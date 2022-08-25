Imports System.Threading

Public Class CSeqRoutineSP790

#Region "Define"
    Dim cSP790 As CDevSP790

    Const numOfChPerDev As Integer = 1 '8  '온도 제어기 한개가 1개 이상의 온도 제어를 할 수 있을 경우를 위해, NX1 = 1, MC9 = 8
    Dim m_nMaxCh As Integer  'UI에서의 채널 개념과 대응되는 채널의 수, 동시에 구동 할 수 있는 수 중에서 현재 클래스에서 담당하는 수
    Dim seedIndex As Integer '현재 클래스에서 담당하는 채널의 시작 인덱스  'm_nMaxCh + SeedIndex = UI 채널 번호
    Dim m_nNumOfTC As Integer '개별 온도 제어가 가능한 온도 컨트롤러의 수 , 만약 온도 제어기 하나에 채널이 8개라면, 제어기수 * 채널수로 입력된 값
    Dim m_numOfDev As Integer

    Dim m_targetTemp() As Double

    Public Sp790Address As Integer = 1
    Public Td500Ch1 As Integer = 1
    Public Td500Ch2 As Integer = 2

    Public Structure sSettingParam
        Dim devID As Integer
        Dim chOfDev As CDevMC9.eCHANNEL
        Dim dTargetTemp As Double
    End Structure

    Dim m_Settings() As CDevSP790.sSettings
    Dim cmdQueue As Queue = New Queue

    Public ReadOnly Property MeasuredData(ByVal devID As Integer, ByVal devCh As Integer) As CDevSP790.sParams
        Get
            'devID = 0 '0 Device 0 번지 데이터만 받아서 처리 2013-04-11 승현
            'devCh = 0
            Return m_Settings(devID).Setting(devCh)
        End Get
    End Property

#End Region

#Region "Init & "
    Public Sub New(ByVal numOfDev As Integer, ByVal seedIdx As Integer)
        seedIndex = seedIdx
        m_numOfDev = numOfDev
        m_nNumOfTC = 1 'numOfDev * numOfChPerDev
        cSP790 = New CDevSP790(numOfDev)
        ReDim m_targetTemp(m_nNumOfTC - 1)
        Dim tempParam(numOfChPerDev - 1) As CDevSP790.sParams
        ReDim m_Settings(numOfDev - 1)

        For i As Integer = 0 To m_Settings.Length - 1
            m_Settings(i).devID = i
            m_Settings(i).numOfCh = numOfChPerDev
            m_Settings(i).Setting = tempParam.Clone
        Next

    End Sub

    Public Sub Dispose()
        Disconnection()
        cSP790 = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

    Dim trdSP790 As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trdSP790 = New Thread(AddressOf trdRoutine)
        trdSP790.Priority = ThreadPriority.Normal
        trdSP790.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub

#Region "Communication"
    Public Function Connection(ByVal config As CCommLib.CComSerial.sCommInfo) As Boolean
        Dim dRetData As String = Nothing


        'If cSP790.Connection(config) = False Then
        '    Return False
        'Else
        '    For idx As Integer = 0 To m_numOfDev - 1
        '        cSP790.OperationRun(seedIndex + idx)
        '    Next
        '    '  If cSP790.sendWHO(Sp790Address, dRetData) = False Then Return False
        'End If


        StartThread()
        Return True
    End Function

    Public Sub Disconnection()

        For idx As Integer = 0 To m_numOfDev - 1
            cSP790.OperationStop(seedIndex + idx)
        Next

        StopThread()
        Application.DoEvents()
        Thread.Sleep(500)
        If cSP790.IsConnected = True Then
            cSP790.Disconnection()
        End If
    End Sub

#End Region

#Region "Function"
    Public Sub SetTemp(ByVal devID As Integer, ByVal temp As Double)
        Dim reqInfos As sSettingParam
        reqInfos.devID = devID
        'reqInfos.chOfDev = chOfDev
        reqInfos.chOfDev = 1
        reqInfos.dTargetTemp = temp
        SyncLock cmdQueue.SyncRoot
            cmdQueue.Enqueue(reqInfos)
        End SyncLock
    End Sub

#End Region


    Private Sub trdRoutine()

        Dim reqInfos As sSettingParam
        Dim nCntCh As Integer = 0
        'Dim nCntidleCh As Integer
        Dim dBeforTemp As Double = Nothing


        Dim fMeas As Boolean = True

        Do
            Application.DoEvents()
            Thread.Sleep(100)

            If fStopTrd = True Then
                Exit Sub
            End If

            SyncLock cmdQueue.SyncRoot

                If cmdQueue.Count > 0 Then
                    reqInfos = cmdQueue.Dequeue
                    fMeas = False
                Else
                    fMeas = True
                End If

            End SyncLock


            If fMeas = True Then

                Dim rcvData As CDevSP790.sParams = Nothing

                For i As Integer = 0 To m_numOfDev - 1

                    If fStopTrd = True Then
                        Exit Sub
                    End If

                    For n As Integer = 0 To m_Settings(i).Setting.Length - 1
                        If cSP790.GetTemperature(seedIndex + i, rcvData) = False Then '.Get_Status(seedIndex + i, i, rcvData) = True Then

                            m_Settings(i).Setting(n).measTemp = reqInfos.dTargetTemp - 0.2 'rcvData.measTemp
                            m_Settings(i).Setting(n).setTemp = reqInfos.dTargetTemp  'rcvData.setTemp

                            ''n = Channel 
                            'For n As Integer = 0 To m_Settings(i).m_Settings.Length - 1
                            '    m_Settings(i).m_Settings(n).measTemp = rcvData(2 + n)
                            '    m_Settings(i).m_Settings(n).setTemp = rcvData(10 + n)

                            '    If rcvData(34 + n) = 2 Then
                            '        m_Settings(i).m_Settings(n).bIsRun = True  
                            '    Else
                            '        m_Settings(i).m_Settings(n).bIsRun = False
                            '    End If
                            'Next

                            'reqInfos.dTargetTemp = 25
                            'cSP790.SetTemperature(seedIndex + i, 1, reqInfos.dTargetTemp)

                        Else

                        End If
                    Next
                Next
               
            Else

                If dBeforTemp <> reqInfos.dTargetTemp Then
                    'If cSP790.SetTemperature(seedIndex + reqInfos.devID, 1, reqInfos.dTargetTemp) = True Then  'ADDR CH RUNSTOP TARGETTEMP

                    'End If
                End If


            End If

        Loop
    End Sub

End Class
