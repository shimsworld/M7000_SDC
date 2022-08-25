<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDispMultiCtrlOfJIGLayout
    Inherits ucDispMultiCtrlCommonNode

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.scJIG = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'scJIG
        '
        Me.scJIG.AutoScroll = True
        Me.scJIG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.scJIG.Location = New System.Drawing.Point(250, 215)
        Me.scJIG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.scJIG.Name = "scJIG"
        Me.scJIG.Size = New System.Drawing.Size(287, 442)
        Me.scJIG.TabIndex = 1
        '
        'ucDispMultiCtrlOfJIGLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Channel = New Integer() {0}
        Me.Controls.Add(Me.scJIG)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucDispMultiCtrlOfJIGLayout"
        Me.Size = New System.Drawing.Size(744, 774)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents scJIG As System.Windows.Forms.Panel
End Class
