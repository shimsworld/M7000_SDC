Public Class ucDispImage


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill

        cbTitle.Location = New System.Drawing.Point(0, 0)
        cbTitle.Dock = DockStyle.Fill

        pbImage.Location = New System.Drawing.Point(0, 0)
        pbImage.Dock = DockStyle.Fill
    End Sub

End Class
