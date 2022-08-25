Imports System.Threading
Imports System.IO
Public Class CSeqRoutineSG

    Public cSG As cDevSG
    Public myParent As frmMain
    '* Address 설정 Argument는 0부터, 내부에서 보낼때는 +1을 해서 1부터
    Const numOfChPerDev As Integer = 8  '온도 제어기 한개가 1개 이상의 온도 제어를 할 수 있을 경우를 위해, NX1 = 1, MC9 = 8

    Dim seedCh As Integer '현재 클래스에서 담당하는 채널의 시작 인덱스  'm_nMaxCh + SeedIndex = UI 채널 번호
    Dim seedAddr As Integer
    Dim m_nNumOfCh As Integer 'Panel을 개별 제어할S 수 , 만약 G 하나에 채널이 8개라면, 제어기수 * 채널수로 입력된 값
    Dim m_nMaxCh As Integer  'UI에서의 채널 개념과 대응되는 채널의 수, 동시에 구동 할 수 있는 수 중에서 현재 클래스에서 담당하는 수, m_nNumOfCh 과 같은 값이다....
    Dim m_numOfDev As Integer

    Dim m_BoardInfo() As cDevSG.sBoardInfo

    Dim cmdQueue As Queue = New Queue
    Dim m_SeqRoutineStatus() As eSequenceState
    Dim m_SourceSettings() As sSettingParam
    Dim m_MeasuredData() As sMeasuredData

    Dim m_bIsPaused As Boolean = False

    Dim m_SGChMap() As sSGMap

#Region "Enums"

    Public Enum eSequenceState
        eidle
        eSetSource
        eMeasuring
        eReset
        eBoardReset
        eReadCal
    End Enum



#End Region


#Region "Define"


#Region "Struecture"

    Public Structure sRGBRotationInfos
        Dim bRotationUse As Boolean
        Dim sRotationParameter() As sRGBParemeter
    End Structure

    Public Structure sRGBParemeter
        Dim dDelay As Double
        Dim dRed As Double
        Dim dGreen As Double
        Dim dBlue As Double
        Dim sSignalName As String
    End Structure

    Public Structure sSettingParam
        Dim devID As Integer
        Dim chOfDev As Integer
        Dim CMDState As eSequenceState
        Dim MainPower() As CDevSG.sSettingParam
        Dim SubPower() As CDevSG.sSettingParam
        Dim Signal() As CDevSG.sSettingParam
        Dim MainPowerLimit() As CDevSG.sLimit
    End Structure

    Public Structure sMeasuredData
        Dim dELVDD_I As Double
        Dim dELVDD_V As Double
        Dim dELVSS_I As Double
        Dim dELVSS_V As Double
        Dim dTOTAL_I As Double
        Dim dPD_I As Double
        Dim dELVDD_Temp As Double
        Dim dELVSS_Temp As Double
    End Structure

    Public Structure sSGMap
        Dim nMainPower() As Integer
        Dim nSubPower() As Integer
        Dim nSignal() As Integer
        Dim nPDCh() As Integer
    End Structure


#End Region

   



#End Region


#Region "Properties"

    Public ReadOnly Property ChannelStatus() As eSequenceState()
        Get
            Return m_SeqRoutineStatus
        End Get
    End Property

    Public ReadOnly Property MeasuredData(ByVal ch As Integer) As sMeasuredData
        Get
            Return m_MeasuredData(ch)
        End Get
    End Property

    Public Property EnableSequenceRoutinePaused()
        Get
            Return m_bIsPaused
        End Get
        Set(ByVal value)
            m_bIsPaused = value
        End Set
    End Property

    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return cSG.IsConnected
        End Get
    End Property

#End Region



