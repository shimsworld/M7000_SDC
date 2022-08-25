<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCommonConditions
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
        Me.gbCommon = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelACFMode = New System.Windows.Forms.ComboBox()
        Me.lblACFMode = New System.Windows.Forms.Label()
        Me.tbDefaultTemp = New System.Windows.Forms.TextBox()
        Me.lblDefTemp = New System.Windows.Forms.Label()
        Me.UcLimitSetting1 = New M7000.ucLimitSetting()
        Me.ucSeqEndParam = New M7000.ucTestEndParam()
        Me.gbCommon.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCommon
        '
        Me.gbCommon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCommon.Controls.Add(Me.Label3)
        Me.gbCommon.Controls.Add(Me.cbSelACFMode)
        Me.gbCommon.Controls.Add(Me.lblACFMode)
        Me.gbCommon.Controls.Add(Me.tbDefaultTemp)
        Me.gbCommon.Controls.Add(Me.lblDefTemp)
        Me.gbCommon.Controls.Add(Me.UcLimitSetting1)
        Me.gbCommon.Controls.Add(Me.ucSeqEndParam)
        Me.gbCommon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCommon.Location = New System.Drawing.Point(3, 3)
        Me.gbCommon.Name = "gbCommon"
        Me.gbCommon.Size = New System.Drawing.Size(254, 347)
        Me.gbCommon.TabIndex = 0
        Me.gbCommon.TabStop = False
        Me.gbCommon.Text = "Common"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "℃"
        Me.Label3.Visible = False
        '
        'cbSelACFMode
        '
        Me.cbSelACFMode.FormattingEnabled = True
        Me.cbSelACFMode.Items.AddRange(New Object() {"EXCLUDE_AREA_LESS_EQUAL_50", "EXCLUDE_AREA_OUT_RANGE_50_50000", "EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5", "EXCLUDE_AREA_OUT_RANGE_1000_50000"})
        Me.cbSelACFMode.Location = New System.Drawing.Point(78, 49)
        Me.cbSelACFMode.Name = "cbSelACFMode"
        Me.cbSelACFMode.Size = New System.Drawing.Size(170, 23)
        Me.cbSelACFMode.TabIndex = 2
        Me.cbSelACFMode.Text = "ComboBox"
        '
        'lblACFMode
        '
        Me.lblACFMode.Location = New System.Drawing.Point(6, 52)
        Me.lblACFMode.Name = "lblACFMode"
        Me.lblACFMode.Size = New System.Drawing.Size(69, 13)
        Me.lblACFMode.TabIndex = 24
        Me.lblACFMode.Text = "ACF Mode"
        Me.lblACFMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDefaultTemp
        '
        Me.tbDefaultTemp.BackColor = System.Drawing.SystemColors.Control
        Me.tbDefaultTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDefaultTemp.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbDefaultTemp.Location = New System.Drawing.Point(147, 20)
        Me.tbDefaultTemp.Name = "tbDefaultTemp"
        Me.tbDefaultTemp.Size = New System.Drawing.Size(62, 21)
        Me.tbDefaultTemp.TabIndex = 1
        Me.tbDefaultTemp.Text = "0"
        Me.tbDefaultTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDefTemp
        '
        Me.lblDefTemp.Location = New System.Drawing.Point(15, 22)
        Me.lblDefTemp.Name = "lblDefTemp"
        Me.lblDefTemp.Size = New System.Drawing.Size(138, 17)
        Me.lblDefTemp.TabIndex = 8
        Me.lblDefTemp.Text = "Default Temperature"
        '
        'UcLimitSetting1
        '
        Me.UcLimitSetting1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcLimitSetting1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcLimitSetting1.Location = New System.Drawing.Point(6, 77)
        Me.UcLimitSetting1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcLimitSetting1.Name = "UcLimitSetting1"
        Me.UcLimitSetting1.Size = New System.Drawing.Size(243, 95)
        Me.UcLimitSetting1.TabIndex = 3
        Me.UcLimitSetting1.Title = "Limit Settings"
        '
        'ucSeqEndParam
        '
        Me.ucSeqEndParam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucSeqEndParam.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucSeqEndParam.Location = New System.Drawing.Point(6, 177)
        Me.ucSeqEndParam.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucSeqEndParam.Name = "ucSeqEndParam"
        Me.ucSeqEndParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucSeqEndParam.Size = New System.Drawing.Size(243, 163)
        Me.ucSeqEndParam.TabIndex = 4
        Me.ucSeqEndParam.Title = "Sequence End Condition"
        '
        'ucCommonConditions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbCommon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucCommonConditions"
        Me.Size = New System.Drawing.Size(260, 355)
        Me.gbCommon.ResumeLayout(False)
        Me.gbCommon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCommon As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelACFMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblACFMode As System.Windows.Forms.Label
    Friend WithEvents tbDefaultTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblDefTemp As System.Windows.Forms.Label
    Friend WithEvents UcLimitSetting1 As M7000.ucLimitSetting
    Friend WithEvents ucSeqEndParam As M7000.ucTestEndParam
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
