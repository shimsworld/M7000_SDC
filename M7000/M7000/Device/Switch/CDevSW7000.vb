Imports System.IO.Ports
Imports System.Threading
Imports CCommLib

Public Class CDevSW7000
    Inherits CDevSwitchCommonNode

#Region "Define"

    Dim m_nBeforOnChannel As Integer

    Public Event evDataTransfered(ByVal str As String, ByVal stat As eTransferState)

    Public communicator As CComAPI ' CCommLib.CComAPI(CCommLib.CComCommonNode.eCommType.eGPIB)
    '  Dim m_Config As CComCommonNode.sCommInfo


#Region "Switch Command Set"
    '--------------------------------------------------------
    'Switch Command Set
    '2008�� 4�� 19�� 
    '��·�
    '----------------------------------------------------------------------------
    Private Const SW_SET_ALLCH_OFF = "D@"    '0x40 : ��ä�� ����
    Private Const SW_SET_ALLCH_ON = "DA"     '0x41 : ��ä�� �ѱ�

    Private Const SW_SET_CH_OFF = "DB" '"DH" '      '0x42 : ä�� ������ ���� '48
    Private Const SW_SET_CH_ON = "DC" '"DI" '       '0x43 : ä�� ������ �ѱ� '49

    Private Const SW_SET_PHOTO_OFF = "DD"    '0x44 : ���� ���� ����ġ ����
    Private Const SW_SET_PHOTO_ON = "DE"     '0x45 : ���� ���� ����ġ �ѱ�

    Private Const SW_GET_DUMMY = "O@"        '0xF0 : ���� ���
    Private Const SW_GET_BOARD_INFO = "OB"   '0xF2 : Board Information �б� ���

#End Region

#Region "String and Enums"

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eMode
        eON
        eOFF
    End Enum

#End Region

#End Region

#Region "Propertys"

#End Region

#Region "Creator, Disposer And Initialization"

    Public Sub New()
        MyBase.New()
        ' m_CommStatus = eTransferState.eReady

        '  m_bIsConnected = False
        '   communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        m_MyModel = eModel.MC_SW7000
    End Sub

    Private Sub init()

    End Sub

#End Region

    

