Public Class ucDispMain
    Dim m_SelectCnt()() As Integer
    Dim m_maxjig As Integer
    Dim m_ivljig As Integer
    Dim LtJigs As List(Of ucDispMainJIG)
    Dim IvlJig As ucMainIVLJig
    Public Sub New(ByVal maxltjig As Integer, ByVal maxIVLjig As Integer)
        InitializeComponent()
        m_maxjig = maxltjig
        m_ivljig = maxIVLjig
        Dim W = panelmain.Size.Width / 4
        Dim H = panelmain.Size.Height / 2

        LtJigs = New List(Of ucDispMainJIG)
        If m_ivljig >= 1 Then
            IvlJig = New ucMainIVLJig()
            IvlJig.Label5.Dock = Dock.Fill
            panelmain.Controls.Add(IvlJig)

        End If

        For index = 0 To m_maxjig - 1
            Dim lt = New ucDispMainJIG(8, index + 1)
            LtJigs.Add(lt)
            panelmain.Controls.Add(LtJigs(index))
        Next

        init()
    End Sub
    Private Sub init()
        'SetPanelPosition(Me.Size)
    End Sub
    Public Sub SetCell(ByVal pallet As Integer, ByVal channel As Integer, ByVal selected As Boolean)
        If selected Then
            LtJigs(pallet).AddCell(channel + 1)
        Else
            LtJigs(pallet).SubCell(channel + 1)
        End If

    End Sub
    Public Sub SetPanelPosition()
        Dim W, H As Integer
        Dim size = Me.Size
        W = size.Width / 4
        H = size.Height / 2
        For index = 0 To m_maxjig - 1
            LtJigs(index).Size = New Size(W, H)
            LtJigs(index).SetPanelPosition()
            Select Case index
                Case 0
                    LtJigs(index).Location = New Point(0, 0)
                Case 1
                    LtJigs(index).Location = New Point(0, H)
                Case 2
                    LtJigs(index).Location = New Point(W, 0)
                Case 3
                    LtJigs(index).Location = New Point(W, H)
                Case 4
                    If m_ivljig >= 1 Then
                        LtJigs(index).Location = New Point(W * 3, 0)
                    Else
                        LtJigs(index).Location = New Point(W * 2, 0)
                    End If

                Case 5
                    If m_ivljig >= 1 Then
                        LtJigs(index).Location = New Point(W * 3, H)
                    Else
                        LtJigs(index).Location = New Point(W * 2, H)
                    End If
            End Select
        Next
        For index = 0 To m_ivljig - 1
            IvlJig.Size = New Size(W, H * 2)
            IvlJig.Location = New Point(W * 2, 0)
        Next
        'Panel1.Location = New Point(0, 0)
        'Panel2.Location = New Point(0, H)
        'Panel3.Location = New Point(W, 0)
        'Panel4.Location = New Point(W, H)
        'Panel5.Location = New Point(W * 3, 0)
        'Panel6.Location = New Point(W * 3, H)
        'Panel7.Location = New Point(W * 2, 0)

        'Panel1.Size = New Size(W, H)
        'Panel2.Size = New Size(W, H)
        'Panel3.Size = New Size(W, H)
        'Panel4.Size = New Size(W, H)
        'Panel5.Size = New Size(W, H)
        'Panel6.Size = New Size(W, H)
        'Panel7.Size = New Size(W, H * 2)

    End Sub
End Class
