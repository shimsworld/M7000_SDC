<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispRcpCommon
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
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.ucDispCommonConditions = New M7000.ucCommonConditions()
        Me.ucDispSampleInfos = New M7000.ucSampleInfos()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Silver
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(219, 364)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(244, 49)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'ucDispCommonConditions
        '
        Me.ucDispCommonConditions.Location = New System.Drawing.Point(408, 2)
        Me.ucDispCommonConditions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ucDispCommonConditions.Name = "ucDispCommonConditions"
        Me.ucDispCommonConditions.Size = New System.Drawing.Size(276, 354)
        Me.ucDispCommonConditions.TabIndex = 1
        '
        'ucDispSampleInfos
        '
        Me.ucDispSampleInfos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispSampleInfos.Location = New System.Drawing.Point(3, 11)
        Me.ucDispSampleInfos.Name = "ucDispSampleInfos"
        Me.ucDispSampleInfos.Size = New System.Drawing.Size(405, 347)
        Me.ucDispSampleInfos.TabIndex = 0
        '
        'ucDispRcpCommon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.ucDispCommonConditions)
        Me.Controls.Add(Me.ucDispSampleInfos)
        Me.Controls.Add(Me.btnUpdate)
        Me.DoubleBuffered = True
        Me.Name = "ucDispRcpCommon"
        Me.Size = New System.Drawing.Size(702, 428)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents ucDispSampleInfos As M7000.ucSampleInfos
    Friend WithEvents ucDispCommonConditions As M7000.ucCommonConditions

End Class
