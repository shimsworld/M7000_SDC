<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigRS232_RS485
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOFFLine = New System.Windows.Forms.CheckBox()
        Me.tbNumOfDevice = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblAddRess = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbSelDeviceSelect = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbSelCommType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.ucDispRs232 = New CCommLib.ucConfigRs232()
        Me.ConfigList = New CCommLib.ucDispListView()
        Me.gbConfig.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.ucDispRs232)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Location = New System.Drawing.Point(8, 3)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(553, 470)
        Me.gbConfig.TabIndex = 8
        Me.gbConfig.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOFFLine)
        Me.GroupBox3.Controls.Add(Me.tbNumOfDevice)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtAddress)
        Me.GroupBox3.Controls.Add(Me.lblAddRess)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cbSelDeviceSelect)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cbSelCommType)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox3.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 202)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(29, 180)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 26
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'tbNumOfDevice
        '
        Me.tbNumOfDevice.Location = New System.Drawing.Point(147, 112)
        Me.tbNumOfDevice.Name = "tbNumOfDevice"
        Me.tbNumOfDevice.Size = New System.Drawing.Size(91, 21)
        Me.tbNumOfDevice.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 12)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "number Of Device :"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(147, 140)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(91, 21)
        Me.txtAddress.TabIndex = 24
        '
        'lblAddRess
        '
        Me.lblAddRess.AutoSize = True
        Me.lblAddRess.Location = New System.Drawing.Point(48, 144)
        Me.lblAddRess.Name = "lblAddRess"
        Me.lblAddRess.Size = New System.Drawing.Size(93, 12)
        Me.lblAddRess.TabIndex = 23
        Me.lblAddRess.Text = "Seed Address :"
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
        Me.Label7.Location = New System.Drawing.Point(203, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(223, 84)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(147, 84)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(156, 222)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(75, 38)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(321, 222)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 38)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(236, 222)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(81, 38)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ucDispRs232
        '
        Me.ucDispRs232.BAUDRATE = 19200
        Me.ucDispRs232.COMPORT = Nothing
        Me.ucDispRs232.DATABIT = 8
        Me.ucDispRs232.Location = New System.Drawing.Point(298, 14)
        Me.ucDispRs232.Name = "ucDispRs232"
        Me.ucDispRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucDispRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.Size = New System.Drawing.Size(241, 202)
        Me.ucDispRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucDispRs232.TabIndex = 8
        Me.ucDispRs232.Title = "RS232"
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No.", "Type", "Setting Parametor", "Allocation Ch", "Device"}
        Me.ConfigList.ColHeaderWidthRatio = "10,15,30,30,15"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(6, 265)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(533, 193)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'ucConfigRS232_RS485
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigRS232_RS485"
        Me.Size = New System.Drawing.Size(568, 483)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbSelDeviceSelect As System.Windows.Forms.ComboBox
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
    Friend WithEvents ConfigList As ucDispListView
    Friend WithEvents tbNumOfDevice As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAddRess As System.Windows.Forms.Label
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox

End Class
