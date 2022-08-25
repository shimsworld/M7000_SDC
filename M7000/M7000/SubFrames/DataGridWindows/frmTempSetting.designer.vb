<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTempSetting
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
        Me.btnCalcle = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.UcTempSet = New M7000.ucTempSetting()
        Me.SuspendLayout()
        '
        'btnCalcle
        '
        Me.btnCalcle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCalcle.Location = New System.Drawing.Point(139, 94)
        Me.btnCalcle.Name = "btnCalcle"
        Me.btnCalcle.Size = New System.Drawing.Size(77, 28)
        Me.btnCalcle.TabIndex = 25
        Me.btnCalcle.Text = "Cancel"
        Me.btnCalcle.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(56, 94)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(77, 28)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'UcTempSet
        '
        Me.UcTempSet.Location = New System.Drawing.Point(9, 12)
        Me.UcTempSet.Name = "UcTempSet"
        Me.UcTempSet.SetModeTime = 0.0R
        Me.UcTempSet.Size = New System.Drawing.Size(211, 73)
        Me.UcTempSet.TabIndex = 4
        Me.UcTempSet.TartgetTemp = 0.0R
        Me.UcTempSet.ViewMode = M7000.ucTempSetting.eViewMode.eAllView
        '
        'frmTempSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(230, 129)
        Me.Controls.Add(Me.btnCalcle)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UcTempSet)
        Me.Name = "frmTempSetting"
        Me.Text = "frmTempSetting"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcTempSet As M7000.ucTempSetting
    Friend WithEvents btnCalcle As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
