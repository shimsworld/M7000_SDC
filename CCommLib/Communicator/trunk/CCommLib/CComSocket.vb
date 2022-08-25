﻿Imports System.Net.Sockets
Imports System.Text
Imports System.Net

Public Class CComSocket
    Inherits CComCommonNode
    Dim cUDP As System.Net.Sockets.UdpClient
    Dim WithEvents cTCP As System.Net.Sockets.TcpClient
    Dim m_Config As sSockInfos
    ' Dim m_CommType As eType

#Region "Defines"


#Region "Enums"

    Public Enum eDataType
        eString
        eByte
    End Enum

    Public Enum eType
        eUDP
        eTCP
    End Enum

#End Region

#Region "Structure"

    Public Structure sSockInfos
        Dim sIPAddress As String
        Dim nPort As Integer
        Dim sSendTerminator As String 'STX
        Dim sRcvTerminator As String 'EOT
    End Structure


#End Region

#Region "Properties"

    ''' <summary>
    ''' ACK Time out by sec
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property TimeOut As Double
        Get
            Return MyBase.TimeOut
        End Get
        Set(value As Double)
            MyBase.TimeOut = value
        End Set
    End Property


#End Region

#End Region

#Region "Creator, Disposer And Init"


    Public Sub New(ByVal type As eType)
        m_CommType = type
        Select Case m_CommType
            Case eType.eTCP
                cTCP = New TcpClient()
            Case eType.eUDP
                cUDP = New UdpClient()
        End Select

        m_dTimeOut = 1
    End Sub

    Public Sub New(ByVal client As System.Net.Sockets.TcpClient)
        m_CommType = eCommType.eTCP
        cTCP = client
        m_dTimeOut = 1
    End Sub

