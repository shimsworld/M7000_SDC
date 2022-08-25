<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMcPGControl
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UcframePG = New M7000.ucMcPG()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UcframePower = New M7000.ucMcPGPower()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.UcFrameModuleControl = New M7000.ucMcPGControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1252, 813)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1244, 785)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PatternGenerator"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.UcframePG)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1238, 779)
        Me.Panel1.TabIndex = 0
        '
        'UcframePG
        '
        Me.UcframePG.AutoScroll = True
        Me.UcframePG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcframePG.Location = New System.Drawing.Point(0, 0)
        Me.UcframePG.Name = "UcframePG"
        Me.UcframePG.selectedDevice = 0
        Me.UcframePG.Size = New System.Drawing.Size(1238, 779)
        Me.UcframePG.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1244, 785)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Module Power"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UcframePower)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1238, 779)
        Me.Panel2.TabIndex = 0
        '
        'UcframePower
        '
        Me.UcframePower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcframePower.Location = New System.Drawing.Point(0, 0)
        Me.UcframePower.Name = "UcframePower"
        Me.UcframePower.selectedDevice = 0
        Me.UcframePower.Size = New System.Drawing.Size(1238, 779)
        Me.UcframePower.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.UcFrameModuleControl)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1244, 785)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Register"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'UcFrameModuleControl
        '
        Me.UcFrameModuleControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcFrameModuleControl.Location = New System.Drawing.Point(0, 0)
        Me.UcFrameModuleControl.Name = "UcFrameModuleControl"
        Me.UcFrameModuleControl.selectedDevice = 0
        Me.UcFrameModuleControl.Size = New System.Drawing.Size(1244, 785)
        Me.UcFrameModuleControl.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Device : "
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(143, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(130, 20)
        Me.ComboBox1.TabIndex = 2
        '
        'frmPGControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1263, 862)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmPGControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UcframePG As ucMcPG
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents UcFrameModuleControl As ucMcPGControl
    Friend WithEvents UcframePower As ucMcPGPower
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
