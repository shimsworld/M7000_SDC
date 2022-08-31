Imports System.Threading
Imports ActProgTypeLib
Imports ActUtlTypeLib

'//////////////////////////////////
' BRate : 19200
' Data Bit : 8
' Stop Bit : 0
' Parity : Odd
' rcv / Send Termination 필요 없음
'//////////////////////////////////

Public Class CDevPLC_MITSUBISHI
    Inherits CDevPLCCommonNode

#Region "Define"

    Public Const UNIT_QNUSB As Short = &H16S
    Public Const PROTOCOL_USB As Short = &HDS

    'Serial 
    Public Const UNIT_SERIAL As Short = &H19S
    Public Const UNIT_ETHERNET As Short = &H1AS
    Public Const PROTOCOL_SERIAL As Short = &H4S
    Public Const PROTOCOL_TCPIP As Short = &H5S

    Dim ActProgType As New ActProgType
    Dim ActUtlType As New ActUtlType
    Dim measQueue As New Queue

    Private myParent As frmMain
    Private m_CommType As eType
    Private m_LogicNo As Integer

    Dim m_bIsRequest As Boolean = False

    Const CommRetryCount As Integer = 5
    '정현기 수정 2022.08.28
    '===================================================================================================================================

    'GET
    Const PLCCOMMAND_SYSTEM_STATE_CHK As String = "B1000"    'POWER ON, POWER DOWN, TEACH MODE , AUTO MODE, MANUAL MODE , PROCESSING
    Const PLCCOMMAND_SYSTEM_ALIVE As String = "B1010"
    Const PLCCOMMAND_ALARAM_CHK As String = "B1020"  '알람 조회 (Light ALARAM, HEAVY ALAEAM)
    Const PLCCOMMAND_EQP_STATE_CHK As String = "B1030"   '실험 상태 조회 (RUN, STOP ,PASUE)FV
    Const PLCCOMMAND_PLC_MANUAL_MODE_CHK As String = "B1040" 'PLC 수동조작 모드 체크
    Const PLCCOMMAND_MOTER_MOVING_CHK As String = " B1050" 'Motor Moving CHECK
    'Const PLCCOMMAND_LD_SLOT_CHK As String = "B1060" 'LD 슬롯 상태 확인 0번은 C/V 슬롯 1부터 1 ~ 12까지 사용 가능
    'Const PLCCOMMAND_ULD_SLOT_CHK As String = "B1070" 'ULD 슬롯 상태 확인 0번은 C/V 슬롯, 1부터  1~12 까지 사용 가능
    'Const PLCCOMMAND_EQP_DETECT_CHK As String = "B108" '제품감지ㅋ
    Const PLCCOMMAND_SERVO_STATUS_CHK As String = "B10A0"    'Servo 상태 체크 (X축, Y축,Z축)
    Const PLCCOMMAND_AXIS_ALARAM_STATUS_CHK As String = "B10B0"  '축 알람 체크 (X축, Y축,Z축)
    'Const PLCCOMMAND_LD_MOVE_CHK As String = "B10C0" 'LD 이동 가능 상태 확인
    'Const PLCCOMMAND_ULD_MOVE_CHK As String = "B10D0" 'ULD 이동 가능 상태 확인
    Const PLCCOMMAND_MODE_CHANGE_CONDITION_CHK As String = "B10E0" '수동, 자동 모드 변경 전환 조건 체크
    Const PLCCOMMAND_ALL_RESET_CURRENT_CHK As String = "B10F0"    '전체 초기화 상태 체크(현재 상태 체크)

    '===================================================================================================================================

    'SET
    Const PLCCOMMAND_SET_MODE As String = "B2000" '수동모드, 자동모드 전환
    Const PLCCOMMAND_CONNECT_STATE_CHK As String = "B2010"   '연결 상태 조회
    Const PLCCOMMAND_PC_READY As String = "B2020"   '소프트웨어 Run
    Const PLCCOMMAND_SET_EQP_STATE As String = "B2030"   '실험 상태 설정 (RUN, STOP, PAUSE)
    Const PLCCOMMAND_SET_PC_MANUAL_MODE As String = "B2040"  'PC 수동조작 모드 설정
    Const PLCCOMMAND_SET_ERROR_RESET As String = "B20F0" 'Error Reset

    '===================================================================================================================================

    ''GET
    'Const PLCCOMMAND_MANUAL_MODE_CHK As String = "B1100"  '수동운전 가능 상태 조회 (0번 가능여부, 1번 ACK)
    'Const PLCCOMMAND_JOG_X_MOVE_CHK As String = "B1120"   'X축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_Y_MOVE_CHK As String = "B1110"   'Y축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_Z_MOVE_CHK As String = "B1130"   'Z축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_HITTING_MOVE_CHK As String = "B1140"   'HITTING축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_LD_MOVE_CHK As String = "B1150"   'LD축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_ULD_MOVE_CHK As String = "B1160"   'ULD축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_X_STATE_CHK As String = "B11B0" 'X축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_Y_STATE_CHK As String = "B11A0" 'Y축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_Z_STATE_CHK As String = "B11C0" 'Z축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_ALL_RESET_CHK As String = "B11D0" '전체 초기화 가능 여부 조회 (0번 가능여부, 1번 ACK)
    'Const PLCCOMMAND_SUPPLY_CHK As String = "B11E0" '투입 연속 동작 가능 여부 조회 (0번 가능여부, 1번 ACK)
    'Const PLCCOMMAND_EXHAUST_CHK As String = "B11F0" '배출 연속 동작 가능 여부 조회 (0번 가능여부, 1번 ACK)


    'Get
    Const PLCCOMMAND_MANUAL_MODE_CHK As String = "B1100"  '수동운전 가능 상태 조회 (0번 가능여부, 1번 ACK)
    Const PLCCOMMAND_JOG_X_MOVE_CHK As String = "B1110"   'X축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    Const PLCCOMMAND_JOG_Y_MOVE_CHK As String = "B1120"   'Y축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    Const PLCCOMMAND_JOG_Z_MOVE_CHK As String = "B1130"   'Z축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_THETA1_MOVE_CHK As String = "B1140"   'THETA1축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_THETA2_MOVE_CHK As String = "B1150"   'THETA2축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_THETA3_MOVE_CHK As String = "B1160"   'THETA3축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_JOG_THETA4_MOVE_CHK As String = "B1170"   'THETA4축 조그 운전 가능 여부 조회 (0번 가능여부, 1번 BUSY)
    'Const PLCCOMMAND_Y_STATE_CHK As String = "B1190"
    Const PLCCOMMAND_X_STATE_CHK As String = "B11A0"  'X축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    Const PLCCOMMAND_Y_STATE_CHK As String = "B11B0" 'Y축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    Const PLCCOMMAND_Z_STATE_CHK As String = "B11C0" 'Z축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)

    '정현기 
    Const PLCCOMMAND_X_STATE_ACK As String = "B11A1"  'X축 위치명령 ACK (0번 가능여부, 1번 ACK, 2번 위치 완료)
    Const PLCCOMMAND_Y_STATE_ACK As String = "B11B1" 'Y축 위치명령 ACK (0번 가능여부, 1번 ACK, 2번 위치 완료)
    Const PLCCOMMAND_Z_STATE_ACK As String = "B11C1" 'Z축 위치명령 ACK (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_THETA3_STATE_CHK As String = "B11D0"
    'Const PLCCOMMAND_THETA4_STATE_CHK As String = "B11E0"
    Const PLCCOMMAND_ALL_RESET_CHK As String = "B11F0" '전체 초기화 가능
    Const PLCCOMMAND_ALL_RESET_ACK As String = "B11F1" '전체 초기화 ACK
    'Const PLCCOMMAND_X_STATE_CHK As String = "B11B0" 'X축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_Y_STATE_CHK As String = "B11A0" 'Y축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_Z_STATE_CHK As String = "B11C0" 'Z축 이동 가능 여부 조회 (0번 가능여부, 1번 ACK, 2번 위치 완료)
    'Const PLCCOMMAND_ALL_RESET_CHK As String = "B11D0" '전체 초기화 가능 여부 조회 (0번 가능여부, 1번 ACK)
    'Const PLCCOMMAND_SUPPLY_CHK As String = "B11E0" '투입 연속 동작 가능 여부 조회 (0번 가능여부, 1번 ACK)
    'Const PLCCOMMAND_EXHAUST_CHK As String = "B11F0" '배출 연속 동작 가능 여부 조회 (0번 가능여부, 1번 ACK)
    '===================================================================================================================================

    'SET
    'Const PLCCOMMAND_MANUAL_MODE_REQUEST As String = "B2100" '수동운전 설정 REQUEST
    'Const PLCCOMMAND_JOG_X_MOVE As String = "B2120"    'X축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_Y_MOVE As String = "B2110"    'Y축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_Z_MOVE As String = "B2130"    'Z축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_HITTING_MOVE As String = "B2140"    'HITTING축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_LD_MOVE As String = "B2150"    'LD축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_ULD_MOVE As String = "B2160"    'ULD축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_X_MOVE_REQUEST As String = "B21B0"  'X축 이동 설정 REQUEST
    'Const PLCCOMMAND_Y_MOVE_REQUEST As String = "B21A0"  'Y축 이동 설정 REQUEST
    'Const PLCCOMMAND_Z_MOVE_REQUEST As String = "B21C0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_ALL_RESET_REQUSET As String = "B21D0"   '전체 초기화 설정 REQUEST (BIT0)
    'Const PLCCOMMAND_SUPPLY_REQUEST As String = "B21E0"  '투입 연속 동작 설정 REQUEST (BIT0)
    'Const PLCCOMMAND_EXHAUST_REQUEST As String = "B21F0" '배출 연속 동작 설정 REQUEST (BIT5)

    Const PLCCOMMAND_MANUAL_MODE_REQUEST As String = "B2100" '수동운전 설정 REQUEST
    Const PLCCOMMAND_JOG_X_MOVE As String = "B2110"    'X축 조그 운전 설정 (0번 +, 1번 -)
    Const PLCCOMMAND_JOG_Y_MOVE As String = "B2120"    'Y축 조그 운전 설정 (0번 +, 1번 -)
    Const PLCCOMMAND_JOG_Z_MOVE As String = "B2130"    'Z축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_THETA1_MOVE As String = "B2140"    'Z축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_THETA2_MOVE As String = "B2150"    'HITTING축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_THETA3_MOVE As String = "B2160"    'LD축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_JOG_THETA4_MOVE As String = "B2170"    'ULD축 조그 운전 설정 (0번 +, 1번 -)
    'Const PLCCOMMAND_Y_MOVE_REQUEST As String = "B2190"  'X축 이동 설정 REQUEST
    Const PLCCOMMAND_X_MOVE_REQUEST As String = "B21A0"  'Y축 이동 설정 REQUEST
    Const PLCCOMMAND_Y_MOVE_REQUEST As String = "B21B0"  'Y축 이동 설정 REQUEST
    Const PLCCOMMAND_Z_MOVE_REQUEST As String = "B21C0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_THETA1_MOVE_REQUEST As String = "B21B0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_THETA2_MOVE_REQUEST As String = "B21C0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_THETA3_MOVE_REQUEST As String = "B21D0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_THETA4_MOVE_REQUEST As String = "B21E0"  'Z축 이동 설정 REQUEST
    'Const PLCCOMMAND_ALL_RESET_REQUSET As String = "B21D0"   '전체 초기화 설정 REQUEST (BIT0)
    'Const PLCCOMMAND_SUPPLY_REQUEST As String = "B21E0"  '투입 연속 동작 설정 REQUEST (BIT0)
    Const PLCCOMMAND_ALL_RESET_REQUSET As String = "B21F0" '배출 연속 동작 설정 REQUEST (BIT5)
    '===================================================================================================================================

    ''GET
    'Const PLCCOMMAND_CURRENT_X_POSITION As String = "W11B0"  'X축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_Y_POSITION As String = "W11A0"  'Y축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_Z_POSITION As String = "W11C0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_ALL_RESET_STATUS_CHK As String = "W11D0"   '전체 초기화 STATUS 조회 (0)
    'Const PLCCOMMAND_SUPPLY_STATUS_CHK As String = "W11E0" '투입 연속 동작 STATUS 조회 (0)
    'Const PLCCOMMAND_EXHAUST_STATUS_CHK As String = "W11F0" '배출 연속 동작 STATUS 조회 (0)
    'GET
    Const PLCCOMMAND_CURRENT_X_POSITION As String = "W11A0"  'X축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_CURRENT_Y1_POSITION As String = "W11B0"  'Y1축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_CURRENT_Y2_POSITION As String = "W11B2"  'Y2축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_CURRENT_Z_POSITION As String = "W11C0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_THETA1_POSITION As String = "W11B0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_THETA2_POSITION As String = "W11C0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_THETA3_POSITION As String = "W11D0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_CURRENT_THETA4_POSITION As String = "W11E0"  'Z축 현재 위치 조회 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_ALL_RESET_STATUS_CHK As String = "W11F0"   '전체 초기화 STATUS 조회 (0)

    '===================================================================================================================================

    'SET
    Const PLCCOMMAND_JOG_X_SPEED_SET As String = "W2110"  'X축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_JOG_Y_SPEED_SET As String = "W2120"  'Y축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    Const PLCCOMMAND_JOG_Z_SPEED_SET As String = "W2130" 'Z축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_THETA_SPEED_SET As String = "W2120" 'THETA축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)

    Const PLCCOMMAND_X_POSITION_METHOD_SET As String = "W2160" 'X축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    Const PLCCOMMAND_X_MOVING_METHOD_SET As String = "W2161" 'X축 위치 결정 코드 (1 = ABS , 2 =INC )
    Const PLCCOMMAND_Y_POSITION_METHOD_SET As String = "W2170" 'Y축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    Const PLCCOMMAND_Y_MOVING_METHOD_SET As String = "W2171" 'Y축 위치 결정 코드 (1 = ABS , 2 =INC )
    Const PLCCOMMAND_Z_POSITION_METHOD_SET As String = "W2180" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    Const PLCCOMMAND_Z_MOVING_METHOD_SET As String = "W2181" 'Z축 위치 결정 코드 (1 = ABS , 2 =INC )

    'Const PLCCOMMAND_THETA1_POSITION_METHOD_SET As String = "W2160" 'Z축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_THETA1_MOVING_METHOD_SET As String = "W2161" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_THETA2_POSITION_METHOD_SET As String = "W2170" 'Z축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_THETA2_MOVING_METHOD_SET As String = "W2171" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_THETA3_POSITION_METHOD_SET As String = "W2180" 'Z축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_THETA3_MOVING_METHOD_SET As String = "W2181" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_THETA4_POSITION_METHOD_SET As String = "W2190" 'Z축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_THETA4_MOVING_METHOD_SET As String = "W2191" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))

    Const PLCCOMMAND_X_MOVE_SPEED_SET As String = "W21B0"   'X축 설정 (위치 ,속도), 속도(0,1), 위치(2,3)
    Const PLCCOMMAND_Y_MOVE_SPEED_SET As String = "W21C0"   'Y축 설정 (위치 ,속도), 속도(0,1), 위치(2,3)
    Const PLCCOMMAND_Z_MOVE_SPEED_SET As String = "W21D0"   'Z축 설정 (위치, 속도), 속도(0,1), 위치(2,3)

    Const PLCCOMMAND_X_MOVE_POSITION_SET As String = "W21B2"   'X축 설정 (위치 ,속도), 속도(0,1), 위치(2,3)
    Const PLCCOMMAND_Y_MOVE_POSITION_SET As String = "W21C2"   'Y축 설정 (위치 ,속도), 속도(0,1), 위치(2,3)
    Const PLCCOMMAND_Z_MOVE_POSITION_SET As String = "W21D2"   'Z축 설정 (위치, 속도), 속도(0,1), 위치(2,3)

    'Const PLCCOMMAND_THETA1_MOVE_SPEED_SET As String = "W21C0"   'THETA1축 설정 (위치, 속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_THETA2_MOVE_SPEED_SET As String = "W21D0"   'THETA2축 설정 (위치, 속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_THETA3_MOVE_SPEED_SET As String = "W21E0"   'THETA3축 설정 (위치, 속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_THETA4_MOVE_SPEED_SET As String = "W21F0"   'THETA4축 설정 (위치, 속도), 속도(0,1), 위치(2,3)

    'Const PLCCOMMAND_Y_MOVE_POSITION_SET As String = "W21A2"    'Y축 위치 설정 (2,3)
    'Const PLCCOMMAND_Z_MOVE_POSITION_SET As String = "W21B2"    'X축 위치 설정 (2,3)
    'Const PLCCOMMAND_THETA1_MOVE_POSITION_SET As String = "W21C2"    'Z축 위치 설정 (2,3)
    'Const PLCCOMMAND_THETA2_MOVE_POSITION_SET As String = "W21D2"    'Z축 위치 설정 (2,3)
    'Const PLCCOMMAND_THETA3_MOVE_POSITION_SET As String = "W21E2"    'Z축 위치 설정 (2,3)
    'Const PLCCOMMAND_THETA4_MOVE_POSITION_SET As String = "W21F2"    'Z축 위치 설정 (2,3)

    ''SET
    'Const PLCCOMMAND_MANUAL_MODE_COMMAND_NO_SET As String = "W2100"  '수동운전 COMMAND NO.(0) , LD슬롯 NO(1), ULD슬롯(2)
    'Const PLCCOMMAND_LD_SLOT_NUMBER As String = "W2101" 'LD SLOT 번호 지정
    'Const PLCCOMMAND_ULD_SLOT_NUMBER As String = "W2102"    'ULD SLOT 번호 지정
    'Const PLCCOMMAND_JOG_X_SPEED_SET As String = "W2120" 'X축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_Y_SPEED_SET As String = "W2110" 'Y축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_Z_SPEED_SET As String = "W2130" 'Z축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_HITTING_SPEED_SET As String = "W2140" 'HITTING축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_LD_SPEED_SET As String = "W2150" 'LD축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_JOG_ULD_SPEED_SET As String = "W2160" 'ULD축 조그 운전 속도 설정 (0, 1 2WORD(4BYTE) 사용)
    'Const PLCCOMMAND_X_POSITION_METHOD_SET As String = "W2180" 'X축 위치 명령 코드(HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_X_MOVING_METHOD_SET As String = "W2181"  'X축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_Y_POSITION_METHOD_SET As String = "W2170" 'Y축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_Y_MOVING_METHOD_SET As String = "W2171"    'Y축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_Z_POSITION_METHOD_SET As String = "W2190" 'Z축 위치 명령 및 결정(제어명령코드 (HOME = 1, POSITION =2), 위치결정코드 (1=ABS, 2=INC))
    'Const PLCCOMMAND_Z_MOVING_METHOD_SET As String = "W2191"    'Z축 위치 결정 코드 (1 = ABS , 2 =INC )
    'Const PLCCOMMAND_X_MOVE_SPEED_SET As String = "W21B0"   'X축 설정 (위치 ,속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_Y_MOVE_SPEED_SET As String = "W21A0"   'Y축 설정 (위치, 속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_Z_MOVE_SPEED_SET As String = "W21C0"   'Z축 설정 (위치, 속도), 속도(0,1), 위치(2,3)
    'Const PLCCOMMAND_X_MOVE_POSITION_SET As String = "W21B2"    'X축 위치 설정 (2,3)
    'Const PLCCOMMAND_Y_MOVE_POSITION_SET As String = "W21A2"    'Y축 위치 설정 (2,3)
    'Const PLCCOMMAND_Z_MOVE_POSITION_SET As String = "W21C2"    'Z축 위치 설정 (2,3)
    'Const PLCCOMMAND_SUPPLY_SLOT_NO_SET As String = "W21E0"  '투입 연속 동작 SLOT NO.
    'Const PLCCOMMAND_EXHAUST_SLOT_NO_SET As String = "W21F0" '배출 연속 동작 SLOT NO.

    '===================================================================================================================================

    'ALARM
    '정현기 경알람
    Const PLCCOMMAND_ALARM_WEAK1 As String = "D9148"
    Const PLCCOMMAND_ALARM_WEAK2 As String = "D9149"
    '정현기 중알람
    Const PLCCOMMAND_ALARM_EMS As String = "D9200"
    '0(EMS), 4(세이프티 컨트롤러-1 알람), 5(세이프티 컨트롤러-2 알람), 8(구동부메인 M/C1 Power OFF), 9(구동부메인 M/C2 Power OFF)
    'A(컨트롤박스 내부 온도알람) , B(컨트롤박스 연기감지 센서)

    Const PLCCOMMAND_ALARM_STRANGETEMP As String = "D9201"     '1~4 (히터유닛 1~4 온도 이상)
    '정현기(알람 어디다가 추가해야할까...?)
    Const PLCCOMMAND_ALARM_EOCRTEMP As String = "D9202"     '1-4 (히터유닛 1~4 EOCR 상태 이상)
    Const PLCCOMMAND_ALARM_SSRTEMP As String = "D9203"      '1~4 (히터유닛 1~4 SSR 80도 알람)
    Const PLCCOMMAND_ALARM_SSRTEMP2 As String = "D9204"      '1~4 (히터유닛 1~4 SSR 60도 알람)
    Const PLCCOMMAND_ALARM_TEMPSENSOR1 As String = "D9205"   '(히터온도 센서 1~4 - 1 과온 알람)
    Const PLCCOMMAND_ALARM_TEMPSENSOR2 As String = "D9206"   '(히터온도 센서 1~4 - 2 과온 알람)
    Const PLCCOMMAND_ALARM_DOOROPEN As String = "D9208"     '도어오픈에러 0(세이프티 도어루프 에러), 1(로더세이프티 개방), 2(암실 좌측 세이프티 개방)
    Const PLCCOMMAND_ALARM_Y1_AXIS As String = "D9210" 'Y1 서보 알람
    ' 0 : [Ax.01] IVL-Y1 축 알람
    ' 1 : [Ax.01] IVL-Y1 서보 알람
    ' 2 : [Ax.01] IVL-Y1 RLS 리밋센서 알람
    ' 3 : [Ax.01] IVL-Y1 FLS 리밋센서 알람
    ' 4 : [Ax.01] IVL-Y1 충돌감지 알람
    ' 5 : [Ax.01] IVL-Y1 원점운전 타임아웃
    ' 6 : [Ax.01] IVL-Y1 위치운전 타임아웃
    ' 7 : [Ax.01] IVL-Y1 AMP 과온 알람
    ' 8 : [Ax.01] IVL-Y1 과전류 알람
    ' A : [Ax.01] IVL-Y 동기축 위치편차 알람
    Const PLCCOMMAND_ALARM_Y2_AXIS As String = "D9211" 'Y2 서보 알람
    ' 0 : [Ax.02] IVL-Y2 축 알람
    ' 1 : [Ax.02] IVL-Y2 서보 알람
    ' 2 : [Ax.02] IVL-Y2 RLS 리밋센서 알람
    ' 3 : [Ax.02] IVL-Y2 FLS 리밋센서 알람
    ' 4 : [Ax.01] IVL-Y2 충돌감지 알람
    ' 5 : [Ax.02] IVL-Y2 원점운전 타임아웃
    ' 6 : [Ax.02] IVL-Y2 위치운전 타임아웃
    ' 7 : [Ax.02] IVL-Y2 AMP 과온 알람
    ' 8 : [Ax.02] IVL-Y2 과전류 알람
    Const PLCCOMMAND_ALARM_X_AXIS As String = "D9212" 'X 서보 알람
    ' 0 : [Ax.03] IVL-X 축 알람
    ' 1 : [Ax.03] IVL-X 서보 알람
    ' 2 : [Ax.03] IVL-X RLS 리밋센서 알람
    ' 3 : [Ax.03] IVL-X FLS 리밋센서 알람
    ' 4 : [Ax.03] IVL-X 충돌감지 알람
    ' 5 : [Ax.03] IVL-X 원점운전 타임아웃
    ' 6 : [Ax.03] IVL-X 위치운전 타임아웃
    ' 7 : [Ax.03] IVL-X AMP 과온 알람
    ' 8 : [Ax.03] IVL-X 과전류 알람
    Const PLCCOMMAND_ALARM_Z_AXIS As String = "D9213" 'Z 서보 알람
    ' 0 : [Ax.04] IVL-Z 축 알람
    ' 1 : [Ax.04] IVL-Z 서보 알람
    ' 2 : [Ax.04] IVL-Z RLS 리밋센서 알람
    ' 3 : [Ax.04] IVL-Z FLS 리밋센서 알람
    ' 4 : [Ax.04] IVL-Z 충돌감지 알람
    ' 5 : [Ax.04] IVL-Z 원점운전 타임아웃
    ' 6 : [Ax.04] IVL-Z 위치운전 타임아웃
    ' 7 : [Ax.04] IVL-Z AMP 과온 알람
    ' 8 : [Ax.04] IVL-Z 과전류 알람



    'Const PLCCOMMAND_ALARM_HITTER_AXIS As String = "D9220"  '7 (히터 AMP 과온알람), 8(히터 과전류 알람)
    'Const PLCCOMMAND_ALARM_X_AXIS As String = "D9230" ' 7 (X AMP 과온알람), 8(X 과전류 알람)
    'Const PLCCOMMAND_ALARM_Y_AXIS As String = "D9231"   '7 (Y AMP 과온알람) , 8(Y 과전류 알람)
    'Const PLCCOMMAND_ALARM_Z_AXIS As String = "D9232"   '7 (Z AMP 과온알람) , 8(Z 과전류 알람)
    'Const PLCCOMMAND_ALARM_THETA1_AXIS As String = "D9233"
    'Const PLCCOMMAND_ALARM_THETA2_AXIS As String = "D9234"
    'Const PLCCOMMAND_ALARM_THETA3_AXIS As String = "D9235"
    'Const PLCCOMMAND_ALARM_THETA4_AXIS As String = "D9236"
    ' Const PLCCOMMAND_ALARM_UNLOADER_AXIS As String = "D9240"    '7(언로더 AMP 과온알람), 8(언로더 과전류 알람)

    '===================================================================================================================================
    Const ERROR_RESET As Short = 6
    Const EQE_RUN_REQUEST As Short = 1
    Const EQE_STOP_REQUEST As Short = 2
    Const EQE_PAUSE_REQUEST As Short = 4
    Const EQE_RESET_REQUEST As Short = 0

    Const X_MOVING_COMPLETE_ACK As Short = 2
    Const Y_MOVING_COMPLETE_ACK As Short = 2
    Const Z_MOVING_COMPLETE_ACK As Short = 2
    Const THETA1_MOVING_COMPLETE_ACK As Short = 2
    Const THETA2_MOVING_COMPLETE_ACK As Short = 2
    Const THETA3_MOVING_COMPLETE_ACK As Short = 2
    Const THETA4_MOVING_COMPLETE_ACK As Short = 2
#End Region

#Region "Enum"

    Public Enum eType
        _Utl
        _Prog
    End Enum

#End Region

#Region "Propertys"

    Public Overrides Property ComType As eType
        Get
            Return m_CommType
        End Get
        Set(ByVal value As eType)
            m_CommType = value
        End Set
    End Property

    Public Overrides Property LoginNo As Integer
        Get
            Return m_LogicNo
        End Get
        Set(ByVal value As Integer)
            m_LogicNo = value
        End Set
    End Property

#End Region

#Region "Creator and Dispose"

    Public Sub New(ByVal fmain As frmMain, ByVal nTotAxisNumber As Integer)

        myParent = fmain
        m_MyModel = eModel.MITSUBISHI

        m_nTotalAxis = nTotAxisNumber

        With m_sSignalInfo
            '.sStatusCaptions = New String() {"Down", "IDEL", "PROCESS", "Maintenance", "Alarm", "Reserved01", "SafetyMode_Auto", "SafetyMode_Teach ", "Pause", "PauseAndIDEL", "PauseAndProcess"}
            .sStatusCaptions = New String() {"Power On", "Power Down", "Teaching Mode", "Auto Mode", "Manual Mode", "Processing"}
            .nStatusValues = New Integer() {0, 1, 2, 3, 4, 5, 6, 10}
            .nEQPStatusCaption = New String() {"RUN", "STOP", "PAUSE"}
            ' .sStatusCaptions = New String() {"Down", "IDEL", "PROCESS", "Maintenance", "Alarm", "Reserved01", "SafetyMode_Auto", "SafetyMode_Teach ", "Pause", "PauseAndIDEL", "PauseAndProcess"}
            '  .nStatusValues = New Integer() {0, 1, 2, 4, 8, 10, 32, 64, 80, 81, 82}

            '  .sAlarmCations = New String() {"No Error", "Emergency", "Fire", "Heater", "Current Limit", "Interrock", "Cylinder", "DoorOpen", "Supply", "InspectionStage", "Ehaxus"}
            .sAlarmCations = New String() {"EQP Light Alaram", "EQP Heavy Alaram"}
            .nAlarmValues = New Integer() {2, 3}
            .sOutputCaptions = New String() {"All OFF", "RED", "YELLOW", "GREEN", "BLUE", "Reserved01", "Reserved02", "Reserved03", "Reserved04"}
            .nOutputValues = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}

            .sMagazineInfos.sSupply.sSlotCaption = New String() {"None", "Slot01", "Slot02", "Slot03", "Slot04", "Slot05", "Slot06", "Slot07", "Slot08", "Slot09", "Slot10"}
            .sMagazineInfos.sSupply.nSlotValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
            .sMagazineInfos.sSupply.sPositionCaption = New String() {"None", "Slot01", "Slot02", "Slot03", "Slot04", "Slot05", "Slot06", "Slot07", "Slot08", "Slot09", "Slot10"}
            .sMagazineInfos.sSupply.nPositionValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
            .sMagazineInfos.sSupply.sStatusCaption = New String() {"IDEL", "Ready", "Scan", "Scan End", "Up", "Down", "Ready End", "Start", "Proceeding", "End", "Busy", "UpDown End", "Home", "Home End"}
            .sMagazineInfos.sSupply.nStatusValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096}

            .sMagazineInfos.sExhaus.sSlotCaption = New String() {"None", "Slot01", "Slot02", "Slot03", "Slot04", "Slot05", "Slot06", "Slot07", "Slot08", "Slot09", "Slot10"}
            .sMagazineInfos.sExhaus.nSlotValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
            .sMagazineInfos.sExhaus.sPositionCaption = New String() {"None", "Slot01", "Slot02", "Slot03", "Slot04", "Slot05", "Slot06", "Slot07", "Slot08", "Slot09", "Slot10"}
            .sMagazineInfos.sExhaus.nPositionValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
            .sMagazineInfos.sExhaus.sStatusCaption = New String() {"IDEL", "Ready", "Scan", "Scan End", "Up", "Down", "Ready End", "Start", "Proceeding", "End", "Busy", "UpDown End", "Home", "Home End"}
            .sMagazineInfos.sExhaus.nStatusValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096}

            .sMagazineInfos.sContact.sContactIspectionStatusCaption = New String() {"IDEL", "Detection", "Reset", "Meas Ready End", "Error", "Reserved01", "Reserved02", "Reserved03", "Reserved04"}
            .sMagazineInfos.sContact.nContactIspectionStatusValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}

            '  .sMagazineInfos.sError.sErrorStatusCaption = New String() {"NoError", "Supply Move", "Exhaus Move", "Reserved01", "Reserved02", "Reserved03", "Reserved04", "Reserved05", "Reserved06", "Reserved07", "Reserved08"}
            '  .sMagazineInfos.sError.nErrorStatusValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}

            '   .sMagazineInfos.sError.sErrorStatusCaption = New String() {"NoError", "Reserved01", "Reserved02", "Reserved03", "Reserved04", "Reserved05", "Reserved06", "Reserved07", "Reserved08", "Reserved09", "Reserved10", _
            '              "Reserved11", "Reserved12", "Reserved13", "Reserved014", "Reserved15", "Reserved16", "Reserved17", "Reserved18", "Reserved19", "Reserved20", "Reserved21"}
            ' .sMagazineInfos.sError.nErrorStatusValue = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
        End With

    End Sub

