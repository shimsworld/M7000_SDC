<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEIPPGControl
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
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEIPPGControl))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnSelectOn = New System.Windows.Forms.Button()
        Me.btnSelectOff = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ucCfgRS232 = New CCommLib.ucConfigRs232()
        Me.tbConnectionStatus = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnSelectOn)
        Me.GroupBox6.Controls.Add(Me.btnSelectOff)
        Me.GroupBox6.Location = New System.Drawing.Point(299, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(285, 78)
        Me.GroupBox6.TabIndex = 38
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Control"
        '
        'btnSelectOn
        '
        Me.btnSelectOn.Location = New System.Drawing.Point(23, 22)
        Me.btnSelectOn.Name = "btnSelectOn"
        Me.btnSelectOn.Size = New System.Drawing.Size(116, 41)
        Me.btnSelectOn.TabIndex = 17
        Me.btnSelectOn.Text = "On"
        Me.btnSelectOn.UseVisualStyleBackColor = True
        '
        'btnSelectOff
        '
        Me.btnSelectOff.Location = New System.Drawing.Point(154, 22)
        Me.btnSelectOff.Name = "btnSelectOff"
        Me.btnSelectOff.Size = New System.Drawing.Size(108, 39)
        Me.btnSelectOff.TabIndex = 10
        Me.btnSelectOff.Text = "Off"
        Me.btnSelectOff.UseVisualStyleBackColor = True
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
        Me.GroupBox5.TabIndex = 37
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'ucCfgRS232
        '
        Me.ucCfgRS232.BAUDRATE = 19200
        Me.ucCfgRS232.COMPORT = "COM3"
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
        'frmEIPPGControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 378)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEIPPGControl"
        Me.Text = "frmEIPPGControl"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnSelectOn As Button
    Friend WithEvents btnSelectOff As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ucCfgRS232 As CCommLib.ucConfigRs232
    Friend WithEvents tbConnectionStatus As TextBox
    Friend WithEvents btnConnection As Button
    Friend WithEvents btnDisconnection As Button
End Class
