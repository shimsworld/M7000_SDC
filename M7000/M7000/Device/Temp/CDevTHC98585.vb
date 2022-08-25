Imports System.Threading
Imports CCommLib

Public Class CDevTHC98585
    Inherits CDevTCCommonNode

#Region "Defien"

    Public WithEvents communicator As CComAPI

    Dim m_Config As CComSerial.sSerialPortInfo


    Dim m_dTemperature As Double
    Dim m_dHumidity As Double



#End Region

#Region "Property"

    Public ReadOnly Property Temperatuer As Double
        Get
            Return m_dTemperature
        End Get
    End Property

    Public ReadOnly Property Humidity As Double
        Get
            Return m_dHumidity
        End Get
    End Property

#End Region


#Region "Creator and Disposer and initialization"


    Public Sub New()

        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        communicator.Communicator.DataType = CComSerial.eDataType.eByte
        'communicator.Communicator.eCommType = CComCommonNode.eCommType.eSerial

    End Sub

#End Region


    Public Overrides Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean

        m_bIsConnected = False
        m_Config = Config

        If communicator.Communicator.Connect(m_Config) = False Then Return False

        m_bIsConnected = True
        Return True
    End Function

    'Public Function Connection() As Boolean

    '    m_bIsConnected = False

    '    If communicator Is Nothing Then Return False

    '    If communicator.Communicator.Connect(m_Config) = False Then Return False

    '    m_bIsConnected = True
    '    Return True
    'End Function

    Public Overrides Sub Disconnection()
        communicator.Communicator.Disconnect()
        m_bIsConnected = False
    End Sub

    Private Sub communicator_evDataRecivedToByte(ByVal nByte() As Byte) Handles communicator.evDataRecivedToByte
        Dim Temper() As Byte = Nothing
        Dim Humi() As Byte = Nothing
        Dim strTemp As String = ""
        Dim strHumi As String = ""

        '수신된 바이트 값을 Temp 와 Humidity 영역을 구분하여 Ascii 값으로 변경
        Temp(nByte, Temper, Humi)

        If Temper Is Nothing Or Humi Is Nothing Then

            m_dTemperature = 0
            m_dHumidity = 0
        Else
            ASCIItoCHAR(Temper, strTemp)
            ASCIItoCHAR(Humi, strHumi)

            m_dTemperature = CDbl(strTemp) / 10
            m_dHumidity = CDbl(strHumi) / 10
        End If

    End Sub

    Private Sub ASCIItoHEX(ByVal In_ASCII() As Byte, ByRef out_HEX As String)
        Dim i As Integer = 0
        Dim iMax As Integer = 0
        Dim iDec() As Integer = Nothing
        Dim strHex() As String = Nothing
        Dim In_strHexMask As String = "40"
        Try
            iMax = In_ASCII.Length - 1
            If iMax < 0 Then iMax = 0

            ReDim iDec(iMax)
            ReDim strHex(iMax)

            'Mask 제거
            For i = 0 To iMax
                iDec(i) = (In_ASCII(i)) 'Asc(Mid(In_ASCII, i + 1, 1))
                'iDec(i) = iDec(i) - CInt("&h" + In_strHexMask)
                If iDec(i) < 10 Then
                    strHex(i) = "0" + Hex(iDec(i))
                Else
                    strHex(i) = Hex(iDec(i))
                End If

            Next i

            For i = 0 To iMax
                out_HEX = out_HEX + strHex(i)
            Next i
        Catch ex As Exception

        End Try
        Debug.WriteLine("[ASCII to HEX] " & out_HEX)

    End Sub

    Private Sub ASCIItoCHAR(ByVal In_ASCII() As Byte, ByRef out_HEX As String)
        Dim iMax As Integer = 0
        Dim strHex() As String = Nothing
        Try
            iMax = In_ASCII.Length - 1
            If iMax < 0 Then iMax = 0

            ReDim strHex(iMax)

            'Mask 제거
            For i As Integer = 0 To iMax
                strHex(i) = Chr(In_ASCII(i))
            Next i

            For i = 0 To iMax
                out_HEX = out_HEX + strHex(i)
            Next i
        Catch ex As Exception

        End Try
        Debug.WriteLine("[ASCII to CHAR] " & out_HEX)

    End Sub

    Private Sub Temp(ByVal In_ASCII() As Byte, ByRef out_Temp() As Byte, ByRef out_Humidity() As Byte)
        Dim nOut(2) As Integer
        Dim j As Integer = 0
        For i As Integer = 0 To In_ASCII.Length - 1
            If In_ASCII(i) = 32 Then
                nOut(j) = i
                j = j + 1
            ElseIf In_ASCII(i) = 13 Then
                nOut(j) = i
                Exit For
            End If
        Next

        Dim nSize As Integer
        nSize = nOut(1) - (nOut(0) + 1)

        If nSize < 1 Then
            out_Temp = Nothing
            Exit Sub
        End If

        ReDim out_Temp(nSize - 1)  'dsffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff

        For i = 0 To nSize - 1
            out_Temp(i) = In_ASCII(nOut(0) + 1 + i)
        Next

        nSize = nOut(2) - (nOut(1) + 1)

        If nSize < 1 Then
            out_Humidity = Nothing
            Exit Sub
        End If

        ReDim out_Humidity(nSize - 1)

        For i = 0 To nSize - 1
            out_Humidity(i) = In_ASCII(nOut(1) + 1 + i)
        Next
    End Sub


End Class