#End Region

    Private Sub InitProgramType(ByVal config As CCommLib.CComCommonNode.sCommInfo)

        With ActProgType
            .ActUnitType = UNIT_ETHERNET
            '.ActProtocolType = PROTOCOL_SERIAL
            .ActProtocolType = PROTOCOL_TCPIP

            .ActHostAddress = CStr(config.sLanInfo.sIPAddress) '"192.168.1.10" '밖으로 뺴야함
            .ActPortNumber = 1 'CInt(config.sSerialInfo.sPortName.Substring(3, config.sSerialInfo.sPortName.Length - 3)) '1
            '.ActBaudRate = config.sSerialInfo.nBaudRate '19200
            '.ActDataBits = config.sSerialInfo.nDataBits '8
            '.ActParity = config.sSerialInfo.nParity
            '.ActStopBits = config.sSerialInfo.nStopBits
            .ActNetworkNumber = 0 '&H0S
            .ActStationNumber = 255 '255 'Default 설정 255 (0xFF)
            .ActUnitNumber = 0
            .ActConnectUnitNumber = 0
            .ActIONumber = 1023 '&H3FFS   'Defalut 설정  1023
            '.ActCpuType = &H70S     'Q03UDCPU
            .ActCpuType = &HD1S     'Q03UDVCPU (대상 CPU설정) 모델명 따라감
            .ActControl = &H8S      'DTR, RTS 모두 제어
            .ActTimeOut = 10000
            .ActSumCheck = &H0S
            .ActSourceNetworkNumber = 1
            .ActSourceStationNumber = 2
            .ActDestinationPortNumber = 5002 '&H0S
            .ActDestinationIONumber = &H0S
            .ActMultiDropChannelNumber = 0
            .ActThroughNetworkType = &H0S
            .ActIntelligentPreferenceBit = &H0S
            .ActDidPropertyBit = &H1S
            .ActDsidPropertyBit = &H1S
            .ActPacketType = &H1S
            .ActConnectWay = 0
            .ActATCommand = ""
            .ActDialNumber = ""
            .ActOutsideLineNumber = ""
            .ActCallbackNumber = ""
            .ActLineType = 0
            .ActConnectionCDWaitTime = 0
            .ActConnectionModemReportWaitTime = 0
            .ActDisconnectionCDWaitTime = 0
            .ActDisconnectionDelayTime = 0
            .ActTransmissionDelayTime = 0
            .ActATCommandResponseWaitTime = 0
            .ActPasswordCancelResponseWaitTime = 0
            .ActATCommandPasswordCancelRetryTimes = 0
            .ActCallbackCancelWaitTime = 0
            .ActCallbackDelayTime = 0
            .ActCallbackReceptionWaitingTimeOut = 0
            .ActTargetSimulator = 0
            .ActPassword = ""
            ' .ActStationNumber = 255
        End With
    End Sub

    Public Overrides Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean

        'PLC CommType Prog 타입으로 변경 시, 추가 필요
        '현재는 Utl 타입으로 통신 설정
        Dim iReturnCode As Integer              'Return code
        Dim iLogicalStationNumber As Integer    'LogicalStationNumber for ActUtlType

        Try
            If m_CommType = eType._Prog Then

                InitProgramType(config)

                iReturnCode = ActProgType.Open()
                '
            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'check the 'LogicalStationNumber'.(If succeeded, the value is gotten.)
                If GetIntValue(m_LogicNo, iLogicalStationNumber) = False Then
                    'If failed, this process is end.
                    Return False
                End If

                'Set the value of 'LogicalStationNumber' to the property.
                ActUtlType.ActLogicalStationNumber = iLogicalStationNumber

                'The Open method is executed.
                iReturnCode = ActUtlType.Open()
            End If

        Catch exception As Exception
            Return False
        End Try

        If iReturnCode <> 0 Then
            m_bIsConnected = False
            Return False
        Else
            m_bIsConnected = True
        End If

        Return True
    End Function

    Public Overrides Sub Disconnection()
        Dim iReturnCode As Integer     'Return code

        If m_bIsConnected = False Then Exit Sub

        If m_CommType = eType._Prog Then
            'When ActProgType is selected by the radio button,
            'the Close method is executed.
            iReturnCode = ActProgType.Close()

        ElseIf m_CommType = eType._Utl Then
            'When ActUtlType is selected by the radio button,
            'the Close method is executed

            iReturnCode = ActUtlType.Close()
        End If

        'When The Close method is succeeded, enable the TextBox of 'LogocalStationNumber'.
        If iReturnCode = 0 Then
            m_bIsConnected = False
        End If
    End Sub

    Public Overrides Function SetSystemStatus(ByVal state As eEQPStatus) As Boolean

        Dim REQUEST_MSG As String = Nothing

        If state = eEQPStatus.eRun Then
            REQUEST_MSG = 1
        ElseIf state = eEQPStatus.eStop Then
            REQUEST_MSG = 2
        ElseIf state = eEQPStatus.ePause Then
            REQUEST_MSG = 4
        End If


        ' If SetData(PLCCOMMAND_SET_EQP_STATE, m_sSignalInfo.nStatusValues(state)) = False Then Return False

        If SetData(PLCCOMMAND_SET_EQP_STATE, CShort(REQUEST_MSG)) = False Then Return False

        Return True
    End Function
    Public Overrides Function SetChangeMode(ByVal Mode As CDevPLCCommonNode.eRunningMode) As Boolean
        If Can_ChangeMode() = True Then
            If Mode = eRunningMode.eManual Then
                If SetData(PLCCOMMAND_SET_MODE, CShort(Mode)) = False Then Return False
            ElseIf Mode = eRunningMode.eAuto Then
                If SetData(PLCCOMMAND_SET_MODE, CShort(Mode)) = False Then Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function
    '정현기 추가
    Public Overrides Function SetSWRun_ON() As Boolean
        If SetData(PLCCOMMAND_PC_READY, CShort(1)) = False Then Return False
        Return True
    End Function
    Public Overrides Function SetSWRun_OFF() As Boolean
        If SetData(PLCCOMMAND_PC_READY, CShort(0)) = False Then Return False
        Return True
    End Function
