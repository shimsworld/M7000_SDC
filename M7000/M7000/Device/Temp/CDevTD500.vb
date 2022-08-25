Imports System.IO
Imports System.Math
Imports System.Threading
Imports CCommLib

Public Class CDevTD500
    Inherits CDevTCCommonNode

    Dim communicator As CComAPI
    Dim m_nNumOfDev As Integer
    Dim m_numOfChPerDev As Integer
    'Dim ID485 As Integer = 1

    'Public CPort As New CComSerial
#Region "Define"

    Private sSTOP As String = 0
    Private sRUN As String = 1

    Private sDregisterCh1() As String = {"126", "150", "152", "1000"} '150~151 A.T  
    Private sDregisterCh2() As String = {"127", "151", "153", "1001"} '152~153 Run    1000~1001 SV value

    'Dim m_Settings As sSettings

    'Public Structure sSettings
    '    Dim m_Settings As sParams
    'End Structure

    'Public Structure sParams
    '    Dim measTemp As Double
    '    Dim setTemp As Double
    '    Dim bIsRun As Boolean
    'End Structure


#End Region

#Region "Property"

    Public Overrides Property DevAddr As Integer
        Get
            Return ID485
        End Get
        Set(ByVal value As Integer)
            ID485 = value
        End Set
    End Property

    Public Overrides ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overrides Property NumOfChannelPerDev As Integer
        Get
            Return m_numOfChPerDev
        End Get
        Set(ByVal value As Integer)
            m_numOfChPerDev = value
        End Set

    End Property
#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal configInfo As CComCommonNode.sCommInfo) As Boolean
        Dim strTempCommand As String = ""
        Dim strRetData As String = ""

        If communicator.Communicator.Connect(configInfo) = False Then
            m_bIsConnected = False
            Return False
        End If
        m_bIsConnected = True
        Return True

    End Function

    Public Overrides Sub DisConnection()
        communicator.Communicator.Disconnect()
    End Sub

#End Region

#Region "init"

    Public Sub New(ByVal numOfDev As Integer)
        MyBase.New()
        m_MyModel = eModel._TD500
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        m_nNumOfDev = numOfDev
        m_numOfChPerDev = 1

        'ReDim m_Settings(m_nNumOfDev - 1)
        'Dim tempParam(0) As sParams

        'For i As Integer = 0 To m_Settings.Length - 1
        '    m_Settings(i).devID = i
        '    m_Settings(i).numOfCh = 1
        '    m_Settings(i).m_Setting = tempParam.Clone
        'Next

    End Sub


#End Region

