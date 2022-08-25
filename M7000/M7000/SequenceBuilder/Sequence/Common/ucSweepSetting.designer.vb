<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSweepSetting
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
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.cbSelSweepType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSingleValue = New System.Windows.Forms.Label()
        Me.tbSingleValue = New System.Windows.Forms.TextBox()
        Me.lblSingleValueUnit = New System.Windows.Forms.Label()
        Me.ucRGBSweepRegion = New M7000.ucMeasureRGBSweepRegion()
        Me.ucSweepRegion = New M7000.ucMeasureSweepRegion()
        Me.ucUserPatternList = New M7000.ucMeasureSweepList()
        Me.gbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.ucRGBSweepRegion)
        Me.gbMain.Controls.Add(Me.cbSelSweepType)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.ucSweepRegion)
        Me.gbMain.Controls.Add(Me.ucUserPatternList)
        Me.gbMain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMain.Location = New System.Drawing.Point(4, 4)
        Me.gbMain.Margin = New System.Windows.Forms.Padding(4)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Padding = New System.Windows.Forms.Padding(4)
        Me.gbMain.Size = New System.Drawing.Size(464, 464)
        Me.gbMain.TabIndex = 50
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Sweep Settings"
        '
        'cbSelSweepType
        '
        Me.cbSelSweepType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelSweepType.FormattingEnabled = True
        Me.cbSelSweepType.Location = New System.Drawing.Point(148, 32)
        Me.cbSelSweepType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSelSweepType.Name = "cbSelSweepType"
        Me.cbSelSweepType.Size = New System.Drawing.Size(258, 29)
        Me.cbSelSweepType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Type"
        '
        'lblSingleValue
        '
        Me.lblSingleValue.AutoSize = True
        Me.lblSingleValue.Location = New System.Drawing.Point(32, 681)
        Me.lblSingleValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSingleValue.Name = "lblSingleValue"
        Me.lblSingleValue.Size = New System.Drawing.Size(52, 20)
        Me.lblSingleValue.TabIndex = 4
        Me.lblSingleValue.Text = "Bias : "
        Me.lblSingleValue.Visible = False
        '
        'tbSingleValue
        '
        Me.tbSingleValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSingleValue.Location = New System.Drawing.Point(106, 674)
        Me.tbSingleValue.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSingleValue.Name = "tbSingleValue"
        Me.tbSingleValue.Size = New System.Drawing.Size(155, 26)
        Me.tbSingleValue.TabIndex = 5
        Me.tbSingleValue.Visible = False
        '
        'lblSingleValueUnit
        '
        Me.lblSingleValueUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSingleValueUnit.AutoSize = True
        Me.lblSingleValueUnit.Location = New System.Drawing.Point(271, 681)
        Me.lblSingleValueUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSingleValueUnit.Name = "lblSingleValueUnit"
        Me.lblSingleValueUnit.Size = New System.Drawing.Size(20, 20)
        Me.lblSingleValueUnit.TabIndex = 6
        Me.lblSingleValueUnit.Text = "V"
        Me.lblSingleValueUnit.Visible = False
        '
        'ucRGBSweepRegion
        '
        Me.ucRGBSweepRegion.AutoScroll = True
        Me.ucRGBSweepRegion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucRGBSweepRegion.IsVisibleUnit = True
        Me.ucRGBSweepRegion.Location = New System.Drawing.Point(9, 70)
        Me.ucRGBSweepRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.ucRGBSweepRegion.MaximumSize = New System.Drawing.Size(506, 364)
        Me.ucRGBSweepRegion.MinimumSize = New System.Drawing.Size(392, 356)
        Me.ucRGBSweepRegion.Name = "ucRGBSweepRegion"
        Me.ucRGBSweepRegion.Setting = Nothing
        Me.ucRGBSweepRegion.Size = New System.Drawing.Size(506, 364)
        Me.ucRGBSweepRegion.SweepList = Nothing
        Me.ucRGBSweepRegion.TabIndex = 3
        Me.ucRGBSweepRegion.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'ucSweepRegion
        '
        Me.ucSweepRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucSweepRegion.AutoScroll = True
        Me.ucSweepRegion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucSweepRegion.IsVisibleUnit = True
        Me.ucSweepRegion.Location = New System.Drawing.Point(9, 70)
        Me.ucSweepRegion.Margin = New System.Windows.Forms.Padding(6)
        Me.ucSweepRegion.MaximumSize = New System.Drawing.Size(434, 394)
        Me.ucSweepRegion.MinimumSize = New System.Drawing.Size(336, 386)
        Me.ucSweepRegion.Name = "ucSweepRegion"
        Me.ucSweepRegion.Setting = Nothing
        Me.ucSweepRegion.Size = New System.Drawing.Size(434, 386)
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
        Me.ucUserPatternList.Location = New System.Drawing.Point(9, 80)
        Me.ucUserPatternList.Margin = New System.Windows.Forms.Padding(6)
        Me.ucUserPatternList.MaximumSize = New System.Drawing.Size(434, 358)
        Me.ucUserPatternList.MinimumSize = New System.Drawing.Size(294, 358)
        Me.ucUserPatternList.Name = "ucUserPatternList"
        Me.ucUserPatternList.Setting = Nothing
        Me.ucUserPatternList.Size = New System.Drawing.Size(434, 358)
        Me.ucUserPatternList.TabIndex = 2
        Me.ucUserPatternList.Title = "Measurement Sweep List"
        Me.ucUserPatternList.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'ucSweepSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.lblSingleValueUnit)
        Me.Controls.Add(Me.tbSingleValue)
        Me.Controls.Add(Me.lblSingleValue)
        Me.Controls.Add(Me.gbMain)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(514, 488)
        Me.MinimumSize = New System.Drawing.Size(346, 434)
        Me.Name = "ucSweepSetting"
        Me.Size = New System.Drawing.Size(385, 408)
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
    Public WithEvents ucRGBSweepRegion As ucMeasureRGBSweepRegion
End Class
