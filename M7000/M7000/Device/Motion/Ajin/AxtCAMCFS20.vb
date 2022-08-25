Option Strict Off
Option Explicit On

Module AxtCAMCFS20
    ''/*------------------------------------------------------------------------------------------------*
    '	AXTCAMCFS Library - CAMC-FS 2.0�̻� Motion module
    '	������ǰ
    '		SMC-1V02 - CAMC-FS Ver2.0 �̻� 1��
    '		SMC-2V02 - CAMC-FS Ver2.0 �̻� 2��
    ' *------------------------------------------------------------------------------------------------*/

    ' ���� �ʱ�ȭ �Լ���        -======================================================================================
    ' CAMC-FS�� ������ ���(SMC-1V02, SMC-2V02)�� �˻��Ͽ� �ʱ�ȭ�Ѵ�. CAMC-FS 2.0�̻� �����Ѵ�
    ' reset	: 1(TRUE) = ��������(ī���� ��)�� �ʱ�ȭ�Ѵ�
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
    Public Declare Function InitializeCAMCFS20 Lib "AxtLib.dll" (ByVal reset As Byte) As Byte
    ' CAMC-FS20 ����� ����� ���������� Ȯ���Ѵ�
    ' ���ϰ� :  1(TRUE) = CAMC-FS20 ����� ��� �����ϴ�
    Public Declare Function CFS20IsInitialized Lib "AxtLib.dll" () As Byte
    ' CAMC-FS20�� ������ ����� ����� �����Ѵ�
    Public Declare Sub CFS20StopService Lib "AxtLib.dll" ()

    '/ ���� ���� ���� �Լ���        -===================================================================================
    ' ������ �ּҿ� ������ ���̽������� ��ȣ�� �����Ѵ�. ������ -1�� �����Ѵ�
    Public Declare Function CFS20get_boardno Lib "AxtLib.dll" (ByVal address As Long) As Integer
    ' ���̽������� ������ �����Ѵ�
    Public Declare Function CFS20get_numof_boards Lib "AxtLib.dll" () As Integer
    ' ������ ���̽����忡 ������ ���� ������ �����Ѵ�
    Public Declare Function CFS20get_numof_axes Lib "AxtLib.dll" (ByVal nBoardNo As Integer) As Integer
    ' ���� ������ �����Ѵ�
    Public Declare Function CFS20get_total_numof_axis Lib "AxtLib.dll" () As Integer
    ' ������ ���̽������ȣ�� ����ȣ�� �ش��ϴ� ���ȣ�� �����Ѵ�
    Public Declare Function CFS20get_axisno Lib "AxtLib.dll" (ByVal nBoardNo As Integer, ByVal nModuleNo As Integer) As Integer
    ' ������ ���� ������ �����Ѵ�
    ' nBoardNo : �ش� ���� ������ ���̽������� ��ȣ.
    ' nModuleNo: �ش� ���� ������ ����� ���̽� ��峻 ��� ��ġ(0~3)
    ' bModuleID: �ش� ���� ������ ����� ID : SMC-2V02(0x02)
    ' nAxisPos : �ش� ���� ������ ����� ù��°���� �ι�° ������ ����.(0 : ù��°, 1 : �ι�°)
    Public Declare Function CFS20get_axis_info Lib "AxtLib.dll" (ByVal nAxisNo As Integer, ByRef nBoardNo As Integer, ByRef nModuleNo As Integer, ByRef bModuleID As Byte, ByRef nAxisPos As Integer) As Byte

    ' ���� ���� �Լ���        -========================================================================================
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
    '  9) ���ڴ� �Է¹��2 ������
    ' 10) ����/�ܺ� ī���� : 0. 	
    Public Declare Function CFS20load_parameter Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nfilename As String) As Byte
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
    '  9) ���ڴ� �Է¹��2 ������
    Public Declare Function CFS20save_parameter Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nfilename As String) As Byte
    ' ��� ���� �ʱⰪ�� ������ ���Ͽ��� �о �����Ѵ�
    Public Declare Function CFS20load_parameter_all Lib "AxtLib.dll" (ByVal nfilename As String) As Byte
    ' ��� ���� �ʱⰪ�� ������ ���Ͽ� �����Ѵ�
    Public Declare Function CFS20save_parameter_all Lib "AxtLib.dll" (ByVal nfilename As String) As Byte

    ' ���ͷ�Ʈ �Լ���   -================================================================================================
    '(���ͷ�Ʈ�� ����ϱ� ���ؼ��� 
    'Window message & procedure
    '    hWnd    : ������ �ڵ�, ������ �޼����� ������ ���. ������� ������ NULL�� �Է�.
    '    wMsg    : ������ �ڵ��� �޼���, ������� �ʰų� ����Ʈ���� ����Ϸ��� 0�� �Է�.
    '    proc    : ���ͷ�Ʈ �߻��� ȣ��� �Լ��� ������, ������� ������ NULL�� �Է�.
    Public Declare Sub CFS20SetWindowMessage Lib "AxtLib.dll" (ByVal hWnd As Long, ByVal wMsg As Integer, ByVal proc As Long)
    '-===============================================================================
    ' ReadInterruptFlag���� ������ ���� flag������ �о� ���� �Լ�(���ͷ�Ʈ service routine���� ���ͷ��� �߻� ������ �Ǻ��Ѵ�.)
    ' ���ϰ�: ���ͷ�Ʈ�� �߻� �Ͽ����� �߻��ϴ� ���ͷ�Ʈ flag register(CAMC-FS20 �� INTFLAG ����.)
    Public Declare Function CFS20read_interrupt_flag Lib "AxtLib.dll" (ByVal axis As Integer) As Long

    ' ���� ���� �ʱ�ȭ �Լ���        -==================================================================================
    ' ����Ŭ�� ����( ��⿡ ������ Oscillator�� ����� ��쿡�� ����)
    Public Declare Sub CFS20KeSetMainClk Lib "AxtLib.dll" (ByVal nMainClk As Long)
    ' Drive mode 1�� ����/Ȯ���Ѵ�.
    ' decelstartpoint : �����Ÿ� ���� ��� ����� ���� ��ġ ���� ��� ����(0 : �ڵ� ������, 1 : ���� ������)
    ' pulseoutmethod : ��� �޽� ��� ����(typedef : PULSE_OUTPUT)
    ' detecsignal : ��ȣ �˻�-1/2 ���� ��� ����� �˻� �� ��ȣ ����(typedef : DETECT_DESTINATION_SIGNAL)
    Public Declare Sub CFS20set_drive_mode1 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal decelstartpoint As Byte, ByVal pulseoutmethod As Byte, ByVal detectsignal As Byte)
    Public Declare Function CFS20get_drive_mode1 Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' Drive mode 2�� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_drive_mode2 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal encmethod As Byte, ByVal inpactivelevel As Byte, ByVal alarmactivelevel As Byte, ByVal nslmactivelevel As Byte, ByVal pslmactivelevel As Byte, ByVal nelmactivelevel As Byte, ByVal pelmactivelevel As Byte)
    Public Declare Function CFS20get_drive_mode2 Lib "AxtLib.dll" (ByVal axis As Integer) As Integer
    ' Unit/Pulse ����/Ȯ���Ѵ�.
    ' Unit/Pulse : 1 pulse�� ���� system�� �̵��Ÿ��� ���ϸ�, �̶� Unit�� ������ ����ڰ� ���Ƿ� ������ �� �ִ�.
    ' Ex) Ball screw pitch : 10mm, ���� 1ȸ���� �޽��� : 10000 ==> Unit�� mm�� ������ ��� : Unit/Pulse = 10/10000.
    ' ���� unitperpulse�� 0.001�� �Է��ϸ� ��� ��������� mm�� ������. 
    ' Ex) Linear motor�� ���ش��� 1 pulse�� 2 uM. ==> Unit�� mm�� ������ ��� : Unit/Pulse = 0.002/1.
    Public Declare Sub CFS20set_moveunit_perpulse Lib "AxtLib.dll" (ByVal axis As Integer, ByVal unitperpulse As Double)
    Public Declare Function CFS20get_moveunit_perpulse Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' Unit/Pulse�� ��������� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_movepulse_perunit Lib "AxtLib.dll" (ByVal axis As Integer, ByVal pulseperunit As Double)
    Public Declare Function CFS20get_movepulse_perunit Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ���� �ӵ� ����/Ȯ���Ѵ�.(Unit/Sec)
    Public Declare Sub CFS20set_startstop_speed Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double)
    Public Declare Function CFS20get_startstop_speed Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' �ְ� �ӵ� ���� Unit/Sec. ���� system�� �ְ� �ӵ��� �����Ѵ�.
    ' Unit/Pulse ������ ���ۼӵ� ���� ���Ŀ� �����Ѵ�.
    ' ������ �ְ� �ӵ� �̻����δ� ������ �Ҽ� �����Ƿ� �����Ѵ�.
    Public Declare Function CFS20set_max_speed Lib "AxtLib.dll" (ByVal axis As Integer, ByVal max_velocity As Double) As Byte
    Public Declare Function CFS20get_max_speed Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' SW�� ����� ���� ����/Ȯ���Ѵ�. �̰����� S-Curve ������ percentage�� ���� �����ϴ�.
    Public Declare Sub CFS20set_s_rate Lib "AxtLib.dll" (ByVal axis As Integer, ByVal a_percent As Double, ByVal b_percent As Double)
    Public Declare Sub CFS20get_s_rate Lib "AxtLib.dll" (ByVal axis As Integer, ByRef a_percent As Double, ByRef b_percent As Double)
    ' ���� ������ ��忡�� �ܷ� �޽��� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_slowdown_rear_pulse Lib "AxtLib.dll" (ByVal axis As Integer, ByVal ulData As Long)
    Public Declare Function CFS20get_slowdown_rear_pulse Lib "AxtLib.dll" (ByVal axis As Integer) As Long
    ' ���� ���� ���� ���� ������ ���� ����� ����/Ȯ���Ѵ�.
    ' 0x0 : �ڵ� ������.
    ' 0x1 : ���� ������.
    Public Declare Function CFS20set_decel_point Lib "AxtLib.dll" (ByVal axis As Integer, ByVal method As Byte) As Byte
    Public Declare Function CFS20get_decel_point Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ���� ���� Ȯ�� �Լ���        -=====================================================================================
    ' ���� ���� �޽� ����������� Ȯ���Ѵ�.
    Public Declare Function CFS20in_motion Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� �޽� ����� ����ƴ��� Ȯ���Ѵ�.
    Public Declare Function CFS20motion_done Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� �������� ���� ��µ� �޽� ī���� ���� Ȯ���Ѵ�. (Pulse)
    Public Declare Function CFS20get_drive_pulse_counts Lib "AxtLib.dll" (ByVal axis As Integer) As Long
    ' ���� ���� DriveStatus �������͸� Ȯ���Ѵ�.
    Public Declare Function CFS20get_drive_status Lib "AxtLib.dll" (ByVal axis As Integer) As Integer
    ' ���� ���� EndStatus �������͸� Ȯ���Ѵ�.
    ' End Status Bit�� �ǹ�
    ' 14bit : Limit(PELM, NELM, PSLM, NSLM, Soft)�� ���� ����
    ' 13bit : Limit ���� ������ ���� ����
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
    Public Declare Function CFS20get_end_status Lib "AxtLib.dll" (ByVal axis As Integer) As Integer
    ' ���� ���� Mechanical �������͸� Ȯ���Ѵ�.
    ' Mechanical Signal Bit�� �ǹ�
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
    Public Declare Function CFS20get_mechanical_signal Lib "AxtLib.dll" (ByVal axis As Integer) As Integer
    ' ���� ����  ���� �ӵ��� �о� �´�.(Unit/Sec)
    Public Declare Function CFS20get_velocity Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ���� ���� Command position�� Actual position�� ���� Ȯ���Ѵ�.
    Public Declare Function CFS20get_error Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ���� ���� ���� ����̺��� �̵� �Ÿ��� Ȯ�� �Ѵ�. (Unit)
    Public Declare Function CFS20get_drivedistance Lib "AxtLib.dll" (ByVal axis As Integer) As Double

    ' Encoder �Է� ��� ���� �Լ���        -=============================================================================
    ' ���� ���� Encoder �Է� ����� ����/Ȯ���Ѵ�.
    ' method : typedef(EXTERNAL_COUNTER_INPUT)
    ' UpDownMode = 0x0    // Up/Down
    ' Sqr1Mode   = 0x1    // 1ü��
    ' Sqr2Mode   = 0x2    // 2ü��
    ' Sqr4Mode   = 0x3    // 4ü��
    Public Declare Function CFS20set_enc_input_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal method As Byte) As Byte
    Public Declare Function CFS20get_enc_input_method Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� �ܺ� ��ġ counter clear�� ����� ����/Ȯ���Ѵ�.
    ' method : CAMC-FS chip �޴��� EXTCNTCLR �������� ����.
    Public Declare Function CFS20set_enc2_input_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal method As Byte) As Byte
    Public Declare Function CFS20get_enc2_input_method Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� �ܺ� ��ġ counter�� count ����� ����/Ȯ���Ѵ�.
    ' reverse :
    ' TRUE  : �Է� ���ڴ��� �ݴ�Ǵ� �������� count�Ѵ�.
    ' FALSE : �Է� ���ڴ��� ���� ���������� count�Ѵ�.
    Public Declare Function CFS20set_enc_reverse Lib "AxtLib.dll" (ByVal axis As Integer, ByVal reverse As Byte) As Byte
    Public Declare Function CFS20get_enc_reverse Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' �޽� ��� ��� �Լ���        -=====================================================================================
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
    Public Declare Function CFS20set_pulse_out_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal method As Byte) As Byte
    Public Declare Function CFS20get_pulse_out_method Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ��ġ Ȯ�� �� ��ġ �� ���� �Լ��� -===============================================================================
    ' �ܺ� ��ġ ���� �����Ѵ�. ������ ���¿��� �ܺ� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    Public Declare Sub CFS20set_actual_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_actual_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ���� ��ġ ���� �����Ѵ�. ������ ���¿��� ���� ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    Public Declare Sub CFS20set_command_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_command_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double

    ' ���� ����̹� ��� ��ȣ ���� �Լ���-===============================================================================
    ' ���� Enable��� ��ȣ�� Active Level�� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_servo_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_servo_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� Enable(On) / Disable(Off)�� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_servo_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal state As Byte) As Byte
    Public Declare Function CFS20get_servo_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ���� ����̹� �Է� ��ȣ ���� �Լ���-===============================================================================
    ' ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� ��������� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_inposition_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_inposition_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ��ġ�����Ϸ�(inposition)�Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_inposition_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_inposition_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_inposition_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20in_position Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �˶� �Է½�ȣ ����� ��������� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_alarm_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_alarm_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �˶� �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_alarm_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_alarm_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_alarm_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ����Ʈ ��ȣ ���� �Լ���-===========================================================================================
    ' ������ ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_end_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_end_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' -������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_nend_limit_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_nend_limit_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_nend_limit_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' +������ ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_pend_limit_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_pend_limit_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_pend_limit_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �������� ����Ʈ ��� ��������� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_slow_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_slow_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' -�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_nslow_limit_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_nslow_limit_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_nslow_limit_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' +�������� ����Ʈ �Է� ��ȣ�� Active Level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_pslow_limit_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_pslow_limit_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_pslow_limit_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' -LIMIT ���� ������ ��/�������� ���θ� ����/Ȯ���Ѵ�. (Ver 3.0���� ����)
    ' stop:
    ' 0 : ������, 1 : ��������
    Public Declare Function CFS20set_nlimit_sel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal a_stop As Byte) As Byte
    Public Declare Function CFS20get_nlimit_sel Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' +LIMIT ���� ������ ��/�������� ���θ� ����/Ȯ���Ѵ�. (Ver 3.0���� ����)	
    ' stop:
    ' 0 : ������, 1 : ��������
    Public Declare Function CFS20set_plimit_sel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal a_stop As Byte) As Byte
    Public Declare Function CFS20get_plimit_sel Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ����Ʈ���� ����Ʈ ���� �Լ���-=====================================================================================
    ' ����Ʈ���� ����Ʈ ��������� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_soft_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte)
    Public Declare Function CFS20get_soft_limit_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ����Ʈ���� ����Ʈ ���� ������ġ������ ����/Ȯ���Ѵ�.
    ' sel :
    ' 0x0 : ������ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
    ' 0x1 : �ܺ���ġ�� ���Ͽ� ����Ʈ���� ����Ʈ ��� ����.
    Public Declare Sub CFS20set_soft_limit_sel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal sel As Byte)
    Public Declare Function CFS20get_soft_limit_sel Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ����Ʈ���� ����Ʈ �߻��� ���� ��带 ����/Ȯ���Ѵ�.
    ' mode :
    ' 0x0 : ����Ʈ���� ����Ʈ ��ġ���� ������ �Ѵ�.
    ' 0x1 : ����Ʈ���� ����Ʈ ��ġ���� �������� �Ѵ�.
    Public Declare Sub CFS20set_soft_limit_stopmode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mode As Byte)
    Public Declare Function CFS20get_soft_limit_stopmode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ����Ʈ���� ����Ʈ -��ġ�� ����/Ȯ���Ѵ�.(position = Unit)
    Public Declare Sub CFS20set_soft_nlimit_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_soft_nlimit_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ����Ʈ���� ����Ʈ +��ġ�� ����/Ȯ�� �Ѵ�.(position = Unit)
    Public Declare Sub CFS20set_soft_plimit_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_soft_plimit_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double

    ' ������� ��ȣ-=====================================================================================================
    ' ESTOP, SSTOP ��ȣ ��������� ����/Ȯ���Ѵ�.(Emergency stop, Slow-Down stop)
    Public Declare Function CFS20set_emg_signal_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_emg_signal_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ��������� ��/�������� ���θ� ����/Ȯ���Ѵ�.
    ' stop:
    ' 0 : ������, 1 : ��������
    Public Declare Function CFS20set_stop_sel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal a_stop As Byte) As Byte
    Public Declare Function CFS20get_stop_sel Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ���� ���� �Ÿ� ����-===============================================================================================
    ' start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�(Blocking).
    ' *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    ' *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    ' *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    ' *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.
    ' �Է� ����: velocity(Unit/Sec), acceleration/deceleration(Unit/Sec^2), acceltime/deceltime(Sec), position(Unit)

    ' ��Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Integer
    Public Declare Function CFS20move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Integer
    Public Declare Function CFS20r_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Integer
    Public Declare Function CFS20r_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Integer
    ' Non Blocking�Լ� (�������� ��� ���õ�)
    Public Declare Function CFS20start_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    Public Declare Function CFS20start_r_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_r_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    ' ���Ī �����޽�(Pulse Drive), ��ٸ��� ���� �Լ�, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20a_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Integer
    Public Declare Function CFS20a_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Integer
    Public Declare Function CFS20ra_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Integer
    Public Declare Function CFS20ra_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Integer
    ' Non Blocking�Լ� (�������� ��� ���õ�)
    Public Declare Function CFS20start_a_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20start_a_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
    Public Declare Function CFS20start_ra_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20start_ra_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
    ' ��Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20s_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Integer
    Public Declare Function CFS20s_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Integer
    Public Declare Function CFS20rs_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Integer
    Public Declare Function CFS20rs_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Integer
    ' Non Blocking�Լ� (�������� ��� ���õ�)
    Public Declare Function CFS20start_s_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_s_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    Public Declare Function CFS20start_rs_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_rs_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    ' ���Ī �����޽�(Pulse Drive), S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20as_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Integer
    Public Declare Function CFS20as_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Integer
    Public Declare Function CFS20ras_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Integer
    Public Declare Function CFS20ras_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Integer
    ' Non Blocking�Լ� (�������� ��� ���õ�), jerk���(���� : �ۼ�Ʈ) ���������� S�� �̵�����.
    Public Declare Function CFS20start_as_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20start_as_move2 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal jerk As Double) As Byte
    Public Declare Function CFS20start_as_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
    Public Declare Function CFS20start_ras_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20start_ras_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte

    ' ��Ī ���� �޽�(Pulse Drive), S���� ����, �����ǥ, ������,
    ' Non Blocking (�������� ��� ���õ�), ���� ��ġ�� �������� over_distance���� over_velocity�� �ӵ��� ���� �Ѵ�.
    Public Declare Function CFS20start_rs_move_override Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal over_distance As Double, ByVal over_velocity As Double, ByVal Target As Byte) As Byte

    ' ���� ���� ����-====================================================================================================
    ' ���� �����ӵ� �� �ӵ��� ���� ������ �߻����� ������ ���������� �����Ѵ�.
    ' *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    ' *a*_*    : ������ �ӵ� �����ӵ��� ���Ī���� ����Ѵ�. ���ӷ� �Ǵ� ���� �ð���  ���ӷ� �Ǵ� ���� �ð��� ���� �Է¹޴´�.
    ' *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    ' ���ӵ� ��ٸ��� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
    ' ��Ī ������ �����Լ�
    Public Declare Function CFS20v_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20v_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    ' ���Ī ������ �����Լ�
    Public Declare Function CFS20v_a_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20v_a_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte
    ' ���ӵ� S���� ���� �Լ���, ������/���ӽð�(_ex)(�ð�����:Sec) - �������� ��쿡�� �ӵ��������̵�
    ' ��Ī ������ �����Լ�
    Public Declare Function CFS20v_s_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20v_s_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    ' ���Ī ������ �����Լ�
    Public Declare Function CFS20v_as_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double) As Byte
    Public Declare Function CFS20v_as_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double) As Byte

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
    Public Declare Function CFS20start_signal_search1 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double, ByVal detect_signal As Byte) As Byte
    Public Declare Function CFS20start_signal_search1_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double, ByVal detect_signal As Byte) As Byte
    ' ��ȣ����1(Signal search 1) S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    Public Declare Function CFS20start_s_signal_search1 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double, ByVal detect_signal As Byte) As Byte
    Public Declare Function CFS20start_s_signal_search1_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double, ByVal detect_signal As Byte) As Byte
    ' ��ȣ����2(Signal search 2) ��ٸ��� ����, ������ ����
    Public Declare Function CFS20start_signal_search2 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal detect_signal As Byte) As Byte

    ' MPG(Manual Pulse Generation) ���� ����-===========================================================================
    ' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ��带 ����/Ȯ���Ѵ�.
    ' mode
    ' 0x1 : Slave �������, �ܺ� Differential ��ȣ�� ���� ���
    ' 0x2 : ���� �޽� ����, �ܺ� �Է� ��ȣ�� ���� ���� �޽� ���� ����
    ' 0x4 : ���� ���� ���, �ܺ� ���� �Է� ��ȣ�� Ư�� ���� ���� ����
    Public Declare Function CFS20set_mpg_drive_mode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mode As Byte) As Byte
    Public Declare Function CFS20get_mpg_drive_mode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������带 ����/Ȯ���Ѵ�.
    ' mode
    ' 0x0 : �ܺ� ��ȣ�� ���� ���� ����
    ' 0x1 : ����ڿ� ���� ������ �������� ����
    Public Declare Function CFS20set_mpg_dir_mode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mode As Byte) As Byte
    Public Declare Function CFS20get_mpg_dir_mode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���� ���� ������尡 ����ڿ� ����
    ' ������ �������� �����Ǿ��� �� �ʿ��� ������� ���� ���� ���� ���� ����/Ȯ���Ѵ�.
    ' mode
    ' 0x0 : ����� ���� ���� ������ +�� ����
    ' 0x1 : ����� ���� ���� ������ -�� ����
    Public Declare Function CFS20set_mpg_user_dir Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mode As Byte) As Byte
    Public Declare Function CFS20get_mpg_user_dir Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ MPG(Manual Pulse Generation) ����̹��� ���Ǵ� EXPP/EXMP �� �Է� ��带 �����Ѵ�.
    '  2 bit : '0' : level input(���� �Է� 4 = EXPP, ���� �Է� 5 = EXMP�� �Է� �޴´�.)
    '          '1' : Differential input(���� �Է����� EXPP, EXMP�� �Է� ����,)
    '  1~0bit: "00" : 1 phase
    '          "01" : 2 phase 1 times
    '          "10" : 2 phase 2 times
    '          "11" : 2 phase 4 times
    Public Declare Function CFS20set_mpg_input_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal method As Byte) As Byte
    Public Declare Function CFS20get_mpg_input_method Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' MPG��ġ ���� �����Ѵ�. ������ ���¿��� MPG ��ġ�� Ư�� ������ ����/Ȯ���Ѵ�.(position = Unit)
    Public Declare Function CFS20set_mpg_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double) As Byte
    Public Declare Function CFS20get_mpg_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double

    ' MPG(Manual Pulse Generation) ���� -===============================================================================
    ' ������ �ӵ��� ��ٸ��� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    Public Declare Function CFS20start_mpg Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_mpg_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double) As Byte
    ' ������ �ӵ��� S���� ����, ������/���ӽð�(_ex)(�ð�����:Sec)
    Public Declare Function CFS20start_s_mpg Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double) As Byte
    Public Declare Function CFS20start_s_mpg_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceltime As Double) As Byte

    ' �������̵�(������)-================================================================================================
    ' ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� ��ġ(������ġ)�� ������ �ٲ۴�.
    Public Declare Function CFS20position_override Lib "AxtLib.dll" (ByVal axis As Integer, ByVal overrideposition As Double) As Byte
    ' ���� ���� �Ÿ� ������ ���� ���۽������� �Է��� �Ÿ�(�����ġ)�� ������ �ٲ۴�.    
    Public Declare Function CFS20position_r_override Lib "AxtLib.dll" (ByVal axis As Integer, ByVal overridedistance As Double) As Byte
    ' ������ ���� �ʱ� ������ �ӵ��� �ٲ۴�.(set_max_speed > velocity > set_startstop_speed)
    Public Declare Function CFS20velocity_override Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double) As Byte
    ' ���� ���� ������ ����Ǳ� �� �Էµ� overrideposition���� �ּ� ��� �޽�(dec_pulse) �̻��� ��� override ������ �Ѵ�.
    Public Declare Function CFS20position_override2 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal overrideposition As Double, ByVal dec_pulse As Double) As Byte
    ' ���� �࿡ ����/���� ���� ������ ������ ���������� �ӵ� override ������ �Ѵ�.
    Public Declare Function CFS20velocity_override2 Lib "AxtLib.dll" (ByVal axis As Integer, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal jerk As Double) As Byte

    ' ���� ���� Ȯ��-====================================================================================================
    ' ���� ���� ������ ����� ������ ��ٸ� �� �Լ��� �����.
    Public Declare Function CFS20wait_for_done Lib "AxtLib.dll" (ByVal axis As Integer) As Integer

    ' ���� ���� ����-====================================================================================================
    ' ���� ���� �������Ѵ�.
    Public Declare Function CFS20set_e_stop Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� ������ �������� �����Ѵ�.
    Public Declare Function CFS20set_stop Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� ���� �Էµ� �������� �����Ѵ�.
    Public Declare Function CFS20set_stop_decel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal deceleration As Double) As Byte
    ' ���� ���� �Էµ� ���� �ð����� �����Ѵ�.
    Public Declare Function CFS20set_stop_deceltime Lib "AxtLib.dll" (ByVal axis As Integer, ByVal deceltime As Double) As Byte

    ' ���� ���� �������� ����-==========================================================================================
    ' Master/Slave link �Ǵ� ��ǥ�� link ���� �ϳ��� ����Ͽ��� �Ѵ�.
    ' Master/Slave link ����. (�Ϲ� ���� ������ master �� ������ slave�൵ ���� �����ȴ�.)
    Public Declare Function CFS20link Lib "AxtLib.dll" (ByVal master As Integer, ByVal slave As Integer, ByVal ratio As Double) As Byte
    ' Master/Slave link ����
    Public Declare Function CFS20endlink Lib "AxtLib.dll" (ByVal slave As Integer) As Byte

    ' ��ǥ�� link ����-================================================================================================
    ' ���� ��ǥ�迡 �� �Ҵ� - n_axes������ŭ�� ����� ����/Ȯ���Ѵ�.(coordinate�� 1..8���� ��� ����)
    ' n_axes ������ŭ�� ����� ����/Ȯ���Ѵ�. - (n_axes�� 1..4���� ��� ����)
    Public Declare Function CFS20map_axes Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal n_axes As Integer, ByRef map_array As Integer) As Byte
    Public Declare Function CFS20get_mapped_axes Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal n_axes As Integer, ByRef map_array As Integer) As Byte
    ' ���� ��ǥ���� ���/���� ��� ����/Ȯ���Ѵ�.
    ' mode:
    ' 0: �����ǥ����, 1: ������ǥ ����
    Public Declare Sub CFS20set_coordinate_mode Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal mode As Integer)
    Public Declare Function CFS20get_coordinate_mode Lib "AxtLib.dll" (ByVal coordinate As Integer) As Integer
    ' ���� ��ǥ���� �ӵ� �������� ����/Ȯ���Ѵ�.
    ' mode:
    ' 0: ��ٸ��� ����, 1: SĿ�� ����
    Public Declare Sub CFS20set_move_profile Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal mode As Integer)
    Public Declare Function CFS20get_move_profile Lib "AxtLib.dll" (ByVal coordinate As Integer) As Integer
    ' ���� ��ǥ���� �ʱ� �ӵ��� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_move_startstop_velocity Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal velocity As Double)
    Public Declare Function CFS20get_move_startstop_velocity Lib "AxtLib.dll" (ByVal coordinate As Integer) As Double
    ' Ư�� ��ǥ���� �ӵ��� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_move_velocity Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal velocity As Double)
    Public Declare Function CFS20get_move_velocity Lib "AxtLib.dll" (ByVal coordinate As Integer) As Double
    ' Ư�� ��ǥ���� �������� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_move_acceleration Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal acceleration As Double)
    Public Declare Function CFS20get_move_acceleration Lib "AxtLib.dll" (ByVal coordinate As Integer) As Double
    ' Ư�� ��ǥ���� ���� �ð�(Sec)�� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_move_acceltime Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal acceltime As Double)
    Public Declare Function CFS20get_move_acceltime Lib "AxtLib.dll" (ByVal coordinate As Integer) As Double
    ' ���� ��������  ��ǥ���� ���� �����ӵ��� ��ȯ�Ѵ�.
    Public Declare Function CFS20co_get_velocity Lib "AxtLib.dll" (ByVal coordinate As Integer) As Double

    ' ����Ʈ���� ���� ����(���� ��ǥ�迡 ���Ͽ�)-========================================================================
    ' Blocking�Լ� (������� �޽� ����� �Ϸ�� �� �Ѿ��)
    ' 2, 3, 4���� �����̵��Ѵ�.
    Public Declare Function CFS20move_2 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double) As Byte
    Public Declare Function CFS20move_3 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double) As Byte
    Public Declare Function CFS20move_4 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal w As Double) As Byte
    ' Non Blocking�Լ� (�������� ��� ���õ�)
    ' 2, 3, 4���� ���� �̵��Ѵ�.
    Public Declare Function CFS20start_move_2 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double) As Byte
    Public Declare Function CFS20start_move_3 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double) As Byte
    Public Declare Function CFS20start_move_4 Lib "AxtLib.dll" (ByVal coordinate As Integer, ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal w As Double) As Byte
    ' ���� ��ǥ���� ������� ��� �Ϸ� üũ    
    Public Declare Function CFS20co_motion_done Lib "AxtLib.dll" (ByVal coordinate As Integer) As Byte
    ' ���� ��ǥ���� ������ �Ϸ�ɶ� ���� ��ٸ���.
    Public Declare Function CFS20co_wait_for_done Lib "AxtLib.dll" (ByVal coordinate As Integer) As Byte

    ' ���� ����(���� ����) : Master/Slave�� link�Ǿ� ���� ��� ������ �߻� �� �� �ִ�.-==================================
    ' ���� ����� ���� �Ÿ� �� �ӵ� ���ӵ� ������ ���� ���� �����Ѵ�. ���� ���ۿ� ���� ����ȭ�� ����Ѵ�. 
    ' start_** : ���� �࿡�� ���� ������ �Լ��� return�Ѵ�. "start_*" �� ������ �̵� �Ϸ��� return�Ѵ�.
    ' *r*_*    : ���� �࿡�� �Էµ� �Ÿ���ŭ(�����ǥ)�� �̵��Ѵ�. "*r_*�� ������ �Էµ� ��ġ(������ǥ)�� �̵��Ѵ�.
    ' *s*_*    : ������ �ӵ� ���������� "S curve"�� �̿��Ѵ�. "*s_*"�� ���ٸ� ��ٸ��� �������� �̿��Ѵ�.
    ' *_ex     : ������ �����ӵ��� ���� �Ǵ� ���� �ð����� �Է� �޴´�. "*_ex"�� ���ٸ� �����ӷ��� �Է� �޴´�.

    ' ���� �����޽�(Pulse Drive)����, ��ٸ��� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    Public Declare Function CFS20r_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20r_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    ' Non Blocking�Լ� (�������� ���� ���õ�)
    Public Declare Function CFS20start_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20start_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    Public Declare Function CFS20start_r_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20start_r_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    ' ���� �����޽�(Pulse Drive)����, S���� ����, ����/�����ǥ(r), ������/���ӽð�(_ex)(�ð�����:Sec)
    ' Blocking�Լ� (������� ��� �������� �޽� ����� �Ϸ�� �� �Ѿ��)
    Public Declare Function CFS20s_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20s_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    Public Declare Function CFS20rs_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20rs_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    ' Non Blocking�Լ� (�������� ���� ���õ�)
    Public Declare Function CFS20start_s_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20start_s_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef positions As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    Public Declare Function CFS20start_rs_move_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef accelerations As Double) As Byte
    Public Declare Function CFS20start_rs_move_all_ex Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef distances As Double, ByRef velocities As Double, ByRef acceltimes As Double) As Byte
    '���� ��鿡 ���Ͽ� S���� ������ ���� �����ӽ��� SĿ���� ������ ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_s_rate_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef a_percent As Double, ByRef b_percent As Double)
    Public Declare Sub CFS20get_s_rate_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef a_percent As Double, ByRef b_percent As Double)

    ' ���� ���� Ȯ��-====================================================================================================
    ' �Է� �ش� ����� ���� ���¸� Ȯ���ϰ� ������ ���� �� ���� ��ٸ���.
    Public Declare Function CFS20wait_for_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer) As Byte

    ' ���� ���� ����-====================================================================================================
    ' ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    Public Declare Function CFS20reset_axis_sync Lib "AxtLib.dll" (ByVal nLen As Integer, ByRef aAxis As Integer) As Byte
    ' ���� ����� ���⸦ ������Ų��. - ��������� �������� ���������ʰ� �����.
    Public Declare Function CFS20set_axis_sync Lib "AxtLib.dll" (ByVal nLen As Integer, ByRef aAxis As Integer) As Byte
    ' ������ ���� ���� ����/����/Ȯ���Ѵ�.
    ' sync:
    ' 0: Reset - ���� �������� ����.
    ' 1: Set	- ���� ������.
    Public Declare Function CFS20set_sync_axis Lib "AxtLib.dll" (ByVal axis As Integer, ByVal sync As Byte) As Byte
    Public Declare Function CFS20get_sync_axis Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ������ ����� ���� ���� ����/����/Ȯ���Ѵ�.
    ' sync:
    ' 0: Reset - ���� �������� ����.
    ' 1: Set	- ���� ������.	
    Public Declare Function CFS20set_sync_module Lib "AxtLib.dll" (ByVal axis As Integer, ByVal sync As Byte) As Byte
    Public Declare Function CFS20get_sync_module Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ���� ���� ����-====================================================================================================
    ' Ȩ ��ġ �����嵵 ����
    Public Declare Function CFS20emergency_stop Lib "AxtLib.dll" () As Byte

    ' -�����˻� =========================================================================================================
    ' ���̺귯�� �󿡼� Thread�� ����Ͽ� �˻��Ѵ�. ���� : ������ Ĩ���� StartStop Speed�� ���� �� �ִ�.
    ' �����˻��� �����Ѵ�.
    ' bStop:
    ' 0: ��������
    ' 1: ������
    Public Declare Function CFS20abort_home_search Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bStop As Byte) As Byte
    ' �����˻��� �����Ѵ�. �����ϱ� ���� �����˻��� �ʿ��� ������ �ʿ��ϴ�.
    Public Declare Function CFS20home_search Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �Է� ����� ���ÿ� �����˻��� �ǽ��Ѵ�.
    Public Declare Function CFS20home_search_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer) As Byte
    ' �����˻� ���� �������� Ȯ���Ѵ�.
    Public Declare Function CFS20get_home_done Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ��ȯ��: 0: �����˻� ������, 1: �����˻� ����
    ' �ش� ����� �����˻� ���� �������� Ȯ���Ѵ�.
    Public Declare Function CFS20get_home_done_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer) As Byte
    ' ���� ���� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    Public Declare Function CFS20get_home_end_status Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ��ȯ��: 0: �����˻� ����, 1: �����˻� ����
    ' ���� ����� ���� �˻� ������ ���� ���¸� Ȯ���Ѵ�.
    Public Declare Function CFS20get_home_end_status_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer, ByRef endstatus As Byte) As Byte
    ' ���� �˻��� �� ���ܸ��� method�� ����/Ȯ���Ѵ�.
    ' Method�� ���� ���� 
    '    0 Bit ���� ��뿩�� ���� (0 : ������� ����, 1: �����
    '    1 Bit ������ ��� ���� (0 : ������, 1 : ���� �ð�)
    '    2 Bit ������� ���� (0 : ���� ����, 1 : �� ����)
    '    3 Bit �˻����� ���� (0 : cww(-), 1 : cw(+))
    ' 7654 Bit detect signal ����(typedef : DETECT_DESTINATION_SIGNAL)
    Public Declare Function CFS20set_home_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef method As Byte) As Byte
    Public Declare Function CFS20get_home_method Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef method As Byte) As Byte
    ' ���� �˻��� �� ���ܸ��� offset�� ����/Ȯ���Ѵ�.	
    Public Declare Function CFS20set_home_offset Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef offset As Double) As Byte
    Public Declare Function CFS20get_home_offset Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef offset As Double) As Byte
    ' �� ���� ���� �˻� �ӵ��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_home_velocity Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef velocity As Double) As Byte
    Public Declare Function CFS20get_home_velocity Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef velocity As Double) As Byte
    ' ���� ���� ���� �˻� �� �� ���ܺ� �������� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_home_acceleration Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef acceleration As Double) As Byte
    Public Declare Function CFS20get_home_acceleration Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef acceleration As Double) As Byte
    ' ���� ���� ���� �˻� �� �� ���ܺ� ���� �ð��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_home_acceltime Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef acceltime As Double) As Byte
    Public Declare Function CFS20get_home_acceltime Lib "AxtLib.dll" (ByVal axis As Integer, ByVal nstep As Integer, ByRef acceltime As Double) As Byte
    ' ���� �࿡ ���� �˻����� ���ڴ� 'Z'�� ���� ��� �� ���� �Ѱ谪�� ����/Ȯ���Ѵ�.(Pulse) - ������ ����� �˻� ����
    Public Declare Function CFS20set_zphase_search_range Lib "AxtLib.dll" (ByVal axis As Integer, ByVal pulses As Integer) As Byte
    Public Declare Function CFS20get_zphase_search_range Lib "AxtLib.dll" (ByVal axis As Integer) As Integer
    ' ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������̸� ���õ�.
    Public Declare Function CFS20home_zero Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ������ ��� ���� ���� ��ġ�� ����(0 Position)���� �����Ѵ�. - �������� ���� ���õ�
    Public Declare Function CFS20home_zero_all Lib "AxtLib.dll" (ByVal number As Integer, ByRef axes As Integer) As Byte

    ' ���� �����-=======================================================================================================
    ' ���� ���
    ' 0 bit : ���� ��� 0(Servo-On)
    ' 1 bit : ���� ��� 1(ALARM Clear)
    ' 2 bit : ���� ��� 2
    ' 3 bit : ���� ��� 3
    ' 4 bit(PLD) : ���� ��� 4
    ' 5 bit(PLD) : ���� ��� 5
    ' ���� �Է�
    ' 0 bit : ���� �Է� 0(ORiginal Sensor)
    ' 1 bit : ���� �Է� 1(Z phase)
    ' 2 bit : ���� �Է� 2
    ' 3 bit : ���� �Է� 3
    ' 4 bit(PLD) : ���� �Է� 5
    ' 5 bit(PLD) : ���� �Է� 6
    ' On ==> ���ڴ� N24V, 'Off' ==> ���ڴ� Open(float).	

    ' ���� ���� ��°��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_output Lib "AxtLib.dll" (ByVal axis As Integer, ByVal value As Byte) As Byte
    Public Declare Function CFS20get_output Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �Է� ���� Ȯ���Ѵ�.
    ' '1'('On') <== ���ڴ� N24V�� �����, '0'('Off') <== ���ڴ� P24V �Ǵ� Float.
    Public Declare Function CFS20get_input Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� �ش� bit�� ����� On/Off ��Ų��.
    ' bitNo : 0 ~ 5.
    Public Declare Function CFS20set_output_bit Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bitNo As Byte) As Byte
    Public Declare Function CFS20reset_output_bit Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bitNo As Byte) As Byte
    ' �ش� ���� �ش� ���� ��� bit�� ��� ���¸� Ȯ���Ѵ�.
    ' bitNo : 0 ~ 5.
    Public Declare Function CFS20output_bit_on Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bitNo As Byte) As Byte
    ' �ش� ���� �ش� ���� ��� bit�� ���¸� �Է� state�� �ٲ۴�.
    ' bitNo : 0 ~ 5. 
    Public Declare Function CFS20change_output_bit Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bitNo As Byte, ByVal state As Byte) As Byte
    ' �ش� ���� �ش� ���� �Է� bit�� ���¸� Ȯ�� �Ѵ�.
    ' bitNo : 0 ~ 5.
    Public Declare Function CFS20input_bit_on Lib "AxtLib.dll" (ByVal axis As Integer, ByVal bitNo As Byte) As Byte
    ' ���� �Է�(Universal input) 4 ��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_ui4_mode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal state As Byte) As Byte
    Public Declare Function CFS20get_ui4_mode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �Է�(Universal input) 5 ��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_ui5_mode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal state As Byte) As Byte
    Public Declare Function CFS20get_ui5_mode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' �ܿ� �޽� clear-===================================================================================================
    ' �ش� ���� ������ �ܿ� �޽� Clear ����� ��� ���θ� ����/Ȯ���Ѵ�.
    ' CLR ��ȣ�� Default ��� ==> ���ڴ� Open�̴�.
    Public Declare Function CFS20set_crc_mask Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mask As Integer) As Byte
    Public Declare Function CFS20get_crc_mask Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� �ܿ� �޽� Clear ����� Active level�� ����/Ȯ���Ѵ�.
    ' Default Active level ==> '1' ==> ���ڴ� N24V
    Public Declare Function CFS20set_crc_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Integer) As Byte
    Public Declare Function CFS20get_crc_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� -Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.    
    Public Declare Function CFS20set_crc_nelm_mask Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mask As Integer) As Byte
    Public Declare Function CFS20get_crc_nelm_mask Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� -Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.    
    Public Declare Function CFS20set_crc_nelm_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Integer) As Byte
    Public Declare Function CFS20get_crc_nelm_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� +Emeregency End limit�� ���� Clear��� ��� ������ ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_crc_pelm_mask Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mask As Integer) As Byte
    Public Declare Function CFS20get_crc_pelm_mask Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� +Emeregency End limit�� Active level�� ����/Ȯ���Ѵ�. set_nend_limit_level�� �����ϰ� �����Ѵ�.
    Public Declare Function CFS20set_crc_pelm_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Integer) As Byte
    Public Declare Function CFS20get_crc_pelm_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' �ش� ���� �ܿ� �޽� Clear ����� �Է� ������ ���� ���/Ȯ���Ѵ�.
    Public Declare Function CFS20set_programmed_crc Lib "AxtLib.dll" (ByVal axis As Integer, ByVal data As Integer) As Byte
    Public Declare Function CFS20get_programmed_crc Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' Ʈ���� ��� ======================================================================================================
    ' ����/�ܺ� ��ġ�� ���Ͽ� �ֱ�/���� ��ġ���� ������ Active level�� Trigger pulse�� �߻� ��Ų��.
    ' Ʈ���� ��� �޽��� Active level�� ����/Ȯ���Ѵ�.
    ' ('0' : 5V ���(0 V), 24V �͹̳� ���(Open); '1'(default) : 5V ���(5 V), 24V �͹̳� ���(N24V).
    Public Declare Function CFS20set_trigger_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal trigger_level As Byte) As Byte
    Public Declare Function CFS20get_trigger_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' Ʈ���� ��ɿ� ����� ���� ��ġ�� �����Ѵ�.
    ' 0x0 : �ܺ� ��ġ External(Actual)
    ' 0x1 : ���� ��ġ Internal(Command)
    Public Declare Function CFS20set_trigger_sel Lib "AxtLib.dll" (ByVal axis As Integer, ByVal trigger_sel As Byte) As Byte
    Public Declare Function CFS20get_trigger_sel Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' time
    ' 0x00 : 4 msec(Ĩ ��� Bypass)
    ' 0x01 : 8msec
    ' 0x02 : 16msec
    ' 0x03	: 24msec
    ' ~
    ' 0x0A: 80msec
    ' 0x0B: 88msec
    ' ~
    ' 0x0F: 120msec
    Public Declare Function CFS20set_trigger_time Lib "AxtLib.dll" (ByVal axis As Integer, ByVal a_time As Byte) As Byte
    Public Declare Function CFS20get_trigger_time Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ Ʈ���� �߻� ����� ����/Ȯ���Ѵ�.
    ' 0x0 : Ʈ���� ���� ��ġ���� Ʈ���� �߻�, ���� ��ġ ���
    ' 0x1 : Ʈ���� ��ġ���� ����� �ֱ� Ʈ���� ���
    Public Declare Function CFS20set_trigger_mode Lib "AxtLib.dll" (ByVal axis As Integer, ByVal mode_sel As Byte) As Byte
    Public Declare Function CFS20get_trigger_mode Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ Ʈ���� �ֱ� �Ǵ� ���� ��ġ ���� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_trigger_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal trigger_position As Double) As Byte
    Public Declare Function CFS20get_trigger_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' ���� ���� Ʈ���� ����� ��� ���θ� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_trigger_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal ena_status As Byte) As Byte
    Public Declare Function CFS20is_trigger_enabled Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    ' ���� �࿡ Ʈ���� �߻��� ���ͷ�Ʈ�� �߻��ϵ��� ����/Ȯ���Ѵ�.
    Public Declare Function CFS20set_trigger_interrupt_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal ena_int As Byte) As Byte
    Public Declare Function CFS20is_trigger_interrupt_enabled Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' MARK ����̺� �����Լ� ===========================================================================================
    ' MARK, �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
    Public Declare Function CFS20start_pr_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Byte
    Public Declare Function CFS20start_pr_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Byte
    ' MARK, ���Ī �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec)
    Public Declare Function CFS20start_pra_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Byte
    Public Declare Function CFS20start_pra_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Byte
    ' �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    Public Declare Function CFS20pr_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Integer
    Public Declare Function CFS20pr_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Integer
    ' MARK, ���Ī �����޽�(Pulse Drive) ��ٸ��� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    Public Declare Function CFS20pra_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Integer
    Public Declare Function CFS20pra_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Integer
    ' MARK, �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec)
    Public Declare Function CFS20start_prs_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Byte
    Public Declare Function CFS20start_prs_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Byte
    ' MARK, ���Ī �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec)
    Public Declare Function CFS20start_pras_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Byte
    Public Declare Function CFS20start_pras_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Byte
    ' MARK, �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    Public Declare Function CFS20prs_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal drive As Byte) As Integer
    Public Declare Function CFS20prs_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal drive As Byte) As Integer
    ' MARK, ���Ī �����޽�(Pulse Drive) S���� ����, �����ǥ, ������/���ӽð�(Sec). ������ �Ϸ�ɶ����� ���
    Public Declare Function CFS20pras_move Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceleration As Double, ByVal deceleration As Double, ByVal drive As Byte) As Integer
    Public Declare Function CFS20pras_move_ex Lib "AxtLib.dll" (ByVal axis As Integer, ByVal distance As Double, ByVal velocity As Double, ByVal acceltime As Double, ByVal deceltime As Double, ByVal drive As Byte) As Integer
    ' MARK Signal�� Active level�� ����/Ȯ��/����Ȯ���Ѵ�.
    Public Declare Function CFS20set_mark_signal_level Lib "AxtLib.dll" (ByVal axis As Integer, ByVal level As Byte) As Byte
    Public Declare Function CFS20get_mark_signal_level Lib "AxtLib.dll" (ByVal axis As Integer) As Byte
    Public Declare Function CFS20get_mark_signal_switch Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    Public Declare Function CFS20set_mark_signal_enable Lib "AxtLib.dll" (ByVal axis As Integer, ByVal use As Byte) As Byte
    Public Declare Function CFS20get_mark_signal_enable Lib "AxtLib.dll" (ByVal axis As Integer) As Byte

    ' ��ġ �񱳱� ���� �Լ��� ==========================================================================================
    ' Internal(Command) comparator���� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_internal_comparator_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_internal_comparator_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double
    ' External(Encoder) comparator���� ����/Ȯ���Ѵ�.
    Public Declare Sub CFS20set_external_comparator_position Lib "AxtLib.dll" (ByVal axis As Integer, ByVal position As Double)
    Public Declare Function CFS20get_external_comparator_position Lib "AxtLib.dll" (ByVal axis As Integer) As Double

    ' �����ڵ� �б� �Լ��� =============================================================================================
    ' ������ �����ڵ带 �д´�.
    Public Declare Function CFS20get_error_code Lib "AxtLib.dll" () As Integer
    ' �����ڵ��� ������ ���ڷ� ��ȯ�Ѵ�.
    Public Declare Function CFS20get_error_msg Lib "AxtLib.dll" (ByVal ErrorCode As Integer) As String


End Module
