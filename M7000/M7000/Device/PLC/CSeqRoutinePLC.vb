Imports System.Threading

Public Class CSeqRoutinePLC

#Region "Define"

    Dim PLC As CDevPLC_API
    Dim myParent As frmMain
    Dim m_bXMotionMoveCompleted As Boolean
    Dim m_bYMotionMoveCompleted As Boolean
    Dim m_bZMotionMoveCompleted As Boolean
    Dim m_bTheta1MotionMoveCompleted As Boolean
    Dim m_bTheta2MotionMoveCompleted As Boolean
    Dim m_bTheta3MotionMoveCompleted As Boolean
    Dim m_bTheta4MotionMoveCompleted As Boolean 
    Public m_PLCDatas As CDevPLCCommonNode.sPLCDatas
    Dim m_PLCSignalInfo As CDevPLCCommonNode.sSignalInfo
    Dim m_MotionPosition() As Double
    Const CommRetryCount As Integer = 100
    Const numberOfAxis As Integer = 6
    Dim m_bIsConnected As Boolean = False
    Dim measQueue As New Queue
    Dim m_bIsRequest As Boolean = False
    Dim m_PLCQueueCounter As Integer
    Dim m_CanAllReset As Boolean
    Dim m_Reset As Boolean
    Dim m_SupplyUpDown As Boolean
    Dim m_ExhausUpDown As Boolean
    Dim m_SupplyScan As Boolean
    Dim m_ExhausScan As Boolean
    Dim ConnectionCount As Integer = 0
    Public Event evChangeSystemStatus(ByVal state() As CDevPLCCommonNode.eSystemStatus)
    Public Event evChangeAlarm(ByVal alarm() As CDevPLCCommonNode.eDISignal)
    Public Event evChangeEQPAlarm(ByVal alarm() As CDevPLCCommonNode.eEQPLightAlaram)
    Public Event evChangeEQPState(ByVal alarm() As CDevPLCCommonNode.eEQPStatus)
    Public Event evChangeServoAlarm(ByVal alarm() As CDevPLCCommonNode.eServoAlarm)
    Public Event evChangeAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAllAxisAlarm)

    Public Event evChangeMagazineSupplySlot(ByVal state() As CDevPLCCommonNode.eSlotSignal)
    Public Event evChangeMagazineSupplyPosition(ByVal state() As CDevPLCCommonNode.ePositionSignal)
    Public Event evChangeMagazineSupplyStatus(ByVal state() As CDevPLCCommonNode.eMagazineStatus)
    Public Event evChangeMagazineExhausSlot(ByVal state() As CDevPLCCommonNode.eSlotSignal)

    Public Event evChangeMagazineExhausPosition(ByVal state() As CDevPLCCommonNode.ePositionSignal)
    Public Event evChangeMagazineExhausStatus(ByVal state() As CDevPLCCommonNode.eMagazineStatus)
    Public Event evChangeMagazineAlarm(ByVal alarm() As CDevPLCCommonNode.eMagazineError)
    Public Event evChangeMagazineContactInspection(ByVal state() As CDevPLCCommonNode.eMagazineContactIspection)

    Public Event evChangeDoorAlarm(ByVal state() As CDevPLCCommonNode.eDoorAlarm)
    Public Event evChangeTemperatureAlarm(ByVal state() As CDevPLCCommonNode.eTemperatureAlarm)
    Public Event evChangeTemperatureControlAlarm(ByVal state() As CDevPLCCommonNode.eTemperatureAlarm)
    Public Event evChangeLiftAlarm(ByVal state() As CDevPLCCommonNode.eLiftAlarm)
    Public Event evChangeConbareAlarm(ByVal state() As CDevPLCCommonNode.eConbareConnection)
    Public Event evChangePCBInfoAlarm(ByVal state() As CDevPLCCommonNode.ePCBInfoAlarm)

    'semi'
    Public Event evChangeEMSAlarm(ByVal alarm() As CDevPLCCommonNode.eEMSAlarm)
    '  Public Event evChangeStrangeTempAlarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm)
    ' Public Event evChangeEOCRAlarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm)
    ' Public Event evChangeSSRAlarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm)
    '  Public Event evChangeOverTempZone1Alarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm)
    ' Public Event evChangeOverTempZone2Alarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm)
    ' Public Event evChangeLoaderAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    '  Public Event evChangeHitterAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    '  Public Event evChangeXAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeYAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeZAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeTheta1AxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeTheta2AxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeTheta3AxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    Public Event evChangeTheta4AxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
    '  Public Event evChangeUnLoaderAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm)
#End Region


#Region "Propertys"

    Public Property Datas As CDevPLCCommonNode.sPLCDatas
        Get
            Return m_PLCDatas
        End Get
        Set(ByVal value As CDevPLCCommonNode.sPLCDatas)
            m_PLCDatas = value
        End Set
    End Property

    Public Property PLCSignalInfo As CDevPLCCommonNode.sSignalInfo
        Get
            Return m_PLCSignalInfo
        End Get
        Set(ByVal value As CDevPLCCommonNode.sSignalInfo)
            m_PLCSignalInfo = value
        End Set
    End Property

    Public Property PLCRequest As Boolean
        Get
            Return m_bIsRequest
        End Get
        Set(ByVal value As Boolean)
            m_bIsRequest = value
        End Set
    End Property
    Public ReadOnly Property CurrentPosition As Double()
        Get
            Return m_MotionPosition.Clone
        End Get
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Property XMoveCompleted As Boolean
        Get
            Return m_bXMotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bXMotionMoveCompleted = value
        End Set
    End Property
    Public Property YMoveCompleted As Boolean
        Get
            Return m_bYMotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bYMotionMoveCompleted = value
        End Set
    End Property
    Public Property ZMoveCompleted As Boolean
        Get
            Return m_bZMotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bZMotionMoveCompleted = value
        End Set
    End Property
    Public Property Theta1MoveCompleted As Boolean
        Get
            Return m_bTheta1MotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bTheta1MotionMoveCompleted = value
        End Set
    End Property
    Public Property Theta2MoveCompleted As Boolean
        Get
            Return m_bTheta2MotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bTheta2MotionMoveCompleted = value
        End Set
    End Property
    Public Property Theta3MoveCompleted As Boolean
        Get
            Return m_bTheta3MotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bTheta3MotionMoveCompleted = value
        End Set
    End Property
    Public Property Theta4MoveCompleted As Boolean
        Get
            Return m_bTheta4MotionMoveCompleted
        End Get
        Set(ByVal value As Boolean)
            m_bTheta4MotionMoveCompleted = value
        End Set
    End Property
    Public Property ConnectCount As Integer
        Get
            Return ConnectionCount
        End Get
        Set(value As Integer)
            ConnectionCount = value
        End Set
    End Property

    Public Property CanAllReset As Boolean
        Get
            Return m_CanAllReset
        End Get
        Set(value As Boolean)
            m_CanAllReset = value
        End Set
    End Property
    Public Property Reset As Boolean
        Get
            Return m_Reset
        End Get
        Set(value As Boolean)
            m_Reset = value
        End Set
    End Property
#End Region

