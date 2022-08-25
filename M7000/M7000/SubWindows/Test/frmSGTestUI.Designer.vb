<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSGTestUI
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
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.btnMeas = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbELVDD_I = New System.Windows.Forms.TextBox()
        Me.tbPD_I = New System.Windows.Forms.TextBox()
        Me.tbELVSS_T = New System.Windows.Forms.TextBox()
        Me.tbELVDD_T = New System.Windows.Forms.TextBox()
        Me.tbELVSS_I = New System.Windows.Forms.TextBox()
        Me.cbSelGroup = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbChannel = New System.Windows.Forms.TextBox()
        Me.tbDevice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbSystempCh = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_off = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UcDispSignalGenerator1 = New M7000.ucDispSignalGenerator()
        Me.SuspendLayout()
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(205, 5)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(105, 34)
        Me.btnConnection.TabIndex = 1
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(316, 6)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(105, 34)
        Me.btnDisconnection.TabIndex = 2
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(763, 5)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(105, 34)
        Me.btnSet.TabIndex = 3
        Me.btnSet.Text = "SET"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'btnMeas
        '
        Me.btnMeas.Location = New System.Drawing.Point(1124, 5)
        Me.btnMeas.Name = "btnMeas"
        Me.btnMeas.Size = New System.Drawing.Size(105, 34)
        Me.btnMeas.TabIndex = 4
        Me.btnMeas.Text = "MEAS."
        Me.btnMeas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1036, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ELVDD I :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1031, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ELVDD T :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1036, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "ELVSS I :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1031, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ELVSS T :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1059, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "PD I :"
        '
        'tbELVDD_I
        '
        Me.tbELVDD_I.Location = New System.Drawing.Point(1101, 74)
        Me.tbELVDD_I.Name = "tbELVDD_I"
        Me.tbELVDD_I.Size = New System.Drawing.Size(153, 21)
        Me.tbELVDD_I.TabIndex = 11
        '
        'tbPD_I
        '
        Me.tbPD_I.Location = New System.Drawing.Point(1101, 185)
        Me.tbPD_I.Name = "tbPD_I"
        Me.tbPD_I.Size = New System.Drawing.Size(153, 21)
        Me.tbPD_I.TabIndex = 12
        '
        'tbELVSS_T
        '
        Me.tbELVSS_T.Location = New System.Drawing.Point(1101, 158)
        Me.tbELVSS_T.Name = "tbELVSS_T"
        Me.tbELVSS_T.Size = New System.Drawing.Size(153, 21)
        Me.tbELVSS_T.TabIndex = 13
        '
        'tbELVDD_T
        '
        Me.tbELVDD_T.Location = New System.Drawing.Point(1101, 131)
        Me.tbELVDD_T.Name = "tbELVDD_T"
        Me.tbELVDD_T.Size = New System.Drawing.Size(153, 21)
        Me.tbELVDD_T.TabIndex = 14
        '
        'tbELVSS_I
        '
        Me.tbELVSS_I.Location = New System.Drawing.Point(1101, 104)
        Me.tbELVSS_I.Name = "tbELVSS_I"
        Me.tbELVSS_I.Size = New System.Drawing.Size(153, 21)
        Me.tbELVSS_I.TabIndex = 15
        '
        'cbSelGroup
        '
        Me.cbSelGroup.FormattingEnabled = True
        Me.cbSelGroup.Location = New System.Drawing.Point(88, 13)
        Me.cbSelGroup.Name = "cbSelGroup"
        Me.cbSelGroup.Size = New System.Drawing.Size(81, 20)
        Me.cbSelGroup.TabIndex = 70
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.Location = New System.Drawing.Point(24, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 11)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "Group :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(598, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 11)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Channel :"
        '
        'tbChannel
        '
        Me.tbChannel.Location = New System.Drawing.Point(668, 12)
        Me.tbChannel.Name = "tbChannel"
        Me.tbChannel.Size = New System.Drawing.Size(45, 21)
        Me.tbChannel.TabIndex = 72
        Me.tbChannel.Text = "0"
        Me.tbChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbDevice
        '
        Me.tbDevice.Location = New System.Drawing.Point(523, 12)
        Me.tbDevice.Name = "tbDevice"
        Me.tbDevice.Size = New System.Drawing.Size(45, 21)
        Me.tbDevice.TabIndex = 74
        Me.tbDevice.Text = "0"
        Me.tbDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(461, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 11)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Device :"
        '
        'tbSystempCh
        '
        Me.tbSystempCh.Location = New System.Drawing.Point(1072, 13)
        Me.tbSystempCh.Name = "tbSystempCh"
        Me.tbSystempCh.Size = New System.Drawing.Size(45, 21)
        Me.tbSystempCh.TabIndex = 76
        Me.tbSystempCh.Text = "0"
        Me.tbSystempCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(1002, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 11)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Channel :"
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(874, 5)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(105, 34)
        Me.btn_off.TabIndex = 79
        Me.btn_off.Text = "OFF"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1061, 253)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 39)
        Me.Button1.TabIndex = 80
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UcDispSignalGenerator1
        '
        Me.UcDispSignalGenerator1.IsVisibleOnlyGrid = False
        Me.UcDispSignalGenerator1.Location = New System.Drawing.Point(12, 45)
        Me.UcDispSignalGenerator1.Name = "UcDispSignalGenerator1"
        Me.UcDispSignalGenerator1.Size = New System.Drawing.Size(1009, 732)
        Me.UcDispSignalGenerator1.TabIndex = 0
        '
        'frmSGTestUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1347, 801)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.tbSystempCh)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbDevice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbChannel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbSelGroup)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.tbELVSS_I)
        Me.Controls.Add(Me.tbELVDD_T)
        Me.Controls.Add(Me.tbELVSS_T)
        Me.Controls.Add(Me.tbPD_I)
        Me.Controls.Add(Me.tbELVDD_I)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMeas)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.btnDisconnection)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.UcDispSignalGenerator1)
        Me.Name = "frmSGTestUI"
        Me.Text = "frmSGTestUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UcDispSignalGenerator1 As M7000.ucDispSignalGenerator
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents btnMeas As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbELVDD_I As System.Windows.Forms.TextBox
    Friend WithEvents tbPD_I As System.Windows.Forms.TextBox
    Friend WithEvents tbELVSS_T As System.Windows.Forms.TextBox
    Friend WithEvents tbELVDD_T As System.Windows.Forms.TextBox
    Friend WithEvents tbELVSS_I As System.Windows.Forms.TextBox
    Friend WithEvents cbSelGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbChannel As System.Windows.Forms.TextBox
    Friend WithEvents tbDevice As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbSystempCh As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_off As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
