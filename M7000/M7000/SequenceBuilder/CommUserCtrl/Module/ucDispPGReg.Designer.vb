<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispPGReg
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
        Me.spcMain = New System.Windows.Forms.SplitContainer()
        Me.ucDispDataGrid = New M7000.ucDataGridView()
        Me.menuGridCtrl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DOWNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gbImportExport = New System.Windows.Forms.GroupBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_Pattern = New System.Windows.Forms.ComboBox()
        Me.gbSettings = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.tbValue = New System.Windows.Forms.TextBox()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.tbRegName = New System.Windows.Forms.TextBox()
        Me.lblVlow = New System.Windows.Forms.Label()
        Me.lblVhigh = New System.Windows.Forms.Label()
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcMain.Panel1.SuspendLayout()
        Me.spcMain.Panel2.SuspendLayout()
        Me.spcMain.SuspendLayout()
        Me.menuGridCtrl.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbImportExport.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'spcMain
        '
        Me.spcMain.Location = New System.Drawing.Point(10, 18)
        Me.spcMain.Name = "spcMain"
        '
        'spcMain.Panel1
        '
        Me.spcMain.Panel1.Controls.Add(Me.ucDispDataGrid)
        '
        'spcMain.Panel2
        '
        Me.spcMain.Panel2.Controls.Add(Me.SplitContainer2)
        Me.spcMain.Size = New System.Drawing.Size(938, 704)
        Me.spcMain.SplitterDistance = 542
        Me.spcMain.SplitterWidth = 3
        Me.spcMain.TabIndex = 8
        '
        'ucDispDataGrid
        '
        Me.ucDispDataGrid.AutoScroll = True
        Me.ucDispDataGrid.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucDispDataGrid.CellColor = Nothing
        Me.ucDispDataGrid.ColHeaderWidthRatio = "30,15,10,45"
        Me.ucDispDataGrid.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ucDispDataGrid.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucDispDataGrid.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ucDispDataGrid.ContextMenuStrip = Me.menuGridCtrl
        Me.ucDispDataGrid.ControllerHeaderText = New String() {"Reg. Name", "CMD(Addr)", "Len", "Value"}
        Me.ucDispDataGrid.Location = New System.Drawing.Point(3, 3)
        Me.ucDispDataGrid.Name = "ucDispDataGrid"
        Me.ucDispDataGrid.RowHeaderSize = 30
        Me.ucDispDataGrid.RowLineNum = 0
        Me.ucDispDataGrid.Size = New System.Drawing.Size(532, 561)
        Me.ucDispDataGrid.TabIndex = 2
        Me.ucDispDataGrid.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucDispDataGrid.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
        '
        'menuGridCtrl
        '
        Me.menuGridCtrl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UPToolStripMenuItem, Me.DOWNToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.ClearToolStripMenuItem})
        Me.menuGridCtrl.Name = "menuGridCtrl"
        Me.menuGridCtrl.Size = New System.Drawing.Size(112, 104)
        '
        'UPToolStripMenuItem
        '
        Me.UPToolStripMenuItem.Name = "UPToolStripMenuItem"
        Me.UPToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.UPToolStripMenuItem.Text = "UP"
        Me.UPToolStripMenuItem.Visible = False
        '
        'DOWNToolStripMenuItem
        '
        Me.DOWNToolStripMenuItem.Name = "DOWNToolStripMenuItem"
        Me.DOWNToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.DOWNToolStripMenuItem.Text = "DOWN"
        Me.DOWNToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(108, 6)
        Me.ToolStripMenuItem1.Visible = False
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        Me.DeleteToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(108, 6)
        Me.ToolStripMenuItem2.Visible = False
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbImportExport)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbSettings)
        Me.SplitContainer2.Size = New System.Drawing.Size(393, 704)
        Me.SplitContainer2.SplitterDistance = 138
        Me.SplitContainer2.TabIndex = 0
        '
        'gbImportExport
        '
        Me.gbImportExport.Controls.Add(Me.txtComments)
        Me.gbImportExport.Controls.Add(Me.lblComments)
        Me.gbImportExport.Controls.Add(Me.btnLoad)
        Me.gbImportExport.Controls.Add(Me.btnSave)
        Me.gbImportExport.Location = New System.Drawing.Point(15, 8)
        Me.gbImportExport.Name = "gbImportExport"
        Me.gbImportExport.Size = New System.Drawing.Size(213, 91)
        Me.gbImportExport.TabIndex = 6
        Me.gbImportExport.TabStop = False
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(79, 22)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(121, 20)
        Me.txtComments.TabIndex = 9
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(13, 26)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(59, 13)
        Me.lblComments.TabIndex = 8
        Me.lblComments.Text = "Comments "
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(92, 49)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(60, 36)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(27, 49)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 36)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_Pattern)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 67)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Default Pattern"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Select Pattern : "
        '
        'cbo_Pattern
        '
        Me.cbo_Pattern.FormattingEnabled = True
        Me.cbo_Pattern.Items.AddRange(New Object() {"단색 칼라", "5*5 Pattern", "5*5 Pattern ( 3,3) 색변경", "가로 3 블럭 설정", "세로 3 블럭 설정"})
        Me.cbo_Pattern.Location = New System.Drawing.Point(112, 27)
        Me.cbo_Pattern.Name = "cbo_Pattern"
        Me.cbo_Pattern.Size = New System.Drawing.Size(156, 21)
        Me.cbo_Pattern.TabIndex = 0
        '
        'gbSettings
        '
        Me.gbSettings.Controls.Add(Me.btnAdd)
        Me.gbSettings.Controls.Add(Me.tbValue)
        Me.gbSettings.Controls.Add(Me.lblDelay)
        Me.gbSettings.Controls.Add(Me.tbAddress)
        Me.gbSettings.Controls.Add(Me.tbRegName)
        Me.gbSettings.Controls.Add(Me.lblVlow)
        Me.gbSettings.Controls.Add(Me.lblVhigh)
        Me.gbSettings.Location = New System.Drawing.Point(6, 3)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Size = New System.Drawing.Size(283, 198)
        Me.gbSettings.TabIndex = 3
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "Settings"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(38, 147)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(189, 44)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'tbValue
        '
        Me.tbValue.Location = New System.Drawing.Point(104, 87)
        Me.tbValue.Multiline = True
        Me.tbValue.Name = "tbValue"
        Me.tbValue.Size = New System.Drawing.Size(164, 54)
        Me.tbValue.TabIndex = 6
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(60, 92)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(40, 13)
        Me.lblDelay.TabIndex = 4
        Me.lblDelay.Text = "Value :"
        '
        'tbAddress
        '
        Me.tbAddress.Location = New System.Drawing.Point(104, 54)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(164, 20)
        Me.tbAddress.TabIndex = 3
        '
        'tbRegName
        '
        Me.tbRegName.Location = New System.Drawing.Point(104, 23)
        Me.tbRegName.Name = "tbRegName"
        Me.tbRegName.Size = New System.Drawing.Size(164, 20)
        Me.tbRegName.TabIndex = 2
        '
        'lblVlow
        '
        Me.lblVlow.AutoSize = True
        Me.lblVlow.Location = New System.Drawing.Point(47, 59)
        Me.lblVlow.Name = "lblVlow"
        Me.lblVlow.Size = New System.Drawing.Size(51, 13)
        Me.lblVlow.TabIndex = 1
        Me.lblVlow.Text = "Address :"
        '
        'lblVhigh
        '
        Me.lblVhigh.AutoSize = True
        Me.lblVhigh.Location = New System.Drawing.Point(15, 26)
        Me.lblVhigh.Name = "lblVhigh"
        Me.lblVhigh.Size = New System.Drawing.Size(83, 13)
        Me.lblVhigh.TabIndex = 0
        Me.lblVhigh.Text = "Register Name :"
        '
        'ucDispPGReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spcMain)
        Me.Name = "ucDispPGReg"
        Me.Size = New System.Drawing.Size(1077, 726)
        Me.spcMain.Panel1.ResumeLayout(False)
        Me.spcMain.Panel2.ResumeLayout(False)
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcMain.ResumeLayout(False)
        Me.menuGridCtrl.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbImportExport.ResumeLayout(False)
        Me.gbImportExport.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSettings.ResumeLayout(False)
        Me.gbSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spcMain As System.Windows.Forms.SplitContainer
    Friend WithEvents ucDispDataGrid As ucDataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbImportExport As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbSettings As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents tbValue As System.Windows.Forms.TextBox
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents tbRegName As System.Windows.Forms.TextBox
    Friend WithEvents lblVlow As System.Windows.Forms.Label
    Friend WithEvents lblVhigh As System.Windows.Forms.Label
    Friend WithEvents menuGridCtrl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DOWNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_Pattern As System.Windows.Forms.ComboBox

End Class
