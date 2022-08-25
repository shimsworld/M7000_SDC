Imports System.Threading

Public Class CSeqRoutineM6000


#Region "Define"

    Public McSMU As CDevM6000PLUS
    Dim m_nBoardNum As Integer
    Private Const m_nChPerBoard As Integer = 4
    Dim m_nMaxCh As Integer
    Dim m_nSeedIndex As Integer
    Dim requestQueue As Queue
    Dim g_SeqRoutineStatus() As eSequenceState
    Dim g_SourceSettings() As CDevM6000PLUS.sSettingParams
    Dim g_MeasuredData() As CDevM6000PLUS.sMeasParams
    Dim m_DeviceError As sDeviceError
    Dim g_LimitSettings()() As ucLimitSetting.sLimitSetting
    Dim g_ACK As Boolean = False
    Dim m_ID As Integer '
    Dim g_ChangeSourceSettings() As CDevM6000CommonNode.sSettingParams '모드 별 세팅 파라메터 변경
    Dim myParent As frmMain 'Limmited Value 전달용 Main 문 선언
    Dim m_HWLimitConditions() As String = New String() {"[Stop High Voltage HW Limit]", "[Stop Low Voltage HW Limit]", "[Stop High Current HW Limit]", "[Stop Low Current HW Limit]"}
    Public Event evAlarm(ByVal DevID As Integer, ByVal chOfDev As Integer, ByVal alarmInfo As eAlarm)

#Region "Enums"

    Public Enum eSequenceState
        eidle
        eSetSource
        eFastSetSource
        eMeasuring
        eReset
        eReadCal
    End Enum

    Public Enum eAlarm
        _LimitAlarm_Bias_OverVolt
        _LimitAlarm_Bias_OverCurrent
        _LimitAlarm_Amplitude_OverVolt
        _LimitAlarm_Amplitude_OverCurrent
    End Enum
    Public Enum eStatus
        _NoError
        _ErrorOccurred
    End Enum
    Public Enum eHWLimitConditions
        OverVoltage = 1
        LowVoltage = 2
        OverCurrent = 3
        LowCurrent = 4
    End Enum
    Structure sChannelError
        Dim nErrorCounter As Integer
        Dim nStatus As eStatus
    End Structure


#End Region

#Region "Structure"

    Public Structure sSettingInfo
        Dim nCh As Integer
        Dim SourceSetting As CDevM6000PLUS.sSettingParams
    End Structure

    Structure sDeviceError
        Dim nDevice As eStatus
        Dim Channel() As sChannelError
    End Structure
#End Region

#End Region

#Region "Properties"

    Public Property ACK() As Boolean
        Get
            Return g_ACK
        End Get
        Set(ByVal value As Boolean)
            g_ACK = value
        End Set
    End Property
    Public ReadOnly Property ChannelStatus() As eSequenceState()
        Get
            Return g_SeqRoutineStatus
        End Get
    End Property

    Public ReadOnly Property MeasuredData(ByVal nCh As Integer) As CDevM6000PLUS.sMeasParams
        Get
            Return g_MeasuredData(nCh)
        End Get
    End Property
    Public Property DeviceError() As sDeviceError
        Get
            Return m_DeviceError
        End Get
        Set(ByVal value As sDeviceError)
            m_DeviceError = value
        End Set
    End Property
    'Public WriteOnly Property MainStatus() As frmMain
    '    Set(value As frmMain)
    '        fmain = value
    '    End Set
    'End Property

