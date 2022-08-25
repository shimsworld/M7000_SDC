<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSGSendRecieveLog
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
        Me.txt_mline = New System.Windows.Forms.TextBox()
        Me.btn_LogReset = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LogRcv = New ucSingleList()
        Me.LogSend = New ucSingleList()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_mline)
        Me.GroupBox3.Controls.Add(Me.btn_LogReset)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(967, 193)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'txt_mline
        '
        Me.txt_mline.Location = New System.Drawing.Point(6, 83)
        Me.txt_mline.Multiline = True
        Me.txt_mline.Name = "txt_mline"
        Me.txt_mline.Size = New System.Drawing.Size(952, 100)
        Me.txt_mline.TabIndex = 7
        '
        'btn_LogReset
        '
        Me.btn_LogReset.Location = New System.Drawing.Point(814, 20)
        Me.btn_LogReset.Name = "btn_LogReset"
        Me.btn_LogReset.Size = New System.Drawing.Size(147, 57)
        Me.btn_LogReset.TabIndex = 6
        Me.btn_LogReset.Text = "CLEAR"
        Me.btn_LogReset.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LogRcv)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 583)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recice Str"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LogSend)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 583)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Send Str"
        '
        'LogRcv
        '
        Me.LogRcv.AutoScroll = True
        Me.LogRcv.ColHeader = New String() {"No", "Rcv String"}
        Me.LogRcv.ColHeaderWidthRatio = "20,120"
        Me.LogRcv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogRcv.Location = New System.Drawing.Point(3, 17)
        Me.LogRcv.Name = "LogRcv"
        Me.LogRcv.Size = New System.Drawing.Size(472, 563)
        Me.LogRcv.TabIndex = 1
        '
        'LogSend
        '
        Me.LogSend.AutoScroll = True
        Me.LogSend.ColHeader = New String() {"No", "Send String"}
        Me.LogSend.ColHeaderWidthRatio = "20,120"
        Me.LogSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogSend.Location = New System.Drawing.Point(3, 17)
        Me.LogSend.Name = "LogSend"
        Me.LogSend.Size = New System.Drawing.Size(472, 563)
        Me.LogSend.TabIndex = 0
        '
        'frmSendRecieveLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 812)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmSendRecieveLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSendRecieveLog"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_mline As System.Windows.Forms.TextBox
    Friend WithEvents btn_LogReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LogRcv As ucSingleList
    Friend WithEvents LogSend As ucSingleList
End Class
