<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigMcPGGroup
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
        Me.gbConfig = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbSeedCh = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkEnablePDUnit = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbPDUnitNoTo = New System.Windows.Forms.TextBox()
        Me.tbPDUnitNoFrom = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkEnablePGCtrlBD = New System.Windows.Forms.CheckBox()
        Me.tbPGCtrlBDNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkEnablePGPwr = New System.Windows.Forms.CheckBox()
        Me.tbPGPwrNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkEnablePG = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbPGNoTo = New System.Windows.Forms.TextBox()
        Me.tbPGNoFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.ConfigList = New M7000.ucDispListView()
        Me.gbConfig.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.GroupBox3)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Location = New System.Drawing.Point(20, 25)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(1115, 165)
        Me.gbConfig.TabIndex = 7
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Group Settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbSeedCh)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.chkEnablePDUnit)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbPDUnitNoTo)
        Me.GroupBox3.Controls.Add(Me.tbPDUnitNoFrom)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.chkEnablePGCtrlBD)
        Me.GroupBox3.Controls.Add(Me.tbPGCtrlBDNo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.chkEnablePGPwr)
        Me.GroupBox3.Controls.Add(Me.tbPGPwrNo)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.chkEnablePG)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.tbPGNoTo)
        Me.GroupBox3.Controls.Add(Me.tbPGNoFrom)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(365, 144)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Device"
        '
        'tbSeedCh
        '
        Me.tbSeedCh.Location = New System.Drawing.Point(230, 14)
        Me.tbSeedCh.Name = "tbSeedCh"
        Me.tbSeedCh.Size = New System.Drawing.Size(49, 21)
        Me.tbSeedCh.TabIndex = 28
        Me.tbSeedCh.Text = "0"
        Me.tbSeedCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 12)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Seed Channel No. :"
        '
        'chkEnablePDUnit
        '
        Me.chkEnablePDUnit.AutoSize = True
        Me.chkEnablePDUnit.Location = New System.Drawing.Point(20, 120)
        Me.chkEnablePDUnit.Name = "chkEnablePDUnit"
        Me.chkEnablePDUnit.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePDUnit.TabIndex = 26
        Me.chkEnablePDUnit.Text = "Enable"
        Me.chkEnablePDUnit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "~"
        '
        'tbPDUnitNoTo
        '
        Me.tbPDUnitNoTo.Location = New System.Drawing.Point(306, 115)
        Me.tbPDUnitNoTo.Name = "tbPDUnitNoTo"
        Me.tbPDUnitNoTo.Size = New System.Drawing.Size(49, 21)
        Me.tbPDUnitNoTo.TabIndex = 24
        Me.tbPDUnitNoTo.Text = "0"
        Me.tbPDUnitNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbPDUnitNoFrom
        '
        Me.tbPDUnitNoFrom.Location = New System.Drawing.Point(230, 115)
        Me.tbPDUnitNoFrom.Name = "tbPDUnitNoFrom"
        Me.tbPDUnitNoFrom.Size = New System.Drawing.Size(49, 21)
        Me.tbPDUnitNoFrom.TabIndex = 23
        Me.tbPDUnitNoFrom.Text = "0"
        Me.tbPDUnitNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(173, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 12)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "PD Unit :"
        '
        'chkEnablePGCtrlBD
        '
        Me.chkEnablePGCtrlBD.AutoSize = True
        Me.chkEnablePGCtrlBD.Location = New System.Drawing.Point(20, 92)
        Me.chkEnablePGCtrlBD.Name = "chkEnablePGCtrlBD"
        Me.chkEnablePGCtrlBD.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePGCtrlBD.TabIndex = 21
        Me.chkEnablePGCtrlBD.Text = "Enable"
        Me.chkEnablePGCtrlBD.UseVisualStyleBackColor = True
        '
        'tbPGCtrlBDNo
        '
        Me.tbPGCtrlBDNo.Location = New System.Drawing.Point(230, 90)
        Me.tbPGCtrlBDNo.Name = "tbPGCtrlBDNo"
        Me.tbPGCtrlBDNo.Size = New System.Drawing.Size(49, 21)
        Me.tbPGCtrlBDNo.TabIndex = 18
        Me.tbPGCtrlBDNo.Text = "0"
        Me.tbPGCtrlBDNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(160, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "PG Board :"
        '
        'chkEnablePGPwr
        '
        Me.chkEnablePGPwr.AutoSize = True
        Me.chkEnablePGPwr.Location = New System.Drawing.Point(20, 66)
        Me.chkEnablePGPwr.Name = "chkEnablePGPwr"
        Me.chkEnablePGPwr.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePGPwr.TabIndex = 16
        Me.chkEnablePGPwr.Text = "Enable"
        Me.chkEnablePGPwr.UseVisualStyleBackColor = True
        '
        'tbPGPwrNo
        '
        Me.tbPGPwrNo.Location = New System.Drawing.Point(230, 64)
        Me.tbPGPwrNo.Name = "tbPGPwrNo"
        Me.tbPGPwrNo.Size = New System.Drawing.Size(49, 21)
        Me.tbPGPwrNo.TabIndex = 13
        Me.tbPGPwrNo.Text = "0"
        Me.tbPGPwrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "PG Power :"
        '
        'chkEnablePG
        '
        Me.chkEnablePG.AutoSize = True
        Me.chkEnablePG.Location = New System.Drawing.Point(20, 42)
        Me.chkEnablePG.Name = "chkEnablePG"
        Me.chkEnablePG.Size = New System.Drawing.Size(63, 16)
        Me.chkEnablePG.TabIndex = 11
        Me.chkEnablePG.Text = "Enable"
        Me.chkEnablePG.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(286, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "~"
        '
        'tbPGNoTo
        '
        Me.tbPGNoTo.Location = New System.Drawing.Point(306, 39)
        Me.tbPGNoTo.Name = "tbPGNoTo"
        Me.tbPGNoTo.Size = New System.Drawing.Size(49, 21)
        Me.tbPGNoTo.TabIndex = 9
        Me.tbPGNoTo.Text = "0"
        Me.tbPGNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbPGNoFrom
        '
        Me.tbPGNoFrom.Location = New System.Drawing.Point(230, 39)
        Me.tbPGNoFrom.Name = "tbPGNoFrom"
        Me.tbPGNoFrom.Size = New System.Drawing.Size(49, 21)
        Me.tbPGNoFrom.TabIndex = 8
        Me.tbPGNoFrom.Text = "0"
        Me.tbPGNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(115, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Pattern Generator :"
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(377, 20)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(75, 43)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(377, 114)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 43)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(377, 67)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(75, 43)
        Me.btnListDel.TabIndex = 6
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"Group ID", "Seed Ch", "PG No", "PG Power No", "PG Board No", "PD Unit No"}
        Me.ConfigList.ColHeaderWidthRatio = "15,15,20,15,15,20"
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.Location = New System.Drawing.Point(458, 20)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(640, 138)
        Me.ConfigList.TabIndex = 5
        Me.ConfigList.UseCheckBoxex = False
        '
        'ucConfigPG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigPG"
        Me.Size = New System.Drawing.Size(1256, 492)
        Me.gbConfig.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnablePDUnit As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbPDUnitNoTo As System.Windows.Forms.TextBox
    Friend WithEvents tbPDUnitNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkEnablePGCtrlBD As System.Windows.Forms.CheckBox
    Friend WithEvents tbPGCtrlBDNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkEnablePGPwr As System.Windows.Forms.CheckBox
    Friend WithEvents tbPGPwrNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkEnablePG As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbPGNoTo As System.Windows.Forms.TextBox
    Friend WithEvents tbPGNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents ConfigList As M7000.ucDispListView
    Friend WithEvents tbSeedCh As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
