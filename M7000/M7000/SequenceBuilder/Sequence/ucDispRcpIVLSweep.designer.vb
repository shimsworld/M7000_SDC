<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpIVLSweep
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.gbIVLSweepCommon = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.UcDispListView1 = New M7000.ucDispListView()
        Me.tcCommon = New System.Windows.Forms.TabControl()
        Me.tbStandard = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ChkAnd = New System.Windows.Forms.CheckBox()
        Me.chkBiasInvert = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbNormalFastSelect = New System.Windows.Forms.ComboBox()
        Me.cbFastBiasMode = New System.Windows.Forms.ComboBox()
        Me.tbValueForFast = New System.Windows.Forms.TextBox()
        Me.lblValueForFast = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbLumiCorrection = New System.Windows.Forms.TextBox()
        Me.lblLumiCorrectionUnit = New System.Windows.Forms.Label()
        Me.lblLumiCorrection = New System.Windows.Forms.Label()
        Me.tbCurrentLimit = New System.Windows.Forms.TextBox()
        Me.lblCurrentLimitUnit = New System.Windows.Forms.Label()
        Me.lblCurrentLimit = New System.Windows.Forms.Label()
        Me.tbLMeasLimit = New System.Windows.Forms.TextBox()
        Me.lblLMeasLimitUnit = New System.Windows.Forms.Label()
        Me.lblLMeasLimit = New System.Windows.Forms.Label()
        Me.ucColorSetting = New M7000.ucMeasureColorList()
        Me.lblViewingAngleUnit = New System.Windows.Forms.Label()
        Me.tbViewingAngle = New System.Windows.Forms.TextBox()
        Me.lblBiasMode = New System.Windows.Forms.Label()
        Me.lblViewingAngle = New System.Windows.Forms.Label()
        Me.tbLMeasLevel = New System.Windows.Forms.TextBox()
        Me.cbBiasMode = New System.Windows.Forms.ComboBox()
        Me.lblLMeasValueUnit = New System.Windows.Forms.Label()
        Me.lblLMeasLevel = New System.Windows.Forms.Label()
        Me.cbMeasureMode = New System.Windows.Forms.ComboBox()
        Me.lblMeasMode = New System.Windows.Forms.Label()
        Me.ucSweepSetting = New M7000.ucSweepSetting()
        Me.tbDetail = New System.Windows.Forms.TabPage()
        Me.gbDetailSettings = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbSweepMode = New System.Windows.Forms.ComboBox()
        Me.tbCycleDelay = New System.Windows.Forms.TextBox()
        Me.cbDelayState = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbMeasureDelay = New System.Windows.Forms.TextBox()
        Me.cbSweepMethod = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbOffsetBias = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbAverage = New System.Windows.Forms.TextBox()
        Me.lblOffsetBiasValueUnit = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSweepDelay = New System.Windows.Forms.TextBox()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ucDispRGBSignal = New M7000.ucPanelRGB()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbSweepLine = New System.Windows.Forms.ComboBox()
        Me.ucDispKeithley = New CSMULib.ucKeithleySMUSettings()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.gbIVLSweepCommon.SuspendLayout()
        Me.tcCommon.SuspendLayout()
        Me.tbStandard.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbDetail.SuspendLayout()
        Me.gbDetailSettings.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spContainer.Location = New System.Drawing.Point(3, 3)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.Controls.Add(Me.gbIVLSweepCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(543, 943)
        Me.spContainer.SplitterDistance = 417
        Me.spContainer.TabIndex = 2
        '
        'gbIVLSweepCommon
        '
        Me.gbIVLSweepCommon.Controls.Add(Me.tcCommon)
        Me.gbIVLSweepCommon.Location = New System.Drawing.Point(10, 13)
        Me.gbIVLSweepCommon.MinimumSize = New System.Drawing.Size(440, 334)
        Me.gbIVLSweepCommon.Name = "gbIVLSweepCommon"
        Me.gbIVLSweepCommon.Size = New System.Drawing.Size(518, 401)
        Me.gbIVLSweepCommon.TabIndex = 0
        Me.gbIVLSweepCommon.TabStop = False
        Me.gbIVLSweepCommon.Text = "Common"
        '
        'tcCommon
        '
        Me.tcCommon.Controls.Add(Me.tbStandard)
        Me.tcCommon.Controls.Add(Me.tbDetail)
        Me.tcCommon.Location = New System.Drawing.Point(7, 17)
        Me.tcCommon.Name = "tcCommon"
        Me.tcCommon.SelectedIndex = 0
        Me.tcCommon.Size = New System.Drawing.Size(505, 378)
        Me.tcCommon.TabIndex = 35
        '
        'tbStandard
        '
        Me.tbStandard.BackColor = System.Drawing.SystemColors.Control
        Me.tbStandard.Controls.Add(Me.SplitContainer2)
        Me.tbStandard.Location = New System.Drawing.Point(4, 24)
        Me.tbStandard.Name = "tbStandard"
        Me.tbStandard.Padding = New System.Windows.Forms.Padding(3)
        Me.tbStandard.Size = New System.Drawing.Size(497, 350)
        Me.tbStandard.TabIndex = 0
        Me.tbStandard.Text = "Standard"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkAnd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkBiasInvert)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbLumiCorrection)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLumiCorrectionUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLumiCorrection)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbCurrentLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCurrentLimitUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCurrentLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbLMeasLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasLimitUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ucColorSetting)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblViewingAngleUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbViewingAngle)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblBiasMode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblViewingAngle)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbLMeasLevel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbBiasMode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasValueUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasLevel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cbMeasureMode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblMeasMode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.ucSweepSetting)
        Me.SplitContainer2.Size = New System.Drawing.Size(491, 344)
        Me.SplitContainer2.SplitterDistance = 237
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 0
        '
        'ChkAnd
        '
        Me.ChkAnd.AutoSize = True
        Me.ChkAnd.Location = New System.Drawing.Point(108, 149)
        Me.ChkAnd.Name = "ChkAnd"
        Me.ChkAnd.Size = New System.Drawing.Size(48, 19)
        Me.ChkAnd.TabIndex = 0
        Me.ChkAnd.Text = "And"
        Me.ChkAnd.UseVisualStyleBackColor = True
        '
        'chkBiasInvert
        '
        Me.chkBiasInvert.AutoSize = True
        Me.chkBiasInvert.Location = New System.Drawing.Point(81, 232)
        Me.chkBiasInvert.Name = "chkBiasInvert"
        Me.chkBiasInvert.Size = New System.Drawing.Size(86, 19)
        Me.chkBiasInvert.TabIndex = 44
        Me.chkBiasInvert.Text = "Bias Invert"
        Me.chkBiasInvert.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbNormalFastSelect)
        Me.GroupBox1.Controls.Add(Me.cbFastBiasMode)
        Me.GroupBox1.Controls.Add(Me.tbValueForFast)
        Me.GroupBox1.Controls.Add(Me.lblValueForFast)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 16)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fast Mode"
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UcDispListView1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 255)
        Me.GroupBox2.Name = "GroupBox1"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 196)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measurement Point"
        Me.GroupBox2.Visible = True
        '
        'UcDispListView1
        '
        Me.UcDispListView1.ColHeader = New String() {"Point", "Position X(mm)", "Position Y(mm)"}
        Me.UcDispListView1.ColHeaderWidthRatio = "20,40,40"
        Me.UcDispListView1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcDispListView1.FullRawSelection = True
        Me.UcDispListView1.HideSelection = False
        Me.UcDispListView1.LabelEdit = True
        Me.UcDispListView1.LabelWrap = True
        Me.UcDispListView1.Location = New System.Drawing.Point(8, 28)
        Me.UcDispListView1.Name = "UcDispListView1"
        Me.UcDispListView1.Size = New System.Drawing.Size(295, 152)
        Me.UcDispListView1.TabIndex = 1
        Me.UcDispListView1.UseCheckBoxex = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Bias Mode"
        '
        'cbNormalFastSelect
        '
        Me.cbNormalFastSelect.FormattingEnabled = True
        Me.cbNormalFastSelect.Location = New System.Drawing.Point(106, 21)
        Me.cbNormalFastSelect.Name = "cbNormalFastSelect"
        Me.cbNormalFastSelect.Size = New System.Drawing.Size(65, 23)
        Me.cbNormalFastSelect.TabIndex = 41
        '
        'cbFastBiasMode
        '
        Me.cbFastBiasMode.FormattingEnabled = True
        Me.cbFastBiasMode.Location = New System.Drawing.Point(106, 47)
        Me.cbFastBiasMode.Name = "cbFastBiasMode"
        Me.cbFastBiasMode.Size = New System.Drawing.Size(65, 23)
        Me.cbFastBiasMode.TabIndex = 44
        '
        'tbValueForFast
        '
        Me.tbValueForFast.BackColor = System.Drawing.SystemColors.Control
        Me.tbValueForFast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbValueForFast.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbValueForFast.Location = New System.Drawing.Point(106, 76)
        Me.tbValueForFast.Name = "tbValueForFast"
        Me.tbValueForFast.Size = New System.Drawing.Size(64, 21)
        Me.tbValueForFast.TabIndex = 38
        Me.tbValueForFast.Text = "0"
        Me.tbValueForFast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblValueForFast
        '
        Me.lblValueForFast.AutoSize = True
        Me.lblValueForFast.Location = New System.Drawing.Point(172, 79)
        Me.lblValueForFast.Name = "lblValueForFast"
        Me.lblValueForFast.Size = New System.Drawing.Size(15, 15)
        Me.lblValueForFast.TabIndex = 40
        Me.lblValueForFast.Text = "V"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Measure Mode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Value for Fast"
        '
        'tbLumiCorrection
        '
        Me.tbLumiCorrection.BackColor = System.Drawing.SystemColors.Control
        Me.tbLumiCorrection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLumiCorrection.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbLumiCorrection.Location = New System.Drawing.Point(107, 205)
        Me.tbLumiCorrection.Name = "tbLumiCorrection"
        Me.tbLumiCorrection.Size = New System.Drawing.Size(60, 21)
        Me.tbLumiCorrection.TabIndex = 35
        Me.tbLumiCorrection.Text = "0"
        Me.tbLumiCorrection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLumiCorrectionUnit
        '
        Me.lblLumiCorrectionUnit.AutoSize = True
        Me.lblLumiCorrectionUnit.Location = New System.Drawing.Point(168, 209)
        Me.lblLumiCorrectionUnit.Name = "lblLumiCorrectionUnit"
        Me.lblLumiCorrectionUnit.Size = New System.Drawing.Size(16, 15)
        Me.lblLumiCorrectionUnit.TabIndex = 37
        Me.lblLumiCorrectionUnit.Text = "%"
        '
        'lblLumiCorrection
        '
        Me.lblLumiCorrection.AutoSize = True
        Me.lblLumiCorrection.Location = New System.Drawing.Point(3, 205)
        Me.lblLumiCorrection.Name = "lblLumiCorrection"
        Me.lblLumiCorrection.Size = New System.Drawing.Size(98, 15)
        Me.lblLumiCorrection.TabIndex = 36
        Me.lblLumiCorrection.Text = "Lumi Correction"
        '
        'tbCurrentLimit
        '
        Me.tbCurrentLimit.BackColor = System.Drawing.SystemColors.Control
        Me.tbCurrentLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCurrentLimit.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbCurrentLimit.Location = New System.Drawing.Point(107, 179)
        Me.tbCurrentLimit.Name = "tbCurrentLimit"
        Me.tbCurrentLimit.Size = New System.Drawing.Size(60, 21)
        Me.tbCurrentLimit.TabIndex = 32
        Me.tbCurrentLimit.Text = "0"
        Me.tbCurrentLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCurrentLimitUnit
        '
        Me.lblCurrentLimitUnit.AutoSize = True
        Me.lblCurrentLimitUnit.Location = New System.Drawing.Point(168, 183)
        Me.lblCurrentLimitUnit.Name = "lblCurrentLimitUnit"
        Me.lblCurrentLimitUnit.Size = New System.Drawing.Size(26, 15)
        Me.lblCurrentLimitUnit.TabIndex = 34
        Me.lblCurrentLimitUnit.Text = "mA"
        '
        'lblCurrentLimit
        '
        Me.lblCurrentLimit.AutoSize = True
        Me.lblCurrentLimit.Location = New System.Drawing.Point(20, 179)
        Me.lblCurrentLimit.Name = "lblCurrentLimit"
        Me.lblCurrentLimit.Size = New System.Drawing.Size(81, 15)
        Me.lblCurrentLimit.TabIndex = 33
        Me.lblCurrentLimit.Text = "Current Limit"
        '
        'tbLMeasLimit
        '
        Me.tbLMeasLimit.BackColor = System.Drawing.SystemColors.Control
        Me.tbLMeasLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLMeasLimit.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbLMeasLimit.Location = New System.Drawing.Point(107, 118)
        Me.tbLMeasLimit.Name = "tbLMeasLimit"
        Me.tbLMeasLimit.Size = New System.Drawing.Size(60, 21)
        Me.tbLMeasLimit.TabIndex = 29
        Me.tbLMeasLimit.Text = "0"
        Me.tbLMeasLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLMeasLimitUnit
        '
        Me.lblLMeasLimitUnit.AutoSize = True
        Me.lblLMeasLimitUnit.Location = New System.Drawing.Point(168, 122)
        Me.lblLMeasLimitUnit.Name = "lblLMeasLimitUnit"
        Me.lblLMeasLimitUnit.Size = New System.Drawing.Size(42, 15)
        Me.lblLMeasLimitUnit.TabIndex = 31
        Me.lblLMeasLimitUnit.Text = "cd/m2"
        '
        'lblLMeasLimit
        '
        Me.lblLMeasLimit.AutoSize = True
        Me.lblLMeasLimit.Location = New System.Drawing.Point(22, 118)
        Me.lblLMeasLimit.Name = "lblLMeasLimit"
        Me.lblLMeasLimit.Size = New System.Drawing.Size(79, 15)
        Me.lblLMeasLimit.TabIndex = 30
        Me.lblLMeasLimit.Text = "L Meas Limit"
        '
        'ucColorSetting
        '
        Me.ucColorSetting.Location = New System.Drawing.Point(13, 306)
        Me.ucColorSetting.Name = "ucColorSetting"
        Me.ucColorSetting.Setting = New M7000.ucMeasureColorList.eColor() {M7000.ucMeasureColorList.eColor._Red}
        Me.ucColorSetting.Size = New System.Drawing.Size(185, 54)
        Me.ucColorSetting.TabIndex = 9
        '
        'lblViewingAngleUnit
        '
        Me.lblViewingAngleUnit.AutoSize = True
        Me.lblViewingAngleUnit.Location = New System.Drawing.Point(168, 67)
        Me.lblViewingAngleUnit.Name = "lblViewingAngleUnit"
        Me.lblViewingAngleUnit.Size = New System.Drawing.Size(29, 15)
        Me.lblViewingAngleUnit.TabIndex = 27
        Me.lblViewingAngleUnit.Text = "Deg"
        '
        'tbViewingAngle
        '
        Me.tbViewingAngle.BackColor = System.Drawing.SystemColors.Control
        Me.tbViewingAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbViewingAngle.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbViewingAngle.Location = New System.Drawing.Point(107, 63)
        Me.tbViewingAngle.Name = "tbViewingAngle"
        Me.tbViewingAngle.Size = New System.Drawing.Size(60, 21)
        Me.tbViewingAngle.TabIndex = 21
        Me.tbViewingAngle.Text = "0"
        Me.tbViewingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBiasMode
        '
        Me.lblBiasMode.AutoSize = True
        Me.lblBiasMode.Location = New System.Drawing.Point(35, 12)
        Me.lblBiasMode.Name = "lblBiasMode"
        Me.lblBiasMode.Size = New System.Drawing.Size(66, 15)
        Me.lblBiasMode.TabIndex = 23
        Me.lblBiasMode.Text = "Bias Mode"
        '
        'lblViewingAngle
        '
        Me.lblViewingAngle.AutoSize = True
        Me.lblViewingAngle.Location = New System.Drawing.Point(16, 64)
        Me.lblViewingAngle.Name = "lblViewingAngle"
        Me.lblViewingAngle.Size = New System.Drawing.Size(87, 15)
        Me.lblViewingAngle.TabIndex = 25
        Me.lblViewingAngle.Text = "Viewing Angle"
        '
        'tbLMeasLevel
        '
        Me.tbLMeasLevel.BackColor = System.Drawing.SystemColors.Control
        Me.tbLMeasLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLMeasLevel.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbLMeasLevel.Location = New System.Drawing.Point(107, 91)
        Me.tbLMeasLevel.Name = "tbLMeasLevel"
        Me.tbLMeasLevel.Size = New System.Drawing.Size(60, 21)
        Me.tbLMeasLevel.TabIndex = 22
        Me.tbLMeasLevel.Text = "0"
        Me.tbLMeasLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbBiasMode
        '
        Me.cbBiasMode.FormattingEnabled = True
        Me.cbBiasMode.Location = New System.Drawing.Point(107, 9)
        Me.cbBiasMode.Name = "cbBiasMode"
        Me.cbBiasMode.Size = New System.Drawing.Size(60, 23)
        Me.cbBiasMode.TabIndex = 19
        '
        'lblLMeasValueUnit
        '
        Me.lblLMeasValueUnit.AutoSize = True
        Me.lblLMeasValueUnit.Location = New System.Drawing.Point(168, 95)
        Me.lblLMeasValueUnit.Name = "lblLMeasValueUnit"
        Me.lblLMeasValueUnit.Size = New System.Drawing.Size(15, 15)
        Me.lblLMeasValueUnit.TabIndex = 28
        Me.lblLMeasValueUnit.Text = "V"
        '
        'lblLMeasLevel
        '
        Me.lblLMeasLevel.AutoSize = True
        Me.lblLMeasLevel.Location = New System.Drawing.Point(20, 91)
        Me.lblLMeasLevel.Name = "lblLMeasLevel"
        Me.lblLMeasLevel.Size = New System.Drawing.Size(81, 15)
        Me.lblLMeasLevel.TabIndex = 26
        Me.lblLMeasLevel.Text = "L Meas Level"
        '
        'cbMeasureMode
        '
        Me.cbMeasureMode.FormattingEnabled = True
        Me.cbMeasureMode.Location = New System.Drawing.Point(107, 34)
        Me.cbMeasureMode.Name = "cbMeasureMode"
        Me.cbMeasureMode.Size = New System.Drawing.Size(60, 23)
        Me.cbMeasureMode.TabIndex = 20
        '
        'lblMeasMode
        '
        Me.lblMeasMode.AutoSize = True
        Me.lblMeasMode.Location = New System.Drawing.Point(12, 37)
        Me.lblMeasMode.Name = "lblMeasMode"
        Me.lblMeasMode.Size = New System.Drawing.Size(91, 15)
        Me.lblMeasMode.TabIndex = 24
        Me.lblMeasMode.Text = "Measure Mode"
        '
        'ucSweepSetting
        '
        Me.ucSweepSetting.AutoScroll = True
        Me.ucSweepSetting.Location = New System.Drawing.Point(7, 12)
        Me.ucSweepSetting.MainTitle = "Sweep Settings"
        Me.ucSweepSetting.MaximumSize = New System.Drawing.Size(289, 432)
        Me.ucSweepSetting.MinimumSize = New System.Drawing.Size(226, 217)
        Me.ucSweepSetting.Name = "ucSweepSetting"
        Me.ucSweepSetting.Size = New System.Drawing.Size(235, 310)
        Me.ucSweepSetting.SweepType = M7000.ucSweepSetting.eSweepType._Standard
        Me.ucSweepSetting.TabIndex = 4
        '
        'tbDetail
        '
        Me.tbDetail.BackColor = System.Drawing.SystemColors.Control
        Me.tbDetail.Controls.Add(Me.gbDetailSettings)
        Me.tbDetail.Location = New System.Drawing.Point(4, 24)
        Me.tbDetail.Name = "tbDetail"
        Me.tbDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDetail.Size = New System.Drawing.Size(497, 350)
        Me.tbDetail.TabIndex = 1
        Me.tbDetail.Text = "Detail"
        '
        'gbDetailSettings
        '
        Me.gbDetailSettings.Controls.Add(Me.Label2)
        Me.gbDetailSettings.Controls.Add(Me.Label9)
        Me.gbDetailSettings.Controls.Add(Me.cbSweepMode)
        Me.gbDetailSettings.Controls.Add(Me.tbCycleDelay)
        Me.gbDetailSettings.Controls.Add(Me.cbDelayState)
        Me.gbDetailSettings.Controls.Add(Me.Label10)
        Me.gbDetailSettings.Controls.Add(Me.Label15)
        Me.gbDetailSettings.Controls.Add(Me.tbMeasureDelay)
        Me.gbDetailSettings.Controls.Add(Me.cbSweepMethod)
        Me.gbDetailSettings.Controls.Add(Me.Label16)
        Me.gbDetailSettings.Controls.Add(Me.tbOffsetBias)
        Me.gbDetailSettings.Controls.Add(Me.Label5)
        Me.gbDetailSettings.Controls.Add(Me.Label14)
        Me.gbDetailSettings.Controls.Add(Me.Label13)
        Me.gbDetailSettings.Controls.Add(Me.Label11)
        Me.gbDetailSettings.Controls.Add(Me.Label12)
        Me.gbDetailSettings.Controls.Add(Me.tbAverage)
        Me.gbDetailSettings.Controls.Add(Me.lblOffsetBiasValueUnit)
        Me.gbDetailSettings.Controls.Add(Me.Label8)
        Me.gbDetailSettings.Controls.Add(Me.tbSweepDelay)
        Me.gbDetailSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetailSettings.Location = New System.Drawing.Point(3, 3)
        Me.gbDetailSettings.Name = "gbDetailSettings"
        Me.gbDetailSettings.Size = New System.Drawing.Size(491, 344)
        Me.gbDetailSettings.TabIndex = 31
        Me.gbDetailSettings.TabStop = False
        Me.gbDetailSettings.Text = "Detail Parameter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Sweep Mode"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(360, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Sec"
        '
        'cbSweepMode
        '
        Me.cbSweepMode.FormattingEnabled = True
        Me.cbSweepMode.Location = New System.Drawing.Point(101, 25)
        Me.cbSweepMode.Name = "cbSweepMode"
        Me.cbSweepMode.Size = New System.Drawing.Size(73, 23)
        Me.cbSweepMode.TabIndex = 26
        '
        'tbCycleDelay
        '
        Me.tbCycleDelay.BackColor = System.Drawing.SystemColors.Control
        Me.tbCycleDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCycleDelay.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbCycleDelay.Location = New System.Drawing.Point(98, 147)
        Me.tbCycleDelay.Name = "tbCycleDelay"
        Me.tbCycleDelay.Size = New System.Drawing.Size(56, 21)
        Me.tbCycleDelay.TabIndex = 19
        Me.tbCycleDelay.Text = "1"
        Me.tbCycleDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCycleDelay.Visible = False
        '
        'cbDelayState
        '
        Me.cbDelayState.FormattingEnabled = True
        Me.cbDelayState.Location = New System.Drawing.Point(101, 53)
        Me.cbDelayState.Name = "cbDelayState"
        Me.cbDelayState.Size = New System.Drawing.Size(72, 23)
        Me.cbDelayState.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(205, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 15)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "MeasureDelay"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(27, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "DelayState"
        '
        'tbMeasureDelay
        '
        Me.tbMeasureDelay.BackColor = System.Drawing.SystemColors.Control
        Me.tbMeasureDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbMeasureDelay.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbMeasureDelay.Location = New System.Drawing.Point(299, 95)
        Me.tbMeasureDelay.Name = "tbMeasureDelay"
        Me.tbMeasureDelay.Size = New System.Drawing.Size(56, 21)
        Me.tbMeasureDelay.TabIndex = 16
        Me.tbMeasureDelay.Text = "0.1"
        Me.tbMeasureDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbSweepMethod
        '
        Me.cbSweepMethod.FormattingEnabled = True
        Me.cbSweepMethod.Location = New System.Drawing.Point(280, 25)
        Me.cbSweepMethod.Name = "cbSweepMethod"
        Me.cbSweepMethod.Size = New System.Drawing.Size(73, 23)
        Me.cbSweepMethod.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(41, 98)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Average"
        '
        'tbOffsetBias
        '
        Me.tbOffsetBias.BackColor = System.Drawing.SystemColors.Control
        Me.tbOffsetBias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbOffsetBias.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbOffsetBias.Location = New System.Drawing.Point(299, 121)
        Me.tbOffsetBias.Name = "tbOffsetBias"
        Me.tbOffsetBias.Size = New System.Drawing.Size(56, 21)
        Me.tbOffsetBias.TabIndex = 13
        Me.tbOffsetBias.Text = "1"
        Me.tbOffsetBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(184, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Sweep Method"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 124)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "SweepDelay"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(159, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 15)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Sec"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(159, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Sec"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 15)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "CycleDelay"
        Me.Label12.Visible = False
        '
        'tbAverage
        '
        Me.tbAverage.BackColor = System.Drawing.SystemColors.Control
        Me.tbAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAverage.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbAverage.Location = New System.Drawing.Point(98, 95)
        Me.tbAverage.Name = "tbAverage"
        Me.tbAverage.Size = New System.Drawing.Size(56, 21)
        Me.tbAverage.TabIndex = 25
        Me.tbAverage.Text = "1"
        Me.tbAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOffsetBiasValueUnit
        '
        Me.lblOffsetBiasValueUnit.AutoSize = True
        Me.lblOffsetBiasValueUnit.Location = New System.Drawing.Point(360, 124)
        Me.lblOffsetBiasValueUnit.Name = "lblOffsetBiasValueUnit"
        Me.lblOffsetBiasValueUnit.Size = New System.Drawing.Size(15, 15)
        Me.lblOffsetBiasValueUnit.TabIndex = 14
        Me.lblOffsetBiasValueUnit.Text = "V"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "OffsetBias"
        '
        'tbSweepDelay
        '
        Me.tbSweepDelay.BackColor = System.Drawing.SystemColors.Control
        Me.tbSweepDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSweepDelay.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSweepDelay.Location = New System.Drawing.Point(98, 121)
        Me.tbSweepDelay.Name = "tbSweepDelay"
        Me.tbSweepDelay.Size = New System.Drawing.Size(56, 21)
        Me.tbSweepDelay.TabIndex = 22
        Me.tbSweepDelay.Text = "1"
        Me.tbSweepDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tlpPanel2
        '
        Me.tlpPanel2.ColumnCount = 4
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.Controls.Add(Me.btnMeasPoint, 3, 1)
        Me.tlpPanel2.Controls.Add(Me.btnEdit, 2, 1)
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Controls.Add(Me.btnADD, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Location = New System.Drawing.Point(7, 17)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(515, 492)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.BackColor = System.Drawing.Color.Silver
        Me.btnMeasPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeasPoint.Location = New System.Drawing.Point(387, 459)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(93, 30)
        Me.btnMeasPoint.TabIndex = 12
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = False
        Me.btnMeasPoint.Visible = True
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.Silver
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(259, 459)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(63, 30)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        Me.btnEdit.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Silver
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Location = New System.Drawing.Point(131, 459)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(63, 30)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnADD
        '
        Me.btnADD.BackColor = System.Drawing.Color.Silver
        Me.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD.Location = New System.Drawing.Point(3, 459)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(63, 30)
        Me.btnADD.TabIndex = 9
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(464, 413)
        Me.Panel1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(7, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ucDispRGBSignal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSweepLine)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ucDispKeithley)
        Me.SplitContainer1.Size = New System.Drawing.Size(446, 390)
        Me.SplitContainer1.SplitterDistance = 60
        Me.SplitContainer1.TabIndex = 1
        '
        'ucDispRGBSignal
        '
        Me.ucDispRGBSignal.Location = New System.Drawing.Point(145, 8)
        Me.ucDispRGBSignal.Name = "ucDispRGBSignal"
        Me.ucDispRGBSignal.Size = New System.Drawing.Size(298, 49)
        Me.ucDispRGBSignal.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 15)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "SweepLine"
        '
        'cbSweepLine
        '
        Me.cbSweepLine.FormattingEnabled = True
        Me.cbSweepLine.Location = New System.Drawing.Point(78, 22)
        Me.cbSweepLine.Name = "cbSweepLine"
        Me.cbSweepLine.Size = New System.Drawing.Size(60, 23)
        Me.cbSweepLine.TabIndex = 6
        '
        'ucDispKeithley
        '
        Me.ucDispKeithley.AutoScroll = True
        Me.ucDispKeithley.Location = New System.Drawing.Point(3, 3)
        Me.ucDispKeithley.Name = "ucDispKeithley"
        Me.ucDispKeithley.Size = New System.Drawing.Size(413, 319)
        Me.ucDispKeithley.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Bias Mode :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(257, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 12)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "SweepType  :"
        '
        'ucDispRcpIVLSweep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpIVLSweep"
        Me.Size = New System.Drawing.Size(572, 975)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbIVLSweepCommon.ResumeLayout(False)
        Me.tcCommon.ResumeLayout(False)
        Me.tbStandard.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.tbDetail.ResumeLayout(False)
        Me.gbDetailSettings.ResumeLayout(False)
        Me.gbDetailSettings.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents gbIVLSweepCommon As System.Windows.Forms.GroupBox
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbSweepMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSweepMode As System.Windows.Forms.ComboBox
    Friend WithEvents tbAverage As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbSweepDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbCycleDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblOffsetBiasValueUnit As System.Windows.Forms.Label
    Friend WithEvents tbOffsetBias As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbDelayState As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbSweepLine As System.Windows.Forms.ComboBox
    Friend WithEvents tcCommon As System.Windows.Forms.TabControl
    Friend WithEvents tbDetail As System.Windows.Forms.TabPage
    Friend WithEvents gbDetailSettings As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ucDispRGBSignal As M7000.ucPanelRGB
    Friend WithEvents ucDispKeithley As CSMULib.ucKeithleySMUSettings
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbStandard As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ucColorSetting As M7000.ucMeasureColorList
    Friend WithEvents lblViewingAngleUnit As System.Windows.Forms.Label
    Friend WithEvents tbViewingAngle As System.Windows.Forms.TextBox
    Friend WithEvents lblBiasMode As System.Windows.Forms.Label
    Friend WithEvents lblViewingAngle As System.Windows.Forms.Label
    Friend WithEvents tbLMeasLevel As System.Windows.Forms.TextBox
    Friend WithEvents cbBiasMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblLMeasValueUnit As System.Windows.Forms.Label
    Friend WithEvents lblLMeasLevel As System.Windows.Forms.Label
    Friend WithEvents cbMeasureMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblMeasMode As System.Windows.Forms.Label
    Friend WithEvents ucSweepSetting As M7000.ucSweepSetting
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbCurrentLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentLimitUnit As System.Windows.Forms.Label
    Friend WithEvents lblCurrentLimit As System.Windows.Forms.Label
    Friend WithEvents tbLMeasLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblLMeasLimitUnit As System.Windows.Forms.Label
    Friend WithEvents lblLMeasLimit As System.Windows.Forms.Label
    Friend WithEvents tbLumiCorrection As System.Windows.Forms.TextBox
    Friend WithEvents lblLumiCorrectionUnit As System.Windows.Forms.Label
    Friend WithEvents lblLumiCorrection As System.Windows.Forms.Label
    Friend WithEvents tbValueForFast As System.Windows.Forms.TextBox
    Friend WithEvents lblValueForFast As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbNormalFastSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFastBiasMode As System.Windows.Forms.ComboBox
    Friend WithEvents chkBiasInvert As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAnd As System.Windows.Forms.CheckBox
    Protected WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents UcDispListView1 As M7000.ucDispListView

End Class
