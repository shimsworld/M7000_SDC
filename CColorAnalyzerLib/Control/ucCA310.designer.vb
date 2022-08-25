<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCA310
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelSyncMode = New System.Windows.Forms.ComboBox()
        Me.btnSetCalMode = New System.Windows.Forms.Button()
        Me.tbSyncModeFreqValue = New System.Windows.Forms.TextBox()
        Me.cbSelDefCalMode = New System.Windows.Forms.ComboBox()
        Me.btnSetSyncMode = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSelDisplayMode = New System.Windows.Forms.ComboBox()
        Me.btnSetBrightnessUnit = New System.Windows.Forms.Button()
        Me.btnSetDispMode = New System.Windows.Forms.Button()
        Me.cbSelBrightnessUnit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSelDispDigits = New System.Windows.Forms.ComboBox()
        Me.btnSetAverageMode = New System.Windows.Forms.Button()
        Me.btnSetDispDigits = New System.Windows.Forms.Button()
        Me.cbSelAveragingMode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.lblDeviceInfo = New System.Windows.Forms.Label()
        Me.btnUpdateState = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnZeroCal = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbSelSyncMode)
        Me.GroupBox1.Controls.Add(Me.btnSetCalMode)
        Me.GroupBox1.Controls.Add(Me.tbSyncModeFreqValue)
        Me.GroupBox1.Controls.Add(Me.cbSelDefCalMode)
        Me.GroupBox1.Controls.Add(Me.btnSetSyncMode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbSelDisplayMode)
        Me.GroupBox1.Controls.Add(Me.btnSetBrightnessUnit)
        Me.GroupBox1.Controls.Add(Me.btnSetDispMode)
        Me.GroupBox1.Controls.Add(Me.cbSelBrightnessUnit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbSelDispDigits)
        Me.GroupBox1.Controls.Add(Me.btnSetAverageMode)
        Me.GroupBox1.Controls.Add(Me.btnSetDispDigits)
        Me.GroupBox1.Controls.Add(Me.cbSelAveragingMode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 69)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(354, 298)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 298)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Sync Mode :"
        '
        'cbSelSyncMode
        '
        Me.cbSelSyncMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelSyncMode.FormattingEnabled = True
        Me.cbSelSyncMode.Location = New System.Drawing.Point(96, 21)
        Me.cbSelSyncMode.Name = "cbSelSyncMode"
        Me.cbSelSyncMode.Size = New System.Drawing.Size(111, 20)
        Me.cbSelSyncMode.TabIndex = 9
        '
        'btnSetCalMode
        '
        Me.btnSetCalMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetCalMode.Location = New System.Drawing.Point(289, 188)
        Me.btnSetCalMode.Name = "btnSetCalMode"
        Me.btnSetCalMode.Size = New System.Drawing.Size(64, 30)
        Me.btnSetCalMode.TabIndex = 28
        Me.btnSetCalMode.Text = "SET"
        Me.btnSetCalMode.UseVisualStyleBackColor = True
        '
        'tbSyncModeFreqValue
        '
        Me.tbSyncModeFreqValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSyncModeFreqValue.Location = New System.Drawing.Point(213, 21)
        Me.tbSyncModeFreqValue.Name = "tbSyncModeFreqValue"
        Me.tbSyncModeFreqValue.Size = New System.Drawing.Size(68, 21)
        Me.tbSyncModeFreqValue.TabIndex = 10
        '
        'cbSelDefCalMode
        '
        Me.cbSelDefCalMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelDefCalMode.FormattingEnabled = True
        Me.cbSelDefCalMode.Location = New System.Drawing.Point(153, 194)
        Me.cbSelDefCalMode.Name = "cbSelDefCalMode"
        Me.cbSelDefCalMode.Size = New System.Drawing.Size(128, 20)
        Me.cbSelDefCalMode.TabIndex = 27
        '
        'btnSetSyncMode
        '
        Me.btnSetSyncMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetSyncMode.Location = New System.Drawing.Point(289, 19)
        Me.btnSetSyncMode.Name = "btnSetSyncMode"
        Me.btnSetSyncMode.Size = New System.Drawing.Size(64, 30)
        Me.btnSetSyncMode.TabIndex = 11
        Me.btnSetSyncMode.Text = "SET"
        Me.btnSetSyncMode.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 12)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Def. Calibration mode :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Display Mode :"
        '
        'cbSelDisplayMode
        '
        Me.cbSelDisplayMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelDisplayMode.FormattingEnabled = True
        Me.cbSelDisplayMode.Location = New System.Drawing.Point(106, 56)
        Me.cbSelDisplayMode.Name = "cbSelDisplayMode"
        Me.cbSelDisplayMode.Size = New System.Drawing.Size(175, 20)
        Me.cbSelDisplayMode.TabIndex = 14
        '
        'btnSetBrightnessUnit
        '
        Me.btnSetBrightnessUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetBrightnessUnit.Location = New System.Drawing.Point(289, 154)
        Me.btnSetBrightnessUnit.Name = "btnSetBrightnessUnit"
        Me.btnSetBrightnessUnit.Size = New System.Drawing.Size(64, 30)
        Me.btnSetBrightnessUnit.TabIndex = 24
        Me.btnSetBrightnessUnit.Text = "SET"
        Me.btnSetBrightnessUnit.UseVisualStyleBackColor = True
        '
        'btnSetDispMode
        '
        Me.btnSetDispMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetDispMode.Location = New System.Drawing.Point(289, 52)
        Me.btnSetDispMode.Name = "btnSetDispMode"
        Me.btnSetDispMode.Size = New System.Drawing.Size(64, 30)
        Me.btnSetDispMode.TabIndex = 15
        Me.btnSetDispMode.Text = "SET"
        Me.btnSetDispMode.UseVisualStyleBackColor = True
        '
        'cbSelBrightnessUnit
        '
        Me.cbSelBrightnessUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelBrightnessUnit.FormattingEnabled = True
        Me.cbSelBrightnessUnit.Location = New System.Drawing.Point(120, 160)
        Me.cbSelBrightnessUnit.Name = "cbSelBrightnessUnit"
        Me.cbSelBrightnessUnit.Size = New System.Drawing.Size(161, 20)
        Me.cbSelBrightnessUnit.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Display Digits :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Brightness Unit :"
        '
        'cbSelDispDigits
        '
        Me.cbSelDispDigits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelDispDigits.FormattingEnabled = True
        Me.cbSelDispDigits.Location = New System.Drawing.Point(106, 93)
        Me.cbSelDispDigits.Name = "cbSelDispDigits"
        Me.cbSelDispDigits.Size = New System.Drawing.Size(175, 20)
        Me.cbSelDispDigits.TabIndex = 17
        '
        'btnSetAverageMode
        '
        Me.btnSetAverageMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetAverageMode.Location = New System.Drawing.Point(289, 120)
        Me.btnSetAverageMode.Name = "btnSetAverageMode"
        Me.btnSetAverageMode.Size = New System.Drawing.Size(64, 30)
        Me.btnSetAverageMode.TabIndex = 21
        Me.btnSetAverageMode.Text = "SET"
        Me.btnSetAverageMode.UseVisualStyleBackColor = True
        '
        'btnSetDispDigits
        '
        Me.btnSetDispDigits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetDispDigits.Location = New System.Drawing.Point(289, 86)
        Me.btnSetDispDigits.Name = "btnSetDispDigits"
        Me.btnSetDispDigits.Size = New System.Drawing.Size(64, 30)
        Me.btnSetDispDigits.TabIndex = 18
        Me.btnSetDispDigits.Text = "SET"
        Me.btnSetDispDigits.UseVisualStyleBackColor = True
        '
        'cbSelAveragingMode
        '
        Me.cbSelAveragingMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelAveragingMode.FormattingEnabled = True
        Me.cbSelAveragingMode.Location = New System.Drawing.Point(120, 127)
        Me.cbSelAveragingMode.Name = "cbSelAveragingMode"
        Me.cbSelAveragingMode.Size = New System.Drawing.Size(161, 20)
        Me.cbSelAveragingMode.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Averaging Mode :"
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(115, 3)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 38
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'lblDeviceInfo
        '
        Me.lblDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDeviceInfo.Location = New System.Drawing.Point(3, 17)
        Me.lblDeviceInfo.Name = "lblDeviceInfo"
        Me.lblDeviceInfo.Size = New System.Drawing.Size(315, 67)
        Me.lblDeviceInfo.TabIndex = 37
        Me.lblDeviceInfo.Text = "Device Information"
        '
        'btnUpdateState
        '
        Me.btnUpdateState.Location = New System.Drawing.Point(242, 3)
        Me.btnUpdateState.Name = "btnUpdateState"
        Me.btnUpdateState.Size = New System.Drawing.Size(88, 44)
        Me.btnUpdateState.TabIndex = 36
        Me.btnUpdateState.Text = "Update State"
        Me.btnUpdateState.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 188)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Measurement Data"
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(342, 3)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 34
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(539, 3)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(88, 44)
        Me.btnMeasure.TabIndex = 33
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'btnZeroCal
        '
        Me.btnZeroCal.Location = New System.Drawing.Point(445, 3)
        Me.btnZeroCal.Name = "btnZeroCal"
        Me.btnZeroCal.Size = New System.Drawing.Size(88, 44)
        Me.btnZeroCal.TabIndex = 32
        Me.btnZeroCal.Text = "Zero-Cal"
        Me.btnZeroCal.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(13, 3)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 31
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 162)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 208)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measurement Data"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblDeviceInfo)
        Me.GroupBox3.Location = New System.Drawing.Point(384, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(321, 87)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Device Information"
        '
        'ucCA310
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnUpdateState)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnZeroCal)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "ucCA310"
        Me.Size = New System.Drawing.Size(720, 388)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelSyncMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetCalMode As System.Windows.Forms.Button
    Friend WithEvents tbSyncModeFreqValue As System.Windows.Forms.TextBox
    Friend WithEvents cbSelDefCalMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetSyncMode As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbSelDisplayMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetBrightnessUnit As System.Windows.Forms.Button
    Friend WithEvents btnSetDispMode As System.Windows.Forms.Button
    Friend WithEvents cbSelBrightnessUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbSelDispDigits As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetAverageMode As System.Windows.Forms.Button
    Friend WithEvents btnSetDispDigits As System.Windows.Forms.Button
    Friend WithEvents cbSelAveragingMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnUpdateState As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents btnZeroCal As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblDeviceInfo As System.Windows.Forms.Label

End Class
