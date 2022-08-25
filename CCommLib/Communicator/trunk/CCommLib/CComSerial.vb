option explicit on
Option Strict On

Imports System.IO.Ports
Imports System.Runtime.Remoting.Messaging
Imports System.Threading
Imports System
Imports System.IO
Imports System.Windows.Forms


Public Class CComSerial
    Inherits CComCommonNode

#Region "Defines"

    Friend Shared comPortExists As Boolean

    Private SerialErrorReceivedEventHandler1 As New SerialErrorReceivedEventHandler(AddressOf ErrorReceived)

    Private WithEvents cPort As SerialPort
    Dim m_Config As sSerialPortInfo
    ' Dim m_bPortOpend As Boolean

    Dim m_sVersion As System.Version

    Dim m_sLogPath As String = Application.StartupPath & "\Log"

#Region "Enums & Structures"

    Public Enum eDataType
        eString
        eByte
    End Enum

    Public Structure sSerialPortInfo
        Dim sPortName As String
        Dim nBaudRate As Integer
        Dim nDataBits As Integer
        Dim nParity As System.IO.Ports.Parity
        Dim nStopBits As System.IO.Ports.StopBits
        Dim nHandShake As System.IO.Ports.Handshake
        Dim sRcvTerminator As String
        Dim sSendTerminator As String
        Dim enableTerminator As Boolean
        '  Dim sCommencer As String
    End Structure

#End Region

#End Region

#Region "Propertis"

    Public ReadOnly Property PortOpen() As Boolean
        Get
            Return cPort.IsOpen
        End Get
    End Property

    Public Overrides Property Configure() As sSerialPortInfo
        Get
            Return m_Config
        End Get
        Set(ByVal value As sSerialPortInfo)
            m_Config = value
        End Set
    End Property

    Public ReadOnly Property Version() As String
        Get
            Return m_sVersion.Major & "." & m_sVersion.Minor & "." & m_sVersion.Revision
        End Get
    End Property

#End Region
    '

#Region "Creator"

    Public Sub New()
        MyBase.New()
        m_CommType = eCommType.eSerial
        m_bIsOffline = False
        Dim nMajor As Integer = 1
        Dim nMinor As Integer = 0
        Dim nRevision As Integer = 2
        Dim ports() As String = Nothing

        m_sVersion = New System.Version(nMajor, nMinor, nRevision)
        cPort = New SerialPort()
        ' cPort.RtsEnable = True
        FindComPorts(ports)
        m_dTimeOut = 5
        ' CComSerial.FindComPorts(ports)
    End Sub

#End Region

