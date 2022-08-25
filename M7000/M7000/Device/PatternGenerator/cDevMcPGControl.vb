Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Math
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports CCommLib
Public Class cDevMcPGControl

#Region "Define"

    Dim cConUnit As CUnitCommonNode
    Dim communicator As CComAPI

    Dim bySetData() As Byte
    Dim byGetData() As Byte
    Dim byFieldData() As Byte

    Dim nData_Len As Integer

    Dim m_bIsConnected As Boolean = False
    Dim m_bUseLogOutput As Boolean = False

#Region "Enum"

    Enum eRcvDataLength
        eNone = 0
        eBoard = 35
        e2Byte = 2
        e3Byte = 3
        e1Byte = 1
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

    Public Enum eTargetReg
        Mipi = 0
        DriverIC
        Packet
        Packet_Comment
        Delay = 255
    End Enum
#End Region

#Region "Structure"

    'Public Structure stSgConfig
    '    Dim sSerialInfo As CComSerial.sSerialPortInfo
    'End Structure

    Public Structure sRegisterInfos
        Dim nTarget As eTargetReg
        Dim nDelay As Integer
        Dim nRegAddr As Integer
        Dim nDataLen As Integer
        Dim nRegValue() As Integer
        Dim sCommet As String
    End Structure

#End Region

#Region "MC Command"
    '공통 명령
    Const MC_STX As Byte = &H2
    Const MC_ETX As Byte = &H3

    '공통 명령
    Const MC_COMMON As Byte = &H0
    Const MC_PING As Byte = &H0
    Const MC_RESET As Byte = &H1
    Const MC_SREGISTER As Byte = &H10
    Const MC_MOTION As Byte = &H11
    Const MC_BOARD_INFO As Byte = &H2
    Const MC_SAVE As Byte = &H14
    Const MC_RES_INIT As Byte = &H10

    '동작 설정/조회
    Const MC_SET_ERR As Byte = &H1
    Const MC_GET_ERR As Byte = &H0

    'Module Control 명령
    Const MC_Command As Byte = &H22
    Const MC_DirverInitialize As Byte = &H0
    Const MC_DisplayONOFF As Byte = &H1
    Const MC_Register_ReadWrite As Byte = &H2
    Const MC_PatternSet As Byte = &H3



#End Region




#End Region

#Region "Property"
    Public ReadOnly Property IsConnected As Boolean
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

#Region "Creator, Disposer And init"

    Public Sub New()
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
    End Sub

#End Region


