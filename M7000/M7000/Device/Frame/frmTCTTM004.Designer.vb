<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTCTTM004
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbNumOfDevice = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGetSettingTemp = New System.Windows.Forms.Button()
        Me.tbGetSettingTemp = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnGetTemp = New System.Windows.Forms.Button()
        Me.tbGetTemp = New System.Windows.Forms.TextBox()
        Me.btnSetTemp = New System.Windows.Forms.Button()
        Me.tbSetTemp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGetDPInfo = New System.Windows.Forms.Button()
        Me.btnGetEvent1Status = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGetLimitAlarm1_Low = New System.Windows.Forms.Button()
        Me.btnGetLimitAlarm1_High = New System.Windows.Forms.Button()
        Me.btnSetLimitAlarm1_Low = New System.Windows.Forms.Button()
        Me.tbLimitAlarm1_Low = New System.Windows.Forms.TextBox()
        Me.btnSetLimitAlarm1_High = New System.Windows.Forms.Button()
        Me.tbLimitAlarm1_High = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGetOutputStauts = New System.Windows.Forms.Button()
        Me.btnGetSensityivity = New System.Windows.Forms.Button()
        Me.btnGetDelayTimer = New System.Windows.Forms.Button()
        Me.btnGetPolarity = New System.Windows.Forms.Button()
        Me.chkEnableEvent1 = New System.Windows.Forms.CheckBox()
        Me.cbAllChannel = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbNumOfDevice)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.tbAddress)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnDisconnection)
        Me.GroupBox2.Controls.Add(Me.btnConnection)
        Me.GroupBox2.Controls.Add(Me.cbBaudRate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbPort)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 174)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Communication"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LimeGreen
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(319, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "* Device Configuration에 온도 컨트롤러 설정이 되어 있지"
        '
        'tbNumOfDevice
        '
        Me.tbNumOfDevice.Location = New System.Drawing.Point(109, 103)
        Me.tbNumOfDevice.Name = "tbNumOfDevice"
        Me.tbNumOfDevice.Size = New System.Drawing.Size(69, 21)
        Me.tbNumOfDevice.TabIndex = 22
        Me.tbNumOfDevice.Text = "0"
        Me.tbNumOfDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 12)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "NumOfDevice :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.LimeGreen
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(234, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "않으면 NumOfDevice 수로 초기 셋팅한다."
        '
        'tbAddress
        '
        Me.tbAddress.Location = New System.Drawing.Point(109, 77)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(69, 21)
        Me.tbAddress.TabIndex = 20
        Me.tbAddress.Text = "1"
        Me.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Address :"
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisconnection.Location = New System.Drawing.Point(190, 61)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(94, 34)
        Me.btnDisconnection.TabIndex = 7
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnection.Location = New System.Drawing.Point(190, 26)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(94, 34)
        Me.btnConnection.TabIndex = 6
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400"})
        Me.cbBaudRate.Location = New System.Drawing.Point(109, 51)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(69, 20)
        Me.cbBaudRate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BaudRate :"
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(109, 25)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(69, 20)
        Me.cbPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port :"
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.TextBox1.Location = New System.Drawing.Point(322, 13)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(290, 126)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGetSettingTemp)
        Me.GroupBox1.Controls.Add(Me.tbGetSettingTemp)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnGetTemp)
        Me.GroupBox1.Controls.Add(Me.tbGetTemp)
        Me.GroupBox1.Controls.Add(Me.btnSetTemp)
        Me.GroupBox1.Controls.Add(Me.tbSetTemp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 121)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PV/SV"
        '
        'btnGetSettingTemp
        '
        Me.btnGetSettingTemp.Location = New System.Drawing.Point(190, 77)
        Me.btnGetSettingTemp.Name = "btnGetSettingTemp"
        Me.btnGetSettingTemp.Size = New System.Drawing.Size(70, 25)
        Me.btnGetSettingTemp.TabIndex = 22
        Me.btnGetSettingTemp.Text = "Get Temp"
        Me.btnGetSettingTemp.UseVisualStyleBackColor = True
        '
        'tbGetSettingTemp
        '
        Me.tbGetSettingTemp.Location = New System.Drawing.Point(104, 79)
        Me.tbGetSettingTemp.Name = "tbGetSettingTemp"
        Me.tbGetSettingTemp.Size = New System.Drawing.Size(82, 20)
        Me.tbGetSettingTemp.TabIndex = 21
        Me.tbGetSettingTemp.Text = "0"
        Me.tbGetSettingTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Get Setting Temp."
        '
        'btnGetTemp
        '
        Me.btnGetTemp.Location = New System.Drawing.Point(190, 48)
        Me.btnGetTemp.Name = "btnGetTemp"
        Me.btnGetTemp.Size = New System.Drawing.Size(70, 25)
        Me.btnGetTemp.TabIndex = 19
        Me.btnGetTemp.Text = "Get Temp"
        Me.btnGetTemp.UseVisualStyleBackColor = True
        '
        'tbGetTemp
        '
        Me.tbGetTemp.Location = New System.Drawing.Point(104, 50)
        Me.tbGetTemp.Name = "tbGetTemp"
        Me.tbGetTemp.Size = New System.Drawing.Size(82, 20)
        Me.tbGetTemp.TabIndex = 18
        Me.tbGetTemp.Text = "0"
        Me.tbGetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSetTemp
        '
        Me.btnSetTemp.Location = New System.Drawing.Point(190, 17)
        Me.btnSetTemp.Name = "btnSetTemp"
        Me.btnSetTemp.Size = New System.Drawing.Size(70, 25)
        Me.btnSetTemp.TabIndex = 15
        Me.btnSetTemp.Text = "Set Temp"
        Me.btnSetTemp.UseVisualStyleBackColor = True
        '
        'tbSetTemp
        '
        Me.tbSetTemp.Location = New System.Drawing.Point(104, 20)
        Me.tbSetTemp.Name = "tbSetTemp"
        Me.tbSetTemp.Size = New System.Drawing.Size(82, 20)
        Me.tbSetTemp.TabIndex = 14
        Me.tbSetTemp.Text = "0"
        Me.tbSetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Get Temperature"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Set Temperature"
        '
        'btnGetDPInfo
        '
        Me.btnGetDPInfo.Location = New System.Drawing.Point(308, 197)
        Me.btnGetDPInfo.Name = "btnGetDPInfo"
        Me.btnGetDPInfo.Size = New System.Drawing.Size(105, 33)
        Me.btnGetDPInfo.TabIndex = 20
        Me.btnGetDPInfo.Text = "Get DP Info"
        Me.btnGetDPInfo.UseVisualStyleBackColor = True
        '
        'btnGetEvent1Status
        '
        Me.btnGetEvent1Status.Location = New System.Drawing.Point(308, 234)
        Me.btnGetEvent1Status.Name = "btnGetEvent1Status"
        Me.btnGetEvent1Status.Size = New System.Drawing.Size(105, 35)
        Me.btnGetEvent1Status.TabIndex = 21
        Me.btnGetEvent1Status.Text = "Get Event1 Status"
        Me.btnGetEvent1Status.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGetLimitAlarm1_Low)
        Me.GroupBox3.Controls.Add(Me.btnGetLimitAlarm1_High)
        Me.GroupBox3.Controls.Add(Me.btnSetLimitAlarm1_Low)
        Me.GroupBox3.Controls.Add(Me.tbLimitAlarm1_Low)
        Me.GroupBox3.Controls.Add(Me.btnSetLimitAlarm1_High)
        Me.GroupBox3.Controls.Add(Me.tbLimitAlarm1_High)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 308)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 89)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Limit Event1 Alarm"
        '
        'btnGetLimitAlarm1_Low
        '
        Me.btnGetLimitAlarm1_Low.Location = New System.Drawing.Point(243, 47)
        Me.btnGetLimitAlarm1_Low.Name = "btnGetLimitAlarm1_Low"
        Me.btnGetLimitAlarm1_Low.Size = New System.Drawing.Size(43, 30)
        Me.btnGetLimitAlarm1_Low.TabIndex = 21
        Me.btnGetLimitAlarm1_Low.Text = "Get"
        Me.btnGetLimitAlarm1_Low.UseVisualStyleBackColor = True
        '
        'btnGetLimitAlarm1_High
        '
        Me.btnGetLimitAlarm1_High.Location = New System.Drawing.Point(243, 16)
        Me.btnGetLimitAlarm1_High.Name = "btnGetLimitAlarm1_High"
        Me.btnGetLimitAlarm1_High.Size = New System.Drawing.Size(43, 30)
        Me.btnGetLimitAlarm1_High.TabIndex = 20
        Me.btnGetLimitAlarm1_High.Text = "Get"
        Me.btnGetLimitAlarm1_High.UseVisualStyleBackColor = True
        '
        'btnSetLimitAlarm1_Low
        '
        Me.btnSetLimitAlarm1_Low.Location = New System.Drawing.Point(196, 47)
        Me.btnSetLimitAlarm1_Low.Name = "btnSetLimitAlarm1_Low"
        Me.btnSetLimitAlarm1_Low.Size = New System.Drawing.Size(43, 30)
        Me.btnSetLimitAlarm1_Low.TabIndex = 19
        Me.btnSetLimitAlarm1_Low.Text = "Set"
        Me.btnSetLimitAlarm1_Low.UseVisualStyleBackColor = True
        '
        'tbLimitAlarm1_Low
        '
        Me.tbLimitAlarm1_Low.Location = New System.Drawing.Point(104, 52)
        Me.tbLimitAlarm1_Low.Name = "tbLimitAlarm1_Low"
        Me.tbLimitAlarm1_Low.Size = New System.Drawing.Size(82, 20)
        Me.tbLimitAlarm1_Low.TabIndex = 18
        Me.tbLimitAlarm1_Low.Text = "0"
        Me.tbLimitAlarm1_Low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSetLimitAlarm1_High
        '
        Me.btnSetLimitAlarm1_High.Location = New System.Drawing.Point(196, 16)
        Me.btnSetLimitAlarm1_High.Name = "btnSetLimitAlarm1_High"
        Me.btnSetLimitAlarm1_High.Size = New System.Drawing.Size(43, 30)
        Me.btnSetLimitAlarm1_High.TabIndex = 15
        Me.btnSetLimitAlarm1_High.Text = "Set"
        Me.btnSetLimitAlarm1_High.UseVisualStyleBackColor = True
        '
        'tbLimitAlarm1_High
        '
        Me.tbLimitAlarm1_High.Location = New System.Drawing.Point(104, 20)
        Me.tbLimitAlarm1_High.Name = "tbLimitAlarm1_High"
        Me.tbLimitAlarm1_High.Size = New System.Drawing.Size(82, 20)
        Me.tbLimitAlarm1_High.TabIndex = 14
        Me.tbLimitAlarm1_High.Text = "0"
        Me.tbLimitAlarm1_High.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Low :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "High :"
        '
        'btnGetOutputStauts
        '
        Me.btnGetOutputStauts.Location = New System.Drawing.Point(308, 271)
        Me.btnGetOutputStauts.Name = "btnGetOutputStauts"
        Me.btnGetOutputStauts.Size = New System.Drawing.Size(105, 33)
        Me.btnGetOutputStauts.TabIndex = 24
        Me.btnGetOutputStauts.Text = "Get Output Status"
        Me.btnGetOutputStauts.UseVisualStyleBackColor = True
        '
        'btnGetSensityivity
        '
        Me.btnGetSensityivity.Location = New System.Drawing.Point(507, 194)
        Me.btnGetSensityivity.Name = "btnGetSensityivity"
        Me.btnGetSensityivity.Size = New System.Drawing.Size(105, 30)
        Me.btnGetSensityivity.TabIndex = 25
        Me.btnGetSensityivity.Text = "Get Sensitivity"
        Me.btnGetSensityivity.UseVisualStyleBackColor = True
        '
        'btnGetDelayTimer
        '
        Me.btnGetDelayTimer.Location = New System.Drawing.Point(507, 231)
        Me.btnGetDelayTimer.Name = "btnGetDelayTimer"
        Me.btnGetDelayTimer.Size = New System.Drawing.Size(105, 30)
        Me.btnGetDelayTimer.TabIndex = 26
        Me.btnGetDelayTimer.Text = "Get Delay Timer"
        Me.btnGetDelayTimer.UseVisualStyleBackColor = True
        '
        'btnGetPolarity
        '
        Me.btnGetPolarity.Location = New System.Drawing.Point(507, 268)
        Me.btnGetPolarity.Name = "btnGetPolarity"
        Me.btnGetPolarity.Size = New System.Drawing.Size(105, 30)
        Me.btnGetPolarity.TabIndex = 27
        Me.btnGetPolarity.Text = "Get Polarity"
        Me.btnGetPolarity.UseVisualStyleBackColor = True
        '
        'chkEnableEvent1
        '
        Me.chkEnableEvent1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEnableEvent1.Location = New System.Drawing.Point(308, 307)
        Me.chkEnableEvent1.Name = "chkEnableEvent1"
        Me.chkEnableEvent1.Size = New System.Drawing.Size(105, 33)
        Me.chkEnableEvent1.TabIndex = 28
        Me.chkEnableEvent1.Text = "Enable Event1"
        Me.chkEnableEvent1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEnableEvent1.UseVisualStyleBackColor = True
        '
        'cbAllChannel
        '
        Me.cbAllChannel.AutoSize = True
        Me.cbAllChannel.Location = New System.Drawing.Point(349, 173)
        Me.cbAllChannel.Name = "cbAllChannel"
        Me.cbAllChannel.Size = New System.Drawing.Size(76, 17)
        Me.cbAllChannel.TabIndex = 29
        Me.cbAllChannel.Text = "AllChannel"
        Me.cbAllChannel.UseVisualStyleBackColor = True
        '
        'frmTCTTM004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 404)
        Me.Controls.Add(Me.cbAllChannel)
        Me.Controls.Add(Me.chkEnableEvent1)
        Me.Controls.Add(Me.btnGetPolarity)
        Me.Controls.Add(Me.btnGetDelayTimer)
        Me.Controls.Add(Me.btnGetSensityivity)
        Me.Controls.Add(Me.btnGetOutputStauts)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGetEvent1Status)
        Me.Controls.Add(Me.btnGetDPInfo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTCTTM004"
        Me.Text = "frmTCTTM004"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetTemp As System.Windows.Forms.Button
    Friend WithEvents tbGetTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnSetTemp As System.Windows.Forms.Button
    Friend WithEvents tbSetTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGetDPInfo As System.Windows.Forms.Button
    Friend WithEvents btnGetEvent1Status As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetLimitAlarm1_Low As System.Windows.Forms.Button
    Friend WithEvents tbLimitAlarm1_Low As System.Windows.Forms.TextBox
    Friend WithEvents btnSetLimitAlarm1_High As System.Windows.Forms.Button
    Friend WithEvents tbLimitAlarm1_High As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnGetLimitAlarm1_Low As System.Windows.Forms.Button
    Friend WithEvents btnGetLimitAlarm1_High As System.Windows.Forms.Button
    Friend WithEvents btnGetOutputStauts As System.Windows.Forms.Button
    Friend WithEvents btnGetSensityivity As System.Windows.Forms.Button
    Friend WithEvents btnGetDelayTimer As System.Windows.Forms.Button
    Friend WithEvents btnGetPolarity As System.Windows.Forms.Button
    Friend WithEvents chkEnableEvent1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbAllChannel As System.Windows.Forms.CheckBox
    Friend WithEvents tbNumOfDevice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnGetSettingTemp As System.Windows.Forms.Button
    Friend WithEvents tbGetSettingTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
