<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogInWnd
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLogInPW = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.lblLogInStatus = New System.Windows.Forms.Label()
        Me.chkEnableSystemMenu = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNewpassSet = New System.Windows.Forms.Button()
        Me.txtExistPass = New System.Windows.Forms.TextBox()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLogInPW)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnLogIn)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 66)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'txtLogInPW
        '
        Me.txtLogInPW.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogInPW.Location = New System.Drawing.Point(143, 23)
        Me.txtLogInPW.Multiline = True
        Me.txtLogInPW.Name = "txtLogInPW"
        Me.txtLogInPW.Size = New System.Drawing.Size(119, 29)
        Me.txtLogInPW.TabIndex = 8
        Me.txtLogInPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 35)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLogIn
        '
        Me.btnLogIn.Location = New System.Drawing.Point(320, 23)
        Me.btnLogIn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(92, 29)
        Me.btnLogIn.TabIndex = 8
        Me.btnLogIn.Text = "Log-In"
        Me.btnLogIn.UseVisualStyleBackColor = True
        '
        'lblLogInStatus
        '
        Me.lblLogInStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLogInStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLogInStatus.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLogInStatus.Location = New System.Drawing.Point(7, 75)
        Me.lblLogInStatus.Name = "lblLogInStatus"
        Me.lblLogInStatus.Size = New System.Drawing.Size(420, 25)
        Me.lblLogInStatus.TabIndex = 9
        Me.lblLogInStatus.Text = "Please, Log-In"
        Me.lblLogInStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkEnableSystemMenu
        '
        Me.chkEnableSystemMenu.Location = New System.Drawing.Point(11, 105)
        Me.chkEnableSystemMenu.Name = "chkEnableSystemMenu"
        Me.chkEnableSystemMenu.Size = New System.Drawing.Size(156, 31)
        Me.chkEnableSystemMenu.TabIndex = 11
        Me.chkEnableSystemMenu.Text = "Setting new password"
        Me.chkEnableSystemMenu.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNewpassSet)
        Me.GroupBox2.Controls.Add(Me.txtExistPass)
        Me.GroupBox2.Controls.Add(Me.txtNewPass)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(418, 101)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Password to change"
        '
        'btnNewpassSet
        '
        Me.btnNewpassSet.Location = New System.Drawing.Point(320, 22)
        Me.btnNewpassSet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNewpassSet.Name = "btnNewpassSet"
        Me.btnNewpassSet.Size = New System.Drawing.Size(92, 29)
        Me.btnNewpassSet.TabIndex = 9
        Me.btnNewpassSet.Text = "Change"
        Me.btnNewpassSet.UseVisualStyleBackColor = True
        '
        'txtExistPass
        '
        Me.txtExistPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExistPass.Location = New System.Drawing.Point(143, 29)
        Me.txtExistPass.Multiline = True
        Me.txtExistPass.Name = "txtExistPass"
        Me.txtExistPass.Size = New System.Drawing.Size(119, 22)
        Me.txtExistPass.TabIndex = 13
        Me.txtExistPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNewPass
        '
        Me.txtNewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPass.Location = New System.Drawing.Point(143, 58)
        Me.txtNewPass.Multiline = True
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(119, 22)
        Me.txtNewPass.TabIndex = 12
        Me.txtNewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 35)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "New password"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 35)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Existing password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmLogInWnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(437, 136)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkEnableSystemMenu)
        Me.Controls.Add(Me.lblLogInStatus)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLogInWnd"
        Me.Text = "System Administrator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLogInPW As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLogIn As System.Windows.Forms.Button
    Friend WithEvents lblLogInStatus As System.Windows.Forms.Label
    Friend WithEvents chkEnableSystemMenu As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewpassSet As System.Windows.Forms.Button
    Friend WithEvents txtExistPass As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
