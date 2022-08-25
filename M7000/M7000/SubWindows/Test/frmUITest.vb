Public Class frmUITest


    Dim JIG As ucDispJIG

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()

        'JIG = New ucDispUnitCellJIG

        'Me.Controls.Add(JIG)

        'JIG.NumberOfCell = 7
        'JIG.CellLayout_Col = 3
        'JIG.CellLayout_Row = 3
        'JIG.Location = New System.Drawing.Point(0, 0)
        'JIG.Size = New System.Drawing.Size(300, 300)

    End Sub
End Class