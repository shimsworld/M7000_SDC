<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmG4sTestUI
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
        Me.tbClients = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbServerMsg = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPowerON = New System.Windows.Forms.Button()
        Me.btnGetCurrent = New System.Windows.Forms.Button()
        Me.btnPowerOFF = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelDev = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRealTimeDatas = New System.Windows.Forms.Label()
        Me.btnPatternBack = New System.Windows.Forms.Button()
        Me.btnGetRealtimeData = New System.Windows.Forms.Button()
        Me.btnPatternNext = New System.Windows.Forms.Button()
        Me.btnPatternChange = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbPatternNumber = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnUpdateAll = New System.Windows.Forms.Button()
        Me.cbSelModel = New System.Windows.Forms.ComboBox()
        Me.cbSelIniti = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSetPattern = New System.Windows.Forms.Button()
        Me.cbSelPattern = New System.Windows.Forms.ComboBox()
        Me.btnSetInitial = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnUpdateModelInfo = New System.Windows.Forms.Button()
        Me.btnSetModel = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnSeqReset = New System.Windows.Forms.Button()
        Me.btnSeqAutoSlide = New System.Windows.Forms.Button()
        Me.btnSeqPowerOFF = New System.Windows.Forms.Button()
        Me.btnSeqPowerON = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cbSelChannel = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbClients)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 414)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Clients"
        '
        'tbClients
        '
        Me.tbClients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbClients.Location = New System.Drawing.Point(3, 17)
        Me.tbClients.Multiline = True
        Me.tbClients.Name = "tbClients"
        Me.tbClients.Size = New System.Drawing.Size(167, 394)
        Me.tbClients.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbServerMsg)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 473)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 112)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TCP Server"
        '
        'tbServerMsg
        '
        Me.tbServerMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbServerMsg.Location = New System.Drawing.Point(3, 17)
        Me.tbServerMsg.Multiline = True
        Me.tbServerMsg.Name = "tbServerMsg"
        Me.tbServerMsg.Size = New System.Drawing.Size(340, 92)
        Me.tbServerMsg.TabIndex = 3
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(12, 7)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(170, 38)
        Me.btnConnection.TabIndex = 20
        Me.btnConnection.Text = "Server Open"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.btnPowerON)
        Me.GroupBox5.Controls.Add(Me.btnGetCurrent)
        Me.GroupBox5.Controls.Add(Me.btnPowerOFF)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.cbSelDev)
        Me.GroupBox5.Location = New System.Drawing.Point(364, 476)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(269, 109)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Controls"
        Me.GroupBox5.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 12)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "* IP 번호를 선택"
        '
        'btnPowerON
        '
        Me.btnPowerON.Location = New System.Drawing.Point(13, 63)
        Me.btnPowerON.Name = "btnPowerON"
        Me.btnPowerON.Size = New System.Drawing.Size(78, 38)
        Me.btnPowerON.TabIndex = 6
        Me.btnPowerON.Text = "Power ON"
        Me.btnPowerON.UseVisualStyleBackColor = True
        '
        'btnGetCurrent
        '
        Me.btnGetCurrent.Location = New System.Drawing.Point(183, 63)
        Me.btnGetCurrent.Name = "btnGetCurrent"
        Me.btnGetCurrent.Size = New System.Drawing.Size(78, 38)
        Me.btnGetCurrent.TabIndex = 4
        Me.btnGetCurrent.Text = "Get Current"
        Me.btnGetCurrent.UseVisualStyleBackColor = True
        '
        'btnPowerOFF
        '
        Me.btnPowerOFF.Location = New System.Drawing.Point(97, 63)
        Me.btnPowerOFF.Name = "btnPowerOFF"
        Me.btnPowerOFF.Size = New System.Drawing.Size(78, 38)
        Me.btnPowerOFF.TabIndex = 5
        Me.btnPowerOFF.Text = "Power OFF"
        Me.btnPowerOFF.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Select Device :"
        '
        'cbSelDev
        '
        Me.cbSelDev.FormattingEnabled = True
        Me.cbSelDev.Location = New System.Drawing.Point(108, 20)
        Me.cbSelDev.Name = "cbSelDev"
        Me.cbSelDev.Size = New System.Drawing.Size(99, 20)
        Me.cbSelDev.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRealTimeDatas)
        Me.GroupBox4.Location = New System.Drawing.Point(386, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 242)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Real Time Datas"
        '
        'lblRealTimeDatas
        '
        Me.lblRealTimeDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRealTimeDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblRealTimeDatas.Name = "lblRealTimeDatas"
        Me.lblRealTimeDatas.Size = New System.Drawing.Size(294, 222)
        Me.lblRealTimeDatas.TabIndex = 13
        Me.lblRealTimeDatas.Text = "Label2"
        '
        'btnPatternBack
        '
        Me.btnPatternBack.Location = New System.Drawing.Point(11, 61)
        Me.btnPatternBack.Name = "btnPatternBack"
        Me.btnPatternBack.Size = New System.Drawing.Size(99, 38)
        Me.btnPatternBack.TabIndex = 7
        Me.btnPatternBack.Text = "BACK"
        Me.btnPatternBack.UseVisualStyleBackColor = True
        '
        'btnGetRealtimeData
        '
        Me.btnGetRealtimeData.Location = New System.Drawing.Point(587, 17)
        Me.btnGetRealtimeData.Name = "btnGetRealtimeData"
        Me.btnGetRealtimeData.Size = New System.Drawing.Size(99, 38)
        Me.btnGetRealtimeData.TabIndex = 3
        Me.btnGetRealtimeData.Text = "Get Real-time data"
        Me.btnGetRealtimeData.UseVisualStyleBackColor = True
        '
        'btnPatternNext
        '
        Me.btnPatternNext.Location = New System.Drawing.Point(116, 61)
        Me.btnPatternNext.Name = "btnPatternNext"
        Me.btnPatternNext.Size = New System.Drawing.Size(99, 38)
        Me.btnPatternNext.TabIndex = 8
        Me.btnPatternNext.Text = "NEXT"
        Me.btnPatternNext.UseVisualStyleBackColor = True
        '
        'btnPatternChange
        '
        Me.btnPatternChange.Location = New System.Drawing.Point(198, 104)
        Me.btnPatternChange.Name = "btnPatternChange"
        Me.btnPatternChange.Size = New System.Drawing.Size(99, 38)
        Me.btnPatternChange.TabIndex = 9
        Me.btnPatternChange.Text = "CHANGE"
        Me.btnPatternChange.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Pattern Number :"
        '
        'tbPatternNumber
        '
        Me.tbPatternNumber.Location = New System.Drawing.Point(116, 114)
        Me.tbPatternNumber.Name = "tbPatternNumber"
        Me.tbPatternNumber.Size = New System.Drawing.Size(76, 21)
        Me.tbPatternNumber.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.btnDisconnection)
        Me.GroupBox3.Controls.Add(Me.btnSeqReset)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btnSeqAutoSlide)
        Me.GroupBox3.Controls.Add(Me.btnPatternBack)
        Me.GroupBox3.Controls.Add(Me.btnSeqPowerOFF)
        Me.GroupBox3.Controls.Add(Me.btnPatternNext)
        Me.GroupBox3.Controls.Add(Me.btnGetRealtimeData)
        Me.GroupBox3.Controls.Add(Me.btnSeqPowerON)
        Me.GroupBox3.Controls.Add(Me.btnPatternChange)
        Me.GroupBox3.Controls.Add(Me.tbPatternNumber)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(191, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(692, 414)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Control"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnUpdateAll)
        Me.GroupBox6.Controls.Add(Me.cbSelModel)
        Me.GroupBox6.Controls.Add(Me.cbSelIniti)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.btnSetPattern)
        Me.GroupBox6.Controls.Add(Me.cbSelPattern)
        Me.GroupBox6.Controls.Add(Me.btnSetInitial)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.btnUpdateModelInfo)
        Me.GroupBox6.Controls.Add(Me.btnSetModel)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 158)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(374, 145)
        Me.GroupBox6.TabIndex = 55
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Model"
        '
        'btnUpdateAll
        '
        Me.btnUpdateAll.Location = New System.Drawing.Point(199, 20)
        Me.btnUpdateAll.Name = "btnUpdateAll"
        Me.btnUpdateAll.Size = New System.Drawing.Size(161, 28)
        Me.btnUpdateAll.TabIndex = 54
        Me.btnUpdateAll.Text = "Update All"
        Me.btnUpdateAll.UseVisualStyleBackColor = True
        '
        'cbSelModel
        '
        Me.cbSelModel.FormattingEnabled = True
        Me.cbSelModel.Location = New System.Drawing.Point(106, 54)
        Me.cbSelModel.Name = "cbSelModel"
        Me.cbSelModel.Size = New System.Drawing.Size(186, 20)
        Me.cbSelModel.TabIndex = 44
        '
        'cbSelIniti
        '
        Me.cbSelIniti.FormattingEnabled = True
        Me.cbSelIniti.Location = New System.Drawing.Point(106, 119)
        Me.cbSelIniti.Name = "cbSelIniti"
        Me.cbSelIniti.Size = New System.Drawing.Size(186, 20)
        Me.cbSelIniti.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 12)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Select Model :"
        '
        'btnSetPattern
        '
        Me.btnSetPattern.Location = New System.Drawing.Point(298, 84)
        Me.btnSetPattern.Name = "btnSetPattern"
        Me.btnSetPattern.Size = New System.Drawing.Size(62, 24)
        Me.btnSetPattern.TabIndex = 52
        Me.btnSetPattern.Text = "Pattern"
        Me.btnSetPattern.UseVisualStyleBackColor = True
        Me.btnSetPattern.Visible = False
        '
        'cbSelPattern
        '
        Me.cbSelPattern.FormattingEnabled = True
        Me.cbSelPattern.Location = New System.Drawing.Point(106, 85)
        Me.cbSelPattern.Name = "cbSelPattern"
        Me.cbSelPattern.Size = New System.Drawing.Size(186, 20)
        Me.cbSelPattern.TabIndex = 46
        '
        'btnSetInitial
        '
        Me.btnSetInitial.Location = New System.Drawing.Point(298, 117)
        Me.btnSetInitial.Name = "btnSetInitial"
        Me.btnSetInitial.Size = New System.Drawing.Size(62, 24)
        Me.btnSetInitial.TabIndex = 51
        Me.btnSetInitial.Text = "Initial"
        Me.btnSetInitial.UseVisualStyleBackColor = True
        Me.btnSetInitial.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 12)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Select Pattern :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 12)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Select Initial :"
        '
        'btnUpdateModelInfo
        '
        Me.btnUpdateModelInfo.Location = New System.Drawing.Point(15, 20)
        Me.btnUpdateModelInfo.Name = "btnUpdateModelInfo"
        Me.btnUpdateModelInfo.Size = New System.Drawing.Size(134, 28)
        Me.btnUpdateModelInfo.TabIndex = 48
        Me.btnUpdateModelInfo.Text = "Load Model Info."
        Me.btnUpdateModelInfo.UseVisualStyleBackColor = True
        '
        'btnSetModel
        '
        Me.btnSetModel.Location = New System.Drawing.Point(298, 50)
        Me.btnSetModel.Name = "btnSetModel"
        Me.btnSetModel.Size = New System.Drawing.Size(62, 24)
        Me.btnSetModel.TabIndex = 49
        Me.btnSetModel.Text = "Model"
        Me.btnSetModel.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(339, 17)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(99, 38)
        Me.btnDisconnection.TabIndex = 29
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnSeqReset
        '
        Me.btnSeqReset.Location = New System.Drawing.Point(221, 17)
        Me.btnSeqReset.Name = "btnSeqReset"
        Me.btnSeqReset.Size = New System.Drawing.Size(99, 38)
        Me.btnSeqReset.TabIndex = 24
        Me.btnSeqReset.Text = "Reset"
        Me.btnSeqReset.UseVisualStyleBackColor = True
        '
        'btnSeqAutoSlide
        '
        Me.btnSeqAutoSlide.Location = New System.Drawing.Point(221, 61)
        Me.btnSeqAutoSlide.Name = "btnSeqAutoSlide"
        Me.btnSeqAutoSlide.Size = New System.Drawing.Size(99, 38)
        Me.btnSeqAutoSlide.TabIndex = 23
        Me.btnSeqAutoSlide.Text = "Auto Slide Test"
        Me.btnSeqAutoSlide.UseVisualStyleBackColor = True
        '
        'btnSeqPowerOFF
        '
        Me.btnSeqPowerOFF.Location = New System.Drawing.Point(116, 17)
        Me.btnSeqPowerOFF.Name = "btnSeqPowerOFF"
        Me.btnSeqPowerOFF.Size = New System.Drawing.Size(99, 38)
        Me.btnSeqPowerOFF.TabIndex = 22
        Me.btnSeqPowerOFF.Text = "Power Off"
        Me.btnSeqPowerOFF.UseVisualStyleBackColor = True
        '
        'btnSeqPowerON
        '
        Me.btnSeqPowerON.Location = New System.Drawing.Point(11, 17)
        Me.btnSeqPowerON.Name = "btnSeqPowerON"
        Me.btnSeqPowerON.Size = New System.Drawing.Size(99, 38)
        Me.btnSeqPowerON.TabIndex = 18
        Me.btnSeqPowerON.Text = "Power On"
        Me.btnSeqPowerON.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Target Channel :"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(762, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(121, 38)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cbSelChannel
        '
        Me.cbSelChannel.FormattingEnabled = True
        Me.cbSelChannel.Location = New System.Drawing.Point(298, 16)
        Me.cbSelChannel.Name = "cbSelChannel"
        Me.cbSelChannel.Size = New System.Drawing.Size(99, 20)
        Me.cbSelChannel.TabIndex = 27
        '
        'frmG4sTestUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 589)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbSelChannel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmG4sTestUI"
        Me.Text = "G4S Control"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbClients As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbServerMsg As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPowerON As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRealTimeDatas As System.Windows.Forms.Label
    Friend WithEvents btnGetCurrent As System.Windows.Forms.Button
    Friend WithEvents btnPowerOFF As System.Windows.Forms.Button
    Friend WithEvents btnPatternBack As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGetRealtimeData As System.Windows.Forms.Button
    Friend WithEvents btnPatternNext As System.Windows.Forms.Button
    Friend WithEvents btnPatternChange As System.Windows.Forms.Button
    Friend WithEvents cbSelDev As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbPatternNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSeqReset As System.Windows.Forms.Button
    Friend WithEvents btnSeqAutoSlide As System.Windows.Forms.Button
    Friend WithEvents btnSeqPowerOFF As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSeqPowerON As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cbSelChannel As System.Windows.Forms.ComboBox
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdateAll As System.Windows.Forms.Button
    Friend WithEvents cbSelModel As System.Windows.Forms.ComboBox
    Friend WithEvents cbSelIniti As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSetPattern As System.Windows.Forms.Button
    Friend WithEvents cbSelPattern As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetInitial As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnUpdateModelInfo As System.Windows.Forms.Button
    Friend WithEvents btnSetModel As System.Windows.Forms.Button
End Class
