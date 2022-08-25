Imports System.Threading

Public Class CSeqRoutineTemp

    Dim TC As CDevTempController

    Dim m_numOfChPerDev As Integer '= 1  '온도 제어기 한개가 1개 이상의 온도 제어를 할 수 있을 경우를 위해, NX1 = 1, MC9 = 8
    Dim m_nMaxCh As Integer  'UI에서의 채널 개념과 대응되는 채널의 수, 동시에 구동 할 수 있는 수 중에서 현재 클래스에서 담당하는 수
    Dim seedIndex As Integer '현재 클래스에서 담당하는 채널의 시작 인덱스  'm_nMaxCh + SeedIndex = UI 채널 번호
    Dim m_nNumOfTC As Integer '개별 온도 제어가 가능한 온도 컨트롤러의 수 , 만약 온도 제어기 하나에 채널이 8개라면, 제어기수 * 채널수로 입력된 값
    Dim m_numOfDev As Integer

    Dim m_targetTemp() As Double

    Public Structure sSettingParam
        Dim devID As Integer
        Dim chOfDev As CDevMC9.eCHANNEL
        Dim dTargetTemp As Double
    End Structure

    Dim m_settings() As CDevTCCommonNode.sSettings
    Dim cmdQueue As Queue = New Queue

    '  Public Event evChangedOutputState(ByVal DevID As Integer, ByVal outputState() As CDevTCCommonNode.eOutputStatus)
    Public Event evChangedOutputState(ByVal NumOfDev As Integer, ByVal settings() As CDevTCCommonNode.sSettings, ByVal bDisplayAlarm As Boolean)
#Region "Init"

    Public Sub New(ByVal DevType As CDevTCCommonNode.eModel, ByVal numOfDev As Integer, ByVal seedIdx As Integer, ByVal settings As CDevTCCommonNode.sParams)
        TC = New CDevTempController(DevType, numOfDev)

        m_numOfChPerDev = TC.Temperature.NumOfChannelPerDev

        seedIndex = seedIdx
        m_numOfDev = numOfDev
        m_nNumOfTC = numOfDev * m_numOfChPerDev

        ReDim m_targetTemp(m_nNumOfTC - 1)
        Dim tempParam(m_numOfChPerDev - 1) As CDevTCCommonNode.sParams


        m_settings = TC.Temperature.Settings

        For i As Integer = 0 To m_settings.Length - 1
            For j As Integer = 0 To m_settings(i).Setting.Length - 1
                m_settings(i).Setting(j).dEvent1LimitVal_High = settings.dEvent1LimitVal_High
                m_settings(i).Setting(j).dEvent1LimitVal_Low = settings.dEvent1LimitVal_Low
            Next
        Next
        'ReDim m_settings(numOfDev - 1)

        'For i As Integer = 0 To m_settings.Length - 1
        '    m_settings(i).devID = i
        '    m_settings(i).numOfCh = m_numOfChPerDev
        '    m_settings(i).Setting = tempParam.Clone
        'Next

    End Sub

    Public Sub Dispose()
        Disconnection()
        TC.Temperature = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


#Region "Property"

    Public Overridable ReadOnly Property MeasuredData(ByVal devID As Integer, ByVal devCh As Integer) As CDevTCCommonNode.sParams
        Get
            'devID = 0 '0 Device 0 번지 데이터만 받아서 처리 2013-04-11 승현
            'devCh = 0
            Return m_settings(devID).Setting(devCh) ' m_Settings(devID).m_Settings(devCh)
        End Get

    End Property

