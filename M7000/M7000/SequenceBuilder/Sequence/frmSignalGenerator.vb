Public Class frmSignalGenerator

    Public Event evUpdateSingleGeneratorData(ByVal infos As ucDispSignalGenerator.sSGDatas)

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        UcDispSignalGenerator1.Location = New System.Drawing.Point(0, 0)
        UcDispSignalGenerator1.Dock = DockStyle.Fill
    End Sub

    Private Sub frmSignalGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

 
End Class