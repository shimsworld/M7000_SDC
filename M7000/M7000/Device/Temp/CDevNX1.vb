Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib

Public Class CDevNX1
    Inherits CDevTCCommonNode
    Dim communicator As CComAPI

#Region "Define"
    Dim m_nNumOfDev As Integer
    Dim m_numOfChPerDev As Integer


#Region "Thermometer(NX_Series) Command Set"

    Public Const NX1_GET_INFO = "WHO"

    Public Const NX1_GET_TEMP = "DRS,02,0001"

    Public Const NXx_TEMP_VALUE_RATE = 10

    Public Const stx As String = Chr(&H2)



    '데이터 커맨드는 아래의 두가지중 어떤것을 보내도 상관 없음
    'Public Const NX1_GET_TEMP = Chr(&H2) & Chr(&H30) & Chr(&H31) & Chr(&H44) & Chr(&H52) & Chr(&H53) & Chr(&H2C) & Chr(&H30) & Chr(&H31) & Chr(&H2C) & Chr(&H30) & Chr(&H30) & Chr(&H30) & Chr(&H31) ' & Chr(&HD) & Chr(&HA)
    'Public Const NX1_GET_TEMP = Chr(&H2) & "01DRS,01,0001"
    '
    'STX/01/DRS/,/01/,/0001/CR/LF

#End Region

#End Region

#Region "Properties"

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

#Region "Create, Dispose And Init"

    Public Sub New(ByVal numOfDev As Integer)
        MyBase.New()
        m_MyModel = eModel._NX1
        m_nNumOfDev = numOfDev
        m_numOfChPerDev = 1
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub

    Public Overrides Sub Dispose()
        communicator = Nothing
    End Sub

#End Region

#Region "Communication"

    Public Overloads Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean
        Dim strTempCommand As String = ""
        Dim strRetData As String = ""


        If communicator.Communicator.Connect(Config) = False Then
            m_bIsConnected = False
            Return False
        End If
        m_bIsConnected = True
        Return True
    End Function

    Public Overloads Sub Disconnection()
        communicator.Communicator.Disconnect()
    End Sub

    Public Function GetDevInfo(ByVal addr As Integer, ByRef sDevInfo As String) As Boolean

        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""
        '  Dim sDevInfo As String = ""

        strAddr = Format(addr + 1, "00")

        sCommand = stx & strAddr & NX1_GET_INFO

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            sDevInfo = sRcvMsg.Clone
        Else
            Return False
        End If
        'If SendCommand(sCommand, sRcvMsg) = True Then
        '    sDevInfo = sRcvMsg.Clone()
        'Else
        '    Return False
        'End If

        Return sDevInfo
    End Function

#End Region