#End Region

    Public Sub New(ByVal ID As Integer, ByVal boardNum As Integer, ByVal seedIdx As Integer, ByVal main As frmMain)
        myParent = main

        m_ID = ID
        m_nSeedIndex = seedIdx
        m_nBoardNum = boardNum
        m_nMaxCh = m_nBoardNum * m_nChPerBoard
        ReDim g_SeqRoutineStatus(m_nMaxCh - 1)
        ReDim g_SourceSettings(m_nMaxCh - 1)
        ReDim g_MeasuredData(m_nMaxCh - 1)
        ReDim g_LimitSettings(m_nMaxCh - 1)
        ReDim m_DeviceError.Channel(m_nMaxCh - 1)
        ReDim g_ChangeSourceSettings(m_nMaxCh - 1)
        McSMU = New CDevM6000PLUS(m_ID, m_nBoardNum)

        m_DeviceError.nDevice = eStatus._NoError

        For i As Integer = 0 To m_nMaxCh - 1
            g_SeqRoutineStatus(i) = eSequenceState.eidle
            '  g_RecievedDataStatus(i) = False
            m_DeviceError.Channel(i).nStatus = eStatus._NoError
            m_DeviceError.Channel(i).nErrorCounter = 0
        Next

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose()
        Disconnection()
        McSMU = Nothing
        Finalize()
    End Sub

    Public Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        If McSMU.Connection(config) = False Then Return False

        StartThread()
        Return True
    End Function


    Public Sub Disconnection()
        StopThread()
        Application.DoEvents()
        Thread.Sleep(100)
        If McSMU Is Nothing = False Then
            If McSMU.IsConnected = True Then
                McSMU.Disconnection()
            End If
        End If
    End Sub


    Public Function Request(ByVal nCh As Integer, ByVal state As eSequenceState) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False

        g_SeqRoutineStatus(nCh) = state

        Return True
    End Function

    Public Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal setting As CDevM6000PLUS.sSettingParams, ByVal Limit() As ucLimitSetting.sLimitSetting) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False

        g_SeqRoutineStatus(nCh) = state
        g_SourceSettings(nCh) = setting
        g_LimitSettings(nCh) = Limit

        Return True
    End Function
    Public Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal setting As CDevM6000PLUS.sSettingParams) As Boolean
        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False

        g_SeqRoutineStatus(nCh) = state
        g_SourceSettings(nCh) = setting

        McSMU.Settings(nCh) = setting

        Return True
    End Function

    Public Sub ResetAll()
        For i As Integer = 0 To m_nMaxCh - 1
            g_SeqRoutineStatus(i) = eSequenceState.eReset
        Next
    End Sub

    Dim trdM6000 As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trdM6000 = New Thread(AddressOf trdRoutine)
        trdM6000.Priority = ThreadPriority.Normal
        trdM6000.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub

    Private Sub trdRoutine()

        'Dim ctrlInfos As sSettingInfo
        Dim nCntCh As Integer = 0
        Dim nCntidleCh As Integer
        Dim nSleepTime As Integer = 100
        Dim bReConnection As Boolean = False

        Do
            Application.DoEvents()
            Thread.Sleep(nSleepTime)

            If fStopTrd = True Then
                Exit Sub
            End If

            g_ACK = False
            If McSMU.ACK = False Then
                g_ACK = True
                myParent.HWStatusColor(g_nHWM6000StartIndex + m_ID, Color.Yellow)
            Else
                g_ACK = False
                myParent.HWStatusColor(g_nHWM6000StartIndex + m_ID, Color.LimeGreen)
            End If
            'SyncLock requestQueue.SyncRoot


            '    If requestQueue.Count > 0 Then
            '        ctrlInfos = requestQueue.Dequeue
            '    End If

            'End SyncLock
            If g_ACK = False Then
                Select Case g_SeqRoutineStatus(nCntCh)

                    Case eSequenceState.eidle
                        g_MeasuredData(nCntCh).dVoltage_Bias = 0
                        g_MeasuredData(nCntCh).dVoltage_Amplitude = 0
                        g_MeasuredData(nCntCh).dCurrent_Amplitude = 0
                        g_MeasuredData(nCntCh).dCurrent_Bias = 0
                        g_MeasuredData(nCntCh).dPDCurrent = 0
                        nCntidleCh += 1
                    Case eSequenceState.eReset

                        If McSMU.CellOFF(nCntCh) = True Then
                            g_MeasuredData(nCntCh).dVoltage_Bias = 0
                            g_MeasuredData(nCntCh).dVoltage_Amplitude = 0
                            g_MeasuredData(nCntCh).dCurrent_Amplitude = 0
                            g_MeasuredData(nCntCh).dCurrent_Bias = 0
                            g_MeasuredData(nCntCh).dPDCurrent = 0
                            nSleepTime = 100
                            g_SeqRoutineStatus(nCntCh) = eSequenceState.eidle
                        Else
                            nSleepTime = 1000

                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error,
                                                                              "Reset in sequence routine, [Device ID :" & Format(m_ID, "00") & "] [Channel : " & Format(nCntCh, "00") & " ]")
                            '예외처리
                        End If

                    Case eSequenceState.eMeasuring

                        Dim strVolt_Bias As String = Nothing
                        Dim strVolt_Amplitude As String = Nothing
                        Dim strCurr_Bias As String = Nothing
                        Dim strCurr_Amplitude As String = Nothing
                        Dim strPDCurr As String = Nothing
                        Dim strLimit As String = Nothing
                        Dim ErrorChk As Boolean = False

                        If McSMU.Measurement(nCntCh, strVolt_Bias, strVolt_Amplitude, strCurr_Bias, strCurr_Amplitude, strPDCurr, strLimit, ErrorChk) = True Then
                            m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                            myParent.cTimeScheduler.g_BoardErrorStatus(nCntCh + m_nSeedIndex) = False
                            '    g_RecievedDataStatus(nCntCh) = True

                            '1)측정 후 PD값 변화 확인
                            nSleepTime = 100
                            g_MeasuredData(nCntCh).dVoltage_Bias = CDbl(strVolt_Bias)
                            g_MeasuredData(nCntCh).dVoltage_Amplitude = CDbl(strVolt_Amplitude)
                            g_MeasuredData(nCntCh).dCurrent_Bias = CDbl(strCurr_Bias) '* 0.001 'mA->A
                            g_MeasuredData(nCntCh).dCurrent_Amplitude = CDbl(strCurr_Amplitude) '* 0.001 'mA->A
                            g_MeasuredData(nCntCh).dPDCurrent = CDbl(strPDCurr) '/ 1000000 'uA->A
                            bReConnection = False

                            'HW Limit Check
                            If IsCheckedHWLimitConditions(nCntCh, strLimit) = True Then
                                myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & "      V :   " & g_MeasuredData(nCntCh).dVoltage_Bias & "     mA :     " & g_MeasuredData(nCntCh).dCurrent_Bias)
                                myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                            End If

                            'SW Limit Check
                            ' ddd()
                        Else    'Meas실패 시 한번 더 시도한다.

                            If McSMU.Measurement(nCntCh, strVolt_Bias, strVolt_Amplitude, strCurr_Bias, strCurr_Amplitude, strPDCurr, strLimit, ErrorChk) = True Then
                                m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                                myParent.cTimeScheduler.g_BoardErrorStatus(nCntCh + m_nSeedIndex) = False
                                ' g_RecievedDataStatus(nCntCh) = True

                                '1)측정 후 PD값 변화 확인
                                If g_SourceSettings(nCntCh).source.nConstantBrightnessMode = True Then
                                End If
                                'End If

                                nSleepTime = 100
                                g_MeasuredData(nCntCh).dVoltage_Bias = CDbl(strVolt_Bias)
                                g_MeasuredData(nCntCh).dVoltage_Amplitude = CDbl(strVolt_Amplitude)
                                g_MeasuredData(nCntCh).dCurrent_Bias = CDbl(strCurr_Bias) '* 0.001 'mA->A
                                g_MeasuredData(nCntCh).dCurrent_Amplitude = CDbl(strCurr_Amplitude) '* 0.001 'mA->A
                                g_MeasuredData(nCntCh).dPDCurrent = CDbl(strPDCurr) '/ 1000000 'uA->A
                                'g_MeasuredData(nCntCh).dLuminance_Candela = CalculatePDCd(nCntCh, CDbl(strPDCurr))

                                bReConnection = False

                                'HW Limit Check
                                If IsCheckedHWLimitConditions(nCntCh, strLimit) = True Then
                                    myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & "      V :   " & g_MeasuredData(nCntCh).dVoltage_Bias & "     mA :     " & g_MeasuredData(nCntCh).dCurrent_Bias)
                                    myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                    g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                                End If

                                'SW Limit Check
                                'ddd()
                            Else
                                m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                                nSleepTime = 1000
                                bReConnection = True
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Measure)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                            End If
                        End If

                    Case eSequenceState.eSetSource
                        Dim ErrorChk As Boolean = False
                        Dim strLimit_SetSource As String = Nothing

                        If McSMU.Reset(nCntCh) = False Then
                            nSleepTime = 1000
                            bReConnection = True
                            m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Reset)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                        Else
                            bReConnection = False
                            m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                        End If

                        Application.DoEvents()
                        Thread.Sleep(10)
                        m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                        bReConnection = False

                        'If McSMU.Set_OverVoltageValue(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(0).LimitValue.dMin, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(0).LimitValue.dMax) = False Then
                        '    If McSMU.Set_OverVoltageValue(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(0).LimitValue.dMin, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(0).LimitValue.dMax) = False Then
                        '        nSleepTime = 1000
                        '        bReConnection = True
                        '        m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                        '        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Set OverVoltage)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                        '    End If
                        'End If

                        Application.DoEvents()
                        Thread.Sleep(10)

                        'If McSMU.Set_OverCurrentValue(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(1).LimitValue.dMin, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(1).LimitValue.dMax) = False Then
                        '    If McSMU.Set_OverCurrentValue(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(1).LimitValue.dMin, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits(1).LimitValue.dMax) = False Then
                        '        nSleepTime = 1000
                        '        bReConnection = True
                        '        m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                        '        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Set OverCurrent)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                        '    End If
                        'End If

                        If McSMU.InitializeM6000(nCntCh, g_ChRangeInfo(nCntCh + m_nSeedIndex), g_SourceSettings(nCntCh)) = True Then

                            If g_nMaxCh <= 31 Then
                                Application.DoEvents()
                                Thread.Sleep(200)
                            Else
                                Application.DoEvents()
                                Thread.Sleep(200)
                            End If

                            ''AutoRange , CC 1mA이상일 떄 자동으로 Range 변경하는 구문 -1~ 1은 1mA Range 사용하고 그외는 10mA Range로 자동 변경한다.
                            'If g_SourceSettings(nCntCh).source.Mode = CDevM6000CommonNode.eMode.eCC Then
                            '    If g_SourceSettings(nCntCh).source.dBiasValue <= 1 And g_SourceSettings(nCntCh).source.dBiasValue >= -1 Then
                            '        McSMU.M6000.Set_CurrentRange(nCntCh, CDevM6000CommonNode.eCurrentRange._RANGE_1)
                            '        McSMU.M6000.Set_OverCurrentValue(nCntCh, -0.00105, 0.00105)
                            '    Else
                            '        McSMU.M6000.Set_CurrentRange(nCntCh, CDevM6000CommonNode.eCurrentRange._RANGE_2)
                            '        McSMU.M6000.Set_OverCurrentValue(nCntCh, -0.0105, 0.0105)
                            '    End If
                            'End If

                            'Application.DoEvents()
                            'Thread.Sleep(10)

                            'If g_SourceSettings(nCntCh).source.Mode = CDevM6000CommonNode.eMode.ePC Or g_SourceSettings(nCntCh).source.Mode = CDevM6000CommonNode.eMode.ePCV Then
                            '    McSMU.M6000.Set_CurrentRange(nCntCh, CDevM6000CommonNode.eCurrentRange._RANGE_2)
                            '    McSMU.M6000.Set_OverCurrentValue(nCntCh, -0.0105, 0.0105)
                            'End If

                            'Application.DoEvents()
                            'Thread.Sleep(10)

                            If McSMU.BiasSettings(nCntCh, g_SourceSettings(nCntCh), Nothing) = True Then
                                m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                                bReConnection = False
                                g_ChangeSourceSettings(nCntCh) = g_SourceSettings(nCntCh)
                                nSleepTime = 100

                                If g_nMaxCh >= 31 Then
                                    Application.DoEvents()
                                    Thread.Sleep(500)
                                Else
                                    Application.DoEvents()
                                    Thread.Sleep(200)
                                End If

                                '' myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Bias Settings Ok)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))

                                Dim strVolt_Bias As String = Nothing
                                Dim strVolt_Amplitude As String = Nothing
                                Dim strCurr_Bias As String = Nothing
                                Dim strCurr_Amplitude As String = Nothing
                                Dim strPDCurr As String = Nothing
                                Dim strLimit As String = Nothing

                                If McSMU.Measurement(nCntCh, strVolt_Bias, strVolt_Amplitude, strCurr_Bias, strCurr_Amplitude, strPDCurr, strLimit, ErrorChk) = True Then

                                    m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                                    bReConnection = False
                                    myParent.cTimeScheduler.g_BoardErrorStatus(nCntCh + m_nSeedIndex) = False
                                    nSleepTime = 100
                                    g_MeasuredData(nCntCh).dVoltage_Bias = CDbl(strVolt_Bias)
                                    g_MeasuredData(nCntCh).dVoltage_Amplitude = CDbl(strVolt_Amplitude)
                                    g_MeasuredData(nCntCh).dCurrent_Bias = CDbl(strCurr_Bias) '* 0.001 'mA->A
                                    g_MeasuredData(nCntCh).dCurrent_Amplitude = CDbl(strCurr_Amplitude) '* 0.001 'mA->A
                                    g_MeasuredData(nCntCh).dPDCurrent = CDbl(strPDCurr) '* 0.000001 ' uA->A
                                    '  g_MeasuredData(nCntCh).dLuminance_Candela = CalculatePDCd(nCntCh, strPDCurr) 'uA 기준으로 Calibratio 하기 때문에 변환값 적용(X)

                                    'HW Limit Check
                                    If IsCheckedHWLimitConditions(nCntCh, strLimit) = True Then
                                        myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                        myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & "      V :   " & g_MeasuredData(nCntCh).dVoltage_Bias & "     mA :     " & g_MeasuredData(nCntCh).dCurrent_Bias)
                                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                                        g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                    Else
                                        If g_SeqRoutineStatus(nCntCh) <> eSequenceState.eReset Then
                                            g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                                            '' myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Convert State : eMeasuring)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                                        End If
                                    End If

                                    'SW LImit Check
                                    'If IsCheckedLimitConditions(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits) = True Then
                                    '    myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                    '    myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                    '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                                    '    g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                    'Else
                                    '    If g_SeqRoutineStatus(nCntCh) <> eSequenceState.eReset Then
                                    '        g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                                    '        ''    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Convert State : eMeasuring)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                                    '    End If
                                    'End If

                                Else
                                    Application.DoEvents()
                                    Thread.Sleep(500)

                                    If McSMU.Measurement(nCntCh, strVolt_Bias, strVolt_Amplitude, strCurr_Bias, strCurr_Amplitude, strPDCurr, strLimit, ErrorChk) = True Then
                                        nSleepTime = 100
                                        m_DeviceError.Channel(nCntCh).nErrorCounter = 0
                                        bReConnection = False
                                        myParent.cTimeScheduler.g_BoardErrorStatus(nCntCh + m_nSeedIndex) = False
                                        nSleepTime = 100
                                        g_MeasuredData(nCntCh).dVoltage_Bias = CDbl(strVolt_Bias)
                                        g_MeasuredData(nCntCh).dVoltage_Amplitude = CDbl(strVolt_Amplitude)
                                        g_MeasuredData(nCntCh).dCurrent_Bias = CDbl(strCurr_Bias) '* 0.001 'mA->A
                                        g_MeasuredData(nCntCh).dCurrent_Amplitude = CDbl(strCurr_Amplitude) '* 0.001 'mA->A
                                        g_MeasuredData(nCntCh).dPDCurrent = CDbl(strPDCurr) '* 0.000001 ' uA->A
                                        '  g_MeasuredData(nCntCh).dLuminance_Candela = CalculatePDCd(nCntCh, strPDCurr) 'uA 기준으로 Calibratio 하기 때문에 변환값 적용(X)

                                        'HW Limit Check
                                        If IsCheckedHWLimitConditions(nCntCh, strLimit) = True Then
                                            myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                            myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Meausre HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & "      V :   " & g_MeasuredData(nCntCh).dVoltage_Bias & "     mA :     " & g_MeasuredData(nCntCh).dCurrent_Bias)
                                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.HW Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                                            g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                        Else
                                            If g_SeqRoutineStatus(nCntCh) <> eSequenceState.eReset Then
                                                g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                                            End If
                                        End If

                                        'SW LImit Check
                                        'If IsCheckedLimitConditions(nCntCh, myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits) = True Then
                                        '    myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                        '    myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                        '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Limit)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                                        '    g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                        'Else
                                        '    If g_SeqRoutineStatus(nCntCh) <> eSequenceState.eReset Then
                                        '        g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                                        '        'g_seqIVLState(nCntCh) = eIVLState.eIDLE
                                        '    End If
                                        'End If

                                    Else
                                        nSleepTime = 1000
                                        bReConnection = True
                                        m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Set TO Measure)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                                    End If
                                    End If
                            Else
                                nSleepTime = 1000
                                bReConnection = True
                                m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Func.Source Setting)" & " , CH:" & nCntCh + m_nSeedIndex + 1)
                            End If

                        Else
                            nSleepTime = 1000
                            bReConnection = True
                            m_DeviceError.Channel(nCntCh).nErrorCounter += 1
                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Meas Initialize Fail)" & " , CH:" & nCntCh + m_nSeedIndex + 1 & ", Error Counter = " & Format(m_DeviceError.Channel(nCntCh).nErrorCounter, "00"))
                        End If

                        '   End If

                    Case eSequenceState.eFastSetSource

                        'CC일때는 initialize 진행해야됨
                        If g_SourceSettings(nCntCh).source.Mode = CDevM6000CommonNode.eMode.eCC Then
                            If McSMU.InitializeM6000(nCntCh, g_ChRangeInfo(nCntCh + m_nSeedIndex), g_SourceSettings(nCntCh)) = True Then
                                Application.DoEvents()
                                Thread.Sleep(200)

                                If McSMU.BiasSettings(nCntCh, g_SourceSettings(nCntCh), Nothing) = True Then
                                    g_MeasuredData(nCntCh).Mode = g_SourceSettings(nCntCh).source.Mode

                                    Application.DoEvents()
                                    Thread.Sleep(30)

                                    nSleepTime = 100
                                    g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                                Else
                                    nSleepTime = 1000
                                    '예외처리 필요
                                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error,
                                                                                                   "BiasSettings in sequence routine, reconnection, [Device ID :" & Format(m_ID, "00") & "] [Channel : " & Format(nCntCh, "00") & " ]")
                                End If
                            End If

                        Else 'CV일떄는 initialize 진행안해도됨
                            If McSMU.BiasSettings(nCntCh, g_SourceSettings(nCntCh), Nothing) = True Then

                                Application.DoEvents()
                                Thread.Sleep(30)

                                g_MeasuredData(nCntCh).Mode = g_SourceSettings(nCntCh).source.Mode
                                nSleepTime = 100
                                g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring
                            Else
                                nSleepTime = 1000
                                '예외처리 필요
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error,
                                                                                               "BiasSettings in sequence routine, reconnection, [Device ID :" & Format(m_ID, "00") & "] [Channel : " & Format(nCntCh, "00") & " ]")
                            End If
                        End If
                End Select

                'Limit 조건 추가 2013-04-14 ------------------------------------------------------------
                '실험 종료 조건 비교 Limitted 조건 초과 시 Over 메세지와 함께 해당 채널 측정 종료

                If g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring Then

                    If g_SystemOptions.bEnableAlarm = True Then

                        'If g_LimitSettings(nCntCh) Is Nothing = False Then

                        If g_LimitSettings(nCntCh) Is Nothing = False Then
                            Dim ucLimmited() As ucLimitSetting.sLimitSetting '= g_LimitSettings(nCntCh).Clone
                            ucLimmited = myParent.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits.Clone

                            For i As Integer = 0 To ucLimmited.Length - 1
                                If ucLimmited(i).LimitValue.dMax <> 0 Or ucLimmited(i).LimitValue.dMin <> 0 Then
                                    Select Case ucLimmited(i).eTypeOfValue
                                        Case ucLimitSetting.eLimitValueType.eVoltage
                                            If ucLimmited(i).eTypeOfValue = ucLimitSetting.eLimitValueType.eVoltage Then
                                                If g_MeasuredData(nCntCh).dVoltage_Bias <> 0 Then
                                                    If g_MeasuredData(nCntCh).dVoltage_Bias < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dVoltage_Bias > ucLimmited(i).LimitValue.dMax Then
                                                        myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                                        myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                                        g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                                        RaiseEvent evAlarm(m_ID, nCntCh, eAlarm._LimitAlarm_Bias_OverVolt)
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                            'If g_MeasuredData(nCntCh).dVoltage_Amplitude < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dVoltage_Amplitude > ucLimmited(i).LimitValue.dMax Then
                                            '    myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                            '    myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                            '    g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                            '    RaiseEvent evAlarm(m_ID, nCntCh, eAlarm._LimitAlarm_Amplitude_OverVolt)
                                            '    Exit For
                                            'End If

                                        Case ucLimitSetting.eLimitValueType.eCurrent
                                            If ucLimmited(i).eTypeOfValue = ucLimitSetting.eLimitValueType.eCurrent Then
                                                If g_MeasuredData(nCntCh).dCurrent_Bias <> 0 Then
                                                    If g_MeasuredData(nCntCh).dCurrent_Bias < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dCurrent_Bias > ucLimmited(i).LimitValue.dMax Then
                                                        myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                                        myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                                        g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                                        RaiseEvent evAlarm(m_ID, nCntCh, eAlarm._LimitAlarm_Bias_OverCurrent)
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                            'If g_MeasuredData(nCntCh).dCurrent_Amplitude < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dCurrent_Amplitude > ucLimmited(i).LimitValue.dMax Then
                                            '    myParent.SequenceList(nCntCh + m_nSeedIndex).RequestTest = False
                                            '    myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                                            '    g_SeqRoutineStatus(nCntCh) = eSequenceState.eReset
                                            '    RaiseEvent evAlarm(m_ID, nCntCh, eAlarm._LimitAlarm_Amplitude_OverCurrent)
                                            '    Exit For
                                            'End If
                                    End Select
                                End If

                            Next

                        End If

                    End If

                End If

                '---------------------------------------------------------------------------

                If bReConnection = True Then

                    McSMU.Disconnection()
                    Application.DoEvents()
                    Thread.Sleep(10000)
                    McSMU.Connection()
                    If McSMU.ReadCalibrationData() = True Then
                        bReConnection = False
                    End If

                End If

                nCntCh += 1
                If nCntCh >= m_nMaxCh Then

                    If nCntidleCh >= m_nMaxCh Then

                        'ACK  명령 추가
                        If McSMU.ACK = True Then
                            nSleepTime = 100
                        Else
                            nSleepTime = 100
                        End If
                    End If

                    Thread.Sleep(nSleepTime)

                    nCntidleCh = 0
                    nCntCh = 0
                End If
            Else
                McSMU.Disconnection()
                Application.DoEvents()
                Thread.Sleep(3000)
                If McSMU.Connection() = True Then
                    bReConnection = False
                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "ACK Re-Connection OK")
                Else
                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "ACK Re-Connection Failure")
                End If
            End If
        Loop
    End Sub
    Private Function IsCheckedHWLimitConditions(ByVal nCntCh As Integer, ByVal RevData As String) As Boolean
        If RevData Is Nothing Then Return False

        If RevData = eHWLimitConditions.OverVoltage Then ' 1
            myParent.frmMonitorUI.Message(nCntCh + m_nSeedIndex) = m_HWLimitConditions(eHWLimitConditions.OverVoltage - 1) '"[High Voltage Limit]"
            Return True
        ElseIf RevData = eHWLimitConditions.LowVoltage Then ' 2
            myParent.frmMonitorUI.Message(nCntCh + m_nSeedIndex) = m_HWLimitConditions(eHWLimitConditions.LowVoltage - 1) '"[Low Voltage Limit]"
            Return True
        ElseIf RevData = eHWLimitConditions.OverCurrent Then ' 3
            myParent.frmMonitorUI.Message(nCntCh + m_nSeedIndex) = m_HWLimitConditions(eHWLimitConditions.OverCurrent - 1) '"[High Current Limit]"
            Return True
        ElseIf RevData = eHWLimitConditions.LowCurrent Then ' 4
            myParent.frmMonitorUI.Message(nCntCh + m_nSeedIndex) = m_HWLimitConditions(eHWLimitConditions.LowCurrent - 1) '"[Low Current Limit]"
            Return True
        End If

        Return False
    End Function
    Public Shared Function ConvertM6000RecipeToSeqRoutineSettings(ByVal cellSettings As ucDispCellLifetime.sSourceSetting, ByRef seqRoutineSetting As CSeqRoutineM6000.sSettingInfo) As Boolean

        Dim setting As ucDispCellLifetime.sSourceSetting = cellSettings

        With seqRoutineSetting
            .SourceSetting.bOutputState = CDevM6000PLUS.eONOFF.eON
            .SourceSetting.source.dAmplitude = setting.dAmplitude
            .SourceSetting.source.dBiasValue = setting.dBias
            .SourceSetting.source.Mode = setting.Mode
            .SourceSetting.source.Pulse.dDuty = setting.Pulse.dDuty
            .SourceSetting.source.Pulse.dFrequency = setting.Pulse.dFrequency
            '  .SourceSetting.source.nConstantBrightnessMode = setting.nConstantBrightnessMode
        End With

        Return True
    End Function

#Region "Support Functions"

    Public Shared Function ConvertIntSequenceStateToString(ByVal nState As eSequenceState) As String
        Return nState.ToString
    End Function

    Public Shared Function ConvertStringSequenceStateToInteger(ByVal strSequenceState As String) As Integer
        Select Case strSequenceState
            Case eSequenceState.eidle.ToString
                Return eSequenceState.eidle
            Case eSequenceState.eSetSource.ToString
                Return eSequenceState.eSetSource
            Case eSequenceState.eMeasuring.ToString
                Return eSequenceState.eMeasuring
            Case eSequenceState.eReset.ToString
                Return eSequenceState.eReset
            Case eSequenceState.eReadCal.ToString
                Return eSequenceState.eReadCal
            Case Else
                Return -1
        End Select
    End Function

#End Region

End Class
