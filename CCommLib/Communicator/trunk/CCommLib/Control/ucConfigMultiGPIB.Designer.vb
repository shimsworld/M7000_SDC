<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigMultiGPIB
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
        Me.ucDispGPIB = New CCommLib.ucConfigGPIB()
        Me.ConfigList = New CCommLib.ucDispListView()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkOFFLine = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtChAlloEnd = New System.Windows.Forms.TextBox()
        Me.txtChAlloStart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbConfig.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.ucDispGPIB)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.GroupBox1)
        Me.gbConfig.Location = New System.Drawing.Point(15, 15)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(530, 274)
        Me.gbConfig.TabIndex = 17
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
        '
        'ucDispGPIB
        '
        Me.ucDispGPIB.ADDRESS = 0
        Me.ucDispGPIB.Location = New System.Drawing.Point(267, 16)
        Me.ucDispGPIB.Name = "ucDispGPIB"
        Me.ucDispGPIB.Size = New System.Drawing.Size(243, 50)
        Me.ucDispGPIB.TabIndex = 22
        Me.ucDispGPIB.Title = "GPIB"
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"No", "Address", "Allocation Ch", "State"}
        Me.ConfigList.ColHeaderWidthRatio = "10,30,30,30"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(6, 119)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(504, 140)
        Me.ConfigList.TabIndex = 21
        Me.ConfigList.UseCheckBoxex = False
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(267, 72)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(76, 41)
        Me.btnADD.TabIndex = 20
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(434, 72)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 41)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(349, 72)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(76, 41)
        Me.btnListDel.TabIndex = 19
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkOFFLine)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtChAlloEnd)
        Me.GroupBox1.Controls.Add(Me.txtChAlloStart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 97)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Common"
        '
        'chkOFFLine
        '
        Me.chkOFFLine.AutoSize = True
        Me.chkOFFLine.Location = New System.Drawing.Point(9, 76)
        Me.chkOFFLine.Name = "chkOFFLine"
        Me.chkOFFLine.Size = New System.Drawing.Size(74, 16)
        Me.chkOFFLine.TabIndex = 22
        Me.chkOFFLine.Text = "OFFLINE"
        Me.chkOFFLine.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "~"
        '
        'txtChAlloEnd
        '
        Me.txtChAlloEnd.Location = New System.Drawing.Point(186, 20)
        Me.txtChAlloEnd.Name = "txtChAlloEnd"
        Me.txtChAlloEnd.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloEnd.TabIndex = 9
        Me.txtChAlloEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtChAlloStart
        '
        Me.txtChAlloStart.Location = New System.Drawing.Point(115, 20)
        Me.txtChAlloStart.Name = "txtChAlloStart"
        Me.txtChAlloStart.Size = New System.Drawing.Size(50, 21)
        Me.txtChAlloStart.TabIndex = 8
        Me.txtChAlloStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Allocation Ch. :"
        '
        'ucConfigMultiGPIB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigMultiGPIB"
        Me.Size = New System.Drawing.Size(609, 344)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOFFLine As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChAlloEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtChAlloStart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConfigList As ucDispListView
    Friend WithEvents ucDispGPIB As CCommLib.ucConfigGPIB

End Class