#Region "Magazine Control"

    'Public Overrides Function GetSupplySlotStatus(ByVal state() As eSlotSignal) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_LD_SLOT_CHK, sRcvValue) = True Then

    '        If sRcvValue = "0" Then

    '            state(0) = eSlotSignal.eNone
    '            myParent.cPLC.m_PLCDatas.nSupplySlotSignal = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else
    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer
    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eSlotSignal.eSlot00
    '                        Case 1
    '                            state(nCnt) = eSlotSignal.eSlot01
    '                        Case 2
    '                            state(nCnt) = eSlotSignal.eSlot02
    '                        Case 3
    '                            state(nCnt) = eSlotSignal.eSlot03
    '                        Case 4
    '                            state(nCnt) = eSlotSignal.eSlot04
    '                        Case 5
    '                            state(nCnt) = eSlotSignal.eSlot05
    '                        Case 6
    '                            state(nCnt) = eSlotSignal.eSlot06
    '                        Case 7
    '                            state(nCnt) = eSlotSignal.eSlot07
    '                        Case 8
    '                            state(nCnt) = eSlotSignal.eSlot08
    '                        Case 9
    '                            state(nCnt) = eSlotSignal.eSlot09
    '                        Case 10
    '                            state(nCnt) = eSlotSignal.eSlot10
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nSupplySlotSignal = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    '정현기(경알람)
    Public Overrides Function GetWeak1Alarm(ByVal state() As eWeakAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_WEAK1, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eWeakAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nWeakAlarm1 = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eWeakAlarm.eError1
                            Case 1
                                state(nCnt) = eWeakAlarm.eError2
                            Case 2
                                state(nCnt) = eWeakAlarm.eError3
                            Case 3
                                state(nCnt) = eWeakAlarm.eError4
                            Case 4
                                state(nCnt) = eWeakAlarm.eError5
                            Case 5
                                state(nCnt) = eWeakAlarm.eError6
                            Case 6
                                state(nCnt) = eWeakAlarm.eError7
                            Case 7
                                state(nCnt) = eWeakAlarm.eError8
                            Case 8
                                state(nCnt) = eWeakAlarm.eError9
                            Case 9
                                state(nCnt) = eWeakAlarm.eError10
                            Case 10
                                state(nCnt) = eWeakAlarm.eError11
                            Case 11
                                state(nCnt) = eWeakAlarm.eError12
                            Case 12
                                state(nCnt) = eWeakAlarm.eError13
                            Case 13
                                state(nCnt) = eWeakAlarm.eError14
                            Case 14
                                state(nCnt) = eWeakAlarm.eError15
                            Case 15
                                state(nCnt) = eWeakAlarm.eError16
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nWeakAlarm1 = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetWeak2Alarm(ByVal state() As eWeakAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_WEAK2, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eWeakAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nWeakAlarm2 = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eWeakAlarm.eError1
                            Case 1
                                state(nCnt) = eWeakAlarm.eError2
                            Case 2
                                state(nCnt) = eWeakAlarm.eError3
                            Case 3
                                state(nCnt) = eWeakAlarm.eError4
                            Case 4
                                state(nCnt) = eWeakAlarm.eError5
                            Case 5
                                state(nCnt) = eWeakAlarm.eError6
                            Case 6
                                state(nCnt) = eWeakAlarm.eError7
                            Case 7
                                state(nCnt) = eWeakAlarm.eError8
                            Case 8
                                state(nCnt) = eWeakAlarm.eError9
                            Case 9
                                state(nCnt) = eWeakAlarm.eError10
                            Case 10
                                state(nCnt) = eWeakAlarm.eError11
                            Case 11
                                state(nCnt) = eWeakAlarm.eError12
                            Case 12
                                state(nCnt) = eWeakAlarm.eError13
                            Case 13
                                state(nCnt) = eWeakAlarm.eError14
                            Case 14
                                state(nCnt) = eWeakAlarm.eError15
                            Case 15
                                state(nCnt) = eWeakAlarm.eError16
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nWeakAlarm2 = state.Clone

            End If
        End If

        Return True
    End Function
    '정현기(중알람)
    Public Overrides Function GetEMSAlarm(ByVal state() As eEMSAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_EMS, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eEMSAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nEmsAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eEMSAlarm.eEMS1
                            'Case 1
                            '    state(nCnt) = eEMSAlarm.eEMS2
                            Case 4
                                state(nCnt) = eEMSAlarm.eSafety_Control_Alarm1
                            Case 5
                                state(nCnt) = eEMSAlarm.eSafety_Control_Alarm2
                            Case 8
                                state(nCnt) = eEMSAlarm.eMC1_POWEROFF_Alarm
                            Case 9
                                state(nCnt) = eEMSAlarm.eMC2_POWEROFF_Alarm
                            Case 10
                                state(nCnt) = eEMSAlarm.eControlBoxTempLightAlarm
                            'Case 11
                            '    state(nCnt) = eEMSAlarm.eControlBoxTempHeavyAlarm
                            Case 11
                                state(nCnt) = eEMSAlarm.eControlBoxSmokeAlarm
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nEmsAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetStrangeTempAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_STRANGETEMP, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nStrangeTempAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nStrangeTempAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetEOCRAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_EOCRTEMP, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nEOCRTempAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nEOCRTempAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetSSR1Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_SSRTEMP, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nSSRTemp1Alarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nSSRTemp1Alarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetSSR2Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_SSRTEMP2, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nSSRTemp2Alarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nSSRTemp2Alarm = state.Clone

            End If
        End If

        Return True
    End Function

    Public Overrides Function GetTempSensor1Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_TEMPSENSOR1, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nTempSensor1Alarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nTempSensor1Alarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetTempSensor2Alarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_TEMPSENSOR2, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nTempSensor2Alarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nTempSensor2Alarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetDoorAlarm(ByVal state() As eDoorAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_DOOROPEN, sRcvValue) = True Then '도어알람 필요하다.

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nDoorAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eDoorAlarm.eSafety_Door_Loop
                            Case 1
                                state(nCnt) = eDoorAlarm.eSafety_Door_1
                            Case 2
                                state(nCnt) = eDoorAlarm.eSafety_Door_2
                            Case 3
                                state(nCnt) = eDoorAlarm.eSafety_Door_3
                            Case 4
                                state(nCnt) = eDoorAlarm.eSafety_Door_4
                            Case 5
                                state(nCnt) = eDoorAlarm.eSafety_Door_5
                            Case 6
                                state(nCnt) = eDoorAlarm.eSafety_Door_6
                            Case 7
                                state(nCnt) = eDoorAlarm.eSafety_Door_7
                            Case 8
                                state(nCnt) = eDoorAlarm.eSafety_Door_8
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nDoorAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    'Public Overrides Function GetOverTempZone1Alarm(ByVal state() As eTemperatureAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_OVERTEMP_1, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = eTemperatureAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nOverTempAlarm_Zone1 = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eTemperatureAlarm.eT1
    '                        Case 1
    '                            state(nCnt) = eTemperatureAlarm.eT2
    '                        Case 2
    '                            state(nCnt) = eTemperatureAlarm.eT3
    '                        Case 3
    '                            state(nCnt) = eTemperatureAlarm.eT4
    '                        Case 4
    '                            state(nCnt) = eTemperatureAlarm.eT5
    '                        Case 5
    '                            state(nCnt) = eTemperatureAlarm.eT6
    '                        Case 6
    '                            state(nCnt) = eTemperatureAlarm.eT7
    '                        Case 7
    '                            state(nCnt) = eTemperatureAlarm.eT8
    '                        Case 8
    '                            state(nCnt) = eTemperatureAlarm.eT9
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nOverTempAlarm_Zone1 = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetOverTempZone2Alarm(ByVal state() As eTemperatureAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_OVERTEMP_2, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = eTemperatureAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nOverTempAlarm_Zone2 = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eTemperatureAlarm.eT1
    '                        Case 1
    '                            state(nCnt) = eTemperatureAlarm.eT2
    '                        Case 2
    '                            state(nCnt) = eTemperatureAlarm.eT3
    '                        Case 3
    '                            state(nCnt) = eTemperatureAlarm.eT4
    '                        Case 4
    '                            state(nCnt) = eTemperatureAlarm.eT5
    '                        Case 5
    '                            state(nCnt) = eTemperatureAlarm.eT6
    '                        Case 6
    '                            state(nCnt) = eTemperatureAlarm.eT7
    '                        Case 7
    '                            state(nCnt) = eTemperatureAlarm.eT8
    '                        Case 8
    '                            state(nCnt) = eTemperatureAlarm.eT9
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nOverTempAlarm_Zone2 = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetLoaderAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_LOADER_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nLoaderAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nLoaderAxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetUnLoaderAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_UNLOADER_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nUnLoaderAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nUnLoaderAxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetHitterAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_HITTER_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nHitterAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nHitterAxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    '정현기
    Public Overrides Function GetXAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Dim sRcvValue As String = ""
        ReDim state(0)
        If GetData(PLCCOMMAND_ALARM_X_AXIS, sRcvValue) = True Then

            If sRcvValue = "0" Then
                state(0) = eAxisAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nXAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eAxisAlarm.eAxis_Alarm
                            Case 1
                                state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
                            Case 2
                                state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
                            Case 3
                                state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
                            Case 4
                                state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
                            Case 5
                                state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
                            Case 6
                                state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
                            Case 7
                                state(nCnt) = eAxisAlarm.eAMP_Over_Temp
                            Case 8
                                state(nCnt) = eAxisAlarm.eOver_Current
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nXAxisAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetY1AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_Y1_AXIS, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eAxisAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nY1AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eAxisAlarm.eAxis_Alarm
                            Case 1
                                state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
                            Case 2
                                state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
                            Case 3
                                state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
                            Case 4
                                state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
                            Case 5
                                state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
                            Case 6
                                state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
                            Case 7
                                state(nCnt) = eAxisAlarm.eAMP_Over_Temp
                            Case 8
                                state(nCnt) = eAxisAlarm.eOver_Current
                            Case 10
                                state(nCnt) = eAxisAlarm.eSynchronous_axispositional_alarm
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nY1AxisAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetY2AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_Y2_AXIS, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eAxisAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nY2AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eAxisAlarm.eAxis_Alarm
                            Case 1
                                state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
                            Case 2
                                state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
                            Case 3
                                state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
                            Case 4
                                state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
                            Case 5
                                state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
                            Case 6
                                state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
                            Case 7
                                state(nCnt) = eAxisAlarm.eAMP_Over_Temp
                            Case 8
                                state(nCnt) = eAxisAlarm.eOver_Current
                            Case 10
                                state(nCnt) = eAxisAlarm.eSynchronous_axispositional_alarm
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nY2AxisAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function GetZAxisAlarm(ByVal state() As eAxisAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARM_Z_AXIS, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eAxisAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nZAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eAxisAlarm.eAxis_Alarm
                            Case 1
                                state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
                            Case 2
                                state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
                            Case 3
                                state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
                            Case 4
                                state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
                            Case 5
                                state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
                            Case 6
                                state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
                            Case 7
                                state(nCnt) = eAxisAlarm.eAMP_Over_Temp
                            Case 8
                                state(nCnt) = eAxisAlarm.eOver_Current
                            Case 10
                                state(nCnt) = eAxisAlarm.eSynchronous_axispositional_alarm
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nZAxisAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    'Public Overrides Function GetTheta1AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_Theta1_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nTheta1AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nTheta1AxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetTheta2AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_THETA2_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nTheta2AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nTheta2AxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetTheta3AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_Theta3_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nTheta3AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nTheta3AxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetTheta4AxisAlarm(ByVal state() As eAxisAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_Theta4_AXIS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eAxisAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nTheta4AxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eAxisAlarm.eAxis_Alarm
    '                        Case 1
    '                            state(nCnt) = eAxisAlarm.eAxis_Servo_Alarm
    '                        Case 2
    '                            state(nCnt) = eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                        Case 3
    '                            state(nCnt) = eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                        Case 4
    '                            state(nCnt) = eAxisAlarm.eAxis_Crush_Alarm
    '                        Case 5
    '                            state(nCnt) = eAxisAlarm.eAxis_Homming_Timeout
    '                        Case 6
    '                            state(nCnt) = eAxisAlarm.eAxis_Moving_Timeout
    '                        Case 7
    '                            state(nCnt) = eAxisAlarm.eAMP_Over_Temp
    '                        Case 8
    '                            state(nCnt) = eAxisAlarm.eOver_Current
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nTheta4AxisAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    'Public Overrides Function GetExhausSlotStatus(ByVal state() As eSlotSignal) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ULD_SLOT_CHK, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eSlotSignal.eNone
    '            myParent.cPLC.m_PLCDatas.nExhausSlotSignal = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else
    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eSlotSignal.eSlot00
    '                        Case 1
    '                            state(nCnt) = eSlotSignal.eSlot01
    '                        Case 2
    '                            state(nCnt) = eSlotSignal.eSlot02
    '                        Case 3
    '                            state(nCnt) = eSlotSignal.eSlot03
    '                        Case 4
    '                            state(nCnt) = eSlotSignal.eSlot04
    '                        Case 5
    '                            state(nCnt) = eSlotSignal.eSlot05
    '                        Case 6
    '                            state(nCnt) = eSlotSignal.eSlot06
    '                        Case 7
    '                            state(nCnt) = eSlotSignal.eSlot07
    '                        Case 8
    '                            state(nCnt) = eSlotSignal.eSlot08
    '                        Case 9
    '                            state(nCnt) = eSlotSignal.eSlot09
    '                        Case 10
    '                            state(nCnt) = eSlotSignal.eSlot10
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nExhausSlotSignal = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetSupplyPosition(ByVal state() As ePositionSignal) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_LD_MOVE_CHK, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = ePositionSignal.eNone
    '            myParent.cPLC.m_PLCDatas.nSupplyPositionSignal = state.Clone  '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else
    '            Dim nCnt As Integer = Nothing
    '            Dim nBinery() As Integer = Nothing
    '            nBinery = hex2bin(sRcvValue)
    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = ePositionSignal.eNone
    '                        Case 1
    '                            state(nCnt) = ePositionSignal.ePosition01
    '                        Case 2
    '                            state(nCnt) = ePositionSignal.ePosition02
    '                        Case 3
    '                            state(nCnt) = ePositionSignal.ePosition03
    '                        Case 4
    '                            state(nCnt) = ePositionSignal.ePosition04
    '                        Case 5
    '                            state(nCnt) = ePositionSignal.ePosition05
    '                        Case 6
    '                            state(nCnt) = ePositionSignal.ePosition06
    '                        Case 7
    '                            state(nCnt) = ePositionSignal.ePosition07
    '                        Case 8
    '                            state(nCnt) = ePositionSignal.ePosition08
    '                        Case 9
    '                            state(nCnt) = ePositionSignal.ePosition09
    '                        Case 10
    '                            state(nCnt) = ePositionSignal.ePosition10
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next
    '        End If
    '        myParent.cPLC.m_PLCDatas.nSupplyPositionSignal = state.Clone

    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetExhausPosition(ByVal state() As ePositionSignal) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ULD_MOVE_CHK, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            state(0) = ePositionSignal.eNone
    '            myParent.cPLC.m_PLCDatas.nExhausPositionSignal = state.Clone  '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else
    '            Dim nCnt As Integer = Nothing
    '            Dim nBinery() As Integer = Nothing
    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = ePositionSignal.eNone
    '                        Case 1
    '                            state(nCnt) = ePositionSignal.ePosition01
    '                        Case 2
    '                            state(nCnt) = ePositionSignal.ePosition02
    '                        Case 3
    '                            state(nCnt) = ePositionSignal.ePosition03
    '                        Case 4
    '                            state(nCnt) = ePositionSignal.ePosition04
    '                        Case 5
    '                            state(nCnt) = ePositionSignal.ePosition05
    '                        Case 6
    '                            state(nCnt) = ePositionSignal.ePosition06
    '                        Case 7
    '                            state(nCnt) = ePositionSignal.ePosition07
    '                        Case 8
    '                            state(nCnt) = ePositionSignal.ePosition08
    '                        Case 9
    '                            state(nCnt) = ePositionSignal.ePosition09
    '                        Case 10
    '                            state(nCnt) = ePositionSignal.ePosition10
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next
    '        End If
    '        myParent.cPLC.m_PLCDatas.nExhausPositionSignal = state.Clone

    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetMagazineAlarmStatus(ByVal state() As eMagazineError) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_MAGAZINE_ERROR, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eMagazineError.eNoError
    '            myParent.cPLC.m_PLCDatas.nMagazineError = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eMagazineError.eReserved01
    '                        Case 1
    '                            state(nCnt) = eMagazineError.eReserved01
    '                        Case 2
    '                            state(nCnt) = eMagazineError.eReserved02
    '                        Case 3
    '                            state(nCnt) = eMagazineError.eReserved03
    '                        Case 4
    '                            state(nCnt) = eMagazineError.eReserved04
    '                        Case 5
    '                            state(nCnt) = eMagazineError.eReserved05
    '                        Case 6
    '                            state(nCnt) = eMagazineError.eReserved06
    '                        Case 7
    '                            state(nCnt) = eMagazineError.eReserved07
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nMagazineError = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetMagazineSupplyStatus(ByVal state() As eMagazineStatus) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_MAGAZINE_SUPPLY_STATUS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eMagazineStatus.eIDEL
    '            myParent.cPLC.m_PLCDatas.nSupplyMagazineStatus = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eMagazineStatus.eReady
    '                        Case 1
    '                            state(nCnt) = eMagazineStatus.eScan
    '                        Case 2
    '                            state(nCnt) = eMagazineStatus.eScanEnd
    '                        Case 3
    '                            state(nCnt) = eMagazineStatus.ePallet_Up
    '                        Case 4
    '                            state(nCnt) = eMagazineStatus.ePallet_Down
    '                        Case 5
    '                            state(nCnt) = eMagazineStatus.eReadyEnd
    '                        Case 6
    '                            state(nCnt) = eMagazineStatus.eStart
    '                        Case 7
    '                            state(nCnt) = eMagazineStatus.eProgress
    '                        Case 8
    '                            state(nCnt) = eMagazineStatus.eEND
    '                        Case 9
    '                            state(nCnt) = eMagazineStatus.eBusy
    '                        Case 10
    '                            state(nCnt) = eMagazineStatus.eUpDownEnd
    '                        Case 11
    '                            state(nCnt) = eMagazineStatus.eHome
    '                        Case 12
    '                            state(nCnt) = eMagazineStatus.eHomeEnd
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nSupplyMagazineStatus = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetMagazineExhausStatus(ByVal state() As eMagazineStatus) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_MAGAZINE_EXHAUS_STATUS, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eMagazineStatus.eIDEL
    '            myParent.cPLC.m_PLCDatas.nExhausMagazineStatus = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eMagazineStatus.eReady
    '                        Case 1
    '                            state(nCnt) = eMagazineStatus.eScan
    '                        Case 2
    '                            state(nCnt) = eMagazineStatus.eScanEnd
    '                        Case 3
    '                            state(nCnt) = eMagazineStatus.ePallet_Up
    '                        Case 4
    '                            state(nCnt) = eMagazineStatus.ePallet_Down
    '                        Case 5
    '                            state(nCnt) = eMagazineStatus.eReadyEnd
    '                        Case 6
    '                            state(nCnt) = eMagazineStatus.eStart
    '                        Case 7
    '                            state(nCnt) = eMagazineStatus.eProgress
    '                        Case 8
    '                            state(nCnt) = eMagazineStatus.eEND
    '                        Case 9
    '                            state(nCnt) = eMagazineStatus.eBusy
    '                        Case 10
    '                            state(nCnt) = eMagazineStatus.eUpDownEnd
    '                        Case 11
    '                            state(nCnt) = eMagazineStatus.eHome
    '                        Case 12
    '                            state(nCnt) = eMagazineStatus.eHomeEnd
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nExhausMagazineStatus = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    Public Overrides Function Get_Axis_Alarm(ByVal state() As eAllAxisAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_AXIS_ALARAM_STATUS_CHK, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eAllAxisAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nAxisAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else
                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)
                        '나중에 수정해야함
                        Select Case i
                            Case 0
                                state(nCnt) = eAllAxisAlarm.eY1_Axis_Alarm
                            Case 1
                                state(nCnt) = eAllAxisAlarm.eY2_Axis_Alarm
                            Case 2
                                state(nCnt) = eAllAxisAlarm.eX_Axis_Alarm
                            Case 1
                                state(nCnt) = eAllAxisAlarm.eZ_Axis_Alarm
                            Case 2
                                state(nCnt) = eAllAxisAlarm.eTheta1_Axis_Alarm
                            Case 3
                                state(nCnt) = eAllAxisAlarm.eTheta2_Axis_Alarm
                            Case 4
                                state(nCnt) = eAllAxisAlarm.eTheta3_Axis_Alarm
                            Case 5
                                state(nCnt) = eAllAxisAlarm.eTheta4_Axis_Alarm
                        End Select

                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nAxisAlarm = state.Clone

            End If
        End If

        Return True
    End Function
    Public Overrides Function Get_EQP_Alarm(ByVal state() As eEQPLightAlaram) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_ALARAM_CHK, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eEQPLightAlaram.eNoError
                myParent.cPLC.m_PLCDatas.nEQPAlaram = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eEQPLightAlaram.eNoError
                            Case 1
                                state(nCnt) = eEQPLightAlaram.eNoError
                            Case 2
                                state(nCnt) = eEQPLightAlaram.eLightAlaram
                            Case 3
                                state(nCnt) = eEQPLightAlaram.eHeavyAlaram
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nEQPAlaram = state.Clone

            End If
        End If

        Return True
    End Function

    Public Overrides Function Get_Servo_Alarm(ByVal state() As eServoAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData(PLCCOMMAND_SERVO_STATUS_CHK, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = ePCBInfoAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nServoAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eServoAlarm.eX_Axis_Servo_ON
                            Case 1
                                state(nCnt) = eServoAlarm.eY1_Axis_Servo_ON
                            Case 2
                                state(nCnt) = eServoAlarm.eY2_Axis_Servo_ON
                            Case 3
                                state(nCnt) = eServoAlarm.eZ_Axis_Servo_ON
                                'Case 4
                                '    state(nCnt) = eServoAlarm.eTheta3_Axis_Servo_ON
                                'Case 5
                                '    state(nCnt) = eServoAlarm.eTheta4_Axis_Servo_ON
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nServoAlarm = state.Clone

            End If
        End If

        Return True
    End Function

    Public Overrides Function GetTemperatureAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData("00", sRcvValue) = True Then '온도 알람 필요하다.

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nTemperatureAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nTemperatureAlarm = state.Clone

            End If
        End If

        Return True
    End Function

    Public Overrides Function GetTemperatureControlAlarm(ByVal state() As eTemperatureAlarm) As Boolean
        Dim sRcvValue As String = ""

        If GetData("00", sRcvValue) = True Then '온도 알람 필요하다

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eTemperatureAlarm.eNoError
                myParent.cPLC.m_PLCDatas.nTemperatureControlAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eTemperatureAlarm.eT1
                            Case 1
                                state(nCnt) = eTemperatureAlarm.eT2
                            Case 2
                                state(nCnt) = eTemperatureAlarm.eT3
                            Case 3
                                state(nCnt) = eTemperatureAlarm.eT4
                            Case 4
                                state(nCnt) = eTemperatureAlarm.eT5
                            Case 5
                                state(nCnt) = eTemperatureAlarm.eT6
                            Case 6
                                state(nCnt) = eTemperatureAlarm.eT7
                            Case 7
                                state(nCnt) = eTemperatureAlarm.eT8
                            Case 8
                                state(nCnt) = eTemperatureAlarm.eT9
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nTemperatureControlAlarm = state.Clone

            End If
        End If

        Return True
    End Function

    'Public Overrides Function GetPCB_ContactAlarm(ByVal state() As ePCBInfoAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_PCB_CONTACT_INFO, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = ePCBInfoAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nPCBInfoAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Pin_Contact_JIG_UP
    '                        Case 1
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Pin_Contact_JIG_Down
    '                        Case 2
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Supply_Stoper_UP
    '                        Case 3
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Supply_Stoper_Down
    '                        Case 4
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Align_Stoper_Forward
    '                        Case 5
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Align_Stoper_Reverse
    '                        Case 6
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Stage_Unit_UP
    '                        Case 7
    '                            state(nCnt) = ePCBInfoAlarm.ePCB_Stage_Unit_Down
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nPCBInfoAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetConbareConnectionAlarm(ByVal state() As eConbareConnection) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_CONBARE_CONNECTION, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eConbareConnection.eNoError
    '            myParent.cPLC.m_PLCDatas.nConbareAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eConbareConnection.eSupply_Conbare_Unit_Forward
    '                        Case 1
    '                            state(nCnt) = eConbareConnection.eSupply_Conbare_Unit_Reverse
    '                        Case 2
    '                            state(nCnt) = eConbareConnection.eExhaus_Conbare_Unit_Forward
    '                        Case 3
    '                            state(nCnt) = eConbareConnection.eExhaus_Conbare_Unit_Reverse
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nConbareAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Overrides Function GetLiftSensorAlarm(ByVal state() As eLiftAlarm) As Boolean
    '    Dim sRcvValue As String = ""

    '    If GetData(PLCCOMMAND_ALARM_LIFT_SENSOR, sRcvValue) = True Then

    '        If sRcvValue = "0" Then
    '            ReDim state(0)
    '            state(0) = eLiftAlarm.eNoError
    '            myParent.cPLC.m_PLCDatas.nLiftAlarm = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
    '            Return True
    '        Else

    '            Dim nCnt As Integer
    '            Dim nBinery() As Integer

    '            nBinery = hex2bin(sRcvValue)

    '            For i As Integer = 0 To nBinery.Length - 1
    '                If nBinery(i) = -1 Then
    '                    Return False
    '                ElseIf nBinery(i) = 1 Then
    '                    ReDim Preserve state(nCnt)

    '                    Select Case i
    '                        Case 0
    '                            state(nCnt) = eLiftAlarm.eSupply_Conbare_Exhaus
    '                        Case 1
    '                            state(nCnt) = eLiftAlarm.eSupply_UpDown_Interlock1
    '                        Case 2
    '                            state(nCnt) = eLiftAlarm.eSupply_UpDown_interlock2
    '                        Case 3
    '                            state(nCnt) = eLiftAlarm.eContactInspection_Stage
    '                        Case 4
    '                            state(nCnt) = eLiftAlarm.eExhaus_Conbare_Supply
    '                        Case 5
    '                            state(nCnt) = eLiftAlarm.eExhaus_Conbare_Exhaus
    '                        Case 6
    '                            state(nCnt) = eLiftAlarm.eExhaus_UpDown_Interlock1
    '                        Case 7
    '                            state(nCnt) = eLiftAlarm.eExhaus_UpDown_interlock2
    '                    End Select
    '                    nCnt += 1
    '                End If
    '            Next

    '            myParent.cPLC.m_PLCDatas.nLiftAlarm = state.Clone

    '        End If
    '    End If

    '    Return True
    'End Function
    Public Overrides Function SetRunState(ByVal State As CDevPLCCommonNode.eRunState) As Boolean
        '정현기 재술이형 물어봐야함
        If State = eRunState.eRun Then
            If SetData(PLCCOMMAND_SET_EQP_STATE, EQE_RUN_REQUEST) = False Then Return False
        ElseIf State = eRunState.eStop Then
            If SetData(PLCCOMMAND_SET_EQP_STATE, EQE_STOP_REQUEST) = False Then Return False
        ElseIf State = eRunState.ePause Then
            If SetData(PLCCOMMAND_SET_EQP_STATE, EQE_PAUSE_REQUEST) = False Then Return False
        ElseIf State = eRunState.eReset Then
            If SetData(PLCCOMMAND_SET_EQP_STATE, EQE_RESET_REQUEST) = False Then Return False
        End If

        Return True
    End Function

    Public Overrides Function SetMagazineSupplyStatus(ByVal state As eMagazineStatus) As Boolean
        '  If SetData(PLCCOMMAND_MAGAZINE_SUPPLY_STATUS, m_sSignalInfo.sMagazineInfos.sSupply.nStatusValue(state)) = False Then Return False

        Return True
    End Function

    Public Overrides Function SetMagazineExhausStatus(ByVal state As eMagazineStatus) As Boolean
        '    If SetData(PLCCOMMAND_MAGAZINE_EXHAUS_STATUS, m_sSignalInfo.sMagazineInfos.sExhaus.nStatusValue(state)) = False Then Return False

        Return True
    End Function

    Public Overrides Function SetMagazineContactInspectionStatus(ByVal state As eMagazineContactIspection) As Boolean
        '  If SetData(PLCCOMMAND_MAGAZINE_CONTACTINSPECTION, m_sSignalInfo.sMagazineInfos.sContact.nContactIspectionStatusValue(state)) = False Then Return False

        Return True
    End Function

#End Region
    Public Overrides Function GetEQPState(ByRef State() As CDevPLCCommonNode.eEQPStatus) As Boolean
        Dim sRcvValue As String = ""
        '정현기 재술이형 물어봐야함
        If GetData(PLCCOMMAND_EQP_STATE_CHK, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim State(0)
                State(0) = eEQPStatus.eRun
                myParent.cPLC.m_PLCDatas.nSystemStatus = State.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve State(nCnt)

                        Select Case i
                            Case 0
                                State(nCnt) = eEQPStatus.eRun
                            Case 1
                                State(nCnt) = eEQPStatus.eStop
                            Case 2
                                State(nCnt) = eEQPStatus.ePause
                            Case 3
                                State(nCnt) = eEQPStatus.eReset
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nEQPState = State.Clone
                ' Return True
            End If
        End If

        Return True
    End Function

    Public Overrides Function GetSystemStatus(ByVal state() As eSystemStatus) As Boolean
        Dim sRcvValue As String = ""
        ReDim state(0)
        If GetData(PLCCOMMAND_SYSTEM_STATE_CHK, sRcvValue) = True Then

            If sRcvValue = "0" Then
                ReDim state(0)
                state(0) = eSystemStatus.ePower_Down
                myParent.cPLC.m_PLCDatas.nSystemStatus = state.Clone '    m_PLCDatas.nSystemStatus = state.Clone
                Return True
            Else

                Dim nCnt As Integer = 0
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve state(nCnt)

                        Select Case i
                            Case 0
                                state(nCnt) = eSystemStatus.ePower_On
                            Case 1
                                state(nCnt) = eSystemStatus.ePower_Down
                            Case 2
                                state(nCnt) = eSystemStatus.eTeaching_Mode
                            Case 3
                                state(nCnt) = eSystemStatus.eAuto_Mode
                            Case 4
                                state(nCnt) = eSystemStatus.eManual_Mode
                            Case 5
                                state(nCnt) = eSystemStatus.eProcessing
                            Case 6
                                state(nCnt) = eSystemStatus.eLoading
                            Case 7
                                state(nCnt) = eSystemStatus.eIDEL
                        End Select

                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nSystemStatus = state.Clone

                ' Return True
            End If
        End If

        Return True
    End Function


    Public Function ChkCanAllReset(ByVal ChkMode As CDevPLCCommonNode.eAllResetChkState)
        Dim sRcvData As String = Nothing
        Dim PLC_Command As String = Nothing
        PLC_Command = PLCCOMMAND_ALL_RESET_STATUS_CHK

        If GetData(PLC_Command, sRcvData) = False Then Return False
        If sRcvData = "0" Then
            Return False
        Else
            Dim nBinery() As Integer = Nothing

            nBinery = hex2bin(sRcvData)

            If ChkMode = eAllResetChkState.eCan_All_Reset Then
                If nBinery(0) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf ChkMode = eAllResetChkState.eACK_All_Reset Then
                If nBinery(1) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Overrides Function GetCanAllReset(ByVal chkMode As CDevPLCCommonNode.eAllResetChkState) As Boolean
        Dim sRcvData As String = Nothing
        Dim PLC_Command As String = Nothing
        PLC_Command = PLCCOMMAND_ALL_RESET_CHK

        If GetData(PLC_Command, sRcvData) = False Then Return False
        If sRcvData = "0" Then
            Return False
        Else
            Dim nBinery() As Integer = Nothing

            nBinery = hex2bin(sRcvData)

            If chkMode = eAllResetChkState.eCan_All_Reset Then
                If nBinery(0) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf chkMode = eAllResetChkState.eACK_All_Reset Then
                If nBinery(1) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Function ChkAckAllReset(ByVal ChkMode As CDevPLCCommonNode.eAllResetChkState)
        Dim sRcvData As String = Nothing
        Dim PLC_Command As String = Nothing
        PLC_Command = PLCCOMMAND_ALL_RESET_CHK

        If GetData(PLC_Command, sRcvData) = False Then Return False
        If sRcvData = "0" Then
            Return False
        Else
            Dim nBinery() As Integer = Nothing

            nBinery = hex2bin(sRcvData)

            If ChkMode = eAllResetChkState.eCan_All_Reset Then
                If nBinery(0) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf ChkMode = eAllResetChkState.eACK_All_Reset Then
                If nBinery(1) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Overrides Function SetAllReset() As Boolean
        Dim rcvData As String = Nothing

        ' 1. 전체 초기화 가능 상태 조회
        'If ChkCanAllReset(eAllResetChkState.eCan_All_Reset) = False Then Return False

        ' 2. 전체 초기화 REQUEST
        If SetData(PLCCOMMAND_ALL_RESET_REQUSET, CShort(1)) = False Then Return False

        If ChkAckAllReset(eAllResetChkState.eACK_All_Reset) = False Then Return False

        ' 3. ACK 신호 확인
        '  If ChkCanAllReset(eAllResetChkState.eACK_All_Reset) = False Then Return False


        ' 4. ACK 신호 확인 후 다시 OFF
        If SetData(PLCCOMMAND_ALL_RESET_REQUSET, CShort(0)) = False Then Return False
        Return True
    End Function
    Public Overrides Function SetAlarm(ByVal alarm As eDISignal) As Boolean
        '   If SetData(PLCCOMMAND_DI_SIGNAL, m_sSignalInfo.nAlarmValues(alarm)) = False Then Return False
        'DI 알람 필요하다.
        Return True
    End Function

    Public Overrides Function GetAlarm(ByRef alarm() As eDISignal) As Boolean
        Dim sRcvValue As String = ""

        If GetData("00", sRcvValue) = True Then 'Get IO 알람 필요하다.

            If sRcvValue = "0" Then
                ReDim alarm(0)
                alarm(0) = eDISignal.eNoError

                myParent.cPLC.m_PLCDatas.nDISignal = alarm.Clone
                Return True
            Else
                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve alarm(nCnt)

                        Select Case i
                            Case 0
                                alarm(nCnt) = eDISignal.eEmergency
                            Case 1
                                alarm(nCnt) = eDISignal.eFire
                            Case 2
                                alarm(nCnt) = eDISignal.eHeater
                            Case 3
                                alarm(nCnt) = eDISignal.eCurrentLimit
                            Case 4
                                alarm(nCnt) = eDISignal.eInterlock
                            Case 5
                                alarm(nCnt) = eDISignal.eCylinder
                            Case 6
                                alarm(nCnt) = eDISignal.eDoorOpen
                            Case 7
                                alarm(nCnt) = eDISignal.eSupply
                            Case 8
                                alarm(nCnt) = eDISignal.eInspectionStage
                            Case 9
                                alarm(nCnt) = eDISignal.eExhaus
                        End Select
                        nCnt += 1
                    End If
                Next

                'D0로 되어 있었음 확인 필요
                myParent.cPLC.m_PLCDatas.nDISignal = alarm.Clone
                '  Return True
            End If
        End If

        Return True
    End Function

    Public Overrides Function SetDOSignal(ByVal signal As eDOSignal) As Boolean
        ' If SetData(PLCCOMMAND_DO_SIGNAL, m_sSignalInfo.nOutputValues(signal)) = False Then Return False
        '경광등 알람 필요할까?
        Return True
    End Function

    Public Overrides Function GetDOSignal(ByRef signal() As eDOSignal) As Boolean
        Dim sRcvValue As String = ""

        If GetData("00", sRcvValue) = True Then '경광등 알람 필요할까?

            If sRcvValue = "0" Then
                ReDim signal(0)
                signal(0) = eDOSignal.eALLOFF

                myParent.cPLC.m_PLCDatas.nDOSignal = signal.Clone
                Return True
            Else

                Dim nCnt As Integer
                Dim nBinery() As Integer

                nBinery = hex2bin(sRcvValue)

                For i As Integer = 0 To nBinery.Length - 1
                    If nBinery(i) = -1 Then
                        Return False
                    ElseIf nBinery(i) = 1 Then
                        ReDim Preserve signal(nCnt)

                        Select Case i
                            Case 0
                                signal(nCnt) = eDOSignal.ePort0_RED
                            Case 1
                                signal(nCnt) = eDOSignal.ePort1_YELLOW
                            Case 2
                                signal(nCnt) = eDOSignal.ePort2_GREEN
                            Case 3
                                signal(nCnt) = eDOSignal.ePort3_BLUE
                            Case 4
                                signal(nCnt) = eDOSignal.ePort4_Reserved
                            Case 5
                                signal(nCnt) = eDOSignal.ePort5_Reserved
                            Case 6
                                signal(nCnt) = eDOSignal.ePort6_Reserved
                            Case 7
                                signal(nCnt) = eDOSignal.ePort7_Reserved
                        End Select
                        nCnt += 1
                    End If
                Next

                myParent.cPLC.m_PLCDatas.nDOSignal = signal.Clone

                ' Return True
            End If

        End If

        Return True
    End Function

    Public Overrides Function CheckConnectionStatus() As Boolean
        If SetData(PLCCOMMAND_CONNECT_STATE_CHK, CShort(myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal)) = True Then 'myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal) = True Then
            If myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 0 Then
                myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 1
            Else
                myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 0
            End If
        Else
            Return False
        End If

        Return True
    End Function
    Private Function SetData(ByVal sDeviceName As String, ByVal nDevVal As Integer, ByVal nNumberDevice As Integer) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = nNumberDevice  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        '  Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        ' sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        'For i As Integer = 0 To iNumberOfDeviceName - 1
        '    szDeviceName(i) = "D" & Format(CInt(sAddressValue) + i, "000")
        'Next
        szDeviceName(nNumberDevice - 1) = sDeviceName   '1:1 매칭
        ''Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        Try
            ValueBuff4Byte.INT16_Data = nDevVal
        Catch ex As Exception
            Return False
        End Try

        ValueBuf2Byte_LSB.ByteData_L = ValueBuff4Byte.ByteData_L
        ValueBuf2Byte_LSB.ByteData_H = ValueBuff4Byte.ByteData_H

        sharrDeviceValue(0) = ValueBuf2Byte_LSB.INT16_Data
        '    sharrDeviceValue(1) = ValueBuf2Byte_MSB.INT16_Data

        sDevVal = CStr(nDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        'If GetIntValue(sDevVal, sharrDeviceValue) = False Then
        '    Return False
        'End If

        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))   'WriteDeviceBlock(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
                Next

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))
                Next
            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function SetData(ByVal sDeviceName As String, ByVal nDevVal As Integer) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT32
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "D" & Format(CInt(sAddressValue) + i, "000")
        Next

        ''Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        Try
            ValueBuff4Byte.INT32_Data = nDevVal
        Catch ex As Exception
            Return False
        End Try

        ValueBuf2Byte_LSB.ByteData_L = ValueBuff4Byte.ByteData0
        ValueBuf2Byte_LSB.ByteData_H = ValueBuff4Byte.ByteData1

        ValueBuf2Byte_MSB.ByteData_L = ValueBuff4Byte.ByteData2
        ValueBuf2Byte_MSB.ByteData_H = ValueBuff4Byte.ByteData3

        sharrDeviceValue(0) = ValueBuf2Byte_LSB.INT16_Data
        sharrDeviceValue(1) = ValueBuf2Byte_MSB.INT16_Data

        sDevVal = CStr(nDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        'If GetIntValue(sDevVal, sharrDeviceValue) = False Then
        '    Return False
        'End If

        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))   'WriteDeviceBlock(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
                Next

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))
                Next
            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function SetData(ByVal sDeviceName As String, ByVal nDevVal As Short) As Boolean
        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue As Short         'Data for 'DeviceValue'
        Dim sDevVal As String = ""

       
        szDeviceName = sDeviceName 'String.Join(vbLf, txt_DeviceNameBlock.Lines)

        If GetIntValue(1, iNumberOfDeviceName) = False Then
            Return False
        End If

        sDevVal = CStr(nDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        If GetShort(sDevVal, sharrDeviceValue) = False Then
            Return False
        End If

        Try
            If m_CommType = eType._Prog Then
               
                iReturnCode = ActProgType.WriteDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)

            ElseIf m_CommType = eType._Utl Then
                
                iReturnCode = ActUtlType.WriteDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function
    Private Function SetData(ByVal sDeviceName As String, ByVal dDevVal As Single) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""


        Dim ValueBuff4Byte As CUnitCommonNode.SplitSingle
        Dim ValueBuf2Byte_1 As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_2 As CUnitCommonNode.SplitINT16
        'Dim ValueBuf2Byte_3 As CUnitCommonNode.SplitINT16
        'Dim ValueBuf2Byte_4 As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "D" & Format(CInt(sAddressValue) + i, "000")
        Next

        ''Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        Try
            ValueBuff4Byte.SingleData = dDevVal
        Catch ex As Exception
            Return False
        End Try

        ValueBuf2Byte_1.ByteData_L = ValueBuff4Byte.ByteData0_L
        ValueBuf2Byte_1.ByteData_H = ValueBuff4Byte.ByteData0_H

        ValueBuf2Byte_2.ByteData_L = ValueBuff4Byte.ByteData1_L
        ValueBuf2Byte_2.ByteData_H = ValueBuff4Byte.ByteData1_H

        'ValueBuf2Byte_3.ByteData_L = ValueBuff4Byte.ByteData2_L
        'ValueBuf2Byte_3.ByteData_H = ValueBuff4Byte.ByteData2_H

        'ValueBuf2Byte_4.ByteData_L = ValueBuff4Byte.ByteData3_L
        'ValueBuf2Byte_4.ByteData_H = ValueBuff4Byte.ByteData3_H

        sharrDeviceValue(0) = ValueBuf2Byte_1.INT16_Data
        sharrDeviceValue(1) = ValueBuf2Byte_2.INT16_Data
        'sharrDeviceValue(2) = ValueBuf2Byte_3.INT16_Data
        'sharrDeviceValue(3) = ValueBuf2Byte_4.INT16_Data

        sDevVal = CStr(dDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        'If GetIntValue(sDevVal, sharrDeviceValue) = False Then
        '    Return False
        'End If

        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))   'WriteDeviceBlock(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
                Next

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))
                Next

            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function
    Private Function SetData(ByVal sDeviceName As String, ByVal nDevNo As String, ByVal sDevVal() As String) As Boolean
        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'

        'Displayed output data is cleared.

        'Get the list of 'DeviceName'.
        '  Join each line(StringType array) of 'DeviceName' by the separator '\n',
        '  and create a joined string data.
        szDeviceName = sDeviceName 'String.Join(vbLf, txt_DeviceNameBlock.Lines)

        'Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        If GetIntValue(nDevNo, iNumberOfDeviceName) = False Then
            Return False
        End If

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        If GetShortArray(sDevVal, sharrDeviceValue) = False Then
            Return False
        End If

        '
        'Processing of WriteDeviceBlock2 method
        '
        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                iReturnCode = ActProgType.WriteDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                iReturnCode = ActUtlType.WriteDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))
            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function
    Private Function SetData(ByVal sDeviceName As String, ByVal nDevVal As Double) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2  'Data for 'DeviceSize = 16bit * 4 = 64Bit = double
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Double      'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sStartIndex As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT32
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16

        ' Dim ValueBuf2Byte_LSB2 As CUnitCommonNode.SplitINT16
        ' Dim ValueBuf2Byte_MSB2 As CUnitCommonNode.SplitINT16

        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 2)
        sStartIndex = sDeviceName.Substring(sDeviceName.Length - 1, 1)
        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "W" & sAddressValue & Format(i + sStartIndex, "0")
        Next

        ''Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        Try
            ValueBuff4Byte.INT32_Data = CDbl(nDevVal)
        Catch ex As Exception

        End Try

        ValueBuf2Byte_LSB.ByteData_L = ValueBuff4Byte.ByteData0
        ValueBuf2Byte_LSB.ByteData_H = ValueBuff4Byte.ByteData1
        ValueBuf2Byte_MSB.ByteData_L = ValueBuff4Byte.ByteData2
        ValueBuf2Byte_MSB.ByteData_H = ValueBuff4Byte.ByteData3

        'ValueBuf2Byte_MSB.ByteData0 = ValueBuff4Byte.ByteData
        'ValueBuf2Byte_MSB.ByteData1 = ValueBuff4Byte.ByteData2_L
        'ValueBuf2Byte_MSB.ByteData2 = ValueBuff4Byte.ByteData3_H
        'ValueBuf2Byte_MSB.ByteData3 = ValueBuff4Byte.ByteData3_L

        sharrDeviceValue(0) = ValueBuf2Byte_LSB.INT16_Data
        sharrDeviceValue(1) = ValueBuf2Byte_MSB.INT16_Data

        ' sDevVal = CStr(nDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        'If GetIntValue(sDevVal, sharrDeviceValue) = False Then
        '    Return False
        'End If

        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))   'WriteDeviceBlock(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
                Next

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))
                Next

            End If

        Catch exception As Exception
            Return False
        End Try

        ''''''''''''''''''''''''''''''

        Return True
    End Function
    Private Function SetData(ByVal sDeviceName As String, ByVal nDevVal As UInteger) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitUINT32
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "W21A" & Format(CInt(sAddressValue) + i, "0")
        Next

        ''Check the 'DeviceSize'.(If succeeded, the value is gotten.)

        Try
            ValueBuff4Byte.UINT32_Data = CUInt(nDevVal)
        Catch ex As Exception
            Return False
        End Try


        ValueBuf2Byte_LSB.ByteData_L = ValueBuff4Byte.ByteData0
        ValueBuf2Byte_LSB.ByteData_H = ValueBuff4Byte.ByteData1

        ValueBuf2Byte_MSB.ByteData_L = ValueBuff4Byte.ByteData2
        ValueBuf2Byte_MSB.ByteData_H = ValueBuff4Byte.ByteData3

        sharrDeviceValue(0) = ValueBuf2Byte_LSB.INT16_Data
        sharrDeviceValue(1) = ValueBuf2Byte_MSB.INT16_Data

        sDevVal = CStr(nDevVal)

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        'ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        'If GetIntValue(sDevVal, sharrDeviceValue) = False Then
        '    Return False
        'End If

        Try
            If m_CommType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.WriteDeviceBlock(szDeviceName(i), 2, 100000) 'sharrDeviceValue(i))   'WriteDeviceBlock(szDeviceName, iNumberOfDeviceName, sharrDeviceValue)
                Next

            ElseIf m_CommType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the WriteDeviceRandom2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.WriteDeviceBlock(szDeviceName(i), 1, sharrDeviceValue(i))
                Next

            End If

        Catch exception As Exception
            Return False
        End Try

        Return True
    End Function
    Private Function GetData(ByVal sDeviceName As String, ByVal nDevNo As String, ByRef sDevVal() As String) As Boolean

        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        Dim szarrData() As String               'Array for 'Data'
        Dim iNumber As Integer                  'Loop counter


        'Get the list of 'DeviceName'.
        '  Join each line(StringType array) of 'DeviceName' by the separator '\n',
        '  and create a joined string data.
        szDeviceName = sDeviceName

        'Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        If GetIntValue(nDevNo, iNumberOfDeviceName) = False Then
            'If failed, this process is end.
            Return False
        End If

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(iNumberOfDeviceName - 1)

        'Processing of ReadDeviceBlock2 method
        Try
            '
            If ComType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                iReturnCode = ActProgType.ReadDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))

            ElseIf ComType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                iReturnCode = ActUtlType.ReadDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))
            End If

        Catch exException As Exception
            Return False
        End Try
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            'Assign array for the read data.
            ReDim szarrData(iNumberOfDeviceName - 1)

            'Copy the read data to the 'lpszarrData'.
            For iNumber = 0 To iNumberOfDeviceName - 1
                szarrData(iNumber) = sharrDeviceValue(iNumber).ToString()
            Next iNumber

            'Set the read data to the 'Data', and display it.
            sDevVal = szarrData.Clone
        End If

        Return True
    End Function

    Private Function GetData(ByVal sDeviceName As String, ByRef sDevVal As String) As Boolean

        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        Dim szarrData() As String               'Array for 'Data'
        Dim iNumber As Integer                  'Loop counter

        'Get the list of 'DeviceName'.
        '  Join each line(StringType array) of 'DeviceName' by the separator '\n',
        '  and create a joined string data.
        szDeviceName = sDeviceName

        'Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        If GetIntValue(1, iNumberOfDeviceName) = False Then
            'If failed, this process is end.
            Return False
        End If

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(iNumberOfDeviceName - 1)

        'Processing of ReadDeviceBlock2 method
        '
        Try
            If ComType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                iReturnCode = ActProgType.ReadDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))

            ElseIf ComType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                iReturnCode = ActUtlType.ReadDeviceBlock2(szDeviceName, iNumberOfDeviceName, sharrDeviceValue(0))
            End If

        Catch exException As Exception
            Return False
        End Try

        'Display the read data
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            'Assign array for the read data.
            ReDim szarrData(iNumberOfDeviceName - 1)

            'Copy the read data to the 'lpszarrData'.
            For iNumber = 0 To iNumberOfDeviceName - 1
                szarrData(iNumber) = sharrDeviceValue(iNumber).ToString()
            Next iNumber

            'Set the read data to the 'Data', and display it.
            sDevVal = szarrData(0)
        End If

        Return True
    End Function
    Private Function GetData(ByVal sDeviceName As String, ByRef nDevVal As Double) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2 'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Double           'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""
        Dim sStartIndex As String = Nothing

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT32
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16

        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 2)
        sStartIndex = sDeviceName.Substring(sDeviceName.Length - 1, 1)
        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "W" & sAddressValue & Format(i + sStartIndex, "0")
        Next

        'Processing of ReadDeviceBlock2 method
        '
      
        Try
            If ComType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            ElseIf ComType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            End If

        Catch exException As Exception
            Return False
        End Try

        'ValueBuf2Byte_LSB.UINT16_Data = sharrDeviceValue(0)
        'ValueBuf2Byte_MSB.UINT16_Data = sharrDeviceValue(1)

        'ValueBuff4Byte.ByteData0 = ValueBuf2Byte_LSB.ByteData_L
        'ValueBuff4Byte.ByteData1 = ValueBuf2Byte_LSB.ByteData_H

        'ValueBuff4Byte.ByteData2 = ValueBuf2Byte_MSB.ByteData_L
        'ValueBuff4Byte.ByteData3 = ValueBuf2Byte_MSB.ByteData_H

        'ValueBuf2Byte_LSB.UINT32_Data = sharrDeviceValue(0)
        'ValueBuf2Byte_MSB.UINT32_Data = sharrDeviceValue(1)

        'ValueBuff4Byte.ByteData0_L = ValueBuf2Byte_LSB.ByteData3
        'ValueBuff4Byte.ByteData0_H = ValueBuf2Byte_LSB.ByteData2
        'ValueBuff4Byte.ByteData1_L = ValueBuf2Byte_LSB.ByteData1
        'ValueBuff4Byte.ByteData1_H = ValueBuf2Byte_LSB.ByteData0
        'ValueBuff4Byte.ByteData2_L = ValueBuf2Byte_MSB.ByteData3
        'ValueBuff4Byte.ByteData2_H = ValueBuf2Byte_MSB.ByteData2
        'ValueBuff4Byte.ByteData3_L = ValueBuf2Byte_MSB.ByteData1
        'ValueBuff4Byte.ByteData3_H = ValueBuf2Byte_MSB.ByteData0


        '이건 플러스 영역은 된다.

        ValueBuf2Byte_LSB.INT16_Data = sharrDeviceValue(0)
        ValueBuf2Byte_MSB.INT16_Data = sharrDeviceValue(1)

        ValueBuff4Byte.ByteData0 = ValueBuf2Byte_LSB.ByteData_L
        ValueBuff4Byte.ByteData1 = ValueBuf2Byte_LSB.ByteData_H

        ValueBuff4Byte.ByteData2 = ValueBuf2Byte_MSB.ByteData_L
        ValueBuff4Byte.ByteData3 = ValueBuf2Byte_MSB.ByteData_H

        nDevVal = ValueBuff4Byte.INT32_Data


        Return True
    End Function
    Private Function GetData(ByVal sDeviceName As String, ByRef nDevVal As Integer) As Boolean
        Dim iReturnCode As Integer              'Return code

        Dim iNumberOfDeviceName As Integer = 2  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT32
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        For i As Integer = 0 To iNumberOfDeviceName - 1
            'szDeviceName(i) = "D" & Format(CInt(sAddressValue) + i, "000")
            szDeviceName(i) = "D" & Format(CInt(0) + i, "000")
        Next

        'Processing of ReadDeviceBlock2 method
        '
        Try
            If ComType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            ElseIf ComType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            End If

        Catch exException As Exception
            Return False
        End Try

        ValueBuf2Byte_LSB.INT16_Data = sharrDeviceValue(0)
        ValueBuf2Byte_MSB.INT16_Data = sharrDeviceValue(1)

        ValueBuff4Byte.ByteData0 = ValueBuf2Byte_LSB.ByteData_L
        ValueBuff4Byte.ByteData1 = ValueBuf2Byte_LSB.ByteData_H
        ValueBuff4Byte.ByteData2 = ValueBuf2Byte_MSB.ByteData_L
        ValueBuff4Byte.ByteData3 = ValueBuf2Byte_MSB.ByteData_H

        nDevVal = ValueBuff4Byte.INT32_Data

        Return True
    End Function
    Private Function GetData(ByVal sDeviceName As String, ByRef nDevVal As Integer, ByVal nNumberOfDevice As Integer) As Boolean
        Dim iReturnCode As Integer              'Return code
        Dim iNumberOfDeviceName As Integer = nNumberOfDevice  'Data for 'DeviceSize = 16bit * 2 = 32Bit = Integer
        Dim sharrDeviceValue(iNumberOfDeviceName - 1) As Short         'Data for 'DeviceValue'
        Dim szDeviceName(iNumberOfDeviceName - 1) As String          'List data for 'DeviceName'
        Dim sAddressValue As String
        Dim sDevVal As String = ""

        Dim ValueBuff4Byte As CUnitCommonNode.SplitINT16
        Dim ValueBuf2Byte_LSB As CUnitCommonNode.SplitINT16
        ' Dim ValueBuf2Byte_MSB As CUnitCommonNode.SplitINT16
        'Get the list of 'DeviceName'.
        If sDeviceName.Length < 4 Then Return False
        sAddressValue = sDeviceName.Substring(1, sDeviceName.Length - 1)

        For i As Integer = 0 To iNumberOfDeviceName - 1
            szDeviceName(i) = "D" & Format(CInt(sAddressValue) + i, "000")
        Next

        'Processing of ReadDeviceBlock2 method
        '
        Try
            If ComType = eType._Prog Then
                'When ActProgType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActProgType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            ElseIf ComType = eType._Utl Then
                'When ActUtlType is selected by the radio button,
                'the ReadDeviceBlock2 method is executed.
                For i As Integer = 0 To iNumberOfDeviceName - 1
                    iReturnCode = ActUtlType.ReadDeviceBlock2(szDeviceName(i), iNumberOfDeviceName, sharrDeviceValue(i))
                Next

            End If

        Catch exException As Exception
            Return False
        End Try

        ValueBuf2Byte_LSB.INT16_Data = sharrDeviceValue(0)
        'ValueBuf2Byte_MSB.INT16_Data = sharrDeviceValue(1)

        ValueBuff4Byte.ByteData_L = ValueBuf2Byte_LSB.ByteData_L
        ValueBuff4Byte.ByteData_H = ValueBuf2Byte_LSB.ByteData_H
        'ValueBuff4Byte.ByteData2 = ValueBuf2Byte_MSB.ByteData_L
        'ValueBuff4Byte.ByteData3 = ValueBuf2Byte_MSB.ByteData_H

        nDevVal = ValueBuff4Byte.INT16_Data

        Return True
    End Function