#End Region


    Dim trdTemp As Thread
    Dim fStopTrd As Boolean


    Private Sub StartThread()
        trdTemp = New Thread(AddressOf trdRoutine)
        trdTemp.Priority = ThreadPriority.Normal
        trdTemp.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub

    Public Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim dRetData As String = Nothing
        config.sSerialInfo.enableTerminator = False
        If TC.Temperature.Connection(config) = False Then
            Return False
        Else
            Dim sInfos As String = Nothing
            For idx As Integer = 0 To m_numOfDev - 1
                If TC.Temperature.DevINFO(seedIndex + idx, sInfos) <> CDevTCCommonNode.eReturnCode.OK Then Return False
                Application.DoEvents()
                Thread.Sleep(100)

                If TC.Temperature.OperationRun(seedIndex + idx) = False Then Return False
                m_settings(idx).Setting(0).bIsRun = True
            Next

        End If

        StartThread()
        Return True
    End Function

    Public Sub Disconnection()
        If TC.Temperature.IsConnected = True Then

            'For idx As Integer = 0 To m_numOfDev - 1
            '    If TC.Temperature.OperationStop(seedIndex + idx) = False Then Exit Sub
            '    m_settings(idx).m_Setting(0).bIsRun = False
            'Next

            StopThread()
            Application.DoEvents()
            Thread.Sleep(500)

            TC.Temperature.Disconnection()
        End If
    End Sub


    Public Sub SetTemp(ByVal devID As Integer, ByVal temp As Double)
        Dim reqInfos As sSettingParam
        reqInfos.devID = devID
        reqInfos.chOfDev = 1
        reqInfos.dTargetTemp = temp
        SyncLock cmdQueue.SyncRoot
            cmdQueue.Enqueue(reqInfos)
        End SyncLock
    End Sub

    Public Sub SetTemp(ByVal devID As Integer, ByVal chOfDev As CDevMC9.eCHANNEL, ByVal temp As Double)
        Dim reqInfos As sSettingParam
        reqInfos.devID = devID
        reqInfos.chOfDev = chOfDev
        reqInfos.dTargetTemp = temp
        SyncLock cmdQueue.SyncRoot
            cmdQueue.Enqueue(reqInfos)
        End SyncLock
    End Sub

    Public Sub GetSetTemp(ByVal devID As Integer, ByRef dTemp As Double)
        dTemp = m_settings(devID).Setting(0).setTemp
    End Sub

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

                '   Dim rcvData() As Double = Nothing
                Dim temp As Double = 0
                Dim getSetTemp As Double = 0

                'i = Device No
                For i As Integer = 0 To m_numOfDev - 1

                    If fStopTrd = True Then
                        Exit Sub
                    End If

                    '이재하 온도부분 잠시정지
                    If TC.Temperature Is Nothing Then Exit Sub

                    'If TC.Temperature.Get_Status(seedIndex + i, i, rcvData) = CDevTCCommonNode.eReturnCode.OK Then

                    '    'n = Channel 
                    '    For n As Integer = 0 To m_settings(i).m_Setting.Length - 1
                    '        m_settings(i).m_Setting(n).measTemp = rcvData(2 + n)
                    '        m_settings(i).m_Setting(n).setTemp = rcvData(10 + n)

                    '        If rcvData(34 + n) = 2 Then
                    '            m_settings(i).m_Setting(n).bIsRun = True
                    '        Else
                    '            m_settings(i).m_Setting(n).bIsRun = False
                    '        End If
                    '    Next
                    'Else

                    'End If
                    'seedIndex
                    If TC.Temperature.GetTemperature(seedIndex + i, temp) = CDevTCCommonNode.eReturnCode.OK Then
                        TC.Temperature.GetSetTemperature(seedIndex + i, getSetTemp)

                        '    'n = Channel 
                        For n As Integer = 0 To m_settings(i).Setting.Length - 1
                            m_settings(i).Setting(n).measTemp = temp
                            m_settings(i).Setting(n).setTemp = getSetTemp
                        Next
                    End If
                Next

            Else


                'MC9
                'If TC.Temperature.SetTemperature(seedIndex + reqInfos.devID, reqInfos.chOfDev, reqInfos.dTargetTemp) = CDevTCCommonNode.eReturnCode.OK Then

                '    'Bias(Offset) 갑 설정 가능하게 추가. 2013-03-14
                '    'If cMC9.Set_BiasValue(reqInfos.devID, reqInfos.chOfDev, -1) = True Then
                '    '    ' 예외 처리
                '    'End If

                'Else
                '    '예외처리
                'End If


                If TC.Temperature.SetTemperature(seedIndex + reqInfos.devID, reqInfos.dTargetTemp) <> CDevTCCommonNode.eReturnCode.OK Then
                    m_settings(reqInfos.devID).Setting(0).setTemp = reqInfos.dTargetTemp
                    m_settings(reqInfos.devID).Setting(0).bIsRun = True
                End If
            End If


            'If TC.Temperature.Model = CDevTCCommonNode.eModel._TOHO_TTM004 Then
            '    Dim sErrorMessage As String = Nothing
            '    Dim nEventCnt As Integer = 0
            '    Dim bDisplayAlarmMessage As Boolean = False

            '    For i As Integer = 0 To m_numOfDev - 1
            '        If TC.Temperature.GetOutputStatus(seedIndex + i, m_settings(i).Setting(0).nOutputState) = CDevTCCommonNode.eReturnCode.OK Then

            '            For j As Integer = 0 To m_settings(i).Setting(0).nOutputState.Length - 1
            '                Select Case m_settings(i).Setting(0).nOutputState(j)
            '                    Case CDevTCCommonNode.eOutputStatus._Limit_Alarm_EV1 ' To CDevTCCommonNode.eOutputStatus._OUT1
            '                        nEventCnt += 1
            '                End Select
            '            Next
            '        Else
            '            '예외처리
            '            '오류 연속 발생 카운트 및 Log처리
            '            '바로 루틴 종료시키면 안됨.
            '        End If

            '        If nEventCnt > 0 Then            '온도 알람 Flage
            '            bDisplayAlarmMessage = True  '온도 알람 Show
            '        Else
            '            bDisplayAlarmMessage = False  '온도 알람 Hide
            '        End If

            '        If fStopTrd = True Then
            '            Exit Sub
            '        End If

            '    Next

            '    RaiseEvent evChangedOutputState(m_numOfDev, m_settings, bDisplayAlarmMessage)

            'End If

            'If fMeas = True Then
            '    Dim RcvData As CDevTCCommonNode.sParams = Nothing

            '    If fStopTrd = True Then
            '        Exit Sub
            '    End If

            '    For i As Integer = 0 To m_numOfDev - 1

            '        If fStopTrd = True Then
            '            Exit Sub
            '        End If

            '        For n As Integer = 0 To m_settings(i).m_Setting.Length - 1
            '            If TC.Temperature.GetTemperature(seedIndex + i, RcvData) = CDevTCCommonNode.eReturnCode.OK Then '.Get_Status(seedIndex + i, i, rcvData) = True Then

            '                m_settings(i).m_Setting(n).measTemp = RcvData.measTemp ' reqInfos.dTargetTemp - 0.2 'rcvData.measTemp
            '                m_settings(i).m_Setting(n).setTemp = reqInfos.dTargetTemp    'rcvData.setTemp

            '            Else

            '            End If
            '        Next
            '    Next
            'Else

            '    If dBeforTemp <> reqInfos.dTargetTemp Then
            '        If TC.Temperature.SetTemperature(seedIndex + reqInfos.devID, reqInfos.dTargetTemp) = True Then  'ADDR CH RUNSTOP TARGETTEMP

            '            dBeforTemp = reqInfos.dTargetTemp
            '        Else
            '            '예외처리
            '        End If
            '    End If


            'End If

        Loop
    End Sub

End Class
