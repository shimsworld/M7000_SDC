Public Class ucDispMainJIG
    Dim m_Maxpoint As Integer
    Public Labels() As Label
    Public pointlist As List(Of Integer)
    Public Sub New(Optional ByVal maxpoint As Integer = 8, Optional ByVal JigNum As Integer = 1)
        InitializeComponent()
        m_Maxpoint = maxpoint
        Labels = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8}
        pointlist = New List(Of Integer)
        lbName.Text = $"JIG #{JigNum}"
        init()
    End Sub
    'PointList에 특정 포인트 Add하여 출력
    Public Sub AddCell(ByVal Point As Integer)
        pointlist.Add(Point)
        pointlist.Sort()
        SetLabel()
    End Sub
    Public Sub SubCell(ByVal Point As Integer)
        pointlist.Remove(Point)
        pointlist.Sort()
        SetLabel()
    End Sub
    'Point List의 데이터 Label에 순차 출력
    Private Sub SetLabel()
        For index = 0 To m_Maxpoint - 1
            If index <= (pointlist.Count - 1) Then
                'Labels(index).Visible = True
                Labels(index).Text = $"{pointlist(index)}"
            Else
                Labels(index).Text = ""
                'Labels(index).Visible = False
            End If

        Next
    End Sub
    Private Sub init()
    End Sub
    Public Sub SetPanelPosition()
        'Dim W, H, X, Y As Integer
        'W = (lbName.Width / 4) - 1
        'H = (Me.Height - lbName.Height - 10) / 2
        'X = 5
        'Y = lbName.Height + 10

        'For index = 0 To m_Maxpoint - 1
        '    Labels(index).Size = New Size(W, H)
        '    Labels(index).Location = New Point(X, Y)
        '    If index <= 2 Then
        '        X += W + 5
        '    ElseIf index = 3 Then
        '        X = 5
        '        Y += H + 5
        '    ElseIf index < m_Maxpoint Then
        '        X += W + 5
        '    End If

        'Next


    End Sub
End Class
