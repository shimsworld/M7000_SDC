<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSelectValueTypeAndUnit
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
        Me.cbSelUnit1 = New System.Windows.Forms.ComboBox()
        Me.cbSelValueType = New System.Windows.Forms.ComboBox()
        Me.cbSelUnit2 = New System.Windows.Forms.ComboBox()
        Me.lblDevider = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbSelUnit1
        '
        Me.cbSelUnit1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelUnit1.FormattingEnabled = True
        Me.cbSelUnit1.Location = New System.Drawing.Point(159, 3)
        Me.cbSelUnit1.Name = "cbSelUnit1"
        Me.cbSelUnit1.Size = New System.Drawing.Size(57, 20)
        Me.cbSelUnit1.TabIndex = 1
        '
        'cbSelValueType
        '
        Me.cbSelValueType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelValueType.FormattingEnabled = True
        Me.cbSelValueType.Location = New System.Drawing.Point(3, 3)
        Me.cbSelValueType.Name = "cbSelValueType"
        Me.cbSelValueType.Size = New System.Drawing.Size(150, 20)
        Me.cbSelValueType.TabIndex = 2
        '
        'cbSelUnit2
        '
        Me.cbSelUnit2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelUnit2.FormattingEnabled = True
        Me.cbSelUnit2.Location = New System.Drawing.Point(233, 3)
        Me.cbSelUnit2.Name = "cbSelUnit2"
        Me.cbSelUnit2.Size = New System.Drawing.Size(57, 20)
        Me.cbSelUnit2.TabIndex = 3
        '
        'lblDevider
        '
        Me.lblDevider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDevider.AutoSize = True
        Me.lblDevider.Location = New System.Drawing.Point(219, 6)
        Me.lblDevider.Name = "lblDevider"
        Me.lblDevider.Size = New System.Drawing.Size(11, 12)
        Me.lblDevider.TabIndex = 4
        Me.lblDevider.Text = "/"
        '
        'ucSelectValueTypeAndUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDevider)
        Me.Controls.Add(Me.cbSelUnit2)
        Me.Controls.Add(Me.cbSelValueType)
        Me.Controls.Add(Me.cbSelUnit1)
        Me.Name = "ucSelectValueTypeAndUnit"
        Me.Size = New System.Drawing.Size(293, 28)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSelUnit1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbSelValueType As System.Windows.Forms.ComboBox
    Friend WithEvents cbSelUnit2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblDevider As System.Windows.Forms.Label

End Class
