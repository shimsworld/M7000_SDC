Imports System.Threading

Public Class CSeqRoutineMcPG
    Inherits CDevPGCommonNode



    '* Address 설정 Argument는 0부터, 내부에서 보낼때는 +1을 해서 1부터
    Public Const numOfChPerDev_PG As Integer = 8  '제어기 한개가 1개 이상의 샘플을 구동 할 수 있을 경우를 위해, 여기서는 1개의 제어기가 8개의 샘플에 출력이 나가는형태로, 개별제어는 안됨
    Public Const numOfChPerDev_PGPwr As Integer = 1  '제어기 한개가 1개 이상의 샘플을 구동 할 수 있을 경우를 위해
    Public Const numOfChPerDev_PGCtrl As Integer = 4  '제어기 한개가 1개 이상의 샘플을 구동 할 수 있을 경우를 위해
    Public Const numOfChPerDev_PDUnit As Integer = 32

    Dim seedCh As Integer '현재 클래스에서 담당하는 채널의 시작 인덱스  'm_nMaxCh + SeedCh = UI 채널 번호

    '  Dim m_nNumOfCh As Integer '구동 가능한 채널수(PG, PG Power,PG Ctrl BD, PD Unit의 조합으로 구동 가능한 채널의 수, 즉 가장 작은 장비의 수량)
    Dim m_nNumOfCh_PG As Integer     '개별 제어할 모듈의 수
    Dim m_nNumOfCh_PGCtrl As Integer '개별 제어할 모듈의 수
    Dim m_nNumOfCh_PGPwr As Integer  '개별 제어할 모듈의 수
    Dim m_nNumOfCh_PDUnit As Integer  '개별 제어할 모듈의 수
    '위의 4개의 변수에 저장될 값은 같아야만 한다. 다르면 시스템 설정이 절못된 것임.
    ' m_nNumOfCh = m_nNumOfCh_PDUnit =  m_nNumOfCh_PGPwr =  m_nNumOfCh_PGCtrl =  m_nNumOfCh_PG
    Dim m_nNumOfCh As Integer 'Panel을 개별 제어할S 수 , 만약 G 하나에 채널이 8개라면, 제어기수 * 채널수로 입력된 값
    Dim m_nMaxCh As Integer  'UI에서의 채널 개념과 대응되는 채널의 수, 동시에 구동 할 수 있는 수 중에서 현재 클래스에서 담당하는 수, m_nNumOfCh 과 같은 값이다....

    Dim m_devConfigInfo As sInitParam

    Dim cmdQueue As Queue = New Queue

    Dim m_SourceSettings() As sSettingParam







#Region "Enums"



    Public Structure sInitParam
        Dim nSeedCh As Integer
        Dim sPG As sSerial
        Dim sPDUnit As sSerial
        Dim sPGCtrl As sParallel
        Dim sPGPower As sParallel
    End Structure

    Public Structure sParallel
        Dim bEnable As Boolean
        Dim nNumOfDev As Integer
        Dim nSeedAddress As Integer
    End Structure

    Public Structure sSerial
        Dim bEnable As Boolean
        Dim nNumOfDev As Integer
    End Structure
    'Public Structure sSGMap
    '    Dim nMainPower() As Integer
    '    Dim nSubPower() As Integer
    '    Dim nSignal() As Integer
    '    Dim nPDCh() As Integer
    'End Structure

#End Region


#Region "Define"


#Region "Struecture"

    Public Structure sSettingParam
        Dim devID As Integer
        Dim chOfDev As Integer
        Dim CMDState As eSequenceState
        Dim sPGSettings As frmPatternGeneratorSetting.sPGInfos
        'Dim PGCtrl As
        'Dim Signal() As cDevSG.sSettingParam
        'Dim MainPowerLimit() As cDevSG.sLimit
    End Structure

    Public Structure sMeasuredData
        Dim nPowerChNo() As Integer    '5개의 채널중 사용중인 채널의 번호를 저장하는 배열
        Dim dVoltage() As Double
        Dim dCurrent() As Double
        Dim dPD_I As Double
        Dim dLuminance As Double
    End Structure


    Public Structure sCommInfo
        Dim bEnablePG As Boolean
        Dim bEnablePGPwr As Boolean
        Dim bEnablePGCtrlBD As Boolean
        Dim bEnablePDUnit As Boolean
        Dim sPDUnit() As CCommLib.CComSerial.sSerialPortInfo
        Dim sPG() As CCommLib.CComSocket.sSockInfos
        Dim sPGPwr As CCommLib.CComSerial.sSerialPortInfo
        Dim sPGCtrl As CCommLib.CComSerial.sSerialPortInfo
    End Structure

