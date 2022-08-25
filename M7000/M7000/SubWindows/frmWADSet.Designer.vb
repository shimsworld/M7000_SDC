<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWADSet
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblWADFactor_X = New System.Windows.Forms.Label()
        Me.lblWADFactor_Y = New System.Windows.Forms.Label()
        Me.lblWADFactor_Z = New System.Windows.Forms.Label()
        Me.Lb_Display_num = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(446, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 33)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(367, 244)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 33)
        Me.btnOk.TabIndex = 27
        Me.btnOk.Text = "Set"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblWADFactor_X
        '
        Me.lblWADFactor_X.BackColor = System.Drawing.Color.Gainsboro
        Me.lblWADFactor_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWADFactor_X.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWADFactor_X.ForeColor = System.Drawing.Color.DimGray
        Me.lblWADFactor_X.Location = New System.Drawing.Point(80, 9)
        Me.lblWADFactor_X.Name = "lblWADFactor_X"
        Me.lblWADFactor_X.Size = New System.Drawing.Size(133, 22)
        Me.lblWADFactor_X.TabIndex = 29
        Me.lblWADFactor_X.Text = "WAD Factor X"
        Me.lblWADFactor_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWADFactor_Y
        '
        Me.lblWADFactor_Y.BackColor = System.Drawing.Color.Gainsboro
        Me.lblWADFactor_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWADFactor_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWADFactor_Y.ForeColor = System.Drawing.Color.DimGray
        Me.lblWADFactor_Y.Location = New System.Drawing.Point(219, 9)
        Me.lblWADFactor_Y.Name = "lblWADFactor_Y"
        Me.lblWADFactor_Y.Size = New System.Drawing.Size(133, 22)
        Me.lblWADFactor_Y.TabIndex = 30
        Me.lblWADFactor_Y.Text = "WAD Factor Y"
        Me.lblWADFactor_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWADFactor_Z
        '
        Me.lblWADFactor_Z.BackColor = System.Drawing.Color.Gainsboro
        Me.lblWADFactor_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWADFactor_Z.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWADFactor_Z.ForeColor = System.Drawing.Color.DimGray
        Me.lblWADFactor_Z.Location = New System.Drawing.Point(358, 9)
        Me.lblWADFactor_Z.Name = "lblWADFactor_Z"
        Me.lblWADFactor_Z.Size = New System.Drawing.Size(133, 22)
        Me.lblWADFactor_Z.TabIndex = 31
        Me.lblWADFactor_Z.Text = "WAD Factor Z"
        Me.lblWADFactor_Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Display_num
        '
        Me.Lb_Display_num.BackColor = System.Drawing.Color.Gainsboro
        Me.Lb_Display_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_Display_num.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Display_num.ForeColor = System.Drawing.Color.DimGray
        Me.Lb_Display_num.Location = New System.Drawing.Point(12, 10)
        Me.Lb_Display_num.Name = "Lb_Display_num"
        Me.Lb_Display_num.Size = New System.Drawing.Size(61, 20)
        Me.Lb_Display_num.TabIndex = 32
        Me.Lb_Display_num.Text = "X"
        Me.Lb_Display_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmWADSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(525, 284)
        Me.Controls.Add(Me.Lb_Display_num)
        Me.Controls.Add(Me.lblWADFactor_Z)
        Me.Controls.Add(Me.lblWADFactor_Y)
        Me.Controls.Add(Me.lblWADFactor_X)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmWADSet"
        Me.Text = "WAD Calibration Factor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblWADFactor_X As System.Windows.Forms.Label
    Friend WithEvents lblWADFactor_Y As System.Windows.Forms.Label
    Friend WithEvents lblWADFactor_Z As System.Windows.Forms.Label
    Friend WithEvents Lb_Display_num As System.Windows.Forms.Label
End Class
