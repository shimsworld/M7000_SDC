<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispImage
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
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.cbTitle = New System.Windows.Forms.CheckBox()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImage
        '
        Me.pbImage.BackColor = System.Drawing.Color.Black
        Me.pbImage.Location = New System.Drawing.Point(3, 23)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(163, 213)
        Me.pbImage.TabIndex = 0
        Me.pbImage.TabStop = False
        '
        'cbTitle
        '
        Me.cbTitle.AutoSize = True
        Me.cbTitle.BackColor = System.Drawing.Color.Transparent
        Me.cbTitle.Location = New System.Drawing.Point(3, 3)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(87, 14)
        Me.cbTitle.TabIndex = 1
        Me.cbTitle.Text = "Image Title"
        Me.cbTitle.UseVisualStyleBackColor = False
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.cbTitle, 0, 0)
        Me.tlpMain.Controls.Add(Me.pbImage, 0, 1)
        Me.tlpMain.Location = New System.Drawing.Point(17, 25)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(371, 423)
        Me.tlpMain.TabIndex = 2
        '
        'ucDispImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispImage"
        Me.Size = New System.Drawing.Size(495, 506)
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents cbTitle As System.Windows.Forms.CheckBox
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel

End Class
