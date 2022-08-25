Imports System.Threading

Public Class CSeqRoutineTD500

#Region "Define"
    Dim cTD500 As CDevTD500

    Public Td500Address As Integer = 1
    Public Td500Ch1 As Integer = 1
    Public Td500Ch2 As Integer = 2

    Public Structure sSettingParam
        Dim dTargetTemp As Double
    End Structure

#End Region
   
#Region "Init & "
    Public Sub New()
        cTD500 = New CDevTD500(0)
    End Sub

    Public Sub Dispose()
        Disconnection()
        cTD500 = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region

    Dim cmdQueue As Queue = New Queue
    Dim trdTD500 As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trdTD500 = New Thread(AddressOf trdRoutine)
        trdTD500.Priority = ThreadPriority.Normal
        trdTD500.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub

    Dim m_Settings As CDevTD500.sSettings

    'Public ReadOnly Property MeasuredData(ByVal devID As Integer, ByVal devCh As Integer) As CDevTD500.sParams
    '    Get
    '        'devID = 0 '0 Device 0 번지 데이터만 받아서 처리 2013-04-11 승현
    '        'devCh = 0
    '        'Return m_Settings(devID).m_Settings(devCh)
    '    End Get
    'End Property

#Region "Communication"
    Public Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim dRetData As String = Nothing


        If cTD500.Connection(config) = False Then
            Return False
        Else
            If cTD500.sendWHO(Td500Address, dRetData) = False Then Return False
        End If

        cTD500.OperationRun(Td500Address, Td500Ch1)

        StartThread()
        Return True
    End Function

    Public Sub Disconnection()
        cTD500.OperationStop(Td500Address, Td500Ch1)

        StopThread()
        Application.DoEvents()
        Thread.Sleep(500)
        If cTD500.IsConnected = True Then
            cTD500.DisConnection()
        End If
    End Sub

#End Region

#Region "Function"
    Public Sub SetTemp(ByVal temp As Double)
        Dim reqInfos As sSettingParam

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

                Dim rcvData As Double = Nothing

                If fStopTrd = True Then
                    Exit Sub
                End If

                If cTD500.GetTemperature(Td500Address, rcvData) = True Then '.Get_Status(seedIndex + i, i, rcvData) = True Then

                    'm_Settings.m_Settings.measTemp = rcvData


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
                Else

                End If
            Else

                If dBeforTemp <> reqInfos.dTargetTemp Then
                    If cTD500.SetTemperature(Td500Address, Td500Ch1, True, reqInfos.dTargetTemp) = True Then  'ADDR CH RUNSTOP TARGETTEMP
                        dBeforTemp = reqInfos.dTargetTemp
                        'm_Settings.m_Settings.setTemp = reqInfos.dTargetTemp

                        'Bias(Offset) 갑 설정 가능하게 추가. 2013-03-14
                        'If cMC9.Set_BiasValue(reqInfos.devID, reqInfos.chOfDev, -1) = True Then
                        '    ' 예외 처리
                        'End If

                    Else
                        '예외처리
                    End If
                End If

              
            End If

        Loop
    End Sub

End Class
