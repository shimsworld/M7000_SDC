Imports System.Threading

Public Class CDevMotion_AJIN
    Public LogoMsg As String = "Montion Control"
    Public HomeVel() As Double = {8000, 3000, 1000, 1000, 1000, 1000, 1000, 1000, 1000} 'Homing �� �� �� �ӵ�

    Private bIsConnected As Boolean = False

    Dim m_CalDataRealDistance_X As Double
    Dim m_CalDataRealDistance_Y As Double
    Dim m_CalDataRealDistance_Z As Double
    Dim m_CalDataRealDistance_Theta As Double
    Shared sSupportDeviceList() As String = New String() {"None", "AJIN"}

    Dim m_CalDataRealDistanceUse As Boolean
    Dim m_Distance() As Double

    'Theta Factor -20170413
    Dim m_CalDataDeviation_Theta As Double 'Theta Home Position Deviation
    Dim m_CalDataRatio_Theta As Double 'Theta Pulse Ratio (Rotation Cal. ?? Factor)
    Dim m_CalDataOffset_Theta As Double 'Theta Pulse Offset (Rotation Cal. ?? Factor)

    Dim myParent As frmMain

#Region "Define"

    Dim m_MotionSettins() As sMotionParams
    'Dim m_nXAxisSettingIndex As Integer = 0
    'Dim m_nYAxisSettingIndex As Integer = 1
    'Dim m_nZAxisSettingIndex As Integer = 2
    'Dim m_nThetaAxisSettingIndex As Integer = 3

    Dim m_nYAxisIndex As Integer = 0
    Dim m_nZAxisIndex As Integer = 1
    Dim m_nThetaAxisIndex As Integer = 2
    Dim m_nTheta2AxisIndex As Integer = 3
    Dim m_nTheta3AxisIndex As Integer = 4
    Dim m_nTheta4AxisIndex As Integer = 5
    Dim m_nXAxisIndex As Integer = 6
    'dim m_nTheta5AxisIndex As Integer = 7


    Public Structure sMotionParams
        Dim ePulseOutMethod As ePulseOutMethod
        Dim eMotionAxis As eMotionAxis
        Dim eRealMotionAxis As eMotionAxis
        Dim eMotionAxisInverting As eMotionAxis
        Dim eEncInputMethod As eEncoderInputMethod
        Dim dVelocity As Double   '���� ���
        Dim dAcceleration As Double
        Dim dDeceleration As Double
        Dim dMaxSpeed As Double
        Dim dStartSpeed As Double  '�ະ ���� ����
        Dim dUnitPulse As Double
        Dim bDirectionInverting As Boolean   '���� ����
        Dim bSyncControl As Boolean  '���� ����
        Dim dHomeSpeed As Double
        Dim dHomeSerchFixDistance As Double
        Dim nIO_Limit_P As eSTATE
        Dim nIO_Limit_M As eSTATE
        Dim nIO_SLimit_P As eSTATE
        Dim nIO_SLimit_M As eSTATE
        Dim nIO_Alarm As eSTATE
    End Structure

    Public Enum ePulseOutMethod
        eOneHighLowHigh = 0
        eOneHighHighLow
        eOneLowLowHigh
        eOneLowHighLow
        eTwoCcwCwHigh
        eTwoCcwCwLow
        eTwoCwCcwHigh
        eTwoCwCcwLow
    End Enum

    Public Enum eEncoderInputMethod
        eUpDownMode = 0  'Up/Down
        eSqr1Mode           '1ü��
        eSqr2Mode           '2ü��
        eSqr4Mode           '3ü��
    End Enum

    Public Enum eMotionAxis
        eNot_Use
        eY_Axis 'Y��
        eZ_Axis 'Z��
        eTheta_Axis '����
        eTheta2_Axis
        eTheta3_Axis
        eTheta4_Axis
        eX_Axis 'X��
    End Enum

    Public Enum eSTATE
        _OFF
        _ON
    End Enum
#End Region


