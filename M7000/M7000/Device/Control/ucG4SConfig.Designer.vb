<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucG4SConfig
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
        Me.tbNumOfDev = New System.Windows.Forms.TextBox()
        Me.tbSeedIP04 = New System.Windows.Forms.TextBox()
        Me.chkOFFLine = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbSeedIP03 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbSeedIP02 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbSeedIP01 = New System.Windows.Forms.TextBox()
        Me.tbServerOpenTime = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbConfig.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbIPSet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.gbIPSet)
        Me.gbConfig.Location = New System.Drawing.Point(19, 3)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(558, 198)
        Me.gbConfig.TabIndex = 1
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbNumOfDev)
        Me.GroupBox3.Controls.Add(Me.tbSeedIP04)
        Me.GroupBox3.Controls.Add(Me.chkOFFLine)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tbSeedIP03)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.tbSeedIP02)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.tbSeedIP01)
        Me.GroupBox3.Controls.Add(Me.tbServerOpenTime)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox3.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(262, 160)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'tbNumOfDev
        '
        Me.tbNumOfDev.Location = New System.Drawing.Point(131, 107)
        Me.tbNumOfDev.Name = "tbNumOfDev"
        Me.tbNumOfDev.Size = New System.Drawing.Size(79, 21)
        Me.tbNumOfDev.TabIndex = 21
        Me.tbNumOfDev.Text = "15"
        Me.tbNumOfDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSeedIP04
        '
        Me.tbSeedIP04.Location = New System.Drawing.Point(211, 77)
        Me.tbSeedIP04.Name = "tbSeedIP04"
        Me.tbSeedIP04.Size = New System.Drawing.Size(40, 21)
        Me.tbSeedIP04.TabIndex = 20
        Me.tbSeedIP04.Text = "11"
        Me.tbSeedIP04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(15, 138)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 7
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(204, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(9, 12)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "."
        '
        'tbSeedIP03
        '
        Me.tbSeedIP03.Location = New System.Drawing.Point(163, 77)
        Me.tbSeedIP03.Name = "tbSeedIP03"
        Me.tbSeedIP03.Size = New System.Drawing.Size(40, 21)
        Me.tbSeedIP03.TabIndex = 18
        Me.tbSeedIP03.Text = "0"
        Me.tbSeedIP03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(156, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(9, 12)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "."
        '
        'tbSeedIP02
        '
        Me.tbSeedIP02.Location = New System.Drawing.Point(116, 77)
        Me.tbSeedIP02.Name = "tbSeedIP02"
        Me.tbSeedIP02.Size = New System.Drawing.Size(40, 21)
        Me.tbSeedIP02.TabIndex = 16
        Me.tbSeedIP02.Text = "168"
        Me.tbSeedIP02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(108, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(9, 12)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "."
        '
        'tbSeedIP01
        '
        Me.tbSeedIP01.Location = New System.Drawing.Point(69, 77)
        Me.tbSeedIP01.Name = "tbSeedIP01"
        Me.tbSeedIP01.Size = New System.Drawing.Size(40, 21)
        Me.tbSeedIP01.TabIndex = 14
        Me.tbSeedIP01.Text = "192"
        Me.tbSeedIP01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbServerOpenTime
        '
        Me.tbServerOpenTime.Location = New System.Drawing.Point(164, 49)
        Me.tbServerOpenTime.Name = "tbServerOpenTime"
        Me.tbServerOpenTime.Size = New System.Drawing.Size(79, 21)
        Me.tbServerOpenTime.TabIndex = 13
        Me.tbServerOpenTime.Text = "10"
        Me.tbServerOpenTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 12)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Number Of Device :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Seed IP :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 12)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Server Open Time(Sec) :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(174, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(193, 20)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.Text = "25"
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(117, 20)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.Text = "1"
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'gbIPSet
        '
        Me.gbIPSet.Controls.Add(Me.GroupBox2)
        Me.gbIPSet.Controls.Add(Me.GroupBox4)
        Me.gbIPSet.Location = New System.Drawing.Point(274, 21)
        Me.gbIPSet.Name = "gbIPSet"
        Me.gbIPSet.Size = New System.Drawing.Size(262, 97)
        Me.gbIPSet.TabIndex = 14
        Me.gbIPSet.TabStop = False
        Me.gbIPSet.Text = "Server IP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPort)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 38)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'txtPort
        '
        Me.txtPort.Enabled = False
        Me.txtPort.Location = New System.Drawing.Point(42, 11)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(72, 21)
        Me.txtPort.TabIndex = 7
        Me.txtPort.Text = "8888"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port :"
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
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 42)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'txtIPBox4
        '
        Me.txtIPBox4.Enabled = False
        Me.txtIPBox4.Location = New System.Drawing.Point(196, 14)
        Me.txtIPBox4.Name = "txtIPBox4"
        Me.txtIPBox4.Size = New System.Drawing.Size(45, 21)
        Me.txtIPBox4.TabIndex = 12
        Me.txtIPBox4.Text = "250"
        Me.txtIPBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(190, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(9, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "."
        '
        'txtIPBox3
        '
        Me.txtIPBox3.Enabled = False
        Me.txtIPBox3.Location = New System.Drawing.Point(145, 14)
        Me.txtIPBox3.Name = "txtIPBox3"
        Me.txtIPBox3.Size = New System.Drawing.Size(45, 21)
        Me.txtIPBox3.TabIndex = 10
        Me.txtIPBox3.Text = "0"
        Me.txtIPBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(138, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(9, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "."
        '
        'txtIPBox2
        '
        Me.txtIPBox2.Enabled = False
        Me.txtIPBox2.Location = New System.Drawing.Point(93, 14)
        Me.txtIPBox2.Name = "txtIPBox2"
        Me.txtIPBox2.Size = New System.Drawing.Size(45, 21)
        Me.txtIPBox2.TabIndex = 8
        Me.txtIPBox2.Text = "168"
        Me.txtIPBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(86, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(9, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "."
        '
        'txtIPBox1
        '
        Me.txtIPBox1.Enabled = False
        Me.txtIPBox1.Location = New System.Drawing.Point(42, 14)
        Me.txtIPBox1.Name = "txtIPBox1"
        Me.txtIPBox1.Size = New System.Drawing.Size(45, 21)
        Me.txtIPBox1.TabIndex = 6
        Me.txtIPBox1.Text = "192"
        Me.txtIPBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP :"
        '
        'ucG4SConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucG4SConfig"
        Me.Size = New System.Drawing.Size(840, 494)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbIPSet.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox
    Friend WithEvents tbNumOfDev As System.Windows.Forms.TextBox
    Friend WithEvents tbSeedIP04 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbSeedIP03 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbSeedIP02 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbSeedIP01 As System.Windows.Forms.TextBox
    Friend WithEvents tbServerOpenTime As System.Windows.Forms.TextBox

End Class
