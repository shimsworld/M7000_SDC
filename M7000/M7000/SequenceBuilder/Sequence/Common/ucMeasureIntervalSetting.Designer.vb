<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMeasureIntervalSetting
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
        Me.gbTime = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ucListMeasInterval = New M7000.ucDispListView()
        Me.txtChangeTime = New System.Windows.Forms.TextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIntervalTime = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnListDown = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnListUP = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.gbTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTime
        '
        Me.gbTime.Controls.Add(Me.btnSave)
        Me.gbTime.Controls.Add(Me.ucListMeasInterval)
        Me.gbTime.Controls.Add(Me.txtChangeTime)
        Me.gbTime.Controls.Add(Me.btnLoad)
        Me.gbTime.Controls.Add(Me.Label3)
        Me.gbTime.Controls.Add(Me.txtIntervalTime)
        Me.gbTime.Controls.Add(Me.btnAdd)
        Me.gbTime.Controls.Add(Me.Label4)
        Me.gbTime.Controls.Add(Me.btnListDown)
        Me.gbTime.Controls.Add(Me.Label1)
        Me.gbTime.Controls.Add(Me.Label2)
        Me.gbTime.Controls.Add(Me.btnListUP)
        Me.gbTime.Controls.Add(Me.btnClear)
        Me.gbTime.Controls.Add(Me.btnDelete)
        Me.gbTime.Location = New System.Drawing.Point(53, 25)
        Me.gbTime.Name = "gbTime"
        Me.gbTime.Size = New System.Drawing.Size(229, 257)
        Me.gbTime.TabIndex = 0
        Me.gbTime.TabStop = False
        Me.gbTime.Text = "Measurement Interval Time"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(127, 188)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'ucListMeasInterval
        '
        Me.ucListMeasInterval.ColHeader = New String() {"Interval", "Change"}
        Me.ucListMeasInterval.ColHeaderWidthRatio = "50,50"
        Me.ucListMeasInterval.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListMeasInterval.FullRawSelection = True
        Me.ucListMeasInterval.HideSelection = False
        Me.ucListMeasInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListMeasInterval.LabelEdit = True
        Me.ucListMeasInterval.LabelWrap = True
        Me.ucListMeasInterval.Location = New System.Drawing.Point(17, 70)
        Me.ucListMeasInterval.Name = "ucListMeasInterval"
        Me.ucListMeasInterval.Size = New System.Drawing.Size(203, 109)
        Me.ucListMeasInterval.TabIndex = 10
        Me.ucListMeasInterval.UseCheckBoxex = False
        '
        'txtChangeTime
        '
        Me.txtChangeTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtChangeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeTime.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtChangeTime.Location = New System.Drawing.Point(73, 44)
        Me.txtChangeTime.Name = "txtChangeTime"
        Me.txtChangeTime.Size = New System.Drawing.Size(57, 21)
        Me.txtChangeTime.TabIndex = 2
        Me.txtChangeTime.Text = "0"
        Me.txtChangeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(82, 188)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(60, 23)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        Me.btnLoad.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(133, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 12)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "hrs"
        '
        'txtIntervalTime
        '
        Me.txtIntervalTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtIntervalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIntervalTime.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtIntervalTime.Location = New System.Drawing.Point(73, 19)
        Me.txtIntervalTime.Name = "txtIntervalTime"
        Me.txtIntervalTime.Size = New System.Drawing.Size(57, 21)
        Me.txtIntervalTime.TabIndex = 1
        Me.txtIntervalTime.Text = "0"
        Me.txtIntervalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(160, 14)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(133, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "hrs"
        '
        'btnListDown
        '
        Me.btnListDown.Location = New System.Drawing.Point(17, 188)
        Me.btnListDown.Name = "btnListDown"
        Me.btnListDown.Size = New System.Drawing.Size(60, 23)
        Me.btnListDown.TabIndex = 8
        Me.btnListDown.Text = "DOWN"
        Me.btnListDown.UseVisualStyleBackColor = True
        Me.btnListDown.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Interval"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Change"
        '
        'btnListUP
        '
        Me.btnListUP.Location = New System.Drawing.Point(17, 214)
        Me.btnListUP.Name = "btnListUP"
        Me.btnListUP.Size = New System.Drawing.Size(60, 23)
        Me.btnListUP.TabIndex = 9
        Me.btnListUP.Text = "UP"
        Me.btnListUP.UseVisualStyleBackColor = True
        Me.btnListUP.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(71, 214)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Silver
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(160, 41)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'ucMeasureIntervalSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbTime)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMeasureIntervalSetting"
        Me.Size = New System.Drawing.Size(546, 418)
        Me.gbTime.ResumeLayout(False)
        Me.gbTime.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTime As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ucListMeasInterval As ucDispListView
    Friend WithEvents txtChangeTime As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIntervalTime As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnListDown As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnListUP As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button

End Class
