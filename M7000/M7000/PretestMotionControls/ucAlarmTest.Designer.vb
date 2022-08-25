<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAlarmTest
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
        Me.btnGreen = New System.Windows.Forms.Button()
        Me.btnYellow = New System.Windows.Forms.Button()
        Me.btnAlarm = New System.Windows.Forms.Button()
        Me.btnRed = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAlarmStop = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGreen
        '
        Me.btnGreen.BackColor = System.Drawing.Color.LimeGreen
        Me.btnGreen.Location = New System.Drawing.Point(5, 18)
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.Size = New System.Drawing.Size(70, 30)
        Me.btnGreen.TabIndex = 3
        Me.btnGreen.Text = "Green"
        Me.btnGreen.UseVisualStyleBackColor = False
        '
        'btnYellow
        '
        Me.btnYellow.BackColor = System.Drawing.Color.Yellow
        Me.btnYellow.Location = New System.Drawing.Point(74, 18)
        Me.btnYellow.Name = "btnYellow"
        Me.btnYellow.Size = New System.Drawing.Size(70, 30)
        Me.btnYellow.TabIndex = 4
        Me.btnYellow.Text = "Yellow"
        Me.btnYellow.UseVisualStyleBackColor = False
        '
        'btnAlarm
        '
        Me.btnAlarm.BackColor = System.Drawing.Color.Fuchsia
        Me.btnAlarm.Location = New System.Drawing.Point(212, 18)
        Me.btnAlarm.Name = "btnAlarm"
        Me.btnAlarm.Size = New System.Drawing.Size(70, 30)
        Me.btnAlarm.TabIndex = 6
        Me.btnAlarm.Text = "Alarm"
        Me.btnAlarm.UseVisualStyleBackColor = False
        '
        'btnRed
        '
        Me.btnRed.BackColor = System.Drawing.Color.Red
        Me.btnRed.Location = New System.Drawing.Point(143, 18)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(70, 30)
        Me.btnRed.TabIndex = 5
        Me.btnRed.Text = "Red"
        Me.btnRed.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAlarmStop)
        Me.GroupBox1.Controls.Add(Me.btnGreen)
        Me.GroupBox1.Controls.Add(Me.btnAlarm)
        Me.GroupBox1.Controls.Add(Me.btnYellow)
        Me.GroupBox1.Controls.Add(Me.btnRed)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 60)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alarm Test"
        '
        'btnAlarmStop
        '
        Me.btnAlarmStop.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnAlarmStop.Location = New System.Drawing.Point(285, 18)
        Me.btnAlarmStop.Name = "btnAlarmStop"
        Me.btnAlarmStop.Size = New System.Drawing.Size(75, 30)
        Me.btnAlarmStop.TabIndex = 7
        Me.btnAlarmStop.Text = "Alarm Stop"
        Me.btnAlarmStop.UseVisualStyleBackColor = False
        '
        'ucAlarmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucAlarmTest"
        Me.Size = New System.Drawing.Size(394, 65)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGreen As System.Windows.Forms.Button
    Friend WithEvents btnYellow As System.Windows.Forms.Button
    Friend WithEvents btnAlarm As System.Windows.Forms.Button
    Friend WithEvents btnRed As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAlarmStop As System.Windows.Forms.Button

End Class
