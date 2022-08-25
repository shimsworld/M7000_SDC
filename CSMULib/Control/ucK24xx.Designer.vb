<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucK24xx
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
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisConnection = New System.Windows.Forms.Button()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.gbState = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.gbMeasData = New System.Windows.Forms.GroupBox()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.btnBiasOn = New System.Windows.Forms.Button()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.btnBiasOff = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbState.SuspendLayout()
        Me.gbMeasData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(262, 16)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 69
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(15, 16)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 64
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(117, 16)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 65
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(791, 16)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(94, 74)
        Me.btnMeasure.TabIndex = 68
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'gbState
        '
        Me.gbState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbState.Controls.Add(Me.lblStateMessage)
        Me.gbState.Location = New System.Drawing.Point(567, 251)
        Me.gbState.Name = "gbState"
        Me.gbState.Size = New System.Drawing.Size(315, 63)
        Me.gbState.TabIndex = 71
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
        Me.gbMeasData.Location = New System.Drawing.Point(567, 96)
        Me.gbMeasData.Name = "gbMeasData"
        Me.gbMeasData.Size = New System.Drawing.Size(318, 138)
        Me.gbMeasData.TabIndex = 70
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
        'btnBiasOn
        '
        Me.btnBiasOn.Location = New System.Drawing.Point(703, 16)
        Me.btnBiasOn.Name = "btnBiasOn"
        Me.btnBiasOn.Size = New System.Drawing.Size(77, 34)
        Me.btnBiasOn.TabIndex = 72
        Me.btnBiasOn.Text = "On"
        Me.btnBiasOn.UseVisualStyleBackColor = True
        '
        'tbBias
        '
        Me.tbBias.Location = New System.Drawing.Point(614, 24)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(69, 21)
        Me.tbBias.TabIndex = 73
        '
        'btnBiasOff
        '
        Me.btnBiasOff.Location = New System.Drawing.Point(703, 56)
        Me.btnBiasOff.Name = "btnBiasOff"
        Me.btnBiasOff.Size = New System.Drawing.Size(77, 34)
        Me.btnBiasOff.TabIndex = 74
        Me.btnBiasOff.Text = "Off"
        Me.btnBiasOff.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 12)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Bias :"
        '
        'ucK24xx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.Name = "ucK24xx"
        Me.Size = New System.Drawing.Size(901, 461)
        Me.gbState.ResumeLayout(False)
        Me.gbMeasData.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents gbState As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents gbMeasData As System.Windows.Forms.GroupBox
    Friend WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents btnBiasOn As System.Windows.Forms.Button
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents btnBiasOff As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
