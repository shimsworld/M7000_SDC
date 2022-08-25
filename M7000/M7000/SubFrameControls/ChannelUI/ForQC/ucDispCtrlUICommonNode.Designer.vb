<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispCtrlUICommonNode
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
        Me.components = New System.ComponentModel.Container()
        Me.ctrlMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TestRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SequenceBuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctrlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctrlMenu
        '
        Me.ctrlMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestRunToolStripMenuItem, Me.TestStopToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoadSequenceToolStripMenuItem, Me.SaveSequenceToolStripMenuItem, Me.ToolStripMenuItem2, Me.SequenceBuilderToolStripMenuItem})
        Me.ctrlMenu.Name = "ctrlMenu"
        Me.ctrlMenu.Size = New System.Drawing.Size(168, 148)
        '
        'TestRunToolStripMenuItem
        '
        Me.TestRunToolStripMenuItem.Name = "TestRunToolStripMenuItem"
        Me.TestRunToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TestRunToolStripMenuItem.Text = "Test Run"
        '
        'TestStopToolStripMenuItem
        '
        Me.TestStopToolStripMenuItem.Name = "TestStopToolStripMenuItem"
        Me.TestStopToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TestStopToolStripMenuItem.Text = "Test Stop"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 6)
        '
        'LoadSequenceToolStripMenuItem
        '
        Me.LoadSequenceToolStripMenuItem.Name = "LoadSequenceToolStripMenuItem"
        Me.LoadSequenceToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LoadSequenceToolStripMenuItem.Text = "Load Sequence"
        '
        'SaveSequenceToolStripMenuItem
        '
        Me.SaveSequenceToolStripMenuItem.Name = "SaveSequenceToolStripMenuItem"
        Me.SaveSequenceToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SaveSequenceToolStripMenuItem.Text = "Save Sequence"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(164, 6)
        '
        'SequenceBuilderToolStripMenuItem
        '
        Me.SequenceBuilderToolStripMenuItem.Name = "SequenceBuilderToolStripMenuItem"
        Me.SequenceBuilderToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SequenceBuilderToolStripMenuItem.Text = "Sequence Builder"
        '
        'ucDispCtrlUICommonNode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ctrlMenu
        Me.Name = "ucDispCtrlUICommonNode"
        Me.Size = New System.Drawing.Size(945, 137)
        Me.ctrlMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctrlMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TestRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestStopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SequenceBuilderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
