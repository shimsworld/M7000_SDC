<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpAging
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
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.ucMeasureIntervalSetting = New M7000.ucMeasureIntervalSetting()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ucRefPDSetting = New M7000.ucRefPDSetting()
        Me.ucTestEndParam = New M7000.ucTestEndParam()
        Me.rbNoStress = New System.Windows.Forms.RadioButton()
        Me.rbStress = New System.Windows.Forms.RadioButton()
        Me.gbLifeTimeEndSourceSetting = New System.Windows.Forms.GroupBox()
        Me.rbLifeTimeEndBiasON = New System.Windows.Forms.RadioButton()
        Me.rbLifeTimeEndBiasOFF = New System.Windows.Forms.RadioButton()
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.gbLifetimeCommon = New System.Windows.Forms.GroupBox()
        Me.gbStressMode = New System.Windows.Forms.GroupBox()
        Me.tlpPanel2.SuspendLayout()
        Me.gbLifeTimeEndSourceSetting.SuspendLayout()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.gbLifetimeCommon.SuspendLayout()
        Me.gbStressMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Location = New System.Drawing.Point(363, 393)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(93, 39)
        Me.btnMeasPoint.TabIndex = 13
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        Me.btnMeasPoint.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(123, 393)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(63, 39)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'ucMeasureIntervalSetting
        '
        Me.ucMeasureIntervalSetting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucMeasureIntervalSetting.Location = New System.Drawing.Point(5, 116)
        Me.ucMeasureIntervalSetting.Name = "ucMeasureIntervalSetting"
        Me.ucMeasureIntervalSetting.Setting = New M7000.ucMeasureIntervalSetting.sSetTime(-1) {}
        Me.ucMeasureIntervalSetting.Size = New System.Drawing.Size(232, 189)
        Me.ucMeasureIntervalSetting.TabIndex = 7
        Me.ucMeasureIntervalSetting.Visible = False
        '
        'tlpPanel2
        '
        Me.tlpPanel2.BackColor = System.Drawing.Color.Transparent
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
        Me.tlpPanel2.Location = New System.Drawing.Point(7, 17)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(483, 444)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(243, 393)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(63, 39)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(3, 393)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(63, 39)
        Me.btnADD.TabIndex = 10
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 378)
        Me.Panel1.TabIndex = 9
        '
        'ucRefPDSetting
        '
        Me.ucRefPDSetting.Location = New System.Drawing.Point(313, 20)
        Me.ucRefPDSetting.Name = "ucRefPDSetting"
        Me.ucRefPDSetting.Size = New System.Drawing.Size(179, 88)
        Me.ucRefPDSetting.TabIndex = 3
        Me.ucRefPDSetting.Visible = False
        '
        'ucTestEndParam
        '
        Me.ucTestEndParam.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucTestEndParam.Location = New System.Drawing.Point(245, 116)
        Me.ucTestEndParam.Name = "ucTestEndParam"
        Me.ucTestEndParam.Settings = New M7000.ucTestEndParam.sTestEndParam(-1) {}
        Me.ucTestEndParam.Size = New System.Drawing.Size(248, 189)
        Me.ucTestEndParam.TabIndex = 8
        Me.ucTestEndParam.Title = "End Conditions"
        '
        'rbNoStress
        '
        Me.rbNoStress.AutoSize = True
        Me.rbNoStress.Location = New System.Drawing.Point(17, 24)
        Me.rbNoStress.Name = "rbNoStress"
        Me.rbNoStress.Size = New System.Drawing.Size(98, 16)
        Me.rbNoStress.TabIndex = 1
        Me.rbNoStress.Text = "보관(NoBias)"
        Me.rbNoStress.UseVisualStyleBackColor = True
        '
        'rbStress
        '
        Me.rbStress.AutoSize = True
        Me.rbStress.Checked = True
        Me.rbStress.Location = New System.Drawing.Point(17, 51)
        Me.rbStress.Name = "rbStress"
        Me.rbStress.Size = New System.Drawing.Size(82, 16)
        Me.rbStress.TabIndex = 2
        Me.rbStress.TabStop = True
        Me.rbStress.Text = "동작(Bias)"
        Me.rbStress.UseVisualStyleBackColor = True
        '
        'gbLifeTimeEndSourceSetting
        '
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasON)
        Me.gbLifeTimeEndSourceSetting.Controls.Add(Me.rbLifeTimeEndBiasOFF)
        Me.gbLifeTimeEndSourceSetting.Location = New System.Drawing.Point(175, 20)
        Me.gbLifeTimeEndSourceSetting.Name = "gbLifeTimeEndSourceSetting"
        Me.gbLifeTimeEndSourceSetting.Size = New System.Drawing.Size(101, 88)
        Me.gbLifeTimeEndSourceSetting.TabIndex = 4
        Me.gbLifeTimeEndSourceSetting.TabStop = False
        Me.gbLifeTimeEndSourceSetting.Text = "종료 동작"
        '
        'rbLifeTimeEndBiasON
        '
        Me.rbLifeTimeEndBiasON.AutoSize = True
        Me.rbLifeTimeEndBiasON.Location = New System.Drawing.Point(16, 51)
        Me.rbLifeTimeEndBiasON.Name = "rbLifeTimeEndBiasON"
        Me.rbLifeTimeEndBiasON.Size = New System.Drawing.Size(70, 16)
        Me.rbLifeTimeEndBiasON.TabIndex = 6
        Me.rbLifeTimeEndBiasON.Text = "Bias ON"
        Me.rbLifeTimeEndBiasON.UseVisualStyleBackColor = True
        '
        'rbLifeTimeEndBiasOFF
        '
        Me.rbLifeTimeEndBiasOFF.AutoSize = True
        Me.rbLifeTimeEndBiasOFF.Checked = True
        Me.rbLifeTimeEndBiasOFF.Location = New System.Drawing.Point(16, 24)
        Me.rbLifeTimeEndBiasOFF.Name = "rbLifeTimeEndBiasOFF"
        Me.rbLifeTimeEndBiasOFF.Size = New System.Drawing.Size(75, 16)
        Me.rbLifeTimeEndBiasOFF.TabIndex = 5
        Me.rbLifeTimeEndBiasOFF.TabStop = True
        Me.rbLifeTimeEndBiasOFF.Text = "Bias OFF"
        Me.rbLifeTimeEndBiasOFF.UseVisualStyleBackColor = True
        '
        'spContainer
        '
        Me.spContainer.Location = New System.Drawing.Point(5, 8)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel1.Controls.Add(Me.gbLifetimeCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(507, 867)
        Me.spContainer.SplitterDistance = 403
        Me.spContainer.TabIndex = 2
        '
        'gbLifetimeCommon
        '
        Me.gbLifetimeCommon.Controls.Add(Me.ucMeasureIntervalSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucRefPDSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.ucTestEndParam)
        Me.gbLifetimeCommon.Controls.Add(Me.gbLifeTimeEndSourceSetting)
        Me.gbLifetimeCommon.Controls.Add(Me.gbStressMode)
        Me.gbLifetimeCommon.Location = New System.Drawing.Point(3, 3)
        Me.gbLifetimeCommon.MinimumSize = New System.Drawing.Size(440, 334)
        Me.gbLifetimeCommon.Name = "gbLifetimeCommon"
        Me.gbLifetimeCommon.Size = New System.Drawing.Size(501, 360)
        Me.gbLifetimeCommon.TabIndex = 0
        Me.gbLifetimeCommon.TabStop = False
        Me.gbLifetimeCommon.Text = "Common"
        '
        'gbStressMode
        '
        Me.gbStressMode.Controls.Add(Me.rbStress)
        Me.gbStressMode.Controls.Add(Me.rbNoStress)
        Me.gbStressMode.Location = New System.Drawing.Point(7, 20)
        Me.gbStressMode.Name = "gbStressMode"
        Me.gbStressMode.Size = New System.Drawing.Size(120, 88)
        Me.gbStressMode.TabIndex = 0
        Me.gbStressMode.TabStop = False
        Me.gbStressMode.Text = "MODE"
        '
        'ucDispRcpAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpAging"
        Me.Size = New System.Drawing.Size(516, 883)
        Me.tlpPanel2.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.ResumeLayout(False)
        Me.gbLifeTimeEndSourceSetting.PerformLayout()
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbLifetimeCommon.ResumeLayout(False)
        Me.gbStressMode.ResumeLayout(False)
        Me.gbStressMode.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents ucMeasureIntervalSetting As M7000.ucMeasureIntervalSetting
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ucRefPDSetting As M7000.ucRefPDSetting
    Friend WithEvents ucTestEndParam As M7000.ucTestEndParam
    Public WithEvents rbNoStress As System.Windows.Forms.RadioButton
    Public WithEvents rbStress As System.Windows.Forms.RadioButton
    Protected WithEvents gbLifeTimeEndSourceSetting As System.Windows.Forms.GroupBox
    Public WithEvents rbLifeTimeEndBiasON As System.Windows.Forms.RadioButton
    Public WithEvents rbLifeTimeEndBiasOFF As System.Windows.Forms.RadioButton
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents gbLifetimeCommon As System.Windows.Forms.GroupBox
    Protected WithEvents gbStressMode As System.Windows.Forms.GroupBox

End Class
