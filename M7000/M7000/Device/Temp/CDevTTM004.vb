Imports CCommLib
Imports System.Threading

Public Class CDevTTM004
    Inherits CDevTCCommonNode

    Dim communicator As CComAPI

#Region "Define"
    Dim m_nNumOfDev As Integer
    Dim m_numOfChPerDev As Integer


    Dim m_nDPParam As Integer = 10 'Decimal Point


    Const ACK As Byte = &H6
    Const NAK As Byte = &H15

    Public Const stx As String = Chr(&H2)
    Public Const etx As String = Chr(&H3)

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
        m_MyModel = eModel._TOHO_TTM004
        m_nNumOfDev = numOfDev
        m_numOfChPerDev = 1

        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        communicator.Communicator.TimeOut = 1

        ReDim m_Settings(m_nNumOfDev * m_numOfChPerDev - 1)

        Dim tempParam(m_numOfChPerDev - 1) As sParams

        For i As Integer = 0 To m_Settings.Length - 1
            m_Settings(i).devID = i
            m_Settings(i).numOfCh = m_numOfChPerDev ' 8
            m_Settings(i).Setting = tempParam.Clone
        Next

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub

    Public Overrides Sub Dispose()
        communicator = Nothing
    End Sub

#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal configInfo As CComCommonNode.sCommInfo) As Boolean
        Dim strTempCommand As String = ""
        Dim strRetData As String = ""

        m_bIsConnected = False

        If communicator.Communicator.Connect(configInfo) = False Then
            Return False
        End If

        If DeviceIntialization() <> eReturnCode.OK Then Return False

        m_bIsConnected = True
        Return True
    End Function

    Public Overloads Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean
        Dim strTempCommand As String = ""
        Dim strRetData As String = ""

        m_bIsConnected = False

        If communicator.Communicator.Connect(Config) = False Then
            Return False
        End If

        If DeviceIntialization() <> eReturnCode.OK Then Return False

        m_bIsConnected = True
        Return True
    End Function

    Public Overloads Sub Disconnection()
        communicator.Communicator.Disconnect()
    End Sub

    Public Overrides Function OperationRun(ByVal addr As Integer) As eReturnCode
        Return eReturnCode.OK
    End Function
    Public Overrides Function DevINFO(ByVal addr As Integer, ByRef sInfo As String) As CDevTCCommonNode.eReturnCode
        sInfo = ""
        Return eReturnCode.OK
    End Function

    'Public Overrides Function SetLimitAlarm(ByVal addr As Integer, ByVal dLimit_Low As Double, ByVal dLimit_High As Double) As eReturnCode
    '    Dim retCode As eReturnCode = eReturnCode.OK

    '    retCode = SetEventAlarm1_High(addr, dLimit_High)
    '    If retCode <> eReturnCode.OK Then Return retCode

    '    retCode = SetEventAlarm1_Low(addr, dLimit_Low)
    '    If retCode <> eReturnCode.OK Then Return retCode

    '    Return retCode
    'End Function


#End Region

