<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingWind
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
        Me.components = New System.ComponentModel.Container()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCalcle = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbSettingsChAlloc = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkViewingAngleUse = New System.Windows.Forms.CheckBox()
        Me.chkIVLSweepUse = New System.Windows.Forms.CheckBox()
        Me.chkLifetimeUse = New System.Windows.Forms.CheckBox()
        Me.gbSMUForIVL = New System.Windows.Forms.GroupBox()
        Me.chkEnableSMU_IVL = New System.Windows.Forms.CheckBox()
        Me.cbSelSMUforIVLCh = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cbSelSMUForIVLDevice = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.gbSW7000 = New System.Windows.Forms.GroupBox()
        Me.cbSelSW7000Ch = New System.Windows.Forms.ComboBox()
        Me.chkEnableSW7000 = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbSelSW7000Device = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.gbSwitch = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbSelSwitchCh = New System.Windows.Forms.ComboBox()
        Me.cbSelSwitchDevice = New System.Windows.Forms.ComboBox()
        Me.chkEnableK7001 = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.gbPGGroup = New System.Windows.Forms.GroupBox()
        Me.chkEnablePG = New System.Windows.Forms.CheckBox()
        Me.gbPGCtrlBD = New System.Windows.Forms.GroupBox()
        Me.cbSelPGCtrlDevice = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbSelPGCtrlCh = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbSelPGCtrlGroup = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gbPGPower = New System.Windows.Forms.GroupBox()
        Me.cbSelPGPwrDevice = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbSelPGPwrCh = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbSelPGPwrGroup = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbPG = New System.Windows.Forms.GroupBox()
        Me.cbSelPGCh = New System.Windows.Forms.ComboBox()
        Me.lblPGCh = New System.Windows.Forms.Label()
        Me.cbSelPGDevice = New System.Windows.Forms.ComboBox()
        Me.lblPGDev = New System.Windows.Forms.Label()
        Me.gbPDUnit = New System.Windows.Forms.GroupBox()
        Me.cbSelPDUnitCh = New System.Windows.Forms.ComboBox()
        Me.chkEnablePDUnit = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbSelPDUnitDevice = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbSelSampleType = New System.Windows.Forms.ComboBox()
        Me.cbSelPallet = New System.Windows.Forms.ComboBox()
        Me.lblSampleType = New System.Windows.Forms.Label()
        Me.cbSelJIG = New System.Windows.Forms.ComboBox()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblJIG = New System.Windows.Forms.Label()
        Me.gbSG = New System.Windows.Forms.GroupBox()
        Me.chkEnableSG = New System.Windows.Forms.CheckBox()
        Me.cbSelSGDevice = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbSelSGCh = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbSelSGGroup = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbTC = New System.Windows.Forms.GroupBox()
        Me.chkEnableTC = New System.Windows.Forms.CheckBox()
        Me.cbSelTCDevice = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSelTCChannel = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelTCGroup = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbM6000 = New System.Windows.Forms.GroupBox()
        Me.cbSelM6000Ch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkEnableM6000 = New System.Windows.Forms.CheckBox()
        Me.cbSelM6000Device = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.gbListChAlloc = New System.Windows.Forms.GroupBox()
        Me.ucListChAllocation = New M7000.ucDispListView()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.tcSettings = New System.Windows.Forms.TabControl()
        Me.tpChAllocation = New System.Windows.Forms.TabPage()
        Me.tpJIGLayout = New System.Windows.Forms.TabPage()
        Me.btnEditJIGLocation_tpJIGLayout = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ucListJIGSettings = New M7000.ucDispListView()
        Me.btnDEL_tpJIGLayout = New System.Windows.Forms.Button()
        Me.btnClear_tpJIGLayout = New System.Windows.Forms.Button()
        Me.btnADD_tpJIGLayout = New System.Windows.Forms.Button()
        Me.btnChange_tpJIGLayout = New System.Windows.Forms.Button()
        Me.gbSettingsJIGLayout = New System.Windows.Forms.GroupBox()
        Me.tbAddText_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout = New System.Windows.Forms.CheckBox()
        Me.lblJIGBackColor_tpJIGLayout = New System.Windows.Forms.Label()
        Me.lblJIGLayout_StatusMsgFont = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbNumOfSample_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.gbSettingsProperty02_JIGLayout = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbCellLayoutRow_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.tbCellLayoutCol_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.ucJIG = New M7000.ucDispJIG()
        Me.gbSettingProperty01_JIGLayout = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbJIGSizeWidth_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbJIGSizeHeight_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.tbJIGOutlineWidth_tpJIGLayout = New System.Windows.Forms.TextBox()
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout = New System.Windows.Forms.Label()
        Me.lblJIGOutlineColorAtSel_tpJIGLayout = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbSelSampleType_tpJIGLayout = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbSelJIG_tpJIGLayout = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tpDisplay = New System.Windows.Forms.TabPage()
        Me.cbDisplayMainUI = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.cbSelSwitchPairCh = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.gbSettingsChAlloc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSMUForIVL.SuspendLayout()
        Me.gbSW7000.SuspendLayout()
        Me.gbSwitch.SuspendLayout()
        Me.gbPGGroup.SuspendLayout()
        Me.gbPGCtrlBD.SuspendLayout()
        Me.gbPGPower.SuspendLayout()
        Me.gbPG.SuspendLayout()
        Me.gbPDUnit.SuspendLayout()
        Me.gbSG.SuspendLayout()
        Me.gbTC.SuspendLayout()
        Me.gbM6000.SuspendLayout()
        Me.gbListChAlloc.SuspendLayout()
        Me.tcSettings.SuspendLayout()
        Me.tpChAllocation.SuspendLayout()
        Me.tpJIGLayout.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbSettingsJIGLayout.SuspendLayout()
        Me.gbSettingsProperty02_JIGLayout.SuspendLayout()
        Me.gbSettingProperty01_JIGLayout.SuspendLayout()
        Me.tpDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(682, 687)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(83, 37)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        Me.btnLoad.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(595, 687)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 37)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(774, 687)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(83, 37)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCalcle
        '
        Me.btnCalcle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCalcle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcle.Location = New System.Drawing.Point(861, 687)
        Me.btnCalcle.Name = "btnCalcle"
        Me.btnCalcle.Size = New System.Drawing.Size(84, 37)
        Me.btnCalcle.TabIndex = 1
        Me.btnCalcle.Text = "Cancel"
        Me.btnCalcle.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Device :"
        '
        'gbSettingsChAlloc
        '
        Me.gbSettingsChAlloc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSettingsChAlloc.Controls.Add(Me.GroupBox1)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbSMUForIVL)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbSW7000)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbSwitch)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbPGGroup)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbPDUnit)
        Me.gbSettingsChAlloc.Controls.Add(Me.cbSelSampleType)
        Me.gbSettingsChAlloc.Controls.Add(Me.cbSelPallet)
        Me.gbSettingsChAlloc.Controls.Add(Me.lblSampleType)
        Me.gbSettingsChAlloc.Controls.Add(Me.cbSelJIG)
        Me.gbSettingsChAlloc.Controls.Add(Me.lblPallet)
        Me.gbSettingsChAlloc.Controls.Add(Me.lblJIG)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbSG)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbTC)
        Me.gbSettingsChAlloc.Controls.Add(Me.gbM6000)
        Me.gbSettingsChAlloc.Location = New System.Drawing.Point(6, 3)
        Me.gbSettingsChAlloc.Name = "gbSettingsChAlloc"
        Me.gbSettingsChAlloc.Size = New System.Drawing.Size(903, 329)
        Me.gbSettingsChAlloc.TabIndex = 5
        Me.gbSettingsChAlloc.TabStop = False
        Me.gbSettingsChAlloc.Text = "Settings"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkViewingAngleUse)
        Me.GroupBox1.Controls.Add(Me.chkIVLSweepUse)
        Me.GroupBox1.Controls.Add(Me.chkLifetimeUse)
        Me.GroupBox1.Location = New System.Drawing.Point(766, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 80)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Experiment"
        '
        'chkViewingAngleUse
        '
        Me.chkViewingAngleUse.AutoSize = True
        Me.chkViewingAngleUse.Location = New System.Drawing.Point(13, 58)
        Me.chkViewingAngleUse.Name = "chkViewingAngleUse"
        Me.chkViewingAngleUse.Size = New System.Drawing.Size(75, 16)
        Me.chkViewingAngleUse.TabIndex = 17
        Me.chkViewingAngleUse.Text = "V/A use."
        Me.chkViewingAngleUse.UseVisualStyleBackColor = True
        '
        'chkIVLSweepUse
        '
        Me.chkIVLSweepUse.AutoSize = True
        Me.chkIVLSweepUse.Location = New System.Drawing.Point(13, 17)
        Me.chkIVLSweepUse.Name = "chkIVLSweepUse"
        Me.chkIVLSweepUse.Size = New System.Drawing.Size(114, 16)
        Me.chkIVLSweepUse.TabIndex = 16
        Me.chkIVLSweepUse.Text = "IVL Sweep use."
        Me.chkIVLSweepUse.UseVisualStyleBackColor = True
        '
        'chkLifetimeUse
        '
        Me.chkLifetimeUse.AutoSize = True
        Me.chkLifetimeUse.Location = New System.Drawing.Point(13, 37)
        Me.chkLifetimeUse.Name = "chkLifetimeUse"
        Me.chkLifetimeUse.Size = New System.Drawing.Size(97, 16)
        Me.chkLifetimeUse.TabIndex = 15
        Me.chkLifetimeUse.Text = "Lifetime use."
        Me.chkLifetimeUse.UseVisualStyleBackColor = True
        '
        'gbSMUForIVL
        '
        Me.gbSMUForIVL.Controls.Add(Me.chkEnableSMU_IVL)
        Me.gbSMUForIVL.Controls.Add(Me.cbSelSMUforIVLCh)
        Me.gbSMUForIVL.Controls.Add(Me.Label35)
        Me.gbSMUForIVL.Controls.Add(Me.cbSelSMUForIVLDevice)
        Me.gbSMUForIVL.Controls.Add(Me.Label36)
        Me.gbSMUForIVL.Location = New System.Drawing.Point(332, 15)
        Me.gbSMUForIVL.Name = "gbSMUForIVL"
        Me.gbSMUForIVL.Size = New System.Drawing.Size(139, 93)
        Me.gbSMUForIVL.TabIndex = 12
        Me.gbSMUForIVL.TabStop = False
        Me.gbSMUForIVL.Text = "IVL SMU"
        '
        'chkEnableSMU_IVL
        '
        Me.chkEnableSMU_IVL.AutoSize = True
        Me.chkEnableSMU_IVL.Location = New System.Drawing.Point(17, 15)
        Me.chkEnableSMU_IVL.Name = "chkEnableSMU_IVL"
        Me.chkEnableSMU_IVL.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableSMU_IVL.TabIndex = 18
        Me.chkEnableSMU_IVL.Text = "Enable"
        Me.chkEnableSMU_IVL.UseVisualStyleBackColor = True
        '
        'cbSelSMUforIVLCh
        '
        Me.cbSelSMUforIVLCh.FormattingEnabled = True
        Me.cbSelSMUforIVLCh.Location = New System.Drawing.Point(82, 61)
        Me.cbSelSMUforIVLCh.Name = "cbSelSMUforIVLCh"
        Me.cbSelSMUforIVLCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSMUforIVLCh.TabIndex = 7
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(16, 65)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(60, 12)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Channel :"
        '
        'cbSelSMUForIVLDevice
        '
        Me.cbSelSMUForIVLDevice.FormattingEnabled = True
        Me.cbSelSMUForIVLDevice.Location = New System.Drawing.Point(82, 37)
        Me.cbSelSMUForIVLDevice.Name = "cbSelSMUForIVLDevice"
        Me.cbSelSMUForIVLDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSMUForIVLDevice.TabIndex = 5
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(24, 41)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(51, 12)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Device :"
        '
        'gbSW7000
        '
        Me.gbSW7000.Controls.Add(Me.cbSelSW7000Ch)
        Me.gbSW7000.Controls.Add(Me.chkEnableSW7000)
        Me.gbSW7000.Controls.Add(Me.Label33)
        Me.gbSW7000.Controls.Add(Me.cbSelSW7000Device)
        Me.gbSW7000.Controls.Add(Me.Label34)
        Me.gbSW7000.Location = New System.Drawing.Point(597, 145)
        Me.gbSW7000.Name = "gbSW7000"
        Me.gbSW7000.Size = New System.Drawing.Size(140, 85)
        Me.gbSW7000.TabIndex = 11
        Me.gbSW7000.TabStop = False
        Me.gbSW7000.Text = "SW7000"
        Me.gbSW7000.Visible = False
        '
        'cbSelSW7000Ch
        '
        Me.cbSelSW7000Ch.FormattingEnabled = True
        Me.cbSelSW7000Ch.Location = New System.Drawing.Point(84, 60)
        Me.cbSelSW7000Ch.Name = "cbSelSW7000Ch"
        Me.cbSelSW7000Ch.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSW7000Ch.TabIndex = 7
        '
        'chkEnableSW7000
        '
        Me.chkEnableSW7000.AutoSize = True
        Me.chkEnableSW7000.Location = New System.Drawing.Point(15, 16)
        Me.chkEnableSW7000.Name = "chkEnableSW7000"
        Me.chkEnableSW7000.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableSW7000.TabIndex = 20
        Me.chkEnableSW7000.Text = "Enable"
        Me.chkEnableSW7000.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(17, 63)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(60, 12)
        Me.Label33.TabIndex = 6
        Me.Label33.Text = "Channel :"
        '
        'cbSelSW7000Device
        '
        Me.cbSelSW7000Device.FormattingEnabled = True
        Me.cbSelSW7000Device.Location = New System.Drawing.Point(84, 36)
        Me.cbSelSW7000Device.Name = "cbSelSW7000Device"
        Me.cbSelSW7000Device.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSW7000Device.TabIndex = 5
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(27, 39)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(51, 12)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Device :"
        '
        'gbSwitch
        '
        Me.gbSwitch.Controls.Add(Me.cbSelSwitchPairCh)
        Me.gbSwitch.Controls.Add(Me.Label37)
        Me.gbSwitch.Controls.Add(Me.Label32)
        Me.gbSwitch.Controls.Add(Me.cbSelSwitchCh)
        Me.gbSwitch.Controls.Add(Me.cbSelSwitchDevice)
        Me.gbSwitch.Controls.Add(Me.chkEnableK7001)
        Me.gbSwitch.Controls.Add(Me.Label31)
        Me.gbSwitch.Location = New System.Drawing.Point(479, 15)
        Me.gbSwitch.Name = "gbSwitch"
        Me.gbSwitch.Size = New System.Drawing.Size(134, 121)
        Me.gbSwitch.TabIndex = 8
        Me.gbSwitch.TabStop = False
        Me.gbSwitch.Text = "Switch"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(13, 40)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(51, 12)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Device :"
        '
        'cbSelSwitchCh
        '
        Me.cbSelSwitchCh.FormattingEnabled = True
        Me.cbSelSwitchCh.Location = New System.Drawing.Point(70, 61)
        Me.cbSelSwitchCh.Name = "cbSelSwitchCh"
        Me.cbSelSwitchCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSwitchCh.TabIndex = 7
        '
        'cbSelSwitchDevice
        '
        Me.cbSelSwitchDevice.FormattingEnabled = True
        Me.cbSelSwitchDevice.Location = New System.Drawing.Point(70, 37)
        Me.cbSelSwitchDevice.Name = "cbSelSwitchDevice"
        Me.cbSelSwitchDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSwitchDevice.TabIndex = 5
        '
        'chkEnableK7001
        '
        Me.chkEnableK7001.AutoSize = True
        Me.chkEnableK7001.Location = New System.Drawing.Point(15, 16)
        Me.chkEnableK7001.Name = "chkEnableK7001"
        Me.chkEnableK7001.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableK7001.TabIndex = 16
        Me.chkEnableK7001.Text = "Enable"
        Me.chkEnableK7001.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 64)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 12)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Channel :"
        '
        'gbPGGroup
        '
        Me.gbPGGroup.Controls.Add(Me.chkEnablePG)
        Me.gbPGGroup.Controls.Add(Me.gbPGCtrlBD)
        Me.gbPGGroup.Controls.Add(Me.gbPGPower)
        Me.gbPGGroup.Controls.Add(Me.gbPG)
        Me.gbPGGroup.Location = New System.Drawing.Point(8, 118)
        Me.gbPGGroup.Name = "gbPGGroup"
        Me.gbPGGroup.Size = New System.Drawing.Size(437, 104)
        Me.gbPGGroup.TabIndex = 10
        Me.gbPGGroup.TabStop = False
        Me.gbPGGroup.Text = "Pattern Generator"
        '
        'chkEnablePG
        '
        Me.chkEnablePG.AutoSize = True
        Me.chkEnablePG.Location = New System.Drawing.Point(19, 15)
        Me.chkEnablePG.Name = "chkEnablePG"
        Me.chkEnablePG.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePG.TabIndex = 14
        Me.chkEnablePG.Text = "Enable"
        Me.chkEnablePG.UseVisualStyleBackColor = True
        '
        'gbPGCtrlBD
        '
        Me.gbPGCtrlBD.Controls.Add(Me.cbSelPGCtrlDevice)
        Me.gbPGCtrlBD.Controls.Add(Me.Label16)
        Me.gbPGCtrlBD.Controls.Add(Me.cbSelPGCtrlCh)
        Me.gbPGCtrlBD.Controls.Add(Me.Label17)
        Me.gbPGCtrlBD.Controls.Add(Me.cbSelPGCtrlGroup)
        Me.gbPGCtrlBD.Controls.Add(Me.Label18)
        Me.gbPGCtrlBD.Location = New System.Drawing.Point(299, 12)
        Me.gbPGCtrlBD.Name = "gbPGCtrlBD"
        Me.gbPGCtrlBD.Size = New System.Drawing.Size(132, 89)
        Me.gbPGCtrlBD.TabIndex = 12
        Me.gbPGCtrlBD.TabStop = False
        Me.gbPGCtrlBD.Text = "PG Control BD"
        '
        'cbSelPGCtrlDevice
        '
        Me.cbSelPGCtrlDevice.FormattingEnabled = True
        Me.cbSelPGCtrlDevice.Location = New System.Drawing.Point(75, 39)
        Me.cbSelPGCtrlDevice.Name = "cbSelPGCtrlDevice"
        Me.cbSelPGCtrlDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGCtrlDevice.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 42)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 12)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Device :"
        '
        'cbSelPGCtrlCh
        '
        Me.cbSelPGCtrlCh.FormattingEnabled = True
        Me.cbSelPGCtrlCh.Location = New System.Drawing.Point(75, 62)
        Me.cbSelPGCtrlCh.Name = "cbSelPGCtrlCh"
        Me.cbSelPGCtrlCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGCtrlCh.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 12)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Channel :"
        '
        'cbSelPGCtrlGroup
        '
        Me.cbSelPGCtrlGroup.FormattingEnabled = True
        Me.cbSelPGCtrlGroup.Location = New System.Drawing.Point(75, 15)
        Me.cbSelPGCtrlGroup.Name = "cbSelPGCtrlGroup"
        Me.cbSelPGCtrlGroup.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGCtrlGroup.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 12)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Group :"
        '
        'gbPGPower
        '
        Me.gbPGPower.Controls.Add(Me.cbSelPGPwrDevice)
        Me.gbPGPower.Controls.Add(Me.Label13)
        Me.gbPGPower.Controls.Add(Me.cbSelPGPwrCh)
        Me.gbPGPower.Controls.Add(Me.Label14)
        Me.gbPGPower.Controls.Add(Me.cbSelPGPwrGroup)
        Me.gbPGPower.Controls.Add(Me.Label15)
        Me.gbPGPower.Location = New System.Drawing.Point(150, 12)
        Me.gbPGPower.Name = "gbPGPower"
        Me.gbPGPower.Size = New System.Drawing.Size(142, 89)
        Me.gbPGPower.TabIndex = 11
        Me.gbPGPower.TabStop = False
        Me.gbPGPower.Text = "PG Power"
        '
        'cbSelPGPwrDevice
        '
        Me.cbSelPGPwrDevice.FormattingEnabled = True
        Me.cbSelPGPwrDevice.Location = New System.Drawing.Point(77, 39)
        Me.cbSelPGPwrDevice.Name = "cbSelPGPwrDevice"
        Me.cbSelPGPwrDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGPwrDevice.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 12)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Device :"
        '
        'cbSelPGPwrCh
        '
        Me.cbSelPGPwrCh.FormattingEnabled = True
        Me.cbSelPGPwrCh.Location = New System.Drawing.Point(77, 62)
        Me.cbSelPGPwrCh.Name = "cbSelPGPwrCh"
        Me.cbSelPGPwrCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGPwrCh.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 12)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Channel :"
        '
        'cbSelPGPwrGroup
        '
        Me.cbSelPGPwrGroup.FormattingEnabled = True
        Me.cbSelPGPwrGroup.Location = New System.Drawing.Point(77, 15)
        Me.cbSelPGPwrGroup.Name = "cbSelPGPwrGroup"
        Me.cbSelPGPwrGroup.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGPwrGroup.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 12)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Group :"
        '
        'gbPG
        '
        Me.gbPG.Controls.Add(Me.cbSelPGCh)
        Me.gbPG.Controls.Add(Me.lblPGCh)
        Me.gbPG.Controls.Add(Me.cbSelPGDevice)
        Me.gbPG.Controls.Add(Me.lblPGDev)
        Me.gbPG.Location = New System.Drawing.Point(6, 33)
        Me.gbPG.Name = "gbPG"
        Me.gbPG.Size = New System.Drawing.Size(139, 66)
        Me.gbPG.TabIndex = 10
        Me.gbPG.TabStop = False
        Me.gbPG.Text = "PG"
        '
        'cbSelPGCh
        '
        Me.cbSelPGCh.FormattingEnabled = True
        Me.cbSelPGCh.Location = New System.Drawing.Point(82, 39)
        Me.cbSelPGCh.Name = "cbSelPGCh"
        Me.cbSelPGCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGCh.TabIndex = 7
        '
        'lblPGCh
        '
        Me.lblPGCh.AutoSize = True
        Me.lblPGCh.Location = New System.Drawing.Point(16, 42)
        Me.lblPGCh.Name = "lblPGCh"
        Me.lblPGCh.Size = New System.Drawing.Size(60, 12)
        Me.lblPGCh.TabIndex = 6
        Me.lblPGCh.Text = "Channel :"
        '
        'cbSelPGDevice
        '
        Me.cbSelPGDevice.FormattingEnabled = True
        Me.cbSelPGDevice.Location = New System.Drawing.Point(82, 15)
        Me.cbSelPGDevice.Name = "cbSelPGDevice"
        Me.cbSelPGDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPGDevice.TabIndex = 5
        '
        'lblPGDev
        '
        Me.lblPGDev.AutoSize = True
        Me.lblPGDev.Location = New System.Drawing.Point(24, 18)
        Me.lblPGDev.Name = "lblPGDev"
        Me.lblPGDev.Size = New System.Drawing.Size(51, 12)
        Me.lblPGDev.TabIndex = 4
        Me.lblPGDev.Text = "Device :"
        '
        'gbPDUnit
        '
        Me.gbPDUnit.Controls.Add(Me.cbSelPDUnitCh)
        Me.gbPDUnit.Controls.Add(Me.chkEnablePDUnit)
        Me.gbPDUnit.Controls.Add(Me.Label6)
        Me.gbPDUnit.Controls.Add(Me.cbSelPDUnitDevice)
        Me.gbPDUnit.Controls.Add(Me.Label10)
        Me.gbPDUnit.Location = New System.Drawing.Point(451, 148)
        Me.gbPDUnit.Name = "gbPDUnit"
        Me.gbPDUnit.Size = New System.Drawing.Size(139, 91)
        Me.gbPDUnit.TabIndex = 9
        Me.gbPDUnit.TabStop = False
        Me.gbPDUnit.Text = "PD Measure Unit"
        '
        'cbSelPDUnitCh
        '
        Me.cbSelPDUnitCh.FormattingEnabled = True
        Me.cbSelPDUnitCh.Location = New System.Drawing.Point(82, 60)
        Me.cbSelPDUnitCh.Name = "cbSelPDUnitCh"
        Me.cbSelPDUnitCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPDUnitCh.TabIndex = 7
        '
        'chkEnablePDUnit
        '
        Me.chkEnablePDUnit.AutoSize = True
        Me.chkEnablePDUnit.Location = New System.Drawing.Point(13, 16)
        Me.chkEnablePDUnit.Name = "chkEnablePDUnit"
        Me.chkEnablePDUnit.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePDUnit.TabIndex = 21
        Me.chkEnablePDUnit.Text = "Enable"
        Me.chkEnablePDUnit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Channel :"
        '
        'cbSelPDUnitDevice
        '
        Me.cbSelPDUnitDevice.FormattingEnabled = True
        Me.cbSelPDUnitDevice.Location = New System.Drawing.Point(82, 36)
        Me.cbSelPDUnitDevice.Name = "cbSelPDUnitDevice"
        Me.cbSelPDUnitDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelPDUnitDevice.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 12)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Device :"
        '
        'cbSelSampleType
        '
        Me.cbSelSampleType.FormattingEnabled = True
        Me.cbSelSampleType.Items.AddRange(New Object() {"Cell", "Panel", "Module"})
        Me.cbSelSampleType.Location = New System.Drawing.Point(105, 75)
        Me.cbSelSampleType.Name = "cbSelSampleType"
        Me.cbSelSampleType.Size = New System.Drawing.Size(73, 20)
        Me.cbSelSampleType.TabIndex = 5
        '
        'cbSelPallet
        '
        Me.cbSelPallet.FormattingEnabled = True
        Me.cbSelPallet.Location = New System.Drawing.Point(105, 23)
        Me.cbSelPallet.Name = "cbSelPallet"
        Me.cbSelPallet.Size = New System.Drawing.Size(73, 20)
        Me.cbSelPallet.TabIndex = 5
        '
        'lblSampleType
        '
        Me.lblSampleType.AutoSize = True
        Me.lblSampleType.Location = New System.Drawing.Point(10, 79)
        Me.lblSampleType.Name = "lblSampleType"
        Me.lblSampleType.Size = New System.Drawing.Size(89, 12)
        Me.lblSampleType.TabIndex = 4
        Me.lblSampleType.Text = "Sample Type :"
        '
        'cbSelJIG
        '
        Me.cbSelJIG.FormattingEnabled = True
        Me.cbSelJIG.Location = New System.Drawing.Point(105, 49)
        Me.cbSelJIG.Name = "cbSelJIG"
        Me.cbSelJIG.Size = New System.Drawing.Size(73, 20)
        Me.cbSelJIG.TabIndex = 5
        '
        'lblPallet
        '
        Me.lblPallet.AutoSize = True
        Me.lblPallet.Location = New System.Drawing.Point(6, 26)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(93, 12)
        Me.lblPallet.TabIndex = 4
        Me.lblPallet.Text = "Pallet Number :"
        '
        'lblJIG
        '
        Me.lblJIG.AutoSize = True
        Me.lblJIG.Location = New System.Drawing.Point(19, 52)
        Me.lblJIG.Name = "lblJIG"
        Me.lblJIG.Size = New System.Drawing.Size(80, 12)
        Me.lblJIG.TabIndex = 4
        Me.lblJIG.Text = "JIG Number :"
        '
        'gbSG
        '
        Me.gbSG.Controls.Add(Me.chkEnableSG)
        Me.gbSG.Controls.Add(Me.cbSelSGDevice)
        Me.gbSG.Controls.Add(Me.Label5)
        Me.gbSG.Controls.Add(Me.cbSelSGCh)
        Me.gbSG.Controls.Add(Me.Label8)
        Me.gbSG.Controls.Add(Me.cbSelSGGroup)
        Me.gbSG.Controls.Add(Me.Label9)
        Me.gbSG.Location = New System.Drawing.Point(743, 145)
        Me.gbSG.Name = "gbSG"
        Me.gbSG.Size = New System.Drawing.Size(136, 114)
        Me.gbSG.TabIndex = 8
        Me.gbSG.TabStop = False
        Me.gbSG.Text = "Signal Generator"
        '
        'chkEnableSG
        '
        Me.chkEnableSG.AutoSize = True
        Me.chkEnableSG.Location = New System.Drawing.Point(16, 16)
        Me.chkEnableSG.Name = "chkEnableSG"
        Me.chkEnableSG.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableSG.TabIndex = 18
        Me.chkEnableSG.Text = "Enable"
        Me.chkEnableSG.UseVisualStyleBackColor = True
        '
        'cbSelSGDevice
        '
        Me.cbSelSGDevice.FormattingEnabled = True
        Me.cbSelSGDevice.Location = New System.Drawing.Point(78, 62)
        Me.cbSelSGDevice.Name = "cbSelSGDevice"
        Me.cbSelSGDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSGDevice.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Device :"
        '
        'cbSelSGCh
        '
        Me.cbSelSGCh.FormattingEnabled = True
        Me.cbSelSGCh.Location = New System.Drawing.Point(78, 88)
        Me.cbSelSGCh.Name = "cbSelSGCh"
        Me.cbSelSGCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSGCh.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 12)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Channel :"
        '
        'cbSelSGGroup
        '
        Me.cbSelSGGroup.FormattingEnabled = True
        Me.cbSelSGGroup.Location = New System.Drawing.Point(78, 35)
        Me.cbSelSGGroup.Name = "cbSelSGGroup"
        Me.cbSelSGGroup.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSGGroup.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Group :"
        '
        'gbTC
        '
        Me.gbTC.Controls.Add(Me.chkEnableTC)
        Me.gbTC.Controls.Add(Me.cbSelTCDevice)
        Me.gbTC.Controls.Add(Me.Label7)
        Me.gbTC.Controls.Add(Me.cbSelTCChannel)
        Me.gbTC.Controls.Add(Me.Label3)
        Me.gbTC.Controls.Add(Me.cbSelTCGroup)
        Me.gbTC.Controls.Add(Me.Label4)
        Me.gbTC.Location = New System.Drawing.Point(626, 15)
        Me.gbTC.Name = "gbTC"
        Me.gbTC.Size = New System.Drawing.Size(136, 121)
        Me.gbTC.TabIndex = 6
        Me.gbTC.TabStop = False
        Me.gbTC.Text = "TC"
        '
        'chkEnableTC
        '
        Me.chkEnableTC.AutoSize = True
        Me.chkEnableTC.Location = New System.Drawing.Point(14, 16)
        Me.chkEnableTC.Name = "chkEnableTC"
        Me.chkEnableTC.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableTC.TabIndex = 17
        Me.chkEnableTC.Text = "Enable"
        Me.chkEnableTC.UseVisualStyleBackColor = True
        '
        'cbSelTCDevice
        '
        Me.cbSelTCDevice.FormattingEnabled = True
        Me.cbSelTCDevice.Location = New System.Drawing.Point(76, 62)
        Me.cbSelTCDevice.Name = "cbSelTCDevice"
        Me.cbSelTCDevice.Size = New System.Drawing.Size(49, 20)
        Me.cbSelTCDevice.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Device :"
        '
        'cbSelTCChannel
        '
        Me.cbSelTCChannel.FormattingEnabled = True
        Me.cbSelTCChannel.Location = New System.Drawing.Point(76, 88)
        Me.cbSelTCChannel.Name = "cbSelTCChannel"
        Me.cbSelTCChannel.Size = New System.Drawing.Size(49, 20)
        Me.cbSelTCChannel.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Channel :"
        '
        'cbSelTCGroup
        '
        Me.cbSelTCGroup.FormattingEnabled = True
        Me.cbSelTCGroup.Location = New System.Drawing.Point(76, 35)
        Me.cbSelTCGroup.Name = "cbSelTCGroup"
        Me.cbSelTCGroup.Size = New System.Drawing.Size(49, 20)
        Me.cbSelTCGroup.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Group :"
        '
        'gbM6000
        '
        Me.gbM6000.Controls.Add(Me.cbSelM6000Ch)
        Me.gbM6000.Controls.Add(Me.Label1)
        Me.gbM6000.Controls.Add(Me.Label2)
        Me.gbM6000.Controls.Add(Me.chkEnableM6000)
        Me.gbM6000.Controls.Add(Me.cbSelM6000Device)
        Me.gbM6000.Location = New System.Drawing.Point(184, 15)
        Me.gbM6000.Name = "gbM6000"
        Me.gbM6000.Size = New System.Drawing.Size(142, 93)
        Me.gbM6000.TabIndex = 5
        Me.gbM6000.TabStop = False
        Me.gbM6000.Text = "M6000"
        '
        'cbSelM6000Ch
        '
        Me.cbSelM6000Ch.FormattingEnabled = True
        Me.cbSelM6000Ch.Location = New System.Drawing.Point(73, 62)
        Me.cbSelM6000Ch.Name = "cbSelM6000Ch"
        Me.cbSelM6000Ch.Size = New System.Drawing.Size(49, 20)
        Me.cbSelM6000Ch.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Channel :"
        '
        'chkEnableM6000
        '
        Me.chkEnableM6000.AutoSize = True
        Me.chkEnableM6000.Location = New System.Drawing.Point(19, 17)
        Me.chkEnableM6000.Name = "chkEnableM6000"
        Me.chkEnableM6000.Size = New System.Drawing.Size(63, 16)
        Me.chkEnableM6000.TabIndex = 15
        Me.chkEnableM6000.Text = "Enable"
        Me.chkEnableM6000.UseVisualStyleBackColor = True
        '
        'cbSelM6000Device
        '
        Me.cbSelM6000Device.FormattingEnabled = True
        Me.cbSelM6000Device.Location = New System.Drawing.Point(73, 38)
        Me.cbSelM6000Device.Name = "cbSelM6000Device"
        Me.cbSelM6000Device.Size = New System.Drawing.Size(49, 20)
        Me.cbSelM6000Device.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(259, 340)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 31)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(541, 340)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(87, 31)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Location = New System.Drawing.Point(355, 340)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(87, 31)
        Me.btnDel.TabIndex = 8
        Me.btnDel.Text = "DEL"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'gbListChAlloc
        '
        Me.gbListChAlloc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbListChAlloc.Controls.Add(Me.ucListChAllocation)
        Me.gbListChAlloc.Location = New System.Drawing.Point(7, 376)
        Me.gbListChAlloc.Name = "gbListChAlloc"
        Me.gbListChAlloc.Size = New System.Drawing.Size(905, 257)
        Me.gbListChAlloc.TabIndex = 10
        Me.gbListChAlloc.TabStop = False
        Me.gbListChAlloc.Text = "List Of Channel Allocation"
        '
        'ucListChAllocation
        '
        Me.ucListChAllocation.ColHeader = New String() {"Ch", "M6000 Device", "M6000 Channel", "TC Group", "TC Device", "TC Channel", "JIG No"}
        Me.ucListChAllocation.ColHeaderWidthRatio = "10,15,15,15,15,15,15"
        Me.ucListChAllocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucListChAllocation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListChAllocation.FullRawSelection = True
        Me.ucListChAllocation.HideSelection = False
        Me.ucListChAllocation.LabelEdit = True
        Me.ucListChAllocation.LabelWrap = True
        Me.ucListChAllocation.Location = New System.Drawing.Point(3, 17)
        Me.ucListChAllocation.Name = "ucListChAllocation"
        Me.ucListChAllocation.Size = New System.Drawing.Size(899, 237)
        Me.ucListChAllocation.TabIndex = 9
        Me.ucListChAllocation.UseCheckBoxex = False
        '
        'btnChange
        '
        Me.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChange.Location = New System.Drawing.Point(448, 340)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(87, 31)
        Me.btnChange.TabIndex = 11
        Me.btnChange.Text = "Change"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'tcSettings
        '
        Me.tcSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcSettings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcSettings.Controls.Add(Me.tpChAllocation)
        Me.tcSettings.Controls.Add(Me.tpJIGLayout)
        Me.tcSettings.Controls.Add(Me.tpDisplay)
        Me.tcSettings.Location = New System.Drawing.Point(12, 12)
        Me.tcSettings.Name = "tcSettings"
        Me.tcSettings.SelectedIndex = 0
        Me.tcSettings.Size = New System.Drawing.Size(927, 668)
        Me.tcSettings.TabIndex = 12
        '
        'tpChAllocation
        '
        Me.tpChAllocation.Controls.Add(Me.gbSettingsChAlloc)
        Me.tpChAllocation.Controls.Add(Me.btnClear)
        Me.tpChAllocation.Controls.Add(Me.gbListChAlloc)
        Me.tpChAllocation.Controls.Add(Me.btnChange)
        Me.tpChAllocation.Controls.Add(Me.btnAdd)
        Me.tpChAllocation.Controls.Add(Me.btnDel)
        Me.tpChAllocation.Location = New System.Drawing.Point(4, 25)
        Me.tpChAllocation.Name = "tpChAllocation"
        Me.tpChAllocation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpChAllocation.Size = New System.Drawing.Size(919, 639)
        Me.tpChAllocation.TabIndex = 0
        Me.tpChAllocation.Text = "Channel Allocation"
        Me.tpChAllocation.UseVisualStyleBackColor = True
        '
        'tpJIGLayout
        '
        Me.tpJIGLayout.Controls.Add(Me.btnEditJIGLocation_tpJIGLayout)
        Me.tpJIGLayout.Controls.Add(Me.GroupBox3)
        Me.tpJIGLayout.Controls.Add(Me.btnDEL_tpJIGLayout)
        Me.tpJIGLayout.Controls.Add(Me.btnClear_tpJIGLayout)
        Me.tpJIGLayout.Controls.Add(Me.btnADD_tpJIGLayout)
        Me.tpJIGLayout.Controls.Add(Me.btnChange_tpJIGLayout)
        Me.tpJIGLayout.Controls.Add(Me.gbSettingsJIGLayout)
        Me.tpJIGLayout.Location = New System.Drawing.Point(4, 25)
        Me.tpJIGLayout.Name = "tpJIGLayout"
        Me.tpJIGLayout.Padding = New System.Windows.Forms.Padding(3)
        Me.tpJIGLayout.Size = New System.Drawing.Size(919, 639)
        Me.tpJIGLayout.TabIndex = 1
        Me.tpJIGLayout.Text = "JIG Layout"
        Me.tpJIGLayout.UseVisualStyleBackColor = True
        '
        'btnEditJIGLocation_tpJIGLayout
        '
        Me.btnEditJIGLocation_tpJIGLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditJIGLocation_tpJIGLayout.Location = New System.Drawing.Point(625, 347)
        Me.btnEditJIGLocation_tpJIGLayout.Name = "btnEditJIGLocation_tpJIGLayout"
        Me.btnEditJIGLocation_tpJIGLayout.Size = New System.Drawing.Size(113, 31)
        Me.btnEditJIGLocation_tpJIGLayout.TabIndex = 17
        Me.btnEditJIGLocation_tpJIGLayout.Text = "Edit Location"
        Me.btnEditJIGLocation_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ucListJIGSettings)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 400)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(906, 233)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "List Of JIG Settings"
        '
        'ucListJIGSettings
        '
        Me.ucListJIGSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListJIGSettings.ColHeader = New String() {"JIG No.", "Target Sample", "Size(X,Y)", "Cell Layout(Col,Row)", "Background Color", "Outline Color/Selected", "Outline Color/Unselected", "Outline Width", "Font of status", "Multi Select", "Add Text"}
        Me.ucListJIGSettings.ColHeaderWidthRatio = "7,11,10,15,13,15,15,10,7,5,5"
        Me.ucListJIGSettings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListJIGSettings.FullRawSelection = True
        Me.ucListJIGSettings.HideSelection = False
        Me.ucListJIGSettings.LabelEdit = True
        Me.ucListJIGSettings.LabelWrap = True
        Me.ucListJIGSettings.Location = New System.Drawing.Point(6, 20)
        Me.ucListJIGSettings.Name = "ucListJIGSettings"
        Me.ucListJIGSettings.Size = New System.Drawing.Size(894, 207)
        Me.ucListJIGSettings.TabIndex = 9
        Me.ucListJIGSettings.UseCheckBoxex = False
        '
        'btnDEL_tpJIGLayout
        '
        Me.btnDEL_tpJIGLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDEL_tpJIGLayout.Location = New System.Drawing.Point(526, 347)
        Me.btnDEL_tpJIGLayout.Name = "btnDEL_tpJIGLayout"
        Me.btnDEL_tpJIGLayout.Size = New System.Drawing.Size(87, 31)
        Me.btnDEL_tpJIGLayout.TabIndex = 14
        Me.btnDEL_tpJIGLayout.Text = "DEL"
        Me.btnDEL_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'btnClear_tpJIGLayout
        '
        Me.btnClear_tpJIGLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear_tpJIGLayout.Location = New System.Drawing.Point(424, 347)
        Me.btnClear_tpJIGLayout.Name = "btnClear_tpJIGLayout"
        Me.btnClear_tpJIGLayout.Size = New System.Drawing.Size(87, 31)
        Me.btnClear_tpJIGLayout.TabIndex = 13
        Me.btnClear_tpJIGLayout.Text = "Clear"
        Me.btnClear_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'btnADD_tpJIGLayout
        '
        Me.btnADD_tpJIGLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD_tpJIGLayout.Location = New System.Drawing.Point(211, 347)
        Me.btnADD_tpJIGLayout.Name = "btnADD_tpJIGLayout"
        Me.btnADD_tpJIGLayout.Size = New System.Drawing.Size(87, 31)
        Me.btnADD_tpJIGLayout.TabIndex = 12
        Me.btnADD_tpJIGLayout.Text = "ADD"
        Me.btnADD_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'btnChange_tpJIGLayout
        '
        Me.btnChange_tpJIGLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChange_tpJIGLayout.Location = New System.Drawing.Point(320, 347)
        Me.btnChange_tpJIGLayout.Name = "btnChange_tpJIGLayout"
        Me.btnChange_tpJIGLayout.Size = New System.Drawing.Size(87, 31)
        Me.btnChange_tpJIGLayout.TabIndex = 15
        Me.btnChange_tpJIGLayout.Text = "Change"
        Me.btnChange_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'gbSettingsJIGLayout
        '
        Me.gbSettingsJIGLayout.Controls.Add(Me.tbAddText_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label12)
        Me.gbSettingsJIGLayout.Controls.Add(Me.chkSelJIGToMultiChannelSelect_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.lblJIGBackColor_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.lblJIGLayout_StatusMsgFont)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label11)
        Me.gbSettingsJIGLayout.Controls.Add(Me.tbNumOfSample_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label30)
        Me.gbSettingsJIGLayout.Controls.Add(Me.gbSettingsProperty02_JIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.ucJIG)
        Me.gbSettingsJIGLayout.Controls.Add(Me.gbSettingProperty01_JIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.tbJIGOutlineWidth_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.lblJIGOutlineColorAtUnsel_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.lblJIGOutlineColorAtSel_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label26)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label25)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label24)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label23)
        Me.gbSettingsJIGLayout.Controls.Add(Me.cbSelSampleType_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label21)
        Me.gbSettingsJIGLayout.Controls.Add(Me.cbSelJIG_tpJIGLayout)
        Me.gbSettingsJIGLayout.Controls.Add(Me.Label20)
        Me.gbSettingsJIGLayout.Location = New System.Drawing.Point(7, 2)
        Me.gbSettingsJIGLayout.Name = "gbSettingsJIGLayout"
        Me.gbSettingsJIGLayout.Size = New System.Drawing.Size(904, 339)
        Me.gbSettingsJIGLayout.TabIndex = 0
        Me.gbSettingsJIGLayout.TabStop = False
        Me.gbSettingsJIGLayout.Text = "JIG Settings"
        '
        'tbAddText_tpJIGLayout
        '
        Me.tbAddText_tpJIGLayout.Location = New System.Drawing.Point(174, 93)
        Me.tbAddText_tpJIGLayout.Name = "tbAddText_tpJIGLayout"
        Me.tbAddText_tpJIGLayout.Size = New System.Drawing.Size(87, 21)
        Me.tbAddText_tpJIGLayout.TabIndex = 33
        Me.tbAddText_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(104, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 12)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Add Text :"
        '
        'chkSelJIGToMultiChannelSelect_tpJIGLayout
        '
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.AutoSize = True
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.Location = New System.Drawing.Point(238, 19)
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.Name = "chkSelJIGToMultiChannelSelect_tpJIGLayout"
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.Size = New System.Drawing.Size(90, 16)
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.TabIndex = 31
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.Text = "Multi Select"
        Me.chkSelJIGToMultiChannelSelect_tpJIGLayout.UseVisualStyleBackColor = True
        '
        'lblJIGBackColor_tpJIGLayout
        '
        Me.lblJIGBackColor_tpJIGLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJIGBackColor_tpJIGLayout.Location = New System.Drawing.Point(174, 120)
        Me.lblJIGBackColor_tpJIGLayout.Name = "lblJIGBackColor_tpJIGLayout"
        Me.lblJIGBackColor_tpJIGLayout.Size = New System.Drawing.Size(87, 20)
        Me.lblJIGBackColor_tpJIGLayout.TabIndex = 16
        '
        'lblJIGLayout_StatusMsgFont
        '
        Me.lblJIGLayout_StatusMsgFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJIGLayout_StatusMsgFont.Location = New System.Drawing.Point(114, 226)
        Me.lblJIGLayout_StatusMsgFont.Name = "lblJIGLayout_StatusMsgFont"
        Me.lblJIGLayout_StatusMsgFont.Size = New System.Drawing.Size(162, 20)
        Me.lblJIGLayout_StatusMsgFont.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("굴림체", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 12)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Font of Status :"
        '
        'tbNumOfSample_tpJIGLayout
        '
        Me.tbNumOfSample_tpJIGLayout.Location = New System.Drawing.Point(174, 66)
        Me.tbNumOfSample_tpJIGLayout.Name = "tbNumOfSample_tpJIGLayout"
        Me.tbNumOfSample_tpJIGLayout.Size = New System.Drawing.Size(87, 21)
        Me.tbNumOfSample_tpJIGLayout.TabIndex = 26
        Me.tbNumOfSample_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(47, 70)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 12)
        Me.Label30.TabIndex = 25
        Me.Label30.Text = "Number Of Sample :"
        '
        'gbSettingsProperty02_JIGLayout
        '
        Me.gbSettingsProperty02_JIGLayout.Controls.Add(Me.Label28)
        Me.gbSettingsProperty02_JIGLayout.Controls.Add(Me.Label22)
        Me.gbSettingsProperty02_JIGLayout.Controls.Add(Me.tbCellLayoutRow_tpJIGLayout)
        Me.gbSettingsProperty02_JIGLayout.Controls.Add(Me.tbCellLayoutCol_tpJIGLayout)
        Me.gbSettingsProperty02_JIGLayout.Location = New System.Drawing.Point(147, 259)
        Me.gbSettingsProperty02_JIGLayout.Name = "gbSettingsProperty02_JIGLayout"
        Me.gbSettingsProperty02_JIGLayout.Size = New System.Drawing.Size(129, 75)
        Me.gbSettingsProperty02_JIGLayout.TabIndex = 23
        Me.gbSettingsProperty02_JIGLayout.TabStop = False
        Me.gbSettingsProperty02_JIGLayout.Text = "Cell Layout"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(16, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(38, 12)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "Row :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(22, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 12)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Col :"
        '
        'tbCellLayoutRow_tpJIGLayout
        '
        Me.tbCellLayoutRow_tpJIGLayout.Location = New System.Drawing.Point(59, 47)
        Me.tbCellLayoutRow_tpJIGLayout.Name = "tbCellLayoutRow_tpJIGLayout"
        Me.tbCellLayoutRow_tpJIGLayout.Size = New System.Drawing.Size(53, 21)
        Me.tbCellLayoutRow_tpJIGLayout.TabIndex = 21
        Me.tbCellLayoutRow_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCellLayoutCol_tpJIGLayout
        '
        Me.tbCellLayoutCol_tpJIGLayout.Location = New System.Drawing.Point(59, 21)
        Me.tbCellLayoutCol_tpJIGLayout.Name = "tbCellLayoutCol_tpJIGLayout"
        Me.tbCellLayoutCol_tpJIGLayout.Size = New System.Drawing.Size(53, 21)
        Me.tbCellLayoutCol_tpJIGLayout.TabIndex = 11
        Me.tbCellLayoutCol_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ucJIG
        '
        Me.ucJIG.CellLayout_Col = 2
        Me.ucJIG.CellLayout_Row = 2
        Me.ucJIG.ChannelNo = 0
        Me.ucJIG.EnabelMultiSelect = False
        Me.ucJIG.IsSelected = False
        Me.ucJIG.IsSelectedChannel = True
        Me.ucJIG.JIGColor = System.Drawing.Color.LightGray
        Me.ucJIG.JIGNo = 0
        Me.ucJIG.Location = New System.Drawing.Point(371, 34)
        Me.ucJIG.Name = "ucJIG"
        Me.ucJIG.NumberOfCell = 4
        Me.ucJIG.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.ucJIG.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.ucJIG.OutlineWidth = 3.0R
        Me.ucJIG.PreviouslySelectedCellIdx = 0
        Me.ucJIG.SampleType = M7000.ucSampleInfos.eSampleType.eCell
        Me.ucJIG.Size = New System.Drawing.Size(438, 259)
        Me.ucJIG.StatusMsgFont = Nothing
        Me.ucJIG.TabIndex = 24
        '
        'gbSettingProperty01_JIGLayout
        '
        Me.gbSettingProperty01_JIGLayout.Controls.Add(Me.Label27)
        Me.gbSettingProperty01_JIGLayout.Controls.Add(Me.tbJIGSizeWidth_tpJIGLayout)
        Me.gbSettingProperty01_JIGLayout.Controls.Add(Me.Label19)
        Me.gbSettingProperty01_JIGLayout.Controls.Add(Me.tbJIGSizeHeight_tpJIGLayout)
        Me.gbSettingProperty01_JIGLayout.Location = New System.Drawing.Point(8, 259)
        Me.gbSettingProperty01_JIGLayout.Name = "gbSettingProperty01_JIGLayout"
        Me.gbSettingProperty01_JIGLayout.Size = New System.Drawing.Size(133, 75)
        Me.gbSettingProperty01_JIGLayout.TabIndex = 22
        Me.gbSettingProperty01_JIGLayout.TabStop = False
        Me.gbSettingProperty01_JIGLayout.Text = "JIG Display Size"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 50)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 12)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "Height :"
        '
        'tbJIGSizeWidth_tpJIGLayout
        '
        Me.tbJIGSizeWidth_tpJIGLayout.Location = New System.Drawing.Point(61, 21)
        Me.tbJIGSizeWidth_tpJIGLayout.Name = "tbJIGSizeWidth_tpJIGLayout"
        Me.tbJIGSizeWidth_tpJIGLayout.Size = New System.Drawing.Size(62, 21)
        Me.tbJIGSizeWidth_tpJIGLayout.TabIndex = 1
        Me.tbJIGSizeWidth_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 12)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Width :"
        '
        'tbJIGSizeHeight_tpJIGLayout
        '
        Me.tbJIGSizeHeight_tpJIGLayout.Location = New System.Drawing.Point(61, 46)
        Me.tbJIGSizeHeight_tpJIGLayout.Name = "tbJIGSizeHeight_tpJIGLayout"
        Me.tbJIGSizeHeight_tpJIGLayout.Size = New System.Drawing.Size(62, 21)
        Me.tbJIGSizeHeight_tpJIGLayout.TabIndex = 20
        Me.tbJIGSizeHeight_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbJIGOutlineWidth_tpJIGLayout
        '
        Me.tbJIGOutlineWidth_tpJIGLayout.Location = New System.Drawing.Point(174, 200)
        Me.tbJIGOutlineWidth_tpJIGLayout.Name = "tbJIGOutlineWidth_tpJIGLayout"
        Me.tbJIGOutlineWidth_tpJIGLayout.Size = New System.Drawing.Size(87, 21)
        Me.tbJIGOutlineWidth_tpJIGLayout.TabIndex = 19
        Me.tbJIGOutlineWidth_tpJIGLayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblJIGOutlineColorAtUnsel_tpJIGLayout
        '
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout.Location = New System.Drawing.Point(174, 174)
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout.Name = "lblJIGOutlineColorAtUnsel_tpJIGLayout"
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout.Size = New System.Drawing.Size(87, 20)
        Me.lblJIGOutlineColorAtUnsel_tpJIGLayout.TabIndex = 18
        '
        'lblJIGOutlineColorAtSel_tpJIGLayout
        '
        Me.lblJIGOutlineColorAtSel_tpJIGLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJIGOutlineColorAtSel_tpJIGLayout.Location = New System.Drawing.Point(174, 146)
        Me.lblJIGOutlineColorAtSel_tpJIGLayout.Name = "lblJIGOutlineColorAtSel_tpJIGLayout"
        Me.lblJIGOutlineColorAtSel_tpJIGLayout.Size = New System.Drawing.Size(87, 20)
        Me.lblJIGOutlineColorAtSel_tpJIGLayout.TabIndex = 17
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("굴림체", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label26.Location = New System.Drawing.Point(73, 204)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(95, 12)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Outline Width :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 176)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(155, 12)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Outline Color/Unselected :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(27, 150)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(141, 12)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "Outline Color/Selected :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(54, 123)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(114, 12)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Background Color :"
        '
        'cbSelSampleType_tpJIGLayout
        '
        Me.cbSelSampleType_tpJIGLayout.FormattingEnabled = True
        Me.cbSelSampleType_tpJIGLayout.Items.AddRange(New Object() {"Cell", "Panel", "Module"})
        Me.cbSelSampleType_tpJIGLayout.Location = New System.Drawing.Point(174, 40)
        Me.cbSelSampleType_tpJIGLayout.Name = "cbSelSampleType_tpJIGLayout"
        Me.cbSelSampleType_tpJIGLayout.Size = New System.Drawing.Size(88, 20)
        Me.cbSelSampleType_tpJIGLayout.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(79, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(89, 12)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Sample Type :"
        '
        'cbSelJIG_tpJIGLayout
        '
        Me.cbSelJIG_tpJIGLayout.FormattingEnabled = True
        Me.cbSelJIG_tpJIGLayout.Location = New System.Drawing.Point(174, 16)
        Me.cbSelJIG_tpJIGLayout.Name = "cbSelJIG_tpJIGLayout"
        Me.cbSelJIG_tpJIGLayout.Size = New System.Drawing.Size(58, 20)
        Me.cbSelJIG_tpJIGLayout.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(117, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 12)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "JIG No :"
        '
        'tpDisplay
        '
        Me.tpDisplay.Controls.Add(Me.cbDisplayMainUI)
        Me.tpDisplay.Controls.Add(Me.Label29)
        Me.tpDisplay.Location = New System.Drawing.Point(4, 25)
        Me.tpDisplay.Name = "tpDisplay"
        Me.tpDisplay.Size = New System.Drawing.Size(919, 639)
        Me.tpDisplay.TabIndex = 2
        Me.tpDisplay.Text = "Display"
        Me.tpDisplay.UseVisualStyleBackColor = True
        '
        'cbDisplayMainUI
        '
        Me.cbDisplayMainUI.FormattingEnabled = True
        Me.cbDisplayMainUI.Location = New System.Drawing.Point(192, 23)
        Me.cbDisplayMainUI.Name = "cbDisplayMainUI"
        Me.cbDisplayMainUI.Size = New System.Drawing.Size(266, 20)
        Me.cbDisplayMainUI.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(49, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(139, 12)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Select Main Control UI :"
        '
        'btnTest
        '
        Me.btnTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest.Location = New System.Drawing.Point(394, 687)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(83, 37)
        Me.btnTest.TabIndex = 13
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'cbSelSwitchPairCh
        '
        Me.cbSelSwitchPairCh.FormattingEnabled = True
        Me.cbSelSwitchPairCh.Location = New System.Drawing.Point(70, 87)
        Me.cbSelSwitchPairCh.Name = "cbSelSwitchPairCh"
        Me.cbSelSwitchPairCh.Size = New System.Drawing.Size(49, 20)
        Me.cbSelSwitchPairCh.TabIndex = 18
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 90)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(60, 12)
        Me.Label37.TabIndex = 17
        Me.Label37.Text = "Channel :"
        '
        'frmSettingWind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 728)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.tcSettings)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnCalcle)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmSettingWind"
        Me.Text = "Settings"
        Me.gbSettingsChAlloc.ResumeLayout(False)
        Me.gbSettingsChAlloc.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSMUForIVL.ResumeLayout(False)
        Me.gbSMUForIVL.PerformLayout()
        Me.gbSW7000.ResumeLayout(False)
        Me.gbSW7000.PerformLayout()
        Me.gbSwitch.ResumeLayout(False)
        Me.gbSwitch.PerformLayout()
        Me.gbPGGroup.ResumeLayout(False)
        Me.gbPGGroup.PerformLayout()
        Me.gbPGCtrlBD.ResumeLayout(False)
        Me.gbPGCtrlBD.PerformLayout()
        Me.gbPGPower.ResumeLayout(False)
        Me.gbPGPower.PerformLayout()
        Me.gbPG.ResumeLayout(False)
        Me.gbPG.PerformLayout()
        Me.gbPDUnit.ResumeLayout(False)
        Me.gbPDUnit.PerformLayout()
        Me.gbSG.ResumeLayout(False)
        Me.gbSG.PerformLayout()
        Me.gbTC.ResumeLayout(False)
        Me.gbTC.PerformLayout()
        Me.gbM6000.ResumeLayout(False)
        Me.gbM6000.PerformLayout()
        Me.gbListChAlloc.ResumeLayout(False)
        Me.tcSettings.ResumeLayout(False)
        Me.tpChAllocation.ResumeLayout(False)
        Me.tpJIGLayout.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.gbSettingsJIGLayout.ResumeLayout(False)
        Me.gbSettingsJIGLayout.PerformLayout()
        Me.gbSettingsProperty02_JIGLayout.ResumeLayout(False)
        Me.gbSettingsProperty02_JIGLayout.PerformLayout()
        Me.gbSettingProperty01_JIGLayout.ResumeLayout(False)
        Me.gbSettingProperty01_JIGLayout.PerformLayout()
        Me.tpDisplay.ResumeLayout(False)
        Me.tpDisplay.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCalcle As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbSettingsChAlloc As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelJIG As System.Windows.Forms.ComboBox
    Friend WithEvents lblJIG As System.Windows.Forms.Label
    Friend WithEvents gbTC As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelTCDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbSelTCChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelTCGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbM6000 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelM6000Ch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSelM6000Device As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents ucListChAllocation As ucDispListView
    Friend WithEvents gbListChAlloc As System.Windows.Forms.GroupBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents gbSG As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSGDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbSelSGCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbSelSGGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbSelSampleType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleType As System.Windows.Forms.Label
    Friend WithEvents cbSelPallet As System.Windows.Forms.ComboBox
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents gbPGGroup As System.Windows.Forms.GroupBox
    Friend WithEvents gbPGCtrlBD As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelPGCtrlDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbSelPGCtrlCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbSelPGCtrlGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gbPGPower As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelPGPwrDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbSelPGPwrCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbSelPGPwrGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbPG As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelPGCh As System.Windows.Forms.ComboBox
    Friend WithEvents lblPGCh As System.Windows.Forms.Label
    Friend WithEvents cbSelPGDevice As System.Windows.Forms.ComboBox
    Friend WithEvents lblPGDev As System.Windows.Forms.Label
    Friend WithEvents gbPDUnit As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelPDUnitCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbSelPDUnitDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tcSettings As System.Windows.Forms.TabControl
    Friend WithEvents tpChAllocation As System.Windows.Forms.TabPage
    Friend WithEvents tpJIGLayout As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ucListJIGSettings As M7000.ucDispListView
    Friend WithEvents btnClear_tpJIGLayout As System.Windows.Forms.Button
    Friend WithEvents btnChange_tpJIGLayout As System.Windows.Forms.Button
    Friend WithEvents btnADD_tpJIGLayout As System.Windows.Forms.Button
    Friend WithEvents btnDEL_tpJIGLayout As System.Windows.Forms.Button
    Friend WithEvents gbSettingsJIGLayout As System.Windows.Forms.GroupBox
    Friend WithEvents tbJIGOutlineWidth_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents lblJIGOutlineColorAtUnsel_tpJIGLayout As System.Windows.Forms.Label
    Friend WithEvents lblJIGOutlineColorAtSel_tpJIGLayout As System.Windows.Forms.Label
    Friend WithEvents lblJIGBackColor_tpJIGLayout As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbCellLayoutCol_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbSelSampleType_tpJIGLayout As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbSelJIG_tpJIGLayout As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbJIGSizeWidth_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gbSettingProperty01_JIGLayout As System.Windows.Forms.GroupBox
    Friend WithEvents tbJIGSizeHeight_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents tbCellLayoutRow_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents gbSettingsProperty02_JIGLayout As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents tbNumOfSample_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ucJIG As M7000.ucDispJIG
    Friend WithEvents btnEditJIGLocation_tpJIGLayout As System.Windows.Forms.Button
    Friend WithEvents tpDisplay As System.Windows.Forms.TabPage
    Friend WithEvents cbDisplayMainUI As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents gbSMUForIVL As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSMUforIVLCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cbSelSMUForIVLDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents gbSW7000 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSW7000Ch As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbSelSW7000Device As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents gbSwitch As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSwitchCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cbSelSwitchDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents chkEnableSMU_IVL As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableSW7000 As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableK7001 As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnablePG As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnablePDUnit As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableSG As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableTC As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableM6000 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblJIGLayout_StatusMsgFont As System.Windows.Forms.Label
    Friend WithEvents chkSelJIGToMultiChannelSelect_tpJIGLayout As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkViewingAngleUse As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLSweepUse As System.Windows.Forms.CheckBox
    Friend WithEvents chkLifetimeUse As System.Windows.Forms.CheckBox
    Friend WithEvents tbAddText_tpJIGLayout As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSelSwitchPairCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
End Class
