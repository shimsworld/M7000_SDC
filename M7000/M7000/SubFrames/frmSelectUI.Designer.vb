<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectUI
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
        Me.rb6X5 = New System.Windows.Forms.RadioButton()
        Me.rb2X2 = New System.Windows.Forms.RadioButton()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rb6X5
        '
        Me.rb6X5.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb6X5.AutoSize = True
        Me.rb6X5.BackColor = System.Drawing.Color.White
        Me.rb6X5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rb6X5.Font = New System.Drawing.Font("Segoe UI", 41.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb6X5.Location = New System.Drawing.Point(23, 20)
        Me.rb6X5.Name = "rb6X5"
        Me.rb6X5.Size = New System.Drawing.Size(622, 86)
        Me.rb6X5.TabIndex = 0
        Me.rb6X5.TabStop = True
        Me.rb6X5.Text = "TYPE 01 : 6 X 5 (30CH)"
        Me.rb6X5.UseVisualStyleBackColor = False
        '
        'rb2X2
        '
        Me.rb2X2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rb2X2.AutoSize = True
        Me.rb2X2.BackColor = System.Drawing.Color.White
        Me.rb2X2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rb2X2.Font = New System.Drawing.Font("Segoe UI", 41.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2X2.Location = New System.Drawing.Point(23, 125)
        Me.rb2X2.Name = "rb2X2"
        Me.rb2X2.Size = New System.Drawing.Size(622, 86)
        Me.rb2X2.TabIndex = 1
        Me.rb2X2.TabStop = True
        Me.rb2X2.Text = "TYPE 02 : 2 X 2 (04CH)"
        Me.rb2X2.UseVisualStyleBackColor = False
        '
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.Silver
        Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(23, 226)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(724, 91)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = False
        '
        'frmSelectUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 327)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.rb2X2)
        Me.Controls.Add(Me.rb6X5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSelectUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                                                                                 " & _
    "      TYPE SELECT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rb6X5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2X2 As System.Windows.Forms.RadioButton
    Friend WithEvents btnSelect As System.Windows.Forms.Button
End Class
