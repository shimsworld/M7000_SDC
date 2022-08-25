<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcDacChannel
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
        Me.lbl_realdac1 = New System.Windows.Forms.Label()
        Me.btn_GetDacLow = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSetDAC_Low = New System.Windows.Forms.Button()
        Me.txt_LowDAC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_calget = New System.Windows.Forms.Button()
        Me.btn_calSet = New System.Windows.Forms.Button()
        Me.txt_offset = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_ratio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rdo_ch2 = New System.Windows.Forms.RadioButton()
        Me.rdo_ch1 = New System.Windows.Forms.RadioButton()
        Me.btnOnOff = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_delay = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_width = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_period = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_dacnum2 = New System.Windows.Forms.Label()
        Me.lbl_dacnum1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_realdac2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_HighDAC = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdo_pulseMode = New System.Windows.Forms.RadioButton()
        Me.rdo_dcMode = New System.Windows.Forms.RadioButton()
        Me.Chk_CH = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_realdac1
        '
        Me.lbl_realdac1.AutoEllipsis = True
        Me.lbl_realdac1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_realdac1.ForeColor = System.Drawing.Color.Black
        Me.lbl_realdac1.Location = New System.Drawing.Point(338, 14)
        Me.lbl_realdac1.Name = "lbl_realdac1"
        Me.lbl_realdac1.Size = New System.Drawing.Size(165, 18)
        Me.lbl_realdac1.TabIndex = 34
        Me.lbl_realdac1.Text = " 0"
        Me.lbl_realdac1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_GetDacLow
        '
        Me.btn_GetDacLow.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_GetDacLow.Location = New System.Drawing.Point(548, 13)
        Me.btn_GetDacLow.Name = "btn_GetDacLow"
        Me.btn_GetDacLow.Size = New System.Drawing.Size(75, 47)
        Me.btn_GetDacLow.TabIndex = 32
        Me.btn_GetDacLow.Text = "READ"
        Me.btn_GetDacLow.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(219, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 11)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "V"
        '
        'btnSetDAC_Low
        '
        Me.btnSetDAC_Low.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSetDAC_Low.Location = New System.Drawing.Point(248, 13)
        Me.btnSetDAC_Low.Name = "btnSetDAC_Low"
        Me.btnSetDAC_Low.Size = New System.Drawing.Size(75, 47)
        Me.btnSetDAC_Low.TabIndex = 31
        Me.btnSetDAC_Low.Text = "SET"
        Me.btnSetDAC_Low.UseVisualStyleBackColor = True
        '
        'txt_LowDAC
        '
        Me.txt_LowDAC.Location = New System.Drawing.Point(117, 13)
        Me.txt_LowDAC.Name = "txt_LowDAC"
        Me.txt_LowDAC.Size = New System.Drawing.Size(100, 21)
        Me.txt_LowDAC.TabIndex = 33
        Me.txt_LowDAC.Text = "0"
        Me.txt_LowDAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(509, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 11)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "V"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(97, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(913, 135)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.rdo_ch2)
        Me.GroupBox3.Controls.Add(Me.rdo_ch1)
        Me.GroupBox3.Controls.Add(Me.btnOnOff)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.lbl_dacnum2)
        Me.GroupBox3.Controls.Add(Me.lbl_dacnum1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lbl_realdac2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_HighDAC)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.lbl_realdac1)
        Me.GroupBox3.Controls.Add(Me.btn_GetDacLow)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnSetDAC_Low)
        Me.GroupBox3.Controls.Add(Me.txt_LowDAC)
        Me.GroupBox3.Location = New System.Drawing.Point(115, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(785, 117)
        Me.GroupBox3.TabIndex = 50
        Me.GroupBox3.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_calget)
        Me.GroupBox5.Controls.Add(Me.btn_calSet)
        Me.GroupBox5.Controls.Add(Me.txt_offset)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txt_ratio)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(394, 63)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(378, 43)
        Me.GroupBox5.TabIndex = 56
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cal. Data"
        '
        'btn_calget
        '
        Me.btn_calget.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_calget.Location = New System.Drawing.Point(303, 15)
        Me.btn_calget.Name = "btn_calget"
        Me.btn_calget.Size = New System.Drawing.Size(62, 21)
        Me.btn_calget.TabIndex = 38
        Me.btn_calget.Text = "GET"
        Me.btn_calget.UseVisualStyleBackColor = True
        '
        'btn_calSet
        '
        Me.btn_calSet.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_calSet.Location = New System.Drawing.Point(235, 16)
        Me.btn_calSet.Name = "btn_calSet"
        Me.btn_calSet.Size = New System.Drawing.Size(62, 21)
        Me.btn_calSet.TabIndex = 37
        Me.btn_calSet.Text = "SET"
        Me.btn_calSet.UseVisualStyleBackColor = True
        '
        'txt_offset
        '
        Me.txt_offset.Enabled = False
        Me.txt_offset.Location = New System.Drawing.Point(159, 16)
        Me.txt_offset.Name = "txt_offset"
        Me.txt_offset.Size = New System.Drawing.Size(74, 21)
        Me.txt_offset.TabIndex = 36
        Me.txt_offset.Text = "0.0000000"
        Me.txt_offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(115, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 23)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "OffSet"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_ratio
        '
        Me.txt_ratio.Enabled = False
        Me.txt_ratio.Location = New System.Drawing.Point(42, 17)
        Me.txt_ratio.Name = "txt_ratio"
        Me.txt_ratio.Size = New System.Drawing.Size(74, 21)
        Me.txt_ratio.TabIndex = 34
        Me.txt_ratio.Text = "0.0000000"
        Me.txt_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 23)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ratio"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdo_ch2
        '
        Me.rdo_ch2.AutoSize = True
        Me.rdo_ch2.Location = New System.Drawing.Point(21, 44)
        Me.rdo_ch2.Name = "rdo_ch2"
        Me.rdo_ch2.Size = New System.Drawing.Size(14, 13)
        Me.rdo_ch2.TabIndex = 55
        Me.rdo_ch2.UseVisualStyleBackColor = True
        '
        'rdo_ch1
        '
        Me.rdo_ch1.AutoSize = True
        Me.rdo_ch1.Checked = True
        Me.rdo_ch1.Location = New System.Drawing.Point(21, 16)
        Me.rdo_ch1.Name = "rdo_ch1"
        Me.rdo_ch1.Size = New System.Drawing.Size(14, 13)
        Me.rdo_ch1.TabIndex = 54
        Me.rdo_ch1.TabStop = True
        Me.rdo_ch1.UseVisualStyleBackColor = True
        '
        'btnOnOff
        '
        Me.btnOnOff.BackColor = System.Drawing.Color.Blue
        Me.btnOnOff.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnOnOff.Location = New System.Drawing.Point(629, 13)
        Me.btnOnOff.Name = "btnOnOff"
        Me.btnOnOff.Size = New System.Drawing.Size(75, 47)
        Me.btnOnOff.TabIndex = 51
        Me.btnOnOff.Text = "ON"
        Me.btnOnOff.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_delay)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txt_width)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txt_period)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(16, 63)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(375, 43)
        Me.GroupBox4.TabIndex = 50
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pulse Set"
        '
        'txt_delay
        '
        Me.txt_delay.Location = New System.Drawing.Point(293, 17)
        Me.txt_delay.Name = "txt_delay"
        Me.txt_delay.Size = New System.Drawing.Size(72, 21)
        Me.txt_delay.TabIndex = 38
        Me.txt_delay.Text = "100"
        Me.txt_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(245, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 23)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Delay"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_width
        '
        Me.txt_width.Location = New System.Drawing.Point(171, 17)
        Me.txt_width.Name = "txt_width"
        Me.txt_width.Size = New System.Drawing.Size(72, 21)
        Me.txt_width.TabIndex = 36
        Me.txt_width.Text = "100"
        Me.txt_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(134, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 23)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Width"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_period
        '
        Me.txt_period.Location = New System.Drawing.Point(59, 17)
        Me.txt_period.Name = "txt_period"
        Me.txt_period.Size = New System.Drawing.Size(72, 21)
        Me.txt_period.TabIndex = 34
        Me.txt_period.Text = "100"
        Me.txt_period.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Period"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_dacnum2
        '
        Me.lbl_dacnum2.Location = New System.Drawing.Point(19, 42)
        Me.lbl_dacnum2.Name = "lbl_dacnum2"
        Me.lbl_dacnum2.Size = New System.Drawing.Size(92, 18)
        Me.lbl_dacnum2.TabIndex = 44
        Me.lbl_dacnum2.Text = "DAC 01"
        Me.lbl_dacnum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_dacnum1
        '
        Me.lbl_dacnum1.Location = New System.Drawing.Point(19, 14)
        Me.lbl_dacnum1.Name = "lbl_dacnum1"
        Me.lbl_dacnum1.Size = New System.Drawing.Size(92, 18)
        Me.lbl_dacnum1.TabIndex = 43
        Me.lbl_dacnum1.Text = "DAC 00"
        Me.lbl_dacnum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(509, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 11)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "V"
        '
        'lbl_realdac2
        '
        Me.lbl_realdac2.AutoEllipsis = True
        Me.lbl_realdac2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_realdac2.ForeColor = System.Drawing.Color.Black
        Me.lbl_realdac2.Location = New System.Drawing.Point(338, 41)
        Me.lbl_realdac2.Name = "lbl_realdac2"
        Me.lbl_realdac2.Size = New System.Drawing.Size(165, 18)
        Me.lbl_realdac2.TabIndex = 41
        Me.lbl_realdac2.Text = " 0"
        Me.lbl_realdac2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(219, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 11)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "V"
        '
        'txt_HighDAC
        '
        Me.txt_HighDAC.Location = New System.Drawing.Point(117, 40)
        Me.txt_HighDAC.Name = "txt_HighDAC"
        Me.txt_HighDAC.Size = New System.Drawing.Size(100, 21)
        Me.txt_HighDAC.TabIndex = 40
        Me.txt_HighDAC.Text = "0"
        Me.txt_HighDAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdo_pulseMode)
        Me.GroupBox2.Controls.Add(Me.rdo_dcMode)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(106, 119)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mode"
        '
        'rdo_pulseMode
        '
        Me.rdo_pulseMode.AutoSize = True
        Me.rdo_pulseMode.Location = New System.Drawing.Point(11, 63)
        Me.rdo_pulseMode.Name = "rdo_pulseMode"
        Me.rdo_pulseMode.Size = New System.Drawing.Size(91, 16)
        Me.rdo_pulseMode.TabIndex = 46
        Me.rdo_pulseMode.Text = "Pulse Mode"
        Me.rdo_pulseMode.UseVisualStyleBackColor = True
        '
        'rdo_dcMode
        '
        Me.rdo_dcMode.AutoSize = True
        Me.rdo_dcMode.Checked = True
        Me.rdo_dcMode.Location = New System.Drawing.Point(11, 41)
        Me.rdo_dcMode.Name = "rdo_dcMode"
        Me.rdo_dcMode.Size = New System.Drawing.Size(76, 16)
        Me.rdo_dcMode.TabIndex = 45
        Me.rdo_dcMode.TabStop = True
        Me.rdo_dcMode.Text = "DC Mode"
        Me.rdo_dcMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdo_dcMode.UseVisualStyleBackColor = True
        '
        'Chk_CH
        '
        Me.Chk_CH.Appearance = System.Windows.Forms.Appearance.Button
        Me.Chk_CH.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Chk_CH.Location = New System.Drawing.Point(4, 26)
        Me.Chk_CH.Name = "Chk_CH"
        Me.Chk_CH.Size = New System.Drawing.Size(89, 84)
        Me.Chk_CH.TabIndex = 256
        Me.Chk_CH.Text = "Ch 00"
        Me.Chk_CH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Chk_CH.UseVisualStyleBackColor = True
        '
        'UcDacChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.Chk_CH)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UcDacChannel"
        Me.Size = New System.Drawing.Size(1016, 140)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_realdac1 As System.Windows.Forms.Label
    Friend WithEvents btn_GetDacLow As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSetDAC_Low As System.Windows.Forms.Button
    Friend WithEvents txt_LowDAC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_dacnum2 As System.Windows.Forms.Label
    Friend WithEvents lbl_dacnum1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_realdac2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_HighDAC As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_pulseMode As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_dcMode As System.Windows.Forms.RadioButton
    Friend WithEvents txt_delay As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_width As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_period As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnOnOff As System.Windows.Forms.Button
    Friend WithEvents Chk_CH As System.Windows.Forms.CheckBox
    Friend WithEvents rdo_ch1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_ch2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_calget As System.Windows.Forms.Button
    Friend WithEvents btn_calSet As System.Windows.Forms.Button
    Friend WithEvents txt_offset As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ratio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
