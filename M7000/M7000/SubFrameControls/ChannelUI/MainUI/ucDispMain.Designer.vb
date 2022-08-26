<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDispMain
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
        Me.panelmain = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'panelmain
        '
        Me.panelmain.BackColor = System.Drawing.SystemColors.Control
        Me.panelmain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelmain.Location = New System.Drawing.Point(0, 0)
        Me.panelmain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelmain.Name = "panelmain"
        Me.panelmain.Size = New System.Drawing.Size(1367, 764)
        Me.panelmain.TabIndex = 0
        '
        'ucDispMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelmain)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ucDispMain"
        Me.Size = New System.Drawing.Size(1367, 764)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelmain As Panel
End Class
