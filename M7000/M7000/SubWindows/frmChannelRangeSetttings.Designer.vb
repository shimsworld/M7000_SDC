<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelRangeSetttings
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
        Me.ucDispBoardRange = New M7000.ucDispListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBoardRangeSetAll = New System.Windows.Forms.Button()
        Me.btnBoardRangeSet = New System.Windows.Forms.Button()
        Me.tbSetRangePhotoMax3 = New System.Windows.Forms.TextBox()
        Me.tbSetRangePhotoMin3 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.tbSetRangePhotoMax2 = New System.Windows.Forms.TextBox()
        Me.tbSetRangePhotoMin2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.tbSetRangePhotoMax1 = New System.Windows.Forms.TextBox()
        Me.tbSetRangePhotoMin1 = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.tbSetRangeCurrMax2 = New System.Windows.Forms.TextBox()
        Me.tbSetRangeCurrMin2 = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tbSetRangeCurrMax1 = New System.Windows.Forms.TextBox()
        Me.tbSetRangeCurrMin1 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tbSetRangeVoltMax = New System.Windows.Forms.TextBox()
        Me.tbSetRangeVoltMin = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ucDispRangeSet = New M7000.ucDispListView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbSemiAutoRangeOff = New System.Windows.Forms.RadioButton()
        Me.rbSemiAutoRangeOn = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbAutoRangeOFF = New System.Windows.Forms.RadioButton()
        Me.rbAutoRangeOn = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbCurrRangeIVL_2 = New System.Windows.Forms.RadioButton()
        Me.rbCurrRangeIVL_1 = New System.Windows.Forms.RadioButton()
        Me.btnRangeSetAll = New System.Windows.Forms.Button()
        Me.btnRangeSet = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rbPDRange_3 = New System.Windows.Forms.RadioButton()
        Me.rbPDRange_2 = New System.Windows.Forms.RadioButton()
        Me.rbPDRange_1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.rb4Wire = New System.Windows.Forms.RadioButton()
        Me.rb2Wire = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbCurrRange_2 = New System.Windows.Forms.RadioButton()
        Me.rbCurrRange_1 = New System.Windows.Forms.RadioButton()
        Me.btnCalcle = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucDispBoardRange
        '
        Me.ucDispBoardRange.ColHeader = New String() {"Board No.", "Voltage min.", "Voltage max.", "Current 1 min.", "Current 1 max.", "Current 2 min.", "Current 2 max.", "Photocurrent 1 min.", "Photocurrent 1 max.", "Photocurrent 2 min.", "Photocurrent 2 max.", "Photocurrent 3 min.", "Photocurrent 3 max."}
        Me.ucDispBoardRange.ColHeaderWidthRatio = "5,8,8,7,7,7,7,9,9,9,9,9,9"
        Me.ucDispBoardRange.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispBoardRange.FullRawSelection = True
        Me.ucDispBoardRange.HideSelection = False
        Me.ucDispBoardRange.LabelEdit = True
        Me.ucDispBoardRange.LabelWrap = True
        Me.ucDispBoardRange.Location = New System.Drawing.Point(224, 21)
        Me.ucDispBoardRange.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucDispBoardRange.Name = "ucDispBoardRange"
        Me.ucDispBoardRange.Size = New System.Drawing.Size(1466, 279)
        Me.ucDispBoardRange.TabIndex = 0
        Me.ucDispBoardRange.UseCheckBoxex = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(584, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(460, 84)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Don't touch Board Range" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Set Range is Okay"
        '
        'btnBoardRangeSetAll
        '
        Me.btnBoardRangeSetAll.BackColor = System.Drawing.Color.LightGray
        Me.btnBoardRangeSetAll.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoardRangeSetAll.Location = New System.Drawing.Point(13, 229)
        Me.btnBoardRangeSetAll.Name = "btnBoardRangeSetAll"
        Me.btnBoardRangeSetAll.Size = New System.Drawing.Size(97, 26)
        Me.btnBoardRangeSetAll.TabIndex = 165
        Me.btnBoardRangeSetAll.Text = "SET ALL"
        Me.btnBoardRangeSetAll.UseVisualStyleBackColor = False
        '
        'btnBoardRangeSet
        '
        Me.btnBoardRangeSet.BackColor = System.Drawing.Color.LightGray
        Me.btnBoardRangeSet.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoardRangeSet.Location = New System.Drawing.Point(116, 229)
        Me.btnBoardRangeSet.Name = "btnBoardRangeSet"
        Me.btnBoardRangeSet.Size = New System.Drawing.Size(97, 26)
        Me.btnBoardRangeSet.TabIndex = 164
        Me.btnBoardRangeSet.Text = "SET"
        Me.btnBoardRangeSet.UseVisualStyleBackColor = False
        '
        'tbSetRangePhotoMax3
        '
        Me.tbSetRangePhotoMax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMax3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMax3.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMax3.Location = New System.Drawing.Point(164, 200)
        Me.tbSetRangePhotoMax3.Name = "tbSetRangePhotoMax3"
        Me.tbSetRangePhotoMax3.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMax3.TabIndex = 163
        Me.tbSetRangePhotoMax3.Text = "0"
        Me.tbSetRangePhotoMax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangePhotoMin3
        '
        Me.tbSetRangePhotoMin3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMin3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMin3.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMin3.Location = New System.Drawing.Point(113, 200)
        Me.tbSetRangePhotoMin3.Name = "tbSetRangePhotoMin3"
        Me.tbSetRangePhotoMin3.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMin3.TabIndex = 162
        Me.tbSetRangePhotoMin3.Text = "0"
        Me.tbSetRangePhotoMin3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(27, 205)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 15)
        Me.Label38.TabIndex = 161
        Me.Label38.Text = "Photo3 (A)"
        '
        'tbSetRangePhotoMax2
        '
        Me.tbSetRangePhotoMax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMax2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMax2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMax2.Location = New System.Drawing.Point(164, 175)
        Me.tbSetRangePhotoMax2.Name = "tbSetRangePhotoMax2"
        Me.tbSetRangePhotoMax2.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMax2.TabIndex = 160
        Me.tbSetRangePhotoMax2.Text = "0"
        Me.tbSetRangePhotoMax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangePhotoMin2
        '
        Me.tbSetRangePhotoMin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMin2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMin2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMin2.Location = New System.Drawing.Point(113, 175)
        Me.tbSetRangePhotoMin2.Name = "tbSetRangePhotoMin2"
        Me.tbSetRangePhotoMin2.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMin2.TabIndex = 159
        Me.tbSetRangePhotoMin2.Text = "0"
        Me.tbSetRangePhotoMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(26, 180)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(64, 15)
        Me.Label41.TabIndex = 158
        Me.Label41.Text = "Photo2 (A)"
        '
        'tbSetRangePhotoMax1
        '
        Me.tbSetRangePhotoMax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMax1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMax1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMax1.Location = New System.Drawing.Point(164, 149)
        Me.tbSetRangePhotoMax1.Name = "tbSetRangePhotoMax1"
        Me.tbSetRangePhotoMax1.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMax1.TabIndex = 157
        Me.tbSetRangePhotoMax1.Text = "0"
        Me.tbSetRangePhotoMax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangePhotoMin1
        '
        Me.tbSetRangePhotoMin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangePhotoMin1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangePhotoMin1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangePhotoMin1.Location = New System.Drawing.Point(113, 149)
        Me.tbSetRangePhotoMin1.Name = "tbSetRangePhotoMin1"
        Me.tbSetRangePhotoMin1.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangePhotoMin1.TabIndex = 156
        Me.tbSetRangePhotoMin1.Text = "0"
        Me.tbSetRangePhotoMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(26, 154)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(64, 15)
        Me.Label42.TabIndex = 155
        Me.Label42.Text = "Photo1 (A)"
        '
        'tbSetRangeCurrMax2
        '
        Me.tbSetRangeCurrMax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeCurrMax2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeCurrMax2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeCurrMax2.Location = New System.Drawing.Point(164, 124)
        Me.tbSetRangeCurrMax2.Name = "tbSetRangeCurrMax2"
        Me.tbSetRangeCurrMax2.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeCurrMax2.TabIndex = 154
        Me.tbSetRangeCurrMax2.Text = "0"
        Me.tbSetRangeCurrMax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangeCurrMin2
        '
        Me.tbSetRangeCurrMin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeCurrMin2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeCurrMin2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeCurrMin2.Location = New System.Drawing.Point(113, 124)
        Me.tbSetRangeCurrMin2.Name = "tbSetRangeCurrMin2"
        Me.tbSetRangeCurrMin2.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeCurrMin2.TabIndex = 153
        Me.tbSetRangeCurrMin2.Text = "0"
        Me.tbSetRangeCurrMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(19, 129)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(72, 15)
        Me.Label39.TabIndex = 152
        Me.Label39.Text = "Current2 (A)"
        '
        'tbSetRangeCurrMax1
        '
        Me.tbSetRangeCurrMax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeCurrMax1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeCurrMax1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeCurrMax1.Location = New System.Drawing.Point(164, 99)
        Me.tbSetRangeCurrMax1.Name = "tbSetRangeCurrMax1"
        Me.tbSetRangeCurrMax1.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeCurrMax1.TabIndex = 151
        Me.tbSetRangeCurrMax1.Text = "0"
        Me.tbSetRangeCurrMax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangeCurrMin1
        '
        Me.tbSetRangeCurrMin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeCurrMin1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeCurrMin1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeCurrMin1.Location = New System.Drawing.Point(113, 99)
        Me.tbSetRangeCurrMin1.Name = "tbSetRangeCurrMin1"
        Me.tbSetRangeCurrMin1.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeCurrMin1.TabIndex = 150
        Me.tbSetRangeCurrMin1.Text = "0"
        Me.tbSetRangeCurrMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(20, 104)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 15)
        Me.Label40.TabIndex = 149
        Me.Label40.Text = "Current1 (A)"
        '
        'tbSetRangeVoltMax
        '
        Me.tbSetRangeVoltMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeVoltMax.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeVoltMax.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeVoltMax.Location = New System.Drawing.Point(164, 74)
        Me.tbSetRangeVoltMax.Name = "tbSetRangeVoltMax"
        Me.tbSetRangeVoltMax.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeVoltMax.TabIndex = 148
        Me.tbSetRangeVoltMax.Text = "0"
        Me.tbSetRangeVoltMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSetRangeVoltMin
        '
        Me.tbSetRangeVoltMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetRangeVoltMin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetRangeVoltMin.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetRangeVoltMin.Location = New System.Drawing.Point(113, 74)
        Me.tbSetRangeVoltMin.Name = "tbSetRangeVoltMin"
        Me.tbSetRangeVoltMin.Size = New System.Drawing.Size(47, 23)
        Me.tbSetRangeVoltMin.TabIndex = 147
        Me.tbSetRangeVoltMin.Text = "0"
        Me.tbSetRangeVoltMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(25, 79)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 15)
        Me.Label37.TabIndex = 146
        Me.Label37.Text = "Voltage (V)"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(164, 58)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(33, 13)
        Me.Label34.TabIndex = 145
        Me.Label34.Text = "MAX"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(118, 58)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(30, 13)
        Me.Label35.TabIndex = 144
        Me.Label35.Text = "MIN"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ucDispBoardRange)
        Me.GroupBox1.Controls.Add(Me.btnBoardRangeSetAll)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.btnBoardRangeSet)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMax3)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMin3)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeVoltMin)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeVoltMax)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMax2)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMin2)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeCurrMin1)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeCurrMax1)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMax1)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.tbSetRangePhotoMin1)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeCurrMin2)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.tbSetRangeCurrMax2)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1697, 318)
        Me.GroupBox1.TabIndex = 166
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Board Range"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ucDispRangeSet)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.btnRangeSetAll)
        Me.GroupBox2.Controls.Add(Me.btnRangeSet)
        Me.GroupBox2.Controls.Add(Me.GroupBox9)
        Me.GroupBox2.Controls.Add(Me.GroupBox18)
        Me.GroupBox2.Controls.Add(Me.GroupBox8)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 418)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1420, 337)
        Me.GroupBox2.TabIndex = 167
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Set Range"
        '
        'ucDispRangeSet
        '
        Me.ucDispRangeSet.ColHeader = New String() {"Channel", "Current (LT)", "Current (IVL)", "Photocurrent", "Probe", "Auto Range", "PD SemiAuto"}
        Me.ucDispRangeSet.ColHeaderWidthRatio = "6,20,20,20,8,13,13"
        Me.ucDispRangeSet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispRangeSet.FullRawSelection = True
        Me.ucDispRangeSet.HideSelection = False
        Me.ucDispRangeSet.LabelEdit = True
        Me.ucDispRangeSet.LabelWrap = True
        Me.ucDispRangeSet.Location = New System.Drawing.Point(295, 21)
        Me.ucDispRangeSet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucDispRangeSet.Name = "ucDispRangeSet"
        Me.ucDispRangeSet.Size = New System.Drawing.Size(1091, 266)
        Me.ucDispRangeSet.TabIndex = 166
        Me.ucDispRangeSet.UseCheckBoxex = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbSemiAutoRangeOff)
        Me.GroupBox4.Controls.Add(Me.rbSemiAutoRangeOn)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 235)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(265, 38)
        Me.GroupBox4.TabIndex = 156
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "PD SemiAuto"
        '
        'rbSemiAutoRangeOff
        '
        Me.rbSemiAutoRangeOff.AutoSize = True
        Me.rbSemiAutoRangeOff.Checked = True
        Me.rbSemiAutoRangeOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbSemiAutoRangeOff.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSemiAutoRangeOff.Location = New System.Drawing.Point(107, 15)
        Me.rbSemiAutoRangeOff.Name = "rbSemiAutoRangeOff"
        Me.rbSemiAutoRangeOff.Size = New System.Drawing.Size(45, 17)
        Me.rbSemiAutoRangeOff.TabIndex = 8
        Me.rbSemiAutoRangeOff.TabStop = True
        Me.rbSemiAutoRangeOff.Text = "OFF"
        Me.rbSemiAutoRangeOff.UseVisualStyleBackColor = True
        '
        'rbSemiAutoRangeOn
        '
        Me.rbSemiAutoRangeOn.AutoSize = True
        Me.rbSemiAutoRangeOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbSemiAutoRangeOn.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSemiAutoRangeOn.Location = New System.Drawing.Point(30, 15)
        Me.rbSemiAutoRangeOn.Name = "rbSemiAutoRangeOn"
        Me.rbSemiAutoRangeOn.Size = New System.Drawing.Size(40, 17)
        Me.rbSemiAutoRangeOn.TabIndex = 7
        Me.rbSemiAutoRangeOn.Text = "On"
        Me.rbSemiAutoRangeOn.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbAutoRangeOFF)
        Me.GroupBox3.Controls.Add(Me.rbAutoRangeOn)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(265, 38)
        Me.GroupBox3.TabIndex = 155
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto Range"
        '
        'rbAutoRangeOFF
        '
        Me.rbAutoRangeOFF.AutoSize = True
        Me.rbAutoRangeOFF.Checked = True
        Me.rbAutoRangeOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAutoRangeOFF.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAutoRangeOFF.Location = New System.Drawing.Point(107, 15)
        Me.rbAutoRangeOFF.Name = "rbAutoRangeOFF"
        Me.rbAutoRangeOFF.Size = New System.Drawing.Size(45, 17)
        Me.rbAutoRangeOFF.TabIndex = 8
        Me.rbAutoRangeOFF.TabStop = True
        Me.rbAutoRangeOFF.Text = "OFF"
        Me.rbAutoRangeOFF.UseVisualStyleBackColor = True
        '
        'rbAutoRangeOn
        '
        Me.rbAutoRangeOn.AutoSize = True
        Me.rbAutoRangeOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbAutoRangeOn.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAutoRangeOn.Location = New System.Drawing.Point(30, 15)
        Me.rbAutoRangeOn.Name = "rbAutoRangeOn"
        Me.rbAutoRangeOn.Size = New System.Drawing.Size(40, 17)
        Me.rbAutoRangeOn.TabIndex = 7
        Me.rbAutoRangeOn.Text = "On"
        Me.rbAutoRangeOn.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbCurrRangeIVL_2)
        Me.GroupBox5.Controls.Add(Me.rbCurrRangeIVL_1)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(265, 37)
        Me.GroupBox5.TabIndex = 154
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Current (A) for IVL"
        '
        'rbCurrRangeIVL_2
        '
        Me.rbCurrRangeIVL_2.AutoSize = True
        Me.rbCurrRangeIVL_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbCurrRangeIVL_2.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCurrRangeIVL_2.Location = New System.Drawing.Point(108, 15)
        Me.rbCurrRangeIVL_2.Name = "rbCurrRangeIVL_2"
        Me.rbCurrRangeIVL_2.Size = New System.Drawing.Size(37, 17)
        Me.rbCurrRangeIVL_2.TabIndex = 8
        Me.rbCurrRangeIVL_2.Text = "#2"
        Me.rbCurrRangeIVL_2.UseVisualStyleBackColor = True
        '
        'rbCurrRangeIVL_1
        '
        Me.rbCurrRangeIVL_1.AutoSize = True
        Me.rbCurrRangeIVL_1.Checked = True
        Me.rbCurrRangeIVL_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbCurrRangeIVL_1.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCurrRangeIVL_1.Location = New System.Drawing.Point(29, 15)
        Me.rbCurrRangeIVL_1.Name = "rbCurrRangeIVL_1"
        Me.rbCurrRangeIVL_1.Size = New System.Drawing.Size(37, 17)
        Me.rbCurrRangeIVL_1.TabIndex = 7
        Me.rbCurrRangeIVL_1.TabStop = True
        Me.rbCurrRangeIVL_1.Text = "#1"
        Me.rbCurrRangeIVL_1.UseVisualStyleBackColor = True
        '
        'btnRangeSetAll
        '
        Me.btnRangeSetAll.BackColor = System.Drawing.Color.LightGray
        Me.btnRangeSetAll.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRangeSetAll.Location = New System.Drawing.Point(13, 279)
        Me.btnRangeSetAll.Name = "btnRangeSetAll"
        Me.btnRangeSetAll.Size = New System.Drawing.Size(97, 26)
        Me.btnRangeSetAll.TabIndex = 153
        Me.btnRangeSetAll.Text = "SET ALL"
        Me.btnRangeSetAll.UseVisualStyleBackColor = False
        '
        'btnRangeSet
        '
        Me.btnRangeSet.BackColor = System.Drawing.Color.LightGray
        Me.btnRangeSet.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRangeSet.Location = New System.Drawing.Point(116, 279)
        Me.btnRangeSet.Name = "btnRangeSet"
        Me.btnRangeSet.Size = New System.Drawing.Size(97, 26)
        Me.btnRangeSet.TabIndex = 152
        Me.btnRangeSet.Text = "SET"
        Me.btnRangeSet.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rbPDRange_3)
        Me.GroupBox9.Controls.Add(Me.rbPDRange_2)
        Me.GroupBox9.Controls.Add(Me.rbPDRange_1)
        Me.GroupBox9.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(6, 101)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(265, 39)
        Me.GroupBox9.TabIndex = 150
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Photocurrent (A)"
        '
        'rbPDRange_3
        '
        Me.rbPDRange_3.AutoSize = True
        Me.rbPDRange_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbPDRange_3.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPDRange_3.Location = New System.Drawing.Point(190, 16)
        Me.rbPDRange_3.Name = "rbPDRange_3"
        Me.rbPDRange_3.Size = New System.Drawing.Size(37, 17)
        Me.rbPDRange_3.TabIndex = 9
        Me.rbPDRange_3.Text = "#3"
        Me.rbPDRange_3.UseVisualStyleBackColor = True
        '
        'rbPDRange_2
        '
        Me.rbPDRange_2.AutoSize = True
        Me.rbPDRange_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbPDRange_2.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPDRange_2.Location = New System.Drawing.Point(108, 16)
        Me.rbPDRange_2.Name = "rbPDRange_2"
        Me.rbPDRange_2.Size = New System.Drawing.Size(37, 17)
        Me.rbPDRange_2.TabIndex = 8
        Me.rbPDRange_2.Text = "#2"
        Me.rbPDRange_2.UseVisualStyleBackColor = True
        '
        'rbPDRange_1
        '
        Me.rbPDRange_1.AutoSize = True
        Me.rbPDRange_1.Checked = True
        Me.rbPDRange_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbPDRange_1.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPDRange_1.Location = New System.Drawing.Point(29, 16)
        Me.rbPDRange_1.Name = "rbPDRange_1"
        Me.rbPDRange_1.Size = New System.Drawing.Size(37, 17)
        Me.rbPDRange_1.TabIndex = 7
        Me.rbPDRange_1.TabStop = True
        Me.rbPDRange_1.Text = "#1"
        Me.rbPDRange_1.UseVisualStyleBackColor = True
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.rb4Wire)
        Me.GroupBox18.Controls.Add(Me.rb2Wire)
        Me.GroupBox18.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(6, 146)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(265, 38)
        Me.GroupBox18.TabIndex = 151
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Probe"
        '
        'rb4Wire
        '
        Me.rb4Wire.AutoSize = True
        Me.rb4Wire.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rb4Wire.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb4Wire.Location = New System.Drawing.Point(107, 15)
        Me.rb4Wire.Name = "rb4Wire"
        Me.rb4Wire.Size = New System.Drawing.Size(58, 17)
        Me.rb4Wire.TabIndex = 8
        Me.rb4Wire.Text = "4-Wire"
        Me.rb4Wire.UseVisualStyleBackColor = True
        '
        'rb2Wire
        '
        Me.rb2Wire.AutoSize = True
        Me.rb2Wire.Checked = True
        Me.rb2Wire.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rb2Wire.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2Wire.Location = New System.Drawing.Point(29, 15)
        Me.rb2Wire.Name = "rb2Wire"
        Me.rb2Wire.Size = New System.Drawing.Size(58, 17)
        Me.rb2Wire.TabIndex = 7
        Me.rb2Wire.TabStop = True
        Me.rb2Wire.Text = "2-Wire"
        Me.rb2Wire.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbCurrRange_2)
        Me.GroupBox8.Controls.Add(Me.rbCurrRange_1)
        Me.GroupBox8.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(265, 37)
        Me.GroupBox8.TabIndex = 149
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Current (A) for LT"
        '
        'rbCurrRange_2
        '
        Me.rbCurrRange_2.AutoSize = True
        Me.rbCurrRange_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbCurrRange_2.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCurrRange_2.Location = New System.Drawing.Point(108, 15)
        Me.rbCurrRange_2.Name = "rbCurrRange_2"
        Me.rbCurrRange_2.Size = New System.Drawing.Size(37, 17)
        Me.rbCurrRange_2.TabIndex = 8
        Me.rbCurrRange_2.Text = "#2"
        Me.rbCurrRange_2.UseVisualStyleBackColor = True
        '
        'rbCurrRange_1
        '
        Me.rbCurrRange_1.AutoSize = True
        Me.rbCurrRange_1.Checked = True
        Me.rbCurrRange_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbCurrRange_1.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCurrRange_1.Location = New System.Drawing.Point(29, 15)
        Me.rbCurrRange_1.Name = "rbCurrRange_1"
        Me.rbCurrRange_1.Size = New System.Drawing.Size(37, 17)
        Me.rbCurrRange_1.TabIndex = 7
        Me.rbCurrRange_1.TabStop = True
        Me.rbCurrRange_1.Text = "#1"
        Me.rbCurrRange_1.UseVisualStyleBackColor = True
        '
        'btnCalcle
        '
        Me.btnCalcle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCalcle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCalcle.Location = New System.Drawing.Point(1603, 718)
        Me.btnCalcle.Name = "btnCalcle"
        Me.btnCalcle.Size = New System.Drawing.Size(100, 37)
        Me.btnCalcle.TabIndex = 168
        Me.btnCalcle.Text = "CANCEL"
        Me.btnCalcle.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Location = New System.Drawing.Point(1475, 718)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 37)
        Me.btnOK.TabIndex = 167
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmChannelRangeSetttings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1718, 767)
        Me.Controls.Add(Me.btnCalcle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmChannelRangeSetttings"
        Me.Text = "frmChannelRangeSetttings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ucDispBoardRange As M7000.ucDispListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBoardRangeSetAll As System.Windows.Forms.Button
    Friend WithEvents btnBoardRangeSet As System.Windows.Forms.Button
    Friend WithEvents tbSetRangePhotoMax3 As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangePhotoMin3 As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents tbSetRangePhotoMax2 As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangePhotoMin2 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tbSetRangePhotoMax1 As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangePhotoMin1 As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents tbSetRangeCurrMax2 As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangeCurrMin2 As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tbSetRangeCurrMax1 As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangeCurrMin1 As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents tbSetRangeVoltMax As System.Windows.Forms.TextBox
    Friend WithEvents tbSetRangeVoltMin As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ucDispRangeSet As M7000.ucDispListView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSemiAutoRangeOff As System.Windows.Forms.RadioButton
    Friend WithEvents rbSemiAutoRangeOn As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAutoRangeOFF As System.Windows.Forms.RadioButton
    Friend WithEvents rbAutoRangeOn As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCurrRangeIVL_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbCurrRangeIVL_1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnRangeSetAll As System.Windows.Forms.Button
    Friend WithEvents btnRangeSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPDRange_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPDRange_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPDRange_1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents rb4Wire As System.Windows.Forms.RadioButton
    Friend WithEvents rb2Wire As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCurrRange_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbCurrRange_1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnCalcle As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
