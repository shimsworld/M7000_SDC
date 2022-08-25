<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmK7001Control
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
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.tbFWVersion = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbSerial = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbModel = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbManufacture = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnReset_K7001 = New System.Windows.Forms.Button()
        Me.btnIDN_K7001 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.gbGPIBSet = New System.Windows.Forms.GroupBox()
        Me.tbAddressNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbConnectionStatus = New System.Windows.Forms.TextBox()
        Me.btnK7001Connection = New System.Windows.Forms.Button()
        Me.btnK7001Disconnection = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tbSelectCardNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAllOpen = New System.Windows.Forms.Button()
        Me.tbSelectChNumber = New System.Windows.Forms.TextBox()
        Me.btnSelectOpen_K7001 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSelectClose_K7001 = New System.Windows.Forms.Button()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gbGPIBSet.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.tbFWVersion)
        Me.GroupBox12.Controls.Add(Me.Label22)
        Me.GroupBox12.Controls.Add(Me.tbSerial)
        Me.GroupBox12.Controls.Add(Me.Label21)
        Me.GroupBox12.Controls.Add(Me.tbModel)
        Me.GroupBox12.Controls.Add(Me.Label20)
        Me.GroupBox12.Controls.Add(Me.tbManufacture)
        Me.GroupBox12.Controls.Add(Me.Label19)
        Me.GroupBox12.Controls.Add(Me.btnReset_K7001)
        Me.GroupBox12.Controls.Add(Me.btnIDN_K7001)
        Me.GroupBox12.Location = New System.Drawing.Point(281, 12)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(355, 174)
        Me.GroupBox12.TabIndex = 17
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Common"
        '
        'tbFWVersion
        '
        Me.tbFWVersion.Location = New System.Drawing.Point(103, 128)
        Me.tbFWVersion.Name = "tbFWVersion"
        Me.tbFWVersion.Size = New System.Drawing.Size(246, 21)
        Me.tbFWVersion.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(20, 132)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 12)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "FW Version :"
        '
        'tbSerial
        '
        Me.tbSerial.Location = New System.Drawing.Point(103, 104)
        Me.tbSerial.Name = "tbSerial"
        Me.tbSerial.Size = New System.Drawing.Size(246, 21)
        Me.tbSerial.TabIndex = 27
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(52, 107)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 12)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "Serial :"
        '
        'tbModel
        '
        Me.tbModel.Location = New System.Drawing.Point(103, 80)
        Me.tbModel.Name = "tbModel"
        Me.tbModel.Size = New System.Drawing.Size(246, 21)
        Me.tbModel.TabIndex = 25
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(49, 83)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 12)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Model :"
        '
        'tbManufacture
        '
        Me.tbManufacture.Location = New System.Drawing.Point(103, 55)
        Me.tbManufacture.Name = "tbManufacture"
        Me.tbManufacture.Size = New System.Drawing.Size(246, 21)
        Me.tbManufacture.TabIndex = 23
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 12)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Manufacture :"
        '
        'btnReset_K7001
        '
        Me.btnReset_K7001.Location = New System.Drawing.Point(231, 20)
        Me.btnReset_K7001.Name = "btnReset_K7001"
        Me.btnReset_K7001.Size = New System.Drawing.Size(118, 29)
        Me.btnReset_K7001.TabIndex = 21
        Me.btnReset_K7001.Text = "RESET"
        Me.btnReset_K7001.UseVisualStyleBackColor = True
        '
        'btnIDN_K7001
        '
        Me.btnIDN_K7001.Location = New System.Drawing.Point(103, 20)
        Me.btnIDN_K7001.Name = "btnIDN_K7001"
        Me.btnIDN_K7001.Size = New System.Drawing.Size(122, 29)
        Me.btnIDN_K7001.TabIndex = 20
        Me.btnIDN_K7001.Text = "IDN"
        Me.btnIDN_K7001.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gbGPIBSet)
        Me.GroupBox5.Controls.Add(Me.tbConnectionStatus)
        Me.GroupBox5.Controls.Add(Me.btnK7001Connection)
        Me.GroupBox5.Controls.Add(Me.btnK7001Disconnection)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(263, 174)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'gbGPIBSet
        '
        Me.gbGPIBSet.Controls.Add(Me.tbAddressNumber)
        Me.gbGPIBSet.Controls.Add(Me.Label1)
        Me.gbGPIBSet.Location = New System.Drawing.Point(10, 61)
        Me.gbGPIBSet.Name = "gbGPIBSet"
        Me.gbGPIBSet.Size = New System.Drawing.Size(245, 42)
        Me.gbGPIBSet.TabIndex = 19
        Me.gbGPIBSet.TabStop = False
        Me.gbGPIBSet.Text = "GPIB"
        '
        'tbAddressNumber
        '
        Me.tbAddressNumber.Location = New System.Drawing.Point(141, 13)
        Me.tbAddressNumber.Name = "tbAddressNumber"
        Me.tbAddressNumber.Size = New System.Drawing.Size(91, 21)
        Me.tbAddressNumber.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Address :"
        '
        'tbConnectionStatus
        '
        Me.tbConnectionStatus.Location = New System.Drawing.Point(6, 109)
        Me.tbConnectionStatus.Multiline = True
        Me.tbConnectionStatus.Name = "tbConnectionStatus"
        Me.tbConnectionStatus.Size = New System.Drawing.Size(245, 55)
        Me.tbConnectionStatus.TabIndex = 5
        '
        'btnK7001Connection
        '
        Me.btnK7001Connection.Location = New System.Drawing.Point(10, 20)
        Me.btnK7001Connection.Name = "btnK7001Connection"
        Me.btnK7001Connection.Size = New System.Drawing.Size(119, 35)
        Me.btnK7001Connection.TabIndex = 0
        Me.btnK7001Connection.Text = "Connection"
        Me.btnK7001Connection.UseVisualStyleBackColor = True
        '
        'btnK7001Disconnection
        '
        Me.btnK7001Disconnection.Location = New System.Drawing.Point(143, 20)
        Me.btnK7001Disconnection.Name = "btnK7001Disconnection"
        Me.btnK7001Disconnection.Size = New System.Drawing.Size(112, 35)
        Me.btnK7001Disconnection.TabIndex = 1
        Me.btnK7001Disconnection.Text = "Disconnection"
        Me.btnK7001Disconnection.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tbSelectCardNumber)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.btnAllOpen)
        Me.GroupBox6.Controls.Add(Me.tbSelectChNumber)
        Me.GroupBox6.Controls.Add(Me.btnSelectOpen_K7001)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.btnSelectClose_K7001)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 202)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(355, 94)
        Me.GroupBox6.TabIndex = 18
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Control"
        '
        'tbSelectCardNumber
        '
        Me.tbSelectCardNumber.Location = New System.Drawing.Point(103, 18)
        Me.tbSelectCardNumber.Name = "tbSelectCardNumber"
        Me.tbSelectCardNumber.Size = New System.Drawing.Size(65, 21)
        Me.tbSelectCardNumber.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 12)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "CardNumber :"
        '
        'btnAllOpen
        '
        Me.btnAllOpen.Location = New System.Drawing.Point(16, 53)
        Me.btnAllOpen.Name = "btnAllOpen"
        Me.btnAllOpen.Size = New System.Drawing.Size(105, 31)
        Me.btnAllOpen.TabIndex = 31
        Me.btnAllOpen.Text = "AllOpen"
        Me.btnAllOpen.UseVisualStyleBackColor = True
        '
        'tbSelectChNumber
        '
        Me.tbSelectChNumber.Location = New System.Drawing.Point(258, 18)
        Me.tbSelectChNumber.Name = "tbSelectChNumber"
        Me.tbSelectChNumber.Size = New System.Drawing.Size(65, 21)
        Me.tbSelectChNumber.TabIndex = 28
        '
        'btnSelectOpen_K7001
        '
        Me.btnSelectOpen_K7001.Location = New System.Drawing.Point(127, 53)
        Me.btnSelectOpen_K7001.Name = "btnSelectOpen_K7001"
        Me.btnSelectOpen_K7001.Size = New System.Drawing.Size(96, 31)
        Me.btnSelectOpen_K7001.TabIndex = 17
        Me.btnSelectOpen_K7001.Text = "Open"
        Me.btnSelectOpen_K7001.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(178, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 12)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "ChNumber :"
        '
        'btnSelectClose_K7001
        '
        Me.btnSelectClose_K7001.Location = New System.Drawing.Point(231, 53)
        Me.btnSelectClose_K7001.Name = "btnSelectClose_K7001"
        Me.btnSelectClose_K7001.Size = New System.Drawing.Size(92, 31)
        Me.btnSelectClose_K7001.TabIndex = 10
        Me.btnSelectClose_K7001.Text = "Close"
        Me.btnSelectClose_K7001.UseVisualStyleBackColor = True
        '
        'frmK7001Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 543)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmK7001Control"
        Me.Text = "frmK7001Control"
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gbGPIBSet.ResumeLayout(False)
        Me.gbGPIBSet.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents tbFWVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbModel As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbManufacture As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnReset_K7001 As System.Windows.Forms.Button
    Friend WithEvents btnIDN_K7001 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tbConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnK7001Connection As System.Windows.Forms.Button
    Friend WithEvents btnK7001Disconnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents tbSelectCardNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAllOpen As System.Windows.Forms.Button
    Friend WithEvents tbSelectChNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectOpen_K7001 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSelectClose_K7001 As System.Windows.Forms.Button
    Friend WithEvents gbGPIBSet As System.Windows.Forms.GroupBox
    Friend WithEvents tbAddressNumber As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
End Class