#Region "Surport Functions"

#Region " Processing of getting 32bit integer from TextBox "

    Private Function GetIntValue(ByVal sSourceOfIntValue As String, ByRef iGottenIntValue As Integer) As Boolean

        'Get the value as 32bit integer from TextBox
        Try
            iGottenIntValue = Convert.ToInt32(sSourceOfIntValue)

        Catch exExcepion As Exception
            Return False
        End Try

        Return True

    End Function

#End Region

#Region " Processing of getting ShortType array from StringType array of multiline TextBox "

    Private Function GetShortArray(ByVal sSourceOfShortArray() As String, ByRef sharrShortArrayValue() As Short) As Boolean

        Dim iSizeOfShortArray As Integer        'Size of ShortType array
        Dim iNumber As Integer                  'Loop counter

        'Get the size of ShortType array.
        iSizeOfShortArray = sSourceOfShortArray.Length

        'Get each element of ShortType array.
        For iNumber = 0 To iSizeOfShortArray - 1
            Try
                sharrShortArrayValue(iNumber) = Convert.ToInt16(sSourceOfShortArray(iNumber))

            Catch exExcepion As Exception
                ''When the value is nothing or out of the range, the exception is processed.
                'MessageBox.Show(exExcepion.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Next iNumber

        Return True

    End Function

    Private Function GetShort(ByVal sSourceOfShort As String, ByRef sharrShortValue As Short) As Boolean
        Try
            sharrShortValue = Convert.ToInt16(sSourceOfShort)
        Catch exExcepion As Exception
            ''When the value is nothing or out of the range, the exception is processed.
            'MessageBox.Show(exExcepion.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try


        Return True
    End Function

    Public Overrides Function SendTestCommand(ByVal sSendCommand As String, ByRef sRcvData As String) As Boolean

        'Dim buffer As Array

        'buffer = Split(sSendCommand, ",")

        'If buffer.Length < 2 Then Return False

        'If SetData(buffer(0).ToString, buffer(2).ToString) = True Then

        '    If GetData(buffer(0).ToString, sRcvData) = False Then Return False
        'Else
        '    Return False
        'End If

        'Return True
    End Function

