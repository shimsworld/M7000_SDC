Public Class CConfigINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub
    '김세훈
    Private strSection() As String = New String() {"File Info",
                                                   "Common",
                                                   "M6000Config",
                                                   "McSignalGenerator",
                                                 "PatternGenerator", "McPGGroupping", "McPatternGenerator", "McPGPower", "McPGControlBoard",
                                                   "Camera",
                                                   "Spectrometer",
                                                   "TCConfig",
                                                   "PLC",
                                                   "Motion",
                                                   "PD Measurement Unit",
                                                   "SMUForIVL",
                                                   "Switch",
                                                   "ColorAnalyzer",
                                                   "BCR",
                                                  "Strobe",
                                                   "DMM",
                                                   "IVLPowerSupply"
                                                  }
    '   "THC_98585", _

    Private strKey() As String = New String() {"FileTitle", "File Version", "MaxChannel", "number Of JIG", "number Of Pallet", "number Of IVLJIG",
                                               "CounterM6000", "CounterTC", "CounterSG", "CounterPDMeasUnit", "CounterPG", "CounterPGPower", "CounterPGCtrlBD", "CounterPGGrouppingInfo",
                                               "CounterSMUForIVL", "CounterSwitch", "CounterSpectrometer", " CounterColorAnalyzer", "CounterPLC", "CounterBCR", "CounterMotion", "CounterStrobe", "CounterDMM", "CounterIVLPowerSupply",
                                               "CounterDeviceList", "KindOfDevice",
                                               "number of Board in M6000",
                                               "SystemMaxVolt", "SystemMaxCurrent",
                                               "Device ID", "CommunicationType", "SubCommunicationType", "OFFLine", "LAN_Address", "LAN_PortNum",
                                               "Serial_PortName", "Serial_BaudRate",
                                               "Serial_DataBit", "Serial_Parity", "Serial_StopBit", "Serial_TerminatorToString", "Serial_CMDTerminatorToString",
                                               "Serial_TermiantorToByte", "Serial_CMDTerminatorToByte",
                                               "GPIB_Address",
                                               "number Of Device", "RS485_Address", "ChannelAllocationInfo_Start", "ChannelAllocationInfo_End",
        "Motion Pulse Out Method", "Motion Control Mode", "Motion Real Control Mode", "Motion Encoder Input", "Motion Velocity", "Motion Acceleration",
        "Motion Deceleration", "Motion Maximum Speed", "Motion Count Axis", "Motion Init Speed", "Motion Unit Pulse", "Motion Direction Inverting", "Motion Sync Control", "Motion Home Speed", "Motion Home Serch Speed", "Motion IO Limit (+)", "Motion IO Limit (-)", "Motion IO SLimit (+)", "Motion IO SLimit (-)", "Motion IO Alarm",
        "PGGroup_Enable_PG", "PGGroup_Enable_PGPwr", "PGGroup_Enable_PGCtrlBD", "PGGroup_Enable_PDUnit",
        "PGGroup_PGNo_From", "PGGroup_PGNo_To", "PGGroup_PDUnitNo_From", "PGGroup_PDUnitNo_To", "PGGroup_PGPwrNO", "PGGroup_PGCtrlBDNo", "PGGroup_Seed_Ch",
                "TCPServer_OpenTime_ms", "TCPServer_IPAddress", "TCPServer_Port", "TCPServer_SeedIPAddress", "IVL_PowerSupplyDevide_Type"
                                }
    '김세훈
    Public Enum eSecID
        eFileInfo
        eCommon
        eM6000
        eMcSG
        ePatternGenerator   'Module Driver
        eMcPGGroupping
        eMcPG
        eMcPGPower
        eMCPGCtrlBoard
        eCamera
        eSpectrometer
        eTCConfig
        ePLC
        eMotion
        ePDMeasurementUnit
        eSMUForIVL
        eSwitch
        eColorAnalyzer
        eBCR
        eStrobe
        eDMM
        eIVLPowerSupply
    End Enum

    '  eTHC98585

    Public Enum eKeyID
        FileTitle        'File Info
        FileVersion
        MaxChannel       'Common
        numOfJIG
        numOfPallet
        numOfIVLJIG
        CounterM6000Infos
        CounterTCInfos
        CounterSGInfos
        CounterPDUnitInfos
        CounterMcPGInfos
        CounterMcPGPowerInofs
        CounterMcPGCtrlBDInfos
        CounterMcPGGroupInfos
        CounterSMUForIVLInfos
        CounterSwitchInfos
        CounterSpectrometer
        CounterColorAnalyzer
        CounterPLC
        CounterBCRInfos
        CounterMotionInfos
        CounterStrobeInfos
        CounterDMMInfos
        CounterIVLPowerSupply '김세훈
        CounterDeviceList    '시스템 구성 컴포넌트의 종류의 수
        KindOfDevice         '시스템 구성 컴포넌트의 종류
        numberOfBoard
        SystemMaxVolt
        SystemMaxCurrent
        DeviceID        'Switch Device(K7001, SW7000) ID, SMU Device(K236, 2400, 2635) ID
        CommunicationType
        SubCommunicationType
        OFFLine
        Client_IPAddress
        Client_Port
        Serial_PortName
        Serial_BaudRate
        Serial_DataBit
        Serial_Parity
        Serial_StopBit
        Serial_TerminatorToString
        Serial_CMDTerminatorToString
        Serial_TermiantorToByte
        Serial_CMDTerminatorToByte
        GPIB_Address
        numberOfDevice                  '각 Device 수의 수량 저장, ex) M6000, 5EA
        RS485_Address
        ChannelAllocationInfo_Start
        ChannelAllocationInfo_End
        eMotion_PulseOut                'Motion
        eMotion_CtrlMode
        eMotion_Real_CtrlMode
        eMotion_EncoderInput
        eMotion_Velocity
        eMotion_Acceleration
        eMotion_Deceleration
        eMotion_MaximumSpeed
        eMotion_CounterAxis
        eMotion_InitSpeed
        eMotion_UnitPulse
        eMotion_DirectionInverting
        eMotion_SyncControl
        eMotion_HomeSpeed
        eMotion_HomeSerchSpeed
        eMotion_IO_SpeedLimitPlus
        eMotion_IO_SpeedLimitMinus
        eMotion_IO_SlowLimitPlus
        eMotion_IO_SlowLimitMinus
        eMotion_IO_Alarm
        ePGGroup_Enable_PG
        ePGGroup_Enable_PGPwr
        ePGGroup_Enable_PGCtrlBD
        ePGGroup_Enable_PDUnit
        ePGGroup_PGNo_From
        ePGGroup_PGNo_To
        ePGGroup_PDUnitNo_From
        ePGGroup_PDUnitNo_To
        ePGGroup_PGPwrNO
        ePGGroup_PGCtrlBDNo
        ePGGroup_Seed_Ch
        eTCPServer_OpenTime  'Client Accept Time
        eTCPServer_IPAddress
        eTCPServer_Port
        eTCPServer_SeedIPAddress
        eIVLDevType '정현기
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)


        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function

End Class
