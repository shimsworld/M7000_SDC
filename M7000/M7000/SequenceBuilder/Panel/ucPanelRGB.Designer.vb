<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPanelRGB
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
        Me.gbRGBSignal = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbBlue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbGreen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbRed = New System.Windows.Forms.TextBox()
        Me.lblStepValueUnit = New System.Windows.Forms.Label()
        Me.gbRGBSignal.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbRGBSignal
        '
        Me.gbRGBSignal.Controls.Add(Me.Label3)
        Me.gbRGBSignal.Controls.Add(Me.tbBlue)
        Me.gbRGBSignal.Controls.Add(Me.Label4)
        Me.gbRGBSignal.Controls.Add(Me.Label1)
        Me.gbRGBSignal.Controls.Add(Me.tbGreen)
        Me.gbRGBSignal.Controls.Add(Me.Label2)
        Me.gbRGBSignal.Controls.Add(Me.Label7)
        Me.gbRGBSignal.Controls.Add(Me.tbRed)
        Me.gbRGBSignal.Controls.Add(Me.lblStepValueUnit)
        Me.gbRGBSignal.Location = New System.Drawing.Point(13, 15)
        Me.gbRGBSignal.Name = "gbRGBSignal"
        Me.gbRGBSignal.Size = New System.Drawing.Size(347, 46)
        Me.gbRGBSignal.TabIndex = 0
        Me.gbRGBSignal.TabStop = False
        Me.gbRGBSignal.Text = "RGB Signal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 12)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "B :"
        '
        'tbBlue
        '
        Me.tbBlue.Location = New System.Drawing.Point(267, 17)
        Me.tbBlue.Name = "tbBlue"
        Me.tbBlue.Size = New System.Drawing.Size(54, 21)
        Me.tbBlue.TabIndex = 44
        Me.tbBlue.Text = "0"
        Me.tbBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(325, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 12)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "V"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(124, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 12)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "G :"
        '
        'tbGreen
        '
        Me.tbGreen.Location = New System.Drawing.Point(152, 17)
        Me.tbGreen.Name = "tbGreen"
        Me.tbGreen.Size = New System.Drawing.Size(54, 21)
        Me.tbGreen.TabIndex = 41
        Me.tbGreen.Text = "0"
        Me.tbGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 12)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "V"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 12)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "R :"
        '
        'tbRed
        '
        Me.tbRed.Location = New System.Drawing.Point(37, 17)
        Me.tbRed.Name = "tbRed"
        Me.tbRed.Size = New System.Drawing.Size(54, 21)
        Me.tbRed.TabIndex = 38
        Me.tbRed.Text = "0"
        Me.tbRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStepValueUnit
        '
        Me.lblStepValueUnit.AutoSize = True
        Me.lblStepValueUnit.Location = New System.Drawing.Point(94, 20)
        Me.lblStepValueUnit.Name = "lblStepValueUnit"
        Me.lblStepValueUnit.Size = New System.Drawing.Size(13, 12)
        Me.lblStepValueUnit.TabIndex = 39
        Me.lblStepValueUnit.Text = "V"
        '
        'ucPanelRGB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbRGBSignal)
        Me.Name = "ucPanelRGB"
        Me.Size = New System.Drawing.Size(369, 76)
        Me.gbRGBSignal.ResumeLayout(False)
        Me.gbRGBSignal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbRGBSignal As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbBlue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbGreen As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbRed As System.Windows.Forms.TextBox
    Friend WithEvents lblStepValueUnit As System.Windows.Forms.Label

End Class
