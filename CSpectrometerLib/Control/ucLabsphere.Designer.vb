<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLabsphere
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
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSetIntegAverage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAveragecount = New System.Windows.Forms.TextBox()
        Me.txtIntegrationTime = New System.Windows.Forms.TextBox()
        Me.btnSetAutoExpose = New System.Windows.Forms.Button()
        Me.btnDarkMeasure = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblStateMessage)
        Me.GroupBox3.Location = New System.Drawing.Point(380, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(321, 63)
        Me.GroupBox3.TabIndex = 78
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblMeasuredDatas)
        Me.GroupBox2.Location = New System.Drawing.Point(380, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 171)
        Me.GroupBox2.TabIndex = 77
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
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(407, 14)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 76
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(11, 14)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 73
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(113, 14)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 74
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(501, 14)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(88, 44)
        Me.btnMeasure.TabIndex = 75
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSetIntegAverage)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAveragecount)
        Me.GroupBox1.Controls.Add(Me.txtIntegrationTime)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 110)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "ms"
        '
        'btnSetIntegAverage
        '
        Me.btnSetIntegAverage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetIntegAverage.Location = New System.Drawing.Point(242, 27)
        Me.btnSetIntegAverage.Name = "btnSetIntegAverage"
        Me.btnSetIntegAverage.Size = New System.Drawing.Size(93, 31)
        Me.btnSetIntegAverage.TabIndex = 28
        Me.btnSetIntegAverage.Text = "SET"
        Me.btnSetIntegAverage.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Average Count"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Integration Time"
        '
        'txtAveragecount
        '
        Me.txtAveragecount.Location = New System.Drawing.Point(117, 60)
        Me.txtAveragecount.Name = "txtAveragecount"
        Me.txtAveragecount.Size = New System.Drawing.Size(90, 21)
        Me.txtAveragecount.TabIndex = 1
        '
        'txtIntegrationTime
        '
        Me.txtIntegrationTime.Location = New System.Drawing.Point(117, 33)
        Me.txtIntegrationTime.Name = "txtIntegrationTime"
        Me.txtIntegrationTime.Size = New System.Drawing.Size(90, 21)
        Me.txtIntegrationTime.TabIndex = 0
        '
        'btnSetAutoExpose
        '
        Me.btnSetAutoExpose.Location = New System.Drawing.Point(307, 14)
        Me.btnSetAutoExpose.Name = "btnSetAutoExpose"
        Me.btnSetAutoExpose.Size = New System.Drawing.Size(88, 44)
        Me.btnSetAutoExpose.TabIndex = 81
        Me.btnSetAutoExpose.Text = "Auto Expose"
        Me.btnSetAutoExpose.UseVisualStyleBackColor = True
        '
        'btnDarkMeasure
        '
        Me.btnDarkMeasure.Location = New System.Drawing.Point(595, 14)
        Me.btnDarkMeasure.Name = "btnDarkMeasure"
        Me.btnDarkMeasure.Size = New System.Drawing.Size(88, 44)
        Me.btnDarkMeasure.TabIndex = 82
        Me.btnDarkMeasure.Text = "Dark Measure"
        Me.btnDarkMeasure.UseVisualStyleBackColor = True
        '
        'ucLabsphere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDarkMeasure)
        Me.Controls.Add(Me.btnSetAutoExpose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnMeasure)
        Me.Name = "ucLabsphere"
        Me.Size = New System.Drawing.Size(715, 367)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSetIntegAverage As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAveragecount As System.Windows.Forms.TextBox
    Friend WithEvents txtIntegrationTime As System.Windows.Forms.TextBox
    Friend WithEvents btnSetAutoExpose As System.Windows.Forms.Button
    Friend WithEvents btnDarkMeasure As System.Windows.Forms.Button

End Class
