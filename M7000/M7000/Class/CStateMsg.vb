Public Class CStateMsg

    Public Event StatusEventID(ByVal type As eType, ByVal ID As eStateMsg)
    Public Event StatusEventMsg(ByVal type As eType, ByVal strMsg As String)
    Public Event ChStatusEventMsg(ByVal targetCh As Integer, ByVal type As eType, ByVal strMsg As String)

    ' Public Event 




    Public g_sStatusMsgs_KOR() As String = New String() {"System configuration is required.",
                                                         "Check device configuration and communication settings.",
                                                         "Channel settings are required.",
                                                         "Please check the option setting.",
                                                         "I can not run it because I can not see the previous experiment information.",
                                                         "SYSTEM_ALARM_Failed_Create_Device",
                                                         "SYSTEM_ALARM_Failed_Load_RangeData",
                                                         "SYSTEM_ALARM_EMERGENCY_CLOSED",
                                                         "SYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION",
                                                         "SYSTEM_ERROR_SEQ_PROCESS_TIMEOUT",
                                                        "Please select a channel.",
                                                        "Please use after connecting the system",
                                                        "Current connection is complete.",
                                                        "No Information for SG Signal.",
                                                        "The selected channel is already running. You can restart after shutdown.",
                                                        "The selected group has an experiment in progress first. You must run it after finishing.",
                                                        "Can not find motion position infomation.",
                                                        "Ready to Auto Centering & Focusing",
                                                        "Completed Auto Centering",
                                                        "Completed Auto Focusing",
                                                        "Running Auto Focusing",
                                                        "Running Auto Centering",
                                                        "Failed Auto Focusing[Message : Cells are too dark to process data.]",
                                                        "Failed Auto Focusing[Message : Cells are dark or not turned on.]",
                                                        "Failed Auto Centering[Message : Cells are low in brightness and can not process data.]",
                                                        "Failed Auto Centering[Message : Cells are low or not turned on.]",
                                                        "Cell Intensity adjust [Message : Increase the cell bias]",
                                                        "Cell Intensity adjust [Message : Cell brightness adjustment complete ]",
                                                        "Failed Cell Intensity adjust[Message : Failed Cell Bias Setting ]",
                                                        "Failed Cell Intensity adjust][Message : Please check the conditions of the cell.]",
                                                         "It can not be used during the experiment. Please make sure all channels are IDLE.",
                                                         "Please check the sequence file or save path.",
                                                         "SYSTEM_THREAD_START",
                                                         "SYSTEM_THREAD_STOP",
                                                         "SYSTEM_PLC_THREAD_START",
                                                         "SYSTEM_PLC_THREAD_STOP",
                                                        "There is no recipe registered in the sequence. Please register and use.",
                                                         "Please check the sequence information and try again..",
                                                          "The selected channel can only perform IVL Test.",
                                                         "Data information mismatch.",
                                                          "There is no termination condition. Experiments can be repeated indefinitely.",
                                                         "Connecting...",
                                                         "Connection Completed",
                                                         "Connection Failed,Please check the Configuration Settings",
                                                         "SYSTEM Disconnected",
                                                         "SYSTEM READY",
                                                         "SYSTEM RUNNING",
                                                          "CH Test Start",
                                                         "CH Test Exit",
  "SYSTEM_STATUS_REQUEST_PAUSE",
                                                         "SYSTEM_STATUS_TEACH",
                                                         "SYSTEM_STATUS_AUTO",
                                                         "SYSTEM_STATUS_RELEASE_PAUSE",
                                                         "SYSTEM_STATUS_EMERGENCY_STOP",
                                                         "SYSTEM_STATUS_RELEASE_EMERGENCY",
                                                         "Homming...",
                                                         "Motion Moved Home Position...",
                                                         "Device Initilization Fail",
                                                         "DEV_COMMON_MSG_Retry_TimeOut_Cnt",
                                                         "SG Function Error",
                                                         "SG Wrong Input Signal",
                                                         "SG Channel number is wrong.",
                                                         "SG Subroutine Status Error",
                                                         "SG Resister Read",
                                                         "SG Limit Alarm",
                                                         "PG Power Function Error",
                                                         "PG Function Error",
                                                         "PG Control Board Function Error",
                                                            "Connected to M6000",
        "Failed connection to M6000",
                                                         "M6000 Function Error",
                                                         "M6000 Not Read Calibration Data.",
                                                         "M6000 SubRoutine Status Error",
                                                         "M6000 Limit Alarm",
                                                             "Connected to PLC",
        "Failed connection to PLC",
        "Connected to Temperature Controller",
        "Failed connection to Temperature Controller",
        "Connected to ACF CAMERA",
        "Failed connection to ACF CAMERA",
                                          "DEV_ACF_MSG_Function_Error",
                                          "DEV_SPECTRORADIOMETER_Connected",
        "DEV_SPECTRORADIOMETER_ConnectionFailed",
        "DEV_SPECTRORADIOMTER_FUNC_ERROR",
                                          "DEV_COLORANALYZER_ZEROCAL",
        "DEV_COLORANALYZER_COMPLETE_ZEROCAL",
                                          "check the motion position data(Spectrometer)",
                                          "check the motion position data(CCD)",
                                          "check the motion position data(MCR)",
                                          "check the motion position data(CA)",
                                                         "check the motion position data(Theta Y)",
                                          "Save Position Complete(Spectrometer)",
                                          "Save Position Complete(CCD)",
                                          "Save Position Complete(MCR)",
                                          "Save Position Complete(CA)",
                                                         "Save Position Complete(Theta Y)",
                                          "DEV_MOTION_CMD_POS_MISMATCH",
                                          "DEV_MOTION_CMD_CHECK_FAILED",
                                          "DEV_MOTION_Function_Error",
        "DEV_G4s_MSG_SEQ_ROUTINE_START",
        "DEV_G4s_MSG_SEQ_ROUTINE_STOP",
        "DEV_G4s_MSG_FUNCTION_ERROR", "DEV_G4s_MSG_ERROR_COUNT_OVER_Client_Nothing",
                                                         "DEV_HEXA_Transpose_Error",
                                                         "DEV_HEXA_Multiply_Error",
                                                         "DEV_HEXA_Inverse_Error",
                                                         "K_Factor_Calibration_Error",
                                                         "DEV_STROBE_CONNECTION_SUCCESS",
                                                         "DEV_STROBE_CONNECGTION_FAILURE",
                                                         "DEV_MOTION_CONNECTION_SUCCESS",
                                                         "DEV_MOTION_CONNECTION_FAILURE",
                                                         "Change PLC State",
                                                         "Manual cell on-off",
                                                        "AllocationGetvalue error",
                                                         "팔레트 대기중...",
        "물류부 홈 이동...",
        "팔레트 실험을 진행 합니다...",
        "팔레트 공급",
        "팔레트 배출",
        "팔레트 스캔",
        "팔레트 위치 체크",
        "과전류 알람",
        "과온 알람",
        "비상 정지 스위치 알람",
        "컨트롤 전원 확인 알람",
        "세이프티 릴레이 확인 알람1",
        "세이프티 릴레이 확인 알람2",
        "도어 세이프티 확인 알람1",
        "도어 세이프티 확인 알람2",
        "사이드 도어 오픈 알람",
        "제어부 온도 상승 알람",
        "공급 리프트 도어 오픈 알람",
        "검사 스테이지 도어 오픈 알람",
        "배출 리프트 도어 오픈 알람",
        "PCB 핀 컨텍 지그 상승 알람",
        "PCB 핀 컨텍 지그 하강 알람",
        "PCB 공급 스토퍼 상승 알람",
        "PCB 공급 스토퍼 하강 알람",
        "PCB 얼라인 스토퍼 전진 알람",
        "PCB 얼라인 스토퍼 후진 알람",
        "PCB 스테이지 유닛트 상승 알람",
        "PCB 스테이지 유닛트 하강 알람",
        "공급 컨베어 연결 유닛 전진 알람",
        "공급 컨베어 연결 유닛 후진 알람",
        "배출 컨베어 연결 유닛 전진 알람",
        "배출 컨베어 연결 유닛 후진 알람",
        "공급 컨베어 배출 체크 센서 알람",
        "공급 상승/하강 인터록 센서 알람1",
        "공급 상승/하강 인터록 센서 알람2",
        "검사 스테이지 공급 체크 센서 알람",
        "배출 컨베어 공급 체크 센서 알람",
        "배출 컨베어 배출 체크 센서 알람",
        "배출 상승/하강 인터록 센서 알람1",
        "배출 상승/하강 인터록 센서 알람2",
        "Door 센서 정상",
        "EOCR 정상(과전류)",
        "온도 컨트롤러 정상(과온)",
        "팔레트 컨텍 센서 정상",
        "컨베어 센서 정상",
        "리프트 센서 정상",
        "SMU Error",
        "Switch Error",
        "EMS 및 Control box 알람",
        "온도 이상 알람",
        "온도 ECOR 알람",
        "온도 SSR 알람",
        "온도 과온 알람",
        "도어 오픈 알람",
        "축 알람",
                                                         "Manual Measuring", "Manual Measure end"}

