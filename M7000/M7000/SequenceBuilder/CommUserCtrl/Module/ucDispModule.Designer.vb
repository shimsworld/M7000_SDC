<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispModule
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
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpRegImsi = New System.Windows.Forms.TabPage()
        Me.ucPGInitCode = New M7000.UcDispPGInitCode()
        Me.tpPower = New System.Windows.Forms.TabPage()
        Me.ucPGPower = New M7000.ucDispPGPower()
        Me.tpImageSweep = New System.Windows.Forms.TabPage()
        Me.tcMain.SuspendLayout()
        Me.tpRegImsi.SuspendLayout()
        Me.tpPower.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpRegImsi)
        Me.tcMain.Controls.Add(Me.tpPower)
        Me.tcMain.Controls.Add(Me.tpImageSweep)
        Me.tcMain.Location = New System.Drawing.Point(3, 3)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(980, 559)
        Me.tcMain.TabIndex = 0
        '
        'tpRegImsi
        '
        Me.tpRegImsi.Controls.Add(Me.ucPGInitCode)
        Me.tpRegImsi.Location = New System.Drawing.Point(4, 22)
        Me.tpRegImsi.Name = "tpRegImsi"
        Me.tpRegImsi.Size = New System.Drawing.Size(972, 533)
        Me.tpRegImsi.TabIndex = 4
        Me.tpRegImsi.Text = "Init Code"
        Me.tpRegImsi.UseVisualStyleBackColor = True
        '
        'ucPGInitCode
        '
        Me.ucPGInitCode.AutoScroll = True
        Me.ucPGInitCode.IsVisibleOnlyGrid = False
        Me.ucPGInitCode.Location = New System.Drawing.Point(3, 3)
        Me.ucPGInitCode.Name = "ucPGInitCode"
        Me.ucPGInitCode.Size = New System.Drawing.Size(689, 409)
        Me.ucPGInitCode.TabIndex = 0
        '
        'tpPower
        '
        Me.tpPower.Controls.Add(Me.ucPGPower)
        Me.tpPower.Location = New System.Drawing.Point(4, 22)
        Me.tpPower.Name = "tpPower"
        Me.tpPower.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPower.Size = New System.Drawing.Size(972, 533)
        Me.tpPower.TabIndex = 0
        Me.tpPower.Text = "Power"
        Me.tpPower.UseVisualStyleBackColor = True
        '
        'ucPGPower
        '
        Me.ucPGPower.Location = New System.Drawing.Point(6, 6)
        Me.ucPGPower.MinimumSize = New System.Drawing.Size(437, 213)
        Me.ucPGPower.Name = "ucPGPower"
        Me.ucPGPower.Size = New System.Drawing.Size(437, 213)
        Me.ucPGPower.TabIndex = 1
        '
        'tpImageSweep
        '
        Me.tpImageSweep.Location = New System.Drawing.Point(4, 22)
        Me.tpImageSweep.Name = "tpImageSweep"
        Me.tpImageSweep.Size = New System.Drawing.Size(972, 533)
        Me.tpImageSweep.TabIndex = 5
        Me.tpImageSweep.Text = "Pattern"
        Me.tpImageSweep.UseVisualStyleBackColor = True
        '
        'ucDispModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tcMain)
        Me.Name = "ucDispModule"
        Me.Size = New System.Drawing.Size(990, 578)
        Me.tcMain.ResumeLayout(False)
        Me.tpRegImsi.ResumeLayout(False)
        Me.tpPower.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpPower As System.Windows.Forms.TabPage
    Friend WithEvents tpRegImsi As System.Windows.Forms.TabPage
    Friend WithEvents tpImageSweep As System.Windows.Forms.TabPage
    Friend WithEvents ucPGPower As M7000.ucDispPGPower
    Friend WithEvents ucPGInitCode As M7000.UcDispPGInitCode

End Class
