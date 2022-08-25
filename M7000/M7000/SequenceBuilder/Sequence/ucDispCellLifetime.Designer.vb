<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispCellLifetime
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
        Me.gbSource = New System.Windows.Forms.GroupBox()
        Me.chkConstantBrightness = New System.Windows.Forms.CheckBox()
        Me.lblSetRev = New System.Windows.Forms.Label()
        Me.chkDutuDivision = New System.Windows.Forms.CheckBox()
        Me.chkBiasReverse = New System.Windows.Forms.CheckBox()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.cbBiasMode = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblDutyPercent = New System.Windows.Forms.Label()
        Me.lblFrequencyUnit = New System.Windows.Forms.Label()
        Me.lblAmpUnit = New System.Windows.Forms.Label()
        Me.lblValueUnit = New System.Windows.Forms.Label()
        Me.txtDuty = New System.Windows.Forms.TextBox()
        Me.txtFrequency = New System.Windows.Forms.TextBox()
        Me.txtAmplitude = New System.Windows.Forms.TextBox()
        Me.lblDuty = New System.Windows.Forms.Label()
        Me.txtBiasValue = New System.Windows.Forms.TextBox()
        Me.lblFrequency = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblAmplitude = New System.Windows.Forms.Label()
        Me.chkEnable = New System.Windows.Forms.CheckBox()
        Me.gbSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSource
        '
        Me.gbSource.Controls.Add(Me.chkConstantBrightness)
        Me.gbSource.Controls.Add(Me.lblSetRev)
        Me.gbSource.Controls.Add(Me.chkDutuDivision)
        Me.gbSource.Controls.Add(Me.chkBiasReverse)
        Me.gbSource.Controls.Add(Me.lblMode)
        Me.gbSource.Controls.Add(Me.cbBiasMode)
        Me.gbSource.Controls.Add(Me.btnAdd)
        Me.gbSource.Controls.Add(Me.lblDutyPercent)
        Me.gbSource.Controls.Add(Me.lblFrequencyUnit)
        Me.gbSource.Controls.Add(Me.lblAmpUnit)
        Me.gbSource.Controls.Add(Me.lblValueUnit)
        Me.gbSource.Controls.Add(Me.txtDuty)
        Me.gbSource.Controls.Add(Me.txtFrequency)
        Me.gbSource.Controls.Add(Me.txtAmplitude)
        Me.gbSource.Controls.Add(Me.lblDuty)
        Me.gbSource.Controls.Add(Me.txtBiasValue)
        Me.gbSource.Controls.Add(Me.lblFrequency)
        Me.gbSource.Controls.Add(Me.lblValue)
        Me.gbSource.Controls.Add(Me.lblAmplitude)
        Me.gbSource.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSource.Location = New System.Drawing.Point(2, 42)
        Me.gbSource.Name = "gbSource"
        Me.gbSource.Size = New System.Drawing.Size(181, 242)
        Me.gbSource.TabIndex = 1
        Me.gbSource.TabStop = False
        Me.gbSource.Text = "Source Settings"
        Me.gbSource.Visible = False
        '
        'chkConstantBrightness
        '
        Me.chkConstantBrightness.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkConstantBrightness.AutoSize = True
        Me.chkConstantBrightness.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkConstantBrightness.Location = New System.Drawing.Point(28, 185)
        Me.chkConstantBrightness.Name = "chkConstantBrightness"
        Me.chkConstantBrightness.Size = New System.Drawing.Size(142, 19)
        Me.chkConstantBrightness.TabIndex = 9
        Me.chkConstantBrightness.Text = "Constant Brightness"
        Me.chkConstantBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkConstantBrightness.UseVisualStyleBackColor = True
        '
        'lblSetRev
        '
        Me.lblSetRev.AutoSize = True
        Me.lblSetRev.Location = New System.Drawing.Point(21, 46)
        Me.lblSetRev.Name = "lblSetRev"
        Me.lblSetRev.Size = New System.Drawing.Size(50, 15)
        Me.lblSetRev.TabIndex = 21
        Me.lblSetRev.Text = "Set Rev"
        '
        'chkDutuDivision
        '
        Me.chkDutuDivision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDutuDivision.AutoSize = True
        Me.chkDutuDivision.Location = New System.Drawing.Point(156, 159)
        Me.chkDutuDivision.Name = "chkDutuDivision"
        Me.chkDutuDivision.Size = New System.Drawing.Size(15, 14)
        Me.chkDutuDivision.TabIndex = 8
        Me.chkDutuDivision.UseVisualStyleBackColor = True
        '
        'chkBiasReverse
        '
        Me.chkBiasReverse.AutoSize = True
        Me.chkBiasReverse.Location = New System.Drawing.Point(75, 44)
        Me.chkBiasReverse.Name = "chkBiasReverse"
        Me.chkBiasReverse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkBiasReverse.Size = New System.Drawing.Size(41, 19)
        Me.chkBiasReverse.TabIndex = 3
        Me.chkBiasReverse.Text = "(+)"
        Me.chkBiasReverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBiasReverse.UseVisualStyleBackColor = True
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(31, 20)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(38, 15)
        Me.lblMode.TabIndex = 20
        Me.lblMode.Text = "Mode"
        '
        'cbBiasMode
        '
        Me.cbBiasMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBiasMode.FormattingEnabled = True
        Me.cbBiasMode.Location = New System.Drawing.Point(75, 16)
        Me.cbBiasMode.Name = "cbBiasMode"
        Me.cbBiasMode.Size = New System.Drawing.Size(57, 23)
        Me.cbBiasMode.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(33, 209)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(115, 27)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblDutyPercent
        '
        Me.lblDutyPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDutyPercent.AutoSize = True
        Me.lblDutyPercent.Location = New System.Drawing.Point(136, 159)
        Me.lblDutyPercent.Name = "lblDutyPercent"
        Me.lblDutyPercent.Size = New System.Drawing.Size(16, 15)
        Me.lblDutyPercent.TabIndex = 29
        Me.lblDutyPercent.Text = "%"
        '
        'lblFrequencyUnit
        '
        Me.lblFrequencyUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFrequencyUnit.AutoSize = True
        Me.lblFrequencyUnit.Location = New System.Drawing.Point(136, 130)
        Me.lblFrequencyUnit.Name = "lblFrequencyUnit"
        Me.lblFrequencyUnit.Size = New System.Drawing.Size(21, 15)
        Me.lblFrequencyUnit.TabIndex = 28
        Me.lblFrequencyUnit.Text = "Hz"
        '
        'lblAmpUnit
        '
        Me.lblAmpUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmpUnit.AutoSize = True
        Me.lblAmpUnit.Location = New System.Drawing.Point(136, 101)
        Me.lblAmpUnit.Name = "lblAmpUnit"
        Me.lblAmpUnit.Size = New System.Drawing.Size(15, 15)
        Me.lblAmpUnit.TabIndex = 27
        Me.lblAmpUnit.Text = "V"
        '
        'lblValueUnit
        '
        Me.lblValueUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblValueUnit.AutoSize = True
        Me.lblValueUnit.Location = New System.Drawing.Point(136, 72)
        Me.lblValueUnit.Name = "lblValueUnit"
        Me.lblValueUnit.Size = New System.Drawing.Size(15, 15)
        Me.lblValueUnit.TabIndex = 26
        Me.lblValueUnit.Text = "V"
        '
        'txtDuty
        '
        Me.txtDuty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDuty.Location = New System.Drawing.Point(75, 156)
        Me.txtDuty.Name = "txtDuty"
        Me.txtDuty.Size = New System.Drawing.Size(57, 21)
        Me.txtDuty.TabIndex = 7
        Me.txtDuty.Text = "0"
        Me.txtDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFrequency
        '
        Me.txtFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFrequency.Location = New System.Drawing.Point(75, 127)
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(57, 21)
        Me.txtFrequency.TabIndex = 6
        Me.txtFrequency.Text = "0"
        Me.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAmplitude
        '
        Me.txtAmplitude.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmplitude.Location = New System.Drawing.Point(75, 98)
        Me.txtAmplitude.Name = "txtAmplitude"
        Me.txtAmplitude.Size = New System.Drawing.Size(57, 21)
        Me.txtAmplitude.TabIndex = 5
        Me.txtAmplitude.Text = "0"
        Me.txtAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDuty
        '
        Me.lblDuty.AutoSize = True
        Me.lblDuty.Location = New System.Drawing.Point(22, 159)
        Me.lblDuty.Name = "lblDuty"
        Me.lblDuty.Size = New System.Drawing.Size(44, 15)
        Me.lblDuty.TabIndex = 25
        Me.lblDuty.Text = "    Duty"
        '
        'txtBiasValue
        '
        Me.txtBiasValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBiasValue.Location = New System.Drawing.Point(75, 68)
        Me.txtBiasValue.Name = "txtBiasValue"
        Me.txtBiasValue.Size = New System.Drawing.Size(57, 21)
        Me.txtBiasValue.TabIndex = 4
        Me.txtBiasValue.Text = "0"
        Me.txtBiasValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFrequency
        '
        Me.lblFrequency.AutoSize = True
        Me.lblFrequency.Location = New System.Drawing.Point(7, 130)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Size = New System.Drawing.Size(66, 15)
        Me.lblFrequency.TabIndex = 24
        Me.lblFrequency.Text = "Frequency"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(36, 72)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(32, 15)
        Me.lblValue.TabIndex = 22
        Me.lblValue.Text = "Bias"
        '
        'lblAmplitude
        '
        Me.lblAmplitude.AutoSize = True
        Me.lblAmplitude.Location = New System.Drawing.Point(13, 101)
        Me.lblAmplitude.Name = "lblAmplitude"
        Me.lblAmplitude.Size = New System.Drawing.Size(61, 15)
        Me.lblAmplitude.TabIndex = 23
        Me.lblAmplitude.Text = "Ampitude"
        '
        'chkEnable
        '
        Me.chkEnable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEnable.Location = New System.Drawing.Point(36, 3)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Size = New System.Drawing.Size(115, 33)
        Me.chkEnable.TabIndex = 0
        Me.chkEnable.Text = "Enable"
        Me.chkEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEnable.UseVisualStyleBackColor = True
        Me.chkEnable.Visible = False
        '
        'ucDispCellLifetime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.chkEnable)
        Me.Controls.Add(Me.gbSource)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(163, 282)
        Me.Name = "ucDispCellLifetime"
        Me.Size = New System.Drawing.Size(184, 292)
        Me.gbSource.ResumeLayout(False)
        Me.gbSource.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSource As System.Windows.Forms.GroupBox
    Friend WithEvents lblSetRev As System.Windows.Forms.Label
    Friend WithEvents chkDutuDivision As System.Windows.Forms.CheckBox
    Friend WithEvents chkBiasReverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents cbBiasMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblDutyPercent As System.Windows.Forms.Label
    Friend WithEvents lblFrequencyUnit As System.Windows.Forms.Label
    Friend WithEvents lblAmpUnit As System.Windows.Forms.Label
    Friend WithEvents lblValueUnit As System.Windows.Forms.Label
    Friend WithEvents txtDuty As System.Windows.Forms.TextBox
    Friend WithEvents txtFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtAmplitude As System.Windows.Forms.TextBox
    Friend WithEvents lblDuty As System.Windows.Forms.Label
    Friend WithEvents txtBiasValue As System.Windows.Forms.TextBox
    Friend WithEvents lblFrequency As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblAmplitude As System.Windows.Forms.Label
    Friend WithEvents chkConstantBrightness As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnable As System.Windows.Forms.CheckBox

End Class