#Region "Creator & Disposer"

    Public Sub New(ByVal main As frmMain, ByVal numOfDev As Integer, ByVal seedAddress As Integer, ByVal seedChannel As Integer, ByVal initParam As cDevSG.sInitialParam)
        myParent = main
        seedCh = seedChannel
        seedAddr = seedAddress
        m_numOfDev = numOfDev
        m_nNumOfCh = numOfDev * numOfChPerDev
        m_nMaxCh = m_nNumOfCh
        cSG = New cDevSG(initParam)
        ReDim m_SeqRoutineStatus(m_nNumOfCh - 1)
        ReDim m_BoardInfo(m_nNumOfCh - 1)
        ReDim m_SourceSettings(m_nNumOfCh - 1)
        ReDim m_MeasuredData(m_nNumOfCh - 1)
        ReDim m_SGChMap(m_nNumOfCh - 1)

        For i As Integer = 0 To m_SeqRoutineStatus.Length - 1
            m_SeqRoutineStatus(i) = eSequenceState.eidle
        Next

        For i As Integer = 0 To m_SGChMap.Length - 1
            ReDim m_SGChMap(i).nMainPower(1)
            m_SGChMap(i).nMainPower(0) = i * 2
            m_SGChMap(i).nMainPower(1) = i * 2 + 1

            'Signal, Subpower는 필요 없을 것 같음.
            ReDim m_SGChMap(i).nSubPower(11)
            For n As Integer = 0 To m_SGChMap(i).nSubPower.Length - 1
                m_SGChMap(i).nSubPower(n) = n
            Next

            ReDim m_SGChMap(i).nSignal(25)
            For n As Integer = 0 To m_SGChMap(i).nSignal.Length - 1
                m_SGChMap(i).nSignal(n) = n
            Next

            ReDim m_SGChMap(i).nPDCh(0)
            m_SGChMap(i).nPDCh(0) = i

        Next


    End Sub

    Public Sub Dispose()
        Disconnection()
        cSG = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region




    Public Function Connection(ByVal config As CCommLib.ucConfigRS485.sRS485Config) As Boolean
        'If cSG.Connection(config) = False Then Return False
        'For i As Integer = 0 To m_numOfDev - 1
        '    If cSG.cBoardInfo(i, 0, m_BoardInfo(i), 0) = False Then Return False
        '    'If cSG.PowerReadCal(i, 0) = False Then Return False
        '    'If cSG.SenseReadCal(i, 0) = False Then Return False
        'Next


        'StartThread()
        'Return True
        If cSG.Connection(config.sSerialInfo) = False Then Return False
        For i As Integer = 0 To m_numOfDev - 1
            If cSG.cBoardInfo(i + seedAddr, 0, m_BoardInfo(i), 0) = False Then Return False
            If cSG.PowerReadCal(i + seedAddr, 0) = False Then Return False
            If cSG.SenseReadCal(i + seedAddr, 0) = False Then Return False

            Dim nDevAddr, nDevID, nDevCh As Integer

            For nCh As Integer = 0 To m_nMaxCh - 1
                ConvertChToDevIDAndDevCh(nCh, nDevAddr, nDevID, nDevCh)
                If cSG.PD_AverLimitSet(nDevAddr, 0, nDevCh * 3, 255) = False Then 'nDevCh * 3  m_SGChMap(nDevID).nPDCh(0)
                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Function_Error, "Function : PD_AverLimitSet()")
                End If
            Next
        Next


        StartThread()
        Return True
    End Function

    Public Sub Disconnection()
        StopThread()
        Application.DoEvents()
        Thread.Sleep(500)
        If cSG.IsConnected = True Then
            cSG.DisConnection()
        End If
    End Sub

    Public Function Request(ByVal devID As Integer, ByVal devCh As Integer, ByVal state As eSequenceState) As Boolean


        Dim myCh As Integer
        ConvertDevIDAndDevChToCh(devID, devCh, myCh)
        If myCh < 0 Or myCh > m_nNumOfCh - 1 Then Return False
        m_SeqRoutineStatus(myCh) = state

        Return True
    End Function

   Public Function Request(ByVal nChOfSgGroup As Integer, ByVal state As eSequenceState, ByVal setting As sSettingParam) As Boolean
        Dim myCh As Integer = nChOfSgGroup
        If myCh < 0 Or myCh > m_nNumOfCh - 1 Then Return False
        m_SourceSettings(myCh) = setting
        m_SeqRoutineStatus(myCh) = state
        Return True
    End Function

    Public Function Request(ByVal devID As Integer, ByVal devCh As Integer, ByVal state As eSequenceState, ByVal setting As sSettingParam) As Boolean
        Dim myCh As Integer
        ConvertDevIDAndDevChToCh(devID, devCh, myCh)
        If myCh < 0 Or myCh > m_nNumOfCh - 1 Then Return False

        m_SeqRoutineStatus(myCh) = state
        m_SourceSettings(myCh) = setting

        Return True
    End Function


    Dim trd As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trd = New Thread(AddressOf trdRoutine)
        trd.Priority = ThreadPriority.Normal
        trd.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub



    Private Sub trdRoutine()

        'Dim ctrlInfos As sSettingInfo
        Dim nCntCh As Integer = 0
        Dim nCntidleCh As Integer

        Dim devIDELCnt(m_numOfDev - 1) As Integer
        Dim devIDELChkBit(m_numOfDev - 1)() As Integer

        For i As Integer = 0 To m_numOfDev - 1
            devIDELChkBit(i) = New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        Next


        Dim nSleepTime As Integer = 100
        Dim bReConnection As Boolean = False

        Dim nDevAddr As Integer 'Address
        Dim nDevCh As Integer
        Dim nDevID As Integer 'Array Index of Device
      
        Dim ErrorData() As Byte = Nothing
        Dim OutDLength As Integer = 0
        Dim RcvDLength As Integer = 0
        Do
            Application.DoEvents()
            Thread.Sleep(nSleepTime)

            If fStopTrd = True Then
                Exit Sub
            End If

            If m_bIsPaused = False Then

                ConvertChToDevIDAndDevCh(nCntCh, nDevAddr, nDevID, nDevCh)
                Select Case m_SeqRoutineStatus(nCntCh)

                    Case eSequenceState.eidle
                        nCntidleCh += 1
                        devIDELChkBit(nDevAddr)(nDevCh) = 0

                    Case eSequenceState.eReset

                        '출력
                        For i As Integer = 0 To m_SGChMap(nDevCh).nMainPower.Length - 1
                            If cSG.MainPower_Off(nDevAddr, nDevCh, m_SGChMap(nDevCh).nMainPower(i)) = False Then

                            End If
                        Next
                        If devIDELCnt(nDevAddr) = 1 Then

                            If cSG.MainPower_Off(nDevAddr, nDevCh) = False Then

                            End If

                            If cSG.SIGPower_Off(nDevAddr, nDevCh) = False Then

                            End If
                            If cSG.SubPower_Off(nDevAddr, nDevCh) = False Then

                            End If

                        End If

                       
                        m_SeqRoutineStatus(nCntCh) = eSequenceState.eidle
                    Case eSequenceState.eBoardReset

                        '보드 리셋
                        If cSG.cReset(seedAddr + nDevAddr, 0, 0) = True Then
                            cSG.Set_GPO_Out(seedAddr + nDevAddr, 0, 0, 0) '이재하 추가
                            m_MeasuredData(nCntCh).dELVDD_I = 0
                            m_MeasuredData(nCntCh).dELVSS_I = 0

                            m_MeasuredData(nCntCh).dPD_I = 0
                            nSleepTime = 100

                            '보드 리셋 이기 때문에 하나라도 리셋되면 보드에 연결된 채널을 모두 IDLE 상태로 변경
                            For i As Integer = 0 To numOfChPerDev - 1
                                Dim ch As Integer
                                ConvertDevIDAndDevChToCh(nDevCh, i, ch)
                                m_SeqRoutineStatus(nCntCh) = eSequenceState.eidle
                            Next

                        Else
                            nSleepTime = 1000
                            '예외처리
                        End If

                    Case eSequenceState.eMeasuring

                        'Dim dVolt_Bias As Double
                        'Dim dVolt_Amplitude As Double
                        'Dim dCurr_Bias As Double
                        'Dim dCurr_Amplitude As Double
                        'Dim dPDCurr As Double

                        Dim dValue As sMeasuredData

                        If cSG.MainPower_CurrMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(0), dValue.dELVDD_I) = False Then
                        End If

                        If cSG.MainPower_CurrMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(1), dValue.dELVSS_I) = False Then
                        End If

                        If cSG.MainPower_TempMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(0), dValue.dELVDD_Temp) = False Then
                        End If

                        If cSG.MainPower_TempMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(1), dValue.dELVSS_Temp) = False Then
                        End If

                        If cSG.PD_Meas(nDevAddr, 0, m_SGChMap(nDevAddr).nPDCh(0), dValue.dPD_I) = False Then
                        End If

                        dValue.dELVDD_V = m_SourceSettings(nCntCh).MainPower(0).dBias
                        dValue.dELVSS_V = m_SourceSettings(nCntCh).MainPower(1).dBias

                        m_MeasuredData(nCntCh) = dValue
                        myParent.g_MeasuredDatas(nCntCh + seedCh).sPanelLTParams.sMeasuredValues = dValue

                        'If cM6000.Measurement(nCntCh, dVolt_Amplitude, dVolt_Bias, dCurr_Amplitude, dCurr_Bias, dPDCurr) = True Then
                        '    nSleepTime = 100
                        '    g_MeasuredData(nCntCh).dVoltage_Bias = dVolt_Bias
                        '    g_MeasuredData(nCntCh).dVoltage_Amplitude = dVolt_Amplitude
                        '    g_MeasuredData(nCntCh).dCurrent_Amplitude = dCurr_Amplitude
                        '    g_MeasuredData(nCntCh).dCurrent_Bias = dCurr_Bias
                        '    g_MeasuredData(nCntCh).dPDCurrent = dPDCurr
                        '    bReConnection = False
                        'Else
                        '    nSleepTime = 1000
                        '    bReConnection = True

                        '    '통신 Faile 이 연속으로 발생하면 통신 이상으로 판단 하고 자동 중지ㄴ
                        'End If



                    Case eSequenceState.eSetSource

                        devIDELChkBit(nDevAddr)(nDevCh) = 1


                     

                        'Signal & Sub Power 설정
                        If devIDELCnt(nDevAddr) = 0 Then

                            For i As Integer = 0 To m_SourceSettings(nCntCh).Signal.Length - 1 ' m_SGChMap(nDevCh).nSignal.Length - 1
                                If cSG.SIGPower_BiasSet(nDevAddr, 0, m_SGChMap(nDevCh).nSignal(m_SourceSettings(nCntCh).Signal(i).nIdx), m_SourceSettings(nCntCh).Signal(i)) = False Then

                                End If
                            Next

                            For i As Integer = 0 To m_SourceSettings(nCntCh).SubPower.Length - 1 ' m_SGChMap(nDevCh).nSubPower.Length - 1
                                If cSG.SubPower_BiasSet(nDevAddr, 0, m_SGChMap(nDevCh).nSubPower(m_SourceSettings(nCntCh).SubPower(i).nIdx), m_SourceSettings(nCntCh).SubPower(i)) = False Then

                                End If
                            Next

                            If cSG.SIGPower_On(nDevAddr, 0, m_SGChMap(nDevCh).nSignal) = False Then

                            End If

                            If cSG.SubPower_On(nDevAddr, 0, m_SGChMap(nDevCh).nSubPower) = False Then

                            End If
                        End If


                        '출력
                        For i As Integer = 0 To m_SGChMap(nDevCh).nMainPower.Length - 1
                            If cSG.MainPower_BiasSet(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(i), m_SourceSettings(nCntCh).MainPower(i)) = False Then

                            End If

                            If cSG.MainPower_CurrLimitSet(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(i), m_SourceSettings(nCntCh).MainPowerLimit(i)) = False Then

                            End If

                            If cSG.MainPower_TempLimitSet(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(i), m_SourceSettings(nCntCh).MainPowerLimit(i)) = False Then

                            End If

                        Next

                        If cSG.MainPower_On(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower) = False Then

                        End If


                        Dim dValue As sMeasuredData

                        If cSG.MainPower_CurrMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(0), dValue.dELVDD_I) = False Then


                        End If

                        If cSG.MainPower_CurrMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(1), dValue.dELVSS_I) = False Then

                        End If

                        If cSG.MainPower_TempMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(0), dValue.dELVDD_Temp) = False Then

                        End If

                        If cSG.MainPower_TempMeas(nDevAddr, 0, m_SGChMap(nDevCh).nMainPower(1), dValue.dELVSS_Temp) = False Then

                        End If

                        If cSG.PD_Meas(nDevAddr, 0, m_SGChMap(nDevAddr).nPDCh(0), dValue.dPD_I) = False Then

                        End If

                        m_MeasuredData(nCntCh) = dValue



                        'If cM6000.BiasSettings(nCntCh, g_SourceSettings(nCntCh)) = True Then
                        '    nSleepTime = 100
                        'Else
                        '    nSleepTime = 1000
                        '    '예외처리 필요
                        'End If


                        'Application.DoEvents()
                        'Thread.Sleep(1500)

                        'Dim dVolt_Bias As Double
                        'Dim dVolt_Amplitude As Double
                        'Dim dCurr_Bias As Double
                        'Dim dCurr_Amplitude As Double
                        'Dim dPDCurr As Double

                        ''If cM6000.Measurement(nCntCh, dVolt_Amplitude, dVolt_Bias, dCurr_Amplitude, dCurr_Bias, dPDCurr) = True Then
                        ''    nSleepTime = 100
                        ''Else
                        ''    nSleepTime = 1000
                        ''End If

                        'If cM6000.Measurement(nCntCh, dVolt_Amplitude, dVolt_Bias, dCurr_Amplitude, dCurr_Bias, dPDCurr) = True Then
                        '    nSleepTime = 100
                        '    g_MeasuredData(nCntCh).dVoltage_Bias = dVolt_Bias
                        '    g_MeasuredData(nCntCh).dVoltage_Amplitude = dVolt_Amplitude
                        '    g_MeasuredData(nCntCh).dCurrent_Amplitude = dCurr_Amplitude
                        '    g_MeasuredData(nCntCh).dCurrent_Bias = dCurr_Bias
                        '    g_MeasuredData(nCntCh).dPDCurrent = dPDCurr
                        'Else
                        '    nSleepTime = 1000

                        '    '예외처리
                        '    '통신 Faile 이 연속으로 발생하면 통신 이상으로 판단 하고 자동 중지ㄴ
                        'End If




                        m_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring

                End Select

                'Limit 조건 추가 2013-04-14 ------------------------------------------------------------
                '실험 종료 조건 비교 Limitted 조건 초과 시 Over 메세지와 함께 해당 채널 측정 종료

                'If fMain Is Nothing = False Then

                '    If g_SeqRoutineStatus(nCntCh) = eSequenceState.eMeasuring Then

                '        If fMain.g_SystemOptions.bEnableAlarm = True Then

                '            If fMain.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits Is Nothing = False Then
                '                Dim ucLimmited() As ucLimitSetting.sLimitSetting = fMain.SequenceList(nCntCh + m_nSeedIndex).SequenceInfo.sCommon.sLimits

                '                For i As Integer = 0 To ucLimmited.Length - 1
                '                    If ucLimmited(i).LimitValue.dMax <> 0 Or ucLimmited(i).LimitValue.dMin <> 0 Then
                '                        Select Case ucLimmited(i).eTypeOfValue
                '                            Case ucLimitSetting.eLimitValueType.eVoltage
                '                                If g_MeasuredData(nCntCh).dVoltage_Bias < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dVoltage_Bias > ucLimmited(i).LimitValue.dMax Then

                '                                    ' 실험(종료)
                '                                    fMain.cTimeScheduler.g_ChSchedulerStauts(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                '                                    'LEX
                '                                    ' fMain.frmControlTwoStpeCyle.target(nCntCh + m_nSeedIndex).SetIndicate_StopMessage = "Over LowVolt"
                '                                    Exit For
                '                                End If

                '                                If g_MeasuredData(nCntCh).dVoltage_Amplitude < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dVoltage_Amplitude > ucLimmited(i).LimitValue.dMax Then
                '                                    '실험 종료
                '                                    fMain.cTimeScheduler.g_ChSchedulerStauts(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                '                                    'LEX
                '                                    ' fMain.frmControlTwoStpeCyle.target(nCntCh + m_nSeedIndex).SetIndicate_StopMessage = "Over HighVolt"
                '                                    Exit For
                '                                End If

                '                            Case ucLimitSetting.eLimitValueType.eCurrent
                '                                If g_MeasuredData(nCntCh).dCurrent_Bias < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dCurrent_Bias > ucLimmited(i).LimitValue.dMax Then
                '                                    '실험 종료
                '                                    fMain.cTimeScheduler.g_ChSchedulerStauts(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                '                                    'LEX
                '                                    'fMain.frmControlTwoStpeCyle.target(nCntCh + m_nSeedIndex).SetIndicate_StopMessage = "Over LowCurr"
                '                                    Exit For
                '                                End If

                '                                If g_MeasuredData(nCntCh).dCurrent_Amplitude < ucLimmited(i).LimitValue.dMin Or g_MeasuredData(nCntCh).dCurrent_Amplitude > ucLimmited(i).LimitValue.dMax Then
                '                                    '실험 종료
                '                                    fMain.cTimeScheduler.g_ChSchedulerStauts(nCntCh + m_nSeedIndex) = CScheduler.eChSchedulerSTATE.eStop
                '                                    'LEX
                '                                    'fMain.frmControlTwoStpeCyle.target(nCntCh + m_nSeedIndex).SetIndicate_StopMessage = "Over HighCurr"
                '                                    Exit For
                '                                End If
                '                        End Select
                '                    End If

                '                Next


                '                If fMain.cTimeScheduler.g_ChSchedulerStauts(nCntCh) = CScheduler.eChSchedulerSTATE.eStop Then ' 측정 종료되면  컨트롤러 Enable  true 2013-04-18 승현
                '                    'LEX
                '                    'fMain.frmControlTwoStpeCyle.target(nCntCh).EnableSetting = True
                '                End If

                '            End If

                '        End If

                '    End If


                'End If


                '---------------------------------------------------------------------------

                nCntCh += 1
                If nCntCh >= m_nMaxCh Then

                    'IDEL 상태인 채널의 수가 전채 채널의 수와 같으면 모두 대기 상태
                    If nCntidleCh >= m_nMaxCh Then
                    End If

                    Thread.Sleep(nSleepTime)

                    nCntidleCh = 0
                    nCntCh = 0
                End If

                For i As Integer = 0 To m_numOfDev - 1
                    devIDELCnt(i) = 0
                    'Device의 채널이 IDEL인 상태를 카운트, 카운트 값이 Device의 채널수와 같으면 모두 IDEL 상태
                    For n As Integer = 0 To devIDELChkBit(i).Length - 1

                        devIDELCnt(i) = devIDELCnt(i) + devIDELChkBit(i)(n)
                    Next

                    If devIDELCnt(i) = 0 Then
                        If cSG.cPing(seedAddr + i, 0, 0) = False Then

                        End If
                    End If
                   
                Next
            End If
          
        Loop

    End Sub

    Private Sub ConvertChToDevIDAndDevCh(ByVal nCh As Integer, ByRef devAddress As Integer, ByRef devID As Integer, ByRef devCh As Integer)

        Dim dDevTemp As Double

        dDevTemp = nCh / numOfChPerDev

        devAddress = Fix(dDevTemp) + seedAddr   'Address

        devID = devAddress - seedAddr

        devCh = nCh - (numOfChPerDev * (devAddress - seedAddr))

    End Sub

    Private Sub ConvertDevIDAndDevChToCh(ByVal devID As Integer, ByVal devCh As Integer, ByRef nCh As Integer)
        nCh = devID * numOfChPerDev + devCh
    End Sub

    Public Shared Function ConvertStringSequenceStateToInteger(ByVal str As String) As eSequenceState
        Select Case str
            Case eSequenceState.eidle.ToString
                Return eSequenceState.eidle
            Case eSequenceState.eSetSource.ToString
                Return eSequenceState.eSetSource
            Case eSequenceState.eMeasuring.ToString
                Return eSequenceState.eMeasuring
            Case eSequenceState.eReset.ToString
                Return eSequenceState.eReset
            Case eSequenceState.eBoardReset.ToString
                Return eSequenceState.eBoardReset
            Case eSequenceState.eReadCal.ToString
                Return eSequenceState.eReadCal
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertSGRecipeToSeqRoutineSettings(ByVal panelSettings As ucDispSignalGenerator.sSGDatas, ByRef seqRoutineSetting As CSeqRoutineSG.sSettingParam) As Boolean
        Dim setting As ucDispSignalGenerator.sSGDatas = panelSettings

        Dim nCntMainPwr As Integer = Nothing
        Dim nCntSubPwr As Integer = Nothing
        Dim nCntSignal As Integer = Nothing

        Dim mainPwr() As cDevSG.sSettingParam = Nothing
        Dim subPwr() As cDevSG.sSettingParam = Nothing
        Dim signal() As cDevSG.sSettingParam = Nothing
        Dim mainPwrLimit() As cDevSG.sLimit = Nothing

        For i As Integer = 0 To setting.nLenSignal - 1
            If setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower2 Then
                ReDim Preserve mainPwr(nCntMainPwr)
                ReDim Preserve mainPwrLimit(nCntMainPwr)
                mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                mainPwr(nCntMainPwr).sSignalName = setting.sParamData(i).sSignalName
                If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                nCntMainPwr += 1
            ElseIf setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower1 Then
                ReDim Preserve mainPwr(nCntMainPwr)
                ReDim Preserve mainPwrLimit(nCntMainPwr)
                mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                mainPwr(nCntMainPwr).sSignalName = setting.sParamData(i).sSignalName
                If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                nCntMainPwr += 1
            ElseIf setting.sParamData(i).eSignal >= ucDispSignalGenerator.ePGSignal.SubPower1 And setting.sParamData(i).eSignal <= ucDispSignalGenerator.ePGSignal.SubPower12 Then
                ReDim Preserve subPwr(nCntSubPwr)

                subPwr(nCntSubPwr).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.SubPower1)
                subPwr(nCntSubPwr).sSignalName = setting.sParamData(i).sSignalName
                subPwr(nCntSubPwr).Mode = setting.sParamData(i).eSrcMode
                If subPwr(nCntSubPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    subPwr(nCntSubPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                subPwr(nCntSubPwr).dBias = setting.sParamData(i).dBias
                subPwr(nCntSubPwr).dAmplitude = setting.sParamData(i).dAmplitude
                subPwr(nCntSubPwr).PulseParam = setting.sParamData(i).sPulse
                nCntSubPwr += 1
            Else
                ReDim Preserve signal(nCntSignal)
                signal(nCntSignal).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.Signal1)
                signal(nCntSignal).sSignalName = setting.sParamData(i).sSignalName
                signal(nCntSignal).Mode = setting.sParamData(i).eSrcMode
                If signal(nCntSignal).Mode = CDevSG.eDacMode.eDCMode Then
                    signal(nCntSignal).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                signal(nCntSignal).dBias = setting.sParamData(i).dBias
                signal(nCntSignal).dAmplitude = setting.sParamData(i).dAmplitude
                signal(nCntSignal).PulseParam = setting.sParamData(i).sPulse
                nCntSignal += 1
            End If

        Next

        seqRoutineSetting.MainPower = mainPwr.Clone
        seqRoutineSetting.SubPower = subPwr.Clone
        seqRoutineSetting.Signal = signal.Clone
        seqRoutineSetting.MainPowerLimit = mainPwrLimit.Clone
        Return True
    End Function
End Class
