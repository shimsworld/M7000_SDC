<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucKeithleySMUSettings
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
        Me.gbKeithley = New System.Windows.Forms.GroupBox()
        Me.gbSMUCH = New System.Windows.Forms.GroupBox()
        Me.rbChA = New System.Windows.Forms.RadioButton()
        Me.rbChB = New System.Windows.Forms.RadioButton()
        Me.gbRange = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCurrentRange = New System.Windows.Forms.ComboBox()
        Me.cbVoltageRange = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboBiasMode = New System.Windows.Forms.ComboBox()
        Me.rbCV = New System.Windows.Forms.RadioButton()
        Me.rbCC = New System.Windows.Forms.RadioButton()
        Me.gbTerminalMode = New System.Windows.Forms.GroupBox()
        Me.rbRear = New System.Windows.Forms.RadioButton()
        Me.rbFront = New System.Windows.Forms.RadioButton()
        Me.gbWireMode = New System.Windows.Forms.GroupBox()
        Me.rb2Wire = New System.Windows.Forms.RadioButton()
        Me.rb4Wire = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.cbIntegTime = New System.Windows.Forms.ComboBox()
        Me.cbAutoDelay_Measure = New System.Windows.Forms.CheckBox()
        Me.lblIntegTime = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbAutoRange_Measure = New System.Windows.Forms.CheckBox()
        Me.tbNumofMeasData = New System.Windows.Forms.TextBox()
        Me.tbMeasDelay = New System.Windows.Forms.TextBox()
        Me.tbIntegTime = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbAutoRange_Source = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tbNumofpulse = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbPulseofftime = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbPulseontime = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSourceDelay = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbVoltLimit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbCurrentLimit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbKeithley.SuspendLayout()
        Me.gbSMUCH.SuspendLayout()
        Me.gbRange.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbTerminalMode.SuspendLayout()
        Me.gbWireMode.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbKeithley
        '
        Me.gbKeithley.Controls.Add(Me.gbSMUCH)
        Me.gbKeithley.Controls.Add(Me.gbRange)
        Me.gbKeithley.Controls.Add(Me.GroupBox1)
        Me.gbKeithley.Controls.Add(Me.gbTerminalMode)
        Me.gbKeithley.Controls.Add(Me.gbWireMode)
        Me.gbKeithley.Controls.Add(Me.GroupBox8)
        Me.gbKeithley.Controls.Add(Me.GroupBox7)
        Me.gbKeithley.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbKeithley.Location = New System.Drawing.Point(20, 21)
        Me.gbKeithley.Name = "gbKeithley"
        Me.gbKeithley.Size = New System.Drawing.Size(537, 308)
        Me.gbKeithley.TabIndex = 1
        Me.gbKeithley.TabStop = False
        Me.gbKeithley.Text = "Settings"
        '
        'gbSMUCH
        '
        Me.gbSMUCH.Controls.Add(Me.rbChA)
        Me.gbSMUCH.Controls.Add(Me.rbChB)
        Me.gbSMUCH.Location = New System.Drawing.Point(334, 18)
        Me.gbSMUCH.Name = "gbSMUCH"
        Me.gbSMUCH.Size = New System.Drawing.Size(142, 47)
        Me.gbSMUCH.TabIndex = 18
        Me.gbSMUCH.TabStop = False
        Me.gbSMUCH.Text = "Channel"
        '
        'rbChA
        '
        Me.rbChA.AutoSize = True
        Me.rbChA.Checked = True
        Me.rbChA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbChA.Location = New System.Drawing.Point(8, 20)
        Me.rbChA.Name = "rbChA"
        Me.rbChA.Size = New System.Drawing.Size(32, 19)
        Me.rbChA.TabIndex = 1
        Me.rbChA.TabStop = True
        Me.rbChA.Text = "A"
        Me.rbChA.UseVisualStyleBackColor = True
        '
        'rbChB
        '
        Me.rbChB.AutoSize = True
        Me.rbChB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbChB.Location = New System.Drawing.Point(77, 20)
        Me.rbChB.Name = "rbChB"
        Me.rbChB.Size = New System.Drawing.Size(32, 19)
        Me.rbChB.TabIndex = 0
        Me.rbChB.Text = "B"
        Me.rbChB.UseVisualStyleBackColor = True
        '
        'gbRange
        '
        Me.gbRange.Controls.Add(Me.Label4)
        Me.gbRange.Controls.Add(Me.Label3)
        Me.gbRange.Controls.Add(Me.cbCurrentRange)
        Me.gbRange.Controls.Add(Me.cbVoltageRange)
        Me.gbRange.Location = New System.Drawing.Point(14, 252)
        Me.gbRange.Name = "gbRange"
        Me.gbRange.Size = New System.Drawing.Size(377, 51)
        Me.gbRange.TabIndex = 17
        Me.gbRange.TabStop = False
        Me.gbRange.Text = "Range"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(194, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Current Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Voltage Range"
        '
        'cbCurrentRange
        '
        Me.cbCurrentRange.FormattingEnabled = True
        Me.cbCurrentRange.Location = New System.Drawing.Point(294, 20)
        Me.cbCurrentRange.Name = "cbCurrentRange"
        Me.cbCurrentRange.Size = New System.Drawing.Size(76, 23)
        Me.cbCurrentRange.TabIndex = 35
        Me.cbCurrentRange.Text = "Nothing"
        '
        'cbVoltageRange
        '
        Me.cbVoltageRange.FormattingEnabled = True
        Me.cbVoltageRange.Location = New System.Drawing.Point(107, 20)
        Me.cbVoltageRange.Name = "cbVoltageRange"
        Me.cbVoltageRange.Size = New System.Drawing.Size(76, 23)
        Me.cbVoltageRange.TabIndex = 34
        Me.cbVoltageRange.Text = "Nothing"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboBiasMode)
        Me.GroupBox1.Controls.Add(Me.rbCV)
        Me.GroupBox1.Controls.Add(Me.rbCC)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(134, 47)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bias Mode"
        '
        'cboBiasMode
        '
        Me.cboBiasMode.FormattingEnabled = True
        Me.cboBiasMode.Location = New System.Drawing.Point(7, 16)
        Me.cboBiasMode.Name = "cboBiasMode"
        Me.cboBiasMode.Size = New System.Drawing.Size(121, 23)
        Me.cboBiasMode.TabIndex = 2
        '
        'rbCV
        '
        Me.rbCV.AutoSize = True
        Me.rbCV.Checked = True
        Me.rbCV.Location = New System.Drawing.Point(8, 20)
        Me.rbCV.Name = "rbCV"
        Me.rbCV.Size = New System.Drawing.Size(41, 19)
        Me.rbCV.TabIndex = 1
        Me.rbCV.TabStop = True
        Me.rbCV.Text = "CV"
        Me.rbCV.UseVisualStyleBackColor = True
        Me.rbCV.Visible = False
        '
        'rbCC
        '
        Me.rbCC.AutoSize = True
        Me.rbCC.Location = New System.Drawing.Point(77, 20)
        Me.rbCC.Name = "rbCC"
        Me.rbCC.Size = New System.Drawing.Size(41, 19)
        Me.rbCC.TabIndex = 0
        Me.rbCC.Text = "CC"
        Me.rbCC.UseVisualStyleBackColor = True
        Me.rbCC.Visible = False
        '
        'gbTerminalMode
        '
        Me.gbTerminalMode.Controls.Add(Me.rbRear)
        Me.gbTerminalMode.Controls.Add(Me.rbFront)
        Me.gbTerminalMode.Location = New System.Drawing.Point(334, 20)
        Me.gbTerminalMode.Name = "gbTerminalMode"
        Me.gbTerminalMode.Size = New System.Drawing.Size(142, 47)
        Me.gbTerminalMode.TabIndex = 15
        Me.gbTerminalMode.TabStop = False
        Me.gbTerminalMode.Text = "Terminal Mode"
        '
        'rbRear
        '
        Me.rbRear.AutoSize = True
        Me.rbRear.Checked = True
        Me.rbRear.Location = New System.Drawing.Point(8, 20)
        Me.rbRear.Name = "rbRear"
        Me.rbRear.Size = New System.Drawing.Size(52, 19)
        Me.rbRear.TabIndex = 1
        Me.rbRear.TabStop = True
        Me.rbRear.Text = "Rear"
        Me.rbRear.UseVisualStyleBackColor = True
        '
        'rbFront
        '
        Me.rbFront.AutoSize = True
        Me.rbFront.Location = New System.Drawing.Point(77, 20)
        Me.rbFront.Name = "rbFront"
        Me.rbFront.Size = New System.Drawing.Size(54, 19)
        Me.rbFront.TabIndex = 0
        Me.rbFront.Text = "Front"
        Me.rbFront.UseVisualStyleBackColor = True
        '
        'gbWireMode
        '
        Me.gbWireMode.Controls.Add(Me.rb2Wire)
        Me.gbWireMode.Controls.Add(Me.rb4Wire)
        Me.gbWireMode.Location = New System.Drawing.Point(166, 18)
        Me.gbWireMode.Name = "gbWireMode"
        Me.gbWireMode.Size = New System.Drawing.Size(148, 47)
        Me.gbWireMode.TabIndex = 14
        Me.gbWireMode.TabStop = False
        Me.gbWireMode.Text = "Wire Mode"
        '
        'rb2Wire
        '
        Me.rb2Wire.AutoSize = True
        Me.rb2Wire.Checked = True
        Me.rb2Wire.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rb2Wire.Location = New System.Drawing.Point(8, 20)
        Me.rb2Wire.Name = "rb2Wire"
        Me.rb2Wire.Size = New System.Drawing.Size(62, 19)
        Me.rb2Wire.TabIndex = 1
        Me.rb2Wire.TabStop = True
        Me.rb2Wire.Text = "2-Wire"
        Me.rb2Wire.UseVisualStyleBackColor = True
        '
        'rb4Wire
        '
        Me.rb4Wire.AutoSize = True
        Me.rb4Wire.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rb4Wire.Location = New System.Drawing.Point(77, 20)
        Me.rb4Wire.Name = "rb4Wire"
        Me.rb4Wire.Size = New System.Drawing.Size(62, 19)
        Me.rb4Wire.TabIndex = 0
        Me.rb4Wire.Text = "4-Wire"
        Me.rb4Wire.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cbIntegTime)
        Me.GroupBox8.Controls.Add(Me.cbAutoDelay_Measure)
        Me.GroupBox8.Controls.Add(Me.lblIntegTime)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.cbAutoRange_Measure)
        Me.GroupBox8.Controls.Add(Me.tbNumofMeasData)
        Me.GroupBox8.Controls.Add(Me.tbMeasDelay)
        Me.GroupBox8.Controls.Add(Me.tbIntegTime)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.cbAutoRange_Source)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Location = New System.Drawing.Point(243, 66)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(287, 183)
        Me.GroupBox8.TabIndex = 13
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Measure"
        '
        'cbIntegTime
        '
        Me.cbIntegTime.FormattingEnabled = True
        Me.cbIntegTime.Location = New System.Drawing.Point(182, 154)
        Me.cbIntegTime.Name = "cbIntegTime"
        Me.cbIntegTime.Size = New System.Drawing.Size(94, 23)
        Me.cbIntegTime.TabIndex = 37
        Me.cbIntegTime.Text = "Nothing"
        '
        'cbAutoDelay_Measure
        '
        Me.cbAutoDelay_Measure.AutoSize = True
        Me.cbAutoDelay_Measure.Checked = True
        Me.cbAutoDelay_Measure.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAutoDelay_Measure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAutoDelay_Measure.Location = New System.Drawing.Point(80, 117)
        Me.cbAutoDelay_Measure.Name = "cbAutoDelay_Measure"
        Me.cbAutoDelay_Measure.Size = New System.Drawing.Size(117, 19)
        Me.cbAutoDelay_Measure.TabIndex = 11
        Me.cbAutoDelay_Measure.Text = "Auto Meas Delay"
        Me.cbAutoDelay_Measure.UseVisualStyleBackColor = True
        '
        'lblIntegTime
        '
        Me.lblIntegTime.AutoSize = True
        Me.lblIntegTime.Location = New System.Drawing.Point(251, 71)
        Me.lblIntegTime.Name = "lblIntegTime"
        Me.lblIntegTime.Size = New System.Drawing.Size(29, 15)
        Me.lblIntegTime.TabIndex = 10
        Me.lblIntegTime.Text = "Sec"
        Me.lblIntegTime.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Number of Meas Data Points"
        '
        'cbAutoRange_Measure
        '
        Me.cbAutoRange_Measure.AutoSize = True
        Me.cbAutoRange_Measure.Checked = True
        Me.cbAutoRange_Measure.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAutoRange_Measure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAutoRange_Measure.Location = New System.Drawing.Point(80, 95)
        Me.cbAutoRange_Measure.Name = "cbAutoRange_Measure"
        Me.cbAutoRange_Measure.Size = New System.Drawing.Size(88, 19)
        Me.cbAutoRange_Measure.TabIndex = 9
        Me.cbAutoRange_Measure.Text = "Auto Range"
        Me.cbAutoRange_Measure.UseVisualStyleBackColor = True
        Me.cbAutoRange_Measure.Visible = False
        '
        'tbNumofMeasData
        '
        Me.tbNumofMeasData.BackColor = System.Drawing.Color.White
        Me.tbNumofMeasData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbNumofMeasData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumofMeasData.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbNumofMeasData.Location = New System.Drawing.Point(182, 14)
        Me.tbNumofMeasData.Name = "tbNumofMeasData"
        Me.tbNumofMeasData.Size = New System.Drawing.Size(63, 21)
        Me.tbNumofMeasData.TabIndex = 0
        Me.tbNumofMeasData.Text = "100"
        Me.tbNumofMeasData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbMeasDelay
        '
        Me.tbMeasDelay.BackColor = System.Drawing.Color.White
        Me.tbMeasDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbMeasDelay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMeasDelay.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbMeasDelay.Location = New System.Drawing.Point(182, 41)
        Me.tbMeasDelay.Name = "tbMeasDelay"
        Me.tbMeasDelay.Size = New System.Drawing.Size(63, 21)
        Me.tbMeasDelay.TabIndex = 1
        Me.tbMeasDelay.Text = "0.1"
        Me.tbMeasDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbIntegTime
        '
        Me.tbIntegTime.BackColor = System.Drawing.Color.White
        Me.tbIntegTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbIntegTime.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbIntegTime.Location = New System.Drawing.Point(182, 68)
        Me.tbIntegTime.Name = "tbIntegTime"
        Me.tbIntegTime.Size = New System.Drawing.Size(63, 21)
        Me.tbIntegTime.TabIndex = 2
        Me.tbIntegTime.Text = "1"
        Me.tbIntegTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(78, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 15)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Integration Time"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(251, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 15)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Sec"
        '
        'cbAutoRange_Source
        '
        Me.cbAutoRange_Source.AutoSize = True
        Me.cbAutoRange_Source.Checked = True
        Me.cbAutoRange_Source.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAutoRange_Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbAutoRange_Source.Location = New System.Drawing.Point(80, 141)
        Me.cbAutoRange_Source.Name = "cbAutoRange_Source"
        Me.cbAutoRange_Source.Size = New System.Drawing.Size(88, 19)
        Me.cbAutoRange_Source.TabIndex = 9
        Me.cbAutoRange_Source.Text = "Auto Range"
        Me.cbAutoRange_Source.UseVisualStyleBackColor = True
        Me.cbAutoRange_Source.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(83, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 15)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Measure Delay"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbNumofpulse)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.tbPulseofftime)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.tbPulseontime)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.tbSourceDelay)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.tbVoltLimit)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.tbCurrentLimit)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Location = New System.Drawing.Point(14, 66)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(222, 183)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Source"
        '
        'tbNumofpulse
        '
        Me.tbNumofpulse.BackColor = System.Drawing.Color.White
        Me.tbNumofpulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbNumofpulse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumofpulse.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbNumofpulse.Location = New System.Drawing.Point(109, 150)
        Me.tbNumofpulse.Name = "tbNumofpulse"
        Me.tbNumofpulse.Size = New System.Drawing.Size(72, 21)
        Me.tbNumofpulse.TabIndex = 16
        Me.tbNumofpulse.Text = "1"
        Me.tbNumofpulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Num of Pulse"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(185, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 15)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Sec"
        '
        'tbPulseofftime
        '
        Me.tbPulseofftime.BackColor = System.Drawing.Color.White
        Me.tbPulseofftime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPulseofftime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPulseofftime.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbPulseofftime.Location = New System.Drawing.Point(109, 123)
        Me.tbPulseofftime.Name = "tbPulseofftime"
        Me.tbPulseofftime.Size = New System.Drawing.Size(72, 21)
        Me.tbPulseofftime.TabIndex = 13
        Me.tbPulseofftime.Text = "0.3"
        Me.tbPulseofftime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 124)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 15)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Pulse off Time"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(185, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 15)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Sec"
        '
        'tbPulseontime
        '
        Me.tbPulseontime.BackColor = System.Drawing.Color.White
        Me.tbPulseontime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPulseontime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPulseontime.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbPulseontime.Location = New System.Drawing.Point(109, 96)
        Me.tbPulseontime.Name = "tbPulseontime"
        Me.tbPulseontime.Size = New System.Drawing.Size(72, 21)
        Me.tbPulseontime.TabIndex = 10
        Me.tbPulseontime.Text = "0.1"
        Me.tbPulseontime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 15)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Pulse on Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Source Delay"
        '
        'tbSourceDelay
        '
        Me.tbSourceDelay.BackColor = System.Drawing.Color.White
        Me.tbSourceDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSourceDelay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSourceDelay.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSourceDelay.Location = New System.Drawing.Point(109, 15)
        Me.tbSourceDelay.Name = "tbSourceDelay"
        Me.tbSourceDelay.Size = New System.Drawing.Size(72, 21)
        Me.tbSourceDelay.TabIndex = 0
        Me.tbSourceDelay.Text = "0.1"
        Me.tbSourceDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(186, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "A"
        '
        'tbVoltLimit
        '
        Me.tbVoltLimit.BackColor = System.Drawing.Color.White
        Me.tbVoltLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbVoltLimit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVoltLimit.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbVoltLimit.Location = New System.Drawing.Point(109, 40)
        Me.tbVoltLimit.Name = "tbVoltLimit"
        Me.tbVoltLimit.Size = New System.Drawing.Size(72, 21)
        Me.tbVoltLimit.TabIndex = 1
        Me.tbVoltLimit.Text = "20"
        Me.tbVoltLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(186, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "V"
        '
        'tbCurrentLimit
        '
        Me.tbCurrentLimit.BackColor = System.Drawing.Color.White
        Me.tbCurrentLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCurrentLimit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCurrentLimit.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbCurrentLimit.Location = New System.Drawing.Point(109, 67)
        Me.tbCurrentLimit.Name = "tbCurrentLimit"
        Me.tbCurrentLimit.Size = New System.Drawing.Size(72, 21)
        Me.tbCurrentLimit.TabIndex = 2
        Me.tbCurrentLimit.Text = "1"
        Me.tbCurrentLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Limit(I)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sec"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Limit(V)"
        '
        'ucKeithleySMUSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbKeithley)
        Me.Name = "ucKeithleySMUSettings"
        Me.Size = New System.Drawing.Size(583, 361)
        Me.gbKeithley.ResumeLayout(False)
        Me.gbSMUCH.ResumeLayout(False)
        Me.gbSMUCH.PerformLayout()
        Me.gbRange.ResumeLayout(False)
        Me.gbRange.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbTerminalMode.ResumeLayout(False)
        Me.gbTerminalMode.PerformLayout()
        Me.gbWireMode.ResumeLayout(False)
        Me.gbWireMode.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbKeithley As System.Windows.Forms.GroupBox
    Friend WithEvents gbTerminalMode As System.Windows.Forms.GroupBox
    Friend WithEvents rbRear As System.Windows.Forms.RadioButton
    Friend WithEvents rbFront As System.Windows.Forms.RadioButton
    Friend WithEvents gbWireMode As System.Windows.Forms.GroupBox
    Friend WithEvents rb2Wire As System.Windows.Forms.RadioButton
    Friend WithEvents rb4Wire As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAutoDelay_Measure As System.Windows.Forms.CheckBox
    Friend WithEvents lblIntegTime As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbAutoRange_Measure As System.Windows.Forms.CheckBox
    Friend WithEvents tbNumofMeasData As System.Windows.Forms.TextBox
    Friend WithEvents tbMeasDelay As System.Windows.Forms.TextBox
    Friend WithEvents tbIntegTime As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAutoRange_Source As System.Windows.Forms.CheckBox
    Friend WithEvents tbSourceDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbVoltLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbCurrentLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents rbCV As System.Windows.Forms.RadioButton
    Public WithEvents rbCC As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents cbCurrentRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents cbVoltageRange As System.Windows.Forms.ComboBox
    Private WithEvents cbIntegTime As System.Windows.Forms.ComboBox
    Friend WithEvents gbRange As System.Windows.Forms.GroupBox
    Friend WithEvents gbSMUCH As System.Windows.Forms.GroupBox
    Friend WithEvents rbChA As System.Windows.Forms.RadioButton
    Friend WithEvents rbChB As System.Windows.Forms.RadioButton
    Friend WithEvents tbNumofpulse As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbPulseofftime As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbPulseontime As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents cboBiasMode As System.Windows.Forms.ComboBox

End Class