#Region "Communication Functions"

    Public Function Connection(ByVal info As CComSerial.sSerialPortInfo) As Boolean

        Dim ret As Integer = communicator.Communicator.Connect(info)

        If ret <> 1 Then
            Return False
        End If

        m_bIsConnected = True
        Return True

    End Function

    Public Function DisConnection() As Boolean
        communicator.Communicator.Disconnect()

        m_bIsConnected = False
        Return True
    End Function


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
            MsgBox("Receive error.", MsgBoxStyle.Critical, "Care!!")
            Return "Error"
        End If
        Return "Success"
    End Function

    Dim RcvDLen As Integer = 0
    Dim OutDLen As Integer = 0

    Dim byRcvData() As Byte

    Public Sub Error_CheckBuffer(ByRef GetData() As Byte, ByRef OutDataLength As Integer, ByRef RcvDataLength As Integer)
        GetData = byRcvData.Clone
        OutDataLength = OutDLen
        RcvDataLength = RcvDLen
    End Sub


    Private Function Err_Check(ByVal inGetByte() As Byte, ByRef outErrCode As Integer, ByRef nLenOfDataField As Integer, Optional ByVal inChkDataLength As Integer = 0) As Boolean
        Try
            If inGetByte Is Nothing Then
                'MsgBox("데이터가 수신되지 않았습니다.")
                Return False
            End If

            byRcvData = inGetByte.Clone

            'Data Length
            Dim tcByteArr(1) As Byte
            tcByteArr(0) = byGetData(6) '
            tcByteArr(1) = byGetData(7)
            nLenOfDataField = fConvertInt16Byte(tcByteArr)

            If inChkDataLength <> 0 Then
                If nLenOfDataField <> inChkDataLength Then
                    MsgBox("The received data is not upright.")
                    Return False
                End If
            End If

            'Check Error Code
            outErrCode = Int(byGetData(5))

            Select Case byGetData(5)
                Case &H0   'No error
                    Return True
                Case &H1   'Operation Error
                    Return True
                Case &H2   'Device initialization error
                    Return True
                Case &H3  'Receved Data Error, Uncorrect CRC
                    Return True
                Case &H4  'Receved Command Error, illegal Command
                    Return True
                Case &H5 'Processing Befor Command
                    Return True
                Case &H6 'Can't sets command
                    Return True
                Case &HFF 'Undefined error
                    Return True
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

        If m_bUseLogOutput = True Then
            fLogDisplay(frmPGSendRecieveLog.LogSend, str1)
        End If

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

            If m_bUseLogOutput = True Then
                fLogDisplay(frmPGSendRecieveLog.LogRcv, str1)
            End If




            If byRcvData.Length < 10 Then
                '  MsgBox("수신된 데이타가 없습니다.")
                Return Nothing
            End If

            str1 = ""
        End If

        Return byRcvData

    End Function

    Private Function Set_FieldInfo(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal Cmd1 As Byte, ByVal Cmd2 As Byte, ByVal Err As Byte, ByVal Len As Integer, ByVal Data() As Byte, ByRef outSetData() As Byte) As Boolean


        Try

            Dim toutData() As Byte
            Dim tCnt As Integer = 0
            ReDim toutData(9 + Len)


            toutData(0) = MC_STX  'stx
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
            toutData(tCnt + 2) = MC_ETX

            outSetData = toutData.Clone

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "Convert Function"

    Private Function fConvertInt8Byte(ByVal inValue As Byte) As Integer
        Dim bVal As Integer
        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.ByteData = inValue

        bVal = convertedValue.UINT8_Data

        Return bVal
    End Function

    Private Function fConvertByteInt16(ByVal inValue As UInt16) As Byte()
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

    Private Function fConvertByteSingle(ByVal inValue As Int32) As Byte()
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
        DecToBin = ""
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
#End Region

#Region "Control Functions"

    Public Function cComplete(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nMotionStatus As Integer, ByRef outErrCode As Integer) As Boolean
        '이전 명령어 완료 상대 퐉인 (0x11)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_MOTION, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_PING, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_RESET, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_BOARD_INFO, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_SAVE, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_RES_INIT, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, MC_COMMON, MC_RES_INIT, MC_GET_ERR, 0, byFieldData, bySetData) = False Then
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

#Region "Get Function"
    Public Function Get_DisplayOnOFF(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutOnOFF As eOnOff) As Boolean
        ' Driver OnOFF ( 0x2201)
        ReDim byFieldData(Nothing)


        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_DisplayONOFF, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e1Byte) = False Then
            Return False
        End If

        Try
            OutOnOFF = Int(byGetData(eRcvDataLength.eStartData))
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        Return True
    End Function
    Public Function Get_RegReadWrite(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inregaddr As Integer, ByVal OutRegData As String) As Boolean
        '
        'Reg Read( 0x2202)
        ReDim byFieldData(0)

        byFieldData(0) = "&H" & Hex(inregaddr)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_DisplayONOFF, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        OutRegData = ""
        Try
            If outDataLen > 1 Then
                For Cnt As Integer = 1 To outDataLen - 1

                    If Cnt = 1 Then
                        OutRegData = CStr((byGetData(eRcvDataLength.eStartData + Cnt)))
                    Else
                        OutRegData = OutRegData & "," & CStr((byGetData(eRcvDataLength.eStartData + Cnt)))
                    End If

                Next

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        Return True
    End Function

#End Region

