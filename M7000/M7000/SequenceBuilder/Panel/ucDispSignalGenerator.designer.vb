<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispSignalGenerator
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
        Me.lblControlLine = New System.Windows.Forms.Label()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTempLimit = New System.Windows.Forms.TextBox()
        Me.lblTempLimit = New System.Windows.Forms.Label()
        Me.tbAverage = New System.Windows.Forms.TextBox()
        Me.lblAverage = New System.Windows.Forms.Label()
        Me.tbCurrentLimit = New System.Windows.Forms.TextBox()
        Me.lblCurrentLimit = New System.Windows.Forms.Label()
        Me.txtperiod = New System.Windows.Forms.TextBox()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.txtwidth = New System.Windows.Forms.TextBox()
        Me.txtdelay = New System.Windows.Forms.TextBox()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.tbAmplitude = New System.Windows.Forms.TextBox()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.lblVlow = New System.Windows.Forms.Label()
        Me.lblVhigh = New System.Windows.Forms.Label()
        Me.lbl_Amplitude = New System.Windows.Forms.Label()
        Me.lbl_Bias = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoPV = New System.Windows.Forms.RadioButton()
        Me.rdoCV = New System.Windows.Forms.RadioButton()
        Me.cboControlLine = New System.Windows.Forms.ComboBox()
        Me.gbImportExport = New System.Windows.Forms.GroupBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ucDispDataGrid = New M7000.ucDataGridView()
        Me.ctxListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPDAverage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbControl.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbImportExport.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ctxListMenu.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblControlLine
        '
        Me.lblControlLine.AutoSize = True
        Me.lblControlLine.Location = New System.Drawing.Point(14, 18)
        Me.lblControlLine.Name = "lblControlLine"
        Me.lblControlLine.Size = New System.Drawing.Size(120, 12)
        Me.lblControlLine.TabIndex = 0
        Me.lblControlLine.Text = "Select Control Line :"
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.btnModify)
        Me.gbControl.Controls.Add(Me.btnDelete)
        Me.gbControl.Controls.Add(Me.btnAdd)
        Me.gbControl.Controls.Add(Me.GroupBox3)
        Me.gbControl.Controls.Add(Me.GroupBox2)
        Me.gbControl.Controls.Add(Me.cboControlLine)
        Me.gbControl.Controls.Add(Me.lblControlLine)
        Me.gbControl.Location = New System.Drawing.Point(17, 3)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(248, 381)
        Me.gbControl.TabIndex = 1
        Me.gbControl.TabStop = False
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(160, 337)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 41)
        Me.btnModify.TabIndex = 12
        Me.btnModify.Text = "MODIFY"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(86, 337)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(73, 41)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(11, 337)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(73, 41)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.tbTempLimit)
        Me.GroupBox3.Controls.Add(Me.lblTempLimit)
        Me.GroupBox3.Controls.Add(Me.tbAverage)
        Me.GroupBox3.Controls.Add(Me.lblAverage)
        Me.GroupBox3.Controls.Add(Me.tbCurrentLimit)
        Me.GroupBox3.Controls.Add(Me.lblCurrentLimit)
        Me.GroupBox3.Controls.Add(Me.txtperiod)
        Me.GroupBox3.Controls.Add(Me.lblPeriod)
        Me.GroupBox3.Controls.Add(Me.txtwidth)
        Me.GroupBox3.Controls.Add(Me.txtdelay)
        Me.GroupBox3.Controls.Add(Me.lblWidth)
        Me.GroupBox3.Controls.Add(Me.lblDelay)
        Me.GroupBox3.Controls.Add(Me.tbAmplitude)
        Me.GroupBox3.Controls.Add(Me.tbBias)
        Me.GroupBox3.Controls.Add(Me.lblVlow)
        Me.GroupBox3.Controls.Add(Me.lblVhigh)
        Me.GroupBox3.Controls.Add(Me.lbl_Amplitude)
        Me.GroupBox3.Controls.Add(Me.lbl_Bias)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(220, 241)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parameter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(192, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "us"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "us"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(192, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "us"
        '
        'tbTempLimit
        '
        Me.tbTempLimit.Location = New System.Drawing.Point(106, 182)
        Me.tbTempLimit.Name = "tbTempLimit"
        Me.tbTempLimit.Size = New System.Drawing.Size(81, 21)
        Me.tbTempLimit.TabIndex = 15
        '
        'lblTempLimit
        '
        Me.lblTempLimit.AutoSize = True
        Me.lblTempLimit.Location = New System.Drawing.Point(23, 185)
        Me.lblTempLimit.Name = "lblTempLimit"
        Me.lblTempLimit.Size = New System.Drawing.Size(77, 12)
        Me.lblTempLimit.TabIndex = 14
        Me.lblTempLimit.Text = "Temp Limit :"
        '
        'tbAverage
        '
        Me.tbAverage.Location = New System.Drawing.Point(106, 209)
        Me.tbAverage.Name = "tbAverage"
        Me.tbAverage.Size = New System.Drawing.Size(81, 21)
        Me.tbAverage.TabIndex = 13
        '
        'lblAverage
        '
        Me.lblAverage.AutoSize = True
        Me.lblAverage.Location = New System.Drawing.Point(41, 212)
        Me.lblAverage.Name = "lblAverage"
        Me.lblAverage.Size = New System.Drawing.Size(59, 12)
        Me.lblAverage.TabIndex = 12
        Me.lblAverage.Text = "Average :"
        '
        'tbCurrentLimit
        '
        Me.tbCurrentLimit.Location = New System.Drawing.Point(106, 155)
        Me.tbCurrentLimit.Name = "tbCurrentLimit"
        Me.tbCurrentLimit.Size = New System.Drawing.Size(81, 21)
        Me.tbCurrentLimit.TabIndex = 11
        '
        'lblCurrentLimit
        '
        Me.lblCurrentLimit.AutoSize = True
        Me.lblCurrentLimit.Location = New System.Drawing.Point(15, 158)
        Me.lblCurrentLimit.Name = "lblCurrentLimit"
        Me.lblCurrentLimit.Size = New System.Drawing.Size(85, 12)
        Me.lblCurrentLimit.TabIndex = 10
        Me.lblCurrentLimit.Text = "Current Limit :"
        '
        'txtperiod
        '
        Me.txtperiod.Location = New System.Drawing.Point(106, 128)
        Me.txtperiod.Name = "txtperiod"
        Me.txtperiod.Size = New System.Drawing.Size(81, 21)
        Me.txtperiod.TabIndex = 9
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(51, 131)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(49, 12)
        Me.lblPeriod.TabIndex = 8
        Me.lblPeriod.Text = "Period :"
        '
        'txtwidth
        '
        Me.txtwidth.Location = New System.Drawing.Point(106, 101)
        Me.txtwidth.Name = "txtwidth"
        Me.txtwidth.Size = New System.Drawing.Size(81, 21)
        Me.txtwidth.TabIndex = 7
        '
        'txtdelay
        '
        Me.txtdelay.Location = New System.Drawing.Point(106, 74)
        Me.txtdelay.Name = "txtdelay"
        Me.txtdelay.Size = New System.Drawing.Size(81, 21)
        Me.txtdelay.TabIndex = 6
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(57, 104)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(43, 12)
        Me.lblWidth.TabIndex = 5
        Me.lblWidth.Text = "Width :"
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(55, 77)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(45, 12)
        Me.lblDelay.TabIndex = 4
        Me.lblDelay.Text = "Delay :"
        '
        'tbAmplitude
        '
        Me.tbAmplitude.Location = New System.Drawing.Point(106, 47)
        Me.tbAmplitude.Name = "tbAmplitude"
        Me.tbAmplitude.Size = New System.Drawing.Size(81, 21)
        Me.tbAmplitude.TabIndex = 3
        '
        'tbBias
        '
        Me.tbBias.Location = New System.Drawing.Point(106, 20)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(81, 21)
        Me.tbBias.TabIndex = 2
        '
        'lblVlow
        '
        Me.lblVlow.AutoSize = True
        Me.lblVlow.Location = New System.Drawing.Point(31, 50)
        Me.lblVlow.Name = "lblVlow"
        Me.lblVlow.Size = New System.Drawing.Size(69, 12)
        Me.lblVlow.TabIndex = 1
        Me.lblVlow.Text = "Amplitude :"
        '
        'lblVhigh
        '
        Me.lblVhigh.AutoSize = True
        Me.lblVhigh.Location = New System.Drawing.Point(62, 23)
        Me.lblVhigh.Name = "lblVhigh"
        Me.lblVhigh.Size = New System.Drawing.Size(38, 12)
        Me.lblVhigh.TabIndex = 0
        Me.lblVhigh.Text = "Bias :"
        '
        'lbl_Amplitude
        '
        Me.lbl_Amplitude.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Amplitude.Location = New System.Drawing.Point(104, 45)
        Me.lbl_Amplitude.Name = "lbl_Amplitude"
        Me.lbl_Amplitude.Size = New System.Drawing.Size(85, 25)
        Me.lbl_Amplitude.TabIndex = 33
        '
        'lbl_Bias
        '
        Me.lbl_Bias.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Bias.Location = New System.Drawing.Point(104, 18)
        Me.lbl_Bias.Name = "lbl_Bias"
        Me.lbl_Bias.Size = New System.Drawing.Size(85, 25)
        Me.lbl_Bias.TabIndex = 34
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoPV)
        Me.GroupBox2.Controls.Add(Me.rdoCV)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 45)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mode"
        '
        'rdoPV
        '
        Me.rdoPV.AutoSize = True
        Me.rdoPV.Location = New System.Drawing.Point(132, 20)
        Me.rdoPV.Name = "rdoPV"
        Me.rdoPV.Size = New System.Drawing.Size(39, 16)
        Me.rdoPV.TabIndex = 1
        Me.rdoPV.TabStop = True
        Me.rdoPV.Text = "PV"
        Me.rdoPV.UseVisualStyleBackColor = True
        '
        'rdoCV
        '
        Me.rdoCV.AutoSize = True
        Me.rdoCV.Location = New System.Drawing.Point(41, 20)
        Me.rdoCV.Name = "rdoCV"
        Me.rdoCV.Size = New System.Drawing.Size(40, 16)
        Me.rdoCV.TabIndex = 0
        Me.rdoCV.TabStop = True
        Me.rdoCV.Text = "CV"
        Me.rdoCV.UseVisualStyleBackColor = True
        '
        'cboControlLine
        '
        Me.cboControlLine.FormattingEnabled = True
        Me.cboControlLine.Items.AddRange(New Object() {"ELVDD", "ELVSS", "SubPower1", "SubPower2", "SubPower3", "SubPower4", "SubPower5", "SubPower6", "SubPower7", "SubPower8", "SubPower9", "SubPower10", "SubPower11", "SubPower12", "Signal1", "Signal2", "Signal3", "Signal4", "Signal5", "Signal6", "Signal7", "Signal8", "Signal9", "Signal10", "Signal11", "Signal12", "Signal13", "Signal14", "Signal15", "Signal16", "Signal17", "Signal18", "Signal19", "Signal20", "Signal21", "Signal22", "Signal23", "Signal24", "Signal25", "Signal26"})
        Me.cboControlLine.Location = New System.Drawing.Point(140, 15)
        Me.cboControlLine.Name = "cboControlLine"
        Me.cboControlLine.Size = New System.Drawing.Size(91, 20)
        Me.cboControlLine.TabIndex = 1
        Me.cboControlLine.Text = "ELVDD"
        '
        'gbImportExport
        '
        Me.gbImportExport.Controls.Add(Me.txtComments)
        Me.gbImportExport.Controls.Add(Me.lblComments)
        Me.gbImportExport.Controls.Add(Me.btnLoad)
        Me.gbImportExport.Controls.Add(Me.btnSave)
        Me.gbImportExport.Location = New System.Drawing.Point(17, 7)
        Me.gbImportExport.Name = "gbImportExport"
        Me.gbImportExport.Size = New System.Drawing.Size(248, 84)
        Me.gbImportExport.TabIndex = 6
        Me.gbImportExport.TabStop = False
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(92, 20)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(140, 21)
        Me.txtComments.TabIndex = 9
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(15, 24)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(71, 12)
        Me.lblComments.TabIndex = 8
        Me.lblComments.Text = "Comments "
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(107, 45)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(70, 33)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(31, 45)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 33)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ucDispDataGrid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1033, 551)
        Me.SplitContainer1.SplitterDistance = 736
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 7
        '
        'ucDispDataGrid
        '
        Me.ucDispDataGrid.AutoScroll = True
        Me.ucDispDataGrid.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucDispDataGrid.CellColor = Nothing
        Me.ucDispDataGrid.ColHeaderWidthRatio = "15,10,7,10,7,7,7,12,12,10"
        Me.ucDispDataGrid.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucDispDataGrid.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucDispDataGrid.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ucDispDataGrid.ContextMenuStrip = Me.ctxListMenu
        Me.ucDispDataGrid.ControllerHeaderText = New String() {"Control Line", "Mode ", "Bias", "Amplitude", "Delay", "Width", "Period", "Current Limit", "Temp Limit", "Average"}
        Me.ucDispDataGrid.EnableEvent = True
        Me.ucDispDataGrid.Location = New System.Drawing.Point(3, 3)
        Me.ucDispDataGrid.Name = "ucDispDataGrid"
        Me.ucDispDataGrid.RowHeaderSize = 30
        Me.ucDispDataGrid.RowHeaderVisible = True
        Me.ucDispDataGrid.RowLineNum = 0
        Me.ucDispDataGrid.Size = New System.Drawing.Size(719, 505)
        Me.ucDispDataGrid.TabIndex = 2
        Me.ucDispDataGrid.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucDispDataGrid.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
        '
        'ctxListMenu
        '
        Me.ctxListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelToolStripMenuItem, Me.ToolStripMenuItem1, Me.ClearToolStripMenuItem})
        Me.ctxListMenu.Name = "ctxListMenu"
        Me.ctxListMenu.Size = New System.Drawing.Size(102, 54)
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbControl)
        Me.SplitContainer2.Size = New System.Drawing.Size(294, 551)
        Me.SplitContainer2.SplitterDistance = 106
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPDAverage)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 390)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 38)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PD Measure Average"
        '
        'txtPDAverage
        '
        Me.txtPDAverage.Location = New System.Drawing.Point(79, 15)
        Me.txtPDAverage.Name = "txtPDAverage"
        Me.txtPDAverage.Size = New System.Drawing.Size(81, 21)
        Me.txtPDAverage.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Average :"
        '
        'ucDispSignalGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucDispSignalGenerator"
        Me.Size = New System.Drawing.Size(1039, 557)
        Me.gbControl.ResumeLayout(False)
        Me.gbControl.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbImportExport.ResumeLayout(False)
        Me.gbImportExport.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ctxListMenu.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblControlLine As System.Windows.Forms.Label
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Friend WithEvents cboControlLine As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPV As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCV As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtperiod As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents txtwidth As System.Windows.Forms.TextBox
    Friend WithEvents txtdelay As System.Windows.Forms.TextBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents tbAmplitude As System.Windows.Forms.TextBox
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents lblVlow As System.Windows.Forms.Label
    Friend WithEvents lblVhigh As System.Windows.Forms.Label
    Friend WithEvents ucDispDataGrid As ucDataGridView
    Friend WithEvents gbImportExport As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ctxListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbTempLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblTempLimit As System.Windows.Forms.Label
    Friend WithEvents tbAverage As System.Windows.Forms.TextBox
    Friend WithEvents lblAverage As System.Windows.Forms.Label
    Friend WithEvents tbCurrentLimit As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentLimit As System.Windows.Forms.Label
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPDAverage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_Amplitude As System.Windows.Forms.Label
    Friend WithEvents lbl_Bias As System.Windows.Forms.Label

End Class
