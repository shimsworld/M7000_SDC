Imports CCommLib
Imports System.Windows.Forms
Imports System.Threading

Public Class CDevEZISERVOPLUSR
    ' Inherits CDevMotionCommonNode

    Dim m_Config As CComCommonNode.sCommInfo
    Dim nPortNo As Integer = 0
    '   Dim iSlaveNo As Integer = 0 '0~15
    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    ' Protected m_Settings As sSetInfos
    Protected m_bIsConnected As Boolean = False
    Shared sSupportDeviceList() As String = New String() {"None", "EziSERVOPlusR"}
    Protected m_ErrorCode As Integer

    Protected m_CalDataRealDistance_X As Double
    Protected m_CalDataRealDistance_Y As Double
    Protected m_CalDataRealDistance_Z As Double
    Protected m_CalDataRealDistance_Theta_Y As Double
    Protected m_CalDataRealDistance_Theta As Double

    Protected m_CalDataRealDistanceUse As Boolean
    Protected m_Distance() As Double

    Protected m_MotionSettins() As sMotionParams
    Protected m_nXAxisIndex As Integer = 0
    Protected m_nYAxisIndex As Integer = 1
    Protected m_nZAxisIndex As Integer = 2
    Protected m_nThetaYAxisIndex As Integer = 3
    Protected m_nThetaAxisIndex As Integer = 4
    Public dDefaultZDistance As Double = 20

    Public Enum eModel
        None
        eEziSERVOPlusR
    End Enum

    Public Enum eMotionAxis
        eNot_Use
        eX_Axis 'X축
        eY_Axis 'Y축
        eZ_Axis 'Z축
        eThetaY_Axis
        eTheta_Axis 'θ축
    End Enum


#Region "Structures"

    'Public Structure sSetInfos
    '    Dim sEziPlusR As CDevEZISERVOPLUSR.sCommandSettings
    'End Structure

    Public Structure sOrigionSettings
        Dim nOriginSpeed As Integer
        Dim nOriginSearchSpeed As Integer
        Dim nOriginAccelDecelSpeed As Integer
    End Structure

    Public Structure sSingleMoveSettings
        Dim nVelocity As Integer
        Dim StartSpeed As Integer
        Dim nAccelSpeed As Integer
        Dim nDecelSpeed As Integer
    End Structure

  
    Public Structure sMotionParams
        Dim n90PluseValue As Integer
        Dim n1PulseValue As Integer
        Dim sOriginInofos As sOrigionSettings
        Dim sSingleMoveInfos As sSingleMoveSettings
        '      Dim ePulseOutMethod As ePulseOutMethod
        Dim eMotionAxis As eMotionAxis
        Dim eMotionAxisInverting As eMotionAxis
        '     Dim eEncInputMethod As eEncoderInputMethod
        ' Dim dVelocity As Double   '공통 사용
        '  Dim dAcceleration As Double
        '  Dim dDeceleration As Double
        Dim dMaxSpeed As Double
        '  Dim dInitSpeed As Double  '축별 설정 가능
        Dim dUnitPulse As Double
        Dim bDirectionInverting As Boolean   '방향 반전

        ' Dim dHomeSpeed As Double
    End Structure
#End Region

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public Property Model As eModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eModel)
            m_MyModel = value
        End Set
    End Property

    Public Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public ReadOnly Property ErrorCode As Integer
        Get
            Return m_ErrorCode
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

    Public Property CalDataRealDistanceThetaY As Double
        Get
            Return m_CalDataRealDistance_Theta_Y
        End Get
        Set(ByVal value As Double)
            m_CalDataRealDistance_Theta_Y = value
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

    Public ReadOnly Property RealDistance As Double()
        Get
            Return m_Distance
        End Get
    End Property

#Region "Enum"
    Public Enum eErrorCode
        FMM_OK = 0
        FMM_NOT_OPEN
        FMM_INVALID_PORT_NUM
        FMM_INVALID_SLAVE_NUM
        FMC_DISCONNECTED = 5
        FMC_TIMEOUT_ERROR
        FMC_CRCFAILED_ERROR
        FMC_RECVPACKET_ERROR
        FMM_POSTABLE_ERROR
        FMP_FRAMETYPEERROR = 128
        FMP_DATAERROR
        FMP_PACKETERROR
        FMP_RUNFAIL = 133
        FMP_RESETFAIL
        FMP_SERVOONFAIL1
        FMP_SERVOONFAIL2
        FMP_SERVOONFAIL3
        FMP_ROMACCESS = 139
        FMP_PACKETCRCERROR = 170
        FMM_UNKNOWN_ERROR = 255
    End Enum

    Public Enum eParameter
        SERVO_PULSEPERREVOLUTION = 0
        SERVO_AXISMAXSPEED
        SERVO_AXISSTARTSPEED
        SERVO_AXISACCTIME
        SERVO_AXISDECTIME
        SERVO_SPEEDOVERRIDE
        SERVO_JOGHIGHSPEED
        SERVO_JOGLOWSPEED
        SERVO_JOGACCDECTIME
        SERVO_SERVOALARMLOGIC
        SERVO_SERVOONLOGIC
        SERVO_SERVORESETLOGIC
        SERVO_SWLMTPLUSVALUE
        SERVO_SWLMTMINUSVALUE
        SERVO_SOFTLMTSTOPMETHOD
        SERVO_HARDLMTSTOPMETHOD
        SERVO_LIMITSENSORLOGIC
        SERVO_ORGSPEED
        SERVO_ORGSEARCHSPEED
        SERVO_ORGACCDECTIME
        SERVO_ORGMETHOD
        SERVO_ORGDIR
        SERVO_ORGOFFSET
        SERVO_ORGPOSITIONSET
        SERVO_ORGSENSORLOGIC
        SERVO_POSITIONLOOPGAIN
        SERVO_INPOSITIONVALUE
        SERVO_POSTRACKINGLIMIT
        SERVO_MOTIONDIR
        SERVO_LIMITSENSORDIR
        SERVO_ORGTORQUERATIO
        SERVO_POSERROVERFLOWLIMIT
        SERVO_POSVALUECOUNTINGMETHOD
        SERVO_SERVOONMETHOD
        SERVO_BRAKEDELAYTIME
        SERVO_SSTOP_METHOD
        MAX_SERVO_PARAM
    End Enum

    Public Enum eOnOFF
        eOFF
        eON
    End Enum
#End Region

#Region "Sturcture"
    Public Structure sAlarmLog
        Dim nAlarmCount As Byte
        Dim nAlarmLog() As Byte
    End Structure

    Public Structure sLPITEM_NODE
        Dim lPosition As Integer
        Dim dwStartSpd As UInteger
        Dim dwMoveSpd As UInteger
        Dim wAccelRate As UShort
        Dim wDecelRate As UShort
        Dim wCommand As UShort
        Dim wWaitTime As UShort
        Dim wContinuos As UShort
        Dim wBranch As UShort
        Dim wCond_branch0 As UShort
        Dim wCond_branch1 As UShort
        Dim wCond_branch2 As UShort
        Dim wLoopCount As UShort
        Dim wBranchAfterLoop As UShort
        Dim wPTSet As UShort
        Dim wLoopCountCLR As UShort
        Dim bCheckInpos As UShort '0 : Check Impos, 1 : Don't Check.
        Dim lTrrigerPos As Integer
        Dim wTrrigerOnTime As UShort
        Dim wPushRatio As UShort
        Dim dwPushSpeed As UInteger
        Dim lPushPosition As Integer
        Dim wPushMode As UShort
    End Structure

    Public Structure sEziservoAxisStatus
        Dim dwValue As UInteger
        Const FFLAG_ERRORALL As UInteger = &H1UI      '	: 1; // = 0x00000001;
        Const FFLAG_HWPOSILMT As UInteger = &H2UI     ': 1; // = 0x00000002;
        Const FFLAG_HWNEGALMT As UInteger = &H4UI       ': 1; // = 0x00000004;
        Const FFLAG_SWPOGILMT As UInteger = &H8UI         ': 1; // = 0x00000008;
        Const FFLAG_SWNEGALMT As UInteger = &H10UI     ': 1; // = 0x00000010;
        Const FFLAG_RESERVED0 As UInteger = &H20UI        ': 1; // = 0x00000020;
        Const FFLAG_RESERVED1 As UInteger = &H40UI     '	: 1; // = 0x00000040;
        Const FFLAG_ERRPOSOVERFLOW As UInteger = &H80UI   ': 1; // = 0x00000080;
        Const FFLAG_ERROVERCURRENT As UInteger = &H100UI     ': 1; // = 0x00000100;
        Const FFLAG_ERROVERSPEED As UInteger = &H200UI      ': 1; // = 0x00000200;
        Const FFLAG_ERRPOSTRACKING As UInteger = &H400UI     ': 1; // = 0x00000400;
        Const FFLAG_ERROVERLOAD As UInteger = &H800UI   ': 1; // = 0x00000800;
        Const FFLAG_ERROVERHEAT As UInteger = &H1000UI        ': 1; // = 0x00001000;
        Const FFLAG_ERRBACKEMF As UInteger = &H2000UI     ': 1; // = 0x00002000;
        Const FFLAG_ERRMOTORPOWER As UInteger = &H4000UI     ': 1; // = 0x00004000;
        Const FFLAG_ERRINPOSITION As UInteger = &H8000UI    ': 1; // = 0x00008000;
        Const FFLAG_EMGSTOP As UInteger = &H10000UI  ': 1; // = 0x00010000;
        Const FFLAG_SLOWSTOP As UInteger = &H20000UI         ': 1; // = 0x00020000;
        Const FFLAG_ORIGINRETURNING As UInteger = &H40000UI     ': 1; // = 0x00040000;
        Const FFLAG_INPOSITION As UInteger = &H80000UI    ': 1; // = 0x00080000;
        Const FFLAG_SERVOON As UInteger = &H100000UI  ': 1; // = 0x00100000;
        Const FFLAG_ALARMRESET As UInteger = &H200000UI     ': 1; // = 0x00200000;
        Const FFLAG_PTSTOPPED As UInteger = &H400000UI        ': 1; // = 0x00400000;
        Const FFLAG_ORIGINSENSOR As UInteger = &H800000UI    ': 1; // = 0x00800000;
        Const FFLAG_ZPULSE As UInteger = &H1000000UI          ': 1; // = 0x01000000;
        Const FFLAG_ORIGINRETOK As UInteger = &H2000000UI      ': 1; // = 0x02000000;
        Const FFLAG_MOTIONDIR As UInteger = &H4000000UI     ': 1; // = 0x04000000;
        Const FFLAG_MOTIONING As UInteger = &H8000000UI     ': 1; // = 0x08000000;
        Const FFLAG_MOTIONPAUSE As UInteger = &H10000000UI     ': 1; // = 0x10000000;
        Const FFLAG_MOTIONACCEL As UInteger = &H20000000UI     ': 1; // = 0x20000000;
        Const FFLAG_MOTIONDECEL As UInteger = &H40000000UI   ': 1; // = 0x40000000;
        Const FFLAG_MOTIONCONST As UInteger = &H80000000UI   '	: 1; // = 0x80000000;
    End Structure

    'Public Structure sCommandSettings
    '    Dim n90PluseValue As Integer
    '    Dim n1PulseValue As Integer
    '    Dim sOriginInofos As sOrigionSettings
    '    Dim sSingleMoveInfos As sSingleMoveSettings
    'End Structure


