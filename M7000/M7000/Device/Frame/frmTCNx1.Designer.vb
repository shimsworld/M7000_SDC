<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTCNx1
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
        Me.btnGetTemp = New System.Windows.Forms.Button()
        Me.tbGetTemp = New System.Windows.Forms.TextBox()
        Me.btnSetTemp = New System.Windows.Forms.Button()
        Me.tbSetTemp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGetAlarm1Type = New System.Windows.Forms.Button()
        Me.btnGetAlarm1DeadBand = New System.Windows.Forms.Button()
        Me.btnGetAlarm1Value = New System.Windows.Forms.Button()
        Me.btnSetAlarm1DeadBand = New System.Windows.Forms.Button()
        Me.btnSetAlarm1Value = New System.Windows.Forms.Button()
        Me.btnSetAlarm1Type = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbAlarm1Value = New System.Windows.Forms.TextBox()
        Me.tbAlarm1DeadBand = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSelAlarm1Type = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGetTemp)
        Me.GroupBox1.Controls.Add(Me.tbGetTemp)
        Me.GroupBox1.Controls.Add(Me.btnSetTemp)
        Me.GroupBox1.Controls.Add(Me.tbSetTemp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 82)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PV/SV"
        '
        'btnGetTemp
        '
        Me.btnGetTemp.Location = New System.Drawing.Point(236, 43)
        Me.btnGetTemp.Name = "btnGetTemp"
        Me.btnGetTemp.Size = New System.Drawing.Size(82, 28)
        Me.btnGetTemp.TabIndex = 19
        Me.btnGetTemp.Text = "Get Temp"
        Me.btnGetTemp.UseVisualStyleBackColor = True
        '
        'tbGetTemp
        '
        Me.tbGetTemp.Location = New System.Drawing.Point(121, 48)
        Me.tbGetTemp.Name = "tbGetTemp"
        Me.tbGetTemp.Size = New System.Drawing.Size(95, 21)
        Me.tbGetTemp.TabIndex = 18
        Me.tbGetTemp.Text = "0"
        Me.tbGetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSetTemp
        '
        Me.btnSetTemp.Location = New System.Drawing.Point(236, 15)
        Me.btnSetTemp.Name = "btnSetTemp"
        Me.btnSetTemp.Size = New System.Drawing.Size(82, 28)
        Me.btnSetTemp.TabIndex = 15
        Me.btnSetTemp.Text = "Set Temp"
        Me.btnSetTemp.UseVisualStyleBackColor = True
        '
        'tbSetTemp
        '
        Me.tbSetTemp.Location = New System.Drawing.Point(121, 18)
        Me.tbSetTemp.Name = "tbSetTemp"
        Me.tbSetTemp.Size = New System.Drawing.Size(95, 21)
        Me.tbSetTemp.TabIndex = 14
        Me.tbSetTemp.Text = "0"
        Me.tbSetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Get Temperature"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Set Temperature"
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.TextBox1.Location = New System.Drawing.Point(372, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(338, 100)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Controls.Add(Me.tbAddress)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnDisconnection)
        Me.GroupBox2.Controls.Add(Me.btnConnection)
        Me.GroupBox2.Controls.Add(Me.cbBaudRate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbPort)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 100)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Communication"
        '
        'tbAddress
        '
        Me.tbAddress.Location = New System.Drawing.Point(80, 72)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(96, 21)
        Me.tbAddress.TabIndex = 20
        Me.tbAddress.Text = "0"
        Me.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Address :"
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(198, 56)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(135, 31)
        Me.btnDisconnection.TabIndex = 7
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(198, 24)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(135, 31)
        Me.btnConnection.TabIndex = 6
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400"})
        Me.cbBaudRate.Location = New System.Drawing.Point(80, 48)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(96, 20)
        Me.cbBaudRate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BaudRate"
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(80, 24)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(96, 20)
        Me.cbPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGetAlarm1Type)
        Me.GroupBox3.Controls.Add(Me.btnGetAlarm1DeadBand)
        Me.GroupBox3.Controls.Add(Me.btnGetAlarm1Value)
        Me.GroupBox3.Controls.Add(Me.btnSetAlarm1DeadBand)
        Me.GroupBox3.Controls.Add(Me.btnSetAlarm1Value)
        Me.GroupBox3.Controls.Add(Me.btnSetAlarm1Type)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.tbAlarm1Value)
        Me.GroupBox3.Controls.Add(Me.tbAlarm1DeadBand)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cbSelAlarm1Type)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(356, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 112)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Alarm1"
        '
        'btnGetAlarm1Type
        '
        Me.btnGetAlarm1Type.Location = New System.Drawing.Point(295, 15)
        Me.btnGetAlarm1Type.Name = "btnGetAlarm1Type"
        Me.btnGetAlarm1Type.Size = New System.Drawing.Size(51, 28)
        Me.btnGetAlarm1Type.TabIndex = 25
        Me.btnGetAlarm1Type.Text = "Get"
        Me.btnGetAlarm1Type.UseVisualStyleBackColor = True
        '
        'btnGetAlarm1DeadBand
        '
        Me.btnGetAlarm1DeadBand.Location = New System.Drawing.Point(295, 45)
        Me.btnGetAlarm1DeadBand.Name = "btnGetAlarm1DeadBand"
        Me.btnGetAlarm1DeadBand.Size = New System.Drawing.Size(51, 28)
        Me.btnGetAlarm1DeadBand.TabIndex = 24
        Me.btnGetAlarm1DeadBand.Text = "Get"
        Me.btnGetAlarm1DeadBand.UseVisualStyleBackColor = True
        '
        'btnGetAlarm1Value
        '
        Me.btnGetAlarm1Value.Location = New System.Drawing.Point(295, 77)
        Me.btnGetAlarm1Value.Name = "btnGetAlarm1Value"
        Me.btnGetAlarm1Value.Size = New System.Drawing.Size(51, 28)
        Me.btnGetAlarm1Value.TabIndex = 23
        Me.btnGetAlarm1Value.Text = "Get"
        Me.btnGetAlarm1Value.UseVisualStyleBackColor = True
        '
        'btnSetAlarm1DeadBand
        '
        Me.btnSetAlarm1DeadBand.Location = New System.Drawing.Point(241, 45)
        Me.btnSetAlarm1DeadBand.Name = "btnSetAlarm1DeadBand"
        Me.btnSetAlarm1DeadBand.Size = New System.Drawing.Size(51, 28)
        Me.btnSetAlarm1DeadBand.TabIndex = 22
        Me.btnSetAlarm1DeadBand.Text = "Set"
        Me.btnSetAlarm1DeadBand.UseVisualStyleBackColor = True
        '
        'btnSetAlarm1Value
        '
        Me.btnSetAlarm1Value.Location = New System.Drawing.Point(241, 77)
        Me.btnSetAlarm1Value.Name = "btnSetAlarm1Value"
        Me.btnSetAlarm1Value.Size = New System.Drawing.Size(51, 28)
        Me.btnSetAlarm1Value.TabIndex = 21
        Me.btnSetAlarm1Value.Text = "Set"
        Me.btnSetAlarm1Value.UseVisualStyleBackColor = True
        '
        'btnSetAlarm1Type
        '
        Me.btnSetAlarm1Type.Location = New System.Drawing.Point(241, 15)
        Me.btnSetAlarm1Type.Name = "btnSetAlarm1Type"
        Me.btnSetAlarm1Type.Size = New System.Drawing.Size(51, 28)
        Me.btnSetAlarm1Type.TabIndex = 20
        Me.btnSetAlarm1Type.Text = "Set"
        Me.btnSetAlarm1Type.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(217, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 12)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(217, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 12)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "%"
        '
        'tbAlarm1Value
        '
        Me.tbAlarm1Value.Location = New System.Drawing.Point(86, 79)
        Me.tbAlarm1Value.Name = "tbAlarm1Value"
        Me.tbAlarm1Value.Size = New System.Drawing.Size(124, 21)
        Me.tbAlarm1Value.TabIndex = 11
        '
        'tbAlarm1DeadBand
        '
        Me.tbAlarm1DeadBand.Location = New System.Drawing.Point(86, 51)
        Me.tbAlarm1DeadBand.Name = "tbAlarm1DeadBand"
        Me.tbAlarm1DeadBand.Size = New System.Drawing.Size(124, 21)
        Me.tbAlarm1DeadBand.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "설정값 :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "데드 밴드 :"
        '
        'cbSelAlarm1Type
        '
        Me.cbSelAlarm1Type.FormattingEnabled = True
        Me.cbSelAlarm1Type.Location = New System.Drawing.Point(85, 19)
        Me.cbSelAlarm1Type.Name = "cbSelAlarm1Type"
        Me.cbSelAlarm1Type.Size = New System.Drawing.Size(151, 20)
        Me.cbSelAlarm1Type.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "출력 종류 :"
        '
        'frmNx1Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 238)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmNx1Control"
        Me.Text = "frmNx1TempController"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetTemp As System.Windows.Forms.Button
    Friend WithEvents tbGetTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnSetTemp As System.Windows.Forms.Button
    Friend WithEvents tbSetTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetAlarm1Type As System.Windows.Forms.Button
    Friend WithEvents btnGetAlarm1DeadBand As System.Windows.Forms.Button
    Friend WithEvents btnGetAlarm1Value As System.Windows.Forms.Button
    Friend WithEvents btnSetAlarm1DeadBand As System.Windows.Forms.Button
    Friend WithEvents btnSetAlarm1Value As System.Windows.Forms.Button
    Friend WithEvents btnSetAlarm1Type As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbAlarm1Value As System.Windows.Forms.TextBox
    Friend WithEvents tbAlarm1DeadBand As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbSelAlarm1Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
