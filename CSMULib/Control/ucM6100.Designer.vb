<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucM6100
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBiasOff = New System.Windows.Forms.Button()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.btnBiasOn = New System.Windows.Forms.Button()
        Me.gbState = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.gbMeasData = New System.Windows.Forms.GroupBox()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.tbAmp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFreq = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDuty = New System.Windows.Forms.TextBox()
        Me.gbState.SuspendLayout()
        Me.gbMeasData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(376, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 12)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Bias :"
        '
        'btnBiasOff
        '
        Me.btnBiasOff.Location = New System.Drawing.Point(706, 52)
        Me.btnBiasOff.Name = "btnBiasOff"
        Me.btnBiasOff.Size = New System.Drawing.Size(77, 34)
        Me.btnBiasOff.TabIndex = 94
        Me.btnBiasOff.Text = "Off"
        Me.btnBiasOff.UseVisualStyleBackColor = True
        '
        'tbBias
        '
        Me.tbBias.Location = New System.Drawing.Point(420, 26)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(69, 21)
        Me.tbBias.TabIndex = 93
        Me.tbBias.Text = "1"
        '
        'btnBiasOn
        '
        Me.btnBiasOn.Location = New System.Drawing.Point(706, 12)
        Me.btnBiasOn.Name = "btnBiasOn"
        Me.btnBiasOn.Size = New System.Drawing.Size(77, 34)
        Me.btnBiasOn.TabIndex = 92
        Me.btnBiasOn.Text = "On"
        Me.btnBiasOn.UseVisualStyleBackColor = True
        '
        'gbState
        '
        Me.gbState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbState.Controls.Add(Me.lblStateMessage)
        Me.gbState.Location = New System.Drawing.Point(570, 247)
        Me.gbState.Name = "gbState"
        Me.gbState.Size = New System.Drawing.Size(315, 63)
        Me.gbState.TabIndex = 91
        Me.gbState.TabStop = False
        Me.gbState.Text = "State Message"
        '
        'lblStateMessage
        '
        Me.lblStateMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStateMessage.Location = New System.Drawing.Point(3, 17)
        Me.lblStateMessage.Name = "lblStateMessage"
        Me.lblStateMessage.Size = New System.Drawing.Size(309, 43)
        Me.lblStateMessage.TabIndex = 43
        Me.lblStateMessage.Text = "Datas"
        '
        'gbMeasData
        '
        Me.gbMeasData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMeasData.Controls.Add(Me.lblMeasuredDatas)
        Me.gbMeasData.Location = New System.Drawing.Point(570, 92)
        Me.gbMeasData.Name = "gbMeasData"
        Me.gbMeasData.Size = New System.Drawing.Size(318, 138)
        Me.gbMeasData.TabIndex = 90
        Me.gbMeasData.TabStop = False
        Me.gbMeasData.Text = "Measurement Data"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(312, 118)
        Me.lblMeasuredDatas.TabIndex = 35
        Me.lblMeasuredDatas.Text = "Measurement Data"
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(265, 12)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 89
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(18, 12)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 86
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(120, 12)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 87
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(794, 12)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(94, 74)
        Me.btnMeasure.TabIndex = 88
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(498, 34)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(69, 12)
        Me.Label111.TabIndex = 97
        Me.Label111.Text = "Amplitude :"
        Me.Label111.Visible = False
        '
        'tbAmp
        '
        Me.tbAmp.Location = New System.Drawing.Point(570, 26)
        Me.tbAmp.Name = "tbAmp"
        Me.tbAmp.Size = New System.Drawing.Size(69, 21)
        Me.tbAmp.TabIndex = 96
        Me.tbAmp.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(376, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 12)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Freq :"
        Me.Label3.Visible = False
        '
        'tbFreq
        '
        Me.tbFreq.Location = New System.Drawing.Point(420, 60)
        Me.tbFreq.Name = "tbFreq"
        Me.tbFreq.Size = New System.Drawing.Size(69, 21)
        Me.tbFreq.TabIndex = 98
        Me.tbFreq.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(526, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 12)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Duty :"
        Me.Label4.Visible = False
        '
        'tbDuty
        '
        Me.tbDuty.Location = New System.Drawing.Point(570, 60)
        Me.tbDuty.Name = "tbDuty"
        Me.tbDuty.Size = New System.Drawing.Size(69, 21)
        Me.tbDuty.TabIndex = 100
        Me.tbDuty.Visible = False
        '
        'ucM6100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDuty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbFreq)
        Me.Controls.Add(Me.Label111)
        Me.Controls.Add(Me.tbAmp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBiasOff)
        Me.Controls.Add(Me.tbBias)
        Me.Controls.Add(Me.btnBiasOn)
        Me.Controls.Add(Me.gbState)
        Me.Controls.Add(Me.gbMeasData)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.btnMeasure)
        Me.Name = "ucM6100"
        Me.Size = New System.Drawing.Size(910, 386)
        Me.gbState.ResumeLayout(False)
        Me.gbMeasData.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBiasOff As System.Windows.Forms.Button
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents btnBiasOn As System.Windows.Forms.Button
    Friend WithEvents gbState As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents gbMeasData As System.Windows.Forms.GroupBox
    Friend WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents tbAmp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbFreq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbDuty As System.Windows.Forms.TextBox

End Class