#End Region

#Region "Suport Functions"

    'Public Overrides Function DecToBinery(ByVal dec As Integer) As Integer()
    '    Dim nInValue As Integer = dec
    '    Dim quota As Integer
    '    Dim remainder As Integer
    '    Dim nCnt As Integer
    '    Dim nBinery(7) As Integer

    '    If nInValue < 0 Or nInValue > 255 Then
    '        Return New Integer() {-1, -1, -1, -1, -1, -1, -1, -1}
    '    End If

    '    Do
    '        quota = Fix(nInValue / 2)
    '        If quota <= 1 Then
    '            remainder = nInValue - (quota * 2)
    '            nBinery(nCnt) = remainder
    '            nCnt += 1
    '            nBinery(nCnt) = quota
    '            Exit Do
    '        End If
    '        remainder = nInValue - (quota * 2)
    '        nBinery(nCnt) = remainder
    '        nInValue = quota
    '        nCnt += 1

    '    Loop
    '    Return nBinery
    'End Function

    ''Decimal -> Binary
    Public Overrides Function hex2bin(ByVal in_val) As Integer()
        Dim i, j As Integer
        Dim in_len As Integer
        Dim result, atom, temp As String
        result = ""

        in_len = Len(in_val)    '입력문자열의 길이를 구함

        i = in_len

        atom = in_val ' Mid(in_val, i, 1)    '맨 뒤에 문자부터 atom에 저장

        temp = dec2bin(atom)    '16진수의 각 자리의 숫자는 2진수의 네 자리에 해당하므로
        'atom을 2진수 변환한 후 그 값을 네 자리가 안될경우 4자리로 맞춰줘야 함
        in_len = Len(temp)
        If in_len < 8 Then

            For j = 1 To (8 - in_len) Step 1
                temp = "0" + temp
            Next j

        End If
        result = temp + result
        i = i - 1

        Dim intValue(result.Length - 1) As Integer
        For n As Integer = 0 To result.Length - 1
            intValue(n) = CInt(result.Substring(result.Length - n - 1, 1))
        Next
        Return intValue
    End Function

    'Public Function dec2bin(ByVal in_val)

    '    Dim i As Integer
    '    Dim result As Integer
    '    Dim strResult As String = ""
    '    'Dim dIn_Data As Integer

    '    in_val = Val(in_val)   '입력값을 숫자로 변환합니다.

    '    i = 0
    '    Do
    '        result = Str(in_val Mod 2) '+ result     '2로 나눈 나머지(0,1)을 차곡차곡 앞쪽으로 붙임
    '        strResult = CStr(result) & strResult
    '        in_val = Int(in_val / 2)    '2로 나눈 몫은 다음 Mod를 위해 저장
    '        i = i + 1
    '    Loop Until in_val = 1 Or in_val = 0    '몫이 2로 더이상 나누어 지지 않을때 루프의 끝
    '    strResult = in_val & strResult   '마지막으로 2로 나누어 지지 않는값도 앞쪽에 붙임

    '    dec2bin = strResult

    'End Function