#Region "Set Function"

    Public Function Set_Initialize(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '
        ' Driver Initialize ( 0x2200)

        ReDim byFieldData(Nothing)


        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_DirverInitialize, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
    Public Function Set_Pattern(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetMode As Integer, ByVal inR As Integer, ByVal inG As Integer, ByVal inB As Integer) As Boolean
        '
        ' Driver OnOFF ( 0x2201)

        ReDim byFieldData(3)

        byFieldData(0) = "&H" & Hex(inSetMode)
        byFieldData(1) = "&H" & Hex(inR)
        byFieldData(2) = "&H" & Hex(inG)
        byFieldData(3) = "&H" & Hex(inB)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_PatternSet, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
    Public Function Set_DisplayOnOFF(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inOnOFF As eOnOff) As Boolean
        '
        ' Driver OnOFF ( 0x2201)

        ReDim byFieldData(0)

        byFieldData(0) = "&H" & Hex(inOnOFF)
        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_DisplayONOFF, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

    Public Function Set_RegReadWrite(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inregaddr As Integer, ByVal inRegData() As Integer) As Boolean
        '
        'Reg Write ( 0x2202)

        ReDim byFieldData(inRegData.Length - 1 + 1)

        byFieldData(0) = "&H" & Hex(inregaddr)

        For Cnt As Integer = 0 To inRegData.Length - 1
            byFieldData(Cnt + 1) = "&H" & Hex(inRegData(Cnt))
        Next


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_Register_ReadWrite, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

    Public Function ModuleReset(ByVal inAddrs As Integer, ByVal inch As Integer) As Integer '

        'ReDim byFieldData(inRegData.Length - 1 + 1)
        'Dim byBuf(3000) As Byte
        '  Dim byBuf() As Byte = New Byte() {&H0, &HBC, &H2, &H0, &H1, &H0, &HBF, &H2, &H0, &H1} '20140408
        Dim byBuf() As Byte = New Byte() {&H0, &HBC, &H2, &H0, &H1, _
                                          &H0, &HBF, &H2, &H0, &H1, _
                                          &HFF, &H0, &HA0, _
                                          &H0, &HC0, &H2, &H1, &H0, _
                                          &HFF, &H0, &H10} '20140411
        'Dim byDelayBuf(1) As Byte
        Dim nCnt As Integer = byBuf.Length
        'For i As Integer = 0 To initCodes.Length - 1
        '    byBuf(nCnt) = Convert.ToByte(initCodes(i).nTarget) : nCnt += 1
        '    If initCodes(i).nTarget = eTargetReg.Delay Then
        '        byDelayBuf = fConvertInt16ToByte((initCodes(i).nDelay))
        '        byBuf(nCnt) = byDelayBuf(0) : nCnt += 1
        '        byBuf(nCnt) = byDelayBuf(1) : nCnt += 1
        '    Else
        '        byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegAddr) : nCnt += 1
        '        byBuf(nCnt) = Convert.ToByte(initCodes(i).nDataLen) : nCnt += 1
        '        For n As Integer = 0 To initCodes(i).nRegValue.Length - 1
        '            byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegValue(n)) : nCnt += 1
        '        Next
        '    End If
        'Next

        ReDim byFieldData(nCnt - 1)

        Array.Copy(byBuf, 0, byFieldData, 0, nCnt)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_Register_ReadWrite, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        Dim outErrCode As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then Return 300
        Return outErrCode
    End Function

    Public Function DownloadInitialCode(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal initCodes() As sRegisterInfos) As Integer

        'ReDim byFieldData(inRegData.Length - 1 + 1)
        Dim byBuf(3000) As Byte
        Dim byDelayBuf(1) As Byte
        Dim nCnt As Integer = 0
        For i As Integer = 0 To initCodes.Length - 1
            If initCodes(i).nTarget = eTargetReg.Packet Or initCodes(i).nTarget = eTargetReg.Packet_Comment Then

            Else
                byBuf(nCnt) = Convert.ToByte(initCodes(i).nTarget) : nCnt += 1
                If initCodes(i).nTarget = eTargetReg.Delay Then
                    byDelayBuf = fConvertByteInt16((initCodes(i).nDelay))
                    byBuf(nCnt) = byDelayBuf(0) : nCnt += 1
                    byBuf(nCnt) = byDelayBuf(1) : nCnt += 1
                ElseIf initCodes(i).nTarget = eTargetReg.Mipi Then
                    byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegAddr) : nCnt += 1
                    byBuf(nCnt) = Convert.ToByte(initCodes(i).nDataLen) : nCnt += 1
                    For n As Integer = 0 To initCodes(i).nRegValue.Length - 1
                        byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegValue(n)) : nCnt += 1
                    Next
                End If
            End If
        Next

        ReDim byFieldData(nCnt - 1)

        Array.Copy(byBuf, 0, byFieldData, 0, nCnt)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_Register_ReadWrite, MC_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        Dim outErrCode As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then Return 300
        Return outErrCode
    End Function


    Public Function UploadInitialCode(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef initCodes() As sRegisterInfos) As Integer


        Dim byBuf(3000) As Byte
        Dim byDelayBuf(1) As Byte
        Dim nCnt As Integer = 0
        Dim nIdxOfDelay() As Integer = Nothing  'Init Code Packet에서(initCodes) Delay 값에 해당하는 값의 인덱스를 저장하는 배열
        Dim nCntDelay As Integer = 0

        For i As Integer = 0 To initCodes.Length - 1
            If initCodes(i).nTarget = eTargetReg.Delay Then
                ReDim Preserve nIdxOfDelay(nCntDelay)
                nIdxOfDelay(nCntDelay) = i
                nCntDelay += 1
            Else
                byBuf(nCnt) = Convert.ToByte(initCodes(i).nTarget) : nCnt += 1
                byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegAddr) : nCnt += 1
                byBuf(nCnt) = Convert.ToByte(initCodes(i).nDataLen) : nCnt += 1
            End If
        Next

        ReDim byFieldData(nCnt - 1)

        Array.Copy(byBuf, 0, byFieldData, 0, nCnt)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, MC_Command, MC_Register_ReadWrite, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return 300
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        Dim outErrCode As Integer

        '=====================Test Code Start=====================================

        'Dim byBuf(3000) As Byte
        'Dim byDelayBuf(1) As Byte
        'Dim nCnt As Integer = 0
        'Dim nIdxOfDelay() As Integer = Nothing  'Init Code Packet에서(initCodes) Delay 값에 해당하는 값의 인덱스를 저장하는 배열
        'Dim nCntDelay As Integer = 0

        'For i As Integer = 0 To initCodes.Length - 1
        '    If initCodes(i).nTarget = eTargetReg.Delay Then
        '        ReDim Preserve nIdxOfDelay(nCntDelay)
        '        nIdxOfDelay(nCntDelay) = i
        '        nCntDelay += 1
        '    End If
        'Next

        'For i As Integer = 0 To initCodes.Length - 1

        '    If initCodes(i).nTarget = eTargetReg.Delay Then
        '        'byBuf(nCnt) = Convert.ToByte(initCodes(i).nTarget) : nCnt += 1
        '        'byDelayBuf = fConvertByteInt16((initCodes(i).nDelay))
        '        'byBuf(nCnt) = byDelayBuf(0) : nCnt += 1
        '        'byBuf(nCnt) = byDelayBuf(1) : nCnt += 1
        '    Else
        '        byBuf(nCnt) = Convert.ToByte(initCodes(i).nTarget) : nCnt += 1
        '        byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegAddr) : nCnt += 1
        '        byBuf(nCnt) = Convert.ToByte(initCodes(i).nDataLen) : nCnt += 1
        '        For n As Integer = 0 To initCodes(i).nRegValue.Length - 1
        '            byBuf(nCnt) = Convert.ToByte(initCodes(i).nRegValue(n)) : nCnt += 1
        '        Next
        '    End If

        '    initCodes(i).nRegValue = Nothing
        'Next

        'ReDim byFieldData(nCnt - 1)

        'Array.Copy(byBuf, 0, byFieldData, 0, nCnt)

        'nData_Len = byFieldData.Length

        'If Set_FieldInfo(inAddrs, inch, MC_Command, MC_Register_ReadWrite, MC_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
        '    Return False
        'End If

        '' bySetData = Set_FiledInfo()
        'byGetData = bySetData.Clone 'SendCommand(bySetData)
        'Dim outDataLen As Integer
        'Dim outErrCode As Integer

        'Test Code End======================================================

        Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone)

        If outErrCode <> 0 Then
            initCodes = Nothing
            Return outErrCode
        End If

        '===============================================
        '==============recevied data parsing==================
        '===============================================
        Dim RcvInitCode As sRegisterInfos
        Dim RcvInitCodePacket() As sRegisterInfos = Nothing
        Dim byRcvDataField(outDataLen - 1) As Byte
        Try
            Array.Copy(byGetData, 8, byRcvDataField, 0, outDataLen)
        Catch ex As Exception
            initCodes = Nothing
            Return 301   'Error 정의 필요
        End Try

        nCnt = 0    '한 패킷 안에 포한된 Register 명령의 수
        Dim nCntByte As Integer = 0
        Do

            'For i As Integer = 0 To byRcvDataField.Length - 1
            'Target
            RcvInitCode.nTarget = Convert.ToInt16(byRcvDataField(nCntByte)) : nCntByte += 1
            'Check Target
            Select Case RcvInitCode.nTarget
                Case eTargetReg.Mipi

                Case eTargetReg.DriverIC

                Case eTargetReg.Delay
                    initCodes = Nothing
                    Return 302
                Case Else
                    initCodes = Nothing
                    Return 303
            End Select

            RcvInitCode.nRegAddr = Convert.ToInt16(byRcvDataField(nCntByte)) : nCntByte += 1
            RcvInitCode.nDataLen = Convert.ToInt16(byRcvDataField(nCntByte)) : nCntByte += 1

            ReDim RcvInitCode.nRegValue(RcvInitCode.nDataLen - 1)
            For n As Integer = 0 To RcvInitCode.nDataLen - 1
                RcvInitCode.nRegValue(n) = Convert.ToInt16(byRcvDataField(nCntByte)) : nCntByte += 1
            Next

            ReDim Preserve RcvInitCodePacket(nCnt)
            RcvInitCodePacket(nCnt).nTarget = RcvInitCode.nTarget
            RcvInitCodePacket(nCnt).nDelay = RcvInitCode.nDelay
            RcvInitCodePacket(nCnt).nRegAddr = RcvInitCode.nRegAddr
            RcvInitCodePacket(nCnt).nDataLen = RcvInitCode.nDataLen
            RcvInitCodePacket(nCnt).nRegValue = RcvInitCode.nRegValue.Clone

            nCnt += 1
            'Next

        Loop Until byRcvDataField.Length = nCntByte


        '===========================================================
        '카운트 변수 초기화
        nCnt = 0
        For i As Integer = 0 To initCodes.Length - 1

            If nIdxOfDelay Is Nothing Then
                If initCodes.Length = RcvInitCodePacket.Length Then
                    initCodes = RcvInitCodePacket.Clone
                Else
                    initCodes = Nothing
                    MsgBox("The number of verification request data and received data is not right.")
                    Return 304
                End If
            Else
                '딜레이가 아니면,
                Dim bIsDelay As Boolean = False
                For n As Integer = 0 To nIdxOfDelay.Length - 1
                    If i = nIdxOfDelay(n) Then
                        bIsDelay = True
                    End If
                Next

                'Delay Index가 아닌 곳에만 복사
                If bIsDelay = False Then
                    initCodes(i).nTarget = RcvInitCodePacket(nCnt).nTarget
                    initCodes(i).nDelay = RcvInitCodePacket(nCnt).nDelay
                    initCodes(i).nRegAddr = RcvInitCodePacket(nCnt).nRegAddr
                    initCodes(i).nDataLen = RcvInitCodePacket(nCnt).nDataLen
                    initCodes(i).nRegValue = RcvInitCodePacket(nCnt).nRegValue.Clone
                    nCnt += 1
                End If
            End If

        Next
        '===================================================================

        Return outErrCode
    End Function

#End Region
End Class
