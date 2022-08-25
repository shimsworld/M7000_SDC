<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpGrayScaleSweep
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
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbSelectSweepMode = New System.Windows.Forms.GroupBox()
        Me.rdoUserPattern = New System.Windows.Forms.RadioButton()
        Me.rdoAll = New System.Windows.Forms.RadioButton()
        Me.rdoBlue = New System.Windows.Forms.RadioButton()
        Me.rdoGreen = New System.Windows.Forms.RadioButton()
        Me.rdoRed = New System.Windows.Forms.RadioButton()
        Me.ucGrayScaleSweepTable = New M7000.ucMeasureSweepRegion()
        Me.ucGrayScaleSweepRegion = New M7000.ucMeasureSweepRegion()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbSelectSweepMode.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spContainer.Location = New System.Drawing.Point(3, 4)
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
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(609, 817)
        Me.spContainer.SplitterDistance = 321
        Me.spContainer.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbSelectSweepMode)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ucGrayScaleSweepTable)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ucGrayScaleSweepRegion)
        Me.SplitContainer1.Size = New System.Drawing.Size(607, 319)
        Me.SplitContainer1.SplitterDistance = 63
        Me.SplitContainer1.TabIndex = 0
        '
        'gbSelectSweepMode
        '
        Me.gbSelectSweepMode.Controls.Add(Me.rdoUserPattern)
        Me.gbSelectSweepMode.Controls.Add(Me.rdoAll)
        Me.gbSelectSweepMode.Controls.Add(Me.rdoBlue)
        Me.gbSelectSweepMode.Controls.Add(Me.rdoGreen)
        Me.gbSelectSweepMode.Controls.Add(Me.rdoRed)
        Me.gbSelectSweepMode.Location = New System.Drawing.Point(26, 11)
        Me.gbSelectSweepMode.Name = "gbSelectSweepMode"
        Me.gbSelectSweepMode.Size = New System.Drawing.Size(476, 42)
        Me.gbSelectSweepMode.TabIndex = 25
        Me.gbSelectSweepMode.TabStop = False
        Me.gbSelectSweepMode.Text = "Select Sweep Mode"
        '
        'rdoUserPattern
        '
        Me.rdoUserPattern.AutoSize = True
        Me.rdoUserPattern.Location = New System.Drawing.Point(366, 19)
        Me.rdoUserPattern.Name = "rdoUserPattern"
        Me.rdoUserPattern.Size = New System.Drawing.Size(88, 16)
        Me.rdoUserPattern.TabIndex = 4
        Me.rdoUserPattern.TabStop = True
        Me.rdoUserPattern.Text = "UserPattern"
        Me.rdoUserPattern.UseVisualStyleBackColor = True
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(265, 19)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(37, 16)
        Me.rdoAll.TabIndex = 3
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "All"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'rdoBlue
        '
        Me.rdoBlue.AutoSize = True
        Me.rdoBlue.Location = New System.Drawing.Point(181, 19)
        Me.rdoBlue.Name = "rdoBlue"
        Me.rdoBlue.Size = New System.Drawing.Size(48, 16)
        Me.rdoBlue.TabIndex = 2
        Me.rdoBlue.TabStop = True
        Me.rdoBlue.Text = "Blue"
        Me.rdoBlue.UseVisualStyleBackColor = True
        '
        'rdoGreen
        '
        Me.rdoGreen.AutoSize = True
        Me.rdoGreen.Location = New System.Drawing.Point(93, 19)
        Me.rdoGreen.Name = "rdoGreen"
        Me.rdoGreen.Size = New System.Drawing.Size(57, 16)
        Me.rdoGreen.TabIndex = 1
        Me.rdoGreen.TabStop = True
        Me.rdoGreen.Text = "Green"
        Me.rdoGreen.UseVisualStyleBackColor = True
        '
        'rdoRed
        '
        Me.rdoRed.AutoSize = True
        Me.rdoRed.Location = New System.Drawing.Point(13, 19)
        Me.rdoRed.Name = "rdoRed"
        Me.rdoRed.Size = New System.Drawing.Size(45, 16)
        Me.rdoRed.TabIndex = 0
        Me.rdoRed.TabStop = True
        Me.rdoRed.Text = "Red"
        Me.rdoRed.UseVisualStyleBackColor = True
        '
        'ucGrayScaleSweepTable
        '
        Me.ucGrayScaleSweepTable.AutoScroll = True
        Me.ucGrayScaleSweepTable.IsVisibleUnit = False
        Me.ucGrayScaleSweepTable.Location = New System.Drawing.Point(291, 22)
        Me.ucGrayScaleSweepTable.MaximumSize = New System.Drawing.Size(337, 243)
        Me.ucGrayScaleSweepTable.MinimumSize = New System.Drawing.Size(261, 237)
        Me.ucGrayScaleSweepTable.Name = "ucGrayScaleSweepTable"
        Me.ucGrayScaleSweepTable.Setting = Nothing
        Me.ucGrayScaleSweepTable.Size = New System.Drawing.Size(261, 237)
        Me.ucGrayScaleSweepTable.SweepList = Nothing
        Me.ucGrayScaleSweepTable.SweepType = M7000.ucMeasureSweepRegion.eSweepType._UserPattern
        Me.ucGrayScaleSweepTable.TabIndex = 25
        Me.ucGrayScaleSweepTable.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'ucGrayScaleSweepRegion
        '
        Me.ucGrayScaleSweepRegion.AutoScroll = True
        Me.ucGrayScaleSweepRegion.IsVisibleUnit = False
        Me.ucGrayScaleSweepRegion.Location = New System.Drawing.Point(47, 22)
        Me.ucGrayScaleSweepRegion.MaximumSize = New System.Drawing.Size(337, 243)
        Me.ucGrayScaleSweepRegion.MinimumSize = New System.Drawing.Size(261, 237)
        Me.ucGrayScaleSweepRegion.Name = "ucGrayScaleSweepRegion"
        Me.ucGrayScaleSweepRegion.Setting = Nothing
        Me.ucGrayScaleSweepRegion.Size = New System.Drawing.Size(261, 237)
        Me.ucGrayScaleSweepRegion.SweepList = Nothing
        Me.ucGrayScaleSweepRegion.SweepType = M7000.ucMeasureSweepRegion.eSweepType._GraySweep
        Me.ucGrayScaleSweepRegion.TabIndex = 24
        Me.ucGrayScaleSweepRegion.UnitType = M7000.ucSweepSetting.eUnitType._Voltage
        '
        'tlpPanel2
        '
        Me.tlpPanel2.ColumnCount = 4
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.Controls.Add(Me.btnMeasPoint, 3, 1)
        Me.tlpPanel2.Controls.Add(Me.btnEdit, 2, 1)
        Me.tlpPanel2.Controls.Add(Me.btnADD, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Location = New System.Drawing.Point(8, 16)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(563, 454)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Location = New System.Drawing.Point(423, 407)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(108, 36)
        Me.btnMeasPoint.TabIndex = 23
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(283, 407)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(73, 36)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(3, 407)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(73, 36)
        Me.btnADD.TabIndex = 24
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(143, 407)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(73, 36)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(541, 381)
        Me.Panel1.TabIndex = 0
        '
        'ucDispRcpGrayScaleSweep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpGrayScaleSweep"
        Me.Size = New System.Drawing.Size(617, 829)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbSelectSweepMode.ResumeLayout(False)
        Me.gbSelectSweepMode.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ucGrayScaleSweepRegion As M7000.ucMeasureSweepRegion
    Friend WithEvents gbSelectSweepMode As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rdoUserPattern As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBlue As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGreen As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRed As System.Windows.Forms.RadioButton
    Friend WithEvents ucGrayScaleSweepTable As M7000.ucMeasureSweepRegion

End Class
