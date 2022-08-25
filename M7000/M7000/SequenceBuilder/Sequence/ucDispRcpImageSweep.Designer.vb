<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpImageSweep
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
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbSweepList = New System.Windows.Forms.GroupBox()
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ucImageList = New M7000.ucDataGridView()
        Me.tlpPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbSweepList.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPanel2
        '
        Me.tlpPanel2.ColumnCount = 4
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Controls.Add(Me.btnMeasPoint, 3, 1)
        Me.tlpPanel2.Controls.Add(Me.btnEdit, 2, 1)
        Me.tlpPanel2.Controls.Add(Me.btnADD, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Location = New System.Drawing.Point(5, 4)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(682, 563)
        Me.tlpPanel2.TabIndex = 3
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.gbSweepList)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 480)
        Me.Panel1.TabIndex = 0
        '
        'gbSweepList
        '
        Me.gbSweepList.Controls.Add(Me.ucImageList)
        Me.gbSweepList.Location = New System.Drawing.Point(17, 20)
        Me.gbSweepList.Name = "gbSweepList"
        Me.gbSweepList.Size = New System.Drawing.Size(600, 411)
        Me.gbSweepList.TabIndex = 2
        Me.gbSweepList.TabStop = False
        Me.gbSweepList.Text = "Image Sweep List"
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Location = New System.Drawing.Point(513, 516)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(108, 36)
        Me.btnMeasPoint.TabIndex = 23
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(343, 516)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(73, 36)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(3, 516)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(73, 36)
        Me.btnADD.TabIndex = 24
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(173, 516)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(73, 36)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddImageToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(134, 26)
        '
        'AddImageToolStripMenuItem
        '
        Me.AddImageToolStripMenuItem.Name = "AddImageToolStripMenuItem"
        Me.AddImageToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AddImageToolStripMenuItem.Text = "Add Image"
        '
        'ucImageList
        '
        Me.ucImageList.AutoScroll = True
        Me.ucImageList.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucImageList.CellColor = Nothing
        Me.ucImageList.ColHeaderWidthRatio = "20,40,20,20"
        Me.ucImageList.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ucImageList.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucImageList.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        Me.ucImageList.ControllerHeaderText = New String() {"Image", "Image Name", "Delay", "Meas. Points"}
        Me.ucImageList.EnableEvent = True
        Me.ucImageList.Location = New System.Drawing.Point(7, 18)
        Me.ucImageList.Name = "ucImageList"
        Me.ucImageList.RowHeaderSize = 50
        Me.ucImageList.RowHeaderVisible = True
        Me.ucImageList.RowLineNum = 0
        Me.ucImageList.Size = New System.Drawing.Size(586, 300)
        Me.ucImageList.TabIndex = 0
        Me.ucImageList.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucImageList.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eButton}
        '
        'ucDispRcpImageSweep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpPanel2)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpImageSweep"
        Me.Size = New System.Drawing.Size(692, 575)
        Me.tlpPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbSweepList.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents gbSweepList As System.Windows.Forms.GroupBox
    Friend WithEvents ucImageList As M7000.ucDataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
