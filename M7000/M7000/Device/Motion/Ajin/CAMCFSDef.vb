Option Strict Off
Option Explicit On 

Module CAMCFSDef
    ''/*-------------------------------------------------------------------------------------------------*
    ' *        CAMC-FS (SMC-1V02, SMC-2V02)                                                             *
    ' *-------------------------------------------------------------------------------------------------*/

    ''/*-------------------------------------------------------------------------------------------------*
    ' *        CAMC-5M, CAMC-FS 1.0 / 2.0에서 공통으로 사용하는 매크로...                               *
    ' *-------------------------------------------------------------------------------------------------*/

    '/* Type 설정	*/

    Public Const POSITIVE_SENSE = 1
    Public Const NEGATIVE_SENSE = -1

    ' 2004년 3월 8일 안병건 추가
    Public Const MASTER = 1
    Public Const SLAVE = 0

    ' 2004년 3월 9일 안병건 추가
    Public Const UI4 = 0
    Public Const UI5 = 0
    Public Const JOG = 1
    Public Const MARK = 2


    Public Const DRIVE1 = 1
    Public Const DRIVE2 = 2
    Public Const DRIVE3 = 3


    Public Const DIFF_INPUT = &H0             ' Differential input
    Public Const LEVEL_INPUT = &H1             ' Level input


    Public Const Phase = &H0             ' 단상
    Public Const Mode1 = &H1             ' 1체배
    Public Const Mode2 = &H2             ' 2체배
    Public Const Mode4 = &H3             ' 4체배

    '/* Main clock							*/
    Public Const F_33M_CLK = 33000000           ' 33.000 MHz 
    Public Const F_32_768M_CLK = 32768000          ' 32.768 MHz 
    Public Const F_20M_CLK = 20000000           ' 20.000 MHz 
    Public Const F_16_384M_CLK = 16384000          ' 16.384 MHz : Default 

    ''/* MODE1 DATA							
    ' *
    ' *	감속 개시 POINT 검출 방식
    ' */

    Public Const AutoDetect = &H0
    Public Const RestPulse = &H1

    '/* Pulse Output Method					*/

    Public Const OneHighLowHigh = &H0           ' 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
    Public Const OneHighHighLow = &H1           ' 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
    Public Const OneLowLowHigh = &H2           ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
    Public Const OneLowHighLow = &H3           ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
    Public Const TwoCcwCwHigh = &H4            ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High	 
    Public Const TwoCcwCwLow = &H5            ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low	 
    Public Const TwoCwCcwHigh = &H6            ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
    Public Const TwoCwCcwLow = &H7            ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low

    '/* Detect Destination Signal			*/

    Public Const PElmNegativeEdge = &H0           ' +Elm(End limit) 하강 edge
    Public Const NElmNegativeEdge = &H1           ' -Elm(End limit) 하강 edge
    Public Const PSlmNegativeEdge = &H2           ' +Slm(Slowdown limit) 하강 edge
    Public Const NSlmNegativeEdge = &H3           ' -Slm(Slowdown limit) 하강 edge
    Public Const In0DownEdge = &H4            ' IN0(ORG) 하강 edge
    Public Const In1DownEdge = &H5            ' IN1(Z상) 하강 edge
    Public Const In2DownEdge = &H6            ' IN2(범용) 하강 edge
    Public Const In3DownEdge = &H7            ' IN3(범용) 하강 edge
    Public Const PElmPositiveEdge = &H8           ' +Elm(End limit) 상승 edge
    Public Const NElmPositiveEdge = &H9           ' -Elm(End limit) 상승 edge
    Public Const PSlmPositiveEdge = &HA           ' +Slm(Slowdown limit) 상승 edge
    Public Const NSlmPositiveEdge = &HB           ' -Slm(Slowdown limit) 상승 edge
    Public Const In0UpEdge = &HC            ' IN0(ORG) 상승 edge
    Public Const In1UpEdge = &HD            ' IN1(Z상) 상승 edge
    Public Const In2UpEdge = &HE            ' IN2(범용) 상승 edge
    Public Const In3UpEdge = &HF            ' IN3(범용) 상승 edge

    ''/* Mode2 Data   
    ' * External Counter Input 
    ' */

    Public Const UpDownMode = &H0            ' Up/Down
    Public Const Sqr1Mode = &H1             ' 1체배
    Public Const Sqr2Mode = &H2             ' 2체배
    Public Const Sqr4Mode = &H3             ' 4체배


    Public Const InpActiveLow = 0
    Public Const InpActiveHigh = 1


    Public Const AlmActiveLow = 0
    Public Const AlmActiveHigh = 1


    Public Const NSlmActiveLow = 0
    Public Const NSlmActiveHigh = 1


    Public Const PSlmActiveLow = 0
    Public Const PSlmActiveHigh = 1


    Public Const NElmActiveLow = 0
    Public Const NElmActiveHigh = 1


    Public Const PElmActiveLow = 0
    Public Const PElmActiveHigh = 1

    '/* Universal Input/Output				*/

    Public Const US_OUT0 = &H1
    Public Const US_OUT1 = &H2
    Public Const US_OUT2 = &H4
    Public Const US_OUT3 = &H8
    Public Const US_IN0 = &H10
    Public Const US_IN1 = &H20
    Public Const US_IN2 = &H40
    Public Const US_IN3 = &H80

    '/* BOARD SELECT							*/
    Public Const BASE_ADDR = 0
    Public Const BOARD0_BASE_ADDR = 0
    Public Const BOARD1_BASE_ADDR = 1
    Public Const BOARD2_BASE_ADDR = 2
    Public Const BOARD3_BASE_ADDR = 3
    Public Const BOARD4_BASE_ADDR = 4
    Public Const BOARD5_BASE_ADDR = 5
    Public Const BOARD6_BASE_ADDR = 6
    Public Const BOARD7_BASE_ADDR = 7

    '/* CAMC CHIP SELECT						*/

    Public Const CCA_CAMC0_ADDR = &H0
    Public Const CCA_CAMC1_ADDR = &H10
    Public Const CCA_CAMC2_ADDR = &H20
    Public Const CCA_CAMC3_ADDR = &H30
    Public Const CCA_CAMC4_ADDR = &H40
    Public Const CCA_CAMC5_ADDR = &H50
    Public Const CCA_CAMC6_ADDR = &H60
    Public Const CCA_CAMC7_ADDR = &H70

    '/* CHIP SELECT		*/

    Public Const CS_CAMC0 = &H0
    Public Const CS_CAMC1 = &H1
    Public Const CS_CAMC2 = &H2
    Public Const CS_CAMC3 = &H3
    Public Const CS_CAMC4 = &H4
    Public Const CS_CAMC5 = &H5
    Public Const CS_CAMC6 = &H6
    Public Const CS_CAMC7 = &H7
    Public Const CS_CAMC8 = &H8
    Public Const CS_CAMC9 = &H9
    Public Const CS_CAMC10 = &HA
    Public Const CS_CAMC11 = &HB
    Public Const CS_CAMC12 = &HC
    Public Const CS_CAMC13 = &HD
    Public Const CS_CAMC14 = &HE
    Public Const CS_CAMC15 = &HF
    Public Const CS_CAMC16 = &H10
    Public Const CS_CAMC17 = &H11
    Public Const CS_CAMC18 = &H12
    Public Const CS_CAMC19 = &H13
    Public Const CS_CAMC20 = &H14
    Public Const CS_CAMC21 = &H15
    Public Const CS_CAMC22 = &H16
    Public Const CS_CAMC23 = &H17
    Public Const CS_CAMC24 = &H18
    Public Const CS_CAMC25 = &H19
    Public Const CS_CAMC26 = &H1A
    Public Const CS_CAMC27 = &H1B
    Public Const CS_CAMC28 = &H1C
    Public Const CS_CAMC29 = &H1D
    Public Const CS_CAMC30 = &H1E
    Public Const CS_CAMC31 = &H1F

    '/*	AMCS Board 추가		*/
    '/*	2000년 12월 16일	*/
    '/*	작성자 : 이성재		*/

    Public Const AMC1X = &H1
    Public Const AMC2X = &H2
    Public Const AMC3X = &H3
    Public Const AMC4X = &H4
    Public Const AMC6X = &H6
    Public Const AMC8X = &H8

    '/*----------------------------------------------------------------------*/
    '/*						칩 초기화 구조체								*/
    '/*----------------------------------------------------------------------*/

    '/*----------------------------------------------------------------------*/
    '/*						이동방향										*/
    '/*----------------------------------------------------------------------*/

    Public Const MoveLeft = -1
    Public Const MoveRight = 1

    '/////////////////////////////////////////////////////
    ' 2005/08/11 김민호 수정
    ' CAMC5MDef.h 와의 충돌에 의해 위치 변경

    Public Const SLAVE_MODE = 1
    Public Const PRST_DRV_MODE = 2
    Public Const CONT_DRV_MODE = 4
    '//////////////////////////////////////////////////////

    '/* Write port							*/

    Public Const FsData1Write = &H0
    Public Const FsData2Write = &H1
    Public Const FsData3Write = &H2
    Public Const FsData4Write = &H3
    Public Const FsCommandWrite = &H4

    '/* Read port							*/

    Public Const FsData1Read = &H0
    Public Const FsData2Read = &H1
    Public Const FsData3Read = &H2
    Public Const FsData4Read = &H3
    Public Const FsCommandRead = &H4

    '/* FS Universal Input/Output			*/

    Public Const FSUS_OUT0 = &H1               ' Bit 0
    Public Const FSUS_SVON = &H1               ' Bit 0, Servo ON
    Public Const FSUS_OUT1 = &H2               ' Bit 1
    Public Const FSUS_ALMC = &H2               ' Bit 1, Alarm Clear
    Public Const FSUS_OUT2 = &H4               ' Bit 2
    Public Const FSUS_OUT3 = &H8               ' Bit 3
    Public Const FSUS_IN0 = &H10              ' Bit 4
    Public Const FSUS_ORG = &H10              ' Bit 4, Origin
    Public Const FSUS_IN1 = &H20              ' Bit 5
    Public Const FSUS_PZ = &H20              ' Bit 5, Encoder Z상
    Public Const FSUS_IN2 = &H40              ' Bit 6
    Public Const FSUS_IN3 = &H80              ' Bit 7

    ' [V2.0이상]
    Public Const FSUS_OPCODE0 = &H100            ' Bit 8
    Public Const FSUS_OPCODE1 = &H200            ' Bit 9
    Public Const FSUS_OPCODE2 = &H400            ' Bit 10
    Public Const FSUS_OPDATA0 = &H800            ' Bit 11
    Public Const FSUS_OPDATA1 = &H1000           ' Bit 12
    Public Const FSUS_OPDATA2 = &H2000           ' Bit 13
    Public Const FSUS_OPDATA3 = &H4000           ' Bit 14

    '/* FS End status : 0x0000이면 정상종료	*/

    Public Const FSEND_STATUS_SLM = &H1             ' Bit 0, limit 감속정지 신호 입력에 의한 종료
    Public Const FSEND_STATUS_ELM = &H2             ' Bit 1, limit 급정지 신호 입력에 의한 종료
    Public Const FSEND_STATUS_SSTOP_SIGNAL = &H4           ' Bit 2, 감속 정지 신호 입력에 의한 종료
    Public Const FSEND_STATUS_ESTOP_SIGANL = &H8           ' Bit 3, 급정지 신호 입력에 의한 종료
    Public Const FSEND_STATUS_SSTOP_COMMAND = &H10         ' Bit 4, 감속 정지 명령에 의한 종료
    Public Const FSEND_STATUS_ESTOP_COMMAND = &H20         ' Bit 5, 급정지 정지 명령에 의한 종료
    Public Const FSEND_STATUS_ALARM_SIGNAL = &H40          ' Bit 6, Alarm 신호 입력에 희한 종료
    Public Const FSEND_STATUS_DATA_ERROR = &H80          ' Bit 7, 데이터 설정 에러에 의한 종료

    '[V2.0이상]
    Public Const FSEND_STATUS_DEVIATION_ERROR = &H100        ' Bit 8, 탈조 에러에 의한 종료
    Public Const FSEND_STATUS_ORIGIN_DETECT = &H200        ' Bit 9, 원점 검출에 의한 종료
    Public Const FSEND_STATUS_SIGNAL_DETECT = &H400        ' Bit 10, 신호 검출에 의한 종료(Signal search-1/2 drive 종료)
    Public Const FSEND_STATUS_PRESET_PULSE_DRIVE = &H800       ' Bit 11, Preset pulse drive 종료
    Public Const FSEND_STATUS_SENSOR_PULSE_DRIVE = &H1000      ' Bit 12, Sensor pulse drive 종료
    Public Const FSEND_STATUS_LIMIT = &H2000         ' Bit 13, Limit 완전정지에 의한 종료
    Public Const FSEND_STATUS_SOFTLIMIT = &H4000        ' Bit 14, Soft limit에 의한 종료

    '/* FS Drive status						*/

    Public Const FSDRIVE_STATUS_BUSY = &H1            ' Bit 0, BUSY(드라이브 구동 중)
    Public Const FSDRIVE_STATUS_DOWN = &H2            ' Bit 1, DOWN(감속 중)
    Public Const FSDRIVE_STATUS_CONST = &H4            ' Bit 2, CONST(등속 중)
    Public Const FSDRIVE_STATUS_UP = &H8             ' Bit 3, UP(가속 중)
    Public Const FSDRIVE_STATUS_ICL = &H10           ' Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
    Public Const FSDRIVE_STATUS_ICG = &H20           ' Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
    Public Const FSDRIVE_STATUS_ECL = &H40           ' Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
    Public Const FSDRIVE_STATUS_ECG = &H80           ' Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)

    '[V2.0이상]
    Public Const FSDRIVE_STATUS_DEVIATION_ERROR = &H100       ' Bit 8, 드라이브 방향 신호(0=CW/1=CCW)

    '/* FS Mechanical signal					*/

    Public Const FSMECHANICAL_PELM_LEVEL = &H1           ' Bit 0, +Limit 급정지 신호 입력 Level
    Public Const FSMECHANICAL_NELM_LEVEL = &H2           ' Bit 1, -Limit 급정지 신호 입력 Level
    Public Const FSMECHANICAL_PSLM_LEVEL = &H4           ' Bit 2, +limit 감속정지 신호 입력 Level
    Public Const FSMECHANICAL_NSLM_LEVEL = &H8           ' Bit 3, -limit 감속정지 신호 입력 Level
    Public Const FSMECHANICAL_ALARM_LEVEL = &H10          ' Bit 4, Alarm 신호 입력 Level
    Public Const FSMECHANICAL_INP_LEVEL = &H20          ' Bit 5, Inposition 신호 입력 Level
    Public Const FSMECHANICAL_ENC_DOWN_LEVEL = &H40         ' Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
    Public Const FSMECHANICAL_ENC_UP_LEVEL = &H80          ' Bit 7, 엔코더 UP(A상) 신호 입력 Level

    '[V2.0이상]
    Public Const FSMECHANICAL_EXMP_LEVEL = &H100         ' Bit 8, EXMP 신호 입력 Level
    Public Const FSMECHANICAL_EXPP_LEVEL = &H200         ' Bit 9, EXPP 신호 입력 Level
    Public Const FSMECHANICAL_MARK_LEVEL = &H400         ' Bit 10, MARK# 신호 입력 Level
    Public Const FSMECHANICAL_SSTOP_LEVEL = &H800         ' Bit 11, SSTOP 신호 입력 Level
    Public Const FSMECHANICAL_ESTOP_LEVEL = &H1000        ' Bit 12, ESTOP 신호 입력 Level

    '/* 드라이브 동작 설정					*/

    Public Const SYM_LINEAR = &H0             ' 대칭 사다리꼴
    Public Const ASYM_LINEAR = &H1             ' 비대칭 사다리꼴
    Public Const SYM_CURVE = &H2             ' 대칭 포물선(S-Curve)
    Public Const ASYM_CURVE = &H3             ' 비대칭 포물선(S-Curve)

    '/* FS COMMAND LIST							*/

    ' PGM-1 Group Register
    Public Const FsRangeDataRead = &H0            ' PGM-1 RANGE READ, 16bit, 0xFFFF
    Public Const FsRangeDataWrite = &H80          ' PGM-1 RANGE WRITE
    Public Const FsStartStopSpeedDataRead = &H1         ' PGM-1 START/STOP SPEED DATA READ, 16bit, 
    Public Const FsStartStopSpeedDataWrite = &H81        ' PGM-1 START/STOP SPEED DATA WRITE
    Public Const FsObjectSpeedDataRead = &H2          ' PGM-1 OBJECT SPEED DATA READ, 16bit, 
    Public Const FsObjectSpeedDataWrite = &H82         ' PGM-1 OBJECT SPEED DATA WRITE
    Public Const FsRate1DataRead = &H3            ' PGM-1 RATE-1 DATA READ, 16bit, 0xFFFF
    Public Const FsRate1DataWrite = &H83          ' PGM-1 RATE-1 DATA WRITE
    Public Const FsRate2DataRead = &H4            ' PGM-1 RATE-2 DATA READ, 16bit, 0xFFFF
    Public Const FsRate2DataWrite = &H84          ' PGM-1 RATE-2 DATA WRITE
    Public Const FsRate3DataRead = &H5            ' PGM-1 RATE-3 DATA READ, 16bit, 0xFFFF
    Public Const FsRate3DataWrite = &H85          ' PGM-1 RATE-3 DATA WRITE
    Public Const FsRateChangePoint12Read = &H6          ' PGM-1 RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    Public Const FsRateChangePoint12Write = &H86        ' PGM-1 RATE CHANGE POINT 1-2 WRITE
    Public Const FsRateChangePoint23Read = &H7          ' PGM-1 RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    Public Const FsRateChangePoint23Write = &H87        ' PGM-1 RATE CHANGE POINT 2-3 WRITE
    Public Const FsSw1DataRead = &H8            ' PGM-1 SW-1 DATA READ, 15bit, 0x7FFF
    Public Const FsSw1DataWrite = &H88           ' PGM-1 SW-1 DATA WRITE
    Public Const FsSw2DataRead = &H9            ' PGM-1 SW-2 DATA READ, 15bit, 0x7FFF
    Public Const FsSw2DataWrite = &H89           ' PGM-1 SW-2 DATA WRITE
    Public Const FsPwmOutDataRead = &HA           ' PGM-1 PWM 출력 설정 DATA READ(0~6), 3bit, 0x00
    Public Const FsPwmOutDataWrite = &H8A          ' PGM-1 PWM 출력 설정 DATA WRITE
    Public Const FsSlowDownRearPulseRead = &HB          ' PGM-1 SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    Public Const FsSlowDownRearPulseWrite = &H8B        ' PGM-1 SLOW DOWN/REAR PULSE WRITE
    Public Const FsCurrentSpeedDataRead = &HC          ' PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
    Public Const FsNoOperation_8C = &H8C          ' No operation
    Public Const FsCurrentSpeedComparateDataRead = &HD        ' PGM-1 현재 SPEED 비교 DATA READ, 16bit, 0x0000
    Public Const FsCurrentSpeedComparateDataWrite = &H8D      ' PGM-1 현재 SPEED 비교 DATA WRITE
    Public Const FsDrivePulseCountRead = &HE          ' PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
    Public Const FsNoOperation_8E = &H8E          ' No operation
    Public Const FsPresetPulseDataRead = &HF          ' PGM-1 PRESET PULSE DATA READ, 32bit, 0x00000000
    Public Const FsNoOperation_8F = &H8F          ' No operation

    ' PGM-1 Update Group Register
    Public Const FsURangeDataRead = &H10          ' PGM-1 UP-DATE RANGE READ, 16bit, 0xFFFF
    Public Const FsURangeDataWrite = &H90          ' PGM-1 UP-DATE RANGE WRITE
    Public Const FsUStartStopSpeedDataRead = &H11        ' PGM-1 UP-DATE START/STOP SPEED DATA READ, 16bit, 
    Public Const FsUStartStopSpeedDataWrite = &H91        ' PGM-1 UP-DATE START/STOP SPEED DATA WRITE
    Public Const FsUObjectSpeedDataRead = &H12         ' PGM-1 UP-DATE OBJECT SPEED DATA READ, 16bit, 
    Public Const FsUObjectSpeedDataWrite = &H92         ' PGM-1 UP-DATE OBJECT SPEED DATA WRITE
    Public Const FsURate1DataRead = &H13          ' PGM-1 UP-DATE RATE-1 DATA READ, 16bit, 0xFFFF
    Public Const FsURate1DataWrite = &H93          ' PGM-1 UP-DATE RATE-1 DATA WRITE
    Public Const FsURate2DataRead = &H14          ' PGM-1 UP-DATE RATE-2 DATA READ, 16bit, 0xFFFF
    Public Const FsURate2DataWrite = &H94          ' PGM-1 UP-DATE RATE-2 DATA WRITE
    Public Const FsURate3DataRead = &H15          ' PGM-1 UP-DATE RATE-3 DATA READ, 16bit, 0xFFFF
    Public Const FsURate3DataWrite = &H95          ' PGM-1 UP-DATE RATE-3 DATA WRITE
    Public Const FsURateChange12DataRead = &H16         ' PGM-1 UP-DATE RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
    Public Const FsURateChange12DataWrite = &H96        ' PGM-1 UP-DATE RATE CHANGE POINT 1-2 WRITE
    Public Const FsURateChange23DataRead = &H17         ' PGM-1 UP-DATE RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
    Public Const FsURateChange23DataWrite = &H97        ' PGM-1 UP-DATE RATE CHANGE POINT 2-3 WRITE
    Public Const FsUSw1DataRead = &H18           ' PGM-1 UP-DATE SW-1 DATA READ, 15bit, 0x7FFF
    Public Const FsUSw1DataWrite = &H98           ' PGM-1 UP-DATE SW-1 DATA WRITE
    Public Const FsUSw2DataRead = &H19           ' PGM-1 UP-DATE SW-2 DATA READ, 15bit, 0x7FFF
    Public Const FsUSw2DataWrite = &H99           ' PGM-1 UP-DATE SW-2 DATA WRITE
    Public Const FsUCurrentSpeedChangeDataRead = &H1A       ' PGM-1 CURRENT SPEED CHANGE DATA READ
    Public Const FsUCurrentSpeedChangeDataWrote = &H9A       ' PGM-1 CURRENT SPEED CHANGE DATA WRITE
    Public Const FsUSlowDownRearPulseRead = &H1B        ' PGM-1 UP-DATE SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
    Public Const FsUSlowDownRearPulseWrite = &H9B        ' PGM-1 UP-DATE SLOW DOWN/REAR PULSE WRITE
    Public Const FsUCurrentSpeedDataRead = &H1C         ' PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
    Public Const FsNoOperation_9C = &H9C          ' No operation
    Public Const FsUCurrentSpeedComparateDataRead = &H1D      ' PGM-1 UP-DATE 현재 SPEED 비교 DATA READ, 16bit, 0x0000
    Public Const FsUCurrentSpeedComparateDataWrite = &H9D      ' PGM-1 UP-DATE 현재 SPEED 비교 DATA WRITE
    Public Const FsUDrivePulseCounterDataRead = &H1E       ' PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
    Public Const FsNoOperation_9E = &H9E          ' No operation
    Public Const FsUPresetPulseDataRead = &H1F         ' PGM-1 UP-DATE PRESET PULSE DATA READ, 32bit, 0x00000000
    Public Const FsNoOperation_9F = &H9F          ' No operation

    ' PGM-2 Group Register
    Public Const FsNoOperation_20 = &H20          ' No operation
    Public Const FsPresetPulseDriveP = &HA0          ' +PRESET PULSE DRIVE, 32
    Public Const FsNoOperation_21 = &H21          ' No operation
    Public Const FsContinuousDriveP = &HA1          ' +CONTINUOUS DRIVE
    Public Const FsNoOperation_22 = &H22          ' No operation
    Public Const FsSignalSearch1DriveP = &HA2         ' +SIGNAL SEARCH-1 DRIVE
    Public Const FsNoOperation_23 = &H23          ' No operation
    Public Const FsSignalSearch2DriveP = &HA3         ' +SIGNAL SEARCH-2 DRIVE
    Public Const FsNoOperation_24 = &H24          ' No operation
    Public Const FsOriginSearchDriveP = &HA4         ' +ORIGIN(원점) SEARCH DRIVE
    Public Const FsNoOperation_25 = &H25          ' No operation
    Public Const FsPresetPulseDriveN = &HA5          ' -PRESET PULSE DRIVE, 32
    Public Const FsNoOperation_26 = &H26          ' No operation
    Public Const FsContinuousDriveN = &HA6          ' -CONTINUOUS DRIVE
    Public Const FsNoOperation_27 = &H27          ' No operation
    Public Const FsSignalSearch1DriveN = &HA7         ' -SIGNAL SEARCH-1 DRIVE
    Public Const FsNoOperation_28 = &H28          ' No operation
    Public Const FsSignalSearch2DriveN = &HA8         ' -SIGNAL SEARCH-2 DRIVE
    Public Const FsNoOperation_29 = &H29          ' No operation
    Public Const FsOriginSearchDriveN = &HA9         ' -ORIGIN(원점) SEARCH DRIVE
    Public Const FsNoOperation_2A = &H2A          ' No operation
    Public Const FsPresetPulseDataOverride = &HAA        ' PRESET PULSE DATA OVERRIDE(ON_BUSY)
    Public Const FsNoOperation_2B = &H2B          ' No operation
    Public Const FsSlowDownStop = &HAB           ' SLOW DOWN STOP
    Public Const FsNoOperation_2C = &H2C          ' No operation
    Public Const FsEmergencyStop = &HAC           ' EMERGENCY STOP
    Public Const FsDriveOperationSelectDataRead = &H2D       ' 드라이브 동작 설정 DATA READ
    Public Const FsDriveOperationSelectDataWrite = &HAD       ' 드라이브 동작 설정 DATA WRITE
    Public Const FsMpgOperationSettingDataRead = &H2E       ' MPG OPERATION SETTING DATA READ, 3bit, 0x00		<+> 2002-11-15 FS2.0 - JNS
    Public Const FsMpgOperationSettingDataWrite = &HAE       ' MPG OPERATION SETTING DATA WRITE					<+> 2002-11-15 FS2.0 - JNS
    Public Const FsMpgPresetPulseDataRead = &H2F        ' MPG PRESET PULSE DATA READ, 32bit, 0x00000000	<+> 2002-11-15 FS2.0 - JNS
    Public Const FsMpgPresetPulseDataWrite = &HAF        ' MPG PRESET PULSE DATA WRITE						<+> 2002-11-15 FS2.0 - JNS

    '	/* Extension Group Register */
    Public Const FsNoOperation_30 = &H30          ' No operation
    Public Const FsSensorPositioningDrive1P = &HB0        ' +SENSOR POSITIONING DRIVE I
    Public Const FsNoOperation_31 = &H31          ' No operation
    Public Const FsSensorPositioningDrive1N = &HB1        ' -SENSOR POSITIONING DRIVE I
    Public Const FsNoOperation_32 = &H32          ' No operation
    Public Const FsSensorPositioningDrive2P = &HB2        ' +SENSOR POSITIONING DRIVE II
    Public Const FsNoOperation_33 = &H33          ' No operation
    Public Const FsSensorPositioningDrive2N = &HB3        ' -SENSOR POSITIONING DRIVE II
    Public Const FsNoOperation_34 = &H34          ' No operation
    Public Const FsSensorPositioningDrive3P = &HB4        ' +SENSOR POSITIONING DRIVE III
    Public Const FsNoOperation_35 = &H35          ' No operation
    Public Const FsSensorPositioningDrive3N = &HB5        ' -SENSOR POSITIONING DRIVE III
    Public Const FsSoftlimitSettingDataRead = &H36        ' SOFT LIMIT 설정 READ, 3bit, 0x00
    Public Const FsSoftlimitSettingDataWrite = &HB6        ' SOFT LIMIT 설정 WRITE
    Public Const FsNegativeSoftlimitDataRead = &H37        ' -SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x80000000
    Public Const FsNegativeSoftlimitDataWrite = &HB7       ' -SOFT LIMIT 비교 레지스터 설정 WRITE
    Public Const FsPositiveSoftlimitDataRead = &H38        ' +SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x7FFFFFFF
    Public Const FsPositiveSoftlimitDataWrite = &HB8       ' +SOFT LIMIT 비교 레지스터 설정 WRITE
    Public Const FsTriggerModeSettingDataRead = &H39       ' TRIGGER MODE 설정 READ, 32bit, 0x00010000
    Public Const FsTriggerModeSettingDataWrite = &HB9       ' TRIGGER MODE 설정 WRITE
    Public Const FsTriggerComparatorDataRead = &H3A        ' TRIGGER 비교 데이터 설정 READ, 32bit, 0x00000000
    Public Const FsTriggerComparatorDataWrite = &HBA       ' TRIGGER 비교 데이터 설정 WRITE
    Public Const FsInternalCounterMDataRead = &H3B        ' INTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    Public Const FsInternalCounterMDataWrite = &HBB        ' INTERNAL M-DATA 설정 WRITE
    Public Const FsExternalCounterMDataRead = &H3C        ' EXTERNAL M-DATA 설정 READ, 32bit, 0x80000000
    Public Const FsExternalCounterMDataWrite = &HBC        ' EXTERNAL M-DATA 설정 WRITE
    Public Const FsNoOperation_BD = &HBD          ' No operation
    Public Const FsNoOperation_3D = &H3D          ' No operation
    Public Const FsNoOperation_3E = &H3E          ' No operation
    Public Const FsNoOperation_BE = &HBE          ' No operation
    Public Const FsNoOperation_3F = &H3F          ' No operation
    Public Const FsNoOperation_BF = &HBF          ' No operation

    '	/* Scripter Group Register			*/
    Public Const FsScriptOperSetReg1Read = &H40         ' 스크립트 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    Public Const FsScriptOperSetReg1Write = &HC0        ' 스크립트 동작 설정 레지스터-1 WRITE
    Public Const FsScriptOperSetReg2Read = &H41         ' 스크립트 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    Public Const FsScriptOperSetReg2Write = &HC1        ' 스크립트 동작 설정 레지스터-2 WRITE
    Public Const FsScriptOperSetReg3Read = &H42         ' 스크립트 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    Public Const FsScriptOperSetReg3Write = &HC2        ' 스크립트 동작 설정 레지스터-3 WRITE
    Public Const FsScriptOperSetRegQueueRead = &H43        ' 스크립트 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    Public Const FsScriptOperSetRegQueueWrite = &HC3       ' 스크립트 동작 설정 레지스터-Queue WRITE
    Public Const FsScriptOperDataReg1Read = &H44        ' 스크립트 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    Public Const FsScriptOperDataReg1Write = &HC4        ' 스크립트 동작 데이터 레지스터-1 WRITE
    Public Const FsScriptOperDataReg2Read = &H45        ' 스크립트 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    Public Const FsScriptOperDataReg2Write = &HC5        ' 스크립트 동작 데이터 레지스터-2 WRITE
    Public Const FsScriptOperDataReg3Read = &H46        ' 스크립트 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    Public Const FsScriptOperDataReg3Write = &HC6        ' 스크립트 동작 데이터 레지스터-3 WRITE
    Public Const FsScriptOperDataRegQueueRead = &H47       ' 스크립트 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    Public Const FsScriptOperDataRegQueueWrite = &HC7       ' 스크립트 동작 데이터 레지스터-Queue WRITE
    Public Const FsNoOperation_48 = &H48          ' No operation
    Public Const FsScriptOperQueueClear = &HC8         ' 스크립트 Queue clear
    Public Const FsScriptOperSetQueueIndexRead = &H49       ' 스크립트 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    Public Const FsNoOperation_C9 = &HC9          ' No operation
    Public Const FsScriptOperDataQueueIndexRead = &H4A       ' 스크립트 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    Public Const FsNoOperation_CA = &HCA          ' No operation
    Public Const FsScriptOperQueueFlagRead = &H4B        ' 스크립트 Queue Full/Empty Flag READ, 4bit, 0x05
    Public Const FsNoOperation_CB = &HCB          ' No operation
    Public Const FsScriptOperQueueSizeSettingRead = &H4C      ' 스크립트 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    Public Const FsScriptOperQueueSizeSettingWrite = &HCC      ' 스크립트 Queue size 설정(0~13) WRITE
    Public Const FsScriptOperQueueStatusRead = &H4D        ' 스크립트 Queue status READ, 12bit, 0x005
    Public Const FsNoOperation_CD = &HCD          ' No operation
    Public Const FsNoOperation_4E = &H4E          ' No operation
    Public Const FsNoOperation_CE = &HCE          ' No operation
    Public Const FsNoOperation_4F = &H4F          ' No operation
    Public Const FsNoOperation_CF = &HCF          ' No operation

    '	/* Caption Group Register */
    Public Const FsCaptionOperSetReg1Read = &H50        ' 갈무리 동작 설정 레지스터-1 READ, 32bit, 0x00000000
    Public Const FsCaptionOperSetReg1Write = &HD0        ' 갈무리 동작 설정 레지스터-1 WRITE
    Public Const FsCaptionOperSetReg2Read = &H51        ' 갈무리 동작 설정 레지스터-2 READ, 32bit, 0x00000000
    Public Const FsCaptionOperSetReg2Write = &HD1        ' 갈무리 동작 설정 레지스터-2 WRITE
    Public Const FsCaptionOperSetReg3Read = &H52        ' 갈무리 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
    Public Const FsCaptionOperSetReg3Write = &HD2        ' 갈무리 동작 설정 레지스터-3 WRITE
    Public Const FsCaptionOperSetRegQueueRead = &H53       ' 갈무리 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
    Public Const FsCaptionOperSetRegQueueWrite = &HD3       ' 갈무리 동작 설정 레지스터-Queue WRITE
    Public Const FsCaptionOperDataReg1Read = &H54        ' 갈무리 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
    Public Const FsNoOperation_D4 = &HD4          ' No operation
    Public Const FsCaptionOperDataReg2Read = &H55        ' 갈무리 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
    Public Const FsNoOperation_D5 = &HD5          ' No operation
    Public Const FsCaptionOperDataReg3Read = &H56        ' 갈무리 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
    Public Const FsNoOperation_D6 = &HD6          ' No operation
    Public Const FsCaptionOperDataRegQueueRead = &H57       ' 갈무리 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
    Public Const FsNoOperation_D7 = &HD7          ' No operation
    Public Const FsNoOperation_58 = &H58          ' No operation
    Public Const FsCaptionOperQueueClear = &HD8         ' 갈무리 Queue clear
    Public Const FsCaptionOperSetQueueIndexRead = &H59       ' 갈무리 동작 설정 Queue 인덱스 READ, 4bit, 0x00
    Public Const FsNoOperation_D9 = &HD9          ' No operation
    Public Const FsCaptionOperDataQueueIndexRead = &H5A       ' 갈무리 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
    Public Const FsNoOperation_DA = &HDA          ' No operation
    Public Const FsCaptionOperQueueFlagRead = &H5B        ' 갈무리 Queue Full/Empty Flag READ, 4bit, 0x05
    Public Const FsNoOperation_DB = &HDB          ' No operation
    Public Const FsCaptionOperQueueSizeSettingRead = &H5C      ' 갈무리 Queue size 설정(0~13) READ, 16bit, 0xD0D0
    Public Const FsCaptionOperQueueSizeSettingWrite = &HDC      ' 갈무리 Queue size 설정(0~13) WRITE
    Public Const FsCaptionOperQueueStatusRead = &H5D       ' 갈무리 Queue status READ, 12bit, 0x005
    Public Const FsNoOperation_DD = &HDD          ' No operation
    Public Const FsNoOperation_5E = &H5E          ' No operation
    Public Const FsNoOperation_DE = &HDE          ' No operation
    Public Const FsNoOperation_5F = &H5F          ' No operation
    Public Const FsNoOperation_DF = &HDF          ' No operation

    '	/* BUS - 1 Group Register			*/
    Public Const FsInternalCounterRead = &H60         ' INTERNAL COUNTER DATA READ(Signed), 32bit, 0x00000000
    Public Const FsInternalCounterWrite = &HE0         ' INTERNAL COUNTER DATA WRITE(Signed)
    Public Const FsInternalCounterComparatorDataRead = &H61      ' INTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    Public Const FsInternalCounterComparatorDataWrite = &HE1     ' INTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    Public Const FsInternalCounterPreScaleDataRead = &H62      ' INTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    Public Const FsInternalCounterPreScaleDataWrite = &HE2      ' INTERNAL COUNTER PRE-SCALE DATA WRITE
    Public Const FsInternalCounterNCountDataRead = &H63       ' INTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    Public Const FsInternalCounterNCountDataWrite = &HE3      ' INTERNAL COUNTER P-DATA WRITE
    Public Const FsExternalCounterRead = &H64         ' EXTERNAL COUNTER DATA READ READ(Signed), 32bit, 0x00000000
    Public Const FsExternalCounterWrite = &HE4         ' EXTERNAL COUNTER DATA READ WRITE(Signed)
    Public Const FsExternalCounterComparatorDataRead = &H65      ' EXTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
    Public Const FsExternalCounterComparatorDataWrite = &HE5     ' EXTERNAL COUNTER COMPARATE DATA WRITE(Signed)
    Public Const FsExternalCounterPreScaleDataRead = &H66      ' EXTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
    Public Const FsExternalCounterPreScaleDataWrite = &HE6      ' EXTERNAL COUNTER PRE-SCALE DATA WRITE
    Public Const FsExternalCounterNCountDataRead = &H67       ' EXTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
    Public Const FsExternalCounterNCountDataWrite = &HE7      ' EXTERNAL COUNTER P-DATA WRITE
    Public Const FsExternalSpeedDataRead = &H68         ' EXTERNAL SPEED DATA READ, 32bit, 0x00000000
    Public Const FsExternalSpeedDataWrite = &HE8        ' EXTERNAL SPEED DATA WRITE
    Public Const FsExternalSpeedComparateDataRead = &H69      ' EXTERNAL SPEED COMPARATE DATA READ, 32bit, 0x00000000
    Public Const FsExternalSpeedComparateDataWrite = &HE9      ' EXTERNAL SPEED COMPARATE DATA WRITE
    Public Const FsExternalSensorFilterBandWidthDataRead = &H6A     ' 외부 센서 필터 대역폭 설정 DATA READ, 8bit, 0x05
    Public Const FsExternalSensorFilterBandWidthDataWrite = &HEA    ' 외부 센서 필터 대역폭 설정 DATA WRITE
    Public Const FsOffRangeDataRead = &H6B          ' OFF-RANGE DATA READ, 8bit, 0x00
    Public Const FsOffRangeDataWrite = &HEB          ' OFF-RANGE DATA WRITE
    Public Const FsDeviationDataRead = &H6C          ' DEVIATION DATA READ, 16bit, 0x0000
    Public Const FsNoOperation_EC = &HEC          ' No operation
    Public Const FsPgmRegChangeDataRead = &H6D         ' PGM REGISTER CHANGE DATA READ
    Public Const FsPgmRegChangeDataWrite = &HED         ' PGM REGISTER CHANGE DATA WRITE
    Public Const FsNoOperation_6E = &H6E          ' No operation
    Public Const FsCompareRegisterInputChangeDataWrite = &HEE     ' COMPARE REGISTER INPUT CHANGE
    Public Const FsNoOperation_6F = &H6F          ' No operation
    Public Const FsNoOperation_EF = &HEF          ' No operation
    '?	FsCompareRegisterInputChangeDataRead= 0x6E,				//<+> 2002-11-15 FS2.0 - JNS

    '	/* BUS - 2 Group Register			*/
    Public Const FsChipFunctionSetDataRead = &H70        ' 칩 기능 설정 DATA READ, 13bit, 0x0C3E
    Public Const FsChipFunctionSetDataWrite = &HF0        ' 칩 기능 설정 DATA WRITE
    Public Const FsMode1Read = &H71            ' MODE1 DATA READ, 8bit, 0x00
    Public Const FsMode1Write = &HF1           ' MODE1 DATA WRITE
    Public Const FsMode2Read = &H72            ' MODE2 DATA READ, 11bit, 0x200
    Public Const FsMode2Write = &HF2           ' MODE2 DATA WRITE
    Public Const FsUniversalSignalRead = &H73         ' UNIVERSAL IN READ, 11bit, 0x0000
    Public Const FsUniversalSignalWrite = &HF3         ' UNIVERSAL OUT WRITE
    Public Const FsEndStatusRead = &H74           ' END STATUS DATA READ, 15bit, 0x0000
    Public Const FsNoOperation_F4 = &HF4          ' No operation
    Public Const FsMechanicalSignalRead = &H75         ' MECHANICAL SIGNAL DATA READ, 13bit
    Public Const FsNoOperation_F5 = &HF5          ' No operation
    Public Const FsDriveStatusRead = &H76          ' DRIVE STATE DATA READ, 9bit
    Public Const FsNoOperation_F6 = &HF6          ' No operation
    Public Const FsExternalCounterSetDataRead = &H77       ' EXTERNAL COUNTER 설정 DATA READ, 9bit, 0x00
    Public Const FsExternalCounterSetDataWrite = &HF7       ' EXTERNAL COUNTER 설정 DATA WRITE
    Public Const FsNoOperation_78 = &H78          ' No operation
    Public Const FsRegisterClear = &HF8           ' REGISTER CLEAR(INITIALIZATION)
    Public Const FsInterruptFlagRead = &H79          ' Interrupt Flag READ, 32bit, 0x00000000
    Public Const FsInterruptOutCommand = &HF9         ' Interrupt 발생 Command
    Public Const FsInterruptMaskRead = &H7A          ' Interrupt Mask READ, 32bit, 0x00000001
    Public Const FsInterruptMaskWrite = &HFA         ' Interrupt Mask WRITE
    Public Const FsEMode1DataRead = &H7B          ' EMODE1 DATA READ, 8bit, 0x00
    Public Const FsEMode1DataWrite = &HFB          ' EMODE1 DATA WRITE
    Public Const FsEUniversalOutRead = &H7C          ' Extension UNIVERSAL OUT READ, 8bit, 0x00
    Public Const FsEUniversalOutWrite = &HFC         ' Extension UNIVERSAL OUT WRITE
    Public Const FsNoOperation_7D = &H7D          ' No operation
    Public Const FsLimitStopDisableWrite = &HFD         ' LIMIT 완전정지 해제
    Public Const FsUserInterruptSourceSelectRegRead = &H7E      ' USER Interrupt source selection register READ, 32bit, 0x00000000
    Public Const FsUserInterruptSourceSelectRegWrite = &HFE      ' USER Interrupt source selection register WRITE
    Public Const FsNoOperation_7F = &H7F          ' No operation
    Public Const FsNoOperation_FF = &HFF          ' No operation

    ''/*
    '	모듈의 Version :
    '		- CAMC-FS 1.0 이면 0	=> CFS
    '		- CAMC-FS 2.0 이면 2	=> CFS, CFS20
    '		- CAMC-FS 2.1 이면 4	=> CFS, CFS20
    '*/
    Public Const CAMC_FS_VERSION_10 = 0           ' FS Ver 1.0
    Public Const CAMC_FS_VERSION_20 = 2           ' FS Ver 2.0
    Public Const CAMC_FS_VERSION_20_KDNS = 3         ' FS Ver 2.0 - for KDNS
    Public Const CAMC_FS_VERSION_21 = 4           ' FS Ver 2.1
    Public Const CAMC_FS_VERSION_30 = 5           ' FS Ver 3.0

    ' 스크립트/갈무리 동작 설정 레지스터-1/2/3/Queue
    Public Const SCRIPT_REG1 = 1            ' 스크립트 레지스터-1
    Public Const SCRIPT_REG2 = 2            ' 스크립트 레지스터-2
    Public Const SCRIPT_REG3 = 3            ' 스크립트 레지스터-3
    Public Const SCRIPT_REG_QUEUE = 4           ' 스크립트 레지스터-Queue
    Public Const CAPTION_REG1 = 11            ' 갈무리 레지스터-1
    Public Const CAPTION_REG2 = 12            ' 갈무리 레지스터-2
    Public Const CAPTION_REG3 = 13            ' 갈무리 레지스터-3
    Public Const CAPTION_REG_QUEUE = 14           ' 갈무리 레지스터-Queue

    ' CFS20KeSetScriptCaption의 event입력을 위한 값 define.
    ' bit 31 : 0=한번만실행, 1=계속 실행
    Public Const OPERATION_ONCE_RUN = &H0               ' bit 31 OFF
    Public Const OPERATION_CONTINUE_RUN = &H80000000       ' bit 31 ON
    ' bit 30..26 : Don't care
    ' bit 25..24 : 00=1번이벤트만검출, 01=OR연산, 10=AND연산, 11=XOR연산
    Public Const OPERATION_EVENT_NONE = &H0               ' bit 25=OFF, 24=OFF
    Public Const OPERATION_EVENT_OR = &H1000000         ' bit 25=OFF, 24=ON
    Public Const OPERATION_EVENT_AND = &H2000000         ' bit 25=ON,  24=OFF
    Public Const OPERATION_EVENT_XOR = &H3000000         ' bit 25=ON,  24=ON

    ' CFS20SetScriptCaption의 event_logic입력을 위한 값 define.
    ' bit 7 : 0=한번만실행, 1=계속 실행
    Public Const FSSC_ONE_TIME_RUN = &H0           ' bit 7 OFF
    Public Const FSSC_ALWAYS_RUN = &H80           ' bit 7 ON
    ' bit 6 bit : sc에 따라서 다음과 같은 차이점이 있음.
    '	sc = SCRIPT_REG1, SCRIPT_REG2, SCRIPT_REG3 일 때. Don't care.
    '	sc = SCRIPT_REG_QUEUE 일 때. Script 동작시 인터럽트 출력 유무. 해당 인터럽트 mask가 enable 되어 있어야 함.
    '		0(인터럽트 발생하지 않음), 1(해당 script 수행시 인터럽트 발생) 
    '	sc = CAPTION_REG1, CAPTION_REG2, CAPTION_REG3 일 때. Don't care.
    '	sc = CAPTION_REG_QUEUE. Caption 동작시 인터럽트 출력 유무. 해당 인터럽트 mask가 enable되어 있어야 함.
    '		0(인터럽트 발생하지 않음), 1(해당 caption 수행시 인터럽트 발생) 
    Public Const IPSCQ_INTERRUPT_DISABLE = &H0          ' bit 6 OFF
    Public Const IPSCQ_INTERRUPT_ENABLE = &H40         ' bit 6 ON
    ' bit 1..0 bit : 00=1번이벤트만검출, 01=OR연산, 10=AND연산, 11=XOR연산
    Public Const FSSC_EVENT_OP_NONE = &H0           ' bit 1=OFF, 0=OFF
    Public Const FSSC_EVENT_OP_OR = &H1           ' bit 1=OFF, 0=ON
    Public Const FSSC_EVENT_OP_AND = &H2           ' bit 1=ON,  0=OFF
    Public Const FSSC_EVENT_OP_XOR = &H3           ' bit 1=ON,  0=ON

    '/* EVENT LIST							*/

    Public Const EVENT_NONE = &H0             ' 검출사항 없음
    Public Const EVENT_DRIVE_END = &H1            ' 드라이브 종료
    Public Const EVENT_PRESETDRIVE_START = &H2          ' 지정펄스 수 드라이브 시작
    Public Const EVENT_PRESETDRIVE_END = &H3          ' 지정펄스 수 드라이브 종료
    Public Const EVENT_CONTINOUSDRIVE_START = &H4         ' 연속 드라이브 시작
    Public Const EVENT_CONTINOUSDRIVE_END = &H5         ' 연속 드라이브 종료
    Public Const EVENT_SIGNAL_SEARCH_1_START = &H6         ' 신호 검출-1 드라이브 시작
    Public Const EVENT_SIGNAL_SEARCH_1_END = &H7         ' 신호 검출-1 드라이브 종료
    Public Const EVENT_SIGNAL_SEARCH_2_START = &H8         ' 신호 검출-2 드라이브 시작
    Public Const EVENT_SIGNAL_SEARCH_2_END = &H9         ' 신호 검출-2 드라이브 종료
    Public Const EVENT_ORIGIN_DETECT_START = &HA         ' 원점검출 드라이브 시작
    Public Const EVENT_ORIGIN_DETECT_END = &HB          ' 원점검출 드라이브 종료
    Public Const EVENT_SPEED_UP = &HC            ' 가속
    Public Const EVENT_SPEED_CONST = &HD           ' 등속
    Public Const EVENT_SPEED_DOWN = &HE           ' 감속
    Public Const EVENT_ICG = &HF             ' 내부위치카운터 > 내부위치비교값
    Public Const EVENT_ICE = &H10            ' 내부위치카운터 = 내부위치비교값
    Public Const EVENT_ICL = &H11            ' 내부위치카운터 < 내부위치비교값
    Public Const EVENT_ECG = &H12            ' 외부위치카운터 > 외부위치비교값
    Public Const EVENT_ECE = &H13            ' 외부위치카운터 = 외부위치비교값
    Public Const EVENT_ECL = &H14            ' 외부위치카운터 < 외부위치비교값
    Public Const EVENT_EPCG = &H15            ' 외부펄스카운터 > 외부펄스카운터비교값
    Public Const EVENT_EPCE = &H16            ' 외부펄스카운터 = 외부펄스카운터비교값
    Public Const EVENT_EPCL = &H17            ' 외부펄스카운터 < 외부펄스카운터비교값
    Public Const EVENT_SPG = &H18            ' 현재속도데이터 > 현재속도비교데이터
    Public Const EVENT_SPE = &H19            ' 현재속도데이터 = 현재속도비교데이터
    Public Const EVENT_SPL = &H1A            ' 현재속도데이터 < 현재속도비교데이터
    Public Const EVENT_SP12G = &H1B            ' 현재속도데이터 > Rate Change Point 1-2
    Public Const EVENT_SP12E = &H1C            ' 현재속도데이터 = Rate Change Point 1-2
    Public Const EVENT_SP12L = &H1D            ' 현재속도데이터 < Rate Change Point 1-2
    Public Const EVENT_SP23G = &H1E            ' 현재속도데이터 > Rate Change Point 2-3
    Public Const EVENT_SP23E = &H1F            ' 현재속도데이터 = Rate Change Point 2-3
    Public Const EVENT_SP23L = &H20            ' 현재속도데이터 < Rate Change Point 2-3
    Public Const EVENT_OBJECT_SPEED = &H21          ' 현재속도데이터 = 목표속도데이터
    Public Const EVENT_SS_SPEED = &H22           ' 현재속도데이터 = 시작속도데이터
    Public Const EVENT_ESTOP = &H23            ' 급속정지
    Public Const EVENT_SSTOP = &H24            ' 감속정지
    Public Const EVENT_PELM = &H25            ' +Emergency Limit 신호 입력
    Public Const EVENT_NELM = &H26            ' -Emergency Limit 신호 입력
    Public Const EVENT_PSLM = &H27            ' +Slow Down Limit 신호 입력
    Public Const EVENT_NSLM = &H28            ' -Slow Down Limit 신호 입력
    Public Const EVENT_DEVIATION_ERROR = &H29         ' 탈조 에러 발생
    Public Const EVENT_DATA_ERROR = &H2A          ' 데이터 설정 에러 발생
    Public Const EVENT_ALARM_ERROR = &H2B          ' Alarm 신호 입력
    Public Const EVENT_ESTOP_COMMAND = &H2C          ' 급속 정지 명령 실행
    Public Const EVENT_SSTOP_COMMAND = &H2D          ' 감속 정지 명령 실행
    Public Const EVENT_ESTOP_SIGNAL = &H2E          ' 급속 정지 신호 입력
    Public Const EVENT_SSTOP_SIGNAL = &H2F          ' 감속 정지 신호 입력
    Public Const EVENT_ELM = &H30            ' Emergency Limit 신호 입력
    Public Const EVENT_SLM = &H31            ' Slow Down Limit 신호 입력
    Public Const EVENT_INPOSITION = &H32          ' Inposition 신호 입력
    Public Const EVENT_IN0_HIGH = &H33           ' IN0 High 신호 입력
    Public Const EVENT_IN0_LOW = &H34           ' IN0 Low  신호 입력
    Public Const EVENT_IN1_HIGH = &H35           ' IN1 High 신호 입력
    Public Const EVENT_IN1_LOW = &H36           ' IN1 Low  신호 입력
    Public Const EVENT_IN2_HIGH = &H37           ' IN2 High 신호 입력
    Public Const EVENT_IN2_LOW = &H38           ' IN2 Low  신호 입력
    Public Const EVENT_IN3_HIGH = &H39           ' IN3 High 신호 입력
    Public Const EVENT_IN3_LOW = &H3A           ' IN3 Low  신호 입력
    Public Const EVENT_OUT0_HIGH = &H3B           ' OUT0 High 신호 입력
    Public Const EVENT_OUT0_LOW = &H3C           ' OUT0 Low  신호 입력
    Public Const EVENT_OUT1_HIGH = &H3D           ' OUT1 High 신호 입력
    Public Const EVENT_OUT1_LOW = &H3E           ' OUT1 Low  신호 입력
    Public Const EVENT_OUT2_HIGH = &H3F           ' OUT2 High 신호 입력
    Public Const EVENT_OUT2_LOW = &H40           ' OUT2 Low  신호 입력
    Public Const EVENT_OUT3_HIGH = &H41           ' OUT3 High 신호 입력
    Public Const EVENT_OUT3_LOW = &H42           ' OUT3 Low  신호 입력
    Public Const EVENT_SENSOR_DRIVE1_START = &H43        ' Sensor Positioning drive I 시작
    Public Const EVENT_SENSOR_DRIVE1_END = &H44         ' Sensor Positioning drive I 종료
    Public Const EVENT_SENSOR_DRIVE2_START = &H45        ' Sensor Positioning drive II 시작
    Public Const EVENT_SENSOR_DRIVE2_END = &H46         ' Sensor Positioning drive II 종료
    Public Const EVENT_SENSOR_DRIVE3_START = &H47        ' Sensor Positioning drive III 시작
    Public Const EVENT_SENSOR_DRIVE3_END = &H48         ' Sensor Positioning drive III 종료
    Public Const EVENT_1STCOUNTER_NDATA_CLEAR = &H49       ' 1'st counter N-data count clear
    Public Const EVENT_2NDCOUNTER_NDATA_CLEAR = &H4A       ' 2'nd counter N-data count clear
    Public Const EVENT_MARK_SIGNAL_HIGH = &H4B         ' Mark# signal high
    Public Const EVENT_MARK_SIGNAL_LOW = &H4C         ' Mark# signal low
    Public Const EVENT_EUIO0_HIGH = &H4D          ' EUIO0 High 신호 입력
    Public Const EVENT_EUIO0_LOW = &H4E           ' EUIO0 Low  신호 입력
    Public Const EVENT_EUIO1_HIGH = &H4F          ' EUIO1 High 신호 입력
    Public Const EVENT_EUIO1_LOW = &H50           ' EUIO1 Low  신호 입력
    Public Const EVENT_EUIO2_HIGH = &H51          ' EUIO2 High 신호 입력
    Public Const EVENT_EUIO2_LOW = &H52           ' EUIO2 Low  신호 입력
    Public Const EVENT_EUIO3_HIGH = &H53          ' EUIO3 High 신호 입력
    Public Const EVENT_EUIO3_LOW = &H54           ' EUIO3 Low  신호 입력
    Public Const EVENT_EUIO4_HIGH = &H55          ' EUIO4 High 신호 입력
    Public Const EVENT_EUIO4_LOW = &H56           ' EUIO4 Low  신호 입력
    Public Const EVENT_SOFTWARE_PLIMIT = &H57         ' +Software Limit
    Public Const EVENT_SOFTWARE_NLIMIT = &H58         ' -Software Limit
    Public Const EVENT_SOFTWARE_LIMIT = &H59         ' Software Limit
    Public Const EVENT_TRIGGER_ENABLE = &H5A         ' Trigger enable
    Public Const EVENT_INT_GEN_SOURCE = &H5B         ' Interrupt Generated by any source
    Public Const EVENT_INT_GEN_CMDF9 = &H5C          ' Interrupt Generated by Command "F9"
    Public Const EVENT_PRESETDRIVE_TRI_START = &H5D        ' Preset 삼각구동 시작
    Public Const EVENT_BUSY_HIGH = &H5E           ' 드라이브 busy High
    Public Const EVENT_BUSY_LOW = &H5F           ' 드라이브 busy Low
    Public Const EVENT_UNCONDITIONAL_RUN = &HFF         ' 무조건 수행(Queue command 한정)

    ' bit 23..16 : 2번 검출 이벤트 설정
    Function OPERATION_EVENT_2(ByVal a_Event As Integer) As Long
        OPERATION_EVENT_2 = (a_Event And &HFF) * 2 ^ 16
    End Function    ' bit 23..16
    ' bit 15..8 : 1번 검출 이벤트 설정
    Function OPERATION_EVENT_1(ByVal a_Event As Integer) As Long
        OPERATION_EVENT_1 = (a_Event And &HFF) * 2 ^ 8
    End Function    ' bit 15..8
    ' bit 7..0 : 이벤트 검출 후 실행할 Command
    Function OPERATION_EVENT_COMMAND(ByVal a_Command As Integer) As Long
        OPERATION_EVENT_COMMAND = (a_Command And &HFF)
    End Function    ' bit 7..0 : enum _FSCOMMAND 참조

End Module


