Public Class CDevIVLPowerSupplyAPI
    Public myPwr As CDevIVLPowerSupplyCommonNode
    Public Sub New(ByVal device As CDevSwitchCommonNode.eModel)
        Select Case device
            Case CDevIVLPowerSupplyCommonNode.eModel.SPE3051
                myPwr = New CDevIVLPowersupply
        End Select
    End Sub
End Class
