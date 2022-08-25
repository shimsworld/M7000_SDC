Option Strict Off
Option Explicit On
Module AxtLIBDef
	'	Console application 프로그램을 위해서 아래 부분을 정의함
	
	'typedef int							BOOL;			// 0(FALSE), 1(TRUE)
	
	' Bus type
	Public Const BUSTYPE_UNKNOWN As Short = -1 ' Unknown
	Public Const BUSTYPE_ISA As Short = 0 ' ISA(Industrial Standard Architecture)
	Public Const BUSTYPE_PCI As Short = 1 ' PCI
	Public Const BUSTYPE_VME As Short = 2 ' VME
	Public Const BUSTYPE_CPCI As Short = 3 ' Compact PCI
	Public Const BUSTYPE_MIN As Short = BUSTYPE_ISA ' 0
	Public Const BUSTYPE_MAX As Short = BUSTYPE_CPCI ' 3
	Public Const BUSTYPE_NUM As Short = 4 ' 4
	
	' 베이스 보드 정의
	Public Const AXT_UNKNOWN As Short = &H0s ' Unknown Baseboard
	Public Const AXT_BIHR As Short = &H1s ' ISA bus, Half size
	Public Const AXT_BIFR As Short = &H2s ' ISA bus, Full size
	Public Const AXT_BPHR As Short = &H3s ' PCI bus, Half size
	Public Const AXT_BPFR As Short = &H4s ' PCI bus, Full size
	Public Const AXT_BV3R As Short = &H5s ' VME bus, 3U size
	Public Const AXT_BV6R As Short = &H6s ' VME bus, 6U size
	Public Const AXT_BC3R As Short = &H7s ' cPCI bus, 3U size
	Public Const AXT_BC6R As Short = &H8s ' cPCI bus, 6U size
	Public Const AXT_FMNSH4D As Short = &H52s ' ISA bus, Full size, DB-32T, SIO-2V03 * 2
	Public Const AXT_BPHD As Short = &H83s ' PCI bus, Half size, DB-32T
	
	' 모듈 정의
	Public Const AXT_SMC_2V01 As Short = &H1s ' CAMC-5M, 2 Axis
	Public Const AXT_SMC_2V02 As Short = &H2s ' CAMC-FS, 2 Axis
	Public Const AXT_SMC_1V01 As Short = &H3s ' CAMC-5M, 1 Axis
	Public Const AXT_SMC_1V02 As Short = &H4s ' CAMC-FS, 1 Axis
	Public Const AXT_SMC_2V03 As Short = &H5s ' CAMC-IP, 2 Axis
	Public Const AXT_SMC_4V51 As Short = &H33s ' MCX314,  4 Axis
	Public Const AXT_SMC_2V53 As Short = &H35s ' PMD, 2 Axis
	Public Const AXT_SMC_2V54 As Short = &H36s ' MCX312,  2 Axis
	Public Const AXT_SIO_DI32 As Short = &H97s ' Digital IN  32점
	Public Const AXT_SIO_DO32P As Short = &H98s ' Digital OUT 32점
	Public Const AXT_SIO_DB32P As Short = &H99s ' Digital IN 16점 / OUT 16점
	Public Const AXT_SIO_DO32T As Short = &H9Es ' Digital OUT 16점, Power TR 출력
	Public Const AXT_SIO_DB32T As Short = &H9Fs ' Digital IN 16점 / OUT 16점, Power TR 출력
	Public Const AXT_SIO_AI4R As Short = &HA1s ' A1h(161) : AI 4Ch, 12 bit
	Public Const AXT_SIO_AO4R As Short = &HA2s ' A2h(162) : AO 4Ch, 12 bit
	Public Const AXT_SIO_AI16H As Short = &HA3s ' A3h(163) : AI 4Ch, 16 bit
	Public Const AXT_SIO_AO8H As Short = &HA4s ' A4h(164) : AO 4Ch, 16 bit
	Public Const AXT_COM_234R As Short = &HD3s ' COM-234R
	Public Const AXT_COM_484R As Short = &HD4s ' COM-484R
	
	' Module header info.
	Public Const REG_PREAMBLE As Short = &H0s ' Preamble		: B6h
	Public Const REG_ID As Short = &H2s ' Module ID	: 97h, 98h, 99h
	Public Const REG_VERSION As Short = &H4s ' Version		: 0.0
	Public Const REG_SOFTWARE_RESET As Short = &H6s ' bit 0 : 1(hi)로 Write시 Software reset
	
	' -------------------------------------------------------------------------------------
	Public Const AXT_MODULE As Short = 5 ' 베이스보드의 모듈 갯수 
	Public Const MAX_AXT_BOARD As Short = 21 ' 장착할 수 있는 보드의 갯수
	Public Const MAX_AXT_MODULE As Short = (MAX_AXT_BOARD * 5) ' 장착할 수 있는 모듈의 갯수 
	Public Const MAX_AXIS As Short = (MAX_AXT_MODULE * 2) ' 최대 모션 축의 갯수
	
	Public Const DIO_MODULE_ALL As Short = 0 '$$
	Public Const AIO_MODULE_ALL As Short = 0 '$$
	
	' Sync 및 Trigger 관련 Register
	Public Const AXT_SYNC_OFFSET As Short = &H1800s
	Public Const AXT_BASE_EEPROM As Short = &H1802s ' <+> 2002/03/07
	Public Const AXT_INTR_MASK As Short = &H1804s
	Public Const AXT_INTR_FLAG As Short = &H1806s
	
	' 모듈의 어드레스 - 오프셋
	Public Const SUBMODULE0 As Short = &H0s ' Module 0 offset
	Public Const SUBMODULE1 As Short = &H400s ' Module 1 offset
	Public Const SUBMODULE2 As Short = &H800s ' Module 2 offset
	Public Const SUBMODULE3 As Short = &HC00s ' Module 3 offset
	Public Const SUBMODULE4 As Short = &H1000s ' Module 4 offset
	
	'#define MODULE_NUM						4					// 베이스보드의 모듈 갯수
	
	' 로그 레벨
	Public Const LEVEL_NONE As Short = 0
	Public Const LEVEL_ERROR As Short = 1
	Public Const LEVEL_RUNSTOP As Short = 2
	Public Const LEVEL_FUNCTION As Short = 3
	
	
	Public Const AJIN_PREAMBLE As Short = &HB6s ' Preamble : B6h
	
	Public Const WM_USER As Short = &H400s
	
	' CAMC-5M Module
	Public Const WM_CAMC5M_INTERRUPT As Integer = (WM_USER + 2001)
	'Example : void C5MInterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT8 byFlag);
	
	' CAMC-FS Module
	Public Const WM_CAMCFS_INTERRUPT As Integer = (WM_USER + 2002)
	'Example : void CFSInterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT8 byFlag);
	
	' MCX-312 Module
	Public Const WM_MCX312_INTERRUPT As Integer = (WM_USER + 2003)
	'Example : void M312InterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT16 wFlag);
	
	' MCX-314 Module
	Public Const WM_MCX314_INTERRUPT As Integer = (WM_USER + 2004)
	'Example : void M314InterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT32 dwFlag);
	
	''/* Undefine
	'// PMD Module
	'#define WM_PMD_INTERRUPT				(WM_USER + 2005)
	'typedef void (*AXT_PMD_INTERRUPT_PROC)(INT16 nBoardNo, INT16 nModulePos, UINT32 dwFlag);
	'//Example : void PmdInterruptProc(INT16 nChannelNo);
	'*/
	
	' Comm Module
	Public Const WM_COMM_INTERRUPT As Integer = (WM_USER + 2006)
	'Example : void CommInterruptProc(INT16 nChannelNo);
	
	' DIO Module
	Public Const WM_DIO_INTERRUPT As Integer = (WM_USER + 2007)
	'Example : void DioInterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT32 dwFlag);
	
	' AIO Module
	Public Const WM_AIO_INTERRUPT As Integer = (WM_USER + 2008)
	'Example : void AioInterruptProc(INT16 nChannelNo, INT16 nStatus);
	
	' CAMC-IP Module
	Public Const WM_CAMCIP_INTERRUPT As Integer = (WM_USER + 2009)
	'Example : void CIPInterruptProc(INT16 nBoardNo, INT16 nModulePos, UINT8 byFlag);
	
	Public Const LOW As Short = 0
	Public Const HIGH As Short = 1
	
	Public Const DISABLE As Short = 0
	Public Const ENABLE As Short = 1
	
	' VALUE가 MIN과 MAX 사이의 값인가 ?
	Function InBound(ByRef MIN As Integer, ByRef MAX As Integer, ByRef VALUE As Integer) As Byte
		If MIN <= VALUE And VALUE <= MAX Then
			InBound = True
		Else
			InBound = False
		End If
	End Function
	
	' VALUE가 MIN보다 작은 값이면 MIN, MAX보다 큰 값이면 MAX, MIN과 MAX사이의 값이면 VALUE를 리턴
	Function Bound(ByRef MIN As Integer, ByRef MAX As Integer, ByRef VALUE As Integer) As Integer
		If MIN > VALUE Then
			Bound = MIN
		ElseIf MAX < VALUE Then 
			Bound = MAX
		Else
			Bound = VALUE
		End If
	End Function
	
	' 반올림
	Function round(ByRef x As Double) As Integer
        Dim VALUE As Double
        Dim MAX As Double
        Dim nRound As Integer
		If x >= 0 Then
            nRound = x + 0.5
			'UPGRADE_WARNING: VALUE 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			'UPGRADE_WARNING: MAX 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		ElseIf MAX < VALUE Then 
            nRound = x - 0.5
        End If
        Return nRound
	End Function
End Module