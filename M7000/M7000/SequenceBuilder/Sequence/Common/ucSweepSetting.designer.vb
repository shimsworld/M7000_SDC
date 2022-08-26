<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucSweepSetting
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.ucRGBSweepRegion = New ucMeasureRGBSweepRegion()
        Me.cbSelSweepType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ucSweepRegion = New M7000.ucMeasureSweepRegion()
        Me.ucUserPatternList = New M7000.ucMeasureSweepList()
        Me.lblSingleValue = New System.Windows.Forms.Label()
        Me.tbSingleValue = New System.Windows.Forms.TextBox()
        Me.lblSingleValueUnit = New System.Windows.Forms.Label()
        Me.gbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.cbSelSweepType)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.ucSweepRegion)
        Me.gbMain.Controls.Add(Me.ucUserPatternList)
        Me.gbMain.Controls.Add(Me.ucRGBSweepRegion)
        Me.gbMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMain.Location = New System.Drawing.Point(3, 3)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(319, 323)
        Me.gbMain.TabIndex = 50
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Sweep Settings"
        '
        'ucRGBSweepRegion
        '
        Me.ucRGBSweepRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucRGBSweepRegion.AutoScroll = True
        Me.ucRGBSweepRegion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucRGBSweepRegion.Location = New System.Drawing.Point(6, 47)
        Me.ucRGBSweepRegion.MaximumSize = New System.Drawing.Size(300, 300)
        Me.ucRGBSweepRegion.MinimumSize = New System.Drawing.Size(261, 237)
        Me.ucRGBSweepRegion.Name = "ucRGBSweepRegion"
        Me.ucRGBSweepRegion.Setting = Nothing
        Me.ucRGBSweepRegion.Size = New System.Drawing.Size(276, 270)
        Me.ucRGBSweepRegion.SweepList = Nothing
        Me.ucRGBSweepRegion.SweepType = M7000.ucMeasureSweepRegion.eSweepType._RGBSweep
        Me.ucRGBSweepRegion.TabIndex = 3
        Me.ucRGBSweepRegion.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'cbSelSweepType
        '
        Me.cbSelSweepType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelSweepType.FormattingEnabled = True
        Me.cbSelSweepType.Location = New System.Drawing.Point(99, 21)
        Me.cbSelSweepType.Name = "cbSelSweepType"
        Me.cbSelSweepType.Size = New System.Drawing.Size(183, 23)
        Me.cbSelSweepType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Type"
        '
        'ucSweepRegion
        '
        Me.ucSweepRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucSweepRegion.AutoScroll = True
        Me.ucSweepRegion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucSweepRegion.IsVisibleUnit = True
        Me.ucSweepRegion.Location = New System.Drawing.Point(6, 47)
        Me.ucSweepRegion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucSweepRegion.MaximumSize = New System.Drawing.Size(289, 263)
        Me.ucSweepRegion.MinimumSize = New System.Drawing.Size(224, 257)
        Me.ucSweepRegion.Name = "ucSweepRegion"
        Me.ucSweepRegion.Setting = Nothing
        Me.ucSweepRegion.Size = New System.Drawing.Size(248, 257)
        Me.ucSweepRegion.SweepList = Nothing
        Me.ucSweepRegion.SweepType = M7000.ucMeasureSweepRegion.eSweepType._IVLSweep
        Me.ucSweepRegion.TabIndex = 1
        Me.ucSweepRegion.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'ucUserPatternList
        '
        Me.ucUserPatternList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucUserPatternList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucUserPatternList.Location = New System.Drawing.Point(6, 53)
        Me.ucUserPatternList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucUserPatternList.MaximumSize = New System.Drawing.Size(289, 239)
        Me.ucUserPatternList.MinimumSize = New System.Drawing.Size(196, 239)
        Me.ucUserPatternList.Name = "ucUserPatternList"
        Me.ucUserPatternList.Setting = Nothing
        Me.ucUserPatternList.Size = New System.Drawing.Size(248, 239)
        Me.ucUserPatternList.TabIndex = 2
        Me.ucUserPatternList.Title = "Measurement Sweep List"
        Me.ucUserPatternList.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'lblSingleValue
        '
        Me.lblSingleValue.AutoSize = True
        Me.lblSingleValue.Location = New System.Drawing.Point(21, 454)
        Me.lblSingleValue.Name = "lblSingleValue"
        Me.lblSingleValue.Size = New System.Drawing.Size(36, 13)
        Me.lblSingleValue.TabIndex = 4
        Me.lblSingleValue.Text = "Bias : "
        Me.lblSingleValue.Visible = False
        '
        'tbSingleValue
        '
        Me.tbSingleValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSingleValue.Location = New System.Drawing.Point(71, 449)
        Me.tbSingleValue.Name = "tbSingleValue"
        Me.tbSingleValue.Size = New System.Drawing.Size(204, 20)
        Me.tbSingleValue.TabIndex = 5
        Me.tbSingleValue.Visible = False
        '
        'lblSingleValueUnit
        '
        Me.lblSingleValueUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSingleValueUnit.AutoSize = True
        Me.lblSingleValueUnit.Location = New System.Drawing.Point(280, 454)
        Me.lblSingleValueUnit.Name = "lblSingleValueUnit"
        Me.lblSingleValueUnit.Size = New System.Drawing.Size(14, 13)
        Me.lblSingleValueUnit.TabIndex = 6
        Me.lblSingleValueUnit.Text = "V"
        Me.lblSingleValueUnit.Visible = False
        '
        'ucSweepSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.lblSingleValueUnit)
        Me.Controls.Add(Me.tbSingleValue)
        Me.Controls.Add(Me.lblSingleValue)
        Me.Controls.Add(Me.gbMain)
        Me.MaximumSize = New System.Drawing.Size(400, 325)
        Me.MinimumSize = New System.Drawing.Size(231, 289)
        Me.Name = "ucSweepSetting"
        Me.Size = New System.Drawing.Size(317, 308)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSweepType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSingleValue As System.Windows.Forms.Label
    Friend WithEvents tbSingleValue As System.Windows.Forms.TextBox
    Friend WithEvents lblSingleValueUnit As System.Windows.Forms.Label
    Public WithEvents ucSweepRegion As M7000.ucMeasureSweepRegion
    Public WithEvents ucUserPatternList As M7000.ucMeasureSweepList
    Public WithEvents ucRGBSweepRegion As M7000.ucMeasureRGBSweepRegion
End Class
