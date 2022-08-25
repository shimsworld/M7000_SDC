<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPGSendRecieveLog
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
        Me.LogSend = New ucSingleList()
        Me.txt_mline = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_LogReset = New System.Windows.Forms.Button()
        Me.LogRcv = New ucSingleList()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogSend
        '
        Me.LogSend.AutoScroll = True
        Me.LogSend.ColHeader = New String() {"No", "Rcv String"}
        Me.LogSend.ColHeaderWidthRatio = "20,120"
        Me.LogSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogSend.Location = New System.Drawing.Point(3, 17)
        Me.LogSend.Name = "LogSend"
        Me.LogSend.Size = New System.Drawing.Size(472, 563)
        Me.LogSend.TabIndex = 0
        '
        'txt_mline
        '
        Me.txt_mline.Location = New System.Drawing.Point(6, 83)
        Me.txt_mline.Multiline = True
        Me.txt_mline.Name = "txt_mline"
        Me.txt_mline.Size = New System.Drawing.Size(952, 100)
        Me.txt_mline.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LogSend)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 583)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Send Str"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LogRcv)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 583)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recice Str"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_mline)
        Me.GroupBox3.Controls.Add(Me.btn_LogReset)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(967, 193)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'frmPGSendRecieveLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 808)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmPGSendRecieveLog"
        Me.Text = "frmPGSendRecieceLog"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LogSend As ucSingleList
    Friend WithEvents txt_mline As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_LogReset As System.Windows.Forms.Button
    Friend WithEvents LogRcv As ucSingleList
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