#End Region

#Region "IO Input/output Mask list"

    Const SERVO_IN_BITMASK_LIMITP = &H1UI
    Const SERVO_IN_BITMASK_LIMITN = &H2UI
    Const SERVO_IN_BITMASK_ORIGIN = &H4UI
    Const SERVO_IN_BITMASK_CLEARPOSITION = &H8UI
    Const SERVO_IN_BITMASK_PTA0 = &H10UI
    Const SERVO_IN_BITMASK_PTA1 = &H20UI
    Const SERVO_IN_BITMASK_PTA2 = &H40UI
    Const SERVO_IN_BITMASK_PTA3 = &H80UI
    Const SERVO_IN_BITMASK_PTA4 = &H100UI
    Const SERVO_IN_BITMASK_PTA5 = &H200UI
    Const SERVO_IN_BITMASK_PTA6 = &H400UI
    Const SERVO_IN_BITMASK_PTA7 = &H800UI
    Const SERVO_IN_BITMASK_PTSTART = &H1000UI
    Const SERVO_IN_BITMASK_STOP = &H2000UI
    Const SERVO_IN_BITMASK_PJOG = &H4000UI
    Const SERVO_IN_BITMASK_NJOG = &H8000UI
    Const SERVO_IN_BITMASK_ALARMRESET = &H10000UI
    Const SERVO_IN_BITMASK_SERVOON = &H20000UI
    Const SERVO_IN_BITMASK_PAUSE = &H40000UI
    Const SERVO_IN_BITMASK_ORIGINSEARCH = &H80000UI
    Const SERVO_IN_BITMASK_TEACHING = &H100000UI
    Const SERVO_IN_BITMASK_ESTOP = &H200000UI
    Const SERVO_IN_BITMASK_JPTIN0 = &H400000UI
    Const SERVO_IN_BITMASK_JPTIN1 = &H800000UI
    Const SERVO_IN_BITMASK_JPTIN2 = &H1000000UI
    Const SERVO_IN_BITMASK_JPTSTART = &H2000000UI
    Const SERVO_IN_BITMASK_USERIN0 = &H4000000UI
    Const SERVO_IN_BITMASK_USERIN1 = &H8000000UI
    Const SERVO_IN_BITMASK_USERIN2 = &H10000000UI
    Const SERVO_IN_BITMASK_USERIN3 = &H20000000UI
    Const SERVO_IN_BITMASK_USERIN4 = &H40000000UI
    Const SERVO_IN_BITMASK_USERIN5 = &H80000000UI
    Const SERVO_IN_BITMASK_USERIN6 = &H200UI
    Const SERVO_IN_BITMASK_USERIN7 = &H400UI
    Const SERVO_IN_BITMASK_USERIN8 = &H800UI

    '// Output Bit-mask list.
    Const SERVO_OUT_BITMASK_COMPAREOUT = &H1UI
    Const SERVO_OUT_BITMASK_INPOSITION = &H2UI
    Const SERVO_OUT_BITMASK_ALARM = &H4UI
    Const SERVO_OUT_BITMASK_MOVING = &H8UI
    Const SERVO_OUT_BITMASK_ACCDEC = &H10UI
    Const SERVO_OUT_BITMASK_ACK = &H20UI
    Const SERVO_OUT_BITMASK_END = &H40UI
    Const SERVO_OUT_BITMASK_ALARMBLINK = &H80UI
    Const SERVO_OUT_BITMASK_ORGSEARCHOK = &H100UI
    Const SERVO_OUT_BITMASK_SERVOREADY = &H200UI
    '/static const DWORD	SERVO_OUT_BITMASK_RESERVED	= 0x00000400;
    Const SERVO_OUT_BITMASK_BRAKE = &H800UI
    Const SERVO_OUT_BITMASK_PTOUT0 = &H1000UI
    Const SERVO_OUT_BITMASK_PTOUT1 = &H2000UI
    Const SERVO_OUT_BITMASK_PTOUT2 = &H4000UI
    Const SERVO_OUT_BITMASK_USEROUT0 = &H8000UI
    Const SERVO_OUT_BITMASK_USEROUT1 = &H10000UI
    Const SERVO_OUT_BITMASK_USEROUT2 = &H20000UI
    Const SERVO_OUT_BITMASK_USEROUT3 = &H40000UI
    Const SERVO_OUT_BITMASK_USEROUT4 = &H80000UI
    Const SERVO_OUT_BITMASK_USEROUT5 = &H100000UI
    Const SERVO_OUT_BITMASK_USEROUT6 = &H200000UI
    Const SERVO_OUT_BITMASK_USEROUT7 = &H400000UI
    Const SERVO_OUT_BITMASK_USEROUT8 = &H800000UI

    '// Input Bit-mask list.
    Const SERVO_ADC_IN_BITMASK_LIMITP = &H1UI
    Const SERVO_ADC_IN_BITMASK_LIMITN = &H2UI
    Const SERVO_ADC_IN_BITMASK_ORIGIN = &H4UI
    Const SERVO_ADC_IN_BITMASK_CLEARPOSITION = &H8UI
    Const SERVO_ADC_IN_BITMASK_PTA0 = &H10UI
    Const SERVO_ADC_IN_BITMASK_PTA1 = &H20UI
    Const SERVO_ADC_IN_BITMASK_PTA2 = &H40UI
    Const SERVO_ADC_IN_BITMASK_PTA3 = &H80UI
    Const SERVO_ADC_IN_BITMASK_PTA4 = &H100UI
    Const SERVO_ADC_IN_BITMASK_PTA5 = &H200UI
    Const SERVO_ADC_IN_BITMASK_PTA6 = &H400UI
    Const SERVO_ADC_IN_BITMASK_PTA7 = &H800UI
    Const SERVO_ADC_IN_BITMASK_PTSTART = &H1000UI
    Const SERVO_ADC_IN_BITMASK_STOP = &H2000UI
    Const SERVO_ADC_IN_BITMASK_PJOG = &H4000UI
    Const SERVO_ADC_IN_BITMASK_NJOG = &H8000UI
    Const SERVO_ADC_IN_BITMASK_ALARMRESET = &H10000UI
    Const SERVO_ADC_IN_BITMASK_SERVOON = &H20000UI
    Const SERVO_ADC_IN_BITMASK_PAUSE = &H40000UI
    Const SERVO_ADC_IN_BITMASK_ORIGINSEARCH = &H80000UI
    Const SERVO_ADC_IN_BITMASK_TEACHING = &H100000UI
    Const SERVO_ADC_IN_BITMASK_ESTOP = &H200000UI
    Const SERVO_ADC_IN_BITMASK_JPTIN0 = &H400000UI
    Const SERVO_ADC_IN_BITMASK_JPTIN1 = &H800000UI
    Const SERVO_ADC_IN_BITMASK_JPTIN2 = &H1000000UI
    Const SERVO_ADC_IN_BITMASK_JPTSTART = &H2000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN0 = &H4000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN1 = &H8000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN2 = &H10000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN3 = &H20000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN4 = &H40000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN5 = &H80000000UI
    Const SERVO_ADC_IN_BITMASK_USERIN6 = &H200UI
    Const SERVO_ADC_IN_BITMASK_USERIN7 = &H400UI
    Const SERVO_ADC_IN_BITMASK_USERIN8 = &H800UI

    '// Output Bit-mask list.
    Const SERVO_ADC_OUT_BITMASK_COMPAREOUT = &H1UI
    Const SERVO_ADC_OUT_BITMASK_INPOSITION = &H2UI
    Const SERVO_ADC_OUT_BITMASK_ALARM = &H4UI
    Const SERVO_ADC_OUT_BITMASK_MOVING = &H8UI
    Const SERVO_ADC_OUT_BITMASK_ACCDEC = &H10UI
    Const SERVO_ADC_OUT_BITMASK_ACK = &H20UI
    Const SERVO_ADC_OUT_BITMASK_END = &H40UI
    Const SERVO_ADC_OUT_BITMASK_ALARMBLINK = &H80UI
    Const SERVO_ADC_OUT_BITMASK_ORGSEARCHOK = &H100UI
    Const SERVO_ADC_OUT_BITMASK_SERVOREADY = &H200UI
    '/static const DWORD	SERVO_ADC_OUT_BITMASK_RESERVED	= 0x00000400;
    Const SERVO_ADC_OUT_BITMASK_BRAKE = &H800UI
    Const SERVO_ADC_OUT_BITMASK_PTOUT0 = &H1000UI
    Const SERVO_ADC_OUT_BITMASK_PTOUT1 = &H2000UI
    Const SERVO_ADC_OUT_BITMASK_PTOUT2 = &H4000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT0 = &H8000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT1 = &H10000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT2 = &H20000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT3 = &H40000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT4 = &H80000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT5 = &H100000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT6 = &H200000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT7 = &H400000UI
    Const SERVO_ADC_OUT_BITMASK_USEROUT8 = &H800000UI
