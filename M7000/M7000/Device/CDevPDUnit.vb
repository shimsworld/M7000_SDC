Imports System.Threading
Imports CCommLib

Public Class CDevPDUnit

#Region "Define"

#Region "Const"

    Public m_ChNum() As Byte = New Byte() {&HE0, &HE1, &HE2, &HE3, &HE4, &HE5, &HE6, &HE7, &HE8, &HE9, &HEA, &HEB, &HEC, &HED, &HEE, &HEF, _
                                             &HF0, &HF1, &HF2, &HF3, &HF4, &HF5, &HF6, &HF7, &HF8, &HF9, &HFA, &HFB, &HFC, &HFD, &HFE, &HFF}

    Public Const System_Ch As Integer = 32

    Public Const MaxValue As Integer = 100
    Public Const ResolutionBit As Integer = 16

#Region "Communication_Serial"
    Public Const SERIAL_BAUDRATE As Integer = 38400
    Public Const SERIAL_DataBits As Integer = 8
    Public Const SERIAL_Terminator As String = "" 'vbCrLf
    Public Const SERIAL_CMDTerminator As String = ")" 'vbCrLf
    Public Const SERIAL_StopBit As System.IO.Ports.StopBits = IO.Ports.StopBits.One
    Public Const SERIAL_Parity As System.IO.Ports.Parity = IO.Ports.Parity.None
#End Region

#End Region

    Dim communicator As CComAPI


    Dim m_Config As CComSerial.sSerialPortInfo
    Dim bIsConnected As Boolean = False
    Dim CalParam As sCalParam

    'Dim cSocketInfo() As CWinSock.sStateWinSock
    'Dim cComSerialInfo() As CComSerial.sSerialPortInfo

#Region "M6000 Command Set"


    Private Const MSG_TEST_GET_INFO = &H40
    Private Const MSG_TEST_GET_PD_CURRENT = &H41
    Private Const MSG_TEST_GET_CAL_DATA = &H42
    Private Const MSG_TEST_SET_CAL_DATA = &H43
    Private Const MSG_TEST_ERROR_CODE = &H44

    Private Const MSG_BRACKET_OPEN = &H28 '"("
    Private Const MSG_BRACKET_CLOSE = &H29 ' ")"
    Private Const MSG_COMMA = &H2C '","
  
#End Region

#Region "Structure"

    Public sCalData() As sCalParam

    Public Structure sCalParam
        Dim Ratio As String
        Dim Offset As String
    End Structure


#Region "Enum"

#End Region

#End Region

#Region "Property"

   
    Public ReadOnly Property IsConnected As Boolean
        Get
            Return bIsConnected
        End Get
    End Property

    Public ReadOnly Property CalDatas As sCalParam()
        Get
            Return sCalData.Clone
        End Get
    End Property

#End Region

#Region "Create, Dispose and init"

    Public Sub New()
        ReDim sCalData(System_Ch - 1)
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
    End Sub
#End Region

#Region "Communication"
    Public Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean

        bIsConnected = False
        m_Config = Config
        m_Config.enableTerminator = False

        'm_Config.commType
        If communicator.Communicator.Connect(m_Config) = False Then Return False

        If ReadAllCalData() = False Then
            Return False
        End If

        bIsConnected = True
        Return True
    End Function

    Public Sub Disconnection()
        communicator.Communicator.Disconnect()
        bIsConnected = False
    End Sub

#End Region

#End Region


#Region "Calibration"

    Public Function ReadCalibrationData() As Boolean
        Dim sCalBUff As sCalParam = Nothing

        For idx As Integer = 0 To System_Ch - 1

            If ReadCalData(idx, sCalBUff) = True Then
                sCalData(idx) = sCalBUff
            End If
        Next

        Return True
    End Function

#End Region


