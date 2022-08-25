<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSGOutputDefine
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelOutputAssign = New System.Windows.Forms.Button()
        Me.btnClearOutputAssign = New System.Windows.Forms.Button()
        Me.btnAddOutputAssign = New System.Windows.Forms.Button()
        Me.cbSelMainPower2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelMainPower1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListMainPower = New M7000.ucDispListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDelOutputName = New System.Windows.Forms.Button()
        Me.tbOutputLineName = New System.Windows.Forms.TextBox()
        Me.btnClearOutputName = New System.Windows.Forms.Button()
        Me.btnAddOutputName = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSelSGOuputLine = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListOutputName = New M7000.ucDispListView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSelMajorCtrlSignal_Red = New System.Windows.Forms.ComboBox()
        Me.cbSelMajorCtrlSignal_Green = New System.Windows.Forms.ComboBox()
        Me.cbSelMajorCtrlSignal_Blue = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelOutputAssign)
        Me.GroupBox1.Controls.Add(Me.btnClearOutputAssign)
        Me.GroupBox1.Controls.Add(Me.btnAddOutputAssign)
        Me.GroupBox1.Controls.Add(Me.cbSelMainPower2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbSelMainPower1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ListMainPower)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 366)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Output Assingment"
        '
        'btnDelOutputAssign
        '
        Me.btnDelOutputAssign.Location = New System.Drawing.Point(91, 87)
        Me.btnDelOutputAssign.Name = "btnDelOutputAssign"
        Me.btnDelOutputAssign.Size = New System.Drawing.Size(57, 31)
        Me.btnDelOutputAssign.TabIndex = 11
        Me.btnDelOutputAssign.Text = "DEL"
        Me.btnDelOutputAssign.UseVisualStyleBackColor = True
        '
        'btnClearOutputAssign
        '
        Me.btnClearOutputAssign.Location = New System.Drawing.Point(153, 87)
        Me.btnClearOutputAssign.Name = "btnClearOutputAssign"
        Me.btnClearOutputAssign.Size = New System.Drawing.Size(57, 31)
        Me.btnClearOutputAssign.TabIndex = 10
        Me.btnClearOutputAssign.Text = "CLEAR"
        Me.btnClearOutputAssign.UseVisualStyleBackColor = True
        '
        'btnAddOutputAssign
        '
        Me.btnAddOutputAssign.Location = New System.Drawing.Point(28, 87)
        Me.btnAddOutputAssign.Name = "btnAddOutputAssign"
        Me.btnAddOutputAssign.Size = New System.Drawing.Size(57, 31)
        Me.btnAddOutputAssign.TabIndex = 9
        Me.btnAddOutputAssign.Text = "ADD"
        Me.btnAddOutputAssign.UseVisualStyleBackColor = True
        '
        'cbSelMainPower2
        '
        Me.cbSelMainPower2.FormattingEnabled = True
        Me.cbSelMainPower2.Location = New System.Drawing.Point(106, 55)
        Me.cbSelMainPower2.Name = "cbSelMainPower2"
        Me.cbSelMainPower2.Size = New System.Drawing.Size(79, 20)
        Me.cbSelMainPower2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Main Power2 :"
        '
        'cbSelMainPower1
        '
        Me.cbSelMainPower1.FormattingEnabled = True
        Me.cbSelMainPower1.Location = New System.Drawing.Point(106, 27)
        Me.cbSelMainPower1.Name = "cbSelMainPower1"
        Me.cbSelMainPower1.Size = New System.Drawing.Size(79, 20)
        Me.cbSelMainPower1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Main Power1 :"
        '
        'ListMainPower
        '
        Me.ListMainPower.ColHeader = New String() {"Ch.", "Main Power1", "Main Power2"}
        Me.ListMainPower.ColHeaderWidthRatio = "20,40,40"
        Me.ListMainPower.FullRawSelection = True
        Me.ListMainPower.Location = New System.Drawing.Point(7, 125)
        Me.ListMainPower.Name = "ListMainPower"
        Me.ListMainPower.Size = New System.Drawing.Size(231, 235)
        Me.ListMainPower.TabIndex = 0
        Me.ListMainPower.UseCheckBoxex = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDelOutputName)
        Me.GroupBox2.Controls.Add(Me.tbOutputLineName)
        Me.GroupBox2.Controls.Add(Me.btnClearOutputName)
        Me.GroupBox2.Controls.Add(Me.btnAddOutputName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbSelSGOuputLine)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ListOutputName)
        Me.GroupBox2.Location = New System.Drawing.Point(251, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(265, 366)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Output Name"
        '
        'btnDelOutputName
        '
        Me.btnDelOutputName.Location = New System.Drawing.Point(101, 87)
        Me.btnDelOutputName.Name = "btnDelOutputName"
        Me.btnDelOutputName.Size = New System.Drawing.Size(57, 31)
        Me.btnDelOutputName.TabIndex = 14
        Me.btnDelOutputName.Text = "DEL"
        Me.btnDelOutputName.UseVisualStyleBackColor = True
        '
        'tbOutputLineName
        '
        Me.tbOutputLineName.Location = New System.Drawing.Point(85, 56)
        Me.tbOutputLineName.Name = "tbOutputLineName"
        Me.tbOutputLineName.Size = New System.Drawing.Size(160, 21)
        Me.tbOutputLineName.TabIndex = 8
        '
        'btnClearOutputName
        '
        Me.btnClearOutputName.Location = New System.Drawing.Point(164, 87)
        Me.btnClearOutputName.Name = "btnClearOutputName"
        Me.btnClearOutputName.Size = New System.Drawing.Size(57, 31)
        Me.btnClearOutputName.TabIndex = 13
        Me.btnClearOutputName.Text = "CLEAR"
        Me.btnClearOutputName.UseVisualStyleBackColor = True
        '
        'btnAddOutputName
        '
        Me.btnAddOutputName.Location = New System.Drawing.Point(39, 87)
        Me.btnAddOutputName.Name = "btnAddOutputName"
        Me.btnAddOutputName.Size = New System.Drawing.Size(57, 31)
        Me.btnAddOutputName.TabIndex = 12
        Me.btnAddOutputName.Text = "ADD"
        Me.btnAddOutputName.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Line Name :"
        '
        'cbSelSGOuputLine
        '
        Me.cbSelSGOuputLine.FormattingEnabled = True
        Me.cbSelSGOuputLine.Location = New System.Drawing.Point(85, 26)
        Me.cbSelSGOuputLine.Name = "cbSelSGOuputLine"
        Me.cbSelSGOuputLine.Size = New System.Drawing.Size(90, 20)
        Me.cbSelSGOuputLine.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Output Line :"
        '
        'ListOutputName
        '
        Me.ListOutputName.ColHeader = New String() {"No.", "Output Line", "Name"}
        Me.ListOutputName.ColHeaderWidthRatio = "15,35,50"
        Me.ListOutputName.FullRawSelection = True
        Me.ListOutputName.Location = New System.Drawing.Point(5, 125)
        Me.ListOutputName.Name = "ListOutputName"
        Me.ListOutputName.Size = New System.Drawing.Size(253, 235)
        Me.ListOutputName.TabIndex = 1
        Me.ListOutputName.UseCheckBoxex = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbSelMajorCtrlSignal_Blue)
        Me.GroupBox3.Controls.Add(Me.cbSelMajorCtrlSignal_Green)
        Me.GroupBox3.Controls.Add(Me.cbSelMajorCtrlSignal_Red)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(526, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(176, 366)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Major Control Signal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Red :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Blue :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Green :"
        '
        'cbSelMajorCtrlSignal_Red
        '
        Me.cbSelMajorCtrlSignal_Red.FormattingEnabled = True
        Me.cbSelMajorCtrlSignal_Red.Location = New System.Drawing.Point(66, 26)
        Me.cbSelMajorCtrlSignal_Red.Name = "cbSelMajorCtrlSignal_Red"
        Me.cbSelMajorCtrlSignal_Red.Size = New System.Drawing.Size(104, 20)
        Me.cbSelMajorCtrlSignal_Red.TabIndex = 7
        '
        'cbSelMajorCtrlSignal_Green
        '
        Me.cbSelMajorCtrlSignal_Green.FormattingEnabled = True
        Me.cbSelMajorCtrlSignal_Green.Location = New System.Drawing.Point(66, 56)
        Me.cbSelMajorCtrlSignal_Green.Name = "cbSelMajorCtrlSignal_Green"
        Me.cbSelMajorCtrlSignal_Green.Size = New System.Drawing.Size(104, 20)
        Me.cbSelMajorCtrlSignal_Green.TabIndex = 8
        '
        'cbSelMajorCtrlSignal_Blue
        '
        Me.cbSelMajorCtrlSignal_Blue.FormattingEnabled = True
        Me.cbSelMajorCtrlSignal_Blue.Location = New System.Drawing.Point(66, 89)
        Me.cbSelMajorCtrlSignal_Blue.Name = "cbSelMajorCtrlSignal_Blue"
        Me.cbSelMajorCtrlSignal_Blue.Size = New System.Drawing.Size(104, 20)
        Me.cbSelMajorCtrlSignal_Blue.TabIndex = 9
        '
        'ucSGOutputDefine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucSGOutputDefine"
        Me.Size = New System.Drawing.Size(712, 380)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelMainPower1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListMainPower As M7000.ucDispListView
    Friend WithEvents cbSelMainPower2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbOutputLineName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbSelSGOuputLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListOutputName As M7000.ucDispListView
    Friend WithEvents btnDelOutputAssign As System.Windows.Forms.Button
    Friend WithEvents btnClearOutputAssign As System.Windows.Forms.Button
    Friend WithEvents btnAddOutputAssign As System.Windows.Forms.Button
    Friend WithEvents btnDelOutputName As System.Windows.Forms.Button
    Friend WithEvents btnClearOutputName As System.Windows.Forms.Button
    Friend WithEvents btnAddOutputName As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelMajorCtrlSignal_Blue As System.Windows.Forms.ComboBox
    Friend WithEvents cbSelMajorCtrlSignal_Green As System.Windows.Forms.ComboBox
    Friend WithEvents cbSelMajorCtrlSignal_Red As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
