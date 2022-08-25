Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Math
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports CCommLib

Public Class cDevMcPG


#Region "Define"

    Dim communicator As CComAPI

    Dim bySetData() As Byte
    Dim byGetData() As Byte
    Dim byFieldData() As Byte

    Dim nData_Len As Integer


    Dim m_bIsConnected As Boolean = False

    Dim m_Size_Width As Integer = 1920
    Dim m_Size_Height As Integer = 1080

#Region "Enum"

    Enum eLimitAlarm
        eNoAlarm
        eVoltLimit
        eCurrentLimit
        eTempLimit
    End Enum

#End Region
#End Region

#Region "Creator, Disposer and init"

    Public Sub New()
        communicator = New CComAPI(CComCommonNode.eCommType.eTCP)
    End Sub

#End Region


#Region "Properties"

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

#End Region





#Region "Connection & Disconnection"



    Public Function Connection(ByVal info As CComSocket.sSockInfos) As Boolean

        communicator.Communicator.Connect(info)
        m_bIsConnected = True
        Return True

    End Function
    Public Function DisConnection() As Boolean
        communicator.Communicator.Disconnect()
        m_bIsConnected = False
        Return True
    End Function

#End Region

#Region "PG Command"
    '공통 명령
    Const PG_STX As Byte = &H2
    Const PG_ETX As Byte = &H3

    '공통 명령
    Const PG_COMMON As Byte = &H0
    Const PG_PING As Byte = &H0
    Const PG_RESET As Byte = &H1
    Const PG_SREGISTER As Byte = &H10
    Const PG_MOTION As Byte = &H11
    Const PG_BOARD_INFO As Byte = &H2
    Const PG_SAVE As Byte = &H14
    Const PG_RES_INIT As Byte = &H10

    '동작 설정/조회
    Const PG_SET_ERR As Byte = &H1
    Const PG_GET_ERR As Byte = &H0

    'Pattern Generator 명령
    Const PG_Command As Byte = &H20
    Const PG_FileDown As Byte = &H0
    Const PG_FileUp As Byte = &H1
    Const PG_SlideShow_Run As Byte = &H10
    Const PG_SlideShow_Stop As Byte = &H11
    Const PG_Image_Select As Byte = &H12
    Const PG_SlideShow_Interval As Byte = &H12