#Region "Set/Get Temperature"

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal temperature As Double) As eReturnCode

        Dim sHexTemp As String
        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        ' If g_bIsConnected = False Then Return False

        temperature = temperature * 10

        If temperature < 0 Then
            temperature = temperature + 65536
        End If

        sHexTemp = Dec2Hex(CLng(temperature), 4)

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DWS" & ",02,0300,0001," & sHexTemp

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvMsg) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef dCurrTemp As Double, ByRef dSetTemp As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""


        'If g_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        sCommand = stx & strAddr & NX1_GET_TEMP  '& vbCrLf

        If communicator.Communicator.SendToString(sCommand, strRecv) = CComCommonNode.eReturnCode.OK Then
            If NX_ReadData_Parse(strRecv, dCurrTemp, dSetTemp) = False Then
                dCurrTemp = -100
                dSetTemp = -100
                Return False
            End If
        Else
            Return False
        End If

        'If SendCommand(sCommand, strRecv) = True Then
        '    If NX_ReadData_Parse(strRecv, dCurrTemp, dSetTemp) = False Then
        '        dCurrTemp = -100
        '        dSetTemp = -100
        '        Return False
        '    End If
        'Else
        '    Return False
        'End If
        Return True
    End Function

    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef RcvData As CDevTCCommonNode.sParams) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""

        Dim dCurrTemp As Double = Nothing
        Dim dSetTemp As Double = Nothing

        'If g_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        sCommand = stx & strAddr & NX1_GET_TEMP  '& vbCrLf

        If communicator.Communicator.SendToString(sCommand, strRecv) = True Then
            If NX_ReadData_Parse(strRecv, dCurrTemp, dSetTemp) = False Then
                dCurrTemp = -100
                dSetTemp = -100
                Return False
            End If
        Else
            Return False
        End If

        RcvData.measTemp = dCurrTemp
        RcvData.setTemp = dSetTemp

        'If SendCommand(sCommand, strRecv) = True Then
        '    If NX_ReadData_Parse(strRecv, dCurrTemp, dSetTemp) = False Then
        '        dCurrTemp = -100
        '        dSetTemp = -100
        '        Return False
        '    End If
        'Else
        '    Return False
        'End If
        Return True
    End Function

    Public Function SetLamp(ByVal addr As Integer, ByVal in_GoalTemp As Double, ByVal in_IncreaTemp As Double, ByVal in_IncreaTime As Double) As Boolean
        Dim strAddr As String
        Dim strSend As String
        Dim strRecv As String = ""
        Dim sHexValue As String

        'If g_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        '순서가 중요함

        '1
        '[Cmd:]    STX        Addr      Cmd   ,갯수,D Register,   Data                    
        'strSend = Chr(&H2) + strAddr + "DWS" + ",01,0108,0032" '+ strValueHex(in_IncreaTemp)
        sHexValue = Dec2Hex(CLng(in_IncreaTemp), 4)
        strSend = stx & strAddr & "DWS" & ",01,0108," & sHexValue
        If communicator.Communicator.SendToString(strSend, strRecv) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(strSend, strRecv) = False Then
        '    Return False
        'End If


        '2
        '[Cmd:]    STX        Addr      Cmd   ,갯수,D Register,   Data                    
        'strSend = Chr(&H2) + strAddr + "DWS" + ",01,0110,0001" '+ strValueHex(in_IncreaTime)
        sHexValue = Dec2Hex(CLng(in_IncreaTime), 4)
        strSend = stx & strAddr & "DWS" & ",01,0110," & sHexValue
        If communicator.Communicator.SendToString(strSend, strRecv) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(strSend, strRecv) = False Then
        '    Return False
        'End If

        '3
        '[Cmd:]    STX        Addr      Cmd   ,갯수,D Register,   Data                    
        'strSend = Chr(&H2) + strAddr + "DWS" + ",02,0300,0001," + strValueHex(in_GoalTemp)
        sHexValue = Dec2Hex(CLng(in_GoalTemp), 4)
        strSend = stx & strAddr & "DWS" & ",02,0300,0001," & sHexValue
        If communicator.Communicator.SendToString(strSend, strRecv) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(strSend, strRecv) = False Then
        '    Return False
        'End If

        Return True
    End Function


    'Alarm

    Public Enum eAlarmCode
        eHigh_ABS_Value
        eLow_ABS_Value
        eHigh_DEV_Value
        eLow_DEV_Value
        eHigh_DEV_Value_INV
        eLow_DEV_Value_INV
        eHigh_Low_DEV_Value
        eHigh_LowBand
        eHigh_ABS_INV
        eLow_ABS_INV
        eHigh_ABS_N_Hold
        eLow_ABS_N_Hold
        eHigh_DEV_N_Hold
        eLow_DEV_N_Hold
        eHigh_DEV_N_Hold_INV
        eLow_DEV_N_Hold_INV
        eHigh_Low_DEV_N_Hold
        eHigh_LowBand_N_Hold
        eHigh_ABS_Value_N_Hold
        eLow_ABS_Value_N_Hold
        eHeater_Break_Alarm1
    End Enum

    Public sAlarmTypes() As String = New String() {"High_ABS_Value",
        "Low_ABS_Value",
        "High_DEV_Value",
        "Low_DEV_Value",
        "High_DEV_Value_INV",
        "Low_DEV_Value_INV",
        "High_Low_DEV_Value",
        "High_LowBand",
        "High_ABS_INV",
        "Low_ABS_INV",
        "High_ABS_N_Hold",
        "Low_ABS_N_Hold",
        "High_DEV_N_Hold",
        "Low_DEV_N_Hold",
        "High_DEV_N_Hold_INV",
        "Low_DEV_N_Hold_INV",
        "High_Low_DEV_N_Hold",
        "High_LowBand_N_Hold",
        "High_ABS_Value_N_Hold",
        "Low_ABS_Value_N_Hold",
        "Heater_Break_Alarm1"}

    Public Function SetAlarm1Type(ByVal addr As Integer, ByVal alarmCode As Integer) As Boolean

        Dim sHexValue As String
        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        alarmCode = alarmCode + 1

        If m_bIsConnected = False Then Return False

        sHexValue = Dec2Hex(CLng(alarmCode), 4)

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DWS" & ",01,0410," & sHexValue

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True

    End Function

    Public Function SetAlarm2Type(ByVal addr As Integer, ByVal alarmCode As Integer) As Boolean

        Dim sHexValue As String
        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        alarmCode = alarmCode + 1

        If m_bIsConnected = False Then Return False

        sHexValue = Dec2Hex(CLng(alarmCode), 4)

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DWS" & ",01,0411," & sHexValue

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True

    End Function

    Public Function SetAlarm1DeadBand(ByVal addr As Integer, ByVal dDeadBand As Double) As Boolean

        Dim sHexValue As String
        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        If dDeadBand < 0 Or dDeadBand > 100 Then Return False

        dDeadBand = dDeadBand * 10

        sHexValue = Dec2Hex(CLng(dDeadBand), 4)

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DWS" & ",01,0413," & sHexValue

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvMsg) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function SetAlarm1Value(ByVal addr As Integer, ByVal dValue As Double) As Boolean

        Dim sHexValue As String
        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        If dValue < -100 Or dValue > 100 Then Return False

        dValue = dValue * 10

        sHexValue = Dec2Hex(CLng(dValue), 4)

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DWS" & ",01,0416," & sHexValue

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvMsg) = False Then
        '    Return False
        'End If

        Return True

    End Function


    Public Function GetAlarm1Type(ByVal addr As Integer, ByRef alarmCode As Integer) As Boolean

        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DRS" & ",01,0410"

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            If NX_ReadData_Parse(sRcvMsg, alarmCode) = False Then
                Return False
            End If
            ' alarmCode = alarmCode
        End If

        Return True

    End Function

    Public Function GetAlarm2Type(ByVal addr As Integer, ByRef alarmCode As Integer) As Boolean

        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DRS" & ",01,0411"

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            If NX_ReadData_Parse(sRcvMsg, alarmCode) = False Then
                Return False
            End If
            ' alarmCode = alarmCode - 1
        End If

        Return True

    End Function

    Public Function GetAlarm1DeadBand(ByVal addr As Integer, ByRef dDeadBand As Double) As Boolean

        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DRS" & ",01,0413"

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            If NX_ReadData_Parse(sRcvMsg, dDeadBand) = False Then
                Return False
            End If
            dDeadBand = dDeadBand / NXx_TEMP_VALUE_RATE
        End If
        'If SendCommand(sCommand, sRcvMsg) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function GetAlarm1Value(ByVal addr As Integer, ByRef dValue As Double) As Boolean

        Dim sCommand As String
        Dim strAddr As String
        Dim sRcvMsg As String = ""

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr + 1, "00")

        '[Cmd:]            Addr      Cmd   ,갯수,D Register,   Data                    
        sCommand = stx & strAddr & "DRS" & ",01,0416"

        'Send + Recv
        If communicator.Communicator.SendToString(sCommand, sRcvMsg) = CComCommonNode.eReturnCode.OK Then
            If NX_ReadData_Parse(sRcvMsg, dValue) = False Then
                Return False
            End If

            dValue = dValue / NXx_TEMP_VALUE_RATE
        End If
        'If SendCommand(sCommand, sRcvMsg) = False Then
        '    Return False
        'End If

        Return True

    End Function


