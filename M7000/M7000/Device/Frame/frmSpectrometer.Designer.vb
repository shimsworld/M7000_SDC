<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpectrometer
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
        Me.btnCreateObj = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCreateObj
        '
        Me.btnCreateObj.Location = New System.Drawing.Point(32, 548)
        Me.btnCreateObj.Name = "btnCreateObj"
        Me.btnCreateObj.Size = New System.Drawing.Size(204, 43)
        Me.btnCreateObj.TabIndex = 10
        Me.btnCreateObj.Text = "Device Initialization"
        Me.btnCreateObj.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(12, 686)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(568, 18)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "CS1000A, CS1000 : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8" & _
            ", Terminator : CR"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(722, 651)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(522, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "AVANTES : USB"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 668)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(522, 18)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "CS2000 : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, Termina" & _
            "tor : CR"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 616)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(522, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "PR705 : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, Terminat" & _
            "or : CR+LF"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(722, 616)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(522, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "SR-3AR : USB"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 650)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(699, 18)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "PR655 : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, Send Ter" & _
            "minator : CR, Recive Terminator : CR+LF"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(722, 633)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(571, 18)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "SR-UL2 : USB , Serial - BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, " & _
            "Terminator : CR+LF "
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 633)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(592, 17)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "PR650 : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, Recive T" & _
            "erminator : CR+LF"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(722, 668)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(522, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "LABSPHERE : USB"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(722, 686)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(571, 18)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "DarsaPro : Serial, BPS : 9600, Parity : None, Stop bit : One, Data Len : 8, Termi" & _
            "nator : CR+LF "
        '
        'frmSpectrometer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1297, 759)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCreateObj)
        Me.Name = "frmSpectrometer"
        Me.Text = "frmSpectrometer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCreateObj As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
