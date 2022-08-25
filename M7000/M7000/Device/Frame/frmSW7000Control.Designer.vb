<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSW7000Control
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ucCfgRS232 = New CCommLib.ucConfigRs232()
        Me.tbConnectionStatus = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnAllOff = New System.Windows.Forms.Button()
        Me.tbSelectChNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAllOn = New System.Windows.Forms.Button()
        Me.btnSelectOn = New System.Windows.Forms.Button()
        Me.btnSelectOff = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.tbDelay = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbEnd = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbStart = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ucCfgRS232)
        Me.GroupBox5.Controls.Add(Me.tbConnectionStatus)
        Me.GroupBox5.Controls.Add(Me.btnConnection)
        Me.GroupBox5.Controls.Add(Me.btnDisconnection)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 363)
        Me.GroupBox5.TabIndex = 30
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'ucCfgRS232
        '
        Me.ucCfgRS232.BAUDRATE = 19200
        Me.ucCfgRS232.COMPORT = "COM1"
        Me.ucCfgRS232.DATABIT = 8
        Me.ucCfgRS232.Location = New System.Drawing.Point(12, 63)
        Me.ucCfgRS232.Name = "ucCfgRS232"
        Me.ucCfgRS232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucCfgRS232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucCfgRS232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucCfgRS232.Size = New System.Drawing.Size(242, 230)
        Me.ucCfgRS232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucCfgRS232.TabIndex = 6
        Me.ucCfgRS232.Title = "RS232"
        '
        'tbConnectionStatus
        '
        Me.tbConnectionStatus.Location = New System.Drawing.Point(12, 299)
        Me.tbConnectionStatus.Multiline = True
        Me.tbConnectionStatus.Name = "tbConnectionStatus"
        Me.tbConnectionStatus.Size = New System.Drawing.Size(242, 55)
        Me.tbConnectionStatus.TabIndex = 5
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(12, 22)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(116, 35)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(134, 21)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(109, 35)
        Me.btnDisconnection.TabIndex = 1
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnAllOff)
        Me.GroupBox6.Controls.Add(Me.tbSelectChNumber)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.btnAllOn)
        Me.GroupBox6.Controls.Add(Me.btnSelectOn)
        Me.GroupBox6.Controls.Add(Me.btnSelectOff)
        Me.GroupBox6.Location = New System.Drawing.Point(299, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(383, 117)
        Me.GroupBox6.TabIndex = 32
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Control"
        '
        'btnAllOff
        '
        Me.btnAllOff.Location = New System.Drawing.Point(147, 62)
        Me.btnAllOff.Name = "btnAllOff"
        Me.btnAllOff.Size = New System.Drawing.Size(108, 39)
        Me.btnAllOff.TabIndex = 34
        Me.btnAllOff.Text = "All_OFF"
        Me.btnAllOff.UseVisualStyleBackColor = True
        '
        'tbSelectChNumber
        '
        Me.tbSelectChNumber.Location = New System.Drawing.Point(92, 19)
        Me.tbSelectChNumber.Name = "tbSelectChNumber"
        Me.tbSelectChNumber.Size = New System.Drawing.Size(79, 21)
        Me.tbSelectChNumber.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 12)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "chNumber :"
        '
        'btnAllOn
        '
        Me.btnAllOn.Location = New System.Drawing.Point(16, 62)
        Me.btnAllOn.Name = "btnAllOn"
        Me.btnAllOn.Size = New System.Drawing.Size(116, 39)
        Me.btnAllOn.TabIndex = 31
        Me.btnAllOn.Text = "All_ON"
        Me.btnAllOn.UseVisualStyleBackColor = True
        '
        'btnSelectOn
        '
        Me.btnSelectOn.Location = New System.Drawing.Point(177, 13)
        Me.btnSelectOn.Name = "btnSelectOn"
        Me.btnSelectOn.Size = New System.Drawing.Size(96, 31)
        Me.btnSelectOn.TabIndex = 17
        Me.btnSelectOn.Text = "On"
        Me.btnSelectOn.UseVisualStyleBackColor = True
        '
        'btnSelectOff
        '
        Me.btnSelectOff.Location = New System.Drawing.Point(279, 13)
        Me.btnSelectOff.Name = "btnSelectOff"
        Me.btnSelectOff.Size = New System.Drawing.Size(96, 31)
        Me.btnSelectOff.TabIndex = 10
        Me.btnSelectOff.Text = "Off"
        Me.btnSelectOff.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEnd)
        Me.GroupBox1.Controls.Add(Me.tbDelay)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbEnd)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbStart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(299, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 119)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto Check"
        '
        'btnEnd
        '
        Me.btnEnd.Location = New System.Drawing.Point(177, 67)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(116, 39)
        Me.btnEnd.TabIndex = 34
        Me.btnEnd.Text = "Stop"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'tbDelay
        '
        Me.tbDelay.Location = New System.Drawing.Point(72, 77)
        Me.tbDelay.Name = "tbDelay"
        Me.tbDelay.Size = New System.Drawing.Size(79, 21)
        Me.tbDelay.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 12)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Delay :"
        '
        'tbEnd
        '
        Me.tbEnd.Location = New System.Drawing.Point(72, 49)
        Me.tbEnd.Name = "tbEnd"
        Me.tbEnd.Size = New System.Drawing.Size(79, 21)
        Me.tbEnd.TabIndex = 35
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(177, 19)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(116, 39)
        Me.btnStart.TabIndex = 31
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 12)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "chEnd :"
        '
        'tbStart
        '
        Me.tbStart.Location = New System.Drawing.Point(72, 19)
        Me.tbStart.Name = "tbStart"
        Me.tbStart.Size = New System.Drawing.Size(79, 21)
        Me.tbStart.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "chStart :"
        '
        'frmSW7000Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 444)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmSW7000Control"
        Me.Text = "frmSW7000Control"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ucCfgRS232 As CCommLib.ucConfigRs232
    Friend WithEvents tbConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAllOff As System.Windows.Forms.Button
    Friend WithEvents tbSelectChNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAllOn As System.Windows.Forms.Button
    Friend WithEvents btnSelectOn As System.Windows.Forms.Button
    Friend WithEvents btnSelectOff As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents tbStart As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tbDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
