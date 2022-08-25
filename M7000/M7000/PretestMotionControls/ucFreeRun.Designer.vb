<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFreeRun
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
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLimit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBias = New System.Windows.Forms.TextBox()
        Me.btnIvlSweep = New System.Windows.Forms.Button()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.btnCellOff = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.rdoCC = New System.Windows.Forms.RadioButton()
        Me.rdoCV = New System.Windows.Forms.RadioButton()
        Me.chkMotion = New System.Windows.Forms.CheckBox()
        Me.btnCellOn = New System.Windows.Forms.Button()
        Me.cbSelCh = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.GroupBox11)
        Me.GroupBox9.Controls.Add(Me.btnIvlSweep)
        Me.GroupBox9.Controls.Add(Me.btnMeas)
        Me.GroupBox9.Controls.Add(Me.btnCellOff)
        Me.GroupBox9.Controls.Add(Me.GroupBox10)
        Me.GroupBox9.Controls.Add(Me.chkMotion)
        Me.GroupBox9.Controls.Add(Me.btnCellOn)
        Me.GroupBox9.Controls.Add(Me.cbSelCh)
        Me.GroupBox9.Controls.Add(Me.Label1)
        Me.GroupBox9.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(356, 212)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Control"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label4)
        Me.GroupBox11.Controls.Add(Me.Label5)
        Me.GroupBox11.Controls.Add(Me.txtLimit)
        Me.GroupBox11.Controls.Add(Me.Label3)
        Me.GroupBox11.Controls.Add(Me.Label2)
        Me.GroupBox11.Controls.Add(Me.txtBias)
        Me.GroupBox11.Location = New System.Drawing.Point(7, 124)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(190, 78)
        Me.GroupBox11.TabIndex = 10
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Set Value"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(156, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Limit"
        '
        'txtLimit
        '
        Me.txtLimit.Location = New System.Drawing.Point(59, 45)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.Size = New System.Drawing.Size(91, 21)
        Me.txtLimit.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "V"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bias"
        '
        'txtBias
        '
        Me.txtBias.Location = New System.Drawing.Point(59, 18)
        Me.txtBias.Name = "txtBias"
        Me.txtBias.Size = New System.Drawing.Size(91, 21)
        Me.txtBias.TabIndex = 0
        '
        'btnIvlSweep
        '
        Me.btnIvlSweep.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnIvlSweep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIvlSweep.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnIvlSweep.Location = New System.Drawing.Point(224, 160)
        Me.btnIvlSweep.Name = "btnIvlSweep"
        Me.btnIvlSweep.Size = New System.Drawing.Size(123, 36)
        Me.btnIvlSweep.TabIndex = 9
        Me.btnIvlSweep.Text = "IVL Sweep"
        Me.btnIvlSweep.UseVisualStyleBackColor = False
        '
        'btnMeas
        '
        Me.btnMeas.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnMeas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeas.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMeas.Location = New System.Drawing.Point(224, 110)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(123, 36)
        Me.btnMeas.TabIndex = 8
        Me.btnMeas.Text = "Meas"
        Me.btnMeas.UseVisualStyleBackColor = False
        '
        'btnCellOff
        '
        Me.btnCellOff.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnCellOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCellOff.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnCellOff.Location = New System.Drawing.Point(224, 50)
        Me.btnCellOff.Name = "btnCellOff"
        Me.btnCellOff.Size = New System.Drawing.Size(123, 36)
        Me.btnCellOff.TabIndex = 7
        Me.btnCellOff.Text = "Cell OFF"
        Me.btnCellOff.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.rdoCC)
        Me.GroupBox10.Controls.Add(Me.rdoCV)
        Me.GroupBox10.Location = New System.Drawing.Point(7, 79)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(190, 39)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Bias Mode"
        '
        'rdoCC
        '
        Me.rdoCC.AutoSize = True
        Me.rdoCC.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoCC.Location = New System.Drawing.Point(109, 15)
        Me.rdoCC.Name = "rdoCC"
        Me.rdoCC.Size = New System.Drawing.Size(48, 16)
        Me.rdoCC.TabIndex = 1
        Me.rdoCC.TabStop = True
        Me.rdoCC.Text = " CC"
        Me.rdoCC.UseVisualStyleBackColor = True
        '
        'rdoCV
        '
        Me.rdoCV.AutoSize = True
        Me.rdoCV.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoCV.Location = New System.Drawing.Point(39, 15)
        Me.rdoCV.Name = "rdoCV"
        Me.rdoCV.Size = New System.Drawing.Size(42, 16)
        Me.rdoCV.TabIndex = 0
        Me.rdoCV.TabStop = True
        Me.rdoCV.Text = "CV"
        Me.rdoCV.UseVisualStyleBackColor = True
        '
        'chkMotion
        '
        Me.chkMotion.AutoSize = True
        Me.chkMotion.Location = New System.Drawing.Point(16, 52)
        Me.chkMotion.Name = "chkMotion"
        Me.chkMotion.Size = New System.Drawing.Size(62, 16)
        Me.chkMotion.TabIndex = 6
        Me.chkMotion.Text = "Motion"
        Me.chkMotion.UseVisualStyleBackColor = True
        '
        'btnCellOn
        '
        Me.btnCellOn.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnCellOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCellOn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnCellOn.Location = New System.Drawing.Point(224, 15)
        Me.btnCellOn.Name = "btnCellOn"
        Me.btnCellOn.Size = New System.Drawing.Size(123, 36)
        Me.btnCellOn.TabIndex = 5
        Me.btnCellOn.Text = "Cell ON"
        Me.btnCellOn.UseVisualStyleBackColor = False
        '
        'cbSelCh
        '
        Me.cbSelCh.FormattingEnabled = True
        Me.cbSelCh.Location = New System.Drawing.Point(95, 17)
        Me.cbSelCh.Name = "cbSelCh"
        Me.cbSelCh.Size = New System.Drawing.Size(102, 20)
        Me.cbSelCh.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select CH"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 232)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(357, 210)
        Me.GroupBox8.TabIndex = 5
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Position Change"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Meas. T(ms)  :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 12)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "CIE 1976 v    :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "CIE 1976 u    :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "CIE 1931 y    :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "CIE 1931 x    :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Luminance   :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Current  (A)  :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Voltage  (V)  :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox9)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 446)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Free RUN"
        '
        'ucFreeRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucFreeRun"
        Me.Size = New System.Drawing.Size(365, 448)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBias As System.Windows.Forms.TextBox
    Friend WithEvents btnIvlSweep As System.Windows.Forms.Button
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents btnCellOff As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoCC As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCV As System.Windows.Forms.RadioButton
    Friend WithEvents chkMotion As System.Windows.Forms.CheckBox
    Friend WithEvents btnCellOn As System.Windows.Forms.Button
    Friend WithEvents cbSelCh As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
