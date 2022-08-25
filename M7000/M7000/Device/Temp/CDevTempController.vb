Public Class CDevTempController

    Public WithEvents Temperature As CDevTCCommonNode

#Region "Creator"

    Public Sub New(ByVal type As CDevTCCommonNode.eModel, ByVal numOfDev As Integer)

        Select Case type

            Case CDevTCCommonNode.eModel._NX1
                Temperature = New CDevNX1(numOfDev)
            Case CDevTCCommonNode.eModel._MC9
                Temperature = New CDevMC9(numOfDev)
            Case CDevTCCommonNode.eModel._TD500
                Temperature = New CDevTD500(numOfDev)
            Case CDevTCCommonNode.eModel._SP790
                Temperature = New CDevSP790(numOfDev)
            Case CDevTCCommonNode.eModel._TOHO_TTM004
                Temperature = New CDevTTM004(numOfDev)
        End Select

    End Sub

#End Region




End Class
