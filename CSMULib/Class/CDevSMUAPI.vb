Public Class CDevSMUAPI

    Public mySMU As CDevSMUCommonNode

    Public Sub New(ByVal device As CDevSMUCommonNode.eModel, Optional ByVal numBoard As Integer = 0)

        Select Case device

            Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
                mySMU = New CDevK23x(device)

            Case CDevSMUCommonNode.eModel.KEITHLEY_K2400 To CDevSMUCommonNode.eModel.KEITHLEY_K2450
                mySMU = New CDevK24xx(device)

            Case CDevSMUCommonNode.eModel.KEITHLEY_K2601 To CDevSMUCommonNode.eModel.KEITHLEY_K2636
                mySMU = New CDevK26xx(device)

            Case CDevSMUCommonNode.eModel.MCSCIENCE_M6100
                mySMU = New CDevM6100(device, numBoard)
        End Select
    End Sub

End Class