#Region "Propertys"

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property
    Public Property CalDataRealDistanceUse As Boolean

        Get
            Return m_CalDataRealDistanceUse
        End Get
        Set(ByVal value As Boolean)
            m_CalDataRealDistanceUse = value
        End Set
    End Property


    Public Property CalDataRealDistanceX As Double
        Get
            Return m_CalDataRealDistance_X
        End Get
        Set(ByVal value As Double)
            m_CalDataRealDistance_X = value
        End Set
    End Property

    Public Property CalDataRealDistanceY As Double
        Get
            Return m_CalDataRealDistance_Y
        End Get
        Set(ByVal value As Double)
            m_CalDataRealDistance_Y = value
        End Set
    End Property

    Public Property CalDataRealDistanceZ As Double
        Get
            Return m_CalDataRealDistance_Z
        End Get
        Set(ByVal value As Double)
            m_CalDataRealDistance_Z = value
        End Set
    End Property

    Public Property CalDataRealDistanceTheta As Double
        Get
            Return m_CalDataRealDistance_Theta
        End Get
        Set(ByVal value As Double)
            m_CalDataRealDistance_Theta = value
        End Set
    End Property

    Public Property CalDataDeviationTheta As Double
        Get
            Return m_CalDataDeviation_Theta
        End Get
        Set(ByVal value As Double)
            m_CalDataDeviation_Theta = value
        End Set
    End Property

    Public Property CalDataRatioTheta As Double
        Get
            Return m_CalDataRatio_Theta
        End Get
        Set(ByVal value As Double)
            m_CalDataRatio_Theta = value
        End Set
    End Property

    Public Property CalDataOffsetTheta As Double
        Get
            Return m_CalDataOffset_Theta
        End Get
        Set(ByVal value As Double)
            m_CalDataOffset_Theta = value
        End Set
    End Property

    Public Property Settings As sMotionParams()
        Get
            Return m_MotionSettins
        End Get
        Set(ByVal value As sMotionParams())
            m_MotionSettins = value
        End Set
    End Property

    Public Property MaxSpeed(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dMaxSpeed
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dMaxSpeed = Value
        End Set
    End Property

    Public Property MotionCtrlMode(ByVal idx As Integer) As eMotionAxis
        Get
            Return m_MotionSettins(idx).eMotionAxis
        End Get
        Set(ByVal Value As eMotionAxis)
            m_MotionSettins(idx).eMotionAxis = Value
        End Set
    End Property

    Public Property PulseOutMethod(ByVal idx As Integer) As ePulseOutMethod
        Get
            Return m_MotionSettins(idx).ePulseOutMethod
        End Get
        Set(ByVal Value As ePulseOutMethod)
            m_MotionSettins(idx).ePulseOutMethod = Value
        End Set
    End Property

    Public Property EncoderInputMethod(ByVal idx As Integer) As eEncoderInputMethod
        Get
            Return m_MotionSettins(idx).eEncInputMethod
        End Get
        Set(ByVal Value As eEncoderInputMethod)
            m_MotionSettins(idx).eEncInputMethod = Value
        End Set
    End Property

    Public Property Velocity(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dVelocity
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dVelocity = Value
        End Set
    End Property

    Public Property Acceleration(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dAcceleration
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dAcceleration = Value
        End Set
    End Property

    Public Property Deceleration(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dDeceleration
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dDeceleration = Value
        End Set
    End Property

    Public Property StartSpeed(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dStartSpeed
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dStartSpeed = Value
        End Set
    End Property

    Public Property UnitPulse(ByVal idx As Integer) As Double
        Get
            Return m_MotionSettins(idx).dUnitPulse
        End Get
        Set(ByVal Value As Double)
            m_MotionSettins(idx).dUnitPulse = Value
        End Set
    End Property

    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return bIsConnected
        End Get
    End Property


    Public ReadOnly Property RealDistance As Double()
        Get
            Return m_Distance
        End Get
    End Property

#End Region



#Region "Functions and Sub"



    Public Sub New(ByVal parent As frmMain, ByVal nTotAxisNumber As Integer)
        Dim motionSetting As sMotionParams
        ReDim m_MotionSettins(nTotAxisNumber)

        myParent = parent

        motionSetting.ePulseOutMethod = ePulseOutMethod.eTwoCwCcwLow
        motionSetting.eEncInputMethod = eEncoderInputMethod.eSqr4Mode
        motionSetting.dVelocity = 100
        motionSetting.dAcceleration = 350
        motionSetting.dDeceleration = 800
        motionSetting.dMaxSpeed = 10000
        motionSetting.dStartSpeed = 1
        motionSetting.dUnitPulse = 0.01

        m_CalDataRealDistance_X = 1
        m_CalDataRealDistance_Y = 1
        m_CalDataRealDistance_Z = 1
        m_CalDataRealDistance_Theta = 1

        '??? Factor
        m_CalDataDeviation_Theta = 0
        m_CalDataRatio_Theta = 1
        m_CalDataOffset_Theta = 0

        For i As Integer = 0 To m_MotionSettins.Length - 1
            m_MotionSettins(i) = motionSetting
            m_MotionSettins(i).eMotionAxis = i + 1
            m_MotionSettins(i).eMotionAxisInverting = i + 1
        Next

    End Sub

    'Motion Part
#Region "Motion Initialization"

    Public Function InitAxt() As Boolean

        bIsConnected = False
        ''Log & Status Bar *****************************
        'LogWrite("InitAxt")
        'frmMain.MsgStatusBarPanel.Text = "Library ,PCI, CAMC-IP Initialization."
        ''**********************************************
        ' ## ���� ���̺귯�� �� ��� �ʱ�ȭ �κ� ##
        If (AxtIsInitialized = False) Then                        ' ���� ���̺귯���� ��� �������� (�ʱ�ȭ�� �Ǿ�����) Ȯ��
            If (AxtInitialize(Nothing, -1) = False) Then  ' ���� ���̺귯�� �ʱ�ȭ
                MsgBox("Can not Library Initialize!!", MsgBoxStyle.Critical, LogoMsg)
                Return False
            End If
        End If

        If (AxtIsInitializedBus(BUSTYPE_PCI) = False) Then       ' ������ ����(PCI)�� �ʱ�ȭ �Ǿ����� Ȯ��
            ' ������ ISA �ϰ�� BUSTYPE_PCI -> BUSTYPE_ISA ����
            If (AxtOpenDeviceAuto(BUSTYPE_PCI) = False) Then     ' ���ο� ���̽����带 �ڵ����� ���ն��̺귯���� �߰�
                MsgBox("Can not Baseboard Initialize!!", MsgBoxStyle.Critical, LogoMsg)
                Return False
            End If
        End If

        If (CFS20IsInitialized() = False) Then                     ' CAMC-IP����� ����� �� �ֵ��� ���̺귯���� �ʱ�ȭ�Ǿ����� Ȯ��
            If (InitializeCAMCFS20(True) = False) Then             ' CAMC-IP����� �ʱ�ȭ(�����ִ� ��纣�̽����忡�� IP����� �˻��Ͽ� �ʱ�ȭ)
                MsgBox("Can not FS-20 Module Initialize!!", MsgBoxStyle.Critical, LogoMsg)
                Return False
            End If
        End If

        bIsConnected = True
        Return True
    End Function

    Public Sub initMotion()
        Dim rebyte As Byte = Nothing
        ''Log & Status Bar *****************************
        ''LogWrite("inixMotion")
        ''frmMain.MsgStatusBarPanel.Text = "All Axis Output Method and Encoder Method Set"
        ''**********************************************
        '���� �޽� ��¹�İ� ���ڴ� ��� ����
        cbopulseout_Validating()
        cboencinput_Validating()

     
    End Sub


    ''' <summary>
    ''' �ʱ� �ӵ� ���� �� ����
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitVariableSet()
        ''Log & Status Bar *****************************
        ''LogWrite("InitVariableSet")
        ''frmMain.MsgStatusBarPanel.Text = "Moveunit Purpulse and Startstop Speed Set."
        ''**********************************************
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next

        ' setMaxSpeed()

        Dim retbyte As Byte = Nothing

        For cnt_axis = 0 To nNumAxis - 1
            CFS20set_moveunit_perpulse(cnt_axis, m_MotionSettins(cnt_axis).dUnitPulse)  ' �����࿡ �޽��� �����̴� �Ÿ��� �����Ѵ�. 
            CFS20set_startstop_speed(cnt_axis, m_MotionSettins(cnt_axis).dStartSpeed)    ' �����࿡ �ʱ� �ӵ��� �����Ѵ�.

            'I/O Limit(+)(-)
            retbyte = CFS20get_pend_limit_level(cnt_axis)
            If retbyte <> m_MotionSettins(cnt_axis).nIO_Limit_P Then
                CFS20set_pend_limit_level(cnt_axis, CByte(m_MotionSettins(cnt_axis).nIO_Limit_P))
            End If

            retbyte = CFS20get_nend_limit_level(cnt_axis)
            If retbyte <> m_MotionSettins(cnt_axis).nIO_Limit_M Then
                CFS20set_nend_limit_level(cnt_axis, CByte(m_MotionSettins(cnt_axis).nIO_Limit_M))
            End If

            'I/O Slow Limit(+)(-) 
            retbyte = CFS20get_pslow_limit_level(cnt_axis)
            If retbyte <> m_MotionSettins(cnt_axis).nIO_SLimit_P Then
                CFS20set_pslow_limit_level(cnt_axis, CByte(m_MotionSettins(cnt_axis).nIO_SLimit_P))
            End If

            retbyte = CFS20get_nslow_limit_level(cnt_axis)
            If retbyte <> m_MotionSettins(cnt_axis).nIO_SLimit_M Then
                CFS20set_nslow_limit_level(cnt_axis, CByte(m_MotionSettins(cnt_axis).nIO_SLimit_M))
            End If

            'I/O Alarm
            retbyte = CFS20get_alarm_level(cnt_axis)
            If retbyte <> m_MotionSettins(cnt_axis).nIO_Alarm Then
                CFS20set_alarm_level(cnt_axis, CByte(m_MotionSettins(cnt_axis).nIO_Alarm))
            End If

        Next
        '��� Max Speed ���� 

        setMaxSpeed()
    End Sub

    ' �޽� ��� ����� �����Ѵ�.
    Private Sub cbopulseout_Validating()
        Dim retbyte As Byte = Nothing
        ''Dim Cancel As Boolean = eventArgs.Cancel

        ''Log & Status Bar *****************************
        ''LogWrite("cbopulseout_Validating")
        ''frmMain.MsgStatusBarPanel.Text = "Pulse Output Method Set."
        ''**********************************************
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next

        For cnt_axis = 0 To nNumAxis - 1
            retbyte = CFS20set_pulse_out_method(cnt_axis, m_MotionSettins(cnt_axis).ePulseOutMethod)  ' TwoCwCcwHigh�� ����
        Next

    End Sub

    ' ���ڴ� �Է� ����� �����ϴ� �޺� �ڽ��̴�.
    Private Sub cboencinput_Validating()
        ''Dim Cancel As Boolean = eventArgs.Cancel

        ''Log & Status Bar *****************************
        ''LogWrite("cbopulseout_Validating")
        ''frmMain.MsgStatusBarPanel.Text = "Encoder Output Method Set."
        ''**********************************************
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next


        For cnt_axis = 0 To nNumAxis - 1
            CFS20set_enc_input_method(cnt_axis, m_MotionSettins(cnt_axis).eEncInputMethod)   '4ä��
        Next

    End Sub

#End Region


#Region "Servo ON/OFF"
    Public Sub SERVO_ON()
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length
        '   Dim byRst(nNumAxis - 1) As Byte
        '   Dim retBit() As Integer


        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next

        For cnt_axis = 0 To nNumAxis - 1

            'Alarm Clear
            CFS20set_output_bit(cnt_axis, 1)

            'Alarm Reset
            CFS20reset_output_bit(cnt_axis, 1)

            'Servo On
            CFS20set_output_bit(cnt_axis, 0)
        Next

    End Sub

    Public Sub SERVO_OFF()
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next

        For cnt_axis = 0 To nNumAxis - 1
            CFS20reset_output_bit(cnt_axis, 0)
        Next

    End Sub

#End Region

#Region "Homing"


    Public Sub TestFunc()

        'Dim byRst() As Byte
        'Dim nNumAxis As Integer = m_MotionSettins.Length
        'ReDim byRst(nNumAxis - 1)
        'Dim retBit() As Integer

        'For i As Integer = 0 To nNumAxis - 1
        '    byRst(i) = CFS20get_input(i)
        '    retBit = CDevPLC.DecToBinery(Convert.ToInt16(byRst(i)))

        '    'Bit 0 : ORG  , 0: OFF, 1 : ON
        '    'Bit 1 : Z Phase
        '    If retBit(0) = 1 Then

        '    End If
        'Next

        For i As Integer = 0 To m_MotionSettins.Length - 1
            CFS20set_moveunit_perpulse(i, m_MotionSettins(i).dUnitPulse)
            CFS20set_startstop_speed(i, m_MotionSettins(i).dVelocity)
            CFS20set_max_speed(i, CFS20get_max_speed(i))
        Next




    End Sub

    Public Sub Link()

        For i As Integer = 0 To m_MotionSettins.Length - 1
            If m_MotionSettins(i).bSyncControl = True Then
                CFS20link(i, i + 1, 1)
                Exit For
            End If

        Next
    End Sub

    Public Sub EndLink()

        For i As Integer = 0 To m_MotionSettins.Length - 1
            If m_MotionSettins(i).bSyncControl = True Then
                CFS20endlink(i + 1)
                Exit For
            End If

        Next

    End Sub

    Public Sub Homming(Optional ByVal bSerchHomePosition As Boolean = True)
        ''Log & Status Bar *****************************
        ''LogWrite("Homming")
        ''frmMain.MsgStatusBarPanel.Text = "Homming Set"
        ''**********************************************
        Dim IN0_UPEDGE As Byte
        Dim IN0_DNEDGE As Byte
        Dim IN1_UPEDGE As Byte
        Dim IN1_DNEDGE As Byte
        Dim DIR_CW As Byte = &H8S
        Dim DIR_CCW As Byte = &H0S
        Dim STOP_EMG As Byte
        Dim USE_STEP As Byte
        Dim HOME_STEP As Short
        Dim HOME_BIT As Short
        Dim Methods(m_MotionSettins.Length - 1) As Byte
        Dim velocities(m_MotionSettins.Length - 1) As Double
        Dim accelerations(m_MotionSettins.Length - 1) As Double
        Dim byRst() As Byte
        Dim Dir(m_MotionSettins.Length - 1) As Boolean
        Dim Sync(m_MotionSettins.Length - 1) As Boolean
        Dim dStandardPositionHomeSerch(m_MotionSettins.Length - 1) As Double
        ' Dim axes() As Short
        Dim nNumAxis As Integer = m_MotionSettins.Length



        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Exit Sub
        'End If

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next

        IN0_UPEDGE = &HC   'ORG ��¿���
        IN0_DNEDGE = &H4   'ORG �ϰ�����
        IN1_UPEDGE = &HD   'Z�� ��¿���
        IN1_DNEDGE = &H5   'Z�� �ϰ�����

        '   DIR_CW = &H8S    '�˻����� cw(+)�� ����
        STOP_EMG = &H4  '
        USE_STEP = &H1S

        HOME_STEP = 4
        HOME_BIT = &H0S

        ' �����˻��� �༳���ϱ�'

        For i As Integer = 0 To nNumAxis - 1
            Methods(i) = IN0_UPEDGE Or STOP_EMG 'Or DIR_CCW
        Next
        '    Methods(0) = IN0_UPEDGE Or STOP_EMG 'Or DIR_CCW
        '  Methods(1) = IN0_UPEDGE Or STOP_EMG 'Or DIR_CW
        '   Methods(2) = IN0_UPEDGE Or STOP_EMG 'Or DIR_CCW
        '  Methods(3) = IN0_UPEDGE Or STOP_EMG 'Or DIR_CCW

        'True : CW, False : CCW 

        '   Dir(0) = True '
        '  Dir(1) = True '
        '  Dir(2) = True

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).ePulseOutMethod = ePulseOutMethod.eTwoCcwCwHigh Then
                Dir(i) = False
            ElseIf m_MotionSettins(i).ePulseOutMethod = ePulseOutMethod.eTwoCwCcwHigh Then
                Dir(i) = True '
            ElseIf m_MotionSettins(i).ePulseOutMethod = ePulseOutMethod.eTwoCwCcwLow Then
                Dir(i) = False
            End If
            dStandardPositionHomeSerch(i) = m_MotionSettins(i).dHomeSerchFixDistance
        Next


        Dim retBit() As Integer
        ReDim byRst(nNumAxis - 1)


        'Home ��ġ�� ã���� ������ �Ÿ����� ã�� ���ؼ�... �� ó�� Home�� ã�� �ʾƼ� 2��° Home ã�� �� ���� �����ϰ� ��.��� ���� �� ã�� Home�� �� ó����
        If bSerchHomePosition = True Then
            ' myParent.cMotion.XMove(20, True)
            ' myParent.cMotion.YMove(20, True)
            ' myParent.cMotion.ZMove(10, True)

            '�̵� �� home �ӵ� ����
            For i = 0 To nNumAxis - 1
                'If m_MotionSettins(i).bDirectionInverting = False Then
                '    dStandardPositionHomeSerch(i) = dStandardPositionHomeSerch(i) * -1
                'Else

                'End If
                myParent.cMotion.AxisMove(i, dStandardPositionHomeSerch(i), True)
            Next

            For i = 0 To nNumAxis - 1
                CFS20set_max_speed(i, m_MotionSettins(i).dHomeSpeed)
            Next
        End If

        '���� �ߴ���...
        For i As Integer = 0 To nNumAxis - 1
            MoveCompleted(i)
        Next

        'Z ���� ���� �ø�(Homming, ���� ���� ������ ���ؼ�)
        '20160613 CJS ����(4��)

        If nNumAxis >= 4 Then
            byRst(2) = CFS20get_input(2)
            retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(2)))

            'Bit 0 : ORG  , 0: OFF, 1 : ON
            'Bit 1 : Z Phase
            If retBit(0) = 1 Then  ' already Homm

            Else 'Homming
                If Dir(2) = True Then
                    CFS20start_signal_search1(m_nZAxisIndex, m_MotionSettins(m_nZAxisIndex).dVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration, Methods(m_nZAxisIndex))
                Else
                    CFS20start_signal_search1(m_nZAxisIndex, -m_MotionSettins(m_nZAxisIndex).dVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration, Methods(m_nZAxisIndex))
                End If
            End If

            MoveCompleted(m_nZAxisIndex)
            CFS20home_zero(m_nZAxisIndex)
        End If

        For i As Integer = 0 To nNumAxis - 1
            byRst(i) = CFS20get_input(i)
            retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(i)))


            'Bit 0 : ORG  , 0: OFF, 1 : ON
            'Bit 1 : Z Phase
            If retBit(0) = 1 Then  ' already Homm

            Else 'Homming
                If Dir(i) = True Then
                    CFS20start_signal_search1(i, m_MotionSettins(i).dVelocity, m_MotionSettins(i).dAcceleration, Methods(i))
                Else
                    CFS20start_signal_search1(i, -m_MotionSettins(i).dVelocity, m_MotionSettins(i).dAcceleration, Methods(i))
                End If
            End If
        Next


        For i As Integer = 0 To nNumAxis - 1
            MoveCompleted(i)
            CFS20home_zero(i)
        Next



        For i As Integer = 0 To nNumAxis - 1
            byRst(i) = CFS20get_input(i)
            retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(i)))

            If retBit(0) = 1 Then  ' already Homm

            Else 'Homming
                If Dir(i) = True Then
                    CFS20start_signal_search1(i, -m_MotionSettins(i).dVelocity, m_MotionSettins(i).dAcceleration, Methods(i))
                Else
                    CFS20start_signal_search1(i, m_MotionSettins(i).dVelocity, m_MotionSettins(i).dAcceleration, Methods(i))
                End If
            End If
        Next


        For i As Integer = 0 To nNumAxis - 2
            MoveCompleted(i)
            CFS20home_zero(i)
        Next

        'Theta �� Homming (pos�� +�ʿ� ������ -�� Ȩ�⵿ / pos�� -�ʿ� ������ +�� Ȩ�⵿)
        'True : CW, False : CCW 
        '===============================================================================================================================

        'Dir(3) = False
        'Dim R_EndLimitMethod As Byte = &H9   ' Or STOP_EMG


        '' For i As Integer = 0 To nNumAxis - 2
        'byRst(3) = CFS20get_input(3)
        'retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(3)))

        'If retBit(0) = 1 Then  ' already Homm

        'Else 'Homming
        '    If Dir(3) = True Then
        '        CFS20start_signal_search1(3, m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, R_EndLimitMethod)
        '    Else
        '        CFS20start_signal_search1(3, -m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, R_EndLimitMethod)
        '    End If
        'End If

        'MoveCompleted(3)

        '==========================================
        Dim dComPos() As Double = Nothing

        dComPos = GetCommandPosition()
        'True : CW, False : CCW 
        'If dComPos(3) < 0 Then
        '    Dir(3) = True
        'ElseIf dComPos(3) > 0 Then
        '    Dir(3) = False
        'End If


        ' For i As Integer = 0 To nNumAxis - 2
        'byRst(3) = CFS20get_input(3)
        'retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(3)))

        ''Methods(3) = IN0_UPEDGE

        'If retBit(0) = 1 Then  ' already Homm

        'Else 'Homming
        '    If Dir(3) = True Then
        '        CFS20start_signal_search1(3, m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, Methods(3))
        '    Else
        '        CFS20start_signal_search1(3, -m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, Methods(3))
        '    End If
        'End If
        '  Next


        'For i As Integer = 0 To nNumAxis - 2
        'MoveCompleted(3)
        'CFS20home_zero(3)

        'ViewAngleMove(10, True)

        'CFS20set_max_speed(3, m_MotionSettins(3).dHomeSpeed)

        'MoveCompleted(3)

        'dComPos = GetCommandPosition()
        ''True : CW, False : CCW 
        'If dComPos(3) < 0 Then
        '    Dir(3) = True
        'ElseIf dComPos(3) > 0 Then
        '    Dir(3) = False
        'End If


        '' For i As Integer = 0 To nNumAxis - 2
        'byRst(3) = CFS20get_input(3)
        'retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst(3)))

        'If retBit(0) = 1 Then  ' already Homm

        'Else 'Homming
        '    If Dir(3) = True Then
        '        CFS20start_signal_search1(3, m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, Methods(3))
        '    Else
        '        CFS20start_signal_search1(3, -m_MotionSettins(3).dVelocity, m_MotionSettins(3).dAcceleration, Methods(3))
        '    End If
        'End If
        ''============================================
        ''Next

        'ViewAngleMove(0, True)

        'MoveCompleted(3)

        '===============================================================================================================================

        setMaxSpeed()
        MoveCompleted()

        For idx As Integer = 0 To nNumAxis - 1
            CFS20home_zero(idx)
            Application.DoEvents()
            Thread.Sleep(2)
        Next

        '    /* Detect Signal---------------------------------------------------------
        '    PElmNegativeEdge    = &H0,          ' +Elm(End limit) �ϰ� edge
        '    NElmNegativeEdge    = &H1,          ' -Elm(End limit) �ϰ� edge
        '    PSlmNegativeEdge    = &H2,          ' +Slm(Slowdown limit) �ϰ� edge
        '    NSlmNegativeEdge    = &H3,          ' -Slm(Slowdown limit) �ϰ� edge
        '    In0DownEdge         = &H4,          ' IN0(ORG) �ϰ� edge
        '    In1DownEdge         = &H5,          ' IN1(Z��) �ϰ� edge
        '    In2DownEdge         = &H6,          ' IN2(����) �ϰ� edge
        '    In3DownEdge         = &H7,          ' IN3(����) �ϰ� edge
        '    PElmPositiveEdge    = &H8,          ' +Elm(End limit) ��� edge
        '    NElmPositiveEdge    = &H9,          ' -Elm(End limit) ��� edge
        '    PSlmPositiveEdge    = &Ha,          ' +Slm(Slowdown limit) ��� edge
        '    NSlmPositiveEdge    = &Hb,          ' -Slm(Slowdown limit) ��� edge
        '    In0UpEdge           = &Hc,          ' IN0(ORG) ��� edge
        '    In1UpEdge           = &Hd,          ' IN1(Z��) ��� edge
        '    In2UpEdge           = &He,          ' IN2(����) ��� edge
        '    In3UpEdge           = &Hf           ' IN3(����) ��� edge
        '    ------------------------------------------------------------------------*/
        '    /*-----------------------------------------------------------------------
        '    7-4Bit  detect signal ����
        '    3Bit    �˻����� ���� (0 : ccw(-), 1 : cw(+))
        '    2Bit    ������� ���� (0 : ���� ����, 1 : �� ����)
        '    1Bit    ������ ��� ���� (0 : ������, 1 : ���� �ð�)
        '    0Bit    ���� ��뿩�� ���� (0 : ������� ����, 1: �����
        '    ------------------------------------------------------------------------*/

    End Sub

