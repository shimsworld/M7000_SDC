<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBM7A
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtZRange = New System.Windows.Forms.TextBox()
        Me.txtYRange = New System.Windows.Forms.TextBox()
        Me.txtXRange = New System.Windows.Forms.TextBox()
        Me.btnSetAverageMode = New System.Windows.Forms.Button()
        Me.btnSetSpeedMode = New System.Windows.Forms.Button()
        Me.btnSetRangeMode = New System.Windows.Forms.Button()
        Me.cbSelAverageMode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbSelSpeedMode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelRangeMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFactornumber = New System.Windows.Forms.TextBox()
        Me.btnSetFactornumber = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblStateMessage)
        Me.GroupBox3.Location = New System.Drawing.Point(364, 234)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 41)
        Me.GroupBox3.TabIndex = 51
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblMeasuredDatas)
        Me.GroupBox2.Location = New System.Drawing.Point(364, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 160)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measured Datas"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(273, 140)
        Me.lblMeasuredDatas.TabIndex = 43
        Me.lblMeasuredDatas.Text = "Datas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSetFactornumber)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFactornumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtZRange)
        Me.GroupBox1.Controls.Add(Me.txtYRange)
        Me.GroupBox1.Controls.Add(Me.txtXRange)
        Me.GroupBox1.Controls.Add(Me.btnSetAverageMode)
        Me.GroupBox1.Controls.Add(Me.btnSetSpeedMode)
        Me.GroupBox1.Controls.Add(Me.btnSetRangeMode)
        Me.GroupBox1.Controls.Add(Me.cbSelAverageMode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbSelSpeedMode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbSelRangeMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 256)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(109, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Z Range : "
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Y Range : "
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "X Range : "
        '
        'txtZRange
        '
        Me.txtZRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtZRange.Location = New System.Drawing.Point(180, 105)
        Me.txtZRange.Name = "txtZRange"
        Me.txtZRange.Size = New System.Drawing.Size(68, 21)
        Me.txtZRange.TabIndex = 13
        '
        'txtYRange
        '
        Me.txtYRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYRange.Location = New System.Drawing.Point(180, 78)
        Me.txtYRange.Name = "txtYRange"
        Me.txtYRange.Size = New System.Drawing.Size(68, 21)
        Me.txtYRange.TabIndex = 12
        '
        'txtXRange
        '
        Me.txtXRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtXRange.Location = New System.Drawing.Point(180, 51)
        Me.txtXRange.Name = "txtXRange"
        Me.txtXRange.Size = New System.Drawing.Size(68, 21)
        Me.txtXRange.TabIndex = 11
        '
        'btnSetAverageMode
        '
        Me.btnSetAverageMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetAverageMode.Location = New System.Drawing.Point(255, 164)
        Me.btnSetAverageMode.Name = "btnSetAverageMode"
        Me.btnSetAverageMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetAverageMode.TabIndex = 8
        Me.btnSetAverageMode.Text = "SET"
        Me.btnSetAverageMode.UseVisualStyleBackColor = True
        '
        'btnSetSpeedMode
        '
        Me.btnSetSpeedMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetSpeedMode.Location = New System.Drawing.Point(255, 129)
        Me.btnSetSpeedMode.Name = "btnSetSpeedMode"
        Me.btnSetSpeedMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetSpeedMode.TabIndex = 7
        Me.btnSetSpeedMode.Text = "SET"
        Me.btnSetSpeedMode.UseVisualStyleBackColor = True
        '
        'btnSetRangeMode
        '
        Me.btnSetRangeMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetRangeMode.Location = New System.Drawing.Point(255, 14)
        Me.btnSetRangeMode.Name = "btnSetRangeMode"
        Me.btnSetRangeMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetRangeMode.TabIndex = 6
        Me.btnSetRangeMode.Text = "SET"
        Me.btnSetRangeMode.UseVisualStyleBackColor = True
        '
        'cbSelAverageMode
        '
        Me.cbSelAverageMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelAverageMode.FormattingEnabled = True
        Me.cbSelAverageMode.Location = New System.Drawing.Point(125, 170)
        Me.cbSelAverageMode.Name = "cbSelAverageMode"
        Me.cbSelAverageMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelAverageMode.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Average Mode :"
        '
        'cbSelSpeedMode
        '
        Me.cbSelSpeedMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelSpeedMode.FormattingEnabled = True
        Me.cbSelSpeedMode.Location = New System.Drawing.Point(125, 135)
        Me.cbSelSpeedMode.Name = "cbSelSpeedMode"
        Me.cbSelSpeedMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelSpeedMode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Speed Mode :"
        '
        'cbSelRangeMode
        '
        Me.cbSelRangeMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelRangeMode.FormattingEnabled = True
        Me.cbSelRangeMode.Location = New System.Drawing.Point(125, 20)
        Me.cbSelRangeMode.Name = "cbSelRangeMode"
        Me.cbSelRangeMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelRangeMode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Range Mode :"
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(130, 16)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnDisConnection.TabIndex = 48
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(369, 16)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(112, 44)
        Me.btnMeasure.TabIndex = 47
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(17, 16)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnConnection.TabIndex = 46
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 12)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Factor Number : "
        '
        'txtFactornumber
        '
        Me.txtFactornumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFactornumber.Location = New System.Drawing.Point(125, 208)
        Me.txtFactornumber.Name = "txtFactornumber"
        Me.txtFactornumber.Size = New System.Drawing.Size(68, 21)
        Me.txtFactornumber.TabIndex = 17
        '
        'btnSetFactornumber
        '
        Me.btnSetFactornumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetFactornumber.Location = New System.Drawing.Point(255, 202)
        Me.btnSetFactornumber.Name = "btnSetFactornumber"
        Me.btnSetFactornumber.Size = New System.Drawing.Size(72, 31)
        Me.btnSetFactornumber.TabIndex = 19
        Me.btnSetFactornumber.Text = "SET"
        Me.btnSetFactornumber.UseVisualStyleBackColor = True
        '
        'ucBM7A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "ucBM7A"
        Me.Size = New System.Drawing.Size(676, 347)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetAverageMode As System.Windows.Forms.Button
    Friend WithEvents btnSetSpeedMode As System.Windows.Forms.Button
    Friend WithEvents btnSetRangeMode As System.Windows.Forms.Button
    Friend WithEvents cbSelAverageMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbSelSpeedMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSelRangeMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtZRange As System.Windows.Forms.TextBox
    Friend WithEvents txtYRange As System.Windows.Forms.TextBox
    Friend WithEvents txtXRange As System.Windows.Forms.TextBox
    Friend WithEvents btnSetFactornumber As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFactornumber As System.Windows.Forms.TextBox

End Class