#End Region
#End Region


#Region "Sequence"
    Public Overrides Function AlarmClear() As Boolean

        '리셋해주고 셋팅해야하므로 0이후에 1줌
        SetData(PLCCOMMAND_SET_ERROR_RESET, CShort(0))

        SetData(PLCCOMMAND_SET_ERROR_RESET, CShort(1))

        SetData(PLCCOMMAND_SET_ERROR_RESET, CShort(0))
        Return False
    End Function

    Public Function MotionAlarmState(ByVal nAxis As Integer) As Boolean
        Dim sRcvValue As String = Nothing
        Dim PLC_Command As String = Nothing

        If GetData(PLCCOMMAND_AXIS_ALARAM_STATUS_CHK, sRcvValue) = False Then Return False

        If sRcvValue = "0" Then
            Return True
        Else
            Dim nBinery() As Integer = Nothing
            nBinery = hex2bin(sRcvValue)
            If nBinery(nAxis) = 1 Then  '0번 X축, 1번 Y축, 2번 Z축
                Return False
            Else
                Return True
            End If
        End If
        Return True
    End Function
    'Public Function Slot_Moving_Status(ByVal eSlot As CDevPLCCommonNode.eSlot, ByVal MovingStatus As CDevPLCCommonNode.eSlotMovingStatus) As Boolean
    '    Dim sRcvValue As String = Nothing
    '    Dim PLC_Command As String = Nothing

    '    If eSlot = CDevPLCCommonNode.eSlot.eSupply Then
    '        PLC_Command = PLCCOMMAND_SUPPLY_CHK
    '    ElseIf eSlot = CDevPLCCommonNode.eSlot.eExhaust Then
    '        PLC_Command = PLCCOMMAND_EXHAUST_CHK
    '    End If

    '    If GetData(PLC_Command, sRcvValue) = False Then Return False
    '    If sRcvValue = "0" Then
    '        Return False
    '    Else
    '        Dim nBinery() As Integer

    '        nBinery = hex2bin(sRcvValue)
    '        If MovingStatus = eSlotMovingStatus.eSlot_Can_Move Then
    '            If nBinery(0) = 1 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        ElseIf MovingStatus = eSlotMovingStatus.eSlot_ACK Then
    '            If nBinery(1) = 1 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End If
    '    End If
    '    Return True
    'End Function
    Public Overrides Function Can_ChangeMode() As Boolean
        Dim sRcvValue As String = Nothing
        If GetData(PLCCOMMAND_MODE_CHANGE_CONDITION_CHK, sRcvValue) = False Then Return False

        If sRcvValue = "0" Then Return False
        If sRcvValue = "1" Then Return True
        Return True
    End Function
    Public Function Axis_Moving_Status(ByVal nAxis As Integer, ByVal AxisStatus As CDevPLCCommonNode.eAxisStatus) As Boolean
        Dim sRcvValue As String = Nothing
        Dim PLC_Command As String = Nothing

        If nAxis = CDevPLCCommonNode.eAxis.eX Then
            PLC_Command = PLCCOMMAND_X_STATE_CHK
        ElseIf nAxis = CDevPLCCommonNode.eAxis.eY Then
            PLC_Command = PLCCOMMAND_Y_STATE_CHK
        ElseIf nAxis = CDevPLCCommonNode.eAxis.eZ Then
            PLC_Command = PLCCOMMAND_Z_STATE_CHK
            'ElseIf nAxis = CDevPLCCommonNode.eAxis.eTHETA1 Then
            '    PLC_Command = PLCCOMMAND_THETA1_STATE_CHK
            'ElseIf nAxis = CDevPLCCommonNode.eAxis.eTHETA2 Then
            '    PLC_Command = PLCCOMMAND_THETA2_STATE_CHK
            'ElseIf nAxis = CDevPLCCommonNode.eAxis.eTHETA3 Then
            '    PLC_Command = PLCCOMMAND_THETA3_STATE_CHK
            'ElseIf nAxis = CDevPLCCommonNode.eAxis.eTHETA4 Then
            '    PLC_Command = PLCCOMMAND_THETA4_STATE_CHK
        End If

        If GetData(PLC_Command, sRcvValue) = False Then Return False

        If sRcvValue = "0" Then
            Return False
        Else
            Dim nBinery() As Integer

            nBinery = hex2bin(sRcvValue)
            If AxisStatus = eAxisStatus.eAxis_Can_Move Then
                If nBinery(0) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf AxisStatus = eAxisStatus.eAxis_ACK Then
                If nBinery(1) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf AxisStatus = eAxisStatus.eAxis_Moving_Complete Then
                If nBinery(2) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf AxisStatus = eAxisStatus.eAxis_Can_Homming Then
                If nBinery(3) = 1 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf AxisStatus = eAxisStatus.eAxis_ACK_Moving_Complete Then
                If nBinery(4) = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If

        Return True

    End Function
    Public Overrides Function Homming() As Boolean

        Dim Axis_Speed_Command As String = Nothing
        Dim Axis_Move_Command As String = Nothing
        Dim Axis_Checking_Move As String = Nothing
        Dim Axis_Moving_Method As String = Nothing
        Dim Axis_Complete_ACK As Short = Nothing
        Dim RcvData As String = Nothing

        '각 축마다 진행해야함 일단 고정으로 두는데 나중에 바꾸자.
        For idx As Integer = 0 To 2

            If idx = 0 Then
                Axis_Speed_Command = PLCCOMMAND_X_MOVE_SPEED_SET
                Axis_Moving_Method = PLCCOMMAND_X_POSITION_METHOD_SET
                Axis_Move_Command = PLCCOMMAND_X_MOVE_REQUEST
                Axis_Checking_Move = PLCCOMMAND_X_STATE_CHK
                Axis_Complete_ACK = X_MOVING_COMPLETE_ACK
            ElseIf idx = 1 Then
                Axis_Speed_Command = PLCCOMMAND_Y_MOVE_SPEED_SET
                Axis_Moving_Method = PLCCOMMAND_Y_POSITION_METHOD_SET
                Axis_Move_Command = PLCCOMMAND_Y_MOVE_REQUEST
                Axis_Checking_Move = PLCCOMMAND_Y_STATE_CHK
                Axis_Complete_ACK = Y_MOVING_COMPLETE_ACK
            ElseIf idx = 2 Then
                Axis_Speed_Command = PLCCOMMAND_Z_MOVE_SPEED_SET
                Axis_Moving_Method = PLCCOMMAND_Z_POSITION_METHOD_SET
                Axis_Move_Command = PLCCOMMAND_Z_MOVE_REQUEST
                Axis_Checking_Move = PLCCOMMAND_Z_STATE_CHK
                Axis_Complete_ACK = Z_MOVING_COMPLETE_ACK
                'Axis_Speed_Command = PLCCOMMAND_X_MOVE_SPEED_SET
                'Axis_Moving_Method = PLCCOMMAND_X_POSITION_METHOD_SET
                'Axis_Move_Command = PLCCOMMAND_X_MOVE_REQUEST
                'Axis_Checking_Move = PLCCOMMAND_X_STATE_CHK
                'Axis_Complete_ACK = X_MOVING_COMPLETE_ACK
                'ElseIf idx = 2 Then
                '    Axis_Speed_Command = PLCCOMMAND_THETA1_MOVE_SPEED_SET
                '    Axis_Moving_Method = PLCCOMMAND_THETA1_POSITION_METHOD_SET
                '    Axis_Move_Command = PLCCOMMAND_THETA1_MOVE_REQUEST
                '    Axis_Checking_Move = PLCCOMMAND_THETA1_STATE_CHK
                '    Axis_Complete_ACK = THETA1_MOVING_COMPLETE_ACK
                'ElseIf idx = 3 Then
                '    Axis_Speed_Command = PLCCOMMAND_THETA2_MOVE_SPEED_SET
                '    Axis_Moving_Method = PLCCOMMAND_THETA2_POSITION_METHOD_SET
                '    Axis_Move_Command = PLCCOMMAND_THETA2_MOVE_REQUEST
                '    Axis_Checking_Move = PLCCOMMAND_THETA2_STATE_CHK
                '    Axis_Complete_ACK = THETA2_MOVING_COMPLETE_ACK
                'ElseIf idx = 4 Then
                '    Axis_Speed_Command = PLCCOMMAND_THETA3_MOVE_SPEED_SET
                '    Axis_Moving_Method = PLCCOMMAND_THETA3_POSITION_METHOD_SET
                '    Axis_Move_Command = PLCCOMMAND_THETA3_MOVE_REQUEST
                '    Axis_Checking_Move = PLCCOMMAND_THETA3_STATE_CHK
                '    Axis_Complete_ACK = THETA3_MOVING_COMPLETE_ACK
                'ElseIf idx = 5 Then
                '    Axis_Speed_Command = PLCCOMMAND_THETA4_MOVE_SPEED_SET
                '    Axis_Moving_Method = PLCCOMMAND_THETA4_POSITION_METHOD_SET
                '    Axis_Move_Command = PLCCOMMAND_THETA4_MOVE_REQUEST
                '    Axis_Checking_Move = PLCCOMMAND_THETA4_STATE_CHK
                '    Axis_Complete_ACK = THETA4_MOVING_COMPLETE_ACK
            End If

            '알람이 있다면 클리어하고 진행한다.
            If MotionAlarmState(idx) = False Then
                AlarmClear()

                Application.DoEvents()
                Thread.Sleep(1000)

                If MotionAlarmState(idx) = True Then

                    ' 1. 축 속도 Set  ,속도는 임시
                    '홈은 속도 설정 필요없다.
                    ' If SetData(Axis_Speed_Command, 20.0) = False Then Return False

                    Thread.Sleep(1)

                    ' 2. 위치 명령 set
                    If SetData(Axis_Moving_Method, eMovingPosition.eHome, 1) = False Then Return False


                    ' 3. 축 이동전 위치명령 가능여부 확인
                    If Axis_Moving_Status(idx, eAxisStatus.eAxis_Can_Move) = False Then Return False

                    Thread.Sleep(1)

                    ' 4. 축이동 Request ON
                    If SetData(Axis_Move_Command, CShort(1)) = False Then Return False

                    Thread.Sleep(1)

                    ' 5 .축 이동 ACK 명령 확인
                    If Axis_Moving_Status(idx, eAxisStatus.eAxis_ACK) = False Then Return False

                    Thread.Sleep(1)

                    '6 .축 이동 Request OFF   '0날려줘야 실제 이동함
                    If SetData(Axis_Move_Command, CShort(0)) = False Then Return False
                    'If SetData(PLCCOMMAND_MOTION_HOMMING, CShort(0)) = False Then Return False

                    '7 축 이동 완료 ACK 신호
                    If SetData(Axis_Move_Command, Axis_Complete_ACK) = False Then Return False

                    '컴플리트 Ack


                Else
                    Return False
                End If
            Else
                ' 1. 축 속도 Set  ,속도는 임시 '처음에 무조건 requset를 off해줘야함
                If SetData(Axis_Move_Command, CShort(0)) = False Then Return False

                '홈은 속도 설정 필요없다.
                ' If SetData(Axis_Speed_Command, 20.0) = False Then Return False

                Thread.Sleep(1)

                ' 2. 위치 명령 set
                If SetData(Axis_Moving_Method, eMovingPosition.eHome, 1) = False Then Return False


                ' 3. 축 이동전 위치명령 가능여부 확인
                If Axis_Moving_Status(idx, eAxisStatus.eAxis_Can_Move) = False Then Return False

                Thread.Sleep(1)

                ' 4. 축이동 Request ON
                If SetData(Axis_Move_Command, CShort(1)) = False Then Return False

                Thread.Sleep(1)

                ' 5 .축 이동 ACK 명령 확인
                If Axis_Moving_Status(idx, eAxisStatus.eAxis_ACK) = False Then Return False

                Thread.Sleep(1)

                '6 .축 이동 Request OFF   '0날려줘야 실제 이동함
                If SetData(Axis_Move_Command, CShort(0)) = False Then Return False
                'If SetData(PLCCOMMAND_MOTION_HOMMING, CShort(0)) = False Then Return False

                '7. 축 이동 완료 ACK
                If SetData(Axis_Move_Command, Axis_Complete_ACK) = False Then Return False
            End If
        Next
        Return True
    End Function

    Public Overrides Function GetCurrentPosition(ByRef pos() As Double) As Boolean
        Dim nPosValue As Double
        ReDim pos(m_nTotalAxis - 1)

        '표기값으로 인해 나눠서 표기해야함
        If GetData(PLCCOMMAND_CURRENT_X_POSITION, nPosValue) = False Then Return False
        pos(0) = nPosValue / 1000

        If GetData(PLCCOMMAND_CURRENT_Y1_POSITION, nPosValue) = False Then Return False
        pos(1) = nPosValue / 1000

        If GetData(PLCCOMMAND_CURRENT_Y2_POSITION, nPosValue) = False Then Return False
        pos(2) = nPosValue / 1000

        If GetData(PLCCOMMAND_CURRENT_Z_POSITION, nPosValue) = False Then Return False
        pos(3) = nPosValue / 1000

        'If GetData(PLCCOMMAND_CURRENT_THETA1_POSITION, nPosValue) = False Then Return False

        'pos(2) = nPosValue / 1000
        'If GetData(PLCCOMMAND_CURRENT_THETA2_POSITION, nPosValue) = False Then Return False

        'pos(3) = nPosValue / 1000
        'If GetData(PLCCOMMAND_CURRENT_THETA3_POSITION, nPosValue) = False Then Return False

        'pos(4) = nPosValue / 1000
        'If GetData(PLCCOMMAND_CURRENT_THETA4_POSITION, nPosValue) = False Then Return False

        'pos(5) = nPosValue / 1000
        Return True
    End Function
    Public Overrides Function MoveCompleted() As Boolean
        Dim sStateVal As String = Nothing

        If MoveCompleted(0) = True And
            MoveCompleted(1) = True And
            MoveCompleted(2) = True Then
            Return True
        Else
            Return False
        End If

        'If GetData(PLCCOMMAND_MOTION_MOVE_DONE_X, sStateVal) = False Then Return False
        'If CInt(sStateVal) = 15 Then Return True
        'Return False

    End Function
    Public Overrides Function SetMoveComplete(ByVal axis As Integer) As Boolean
        Dim sStateVal As String = Nothing

        Select Case axis
            Case 0
                If SetData(PLCCOMMAND_X_MOVE_REQUEST, X_MOVING_COMPLETE_ACK) = False Then Return False
            Case 1
                If SetData(PLCCOMMAND_Y_MOVE_REQUEST, Y_MOVING_COMPLETE_ACK) = False Then Return False
            Case 2
                If SetData(PLCCOMMAND_Z_MOVE_REQUEST, Z_MOVING_COMPLETE_ACK) = False Then Return False
                'Case 2
                '    If SetData(PLCCOMMAND_THETA1_MOVE_REQUEST, THETA1_MOVING_COMPLETE_ACK) = False Then Return False
                'Case 3
                '    If SetData(PLCCOMMAND_THETA2_MOVE_REQUEST, THETA2_MOVING_COMPLETE_ACK) = False Then Return False
                'Case 4
                '    If SetData(PLCCOMMAND_THETA3_MOVE_REQUEST, THETA3_MOVING_COMPLETE_ACK) = False Then Return False
                'Case 5
                '    If SetData(PLCCOMMAND_THETA4_MOVE_REQUEST, THETA4_MOVING_COMPLETE_ACK) = False Then Return False
        End Select

        Return True
    End Function
    Public Overrides Function MoveCompleted(ByVal axis As Integer) As Boolean
        Dim sStateVal As String = Nothing

        Select Case axis

            'Case 0
            '    If Axis_Moving_Status(0, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 0
                If Axis_Moving_Status(0, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 1
                If Axis_Moving_Status(1, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 2
                If Axis_Moving_Status(2, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 3
                If Axis_Moving_Status(3, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 4
                If Axis_Moving_Status(4, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
            Case 5
                If Axis_Moving_Status(5, eAxisStatus.eAxis_ACK_Moving_Complete) = False Then Return False
        End Select

        Return True
    End Function

    Public Overrides Function JOG_MOVE_STOP() As Boolean
        ' If SetData(PLCCOMMAND_JOG_X_MOVE, CShort(0)) = False Then Return False

        If SetData(PLCCOMMAND_JOG_X_MOVE, CShort(0)) = False Then Return False

        If SetData(PLCCOMMAND_JOG_Y_MOVE, CShort(0)) = False Then Return False

        If SetData(PLCCOMMAND_JOG_Z_MOVE, CShort(0)) = False Then Return False

        'If SetData(PLCCOMMAND_JOG_THETA1_MOVE, CShort(0)) = False Then Return False

        'If SetData(PLCCOMMAND_JOG_THETA2_MOVE, CShort(0)) = False Then Return False

        'If SetData(PLCCOMMAND_JOG_THETA3_MOVE, CShort(0)) = False Then Return False

        'If SetData(PLCCOMMAND_JOG_THETA4_MOVE, CShort(0)) = False Then Return False

        Return True
    End Function
    Public Overrides Function JogXRMove(ByVal vel As Double) As Boolean
        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(0) = False Then Return False
        ' SetData(PLCCOMMAND_JOG_X_MOVE, CShort(0))
        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_X_SPEED_SET, vel) = False Then Return False

        '3 조그 이동
        If SetData(PLCCOMMAND_JOG_X_MOVE, CShort(2)) = False Then Return False

        Return True

    End Function


    Public Overrides Function JogXLMove(ByVal vel As Double) As Boolean

        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(0) = False Then Return False

        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_X_SPEED_SET, vel) = False Then Return False

        '3 조그 이동
        If SetData(PLCCOMMAND_JOG_X_MOVE, CShort(1)) = False Then Return False
        Return True
    End Function

    Public Overrides Function JogYuPMove(ByVal vel As Double) As Boolean

        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(0) = False Then Return False

        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_Y_SPEED_SET, vel) = False Then Return False

        '3. 조그 이동
        If SetData(PLCCOMMAND_JOG_Y_MOVE, CShort(2)) = False Then Return False

        Return True
    End Function

    Public Overrides Function JogYDownMove(ByVal vel As Double) As Boolean
        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(0) = False Then Return False

        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_Y_SPEED_SET, vel) = False Then Return False

        '3. 조그 이동
        If SetData(PLCCOMMAND_JOG_Y_MOVE, CShort(1)) = False Then Return False

        Return True

    End Function

    Public Overrides Function JogZUpMove(ByVal vel As Double) As Boolean
        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(1) = False Then Return False

        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_Z_SPEED_SET, vel) = False Then Return False

        '3. 조그 이동
        If SetData(PLCCOMMAND_JOG_Z_MOVE, CShort(2)) = False Then Return False

        Return True
    End Function

    Public Overrides Function JogZDownMove(ByVal vel As Double) As Boolean
        '1. 조그 운전 가능 여부 확인
        If JOG_Can_Move(1) = False Then Return False

        '2. 조그 속도 지정
        If SetData(PLCCOMMAND_JOG_Z_SPEED_SET, vel) = False Then Return False

        '3. 조그 이동
        If SetData(PLCCOMMAND_JOG_Z_MOVE, CShort(1)) = False Then Return False

        Return True
    End Function

    'Public Overrides Function JogTheta1UpMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(2) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA1_MOVE, CShort(2)) = False Then Return False

    '    Return True
    'End Function

    'Public Overrides Function JogTheta1DownMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(2) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA1_MOVE, CShort(1)) = False Then Return False

    '    Return True
    'End Function
    'Public Overrides Function JogTheta2UpMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(3) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA2_MOVE, CShort(2)) = False Then Return False

    '    Return True
    'End Function

    'Public Overrides Function JogTheta2DownMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(3) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA2_MOVE, CShort(1)) = False Then Return False

    '    Return True
    'End Function
    'Public Overrides Function JogTheta3UpMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(4) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA3_MOVE, CShort(2)) = False Then Return False

    '    Return True
    'End Function

    'Public Overrides Function JogTheta3DownMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(4) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA3_MOVE, CShort(1)) = False Then Return False

    '    Return True
    'End Function
    'Public Overrides Function JogTheta4UpMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(5) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA4_MOVE, CShort(2)) = False Then Return False

    '    Return True
    'End Function

    'Public Overrides Function JogTheta4DownMove(ByVal vel As Double) As Boolean
    '    '1. 조그 운전 가능 여부 확인
    '    If JOG_Can_Move(5) = False Then Return False

    '    '2. 조그 속도 지정
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, vel) = False Then Return False

    '    '3. 조그 이동
    '    If SetData(PLCCOMMAND_JOG_THETA4_MOVE, CShort(1)) = False Then Return False

    '    Return True
    'End Function



    Public Overrides Function Jog_Mode_On() As Boolean

        ' 1. STOP 전환 전에 리셋 필요
        If SetRunState(eRunState.eReset) = False Then Return False

        ' 2. STOP전환
        If SetRunState(eRunState.eStop) = False Then Return False

        Application.DoEvents()
        Thread.Sleep(2000) 'STOP전환 후 대기 시간 필요함

        ' 3. 메뉴얼 모드로 전환
        If Can_ChangeMode() = True Then
            If SetChangeMode(eRunningMode.eManual) = False Then Return False
        Else
            Return False
        End If

        Return True
    End Function
    Public Overrides Function Jog_Mode_On_Teach() As Boolean

        ' 1. STOP 전환 전에 리셋 필요
        If SetRunState(eRunState.eReset) = False Then Return False

        ' 2. STOP전환
        If SetRunState(eRunState.eStop) = False Then Return False

        Application.DoEvents()
        Thread.Sleep(2000) 'STOP전환 후 대기 시간 필요함

        ' 3. 메뉴얼 모드로 전환
        ' If Can_ChangeMode() = True Then
        ' If SetChangeMode(eRunningMode.eManual) = False Then Return False
        'Else
        ' Return False
        ' End If

        'Manual
        If SetData(PLCCOMMAND_SET_MODE, CShort(1)) = False Then Return False

        Return True
    End Function

    Public Overrides Function Jog_Mode_Off_Auto() As Boolean

        ' 1. 메뉴얼 모드로 전환
        'If Can_ChangeMode() = True Then
        ' If SetChangeMode(eRunningMode.eAuto) = False Then Return False
        'Else
        'Return False
        'End If
        If SetData(PLCCOMMAND_SET_MODE, CShort(2)) = False Then Return False

        ' 2. STOP 전환 전에 리셋 필요
        If SetRunState(eRunState.eReset) = False Then Return False

        ' 3. STOP전환
        If SetRunState(eRunState.eRun) = False Then Return False

        Application.DoEvents()
        Thread.Sleep(2000) 'STOP전환 후 대기 시간 필요함

        Return True
    End Function
    Public Overrides Function Jog_Mode_Off() As Boolean

        ' 1. 메뉴얼 모드로 전환
        If Can_ChangeMode() = True Then
            If SetChangeMode(eRunningMode.eAuto) = False Then Return False
        Else
            Return False
        End If

        ' 2. STOP 전환 전에 리셋 필요
        If SetRunState(eRunState.eReset) = False Then Return False

        ' 3. STOP전환
        If SetRunState(eRunState.eRun) = False Then Return False

        Application.DoEvents()
        Thread.Sleep(2000) 'STOP전환 후 대기 시간 필요함

        Return True
    End Function
    Public Function JOG_Can_Move(ByVal nAxis As Integer) As Boolean
        Dim sRcvData As String = Nothing
        Dim PLC_Command As String = Nothing
        If nAxis = 0 Then
            PLC_Command = PLCCOMMAND_JOG_X_MOVE_CHK
        ElseIf nAxis = 1 Then
            PLC_Command = PLCCOMMAND_JOG_Y_MOVE_CHK
        ElseIf nAxis = 2 Then
            PLC_Command = PLCCOMMAND_JOG_Z_MOVE_CHK
            'ElseIf nAxis = 2 Then
            '    PLC_Command = PLCCOMMAND_JOG_THETA1_MOVE_CHK
            'ElseIf nAxis = 3 Then
            '    PLC_Command = PLCCOMMAND_JOG_THETA2_MOVE_CHK
            'ElseIf nAxis = 4 Then
            '    PLC_Command = PLCCOMMAND_JOG_THETA3_MOVE_CHK
            'ElseIf nAxis = 5 Then
            '    PLC_Command = PLCCOMMAND_JOG_THETA4_MOVE_CHK
        End If

        If GetData(PLC_Command, sRcvData) = False Then Return False
        If sRcvData = "0" Then
            Return False
        Else
            Dim nBinery() As Integer = Nothing

            nBinery = hex2bin(sRcvData)
            If nBinery(0) = 1 Then
                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function
    Public Overrides Function SetJogXVelocity(ByVal Velocity As Double) As Boolean
        If SetData(PLCCOMMAND_JOG_X_SPEED_SET, Velocity) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetJogYVelocity(ByVal Velocity As Double) As Boolean
        If SetData(PLCCOMMAND_JOG_Y_SPEED_SET, Velocity) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetJogZVelocity(ByVal Velocity As Double) As Boolean
        If SetData(PLCCOMMAND_JOG_Z_SPEED_SET, Velocity) = False Then Return False
        Return True
    End Function

    'Public Overrides Function SetJogThetaVelocity(ByVal Velocity As Double) As Boolean
    '    If SetData(PLCCOMMAND_JOG_THETA_SPEED_SET, Velocity) = False Then Return False
    '    Return True
    'End Function

    'Public Overrides Function PositionMoveX(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
    '    '1. X축 속도 지정
    '    If SetData(PLCCOMMAND_X_MOVE_SPEED_SET, vel) = False Then Return False

    '    '2. X축 위치 명령
    '    If MoveMethod = eMovingMethod.eABS Then
    '        If SetData(PLCCOMMAND_X_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
    '    Else
    '        If SetData(PLCCOMMAND_X_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
    '    End If

    '    '2-1. X축 위치 결정
    '    If SetData(PLCCOMMAND_X_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

    '    '3. X축 위치 명령
    '    If SetData(PLCCOMMAND_X_MOVE_POSITION_SET, pos) = False Then Return False

    '    '4. X축 명령 가능 여부 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eX, eAxisStatus.eAxis_Can_Move) = False Then Return False

    '    '5. X축 위치 명령 Request
    '    If SetData(PLCCOMMAND_X_MOVE_REQUEST, CShort(1)) = False Then Return False

    '    '6 x축 ACK 신호 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eX, eAxisStatus.eAxis_ACK) = False Then Return False

    '    '7. X축 위치 명령 Request off
    '    If SetData(PLCCOMMAND_X_MOVE_REQUEST, CShort(0)) = False Then Return False

    '    Return True
    'End Function
    Public Overrides Function PositionMoveX(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

        '1. X축 속도 지정
        If SetData(PLCCOMMAND_X_MOVE_SPEED_SET, vel) = False Then Return False

        '2. X축 이동 명령
        If MoveMethod = eMovingMethod.eABS Then
            If SetData(PLCCOMMAND_X_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
        Else
            If SetData(PLCCOMMAND_X_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
        End If

        '2-1. X축 위치 결정
        If SetData(PLCCOMMAND_X_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

        '3. X축 위치 명령
        If SetData(PLCCOMMAND_X_MOVE_POSITION_SET, pos) = False Then Return False

        '4. X축 명령 가능 여부 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eX, eAxisStatus.eAxis_Can_Move) = False Then Return False

        '5. X축 위치 명령 Request
        If SetData(PLCCOMMAND_X_MOVE_REQUEST, CShort(1)) = False Then Return False

        '6  X축 ACK 신호 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eX, eAxisStatus.eAxis_ACK) = False Then Return False

        '7. X축 위치 명령 Request off
        If SetData(PLCCOMMAND_X_MOVE_REQUEST, CShort(0)) = False Then Return False

        Return True

    End Function
    Public Overrides Function PositionMoveY(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

        '1. Y축 속도 지정
        If SetData(PLCCOMMAND_Y_MOVE_SPEED_SET, vel) = False Then Return False

        '2. Y축 이동 명령
        If MoveMethod = eMovingMethod.eABS Then
            If SetData(PLCCOMMAND_Y_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
        Else
            If SetData(PLCCOMMAND_Y_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
        End If

        '2-1. Y축 위치 결정
        If SetData(PLCCOMMAND_Y_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

        '3. Y축 위치 명령
        If SetData(PLCCOMMAND_Y_MOVE_POSITION_SET, pos) = False Then Return False

        '4. Y축 명령 가능 여부 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eY, eAxisStatus.eAxis_Can_Move) = False Then Return False

        '5. Y축 위치 명령 Request
        If SetData(PLCCOMMAND_Y_MOVE_REQUEST, CShort(1)) = False Then Return False

        '6  Y축 ACK 신호 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eY, eAxisStatus.eAxis_ACK) = False Then Return False

        '7. Y축 위치 명령 Request off
        If SetData(PLCCOMMAND_Y_MOVE_REQUEST, CShort(0)) = False Then Return False

        Return True

    End Function

    Public Overrides Function PositionMoveZ(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

        '1. Z축 속도 지정
        If SetData(PLCCOMMAND_Z_MOVE_SPEED_SET, vel) = False Then Return False

        '2. Z축 이동 명령
        If MoveMethod = eMovingMethod.eABS Then
            If SetData(PLCCOMMAND_Z_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
        Else
            If SetData(PLCCOMMAND_Z_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
        End If

        '2-1. Z축 위치 결정
        If SetData(PLCCOMMAND_Z_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

        '3. Z축 위치 명령
        If SetData(PLCCOMMAND_Z_MOVE_POSITION_SET, pos) = False Then Return False

        '4. Z축 명령 가능 여부 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eZ, eAxisStatus.eAxis_Can_Move) = False Then Return False

        '5. Z축 위치 명령 Request
        If SetData(PLCCOMMAND_Z_MOVE_REQUEST, CShort(1)) = False Then Return False

        '6  Z축 ACK 신호 확인
        If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eZ, eAxisStatus.eAxis_ACK) = False Then Return False

        '7. Z축 위치 명령 Request off
        If SetData(PLCCOMMAND_Z_MOVE_REQUEST, CShort(0)) = False Then Return False

        Return True
    End Function

    'Public Overrides Function PositionMoveTheta1(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

    '    '1. Y축 속도 지정
    '    If SetData(PLCCOMMAND_THETA1_MOVE_SPEED_SET, vel) = False Then Return False

    '    '2. Y축 이동 명령
    '    If MoveMethod = eMovingMethod.eABS Then
    '        If SetData(PLCCOMMAND_THETA1_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
    '    Else
    '        If SetData(PLCCOMMAND_THETA1_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
    '    End If

    '    '2-1. Y축 위치 결정
    '    If SetData(PLCCOMMAND_THETA1_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

    '    '3. Y축 위치 명령
    '    If SetData(PLCCOMMAND_THETA1_MOVE_POSITION_SET, pos) = False Then Return False

    '    '4. Y축 명령 가능 여부 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA1, eAxisStatus.eAxis_Can_Move) = False Then Return False

    '    '5. Y축 위치 명령 Request
    '    If SetData(PLCCOMMAND_THETA1_MOVE_REQUEST, CShort(1)) = False Then Return False

    '    '6  Y축 ACK 신호 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA1, eAxisStatus.eAxis_ACK) = False Then Return False

    '    '7. Y축 위치 명령 Request off
    '    If SetData(PLCCOMMAND_THETA1_MOVE_REQUEST, CShort(0)) = False Then Return False

    '    Return True

    'End Function
    'Public Overrides Function PositionMoveTheta2(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

    '    '1. Y축 속도 지정
    '    If SetData(PLCCOMMAND_THETA2_MOVE_SPEED_SET, vel) = False Then Return False

    '    '2. Y축 이동 명령
    '    If MoveMethod = eMovingMethod.eABS Then
    '        If SetData(PLCCOMMAND_THETA2_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
    '    Else
    '        If SetData(PLCCOMMAND_THETA2_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
    '    End If

    '    '2-1. Y축 위치 결정
    '    If SetData(PLCCOMMAND_THETA2_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

    '    '3. Y축 위치 명령
    '    If SetData(PLCCOMMAND_THETA2_MOVE_POSITION_SET, pos) = False Then Return False

    '    '4. Y축 명령 가능 여부 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA2, eAxisStatus.eAxis_Can_Move) = False Then Return False

    '    '5. Y축 위치 명령 Request
    '    If SetData(PLCCOMMAND_THETA2_MOVE_REQUEST, CShort(1)) = False Then Return False

    '    '6  Y축 ACK 신호 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA2, eAxisStatus.eAxis_ACK) = False Then Return False

    '    '7. Y축 위치 명령 Request off
    '    If SetData(PLCCOMMAND_THETA2_MOVE_REQUEST, CShort(0)) = False Then Return False

    '    Return True

    'End Function
    'Public Overrides Function PositionMoveTheta3(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

    '    '1. Y축 속도 지정
    '    If SetData(PLCCOMMAND_THETA3_MOVE_SPEED_SET, vel) = False Then Return False

    '    '2. Y축 이동 명령
    '    If MoveMethod = eMovingMethod.eABS Then
    '        If SetData(PLCCOMMAND_THETA3_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
    '    Else
    '        If SetData(PLCCOMMAND_THETA3_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
    '    End If

    '    '2-1. Y축 위치 결정
    '    If SetData(PLCCOMMAND_THETA3_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

    '    '3. Y축 위치 명령
    '    If SetData(PLCCOMMAND_THETA3_MOVE_POSITION_SET, pos) = False Then Return False

    '    '4. Y축 명령 가능 여부 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA3, eAxisStatus.eAxis_Can_Move) = False Then Return False

    '    '5. Y축 위치 명령 Request
    '    If SetData(PLCCOMMAND_THETA3_MOVE_REQUEST, CShort(1)) = False Then Return False

    '    '6  Y축 ACK 신호 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA3, eAxisStatus.eAxis_ACK) = False Then Return False

    '    '7. Y축 위치 명령 Request off
    '    If SetData(PLCCOMMAND_THETA3_MOVE_REQUEST, CShort(0)) = False Then Return False

    '    Return True

    'End Function

    'Public Overrides Function PositionMoveTheta4(ByVal pos As Double, ByVal vel As Double, ByVal MoveMethod As CDevPLCCommonNode.eMovingMethod) As Boolean

    '    '1. Y축 속도 지정
    '    If SetData(PLCCOMMAND_THETA4_MOVE_SPEED_SET, vel) = False Then Return False

    '    '2. Y축 이동 명령
    '    If MoveMethod = eMovingMethod.eABS Then
    '        If SetData(PLCCOMMAND_THETA4_MOVING_METHOD_SET, eMovingMethod.eABS, 1) = False Then Return False
    '    Else
    '        If SetData(PLCCOMMAND_THETA4_MOVING_METHOD_SET, eMovingMethod.eINC, 1) = False Then Return False
    '    End If

    '    '2-1. Y축 위치 결정
    '    If SetData(PLCCOMMAND_THETA4_POSITION_METHOD_SET, eMovingPosition.ePosition, 1) = False Then Return False

    '    '3. Y축 위치 명령
    '    If SetData(PLCCOMMAND_THETA4_MOVE_POSITION_SET, pos) = False Then Return False

    '    '4. Y축 명령 가능 여부 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA4, eAxisStatus.eAxis_Can_Move) = False Then Return False

    '    '5. Y축 위치 명령 Request
    '    If SetData(PLCCOMMAND_THETA4_MOVE_REQUEST, CShort(1)) = False Then Return False

    '    '6  Y축 ACK 신호 확인
    '    If Axis_Moving_Status(CDevPLCCommonNode.eAxis.eTHETA4, eAxisStatus.eAxis_ACK) = False Then Return False

    '    '7. Y축 위치 명령 Request off
    '    If SetData(PLCCOMMAND_THETA4_MOVE_REQUEST, CShort(0)) = False Then Return False

    '    Return True

    'End Function
    Public Overrides Function SetCompleteACK(ByVal Axis As CDevPLCCommonNode.eAxis) As Boolean
        If Axis = eAxis.eX Then
            If SetData(PLCCOMMAND_X_MOVE_REQUEST, X_MOVING_COMPLETE_ACK) = False Then Return False
        ElseIf Axis = eAxis.eY Then
        If SetData(PLCCOMMAND_Y_MOVE_REQUEST, Y_MOVING_COMPLETE_ACK) = False Then Return False
        ElseIf Axis = eAxis.eZ Then
            If SetData(PLCCOMMAND_Z_MOVE_REQUEST, Z_MOVING_COMPLETE_ACK) = False Then Return False
            'ElseIf Axis = eAxis.eTHETA1 Then
            '    If SetData(PLCCOMMAND_THETA1_MOVE_REQUEST, THETA1_MOVING_COMPLETE_ACK) = False Then Return False
            'ElseIf Axis = eAxis.eTHETA2 Then
            '    If SetData(PLCCOMMAND_THETA2_MOVE_REQUEST, THETA2_MOVING_COMPLETE_ACK) = False Then Return False
            'ElseIf Axis = eAxis.eTHETA3 Then
            '    If SetData(PLCCOMMAND_THETA3_MOVE_REQUEST, THETA3_MOVING_COMPLETE_ACK) = False Then Return False
            'ElseIf Axis = eAxis.eTHETA4 Then
            '    If SetData(PLCCOMMAND_THETA4_MOVE_REQUEST, THETA4_MOVING_COMPLETE_ACK) = False Then Return False
        End If
        Return True
    End Function
    'Public Function SetSupplySlotNumber(ByVal nSlotNo As Integer) As Boolean
    '    If SetData(PLCCOMMAND_SUPPLY_SLOT_NO_SET, CShort(nSlotNo)) = False Then Return False
    '    Return True
    'End Function
    'Public Function SetExhaustSlotNumber(ByVal nSlotNo As Integer) As Boolean
    '    If SetData(PLCCOMMAND_EXHAUST_SLOT_NO_SET, CShort(nSlotNo)) = False Then Return False
    '    Return True
    'End Function

    'Public Function SetSupplyRequest(ByVal bOnOff As Boolean) As Boolean
    '    If bOnOff = True Then
    '        If SetData(PLCCOMMAND_SUPPLY_REQUEST, CShort(1)) = False Then Return False
    '    ElseIf bOnOff = False Then
    '        If SetData(PLCCOMMAND_SUPPLY_REQUEST, CShort(0)) = False Then Return False
    '    End If
    '    Return True
    'End Function

    'Public Function SetExhaustRequest(ByVal bOnOff As Boolean) As Boolean
    '    If bOnOff = True Then
    '        If SetData(PLCCOMMAND_EXHAUST_REQUEST, CShort(1)) = False Then Return False
    '    ElseIf bOnOff = False Then
    '        If SetData(PLCCOMMAND_EXHAUST_REQUEST, CShort(0)) = False Then Return False
    '    End If
    '    Return True
    'End Function

    'Public Overrides Function SetSlotSupply(ByVal nSlotNo As Integer) As Boolean

    '    '투입 연속 동작 가능 상태 조회
    '    If Slot_Moving_Status(eSlot.eSupply, eSlotMovingStatus.eSlot_Can_Move) = False Then
    '        Return False
    '    End If


    '    '투입 연속 동작 SLOT NO. 지정
    '    If SetSupplySlotNumber(nSlotNo) = False Then
    '        Return False
    '    End If


    '    '투입 연속 동작 Request
    '    If SetSupplyRequest(True) = False Then
    '        Return False
    '    End If


    '    '투입 연속 동작 ACK 신호 확인
    '    If Slot_Moving_Status(eSlot.eSupply, eSlotMovingStatus.eSlot_ACK) = False Then
    '        Return False
    '    End If


    '    '투입 연속 동작 Request OFF
    '    If SetSupplyRequest(False) = False Then
    '        Return False
    '    End If


    '    Return True
    'End Function

    'Public Overrides Function SetSlotExhaust(ByVal nSlotNo As Integer) As Boolean

    '    '배출 연속 동작 가능 상태 조회
    '    If Slot_Moving_Status(eSlot.eExhaust, eSlotMovingStatus.eSlot_Can_Move) = False Then Return False

    '    '배출 동작 SLOT NO. 지정
    '    If SetExhaustSlotNumber(nSlotNo) = False Then Return False

    '    '배출 연속 동작 Request
    '    If SetExhaustRequest(True) = False Then Return False

    '    '배출 연속 동작 ACK 신호 확인
    '    If Slot_Moving_Status(eSlot.eExhaust, eSlotMovingStatus.eSlot_ACK) = False Then Return False

    '    '배출 연속 동작 Request OFF
    '    If SetExhaustRequest(False) = False Then Return False

    '    Return True

    'End Function

    'Public Overrides Function GetSupplyMoveCompleted(ByRef bComplete As Boolean) As Boolean
    '    Dim sRcvData As String = Nothing
    '    If GetData(PLCCOMMAND_SUPPLY_STATUS_CHK, sRcvData) = False Then Return False
    '    If sRcvData = 0 Then bComplete = False
    '    If sRcvData = 1 Then bComplete = True
    '    Return True
    'End Function
    'Public Overrides Function GetExhaustMoveCompleted(ByRef bComplete As Boolean) As Boolean

    '    Dim sRcvData As String = Nothing
    '    If GetData(PLCCOMMAND_EXHAUST_STATUS_CHK, sRcvData) = False Then Return False
    '    If sRcvData = 0 Then bComplete = False
    '    If sRcvData = 1 Then bComplete = True
    '    Return True

    'End Function
#End Region

End Class