#End Region

#End Region


#Region "Properties"

    'Public Overrides ReadOnly Property MeasuredData(ch As Integer) As Object
    '    Get
    '        Return m_MeasuredData(ch)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property MeasuredData(ByVal ch As Integer) As sMeasuredData
    '    Get
    '        Return m_MeasuredData(ch)
    '    End Get
    'End Property


    Public Property UseLogOutputPGCtrlBoard As Boolean
        Get
            Return cMcPGCtrl.UseLogOutput
        End Get
        Set(ByVal value As Boolean)
            cMcPGCtrl.UseLogOutput = value
        End Set
    End Property

    Public Property UseLogOutputPGPower As Boolean
        Get
            Return cMcPGPwr.UseLogOutput
        End Get
        Set(ByVal value As Boolean)
            cMcPGPwr.UseLogOutput = value
        End Set
    End Property

  

    Public ReadOnly Property IsPGConnected(ByVal devNum As Integer) As Boolean
        Get
            Return cMcPG(devNum).IsConnected
        End Get
    End Property

    Public ReadOnly Property IsPDUnitConnected(ByVal devNum As Integer) As Boolean
        Get
            If m_devConfigInfo.sPDUnit.bEnable = True Then
                Return cMcPDMeasUnit(devNum).IsConnected
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property IsPGPwrConnected() As Boolean
        Get
            Return cMcPGPwr.IsConnected
        End Get
    End Property

    Public ReadOnly Property IsPGCtrlConnected() As Boolean
        Get
            Return False '
        End Get
    End Property


#End Region

#Region "Creator & Disposer"

    Public Sub New(ByVal main As frmMain, ByVal initParam As CSeqRoutineMcPG.sInitParam)
        MyBase.new()
        myParent = main
        m_devConfigInfo = initParam
        Dim numOfCh() As Integer = Nothing
        Dim devCnt As Integer = 0

        seedCh = m_devConfigInfo.nSeedCh

        If initParam.sPG.bEnable = True Then
            ReDim Preserve numOfCh(devCnt)
            m_nNumOfCh_PG = m_devConfigInfo.sPG.nNumOfDev * numOfChPerDev_PG
            numOfCh(devCnt) = m_nNumOfCh_PG
            devCnt += 1

            ReDim cMcPG(m_devConfigInfo.sPG.nNumOfDev - 1)
            For i As Integer = 0 To m_devConfigInfo.sPG.nNumOfDev - 1
                cMcPG(i) = New cDevMcPG()
            Next
        End If

        If initParam.sPGPower.bEnable = True Then
            ReDim Preserve numOfCh(devCnt)
            m_nNumOfCh_PGPwr = m_devConfigInfo.sPGPower.nNumOfDev * numOfChPerDev_PGPwr
            numOfCh(devCnt) = m_nNumOfCh_PGPwr
            devCnt += 1

            cMcPGPwr = New cDevMcPGPower
        End If

        If initParam.sPGCtrl.bEnable = True Then
            ReDim Preserve numOfCh(devCnt)
            m_nNumOfCh_PGCtrl = m_devConfigInfo.sPGCtrl.nNumOfDev * numOfChPerDev_PGCtrl
            numOfCh(devCnt) = m_nNumOfCh_PGCtrl
            devCnt += 1

            cMcPGCtrl = New cDevMcPGControl
        End If

        If initParam.sPDUnit.bEnable = True Then
            ReDim Preserve numOfCh(devCnt)
            m_nNumOfCh_PDUnit = m_devConfigInfo.sPDUnit.nNumOfDev * numOfChPerDev_PDUnit
            numOfCh(devCnt) = m_nNumOfCh_PDUnit
            devCnt += 1

            ReDim cMcPDMeasUnit(m_devConfigInfo.sPDUnit.nNumOfDev - 1)
            For i As Integer = 0 To m_devConfigInfo.sPDUnit.nNumOfDev - 1
                cMcPDMeasUnit(i) = New CDevPDUnit()
            Next

        End If

        m_nNumOfCh = numOfCh.Min
        m_nMaxCh = m_nNumOfCh


        ReDim m_SeqRoutineStatus(m_nNumOfCh - 1)
        ReDim m_SourceSettings(m_nNumOfCh - 1)
        ReDim m_MeasuredData(m_nNumOfCh - 1)

        For i As Integer = 0 To m_SeqRoutineStatus.Length - 1
            m_SeqRoutineStatus(i) = eSequenceState.eidle
        Next


        MyBase.m_bIsConnected = False

    End Sub

    Public Overrides Sub Dispose()
        StopThread()
        Disconnection()
        cMcPG = Nothing
        cMcPDMeasUnit = Nothing
        cMcPGPwr = Nothing
        cMcPGCtrl = Nothing
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


