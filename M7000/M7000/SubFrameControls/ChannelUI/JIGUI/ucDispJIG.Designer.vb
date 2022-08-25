<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispJIG
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTopLayer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIndicator = New System.Windows.Forms.Label()
        Me.lblIndicator_Temp = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnJIGOutline = New System.Windows.Forms.Panel()
        Me.pnJIGArea = New System.Windows.Forms.Panel()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.실험시작ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.실험정지ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnloadSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SavePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlpMain.SuspendLayout()
        Me.tlpTopLayer.SuspendLayout()
        Me.pnJIGOutline.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.tlpTopLayer, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnJIGOutline, 0, 1)
        Me.tlpMain.Location = New System.Drawing.Point(28, 42)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.tlpMain.Size = New System.Drawing.Size(323, 277)
        Me.tlpMain.TabIndex = 4
        '
        'tlpTopLayer
        '
        Me.tlpTopLayer.ColumnCount = 3
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.416919!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.26814!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.523659!))
        Me.tlpTopLayer.Controls.Add(Me.lblIndicator, 0, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblIndicator_Temp, 2, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblTitle, 1, 0)
        Me.tlpTopLayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopLayer.Location = New System.Drawing.Point(3, 3)
        Me.tlpTopLayer.Name = "tlpTopLayer"
        Me.tlpTopLayer.RowCount = 1
        Me.tlpTopLayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopLayer.Size = New System.Drawing.Size(317, 17)
        Me.tlpTopLayer.TabIndex = 5
        '
        'lblIndicator
        '
        Me.lblIndicator.AutoSize = True
        Me.lblIndicator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIndicator.Location = New System.Drawing.Point(3, 0)
        Me.lblIndicator.Name = "lblIndicator"
        Me.lblIndicator.Size = New System.Drawing.Size(1, 17)
        Me.lblIndicator.TabIndex = 6
        Me.lblIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIndicator_Temp
        '
        Me.lblIndicator_Temp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIndicator_Temp.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIndicator_Temp.Location = New System.Drawing.Point(309, 0)
        Me.lblIndicator_Temp.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblIndicator_Temp.Name = "lblIndicator_Temp"
        Me.lblIndicator_Temp.Size = New System.Drawing.Size(7, 17)
        Me.lblIndicator_Temp.TabIndex = 5
        Me.lblIndicator_Temp.Text = "999.9"
        Me.lblIndicator_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(10, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(295, 17)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "JIG No."
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnJIGOutline
        '
        Me.pnJIGOutline.BackColor = System.Drawing.Color.Transparent
        Me.pnJIGOutline.Controls.Add(Me.pnJIGArea)
        Me.pnJIGOutline.Location = New System.Drawing.Point(3, 26)
        Me.pnJIGOutline.Name = "pnJIGOutline"
        Me.pnJIGOutline.Size = New System.Drawing.Size(297, 248)
        Me.pnJIGOutline.TabIndex = 2
        '
        'pnJIGArea
        '
        Me.pnJIGArea.Location = New System.Drawing.Point(16, 18)
        Me.pnJIGArea.Name = "pnJIGArea"
        Me.pnJIGArea.Size = New System.Drawing.Size(122, 155)
        Me.pnJIGArea.TabIndex = 5
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
        'SavePathToolStripMenuItem
        '
        Me.SavePathToolStripMenuItem.Name = "SavePathToolStripMenuItem"
        Me.SavePathToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SavePathToolStripMenuItem.Text = "Save Path"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(165, 6)
        '
        'EditSequenceToolStripMenuItem
        '
        Me.EditSequenceToolStripMenuItem.Name = "EditSequenceToolStripMenuItem"
        Me.EditSequenceToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditSequenceToolStripMenuItem.Text = "Edit Sequence"
        '
        'ucDispJIG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ctxMenu
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispJIG"
        Me.Size = New System.Drawing.Size(645, 528)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpTopLayer.ResumeLayout(False)
        Me.tlpTopLayer.PerformLayout()
        Me.pnJIGOutline.ResumeLayout(False)
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnJIGOutline As System.Windows.Forms.Panel
    Friend WithEvents pnJIGArea As System.Windows.Forms.Panel
    Friend WithEvents tlpTopLayer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblIndicator_Temp As System.Windows.Forms.Label
    Friend WithEvents lblIndicator As System.Windows.Forms.Label
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 실험시작ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 실험정지ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnloadSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SavePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator

End Class
