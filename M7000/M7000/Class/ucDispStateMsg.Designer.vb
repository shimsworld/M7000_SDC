<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispStateMsg
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
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.pnControl = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.listStateMessage = New System.Windows.Forms.ListView()
        Me.gbMain.SuspendLayout()
        Me.pnControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.pnControl)
        Me.gbMain.Controls.Add(Me.listStateMessage)
        Me.gbMain.Location = New System.Drawing.Point(43, 55)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(625, 241)
        Me.gbMain.TabIndex = 0
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "State Message"
        '
        'pnControl
        '
        Me.pnControl.Controls.Add(Me.btnClear)
        Me.pnControl.Location = New System.Drawing.Point(505, 29)
        Me.pnControl.Name = "pnControl"
        Me.pnControl.Size = New System.Drawing.Size(104, 173)
        Me.pnControl.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(0, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 36)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'listStateMessage
        '
        Me.listStateMessage.Location = New System.Drawing.Point(59, 37)
        Me.listStateMessage.Name = "listStateMessage"
        Me.listStateMessage.Size = New System.Drawing.Size(424, 165)
        Me.listStateMessage.TabIndex = 0
        Me.listStateMessage.UseCompatibleStateImageBehavior = False
        '
        'ucDispStateMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbMain)
        Me.DoubleBuffered = True
        Me.Name = "ucDispStateMsg"
        Me.Size = New System.Drawing.Size(977, 347)
        Me.gbMain.ResumeLayout(False)
        Me.pnControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents pnControl As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents listStateMessage As System.Windows.Forms.ListView

End Class
