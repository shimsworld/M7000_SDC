<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpViewingAngle
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
        Me.gbCommon = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLumiCorrection = New System.Windows.Forms.TextBox()
        Me.lblBias1Unit = New System.Windows.Forms.Label()
        Me.lblBias1 = New System.Windows.Forms.Label()
        Me.tbBias1 = New System.Windows.Forms.TextBox()
        Me.lblBiasMode = New System.Windows.Forms.Label()
        Me.cbBiasMode = New System.Windows.Forms.ComboBox()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMeasPoint = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ucDispKeithley = New CSMULib.ucKeithleySMUSettings()
        Me.ucSweepSetting = New M7000.ucSweepSetting()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.gbCommon.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'spContainer
        '
        Me.spContainer.Location = New System.Drawing.Point(11, 3)
        Me.spContainer.Name = "spContainer"
        Me.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.AutoScroll = True
        Me.spContainer.Panel1.Controls.Add(Me.gbCommon)
        Me.spContainer.Panel1MinSize = 315
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.tlpPanel2)
        Me.spContainer.Size = New System.Drawing.Size(527, 835)
        Me.spContainer.SplitterDistance = 343
        Me.spContainer.TabIndex = 3
        '
        'gbCommon
        '
        Me.gbCommon.Controls.Add(Me.Label1)
        Me.gbCommon.Controls.Add(Me.Label2)
        Me.gbCommon.Controls.Add(Me.tbLumiCorrection)
        Me.gbCommon.Controls.Add(Me.lblBias1Unit)
        Me.gbCommon.Controls.Add(Me.lblBias1)
        Me.gbCommon.Controls.Add(Me.tbBias1)
        Me.gbCommon.Controls.Add(Me.lblBiasMode)
        Me.gbCommon.Controls.Add(Me.cbBiasMode)
        Me.gbCommon.Controls.Add(Me.ucSweepSetting)
        Me.gbCommon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCommon.Location = New System.Drawing.Point(3, 4)
        Me.gbCommon.MinimumSize = New System.Drawing.Size(440, 334)
        Me.gbCommon.Name = "gbCommon"
        Me.gbCommon.Size = New System.Drawing.Size(521, 334)
        Me.gbCommon.TabIndex = 0
        Me.gbCommon.TabStop = False
        Me.gbCommon.Text = "Common"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "%"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Lumi Correction"
        '
        'tbLumiCorrection
        '
        Me.tbLumiCorrection.BackColor = System.Drawing.SystemColors.Control
        Me.tbLumiCorrection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLumiCorrection.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbLumiCorrection.Location = New System.Drawing.Point(109, 88)
        Me.tbLumiCorrection.Name = "tbLumiCorrection"
        Me.tbLumiCorrection.Size = New System.Drawing.Size(62, 21)
        Me.tbLumiCorrection.TabIndex = 44
        Me.tbLumiCorrection.Text = "0"
        Me.tbLumiCorrection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBias1Unit
        '
        Me.lblBias1Unit.AutoSize = True
        Me.lblBias1Unit.Location = New System.Drawing.Point(176, 59)
        Me.lblBias1Unit.Name = "lblBias1Unit"
        Me.lblBias1Unit.Size = New System.Drawing.Size(15, 15)
        Me.lblBias1Unit.TabIndex = 43
        Me.lblBias1Unit.Text = "V"
        '
        'lblBias1
        '
        Me.lblBias1.AutoSize = True
        Me.lblBias1.Location = New System.Drawing.Point(72, 59)
        Me.lblBias1.Name = "lblBias1"
        Me.lblBias1.Size = New System.Drawing.Size(32, 15)
        Me.lblBias1.TabIndex = 42
        Me.lblBias1.Text = "Bias"
        '
        'tbBias1
        '
        Me.tbBias1.BackColor = System.Drawing.SystemColors.Control
        Me.tbBias1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBias1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbBias1.Location = New System.Drawing.Point(109, 58)
        Me.tbBias1.Name = "tbBias1"
        Me.tbBias1.Size = New System.Drawing.Size(62, 21)
        Me.tbBias1.TabIndex = 41
        Me.tbBias1.Text = "0"
        Me.tbBias1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBiasMode
        '
        Me.lblBiasMode.AutoSize = True
        Me.lblBiasMode.Location = New System.Drawing.Point(39, 30)
        Me.lblBiasMode.Name = "lblBiasMode"
        Me.lblBiasMode.Size = New System.Drawing.Size(66, 15)
        Me.lblBiasMode.TabIndex = 37
        Me.lblBiasMode.Text = "Bias Mode"
        '
        'cbBiasMode
        '
        Me.cbBiasMode.FormattingEnabled = True
        Me.cbBiasMode.Location = New System.Drawing.Point(110, 27)
        Me.cbBiasMode.Name = "cbBiasMode"
        Me.cbBiasMode.Size = New System.Drawing.Size(61, 23)
        Me.cbBiasMode.TabIndex = 36
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
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Controls.Add(Me.btnADD, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Location = New System.Drawing.Point(6, 3)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(498, 457)
        Me.tlpPanel2.TabIndex = 2
        '
        'btnMeasPoint
        '
        Me.btnMeasPoint.Location = New System.Drawing.Point(375, 406)
        Me.btnMeasPoint.Name = "btnMeasPoint"
        Me.btnMeasPoint.Size = New System.Drawing.Size(93, 39)
        Me.btnMeasPoint.TabIndex = 23
        Me.btnMeasPoint.Text = "Set Meas. Point"
        Me.btnMeasPoint.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(251, 406)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(63, 39)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(127, 406)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(63, 39)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(3, 406)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(63, 39)
        Me.btnADD.TabIndex = 24
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.ucDispKeithley)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 352)
        Me.Panel1.TabIndex = 0
        '
        'ucDispKeithley
        '
        Me.ucDispKeithley.AutoScroll = True
        Me.ucDispKeithley.Location = New System.Drawing.Point(3, 14)
        Me.ucDispKeithley.Name = "ucDispKeithley"
        Me.ucDispKeithley.Size = New System.Drawing.Size(448, 288)
        Me.ucDispKeithley.TabIndex = 6
        '
        'ucSweepSetting
        '
        Me.ucSweepSetting.AutoScroll = True
        Me.ucSweepSetting.Location = New System.Drawing.Point(212, 13)
        Me.ucSweepSetting.MainTitle = "Sweep Settings"
        Me.ucSweepSetting.MaximumSize = New System.Drawing.Size(289, 432)
        Me.ucSweepSetting.MinimumSize = New System.Drawing.Size(226, 217)
        Me.ucSweepSetting.Name = "ucSweepSetting"
        Me.ucSweepSetting.Size = New System.Drawing.Size(289, 315)
        Me.ucSweepSetting.SweepType = M7000.ucSweepSetting.eSweepType._Standard
        Me.ucSweepSetting.TabIndex = 0
        '
        'ucDispRcpViewingAngle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spContainer)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpViewingAngle"
        Me.Size = New System.Drawing.Size(565, 871)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.gbCommon.ResumeLayout(False)
        Me.gbCommon.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents gbCommon As System.Windows.Forms.GroupBox
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMeasPoint As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents ucSweepSetting As M7000.ucSweepSetting
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ucDispKeithley As CSMULib.ucKeithleySMUSettings
    Friend WithEvents lblBias1Unit As System.Windows.Forms.Label
    Friend WithEvents lblBias1 As System.Windows.Forms.Label
    Friend WithEvents tbBias1 As System.Windows.Forms.TextBox
    Friend WithEvents lblBiasMode As System.Windows.Forms.Label
    Friend WithEvents cbBiasMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbLumiCorrection As System.Windows.Forms.TextBox

End Class
