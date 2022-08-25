<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRefPDSetting
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
        Me.gbRefPD = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRenewalTime = New System.Windows.Forms.TextBox()
        Me.cbRenewalMode = New System.Windows.Forms.ComboBox()
        Me.gbRefPD.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbRefPD
        '
        Me.gbRefPD.Controls.Add(Me.Label4)
        Me.gbRefPD.Controls.Add(Me.Label3)
        Me.gbRefPD.Controls.Add(Me.Label2)
        Me.gbRefPD.Controls.Add(Me.txtRenewalTime)
        Me.gbRefPD.Controls.Add(Me.cbRenewalMode)
        Me.gbRefPD.Location = New System.Drawing.Point(40, 31)
        Me.gbRefPD.Name = "gbRefPD"
        Me.gbRefPD.Size = New System.Drawing.Size(211, 72)
        Me.gbRefPD.TabIndex = 0
        Me.gbRefPD.TabStop = False
        Me.gbRefPD.Text = "Ref. Luminance(Ref. PD)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Min"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Renewal Time :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Renewal Mode :"
        '
        'txtRenewalTime
        '
        Me.txtRenewalTime.Location = New System.Drawing.Point(110, 46)
        Me.txtRenewalTime.Name = "txtRenewalTime"
        Me.txtRenewalTime.Size = New System.Drawing.Size(62, 21)
        Me.txtRenewalTime.TabIndex = 2
        Me.txtRenewalTime.Text = "0"
        Me.txtRenewalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbRenewalMode
        '
        Me.cbRenewalMode.FormattingEnabled = True
        Me.cbRenewalMode.Location = New System.Drawing.Point(110, 20)
        Me.cbRenewalMode.Name = "cbRenewalMode"
        Me.cbRenewalMode.Size = New System.Drawing.Size(62, 20)
        Me.cbRenewalMode.TabIndex = 1
        Me.cbRenewalMode.Text = "OFF"
        '
        'ucRefPDSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbRefPD)
        Me.Name = "ucRefPDSetting"
        Me.Size = New System.Drawing.Size(321, 216)
        Me.gbRefPD.ResumeLayout(False)
        Me.gbRefPD.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbRefPD As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRenewalTime As System.Windows.Forms.TextBox
    Friend WithEvents cbRenewalMode As System.Windows.Forms.ComboBox

End Class
