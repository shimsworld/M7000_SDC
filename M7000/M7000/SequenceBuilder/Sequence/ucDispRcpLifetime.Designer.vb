<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpLifetime
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
        Me.gbLifetimeCommon = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UcDispListView1 = New M7000.ucDispListView()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboIntegralUserCount = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtWLInterval4Stop = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtWLInterval2Start = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.txtWLInterval1Start = New System.Windows.Forms.TextBox()
        Me.txtWLInterval2Stop = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.txtWLInterval4Start = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.txtWLInterval1Stop = New System.Windows.Forms.TextBox()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.txtWLInterval3Stop = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.txtWLInterval3Start = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.ucMeasureIntervalSetting = New M7000.ucMeasureIntervalSetting()
        Me.ucRefPDSetting = New M7000.ucRefPDSetting()
        Me.ucTestEndParam = New M7000.ucTestEndParam()
        Me.gbLifeTimeEndSourceSetting = New System.Windows.Forms.GroupBox()
        Me.rbLifeTimeEndBiasON = New System.Windows.Forms.RadioButton()
        Me.rbLifeTimeEndBiasOFF = New System.Windows.Forms.RadioButton()
        Me.gbStressMode = New System.Windows.Forms.GroupBox()
        Me.rbStress = New System.Windows.Forms.RadioButton()
        Me.rbNoStress = New System.Windows.Forms.RadioButton()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.gbLifetimeCommon.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.gbLifeTimeEndSourceSetting.SuspendLayout()
        Me.gbStressMode.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.Location = New System.Drawing.Point(3, 3)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel1.Controls.Add(Me.gbLifetimeCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(507, 867)
        Me.spContainer.SplitterDistance = 488
        Me.spContainer.TabIndex = 1
        '
        'gbLifetimeCommon
        '
        Me.gbLifetimeCommon.Controls.Add(Me.GroupBox1)
        Me.gbLifetimeCommon.Controls.Add(Me.GroupBox29)
        Me.gbLifetimeCommon.Controls.Add(Me.ucMeasureIntervalSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucRefPDSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucTestEndParam)
        Me.gbLifetimeCommon.Controls.Add(Me.gbLifeTimeEndSourceSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.gbStressMode)
        Me.gbLifetimeCommon.Location = New System.Drawing.Point(3, 3)
        Me.gbLifetimeCommon.MinimumSize = New System.Drawing.Size(440, 334)
        Me.gbLifetimeCommon.Name = "gbLifetimeCommon"
        Me.gbLifetimeCommon.Size = New System.Drawing.Size(501, 608)
        Me.gbLifetimeCommon.TabIndex = 0
        Me.gbLifetimeCommon.TabStop = False
        Me.gbLifetimeCommon.Text = "Common"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UcDispListView1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 196)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Measurement Point"
        Me.GroupBox1.Visible = False
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
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.Label2)
        Me.GroupBox29.Controls.Add(Me.cboIntegralUserCount)
        Me.GroupBox29.Controls.Add(Me.Label1)
        Me.GroupBox29.Controls.Add(Me.Label97)
        Me.GroupBox29.Controls.Add(Me.Label91)
        Me.GroupBox29.Controls.Add(Me.Label83)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval4Stop)
        Me.GroupBox29.Controls.Add(Me.Label82)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval2Start)
        Me.GroupBox29.Controls.Add(Me.Label98)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval1Start)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval2Stop)
        Me.GroupBox29.Controls.Add(Me.Label117)
        Me.GroupBox29.Controls.Add(Me.Label85)
        Me.GroupBox29.Controls.Add(Me.Label87)
        Me.GroupBox29.Controls.Add(Me.Label118)
        Me.GroupBox29.Controls.Add(Me.Label88)
        Me.GroupBox29.Controls.Add(Me.Label84)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval4Start)
        Me.GroupBox29.Controls.Add(Me.Label89)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval1Stop)
        Me.GroupBox29.Controls.Add(Me.Label119)
        Me.GroupBox29.Controls.Add(Me.Label92)
        Me.GroupBox29.Controls.Add(Me.Label86)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval3Stop)
        Me.GroupBox29.Controls.Add(Me.Label90)
        Me.GroupBox29.Controls.Add(Me.Label96)
        Me.GroupBox29.Controls.Add(Me.Label93)
        Me.GroupBox29.Controls.Add(Me.Label94)
        Me.GroupBox29.Controls.Add(Me.txtWLInterval3Start)
        Me.GroupBox29.Controls.Add(Me.Label95)
        Me.GroupBox29.Location = New System.Drawing.Point(477, 320)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(494, 127)
        Me.GroupBox29.TabIndex = 11
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Integral Wavelength"
        Me.GroupBox29.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(256, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "[Range : 380 ~ 780 , Interval : 2nm)"
        '
        'cboIntegralUserCount
        '
        Me.cboIntegralUserCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIntegralUserCount.FormattingEnabled = True
        Me.cboIntegralUserCount.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cboIntegralUserCount.Location = New System.Drawing.Point(102, 21)
        Me.cboIntegralUserCount.Name = "cboIntegralUserCount"
        Me.cboIntegralUserCount.Size = New System.Drawing.Size(59, 28)
        Me.cboIntegralUserCount.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Use Count :"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(464, 103)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(31, 20)
        Me.Label97.TabIndex = 33
        Me.Label97.Text = "nm"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(155, 54)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(78, 20)
        Me.Label91.TabIndex = 13
        Me.Label91.Text = "[Interval2]"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(211, 104)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(31, 20)
        Me.Label83.TabIndex = 19
        Me.Label83.Text = "nm"
        '
        'txtWLInterval4Stop
        '
        Me.txtWLInterval4Stop.Location = New System.Drawing.Point(417, 97)
        Me.txtWLInterval4Stop.Name = "txtWLInterval4Stop"
        Me.txtWLInterval4Stop.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval4Stop.TabIndex = 32
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(29, 54)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(78, 20)
        Me.Label82.TabIndex = 0
        Me.Label82.Text = "[Interval1]"
        '
        'txtWLInterval2Start
        '
        Me.txtWLInterval2Start.Location = New System.Drawing.Point(164, 73)
        Me.txtWLInterval2Start.Name = "txtWLInterval2Start"
        Me.txtWLInterval2Start.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval2Start.TabIndex = 14
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Location = New System.Drawing.Point(384, 102)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(43, 20)
        Me.Label98.TabIndex = 31
        Me.Label98.Text = "Stop"
        '
        'txtWLInterval1Start
        '
        Me.txtWLInterval1Start.Location = New System.Drawing.Point(38, 73)
        Me.txtWLInterval1Start.Name = "txtWLInterval1Start"
        Me.txtWLInterval1Start.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval1Start.TabIndex = 1
        '
        'txtWLInterval2Stop
        '
        Me.txtWLInterval2Stop.Location = New System.Drawing.Point(164, 97)
        Me.txtWLInterval2Stop.Name = "txtWLInterval2Stop"
        Me.txtWLInterval2Stop.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval2Stop.TabIndex = 18
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Location = New System.Drawing.Point(384, 78)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(44, 20)
        Me.Label117.TabIndex = 30
        Me.Label117.Text = "Start"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(85, 79)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(31, 20)
        Me.Label85.TabIndex = 6
        Me.Label85.Text = "nm"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(211, 80)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(31, 20)
        Me.Label87.TabIndex = 15
        Me.Label87.Text = "nm"
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Location = New System.Drawing.Point(464, 80)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(31, 20)
        Me.Label118.TabIndex = 29
        Me.Label118.Text = "nm"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(6, 78)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(44, 20)
        Me.Label88.TabIndex = 9
        Me.Label88.Text = "Start"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(132, 102)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(43, 20)
        Me.Label84.TabIndex = 17
        Me.Label84.Text = "Stop"
        '
        'txtWLInterval4Start
        '
        Me.txtWLInterval4Start.Location = New System.Drawing.Point(417, 73)
        Me.txtWLInterval4Start.Name = "txtWLInterval4Start"
        Me.txtWLInterval4Start.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval4Start.TabIndex = 28
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(6, 102)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(43, 20)
        Me.Label89.TabIndex = 10
        Me.Label89.Text = "Stop"
        '
        'txtWLInterval1Stop
        '
        Me.txtWLInterval1Stop.Location = New System.Drawing.Point(38, 97)
        Me.txtWLInterval1Stop.Name = "txtWLInterval1Stop"
        Me.txtWLInterval1Stop.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval1Stop.TabIndex = 11
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.Location = New System.Drawing.Point(409, 54)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(78, 20)
        Me.Label119.TabIndex = 27
        Me.Label119.Text = "[Interval4]"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(340, 103)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(31, 20)
        Me.Label92.TabIndex = 26
        Me.Label92.Text = "nm"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(132, 78)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(44, 20)
        Me.Label86.TabIndex = 16
        Me.Label86.Text = "Start"
        '
        'txtWLInterval3Stop
        '
        Me.txtWLInterval3Stop.Location = New System.Drawing.Point(293, 97)
        Me.txtWLInterval3Stop.Name = "txtWLInterval3Stop"
        Me.txtWLInterval3Stop.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval3Stop.TabIndex = 25
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(85, 103)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(31, 20)
        Me.Label90.TabIndex = 12
        Me.Label90.Text = "nm"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(284, 54)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(78, 20)
        Me.Label96.TabIndex = 20
        Me.Label96.Text = "[Interval3]"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(261, 102)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(43, 20)
        Me.Label93.TabIndex = 24
        Me.Label93.Text = "Stop"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(261, 78)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(44, 20)
        Me.Label94.TabIndex = 23
        Me.Label94.Text = "Start"
        '
        'txtWLInterval3Start
        '
        Me.txtWLInterval3Start.Location = New System.Drawing.Point(293, 73)
        Me.txtWLInterval3Start.Name = "txtWLInterval3Start"
        Me.txtWLInterval3Start.Size = New System.Drawing.Size(44, 26)
        Me.txtWLInterval3Start.TabIndex = 21
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(340, 79)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(31, 20)
        Me.Label95.TabIndex = 22
        Me.Label95.Text = "nm"
        '
        'ucMeasureIntervalSetting
        '
        Me.ucMeasureIntervalSetting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucMeasureIntervalSetting.Location = New System.Drawing.Point(11, 116)
        Me.ucMeasureIntervalSetting.Name = "ucMeasureIntervalSetting"
        Me.ucMeasureIntervalSetting.Setting = New M7000.ucMeasureIntervalSetting.sSetTime(-1) {}
        Me.ucMeasureIntervalSetting.Size = New System.Drawing.Size(232, 191)
        Me.ucMeasureIntervalSetting.TabIndex = 7
        '
        'ucRefPDSetting
        '
        Me.ucRefPDSetting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucRefPDSetting.Location = New System.Drawing.Point(161, 22)
        Me.ucRefPDSetting.Name = "ucRefPDSetting"
        Me.ucRefPDSetting.Size = New System.Drawing.Size(179, 88)
        Me.ucRefPDSetting.TabIndex = 3
        '
        'ucTestEndParam
        '
        Me.ucTestEndParam.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucTestEndParam.Location = New System.Drawing.Point(253, 116)
        Me.ucTestEndParam.Name = "ucTestEndParam"
        Me.ucTestEndParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestEndParam.Size = New System.Drawing.Size(248, 191)
        Me.ucTestEndParam.TabIndex = 8
        Me.ucTestEndParam.Title = "End Conditions"
        '
        'gbLifeTimeEndSourceSetting
        '
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasON)
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasOFF)
        Me.gbLifeTimeEndSourceSetting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLifeTimeEndSourceSetting.Location = New System.Drawing.Point(367, 20)
        Me.gbLifeTimeEndSourceSetting.Name = "gbLifeTimeEndSourceSetting"
        Me.gbLifeTimeEndSourceSetting.Size = New System.Drawing.Size(101, 88)
        Me.gbLifeTimeEndSourceSetting.TabIndex = 4
        Me.gbLifeTimeEndSourceSetting.TabStop = False
        Me.gbLifeTimeEndSourceSetting.Text = "종료 동작"
        '
        'rbLifeTimeEndBiasON
        '
        Me.rbLifeTimeEndBiasON.AutoSize = True
        Me.rbLifeTimeEndBiasON.Location = New System.Drawing.Point(16, 51)
        Me.rbLifeTimeEndBiasON.Name = "rbLifeTimeEndBiasON"
        Me.rbLifeTimeEndBiasON.Size = New System.Drawing.Size(70, 19)
        Me.rbLifeTimeEndBiasON.TabIndex = 6
        Me.rbLifeTimeEndBiasON.Text = "Bias ON"
        Me.rbLifeTimeEndBiasON.UseVisualStyleBackColor = True
        '
        'rbLifeTimeEndBiasOFF
        '
        Me.rbLifeTimeEndBiasOFF.AutoSize = True
        Me.rbLifeTimeEndBiasOFF.Checked = True
        Me.rbLifeTimeEndBiasOFF.Location = New System.Drawing.Point(16, 24)
        Me.rbLifeTimeEndBiasOFF.Name = "rbLifeTimeEndBiasOFF"
        Me.rbLifeTimeEndBiasOFF.Size = New System.Drawing.Size(74, 19)
        Me.rbLifeTimeEndBiasOFF.TabIndex = 5
        Me.rbLifeTimeEndBiasOFF.TabStop = True
        Me.rbLifeTimeEndBiasOFF.Text = "Bias OFF"
        Me.rbLifeTimeEndBiasOFF.UseVisualStyleBackColor = True
        '
        'gbStressMode
        '
        Me.gbStressMode.Controls.Add(Me.rbStress)
        Me.gbStressMode.Controls.Add(Me.rbNoStress)
        Me.gbStressMode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStressMode.Location = New System.Drawing.Point(10, 17)
        Me.gbStressMode.Name = "gbStressMode"
        Me.gbStressMode.Size = New System.Drawing.Size(120, 88)
        Me.gbStressMode.TabIndex = 0
        Me.gbStressMode.TabStop = False
        Me.gbStressMode.Text = "MODE"
        '
        'rbStress
        '
        Me.rbStress.AutoSize = True
        Me.rbStress.Checked = True
        Me.rbStress.Location = New System.Drawing.Point(17, 51)
        Me.rbStress.Name = "rbStress"
        Me.rbStress.Size = New System.Drawing.Size(82, 19)
        Me.rbStress.TabIndex = 2
        Me.rbStress.TabStop = True
        Me.rbStress.Text = "동작(Bias)"
        Me.rbStress.UseVisualStyleBackColor = True
        '
        'rbNoStress
        '
        Me.rbNoStress.AutoSize = True
        Me.rbNoStress.Location = New System.Drawing.Point(17, 24)
        Me.rbNoStress.Name = "rbNoStress"
        Me.rbNoStress.Size = New System.Drawing.Size(97, 19)
        Me.rbNoStress.TabIndex = 1
        Me.rbNoStress.Text = "보관(NoBias)"
        Me.rbNoStress.UseVisualStyleBackColor = True
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
        Me.tlpPanel2.Location = New System.Drawing.Point(9, 4)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(483, 368)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeasPoint.Location = New System.Drawing.Point(363, 321)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(93, 39)
        Me.btnMeasPoint.TabIndex = 13
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        Me.btnMeasPoint.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(243, 321)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(63, 39)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnADD
        '
        Me.btnADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADD.Location = New System.Drawing.Point(3, 321)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(63, 39)
        Me.btnADD.TabIndex = 10
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(123, 321)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(63, 39)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 312)
        Me.Panel1.TabIndex = 9
        '
        'ucDispRcpLifetime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpLifetime"
        Me.Size = New System.Drawing.Size(516, 883)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbLifetimeCommon.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.gbLifeTimeEndSourceSetting.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.PerformLayout()
        Me.gbStressMode.ResumeLayout(False)
        Me.gbStressMode.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbLifetimeCommon As System.Windows.Forms.GroupBox
    Protected WithEvents gbLifeTimeEndSourceSetting As System.Windows.Forms.GroupBox
    Protected WithEvents gbStressMode As System.Windows.Forms.GroupBox
    Friend WithEvents ucMeasureIntervalSetting As ucMeasureIntervalSetting
    Friend WithEvents ucRefPDSetting As ucRefPDSetting
    Friend WithEvents ucTestEndParam As ucTestEndParam
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Public WithEvents rbNoStress As System.Windows.Forms.RadioButton
    Public WithEvents rbLifeTimeEndBiasON As System.Windows.Forms.RadioButton
    Public WithEvents rbLifeTimeEndBiasOFF As System.Windows.Forms.RadioButton
    Public WithEvents rbStress As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval4Stop As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval4Start As System.Windows.Forms.TextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval1Start As System.Windows.Forms.TextBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval1Stop As System.Windows.Forms.TextBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval2Start As System.Windows.Forms.TextBox
    Friend WithEvents txtWLInterval2Stop As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval3Stop As System.Windows.Forms.TextBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents txtWLInterval3Start As System.Windows.Forms.TextBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents cboIntegralUserCount As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UcDispListView1 As M7000.ucDispListView

End Class
