Option Strict Off
Option Explicit On
Module CAMCIPDef
	''/*-------------------------------------------------------------------------------------------------*
	' *        CAMC-IP (SMC-2V03)                                                             *
	' *-------------------------------------------------------------------------------------------------*/
	
	''/*-------------------------------------------------------------------------------------------------*
	' *        CAMC-5M, CAMC-FS 1.0 / 2.0에서 공통으로 사용하는 매크로...                               *
	' *-------------------------------------------------------------------------------------------------*/
	
	'/* Type 설정	*/
	
	Public Const POSITIVE_SENSE As Short = 1
	Public Const NEGATIVE_SENSE As Short = -1
	
	'/* Main clock							*/
	Public Const F_33M_CLK As Integer = 33000000 ' 33.000 MHz 
	Public Const F_32_768M_CLK As Integer = 32768000 ' 32.768 MHz 
	Public Const F_20M_CLK As Integer = 20000000 ' 20.000 MHz 
	Public Const F_16_384M_CLK As Integer = 16384000 ' 16.384 MHz : Default 
	
	''/* MODE1 DATA							
	' *
	' *	감속 개시 POINT 검출 방식
	' */
	
	Public Const AutoDetect As Short = &H0s
	Public Const RestPulse As Short = &H1s
	
	'/* Pulse Output Method					*/
	
	Public Const OneHighLowHigh As Short = &H0s ' 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
	Public Const OneHighHighLow As Short = &H1s ' 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
	Public Const OneLowLowHigh As Short = &H2s ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
	Public Const OneLowHighLow As Short = &H3s ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
	Public Const TwoCcwCwHigh As Short = &H4s ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High	 
	Public Const TwoCcwCwLow As Short = &H5s ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low	 
	Public Const TwoCwCcwHigh As Short = &H6s ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
	Public Const TwoCwCcwLow As Short = &H7s ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
	Public Const TwoPhase As Short = &H8s ' 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
	
	'/* Detect Destination Signal			*/
	
	Public Const PElmNegativeEdge As Short = &H0s ' +Elm(End limit) 하강 edge
	Public Const NElmNegativeEdge As Short = &H1s ' -Elm(End limit) 하강 edge
	Public Const PSlmNegativeEdge As Short = &H2s ' +Slm(Slowdown limit) 하강 edge
	Public Const NSlmNegativeEdge As Short = &H3s ' -Slm(Slowdown limit) 하강 edge
	Public Const In0DownEdge As Short = &H4s ' 범용입력 IN0(ORG) 하강 edge
	Public Const In1DownEdge As Short = &H5s ' 범용입력 IN1(Z상) 하강 edge
	Public Const In2DownEdge As Short = &H6s ' 범용입력 IN2(하강 edge
	Public Const In3DownEdge As Short = &H7s ' 범용입력 IN3 하강 edge
	Public Const PElmPositiveEdge As Short = &H8s ' +Elm(End limit) 상승 edge
	Public Const NElmPositiveEdge As Short = &H9s ' -Elm(End limit) 상승 edge
	Public Const PSlmPositiveEdge As Short = &HAs ' +Slm(Slowdown limit) 상승 edge
	Public Const NSlmPositiveEdge As Short = &HBs ' -Slm(Slowdown limit) 상승 edge
	Public Const In0UpEdge As Short = &HCs ' 범용입력 IN0(ORG) 상승 edge
	Public Const In1UpEdge As Short = &HDs ' 범용입력 IN1(Z상) 상승 edge
	Public Const In2UpEdge As Short = &HEs ' 범용입력 IN2 상승 edge
	Public Const In3UpEdge As Short = &HFs ' 범용입력 IN3 상승 edge
	
	'/* Mode2 Data   External Counter Input */
	
	Public Const UpDownMode As Short = &H0s ' Up/Down
	Public Const Sqr1Mode As Short = &H1s ' 1체배
	Public Const Sqr2Mode As Short = &H2s ' 2체배
	Public Const Sqr4Mode As Short = &H3s ' 4체배
	
	
	Public Const InpActiveLow As Short = 0
	Public Const InpActiveHigh As Short = 1
	
	
	Public Const AlmActiveLow As Short = 0
	Public Const AlmActiveHigh As Short = 1
	
	
	Public Const NSlmActiveLow As Short = 0
	Public Const NSlmActiveHigh As Short = 1
	
	
	Public Const PSlmActiveLow As Short = 0
	Public Const PSlmActiveHigh As Short = 1
	
	
	Public Const NElmActiveLow As Short = 0
	Public Const NElmActiveHigh As Short = 1
	
	
	Public Const PElmActiveLow As Short = 0
	Public Const PElmActiveHigh As Short = 1
	
	'/* Universal Input/Output				*/
	
	Public Const US_OUT0 As Short = &H1s
	Public Const US_OUT1 As Short = &H2s
	Public Const US_OUT2 As Short = &H4s
	Public Const US_OUT3 As Short = &H8s
	Public Const US_IN0 As Short = &H10s
	Public Const US_IN1 As Short = &H20s
	Public Const US_IN2 As Short = &H40s
	Public Const US_IN3 As Short = &H80s
	
	'/* BOARD SELECT							*/
	Public Const BASE_ADDR As Short = 0
	Public Const BOARD0_BASE_ADDR As Short = 0
	Public Const BOARD1_BASE_ADDR As Short = 1
	Public Const BOARD2_BASE_ADDR As Short = 2
	Public Const BOARD3_BASE_ADDR As Short = 3
	Public Const BOARD4_BASE_ADDR As Short = 4
	Public Const BOARD5_BASE_ADDR As Short = 5
	Public Const BOARD6_BASE_ADDR As Short = 6
	Public Const BOARD7_BASE_ADDR As Short = 7
	
	'/* CAMC CHIP SELECT						*/
	
	Public Const CCA_CAMC0_ADDR As Short = &H0s
	Public Const CCA_CAMC1_ADDR As Short = &H10s
	Public Const CCA_CAMC2_ADDR As Short = &H20s
	Public Const CCA_CAMC3_ADDR As Short = &H30s
	Public Const CCA_CAMC4_ADDR As Short = &H40s
	Public Const CCA_CAMC5_ADDR As Short = &H50s
	Public Const CCA_CAMC6_ADDR As Short = &H60s
	Public Const CCA_CAMC7_ADDR As Short = &H70s
	
	'/* CHIP SELECT		*/
	
	Public Const CS_CAMC0 As Short = &H0s
	Public Const CS_CAMC1 As Short = &H1s
	Public Const CS_CAMC2 As Short = &H2s
	Public Const CS_CAMC3 As Short = &H3s
	Public Const CS_CAMC4 As Short = &H4s
	Public Const CS_CAMC5 As Short = &H5s
	Public Const CS_CAMC6 As Short = &H6s
	Public Const CS_CAMC7 As Short = &H7s
	Public Const CS_CAMC8 As Short = &H8s
	Public Const CS_CAMC9 As Short = &H9s
	Public Const CS_CAMC10 As Short = &HAs
	Public Const CS_CAMC11 As Short = &HBs
	Public Const CS_CAMC12 As Short = &HCs
	Public Const CS_CAMC13 As Short = &HDs
	Public Const CS_CAMC14 As Short = &HEs
	Public Const CS_CAMC15 As Short = &HFs
	Public Const CS_CAMC16 As Short = &H10s
	Public Const CS_CAMC17 As Short = &H11s
	Public Const CS_CAMC18 As Short = &H12s
	Public Const CS_CAMC19 As Short = &H13s
	Public Const CS_CAMC20 As Short = &H14s
	Public Const CS_CAMC21 As Short = &H15s
	Public Const CS_CAMC22 As Short = &H16s
	Public Const CS_CAMC23 As Short = &H17s
	Public Const CS_CAMC24 As Short = &H18s
	Public Const CS_CAMC25 As Short = &H19s
	Public Const CS_CAMC26 As Short = &H1As
	Public Const CS_CAMC27 As Short = &H1Bs
	Public Const CS_CAMC28 As Short = &H1Cs
	Public Const CS_CAMC29 As Short = &H1Ds
	Public Const CS_CAMC30 As Short = &H1Es
	Public Const CS_CAMC31 As Short = &H1Fs
	
	
	Public Const AMC1X As Short = &H1s
	Public Const AMC2X As Short = &H2s
	Public Const AMC3X As Short = &H3s
	Public Const AMC4X As Short = &H4s
	Public Const AMC6X As Short = &H6s
	Public Const AMC8X As Short = &H8s
	
	'/*----------------------------------------------------------------------*/
	'/*						칩 초기화 구조체								*/
	'/*----------------------------------------------------------------------*/
	
	'/*----------------------------------------------------------------------*/
	'/*						이동방향										*/
	'/*----------------------------------------------------------------------*/
	
	Public Const MoveLeft As Short = -1
	Public Const MoveRight As Short = 1
	
	Public Const PI As Double = 3.141592
	
	' CAMC_IP_VERSION definition
	Public Const CAMC_IP_VERSION_10 As Short = &H11s ' IP Ver 1.0
	Public Const CAMC_IP_VERSION_20 As Short = &H20s ' IP Ver 2.0
	Public Const CAMC_IP_VERSION_30 As Short = &H30s ' IP Ver 3.0 ' not exist yet(2003)
	Public Const CAMC_IP_VERSION_40 As Short = &H40s ' IP Ver 4.0 ' not exist yet(2003)
	
	'/* Detect Destination Signal			*/
	
	Public Const IpPElmNegativeEdge As Short = &H0s ' +Elm(End limit) 하강 edge
	Public Const IpNElmNegativeEdge As Short = &H1s ' -Elm(End limit) 하강 edge
	Public Const IpPSlmNegativeEdge As Short = &H2s ' +Slm(Slowdown limit) 하강 edge
	Public Const IpNSlmNegativeEdge As Short = &H3s ' -Slm(Slowdown limit) 하강 edge
	Public Const IpUIO5DownEdge As Short = &H4s ' UIO5(ORG) 하강 edge
	Public Const IpUIO6DownEdge As Short = &H5s ' UIO6(Z상) 하강 edge
	Public Const IpUIO7DownEdge As Short = &H6s ' UIO7(범용) 하강 edge
	Public Const IpUIO8DownEdge As Short = &H7s ' UIO8(범용) 하강 edge
	Public Const IpPElmPositiveEdge As Short = &H8s ' +Elm(End limit) 상승 edge
	Public Const IpNElmPositiveEdge As Short = &H9s ' -Elm(End limit) 상승 edge
	Public Const IpPSlmPositiveEdge As Short = &HAs ' +Slm(Slowdown limit) 상승 edge
	Public Const IpNSlmPositiveEdge As Short = &HBs ' -Slm(Slowdown limit) 상승 edge
	Public Const IpUIO5UpEdge As Short = &HCs ' UIO5(ORG) 상승 edge
	Public Const IpUIO6UpEdge As Short = &HDs ' UIO6(Z상) 상승 edge
	Public Const IpUIO7UpEdge As Short = &HEs ' UIO7(범용) 상승 edge
	Public Const IpUIO8UpEdge As Short = &HFs ' UIO8(범용) 상승 edge
	
	'/* Write port							*/
	
	Public Const IpData1Write As Short = &H0s
	Public Const IpData2Write As Short = &H1s
	Public Const IpData3Write As Short = &H2s
	Public Const IpData4Write As Short = &H3s
	Public Const IpCommandWrite As Short = &H4s
	Public Const IpCommonCommandWrite As Short = &H7s
	
	'/* Read port							*/
	
	Public Const IpData1Read As Short = &H0s
	Public Const IpData2Read As Short = &H1s
	Public Const IpData3Read As Short = &H2s
	Public Const IpData4Read As Short = &H3s
	Public Const IpCommandRead As Short = &H4s
	Public Const IpAxisStatusMSB As Short = &H5s
	Public Const IpAxisStatusLSB As Short = &H6s
	Public Const IpCommonAxisStatus As Short = &H7s
	
	'/* IP End status : 0x0000이면 정상종료	*/
	
	Public Const IPEND_STATUS_SLM As Short = &H1s ' Bit 0, limit 감속정지 신호 입력에 의한 종료
	Public Const IPEND_STATUS_ELM As Short = &H2s ' Bit 1, limit 급정지 신호 입력에 의한 종료
	Public Const IPEND_STATUS_SSTOP_SIGNAL As Short = &H4s ' Bit 2, 감속 정지 신호 입력에 의한 종료
	Public Const IPEND_STATUS_ESTOP_SIGANL As Short = &H8s ' Bit 3, 급정지 신호 입력에 의한 종료
	Public Const IPEND_STATUS_SSTOP_COMMAND As Short = &H10s ' Bit 4, 감속 정지 명령에 의한 종료
	Public Const IPEND_STATUS_ESTOP_COMMAND As Short = &H20s ' Bit 5, 급정지 정지 명령에 의한 종료
	Public Const IPEND_STATUS_ALARM_SIGNAL As Short = &H40s ' Bit 6, Alarm 신호 입력에 희한 종료
	Public Const IPEND_STATUS_DATA_ERROR As Short = &H80s ' Bit 7, 데이터 설정 에러에 의한 종료
	Public Const IPFSEND_STATUS_DEVIATION_ERROR As Short = &H100s ' Bit 8, 탈조 에러에 의한 종료
	Public Const IPFSEND_STATUS_ORIGIN_DETECT As Short = &H200s ' Bit 9, 원점 검출에 의한 종료
	Public Const IPFSEND_STATUS_SIGNAL_DETECT As Short = &H400s ' Bit 10, 신호 검출에 의한 종료(Signal search-1/2 drive 종료)
	Public Const IPFSEND_STATUS_PRESET_PULSE_DRIVE As Short = &H800s ' Bit 11, Preset pulse drive 종료
	Public Const IPFSEND_STATUS_SENSOR_PULSE_DRIVE As Short = &H1000s ' Bit 12, Sensor pulse drive 종료
	Public Const IPFSEND_STATUS_LIMIT As Short = &H2000s ' Bit 13, Limit 완전정지에 의한 종료
	Public Const IPFSEND_STATUS_SOFTLIMIT As Short = &H4000s ' Bit 14, Soft limit에 의한 종료
	Public Const IPFSEND_STATUS_INTERPOLATION_DRIVE As Short = &H8000s ' Bit 15, Soft limit에 의한 종료
	
	'/* FS Drive status						*/
	
	Public Const IPDRIVE_STATUS_BUSY As Short = &H1s ' Bit 0, BUSY(드라이브 구동 중)
	Public Const IPDRIVE_STATUS_DOWN As Short = &H2s ' Bit 1, DOWN(감속 중)
	Public Const IPDRIVE_STATUS_CONST As Short = &H4s ' Bit 2, CONST(등속 중)
	Public Const IPDRIVE_STATUS_UP As Short = &H8s ' Bit 3, UP(가속 중)
	Public Const IPDRIVE_STATUS_ICL As Short = &H10s ' Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
	Public Const IPDRIVE_STATUS_ICG As Short = &H20s ' Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
	Public Const IPDRIVE_STATUS_ECL As Short = &H40s ' Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
	Public Const IPDRIVE_STATUS_ECG As Short = &H80s ' Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)
	Public Const IPDRIVE_STATUS_DRIVE_DIRECTION As Short = &H100s ' Bit 8, 드라이브 방향 신호(0=CW/1=CCW)
	Public Const IPDRIVE_STATUS_COMMAND_BUSY As Short = &H200s ' Bit 9, 명령어 수행중
	Public Const IPDRIVE_STATUS_PRESET_DRIVING As Short = &H400s ' Bit 10, Preset pulse drive 중
	Public Const IPDRIVE_STATUS_CONTINUOUS_DRIVING As Short = &H800s ' Bit 11, Continuouse speed drive 중
	Public Const IPDRIVE_STATUS_SIGNAL_SEARCH_DRIVING As Short = &H1000s ' Bit 12, Signal search-1/2 drive 중
	Public Const IPDRIVE_STATUS_ORG_SEARCH_DRIVING As Short = &H2000s ' Bit 13, 원점 검출 drive 중
	Public Const IPDRIVE_STATUS_MPG_DRIVING As Short = &H4000s ' Bit 14, MPG drive 중
	Public Const IPDRIVE_STATUS_SENSOR_DRIVING As Short = &H8000s ' Bit 15, Sensor positioning drive 중
	Public Const IPDRIVE_STATUS_L_C_INTERPOLATION As Integer = &H10000 ' Bit 16, 직선/원호 보간 중
	Public Const IPDRIVE_STATUS_PATTERN_INTERPOLATION As Integer = &H20000 ' Bit 17, 비트 패턴 보간 중
	Public Const IPDRIVE_STATUS_INTERRUPT_BANK1 As Integer = &H40000 ' Bit 18, 인터럽트 bank1에서 발생
	Public Const IPDRIVE_STATUS_INTERRUPT_BANK2 As Integer = &H80000 ' Bit 19, 인터럽트 bank2에서 발생
	
	'/* IP mechanical signal					*/
	
	Public Const IPMECHANICAL_PELM_LEVEL As Short = &H1s ' Bit 0, +Limit 급정지 신호가 액티브 됨
	Public Const IPMECHANICAL_NELM_LEVEL As Short = &H2s ' Bit 1, -Limit 급정지 신호 액티브 됨
	Public Const IPMECHANICAL_PSLM_LEVEL As Short = &H4s ' Bit 2, +limit 감속정지 신호 액티브 됨
	Public Const IPMECHANICAL_NSLM_LEVEL As Short = &H8s ' Bit 3, -limit 감속정지 신호 액티브 됨
	Public Const IPMECHANICAL_ALARM_LEVEL As Short = &H10s ' Bit 4, Alarm 신호 액티브 됨
	Public Const IPMECHANICAL_INP_LEVEL As Short = &H20s ' Bit 5, Inposition 신호 액티브 됨
	Public Const IPMECHANICAL_ENC_DOWN_LEVEL As Short = &H40s ' Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
	Public Const IPMECHANICAL_ENC_UP_LEVEL As Short = &H80s ' Bit 7, 엔코더 UP(A상) 신호 입력 Level
	Public Const IPMECHANICAL_EXMP_LEVEL As Short = &H100s ' Bit 8, EXMP 신호 입력 Level
	Public Const IPMECHANICAL_EXPP_LEVEL As Short = &H200s ' Bit 9, EXPP 신호 입력 Level
	Public Const IPMECHANICAL_MARK_LEVEL As Short = &H400s ' Bit 10, MARK# 신호 액티브 됨
	Public Const IPMECHANICAL_SSTOP_LEVEL As Short = &H800s ' Bit 11, SSTOP 신호 액티브 됨
	Public Const IPMECHANICAL_ESTOP_LEVEL As Short = &H1000s ' Bit 12, ESTOP 신호 액티브 됨
	Public Const IPMECHANICAL_SYNC_LEVEL As Short = &H2000s ' Bit 13, SYNC 신호 입력 Level
	Public Const IPMECHANICAL_MODE8_16_LEVEL As Short = &H4000s ' Bit 14, MODE8_16 신호 입력 Level
	
	'/* 드라이브 동작 설정					*/
	
	Public Const IPSYM_LINEAR As Short = &H0s ' 대칭 사다리꼴
	Public Const IPASYM_LINEAR As Short = &H1s ' 비대칭 사다리꼴
	Public Const IPSYM_CURVE As Short = &H2s ' 대칭 포물선(S-Curve)
	Public Const IPASYM_CURVE As Short = &H3s ' 비대칭 포물선(S-Curve)
	Public Const IPSYM_LINEAR_FRAC As Short = &H8s ' 소수점 사용 대칭 사다리꼴
	Public Const IPASYM_LINEAR_FRAC As Short = &H9s ' 소수점 사용 비대칭 사다리꼴
	Public Const IPSYM_CURVE_FRAC As Short = &HAs ' 소수점 사용 대칭 포물선(S-Curve)
	Public Const IPASYM_CURVE_FRAC As Short = &HBs ' 소수점 사용 비대칭 포물선(S-Curve)
	
	'/* IP COMMAND LIST							*/
	
	' PGM-1 Group Register
	Public Const IPxyRANGERead As Short = &H0s ' PGM-1 RANGE READ, 16bit, 0xFFFF
	Public Const IPxyRANGEWrite As Short = &H80s ' PGM-1 RANGE WRITE
	Public Const IPxySTDRead As Short = &H1s ' PGM-1 START/STOP SPEED DATA READ, 16bit, 
	Public Const IPxySTDWrite As Short = &H81s ' PGM-1 START/STOP SPEED DATA WRITE
	Public Const IPxyOBJRead As Short = &H2s ' PGM-1 OBJECT SPEED DATA READ, 16bit, 
	Public Const IPxyOBJWrite As Short = &H82s ' PGM-1 OBJECT SPEED DATA WRITE
	Public Const IPxyRATE1Read As Short = &H3s ' PGM-1 RATE-1 DATA READ, 16bit, 0xFFFF
	Public Const IPxyRATE1Write As Short = &H83s ' PGM-1 RATE-1 DATA WRITE
	Public Const IPxyRATE2Read As Short = &H4s ' PGM-1 RATE-2 DATA READ, 16bit, 0xFFFF
	Public Const IPxyRATE2Write As Short = &H84s ' PGM-1 RATE-2 DATA WRITE
	Public Const IPxyRATE3Read As Short = &H5s ' PGM-1 RATE-3 DATA READ, 16bit, 0xFFFF
	Public Const IPxyRATE3Write As Short = &H85s ' PGM-1 RATE-3 DATA WRITE
	Public Const IPxyRCP12Read As Short = &H6s ' PGM-1 RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
	Public Const IPxyRCP12Write As Short = &H86s ' PGM-1 RATE CHANGE POINT 1-2 WRITE
	Public Const IPxyRCP23Read As Short = &H7s ' PGM-1 RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
	Public Const IPxyRCP23Write As Short = &H87s ' PGM-1 RATE CHANGE POINT 2-3 WRITE
	Public Const IPxySW1Read As Short = &H8s ' PGM-1 SW-1 DATA READ, 15bit, 0x7FFF
	Public Const IPxySW1Write As Short = &H88s ' PGM-1 SW-1 DATA WRITE
	Public Const IPxySW2Read As Short = &H9s ' PGM-1 SW-2 DATA READ, 15bit, 0x7FFF
	Public Const IPxySW2Write As Short = &H89s ' PGM-1 SW-2 DATA WRITE
	Public Const IPxyPWMRead As Short = &HAs ' PGM-1 PWM 출력 설정 DATA READ(0~6), 3bit, 0x00
	Public Const IPxyPWMWrite As Short = &H8As ' PGM-1 PWM 출력 설정 DATA WRITE
	Public Const IPxyREARRead As Short = &HBs ' PGM-1 SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
	Public Const IPxyREARWrite As Short = &H8Bs ' PGM-1 SLOW DOWN/REAR PULSE WRITE
	Public Const IPxySPDRead As Short = &HCs ' PGM-1 현재 SPEED DATA READ, 16bit, 0x0000
	Public Const IPxyNoOperation_8C As Short = &H8Cs ' No operation
	Public Const IPxySPDCMPRead As Short = &HDs ' PGM-1 현재 SPEED 비교 DATA READ, 16bit, 0x0000
	Public Const IPxySPDCMPWrite As Short = &H8Ds ' PGM-1 현재 SPEED 비교 DATA WRITE
	Public Const IPxyDRVPULSERead As Short = &HEs ' PGM-1 DRIVE PULSE COUNTER READ, 32bit, 0x00000000
	Public Const IPxyNoOperation_8E As Short = &H8Es ' No operation
	Public Const IPxyPRESETPULSERead As Short = &HFs ' PGM-1 PRESET PULSE DATA READ, 32bit, 0x00000000
	Public Const IPxyNoOperation_8F As Short = &H8Fs ' No operation
	
	' PGM-1 Update Group Register
	Public Const IPxyURANGERead As Short = &H10s ' PGM-1 UP-DATE RANGE READ, 16bit, 0xFFFF
	Public Const IPxyURANGEWrite As Short = &H90s ' PGM-1 UP-DATE RANGE WRITE
	Public Const IPxyUSTDRead As Short = &H11s ' PGM-1 UP-DATE START/STOP SPEED DATA READ, 16bit, 
	Public Const IPxyUSTDWrite As Short = &H91s ' PGM-1 UP-DATE START/STOP SPEED DATA WRITE
	Public Const IPxyUOBJRead As Short = &H12s ' PGM-1 UP-DATE OBJECT SPEED DATA READ, 16bit, 
	Public Const IPxyUOBJWrite As Short = &H92s ' PGM-1 UP-DATE OBJECT SPEED DATA WRITE
	Public Const IPxyURATE1Read As Short = &H13s ' PGM-1 UP-DATE RATE-1 DATA READ, 16bit, 0xFFFF
	Public Const IPxyURATE1Write As Short = &H93s ' PGM-1 UP-DATE RATE-1 DATA WRITE
	Public Const IPxyURATE2Read As Short = &H14s ' PGM-1 UP-DATE RATE-2 DATA READ, 16bit, 0xFFFF
	Public Const IPxyURATE2Write As Short = &H94s ' PGM-1 UP-DATE RATE-2 DATA WRITE
	Public Const IPxyURATE3Read As Short = &H15s ' PGM-1 UP-DATE RATE-3 DATA READ, 16bit, 0xFFFF
	Public Const IPxyURATE3Write As Short = &H95s ' PGM-1 UP-DATE RATE-3 DATA WRITE
	Public Const IPxyURCP12Read As Short = &H16s ' PGM-1 UP-DATE RATE CHANGE POINT 1-2 READ, 16bit, 0xFFFF
	Public Const IPxyURCP12Write As Short = &H96s ' PGM-1 UP-DATE RATE CHANGE POINT 1-2 WRITE
	Public Const IPxyURCP23Read As Short = &H17s ' PGM-1 UP-DATE RATE CHANGE POINT 2-3 READ, 16bit, 0xFFFF
	Public Const IPxyURCP23Write As Short = &H97s ' PGM-1 UP-DATE RATE CHANGE POINT 2-3 WRITE
	Public Const IPxyUSW1Read As Short = &H18s ' PGM-1 UP-DATE SW-1 DATA READ, 15bit, 0x7FFF
	Public Const IPxyUSW1Write As Short = &H98s ' PGM-1 UP-DATE SW-1 DATA WRITE
	Public Const IPxyUSW2Read As Short = &H19s ' PGM-1 UP-DATE SW-2 DATA READ, 15bit, 0x7FFF
	Public Const IPxyUSW2Write As Short = &H99s ' PGM-1 UP-DATE SW-2 DATA WRITE
	Public Const IPxyNoOperation_1A As Short = &H1As ' No operation
	Public Const IPxyNoOperation_9A As Short = &H9As ' No operation
	Public Const IPxyUREARRead As Short = &H1Bs ' PGM-1 UP-DATE SLOW DOWN/REAR PULSE READ, 32bit, 0x00000000
	Public Const IPxyUREARWrite As Short = &H9Bs ' PGM-1 UP-DATE SLOW DOWN/REAR PULSE WRITE
	Public Const IPxySPDRead_1C As Short = &H1Cs ' PGM-1 UP-DATA CURRENT SPEED READ(Same with 0x0C)
	Public Const IPxyNoOperation_9C As Short = &H9Cs ' No operation
	Public Const IPxySPDCMPRead_1D As Short = &H1Ds ' PGM-1 현재 SPEED 비교 DATA READ(Same with 0x0D) 
	Public Const IPxySPDCMPWrite_9D As Short = &H9Ds ' PGM-1 현재 SPEED 비교 DATA WRITE(Same with 0x8D) 
	Public Const IPxyACCPULSERead As Short = &H1Es ' PGM-1 가속 PULSE COUNTER READ, 32bit, 0x00000000
	Public Const IPxyNoOperation_9E As Short = &H9Es ' No operation
	Public Const IPxyPRESETPULSERead_1F As Short = &H1Fs ' PGM-1 PRESET PULSE DATA READ(Same with 0x0F)
	Public Const IPxyNoOperation_9F As Short = &H9Fs ' No operation
	
	' PGM-2 Group Register
	Public Const IPxyNoOperation_20 As Short = &H20s ' No operation
	Public Const IPxyPPRESETDRV As Short = &HA0s ' +PRESET PULSE DRIVE, 32
	Public Const IPxyNoOperation_21 As Short = &H21s ' No operation
	Public Const IPxyPCONTDRV As Short = &HA1s ' +CONTINUOUS DRIVE
	Public Const IPxyNoOperation_22 As Short = &H22s ' No operation
	Public Const IPxyPSCH1DRV As Short = &HA2s ' +SIGNAL SEARCH-1 DRIVE
	Public Const IPxyNoOperation_23 As Short = &H23s ' No operation
	Public Const IPxyPSCH2DRV As Short = &HA3s ' +SIGNAL SEARCH-2 DRIVE
	Public Const IPxyNoOperation_24 As Short = &H24s ' No operation
	Public Const IPxyPORGDRV As Short = &HA4s ' +ORIGIN(원점) SEARCH DRIVE
	Public Const IPxyNoOperation_25 As Short = &H25s ' No operation
	Public Const IPxyMPRESETDRV As Short = &HA5s ' -PRESET PULSE DRIVE, 32
	Public Const IPxyNoOperation_26 As Short = &H26s ' No operation
	Public Const IPxyMCONTDRV As Short = &HA6s ' -CONTINUOUS DRIVE
	Public Const IPxyNoOperation_27 As Short = &H27s ' No operation
	Public Const IPxyMSCH1DRV As Short = &HA7s ' -SIGNAL SEARCH-1 DRIVE
	Public Const IPxyNoOperation_28 As Short = &H28s ' No operation
	Public Const IPxyMSCH2DRV As Short = &HA8s ' -SIGNAL SEARCH-2 DRIVE
	Public Const IPxyNoOperation_29 As Short = &H29s ' No operation
	Public Const IPxyMORGDRV As Short = &HA9s ' -ORIGIN(원점) SEARCH DRIVE
	Public Const IPxyPULSEOVERRead As Short = &H2As ' Preset/MPG drive override pulse data read
	Public Const IPxyPULSEOVERWrite As Short = &HAAs ' PRESET PULSE DATA OVERRIDE(ON_BUSY)
	Public Const IPxyNoOperation_2B As Short = &H2Bs ' No operation
	Public Const IPxySSTOPCMD As Short = &HABs ' SLOW DOWN STOP
	Public Const IPxyNoOperation_2C As Short = &H2Cs ' No operation
	Public Const IPxyESTOPCMD As Short = &HACs ' EMERGENCY STOP
	Public Const IPxyDRIVEMODERead As Short = &H2Ds ' 드라이브 동작 설정 DATA READ
	Public Const IPxyDRIVEMODEWrite As Short = &HADs ' 드라이브 동작 설정 DATA WRITE
	Public Const IPxyMPGCONRead As Short = &H2Es ' MPG OPERATION SETTING DATA READ, 3bit, 0x00	
	Public Const IPxyMPGCONWrite As Short = &HAEs ' MPG OPERATION SETTING DATA WRITE				
	Public Const IPxyPULSEMPGRead As Short = &H2Fs ' MPG PRESET PULSE DATA READ, 32bit, 0x00000000
	Public Const IPxyPULSEMPGWrite As Short = &HAFs ' MPG PRESET PULSE DATA WRITE					
	
	'	/* Extension Group Register */
	Public Const IPxyNoOperation_30 As Short = &H30s ' No operation
	Public Const IPxyPSPO1DRV As Short = &HB0s ' +SENSOR POSITIONING DRIVE I
	Public Const IPxyNoOperation_31 As Short = &H31s ' No operation
	Public Const IPxyMSPO1DRV As Short = &HB1s ' -SENSOR POSITIONING DRIVE I
	Public Const IPxyNoOperation_32 As Short = &H32s ' No operation
	Public Const IPxyPSPO2DRV As Short = &HB2s ' +SENSOR POSITIONING DRIVE II
	Public Const IPxyNoOperation_33 As Short = &H33s ' No operation
	Public Const IPxyMSPO2DRV As Short = &HB3s ' -SENSOR POSITIONING DRIVE II
	Public Const IPxyNoOperation_34 As Short = &H34s ' No operation
	Public Const IPxyPSPO3DRV As Short = &HB4s ' +SENSOR POSITIONING DRIVE III
	Public Const IPxyNoOperation_35 As Short = &H35s ' No operation
	Public Const IPxyMSPO3DRV As Short = &HB5s ' -SENSOR POSITIONING DRIVE III
	Public Const IPxySWLMTCONRead As Short = &H36s ' SOFT LIMIT 설정 READ, 3bit, 0x00
	Public Const IPxySWLMTCONWrite As Short = &HB6s ' SOFT LIMIT 설정 WRITE
	Public Const IPxyMSWLMTCOMPRead As Short = &H37s ' -SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x80000000
	Public Const IPxyMSWLMTCOMPWrite As Short = &HB7s ' -SOFT LIMIT 비교 레지스터 설정 WRITE
	Public Const IPxyPSWLMTCOMPRead As Short = &H38s ' +SOFT LIMIT 비교 레지스터 설정 READ, 32bit, 0x7FFFFFFF
	Public Const IPxyPSWLMTCOMPWrite As Short = &HB8s ' +SOFT LIMIT 비교 레지스터 설정 WRITE
	Public Const IPxyTRGCONRead As Short = &H39s ' TRIGGER MODE 설정 READ, 32bit, 0x00010000
	Public Const IPxyTRGCONWrite As Short = &HB9s ' TRIGGER MODE 설정 WRITE
	Public Const IPxyTRGCOMPRead As Short = &H3As ' TRIGGER 비교 데이터 설정 READ, 32bit, 0x00000000
	Public Const IPxyTRGCOMPWrite As Short = &HBAs ' TRIGGER 비교 데이터 설정 WRITE
	Public Const IPxyICMRead As Short = &H3Bs ' INTERNAL M-DATA 설정 READ, 32bit, 0x80000000
	Public Const IPxyICMWrite As Short = &HBBs ' INTERNAL M-DATA 설정 WRITE
	Public Const IPxyECMRead As Short = &H3Cs ' EXTERNAL M-DATA 설정 READ, 32bit, 0x80000000
	Public Const IPxyECMWrite As Short = &HBCs ' EXTERNAL M-DATA 설정 WRITE
	Public Const IPxySTOPPWRead As Short = &H3Ds ' Stop pulse width Read
	Public Const IPxySTOPPWWrite As Short = &HBDs ' Stop pulse width Write
	Public Const IPxyNoOperation_3E As Short = &H3Es ' No operation
	Public Const IPxyNoOperation_BE As Short = &HBEs ' No operation
	Public Const IPxyNoOperation_3F As Short = &H3Fs ' No operation
	Public Const IPxyTRGCMD As Short = &HBFs ' TRIG output signal generation command
	
	'	/* Interpolation Group	Registers	*/
	Public Const IPxCIRXCRead As Short = &H40s ' Circular interpolation X axis center point read
	Public Const IPxCIRXCWrite As Short = &HC0s ' Circular interpolation X axis center point write 
	Public Const IPxCIRYCRead As Short = &H41s ' Circular interpolation Y axis center point read 
	Public Const IPxCIRYCWrite As Short = &HC1s ' Circular interpolation Y axis center point write  
	Public Const IPxENDXRead As Short = &H42s ' Interpolation X axis end point read 
	Public Const IPxENDXWrite As Short = &HC2s ' Interpolation X axis end point write  
	Public Const IPxENDYRead As Short = &H43s ' Interpolation Y axis end point read  
	Public Const IPxENDYWrite As Short = &HC3s ' Interpolation Y axis end point write  
	Public Const IPxPTXENDRead As Short = &H44s ' Pattern interpolation X Queue data read
	Public Const IPxPTXENDWrite As Short = &HC4s ' Pattern interpolation X Queue data with queue push 
	Public Const IPxPTYENDRead As Short = &H45s ' Pattern interpolation Y Queue data read 
	Public Const IPxPTYENDWrite As Short = &HC5s ' Pattern interpolation Y Queue data write
	Public Const IPxPTQUEUERead As Short = &H46s ' Pattern interpolation Queue index read
	Public Const IPxNoOperation_C6 As Short = &HC6s ' No operation
	Public Const IPxNoOperation_47 As Short = &H47s ' No operation
	Public Const IPxNoOperation_C7 As Short = &HC7s ' No operation
	Public Const IPxNoOperation_48 As Short = &H48s ' No operation
	Public Const IPxNoOperation_C8 As Short = &HC8s ' No operation
	Public Const IPxNoOperation_49 As Short = &H49s ' No operation
	Public Const IPxNoOperation_C9 As Short = &HC9s ' No operation
	Public Const IPxINPSTATUSRead As Short = &H4As ' Interpolation Status register read
	Public Const IPxNoOperation_CA As Short = &HCAs ' No operation
	Public Const IPxINPMODE_4B As Short = &H4Bs ' Interpolation mode in Queue TOP contets
	Public Const IPxLINPDRV As Short = &HCBs ' Linear interpolation with Queue push
	Public Const IPxINPMODE_4C As Short = &H4Cs ' Interpolation mode in Queue TOP contets
	Public Const IPxCINPDRV As Short = &HCCs ' Circular interpolation with Queue push 
	Public Const IPxBPINPMODE As Short = &H4Ds ' Bit Pattern Interpolation mode in Queue TOP contets
	Public Const IPxBPINPDRV As Short = &HCDs ' Bit pattern Drive
	Public Const IPxNoOperation_4E As Short = &H4Es ' No Operation
	Public Const IPxNoOperation_CE As Short = &HCEs ' No Operation 
	Public Const IPxNoOperation_4F As Short = &H4Fs ' No Operation 
	Public Const IPxNoOperation_CF As Short = &HCFs ' No Operation 
	
	'	/* Arithemetic Group Register */
	Public Const IPxNoOperation_50 As Short = &H50s ' No Operation
	Public Const IPxINPCLR As Short = &HD0s ' Initialize all interpolation control block
	Public Const IPxINPMPOINTRead As Short = &H51s ' Interpolation deceleration manual point(unsigned) read
	Public Const IPxINPMPOINTWrite As Short = &HD1s ' Interpolation deceleration manual point(unsigned) write
	Public Const IPxNoOperation_52 As Short = &H52s ' No Operation
	Public Const IPxINPCLRSWrite As Short = &HD2s ' Initialize interpolation control block with target selection
	Public Const IPxNoOperation_53 As Short = &H53s ' No Operation
	Public Const IPxINPDRVWrite As Short = &HD3s ' linear/circular drive start with queue data(Hold on mode), Restart on pause
	Public Const IPxNoOperation_54 As Short = &H54s ' No operation
	Public Const IPxNoOperation_D4 As Short = &HD4s ' No operation
	Public Const IPxNoOperation_55 As Short = &H55s ' No operation
	Public Const IPxARTSHOT As Short = &HD5s ' Arithmetic block One time execution
	Public Const IPxARTSHOPERRead As Short = &H56s ' Arithmetic block shift and operation selection Read
	Public Const IPxARTSHOPERWrite As Short = &HD6s ' Arithmetic block shift and operation selection Write
	Public Const IPxARTSHRead As Short = &H57s ' Arithmetic block shift amount data Read
	Public Const IPxARTSHWrite As Short = &HD7s ' Arithmetic block shift amount data Write
	Public Const IPxARTSOURCERead As Short = &H58s ' Arithmetic block operand configure data Read
	Public Const IPxARTSOURCEWrite As Short = &HD8s ' Arithmetic block operand configure data Write
	Public Const IPxARTCRESULT1Read As Short = &H59s ' Arithmetic first compare result data Read
	Public Const IPxNoOperation_D9 As Short = &HD9s ' No Operation
	Public Const IPxARTCRESULT2Read As Short = &H5As ' Arithmetic second compare result data Read
	Public Const IPxNoOperation_DA As Short = &HDAs ' No Operation
	Public Const IPxARTARESULT1Read As Short = &H5Bs ' Arithmetic first algebraic result data Read
	Public Const IPxNoOperation_DB As Short = &HDBs ' No Operation
	Public Const IPxARTARESULT2Read As Short = &H5Cs ' Arithmetic second algebraic result data Read
	Public Const IPxNoOperation_DC As Short = &HDCs ' No operation
	Public Const IPxARTUSERARead As Short = &H5Ds ' Arithmetic block User operand A Read
	Public Const IPxARTUSERAWrite As Short = &HDDs ' Arithmetic block User operand A Write
	Public Const IPxARTUSERBRead As Short = &H5Es ' Arithmetic block User operand B Read
	Public Const IPxARTUSERBWrite As Short = &HDEs ' Arithmetic block User operand B Write
	Public Const IPxARTUSERCRead As Short = &H5Fs ' Arithmetic block User operand C Read
	Public Const IPxARTUSERCWrite As Short = &HDFs ' Arithmetic block User operand C Write
	
	'	/* Scripter Group Register			*/
	Public Const IPySCRCON1Read As Short = &H40s ' 스크립트 동작 설정 레지스터-1 READ, 32bit, 0x00000000
	Public Const IPySCRCON1Write As Short = &HC0s ' 스크립트 동작 설정 레지스터-1 WRITE
	Public Const IPySCRCON2Read As Short = &H41s ' 스크립트 동작 설정 레지스터-2 READ, 32bit, 0x00000000
	Public Const IPySCRCON2Write As Short = &HC1s ' 스크립트 동작 설정 레지스터-2 WRITE
	Public Const IPySCRCON3Read As Short = &H42s ' 스크립트 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
	Public Const IPySCRCON3Write As Short = &HC2s ' 스크립트 동작 설정 레지스터-3 WRITE
	Public Const IPySCRCONQRead As Short = &H43s ' 스크립트 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
	Public Const IPySCRCONQWrite As Short = &HC3s ' 스크립트 동작 설정 레지스터-Queue WRITE
	Public Const IPySCRDATA1Read As Short = &H44s ' 스크립트 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
	Public Const IPySCRDATA1Write As Short = &HC4s ' 스크립트 동작 데이터 레지스터-1 WRITE
	Public Const IPySCRDATA2Read As Short = &H45s ' 스크립트 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
	Public Const IPySCRDATA2Write As Short = &HC5s ' 스크립트 동작 데이터 레지스터-2 WRITE
	Public Const IPySCRDATA3Read As Short = &H46s ' 스크립트 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
	Public Const IPySCRDATA3Write As Short = &HC6s ' 스크립트 동작 데이터 레지스터-3 WRITE
	Public Const IPySCRDATAQRead As Short = &H47s ' 스크립트 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
	Public Const IPySCRDATAQWrite As Short = &HC7s ' 스크립트 동작 데이터 레지스터-Queue WRITE
	Public Const IPyNoOperation_48 As Short = &H48s ' No operation
	Public Const IPySCRQCLR As Short = &HC8s ' 스크립트 Queue clear
	Public Const IPySCRCQSIZERead As Short = &H49s ' 스크립트 동작 설정 Queue 인덱스 READ, 4bit, 0x00
	Public Const IPyNoOperation_C9 As Short = &HC9s ' No operation
	Public Const IPySCRDQSIZERead As Short = &H4As ' 스크립트 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
	Public Const IPyNoOperation_CA As Short = &HCAs ' No operation
	Public Const IPySCRQFLAGRead As Short = &H4Bs ' 스크립트 Queue Full/Empty Flag READ, 4bit, 0x05
	Public Const IPyNoOperation_CB As Short = &HCBs ' No operation
	Public Const IPySCRQSIZECONRead As Short = &H4Cs ' 스크립트 Queue size 설정(0~13) READ, 16bit, 0xD0D0
	Public Const IPySCRQSIZECONWrite As Short = &HCCs ' 스크립트 Queue size 설정(0~13) WRITE
	Public Const IPySCRQSTATUSRead As Short = &H4Ds ' 스크립트 Queue status READ, 12bit, 0x005
	Public Const IPyNoOperation_CD As Short = &HCDs ' No operation
	Public Const IPyNoOperation_4E As Short = &H4Es ' No operation
	Public Const IPyNoOperation_CE As Short = &HCEs ' No operation
	Public Const IPyNoOperation_4F As Short = &H4Fs ' No operation
	Public Const IPyNoOperation_CF As Short = &HCFs ' No operation
	
	'	/* Caption Group Register */
	Public Const IPyCAPCON1Read As Short = &H50s ' 갈무리 동작 설정 레지스터-1 READ, 32bit, 0x00000000
	Public Const IPyCAPCON1Write As Short = &HD0s ' 갈무리 동작 설정 레지스터-1 WRITE
	Public Const IPyCAPCON2Read As Short = &H51s ' 갈무리 동작 설정 레지스터-2 READ, 32bit, 0x00000000
	Public Const IPyCAPCON2Write As Short = &HD1s ' 갈무리 동작 설정 레지스터-2 WRITE
	Public Const IPyCAPCON3Read As Short = &H52s ' 갈무리 동작 설정 레지스터-3 READ, 32bit, 0x00000000 
	Public Const IPyCAPCON3Write As Short = &HD2s ' 갈무리 동작 설정 레지스터-3 WRITE
	Public Const IPyCAPCONQRead As Short = &H53s ' 갈무리 동작 설정 레지스터-Queue READ, 32bit, 0x00000000
	Public Const IPyCAPCONQWrite As Short = &HD3s ' 갈무리 동작 설정 레지스터-Queue WRITE
	Public Const IPyCAPDATA1Read As Short = &H54s ' 갈무리 동작 데이터 레지스터-1 READ, 32bit, 0x00000000 
	Public Const IPyNoOperation_D4 As Short = &HD4s ' No operation
	Public Const IPyCAPDATA2Read As Short = &H55s ' 갈무리 동작 데이터 레지스터-2 READ, 32bit, 0x00000000 
	Public Const IPyNoOperation_D5 As Short = &HD5s ' No operation
	Public Const IPyCAPDATA3Read As Short = &H56s ' 갈무리 동작 데이터 레지스터-3 READ, 32bit, 0x00000000 
	Public Const IPyNoOperation_D6 As Short = &HD6s ' No operation
	Public Const IPyCAPDATAQRead As Short = &H57s ' 갈무리 동작 데이터 레지스터-Queue READ, 32bit, 0x00000000 
	Public Const IPyNoOperation_D7 As Short = &HD7s ' No operation
	Public Const IPyNoOperation_58 As Short = &H58s ' No operation
	Public Const IPyCAPQCLR As Short = &HD8s ' 갈무리 Queue clear
	Public Const IPyCAPCQSIZERead As Short = &H59s ' 갈무리 동작 설정 Queue 인덱스 READ, 4bit, 0x00
	Public Const IPyNoOperation_D9 As Short = &HD9s ' No operation
	Public Const IPyCAPDQSIZERead As Short = &H5As ' 갈무리 동작 데이터 Queue 인덱스 READ, 4bit, 0x00
	Public Const IPyNoOperation_DA As Short = &HDAs ' No operation
	Public Const IPyCAPQFLAGRead As Short = &H5Bs ' 갈무리 Queue Full/Empty Flag READ, 4bit, 0x05
	Public Const IPyNoOperation_DB As Short = &HDBs ' No operation
	Public Const IPyCAPQSIZECONRead As Short = &H5Cs ' 갈무리 Queue size 설정(0~13) READ, 16bit, 0xD0D0
	Public Const IPyCAPQSIZECONWrite As Short = &HDCs ' 갈무리 Queue size 설정(0~13) WRITE
	Public Const IPyCAPQSTATUSRead As Short = &H5Ds ' 갈무리 Queue status READ, 12bit, 0x005
	Public Const IPyNoOperation_DD As Short = &HDDs ' No operation
	Public Const IPyNoOperation_5E As Short = &H5Es ' No operation
	Public Const IPyNoOperation_DE As Short = &HDEs ' No operation
	Public Const IPyNoOperation_5F As Short = &H5Fs ' No operation
	Public Const IPyNoOperation_DF As Short = &HDFs ' No operation
	
	'	/* BUS - 1 Group Register			*/
	Public Const IPxyINCNTRead As Short = &H60s ' INTERNAL COUNTER DATA READ(Signed), 32bit, 0x00000000
	Public Const IPxyINCNTWrite As Short = &HE0s ' INTERNAL COUNTER DATA WRITE(Signed)
	Public Const IPxyINCNTCMPRead As Short = &H61s ' INTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
	Public Const IPxyINCNTCMPWrite As Short = &HE1s ' INTERNAL COUNTER COMPARATE DATA WRITE(Signed)
	Public Const IPxyINCNTSCALERead As Short = &H62s ' INTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
	Public Const IPxyINCNTSCALEWrite As Short = &HE2s ' INTERNAL COUNTER PRE-SCALE DATA WRITE
	Public Const IPxyICPRead As Short = &H63s ' INTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
	Public Const IPxyICPWrite As Short = &HE3s ' INTERNAL COUNTER P-DATA WRITE
	Public Const IPxyEXCNTRead As Short = &H64s ' EXTERNAL COUNTER DATA READ READ(Signed), 32bit, 0x00000000
	Public Const IPxyEXCNTWrite As Short = &HE4s ' EXTERNAL COUNTER DATA READ WRITE(Signed)
	Public Const IPxyEXCNTCMPRead As Short = &H65s ' EXTERNAL COUNTER COMPARATE DATA READ(Signed), 32bit, 0x00000000
	Public Const IPxyEXCNTCMPWrite As Short = &HE5s ' EXTERNAL COUNTER COMPARATE DATA WRITE(Signed)
	Public Const IPxyEXCNTSCALERead As Short = &H66s ' EXTERNAL COUNTER PRE-SCALE DATA READ, 8bit, 0x00
	Public Const IPxyEXCNTSCALEWrite As Short = &HE6s ' EXTERNAL COUNTER PRE-SCALE DATA WRITE
	Public Const IPxyEXPRead As Short = &H67s ' EXTERNAL COUNTER P-DATA READ, 32bit, 0x7FFFFFFF
	Public Const IPxyEXPWrite As Short = &HE7s ' EXTERNAL COUNTER P-DATA WRITE
	Public Const IPxyEXSPDRead As Short = &H68s ' EXTERNAL SPEED DATA READ, 32bit, 0x00000000
	Public Const IPxyNoOperation_E8 As Short = &HE8s ' No operation
	Public Const IPxyEXSPDCMPRead As Short = &H69s ' EXTERNAL SPEED COMPARATE DATA READ, 32bit, 0x00000000
	Public Const IPxyEXSPDCMPWrite As Short = &HE9s ' EXTERNAL SPEED COMPARATE DATA WRITE
	Public Const IPxyEXFILTERDRead As Short = &H6As ' 외부 센서 필터 대역폭 설정 DATA READ, 32bit, 0x00050005
	Public Const IPxyEXFILTERDWrite As Short = &HEAs ' 외부 센서 필터 대역폭 설정 DATA WRITE
	Public Const IPxyOFFREGIONRead As Short = &H6Bs ' OFF-RANGE DATA READ, 8bit, 0x00
	Public Const IPxyOFFREGIONWrite As Short = &HEBs ' OFF-RANGE DATA WRITE
	Public Const IPxyDEVIATIONRead As Short = &H6Cs ' DEVIATION DATA READ, 16bit, 0x0000
	Public Const IPxyNoOperation_EC As Short = &HECs ' No operation
	Public Const IPxyPGMCHRead As Short = &H6Ds ' PGM REGISTER CHANGE DATA READ
	Public Const IPxyPGMCHWrite As Short = &HEDs ' PGM REGISTER CHANGE DATA WRITE
	Public Const IPxyCOMPCONRead As Short = &H6Es ' COMPARE REGISTER INPUT CHANGE DATA READ
	Public Const IPxyCOMPCONWrite As Short = &HEEs ' COMPARE REGISTER INPUT CHANGE DATA WRITE
	Public Const IPxyNoOperation_6F As Short = &H6Fs ' No operation
	Public Const IPxyNoOperation_EF As Short = &HEFs ' No operation
	
	'    /* BUS - 2 Group Register			*/
	Public Const IPxyFUNCONRead As Short = &H70s ' 칩 기능 설정 DATA READ,
	Public Const IPxyFUNCONWrite As Short = &HF0s ' 칩 기능 설정 DATA WRITE
	Public Const IPxyMODE1Read As Short = &H71s ' MODE1 DATA READ,
	Public Const IPxyMODE1Write As Short = &HF1s ' MODE1 DATA WRITE
	Public Const IPxyMODE2Read As Short = &H72s ' MODE2 DATA READ,
	Public Const IPxyMODE2Write As Short = &HF2s ' MODE2 DATA WRITE
	Public Const IPxyUIODATARead As Short = &H73s ' UNIVERSAL IN READ,
	Public Const IPxyUIODATAWrite As Short = &HF3s ' UNIVERSAL OUT WRITE
	Public Const IPxyENDSTATUSRead As Short = &H74s ' END STATUS DATA READ,
	Public Const IPxyCLIMCLR As Short = &HF4s ' Complete limit stop clear command
	Public Const IPxyMECHRead As Short = &H75s ' MECHANICAL SIGNAL DATA READ, 13bit
	Public Const IPxyNoOperation_F5 As Short = &HF5s ' No operation
	Public Const IPxyDRVSTATUSRead As Short = &H76s ' DRIVE STATE DATA READ, 9bit
	Public Const IPxyNoOperation_F6 As Short = &HF6s ' No operation
	Public Const IPxyEXCNTCLRRead As Short = &H77s ' EXTERNAL COUNTER 설정 DATA READ, 9bit, 0x00
	Public Const IPxyEXCNTCLRWrite As Short = &HF7s ' EXTERNAL COUNTER 설정 DATA WRITE
	Public Const IPxyNoOperation_78 As Short = &H78s ' No operation
	Public Const IPxySWRESET As Short = &HF8s ' REGISTER CLEAR(INITIALIZATION), Software reset
	Public Const IPxyINTFLAG1Read As Short = &H79s ' Interrupt Flag1 READ, 32bit, 0x00000000
	Public Const IPxyINTFLAG1CLR As Short = &HF9s ' Interrupt Flag1 Clear data write command.
	Public Const IPxyINTMASK1Read As Short = &H7As ' Interrupt Mask1 READ, 32bit, 0x00000001
	Public Const IPxyINTMASK1Write As Short = &HFAs ' Interrupt Mask1 WRITE
	Public Const IPxyUIOMODERead As Short = &H7Bs ' UIO MODE DATA READ, 12bit, 0x01F
	Public Const IPxyUIOMODEWrite As Short = &HFBs ' UIO MODE DATA WRITE
	Public Const IPxyINTFLAG2Read As Short = &H7Cs ' Interrupt Flag2 READ, 32bit, 0x00000000
	Public Const IPxyINTFLAG2CLRWrite As Short = &HFCs ' Interrupt Flag2 Clear data write command.
	Public Const IPxyINTMASK2Read As Short = &H7Ds ' Interrupt Mask2 READ, 32bit, 0x00000001
	Public Const IPxyINTMASK2Write As Short = &HFDs ' Interrupt Mask2 WRITE
	Public Const IPxyINTUSERCONRead As Short = &H7Es ' User interrupt selection control.
	Public Const IPxyINTUSERCONWrite As Short = &HFEs ' User interrupt selection control. 
	Public Const IPxyNoOperation_7F As Short = &H7Fs ' No operation
	Public Const IPxyINTGENCMD As Short = &HFFs ' Interrupt generation command.
	
	' 스크립트/갈무리 동작 설정 레지스터-1/2/3/Queue
	Public Const SCRIPT_REG1 As Short = 1 ' 스크립트 레지스터-1
	Public Const SCRIPT_REG2 As Short = 2 ' 스크립트 레지스터-2
	Public Const SCRIPT_REG3 As Short = 3 ' 스크립트 레지스터-3
	Public Const SCRIPT_REG_QUEUE As Short = 4 ' 스크립트 레지스터-Queue
	Public Const CAPTION_REG1 As Short = 11 ' 갈무리 레지스터-1
	Public Const CAPTION_REG2 As Short = 12 ' 갈무리 레지스터-2
	Public Const CAPTION_REG3 As Short = 13 ' 갈무리 레지스터-3
	Public Const CAPTION_REG_QUEUE As Short = 14 ' 갈무리 레지스터-Queue
	
	' CIPSetScriptCaption의 event_logic입력을 위한 값 define.
	' event_logic(입력) ==================================================================
	'		7 bit : 0(One time execution), 1(Always execution)
	'		6 bit : sc에 따라서 다음과 같은 차이점이 있음.
	'			    sc = SCRIPT_REG1, SCRIPT_REG2, SCRIPT_REG3 일 때. Script 동작시 사용할 데이타 입력 설정.
	'					0(data 사용), 1(ALU 출력 결과를 사용) 
	'				sc = SCRIPT_REG_QUEUE 일 때. Script 동작시 인터럽트 출력 유무. 해당 인터럽트 mask가 enable 되어 있어야 함.
	'					0(인터럽트 발생하지 않음), 1(해당 script 수행시 인터럽트 발생) 
	'			    sc = CAPTION_REG1, CAPTION_REG2, CAPTION_REG3 일 때. Don't care.
	'				sc = CAPTION_REG_QUEUE. Caption 동작시 인터럽트 출력 유무. 해당 인터럽트 mask가 enable되어 있어야 함.
	'					0(인터럽트 발생하지 않음), 1(해당 caption 수행시 인터럽트 발생) 
	'		5 ~ 4bit : "00" : Don't execute command 
	'				   "01" : Execute command in X
	'				   "10" : Execute command in Y
	'				   "11" : Execute command in X,Y(Caption:Don't execution)
	'		3 bit : Second event source axis selection(0 : X axis, 1 : Y axis)
	'		2 bit : First event source axis selection(0 : X axis, 1 : Y axis)  
	'		1~0 bit :   "00" : Use first event source only
	'					"01" : OR operation
	'					"11" : AND operation
	'					"11" : XOR operation
	Public Const IPSC_ONE_TIME_RUN As Short = &H0s ' bit 7 OFF
	Public Const IPSC_ALWAYS_RUN As Short = &H80s ' bit 7 ON
	
	Public Const IPSCQ_INTERRUPT_DISABLE As Short = &H0s ' bit 6 OFF
	Public Const IPSCQ_INTERRUPT_ENABLE As Short = &H40s ' bit 6 ON
	Public Const IPSC_DATA_FROM_DEFAULT As Short = &H0s ' bit 6 OFF
	Public Const IPSC_DATA_FROM_ALU As Short = &H40s ' bit 6 ON
	
	Public Const IPSC_EXE_NONE As Short = &H0s ' bit 5=OFF, 4=OFF
	Public Const IPSC_EXE_ON_X As Short = &H10s ' bit 5=OFF, 4=ON
	Public Const IPSC_EXE_ON_Y As Short = &H20s ' bit 5=ON,  4=OFF
	Public Const IPSC_EXE_ON_XY As Short = &H30s ' bit 5=ON,  4=ON
	Public Const IPSC_EVENT_OP_NONE As Short = &H0s ' bit 1=OFF, 0=OFF
	Public Const IPSC_EVENT_OP_OR As Short = &H1s ' bit 1=OFF, 0=ON
	Public Const IPSC_EVENT_OP_AND As Short = &H2s ' bit 1=ON,  0=OFF
	Public Const IPSC_EVENT_OP_XOR As Short = &H3s ' bit 1=ON,  0=ON
	
	'/* EVENT LIST							*/
	
	Public Const EVENT_IPNONE As Short = &H0s ' 검출사항 없음
	Public Const EVENT_IPDRIVE_END As Short = &H1s ' 드라이브 종료
	Public Const EVENT_IPPRESETDRIVE_START As Short = &H2s ' 지정펄스 수 드라이브 시작
	Public Const EVENT_IPPRESETDRIVE_END As Short = &H3s ' 지정펄스 수 드라이브 종료
	Public Const EVENT_IPCONTINOUSDRIVE_START As Short = &H4s ' 연속 드라이브 시작
	Public Const EVENT_IPCONTINOUSDRIVE_END As Short = &H5s ' 연속 드라이브 종료
	Public Const EVENT_IPSIGNAL_SEARCH_1_START As Short = &H6s ' 신호 검출-1 드라이브 시작
	Public Const EVENT_IPSIGNAL_SEARCH_1_END As Short = &H7s ' 신호 검출-1 드라이브 종료
	Public Const EVENT_IPSIGNAL_SEARCH_2_START As Short = &H8s ' 신호 검출-2 드라이브 시작
	Public Const EVENT_IPSIGNAL_SEARCH_2_END As Short = &H9s ' 신호 검출-2 드라이브 종료
	Public Const EVENT_IPORIGIN_DETECT_START As Short = &HAs ' 원점검출 드라이브 시작
	Public Const EVENT_IPORIGIN_DETECT_END As Short = &HBs ' 원점검출 드라이브 종료
	Public Const EVENT_IPSPEED_UP As Short = &HCs ' 가속
	Public Const EVENT_IPSPEED_CONST As Short = &HDs ' 등속
	Public Const EVENT_IPSPEED_DOWN As Short = &HEs ' 감속
	'** (2005-12-13)
	Public Const EVENT_IPICL As Short = &HFs ' 내부위치카운터 < 내부위치비교값
	Public Const EVENT_IPICE As Short = &H10s ' 내부위치카운터 = 내부위치비교값
	Public Const EVENT_IPICG As Short = &H11s ' 내부위치카운터 > 내부위치비교값
	Public Const EVENT_IPECL As Short = &H12s ' 외부위치카운터 < 외부위치비교값
	Public Const EVENT_IPECE As Short = &H13s ' 외부위치카운터 = 외부위치비교값
	Public Const EVENT_IPECG As Short = &H14s ' 외부위치카운터 > 외부위치비교값
	Public Const EVENT_IPEPCE As Short = &H15s ' 외부펄스카운터 = 외부펄스카운터비교값
	Public Const EVENT_IPEPCL As Short = &H16s ' 외부펄스카운터 < 외부펄스카운터비교값
	Public Const EVENT_IPEPCG As Short = &H17s ' 외부펄스카운터 > 외부펄스카운터비교값
	Public Const EVENT_IPSPL As Short = &H18s ' 현재속도데이터 < 현재속도비교데이터
	Public Const EVENT_IPSPE As Short = &H19s ' 현재속도데이터 = 현재속도비교데이터
	Public Const EVENT_IPSPG As Short = &H1As ' 현재속도데이터 > 현재속도비교데이터
	Public Const EVENT_IPSP12L As Short = &H1Bs ' 현재속도데이터 < Rate Change Point 1-2
	Public Const EVENT_IPSP12E As Short = &H1Cs ' 현재속도데이터 = Rate Change Point 1-2
	Public Const EVENT_IPSP12G As Short = &H1Ds ' 현재속도데이터 > Rate Change Point 1-2
	Public Const EVENT_IPSP23L As Short = &H1Es ' 현재속도데이터 < Rate Change Point 2-3
	Public Const EVENT_IPSP23E As Short = &H1Fs ' 현재속도데이터 = Rate Change Point 2-3
	Public Const EVENT_IPSP23G As Short = &H20s ' 현재속도데이터 > Rate Change Point 2-3
	Public Const EVENT_IPOBJECT_SPEED As Short = &H21s ' 현재속도데이터 = 목표속도데이터
	Public Const EVENT_IPSS_SPEED As Short = &H22s ' 현재속도데이터 = 시작속도데이터
	Public Const EVENT_IPESTOP As Short = &H23s ' 급속정지
	Public Const EVENT_IPSSTOP As Short = &H24s ' 감속정지
	Public Const EVENT_IPPELM As Short = &H25s ' +Emergency Limit 신호 입력
	Public Const EVENT_IPNELM As Short = &H26s ' -Emergency Limit 신호 입력
	Public Const EVENT_IPPSLM As Short = &H27s ' +Slow Down Limit 신호 입력
	Public Const EVENT_IPNSLM As Short = &H28s ' -Slow Down Limit 신호 입력
	Public Const EVENT_IPDEVIATION_ERROR As Short = &H29s ' 탈조 에러 발생
	Public Const EVENT_IPDATA_ERROR As Short = &H2As ' 데이터 설정 에러 발생
	Public Const EVENT_IPALARM_ERROR As Short = &H2Bs ' Alarm 신호 입력
	Public Const EVENT_IPESTOP_COMMAND As Short = &H2Cs ' 급속 정지 명령 실행
	Public Const EVENT_IPSSTOP_COMMAND As Short = &H2Ds ' 감속 정지 명령 실행
	Public Const EVENT_IPESTOP_SIGNAL As Short = &H2Es ' 급속 정지 신호 입력
	Public Const EVENT_IPSSTOP_SIGNAL As Short = &H2Fs ' 감속 정지 신호 입력
	Public Const EVENT_IPELM As Short = &H30s ' Emergency Limit 신호 입력
	Public Const EVENT_IPSLM As Short = &H31s ' Slow Down Limit 신호 입력
	Public Const EVENT_IPINPOSITION As Short = &H32s ' Inposition 신호 입력
	Public Const EVENT_IPINOUT0_HIGH As Short = &H33s ' IN/OUT0 High 신호 입력
	Public Const EVENT_IPINOUT0_LOW As Short = &H34s ' IN/OUT0 Low  신호 입력
	Public Const EVENT_IPINOUT1_HIGH As Short = &H35s ' IN/OUT1 High 신호 입력
	Public Const EVENT_IPINOUT1_LOW As Short = &H36s ' IN/OUT1 Low  신호 입력
	Public Const EVENT_IPINOUT2_HIGH As Short = &H37s ' IN/OUT2 High 신호 입력
	Public Const EVENT_IPINOUT2_LOW As Short = &H38s ' IN/OUT2 Low  신호 입력
	Public Const EVENT_IPINOUT3_HIGH As Short = &H39s ' IN/OUT3 High 신호 입력
	Public Const EVENT_IPINOUT3_LOW As Short = &H3As ' IN/OUT3 Low  신호 입력
	Public Const EVENT_IPINOUT4_HIGH As Short = &H3Bs ' IN/OUT4 High 신호 입력
	Public Const EVENT_IPINOUT4_LOW As Short = &H3Cs ' IN/OUT4 Low  신호 입력
	Public Const EVENT_IPINOUT5_HIGH As Short = &H3Ds ' IN/OUT5 High 신호 입력
	Public Const EVENT_IPINOUT5_LOW As Short = &H3Es ' IN/OUT5 Low  신호 입력
	Public Const EVENT_IPINOUT6_HIGH As Short = &H3Fs ' IN/OUT6 High 신호 입력
	Public Const EVENT_IPINOUT6_LOW As Short = &H40s ' IN/OUT6 Low  신호 입력
	Public Const EVENT_IPINOUT7_HIGH As Short = &H41s ' IN/OUT7 High 신호 입력
	Public Const EVENT_IPINOUT7_LOW As Short = &H42s ' IN/OUT7 Low  신호 
	Public Const EVENT_IPINOUT8_HIGH As Short = &H43s ' IN/OUT8 High 신호 입력
	Public Const EVENT_IPINOUT8_LOW As Short = &H44s ' IN/OUT8 Low  신호 입력
	Public Const EVENT_IPINOUT9_HIGH As Short = &H45s ' IN/OUT9 High 신호 입력
	Public Const EVENT_IPINOUT9_LOW As Short = &H46s ' IN/OUT9 Low  신호 입력
	Public Const EVENT_IPINOUT10_HIGH As Short = &H47s ' IN/OUT10 High 신호 입력
	Public Const EVENT_IPINOUT10_LOW As Short = &H48s ' IN/OUT10 Low  신호 입력
	Public Const EVENT_IPINOUT11_HIGH As Short = &H49s ' IN/OUT11 High 신호 입력
	Public Const EVENT_IPINOUT11_LOW As Short = &H4As ' IN/OUT11 Low  신호 	
	Public Const EVENT_IPSENSOR_DRIVE1_START As Short = &H4Bs ' Sensor Positioning drive I 시작
	Public Const EVENT_IPSENSOR_DRIVE1_END As Short = &H4Cs ' Sensor Positioning drive I 종료
	Public Const EVENT_IPSENSOR_DRIVE2_START As Short = &H4Ds ' Sensor Positioning drive II 시작
	Public Const EVENT_IPSENSOR_DRIVE2_END As Short = &H4Es ' Sensor Positioning drive II 종료
	Public Const EVENT_IPSENSOR_DRIVE3_START As Short = &H4Fs ' Sensor Positioning drive III 시작
	Public Const EVENT_IPSENSOR_DRIVE3_END As Short = &H50s ' Sensor Positioning drive III 종료
	Public Const EVENT_IP1STCOUNTER_NDATA_CLEAR As Short = &H51s ' 1'st counter N-data count clear
	Public Const EVENT_IP2NDCOUNTER_NDATA_CLEAR As Short = &H52s ' 2'nd counter N-data count clear
	Public Const EVENT_IPMARK_SIGNAL_HIGH As Short = &H53s ' Mark# signal high
	Public Const EVENT_IPMARK_SIGNAL_LOW As Short = &H54s ' Mark# signal low
	Public Const EVENT_IPSOFTWARE_PLIMIT As Short = &H55s ' +Software Limit
	Public Const EVENT_IPSOFTWARE_NLIMIT As Short = &H56s ' -Software Limit
	Public Const EVENT_IPSOFTWARE_LIMIT As Short = &H57s ' Software Limit
	Public Const EVENT_IPTRIGGER_ENABLE As Short = &H58s ' Trigger enable
	Public Const EVENT_IPINT_GEN_SOURCE As Short = &H59s ' Interrupt Generated by any source
	Public Const EVENT_IPINT_GEN_CMDF9 As Short = &H5As ' Interrupt Generated by Command "FF"
	Public Const EVENT_IPPRESETDRIVE_TRI_START As Short = &H5Bs ' Preset 삼각구동 시작
	Public Const EVENT_IPBUSY_HIGH As Short = &H5Cs ' 드라이브 busy High
	Public Const EVENT_IPBUSY_LOW As Short = &H5Ds ' 드라이브 busy Low
	
	Public Const EVENT_IPLINP_START As Short = &H5Es ' 단위 직선 보간 시작
	Public Const EVENT_IPLINP_END As Short = &H5Fs ' 단위 직선 보간 종료
	
	Public Const EVENT_IPCINP_START As Short = &H60s ' 단위 원호 보간 시작
	Public Const EVENT_IPCINP_END As Short = &H61s ' 단위 원호 보간 종료
	Public Const EVENT_IPPINP_START As Short = &H62s ' 패턴 보간 시작
	Public Const EVENT_IPPINP_END As Short = &H63s ' 패턴 보간 종료
	Public Const EVENT_IPPDATA_Q_EMPTY As Short = &H64s ' 패턴 보간 데이타 큐 비었음
	Public Const EVENT_IPS_C_INTERNAL_COMMAND_Q_EMPTY As Short = &H65s ' 스크립트/캡션 내부 명령어 큐 비었음
	Public Const EVENT_IPS_C_INTERNAL_COMMAND_Q_FULL As Short = &H66s ' 스크립트/캡션 내부 명령어 큐 가득참
	Public Const EVENT_IPxSYNC_ACTIVATED As Short = &H67s ' xSYNC 신호 입력 High
	Public Const EVENT_IPySYNC_ACTIVATED As Short = &H68s ' ySYNC 신호 입력 High
	Public Const EVENT_IPINTERRUPT_GENERATED As Short = &H69s ' X 축 또는 Y 축에서 인터럽트 발생
	Public Const EVENT_IPINP_START As Short = &H6As ' 보간 시작(원호, 직선, 패턴)
	Public Const EVENT_IPINP_END As Short = &H6Bs ' 보간 종료(원호, 직선, 패턴)
	Public Const EVENT_IPALGEBRIC_RESULT_BIT0 As Short = &H6Cs ' 연산 기능 블럭 연산 출력 결과 0 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT1 As Short = &H6Ds ' 연산 기능 블럭 연산 출력 결과 1 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT2 As Short = &H6Es ' 연산 기능 블럭 연산 출력 결과 2 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT3 As Short = &H6Fs ' 연산 기능 블럭 연산 출력 결과 3 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT4 As Short = &H70s ' 연산 기능 블럭 연산 출력 결과 4 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT5 As Short = &H71s ' 연산 기능 블럭 연산 출력 결과 5 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT6 As Short = &H72s ' 연산 기능 블럭 연산 출력 결과 6 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT7 As Short = &H73s ' 연산 기능 블럭 연산 출력 결과 7 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT8 As Short = &H74s ' 연산 기능 블럭 연산 출력 결과 8 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT9 As Short = &H75s ' 연산 기능 블럭 연산 출력 결과 9 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT10 As Short = &H76s ' 연산 기능 블럭 연산 출력 결과 10 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT11 As Short = &H77s ' 연산 기능 블럭 연산 출력 결과 11 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT12 As Short = &H78s ' 연산 기능 블럭 연산 출력 결과 12 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT13 As Short = &H79s ' 연산 기능 블럭 연산 출력 결과 13 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT14 As Short = &H7As ' 연산 기능 블럭 연산 출력 결과 14 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT15 As Short = &H7Bs ' 연산 기능 블럭 연산 출력 결과 15 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT16 As Short = &H7Cs ' 연산 기능 블럭 연산 출력 결과 16 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT17 As Short = &H7Ds ' 연산 기능 블럭 연산 출력 결과 17 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT18 As Short = &H7Es ' 연산 기능 블럭 연산 출력 결과 18 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT19 As Short = &H7Fs ' 연산 기능 블럭 연산 출력 결과 19 bit High
	
	Public Const EVENT_IPALGEBRIC_RESULT_BIT20 As Short = &H80s ' 연산 기능 블럭 연산 출력 결과 20 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT21 As Short = &H81s ' 연산 기능 블럭 연산 출력 결과 21 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT22 As Short = &H82s ' 연산 기능 블럭 연산 출력 결과 22 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT23 As Short = &H83s ' 연산 기능 블럭 연산 출력 결과 23 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT24 As Short = &H84s ' 연산 기능 블럭 연산 출력 결과 24 it High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT25 As Short = &H85s ' 연산 기능 블럭 연산 출력 결과 25 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT26 As Short = &H86s ' 연산 기능 블럭 연산 출력 결과 26 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT27 As Short = &H87s ' 연산 기능 블럭 연산 출력 결과 27 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT28 As Short = &H88s ' 연산 기능 블럭 연산 출력 결과 28 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT29 As Short = &H89s ' 연산 기능 블럭 연산 출력 결과 29 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT30 As Short = &H8As ' 연산 기능 블럭 연산 출력 결과 30 bit High
	Public Const EVENT_IPALGEBRIC_RESULT_BIT31 As Short = &H8Bs ' 연산 기능 블럭 연산 출력 결과 31 bit High
	Public Const EVENT_IPCOMPARE_RESULT_BIT0 As Short = &H8Cs ' 연산 기능 블럭 비교 출력 결과 0 bit High
	Public Const EVENT_IPCOMPARE_RESULT_BIT1 As Short = &H8Ds ' 연산 기능 블럭 비교 출력 결과 1 bit High
	Public Const EVENT_IPCOMPARE_RESULT_BIT2 As Short = &H8Es ' 연산 기능 블럭 비교 출력 결과 2 bit High
	Public Const EVENT_IPCOMPARE_RESULT_BIT3 As Short = &H8Fs ' 연산 기능 블럭 비교 출력 결과 3 bit High
	Public Const EVENT_IPCOMPARE_RESULT_BIT4 As Short = &H90s ' 연산 기능 블럭 비교 출력 결과 4 bit High
	Public Const EVENT_IPON_INTERPOLATION As Short = &H91s ' 보간 드라이버 중
	Public Const EVENT_IPON_LINEAR_INTERPOLATION As Short = &H92s ' 직선 보간 드라이버 중
	Public Const EVENT_IPON_CIRCULAR_INTERPOLATION As Short = &H93s ' 원호 보간 드라이버 중
	Public Const EVENT_IPON_PATTERN_INTERPOLATION As Short = &H94s ' 패턴 보간 드라이버 중
	Public Const EVENT_IPNONE_95 As Short = &H95s ' 검출 사항 없음
	Public Const EVENT_IPL_C_INP_Q_EMPTY As Short = &H96s ' 직선/원호보간 큐가 비었음
	Public Const EVENT_IPL_C_INP_Q_LESS_4 As Short = &H97s ' 직선/원호보간 큐가 4 미만임
	Public Const EVENT_IPP_INP_Q_EMPTY As Short = &H98s ' 패턴 보간 큐가 비었음
	Public Const EVENT_IPP_INP_Q_LESS_4 As Short = &H99s ' 패턴 보간 큐가 4 미만임
	Public Const EVENT_IPINTERPOLATION_PAUSED As Short = &H9As ' 보간 드라이버가 Pause 됨
	Public Const EVENT_IPP_INP_END_BY_END_PATTERN As Short = &H9Bs ' 패턴 보간 드라이버중 종료 패턴을 만남
	Public Const EVENT_IPARITHMETIC_DATA_SEL As Short = &HEEs ' 스크립트 1-3번 두번째 이벤트로 사용
	' 스크립트 입력 데이타로 연산블럭 출력값을 사용
	' 이벤트 연산 "00" 일때 유효
	Public Const EVENT_IPEXECUTION_ALWAYS As Short = &HFFs ' 무조건 수행(스크립트/캡션 4번(큐)에 한정)
	
	'/* IP Universal Input/Output			*/
	
	Public Const IPUS_OUT0 As Short = &H1s ' Bit 0
	Public Const IPUS_SVON As Short = &H1s ' Bit 0, Servo ON
	Public Const IPUS_OUT1 As Short = &H2s ' Bit 1
	Public Const IPUS_ALMC As Short = &H2s ' Bit 1, Alarm Clear
	Public Const IPUS_OUT2 As Short = &H4s ' Bit 2
	Public Const IPUS_OUT3 As Short = &H8s ' Bit 3
	Public Const IPUS_OUT4 As Short = &H10s ' Bit 4
	Public Const IPUS_CLR As Short = &H10s ' Bit 4
	Public Const IPUS_IN0 As Short = &H20s ' Bit 5
	Public Const IPUS_ORG As Short = &H20s ' Bit 5, Origin
	Public Const IPUS_IN1 As Short = &H40s ' Bit 6
	Public Const IPUS_PZ As Short = &H40s ' Bit 6, Encoder Z상
	Public Const IPUS_IN2 As Short = &H80s ' Bit 7
	Public Const IPUS_IN3 As Short = &H100s ' Bit 8
	Public Const IPUS_IN4 As Short = &H200s ' Bit 9, PSLM 연결
	Public Const IPUS_IN5 As Short = &H400s ' Bit 10. NSLM 연결
	Public Const IPUS_IN6 As Short = &H800s ' Bit 11. SSTOP 연결
	
	Public Const IPUS_OPCODE0 As Short = &H1000s ' Bit 12
	Public Const IPUS_OPCODE1 As Short = &H2000s ' Bit 13
	Public Const IPUS_OPCODE2 As Short = &H4000s ' Bit 14
	
	'/* IP Interrupt MASK setting			*/
	
	Public Const IPINTBANK1_DONTUSE As Short = &H0s ' INTERRUT DISABLED.
	Public Const IPINTBANK1_DRIVE_END As Short = &H1s ' Bit 0, Drive end(default value : 1).
	Public Const IPINTBANK1_ICG As Short = &H2s ' Bit 1, INCNT is greater than INCNTCMP.
	Public Const IPINTBANK1_ICE As Short = &H4s ' Bit 2, INCNT is equal with INCNTCMP.
	Public Const IPINTBANK1_ICL As Short = &H8s ' Bit 3, INCNT is less than INCNTCMP.
	Public Const IPINTBANK1_ECG As Short = &H10s ' Bit 4, EXCNT is greater than EXCNTCMP.
	Public Const IPINTBANK1_ECE As Short = &H20s ' Bit 5, EXCNT is equal with EXCNTCMP.
	Public Const IPINTBANK1_ECL As Short = &H40s ' Bit 6, EXCNT is less than EXCNTCMP.
	Public Const IPINTBANK1_SCRQEMPTY As Short = &H80s ' Bit 7, Script control queue is empty.
	Public Const IPINTBANK1_CAPRQEMPTY As Short = &H100s ' Bit 8, Caption result data queue is empty.
	Public Const IPINTBANK1_SCRREG1EXE As Short = &H200s ' Bit 9, Script control register-1 command is executed.
	Public Const IPINTBANK1_SCRREG2EXE As Short = &H400s ' Bit 10, Script control register-2 command is executed.
	Public Const IPINTBANK1_SCRREG3EXE As Short = &H800s ' Bit 11, Script control register-3 command is executed.
	Public Const IPINTBANK1_CAPREG1EXE As Short = &H1000s ' Bit 12, Caption control register-1 command is executed.
	Public Const IPINTBANK1_CAPREG2EXE As Short = &H2000s ' Bit 13, Caption control register-2 command is executed.
	Public Const IPINTBANK1_CAPREG3EXE As Short = &H4000s ' Bit 14, Caption control register-3 command is executed.
	Public Const IPINTBANK1_INTGGENCMD As Short = &H8000s ' Bit 15, Interrupt generation command is executed(0xFF)
	
	Public Const IPINTBANK1_DOWN As Integer = &H10000 ' Bit 16, At starting point for deceleration drive.
	Public Const IPINTBANK1_CONT As Integer = &H20000 ' Bit 17, At starting point for constant speed drive.
	Public Const IPINTBANK1_UP As Integer = &H40000 ' Bit 18, At starting point for acceleration drive.
	Public Const IPINTBANK1_SIGNALDETECTED As Integer = &H80000 ' Bit 19, Signal assigned in MODE1 is detected.
	Public Const IPINTBANK1_SP23E As Integer = &H100000 ' Bit 20, Current speed is equal with rate change point RCP23.
	Public Const IPINTBANK1_SP12E As Integer = &H200000 ' Bit 21, Current speed is equal with rate change point RCP12.
	Public Const IPINTBANK1_SPE As Integer = &H400000 ' Bit 22, Current speed is equal with speed comparison data(SPDCMP).
	Public Const IPINTBANK1_INCEICM As Integer = &H800000 ' Bit 23, INTCNT(1'st counter) is equal with ICM(1'st count minus limit data)
	Public Const IPINTBANK1_SCRQEXE As Integer = &H1000000 ' Bit 24, Script queue command is executed When SCRCONQ's 30 bit is '1'.
	Public Const IPINTBANK1_CAPQEXE As Integer = &H2000000 ' Bit 25, Caption queue command is executed When CAPCONQ's 30 bit is '1'.
	Public Const IPINTBANK1_SLM As Integer = &H4000000 ' Bit 26, NSLM/PSLM input signal is activated.
	Public Const IPINTBANK1_ELM As Integer = &H8000000 ' Bit 27, NELM/PELM input signal is activated.
	Public Const IPINTBANK1_USERDEFINE1 As Integer = &H10000000 ' Bit 28, Selectable interrupt source 0(refer "0xFE" command).
	Public Const IPINTBANK1_USERDEFINE2 As Integer = &H20000000 ' Bit 29, Selectable interrupt source 1(refer "0xFE" command).
	Public Const IPINTBANK1_USERDEFINE3 As Integer = &H40000000 ' Bit 30, Selectable interrupt source 2(refer "0xFE" command).
	Public Const IPINTBANK1_USERDEFINE4 As Integer = &H80000000 ' Bit 31, Selectable interrupt source 3(refer "0xFE" command).
	
	
	Public Const IPINTBANK2_DONTUSE As Short = &H0s ' INTERRUT DISABLED.
	Public Const IPINTBANK2_L_C_INP_Q_EMPTY As Short = &H1s ' Bit 0, Linear/Circular interpolation parameter queue is empty.
	Public Const IPINTBANK2_P_INP_Q_EMPTY As Short = &H2s ' Bit 1, Bit pattern interpolation queue is empty.
	Public Const IPINTBANK2_ALARM_ERROR As Short = &H4s ' Bit 2, Alarm input signal is activated.
	Public Const IPINTBANK2_INPOSITION As Short = &H8s ' Bit 3, Inposition input signal is activated.
	Public Const IPINTBANK2_MARK_SIGNAL_HIGH As Short = &H10s ' Bit 4, Mark input signal is activated.
	Public Const IPINTBANK2_SSTOP_SIGNAL As Short = &H20s ' Bit 5, SSTOP input signal is activated.
	Public Const IPINTBANK2_ESTOP_SIGNAL As Short = &H40s ' Bit 6, ESTOP input signal is activated.
	Public Const IPINTBANK2_SYNC_ACTIVATED As Short = &H80s ' Bit 7, SYNC input signal is activated.
	Public Const IPINTBANK2_TRIGGER_ENABLE As Short = &H100s ' Bit 8, Trigger output is activated.
	Public Const IPINTBANK2_EXCNTCLR As Short = &H200s ' Bit 9, External(2'nd) counter is cleard by EXCNTCLR setting.
	Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT0 As Short = &H400s ' Bit 10, ALU1's compare result bit 0 is activated.
	Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT1 As Short = &H800s ' Bit 11, ALU1's compare result bit 1 is activated.
	Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT2 As Short = &H1000s ' Bit 12, ALU1's compare result bit 2 is activated.
	Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT3 As Short = &H2000s ' Bit 13, ALU1's compare result bit 3 is activated.
	Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT4 As Short = &H4000s ' Bit 14, ALU1's compare result bit 4 is activated.
	Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT0 As Short = &H8000s ' Bit 15, ALU2's compare result bit 0 is activated.
	Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT1 As Integer = &H10000 ' Bit 16, ALU2's compare result bit 1 is activated.
	Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT2 As Integer = &H20000 ' Bit 17, ALU2's compare result bit 2 is activated.
	Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT3 As Integer = &H40000 ' Bit 18, ALU2's compare result bit 3 is activated.
	Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT4 As Integer = &H80000 ' Bit 19, ALU2's compare result bit 4 is activated.
	Public Const IPINTBANK2_L_C_INP_Q_LESS_4 As Integer = &H100000 ' Bit 20, Linear/Circular interpolation parameter queue is less than 4.
	Public Const IPINTBANK2_P_INP_Q_LESS_4 As Integer = &H200000 ' Bit 21, Pattern interpolation parameter queue is less than 4.
	Public Const IPINTBANK2_XSYNC_ACTIVATED As Integer = &H400000 ' Bit 22, X axis sync input signal is activated.
	Public Const IPINTBANK2_YSYNC_ACTIVATED As Integer = &H800000 ' Bit 23, Y axis sync input siangl is activated.
	Public Const IPINTBANK2_P_INP_END_BY_END_PATTERN As Integer = &H1000000 ' Bit 24, Bit pattern interpolation is terminated by end pattern.
	'	IPINTBANK2_							= 0x02000000,	// Bit 25, Don't care.
	'	IPINTBANK2_							= 0x04000000,	// Bit 26, Don't care. 
	'	IPINTBANK2_							= 0x08000000,	// Bit 27, Don't care. 
	'	IPINTBANK2_							= 0x10000000,	// Bit 28, Don't care. 
	'	IPINTBANK2_							= 0x20000000,	// Bit 29, Don't care. 
	'	IPINTBANK2_							= 0x40000000,	// Bit 30, Don't care. 
	'	IPINTBANK2_							= 0x80000000	// Bit 31, Don't care. 
	
	' bit 5=ON(Y), When Axis is ODD, bit 4=ON(X), When axis is EVEN.
	Function IPSC_EXE_ON_AXIS(ByRef axis As Short) As Byte
		If axis Mod 2 Then
			IPSC_EXE_ON_AXIS = &H10s
		Else
			IPSC_EXE_ON_AXIS = &H20s
		End If
	End Function
	
	' bit 3(0 : X axis, 1 : Y axis)
	Function IPSC_SND_EVENT_AXIS(ByRef axis As Short) As Byte
		IPSC_SND_EVENT_AXIS = CShort((axis Mod 2) And &H1s) * 2 ^ 3
	End Function
	
	' bit 2(0 : X axis, 1 : Y axis)
	Function IPSC_FST_EVENT_AXIS(ByRef axis As Short) As Byte
		IPSC_FST_EVENT_AXIS = CShort((axis Mod 2) And &H1s) * 2 ^ 2
	End Function
End Module