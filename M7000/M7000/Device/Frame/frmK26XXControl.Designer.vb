<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmK26XXControl
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
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.btnSetBias = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbReadCurrent = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbReadVolt = New System.Windows.Forms.TextBox()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.btnCellOff = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbBiasValue = New System.Windows.Forms.TextBox()
        Me.btnCellOn = New System.Windows.Forms.Button()
        Me.tbConnectionStatus = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnOptionSet = New System.Windows.Forms.Button()
        Me.gbConfig = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.gbGPIBSet = New System.Windows.Forms.GroupBox()
        Me.tbAddressNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbSelCommType = New System.Windows.Forms.ComboBox()
        Me.gbIPSet = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtIPBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIPBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIPBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIPBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ucConfigRs232 = New CCommLib.ucConfigRs232()
        Me.ucKeithleyCommon = New CSMULib.ucKeithleySMUSettings()
        Me.GroupBox11.SuspendLayout()
        Me.gbConfig.SuspendLayout()
        Me.gbGPIBSet.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbIPSet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.btnSetBias)
        Me.GroupBox11.Controls.Add(Me.Label16)
        Me.GroupBox11.Controls.Add(Me.tbReadCurrent)
        Me.GroupBox11.Controls.Add(Me.Label15)
        Me.GroupBox11.Controls.Add(Me.tbReadVolt)
        Me.GroupBox11.Controls.Add(Me.btnMeas)
        Me.GroupBox11.Controls.Add(Me.btnCellOff)
        Me.GroupBox11.Controls.Add(Me.Label11)
        Me.GroupBox11.Controls.Add(Me.tbBiasValue)
        Me.GroupBox11.Controls.Add(Me.btnCellOn)
        Me.GroupBox11.Location = New System.Drawing.Point(467, 13)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(518, 102)
        Me.GroupBox11.TabIndex = 13
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Meas"
        '
        'btnSetBias
        '
        Me.btnSetBias.Location = New System.Drawing.Point(147, 15)
        Me.btnSetBias.Name = "btnSetBias"
        Me.btnSetBias.Size = New System.Drawing.Size(55, 26)
        Me.btnSetBias.TabIndex = 18
        Me.btnSetBias.Text = "Set"
        Me.btnSetBias.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(230, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Current :"
        '
        'tbReadCurrent
        '
        Me.tbReadCurrent.Location = New System.Drawing.Point(280, 66)
        Me.tbReadCurrent.Name = "tbReadCurrent"
        Me.tbReadCurrent.Size = New System.Drawing.Size(151, 20)
        Me.tbReadCurrent.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(29, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Volt :"
        '
        'tbReadVolt
        '
        Me.tbReadVolt.Location = New System.Drawing.Point(63, 66)
        Me.tbReadVolt.Name = "tbReadVolt"
        Me.tbReadVolt.Size = New System.Drawing.Size(151, 20)
        Me.tbReadVolt.TabIndex = 14
        '
        'btnMeas
        '
        Me.btnMeas.Location = New System.Drawing.Point(336, 15)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(81, 26)
        Me.btnMeas.TabIndex = 13
        Me.btnMeas.Text = "Meas"
        Me.btnMeas.UseVisualStyleBackColor = True
        '
        'btnCellOff
        '
        Me.btnCellOff.Location = New System.Drawing.Point(267, 15)
        Me.btnCellOff.Name = "btnCellOff"
        Me.btnCellOff.Size = New System.Drawing.Size(55, 26)
        Me.btnCellOff.TabIndex = 12
        Me.btnCellOff.Text = "Cell Off"
        Me.btnCellOff.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Bias :"
        '
        'tbBiasValue
        '
        Me.tbBiasValue.Location = New System.Drawing.Point(63, 18)
        Me.tbBiasValue.Name = "tbBiasValue"
        Me.tbBiasValue.Size = New System.Drawing.Size(79, 20)
        Me.tbBiasValue.TabIndex = 10
        Me.tbBiasValue.Text = "3"
        '
        'btnCellOn
        '
        Me.btnCellOn.Location = New System.Drawing.Point(207, 15)
        Me.btnCellOn.Name = "btnCellOn"
        Me.btnCellOn.Size = New System.Drawing.Size(55, 26)
        Me.btnCellOn.TabIndex = 8
        Me.btnCellOn.Text = "Cell On"
        Me.btnCellOn.UseVisualStyleBackColor = True
        '
        'tbConnectionStatus
        '
        Me.tbConnectionStatus.Location = New System.Drawing.Point(5, 391)
        Me.tbConnectionStatus.Multiline = True
        Me.tbConnectionStatus.Name = "tbConnectionStatus"
        Me.tbConnectionStatus.Size = New System.Drawing.Size(415, 81)
        Me.tbConnectionStatus.TabIndex = 4
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(12, 343)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(119, 41)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(146, 343)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(119, 41)
        Me.btnDisconnection.TabIndex = 1
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnOptionSet
        '
        Me.btnOptionSet.Location = New System.Drawing.Point(869, 418)
        Me.btnOptionSet.Name = "btnOptionSet"
        Me.btnOptionSet.Size = New System.Drawing.Size(116, 43)
        Me.btnOptionSet.TabIndex = 15
        Me.btnOptionSet.Text = "Initialize"
        Me.btnOptionSet.UseVisualStyleBackColor = True
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.gbGPIBSet)
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.gbIPSet)
        Me.gbConfig.Controls.Add(Me.ucConfigRs232)
        Me.gbConfig.Controls.Add(Me.tbConnectionStatus)
        Me.gbConfig.Controls.Add(Me.btnConnection)
        Me.gbConfig.Controls.Add(Me.btnDisconnection)
        Me.gbConfig.Location = New System.Drawing.Point(10, 13)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(447, 499)
        Me.gbConfig.TabIndex = 11
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Communication"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(282, 343)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(119, 41)
        Me.btnClear.TabIndex = 19
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'gbGPIBSet
        '
        Me.gbGPIBSet.Controls.Add(Me.tbAddressNumber)
        Me.gbGPIBSet.Controls.Add(Me.Label1)
        Me.gbGPIBSet.Location = New System.Drawing.Point(213, 86)
        Me.gbGPIBSet.Name = "gbGPIBSet"
        Me.gbGPIBSet.Size = New System.Drawing.Size(151, 46)
        Me.gbGPIBSet.TabIndex = 18
        Me.gbGPIBSet.TabStop = False
        Me.gbGPIBSet.Text = "GPIB"
        '
        'tbAddressNumber
        '
        Me.tbAddressNumber.Location = New System.Drawing.Point(63, 14)
        Me.tbAddressNumber.Name = "tbAddressNumber"
        Me.tbAddressNumber.Size = New System.Drawing.Size(79, 20)
        Me.tbAddressNumber.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Address :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cbSelCommType)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(219, 48)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Communication Type :"
        '
        'cbSelCommType
        '
        Me.cbSelCommType.FormattingEnabled = True
        Me.cbSelCommType.Location = New System.Drawing.Point(126, 15)
        Me.cbSelCommType.Name = "cbSelCommType"
        Me.cbSelCommType.Size = New System.Drawing.Size(81, 21)
        Me.cbSelCommType.TabIndex = 13
        '
        'gbIPSet
        '
        Me.gbIPSet.Controls.Add(Me.GroupBox2)
        Me.gbIPSet.Controls.Add(Me.GroupBox4)
        Me.gbIPSet.Location = New System.Drawing.Point(213, 144)
        Me.gbIPSet.Name = "gbIPSet"
        Me.gbIPSet.Size = New System.Drawing.Size(229, 109)
        Me.gbIPSet.TabIndex = 16
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
        Me.txtPort.Location = New System.Drawing.Point(33, 12)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(43, 20)
        Me.txtPort.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtIPBox4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtIPBox3)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtIPBox2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txtIPBox1)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(219, 46)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
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
        Me.Label5.Size = New System.Drawing.Size(10, 13)
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
        Me.Label4.Size = New System.Drawing.Size(10, 13)
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
        Me.Label3.Size = New System.Drawing.Size(10, 13)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "IP"
        '
        'ucConfigRs232
        '
        Me.ucConfigRs232.BAUDRATE = 9600
        Me.ucConfigRs232.COMPORT = "COM1"
        Me.ucConfigRs232.DATABIT = 8
        Me.ucConfigRs232.Location = New System.Drawing.Point(5, 86)
        Me.ucConfigRs232.Name = "ucConfigRs232"
        Me.ucConfigRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucConfigRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucConfigRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucConfigRs232.Size = New System.Drawing.Size(203, 251)
        Me.ucConfigRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucConfigRs232.TabIndex = 5
        Me.ucConfigRs232.Title = "RS232"
        '
        'ucKeithleyCommon
        '
        Me.ucKeithleyCommon.Location = New System.Drawing.Point(467, 140)
        Me.ucKeithleyCommon.Name = "ucKeithleyCommon"
        Me.ucKeithleyCommon.Size = New System.Drawing.Size(526, 332)
        Me.ucKeithleyCommon.TabIndex = 14
        '
        'frmK26XXControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 683)
        Me.Controls.Add(Me.btnOptionSet)
        Me.Controls.Add(Me.ucKeithleyCommon)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "frmK26XXControl"
        Me.Text = "frmK26XXControl"
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.gbConfig.ResumeLayout(False)
        Me.gbConfig.PerformLayout()
        Me.gbGPIBSet.ResumeLayout(False)
        Me.gbGPIBSet.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbIPSet.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetBias As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbReadCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbReadVolt As System.Windows.Forms.TextBox
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents btnCellOff As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbBiasValue As System.Windows.Forms.TextBox
    Friend WithEvents btnCellOn As System.Windows.Forms.Button
    Friend WithEvents tbConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents ucKeithleyCommon As CSMULib.ucKeithleySMUSettings
    Friend WithEvents btnOptionSet As System.Windows.Forms.Button
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents ucConfigRs232 As CCommLib.ucConfigRs232
    Friend WithEvents gbGPIBSet As System.Windows.Forms.GroupBox
    Friend WithEvents tbAddressNumber As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbSelCommType As System.Windows.Forms.ComboBox
    Friend WithEvents gbIPSet As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIPBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIPBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class
