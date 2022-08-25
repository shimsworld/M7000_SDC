Public Class frmSGDacChannel
    Public ChanDac() As UcDacChannel
    Private Sub frmChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
    End Sub
    Public Sub init()

        Dim cnt As Integer = 0
        Dim AddSize As Integer = 0
        ReDim ChanDac(cDevSG.Max_DAC_Channel - 1)
        For cnt = 0 To cDevSG.Max_DAC_Channel - 1
            ChanDac(cnt) = New UcDacChannel(cnt)
            Me.Controls.Add(ChanDac(cnt))
            If cnt < 1 Then
                ChanDac(cnt).Location = New System.Drawing.Point(2, 3)
                ChanDac(cnt).Chk_CH.Text = "CH" & Format(cnt, "00")
                AddSize = AddSize + ChanDac(cnt).Height
            Else
                ChanDac(cnt).Location = New System.Drawing.Point(2, AddSize + 10)
                ChanDac(cnt).Chk_CH.Text = "CH" & Format(cnt + 1, "00")
                AddSize = AddSize + ChanDac(cnt).Height + 10
            End If

            '  ChanUI(cnt).Panel1.Enabled = False
        Next

    End Sub
End Class