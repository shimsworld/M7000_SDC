Public Class CDevPLCCommonNode

#Region "Define"

    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False

    Protected m_nTotalAxis As Integer
    Dim myParent As frmMain

    Public Event evChangeSystemStatus(ByVal state() As eSystemStatus)
    Public Event evChangeAlarm(ByVal alarm() As eDISignal)
    Shared sSupportDeviceList() As String = New String() {"LS", "MITSUBISHI"}
    Public Shared sTCUnit() As String = New String() {"CH1", "CH2", "CH3", "CH4", "CH5", "CH6", "CH7", "CH8", "CH9"}
    Public Shared sEMSAlarm() As String = New String() {"긴급정지 알람(EMS-1)", "긴급정지 알람(EMS-2)", "", "", "세이프티 컨트롤러-1", "세이프티 컨트롤러-2", "", "", "MC1 POWER OFF", "MC2 POWER OFF", "컨트롤박스 내부온도 경알람", "컨트롤박스 내부온도 중알람", "컨트롤박스 연기감지 센서 알람"}
    Public Shared sTempAlarm() As String = New String() {"히터유닛 CH.1", "히터유닛 CH.2", "히터유닛 CH.3", "히터유닛 CH.4", "히터유닛 CH.5", "히터유닛 CH.6", "히터유닛 CH.7", "히터유닛 CH.8", "히터유닛 CH.9"}
    Public Shared sTempAlarmZone1() As String = New String() {"히터 1-1", "히터 2-1", "히터 3-1", "히터 4-1", "히터 5-1", "히터 6-1", "히터 7-1", "히터 8-1", "히터 9-1"}
    Public Shared sTempAlarmZone2() As String = New String() {"히터 1-2", "히터 2-2", "히터 3-2", "히터 4-2", "히터 5-2", "히터 6-2", "히터 7-2", "히터 8-2", "히터 9-2"}
    '  Public Shared sDoorOpenAlarm() As String = New String() {"세이트피 도어 루프 에러", "로더 세이프티 도어 개방", "암실 좌측 세이프티 도어 개방", "암실 우측 세이프티 도어 개방", "언로더 세이프티 도어 개방", "암실 하부 좌측 세이프티 도어 개방", "암실 하부 우측 세이프티 도어 개방"}
    Public Shared sDoorOpenAlarm() As String = New String() {"세이트피 도어 루프 에러", "암실 세이프티 도어 개방1", "암실 세이프티 도어 개방2", "암실 세이프티 도어 개방3", "암실 세이프티 도어 개방4", "암실 세이프티 도어 개방5", "암실 세이프티 도어 개방6", "암실 세이프티 도어 개방7", "암실 세이프티 도어 개방8"}
    Public Shared sAxisAlarm() As String = New String() {"Y1 알람", "Y2 알람", "X 알람", "Z 알람"} ', "충돌감지 알람", "원점운전 타임아웃", "위치운전 타임아웃", "AMP 과온 알람", "과전류 알람"}
    Public Shared AxisAlarm() As String = New String() {"축 알람", "서보 알람", "RLS 리밋센서 알람", "FLS 리밋센서 알람", "충돌감지 알람", "원점운전 타임아웃", "위치운전 타임아웃", "AMP 과온 알람", "과전류 알람"}
    Public Shared EQPAlaram() As String = New String() {"Light Alaram", "Heavy Alaram"}

    Public Enum eModel
        LS
        MITSUBISHI
    End Enum

    'Dim m_PLCDatas As sPLCDatas

    Public m_sSignalInfo As sSignalInfo

    Public Structure sMagazineSignal
        Dim sSupply As sSemiInLineInfo
        Dim sExhaus As sSemiInLineInfo
        Dim sContact As sContactInfo
        '  Dim sError As sMagzaineError
    End Structure

    Public Structure sSemiInLineInfo
        Dim sSlotCaption() As String
        Dim nSlotValue() As Integer
        Dim sStatusCaption() As String
        Dim nStatusValue() As Integer
        Dim sPositionCaption() As String
        Dim nPositionValue() As Integer
    End Structure

    '  Public Structure sMagzaineError
    'Dim sErrorStatusCaption() As String
    ' Dim nErrorStatusValue() As Integer
    '  End Structure

    Public Structure sContactInfo
        Dim sContactIspectionStatusCaption() As String
        Dim nContactIspectionStatusValue() As Integer
    End Structure

    Public Structure sSignalInfo
        Dim sStatusCaptions() As String
        Dim nStatusValues() As Integer
        Dim sAlarmCations() As String
        Dim nAlarmValues() As Integer
        Dim sOutputCaptions() As String
        Dim nOutputValues() As Integer
        Dim sMagazineInfos As sMagazineSignal
        Dim nEQPStatusCaption() As String
    End Structure

    Public Structure sPLCDatas
        Dim nConnectionStatusChkVal As Integer
        Dim nSystemStatus() As eSystemStatus
        Dim nDISignal() As eDISignal
        Dim nDOSignal() As eDOSignal
        Dim nSupplySlotSignal() As eSlotSignal
        Dim nSupplyPositionSignal() As ePositionSignal
        Dim nSupplyMagazineStatus() As eMagazineStatus
        Dim nExhausSlotSignal() As eSlotSignal
        Dim nExhausPositionSignal() As ePositionSignal
        Dim nExhausMagazineStatus() As eMagazineStatus
        Dim nDoorAlarm() As eDoorAlarm
        Dim nEmsAlarm() As eEMSAlarm
        Dim nStrangeTempAlarm() As eTemperatureAlarm
        Dim nEOCRTempAlarm() As eTemperatureAlarm
        Dim nSSRTempAlarm() As eTemperatureAlarm
        Dim nOverTempAlarm_Zone1() As eTemperatureAlarm
        Dim nOverTempAlarm_Zone2() As eTemperatureAlarm
        Dim nTemperatureControlAlarm() As eTemperatureAlarm
        Dim nTemperatureAlarm() As eTemperatureAlarm
        Dim nLoaderAxisAlarm() As eAxisAlarm
        Dim nHitterAxisAlarm() As eAxisAlarm
        Dim nXAxisAlarm() As eAxisAlarm
        Dim nYAxisAlarm() As eAxisAlarm
        Dim nZAxisAlarm() As eAxisAlarm
        Dim nTheta1AxisAlarm() As eAxisAlarm
        Dim nTheta2AxisAlarm() As eAxisAlarm
        Dim nTheta3AxisAlarm() As eAxisAlarm
        Dim nTheta4AxisAlarm() As eAxisAlarm
        Dim nUnLoaderAxisAlarm() As eAxisAlarm
        Dim nServoAlarm() As eServoAlarm
        Dim nAxisAlarm() As eAllAxisAlarm
        Dim nEQPAlaram() As eEQPLightAlaram
        Dim nEQPState() As eEQPStatus
    End Structure

    Public Structure sRequestInfo
        Dim nCMD As eRequestCMD
        Dim nSYSStatus As eSystemStatus
        Dim nEQPStatus As eEQPStatus
        Dim nMagazineContactInspection As eMagazineContactIspection
        Dim nMagazineStatus As eMagazineStatus
        Dim nDOStatus As eDOSignal
        Dim Param() As Double
        Dim eMovingMethod As eMovingMethod
        Dim nSlotNumber As Integer
        Dim eChangeMode As eRunningMode
    End Structure
    Public Enum eDIFanSignal
        eNoError

    End Enum
    Public Enum eMovingMethod
        eABS = 1    '절대위치
        eINC = 2    '상대위치
    End Enum
    Public Enum eMovingPosition
        eHome = 1
        ePosition = 2
    End Enum
    Public Enum eRequestCMD
        eSetStatus
        eGetAlarm
        eSetMagazineSupplyStatus
        eSetMagazineExhausStatus
        eSetMagazineContactInspection
        ' eGetMagazineAlarm
        eSetDOStatus
        eMotionCtrl
        eSetEQPStatus
    End Enum
    Public Enum eRunState
        eRun = 0
        eStop = 1
        ePause = 2
        eReset = 3
    End Enum
    Public Enum eAxis
        '   eX = 0
        eY = 0
        eZ
        eTHETA1
        eTHETA2
        eTHETA3
        eTHETA4
    End Enum
    Public Enum eSystemStatus
        'eDown = 0
        'eIDEL
        'ePROCESS
        'eMaintenance
        'eAlarm
        'eReserved01
        'eSafetyMode_Auto
        'eSafetyMode_Teach
        'ePause
        'ePauseAndIDEL
        'ePauseAndProcess
        ePower_On = 0
        ePower_Down
        eTeaching_Mode
        eAuto_Mode
        eManual_Mode
        eProcessing
        eLoading
        eIDEL
        eAlarm
        ePause
        eMotion_Servo_On
        eMotion_Servo_Off
        eMotion_Homming
        eMotion_Pos_Move_X
        eMotion_Pos_Move_Y
        eMotion_Pos_Move_Z
        eMotion_Pos_Move_Theta1
        eMotion_Pos_Move_Theta2
        eMotion_Pos_Move_Theta3
        eMotion_Pos_Move_Theta4
        eMotion_Pos_Stop
        eMotion_Set_Jog_X_Velocity
        eMotion_Set_Jog_Y_Velocity
        eMotion_Set_Jog_Z_Velocity
        eMotion_Set_Jog_Theta_Velocity
        eMotion_JOG_X_RMove
        eMotion_JOG_X_LMove
        eMotion_JOG_Y_UpMove
        eMotion_JOG_Y_DownMove
        eMotion_JOG_Z_UpMove
        eMotion_JOG_Z_DownMove
        eMotion_Jog_Theta1_UpMove
        eMotion_Jog_Theta1_DownMove
        eMotion_Jog_Theta2_UpMove
        eMotion_Jog_Theta2_DownMove
        eMotion_Jog_Theta3_UpMove
        eMotion_Jog_Theta3_DownMove
        eMotion_Jog_Theta4_UpMove
        eMotion_Jog_Theta4_DownMove
        eMotion_GET_Position
        eMotion_JOG_Mode_ON
        eMotion_JOG_Mode_OFF
        eMotion_JOG_Mode_Teach
        eMotion_JOG_Mode_Auto
        eMotion_Mode_Clear
        eMotion_Set_Jog_Stop
        eMotion_Complete_ACK
        eEQP_RUN
        eEQP_STOP
        eEQP_PAUSE
        eAlarm_Reset
        eAll_Reset
        eChangeMode
    End Enum
    Public Enum eEQPStatus
        eRun
        eStop
        ePause
        eReset
    End Enum
    Public Enum eMagazineStatus
        eIDEL = 0
        eReady
        eScan
        eScanEnd
        ePallet_Up
        ePallet_Down
        eReadyEnd
        eStart
        eProgress
        eEND
        eBusy
        eUpDownEnd
        eHome
        eHomeEnd
    End Enum

    Public Enum eMagazineContactIspection
        eIDEL = 0
        eStageRead
        eReset
        eReady
        eError
        eReserved01
        eReserved02
        eReserved03
        eReserved04
    End Enum

    Public Enum eMagazineError
        eNoError = 0
        eSupplyMove
        eExhausMove
        eReserved01
        eReserved02
        eReserved03
        eReserved04
        eReserved05
        eReserved06
        eReserved07
    End Enum

    Public Enum ePositionSignal
        eNone = 0
        ePosition01
        ePosition02
        ePosition03
        ePosition04
        ePosition05
        ePosition06
        ePosition07
        ePosition08
        ePosition09
        ePosition10
    End Enum
    Public Enum eAxisStatus
        eAxis_Can_Move
        eAxis_ACK
        eAxis_Moving_Complete
        eAxis_Can_Homming
        eAxis_ACK_Moving_Complete
    End Enum
    Public Enum eSlotMovingStatus
        eSlot_Can_Move
        eSlot_ACK
    End Enum
    Public Enum eSlot
        eSupply
        eExhaust
    End Enum
    Public Enum eSlotSignal
        eNone = 0
        eSlot00
        eSlot01
        eSlot02
        eSlot03
        eSlot04
        eSlot05
        eSlot06
        eSlot07
        eSlot08
        eSlot09
        eSlot10
    End Enum
    Public Enum eDISignal
        eNoError = 0
        eEmergency
        eFire
        eHeater
        eCurrentLimit
        eInterlock
        eCylinder
        eDoorOpen
        eSupply
        eInspectionStage
        eExhaus
    End Enum

    Public Enum eDOSignal
        eALLOFF
        ePort0_RED
        ePort1_YELLOW
        ePort2_GREEN
        ePort3_BLUE
        ePort4_Reserved
        ePort5_Reserved
        ePort6_Reserved
        ePort7_Reserved
    End Enum

    Public Enum eLiftAlarm
        eNoError = 0
        eSupply_Conbare_Exhaus
        eSupply_UpDown_Interlock1
        eSupply_UpDown_interlock2
        eContactInspection_Stage
        eExhaus_Conbare_Supply
        eExhaus_Conbare_Exhaus
        eExhaus_UpDown_Interlock1
        eExhaus_UpDown_interlock2
    End Enum

    Public Enum eDoorAlarm
        eNoError = 0
        eSafety_Door_Loop
        eSafety_Door_1
        eSafety_Door_2
        eSafety_Door_3
        eSafety_Door_4
        eSafety_Door_5
        eSafety_Door_6
        eSafety_Door_7
        eSafety_Door_8
        'eLoader_Safety_Door
        'eLeftSide_Safety_Door
        'eRightSide_Safety_Door
        'eUnLoader_Safety_Door
        'eDownLeftSide_Safety_Door
        'eDownRightSide_Safety_Door
    End Enum
    Public Enum eTemperatureAlarm
        eNoError = 0
        eT1
        eT2
        eT3
        eT4
        eT5
        eT6
        eT7
        eT8
        eT9
    End Enum

    Public Enum eEMSAlarm
        eNoError = 0
        eEMS1 = 1
        eEMS2 = 2
        eSafety_Control_Alarm1 = 5
        eSafety_Control_Alarm2 = 6
        eMC1_POWEROFF_Alarm = 9
        eMC2_POWEROFF_Alarm = 10
        eControlBoxTempLightAlarm = 11
        eControlBoxTempHeavyAlarm = 12
        eControlBoxSmokeAlarm = 13
    End Enum
    Public Enum eServoAlarm
        eY1_Axis_Servo_ON
        eZ_Axis_Servo_ON
        eTheta1_Axis_Servo_ON
        eTheta2_Axis_Servo_ON
        eTheta3_Axis_Servo_ON
        eTheta4_Axis_Servo_ON
        ' eY2_Axis_Servo_ON
        'eX_Axis_Servo_ON
    End Enum
    Public Enum eAllAxisAlarm
        eNoError = 0
        eY1_Axis_Alarm = 1
        eZ_Axis_Alarm = 2
        eTheta1_Axis_Alarm = 3
        eTheta2_Axis_Alarm = 4
        eTheta3_Axis_Alarm = 5
        eTheta4_Axis_Alarm = 6
        'eY2_Axis_Alarm = 2
        'eX_Axis_Alarm = 3

    End Enum
    Public Enum eAxisAlarm
        eNoError = 0
        eAxis_Alarm = 1
        eAxis_Servo_Alarm = 2
        eAxis_RLS_Limit_Alarm = 3
        eAxis_FLS_Limit_Alarm = 4
        eAxis_Crush_Alarm = 5
        eAxis_Homming_Timeout = 6
        eAxis_Moving_Timeout = 7
        eAMP_Over_Temp = 8
        eOver_Current = 9
    End Enum
    Public Enum ePCBInfoAlarm
        eNoError = 0
        ePCB_Pin_Contact_JIG_UP
        ePCB_Pin_Contact_JIG_Down
        ePCB_Supply_Stoper_UP
        ePCB_Supply_Stoper_Down
        ePCB_Align_Stoper_Forward
        ePCB_Align_Stoper_Reverse
        ePCB_Stage_Unit_UP
        ePCB_Stage_Unit_Down
    End Enum

    Public Enum eConbareConnection
        eNoError = 0
        eSupply_Conbare_Unit_Forward
        eSupply_Conbare_Unit_Reverse
        eExhaus_Conbare_Unit_Forward
        eExhaus_Conbare_Unit_Reverse
    End Enum

    Public Enum eEQPLightAlaram
        eNoError = 0
        eLightAlaram = 2
        eHeavyAlaram = 3
    End Enum

    Public Enum eRunningMode
        eManual = 1
        eAuto = 2
    End Enum

    Public Enum eAllResetChkState
        eCan_All_Reset = 0
        eACK_All_Reset = 1
    End Enum
