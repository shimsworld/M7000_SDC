<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMainIVLJig
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.lbName)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel5.Size = New System.Drawing.Size(555, 325)
        Me.Panel5.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(545, 285)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Status"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbName
        '
        Me.lbName.BackColor = System.Drawing.Color.DarkGray
        Me.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbName.Location = New System.Drawing.Point(5, 5)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(545, 30)
        Me.lbName.TabIndex = 1
        Me.lbName.Text = "JIG #5"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucMainIVLJig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel5)
        Me.Name = "ucMainIVLJig"
        Me.Size = New System.Drawing.Size(555, 325)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lbName As Label
End Class
