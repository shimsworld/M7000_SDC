<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeithleySMUSettings
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
        Me.UcKeithleySMUSettings1 = New CSMULib.ucKeithleySMUSettings()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UcKeithleySMUSettings1
        '
        Me.UcKeithleySMUSettings1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcKeithleySMUSettings1.Location = New System.Drawing.Point(3, 2)
        Me.UcKeithleySMUSettings1.Name = "UcKeithleySMUSettings1"
        Me.UcKeithleySMUSettings1.Size = New System.Drawing.Size(639, 334)
        Me.UcKeithleySMUSettings1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(474, 342)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(79, 33)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(559, 342)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmKeithleySMUSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(646, 381)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.UcKeithleySMUSettings1)
        Me.Name = "frmKeithleySMUSettings"
        Me.Text = "Keithley SMU Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcKeithleySMUSettings1 As CSMULib.ucKeithleySMUSettings
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
