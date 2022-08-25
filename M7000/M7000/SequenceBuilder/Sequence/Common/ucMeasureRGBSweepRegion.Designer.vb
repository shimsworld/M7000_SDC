<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMeasureRGBSweepRegion
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gbSweepCommon = New System.Windows.Forms.GroupBox()
        Me.lblPoint = New System.Windows.Forms.Label()
        Me.tbPoint = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.tbStep = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblStop = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblStepValueUnit = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tbStop = New System.Windows.Forms.TextBox()
        Me.lblStartValueUnit = New System.Windows.Forms.Label()
        Me.lblStopValueUnit = New System.Windows.Forms.Label()
        Me.tbStart = New System.Windows.Forms.TextBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.ucListMeasSweep = New M7000.ucDispListView()
        Me.gbSweepCommon.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSweepCommon
        '
        Me.gbSweepCommon.Controls.Add(Me.lblPoint)
        Me.gbSweepCommon.Controls.Add(Me.tbPoint)
        Me.gbSweepCommon.Controls.Add(Me.Button1)
        Me.gbSweepCommon.Controls.Add(Me.lblStep)
        Me.gbSweepCommon.Controls.Add(Me.ucListMeasSweep)
        Me.gbSweepCommon.Controls.Add(Me.tbStep)
        Me.gbSweepCommon.Controls.Add(Me.btnAdd)
        Me.gbSweepCommon.Controls.Add(Me.lblStop)
        Me.gbSweepCommon.Controls.Add(Me.btnClear)
        Me.gbSweepCommon.Controls.Add(Me.lblStepValueUnit)
        Me.gbSweepCommon.Controls.Add(Me.btnDelete)
        Me.gbSweepCommon.Controls.Add(Me.tbStop)
        Me.gbSweepCommon.Controls.Add(Me.lblStartValueUnit)
        Me.gbSweepCommon.Controls.Add(Me.lblStopValueUnit)
        Me.gbSweepCommon.Controls.Add(Me.tbStart)
        Me.gbSweepCommon.Controls.Add(Me.lblStart)
        Me.gbSweepCommon.Location = New System.Drawing.Point(8, 4)
        Me.gbSweepCommon.Margin = New System.Windows.Forms.Padding(4)
        Me.gbSweepCommon.Name = "gbSweepCommon"
        Me.gbSweepCommon.Padding = New System.Windows.Forms.Padding(4)
        Me.gbSweepCommon.Size = New System.Drawing.Size(494, 356)
        Me.gbSweepCommon.TabIndex = 50
        Me.gbSweepCommon.TabStop = False
        Me.gbSweepCommon.Tag = ""
        Me.gbSweepCommon.Text = "IVL RGB Sweep Region"
        '
        'lblPoint
        '
        Me.lblPoint.AutoSize = True
        Me.lblPoint.Location = New System.Drawing.Point(186, 166)
        Me.lblPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPoint.Name = "lblPoint"
        Me.lblPoint.Size = New System.Drawing.Size(55, 21)
        Me.lblPoint.TabIndex = 37
        Me.lblPoint.Text = "Point"
        '
        'tbPoint
        '
        Me.tbPoint.BackColor = System.Drawing.SystemColors.Control
        Me.tbPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPoint.Enabled = False
        Me.tbPoint.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbPoint.Location = New System.Drawing.Point(246, 161)
        Me.tbPoint.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPoint.Name = "tbPoint"
        Me.tbPoint.Size = New System.Drawing.Size(132, 28)
        Me.tbPoint.TabIndex = 3
        Me.tbPoint.Text = "0"
        Me.tbPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(386, 156)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 34)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(17, 129)
        Me.lblStep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(50, 21)
        Me.lblStep.TabIndex = 34
        Me.lblStep.Text = "Step"
        '
        'tbStep
        '
        Me.tbStep.BackColor = System.Drawing.SystemColors.Control
        Me.tbStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStep.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStep.Location = New System.Drawing.Point(72, 125)
        Me.tbStep.Margin = New System.Windows.Forms.Padding(4)
        Me.tbStep.Name = "tbStep"
        Me.tbStep.Size = New System.Drawing.Size(81, 28)
        Me.tbStep.TabIndex = 2
        Me.tbStep.Text = "0"
        Me.tbStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(386, 26)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 34)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblStop
        '
        Me.lblStop.AutoSize = True
        Me.lblStop.Location = New System.Drawing.Point(17, 93)
        Me.lblStop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStop.Name = "lblStop"
        Me.lblStop.Size = New System.Drawing.Size(50, 21)
        Me.lblStop.TabIndex = 27
        Me.lblStop.Text = "Stop"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(386, 112)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(99, 34)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblStepValueUnit
        '
        Me.lblStepValueUnit.AutoSize = True
        Me.lblStepValueUnit.Location = New System.Drawing.Point(161, 127)
        Me.lblStepValueUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStepValueUnit.Name = "lblStepValueUnit"
        Me.lblStepValueUnit.Size = New System.Drawing.Size(23, 21)
        Me.lblStepValueUnit.TabIndex = 36
        Me.lblStepValueUnit.Text = "V"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Silver
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(386, 69)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 34)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'tbStop
        '
        Me.tbStop.BackColor = System.Drawing.SystemColors.Control
        Me.tbStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStop.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStop.Location = New System.Drawing.Point(72, 89)
        Me.tbStop.Margin = New System.Windows.Forms.Padding(4)
        Me.tbStop.Name = "tbStop"
        Me.tbStop.Size = New System.Drawing.Size(81, 28)
        Me.tbStop.TabIndex = 1
        Me.tbStop.Text = "0"
        Me.tbStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStartValueUnit
        '
        Me.lblStartValueUnit.AutoSize = True
        Me.lblStartValueUnit.Location = New System.Drawing.Point(161, 55)
        Me.lblStartValueUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStartValueUnit.Name = "lblStartValueUnit"
        Me.lblStartValueUnit.Size = New System.Drawing.Size(23, 21)
        Me.lblStartValueUnit.TabIndex = 26
        Me.lblStartValueUnit.Text = "V"
        '
        'lblStopValueUnit
        '
        Me.lblStopValueUnit.AutoSize = True
        Me.lblStopValueUnit.Location = New System.Drawing.Point(161, 90)
        Me.lblStopValueUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStopValueUnit.Name = "lblStopValueUnit"
        Me.lblStopValueUnit.Size = New System.Drawing.Size(23, 21)
        Me.lblStopValueUnit.TabIndex = 29
        Me.lblStopValueUnit.Text = "V"
        '
        'tbStart
        '
        Me.tbStart.BackColor = System.Drawing.SystemColors.Control
        Me.tbStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStart.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStart.Location = New System.Drawing.Point(72, 53)
        Me.tbStart.Margin = New System.Windows.Forms.Padding(4)
        Me.tbStart.Name = "tbStart"
        Me.tbStart.Size = New System.Drawing.Size(81, 28)
        Me.tbStart.TabIndex = 0
        Me.tbStart.Text = "0"
        Me.tbStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(17, 58)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(51, 21)
        Me.lblStart.TabIndex = 24
        Me.lblStart.Text = "Start"
        '
        'ucListMeasSweep
        '
        Me.ucListMeasSweep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListMeasSweep.ColHeader = New String() {"No.", "Start", "Stop", "Step", "Point", "Level"}
        Me.ucListMeasSweep.ColHeaderWidthRatio = "10,18,18,18,18,18"
        Me.ucListMeasSweep.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListMeasSweep.FullRawSelection = True
        Me.ucListMeasSweep.HideSelection = False
        Me.ucListMeasSweep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListMeasSweep.LabelEdit = True
        Me.ucListMeasSweep.LabelWrap = True
        Me.ucListMeasSweep.Location = New System.Drawing.Point(9, 195)
        Me.ucListMeasSweep.Margin = New System.Windows.Forms.Padding(6)
        Me.ucListMeasSweep.Name = "ucListMeasSweep"
        Me.ucListMeasSweep.Size = New System.Drawing.Size(476, 142)
        Me.ucListMeasSweep.TabIndex = 25
        Me.ucListMeasSweep.UseCheckBoxex = False
        '
        'ucMeasureRGBSweepRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.gbSweepCommon)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(506, 364)
        Me.MinimumSize = New System.Drawing.Size(392, 356)
        Me.Name = "ucMeasureRGBSweepRegion"
        Me.Size = New System.Drawing.Size(506, 364)
        Me.gbSweepCommon.ResumeLayout(False)
        Me.gbSweepCommon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSweepCommon As System.Windows.Forms.GroupBox
    Friend WithEvents ucListMeasSweep As M7000.ucDispListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents tbStart As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPoint As System.Windows.Forms.Label
    Friend WithEvents tbPoint As System.Windows.Forms.TextBox
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents tbStep As System.Windows.Forms.TextBox
    Friend WithEvents lblStop As System.Windows.Forms.Label
    Friend WithEvents tbStop As System.Windows.Forms.TextBox
    Private WithEvents lblStartValueUnit As System.Windows.Forms.Label
    Private WithEvents lblStepValueUnit As System.Windows.Forms.Label
    Private WithEvents lblStopValueUnit As System.Windows.Forms.Label
End Class