#Region "Port Open & Close"

    Public Overrides Function Connect(ByVal sInfo As sCommInfo) As eReturnCode

        Dim success As eReturnCode = eReturnCode.FuncErr
        m_Config = sInfo.sSerialInfo

        If m_Config.sPortName = Nothing Or m_Config.sPortName.Length < 4 Then
            Return success
        End If


        Try
            If comPortExists Then

                ' The system has at least one COM port.
                ' If the previously selected port is still open, close it.

                If cPort.IsOpen Then
                    Disconnect()
                End If

                cPort.PortName = m_Config.sPortName
                cPort.BaudRate = m_Config.nBaudRate
                cPort.Parity = m_Config.nParity
                cPort.DataBits = m_Config.nDataBits
                cPort.StopBits = m_Config.nStopBits
                cPort.Handshake = m_Config.nHandShake
                cPort.RtsEnable = True
                If Not (cPort.IsOpen) Then

                    cPort.Open()

                    If cPort.IsOpen Then

                        ' The port is open. Set additional parameters.
                        ' Timeouts are in milliseconds.

                        cPort.ReadTimeout = 1000
                        cPort.WriteTimeout = 1000
                        cPort.DtrEnable = True

                        '   cPort.Handshake = System.IO.Ports.Handshake.RequestToSend

                        ' Specify the routine that runs when a DataReceived event occurs.

                        'AddHandler SelectedPort.DataReceived, SerialDataReceivedEventHandler1
                        AddHandler cPort.ErrorReceived, SerialErrorReceivedEventHandler1

                        ' Send data to other modules.

                        'RaiseEvent UserInterfaceData("DisplayCurrentSettings", "", Color.Black)
                        'RaiseEvent UserInterfaceData("DisplayStatus", "", Color.Black)

                        success = eReturnCode.OK

                        ' m_bPortOpend = True

                    End If
                End If

            End If

        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
            Return success
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
            Return success
        Catch ex As System.IO.IOException
            m_sStateMsg = ex.Message.ToString
            Return success
        End Try

        Return success

    End Function

    Public Overrides Function Connect(ByVal sInfo As sSerialPortInfo) As eReturnCode

        Dim success As eReturnCode = eReturnCode.FuncErr
        m_Config = sInfo

        If cPort.IsOpen Then
            Disconnect()
        End If

        If m_Config.sPortName = Nothing Or m_Config.sPortName.Length < 4 Then
            Return success
        End If
        cPort.PortName = m_Config.sPortName
        cPort.BaudRate = m_Config.nBaudRate
        cPort.Parity = m_Config.nParity
        cPort.DataBits = m_Config.nDataBits
        cPort.StopBits = m_Config.nStopBits
        cPort.Handshake = m_Config.nHandShake
        cPort.RtsEnable = True

        Try
            If comPortExists Then

                ' The system has at least one COM port.
                ' If the previously selected port is still open, close it.

                If cPort.IsOpen Then
                    Disconnect()
                End If

                If Not (cPort.IsOpen) Then

                    cPort.Open()

                    If cPort.IsOpen Then

                        ' The port is open. Set additional parameters.
                        ' Timeouts are in milliseconds.

                        cPort.ReadTimeout = 5000
                        cPort.WriteTimeout = 5000
                        cPort.DtrEnable = True

                        '   cPort.Handshake = System.IO.Ports.Handshake.RequestToSend

                        ' Specify the routine that runs when a DataReceived event occurs.

                        'AddHandler SelectedPort.DataReceived, SerialDataReceivedEventHandler1
                        AddHandler cPort.ErrorReceived, SerialErrorReceivedEventHandler1

                        ' Send data to other modules.

                        'RaiseEvent UserInterfaceData("DisplayCurrentSettings", "", Color.Black)
                        'RaiseEvent UserInterfaceData("DisplayStatus", "", Color.Black)

                        success = eReturnCode.OK

                        ' m_bPortOpend = True

                    End If
                End If

            End If

        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
            Return success
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
            Return success
        Catch ex As System.IO.IOException
            m_sStateMsg = ex.Message.ToString
            Return success
        End Try

        Return success

    End Function

    Public Overrides Sub Disconnect()
        Try
            'RaiseEvent UserInterfaceData("DisplayStatus", "", Color.Black)

            If (Not IsNothing(cPort)) Then

                If cPort.IsOpen Then

                    cPort.Close()

                    ' m_bPortOpend = False

                End If
            End If

        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
        Catch ex As System.IO.IOException
            m_sStateMsg = ex.Message.ToString
        End Try
    End Sub

#End Region

