<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispPGImageSweep
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbMeasurementImage = New System.Windows.Forms.GroupBox()
        Me.menuSelectedImageControl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbBurnInImage = New System.Windows.Forms.GroupBox()
        Me.lblBurnInImageName = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BurnInImagePic = New System.Windows.Forms.PictureBox()
        Me.gbAgingImage = New System.Windows.Forms.GroupBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gbModel = New System.Windows.Forms.GroupBox()
        Me.tbInitial = New System.Windows.Forms.TextBox()
        Me.tbPattern = New System.Windows.Forms.TextBox()
        Me.cbSelModel = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbSettings = New System.Windows.Forms.GroupBox()
        Me.tbACFImage = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkDownloadModel = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDelaytime = New System.Windows.Forms.TextBox()
        Me.gbImagePreview = New System.Windows.Forms.GroupBox()
        Me.menuSelectImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.선택된이미지를측정이미지로설정ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.선택된이미지를Sweep이미지로설정ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.선택된이미지를AlignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ucMeasurementImageList = New M7000.ucDataGridView()
        Me.pnAgingImageList = New M7000.ucDataGridView()
        Me.tlpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbMeasurementImage.SuspendLayout()
        Me.menuSelectedImageControl.SuspendLayout()
        Me.gbBurnInImage.SuspendLayout()
        CType(Me.BurnInImagePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgingImage.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbModel.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        Me.menuSelectImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.92448!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.07552!))
        Me.tlpMain.Controls.Add(Me.Panel1, 1, 0)
        Me.tlpMain.Controls.Add(Me.SplitContainer3, 0, 0)
        Me.tlpMain.Location = New System.Drawing.Point(18, 23)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 1
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.77589!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 517.0!))
        Me.tlpMain.Size = New System.Drawing.Size(874, 517)
        Me.tlpMain.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(517, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(354, 511)
        Me.Panel1.TabIndex = 6
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 82)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbMeasurementImage)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbBurnInImage)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbAgingImage)
        Me.SplitContainer1.Size = New System.Drawing.Size(323, 429)
        Me.SplitContainer1.SplitterDistance = 168
        Me.SplitContainer1.TabIndex = 0
        '
        'gbMeasurementImage
        '
        Me.gbMeasurementImage.Controls.Add(Me.ucMeasurementImageList)
        Me.gbMeasurementImage.Location = New System.Drawing.Point(22, 7)
        Me.gbMeasurementImage.Name = "gbMeasurementImage"
        Me.gbMeasurementImage.Size = New System.Drawing.Size(244, 171)
        Me.gbMeasurementImage.TabIndex = 0
        Me.gbMeasurementImage.TabStop = False
        Me.gbMeasurementImage.Text = "Measurement Image"
        '
        'menuSelectedImageControl
        '
        Me.menuSelectedImageControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.UpToolStripMenuItem, Me.DownToolStripMenuItem})
        Me.menuSelectedImageControl.Name = "menuSelectedImageControl"
        Me.menuSelectedImageControl.Size = New System.Drawing.Size(109, 104)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(105, 6)
        Me.ToolStripMenuItem1.Visible = False
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(105, 6)
        Me.ToolStripMenuItem2.Visible = False
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        Me.UpToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.UpToolStripMenuItem.Text = "Up"
        Me.UpToolStripMenuItem.Visible = False
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        Me.DownToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.DownToolStripMenuItem.Text = "Down"
        Me.DownToolStripMenuItem.Visible = False
        '
        'gbBurnInImage
        '
        Me.gbBurnInImage.Controls.Add(Me.lblBurnInImageName)
        Me.gbBurnInImage.Controls.Add(Me.Label4)
        Me.gbBurnInImage.Controls.Add(Me.BurnInImagePic)
        Me.gbBurnInImage.Location = New System.Drawing.Point(22, 14)
        Me.gbBurnInImage.Name = "gbBurnInImage"
        Me.gbBurnInImage.Size = New System.Drawing.Size(223, 102)
        Me.gbBurnInImage.TabIndex = 2
        Me.gbBurnInImage.TabStop = False
        Me.gbBurnInImage.Text = "BurnIn Image"
        '
        'lblBurnInImageName
        '
        Me.lblBurnInImageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBurnInImageName.Location = New System.Drawing.Point(11, 35)
        Me.lblBurnInImageName.Name = "lblBurnInImageName"
        Me.lblBurnInImageName.Size = New System.Drawing.Size(200, 23)
        Me.lblBurnInImageName.TabIndex = 6
        Me.lblBurnInImageName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Image Name"
        '
        'BurnInImagePic
        '
        Me.BurnInImagePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BurnInImagePic.Location = New System.Drawing.Point(11, 61)
        Me.BurnInImagePic.Name = "BurnInImagePic"
        Me.BurnInImagePic.Size = New System.Drawing.Size(200, 82)
        Me.BurnInImagePic.TabIndex = 0
        Me.BurnInImagePic.TabStop = False
        '
        'gbAgingImage
        '
        Me.gbAgingImage.Controls.Add(Me.pnAgingImageList)
        Me.gbAgingImage.Location = New System.Drawing.Point(22, 138)
        Me.gbAgingImage.Name = "gbAgingImage"
        Me.gbAgingImage.Size = New System.Drawing.Size(223, 150)
        Me.gbAgingImage.TabIndex = 0
        Me.gbAgingImage.TabStop = False
        Me.gbAgingImage.Text = "Sweep Image List"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.gbImagePreview)
        Me.SplitContainer3.Size = New System.Drawing.Size(497, 486)
        Me.SplitContainer3.SplitterDistance = 120
        Me.SplitContainer3.TabIndex = 7
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbModel)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbSettings)
        Me.SplitContainer2.Size = New System.Drawing.Size(491, 109)
        Me.SplitContainer2.SplitterDistance = 353
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 5
        '
        'gbModel
        '
        Me.gbModel.Controls.Add(Me.tbInitial)
        Me.gbModel.Controls.Add(Me.tbPattern)
        Me.gbModel.Controls.Add(Me.cbSelModel)
        Me.gbModel.Controls.Add(Me.Label5)
        Me.gbModel.Controls.Add(Me.Label3)
        Me.gbModel.Controls.Add(Me.Label1)
        Me.gbModel.Location = New System.Drawing.Point(9, 4)
        Me.gbModel.Name = "gbModel"
        Me.gbModel.Size = New System.Drawing.Size(266, 97)
        Me.gbModel.TabIndex = 3
        Me.gbModel.TabStop = False
        Me.gbModel.Text = "Model"
        '
        'tbInitial
        '
        Me.tbInitial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInitial.Location = New System.Drawing.Point(68, 69)
        Me.tbInitial.Name = "tbInitial"
        Me.tbInitial.Size = New System.Drawing.Size(192, 21)
        Me.tbInitial.TabIndex = 7
        '
        'tbPattern
        '
        Me.tbPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPattern.Location = New System.Drawing.Point(67, 45)
        Me.tbPattern.Name = "tbPattern"
        Me.tbPattern.Size = New System.Drawing.Size(192, 21)
        Me.tbPattern.TabIndex = 6
        '
        'cbSelModel
        '
        Me.cbSelModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelModel.FormattingEnabled = True
        Me.cbSelModel.Location = New System.Drawing.Point(66, 17)
        Me.cbSelModel.Name = "cbSelModel"
        Me.cbSelModel.Size = New System.Drawing.Size(194, 20)
        Me.cbSelModel.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Initial :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Pattern :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Model :"
        '
        'gbSettings
        '
        Me.gbSettings.Controls.Add(Me.tbACFImage)
        Me.gbSettings.Controls.Add(Me.Label7)
        Me.gbSettings.Controls.Add(Me.chkDownloadModel)
        Me.gbSettings.Controls.Add(Me.Label6)
        Me.gbSettings.Controls.Add(Me.Label2)
        Me.gbSettings.Controls.Add(Me.txtDelaytime)
        Me.gbSettings.Location = New System.Drawing.Point(4, 5)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Size = New System.Drawing.Size(128, 96)
        Me.gbSettings.TabIndex = 0
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "Settings"
        '
        'tbACFImage
        '
        Me.tbACFImage.Location = New System.Drawing.Point(81, 39)
        Me.tbACFImage.Name = "tbACFImage"
        Me.tbACFImage.Size = New System.Drawing.Size(40, 21)
        Me.tbACFImage.TabIndex = 7
        Me.tbACFImage.Text = "3"
        Me.tbACFImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Centering :"
        '
        'chkDownloadModel
        '
        Me.chkDownloadModel.AutoSize = True
        Me.chkDownloadModel.Location = New System.Drawing.Point(9, 19)
        Me.chkDownloadModel.Name = "chkDownloadModel"
        Me.chkDownloadModel.Size = New System.Drawing.Size(119, 16)
        Me.chkDownloadModel.TabIndex = 5
        Me.chkDownloadModel.Text = "Download Model"
        Me.chkDownloadModel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Delay"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Sec"
        '
        'txtDelaytime
        '
        Me.txtDelaytime.Location = New System.Drawing.Point(49, 70)
        Me.txtDelaytime.Name = "txtDelaytime"
        Me.txtDelaytime.Size = New System.Drawing.Size(41, 21)
        Me.txtDelaytime.TabIndex = 0
        Me.txtDelaytime.Text = "3"
        Me.txtDelaytime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbImagePreview
        '
        Me.gbImagePreview.Location = New System.Drawing.Point(27, 25)
        Me.gbImagePreview.Name = "gbImagePreview"
        Me.gbImagePreview.Size = New System.Drawing.Size(385, 294)
        Me.gbImagePreview.TabIndex = 0
        Me.gbImagePreview.TabStop = False
        Me.gbImagePreview.Text = "Image Preview"
        '
        'menuSelectImage
        '
        Me.menuSelectImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.선택된이미지를측정이미지로설정ToolStripMenuItem, Me.선택된이미지를Sweep이미지로설정ToolStripMenuItem, Me.선택된이미지를AlignToolStripMenuItem})
        Me.menuSelectImage.Name = "menuSelectImage"
        Me.menuSelectImage.Size = New System.Drawing.Size(354, 70)
        '
        '선택된이미지를측정이미지로설정ToolStripMenuItem
        '
        Me.선택된이미지를측정이미지로설정ToolStripMenuItem.Name = "선택된이미지를측정이미지로설정ToolStripMenuItem"
        Me.선택된이미지를측정이미지로설정ToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.선택된이미지를측정이미지로설정ToolStripMenuItem.Text = "선택된 이미지를 측정 이미지로 설정"
        '
        '선택된이미지를Sweep이미지로설정ToolStripMenuItem
        '
        Me.선택된이미지를Sweep이미지로설정ToolStripMenuItem.Name = "선택된이미지를Sweep이미지로설정ToolStripMenuItem"
        Me.선택된이미지를Sweep이미지로설정ToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.선택된이미지를Sweep이미지로설정ToolStripMenuItem.Text = "선택된 이미지를 Image List에 등록"
        '
        '선택된이미지를AlignToolStripMenuItem
        '
        Me.선택된이미지를AlignToolStripMenuItem.Name = "선택된이미지를AlignToolStripMenuItem"
        Me.선택된이미지를AlignToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.선택된이미지를AlignToolStripMenuItem.Text = "선택된 이미지를 AC(Auto Centering) Image 로 설정"
        '
        'ucMeasurementImageList
        '
        Me.ucMeasurementImageList.AutoScroll = True
        Me.ucMeasurementImageList.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucMeasurementImageList.CellColor = Nothing
        Me.ucMeasurementImageList.ColHeaderWidthRatio = "80,20"
        Me.ucMeasurementImageList.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucMeasurementImageList.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucMeasurementImageList.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        Me.ucMeasurementImageList.ContextMenuStrip = Me.menuSelectedImageControl
        Me.ucMeasurementImageList.ControllerHeaderText = New String() {"Image Name", "Delay"}
        Me.ucMeasurementImageList.Location = New System.Drawing.Point(11, 20)
        Me.ucMeasurementImageList.Name = "ucMeasurementImageList"
        Me.ucMeasurementImageList.RowHeaderSize = 4
        Me.ucMeasurementImageList.RowHeaderVisible = True
        Me.ucMeasurementImageList.RowLineNum = 0
        Me.ucMeasurementImageList.Size = New System.Drawing.Size(217, 132)
        Me.ucMeasurementImageList.TabIndex = 1
        Me.ucMeasurementImageList.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucMeasurementImageList.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
        '
        'pnAgingImageList
        '
        Me.pnAgingImageList.AutoScroll = True
        Me.pnAgingImageList.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pnAgingImageList.CellColor = Nothing
        Me.pnAgingImageList.ColHeaderWidthRatio = "80,50"
        Me.pnAgingImageList.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.pnAgingImageList.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pnAgingImageList.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        Me.pnAgingImageList.ContextMenuStrip = Me.menuSelectedImageControl
        Me.pnAgingImageList.ControllerHeaderText = New String() {"Image Name", "Delay"}
        Me.pnAgingImageList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnAgingImageList.Location = New System.Drawing.Point(15, 20)
        Me.pnAgingImageList.Name = "pnAgingImageList"
        Me.pnAgingImageList.RowHeaderSize = 4
        Me.pnAgingImageList.RowHeaderVisible = True
        Me.pnAgingImageList.RowLineNum = 0
        Me.pnAgingImageList.Size = New System.Drawing.Size(196, 109)
        Me.pnAgingImageList.TabIndex = 3
        Me.pnAgingImageList.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pnAgingImageList.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
        '
        'ucDispPGImageSweep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispPGImageSweep"
        Me.Size = New System.Drawing.Size(1257, 555)
        Me.tlpMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbMeasurementImage.ResumeLayout(False)
        Me.menuSelectedImageControl.ResumeLayout(False)
        Me.gbBurnInImage.ResumeLayout(False)
        Me.gbBurnInImage.PerformLayout()
        CType(Me.BurnInImagePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgingImage.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbModel.ResumeLayout(False)
        Me.gbModel.PerformLayout()
        Me.gbSettings.ResumeLayout(False)
        Me.gbSettings.PerformLayout()
        Me.menuSelectImage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents menuSelectImage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 선택된이미지를Sweep이미지로설정ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 선택된이미지를측정이미지로설정ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbMeasurementImage As System.Windows.Forms.GroupBox
    Friend WithEvents gbAgingImage As System.Windows.Forms.GroupBox
    Friend WithEvents menuSelectedImageControl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtDelaytime As System.Windows.Forms.TextBox
    Friend WithEvents pnAgingImageList As ucDataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbImagePreview As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbBurnInImage As System.Windows.Forms.GroupBox
    Friend WithEvents lblBurnInImageName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BurnInImagePic As System.Windows.Forms.PictureBox
    Friend WithEvents ucMeasurementImageList As M7000.ucDataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbModel As System.Windows.Forms.GroupBox
    Friend WithEvents tbInitial As System.Windows.Forms.TextBox
    Friend WithEvents tbPattern As System.Windows.Forms.TextBox
    Friend WithEvents cbSelModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDownloadModel As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbACFImage As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 선택된이미지를AlignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
