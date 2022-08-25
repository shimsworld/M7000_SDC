<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispMultiCtrlCommonNode
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
        Me.SelectUnselectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectUnselectAGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectUnselectBGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectUnselectCGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnloadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SavePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.실험시작ToolStripMenuItem, Me.실험정지ToolStripMenuItem, Me.SelectUnselectToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.UnselectAllToolStripMenuItem, Me.SelectUnselectAGroupToolStripMenuItem, Me.SelectUnselectBGroupToolStripMenuItem, Me.SelectUnselectCGroupToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoadSequenceToolStripMenuItem, Me.UnloadSequenceToolStripMenuItem, Me.ToolStripMenuItem3, Me.SavePathToolStripMenuItem, Me.ToolStripMenuItem2, Me.EditSequenceToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(206, 308)
        '
        '실험시작ToolStripMenuItem
        '
        Me.실험시작ToolStripMenuItem.Name = "실험시작ToolStripMenuItem"
        Me.실험시작ToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.실험시작ToolStripMenuItem.Text = "실험 시작"
        Me.실험시작ToolStripMenuItem.Visible = False
        '
        '실험정지ToolStripMenuItem
        '
        Me.실험정지ToolStripMenuItem.Name = "실험정지ToolStripMenuItem"
        Me.실험정지ToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.실험정지ToolStripMenuItem.Text = "실험 정지"
        Me.실험정지ToolStripMenuItem.Visible = False
        '
        'SelectUnselectToolStripMenuItem
        '
        Me.SelectUnselectToolStripMenuItem.Name = "SelectUnselectToolStripMenuItem"
        Me.SelectUnselectToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SelectUnselectToolStripMenuItem.Text = "Select/Unselect"
        '
        'SelectUnselectAGroupToolStripMenuItem
        '
        Me.SelectUnselectAGroupToolStripMenuItem.Name = "SelectUnselectAGroupToolStripMenuItem"
        Me.SelectUnselectAGroupToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SelectUnselectAGroupToolStripMenuItem.Text = "Select/Unselect A Group"
        Me.SelectUnselectAGroupToolStripMenuItem.Visible = False
        '
        'SelectUnselectBGroupToolStripMenuItem
        '
        Me.SelectUnselectBGroupToolStripMenuItem.Name = "SelectUnselectBGroupToolStripMenuItem"
        Me.SelectUnselectBGroupToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SelectUnselectBGroupToolStripMenuItem.Text = "Select/Unselect B Group"
        Me.SelectUnselectBGroupToolStripMenuItem.Visible = False
        '
        'SelectUnselectCGroupToolStripMenuItem
        '
        Me.SelectUnselectCGroupToolStripMenuItem.Name = "SelectUnselectCGroupToolStripMenuItem"
        Me.SelectUnselectCGroupToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SelectUnselectCGroupToolStripMenuItem.Text = "Select/Unselect C Group"
        Me.SelectUnselectCGroupToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(202, 6)
        '
        'LoadSequenceToolStripMenuItem
        '
        Me.LoadSequenceToolStripMenuItem.Name = "LoadSequenceToolStripMenuItem"
        Me.LoadSequenceToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.LoadSequenceToolStripMenuItem.Text = "Load Sequence"
        '
        'UnloadSequenceToolStripMenuItem
        '
        Me.UnloadSequenceToolStripMenuItem.Name = "UnloadSequenceToolStripMenuItem"
        Me.UnloadSequenceToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.UnloadSequenceToolStripMenuItem.Text = "Unload Sequence"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(202, 6)
        '
        'SavePathToolStripMenuItem
        '
        Me.SavePathToolStripMenuItem.Name = "SavePathToolStripMenuItem"
        Me.SavePathToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SavePathToolStripMenuItem.Text = "Save Path"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(202, 6)
        '
        'EditSequenceToolStripMenuItem
        '
        Me.EditSequenceToolStripMenuItem.Name = "EditSequenceToolStripMenuItem"
        Me.EditSequenceToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.EditSequenceToolStripMenuItem.Text = "Edit Sequence"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'UnselectAllToolStripMenuItem
        '
        Me.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem"
        Me.UnselectAllToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.UnselectAllToolStripMenuItem.Text = "Unselect All"
        '
        'ucDispMultiCtrlCommonNode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ctxMenu
        Me.Name = "ucDispMultiCtrlCommonNode"
        Me.Size = New System.Drawing.Size(981, 562)
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 실험시작ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 실험정지ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnloadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SavePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectUnselectAGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectUnselectBGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectUnselectCGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectUnselectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnselectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
