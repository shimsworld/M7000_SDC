<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigRS485
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
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOFFLine = New System.Windows.Forms.CheckBox()
        Me.tbNumOfDevice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblAddRess = New System.Windows.Forms.Label()
        Me.UcConfigRs232 = New CCommLib.ucConfigRs232()
        Me.ConfigList = New CCommLib.ucDispListView()
        Me.gbConfig.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.UcConfigRs232)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Location = New System.Drawing.Point(3, 3)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(620, 374)
        Me.gbConfig.TabIndex = 7
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(538, 23)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(76, 43)
        Me.btnADD.TabIndex = 20
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(538, 101)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 23)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(538, 72)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(76, 23)
        Me.btnListDel.TabIndex = 19
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOFFLine)
        Me.GroupBox3.Controls.Add(Me.tbNumOfDevice)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox3.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtAddress)
        Me.GroupBox3.Controls.Add(Me.lblAddRess)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 135)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(17, 110)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 22
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'tbNumOfDevice
        '
        Me.tbNumOfDevice.Location = New System.Drawing.Point(126, 19)
        Me.tbNumOfDevice.Name = "tbNumOfDevice"
        Me.tbNumOfDevice.Size = New System.Drawing.Size(91, 21)
        Me.tbNumOfDevice.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 12)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "number Of Device :"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(202, 73)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(126, 73)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(126, 46)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(91, 21)
        Me.txtAddress.TabIndex = 16
        '
        'lblAddRess
        '
        Me.lblAddRess.AutoSize = True
        Me.lblAddRess.Location = New System.Drawing.Point(27, 49)
        Me.lblAddRess.Name = "lblAddRess"
        Me.lblAddRess.Size = New System.Drawing.Size(93, 12)
        Me.lblAddRess.TabIndex = 15
        Me.lblAddRess.Text = "Seed Address :"
        '
        'UcConfigRs232
        '
        Me.UcConfigRs232.BAUDRATE = 19200
        Me.UcConfigRs232.COMPORT = Nothing
        Me.UcConfigRs232.DATABIT = 8
        Me.UcConfigRs232.Location = New System.Drawing.Point(276, 16)
        Me.UcConfigRs232.Name = "UcConfigRs232"
        Me.UcConfigRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232.Size = New System.Drawing.Size(239, 204)
        Me.UcConfigRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232.TabIndex = 7
        Me.UcConfigRs232.Title = "Settng"
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No", "number Of Device", "seed Addr", "Settings", "Allocation Ch", "State"}
        Me.ConfigList.ColHeaderWidthRatio = "10,20,15,20,20,15"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(6, 226)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(576, 140)
        Me.ConfigList.TabIndex = 6
        Me.ConfigList.UseCheckBoxex = False
        '
        'ucConfigRS485
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigRS485"
        Me.Size = New System.Drawing.Size(637, 392)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcConfigRs232 As ucConfigRs232
    Friend WithEvents ConfigList As ucDispListView
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAddRess As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents tbNumOfDevice As System.Windows.Forms.TextBox
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox

End Class