#End Region


    Public Overrides Function Connect(ByVal config As sCommInfo) As eReturnCode
        m_Config = config.sLanInfo
        Try
            Select Case m_CommType
                Case eType.eTCP
                    cTCP = New TcpClient
                    cTCP.Connect(m_Config.sIPAddress, m_Config.nPort)
                Case eType.eUDP
                    cUDP = New UdpClient
                    cUDP.Connect(m_Config.sIPAddress, m_Config.nPort)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return eReturnCode.FuncErr
        End Try
        Return eReturnCode.OK
    End Function

    Public Overrides Sub Connect(ByVal config As sSockInfos)
        m_Config = config
        Select Case m_CommType
            Case eType.eTCP
                cTCP = New TcpClient
                cTCP.Connect(m_Config.sIPAddress, m_Config.nPort)
            Case eType.eUDP
                cUDP = New UdpClient
                cUDP.Connect(m_Config.sIPAddress, m_Config.nPort)
        End Select
    End Sub

    Public Sub Connection(ByVal config As sSockInfos)
        m_Config = config
        Select Case m_CommType
            Case eType.eTCP
                cTCP.Connect(m_Config.sIPAddress, m_Config.nPort)
            Case eType.eUDP
                cUDP.Connect(m_Config.sIPAddress, m_Config.nPort)
        End Select

    End Sub

    '   Select Case m_CommType
    '    Case eType.eTCP

    '    Case eType.eUDP

    'End Select

    Public Overrides Sub Disconnect()
        Disconnection()
    End Sub

    Public Sub Disconnection()
        Select Case m_CommType
            Case eType.eTCP
                cTCP.Close()
            Case eType.eUDP
                cUDP.Close()
        End Select
    End Sub

    Public Overrides Function SendToString(ByVal sendData As String, ByRef rcvData As String) As eReturnCode
        Select Case m_CommType
            Case eType.eTCP
                If TCPSendAndRecive(sendData, rcvData) = False Then Return eReturnCode.FuncErr
            Case eType.eUDP
                If UDPSendAndRecive(sendData, rcvData) = False Then Return eReturnCode.FuncErr
        End Select
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToString(ByVal sendData As String) As eReturnCode
        Select Case m_CommType
            Case eType.eTCP
                If TCPSendAndRecive(sendData) = False Then Return eReturnCode.FuncErr
            Case eType.eUDP
                If UDPSendAndRecive(sendData) = False Then Return eReturnCode.FuncErr
        End Select
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToBytes(ByVal sendBytes() As Byte, ByRef rcvData() As Byte, ByVal bQuerry As Boolean) As eReturnCode
        Select Case m_CommType
            Case eType.eTCP
                If TCPSendAndRecive(sendBytes, rcvData, bQuerry) = False Then Return eReturnCode.FuncErr
            Case eType.eUDP
                If UDPSendAndRecive(sendBytes, rcvData, bQuerry) = False Then Return eReturnCode.FuncErr
        End Select
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToBytes(ByVal sendBytes() As Byte, ByRef rcvData() As Byte) As eReturnCode
        Select Case m_CommType
            Case eType.eTCP
                If TCPSendAndRecive(sendBytes, rcvData) = False Then Return eReturnCode.FuncErr
            Case eType.eUDP
                If UDPSendAndRecive(sendBytes, rcvData) = False Then Return eReturnCode.FuncErr
        End Select
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToBytes(ByVal Wbyte() As Byte, ByRef outData() As Byte, ByVal RcvDataLen As Integer, ByVal RcvDataLen_Error As Integer) As CComCommonNode.eReturnCode
        Select Case m_CommType
            Case eType.eTCP
                If TCPSendAndRecive(Wbyte, outData, RcvDataLen, RcvDataLen_Error) = False Then Return eReturnCode.FuncErr
            Case eType.eUDP
                Return eReturnCode.NoSupport
        End Select
        Return eReturnCode.OK
    End Function

    Public Overrides Function ReciveToBytes(ByRef outData() As Byte) As CComCommonNode.eReturnCode
        Select Case m_CommType
            Case eCommType.eTCP
                If TCPRecive(outData) = False Then Return eReturnCode.FuncErr
            Case eCommType.eUDP
                Return eReturnCode.NoSupport
            Case Else
                Return eReturnCode.NoSupport
        End Select
        Return eReturnCode.OK
    End Function


    'Public Function SendAndRecive(ByVal sendData As String, ByRef rcvData As String) As Boolean

    '    Select Case m_CommType
    '        Case eType.eTCP
    '            If TCPSendAndRecive(sendData, rcvData) = False Then Return False
    '        Case eType.eUDP
    '            If UDPSendAndRecive(sendData, rcvData) = False Then Return False
    '    End Select
    '    Return True
    'End Function

    'Public Function SendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte, ByVal bQuerry As Boolean) As Boolean
    '    Select Case m_CommType
    '        Case eType.eTCP
    '            If TCPSendAndRecive(sendBytes, rcvData, bQuerry) = False Then Return False
    '        Case eType.eUDP
    '            If UDPSendAndRecive(sendBytes, rcvData, bQuerry) = False Then Return False
    '    End Select
    '    Return True
    'End Function

    'Public Function SendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte) As Boolean
    '    Select Case m_CommType
    '        Case eType.eTCP
    '            If TCPSendAndRecive(sendBytes, rcvData) = False Then Return False
    '        Case eType.eUDP
    '            If UDPSendAndRecive(sendBytes, rcvData) = False Then Return False
    '    End Select
    '    Return True
    'End Function


