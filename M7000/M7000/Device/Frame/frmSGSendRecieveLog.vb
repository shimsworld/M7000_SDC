Public Class frmSGSendRecieveLog

    Private Sub btn_LogReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LogReset.Click
        LogSend.ClearAllData()
        LogRcv.ClearAllData()
    End Sub

    Private Sub frmSendRecieveLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler LogSend.ListEventClick, AddressOf fSendMultiLineText
        AddHandler LogRcv.ListEventClick, AddressOf fRcvMultiLineText
    End Sub
    Public Sub fRcvMultiLineText()
        txt_mline.Text = LogRcv.SelectData
    End Sub
    Public Sub fSendMultiLineText()
        txt_mline.Text = LogSend.SelectData

    End Sub
End Class