#End Region

#Region "Properties"

    Public ReadOnly Property SignalInfo As CDevPLCCommonNode.sSignalInfo
        Get
            Return m_sSignalInfo
        End Get
    End Property

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public Property Model As eModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eModel)
            m_MyModel = value
        End Set
    End Property

    Public Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overridable Property ComType As CDevPLC_MITSUBISHI.eType
        Get
            Return CDevPLC_MITSUBISHI.eType._Prog
        End Get
        Set(ByVal value As CDevPLC_MITSUBISHI.eType)

        End Set
    End Property

    Public Overridable Property LoginNo As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Public Overridable ReadOnly Property StatusCaptions As String()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property StatusValue As Integer()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property AlarmCaptions As String()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property AlarmValue As Integer()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property OutputCaptions As String()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property OutputValue As Integer()
        Get
            Return Nothing
        End Get
    End Property


#End Region

#Region "Creator, Disoposer And Init"

    Public Sub New()
        m_bIsConnected = False

    End Sub

#End Region

#Region "Communication Functions"

    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub

#End Region

#Region "Control Functions"

    Public Overridable Function GetDoorAlarm(ByVal state() As eDoorAlarm) As Boolean

        Return False
    End Function

    Public Overridable Function GetTemperatureAlarm(ByVal state() As eTemperatureAlarm) As Boolean

        Return False
    End Function

    Public Overridable Function GetTemperatureControlAlarm(ByVal state() As eTemperatureAlarm) As Boolean

        Return False
    End Function
    Public Overridable Function Get_EQP_Alarm(ByVal state() As eEQPLightAlaram) As Boolean
        Return False
    End Function
    Public Overridable Function Get_Servo_Alarm(ByVal state() As eServoAlarm) As Boolean
        Return False
    End Function

    Public Overridable Function Get_Axis_Alarm(ByVal state() As eAllAxisAlarm) As Boolean
        Return False
    End Function

    Public Overridable Function GetPCB_ContactAlarm(ByVal state() As ePCBInfoAlarm) As Boolean

        Return False
    End Function

    Public Overridable Function GetConbareConnectionAlarm(ByVal state() As eConbareConnection) As Boolean

        Return False
    End Function

    Public Overridable Function GetLiftSensorAlarm(ByVal state() As eLiftAlarm) As Boolean

        Return False
    End Function

