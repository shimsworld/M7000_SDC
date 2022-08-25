Imports System.Threading
Imports System.IO

Public Class CSheduler_PLC

    Dim fMain As frmMain
    '    Dim m_MagazineControl As eMagazineControl    '이송부,  배출부,  Scan 컨트롤 할 부분을 선택
    Dim m_MagazinePositionControl As eMagazinePositionControl   'Magazine 위치 Up, Down 조정 컨트롤
    Dim m_RequestedTest As Boolean   '외부 관리용 변수, Scheduler에서 현재 채널의 명령이 예약되었음을 나타냄(Set Sourcing, LifeTime Meas  등)
    Dim m_RequestScan As Boolean
    Dim m_ResetContact As Boolean
    Dim m_ProcessStart As Boolean
    Dim m_SupplyPosition() As CDevPLCCommonNode.ePositionSignal '현재 공급 위치 
    Dim m_ExhausPosition() As CDevPLCCommonNode.ePositionSignal '현재 배출 위치
    Dim m_SupplySlot() As CDevPLCCommonNode.eSlotSignal
    Dim m_ExhausSlot() As CDevPLCCommonNode.eSlotSignal
    Dim m_MagazineControl As sMagazineControl
    Dim m_bSupplyHome As Boolean = False
    Dim m_bExhausHome As Boolean = False
    Dim m_bSupplyUpDown As Boolean
    Dim m_bExhausUpDown As Boolean
    Dim m_HomeChk As Boolean = False
    Dim m_CurrentSlot As Integer = Nothing

    ' Dim m_ExhausControl As eMagazinePositionControl
    Dim m_bExhaus As Boolean
    Dim m_bStartChk As Boolean
    Public g_ChSchedulerPLCStatus As eChSchedulerPLCSTATE
    Public Shared sCaptions_State() As String = New String() {"IDLE",
                                                             "Home",
                                                             "Run",
                                                             "Process",
                                                             "Supply",
                                                             "Exhaust",
                                                             "Scan",
                                                             "Scanning",
                                                             "UpOrDown",
                                                             "ResetContact",
                                                             "PositionAndSlotCheck"}
    Public Structure sMagazineControl
        Dim nSupply As eMagazinePositionControl
        Dim nExhaus As eMagazinePositionControl
    End Structure

    Public Enum eMagazinePositionControl
        eOk = 3
        eUp
        eDown
    End Enum

    Public Enum eChSchedulerPLCSTATE
        eIDLE
        eHome
        eRun
        eProcess
        eSupply
        eExhaus
        eEQPRun
        ePositionAndSlotCheck
    End Enum

    Public Property HomeCheck As Boolean
        Get
            Return m_HomeChk
        End Get
        Set(ByVal value As Boolean)
            m_HomeChk = value
        End Set
    End Property

    Public Property RequestTest As Boolean
        Get
            Return m_RequestedTest
        End Get
        Set(ByVal value As Boolean)
            m_RequestedTest = value
        End Set
    End Property

    Public Property RequestScan As Boolean
        Get
            Return m_RequestScan
        End Get
        Set(ByVal value As Boolean)
            m_RequestScan = value
        End Set
    End Property

    Public Property ResetContact As Boolean
        Get
            Return m_ResetContact
        End Get
        Set(ByVal value As Boolean)
            m_ResetContact = value
        End Set
    End Property

    Public Property SupplyPosition As CDevPLCCommonNode.ePositionSignal()
        Get
            Return m_SupplyPosition
        End Get
        Set(ByVal value As CDevPLCCommonNode.ePositionSignal())
            m_SupplyPosition = value.Clone
        End Set
    End Property

    Public Property SupplySlot As CDevPLCCommonNode.eSlotSignal()
        Get
            Return m_SupplySlot
        End Get
        Set(ByVal value As CDevPLCCommonNode.eSlotSignal())
            m_SupplySlot = value.Clone
        End Set
    End Property

    Public Property ExhausPosition As CDevPLCCommonNode.ePositionSignal()
        Get
            Return m_ExhausPosition
        End Get
        Set(ByVal value As CDevPLCCommonNode.ePositionSignal())
            m_ExhausPosition = value.Clone
        End Set
    End Property

    Public Property ExhausSlot As CDevPLCCommonNode.eSlotSignal()
        Get
            Return m_ExhausSlot
        End Get
        Set(ByVal value As CDevPLCCommonNode.eSlotSignal())
            m_ExhausSlot = value.Clone
        End Set
    End Property
    Public Property StartChk As Boolean
        Get
            Return m_bStartChk
        End Get
        Set(value As Boolean)
            m_bStartChk = value
        End Set
    End Property
    Public Property ExhausStart As Boolean
        Get
            Return m_bExhaus
        End Get
        Set(ByVal value As Boolean)
            m_bExhaus = value
        End Set
    End Property
    Public ReadOnly Property CurrentSlot As Integer
        Get
            Return m_CurrentSlot
        End Get
    End Property


    '#Region "Creator & Disposer"

    Public Sub New(ByVal main As frmMain)
        fMain = main
        m_bExhaus = False
        m_RequestScan = False
        m_RequestedTest = False
        m_ResetContact = False
        m_ProcessStart = False
        g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eIDLE
    End Sub

    Public Sub Dispose()
        Me.Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        '    End Sub
        '  #End Region

        '    Private bStopPLCTrd As Boolean
        '    Private trdPLC As Thread

        '    Public Sub StartTrdPLC()
        '        trdPLC = New Thread(AddressOf PLCScheduleLoop)
        '        trdPLC.Priority = ThreadPriority.AboveNormal   'Highest
        '        trdPLC.TrySetApartmentState(ApartmentState.MTA)
        '        trdPLC.Start()

        '        bStopPLCTrd = False
        '    End Sub

        '    Public Sub StopTrdPLC()
        '        bStopPLCTrd = True
        '    End Sub


        '    Private Sub PLCScheduleLoop()

        '        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        '        Dim nCnt As Integer

        '        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_PLC_THREAD_START, "PLC Scheduler Start")

        '        Do
        '            Application.DoEvents()
        '            Thread.Sleep(100)

        '            reqInfo = Nothing

        '            If bStopPLCTrd = True Then
        '                Exit Do
        '            End If

        '            Select Case g_ChSchedulerPLCStatus

        '                Case eChSchedulerPLCSTATE.eIDLE
        '                    m_RequestedTest = False

        '                    If m_ProcessStart = True Then
        '                        nCnt = 0
        '                        For i As Integer = 0 To fMain.g_PalletInfos.bCheckPallet.Length - 1
        '                            If fMain.g_PalletInfos.bCheckPallet(i) = True Then
        '                                nCnt += 1
        '                            End If
        '                        Next

        '                        If m_SupplySlot(0) <> CDevPLCCommonNode.eSlotSignal.eNone And nCnt > 0 Then
        '                            g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eRun
        '                            m_ProcessStart = False

        '                        ElseIf nCnt = 0 Then
        '                            If m_HomeChk = False Then
        '                                g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eIDLE
        '                                fMain.EnableTsBtnTestStart(True)

        '                            End If
        '                        End If
        '                    End If

        '                Case eChSchedulerPLCSTATE.eHome

        '                    '여기서 홈으로 보내고 가야할까? 근데 홈은 모션만있는데..
        '                    'If CDevPLCCommonNode.eMagazinePositionSignal.ePosition10 = m_SupplyPosition Then
        '                    '    m_bSupplyHome = True
        '                    'Else
        '                    '    m_bSupplyHome = False
        '                    'End If

        '                    'If CDevPLCCommonNode.eMagazinePositionSignal.ePosition10 = m_ExhausPosition Then
        '                    '    m_bExhausHome = True
        '                    'Else
        '                    '    m_bExhausHome = False
        '                    'End If

        '                    '' ''공급, 배출이 모두 Home 위치면 IDEL 상태로
        '                    'If m_bSupplyHome = True And m_bExhausHome = True Then
        '                    g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eIDLE
        '                    'm_HomeChk = True
        '                    ' Else
        '                    'fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Meas_State_Text, CStateMsg.eStateMsg.ePLC_HOME, "")
        '                    'If fMain.PLCScan(g_ChSchedulerPLCStatus, m_bSupplyHome, m_bExhausHome, m_MagazineControl) = True Then
        '                    'End If
        '                    'End If


        '                Case eChSchedulerPLCSTATE.eRun

        '                    ''검사 스테이지에 Magazine이 있는지 확인 있으면 ResetContact
        '                    'For i As Integer = 0 To fMain.cPLC.m_PLCDatas.nMagazinContactIspection.Length - 1
        '                    '    If fMain.cPLC.m_PLCDatas.nMagazinContactIspection(i) = CDevPLCCommonNode.eMagazineContactIspection.eStageRead Then
        '                    '        m_ResetContact = True
        '                    '    End If
        '                    'Next

        '                    '선택된 팔레트 번호 읽어온다.
        '                    fMain.g_PalletInfos.bCheckPallet = fMain.ucPalletSelectUI.IsCheckbox

        '                    ''검사 스테이지에 있으면 재 컨택... 없으면 이송, 배출의 Slot 및 Position 확인 부분으로 이동
        '                    'If m_ResetContact = True Then
        '                    '    g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eResetContact
        '                    'Else
        '                    '    g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.ePositionAndSlotCheck
        '                    'End If

        '                    g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.ePositionAndSlotCheck
        '                    m_ProcessStart = True

        '                Case eChSchedulerPLCSTATE.eProcess
        '                    '시퀀스 루틴 실험 진행 중.....
        '                    '스케쥴러쪽이랑 매칭시켜야되서 한번 더 확인 필요
        '                    If g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eProcess Then
        '                        If m_RequestedTest = False Then
        '                            m_RequestedTest = True
        '                            m_bExhaus = False
        '                            m_bStartChk = True
        '                            fMain.MeasRun(m_CurrentSlot)
        '                        End If
        '                    End If
        '                    ' g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eExhaus
        '                Case eChSchedulerPLCSTATE.eSupply

        '                    If g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eSupply Then
        '                        fMain.SetCbPalletChange(m_CurrentSlot)

        '                        fMain.ucPalletSelectUI.Enabled_gbPallet(False)

        '                        Application.DoEvents()
        '                        Thread.Sleep(500)

        '                        'Run상태로 전환되고 나면 투입 진행
        '                        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Meas_State_Text, CStateMsg.eStateMsg.ePLC_SUPPLY, "Pallet No. = " & m_CurrentSlot + 1)
        '                        If fMain.PLCScan(g_ChSchedulerPLCStatus, m_CurrentSlot) = True Then
        '                            g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eProcess
        '                        Else
        '                        End If
        '                    End If
        '                Case eChSchedulerPLCSTATE.eExhaus
        '                    fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Meas_State_Text, CStateMsg.eStateMsg.ePLC_EXHAUS, "Pallet No. = " & m_CurrentSlot + 1)

        '                    If fMain.PLCScan(g_ChSchedulerPLCStatus, m_CurrentSlot) = True Then
        '                        g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eIDLE
        '                    End If

        '                    fMain.g_PalletInfos.bCheckPallet(m_CurrentSlot) = False  '배출하고 상태 FALSE로 변경

        '                    fMain.ucPalletSelectUI.IsCheckbox = fMain.g_PalletInfos.bCheckPallet

        '                    fMain.ucPalletSelectUI.Enabled_gbPallet(True)

        '                    m_bStartChk = False
        '                Case eChSchedulerPLCSTATE.eEQPRun

        '                    Application.DoEvents()
        '                    Thread.Sleep(500)

        '                    If g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eEQPRun Then
        '                        If fMain.PLCScan(eChSchedulerPLCSTATE.eRun, m_CurrentSlot) = True Then
        '                            g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eSupply
        '                        End If
        '                    End If
        '                Case eChSchedulerPLCSTATE.ePositionAndSlotCheck
        '                    '현재 위치 이송부에 Pallet가 있는지 확인, 현재 위치 배출부에 pallet가 없는지 확인
        '                    '같은 위치로 이동 후 -> 이송부 Pallet 체크, 배출부 Pallet 체크   이송부 = True And 배출부 = False 일 경우에만 이송 시작

        '                    Dim sMagazinePositionControl As sMagazineControl
        '                    Dim nPos As Integer
        '                    '  If m_ExhausSlot Is Nothing = False And
        '                    If m_SupplySlot Is Nothing = False And m_CurrentSlot < 0 = False Then

        '                        'Supply Slot이 있는지 체크 없으면 실험을 시작 할 수 없음.
        '                        ' If fMain.PLC_StatusCheck(CDevPLCCommonNode.eSlotSignal.eNone, CDevPLCCommonNode.eSlotSignal.eNone, CDevPLCCommonNode.ePositionSignal.eNone, CDevPLCCommonNode.ePositionSignal.eNone, "") = True Then

        '                        '선택된 팔레트 위치
        '                        fMain.GetPalletPositionMove(nPos)
        '                        m_CurrentSlot = nPos    'Main에 전달하기 위한 property

        '                        '   If fMain.PLC_PositionCheck(m_SupplySlot(0), m_SupplyPosition, m_ExhausSlot(0), m_ExhausPosition, sMagazinePositionControl) = True Then
        '                        '  If fMain.PLC_PositionCheck(nPos + 1, m_CurrentSlot, nPos + 1, m_ExhausPosition, sMagazinePositionControl) = True Then
        '                        ' m_MagazineControl = sMagazinePositionControl

        '                        '  If m_MagazineControl.nSupply = eMagazinePositionControl.eOk And m_MagazineControl.nExhaus = eMagazinePositionControl.eOk Then
        '                        g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eEQPRun
        '                        m_RequestedTest = False
        '                        'Else
        '                        '    g_ChSchedulerPLCStatus = eChSchedulerPLCSTATE.eUpOrDown
        '                        '    m_RequestedTest = False
        '                        'End If

        '                        ' End If

        '                        'End If

        '                    End If

        '            End Select

        '            fMain.PLCQueueCounter("PLC State = " & g_ChSchedulerPLCStatus.ToString)

        '        Loop

        '    End Sub

        '    Public Function CheckSelectPalletAndSupplyState(ByRef sErrorMsg As String) As Boolean
        '        Dim nCnt As Integer = 0
        '        Dim nChkPalletCnt As Integer = 0

        '        '1. 팔레트가 체크 되었는지 확인
        '        '2. 체크된 팔레트위치에 공급부의 팔레트가 들어있는지 확인
        '        '3. 체크된 팔레트 갯수와 공급부의 팔레트가 들어있는 위치의 갯수가 동일한지 확인. 같은 위치가 맞으면 nCnt+=1
        '        '4. 다를 경우 실험 시작 X

        '        For selectCnt As Integer = 0 To g_ConfigInfos.numOfPallet - 1
        '            If fMain.g_PalletInfos.bCheckPallet(selectCnt) = True Then
        '                nChkPalletCnt += 1
        '                For nSupplyCnt As Integer = 0 To m_SupplySlot.Length - 1
        '                    If m_SupplySlot(nSupplyCnt) = selectCnt + 2 Then
        '                        nCnt += 1
        '                        Exit For
        '                    End If
        '                Next
        '            End If
        '        Next

        '        If nCnt <> nChkPalletCnt Then
        '            sErrorMsg = "소프트웨어에서 선택된 팔레트 위치와 공급부의 팔레트 위치가 다릅니다..."
        '            Return False
        '        End If

        '        Return True
        '    End Function

        '    Public Function CheckInsertSupplyAndExhaus(ByRef sErrorMsg As String) As Boolean
        '        Dim nCnt As Integer = 0

        '        '공급부 유 = 배출불 무 비교 맞는지 확인 진행

        '        For nSupplyCnt As Integer = 0 To m_SupplySlot.Length - 1
        '            If m_ExhausSlot Is Nothing = False Then
        '                For nExhausCnt As Integer = 0 To m_ExhausSlot.Length - 1
        '                    If m_SupplySlot(nSupplyCnt) = m_ExhausSlot(nExhausCnt) Then
        '                        '   If fMain.g_PalletInfos.bCheckPallet(m_SupplySlot(nSupplyCnt)) = True Then
        '                        nCnt += 1
        '                        'End If

        '                    End If
        '                Next
        '                '   Else
        '                '      If fMain.g_PalletInfos.bCheckPallet(m_SupplySlot(nSupplyCnt)) = True Then
        '                '    nCnt += 1
        '                'End If
        '            End If
        '        Next

        '        If nCnt > 0 Then
        '            sErrorMsg = "공급부와 배출부 팔레트 유무를 확인해 주세요." & vbCrLf & "(공급부 : 유, 배출부 : 무) 설정필요)"
        '            Return False
        '        End If

        '        Return True
        '    End Function

        '    Public Function CheckSelectPalletInfos(ByRef sErrorMsg As String) As Boolean
        '        Dim nCnt As Integer = 0

        '        For selectCnt As Integer = 0 To g_ConfigInfos.numOfPallet - 1
        '            If fMain.g_PalletInfos.bCheckPallet(selectCnt) = True Then
        '                'fMain.frmDataGridUI.LoadPalletInfos(selectCnt)
        '                For i As Integer = 0 To g_nMaxCh - 1
        '                    If fMain.g_PalletInfos.sEachPalletInfo(selectCnt).sChannelnfos(i).sSequenceFilename = Nothing Or _
        '                        fMain.g_PalletInfos.sEachPalletInfo(selectCnt).sChannelnfos(i).sDataSaveFilePath = Nothing Or _
        '                        fMain.g_PalletInfos.sEachPalletInfo(selectCnt).sChannelnfos(i).sFilename = Nothing Then
        '                        nCnt += 1
        '                    End If
        '                Next
        '                If nCnt = g_nMaxCh Then
        '                    sErrorMsg = selectCnt + 1 & "번 팔레트의 시퀀스 파일 or 데이터 저장 경로를 확인해 주세요..."
        '                    Return False
        '                End If
        '                nCnt = 0
        '            End If
        '        Next

        '        Return True
    End Sub
End Class
