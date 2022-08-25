<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigSocket
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.GroupBox3.SuspendLayout()
        Me.gbIPSet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Controls.Add(Me.gbIPSet)
        Me.gbConfig.Location = New System.Drawing.Point(3, 3)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(609, 239)
        Me.gbConfig.TabIndex = 6
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
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
        Me.GroupBox3.Size = New System.Drawing.Size(262, 97)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Common"
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(21, 73)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 7
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(175, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(195, 30)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(119, 30)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Allocation Ch. :"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(515, 28)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(75, 38)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(515, 99)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(515, 71)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(75, 23)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No", "Setting Parametor", "Allocation Ch", "State"}
        Me.ConfigList.ColHeaderWidthRatio = "10,35,35,20"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(11, 127)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(579, 102)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'gbIPSet
        '
        Me.gbIPSet.Controls.Add(Me.GroupBox2)
        Me.gbIPSet.Controls.Add(Me.GroupBox1)
        Me.gbIPSet.Location = New System.Drawing.Point(279, 20)
        Me.gbIPSet.Name = "gbIPSet"
        Me.gbIPSet.Size = New System.Drawing.Size(230, 101)
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
        Me.txtPort.Size = New System.Drawing.Size(50, 21)
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
        Me.GroupBox1.Size = New System.Drawing.Size(215, 42)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtIPBox4
        '
        Me.txtIPBox4.Location = New System.Drawing.Point(170, 14)
        Me.txtIPBox4.Name = "txtIPBox4"
        Me.txtIPBox4.Size = New System.Drawing.Size(40, 21)
        Me.txtIPBox4.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(9, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "."
        '
        'txtIPBox3
        '
        Me.txtIPBox3.Location = New System.Drawing.Point(120, 14)
        Me.txtIPBox3.Name = "txtIPBox3"
        Me.txtIPBox3.Size = New System.Drawing.Size(40, 21)
        Me.txtIPBox3.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(9, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "."
        '
        'txtIPBox2
        '
        Me.txtIPBox2.Location = New System.Drawing.Point(70, 14)
        Me.txtIPBox2.Name = "txtIPBox2"
        Me.txtIPBox2.Size = New System.Drawing.Size(40, 21)
        Me.txtIPBox2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(9, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "."
        '
        'txtIPBox1
        '
        Me.txtIPBox1.Location = New System.Drawing.Point(20, 14)
        Me.txtIPBox1.Name = "txtIPBox1"
        Me.txtIPBox1.Size = New System.Drawing.Size(40, 21)
        Me.txtIPBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP"
        '
        'ucConfigSocket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigSocket"
        Me.Size = New System.Drawing.Size(686, 276)
        Me.gbConfig.ResumeLayout(False)
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents ConfigList As ucDispListView
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
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox

End Class
