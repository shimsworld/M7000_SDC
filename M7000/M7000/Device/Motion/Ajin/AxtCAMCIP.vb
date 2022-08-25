Option Strict Off
Option Explicit On
Module AxtCAMCIP
	''/*------------------------------------------------------------------------------------------------*
	'    AXTCAMCIP Library - CAMC-IP Motion module
	'    ������ǰ
	'        SMC-2V03(ver 2.0 ����) - CAMC-IP 2��
	'    ���̺귯�� ���� : v2.0
	'    ������ ������ : 2005. 12. 28.
	'    ������� ���� : Tel. 031-436-2180(���������� ���������)
	' *------------------------------------------------------------------------------------------------*/
	
	'/ ���� �ʱ�ȭ �Լ���        -======================================================================================
	' CAMC-IP�� ������ ���(SMC-2V03)�� �˻��Ͽ� �ʱ�ȭ�Ѵ�. 
	'  reset    : 1(TRUE) = �ʱ�ȭ�� ��������(ī���� ��)�� �ʱ�ȭ�Ѵ�
	'  reset(TRUE)�϶� �ʱ� ������.
	'  1) ���ͷ�Ʈ ������� ����.
	'  2) �������� ��� ������� ����.
	'  3) �˶����� ��� ������� ����.
	'  4) ������ ����Ʈ ��� ��� ��.
	'  5) �������� ����Ʈ ��� ��� ��.
	'  6) �޽� ��� ��� : OneLowHighLow(Pulse : Active LOW, Direction : CW{High};CCW{LOW}).
	'  7) �˻� ��ȣ : +������ ����Ʈ ��ȣ �ϰ� ����.
	'  8) �Է� ���ڴ� ���� : 2��, 4 ü��.
	'  9) �˶�, ��������, +-���� ���� ����Ʈ, +-������ ����Ʈ Active level : HIGH
	' 10) ����/�ܺ� ī���� : 0.
	'UPGRADE_NOTE: reset��(��) reset_Renamed(��)�� ���׷��̵�Ǿ����ϴ�. �ڼ��� ������ ������ �����Ͻʽÿ�: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Public Declare Function InitializeCAMCIP Lib "AxtLib.dll" (ByVal reset_Renamed As Byte) As Byte
	' CAMC-IP ����� ����� ���������� Ȯ���Ѵ�
	' ���ϰ� :  1(TRUE) = CAMC-IP ����� ��� �����ϴ�.
	Public Declare Function CIPIsInitialized Lib "AxtLib.dll" () As Byte
	' CAMC-IP�� ������ ����� ����� �����Ѵ�
	Public Declare Sub CIPStopService Lib "AxtLib.dll" ()
	
	'/ ���� ���� ���� �Լ���        -===================================================================================
	' ������ �ּҿ� ������ ���̽������� ��ȣ�� �����Ѵ�. ������ -1�� �����Ѵ�
	Public Declare Function CIPget_boardno Lib "AxtLib.dll" (ByVal address As Integer) As Short
	' ���̽������� ������ �����Ѵ�
	Public Declare Function CIPget_numof_boards Lib "AxtLib.dll" () As Short
	' ������ ���̽����忡 ������ ���� ������ �����Ѵ�
	Public Declare Function CIPget_numof_axes Lib "AxtLib.dll" (ByVal nBoardNo As Short) As Short
	' ���� ������ �����Ѵ�
	Public Declare Function CIPget_total_numof_axis Lib "AxtLib.dll" () As Short
	' ������ ���̽������ȣ�� ����ȣ�� �ش��ϴ� ���ȣ�� �����Ѵ�
	Public Declare Function CIPget_axisno Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal nModuleNo As Short) As Short
	' ������ ���� ������ �����Ѵ�.
	' nBoardNo : �ش� ���� ������ ���̽������� ��ȣ.
	' nModuleNo: �ش� ���� ������ ����� ���̽� ��峻 ��� ��ġ(0~3)
	' bModuleID: �ش� ���� ������ ����� ID : SMC-2V03(0x05)
	' nAxisPos : �ش� ���� ������ ����� ù��°���� �ι�° ������ ����.(0 : ù��°, 1 : �ι�°)
	Public Declare Function CIPget_axis_info Lib "AxtLib.dll" (ByVal nAxisNo As Short, ByRef nBoardNo As Short, ByRef nModuleNo As Short, ByRef bModuleID As Byte, ByRef nAxisPos As Short) As Byte
	
	' ��ü �ý��۳��� ������ ���� ��� ��ȣ�� �����Ѵ�.
	Public Declare Function CIPget_axisno_2_moduleno Lib "AxtLib.dll" (ByVal axisno As Short) As Short
	
	'/ ���� ���� �Լ���        -========================================================================================
	' ���� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
	' Loading parameters.
	'	1) 1Pulse�� �̵��Ÿ�(Move Unit / Pulse)
	'	2) �ִ� �̵� �ӵ�, ����/���� �ӵ�
	'	3) ���ڴ� �Է¹��, �޽� ��¹�� 
	'	4) +������ ����Ʈ����, -������ ����Ʈ����, ������ ����Ʈ �������
	'  5) +�������� ����Ʈ����,-�������� ����Ʈ����, �������� ����Ʈ �������
	'  6) �˶�����, �˶� �������
	'  7) ��������(��ġ�����Ϸ� ��ȣ)����, �������� �������
	'  8) ������� �������
	'  9) ����/�ܺ� ī���� : 0. 	
	Public Declare Function CIPload_parameter Lib "AxtLib.dll" (ByVal axis As Short, ByVal nfilename As String) As Byte
	' ���� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�.
	' Saving parameters.
	'	1) 1Pulse�� �̵��Ÿ�(Move Unit / Pulse)
	'	2) �ִ� �̵� �ӵ�, ����/���� �ӵ�
	'	3) ���ڴ� �Է¹��, �޽� ��¹�� 
	'	4) +������ ����Ʈ����, -������ ����Ʈ����, ������ ����Ʈ �������
	'  5) +�������� ����Ʈ����,-�������� ����Ʈ����, �������� ����Ʈ �������
	'  6) �˶�����, �˶� �������
	'  7) ��������(��ġ�����Ϸ� ��ȣ)����, �������� �������
	'  8) ������� �������
	Public Declare Function CIPsave_parameter Lib "AxtLib.dll" (ByVal axis As Short, ByVal nfilename As String) As Byte
	' ��� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
	Public Declare Function CIPload_parameter_all Lib "AxtLib.dll" (ByVal nfilename As String) As Byte
	' ��� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�
	Public Declare Function CIPsave_parameter_all Lib "AxtLib.dll" (ByVal nfilename As String) As Byte
	
	' ���ͷ�Ʈ �Լ���   -================================================================================================
	'(���ͷ�Ʈ�� ����ϱ� ���ؼ��� 
	'CIPWriteInterruptMask, CIPKeSetInterruptOutEnableMode, CIPSetWindowMessage������ ���� �Ǿ�� �Ѵ�. ���� �ҽ� ����)
	'Window message & procedure
	'    hWnd    : ������ �ڵ�, ������ �޼����� ������ ���. ������� ������ NULL�� �Է�.
	'    wMsg    : ������ �ڵ��� �޼���, ������� �ʰų� ����Ʈ���� ����Ϸ��� 0�� �Է�.
	'    proc    : ���ͷ�Ʈ �߻��� ȣ��� �Լ��� ������, ������� ������ NULL�� �Է�.
	Public Declare Sub CIPSetWindowMessage Lib "AxtLib.dll" (ByVal hWnd As Integer, ByVal wMsg As Short, ByVal proc As Integer)
	'-===============================================================================
	' ReadInterruptFlag���� ������ ���� flag������ �о� ���� �Լ�(���ͷ�Ʈ service routine���� ���ͷ��� �߻� ������ �Ǻ��Ѵ�.)
	' bank : 
	' 0x0 : ���ͷ�Ʈ�� �߻� �Ͽ����� �߻��ϴ� ���ͷ�Ʈ flag register bank1(CAMC-IP �� INTFLAG1 ����.)
	' 0x1 : ���ͷ�Ʈ�� �߻� �Ͽ����� �߻��ϴ� ���ͷ�Ʈ flag register bank2(CAMC-IP �� INTFLAG2 ����.) 
	Public Declare Function CIPread_interrupt_flag Lib "AxtLib.dll" (ByVal axis As Short, ByVal bank As Integer) As Integer
	' �ش� ���� ���ͷ��� �߻� ������ �����Ѵ�. bank������ CAMC-IP�� INTMASK1, INTMASK2 ������ ����.
	Public Declare Sub CIPKeSetInterruptOutEnableMode Lib "AxtLib.dll" (ByVal axis As Short, ByVal bank1 As Integer, ByVal bank2 As Integer)
	Public Declare Sub CIPKeResetInterruptOutEnableMode Lib "AxtLib.dll" (ByVal axis As Short)
	' �ش� SMC-2V03 ������ ���ͷ��� ��� ���θ� �����Ѵ�. �ش� ���� get_axis_info�� ����Ͽ� �Է� ���� ã�� �ִ´�.
	Public Declare Sub CIPWriteInterruptMask Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal nModulePos As Short, ByVal mask As Byte)
	Public Declare Function CIPReadInterruptMask Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal nModulePos As Short) As Byte
	' �ش� ����� ���ͷ�Ʈ Flag�� Ȯ���Ѵ�.
	' 0 bit : �ش� ����� 0��(x��)�� ���ͷ�Ʈ�� �߻� ����.
	' 1 bit : �ش� ����� 1��(y��)�� ���ͷ�Ʈ�� �߻� ����.
	Public Declare Function CIPReadInterruptFlag Lib "AxtLib.dll" (ByVal nBoardNo As Short, ByVal nModulePos As Short) As Byte
	
	' ���� ���� �ʱ�ȭ �Լ���        -==================================================================================
	' ����Ŭ�� ����( ��⿡ ������ Oscillator�� ����� ��쿡�� ����)
	Public Declare Sub CIPKeSetMainClk Lib "AxtLib.dll" (ByVal axis As Short, ByVal nMainClk As Integer)
	' Drive mode 1�� ����/Ȯ���Ѵ�.
	' pwm_ppls_mode : SMC-2V03������ �ش� ���� ����.
	' decelstartpoint : �����Ÿ� ���� ��� ����� ���� ��ġ ���� ��� ����(0 : �ڵ� ������, 1 : ���� ������)
	' pulseoutmethod : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
	' detecsignal : ��ȣ �˻�-1/2 ���� ��� ����� �˻� �� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
	Public Declare Sub CIPset_drive_mode1 Lib "AxtLib.dll" (ByVal axis As Short, ByVal pwm_ppls_mode As Byte, ByVal decelstartpoint As Byte, ByVal pulseoutmethod As Byte, ByVal detectsignal As Byte)
	Public Declare Function CIPget_drive_mode1 Lib "AxtLib.dll" (ByVal axis As Short) As Short
	
	' Drive mode 2�� ����/Ȯ���Ѵ�.
	' encmethod : �Է� ���ڴ� ��� ����(typedef : EXTERNAL_COUNTER_INPUT)    
	Public Declare Sub CIPset_drive_mode2 Lib "AxtLib.dll" (ByVal axis As Short, ByVal estopactivelevel As Byte, ByVal sstopactivelevel As Byte, ByVal trigactivelevel As Byte, ByVal intactivelevel As Byte, ByVal markactivelevel As Byte, ByVal encmethod As Byte, ByVal inpactivelevel As Byte, ByVal alarmactivelevel As Byte, ByVal nslmactivelevel As Byte, ByVal pslmactivelevel As Byte, ByVal nelmactivelevel As Byte, ByVal pelmactivelevel As Byte)
	Public Declare Function CIPget_drive_mode2 Lib "AxtLib.dll" (ByVal axis As Short) As Short
	' Unit/Pulse ����/Ȯ��
	' Unit/Pulse : 1 pulse�� ���� system�� �̵��Ÿ��� ���ϸ�, �̶� Unit�� ������ ����ڰ� ���Ƿ� ������ �� �ִ�.
	' Ex) Ball screw pitch : 10mm, ���� 1ȸ���� �޽��� : 10000 ==> Unit�� mm�� ������ ��� : Unit/Pulse = 10/10000.
	' ���� unitperpulse�� 0.001�� �Է��ϸ� ��� ��������� mm�� ������. 
	' Ex) Linear motor�� ���ش��� 1 pulse�� 2 uM. ==> Unit�� mm�� ������ ��� : Unit/Pulse = 0.002/1.
	Public Declare Sub CIPset_moveunit_perpulse Lib "AxtLib.dll" (ByVal axis As Short, ByVal unitperpulse As Double)
	Public Declare Function CIPget_moveunit_perpulse Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' pulse/Unit ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_movepulse_perunit Lib "AxtLib.dll" (ByVal axis As Short, ByVal pulseperunit As Double)
	Public Declare Function CIPget_movepulse_perunit Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� �ӵ� ����/Ȯ���Ѵ�.(Unit/Sec)
	Public Declare Sub CIPset_startstop_speed Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double)
	Public Declare Function CIPget_startstop_speed Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' �ְ� �ӵ� ����/Ȯ���Ѵ�.(Unit/Sec) - ���� system�� �ְ� �ӵ��� �����Ѵ�. �����ӵ��� �ִ�ӵ��� ���ѵȴ�.
	' Unit/Pulse ������ ���ۼӵ� ���� ���Ŀ� �����Ѵ�.
	' ������ �ְ� �ӵ� �̻����δ� ������ �Ҽ� �����Ƿ� �����Ѵ�.
	Public Declare Function CIPset_max_speed Lib "AxtLib.dll" (ByVal axis As Short, ByVal max_velocity As Double) As Byte
	Public Declare Function CIPget_max_speed Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' SW�� ����� ���� ����/Ȯ���Ѵ�. �̰����� S-Curve ������ percentage�� ���� �����ϴ�.
	Public Declare Sub CIPset_s_rate Lib "AxtLib.dll" (ByVal axis As Short, ByVal accel_percent As Double, ByVal decel_percent As Double)
	Public Declare Sub CIPget_s_rate Lib "AxtLib.dll" (ByVal axis As Short, ByRef accel_percent As Double, ByRef decel_percent As Double)
	' ���� ������ ��忡�� �ܷ� �޽��� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_slowdown_rear_pulse Lib "AxtLib.dll" (ByVal axis As Short, ByVal ulData As Integer)
	Public Declare Function CIPget_slowdown_rear_pulse Lib "AxtLib.dll" (ByVal axis As Short) As Integer
	' CAMC_IP�� interrupt mask bit 0�� �����Ͽ� ��� �Ϸῡ ���� ���ͷ�Ʈ�� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_motiondone_interrupt_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal ena_int As Byte) As Byte
	Public Declare Function CIPis_motiondone_interrupt_enabled Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� ���� ���� ������ ���� ����� ����/Ȯ���Ѵ�.
	' 0x0 : �ڵ� ������.
	' 0x1 : ���� ������.
	Public Declare Function CIPset_decel_point Lib "AxtLib.dll" (ByVal axis As Short, ByVal method As Byte) As Byte
	Public Declare Function CIPget_decel_point Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ���� ���� Ȯ�� �Լ���        -=====================================================================================
	' ���� ���� �޽� ��� ���¸� Ȯ���Ѵ�.
	Public Declare Function CIPin_motion Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� �޽� ��� ���� ���¸� Ȯ���Ѵ�.
	Public Declare Function CIPmotion_done Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� �������� ���� ��µ� �޽� ī���� ���� Ȯ���Ѵ�.(Pulse)
	Public Declare Function CIPget_drive_pulse_counts Lib "AxtLib.dll" (ByVal axis As Short) As Integer
	' ���� ���� DriveStatus �������͸� Ȯ���Ѵ�.
	Public Declare Function CIPget_drive_status Lib "AxtLib.dll" (ByVal axis As Short) As Integer
	' ���� ���� EndStatus �������͸� Ȯ���Ѵ�.
	' End Status Bit�� �ǹ�
	' 15bit : Interpolation drvie�� ���� ����
	' 14bit : Soft Limit�� ���� ����
	' 13bit : Limit(PELM, NELM, PSLM, NSLM) ��ȣ�� ���� ����
	' 12bit : Sensor positioning drive����
	' 11bit : Preset pulse drive�� ���� ����(������ ��ġ/�Ÿ���ŭ �����̴� �Լ���)
	' 10bit : ��ȣ ���⿡ ���� ����(Signal Search-1/2 drive����)
	' 9 bit : ���� ���⿡ ���� ����
	' 8 bit : Ż�� ������ ���� ����
	' 7 bit : ����Ÿ ���� ������ ���� ����
	' 6 bit : ALARM ��ȣ �Է¿� ���� ����
	' 5 bit : ������ ��ɿ� ���� ����
	' 4 bit : �������� ��ɿ� ���� ����
	' 3 bit : ������ ��ȣ �Է¿� ���� ���� (EMG Button)
	' 2 bit : �������� ��ȣ �Է¿� ���� ����
	' 1 bit : Limit(PELM, NELM, Soft) �������� ���� ����
	' 0 bit : Limit(PSLM, NSLM, Soft) ���������� ���� ����
	Public Declare Function CIPget_end_status Lib "AxtLib.dll" (ByVal axis As Short) As Short
	' ���� ���� Mechanical �������͸� Ȯ���Ѵ�.
	' Mechanical Signal Bit�� �ǹ�
	' 14bit : MODE8_16 ��ȣ �Է� Level
	' 13bit : SYNC ��ȣ �Է�  Level
	' 12bit : ESTOP ��ȣ �Է� Level
	' 11bit : SSTOP ��ȣ �Է� Level
	' 10bit : MARK ��ȣ �Է� Level
	' 9 bit : EXPP(MPG) ��ȣ �Է� Level
	' 8 bit : EXMP(MPG) ��ȣ �Է� Level
	' 7 bit : Encoder Up��ȣ �Է� Level(A�� ��ȣ)
	' 6 bit : Encoder Down��ȣ �Է� Level(B�� ��ȣ)
	' 5 bit : INPOSITION ��ȣ Active ����
	' 4 bit : ALARM ��ȣ Active ����
	' 3 bit : -Limit �������� ��ȣ Active ���� (Ver3.0���� ����������)
	' 2 bit : +Limit �������� ��ȣ Active ���� (Ver3.0���� ����������)
	' 1 bit : -Limit ������ ��ȣ Active ����
	' 0 bit : +Limit ������ ��ȣ Active ����
	Public Declare Function CIPget_mechanical_signal Lib "AxtLib.dll" (ByVal axis As Short) As Short
	' ���� ����  ���� �ӵ��� �о� �´�.(Unit/Sec)
	Public Declare Function CIPget_velocity Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� ���� Command position�� Actual position�� ���� Ȯ���Ѵ�.
	Public Declare Function CIPget_error Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� ���� ���� ����̺��� �̵� �Ÿ��� Ȯ�� �Ѵ�. (Unit)
	Public Declare Function CIPget_drivedistance Lib "AxtLib.dll" (ByVal axis As Short) As Double
	
	'Encoder �Է� ��� ���� �Լ���        -=============================================================================
	' ���� ���� Encoder �Է� ����� ����/Ȯ���Ѵ�.
	' method : typedef(EXTERNAL_COUNTER_INPUT)
	' UpDownMode = 0x0    // Up/Down
	' Sqr1Mode   = 0x1    // 1ü��
	' Sqr2Mode   = 0x2    // 2ü��
	' Sqr4Mode   = 0x3    // 4ü��
	Public Declare Function CIPset_enc_input_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal method As Byte) As Byte
	Public Declare Function CIPget_enc_input_method Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� �ܺ� ��ġ counter clear�� ����� ����/Ȯ���Ѵ�.
	' method : CAMC-IP chip �޴��� EXTCNTCLR �������� ����.
	Public Declare Function CIPset_enc2_input_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal method As Byte) As Byte
	Public Declare Function CIPget_enc2_input_method Lib "AxtLib.dll" (ByVal axis As Short) As Short
	' ���� ���� �ܺ� ��ġ counter�� count ����� ����/Ȯ���Ѵ�.
	' reverse :
	' TRUE  : �Է� ���ڴ��� �ݴ�Ǵ� �������� count�Ѵ�.
	' FALSE : �Է� ���ڴ��� ���� ���������� count�Ѵ�.
	Public Declare Function CIPset_enc_reverse Lib "AxtLib.dll" (ByVal axis As Short, ByVal reverse As Byte) As Byte
	Public Declare Function CIPget_enc_reverse Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	'�޽� ��� ��� �Լ���        -=====================================================================================
	' �޽� ��� ����� ����/Ȯ���Ѵ�.
	' method : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
	' OneHighLowHigh   = 0x0, 1�޽� ���, PULSE(Active High), ������(DIR=Low)  / ������(DIR=High)
	' OneHighHighLow   = 0x1, 1�޽� ���, PULSE(Active High), ������(DIR=High) / ������(DIR=Low)
	' OneLowLowHigh    = 0x2, 1�޽� ���, PULSE(Active Low),  ������(DIR=Low)  / ������(DIR=High)
	' OneLowHighLow    = 0x3, 1�޽� ���, PULSE(Active Low),  ������(DIR=High) / ������(DIR=Low)
	' TwoCcwCwHigh     = 0x4, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active High 
	' TwoCcwCwLow      = 0x5, 2�޽� ���, PULSE(CCW:������),  DIR(CW:������),  Active Low 
	' TwoCwCcwHigh     = 0x6, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active High
	' TwoCwCcwLow      = 0x7, 2�޽� ���, PULSE(CW:������),   DIR(CCW:������), Active Low
	Public Declare Function CIPset_pulse_out_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal method As Byte) As Byte
	Public Declare Function CIPget_pulse_out_method Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ��ġ Ȯ�� �� ��ġ �� ���� �Լ��� -===============================================================================
	' �ܺ� ��ġ ���� �����Ѵ�. ������ ���¿��� �ܺ� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
	Public Declare Sub CIPset_actual_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_actual_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' �ܺ� ��ġ �񱳱⿡ ���� ����/Ȯ���Ѵ�.(position = Unit)
	Public Declare Sub CIPset_actual_comparator_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_actual_comparator_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� ��ġ ���� �����Ѵ�. ������ ���¿��� ���� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
	Public Declare Sub CIPset_command_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_command_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� ��ġ �񱳱⿡ ���� ����/Ȯ���Ѵ� (position = Unit)
	Public Declare Sub CIPset_command_comparator_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_command_comparator_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	
	' ���� ����̹� ��� ��ȣ ���� �Լ���-===============================================================================
	' ���� Enable��� ��ȣ�� Active Level�� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_servo_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_servo_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� Enable(On) / Disable(Off)�� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_servo_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal state As Byte) As Byte
	Public Declare Function CIPget_servo_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ���� ����̹� �Է� ��ȣ ���� �Լ���-===============================================================================
	' ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_inposition_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_inposition_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_inposition_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_inposition_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_inposition_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPin_position Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �˶� �Է½�ȣ ����� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_alarm_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_alarm_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �˶� �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_alarm_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_alarm_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_alarm_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	'MARK ��ȣ(Sensor positioning drive�� ���)
	Public Declare Function CIPset_mark_signal_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_mark_signal_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_mark_signal_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPset_mark_signal_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_mark_signal_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ����Ʈ ��ȣ ���� �Լ���-===========================================================================================
	' ������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_end_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_end_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' -������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_nend_limit_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_nend_limit_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_nend_limit_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' +������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_pend_limit_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_pend_limit_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_pend_limit_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_slow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_slow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' -�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_nslow_limit_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_nslow_limit_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_nslow_limit_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' +�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_pslow_limit_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_pslow_limit_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_pslow_limit_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' +������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.(������ ����Ʈ�� ���Ͽ� +�� -�� ���Ͽ� ���� ���� �����ϴ�.)
	Public Declare Function CIPset_pend_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_pend_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' -������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_nend_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_nend_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' +�������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.(�������� ����Ʈ�� ���Ͽ� +�� -�� ���Ͽ� ���� ���� �����ϴ�.)
	Public Declare Function CIPset_pslow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_pslow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' -�������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_nslow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_nslow_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ����Ʈ���� ����Ʈ ���� �Լ���-=====================================================================================
	' ����Ʈ���� ����Ʈ ��������� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_soft_limit_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte)
	Public Declare Function CIPget_soft_limit_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ����Ʈ���� ����Ʈ ���� ������ġ������ ����/Ȯ���Ѵ�.
	' sel :
	' 0x0 : ������ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
	' 0x1 : �ܺ���ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
	Public Declare Sub CIPset_soft_limit_sel Lib "AxtLib.dll" (ByVal axis As Short, ByVal sel As Byte)
	Public Declare Function CIPget_soft_limit_sel Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ����Ʈ���� ����Ʈ �߻��� ���� ��带 ����/Ȯ���Ѵ�.
	' mode :
	' 0x0 : ����Ʈ���� ����Ʈ ��ġ���� ������ �Ѵ�.
	' 0x1 : ����Ʈ���� ����Ʈ ��ġ���� �������� �Ѵ�.
	Public Declare Sub CIPset_soft_limit_stopmode Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode As Byte)
	Public Declare Function CIPget_soft_limit_stopmode Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ����Ʈ���� ����Ʈ -��ġ�� ����/Ȯ���Ѵ�.(position = Unit)
	Public Declare Sub CIPset_soft_nlimit_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_soft_nlimit_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ����Ʈ���� ����Ʈ +��ġ�� ����/Ȯ�� �Ѵ�.(position = Unit)
	Public Declare Sub CIPset_soft_plimit_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double)
	Public Declare Function CIPget_soft_plimit_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	
	' ������� ��ȣ-=====================================================================================================
	' ESTOP, SSTOP ��ȣ ��������� ����/Ȯ���Ѵ�.(Emergency stop, Slow-Down stop)
	Public Declare Function CIPset_emg_signal_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal use As Byte) As Byte
	Public Declare Function CIPget_emg_signal_enable Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' SSTOP �Է½�ȣ�� Active level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_sstop_signal_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_sstop_signal_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_sstop_signal_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ESTOP �Է½�ȣ�� Active level�� ����/Ȯ��/����Ȯ���Ѵ�.
	Public Declare Function CIPset_estop_signal_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Byte) As Byte
	Public Declare Function CIPget_estop_signal_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPget_estop_signal_switch Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	'���� ���� �Ÿ� ����-===============================================================================================
	'start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�(Blocking).
	'*r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
	'*s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
	'*a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
	'*_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
	'�Է� ����: velocity(Unit/Sec), acceleration/deceleration(Unit/Sec^2), acceltime/deceltime(Sec), position(Unit)
	
	' ��Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPmove Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Short
	Public Declare Function CIPmove_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Short
	Public Declare Function CIPr_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Short
	Public Declare Function CIPr_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Short
	' Non Blocking�Լ� (�������� ��� ���õ�)
	Public Declare Function CIPstart_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	Public Declare Function CIPstart_r_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_r_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	
	' ���Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPa_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Short
	Public Declare Function CIPa_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Short
	Public Declare Function CIPra_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Short
	Public Declare Function CIPra_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Short
	' Non Blocking�Լ� (�������� ��� ���õ�)
	Public Declare Function CIPstart_a_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPstart_a_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	Public Declare Function CIPstart_ra_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPstart_ra_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	' ��Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPs_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Short
	Public Declare Function CIPs_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Short
	Public Declare Function CIPrs_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Short
	Public Declare Function CIPrs_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Short
	' Non Blocking�Լ� (�������� ��� ���õ�)
	Public Declare Function CIPstart_s_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_s_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	Public Declare Function CIPstart_rs_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_rs_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	' ���Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPas_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Short
	Public Declare Function CIPas_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Short
	Public Declare Function CIPras_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Short
	Public Declare Function CIPras_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Short
	' Non Blocking�Լ� (�������� ��� ���õ�), jerk���(���� : �ۼ�Ʈ) ���������� S�� �̵�����.	
	Public Declare Function CIPstart_as_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPstart_as_move2 Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal jerk As Double) As Byte
	Public Declare Function CIPstart_as_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	Public Declare Function CIPstart_ras_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPstart_ras_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	
	' MARK, ��Ī Sensor positioning ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
	Public Declare Function CIPstart_pr_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Byte
	Public Declare Function CIPstart_pr_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Byte
	' MARK, ���Ī Sensor positioning ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
	Public Declare Function CIPstart_pra_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Byte
	Public Declare Function CIPstart_pra_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Byte
	' Sensor positioning ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
	Public Declare Function CIPpr_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Short
	Public Declare Function CIPpr_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Short
	' MARK, ���Ī Sensor positioning ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
	Public Declare Function CIPpra_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Short
	Public Declare Function CIPpra_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Short
	' MARK, ��Ī Sensor positioning S���� ����, �����ǥ, ������/���ӽð�(Sec)
	Public Declare Function CIPstart_prs_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Byte
	Public Declare Function CIPstart_prs_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Byte
	' MARK, ���Ī Sensor positioning S���� ����, �����ǥ, ������/���ӽð�(Sec)
	Public Declare Function CIPstart_pras_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Byte
	Public Declare Function CIPstart_pras_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Byte
	' MARK, Sensor positioning S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
	Public Declare Function CIPprs_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Short
	Public Declare Function CIPprs_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Short
	' MARK, ���Ī Sensor positioning S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
	Public Declare Function CIPpras_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Short
	Public Declare Function CIPpras_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Short
	
	' ��Ī ���� �޽�(Pulse Drive), S���� ����, �����ǥ, ������,
	' Non Blocking (�������� ��� ���õ�), ���� ��ġ�� �������� over_distance���� over_velocity�� �ӵ��� ���� �Ѵ�.
	Public Declare Function CIPstart_rs_move_override Lib "AxtLib.dll" (ByVal axis As Short, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal over_distance As Double, ByVal over_velocity As Double, ByVal Target As Byte) As Byte
	
	'���� ���� ����-====================================================================================================
	' ���� �����ӵ� �� �ӵ��� ���� ������ �߻����� ������ ���������� �����Ѵ�.
	'*s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
	'*a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
	'*_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�. 
	
	' ���ӵ� ��ٸ��� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
	' ��Ī ������ �����Լ�
	Public Declare Function CIPv_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPv_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	' ���Ī ������ �����Լ�
	Public Declare Function CIPv_a_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPv_a_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	' ���ӵ� S���� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
	' ��Ī ������ �����Լ�
	Public Declare Function CIPv_s_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPv_s_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	' ���Ī ������ �����Լ�
	Public Declare Function CIPv_as_move Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
	Public Declare Function CIPv_as_move_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
	
	' ��ȣ ���� ����-====================================================================================================
	' ���� ��ȣ�� ����/���� ������ �˻��Ͽ� ������ �Ǵ� ���������� �� �� �ִ�.
	' detect_signal : �˻� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
	' PElmNegativeEdge    = 0x0,        // +Elm(End limit) �ϰ� edge
	' NElmNegativeEdge    = 0x1,        // -Elm(End limit) �ϰ� edge
	' PSlmNegativeEdge    = 0x2,        // +Slm(Slowdown limit) �ϰ� edge
	' NSlmNegativeEdge    = 0x3,        // -Slm(Slowdown limit) �ϰ� edge
	' In0DownEdge         = 0x4,        // IN0(ORG) �ϰ� edge
	' In1DownEdge         = 0x5,        // IN1(Z��) �ϰ� edge
	' In2DownEdge         = 0x6,        // IN2(����) �ϰ� edge
	' In3DownEdge         = 0x7,        // IN3(����) �ϰ� edge
	' PElmPositiveEdge    = 0x8,        // +Elm(End limit) ��� edge
	' NElmPositiveEdge    = 0x9,        // -Elm(End limit) ��� edge
	' PSlmPositiveEdge    = 0xa,        // +Slm(Slowdown limit) ��� edge
	' NSlmPositiveEdge    = 0xb,        // -Slm(Slowdown limit) ��� edge
	' In0UpEdge           = 0xc,        // IN0(ORG) ��� edge
	' In1UpEdge           = 0xd,        // IN1(Z��) ��� edge
	' In2UpEdge           = 0xe,        // IN2(����) ��� edge
	' In3UpEdge           = 0xf         // IN3(����) ��� edge
	' Signal Search1 : ���� ������ �Է� �ӵ����� �����Ͽ�, ��ȣ ������ ���� ����.
	' Signal Search2 : ���� ������ ���Ӿ��� �Է� �ӵ��� �ǰ�, ��ȣ ������ ������. 
	' ���� : Signal Search2�� �������� �����Ƿ� �ӵ��� ������� Ż���� �ⱸ���� ������ ���� �����Ƿ� �����Ѵ�.
	' *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
	' *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
	
	' ��ȣ����1(Signal search 1) ��ٸ��� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
	Public Declare Function CIPstart_signal_search1 Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double, ByVal detect_signal As Byte) As Byte
	Public Declare Function CIPstart_signal_search1_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double, ByVal detect_signal As Byte) As Byte
	' ��ȣ����1(Signal search 1) S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
	Public Declare Function CIPstart_s_signal_search1 Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double, ByVal detect_signal As Byte) As Byte
	Public Declare Function CIPstart_s_signal_search1_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double, ByVal detect_signal As Byte) As Byte
	' ��ȣ����2(Signal search 2) ��ٸ��� ����, ������ ����
	Public Declare Function CIPstart_signal_search2 Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal detect_signal As Byte) As Byte
	
	' MPG(Manual Pulse Generation) ���� ����-===========================================================================
	' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ��带 ����/Ȯ���Ѵ�.
	' mode
	' 0x1 : Slave �������, �ܺ� Differential ��ȣ�� ���� ���
	' 0x2 : ���� �޽� ����, �ܺ� �Է� ��ȣ�� ���� ���� �޽� ���� ����
	' 0x4 : ���� ���� ���, �ܺ� ���� �Է� ��ȣ�� Ư�� ���� ���� ����
	Public Declare Function CIPset_mpg_drive_mode Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode As Byte) As Byte
	Public Declare Function CIPget_mpg_drive_mode Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� �޽� ������ ����ϴ� �Ÿ� ������ ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_mpg_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal position As Double) As Byte
	Public Declare Function CIPget_mpg_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	
	' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������带 ����/Ȯ���Ѵ�.
	' mode
	' 0x0 : �ܺ� ��ȣ�� ���� ���� ����
	' 0x1 : ����ڿ� ���� ������ �������� ����
	Public Declare Function CIPset_mpg_dir_mode Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode As Byte) As Byte
	Public Declare Function CIPget_mpg_dir_mode Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������尡 ����ڿ� ����
	' ������ �������� �����Ǿ��� �� �ʿ��� ������� ���� ���� ���� ���� ����/Ȯ���Ѵ�.
	' mode
	' 0x0 : ����� ���� ���� ������ +�� ����
	' 0x1 : ����� ���� ���� ������ -�� ����
	Public Declare Function CIPset_mpg_user_dir Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode As Byte) As Byte
	Public Declare Function CIPget_mpg_user_dir Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���Ǵ� EXPP/EXMP �� �Է� ��带 �����Ѵ�.
	'  2 bit : '0' : level input(���� �Է� 4 = EXPP, ���� �Է� 5 = EXMP�� �Է� �޴´�.)
	'          '1' : Differential input(���� �Է����� EXPP, EXMP�� �Է� ����,)
	'  1~0bit: "00" : 1 phase
	'          "01" : 2 phase 1 times
	'          "10" : 2 phase 2 times
	'          "11" : 2 phase 4 times
	Public Declare Function CIPset_mpg_input_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal method As Byte) As Byte
	Public Declare Function CIPget_mpg_input_method Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' MPG(Manual Pulse Generation) ���� -===============================================================================
	' ������ �ӵ��� ��ٸ��� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
	Public Declare Function CIPstart_mpg Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_mpg_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	' ������ �ӵ��� S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
	Public Declare Function CIPstart_s_mpg Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double) As Byte
	Public Declare Function CIPstart_s_mpg_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceltime As Double) As Byte
	
	' �������̵�(������)-================================================================================================
	' ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� ��ġ(������ġ)�� ������ �ٲ۴�.
	Public Declare Function CIPposition_override Lib "AxtLib.dll" (ByVal axis As Short, ByVal overrideposition As Double) As Byte
	' ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� �Ÿ�(�����ġ)�� ������ �ٲ۴�.    
	Public Declare Function CIPposition_r_override Lib "AxtLib.dll" (ByVal axis As Short, ByVal overridedistance As Double) As Byte
	' ������ ���� �ʱ� ������ �ӵ��� �ٲ۴�.(set_max_speed > dbVel > set_startstop_speed)
	Public Declare Function CIPvelocity_override Lib "AxtLib.dll" (ByVal axis As Short, ByVal dbVel As Double) As Byte
	' ���� ���� ������ ����Ǳ� �� �Էµ� overrideposition���� �ּ� ��� �޽�(dec_pulse) �̻��� ��� override ������ �Ѵ�.
	Public Declare Function CIPposition_override2 Lib "AxtLib.dll" (ByVal axis As Short, ByVal overrideposition As Double, ByVal dec_pulse As Double) As Byte
	' ���� �࿡ ����/���� ���� ������ ������ ���������� �ӵ� override ������ �Ѵ�.
	Public Declare Function CIPvelocity_override2 Lib "AxtLib.dll" (ByVal axis As Short, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal jerk As Double) As Byte
	
	' ���� ���� Ȯ��-====================================================================================================
	' ���� ���� ������ ����� ������ ��ٸ� �� �Լ��� �����.
	Public Declare Function CIPwait_for_done Lib "AxtLib.dll" (ByVal axis As Short) As Short
	
	' ���� ���� ����-====================================================================================================
	' ���� ���� �������Ѵ�.
	Public Declare Function CIPset_e_stop Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� ������ �������� �����Ѵ�.
	Public Declare Function CIPset_stop Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ���� �Էµ� �������� �����Ѵ�.
	Public Declare Function CIPset_stop_decel Lib "AxtLib.dll" (ByVal axis As Short, ByVal deceleration As Double) As Byte
	' ���� ���� ���� �ð����� �����Ѵ�.
	Public Declare Function CIPset_stop_deceltime Lib "AxtLib.dll" (ByVal axis As Short, ByVal deceltime As Double) As Byte
	
	' ���� ���� �������� ����-==========================================================================================
	' Master/Slave link �Ǵ� ��ǥ�� link ���� �ϳ��� ����Ͽ��� �Ѵ�.
	' Master/Slave link ����. (�Ϲ� ���� ������ master �� ������ slave�൵ ���� �����ȴ�.)
	' Master/Slave link ����
	Public Declare Function CIPlink Lib "AxtLib.dll" (ByVal master As Short, ByVal slave As Short, ByVal ratio As Double) As Byte
	' Master/Slave link ����
	Public Declare Function CIPendlink Lib "AxtLib.dll" (ByVal slave As Short) As Byte
	
	' ��ǥ�� link ����-================================================================================================
	' ���� ��ǥ�迡 �� �Ҵ� - n_axes������ŭ�� ����� ����/Ȯ���Ѵ�.(coordinate�� 1..8���� ��� ����)
	' n_axes ������ŭ�� ����� ����/Ȯ���Ѵ�. - (n_axes�� 1..4���� ��� ����)
	Public Declare Function CIPmap_axes Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal n_axes As Short, ByRef map_array As Short) As Byte
	Public Declare Function CIPget_mapped_axes Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal n_axes As Short, ByRef map_array As Short) As Byte
	' ���� ��ǥ���� ���/���� ��� ����/Ȯ���Ѵ�.
	' mode:
	' 0: �����ǥ����, 1: ������ǥ ����
	Public Declare Sub CIPset_coordinate_mode Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal mode As Short)
	Public Declare Function CIPget_coordinate_mode Lib "AxtLib.dll" (ByVal coordinate As Short) As Short
	' ���� ��ǥ���� �ӵ� �������� ����/Ȯ���Ѵ�.
	' mode:
	' 0: ��ٸ��� ����, 1: SĿ�� ����
	Public Declare Sub CIPset_move_profile Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal mode As Short)
	Public Declare Function CIPget_move_profile Lib "AxtLib.dll" (ByVal coordinate As Short) As Short
	' ���� ��ǥ���� �ʱ� �ӵ��� ����/Ȯ���Ѵ�.
	'    void   PASCAL EXPORT CIPset_move_startstop_velocity(INT16 coordinate, double velocity);
	'    double PASCAL EXPORT CIPget_move_startstop_velocity(INT16 coordinate);
	' Ư�� ��ǥ���� �ӵ��� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_move_velocity Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal velocity As Double)
	Public Declare Function CIPget_move_velocity Lib "AxtLib.dll" (ByVal coordinate As Short) As Double
	' Ư�� ��ǥ���� �������� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_move_acceleration Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal acceleration As Double)
	Public Declare Function CIPget_move_acceleration Lib "AxtLib.dll" (ByVal coordinate As Short) As Double
	' Ư�� ��ǥ���� ���� �ð�(Sec)�� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_move_acceltime Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal acceltime As Double)
	Public Declare Function CIPget_move_acceltime Lib "AxtLib.dll" (ByVal coordinate As Short) As Double
	' ���� ��������  ��ǥ���� ���� �����ӵ��� ��ȯ�Ѵ�.
	Public Declare Function CIPco_get_velocity Lib "AxtLib.dll" (ByVal coordinate As Short) As Double
	
	' ����Ʈ���� ���� ����(���� ��ǥ�迡 ���Ͽ�)-========================================================================
	' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
	' 2, 3, 4���� �����̵��Ѵ�.
	Public Declare Function CIPmove_2 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double) As Byte
	Public Declare Function CIPmove_3 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double) As Byte
	Public Declare Function CIPmove_4 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal w As Double) As Byte
	' Non Blocking�Լ� (�������� ��� ���õ�)
	' 2, 3, 4���� �����̵��Ѵ�.
	Public Declare Function CIPstart_move_2 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double) As Byte
	Public Declare Function CIPstart_move_3 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double) As Byte
	Public Declare Function CIPstart_move_4 Lib "AxtLib.dll" (ByVal coordinate As Short, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal w As Double) As Byte
	' ���� ��ǥ���� ������� ��� �Ϸ� üũ    
	Public Declare Function CIPco_motion_done Lib "AxtLib.dll" (ByVal coordinate As Short) As Byte
	' ���� ��ǥ���� ������ �Ϸ�ɶ� ���� ��ٸ���.
	Public Declare Function CIPco_wait_for_done Lib "AxtLib.dll" (ByVal coordinate As Short) As Byte
	
	' ���� ����(���� ����) : Master/Slave�� link�Ǿ� ���� ��� ������ �߻� �� �� �ִ�.-==================================
	' ���� ����� ���� �Ÿ� �� �ӵ� ���ӵ� ������ ���� ���� �����Ѵ�. ���� ���ۿ� ���� ����ȭ�� ����Ѵ�. 
	' start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�.
	' *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
	' *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
	' *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
	
	' ���� �����޽�(Pulse Drive)����, ��ٸ��� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPmove_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPmove_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	Public Declare Function CIPr_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPr_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	' Non Blocking�Լ� (�������� ���� ���õ�)
	Public Declare Function CIPstart_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPstart_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	Public Declare Function CIPstart_r_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPstart_r_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	' ���� �����޽�(Pulse Drive)����, S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
	' Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
	Public Declare Function CIPs_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPs_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	Public Declare Function CIPrs_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPrs_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	' Non Blocking�Լ� (�������� ���� ���õ�)
	Public Declare Function CIPstart_s_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPstart_s_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	Public Declare Function CIPstart_rs_move_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
	Public Declare Function CIPstart_rs_move_all_ex Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
	'���� ��鿡 ���Ͽ� S���� ������ ���� �����ӽ��� SĿ���� ������ ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_s_rate_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef accel_percent As Double, ByRef decel_percent As Double)
	Public Declare Sub CIPget_s_rate_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef accel_percent As Double, ByRef decel_percent As Double)
	
	' ���� ���� Ȯ��-====================================================================================================
	' �Է� �ش� ����� ���� ���¸� Ȯ���ϰ� ������ ���� �� ���� ��ٸ���.
    Public Declare Function CIPwait_for_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short) As Byte
	
	' ���� ���� ����-====================================================================================================
	' ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
	Public Declare Function CIPreset_axis_sync Lib "AxtLib.dll" (ByVal nLen As Short, ByRef aAxis As Short) As Byte
	' ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
	Public Declare Function CIPset_axis_sync Lib "AxtLib.dll" (ByVal nLen As Short, ByRef aAxis As Short) As Byte
	
	' ���� ���� ����-====================================================================================================
	' Ȩ ��ġ �����嵵 ����
	Public Declare Function CIPemergency_stop Lib "AxtLib.dll" () As Byte
	
	' -�����˻� =========================================================================================================
	' ���̺귯�� �󿡼� Thread�� ����Ͽ� �˻��Ѵ�. ���� : ������ Ĩ���� StartSto speed�� ���� �� �ִ�.
	' �����˻��� �����Ѵ�.
	' bStop:
	' 0: ��������
	' 1: ������
	Public Declare Function CIPabort_home_search Lib "AxtLib.dll" (ByVal axis As Short, ByVal bStop As Byte) As Byte
	' �����˻��� �����Ѵ�. �����ϱ� ���� �����˻��� �ʿ��� ������ �ʿ��ϴ�.
	Public Declare Function CIPhome_search Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �Է� ����� ���ÿ� �����˻��� �ǽ��Ѵ�.
	Public Declare Function CIPhome_search_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short) As Byte
	' �����˻� �Ϸ� ���¸� Ȯ���Ѵ�.
	' ��ȯ��: 0: �����˻� ������, 1: �����˻� ����
	Public Declare Function CIPget_home_done Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ����� �����˻� ���¸� Ȯ���Ѵ�.
	Public Declare Function CIPget_home_done_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short) As Byte
	' ���� ���� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
	' ��ȯ��: 0: �����˻� ����, 1: �����˻� ����
	Public Declare Function CIPget_home_end_status Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� ����� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
	Public Declare Function CIPget_home_end_status_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short, ByRef endstatus As Byte) As Byte
	' ���� �˻��� �� ���ܸ��� method�� ����/Ȯ���Ѵ�.
	' Method�� ���� ���� 
	'    0 Bit ���� ��뿩�� ���� (0 : ������� ����, 1: �����
	'    1 Bit ������ ��� ���� (0 : ������, 1 : ���� �ð�)
	'    2 Bit ������� ���� (0 : ���� ����, 1 : �� ����)
	'    3 Bit �˻����� ���� (0 : cww(-), 1 : cw(+))
	' 7654 Bit detect signal ����(typedef : DETECT_DESTINATION_SIGNAL)
	Public Declare Function CIPset_home_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef method As Byte) As Byte
	Public Declare Function CIPget_home_method Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef method As Byte) As Byte
	' ���� �˻��� �� ���ܸ��� offset�� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_home_offset Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef offset As Double) As Byte
	Public Declare Function CIPget_home_offset Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef offset As Double) As Byte
	' �� ���� ���� �˻� �ӵ��� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_home_velocity Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef velocity As Double) As Byte
	Public Declare Function CIPget_home_velocity Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef velocity As Double) As Byte
	' ���� ���� ���� �˻� �� �� ���ܺ� �������� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_home_acceleration Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef acceleration As Double) As Byte
	Public Declare Function CIPget_home_acceleration Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef acceleration As Double) As Byte
	' ���� ���� ���� �˻� �� �� ���ܺ� ���� �ð��� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_home_acceltime Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef acceltime As Double) As Byte
	Public Declare Function CIPget_home_acceltime Lib "AxtLib.dll" (ByVal axis As Short, ByVal nstep As Short, ByRef acceltime As Double) As Byte
	' ���� �࿡ ���� �˻����� ���ڴ� 'Z'�� ���� ��� �� ���� �Ѱ谪�� ����/Ȯ���Ѵ�.(Pulse) - ������ ����� �˻� ����
	Public Declare Function CIPset_zphase_search_range Lib "AxtLib.dll" (ByVal axis As Short, ByVal pulses As Short) As Byte
	Public Declare Function CIPget_zphase_search_range Lib "AxtLib.dll" (ByVal axis As Short) As Short
	' ���� ��ġ�� ����(0 Position)���� �����Ѵ� - �������̸� ���õ�.
	Public Declare Function CIPhome_zero Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ������ ��� ���� ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������� ���� ���õ�
	Public Declare Function CIPhome_zero_all Lib "AxtLib.dll" (ByVal number As Short, ByRef axes As Short) As Byte
	
	'������ �࿡ ����/����̺� �ӵ� �� ���������� �Է��ϰ� ������ ���� �˻� ��带 ����Ͽ�
	'CAMC-IP Ĩ ���� ���� �˻� ����̺긦 �����Ѵ�. ���� ���� ���� �� �Լ��� �����.
	'���� : CAMC-IP Ĩ ���� ���� �˻� ����� +-End limit�� Org sensor�� �ἱ �Ǿ�� �ϸ� End limit ����� Enable�Ǿ�� �Ѵ�.
	'2 bit : �����˻� ����.(0 : Plus direction, 1 : Minus direction)
	'1 bit : �����˻��� ����� �ӵ� Profile(0 : Trapzoidal, 1: S-curve)
	'0 bit : ���� ������ ���� �˻� ��ȣ ����(0 : falling edge, 1:rising edge)
	Public Declare Function CIPstart_home_search_chip Lib "AxtLib.dll" (ByVal axis As Short, ByVal startstop As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal home_search_mode As Byte) As Byte
	Public Declare Function CIPstart_home_search_chip_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal startstop As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal home_search_mode As Byte) As Byte
	'������ �࿡ ����/����̺� �ӵ� �� ���������� �Է��ϰ� ������ ���� �˻� ��带 ����Ͽ�
	'CAMC-IP Ĩ ���� ���� �˻� ����̺긦 �����Ѵ�. ���� ���� ���� �� �Լ��� �����.
	'3 bit : �����˻� �Ϸ��� ��ġ clear ����(0: Clear count after search, 1: Maintain count after search)
	'2 bit : �����˻� ����.(0 : Plus direction, 1 : Minus direction)
	'1 bit : �����˻��� ����� �ӵ� Profile(0 : Trapzoidal, 1: S-curve)
	'0 bit : ���� ������ ���� �˻� ��ȣ ����(0 : falling edge, 1:rising edge)
	Public Declare Function CIPhome_search_chip Lib "AxtLib.dll" (ByVal axis As Short, ByVal startstop As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal home_search_mode As Byte) As Byte
	Public Declare Function CIPhome_search_chip_ex Lib "AxtLib.dll" (ByVal axis As Short, ByVal startstop As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal home_search_mode As Byte) As Byte
	
	' ���� �����-=======================================================================================================
	' ���� ��� ���� �����Ѵ�. �ش� ���� value(0x00 ~ 0x3F)�� �ش��ϴ� ��������� 'On'��Ų��.
	' ���� ���
	' 0 bit(CAMC-IP :UIO0) : ���� ��� 0(Servo-On)
	' 1 bit(CAMC-IP :UIO1) : ���� ��� 1(ALARM Clear)
	' 2 bit(CAMC-IP :UIO2) : ���� ��� 2
	' 3 bit(CAMC-IP :UIO3) : ���� ��� 3
	' 4 bit(CAMC-IP :UIO4) : ���� ��� 4
	' 5 bit(PLD)  : ���� ��� 5
	' ���� �Է�
	' 0 bit(CAMC-IP :UIO5) : ���� �Է� 0(ORiginal Sensor)
	' 1 bit(CAMC-IP :UIO6) : ���� �Է� 1(Z phase)
	' 2 bit(CAMC-IP :UIO7) : ���� �Է� 2
	' 3 bit(CAMC-IP :UIO8) : ���� �Է� 3
	' 4 bit(CAMC-IP :UIO9) : ���� �Է� 4
	' 5 bit(CAMC-IP :UIO10) : ���� �Է� 5
	' 6 bit(CAMC-IP :UIO11) : ���� �Է� 6
	' On ==> ���ڴ� N24V, 'Off' ==> ���ڴ� Open(float).
	
	' ���� ��°��� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_output Lib "AxtLib.dll" (ByVal axis As Short, ByVal value As Byte) As Byte
	Public Declare Function CIPget_output Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �Է� ���� Ȯ���Ѵ�.
	' '1'('On') <== ���ڴ� N24V�� �����, '0'('Off') <== ���ڴ� P24V �Ǵ� Float.
	Public Declare Function CIPget_input Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� �ش� bit�� ����� 'On' ��Ų��.
	' bitNo : 0 ~ 5.
	Public Declare Function CIPset_output_bit Lib "AxtLib.dll" (ByVal axis As Short, ByVal bitNo As Byte) As Byte
	' �ش� ���� �ش� ���� ����� 'Off' ��Ų��.
	Public Declare Function CIPreset_output_bit Lib "AxtLib.dll" (ByVal axis As Short, ByVal bitNo As Byte) As Byte
	' �ش� ���� �ش� ���� ��� bit�� ��� ���¸� Ȯ���Ѵ�.
	' bitNo : 0 ~ 5.    
	Public Declare Function CIPoutput_bit_on Lib "AxtLib.dll" (ByVal axis As Short, ByVal bitNo As Byte) As Byte
	' �ش� ���� �ش� ���� ��� bit�� ���¸� �Է� state�� �ٲ۴�.
	' bitNo : 0 ~ 5. 
	Public Declare Function CIPchange_output_bit Lib "AxtLib.dll" (ByVal axis As Short, ByVal bitNo As Byte, ByVal state As Byte) As Byte
	' �ش� ���� �ش� ���� �Է� bit�� ���¸� Ȯ�� �Ѵ�.
	' bitNo : 0 ~ 6.
	Public Declare Function CIPinput_bit_on Lib "AxtLib.dll" (ByVal axis As Short, ByVal bitNo As Byte) As Byte
	
	' �ܿ� �޽� clear-===================================================================================================
	' �ش� ���� ������ �ܿ� �޽� Clear ����� ��� ���θ� ����/Ȯ���Ѵ�.    
	' CLR ��ȣ�� Default ��� ==> ���ڴ� Open�̴�.
	Public Declare Function CIPset_crc_mask Lib "AxtLib.dll" (ByVal axis As Short, ByVal mask As Short) As Byte
	Public Declare Function CIPget_crc_mask Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� �ܿ� �޽� Clear ����� Active level�� ����/Ȯ���Ѵ�.
	' Default Active level ==> '1' ==> ���ڴ� N24V
	Public Declare Function CIPset_crc_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Short) As Byte
	Public Declare Function CIPget_crc_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� -Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.    
	Public Declare Function CIPset_crc_nelm_mask Lib "AxtLib.dll" (ByVal axis As Short, ByVal mask As Short) As Byte
	Public Declare Function CIPget_crc_nelm_mask Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� -Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.    
	Public Declare Function CIPset_crc_nelm_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Short) As Byte
	Public Declare Function CIPget_crc_nelm_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� +Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_crc_pelm_mask Lib "AxtLib.dll" (ByVal axis As Short, ByVal mask As Short) As Byte
	Public Declare Function CIPget_crc_pelm_mask Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� +Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.
	Public Declare Function CIPset_crc_pelm_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal level As Short) As Byte
	Public Declare Function CIPget_crc_pelm_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' �ش� ���� �ܿ� �޽� Clear ����� �Է� ������ ���� ���/Ȯ���Ѵ�.
	Public Declare Function CIPset_programmed_crc Lib "AxtLib.dll" (ByVal axis As Short, ByVal data As Short) As Byte
	Public Declare Function CIPget_programmed_crc Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	'-Ʈ���� ��� ======================================================================================================
	' ����/�ܺ� ��ġ�� ���Ͽ� �ֱ�/���� ��ġ���� ������ Active level�� Trigger pulse�� �߻� ��Ų��.
	' Ʈ���� ��� �޽��� Active level�� ����/Ȯ���Ѵ�.
	' ('0' : 5V ���(0 V), 24V �͹̳� ���(Open); '1'(default) : 5V ���(5 V), 24V �͹̳� ���(N24V).
	Public Declare Function CIPset_trigger_level Lib "AxtLib.dll" (ByVal axis As Short, ByVal trigger_level As Byte) As Byte
	Public Declare Function CIPget_trigger_level Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' Ʈ���� ��ɿ� ����� ���� ��ġ�� ����/Ȯ���Ѵ�.
	' trigger_sel
	' 0x0 : ���� ��ġ Internal(Command)
	' 0x1 : �ܺ� ��ġ External(Actual)
	Public Declare Function CIPset_trigger_sel Lib "AxtLib.dll" (ByVal axis As Short, ByVal trigger_sel As Byte) As Byte
	Public Declare Function CIPget_trigger_sel Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' Ʈ���� �޽����� ����/Ȯ���Ѵ�.
	' time
	' 00h : 4 msec(Ĩ ��� Bypass)
	' 01h : 16 mSec
	' 02h : 32 msec
	' 03h : 64 msec
	Public Declare Function CIPset_trigger_time Lib "AxtLib.dll" (ByVal axis As Short, ByVal a_time As Byte) As Byte
	Public Declare Function CIPget_trigger_time Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �࿡ Ʈ���� �߻� ����� ����/Ȯ���Ѵ�.
	' 0x0 : Ʈ���� ���� ��ġ���� Ʈ���� �߻�, ���� ��ġ ���
	' 0x1 : Ʈ���� ��ġ���� ����� �ֱ� Ʈ���� ���
	Public Declare Function CIPset_trigger_mode Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode_sel As Byte) As Byte
	Public Declare Function CIPget_trigger_mode Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �࿡ Ʈ���� �ֱ� �Ǵ� ���� ��ġ ���� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_trigger_position Lib "AxtLib.dll" (ByVal axis As Short, ByVal trigger_position As Double) As Byte
	Public Declare Function CIPget_trigger_position Lib "AxtLib.dll" (ByVal axis As Short) As Double
	' ���� ���� Ʈ���� ����� ��� ���θ� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_trigger_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal ena_status As Byte) As Byte
	Public Declare Function CIPis_trigger_enabled Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	' ���� �࿡ Ʈ���� �߻��� ���ͷ�Ʈ�� �߻��ϵ��� ����/Ȯ���Ѵ�.
	Public Declare Function CIPset_trigger_interrupt_enable Lib "AxtLib.dll" (ByVal axis As Short, ByVal ena_int As Byte) As Byte
	Public Declare Function CIPis_trigger_interrupt_enabled Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	'-Ĩ ���� ���� ��� ����============================================================================================
	' Module ��ȣ�� CIPget_axisno_2_moduleno�� Ȯ���Ѵ�.
	' ���� ��⿡ ������ CAMC-IP ���� ����� �ʱ�ȭ �Ѵ�.
	Public Declare Function CIPset_path_move_initialize Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Byte
	' ���� ��⿡ ������ CAMC-IP ���� queue�� ��� ���� ������ Ȯ���Ѵ�.
	Public Declare Function CIPis_path_move_queue_free Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Byte
	' ���� ��⿡ ������ CAMC-IP ���� queue�� �Է� ����Ÿ ������ Ȯ�� �Ѵ�..
	Public Declare Function CIPget_path_move_queue_index Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Byte
	' ���� ��⿡ ������ CAMC-IP�� ���� ���� �ӵ��� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_path_move_startstop_velocity Lib "AxtLib.dll" (ByVal nMouleNo As Short, ByVal velocity As Double)
	Public Declare Function CIPget_path_move_startstop_velocity Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Double
	' ���� ��⿡ ������ CAMC-IP�� ���� ���� �ӵ��� ����/Ȯ���Ѵ�.        
	Public Declare Sub CIPset_path_move_velocity Lib "AxtLib.dll" (ByVal nMouleNo As Short, ByVal velocity As Double)
	Public Declare Function CIPget_path_move_velocity Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Double
	' ���� ��⿡ ������ CAMC-IP�� ���� ���� �����ӷ��� ����/Ȯ���Ѵ�.
	Public Declare Sub CIPset_path_move_acceleration Lib "AxtLib.dll" (ByVal nMouleNo As Short, ByVal acceleration As Double)
	Public Declare Function CIPget_path_move_acceleration Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Double
	' ���� ��⿡ ������ CAMC-IP�� ���� ���� ������ �ð��� ����/Ȯ���Ѵ�.    
	Public Declare Sub CIPset_path_move_acceltime Lib "AxtLib.dll" (ByVal nMouleNo As Short, ByVal acceltime As Double)
	Public Declare Function CIPget_path_move_acceltime Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Double
	' ���� ��⿡ ������ CAMC-IP�� ���� ���� �� ����� �ӵ� ���������� ����/Ȯ���Ѵ�.            
	Public Declare Sub CIPset_path_move_profile Lib "AxtLib.dll" (ByVal nMouleNo As Short, ByVal mode As Short)
	Public Declare Function CIPget_path_move_profile Lib "AxtLib.dll" (ByVal nMouleNo As Short) As Short
	
	'-Ĩ ���� ���� ����̹� ����========================================================================================
	'linear_mode(�ڵ� �������� ���� ���� ���Ͽ� ���Ͽ� ��� �����ϴ�. ���� �������� �����ô� ���� ������ �������� �����ؾ� �Ѵ�.)
	' 0 Bit : ���� ������ ��뿩�� (0 : ������� ����, 1: ���)
	' 1 Bit : 2�� �ӵ� ���� ��� ��� ���� (0 : ������� ����, 1 : ���)
	' 2 Bit : �ڵ� ������ ��뿩�� (0 : ������� ����, 1 : ���), ������ ���� ������ ��뿩�δ� ���õȴ�.
	' 3 Bit : Queue ��ü ����(0 : ���� ��� ����(���� Queue�� �Է� ���� �ִٸ� �������� �ش� ���� �����, 1 : Queue�� ��ü)
	'circular_mode(���� �� ���� unit/pulse(pulse/unit)�� ���� �Ͽ��� �Ѵ�.)
	' 0Bit  : ������ ��뿩�� (0 : ������� ����, 1: ���)
	' 1Bit  : 2�� �ӵ� ���� ��� ��� ���� (0 : ������� ����, 1 : ���)
	' 2Bit  : ���� ���� (0 : CW, 1 : CCW)
	' 3 Bit : Queue ��ü ����(0 : ���� ��� ����(���� Queue�� �Է� ���� �ִٸ� �������� �ش� ���� �����, 1 : Queue�� ��ü)
	'start_** : ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�.
	'*r*_*    : �Էµ� ��ġ������ �Ÿ�(�����ǥ) �̴�. "*r_*�� ������ �Էµ� ��ġ������ (������ǥ)�̴�.
	'*_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
	'*_m*     : ��ȣ ������ ����ϴ� ���� �߽��� ��ǥ�� ���� ��ġ�� �������� �ϴ� ��� ��ǥ ������ �Է� �޴´�.
	'_circular: x/y���� ���� ����, x/y�� ���� �߽� ������ �����ϰ� ���� �����Ѵ�.
	'_circular_1: �������� �������� �Է� ���������� ���� �׷��� �� �ο��� ������ �������� �߽������� �����ϰ� ��ȣ ������ �����Ѵ�.
	'             �̶� radius���� (+) �̸� �۰Ե��� ��, (-) �̸� ũ�� ���� ��
	'_circular_2: ���� ����� �� �࿡ �߽����� �Է��ϰ� 0~360 ������ ���� ������ �Է��Ͽ� ���� ��ȣ ���������� �����Ѵ�.
	Public Declare Function CIPpath_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPpath_move_linear_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_linear_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	
	Public Declare Function CIPpath_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPpath_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPmr_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPmr_path_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	
	Public Declare Function CIPpath_move_circular_1 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPpath_move_circular_1_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular_1 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular_1_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	
	Public Declare Function CIPpath_move_circular_2 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPpath_move_circular_2_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular_2 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPr_path_move_circular_2_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	
	Public Declare Function CIPstart_path_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPstart_path_move_linear_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_linear_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	
	Public Declare Function CIPstart_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_path_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_mr_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_mr_path_move_circular_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	
	Public Declare Function CIPstart_path_move_circular_1 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_path_move_circular_1_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular_1 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular_1_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	
	Public Declare Function CIPstart_path_move_circular_2 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_path_move_circular_2_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular_2 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	Public Declare Function CIPstart_r_path_move_circular_2_ex Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	
	' ���� ����� �� ���� �̿��Ͽ� ���� ���� �Ϸ� ������ ���������� �����ǥ�� �������� �Է��Ͽ�
	' ���� ���������� Queue �� ��ü �Ǵ� ������ �����Ѵ�. ���� �ӵ� �Ķ���ʹ� ���� �����Ǿ� �ִ�
	' ���� �̿��Ѵ�. ���� ������ �ϳ��� ���Ͽ� ���� �Է��� �����Ѵ�. ���� ���� ������ ��conti_�� ����
	' ���� ����̺� �Լ��� ���� ������� �������� �ϰ� �����ϸ� �ȴ�.
	Public Declare Function CIPconti_r_path_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	' ���� ����� �� �࿡ ���� ���� �Ϸ� ������ ���������� �����ǥ�� �߽����� �Է��ϰ� 0~360
	' ������ ���� ������ �Է��Ͽ� ���� ��ȣ ���������� Queue �� ��ü �Ǵ� ������ �����Ѵ�. ����
	' �ӵ� �Ķ���ʹ� ���� �����Ǿ� �ִ� ���� �̿��Ѵ�. ���� ������ �ϳ��� ���Ͽ� ���� �Է���
	' �����Ѵ�. ���� ���� ������ ��conti_�� ���� ���� ����̺� �Լ��� ���� ������� �������� �ϰ�
	' �����ϸ� �ȴ�.    
	Public Declare Function CIPconti_r_path_move_circular_2 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_cen As Double, ByVal y_cen As Double, ByVal angle As Double, ByVal circular_mode As Byte) As Byte
	' ���� ����� �� �࿡ ���� ���� �Ϸ� ������ ���������� ��� ��ǥ�� �������� �Է��ϰ�, ��ȣ��
	' �ִ� ������ ���� �Է��Ͽ� ���� ��ȣ ���������� Queue�� ��ü �Ǵ� ������ �����Ѵ�. ���� �ӵ�
	' �Ķ���ʹ� ���� �����Ǿ� �ִ� ���� �̿��Ѵ�. ���� ������ �ϳ��� ���Ͽ� ���� �Է��� �����Ѵ�.
	' ���� ���� ������ ��conti_�� ���� ���� ����̺� �Լ��� ���� ������� �������� �ϰ� �����ϸ�
	' �ȴ�.
	Public Declare Function CIPconti_r_path_move_circular_1 Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal radius As Double, ByVal circular_mode As Byte) As Byte
	' ���� ����� �� �࿡ ���� ���� �Ϸ� ������ ���������� ��� ��ǥ�� ������ �� ������ �Է��Ͽ�
	' ��ȣ ���������� Queue �� ��ü �Ǵ� ������ �����Ѵ�. ���� �ӵ� �Ķ���ʹ� ���� �����Ǿ� �ִ�
	' ���� �̿��Ѵ�. ���� ������ �ϳ��� ���Ͽ� ���� �Է��� �����Ѵ�. ���� ���� ������ ��conti_�� ����
	' ���� ����̺� �Լ��� ���� ������� �������� �ϰ� �����ϸ� �ȴ�.
	Public Declare Function CIPconti_r_path_move_circular Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x_end As Double, ByVal y_end As Double, ByVal x_cen As Double, ByVal y_cen As Double, ByVal circular_mode As Byte) As Byte
	' ���� ����� �� ���� �̿��Ͽ� ���� ���� �Ϸ� ������ ���������� �����ǥ�� �������� �Է��Ͽ�
	' ���� ���������� Queue �� ��ü �Ǵ� ������ �����Ѵ�. ���� �ӵ� �Ķ���ʹ� ���� �����Ǿ� �ִ�
	' ���� �̿��Ѵ�. ���� ������ �ϳ��� ���Ͽ� ���� �Է��� �����Ѵ�. ���� ���� ������ ��conti_�� ����
	' ���� ����̺� �Լ��� ���� ������� �������� �ϰ� �����ϸ� �ȴ�. ���� ������ ���� ���Ͽ�
	' ���Ͽ� ����ϸ� ���ӽ� ���� �޽� ������ ������ ���� ������ �ڵ����� ����Ǿ� ����ȴ�.
	Public Declare Function CIPcontiend_r_path_move_linear Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal x As Double, ByVal y As Double, ByVal linear_mode As Byte) As Byte
	
	'-==================================================================================================================
	' Script/Caption ������ ���� �Լ�
	Public Declare Function CIPSetScriptCaption Lib "AxtLib.dll" (ByVal axis As Short, ByVal sc As Short, ByVal event1 As Byte, ByVal event2 As Byte, ByVal event_logic As Byte, ByVal cmd As Byte, ByVal data As Integer) As Byte
	' sc(�Է�) ==========================================================================
	'        SCRIPT_REG1                    1    // ��ũ��Ʈ ��������-1
	'        SCRIPT_REG2                    2    // ��ũ��Ʈ ��������-2
	'        SCRIPT_REG3                    3    // ��ũ��Ʈ ��������-3
	'        SCRIPT_REG_QUEUE            4    // ��ũ��Ʈ ��������-Queue
	'        CAPTION_REG1                11    // ������ ��������-1
	'        CAPTION_REG2                12    // ������ ��������-2
	'        CAPTION_REG3                13    // ������ ��������-3
	'        CAPTION_REG_QUEUE            14    // ������ ��������-Queue
	' event1(�Է�)  ====================================================================
	'        ����͸� �� event ù��°. IPEVENT�� define�� ���� ���.
	' event2(�Է�)  ====================================================================
	'        ����͸� �� event �ι�°. IPEVENT�� define�� ���� ���.
	' event_logic(�Է�) ==================================================================
	'        7 bit : 0(One time execution), 1(Always execution)
	'        6 bit : sc�� ���� ������ ���� �������� ����.
	'                sc = SCRIPT_REG1, SCRIPT_REG2, SCRIPT_REG3 �� ��. Script ���۽� ����� ����Ÿ �Է� ����.
	'                    0(data ���), 1(ALU ��� ����� ���) 
	'                sc = SCRIPT_REG_QUEUE �� ��. Script ���۽� ���ͷ�Ʈ ��� ����. �ش� ���ͷ�Ʈ mask�� enable �Ǿ� �־�� ��.
	'                    0(���ͷ�Ʈ �߻����� ����), 1(�ش� script ����� ���ͷ�Ʈ �߻�) 
	'                sc = CAPTION_REG1, CAPTION_REG2, CAPTION_REG3 �� ��. Don't care.
	'                sc = CAPTION_REG_QUEUE. Caption ���۽� ���ͷ�Ʈ ��� ����. �ش� ���ͷ�Ʈ mask�� enable�Ǿ� �־�� ��.
	'                    0(���ͷ�Ʈ �߻����� ����), 1(�ش� caption ����� ���ͷ�Ʈ �߻�) 
	'        5 ~ 4bit : "00" : Don't execute command 
	'                   "01" : Execute command in X
	'                   "10" : Execute command in Y
	'                   "11" : Execute command in X,Y(Caption:Don't execution)
	'        3 bit : Second event source axis selection(0 : X axis, 1 : Y axis)
	'        2 bit : First event source axis selection(0 : X axis, 1 : Y axis)  
	'        1~0 bit :   "00" : Use first event source only
	'                    "01" : OR operation
	'                    "11" : AND operation
	'                    "11" : XOR operation
	' cmd(�Է�) ========================================================================
	'        �̺�Ʈ �߻��� ���� ��ų ��ɾ�. IPCOMMAND�� define�� ���� ���.    
	
	'-==================================================================================================================
	' Inter Axis, Inter Module sync setting(UIO11�� �̿��� ��Ⱓ, �ణ ���� ��� ������ ���� ����)
	' ��⳻ ���� IO�� ����� Sync ����� ����ϱ� ���� ����, SMC-2V03 version 2.0 �̸������� ����.
	Public Declare Function CIPset_sync_mode Lib "AxtLib.dll" (ByVal axis As Short, ByVal mode As Byte) As Byte
	Public Declare Function CIPget_sync_mode Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPset_sync_mode_master Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	Public Declare Function CIPset_sync_mode_slave Lib "AxtLib.dll" (ByVal axis As Short) As Byte
	
	' ���� ���̽� ���峻 ��Ⱓ Sync�� ����� ����ϱ����� ����.
	' ��⳻ ���� IO�� ����� Sync ����� ����ϱ� ���� ����, SMC-2V03 version 2.0 �̸������� ����.
	Public Declare Function CIPset_sync_all_mode Lib "AxtLib.dll" (ByVal nModuleNo As Short, ByVal mode As Byte) As Byte
	Public Declare Function CIPget_sync_all_mode Lib "AxtLib.dll" (ByVal nModuleNo As Short) As Byte
	Public Declare Function CIPset_sync_all_mode_master Lib "AxtLib.dll" (ByVal nModuleNo As Short) As Byte
	Public Declare Function CIPset_sync_all_mode_slave Lib "AxtLib.dll" (ByVal nModuleNo As Short) As Byte
	Public Declare Function CIPset_sync_all_mode_disable Lib "AxtLib.dll" (ByVal nModuleNo As Short) As Byte
	
	' �����ڵ� �б� �Լ��� =============================================================================================
	' ������ �����ڵ带 �д´�.
	Public Declare Function CIPget_error_code Lib "AxtLib.dll" () As Short
	' �����ڵ��� ������ ���ڷ� ��ȯ�Ѵ�.
	Public Declare Function CIPget_error_msg Lib "AxtLib.dll" (ByVal ErrorCode As Short) As String
End Module