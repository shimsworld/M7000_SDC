<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSequenceBuilder
    Inherits System.Windows.Forms.UserControl

    'UserControl1은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucSequenceBuilder))
        Me.gbSequeceManager = New System.Windows.Forms.GroupBox()
        Me.gbSequenceEditor = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gbSeqEditCommon = New System.Windows.Forms.GroupBox()
        Me.btnFindSavePath = New System.Windows.Forms.Button()
        Me.tbSavePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.tlpSequenceList = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.spContainerEditor = New System.Windows.Forms.SplitContainer()
        Me.tlpSequenceEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpSequenceEditorButton = New System.Windows.Forms.TableLayoutPanel()
        Me.spcSequenceEditor = New System.Windows.Forms.SplitContainer()
        Me.tlpRcpEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpRcpMode = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnSettings = New System.Windows.Forms.Panel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BuilderMenu = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDeleteSeqFile = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.rdoAging = New System.Windows.Forms.RadioButton()
        Me.rdoImageSticking = New System.Windows.Forms.RadioButton()
        Me.rdoLifetimeAndIVL = New System.Windows.Forms.RadioButton()
        Me.rdoRGBWAging = New System.Windows.Forms.RadioButton()
        Me.rdoGrayScaleSweep = New System.Windows.Forms.RadioButton()
        Me.rdoLifetime = New System.Windows.Forms.RadioButton()
        Me.rdoIVL = New System.Windows.Forms.RadioButton()
        Me.rdoChangeTemp = New System.Windows.Forms.RadioButton()
        Me.rdoImageSweep = New System.Windows.Forms.RadioButton()
        Me.rdoViewingAngle = New System.Windows.Forms.RadioButton()
        Me.gbSeqEditCommon.SuspendLayout()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.tlpSequenceList.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.spContainerEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainerEditor.Panel1.SuspendLayout()
        Me.spContainerEditor.Panel2.SuspendLayout()
        Me.spContainerEditor.SuspendLayout()
        Me.tlpSequenceEditor.SuspendLayout()
        Me.tlpSequenceEditorButton.SuspendLayout()
        CType(Me.spcSequenceEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcSequenceEditor.Panel1.SuspendLayout()
        Me.spcSequenceEditor.SuspendLayout()
        Me.tlpRcpEditor.SuspendLayout()
        Me.tlpRcpMode.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.BuilderMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSequeceManager
        '
        Me.gbSequeceManager.Location = New System.Drawing.Point(3, 40)
        Me.gbSequeceManager.Name = "gbSequeceManager"
        Me.gbSequeceManager.Size = New System.Drawing.Size(326, 484)
        Me.gbSequeceManager.TabIndex = 5
        Me.gbSequeceManager.TabStop = False
        Me.gbSequeceManager.Text = "Sequence List"
        '
        'gbSequenceEditor
        '
        Me.gbSequenceEditor.Location = New System.Drawing.Point(3, 3)
        Me.gbSequenceEditor.Name = "gbSequenceEditor"
        Me.gbSequenceEditor.Size = New System.Drawing.Size(319, 149)
        Me.gbSequenceEditor.TabIndex = 11
        Me.gbSequenceEditor.TabStop = False
        Me.gbSequenceEditor.Text = "Sequence Edit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 17)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'gbSeqEditCommon
        '
        Me.gbSeqEditCommon.Controls.Add(Me.btnFindSavePath)
        Me.gbSeqEditCommon.Controls.Add(Me.tbSavePath)
        Me.gbSeqEditCommon.Controls.Add(Me.Label1)
        Me.gbSeqEditCommon.Location = New System.Drawing.Point(6, 471)
        Me.gbSeqEditCommon.Name = "gbSeqEditCommon"
        Me.gbSeqEditCommon.Size = New System.Drawing.Size(702, 152)
        Me.gbSeqEditCommon.TabIndex = 11
        Me.gbSeqEditCommon.TabStop = False
        Me.gbSeqEditCommon.Text = "Common Settings"
        '
        'btnFindSavePath
        '
        Me.btnFindSavePath.Location = New System.Drawing.Point(607, 22)
        Me.btnFindSavePath.Name = "btnFindSavePath"
        Me.btnFindSavePath.Size = New System.Drawing.Size(80, 25)
        Me.btnFindSavePath.TabIndex = 2
        Me.btnFindSavePath.Text = "Find..."
        Me.btnFindSavePath.UseVisualStyleBackColor = True
        '
        'tbSavePath
        '
        Me.tbSavePath.Location = New System.Drawing.Point(91, 24)
        Me.tbSavePath.Name = "tbSavePath"
        Me.tbSavePath.Size = New System.Drawing.Size(509, 21)
        Me.tbSavePath.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Save Path :"
        '
        'spContainer
        '
        Me.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spContainer.Location = New System.Drawing.Point(15, 20)
        Me.spContainer.Name = "spContainer"
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.Controls.Add(Me.tlpSequenceList)
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.spContainerEditor)
        Me.spContainer.Size = New System.Drawing.Size(1447, 595)
        Me.spContainer.SplitterDistance = 363
        Me.spContainer.SplitterWidth = 2
        Me.spContainer.TabIndex = 4
        '
        'tlpSequenceList
        '
        Me.tlpSequenceList.AutoScroll = True
        Me.tlpSequenceList.ColumnCount = 1
        Me.tlpSequenceList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSequenceList.Controls.Add(Me.gbSequeceManager, 0, 1)
        Me.tlpSequenceList.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.tlpSequenceList.Location = New System.Drawing.Point(3, 7)
        Me.tlpSequenceList.Name = "tlpSequenceList"
        Me.tlpSequenceList.RowCount = 2
        Me.tlpSequenceList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.468532!))
        Me.tlpSequenceList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.53147!))
        Me.tlpSequenceList.Size = New System.Drawing.Size(342, 572)
        Me.tlpSequenceList.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnNew, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnDeleteSeqFile, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnImport, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnExport, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(336, 31)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'spContainerEditor
        '
        Me.spContainerEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spContainerEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spContainerEditor.Location = New System.Drawing.Point(0, 0)
        Me.spContainerEditor.MinimumSize = New System.Drawing.Size(770, 0)
        Me.spContainerEditor.Name = "spContainerEditor"
        '
        'spContainerEditor.Panel1
        '
        Me.spContainerEditor.Panel1.AutoScroll = True
        Me.spContainerEditor.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.spContainerEditor.Panel1.Controls.Add(Me.tlpSequenceEditor)
        '
        'spContainerEditor.Panel2
        '
        Me.spContainerEditor.Panel2.AutoScroll = True
        Me.spContainerEditor.Panel2.Controls.Add(Me.tlpRcpEditor)
        Me.spContainerEditor.Size = New System.Drawing.Size(1082, 595)
        Me.spContainerEditor.SplitterDistance = 466
        Me.spContainerEditor.SplitterWidth = 3
        Me.spContainerEditor.TabIndex = 0
        '
        'tlpSequenceEditor
        '
        Me.tlpSequenceEditor.ColumnCount = 1
        Me.tlpSequenceEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSequenceEditor.Controls.Add(Me.tlpSequenceEditorButton, 0, 0)
        Me.tlpSequenceEditor.Controls.Add(Me.spcSequenceEditor, 0, 1)
        Me.tlpSequenceEditor.Location = New System.Drawing.Point(3, 7)
        Me.tlpSequenceEditor.Name = "tlpSequenceEditor"
        Me.tlpSequenceEditor.RowCount = 2
        Me.tlpSequenceEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.396588!))
        Me.tlpSequenceEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.60341!))
        Me.tlpSequenceEditor.Size = New System.Drawing.Size(421, 469)
        Me.tlpSequenceEditor.TabIndex = 11
        '
        'tlpSequenceEditorButton
        '
        Me.tlpSequenceEditorButton.ColumnCount = 7
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpSequenceEditorButton.Controls.Add(Me.btnSave, 0, 0)
        Me.tlpSequenceEditorButton.Controls.Add(Me.btnUp, 1, 0)
        Me.tlpSequenceEditorButton.Controls.Add(Me.btnClear, 4, 0)
        Me.tlpSequenceEditorButton.Controls.Add(Me.btnDown, 2, 0)
        Me.tlpSequenceEditorButton.Controls.Add(Me.btnDelete, 3, 0)
        Me.tlpSequenceEditorButton.Location = New System.Drawing.Point(3, 3)
        Me.tlpSequenceEditorButton.Name = "tlpSequenceEditorButton"
        Me.tlpSequenceEditorButton.RowCount = 1
        Me.tlpSequenceEditorButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSequenceEditorButton.Size = New System.Drawing.Size(385, 23)
        Me.tlpSequenceEditorButton.TabIndex = 0
        '
        'spcSequenceEditor
        '
        Me.spcSequenceEditor.Location = New System.Drawing.Point(3, 32)
        Me.spcSequenceEditor.Name = "spcSequenceEditor"
        Me.spcSequenceEditor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcSequenceEditor.Panel1
        '
        Me.spcSequenceEditor.Panel1.AutoScroll = True
        Me.spcSequenceEditor.Panel1.Controls.Add(Me.gbSequenceEditor)
        '
        'spcSequenceEditor.Panel2
        '
        Me.spcSequenceEditor.Size = New System.Drawing.Size(340, 397)
        Me.spcSequenceEditor.SplitterDistance = 212
        Me.spcSequenceEditor.TabIndex = 1
        '
        'tlpRcpEditor
        '
        Me.tlpRcpEditor.ColumnCount = 1
        Me.tlpRcpEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRcpEditor.Controls.Add(Me.tlpRcpMode, 0, 0)
        Me.tlpRcpEditor.Controls.Add(Me.pnSettings, 0, 1)
        Me.tlpRcpEditor.Location = New System.Drawing.Point(34, 10)
        Me.tlpRcpEditor.Name = "tlpRcpEditor"
        Me.tlpRcpEditor.RowCount = 2
        Me.tlpRcpEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.928572!))
        Me.tlpRcpEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.07143!))
        Me.tlpRcpEditor.Size = New System.Drawing.Size(465, 504)
        Me.tlpRcpEditor.TabIndex = 0
        '
        'tlpRcpMode
        '
        Me.tlpRcpMode.ColumnCount = 9
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25933!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25933!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25933!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25933!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25933!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.92477!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.92477!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.92477!))
        Me.tlpRcpMode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.92901!))
        Me.tlpRcpMode.Controls.Add(Me.rdoAging, 4, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoImageSticking, 7, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoLifetimeAndIVL, 3, 0)
        Me.tlpRcpMode.Controls.Add(Me.SplitContainer1, 6, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoLifetime, 1, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoIVL, 0, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoChangeTemp, 2, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoImageSweep, 8, 0)
        Me.tlpRcpMode.Controls.Add(Me.rdoViewingAngle, 5, 0)
        Me.tlpRcpMode.Location = New System.Drawing.Point(3, 3)
        Me.tlpRcpMode.Name = "tlpRcpMode"
        Me.tlpRcpMode.RowCount = 1
        Me.tlpRcpMode.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRcpMode.Size = New System.Drawing.Size(452, 39)
        Me.tlpRcpMode.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(302, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdoRGBWAging)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rdoGrayScaleSweep)
        Me.SplitContainer1.Size = New System.Drawing.Size(43, 33)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 1
        '
        'pnSettings
        '
        Me.pnSettings.AutoScroll = True
        Me.pnSettings.Location = New System.Drawing.Point(3, 48)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(396, 398)
        Me.pnSettings.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BuilderMenu
        '
        Me.BuilderMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.BuilderMenu.Location = New System.Drawing.Point(0, 0)
        Me.BuilderMenu.Name = "BuilderMenu"
        Me.BuilderMenu.Size = New System.Drawing.Size(1550, 24)
        Me.BuilderMenu.TabIndex = 5
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'btnNew
        '
        Me.btnNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Image = Global.M7000.My.Resources.Resources.new_
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(3, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(78, 25)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "New"
        Me.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDeleteSeqFile
        '
        Me.btnDeleteSeqFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeleteSeqFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSeqFile.Image = Global.M7000.My.Resources.Resources.delete
        Me.btnDeleteSeqFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteSeqFile.Location = New System.Drawing.Point(255, 3)
        Me.btnDeleteSeqFile.Name = "btnDeleteSeqFile"
        Me.btnDeleteSeqFile.Size = New System.Drawing.Size(78, 25)
        Me.btnDeleteSeqFile.TabIndex = 4
        Me.btnDeleteSeqFile.Text = "Delete"
        Me.btnDeleteSeqFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteSeqFile.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Image = Global.M7000.My.Resources.Resources.import
        Me.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImport.Location = New System.Drawing.Point(87, 3)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(78, 25)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "Import"
        Me.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Image = Global.M7000.My.Resources.Resources.export
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(171, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(78, 25)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp.Image = Global.M7000.My.Resources.Resources.up
        Me.btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUp.Location = New System.Drawing.Point(57, 3)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(48, 17)
        Me.btnUp.TabIndex = 7
        Me.btnUp.Text = "Up"
        Me.btnUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        'Me.btnClear.Image = Global.M7000.My.Resources.Resources.clear
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(219, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(48, 17)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.Image = Global.M7000.My.Resources.Resources.down
        Me.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDown.Location = New System.Drawing.Point(111, 3)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(48, 17)
        Me.btnDown.TabIndex = 8
        Me.btnDown.Text = "Down"
        Me.btnDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Image = Global.M7000.My.Resources.Resources.delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(165, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 17)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'rdoAging
        '
        Me.rdoAging.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoAging.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoAging.Image = CType(resources.GetObject("rdoAging.Image"), System.Drawing.Image)
        Me.rdoAging.Location = New System.Drawing.Point(203, 3)
        Me.rdoAging.Name = "rdoAging"
        Me.rdoAging.Size = New System.Drawing.Size(44, 33)
        Me.rdoAging.TabIndex = 19
        Me.rdoAging.TabStop = True
        Me.rdoAging.Text = "Aging"
        Me.rdoAging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoAging.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoAging.UseVisualStyleBackColor = True
        '
        'rdoImageSticking
        '
        Me.rdoImageSticking.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoImageSticking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoImageSticking.Image = Global.M7000.My.Resources.Resources.pattern
        Me.rdoImageSticking.Location = New System.Drawing.Point(351, 3)
        Me.rdoImageSticking.Name = "rdoImageSticking"
        Me.rdoImageSticking.Size = New System.Drawing.Size(43, 29)
        Me.rdoImageSticking.TabIndex = 18
        Me.rdoImageSticking.TabStop = True
        Me.rdoImageSticking.Text = "Image Sticking"
        Me.rdoImageSticking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoImageSticking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoImageSticking.UseVisualStyleBackColor = True
        '
        'rdoLifetimeAndIVL
        '
        Me.rdoLifetimeAndIVL.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoLifetimeAndIVL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoLifetimeAndIVL.Image = Global.M7000.My.Resources.Resources.lifetime
        Me.rdoLifetimeAndIVL.Location = New System.Drawing.Point(153, 3)
        Me.rdoLifetimeAndIVL.Name = "rdoLifetimeAndIVL"
        Me.rdoLifetimeAndIVL.Size = New System.Drawing.Size(44, 33)
        Me.rdoLifetimeAndIVL.TabIndex = 14
        Me.rdoLifetimeAndIVL.TabStop = True
        Me.rdoLifetimeAndIVL.Text = "Lifetime + IVL"
        Me.rdoLifetimeAndIVL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoLifetimeAndIVL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoLifetimeAndIVL.UseVisualStyleBackColor = True
        '
        'rdoRGBWAging
        '
        Me.rdoRGBWAging.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoRGBWAging.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoRGBWAging.Image = Global.M7000.My.Resources.Resources.rgbw
        Me.rdoRGBWAging.Location = New System.Drawing.Point(1, 0)
        Me.rdoRGBWAging.Name = "rdoRGBWAging"
        Me.rdoRGBWAging.Size = New System.Drawing.Size(43, 33)
        Me.rdoRGBWAging.TabIndex = 17
        Me.rdoRGBWAging.TabStop = True
        Me.rdoRGBWAging.Text = "RGBWAging"
        Me.rdoRGBWAging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoRGBWAging.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoRGBWAging.UseVisualStyleBackColor = True
        '
        'rdoGrayScaleSweep
        '
        Me.rdoGrayScaleSweep.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoGrayScaleSweep.Image = Global.M7000.My.Resources.Resources.gray
        Me.rdoGrayScaleSweep.Location = New System.Drawing.Point(18, 3)
        Me.rdoGrayScaleSweep.Name = "rdoGrayScaleSweep"
        Me.rdoGrayScaleSweep.Size = New System.Drawing.Size(44, 29)
        Me.rdoGrayScaleSweep.TabIndex = 19
        Me.rdoGrayScaleSweep.TabStop = True
        Me.rdoGrayScaleSweep.Text = "Gray Scale Sweep"
        Me.rdoGrayScaleSweep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoGrayScaleSweep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoGrayScaleSweep.UseVisualStyleBackColor = True
        '
        'rdoLifetime
        '
        Me.rdoLifetime.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoLifetime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoLifetime.Image = Global.M7000.My.Resources.Resources.lifetime
        Me.rdoLifetime.Location = New System.Drawing.Point(53, 3)
        Me.rdoLifetime.Name = "rdoLifetime"
        Me.rdoLifetime.Size = New System.Drawing.Size(44, 33)
        Me.rdoLifetime.TabIndex = 13
        Me.rdoLifetime.TabStop = True
        Me.rdoLifetime.Text = "Lifetime"
        Me.rdoLifetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoLifetime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoLifetime.UseVisualStyleBackColor = True
        '
        'rdoIVL
        '
        Me.rdoIVL.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoIVL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoIVL.Image = Global.M7000.My.Resources.Resources.ivl
        Me.rdoIVL.Location = New System.Drawing.Point(3, 3)
        Me.rdoIVL.Name = "rdoIVL"
        Me.rdoIVL.Size = New System.Drawing.Size(44, 33)
        Me.rdoIVL.TabIndex = 12
        Me.rdoIVL.TabStop = True
        Me.rdoIVL.Text = "IVL Sweep"
        Me.rdoIVL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoIVL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoIVL.UseVisualStyleBackColor = True
        '
        'rdoChangeTemp
        '
        Me.rdoChangeTemp.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoChangeTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoChangeTemp.Image = Global.M7000.My.Resources.Resources.temp
        Me.rdoChangeTemp.Location = New System.Drawing.Point(103, 3)
        Me.rdoChangeTemp.Name = "rdoChangeTemp"
        Me.rdoChangeTemp.Size = New System.Drawing.Size(44, 33)
        Me.rdoChangeTemp.TabIndex = 14
        Me.rdoChangeTemp.TabStop = True
        Me.rdoChangeTemp.Text = "Temp"
        Me.rdoChangeTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoChangeTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoChangeTemp.UseVisualStyleBackColor = True
        '
        'rdoImageSweep
        '
        Me.rdoImageSweep.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoImageSweep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoImageSweep.Image = Global.M7000.My.Resources.Resources.image_sweep
        Me.rdoImageSweep.Location = New System.Drawing.Point(400, 3)
        Me.rdoImageSweep.Name = "rdoImageSweep"
        Me.rdoImageSweep.Size = New System.Drawing.Size(48, 33)
        Me.rdoImageSweep.TabIndex = 16
        Me.rdoImageSweep.TabStop = True
        Me.rdoImageSweep.Text = "Image Sweep"
        Me.rdoImageSweep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoImageSweep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoImageSweep.UseVisualStyleBackColor = True
        '
        'rdoViewingAngle
        '
        Me.rdoViewingAngle.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoViewingAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoViewingAngle.Image = Global.M7000.My.Resources.Resources.angle
        Me.rdoViewingAngle.Location = New System.Drawing.Point(253, 3)
        Me.rdoViewingAngle.Name = "rdoViewingAngle"
        Me.rdoViewingAngle.Size = New System.Drawing.Size(43, 33)
        Me.rdoViewingAngle.TabIndex = 15
        Me.rdoViewingAngle.TabStop = True
        Me.rdoViewingAngle.Text = "Viewing Angle"
        Me.rdoViewingAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoViewingAngle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdoViewingAngle.UseVisualStyleBackColor = True
        '
        'ucSequenceBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spContainer)
        Me.Controls.Add(Me.BuilderMenu)
        Me.DoubleBuffered = True
        Me.Name = "ucSequenceBuilder"
        Me.Size = New System.Drawing.Size(1550, 651)
        Me.gbSeqEditCommon.ResumeLayout(False)
        Me.gbSeqEditCommon.PerformLayout()
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.tlpSequenceList.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.spContainerEditor.Panel1.ResumeLayout(False)
        Me.spContainerEditor.Panel2.ResumeLayout(False)
        CType(Me.spContainerEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainerEditor.ResumeLayout(False)
        Me.tlpSequenceEditor.ResumeLayout(False)
        Me.tlpSequenceEditorButton.ResumeLayout(False)
        Me.spcSequenceEditor.Panel1.ResumeLayout(False)
        CType(Me.spcSequenceEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcSequenceEditor.ResumeLayout(False)
        Me.tlpRcpEditor.ResumeLayout(False)
        Me.tlpRcpMode.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.BuilderMenu.ResumeLayout(False)
        Me.BuilderMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbSequeceManager As System.Windows.Forms.GroupBox
    Friend WithEvents gbSequenceEditor As System.Windows.Forms.GroupBox
    'Friend WithEvents UcDataGridView1 As SequenceBuilder.ucDataGridView
    Friend WithEvents gbSeqEditCommon As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSavePath As System.Windows.Forms.TextBox
    Friend WithEvents btnFindSavePath As System.Windows.Forms.Button
    Friend WithEvents ucListSeqManager As ucDispListView
    Friend WithEvents btnDeleteSeqFile As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ucDataGridSeqEditor As ucDataGridView
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents spContainerEditor As System.Windows.Forms.SplitContainer
    Friend WithEvents ucDispCommon As ucDispRcpCommon
    Friend WithEvents tlpRcpEditor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdoGrayScaleSweep As System.Windows.Forms.RadioButton
    Friend WithEvents rdoChangeTemp As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLifetime As System.Windows.Forms.RadioButton
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents rdoIVL As System.Windows.Forms.RadioButton
    Friend WithEvents ucDispLifetime As ucDispRcpLifetime
    Friend WithEvents tlpRcpMode As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdoImageSweep As System.Windows.Forms.RadioButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents rdoImageSticking As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRGBWAging As System.Windows.Forms.RadioButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BuilderMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rdoViewingAngle As System.Windows.Forms.RadioButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tlpSequenceEditor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpSequenceEditorButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents spcSequenceEditor As System.Windows.Forms.SplitContainer
    Friend WithEvents tlpSequenceList As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdoLifetimeAndIVL As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAging As System.Windows.Forms.RadioButton

End Class