#Region "Send/Recive Function"


    Public Overrides Function SendToBytes(ByVal Wbyte() As Byte) As eReturnCode

        Dim success As Boolean
        m_DataType = eDataType.eByte
        Try
            ' Open the COM port if necessary.

            If (Not (cPort Is Nothing)) Then
                If (Not cPort.IsOpen) Then

                    ' Close the port if needed and open the selected port.

                    'PortOpen = 
                    Connect(m_Config)
                End If
            End If

            If cPort.IsOpen Then
                cPort.Write(Wbyte, 0, Wbyte.Length)
                success = True
            End If

        Catch ex As TimeoutException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
            ' This exception can occur if the port was removed. 
            ' If the port was open, close it.

            Disconnect()
            Return eReturnCode.FuncErr

        End Try

        Return eReturnCode.OK

    End Function

    Public Overrides Function SendToBytes(ByVal Wbyte() As Byte, ByRef outData() As Byte) As eReturnCode
        Dim sStartTime As Single
        Dim sDeltaTime As Single

        If m_bIsOffline = True Then
            outData = Nothing
            Return eReturnCode.OK
        End If

        If cPort.IsOpen = False Then Return eReturnCode.FuncErr
        m_DataType = eDataType.eByte
        g_sRcvData = ""
        g_byRcvData = Nothing
        m_CommStatus.serialStatus = eTransferState.eTransferingData

        'inComm = inComm & m_Config.sTerminator
        Try
            cPort.Write(Wbyte, 0, Wbyte.Length)
            If m_Config.enableTerminator = True Then
                Dim byteTerminator(m_Config.sSendTerminator.Length - 1) As Byte
                For i As Integer = 0 To m_Config.sSendTerminator.Length - 1
                    byteTerminator(i) = Convert.ToByte(Asc(m_Config.sSendTerminator.Substring(i, 1)))
                Next
                cPort.Write(byteTerminator, 0, byteTerminator.Length)
            End If
        Catch ex As TimeoutException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As Exception
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        End Try


        Application.DoEvents()
        Thread.Sleep(1)

        sStartTime = timer_Sec()

        Do

            Application.DoEvents()
            Thread.Sleep(1)

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > m_dTimeOut Then
                m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut
            End If

        Loop Until m_CommStatus.serialStatus = eTransferState.eReciveComplete Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut_Counter
        outData = g_byRcvData

        ' RaiseEvent evDataTransfered(g_sRcvData, g_eRS232Status)
        If m_CommStatus.serialStatus <> eTransferState.eReciveComplete Then Return eReturnCode.FuncErr
        ' g_eRS232Status = eTransferState.eReady
        Return eReturnCode.OK
    End Function

    Public Overrides Function ReciveToBytes(ByRef outData() As Byte) As CComCommonNode.eReturnCode
        Dim sStartTime As Single
        Dim sDeltaTime As Single

        If m_bIsOffline = True Then
            outData = Nothing
            Return eReturnCode.OK
        End If

        If cPort.IsOpen = False Then Return eReturnCode.FuncErr
        m_DataType = eDataType.eByte
        g_sRcvData = ""
        g_byRcvData = Nothing
        m_CommStatus.serialStatus = eTransferState.eTransferingData

        'inComm = inComm & m_Config.sTerminator
        Application.DoEvents()
        Thread.Sleep(1)

        sStartTime = timer_Sec()

        Do

            Application.DoEvents()
            Thread.Sleep(1)

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > m_dTimeOut Then
                m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut
            End If

        Loop Until m_CommStatus.serialStatus = eTransferState.eReciveComplete Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut_Counter
        outData = g_byRcvData

        ' RaiseEvent evDataTransfered(g_sRcvData, g_eRS232Status)
        If m_CommStatus.serialStatus <> eTransferState.eReciveComplete Then Return eReturnCode.FuncErr
        ' g_eRS232Status = eTransferState.eReady
        Return eReturnCode.OK

    End Function

    Private g_sRcvData As String
    Private g_byRcvData() As Byte

    Public Overrides Function SendToString(ByVal textToSend As String, ByRef outData As String) As eReturnCode

        Dim sStartTime As Single
        Dim sDeltaTime As Single

        If m_bIsOffline = True Then
            outData = ""
            Return eReturnCode.OK
        End If

        If cPort.IsOpen = False Then Return eReturnCode.FuncErr
        m_DataType = eDataType.eString
        g_sRcvData = ""
        m_CommStatus.serialStatus = eTransferState.eTransferingData

        textToSend = textToSend & m_Config.sSendTerminator
        For i As Integer = 0 To textToSend.Length - 1
            Try
                cPort.Write(textToSend.Substring(i, 1))
            Catch ex As TimeoutException
                m_sStateMsg = ex.Message.ToString
                Return eReturnCode.FuncErr
            Catch ex As InvalidOperationException
                m_sStateMsg = ex.Message.ToString
                Return eReturnCode.FuncErr
            Catch ex As UnauthorizedAccessException
                m_sStateMsg = ex.Message.ToString
                Return eReturnCode.FuncErr
            Catch ex As Exception
                m_sStateMsg = ex.Message.ToString
                Return eReturnCode.FuncErr
            End Try

        Next

        logOutput("Send >> " & textToSend)


        Application.DoEvents()
        Thread.Sleep(1)

        sStartTime = timer_Sec()

        Do

            Application.DoEvents()
            Thread.Sleep(1)

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > m_dTimeOut Then 'm_dTimeOut
                m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut
            End If

        Loop Until m_CommStatus.serialStatus = eTransferState.eReciveComplete Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut_Counter

        outData = g_sRcvData

        logOutput("Recive << " & g_sRcvData)

        ' RaiseEvent evDataTransfered(g_sRcvData, g_eRS232Status)
        If m_CommStatus.serialStatus <> eTransferState.eReciveComplete Then Return eReturnCode.FuncErr
        ' g_eRS232Status = eTransferState.eReady
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToString(ByVal textToSend As String) As eReturnCode

        Try
            ' Open the COM port if necessary.\

            If m_bIsOffline = True Then
                Return eReturnCode.OK
            End If

            If cPort.IsOpen = False Then Return eReturnCode.FuncErr
            m_DataType = eDataType.eString
            g_sRcvData = ""
            m_CommStatus.serialStatus = eTransferState.eTransferingData

            textToSend = textToSend & m_Config.sSendTerminator
            For i As Integer = 0 To textToSend.Length - 1
                cPort.Write(textToSend.Substring(i, 1))
            Next

        Catch ex As TimeoutException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As InvalidOperationException
            m_sStateMsg = ex.Message.ToString
            Return eReturnCode.FuncErr
        Catch ex As UnauthorizedAccessException
            m_sStateMsg = ex.Message.ToString
            Disconnect()
            Return eReturnCode.FuncErr
        End Try

        m_CommStatus.serialStatus = eTransferState.eSendComplete
        Return eReturnCode.OK
    End Function


    Public Overrides Function ReciveToString(ByRef outData As String) As CComCommonNode.eReturnCode

        Dim sStartTime As Single
        Dim sDeltaTime As Single

        If m_bIsOffline = True Then
            outData = ""
            Return eReturnCode.OK
        End If

        If cPort.IsOpen = False Then Return eReturnCode.FuncErr
        m_DataType = eDataType.eString
        g_sRcvData = ""
        m_CommStatus.serialStatus = eTransferState.eTransferingData

        Application.DoEvents()
        Thread.Sleep(1)
        sStartTime = timer_Sec()
        Do

            Application.DoEvents()
            Thread.Sleep(1)

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > m_dTimeOut Then 'm_dTimeOut
                m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut
            End If

        Loop Until m_CommStatus.serialStatus = eTransferState.eReciveComplete Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut Or _
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut_Counter

        outData = g_sRcvData

        logOutput("Recive << " & g_sRcvData)

        ' RaiseEvent evDataTransfered(g_sRcvData, g_eRS232Status)
        If m_CommStatus.serialStatus <> eTransferState.eReciveComplete Then Return eReturnCode.FuncErr
        ' g_eRS232Status = eTransferState.eReady
        Return eReturnCode.OK
    End Function
    Private Sub m_SelectedPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles cPort.DataReceived
        Dim rcvData As String = ""
        Dim sDataBuf As String = ""
        Dim nCnt As Integer = 0
        Dim bRcvData() As Byte = Nothing
        Dim bDataBuf() As Byte = Nothing
        Dim nBytesToRead As Integer = 0

        Dim byTerminator(m_Config.sRcvTerminator.Length - 1) As Byte
        Dim str As String

        For i As Integer = 0 To m_Config.sRcvTerminator.Length - 1
            str = m_Config.sRcvTerminator.Substring(i, 1)
            byTerminator(i) = Convert.ToByte(Asc(str))
        Next

        Do
            If m_DataType = eDataType.eString Then

                Do
                    Application.DoEvents()
                    Thread.Sleep(5)

                    Try
                        rcvData = cPort.ReadExisting
                    Catch ex As Exception
                        Exit Sub
                    End Try


                    If rcvData = "" Then
                        Exit Do
                    End If
                    sDataBuf = sDataBuf & rcvData
                Loop


            ElseIf m_DataType = eDataType.eByte Then

                Do
                    Application.DoEvents()
                    Thread.Sleep(10)
                    'If m_Config.enableTerminator = False Then
                    '    Application.DoEvents()
                    '    Thread.Sleep(1000)
                    'End If

                    If cPort.BytesToRead <= 0 Then
                        nBytesToRead = 0
                        Exit Do
                    Else
                        nBytesToRead = cPort.BytesToRead
                    End If

                    ReDim bRcvData(nBytesToRead - 1)

                    cPort.Read(bRcvData, 0, nBytesToRead)

                    If bDataBuf Is Nothing Then
                        ReDim bDataBuf(bRcvData.Length - 1)
                    Else
                        ReDim Preserve bDataBuf(bDataBuf.Length + bRcvData.Length - 1)
                    End If
                    Array.Copy(bRcvData, 0, bDataBuf, bDataBuf.Length - bRcvData.Length, bRcvData.Length)

                    'If m_Config.enableTerminator = False Then
                    '    If nBytesToRead > 5 Then
                    '        Exit Do
                    '    End If
                    'End If

                Loop
            End If


            If m_DataType = eDataType.eString Then

                If sDataBuf <> "" Then
                    If m_Config.sRcvTerminator <> "" Then

                        If sDataBuf.Length > m_Config.sRcvTerminator.Length Then

                            If sDataBuf.Substring(sDataBuf.Length - m_Config.sRcvTerminator.Length, m_Config.sRcvTerminator.Length) = m_Config.sRcvTerminator Then

                                Application.DoEvents()
                                Thread.Sleep(10)

                                If cPort.BytesToRead <= 0 Then
                                    g_sRcvData = sDataBuf
                                    MyBase.DataRecivedToString(g_sRcvData)
                                    m_CommStatus.serialStatus = eTransferState.eReciveComplete
                                    Exit Do
                                End If

                            ElseIf sDataBuf = "[151]" Then   'M6000 특수 케이스
                                g_sRcvData = sDataBuf
                                MyBase.DataRecivedToString(g_sRcvData)
                                m_CommStatus.serialStatus = eTransferState.eReciveComplete
                                Exit Do
                            End If

                        End If

                    Else
                        g_sRcvData = sDataBuf
                        MyBase.DataRecivedToString(g_sRcvData)
                        m_CommStatus.serialStatus = eTransferState.eReciveComplete
                        Exit Do
                    End If

                Else
                    g_sRcvData = sDataBuf
                    m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData
                End If

            ElseIf m_DataType = eDataType.eByte Then



                If bDataBuf Is Nothing = False Then

                    If byTerminator.Length = 0 Then
                        g_byRcvData = bDataBuf
                        MyBase.DataRecivedToByte(g_byRcvData)
                        m_CommStatus.serialStatus = eTransferState.eReciveComplete
                        Exit Do
                    End If

                    If bDataBuf.Length > byTerminator.Length Then

                        For i As Integer = 0 To byTerminator.Length - 1

                            If bDataBuf(bDataBuf.Length - byTerminator.Length + i) = byTerminator(i) Then 'Terminator Check True

                                Application.DoEvents()
                                Thread.Sleep(10)

                                If cPort.BytesToRead <= 0 Then

                                    g_byRcvData = bDataBuf
                                    MyBase.DataRecivedToByte(g_byRcvData)
                                    m_CommStatus.serialStatus = eTransferState.eReciveComplete

                                    Exit Do

                                End If

                            End If

                        Next

                    End If

                Else

                    If nCnt > 20 Then
                        g_byRcvData = bDataBuf
                        m_CommStatus.serialStatus = eTransferState.eReciveFail_NoData
                    End If

                End If

            End If

            nCnt += 1
            If nCnt > 100 Then
                m_CommStatus.serialStatus = eTransferState.eReciveFail_TimeOut_Counter
                Exit Do
            End If

        Loop

    End Sub

    Dim BuffIndx As sTermi
    Public Structure sTermi
        Dim STXIndex() As Integer
        Dim ETXIndex() As Integer
    End Structure

    Private Function CheckedTerminatorIndex(ByVal byRcvData() As Byte) As Boolean
        Dim str As String

        Dim byTerminator(m_Config.sRcvTerminator.Length - 1) As Byte
        str = ""
        For i As Integer = 0 To m_Config.sRcvTerminator.Length - 1
            str = m_Config.sRcvTerminator.Substring(i, 1)
            byTerminator(i) = Convert.ToByte(Asc(str))
        Next

        ReDim BuffIndx.ETXIndex(byTerminator.Length - 1)

        For idx As Integer = byTerminator.Length - 1 To 0 Step -1
            For jdx As Integer = byRcvData.Length - 1 To 0 Step -1
                If byRcvData(byRcvData.Length + jdx - byRcvData.Length) = byTerminator(idx) Then
                    BuffIndx.ETXIndex(idx) = jdx

                    Exit For
                End If
            Next
        Next

        Dim cnt As Integer = 0

        For SumCnt As Integer = 0 To BuffIndx.ETXIndex.Length - 1
            cnt = cnt + BuffIndx.ETXIndex(SumCnt)
        Next

        If cnt = 0 Then
            Return False
        End If
        'ReDim byRetRcvData(BuffIndx.ETXIndex(BuffIndx.ETXIndex.Length - 1) - BuffIndx.STXIndex(BuffIndx.STXIndex.Length - 1))

        'If byRetRcvData.Length = 0 Then
        '    Return False
        'End If

        'Dim cnt As Integer = 0

        'For idx As Integer = BuffIndx.STXIndex(0) To BuffIndx.ETXIndex(BuffIndx.ETXIndex.Length - 1)
        '    byRetRcvData(cnt) = byRcvData(idx)
        '    cnt += 1
        'Next


        'For cnt As Integer = 0 To bySTX.Length - 1
        '    If byRcvData(byRcvData.Length + cnt - byRcvData.Length) = bySTX(cnt) Then

        '        For i As Integer = 0 To byTerminator.Length - 1


        '            If byRcvData(byRcvData.Length - byTerminator.Length + i) = byTerminator(i) Then 'Terminator Check True

        '                Return True
        '                'MyBase.DataRecivedToByte(g_byRcvData)
        '                'm_CommStatus.serialStatus = eTransferState.eReciveComplete
        '            Else
        '                Return False
        '            End If

        '        Next
        '    Else
        '        Return False
        '    End If

        'Next



        '    End If
        'End If



        'Dim index As Integer = Array.FindIndex(byRcvData, 0, 3, AddressOf aaa)


        ' Array.FindIndex(byRcvData, &H2)
        Return True
    End Function

    Private Function DataFrameDevide(ByVal byRcvData() As Byte, ByRef byRetRcvData() As Byte) As Boolean
        'Dim byRetRcvData() As Byte = Nothing

        ReDim byRetRcvData(BuffIndx.ETXIndex(BuffIndx.ETXIndex.Length - 1) - BuffIndx.STXIndex(BuffIndx.STXIndex.Length - 1))

        If byRetRcvData.Length = 0 Then
            Return False
        End If

        Dim cnt As Integer = 0

        For idx As Integer = BuffIndx.STXIndex(0) To BuffIndx.ETXIndex(BuffIndx.ETXIndex.Length - 1)
            byRetRcvData(cnt) = byRcvData(idx)
            cnt += 1
        Next


        If byRetRcvData Is Nothing Then
            Return False
        End If
        'For cnt As Integer = 0 To bySTX.Length - 1
        '    If byRcvData(byRcvData.Length + cnt - byRcvData.Length) = bySTX(cnt) Then

        '        For i As Integer = 0 To byTerminator.Length - 1


        '            If byRcvData(byRcvData.Length - byTerminator.Length + i) = byTerminator(i) Then 'Terminator Check True


        '                Return True
        '                'MyBase.DataRecivedToByte(g_byRcvData)
        '                'm_CommStatus.serialStatus = eTransferState.eReciveComplete
        '            Else
        '                Return False
        '            End If

        '        Next
        '    Else
        '        Return False
        '    End If

        'Next



        'Dim index As Integer = Array.FindIndex(byRcvData, 0, 3, AddressOf aaa)


        ' Array.FindIndex(byRcvData, &H2)

        Return True
    End Function
