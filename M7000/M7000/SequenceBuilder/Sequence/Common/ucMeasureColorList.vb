Public Class ucMeasureColorList


#Region "Define"
    Dim m_UserColorList() As eColor
    Public Shared sColorType() As String = New String() {"Red", "Green", "Blue", "White"}

#End Region


#Region "Enum"
    Public Enum eColor
        _Red
        _Green
        _Blue
        _White
    End Enum
#End Region


#Region "Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbColorList.Location = New System.Drawing.Point(0, 0)
        gbColorList.Dock = DockStyle.Fill

        With cbSelColorType
            .Items.Clear()

            For i As Integer = 0 To sColorType.Length - 1
                .Items.Add(sColorType(i))
            Next

            .SelectedIndex = 0
        End With

        Dim sData(1) As String

        sData(0) = ucListMeasColor.GetListItemCount + 1
        sData(1) = sColorType(cbSelColorType.SelectedIndex)

        ucListMeasColor.AddRowData(sData)

    End Sub
#End Region


#Region "Property"

    Public Property Setting As eColor()
        Get
            GetValueFormUI(m_UserColorList)
            Return m_UserColorList
        End Get
        Set(ByVal value As eColor())
            If value Is Nothing = False Then
                m_UserColorList = value
                SetValueToUI(m_UserColorList)
            End If

        End Set
    End Property

#End Region


#Region "Event"

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sData(1) As String

        sData(0) = ucListMeasColor.GetListItemCount + 1
        sData(1) = sColorType(cbSelColorType.SelectedIndex)

        ucListMeasColor.AddRowData(sData)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim SelectedListNo As Integer

        ucListMeasColor.GetSelectedRowNumber(SelectedListNo)

        ucListMeasColor.DelSelectedRow(SelectedListNo)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ucListMeasColor.ClearAllData()
    End Sub

#End Region



#Region "Function"

    Private Function GetValueFormUI(ByRef colorListInfo() As eColor) As Boolean

        Dim nNumber() As Integer = Nothing
        Dim nColor() As String = Nothing
        Dim nCnt As Integer

        nCnt = ucListMeasColor.GetListItemCount

        If ucListMeasColor.GetListItemCount <= 0 Then Return False

        ReDim nNumber(nCnt - 1)
        ReDim nColor(nCnt - 1)
        ReDim colorListInfo(nCnt - 1)

        ucListMeasColor.GetColumnData(0, nNumber)
        ucListMeasColor.GetColumnData(1, nColor)

        For i As Integer = 0 To ucListMeasColor.GetListItemCount - 1
            colorListInfo(i) = ConvertStringToColorNumber(nColor(i))
        Next

        Return True
    End Function

    Private Sub SetValueToUI(ByVal colorListInfo() As eColor)

        Dim sdata(1) As String

        ucListMeasColor.ClearAllData()

        For i As Integer = 0 To colorListInfo.Length - 1
            sdata(0) = CStr(i + 1)
            sdata(1) = sColorType(colorListInfo(i))

            ucListMeasColor.AddRowData(sdata)
        Next

    End Sub

#End Region


    Public Shared Function ConvertStringToColorNumber(ByVal str As String) As eColor
        Select str
            Case "Red"
                Return eColor._Red
            Case "Green"
                Return eColor._Green
            Case "Blue"
                Return eColor._Blue
            Case "White"
                Return eColor._White
            Case Else
                Return -1
        End Select
    End Function

End Class
