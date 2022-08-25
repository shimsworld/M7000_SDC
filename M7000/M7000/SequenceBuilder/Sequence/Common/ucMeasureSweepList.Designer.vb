<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMeasureSweepList
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
        Me.gbSweepList = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ucListMeasSweep = New M7000.ucDispListView()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblValueUnit = New System.Windows.Forms.Label()
        Me.tbBias = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnListDown = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnListUP = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tbStepBias = New System.Windows.Forms.TextBox()
        Me.gbSweepList.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSweepList
        '
        Me.gbSweepList.Controls.Add(Me.btnSave)
        Me.gbSweepList.Controls.Add(Me.ucListMeasSweep)
        Me.gbSweepList.Controls.Add(Me.btnLoad)
        Me.gbSweepList.Controls.Add(Me.lblValueUnit)
        Me.gbSweepList.Controls.Add(Me.tbBias)
        Me.gbSweepList.Controls.Add(Me.btnAdd)
        Me.gbSweepList.Controls.Add(Me.btnListDown)
        Me.gbSweepList.Controls.Add(Me.Label1)
        Me.gbSweepList.Controls.Add(Me.btnListUP)
        Me.gbSweepList.Controls.Add(Me.btnClear)
        Me.gbSweepList.Controls.Add(Me.btnDelete)
        Me.gbSweepList.Location = New System.Drawing.Point(3, 3)
        Me.gbSweepList.Name = "gbSweepList"
        Me.gbSweepList.Size = New System.Drawing.Size(260, 215)
        Me.gbSweepList.TabIndex = 50
        Me.gbSweepList.TabStop = False
        Me.gbSweepList.Text = "Measurement Sweep List"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Silver
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(195, 109)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Visible = False
        '
        'ucListMeasSweep
        '
        Me.ucListMeasSweep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListMeasSweep.AutoScroll = True
        Me.ucListMeasSweep.ColHeader = New String() {"No.", "Value"}
        Me.ucListMeasSweep.ColHeaderWidthRatio = "30,70"
        Me.ucListMeasSweep.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListMeasSweep.FullRawSelection = True
        Me.ucListMeasSweep.HideSelection = False
        Me.ucListMeasSweep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListMeasSweep.LabelEdit = True
        Me.ucListMeasSweep.LabelWrap = True
        Me.ucListMeasSweep.Location = New System.Drawing.Point(6, 52)
        Me.ucListMeasSweep.Name = "ucListMeasSweep"
        Me.ucListMeasSweep.Size = New System.Drawing.Size(183, 157)
        Me.ucListMeasSweep.TabIndex = 8
        Me.ucListMeasSweep.UseCheckBoxex = False
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackColor = System.Drawing.Color.Silver
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(195, 138)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(60, 23)
        Me.btnLoad.TabIndex = 5
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = False
        Me.btnLoad.Visible = False
        '
        'lblValueUnit
        '
        Me.lblValueUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblValueUnit.AutoSize = True
        Me.lblValueUnit.Location = New System.Drawing.Point(148, 27)
        Me.lblValueUnit.Name = "lblValueUnit"
        Me.lblValueUnit.Size = New System.Drawing.Size(15, 15)
        Me.lblValueUnit.TabIndex = 23
        Me.lblValueUnit.Text = "V"
        '
        'tbBias
        '
        Me.tbBias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbBias.BackColor = System.Drawing.SystemColors.Control
        Me.tbBias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBias.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbBias.Location = New System.Drawing.Point(70, 24)
        Me.tbBias.Name = "tbBias"
        Me.tbBias.Size = New System.Drawing.Size(74, 21)
        Me.tbBias.TabIndex = 0
        Me.tbBias.Text = "0"
        Me.tbBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(195, 18)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnListDown
        '
        Me.btnListDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListDown.BackColor = System.Drawing.Color.Silver
        Me.btnListDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListDown.Location = New System.Drawing.Point(195, 169)
        Me.btnListDown.Name = "btnListDown"
        Me.btnListDown.Size = New System.Drawing.Size(60, 23)
        Me.btnListDown.TabIndex = 6
        Me.btnListDown.Text = "DOWN"
        Me.btnListDown.UseVisualStyleBackColor = False
        Me.btnListDown.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Bias"
        '
        'btnListUP
        '
        Me.btnListUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnListUP.BackColor = System.Drawing.Color.Silver
        Me.btnListUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListUP.Location = New System.Drawing.Point(195, 180)
        Me.btnListUP.Name = "btnListUP"
        Me.btnListUP.Size = New System.Drawing.Size(60, 23)
        Me.btnListUP.TabIndex = 7
        Me.btnListUP.Text = "UP"
        Me.btnListUP.UseVisualStyleBackColor = False
        Me.btnListUP.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(195, 80)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Silver
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(195, 50)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'tbStepBias
        '
        Me.tbStepBias.Location = New System.Drawing.Point(82, 16)
        Me.tbStepBias.Name = "tbStepBias"
        Me.tbStepBias.Size = New System.Drawing.Size(62, 20)
        Me.tbStepBias.TabIndex = 21
        Me.tbStepBias.Text = "0"
        Me.tbStepBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ucMeasureSweepList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbSweepList)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(337, 221)
        Me.MinimumSize = New System.Drawing.Size(229, 221)
        Me.Name = "ucMeasureSweepList"
        Me.Size = New System.Drawing.Size(337, 221)
        Me.gbSweepList.ResumeLayout(False)
        Me.gbSweepList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSweepList As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ucListMeasSweep As M7000.ucDispListView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lblValueUnit As System.Windows.Forms.Label
    Friend WithEvents tbBias As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnListDown As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnListUP As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents tbStepBias As System.Windows.Forms.TextBox

End Class
