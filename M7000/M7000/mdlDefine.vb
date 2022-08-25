Module mdlDefine

    Public g_strMainTitle As String = "M7000 Lifetime Test System"

    Public g_strSWVer As String = "1.1.0.3_202106"

    '=================================================
    '버전 분기에 따른 관리 방안
    '현재 UI Flatform 을 사용하면서 시스템 구조상 호환이 어려운 경우에 대한 분기 버전의 관리 방안 필요
    'V n1.n2.n3 (0.0.0) 체계에서
    ' n1 : 동일 UI flatform
    ' n2 : 버젼 분기된 번호
    ' n3 : 버젼 분기된 SW에서의 Update 또는 Revision 된 번호
    '================================================
    'Version _ Build Date
    '1.10.000" :덕산 납품 초기 버전


    '-------------------신규 버젼 관리 체계-----------------
    '통합 가능 버젼
    '1.0.xxx" : PMX 장비
    '1.1.xxx" : AMX 장비
    '1.2.xxx" : 

    '고객 최적화 버젼
    '1.10.xxx" : BOE 장비
    '1.11.xxx" : LGC 김동헌 과장 소스코드
    '1.12.xxx" : SDC 문창윤 선임 (GNT 구동기 적용, Lifetime 측정 기능)
    '1.13.xxx" : 정승재 책임(55인치 대형 패널 Type1)

    Public g_strFileVer As String = "1.0.0"    '데이터 저장 포맷 버젼
    Public g_nHWM6000StartIndex As Integer = 0
    Public g_ChRangeInfo() As frmChannelRangeSetttings.sRangeSettings
    Public g_ConfigInfos As frmConfigDevice.sConfig
    Public g_ChAllocationInfos() As frmSettingWind.sChAllocationInfo
    Public g_SystemInfo As frmMain.sSStatus
    Public g_SystemOptions As frmMain.sSOptions  ' Public g_sSystemOption As frmOptionWindow.sOPTIONDATa
    Public g_SequenceBuilderOptions As frmBuilderSettings.sSeqBuilderSettings
    ' Public g_ChAllocationInfos() As frmSettingWind.sChAllocationInfo
    Public g_SystemSettings As frmSettingWind.sSystemSettings
    Public g_FileFormatError As Boolean = False
    Public g_nMaxCh As Integer = 100
    Public g_nMaxJIG As Integer = 10
    Public g_CalDegree As Integer = 0
    Public g_ConnectedSpectrometer As Boolean = False
    Public g_sPATH_SYSINI As String = New String(Application.StartupPath & "\Config\")
    Public g_sPATH_CONFIG As String = New String(Application.StartupPath & "\Configuration\")
    Public g_SPATH_SystemData As String = New String(Application.StartupPath & "\SystemData\")
    Public g_SPATH_Data As String = New String(Application.StartupPath & "\Data\")
    Public g_sPATH_SystemData_Sequence As String = New String(Application.StartupPath & "\SystemData\Sequence\")   '현재 또는 마지막에 사용된 Sequence 정보 저장용 폴더

    Public InIHEXA50 As String = "HEXA50.ini"
    Public InIHEXA50FitParam As String = "\KFactor\FitParam.ini"
    Public g_sPATH_HEXAKFactorParam As String = "\Data\KFactor\"

    Public g_sPATH_ChannelAssign As String = g_sPATH_CONFIG & "ChAssign\"
    Public g_sPATH_CONFIG_DEVICE As String = g_sPATH_CONFIG & "Device\"
    Public g_sPATH_SYSTEM_OPTION As String = g_SPATH_SystemData & "Option\"
    Public g_sPATH_SYSTEM_LOG As String = g_SPATH_SystemData & "Log\"
    Public g_sPATH_POSTION_LOG As String = g_SPATH_SystemData & "Postion\"
    Public g_sPATH_SHARED_DATA As String = Application.StartupPath & "\SharedData\"
    Public g_sPATH_ViewerData As String = g_sPATH_SHARED_DATA & "Viewer\"
    Public g_sPATH_SEQUENCE As String = Application.StartupPath & "\Sequence\"
    Public g_sPATH_RECIPE_SG As String = Application.StartupPath & "\Recipes\Signal Generator"
    Public g_sPATH_PG_IMAGE As String = Application.StartupPath & "\SharedData\PGImage"
    Public g_sPATH_IMAGE_BACKUP As String = Application.StartupPath & "\SharedData\PGImage_Back"


    Public g_sFilePath_SystemConfig As String = g_sPATH_CONFIG & "SYSConfig.ini"
    Public g_sFilePath_UserSettings As String = g_sPATH_CONFIG & "UserSettings.ini"
    Public g_sFilePath_DeviceConfig As String = g_sPATH_CONFIG_DEVICE & "DevConfig.ini"
    Public m_sChAllocationFileName As String = "ChAllocation.ini"

    Public g_sFilePath_M600CalData As String = g_sPATH_CONFIG_DEVICE & "M600CalData.ini"
    Public g_sFilePath_SystemOption As String = g_sPATH_SYSTEM_OPTION & "SystemOption.ini"
    Public g_sFilePath_SystemLog As String = g_sPATH_SYSTEM_LOG & "SystemLog_" & Format(Now.Year, "0000") & Format(Now.Month, "00") & Format(Now.Day, "00") & "_" & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00") & ".ini"
    Public g_sFilePath_ViewerData As String = g_sPATH_ViewerData & "ViewerPath.ini"
    Public g_sFilePath_SeqBuilderSettings As String = g_sPATH_SEQUENCE & "seqBdrCfg.ini"
    Public g_BrightCal_FileName As String = "BrightCal.ini"
    Public g_sFilePath_PGImage As String = g_sPATH_PG_IMAGE & "\" & "ImageManager.ini"

    'Multi Save Path
    Public g_MultiSavePath As String = Nothing
    Public g_MultiSaveFileName() As String = Nothing

    Public g_sSaveDirectory_StateInfo As String = Application.StartupPath & "\State\"
    Dim m_sFileName_StateOfChannel As String = "ChannelStateInformation.ini"
    Dim m_sFileName_StateOfSystem As String = "SystemStateInformation.ini"
    Public g_sSavePath_StateOfChannel As String = g_sSaveDirectory_StateInfo & m_sFileName_StateOfChannel
    Public g_sSavePath_StateOfSystem As String = g_sSaveDirectory_StateInfo & m_sFileName_StateOfSystem

    Public m_PATH_ViewerFolder As String = "M6000_DataViewer"   'mdlDefine 으로 이동
    Public g_SPATH_ROOT_MCSCIENCE As String = "McScience"
    ' Public g_SPATH_ViewerData As String = New String(Application.StartupPath & "\ViewerData\")
    Public g_ViewerData_FileName As String = "DataViewInfo.csv"
    'Public SetBiasTest() As Double

    Public g_sFilePath_MotionPosCCD As String = g_SPATH_SystemData & "MotionPosCCD.ini"
    Public g_sFilePath_MotionPosSpectrometer As String = g_SPATH_SystemData & "MotionPosSpectrometer.ini"
    Public g_sFilePath_MotionPosColorAnalyzer As String = g_SPATH_SystemData & "MotionPosColorAnalyzer.ini"
    Public g_sFilePath_MotionPosMCR As String = g_SPATH_SystemData & "MotionPosMCR.ini"
    Public g_sFilePath_ProcessID As String = g_SPATH_SystemData & "ProcessID.ini"
    Public g_sFilePath_MotionPosThetaY As String = g_SPATH_SystemData & "MotionPosThetaY.ini"

    '  Public g_sSpectrometerInfos As CSpectrometerLib.CDevSpectrometerCommonNode.DeviceOption
    Public g_motionPosSpectrometer() As String
    Public g_motionPosCCD() As String
    Public g_motionPosMCR() As String
    Public g_motionPosColorAnalyzer() As String
    Public g_motionPosThetaY() As String
    Public g_PLCState As PLCState
    Enum PLCState
        eAuto
        eTeach
    End Enum

    Public Structure sMeasureParams
        Dim totalTime As CTime.sTimeValue
        Dim lifeTime As CTime.sTimeValue
        Dim modeTime As TimeSpan
        Dim bIsSavedRefPDCurrent As Boolean
        Dim dRefPDCurrent As Double
        Dim dLumi As Double
        Dim m6000Datas As CDevM6000PLUS.sMeasParams
        ''===M7000========
        Dim totalTime_Current As CTime.sTimeValue '전체 진행시간 = Lifetime
        Dim totalTime_SetValue As CTime.sTimeValue '설정한 전체 진행시간 , 종료 조건에 추가 된 값
        Dim Progress_Current As Integer 'Sequence에서 현재 진행중인  Recipe
        Dim Progress_Total As Integer 'Sequence에 등록된 총 Recipe의 수
        Dim Result As Integer ' 결과 상태를 Enum으로 정의필요함 (Pass, Failed)
        Dim sRecipeTitle As String 'Recipe파일의 이름
        Dim dTemp As Double '현재 온도
        Dim dEnvironmentHumidity As Double
        Dim dEnvironmentTemp As Double
        Dim nLoopCnt As Integer 'Sequence의 반복 횟수
        Dim sEtc As String
    End Structure

    Public WriteOnly Property Type As String
        Set(value As String)
            g_sFilePath_DeviceConfig = g_sPATH_CONFIG_DEVICE & value & "DevConfig.ini"
            m_sChAllocationFileName = value & m_sChAllocationFileName
            g_sFilePath_MotionPosCCD = g_SPATH_SystemData & value & "MotionPosCCD.ini"
            g_sFilePath_MotionPosSpectrometer = g_SPATH_SystemData & value & "MotionPosSpectrometer.ini"
            g_sFilePath_MotionPosThetaY = g_SPATH_SystemData & value & "MotionPosThetaY.ini"
        End Set
    End Property


End Module
