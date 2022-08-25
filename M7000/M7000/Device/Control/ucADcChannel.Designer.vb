<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcADcChannel
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_ABSadc = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.tbAdcAver = New System.Windows.Forms.TextBox()
        Me.tbAdcCount = New System.Windows.Forms.TextBox()
        Me.tbAdcMax = New System.Windows.Forms.TextBox()
        Me.tbAdcMin = New System.Windows.Forms.TextBox()
        Me.btnADCRead = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAdcRead = New System.Windows.Forms.TextBox()
        Me.btnAdcReset = New System.Windows.Forms.Button()
        Me.txt_avercount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_avercountset = New System.Windows.Forms.Button()
        Me.btn_limitcset = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_limit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_CH = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_limittset = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_limittemp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_readlimittemp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_readlimitcurr = New System.Windows.Forms.TextBox()
        Me.txt_readavercount = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_calget = New System.Windows.Forms.Button()
        Me.btn_calSet = New System.Windows.Forms.Button()
        Me.txt_offset = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_ratio = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(550, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 12)
        Me.Label9.TabIndex = 245
        Me.Label9.Text = "Abs(Max-Min)"
        '
        'txt_ABSadc
        '
        Me.txt_ABSadc.Location = New System.Drawing.Point(540, 24)
        Me.txt_ABSadc.Name = "txt_ABSadc"
        Me.txt_ABSadc.ReadOnly = True
        Me.txt_ABSadc.Size = New System.Drawing.Size(109, 21)
        Me.txt_ABSadc.TabIndex = 244
        Me.txt_ABSadc.Text = "0"
        Me.txt_ABSadc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(768, 7)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(71, 12)
        Me.Label41.TabIndex = 243
        Me.Label41.Text = "Read Count"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(681, 7)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(51, 12)
        Me.Label40.TabIndex = 242
        Me.Label40.Text = "Average"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(468, 7)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(30, 12)
        Me.Label39.TabIndex = 241
        Me.Label39.Text = "Max"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(339, 7)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(26, 12)
        Me.Label38.TabIndex = 240
        Me.Label38.Text = "Min"
        '
        'tbAdcAver
        '
        Me.tbAdcAver.Location = New System.Drawing.Point(652, 24)
        Me.tbAdcAver.Name = "tbAdcAver"
        Me.tbAdcAver.ReadOnly = True
        Me.tbAdcAver.Size = New System.Drawing.Size(109, 21)
        Me.tbAdcAver.TabIndex = 239
        Me.tbAdcAver.Text = "0"
        Me.tbAdcAver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbAdcCount
        '
        Me.tbAdcCount.Location = New System.Drawing.Point(766, 24)
        Me.tbAdcCount.Name = "tbAdcCount"
        Me.tbAdcCount.ReadOnly = True
        Me.tbAdcCount.Size = New System.Drawing.Size(75, 21)
        Me.tbAdcCount.TabIndex = 238
        Me.tbAdcCount.Text = "0"
        Me.tbAdcCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbAdcMax
        '
        Me.tbAdcMax.Location = New System.Drawing.Point(429, 24)
        Me.tbAdcMax.Name = "tbAdcMax"
        Me.tbAdcMax.ReadOnly = True
        Me.tbAdcMax.Size = New System.Drawing.Size(109, 21)
        Me.tbAdcMax.TabIndex = 237
        Me.tbAdcMax.Text = "0"
        Me.tbAdcMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbAdcMin
        '
        Me.tbAdcMin.Location = New System.Drawing.Point(319, 24)
        Me.tbAdcMin.Name = "tbAdcMin"
        Me.tbAdcMin.ReadOnly = True
        Me.tbAdcMin.Size = New System.Drawing.Size(109, 21)
        Me.tbAdcMin.TabIndex = 236
        Me.tbAdcMin.Text = "0"
        Me.tbAdcMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnADCRead
        '
        Me.btnADCRead.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnADCRead.Location = New System.Drawing.Point(224, 24)
        Me.btnADCRead.Name = "btnADCRead"
        Me.btnADCRead.Size = New System.Drawing.Size(75, 23)
        Me.btnADCRead.TabIndex = 234
        Me.btnADCRead.Text = "READ"
        Me.btnADCRead.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(204, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 11)
        Me.Label8.TabIndex = 233
        Me.Label8.Text = "V"
        '
        'tbAdcRead
        '
        Me.tbAdcRead.Location = New System.Drawing.Point(89, 22)
        Me.tbAdcRead.Name = "tbAdcRead"
        Me.tbAdcRead.ReadOnly = True
        Me.tbAdcRead.Size = New System.Drawing.Size(109, 21)
        Me.tbAdcRead.TabIndex = 235
        Me.tbAdcRead.Text = "0"
        Me.tbAdcRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdcReset
        '
        Me.btnAdcReset.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAdcReset.Location = New System.Drawing.Point(847, 22)
        Me.btnAdcReset.Name = "btnAdcReset"
        Me.btnAdcReset.Size = New System.Drawing.Size(75, 23)
        Me.btnAdcReset.TabIndex = 247
        Me.btnAdcReset.Text = "Reset"
        Me.btnAdcReset.UseVisualStyleBackColor = True
        '
        'txt_avercount
        '
        Me.txt_avercount.Location = New System.Drawing.Point(186, 62)
        Me.txt_avercount.Name = "txt_avercount"
        Me.txt_avercount.Size = New System.Drawing.Size(66, 21)
        Me.txt_avercount.TabIndex = 248
        Me.txt_avercount.Text = "10"
        Me.txt_avercount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(92, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 12)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Average Count"
        '
        'btn_avercountset
        '
        Me.btn_avercountset.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_avercountset.Location = New System.Drawing.Point(253, 62)
        Me.btn_avercountset.Name = "btn_avercountset"
        Me.btn_avercountset.Size = New System.Drawing.Size(54, 51)
        Me.btn_avercountset.TabIndex = 250
        Me.btn_avercountset.Text = "Set"
        Me.btn_avercountset.UseVisualStyleBackColor = True
        '
        'btn_limitcset
        '
        Me.btn_limitcset.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_limitcset.Location = New System.Drawing.Point(444, 63)
        Me.btn_limitcset.Name = "btn_limitcset"
        Me.btn_limitcset.Size = New System.Drawing.Size(54, 50)
        Me.btn_limitcset.TabIndex = 253
        Me.btn_limitcset.Text = "Set"
        Me.btn_limitcset.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(313, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 12)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Limit"
        '
        'txt_limit
        '
        Me.txt_limit.Location = New System.Drawing.Point(351, 63)
        Me.txt_limit.Name = "txt_limit"
        Me.txt_limit.Size = New System.Drawing.Size(66, 21)
        Me.txt_limit.TabIndex = 251
        Me.txt_limit.Text = "1"
        Me.txt_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(420, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "(A)"
        '
        'Chk_CH
        '
        Me.Chk_CH.Appearance = System.Windows.Forms.Appearance.Button
        Me.Chk_CH.Location = New System.Drawing.Point(4, 13)
        Me.Chk_CH.Name = "Chk_CH"
        Me.Chk_CH.Size = New System.Drawing.Size(79, 65)
        Me.Chk_CH.TabIndex = 255
        Me.Chk_CH.Text = "Ch 00"
        Me.Chk_CH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Chk_CH.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(615, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "(℃)"
        '
        'btn_limittset
        '
        Me.btn_limittset.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_limittset.Location = New System.Drawing.Point(642, 63)
        Me.btn_limittset.Name = "btn_limittset"
        Me.btn_limittset.Size = New System.Drawing.Size(54, 50)
        Me.btn_limittset.TabIndex = 258
        Me.btn_limittset.Text = "Set"
        Me.btn_limittset.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(507, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 12)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "Limit"
        '
        'txt_limittemp
        '
        Me.txt_limittemp.Location = New System.Drawing.Point(545, 63)
        Me.txt_limittemp.Name = "txt_limittemp"
        Me.txt_limittemp.Size = New System.Drawing.Size(66, 21)
        Me.txt_limittemp.TabIndex = 256
        Me.txt_limittemp.Text = "1"
        Me.txt_limittemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(615, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 12)
        Me.Label6.TabIndex = 267
        Me.Label6.Text = "(℃)"
        '
        'txt_readlimittemp
        '
        Me.txt_readlimittemp.Enabled = False
        Me.txt_readlimittemp.Location = New System.Drawing.Point(545, 90)
        Me.txt_readlimittemp.Name = "txt_readlimittemp"
        Me.txt_readlimittemp.Size = New System.Drawing.Size(66, 21)
        Me.txt_readlimittemp.TabIndex = 265
        Me.txt_readlimittemp.Text = "0"
        Me.txt_readlimittemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(420, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 12)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "(A)"
        '
        'txt_readlimitcurr
        '
        Me.txt_readlimitcurr.Enabled = False
        Me.txt_readlimitcurr.Location = New System.Drawing.Point(351, 90)
        Me.txt_readlimitcurr.Name = "txt_readlimitcurr"
        Me.txt_readlimitcurr.Size = New System.Drawing.Size(66, 21)
        Me.txt_readlimitcurr.TabIndex = 262
        Me.txt_readlimitcurr.Text = "0"
        Me.txt_readlimitcurr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_readavercount
        '
        Me.txt_readavercount.Enabled = False
        Me.txt_readavercount.Location = New System.Drawing.Point(186, 89)
        Me.txt_readavercount.Name = "txt_readavercount"
        Me.txt_readavercount.Size = New System.Drawing.Size(66, 21)
        Me.txt_readavercount.TabIndex = 260
        Me.txt_readavercount.Text = "0"
        Me.txt_readavercount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_calget)
        Me.GroupBox5.Controls.Add(Me.btn_calSet)
        Me.GroupBox5.Controls.Add(Me.txt_offset)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txt_ratio)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(706, 51)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(219, 69)
        Me.GroupBox5.TabIndex = 268
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cal. Data"
        '
        'btn_calget
        '
        Me.btn_calget.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_calget.Location = New System.Drawing.Point(134, 42)
        Me.btn_calget.Name = "btn_calget"
        Me.btn_calget.Size = New System.Drawing.Size(62, 21)
        Me.btn_calget.TabIndex = 38
        Me.btn_calget.Text = "GET"
        Me.btn_calget.UseVisualStyleBackColor = True
        '
        'btn_calSet
        '
        Me.btn_calSet.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_calSet.Location = New System.Drawing.Point(134, 18)
        Me.btn_calSet.Name = "btn_calSet"
        Me.btn_calSet.Size = New System.Drawing.Size(62, 21)
        Me.btn_calSet.TabIndex = 37
        Me.btn_calSet.Text = "SET"
        Me.btn_calSet.UseVisualStyleBackColor = True
        '
        'txt_offset
        '
        Me.txt_offset.Enabled = False
        Me.txt_offset.Location = New System.Drawing.Point(54, 41)
        Me.txt_offset.Name = "txt_offset"
        Me.txt_offset.Size = New System.Drawing.Size(74, 21)
        Me.txt_offset.TabIndex = 36
        Me.txt_offset.Text = "0.0000000"
        Me.txt_offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 23)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "OffSet"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_ratio
        '
        Me.txt_ratio.Enabled = False
        Me.txt_ratio.Location = New System.Drawing.Point(54, 17)
        Me.txt_ratio.Name = "txt_ratio"
        Me.txt_ratio.Size = New System.Drawing.Size(74, 21)
        Me.txt_ratio.TabIndex = 34
        Me.txt_ratio.Text = "0.0000000"
        Me.txt_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 23)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ratio"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcADcChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_readlimittemp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_readlimitcurr)
        Me.Controls.Add(Me.txt_readavercount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_limittset)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_limittemp)
        Me.Controls.Add(Me.Chk_CH)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_limitcset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_limit)
        Me.Controls.Add(Me.btn_avercountset)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_avercount)
        Me.Controls.Add(Me.btnAdcReset)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_ABSadc)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.tbAdcAver)
        Me.Controls.Add(Me.tbAdcCount)
        Me.Controls.Add(Me.tbAdcMax)
        Me.Controls.Add(Me.tbAdcMin)
        Me.Controls.Add(Me.btnADCRead)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbAdcRead)
        Me.Name = "UcADcChannel"
        Me.Size = New System.Drawing.Size(937, 123)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_ABSadc As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents tbAdcAver As System.Windows.Forms.TextBox
    Friend WithEvents tbAdcCount As System.Windows.Forms.TextBox
    Friend WithEvents tbAdcMax As System.Windows.Forms.TextBox
    Friend WithEvents tbAdcMin As System.Windows.Forms.TextBox
    Friend WithEvents btnADCRead As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbAdcRead As System.Windows.Forms.TextBox
    Friend WithEvents btnAdcReset As System.Windows.Forms.Button
    Friend WithEvents txt_avercount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_avercountset As System.Windows.Forms.Button
    Friend WithEvents btn_limitcset As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_limit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_CH As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_limittset As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_limittemp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_readlimittemp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_readlimitcurr As System.Windows.Forms.TextBox
    Friend WithEvents txt_readavercount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_calget As System.Windows.Forms.Button
    Friend WithEvents btn_calSet As System.Windows.Forms.Button
    Friend WithEvents txt_offset As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ratio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