#Region "Functions"

    Public Overrides Function DevINFO(ByVal addr As Integer, ByRef sInfo As String) As eReturnCode

        If sendWHO(addr, sInfo) = False Then Return eReturnCode.FuncErr

        Return eReturnCode.OK
    End Function


    Public Function sendWHO(ByVal addr As Integer, ByRef sRetInfo As String) As Boolean
        Dim sRcvData As String = 0
        Dim SendBuf() As Byte
        Dim myUBound As Long = 12

        ReDim SendBuf(myUBound)
        SendBuf(0) = &H2
        SendBuf(1) = Asc(CStr(addr \ 100))
        SendBuf(2) = Asc(CStr((addr Mod 100) \ 10))
        SendBuf(3) = Asc(CStr(addr Mod 10))
        SendBuf(4) = Asc(",")
        SendBuf(5) = Asc("W")
        SendBuf(6) = Asc("H")
        SendBuf(7) = Asc("O")
        SendBuf(8) = Asc(",")

        Chksum(SendBuf)

        SendBuf(myUBound - 1) = &HD
        SendBuf(myUBound) = &HA
        Dim bRcvData() As Byte = Nothing

        S_Step = 1

        Dim nTimeOut As Integer = 0

        Dim sData As String = Nothing

        Do
            If communicator.Communicator.SendToBytes(SendBuf, bRcvData) = False Then Return False

            If nTimeOut > 100 Then Return False

            nTimeOut += 1

        Loop Until DataParsing(bRcvData, sData) = True

        sRetInfo = sData.Clone

        Return True


    End Function
    'Private Function TD500RunStop(ByVal addr As Integer, ByVal nCh As Integer, ByVal sRunStop As Boolean) As Boolean
    '    Dim DReg As String
    '    Dim WriteData As String

    '    If nCh = 1 Then
    '        DReg = sDregisterCh1(2)    '152     
    '    Else
    '        DReg = sDregisterCh2(2)    '153
    '    End If

    '    If sRunStop = True Then
    '        WriteData = sRun
    '        If RandomWrite(addr, DReg, WriteData) = False Then Return False
    '        m_Settings.m_Settings.bIsRun = True
    '    Else
    '        WriteData = sStop
    '        If RandomWrite(addr, DReg, WriteData) = False Then Return False
    '        m_Settings.m_Settings.bIsRun = False
    '    End If

    '    Return True
    'End Function

    Public Overrides Function OperationRun(ByVal addr As Integer) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        DReg = sDregisterCh1(2)

        WriteData = sRUN
        If RandomWrite(addr, DReg, WriteData) = False Then Return False
        'm_Settings(addr).m_Setting(0).bIsRun = True

        Return True
    End Function

    Public Overrides Function OperationRun(ByVal addr As Integer, ByVal nCh As Integer) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        If nCh = 1 Then
            DReg = sDregisterCh1(2)
        Else
            DReg = sDregisterCh2(2)
        End If

        WriteData = sRUN
        If RandomWrite(addr, DReg, WriteData) = False Then Return False
        'm_Settings(addr).m_Setting(nCh).bIsRun = True

        Return True
    End Function

    Public Overrides Function OperationStop(ByVal addr As Integer) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        DReg = sDregisterCh1(2)

        WriteData = sSTOP
        If RandomWrite(addr, DReg, WriteData) = False Then Return False
        'm_Settings(addr).m_Setting(0).bIsRun = False

        Return True
    End Function

    Public Overrides Function OperationStop(ByVal addr As Integer, ByVal nCh As Integer) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        If nCh = 1 Then
            DReg = sDregisterCh1(2)
        Else
            DReg = sDregisterCh2(2)
        End If

        WriteData = sSTOP
        If RandomWrite(addr, DReg, WriteData) = False Then Return False
        'm_Settings(addr).m_Setting(nCh).bIsRun = False

        Return True
    End Function

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal dTemperature As Double) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        DReg = sDregisterCh1(3)   '1000
        WriteData = dTemperature * 10
        If RandomWrite(addr, DReg, WriteData) = False Then Return False
        'm_Settings(addr).m_Setting(nCh).setTemp = dTemperature

        'If nCh = 1 Then
        '    DReg = sDregisterCh1(2)    '152     
        'Else
        '    DReg = sDregisterCh2(2)    '153
        'End If

        'If sRunStop = True Then
        '    WriteData = sRun
        '    If RandomWrite(addr, DReg, WriteData) = False Then Return False

        'Else
        '    WriteData = sStop
        '    If RandomWrite(addr, DReg, WriteData) = False Then Return False

        'End If

        Return True
    End Function

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal nCh As Integer, ByVal sRunStop As Boolean, ByVal dTemperature As Integer) As eReturnCode
        Dim DReg As String
        Dim WriteData As String

        If sRunStop = True Then
            If nCh = 1 Then
                DReg = sDregisterCh1(3)   '1000
                WriteData = dTemperature * 10
                If RandomWrite(addr, DReg, WriteData) = False Then Return False

            Else
                DReg = sDregisterCh2(3)   '1001
                WriteData = dTemperature * 10
                If RandomWrite(addr, DReg, WriteData) = False Then Return False

            End If
        End If

        'm_Settings(addr).m_Setting(nCh).setTemp = dTemperature

        'If nCh = 1 Then
        '    DReg = sDregisterCh1(2)    '152     
        'Else
        '    DReg = sDregisterCh2(2)    '153
        'End If

        'If sRunStop = True Then
        '    WriteData = sRun
        '    If RandomWrite(addr, DReg, WriteData) = False Then Return False

        'Else
        '    WriteData = sStop
        '    If RandomWrite(addr, DReg, WriteData) = False Then Return False

        'End If

        Return True
    End Function


    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef dTemperature As Double) As eReturnCode
        Dim DReg As String

        DReg = sDregisterCh1(0)
        If sendRDR(addr, DReg, dTemperature) = False Then
            Return False
        End If

        'm_Settings(addr).m_Setting(0).measTemp = dTemperature

        Return True
    End Function

    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef dTemperature As CDevTCCommonNode.sParams) As eReturnCode
        Dim DReg As String

        DReg = sDregisterCh1(0)
        If sendRDR(addr, DReg, dTemperature.measTemp) = False Then
            Return False
        End If

        'm_Settings(addr).m_Setting(0).measTemp = dTemperature

        Return True
    End Function

    Private Function sendRDR(ByVal addr As Long, ByVal DReg As String, ByRef Meas1 As Double) As Boolean  'set
        Dim SendBuf() As Byte
        'Dim i As Long
        Dim myUBound As Long
        Dim RCnt As Integer = 1
        Dim bRcvData() As Byte = Nothing

        Dim sRcvData As String = 0
        Dim Temp1 As String = 0
        Dim Temp2 As String = 0

        myUBound = 20
        ReDim SendBuf(myUBound)

        SendBuf(0) = &H2
        SendBuf(1) = Asc(CStr(addr \ 100))
        SendBuf(2) = Asc(CStr((addr Mod 100) \ 10))
        SendBuf(3) = Asc(CStr(addr Mod 10))
        SendBuf(4) = Asc(",")
        SendBuf(5) = Asc("R")
        SendBuf(6) = Asc("D")
        SendBuf(7) = Asc("R")
        SendBuf(8) = Asc(",")
        SendBuf(9) = Asc(CStr(RCnt \ 10))
        SendBuf(10) = Asc(CStr(RCnt Mod 10))
        SendBuf(11) = Asc(",")
        SendBuf(12) = Asc(CStr(DReg \ 1000))
        SendBuf(13) = Asc(CStr((DReg Mod 1000) \ 100))
        SendBuf(14) = Asc(CStr((DReg Mod 100) \ 10))
        SendBuf(15) = Asc(CStr(DReg Mod 10))
        SendBuf(16) = Asc(",")

        Chksum(SendBuf)

        SendBuf(myUBound - 1) = &HD
        SendBuf(myUBound) = &HA



        'If CPort.WriteToByte(SendBuf) = False Then
        '    Return False
        'End If

        Dim nTimeOut As Integer = 0

        Dim sData As String = Nothing

        Do
            If communicator.Communicator.SendToBytes(SendBuf, bRcvData) = False Then Return False

            If nTimeOut > 100 Then Return False

            nTimeOut += 1

        Loop Until DataParsing(bRcvData, sData) = True

        Dim arrTemp As Array
        Dim sHexVal As String
        Dim sDecVal As String

        Try
            arrTemp = Split(sData, ",", -1)

            sHexVal = arrTemp(3)

            sDecVal = sHex2Dec(sHexVal)
        Catch ex As Exception
            Return False
        End Try


        '  frmRWDR.txtRWvalue(k).Text = Format(Val("&H" & Chr(bRBuf(12 + k * 5)) & Chr(bRBuf(13 + k * 5)) & Chr(bRBuf(14 + k * 5)) & Chr(bRBuf(15 + k * 5))) / (10 ^ myDP), myFormat)


        'S_Step = 10

        'If CPort.SendToBytes(SendBuf, bRcvData) = False Then
        '    Return False
        'End If

        'DataParsing(bRcvData, bReRcvData)

        '21-41
        'ReDim bReRcvData(20)
        'Dim j As Integer = 0
        'For i As Integer = 21 To 41
        '    bReRcvData(j) = bRcvData(i)
        '    j = j + 1
        'Next
        'Dim cstr1 As String = bReRcvData(12)
        'Dim cstr2 As String = bReRcvData(13)
        'Dim cstr3 As String = bReRcvData(14)
        'Dim cstr4 As String = bReRcvData(15)

        'Dim dCstring As String
        'Dim dCstring1 As String
        'Dim dCstring2 As String

        'dCstring = "&H" & cstr1 & cstr2 & cstr3 & cstr4

        'dCstring = CDec(dCstring)
        'dCstring1 = dCstring.Substring(0, 5) 'dCstring.Substring(0, 2) & "." & dCstring.Substring(2, 4)

        'dCstring = CDbl(dCstring1) + CDbl(dCstring2)

        'MeasParse(sRcvData, Temp1, Temp2)

        ' Meas1 = bReRcvData

        'Meas1 = Temp1.Clone()
        'Meas2 = Temp2.Clone()

        Meas1 = CDbl(sDecVal) / 10

        Return True
    End Function


    Private Function sHex2Dec(ByVal sHex As String) As String
        Dim i As Long
        Dim sDigit As String
        Dim DigitVal As Long
        Dim CalcVal As Long
        Dim MinusF As Boolean

        For i = 1 To Len(sHex)
            sDigit = Mid(sHex, i, 1)
            Select Case sDigit
                Case "A"
                    DigitVal = 10
                Case "B"
                    DigitVal = 11
                Case "C"
                    DigitVal = 12
                Case "D"
                    DigitVal = 13
                Case "E"
                    DigitVal = 14
                Case "F"
                    DigitVal = 15
                Case Else
                    DigitVal = Val(sDigit)
            End Select

            If i = 1 And DigitVal >= 8 Then
                MinusF = True
            End If

            CalcVal = CalcVal + (DigitVal * (16 ^ (Len(sHex) - i)))
        Next i
        If MinusF = True Then
            CalcVal = -(65536 - CalcVal)
        End If
        sHex2Dec = CStr(CalcVal)
    End Function

    Private Function RandomWrite(ByVal addr As Long, ByVal DReg As String, ByVal WriteData As String) As Boolean ', Val temp As Integer) As Boolean 'ByVal DReg As Long, ByVal WCnt As Long, ByVal WData As Object)
        Dim SendBuf() As Byte
        Dim bRcvData() As Byte = Nothing
        'Dim i As Long
        Dim myUBound As Long
        Dim sHex As String
        Dim WCnt As Integer = 1

        myUBound = 20 + (WCnt * 5)
        ReDim SendBuf(myUBound)

        SendBuf(0) = &H2
        SendBuf(1) = Asc(CStr(addr \ 100))
        SendBuf(2) = Asc(CStr((addr Mod 100) \ 10))
        SendBuf(3) = Asc(CStr(addr Mod 10))
        SendBuf(4) = Asc(",")
        SendBuf(5) = Asc("W")
        SendBuf(6) = Asc("R")
        SendBuf(7) = Asc("D")
        SendBuf(8) = Asc(",")
        SendBuf(9) = Asc(CStr(WCnt \ 10))
        SendBuf(10) = Asc(CStr(WCnt Mod 10))
        SendBuf(11) = Asc(",")
        SendBuf(12) = Asc(DReg \ 1000)
        SendBuf(13) = Asc((DReg Mod 1000) \ 100)
        SendBuf(14) = Asc((DReg Mod 100) \ 10)
        SendBuf(15) = Asc(DReg Mod 10)
        SendBuf(16) = Asc(",")
        'SendBuf(17) = Asc(WriteData \ 1000)
        'SendBuf(18) = Asc((WriteData Mod 1000) \ 100)
        'SendBuf(19) = Asc((WriteData Mod 100) \ 10)
        'SendBuf(20) = Asc(WriteData Mod 10)
        'SendBuf(21) = Asc(",")
        'Chksum(SendBuf)

        sHex = Dec2Hex(CLng(WriteData), 4)
        SendBuf(17) = Asc(Mid(sHex, 1, 1))
        SendBuf(18) = Asc(Mid(sHex, 2, 1))
        SendBuf(19) = Asc(Mid(sHex, 3, 1))
        SendBuf(20) = Asc(Mid(sHex, 4, 1))
        SendBuf(21) = Asc(",")
        Chksum(SendBuf)

        SendBuf(myUBound - 1) = &HD
        SendBuf(myUBound) = &HA

        If communicator.Communicator.SendToBytes(SendBuf, bRcvData) = False Then Return False

        'If CPort.SendToBytes(SendBuf, sRcvData) = False Then
        '    Return False
        'End If

        ''SendCommand(SendBuf)
        'If chkRcvData(sRcvData) = False Then
        '    Return False
        'End If

        Application.DoEvents()
        Thread.Sleep(500)

        Return True
    End Function

    Private Sub Chksum(ByRef addChkData As Object)
        Dim i As Long
        Dim chksum As Long

        For i = 1 To UBound(addChkData) - 4
            chksum = chksum + addChkData(i)
        Next i
        chksum = chksum Mod 256

        addChkData(UBound(addChkData) - 3) = Asc(Hex(chksum \ 16))
        addChkData(UBound(addChkData) - 2) = Asc(Hex(chksum Mod 16))
    End Sub

    Private Function Dec2Hex(ByVal sDec As Long, ByVal HexSize As Long) As String
        Dim i As Long
        Dim sHex As String
        Dec2Hex = Nothing

        If sDec < 0 Then
            sDec = 65536 + sDec
        End If

        sHex = Hex(sDec)

        For i = Len(sHex) + 1 To HexSize
            Dec2Hex = Dec2Hex & "0"
        Next i
        Dec2Hex = Dec2Hex & sHex
    End Function

    'Private Function chkRcvData(ByRef sRcvData As String) As Boolean

    '    Dim ack As String
    '    Dim doexit As Boolean

    '    Dim nTimeOut As Integer

    '    doexit = False

    '    Do
    '        Application.DoEvents()
    '        Thread.Sleep(5)

    '        SyncLock m_rcvQueue.SyncRoot

    '            If m_rcvQueue.Count <> 0 Then
    '                ack = m_rcvQueue.Dequeue()
    '                doexit = True
    '            End If

    '        End SyncLock

    '        If doexit Then
    '            Exit Do
    '        End If

    '        nTimeOut = nTimeOut + 1

    '        If nTimeOut > 1000 Then
    '            Return False
    '        End If

    '    Loop

    '    sRcvData = ack.Clone()

    '    Return True

    'End Function

    Private Function MeasParse(ByVal in_Data As String, ByRef Out_Temp1 As String, ByRef Out_Temp2 As String) As Boolean
        MeasParse = False

        Dim i As Long
        Dim j As Long
        Dim sDigit As String
        Dim DigitVal As Long
        Dim CalcVal As Long = 0
        Dim TempData As Array

        TempData = in_Data.Split(in_Data, ",", -1)

        'If TempData Is Nothing = False Then
        '    Return False
        'End If

        For j = 0 To 1
            For i = 1 To Len(TempData(3 + j))
                sDigit = Mid(TempData(3 + j), i, 1)
                Select Case sDigit
                    Case "A"
                        DigitVal = 10
                    Case "B"
                        DigitVal = 11
                    Case "C"
                        DigitVal = 12
                    Case "D"
                        DigitVal = 13
                    Case "E"
                        DigitVal = 14
                    Case "F"
                        DigitVal = 15
                    Case Else
                        DigitVal = Val(sDigit)
                End Select
                CalcVal = CalcVal + (DigitVal * (16 ^ (Len(TempData(3 + j)) - i)))
            Next i
            If j = 0 Then
                Out_Temp1 = CalcVal / 10
                CalcVal = 0
            ElseIf j = 1 Then
                Out_Temp2 = CalcVal / 10
                CalcVal = 0
            End If
        Next j

        Return True
    End Function




    Dim bRCnt As Long
    Dim bRBuf() As Byte
    Dim S_Step As Long
    Public WRegCount As Long = 10
    Public WRegList() As Long
    Public WDataList() As Long
    Public SCR_FrameNo As Long
    Public ScreenVal(0 To 76799) As Byte


    Public Function DataParsing(ByVal retByte() As Byte, ByRef bReRcvData As String) As Boolean
        Dim RBuf() As Byte
        Dim Ridx As Integer

        Dim k As Long
        Dim CMD As String
        Dim RegNo As Long
        Dim longVal As Long
        Dim RunTime As String
        Dim strCur As String
        Dim strTot As String
        Dim PreSize As Long
        Dim mylng As Long
        Dim wrfilename As String
        Dim sPTNname(0 To 29) As Byte
        Dim myDP As Long
        Dim myFormat As String

        Dim send As String = Nothing

        Dim idxStart As Integer = -1
        Dim idxEnd As Integer = -1
        Dim totalLen As Integer
        Dim bDatas() As Byte
        Dim sDatas As String = ""

        ReDim WRegList(0 To 0)

        On Error GoTo ErrProc

        RBuf = retByte

        Ridx = UBound(RBuf)

        For i As Integer = 0 To RBuf.Length - 1
            Select Case RBuf(i)

                Case 2   'STX
                    idxStart = i
                Case 10   'LF
                    If RBuf(i - 1) <> 13 Then Return False 'CR을 확인해서 없으면 무시
                    idxEnd = i
            End Select
        Next

        If idxStart < 0 Or idxEnd < 0 Then Return False
        If idxEnd < idxStart Then Return False '완전한 데이터가 없는 것으로 간주.

        totalLen = idxEnd - idxStart

        ReDim bDatas(totalLen - 1)
        Dim bDatas1(totalLen - 3) As Byte

        Array.Copy(RBuf, idxStart, bDatas, 0, totalLen)

        Array.Copy(bDatas, 1, bDatas1, 0, totalLen - 3)

        'Check_Chksum()

        For i As Integer = 0 To bDatas.Length - 1
            sDatas = sDatas & Convert.ToChar(bDatas(i))
        Next

        'For i = 0 To Ridx
        '    Select Case RBuf(i)

        '        Case 2 'STX
        '            bRCnt = 1
        '            ReDim bRBuf(0 To bRCnt - 1) 'As Byte

        '            bRBuf(0) = RBuf(i)
        '        Case 10
        '            bRCnt = bRCnt + 1
        '            ReDim Preserve bRBuf(0 To bRCnt - 1) 'As Byte

        '            bRBuf(bRCnt - 1) = RBuf(i)


        '            If bRBuf.Length < 21 Then
        '                Exit Function
        '            End If

        '            If Check_Chksum(bRBuf) = True Then
        '                'objRX_TOver.Enabled = False
        '                'lblMSG = ""

        '                'If InStr(StrConv(bRBuf, vbUnicode), "OK") > 0 Then
        '                'Else
        '                '    Exit For
        '                'End If

        '                Select Case S_Step
        '                    Case 1
        '                        'If InStr(StrConv(bRBuf, vbUnicode), "TD500") > 0 Then
        '                        'lblWHO = StrConv(bRBuf, vbUnicode)
        '                        '    S_Step = 0
        '                        'End If
        '                    Case 10
        '                        ' For k = 0 To WRegCount - 1

        '                        WRegList(0) = sDregisterCh1(0)

        '                        myDP = GetDP(WRegList(0) + k)
        '                        myFormat = GetFormat(myDP)

        '                        'frmRWDR.txtRWvalue(k).Text
        '                        send = Format(Val("&H" & Chr(bRBuf(12 + k * 5)) & Chr(bRBuf(13 + k * 5)) & Chr(bRBuf(14 + k * 5)) & Chr(bRBuf(15 + k * 5))) / (10 ^ myDP), myFormat)
        '                        ' Next k
        '                        S_Step = 0
        '                    Case 110
        '                        S_Step = 0
        '                    Case 20
        '                        For k = 0 To WRegCount - 1
        '                            myDP = GetDP(WRegList(k))
        '                            myFormat = GetFormat(myDP)
        '                            'frmRWRD.txtRWvalue(k).Text = Format(Val("&H" & Chr(bRBuf(12 + k * 5)) & Chr(bRBuf(13 + k * 5)) & Chr(bRBuf(14 + k * 5)) & Chr(bRBuf(15 + k * 5))) / (10 ^ myDP), myFormat)
        '                        Next k
        '                        S_Step = 0
        '                    Case 120
        '                        S_Step = 0
        '                    Case 80
        '                        For k = 0 To 99
        '                            If Val(Chr(bRBuf(12 + k * 2))) > 0 Then
        '                                'frmRPI2.lblPtnOX(k).BackColor = &HFF00&
        '                            Else
        '                                'frmRPI2.lblPtnOX(k).BackColor = &H8000000F
        '                            End If
        '                        Next k
        '                        S_Step = 0
        '                    Case 81
        '                        'frmPattern.txtPtnData(0).Text = Val("&H" & Chr(bRBuf(12)) & Chr(bRBuf(13)))
        '                        'frmPattern.txtPtnData(1).Text = Val("&H" & Chr(bRBuf(15)) & Chr(bRBuf(16)))
        '                        'frmPattern.txtPtnData(2).Text = Val("&H" & Chr(bRBuf(18)) & Chr(bRBuf(19)))
        '                        'frmPattern.txtPtnData(3).Text = Val("&H" & Chr(bRBuf(21)) & Chr(bRBuf(22)))
        '                        'frmPattern.txtPtnData(4).Text = Val("&H" & Chr(bRBuf(24)) & Chr(bRBuf(25)) & Chr(bRBuf(26)) & Chr(bRBuf(27)))
        '                        'frmPattern.txtPtnData(5).Text = Format(Val("&H" & Chr(bRBuf(29)) & Chr(bRBuf(30)) & Chr(bRBuf(31)) & Chr(bRBuf(32))) / 10, "0.0")
        '                        'frmPattern.txtPtnData(6).Text = Val("&H" & Chr(bRBuf(34)) & Chr(bRBuf(35)))
        '                        'frmPattern.txtPtnData(7).Text = Val("&H" & Chr(bRBuf(37)) & Chr(bRBuf(38)))
        '                        'frmPattern.txtPtnData(8).Text = Format(Val("&H" & Chr(bRBuf(40)) & Chr(bRBuf(41)) & Chr(bRBuf(42)) & Chr(bRBuf(43))) / 10, "0.0")
        '                        'frmPattern.txtPtnData(9).Text = Format(Val("&H" & Chr(bRBuf(45)) & Chr(bRBuf(46)) & Chr(bRBuf(47)) & Chr(bRBuf(48))) / 10, "0.0")
        '                        For k = 0 To 29
        '                            sPTNname(k) = CByte(Val("&H" & Chr(bRBuf(50 + k * 2)) & Chr(bRBuf(51 + k * 2))))
        '                        Next k
        '                        'frmPattern.txtPtnData(10).Text = StrConv(sPTNname, vbUnicode)

        '                        For k = 0 To 19
        '                            'frmPattern.txtPtnSSeg(k).Text = Val("&H" & Chr(bRBuf(111 + k * 7)) & Chr(bRBuf(112 + k * 7)))
        '                            'frmPattern.txtPtnESeg(k).Text = Val("&H" & Chr(bRBuf(113 + k * 7)) & Chr(bRBuf(114 + k * 7)))
        '                            'frmPattern.txtPtnLRept(k).Text = Val("&H" & Chr(bRBuf(115 + k * 7)) & Chr(bRBuf(116 + k * 7)))
        '                        Next k

        '                        S_Step = 0
        '                    Case 181
        '                        S_Step = 0
        '                    Case 82
        '                        'frmSegment.txtSegData(0).Text = Format(Val("&H" & Chr(bRBuf(12)) & Chr(bRBuf(13)) & Chr(bRBuf(14)) & Chr(bRBuf(15))) / 10, "0.0")
        '                        'frmSegment.txtSegData(1).Text = Format(Val("&H" & Chr(bRBuf(17)) & Chr(bRBuf(18)) & Chr(bRBuf(19)) & Chr(bRBuf(20))) / 10, "0.0")
        '                        'frmSegment.txtSegData(2).Text = Val("&H" & Chr(bRBuf(22)) & Chr(bRBuf(23)))
        '                        'frmSegment.txtSegData(3).Text = Val("&H" & Chr(bRBuf(25)) & Chr(bRBuf(26)))
        '                        'frmSegment.txtSegData(4).Text = Val("&H" & Chr(bRBuf(28)) & Chr(bRBuf(29)))
        '                        'frmSegment.txtSegData(5).Text = Val("&H" & Chr(bRBuf(31)) & Chr(bRBuf(32)))
        '                        For k = 0 To 7
        '                            'frmSegment.txtTS_Mode(k).Text = Val("&H" & Chr(bRBuf(34 + k * 11)) & Chr(bRBuf(35 + k * 11)))
        '                            'frmSegment.txtDelay_H(k).Text = Val("&H" & Chr(bRBuf(36 + k * 11)) & Chr(bRBuf(37 + k * 11)))
        '                            'frmSegment.txtDelay_M(k).Text = Val("&H" & Chr(bRBuf(38 + k * 11)) & Chr(bRBuf(39 + k * 11)))
        '                            'frmSegment.txtHold_H(k).Text = Val("&H" & Chr(bRBuf(40 + k * 11)) & Chr(bRBuf(41 + k * 11)))
        '                            'frmSegment.txtHold_M(k).Text = Val("&H" & Chr(bRBuf(42 + k * 11)) & Chr(bRBuf(43 + k * 11)))
        '                        Next k

        '                        S_Step = 0
        '                    Case 182
        '                        S_Step = 0
        '                    Case 90 'Current Screen Read
        '                        Select Case SCR_FrameNo
        '                            Case 999
        '                                SCR_FrameNo = 0

        '                                'MSComm1.InBufferCount = 0
        '                            Case Else
        '                                'frmRCS.ProgressBar1.Value = (SCR_FrameNo + 1) / 600 * 100
        '                                For k = 0 To 127
        '                                    ScreenVal(SCR_FrameNo * 128 + k) = Val("&H" & Chr(bRBuf(k * 2 + 12)) & Chr(bRBuf(k * 2 + 13)))
        '                                Next k

        '                                SCR_FrameNo = SCR_FrameNo + 1
        '                                If SCR_FrameNo = 600 Then
        '                                    S_Step = 0
        '                                    ' frmRCS.lblComplete.Visible = True

        '                                    'wrfilename = App.Path & "\DispScr.BMP"

        '                                    'Call Save_Screen(ScreenVal, wrfilename)
        '                                    'frmRCS.Picture1.Picture = LoadPicture(wrfilename)
        '                                    '
        '                                    'frmRCS.btnRefresh.Enabled = True
        '                                    'frmRCS.btnSave.Enabled = True
        '                                Else
        '                                    'MSComm1.InBufferCount = 0
        '                                End If
        '                        End Select
        '                    Case 99 'Logo Read
        '                        'frmRLG.ProgressBar1.Value = (SCR_FrameNo + 1) / 600 * 100
        '                        For k = 0 To 127
        '                            ScreenVal(SCR_FrameNo * 128 + k) = Val("&H" & Chr(bRBuf(k * 2 + 12)) & Chr(bRBuf(k * 2 + 13)))
        '                        Next k

        '                        SCR_FrameNo = SCR_FrameNo + 1
        '                        If SCR_FrameNo = 600 Then
        '                            S_Step = 0
        '                            'frmRLG.lblComplete.Visible = True

        '                            'wrfilename = App.Path & "\myLogo.BMP"

        '                            'Call Save_Screen(ScreenVal, wrfilename)
        '                            'frmRLG.Picture1.Picture = LoadPicture(wrfilename)
        '                            '
        '                            'frmRLG.btnRefresh.Enabled = True
        '                            'frmRLG.btnSave.Enabled = True
        '                        Else
        '                            'MSComm1.InBufferCount = 0
        '                        End If
        '                    Case 199 'Logo Write
        '                        Select Case SCR_FrameNo
        '                            Case 999
        '                                'MSComm1.InBufferCount = 0
        '                                'frmWLG.btnLoad.Enabled = True
        '                                'frmWLG.btnSend.Enabled = True
        '                                'frmWLG.lblComplete.Visible = True
        '                                S_Step = 0
        '                            Case Else
        '                                'frmWLG.ProgressBar1.Value = (SCR_FrameNo + 1) / 600 * 100

        '                                SCR_FrameNo = SCR_FrameNo + 1
        '                                If SCR_FrameNo = 600 Then
        '                                    SCR_FrameNo = 999
        '                                End If
        '                        End Select
        '                End Select
        '            Else
        '                'lblMSG = "통신상태 불량"
        '            End If
        '            Exit For
        '        Case Else

        '            bRCnt = bRCnt + 1
        '            ReDim Preserve bRBuf(0 To bRCnt - 1) 'As Byte

        '            bRBuf(bRCnt - 1) = RBuf(i)
        '    End Select
        'Next i


        If S_Step > 0 Then
            'tmrTX.Enabled = True
        End If


        bReRcvData = sDatas
        'bReRcvData = bRBuf

        Return True

