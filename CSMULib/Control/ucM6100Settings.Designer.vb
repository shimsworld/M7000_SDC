<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucM6100Settings
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
        Me.gbM6100 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCurrRange = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbPCV = New System.Windows.Forms.RadioButton()
        Me.rbCV = New System.Windows.Forms.RadioButton()
        Me.rbCC = New System.Windows.Forms.RadioButton()
        Me.gbM6100.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbM6100
        '
        Me.gbM6100.Controls.Add(Me.GroupBox2)
        Me.gbM6100.Controls.Add(Me.GroupBox1)
        Me.gbM6100.Location = New System.Drawing.Point(7, 13)
        Me.gbM6100.Name = "gbM6100"
        Me.gbM6100.Size = New System.Drawing.Size(299, 155)
        Me.gbM6100.TabIndex = 2
        Me.gbM6100.TabStop = False
        Me.gbM6100.Text = "Settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCurrRange)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(245, 64)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Current Range"
        Me.GroupBox2.Visible = False
        '
        'cboCurrRange
        '
        Me.cboCurrRange.FormattingEnabled = True
        Me.cboCurrRange.Location = New System.Drawing.Point(109, 28)
        Me.cboCurrRange.Name = "cboCurrRange"
        Me.cboCurrRange.Size = New System.Drawing.Size(121, 20)
        Me.cboCurrRange.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current Range"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPCV)
        Me.GroupBox1.Controls.Add(Me.rbCV)
        Me.GroupBox1.Controls.Add(Me.rbCC)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 47)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bias Mode"
        '
        'rbPCV
        '
        Me.rbPCV.AutoSize = True
        Me.rbPCV.Location = New System.Drawing.Point(141, 20)
        Me.rbPCV.Name = "rbPCV"
        Me.rbPCV.Size = New System.Drawing.Size(48, 16)
        Me.rbPCV.TabIndex = 2
        Me.rbPCV.Text = "PCV"
        Me.rbPCV.UseVisualStyleBackColor = True
        Me.rbPCV.Visible = False
        '
        'rbCV
        '
        Me.rbCV.AutoSize = True
        Me.rbCV.Checked = True
        Me.rbCV.Location = New System.Drawing.Point(8, 20)
        Me.rbCV.Name = "rbCV"
        Me.rbCV.Size = New System.Drawing.Size(40, 16)
        Me.rbCV.TabIndex = 1
        Me.rbCV.TabStop = True
        Me.rbCV.Text = "CV"
        Me.rbCV.UseVisualStyleBackColor = True
        '
        'rbCC
        '
        Me.rbCC.AutoSize = True
        Me.rbCC.Location = New System.Drawing.Point(77, 20)
        Me.rbCC.Name = "rbCC"
        Me.rbCC.Size = New System.Drawing.Size(41, 16)
        Me.rbCC.TabIndex = 0
        Me.rbCC.Text = "CC"
        Me.rbCC.UseVisualStyleBackColor = True
        '
        'ucM6100Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbM6100)
        Me.Name = "ucM6100Settings"
        Me.Size = New System.Drawing.Size(387, 216)
        Me.gbM6100.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbM6100 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents rbCV As System.Windows.Forms.RadioButton
    Public WithEvents rbCC As System.Windows.Forms.RadioButton
    Public WithEvents rbPCV As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCurrRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
