<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigDevice
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbNumOfJIG = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMaxCh = New System.Windows.Forms.TextBox()
        Me.lblMaxCh = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpCommon = New System.Windows.Forms.TabPage()
        Me.tbNumOfIVLJIG = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNumOfPallet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancle = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.ucMotionConfig = New M7000.ucConfigMotion()
        Me.TabControl1.SuspendLayout()
        Me.tpCommon.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbNumOfJIG
        '
        Me.tbNumOfJIG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbNumOfJIG.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumOfJIG.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbNumOfJIG.Location = New System.Drawing.Point(163, 83)
        Me.tbNumOfJIG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNumOfJIG.Name = "tbNumOfJIG"
        Me.tbNumOfJIG.Size = New System.Drawing.Size(70, 21)
        Me.tbNumOfJIG.TabIndex = 6
        Me.tbNumOfJIG.Text = "0"
        Me.tbNumOfJIG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Number Of JIG"
        '
        'txtMaxCh
        '
        Me.txtMaxCh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxCh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxCh.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtMaxCh.Location = New System.Drawing.Point(163, 37)
        Me.txtMaxCh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaxCh.Name = "txtMaxCh"
        Me.txtMaxCh.Size = New System.Drawing.Size(70, 21)
        Me.txtMaxCh.TabIndex = 4
        Me.txtMaxCh.Text = "0"
        Me.txtMaxCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMaxCh
        '
        Me.lblMaxCh.AutoSize = True
        Me.lblMaxCh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxCh.Location = New System.Drawing.Point(31, 39)
        Me.lblMaxCh.Name = "lblMaxCh"
        Me.lblMaxCh.Size = New System.Drawing.Size(126, 15)
        Me.lblMaxCh.TabIndex = 3
        Me.lblMaxCh.Text = "System Max Channel"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tpCommon)
        Me.TabControl1.Location = New System.Drawing.Point(9, 12)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(308, 302)
        Me.TabControl1.TabIndex = 1
        '
        'tpCommon
        '
        Me.tpCommon.Controls.Add(Me.tbNumOfIVLJIG)
        Me.tpCommon.Controls.Add(Me.Label3)
        Me.tpCommon.Controls.Add(Me.tbNumOfPallet)
        Me.tpCommon.Controls.Add(Me.Label2)
        Me.tpCommon.Controls.Add(Me.tbNumOfJIG)
        Me.tpCommon.Controls.Add(Me.lblMaxCh)
        Me.tpCommon.Controls.Add(Me.txtMaxCh)
        Me.tpCommon.Controls.Add(Me.Label1)
        Me.tpCommon.Location = New System.Drawing.Point(4, 27)
        Me.tpCommon.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tpCommon.Name = "tpCommon"
        Me.tpCommon.Size = New System.Drawing.Size(300, 271)
        Me.tpCommon.TabIndex = 2
        Me.tpCommon.Text = "Common"
        Me.tpCommon.UseVisualStyleBackColor = True
        '
        'tbNumOfIVLJIG
        '
        Me.tbNumOfIVLJIG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbNumOfIVLJIG.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumOfIVLJIG.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbNumOfIVLJIG.Location = New System.Drawing.Point(163, 172)
        Me.tbNumOfIVLJIG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNumOfIVLJIG.Name = "tbNumOfIVLJIG"
        Me.tbNumOfIVLJIG.Size = New System.Drawing.Size(70, 21)
        Me.tbNumOfIVLJIG.TabIndex = 12
        Me.tbNumOfIVLJIG.Text = "0"
        Me.tbNumOfIVLJIG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Number Of IVLJIG"
        '
        'tbNumOfPallet
        '
        Me.tbNumOfPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbNumOfPallet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumOfPallet.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbNumOfPallet.Location = New System.Drawing.Point(163, 132)
        Me.tbNumOfPallet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNumOfPallet.Name = "tbNumOfPallet"
        Me.tbNumOfPallet.Size = New System.Drawing.Size(70, 21)
        Me.tbNumOfPallet.TabIndex = 8
        Me.tbNumOfPallet.Text = "0"
        Me.tbNumOfPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Number Of Pallet"
        '
        'btnCancle
        '
        Me.btnCancle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancle.Location = New System.Drawing.Point(1277, 646)
        Me.btnCancle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancle.Name = "btnCancle"
        Me.btnCancle.Size = New System.Drawing.Size(138, 51)
        Me.btnCancle.TabIndex = 1
        Me.btnCancle.Text = "Cancel"
        Me.btnCancle.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(1136, 647)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(131, 51)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(816, 639)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(131, 51)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(956, 639)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(131, 51)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        Me.btnLoad.Visible = False
        '
        'ucMotionConfig
        '
        Me.ucMotionConfig.Location = New System.Drawing.Point(526, 215)
        Me.ucMotionConfig.Margin = New System.Windows.Forms.Padding(4)
        Me.ucMotionConfig.Name = "ucMotionConfig"
        Me.ucMotionConfig.Setting = Nothing
        Me.ucMotionConfig.Size = New System.Drawing.Size(889, 314)
        Me.ucMotionConfig.TabIndex = 4
        '
        'frmConfigDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1463, 713)
        Me.Controls.Add(Me.ucMotionConfig)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancle)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmConfigDevice"
        Me.Text = "Device Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.tpCommon.ResumeLayout(False)
        Me.tpCommon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMaxCh As System.Windows.Forms.TextBox
    Friend WithEvents lblMaxCh As System.Windows.Forms.Label
    Friend WithEvents tbNumOfJIG As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpCommon As System.Windows.Forms.TabPage
    Friend WithEvents tbNumOfPallet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbNumOfIVLJIG As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancle As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents ucMotionConfig As ucConfigMotion
End Class
