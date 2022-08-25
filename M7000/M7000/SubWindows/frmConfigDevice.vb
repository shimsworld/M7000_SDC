Imports System.IO
Imports CCommLib
Imports CSMULib
Imports CSpectrometerLib
Imports CColorAnalyzerLib

Public Class frmConfigDevice

#Region "Define"


    Dim tpM6000 As System.Windows.Forms.TabPage
    Dim tpSG As System.Windows.Forms.TabPage
    Dim tpTC As System.Windows.Forms.TabPage
    'Dim tpTC_NX1 As System.Windows.Forms.TabPage
    'Dim tpTHC_98585 As System.Windows.Forms.TabPage
    Dim tpPLC As System.Windows.Forms.TabPage
    Dim tpMotion As System.Windows.Forms.TabPage
    Dim tpCamera As System.Windows.Forms.TabPage
    ' Dim tpPR730 As System.Windows.Forms.TabPage
    Dim tpPG As System.Windows.Forms.TabPage
    Dim tpPDMeasurementor As System.Windows.Forms.TabPage
    Dim tpSMUforIVL As System.Windows.Forms.TabPage
    Dim tpSwicth As System.Windows.Forms.TabPage
    Dim tpSpectrometer As System.Windows.Forms.TabPage
    Dim tpColorAnalyzer As System.Windows.Forms.TabPage
    Dim tpBCR As System.Windows.Forms.TabPage
    Dim tpStrobe As System.Windows.Forms.TabPage
    Dim tpDMM As System.Windows.Forms.TabPage
    '정현기
    Dim tpIVLPowerSupply As System.Windows.Forms.TabPage
    ' Dim tpPR705 As System.Windows.Forms.TabPage
    ' Dim tpSR3AR As System.Windows.Forms.TabPage


    'User Control
    Dim ucTCConfig As New ucConfigRS232_RS485(CDevTCCommonNode.SupportDeviceNames)
    '  Dim ucPLCConfig As New CCommLib.ucConfigRs232
    Dim ucSGConfig As New CCommLib.ucConfigRS485
    Dim ucPGConfig As New ucConfigPG
    Dim ucPDMeasUnit As New CCommLib.ucConfigMultiRS232
    Dim ucM6000Config As New ucM6000Config
    Dim ucSwitchConfig As New ucConfigRS232_Socket_GPIB(CDevSwitchCommonNode.SupportDeviceNames)
    Dim ucSMUForIVLConfig As New ucConfigRS232_Socket_GPIB(CDevSMUCommonNode.SupportDeviceNames)
    Dim ucSpectrometerConfig As New ucConfigRS232_Socket_GPIB(CDevSpectrometerCommonNode.SupportDeviceNames)
    Dim ucColorAnalyzerConfig As New ucConfigRS232_Socket_GPIB(CColorAnalyzerLib.CDevColorAnalyzerCommonNode.SupportDeviceNames)
    Dim ucPLCConfig As New ucConfigRS232_Socket_GPIB(CDevPLCCommonNode.SupportDeviceNames)
    Dim ucBCRConfig As New ucConfigRS232_RS485(CDevVoyager1250.SupportDeviceNames)
    Dim ucMotionComConfig As New ucConfigRS232_Socket_GPIB(CDevMotion_AJIN.SupportDeviceNames)
    Dim ucStrobeConfig As New ucConfigRS232_Socket_GPIB(CDevStrobe.SupportDeviceNames)
    Dim ucDMMConfig As New ucConfigRS232_Socket_GPIB(CDevDMM6500.SupportDeviceNames)
    '정현기 Class 개발 후 변경 예정
    Dim ucIVLPowerSupplyConfig As New ucMcIVLPowerSupplyConfig()
    Dim sSystemConfig As sConfig

    Structure sConfig
        Dim nDevice() As frmConfigSystem.eDeviceItem
        Dim MaxCh As Integer
        Dim numOfPallet As Integer
        Dim numOfJIG As Integer
        '김세훈 21
        Dim numOfIVLJIG As Integer

        Dim nCtrlUIType As ucDispMultiCtrlCommonNode.eType
        Dim M6000Config() As ucM6000Config.sM6000Config
        Dim SGConfig() As ucConfigRS485.sRS485Config
        Dim SGOutputInfo As ucSGOutputDefine.sSGOutputInfo

        'PG Device
        Dim PGConfig As ucConfigPG.sConfigs
        'McScience Pattern Generator Configs
        'Dim McPGGroup() As ucConfigMcPGGroup.sMcPGGroupInfos
        'Dim McPGConfig() As ucConfigSocket.sConfig
        'Dim McPGPwrConfig() As ucConfigRS485.sRS485Config
        'Dim McPGCtrlBDConfig() As ucConfigRS485.sRS485Config
        'G&T Systems Pattern Generator Configs
        Dim TCConfig() As ucConfigRS232_RS485.sConfig
        '  Dim PLCConfig As CComSerial.sSerialPortInfo
        Dim MotionConfig() As CDevMotion_AJIN.sMotionParams ' CDevMotion_AJIN.sMotionParams
        Dim PDMeasurementUnit() As ucConfigMultiRS232.sMultiRS232
        Dim PDMeasurementUnitMaxCh As Integer
        Dim SMUForIVLConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim SwitchConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim SpectrometerConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim ColorAnalyzerConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim PLCConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim BCRConfig() As ucConfigRS232_RS485.sConfig
        Dim MotionComConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim StrobeConfig() As ucConfigRS232_Socket_GPIB.sConfig
        Dim DMMConfig() As ucConfigRS232_Socket_GPIB.sConfig
        '정현기
        Dim IVLPowerSupplyConfig As ucMcIVLPowerSupplyConfig.sConfig

    End Structure



#End Region

#Region "Property"

    Public Property ConfigData As sConfig
        Get
            Return sSystemConfig
        End Get
        Set(ByVal value As sConfig)
            sSystemConfig = value
        End Set
    End Property

    Public Property DeviceInfo As frmConfigSystem.eDeviceItem()
        Get
            Return sSystemConfig.nDevice.Clone
        End Get
        Set(ByVal value As frmConfigSystem.eDeviceItem())
            sSystemConfig.nDevice = value.Clone
        End Set
    End Property

#End Region

#Region "Creator and initiation"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        TabControl1.Location = New System.Drawing.Point(3, 3)
        TabControl1.Size = New System.Drawing.Size(Me.ClientSize.Width - Me.DefaultMargin.Horizontal, Me.ClientSize.Height - Me.DefaultMargin.Vertical - 20 - btnOK.Size.Height)
        TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)

        'plSystemConfig.Dock = DockStyle.Fill
        'plSystemConfig.Location = New System.Drawing.Point(0, 0)
        tpM6000 = New System.Windows.Forms.TabPage
        tpM6000.Controls.Add(ucM6000Config)
        tpM6000.Text = "M6000"

        tpSG = New System.Windows.Forms.TabPage
        tpSG.Controls.Add(ucSGConfig)
        tpSG.Text = "Signal Generator"

        tpTC = New System.Windows.Forms.TabPage
        tpTC.Controls.Add(ucTCConfig)
        tpTC.Text = "Temprature Controller"

        'tpTC_NX1 = New System.Windows.Forms.TabPage
        'tpTC_NX1.Controls.Add(UcNX1Config)
        'tpTC_NX1.Text = "NX1"

        tpPLC = New System.Windows.Forms.TabPage
        tpPLC.Controls.Add(ucPLCConfig)
        tpPLC.Text = "PLC"

        tpMotion = New System.Windows.Forms.TabPage
        'tpMotion.Controls.Add(ucMotionComConfig)
        tpMotion.Controls.Add(ucMotionConfig)
        tpMotion.Text = "Motion"

        tpCamera = New System.Windows.Forms.TabPage
        'tpCamera.Controls.Add()
        tpCamera.Text = "Camera"

        'tpPR730 = New System.Windows.Forms.TabPage
        'tpPR730.Controls.Add(ucPR730Config)
        'tpPR730.Text = "Spectrometer"

        tpPG = New System.Windows.Forms.TabPage
        tpPG.Controls.Add(ucPGConfig)
        tpPG.Text = "Pettern Generator"
        tpPG.AutoScroll = True
        tpPDMeasurementor = New System.Windows.Forms.TabPage
        tpPDMeasurementor.Controls.Add(ucPDMeasUnit)
        tpPDMeasurementor.Text = "PD Measurementor"

        tpSMUforIVL = New System.Windows.Forms.TabPage
        tpSMUforIVL.Controls.Add(ucSMUForIVLConfig)
        tpSMUforIVL.Text = "SMU For IVL"

        tpSwicth = New System.Windows.Forms.TabPage
        tpSwicth.Controls.Add(ucSwitchConfig)
        tpSwicth.Text = "Switch"

        tpSpectrometer = New System.Windows.Forms.TabPage
        tpSpectrometer.Controls.Add(ucSpectrometerConfig)
        tpSpectrometer.Text = "Spectroradiometer"

        tpColorAnalyzer = New System.Windows.Forms.TabPage
        tpColorAnalyzer.Controls.Add(ucColorAnalyzerConfig)
        tpColorAnalyzer.Text = "Color Analyzer"

        tpBCR = New System.Windows.Forms.TabPage
        tpBCR.Controls.Add(ucBCRConfig)
        tpBCR.Text = "BCR"

        tpStrobe = New System.Windows.Forms.TabPage
        tpStrobe.Controls.Add(ucStrobeConfig)
        tpStrobe.Text = "Strobe"

        tpDMM = New System.Windows.Forms.TabPage
        tpDMM.Controls.Add(ucDMMConfig)
        tpDMM.Text = "DMM"

        '정현기
        tpIVLPowerSupply = New System.Windows.Forms.TabPage
        tpIVLPowerSupply.Controls.Add(ucIVLPowerSupplyConfig)
        tpIVLPowerSupply.Text = "IVL PowerSupply"

        'tpPR705 = New System.Windows.Forms.TabPage
        'tpPR705.Controls.Add(ucPR705Config)
        'tpPR705.Text = "PR705"

        'tpSR3AR = New System.Windows.Forms.TabPage
        'tpSR3AR.Text = "SR3AR"

        ucM6000Config.Location = New System.Drawing.Point(0, 0)
        ucM6000Config.Dock = DockStyle.Fill

        ucSGConfig.Location = New System.Drawing.Point(0, 0)
        ucSGConfig.Dock = DockStyle.Fill

        ucTCConfig.Location = New System.Drawing.Point(0, 0)
        ucTCConfig.Dock = DockStyle.Fill

        ucPLCConfig.Location = New System.Drawing.Point(0, 0)
        ucPLCConfig.Dock = DockStyle.Fill

        ucPDMeasUnit.Location = New System.Drawing.Point(0, 0)
        ucPDMeasUnit.Dock = DockStyle.Fill

        ucPLCConfig.Location = New System.Drawing.Point(0, 0)
        ucPLCConfig.Dock = DockStyle.Fill

        ucColorAnalyzerConfig.Location = New System.Drawing.Point(0, 0)
        ucColorAnalyzerConfig.Dock = DockStyle.Fill

        '  ucPR730Config.Location = New System.Drawing.Point(0, 0)
        '  ucPR730Config.Dock = DockStyle.Fill

        ucMotionComConfig.Location = New System.Drawing.Point(0, 0)
        'ucMotionConfig.Dock = DockStyle.Fill

        ucMotionConfig.Location = New System.Drawing.Point(0, 0)
        ucMotionConfig.Dock = DockStyle.Fill

        ucSMUForIVLConfig.Location = New System.Drawing.Point(0, 0)
        ucSMUForIVLConfig.Dock = DockStyle.Fill

        '   tpSR3AR.Location = New System.Drawing.Point(0, 0)
        '  tpSR3AR.Dock = DockStyle.Fill

        ' tpPR705.Location = New System.Drawing.Point(0, 0)
        ' tpPR705.Dock = DockStyle.Fill

        tpSwicth.Location = New System.Drawing.Point(0, 0)
        tpSwicth.Dock = DockStyle.Fill

        tpSpectrometer.Location = New System.Drawing.Point(0, 0)
        tpSpectrometer.Dock = DockStyle.Fill

        tpColorAnalyzer.Location = New System.Drawing.Point(0, 0)
        tpColorAnalyzer.Dock = DockStyle.Fill

        ucBCRConfig.Location = New System.Drawing.Point(0, 0)
        ucBCRConfig.Dock = DockStyle.Fill

        ucStrobeConfig.Location = New System.Drawing.Point(0, 0)
        ucStrobeConfig.Dock = DockStyle.Fill

        ucDMMConfig.Location = New System.Drawing.Point(0, 0)
        ucDMMConfig.Dock = DockStyle.Fill

        '정현기
        ucIVLPowerSupplyConfig.Location = New System.Drawing.Point(0, 0)
        ucIVLPowerSupplyConfig.Dock = DockStyle.Fill
    End Sub

#End Region

