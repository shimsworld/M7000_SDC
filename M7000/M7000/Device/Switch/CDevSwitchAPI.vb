Public Class CDevSwitchAPI
    Public mySwitch As CDevSwitchCommonNode

    Public Sub New(ByVal device As CDevSwitchCommonNode.eModel)

        Select Case device

            Case CDevSwitchCommonNode.eModel.MC_SW7000
                mySwitch = New CDevSW7000
            Case CDevSwitchCommonNode.eModel.KEITHLEY_K7001
                mySwitch = New CDevK7001
        End Select
    End Sub
End Class