#Region "Set/Get Temperature"

    Public Function DeviceIntialization(Optional ByVal nSeedAddr As Integer = 1) As eReturnCode

        Dim retCode As eReturnCode = eReturnCode.OK
        Dim dLimitLow As Double = 0
        Dim dLimitHigh As Double = 0
        For i As Integer = 0 To m_Settings.Length - 1

            retCode = GetDecimalPoint(i + nSeedAddr)
            If retCode <> eReturnCode.OK Then Return retCode

            retCode = GetEvent1Status(i + nSeedAddr, m_Settings(i).Setting(m_Settings(i).numOfCh - 1).bEnableEvent1)
            If retCode <> eReturnCode.OK Then Return retCode

            If m_Settings(i).Setting(m_Settings(i).numOfCh - 1).bEnableEvent1 = False Then
                retCode = SetEvent1Status(i + nSeedAddr, True)
                If retCode <> eReturnCode.OK Then Return retCode
                m_Settings(i).Setting(m_Settings(i).numOfCh - 1).bEnableEvent1 = True
            End If

            retCode = GetEventAlarm1_High(i + nSeedAddr, dLimitHigh)
            If retCode <> eReturnCode.OK Then Return retCode

            retCode = GetEventAlarm1_Low(i + nSeedAddr, dLimitLow)
            If retCode <> eReturnCode.OK Then Return retCode

            If dLimitHigh <> m_Settings(i).Setting(m_Settings(i).numOfCh - 1).dEvent1LimitVal_High Then
                retCode = SetEventAlarm1_High(i + nSeedAddr, m_Settings(i).Setting(m_Settings(i).numOfCh - 1).dEvent1LimitVal_High)
                If retCode <> eReturnCode.OK Then Return retCode
            End If

            If dLimitLow <> m_Settings(i).Setting(m_Settings(i).numOfCh - 1).dEvent1LimitVal_Low Then
                retCode = SetEventAlarm1_Low(i + nSeedAddr, m_Settings(i).Setting(m_Settings(i).numOfCh - 1).dEvent1LimitVal_Low)
                If retCode <> eReturnCode.OK Then Return retCode
            End If

            retCode = GetOutputStatus(i + nSeedAddr, m_Settings(i).Setting(m_Settings(i).numOfCh - 1).nOutputState)
            If retCode <> eReturnCode.OK Then Return retCode

        Next

        Return retCode
    End Function

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal temperature As Double) As eReturnCode

        Dim strAddr As String
        Dim sCommand As String
        Dim strDataValue As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        'Write Command Frame Structure 
        strDataValue = CStr(temperature * m_nDPParam)

        If strDataValue.Length > 5 Then
            strDataValue = strDataValue.Substring(strDataValue.Length - 5, 5)
        Else
            Dim i As Integer = strDataValue.Length

            For n As Integer = i To 4
                strDataValue = "0" & strDataValue
            Next
        End If

        sCommand = stx & strAddr & "WSV1" & strDataValue & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length) = BCC

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

        Else

            Return eReturnCode.Communication_Error
        End If

        sCommand = Nothing
        cmdFrame = Nothing
        sCommand = stx & strAddr & "WSTR" & etx
        cmdFrame = System.Text.Encoding.ASCII.GetBytes(sCommand)
        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then
            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

        Else

            Return eReturnCode.Communication_Error
        End If
        Return eReturnCode.OK
    End Function

    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef dCurrTemp As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RPV1" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        Application.DoEvents()
        Thread.Sleep(10)

        communicator.Communicator.TimeOut = 1

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, dCurrTemp) = False Then
                If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then
                    retCode = CheckRcvDataFrame(byRecv, strRecv)
                    If retCode <> eReturnCode.OK Then Return retCode

                    If receiveDataParser_PV(strRecv, dCurrTemp) = False Then
                        dCurrTemp = -100
                        Return eReturnCode.RcvDataParsing_Error
                    End If
                End If
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function


    Public Overrides Function GetSetTemperature(ByVal addr As Integer, ByRef dSetTemp As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RSV1" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, dSetTemp) = False Then
                If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then
                    retCode = CheckRcvDataFrame(byRecv, strRecv)
                    If retCode <> eReturnCode.OK Then Return retCode

                    If receiveDataParser_PV(strRecv, dSetTemp) = False Then
                        dSetTemp = -100
                        Return eReturnCode.RcvDataParsing_Error
                    End If
                End If
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function


    Public Function SetEventAlarm1_High(ByVal addr As Integer, ByVal limitValue As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strDataValue As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        ' If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        'Write Command Frame Structure 
        strDataValue = CStr(limitValue * m_nDPParam)

        If strDataValue.Length > 5 Then
            strDataValue = strDataValue.Substring(strDataValue.Length - 5, 5)
        Else
            Dim i As Integer = strDataValue.Length
            For n As Integer = i To 4
                strDataValue = "0" & strDataValue
            Next
        End If

        sCommand = stx & strAddr & "WE1H" & strDataValue & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)
        'ReDim Preserve cmdFrame(cmdFrame.Length)
        'cmdFrame(cmdFrame.Length) = BCC

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then
            retCode = CheckRcvDataFrame(byRecv, strRecv)
            If retCode <> eReturnCode.OK Then Return retCode
        Else
            Return eReturnCode.Communication_Error
        End If
        Return eReturnCode.OK

    End Function

    Public Function GetEventAlarm1_High(ByVal addr As Integer, ByRef limitValue As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        ' If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1H" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, limitValue) = False Then
                limitValue = -999
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

    Public Function SetEventAlarm1_Low(ByVal addr As Integer, ByVal limitValue As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strDataValue As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        '  If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")
        'Write Command Frame Structure 
        strDataValue = CStr(limitValue * m_nDPParam)

        If strDataValue.Length > 5 Then
            strDataValue = strDataValue.Substring(strDataValue.Length - 5, 5)
        Else
            Dim i As Integer = strDataValue.Length
            For n As Integer = i To 4
                strDataValue = "0" & strDataValue
            Next
        End If

        sCommand = stx & strAddr & "WE1L" & strDataValue & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)
        'ReDim Preserve cmdFrame(cmdFrame.Length)
        'cmdFrame(cmdFrame.Length) = BCC

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then
            retCode = CheckRcvDataFrame(byRecv, strRecv)
            If retCode <> eReturnCode.OK Then Return retCode
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

    Public Function GetEventAlarm1_Low(ByVal addr As Integer, ByRef limitValue As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        'If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1L" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, limitValue) = False Then
                limitValue = -999
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK

    End Function

    Public Function GetEvent1Status(ByVal addr As Integer, ByRef state As Boolean) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        ' If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1F" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode
            If receiveDataParser_Bool(strRecv, state) = False Then
                state = False
                Return eReturnCode.RcvDataParsing_Error
            End If
            'If receiveDataParser_PV(strRecv, dCurrTemp) = False Then
            '    dCurrTemp = -100
            '    Return eReturnCode.RcvDataParsing_Error
            'End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

    Public Function SetEvent1Status(ByVal addr As Integer, ByVal enable As Boolean) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strDataValue As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        'If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        'Write Command Frame Structure 
        If enable = True Then
            strDataValue = "5"
        Else
            strDataValue = "0"
        End If

        If strDataValue.Length > 5 Then
            strDataValue = strDataValue.Substring(strDataValue.Length - 5, 5)
        Else
            Dim i As Integer = strDataValue.Length

            For n As Integer = i To 4
                strDataValue = "0" & strDataValue
            Next
        End If

        sCommand = stx & strAddr & "WE1F" & strDataValue & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length) = BCC

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

        Else

            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

    Public Function GetEventAlarm1Sensitivity(ByVal addr As Integer, ByRef sensitiviity As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1C" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, sensitiviity) = False Then
                sensitiviity = -999
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK

    End Function

    Public Function GetEventAlarm1DelayTimer(ByVal addr As Integer, ByRef time As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1T" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, time) = False Then
                time = -999
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

    Public Function GetEventAlarm1Polarity(ByVal addr As Integer, ByRef polarity As Double) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "RE1P" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_PV(strRecv, polarity) = False Then
                polarity = -999
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function


    Public Overrides Function GetOutputStatus(ByVal addr As Integer, ByRef output() As eOutputStatus) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As eReturnCode

        output = Nothing

        'If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "ROM1" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then

            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            If receiveDataParser_Output(strRecv, output) = False Then
                Return eReturnCode.RcvDataParsing_Error
            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function


    Public Function GetDecimalPoint(ByVal addr As Integer) As eReturnCode
        Dim strAddr As String
        Dim sCommand As String
        Dim strRecv As String = ""
        Dim byRecv As Byte() = Nothing
        Dim retCode As CComCommonNode.eReturnCode

        'If m_bIsConnected = False Then Return False

        strAddr = Format(addr, "00")

        sCommand = stx & strAddr & "R DP" & etx

        Dim cmdFrame() As Byte = System.Text.Encoding.ASCII.GetBytes(sCommand)

        'Dim BCC As Byte = CalculationBCC(cmdFrame)

        'ReDim Preserve cmdFrame(cmdFrame.Length)

        'cmdFrame(cmdFrame.Length - 1) = BCC
        communicator.Communicator.TimeOut = 2

        If communicator.Communicator.SendToBytes(cmdFrame, byRecv) = CComCommonNode.eReturnCode.OK Then


            retCode = CheckRcvDataFrame(byRecv, strRecv)

            If retCode <> eReturnCode.OK Then Return retCode

            Dim dispPt As Integer
            If receiveDataParser_DP(strRecv, dispPt) = False Then

                Return eReturnCode.RcvDataParsing_Error
            Else
                If dispPt = 0 Then
                    m_nDPParam = 1
                ElseIf dispPt = 1 Then
                    m_nDPParam = 10
                Else
                    Return eReturnCode.RcvDataParsing_Error
                End If

            End If
        Else
            Return eReturnCode.Communication_Error
        End If

        Return eReturnCode.OK
    End Function

#End Region

#Region "Data Proc"


    Private Function CalculationBCC(ByVal byFrame() As Byte) As Byte
        Dim BCCVal As Byte

        For i As Integer = 0 To byFrame.Length - 1
            BCCVal = BCCVal Xor byFrame(i)
        Next

        Return BCCVal
    End Function


    Private Function CheckRcvDataFrame(ByVal byRcvFrame As Byte(), ByRef strRcvFrame As String) As eReturnCode

        If byRcvFrame Is Nothing Then Return eReturnCode.FuncErr
        strRcvFrame = System.Text.Encoding.ASCII.GetString(byRcvFrame)

        If strRcvFrame Is Nothing Then Return eReturnCode.FuncErr

        strRcvFrame = strRcvFrame.TrimStart(stx)
        strRcvFrame = strRcvFrame.TrimEnd(etx)

        Dim strAddr As String = strRcvFrame.Substring(0, 2)
        Dim strState As String = strRcvFrame.Substring(2, 1)

        If strState = Chr(NAK) Then Return eReturnCode.RcvData_NAK

        Return eReturnCode.OK
    End Function

    Private Function receiveDataParser_PV(ByVal strRcvFrame As String, ByRef dTemp As Double) As Boolean

        Dim strData As String = Nothing

        If strRcvFrame Is Nothing Then Return False

        Try
            strData = strRcvFrame.Substring(strRcvFrame.Length - 5, 5)
            dTemp = CDbl(strData) / m_nDPParam
        Catch ex As Exception
            dTemp = -100
            Return False
        End Try

        Return True
    End Function

    Private Function receiveDataParser_Bool(ByVal strRcvFrame As String, ByRef bool As Boolean) As Boolean

        Dim strData As String

        If strRcvFrame Is Nothing Then Return False

        Try
            strData = strRcvFrame.Substring(strRcvFrame.Length - 5, 5)
        Catch ex As Exception
            Return False
        End Try

        Dim intValue As Integer = CInt(strData)

        bool = CBool(intValue)

        Return True
    End Function

    Private Function receiveDataParser_Output(ByVal strRcvFrame As String, ByRef Output() As eOutputStatus) As Boolean
        Dim strData As String

        If strRcvFrame Is Nothing Then Return False

        Try
            strData = strRcvFrame.Substring(strRcvFrame.Length - 5, 5)
        Catch ex As Exception
            Return False
        End Try
        '    ReDim Output(strData.Length - 1)
        Dim nCntOutput As Integer = 0
        ReDim Output(nCntOutput)

        For i As Integer = 0 To strData.Length - 1

            If strData.Substring(i, 1) = "1" Then

                ReDim Preserve Output(nCntOutput)
                Select Case i
                    Case 1
                        Output(nCntOutput) = eOutputStatus._Limit_Alarm_EV2
                    Case 2
                        Output(nCntOutput) = eOutputStatus._Limit_Alarm_EV1
                    Case 3
                        Output(nCntOutput) = eOutputStatus._OUT2
                    Case 4
                        Output(nCntOutput) = eOutputStatus._OUT1
                    Case Else
                        Output(nCntOutput) = eOutputStatus._Undefiend
                End Select
                nCntOutput += 1

            End If

        Next

        If nCntOutput = 0 Then
            ReDim Output(nCntOutput)
            Output(nCntOutput) = eOutputStatus._Nothing
        End If

        'Try
        '    dTemp = CDbl(strData) / m_nDPParam
        'Catch ex As Exception
        '    dTemp = -100
        '    Return False
        'End Try

        Return True
    End Function

    Private Function receiveDataParser_DP(ByVal strRcvFrame As String, ByRef pt As Integer) As Boolean

        Dim strData As String

        If strRcvFrame Is Nothing Then Return False

        strData = strRcvFrame.Substring(strRcvFrame.Length - 5, 5)

        Try
            pt = CInt(strData)
        Catch ex As Exception
            pt = -100
            Return False
        End Try

        Return True
    End Function

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

#End Region

End Class
