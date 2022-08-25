Public Class frmGrpPlotItemSelector



    Dim sPlotItemIndex() As String
    Dim sPlotItemColor() As System.Drawing.Color
    Dim nSelectedRowIndex As Integer = 0


    Public Property ItemIndex() As String()
        Get
            Return sPlotItemIndex
        End Get
        Set(ByVal value() As String)
            sPlotItemIndex = value
        End Set
    End Property

    Public Property ItemColor() As System.Drawing.Color()
        Get
            Return sPlotItemColor
        End Get
        Set(ByVal value As System.Drawing.Color())
            sPlotItemColor = value
        End Set
    End Property

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub init()
        sPlotItemIndex = Nothing
        sPlotItemColor = Nothing
    End Sub

    Private Sub frmGrpPlotItemSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dispList.UseCheckBoxex = False
        dispList.ClearAllData()

        If sPlotItemIndex Is Nothing Or sPlotItemColor Is Nothing Then Exit Sub
        Dim lineInfo(1) As Object

        For i As Integer = 0 To sPlotItemColor.Length - 1

            dispList.AddRowData(sPlotItemIndex(i), sPlotItemColor(i))
        Next
    End Sub

  
    Private Sub dispList_evSelectedIndexChanged(ByVal nRow As Integer) Handles dispList.evSelectedIndexChanged

        If nRow < 0 Or nRow > sPlotItemColor.Length - 1 Then Exit Sub
        lblColor.BackColor = sPlotItemColor(nRow)
        nSelectedRowIndex = nRow
    End Sub

    Private Sub btnChangeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeColor.Click
        Dim dlg As New System.Windows.Forms.ColorDialog

        If dlg.ShowDialog(Me) = DialogResult.OK Then
            sPlotItemColor(nSelectedRowIndex) = dlg.Color
            dispList.SetRowData(nSelectedRowIndex, sPlotItemIndex(nSelectedRowIndex), sPlotItemColor(nSelectedRowIndex))
            lblColor.BackColor = sPlotItemColor(nSelectedRowIndex)
        End If

    End Sub
End Class