#Region "Magazine Control"

    Public Overridable Function GetSupplyPosition(ByVal state() As ePositionSignal) As Boolean
        Return False
    End Function

    Public Overridable Function GetExhausPosition(ByVal state() As ePositionSignal) As Boolean
        Return False
    End Function

    Public Overridable Function GetMagazineAlarmStatus(ByVal state() As eMagazineError) As Boolean
        Return False
    End Function

    Public Overridable Function GetMagazineSupplyStatus(ByVal state() As eMagazineStatus) As Boolean
        Return False
    End Function

    Public Overridable Function GetMagazineExhausStatus(ByVal state() As eMagazineStatus) As Boolean
        Return False
    End Function

    Public Overridable Function GetMagazineContactInspectionStatus(ByVal state() As eMagazineContactIspection) As Boolean
        Return False
    End Function

    Public Overridable Function SetMagazineSupplyStatus(ByVal state As eMagazineStatus) As Boolean
        Return False
    End Function

    Public Overridable Function SetMagazineExhausStatus(ByVal state As eMagazineStatus) As Boolean
        Return False
    End Function
    Public Overridable Function GetSupplyMoveCompleted(ByRef bCanMove As Boolean) As Boolean
        Return False
    End Function
    Public Overridable Function GetExhaustMoveCompleted(ByRef bCanMove As Boolean) As Boolean
        Return False
    End Function
    Public Overridable Function SetMagazineContactInspectionStatus(ByVal state As eMagazineContactIspection) As Boolean
        Return False
    End Function

