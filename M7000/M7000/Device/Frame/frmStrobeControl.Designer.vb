<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStrobeControl
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbLevel = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnRemote = New System.Windows.Forms.Button()
        Me.btnGetBright = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
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
        Me.GroupBox5.TabIndex = 31
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Location = New System.Drawing.Point(303, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 35)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "OFF"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'tbLevel
        '
        Me.tbLevel.Location = New System.Drawing.Point(303, 93)
        Me.tbLevel.Multiline = True
        Me.tbLevel.Name = "tbLevel"
        Me.tbLevel.Size = New System.Drawing.Size(170, 41)
        Me.tbLevel.TabIndex = 34
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(303, 140)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 35)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Set"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnRemote
        '
        Me.btnRemote.BackColor = System.Drawing.Color.Gainsboro
        Me.btnRemote.Location = New System.Drawing.Point(425, 33)
        Me.btnRemote.Name = "btnRemote"
        Me.btnRemote.Size = New System.Drawing.Size(116, 35)
        Me.btnRemote.TabIndex = 36
        Me.btnRemote.Text = "Local"
        Me.btnRemote.UseVisualStyleBackColor = False
        '
        'btnGetBright
        '
        Me.btnGetBright.Location = New System.Drawing.Point(425, 140)
        Me.btnGetBright.Name = "btnGetBright"
        Me.btnGetBright.Size = New System.Drawing.Size(116, 35)
        Me.btnGetBright.TabIndex = 37
        Me.btnGetBright.Text = "Get"
        Me.btnGetBright.UseVisualStyleBackColor = True
        '
        'frmStrobeControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 414)
        Me.Controls.Add(Me.btnGetBright)
        Me.Controls.Add(Me.btnRemote)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tbLevel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmStrobeControl"
        Me.Text = "frmStrobeContro"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ucCfgRS232 As CCommLib.ucConfigRs232
    Friend WithEvents tbConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbLevel As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnRemote As System.Windows.Forms.Button
    Friend WithEvents btnGetBright As System.Windows.Forms.Button
End Class
