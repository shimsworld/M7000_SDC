Module EziSERVOPlusRCommand


    Public Declare Function FAS_Connect Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal dwBaud As UInteger) As Boolean
    Public Declare Sub FAS_Close Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte)
    Public Declare Sub FAS_EnableLog Lib "DLL\EziMOTIONPlusR.dll" (ByVal bEnable As Boolean)
    Public Declare Function FAS_SetLogPath Lib "DLL\EziMOTIONPlusR.dll" (ByVal lpPath As String) As Boolean
    Public Declare Function FAS_IsSlaveExist Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
    Public Declare Function FAS_GetSlaveInfo Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef pType As Byte, ByVal lpBuff() As Byte, ByVal nBuffSize As Integer) As Integer
    Public Declare Function FAS_GetMotorInfo Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef pType As Byte, ByVal lpBuff() As Byte, ByVal nBuffSize As Integer) As Integer
    Public Declare Function FAS_SaveAllParameters Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_SetParameter Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByVal lParamValue As Integer) As Integer
    Public Declare Function FAS_GetParameter Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByRef lParamValue As Integer) As Integer
    Public Declare Function FAS_GetROMParameter Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByRef lRomParam As Integer) As Integer
    Public Declare Function FAS_SetIOInput Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwIOSETMask As UInteger, ByVal dwIOCLRMask As UInteger) As Integer
    Public Declare Function FAS_GetIOInput Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwIOInput As UInteger) As Integer
    Public Declare Function FAS_SetIOOutput Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwIOSETMask As UInteger, ByVal dwIOCLRMask As UInteger) As Integer
    Public Declare Function FAS_GetIOOutput Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwIOOutput As UInteger) As Integer
    Public Declare Function FAS_GetIOAssignMap Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iIOPinNo As Byte, ByRef dwIOLogicMask As UInteger, ByRef bLevel As Byte) As Integer
    Public Declare Function FAS_SetIOAssignMap Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iIOPinNo As Byte, ByVal dwIOLogicMask As UInteger, ByVal bLevel As Byte) As Integer
    Public Declare Function FAS_IOAssignMapReadROM Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_ServoEnable Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bOnOff As Boolean) As Integer
    Public Declare Function FAS_ServoAlarmReset Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_StepAlarmReset Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bReset As Boolean) As Integer
    Public Declare Function FAS_GetAxisStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwAxisStatus As UInteger) As Integer
    Public Declare Function FAS_GetIOAxisStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwInStatus As UInteger, ByRef dwOutStatus As UInteger, ByRef dwAxisStatus As UInteger) As Integer
    Public Declare Function FAS_GetMotionStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lPosErr As Integer, ByRef lActVel As Integer, ByRef wPosItemNo As UShort) As Integer
    Public Declare Function FAS_GetAllStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwInStatus As UInteger, ByRef dwOutStatus As UInteger, ByRef dwAxisStatus As UInteger, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lPosErr As Integer, ByRef lActVel As Integer, ByRef wPosItemNo As UShort) As Integer
    Public Declare Function FAS_SetCommandPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lCmdPos As Integer) As Integer
    Public Declare Function FAS_SetActualPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lActPos As Integer) As Integer
    Public Declare Function FAS_ClearPosition Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_GetCommandPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSalveNo As Byte, ByRef lCmdPos As Integer) As Integer
    Public Declare Function FAS_GetActualPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lActPos As Integer) As Integer
    Public Declare Function FAS_GetPosError Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lPosErr As Integer) As Integer
    Public Declare Function FAS_GetActualVel Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lActVel As Integer) As Integer
    Public Declare Function FAS_GetAlarmType Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef nAlarmType As Byte) As Integer
    Public Declare Function FAS_GetAllTorqueStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwInStatus As UInteger, ByRef dwOutStatus As UInteger, ByRef dwAxisStatus As UInteger, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lPosErr As Integer, ByRef wPosItemNo As UShort, ByRef wTorqueValue As UShort) As Integer
    Public Declare Function FAS_GetTorqueStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef wTorqueValue As UShort) As Integer
    Public Declare Function FAS_MoveStop Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_EmergencyStop Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_MovePause Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bPause As Boolean) As Integer
    Public Declare Function FAS_MoveOriginSingleAxis Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_MoveSingleAxisAbsPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lAbsPos As Integer, ByVal lVelocity As UInteger) As Integer
    Public Declare Function FAS_MoveSingleAxisIncPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lIncPos As Integer, ByVal lVelocity As UInteger) As Integer
    Public Declare Function FAS_MoveToLimit Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger, ByVal iLimitDir As Integer) As Integer
    Public Declare Function FAS_MoveVelocity Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger, ByVal iVelDir As Integer) As Integer
    Public Declare Function FAS_PositionAbsOverride Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lOverridePos As Integer) As Integer
    Public Declare Function FAS_PositionIncOverride Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lOverridePos As Integer) As Integer
    Public Declare Function FAS_VelocityOverride Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger) As Integer
    Public Declare Function FAS_MoveLinearAbsPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal nNoOfSlaves As Byte, ByRef iSlaveNo As Byte, ByRef lAbsPos As Integer, ByVal lFeedrate As UInteger, ByVal wAccelTime As UShort) As Integer
    Public Declare Function FAS_MoveLinearIncPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal nNoOfSlaves As Byte, ByRef iSlaveNo As Byte, ByRef lIncPos As Integer, ByVal lFeedrate As UInteger, ByVal wAccelTime As UShort) As Integer
    Public Declare Function FAS_TriggerOutput_RunA Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bStartTrigger As Boolean, ByVal lStartPos As Integer, ByVal dwPeriod As UInteger, ByVal dwPulseTime As UInteger) As Integer
    Public Declare Function FAS_TriggerOutput_Status Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSalveNo As Byte, ByRef bTriggerStatus As Byte) As Integer
    Public Declare Function FAS_MovePush Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwStartSpd As UInteger, ByVal dwMoveSpd As UInteger, ByVal lPosition As Integer, ByVal wAccel As UShort, ByVal wDecel As UShort, ByVal wPushRate As UShort, ByVal dwPushSpd As UInteger, ByVal lEndPosition As Integer, ByVal wPushMdoe As UShort) As Integer
    Public Declare Function FAS_GetPushStatus Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef nPushStatus As Byte) As Integer

    'FAPI int WINAPI	FAS_MoveSingleAxisAbsPosEx(BYTE nPortNo, BYTE iSlaveNo, long lAbsPos, DWORD lVelocity, MOTION_OPTION_EX* lpExOption);
    'FAPI int WINAPI	FAS_MoveSingleAxisIncPosEx(BYTE nPortNo, BYTE iSlaveNo, long lIncPos, DWORD lVelocity, MOTION_OPTION_EX* lpExOption);
    'FAPI int WINAPI	FAS_MoveVelocityEx(BYTE nPortNo, BYTE iSlaveNo, DWORD lVelocity, int iVelDir, VELOCITY_OPTION_EX* lpExOption);

    Public Declare Function FAS_AllMoveStop Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_AllEmergencyStop Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_AllMoveOriginSingleAxis Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_AllMoveSingleAxisAbsPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lAbsPos As Integer, ByVal lVelocity As UInteger) As Integer
    Public Declare Function FAS_AllMoveSingleAxisIncPos Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lIncPos As Integer, ByVal lVelociy As UInteger) As Integer
    Public Declare Function FAS_PosTableReadItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal lPItem As CDevEZISERVOPLUSR.sLPITEM_NODE) As Integer
    Public Declare Function FAS_PosTableWriteItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal lPItem As CDevEZISERVOPLUSR.sLPITEM_NODE) As Integer
    Public Declare Function FAS_PosTableWriteROM Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_PosTableReadROM Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_PosTableRunItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort) As Integer
    Public Declare Function FAS_PosTableReadOneItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal wOffset As UShort, ByRef lPosItemVal As Integer) As Integer
    Public Declare Function FAS_PosTableWriteOneItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal wOffset As UShort, ByVal lPosItemVal As Integer) As Integer
    Public Declare Function FAS_PosTableSingleRunItem Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bNextMove As Boolean, ByVal wItemNo As UShort) As Integer
    Public Declare Function FAS_GapControlEnable Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal lGapCompSpeed As Integer, ByVal lGapAccTime As Integer, ByVal lGapDecTime As Integer, ByVal lGapStartSpeed As Integer) As Integer
    Public Declare Function FAS_GapControlDisable Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer
    Public Declare Function FAS_IsGapControlEnable Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef bIsEnable As Boolean, ByRef wCurrentItemNo As UShort) As Integer
    Public Declare Function FAS_GapControlGetADCValue Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lADCValue As Integer) As Integer
    Public Declare Function FAS_GapOneResultMonitor Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef bUpdated As Byte, ByRef iIndex As Integer, ByRef lGapValue As Integer, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lCompValue As Integer, ByRef lReserved As Integer) As Integer
    Public Declare Function FAS_GetAlarmLogs Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef pAlarmLog As CDevEZISERVOPLUSR.sAlarmLog) As Integer
    Public Declare Function FAS_ResetAlarmLogs Lib "DLL\EziMOTIONPlusR.dll" (ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Integer

   
End Module