#Region "TCP Functions"

    Private Function TCPSendAndRecive(ByVal sendData As String) As Boolean
        Try
            Dim stream As NetworkStream = cTCP.GetStream

            ' Sends a message to the host to which you have connected.
            sendData = sendData & m_Config.sSendTerminator
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(sendData)

            stream.Write(sendBytes, 0, sendBytes.Length)
         
            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
     
            ' Read the first batch of the TcpServer response bytes.

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message

            Return False
        End Try

        Return True
    End Function

    Private Function TCPSendAndRecive(ByVal sendData As String, ByRef rcvData As String) As Boolean
        Try
            Dim stream As NetworkStream = cTCP.GetStream

            ' Sends a message to the host to which you have connected.
            sendData = sendData & m_Config.sSendTerminator
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(sendData)

            stream.Write(sendBytes, 0, sendBytes.Length)
            stream.ReadTimeout = m_dTimeOut * 1000 'sec --> msec

            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            Dim Data As [Byte]() = New [Byte](256) {}


            ' String to store the response ASCII representation.
            Dim responseData As [String] = [String].Empty

            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(Data, 0, Data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(Data, 0, bytes)

            responseData = responseData.TrimEnd(m_Config.sRcvTerminator)
            rcvData = responseData
            ' Which one of these two hosts responded?
            Console.WriteLine("This is the message you received " + _
                                          responseData)

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message

            Return False
        End Try

        Return True
    End Function


    Private Function TCPSendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte, ByVal bQuerry As Boolean) As Boolean

        Try
            Dim stream As NetworkStream = cTCP.GetStream

            stream.Write(sendBytes, 0, sendBytes.Length)
            stream.ReadTimeout = m_dTimeOut * 1000 'sec --> msec

            If bQuerry = True Then

                ' Receive the TcpServer.response.
                ' Buffer to store the response bytes.
                Dim Data As [Byte]() = New [Byte](1024) {}

                ' String to store the response ASCII representation.
                Dim responseData As [String] = [String].Empty

                ' Read the first batch of the TcpServer response bytes.
                Dim bytes As Int32 = stream.Read(Data, 0, Data.Length)
                responseData = System.Text.Encoding.ASCII.GetString(Data, 0, bytes)
                rcvData = Data


                ' Which one of these two hosts responded?
                Console.WriteLine("This is the message you received " + _
                                              responseData)
            End If


        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function

    Private Function TCPSendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte) As Boolean
        Try

            Dim byTerminator() As Byte = Nothing
            Dim str As String

            If m_Config.sRcvTerminator Is Nothing = False Then
                If m_Config.sRcvTerminator.Length > 0 Then
                    ReDim byTerminator(m_Config.sRcvTerminator.Length - 1)

                    For i As Integer = 0 To m_Config.sRcvTerminator.Length - 1
                        str = m_Config.sRcvTerminator.Substring(i, 1)
                        byTerminator(i) = Convert.ToByte(Asc(str))
                    Next
                End If
            End If


            Dim stream As NetworkStream = cTCP.GetStream
            stream.ReadTimeout = 1000

            stream.Write(sendBytes, 0, sendBytes.Length)


            Dim bytes As Int32
            ' String to store the response ASCII representation.
            Dim responseData As [String] = [String].Empty
            Dim byDataBuf As Byte()
            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            Do
                Dim Data As [Byte]() = New [Byte](65535) {}
                ' Read the first batch of the TcpServer response bytes.
                Try
                    If stream.CanRead = True Then
                        bytes = stream.Read(Data, 0, Data.Length)
                    Else
                        Exit Do
                    End If
                Catch ex As Exception
                    Exit Do
                End Try

                If bytes <= 0 Then Exit Do

                responseData = System.Text.Encoding.ASCII.GetString(Data, 0, bytes)
                byDataBuf = System.Text.Encoding.ASCII.GetBytes(responseData)

                If rcvData Is Nothing Then
                    ReDim rcvData(byDataBuf.Length - 1)
                Else
                    ReDim Preserve rcvData(byDataBuf.Length + rcvData.Length - 1)
                End If
                Array.Copy(byDataBuf, 0, rcvData, rcvData.Length - byDataBuf.Length, byDataBuf.Length)

                If byTerminator Is Nothing = False Then
                    If rcvData.Length > byTerminator.Length Then
                        For i As Integer = 0 To byTerminator.Length - 1
                            If rcvData(rcvData.Length - byTerminator.Length + i) = byTerminator(i) Then 'Terminator Check True
                                MyBase.DataRecivedToByte(rcvData)
                                Exit Do
                            End If
                        Next
                    End If

                Else
                    MyBase.DataRecivedToByte(rcvData)
                    Exit Do
                End If


            Loop

            ' Which one of these two hosts responded?
            Console.WriteLine("This is the message you received " + _
                                          responseData)

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function


    Private Function TCPSendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte, ByVal DataLen As Integer, ByVal ErrorDataLen As Integer) As Boolean
        Try

            Dim byTerminator(m_Config.sRcvTerminator.Length - 1) As Byte
            Dim str As String
            For i As Integer = 0 To m_Config.sRcvTerminator.Length - 1
                str = m_Config.sRcvTerminator.Substring(i, 1)
                byTerminator(i) = Convert.ToByte(Asc(str))
            Next

            Dim stream As NetworkStream = cTCP.GetStream
            stream.ReadTimeout = 10000

            stream.Write(sendBytes, 0, sendBytes.Length)


            Dim bytes As Int32
            ' String to store the response ASCII representation.
            '  Dim responseData As [String] = [String].Empty
            Dim byDataBuf As Byte()
            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            Do
                Dim Data As [Byte]() = New [Byte](65535) {}
                ' Read the first batch of the TcpServer response bytes.
                Try
                    If stream.CanRead = True Then
                        bytes = stream.Read(Data, 0, Data.Length)
                    Else
                        Exit Do
                    End If
                Catch ex As Exception
                    Return False
                End Try

                If bytes <= 0 Then Exit Do

                ' responseData = System.Text.Encoding.ASCII.GetString(Data, 0, bytes)
                ReDim byDataBuf(bytes - 1)
                Array.Copy(Data, 0, byDataBuf, 0, bytes)
                'byDataBuf = System.Text.Encoding.ASCII.GetBytes(responseData)

                If rcvData Is Nothing Then
                    ReDim rcvData(byDataBuf.Length - 1)
                Else
                    ReDim Preserve rcvData(byDataBuf.Length + rcvData.Length - 1)
                End If
                Array.Copy(byDataBuf, 0, rcvData, rcvData.Length - byDataBuf.Length, byDataBuf.Length)

                If rcvData.Length > byTerminator.Length Then

                    For i As Integer = 0 To byTerminator.Length - 1
                        If rcvData(rcvData.Length - byTerminator.Length + i) = byTerminator(i) Then 'Terminator Check True
                            If rcvData.Length = DataLen Or rcvData.Length = ErrorDataLen Then
                                MyBase.DataRecivedToByte(rcvData)
                                Exit Do
                            End If
                        End If
                    Next

                End If

            Loop

            ' Which one of these two hosts responded?
            'Console.WriteLine("This is the message you received " + _
            '                              responseData)

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function

    Private Function TCPRecive(ByRef rcvData() As Byte) As Boolean
        Try
            Dim stream As NetworkStream = cTCP.GetStream
            stream.ReadTimeout = m_dTimeOut * 1000   'sec --> msec
            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            Dim Data As [Byte]() = New [Byte](256) {}

            ' String to store the response ASCII representation.
            Dim responseData As [String] = [String].Empty

            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(Data, 0, Data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(Data, 0, bytes)
            rcvData = Data

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function
#End Region


#Region "UDP Functions"
    Private Function UDPSendAndRecive(ByVal sendData As String) As Boolean
        Try
            ' Sends a message to the host to which you have connected.
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(sendData)

            cUDP.Send(sendBytes, sendBytes.Length)

            ' Sends message to a different host using optional hostname and port parameters.
            Dim udpClientB As New UdpClient()
            udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000)

            ' IPEndPoint object will allow us to read datagrams sent from any source.
            Dim RemoteIpEndPoint As New IPEndPoint(m_Config.sIPAddress, m_Config.nPort) 'IPAddress.Any, 0)

            ' UdpClient.Receive blocks until a message is received from a remote host.


            'Dim receiveBytes As [Byte]() = cUDP.Receive(RemoteIpEndPoint)
            'Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)

            '' Which one of these two hosts responded?
            'Console.WriteLine(("This is the message you received " + _
            '                              returnData.ToString()))
            'Console.WriteLine(("This message was sent from " + _
            '                             RemoteIpEndPoint.Address.ToString() + _
            '                             " on their port number " + _
            '                             RemoteIpEndPoint.Port.ToString()))
            'cUDP.Close()
            'udpClientB.Close()

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function
    Private Function UDPSendAndRecive(ByVal sendData As String, ByRef rcvData As String) As Boolean
        Try
            ' Sends a message to the host to which you have connected.
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(sendData)

            cUDP.Send(sendBytes, sendBytes.Length)

            ' Sends message to a different host using optional hostname and port parameters.
            Dim udpClientB As New UdpClient()
            udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000)

            ' IPEndPoint object will allow us to read datagrams sent from any source.
            Dim RemoteIpEndPoint As New IPEndPoint(m_Config.sIPAddress, m_Config.nPort) 'IPAddress.Any, 0)

            ' UdpClient.Receive blocks until a message is received from a remote host.
            Dim receiveBytes As [Byte]() = cUDP.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)

            ' Which one of these two hosts responded?
            Console.WriteLine(("This is the message you received " + _
                                          returnData.ToString()))
            Console.WriteLine(("This message was sent from " + _
                                         RemoteIpEndPoint.Address.ToString() + _
                                         " on their port number " + _
                                         RemoteIpEndPoint.Port.ToString()))
            cUDP.Close()
            udpClientB.Close()

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try

        Return True
    End Function

    Private Function UDPSendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte, ByVal bQuerry As Boolean) As Boolean
        Try
            'Dim address As System.Net.IPAddress
            'address.Address = IPAddress.Parse(m_sIPAddress)

            Dim nRet As Integer

            nRet = cUDP.Send(sendBytes, sendBytes.Length)

            ' IPEndPoint object will allow us to read datagrams sent from any source.
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Parse(m_Config.sIPAddress), m_Config.nPort) 'IPAddress.Any, 0) 


            ' UdpClient.Receive blocks until a message is received from a remote host.
            Dim receiveBytes As [Byte]() = cUDP.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)

            'Time out 기능 추가 구문
            'Do

            '    If cWinSoc.Available > 0 Then
            '        'cWinsoc.receive()
            '    End If

            'Loop Until returnData <> ""

            ' Which one of these two hosts responded?
            'Console.WriteLine(("This is the message you received " + _
            '                              returnData.ToString()))
            'Console.WriteLine(("This message was sent from " + _
            '                             RemoteIpEndPoint.Address.ToString() + _
            '                             " on their port number " + _
            '                             RemoteIpEndPoint.Port.ToString()))
            rcvData = receiveBytes

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try



        Return True
    End Function

    Private Function UDPSendAndRecive(ByVal sendBytes() As Byte, ByRef rcvData() As Byte) As Boolean
        Try
            'Dim address As System.Net.IPAddress
            'address.Address = IPAddress.Parse(m_sIPAddress)

            Dim nRet As Integer

            nRet = cUDP.Send(sendBytes, sendBytes.Length)

            ' IPEndPoint object will allow us to read datagrams sent from any source.
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Parse(m_Config.sIPAddress), m_Config.nPort) 'IPAddress.Any, 0) 


            ' UdpClient.Receive blocks until a message is received from a remote host.
            Dim receiveBytes As [Byte]() = cUDP.Receive(RemoteIpEndPoint)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)

            'Time out 기능 추가 구문
            'Do

            '    If cWinSoc.Available > 0 Then
            '        'cWinsoc.receive()
            '    End If

            'Loop Until returnData <> ""

            ' Which one of these two hosts responded?
            Console.WriteLine(("This is the message you received " + _
                                          returnData.ToString()))
            Console.WriteLine(("This message was sent from " + _
                                         RemoteIpEndPoint.Address.ToString() + _
                                         " on their port number " + _
                                         RemoteIpEndPoint.Port.ToString()))
            rcvData = receiveBytes

        Catch e As Exception
            m_sStateMsg = "SendAndRecive" & e.Message
            Return False
        End Try



        Return True
    End Function

#End Region



End Class
