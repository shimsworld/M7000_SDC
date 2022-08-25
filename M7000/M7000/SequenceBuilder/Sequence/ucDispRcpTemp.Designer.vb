<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpTemp
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStableTime = New System.Windows.Forms.TextBox()
        Me.lblStabilizationTime = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTargetTemp = New System.Windows.Forms.TextBox()
        Me.lblTargetTemp = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.tlpPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbTemperature.SuspendLayout()
        Me.tlpPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTemperature
        '
        Me.gbTemperature.Controls.Add(Me.Label2)
        Me.gbTemperature.Controls.Add(Me.txtStableTime)
        Me.gbTemperature.Controls.Add(Me.lblStabilizationTime)
        Me.gbTemperature.Controls.Add(Me.Label3)
        Me.gbTemperature.Controls.Add(Me.txtTargetTemp)
        Me.gbTemperature.Controls.Add(Me.lblTargetTemp)
        Me.gbTemperature.Location = New System.Drawing.Point(3, 12)
        Me.gbTemperature.Name = "gbTemperature"
        Me.gbTemperature.Size = New System.Drawing.Size(457, 113)
        Me.gbTemperature.TabIndex = 1
        Me.gbTemperature.TabStop = False
        Me.gbTemperature.Text = "Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Min"
        '
        'txtStableTime
        '
        Me.txtStableTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtStableTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStableTime.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtStableTime.Location = New System.Drawing.Point(144, 63)
        Me.txtStableTime.Name = "txtStableTime"
        Me.txtStableTime.Size = New System.Drawing.Size(65, 21)
        Me.txtStableTime.TabIndex = 8
        Me.txtStableTime.Text = "0"
        Me.txtStableTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStabilizationTime
        '
        Me.lblStabilizationTime.AutoSize = True
        Me.lblStabilizationTime.Location = New System.Drawing.Point(23, 66)
        Me.lblStabilizationTime.Name = "lblStabilizationTime"
        Me.lblStabilizationTime.Size = New System.Drawing.Size(113, 15)
        Me.lblStabilizationTime.TabIndex = 6
        Me.lblStabilizationTime.Text = "Stabilization Time :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "℃"
        '
        'txtTargetTemp
        '
        Me.txtTargetTemp.BackColor = System.Drawing.SystemColors.Control
        Me.txtTargetTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTargetTemp.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtTargetTemp.Location = New System.Drawing.Point(144, 27)
        Me.txtTargetTemp.Name = "txtTargetTemp"
        Me.txtTargetTemp.Size = New System.Drawing.Size(65, 21)
        Me.txtTargetTemp.TabIndex = 3
        Me.txtTargetTemp.Text = "0"
        Me.txtTargetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTargetTemp
        '
        Me.lblTargetTemp.AutoSize = True
        Me.lblTargetTemp.Location = New System.Drawing.Point(12, 30)
        Me.lblTargetTemp.Name = "lblTargetTemp"
        Me.lblTargetTemp.Size = New System.Drawing.Size(125, 15)
        Me.lblTargetTemp.TabIndex = 1
        Me.lblTargetTemp.Text = "Target Temperature :"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(143, 407)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(94, 27)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(3, 407)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(94, 27)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'tlpPanel2
        '
        Me.tlpPanel2.ColumnCount = 4
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpPanel2.Controls.Add(Me.btnUpdate, 1, 1)
        Me.tlpPanel2.Controls.Add(Me.btnAdd, 0, 1)
        Me.tlpPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpPanel2.Location = New System.Drawing.Point(5, 4)
        Me.tlpPanel2.Name = "tlpPanel2"
        Me.tlpPanel2.RowCount = 2
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpPanel2.Size = New System.Drawing.Size(563, 454)
        Me.tlpPanel2.TabIndex = 3
        '
        'Panel1
        '
        Me.tlpPanel2.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.gbTemperature)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 388)
        Me.Panel1.TabIndex = 0
        '
        'ucDispRcpTemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tlpPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucDispRcpTemp"
        Me.Size = New System.Drawing.Size(575, 467)
        Me.gbTemperature.ResumeLayout(False)
        Me.gbTemperature.PerformLayout()
        Me.tlpPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTemperature As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtStableTime As System.Windows.Forms.TextBox
    Friend WithEvents lblStabilizationTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTargetTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblTargetTemp As System.Windows.Forms.Label
    Friend WithEvents tlpPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
