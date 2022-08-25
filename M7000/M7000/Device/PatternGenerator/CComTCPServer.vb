Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Threading

Public Class CComTCPServer

#Region "Defines"

    Dim server As TcpListener
    Public clients(249) As CCommLib.CComSocket
    Dim clientEndPointList(249) As String
    Dim bIsConnectedClients(249) As Boolean
    Dim nClientCounter As Integer = 0

    Dim m_sServerOpenTime As Single = 2 'Server Open time for accept clients(default value : 2 sec)

    Dim trdSockConnection As Thread
    Dim m_bIsStopSockConnectionThread As Boolean

    Public Event evStatusMessage(ByVal msg As String)
    Public Event evChangedConnectedClients(ByVal list() As String)

#End Region

#Region "Properties"

    Public ReadOnly Property numberOfClients As Integer
        Get
            Return nClientCounter
        End Get
    End Property

    Public ReadOnly Property ClientList As String()
        Get
            Return clientEndPointList
        End Get
    End Property

    Public ReadOnly Property IsConnectedClients As Boolean()
        Get
            Return bIsConnectedClients
        End Get
    End Property

    Public Property ServerOpenTime As Single
        Get
            Return m_sServerOpenTime
        End Get
        Set(value As Single)
            m_sServerOpenTime = value
        End Set
    End Property

    Public ReadOnly Property IsServerClosed As Boolean
        Get
            Return m_bIsStopSockConnectionThread
        End Get
    End Property


#End Region

#Region "Creator And Disposer, init"

    Public Sub New()

        ReDim clients(249)
        ReDim clientEndPointList(249)

        For i As Integer = 0 To clientEndPointList.Length - 1
            clientEndPointList(i) = "Nothing"
        Next

        For i As Integer = 0 To bIsConnectedClients.Length - 1
            bIsConnectedClients(i) = False
        Next

        nClientCounter = 0
    End Sub

#End Region


#Region "Server Functions"

    Public Sub Open()

        
        trdSockConnection = New Thread(AddressOf AcceptClient)
        trdSockConnection.Priority = ThreadPriority.Normal
        m_bIsStopSockConnectionThread = False
        trdSockConnection.Start()
    End Sub

    Public Sub Close()
        m_bIsStopSockConnectionThread = True
    End Sub


    Private Sub AcceptClient()

        Dim sStartTime As Single
        Dim sWaitingTime As Single

        server = Nothing
        Try
            ' Set the TcpListener on port 13000.
            Dim port As Int32 = 8888
            Dim localAddr As IPAddress = IPAddress.Any ' IPAddress.Parse("127.0.0.1")

            server = New TcpListener(localAddr, port)

            ' Start listening for client requests.
            server.Start()

            RaiseEvent evStatusMessage("Start listening for client requests.")

            sStartTime = timer_Sec()
            ' Enter the listening loop.
            While True

                Application.DoEvents()
                Thread.Sleep(50)

                If m_bIsStopSockConnectionThread = True Then Exit While
                ' Perform a blocking call to accept requests.
                ' You could also user server.AcceptSocket() here.

                If server.Pending = True Then
                    Dim client As TcpClient ' client(nClientCounter)
                    Dim socket As System.Net.Sockets.Socket
                    Dim clientEndPoint As System.Net.IPEndPoint
                    Dim sIP As String
                    Dim arryTemp As Array

                    client = server.AcceptTcpClient()
                    socket = client.Client
                    clientEndPoint = socket.RemoteEndPoint
                    sIP = clientEndPoint.Address.ToString
                    arryTemp = Split(sIP, ".", -1)

                    clients(CInt(arryTemp(3))) = New CCommLib.CComSocket(CCommLib.CComSocket.eType.eTCP)

                    clientEndPointList(CInt(arryTemp(3))) = sIP
                    bIsConnectedClients(CInt(arryTemp(3))) = True

                    RaiseEvent evChangedConnectedClients(clientEndPointList)
                End If

                '시간 Check
                sWaitingTime = timer_Sec() - sStartTime
                If sWaitingTime < 0 Then sWaitingTime = sWaitingTime + 3600
                If sWaitingTime > m_sServerOpenTime Then
                    m_bIsStopSockConnectionThread = True
                    Exit While
                End If

            End While

            nClientCounter = 0
            For i As Integer = 0 To bIsConnectedClients.Length - 1
                If bIsConnectedClients(i) = True Then
                    nClientCounter += 1
                End If
            Next

        Catch e As SocketException
            ' MsgBox(e.Message.ToString)
            RaiseEvent evStatusMessage(e.Message.ToString)
        Finally
            server.Stop()
            RaiseEvent evStatusMessage("Close Server")
        End Try

      

    End Sub

    Public Sub CloseClient(ByVal clientIdx As Integer)
        clients(clientIdx) = Nothing
        clientEndPointList(clientIdx) = "Nothing"
        bIsConnectedClients(clientIdx) = False
        nClientCounter = 0
        For i As Integer = 0 To bIsConnectedClients.Length - 1
            If bIsConnectedClients(i) = True Then
                nClientCounter += 1
            End If
        Next
        RaiseEvent evChangedConnectedClients(clientEndPointList)
    End Sub


#End Region


#Region "Other Functions"

    Private Function timer_Sec() As Single
        Return CSng((Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000))
    End Function

#End Region


End Class
