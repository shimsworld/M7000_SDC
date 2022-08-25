<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpImageSticking
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
        Me.gbLifetimeCommon = New System.Windows.Forms.GroupBox()
        Me.ucMeasureIntervalSetting = New M7000.ucMeasureIntervalSetting()
        Me.ucRefPDSetting = New M7000.ucRefPDSetting()
        Me.ucTestEndParam = New M7000.ucTestEndParam()
        Me.gbLifeTimeEndSourceSetting = New System.Windows.Forms.GroupBox()
        Me.rbLifeTimeEndBiasON = New System.Windows.Forms.RadioButton()
        Me.rbLifeTimeEndBiasOFF = New System.Windows.Forms.RadioButton()
        Me.gbStressMode = New System.Windows.Forms.GroupBox()
        Me.rbStress = New System.Windows.Forms.RadioButton()
        Me.rbNoStress = New System.Windows.Forms.RadioButton()
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
        Me.gbLifetimeCommon.SuspendLayout()
        Me.gbLifeTimeEndSourceSetting.SuspendLayout()
        Me.gbStressMode.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spContainer.Location = New System.Drawing.Point(16, 3)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.Controls.Add(Me.gbLifetimeCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(594, 796)
        Me.spContainer.SplitterDistance = 324
        Me.spContainer.TabIndex = 3
        '
        'gbLifetimeCommon
        '
        Me.gbLifetimeCommon.Controls.Add(Me.ucMeasureIntervalSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucRefPDSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucTestEndParam)
        Me.gbLifetimeCommon.Controls.Add(Me.gbLifeTimeEndSourceSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.gbStressMode)
        Me.gbLifetimeCommon.Location = New System.Drawing.Point(3, 3)
        Me.gbLifetimeCommon.MinimumSize = New System.Drawing.Size(513, 308)
        Me.gbLifetimeCommon.Name = "gbLifetimeCommon"
        Me.gbLifetimeCommon.Size = New System.Drawing.Size(568, 308)
        Me.gbLifetimeCommon.TabIndex = 0
        Me.gbLifetimeCommon.TabStop = False
        Me.gbLifetimeCommon.Text = "Common"
        '
        'ucMeasureIntervalSetting
        '
        Me.ucMeasureIntervalSetting.Location = New System.Drawing.Point(8, 107)
        Me.ucMeasureIntervalSetting.Name = "ucMeasureIntervalSetting"
        Me.ucMeasureIntervalSetting.Setting = Nothing
        Me.ucMeasureIntervalSetting.Size = New System.Drawing.Size(273, 192)
        Me.ucMeasureIntervalSetting.TabIndex = 2
        '
        'ucRefPDSetting
        '
        Me.ucRefPDSetting.Location = New System.Drawing.Point(134, 20)
        Me.ucRefPDSetting.Name = "ucRefPDSetting"
        Me.ucRefPDSetting.Size = New System.Drawing.Size(201, 81)
        Me.ucRefPDSetting.TabIndex = 1
        '
        'ucTestEndParam
        '
        Me.ucTestEndParam.Location = New System.Drawing.Point(288, 107)
        Me.ucTestEndParam.Name = "ucTestEndParam"
        Me.ucTestEndParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestEndParam.Size = New System.Drawing.Size(261, 192)
        Me.ucTestEndParam.TabIndex = 1
        Me.ucTestEndParam.Title = "TEST END"
        '
        'gbLifeTimeEndSourceSetting
        '
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasON)
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasOFF)
        Me.gbLifeTimeEndSourceSetting.Location = New System.Drawing.Point(341, 20)
        Me.gbLifeTimeEndSourceSetting.Name = "gbLifeTimeEndSourceSetting"
        Me.gbLifeTimeEndSourceSetting.Size = New System.Drawing.Size(118, 81)
        Me.gbLifeTimeEndSourceSetting.TabIndex = 22
        Me.gbLifeTimeEndSourceSetting.TabStop = False
        Me.gbLifeTimeEndSourceSetting.Text = "End Bias"
        '
        'rbLifeTimeEndBiasON
        '
        Me.rbLifeTimeEndBiasON.AutoSize = True
        Me.rbLifeTimeEndBiasON.Location = New System.Drawing.Point(19, 47)
        Me.rbLifeTimeEndBiasON.Name = "rbLifeTimeEndBiasON"
        Me.rbLifeTimeEndBiasON.Size = New System.Drawing.Size(70, 16)
        Me.rbLifeTimeEndBiasON.TabIndex = 1
        Me.rbLifeTimeEndBiasON.TabStop = True
        Me.rbLifeTimeEndBiasON.Text = "Bias ON"
        Me.rbLifeTimeEndBiasON.UseVisualStyleBackColor = True
        '
        'rbLifeTimeEndBiasOFF
        '
        Me.rbLifeTimeEndBiasOFF.AutoSize = True
        Me.rbLifeTimeEndBiasOFF.Location = New System.Drawing.Point(19, 22)
        Me.rbLifeTimeEndBiasOFF.Name = "rbLifeTimeEndBiasOFF"
        Me.rbLifeTimeEndBiasOFF.Size = New System.Drawing.Size(75, 16)
        Me.rbLifeTimeEndBiasOFF.TabIndex = 0
        Me.rbLifeTimeEndBiasOFF.TabStop = True
        Me.rbLifeTimeEndBiasOFF.Text = "Bias OFF"
        Me.rbLifeTimeEndBiasOFF.UseVisualStyleBackColor = True
        '
        'gbStressMode
        '
        Me.gbStressMode.Controls.Add(Me.rbStress)
        Me.gbStressMode.Controls.Add(Me.rbNoStress)
        Me.gbStressMode.Location = New System.Drawing.Point(6, 20)
        Me.gbStressMode.Name = "gbStressMode"
        Me.gbStressMode.Size = New System.Drawing.Size(122, 81)
        Me.gbStressMode.TabIndex = 21
        Me.gbStressMode.TabStop = False
        Me.gbStressMode.Text = "MODE"
        '
        'rbStress
        '
        Me.rbStress.AutoSize = True
        Me.rbStress.Location = New System.Drawing.Point(10, 47)
        Me.rbStress.Name = "rbStress"
        Me.rbStress.Size = New System.Drawing.Size(77, 16)
        Me.rbStress.TabIndex = 1
        Me.rbStress.TabStop = True
        Me.rbStress.Text = "Operation"
        Me.rbStress.UseVisualStyleBackColor = True
        '
        'rbNoStress
        '
        Me.rbNoStress.AutoSize = True
        Me.rbNoStress.Location = New System.Drawing.Point(10, 22)
        Me.rbNoStress.Name = "rbNoStress"
        Me.rbNoStress.Size = New System.Drawing.Size(69, 16)
        Me.rbNoStress.TabIndex = 0
        Me.rbNoStress.TabStop = True
        Me.rbNoStress.Text = "Keeping"
        Me.rbNoStress.UseVisualStyleBackColor = True
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
        'ucDispRcpImageSticking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpImageSticking"
        Me.Size = New System.Drawing.Size(640, 820)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbLifetimeCommon.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.PerformLayout()
        Me.gbStressMode.ResumeLayout(False)
        Me.gbStressMode.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents gbLifetimeCommon As System.Windows.Forms.GroupBox
    Friend WithEvents ucMeasureIntervalSetting As M7000.ucMeasureIntervalSetting
    Friend WithEvents ucRefPDSetting As M7000.ucRefPDSetting
    Friend WithEvents ucTestEndParam As M7000.ucTestEndParam
    Protected WithEvents gbLifeTimeEndSourceSetting As System.Windows.Forms.GroupBox
    Public WithEvents rbLifeTimeEndBiasON As System.Windows.Forms.RadioButton
    Public WithEvents rbLifeTimeEndBiasOFF As System.Windows.Forms.RadioButton
    Protected WithEvents gbStressMode As System.Windows.Forms.GroupBox
    Public WithEvents rbStress As System.Windows.Forms.RadioButton
    Public WithEvents rbNoStress As System.Windows.Forms.RadioButton
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
