<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLCAlarm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.btnHide = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(556, 306)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(137, 61)
        Me.btnHide.TabIndex = 0
        Me.btnHide.Text = "Button1"
        Me.btnHide.UseVisualStyleBackColor = True
        Me.btnHide.Visible = False
        '
        'frmPLCAlarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(705, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHide)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPLCAlarm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "FrmPLCAlarm"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHide As System.Windows.Forms.Button
End Class
