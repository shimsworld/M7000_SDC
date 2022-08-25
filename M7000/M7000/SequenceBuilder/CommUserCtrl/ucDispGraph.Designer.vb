<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispGraph
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
        Me.grpMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmSelectPlotMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSCurrent = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSABS_Current = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSJ = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSABS_J = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSLuminance = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSCdA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVoltageVSlmW = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmJVSVoltage = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmJVSLuminance = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmJVSCdA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmJVSlmW = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmLuminanceVSCdA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAngleVSLuminance = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmSaveImageAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShowPointValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomEnableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmUnZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.XAxisScaleLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XAxisScaleLinearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Y1AxisScaleLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Y1AxisScaleLinearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Y2AxisScaleLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Y2AxisScaleLinearToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeLineColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.zgGraph = New ZedGraph.ZedGraphControl()
        Me.btnTestAdd = New System.Windows.Forms.Button()
        Me.btnTestInit = New System.Windows.Forms.Button()
        Me.AngleVSQEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AngleVSCdAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AngleVSLmWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMenu
        '
        Me.grpMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSelectPlotMode, Me.ToolStripMenuItem1, Me.tsmSaveImageAs, Me.tsmPageSetup, Me.tsmPrint, Me.tsmShowPointValues, Me.ToolStripMenuItem6, Me.ZoomEnableToolStripMenuItem, Me.tsmUnZoom, Me.ToolStripMenuItem2, Me.XAxisScaleLogToolStripMenuItem, Me.XAxisScaleLinearToolStripMenuItem, Me.ToolStripMenuItem3, Me.Y1AxisScaleLogToolStripMenuItem, Me.Y1AxisScaleLinearToolStripMenuItem, Me.ToolStripMenuItem4, Me.Y2AxisScaleLogToolStripMenuItem, Me.Y2AxisScaleLinearToolStripMenuItem1, Me.ToolStripMenuItem5, Me.ChangeLineColorToolStripMenuItem})
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(177, 370)
        '
        'tsmSelectPlotMode
        '
        Me.tsmSelectPlotMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmVoltageVSCurrent, Me.tsmVoltageVSABS_Current, Me.tsmVoltageVSJ, Me.tsmVoltageVSABS_J, Me.tsmVoltageVSLuminance, Me.tsmVoltageVSCdA, Me.tsmVoltageVSlmW, Me.tsmJVSVoltage, Me.tsmJVSLuminance, Me.tsmJVSCdA, Me.tsmJVSlmW, Me.tsmLuminanceVSCdA, Me.tsmAngleVSLuminance, Me.AngleVSQEToolStripMenuItem, Me.AngleVSCdAToolStripMenuItem, Me.AngleVSLmWToolStripMenuItem})
        Me.tsmSelectPlotMode.Name = "tsmSelectPlotMode"
        Me.tsmSelectPlotMode.Size = New System.Drawing.Size(176, 22)
        Me.tsmSelectPlotMode.Text = "Select Plot Mode"
        '
        'tsmVoltageVSCurrent
        '
        Me.tsmVoltageVSCurrent.CheckOnClick = True
        Me.tsmVoltageVSCurrent.Name = "tsmVoltageVSCurrent"
        Me.tsmVoltageVSCurrent.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSCurrent.Text = "Voltage VS Current"
        '
        'tsmVoltageVSABS_Current
        '
        Me.tsmVoltageVSABS_Current.Name = "tsmVoltageVSABS_Current"
        Me.tsmVoltageVSABS_Current.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSABS_Current.Text = "Voltage VS ABS_Current"
        '
        'tsmVoltageVSJ
        '
        Me.tsmVoltageVSJ.Name = "tsmVoltageVSJ"
        Me.tsmVoltageVSJ.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSJ.Text = "Voltage VS J"
        '
        'tsmVoltageVSABS_J
        '
        Me.tsmVoltageVSABS_J.Name = "tsmVoltageVSABS_J"
        Me.tsmVoltageVSABS_J.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSABS_J.Text = "Voltage VS ABS_J"
        '
        'tsmVoltageVSLuminance
        '
        Me.tsmVoltageVSLuminance.Name = "tsmVoltageVSLuminance"
        Me.tsmVoltageVSLuminance.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSLuminance.Text = "Voltage VS Luminance"
        '
        'tsmVoltageVSCdA
        '
        Me.tsmVoltageVSCdA.Name = "tsmVoltageVSCdA"
        Me.tsmVoltageVSCdA.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSCdA.Text = "Voltage VS cd/A"
        '
        'tsmVoltageVSlmW
        '
        Me.tsmVoltageVSlmW.Name = "tsmVoltageVSlmW"
        Me.tsmVoltageVSlmW.Size = New System.Drawing.Size(199, 22)
        Me.tsmVoltageVSlmW.Text = "Voltage VS lm/W"
        '
        'tsmJVSVoltage
        '
        Me.tsmJVSVoltage.Name = "tsmJVSVoltage"
        Me.tsmJVSVoltage.Size = New System.Drawing.Size(199, 22)
        Me.tsmJVSVoltage.Text = "J VS Voltage"
        '
        'tsmJVSLuminance
        '
        Me.tsmJVSLuminance.Name = "tsmJVSLuminance"
        Me.tsmJVSLuminance.Size = New System.Drawing.Size(199, 22)
        Me.tsmJVSLuminance.Text = "J VS Luminance"
        '
        'tsmJVSCdA
        '
        Me.tsmJVSCdA.Name = "tsmJVSCdA"
        Me.tsmJVSCdA.Size = New System.Drawing.Size(199, 22)
        Me.tsmJVSCdA.Text = "J VS cd/A"
        '
        'tsmJVSlmW
        '
        Me.tsmJVSlmW.Name = "tsmJVSlmW"
        Me.tsmJVSlmW.Size = New System.Drawing.Size(199, 22)
        Me.tsmJVSlmW.Text = "J VS lm/W"
        '
        'tsmLuminanceVSCdA
        '
        Me.tsmLuminanceVSCdA.Name = "tsmLuminanceVSCdA"
        Me.tsmLuminanceVSCdA.Size = New System.Drawing.Size(199, 22)
        Me.tsmLuminanceVSCdA.Text = "Luminance VS cd/A"
        '
        'tsmAngleVSLuminance
        '
        Me.tsmAngleVSLuminance.Name = "tsmAngleVSLuminance"
        Me.tsmAngleVSLuminance.Size = New System.Drawing.Size(199, 22)
        Me.tsmAngleVSLuminance.Text = "Angle VS Luminance"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(173, 6)
        Me.ToolStripMenuItem1.Visible = False
        '
        'tsmSaveImageAs
        '
        Me.tsmSaveImageAs.Name = "tsmSaveImageAs"
        Me.tsmSaveImageAs.Size = New System.Drawing.Size(176, 22)
        Me.tsmSaveImageAs.Text = "Save Image As..."
        '
        'tsmPageSetup
        '
        Me.tsmPageSetup.Name = "tsmPageSetup"
        Me.tsmPageSetup.Size = New System.Drawing.Size(176, 22)
        Me.tsmPageSetup.Text = "Page Setup..."
        '
        'tsmPrint
        '
        Me.tsmPrint.Name = "tsmPrint"
        Me.tsmPrint.Size = New System.Drawing.Size(176, 22)
        Me.tsmPrint.Text = "Print..."
        '
        'tsmShowPointValues
        '
        Me.tsmShowPointValues.Name = "tsmShowPointValues"
        Me.tsmShowPointValues.Size = New System.Drawing.Size(176, 22)
        Me.tsmShowPointValues.Text = "Show Point Values"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(173, 6)
        '
        'ZoomEnableToolStripMenuItem
        '
        Me.ZoomEnableToolStripMenuItem.Name = "ZoomEnableToolStripMenuItem"
        Me.ZoomEnableToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ZoomEnableToolStripMenuItem.Text = "Zoom Enable"
        '
        'tsmUnZoom
        '
        Me.tsmUnZoom.Name = "tsmUnZoom"
        Me.tsmUnZoom.Size = New System.Drawing.Size(176, 22)
        Me.tsmUnZoom.Text = "Un-Zoom"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(173, 6)
        '
        'XAxisScaleLogToolStripMenuItem
        '
        Me.XAxisScaleLogToolStripMenuItem.Name = "XAxisScaleLogToolStripMenuItem"
        Me.XAxisScaleLogToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.XAxisScaleLogToolStripMenuItem.Text = "X Axis Scale Log"
        '
        'XAxisScaleLinearToolStripMenuItem
        '
        Me.XAxisScaleLinearToolStripMenuItem.Name = "XAxisScaleLinearToolStripMenuItem"
        Me.XAxisScaleLinearToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.XAxisScaleLinearToolStripMenuItem.Text = "X Axis Scale Linear"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(173, 6)
        '
        'Y1AxisScaleLogToolStripMenuItem
        '
        Me.Y1AxisScaleLogToolStripMenuItem.Name = "Y1AxisScaleLogToolStripMenuItem"
        Me.Y1AxisScaleLogToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.Y1AxisScaleLogToolStripMenuItem.Text = "Y1 Axis Scale Log"
        '
        'Y1AxisScaleLinearToolStripMenuItem
        '
        Me.Y1AxisScaleLinearToolStripMenuItem.Name = "Y1AxisScaleLinearToolStripMenuItem"
        Me.Y1AxisScaleLinearToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.Y1AxisScaleLinearToolStripMenuItem.Text = "Y1 Axis Scale Linear"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(173, 6)
        '
        'Y2AxisScaleLogToolStripMenuItem
        '
        Me.Y2AxisScaleLogToolStripMenuItem.Name = "Y2AxisScaleLogToolStripMenuItem"
        Me.Y2AxisScaleLogToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.Y2AxisScaleLogToolStripMenuItem.Text = "Y2 Axis Scale Log"
        '
        'Y2AxisScaleLinearToolStripMenuItem1
        '
        Me.Y2AxisScaleLinearToolStripMenuItem1.Name = "Y2AxisScaleLinearToolStripMenuItem1"
        Me.Y2AxisScaleLinearToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.Y2AxisScaleLinearToolStripMenuItem1.Text = "Y2 Axis Scale Linear"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(173, 6)
        '
        'ChangeLineColorToolStripMenuItem
        '
        Me.ChangeLineColorToolStripMenuItem.Name = "ChangeLineColorToolStripMenuItem"
        Me.ChangeLineColorToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ChangeLineColorToolStripMenuItem.Text = "Change Line Color"
        '
        'zgGraph
        '
        Me.zgGraph.ContextMenuStrip = Me.grpMenu
        Me.zgGraph.Location = New System.Drawing.Point(8, 8)
        Me.zgGraph.Name = "zgGraph"
        Me.zgGraph.ScrollGrace = 0.0R
        Me.zgGraph.ScrollMaxX = 0.0R
        Me.zgGraph.ScrollMaxY = 0.0R
        Me.zgGraph.ScrollMaxY2 = 0.0R
        Me.zgGraph.ScrollMinX = 0.0R
        Me.zgGraph.ScrollMinY = 0.0R
        Me.zgGraph.ScrollMinY2 = 0.0R
        Me.zgGraph.Size = New System.Drawing.Size(325, 175)
        Me.zgGraph.TabIndex = 10
        '
        'btnTestAdd
        '
        Me.btnTestAdd.Location = New System.Drawing.Point(248, 189)
        Me.btnTestAdd.Name = "btnTestAdd"
        Me.btnTestAdd.Size = New System.Drawing.Size(85, 32)
        Me.btnTestAdd.TabIndex = 11
        Me.btnTestAdd.Text = "Add"
        Me.btnTestAdd.UseVisualStyleBackColor = True
        Me.btnTestAdd.Visible = False
        '
        'btnTestInit
        '
        Me.btnTestInit.Location = New System.Drawing.Point(155, 189)
        Me.btnTestInit.Name = "btnTestInit"
        Me.btnTestInit.Size = New System.Drawing.Size(76, 32)
        Me.btnTestInit.TabIndex = 12
        Me.btnTestInit.Text = "Init"
        Me.btnTestInit.UseVisualStyleBackColor = True
        Me.btnTestInit.Visible = False
        '
        'AngleVSQEToolStripMenuItem
        '
        Me.AngleVSQEToolStripMenuItem.Name = "AngleVSQEToolStripMenuItem"
        Me.AngleVSQEToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AngleVSQEToolStripMenuItem.Text = "Angle VS QE"
        '
        'AngleVSCdAToolStripMenuItem
        '
        Me.AngleVSCdAToolStripMenuItem.Name = "AngleVSCdAToolStripMenuItem"
        Me.AngleVSCdAToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AngleVSCdAToolStripMenuItem.Text = "Angle VS cd/A"
        '
        'AngleVSLmWToolStripMenuItem
        '
        Me.AngleVSLmWToolStripMenuItem.Name = "AngleVSLmWToolStripMenuItem"
        Me.AngleVSLmWToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AngleVSLmWToolStripMenuItem.Text = "Angle VS lm/W"
        '
        'ucDispGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.zgGraph)
        Me.Controls.Add(Me.btnTestAdd)
        Me.Controls.Add(Me.btnTestInit)
        Me.Name = "ucDispGraph"
        Me.Size = New System.Drawing.Size(618, 407)
        Me.grpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zgGraph As ZedGraph.ZedGraphControl
    Friend WithEvents grpMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmSelectPlotMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSaveImageAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmShowPointValues As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUnZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents XAxisScaleLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XAxisScaleLinearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Y1AxisScaleLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Y1AxisScaleLinearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Y2AxisScaleLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Y2AxisScaleLinearToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangeLineColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZoomEnableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSCurrent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSABS_Current As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTestAdd As System.Windows.Forms.Button
    Friend WithEvents btnTestInit As System.Windows.Forms.Button
    Friend WithEvents tsmVoltageVSJ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSABS_J As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSLuminance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSCdA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVoltageVSlmW As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmJVSVoltage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmJVSLuminance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmJVSCdA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmJVSlmW As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmLuminanceVSCdA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAngleVSLuminance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AngleVSQEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AngleVSCdAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AngleVSLmWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