#End Region

#Region "Data Proc"
    Private Function Dec2Hex(ByVal sDec As Long, ByVal HexSize As Long) As String
        Dim i As Long
        Dim sHex As String
        Dim sHexDigit As String = ""

        If sDec < 0 Then
            sDec = 65536 + sDec
        End If

        sHex = Hex(sDec)

        For i = Len(sHex) + 1 To HexSize
            sHexDigit = sHexDigit & "0"
        Next i
        sHex = sHexDigit & sHex

        Return sHex
    End Function

    ' Public ReadCH_Temperature_Value As Double

    Private Function NX_ReadData_Parse(ByVal in_RcvData As String, ByRef currTemp As Double, ByRef setTemp As Double) As Boolean

        Dim readBuff() As String
        Dim sCurrTemp As String
        Dim sSetTemp As String
        Dim ConvDec As Long
        'Dim bStatus As Boolean
        'Dim iCh As Integer

        in_RcvData = in_RcvData.TrimEnd("")
        in_RcvData = in_RcvData.TrimEnd(vbLf)
        in_RcvData = in_RcvData.TrimEnd(vbCr)

        If in_RcvData <> "" Then

            Try

                ReDim readBuff(5)

                readBuff = Split(in_RcvData, ",", -1)
                sCurrTemp = readBuff(2) ' = in_RcvData.Substring(in_RcvData.Length - 6, 4)
                sSetTemp = readBuff(3)
                'readTemp = readBuff(2)

                If readBuff(1) = "OK" Then '정상적으로 수신되었으면 10진수로 변환
                    ConvDec = CLng("&H" & sCurrTemp)
                    'If ConvDec > 640 Then
                    '    ConvDec = ConvDec - 65536
                    'End If
                    currTemp = ConvDec / NXx_TEMP_VALUE_RATE
                    ConvDec = CLng("&H" & sSetTemp)
                    If ConvDec > 640 Then
                        ConvDec = ConvDec - 65536
                    End If
                    setTemp = ConvDec / NXx_TEMP_VALUE_RATE
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try


        Else
            'frmMainWnd.frmStatusWnd.txtStatus.AppendText("데이터가 수시되지 않았습니다." & vbCrLf)
            Return False
        End If

        Return True

    End Function


    Private Function NX_ReadData_Parse(ByVal in_RcvData As String, ByRef dValue As Double) As Boolean

        Dim readBuff() As String
        Dim sValueTemp As String
        Dim ConvDec As Long
        'Dim bStatus As Boolean
        'Dim iCh As Integer

        in_RcvData = in_RcvData.TrimEnd("")
        in_RcvData = in_RcvData.TrimEnd(vbLf)
        in_RcvData = in_RcvData.TrimEnd(vbCr)

        If in_RcvData <> "" Then

            Try

                ReDim readBuff(5)

                readBuff = Split(in_RcvData, ",", -1)
                sValueTemp = readBuff(2) ' = in_RcvData.Substring(in_RcvData.Length - 6, 4)

                If readBuff(1) = "OK" Then '정상적으로 수신되었으면 10진수로 변환
                    ConvDec = CLng("&H" & sValueTemp)
                    'If ConvDec > 640 Then
                    '    ConvDec = ConvDec - 65536
                    'End If
                    dValue = ConvDec
                    'ConvDec = CLng("&H" & sSetTemp)
                    'If ConvDec > 640 Then
                    '    ConvDec = ConvDec - 65536
                    'End If
                    'setTemp = ConvDec / NXx_TEMP_VALUE_RATE
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try


        Else
            'frmMainWnd.frmStatusWnd.txtStatus.AppendText("데이터가 수시되지 않았습니다." & vbCrLf)
            Return False
        End If

        Return True

    End Function

#End Region

End Class
