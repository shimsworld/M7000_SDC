<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAcf
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAdjusting = New System.Windows.Forms.Button()
        Me.btnRunAC = New System.Windows.Forms.Button()
        Me.btnRunAF = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdjusting)
        Me.GroupBox1.Controls.Add(Me.btnRunAC)
        Me.GroupBox1.Controls.Add(Me.btnRunAF)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ACF (Auto Centering & Focusing)"
        '
        'btnAdjusting
        '
        Me.btnAdjusting.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnAdjusting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAdjusting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnAdjusting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjusting.Location = New System.Drawing.Point(230, 18)
        Me.btnAdjusting.Name = "btnAdjusting"
        Me.btnAdjusting.Size = New System.Drawing.Size(110, 30)
        Me.btnAdjusting.TabIndex = 2
        Me.btnAdjusting.Text = "Adjusting"
        Me.btnAdjusting.UseVisualStyleBackColor = False
        '
        'btnRunAC
        '
        Me.btnRunAC.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnRunAC.FlatAppearance.BorderSize = 0
        Me.btnRunAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRunAC.Location = New System.Drawing.Point(121, 18)
        Me.btnRunAC.Name = "btnRunAC"
        Me.btnRunAC.Size = New System.Drawing.Size(110, 30)
        Me.btnRunAC.TabIndex = 1
        Me.btnRunAC.Text = "Run AC"
        Me.btnRunAC.UseVisualStyleBackColor = False
        '
        'btnRunAF
        '
        Me.btnRunAF.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnRunAF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRunAF.Location = New System.Drawing.Point(11, 18)
        Me.btnRunAF.Name = "btnRunAF"
        Me.btnRunAF.Size = New System.Drawing.Size(110, 30)
        Me.btnRunAF.TabIndex = 0
        Me.btnRunAF.Text = "Run AF"
        Me.btnRunAF.UseVisualStyleBackColor = False
        '
        'ucAcf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucAcf"
        Me.Size = New System.Drawing.Size(365, 136)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdjusting As System.Windows.Forms.Button
    Friend WithEvents btnRunAC As System.Windows.Forms.Button
    Friend WithEvents btnRunAF As System.Windows.Forms.Button

End Class
