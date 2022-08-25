Imports System.IO.Ports
Imports CCommLib

'b_rate : 9600
'Data Bit ; 8
'Parity : none
'Stop : 1
Public Class CDevVoyager1250

    Dim communicator As CComAPI
    Dim m_Config As CComCommonNode.sCommInfo
    Dim m_bIsConnected As Boolean = False

    Dim WithEvents eventComm As CComAPI

    Shared sSupportDeviceList() As String = New String() {"Voyager1250"}

#Region "Property"

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

#End Region


#Region "Create, Dispose And Init"

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose()
        communicator = Nothing
    End Sub

#End Region

#Region "Communication"

    Public Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim str As String = Nothing
        m_bIsConnected = False
        m_Config = Config

        If communicator Is Nothing = True Then
            communicator = New CComAPI(m_Config.commType)
        End If

        If communicator.Communicator.Connect(m_Config) <> CComCommonNode.eReturnCode.OK Then Return False
        eventComm = communicator

        m_bIsConnected = True

        Return True
    End Function


    Public Function Connection() As Boolean

        m_bIsConnected = False

        If communicator Is Nothing Then Return False

        If communicator.Communicator.Connect(m_Config) <> CComCommonNode.eReturnCode.OK Then Return False

        m_bIsConnected = True

        Return True
    End Function

    Public Sub Disconnection()
        If communicator Is Nothing = False Then
            communicator.Communicator.Disconnect()
        End If

        m_bIsConnected = False
    End Sub

    Public Event evRecieveData(ByVal str As String)

    Public Sub receiveData_EventHandler(ByVal str As String) Handles eventComm.evDataRecivedToString
        RaiseEvent evRecieveData(str)
    End Sub

#End Region
End Class
