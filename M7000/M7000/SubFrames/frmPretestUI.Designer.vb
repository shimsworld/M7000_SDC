<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPretestUI
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Dim TreeListColumn3 As CommonTools.TreeListColumn = New CommonTools.TreeListColumn("fieldname0", "Attributes")
        Dim TreeListColumn4 As CommonTools.TreeListColumn = New CommonTools.TreeListColumn("fieldname1", "Values")
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.lblQueueCount = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblMeasStatus = New System.Windows.Forms.Label()
        Me.btnSourceControl = New System.Windows.Forms.Button()
        Me.sequenceTreeView = New CommonTools.TreeListView()
        Me.lbSequenceName = New System.Windows.Forms.Label()
        Me.Leble2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gbMeasuredData = New System.Windows.Forms.GroupBox()
        Me.ucDispListDatas = New M7000.ucDispListView()
        Me.dispIVLGraph = New M7000.ucDispGraph()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        Me.gbControl.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        CType(Me.sequenceTreeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbMeasuredData.SuspendLayout()
        Me.SuspendLayout()
        '
        'spMain
        '
        Me.spMain.Location = New System.Drawing.Point(12, 12)
        Me.spMain.Name = "spMain"
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.gbControl)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.SplitContainer2)
        Me.spMain.Size = New System.Drawing.Size(1135, 590)
        Me.spMain.SplitterDistance = 351
        Me.spMain.TabIndex = 12
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.gbStatus)
        Me.gbControl.Controls.Add(Me.btnSourceControl)
        Me.gbControl.Controls.Add(Me.sequenceTreeView)
        Me.gbControl.Controls.Add(Me.lbSequenceName)
        Me.gbControl.Controls.Add(Me.Leble2)
        Me.gbControl.Controls.Add(Me.Label1)
        Me.gbControl.Controls.Add(Me.btnStop)
        Me.gbControl.Controls.Add(Me.cbChannel)
        Me.gbControl.Controls.Add(Me.btnLoad)
        Me.gbControl.Controls.Add(Me.btnNew)
        Me.gbControl.Controls.Add(Me.btnRun)
        Me.gbControl.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbControl.Location = New System.Drawing.Point(21, 15)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(323, 511)
        Me.gbControl.TabIndex = 2
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "Test Setting"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.lblQueueCount)
        Me.gbStatus.Controls.Add(Me.lblTemperature)
        Me.gbStatus.Controls.Add(Me.lblMeasStatus)
        Me.gbStatus.Location = New System.Drawing.Point(273, 18)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(280, 117)
        Me.gbStatus.TabIndex = 28
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Status"
        '
        'lblQueueCount
        '
        Me.lblQueueCount.AutoSize = True
        Me.lblQueueCount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueCount.Location = New System.Drawing.Point(6, 49)
        Me.lblQueueCount.Name = "lblQueueCount"
        Me.lblQueueCount.Size = New System.Drawing.Size(56, 19)
        Me.lblQueueCount.TabIndex = 27
        Me.lblQueueCount.Text = "Count"
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperature.Location = New System.Drawing.Point(6, 19)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(106, 19)
        Me.lblTemperature.TabIndex = 26
        Me.lblTemperature.Text = "Temperature"
        '
        'lblMeasStatus
        '
        Me.lblMeasStatus.AutoSize = True
        Me.lblMeasStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblMeasStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasStatus.Location = New System.Drawing.Point(6, 72)
        Me.lblMeasStatus.Name = "lblMeasStatus"
        Me.lblMeasStatus.Size = New System.Drawing.Size(87, 22)
        Me.lblMeasStatus.TabIndex = 25
        Me.lblMeasStatus.Text = "Standby"
        Me.lblMeasStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSourceControl
        '
        Me.btnSourceControl.Location = New System.Drawing.Point(8, 92)
        Me.btnSourceControl.Name = "btnSourceControl"
        Me.btnSourceControl.Size = New System.Drawing.Size(255, 42)
        Me.btnSourceControl.TabIndex = 24
        Me.btnSourceControl.Text = "Single Point Measurement"
        Me.btnSourceControl.UseVisualStyleBackColor = True
        '
        'sequenceTreeView
        '
        Me.sequenceTreeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TreeListColumn3.AutoSize = True
        TreeListColumn3.AutoSizeMinSize = 0
        TreeListColumn3.AutoSizeRatio = 50.0!
        TreeListColumn3.Width = 100
        TreeListColumn4.AutoSize = True
        TreeListColumn4.AutoSizeMinSize = 0
        TreeListColumn4.AutoSizeRatio = 50.0!
        TreeListColumn4.Width = 50
        Me.sequenceTreeView.Columns.AddRange(New CommonTools.TreeListColumn() {TreeListColumn3, TreeListColumn4})
        Me.sequenceTreeView.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.sequenceTreeView.Images = Nothing
        Me.sequenceTreeView.Location = New System.Drawing.Point(6, 157)
        Me.sequenceTreeView.MultiSelect = False
        Me.sequenceTreeView.Name = "sequenceTreeView"
        Me.sequenceTreeView.RowOptions.ShowHeader = False
        Me.sequenceTreeView.Size = New System.Drawing.Size(311, 348)
        Me.sequenceTreeView.TabIndex = 3
        Me.sequenceTreeView.Text = "TreeListView1"
        Me.sequenceTreeView.ViewOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        '
        'lbSequenceName
        '
        Me.lbSequenceName.AutoSize = True
        Me.lbSequenceName.Location = New System.Drawing.Point(173, 157)
        Me.lbSequenceName.Name = "lbSequenceName"
        Me.lbSequenceName.Size = New System.Drawing.Size(0, 12)
        Me.lbSequenceName.TabIndex = 23
        '
        'Leble2
        '
        Me.Leble2.AutoSize = True
        Me.Leble2.Location = New System.Drawing.Point(6, 142)
        Me.Leble2.Name = "Leble2"
        Me.Leble2.Size = New System.Drawing.Size(123, 12)
        Me.Leble2.TabIndex = 21
        Me.Leble2.Text = "SequenceName : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Target Channel : "
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(203, 47)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(60, 42)
        Me.btnStop.TabIndex = 20
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(142, 19)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(121, 20)
        Me.cbChannel.TabIndex = 16
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(71, 47)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(60, 42)
        Me.btnLoad.TabIndex = 19
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnNew.Location = New System.Drawing.Point(8, 47)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 42)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(137, 47)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(60, 42)
        Me.btnRun.TabIndex = 18
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbMeasuredData)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dispIVLGraph)
        Me.SplitContainer2.Size = New System.Drawing.Size(780, 590)
        Me.SplitContainer2.SplitterDistance = 272
        Me.SplitContainer2.TabIndex = 0
        '
        'gbMeasuredData
        '
        Me.gbMeasuredData.Controls.Add(Me.ucDispListDatas)
        Me.gbMeasuredData.Location = New System.Drawing.Point(12, 15)
        Me.gbMeasuredData.Name = "gbMeasuredData"
        Me.gbMeasuredData.Size = New System.Drawing.Size(710, 241)
        Me.gbMeasuredData.TabIndex = 0
        Me.gbMeasuredData.TabStop = False
        Me.gbMeasuredData.Text = "Mes"
        '
        'ucDispListDatas
        '
        Me.ucDispListDatas.ColHeader = New String() {"No.", "Mode", "ELvss(V)", "ELvss(A)", "ELvdd(V)", "ELvdd(A)", "Red Bias(V)", "Green Bias(V)", "Blue Bias(V)"}
        Me.ucDispListDatas.ColHeaderWidthRatio = "5,12,12,12,12,12,12,12,12"
        Me.ucDispListDatas.FullRawSelection = True
        Me.ucDispListDatas.Location = New System.Drawing.Point(6, 20)
        Me.ucDispListDatas.Name = "ucDispListDatas"
        Me.ucDispListDatas.Size = New System.Drawing.Size(654, 194)
        Me.ucDispListDatas.TabIndex = 0
        Me.ucDispListDatas.UseCheckBoxex = False
        '
        'dispIVLGraph
        '
        Me.dispIVLGraph.Location = New System.Drawing.Point(49, 3)
        Me.dispIVLGraph.Name = "dispIVLGraph"
        Me.dispIVLGraph.numOfPlots = 1
        Me.dispIVLGraph.PlotColor = New System.Drawing.Color() {System.Drawing.Color.Yellow}
        Me.dispIVLGraph.PlotIndex = New String() {"Test"}
        Me.dispIVLGraph.Size = New System.Drawing.Size(337, 290)
        Me.dispIVLGraph.TabIndex = 2
        Me.dispIVLGraph.XAxisScale_Auto = True
        Me.dispIVLGraph.XAxisScale_MaxValue = 0.0R
        Me.dispIVLGraph.XAxisScale_MinValue = 0.0R
        Me.dispIVLGraph.XAxisTitle = "X Axis Title"
        Me.dispIVLGraph.Y1AxisTitle = "Y Axis Title"
        Me.dispIVLGraph.Y2AxisTitle = "Y2 Axis Title"
        '
        'frmPretestUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1271, 693)
        Me.ControlBox = False
        Me.Controls.Add(Me.spMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPretestUI"
        Me.spMain.Panel1.ResumeLayout(False)
        Me.spMain.Panel2.ResumeLayout(False)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        Me.gbControl.ResumeLayout(False)
        Me.gbControl.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.sequenceTreeView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbMeasuredData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spMain As System.Windows.Forms.SplitContainer
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Friend WithEvents sequenceTreeView As CommonTools.TreeListView
    Friend WithEvents lbSequenceName As System.Windows.Forms.Label
    Friend WithEvents Leble2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbMeasuredData As System.Windows.Forms.GroupBox
    Friend WithEvents ucDispListDatas As M7000.ucDispListView
    Friend WithEvents dispIVLGraph As M7000.ucDispGraph
    Friend WithEvents btnSourceControl As System.Windows.Forms.Button
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents lblQueueCount As System.Windows.Forms.Label
    Friend WithEvents lblTemperature As System.Windows.Forms.Label
    Friend WithEvents lblMeasStatus As System.Windows.Forms.Label
End Class