#Region "Abstract Functions"

    Public Overrides Function Connection(ByVal config As sCommInfo) As Boolean

        If m_devConfigInfo.sPG.bEnable = True Then
            For i As Integer = 0 To m_devConfigInfo.sPG.nNumOfDev - 1
                If cMcPG(i).Connection(config.sPG(i)) = False Then Return False

                'LEX 통신 연결 확인 필요
            Next
        End If


        If m_devConfigInfo.sPDUnit.bEnable = True Then
            For i As Integer = 0 To m_devConfigInfo.sPDUnit.nNumOfDev - 1
                If cMcPDMeasUnit(i).Connection(config.sPDUnit(i)) = False Then Return False

                'LEX 통신 연결 확인 필요
            Next
        End If


        If m_devConfigInfo.sPGPower.bEnable = True Then
            If cMcPGPwr.Connection(config.sPGPwr) = False Then Return False
        End If


        'LEX 통신 연결 확인 필요
        If m_devConfigInfo.sPGCtrl.bEnable = True Then
            If cMcPGCtrl.Connection(config.sPGCtrl) = False Then Return False
        End If

        'LEX 통신 연결 확인 필요

        m_bIsConnected = True

        StartThread()
        Return True
    End Function

    Public Overrides Sub Disconnection()
        StopThread()
        Application.DoEvents()
        Thread.Sleep(500)

        If m_devConfigInfo.sPG.bEnable = True Then
            For i As Integer = 0 To cMcPG.Length - 1
                If cMcPG(i).IsConnected = True Then
                    cMcPG(i).DisConnection()
                End If
            Next
        End If

        If m_devConfigInfo.sPDUnit.bEnable = True Then
            For i As Integer = 0 To cMcPDMeasUnit.Length - 1
                cMcPDMeasUnit(i).Disconnection()
            Next
        End If

        If m_devConfigInfo.sPGPower.bEnable = True Then
            cMcPGPwr.DisConnection()
        End If

        If m_devConfigInfo.sPGCtrl.bEnable = True Then
            cMcPGCtrl.DisConnection()
        End If

        m_bIsConnected = False

    End Sub

