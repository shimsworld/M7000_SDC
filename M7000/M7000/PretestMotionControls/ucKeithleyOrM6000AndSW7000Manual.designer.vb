<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucKeithleyOrM6000AndSW7000Manual
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
        Me.gbFreeRun = New System.Windows.Forms.GroupBox()
        Me.gbMeasData = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ucMeasDataListview = New M7000.ucDispListView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UcDispListView1 = New M7000.ucDispListView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnON = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.btnOFF = New System.Windows.Forms.Button()
        Me.btnSelectColorAllOn = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAllOff = New System.Windows.Forms.Button()
        Me.gbSrcControl = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMotionMove = New System.Windows.Forms.Button()
        Me.tbAngleValue = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSetSpectrometer = New System.Windows.Forms.Button()
        Me.cbSpeedMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAperture = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.gbSampleInfos = New System.Windows.Forms.GroupBox()
        Me.tbSampleHeight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbSampleWidth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbFill = New System.Windows.Forms.TextBox()
        Me.gbMeasurementSettings = New System.Windows.Forms.GroupBox()
        Me.lblBiasUnit = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbMeasMode = New System.Windows.Forms.ComboBox()
        Me.lblRed = New System.Windows.Forms.Label()
        Me.cbBiasMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.gbSourceComponent = New System.Windows.Forms.GroupBox()
        Me.rdoKeithley = New System.Windows.Forms.RadioButton()
        Me.rdoM6000 = New System.Windows.Forms.RadioButton()
        Me.ucKeithleySMUSettings = New CSMULib.ucKeithleySMUSettings()
        Me.gbFreeRun.SuspendLayout()
        Me.gbMeasData.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbSrcControl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbSampleInfos.SuspendLayout()
        Me.gbMeasurementSettings.SuspendLayout()
        Me.gbSourceComponent.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbFreeRun
        '
        Me.gbFreeRun.BackColor = System.Drawing.SystemColors.Control
        Me.gbFreeRun.Controls.Add(Me.gbMeasData)
        Me.gbFreeRun.Controls.Add(Me.btnSelectColorAllOn)
        Me.gbFreeRun.Controls.Add(Me.Button2)
        Me.gbFreeRun.Controls.Add(Me.ProgressBar1)
        Me.gbFreeRun.Controls.Add(Me.ProgressBar2)
        Me.gbFreeRun.Controls.Add(Me.Button1)
        Me.gbFreeRun.Controls.Add(Me.btnAllOff)
        Me.gbFreeRun.Controls.Add(Me.gbSrcControl)
        Me.gbFreeRun.Controls.Add(Me.ucKeithleySMUSettings)
        Me.gbFreeRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbFreeRun.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFreeRun.Location = New System.Drawing.Point(3, 3)
        Me.gbFreeRun.Name = "gbFreeRun"
        Me.gbFreeRun.Size = New System.Drawing.Size(1176, 476)
        Me.gbFreeRun.TabIndex = 76
        Me.gbFreeRun.TabStop = False
        Me.gbFreeRun.Text = "Free RUN"
        '
        'gbMeasData
        '
        Me.gbMeasData.Controls.Add(Me.TabControl1)
        Me.gbMeasData.Controls.Add(Me.btnON)
        Me.gbMeasData.Controls.Add(Me.btnClear)
        Me.gbMeasData.Controls.Add(Me.btnSave)
        Me.gbMeasData.Controls.Add(Me.btnMeas)
        Me.gbMeasData.Controls.Add(Me.btnOFF)
        Me.gbMeasData.Location = New System.Drawing.Point(485, 14)
        Me.gbMeasData.Name = "gbMeasData"
        Me.gbMeasData.Size = New System.Drawing.Size(685, 302)
        Me.gbMeasData.TabIndex = 73
        Me.gbMeasData.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(659, 219)
        Me.TabControl1.TabIndex = 78
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(651, 191)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "IVL"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ucMeasDataListview)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(645, 185)
        Me.Panel4.TabIndex = 77
        '
        'ucMeasDataListview
        '
        Me.ucMeasDataListview.AutoScroll = True
        Me.ucMeasDataListview.AutoSize = True
        Me.ucMeasDataListview.ColHeader = New String() {"[No]", "[Area]", "[Current]", "[J(mA/cm2)]", "[Luminance(Cd/m2)]", "[CIE1931_x]", "[CIE1931_y]", "[CIE1976_u']", "[CIE1976_v']"}
        Me.ucMeasDataListview.ColHeaderWidthRatio = "4,5,7,8,22,10,10,10,10"
        Me.ucMeasDataListview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucMeasDataListview.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucMeasDataListview.FullRawSelection = True
        Me.ucMeasDataListview.HideSelection = False
        Me.ucMeasDataListview.LabelEdit = True
        Me.ucMeasDataListview.LabelWrap = True
        Me.ucMeasDataListview.Location = New System.Drawing.Point(0, 20)
        Me.ucMeasDataListview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucMeasDataListview.Name = "ucMeasDataListview"
        Me.ucMeasDataListview.Size = New System.Drawing.Size(643, 163)
        Me.ucMeasDataListview.TabIndex = 74
        Me.ucMeasDataListview.UseCheckBoxex = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "DATA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(643, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(651, 191)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Spectrum"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.UcDispListView1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(645, 185)
        Me.Panel1.TabIndex = 78
        '
        'UcDispListView1
        '
        Me.UcDispListView1.AutoScroll = True
        Me.UcDispListView1.AutoSize = True
        Me.UcDispListView1.ColHeader = New String() {"[No]", "[Area]", "[Current]", "[J(mA/cm2)]", "[Luminance(Cd/m2)]", "[CIE1931_x]", "[CIE1931_y]", "[CIE1976_u']", "[CIE1976_v']"}
        Me.UcDispListView1.ColHeaderWidthRatio = "4,5,7,8,22,10,10,10,10"
        Me.UcDispListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDispListView1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcDispListView1.FullRawSelection = True
        Me.UcDispListView1.HideSelection = False
        Me.UcDispListView1.LabelEdit = True
        Me.UcDispListView1.LabelWrap = True
        Me.UcDispListView1.Location = New System.Drawing.Point(0, 20)
        Me.UcDispListView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcDispListView1.Name = "UcDispListView1"
        Me.UcDispListView1.Size = New System.Drawing.Size(643, 163)
        Me.UcDispListView1.TabIndex = 74
        Me.UcDispListView1.UseCheckBoxex = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "DATA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Orange
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(643, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnON
        '
        Me.btnON.BackColor = System.Drawing.Color.Silver
        Me.btnON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnON.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnON.Location = New System.Drawing.Point(7, 249)
        Me.btnON.Name = "btnON"
        Me.btnON.Size = New System.Drawing.Size(79, 35)
        Me.btnON.TabIndex = 63
        Me.btnON.Text = "ON"
        Me.btnON.UseVisualStyleBackColor = False
        Me.btnON.Visible = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnClear.Location = New System.Drawing.Point(347, 249)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(79, 35)
        Me.btnClear.TabIndex = 76
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Silver
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSave.Location = New System.Drawing.Point(262, 249)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 35)
        Me.btnSave.TabIndex = 77
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnMeas
        '
        Me.btnMeas.BackColor = System.Drawing.Color.Silver
        Me.btnMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeas.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMeas.Location = New System.Drawing.Point(177, 249)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(79, 35)
        Me.btnMeas.TabIndex = 74
        Me.btnMeas.Text = "Meas."
        Me.btnMeas.UseVisualStyleBackColor = False
        '
        'btnOFF
        '
        Me.btnOFF.BackColor = System.Drawing.Color.Silver
        Me.btnOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOFF.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnOFF.Location = New System.Drawing.Point(92, 249)
        Me.btnOFF.Name = "btnOFF"
        Me.btnOFF.Size = New System.Drawing.Size(79, 35)
        Me.btnOFF.TabIndex = 65
        Me.btnOFF.Text = "OFF"
        Me.btnOFF.UseVisualStyleBackColor = False
        Me.btnOFF.Visible = False
        '
        'btnSelectColorAllOn
        '
        Me.btnSelectColorAllOn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSelectColorAllOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectColorAllOn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectColorAllOn.Location = New System.Drawing.Point(17, 335)
        Me.btnSelectColorAllOn.Name = "btnSelectColorAllOn"
        Me.btnSelectColorAllOn.Size = New System.Drawing.Size(219, 38)
        Me.btnSelectColorAllOn.TabIndex = 76
        Me.btnSelectColorAllOn.Text = "AllOn (No-Experiment)"
        Me.btnSelectColorAllOn.UseVisualStyleBackColor = False
        Me.btnSelectColorAllOn.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1023, 349)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 25)
        Me.Button2.TabIndex = 79
        Me.Button2.Text = "Stop"
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(255, 379)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(220, 27)
        Me.ProgressBar1.TabIndex = 76
        Me.ProgressBar1.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(17, 379)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(219, 26)
        Me.ProgressBar2.TabIndex = 77
        Me.ProgressBar2.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(940, 349)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 25)
        Me.Button1.TabIndex = 78
        Me.Button1.Text = "Meas"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'btnAllOff
        '
        Me.btnAllOff.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAllOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllOff.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllOff.Location = New System.Drawing.Point(255, 335)
        Me.btnAllOff.Name = "btnAllOff"
        Me.btnAllOff.Size = New System.Drawing.Size(223, 39)
        Me.btnAllOff.TabIndex = 75
        Me.btnAllOff.Text = "AllOff (No-Experiment)"
        Me.btnAllOff.UseVisualStyleBackColor = False
        Me.btnAllOff.Visible = False
        '
        'gbSrcControl
        '
        Me.gbSrcControl.Controls.Add(Me.GroupBox1)
        Me.gbSrcControl.Controls.Add(Me.GroupBox2)
        Me.gbSrcControl.Controls.Add(Me.gbSampleInfos)
        Me.gbSrcControl.Controls.Add(Me.gbMeasurementSettings)
        Me.gbSrcControl.Controls.Add(Me.gbSourceComponent)
        Me.gbSrcControl.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbSrcControl.Location = New System.Drawing.Point(6, 14)
        Me.gbSrcControl.Name = "gbSrcControl"
        Me.gbSrcControl.Size = New System.Drawing.Size(472, 266)
        Me.gbSrcControl.TabIndex = 71
        Me.gbSrcControl.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMotionMove)
        Me.GroupBox1.Controls.Add(Me.tbAngleValue)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(205, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 47)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MotionControl"
        Me.GroupBox1.Visible = False
        '
        'btnMotionMove
        '
        Me.btnMotionMove.BackColor = System.Drawing.Color.Silver
        Me.btnMotionMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMotionMove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMotionMove.Location = New System.Drawing.Point(160, 16)
        Me.btnMotionMove.Name = "btnMotionMove"
        Me.btnMotionMove.Size = New System.Drawing.Size(82, 24)
        Me.btnMotionMove.TabIndex = 78
        Me.btnMotionMove.Text = "Move"
        Me.btnMotionMove.UseVisualStyleBackColor = False
        '
        'tbAngleValue
        '
        Me.tbAngleValue.BackColor = System.Drawing.Color.White
        Me.tbAngleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAngleValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAngleValue.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbAngleValue.Location = New System.Drawing.Point(83, 18)
        Me.tbAngleValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbAngleValue.Name = "tbAngleValue"
        Me.tbAngleValue.Size = New System.Drawing.Size(50, 21)
        Me.tbAngleValue.TabIndex = 82
        Me.tbAngleValue.Text = "0.00"
        Me.tbAngleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Angle(')"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSetSpectrometer)
        Me.GroupBox2.Controls.Add(Me.cbSpeedMode)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbAperture)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(453, 50)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Spectrometer"
        '
        'btnSetSpectrometer
        '
        Me.btnSetSpectrometer.BackColor = System.Drawing.Color.Silver
        Me.btnSetSpectrometer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetSpectrometer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetSpectrometer.Location = New System.Drawing.Point(359, 18)
        Me.btnSetSpectrometer.Name = "btnSetSpectrometer"
        Me.btnSetSpectrometer.Size = New System.Drawing.Size(80, 25)
        Me.btnSetSpectrometer.TabIndex = 91
        Me.btnSetSpectrometer.Text = "Set"
        Me.btnSetSpectrometer.UseVisualStyleBackColor = False
        '
        'cbSpeedMode
        '
        Me.cbSpeedMode.FormattingEnabled = True
        Me.cbSpeedMode.Location = New System.Drawing.Point(269, 20)
        Me.cbSpeedMode.Name = "cbSpeedMode"
        Me.cbSpeedMode.Size = New System.Drawing.Size(81, 23)
        Me.cbSpeedMode.TabIndex = 90
        Me.cbSpeedMode.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(174, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Speed Mode"
        Me.Label1.Visible = False
        '
        'cbAperture
        '
        Me.cbAperture.FormattingEnabled = True
        Me.cbAperture.Location = New System.Drawing.Point(80, 19)
        Me.cbAperture.Name = "cbAperture"
        Me.cbAperture.Size = New System.Drawing.Size(80, 23)
        Me.cbAperture.TabIndex = 88
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(10, 22)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(57, 15)
        Me.Label37.TabIndex = 87
        Me.Label37.Text = "Aperture"
        '
        'gbSampleInfos
        '
        Me.gbSampleInfos.Controls.Add(Me.tbSampleHeight)
        Me.gbSampleInfos.Controls.Add(Me.Label3)
        Me.gbSampleInfos.Controls.Add(Me.tbSampleWidth)
        Me.gbSampleInfos.Controls.Add(Me.Label4)
        Me.gbSampleInfos.Controls.Add(Me.Label5)
        Me.gbSampleInfos.Controls.Add(Me.tbFill)
        Me.gbSampleInfos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSampleInfos.Location = New System.Drawing.Point(6, 64)
        Me.gbSampleInfos.Name = "gbSampleInfos"
        Me.gbSampleInfos.Size = New System.Drawing.Size(453, 51)
        Me.gbSampleInfos.TabIndex = 85
        Me.gbSampleInfos.TabStop = False
        Me.gbSampleInfos.Text = "SampleInfos"
        '
        'tbSampleHeight
        '
        Me.tbSampleHeight.BackColor = System.Drawing.Color.White
        Me.tbSampleHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSampleHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSampleHeight.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSampleHeight.Location = New System.Drawing.Point(96, 18)
        Me.tbSampleHeight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSampleHeight.Name = "tbSampleHeight"
        Me.tbSampleHeight.Size = New System.Drawing.Size(50, 21)
        Me.tbSampleHeight.TabIndex = 78
        Me.tbSampleHeight.Text = "2.772"
        Me.tbSampleHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Height(mm)"
        '
        'tbSampleWidth
        '
        Me.tbSampleWidth.BackColor = System.Drawing.Color.White
        Me.tbSampleWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSampleWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSampleWidth.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSampleWidth.Location = New System.Drawing.Point(240, 18)
        Me.tbSampleWidth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSampleWidth.Name = "tbSampleWidth"
        Me.tbSampleWidth.Size = New System.Drawing.Size(50, 21)
        Me.tbSampleWidth.TabIndex = 80
        Me.tbSampleWidth.Text = "2.772"
        Me.tbSampleWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(159, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Width(mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Fill(%)"
        '
        'tbFill
        '
        Me.tbFill.BackColor = System.Drawing.Color.White
        Me.tbFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFill.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbFill.Location = New System.Drawing.Point(364, 18)
        Me.tbFill.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbFill.Name = "tbFill"
        Me.tbFill.Size = New System.Drawing.Size(50, 21)
        Me.tbFill.TabIndex = 82
        Me.tbFill.Text = "13.19"
        Me.tbFill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbMeasurementSettings
        '
        Me.gbMeasurementSettings.Controls.Add(Me.lblBiasUnit)
        Me.gbMeasurementSettings.Controls.Add(Me.Label2)
        Me.gbMeasurementSettings.Controls.Add(Me.cbMeasMode)
        Me.gbMeasurementSettings.Controls.Add(Me.lblRed)
        Me.gbMeasurementSettings.Controls.Add(Me.cbBiasMode)
        Me.gbMeasurementSettings.Controls.Add(Me.Label7)
        Me.gbMeasurementSettings.Controls.Add(Me.tbBias)
        Me.gbMeasurementSettings.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMeasurementSettings.Location = New System.Drawing.Point(6, 175)
        Me.gbMeasurementSettings.Name = "gbMeasurementSettings"
        Me.gbMeasurementSettings.Size = New System.Drawing.Size(453, 80)
        Me.gbMeasurementSettings.TabIndex = 86
        Me.gbMeasurementSettings.TabStop = False
        Me.gbMeasurementSettings.Text = "MeasurementSettings"
        '
        'lblBiasUnit
        '
        Me.lblBiasUnit.AutoSize = True
        Me.lblBiasUnit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBiasUnit.Location = New System.Drawing.Point(393, 46)
        Me.lblBiasUnit.Name = "lblBiasUnit"
        Me.lblBiasUnit.Size = New System.Drawing.Size(26, 15)
        Me.lblBiasUnit.TabIndex = 87
        Me.lblBiasUnit.Text = "mA"
        Me.lblBiasUnit.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Meas. Mode"
        '
        'cbMeasMode
        '
        Me.cbMeasMode.FormattingEnabled = True
        Me.cbMeasMode.Location = New System.Drawing.Point(106, 20)
        Me.cbMeasMode.Name = "cbMeasMode"
        Me.cbMeasMode.Size = New System.Drawing.Size(84, 23)
        Me.cbMeasMode.TabIndex = 75
        '
        'lblRed
        '
        Me.lblRed.AutoSize = True
        Me.lblRed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRed.Location = New System.Drawing.Point(259, 45)
        Me.lblRed.Name = "lblRed"
        Me.lblRed.Size = New System.Drawing.Size(32, 15)
        Me.lblRed.TabIndex = 86
        Me.lblRed.Text = "Bias"
        Me.lblRed.Visible = False
        '
        'cbBiasMode
        '
        Me.cbBiasMode.FormattingEnabled = True
        Me.cbBiasMode.Location = New System.Drawing.Point(306, 14)
        Me.cbBiasMode.Name = "cbBiasMode"
        Me.cbBiasMode.Size = New System.Drawing.Size(80, 23)
        Me.cbBiasMode.TabIndex = 82
        Me.cbBiasMode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(220, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Bias Mode"
        Me.Label7.Visible = False
        '
        'tbBias
        '
        Me.tbBias.BackColor = System.Drawing.Color.White
        Me.tbBias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBias.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBias.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbBias.Location = New System.Drawing.Point(306, 42)
        Me.tbBias.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(80, 21)
        Me.tbBias.TabIndex = 85
        Me.tbBias.Text = "4.00"
        Me.tbBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbBias.Visible = False
        '
        'gbSourceComponent
        '
        Me.gbSourceComponent.Controls.Add(Me.rdoKeithley)
        Me.gbSourceComponent.Controls.Add(Me.rdoM6000)
        Me.gbSourceComponent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSourceComponent.Location = New System.Drawing.Point(6, 17)
        Me.gbSourceComponent.Name = "gbSourceComponent"
        Me.gbSourceComponent.Size = New System.Drawing.Size(190, 47)
        Me.gbSourceComponent.TabIndex = 84
        Me.gbSourceComponent.TabStop = False
        Me.gbSourceComponent.Text = "SourceComponent"
        Me.gbSourceComponent.Visible = False
        '
        'rdoKeithley
        '
        Me.rdoKeithley.AutoSize = True
        Me.rdoKeithley.Enabled = False
        Me.rdoKeithley.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoKeithley.Location = New System.Drawing.Point(96, 19)
        Me.rdoKeithley.Name = "rdoKeithley"
        Me.rdoKeithley.Size = New System.Drawing.Size(69, 19)
        Me.rdoKeithley.TabIndex = 1
        Me.rdoKeithley.Text = "Keithley"
        Me.rdoKeithley.UseVisualStyleBackColor = True
        '
        'rdoM6000
        '
        Me.rdoM6000.AutoSize = True
        Me.rdoM6000.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoM6000.Location = New System.Drawing.Point(19, 19)
        Me.rdoM6000.Name = "rdoM6000"
        Me.rdoM6000.Size = New System.Drawing.Size(62, 19)
        Me.rdoM6000.TabIndex = 0
        Me.rdoM6000.Text = "M6000"
        Me.rdoM6000.UseVisualStyleBackColor = True
        '
        'ucKeithleySMUSettings
        '
        Me.ucKeithleySMUSettings.Location = New System.Drawing.Point(515, 323)
        Me.ucKeithleySMUSettings.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucKeithleySMUSettings.Name = "ucKeithleySMUSettings"
        Me.ucKeithleySMUSettings.Size = New System.Drawing.Size(285, 73)
        Me.ucKeithleySMUSettings.TabIndex = 61
        Me.ucKeithleySMUSettings.Visible = False
        '
        'ucKeithleyOrM6000AndSW7000Manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.gbFreeRun)
        Me.MinimumSize = New System.Drawing.Size(199, 500)
        Me.Name = "ucKeithleyOrM6000AndSW7000Manual"
        Me.Size = New System.Drawing.Size(1195, 500)
        Me.gbFreeRun.ResumeLayout(False)
        Me.gbMeasData.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbSrcControl.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbSampleInfos.ResumeLayout(False)
        Me.gbSampleInfos.PerformLayout()
        Me.gbMeasurementSettings.ResumeLayout(False)
        Me.gbMeasurementSettings.PerformLayout()
        Me.gbSourceComponent.ResumeLayout(False)
        Me.gbSourceComponent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbFreeRun As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnAllOff As System.Windows.Forms.Button
    Friend WithEvents btnOFF As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbMeasData As System.Windows.Forms.GroupBox
    Friend WithEvents ucMeasDataListview As M7000.ucDispListView
    Friend WithEvents gbSrcControl As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMotionMove As System.Windows.Forms.Button
    Friend WithEvents tbAngleValue As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbMeasurementSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbMeasMode As System.Windows.Forms.ComboBox
    Friend WithEvents cbBiasMode As System.Windows.Forms.ComboBox
    Friend WithEvents gbSampleInfos As System.Windows.Forms.GroupBox
    Friend WithEvents tbSampleHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbSampleWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbFill As System.Windows.Forms.TextBox
    Friend WithEvents gbSourceComponent As System.Windows.Forms.GroupBox
    Friend WithEvents rdoKeithley As System.Windows.Forms.RadioButton
    Friend WithEvents rdoM6000 As System.Windows.Forms.RadioButton
    Friend WithEvents ucKeithleySMUSettings As CSMULib.ucKeithleySMUSettings
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents btnON As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSelectColorAllOn As System.Windows.Forms.Button
    Friend WithEvents lblBiasUnit As System.Windows.Forms.Label
    Friend WithEvents lblRed As System.Windows.Forms.Label
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAperture As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbSpeedMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSetSpectrometer As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UcDispListView1 As M7000.ucDispListView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
