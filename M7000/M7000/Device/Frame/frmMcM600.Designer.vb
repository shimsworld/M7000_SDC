<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMcM600
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
        Me.cbSelChannel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ucDispM6000Setting = New M7000.ucDispCellLifetime()
        Me.btnCtrl_SrcOn = New System.Windows.Forms.Button()
        Me.btnCtrl_SrcOFF = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.btnCtrl_Reset = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbControl.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSelChannel
        '
        Me.cbSelChannel.FormattingEnabled = True
        Me.cbSelChannel.Location = New System.Drawing.Point(258, 21)
        Me.cbSelChannel.Name = "cbSelChannel"
        Me.cbSelChannel.Size = New System.Drawing.Size(66, 20)
        Me.cbSelChannel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Channel :"
        '
        'ucDispM6000Setting
        '
        Me.ucDispM6000Setting.Location = New System.Drawing.Point(12, 68)
        Me.ucDispM6000Setting.Name = "ucDispM6000Setting"
        Me.ucDispM6000Setting.Size = New System.Drawing.Size(219, 256)
        Me.ucDispM6000Setting.TabIndex = 2
        Me.ucDispM6000Setting.ViewMode = M7000.ucDispCellLifetime.eViewMode.eAllView
        '
        'btnCtrl_SrcOn
        '
        Me.btnCtrl_SrcOn.Location = New System.Drawing.Point(15, 63)
        Me.btnCtrl_SrcOn.Name = "btnCtrl_SrcOn"
        Me.btnCtrl_SrcOn.Size = New System.Drawing.Size(72, 37)
        Me.btnCtrl_SrcOn.TabIndex = 3
        Me.btnCtrl_SrcOn.Text = "ON"
        Me.btnCtrl_SrcOn.UseVisualStyleBackColor = True
        '
        'btnCtrl_SrcOFF
        '
        Me.btnCtrl_SrcOFF.Location = New System.Drawing.Point(93, 63)
        Me.btnCtrl_SrcOFF.Name = "btnCtrl_SrcOFF"
        Me.btnCtrl_SrcOFF.Size = New System.Drawing.Size(72, 37)
        Me.btnCtrl_SrcOFF.TabIndex = 4
        Me.btnCtrl_SrcOFF.Text = "OFF"
        Me.btnCtrl_SrcOFF.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(12, 12)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(93, 37)
        Me.btnConnection.TabIndex = 5
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.btnCtrl_Reset)
        Me.gbControl.Controls.Add(Me.btnCtrl_SrcOn)
        Me.gbControl.Controls.Add(Me.btnCtrl_SrcOFF)
        Me.gbControl.Location = New System.Drawing.Point(237, 68)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(185, 171)
        Me.gbControl.TabIndex = 6
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "Control"
        '
        'btnCtrl_Reset
        '
        Me.btnCtrl_Reset.Location = New System.Drawing.Point(15, 20)
        Me.btnCtrl_Reset.Name = "btnCtrl_Reset"
        Me.btnCtrl_Reset.Size = New System.Drawing.Size(72, 37)
        Me.btnCtrl_Reset.TabIndex = 5
        Me.btnCtrl_Reset.Text = "Reset"
        Me.btnCtrl_Reset.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 351)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(428, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsStatus
        '
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(53, 17)
        Me.tsStatus.Text = "Message"
        '
        'frmMcM600
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 373)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbControl)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.ucDispM6000Setting)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSelChannel)
        Me.Name = "frmMcM600"
        Me.Text = "frmMcM600"
        Me.gbControl.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSelChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ucDispM6000Setting As M7000.ucDispCellLifetime
    Friend WithEvents btnCtrl_SrcOn As System.Windows.Forms.Button
    Friend WithEvents btnCtrl_SrcOFF As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Friend WithEvents btnCtrl_Reset As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsStatus As System.Windows.Forms.ToolStripStatusLabel
End Class
