Public Class frmImageManager

    Dim MyParent As frmMain


#Region "Creator & Init"


#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ucPGImageManager.SaveConfiguration()

    End Sub

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Me.Close()
    End Sub

    Private Sub frmImageManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class