#End Region



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ch"></param>UI 의 채널 번호
    ''' <param name="state"></param>PG 제어를 위한 명령 선택
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Request(ByVal ch As Integer, ByVal state As eSequenceState) As Boolean
        Dim myCh As Integer = ch
        '    ConvertDevIDAndDevChToCh(devID, devCh, myCh)
        If myCh < 0 Or myCh > m_nNumOfCh - 1 Then Return False
        m_SeqRoutineStatus(myCh) = state

        Return True
    End Function

    Public Overrides Function Request(ByVal ch As Integer, ByVal state As eSequenceState, ByVal setting As sSettingParam) As Boolean
        Dim myCh As Integer = ch
        '    ConvertDevIDAndDevChToCh(devID, devCh, myCh)
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

        Dim nSleepTime As Integer = 100
        Dim bReConnection As Boolean = False

        Dim nDevAddr_PG As Integer 'Address(485) or Device Index(232, Socket)
        Dim nDevCh_PG As Integer

        Dim nDevAddr_PGPwr As Integer 'Address(485) or Device Index(232, Socket)
        Dim nDevCh_PGPwr As Integer

        Dim nDevAddr_PGCtrl As Integer 'Address(485) or Device Index(232, Socket)
        Dim nDevCh_PGCtrl As Integer

        Dim nDevAddr_PDUnit As Integer 'Address(485) or Device Index(232, Socket)
        Dim nDevCh_PDUnit As Integer


        'Dim devIDELCnt_PG(m_devConfigInfo.sPG.nNumOfDev - 1) As Integer  '디바이스에서 공통으로 묶여 있는 채널의 사용 수량을 체크, 0이면 사용하고 있지 않음, 1 ~ n은 수량 만큼 사용중
        'Dim devIDELChkBit_PG(m_devConfigInfo.sPG.nNumOfDev - 1)() As Integer ' 디바이스에서 공통으로 묶여 있는 각 채널의 사용 비트

        Dim devIDELCnt_PGCtrl(m_devConfigInfo.sPGCtrl.nNumOfDev - 1) As Integer
        Dim devIDELChkBit_PGCtrl(m_devConfigInfo.sPGCtrl.nNumOfDev - 1)() As Integer

        'For i As Integer = 0 To m_devConfigInfo.sPG.nNumOfDev - 1
        '    devIDELChkBit_PG(i) = New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        'Next

        For i As Integer = 0 To m_devConfigInfo.sPGCtrl.nNumOfDev - 1
            devIDELChkBit_PGCtrl(i) = New Integer() {0, 0, 0, 0}
        Next



        Do
            Application.DoEvents()
            Thread.Sleep(nSleepTime)

            If fStopTrd = True Then
                Exit Sub
            End If

            If m_bIsPaused = False Then

                ConvertChToPGDevIDAndDevCh(nCntCh, nDevAddr_PG, nDevCh_PG)
                ConvertChToPGPwrDevIDAndDevCh(nCntCh, nDevAddr_PGPwr, nDevCh_PGPwr)
                ConvertChToPGCtrlDevIDAndDevCh(nCntCh, nDevAddr_PGCtrl, nDevCh_PGCtrl)
                ConvertChToPDUnitDevIDAndDevCh(nCntCh, nDevAddr_PDUnit, nDevCh_PDUnit)

                Select Case m_SeqRoutineStatus(nCntCh)

                    Case eSequenceState.eidle
                        nCntidleCh += 1


                    Case eSequenceState.eReset

                        Dim ret As Integer
                        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eOFF

                        ' devIDELChkBit_PG(nDevAddr_PG)(nDevCh_PG) = 0
                        devIDELChkBit_PGCtrl(nDevAddr_PGCtrl)(nDevCh_PGCtrl) = 0


                        'PG 출력 설정, 다른 채널에서 사용 중일때 끄면 안됨, 1이면 1개의 채널에서 사용 중임.
                        'If devIDELCnt_PG(nDevAddr_PG) = 1 Then

                        'End If

                        If devIDELCnt_PGCtrl(nDevAddr_PGCtrl) = 1 Then
                            'PG Control BD(pallete) 출력 설정, 다른 채널에서 사용 중일때 끄면 안됨, 1이면 1개의 채널에서 사용 중임.
                            If devIDELCnt_PGCtrl(nDevAddr_PGCtrl) = 1 Then
                                'PG Control BD(Pallet) 출력 끄기
                                If cMcPGCtrl.Set_DisplayOnOFF(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, 0, ret, SetOnOFF) = False Then

                                End If
                            End If
                        End If

                        'Power 출력 설정
                        If cMcPGPwr.Power_Off(nDevAddr_PGPwr + m_devConfigInfo.sPGPower.nSeedAddress, 0) = False Then
                            'Lex 예외처리 필요
                        End If

                        m_SeqRoutineStatus(nCntCh) = eSequenceState.eidle

                    Case eSequenceState.eMeasuring

                        For Cnt As Integer = 0 To m_MeasuredData(nCntCh).sMcPG.nPowerChNo.Length - 1

                            If cMcPGPwr.Power_Meas(nDevAddr_PGPwr + m_devConfigInfo.sPGPower.nSeedAddress, _
                                                 0, _
                                                 m_MeasuredData(nCntCh).sMcPG.nPowerChNo(Cnt), _
                                                 m_MeasuredData(nCntCh).sMcPG.dVoltage(Cnt), _
                                                 m_MeasuredData(nCntCh).sMcPG.dCurrent(Cnt)) = False Then

                            Else

                            End If

                        Next

                        If m_devConfigInfo.sPDUnit.bEnable = True Then
                            If cMcPDMeasUnit(nDevAddr_PDUnit).MeasurementPDCurrent(nDevCh_PDUnit, m_MeasuredData(nCntCh).sMcPG.dPD_I) = False Then
                            End If
                        Else
                            m_MeasuredData(nCntCh).sMcPG.dPD_I = 0
                        End If


                        ' myParent.g_MeasuredDatas(nCntCh + seedCh).sModuleLTParams.sMeasuredValues.sMcPG = m_MeasuredData(nCntCh).sMcPG


                    Case eSequenceState.eON


                        Dim ret As Integer

                        'devIDELChkBit_PG(nDevAddr_PG)(nDevCh_PG) = 1
                        devIDELChkBit_PGCtrl(nDevAddr_PGCtrl)(nDevCh_PGCtrl) = 1


                        'PG 출력 설정, 다른 채널에서 이미 설정 되었으면 설정하면 안됨
                        'If devIDELCnt_PG(nDevAddr_PG) = 0 Then

                        'End If


                        'Power 출력 설정
                        If cMcPGPwr.Power_Set(nDevAddr_PGPwr + m_devConfigInfo.sPGPower.nSeedAddress, 0, m_SourceSettings(nCntCh).sPGSettings.sPwr) = False Then  ''
                            'Lex 예외처리 필요
                        End If

                        If cMcPGPwr.Power_On(nDevAddr_PGPwr + m_devConfigInfo.sPGPower.nSeedAddress, 0, m_SourceSettings(nCntCh).sPGSettings.sPwr) = False Then

                        End If


                        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eOFF
                        If cMcPGCtrl.Set_DisplayOnOFF(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, nDevCh_PGCtrl + 1, ret, SetOnOFF) = True Then

                        End If


                        If cMcPGCtrl.Set_Initialize(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, nDevCh_PGCtrl + 1, ret) = False Then

                        End If

                        SetOnOFF = cDevMcPGControl.eOnOff.eON
                        If cMcPGCtrl.Set_DisplayOnOFF(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, nDevCh_PGCtrl + 1, ret, SetOnOFF) = True Then
                        End If



                        'PG Control BD(pallete) 출력 설정, 다른 채널에서 이미 설정 되었으면 설정하면 안됨
                        If devIDELCnt_PGCtrl(nDevAddr_PGCtrl) = 0 Then

                            Thread.Sleep(500)
                            If cMcPGCtrl.Set_Pattern(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, 0, ret, m_SourceSettings(nCntCh).sPGSettings.sReg.ePattern,
                                     m_SourceSettings(nCntCh).sPGSettings.sGrayScale.nRed,
                                     m_SourceSettings(nCntCh).sPGSettings.sGrayScale.nGreen,
                                     m_SourceSettings(nCntCh).sPGSettings.sGrayScale.nBlue) = False Then

                            End If
                            Thread.Sleep(500)
                            '     Dim SetOnOFF As cDevPGControl.eOnOff = cDevPGControl.eOnOff.eON
                            'SetOnOFF = cDevPGControl.eOnOff.eON
                            'If cPGCtrl.Set_DisplayOnOFF(nDevAddr_PGCtrl + m_devConfigInfo.sPGCtrl.nSeedAddress, 0, ret, SetOnOFF) = True Then

                            'End If



                        End If




                        '?? Power_Set 함수에는 값을 설정, Power_ON에는 출력 ON 인데, 정보를 두함수 모두 요구함??




                        '데이터 저장 변수 초기화
                        m_MeasuredData(nCntCh).sMcPG.nPowerChNo = m_SourceSettings(nCntCh).sPGSettings.sPwr.nPwrNO.Clone
                        ReDim m_MeasuredData(nCntCh).sMcPG.dVoltage(m_MeasuredData(nCntCh).sMcPG.nPowerChNo.Length - 1)
                        ReDim m_MeasuredData(nCntCh).sMcPG.dCurrent(m_MeasuredData(nCntCh).sMcPG.nPowerChNo.Length - 1)

                        'For Cnt As Integer = 0 To m_MeasuredData(nCntCh).nPowerChNo.Length - 1

                        '    If cPGPwr.Power_Meas(nDevAddr_PGPwr + m_devConfigInfo.sPGPower.nSeedAddress, 0, m_MeasuredData(nCntCh).nPowerChNo(Cnt), m_MeasuredData(nCntCh).dVoltage(Cnt), m_MeasuredData(nCntCh).dCurrent(Cnt)) = False Then

                        '    End If

                        'Next
                        If m_devConfigInfo.sPDUnit.bEnable = True Then
                            If cMcPDMeasUnit(nDevAddr_PDUnit).MeasurementPDCurrent(nDevCh_PDUnit, m_MeasuredData(nCntCh).sMcPG.dPD_I) = False Then

                            End If
                        End If

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


                'For i As Integer = 0 To m_devConfigInfo.sPG.nNumOfDev - 1

                '    'Device의 채널이 IDEL인 상태를 카운트, 카운트 값이 Device의 채널수와 같으면 모두 IDEL 상태
                '    For n As Integer = 0 To devIDELChkBit_PG(i).Length - 1
                '        devIDELCnt_PG(i) = devIDELCnt_PG(i) + devIDELChkBit_PG(i)(n)
                '    Next

                '    If devIDELCnt_PG(i) = 0 Then '모든 채널이 사용중이지 않음, 통신이 없으므로, 상태체크 등을 할 수 있음.

                '    End If

                'Next

                For i As Integer = 0 To m_devConfigInfo.sPGCtrl.nNumOfDev - 1

                    'Device의 채널이 IDEL인 상태를 카운트, 카운트 값이 Device의 채널수와 같으면 모두 IDEL 상태
                    devIDELCnt_PGCtrl(i) = 0
                    For n As Integer = 0 To devIDELChkBit_PGCtrl(i).Length - 1
                        devIDELCnt_PGCtrl(i) = devIDELCnt_PGCtrl(i) + devIDELChkBit_PGCtrl(i)(n)
                    Next

                    If devIDELCnt_PGCtrl(i) = 0 Then '모든 채널이 사용중이지 않음, 통신이 없으므로, 상태체크 등을 할 수 있음.

                    End If

                Next

            End If

        Loop

    End Sub

    Private Sub ConvertChToPGPwrDevIDAndDevCh(ByVal nCh As Integer, ByRef devID As Integer, ByRef devCh As Integer)

        Dim dDevTemp As Double

        dDevTemp = nCh / numOfChPerDev_PGPwr

        devID = Fix(dDevTemp)

        devCh = nCh - (numOfChPerDev_PGPwr * devID)

    End Sub

    Private Sub ConvertPGPwrDevIDAndDevChToCh(ByVal devID As Integer, ByVal devCh As Integer, ByRef nCh As Integer)
        nCh = devID * numOfChPerDev_PGPwr + devCh
    End Sub

    Private Sub ConvertChToPGCtrlDevIDAndDevCh(ByVal nCh As Integer, ByRef devID As Integer, ByRef devCh As Integer)

        Dim dDevTemp As Double

        dDevTemp = nCh / numOfChPerDev_PGCtrl

        devID = Fix(dDevTemp)

        devCh = nCh - (numOfChPerDev_PGCtrl * devID)

    End Sub

    Private Sub ConvertPGCtrlDevIDAndDevChToCh(ByVal devID As Integer, ByVal devCh As Integer, ByRef nCh As Integer)
        nCh = devID * numOfChPerDev_PGCtrl + devCh
    End Sub

    Private Sub ConvertChToPGDevIDAndDevCh(ByVal nCh As Integer, ByRef devID As Integer, ByRef devCh As Integer)

        Dim dDevTemp As Double

        dDevTemp = nCh / numOfChPerDev_PG

        devID = Fix(dDevTemp)

        devCh = nCh - (numOfChPerDev_PG * devID)

    End Sub

    Private Sub ConvertPGDevIDAndDevChToCh(ByVal devID As Integer, ByVal devCh As Integer, ByRef nCh As Integer)
        nCh = devID * numOfChPerDev_PG + devCh
    End Sub

    Private Sub ConvertChToPDUnitDevIDAndDevCh(ByVal nCh As Integer, ByRef devID As Integer, ByRef devCh As Integer)

        Dim dDevTemp As Double

        dDevTemp = nCh / numOfChPerDev_PDUnit

        devID = Fix(dDevTemp)

        devCh = nCh - (numOfChPerDev_PDUnit * devID)

    End Sub

    Private Sub ConvertPDUnitDevIDAndDevChToCh(ByVal devID As Integer, ByVal devCh As Integer, ByRef nCh As Integer)
        nCh = devID * numOfChPerDev_PDUnit + devCh
    End Sub

End Class