#Region "Control Event Heandler Functions"

    Private Sub frmSystemConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisplaySetting()
        If LoadConfiguration(sSystemConfig) = True Then
            SetValueToUI()
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If txtMaxCh.Text = "" Then
            MsgBox("Please enter system maximum channel.")
        End If

        If MsgBox("Do you want to set?", MsgBoxStyle.OkCancel, "SystemConfig") = MsgBoxResult.Ok Then
            GetValueFromUI()
            SaveConfiguration(sSystemConfig)
            g_ConfigInfos = sSystemConfig
        End If

    End Sub

#End Region

#Region "Functions"



    Private Sub DisplaySetting()

        For i As Integer = 0 To sSystemConfig.nDevice.Length - 1
            Select Case sSystemConfig.nDevice(i)

                Case frmConfigSystem.eDeviceItem.eCamera
                    TabControl1.Controls.Add(tpCamera)
                Case frmConfigSystem.eDeviceItem.ePG
                    TabControl1.Controls.Add(tpPG)
                Case frmConfigSystem.eDeviceItem.eMcSG
                    TabControl1.Controls.Add(tpSG)
                Case frmConfigSystem.eDeviceItem.eMotion
                    TabControl1.Controls.Add(tpMotion)
                Case frmConfigSystem.eDeviceItem.ePDMeasurement
                    TabControl1.Controls.Add(tpPDMeasurementor)
                Case frmConfigSystem.eDeviceItem.ePLC
                    TabControl1.Controls.Add(tpPLC)
                    TabControl1.Controls.Add(tpMotion)
                Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                    TabControl1.Controls.Add(tpSpectrometer)
                Case frmConfigSystem.eDeviceItem.eColorAnalyzer
                    TabControl1.Controls.Add(tpColorAnalyzer)
                    'Case frmConfigSystem.eDeviceItem.ePR705
                    '    TabControl1.Controls.Add(tpPR705)
                    'Case frmConfigSystem.eDeviceItem.eSR3AR
                    '    TabControl1.Controls.Add(tpSR3AR)
                Case frmConfigSystem.eDeviceItem.eSMU_M6000
                    TabControl1.Controls.Add(tpM6000)
                Case frmConfigSystem.eDeviceItem.eTC
                    TabControl1.Controls.Add(tpTC)
                    'Case frmConfigSystem.eDeviceItem.eTHC_98585
                    '    TabControl1.Controls.Add(tpTHC_98585)
                Case frmConfigSystem.eDeviceItem.eSMU_IVL
                    TabControl1.Controls.Add(tpSMUforIVL)
                Case frmConfigSystem.eDeviceItem.eSwitch
                    TabControl1.Controls.Add(tpSwicth)
                    'Case frmConfigSystem.eDeviceItem.eSW_K7001
                    '    TabControl1.Controls.Add(tpK7001)
                    'Case frmConfigSystem.eDeviceItem.eSW_SW7000
                    '    TabControl1.Controls.Add(tpSW7000)
                Case frmConfigSystem.eDeviceItem.eBCR
                    TabControl1.Controls.Add(tpBCR)
                Case frmConfigSystem.eDeviceItem.eStrobe
                    TabControl1.Controls.Add(tpStrobe)
                Case frmConfigSystem.eDeviceItem.eDMM
                    TabControl1.Controls.Add(tpDMM)
                '정현기
                Case frmConfigSystem.eDeviceItem.eIVLPowerSupply
                    TabControl1.Controls.Add(tpIVLPowerSupply)
            End Select
        Next
    End Sub

    Private Sub UcMC9Config_evSettings(ByVal Settings() As ucConfigRS485.sRS485Config)

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        GetValueFromUI()
        SaveConfiguration(sSystemConfig)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If LoadConfiguration(sSystemConfig) = True Then
            SetValueToUI()
        End If
    End Sub

    Private Sub SetValueToUI()
        With sSystemConfig
            txtMaxCh.Text = .MaxCh
            tbNumOfJIG.Text = .numOfJIG
            tbNumOfPallet.Text = .numOfPallet
            ucM6000Config.Setting = .M6000Config
            ucTCConfig.Setting = .TCConfig
            '김세훈 21
            tbNumOfIVLJIG.Text = .numOfIVLJIG

            ucSMUForIVLConfig.Setting = .SMUForIVLConfig

            ucSwitchConfig.Setting = .SwitchConfig

            ucSpectrometerConfig.Setting = .SpectrometerConfig

            'Motion    'LEX >
            ucMotionComConfig.Setting = .MotionComConfig
            ucMotionConfig.Setting = .MotionConfig
            '.PDMeasurementUnit.enableTerminator = True
            ucPDMeasUnit.Setting = .PDMeasurementUnit

            'PLC
            ucPLCConfig.Setting = .PLCConfig

            'SG
            ucSGConfig.Setting = .SGConfig

            'PG
            ucPGConfig.Setting = .PGConfig

            'ColorAnalyzer
            ucColorAnalyzerConfig.Setting = .ColorAnalyzerConfig

            'BCR Reader
            If .BCRConfig Is Nothing = False Then
                ucBCRConfig.Setting = .BCRConfig.Clone
            End If

            ucStrobeConfig.Setting = .StrobeConfig.Clone

            'DMM
            ucDMMConfig.Setting = .DMMConfig.Clone

            '정현기
            'IVL Power Supply
            ucIVLPowerSupplyConfig.Setting = .IVLPowerSupplyConfig
        End With
    End Sub


    Private Sub GetValueFromUI()
        With sSystemConfig
            .MaxCh = CInt(txtMaxCh.Text)
            .numOfJIG = CInt(tbNumOfJIG.Text)
            .numOfPallet = CInt(tbNumOfPallet.Text)
            .M6000Config = ucM6000Config.Setting
            .TCConfig = ucTCConfig.Setting
            '김세훈 21
            .numOfIVLJIG = CInt(tbNumOfIVLJIG.Text)

            .SMUForIVLConfig = ucSMUForIVLConfig.Setting

            .SwitchConfig = ucSwitchConfig.Setting

            .SpectrometerConfig = ucSpectrometerConfig.Setting

            'Motion
            .MotionComConfig = ucMotionComConfig.Setting
            .MotionConfig = ucMotionConfig.Setting

            'PD Unit
            .PDMeasurementUnit = ucPDMeasUnit.Setting

            'PLC
            .PLCConfig = ucPLCConfig.Setting

            'SG
            .SGConfig = ucSGConfig.Setting

            'PG
            .PGConfig = ucPGConfig.Setting

            'ColorAnalyzer
            .ColorAnalyzerConfig = ucColorAnalyzerConfig.Setting

            'BCR Reader
            .BCRConfig = ucBCRConfig.Setting

            .StrobeConfig = ucStrobeConfig.Setting

            'DMM
            .DMMConfig = ucDMMConfig.Setting

            '정현기
            'IVL PowerSupply
            .IVLPowerSupplyConfig = ucIVLPowerSupplyConfig.Setting
        End With
    End Sub

    Public Shared Function SaveConfiguration(ByVal configInfos As sConfig) As Boolean

        Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim sFileTitle As String = "Device Configuration Information"
        Dim sVersion As String = "1.0.0"

        '    If configInfos.M6000Config Is Nothing And configInfos.MC9Config Is Nothing Then Return False

        If Directory.Exists(g_sPATH_CONFIG_DEVICE) = False Then
            Directory.CreateDirectory(g_sPATH_CONFIG_DEVICE)
        End If

        '  If file.GetSaveFileName(CMcFile.eFileType.eINI, fileInfo) = False Then Return False

        Dim configSaver As New CConfigINI(g_sFilePath_DeviceConfig)

        'Save File Infos
        configSaver.SaveIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileTitle, sFileTitle)
        configSaver.SaveIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileVersion, sVersion)

        'Save Common Infos
        With configInfos
            configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.MaxChannel, .MaxCh)
            configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfJIG, .numOfJIG)
            configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfPallet, .numOfPallet)
            '김세훈 21
            configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfIVLJIG, .numOfIVLJIG)
            'configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterDeviceList, configInfos.nDevice.Length)
            'For i As Integer = 0 To configInfos.nDevice.Length - 1
            '    configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.KindOfDevice, i, configInfos.nDevice(i).ToString)
            'Next

            If configInfos.M6000Config Is Nothing Then 'Or configInfos.M6000Config.Length = 0 
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterM6000Infos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterM6000Infos, configInfos.M6000Config.Length)
            End If

            If configInfos.TCConfig Is Nothing Then 'Or configInfos.MC9Config.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterTCInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterTCInfos, configInfos.TCConfig.Length)
            End If

            If configInfos.SGConfig Is Nothing Then 'Or configInfos.SGConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSGInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSGInfos, configInfos.SGConfig.Length)
            End If

            If configInfos.PDMeasurementUnit Is Nothing Then 'Or configInfos.SGConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPDUnitInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPDUnitInfos, configInfos.PDMeasurementUnit.Length)
            End If

            '     If configInfos.PGConfig.nDeviceType = CDevPGCommonNode.eModel._Nothing Then

            'Else
            'End If

            If configInfos.PGConfig.McPGConfig Is Nothing Then   'Or configInfos.PGConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGInfos, configInfos.PGConfig.McPGConfig.Length)
            End If

            If configInfos.PGConfig.McPGPwrConfig Is Nothing Then  ' Or configInfos.PGPwrConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGPowerInofs, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGPowerInofs, configInfos.PGConfig.McPGPwrConfig.Length)
            End If

            If configInfos.PGConfig.McPGCtrlBDConfig Is Nothing Then   'Or configInfos.PGPwrConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGCtrlBDInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGCtrlBDInfos, configInfos.PGConfig.McPGCtrlBDConfig.Length)
            End If

            If configInfos.PGConfig.McPGGroup Is Nothing Then   'Or configInfos.PGPwrConfig.Length = 0
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGGroupInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGGroupInfos, configInfos.PGConfig.McPGGroup.Length)
            End If

            If configInfos.SMUForIVLConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSMUForIVLInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSMUForIVLInfos, configInfos.SMUForIVLConfig.Length)
            End If

            If configInfos.SwitchConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSwitchInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSwitchInfos, configInfos.SwitchConfig.Length)
            End If

            If configInfos.SpectrometerConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSpectrometer, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSpectrometer, configInfos.SpectrometerConfig.Length)
            End If

            If configInfos.ColorAnalyzerConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterColorAnalyzer, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterColorAnalyzer, configInfos.ColorAnalyzerConfig.Length)
            End If

            If configInfos.PLCConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPLC, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPLC, configInfos.PLCConfig.Length)
            End If

            If configInfos.BCRConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterBCRInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterBCRInfos, configInfos.BCRConfig.Length)
            End If

            If configInfos.MotionConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMotionInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMotionInfos, configInfos.MotionConfig.Length)
            End If


            If configInfos.StrobeConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterStrobeInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterStrobeInfos, .StrobeConfig.Length)
            End If

            If configInfos.DMMConfig Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterDMMInfos, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterDMMInfos, .DMMConfig.Length)
            End If

            If configInfos.IVLPowerSupplyConfig.settings Is Nothing Then
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterIVLPowerSupply, CStr(0))
            Else
                configSaver.SaveIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterIVLPowerSupply, .IVLPowerSupplyConfig.settings.Length)
            End If


        End With

        With configInfos

            For n As Integer = 0 To .nDevice.Length - 1

                Select Case .nDevice(n)

                    Case frmConfigSystem.eDeviceItem.eSMU_M6000

                        For i As Integer = 0 To .M6000Config.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.CommunicationType, .M6000Config(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.numberOfBoard, .M6000Config(i).numberOfBoard)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .M6000Config(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .M6000Config(i).iAllocationCh(.M6000Config(i).iAllocationCh.Length - 1).ToString)
                            Select Case .M6000Config(i).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP, CComCommonNode.eCommType.eTCP_MultiSocket
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_IPAddress, .M6000Config(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_Port, .M6000Config(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_IPAddress, .M6000Config(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_Port, .M6000Config(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_PortName, .M6000Config(i).settings.sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_BaudRate, .M6000Config(i).settings.sSerialInfo.nBaudRate.ToString)
                                    ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.M6000Config(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_DataBit, .M6000Config(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_Parity, .M6000Config(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_StopBit, .M6000Config(i).settings.sSerialInfo.nStopBits.ToString)
                                    ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.M6000Config(i).settings.sSerialInfo.sSendTerminator))
                            End Select
                        Next

                    Case frmConfigSystem.eDeviceItem.eMcSG

                        If .SGConfig Is Nothing = False Then

                            For i As Integer = 0 To .SGConfig.Length - 1
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.OFFLine, .SGConfig(i).bIsOffline)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.RS485_Address, .SGConfig(i).nSeedAddress)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.numberOfDevice, .SGConfig(i).numberOfDevice)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .SGConfig(i).iAllocationCh(0).ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .SGConfig(i).iAllocationCh(.SGConfig(i).iAllocationCh.Length - 1).ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_PortName, .SGConfig(i).sSerialInfo.sPortName.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_BaudRate, .SGConfig(i).sSerialInfo.nBaudRate.ToString)
                                ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SGConfig(i).sSerialInfo.sRcvTerminator))
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_DataBit, .SGConfig(i).sSerialInfo.nDataBits.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_Parity, .SGConfig(i).sSerialInfo.nParity.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_StopBit, .SGConfig(i).sSerialInfo.nStopBits.ToString)
                                'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SGConfig(i).sSerialInfo.sSendTerminator))
                            Next

                        End If


                    Case frmConfigSystem.eDeviceItem.ePG

                        configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.DeviceID, configInfos.PGConfig.nDeviceType.ToString)

                        Select Case configInfos.PGConfig.nDeviceType

                            Case CDevPGCommonNode.eDevModel._McPG

                                'PG Groupping Infomation
                                If .PGConfig.McPGGroup Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGGroup.Length - 1
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Seed_Ch, .PGConfig.McPGGroup(i).nSeedCh)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PG, .PGConfig.McPGGroup(i).bEnablePG)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PGCtrlBD, .PGConfig.McPGGroup(i).bEnablePGCtrl)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PGPwr, .PGConfig.McPGGroup(i).bEnablePGPwr)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PDUnit, .PGConfig.McPGGroup(i).bEnablePDUnit)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGNo_From, .PGConfig.McPGGroup(i).nPGNoFrom)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGNo_To, .PGConfig.McPGGroup(i).nPGNoTo)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGPwrNO, .PGConfig.McPGGroup(i).nPGPwrNo)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGCtrlBDNo, .PGConfig.McPGGroup(i).nPGCtrlBDNo)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PDUnitNo_From, .PGConfig.McPGGroup(i).nPDUnitNoFrom)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PDUnitNo_To, .PGConfig.McPGGroup(i).nPDUnitNoTo)
                                    Next
                                End If


                                'PG
                                If .PGConfig.McPGConfig Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGConfig.Length - 1
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.OFFLine, .PGConfig.McPGConfig(i).bIsOffLine)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PGConfig.McPGConfig(i).iAllocationCh(0).ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PGConfig.McPGConfig(i).iAllocationCh(.PGConfig.McPGPwrConfig(i).iAllocationCh.Length - 1).ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.Client_IPAddress, .PGConfig.McPGConfig(i).settings.sIPAddress)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.Client_Port, CStr(.PGConfig.McPGConfig(i).settings.nPort))
                                    Next
                                End If


                                'PG Power
                                For i As Integer = 0 To .PGConfig.McPGPwrConfig.Length - 1
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.OFFLine, .PGConfig.McPGPwrConfig(i).bIsOffline)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.RS485_Address, .PGConfig.McPGPwrConfig(i).nSeedAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.numberOfDevice, .PGConfig.McPGPwrConfig(i).numberOfDevice)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PGConfig.McPGPwrConfig(i).iAllocationCh(0).ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PGConfig.McPGPwrConfig(i).iAllocationCh(.PGConfig.McPGPwrConfig(i).iAllocationCh.Length - 1).ToString)

                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_PortName, .PGConfig.McPGPwrConfig(i).sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_BaudRate, .PGConfig.McPGPwrConfig(i).sSerialInfo.nBaudRate.ToString)
                                    ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PGConfig.McPGPwrConfig(i).sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_DataBit, .PGConfig.McPGPwrConfig(i).sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_Parity, .PGConfig.McPGPwrConfig(i).sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_StopBit, .PGConfig.McPGPwrConfig(i).sSerialInfo.nStopBits.ToString)
                                    ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PGConfig.McPGPwrConfig(i).sSerialInfo.sSendTerminator))
                                Next

                                'PG Control Board
                                For i As Integer = 0 To .PGConfig.McPGCtrlBDConfig.Length - 1
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.OFFLine, .PGConfig.McPGCtrlBDConfig(i).bIsOffline)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.RS485_Address, .PGConfig.McPGCtrlBDConfig(i).nSeedAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.numberOfDevice, .PGConfig.McPGCtrlBDConfig(i).numberOfDevice)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PGConfig.McPGCtrlBDConfig(i).iAllocationCh(0).ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PGConfig.McPGCtrlBDConfig(i).iAllocationCh(.PGConfig.McPGCtrlBDConfig(i).iAllocationCh.Length - 1).ToString)

                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_PortName, .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_BaudRate, .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nBaudRate.ToString)
                                    'configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_DataBit, .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_Parity, .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_StopBit, .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nStopBits.ToString)
                                    'configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sSendTerminator))
                                Next

                            Case CDevPGCommonNode.eDevModel._G4S

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_IPAddress, .PGConfig.G4sConfig.sServerIP)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_Port, .PGConfig.G4sConfig.nServerPort.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_SeedIPAddress, .PGConfig.G4sConfig.sSeedIP)

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.OFFLine, .PGConfig.G4sConfig.bIsOffLine.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.numberOfDevice, .PGConfig.G4sConfig.nNumberOfDev)     '접속가능한 Client 수

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_OpenTime, .PGConfig.G4sConfig.nServerOpenTime_sec.ToString)

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PGConfig.G4sConfig.iAllocationCh(0).ToString)

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PGConfig.G4sConfig.iAllocationCh(.PGConfig.G4sConfig.iAllocationCh.Length - 1).ToString)

                                '김세훈8.25 _EIP 저장Case 추가
                            Case CDevPGCommonNode.eDevModel._EIP

                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_PortName, .PGConfig.EIPConfig.sSerialInfo.sPortName)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_BaudRate, .PGConfig.EIPConfig.sSerialInfo.nBaudRate)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString, .PGConfig.EIPConfig.sSerialInfo.sRcvTerminator)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_DataBit, .PGConfig.EIPConfig.sSerialInfo.nDataBits)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_Parity, .PGConfig.EIPConfig.sSerialInfo.nParity)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_StopBit, .PGConfig.EIPConfig.sSerialInfo.nStopBits)
                                configSaver.SaveIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_TerminatorToString, .PGConfig.EIPConfig.sSerialInfo.enableTerminator)


                            Case CDevPGCommonNode.eDevModel._Nothing
                                Return False
                        End Select



                    Case frmConfigSystem.eDeviceItem.eTC

                        For i As Integer = 0 To .TCConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.OFFLine, .TCConfig(i).bIsOffline)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.DeviceID, .TCConfig(i).device)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.CommunicationType, .TCConfig(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.SubCommunicationType, .TCConfig(i).subCommunicationType)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .TCConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .TCConfig(i).iAllocationCh(.TCConfig(i).iAllocationCh.Length - 1).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.RS485_Address, .TCConfig(i).nSeedAddress)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.numberOfDevice, .TCConfig(i).numberOfDevice)

                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_PortName, .TCConfig(i).settings.sSerialInfo.sPortName.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_BaudRate, .TCConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                            ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.TCConfig(i).settings.sSerialInfo.sRcvTerminator))
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_DataBit, .TCConfig(i).settings.sSerialInfo.nDataBits.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_Parity, .TCConfig(i).settings.sSerialInfo.nParity.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_StopBit, .TCConfig(i).settings.sSerialInfo.nStopBits.ToString)
                            'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                            configSaver.SaveIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.TCConfig(i).settings.sSerialInfo.sSendTerminator))
                        Next

                        'Case frmConfigSystem.eDeviceItem.eTHC_98585

                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_PortName, .THC98585.sPortName.ToString)
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_BaudRate, .THC98585.nBaudRate.ToString)
                        '    ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.THC98585.sRcvTerminator))
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_DataBit, .THC98585.nDataBits.ToString)
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_Parity, .THC98585.nParity.ToString)
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_StopBit, .THC98585.nStopBits.ToString)
                        '    'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                        '    configSaver.SaveIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.THC98585.sSendTerminator))
                    Case frmConfigSystem.eDeviceItem.ePLC
                        For i As Integer = 0 To .PLCConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.CommunicationType, .PLCConfig(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.DeviceID, ConvertPLCDeviceToString(.PLCConfig(i).device))
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PLCConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PLCConfig(i).iAllocationCh(.PLCConfig(i).iAllocationCh.Length - 1).ToString)
                            Select Case .PLCConfig(0).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Client_IPAddress, .PLCConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Client_Port, .PLCConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Client_IPAddress, .PLCConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Client_Port, .PLCConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_PortName, .PLCConfig(i).settings.sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_BaudRate, .PLCConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PLCConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_DataBit, .PLCConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_Parity, .PLCConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_StopBit, .PLCConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PLCConfig(i).settings.sSerialInfo.sSendTerminator))
                                Case CComCommonNode.eCommType.eGPIB
                                    configSaver.SaveIniValue(CConfigINI.eSecID.ePLC, 0, CConfigINI.eKeyID.GPIB_Address, .PLCConfig(i).settings.sGPIBInfo.nAddress)
                            End Select
                        Next
                        If .MotionConfig Is Nothing = False Then
                            configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CounterAxis, CInt(.MotionConfig.Length))
                            For i As Integer = 0 To .MotionConfig.Length - 1
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CtrlMode, i, .MotionConfig(i).eMotionAxis.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Real_CtrlMode, i, .MotionConfig(i).eMotionAxisInverting.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_PulseOut, i, .MotionConfig(i).ePulseOutMethod.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_EncoderInput, i, .MotionConfig(i).eEncInputMethod.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Acceleration, i, .MotionConfig(i).dAcceleration)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Deceleration, i, .MotionConfig(i).dDeceleration)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Velocity, i, .MotionConfig(i).dVelocity)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_MaximumSpeed, i, .MotionConfig(i).dMaxSpeed)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_InitSpeed, i, .MotionConfig(i).dStartSpeed)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_UnitPulse, i, .MotionConfig(i).dUnitPulse)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_DirectionInverting, i, CStr(.MotionConfig(i).bDirectionInverting))
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_HomeSpeed, i, .MotionConfig(i).dHomeSpeed)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitPlus, i, .MotionConfig(i).nIO_Limit_P)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitMinus, i, .MotionConfig(i).nIO_Limit_M)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitPlus, i, .MotionConfig(i).nIO_SLimit_P)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitMinus, i, .MotionConfig(i).nIO_SLimit_M)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_Alarm, i, .MotionConfig(i).nIO_Alarm)
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.eMotion
                        'If .MotionComConfig Is Nothing = False Then
                        '    For i As Integer = 0 To .MotionComConfig.Length - 1
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.CommunicationType, .MotionComConfig(i).communicationType.ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.DeviceID, ConvertMotionDeviceToString(.MotionComConfig(i).device))
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .MotionComConfig(i).iAllocationCh(0).ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .MotionComConfig(i).iAllocationCh(.MotionComConfig(i).iAllocationCh.Length - 1).ToString)
                        '        Select Case .MotionComConfig(i).communicationType
                        '            Case CCommLib.CComCommonNode.eCommType.eTCP
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_IPAddress, .MotionComConfig(i).settings.sLanInfo.sIPAddress)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_Port, .MotionComConfig(i).settings.sLanInfo.nPort)
                        '            Case CCommLib.CComCommonNode.eCommType.eUDP
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_IPAddress, .MotionComConfig(i).settings.sLanInfo.sIPAddress)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_Port, .MotionComConfig(i).settings.sLanInfo.nPort)
                        '            Case CCommLib.CComCommonNode.eCommType.eSerial
                        '                If .MotionComConfig(i).settings.sSerialInfo.sPortName Is Nothing Or .MotionComConfig(i).settings.sSerialInfo.sPortName = "" Then
                        '                    .MotionComConfig(i).settings.sSerialInfo.sPortName = "COM1"
                        '                End If
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_PortName, .MotionComConfig(i).settings.sSerialInfo.sPortName.ToString)

                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_BaudRate, .MotionComConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.MotionComConfig(i).settings.sSerialInfo.sRcvTerminator))
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_DataBit, .MotionComConfig(i).settings.sSerialInfo.nDataBits.ToString)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_Parity, .MotionComConfig(i).settings.sSerialInfo.nParity.ToString)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_StopBit, .MotionComConfig(i).settings.sSerialInfo.nStopBits.ToString)
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.MotionComConfig(i).settings.sSerialInfo.sSendTerminator))
                        '            Case CComCommonNode.eCommType.eGPIB
                        '                configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.GPIB_Address, .MotionComConfig(i).settings.sGPIBInfo.nAddress)
                        '        End Select
                        '    Next
                        'End If

                        'If .MotionConfig Is Nothing = False Then
                        '   configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CounterAxis, CInt(.MotionConfig.Length))
                        '    For i As Integer = 0 To .MotionConfig.Length - 1
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CtrlMode, i, .MotionConfig(i).eMotionAxis.ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Real_CtrlMode, i, .MotionConfig(i).eMotionAxisInverting.ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_PulseOut, i, .MotionConfig(i).ePulseOutMethod.ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_EncoderInput, i, .MotionConfig(i).eEncInputMethod.ToString)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Acceleration, i, .MotionConfig(i).dAcceleration)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Deceleration, i, .MotionConfig(i).dDeceleration)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Velocity, i, .MotionConfig(i).dVelocity)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_MaximumSpeed, i, .MotionConfig(i).dMaxSpeed)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_InitSpeed, i, .MotionConfig(i).dStartSpeed)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_UnitPulse, i, .MotionConfig(i).dUnitPulse)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_DirectionInverting, i, CStr(.MotionConfig(i).bDirectionInverting))
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_HomeSpeed, i, .MotionConfig(i).dHomeSpeed)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitPlus, i, .MotionConfig(i).nIO_Limit_P)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitMinus, i, .MotionConfig(i).nIO_Limit_M)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitPlus, i, .MotionConfig(i).nIO_SLimit_P)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitMinus, i, .MotionConfig(i).nIO_SLimit_M)
                        '        configSaver.SaveIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_Alarm, i, .MotionConfig(i).nIO_Alarm)
                        '    Next
                        'End If

                    Case frmConfigSystem.eDeviceItem.eCamera


                    Case frmConfigSystem.eDeviceItem.ePDMeasurement

                        For i As Integer = 0 To .PDMeasurementUnit.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.OFFLine, .PDMeasurementUnit(i).bIsOffline)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .PDMeasurementUnit(i).nAllocationCh_From)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .PDMeasurementUnit(i).nAllocationCh_To)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_PortName, .PDMeasurementUnit(i).sSerialInfo.sPortName.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_BaudRate, .PDMeasurementUnit(i).sSerialInfo.nBaudRate.ToString)
                            ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PDMeasurementUnit(i).sSerialInfo.sRcvTerminator))
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_DataBit, .PDMeasurementUnit(i).sSerialInfo.nDataBits.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_Parity, .PDMeasurementUnit(i).sSerialInfo.nParity.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_StopBit, .PDMeasurementUnit(i).sSerialInfo.nStopBits.ToString)
                            'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                            configSaver.SaveIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.PDMeasurementUnit(i).sSerialInfo.sSendTerminator))
                        Next

                    Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                        For i As Integer = 0 To .SpectrometerConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.CommunicationType, .SpectrometerConfig(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.DeviceID, ConvertSpectrometerDeviceToString(.SpectrometerConfig(i).device))
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .SpectrometerConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .SpectrometerConfig(i).iAllocationCh(.SpectrometerConfig(i).iAllocationCh.Length - 1).ToString)
                            Select Case .SpectrometerConfig(i).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_IPAddress, .SpectrometerConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_Port, .SpectrometerConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_IPAddress, .SpectrometerConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_Port, .SpectrometerConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    Try
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_PortName, .SpectrometerConfig(i).settings.sSerialInfo.sPortName.ToString)
                                    Catch ex As Exception
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_PortName, "COM1")
                                    End Try


                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_BaudRate, .SpectrometerConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SpectrometerConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_DataBit, .SpectrometerConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_Parity, .SpectrometerConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_StopBit, .SpectrometerConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SpectrometerConfig(i).settings.sSerialInfo.sSendTerminator))
                                Case CComCommonNode.eCommType.eGPIB
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.GPIB_Address, .SpectrometerConfig(i).settings.sGPIBInfo.nAddress)
                            End Select
                        Next

                    Case frmConfigSystem.eDeviceItem.eColorAnalyzer
                        For i As Integer = 0 To .ColorAnalyzerConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.CommunicationType, .ColorAnalyzerConfig(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.DeviceID, ConvertColorAnalyzerDeviceToString(.ColorAnalyzerConfig(i).device))
                            configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .ColorAnalyzerConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .ColorAnalyzerConfig(i).iAllocationCh(.ColorAnalyzerConfig(i).iAllocationCh.Length - 1).ToString)
                            Select Case .ColorAnalyzerConfig(i).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_IPAddress, .ColorAnalyzerConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_Port, .ColorAnalyzerConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_IPAddress, .ColorAnalyzerConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_Port, .ColorAnalyzerConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_PortName, .ColorAnalyzerConfig(i).settings.sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_BaudRate, .ColorAnalyzerConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.ColorAnalyzerConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_DataBit, .ColorAnalyzerConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_Parity, .ColorAnalyzerConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_StopBit, .ColorAnalyzerConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.ColorAnalyzerConfig(i).settings.sSerialInfo.sSendTerminator))
                                Case CComCommonNode.eCommType.eGPIB
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.GPIB_Address, .SpectrometerConfig(i).settings.sGPIBInfo.nAddress)
                                Case CComCommonNode.eCommType.eUSB

                            End Select
                        Next

                    Case frmConfigSystem.eDeviceItem.eSMU_IVL
                        For i As Integer = 0 To .SMUForIVLConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.CommunicationType, .SMUForIVLConfig(i).communicationType.ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.DeviceID, ConvertKeithleyDeviceToString(.SMUForIVLConfig(i).device))
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .SMUForIVLConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .SMUForIVLConfig(i).iAllocationCh(.SMUForIVLConfig(i).iAllocationCh.Length - 1).ToString)
                            Select Case .SMUForIVLConfig(i).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_IPAddress, .SMUForIVLConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_Port, .SMUForIVLConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_IPAddress, .SMUForIVLConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_Port, .SMUForIVLConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_PortName, .SMUForIVLConfig(i).settings.sSerialInfo.sPortName.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_BaudRate, .SMUForIVLConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SMUForIVLConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_DataBit, .SMUForIVLConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_Parity, .SMUForIVLConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_StopBit, .SMUForIVLConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SMUForIVLConfig(i).settings.sSerialInfo.sSendTerminator))
                                Case CComCommonNode.eCommType.eGPIB
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.GPIB_Address, .SMUForIVLConfig(i).settings.sGPIBInfo.nAddress)
                            End Select
                        Next

                    Case frmConfigSystem.eDeviceItem.eSwitch
                        For i As Integer = 0 To .SwitchConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.DeviceID, ConvertSwitchDeviceToString(.SwitchConfig(i).device))
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .SwitchConfig(i).iAllocationCh(0).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .SwitchConfig(i).iAllocationCh(.SwitchConfig(i).iAllocationCh.Length - 1).ToString)
                            configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.CommunicationType, .SwitchConfig(i).communicationType.ToString)
                            Select Case .SwitchConfig(i).communicationType
                                Case CCommLib.CComCommonNode.eCommType.eTCP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_IPAddress, .SwitchConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_Port, .SwitchConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eUDP
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_IPAddress, .SwitchConfig(i).settings.sLanInfo.sIPAddress)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_Port, .SwitchConfig(i).settings.sLanInfo.nPort)
                                Case CCommLib.CComCommonNode.eCommType.eSerial
                                    If .SwitchConfig(i).settings.sSerialInfo.sPortName Is Nothing Or .SwitchConfig(i).settings.sSerialInfo.sPortName = "" Then
                                        .SwitchConfig(i).settings.sSerialInfo.sPortName = "COM1"
                                    End If
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_PortName, .SwitchConfig(i).settings.sSerialInfo.sPortName.ToString)

                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_BaudRate, .SwitchConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SwitchConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_DataBit, .SwitchConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_Parity, .SwitchConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_StopBit, .SwitchConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.SwitchConfig(i).settings.sSerialInfo.sSendTerminator))
                                Case CComCommonNode.eCommType.eGPIB
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.GPIB_Address, .SwitchConfig(i).settings.sGPIBInfo.nAddress)
                            End Select
                        Next

                    Case frmConfigSystem.eDeviceItem.eBCR
                        For i As Integer = 0 To .BCRConfig.Length - 1
                            configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.CommunicationType, .BCRConfig(i).communicationType.ToString)
                            Select Case .BCRConfig(i).communicationType

                                Case CComCommonNode.eCommType.eSerial
                                    Try
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_PortName, .BCRConfig(i).settings.sSerialInfo.sPortName.ToString)
                                    Catch ex As Exception
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_PortName, "COM1")
                                    End Try
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .BCRConfig(i).iAllocationCh(0).ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .BCRConfig(i).iAllocationCh(.BCRConfig(i).iAllocationCh.Length - 1).ToString)

                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_BaudRate, .BCRConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.BCRConfig(i).settings.sSerialInfo.sRcvTerminator))
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_DataBit, .BCRConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_Parity, .BCRConfig(i).settings.sSerialInfo.nParity.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_StopBit, .BCRConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                    configSaver.SaveIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.BCRConfig(i).settings.sSerialInfo.sSendTerminator))
                            End Select

                        Next

                    Case frmConfigSystem.eDeviceItem.eStrobe

                        If .StrobeConfig Is Nothing = False Then
                            For i As Integer = 0 To .StrobeConfig.Length - 1
                                configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.CommunicationType, .StrobeConfig(i).communicationType.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.DeviceID, ConvertStrobeDeviceToString(.StrobeConfig(i).device))
                                configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .StrobeConfig(i).iAllocationCh(0).ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .StrobeConfig(i).iAllocationCh(.StrobeConfig(i).iAllocationCh.Length - 1).ToString)
                                Select Case .StrobeConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_IPAddress, .StrobeConfig(i).settings.sLanInfo.sIPAddress)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_Port, .StrobeConfig(i).settings.sLanInfo.nPort)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_IPAddress, .StrobeConfig(i).settings.sLanInfo.sIPAddress)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_Port, .StrobeConfig(i).settings.sLanInfo.nPort)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        If .StrobeConfig(i).settings.sSerialInfo.sPortName Is Nothing Or .StrobeConfig(i).settings.sSerialInfo.sPortName = "" Then
                                            .StrobeConfig(i).settings.sSerialInfo.sPortName = "COM1"
                                        End If
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_PortName, .StrobeConfig(i).settings.sSerialInfo.sPortName.ToString)

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_BaudRate, .StrobeConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.StrobeConfig(i).settings.sSerialInfo.sRcvTerminator))
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_DataBit, .StrobeConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_Parity, .StrobeConfig(i).settings.sSerialInfo.nParity.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_StopBit, .StrobeConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.StrobeConfig(i).settings.sSerialInfo.sSendTerminator))
                                    Case CComCommonNode.eCommType.eGPIB
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.GPIB_Address, .StrobeConfig(i).settings.sGPIBInfo.nAddress)
                                End Select
                            Next
                        End If
                    Case frmConfigSystem.eDeviceItem.eDMM
                        If .DMMConfig Is Nothing = False Then
                            For i As Integer = 0 To .DMMConfig.Length - 1
                                configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.CommunicationType, .DMMConfig(i).communicationType.ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.DeviceID, ConvertStrobeDeviceToString(.DMMConfig(i).device))
                                configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start, .DMMConfig(i).iAllocationCh(0).ToString)
                                configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.ChannelAllocationInfo_End, .DMMConfig(i).iAllocationCh(.DMMConfig(i).iAllocationCh.Length - 1).ToString)
                                Select Case .DMMConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_IPAddress, .DMMConfig(i).settings.sLanInfo.sIPAddress)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_Port, .DMMConfig(i).settings.sLanInfo.nPort)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_IPAddress, .DMMConfig(i).settings.sLanInfo.sIPAddress)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_Port, .DMMConfig(i).settings.sLanInfo.nPort)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        If .DMMConfig(i).settings.sSerialInfo.sPortName Is Nothing Or .DMMConfig(i).settings.sSerialInfo.sPortName = "" Then
                                            .DMMConfig(i).settings.sSerialInfo.sPortName = "COM1"
                                        End If
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_PortName, .DMMConfig(i).settings.sSerialInfo.sPortName.ToString)

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_BaudRate, .DMMConfig(i).settings.sSerialInfo.nBaudRate.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.DMMConfig(i).settings.sSerialInfo.sRcvTerminator))
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_DataBit, .DMMConfig(i).settings.sSerialInfo.nDataBits.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_Parity, .DMMConfig(i).settings.sSerialInfo.nParity.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_StopBit, .DMMConfig(i).settings.sSerialInfo.nStopBits.ToString)
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_TerminatorToString, ucConfigRs232.ConvertStringToIntTerminator(.DMMConfig(i).settings.sSerialInfo.sSendTerminator))
                                    Case CComCommonNode.eCommType.eGPIB
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.GPIB_Address, .DMMConfig(i).settings.sGPIBInfo.nAddress)
                                End Select
                            Next
                        End If
                        '김세훈
                    Case frmConfigSystem.eDeviceItem.eIVLPowerSupply
                        If .IVLPowerSupplyConfig.settings Is Nothing = False Then
                            For i As Integer = 0 To .IVLPowerSupplyConfig.settings.Length - 1
                                configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.CommunicationType, .IVLPowerSupplyConfig.settings(i).commType.ToString())
                                configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.eIVLDevType, .IVLPowerSupplyConfig.DevType(i).ToString())
                                Select Case .IVLPowerSupplyConfig.settings(i).commType
                                    Case CComCommonNode.eCommType.eSerial
                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_PortName, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.sPortName))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_BaudRate, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.nBaudRate))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.sRcvTerminator))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_DataBit, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.nDataBits))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_Parity, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.nParity.ToString()))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_StopBit, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.nStopBits.ToString()))

                                        configSaver.SaveIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_TerminatorToString, (.IVLPowerSupplyConfig.settings(i).sSerialInfo.sSendTerminator))
                                End Select
                            Next
                        End If
                End Select
            Next

        End With

        Return True
    End Function


    Public Shared Function LoadConfiguration(ByRef configInfos As sConfig) As Boolean
        '   gggggggggggggg()
        Dim sFileTitle As String = "Device Configuration Information"
        Dim sVersion As String = "1.0.0"

        Dim sTemp As String
        Dim nCnt As Integer


        If File.Exists(g_sFilePath_DeviceConfig) = False Then
            Return False
        End If

        Dim configLoader As New CConfigINI(g_sFilePath_DeviceConfig)

        'Load File Infos
        sTemp = configLoader.LoadIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileTitle)
        If sTemp <> sFileTitle Then Return False
        sTemp = configLoader.LoadIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileVersion)
        If sTemp <> sVersion Then Return False

        'Load Common Infos
        With configInfos
            .MaxCh = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.MaxChannel))
            Try
                .numOfJIG = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfJIG))
            Catch ex As Exception
                .numOfJIG = 0
            End Try

            Try
                .numOfPallet = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfPallet))
            Catch ex As Exception
                .numOfPallet = 0
            End Try

            Try
                .numOfIVLJIG = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.numOfIVLJIG))
            Catch ex As Exception
                .numOfIVLJIG = 0
            End Try

            'nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterDeviceList))

            If .nDevice Is Nothing Then
                Return False
            End If

            'ReDim .nDevice(nCnt - 1)
            'For i As Integer = 0 To .nDevice.Length - 1
            '    configInfos.nDevice(i) = ConvertStrToDeviceItem(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.KindOfDevice, i))
            'Next
            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterM6000Infos))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .M6000Config = Nothing
            Else
                ReDim .M6000Config(nCnt - 1)
            End If

            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterTCInfos))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .TCConfig = Nothing
            Else
                ReDim .TCConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSGInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .SGConfig = Nothing
            Else
                ReDim .SGConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPDUnitInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PDMeasurementUnit = Nothing
            Else
                ReDim .PDMeasurementUnit(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PGConfig.McPGConfig = Nothing
            Else
                ReDim .PGConfig.McPGConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGPowerInofs)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PGConfig.McPGPwrConfig = Nothing
            Else
                ReDim .PGConfig.McPGPwrConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGCtrlBDInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PGConfig.McPGCtrlBDConfig = Nothing
            Else
                ReDim .PGConfig.McPGCtrlBDConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMcPGGroupInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PGConfig.McPGGroup = Nothing
            Else
                ReDim .PGConfig.McPGGroup(nCnt - 1)
            End If


            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSMUForIVLInfos))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .SMUForIVLConfig = Nothing
            Else
                ReDim .SMUForIVLConfig(nCnt - 1)
            End If

            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSwitchInfos))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .SwitchConfig = Nothing
            Else
                ReDim .SwitchConfig(nCnt - 1)
            End If


            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterSpectrometer))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .SpectrometerConfig = Nothing
            Else
                ReDim .SpectrometerConfig(nCnt - 1)
            End If


            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterColorAnalyzer))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .ColorAnalyzerConfig = Nothing
            Else
                ReDim .ColorAnalyzerConfig(nCnt - 1)
            End If

            Try
                nCnt = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterPLC))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .PLCConfig = Nothing
            Else
                ReDim .PLCConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterBCRInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .BCRConfig = Nothing
            Else
                ReDim .BCRConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterMotionInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .MotionComConfig = Nothing
            Else
                ReDim .MotionComConfig(nCnt - 1)
            End If

            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterStrobeInfos)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt = 0 Then
                .StrobeConfig = Nothing
            Else
                ReDim .StrobeConfig(nCnt - 1)
            End If

            If nCnt = 0 Then
                .DMMConfig = Nothing
            Else
                ReDim .DMMConfig(nCnt - 1)
            End If
            '김세훈
            Try
                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eCommon, 0, CConfigINI.eKeyID.CounterIVLPowerSupply)
            Catch ex As Exception
                nCnt = 0
            End Try
            If nCnt = 0 Then
                .IVLPowerSupplyConfig.settings = Nothing
                .IVLPowerSupplyConfig.DevType = Nothing
            Else
                ReDim .IVLPowerSupplyConfig.settings(nCnt - 1)
                ReDim .IVLPowerSupplyConfig.DevType(nCnt - 1)
            End If
        End With

        'Load
        With configInfos
            For n As Integer = 0 To .nDevice.Length - 1

                Select Case .nDevice(n)

                    Case frmConfigSystem.eDeviceItem.eSMU_M6000

                        If .M6000Config Is Nothing = False Then

                            For i As Integer = 0 To .M6000Config.Length - 1
                                .M6000Config(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.CommunicationType))
                                .M6000Config(i).numberOfBoard = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.numberOfBoard))
                                .M6000Config(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .M6000Config(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .M6000Config(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.M6000Config(i).nAllocationCh_From, .M6000Config(i).nAllocationCh_To)
                                .M6000Config(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.CommunicationType))
                                Select Case .M6000Config(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP, CComCommonNode.eCommType.eTCP_MultiSocket
                                        .M6000Config(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .M6000Config(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .M6000Config(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .M6000Config(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .M6000Config(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_PortName)
                                        .M6000Config(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                        .M6000Config(i).settings.sSerialInfo.sRcvTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString)
                                        .M6000Config(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .M6000Config(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_Parity))
                                        .M6000Config(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_StopBit))
                                        ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                        .M6000Config(i).settings.sSerialInfo.sSendTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.eM6000, i, CConfigINI.eKeyID.Serial_TerminatorToString)
                                End Select
                            Next

                        End If

                    Case frmConfigSystem.eDeviceItem.eMcSG

                        If .SGConfig Is Nothing = False Then
                            For i As Integer = 0 To .SGConfig.Length - 1
                                .SGConfig(i).bIsOffline = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.OFFLine)
                                .SGConfig(i).nSeedAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.RS485_Address)
                                .SGConfig(i).numberOfDevice = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.numberOfDevice)
                                .SGConfig(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                .SGConfig(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                .SGConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.SGConfig(i).nAllocationCh_From, .SGConfig(i).nAllocationCh_To)
                                .SGConfig(i).sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_PortName)
                                .SGConfig(i).sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_BaudRate)
                                ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                                .SGConfig(i).sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                .SGConfig(i).sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_DataBit)
                                .SGConfig(i).sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_Parity))
                                .SGConfig(i).sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_StopBit))
                                'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                                .SGConfig(i).sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMcSG, i, CConfigINI.eKeyID.Serial_TerminatorToString))
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.ePG

                        .PGConfig.nDeviceType = CDevPGCommonNode.ConvertDeviceModelStringToInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.DeviceID))

                        Select Case .PGConfig.nDeviceType

                            Case CDevPGCommonNode.eDevModel._McPG

                                'PG Groupping Infomation
                                If .PGConfig.McPGGroup Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGGroup.Length - 1
                                        .PGConfig.McPGGroup(i).nSeedCh = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Seed_Ch)
                                        .PGConfig.McPGGroup(i).bEnablePG = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PG)
                                        .PGConfig.McPGGroup(i).bEnablePGCtrl = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PGCtrlBD)
                                        .PGConfig.McPGGroup(i).bEnablePGPwr = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PGPwr)
                                        .PGConfig.McPGGroup(i).bEnablePDUnit = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_Enable_PDUnit)
                                        If .PGConfig.McPGGroup(i).bEnablePG = True Then
                                            .PGConfig.McPGGroup(i).nPGNoFrom = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGNo_From)
                                            .PGConfig.McPGGroup(i).nPGNoTo = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGNo_To)
                                            .PGConfig.McPGGroup(i).nPGNo = ucConfigRS485.GetChannelAssignList(.PGConfig.McPGGroup(i).nPGNoFrom, .PGConfig.McPGGroup(i).nPGNoTo)
                                        Else
                                            .PGConfig.McPGGroup(i).nPGNo = Nothing
                                        End If

                                        If .PGConfig.McPGGroup(i).bEnablePGCtrl = True Then
                                            .PGConfig.McPGGroup(i).nPGCtrlBDNo = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGCtrlBDNo)
                                        Else

                                        End If

                                        If .PGConfig.McPGGroup(i).bEnablePGPwr = True Then
                                            .PGConfig.McPGGroup(i).nPGPwrNo = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PGPwrNO)

                                        Else

                                        End If

                                        If .PGConfig.McPGGroup(i).bEnablePDUnit = True Then
                                            .PGConfig.McPGGroup(i).nPDUnitNoFrom = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PDUnitNo_From)
                                            .PGConfig.McPGGroup(i).nPDUnitNoTo = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGGroupping, i, CConfigINI.eKeyID.ePGGroup_PDUnitNo_To)
                                            .PGConfig.McPGGroup(i).nPDUnitNo = ucConfigRS485.GetChannelAssignList(.PGConfig.McPGGroup(i).nPDUnitNoFrom, .PGConfig.McPGGroup(i).nPDUnitNoTo)
                                        Else
                                            .PGConfig.McPGGroup(i).nPDUnitNo = Nothing
                                        End If
                                    Next
                                End If

                                'PG
                                If .PGConfig.McPGConfig Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGConfig.Length - 1
                                        .PGConfig.McPGConfig(i).bIsOffLine = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.OFFLine)
                                        .PGConfig.McPGConfig(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                        .PGConfig.McPGConfig(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                        .PGConfig.McPGConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.PGConfig.McPGConfig(i).nAllocationCh_From, .PGConfig.McPGConfig(i).nAllocationCh_To)
                                        .PGConfig.McPGConfig(i).settings.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .PGConfig.McPGConfig(i).settings.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPG, i, CConfigINI.eKeyID.Client_Port)
                                    Next
                                Else
                                    .PGConfig.McPGConfig = Nothing
                                End If

                                'PG Power
                                If .PGConfig.McPGPwrConfig Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGPwrConfig.Length - 1
                                        .PGConfig.McPGPwrConfig(i).bIsOffline = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.OFFLine)
                                        .PGConfig.McPGPwrConfig(i).nSeedAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.RS485_Address)
                                        .PGConfig.McPGPwrConfig(i).numberOfDevice = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.numberOfDevice)
                                        .PGConfig.McPGPwrConfig(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                        .PGConfig.McPGPwrConfig(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                        .PGConfig.McPGPwrConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.PGConfig.McPGPwrConfig(i).nAllocationCh_From, .PGConfig.McPGPwrConfig(i).nAllocationCh_To)

                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_PortName)
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_Parity))
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_StopBit))
                                        ' configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                        .PGConfig.McPGPwrConfig(i).sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMcPGPower, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Next
                                End If

                                'PG Control Board
                                If .PGConfig.McPGCtrlBDConfig Is Nothing = False Then
                                    For i As Integer = 0 To .PGConfig.McPGCtrlBDConfig.Length - 1
                                        .PGConfig.McPGCtrlBDConfig(i).bIsOffline = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.OFFLine)
                                        .PGConfig.McPGCtrlBDConfig(i).nSeedAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.RS485_Address)
                                        .PGConfig.McPGCtrlBDConfig(i).numberOfDevice = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.numberOfDevice)
                                        .PGConfig.McPGCtrlBDConfig(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                        .PGConfig.McPGCtrlBDConfig(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                        .PGConfig.McPGCtrlBDConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.PGConfig.McPGCtrlBDConfig(i).nAllocationCh_From, .PGConfig.McPGCtrlBDConfig(i).nAllocationCh_To)

                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_PortName)
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        'configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .M6000Config(i).sSerial.bCMDTerminator.ToString)  'YSR
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_Parity))
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_StopBit))
                                        'configSaver.SaveIniValue(CConfigINI.eSecID.eM6000Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .M6000Config(i).sSerial.bTerminator.ToString) 'YSR
                                        .PGConfig.McPGCtrlBDConfig(i).sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMCPGCtrlBoard, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Next

                                End If

                            Case CDevPGCommonNode.eDevModel._G4S

                                .PGConfig.G4sConfig.sServerIP = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_IPAddress)
                                .PGConfig.G4sConfig.nServerPort = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_Port))
                                .PGConfig.G4sConfig.sSeedIP = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_SeedIPAddress)

                                .PGConfig.G4sConfig.bIsOffLine = CBool(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.OFFLine))
                                .PGConfig.G4sConfig.nNumberOfDev = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.numberOfDevice))     '접속가능한 Client 수
                                .PGConfig.G4sConfig.nServerOpenTime_sec = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.eTCPServer_OpenTime))

                                .PGConfig.G4sConfig.nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.ChannelAllocationInfo_Start))

                                .PGConfig.G4sConfig.nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.ChannelAllocationInfo_End))

                                .PGConfig.G4sConfig.iAllocationCh = ucConfigRS485.GetChannelAssignList(.PGConfig.G4sConfig.nAllocationCh_From, .PGConfig.G4sConfig.nAllocationCh_To)

                                '김세훈 8.25 _EIP 로드 추가
                            Case CDevPGCommonNode.eDevModel._EIP
                                .PGConfig.EIPConfig.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.CommunicationType))
                                Select Case .PGConfig.EIPConfig.commType
                                    Case CComCommonNode.eCommType.eSerial
                                        .PGConfig.EIPConfig.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_PortName)
                                        .PGConfig.EIPConfig.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_BaudRate)
                                        .PGConfig.EIPConfig.sSerialInfo.sRcvTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString)
                                        .PGConfig.EIPConfig.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_DataBit)
                                        .PGConfig.EIPConfig.sSerialInfo.nStopBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_StopBit)
                                        .PGConfig.EIPConfig.sSerialInfo.sSendTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.ePatternGenerator, 0, CConfigINI.eKeyID.Serial_TerminatorToString)
                                End Select

                            Case Else

                        End Select

                    Case frmConfigSystem.eDeviceItem.eTC

                        If .TCConfig Is Nothing = False Then
                            For i As Integer = 0 To .TCConfig.Length - 1
                                .TCConfig(i).bIsOffline = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.OFFLine)
                                .TCConfig(i).device = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.DeviceID)
                                .TCConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.CommunicationType))
                                .TCConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.CommunicationType))
                                Try
                                    .TCConfig(i).subCommunicationType = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.SubCommunicationType)
                                Catch ex As Exception
                                    .TCConfig(i).subCommunicationType = 1
                                End Try


                                .TCConfig(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                .TCConfig(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                .TCConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.TCConfig(i).nAllocationCh_From, .TCConfig(i).nAllocationCh_To)
                                .TCConfig(i).nSeedAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.RS485_Address)
                                .TCConfig(i).numberOfDevice = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.numberOfDevice)


                                .TCConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_PortName)
                                .TCConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_BaudRate)
                                ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                                .TCConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                .TCConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_DataBit)
                                .TCConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_Parity))
                                .TCConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_StopBit))
                                'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                                .TCConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eTCConfig, i, CConfigINI.eKeyID.Serial_TerminatorToString))
                            Next
                        End If

                        'Case frmConfigSystem.eDeviceItem.eTHC_98585

                        '    .THC98585.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_PortName)
                        '    .THC98585.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_BaudRate)
                        '    ' configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_CMDTerminatorToByte, .MC9Config(i).sSerialInfo.bCMDTerminator.ToString) 'YSR
                        '    .THC98585.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                        '    .THC98585.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_DataBit)
                        '    .THC98585.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_Parity))
                        '    .THC98585.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_StopBit))
                        '    'configSaver.SaveIniValue(CConfigINI.eSecID.eMC9Config, i, CConfigINI.eKeyID.Serial_TermiantorToByte, .MC9Config(i).sSerialInfo.bTerminator.ToString) 'YSR
                        '    .THC98585.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eTHC98585, 0, CConfigINI.eKeyID.Serial_TerminatorToString))

                    Case frmConfigSystem.eDeviceItem.ePLC

                        If .PLCConfig Is Nothing = False Then
                            For i As Integer = 0 To .PLCConfig.Length - 1
                                .PLCConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.CommunicationType))
                                .PLCConfig(i).device = ConvertStringToPLCDevice(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.DeviceID))
                                .PLCConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.CommunicationType))
                                .PLCConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .PLCConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .PLCConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.PLCConfig(i).nAllocationCh_From, .PLCConfig(i).nAllocationCh_To)

                                Select Case .PLCConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .PLCConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .PLCConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .PLCConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .PLCConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .PLCConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_PortName)
                                        .PLCConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .PLCConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .PLCConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .PLCConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_Parity))
                                        .PLCConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .PLCConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .PLCConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.ePLC, i, CConfigINI.eKeyID.GPIB_Address))
                                    Case CComCommonNode.eCommType.eUSB

                                End Select
                            Next

                            Try
                                nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CounterAxis)
                                ReDim .MotionConfig(nCnt - 1)
                                For i As Integer = 0 To nCnt - 1
                                    .MotionConfig(i).eMotionAxis = ConvertStrToMotionAxis(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CtrlMode, i))
                                    .MotionConfig(i).eMotionAxisInverting = ConvertStrToMotionAxis(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Real_CtrlMode, i))
                                    .MotionConfig(i).ePulseOutMethod = ConvertStrToPulseOutMethod(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_PulseOut, i))
                                    .MotionConfig(i).eEncInputMethod = ConvertStrToEncInputMethod(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_EncoderInput, i))
                                    .MotionConfig(i).dAcceleration = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Acceleration, i)
                                    .MotionConfig(i).dDeceleration = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Deceleration, i)
                                    .MotionConfig(i).dVelocity = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Velocity, i)
                                    .MotionConfig(i).dMaxSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_MaximumSpeed, i)
                                    .MotionConfig(i).dStartSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_InitSpeed, i)
                                    .MotionConfig(i).dUnitPulse = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_UnitPulse, i)
                                    .MotionConfig(i).nIO_Limit_P = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitPlus, i)
                                    .MotionConfig(i).nIO_Limit_M = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitMinus, i)
                                    .MotionConfig(i).nIO_SLimit_P = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitPlus, i)
                                    .MotionConfig(i).nIO_SLimit_M = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitMinus, i)
                                    .MotionConfig(i).nIO_Alarm = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_Alarm, i)
                                    Try
                                        .MotionConfig(i).dHomeSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_HomeSpeed, i)
                                    Catch ex As Exception
                                        .MotionConfig(i).dHomeSpeed = 50
                                    End Try


                                    Try
                                        .MotionConfig(i).bDirectionInverting = CBool(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_DirectionInverting, i))
                                    Catch ex As Exception
                                        .MotionConfig(i).bDirectionInverting = False
                                    End Try

                                Next
                            Catch ex As Exception
                                nCnt = 0
                                Return False
                            End Try
                        End If


                    Case frmConfigSystem.eDeviceItem.eMotion

                        '  If .MotionComConfig Is Nothing = False Then
                        '      For i As Integer = 0 To .MotionConfig.Length - 1
                        '          .MotionComConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.CommunicationType))
                        '          .MotionComConfig(i).device = ConvertStringToMotionDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.DeviceID))
                        '          .MotionComConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.CommunicationType))
                        '          .MotionComConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                        '          .MotionComConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                        '          .MotionComConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.MotionComConfig(i).nAllocationCh_From, .MotionComConfig(i).nAllocationCh_To)

                        '          Select Case .MotionComConfig(i).communicationType
                        '              Case CCommLib.CComCommonNode.eCommType.eTCP
                        '                  .MotionComConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_IPAddress)
                        '                  .MotionComConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_Port)
                        '              Case CCommLib.CComCommonNode.eCommType.eUDP
                        '                  .MotionComConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_IPAddress)
                        '                  .MotionComConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Client_Port)
                        '              Case CCommLib.CComCommonNode.eCommType.eSerial
                        '                  .MotionComConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_PortName)
                        '                  .MotionComConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_BaudRate)
                        '                  .MotionComConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                        '                  .MotionComConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_DataBit)
                        '                  .MotionComConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_Parity))
                        '                  .MotionComConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_StopBit))
                        '                  .MotionComConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                        '              Case CComCommonNode.eCommType.eGPIB
                        '                  .MotionComConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, i, CConfigINI.eKeyID.GPIB_Address))
                        '          End Select
                        '      Next
                        '  End If

                        'Try
                        '      nCnt = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CounterAxis)
                        '      ReDim .MotionConfig(nCnt - 1)
                        '      For i As Integer = 0 To nCnt - 1
                        '          .MotionConfig(i).eMotionAxis = ConvertStrToMotionAxis(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_CtrlMode, i))
                        '          .MotionConfig(i).eMotionAxisInverting = ConvertStrToMotionAxis(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Real_CtrlMode, i))
                        '          .MotionConfig(i).ePulseOutMethod = ConvertStrToPulseOutMethod(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_PulseOut, i))
                        '          .MotionConfig(i).eEncInputMethod = ConvertStrToEncInputMethod(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_EncoderInput, i))
                        '          .MotionConfig(i).dAcceleration = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Acceleration, i)
                        '          .MotionConfig(i).dDeceleration = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Deceleration, i)
                        '          .MotionConfig(i).dVelocity = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_Velocity, i)
                        '          .MotionConfig(i).dMaxSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_MaximumSpeed, i)
                        '          .MotionConfig(i).dStartSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_InitSpeed, i)
                        '          .MotionConfig(i).dUnitPulse = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_UnitPulse, i)
                        '          .MotionConfig(i).nIO_Limit_P = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitPlus, i)
                        '          .MotionConfig(i).nIO_Limit_M = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SlowLimitMinus, i)
                        '          .MotionConfig(i).nIO_SLimit_P = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitPlus, i)
                        '          .MotionConfig(i).nIO_SLimit_M = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_SpeedLimitMinus, i)
                        '          .MotionConfig(i).nIO_Alarm = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_IO_Alarm, i)
                        '          Try
                        '              .MotionConfig(i).dHomeSpeed = configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_HomeSpeed, i)
                        '          Catch ex As Exception
                        '              .MotionConfig(i).dHomeSpeed = 50
                        '          End Try


                        '          Try
                        '              .MotionConfig(i).bDirectionInverting = CBool(configLoader.LoadIniValue(CConfigINI.eSecID.eMotion, 0, CConfigINI.eKeyID.eMotion_DirectionInverting, i))
                        '          Catch ex As Exception
                        '              .MotionConfig(i).bDirectionInverting = False
                        '          End Try

                        '      Next
                        '  Catch ex As Exception
                        '      nCnt = 0
                        '      Return False
                        '  End Try

                    Case frmConfigSystem.eDeviceItem.eCamera

                        'Component 추가
                        'Case frmConfigSystem.eDeviceItem.ePR730

                        '    Try
                        '        .PR730Config.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_PortName)
                        '        .PR730Config.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_BaudRate)
                        '        .PR730Config.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                        '        .PR730Config.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_DataBit)
                        '        .PR730Config.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_Parity))
                        '        .PR730Config.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_StopBit))
                        '        .PR730Config.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePR730, 0, CConfigINI.eKeyID.Serial_TerminatorToString))
                        '    Catch ex As Exception
                        '        Return False
                        '    End Try

                        'Case frmConfigSystem.eDeviceItem.ePR705
                        '    Try
                        '        .PR705Config.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_PortName)
                        '        .PR705Config.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_BaudRate)
                        '        .PR705Config.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                        '        .PR705Config.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_DataBit)
                        '        .PR705Config.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_Parity))
                        '        .PR705Config.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_StopBit))
                        '        .PR705Config.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePR705, 0, CConfigINI.eKeyID.Serial_TerminatorToString))
                        '    Catch ex As Exception
                        '        Return False
                        '    End Try

                    Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                        If .SpectrometerConfig Is Nothing = False Then
                            For i As Integer = 0 To .SpectrometerConfig.Length - 1
                                .SpectrometerConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.CommunicationType))
                                .SpectrometerConfig(i).device = ConvertStringToSpectrometerDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.DeviceID))
                                .SpectrometerConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.CommunicationType))
                                .SpectrometerConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .SpectrometerConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .SpectrometerConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.SpectrometerConfig(i).nAllocationCh_From, .SpectrometerConfig(i).nAllocationCh_To)

                                Select Case .SpectrometerConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .SpectrometerConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SpectrometerConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .SpectrometerConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SpectrometerConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .SpectrometerConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_PortName)
                                        .SpectrometerConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .SpectrometerConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .SpectrometerConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .SpectrometerConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_Parity))
                                        .SpectrometerConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .SpectrometerConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .SpectrometerConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSpectrometer, i, CConfigINI.eKeyID.GPIB_Address))
                                    Case CComCommonNode.eCommType.eUSB

                                End Select
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.eColorAnalyzer
                        If .ColorAnalyzerConfig Is Nothing = False Then
                            For i As Integer = 0 To .ColorAnalyzerConfig.Length - 1
                                .ColorAnalyzerConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.CommunicationType))
                                .ColorAnalyzerConfig(i).device = ConvertStringToColorAnalyzerDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.DeviceID))
                                .ColorAnalyzerConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.CommunicationType))
                                .ColorAnalyzerConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .ColorAnalyzerConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .ColorAnalyzerConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.ColorAnalyzerConfig(i).nAllocationCh_From, .ColorAnalyzerConfig(i).nAllocationCh_To)

                                Select Case .ColorAnalyzerConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .ColorAnalyzerConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .ColorAnalyzerConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .ColorAnalyzerConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .ColorAnalyzerConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_PortName)
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_Parity))
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .ColorAnalyzerConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .ColorAnalyzerConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eColorAnalyzer, i, CConfigINI.eKeyID.GPIB_Address))
                                    Case CComCommonNode.eCommType.eUSB

                                End Select
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.eSMU_IVL

                        If .SMUForIVLConfig Is Nothing = False Then
                            For i As Integer = 0 To .SMUForIVLConfig.Length - 1
                                .SMUForIVLConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.CommunicationType))
                                .SMUForIVLConfig(i).device = ConvertStringToKeithleyDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.DeviceID))
                                .SMUForIVLConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.CommunicationType))
                                .SMUForIVLConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .SMUForIVLConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .SMUForIVLConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.SMUForIVLConfig(i).nAllocationCh_From, .SMUForIVLConfig(i).nAllocationCh_To)

                                Select Case .SMUForIVLConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .SMUForIVLConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SMUForIVLConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .SMUForIVLConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SMUForIVLConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .SMUForIVLConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_PortName)
                                        .SMUForIVLConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .SMUForIVLConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .SMUForIVLConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .SMUForIVLConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_Parity))
                                        .SMUForIVLConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .SMUForIVLConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .SMUForIVLConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSMUForIVL, i, CConfigINI.eKeyID.GPIB_Address))
                                End Select
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.eSwitch

                        If .SwitchConfig Is Nothing = False Then
                            For i As Integer = 0 To .SwitchConfig.Length - 1
                                .SwitchConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.CommunicationType))
                                .SwitchConfig(i).device = ConvertStringToSwitchDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.DeviceID))
                                .SwitchConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.CommunicationType))
                                .SwitchConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .SwitchConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .SwitchConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.SwitchConfig(i).nAllocationCh_From, .SwitchConfig(i).nAllocationCh_To)

                                Select Case .SwitchConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .SwitchConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SwitchConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .SwitchConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .SwitchConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .SwitchConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_PortName)
                                        .SwitchConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .SwitchConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .SwitchConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .SwitchConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_Parity))
                                        .SwitchConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .SwitchConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.Serial_TerminatorToString))
                                    Case CComCommonNode.eCommType.eGPIB
                                        .SwitchConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eSwitch, i, CConfigINI.eKeyID.GPIB_Address))
                                End Select
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.ePDMeasurement

                        If .PDMeasurementUnit Is Nothing = False Then
                            Try
                                For i As Integer = 0 To .PDMeasurementUnit.Length - 1
                                    .PDMeasurementUnit(i).bIsOffline = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.OFFLine)
                                    .PDMeasurementUnit(i).nAllocationCh_From = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start)
                                    .PDMeasurementUnit(i).nAllocationCh_To = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.ChannelAllocationInfo_End)
                                    .PDMeasurementUnit(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.PDMeasurementUnit(i).nAllocationCh_From, .PDMeasurementUnit(i).nAllocationCh_To)
                                    .PDMeasurementUnit(i).sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_PortName)
                                    .PDMeasurementUnit(i).sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_BaudRate)
                                    .PDMeasurementUnit(i).sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                    .PDMeasurementUnit(i).sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_DataBit)
                                    .PDMeasurementUnit(i).sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_Parity))
                                    .PDMeasurementUnit(i).sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_StopBit))
                                    .PDMeasurementUnit(i).sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.ePDMeasurementUnit, i, CConfigINI.eKeyID.Serial_TerminatorToString))
                                Next
                            Catch ex As Exception
                                Return False
                            End Try

                        End If

                    Case frmConfigSystem.eDeviceItem.eBCR
                        If .BCRConfig Is Nothing = False Then
                            For i As Integer = 0 To .BCRConfig.Length - 1
                                .BCRConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.CommunicationType))
                                .BCRConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.CommunicationType))
                                .BCRConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .BCRConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .BCRConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.BCRConfig(i).nAllocationCh_From, .BCRConfig(i).nAllocationCh_To)

                                Select Case .BCRConfig(i).communicationType
                                    Case CComCommonNode.eCommType.eSerial
                                        .BCRConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_PortName)
                                        .BCRConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .BCRConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .BCRConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .BCRConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_Parity))
                                        .BCRConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .BCRConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eBCR, i, CConfigINI.eKeyID.Serial_TerminatorToString))
                                End Select
                            Next

                        End If

                    Case frmConfigSystem.eDeviceItem.eStrobe
                        If .StrobeConfig Is Nothing = False Then
                            For i As Integer = 0 To .StrobeConfig.Length - 1
                                .StrobeConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.CommunicationType))
                                .StrobeConfig(i).device = ConvertStringToStrobeDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.DeviceID))
                                .StrobeConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.CommunicationType))
                                .StrobeConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .StrobeConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .StrobeConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.StrobeConfig(i).nAllocationCh_From, .StrobeConfig(i).nAllocationCh_To)

                                Select Case .StrobeConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .StrobeConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .StrobeConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .StrobeConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .StrobeConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .StrobeConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_PortName)
                                        .StrobeConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .StrobeConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .StrobeConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .StrobeConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_Parity))
                                        .StrobeConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .StrobeConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .StrobeConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eStrobe, i, CConfigINI.eKeyID.GPIB_Address))
                                End Select
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.eDMM
                        If .DMMConfig Is Nothing = False Then
                            For i As Integer = 0 To .DMMConfig.Length - 1
                                .DMMConfig(i).communicationType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.CommunicationType))
                                .DMMConfig(i).device = ConvertStringToStrobeDevice(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.DeviceID))
                                .DMMConfig(i).settings.commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.CommunicationType))
                                .DMMConfig(i).nAllocationCh_From = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.ChannelAllocationInfo_Start))
                                .DMMConfig(i).nAllocationCh_To = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.ChannelAllocationInfo_End))
                                .DMMConfig(i).iAllocationCh = ucConfigRS485.GetChannelAssignList(.DMMConfig(i).nAllocationCh_From, .DMMConfig(i).nAllocationCh_To)

                                Select Case .DMMConfig(i).communicationType
                                    Case CCommLib.CComCommonNode.eCommType.eTCP
                                        .DMMConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .DMMConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eUDP
                                        .DMMConfig(i).settings.sLanInfo.sIPAddress = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_IPAddress)
                                        .DMMConfig(i).settings.sLanInfo.nPort = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Client_Port)
                                    Case CCommLib.CComCommonNode.eCommType.eSerial
                                        .DMMConfig(i).settings.sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_PortName)
                                        .DMMConfig(i).settings.sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .DMMConfig(i).settings.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString))
                                        .DMMConfig(i).settings.sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .DMMConfig(i).settings.sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_Parity))
                                        .DMMConfig(i).settings.sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .DMMConfig(i).settings.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.Serial_TerminatorToString))

                                    Case CComCommonNode.eCommType.eGPIB
                                        .DMMConfig(i).settings.sGPIBInfo.nAddress = CInt(configLoader.LoadIniValue(CConfigINI.eSecID.eDMM, i, CConfigINI.eKeyID.GPIB_Address))
                                End Select
                            Next
                        End If
                        '김세훈
                    Case frmConfigSystem.eDeviceItem.eIVLPowerSupply
                        If .IVLPowerSupplyConfig.settings Is Nothing = False Then
                            For i As Integer = 0 To .IVLPowerSupplyConfig.settings.Length - 1
                                .IVLPowerSupplyConfig.settings(i).commType = ConvertStringToCommType(configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.CommunicationType))
                                .IVLPowerSupplyConfig.DevType(i) = ConvertStringToIVLDevType(configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.eIVLDevType))
                                Select Case .IVLPowerSupplyConfig.settings(i).commType
                                    Case CComCommonNode.eCommType.eSerial
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.sPortName = configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_PortName)
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.nBaudRate = configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_BaudRate)
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.sRcvTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_CMDTerminatorToString)
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.nDataBits = configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_DataBit)
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.nParity = ConvertStringToParity(configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_Parity))
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.nStopBits = ConvertStringToStopBits(configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_StopBit))
                                        .IVLPowerSupplyConfig.settings(i).sSerialInfo.sSendTerminator = configLoader.LoadIniValue(CConfigINI.eSecID.eIVLPowerSupply, i, CConfigINI.eKeyID.Serial_TerminatorToString)
                                End Select
                            Next
                        End If
                End Select


            Next

        End With

        Return True
    End Function


