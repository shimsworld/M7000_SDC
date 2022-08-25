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
        Me.ConfigList = New CCommLib.ucDispListView()
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
        Me.gbConfig.Location = New System.Drawing.Point(17, 14)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(537, 517)
        Me.gbConfig.TabIndex = 7
        Me.gbConfig.TabStop = False
        '
        'gbGPIBSet
        '
        Me.gbGPIBSet.Controls.Add(Me.tbAddressNumber)
        Me.gbGPIBSet.Controls.Add(Me.Label11)
        Me.gbGPIBSet.Location = New System.Drawing.Point(255, 104)
        Me.gbGPIBSet.Name = "gbGPIBSet"
        Me.gbGPIBSet.Size = New System.Drawing.Size(176, 42)
        Me.gbGPIBSet.TabIndex = 15
        Me.gbGPIBSet.TabStop = False
        Me.gbGPIBSet.Text = "GPIB"
        '
        'tbAddressNumber
        '
        Me.tbAddressNumber.Location = New System.Drawing.Point(73, 13)
        Me.tbAddressNumber.Name = "tbAddressNumber"
        Me.tbAddressNumber.Size = New System.Drawing.Size(91, 21)
        Me.tbAddressNumber.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Address :"
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
        Me.GroupBox3.Location = New System.Drawing.Point(10, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(512, 78)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Device Select  :"
        '
        'cbSelDeviceSelect
        '
        Me.cbSelDeviceSelect.FormattingEnabled = True
        Me.cbSelDeviceSelect.Location = New System.Drawing.Point(147, 18)
        Me.cbSelDeviceSelect.Name = "cbSelDeviceSelect"
        Me.cbSelDeviceSelect.Size = New System.Drawing.Size(94, 20)
        Me.cbSelDeviceSelect.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 12)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Communication Type :"
        '
        'cbSelCommType
        '
        Me.cbSelCommType.FormattingEnabled = True
        Me.cbSelCommType.Location = New System.Drawing.Point(147, 48)
        Me.cbSelCommType.Name = "cbSelCommType"
        Me.cbSelCommType.Size = New System.Drawing.Size(94, 20)
        Me.cbSelCommType.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(422, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(442, 16)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(49, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(366, 16)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(49, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(267, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'ucDispRs232
        '
        Me.ucDispRs232.BAUDRATE = 19200
        Me.ucDispRs232.COMPORT = "COM12"
        Me.ucDispRs232.DATABIT = 8
        Me.ucDispRs232.Location = New System.Drawing.Point(10, 104)
        Me.ucDispRs232.Name = "ucDispRs232"
        Me.ucDispRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucDispRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.Size = New System.Drawing.Size(241, 202)
        Me.ucDispRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucDispRs232.TabIndex = 8
        Me.ucDispRs232.Title = "RS232"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(255, 259)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(84, 50)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(439, 259)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(84, 50)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(346, 259)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(85, 50)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No.", "Mode", "Setting Parametor", "Allocation Ch", "Device"}
        Me.ConfigList.ColHeaderWidthRatio = "10,15,30,30,15"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(10, 315)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(512, 196)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'gbIPSet
        '
        Me.gbIPSet.Controls.Add(Me.GroupBox2)
        Me.gbIPSet.Controls.Add(Me.GroupBox1)
        Me.gbIPSet.Location = New System.Drawing.Point(255, 152)
        Me.gbIPSet.Name = "gbIPSet"
        Me.gbIPSet.Size = New System.Drawing.Size(267, 101)
        Me.gbIPSet.TabIndex = 4
        Me.gbIPSet.TabStop = False
        Me.gbIPSet.Text = "IP Set"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPort)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(94, 38)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(38, 11)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(49, 21)
        Me.txtPort.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
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
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 42)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtIPBox4
        '
        Me.txtIPBox4.Location = New System.Drawing.Point(201, 13)
        Me.txtIPBox4.Name = "txtIPBox4"
        Me.txtIPBox4.Size = New System.Drawing.Size(49, 21)
        Me.txtIPBox4.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(192, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(9, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "."
        '
        'txtIPBox3
        '
        Me.txtIPBox3.Location = New System.Drawing.Point(141, 14)
        Me.txtIPBox3.Name = "txtIPBox3"
        Me.txtIPBox3.Size = New System.Drawing.Size(49, 21)
        Me.txtIPBox3.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(132, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(9, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "."
        '
        'txtIPBox2
        '
        Me.txtIPBox2.Location = New System.Drawing.Point(79, 15)
        Me.txtIPBox2.Name = "txtIPBox2"
        Me.txtIPBox2.Size = New System.Drawing.Size(49, 21)
        Me.txtIPBox2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(9, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "."
        '
        'txtIPBox1
        '
        Me.txtIPBox1.Location = New System.Drawing.Point(20, 15)
        Me.txtIPBox1.Name = "txtIPBox1"
        Me.txtIPBox1.Size = New System.Drawing.Size(49, 21)
        Me.txtIPBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP"
        '
        'ucConfigRS232_Socket_GPIB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigRS232_Socket_GPIB"
        Me.Size = New System.Drawing.Size(595, 555)
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
    Friend WithEvents ConfigList As CCommLib.ucDispListView
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
