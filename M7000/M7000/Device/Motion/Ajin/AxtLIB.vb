Option Strict Off
Option Explicit On
Module AxtLIB
	''/*------------------------------------------------------------------------------------------------*
	'	AXTLIB Library - 통합라이브러리 및 베이스보드 관리
	'	적용제품
	'		BIHR - ISA Half size, 2 module
	'		BIFR - ISA Full size, 4 module
	'		BPHR - PCI Half size, 2 module
    '		BPFR - PCI Full size, 4 module
	'		BV3R - VME 3U size, 2 module
	'		BV6R - VME 6U size, 4 module
	'		BC3R - CompactPCI 3U size, 2 module
	'		BC6R - CompactPCI 6U size, 4 module
	' *------------------------------------------------------------------------------------------------*/
	
	'/ <<통합라이브러리 초기화 및 종료>>
	' 통합 라이브러리를 초기화 한다..
	Public Declare Function AxtInitialize Lib "AxtLib.dll" (ByVal hWnd As Integer, ByVal nIrqNo As Short) As Byte
	' 통합 라이브러리가 사용 가능하지 (초기화가 되었는지)를 확인한다
	Public Declare Function AxtIsInitialized Lib "AxtLib.dll" () As Byte
	' 통합 라이브러리의 사용을 종료한다.
	Public Declare Sub AxtClose Lib "AxtLib.dll" ()
	
	'/ <<베이스보드 오픈 및 닫기>>
	' 지정한 버스(ISA, PCI, VME, CompactPCI)가 초기화 되었는지를 확인한다
	Public Declare Function AxtIsInitializedBus Lib "AxtLib.dll" (ByVal BusType As Short) As Short
	' 새로운 베이스보드를 통합라이브러리에 추가한다.
	Public Declare Function AxtOpenDevice Lib "AxtLib.dll" (ByVal BusType As Short, ByVal dwBaseAddr As Integer) As Short
	' 새로운 베이스보드를 배열을 이용하여 한꺼번에 통합라이브러리에 추가한다.
	Public Declare Function AxtOpenDeviceAll Lib "AxtLib.dll" (ByVal BusType As Short, ByVal nLen As Short, ByRef dwBaseAddr As Integer) As Short
	' 새로운 베이스보드를 자동으로 통합라이브러리에 추가한다.
	Public Declare Function AxtOpenDeviceAuto Lib "AxtLib.dll" (ByVal BusType As Short) As Short
	' 추가된 베이스보드를 전부 닫는다
	Public Declare Sub AxtCloseDeviceAll Lib "AxtLib.dll" ()
	
	'/ <<베이스보드의인터럽트 사용의 허가 및 금지>>
	' 베이스보드의 인터럽트의 사용을 허가한다
	Public Declare Sub AxtEnableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	' 베이스보드의 인터럽트가 사용 가능한지를 확인한다
	Public Declare Function AxtIsEnableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	' 베이스보드의 인터럽트의 사용을 금지한다
	Public Declare Sub AxtDisableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	
	' <<베이스보드의 인터럽트 마스크 및 플래그 레지스터>>
	' 베이스보드의 인터럽트 플래그 레지스터를 클리어 한다
	Public Declare Sub AxtInterruptFlagClear Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	' 베이스보드에 장착된 각 모듈의 인터럽트를 사용할 수 있도록 해당 핀의 사용을 허용한다
	Public Declare Sub AxtWriteInterruptMaskModule Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal Mask As Byte)
	' 설정된 인터럽트 마스크 레지스터를 읽는다
	Public Declare Function AxtReadInterruptMaskModule Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	' 베이스보드의 인터럽트 플래그 레지스터의 내용을 읽는다
	Public Declare Function AxtReadInterruptFlagModule Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	
	'/ <<보드 정보>>
	' 지정한 버스의 (오픈된) 베이스보드 갯수를 리턴한다
	Public Declare Function AxtGetBoardCounts Lib "AxtLib.dll" () As Short
	' (오픈된) 모든 베이스보드 갯수를 리턴한다
	Public Declare Function AxtGetBoardCountsBus Lib "AxtLib.dll" (ByVal nBusType As Short) As Short
	' 지정한 베이스보드에 장착된 모듈의 ID 및 모듈의 갯수를 리턴한다
	Public Declare Function AxtGetModuleCounts Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByRef ModuleID As Byte) As Short
	' 지정한 베이스보드에 장착된 모듈중 지정한 모듈 ID의 갯수를 리턴한다
	Public Declare Function AxtGetModelCounts Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal ModuleID As Byte) As Short
	' 모든 베이스보드에 장착된 모듈중 지정한 모듈ID를 가진 모듈의 갯수를 리턴한다
	Public Declare Function AxtGetModelCountsAll Lib "AxtLib.dll" (ByVal ModuleID As Byte) As Short
	' 지정한 베이스보드의 ID를 리턴한다
	Public Declare Function AxtGetBoardID Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Short
	' 지정한 베이스보드의 Adress를 리턴한다.
	Public Declare Function AxtGetBoardAddress Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Integer
	
	' Log Level을 설정한다.
	Public Declare Sub AxtSetLogLevel Lib "AxtLib.dll" (ByVal nLogLevel As Short)
	' Log Level을 확인한다.
	Public Declare Function AxtGetLogLevel Lib "AxtLib.dll" () As Short
	
	'/ Library Version Infomation
	Public Declare Function AxtGetLibVersion Lib "AxtLib.dll" () As String
	Public Declare Function AxtGetLibDate Lib "AxtLib.dll" () As String
	
	Public Declare Function Axtget_error_code Lib "AxtLib.dll" () As Short
	Public Declare Function Axtget_error_msg Lib "AxtLib.dll" (ByVal ErrorCode As Short) As String
End Module