ErrProc:
        Return False

    End Function

    Public Function Check_Chksum(ByVal chkData As Object) As Boolean
        Dim i As Long
        Dim chksum As Long
        Dim chksum_R As Long
        Dim ChkRST As Boolean


        For i = 1 To UBound(chkData) - 4
            chksum = chksum + chkData(i)
        Next i

        chksum_R = CRC2Dec(Chr(chkData(UBound(chkData) - 3))) * 16 + CRC2Dec(Chr(chkData(UBound(chkData) - 2)))


        If (chksum Mod 256) = chksum_R Then
            ChkRST = True
        Else
            ChkRST = False
        End If

        Check_Chksum = ChkRST
    End Function


    Public Function GetDP(ByVal RegNo As Long) As Long
        Select Case RegNo
            Case 126 To 135, 1000 To 1001, 1007 To 1010, 1062 To 1071, 1094 To 1095, 1110 To 1113, 1116 To 1119, _
                 1132, 1133, 1137, 1140, 1141, 1145, 1148, 1149, 1153, 1156, 1157, 1161, _
                 1164, 1165, 1169, 1172, 1173, 1177, 1180, 1181, 1185, 1188, 1189, 1193, _
                 1203, 1204, 1207, 1208, 1211, 1212, 1215, 1216, _
                 1120 To 1283, 1534, 1535, 1538, 1539, 1800 To 1815
                GetDP = 1
            Case Else
                GetDP = 0
        End Select

    End Function

    Public Function GetFormat(ByVal DP_No As Long) As String
        Dim myFormat As String
        Dim i As Long

        myFormat = "0"
        If DP_No > 0 Then
            myFormat = myFormat & "."
            For i = 1 To DP_No
                myFormat = myFormat & "0"
            Next i
        End If
        GetFormat = myFormat
    End Function

    Public Function CRC2Dec(ByVal sHex As String) As Long
        Dim i As Long
        Dim sDigit As String
        Dim DigitVal As Long
        Dim CalcVal As Long

        For i = 1 To Len(sHex)
            sDigit = Mid(sHex, i, 1)
            Select Case sDigit
                Case "A"
                    DigitVal = 10
                Case "B"
                    DigitVal = 11
                Case "C"
                    DigitVal = 12
                Case "D"
                    DigitVal = 13
                Case "E"
                    DigitVal = 14
                Case "F"
                    DigitVal = 15

                Case Else
                    DigitVal = Val(sDigit)
            End Select
            CalcVal = CalcVal + (DigitVal * (16 ^ (Len(sHex) - i)))
        Next i
        CRC2Dec = CalcVal
    End Function

#End Region

  

End Class
