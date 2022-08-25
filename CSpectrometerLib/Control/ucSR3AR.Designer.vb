<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSR3AR
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
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnLocal = New System.Windows.Forms.Button()
        Me.btnRemote = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.cbSetMeasSpeed = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSetAperture = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSetApertureMode = New System.Windows.Forms.Button()
        Me.btnSetMeasuringSpeed = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(115, 13)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 40
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(13, 13)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 39
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnLocal
        '
        Me.btnLocal.Location = New System.Drawing.Point(353, 13)
        Me.btnLocal.Name = "btnLocal"
        Me.btnLocal.Size = New System.Drawing.Size(96, 44)
        Me.btnLocal.TabIndex = 42
        Me.btnLocal.Text = "Local"
        Me.btnLocal.UseVisualStyleBackColor = True
        '
        'btnRemote
        '
        Me.btnRemote.Location = New System.Drawing.Point(251, 13)
        Me.btnRemote.Name = "btnRemote"
        Me.btnRemote.Size = New System.Drawing.Size(96, 44)
        Me.btnRemote.TabIndex = 41
        Me.btnRemote.Text = "Remote"
        Me.btnRemote.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(581, 13)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(88, 44)
        Me.btnMeasure.TabIndex = 43
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'cbSetMeasSpeed
        '
        Me.cbSetMeasSpeed.FormattingEnabled = True
        Me.cbSetMeasSpeed.Location = New System.Drawing.Point(91, 59)
        Me.cbSetMeasSpeed.Name = "cbSetMeasSpeed"
        Me.cbSetMeasSpeed.Size = New System.Drawing.Size(130, 20)
        Me.cbSetMeasSpeed.TabIndex = 26
        Me.cbSetMeasSpeed.Text = "Nothing"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "MeasSpeed :"
        '
        'cbSetAperture
        '
        Me.cbSetAperture.FormattingEnabled = True
        Me.cbSetAperture.Location = New System.Drawing.Point(91, 26)
        Me.cbSetAperture.Name = "cbSetAperture"
        Me.cbSetAperture.Size = New System.Drawing.Size(130, 20)
        Me.cbSetAperture.TabIndex = 24
        Me.cbSetAperture.Text = "Nothing"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Aperture :"
        '
        'btnSetApertureMode
        '
        Me.btnSetApertureMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetApertureMode.Location = New System.Drawing.Point(238, 20)
        Me.btnSetApertureMode.Name = "btnSetApertureMode"
        Me.btnSetApertureMode.Size = New System.Drawing.Size(93, 31)
        Me.btnSetApertureMode.TabIndex = 27
        Me.btnSetApertureMode.Text = "SET"
        Me.btnSetApertureMode.UseVisualStyleBackColor = True
        '
        'btnSetMeasuringSpeed
        '
        Me.btnSetMeasuringSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetMeasuringSpeed.Location = New System.Drawing.Point(238, 53)
        Me.btnSetMeasuringSpeed.Name = "btnSetMeasuringSpeed"
        Me.btnSetMeasuringSpeed.Size = New System.Drawing.Size(93, 31)
        Me.btnSetMeasuringSpeed.TabIndex = 28
        Me.btnSetMeasuringSpeed.Text = "SET"
        Me.btnSetMeasuringSpeed.UseVisualStyleBackColor = True
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(487, 13)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 45
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblMeasuredDatas)
        Me.GroupBox2.Location = New System.Drawing.Point(382, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 171)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measurement Data"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(315, 151)
        Me.lblMeasuredDatas.TabIndex = 35
        Me.lblMeasuredDatas.Text = "Measurement Data"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSetApertureMode)
        Me.GroupBox1.Controls.Add(Me.btnSetMeasuringSpeed)
        Me.GroupBox1.Controls.Add(Me.cbSetMeasSpeed)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbSetAperture)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 101)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblStateMessage)
        Me.GroupBox3.Location = New System.Drawing.Point(382, 251)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(321, 63)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "State Message"
        '
        'lblStateMessage
        '
        Me.lblStateMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStateMessage.Location = New System.Drawing.Point(3, 17)
        Me.lblStateMessage.Name = "lblStateMessage"
        Me.lblStateMessage.Size = New System.Drawing.Size(315, 43)
        Me.lblStateMessage.TabIndex = 43
        Me.lblStateMessage.Text = "Datas"
        '
        'ucSR3AR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnLocal)
        Me.Controls.Add(Me.btnRemote)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnConnection)
        Me.Name = "ucSR3AR"
        Me.Size = New System.Drawing.Size(720, 329)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnLocal As System.Windows.Forms.Button
    Friend WithEvents btnRemote As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Private WithEvents cbSetMeasSpeed As System.Windows.Forms.ComboBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cbSetAperture As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSetApertureMode As System.Windows.Forms.Button
    Friend WithEvents btnSetMeasuringSpeed As System.Windows.Forms.Button
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label

End Class
