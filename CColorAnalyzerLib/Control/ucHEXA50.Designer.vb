<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHEXA50
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
        Me.btnSetRange = New System.Windows.Forms.Button()
        Me.cbSelRange = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSetOffset = New System.Windows.Forms.Button()
        Me.cbSelOffset = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSetDivider = New System.Windows.Forms.Button()
        Me.cbSelDivider = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSetRefCurrent = New System.Windows.Forms.Button()
        Me.btnSetIntegTime = New System.Windows.Forms.Button()
        Me.btnSetMeasuringMode = New System.Windows.Forms.Button()
        Me.cbSelRefCurrent = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelIntegTime = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelMeasMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblStateMessage)
        Me.GroupBox3.Location = New System.Drawing.Point(458, 271)
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
        Me.GroupBox2.Location = New System.Drawing.Point(458, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 199)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measured Datas"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(273, 179)
        Me.lblMeasuredDatas.TabIndex = 43
        Me.lblMeasuredDatas.Text = "Datas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.btnSetRange)
        Me.GroupBox1.Controls.Add(Me.cbSelRange)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnSetOffset)
        Me.GroupBox1.Controls.Add(Me.cbSelOffset)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnSetDivider)
        Me.GroupBox1.Controls.Add(Me.cbSelDivider)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnSetRefCurrent)
        Me.GroupBox1.Controls.Add(Me.btnSetIntegTime)
        Me.GroupBox1.Controls.Add(Me.btnSetMeasuringMode)
        Me.GroupBox1.Controls.Add(Me.cbSelRefCurrent)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbSelIntegTime)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbSelMeasMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 337)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'btnSetRange
        '
        Me.btnSetRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetRange.Location = New System.Drawing.Point(351, 104)
        Me.btnSetRange.Name = "btnSetRange"
        Me.btnSetRange.Size = New System.Drawing.Size(72, 31)
        Me.btnSetRange.TabIndex = 17
        Me.btnSetRange.Text = "SET"
        Me.btnSetRange.UseVisualStyleBackColor = True
        '
        'cbSelRange
        '
        Me.cbSelRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelRange.FormattingEnabled = True
        Me.cbSelRange.Location = New System.Drawing.Point(221, 110)
        Me.cbSelRange.Name = "cbSelRange"
        Me.cbSelRange.Size = New System.Drawing.Size(123, 20)
        Me.cbSelRange.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 12)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Range :"
        '
        'btnSetOffset
        '
        Me.btnSetOffset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetOffset.Location = New System.Drawing.Point(351, 285)
        Me.btnSetOffset.Name = "btnSetOffset"
        Me.btnSetOffset.Size = New System.Drawing.Size(72, 31)
        Me.btnSetOffset.TabIndex = 14
        Me.btnSetOffset.Text = "SET"
        Me.btnSetOffset.UseVisualStyleBackColor = True
        '
        'cbSelOffset
        '
        Me.cbSelOffset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelOffset.FormattingEnabled = True
        Me.cbSelOffset.Location = New System.Drawing.Point(221, 291)
        Me.cbSelOffset.Name = "cbSelOffset"
        Me.cbSelOffset.Size = New System.Drawing.Size(123, 20)
        Me.cbSelOffset.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 294)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Offset [dec] :"
        '
        'btnSetDivider
        '
        Me.btnSetDivider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetDivider.Location = New System.Drawing.Point(351, 248)
        Me.btnSetDivider.Name = "btnSetDivider"
        Me.btnSetDivider.Size = New System.Drawing.Size(72, 31)
        Me.btnSetDivider.TabIndex = 11
        Me.btnSetDivider.Text = "SET"
        Me.btnSetDivider.UseVisualStyleBackColor = True
        '
        'cbSelDivider
        '
        Me.cbSelDivider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelDivider.FormattingEnabled = True
        Me.cbSelDivider.Location = New System.Drawing.Point(221, 254)
        Me.cbSelDivider.Name = "cbSelDivider"
        Me.cbSelDivider.Size = New System.Drawing.Size(123, 20)
        Me.cbSelDivider.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Divider :"
        '
        'btnSetRefCurrent
        '
        Me.btnSetRefCurrent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetRefCurrent.Location = New System.Drawing.Point(351, 211)
        Me.btnSetRefCurrent.Name = "btnSetRefCurrent"
        Me.btnSetRefCurrent.Size = New System.Drawing.Size(72, 31)
        Me.btnSetRefCurrent.TabIndex = 8
        Me.btnSetRefCurrent.Text = "SET"
        Me.btnSetRefCurrent.UseVisualStyleBackColor = True
        '
        'btnSetIntegTime
        '
        Me.btnSetIntegTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetIntegTime.Location = New System.Drawing.Point(351, 176)
        Me.btnSetIntegTime.Name = "btnSetIntegTime"
        Me.btnSetIntegTime.Size = New System.Drawing.Size(72, 31)
        Me.btnSetIntegTime.TabIndex = 7
        Me.btnSetIntegTime.Text = "SET"
        Me.btnSetIntegTime.UseVisualStyleBackColor = True
        '
        'btnSetMeasuringMode
        '
        Me.btnSetMeasuringMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetMeasuringMode.Location = New System.Drawing.Point(351, 141)
        Me.btnSetMeasuringMode.Name = "btnSetMeasuringMode"
        Me.btnSetMeasuringMode.Size = New System.Drawing.Size(72, 31)
        Me.btnSetMeasuringMode.TabIndex = 6
        Me.btnSetMeasuringMode.Text = "SET"
        Me.btnSetMeasuringMode.UseVisualStyleBackColor = True
        '
        'cbSelRefCurrent
        '
        Me.cbSelRefCurrent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelRefCurrent.FormattingEnabled = True
        Me.cbSelRefCurrent.Location = New System.Drawing.Point(221, 217)
        Me.cbSelRefCurrent.Name = "cbSelRefCurrent"
        Me.cbSelRefCurrent.Size = New System.Drawing.Size(123, 20)
        Me.cbSelRefCurrent.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Reference Current :"
        '
        'cbSelIntegTime
        '
        Me.cbSelIntegTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelIntegTime.FormattingEnabled = True
        Me.cbSelIntegTime.Location = New System.Drawing.Point(221, 182)
        Me.cbSelIntegTime.Name = "cbSelIntegTime"
        Me.cbSelIntegTime.Size = New System.Drawing.Size(123, 20)
        Me.cbSelIntegTime.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Integration Time :"
        '
        'cbSelMeasMode
        '
        Me.cbSelMeasMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelMeasMode.FormattingEnabled = True
        Me.cbSelMeasMode.Location = New System.Drawing.Point(221, 147)
        Me.cbSelMeasMode.Name = "cbSelMeasMode"
        Me.cbSelMeasMode.Size = New System.Drawing.Size(123, 20)
        Me.cbSelMeasMode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Measuring Mode :"
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(128, 12)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnDisConnection.TabIndex = 48
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(340, 12)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(112, 44)
        Me.btnMeasure.TabIndex = 47
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(15, 12)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(107, 44)
        Me.btnConnection.TabIndex = 46
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(380, 74)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(18, 30)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(56, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "AUTO"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(94, 30)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(74, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "MANUAL"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(189, 29)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(124, 20)
        Me.ComboBox1.TabIndex = 2
        '
        'ucHEXA50
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "ucHEXA50"
        Me.Size = New System.Drawing.Size(750, 457)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetOffset As System.Windows.Forms.Button
    Friend WithEvents cbSelOffset As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSetDivider As System.Windows.Forms.Button
    Friend WithEvents cbSelDivider As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSetRefCurrent As System.Windows.Forms.Button
    Friend WithEvents btnSetIntegTime As System.Windows.Forms.Button
    Friend WithEvents btnSetMeasuringMode As System.Windows.Forms.Button
    Friend WithEvents cbSelRefCurrent As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelIntegTime As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSelMeasMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnSetRange As System.Windows.Forms.Button
    Friend WithEvents cbSelRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton

End Class
