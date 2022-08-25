<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSinglePointMeas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbFillFactor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbSampleHight = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbSampleWidth = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkLMeas = New System.Windows.Forms.CheckBox()
        Me.tbQE = New System.Windows.Forms.TextBox()
        Me.tbCurrentdensity = New System.Windows.Forms.TextBox()
        Me.tbCIE1976v = New System.Windows.Forms.TextBox()
        Me.tbCIE1976u = New System.Windows.Forms.TextBox()
        Me.tbCIE1931y = New System.Windows.Forms.TextBox()
        Me.tbCIE1931x = New System.Windows.Forms.TextBox()
        Me.tbCdPerAmpare = New System.Windows.Forms.TextBox()
        Me.tbLuminance = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCurrent = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.tbVoltage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbSrcControl = New System.Windows.Forms.GroupBox()
        Me.btnOFF = New System.Windows.Forms.Button()
        Me.btnON = New System.Windows.Forms.Button()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.UcKeithleySMUSettings = New CSMULib.ucKeithleySMUSettings()
        Me.GroupBox1.SuspendLayout()
        Me.gbSrcControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbFillFactor)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.tbSampleHight)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.tbSampleWidth)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.chkLMeas)
        Me.GroupBox1.Controls.Add(Me.tbQE)
        Me.GroupBox1.Controls.Add(Me.tbCurrentdensity)
        Me.GroupBox1.Controls.Add(Me.tbCIE1976v)
        Me.GroupBox1.Controls.Add(Me.tbCIE1976u)
        Me.GroupBox1.Controls.Add(Me.tbCIE1931y)
        Me.GroupBox1.Controls.Add(Me.tbCIE1931x)
        Me.GroupBox1.Controls.Add(Me.tbCdPerAmpare)
        Me.GroupBox1.Controls.Add(Me.tbLuminance)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbCurrent)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnMeas)
        Me.GroupBox1.Controls.Add(Me.tbVoltage)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(552, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 322)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Measurement"
        '
        'tbFillFactor
        '
        Me.tbFillFactor.Location = New System.Drawing.Point(339, 174)
        Me.tbFillFactor.Name = "tbFillFactor"
        Me.tbFillFactor.Size = New System.Drawing.Size(46, 21)
        Me.tbFillFactor.TabIndex = 93
        Me.tbFillFactor.Text = "100"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(249, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 12)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "Fill Factor(%) :"
        '
        'tbSampleHight
        '
        Me.tbSampleHight.Location = New System.Drawing.Point(339, 147)
        Me.tbSampleHight.Name = "tbSampleHight"
        Me.tbSampleHight.Size = New System.Drawing.Size(46, 21)
        Me.tbSampleHight.TabIndex = 91
        Me.tbSampleHight.Text = "2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(264, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 12)
        Me.Label14.TabIndex = 90
        Me.Label14.Text = "Hight(mm) :"
        '
        'tbSampleWidth
        '
        Me.tbSampleWidth.Location = New System.Drawing.Point(338, 120)
        Me.tbSampleWidth.Name = "tbSampleWidth"
        Me.tbSampleWidth.Size = New System.Drawing.Size(46, 21)
        Me.tbSampleWidth.TabIndex = 89
        Me.tbSampleWidth.Text = "2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(261, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 12)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "Width(mm) :"
        '
        'chkLMeas
        '
        Me.chkLMeas.AutoSize = True
        Me.chkLMeas.Location = New System.Drawing.Point(258, 23)
        Me.chkLMeas.Name = "chkLMeas"
        Me.chkLMeas.Size = New System.Drawing.Size(67, 16)
        Me.chkLMeas.TabIndex = 87
        Me.chkLMeas.Text = "L Meas"
        Me.chkLMeas.UseVisualStyleBackColor = True
        '
        'tbQE
        '
        Me.tbQE.Location = New System.Drawing.Point(149, 262)
        Me.tbQE.Name = "tbQE"
        Me.tbQE.Size = New System.Drawing.Size(93, 21)
        Me.tbQE.TabIndex = 86
        '
        'tbCurrentdensity
        '
        Me.tbCurrentdensity.Location = New System.Drawing.Point(149, 73)
        Me.tbCurrentdensity.Name = "tbCurrentdensity"
        Me.tbCurrentdensity.Size = New System.Drawing.Size(93, 21)
        Me.tbCurrentdensity.TabIndex = 85
        '
        'tbCIE1976v
        '
        Me.tbCIE1976v.Location = New System.Drawing.Point(149, 233)
        Me.tbCIE1976v.Name = "tbCIE1976v"
        Me.tbCIE1976v.Size = New System.Drawing.Size(93, 21)
        Me.tbCIE1976v.TabIndex = 84
        '
        'tbCIE1976u
        '
        Me.tbCIE1976u.Location = New System.Drawing.Point(149, 206)
        Me.tbCIE1976u.Name = "tbCIE1976u"
        Me.tbCIE1976u.Size = New System.Drawing.Size(93, 21)
        Me.tbCIE1976u.TabIndex = 83
        '
        'tbCIE1931y
        '
        Me.tbCIE1931y.Location = New System.Drawing.Point(149, 179)
        Me.tbCIE1931y.Name = "tbCIE1931y"
        Me.tbCIE1931y.Size = New System.Drawing.Size(93, 21)
        Me.tbCIE1931y.TabIndex = 82
        '
        'tbCIE1931x
        '
        Me.tbCIE1931x.Location = New System.Drawing.Point(149, 152)
        Me.tbCIE1931x.Name = "tbCIE1931x"
        Me.tbCIE1931x.Size = New System.Drawing.Size(93, 21)
        Me.tbCIE1931x.TabIndex = 81
        '
        'tbCdPerAmpare
        '
        Me.tbCdPerAmpare.Location = New System.Drawing.Point(149, 125)
        Me.tbCdPerAmpare.Name = "tbCdPerAmpare"
        Me.tbCdPerAmpare.Size = New System.Drawing.Size(93, 21)
        Me.tbCdPerAmpare.TabIndex = 80
        '
        'tbLuminance
        '
        Me.tbLuminance.Location = New System.Drawing.Point(149, 99)
        Me.tbLuminance.Name = "tbLuminance"
        Me.tbLuminance.Size = New System.Drawing.Size(93, 21)
        Me.tbLuminance.TabIndex = 79
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(65, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 12)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "J(mA/cm2) :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(76, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 12)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "CIE1976 v :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(93, 268)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 12)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "QE(%) :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(75, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 12)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "CIE1976 u :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(75, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 12)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "CIE1931 y :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(75, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 12)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "CIE1931 x :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(102, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "cd/A :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 12)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Luminance(cd/m2) :"
        '
        'tbCurrent
        '
        Me.tbCurrent.Location = New System.Drawing.Point(149, 47)
        Me.tbCurrent.Name = "tbCurrent"
        Me.tbCurrent.Size = New System.Drawing.Size(93, 21)
        Me.tbCurrent.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 12)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Current(A) :"
        '
        'btnMeas
        '
        Me.btnMeas.BackColor = System.Drawing.SystemColors.Control
        Me.btnMeas.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMeas.Location = New System.Drawing.Point(257, 45)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(122, 38)
        Me.btnMeas.TabIndex = 64
        Me.btnMeas.Text = "MEASURE"
        Me.btnMeas.UseVisualStyleBackColor = False
        '
        'tbVoltage
        '
        Me.tbVoltage.Location = New System.Drawing.Point(149, 20)
        Me.tbVoltage.Name = "tbVoltage"
        Me.tbVoltage.Size = New System.Drawing.Size(93, 21)
        Me.tbVoltage.TabIndex = 67
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 12)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Voltage(V) :"
        '
        'gbSrcControl
        '
        Me.gbSrcControl.Controls.Add(Me.btnOFF)
        Me.gbSrcControl.Controls.Add(Me.btnON)
        Me.gbSrcControl.Controls.Add(Me.tbBias)
        Me.gbSrcControl.Controls.Add(Me.Label3)
        Me.gbSrcControl.Controls.Add(Me.UcKeithleySMUSettings)
        Me.gbSrcControl.Controls.Add(Me.cbChannel)
        Me.gbSrcControl.Controls.Add(Me.Label1)
        Me.gbSrcControl.Location = New System.Drawing.Point(8, 8)
        Me.gbSrcControl.Name = "gbSrcControl"
        Me.gbSrcControl.Size = New System.Drawing.Size(538, 322)
        Me.gbSrcControl.TabIndex = 69
        Me.gbSrcControl.TabStop = False
        Me.gbSrcControl.Text = "Source"
        '
        'btnOFF
        '
        Me.btnOFF.Location = New System.Drawing.Point(334, 17)
        Me.btnOFF.Name = "btnOFF"
        Me.btnOFF.Size = New System.Drawing.Size(92, 35)
        Me.btnOFF.TabIndex = 65
        Me.btnOFF.Text = "OFF"
        Me.btnOFF.UseVisualStyleBackColor = True
        '
        'btnON
        '
        Me.btnON.Location = New System.Drawing.Point(236, 17)
        Me.btnON.Name = "btnON"
        Me.btnON.Size = New System.Drawing.Size(92, 35)
        Me.btnON.TabIndex = 63
        Me.btnON.Text = "ON"
        Me.btnON.UseVisualStyleBackColor = True
        '
        'tbBias
        '
        Me.tbBias.Location = New System.Drawing.Point(123, 44)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(81, 21)
        Me.tbBias.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Bias : "
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(123, 17)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(81, 20)
        Me.cbChannel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Channel : "
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(853, 336)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 35)
        Me.btnClose.TabIndex = 71
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'UcKeithleySMUSettings
        '
        Me.UcKeithleySMUSettings.Location = New System.Drawing.Point(8, 73)
        Me.UcKeithleySMUSettings.Name = "UcKeithleySMUSettings"
        Me.UcKeithleySMUSettings.Size = New System.Drawing.Size(523, 239)
        Me.UcKeithleySMUSettings.TabIndex = 60
        '
        'frmSinglePointMeas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 377)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbSrcControl)
        Me.Name = "frmSinglePointMeas"
        Me.Text = "Single Point Measurement Windows"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSrcControl.ResumeLayout(False)
        Me.gbSrcControl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbQE As System.Windows.Forms.TextBox
    Friend WithEvents tbCurrentdensity As System.Windows.Forms.TextBox
    Friend WithEvents tbCIE1976v As System.Windows.Forms.TextBox
    Friend WithEvents tbCIE1976u As System.Windows.Forms.TextBox
    Friend WithEvents tbCIE1931y As System.Windows.Forms.TextBox
    Friend WithEvents tbCIE1931x As System.Windows.Forms.TextBox
    Friend WithEvents tbCdPerAmpare As System.Windows.Forms.TextBox
    Friend WithEvents tbLuminance As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents tbVoltage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbSrcControl As System.Windows.Forms.GroupBox
    Friend WithEvents btnOFF As System.Windows.Forms.Button
    Friend WithEvents btnON As System.Windows.Forms.Button
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UcKeithleySMUSettings As CSMULib.ucKeithleySMUSettings
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkLMeas As System.Windows.Forms.CheckBox
    Friend WithEvents tbFillFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbSampleHight As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbSampleWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
