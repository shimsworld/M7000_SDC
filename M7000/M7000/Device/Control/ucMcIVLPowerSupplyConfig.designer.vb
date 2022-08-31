<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMcIVLPowerSupplyConfig
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
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblIVLPSDev5 = New System.Windows.Forms.Label()
        Me.lblIVLPSDev4 = New System.Windows.Forms.Label()
        Me.lblIVLPSDev3 = New System.Windows.Forms.Label()
        Me.lblIVLPSDev2 = New System.Windows.Forms.Label()
        Me.lblIVLPSDev1 = New System.Windows.Forms.Label()
        Me.UcConfigRs232_05 = New CCommLib.ucConfigRs232()
        Me.UcConfigRs232_04 = New CCommLib.ucConfigRs232()
        Me.UcConfigRs232_03 = New CCommLib.ucConfigRs232()
        Me.UcConfigRs232_02 = New CCommLib.ucConfigRs232()
        Me.UcConfigRs232_01 = New CCommLib.ucConfigRs232()
        Me.SuspendLayout()
        '
        'lblIVLPSDev5
        '
        Me.lblIVLPSDev5.AutoSize = True
        Me.lblIVLPSDev5.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIVLPSDev5.ForeColor = System.Drawing.Color.Black
        Me.lblIVLPSDev5.Location = New System.Drawing.Point(1102, 13)
        Me.lblIVLPSDev5.Name = "lblIVLPSDev5"
        Me.lblIVLPSDev5.Size = New System.Drawing.Size(45, 20)
        Me.lblIVLPSDev5.TabIndex = 28
        Me.lblIVLPSDev5.Text = "Vss"
        '
        'lblIVLPSDev4
        '
        Me.lblIVLPSDev4.AutoSize = True
        Me.lblIVLPSDev4.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIVLPSDev4.ForeColor = System.Drawing.Color.Black
        Me.lblIVLPSDev4.Location = New System.Drawing.Point(844, 13)
        Me.lblIVLPSDev4.Name = "lblIVLPSDev4"
        Me.lblIVLPSDev4.Size = New System.Drawing.Size(45, 20)
        Me.lblIVLPSDev4.TabIndex = 27
        Me.lblIVLPSDev4.Text = "Vdd"
        '
        'lblIVLPSDev3
        '
        Me.lblIVLPSDev3.AutoSize = True
        Me.lblIVLPSDev3.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIVLPSDev3.ForeColor = System.Drawing.Color.Black
        Me.lblIVLPSDev3.Location = New System.Drawing.Point(611, 10)
        Me.lblIVLPSDev3.Name = "lblIVLPSDev3"
        Me.lblIVLPSDev3.Size = New System.Drawing.Size(22, 20)
        Me.lblIVLPSDev3.TabIndex = 26
        Me.lblIVLPSDev3.Text = "B"
        '
        'lblIVLPSDev2
        '
        Me.lblIVLPSDev2.AutoSize = True
        Me.lblIVLPSDev2.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIVLPSDev2.ForeColor = System.Drawing.Color.Black
        Me.lblIVLPSDev2.Location = New System.Drawing.Point(360, 13)
        Me.lblIVLPSDev2.Name = "lblIVLPSDev2"
        Me.lblIVLPSDev2.Size = New System.Drawing.Size(24, 20)
        Me.lblIVLPSDev2.TabIndex = 25
        Me.lblIVLPSDev2.Text = "G"
        '
        'lblIVLPSDev1
        '
        Me.lblIVLPSDev1.AutoSize = True
        Me.lblIVLPSDev1.Font = New System.Drawing.Font("굴림", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIVLPSDev1.ForeColor = System.Drawing.Color.Black
        Me.lblIVLPSDev1.Location = New System.Drawing.Point(112, 10)
        Me.lblIVLPSDev1.Name = "lblIVLPSDev1"
        Me.lblIVLPSDev1.Size = New System.Drawing.Size(22, 20)
        Me.lblIVLPSDev1.TabIndex = 24
        Me.lblIVLPSDev1.Text = "R"
        '
        'UcConfigRs232_05
        '
        Me.UcConfigRs232_05.BAUDRATE = 19200
        Me.UcConfigRs232_05.COMPORT = "COM3"
        Me.UcConfigRs232_05.DATABIT = 8
        Me.UcConfigRs232_05.Location = New System.Drawing.Point(999, 36)
        Me.UcConfigRs232_05.Name = "UcConfigRs232_05"
        Me.UcConfigRs232_05.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232_05.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_05.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_05.Size = New System.Drawing.Size(241, 202)
        Me.UcConfigRs232_05.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232_05.TabIndex = 23
        Me.UcConfigRs232_05.Title = "RS232"
        '
        'UcConfigRs232_04
        '
        Me.UcConfigRs232_04.BAUDRATE = 19200
        Me.UcConfigRs232_04.COMPORT = "COM3"
        Me.UcConfigRs232_04.DATABIT = 8
        Me.UcConfigRs232_04.Location = New System.Drawing.Point(752, 36)
        Me.UcConfigRs232_04.Name = "UcConfigRs232_04"
        Me.UcConfigRs232_04.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232_04.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_04.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_04.Size = New System.Drawing.Size(241, 202)
        Me.UcConfigRs232_04.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232_04.TabIndex = 22
        Me.UcConfigRs232_04.Title = "RS232"
        '
        'UcConfigRs232_03
        '
        Me.UcConfigRs232_03.BAUDRATE = 19200
        Me.UcConfigRs232_03.COMPORT = "COM3"
        Me.UcConfigRs232_03.DATABIT = 8
        Me.UcConfigRs232_03.Location = New System.Drawing.Point(504, 36)
        Me.UcConfigRs232_03.Name = "UcConfigRs232_03"
        Me.UcConfigRs232_03.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232_03.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_03.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_03.Size = New System.Drawing.Size(241, 202)
        Me.UcConfigRs232_03.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232_03.TabIndex = 21
        Me.UcConfigRs232_03.Title = "RS232"
        '
        'UcConfigRs232_02
        '
        Me.UcConfigRs232_02.BAUDRATE = 19200
        Me.UcConfigRs232_02.COMPORT = "COM3"
        Me.UcConfigRs232_02.DATABIT = 8
        Me.UcConfigRs232_02.Location = New System.Drawing.Point(257, 36)
        Me.UcConfigRs232_02.Name = "UcConfigRs232_02"
        Me.UcConfigRs232_02.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232_02.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_02.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_02.Size = New System.Drawing.Size(241, 202)
        Me.UcConfigRs232_02.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232_02.TabIndex = 20
        Me.UcConfigRs232_02.Title = "RS232"
        '
        'UcConfigRs232_01
        '
        Me.UcConfigRs232_01.BAUDRATE = 19200
        Me.UcConfigRs232_01.COMPORT = "COM3"
        Me.UcConfigRs232_01.DATABIT = 8
        Me.UcConfigRs232_01.Location = New System.Drawing.Point(10, 36)
        Me.UcConfigRs232_01.Name = "UcConfigRs232_01"
        Me.UcConfigRs232_01.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232_01.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_01.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.UcConfigRs232_01.Size = New System.Drawing.Size(241, 202)
        Me.UcConfigRs232_01.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232_01.TabIndex = 19
        Me.UcConfigRs232_01.Title = "RS232"
        '
        'ucMcIVLPowerSupplyConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblIVLPSDev5)
        Me.Controls.Add(Me.lblIVLPSDev4)
        Me.Controls.Add(Me.lblIVLPSDev3)
        Me.Controls.Add(Me.lblIVLPSDev2)
        Me.Controls.Add(Me.lblIVLPSDev1)
        Me.Controls.Add(Me.UcConfigRs232_05)
        Me.Controls.Add(Me.UcConfigRs232_04)
        Me.Controls.Add(Me.UcConfigRs232_03)
        Me.Controls.Add(Me.UcConfigRs232_02)
        Me.Controls.Add(Me.UcConfigRs232_01)
        Me.Name = "ucMcIVLPowerSupplyConfig"
        Me.Size = New System.Drawing.Size(1275, 259)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIVLPSDev5 As Label
    Friend WithEvents lblIVLPSDev4 As Label
    Friend WithEvents lblIVLPSDev3 As Label
    Friend WithEvents lblIVLPSDev2 As Label
    Friend WithEvents lblIVLPSDev1 As Label
    Friend WithEvents UcConfigRs232_05 As CCommLib.ucConfigRs232
    Friend WithEvents UcConfigRs232_04 As CCommLib.ucConfigRs232
    Friend WithEvents UcConfigRs232_03 As CCommLib.ucConfigRs232
    Friend WithEvents UcConfigRs232_02 As CCommLib.ucConfigRs232
    Friend WithEvents UcConfigRs232_01 As CCommLib.ucConfigRs232
End Class