#Region "Creation"

    Public Sub New(ByVal DevType As CDevPLCCommonNode.eModel, ByVal fmain As frmMain)
        PLC = New CDevPLC_API(DevType, fmain, numberOfAxis)

        PLC.myPLC.ComType = CDevPLC_MITSUBISHI.eType._Prog
        PLC.myPLC.LoginNo = 0

        myParent = fmain

        ReDim m_MotionPosition(numberOfAxis - 1)

        For i As Integer = 0 To numberOfAxis - 1
            m_MotionPosition(i) = 0
        Next

        Dim nSystemStatus(0) As CDevPLCCommonNode.eSystemStatus
        Dim nDISignal(0) As CDevPLCCommonNode.eDISignal
        Dim nDOSignal(0) As CDevPLCCommonNode.eDOSignal

        Dim nMagazineSupplySlot(0) As CDevPLCCommonNode.eSlotSignal
        Dim nMagazineSupplyPosition(0) As CDevPLCCommonNode.ePositionSignal
        Dim nMagazineSupplyStatus(0) As CDevPLCCommonNode.eMagazineStatus

        Dim nMagazineExhausSlot(0) As CDevPLCCommonNode.eSlotSignal
        Dim nMagazineExhausPosition(0) As CDevPLCCommonNode.ePositionSignal
        Dim nMagazineExhausStatus(0) As CDevPLCCommonNode.eMagazineStatus

        Dim nMagazineError(0) As CDevPLCCommonNode.eMagazineError
        Dim nMagazineContactIspection(0) As CDevPLCCommonNode.eMagazineContactIspection

        Dim nTemperatureControlAlarm(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nTemperatureAlarm(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nLiftAlarm(0) As CDevPLCCommonNode.eLiftAlarm
        Dim nConbareAlarm(0) As CDevPLCCommonNode.eConbareConnection
        Dim nPCBInfoAlarm(0) As CDevPLCCommonNode.ePCBInfoAlarm

        Dim nEQPState(0) As CDevPLCCommonNode.eEQPStatus
        Dim nEQPAlarm(0) As CDevPLCCommonNode.eEQPLightAlaram
        Dim nServoAlarm(0) As CDevPLCCommonNode.eServoAlarm
        Dim nAxisAlarm(0) As CDevPLCCommonNode.eAllAxisAlarm

        Dim nEmsAlarm(0) As CDevPLCCommonNode.eEMSAlarm
        Dim nStrangeTempAlarm(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nEOCRTempAlarm(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nSSRTempAlarm(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nOverTempAlarm_Zone1(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nOverTempAlarm_Zone2(0) As CDevPLCCommonNode.eTemperatureAlarm
        Dim nLoaderAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nHitterAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nXAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nYAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nZAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nTheta1AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nTheta2AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nTheta3AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nTheta4AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nUnLoaderAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim nDoorAlarm(0) As CDevPLCCommonNode.eDoorAlarm

        nEmsAlarm(0) = CDevPLCCommonNode.eEMSAlarm.eNoError
        nStrangeTempAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nEOCRTempAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nSSRTempAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nOverTempAlarm_Zone1(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nOverTempAlarm_Zone2(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nLoaderAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nHitterAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nXAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nYAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nZAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nTheta1AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nTheta2AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nTheta3AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nTheta4AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        nUnLoaderAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError

        nDoorAlarm(0) = CDevPLCCommonNode.eDoorAlarm.eNoError
        nEQPAlarm(0) = CDevPLCCommonNode.eEQPLightAlaram.eNoError
        nServoAlarm(0) = CDevPLCCommonNode.eServoAlarm.eY1_Axis_Servo_ON
        nAxisAlarm(0) = CDevPLCCommonNode.eAllAxisAlarm.eNoError

        nSystemStatus(0) = CDevPLCCommonNode.eSystemStatus.ePower_Down
        nDISignal(0) = CDevPLCCommonNode.eDISignal.eNoError
        nDOSignal(0) = CDevPLCCommonNode.eDOSignal.eALLOFF

        nMagazineSupplySlot(0) = CDevPLCCommonNode.eSlotSignal.eNone
        nMagazineSupplyPosition(0) = CDevPLCCommonNode.ePositionSignal.eNone
        nMagazineSupplyStatus(0) = CDevPLCCommonNode.eMagazineStatus.eIDEL
        nMagazineExhausSlot(0) = CDevPLCCommonNode.eSlotSignal.eNone
        nMagazineExhausPosition(0) = CDevPLCCommonNode.ePositionSignal.eNone
        nMagazineExhausStatus(0) = CDevPLCCommonNode.eMagazineStatus.eIDEL
        nMagazineError(0) = CDevPLCCommonNode.eMagazineError.eNoError
        nMagazineContactIspection(0) = CDevPLCCommonNode.eMagazineContactIspection.eIDEL

        nTemperatureControlAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nTemperatureAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        nLiftAlarm(0) = CDevPLCCommonNode.eLiftAlarm.eNoError
        nConbareAlarm(0) = CDevPLCCommonNode.eConbareConnection.eNoError
        nPCBInfoAlarm(0) = CDevPLCCommonNode.ePCBInfoAlarm.eNoError
        nEQPState(0) = CDevPLCCommonNode.eEQPStatus.eRun

        m_PLCDatas.nSystemStatus = nSystemStatus.Clone
        m_PLCDatas.nDISignal = nDISignal.Clone
        m_PLCDatas.nDOSignal = nDOSignal.Clone

        m_PLCDatas.nSupplySlotSignal = nMagazineSupplySlot.Clone
        m_PLCDatas.nSupplyPositionSignal = nMagazineSupplyPosition
        m_PLCDatas.nSupplyMagazineStatus = nMagazineSupplyStatus.Clone
        m_PLCDatas.nExhausSlotSignal = nMagazineExhausSlot.Clone
        m_PLCDatas.nExhausPositionSignal = nMagazineExhausPosition
        m_PLCDatas.nExhausMagazineStatus = nMagazineExhausStatus.Clone
        m_PLCDatas.nTemperatureControlAlarm = nTemperatureControlAlarm.Clone
        m_PLCDatas.nTemperatureAlarm = nTemperatureAlarm.Clone

        'Semi
        m_PLCDatas.nEQPAlaram = nEQPAlarm.Clone
        m_PLCDatas.nServoAlarm = nServoAlarm.Clone
        m_PLCDatas.nAxisAlarm = nAxisAlarm.Clone
        m_PLCDatas.nEQPState = nEQPState.Clone
        m_PLCDatas.nEmsAlarm = nEmsAlarm.Clone
        m_PLCDatas.nStrangeTempAlarm = nStrangeTempAlarm.Clone
        m_PLCDatas.nEOCRTempAlarm = nEOCRTempAlarm.Clone
        m_PLCDatas.nSSRTempAlarm = nSSRTempAlarm.Clone
        m_PLCDatas.nOverTempAlarm_Zone1 = nOverTempAlarm_Zone1.Clone
        m_PLCDatas.nOverTempAlarm_Zone2 = nOverTempAlarm_Zone2.Clone
        m_PLCDatas.nLoaderAxisAlarm = nLoaderAxisAlarm.Clone
        m_PLCDatas.nHitterAxisAlarm = nHitterAxisAlarm.Clone
        m_PLCDatas.nXAxisAlarm = nAxisAlarm.Clone
        m_PLCDatas.nYAxisAlarm = nYAxisAlarm.Clone
        m_PLCDatas.nZAxisAlarm = nZAxisAlarm.Clone
        m_PLCDatas.nTheta1AxisAlarm = nTheta1AxisAlarm.clone
        m_PLCDatas.nTheta2AxisAlarm = nTheta2AxisAlarm.clone
        m_PLCDatas.nTheta3AxisAlarm = nTheta3AxisAlarm.clone
        m_PLCDatas.nTheta4AxisAlarm = nTheta4AxisAlarm.clone
        m_PLCDatas.nUnLoaderAxisAlarm = nUnLoaderAxisAlarm.Clone
        m_PLCSignalInfo = PLC.myPLC.SignalInfo
        m_PLCDatas.nDoorAlarm = nDoorAlarm.Clone
    End Sub

#End Region


#Region "Connect/Disconnect"

    Public Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim dRetData As String = Nothing

        If PLC.myPLC.Connection(config) = False Then
            Return False
        Else
            m_Reset = False
            PLC.myPLC.GetSystemStatus(m_PLCDatas.nSystemStatus)

            trdStart()

            'Thread.Sleep(1000)
            'Dim reqInfo As CDevPLCCommonNode.sRequestInfo = Nothing

            'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetStatus
            'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eIDEL
            'Request(reqInfo)
        End If
        m_bIsConnected = True

        Return True
    End Function

    Public Sub Init()
        ReDim m_PLCDatas.nSystemStatus(0)
        ReDim m_PLCDatas.nSupplySlotSignal(0)
        ' ReDim m_PLCDatas.nSupplyPositionSignal(0)
        ReDim m_PLCDatas.nSupplyMagazineStatus(0)
        ReDim m_PLCDatas.nExhausSlotSignal(0)
        ' ReDim m_PLCDatas.nExhausPositionSignal(0)
        ReDim m_PLCDatas.nExhausMagazineStatus(0)
        ReDim m_PLCDatas.nTemperatureAlarm(0)
        ReDim m_PLCDatas.nTemperatureControlAlarm(0)

        ReDim m_PLCDatas.nDoorAlarm(0)
        ReDim m_PLCDatas.nEmsAlarm(0)
        ReDim m_PLCDatas.nStrangeTempAlarm(0)
        ReDim m_PLCDatas.nEOCRTempAlarm(0)
        ReDim m_PLCDatas.nSSRTempAlarm(0)
        ReDim m_PLCDatas.nOverTempAlarm_Zone1(0)
        ReDim m_PLCDatas.nOverTempAlarm_Zone2(0)
        ReDim m_PLCDatas.nLoaderAxisAlarm(0)
        ReDim m_PLCDatas.nHitterAxisAlarm(0)
        ReDim m_PLCDatas.nXAxisAlarm(0)
        ReDim m_PLCDatas.nYAxisAlarm(0)
        ReDim m_PLCDatas.nZAxisAlarm(0)
        ReDim m_PLCDatas.nTheta1AxisAlarm(0)
        ReDim m_PLCDatas.nTheta2AxisAlarm(0)
        ReDim m_PLCDatas.nTheta3AxisAlarm(0)
        ReDim m_PLCDatas.nTheta4AxisAlarm(0)
        ReDim m_PLCDatas.nUnLoaderAxisAlarm(0)

        m_PLCSignalInfo = PLC.myPLC.SignalInfo

        m_PLCDatas.nSystemStatus(0) = CDevPLCCommonNode.eSystemStatus.ePower_Down
        m_PLCDatas.nSupplySlotSignal(0) = CDevPLCCommonNode.eSlotSignal.eNone
        m_PLCDatas.nSupplyPositionSignal(0) = CDevPLCCommonNode.ePositionSignal.eNone
        m_PLCDatas.nSupplyMagazineStatus(0) = CDevPLCCommonNode.eMagazineStatus.eIDEL
        m_PLCDatas.nExhausSlotSignal(0) = CDevPLCCommonNode.eSlotSignal.eNone
        m_PLCDatas.nExhausPositionSignal(0) = CDevPLCCommonNode.ePositionSignal.eNone
        m_PLCDatas.nExhausMagazineStatus(0) = CDevPLCCommonNode.eMagazineStatus.eIDEL
        m_PLCDatas.nTemperatureAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        m_PLCDatas.nTemperatureControlAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError

        'Semi'
        m_PLCDatas.nDoorAlarm(0) = CDevPLCCommonNode.eDoorAlarm.eNoError
        m_PLCDatas.nEmsAlarm(0) = CDevPLCCommonNode.eEMSAlarm.eNoError
        m_PLCDatas.nEOCRTempAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        m_PLCDatas.nSSRTempAlarm(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        m_PLCDatas.nOverTempAlarm_Zone1(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        m_PLCDatas.nOverTempAlarm_Zone2(0) = CDevPLCCommonNode.eTemperatureAlarm.eNoError
        m_PLCDatas.nLoaderAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nHitterAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nXAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nYAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nZAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nTheta1AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nTheta2AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nTheta3AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nTheta4AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        m_PLCDatas.nUnLoaderAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError

        RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
        'RaiseEvent evChangeMagazineSupplySlot(m_PLCDatas.nSupplySlotSignal)
        RaiseEvent evChangeEQPAlarm(m_PLCDatas.nEQPAlaram)

        RaiseEvent evChangeAxisAlarm(m_PLCDatas.nAxisAlarm)
        RaiseEvent evChangeServoAlarm(m_PLCDatas.nServoAlarm)
        'RaiseEvent evChangeMagazineSupplyPosition(m_PLCDatas.nSupplyPositionSignal)
        'RaiseEvent evChangeMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus)
        'RaiseEvent evChangeMagazineExhausSlot(m_PLCDatas.nExhausSlotSignal)
        'RaiseEvent evChangeMagazineExhausPosition(m_PLCDatas.nExhausPositionSignal)
        'RaiseEvent evChangeMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus)
        ' RaiseEvent evChangeDoorAlarm(m_PLCDatas.nDoorAlarm)
        RaiseEvent evChangeTemperatureAlarm(m_PLCDatas.nTemperatureAlarm)
        ' RaiseEvent evChangeTemperatureControlAlarm(m_PLCDatas.nTemperatureControlAlarm)

        'Semi'
        RaiseEvent evChangeEMSAlarm(m_PLCDatas.nEmsAlarm)
        '  RaiseEvent evChangeStrangeTempAlarm(m_PLCDatas.nStrangeTempAlarm)
        '  RaiseEvent evChangeEOCRAlarm(m_PLCDatas.nEOCRTempAlarm)
        '  RaiseEvent evChangeSSRAlarm(m_PLCDatas.nSSRTempAlarm)
        ' RaiseEvent evChangeOverTempZone1Alarm(m_PLCDatas.nOverTempAlarm_Zone1)
        '  RaiseEvent evChangeOverTempZone2Alarm(m_PLCDatas.nOverTempAlarm_Zone2)
        '  RaiseEvent evChangeLoaderAxisAlarm(m_PLCDatas.nLoaderAxisAlarm)
        '  RaiseEvent evChangeHitterAxisAlarm(m_PLCDatas.nHitterAxisAlarm)
        ' RaiseEvent evChangeXAxisAlarm(m_PLCDatas.nXAxisAlarm)
        RaiseEvent evChangeYAxisAlarm(m_PLCDatas.nYAxisAlarm)
        RaiseEvent evChangeZAxisAlarm(m_PLCDatas.nZAxisAlarm)
        RaiseEvent evChangeTheta1AxisAlarm(m_PLCDatas.nTheta1AxisAlarm)
        RaiseEvent evChangeTheta2AxisAlarm(m_PLCDatas.nTheta2AxisAlarm)
        RaiseEvent evChangeTheta3AxisAlarm(m_PLCDatas.nTheta3AxisAlarm)
        RaiseEvent evChangeTheta4AxIsAlarm(m_PLCDatas.nTheta4AxisAlarm)

        '  RaiseEvent evChangeUnLoaderAxisAlarm(m_PLCDatas.nUnLoaderAxisAlarm)
    End Sub

    Public Sub Disconnection()

        trdStop()

        measQueue.Clear()

        PLC.myPLC.Disconnection()

    End Sub


#End Region

    Public Property PLCQueueCounter As Integer
        Get
            Return m_PLCQueueCounter
        End Get
        Set(ByVal value As Integer)
            m_PLCQueueCounter = value
        End Set
    End Property


    Public Sub Request(ByVal info As CDevPLCCommonNode.sRequestInfo)
        SyncLock measQueue.SyncRoot
            'If m_bIsRequest = False Then
            '   m_bIsRequest = True
            measQueue.Enqueue(info)
            '   End If
        End SyncLock
    End Sub

    Public trdProcess As Thread
    Public bIsStop_trdProcess As Boolean

    Private Sub trdStart()
        trdProcess = New Thread(AddressOf trdPorcessLoop)
        trdProcess.Priority = ThreadPriority.Highest

        trdProcess.TrySetApartmentState(ApartmentState.MTA)
        trdProcess.Start()
        bIsStop_trdProcess = False
    End Sub

    Public Sub trdStop()
        bIsStop_trdProcess = True
    End Sub

    Public Sub Dispose()
        Disconnection()
        'PLC.myPLC = Nothing
        Finalize()
    End Sub


    Private Sub trdPorcessLoop()

        Dim requestInfo As CDevPLCCommonNode.sRequestInfo
        Dim dPos() As Double = Nothing

        Dim beforState(0) As CDevPLCCommonNode.eSystemStatus
        Dim beforAlarm(0) As CDevPLCCommonNode.eDISignal
        Dim beforeDoorAlarm(0) As CDevPLCCommonNode.eDoorAlarm
        Dim beforeServoAlarm(0) As CDevPLCCommonNode.eServoAlarm
        Dim beforeEQPAlarm(0) As CDevPLCCommonNode.eEQPLightAlaram
        Dim beforeAxisAlarm(0) As CDevPLCCommonNode.eAllAxisAlarm
        Dim beforeEQPState(0) As CDevPLCCommonNode.eEQPStatus
        Dim beforeEmsAlarm(0) As CDevPLCCommonNode.eEMSAlarm
        Dim beforeYAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim beforeZAxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim beforeTheta1AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim beforeTheta2AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim beforeTheta3AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
        Dim beforeTheta4AxisAlarm(0) As CDevPLCCommonNode.eAxisAlarm
       
        Dim retryCount As Integer = 0

        beforState(0) = CDevPLCCommonNode.eSystemStatus.ePower_Down
        beforAlarm(0) = CDevPLCCommonNode.eDISignal.eNoError
        beforeDoorAlarm(0) = CDevPLCCommonNode.eDoorAlarm.eNoError
       
        beforeEQPAlarm(0) = CDevPLCCommonNode.eEQPLightAlaram.eNoError
        beforeAxisAlarm(0) = CDevPLCCommonNode.eAllAxisAlarm.eNoError
        beforeEQPState(0) = CDevPLCCommonNode.eEQPStatus.eRun

        'semi'
        beforeEmsAlarm(0) = CDevPLCCommonNode.eEMSAlarm.eNoError
        beforeYAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        beforeZAxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        beforeTheta1AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        beforeTheta2AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        beforeTheta3AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError
        beforeTheta4AxisAlarm(0) = CDevPLCCommonNode.eAxisAlarm.eNoError

        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "PLC Sequence Routine")

        Do
            Application.DoEvents()
            Thread.Sleep(100)

            If bIsStop_trdProcess = True Then
                Init()
                Exit Do
            End If

            If retryCount > CommRetryCount Then
                ReDim m_PLCDatas.nSystemStatus(0)
                m_PLCDatas.nSystemStatus(0) = CDevPLCCommonNode.eSystemStatus.ePower_Down

                RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
                Exit Do
            End If

            If PLC.myPLC.CheckConnectionStatus() = False Then

            End If

            If retryCount = 0 Then

                Do
                    If retryCount > CommRetryCount Then
                        ReDim m_PLCDatas.nSystemStatus(0)
                        m_PLCDatas.nSystemStatus(0) = CDevPLCCommonNode.eSystemStatus.ePower_Down

                        RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "PLC Down(retry count over) - PLC Sequence Routine")
                        Exit Sub
                    End If

                    If bIsStop_trdProcess = True Then
                        Exit Do
                    End If

                    If retryCount = 0 Then   '통신 상태가 정상 일때, 1초 간격으로 통신
                        Application.DoEvents()
                        Thread.Sleep(10)

                        SyncLock measQueue.SyncRoot  '정상일때만 다음 명령 처리
                            m_PLCQueueCounter = measQueue.Count

                            If measQueue.Count >= 1 Then
                                requestInfo = measQueue.Dequeue
                                Exit Do
                            Else
                                m_bIsRequest = False
                            End If
                        End SyncLock

                    Else   '통신 상태가 비정상 일때
                        Application.DoEvents()
                        Thread.Sleep(100)
                    End If

                    ' Application.DoEvents()
                    'Connection 연결 상태 확인
                    If PLC.myPLC.CheckConnectionStatus() = False Then
                        '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
                        '재 연결 후에 다시 작동
                        retryCount += 1
                        ConnectionCount = 0
                    Else
                        ConnectionCount += 1
                        If ConnectionCount > 10 Then
                            ConnectionCount = 10
                        End If
                        retryCount = 0
                    End If

                    m_bYMotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eY)
                    m_bZMotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eZ)
                    m_bTheta1MotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eTHETA1)
                    m_bTheta2MotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eTHETA2)
                    m_bTheta3MotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eTHETA3)
                    m_bTheta4MotionMoveCompleted = PLC.myPLC.MoveCompleted(CDevPLCCommonNode.eAxis.eTHETA4)
                    m_CanAllReset = PLC.myPLC.GetCanAllReset(CDevPLCCommonNode.eAllResetChkState.eCan_All_Reset)
                    'System 상태 감시
                    Dim fIsAlarmState As Boolean = False
                    Dim fIsMagazineSupplyAlarmState As Boolean = False
                    Dim fIsMagazineExhausAlarmState As Boolean = False
                    Application.DoEvents()
                    Thread.Sleep(10)
                    GetSystemStatus(beforState, beforAlarm, retryCount, fIsAlarmState)

                    '알람 추가되면 여기 추가하면됨

                    'Servo Alarm 조회 (모든 축(축만 조회하고 각 축 세부알람은 따른 곳에서 조회함))
                    '개별 축 알람 올라오므로 현재는 필요없음
                    GetServoAlarm(beforeServoAlarm, retryCount)

                    'EMS Alarm 조회
                    GetEMSAlarm(beforeEmsAlarm, retryCount)

                    'Door Alarm 조회
                    GetAlarmDoor(beforeDoorAlarm, retryCount)

                    'Y축 알람 조회
                    GetYAxisAlarm(beforeYAxisAlarm, retryCount)

                    'Z축 알람 조회
                    GetZAxisAlarm(beforeZAxisAlarm, retryCount)

                    'Theta1축 알람 조회
                    GetTheta1AxisAlarm(beforeTheta1AxisAlarm, retryCount)

                    'Theta2축 알람 조회
                    GetTheta2AxisAlarm(beforeTheta2AxisAlarm, retryCount)

                    'Theta3축 알람 조회
                    GetTheta3AxisAlarm(beforeTheta3AxisAlarm, retryCount)

                    'Theta4축 알람 조회
                    GetTheta4AxisAlarm(beforeTheta4AxisAlarm, retryCount)

                    'System 알람 체크
                    If fIsAlarmState = True Then
                        requestInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eGetAlarm
                        Exit Do
                    End If

                    'EQP STATE 조회
                    GetEQPStatus(beforeEQPState, retryCount)
                    
                    Application.DoEvents()
                    Thread.Sleep(10)
                    '갱신 매번 해야되니까 불러와야되나?

                    If PLC.myPLC.GetCurrentPosition(dPos) = True Then
                        m_MotionPosition = dPos.Clone
                    End If
                    

                Loop
            End If

            Select Case requestInfo.nCMD

                Case CDevPLCCommonNode.eRequestCMD.eGetAlarm
                    Dim alarm(0) As CDevPLCCommonNode.eDISignal
                    alarm(0) = CDevPLCCommonNode.eDISignal.eNoError
                    m_PLCDatas.nDISignal = alarm.Clone
                    If PLC.myPLC.GetAlarm(m_PLCDatas.nDISignal) = False Then
                        '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
                        '재 연결 후에 다시 작동
                        retryCount += 1
                    Else
                        retryCount = 0
                        '알람의 상태에 변화가 있으면 이벤트를 날린다.
                        If beforAlarm.Length <> m_PLCDatas.nDISignal.Length Then
                            RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
                        Else

                            For i As Integer = 0 To beforAlarm.Length - 1
                                If beforAlarm(i) <> m_PLCDatas.nDISignal(i) Then
                                    RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
                                End If
                            Next
                        End If
                        '시스템의 상태를 갱신 한다.
                        beforAlarm = m_PLCDatas.nDISignal.Clone
                    End If

                    'Case CDevPLCCommonNode.eRequestCMD.eGetMagazineAlarm
                    '    '=====================  Alarm =================
                    '    Dim alarm(0) As CDevPLCCommonNode.eMagazineError
                    '    alarm(0) = CDevPLCCommonNode.eMagazineError.eNoError
                    '    m_PLCDatas.nMagazineError = alarm.Clone
                    '    If PLC.myPLC.GetMagazineAlarmStatus(m_PLCDatas.nMagazineError) = False Then
                    '        '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
                    '        '재 연결 후에 다시 작동
                    '        retryCount += 1
                    '    Else
                    '        retryCount = 0
                    '        '알람의 상태에 변화가 있으면 이벤트를 날린다.
                    '        If beforeMagazineAlarm.Length <> m_PLCDatas.nMagazineError.Length Then
                    '            RaiseEvent evChangeMagazineAlarm(m_PLCDatas.nMagazineError)
                    '        Else

                    '            For i As Integer = 0 To beforeMagazineAlarm.Length - 1
                    '                If beforeMagazineAlarm(i) <> m_PLCDatas.nMagazineError(i) Then
                    '                    RaiseEvent evChangeMagazineAlarm(m_PLCDatas.nMagazineError)
                    '                End If
                    '            Next
                    '        End If
                    '        '시스템의 상태를 갱신 한다.
                    '        beforeMagazineAlarm = m_PLCDatas.nMagazineError.Clone
                    '    End If
                Case CDevPLCCommonNode.eRequestCMD.eSetEQPStatus
                    SetEQPSystemStatus(requestInfo, retryCount)

                Case CDevPLCCommonNode.eRequestCMD.eSetStatus
                    Dim fIsAlarmState As Boolean = False

                    SetSystemStatus(requestInfo, retryCount, beforState, fIsAlarmState)

                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
                    ' If fIsAlarmState = True Then
                    'requestInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eGetAlarm
                    ' Exit Do
                    '  End If

                Case CDevPLCCommonNode.eRequestCMD.eSetMagazineSupplyStatus
                    '=====================  MagazienSupply =================
                    '   Dim fIsMagazineAlarmState As Boolean = False

                    SetMagazineSupplyStatus(requestInfo, retryCount, beforState)

                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
                    'If fIsMagazineAlarmState = True Then
                    '    requestInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eGetMagazineAlarm
                    '    Exit Do
                    'End If

                Case CDevPLCCommonNode.eRequestCMD.eSetMagazineExhausStatus
                    '=====================  MagazienExhaus =================
                    ' Dim fIsMagazineAlarmState As Boolean = False

                    SetMagazineExhausStatus(requestInfo, retryCount, beforState)

                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
                    'If fIsMagazineAlarmState = True Then
                    '    requestInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eGetMagazineAlarm
                    '    Exit Do
                    'End If

                Case CDevPLCCommonNode.eRequestCMD.eSetMagazineContactInspection
                    '=====================  ContactIspection =================

                    ' Dim fIsMagazineAlarmState As Boolean = False

                    'SetMagazineContactInspection(requestInfo, retryCount, beforState)

                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
                    'If fIsMagazineAlarmState = True Then
                    '    requestInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eGetMagazineAlarm
                    '    Exit Do
                    'End If

                Case CDevPLCCommonNode.eRequestCMD.eSetDOStatus
                    SetDOStatus(requestInfo, retryCount)

                Case CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                    '   m_bXMotionMoveCompleted = False
                    m_bYMotionMoveCompleted = False
                    m_bZMotionMoveCompleted = False
                    m_bTheta1MotionMoveCompleted = False
                    m_bTheta2MotionMoveCompleted = False
                    m_bTheta3MotionMoveCompleted = False
                    m_bTheta4MotionMoveCompleted = False

                    Select Case requestInfo.nSYSStatus

                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Homming
                            If PLC.myPLC.Homming() = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_X_Velocity
                            If PLC.myPLC.SetJogXVelocity(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Y_Velocity
                            If PLC.myPLC.SetJogYVelocity(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Z_Velocity
                            If PLC.myPLC.SetJogZVelocity(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If

                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Theta_Velocity
                            If PLC.myPLC.SetJogThetaVelocity(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_X
                            '일단 속도까지 넣었는데 속도를 처음셋팅하고 나서 필요없으면 뺴야됨
                            If PLC.myPLC.PositionMoveX(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Y
                            If PLC.myPLC.PositionMoveY(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Z
                            If PLC.myPLC.PositionMoveZ(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta1
                            If PLC.myPLC.PositionMoveTheta1(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta2
                            If PLC.myPLC.PositionMoveTheta2(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta3
                            If PLC.myPLC.PositionMoveTheta3(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta4
                            If PLC.myPLC.PositionMoveTheta4(requestInfo.Param(0), requestInfo.Param(1), requestInfo.eMovingMethod) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_X_RMove
                            If PLC.myPLC.JogXRMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_X_LMove
                            If PLC.myPLC.JogXLMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_DownMove
                            If PLC.myPLC.JogYDownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_UpMove
                            If PLC.myPLC.JogYuPMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_DownMove
                            If PLC.myPLC.JogZDownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_UpMove
                            If PLC.myPLC.JogZUpMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_DownMove
                            If PLC.myPLC.JogTheta1DownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_UpMove
                            If PLC.myPLC.JogTheta1UpMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_DownMove
                            If PLC.myPLC.JogTheta2DownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_UpMove
                            If PLC.myPLC.JogTheta2UpMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_DownMove
                            If PLC.myPLC.JogTheta3DownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_UpMove
                            If PLC.myPLC.JogTheta3UpMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_DownMove
                            If PLC.myPLC.JogTheta4DownMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_UpMove
                            If PLC.myPLC.JogTheta4UpMove(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Stop
                            If PLC.myPLC.JOG_MOVE_STOP() = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_Teach
                            If PLC.myPLC.Jog_Mode_On_Teach = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_ON
                            If PLC.myPLC.Jog_Mode_On = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_OFF
                            If PLC.myPLC.Jog_Mode_Off = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_Auto
                            If PLC.myPLC.Jog_Mode_Off_Auto = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_OFF
                            If PLC.myPLC.JOG_MOVE_STOP() = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eAlarm_Reset
                            If PLC.myPLC.AlarmClear() = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eAll_Reset
                            m_CanAllReset = False
                            If PLC.myPLC.SetAllReset() = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                                Thread.Sleep(100)
                                Application.DoEvents()
                                m_Reset = True
                                m_CanAllReset = PLC.myPLC.GetCanAllReset(CDevPLCCommonNode.eAllResetChkState.eCan_All_Reset)
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_GET_Position
                            Dim pos() As Double = Nothing
                            If PLC.myPLC.GetCurrentPosition(pos) = False Then
                                retryCount += 1
                            Else
                                m_MotionPosition = pos.Clone
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eChangeMode
                            If PLC.myPLC.SetChangeMode(requestInfo.eChangeMode) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                        Case CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK
                            If PLC.myPLC.SetCompleteACK(requestInfo.Param(0)) = False Then
                                retryCount += 1
                            Else
                                retryCount = 0
                            End If
                    End Select

            End Select


        Loop

        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "PLC Sequence Routine")

    End Sub

#Region "Set Control"

    Private Sub SetDOStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo, ByVal retryCount As Integer)
        If PLC.myPLC.SetDOSignal(requestInfo.nDOStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
        End If
    End Sub
    Private Sub SetEQPSystemStatus(ByVal requsetinfo As CDevPLCCommonNode.sRequestInfo, ByVal retryCount As Integer)
        If requsetinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun Then
            If PLC.myPLC.SetSystemStatus(CDevPLCCommonNode.eEQPStatus.eRun) = False Then Exit Sub
        ElseIf requsetinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eStop Then
            If PLC.myPLC.SetSystemStatus(CDevPLCCommonNode.eEQPStatus.eStop) = False Then Exit Sub
        ElseIf requsetinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.ePause Then
            If PLC.myPLC.SetSystemStatus(CDevPLCCommonNode.eEQPStatus.ePause) = False Then Exit Sub
        ElseIf requsetinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun Then
            If PLC.myPLC.SetSystemStatus(CDevPLCCommonNode.eEQPStatus.eReset) = False Then Exit Sub
        End If
    End Sub
    Private Sub SetSystemStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo, ByVal retryCount As Integer, ByRef beforState() As CDevPLCCommonNode.eSystemStatus, ByRef fIsAlarmState As Boolean)

        'If PLC.myPLC.SetSystemStatus(requestInfo.nSYSStatus) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0
        'End If

        'System 상태 감시
        If PLC.myPLC.GetSystemStatus(m_PLCDatas.nSystemStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nSystemStatus.Length Then
                RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nSystemStatus(i) Then
                        RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nSystemStatus.Clone

            '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
            For i As Integer = 0 To m_PLCDatas.nSystemStatus.Length - 1
                If m_PLCDatas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eAlarm Then
                    fIsAlarmState = True
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub SetMagazineSupplyStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo, ByVal retryCount As Integer, ByRef beforeMagazineSupplyStatus() As CDevPLCCommonNode.eMagazineStatus)

        If PLC.myPLC.SetMagazineSupplyStatus(requestInfo.nMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
        End If

        'MagazienSupply 상태 감시
        If PLC.myPLC.GetMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            'MagazienSupply 상태에 변화가 있으면 이벤트를 날린다.
            If beforeMagazineSupplyStatus.Length <> m_PLCDatas.nSupplyMagazineStatus.Length Then
                RaiseEvent evChangeMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus)
            Else
                For i As Integer = 0 To beforeMagazineSupplyStatus.Length - 1
                    If beforeMagazineSupplyStatus(i) <> m_PLCDatas.nSupplyMagazineStatus(i) Then
                        RaiseEvent evChangeMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus)
                    End If
                Next
            End If
            'MagazienSupply 상태를 갱신 한다.
            beforeMagazineSupplyStatus = m_PLCDatas.nSupplyMagazineStatus.Clone

            ''Magazine Alarm이 발생하면 Alarm 상태를 읽는다.
            'For i As Integer = 0 To m_PLCDatas.nSupplyMagazineStatus.Length - 1
            '    If m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eError Or _
            '        m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eScanError Then
            '        fIsAlarmState = True
            '        Exit Sub
            '    End If
            'Next
        End If

    End Sub

    Private Sub SetMagazineExhausStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo, ByVal retryCount As Integer, ByRef beforeMagazineExhausStatus() As CDevPLCCommonNode.eMagazineStatus)
        If PLC.myPLC.SetMagazineExhausStatus(requestInfo.nMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
        End If

        'MagazienExhaus 상태 감시
        If PLC.myPLC.GetMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            'MagazienExhaus 상태에 변화가 있으면 이벤트를 날린다.
            If beforeMagazineExhausStatus.Length <> m_PLCDatas.nExhausMagazineStatus.Length Then
                RaiseEvent evChangeMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus)
            Else
                For i As Integer = 0 To beforeMagazineExhausStatus.Length - 1
                    If beforeMagazineExhausStatus(i) <> m_PLCDatas.nExhausMagazineStatus(i) Then
                        RaiseEvent evChangeMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus)
                    End If
                Next
            End If
            'MagazienExhaus 상태를 갱신 한다.
            beforeMagazineExhausStatus = m_PLCDatas.nExhausMagazineStatus.Clone

            ''시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
            'For i As Integer = 0 To m_PLCDatas.nExhausMagazineStatus.Length - 1
            '    If m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eError Or _
            '        m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eScanError Then
            '        fIsAlarmState = True
            '        Exit Sub
            '    End If
            'Next
        End If
    End Sub


#End Region


    Public Function SetDOStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetDOSignal(requestInfo.nDOStatus) = False Then Return False

        Return True
    End Function

    Public Function SetMagazineSupplyStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetMagazineSupplyStatus(requestInfo.nMagazineStatus) = False Then Return False

        Return True
    End Function

    Public Function SetMagazineExhausStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetMagazineExhausStatus(requestInfo.nMagazineStatus) = False Then Return False

        Return True
    End Function
    Public Function GetSupplyMoveCompleted(ByRef bComplete As Boolean) As Boolean

        'TRUE 일때만 완료상태이다.
        If PLC.myPLC.GetSupplyMoveCompleted(bComplete) = False Then Return False
        Return True
    End Function
    Public Function GetExhaustMoveCompleted(ByRef bComplete As Boolean) As Boolean

        'TRUE 일때만 완료상태이다.
        If PLC.myPLC.GetExhaustMoveCompleted(bComplete) = False Then Return False
        Return True
    End Function
    Public Function SetSlotSupply(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetSlotSupply(requestInfo.nSlotNumber) = False Then Return False
        Return True
    End Function
    Public Function SetSlotExhaust(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetSlotExhaust(requestInfo.nSlotNumber) = False Then Return False
        Return True
    End Function
    Public Function SetEQPStatus(ByVal requestInfo As CDevPLCCommonNode.sRequestInfo) As Boolean
        If PLC.myPLC.SetRunState(requestInfo.nEQPStatus) = False Then Return False
        Return True
    End Function

    Public Function SetAllReset() As Boolean
        If PLC.myPLC.SetAllReset() = False Then Return False
        Return True
    End Function
    Public Function SetChangeMode(ByVal mode As CDevPLCCommonNode.eRunningMode) As Boolean
        If PLC.myPLC.SetChangeMode(mode) = False Then Return False
        Return True
    End Function
    Public Function GetEQPStatue(ByRef EQPState() As CDevPLCCommonNode.eEQPStatus)
        If PLC.myPLC.GetEQPState(EQPState) = False Then Return False
        Return True
    End Function

    Public Function GetCanChange() As Boolean
        If PLC.myPLC.Can_ChangeMode() = False Then
            Return False
        End If
        Return True
    End Function
#Region "Get Control"
    Private Sub GetDOStatus(ByRef retryCount As Integer)
        If PLC.myPLC.GetDOSignal(m_PLCDatas.nDOSignal) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
        End If
    End Sub

    Private Sub GetSystemStatus(ByRef beforState() As CDevPLCCommonNode.eSystemStatus, ByRef beforAlarm() As CDevPLCCommonNode.eDISignal, ByRef retryCount As Integer, ByRef fIsAlarmState As Boolean)
        'System 상태 감시
        If PLC.myPLC.GetSystemStatus(m_PLCDatas.nSystemStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nSystemStatus.Length Then
                RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nSystemStatus(i) Then
                        RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nSystemStatus.Clone

            '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
            For i As Integer = 0 To m_PLCDatas.nSystemStatus.Length - 1
                If m_PLCDatas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eAlarm Then
                    fIsAlarmState = True
                    Exit Sub
                End If
            Next

            Dim alarm(0) As CDevPLCCommonNode.eDISignal
            alarm(0) = CDevPLCCommonNode.eDISignal.eNoError
            m_PLCDatas.nDISignal = alarm.Clone

            '알람의 상태에 변화가 있으면 이벤트를 날린다.
            If beforAlarm.Length <> m_PLCDatas.nDISignal.Length Then
                RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
            Else
                For n As Integer = 0 To beforAlarm.Length - 1
                    If beforAlarm(n) <> m_PLCDatas.nDISignal(n) Then
                        RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforAlarm = m_PLCDatas.nDISignal.Clone
        End If

    End Sub

    Private Sub GetMagazineSupplySlot(ByRef beforState() As CDevPLCCommonNode.eSlotSignal, ByRef retryCount As Integer)
        If PLC.myPLC.GetSupplySlotStatus(m_PLCDatas.nSupplySlotSignal) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nSupplySlotSignal.Length Then
                RaiseEvent evChangeMagazineSupplySlot(m_PLCDatas.nSupplySlotSignal)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nSupplySlotSignal(i) Then
                        RaiseEvent evChangeMagazineSupplySlot(m_PLCDatas.nSupplySlotSignal)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nSupplySlotSignal.Clone
        End If
    End Sub

    Private Sub GetMagazineSupplyPosition(ByRef beforState() As CDevPLCCommonNode.ePositionSignal, ByRef retryCount As Integer)
        If PLC.myPLC.GetSupplyPosition(m_PLCDatas.nSupplyPositionSignal) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nSupplyPositionSignal.Length Then
                RaiseEvent evChangeMagazineSupplyPosition(m_PLCDatas.nSupplyPositionSignal)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nSupplyPositionSignal(i) Then
                        RaiseEvent evChangeMagazineSupplyPosition(m_PLCDatas.nSupplyPositionSignal)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nSupplyPositionSignal.Clone
        End If
    End Sub

    Private Sub GetMagazineSupplyStatus(ByRef beforState() As CDevPLCCommonNode.eMagazineStatus, ByRef retryCount As Integer, ByRef fIsAlarmState As Boolean)
        If PLC.myPLC.GetMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nSupplyMagazineStatus.Length Then
                RaiseEvent evChangeMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nSupplyMagazineStatus(i) Then
                        RaiseEvent evChangeMagazineSupplyStatus(m_PLCDatas.nSupplyMagazineStatus)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nSupplyMagazineStatus.Clone
        End If
    End Sub
    Private Sub GetAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAllAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.Get_Axis_Alarm(m_PLCDatas.nAxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nAxisAlarm.Length Then
                RaiseEvent evChangeAxisAlarm(m_PLCDatas.nAxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nAxisAlarm(i) Then
                        RaiseEvent evChangeAxisAlarm(m_PLCDatas.nAxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nAxisAlarm.Clone
        End If
    End Sub
    Private Sub GetEMSAlarm(ByRef beforState() As CDevPLCCommonNode.eEMSAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetEMSAlarm(m_PLCDatas.nEmsAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nEmsAlarm.Length Then
                RaiseEvent evChangeEMSAlarm(m_PLCDatas.nEmsAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nEmsAlarm(i) Then
                        RaiseEvent evChangeEMSAlarm(m_PLCDatas.nEmsAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nEmsAlarm.Clone
        End If
    End Sub
    Private Sub GetStrangeTempAlarm(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetStrangeTempAlarm(m_PLCDatas.nStrangeTempAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nStrangeTempAlarm.Length Then
        '        RaiseEvent evChangeStrangeTempAlarm(m_PLCDatas.nStrangeTempAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nStrangeTempAlarm(i) Then
        '                RaiseEvent evChangeStrangeTempAlarm(m_PLCDatas.nStrangeTempAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nStrangeTempAlarm.Clone
        'End If
    End Sub
    Private Sub GetEOCRAlarm(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetEOCRAlarm(m_PLCDatas.nEOCRTempAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nEOCRTempAlarm.Length Then
        '        RaiseEvent evChangeEOCRAlarm(m_PLCDatas.nEOCRTempAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nEOCRTempAlarm(i) Then
        '                RaiseEvent evChangeEOCRAlarm(m_PLCDatas.nEOCRTempAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nEOCRTempAlarm.Clone
        'End If
    End Sub
    Private Sub GetSSRAlarm(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetSSRAlarm(m_PLCDatas.nSSRTempAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nSSRTempAlarm.Length Then
        '        RaiseEvent evChangeSSRAlarm(m_PLCDatas.nSSRTempAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nSSRTempAlarm(i) Then
        '                RaiseEvent evChangeSSRAlarm(m_PLCDatas.nSSRTempAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nSSRTempAlarm.Clone
        'End If
    End Sub
    Private Sub GetOverTempZone1Alarm(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetOverTempZone1Alarm(m_PLCDatas.nOverTempAlarm_Zone1) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nOverTempAlarm_Zone1.Length Then
        '        RaiseEvent evChangeOverTempZone1Alarm(m_PLCDatas.nOverTempAlarm_Zone1)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nOverTempAlarm_Zone1(i) Then
        '                RaiseEvent evChangeOverTempZone1Alarm(m_PLCDatas.nOverTempAlarm_Zone1)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nOverTempAlarm_Zone1.Clone
        'End If
    End Sub
    Private Sub GetOverTempZone2Alarm(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetOverTempZone2Alarm(m_PLCDatas.nOverTempAlarm_Zone2) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nOverTempAlarm_Zone2.Length Then
        '        RaiseEvent evChangeOverTempZone2Alarm(m_PLCDatas.nOverTempAlarm_Zone2)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nOverTempAlarm_Zone2(i) Then
        '                RaiseEvent evChangeOverTempZone2Alarm(m_PLCDatas.nOverTempAlarm_Zone2)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nOverTempAlarm_Zone2.Clone
        'End If
    End Sub
    Private Sub GetLoaderAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetLoaderAxisAlarm(m_PLCDatas.nLoaderAxisAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nLoaderAxisAlarm.Length Then
        '        RaiseEvent evChangeLoaderAxisAlarm(m_PLCDatas.nLoaderAxisAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nLoaderAxisAlarm(i) Then
        '                RaiseEvent evChangeLoaderAxisAlarm(m_PLCDatas.nLoaderAxisAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nLoaderAxisAlarm.Clone
        'End If
    End Sub
    Private Sub GetUnLoaderAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetUnLoaderAxisAlarm(m_PLCDatas.nUnLoaderAxisAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nUnLoaderAxisAlarm.Length Then
        '        RaiseEvent evChangeUnLoaderAxisAlarm(m_PLCDatas.nUnLoaderAxisAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nUnLoaderAxisAlarm(i) Then
        '                RaiseEvent evChangeUnLoaderAxisAlarm(m_PLCDatas.nUnLoaderAxisAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nUnLoaderAxisAlarm.Clone
        'End If
    End Sub
    Private Sub GetHitterAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetHitterAxisAlarm(m_PLCDatas.nHitterAxisAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0

        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nHitterAxisAlarm.Length Then
        '        RaiseEvent evChangeHitterAxisAlarm(m_PLCDatas.nHitterAxisAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nHitterAxisAlarm(i) Then
        '                RaiseEvent evChangeHitterAxisAlarm(m_PLCDatas.nHitterAxisAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nHitterAxisAlarm.Clone
        'End If
    End Sub
    Private Sub GetXAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        'If PLC.myPLC.GetXAxisAlarm(m_PLCDatas.nXAxisAlarm) = False Then
        '    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
        '    '재 연결 후에 다시 작동
        '    retryCount += 1
        'Else
        '    retryCount = 0
        '    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
        '    If beforState.Length <> m_PLCDatas.nXAxisAlarm.Length Then
        '        RaiseEvent evChangeXAxisAlarm(m_PLCDatas.nXAxisAlarm)
        '    Else
        '        For i As Integer = 0 To beforState.Length - 1
        '            If beforState(i) <> m_PLCDatas.nXAxisAlarm(i) Then
        '                RaiseEvent evChangeXAxisAlarm(m_PLCDatas.nXAxisAlarm)
        '            End If
        '        Next
        '    End If
        '    '시스템의 상태를 갱신 한다.
        '    beforState = m_PLCDatas.nXAxisAlarm.Clone
        'End If
    End Sub
    Private Sub GetYAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetYAxisAlarm(m_PLCDatas.nYAxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nYAxisAlarm.Length Then
                RaiseEvent evChangeYAxisAlarm(m_PLCDatas.nYAxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nYAxisAlarm(i) Then
                        RaiseEvent evChangeYAxisAlarm(m_PLCDatas.nYAxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nYAxisAlarm.Clone
        End If
    End Sub
    Private Sub GetZAxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetZAxisAlarm(m_PLCDatas.nZAxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nZAxisAlarm.Length Then
                RaiseEvent evChangeZAxisAlarm(m_PLCDatas.nZAxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nZAxisAlarm(i) Then
                        RaiseEvent evChangeZAxisAlarm(m_PLCDatas.nZAxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nZAxisAlarm.Clone
        End If
    End Sub
    Private Sub GetTheta1AxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTheta1AxisAlarm(m_PLCDatas.nTheta1AxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTheta1AxisAlarm.Length Then
                RaiseEvent evChangeTheta1AxisAlarm(m_PLCDatas.nTheta1AxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTheta1AxisAlarm(i) Then
                        RaiseEvent evChangeTheta1AxisAlarm(m_PLCDatas.nTheta1AxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTheta1AxisAlarm.Clone
        End If
    End Sub
    Private Sub GetTheta2AxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTheta2AxisAlarm(m_PLCDatas.nTheta1AxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTheta2AxisAlarm.Length Then
                RaiseEvent evChangeTheta2AxisAlarm(m_PLCDatas.nTheta2AxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTheta2AxisAlarm(i) Then
                        RaiseEvent evChangeTheta2AxisAlarm(m_PLCDatas.nTheta2AxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTheta2AxisAlarm.Clone
        End If
    End Sub
    Private Sub GetTheta3AxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTheta3AxisAlarm(m_PLCDatas.nTheta3AxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTheta3AxisAlarm.Length Then
                RaiseEvent evChangeTheta3AxisAlarm(m_PLCDatas.nTheta3AxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTheta3AxisAlarm(i) Then
                        RaiseEvent evChangeTheta3AxisAlarm(m_PLCDatas.nTheta3AxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTheta3AxisAlarm.Clone
        End If
    End Sub
    Private Sub GetTheta4AxisAlarm(ByRef beforState() As CDevPLCCommonNode.eAxisAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTheta4AxisAlarm(m_PLCDatas.nTheta4AxisAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTheta4AxisAlarm.Length Then
                RaiseEvent evChangeTheta4AxisAlarm(m_PLCDatas.nTheta4AxisAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTheta4AxisAlarm(i) Then
                        RaiseEvent evChangeTheta4AxisAlarm(m_PLCDatas.nTheta4AxisAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTheta4AxisAlarm.Clone
        End If
    End Sub
    Private Sub GetEQPAlaram(ByRef beforState() As CDevPLCCommonNode.eEQPLightAlaram, ByRef retryCount As Integer)
        If PLC.myPLC.Get_EQP_Alarm(m_PLCDatas.nEQPAlaram) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nEQPAlaram.Length Then
                RaiseEvent evChangeEQPAlarm(m_PLCDatas.nEQPAlaram)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nEQPAlaram(i) Then
                        RaiseEvent evChangeEQPAlarm(m_PLCDatas.nEQPAlaram)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nEQPAlaram.Clone
        End If
    End Sub
    Private Sub GetServoAlarm(ByRef beforState() As CDevPLCCommonNode.eServoAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.Get_Servo_Alarm(m_PLCDatas.nServoAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nServoAlarm.Length Then
                RaiseEvent evChangeServoAlarm(m_PLCDatas.nServoAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nServoAlarm(i) Then
                        RaiseEvent evChangeServoAlarm(m_PLCDatas.nServoAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nServoAlarm.Clone
        End If
    End Sub
    Private Sub GetEQPStatus(ByRef beforState() As CDevPLCCommonNode.eEQPStatus, ByRef retryCount As Integer)
        If PLC.myPLC.GetEQPState(m_PLCDatas.nEQPState) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0
            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nEQPState.Length Then
                RaiseEvent evChangeEQPState(m_PLCDatas.nEQPState)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nEQPState(i) Then
                        RaiseEvent evChangeEQPState(m_PLCDatas.nEQPState)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nEQPState.Clone
        End If
    End Sub



    Private Sub GetMagazineExhausSlot(ByRef beforState() As CDevPLCCommonNode.eSlotSignal, ByRef retryCount As Integer)
        If PLC.myPLC.GetExhausSlotStatus(m_PLCDatas.nExhausSlotSignal) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nExhausSlotSignal.Length Then
                RaiseEvent evChangeMagazineExhausSlot(m_PLCDatas.nExhausSlotSignal)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nExhausSlotSignal(i) Then
                        RaiseEvent evChangeMagazineExhausSlot(m_PLCDatas.nExhausSlotSignal)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nExhausSlotSignal.Clone
        End If
    End Sub

    Private Sub GetMagazineExhausPosition(ByRef beforState() As CDevPLCCommonNode.ePositionSignal, ByRef retryCount As Integer)
        If PLC.myPLC.GetExhausPosition(m_PLCDatas.nExhausPositionSignal) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nExhausPositionSignal.Length Then
                RaiseEvent evChangeMagazineExhausPosition(m_PLCDatas.nExhausPositionSignal)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nExhausPositionSignal(i) Then
                        RaiseEvent evChangeMagazineExhausPosition(m_PLCDatas.nExhausPositionSignal)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nExhausPositionSignal.Clone
        End If
    End Sub

    Private Sub GetMagazineExhausStatus(ByRef beforState() As CDevPLCCommonNode.eMagazineStatus, ByRef retryCount As Integer, ByRef fIsAlarmState As Boolean)
        If PLC.myPLC.GetMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nExhausMagazineStatus.Length Then
                RaiseEvent evChangeMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nExhausMagazineStatus(i) Then
                        RaiseEvent evChangeMagazineExhausStatus(m_PLCDatas.nExhausMagazineStatus)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nExhausMagazineStatus.Clone


            ''Magazine Alarm이 발생하면 Alarm 상태를 읽는다.
            'For i As Integer = 0 To m_PLCDatas.nExhausMagazineStatus.Length - 1
            '    If m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eScanError Or
            '        m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eError Then
            '        fIsAlarmState = True
            '        Exit Sub
            '    End If
            'Next

            'Dim alarm(0) As CDevPLCCommonNode.eMagazineError
            'alarm(0) = CDevPLCCommonNode.eMagazineError.eNoError
            'm_PLCDatas.nMagazineError = alarm.Clone

            ''알람의 상태에 변화가 있으면 이벤트를 날린다.
            'If beforAlarm.Length <> m_PLCDatas.nMagazineError.Length Then
            '    RaiseEvent evChangeMagazineAlarm(m_PLCDatas.nMagazineError)
            'Else
            '    For n As Integer = 0 To beforAlarm.Length - 1
            '        If beforAlarm(n) <> m_PLCDatas.nMagazineError(n) Then
            '            RaiseEvent evChangeMagazineAlarm(m_PLCDatas.nMagazineError)
            '        End If
            '    Next
            'End If
            ''시스템의 상태를 갱신 한다.
            'beforAlarm = m_PLCDatas.nMagazineError.Clone
        End If
    End Sub

    Private Sub GetAlarmDoor(ByRef beforState() As CDevPLCCommonNode.eDoorAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetDoorAlarm(m_PLCDatas.nDoorAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nDoorAlarm.Length Then
                RaiseEvent evChangeDoorAlarm(m_PLCDatas.nDoorAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nDoorAlarm(i) Then
                        RaiseEvent evChangeDoorAlarm(m_PLCDatas.nDoorAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nDoorAlarm.Clone
        End If

    End Sub

    Private Sub GetAlarmTemperature(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTemperatureAlarm(m_PLCDatas.nTemperatureAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTemperatureAlarm.Length Then
                RaiseEvent evChangeTemperatureAlarm(m_PLCDatas.nTemperatureAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTemperatureAlarm(i) Then
                        RaiseEvent evChangeTemperatureAlarm(m_PLCDatas.nTemperatureAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTemperatureAlarm.Clone
        End If

    End Sub

    Private Sub GetAlarmTemperatureControl(ByRef beforState() As CDevPLCCommonNode.eTemperatureAlarm, ByRef retryCount As Integer)
        If PLC.myPLC.GetTemperatureControlAlarm(m_PLCDatas.nTemperatureControlAlarm) = False Then
            '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
            '재 연결 후에 다시 작동
            retryCount += 1
        Else
            retryCount = 0

            '시스템의 상태에 변화가 있으면 이벤트를 날린다.
            If beforState.Length <> m_PLCDatas.nTemperatureControlAlarm.Length Then
                RaiseEvent evChangeTemperatureControlAlarm(m_PLCDatas.nTemperatureControlAlarm)
            Else
                For i As Integer = 0 To beforState.Length - 1
                    If beforState(i) <> m_PLCDatas.nTemperatureControlAlarm(i) Then
                        RaiseEvent evChangeTemperatureControlAlarm(m_PLCDatas.nTemperatureControlAlarm)
                    End If
                Next
            End If
            '시스템의 상태를 갱신 한다.
            beforState = m_PLCDatas.nTemperatureControlAlarm.Clone
        End If
    End Sub

#End Region

End Class