#Region "Read / Write"

    Public Function ReadDevInfo(ByRef sRcvData As String) As Boolean
        Dim sSendCommand(4) As Byte
        Dim sRcvBuff() As Byte = Nothing
        '28E02C4029

        sSendCommand(0) = MSG_BRACKET_OPEN ' &H28     sSendCommand.Length - 5
        sSendCommand(1) = m_ChNum(0) '&HE0 sSendCommand.Length - 4
        sSendCommand(2) = MSG_COMMA '&H2C     sSendCommand.Length - 3
        sSendCommand(3) = MSG_TEST_GET_INFO '&H40    'sSendCommand.Length - 2
        sSendCommand(4) = MSG_BRACKET_CLOSE '&H29   'sSendCommand.Length - 1

        If communicator.Communicator.SendToBytes(sSendCommand, sRcvBuff) = CComCommonNode.eReturnCode.OK Then
            ConvertToAsc(sRcvBuff, sRcvData)
        Else
            Return False
        End If

        Return True
    End Function


    Public Function ReadCalData(ByVal nChCnt As Integer, ByRef sRcvData As sCalParam) As Boolean
        Dim sSendCommand(4) As Byte
        Dim sRcvBuff() As Byte = Nothing
        Dim strRcvData As String = Nothing

        '28E02C4029

        sSendCommand(0) = MSG_BRACKET_OPEN ' &H28     sSendCommand.Length - 4
        sSendCommand(1) = m_ChNum(nChCnt) '&HE0    sSendCommand.Length - 3
        sSendCommand(2) = MSG_COMMA '&H2C    sSendCommand.Length - 2
        sSendCommand(3) = MSG_TEST_GET_CAL_DATA '&H42    sSendCommand.Length - 1
        sSendCommand(4) = MSG_BRACKET_CLOSE '&H29    sSendCommand.Length

        If communicator.Communicator.SendToBytes(sSendCommand, sRcvBuff) = CComCommonNode.eReturnCode.OK Then
            ConvertToAsc(sRcvBuff, strRcvData)
            If Parse_data(strRcvData, sRcvData) = False Then Return False
        Else
            Return False
        End If

        Return True
    End Function


    Public Function ReadAllCalData() As Boolean

        For idx As Integer = 0 To CDevPDUnit.System_Ch - 1
            If ReadCalData(idx, sCalData(idx)) = False Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function ReadAllCalData(ByRef calDatas() As sCalParam) As Boolean

        If bIsConnected = False Then Return False

        For idx As Integer = 0 To CDevPDUnit.System_Ch - 1
            If ReadCalData(idx, sCalData(idx)) = False Then
                Return False
            End If
        Next

        calDatas = sCalData.Clone

        Return True
    End Function

    Public Function WriteCalData(ByVal nChCnt As Integer, ByVal sSetData As sCalParam) As Boolean
        Dim sSendCommand(4) As Byte
        Dim sRcvBuff() As Byte = Nothing
        Dim sRcvData As String = Nothing


        Dim sRetRatioBuff As Array = Nothing
        Dim sRetOffsetBuff As Array = Nothing

        ConvertToHex(sSetData, sRetRatioBuff, sRetOffsetBuff)

        ReDim sSendCommand(4 + sRetOffsetBuff.Length + sRetRatioBuff.Length)

        '28E02C4029
        sSendCommand(0) = MSG_BRACKET_OPEN ' &H28
        sSendCommand(1) = m_ChNum(nChCnt) '&HE0
        sSendCommand(2) = MSG_COMMA '&H2C
        sSendCommand(3) = MSG_TEST_SET_CAL_DATA  '&H43

        sSendCommand(4) = sRetRatioBuff(0)
        sSendCommand(5) = sRetRatioBuff(1)
        sSendCommand(6) = sRetRatioBuff(2)
        sSendCommand(7) = sRetRatioBuff(3)
        sSendCommand(8) = sRetRatioBuff(4)
        sSendCommand(9) = sRetRatioBuff(5)
        sSendCommand(10) = sRetRatioBuff(6)
        sSendCommand(11) = sRetRatioBuff(7)

        sSendCommand(12) = sRetOffsetBuff(0)
        sSendCommand(13) = sRetOffsetBuff(1)
        sSendCommand(14) = sRetOffsetBuff(2)
        sSendCommand(15) = sRetOffsetBuff(3)
        sSendCommand(16) = sRetOffsetBuff(4)
        sSendCommand(17) = sRetOffsetBuff(5)
        sSendCommand(18) = sRetOffsetBuff(6)
        sSendCommand(19) = sRetOffsetBuff(7)

        sSendCommand(20) = MSG_BRACKET_CLOSE '&H29

        Dim test As String = Nothing

        For i As Integer = 0 To sSendCommand.Length - 1
            test = test & Hex(sSendCommand(i))
        Next
        If communicator.Communicator.SendToBytes(sSendCommand) = CComCommonNode.eReturnCode.OK Then
            'ConvertToAsc(sRcvBuff, sRcvData)
        Else
            Return False
        End If

        Return True
    End Function


#End Region

