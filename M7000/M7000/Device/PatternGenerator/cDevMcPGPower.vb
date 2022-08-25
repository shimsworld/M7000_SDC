Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Math
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports CCommLib

Public Class cDevMcPGPower

#Region "Define"

    Dim cConUnit As CUnitCommonNode
    Dim communicator As CComAPI

    Dim bySetData() As Byte
    Dim byGetData() As Byte
    Dim byFieldData() As Byte

    Dim nData_Len As Integer

    Dim m_bIsConnected As Boolean = False
    Dim m_bUseLogOutput As Boolean = False
    'Public CH As Integer = 0
    'Public ADDR As Integer = 0

    Dim nNumofMaxPower As Integer = 5
    Public Cal_DacSlope() As Double
    Public Cal_DacOffset() As Double
    Public Cal_AdcSlope() As Double
    Public Cal_AdcOffset() As Double

    Public CalApply As Boolean = False

#Region "Enum"

    Enum eRcvDataLength
        eNone = 0
        eBoard = 35
        e2Byte = 2
        e3Byte = 3
        e1Byte = 1
        ePortbyte = 1
        e4Byte = 4
        e5Byte = 5
        eStartData = 8
        eChByte = 1
        eReserve = 1
        eInterval = 40
    End Enum

    Enum eOnOff
        eOFF
        eON
    End Enum
#End Region

#End Region

#Region "Properties"

    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property


    Public Property UseLogOutput As Boolean
        Get
            Return m_bUseLogOutput
        End Get
        Set(ByVal value As Boolean)
            m_bUseLogOutput = value
        End Set
    End Property

#End Region

#Region "Creator, Disposer and initilization"

    Public Sub New()
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        ReDim Cal_DacSlope(nNumofMaxPower - 1)
        ReDim Cal_DacOffset(nNumofMaxPower - 1)
        ReDim Cal_AdcSlope(nNumofMaxPower - 1)
        ReDim Cal_AdcOffset(nNumofMaxPower - 1)

    End Sub
#End Region

#Region "Connection & Disconnection"

    Public Function Connection(ByVal info As CComSerial.sSerialPortInfo) As Boolean

        '    info.enableTerminator = True
        '   info.sCMDTerminator = Chr(&H3)
        If communicator.Communicator.Connect(info) = False Then Return False

        m_bIsConnected = True
        Return True

    End Function

    Public Sub DisConnection()
        communicator.Communicator.Disconnect()

        m_bIsConnected = False

    End Sub



#End Region

#Region "MC Command"
    '공통 명령
    Const Power_STX As Byte = &H2
    Const Power_ETX As Byte = &H3

    '공통 명령
    Const Power_COMMON As Byte = &H0
    Const Power_PING As Byte = &H0
    Const Power_RESET As Byte = &H1
    Const Power_SREGISTER As Byte = &H10
    Const Power_MOTION As Byte = &H11
    Const Power_BOARD_INFO As Byte = &H2
    Const Power_SAVE As Byte = &H14
    Const Power_RES_INIT As Byte = &H10

    '동작 설정/조회
    Const Power_SET_ERR As Byte = &H1
    Const Power_GET_ERR As Byte = &H0

    'Power  Control 명령
    Const Power_Command As Byte = &H23
    Const Power_OnOff As Byte = &H0
    Const Power_Output As Byte = &H2
    Const Power_InputMeasurement As Byte = &H10
    Const Power_InputLimit As Byte = &H11
    Const Power_AllInputLimit As Byte = &H12
    Const Power_OnDelay As Byte = &H20
    Const Power_OffDelay As Byte = &H21

    'power Cal data
    Const Power_Compensation As Byte = &HF0
    Const Power_Dac_Slope As Byte = &H0
    Const Power_Dac_Offset As Byte = &H1

    Const Power_ADc_Slope As Byte = &H10
    Const Power_ADc_Offset As Byte = &H11
#End Region

