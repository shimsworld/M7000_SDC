<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTHCControl
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboComList = New System.Windows.Forms.ComboBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnMeasurement = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbHumidity = New System.Windows.Forms.Label()
        Me.lbTemp = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comm Port"
        '
        'cboComList
        '
        Me.cboComList.FormattingEnabled = True
        Me.cboComList.Location = New System.Drawing.Point(95, 33)
        Me.cboComList.Name = "cboComList"
        Me.cboComList.Size = New System.Drawing.Size(121, 20)
        Me.cboComList.TabIndex = 1
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(255, 30)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(122, 23)
        Me.btnConnection.TabIndex = 2
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(255, 59)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(122, 23)
        Me.btnDisconnection.TabIndex = 3
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnMeasurement
        '
        Me.btnMeasurement.Location = New System.Drawing.Point(253, 92)
        Me.btnMeasurement.Name = "btnMeasurement"
        Me.btnMeasurement.Size = New System.Drawing.Size(122, 23)
        Me.btnMeasurement.TabIndex = 4
        Me.btnMeasurement.Text = "Measurement"
        Me.btnMeasurement.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnMeasurement)
        Me.GroupBox1.Controls.Add(Me.cboComList)
        Me.GroupBox1.Controls.Add(Me.btnDisconnection)
        Me.GroupBox1.Controls.Add(Me.btnConnection)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 130)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lbHumidity)
        Me.GroupBox2.Controls.Add(Me.lbTemp)
        Me.GroupBox2.Location = New System.Drawing.Point(53, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(569, 153)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(450, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(439, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 40)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 'C"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbHumidity
        '
        Me.lbHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbHumidity.Location = New System.Drawing.Point(253, 85)
        Me.lbHumidity.Name = "lbHumidity"
        Me.lbHumidity.Size = New System.Drawing.Size(180, 40)
        Me.lbHumidity.TabIndex = 1
        Me.lbHumidity.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.lbHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTemp
        '
        Me.lbTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTemp.Location = New System.Drawing.Point(253, 29)
        Me.lbTemp.Name = "lbTemp"
        Me.lbTemp.Size = New System.Drawing.Size(180, 40)
        Me.lbTemp.TabIndex = 0
        Me.lbTemp.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        Me.lbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 367)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMain"
        Me.Text = "THERMO - HYGRO MONITOR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboComList As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents btnMeasurement As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbHumidity As System.Windows.Forms.Label
    Friend WithEvents lbTemp As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
