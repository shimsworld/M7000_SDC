<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCA310ManualMeasUI
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.ucCA310DataListview = New M7000.ucDispListView()
        Me.btnDataSave = New System.Windows.Forms.Button()
        Me.btnListviewClear = New System.Windows.Forms.Button()
        Me.btnCA310Meas = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ucCA310DataListview
        '
        Me.ucCA310DataListview.ColHeader = New String() {"No.", "Mode.", "Area.", "Volt"}
        Me.ucCA310DataListview.ColHeaderWidthRatio = "25,25,25,25"
        Me.ucCA310DataListview.FullRawSelection = True
        Me.ucCA310DataListview.Location = New System.Drawing.Point(12, 80)
        Me.ucCA310DataListview.Name = "ucCA310DataListview"
        Me.ucCA310DataListview.Size = New System.Drawing.Size(630, 166)
        Me.ucCA310DataListview.TabIndex = 1
        Me.ucCA310DataListview.UseCheckBoxex = False
        '
        'btnDataSave
        '
        Me.btnDataSave.Location = New System.Drawing.Point(190, 20)
        Me.btnDataSave.Name = "btnDataSave"
        Me.btnDataSave.Size = New System.Drawing.Size(153, 43)
        Me.btnDataSave.TabIndex = 3
        Me.btnDataSave.Text = "Save"
        Me.btnDataSave.UseVisualStyleBackColor = True
        '
        'btnListviewClear
        '
        Me.btnListviewClear.Location = New System.Drawing.Point(489, 20)
        Me.btnListviewClear.Name = "btnListviewClear"
        Me.btnListviewClear.Size = New System.Drawing.Size(153, 43)
        Me.btnListviewClear.TabIndex = 4
        Me.btnListviewClear.Text = "Clear"
        Me.btnListviewClear.UseVisualStyleBackColor = True
        '
        'btnCA310Meas
        '
        Me.btnCA310Meas.Location = New System.Drawing.Point(12, 20)
        Me.btnCA310Meas.Name = "btnCA310Meas"
        Me.btnCA310Meas.Size = New System.Drawing.Size(141, 43)
        Me.btnCA310Meas.TabIndex = 5
        Me.btnCA310Meas.Text = "Meas."
        Me.btnCA310Meas.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(420, 252)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(222, 35)
        Me.btnClose.TabIndex = 96
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCA310ManualMeasUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 297)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCA310Meas)
        Me.Controls.Add(Me.btnListviewClear)
        Me.Controls.Add(Me.btnDataSave)
        Me.Controls.Add(Me.ucCA310DataListview)
        Me.Name = "frmCA310ManualMeasUI"
        Me.Text = "frmCA310"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucCA310DataListview As M7000.ucDispListView
    Friend WithEvents btnDataSave As System.Windows.Forms.Button
    Friend WithEvents btnListviewClear As System.Windows.Forms.Button
    Friend WithEvents btnCA310Meas As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