#Region "Communication"

    Public Overrides Function Connection(ByVal configInfo As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = configInfo
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(configInfo) = False Then

            m_bIsConnected = False
            Return False
        Else
            m_bIsConnected = True

            Return True
        End If
    End Function

    Public Overrides Function Connection(ByVal configInfo As CComSerial.sSerialPortInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo.sSerialInfo = configInfo

        If communicator.Communicator.Connect(configInfo) = False Then
            m_bIsConnected = False
            Return False
        Else
            m_bIsConnected = True

            Return True
        End If
    End Function

    Public Overrides Sub Disconnection()
        If m_bIsConnected = True Then
            communicator.Communicator.Disconnect()
        End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"
    Public Overrides Function AllOFF() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim bStatus As Boolean

        On Error GoTo ErrorHandler

        If m_bIsConnected = False Then
            Return False
        End If

        If SetSwitch(m_nBeforOnChannel, eMode.eOFF) = False Then
            Return False
        End If

        sCommand = SMUMakeCommand(0, SW_SET_ALLCH_OFF)

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        bStatus = ReceiveData(sRcvData, SW_SET_ALLCH_OFF)
        Return bStatus

ErrorHandler:
        Return False
    End Function

    Public Overrides Function AllON() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim bStatus As Boolean

        On Error GoTo ErrorHandler

        If m_bIsConnected = False Then
            Return False
        End If

        If SetSwitch(m_nBeforOnChannel, eMode.eOFF) = False Then
            Return False
        End If

        sCommand = SMUMakeCommand(0, SW_SET_ALLCH_ON)

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        bStatus = ReceiveData(sRcvData, SW_SET_ALLCH_ON)
        Return bStatus

ErrorHandler:
        Return False
    End Function

    Public Overrides Function SwitchON(ByVal nCh As Integer) As Boolean
        Return SetSwitch(nCh, eMode.eON)
    End Function

    Public Overrides Function SwitchOFF(ByVal nCh As Integer) As Boolean
        Return SetSwitch(nCh, eMode.eOFF)
    End Function
#End Region

#Region "Switch Device Command Process Function"

    Public Function init_Switch() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim bStatus As Boolean

        On Error GoTo ErrorHandler

        If m_bIsConnected = False Then
            Return False
        End If

        '��ä�� On�� �ϸ� ��.(����Ī ����� ������ ���� �帣�� �Ǿ ��� ������ ���� �� �����Ƿ�) _PSK
        'sCommand = SMUMakeCommand(0, SW_SET_ALLCH_ON)
        'If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        'bStatus = ReceiveData(sRcvData)
        'If bStatus = False Then
        '    Return False
        'End If

        'Thread.Sleep(100)

        sCommand = SMUMakeCommand(0, SW_SET_ALLCH_OFF)
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        bStatus = ReceiveData(sRcvData, SW_SET_ALLCH_OFF)

        Thread.Sleep(100)

        Return bStatus

ErrorHandler:

        Return False

    End Function

   

    Public Function SetSwitch(ByVal in_iCH As Integer, ByVal nMode As eMode) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim readBuff() As String
        Dim bStatus As Boolean
        Dim strDevComm As String = ""

        On Error GoTo ErrorHandler

        'Swithc Device�� ������� ������ �׳� ����
        If m_bIsConnected = False Then
            Return False
        End If

        Select Case nMode

            Case eMode.eON
                m_nBeforOnChannel = in_iCH
                strDevComm = SW_SET_CH_ON
            Case eMode.eOFF
                strDevComm = SW_SET_CH_OFF
        End Select

        sCommand = SMUMakeCommand(in_iCH, strDevComm)

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        If sRcvData <> "" Then

            ReDim readBuff(5)

            If sRcvData.Length = 10 Then

                'RcvDataBuff = strRcvData.Substring(strRcvData.IndexOf("(") + 1, strRcvData.Length - 1)

                readBuff = Split(sRcvData, ",", -1)

                If strDevComm = readBuff(1) Then
                    bStatus = True
                Else
                    ' frmMainWnd.frmStatusWnd.txtStatus.AppendText("Switch Device���� ������ �߻��Ͽ����ϴ�.")
                    bStatus = False

                    Return bStatus

                    Exit Function
                End If

            Else

                'frmMainWnd.frmStatusWnd.txtStatus.AppendText("Switch Device Info : " & strRcvData)
                bStatus = True

            End If
        Else
            bStatus = False

        End If

        Return bStatus

ErrorHandler:

        bStatus = False
        Return bStatus
    End Function


    'Private Function ChNumberToSwitchNumber(ByVal nCh As Integer) As Integer
    '    Dim i As Integer

    '    nCh = nCh + 1

    '    Select Case nCh
    '        Case 1 To 8, 17 To 24, 33 To 40
    '            If nCh Mod 2 = 1 Then
    '                If nCh <= 8 Then
    '                    i = 0
    '                ElseIf nCh >= 17 And nCh <= 24 Then
    '                    i = -4
    '                ElseIf nCh >= 33 And nCh <= 40 Then
    '                    i = -8
    '                End If

    '                nCh = nCh + i - (nCh \ 2)
    '            Else
    '                If nCh <= 8 Then
    '                    i = 22
    '                ElseIf nCh >= 17 And nCh <= 24 Then
    '                    i = 10
    '                ElseIf nCh >= 33 And nCh <= 40 Then
    '                    i = -2
    '                End If
    '                nCh = nCh + i + (nCh / 2)
    '            End If

    '            Return nCh - 1


    '        Case 9 To 16, 25 To 32, 41 To 48
    '            If nCh Mod 2 = 1 Then
    '                If nCh >= 9 And nCh <= 16 Then
    '                    i = 13
    '                ElseIf nCh >= 25 And nCh <= 32 Then
    '                    i = 1
    '                ElseIf nCh >= 41 And nCh <= 48 Then
    '                    i = -11
    '                End If

    '                nCh = nCh + i + (nCh \ 2)
    '            Else
    '                If nCh >= 9 And nCh <= 16 Then
    '                    i = 12
    '                ElseIf nCh >= 25 And nCh <= 32 Then
    '                    i = 0
    '                ElseIf nCh >= 41 And nCh <= 48 Then
    '                    i = -12
    '                End If
    '                nCh = nCh + i + (nCh / 2)
    '            End If

    '            Return nCh - 1

    '        Case 49 To 60                       '13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24
    '            nCh = nCh - 36

    '            Return nCh - 1

    '    End Select

    'End Function

#End Region


#Region "Support Functions"


    Private Function SMUMakeCommand(ByVal In_iCH As Integer, ByVal In_strCommand As String) As String
        Dim strBuffCH As String = ""

        If ConvertIntChToMcProtocolCh(In_iCH, strBuffCH) = False Then
            strBuffCH = "@@"  '���� ó���� �ؾ� �ϳ�, �Լ��� ���°� �׷��� ����...���߿� ���ľ� ����.
        End If

        strBuffCH = "(" & strBuffCH & "," & In_strCommand & ")"

        Return strBuffCH
    End Function

    Private Function ConvertIntChToMcProtocolCh(ByVal in_Ch As Integer, ByRef outCh As String) As Boolean

        Dim strHexVal As String

        Dim nHighByteVal As Integer
        Dim nLowByteVal As Integer
        Dim sHighByteVal As String
        Dim sLowByteval As String

        strHexVal = Hex(in_Ch)

        Select Case strHexVal.Length
            Case 1
                nLowByteVal = ConvertHexToInt(strHexVal)
                sLowByteval = Convert.ToChar(64 + nLowByteVal)
                outCh = "@" & sLowByteval
            Case 2
                nHighByteVal = ConvertHexToInt(strHexVal.Substring(0, 1))
                nLowByteVal = ConvertHexToInt(strHexVal.Substring(1, 1))

                sLowByteval = Convert.ToChar(64 + nLowByteVal)
                sHighByteVal = Convert.ToChar(64 + nHighByteVal)

                outCh = sHighByteVal & sLowByteval
            Case Else
                Return False
        End Select

        Return True
    End Function

    Private Function ConvertHexToInt(ByVal strHexVal As String) As Integer
        Select Case strHexVal
            Case "A"
                Return 10
            Case "B"
                Return 11
            Case "C"
                Return 12
            Case "D"
                Return 13
            Case "E"
                Return 14
            Case "F"
                Return 15
            Case Else
                Return CInt(strHexVal)
        End Select
    End Function

#End Region

#Region "Serial Communication Function"


    Private g_sRcvData As String

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function


#End Region

    Private Function ReceiveData(ByVal strRcvData As String, ByVal sSendDataChk As String) As Boolean
        Dim readBuff() As String
        Dim bStatus As Boolean
        '  Dim strDevComm As String = sSendDataChk

        On Error GoTo ErrorHandler

        If strRcvData <> "" Then

            ReDim readBuff(5)

            If strRcvData.Length = 10 Then

                readBuff = Split(strRcvData, ",", -1)

                If sSendDataChk = readBuff(1) Then
                    bStatus = True
                Else
                    bStatus = False

                    Return bStatus

                    Exit Function
                End If

            Else
                bStatus = True

            End If
        Else
            bStatus = False

        End If

        Return bStatus

ErrorHandler:

        bStatus = False
        Return bStatus

    End Function

End Class
