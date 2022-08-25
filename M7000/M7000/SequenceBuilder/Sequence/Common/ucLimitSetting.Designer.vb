<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLimitSetting
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
        Me.gbLimit = New System.Windows.Forms.GroupBox()
        Me.tbCurrentLow_Max = New System.Windows.Forms.TextBox()
        Me.tbCurrentLow_Min = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbVoltLow_Max = New System.Windows.Forms.TextBox()
        Me.tbVoltLow_Min = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbLimit.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbLimit
        '
        Me.gbLimit.Controls.Add(Me.tbCurrentLow_Max)
        Me.gbLimit.Controls.Add(Me.tbCurrentLow_Min)
        Me.gbLimit.Controls.Add(Me.Label5)
        Me.gbLimit.Controls.Add(Me.tbVoltLow_Max)
        Me.gbLimit.Controls.Add(Me.tbVoltLow_Min)
        Me.gbLimit.Controls.Add(Me.Label3)
        Me.gbLimit.Controls.Add(Me.Label2)
        Me.gbLimit.Controls.Add(Me.Label1)
        Me.gbLimit.Location = New System.Drawing.Point(3, 3)
        Me.gbLimit.Name = "gbLimit"
        Me.gbLimit.Size = New System.Drawing.Size(229, 90)
        Me.gbLimit.TabIndex = 0
        Me.gbLimit.TabStop = False
        Me.gbLimit.Text = "Limit Settings"
        '
        'tbCurrentLow_Max
        '
        Me.tbCurrentLow_Max.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCurrentLow_Max.BackColor = System.Drawing.SystemColors.Control
        Me.tbCurrentLow_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCurrentLow_Max.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbCurrentLow_Max.Location = New System.Drawing.Point(161, 60)
        Me.tbCurrentLow_Max.Name = "tbCurrentLow_Max"
        Me.tbCurrentLow_Max.Size = New System.Drawing.Size(58, 21)
        Me.tbCurrentLow_Max.TabIndex = 4
        Me.tbCurrentLow_Max.Text = "0"
        Me.tbCurrentLow_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCurrentLow_Min
        '
        Me.tbCurrentLow_Min.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCurrentLow_Min.BackColor = System.Drawing.SystemColors.Control
        Me.tbCurrentLow_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCurrentLow_Min.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbCurrentLow_Min.Location = New System.Drawing.Point(95, 60)
        Me.tbCurrentLow_Min.Name = "tbCurrentLow_Min"
        Me.tbCurrentLow_Min.Size = New System.Drawing.Size(58, 21)
        Me.tbCurrentLow_Min.TabIndex = 3
        Me.tbCurrentLow_Min.Text = "0"
        Me.tbCurrentLow_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(6, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 18)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Current(mA)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbVoltLow_Max
        '
        Me.tbVoltLow_Max.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVoltLow_Max.BackColor = System.Drawing.SystemColors.Control
        Me.tbVoltLow_Max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbVoltLow_Max.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbVoltLow_Max.Location = New System.Drawing.Point(161, 33)
        Me.tbVoltLow_Max.Name = "tbVoltLow_Max"
        Me.tbVoltLow_Max.Size = New System.Drawing.Size(58, 21)
        Me.tbVoltLow_Max.TabIndex = 2
        Me.tbVoltLow_Max.Text = "0"
        Me.tbVoltLow_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbVoltLow_Min
        '
        Me.tbVoltLow_Min.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVoltLow_Min.BackColor = System.Drawing.SystemColors.Control
        Me.tbVoltLow_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbVoltLow_Min.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbVoltLow_Min.Location = New System.Drawing.Point(95, 33)
        Me.tbVoltLow_Min.Name = "tbVoltLow_Min"
        Me.tbVoltLow_Min.Size = New System.Drawing.Size(58, 21)
        Me.tbVoltLow_Min.TabIndex = 1
        Me.tbVoltLow_Min.Text = "0"
        Me.tbVoltLow_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Max"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Min"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Voltage(V)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucLimitSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbLimit)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucLimitSetting"
        Me.Size = New System.Drawing.Size(242, 108)
        Me.gbLimit.ResumeLayout(False)
        Me.gbLimit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbLimit As System.Windows.Forms.GroupBox
    Friend WithEvents tbCurrentLow_Max As System.Windows.Forms.TextBox
    Friend WithEvents tbCurrentLow_Min As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbVoltLow_Max As System.Windows.Forms.TextBox
    Friend WithEvents tbVoltLow_Min As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
