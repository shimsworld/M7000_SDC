<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPR650
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
        Me.gbState = New System.Windows.Forms.GroupBox()
        Me.lblStateMessage = New System.Windows.Forms.Label()
        Me.btnRemote = New System.Windows.Forms.Button()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.txtAverageCount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMeasSpeed = New System.Windows.Forms.TextBox()
        Me.cbSetLens = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLocal = New System.Windows.Forms.Button()
        Me.gbMeasData = New System.Windows.Forms.GroupBox()
        Me.lblMeasuredDatas = New System.Windows.Forms.Label()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.gbState.SuspendLayout()
        Me.gbControl.SuspendLayout()
        Me.gbMeasData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(485, 13)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(88, 44)
        Me.btnSetting.TabIndex = 72
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(11, 13)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnConnection.TabIndex = 67
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisConnection
        '
        Me.btnDisConnection.Location = New System.Drawing.Point(113, 13)
        Me.btnDisConnection.Name = "btnDisConnection"
        Me.btnDisConnection.Size = New System.Drawing.Size(96, 44)
        Me.btnDisConnection.TabIndex = 68
        Me.btnDisConnection.Text = "Disconnection"
        Me.btnDisConnection.UseVisualStyleBackColor = True
        '
        'gbState
        '
        Me.gbState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbState.Controls.Add(Me.lblStateMessage)
        Me.gbState.Location = New System.Drawing.Point(265, 251)
        Me.gbState.Name = "gbState"
        Me.gbState.Size = New System.Drawing.Size(401, 63)
        Me.gbState.TabIndex = 75
        Me.gbState.TabStop = False
        Me.gbState.Text = "State Message"
        '
        'lblStateMessage
        '
        Me.lblStateMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStateMessage.Location = New System.Drawing.Point(3, 17)
        Me.lblStateMessage.Name = "lblStateMessage"
        Me.lblStateMessage.Size = New System.Drawing.Size(395, 43)
        Me.lblStateMessage.TabIndex = 43
        Me.lblStateMessage.Text = "Datas"
        '
        'btnRemote
        '
        Me.btnRemote.Location = New System.Drawing.Point(249, 13)
        Me.btnRemote.Name = "btnRemote"
        Me.btnRemote.Size = New System.Drawing.Size(96, 44)
        Me.btnRemote.TabIndex = 69
        Me.btnRemote.Text = "Remote"
        Me.btnRemote.UseVisualStyleBackColor = True
        '
        'gbControl
        '
        Me.gbControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbControl.Controls.Add(Me.txtAverageCount)
        Me.gbControl.Controls.Add(Me.Label4)
        Me.gbControl.Controls.Add(Me.Label1)
        Me.gbControl.Controls.Add(Me.Label2)
        Me.gbControl.Controls.Add(Me.txtMeasSpeed)
        Me.gbControl.Controls.Add(Me.cbSetLens)
        Me.gbControl.Controls.Add(Me.Label3)
        Me.gbControl.Location = New System.Drawing.Point(11, 80)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(237, 114)
        Me.gbControl.TabIndex = 74
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "Control"
        '
        'txtAverageCount
        '
        Me.txtAverageCount.Location = New System.Drawing.Point(117, 82)
        Me.txtAverageCount.Name = "txtAverageCount"
        Me.txtAverageCount.Size = New System.Drawing.Size(81, 21)
        Me.txtAverageCount.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 12)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Average Count :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(204, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "ms"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 12)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Integration Time :"
        '
        'txtMeasSpeed
        '
        Me.txtMeasSpeed.Location = New System.Drawing.Point(117, 55)
        Me.txtMeasSpeed.Name = "txtMeasSpeed"
        Me.txtMeasSpeed.Size = New System.Drawing.Size(81, 21)
        Me.txtMeasSpeed.TabIndex = 35
        '
        'cbSetLens
        '
        Me.cbSetLens.FormattingEnabled = True
        Me.cbSetLens.Location = New System.Drawing.Point(102, 29)
        Me.cbSetLens.Name = "cbSetLens"
        Me.cbSetLens.Size = New System.Drawing.Size(130, 20)
        Me.cbSetLens.TabIndex = 33
        Me.cbSetLens.Text = "Nothing"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Lens :"
        '
        'btnLocal
        '
        Me.btnLocal.Location = New System.Drawing.Point(351, 13)
        Me.btnLocal.Name = "btnLocal"
        Me.btnLocal.Size = New System.Drawing.Size(96, 44)
        Me.btnLocal.TabIndex = 70
        Me.btnLocal.Text = "Local"
        Me.btnLocal.UseVisualStyleBackColor = True
        '
        'gbMeasData
        '
        Me.gbMeasData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMeasData.Controls.Add(Me.lblMeasuredDatas)
        Me.gbMeasData.Location = New System.Drawing.Point(265, 63)
        Me.gbMeasData.Name = "gbMeasData"
        Me.gbMeasData.Size = New System.Drawing.Size(404, 171)
        Me.gbMeasData.TabIndex = 73
        Me.gbMeasData.TabStop = False
        Me.gbMeasData.Text = "Measurement Data"
        '
        'lblMeasuredDatas
        '
        Me.lblMeasuredDatas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeasuredDatas.Location = New System.Drawing.Point(3, 17)
        Me.lblMeasuredDatas.Name = "lblMeasuredDatas"
        Me.lblMeasuredDatas.Size = New System.Drawing.Size(398, 151)
        Me.lblMeasuredDatas.TabIndex = 35
        Me.lblMeasuredDatas.Text = "Measurement Data"
        '
        'btnMeasure
        '
        Me.btnMeasure.Location = New System.Drawing.Point(579, 13)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(88, 44)
        Me.btnMeasure.TabIndex = 71
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.UseVisualStyleBackColor = True
        '
        'ucPR650
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.btnDisConnection)
        Me.Controls.Add(Me.gbState)
        Me.Controls.Add(Me.btnRemote)
        Me.Controls.Add(Me.gbControl)
        Me.Controls.Add(Me.btnLocal)
        Me.Controls.Add(Me.gbMeasData)
        Me.Controls.Add(Me.btnMeasure)
        Me.Name = "ucPR650"
        Me.Size = New System.Drawing.Size(693, 403)
        Me.gbState.ResumeLayout(False)
        Me.gbControl.ResumeLayout(False)
        Me.gbControl.PerformLayout()
        Me.gbMeasData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisConnection As System.Windows.Forms.Button
    Friend WithEvents gbState As System.Windows.Forms.GroupBox
    Public WithEvents lblStateMessage As System.Windows.Forms.Label
    Friend WithEvents btnRemote As System.Windows.Forms.Button
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Private WithEvents cbSetLens As System.Windows.Forms.ComboBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLocal As System.Windows.Forms.Button
    Friend WithEvents gbMeasData As System.Windows.Forms.GroupBox
    Friend WithEvents lblMeasuredDatas As System.Windows.Forms.Label
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMeasSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtAverageCount As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label

End Class
