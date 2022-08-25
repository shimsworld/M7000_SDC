Option Strict Off
Option Explicit On
Module AxtLIB
	''/*------------------------------------------------------------------------------------------------*
	'	AXTLIB Library - ���ն��̺귯�� �� ���̽����� ����
	'	������ǰ
	'		BIHR - ISA Half size, 2 module
	'		BIFR - ISA Full size, 4 module
	'		BPHR - PCI Half size, 2 module
    '		BPFR - PCI Full size, 4 module
	'		BV3R - VME 3U size, 2 module
	'		BV6R - VME 6U size, 4 module
	'		BC3R - CompactPCI 3U size, 2 module
	'		BC6R - CompactPCI 6U size, 4 module
	' *------------------------------------------------------------------------------------------------*/
	
	'/ <<���ն��̺귯�� �ʱ�ȭ �� ����>>
	' ���� ���̺귯���� �ʱ�ȭ �Ѵ�..
	Public Declare Function AxtInitialize Lib "AxtLib.dll" (ByVal hWnd As Integer, ByVal nIrqNo As Short) As Byte
	' ���� ���̺귯���� ��� �������� (�ʱ�ȭ�� �Ǿ�����)�� Ȯ���Ѵ�
	Public Declare Function AxtIsInitialized Lib "AxtLib.dll" () As Byte
	' ���� ���̺귯���� ����� �����Ѵ�.
	Public Declare Sub AxtClose Lib "AxtLib.dll" ()
	
	'/ <<���̽����� ���� �� �ݱ�>>
	' ������ ����(ISA, PCI, VME, CompactPCI)�� �ʱ�ȭ �Ǿ������� Ȯ���Ѵ�
	Public Declare Function AxtIsInitializedBus Lib "AxtLib.dll" (ByVal BusType As Short) As Short
	' ���ο� ���̽����带 ���ն��̺귯���� �߰��Ѵ�.
	Public Declare Function AxtOpenDevice Lib "AxtLib.dll" (ByVal BusType As Short, ByVal dwBaseAddr As Integer) As Short
	' ���ο� ���̽����带 �迭�� �̿��Ͽ� �Ѳ����� ���ն��̺귯���� �߰��Ѵ�.
	Public Declare Function AxtOpenDeviceAll Lib "AxtLib.dll" (ByVal BusType As Short, ByVal nLen As Short, ByRef dwBaseAddr As Integer) As Short
	' ���ο� ���̽����带 �ڵ����� ���ն��̺귯���� �߰��Ѵ�.
	Public Declare Function AxtOpenDeviceAuto Lib "AxtLib.dll" (ByVal BusType As Short) As Short
	' �߰��� ���̽����带 ���� �ݴ´�
	Public Declare Sub AxtCloseDeviceAll Lib "AxtLib.dll" ()
	
	'/ <<���̽����������ͷ�Ʈ ����� �㰡 �� ����>>
	' ���̽������� ���ͷ�Ʈ�� ����� �㰡�Ѵ�
	Public Declare Sub AxtEnableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	' ���̽������� ���ͷ�Ʈ�� ��� ���������� Ȯ���Ѵ�
	Public Declare Function AxtIsEnableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	' ���̽������� ���ͷ�Ʈ�� ����� �����Ѵ�
	Public Declare Sub AxtDisableInterrupt Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	
	' <<���̽������� ���ͷ�Ʈ ����ũ �� �÷��� ��������>>
	' ���̽������� ���ͷ�Ʈ �÷��� �������͸� Ŭ���� �Ѵ�
	Public Declare Sub AxtInterruptFlagClear Lib "AxtLib.dll" (ByVal nBoardNo As Short)
	' ���̽����忡 ������ �� ����� ���ͷ�Ʈ�� ����� �� �ֵ��� �ش� ���� ����� ����Ѵ�
	Public Declare Sub AxtWriteInterruptMaskModule Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal Mask As Byte)
	' ������ ���ͷ�Ʈ ����ũ �������͸� �д´�
	Public Declare Function AxtReadInterruptMaskModule Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	' ���̽������� ���ͷ�Ʈ �÷��� ���������� ������ �д´�
	Public Declare Function AxtReadInterruptFlagModule Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Byte
	
	'/ <<���� ����>>
	' ������ ������ (���µ�) ���̽����� ������ �����Ѵ�
	Public Declare Function AxtGetBoardCounts Lib "AxtLib.dll" () As Short
	' (���µ�) ��� ���̽����� ������ �����Ѵ�
	Public Declare Function AxtGetBoardCountsBus Lib "AxtLib.dll" (ByVal nBusType As Short) As Short
	' ������ ���̽����忡 ������ ����� ID �� ����� ������ �����Ѵ�
	Public Declare Function AxtGetModuleCounts Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByRef ModuleID As Byte) As Short
	' ������ ���̽����忡 ������ ����� ������ ��� ID�� ������ �����Ѵ�
	Public Declare Function AxtGetModelCounts Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal ModuleID As Byte) As Short
	' ��� ���̽����忡 ������ ����� ������ ���ID�� ���� ����� ������ �����Ѵ�
	Public Declare Function AxtGetModelCountsAll Lib "AxtLib.dll" (ByVal ModuleID As Byte) As Short
	' ������ ���̽������� ID�� �����Ѵ�
	Public Declare Function AxtGetBoardID Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Short
	' ������ ���̽������� Adress�� �����Ѵ�.
	Public Declare Function AxtGetBoardAddress Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Integer
	
	' Log Level�� �����Ѵ�.
	Public Declare Sub AxtSetLogLevel Lib "AxtLib.dll" (ByVal nLogLevel As Short)
	' Log Level�� Ȯ���Ѵ�.
	Public Declare Function AxtGetLogLevel Lib "AxtLib.dll" () As Short
	
	'/ Library Version Infomation
	Public Declare Function AxtGetLibVersion Lib "AxtLib.dll" () As String
	Public Declare Function AxtGetLibDate Lib "AxtLib.dll" () As String
	
	Public Declare Function Axtget_error_code Lib "AxtLib.dll" () As Short
	Public Declare Function Axtget_error_msg Lib "AxtLib.dll" (ByVal ErrorCode As Short) As String
End Module