#End Region

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
                    Return True
                Case &H3
                    Return True
                Case &H4
                    Return True
                Case &H5
                    Return True
                Case &H6
                    Return True
                Case &HFF
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
        If byCmp(4) <> 0 Then
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

        End If





        str = ""
        str1 = ""
        If byRcvData Is Nothing Then
        Else
            If byCmp(4) <> 0 Then
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


            toutData(0) = PG_STX  'stx
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
            toutData(tCnt + 2) = PG_ETX

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

    Private Function fConvertByteInt16(ByVal inValue As Int16) As Byte()

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
#End Region
#Region "Common Function"
    Public Function cComplete(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nMotionStatus As Integer, ByRef outErrCode As Integer) As Boolean
        '이전 명령어 완료 상대 퐉인 (0x11)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_MOTION, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_PING, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_RESET, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_BOARD_INFO, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eBoard) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If

        byBoardData = byGetData

        Return True
    End Function
    Public Function cSaveData(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '저장 항목 들을 메모리에 저장 (0x14)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_SAVE, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_RES_INIT, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

        If Set_FieldInfo(inAddrs, inch, PG_COMMON, PG_RES_INIT, PG_GET_ERR, 0, byFieldData, bySetData) = False Then
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
    Public Function Get_Fileup(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inIndex As Integer, ByRef OutFileName As String, ByRef outImg As Image, Optional ByVal inSectorOffset As Single = 0, Optional ByVal inSectorLength As Single = 0) As Boolean
        '  이미지 파일을 장비에서 불러 온다 0x2001

        Dim tChrStr As String = CStr(Format(inIndex, "00"))


        ReDim byFieldData(13)


        byFieldData(0) = "&H" & Hex(Asc(tChrStr.Substring(0, 1))) 'Filename
        byFieldData(1) = "&H" & Hex(Asc(tChrStr.Substring(1, 1))) 'Filename

        byFieldData(2) = 0 'reserve
        byFieldData(3) = 0 'reserve
        byFieldData(4) = 0 'reserve
        byFieldData(5) = 0 'reserve

        Dim tLenArr() As Byte = fConvertByteSingle(inSectorOffset)  'offset 설정 시  기본값 0
        byFieldData(6) = tLenArr(0)
        byFieldData(7) = tLenArr(1)
        byFieldData(8) = tLenArr(2)
        byFieldData(9) = tLenArr(3)

        tLenArr = fConvertByteSingle(inSectorLength)  '받을 데이터 수 0 으로 설정 시 전체 DAta
        byFieldData(10) = tLenArr(0)
        byFieldData(11) = tLenArr(1)
        byFieldData(12) = tLenArr(2)
        byFieldData(13) = tLenArr(3)

        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_FileUp, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If



        OutFileName = CStr(Chr(Int(byGetData(eRcvDataLength.eStartData)))) & CStr(Chr(Int(byGetData(eRcvDataLength.eStartData + 1))))

        Dim tByteArr(3) As Byte
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 10)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 11)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 12)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 13)
        Dim tSectorLength As Double = fConvertSingleByte(tByteArr)

        Dim tImageArr() As Byte

        ReDim tImageArr(tSectorLength * 512 - 1)
        For Cnt As Integer = 0 To tSectorLength * 512 - 1

            tByteArr(0) = byGetData(eRcvDataLength.eStartData + 14 + Cnt * 1 + 0)
            'tByteArr(1) = byGetData(eRcvDataLength.eStartData + 14 + Cnt * 4 + 1)
            'tByteArr(2) = byGetData(eRcvDataLength.eStartData + 14 + Cnt * 4 + 2)
            'tByteArr(3) = byGetData(eRcvDataLength.eStartData + 14 + Cnt * 4 + 3)

            tImageArr(Cnt) = (tByteArr(0))

        Next

        '   Dim cImage As Image
        outImg = Scale_exter(tImageArr)

        Return True

    End Function
    Public Function Scale_exter(ByVal inPixels() As Byte) As Image
        Dim bmpCropped As New Bitmap(m_Size_Width, m_Size_Height, Imaging.PixelFormat.Format24bppRgb)

        For y1 As Integer = 0 To m_Size_Height - 1
            For x1 As Integer = 0 To m_Size_Width - 1
                Application.DoEvents()
                Try
                    bmpCropped.SetPixel(x1, y1, Color.FromArgb(inPixels(y1 * m_Size_Width * 3 + x1 * 3 + 2), inPixels(y1 * m_Size_Width * 3 + x1 * 3 + 1), inPixels(y1 * m_Size_Width * 3 + x1 * 3 + 0)))
                    '    frmMain.UcframePG1.TextBox3.Text = frmMain.UcframePG1.TextBox3.Text & CStr(y1 * m_Size_Width + x1 * 3 + 0) & "," & CStr(y1 * m_Size_Width + x1 * 3 + 1) & "," & CStr(y1 * m_Size_Width + x1 * 3 + 2) & vbCrLf

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
        Next

        Return bmpCropped

    End Function
    Public Function Get_ImageSelection(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutSeletIndex() As Boolean) As Boolean
        'Image selection ( 0x2012)
        ReDim byFieldData(Nothing)


        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_Image_Select, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e5Byte) = False Then
            Return False
        End If

        Dim tChkSelect() As Integer
        Dim tArrCount As Integer = 0
        Dim tChkSelectStr() As String
        ReDim tChkSelect(4)
        ReDim tChkSelectStr(4)

        Try
            For Cnt1 As Integer = 0 To 4


                tChkSelectStr(Cnt1) = Dec2Bin(Int(byGetData(eRcvDataLength.eStartData + Cnt1)))

                Dim Cnt As Integer
                Dim tStr As String

                For Cnt = 0 To tChkSelectStr(Cnt1).Length - 1

                    tStr = tChkSelectStr(Cnt1).Substring(tChkSelectStr(Cnt1).Length - 1 - Cnt, 1)
                    ReDim Preserve OutSeletIndex(tArrCount)
                    If tStr = "1" Then
                        OutSeletIndex(tArrCount) = True
                    Else
                        OutSeletIndex(tArrCount) = False
                    End If

                    tArrCount = tArrCount + 1
                Next

            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        Return True
    End Function
    Public Function Get_SlideInterval(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef OutInterval() As Integer) As Boolean
        'Slide Interval ( 0x2013)
        ' value 1 이 100ms
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_Image_Select, PG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eInterval) = False Then
            Return False
        End If


        ReDim OutInterval(Int(eRcvDataLength.eInterval) - 1)
        Dim tValArr(1) As Byte

        For Cnt As Integer = 0 To OutInterval.Length - 1
            ' tValArr(0) = byGetData(eRcvDataLength.eStartData + Cnt *2 + 0)
            '     tValArr(1) = byGetData(eRcvDataLength.eStartData + Cnt * 2 + 1)

            OutInterval(Cnt) = Int(byGetData(eRcvDataLength.eStartData + Cnt * 1 + 0))

        Next



        Return True
    End Function
