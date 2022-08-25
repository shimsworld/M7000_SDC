<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuilderSettings
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDefaultValue = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbMeasureAngleMax = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbMeasureAngleMin = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbFillFactor = New System.Windows.Forms.GroupBox()
        Me.tbFillFactor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbSampleSize = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSizeHight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSizeWidth = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbDefaultTemperature = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMeasureIntervalMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbMeasureIntervalMin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpView = New System.Windows.Forms.TabPage()
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.tpSettings = New System.Windows.Forms.TabPage()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancle = New System.Windows.Forms.Button()
        Me.ucTestEndSettings = New M7000.ucTestEndParam()
        Me.ucLimitSettings = New M7000.ucLimitSetting()
        Me.UcDispDefIVLMeasParam = New M7000.ucDefTestEndParam()
        Me.UcDispDefRcpEndParam = New M7000.ucDefTestEndParam()
        Me.ucDispDefSequenceEndParam = New M7000.ucDefTestEndParam()
        Me.UcDispDefAgingRcpEndParam = New M7000.ucDefTestEndParam()
        Me.TabControl1.SuspendLayout()
        Me.tpDefaultValue.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbFillFactor.SuspendLayout()
        Me.gbSampleSize.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpView.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpDefaultValue)
        Me.TabControl1.Controls.Add(Me.tpView)
        Me.TabControl1.Controls.Add(Me.tpSettings)
        Me.TabControl1.Location = New System.Drawing.Point(4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(733, 541)
        Me.TabControl1.TabIndex = 1
        '
        'tpDefaultValue
        '
        Me.tpDefaultValue.Controls.Add(Me.GroupBox4)
        Me.tpDefaultValue.Controls.Add(Me.gbFillFactor)
        Me.tpDefaultValue.Controls.Add(Me.gbSampleSize)
        Me.tpDefaultValue.Controls.Add(Me.GroupBox2)
        Me.tpDefaultValue.Controls.Add(Me.ucTestEndSettings)
        Me.tpDefaultValue.Controls.Add(Me.GroupBox1)
        Me.tpDefaultValue.Controls.Add(Me.ucLimitSettings)
        Me.tpDefaultValue.Location = New System.Drawing.Point(4, 22)
        Me.tpDefaultValue.Name = "tpDefaultValue"
        Me.tpDefaultValue.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDefaultValue.Size = New System.Drawing.Size(725, 515)
        Me.tpDefaultValue.TabIndex = 0
        Me.tpDefaultValue.Text = "Default Value"
        Me.tpDefaultValue.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.tbMeasureAngleMax)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.tbMeasureAngleMin)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 183)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(242, 70)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Measurement ViewAngle"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(170, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Max"
        '
        'tbMeasureAngleMax
        '
        Me.tbMeasureAngleMax.Location = New System.Drawing.Point(156, 34)
        Me.tbMeasureAngleMax.Name = "tbMeasureAngleMax"
        Me.tbMeasureAngleMax.Size = New System.Drawing.Size(56, 21)
        Me.tbMeasureAngleMax.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(107, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Min"
        '
        'tbMeasureAngleMin
        '
        Me.tbMeasureAngleMin.Location = New System.Drawing.Point(93, 34)
        Me.tbMeasureAngleMin.Name = "tbMeasureAngleMin"
        Me.tbMeasureAngleMin.Size = New System.Drawing.Size(56, 21)
        Me.tbMeasureAngleMin.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Angle(') :"
        '
        'gbFillFactor
        '
        Me.gbFillFactor.Controls.Add(Me.tbFillFactor)
        Me.gbFillFactor.Controls.Add(Me.Label7)
        Me.gbFillFactor.Location = New System.Drawing.Point(381, 259)
        Me.gbFillFactor.Name = "gbFillFactor"
        Me.gbFillFactor.Size = New System.Drawing.Size(121, 61)
        Me.gbFillFactor.TabIndex = 25
        Me.gbFillFactor.TabStop = False
        Me.gbFillFactor.Text = "Fill Factor"
        '
        'tbFillFactor
        '
        Me.tbFillFactor.Location = New System.Drawing.Point(17, 26)
        Me.tbFillFactor.Name = "tbFillFactor"
        Me.tbFillFactor.Size = New System.Drawing.Size(70, 21)
        Me.tbFillFactor.TabIndex = 7
        Me.tbFillFactor.Text = "0"
        Me.tbFillFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(94, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "%"
        '
        'gbSampleSize
        '
        Me.gbSampleSize.Controls.Add(Me.Label4)
        Me.gbSampleSize.Controls.Add(Me.tbSizeHight)
        Me.gbSampleSize.Controls.Add(Me.Label9)
        Me.gbSampleSize.Controls.Add(Me.Label8)
        Me.gbSampleSize.Controls.Add(Me.tbSizeWidth)
        Me.gbSampleSize.Controls.Add(Me.Label6)
        Me.gbSampleSize.Location = New System.Drawing.Point(6, 259)
        Me.gbSampleSize.Name = "gbSampleSize"
        Me.gbSampleSize.Size = New System.Drawing.Size(369, 61)
        Me.gbSampleSize.TabIndex = 24
        Me.gbSampleSize.TabStop = False
        Me.gbSampleSize.Text = "Sample Size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(331, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "mm"
        '
        'tbSizeHight
        '
        Me.tbSizeHight.Location = New System.Drawing.Point(241, 26)
        Me.tbSizeHight.Name = "tbSizeHight"
        Me.tbSizeHight.Size = New System.Drawing.Size(83, 21)
        Me.tbSizeHight.TabIndex = 12
        Me.tbSizeHight.Text = "0"
        Me.tbSizeHight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(195, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Hight :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(149, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 12)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "mm"
        '
        'tbSizeWidth
        '
        Me.tbSizeWidth.Location = New System.Drawing.Point(59, 26)
        Me.tbSizeWidth.Name = "tbSizeWidth"
        Me.tbSizeWidth.Size = New System.Drawing.Size(83, 21)
        Me.tbSizeWidth.TabIndex = 7
        Me.tbSizeWidth.Text = "0"
        Me.tbSizeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Width :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tbDefaultTemperature)
        Me.GroupBox2.Location = New System.Drawing.Point(256, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 48)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Default Temperature Settings"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Temp('C) :"
        '
        'tbDefaultTemperature
        '
        Me.tbDefaultTemperature.Location = New System.Drawing.Point(93, 22)
        Me.tbDefaultTemperature.Name = "tbDefaultTemperature"
        Me.tbDefaultTemperature.Size = New System.Drawing.Size(70, 21)
        Me.tbDefaultTemperature.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbMeasureIntervalMax)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbMeasureIntervalMin)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 70)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Measurement Interval Time Settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(170, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max"
        '
        'tbMeasureIntervalMax
        '
        Me.tbMeasureIntervalMax.Location = New System.Drawing.Point(156, 34)
        Me.tbMeasureIntervalMax.Name = "tbMeasureIntervalMax"
        Me.tbMeasureIntervalMax.Size = New System.Drawing.Size(56, 21)
        Me.tbMeasureIntervalMax.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Min"
        '
        'tbMeasureIntervalMin
        '
        Me.tbMeasureIntervalMin.Location = New System.Drawing.Point(93, 34)
        Me.tbMeasureIntervalMin.Name = "tbMeasureIntervalMin"
        Me.tbMeasureIntervalMin.Size = New System.Drawing.Size(56, 21)
        Me.tbMeasureIntervalMin.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Interval(hrs) :"
        '
        'tpView
        '
        Me.tpView.Controls.Add(Me.treeView)
        Me.tpView.Location = New System.Drawing.Point(4, 22)
        Me.tpView.Name = "tpView"
        Me.tpView.Size = New System.Drawing.Size(725, 515)
        Me.tpView.TabIndex = 1
        Me.tpView.Text = "View"
        Me.tpView.UseVisualStyleBackColor = True
        '
        'treeView
        '
        Me.treeView.Location = New System.Drawing.Point(-4, 0)
        Me.treeView.Name = "treeView"
        Me.treeView.Size = New System.Drawing.Size(335, 192)
        Me.treeView.TabIndex = 0
        '
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.UcDispDefAgingRcpEndParam)
        Me.tpSettings.Controls.Add(Me.UcDispDefIVLMeasParam)
        Me.tpSettings.Controls.Add(Me.UcDispDefRcpEndParam)
        Me.tpSettings.Controls.Add(Me.ucDispDefSequenceEndParam)
        Me.tpSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSettings.Size = New System.Drawing.Size(725, 515)
        Me.tpSettings.TabIndex = 2
        Me.tpSettings.Text = "Settings"
        Me.tpSettings.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(559, 551)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(84, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancle
        '
        Me.btnCancle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancle.Location = New System.Drawing.Point(649, 551)
        Me.btnCancle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancle.Name = "btnCancle"
        Me.btnCancle.Size = New System.Drawing.Size(87, 32)
        Me.btnCancle.TabIndex = 3
        Me.btnCancle.Text = "Cancle"
        Me.btnCancle.UseVisualStyleBackColor = True
        '
        'ucTestEndSettings
        '
        Me.ucTestEndSettings.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucTestEndSettings.Location = New System.Drawing.Point(256, 6)
        Me.ucTestEndSettings.Name = "ucTestEndSettings"
        Me.ucTestEndSettings.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestEndSettings.Size = New System.Drawing.Size(306, 171)
        Me.ucTestEndSettings.TabIndex = 22
        Me.ucTestEndSettings.Title = "TEST END"
        '
        'ucLimitSettings
        '
        Me.ucLimitSettings.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucLimitSettings.Location = New System.Drawing.Point(6, 6)
        Me.ucLimitSettings.Name = "ucLimitSettings"
        Me.ucLimitSettings.Size = New System.Drawing.Size(243, 95)
        Me.ucLimitSettings.TabIndex = 0
        Me.ucLimitSettings.Title = "Limit Settings"
        '
        'UcDispDefIVLMeasParam
        '
        Me.UcDispDefIVLMeasParam.Location = New System.Drawing.Point(482, 6)
        Me.UcDispDefIVLMeasParam.Name = "UcDispDefIVLMeasParam"
        Me.UcDispDefIVLMeasParam.Settings = Nothing
        Me.UcDispDefIVLMeasParam.Size = New System.Drawing.Size(232, 240)
        Me.UcDispDefIVLMeasParam.TabIndex = 3
        Me.UcDispDefIVLMeasParam.Title = "IVL Sweep Meas. Params"
        '
        'UcDispDefRcpEndParam
        '
        Me.UcDispDefRcpEndParam.Location = New System.Drawing.Point(244, 6)
        Me.UcDispDefRcpEndParam.Name = "UcDispDefRcpEndParam"
        Me.UcDispDefRcpEndParam.Settings = Nothing
        Me.UcDispDefRcpEndParam.Size = New System.Drawing.Size(232, 240)
        Me.UcDispDefRcpEndParam.TabIndex = 2
        Me.UcDispDefRcpEndParam.Title = "Recipe End Params"
        '
        'ucDispDefSequenceEndParam
        '
        Me.ucDispDefSequenceEndParam.Location = New System.Drawing.Point(6, 6)
        Me.ucDispDefSequenceEndParam.Name = "ucDispDefSequenceEndParam"
        Me.ucDispDefSequenceEndParam.Settings = Nothing
        Me.ucDispDefSequenceEndParam.Size = New System.Drawing.Size(232, 240)
        Me.ucDispDefSequenceEndParam.TabIndex = 1
        Me.ucDispDefSequenceEndParam.Title = "Sequence End Params"
        '
        'UcDispDefAgingRcpEndParam
        '
        Me.UcDispDefAgingRcpEndParam.Location = New System.Drawing.Point(6, 252)
        Me.UcDispDefAgingRcpEndParam.Name = "UcDispDefAgingRcpEndParam"
        Me.UcDispDefAgingRcpEndParam.Settings = Nothing
        Me.UcDispDefAgingRcpEndParam.Size = New System.Drawing.Size(232, 247)
        Me.UcDispDefAgingRcpEndParam.TabIndex = 4
        Me.UcDispDefAgingRcpEndParam.Title = "Aging End Params"
        '
        'frmBuilderSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(741, 589)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancle)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmBuilderSettings"
        Me.Text = "Sequence Builder Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.tpDefaultValue.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbFillFactor.ResumeLayout(False)
        Me.gbFillFactor.PerformLayout()
        Me.gbSampleSize.ResumeLayout(False)
        Me.gbSampleSize.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpView.ResumeLayout(False)
        Me.tpSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucLimitSettings As M7000.ucLimitSetting
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDefaultValue As System.Windows.Forms.TabPage
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancle As System.Windows.Forms.Button
    Friend WithEvents tpView As System.Windows.Forms.TabPage
    Friend WithEvents treeView As System.Windows.Forms.TreeView
    Friend WithEvents tpSettings As System.Windows.Forms.TabPage
    Friend WithEvents gbFillFactor As System.Windows.Forms.GroupBox
    Friend WithEvents tbFillFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbSampleSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSizeHight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbSizeWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbDefaultTemperature As System.Windows.Forms.TextBox
    Friend WithEvents ucTestEndSettings As M7000.ucTestEndParam
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureIntervalMax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureIntervalMin As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ucDispDefSequenceEndParam As M7000.ucDefTestEndParam
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureAngleMax As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbMeasureAngleMin As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UcDispDefRcpEndParam As M7000.ucDefTestEndParam
    Friend WithEvents UcDispDefIVLMeasParam As M7000.ucDefTestEndParam
    Friend WithEvents UcDispDefAgingRcpEndParam As M7000.ucDefTestEndParam
End Class
