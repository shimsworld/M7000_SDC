<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDefTestEndParam
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
        Me.cbSelParam = New System.Windows.Forms.ComboBox()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ucList = New M7000.ucDispListView()
        Me.ctxMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbMain.SuspendLayout()
        Me.ctxMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSelParam
        '
        Me.cbSelParam.FormattingEnabled = True
        Me.cbSelParam.Location = New System.Drawing.Point(10, 33)
        Me.cbSelParam.Name = "cbSelParam"
        Me.cbSelParam.Size = New System.Drawing.Size(150, 20)
        Me.cbSelParam.TabIndex = 0
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.btnADD)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.ucList)
        Me.gbMain.Controls.Add(Me.cbSelParam)
        Me.gbMain.Location = New System.Drawing.Point(3, 3)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(230, 232)
        Me.gbMain.TabIndex = 1
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Define Test End Param"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(162, 18)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(59, 35)
        Me.btnADD.TabIndex = 3
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select parameter : "
        '
        'ucList
        '
        Me.ucList.ColHeader = New String() {"No", "Param"}
        Me.ucList.ColHeaderWidthRatio = "20,80"
        Me.ucList.ContextMenuStrip = Me.ctxMenuStrip
        Me.ucList.FullRawSelection = True
        Me.ucList.Location = New System.Drawing.Point(10, 59)
        Me.ucList.Name = "ucList"
        Me.ucList.Size = New System.Drawing.Size(211, 168)
        Me.ucList.TabIndex = 0
        Me.ucList.UseCheckBoxex = True
        '
        'ctxMenuStrip
        '
        Me.ctxMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelToolStripMenuItem, Me.ToolStripMenuItem1, Me.ClearToolStripMenuItem})
        Me.ctxMenuStrip.Name = "ctxMenuStrip"
        Me.ctxMenuStrip.Size = New System.Drawing.Size(102, 54)
        '
        'DelToolStripMenuItem
        '
        Me.DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        Me.DelToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.DelToolStripMenuItem.Text = "Del"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(98, 6)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'ucDefTestEndParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbMain)
        Me.Name = "ucDefTestEndParam"
        Me.Size = New System.Drawing.Size(236, 244)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.ctxMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbSelParam As System.Windows.Forms.ComboBox
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ucList As M7000.ucDispListView
    Friend WithEvents ctxMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
