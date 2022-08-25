<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTempSetting
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
        Me.gbTemperature = New System.Windows.Forms.GroupBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtModeTime = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTargetTemp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbTemperature.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTemperature
        '
        Me.gbTemperature.Controls.Add(Me.btnUpdate)
        Me.gbTemperature.Controls.Add(Me.Label2)
        Me.gbTemperature.Controls.Add(Me.btnAdd)
        Me.gbTemperature.Controls.Add(Me.txtModeTime)
        Me.gbTemperature.Controls.Add(Me.Label4)
        Me.gbTemperature.Controls.Add(Me.Label3)
        Me.gbTemperature.Controls.Add(Me.txtTargetTemp)
        Me.gbTemperature.Controls.Add(Me.Label1)
        Me.gbTemperature.Location = New System.Drawing.Point(46, 30)
        Me.gbTemperature.Name = "gbTemperature"
        Me.gbTemperature.Size = New System.Drawing.Size(231, 109)
        Me.gbTemperature.TabIndex = 0
        Me.gbTemperature.TabStop = False
        Me.gbTemperature.Text = "Temperature"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Silver
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Location = New System.Drawing.Point(108, 72)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(94, 27)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "UPDATE List"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(132, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Sec"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(8, 72)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(94, 27)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "ADD List"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtModeTime
        '
        Me.txtModeTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtModeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModeTime.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtModeTime.Location = New System.Drawing.Point(64, 46)
        Me.txtModeTime.Name = "txtModeTime"
        Me.txtModeTime.Size = New System.Drawing.Size(65, 21)
        Me.txtModeTime.TabIndex = 2
        Me.txtModeTime.Text = "0"
        Me.txtModeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = " Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "℃"
        '
        'txtTargetTemp
        '
        Me.txtTargetTemp.BackColor = System.Drawing.SystemColors.Control
        Me.txtTargetTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTargetTemp.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtTargetTemp.Location = New System.Drawing.Point(64, 19)
        Me.txtTargetTemp.Name = "txtTargetTemp"
        Me.txtTargetTemp.Size = New System.Drawing.Size(65, 21)
        Me.txtTargetTemp.TabIndex = 1
        Me.txtTargetTemp.Text = "0"
        Me.txtTargetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Target"
        '
        'ucTempSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbTemperature)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucTempSetting"
        Me.Size = New System.Drawing.Size(345, 274)
        Me.gbTemperature.ResumeLayout(False)
        Me.gbTemperature.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTemperature As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTargetTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtModeTime As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button

End Class