#End Region
#Region "Set Function"
    Public Function Scale_Inter(ByVal inFilePath As String, ByRef OutByte() As Byte) As Boolean

        Dim img As Bitmap = Image.FromFile(inFilePath)


        Dim bmd As BitmapData = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), _
                                             ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)

        If m_Size_Width <> img.Width Or m_Size_Height <> img.Height Then
            MsgBox("이미지 사이즈가 맞지 않습니다.!!")
            Return False
        End If

        Dim scan0 As IntPtr = bmd.Scan0

        Dim size As Integer = bmd.Stride * img.Height
        Dim pixels(size - 1) As Byte


        Marshal.Copy(scan0, pixels, 0, pixels.Length)




        OutByte = pixels
        Return True



    End Function
    Public Function Set_FileDown(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inFilePath As String, ByVal inIndex As Integer, Optional ByVal inOffset As Single = 0) As Boolean
        'Image File Down ( 0x2000 )
        '이미지 파일을 장비에 다운


        Dim f_Extention As New FileInfo(inFilePath)

        If File.Exists(inFilePath) = False Then
            MsgBox("파일이 존재 하지 않습니다!", MsgBoxStyle.OkOnly, "Care!!")
            Return False
        End If

        If f_Extention.Extension <> ".bmp" And f_Extention.Extension <> ".JPG" And f_Extention.Extension <> ".JPEG" Then

            MsgBox("이미지] 파일이 아닙니다.")

            Return False

        End If

        Dim tFileData() As Byte = Nothing

        If Scale_Inter(inFilePath, tFileData) = False Then
            Return False
        End If



        ReDim byFieldData(tFileData.Length - 1 + 14)



        If inIndex < 0 Or inIndex > 40 Then

            MsgBox("인덱스는 1 에서 40 까지 가능 합니다!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim tChrStr As String = CStr(Format(inIndex, "00"))

        byFieldData(0) = "&H" & Hex(Asc(tChrStr.Substring(0, 1))) 'Filename
        byFieldData(1) = "&H" & Hex(Asc(tChrStr.Substring(1, 1))) 'Filename

        Dim tCutValue As Integer = 512
        Dim tTotalSetor As Integer = tFileData.Length / tCutValue

        Dim tLenArr() As Byte = fConvertByteSingle(tTotalSetor)  'total sector
        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        tLenArr = fConvertByteSingle(inOffset) 'offset
        byFieldData(6) = tLenArr(0)
        byFieldData(7) = tLenArr(1)
        byFieldData(8) = tLenArr(2)
        byFieldData(9) = tLenArr(3)

        tLenArr = fConvertByteSingle(tTotalSetor) '전송 Data 의 Sector 수 나중에 Offset을 설정 할 시 수정 필요
        byFieldData(10) = tLenArr(0)
        byFieldData(11) = tLenArr(1)
        byFieldData(12) = tLenArr(2)
        byFieldData(13) = tLenArr(3)

        For Cnt As Integer = 0 To tFileData.Length - 1

            '    tLenArr = fConvertByteSingle(tFileData(Cnt)) 'Data
            byFieldData(14 + Cnt) = tFileData(Cnt)


        Next
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_FileDown, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte + eRcvDataLength.eReserve + eRcvDataLength.e1Byte 'file name 2byte + reserve 1byte + Data 1byte
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If

        If byGetData(eRcvDataLength.eStartData + 3) <> 0 Then
            MsgBox("Set FileDown Failed...")
            Return False
        End If
        Return True

    End Function
    Public Function Set_SlideShowRun(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        'Image slide Show run ( 0x2010)
        ReDim byFieldData(Nothing)



        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_SlideShow_Run, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
    Public Function Set_SlideShowStop(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        'Image slide Show stop ( 0x2011)
        ReDim byFieldData(Nothing)



        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_SlideShow_Stop, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
    Public Function Set_ImageSelection(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSeletIndex() As Integer) As Boolean
        'Image selection ( 0x2012)

        Dim Cnt As Integer
        Dim Cnt1 As Integer = Nothing

        For Cnt = 0 To inSeletIndex.Length - 1
            If Int(inSeletIndex(Cnt)) < 1 Or Int(inSeletIndex(Cnt)) > 40 Then
                MsgBox("인덱스는 1 에서 40 까지 가능 합니다!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If



        Next
        Dim tChkSelect() As Integer
        Dim tChkCal0byte() As Boolean
        Dim tChkCal1byte() As Boolean
        Dim tChkCal2byte() As Boolean
        Dim tChkCal3byte() As Boolean
        Dim tChkCal4byte() As Boolean

        ReDim byFieldData(4)
        ReDim tChkSelect(4)
        ReDim tChkCal0byte(7)
        ReDim tChkCal1byte(7)
        ReDim tChkCal2byte(7)
        ReDim tChkCal3byte(7)
        ReDim tChkCal4byte(7)


        For Cnt = 0 To inSeletIndex.Length - 1

            Dim tCal As Double = (inSeletIndex(Cnt)) / 8

            If tCal <= 1 Then
                tChkSelect(4) = tChkSelect(4) + 2 ^ (0 + inSeletIndex(Cnt))
                If tChkCal4byte(inSeletIndex(Cnt)) = True Then
                    MsgBox("중복 된 채널 이 있습니다.!!", MsgBoxStyle.Critical, "Care!!")
                    Return False
                End If
                tChkCal4byte(inSeletIndex(Cnt)) = True
            ElseIf tCal <= 2 Then
                tChkSelect(3) = tChkSelect(3) + 2 ^ (8 + inSeletIndex(Cnt))
                If tChkCal3byte(inSeletIndex(Cnt)) = True Then
                    MsgBox("중복 된 채널 이 있습니다.!!", MsgBoxStyle.Critical, "Care!!")
                    Return False
                End If
                tChkCal3byte(inSeletIndex(Cnt)) = True
            ElseIf tCal <= 3 Then
                tChkSelect(2) = tChkSelect(2) + 2 ^ (16 + inSeletIndex(Cnt))
                If tChkCal2byte(inSeletIndex(Cnt)) = True Then
                    MsgBox("중복 된 채널 이 있습니다.!!", MsgBoxStyle.Critical, "Care!!")
                    Return False
                End If
                tChkCal2byte(inSeletIndex(Cnt)) = True
            ElseIf tCal <= 4 Then
                tChkSelect(1) = tChkSelect(1) + 2 ^ (24 + inSeletIndex(Cnt))
                If tChkCal1byte(inSeletIndex(Cnt)) = True Then
                    MsgBox("중복 된 채널 이 있습니다.!!", MsgBoxStyle.Critical, "Care!!")
                    Return False
                End If
                tChkCal1byte(inSeletIndex(Cnt)) = True
            ElseIf tCal <= 5 Then
                tChkSelect(0) = tChkSelect(0) + 2 ^ (32 + inSeletIndex(Cnt))
                If tChkCal0byte(inSeletIndex(Cnt)) = True Then
                    MsgBox("중복 된 채널 이 있습니다.!!", MsgBoxStyle.Critical, "Care!!")
                    Return False
                End If
                tChkCal0byte(inSeletIndex(Cnt)) = True
            End If

        Next

        byFieldData(0) = "&H" & Hex(tChkSelect(0))
        byFieldData(1) = "&H" & Hex(tChkSelect(1))
        byFieldData(2) = "&H" & Hex(tChkSelect(2))
        byFieldData(3) = "&H" & Hex(tChkSelect(3))
        byFieldData(4) = "&H" & Hex(tChkSelect(4))


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_Image_Select, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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

    Public Function Set_SlideInterval(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetInterval() As Integer) As Boolean
        'Slide Interval ( 0x2013)
        ' value 1 이 100ms
        ReDim byFieldData(inSetInterval.Length * 1 - 1)


        If inSetInterval.Length <> 40 Then
            MsgBox("Data 갯수가 40 과 같지 않습니다!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        For Cnt As Integer = 0 To inSetInterval.Length - 1
            ' tValArr = fConvertByteInt16(inSetInterval(Cnt))
            'byFieldData(Cnt * 2 + 0) = tValArr(0)
            '  byFieldData(Cnt * 2 + 1) = tValArr(1)
            byFieldData(Cnt * 1 + 0) = "&H" & Hex(inSetInterval(Cnt))
        Next

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, PG_Command, PG_Image_Select, PG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
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