#End Region

    Public Overridable Function SetSystemStatus(ByVal state As eEQPStatus) As Boolean
        Return False
    End Function

    Public Overridable Function GetSystemStatus(ByVal state() As eSystemStatus) As Boolean
        Return False
    End Function

    Public Overridable Function SetAlarm(ByVal alarm As eDISignal) As Boolean
        Return False
    End Function

    Public Overridable Function SetAlarm(ByVal alarm() As eDISignal) As Boolean
        Return False
    End Function

    Public Overridable Function GetAlarm(ByRef alarm() As eDISignal) As Boolean
        Return False
    End Function

    Public Overridable Function SetDOSignal(ByVal signal As eDOSignal) As Boolean
        Return False
    End Function

    Public Overridable Function SetDOSignal(ByVal signal() As eDOSignal) As Boolean
        Return False
    End Function

    Public Overridable Function GetDOSignal(ByRef signal() As eDOSignal) As Boolean
        Return False
    End Function

    Public Overridable Function CheckConnectionStatus() As Boolean
        Return False
    End Function

    Public Overridable Sub Request(ByVal info As sRequestInfo)

    End Sub

    ''New Semi In-Line 
    Public Overridable Function Can_ChangeMode() As Boolean
        Return False
    End Function
    Public Overridable Function GetSupplySlotStatus(ByVal state() As eSlotSignal) As Boolean
        Return False
    End Function
    Public Overridable Function Jog_Mode_On_Teach() As Boolean
        Return False
    End Function
    Public Overridable Function Jog_Mode_On() As Boolean
        Return False
    End Function
    Public Overridable Function Jog_Mode_Off() As Boolean
        Return False
    End Function
    Public Overridable Function Jog_Mode_Off_Auto() As Boolean
        Return False
    End Function
    Public Overridable Function GetEMSAlarm(ByVal state() As eEMSAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetStrangeTempAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetEOCRAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetSSRAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetOverTempZone1Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetOverTempZone2Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetLoaderAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetUnLoaderAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetHitterAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetXAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetYAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetZAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetTheta1AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetTheta2AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetTheta3AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetTheta4AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Return False
    End Function
    Public Overridable Function GetExhausSlotStatus(ByVal state() As eSlotSignal) As Boolean
        Return False
    End Function

    Public Overridable Function Homming() As Boolean
        Return False
    End Function
    Public Overridable Function AlarmClear() As Boolean
        Return False
    End Function
    Public Overridable Function MoveCompleted() As Boolean
        Return False
    End Function
    Public Overridable Function SetMoveComplete(ByVal axis As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function MoveCompleted(ByVal axis As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function GetCurrentPosition(ByRef dPos() As Double) As Boolean
        Return False
    End Function
    Public Overridable Function SetRunState(ByVal State As eRunState) As Boolean
        Return False
    End Function
    Public Overridable Function SetPCManualMode() As Boolean
        Return False
    End Function
    Public Overridable Function SetErrorReset() As Boolean
        Return False
    End Function
    Public Overridable Function SetManualModeRequest() As Boolean
        Return False
    End Function
    Public Overridable Function GetManualModeStatus(ByVal nState As Integer)
        Return False
    End Function
    Public Overridable Function SetAllReset() As Boolean
        Return False
    End Function
    Public Overridable Function GetCanAllReset(ByVal Mode As CDevPLCCommonNode.eAllResetChkState) As Boolean
        Return False
    End Function
    'Public Overridable Function SetSupplyRequest() As Boolean
    '    Return False
    'End Function
    'Public Overridable Function SetExhaustRequest() As Boolean
    '    Return False
    'End Function
    Public Overridable Function SetSlotNumber(ByVal nSlotNo As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function Set_Jog_Move(ByVal nAxis As Integer, ByVal bCWCCW As Boolean) As Boolean
        Return False
    End Function
    Public Overridable Function Set_Jog_Speed(ByVal nAxis As Integer, ByVal dSpeed As Double) As Boolean
        Return False
    End Function
    Public Overridable Function SetSupplySlotNo(ByVal nSlotNo As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SetExhaustSlotNo(ByVal nSlotNo As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SetEQPRequest(ByVal nState As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function GetAllResetStatus() As Boolean
        Return False
    End Function
    Public Overridable Function Get_Jog_Status(ByVal nAxis As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function JogXRMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function JogXLMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogYuPMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogYDownMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogZUpMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogZDownMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function JogTheta1UpMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogTheta1DownMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function JogTheta2UpMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogTheta2DownMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function JogTheta3UpMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogTheta3DownMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function JogTheta4UpMove(ByVal vel As Double) As Boolean
        Return False
    End Function

    Public Overridable Function JogTheta4DownMove(ByVal vel As Double) As Boolean
        Return False
    End Function
    Public Overridable Function SetJogXVelocity(ByVal Velocity As Double) As Boolean
        Return False
    End Function

    Public Overridable Function SetJogYVelocity(ByVal Velocity As Double) As Boolean
        Return False
    End Function

    Public Overridable Function SetJogZVelocity(ByVal Velocity As Double) As Boolean
        Return False
    End Function
    Public Overridable Function SetJogThetaVelocity(ByVal Velocity As Double) As Boolean
        Return False
    End Function
    Public Overridable Function PositionMoveX(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function

    Public Overridable Function PositionMoveY(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function

    Public Overridable Function PositionMoveZ(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function
    Public Overridable Function PositionMoveTheta1(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function
    Public Overridable Function PositionMoveTheta2(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function
    Public Overridable Function PositionMoveTheta3(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function
    Public Overridable Function PositionMoveTheta4(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As eMovingMethod) As Boolean
        Return False
    End Function
    Public Overridable Function GetEQPState(ByRef State() As CDevPLCCommonNode.eEQPStatus) As Boolean
        Return False
    End Function
    Public Overridable Function JOG_MOVE_STOP() As Boolean
        Return False
    End Function

    Public Overridable Function SetSlotSupply(ByVal SlotNumber As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SetSlotExhaust(ByVal SlotNumber As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SetChangeMode(ByVal Mode As eRunningMode) As Boolean
        Return False
    End Function
    Public Overridable Function SetCompleteACK(ByVal Axis As CDevPLCCommonNode.eAxis) As Boolean
        Return False
    End Function

#Region "Suport Functions"

    'Public Overridable Function DecToBinery(ByVal dec As Integer) As Integer()
    '    Return Nothing
    'End Function

    Public Overridable Function hex2bin(ByVal in_val) As Integer()
        Return Nothing
    End Function

    Public Shared Function DecToBinery(ByVal dec As Integer) As Integer()
        Dim nInValue As Integer = dec
        Dim quota As Integer
        Dim remainder As Integer
        Dim nCnt As Integer
        Dim nBinery(7) As Integer

        If nInValue < 0 Or nInValue > 255 Then
            Return New Integer() {-1, -1, -1, -1, -1, -1, -1, -1}
        End If

        Do
            quota = Fix(nInValue / 2)
            If quota <= 1 Then
                remainder = nInValue - (quota * 2)
                nBinery(nCnt) = remainder
                nCnt += 1
                nBinery(nCnt) = quota
                Exit Do
            End If
            remainder = nInValue - (quota * 2)
            nBinery(nCnt) = remainder
            nInValue = quota
            nCnt += 1

        Loop
        Return nBinery

    End Function

    Public Function dec2bin(ByVal in_val)

        Dim i As Integer
        Dim result As Integer
        Dim strResult As String = ""
        'Dim dIn_Data As Integer

        in_val = Val(in_val)   '입력값을 숫자로 변환합니다.

        i = 0
        Do
            result = Str(in_val Mod 2) '+ result     '2로 나눈 나머지(0,1)을 차곡차곡 앞쪽으로 붙임
            strResult = CStr(result) & strResult
            in_val = Int(in_val / 2)    '2로 나눈 몫은 다음 Mod를 위해 저장
            i = i + 1
        Loop Until in_val = 1 Or in_val = 0    '몫이 2로 더이상 나누어 지지 않을때 루프의 끝
        strResult = in_val & strResult   '마지막으로 2로 나누어 지지 않는값도 앞쪽에 붙임

        dec2bin = strResult
    End Function

#End Region


    Public Overridable Function SendTestCommand(ByVal sCommand As String, ByRef sRcvData As String) As Boolean
        Return False
    End Function

#End Region

End Class
