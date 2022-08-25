<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpLifetimeAndIVLSweep
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
        Me.gbLifetimeAndIVLSweepCommon = New System.Windows.Forms.GroupBox()
        Me.tcCommon = New System.Windows.Forms.TabControl()
        Me.tbIVL_Standard = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chkFirstIVLSweep = New System.Windows.Forms.CheckBox()
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
        Me.tbLifetime = New System.Windows.Forms.TabPage()
        Me.ucTestIVLMeasParam = New M7000.ucTestEndParam()
        Me.ucMeasureIntervalSetting = New M7000.ucMeasureIntervalSetting()
        Me.ucRefPDSetting = New M7000.ucRefPDSetting()
        Me.ucTestEndParam = New M7000.ucTestEndParam()
        Me.gbLifeTimeEndSourceSetting = New System.Windows.Forms.GroupBox()
        Me.rbLifeTimeEndBiasON = New System.Windows.Forms.RadioButton()
        Me.rbLifeTimeEndBiasOFF = New System.Windows.Forms.RadioButton()
        Me.gbStressMode = New System.Windows.Forms.GroupBox()
        Me.rbStress = New System.Windows.Forms.RadioButton()
        Me.rbNoStress = New System.Windows.Forms.RadioButton()
        Me.tbIVL_Detail = New System.Windows.Forms.TabPage()
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
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbComponent = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpIVL = New System.Windows.Forms.TabPage()
        Me.ucDispKeithley = New CSMULib.ucKeithleySMUSettings()
        Me.tpLifetime = New System.Windows.Forms.TabPage()
        Me.ucDispM6000 = New M7000.ucDispCellLifetime()
        Me.tbCurrentLimit = New System.Windows.Forms.TextBox()
        Me.lblCurrentLimitUnit = New System.Windows.Forms.Label()
        Me.lblCurrentLimit = New System.Windows.Forms.Label()
        Me.tbLMeasLimit = New System.Windows.Forms.TextBox()
        Me.lblLMeasLimitUnit = New System.Windows.Forms.Label()
        Me.lblLMeasLimit = New System.Windows.Forms.Label()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.gbLifetimeAndIVLSweepCommon.SuspendLayout()
        Me.tcCommon.SuspendLayout()
        Me.tbIVL_Standard.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tbLifetime.SuspendLayout()
        Me.gbLifeTimeEndSourceSetting.SuspendLayout()
        Me.gbStressMode.SuspendLayout()
        Me.tbIVL_Detail.SuspendLayout()
        Me.gbDetailSettings.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbComponent.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpIVL.SuspendLayout()
        Me.tpLifetime.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.Location = New System.Drawing.Point(16, 13)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel1.Controls.Add(Me.gbLifetimeAndIVLSweepCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(612, 1062)
        Me.spContainer.SplitterDistance = 395
        Me.spContainer.TabIndex = 2
        '
        'gbLifetimeAndIVLSweepCommon
        '
        Me.gbLifetimeAndIVLSweepCommon.Controls.Add(Me.tcCommon)
        Me.gbLifetimeAndIVLSweepCommon.Location = New System.Drawing.Point(11, 9)
        Me.gbLifetimeAndIVLSweepCommon.MinimumSize = New System.Drawing.Size(513, 308)
        Me.gbLifetimeAndIVLSweepCommon.Name = "gbLifetimeAndIVLSweepCommon"
        Me.gbLifetimeAndIVLSweepCommon.Size = New System.Drawing.Size(578, 364)
        Me.gbLifetimeAndIVLSweepCommon.TabIndex = 3
        Me.gbLifetimeAndIVLSweepCommon.TabStop = False
        Me.gbLifetimeAndIVLSweepCommon.Text = "Common"
        '
        'tcCommon
        '
        Me.tcCommon.Controls.Add(Me.tbIVL_Standard)
        Me.tcCommon.Controls.Add(Me.tbLifetime)
        Me.tcCommon.Controls.Add(Me.tbIVL_Detail)
        Me.tcCommon.Location = New System.Drawing.Point(8, 16)
        Me.tcCommon.Name = "tcCommon"
        Me.tcCommon.SelectedIndex = 0
        Me.tcCommon.Size = New System.Drawing.Size(562, 341)
        Me.tcCommon.TabIndex = 35
        '
        'tbIVL_Standard
        '
        Me.tbIVL_Standard.BackColor = System.Drawing.SystemColors.Control
        Me.tbIVL_Standard.Controls.Add(Me.SplitContainer2)
        Me.tbIVL_Standard.Location = New System.Drawing.Point(4, 22)
        Me.tbIVL_Standard.Name = "tbIVL_Standard"
        Me.tbIVL_Standard.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIVL_Standard.Size = New System.Drawing.Size(554, 315)
        Me.tbIVL_Standard.TabIndex = 0
        Me.tbIVL_Standard.Text = "IVL(Standard)"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbCurrentLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCurrentLimitUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCurrentLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbLMeasLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasLimitUnit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblLMeasLimit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkFirstIVLSweep)
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
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.ucSweepSetting)
        Me.SplitContainer2.Size = New System.Drawing.Size(548, 309)
        Me.SplitContainer2.SplitterDistance = 257
        Me.SplitContainer2.TabIndex = 0
        '
        'chkFirstIVLSweep
        '
        Me.chkFirstIVLSweep.AutoSize = True
        Me.chkFirstIVLSweep.Location = New System.Drawing.Point(116, 163)
        Me.chkFirstIVLSweep.Name = "chkFirstIVLSweep"
        Me.chkFirstIVLSweep.Size = New System.Drawing.Size(105, 16)
        Me.chkFirstIVLSweep.TabIndex = 29
        Me.chkFirstIVLSweep.Text = "FirstIVLSweep"
        Me.chkFirstIVLSweep.UseVisualStyleBackColor = True
        '
        'ucColorSetting
        '
        Me.ucColorSetting.Location = New System.Drawing.Point(15, 185)
        Me.ucColorSetting.Name = "ucColorSetting"
        Me.ucColorSetting.Setting = New M7000.ucMeasureColorList.eColor() {M7000.ucMeasureColorList.eColor._Red}
        Me.ucColorSetting.Size = New System.Drawing.Size(216, 120)
        Me.ucColorSetting.TabIndex = 9
        '
        'lblViewingAngleUnit
        '
        Me.lblViewingAngleUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblViewingAngleUnit.AutoSize = True
        Me.lblViewingAngleUnit.Location = New System.Drawing.Point(204, 68)
        Me.lblViewingAngleUnit.Name = "lblViewingAngleUnit"
        Me.lblViewingAngleUnit.Size = New System.Drawing.Size(27, 12)
        Me.lblViewingAngleUnit.TabIndex = 27
        Me.lblViewingAngleUnit.Text = "Deg"
        '
        'tbViewingAngle
        '
        Me.tbViewingAngle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbViewingAngle.Location = New System.Drawing.Point(113, 64)
        Me.tbViewingAngle.Name = "tbViewingAngle"
        Me.tbViewingAngle.Size = New System.Drawing.Size(90, 21)
        Me.tbViewingAngle.TabIndex = 21
        Me.tbViewingAngle.Text = "0"
        Me.tbViewingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBiasMode
        '
        Me.lblBiasMode.AutoSize = True
        Me.lblBiasMode.Location = New System.Drawing.Point(38, 15)
        Me.lblBiasMode.Name = "lblBiasMode"
        Me.lblBiasMode.Size = New System.Drawing.Size(74, 12)
        Me.lblBiasMode.TabIndex = 23
        Me.lblBiasMode.Text = "Bias Mode :"
        '
        'lblViewingAngle
        '
        Me.lblViewingAngle.AutoSize = True
        Me.lblViewingAngle.Location = New System.Drawing.Point(18, 68)
        Me.lblViewingAngle.Name = "lblViewingAngle"
        Me.lblViewingAngle.Size = New System.Drawing.Size(94, 12)
        Me.lblViewingAngle.TabIndex = 25
        Me.lblViewingAngle.Text = "Viewing Angle :"
        '
        'tbLMeasLevel
        '
        Me.tbLMeasLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLMeasLevel.Location = New System.Drawing.Point(113, 92)
        Me.tbLMeasLevel.Name = "tbLMeasLevel"
        Me.tbLMeasLevel.Size = New System.Drawing.Size(90, 21)
        Me.tbLMeasLevel.TabIndex = 22
        Me.tbLMeasLevel.Text = "0"
        Me.tbLMeasLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbBiasMode
        '
        Me.cbBiasMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBiasMode.FormattingEnabled = True
        Me.cbBiasMode.Location = New System.Drawing.Point(113, 12)
        Me.cbBiasMode.Name = "cbBiasMode"
        Me.cbBiasMode.Size = New System.Drawing.Size(90, 20)
        Me.cbBiasMode.TabIndex = 19
        '
        'lblLMeasValueUnit
        '
        Me.lblLMeasValueUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLMeasValueUnit.AutoSize = True
        Me.lblLMeasValueUnit.Location = New System.Drawing.Point(204, 96)
        Me.lblLMeasValueUnit.Name = "lblLMeasValueUnit"
        Me.lblLMeasValueUnit.Size = New System.Drawing.Size(13, 12)
        Me.lblLMeasValueUnit.TabIndex = 28
        Me.lblLMeasValueUnit.Text = "V"
        '
        'lblLMeasLevel
        '
        Me.lblLMeasLevel.AutoSize = True
        Me.lblLMeasLevel.Location = New System.Drawing.Point(22, 95)
        Me.lblLMeasLevel.Name = "lblLMeasLevel"
        Me.lblLMeasLevel.Size = New System.Drawing.Size(90, 12)
        Me.lblLMeasLevel.TabIndex = 26
        Me.lblLMeasLevel.Text = "L Meas Level :"
        '
        'cbMeasureMode
        '
        Me.cbMeasureMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMeasureMode.FormattingEnabled = True
        Me.cbMeasureMode.Location = New System.Drawing.Point(113, 38)
        Me.cbMeasureMode.Name = "cbMeasureMode"
        Me.cbMeasureMode.Size = New System.Drawing.Size(90, 20)
        Me.cbMeasureMode.TabIndex = 20
        '
        'lblMeasMode
        '
        Me.lblMeasMode.AutoSize = True
        Me.lblMeasMode.Location = New System.Drawing.Point(13, 41)
        Me.lblMeasMode.Name = "lblMeasMode"
        Me.lblMeasMode.Size = New System.Drawing.Size(99, 12)
        Me.lblMeasMode.TabIndex = 24
        Me.lblMeasMode.Text = "Measure Mode :"
        '
        'ucSweepSetting
        '
        Me.ucSweepSetting.AutoScroll = True
        Me.ucSweepSetting.Location = New System.Drawing.Point(7, 15)
        Me.ucSweepSetting.MainTitle = "Sweep Settings"
        Me.ucSweepSetting.MaximumSize = New System.Drawing.Size(337, 399)
        Me.ucSweepSetting.MinimumSize = New System.Drawing.Size(264, 200)
        Me.ucSweepSetting.Name = "ucSweepSetting"
        Me.ucSweepSetting.Size = New System.Drawing.Size(288, 290)
        Me.ucSweepSetting.SweepType = M7000.ucSweepSetting.eSweepType._Standard
        Me.ucSweepSetting.TabIndex = 4
        '
        'tbLifetime
        '
        Me.tbLifetime.BackColor = System.Drawing.SystemColors.Control
        Me.tbLifetime.Controls.Add(Me.ucTestIVLMeasParam)
        Me.tbLifetime.Controls.Add(Me.ucMeasureIntervalSetting)
        Me.tbLifetime.Controls.Add(Me.ucRefPDSetting)
        Me.tbLifetime.Controls.Add(Me.ucTestEndParam)
        Me.tbLifetime.Controls.Add(Me.gbLifeTimeEndSourceSetting)
        Me.tbLifetime.Controls.Add(Me.gbStressMode)
        Me.tbLifetime.Location = New System.Drawing.Point(4, 22)
        Me.tbLifetime.Name = "tbLifetime"
        Me.tbLifetime.Padding = New System.Windows.Forms.Padding(3)
        Me.tbLifetime.Size = New System.Drawing.Size(554, 315)
        Me.tbLifetime.TabIndex = 2
        Me.tbLifetime.Text = "Lifetime"
        '
        'ucTestIVLMeasParam
        '
        Me.ucTestIVLMeasParam.Location = New System.Drawing.Point(321, 97)
        Me.ucTestIVLMeasParam.Name = "ucTestIVLMeasParam"
        Me.ucTestIVLMeasParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestIVLMeasParam.Size = New System.Drawing.Size(220, 192)
        Me.ucTestIVLMeasParam.TabIndex = 14
        Me.ucTestIVLMeasParam.Title = "IVL Sweep Meas. Conditions"
        '
        'ucMeasureIntervalSetting
        '
        Me.ucMeasureIntervalSetting.Location = New System.Drawing.Point(6, 97)
        Me.ucMeasureIntervalSetting.Name = "ucMeasureIntervalSetting"
        Me.ucMeasureIntervalSetting.Setting = New M7000.ucMeasureIntervalSetting.sSetTime(-1) {}
        Me.ucMeasureIntervalSetting.Size = New System.Drawing.Size(228, 192)
        Me.ucMeasureIntervalSetting.TabIndex = 12
        '
        'ucRefPDSetting
        '
        Me.ucRefPDSetting.Location = New System.Drawing.Point(134, 8)
        Me.ucRefPDSetting.Name = "ucRefPDSetting"
        Me.ucRefPDSetting.Size = New System.Drawing.Size(209, 81)
        Me.ucRefPDSetting.TabIndex = 10
        '
        'ucTestEndParam
        '
        Me.ucTestEndParam.Location = New System.Drawing.Point(240, 97)
        Me.ucTestEndParam.Name = "ucTestEndParam"
        Me.ucTestEndParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestEndParam.Size = New System.Drawing.Size(220, 192)
        Me.ucTestEndParam.TabIndex = 13
        Me.ucTestEndParam.Title = "End Conditions"
        '
        'gbLifeTimeEndSourceSetting
        '
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasON)
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasOFF)
        Me.gbLifeTimeEndSourceSetting.Location = New System.Drawing.Point(357, 8)
        Me.gbLifeTimeEndSourceSetting.Name = "gbLifeTimeEndSourceSetting"
        Me.gbLifeTimeEndSourceSetting.Size = New System.Drawing.Size(118, 81)
        Me.gbLifeTimeEndSourceSetting.TabIndex = 11
        Me.gbLifeTimeEndSourceSetting.TabStop = False
        Me.gbLifeTimeEndSourceSetting.Text = "종료 동작"
        '
        'rbLifeTimeEndBiasON
        '
        Me.rbLifeTimeEndBiasON.AutoSize = True
        Me.rbLifeTimeEndBiasON.Location = New System.Drawing.Point(19, 47)
        Me.rbLifeTimeEndBiasON.Name = "rbLifeTimeEndBiasON"
        Me.rbLifeTimeEndBiasON.Size = New System.Drawing.Size(70, 16)
        Me.rbLifeTimeEndBiasON.TabIndex = 6
        Me.rbLifeTimeEndBiasON.Text = "Bias ON"
        Me.rbLifeTimeEndBiasON.UseVisualStyleBackColor = True
        '
        'rbLifeTimeEndBiasOFF
        '
        Me.rbLifeTimeEndBiasOFF.AutoSize = True
        Me.rbLifeTimeEndBiasOFF.Checked = True
        Me.rbLifeTimeEndBiasOFF.Location = New System.Drawing.Point(19, 22)
        Me.rbLifeTimeEndBiasOFF.Name = "rbLifeTimeEndBiasOFF"
        Me.rbLifeTimeEndBiasOFF.Size = New System.Drawing.Size(75, 16)
        Me.rbLifeTimeEndBiasOFF.TabIndex = 5
        Me.rbLifeTimeEndBiasOFF.TabStop = True
        Me.rbLifeTimeEndBiasOFF.Text = "Bias OFF"
        Me.rbLifeTimeEndBiasOFF.UseVisualStyleBackColor = True
        '
        'gbStressMode
        '
        Me.gbStressMode.Controls.Add(Me.rbStress)
        Me.gbStressMode.Controls.Add(Me.rbNoStress)
        Me.gbStressMode.Location = New System.Drawing.Point(6, 8)
        Me.gbStressMode.Name = "gbStressMode"
        Me.gbStressMode.Size = New System.Drawing.Size(122, 81)
        Me.gbStressMode.TabIndex = 9
        Me.gbStressMode.TabStop = False
        Me.gbStressMode.Text = "MODE"
        '
        'rbStress
        '
        Me.rbStress.AutoSize = True
        Me.rbStress.Checked = True
        Me.rbStress.Location = New System.Drawing.Point(20, 47)
        Me.rbStress.Name = "rbStress"
        Me.rbStress.Size = New System.Drawing.Size(82, 16)
        Me.rbStress.TabIndex = 2
        Me.rbStress.TabStop = True
        Me.rbStress.Text = "동작(Bias)"
        Me.rbStress.UseVisualStyleBackColor = True
        '
        'rbNoStress
        '
        Me.rbNoStress.AutoSize = True
        Me.rbNoStress.Location = New System.Drawing.Point(20, 22)
        Me.rbNoStress.Name = "rbNoStress"
        Me.rbNoStress.Size = New System.Drawing.Size(98, 16)
        Me.rbNoStress.TabIndex = 1
        Me.rbNoStress.Text = "보관(NoBias)"
        Me.rbNoStress.UseVisualStyleBackColor = True
        '
        'tbIVL_Detail
        '
        Me.tbIVL_Detail.BackColor = System.Drawing.SystemColors.Control
        Me.tbIVL_Detail.Controls.Add(Me.gbDetailSettings)
        Me.tbIVL_Detail.Location = New System.Drawing.Point(4, 22)
        Me.tbIVL_Detail.Name = "tbIVL_Detail"
        Me.tbIVL_Detail.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIVL_Detail.Size = New System.Drawing.Size(554, 315)
        Me.tbIVL_Detail.TabIndex = 1
        Me.tbIVL_Detail.Text = "IVL(Detail)"
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
        Me.gbDetailSettings.Size = New System.Drawing.Size(548, 309)
        Me.gbDetailSettings.TabIndex = 31
        Me.gbDetailSettings.TabStop = False
        Me.gbDetailSettings.Text = "Detail Parameter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Sweep Mode :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(390, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Sec"
        '
        'cbSweepMode
        '
        Me.cbSweepMode.FormattingEnabled = True
        Me.cbSweepMode.Location = New System.Drawing.Point(114, 23)
        Me.cbSweepMode.Name = "cbSweepMode"
        Me.cbSweepMode.Size = New System.Drawing.Size(84, 20)
        Me.cbSweepMode.TabIndex = 26
        '
        'tbCycleDelay
        '
        Me.tbCycleDelay.Location = New System.Drawing.Point(114, 135)
        Me.tbCycleDelay.Name = "tbCycleDelay"
        Me.tbCycleDelay.Size = New System.Drawing.Size(65, 21)
        Me.tbCycleDelay.TabIndex = 19
        Me.tbCycleDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCycleDelay.Visible = False
        '
        'cbDelayState
        '
        Me.cbDelayState.FormattingEnabled = True
        Me.cbDelayState.Location = New System.Drawing.Point(114, 49)
        Me.cbDelayState.Name = "cbDelayState"
        Me.cbDelayState.Size = New System.Drawing.Size(83, 20)
        Me.cbDelayState.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(218, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 12)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "MeasureDelay :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 12)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "DelayState  :"
        '
        'tbMeasureDelay
        '
        Me.tbMeasureDelay.Location = New System.Drawing.Point(319, 87)
        Me.tbMeasureDelay.Name = "tbMeasureDelay"
        Me.tbMeasureDelay.Size = New System.Drawing.Size(65, 21)
        Me.tbMeasureDelay.TabIndex = 16
        Me.tbMeasureDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbSweepMethod
        '
        Me.cbSweepMethod.FormattingEnabled = True
        Me.cbSweepMethod.Location = New System.Drawing.Point(319, 23)
        Me.cbSweepMethod.Name = "cbSweepMethod"
        Me.cbSweepMethod.Size = New System.Drawing.Size(84, 20)
        Me.cbSweepMethod.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(49, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 12)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Average :"
        '
        'tbOffsetBias
        '
        Me.tbOffsetBias.Location = New System.Drawing.Point(319, 111)
        Me.tbOffsetBias.Name = "tbOffsetBias"
        Me.tbOffsetBias.Size = New System.Drawing.Size(65, 21)
        Me.tbOffsetBias.TabIndex = 13
        Me.tbOffsetBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(215, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Sweep Method :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 12)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "SweepDelay :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(185, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Sec"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(185, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Sec"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 12)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "CycleDelay :"
        Me.Label12.Visible = False
        '
        'tbAverage
        '
        Me.tbAverage.Location = New System.Drawing.Point(114, 87)
        Me.tbAverage.Name = "tbAverage"
        Me.tbAverage.Size = New System.Drawing.Size(65, 21)
        Me.tbAverage.TabIndex = 25
        Me.tbAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOffsetBiasValueUnit
        '
        Me.lblOffsetBiasValueUnit.AutoSize = True
        Me.lblOffsetBiasValueUnit.Location = New System.Drawing.Point(390, 114)
        Me.lblOffsetBiasValueUnit.Name = "lblOffsetBiasValueUnit"
        Me.lblOffsetBiasValueUnit.Size = New System.Drawing.Size(13, 12)
        Me.lblOffsetBiasValueUnit.TabIndex = 14
        Me.lblOffsetBiasValueUnit.Text = "V"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(243, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "OffsetBias :"
        '
        'tbSweepDelay
        '
        Me.tbSweepDelay.Location = New System.Drawing.Point(114, 111)
        Me.tbSweepDelay.Name = "tbSweepDelay"
        Me.tbSweepDelay.Size = New System.Drawing.Size(65, 21)
        Me.tbSweepDelay.TabIndex = 22
        Me.tbSweepDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tlpPanel2
        '
        Me.tlpPanel2.BackColor = System.Drawing.Color.Transparent
        Me.tlpPanel2.ColumnCount = 4
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.Controls.Add(Me.btnMeasPoint, 3, 1)
        Me.tlpPanel2.Controls.Add(Me.btnEdit, 2, 1)
        Me.tlpPanel2.Controls.Add(Me.btnADD, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Location = New System.Drawing.Point(8, 16)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(563, 454)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Location = New System.Drawing.Point(423, 406)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(108, 36)
        Me.btnMeasPoint.TabIndex = 13
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(283, 406)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(73, 36)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(3, 406)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(73, 36)
        Me.btnADD.TabIndex = 10
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(143, 406)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(73, 36)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.gbComponent)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 350)
        Me.Panel1.TabIndex = 9
        '
        'gbComponent
        '
        Me.gbComponent.Controls.Add(Me.TabControl1)
        Me.gbComponent.Location = New System.Drawing.Point(11, 11)
        Me.gbComponent.MinimumSize = New System.Drawing.Size(513, 308)
        Me.gbComponent.Name = "gbComponent"
        Me.gbComponent.Size = New System.Drawing.Size(517, 326)
        Me.gbComponent.TabIndex = 4
        Me.gbComponent.TabStop = False
        Me.gbComponent.Text = "Component"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpIVL)
        Me.TabControl1.Controls.Add(Me.tpLifetime)
        Me.TabControl1.Location = New System.Drawing.Point(8, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(492, 304)
        Me.TabControl1.TabIndex = 35
        '
        'tpIVL
        '
        Me.tpIVL.BackColor = System.Drawing.SystemColors.Control
        Me.tpIVL.Controls.Add(Me.ucDispKeithley)
        Me.tpIVL.Location = New System.Drawing.Point(4, 22)
        Me.tpIVL.Name = "tpIVL"
        Me.tpIVL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIVL.Size = New System.Drawing.Size(484, 278)
        Me.tpIVL.TabIndex = 0
        Me.tpIVL.Text = "IVL"
        '
        'ucDispKeithley
        '
        Me.ucDispKeithley.AutoScroll = True
        Me.ucDispKeithley.Location = New System.Drawing.Point(20, 10)
        Me.ucDispKeithley.Name = "ucDispKeithley"
        Me.ucDispKeithley.Size = New System.Drawing.Size(453, 258)
        Me.ucDispKeithley.TabIndex = 5
        '
        'tpLifetime
        '
        Me.tpLifetime.BackColor = System.Drawing.SystemColors.Control
        Me.tpLifetime.Controls.Add(Me.ucDispM6000)
        Me.tpLifetime.Location = New System.Drawing.Point(4, 22)
        Me.tpLifetime.Name = "tpLifetime"
        Me.tpLifetime.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLifetime.Size = New System.Drawing.Size(484, 278)
        Me.tpLifetime.TabIndex = 2
        Me.tpLifetime.Text = "Lifetime"
        '
        'ucDispM6000
        '
        Me.ucDispM6000.BackColor = System.Drawing.Color.Transparent
        Me.ucDispM6000.Location = New System.Drawing.Point(16, 6)
        Me.ucDispM6000.MinimumSize = New System.Drawing.Size(190, 260)
        Me.ucDispM6000.Name = "ucDispM6000"
        Me.ucDispM6000.Size = New System.Drawing.Size(228, 282)
        Me.ucDispM6000.TabIndex = 0
        Me.ucDispM6000.Title = "Source Settings"
        Me.ucDispM6000.ViewMode = M7000.ucDispCellLifetime.eViewMode.eAllView
        '
        'tbCurrentLimit
        '
        Me.tbCurrentLimit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCurrentLimit.Location = New System.Drawing.Point(113, 139)
        Me.tbCurrentLimit.Name = "tbCurrentLimit"
        Me.tbCurrentLimit.Size = New System.Drawing.Size(90, 21)
        Me.tbCurrentLimit.TabIndex = 38
        Me.tbCurrentLimit.Text = "0"
        Me.tbCurrentLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCurrentLimitUnit
        '
        Me.lblCurrentLimitUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentLimitUnit.AutoSize = True
        Me.lblCurrentLimitUnit.Location = New System.Drawing.Point(203, 142)
        Me.lblCurrentLimitUnit.Name = "lblCurrentLimitUnit"
        Me.lblCurrentLimitUnit.Size = New System.Drawing.Size(24, 12)
        Me.lblCurrentLimitUnit.TabIndex = 40
        Me.lblCurrentLimitUnit.Text = "mA"
        '
        'lblCurrentLimit
        '
        Me.lblCurrentLimit.AutoSize = True
        Me.lblCurrentLimit.Location = New System.Drawing.Point(27, 142)
        Me.lblCurrentLimit.Name = "lblCurrentLimit"
        Me.lblCurrentLimit.Size = New System.Drawing.Size(85, 12)
        Me.lblCurrentLimit.TabIndex = 39
        Me.lblCurrentLimit.Text = "Current Limit :"
        '
        'tbLMeasLimit
        '
        Me.tbLMeasLimit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLMeasLimit.Location = New System.Drawing.Point(113, 116)
        Me.tbLMeasLimit.Name = "tbLMeasLimit"
        Me.tbLMeasLimit.Size = New System.Drawing.Size(90, 21)
        Me.tbLMeasLimit.TabIndex = 35
        Me.tbLMeasLimit.Text = "0"
        Me.tbLMeasLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLMeasLimitUnit
        '
        Me.lblLMeasLimitUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLMeasLimitUnit.AutoSize = True
        Me.lblLMeasLimitUnit.Location = New System.Drawing.Point(203, 119)
        Me.lblLMeasLimitUnit.Name = "lblLMeasLimitUnit"
        Me.lblLMeasLimitUnit.Size = New System.Drawing.Size(42, 12)
        Me.lblLMeasLimitUnit.TabIndex = 37
        Me.lblLMeasLimitUnit.Text = "cd/m2"
        '
        'lblLMeasLimit
        '
        Me.lblLMeasLimit.AutoSize = True
        Me.lblLMeasLimit.Location = New System.Drawing.Point(25, 119)
        Me.lblLMeasLimit.Name = "lblLMeasLimit"
        Me.lblLMeasLimit.Size = New System.Drawing.Size(87, 12)
        Me.lblLMeasLimit.TabIndex = 36
        Me.lblLMeasLimit.Text = "L Meas Limit :"
        '
        'ucDispRcpLifetimeAndIVLSweep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.spContainer)
        Me.Name = "ucDispRcpLifetimeAndIVLSweep"
        Me.Size = New System.Drawing.Size(1649, 874)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbLifetimeAndIVLSweepCommon.ResumeLayout(False)
        Me.tcCommon.ResumeLayout(False)
        Me.tbIVL_Standard.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tbLifetime.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.PerformLayout()
        Me.gbStressMode.ResumeLayout(False)
        Me.gbStressMode.PerformLayout()
        Me.tbIVL_Detail.ResumeLayout(False)
        Me.gbDetailSettings.ResumeLayout(False)
        Me.gbDetailSettings.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbComponent.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpIVL.ResumeLayout(False)
        Me.tpLifetime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents gbLifetimeAndIVLSweepCommon As System.Windows.Forms.GroupBox
    Friend WithEvents tcCommon As System.Windows.Forms.TabControl
    Friend WithEvents tbLifetime As System.Windows.Forms.TabPage
    Friend WithEvents ucMeasureIntervalSetting As M7000.ucMeasureIntervalSetting
    Friend WithEvents ucRefPDSetting As M7000.ucRefPDSetting
    Friend WithEvents ucTestEndParam As M7000.ucTestEndParam
    Protected WithEvents gbLifeTimeEndSourceSetting As System.Windows.Forms.GroupBox
    Public WithEvents rbLifeTimeEndBiasON As System.Windows.Forms.RadioButton
    Public WithEvents rbLifeTimeEndBiasOFF As System.Windows.Forms.RadioButton
    Protected WithEvents gbStressMode As System.Windows.Forms.GroupBox
    Public WithEvents rbStress As System.Windows.Forms.RadioButton
    Public WithEvents rbNoStress As System.Windows.Forms.RadioButton
    Friend WithEvents tbIVL_Standard As System.Windows.Forms.TabPage
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
    Friend WithEvents tbIVL_Detail As System.Windows.Forms.TabPage
    Friend WithEvents gbDetailSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbSweepMode As System.Windows.Forms.ComboBox
    Friend WithEvents tbCycleDelay As System.Windows.Forms.TextBox
    Friend WithEvents cbDelayState As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureDelay As System.Windows.Forms.TextBox
    Friend WithEvents cbSweepMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbOffsetBias As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbAverage As System.Windows.Forms.TextBox
    Friend WithEvents lblOffsetBiasValueUnit As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbSweepDelay As System.Windows.Forms.TextBox
    Friend WithEvents gbComponent As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpLifetime As System.Windows.Forms.TabPage
    Friend WithEvents tpIVL As System.Windows.Forms.TabPage
    Friend WithEvents ucDispKeithley As CSMULib.ucKeithleySMUSettings
    Friend WithEvents ucDispM6000 As M7000.ucDispCellLifetime
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkFirstIVLSweep As System.Windows.Forms.CheckBox
    Friend WithEvents ucTestIVLMeasParam As M7000.ucTestEndParam
    Friend WithEvents tbCurrentLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentLimitUnit As System.Windows.Forms.Label
    Friend WithEvents lblCurrentLimit As System.Windows.Forms.Label
    Friend WithEvents tbLMeasLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblLMeasLimitUnit As System.Windows.Forms.Label
    Friend WithEvents lblLMeasLimit As System.Windows.Forms.Label

End Class
