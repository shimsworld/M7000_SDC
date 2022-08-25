Public Class CDevPLC_API
    Public myPLC As CDevPLCCommonNode

    Public Sub New(ByVal device As CDevPLCCommonNode.eModel, ByVal fmain As frmMain, ByVal totalAXIS As Integer)
        Select Case device

            Case CDevPLCCommonNode.eModel.LS
                myPLC = New CDevPLC_LS(fmain)
            Case CDevPLCCommonNode.eModel.MITSUBISHI
                myPLC = New CDevPLC_MITSUBISHI(fmain, totalAXIS)

        End Select

    End Sub

End Class