#End Region

#Region "Stop & E-Stop"

    '��� �Ͻ�����...
    Public bMotionPause As Boolean

    Public Sub Set_Stop()

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next


        For cnt_axis = 0 To nNumAxis - 1
            CFS20set_stop(cnt_axis)   ' �������� �������� event�� �����Ѵ�.
        Next

    End Sub
    Public Sub Set_Stop(ByVal inAxisNum As Integer)

        ' Dim cnt_axis As Integer
        Dim nNumAxis As Integer = inAxisNum

        If m_MotionSettins(nNumAxis).eMotionAxis = eMotionAxis.eNot_Use Then
            Exit Sub
        End If

        CFS20set_stop(nNumAxis)   ' �������� �������� event�� �����Ѵ�.

    End Sub

    Public Sub Set_EStop()

        Dim nNumAxis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To nNumAxis - 1
            If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                Exit Sub
            End If
        Next
        ''Log & Status Bar *****************************
        ''LogWrite("Emergency_Stop")
        ''frmMain.MsgStatusBarPanel.Text = "All Axis Emergency Stop Set."
        ''**********************************************


        CFS20emergency_stop()
    End Sub

#End Region



    Public Function AxisHomeCheck(ByVal nAxis As Integer) As Boolean

        Dim retBit() As Integer
        Dim byRst As Byte

        byRst = CFS20get_input(nAxis)
        retBit = CDevPLCCommonNode.DecToBinery(Convert.ToInt16(byRst))

        If retBit(0) = 1 Then
            Return True
        End If

        Return False
    End Function
   