#End Region

#Region "Functions"

    Private Sub DisplayException(ByVal moduleName As String, ByVal ex As Exception)

        Dim errorMessage As String

        errorMessage = "Exception: " & ex.Message & _
        " Module: " & moduleName & _
        ". Method: " & ex.TargetSite.Name

        'RaiseEvent UserInterfaceData("DisplayStatus", errorMessage, Color.Red)

        ' To display errors in a message box, uncomment this line:
        ' MessageBox.Show(errorMessage)
    End Sub

    ''' <summary>
    ''' Respond to error events.
    ''' </summary>

    Private Sub ErrorReceived(ByVal sender As Object, ByVal e As SerialErrorReceivedEventArgs)

        Dim SerialErrorReceived1 As SerialError

        SerialErrorReceived1 = e.EventType

        Select Case SerialErrorReceived1

            Case SerialError.Frame
                Console.WriteLine("Framing error.")

            Case SerialError.Overrun
                Console.WriteLine("Character buffer overrun.")

            Case SerialError.RXOver
                Console.WriteLine("Input buffer overflow.")

            Case SerialError.RXParity
                Console.WriteLine("Parity error.")

            Case SerialError.TXFull
                Console.WriteLine("Output buffer full.")
        End Select
    End Sub

    Public Shared Sub FindComPorts(ByRef sPortNames() As String)
        ' Place the names of all COM ports in an array and sort.
        sPortNames = SerialPort.GetPortNames

        ' Is there at least one COM port?

        If sPortNames.Length > 0 Then
            comPortExists = True
            Array.Sort(sPortNames)

        Else
            ' No COM ports found.
            comPortExists = False
        End If

    End Sub


    ''' <summary>
    ''' refInfo의 정보와 newInfo의 정보를 비교하여 같은 값이면 True 를, 다른 값이면 False 를 리턴한다.
    ''' </summary>
    ''' <param name="refInfo"></param>
    ''' <param name="newInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsSameSerialInfos(ByVal refInfo As sSerialPortInfo, ByVal newInfo As sSerialPortInfo) As Boolean
        If refInfo.sPortName <> newInfo.sPortName Or
                refInfo.nBaudRate <> newInfo.nBaudRate Or
                refInfo.nDataBits <> newInfo.nDataBits Or
                refInfo.nHandShake <> newInfo.nHandShake Or
                refInfo.nParity <> newInfo.nParity Or
                refInfo.nStopBits <> newInfo.nStopBits Or
                refInfo.sRcvTerminator <> newInfo.sRcvTerminator Or
                refInfo.sSendTerminator <> newInfo.sSendTerminator Or
                refInfo.enableTerminator <> newInfo.enableTerminator Then
            Return False
        End If
        Return True
    End Function




    Private Function timer_Sec() As Single
        Return CSng((Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000))
    End Function


    Private Sub logOutput(ByVal msg As String)
        'Dim sPath As String = m_sLogPath & "\" & CStr(Now.Year) & CStr(Now.Month) & CStr(Now.Day) & ".txt"

        'If Directory.Exists(m_sLogPath) = False Then
        '    Directory.CreateDirectory(m_sLogPath)
        'End If
        'FileOpen(1, sPath, OpenMode.Append, OpenAccess.Write, OpenShare.Default)
        'WriteLine(1, msg)
        'FileClose(1)
    End Sub


#End Region




    Private Sub CComSerial_evDataRecivedToString(str As String) Handles Me.evDataRecivedToString

    End Sub
End Class