<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigMultiRS232
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
        Me.components = New System.ComponentModel.Container()
        Me.gbConfig = New System.Windows.Forms.GroupBox()
        Me.ucDispRs232 = New CCommLib.ucConfigRs232()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOFFLine = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.ConfigList = New CCommLib.ucDispListView()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.gbConfig.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.ucDispRs232)
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Location = New System.Drawing.Point(21, 18)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(1012, 396)
        Me.gbConfig.TabIndex = 6
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
        '
        'ucDispRs232
        '
        Me.ucDispRs232.BAUDRATE = 19200
        Me.ucDispRs232.COMPORT = Nothing
        Me.ucDispRs232.DATABIT = 8
        Me.ucDispRs232.Location = New System.Drawing.Point(289, 20)
        Me.ucDispRs232.Name = "ucDispRs232"
        Me.ucDispRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucDispRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.Size = New System.Drawing.Size(246, 202)
        Me.ucDispRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucDispRs232.TabIndex = 14
        Me.ucDispRs232.Title = "RS232"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOFFLine)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox3.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 101)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(19, 78)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 23
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(173, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(193, 22)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(117, 22)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(541, 30)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(75, 43)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(541, 108)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(541, 79)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(75, 23)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No", "Setting Parameter", "Allocation Ch", "Status"}
        Me.ConfigList.ColHeaderWidthRatio = "10,35,35,20"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(11, 228)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(576, 134)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ucConfigMultiRS232
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigMultiRS232"
        Me.Size = New System.Drawing.Size(1209, 465)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents ConfigList As ucDispListView
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox
    Friend WithEvents ucDispRs232 As CCommLib.ucConfigRs232
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
