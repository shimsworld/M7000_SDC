<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCS100A
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
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSetCalibrationMode = New System.Windows.Forms.Button()
        Me.btnSetSpeedMode = New System.Windows.Forms.Button()
        Me.btnSetMeasuringMode = New System.Windows.Forms.Button()
        Me.cbSelCalibrationMode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelSpeedMode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelMeasMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(126, 8)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnDisConnection.TabIndex = 41
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(365, 8)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(112, 44)
        Me.btnMeasure.TabIndex = 40
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(13, 8)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnConnection.TabIndex = 39
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSetCalibrationMode)
        Me.GroupBox1.Controls.Add(Me.btnSetSpeedMode)
        Me.GroupBox1.Controls.Add(Me.btnSetMeasuringMode)
        Me.GroupBox1.Controls.Add(Me.cbSelCalibrationMode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbSelSpeedMode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbSelMeasMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 162)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'btnSetCalibrationMode
        '
        Me.btnSetCalibrationMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetCalibrationMode.Location = New System.Drawing.Point(255, 84)
        Me.btnSetCalibrationMode.Name = "btnSetCalibrationMode"
        Me.btnSetCalibrationMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetCalibrationMode.TabIndex = 8
        Me.btnSetCalibrationMode.Text = "SET"
        Me.btnSetCalibrationMode.UseVisualStyleBackColor = True
        '
        'btnSetSpeedMode
        '
        Me.btnSetSpeedMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetSpeedMode.Location = New System.Drawing.Point(255, 49)
        Me.btnSetSpeedMode.Name = "btnSetSpeedMode"
        Me.btnSetSpeedMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetSpeedMode.TabIndex = 7
        Me.btnSetSpeedMode.Text = "SET"
        Me.btnSetSpeedMode.UseVisualStyleBackColor = True
        '
        'btnSetMeasuringMode
        '
        Me.btnSetMeasuringMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetMeasuringMode.Location = New System.Drawing.Point(255, 14)
        Me.btnSetMeasuringMode.Name = "btnSetMeasuringMode"
        Me.btnSetMeasuringMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetMeasuringMode.TabIndex = 6
        Me.btnSetMeasuringMode.Text = "SET"
        Me.btnSetMeasuringMode.UseVisualStyleBackColor = True
        '
        'cbSelCalibrationMode
        '
        Me.cbSelCalibrationMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelCalibrationMode.FormattingEnabled = True
        Me.cbSelCalibrationMode.Location = New System.Drawing.Point(125, 90)
        Me.cbSelCalibrationMode.Name = "cbSelCalibrationMode"
        Me.cbSelCalibrationMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelCalibrationMode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Calibration Mode :"
        '
        'cbSelSpeedMode
        '
        Me.cbSelSpeedMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelSpeedMode.FormattingEnabled = True
        Me.cbSelSpeedMode.Location = New System.Drawing.Point(125, 55)
        Me.cbSelSpeedMode.Name = "cbSelSpeedMode"
        Me.cbSelSpeedMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelSpeedMode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Speed Mode :"
        '
        'cbSelMeasMode
        '
        Me.cbSelMeasMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelMeasMode.FormattingEnabled = True
        Me.cbSelMeasMode.Location = New System.Drawing.Point(125, 20)
        Me.cbSelMeasMode.Name = "cbSelMeasMode"
        Me.cbSelMeasMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelMeasMode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Measuring Mode :"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(273, 95)
        Me.lblMeasuredDatas.TabIndex = 43
        Me.lblMeasuredDatas.Text = "Datas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblMeasuredDatas)
        Me.GroupBox2.Location = New System.Drawing.Point(360, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 115)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measured Datas"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblStateMessage)
        Me.GroupBox3.Location = New System.Drawing.Point(360, 183)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 41)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "State Message"
        '
        'lblStateMessage
        '
        Me.lblStateMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStateMessage.Location = New System.Drawing.Point(3, 17)
        Me.lblStateMessage.Name = "lblStateMessage"
        Me.lblStateMessage.Size = New System.Drawing.Size(273, 21)
        Me.lblStateMessage.TabIndex = 43
        Me.lblStateMessage.Text = "Datas"
        '
        'ucCS100A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "ucCS100A"
        Me.Size = New System.Drawing.Size(651, 250)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelMeasMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSetCalibrationMode As System.Windows.Forms.Button
    Friend WithEvents btnSetSpeedMode As System.Windows.Forms.Button
    Friend WithEvents btnSetMeasuringMode As System.Windows.Forms.Button
    Friend WithEvents cbSelCalibrationMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelSpeedMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Public WithEvents lblStateMessage As System.Windows.Forms.Label

End Class