#Region "Send Command"

    Public Function fCheckAlarm(ByVal inType As Boolean, ByVal inValue As Byte) As String

        Dim rStr As String = Dec2Bin(fConvertInt8Byte(inValue))
        Dim t2BinStr As String = "0"
        If rStr.Length <= 8 Then
            For Cnt As Integer = rStr.Length - 1 To 0 Step -1
                t2BinStr = rStr.Substring(Cnt, 1)

                If inType = True Then
                    'Register Error Check  1st Byte

                    If t2BinStr = "1" Then
                        Select Case Cnt

                            Case 0
                                MsgBox("TBD")
                            Case 1
                                MsgBox("TBD")
                            Case 2
                                MsgBox("TBD")
                            Case 3
                                MsgBox("TBD")
                            Case 4
                                MsgBox("TBD")
                            Case 5
                                MsgBox("TBD")
                            Case 6
                                MsgBox("TBD")
                            Case 7
                                MsgBox("TBD")

                        End Select
                    End If

                ElseIf inType = False Then
                    'Register Error Check  2nd Byte

                    If t2BinStr = "1" Then
                        Select Case Cnt

                            Case 0
                                MsgBox("TBD")
                            Case 1
                                MsgBox("TBD")
                            Case 2
                                MsgBox("TBD")
                            Case 3
                                MsgBox("TBD")
                            Case 4
                                MsgBox("TBD")
                            Case 5
                                MsgBox("TBD")
                            Case 6
                                MsgBox("Limit Alarm")
                                Return "Limit Alarm"
                            Case 7
                                MsgBox("TBD")

                        End Select
                    End If
                End If

            Next

        Else
            MsgBox("수신 된 값이 올바르지 않습니다!!", MsgBoxStyle.Critical, "Care!!")
            Return "Error"
        End If
        Return "Success"
    End Function
    Public Enum eErrorCode
        eSuccess
        eErrAction
        eErrInit
        eErrFrame 'crc code
        eErrCommand 'invaldi command
        eErrComplete 'Running
        eErrSet
        ' 0 정상 상태 0x00 명령 정상 수행
        '1 동작 오류 0x01 설정한 에러가 동작 중 발생한 경우
        '2 장비 초기화 오류 0x02 장비 초기화 수행 오류
        '3 수신 프레임 오류 0x03 수신된 데이터의 프레임 오류 / CRC 오류
        '4 수신 명령 오류 0x04 수신된 명령이 존재하지 않음
        '5 명령 수행 중 오류 0x05 이전에 받은 명령을 수행 중인 경우
        '6 명령 설정 오류 0x06 설정 동작 명령에 실패한 경우
        '```
        '정의되지 않은 오류 0xFF 정의되지 않은 오류 발생할 경우
    End Enum
    Private Function Err_Check(ByVal inGetByte() As Byte, ByRef outErrCode As Integer, ByRef outDataLength As Integer, Optional ByVal inChkDataLength As Integer = 0) As Boolean
        Try
            If inGetByte Is Nothing Then
                MsgBox("데이터가 수신되지 않았습니다.")
                Return False
            End If

            Dim tcByteArr(1) As Byte
            tcByteArr(0) = byGetData(6)
            tcByteArr(1) = byGetData(7)

            Dim tLength As Integer = fConvertInt16Byte(tcByteArr)
            If inChkDataLength <> 0 Then
                If tLength <> inChkDataLength Then
                    MsgBox("수신된 데이터 갯수가 맞지 않습니다.")
                    Return False
                End If


            End If
            outDataLength = tLength
            outErrCode = Int(byGetData(5))

            Select Case byGetData(5)
                Case &H0

                    Return True
                Case &H1
                    Return True
                Case &H2
                    MsgBox(eErrorCode.eErrInit.ToString)
                    Return True
                Case &H3
                    MsgBox(eErrorCode.eErrFrame.ToString)
                    Return True
                Case &H4
                    MsgBox(eErrorCode.eErrCommand.ToString)
                    Return True
                Case &H5
                    MsgBox(eErrorCode.eErrComplete.ToString)
                    Return True
                Case &H6
                    MsgBox(eErrorCode.eErrSet.ToString)
                    Return True
                Case Else
                    MsgBox("UnKnown Error")
                    'Case &HFF
                    '    Return True
            End Select


        Catch ex As Exception

            MsgBox(ex.ToString)
            Return False
        End Try
        '   frmMain.lbl_status.Text = "에러 발생"
        '   MsgBox("에러 발생 : Err_Check() ", MsgBoxStyle.Critical, "Care!!")
        Return True
    End Function

    Public Sub fLogDisplay(ByRef inListView As ucSingleList, ByVal inString As String)

        inListView.AddRowData(inString)
    End Sub

    Public Function SendCommand(ByVal byCmp() As Byte) As Byte()

        Dim byRcvData() As Byte = Nothing
        Dim nLength As Integer = Nothing
        Dim byCrc As Byte = Nothing
        Dim dec As String = Nothing



        For i As Integer = 0 To byCmp.Length - 4
            byCrc = byCrc Xor byCmp(i + 1)
        Next

        byCrc = &H55 Xor byCrc
        byCmp(byCmp.Length - 2) = byCrc


        communicator.Communicator.SendToBytes(byCmp, byRcvData)





        Dim str As String = ""
        Dim str1 As String = ""

        For i As Integer = 0 To byCmp.Length - 1
            'item.SubItems.Add(Hex(byCmp(i)))
            Dim tSTr As String = Hex(byCmp(i)).ToString
            If tSTr.Length = 1 Then
                tSTr = "0" & tSTr
            End If
            str = " " & tSTr
            str1 &= str
        Next

        fLogDisplay(frmPGSendRecieveLog.LogSend, str1)







        str = ""
        str1 = ""
        If byRcvData Is Nothing Then
        Else

            For i As Integer = 0 To byRcvData.Length - 1
                'item.SubItems.Add(Hex(byCmp(i)))
                Dim tSTr As String = Hex(byRcvData(i)).ToString
                If tSTr.Length = 1 Then
                    tSTr = "0" & tSTr
                End If
                str = " " & tSTr
                str1 &= str
            Next
            fLogDisplay(frmPGSendRecieveLog.LogRcv, str1)
        End If
        If byRcvData Is Nothing Then
            Return byRcvData
        End If

        If byRcvData.Length < 10 Then
            '  MsgBox("수신된 데이타가 없습니다.")
            Return Nothing
        End If

        str1 = ""



        Return byRcvData

    End Function
    Private Function Set_FieldInfo(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal Cmd1 As Byte, ByVal Cmd2 As Byte, ByVal Err As Byte, ByVal Len As Integer, ByVal Data() As Byte, ByRef outSetData() As Byte) As Boolean


        Try

            Dim toutData() As Byte
            Dim tCnt As Integer = 0
            ReDim toutData(9 + Len)


            toutData(0) = Power_STX  'stx
            toutData(1) = "&H" & Hex(inAddrs) 'addrs
            toutData(2) = "&H" & Hex(inch) 'ch
            toutData(3) = Cmd1 'cmd 1byte
            toutData(4) = Cmd2 'cmd 1byte

            toutData(5) = Err '"&H" & Hex(Err) 'err 1byte

            Dim tLenArr() As Byte
            Try
                tLenArr = fConvertByteInt16(Len)
            Catch ex As Exception
                ReDim tLenArr(1)
                tLenArr(0) = 0
                tLenArr(1) = 0
            End Try



            toutData(6) = tLenArr(0) '"&H" & Hex(tLenArr(0)) 'cmd 1byte
            toutData(7) = tLenArr(1) '"&H" & Hex(tLenArr(1)) 'cmd 1byte



            If Len > 0 Then

                For nCnt As Integer = 1 To Len
                    toutData(7 + nCnt) = Data(nCnt - 1)
                    tCnt = 7 + nCnt
                Next
            Else
                tCnt = 7

            End If
            toutData(tCnt + 1) = 0 'CRC
            toutData(tCnt + 2) = Power_ETX

            outSetData = toutData.Clone

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
#End Region
#Region "Convert Function"
    Private Function fConvertInt8Byte(ByVal inValue As Byte) As Integer


        Dim bVal As Integer



        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.ByteData = inValue


        bVal = convertedValue.UINT8_Data



        Return bVal
    End Function
    Private Function fConvertByteInt16(ByVal inValue As Integer) As Byte()


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16
        convertedValue.UINT16_Data = inValue


        bVal(1) = (convertedValue.ByteData_L)
        bVal(0) = (convertedValue.ByteData_H)



        Return bVal
    End Function

    Private Function fConvertInt16Byte(ByVal inValueArr() As Byte) As Int16


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16



        convertedValue.ByteData_L = inValueArr(1)
        convertedValue.ByteData_H = inValueArr(0)



        Return convertedValue.UINT16_Data
    End Function
    Private Function fConvertInt24Byte(ByVal inValueArr() As Byte) As UInteger


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24



        convertedValue.ByteDataL = inValueArr(2)
        convertedValue.ByteDataM = inValueArr(1)
        convertedValue.ByteDataH = inValueArr(0)



        Return convertedValue.UINT24_Data
    End Function
    Private Function fConvert24ByteInt(ByVal inValue As UInteger) As Byte()


        Dim bVal(2) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24



        bVal(2) = convertedValue.ByteDataL
        bVal(1) = convertedValue.ByteDataM
        bVal(0) = convertedValue.ByteDataH



        Return bVal
    End Function
    Private Function fConvertSingleByte(ByVal inValueArr() As Byte) As Single

        Dim bVal(3) As Byte

        Try

            If inValueArr.Length = 4 Then
                Dim convertedValue As CUnitCommonNode.SplitSingle

                convertedValue.ByteData0_L = inValueArr(0)
                convertedValue.ByteData0_H = inValueArr(1)
                convertedValue.ByteData1_L = inValueArr(2)
                convertedValue.ByteData1_H = inValueArr(3)


                Return convertedValue.SingleData
            Else
                Return 0
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

        Return 0

    End Function
    Private Function fConvertByteSingle(ByVal inValue As Single) As Byte()

        Dim bVal(3) As Byte



        Dim convertedValue As CUnitCommonNode.SplitSingle
        convertedValue.SingleData = inValue


        bVal(0) = convertedValue.ByteData0_L '
        bVal(1) = convertedValue.ByteData0_H 'convertedValue.ByteData0_H
        bVal(2) = convertedValue.ByteData1_L
        bVal(3) = convertedValue.ByteData1_H



        Return bVal
    End Function
    Private Function DecToBin(ByVal ival As Long) As String
        Dim redata As String = ""
        DecToBin = Nothing
        Do Until ival = 0
            DecToBin = CStr((ival Mod 2)) + DecToBin
            ival = ival \ 2
        Loop
        redata = DecToBin

        Return redata
    End Function
    Public Function Dec2Bin(ByVal inValue As Integer) As String


        Dim d As Integer
        Dim n As Integer = inValue
        Dim m As Integer
        Dim ret As String = ""

        Do
            d = n \ 2 '몫
            m = n Mod 2 '나머지
            ret = CStr(m) & ret '나머지 보관(문자열)

            n = d
        Loop Until d < 2

        If d > 0 Then ret = d & ret

        Return ret
    End Function
    Public Function fConvertGetDoubleV1(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 6
    End Function
    Public Function fConvertSetDoubleV1(ByVal inValue As Double) As Double
        Return ((inValue) / 6) * ((2 ^ 16) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleV2(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 12
    End Function
    Public Function fConvertSetDoubleV2(ByVal inValue As Double) As Double
        Return ((inValue) / 12) * ((2 ^ 16) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleV3(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 12
    End Function
    Public Function fConvertSetDoubleV3(ByVal inValue As Double) As Double
        Return ((inValue) / 12) * ((2 ^ 16) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleV4(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 24
    End Function
    Public Function fConvertSetDoubleV4(ByVal inValue As Double) As Double
        Return ((inValue) / 24) * ((2 ^ 16) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleV5(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 10 * -1 '(음수)
    End Function
    Public Function fConvertSetDoubleV5(ByVal inValue As Double) As Double
        Return ((inValue) / 10) * ((2 ^ 16) - 1)  'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleLimitV1(ByVal inValue As Double) As Double
        Return (inValue / &HFFF) * 6
    End Function
    Public Function fConvertSetDoubleLimitV1(ByVal inValue As Double) As Double
        Return ((inValue) / 6) * ((2 ^ 12) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleLimitV2(ByVal inValue As Double) As Double
        Return (inValue / &HFFF) * 12
    End Function
    Public Function fConvertSetDoubleLimitV2(ByVal inValue As Double) As Double
        Return ((inValue) / 12) * ((2 ^ 12) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleLimitV3(ByVal inValue As Double) As Double
        Return (inValue / &HFFF) * 12
    End Function
    Public Function fConvertSetDoubleLimitV3(ByVal inValue As Double) As Double
        Return ((inValue) / 12) * ((2 ^ 12) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleLimitV4(ByVal inValue As Double) As Double
        Return (inValue / &HFFF) * 24
    End Function
    Public Function fConvertSetDoubleLimitV4(ByVal inValue As Double) As Double
        Return ((inValue) / 24) * ((2 ^ 12) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleLimitV5(ByVal inValue As Double) As Double
        Return (inValue / &HFFF) * 10
    End Function
    Public Function fConvertSetDoubleLimitV5(ByVal inValue As Double) As Double
        Return ((inValue) / 10) * ((2 ^ 12) - 1)  'Int16 변환 수식
    End Function
    Public Function fConvertGetDoubleRead1(ByVal inValue As Double) As Double
        Return (inValue / &HEFF) * 6
    End Function
    Public Function fConvertGetDoubleRead2(ByVal inValue As Double) As Double
        Return (inValue / &HEFF) * 12
    End Function
    Public Function fConvertGetDoubleRead3(ByVal inValue As Double) As Double
        Return (inValue / &HEFF) * 12
    End Function
    Public Function fConvertGetDoubleRead4(ByVal inValue As Double) As Double
        Return (inValue / &HEFF) * 24
    End Function
    Public Function fConvertGetDoubleRead5(ByVal inValue As Double) As Double
        Return (inValue / &HC50) * 10 - 10
    End Function

#End Region
#Region "Common Function"
    Public Function cComplete(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nMotionStatus As Integer, ByRef outErrCode As Integer) As Boolean
        '이전 명령어 완료 상대 퐉인 (0x11)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_MOTION, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e1Byte) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If

        nMotionStatus = byGetData(8)  'nMotion = 0 '수행완료 nMotion = 1 '수행중

        Return True
    End Function
    Public Function cPing(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '보드 와의 통신 확인 유무 ,   'Ping (0x00)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_PING, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then ' byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function cReset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '	보드 리셋 (0x01)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_RESET, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If

        'If CInt(byGetData(6)) <> 0 Then
        '    MsgBox("Reset Error")
        '    Return False
        'End If

        Return True
    End Function
    Public Function cBoardInfo(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef byBoardData() As Byte, ByRef outErrCode As Integer) As Boolean
        '보드 정보 확인 (0x02)
        ReDim byFieldData(Nothing)

        nData_Len = 0
        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_BOARD_INFO, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)

        If Err_Check(byGetData, outErrCode, eRcvDataLength.eBoard) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If

        byBoardData = byGetData

        Return True
    End Function
    Public Function cSaveData(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '저장 항목 들을 메모리에 저장 (0x14)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_SAVE, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If


        Return True
    End Function
    Public Function cResisterInit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '상태 레지스터  초기화 (0x10)
        ReDim byFieldData(1)

        byFieldData(0) = 0
        byFieldData(1) = 0

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_RES_INIT, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function cResisterRead(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nRegState As String, ByRef outErrCode As Integer) As Boolean
        '상태 레지스터  조회 (0x10)
        ReDim byFieldData(Nothing)
        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_COMMON, Power_RES_INIT, Power_GET_ERR, 0, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e2Byte) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e2Byte : 수신될 바이트 길이
            Return False
        End If


        nRegState = ""
        For cnt As Integer = eRcvDataLength.eStartData To eRcvDataLength.eStartData + 1
            Dim tHexStr As String = Hex(byGetData(cnt)).ToString
            If tHexStr.Length = 1 Then
                nRegState = nRegState & "0" & Hex(byGetData(cnt)).ToString & " "

            Else
                nRegState = nRegState & Hex(byGetData(cnt)).ToString & " "
            End If

            If cnt = eRcvDataLength.eStartData Then
                fCheckAlarm(True, byGetData(cnt)) '첫번 째 Byte 알람 분석
            ElseIf cnt = eRcvDataLength.eStartData + 1 Then
                fCheckAlarm(False, byGetData(cnt)) '두번 째 Byte 알람 분석
            End If
        Next



        Return True
    End Function
#End Region
#Region "2013 09 07 추가 "
    Public Function ReadCal_Dac(ByVal InAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer
        For Cnt As Integer = 0 To nNumofMaxPower - 1
            If Get_DacSlope(InAddrs, inch, ret, Cal_DacSlope(Cnt), Cnt) = False Then
                Return False
            End If
            If Get_DacOffset(InAddrs, inch, ret, Cal_DacOffset(Cnt), Cnt) = False Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function ReadCal_Adc(ByVal InAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer
        For Cnt As Integer = 0 To nNumofMaxPower - 1
            If Get_ADcSlope(InAddrs, inch, ret, Cal_AdcSlope(Cnt), Cnt) = False Then
                Return False
            End If
            If Get_ADcOffset(InAddrs, inch, ret, Cal_AdcOffset(Cnt), Cnt) = False Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function Power_Set(ByVal InAddrs As Integer, ByVal inch As Integer, ByVal inSetInfo As ucDispPGPower.sPGPwr) As Boolean

        Dim ret As Integer
        Dim OnDelayValue() As Integer

        If inSetInfo.nPwrNO Is Nothing Or inSetInfo.nPwrNO.Length = 0 Then
            MsgBox("채널 정보가 부족 합니다")
            Return False
        End If
        Dim NumTotalCHCount As Integer = inSetInfo.nPwrNO.Length
        ReDim OnDelayValue(NumTotalCHCount - 1)

        'On Delay Set
        For cnt As Integer = 0 To OnDelayValue.Length - 1
            OnDelayValue(cnt) = CDbl(inSetInfo.sPower(cnt).dONDelay) ' 1= 1ms
        Next

        If Set_PowerOnDelay(InAddrs, inch, ret, OnDelayValue) = False Then
            Return False
        End If
        'On Delay Set

        'Off Delay Set
        Dim OffDelayValue() As Integer
        ReDim OffDelayValue(NumTotalCHCount - 1)
        For cnt As Integer = 0 To OffDelayValue.Length - 1
            OffDelayValue(cnt) = CDbl(inSetInfo.sPower(cnt).dOFFDelay) '1 = 1ms
        Next
        If Set_PowerOffDelay(InAddrs, inch, ret, OffDelayValue) = False Then
            Return False
        End If
        'Off Delay Set



        'PowerOutput set
        Dim tSetVolt As Double
        For Cnt As Integer = 0 To NumTotalCHCount - 1


            If CalApply = False Then
                tSetVolt = inSetInfo.sPower(Cnt).dVoltage
            ElseIf CalApply = True Then
                tSetVolt = inSetInfo.sPower(Cnt).dVoltage * Cal_DacSlope(Cnt) + Cal_DacOffset(Cnt)
            End If
            If Set_PowerOutput(InAddrs, inch, ret, 0, inSetInfo.nPwrNO(Cnt), tSetVolt) = False Then
                Return False
            End If
        Next
        'PowerOutput set

        Return True
    End Function
    Public Function Power_On(ByVal InAddrs As Integer, ByVal inch As Integer, ByVal inSetInfo As ucDispPGPower.sPGPwr) As Boolean
        Dim ret As Integer
        If inSetInfo.nPwrNO Is Nothing Or inSetInfo.nPwrNO.Length = 0 Then
            MsgBox("채널 정보가 부족 합니다")
            Return False
        End If
        Dim nNumBitTotalValue As Integer = 0
        Dim NumTotalCHCount As Integer = inSetInfo.nPwrNO.Length



        For Cnt As Integer = 0 To NumTotalCHCount - 1

            If (inSetInfo.nPwrNO(Cnt) >= 0 And inSetInfo.nPwrNO(Cnt) <= (nNumofMaxPower - 1)) = True Then
                nNumBitTotalValue = nNumBitTotalValue + 2 ^ inSetInfo.nPwrNO(Cnt)
            Else
                MsgBox("Power 채널이 맞지 않습니다")
                Return False
            End If
        Next

        If Set_PowerOnOff(InAddrs, inch, ret, cDevMcPGPower.eOnOff.eON, 0, nNumBitTotalValue) Then
            Return False
        End If
        Return True
    End Function
    Public Function Power_Off(ByVal InAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer

        Dim nNumBitTotalValue As Integer = 0



        For Cnt As Integer = 0 To nNumofMaxPower - 1
            nNumBitTotalValue = nNumBitTotalValue + 2 ^ Cnt
        Next

        If Set_PowerOnOff(InAddrs, inch, ret, cDevMcPGPower.eOnOff.eOFF, 0, nNumBitTotalValue) Then
            Return False
        End If
        Return True
    End Function
    Public Function Power_Meas(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutVoltValue As Double, ByRef OutCurrValue As Double) As Boolean
        Dim ret As Integer

        If (inSetChannel >= 0 And inSetChannel <= (nNumofMaxPower - 1)) = False Then

            MsgBox("Power 채널이 맞지 않습니다")
            Return False
        End If


        If Get_PowerInputMeasure(inAddrs, inch, ret, inSetChannel, OutVoltValue, OutCurrValue) = False Then
            Return False
        End If

        If CalApply = True Then
            OutVoltValue = OutVoltValue * Cal_AdcSlope(inSetChannel) + Cal_AdcOffset(inSetChannel)
        End If
        Return True
    End Function
#End Region
#Region "Get Function"

    Public Function Get_PowerOnOff(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutOnOFF As eOnOff, ByVal inChannel As Integer) As Boolean
        '
        ' Power OnOFF Get( 0x2300) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함

        ReDim byFieldData(0)

        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OnOff, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If

        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then


                OutOnOFF = Int(byGetData(eRcvDataLength.eStartData + 1))

            Else
                MsgBox("채널 번호가 같지 않습니다!!")
                Return False
            End If
        Catch ex As Exception

        End Try



        Return True
    End Function
    Public Function Get_PowerOutput(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inChannel As Integer, ByVal inport As Integer, ByRef OutValue As Double) As Boolean
        '
        ' Power output Get( 0x2302) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 단위 V)

        ReDim byFieldData(1)

        byFieldData(0) = "&H" & Hex(inChannel)
        byFieldData(1) = "&H" & Hex(inport)




        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_Output, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.ePortbyte + eRcvDataLength.e2Byte 'ch byte + port byte + data byte ( 4byte)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then

                Dim tLenArr() As Byte
                'ReDim tLenArr(3)
                'tLenArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                'tLenArr(1) = byGetData(eRcvDataLength.eStartData + 3)
                'tLenArr(2) = byGetData(eRcvDataLength.eStartData + 4)
                'tLenArr(3) = byGetData(eRcvDataLength.eStartData + 5)

                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + 3)

                OutValue = fConvertInt16Byte(tLenArr)

                If inport = 0 Then
                    OutValue = fConvertGetDoubleV1(OutValue)
                ElseIf inport = 1 Then
                    OutValue = fConvertGetDoubleV2(OutValue)
                ElseIf inport = 2 Then
                    OutValue = fConvertGetDoubleV3(OutValue)
                ElseIf inport = 3 Then
                    OutValue = fConvertGetDoubleV4(OutValue)
                ElseIf inport = 4 Then
                    OutValue = fConvertGetDoubleV5((OutValue))
                End If

            Else
                MsgBox("채널 번호가 같지 않습니다!!")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_PowerInputMeasure(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inport As Integer, ByRef OutVoltValue As Double, ByRef OutCurrValue As Double) As Boolean
        '
        ' Power 전원 Port 입력 값 Get( 0x2310) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 단위 V)

        ReDim byFieldData(0)


        byFieldData(0) = "&H" & Hex(inport)




        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_InputMeasurement, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.ePortbyte + eRcvDataLength.e4Byte 'ch byte + port byte + data byte ( 4byte)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inport Then
                Dim tVolt As Double
                Dim tCurr As Double
                Dim tLenArr() As Byte
                'ReDim tLenArr(3)
                'tLenArr(0) = byGetData(eRcvDataLength.eStartData + 1)
                'tLenArr(1) = byGetData(eRcvDataLength.eStartData + 2)
                'tLenArr(2) = byGetData(eRcvDataLength.eStartData + 3)
                'tLenArr(3) = byGetData(eRcvDataLength.eStartData + 4)
                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + 1)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + 2)


                tVolt = fConvertInt16Byte(tLenArr)



                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + 3)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + 4)

                tCurr = fConvertInt16Byte(tLenArr)



                If inport = 0 Then
                    OutVoltValue = fConvertGetDoubleRead1(tVolt)
                    OutCurrValue = tCurr
                ElseIf inport = 1 Then
                    OutVoltValue = fConvertGetDoubleRead2(tVolt)
                    '  OutCurrValue = fConvertGetDoubleV2(tCurr)
                    OutCurrValue = tCurr
                ElseIf inport = 2 Then
                    OutVoltValue = fConvertGetDoubleRead3(tVolt)
                    '   OutCurrValue = fConvertGetDoubleV3(tCurr)
                    OutCurrValue = tCurr
                ElseIf inport = 3 Then
                    OutVoltValue = fConvertGetDoubleRead4(tVolt)
                    ' OutCurrValue = fConvertGetDoubleV4(tCurr)
                    OutCurrValue = tCurr
                ElseIf inport = 4 Then
                    OutVoltValue = fConvertGetDoubleRead5(tVolt)
                    'OutCurrValue = fConvertGetDoubleV5(tCurr)
                    OutCurrValue = tCurr

                End If
            Else
                MsgBox("포트 번호가 같지 않습니다!!")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_PowerInputLimit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inport As Integer, ByRef OutValue As Double) As Boolean
        ' Power input Limit  Set( 0x2311) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(0)


        byFieldData(0) = "&H" & Hex(inport)




        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_InputLimit, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.ePortbyte + eRcvDataLength.e2Byte 'ch byte + port byte + data byte ( 4byte)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inport Then

                Dim tLenArr() As Byte
                'ReDim tLenArr(3)
                'tLenArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                'tLenArr(1) = byGetData(eRcvDataLength.eStartData + 3)
                'tLenArr(2) = byGetData(eRcvDataLength.eStartData + 4)
                'tLenArr(3) = byGetData(eRcvDataLength.eStartData + 5)

                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + 3)

                OutValue = fConvertInt16Byte(tLenArr)

                If inport = 0 Then
                    OutValue = fConvertGetDoubleLimitV1(OutValue)
                ElseIf inport = 1 Then
                    OutValue = fConvertGetDoubleLimitV2(OutValue)
                ElseIf inport = 2 Then
                    OutValue = fConvertGetDoubleLimitV3(OutValue)
                ElseIf inport = 3 Then
                    OutValue = fConvertGetDoubleLimitV4(OutValue)
                ElseIf inport = 4 Then
                    OutValue = fConvertGetDoubleLimitV5(OutValue)
                End If
            Else
                MsgBox("포트 번호가 같지 않습니다!!")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_PowerAllInputLimit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutValue() As Double) As Boolean
        ' Power All input Limit  Get( 0x2312) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_AllInputLimit, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)


        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte * 5 'data byte (4byte) * Ch Count 5

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            Dim tCount As Integer = 2
            ReDim OutValue(4)
            For Cnt As Integer = 0 To OutValue.Length - 1
                Dim tLenArr() As Byte
                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 0)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 1)
                'tLenArr(2) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 2)
                'tLenArr(3) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 3)



                OutValue(Cnt) = fConvertInt16Byte(tLenArr)

                If Cnt = 0 Then
                    OutValue(Cnt) = fConvertGetDoubleLimitV1(OutValue(Cnt))
                ElseIf Cnt = 1 Then
                    OutValue(Cnt) = fConvertGetDoubleLimitV2(OutValue(Cnt))
                ElseIf Cnt = 2 Then
                    OutValue(Cnt) = fConvertGetDoubleLimitV3(OutValue(Cnt))
                ElseIf Cnt = 3 Then
                    OutValue(Cnt) = fConvertGetDoubleLimitV4(OutValue(Cnt))
                ElseIf Cnt = 4 Then
                    OutValue(Cnt) = fConvertGetDoubleLimitV5(OutValue(Cnt))
                End If


            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_PowerOnDelay(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutValue() As Integer) As Boolean
        ' Power All On Delay Get( 0x2320) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OnDelay, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)

        Dim tChannelCount As Integer = 5
        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte * tChannelCount 'data byte (2byte) * Ch Count 5

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            Dim tCount As Integer = 2
            ReDim OutValue(tChannelCount - 1)
            For Cnt As Integer = 0 To tChannelCount - 1

                Dim tLenArr() As Byte
                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 0)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 1)

                OutValue(Cnt) = fConvertInt16Byte(tLenArr)



            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_PowerOffDelay(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutValue() As Double) As Boolean
        ' Power All off  Delay Get( 0x2321) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OffDelay, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)

        Dim tChannelCount As Integer = 5
        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte * tChannelCount 'data byte (2byte) * Ch Count 5

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try
            Dim tCount As Integer = 2
            ReDim OutValue(tChannelCount - 1)
            For Cnt As Integer = 0 To tChannelCount - 1

                Dim tLenArr() As Byte
                ReDim tLenArr(1)
                tLenArr(0) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 0)
                tLenArr(1) = byGetData(eRcvDataLength.eStartData + Cnt * tCount + 1)

                OutValue(Cnt) = fConvertInt16Byte(tLenArr)



            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try



        Return True
    End Function
    Public Function Get_ADcOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC Offset 설정읽기 ( 0xF011)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_ADc_Offset, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_ADcSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC SLope 설정읽기 ( 0xF010)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length


        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_ADc_Slope, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_DacOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC Offset 설정읽기 ( 0xF001)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_Dac_Offset, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_DacSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC SLope 설정읽기 ( 0xF000)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_Dac_Slope, Power_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
#End Region

#Region "Set Function"
    Public Function Set_DacSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC SLope 설정 ( 0xF000)

        ReDim byFieldData(5)






        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_Dac_Slope, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_DacOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC Offset 설정 ( 0xF001)

        ReDim byFieldData(5)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_Dac_Offset, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_ADcSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC SLope 설정 ( 0xF010)

        ReDim byFieldData(5)






        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_ADc_Slope, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_ADcOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC Offset 설정 ( 0xF011)

        ReDim byFieldData(5)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, Power_Compensation, Power_ADc_Offset, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_PowerOffDelay(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inDelayValue() As Integer) As Boolean
        '
        ' Power All off Delay  Set( 0x2321) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        Dim tCount As Integer = 2
        ReDim byFieldData(inDelayValue.Length * tCount - 1)

        If inDelayValue.Length <> 5 Then
            MsgBox("Port 갯수는 5개 이여야 합니다!!")
            Return False
        End If

        Dim tLenArr() As Byte



        For Cnt As Integer = 0 To inDelayValue.Length - 1

            tLenArr = fConvertByteInt16(inDelayValue(Cnt))
            byFieldData(tCount * Cnt + 0) = tLenArr(0)
            byFieldData(tCount * Cnt + 1) = tLenArr(1)

        Next


        nData_Len = byFieldData.Length
        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OffDelay, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PowerOnDelay(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inDelayValue() As Integer) As Boolean
        '
        ' Power All On Delay  Set( 0x2320) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        Dim tCount As Integer = 2
        ReDim byFieldData(inDelayValue.Length * tCount - 1)

        If inDelayValue.Length <> 5 Then
            MsgBox("Port 갯수는 5개 이여야 합니다!!")
            Return False
        End If

        Dim tLenArr() As Byte



        For Cnt As Integer = 0 To inDelayValue.Length - 1

            tLenArr = fConvertByteInt16(inDelayValue(Cnt))
            byFieldData(tCount * Cnt + 0) = tLenArr(0)
            byFieldData(tCount * Cnt + 1) = tLenArr(1)

        Next


        nData_Len = byFieldData.Length
        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OnDelay, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PowerAllInputLimit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inLimitValue() As Double) As Boolean
        '
        ' Power All input Limit  Set( 0x2312) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        Dim tCount As Integer = 2
        ReDim byFieldData(inLimitValue.Length * tCount - 1)

        Dim tLenArr() As Byte
        For Cnt As Integer = 0 To inLimitValue.Length - 1
            If Cnt = 0 Then
                inLimitValue(Cnt) = fConvertSetDoubleLimitV1(inLimitValue(Cnt))
            ElseIf Cnt = 1 Then
                inLimitValue(Cnt) = fConvertSetDoubleLimitV2(inLimitValue(Cnt))
            ElseIf Cnt = 2 Then
                inLimitValue(Cnt) = fConvertSetDoubleLimitV3(inLimitValue(Cnt))
            ElseIf Cnt = 3 Then
                inLimitValue(Cnt) = fConvertSetDoubleLimitV4(inLimitValue(Cnt))
            ElseIf Cnt = 4 Then
                inLimitValue(Cnt) = fConvertSetDoubleLimitV5(inLimitValue(Cnt))
            End If

            tLenArr = fConvertByteInt16(inLimitValue(Cnt))
            byFieldData(tCount * Cnt + 0) = tLenArr(0)
            byFieldData(tCount * Cnt + 1) = tLenArr(1)
            'byFieldData(tCount * Cnt + 2) = tLenArr(2)
            'byFieldData(tCount * Cnt + 3) = tLenArr(3)


        Next





        nData_Len = byFieldData.Length
        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_AllInputLimit, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PowerInputLimit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inport As Integer, ByVal inLimitValue As Integer) As Boolean
        '
        ' Power input Limit  Set( 0x2311) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(3)

        byFieldData(0) = "&H" & Hex(inport)

        byFieldData(1) = 0 'reserve

        If inport = 0 Then
            inLimitValue = fConvertSetDoubleLimitV1(inLimitValue)
        ElseIf inport = 1 Then
            inLimitValue = fConvertSetDoubleLimitV2(inLimitValue)
        ElseIf inport = 2 Then
            inLimitValue = fConvertSetDoubleLimitV3(inLimitValue)
        ElseIf inport = 3 Then
            inLimitValue = fConvertSetDoubleLimitV4(inLimitValue)
        ElseIf inport = 4 Then
            inLimitValue = fConvertSetDoubleLimitV5(inLimitValue)
        End If


        'Dim tLenArr() As Byte = fConvertByteSingle(inLimitValue)

        'byFieldData(2) = tLenArr(0)
        'byFieldData(3) = tLenArr(1)
        'byFieldData(4) = tLenArr(2)
        'byFieldData(5) = tLenArr(3)



        Dim tLenArr() As Byte = fConvertByteInt16(inLimitValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)

        nData_Len = byFieldData.Length
        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_InputLimit, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PowerOnOff(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inOnOFF As eOnOff, ByVal inChannel As Integer, ByVal inStartBitNum As Integer) As Boolean
        '
        ' Power OnOFF Set( 0x2300) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함

        ReDim byFieldData(2)
        byFieldData(0) = "&H" & Hex(inChannel)
        byFieldData(1) = "&H" & Hex(inOnOFF)
        byFieldData(2) = "&H" & Hex(inStartBitNum)
        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_OnOff, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PowerOutput(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inChannel As Integer, ByVal inport As Integer, ByVal inValue As Double) As Boolean
        '
        ' Power output Set( 0x2302) 'Channel Num 0 ~ 7 , Channel 의미 Port0 ~ Port4 를 포함 V)

        ReDim byFieldData(3)

        byFieldData(0) = "&H" & Hex(inChannel)
        byFieldData(1) = "&H" & Hex(inport)

        'Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        'byFieldData(2) = tLenArr(0)
        'byFieldData(3) = tLenArr(1)
        'byFieldData(4) = tLenArr(2)
        'byFieldData(5) = tLenArr(3)
        '((inValue + 5) / 10) * ((2 ^ 14) - 1) 'Int16 변환 수식
        If inport = 0 Then
            inValue = fConvertSetDoubleV1(inValue)
        ElseIf inport = 1 Then
            inValue = fConvertSetDoubleV2(inValue)
        ElseIf inport = 2 Then
            inValue = fConvertSetDoubleV3(inValue)
        ElseIf inport = 3 Then
            inValue = fConvertSetDoubleV4(inValue)
        ElseIf inport = 4 Then
            inValue = fConvertSetDoubleV5(Abs(inValue)) + 3720
        End If

        Dim tLenArr() As Byte = fConvertByteInt16(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)

        nData_Len = byFieldData.Length
        If Set_FieldInfo(inAddrs, inch, Power_Command, Power_Output, Power_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
#End Region



End Class
