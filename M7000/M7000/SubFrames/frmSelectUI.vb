Public Class frmSelectUI


    Dim m_SelectType As String = Nothing

    Public ReadOnly Property TypeSelect As String
        Get
            Return m_SelectType
        End Get
    End Property

    Private Sub rb6X5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb6X5.CheckedChanged, rb6X5.CheckedChanged
        If rb6X5.Checked = True Then
            rb6X5.BackColor = Color.Orange
            rb2X2.BackColor = Color.White
            m_SelectType = "Type1_"
        ElseIf rb2X2.Checked = True Then
            rb6X5.BackColor = Color.White
            rb2X2.BackColor = Color.Orange
            m_SelectType = "Type2_"
        End If

    End Sub

 
End Class