#Region "Enums"

    Public Enum eType
        eMSG_State     'Status Bar
        eMSG_Log       'Status Bar, Log 파일 출력
        eMSG_Popup   'MSG BOX 로 표시
        eMSG_List ' Status List 출력
        eMsg_Popup_Log
        eMsg_State_Log
        eMsg_List_Log
        eMSG_State_Log_Popup   'Status Bar, Log 파일 ,  msgbox
        eMsg_State_Log_Alarm_Text
    End Enum

    Public Enum eStateMsg
        eSYSTEM_ALARM_Check_SystemConfig
        eSYSTEM_ALARM_Check_DeviceConfig
        eSYSTEM_ALARM_Check_SystemSettings
        eSYSTEM_ALARM_Check_Options
        eSYSTEM_ALARM_Check_ChannelLastSequenceInfo
        eSYSTEM_ALARM_Failed_Create_Device         'Failed create to Device Object in updateDeviceConfig()::frmMainClass
        eSYSTEM_ALARM_Check_LoadRangeData
        eSYSTEM_ALARM_EMERGENCY_CLOSED
        eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION
        eSYSTEM_ERROR_SEQ_PROCESS_TIMEOUT
        eSYSTEM_MSG_Need_ChannelSelection
        eSYSTEM_MSG_Need_Connection
        eSYSTEM_MSG_Alrady_Connected
        eSYSTEM_MSG_Need_SG_SignalInfo
        eSYSTEM_MSG_Selected_Ch_Alredy_Running
        eSYSTEM_MSG_Selected_JIG_Alredy_Running
        eSYSTEM_MSG_Not_Found_MotionPos
        eSYSTEM_MSG_ACF_Ready
        eSYSTEM_MSG_ACF_Completed_AC
        eSYSTEM_MSG_ACF_Completed_AF
        eSYSTEM_MSG_ACF_RunningAF
        eSYSTEM_MSG_ACF_RunningAC
        eSYSTEM_MSG_ACF_AF_Fail_NotDetectedCellBlob
        eSYSTEM_MSG_ACF_AF_Fail_LowIntensity
        eSYSTEM_MSG_ACF_AC_Fail_NotDetectedCellBlob
        eSYSTEM_MSG_ACF_AC_Fail_LowIntensity
        eSYSTEM_MSG_ACF_Cell_Intensity_Adjust
        eSYSTEM_MSG_ACF_Completed_Cell_Intensity_Adjust
        eSYSTEM_MSG_ACF_Fail_ACF_Bias_Setting
        eSYSTEM_MSG_ACF_Fail_Cell_Intensity_Adjust_Check_Cell
        eSYSTEM_MSG_Can_use_in_IDLE_STATUE
        eSYSTEM_MSG_Need_Sequencefile_Savepath
        eSYSTEM_THREAD_START
        eSYSTEM_THREAD_STOP
        eSYSTEM_PLC_THREAD_START
        eSYSTEM_PLC_THREAD_STOP
        eSEQUENCE_Nothing_Recipe
        eSEQUENCE_Check_SequenceInfo_After_ReTry
        eSEQUENCE_Selected_Ch_Only_IVLTest
        eSEQUENCE_Number_Error_Of_Save_File
        eSEQUENCE_Nothing_End_Condition
        eSYSTEM_STATUS_Connecting
        eSYSTEM_STATUS_Connected
        eSYSTEM_STATUS_ConnectionFailed
        eSYSTEM_STATUS_Disconnected
        eSYSTEM_STATUS_READY
        eSYSTEM_STATUS_RUNNING
        eSYSTEM_STATUS_CH_TEST_BEGIN
        eSYSTEM_STATUS_CH_TEST_END
        eSYSTEM_STATUS_REQUEST_PAUSE
        eSYSTEM_STATUS_PAUSED
        eSYSYEM_STATUS_AUTO
        eSYSTEM_STATUS_RELEASE_PAUSE
        eSYSTEM_STATUS_EMERGENCY_STOP
        eSYSTEM_STATUS_RELEASE_EMERGENCY
        eSYSTEM_STATUS_HOMMING
        eSYSTEM_STATUS_HOMMING_END
        eDEV_COMMON_MSG_CanNotInit
        eDEV_COMMON_MSG_Retry_TimeOut_Cnt
        eDEV_SG_MSG_Function_Error
        eDEV_SG_MSG_Wrong_Input_Signal
        eDEV_SG_MSG_Channel_Number_UnCorrect
        eDEV_SG_MSG_Sub_routine_Status_Error
        eDEV_SG_MSG_Resister_Read
        eDEV_SG_MSG_Limit_Alarm
        eDEV_PG_POWER_MSG_Function_Error
        eDEV_PG_MSG_Function_Error
        eDEV_PG_PALLET_MSG_Function_Error
        eDEV_M6000_Connected
        eDEV_M6000_ConnectionFailed
        eDEV_M6000_MSG_Function_Error
        eDEV_M6000_MSG_Can_Not_Read_Cal_Data
        eDEV_M6000_MSG_Sub_routine_Status_Error
        eDEV_M6000_Limit_Alarm
        eDEV_PLC_Connected
        eDEV_PLC_ConnectionFailed
        eDEV_TC_Connected
        eDEV_TC_ConnectionFailed
        eDEV_ACF_CAMERA_Connected
        eDEV_ACF_CAMERA_ConnectionFailed
        eDEV_ACF_MSG_Function_Error
        eDEV_SPECTRORADIOMETER_Connected
        eDEV_SPECTRORADIOMETER_ConnectionFailed
        eDEV_SPECTRORADIOMTER_FUNC_ERROR
        eDEV_COLORANALYZER_ZEROCAL
        eDEV_COLORANALYZER_COMPLETE_ZEROCAL
        eDEV_MOTION_CHECK_POSITION_DATA_SPECTROMETER
        eDEV_MOTION_CHECK_POSITION_DATA_CCD
        eDEV_MOTION_CHECK_POSITION_DATA_MCR
        eDEV_MOTION_CHECK_POSITION_DATA_COLORANALYZER
        eDEV_MOTION_CHECK_POSITION_DATA_THETA_Y
        eDEV_POSITION_DATA_SAVE_SPECTROMETER
        eDEV_POSITION_DATA_SAVE_CCD
        eDEV_POSITION_DATA_SAVE_MCR
        eDEV_POSITION_DATA_SAVE_COLORANALYZER
        eDEV_POSITION_DATA_SAVE_THETA_Y
        eDEV_MOTION_CMD_POS_MISMATCH
        eDEV_MOTION_CMD_CHECK_FAILED
        eDEV_MOTION_Function_Error
        eDEV_G4s_MSG_SEQ_ROUTINE_START
        eDEV_G4s_MSG_SEQ_ROUTINE_STOP
        eDEV_G4s_MSG_FUNCTION_ERROR
        eDEV_G4s_MSG_ERROR_COUNT_OVER_Client_Nothing
        eDEV_HEXA_TRANSPOSE_ERROR
        eDEV_HEXA_MULTIPLY_ERROR
        eDEV_HEXA_INVERSE_ERROR
        eDEV_HEXA_K_FACTOR_CALIBRATION_ERROR
        eDEV_STROBE_CONNECTED
        eDEV_STROBE_CONNECTED_FAILURE
        eDEV_MOTION_CONNECTED
        eDEV_MOTION_CONNECTED_FAILURE
        eSystem_Change_PLC_STATE
        eSystem_Manual_Cell_ONOFF
        eSystem_Allocation_value_error
        ePLC_IDEL
        ePLC_HOME
        ePLC_PROCESS
        ePLC_SUPPLY
        ePLC_EXHAUS
        ePLC_SCAN
        ePLC_POSITION_SLOT_CHECK
        eEOCR_ALARM
        eTEMPATURE_ALARM
        ePLC_ALARM_EMS
        ePLC_ALARM_CONTROL_POWER
        ePLC_ALARM_SAFETY_RELAY1
        ePLC_ALARM_SAFETY_RELAY2
        ePLC_ALARM_DOOR_SAFETY1
        ePLC_ALARM_DOOR_SAFETY2
        ePLC_ALARM_SIDE_DOOR_OPEN
        ePLC_ALARM_CONTROL_TC
        ePLC_ALARM_SUPPLY_LIFT_DOOR_OPEN
        ePLC_ALARM_CONTACT_INSPECTION_STAGE_DOOR_OPEN
        ePLC_ALARM_EXHAUS_LIFT_DOOR_OPEN
        ePLC_ALARM_PCB_PIN_CONTACT_JIG_UP
        ePLC_ALARM_PCB_PIN_CONTACT_JIG_DOWN
        ePLC_ALARM_PCB_SUPPLY_STOPER_UP
        ePLC_ALARM_PCB_SUPPLY_STOPER_DOWN
        ePLC_ALARM_PCB_ALIGN_STOPER_FORWARD
        ePLC_ALARM_PCB_ALIGN_STOPER_REVERSE
        ePLC_ALARM_PCB_STAGE_UNIT_UP
        ePLC_ALARM_PCB_STAGE_UNIT_DOWN
        ePLC_ALARM_SUPPLY_CONBARE_CONNECTION_UNIT_FORWARD
        ePLC_ALARM_SUPPLY_CONBARE_CONNECTION_UNIT_REVERSE
        ePLC_ALARM_EXHAUS_CONBARE_CONNECTION_UNIT_FORWARD
        ePLC_ALARM_EXHAUS_CONBARE_CONNECTION_UNIT_REVERSE
        ePLC_ALARM_SUPPLY_CONBARE_EXHAUS_CHECK_SENSOR
        ePLC_ALARM_SUPPLY_UPDOWN_INTERLOCK_SENSOR1
        ePLC_ALARM_SUPPLY_UPDOWN_INTERLOCK_SENSOR2
        ePLC_ALARM_CONTACTINSPECTION_STAGE_SUPPLY_CHECK_SENSOR
        ePLC_ALARM_EXHAUS_CONBARE_SUPPLY_CHECK_SENSOR
        ePLC_ALARM_EXHAUS_CONBARE_EXHAUS_CHECK_SENSOR
        ePLC_ALARM_EXHAUS_UPDOWN_INTERLOCK_SENSOR1
        ePLC_ALARM_EXHAUS_UPDOWN_INTERLOCK_SENSOR2
        ePLC_ALARM_DOOR_OK
        ePLC_ALARM_TC_POWER_OK
        ePLC_ALARM_TC_CONTROL_OK
        ePLC_ALARM_PCB_CONTACT_OK
        ePLC_ALARM_CONBARE_OK
        ePLC_ALARM_LIFT_OK
        eSMU_ERROR
        eSWITCH_ERROR
        ePLC_ALARM_EMS_AND_CONTROLBOX
        ePLC_ALARM_TEMP_STRANGE
        ePLC_ALARM_TEMP_EOCR
        ePLC_ALARM_TEMP_SSR
        ePLC_ALARM_TEMP_OVER
        ePLC_ALARM_DOOR_OPEN
        ePLC_ALARM_AXIS
        eManulMeasuring
        eManulMeasureEnd
    End Enum

#End Region

    'Public Sub messageToString(ByVal type As eType) As eStateMsg
    '    RaiseEvent StatusEventMsg(type, g_sStatusMsgs_KOR(value))
    'End Sub

    Public Sub messageToString(ByVal type As eType, ByVal state As eStateMsg)
        RaiseEvent StatusEventMsg(type, g_sStatusMsgs_KOR(state))
    End Sub

    Public Sub messageTostring(ByVal targetCh As Integer, ByVal type As eType, ByVal state As eStateMsg)
        RaiseEvent ChStatusEventMsg(targetCh, type, g_sStatusMsgs_KOR(state))
    End Sub

    Public Sub messageToUserErrorCode(ByVal type As eType, ByVal state As eStateMsg, ByVal userMsg As String)
        RaiseEvent StatusEventMsg(type, g_sStatusMsgs_KOR(state) & " | " & userMsg)
    End Sub

    Public Sub messageToUserErrorCode(ByVal targetCh As Integer, ByVal type As eType, ByVal state As eStateMsg, ByVal userMsg As String)
        RaiseEvent ChStatusEventMsg(targetCh, type, g_sStatusMsgs_KOR(state) & " | " & userMsg)
    End Sub

End Class
