Public Class frmTempWind

    Dim dTemp As Double

    Public Property Temp As Double
        Get
            Return dTemp
        End Get
        Set(ByVal value As Double)
            dTemp = value
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            dTemp = tbTemp.Text
        Catch ex As Exception
            MsgBox("Input value is incorrect.")
            Exit Sub
        End Try
    End Sub

    Private Sub btnCalcle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub

End Class