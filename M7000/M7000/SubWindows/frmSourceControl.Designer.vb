<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSourceControl
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
        Me.gbSrcControl = New System.Windows.Forms.GroupBox()
        Me.btnLTSourceAllOff = New System.Windows.Forms.Button()
        Me.btnOFF = New System.Windows.Forms.Button()
        Me.btnON = New System.Windows.Forms.Button()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UcKeithleySMUSettings = New CSMULib.ucKeithleySMUSettings()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbCurrent = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.tbVoltage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbSrcControl.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSrcControl
        '
        Me.gbSrcControl.Controls.Add(Me.btnLTSourceAllOff)
        Me.gbSrcControl.Controls.Add(Me.btnOFF)
        Me.gbSrcControl.Controls.Add(Me.btnON)
        Me.gbSrcControl.Controls.Add(Me.tbBias)
        Me.gbSrcControl.Controls.Add(Me.Label3)
        Me.gbSrcControl.Controls.Add(Me.UcKeithleySMUSettings)
        Me.gbSrcControl.Controls.Add(Me.cbChannel)
        Me.gbSrcControl.Controls.Add(Me.Label1)
        Me.gbSrcControl.Location = New System.Drawing.Point(3, 3)
        Me.gbSrcControl.Name = "gbSrcControl"
        Me.gbSrcControl.Size = New System.Drawing.Size(585, 349)
        Me.gbSrcControl.TabIndex = 62
        Me.gbSrcControl.TabStop = False
        Me.gbSrcControl.Text = "Source"
        '
        'btnLTSourceAllOff
        '
        Me.btnLTSourceAllOff.Location = New System.Drawing.Point(339, 25)
        Me.btnLTSourceAllOff.Name = "btnLTSourceAllOff"
        Me.btnLTSourceAllOff.Size = New System.Drawing.Size(108, 38)
        Me.btnLTSourceAllOff.TabIndex = 66
        Me.btnLTSourceAllOff.Text = "Lifetime Source ALL OFF"
        Me.btnLTSourceAllOff.UseVisualStyleBackColor = True
        '
        'btnOFF
        '
        Me.btnOFF.Location = New System.Drawing.Point(270, 25)
        Me.btnOFF.Name = "btnOFF"
        Me.btnOFF.Size = New System.Drawing.Size(64, 38)
        Me.btnOFF.TabIndex = 65
        Me.btnOFF.Text = "OFF"
        Me.btnOFF.UseVisualStyleBackColor = True
        '
        'btnON
        '
        Me.btnON.Location = New System.Drawing.Point(201, 25)
        Me.btnON.Name = "btnON"
        Me.btnON.Size = New System.Drawing.Size(64, 38)
        Me.btnON.TabIndex = 63
        Me.btnON.Text = "ON"
        Me.btnON.UseVisualStyleBackColor = True
        '
        'tbBias
        '
        Me.tbBias.Location = New System.Drawing.Point(105, 48)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(80, 20)
        Me.tbBias.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Bias : "
        '
        'UcKeithleySMUSettings
        '
        Me.UcKeithleySMUSettings.Location = New System.Drawing.Point(7, 79)
        Me.UcKeithleySMUSettings.Name = "UcKeithleySMUSettings"
        Me.UcKeithleySMUSettings.Size = New System.Drawing.Size(552, 259)
        Me.UcKeithleySMUSettings.TabIndex = 60
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(105, 18)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(70, 21)
        Me.cbChannel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Select Channel : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbCurrent)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnMeas)
        Me.GroupBox1.Controls.Add(Me.tbVoltage)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 358)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 61)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Measurement"
        '
        'tbCurrent
        '
        Me.tbCurrent.Location = New System.Drawing.Point(213, 22)
        Me.tbCurrent.Name = "tbCurrent"
        Me.tbCurrent.Size = New System.Drawing.Size(80, 20)
        Me.tbCurrent.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(160, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Current :"
        '
        'btnMeas
        '
        Me.btnMeas.Location = New System.Drawing.Point(327, 14)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(79, 38)
        Me.btnMeas.TabIndex = 64
        Me.btnMeas.Text = "MEASURE"
        Me.btnMeas.UseVisualStyleBackColor = True
        '
        'tbVoltage
        '
        Me.tbVoltage.Location = New System.Drawing.Point(63, 22)
        Me.tbVoltage.Name = "tbVoltage"
        Me.tbVoltage.Size = New System.Drawing.Size(80, 20)
        Me.tbVoltage.TabIndex = 67
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Voltage :"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(509, 425)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 38)
        Me.btnClose.TabIndex = 70
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmSourceControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 467)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gbSrcControl)
        Me.Name = "frmSourceControl"
        Me.Text = "Source Control Windows"
        Me.gbSrcControl.ResumeLayout(False)
        Me.gbSrcControl.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSrcControl As System.Windows.Forms.GroupBox
    Friend WithEvents btnOFF As System.Windows.Forms.Button
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents btnON As System.Windows.Forms.Button
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UcKeithleySMUSettings As CSMULib.ucKeithleySMUSettings
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbVoltage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnLTSourceAllOff As System.Windows.Forms.Button
End Class
