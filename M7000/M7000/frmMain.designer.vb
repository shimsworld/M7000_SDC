<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mainStatus = New System.Windows.Forms.StatusStrip()
        Me.tlStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlQueueCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlManualQueueCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlPLCQueueCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlPLCQueue = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlInnerTemp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlInnerHumi = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlBCRInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlAlarm = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslRemainTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LogInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HWConnectionToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SWConnectionToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SystemConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelAllocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RangeSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PGImageManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZeroCalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAFETYModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SequenceBuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MotionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDMeasurementUnitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MC9ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NX1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.THC98585ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M6000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SignalGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.K26XXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.K24XXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.K23XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PR705ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.K7001ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SW7000ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorAnalyzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TTM004ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpectrometerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SVSCameraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StrobeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EIPPGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IVLPowerSupplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SW7700ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunctionTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestUIToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PGTestUIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UITestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProcessThreadRUNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessThreadStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsBtnAllCheckClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbSWConnection = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnConnection = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnDisconnection = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestRUN = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestSTOP = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestPAUSE = New System.Windows.Forms.ToolStripButton()
        Me.tsbControlViewMode = New System.Windows.Forms.ToolStripButton()
        Me.tsbSelUI_Monitoring = New System.Windows.Forms.ToolStripButton()
        Me.tsbSelUI_Motion = New System.Windows.Forms.ToolStripButton()
        Me.tsSequenceBulider = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnTestRed = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestGreen = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestBlue = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnTestBlack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbPretestViewMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsIVLDisplayShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnCare = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnAlarm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbIVLGraph = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.mainStatus.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainStatus
        '
        Me.mainStatus.BackColor = System.Drawing.Color.White
        Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlStatus, Me.tlQueueCounter, Me.tlManualQueueCounter, Me.tlPLCQueueCounter, Me.ToolStripStatusLabel2, Me.tlPLCQueue, Me.tlInnerTemp, Me.tlInnerHumi, Me.tlBCRInfo, Me.tlAlarm, Me.tslRemainTime, Me.ToolStripSeparator1})
        Me.mainStatus.Location = New System.Drawing.Point(0, 620)
        Me.mainStatus.Name = "mainStatus"
        Me.mainStatus.Size = New System.Drawing.Size(1302, 23)
        Me.mainStatus.TabIndex = 0
        Me.mainStatus.Text = "StatusStrip1"
        '
        'tlStatus
        '
        Me.tlStatus.AutoSize = False
        Me.tlStatus.Name = "tlStatus"
        Me.tlStatus.Size = New System.Drawing.Size(300, 18)
        Me.tlStatus.Text = "Status Message"
        Me.tlStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlQueueCounter
        '
        Me.tlQueueCounter.AutoSize = False
        Me.tlQueueCounter.Name = "tlQueueCounter"
        Me.tlQueueCounter.Size = New System.Drawing.Size(180, 18)
        Me.tlQueueCounter.Text = "Queue Counter = 0"
        '
        'tlManualQueueCounter
        '
        Me.tlManualQueueCounter.AutoSize = False
        Me.tlManualQueueCounter.Name = "tlManualQueueCounter"
        Me.tlManualQueueCounter.Size = New System.Drawing.Size(180, 18)
        Me.tlManualQueueCounter.Text = "M_Queue Counter = 0"
        '
        'tlPLCQueueCounter
        '
        Me.tlPLCQueueCounter.Name = "tlPLCQueueCounter"
        Me.tlPLCQueueCounter.Size = New System.Drawing.Size(137, 18)
        Me.tlPLCQueueCounter.Text = "PLC Queue Counter = 0"
        Me.tlPLCQueueCounter.Visible = False
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 18)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'tlPLCQueue
        '
        Me.tlPLCQueue.AutoSize = False
        Me.tlPLCQueue.Name = "tlPLCQueue"
        Me.tlPLCQueue.Size = New System.Drawing.Size(250, 18)
        Me.tlPLCQueue.Text = "PLC Message"
        Me.tlPLCQueue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlInnerTemp
        '
        Me.tlInnerTemp.AutoSize = False
        Me.tlInnerTemp.Name = "tlInnerTemp"
        Me.tlInnerTemp.Size = New System.Drawing.Size(20, 18)
        Me.tlInnerTemp.Text = "Inner Temp"
        '
        'tlInnerHumi
        '
        Me.tlInnerHumi.AutoSize = False
        Me.tlInnerHumi.Name = "tlInnerHumi"
        Me.tlInnerHumi.Size = New System.Drawing.Size(20, 18)
        Me.tlInnerHumi.Text = "Inner Humi"
        '
        'tlBCRInfo
        '
        Me.tlBCRInfo.AutoSize = False
        Me.tlBCRInfo.Name = "tlBCRInfo"
        Me.tlBCRInfo.Size = New System.Drawing.Size(120, 18)
        Me.tlBCRInfo.Text = "BCR Info."
        Me.tlBCRInfo.Visible = False
        '
        'tlAlarm
        '
        Me.tlAlarm.AutoSize = False
        Me.tlAlarm.Name = "tlAlarm"
        Me.tlAlarm.Size = New System.Drawing.Size(150, 18)
        Me.tlAlarm.Text = "Alarm"
        '
        'tslRemainTime
        '
        Me.tslRemainTime.Name = "tslRemainTime"
        Me.tslRemainTime.Size = New System.Drawing.Size(77, 18)
        Me.tslRemainTime.Text = "Remain Time"
        Me.tslRemainTime.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(20, 23)
        Me.ToolStripSeparator1.Visible = False
        '
        'MainToolStrip
        '
        Me.MainToolStrip.AutoSize = False
        Me.MainToolStrip.BackColor = System.Drawing.Color.White
        Me.MainToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainToolStrip.GripMargin = New System.Windows.Forms.Padding(3)
        Me.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.tsBtnAllCheckClear, Me.tsbSWConnection, Me.tsBtnConnection, Me.tsBtnDisconnection, Me.tsBtnTestRUN, Me.tsBtnTestSTOP, Me.tsBtnTestPAUSE, Me.tsbControlViewMode, Me.tsbSelUI_Monitoring, Me.tsbSelUI_Motion, Me.tsSequenceBulider, Me.ToolStripSeparator6, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.tsBtnTestRed, Me.tsBtnTestGreen, Me.tsBtnTestBlue, Me.tsBtnTestBlack, Me.ToolStripButton1, Me.tsBtnExit, Me.tsbPretestViewMode, Me.ToolStripSeparator7, Me.tsIVLDisplayShow, Me.ToolStripSeparator4, Me.tsBtnCare, Me.tsBtnAlarm, Me.ToolStripSeparator5, Me.tsbIVLGraph, Me.ToolStripSeparator2, Me.ToolStripSeparator8, Me.ToolStripSeparator9})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.MainToolStrip.Size = New System.Drawing.Size(1251, 66)
        Me.MainToolStrip.TabIndex = 1
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AutoSize = False
        Me.ToolStripDropDownButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogInToolStripMenuItem, Me.FileToolStripMenuItem, Me.SystemToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.TestToolStripMenuItem, Me.ControlToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem, Me.FunctionTestToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripDropDownButton1.Image = Global.M7000.My.Resources.Resources._01Menu
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(60, 59)
        Me.ToolStripDropDownButton1.Text = "Menu"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LogInToolStripMenuItem
        '
        Me.LogInToolStripMenuItem.Name = "LogInToolStripMenuItem"
        Me.LogInToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LogInToolStripMenuItem.Text = "Log-In"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FileToolStripMenuItem.Text = "File"
        Me.FileToolStripMenuItem.Visible = False
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HWConnectionToolStripMenu, Me.SWConnectionToolStripMenu, Me.DisconnectionToolStripMenuItem, Me.ToolStripMenuItem2, Me.SystemConfigurationToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.ChannelAllocationToolStripMenuItem, Me.RangeSettingsToolStripMenuItem})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'HWConnectionToolStripMenu
        '
        Me.HWConnectionToolStripMenu.Name = "HWConnectionToolStripMenu"
        Me.HWConnectionToolStripMenu.Size = New System.Drawing.Size(192, 22)
        Me.HWConnectionToolStripMenu.Text = "HW Connection"
        Me.HWConnectionToolStripMenu.Visible = False
        '
        'SWConnectionToolStripMenu
        '
        Me.SWConnectionToolStripMenu.Name = "SWConnectionToolStripMenu"
        Me.SWConnectionToolStripMenu.Size = New System.Drawing.Size(192, 22)
        Me.SWConnectionToolStripMenu.Text = "SW Connection"
        Me.SWConnectionToolStripMenu.Visible = False
        '
        'DisconnectionToolStripMenuItem
        '
        Me.DisconnectionToolStripMenuItem.Name = "DisconnectionToolStripMenuItem"
        Me.DisconnectionToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DisconnectionToolStripMenuItem.Text = "Disconnection"
        Me.DisconnectionToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(189, 6)
        Me.ToolStripMenuItem2.Visible = False
        '
        'SystemConfigurationToolStripMenuItem
        '
        Me.SystemConfigurationToolStripMenuItem.Name = "SystemConfigurationToolStripMenuItem"
        Me.SystemConfigurationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SystemConfigurationToolStripMenuItem.Text = "System Configuration"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ConfigurationToolStripMenuItem.Text = "Device Configuration"
        '
        'ChannelAllocationToolStripMenuItem
        '
        Me.ChannelAllocationToolStripMenuItem.Name = "ChannelAllocationToolStripMenuItem"
        Me.ChannelAllocationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ChannelAllocationToolStripMenuItem.Text = "Channel Allocation"
        '
        'RangeSettingsToolStripMenuItem
        '
        Me.RangeSettingsToolStripMenuItem.Name = "RangeSettingsToolStripMenuItem"
        Me.RangeSettingsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RangeSettingsToolStripMenuItem.Text = "Range Settings"
        Me.RangeSettingsToolStripMenuItem.Visible = False
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.PGImageManagerToolStripMenuItem, Me.ToolStripMenuItem5, Me.ZeroCalToolStripMenuItem, Me.SAFETYModeToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'PGImageManagerToolStripMenuItem
        '
        Me.PGImageManagerToolStripMenuItem.Name = "PGImageManagerToolStripMenuItem"
        Me.PGImageManagerToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.PGImageManagerToolStripMenuItem.Text = "PG Image Manager"
        Me.PGImageManagerToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(196, 6)
        Me.ToolStripMenuItem5.Visible = False
        '
        'ZeroCalToolStripMenuItem
        '
        Me.ZeroCalToolStripMenuItem.Name = "ZeroCalToolStripMenuItem"
        Me.ZeroCalToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ZeroCalToolStripMenuItem.Text = "Zero-Cal"
        Me.ZeroCalToolStripMenuItem.Visible = False
        '
        'SAFETYModeToolStripMenuItem
        '
        Me.SAFETYModeToolStripMenuItem.Name = "SAFETYModeToolStripMenuItem"
        Me.SAFETYModeToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SAFETYModeToolStripMenuItem.Text = "Log-In(SAFETY MODE)"
        Me.SAFETYModeToolStripMenuItem.Visible = False
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripMenuItem, Me.StopToolStripMenuItem, Me.ToolStripMenuItem3, Me.SequenceBuilderToolStripMenuItem})
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestToolStripMenuItem.Text = "Experiment"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(169, 6)
        '
        'SequenceBuilderToolStripMenuItem
        '
        Me.SequenceBuilderToolStripMenuItem.Name = "SequenceBuilderToolStripMenuItem"
        Me.SequenceBuilderToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SequenceBuilderToolStripMenuItem.Text = "Sequence Builder"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MotionToolStripMenuItem, Me.PDMeasurementUnitToolStripMenuItem, Me.PLCToolStripMenuItem, Me.MC9ToolStripMenuItem, Me.NX1ToolStripMenuItem, Me.THC98585ToolStripMenuItem, Me.M6000ToolStripMenuItem, Me.SignalGeneratorToolStripMenuItem, Me.PatternGeneratorToolStripMenuItem, Me.K26XXToolStripMenuItem, Me.K24XXToolStripMenuItem, Me.K23XToolStripMenuItem, Me.PR705ToolStripMenuItem, Me.K7001ToolStripMenuItem, Me.SW7000ToolStripMenuItem, Me.ColorAnalyzerToolStripMenuItem, Me.TTM004ToolStripMenuItem, Me.SpectrometerToolStripMenuItem, Me.SVSCameraToolStripMenuItem, Me.StrobeToolStripMenuItem, Me.EIPPGToolStripMenuItem, Me.IVLPowerSupplyToolStripMenuItem, Me.SW7700ToolStripMenuItem})
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ControlToolStripMenuItem.Text = "Control"
        '
        'MotionToolStripMenuItem
        '
        Me.MotionToolStripMenuItem.Name = "MotionToolStripMenuItem"
        Me.MotionToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.MotionToolStripMenuItem.Text = "PLC Motion"
        '
        'PDMeasurementUnitToolStripMenuItem
        '
        Me.PDMeasurementUnitToolStripMenuItem.Name = "PDMeasurementUnitToolStripMenuItem"
        Me.PDMeasurementUnitToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.PDMeasurementUnitToolStripMenuItem.Text = "PD Measurement Unit"
        Me.PDMeasurementUnitToolStripMenuItem.Visible = False
        '
        'PLCToolStripMenuItem
        '
        Me.PLCToolStripMenuItem.Name = "PLCToolStripMenuItem"
        Me.PLCToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.PLCToolStripMenuItem.Text = "PLC"
        '
        'MC9ToolStripMenuItem
        '
        Me.MC9ToolStripMenuItem.Name = "MC9ToolStripMenuItem"
        Me.MC9ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.MC9ToolStripMenuItem.Text = "MC9"
        Me.MC9ToolStripMenuItem.Visible = False
        '
        'NX1ToolStripMenuItem
        '
        Me.NX1ToolStripMenuItem.Name = "NX1ToolStripMenuItem"
        Me.NX1ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.NX1ToolStripMenuItem.Text = "NX1"
        Me.NX1ToolStripMenuItem.Visible = False
        '
        'THC98585ToolStripMenuItem
        '
        Me.THC98585ToolStripMenuItem.Name = "THC98585ToolStripMenuItem"
        Me.THC98585ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.THC98585ToolStripMenuItem.Text = "THC98585"
        Me.THC98585ToolStripMenuItem.Visible = False
        '
        'M6000ToolStripMenuItem
        '
        Me.M6000ToolStripMenuItem.Name = "M6000ToolStripMenuItem"
        Me.M6000ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.M6000ToolStripMenuItem.Text = "M6000"
        '
        'SignalGeneratorToolStripMenuItem
        '
        Me.SignalGeneratorToolStripMenuItem.Name = "SignalGeneratorToolStripMenuItem"
        Me.SignalGeneratorToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SignalGeneratorToolStripMenuItem.Text = "Signal Generator"
        Me.SignalGeneratorToolStripMenuItem.Visible = False
        '
        'PatternGeneratorToolStripMenuItem
        '
        Me.PatternGeneratorToolStripMenuItem.Name = "PatternGeneratorToolStripMenuItem"
        Me.PatternGeneratorToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.PatternGeneratorToolStripMenuItem.Text = "Pattern Generator"
        Me.PatternGeneratorToolStripMenuItem.Visible = False
        '
        'K26XXToolStripMenuItem
        '
        Me.K26XXToolStripMenuItem.Name = "K26XXToolStripMenuItem"
        Me.K26XXToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.K26XXToolStripMenuItem.Text = "K26XX"
        Me.K26XXToolStripMenuItem.Visible = False
        '
        'K24XXToolStripMenuItem
        '
        Me.K24XXToolStripMenuItem.Name = "K24XXToolStripMenuItem"
        Me.K24XXToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.K24XXToolStripMenuItem.Text = "K24XX"
        Me.K24XXToolStripMenuItem.Visible = False
        '
        'K23XToolStripMenuItem
        '
        Me.K23XToolStripMenuItem.Name = "K23XToolStripMenuItem"
        Me.K23XToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.K23XToolStripMenuItem.Text = "K23X"
        Me.K23XToolStripMenuItem.Visible = False
        '
        'PR705ToolStripMenuItem
        '
        Me.PR705ToolStripMenuItem.Name = "PR705ToolStripMenuItem"
        Me.PR705ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.PR705ToolStripMenuItem.Text = "PR705"
        Me.PR705ToolStripMenuItem.Visible = False
        '
        'K7001ToolStripMenuItem
        '
        Me.K7001ToolStripMenuItem.Name = "K7001ToolStripMenuItem"
        Me.K7001ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.K7001ToolStripMenuItem.Text = "K7001"
        Me.K7001ToolStripMenuItem.Visible = False
        '
        'SW7000ToolStripMenuItem
        '
        Me.SW7000ToolStripMenuItem.Name = "SW7000ToolStripMenuItem"
        Me.SW7000ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SW7000ToolStripMenuItem.Text = "SW7000"
        Me.SW7000ToolStripMenuItem.Visible = False
        '
        'ColorAnalyzerToolStripMenuItem
        '
        Me.ColorAnalyzerToolStripMenuItem.Name = "ColorAnalyzerToolStripMenuItem"
        Me.ColorAnalyzerToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ColorAnalyzerToolStripMenuItem.Text = "Color Analyzer"
        Me.ColorAnalyzerToolStripMenuItem.Visible = False
        '
        'TTM004ToolStripMenuItem
        '
        Me.TTM004ToolStripMenuItem.Name = "TTM004ToolStripMenuItem"
        Me.TTM004ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.TTM004ToolStripMenuItem.Text = "TTM-004"
        '
        'SpectrometerToolStripMenuItem
        '
        Me.SpectrometerToolStripMenuItem.Name = "SpectrometerToolStripMenuItem"
        Me.SpectrometerToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SpectrometerToolStripMenuItem.Text = "Spectrometer"
        '
        'SVSCameraToolStripMenuItem
        '
        Me.SVSCameraToolStripMenuItem.Name = "SVSCameraToolStripMenuItem"
        Me.SVSCameraToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SVSCameraToolStripMenuItem.Text = "SVS Camera"
        '
        'StrobeToolStripMenuItem
        '
        Me.StrobeToolStripMenuItem.Name = "StrobeToolStripMenuItem"
        Me.StrobeToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.StrobeToolStripMenuItem.Text = "Strobe"
        Me.StrobeToolStripMenuItem.Visible = False
        '
        'EIPPGToolStripMenuItem
        '
        Me.EIPPGToolStripMenuItem.Name = "EIPPGToolStripMenuItem"
        Me.EIPPGToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.EIPPGToolStripMenuItem.Text = "EIP Pattern Generator"
        '
        'IVLPowerSupplyToolStripMenuItem
        '
        Me.IVLPowerSupplyToolStripMenuItem.Name = "IVLPowerSupplyToolStripMenuItem"
        Me.IVLPowerSupplyToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.IVLPowerSupplyToolStripMenuItem.Text = "IVL Power Supply"
        '
        'SW7700ToolStripMenuItem
        '
        Me.SW7700ToolStripMenuItem.Name = "SW7700ToolStripMenuItem"
        Me.SW7700ToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SW7700ToolStripMenuItem.Text = "SW7700"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        Me.ViewToolStripMenuItem.Visible = False
        '
        'LogToolStripMenuItem
        '
        Me.LogToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.HideToolStripMenuItem})
        Me.LogToolStripMenuItem.Name = "LogToolStripMenuItem"
        Me.LogToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.LogToolStripMenuItem.Text = "Log"
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FunctionTestToolStripMenuItem
        '
        Me.FunctionTestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestUIToolStripMenuItem2, Me.PGTestUIToolStripMenuItem, Me.UITestToolStripMenuItem, Me.ToolStripMenuItem4, Me.ProcessThreadRUNToolStripMenuItem, Me.ProcessThreadStopToolStripMenuItem})
        Me.FunctionTestToolStripMenuItem.Name = "FunctionTestToolStripMenuItem"
        Me.FunctionTestToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FunctionTestToolStripMenuItem.Text = "Function Test"
        Me.FunctionTestToolStripMenuItem.Visible = False
        '
        'TestUIToolStripMenuItem2
        '
        Me.TestUIToolStripMenuItem2.Name = "TestUIToolStripMenuItem2"
        Me.TestUIToolStripMenuItem2.Size = New System.Drawing.Size(192, 22)
        Me.TestUIToolStripMenuItem2.Text = "SG Test UI"
        '
        'PGTestUIToolStripMenuItem
        '
        Me.PGTestUIToolStripMenuItem.Name = "PGTestUIToolStripMenuItem"
        Me.PGTestUIToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PGTestUIToolStripMenuItem.Text = "PG Test UI"
        '
        'UITestToolStripMenuItem
        '
        Me.UITestToolStripMenuItem.Name = "UITestToolStripMenuItem"
        Me.UITestToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.UITestToolStripMenuItem.Text = "UI Test"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(189, 6)
        '
        'ProcessThreadRUNToolStripMenuItem
        '
        Me.ProcessThreadRUNToolStripMenuItem.Name = "ProcessThreadRUNToolStripMenuItem"
        Me.ProcessThreadRUNToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ProcessThreadRUNToolStripMenuItem.Text = "Process Thread RUN"
        '
        'ProcessThreadStopToolStripMenuItem
        '
        Me.ProcessThreadStopToolStripMenuItem.Name = "ProcessThreadStopToolStripMenuItem"
        Me.ProcessThreadStopToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ProcessThreadStopToolStripMenuItem.Text = "Process Thread Stop"
        '
        'tsBtnAllCheckClear
        '
        Me.tsBtnAllCheckClear.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.tsBtnAllCheckClear.Image = Global.M7000.My.Resources.Resources._02Select_All
        Me.tsBtnAllCheckClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnAllCheckClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnAllCheckClear.Name = "tsBtnAllCheckClear"
        Me.tsBtnAllCheckClear.Size = New System.Drawing.Size(97, 63)
        Me.tsBtnAllCheckClear.Text = "Select/Unselect"
        Me.tsBtnAllCheckClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnAllCheckClear.Visible = False
        '
        'tsbSWConnection
        '
        Me.tsbSWConnection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSWConnection.Image = Global.M7000.My.Resources.Resources._3_pc
        Me.tsbSWConnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSWConnection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSWConnection.Name = "tsbSWConnection"
        Me.tsbSWConnection.Size = New System.Drawing.Size(96, 63)
        Me.tsbSWConnection.Text = "SW Connection"
        Me.tsbSWConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSWConnection.Visible = False
        '
        'tsBtnConnection
        '
        Me.tsBtnConnection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnConnection.Image = Global.M7000.My.Resources.Resources._03Connection
        Me.tsBtnConnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnConnection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnConnection.Name = "tsBtnConnection"
        Me.tsBtnConnection.Size = New System.Drawing.Size(74, 63)
        Me.tsBtnConnection.Text = "Connection"
        Me.tsBtnConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnDisconnection
        '
        Me.tsBtnDisconnection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnDisconnection.Image = Global.M7000.My.Resources.Resources._4_disconnection
        Me.tsBtnDisconnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnDisconnection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnDisconnection.Name = "tsBtnDisconnection"
        Me.tsBtnDisconnection.Size = New System.Drawing.Size(90, 63)
        Me.tsBtnDisconnection.Text = "Disconnection"
        Me.tsBtnDisconnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnDisconnection.Visible = False
        '
        'tsBtnTestRUN
        '
        Me.tsBtnTestRUN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnTestRUN.Image = Global.M7000.My.Resources.Resources._04Start
        Me.tsBtnTestRUN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestRUN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestRUN.Name = "tsBtnTestRUN"
        Me.tsBtnTestRUN.Size = New System.Drawing.Size(54, 63)
        Me.tsBtnTestRUN.Text = "Run"
        Me.tsBtnTestRUN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnTestSTOP
        '
        Me.tsBtnTestSTOP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnTestSTOP.Image = Global.M7000.My.Resources.Resources._05Stop
        Me.tsBtnTestSTOP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestSTOP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestSTOP.Name = "tsBtnTestSTOP"
        Me.tsBtnTestSTOP.Size = New System.Drawing.Size(54, 63)
        Me.tsBtnTestSTOP.Text = "Stop"
        Me.tsBtnTestSTOP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnTestPAUSE
        '
        Me.tsBtnTestPAUSE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnTestPAUSE.Image = Global.M7000.My.Resources.Resources._06Pause
        Me.tsBtnTestPAUSE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestPAUSE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestPAUSE.Name = "tsBtnTestPAUSE"
        Me.tsBtnTestPAUSE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsBtnTestPAUSE.Size = New System.Drawing.Size(54, 63)
        Me.tsBtnTestPAUSE.Text = "Pause"
        Me.tsBtnTestPAUSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbControlViewMode
        '
        Me.tsbControlViewMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbControlViewMode.Image = Global.M7000.My.Resources.Resources._07Main
        Me.tsbControlViewMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbControlViewMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbControlViewMode.Name = "tsbControlViewMode"
        Me.tsbControlViewMode.Size = New System.Drawing.Size(54, 63)
        Me.tsbControlViewMode.Text = "Main UI"
        Me.tsbControlViewMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbSelUI_Monitoring
        '
        Me.tsbSelUI_Monitoring.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSelUI_Monitoring.Image = Global.M7000.My.Resources.Resources._08Monitoring
        Me.tsbSelUI_Monitoring.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSelUI_Monitoring.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSelUI_Monitoring.Name = "tsbSelUI_Monitoring"
        Me.tsbSelUI_Monitoring.Size = New System.Drawing.Size(68, 63)
        Me.tsbSelUI_Monitoring.Text = "Monitoring"
        Me.tsbSelUI_Monitoring.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbSelUI_Motion
        '
        Me.tsbSelUI_Motion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSelUI_Motion.Image = Global.M7000.My.Resources.Resources._09Motion
        Me.tsbSelUI_Motion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSelUI_Motion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSelUI_Motion.Name = "tsbSelUI_Motion"
        Me.tsbSelUI_Motion.Size = New System.Drawing.Size(54, 63)
        Me.tsbSelUI_Motion.Text = "Motion"
        Me.tsbSelUI_Motion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsSequenceBulider
        '
        Me.tsSequenceBulider.BackColor = System.Drawing.Color.White
        Me.tsSequenceBulider.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsSequenceBulider.Image = Global.M7000.My.Resources.Resources.Sequence_Builder
        Me.tsSequenceBulider.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsSequenceBulider.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSequenceBulider.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tsSequenceBulider.Name = "tsSequenceBulider"
        Me.tsSequenceBulider.Size = New System.Drawing.Size(54, 64)
        Me.tsSequenceBulider.Text = "Builder"
        Me.tsSequenceBulider.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsSequenceBulider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 66)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.M7000.My.Resources.Resources.clear_2
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(73, 63)
        Me.ToolStripButton2.Text = "QueueClear"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 66)
        '
        'tsBtnTestRed
        '
        Me.tsBtnTestRed.Image = Global.M7000.My.Resources.Resources.Red1
        Me.tsBtnTestRed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestRed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestRed.Name = "tsBtnTestRed"
        Me.tsBtnTestRed.Size = New System.Drawing.Size(63, 63)
        Me.tsBtnTestRed.Text = "Red Meas"
        Me.tsBtnTestRed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnTestGreen
        '
        Me.tsBtnTestGreen.Image = Global.M7000.My.Resources.Resources.Green1
        Me.tsBtnTestGreen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestGreen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestGreen.Name = "tsBtnTestGreen"
        Me.tsBtnTestGreen.Size = New System.Drawing.Size(74, 63)
        Me.tsBtnTestGreen.Text = "Green Meas"
        Me.tsBtnTestGreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnTestBlue
        '
        Me.tsBtnTestBlue.Image = Global.M7000.My.Resources.Resources.Blue1
        Me.tsBtnTestBlue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestBlue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestBlue.Name = "tsBtnTestBlue"
        Me.tsBtnTestBlue.Size = New System.Drawing.Size(66, 63)
        Me.tsBtnTestBlue.Text = "Blue Meas"
        Me.tsBtnTestBlue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnTestBlack
        '
        Me.tsBtnTestBlack.Image = Global.M7000.My.Resources.Resources.Black1
        Me.tsBtnTestBlack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnTestBlack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnTestBlack.Name = "tsBtnTestBlack"
        Me.tsBtnTestBlack.Size = New System.Drawing.Size(71, 63)
        Me.tsBtnTestBlack.Text = "Black Meas"
        Me.tsBtnTestBlack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = Global.M7000.My.Resources.Resources._05Stop
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(79, 69)
        Me.ToolStripButton1.Text = "Manual Stop"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsBtnExit
        '
        Me.tsBtnExit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnExit.Image = Global.M7000.My.Resources.Resources._10Exit
        Me.tsBtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnExit.Name = "tsBtnExit"
        Me.tsBtnExit.Size = New System.Drawing.Size(54, 69)
        Me.tsBtnExit.Text = "Exit"
        Me.tsBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbPretestViewMode
        '
        Me.tsbPretestViewMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbPretestViewMode.Image = Global.M7000.My.Resources.Resources.pretest
        Me.tsbPretestViewMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPretestViewMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPretestViewMode.Name = "tsbPretestViewMode"
        Me.tsbPretestViewMode.Size = New System.Drawing.Size(50, 51)
        Me.tsbPretestViewMode.Text = "Pretest"
        Me.tsbPretestViewMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbPretestViewMode.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(20, 57)
        Me.ToolStripSeparator7.Visible = False
        '
        'tsIVLDisplayShow
        '
        Me.tsIVLDisplayShow.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsIVLDisplayShow.Image = Global.M7000.My.Resources.Resources.update
        Me.tsIVLDisplayShow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsIVLDisplayShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsIVLDisplayShow.Name = "tsIVLDisplayShow"
        Me.tsIVLDisplayShow.Size = New System.Drawing.Size(72, 51)
        Me.tsIVLDisplayShow.Text = "IVL Display"
        Me.tsIVLDisplayShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsIVLDisplayShow.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(20, 57)
        Me.ToolStripSeparator4.Visible = False
        '
        'tsBtnCare
        '
        Me.tsBtnCare.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnCare.Image = Global.M7000.My.Resources.Resources._9_cafe
        Me.tsBtnCare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnCare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnCare.Name = "tsBtnCare"
        Me.tsBtnCare.Size = New System.Drawing.Size(38, 51)
        Me.tsBtnCare.Text = "Care"
        Me.tsBtnCare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnCare.Visible = False
        '
        'tsBtnAlarm
        '
        Me.tsBtnAlarm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnAlarm.Image = Global.M7000.My.Resources.Resources._10_overvolt
        Me.tsBtnAlarm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnAlarm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnAlarm.Name = "tsBtnAlarm"
        Me.tsBtnAlarm.Size = New System.Drawing.Size(43, 51)
        Me.tsBtnAlarm.Text = "Alarm"
        Me.tsBtnAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnAlarm.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 66)
        Me.ToolStripSeparator5.Visible = False
        '
        'tsbIVLGraph
        '
        Me.tsbIVLGraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbIVLGraph.Image = Global.M7000.My.Resources.Resources._7_graph_view_IVL
        Me.tsbIVLGraph.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbIVLGraph.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIVLGraph.Name = "tsbIVLGraph"
        Me.tsbIVLGraph.Size = New System.Drawing.Size(65, 51)
        Me.tsbIVLGraph.Text = "IVL Graph"
        Me.tsbIVLGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbIVLGraph.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(20, 57)
        Me.ToolStripSeparator2.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 66)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 66)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1302, 66)
        Me.Panel2.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.MainToolStrip)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Size = New System.Drawing.Size(1302, 66)
        Me.SplitContainer1.SplitterDistance = 1251
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1302, 643)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.mainStatus)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "M7000"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mainStatus.ResumeLayout(False)
        Me.mainStatus.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents MainToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HWConnectionToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChannelAllocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SequenceBuilderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunctionTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlQueueCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsBtnDisconnection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnTestRUN As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnTestSTOP As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnTestPAUSE As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPretestViewMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelUI_Motion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SystemConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MotionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SWConnectionToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDMeasurementUnitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PLCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MC9ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NX1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents THC98585ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M6000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SignalGeneratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternGeneratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestUIToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessThreadRUNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessThreadStopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PGTestUIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UITestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents K26XXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents K24XXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents K23XToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBtnCare As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnAlarm As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlAlarm As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlPLCQueue As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PR705ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents K7001ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SW7000ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbControlViewMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsIVLDisplayShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnConnection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSWConnection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelUI_Monitoring As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbIVLGraph As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSequenceBulider As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColorAnalyzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PGImageManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlInnerTemp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlInnerHumi As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZeroCalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tslRemainTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LogInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TTM004ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpectrometerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAFETYModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBtnAllCheckClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents SVSCameraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlPLCQueueCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tlBCRInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StrobeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RangeSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsBtnTestRed As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnTestGreen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnTestBlue As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsBtnTestBlack As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlManualQueueCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EIPPGToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IVLPowerSupplyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SW7700ToolStripMenuItem As ToolStripMenuItem
End Class
