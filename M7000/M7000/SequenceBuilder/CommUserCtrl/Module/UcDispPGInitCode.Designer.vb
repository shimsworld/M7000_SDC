<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcDispPGInitCode
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
        Me.gbImportExport = New System.Windows.Forms.GroupBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.btnSaveInitCode = New System.Windows.Forms.Button()
        Me.btnLoadInitCode = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ucDataGrid = New M7000.ucDataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtCommand = New System.Windows.Forms.TextBox()
        Me.lblCommand = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.lblAdress = New System.Windows.Forms.Label()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.gbImportExport.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbControl.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbImportExport
        '
        Me.gbImportExport.Controls.Add(Me.lblFilePath)
        Me.gbImportExport.Controls.Add(Me.Label1)
        Me.gbImportExport.Controls.Add(Me.txtComments)
        Me.gbImportExport.Controls.Add(Me.lblComments)
        Me.gbImportExport.Controls.Add(Me.btnSaveInitCode)
        Me.gbImportExport.Controls.Add(Me.btnLoadInitCode)
        Me.gbImportExport.Location = New System.Drawing.Point(6, 6)
        Me.gbImportExport.Name = "gbImportExport"
        Me.gbImportExport.Size = New System.Drawing.Size(237, 175)
        Me.gbImportExport.TabIndex = 25
        Me.gbImportExport.TabStop = False
        Me.gbImportExport.Text = "File Load"
        '
        'lblFilePath
        '
        Me.lblFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFilePath.Location = New System.Drawing.Point(76, 45)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(149, 81)
        Me.lblFilePath.TabIndex = 11
        Me.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "File Path"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(76, 20)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(149, 20)
        Me.txtComments.TabIndex = 9
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(15, 24)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(49, 13)
        Me.lblComments.TabIndex = 8
        Me.lblComments.Text = "Init Code"
        '
        'btnSaveInitCode
        '
        Me.btnSaveInitCode.Location = New System.Drawing.Point(153, 129)
        Me.btnSaveInitCode.Name = "btnSaveInitCode"
        Me.btnSaveInitCode.Size = New System.Drawing.Size(72, 32)
        Me.btnSaveInitCode.TabIndex = 7
        Me.btnSaveInitCode.Text = "Save"
        Me.btnSaveInitCode.UseVisualStyleBackColor = True
        '
        'btnLoadInitCode
        '
        Me.btnLoadInitCode.Location = New System.Drawing.Point(76, 129)
        Me.btnLoadInitCode.Name = "btnLoadInitCode"
        Me.btnLoadInitCode.Size = New System.Drawing.Size(72, 32)
        Me.btnLoadInitCode.TabIndex = 6
        Me.btnLoadInitCode.Text = "Load"
        Me.btnLoadInitCode.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ucDataGrid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(847, 683)
        Me.SplitContainer1.SplitterDistance = 596
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 26
        '
        'ucDataGrid
        '
        Me.ucDataGrid.AutoScroll = True
        Me.ucDataGrid.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ucDataGrid.CellColor = Nothing
        Me.ucDataGrid.ColHeaderWidthRatio = "7,17,12,10,9,9,45"
        Me.ucDataGrid.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucDataGrid.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucDataGrid.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ucDataGrid.ControllerHeaderText = New String() {"NO", "Target", "MC(Addr)", "Length", "Value1", "Value2", "Comment"}
        Me.ucDataGrid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDataGrid.Location = New System.Drawing.Point(3, 3)
        Me.ucDataGrid.Name = "ucDataGrid"
        Me.ucDataGrid.RowHeaderSize = 30
        Me.ucDataGrid.RowLineNum = 1
        Me.ucDataGrid.Size = New System.Drawing.Size(592, 677)
        Me.ucDataGrid.TabIndex = 3
        Me.ucDataGrid.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucDataGrid.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbControl)
        Me.SplitContainer2.Size = New System.Drawing.Size(248, 683)
        Me.SplitContainer2.SplitterDistance = 192
        Me.SplitContainer2.TabIndex = 0
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.btnModify)
        Me.gbControl.Controls.Add(Me.btnDelete)
        Me.gbControl.Controls.Add(Me.btnAdd)
        Me.gbControl.Controls.Add(Me.GroupBox3)
        Me.gbControl.Location = New System.Drawing.Point(6, 13)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(240, 344)
        Me.gbControl.TabIndex = 1
        Me.gbControl.TabStop = False
        Me.gbControl.Visible = False
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(155, 197)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 41)
        Me.btnModify.TabIndex = 12
        Me.btnModify.Text = "MODIFY"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(81, 197)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(73, 41)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 197)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(73, 41)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtCommand)
        Me.GroupBox3.Controls.Add(Me.lblCommand)
        Me.GroupBox3.Controls.Add(Me.txtValue)
        Me.GroupBox3.Controls.Add(Me.txtLength)
        Me.GroupBox3.Controls.Add(Me.lblValue)
        Me.GroupBox3.Controls.Add(Me.lblLength)
        Me.GroupBox3.Controls.Add(Me.txtAddr)
        Me.GroupBox3.Controls.Add(Me.txtTarget)
        Me.GroupBox3.Controls.Add(Me.lblAdress)
        Me.GroupBox3.Controls.Add(Me.lblTarget)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(212, 175)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parameter"
        '
        'txtCommand
        '
        Me.txtCommand.Location = New System.Drawing.Point(96, 139)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(81, 20)
        Me.txtCommand.TabIndex = 9
        '
        'lblCommand
        '
        Me.lblCommand.AutoSize = True
        Me.lblCommand.Location = New System.Drawing.Point(19, 142)
        Me.lblCommand.Name = "lblCommand"
        Me.lblCommand.Size = New System.Drawing.Size(60, 13)
        Me.lblCommand.TabIndex = 8
        Me.lblCommand.Text = "Command :"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(96, 112)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(81, 20)
        Me.txtValue.TabIndex = 7
        '
        'txtLength
        '
        Me.txtLength.Location = New System.Drawing.Point(96, 85)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(81, 20)
        Me.txtLength.TabIndex = 6
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(46, 115)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(40, 13)
        Me.lblValue.TabIndex = 5
        Me.lblValue.Text = "Value :"
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.Location = New System.Drawing.Point(40, 88)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(46, 13)
        Me.lblLength.TabIndex = 4
        Me.lblLength.Text = "Length :"
        '
        'txtAddr
        '
        Me.txtAddr.Location = New System.Drawing.Point(96, 58)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(81, 20)
        Me.txtAddr.TabIndex = 3
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(96, 31)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(81, 20)
        Me.txtTarget.TabIndex = 2
        '
        'lblAdress
        '
        Me.lblAdress.AutoSize = True
        Me.lblAdress.Location = New System.Drawing.Point(14, 61)
        Me.lblAdress.Name = "lblAdress"
        Me.lblAdress.Size = New System.Drawing.Size(65, 13)
        Me.lblAdress.TabIndex = 1
        Me.lblAdress.Text = "CMD(Addr) :"
        '
        'lblTarget
        '
        Me.lblTarget.AutoSize = True
        Me.lblTarget.Location = New System.Drawing.Point(42, 34)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(44, 13)
        Me.lblTarget.TabIndex = 0
        Me.lblTarget.Text = "Target :"
        '
        'UcDispPGInitCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UcDispPGInitCode"
        Me.Size = New System.Drawing.Size(864, 722)
        Me.gbImportExport.ResumeLayout(False)
        Me.gbImportExport.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbControl.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbImportExport As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents btnSaveInitCode As System.Windows.Forms.Button
    Friend WithEvents btnLoadInitCode As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox
    Friend WithEvents lblCommand As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents lblAdress As System.Windows.Forms.Label
    Friend WithEvents lblTarget As System.Windows.Forms.Label
    Friend WithEvents ucDataGrid As M7000.ucDataGridView
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
