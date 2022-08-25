<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatternGeneratorSetting
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
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpRegIMSI = New System.Windows.Forms.TabPage()
        Me.ucPGInitCode = New M7000.UcDispPGInitCode()
        Me.tpPower_RGB = New System.Windows.Forms.TabPage()
        Me.ucPGPower = New M7000.ucDispPGPower()
        Me.ucPGGrayScale = New M7000.ucDispPGGrayScale()
        Me.tpImageSweep = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.tcMain.SuspendLayout()
        Me.tpRegIMSI.SuspendLayout()
        Me.tpPower_RGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Controls.Add(Me.tpRegIMSI)
        Me.tcMain.Controls.Add(Me.tpPower_RGB)
        Me.tcMain.Controls.Add(Me.tpImageSweep)
        Me.tcMain.Location = New System.Drawing.Point(3, 2)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(988, 588)
        Me.tcMain.TabIndex = 1
        '
        'tpRegIMSI
        '
        Me.tpRegIMSI.Controls.Add(Me.ucPGInitCode)
        Me.tpRegIMSI.Location = New System.Drawing.Point(4, 22)
        Me.tpRegIMSI.Name = "tpRegIMSI"
        Me.tpRegIMSI.Size = New System.Drawing.Size(980, 562)
        Me.tpRegIMSI.TabIndex = 4
        Me.tpRegIMSI.Text = "Init Code"
        Me.tpRegIMSI.UseVisualStyleBackColor = True
        '
        'ucPGInitCode
        '
        Me.ucPGInitCode.AutoScroll = True
        Me.ucPGInitCode.IsVisibleOnlyGrid = False
        Me.ucPGInitCode.Location = New System.Drawing.Point(5, 3)
        Me.ucPGInitCode.Name = "ucPGInitCode"
        Me.ucPGInitCode.Size = New System.Drawing.Size(955, 556)
        Me.ucPGInitCode.TabIndex = 0
        '
        'tpPower_RGB
        '
        Me.tpPower_RGB.Controls.Add(Me.ucPGPower)
        Me.tpPower_RGB.Controls.Add(Me.ucPGGrayScale)
        Me.tpPower_RGB.Location = New System.Drawing.Point(4, 22)
        Me.tpPower_RGB.Name = "tpPower_RGB"
        Me.tpPower_RGB.Size = New System.Drawing.Size(980, 562)
        Me.tpPower_RGB.TabIndex = 3
        Me.tpPower_RGB.Text = "Power & RGB"
        Me.tpPower_RGB.UseVisualStyleBackColor = True
        '
        'ucPGPower
        '
        Me.ucPGPower.Location = New System.Drawing.Point(6, 3)
        Me.ucPGPower.MinimumSize = New System.Drawing.Size(510, 197)
        Me.ucPGPower.Name = "ucPGPower"
        Me.ucPGPower.Size = New System.Drawing.Size(532, 233)
        Me.ucPGPower.TabIndex = 1
        '
        'ucPGGrayScale
        '
        Me.ucPGGrayScale.Location = New System.Drawing.Point(5, 237)
        Me.ucPGGrayScale.Name = "ucPGGrayScale"
        Me.ucPGGrayScale.Size = New System.Drawing.Size(798, 246)
        Me.ucPGGrayScale.TabIndex = 0
        Me.ucPGGrayScale.Visible = False
        '
        'tpImageSweep
        '
        Me.tpImageSweep.Location = New System.Drawing.Point(4, 22)
        Me.tpImageSweep.Name = "tpImageSweep"
        Me.tpImageSweep.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImageSweep.Size = New System.Drawing.Size(980, 562)
        Me.tpImageSweep.TabIndex = 1
        Me.tpImageSweep.Text = "Pattern"
        Me.tpImageSweep.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(881, 597)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 37)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(772, 597)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 37)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmPatternGeneratorSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(998, 642)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tcMain)
        Me.Name = "frmPatternGeneratorSetting"
        Me.Text = "Pattern Generator Settings"
        Me.tcMain.ResumeLayout(False)
        Me.tpRegIMSI.ResumeLayout(False)
        Me.tpPower_RGB.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    'Friend WithEvents ucPGImageManager As ucDispPGImageManger
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tpPower_RGB As System.Windows.Forms.TabPage
    Friend WithEvents ucPGPower As ucDispPGPower
    Friend WithEvents ucPGGrayScale As ucDispPGGrayScale
    Friend WithEvents tpRegIMSI As System.Windows.Forms.TabPage
    Friend WithEvents tpImageSweep As System.Windows.Forms.TabPage
    Friend WithEvents ucPGInitCode As UcDispPGInitCode
End Class