#Region "Jog Mode �Լ�"

    Public Function JogXRMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        CFS20v_move(m_nXAxisIndex, dDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ��� 

        Return True
    End Function

    Public Function JogXLMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        CFS20v_move(m_nXAxisIndex, dDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ��� 
  
        Return True
    End Function

    Public Function JogYUpMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If

        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        End If

      
        CFS20v_s_move(m_nYAxisIndex, dDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
    

        Return True
    End Function

    Public Function JogYDownMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim byRst As Byte

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        End If


        byRst = CFS20v_s_move(m_nYAxisIndex, dDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

    Public Function JogZUpMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis < eMotionAxis.eZ_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim byRst As Byte

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = True Then
            dDirVelocity = -m_MotionSettins(m_nZAxisIndex).dVelocity
        Else
            dDirVelocity = m_MotionSettins(m_nZAxisIndex).dVelocity
        End If

        byRst = CFS20v_s_move(m_nZAxisIndex, dDirVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

    Public Function JogZDownMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis < eMotionAxis.eZ_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim byRst As Byte

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = True Then
            dDirVelocity = m_MotionSettins(m_nZAxisIndex).dVelocity
        Else
            dDirVelocity = -m_MotionSettins(m_nZAxisIndex).dVelocity
        End If

        byRst = CFS20v_s_move(m_nZAxisIndex, dDirVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration)  ' ���ӱ��� 

        Return True
    End Function

    Public Function JogThetaRMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = True Then
            dDirVelocity = m_MotionSettins(m_nThetaAxisIndex).dVelocity
        Else
            dDirVelocity = -m_MotionSettins(m_nThetaAxisIndex).dVelocity
        End If

        CFS20v_move(m_nThetaAxisIndex, dDirVelocity, m_MotionSettins(m_nThetaAxisIndex).dAcceleration)  ' ���ӱ��� 

        Return True
    End Function

    Public Function JogThetaLMove() As Boolean


        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If

        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = True Then
            dDirVelocity = -m_MotionSettins(m_nThetaAxisIndex).dVelocity
        Else
            dDirVelocity = m_MotionSettins(m_nThetaAxisIndex).dVelocity
        End If

        CFS20v_move(m_nThetaAxisIndex, dDirVelocity, m_MotionSettins(m_nThetaAxisIndex).dAcceleration)  ' ���ӱ��� 

        Return True

        Return True
    End Function

    Public Function JogXLYUpMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisDirVelocity As Double
        Dim dYAxisDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dXAxisDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dYAxisDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        End If

        CFS20v_s_move(m_nXAxisIndex, dXAxisDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ���
        CFS20v_s_move(m_nYAxisIndex, dYAxisDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

    Public Function JogXRYUpMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisDirVelocity As Double
        Dim dYAxisDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dXAxisDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dYAxisDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        End If

        CFS20v_s_move(m_nXAxisIndex, dXAxisDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ���
        CFS20v_s_move(m_nYAxisIndex, dYAxisDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

    Public Function JogXLYDownMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisDirVelocity As Double
        Dim dYAxisDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dXAxisDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dYAxisDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        End If

        CFS20v_s_move(m_nXAxisIndex, dXAxisDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ���
        CFS20v_s_move(m_nYAxisIndex, dYAxisDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

    Public Function JogXRYDownMove() As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value you set is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisDirVelocity As Double
        Dim dYAxisDirVelocity As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisDirVelocity = -m_MotionSettins(m_nXAxisIndex).dVelocity
        Else
            dXAxisDirVelocity = m_MotionSettins(m_nXAxisIndex).dVelocity
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dYAxisDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        End If

        CFS20v_s_move(m_nXAxisIndex, dXAxisDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' ���ӱ���
        CFS20v_s_move(m_nYAxisIndex, dYAxisDirVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  ' ���ӱ��� 
        Return True
    End Function

#End Region
#Region "X,Y,Z,Angle ���� ����"

    Public Function AxisMove(ByVal nAxis As CDevMotion_AJIN.eMotionAxis, ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If

        Dim dDistance As Double

        Dim nAxisIndex As Integer = nAxis
        Dim nRealAxisIndex As Integer

        Dim dAxisCalDataRealDistance As Double

        If m_MotionSettins(nAxisIndex).eMotionAxis <> nAxis + 1 Then
            Return False
        End If

        Select Case m_MotionSettins(nAxisIndex).eMotionAxis
            Case eMotionAxis.eX_Axis
                dAxisCalDataRealDistance = m_CalDataRealDistance_X
            Case eMotionAxis.eY_Axis
                dAxisCalDataRealDistance = m_CalDataRealDistance_Y
            Case eMotionAxis.eZ_Axis
                dAxisCalDataRealDistance = m_CalDataRealDistance_Z
        End Select

        If m_CalDataRealDistanceUse = True Then
            dDistance = distance * dAxisCalDataRealDistance
        End If

        '  If m_MotionSettins(nAxisIndex).eMotionAxis = m_MotionSettins(nAxisIndex).eMotionAxisInverting Then
        If m_MotionSettins(nAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If
        ' Else

        ' End If


        nRealAxisIndex = nAxis ' m_MotionSettins(nAxisIndex).eMotionAxisInverting - 1
        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            CFS20start_ras_move(nRealAxisIndex, dDistance, m_MotionSettins(nRealAxisIndex).dVelocity, m_MotionSettins(nRealAxisIndex).dAcceleration, m_MotionSettins(nRealAxisIndex).dDeceleration)  ' �����ǥ ���Ī s�� ����
        Else
            CFS20start_s_move(nRealAxisIndex, dDistance, m_MotionSettins(nRealAxisIndex).dVelocity, m_MotionSettins(nRealAxisIndex).dAcceleration)  '������ǥ s�� ����
        End If

        MoveCompleted(nRealAxisIndex)

        Return True
    End Function

    Public Function XMove(ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim dDistance As Double

        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = distance * m_CalDataRealDistance_X
        End If

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            CFS20start_ras_move(m_nXAxisIndex, dDistance, m_MotionSettins(m_nXAxisIndex).dVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration, m_MotionSettins(m_nXAxisIndex).dDeceleration)  ' �����ǥ ���Ī s�� ����
        Else
            CFS20start_s_move(m_nXAxisIndex, dDistance, m_MotionSettins(m_nXAxisIndex).dVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  '������ǥ s�� ����
        End If

        MoveCompleted(m_nXAxisIndex)

        Return True
    End Function

    Public Function YMove(ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim dDistance As Double

        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = distance * m_CalDataRealDistance_Y
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        If absolutePos = False Then
            CFS20start_ras_move(m_nYAxisIndex, dDistance, m_MotionSettins(m_nYAxisIndex).dVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration, m_MotionSettins(m_nYAxisIndex).dDeceleration)  ' �����ǥ ���Ī s�� ����
        Else
            CFS20start_s_move(m_nYAxisIndex, dDistance, m_MotionSettins(m_nYAxisIndex).dVelocity, m_MotionSettins(m_nYAxisIndex).dAcceleration)  '������ǥ s�� ����
        End If

        MoveCompleted(m_nYAxisIndex)
        Return True
    End Function

 

    Public Function ViewAngleMove(ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim dRealDistance As Double = distance
        Dim Pos() As Double = Nothing

        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dRealDistance = distance * m_CalDataRealDistance_Theta '+ (m_CalDataDeviation_Theta * m_CalDataRealDistance_Theta)
        End If

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = False Then
            dRealDistance = -dRealDistance
        End If

        Pos = GetCommandPosition()


        If absolutePos = False Then
            dRealDistance = Pos(3) + dRealDistance
            CFS20start_ras_move(m_nThetaAxisIndex, dRealDistance, m_MotionSettins(m_nThetaAxisIndex).dVelocity, m_MotionSettins(m_nThetaAxisIndex).dAcceleration, m_MotionSettins(m_nZAxisIndex).dDeceleration)  ' �����ǥ ���Ī s�� ����
        Else
            
            dRealDistance = ((distance + m_CalDataDeviation_Theta) * m_CalDataRatio_Theta) + m_CalDataOffset_Theta  '((distance + m_CalDataDeviation_Theta) * 0.9938806) + 0.9975721 ' 1.0473  'LEX_20160813
            ''dDistance = distance
            CFS20start_s_move(m_nThetaAxisIndex, dRealDistance, m_MotionSettins(m_nThetaAxisIndex).dVelocity, m_MotionSettins(m_nThetaAxisIndex).dAcceleration)  '������ǥ s�� ����
        End If

        Application.DoEvents()
        Thread.Sleep(100)

        MoveCompleted(m_nThetaAxisIndex)

        Return True
    End Function

    Public Function ZMove(ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim dDistance As Double = distance

        If m_MotionSettins(m_nZAxisIndex).eMotionAxis <> eMotionAxis.eZ_Axis Then
            Return False
        End If


        If m_CalDataRealDistanceUse = True Then
            dDistance = distance * m_CalDataRealDistance_Z
        End If

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        If absolutePos = False Then
            CFS20start_ras_move(m_nZAxisIndex, dDistance, m_MotionSettins(m_nZAxisIndex).dVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration, m_MotionSettins(m_nZAxisIndex).dDeceleration)  ' �����ǥ ���Ī s�� ����
        Else
            CFS20start_s_move(m_nZAxisIndex, dDistance, m_MotionSettins(m_nZAxisIndex).dVelocity, m_MotionSettins(m_nZAxisIndex).dAcceleration)  '������ǥ s�� ����
        End If

        Application.DoEvents()
        Thread.Sleep(100)

        MoveCompleted(m_nZAxisIndex)

        Return True
    End Function

#End Region


#Region "ä�κ� ���� Motion Moving : Absolute : Function Events"


    Public Function SetPosition(ByVal setPos As String) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        If arrPos.Length < 3 Then Return False
        If SetPosition(arrPos) = False Then
            Return False
        End If
        Return True
    End Function

    Public Function SetPositionXYAxisMovingFirst(ByVal setPos As String) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        If arrPos.Length < 3 Then Return False
        If SetPositionXYAxisMovingFirst(arrPos) = False Then
            If SetPositionXYAxisMovingFirst(arrPos) = False Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function SetPosition(ByVal inPosition() As String) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If inPosition Is Nothing Then
            Return False
        End If

        Dim dDistance(2) As Double

        'True : CW, False : CCW 

        '20160613 CJS ����
        Try
            If m_CalDataRealDistanceUse = True Then
                dDistance(0) = CDbl(inPosition(1)) * m_CalDataRealDistance_X
                dDistance(1) = CDbl(inPosition(2)) * m_CalDataRealDistance_Y
                dDistance(2) = CDbl(inPosition(3)) * m_CalDataRealDistance_Z
                'dDistance(3) = CDbl(inPosition(3)) * m_CalDataRealDistance_Theta

            Else
                dDistance(0) = CDbl(inPosition(1))
                dDistance(1) = CDbl(inPosition(2))
                dDistance(2) = CDbl(inPosition(3))
                '  dDistance(3) = CDbl(inPosition(3))

            End If


            'For axis As Integer = 0 To nNumAxis - 1
            '    If m_MotionSettins(axis).bDirectionInverting = True Then
            '        dDistance(axis) = dDistance(axis)
            '    Else
            '        dDistance(axis)  = -dDistance(axis)
            '    End If
            'Next

            For axis As Integer = 0 To dDistance.Length - 1

                If m_MotionSettins(axis).eMotionAxis = m_MotionSettins(axis).eMotionAxisInverting = True Then
                    If m_MotionSettins(axis).bDirectionInverting = False Then
                        dDistance(axis) = -dDistance(axis)
                    End If
                End If
            
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        For cnt_axis = 0 To dDistance.Length - 1
            CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '������ǥ s�� ����
        Next

        MoveCompletedAllAxis()

        Return True
    End Function


   Public Function SetPositionXYAxisMovingFirst(ByVal inPosition() As String) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If inPosition Is Nothing Then
            Return False
        End If

        Dim dDistance(2) As Double
        Dim dPos(2) As Double

        'True : CW, False : CCW 

        Try
            If m_CalDataRealDistanceUse = True Then
                dDistance(0) = CDbl(inPosition(1)) * m_CalDataRealDistance_X
                dDistance(1) = CDbl(inPosition(2)) * m_CalDataRealDistance_Y
                dDistance(2) = CDbl(inPosition(3)) * m_CalDataRealDistance_Z
                '  dDistance(3) = 0
            Else
                dDistance(0) = CDbl(inPosition(1))
                dDistance(1) = CDbl(inPosition(2))
                dDistance(2) = CDbl(inPosition(3)) '+ 119.644
                '   dDistance(3) = 0
            End If

            dPos(0) = CDbl(inPosition(1))
            dPos(1) = CDbl(inPosition(2))
            dPos(2) = CDbl(inPosition(3))

            For axis As Integer = 0 To dDistance.Length - 1
                If m_MotionSettins(axis).eMotionAxis = m_MotionSettins(axis).eMotionAxisInverting = True Then
                    If m_MotionSettins(axis).bDirectionInverting = False Then
                        dDistance(axis) = -dDistance(axis)
                    End If
                Else

                End If

            Next

            m_Distance = dDistance.Clone

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Dim GetCMDPos() As Double = Nothing
        Dim chkPos As Boolean = False
        Dim cnt As Integer = 0
        Dim cntTimeOut As Integer = 0
        Dim sTemp As String = ""


        ''Z���� ���� �·ᰡ Limit ���� ��ġ, �� �ִ� �Ÿ��� ���� �Ǿ��� ���,
        ''Homming���� ������ �����̶� Ʋ������, (Ȩ�� �����̶� ������) ���� �����ϼ� �ִ� �Ÿ��� �پ� ��� �ǰ�
        ''���� ��ǥ��, ���� �·Ḧ ���� ���� Mismatch�� �Ǹ鼭 ��ǥ�� �߸� �̵��Ȱ����� ǥ�õǴ� ������ ����
        ''����, �Ʒ��� ��ƾ�� �ּ� ó���Ѵ�.
        'Do
        '    For cnt_axis = 0 To 1
        '        CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '������ǥ s�� ����
        '        Application.DoEvents()
        '        Thread.Sleep(50)
        '    Next

        '    MoveCompletedAllAxis()
        '    Application.DoEvents()
        '    Thread.Sleep(50)

        '    If nNumAxis > 2 Then '
        '        CFS20start_s_move(2, dDistance(2), m_MotionSettins(2).dVelocity, m_MotionSettins(2).dAcceleration)  '������ǥ s�� ����
        '    End If

        '    Application.DoEvents()
        '    Thread.Sleep(100)

        '    MoveCompletedAllAxis()

        'GetCMDPos = GetCommandPosition()

        'For i As Integer = 0 To dDistance.Length - 1
        '    If Format(CDbl(inPosition(i + 1)), "0.0") = Format(GetCMDPos(i), "0.0") Then
        '        cnt += 1
        '    Else
        '        sTemp = Format(CDbl(inPosition(i + 1)), "0.0") & "/" & Format(GetCMDPos(i), "0.0")
        '    End If
        'Next

        'If cnt = nNumAxis Then
        '    chkPos = True
        'Else
        '    cnt = 0
        '    chkPos = False
        '    cntTimeOut += 1
        '    sTemp = ""
        '    'LEX : Error Message �߰�
        '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_POS_MISMATCH, sTemp)
        'End If

        'If cntTimeOut > 10 Then
        '    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_CHECK_FAILED)
        '    Return False
        'End If


        'Loop Until chkPos

        For cnt_axis = 0 To 1
            CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '������ǥ s�� ����
            Application.DoEvents()
            Thread.Sleep(50)
        Next

        MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        Dim dComPos() As Double = Nothing
        dComPos = GetCommandPosition.Clone

        For cnt_axis = 0 To 1
            If Format(CDbl(inPosition(cnt_axis + 1)), "0") <> Format(dComPos(cnt_axis), "0") Then

                '   CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '������ǥ s�� ����
                Application.DoEvents()
                Thread.Sleep(50)
                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_POS_MISMATCH, Format(inPosition(cnt_axis + 1), "0.0") & Format(CStr(dComPos(cnt_axis)), "0.0"))
                Homming()
                MoveCompletedAllAxis()
                Application.DoEvents()
                Thread.Sleep(100)

                If myParent.m_bThetaAxisUsed = True Then
                    myParent.cMotion.ViewAngleMove(0, True)
                End If
             

                Return False
            End If
        Next

        MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        If nNumAxis > 2 Then '
            CFS20start_s_move(2, dDistance(2), m_MotionSettins(2).dVelocity, m_MotionSettins(2).dAcceleration)  '������ǥ s�� ����
        End If

        MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        Return True
    End Function

    '��� ���� �����ߴ°�?   'LEX_
    Public Function MoveCompleted() As Boolean

        Dim Maxis() As Integer = New Integer() {0, 1, 2, 3}

        If CFS20wait_for_all(4, Maxis(0)) = 0 Then
            Return True
        Else

            Return False
        End If

    End Function

    Public Sub MoveCompletedAllAxis()
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If m_MotionSettins Is Nothing = False Then

            For i As Integer = 0 To nNumAxis - 1
                If m_MotionSettins(i).eMotionAxis = eMotionAxis.eNot_Use Then
                    Exit Sub
                End If
            Next
        End If

        For Cnt As Integer = 0 To nNumAxis - 1
            MoveCompleted(Cnt)
        Next
    End Sub

    Private Sub MoveCompleted(ByVal axis As Integer)
        Dim rst As Boolean

        If m_MotionSettins(axis).eMotionAxis = eMotionAxis.eNot_Use Then
            Exit Sub
        End If

        Do
            rst = CFS20motion_done(axis)
            Application.DoEvents()
            Thread.Sleep(10)
        Loop Until rst = True

    End Sub

    Public Sub setMaxSpeed()

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If m_MotionSettins(nNumAxis - 1).eMotionAxis = eMotionAxis.eNot_Use Then
            Exit Sub
        End If

        Dim dDistance(nNumAxis - 1) As Double

        For cnt_axis = 0 To nNumAxis - 1
            CFS20set_max_speed(cnt_axis, m_MotionSettins(cnt_axis).dMaxSpeed)
        Next
    End Sub

    Public Function CalYFromXByPolynomial(ByVal dXVal As Double, ByVal CalFactor() As Double) As Double

        Dim x As Double = dXVal
        Dim y As Double = 0

        For i As Integer = 0 To CalFactor.Length - 1
            Dim aaa As Double = x ^ i * CalFactor(i)
            y = y + (x ^ i * CalFactor(i))
        Next

        Return y
    End Function

#End Region

#Region "Ȩ���� �տ��� ����: ���� �� ��ġ"

    'Pause mode���� ����
    Public Sub SetPosition_Pause(ByVal pos() As Double)

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If pos Is Nothing Then
            Exit Sub
        End If

        If m_MotionSettins Is Nothing Then Exit Sub

        ' CFS20set_max_speed(0, m_dVelocity)
        'CFS20set_max_speed(1, m_dVelocity)

        For cnt_axis = 0 To nNumAxis - 1
            CFS20start_s_move(cnt_axis, -pos(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '������ǥ s�� ����
        Next

    End Sub

#End Region


#Region "Get Data"


    Public Function GetCommandPosition() As Double()
        Dim pos() As Double = Nothing
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If m_MotionSettins Is Nothing Then Return pos

        ReDim pos(nNumAxis - 1)

        For i As Integer = 0 To nNumAxis - 1
            pos(i) = CFS20get_command_position(i)    'Position �� return
        Next

        If m_CalDataRealDistanceUse = True Then
            pos(m_nXAxisIndex) = pos(m_nXAxisIndex) / m_CalDataRealDistance_X
            pos(m_nYAxisIndex) = pos(m_nYAxisIndex) / m_CalDataRealDistance_Y
            pos(m_nZAxisIndex) = pos(m_nZAxisIndex) / m_CalDataRealDistance_Z
            ' pos(m_nThetaAxisIndex) = pos(m_nThetaAxisIndex) / m_CalDataRealDistance_Theta
            'pos(m_nThetaAxisIndex) = (pos(m_nThetaAxisIndex) - m_CalDataOffset_Theta) / m_CalDataRatio_Theta  ' (( * 0.03950353)) + 1.720176
            'pos(m_nThetaAxisIndex) = ((pos(m_nThetaAxisIndex) / m_CalDataRatio_Theta)) - m_CalDataOffset_Theta ' 1.0473)  'LEX_20160813
            '((distance - 0) * 0.9932) + 1.1481
        End If

        Return pos
    End Function


    Public Function GetActualPosition() As Double()
        Dim pos() As Double = Nothing
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If m_MotionSettins Is Nothing Then Return pos

        ReDim pos(nNumAxis - 1)

        For i As Integer = 0 To nNumAxis - 1
            pos(i) = CFS20get_actual_position(i)    'Position �� return
        Next

        Return pos
    End Function

    Public Function GetLimitLevel() As Integer()
        Dim nlevel() As Integer = Nothing
        Dim nNumAxis As Integer = m_MotionSettins.Length

        If m_MotionSettins Is Nothing Then Return nlevel

        ReDim nlevel(nNumAxis - 1)
        '����Ʈ��ȣ ����
        For i As Integer = 0 To nNumAxis - 1
            nlevel(i) = CFS20get_pend_limit_level(i)
        Next

        Return nlevel

    End Function

#End Region



#End Region



End Class
