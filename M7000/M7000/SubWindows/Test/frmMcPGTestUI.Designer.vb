<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMcPGTestUI
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
        Me.btn_off = New System.Windows.Forms.Button()
        Me.tbChannel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbSelGroup = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.cbSelDevice = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbPDCurrent = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbCurrent05 = New System.Windows.Forms.TextBox()
        Me.tbVolt05 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbCurrent04 = New System.Windows.Forms.TextBox()
        Me.tbVolt04 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbCurrent03 = New System.Windows.Forms.TextBox()
        Me.tbVolt03 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCurrent02 = New System.Windows.Forms.TextBox()
        Me.tbVolt02 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbCurrent01 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbVolt01 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(706, 12)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(105, 34)
        Me.btn_off.TabIndex = 92
        Me.btn_off.Text = "OFF"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'tbChannel
        '
        Me.tbChannel.Location = New System.Drawing.Point(544, 19)
        Me.tbChannel.Name = "tbChannel"
        Me.tbChannel.Size = New System.Drawing.Size(45, 21)
        Me.tbChannel.TabIndex = 87
        Me.tbChannel.Text = "0"
        Me.tbChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(474, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 11)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Channel :"
        '
        'cbSelGroup
        '
        Me.cbSelGroup.FormattingEnabled = True
        Me.cbSelGroup.Location = New System.Drawing.Point(91, 20)
        Me.cbSelGroup.Name = "cbSelGroup"
        Me.cbSelGroup.Size = New System.Drawing.Size(81, 20)
        Me.cbSelGroup.TabIndex = 85
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.Location = New System.Drawing.Point(27, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 11)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Device :"
        '
        'btnMeas
        '
        Me.btnMeas.Location = New System.Drawing.Point(943, 11)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(105, 34)
        Me.btnMeas.TabIndex = 83
        Me.btnMeas.Text = "MEAS."
        Me.btnMeas.UseVisualStyleBackColor = True
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(595, 12)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(105, 34)
        Me.btnSet.TabIndex = 82
        Me.btnSet.Text = "SET"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(319, 13)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(105, 34)
        Me.btnDisconnection.TabIndex = 81
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(208, 12)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(105, 34)
        Me.btnConnection.TabIndex = 80
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'cbSelDevice
        '
        Me.cbSelDevice.FormattingEnabled = True
        Me.cbSelDevice.Location = New System.Drawing.Point(91, 20)
        Me.cbSelDevice.Name = "cbSelDevice"
        Me.cbSelDevice.Size = New System.Drawing.Size(81, 20)
        Me.cbSelDevice.TabIndex = 85
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbPDCurrent)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.tbCurrent05)
        Me.GroupBox1.Controls.Add(Me.tbVolt05)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbCurrent04)
        Me.GroupBox1.Controls.Add(Me.tbVolt04)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbCurrent03)
        Me.GroupBox1.Controls.Add(Me.tbVolt03)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbCurrent02)
        Me.GroupBox1.Controls.Add(Me.tbVolt02)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbCurrent01)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbVolt01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(825, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 390)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Measured Data"
        '
        'tbPDCurrent
        '
        Me.tbPDCurrent.Location = New System.Drawing.Point(59, 183)
        Me.tbPDCurrent.Name = "tbPDCurrent"
        Me.tbPDCurrent.Size = New System.Drawing.Size(119, 21)
        Me.tbPDCurrent.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "PD I"
        '
        'tbCurrent05
        '
        Me.tbCurrent05.Location = New System.Drawing.Point(184, 150)
        Me.tbCurrent05.Name = "tbCurrent05"
        Me.tbCurrent05.Size = New System.Drawing.Size(119, 21)
        Me.tbCurrent05.TabIndex = 16
        '
        'tbVolt05
        '
        Me.tbVolt05.Location = New System.Drawing.Point(59, 150)
        Me.tbVolt05.Name = "tbVolt05"
        Me.tbVolt05.Size = New System.Drawing.Size(119, 21)
        Me.tbVolt05.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ch05"
        '
        'tbCurrent04
        '
        Me.tbCurrent04.Location = New System.Drawing.Point(184, 123)
        Me.tbCurrent04.Name = "tbCurrent04"
        Me.tbCurrent04.Size = New System.Drawing.Size(119, 21)
        Me.tbCurrent04.TabIndex = 13
        '
        'tbVolt04
        '
        Me.tbVolt04.Location = New System.Drawing.Point(59, 123)
        Me.tbVolt04.Name = "tbVolt04"
        Me.tbVolt04.Size = New System.Drawing.Size(119, 21)
        Me.tbVolt04.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 12)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Ch04"
        '
        'tbCurrent03
        '
        Me.tbCurrent03.Location = New System.Drawing.Point(184, 96)
        Me.tbCurrent03.Name = "tbCurrent03"
        Me.tbCurrent03.Size = New System.Drawing.Size(119, 21)
        Me.tbCurrent03.TabIndex = 10
        '
        'tbVolt03
        '
        Me.tbVolt03.Location = New System.Drawing.Point(59, 96)
        Me.tbVolt03.Name = "tbVolt03"
        Me.tbVolt03.Size = New System.Drawing.Size(119, 21)
        Me.tbVolt03.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Ch03"
        '
        'tbCurrent02
        '
        Me.tbCurrent02.Location = New System.Drawing.Point(184, 69)
        Me.tbCurrent02.Name = "tbCurrent02"
        Me.tbCurrent02.Size = New System.Drawing.Size(119, 21)
        Me.tbCurrent02.TabIndex = 7
        '
        'tbVolt02
        '
        Me.tbVolt02.Location = New System.Drawing.Point(59, 69)
        Me.tbVolt02.Name = "tbVolt02"
        Me.tbVolt02.Size = New System.Drawing.Size(119, 21)
        Me.tbVolt02.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Ch02"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Current"
        '
        'tbCurrent01
        '
        Me.tbCurrent01.Location = New System.Drawing.Point(184, 42)
        Me.tbCurrent01.Name = "tbCurrent01"
        Me.tbCurrent01.Size = New System.Drawing.Size(119, 21)
        Me.tbCurrent01.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Voltage"
        '
        'tbVolt01
        '
        Me.tbVolt01.Location = New System.Drawing.Point(59, 42)
        Me.tbVolt01.Name = "tbVolt01"
        Me.tbVolt01.Size = New System.Drawing.Size(119, 21)
        Me.tbVolt01.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ch01"
        '
        'frmMcPGTestUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 644)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.tbChannel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbSelGroup)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnMeas)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.btnDisconnection)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "frmMcPGTestUI"
        Me.Text = "frmPGTestUI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_off As System.Windows.Forms.Button
    Friend WithEvents tbChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbSelGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents cbSelDevice As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbPDCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent05 As System.Windows.Forms.TextBox
    Friend WithEvents tbVolt05 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent04 As System.Windows.Forms.TextBox
    Friend WithEvents tbVolt04 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent03 As System.Windows.Forms.TextBox
    Friend WithEvents tbVolt03 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent02 As System.Windows.Forms.TextBox
    Friend WithEvents tbVolt02 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbCurrent01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbVolt01 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
