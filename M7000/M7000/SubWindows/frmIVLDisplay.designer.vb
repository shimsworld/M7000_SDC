<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIVLDisplay
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
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dispGraph3 = New M7000.ucDispGraph()
        Me.dispGraph = New M7000.ucDispGraph()
        Me.dispGraph4 = New M7000.ucDispGraph()
        Me.dispGraph2 = New M7000.ucDispGraph()
        Me.dispListView = New M7000.ucDispListView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblSweepMode = New System.Windows.Forms.Label()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.lblMeasStatus = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spContainer.Location = New System.Drawing.Point(23, 12)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.Controls.Add(Me.SplitContainer1)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.SplitContainer2)
        Me.spContainer.Size = New System.Drawing.Size(1444, 837)
        Me.spContainer.SplitterDistance = 626
        Me.spContainer.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dispListView)
        Me.SplitContainer1.Size = New System.Drawing.Size(1442, 624)
        Me.SplitContainer1.SplitterDistance = 748
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dispGraph3, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dispGraph, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dispGraph4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dispGraph2, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(80, 67)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(629, 526)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'dispGraph3
        '
        Me.dispGraph3.Location = New System.Drawing.Point(317, 266)
        Me.dispGraph3.Name = "dispGraph3"
        Me.dispGraph3.numOfPlots = 1
        Me.dispGraph3.PlotColor = New System.Drawing.Color() {System.Drawing.Color.Yellow}
        Me.dispGraph3.PlotIndex = New String() {"Test"}
        Me.dispGraph3.Size = New System.Drawing.Size(223, 191)
        Me.dispGraph3.TabIndex = 6
        Me.dispGraph3.XAxisScale_Auto = True
        Me.dispGraph3.XAxisScale_MaxValue = 0.0R
        Me.dispGraph3.XAxisScale_MinValue = 0.0R
        Me.dispGraph3.XAxisTitle = "X Axis Title"
        Me.dispGraph3.Y1AxisTitle = "Y Axis Title"
        Me.dispGraph3.Y2AxisTitle = "Y2 Axis Title"
        '
        'dispGraph
        '
        Me.dispGraph.Location = New System.Drawing.Point(3, 3)
        Me.dispGraph.Name = "dispGraph"
        Me.dispGraph.numOfPlots = 1
        Me.dispGraph.PlotColor = New System.Drawing.Color() {System.Drawing.Color.Yellow}
        Me.dispGraph.PlotIndex = New String() {"Test"}
        Me.dispGraph.Size = New System.Drawing.Size(210, 163)
        Me.dispGraph.TabIndex = 0
        Me.dispGraph.XAxisScale_Auto = True
        Me.dispGraph.XAxisScale_MaxValue = 0.0R
        Me.dispGraph.XAxisScale_MinValue = 0.0R
        Me.dispGraph.XAxisTitle = "X Axis Title"
        Me.dispGraph.Y1AxisTitle = "Y Axis Title"
        Me.dispGraph.Y2AxisTitle = "Y2 Axis Title"
        '
        'dispGraph4
        '
        Me.dispGraph4.Location = New System.Drawing.Point(3, 266)
        Me.dispGraph4.Name = "dispGraph4"
        Me.dispGraph4.numOfPlots = 1
        Me.dispGraph4.PlotColor = New System.Drawing.Color() {System.Drawing.Color.Yellow}
        Me.dispGraph4.PlotIndex = New String() {"Test"}
        Me.dispGraph4.Size = New System.Drawing.Size(210, 203)
        Me.dispGraph4.TabIndex = 5
        Me.dispGraph4.XAxisScale_Auto = True
        Me.dispGraph4.XAxisScale_MaxValue = 0.0R
        Me.dispGraph4.XAxisScale_MinValue = 0.0R
        Me.dispGraph4.XAxisTitle = "X Axis Title"
        Me.dispGraph4.Y1AxisTitle = "Y Axis Title"
        Me.dispGraph4.Y2AxisTitle = "Y2 Axis Title"
        '
        'dispGraph2
        '
        Me.dispGraph2.Location = New System.Drawing.Point(317, 3)
        Me.dispGraph2.Name = "dispGraph2"
        Me.dispGraph2.numOfPlots = 1
        Me.dispGraph2.PlotColor = New System.Drawing.Color() {System.Drawing.Color.Yellow}
        Me.dispGraph2.PlotIndex = New String() {"Test"}
        Me.dispGraph2.Size = New System.Drawing.Size(210, 163)
        Me.dispGraph2.TabIndex = 1
        Me.dispGraph2.XAxisScale_Auto = True
        Me.dispGraph2.XAxisScale_MaxValue = 0.0R
        Me.dispGraph2.XAxisScale_MinValue = 0.0R
        Me.dispGraph2.XAxisTitle = "X Axis Title"
        Me.dispGraph2.Y1AxisTitle = "Y Axis Title"
        Me.dispGraph2.Y2AxisTitle = "Y2 Axis Title"
        '
        'dispListView
        '
        Me.dispListView.ColHeader = New String() {"No.", "Mode", "Area", "Voltage"}
        Me.dispListView.ColHeaderWidthRatio = "25,25,25,25"
        Me.dispListView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dispListView.FullRawSelection = True
        Me.dispListView.HideSelection = False
        Me.dispListView.LabelEdit = True
        Me.dispListView.LabelWrap = True
        Me.dispListView.Location = New System.Drawing.Point(24, 101)
        Me.dispListView.Name = "dispListView"
        Me.dispListView.Size = New System.Drawing.Size(456, 317)
        Me.dispListView.TabIndex = 0
        Me.dispListView.UseCheckBoxex = False
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
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblSweepMode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblChannel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblMeasStatus)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1442, 205)
        Me.SplitContainer2.SplitterDistance = 97
        Me.SplitContainer2.TabIndex = 0
        '
        'lblSweepMode
        '
        Me.lblSweepMode.BackColor = System.Drawing.Color.Transparent
        Me.lblSweepMode.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSweepMode.ForeColor = System.Drawing.Color.LightCoral
        Me.lblSweepMode.Location = New System.Drawing.Point(57, 36)
        Me.lblSweepMode.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSweepMode.Name = "lblSweepMode"
        Me.lblSweepMode.Size = New System.Drawing.Size(178, 30)
        Me.lblSweepMode.TabIndex = 3
        Me.lblSweepMode.Text = "Sweep Mode"
        Me.lblSweepMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChannel
        '
        Me.lblChannel.BackColor = System.Drawing.Color.Transparent
        Me.lblChannel.Font = New System.Drawing.Font("Segoe UI Symbol", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChannel.ForeColor = System.Drawing.Color.Yellow
        Me.lblChannel.Location = New System.Drawing.Point(3, 3)
        Me.lblChannel.Margin = New System.Windows.Forms.Padding(3)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(277, 30)
        Me.lblChannel.TabIndex = 2
        Me.lblChannel.Text = "CHXX"
        Me.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMeasStatus
        '
        Me.lblMeasStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblMeasStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasStatus.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMeasStatus.Location = New System.Drawing.Point(279, 3)
        Me.lblMeasStatus.Name = "lblMeasStatus"
        Me.lblMeasStatus.Size = New System.Drawing.Size(407, 51)
        Me.lblMeasStatus.TabIndex = 0
        Me.lblMeasStatus.Text = "S T A T U S"
        Me.lblMeasStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnHide, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStop, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(56, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(844, 59)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnHide
        '
        Me.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHide.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHide.Location = New System.Drawing.Point(425, 3)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(83, 47)
        Me.btnHide.TabIndex = 2
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(3, 3)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(83, 47)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Meas. Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'frmIVLDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1799, 890)
        Me.ControlBox = False
        Me.Controls.Add(Me.spContainer)
        Me.Name = "frmIVLDisplay"
        Me.Text = "Sweep Indicator"
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblMeasStatus As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents dispListView As M7000.ucDispListView
    Friend WithEvents dispGraph As M7000.ucDispGraph
    Friend WithEvents lblChannel As System.Windows.Forms.Label
    Friend WithEvents lblSweepMode As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dispGraph4 As M7000.ucDispGraph
    Friend WithEvents dispGraph2 As M7000.ucDispGraph
    Friend WithEvents dispGraph3 As M7000.ucDispGraph
End Class