#Region "Measurement"

    Public Function MeasurementPDCurrent(ByVal nChCnt As Integer, ByRef RetPDCurrent As Double) As Boolean
        Dim sSendCommand(4) As Byte
        Dim sRcvBuff() As Byte = Nothing
        Dim sRcvASCData As String = Nothing

        '28E02C4029
        sSendCommand(0) = MSG_BRACKET_OPEN ' &H28
        sSendCommand(1) = m_ChNum(nChCnt) '&HE0
        sSendCommand(2) = MSG_COMMA '&H2C
        sSendCommand(3) = MSG_TEST_GET_PD_CURRENT  '&H41
        sSendCommand(4) = MSG_BRACKET_CLOSE '&H29

        Dim sHexData() As String = Nothing
        Dim ChData(5) As String
        Dim Test As String = ""

        If communicator.Communicator.SendToBytes(sSendCommand, sRcvBuff) = CComCommonNode.eReturnCode.OK Then
            ConvertToAsc(sRcvBuff, sRcvASCData)

            ConvertToHex(sRcvASCData, sHexData)

            For i As Integer = 0 To ChData.Length - 1
                ChData(i) = sHexData(i + 1).Substring(1, 1)


                Test = Test & ChData(i)

            Next
            'ASCIItoHEX(Test, Test)

            'Test = "007FFF"
            HEXtoDEC(Test, MaxValue, ResolutionBit, sRcvASCData)

            RetPDCurrent = CDbl(sRcvASCData * sCalData(nChCnt).Ratio + sCalData(nChCnt).Offset)

        Else
            Return False
        End If

        Return True
    End Function



    Public Function HEXtoDEC(ByVal In_HEX As String, ByVal in_MaxValue As Double, ByVal in_ResolutionBit As Integer, ByRef out_DEC As String) As Boolean

        Dim nByte As Integer            'number of byte(input data)
        Dim ConvDEC As Long             'Conversion Value (Hex to Dec)

        nByte = in_ResolutionBit        'Len(In_HEX)             '입력값의 Byte(Resolution) : 2^nByte-1 으로 사용됨
        ConvDEC = CLng("&H" + In_HEX)   '10진수로 변환된 값

        'DMX Power Board
        out_DEC = ((ConvDEC / (2 ^ nByte - 1)) * in_MaxValue * 2 - in_MaxValue) '((HexToDec_Value / (2 ^ 15)) * 2.048)           'HexToDec_Value * 0.001 '

        '자리수를 소수점 3자리로 설정할 경우 주석을 풀어준다.
        'out_DEC = Format(CDbl(out_DEC), "0.000")

        Debug.WriteLine("[HEX to DEC] " & out_DEC)

        out_DEC = (out_DEC - 25500) / 256


        Return True
    End Function


#End Region

#Region "Data Convert"

    Public Function ConvertToAsc(ByVal sRcv() As Byte, ByRef RetData As String) As Boolean

        Dim RcvBuff() As String = Nothing

        ReDim RcvBuff(sRcv.Length - 1)

        For idx As Integer = 0 To sRcv.Length - 1
            RcvBuff(idx) = Chr("&H" & Hex(sRcv(idx)))
        Next

        For i As Integer = 0 To RcvBuff.Length - 1
            RetData = RetData & RcvBuff(i)
        Next

        Return True
    End Function


    Public Function ConvertToHex(ByVal sCal As sCalParam, ByRef imsi_Ratio() As Byte, ByRef imsi_Offset() As Byte) As Boolean

        Dim imsi_Str As String

        ReDim imsi_Ratio(sCal.Ratio.ToString.Length - 1)
        ReDim imsi_Offset(sCal.Offset.ToString.Length - 1)

        For idx As Integer = 0 To sCal.Offset.ToString.Length - 1
            imsi_Str = sCal.Offset.ToString.Substring(idx, 1)
            imsi_Str = Hex(Asc(imsi_Str))

            imsi_Offset(idx) = "&H" & imsi_Str

            imsi_Str = sCal.Ratio.ToString.Substring(idx, 1)
            imsi_Str = Hex(Asc(imsi_Str))

            imsi_Ratio(idx) = "&H" & imsi_Str
        Next

        Return True
    End Function

    Public Function ConvertToHex(ByVal sCal As String, ByRef imsi_Offset() As String) As Boolean

        Dim imsi_Str As String

        ReDim imsi_Offset(sCal.ToString.Length - 1)


        For idx As Integer = 0 To sCal.ToString.Length - 1
            imsi_Str = sCal.ToString.Substring(idx, 1)
            imsi_Str = Hex(Asc(imsi_Str))

            imsi_Offset(idx) = imsi_Str
        Next

        Return True
    End Function

    Public Function Parse_data(ByVal sRcvData As String, ByRef sCal As sCalParam)
        Dim arrBuf As Array = Nothing

        sRcvData = sRcvData.TrimStart("(")

        sRcvData = sRcvData.TrimEnd(")")

        arrBuf = sRcvData.Split(",")

        If arrBuf.Length = 2 Then
            sCal.Ratio = arrBuf(0)
            sCal.Offset = arrBuf(1)
        Else
            Return False
        End If
        Return True
    End Function

#End Region

End Class
