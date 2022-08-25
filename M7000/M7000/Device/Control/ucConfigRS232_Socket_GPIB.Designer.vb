<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigRS232_Socket_GPIB
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
        Me.gbConfig = New System.Windows.Forms.GroupBox()
        Me.gbGPIBSet = New System.Windows.Forms.GroupBox()
        Me.tbAddressNumber = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbSelDeviceSelect = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbSelCommType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ucDispRs232 = New CCommLib.ucConfigRs232()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.ConfigList = New M7000.ucDispListView()
        Me.gbIPSet = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIPBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIPBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIPBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIPBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbConfig.SuspendLayout()
        Me.gbGPIBSet.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbIPSet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.gbGPIBSet)
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.ucDispRs232)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Controls.Add(Me.gbIPSet)
        Me.gbConfig.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConfig.Location = New System.Drawing.Point(15, 15)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(509, 523)
        Me.gbConfig.TabIndex = 7
        Me.gbConfig.TabStop = False
        '
        'gbGPIBSet
        '
        Me.gbGPIBSet.Controls.Add(Me.tbAddressNumber)
        Me.gbGPIBSet.Controls.Add(Me.Label11)
        Me.gbGPIBSet.Location = New System.Drawing.Point(266, 93)
        Me.gbGPIBSet.Name = "gbGPIBSet"
        Me.gbGPIBSet.Size = New System.Drawing.Size(161, 46)
        Me.gbGPIBSet.TabIndex = 15
        Me.gbGPIBSet.TabStop = False
        Me.gbGPIBSet.Text = "GPIB"
        '
        'tbAddressNumber
        '
        Me.tbAddressNumber.Location = New System.Drawing.Point(70, 16)
        Me.tbAddressNumber.Name = "tbAddressNumber"
        Me.tbAddressNumber.Size = New System.Drawing.Size(79, 20)
        Me.tbAddressNumber.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 14)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Address"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cbSelDeviceSelect)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cbSelCommType)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox3.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(486, 73)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(48, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Device Select"
        '
        'cbSelDeviceSelect
        '
        Me.cbSelDeviceSelect.FormattingEnabled = True
        Me.cbSelDeviceSelect.Location = New System.Drawing.Point(131, 20)
        Me.cbSelDeviceSelect.Name = "cbSelDeviceSelect"
        Me.cbSelDeviceSelect.Size = New System.Drawing.Size(81, 22)
        Me.cbSelDeviceSelect.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 14)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Communication Type"
        '
        'cbSelCommType
        '
        Me.cbSelCommType.FormattingEnabled = True
        Me.cbSelCommType.Location = New System.Drawing.Point(131, 47)
        Me.cbSelCommType.Name = "cbSelCommType"
        Me.cbSelCommType.Size = New System.Drawing.Size(81, 22)
        Me.cbSelCommType.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(385, 19)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(43, 20)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(320, 19)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(43, 20)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(232, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch."
        '
        'ucDispRs232
        '
        Me.ucDispRs232.BAUDRATE = 19200
        Me.ucDispRs232.COMPORT = Nothing
        Me.ucDispRs232.DATABIT = 8
        Me.ucDispRs232.Location = New System.Drawing.Point(9, 89)
        Me.ucDispRs232.Name = "ucDispRs232"
        Me.ucDispRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucDispRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.Size = New System.Drawing.Size(251, 233)
        Me.ucDispRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucDispRs232.TabIndex = 8
        Me.ucDispRs232.Title = "RS232"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(273, 260)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(68, 54)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(420, 260)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 54)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(344, 260)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(73, 54)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No.", "Mode", "Setting Parametor", "Allocation Ch", "Device"}
        Me.ConfigList.ColHeaderWidthRatio = "10,15,30,30,15"
        Me.ConfigList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.HideSelection = False
        Me.ConfigList.LabelEdit = True
        Me.ConfigList.LabelWrap = True
        Me.ConfigList.Location = New System.Drawing.Point(9, 328)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(486, 183)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'gbIPSet
        '
        Me.gbIPSet.Controls.Add(Me.GroupBox2)
        Me.gbIPSet.Controls.Add(Me.GroupBox1)
        Me.gbIPSet.Location = New System.Drawing.Point(266, 145)
        Me.gbIPSet.Name = "gbIPSet"
        Me.gbIPSet.Size = New System.Drawing.Size(229, 109)
        Me.gbIPSet.TabIndex = 4
        Me.gbIPSet.TabStop = False
        Me.gbIPSet.Text = "IP Set"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPort)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(81, 41)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(33, 13)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(43, 20)
        Me.txtPort.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIPBox4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtIPBox3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIPBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtIPBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 46)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtIPBox4
        '
        Me.txtIPBox4.Location = New System.Drawing.Point(172, 14)
        Me.txtIPBox4.Name = "txtIPBox4"
        Me.txtIPBox4.Size = New System.Drawing.Size(43, 20)
        Me.txtIPBox4.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "."
        '
        'txtIPBox3
        '
        Me.txtIPBox3.Location = New System.Drawing.Point(121, 15)
        Me.txtIPBox3.Name = "txtIPBox3"
        Me.txtIPBox3.Size = New System.Drawing.Size(43, 20)
        Me.txtIPBox3.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "."
        '
        'txtIPBox2
        '
        Me.txtIPBox2.Location = New System.Drawing.Point(68, 16)
        Me.txtIPBox2.Name = "txtIPBox2"
        Me.txtIPBox2.Size = New System.Drawing.Size(43, 20)
        Me.txtIPBox2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "."
        '
        'txtIPBox1
        '
        Me.txtIPBox1.Location = New System.Drawing.Point(17, 16)
        Me.txtIPBox1.Name = "txtIPBox1"
        Me.txtIPBox1.Size = New System.Drawing.Size(43, 20)
        Me.txtIPBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP"
        '
        'ucConfigRS232_Socket_GPIB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigRS232_Socket_GPIB"
        Me.Size = New System.Drawing.Size(539, 594)
        Me.gbConfig.ResumeLayout(False)
        Me.gbGPIBSet.ResumeLayout(False)
        Me.gbGPIBSet.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbIPSet.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents gbGPIBSet As System.Windows.Forms.GroupBox
    Friend WithEvents tbAddressNumber As System.Windows.Forms.TextBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbSelCommType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ucDispRs232 As CCommLib.ucConfigRs232
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents ConfigList As M7000.ucDispListView
    Friend WithEvents gbIPSet As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIPBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbSelDeviceSelect As System.Windows.Forms.ComboBox

End Class