#End Region

#Region "Convert / Comapare / Select"

    Public Shared Function ConvertSwitchDeviceToString(ByVal deviceItem As CDevSwitchCommonNode.eModel) As String
        Dim type As String = ""
        Select Case deviceItem

            Case CDevSwitchCommonNode.eModel.MC_SW7000
                type = CDevSwitchCommonNode.eModel.MC_SW7000.ToString
            Case CDevSwitchCommonNode.eModel.KEITHLEY_K7001
                type = CDevSwitchCommonNode.eModel.KEITHLEY_K7001.ToString
            Case Else
                Return "Error"
        End Select
        Return type
    End Function

    Public Shared Function ConvertMotionDeviceToString(ByVal deviceItem As CDevEZISERVOPLUSR.eModel) As String
        Dim type As String = ""
        If CDevEZISERVOPLUSR.eModel.None = deviceItem Then
            type = CDevEZISERVOPLUSR.eModel.None.ToString
        ElseIf CDevEZISERVOPLUSR.eModel.eEziSERVOPlusR = deviceItem Then
            type = CDevEZISERVOPLUSR.eModel.eEziSERVOPlusR.ToString
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToMotionDevice(ByVal str As String) As CDevEZISERVOPLUSR.eModel
        Dim type As CDevEZISERVOPLUSR.eModel
        If CDevEZISERVOPLUSR.eModel.None.ToString = str Then
            type = CDevEZISERVOPLUSR.eModel.None
        ElseIf CDevEZISERVOPLUSR.eModel.eEziSERVOPlusR.ToString = str Then
            type = CDevEZISERVOPLUSR.eModel.eEziSERVOPlusR
        End If

        Return type
    End Function

    Public Shared Function ConvertStrobeDeviceToString(ByVal deviceItem As CDevStrobe.eModel) As String
        Dim type As String = ""
        If CDevStrobe.eModel.Strobe = deviceItem Then
            type = CDevStrobe.eModel.Strobe.ToString
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToStrobeDevice(ByVal str As String) As CDevStrobe.eModel
        Dim type As CDevStrobe.eModel
        If CDevStrobe.eModel.Strobe.ToString = str Then
            type = CDevStrobe.eModel.Strobe
        End If

        Return type
    End Function
    '정현기
    Public Shared Function ConvertIVLDeviceToString(ByVal deviceItem As ucMcIVLPowerSupplyConfig.eDevType) As String
        Dim type As String = ""
        Select Case deviceItem
            Case ucMcIVLPowerSupplyConfig.eDevType._R
                type = ucMcIVLPowerSupplyConfig.eDevType._R.ToString
            Case ucMcIVLPowerSupplyConfig.eDevType._G
                type = ucMcIVLPowerSupplyConfig.eDevType._G.ToString
            Case ucMcIVLPowerSupplyConfig.eDevType._B
                type = ucMcIVLPowerSupplyConfig.eDevType._R.ToString
            Case ucMcIVLPowerSupplyConfig.eDevType._Vdd
                type = ucMcIVLPowerSupplyConfig.eDevType._Vdd.ToString
            Case ucMcIVLPowerSupplyConfig.eDevType._Vss
                type = ucMcIVLPowerSupplyConfig.eDevType._Vss.ToString
        End Select
        Return type
    End Function


    Public Shared Function ConvertKeithleyDeviceToString(ByVal deviceItem As CDevSMUCommonNode.eModel) As String
        Dim type As String = ""
        If CDevSMUCommonNode.eModel.KEITHLEY_K236 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K236.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K237 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K237.ToString
        ElseIf CDevSMUCommonNode.eModel.kEITHLEY_K238 = deviceItem Then
            type = CDevSMUCommonNode.eModel.kEITHLEY_K238.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2400 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2400.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2410 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2410.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2420 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2420.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2425 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2425.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2430 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2430.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2440 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2440.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2450 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2450.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2601 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2601.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2635 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2635.ToString
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2636 = deviceItem Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2636.ToString
            'ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2651A = deviceItem Then
            '    type = CDevSMUCommonNode.eModel.KEITHLEY_K2651A.ToString
        ElseIf CDevSMUCommonNode.eModel.MCSCIENCE_M6100 = deviceItem Then
            type = CDevSMUCommonNode.eModel.MCSCIENCE_M6100.ToString
        End If
        Return type
    End Function

    Public Shared Function ConvertSpectrometerDeviceToString(ByVal deviceItem As CDevSpectrometerCommonNode.eModel) As String
        Dim type As String = ""
        If CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000 = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro.ToString
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000A = deviceItem Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000A.ToString
        End If
        Return type
    End Function

    Public Shared Function ConvertColorAnalyzerDeviceToString(ByVal deviceItem As CDevColorAnalyzerCommonNode.eModel) As String
        Dim type As String = ""
        If CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_BM7A = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_BM7A.ToString
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode.ToString
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode.ToString
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A.ToString
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50 = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50.ToString
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_None = deviceItem Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_None.ToString
        End If

        Return type
    End Function

    Public Shared Function ConvertPLCDeviceToString(ByVal deviceItem As CDevPLCCommonNode.eModel) As String
        Dim type As String = ""
        If CDevPLCCommonNode.eModel.LS = deviceItem Then
            type = CDevPLCCommonNode.eModel.LS.ToString
        ElseIf CDevPLCCommonNode.eModel.MITSUBISHI = deviceItem Then
            type = CDevPLCCommonNode.eModel.MITSUBISHI.ToString
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToSwitchDevice(ByVal str As String) As CDevSwitchCommonNode.eModel
        Dim type As CDevSwitchCommonNode.eModel
        If CDevSwitchCommonNode.eModel.KEITHLEY_K7001.ToString = str Then
            type = CDevSwitchCommonNode.eModel.KEITHLEY_K7001
        ElseIf CDevSwitchCommonNode.eModel.MC_SW7000.ToString = str Then
            type = CDevSwitchCommonNode.eModel.MC_SW7000
        End If
        Return type
    End Function

    Public Shared Function ConvertStringToKeithleyDevice(ByVal str As String) As CDevSMUCommonNode.eModel
        Dim type As CDevSMUCommonNode.eModel
        If CDevSMUCommonNode.eModel.KEITHLEY_K236.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K236
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K237.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K237
        ElseIf CDevSMUCommonNode.eModel.kEITHLEY_K238.ToString = str Then
            type = CDevSMUCommonNode.eModel.kEITHLEY_K238
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2400.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2400
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2410.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2410
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2420.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2420
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2425.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2425
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2430.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2430
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2440.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2440
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2450.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2450
        ElseIf CDevSMUCommonNode.eModel.KEITHLEY_K2635.ToString = str Then
            type = CDevSMUCommonNode.eModel.KEITHLEY_K2635
        End If
        Return type
    End Function

    Public Shared Function ConvertStringToSpectrometerDevice(ByVal str As String) As CDevSpectrometerCommonNode.eModel
        Dim type As CDevSpectrometerCommonNode.eModel
        If CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000A.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000A
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE
        ElseIf CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro.ToString = str Then
            type = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToColorAnalyzerDevice(ByVal str As String) As CDevColorAnalyzerCommonNode.eModel
        Dim type As CDevColorAnalyzerCommonNode.eModel

        If CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_BM7A.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_BM7A
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50
        ElseIf CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_None.ToString = str Then
            type = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_None
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToPLCDevice(ByVal str As String) As CDevPLCCommonNode.eModel
        Dim type As CDevPLCCommonNode.eModel
        If CDevPLCCommonNode.eModel.LS.ToString = str Then
            type = CDevPLCCommonNode.eModel.LS
        ElseIf CDevPLCCommonNode.eModel.MITSUBISHI.ToString = str Then
            type = CDevPLCCommonNode.eModel.MITSUBISHI
        End If

        Return type
    End Function

    Public Shared Function ConvertStringToCommType(ByVal str As String) As CCommLib.CComCommonNode.eCommType
        Dim type As CCommLib.CComCommonNode.eCommType
        If CCommLib.CComCommonNode.eCommType.eTCP.ToString = str Then
            type = CCommLib.CComCommonNode.eCommType.eTCP
        ElseIf str = CCommLib.CComCommonNode.eCommType.eSerial.ToString Then
            type = CCommLib.CComCommonNode.eCommType.eSerial
        ElseIf str = CCommLib.CComCommonNode.eCommType.eUDP.ToString Then
            type = CCommLib.CComCommonNode.eCommType.eUDP
        ElseIf str = CCommLib.CComCommonNode.eCommType.eGPIB.ToString Then
            type = CCommLib.CComCommonNode.eCommType.eGPIB
        ElseIf str = CCommLib.CComCommonNode.eCommType.eUSB.ToString Then
            type = CComCommonNode.eCommType.eUSB
        ElseIf str = CCommLib.CComCommonNode.eCommType.eTCP_MultiSocket.ToString Then
            type = CComCommonNode.eCommType.eTCP_MultiSocket
        End If
        Return type
    End Function

    Public Shared Function ConvertStringToIVLDevType(ByVal str As String) As ucMcIVLPowerSupplyConfig.eDevType
        Dim type As ucMcIVLPowerSupplyConfig.eDevType
        If str = ucMcIVLPowerSupplyConfig.eDevType._R.ToString() Then
            type = ucMcIVLPowerSupplyConfig.eDevType._R
        ElseIf str = ucMcIVLPowerSupplyConfig.eDevType._G.ToString() Then
            type = ucMcIVLPowerSupplyConfig.eDevType._G
        ElseIf str = ucMcIVLPowerSupplyConfig.eDevType._B.ToString() Then
            type = ucMcIVLPowerSupplyConfig.eDevType._B
        ElseIf str = ucMcIVLPowerSupplyConfig.eDevType._Vdd.ToString Then
            type = ucMcIVLPowerSupplyConfig.eDevType._Vdd
        ElseIf str = ucMcIVLPowerSupplyConfig.eDevType._Vss.ToString Then
            type = ucMcIVLPowerSupplyConfig.eDevType._Vss
        End If
        Return type
    End Function

    Public Shared Function ConvertStringToStopBits(ByVal in_data As String) As IO.Ports.StopBits
        Dim type As IO.Ports.StopBits
        If in_data = IO.Ports.StopBits.None.ToString Then
            type = IO.Ports.StopBits.None
        ElseIf in_data = IO.Ports.StopBits.One.ToString Then
            type = IO.Ports.StopBits.One
        ElseIf in_data = IO.Ports.StopBits.OnePointFive.ToString Then
            type = IO.Ports.StopBits.OnePointFive
        ElseIf in_data = IO.Ports.StopBits.Two.ToString Then
            type = IO.Ports.StopBits.Two
        End If
        Return type
    End Function

    Public Shared Function ConvertStringToParity(ByVal in_data As String) As IO.Ports.Parity
        Dim type As IO.Ports.Parity
        If in_data = IO.Ports.Parity.Even.ToString Then
            type = IO.Ports.Parity.Even
        ElseIf in_data = IO.Ports.Parity.Mark.ToString Then
            type = IO.Ports.Parity.Mark
        ElseIf in_data = IO.Ports.Parity.None.ToString Then
            type = IO.Ports.Parity.None
        ElseIf in_data = IO.Ports.Parity.Odd.ToString Then
            type = IO.Ports.Parity.Odd
        ElseIf in_data = IO.Ports.Parity.Space.ToString Then
            type = IO.Ports.Parity.Space
        End If
        Return type
    End Function

    Public Shared Function AllocationChSetting(ByVal StartPoint As Integer, ByVal EndPoint As Integer) As Integer()
        Dim iAllocationBuff(EndPoint - StartPoint) As Integer

        For i2 As Integer = 0 To (EndPoint - StartPoint)
            iAllocationBuff(i2) = StartPoint + i2
        Next
        Return iAllocationBuff.Clone
    End Function

    Public Function ConvertStrToDeviceItem(ByVal str As String) As frmConfigSystem.eDeviceItem

        Select Case str
            Case frmConfigSystem.eDeviceItem.eCamera.ToString
                Return frmConfigSystem.eDeviceItem.eCamera
            Case frmConfigSystem.eDeviceItem.ePG.ToString
                Return frmConfigSystem.eDeviceItem.ePG
            Case frmConfigSystem.eDeviceItem.eMcSG.ToString
                Return frmConfigSystem.eDeviceItem.eMcSG
            Case frmConfigSystem.eDeviceItem.eMotion.ToString
                Return frmConfigSystem.eDeviceItem.eMotion
            Case frmConfigSystem.eDeviceItem.ePDMeasurement.ToString
                Return frmConfigSystem.eDeviceItem.ePDMeasurement
            Case frmConfigSystem.eDeviceItem.ePLC.ToString
                Return frmConfigSystem.eDeviceItem.ePLC
                'Case frmConfigSystem.eDeviceItem.ePR730.ToString
                '    Return frmConfigSystem.eDeviceItem.ePR730
                'Case frmConfigSystem.eDeviceItem.ePR705.ToString
                '    Return frmConfigSystem.eDeviceItem.ePR705
                'Case frmConfigSystem.eDeviceItem.eSR3AR.ToString
                '    Return frmConfigSystem.eDeviceItem.eSR3AR
            Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                Return frmConfigSystem.eDeviceItem.eSpectroradiometer
            Case frmConfigSystem.eDeviceItem.eSMU_IVL.ToString
                Return frmConfigSystem.eDeviceItem.eSMU_IVL
            Case frmConfigSystem.eDeviceItem.eSwitch.ToString
                Return frmConfigSystem.eDeviceItem.eSwitch
            Case frmConfigSystem.eDeviceItem.eSMU_M6000.ToString
                Return frmConfigSystem.eDeviceItem.eSMU_M6000
            Case frmConfigSystem.eDeviceItem.eTC.ToString
                Return frmConfigSystem.eDeviceItem.eTC
            Case frmConfigSystem.eDeviceItem.eColorAnalyzer
                Return frmConfigSystem.eDeviceItem.eColorAnalyzer
                'Case frmConfigSystem.eDeviceItem.eTHC_98585.ToString
                '    Return frmConfigSystem.eDeviceItem.eTHC_98585
            Case frmConfigSystem.eDeviceItem.eBCR
                Return frmConfigSystem.eDeviceItem.eBCR
            Case Else
                Return -1
        End Select

    End Function

    Public Shared Function ConvertStrToMotionAxis(ByVal str As String) As CDevEZISERVOPLUSR.eMotionAxis

        Select Case str

            Case CDevMotion_AJIN.eMotionAxis.eNot_Use.ToString
                Return CDevMotion_AJIN.eMotionAxis.eNot_Use
            Case CDevMotion_AJIN.eMotionAxis.eX_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eX_Axis
            Case CDevMotion_AJIN.eMotionAxis.eY_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eY_Axis
            Case CDevMotion_AJIN.eMotionAxis.eZ_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eZ_Axis
            Case CDevMotion_AJIN.eMotionAxis.eTheta_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eTheta_Axis
            Case CDevMotion_AJIN.eMotionAxis.eTheta2_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eTheta2_Axis
            Case CDevMotion_AJIN.eMotionAxis.eTheta3_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eTheta3_Axis
            Case CDevMotion_AJIN.eMotionAxis.eTheta4_Axis.ToString
                Return CDevMotion_AJIN.eMotionAxis.eTheta4_Axis
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertStrToPulseOutMethod(ByVal str As String) As CDevMotion_AJIN.ePulseOutMethod
        Select Case str

            Case CDevMotion_AJIN.ePulseOutMethod.eOneHighLowHigh.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eOneHighLowHigh
            Case CDevMotion_AJIN.ePulseOutMethod.eOneHighHighLow.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eOneHighHighLow
            Case CDevMotion_AJIN.ePulseOutMethod.eOneLowLowHigh.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eOneLowLowHigh
            Case CDevMotion_AJIN.ePulseOutMethod.eOneLowHighLow.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eOneLowHighLow
            Case CDevMotion_AJIN.ePulseOutMethod.eTwoCcwCwHigh.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eTwoCcwCwHigh
            Case CDevMotion_AJIN.ePulseOutMethod.eTwoCcwCwLow.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eTwoCcwCwLow
            Case CDevMotion_AJIN.ePulseOutMethod.eTwoCwCcwHigh.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eTwoCwCcwHigh
            Case CDevMotion_AJIN.ePulseOutMethod.eTwoCwCcwLow.ToString
                Return CDevMotion_AJIN.ePulseOutMethod.eTwoCwCcwLow
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertStrToEncInputMethod(ByVal str As String) As CDevMotion_AJIN.eEncoderInputMethod
        Select Case str
            Case CDevMotion_AJIN.eEncoderInputMethod.eUpDownMode.ToString
                Return CDevMotion_AJIN.eEncoderInputMethod.eUpDownMode
            Case CDevMotion_AJIN.eEncoderInputMethod.eSqr1Mode.ToString
                Return CDevMotion_AJIN.eEncoderInputMethod.eSqr1Mode
            Case CDevMotion_AJIN.eEncoderInputMethod.eSqr2Mode.ToString
                Return CDevMotion_AJIN.eEncoderInputMethod.eSqr2Mode
            Case CDevMotion_AJIN.eEncoderInputMethod.eSqr4Mode.ToString
                Return CDevMotion_AJIN.eEncoderInputMethod.eSqr4Mode
            Case Else
                Return -1
        End Select
    End Function

#End Region


End Class