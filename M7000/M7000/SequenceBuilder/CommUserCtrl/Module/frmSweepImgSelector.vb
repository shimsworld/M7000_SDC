Public Class frmSweepImgSelector

    Dim myParent As frmMain
    Public WithEvents DispImageSelector As M7000.ucDispPGImageSweep

    Public Sub New(ByVal parent As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
        init()
    End Sub

    Private Sub init()

        DispImageSelector = New M7000.ucDispPGImageSweep(g_sPATH_PG_IMAGE & "\frmSweepImageSelector")
        '
        'UcDispImageSelector
        '
        DispImageSelector.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DispImageSelector.Location = New System.Drawing.Point(3, 1)
        DispImageSelector.Name = "UcDispImageSelector"
        DispImageSelector.Size = New System.Drawing.Size(1018, 586)
        DispImageSelector.TabIndex = 0
        DispImageSelector.VisibleMode = M7000.ucDispPGImageSweep.eViewMode._ImageSweep
        Me.Controls.Add(DispImageSelector)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class