#End Region

#Region "Functions"
    Public Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean

        m_bIsConnected = False
        m_Config = config
        Dim Buf() As String = Nothing

        Dim nType As Byte
        Dim lPBuff(255) As Byte
        Try
            Buf = m_Config.sSerialInfo.sPortName.Split("M")
            If Buf.Length <> 1 Then
                nPortNo = Buf(1)
                If FAS_Connect(nPortNo, m_Config.sSerialInfo.nBaudRate) = False Then
                    Return False
                Else
                    For i As Integer = 0 To m_MotionSettins.Length - 1
                        If FAS_IsSlaveExist(nPortNo, i) = False Then
                            Return False
                        End If

                        If GetSlaveInfo(nPortNo, i, nType, lPBuff, lPBuff.Length) = False Then Return False
                    Next

                End If

                m_bIsConnected = True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Sub Disconnection()
        Try
            FAS_Close(nPortNo)
            m_bIsConnected = False
        Catch ex As Exception

        End Try
    End Sub

    Public Function SetInofos(ByVal iSlaveNo As Integer, ByVal sInfos() As CDevEZISERVOPLUSR.sMotionParams) As Boolean
        Dim cnt_Axis As Integer = m_MotionSettins.Length

        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGSPEED, sInfos(iSlaveNo).sOriginInofos.nOriginSpeed) = False Then Return False 'Origin Speed
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGSEARCHSPEED, sInfos(iSlaveNo).sOriginInofos.nOriginSearchSpeed) = False Then Return False 'Origin SearchSpeed
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISSTARTSPEED, sInfos(iSlaveNo).sSingleMoveInfos.StartSpeed) = False Then Return False
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISACCTIME, sInfos(iSlaveNo).sSingleMoveInfos.nAccelSpeed) = False Then Return False
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISDECTIME, sInfos(iSlaveNo).sSingleMoveInfos.nDecelSpeed) = False Then Return False
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGACCDECTIME, sInfos(iSlaveNo).sOriginInofos.nOriginAccelDecelSpeed) = False Then Return False
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_JOGLOWSPEED, sInfos(iSlaveNo).sSingleMoveInfos.StartSpeed) = False Then Return False
        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_JOGACCDECTIME, sInfos(iSlaveNo).sSingleMoveInfos.nAccelSpeed) = False Then Return False

        m_MotionSettins = sInfos
        Return True
    End Function

    Public Function GetInfos(ByVal iSlaveNo As Integer, ByRef sInfos As CDevEZISERVOPLUSR.sMotionParams) As Boolean
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGSPEED, sInfos.sOriginInofos.nOriginSpeed) = False Then Return False 'Origin Speed
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGSEARCHSPEED, sInfos.sOriginInofos.nOriginSearchSpeed) = False Then Return False 'Origin SearchSpeed
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISSTARTSPEED, sInfos.sSingleMoveInfos.StartSpeed) = False Then Return False
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISACCTIME, sInfos.sSingleMoveInfos.nAccelSpeed) = False Then Return False
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_AXISDECTIME, sInfos.sSingleMoveInfos.nDecelSpeed) = False Then Return False
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGACCDECTIME, sInfos.sOriginInofos.nOriginAccelDecelSpeed) = False Then Return False
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_JOGLOWSPEED, sInfos.sSingleMoveInfos.StartSpeed) = False Then Return False
        If GetParameter(nPortNo, iSlaveNo, eParameter.SERVO_JOGACCDECTIME, sInfos.sSingleMoveInfos.nAccelSpeed) = False Then Return False
        Return True
    End Function

    Public Function InitializeMotion(ByVal sInfos() As sMotionParams) As Boolean

        m_MotionSettins = sInfos.Clone

        Dim cnt_Axis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To cnt_Axis - 1
            '  If OutputOn(i) = False Then Return False

            If SetParameter(nPortNo, i, eParameter.SERVO_ORGSPEED, sInfos(i).sOriginInofos.nOriginSpeed) = False Then Return False 'Origin Speed
            If SetParameter(nPortNo, i, eParameter.SERVO_ORGSEARCHSPEED, sInfos(i).sOriginInofos.nOriginSearchSpeed) = False Then Return False 'Origin SearchSpeed
            If SetParameter(nPortNo, i, eParameter.SERVO_AXISSTARTSPEED, sInfos(i).sSingleMoveInfos.StartSpeed) = False Then Return False
            If SetParameter(nPortNo, i, eParameter.SERVO_AXISACCTIME, sInfos(i).sSingleMoveInfos.nAccelSpeed) = False Then Return False
            If SetParameter(nPortNo, i, eParameter.SERVO_AXISDECTIME, sInfos(i).sSingleMoveInfos.nDecelSpeed) = False Then Return False
            If SetParameter(nPortNo, i, eParameter.SERVO_ORGACCDECTIME, sInfos(i).sOriginInofos.nOriginAccelDecelSpeed) = False Then Return False
            If SetParameter(nPortNo, i, eParameter.SERVO_JOGLOWSPEED, sInfos(i).sSingleMoveInfos.StartSpeed) = False Then Return False
            If SetParameter(nPortNo, i, eParameter.SERVO_JOGACCDECTIME, sInfos(i).sSingleMoveInfos.nAccelSpeed) = False Then Return False
        Next

        '    If MoveOriginSigleAxis(nPortNo, iSlaveNo) = False Then Return False

        Return True
    End Function

    Public Function AxisHomeCheck(ByVal nAxis As Integer) As Boolean
        Return True
    End Function

    Public Function Homming(Optional ByVal bSerchHomePosition As Boolean = True) As Boolean
        Dim uFlag As UInteger
        Dim dwAxisStatus As UInteger = 0
        Dim cnt_Axis As Integer = m_MotionSettins.Length

        'For i As Integer = 1 To 2
        '    If SetParameter(nPortNo, i, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False

        '    Application.DoEvents()
        '    Thread.Sleep(1000)

        '    If MoveOriginSigleAxis(nPortNo, i) = False Then Return False

        '    Do
        '        Application.DoEvents()
        '        Thread.Sleep(5)

        '        GetAxisStatus(nPortNo, i, dwAxisStatus)
        '        uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

        '    Loop Until uFlag = &H6D80000 Or uFlag = &H2D80000

        '    If MoveStop(nPortNo, i) = False Then Return False
        'Next

        'If SetParameter(nPortNo, m_nXAxisIndex, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False

        'Application.DoEvents()
        'Thread.Sleep(1000)

        'If MoveOriginSigleAxis(nPortNo, m_nXAxisIndex) = False Then Return False

        'Do
        '    Application.DoEvents()
        '    Thread.Sleep(5)

        '    GetAxisStatus(nPortNo, m_nXAxisIndex, dwAxisStatus)
        '    uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

        'Loop Until uFlag = &H6D80000 Or uFlag = &H2D80000

        'If MoveStop(nPortNo, m_nXAxisIndex) = False Then Return False

        If SetParameter(nPortNo, 2, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False

        Application.DoEvents()
        Thread.Sleep(1000)

        If MoveOriginSigleAxis(nPortNo, 2) = False Then Return False

        Do
            Application.DoEvents()
            Thread.Sleep(5)

            GetAxisStatus(nPortNo, 2, dwAxisStatus)
            uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

        Loop Until uFlag = &H6D80000 Or uFlag = &H2D80000

        If MoveStop(nPortNo, 2) = False Then Return False


        For i As Integer = 0 To 1
            If SetParameter(nPortNo, i, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False

            Application.DoEvents()
            Thread.Sleep(1000)

            If MoveOriginSigleAxis(nPortNo, i) = False Then Return False

            Do
                Application.DoEvents()
                Thread.Sleep(5)

                GetAxisStatus(nPortNo, i, dwAxisStatus)
                uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

            Loop Until uFlag = &H6D80000 Or uFlag = &H2D80000

            If MoveStop(nPortNo, i) = False Then Return False
        Next

        Dim m_bThetaAxisUsed As Boolean = False

        For idx As Integer = 0 To m_MotionSettins.Length - 1
            If m_MotionSettins(idx).eMotionAxis = eMotionAxis.eTheta_Axis Then
                m_bThetaAxisUsed = True
                Exit For
            End If
        Next

        If m_bThetaAxisUsed = True Then
            If SetParameter(nPortNo, m_nThetaAxisIndex, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False
            Application.DoEvents()
            Thread.Sleep(1000)

            If MoveOriginSigleAxis(nPortNo, m_nThetaAxisIndex) = False Then Return False

            Do
                Application.DoEvents()
                Thread.Sleep(5)

                GetAxisStatus(nPortNo, m_nThetaAxisIndex, dwAxisStatus)
                uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

            Loop Until uFlag = &H6D80000 Or uFlag = &H2D80000
            If MoveStop(nPortNo, m_nThetaAxisIndex) = False Then Return False
            Thread.Sleep(500)
            If ViewAngleMove(6000, True, True) = False Then Return False

        End If


        For i As Integer = 0 To cnt_Axis - 1
            If ClearPosition(nPortNo, i) = False Then Return False
        Next

            '      If OutputOff(i) = False Then Return False


            Return True
    End Function

    Public Function FinalizeMotion(ByVal iSlaveNo As Integer) As Boolean
        Dim uFlag As UInteger
        Dim dwAxisStatus As UInteger = 0
        ' Dim cnt_Axis As Integer = m_MotionSettins.Length

        If SetParameter(nPortNo, iSlaveNo, eParameter.SERVO_ORGMETHOD, 0) = False Then Return False
        Application.DoEvents()
        Thread.Sleep(10)
        If MoveOriginSigleAxis(nPortNo, iSlaveNo) = False Then Return False

        Do
            Application.DoEvents()
            Thread.Sleep(5)
            GetAxisStatus(nPortNo, iSlaveNo, dwAxisStatus)
            uFlag = dwAxisStatus  'Or sEziservoAxisStatus.FFLAG_MOTIONING

        Loop Until uFlag = &H2D80000

        If MoveStop(nPortNo, iSlaveNo) = False Then Return False
        '      If OutputOff(iSlaveNo) = False Then Return False

        Return True
    End Function

    Public Function MovingStop(ByVal iSlaveNo As Integer) As Boolean
        If MoveStop(nPortNo, iSlaveNo) = False Then Return False

        Return True
    End Function

    Public Function MovingStopAllAxis() As Boolean
        Dim cnt_Axis As Integer = m_MotionSettins.Length

        For i As Integer = 0 To cnt_Axis - 1
            If MoveStop(nPortNo, i) = False Then Return False
        Next


        Return True
    End Function

    Public Function SERVO_ON() As Boolean
        Dim cnt_Axis As Integer
        cnt_Axis = m_MotionSettins.Length
        For i As Integer = 0 To cnt_Axis - 1
            Application.DoEvents()
            Thread.Sleep(500)   '500초 강제딜레이 Servo on,off 시
            If ServoEnable(nPortNo, i, eOnOFF.eON) = False Then
                AlarmReset(i)
            End If
        Next

        Return True
    End Function

    Public Function SERVO_OFF() As Boolean
        Dim cnt_Axis As Integer
        cnt_Axis = m_MotionSettins.Length
        For i As Integer = 0 To cnt_Axis - 1
            If ServoEnable(nPortNo, i, eOnOFF.eOFF) = False Then Return False
        Next
        Return True
    End Function

    Public Overloads Function SetPosition(ByVal iSlaveNo As Integer, ByVal value As Double, ByVal sInfos As sMotionParams) As Boolean
        Dim nAbsPos As Integer = CInt(value)
        Dim ret As Integer = 0
        Dim dwAxisStatus As UInteger = 0
        Dim uFlag As UInteger

        Application.DoEvents()
        Thread.Sleep(100)

        If MoveSingleAxisAbsPos(nPortNo, iSlaveNo, nAbsPos, sInfos.sSingleMoveInfos.nVelocity) = False Then Return False

        Do
            Application.DoEvents()
            Thread.Sleep(5)
            GetAxisStatus(nPortNo, iSlaveNo, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        Return True
    End Function

    Public Overloads Function SetPosition(ByVal setPos As String) As Boolean

        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        ' If arrPos.Length < 3 Then Return False
        If SetPosition(arrPos) = False Then
            Return False
        End If
        Return True
    End Function

    Public Overloads Function SetPosition(ByVal value() As String) As Boolean

        'Dim nAbsPos() As Integer
        Dim ret As Integer = 0
        Dim dwAxisStatus As UInteger = 0
        Dim uFlag As UInteger

        Dim dDistance() As Double = Nothing
        Dim dPos() As Double = Nothing

        If value.Length = 4 Then
            ReDim dDistance(2)
            ReDim dPos(2)

            If m_CalDataRealDistanceUse = True Then
                dDistance(0) = CDbl(value(1)) * m_CalDataRealDistance_X
                dDistance(1) = CDbl(value(2)) * m_CalDataRealDistance_Y
                dDistance(2) = CDbl(value(3)) * m_CalDataRealDistance_Z
                '  dDistance(3) = 0
            Else
                dDistance(0) = CDbl(value(1))
                dDistance(1) = CDbl(value(2))
                dDistance(2) = CDbl(value(3)) '+ 119.644
                'dDistance(3) = 0
            End If

            dPos(0) = CDbl(value(1))
            dPos(1) = CDbl(value(2))
            dPos(2) = CDbl(value(3))

            For axis As Integer = 0 To dDistance.Length - 1
                If m_MotionSettins(axis).bDirectionInverting = True Then
                    dDistance(axis) = dDistance(axis)
                Else
                    dDistance(axis) = -dDistance(axis)
                End If
            Next

            m_Distance = dDistance.Clone



            For i As Integer = 0 To value.Length - 3
                Application.DoEvents()
                Thread.Sleep(10)

                If MoveSingleAxisAbsPos(nPortNo, i, dDistance(i), m_MotionSettins(i).sSingleMoveInfos.nVelocity) = False Then Return False

                Do
                    Application.DoEvents()
                    GetAxisStatus(nPortNo, i, dwAxisStatus)

                    uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
                Loop Until uFlag = &H0
            Next

            If MoveSingleAxisAbsPos(nPortNo, 2, dDistance(2), m_MotionSettins(2).sSingleMoveInfos.nVelocity) = False Then Return False

            Do
                Application.DoEvents()
                GetAxisStatus(nPortNo, 2, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0
        Else
            ReDim dDistance(0)
            ReDim dPos(0)

            If m_CalDataRealDistanceUse = True Then
                dDistance(0) = CDbl(value(1)) * m_CalDataRealDistance_Theta_Y
            Else
                dDistance(0) = CDbl(value(1))
            End If

            dPos(0) = CDbl(value(1))

            For axis As Integer = 0 To dDistance.Length - 1
                If m_MotionSettins(3).bDirectionInverting = True Then
                    dDistance(0) = dDistance(0)
                Else
                    dDistance(0) = -dDistance(0)
                End If
            Next

            m_Distance = dDistance.Clone

            If MoveSingleAxisAbsPos(nPortNo, m_nThetaYAxisIndex, dDistance(0), m_MotionSettins(3).sSingleMoveInfos.nVelocity) = False Then Return False

            Do
                Application.DoEvents()
                GetAxisStatus(nPortNo, m_nThetaYAxisIndex, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0

            'If MoveSingleAxisAbsPos(nPortNo, 0, dDistance(0), m_MotionSettins(0).sSingleMoveInfos.nVelocity) = False Then Return False

            'Do
            '    Application.DoEvents()
            '    GetAxisStatus(nPortNo, 0, dwAxisStatus)

            '    uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            'Loop Until uFlag = &H0

        End If

        Return True
    End Function

    Public Function AxisMove(ByVal nAxis As CDevMotion_AJIN.eMotionAxis, ByVal distance As Double, Optional ByVal absolutePos As Boolean = False) As Boolean

        'If myParent.g_AlarmStatus.Contains(CDevPLCCommonNode.eDISignal.eCylinder) = True Then
        '    Return False
        'End If
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger

        Dim dDistance As Double

        Dim nAxisIndex As Integer = nAxis

        Dim dAxisCalDataRealDistance As Double

        If m_MotionSettins(nAxisIndex).eMotionAxis <> nAxis + 1 Then
            Return False
        End If


        Select Case nAxisIndex
            Case 0
                dAxisCalDataRealDistance = m_CalDataRealDistance_X
            Case 1
                dAxisCalDataRealDistance = m_CalDataRealDistance_Y
            Case 2
                dAxisCalDataRealDistance = m_CalDataRealDistance_Z
            Case 3
                dAxisCalDataRealDistance = m_CalDataRealDistance_Theta_Y
            Case 4
                dAxisCalDataRealDistance = m_CalDataRealDistance_Theta
                'Case eMotionAxis.eX_Axis
                '    dAxisCalDataRealDistance = m_CalDataRealDistance_X
                'Case eMotionAxis.eY_Axis
                '    dAxisCalDataRealDistance = m_CalDataRealDistance_Y
                'Case eMotionAxis.eZ_Axis
                '    dAxisCalDataRealDistance = m_CalDataRealDistance_Z
                'Case eMotionAxis.eTheta_Axis
                '    dAxisCalDataRealDistance = m_CalDataRealDistance_Theta
        End Select


        If m_CalDataRealDistanceUse = True Then
            dDistance = distance * dAxisCalDataRealDistance
        End If

        If m_MotionSettins(nAxisIndex).eMotionAxis = m_MotionSettins(nAxisIndex).bDirectionInverting Then
            If m_MotionSettins(nAxisIndex).bDirectionInverting = False Then
                dDistance = -dDistance
            End If
        Else

        End If

        'nRealAxisIndex = m_MotionSettins(nAxisIndex).eMotionAxisInverting - 1
        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, nAxisIndex, dDistance, m_MotionSettins(nAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '상대좌표 s자 구동

        Else
            If MoveSingleAxisAbsPos(nPortNo, nAxisIndex, dDistance, m_MotionSettins(nAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(5)

            GetAxisStatus(nPortNo, nAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(nAxisIndex)

        Return True
    End Function

    Public Function XMove(ByVal value As Double, Optional absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_X
        End If

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        Thread.Sleep(100)
        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then   
            If MoveSingleAxisIncPos(nPortNo, m_nXAxisIndex, dDistance, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '상대좌표 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nXAxisIndex, dDistance, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If
        Do
            Application.DoEvents()
            Thread.Sleep(5)

            GetAxisStatus(nPortNo, m_nXAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(m_nXAxisIndex)

        Return True
    End Function


    Public Function YMove(ByVal value As Double, Optional absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_Y
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nYAxisIndex, dDistance, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nYAxisIndex, dDistance, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(5)

            GetAxisStatus(nPortNo, m_nYAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0
        MovingStop(m_nYAxisIndex)

        Return True
    End Function

    Public Function ThetaYMove(ByVal value As Double, Optional absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nThetaYAxisIndex).eMotionAxis <> eMotionAxis.eThetaY_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_Theta_Y
        End If

        If m_MotionSettins(m_nThetaYAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nThetaYAxisIndex, dDistance, m_MotionSettins(m_nThetaYAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nThetaYAxisIndex, dDistance, m_MotionSettins(m_nThetaYAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(5)

            GetAxisStatus(nPortNo, m_nThetaYAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(m_nThetaYAxisIndex)

        Return True
    End Function

    Public Function ZMove(ByVal value As Double, Optional absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis <> eMotionAxis.eZ_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_Z
        End If

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        Application.DoEvents()
        Thread.Sleep(50)


        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nZAxisIndex, dDistance, m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nZAxisIndex, dDistance, m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(50)

            GetAxisStatus(nPortNo, m_nZAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(m_nZAxisIndex)

        Return True
    End Function

    Public Function ACFXMove(ByVal value As Double, Optional ByVal absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_X
        End If

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        Thread.Sleep(100)
        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nXAxisIndex, dDistance, 4000) = False Then Return False '상대좌표 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nXAxisIndex, dDistance, 4000) = False Then Return False '절대좌표 s자 구동
        End If
        Do
            Application.DoEvents()
            Thread.Sleep(10)

            GetAxisStatus(nPortNo, m_nXAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(m_nXAxisIndex)

        Return True
    End Function

    Public Function ACFYMove(ByVal value As Double, Optional ByVal absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_Y
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        Thread.Sleep(100)

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nYAxisIndex, dDistance, 10000) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nYAxisIndex, dDistance, 10000) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(10)

            GetAxisStatus(nPortNo, m_nYAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0
        MovingStop(m_nYAxisIndex)


        Return True
    End Function

    Public Function ACFZMove(ByVal value As Double, Optional ByVal absolutePos As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis <> eMotionAxis.eZ_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            dDistance = value * m_CalDataRealDistance_Z
        End If

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If
        Application.DoEvents()
        Thread.Sleep(100)

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nZAxisIndex, dDistance, 4000) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            If MoveSingleAxisAbsPos(nPortNo, m_nZAxisIndex, dDistance, 4000) = False Then Return False '절대좌표 s자 구동
        End If

        Do
            Application.DoEvents()
            Thread.Sleep(5)
            GetAxisStatus(nPortNo, m_nZAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0

        MovingStop(m_nZAxisIndex)

        Return True
    End Function

    Public Function ViewAngleMove(ByVal value As Double, Optional ByVal absolutePos As Boolean = False, Optional ByVal bFirst As Boolean = False) As Boolean
        Dim dDistance As Double
        Dim dwAxisStatus As UInteger
        Dim uFlag As UInteger
        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            Return False
        End If

        If m_CalDataRealDistanceUse = True Then
            If bFirst = True Then
                dDistance = value
            Else
                dDistance = value * m_CalDataRealDistance_Theta
            End If

        End If

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = False Then
            dDistance = -dDistance
        End If

        '    CFS20set_max_speed(0, dVelocity)
        If absolutePos = False Then
            If MoveSingleAxisIncPos(nPortNo, m_nThetaAxisIndex, dDistance, m_MotionSettins(m_nThetaAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False ' 상대좌표 비대칭 s자 구동
        Else
            dDistance = dDistance
            If MoveSingleAxisAbsPos(nPortNo, m_nThetaAxisIndex, dDistance, m_MotionSettins(m_nThetaAxisIndex).sSingleMoveInfos.nVelocity) = False Then Return False '절대좌표 s자 구동
        End If
        Do
            Application.DoEvents()
            Thread.Sleep(5)
            GetAxisStatus(nPortNo, m_nThetaAxisIndex, dwAxisStatus)

            uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
        Loop Until uFlag = &H0
        Thread.Sleep(100)
        MovingStop(m_nThetaAxisIndex)

        Return True
    End Function

    Public Function SetPositionXYAxisMovingFirst(ByVal setPos As String) As Boolean
        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        If arrPos.Length < 3 Then Return False
        If SetPositionYZAxisMovingFirst(arrPos) = False Then Return False

        Return True
    End Function

    Public Function SetPositionXYAxisMovingFirst(ByVal inPosition() As String) As Boolean

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length
        Dim dwAxisStatus As UInteger = 0
        Dim uFlag As UInteger
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
                If m_MotionSettins(axis).bDirectionInverting = True Then
                    dDistance(axis) = dDistance(axis)
                Else
                    dDistance(axis) = -dDistance(axis)
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


        ''Z축의 측정 좌료가 Limit 센싱 위치, 즉 최대 거리로 설정 되었을 경우,
        ''Homming에서 기준이 조금이라도 틀어지면, (홈을 조금이라도 지나면) 실제 움직일수 있는 거리는 줄어 들게 되고
        ''설정 좌표와, 구동 좌료를 읽은 값이 Mismatch가 되면서 좌표가 잘못 이동된것으로 표시되는 문제가 있음
        ''따라서, 아래의 루틴은 주석 처리한다.
        'Do
        '    For cnt_axis = 0 To 1
        '        CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '절대좌표 s자 구동
        '        Application.DoEvents()
        '        Thread.Sleep(50)
        '    Next

        '    MoveCompletedAllAxis()
        '    Application.DoEvents()
        '    Thread.Sleep(50)

        '    If nNumAxis > 2 Then '
        '        CFS20start_s_move(2, dDistance(2), m_MotionSettins(2).dVelocity, m_MotionSettins(2).dAcceleration)  '절대좌표 s자 구동
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
        '    'LEX : Error Message 추가
        '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_POS_MISMATCH, sTemp)
        'End If

        'If cntTimeOut > 10 Then
        '    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_CHECK_FAILED)
        '    Return False
        'End If


        'Loop Until chkPos






        For cnt_axis = 0 To 1
            '   CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)


            MoveSingleAxisAbsPos(nPortNo, cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).sSingleMoveInfos.nVelocity) '절대좌표 s자 구동
            Application.DoEvents()
            Thread.Sleep(100)

            Do
                Application.DoEvents()
                Thread.Sleep(5)
                GetAxisStatus(nPortNo, cnt_axis, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0
        Next

        MovingStopAllAxis()
        Application.DoEvents()
        Thread.Sleep(10)

        Dim dComPos() As Double = Nothing
        'ReDim dComPos(m_MotionSettins.Length - 1)
        'For i As Integer = 0 To m_MotionSettins.Length - 1
        '    GetCommandPos(i, dComPos(i))
        'Next

        GetAllCommandPos(dComPos)

        Application.DoEvents()
        Thread.Sleep(1000)
        If nNumAxis > 2 Then '
            MoveSingleAxisAbsPos(nPortNo, m_nZAxisIndex, dDistance(m_nZAxisIndex), m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity)
            'CFS20start_s_move(2, dDistance(2), m_MotionSettins(2).dVelocity, m_MotionSettins(2).dAcceleration)  '절대좌표 s자 구동

            Do
                Application.DoEvents()
                Thread.Sleep(5)
                GetAxisStatus(nPortNo, m_nZAxisIndex, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0

        End If
        'For cnt_axis = 0 To 1
        '    If Format(CDbl(inPosition(cnt_axis + 1)), "0") <> Format(dComPos(cnt_axis), "0") Then

        '        '   CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)  '절대좌표 s자 구동
        '        Application.DoEvents()
        '        Thread.Sleep(50)
        '        ' myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_CMD_POS_MISMATCH, Format(inPosition(cnt_axis + 1), "0.0") & Format(CStr(dComPos(cnt_axis)), "0.0"))
        '        FinalizeMotionAllAxis()
        '        MovingStopAllAxis()
        '        Application.DoEvents()
        '        Thread.Sleep(100)
        '        Return False
        '    End If
        'Next

        '       MovingStopAllAxis()

        MovingStopAllAxis()
        Application.DoEvents()
        Thread.Sleep(10)

        Return True
    End Function

    Public Function SetPositionYZAxisMovingFirst(ByVal inPosition() As String) As Boolean

        Dim cnt_axis As Integer
        Dim nNumAxis As Integer = m_MotionSettins.Length
        Dim dwAxisStatus As UInteger = 0
        Dim uFlag As UInteger
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
                If m_MotionSettins(axis).bDirectionInverting = True Then
                    dDistance(axis) = dDistance(axis)
                Else
                    dDistance(axis) = -dDistance(axis)
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


        For cnt_axis = 0 To 1
            '   CFS20start_s_move(cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).dVelocity, m_MotionSettins(cnt_axis).dAcceleration)


            MoveSingleAxisAbsPos(nPortNo, cnt_axis, dDistance(cnt_axis), m_MotionSettins(cnt_axis).sSingleMoveInfos.nVelocity) '절대좌표 s자 구동
            Application.DoEvents()
            Thread.Sleep(10)

            Do
                Application.DoEvents()
                Thread.Sleep(5)
                GetAxisStatus(nPortNo, cnt_axis, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0
        Next

        MovingStopAllAxis()
        Application.DoEvents()
        Thread.Sleep(10)
        Dim dComPos() As Double = Nothing

        GetAllCommandPos(dComPos)

        Application.DoEvents()
        Thread.Sleep(1000)

        If nNumAxis > 2 Then '
            MoveSingleAxisAbsPos(nPortNo, m_nZAxisIndex, dDistance(m_nZAxisIndex), m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity)
            'CFS20start_s_move(2, dDistance(2), m_MotionSettins(2).dVelocity, m_MotionSettins(2).dAcceleration)  '절대좌표 s자 구동

            Do
                Application.DoEvents()
                Thread.Sleep(5)
                GetAxisStatus(nPortNo, m_nZAxisIndex, dwAxisStatus)

                uFlag = dwAxisStatus And sEziservoAxisStatus.FFLAG_MOTIONING
            Loop Until uFlag = &H0

        End If



        MovingStopAllAxis()
        Application.DoEvents()
        Thread.Sleep(10)

        Return True
    End Function

    Public Function GetActualPosition() As Double()
        Dim cnt_axis As Integer = m_MotionSettins.Length
        Dim pos() As Double = Nothing
        Dim pulsepos() As Integer
        ReDim pulsepos(cnt_axis - 1)
        ReDim pos(cnt_axis - 1)
        For i As Integer = 0 To cnt_axis - 1
            GetActualPos(i, pulsepos(i))

            If pulsepos(0) <> 0 Then
                pos(0) = pulsepos(0)
            Else
                pos(0) = 0
            End If
            If pulsepos(1) <> 0 Then
                pos(1) = pulsepos(1)
            Else
                pos(1) = 0
            End If
            If pulsepos(2) <> 0 Then
                pos(2) = pulsepos(2)
            Else
                pos(2) = 0
            End If

            If pulsepos.Length = 4 Then
                If pulsepos(3) <> 0 Then
                    pos(3) = pulsepos(3)
                Else
                    pos(3) = 0
                End If

            End If

            'If pulsepos(i) <> 0 Then
            '    pos(i) = pulsepos(i)
            'Else
            '    pos(i) = 0
            'End If

        Next
       

        Return pos
    End Function

    Public Function GetCommandPosition() As Double()
        Dim cnt_axis As Integer = m_MotionSettins.Length
        Dim pos() As Double = Nothing
        Dim pulsepos() As Integer
        ReDim pulsepos(cnt_axis - 1)
        ReDim pos(cnt_axis - 1)

        Dim dFactor As Double


        For i As Integer = 0 To cnt_axis - 1
            Select Case i
                Case 0
                    dFactor = m_CalDataRealDistance_X
                Case 1
                    dFactor = m_CalDataRealDistance_Y
                Case 2
                    dFactor = m_CalDataRealDistance_Z
                Case 3
                    dFactor = m_CalDataRealDistance_Theta_Y
                Case 4
                    dFactor = m_CalDataRealDistance_Theta
            End Select

            If GetCommandPos(i, pulsepos(i)) = True Then
                If pulsepos(0) <> 0 Then
                    pos(0) = pulsepos(0) / m_CalDataRealDistance_X
                Else
                    pos(0) = 0
                End If
                If pulsepos(1) <> 0 Then
                    pos(1) = pulsepos(1) / m_CalDataRealDistance_Y
                Else
                    pos(1) = 0
                End If
                If pulsepos(2) <> 0 Then
                    pos(2) = pulsepos(2) / m_CalDataRealDistance_Z
                Else
                    pos(2) = 0
                End If
              

                If pulsepos.Length = 5 Then
                    If pulsepos(4) <> 0 Then
                        pos(4) = pulsepos(4) / m_CalDataRealDistance_Theta
                    Else
                        pos(4) = 0
                    End If
                End If
            Else
                Return Nothing
            End If

            'If pulsepos(i) <> 0 Then
            '    pos(i) = pulsepos(i) / dFactor
            'Else
            '    pos(i) = 0
            'End If
        Next
       
        Return pos
    End Function

    Public Function GetAllCommandPos(ByRef pos() As Double) As Boolean
        Dim cnt_axis As Integer = m_MotionSettins.Length
        Dim pulsepos() As Integer
        ReDim pulsepos(cnt_axis - 1)
        ReDim pos(cnt_axis - 1)

        Dim dFactor As Double

        For i As Integer = 0 To cnt_axis - 1

            'Select Case i
            '    Case 0
            '        dFactor = m_CalDataRealDistance_X
            '    Case 1
            '        dFactor = m_CalDataRealDistance_Y
            '    Case 2
            '        dFactor = m_CalDataRealDistance_Z
            '    Case 3
            '        dFactor = m_CalDataRealDistance_Theta
            'End Select

            If GetCommandPos(i, pulsepos(i)) = True Then
                If pulsepos(0) <> 0 Then
                    pos(0) = pulsepos(0) / m_CalDataRealDistance_X
                Else
                    pos(0) = 0
                End If
                If pulsepos(1) <> 0 Then
                    pos(1) = pulsepos(1) / m_CalDataRealDistance_Y
                Else
                    pos(1) = 0
                End If
                If pulsepos(2) <> 0 Then
                    pos(2) = pulsepos(2) / m_CalDataRealDistance_Z
                Else
                    pos(2) = 0
                End If
                'If pulsepos(3) <> 0 Then
                '    pos(3) = pulsepos(3) / m_CalDataRealDistance_Theta_Y
                'Else
                '    pos(3) = 0
                'End If

                If pulsepos.Length = 4 Then
                    If pulsepos(4) <> 0 Then
                        pos(4) = pulsepos(3) / m_CalDataRealDistance_Theta
                    Else
                        pos(4) = 0
                    End If

                End If
            Else
                Return False
            End If

           
            'If pulsepos(i) <> 0 Then
            '    pos(i) = pulsepos(i) / dFactor
            'Else
            '    pos(i) = 0
            'End If

        Next
      

        Return True
    End Function

    Public Function JogZUpMove() As Boolean
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis < eMotionAxis.eZ_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim byRst As Byte

        Dim dDirVelocity As Double
        Dim dVelDir As Double   '0 : -jog / 1 : +jog

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = True Then
            '   dDirVelocity = -m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nSingleMoveSpeed
            dVelDir = 0
        Else
            ' dDirVelocity = m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nSingleMoveSpeed
            dVelDir = 1
        End If

        If MoveVelocity(nPortNo, m_nZAxisIndex, m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogZDownMove() As Boolean
        If m_MotionSettins(m_nZAxisIndex).eMotionAxis < eMotionAxis.eZ_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim byRst As Byte

        Dim dDirVelocity As Double
        Dim dVelDir As Double   '0 : -jog / 1 : +jog

        If m_MotionSettins(m_nZAxisIndex).bDirectionInverting = True Then
            '   dDirVelocity = -m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nSingleMoveSpeed
            dVelDir = 1
        Else
            ' dDirVelocity = m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nSingleMoveSpeed
            dVelDir = 0
        End If

        If MoveVelocity(nPortNo, m_nZAxisIndex, m_MotionSettins(m_nZAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogYuPMove() As Boolean
        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double
        Dim dVelDir As Double
        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dVelDir = 0
            ' dDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dVelDir = 1
            '  dDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        End If
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogYDownMove() As Boolean
        If m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dDirVelocity As Double
        Dim dVelDir As Double
        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dVelDir = 1
            ' dDirVelocity = -m_MotionSettins(m_nYAxisIndex).dVelocity
        Else
            dVelDir = 0
            '  dDirVelocity = m_MotionSettins(m_nYAxisIndex).dVelocity
        End If
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogXRYUpMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisVelDir As Double
        Dim dYAxisVelDir As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisVelDir = 0
        Else
            dXAxisVelDir = 1
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisVelDir = 0
        Else
            dYAxisVelDir = 1
        End If

        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dXAxisVelDir) = False Then Return False ' 연속구동 
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dYAxisVelDir) = False Then Return False ' 연속구동 
        '   CFS20v_s_move(m_nXAxisIndex, dXAxisDirVelocity, m_MotionSettins(m_nXAxisIndex).dAcceleration)  ' 연속구동
        '  CFS20v_s_move(m_nYAxisIndex, dYAxisDirVelocity, m_MotionSettins(m_nYAxisInde
        Return True
    End Function

    Public Function JogXRYDownMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dXAxisVelDir As Double
        Dim dYAxisVelDir As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisVelDir = 0
        Else
            dXAxisVelDir = 1
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisVelDir = 1
        Else
            dYAxisVelDir = 0
        End If

        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dXAxisVelDir) = False Then Return False ' 연속구동 
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dYAxisVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogXRMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dVelDir As Double


        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dVelDir = 0
        Else
            dVelDir = 1
        End If
        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 
        Return True
    End Function

    Public Function JogXLYDownMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim dXAxisVelDir As Double
        Dim dYAxisVelDir As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisVelDir = 1
        Else
            dXAxisVelDir = 0
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisVelDir = 1
        Else
            dYAxisVelDir = 0
        End If

        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dXAxisVelDir) = False Then Return False ' 연속구동 
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dYAxisVelDir) = False Then Return False ' 연속구동 

        Return True
    End Function

    Public Function JogXLYUpMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Or m_MotionSettins(m_nYAxisIndex).eMotionAxis <> eMotionAxis.eY_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim dXAxisVelDir As Double
        Dim dYAxisVelDir As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dXAxisVelDir = 1
        Else
            dXAxisVelDir = 0
        End If

        If m_MotionSettins(m_nYAxisIndex).bDirectionInverting = True Then
            dYAxisVelDir = 0
        Else
            dYAxisVelDir = 1
        End If

        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dXAxisVelDir) = False Then Return False ' 연속구동 
        If MoveVelocity(nPortNo, m_nYAxisIndex, m_MotionSettins(m_nYAxisIndex).sSingleMoveInfos.nVelocity, dYAxisVelDir) = False Then Return False ' 연속구동 

        Return True
    End Function

    Public Function JogXLMove() As Boolean
        If m_MotionSettins(m_nXAxisIndex).eMotionAxis <> eMotionAxis.eX_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim dVelDir As Double

        If m_MotionSettins(m_nXAxisIndex).bDirectionInverting = True Then
            dVelDir = 1
        Else
            dVelDir = 0
        End If
        If MoveVelocity(nPortNo, m_nXAxisIndex, m_MotionSettins(m_nXAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 

        Return True
    End Function

    Public Function JogThetaRMove() As Boolean
        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim dVelDir As Double

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = True Then
            dVelDir = 1
        Else
            dVelDir = 0
        End If

        If MoveVelocity(nPortNo, m_nThetaAxisIndex, m_MotionSettins(m_nThetaAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 

        Return True
    End Function

    Public Function JogThetaLMove() As Boolean
        If m_MotionSettins(m_nThetaAxisIndex).eMotionAxis <> eMotionAxis.eTheta_Axis Then
            MsgBox("The axis value is not correct.!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If
        Dim dVelDir As Double

        If m_MotionSettins(m_nThetaAxisIndex).bDirectionInverting = True Then
            dVelDir = 0
        Else
            dVelDir = 1
        End If

        If MoveVelocity(nPortNo, m_nThetaAxisIndex, m_MotionSettins(m_nThetaAxisIndex).sSingleMoveInfos.nVelocity, dVelDir) = False Then Return False ' 연속구동 

        Return True
    End Function

    Public Function GetSlaveInfo(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef nType As Byte, ByVal lPBuff() As Byte, ByVal nBuffSize As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetSlaveInfo(nPortNo, iSlaveNo, nType, lPBuff, nBuffSize)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If
        Return True
    End Function

    Public Function GetMotorInfo(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef nType As Byte, ByVal lPBuff() As Byte, ByVal nBuffSize As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetMotorInfo(nPortNo, iSlaveNo, nType, lPBuff, nBuffSize)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function


    Public Function SetAllParameters(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SaveAllParameters(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetParameter(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByVal iParamValue As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetParameter(nPortNo, iSlaveNo, iParamNo, iParamValue)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetParameter(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByRef iParamValue As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetParameter(nPortNo, iSlaveNo, iParamNo, iParamValue)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetROMParameter(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iParamNo As Byte, ByRef lRomParam As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetROMParameter(nPortNo, iSlaveNo, iParamNo, lRomParam)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function ServoEnable(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bMode As eOnOFF) As Boolean
        Dim ret As Integer = 0
        Dim bOnOff As Boolean
        Dim ErrorCode As Integer = 0
        If bMode = eOnOFF.eOFF Then
            bOnOff = False
        Else
            bOnOff = True
        End If
        ret = FAS_ServoEnable(nPortNo, iSlaveNo, bOnOff)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetIOInput(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwIOSetMask As UInteger, ByVal dwIOCLRMask As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetIOInput(nPortNo, iSlaveNo, dwIOSetMask, dwIOCLRMask)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetIOInput(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwIOInput As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetIOInput(nPortNo, iSlaveNo, dwIOInput)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetIOOutput(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwIOSetMask As UInteger, ByVal dwIOCLRMask As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetIOOutput(nPortNo, iSlaveNo, dwIOSetMask, dwIOCLRMask)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetIOOutput(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwIOOutput As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetIOOutput(nPortNo, iSlaveNo, dwIOOutput)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetIOAssignMap(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iIOPinNo As Byte, ByRef nIOLogic As Byte, ByRef bLevel As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetIOAssignMap(nPortNo, iSlaveNo, iIOPinNo, nIOLogic, bLevel)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetIOAssignMap(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal iIOPinNo As Byte, ByVal nLogicNo As Byte, ByVal bLevel As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetIOAssignMap(nPortNo, iSlaveNo, iIOPinNo, nLogicNo, bLevel)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function IOAssignMapReadROM(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_IOAssignMapReadROM(nPortNo, iSlaveNo)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetCommandPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lCmdPos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetCommandPos(nPortNo, iSlaveNo, lCmdPos)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function SetActualPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lActPos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_SetActualPos(nPortNo, iSlaveNo, lActPos)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetCommandPos(ByVal iSlaveNo As Byte, ByRef lCmdPos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetCommandPos(nPortNo, iSlaveNo, lCmdPos)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetActualPos(ByVal iSlaveNo As Byte, ByRef lActPos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetActualPos(nPortNo, iSlaveNo, lActPos)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetPosError(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lPosErr As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetPosError(nPortNo, iSlaveNo, lPosErr)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetActualVel(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lActVel As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetActualVel(nPortNo, iSlaveNo, lActVel)

        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function ClearPosition(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_ClearPosition(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetIOAxisStatus(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwInStatus As UInteger, ByRef dwOutStatus As UInteger, ByRef dwAxisStatus As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetIOAxisStatus(nPortNo, iSlaveNo, dwInStatus, dwOutStatus, dwAxisStatus)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetMotionStatus(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lPosErr As Integer, ByRef lActVel As Integer, ByRef wPosItemNo As UShort) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetMotionStatus(nPortNo, iSlaveNo, lCmdPos, lActPos, lPosErr, lActVel, wPosItemNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetAllStatus(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwInStatus As UInteger, ByRef dwOutStatus As UInteger, ByRef dwAxisStatus As UInteger, ByRef lCmdPos As Integer, ByRef lActPos As Integer, ByRef lPosErr As Integer, ByRef lActVel As Integer, ByRef wPosItemNo As UShort) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetAllStatus(nPortNo, iSlaveNo, dwInStatus, dwOutStatus, dwAxisStatus, lCmdPos, lActPos, lPosErr, lActVel, wPosItemNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetAxisStatus(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef dwAxisStatus As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetAxisStatus(nPortNo, iSlaveNo, dwAxisStatus)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveStop(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveStop(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function EmergencyStop(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_EmergencyStop(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveOriginSigleAxis(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveOriginSingleAxis(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveSingleAxisAbsPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lAbsPos As Integer, ByVal lVelocity As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveSingleAxisAbsPos(nPortNo, iSlaveNo, lAbsPos, lVelocity)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveSingleAxisIncPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lIncPos As Integer, ByVal lVelocity As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveSingleAxisIncPos(nPortNo, iSlaveNo, lIncPos, lVelocity)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveToLimit(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger, ByVal iLimitDir As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveToLimit(nPortNo, iSlaveNo, lVelocity, iLimitDir)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveVelocity(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger, ByVal iVelDir As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveVelocity(nPortNo, iSlaveNo, lVelocity, iVelDir)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PositionAbsOverride(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lOverridePos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PositionAbsOverride(nPortNo, iSlaveNo, lOverridePos)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PositionIncOverride(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lOverridePos As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PositionIncOverride(nPortNo, iSlaveNo, lOverridePos)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function VelocityOverride(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lVelocity As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_VelocityOverride(nPortNo, iSlaveNo, lVelocity)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function AllMoveStop(ByVal nPortNo As Byte, ByVal iSalveNo As Byte) As Boolean 'iSlaveNo = 99
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_AllMoveStop(nPortNo, iSalveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function AllEmergencyStop(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_AllEmergencyStop(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function AllMoveOriginSingleAxis(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean 'iSlaveNo = 99
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_AllMoveOriginSingleAxis(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function AllMoveSingleAxisAbsPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lAbsPos As Integer, ByVal lVelocity As UInteger) As Boolean 'iSlaveNo = 99
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_AllMoveSingleAxisAbsPos(nPortNo, iSlaveNo, lAbsPos, lVelocity)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function AllMoveSingleAxisIncPos(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal lIncPos As Integer, ByVal lVelocity As UInteger) As Boolean  'iSlaveNo = 99
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_AllMoveSingleAxisIncPos(nPortNo, iSlaveNo, lIncPos, lVelocity)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveLinearAbsPos(ByVal nPortNo As Byte, ByVal nNoOfSlaves As Byte, ByRef iSlavesNo As Byte, ByRef lAbsPos As Integer, ByVal lFreedrate As UInteger, ByVal wAccelTime As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveLinearAbsPos(nPortNo, nNoOfSlaves, iSlavesNo, lAbsPos, lFreedrate, wAccelTime)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MoveLinearIncPos(ByVal nPortNo As Byte, ByVal nNoOfSlaves As Byte, ByRef iSlavesNo As Byte, ByRef lIncPos As Integer, ByVal lFeedrate As UInteger, ByVal wAccelTime As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MoveLinearIncPos(nPortNo, nNoOfSlaves, iSlavesNo, lIncPos, lFeedrate, wAccelTime)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableReadItem(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal lpItem As sLPITEM_NODE) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableReadItem(nPortNo, iSlaveNo, wItemNo, lpItem)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableWriteItem(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal lpItem As sLPITEM_NODE) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableWriteItem(nPortNo, iSlaveNo, wItemNo, lpItem)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableWriteROM(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableWriteROM(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableReadROM(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableReadROM(nPortNo, iSlaveNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableRunItem(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableRunItem(nPortNo, iSlaveNo, wItemNo)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableReadOneItem(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal wOffset As UShort, ByRef lPosItemVal As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableReadOneItem(nPortNo, iSlaveNo, wItemNo, wOffset, lPosItemVal)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function PosTableWriteOneItem(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal wItemNo As UShort, ByVal wOffset As UShort, ByVal lPosItemVal As Integer) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_PosTableWriteOneItem(nPortNo, iSlaveNo, wItemNo, wOffset, lPosItemVal)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function TriggerOutput_RunA(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal bStartTrigger As Boolean, ByVal lStartPos As Integer, ByVal dwPeriod As UInteger, ByVal dwPulseTime As UInteger) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_TriggerOutput_RunA(nPortNo, iSlaveNo, bStartTrigger, lStartPos, dwPeriod, dwPulseTime)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function TriggerOutput_Status(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef bTriggerStatus As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_TriggerOutput_Status(nPortNo, iSlaveNo, bTriggerStatus)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function MovePush(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByVal dwStartSpd As UInteger, ByVal dwMoveSpd As UInteger, ByVal lPosition As Integer, _
                             ByVal wAccel As UShort, ByVal wDecel As UShort, ByVal wPushRate As UShort, ByVal dwPushSpd As UInteger, ByVal lEndPosition As Integer, ByVal wPushMode As UShort) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_MovePush(nPortNo, iSlaveNo, dwStartSpd, dwMoveSpd, lPosition, wAccel, wDecel, wPushMode, dwPushSpd, lEndPosition, wPushMode)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function GetPushStatus(ByVal nPortNo As Byte, ByVal iSlaveNo As Byte, ByRef nPushStatus As Byte) As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_GetPushStatus(nPortNo, iSlaveNo, nPushStatus)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function

    Public Function ErrorCheck(ByVal ret As Integer, ByRef ErrorCode As Integer) As Boolean

        Try
            Select Case ret
                Case 0
                    Return True
                Case 1
                    MsgBox("FMM_NOT_OPEN")
                    Return False
                Case 2
                    MsgBox("FMM_INVALID_PORT_NUM")
                    Return False
                Case 3
                    MsgBox("FMM_INVALID_SLAVE_NUM")
                    Return False
                Case 5
                    MsgBox("FMC_DISCONNECTED")
                    Return False
                Case 6
                    '  MsgBox("FMC_TIMEOUT_ERROR")
                    WriteLogMsg("Motion Function ERROR: FMC_TIMEOUT_ERROR (Error Code : 6)")
                    ErrorCode = 6
                    Return False
                Case 7
                    MsgBox("FMC_CRCFAILED_ERROR")
                    Return False
                Case 8
                    MsgBox("FMC_RECVPACKET_ERROR")
                    Return False
                Case 9
                    MsgBox("FMM_POSTABLE_ERROR")
                    Return False
                Case 128
                    MsgBox("FMP_FRAMETYPEERROR")
                    Return False
                Case 129
                    MsgBox("FMP_DATAERROR")
                    Return False
                Case 130
                    MsgBox("FMP_PACKETERROR")
                    Return False
                Case 133
                    MsgBox("FMP_RUNFAIL")
                    AlarmReset(2)
                    ServoEnable(nPortNo, 2, eOnOFF.eON)

                    Return False
                Case 134
                    MsgBox("FMP_RESETFAIL")
                    Return False
                Case 135
                    MsgBox("FMP_SERVOONFAIL1")
                    Return False
                Case 136
                    MsgBox("FMP_SERVOONFAIL2")
                    Return False
                Case 137
                    MsgBox("FMP_SERVOONFAIL3")
                    Return False
                Case 139
                    MsgBox("FMP_ROMACCESS")
                    Return False
                Case 170
                    MsgBox("FMP_PACKETCRCERROR")
                    Return False
                Case 255
                    MsgBox("FMM_UNKNOWN_ERROR")
                    Return False

            End Select
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function AlarmReset() As Boolean
        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        For i As Integer = 0 To 3
            ret = FAS_ServoAlarmReset(nPortNo, i)
            If ErrorCheck(ret, ErrorCode) = False Then
                If ErrorCode = 6 Then
                    Disconnection()

                    Application.DoEvents()
                    Thread.Sleep(5000)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                            Application.DoEvents()
                            Thread.Sleep(500)

                            If Connection(m_Config) = False Then
                                WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                                Return False
                            Else
                                WriteLogMsg("Motion Reconnection Complete")
                            End If
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Public Function AlarmReset(ByVal islave As Integer) As Boolean

        Dim ret As Integer = 0
        Dim ErrorCode As Integer = 0
        ret = FAS_ServoAlarmReset(nPortNo, islave)
        If ErrorCheck(ret, ErrorCode) = False Then
            If ErrorCode = 6 Then
                Disconnection()

                Application.DoEvents()
                Thread.Sleep(5000)

                If Connection(m_Config) = False Then
                    WriteLogMsg("Motion Reconnection Fail , Retry Count 1")

                    Application.DoEvents()
                    Thread.Sleep(500)

                    If Connection(m_Config) = False Then
                        WriteLogMsg("Motion Reconnection Fail , Retry Count 2")

                        Application.DoEvents()
                        Thread.Sleep(500)

                        If Connection(m_Config) = False Then
                            WriteLogMsg("Motion Reconnection Fail , Retry Count 3")
                            Return False
                        Else
                            WriteLogMsg("Motion Reconnection Complete")
                        End If
                    Else
                        WriteLogMsg("Motion Reconnection Complete")
                    End If
                Else
                    WriteLogMsg("Motion Reconnection Complete")
                End If
            End If
        End If

        Return True
    End Function
#End Region


    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.eEziSERVOPlusR
    End Sub
    Public Sub WriteLogMsg(ByVal STR As String)
        Try
            FileOpen(4, g_sFilePath_SystemLog, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            FileClose(4)
        End Try

        Dim cYear As String = Now.Year 'Format(Now, "yyyy")
        Dim cMonth As String = Now.Month ' Format(Now, "MM")
        Dim cDay As String = Now.Day  'Format(Now, "dd")

        Dim cHour As String = Now.Hour '(Now, "HH")
        Dim cMin As String = Now.Minute ' Format(Now, "mm")
        Dim cSec As String = Now.Second 'Format(Now, "ss")

        STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

        PrintLine(4, STR)

        '파일에 쓰고
        FileClose(4)
    End Sub

End Class
