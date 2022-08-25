Imports System.Threading

Public Class CSeqRoutineNX1

#Region "Define"

    Dim cNX1 As CDevNX1
    Dim myParent As frmMain
    '* Address 설정 Argument는 0부터, 내부에서 보낼때는 +1을 해서 1부터
    Const numOfChPerDev As Integer = 1  '온도 제어기 한개가 1개 이상의 온도 제어를 할 수 있을 경우를 위해, NX1 = 1, MC9 = 8
    Dim m_nMaxCh As Integer  'UI에서의 채널 개념과 대응되는 채널의 수, 동시에 구동 할 수 있는 수 중에서 현재 클래스에서 담당하는 수
    Dim m_seedCh As Integer '현재 클래스에서 담당하는 채널의 시작 인덱스  'm_nMaxCh + SeedCh = UI 채널 번호
    Dim m_seedAddr As Integer
    Dim m_nNumOfTC As Integer '개별 온도 제어가 가능한 온도 컨트롤러의 수 , 만약 온도 제어기 하나에 채널이 8개라면, 제어기수 * 채널수로 입력된 값
    Dim m_numOfDev As Integer
    Dim m_allocChPerTC As Integer   '온도 컨트롤러 한개에 할당된 채널의 수(UI)

    Dim m_targetTemp() As Double

    Dim m_MeasuredDatas() As sMeasuredData
    Dim cmdQueue As Queue = New Queue


    Public Structure sMeasuredData
        Dim sDevInfo As String
        Dim dSetTemp As Double
        Dim dMeasuredTemp As Double
    End Structure

    Public Structure sSettingParam
        Dim devID As Integer
        Dim chOfDev As Integer
        Dim dTargetTemp As Double
    End Structure

#End Region

#Region "Property"

    Public ReadOnly Property MeasuredData(ByVal DevNO As Integer) As sMeasuredData
        Get
            'devID = 0 '0 Device 0 번지 데이터만 받아서 처리 2013-04-11 승현
            'devCh = 0
            Return m_MeasuredDatas(DevNO)
        End Get
    End Property

#End Region

#Region "Creator & Disposer"

    Public Sub New(ByVal main As frmMain, ByVal numOfDev As Integer, ByVal seedChannel As Integer, ByVal seedAddress As Integer, ByVal numOfAllocCh As Integer)

        myParent = main
        m_seedCh = seedChannel
        m_seedAddr = seedAddress
        m_numOfDev = numOfDev
        m_nNumOfTC = numOfDev * numOfChPerDev
        m_nMaxCh = numOfAllocCh
        m_allocChPerTC = numOfAllocCh / m_nNumOfTC
        CNX1 = New CDevNX1(numOfDev)
        ReDim m_targetTemp(m_nNumOfTC - 1)
        Dim tempParam(m_numOfDev - 1) As CDevMC9.sParams

        ReDim m_MeasuredDatas(m_nNumOfTC - 1)

        'For i As Integer = 0 To m_Settings.Length - 1
        '    m_Settings(i).devID = i
        '    m_Settings(i).numOfCh = numOfChPerDev
        '    m_Settings(i).m_Settings = tempParam.Clone
        'Next

    End Sub

    Public Sub Dispose()
        Disconnection()
        CNX1 = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


    Public Function Connection(ByVal config As CCommLib.CComSerial.sSerialPortInfo) As Boolean
        If CNX1.Connection(config) = False Then Return False
        For i As Integer = 0 To m_numOfDev - 1
            If cNX1.GetDevInfo(m_seedAddr + i, m_MeasuredDatas(i).sDevInfo) = False Then Return False
        Next
        StartThread()
        Return True
    End Function

    Public Sub Disconnection()
        StopThread()
        Application.DoEvents()
        Thread.Sleep(500)
        If CNX1.IsConnected = True Then
            CNX1.Disconnection()
        End If
    End Sub


    'Public Sub SetTemp(ByVal devID As Integer, ByVal temp As Double)


    '    'reqInfos.nCh = nCh
    '    'reqInfos.SourceSetting = setting


    '    ' If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False
    '    Dim reqInfos As sSettingParam

    '    reqInfos.dTargetTemp = temp
    '    reqInfos.devID = devID
    '    SyncLock cmdQueue.SyncRoot
    '        cmdQueue.Enqueue(reqInfos)
    '    End SyncLock
    'End Sub

    Public Sub SetTemp(ByVal devID As Integer, ByVal temp As Double)

        Dim reqInfos As sSettingParam
        reqInfos.devID = devID
        reqInfos.dTargetTemp = temp
        SyncLock cmdQueue.SyncRoot
            cmdQueue.Enqueue(reqInfos)
        End SyncLock
    End Sub


    Dim trdNX1 As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trdNX1 = New Thread(AddressOf trdRoutine)
        trdNX1.Priority = ThreadPriority.Normal
        trdNX1.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub

    Private Sub trdRoutine()

        Dim reqInfos As sSettingParam
        Dim nCntCh As Integer = 0
        'Dim nCntidleCh As Integer

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

                Dim rcvData() As Double = Nothing

                'i = Device No
                For i As Integer = 0 To m_numOfDev - 1

                    If fStopTrd = True Then
                        Exit Sub
                    End If

                    If CNX1.GetTemperature(m_seedAddr + i, m_MeasuredDatas(i).dMeasuredTemp, m_MeasuredDatas(i).dSetTemp) = True Then
                        For n As Integer = 0 To m_allocChPerTC - 1
                            myParent.g_MeasuredDatas(m_seedCh + (i * m_allocChPerTC + n)).dTemp = m_MeasuredDatas(i).dMeasuredTemp
                        Next
                    Else

                    End If
                Next

            Else

                If CNX1.SetTemperature(m_seedAddr + reqInfos.devID, reqInfos.dTargetTemp) = True Then

                    'Bias(Offset) 갑 설정 가능하게 추가. 2013-03-14
                    'If cMC9.Set_BiasValue(reqInfos.devID, reqInfos.chOfDev, -1) = True Then
                    '    ' 예외 처리
                    'End If

                Else
                    '예외처리
                End If
            End If

        Loop

    End Sub

End Class
