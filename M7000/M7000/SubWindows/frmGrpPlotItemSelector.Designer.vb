<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrpPlotItemSelector
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
        Me.dispList = New ucDispListView()
        Me.btnChangeColor = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dispList
        '
        Me.dispList.ColHeader = New String() {"No.", "Item Index", "Color"}
        Me.dispList.ColHeaderWidthRatio = "15,50,30"
        Me.dispList.Location = New System.Drawing.Point(3, 12)
        Me.dispList.Name = "dispList"
        Me.dispList.Size = New System.Drawing.Size(272, 285)
        Me.dispList.TabIndex = 0
        Me.dispList.UseCheckBoxex = True
        '
        'btnChangeColor
        '
        Me.btnChangeColor.Location = New System.Drawing.Point(280, 167)
        Me.btnChangeColor.Name = "btnChangeColor"
        Me.btnChangeColor.Size = New System.Drawing.Size(121, 46)
        Me.btnChangeColor.TabIndex = 1
        Me.btnChangeColor.Text = "Change"
        Me.btnChangeColor.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(280, 219)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(121, 36)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnCancel.Location = New System.Drawing.Point(280, 261)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 36)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(294, 34)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(94, 83)
        Me.lblColor.TabIndex = 4
        '
        'frmGrpPlotItemSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 301)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnChangeColor)
        Me.Controls.Add(Me.dispList)
        Me.Name = "frmGrpPlotItemSelector"
        Me.Text = "Select Line Color"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dispList As ucDispListView
    Friend WithEvents btnChangeColor As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblColor As System.Windows.Forms.Label
End Class
