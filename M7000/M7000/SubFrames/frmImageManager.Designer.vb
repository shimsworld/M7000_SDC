<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageManager
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancle = New System.Windows.Forms.Button()
        Me.ucPGImageManager = New M7000.UcDispPGImageManager()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(552, 699)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 30)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancle
        '
        Me.btnCancle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancle.Location = New System.Drawing.Point(619, 699)
        Me.btnCancle.Name = "btnCancle"
        Me.btnCancle.Size = New System.Drawing.Size(64, 30)
        Me.btnCancle.TabIndex = 3
        Me.btnCancle.Text = "Cancel"
        Me.btnCancle.UseVisualStyleBackColor = True
        '
        'ucPGImageManager
        '
        Me.ucPGImageManager.Location = New System.Drawing.Point(0, 1)
        Me.ucPGImageManager.Name = "ucPGImageManager"
        Me.ucPGImageManager.Size = New System.Drawing.Size(698, 690)
        Me.ucPGImageManager.TabIndex = 0
        '
        'frmImageManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(694, 732)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancle)
        Me.Controls.Add(Me.ucPGImageManager)
        Me.Name = "frmImageManager"
        Me.Text = "Image Manager"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucPGImageManager As UcDispPGImageManager
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancle As System.Windows.Forms.Button
End Class
