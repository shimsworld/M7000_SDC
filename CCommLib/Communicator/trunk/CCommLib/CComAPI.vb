

Public Class CComAPI



    Public Event evDataRecivedToByte(ByVal nByte() As Byte)
    Public Event evDataRecivedToString(ByVal str As String)


#Region "Creator"


    Public Sub New(ByVal type As CComCommonNode.eCommType)

        Select Case type

            Case CComCommonNode.eCommType.eSerial
                Communicator = New CComSerial
            Case CComCommonNode.eCommType.eUDP
                Communicator = New CComSocket(CComSocket.eType.eUDP)
            Case CComCommonNode.eCommType.eTCP
                Communicator = New CComSocket(CComSocket.eType.eTCP)
            Case CComCommonNode.eCommType.eGPIB
                Communicator = New CComGPIB
        End Select

    End Sub


#End Region

#Region "Child"

    Public WithEvents Communicator As CComCommonNode

#End Region


    Private Sub Communicator_evDataRecivedToByte(ByVal nByte() As Byte) Handles Communicator.evDataRecivedToByte
        RaiseEvent evDataRecivedToByte(nByte)
    End Sub

    Private Sub Communicator_evDataRecivedToString(ByVal str As String) Handles Communicator.evDataRecivedToString
        RaiseEvent evDataRecivedToString(str)
    End Sub

End Class
