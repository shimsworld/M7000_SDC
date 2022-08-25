<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispSampleCommonNode
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
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.실험시작ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.실험정지ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnloadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.실험시작ToolStripMenuItem, Me.실험정지ToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoadSequenceToolStripMenuItem, Me.UnloadSequenceToolStripMenuItem, Me.ToolStripMenuItem2, Me.SavePathToolStripMenuItem, Me.ToolStripMenuItem3, Me.EditSequenceToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(169, 154)
        '
        '실험시작ToolStripMenuItem
        '
        Me.실험시작ToolStripMenuItem.Name = "실험시작ToolStripMenuItem"
        Me.실험시작ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.실험시작ToolStripMenuItem.Text = "실험 시작"
        Me.실험시작ToolStripMenuItem.Visible = False
        '
        '실험정지ToolStripMenuItem
        '
        Me.실험정지ToolStripMenuItem.Name = "실험정지ToolStripMenuItem"
        Me.실험정지ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.실험정지ToolStripMenuItem.Text = "실험 정지"
        Me.실험정지ToolStripMenuItem.Visible = False
        '
        'SavePathToolStripMenuItem
        '
        Me.SavePathToolStripMenuItem.Name = "SavePathToolStripMenuItem"
        Me.SavePathToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SavePathToolStripMenuItem.Text = "Save Path"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'LoadSequenceToolStripMenuItem
        '
        Me.LoadSequenceToolStripMenuItem.Name = "LoadSequenceToolStripMenuItem"
        Me.LoadSequenceToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.LoadSequenceToolStripMenuItem.Text = "Load Sequence"
        '
        'UnloadSequenceToolStripMenuItem
        '
        Me.UnloadSequenceToolStripMenuItem.Name = "UnloadSequenceToolStripMenuItem"
        Me.UnloadSequenceToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.UnloadSequenceToolStripMenuItem.Text = "Unload Sequence"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(165, 6)
        '
        'EditSequenceToolStripMenuItem
        '
        Me.EditSequenceToolStripMenuItem.Name = "EditSequenceToolStripMenuItem"
        Me.EditSequenceToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditSequenceToolStripMenuItem.Text = "Edit Sequence"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(165, 6)
        '
        'ucDispSampleCommonNode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ctxMenu
        Me.Name = "ucDispSampleCommonNode"
        Me.Size = New System.Drawing.Size(352, 161)
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 실험시작ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 실험정지ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnloadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SavePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator

End Class
