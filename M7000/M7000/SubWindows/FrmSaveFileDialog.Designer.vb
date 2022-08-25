<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaveFileDialog
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMasterFileName = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbJIGnum = New System.Windows.Forms.Label()
        Me.lbformat1 = New System.Windows.Forms.Label()
        Me.lbformat2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.txtSavePath = New System.Windows.Forms.TextBox()
        Me.BtnSaveFilePath = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMasterFileName)
        Me.GroupBox3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(17, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(607, 59)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Master Key"
        '
        'txtMasterFileName
        '
        Me.txtMasterFileName.Location = New System.Drawing.Point(15, 21)
        Me.txtMasterFileName.Name = "txtMasterFileName"
        Me.txtMasterFileName.Size = New System.Drawing.Size(579, 21)
        Me.txtMasterFileName.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbJIGnum)
        Me.Panel2.Controls.Add(Me.lbformat1)
        Me.Panel2.Controls.Add(Me.lbformat2)
        Me.Panel2.Location = New System.Drawing.Point(17, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(607, 272)
        Me.Panel2.TabIndex = 29
        '
        'lbJIGnum
        '
        Me.lbJIGnum.AutoSize = True
        Me.lbJIGnum.Location = New System.Drawing.Point(5, 10)
        Me.lbJIGnum.Name = "lbJIGnum"
        Me.lbJIGnum.Size = New System.Drawing.Size(42, 12)
        Me.lbJIGnum.TabIndex = 36
        Me.lbJIGnum.Text = "Label5"
        Me.lbJIGnum.Visible = False
        '
        'lbformat1
        '
        Me.lbformat1.AutoSize = True
        Me.lbformat1.Location = New System.Drawing.Point(68, 10)
        Me.lbformat1.Name = "lbformat1"
        Me.lbformat1.Size = New System.Drawing.Size(42, 12)
        Me.lbformat1.TabIndex = 31
        Me.lbformat1.Text = "Label5"
        Me.lbformat1.Visible = False
        '
        'lbformat2
        '
        Me.lbformat2.AutoSize = True
        Me.lbformat2.Location = New System.Drawing.Point(346, 11)
        Me.lbformat2.Name = "lbformat2"
        Me.lbformat2.Size = New System.Drawing.Size(42, 12)
        Me.lbformat2.TabIndex = 34
        Me.lbformat2.Text = "Label5"
        Me.lbformat2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label88)
        Me.GroupBox2.Controls.Add(Me.txtSavePath)
        Me.GroupBox2.Controls.Add(Me.BtnSaveFilePath)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 384)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 76)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SavePath"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 12)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Save Path : "
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(-85, 57)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(38, 12)
        Me.Label88.TabIndex = 12
        Me.Label88.Text = "Path :"
        '
        'txtSavePath
        '
        Me.txtSavePath.Location = New System.Drawing.Point(130, 34)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.Size = New System.Drawing.Size(352, 21)
        Me.txtSavePath.TabIndex = 11
        '
        'BtnSaveFilePath
        '
        Me.BtnSaveFilePath.Location = New System.Drawing.Point(486, 33)
        Me.BtnSaveFilePath.Name = "BtnSaveFilePath"
        Me.BtnSaveFilePath.Size = New System.Drawing.Size(70, 23)
        Me.BtnSaveFilePath.TabIndex = 10
        Me.BtnSaveFilePath.Text = "..."
        Me.BtnSaveFilePath.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(493, 473)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(131, 48)
        Me.BtnCancel.TabIndex = 32
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Location = New System.Drawing.Point(345, 473)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(131, 48)
        Me.BtnOK.TabIndex = 31
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 12)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Old File Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 12)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "New File Name"
        '
        'FrmSaveFileDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 528)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmSaveFileDialog"
        Me.Text = "Save File"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMasterFileName As System.Windows.Forms.TextBox
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbJIGnum As System.Windows.Forms.Label
    Friend WithEvents lbformat1 As System.Windows.Forms.Label
    Friend WithEvents lbformat2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
    Friend WithEvents BtnSaveFilePath As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
