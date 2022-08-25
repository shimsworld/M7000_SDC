'====================================================================================
'만든이 : 박상규
'날짜 : 2013.07.17
'제품명 : XBM-DR16S  LG산전
'통신방식 : RS-232
'
'1. 제어 신호 및 체크 신호
'  ㄱ. 입력 신호 5개 상태 체크
'     a. 입력 RevData 종단 문자 "ETX" 제외하고 맨 오른쪽의 1byte를 체크
'     b. 상태 설명
'       - Emergency/Reset              Hex 01
'       - Fire Detect Sensor           Hex 02
'       - Heater Part Over Current     Hex 04
'       - OLED Part Over Current       Hex 08
'       - Interrock                    Hex 10
'       - 신호가 중복으로 들어 올 수 있으므로 전체 상태는 31가지임.(경우의 수 2^n-1)
'  ㄴ. 출력 신호 2개 제어(Lamp구동 Green, Blue)
'     a. SendCommand에서 종단 문자 전에  1bit 제어
'     b. Command 설명
'       - Addredd  20   Green Off     0   측정 IDEL 상태 Off상태 일 때는 On,Off 상태로 변경 할 수 있음 PLC에서 처리.
'       - Address  20   Green On      1   측정 중 상태 On상태 일 때는 On 유지.
'       - Address  30   Blue Off      0   통신 연결 해제 및 연결 전 상태
'       - Address  30   Blue On       1   통신 연결 상태
'       - Address  40                     30번 통신 연결 유지 시키기 위해서 Pulse신호 발생
'                                     0   시간 Count Low
'                                     1   시간 Count High
'
'2. 함수 설명
' ㄱ. Connection(ByVal commInfo As CComCommonNode.sCommInfo)  
'   a. 통신 연결
'   b. 시작 문자, 종단 문자, 아스키코드 char형으로 보내 줘야 함.
'   c. from및 Main에서 통신 연결 관련 정보를 구조체 형식으로 전달 받아야 함.
' ㄴ. DisConnection()  
'   a. 통신 연결 해제
' ㄷ. GetPLCStatus()  
'   a. 위험 경보 상태를 읽어 오기. 
'   b. 스레드를 이용하여 계속 체크해야 함.
' ㄹ. chkRcvDataAnalysis(ByVal sRcvData As String, ByRef eWarning As eStatus)
'   a. 읽어온 입력 Data를 분석하여 위험 상태를 리턴 시켜 줌.
'   b. 16진수 -> 10진수 변경 시켜서 리턴  

' ㅁ. SetPLC(ByVal nLampColorOnOff As eLamp)
'   a. Lamp 출력 신호를 보냄       

'====================================================================================
Imports System
Imports System.IO
Imports System.Threading
Imports CCommLib

Public Class CDevPLC_LS
    Inherits CDevPLCCommonNode

    Dim myParent As frmMain
    Public communicator As CComAPI

    Dim m_Config As CComCommonNode.sCommInfo  'CComCommonNode.sCommInfo
    Dim m_bIsRequest As Boolean = False

    Public Const PLCCOMMAND_ETX = CType(ChrW(3), Char)
    Public Const PLCCOMMAND_EOT = CType(ChrW(4), Char)
    Public Const PLCCOMMAND_ENQ = CType(ChrW(5), Char)
    Public Const PLCCOMMAND_ACK = CType(ChrW(6), Char)
    Public Const PLCCOMMAND_NAK = CType(ChrW(21), Char)

    Const PLCCOMMAND_SYSTEM_STATE As String = "00"
    Const PLCCOMMAND_DI_SIGNAL As String = "10"
    Const PLCCOMMAND_CONNECT_STATE_CHK As String = "20"
    Const PLCCOMMAND_DO_SIGNAL As String = "30"

    'Public Shared sStatusCaption() As String = New String() {"Down", "IDEL", "PROCESS", "Maintenance", "Alarm", "Reserved01", "SafetyMode_Auto", "SafetyMode_Teach ", "Pause", "PauseAndProcess"}
    'Public Shared nStatusValue() As Integer = New Integer() {0, 1, 2, 4, 8, 10, 32, 64, 80, 82}

    'Public Shared sAlarmCaption() As String = New String() {"No Error", "Emergency", "Fire", "Heater", "Current Limit", "Interrock", "Cylinder", "DoorOpen", "Reserved"}
    'Public Shared nAlarmValue() As Integer = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}

    'Public Shared sOutputCaption() As String = New String() {"All OFF", "RED", "YELLOW", "GREEN", "BLUE", "Reserved01", "Reserved02", "Reserved03", "Reserved04"}
    'Public Shared nOutputValue() As Integer = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}


#Region "Enum"

    'Public Enum eRequestCMD
    '    eSetStatu
    '    eGetAlarm
    'End Enum

    'Public Enum eSystemStatus
    '    eDown = 0
    '    eIDEL = 1
    '    ePROCESS = 2
    '    eMaintenance = 4
    '    eAlarm = 8
    '    eReserved01 = 10 '16
    '    eSafetyMode_Auto = 32
    '    eSafetyMode_Teach = 64
    '    ePause = 80 '128
    '    ePauseAndProcess = 82 '130
    'End Enum

    'Public Enum eDISignal
    '    eNoError = 0
    '    eEmergency = 1
    '    eFire = 2
    '    eHeater = 4
    '    eCurrentLimit = 8
    '    eInterlock = 16
    '    eCylinder = 32
    '    eDoorOpen = 64
    '    ePort7_Reserved = 128
    'End Enum

    'Public Enum eDOSignal
    '    eALLOFF = 0
    '    ePort0_RED = 1
    '    ePort1_YELLOW = 2
    '    ePort2_GREEN = 4
    '    ePort3_BLUE = 8
    '    ePort4_Reserved = 16
    '    ePort5_Reserved = 32
    '    ePort6_Reserved = 64
    '    ePort7_Reserved = 128
    'End Enum

    Public Enum eOutOnOff
        eOff
        eOn
    End Enum

    Public Enum eAddress
        eInStatus = 10
        eOutMeasStatus = 20 'Lamp Green
        eOutConnectStatus = 30 'Lamp Blue
        eOutConnectChkPulse = 40  'PLC Pulse신호 보내기 일정 시간 동안 신호가 들어오지 않으면 통신 연결 해제.
    End Enum

#End Region

#Region "Properties"


#End Region


#Region "Creator and Dispose"

    Public Sub New(ByVal fmain As frmMain) 'ByVal parent As frmMain

        myParent = fmain
        m_MyModel = eModel.LS

        With m_sSignalInfo
            .sStatusCaptions = New String() {"Down", "IDEL", "PROCESS", "Maintenance", "Alarm", "Reserved01", "SafetyMode_Auto", "SafetyMode_Teach ", "Pause", "PauseAndIDEL", "PauseAndProcess"}
            ' .nStatusValues = New Byte() {0, 1, 2, 4, 8, 10, 32, 64, 80, 81, 82}
            .sAlarmCations = New String() {"No Error", "Emergency", "Fire", "Heater", "Current Limit", "Interrock", "Cylinder", "DoorOpen", "Reserved"}
            .nAlarmValues = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}
            .sOutputCaptions = New String() {"All OFF", "RED", "YELLOW", "GREEN", "BLUE", "Reserved01", "Reserved02", "Reserved03", "Reserved04"}
            .nOutputValues = New Integer() {0, 1, 2, 4, 8, 16, 32, 64, 128}
        End With

        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)

    End Sub


#End Region


#Region "Functions"

    Public Overrides Function Connection(ByVal Config As CComSerial.sCommInfo) As Boolean
        m_Config = Config

        If communicator.Communicator.Connect(Config) <> CComCommonNode.eReturnCode.OK Then Return False

        m_bIsConnected = True

        Return True
    End Function

    Public Overrides Sub Disconnection()
        m_bIsConnected = False

        communicator.Communicator.Disconnect()
    End Sub

    Public Overrides Function GetSystemStatus(ByVal state() As eSystemStatus) As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00RSS0106%DW0" & PLCCOMMAND_SYSTEM_STATE 'PLC에 신호 들어왔는지 확인 할 수 있는 Command
        Dim sRcvData As String = ""

        '감지(비상) 신호 체크 Command 00RSS0106%DW010
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        'RcvData 분석 후 감지(비상) 상태 리턴
        If chkRcvData(sRcvData) = False Then
            Return False
        End If

        '종단 문자 잘라서 버퍼에 담기
        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)

        Dim sRcvValue As String

        sRcvValue = sRcvData.Substring(sRcvData.Length - 3, 2)

        If sRcvValue = "00" Then
            ReDim state(0)
            state(0) = eSystemStatus.ePower_Down
            myParent.cPLC.m_PLCDatas.nSystemStatus = state.Clone
            Return True
        End If

        Dim nCnt As Integer
        Dim nBinery() As Integer

        nBinery = hex2bin(sRcvValue)
        ' nBinery = DecToBinery(nRcvValue)

        For i As Integer = 0 To nBinery.Length - 1
            If nBinery(i) = -1 Then
                Return False
            ElseIf nBinery(i) = 1 Then
                ReDim Preserve state(nCnt)

                'Select Case i
                '    Case 0
                '        state(nCnt) = eSystemStatus.eIDEL
                '    Case 1
                '        state(nCnt) = eSystemStatus.ePROCESS
                '    Case 2
                '        state(nCnt) = eSystemStatus.eMaintenance
                '    Case 3
                '        state(nCnt) = eSystemStatus.eAlarm
                '    Case 4
                '        state(nCnt) = eSystemStatus.eReserved01
                '    Case 5
                '        state(nCnt) = eSystemStatus.eSafetyMode_Auto
                '    Case 6
                '        state(nCnt) = eSystemStatus.eSafetyMode_Teach
                '    Case 7
                '        state(nCnt) = eSystemStatus.ePause
                'End Select
                nCnt += 1
            End If
        Next

        myParent.cPLC.m_PLCDatas.nSystemStatus = state.Clone

        Return True
    End Function

    'Public Overrides Function SetSystemStatus(ByVal state As eSystemStatus) As Boolean
    '    Dim sCommand As String = PLCCOMMAND_ENQ & "00WSS0106%DW0" & PLCCOMMAND_SYSTEM_STATE & Format(CInt(m_sSignalInfo.nStatusValues(state)), "0000") '"00WSS0106%DW020000" & nLampColorOnOff
    '    Dim sRcvData As String = ""
    '    'Lamp 출력 Command 00WSS0106%DW020000

    '    If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
    '    Return True
    'End Function

    Public Overrides Function GetAlarm(ByRef alarm() As eDISignal) As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00RSS0106%DW0" & PLCCOMMAND_DI_SIGNAL 'PLC에 신호 들어왔는지 확인 할 수 있는 Command
        Dim sRcvData As String = ""                '맨 끝단 문을 제외하고 2자리 수를 보고 판단

        '감지(비상) 신호 체크 Command 00RSS0106%DW010
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        'RcvData 분석 후 감지(비상) 상태 리턴
        If chkRcvData(sRcvData) = False Then
            Return False
        End If

        '종단 문자 잘라서 버퍼에 담기
        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)

        Dim sRcvValue As String

        sRcvValue = sRcvData.Substring(sRcvData.Length - 3, 2)

        If sRcvValue = "00" Then

            ReDim alarm(0)
            alarm(0) = eDISignal.eNoError
            myParent.cPLC.m_PLCDatas.nDISignal = alarm.Clone
            Return True
        Else

            Dim nCnt As Integer
            Dim nBinery() As Integer

            nBinery = hex2bin(sRcvValue)  ' DecToBinery(nRcvValue)

            For i As Integer = 0 To nBinery.Length - 1
                If nBinery(i) = -1 Then
                    Return False
                ElseIf nBinery(i) = 1 Then
                    ReDim Preserve alarm(nCnt)

                    Select Case i
                        Case 0
                            alarm(nCnt) = eDISignal.eEmergency
                        Case 1
                            alarm(nCnt) = eDISignal.eFire
                        Case 2
                            alarm(nCnt) = eDISignal.eHeater
                        Case 3
                            alarm(nCnt) = eDISignal.eCurrentLimit
                        Case 4
                            alarm(nCnt) = eDISignal.eInterlock
                        Case 5
                            alarm(nCnt) = eDISignal.eCylinder
                        Case 6
                            alarm(nCnt) = eDISignal.eDoorOpen
                        Case 7
                            alarm(nCnt) = eDISignal.eSupply
                        Case 8
                            alarm(nCnt) = eDISignal.eInspectionStage
                        Case 9
                            alarm(nCnt) = eDISignal.eExhaus
                    End Select
                    nCnt += 1
                End If
            Next

        End If

        myParent.cPLC.m_PLCDatas.nDISignal = alarm.Clone

        Return True
    End Function

    Public Overrides Function SetAlarm(ByVal alarm As eDISignal) As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00WSS0106%DW0" & PLCCOMMAND_DI_SIGNAL & Format(m_sSignalInfo.nAlarmValues(alarm), "0000") '"00WSS0106%DW020000" & nLampColorOnOff
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Overrides Function SetAlarm(ByVal alarm() As eDISignal) As Boolean
        For i As Integer = 0 To alarm.Length - 1
            If SetAlarm(m_sSignalInfo.nAlarmValues(alarm(i))) = False Then Return False
        Next
        Return True
    End Function

    Public Overrides Function GetDOSignal(ByRef signal() As eDOSignal) As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00RSS0106%DW0" & PLCCOMMAND_DO_SIGNAL 'PLC에 신호 들어왔는지 확인 할 수 있는 Command
        Dim sRcvData As String = ""                '맨 끝단 문을 제외하고 2자리 수를 보고 판단
        '0000 0000  워드를 -> 바이트로 00~FF 1,2,4,8

        '감지(비상) 신호 체크 Command 00RSS0106%DW010
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        'RcvData 분석 후 감지(비상) 상태 리턴
        If chkRcvData(sRcvData) = False Then
            Return False
        End If

        '종단 문자 잘라서 버퍼에 담기
        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)

        Dim sRcvValue As Integer

        sRcvValue = sRcvData.Substring(sRcvData.Length - 3, 2)

        If sRcvValue = "00" Then
            ReDim signal(0)
            signal(0) = eDOSignal.eALLOFF

            myParent.cPLC.m_PLCDatas.nDOSignal = signal.Clone
            Return True
        End If

        Dim nCnt As Integer
        Dim nBinery() As Integer

        nBinery = dec2bin(sRcvValue)
        'nBinery = DecToBinery(nRcvValue)

        For i As Integer = 0 To nBinery.Length - 1
            If nBinery(i) = -1 Then
                Return False
            ElseIf nBinery(i) = 1 Then
                ReDim Preserve signal(nCnt)

                Select Case i
                    Case 0
                        signal(nCnt) = eDOSignal.ePort0_RED
                    Case 1
                        signal(nCnt) = eDOSignal.ePort1_YELLOW
                    Case 2
                        signal(nCnt) = eDOSignal.ePort2_GREEN
                    Case 3
                        signal(nCnt) = eDOSignal.ePort3_BLUE
                    Case 4
                        signal(nCnt) = eDOSignal.ePort4_Reserved
                    Case 5
                        signal(nCnt) = eDOSignal.ePort5_Reserved
                    Case 6
                        signal(nCnt) = eDOSignal.ePort6_Reserved
                    Case 7
                        signal(nCnt) = eDOSignal.ePort7_Reserved
                End Select
                nCnt += 1
            End If
        Next
        myParent.cPLC.m_PLCDatas.nDOSignal = signal.Clone
        Return True
    End Function





    Public Overrides Function SetDOSignal(ByVal signal As eDOSignal) As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00WSS0106%DW0" & PLCCOMMAND_DO_SIGNAL & Format(m_sSignalInfo.nOutputValues(signal), "0000") '"00WSS0106%DW020000" & nLampColorOnOff
        Dim sRcvData As String = ""

        'Lamp 출력 Command 00WSS0106%DW020000
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Overrides Function SetDOSignal(ByVal signal() As eDOSignal) As Boolean
        For i As Integer = 0 To signal.Length - 1
            If SetDOSignal(m_sSignalInfo.nOutputValues(signal(i))) = False Then Return False
        Next
        Return True
    End Function

    Public Overrides Function CheckConnectionStatus() As Boolean
        Dim sCommand As String = PLCCOMMAND_ENQ & "00WSS0106%DW0" & PLCCOMMAND_CONNECT_STATE_CHK & Format(myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal, "0000")
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        If myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 0 Then
            myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 1
        Else
            myParent.cPLC.m_PLCDatas.nConnectionStatusChkVal = 0
        End If

        Return True
    End Function

    Public Overrides Function SendTestCommand(ByVal sCommand As String, ByRef sRcvData As String) As Boolean
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

#End Region

#Region "Suport Functions"

    Public Overrides Function hex2bin(ByVal in_val) As Integer()
        Dim i, j As Integer
        Dim in_len As Integer
        Dim result, atom, temp As String
        result = ""

        in_len = Len(in_val)    '입력문자열의 길이를 구함

        i = in_len
        Do
            atom = Mid(in_val, i, 1)    '맨 뒤에 문자부터 atom에 저장

            If Asc(atom) >= 97 And Asc(atom) <= 102 Then     '문자가 a~f사이이면 진입
                Select Case atom
                    Case "a"
                        atom = 10
                    Case "b"
                        atom = 11
                    Case "c"
                        atom = 12
                    Case "d"
                        atom = 13
                    Case "e"
                        atom = 14
                    Case "f"
                        atom = 15
                End Select
            End If

            If Asc(atom) >= 65 And Asc(atom) <= 70 Then
                Select Case atom
                    Case "A"
                        atom = 10
                    Case "B"
                        atom = 11
                    Case "C"
                        atom = 12
                    Case "D"
                        atom = 13
                    Case "E"
                        atom = 14
                    Case "F"
                        atom = 15
                End Select
            End If

            temp = dec2bin(atom)    '16진수의 각 자리의 숫자는 2진수의 네 자리에 해당하므로
            'atom을 2진수 변환한 후 그 값을 네 자리가 안될경우 4자리로 맞춰줘야 함
            in_len = Len(temp)
            If in_len < 4 Then

                For j = 1 To (4 - in_len) Step 1
                    temp = "0" + temp
                Next j

            End If
            result = temp + result
            i = i - 1
        Loop Until i = 0

        Dim intValue(result.Length - 1) As Integer
        For n As Integer = 0 To result.Length - 1
            intValue(n) = CInt(result.Substring(result.Length - n - 1, 1))
        Next
        Return intValue
    End Function


    'Public Function hex2bin(ByVal in_val) As String
    '    Dim i, j As Integer
    '    Dim in_len As Integer
    '    Dim result, atom, temp As String
    '    result = ""

    '    in_len = Len(in_val)    '입력문자열의 길이를 구함

    '    i = in_len
    '    Do
    '        atom = Mid(in_val, i, 1)    '맨 뒤에 문자부터 atom에 저장

    '        If Asc(atom) >= 97 And Asc(atom) <= 102 Then     '문자가 a~f사이이면 진입
    '            Select Case atom
    '                Case "a"
    '                    atom = 10
    '                Case "b"
    '                    atom = 11
    '                Case "c"
    '                    atom = 12
    '                Case "d"
    '                    atom = 13
    '                Case "e"
    '                    atom = 14
    '                Case "f"
    '                    atom = 15
    '            End Select
    '        End If

    '        If Asc(atom) >= 65 And Asc(atom) <= 70 Then
    '            Select Case atom
    '                Case "A"
    '                    atom = 10
    '                Case "B"
    '                    atom = 11
    '                Case "C"
    '                    atom = 12
    '                Case "D"
    '                    atom = 13
    '                Case "E"
    '                    atom = 14
    '                Case "F"
    '                    atom = 15
    '            End Select
    '        End If

    '        temp = dec2bin(atom)    '16진수의 각 자리의 숫자는 2진수의 네 자리에 해당하므로
    '        'atom을 2진수 변환한 후 그 값을 네 자리가 안될경우 4자리로 맞춰줘야 함
    '        in_len = Len(temp)
    '        If in_len < 4 Then

    '            For j = 1 To (4 - in_len) Step 1
    '                temp = "0" + temp
    '            Next j

    '        End If
    '        result = temp + result
    '        i = i - 1
    '    Loop Until i = 0

    '    Return result
    'End Function




    Private Function chkRcvData(ByVal sRcvData As String) As Boolean

        'Rcv 시작 문자 ACK아니면 false 리턴해서 Error NAK 보냄
        If Mid(sRcvData, 1, 1) <> PLCCOMMAND_ACK Then
            Return False
        End If

        '종단 문자 재 확인 삭제 할 수 있음 serial class에서 확인 함.
        If Mid(sRcvData, sRcvData.Length, 1) <> m_Config.sSerialInfo.sRcvTerminator Then
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Sequence"


    'Public Overrides Sub Request(ByVal info As sRequestInfo)
    '    SyncLock measQueue.SyncRoot
    '        If m_bIsRequest = False Then
    '            m_bIsRequest = True
    '            measQueue.Enqueue(info)
    '        End If
    '    End SyncLock
    'End Sub

    'Public trdProcess As Thread
    'Public bIsStop_trdProcess As Boolean

    'Private Sub trdStart()
    '    trdProcess = New Thread(AddressOf trdPorcessLoop)
    '    trdProcess.Start()
    '    bIsStop_trdProcess = False
    'End Sub

    'Public Sub trdStop()
    '    bIsStop_trdProcess = True
    'End Sub

    'Private Sub trdPorcessLoop()

    '    Dim requestInfo As sRequestInfo
    '    Dim beforState(0) As eSystemStatus
    '    Dim beforAlarm(0) As eDISignal

    '    Dim retryCount As Integer = 0

    '    beforState(0) = eSystemStatus.eDown
    '    beforAlarm(0) = eDISignal.eNoError

    '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "PLC Sequence Routine")

    '    Do
    '        Application.DoEvents()
    '        Thread.Sleep(10)

    '        If bIsStop_trdProcess = True Then
    '            Exit Do
    '        End If

    '        If retryCount > CommRetryCount Then
    '            ReDim m_PLCDatas.nSystemStatus(0)
    '            m_PLCDatas.nSystemStatus(0) = eSystemStatus.eDown

    '            RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
    '            Exit Do
    '        End If


    '        If retryCount = 0 Then

    '            Do

    '                If retryCount > CommRetryCount Then
    '                    ReDim m_PLCDatas.nSystemStatus(0)
    '                    m_PLCDatas.nSystemStatus(0) = eSystemStatus.eDown

    '                    RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)

    '                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "PLC Sequence Routine")
    '                    Exit Sub
    '                End If

    '                If bIsStop_trdProcess = True Then
    '                    Exit Do
    '                End If

    '                If retryCount = 0 Then   '통신 상태가 정상 일때, 1초 간격으로 통신
    '                    Application.DoEvents()
    '                    Thread.Sleep(1000)

    '                    SyncLock measQueue.SyncRoot  '정상일때만 다음 명령 처리
    '                        If measQueue.Count >= 1 Then
    '                            requestInfo = measQueue.Dequeue
    '                            Exit Do
    '                        Else
    '                            m_bIsRequest = False
    '                        End If
    '                    End SyncLock

    '                Else   '통신 상태가 비저상 일때
    '                    Application.DoEvents()
    '                    Thread.Sleep(10)
    '                End If


    '                'Connection 연결 상태 확인
    '                If CheckConnectionStatus() = False Then
    '                    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
    '                    '재 연결 후에 다시 작동
    '                    retryCount += 1
    '                Else
    '                    retryCount = 0
    '                End If

    '                'System 상태 감시
    '                If GetSystemStatus(m_PLCDatas.nSystemStatus) = False Then
    '                    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
    '                    '재 연결 후에 다시 작동
    '                    retryCount += 1
    '                Else
    '                    retryCount = 0

    '                    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
    '                    If beforState.Length <> m_PLCDatas.nSystemStatus.Length Then
    '                       RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
    '                    Else
    '                        For i As Integer = 0 To beforState.Length - 1
    '                            If beforState(i) <> m_PLCDatas.nSystemStatus(i) Then
    '                                RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
    '                            End If
    '                        Next
    '                    End If
    '                    '시스템의 상태를 갱신 한다.
    '                    beforState = m_PLCDatas.nSystemStatus.Clone

    '                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
    '                    Dim fIsAlarmState As Boolean = False

    '                    For i As Integer = 0 To m_PLCDatas.nSystemStatus.Length - 1
    '                        If m_PLCDatas.nSystemStatus(i) = eSystemStatus.eAlarm Then
    '                            fIsAlarmState = True
    '                        End If
    '                    Next

    '                    If fIsAlarmState = True Then
    '                        requestInfo.nCMD = eRequestCMD.eGetAlarm
    '                        Exit Do
    '                    Else
    '                        Dim alarm(0) As eDISignal
    '                        alarm(0) = eDISignal.eNoError
    '                        m_PLCDatas.nDISignal = alarm.Clone

    '                        '알람의 상태에 변화가 있으면 이벤트를 날린다.
    '                        If beforAlarm.Length <> m_PLCDatas.nDISignal.Length Then
    '                            RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
    '                        Else
    '                            For n As Integer = 0 To beforAlarm.Length - 1
    '                                If beforAlarm(n) <> m_PLCDatas.nDISignal(n) Then
    '                                    RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
    '                                End If
    '                            Next
    '                        End If
    '                        '시스템의 상태를 갱신 한다.
    '                        beforAlarm = m_PLCDatas.nDISignal.Clone

    '                    End If
    '                End If
    '            Loop


    '        End If




    '        Select Case requestInfo.nCMD

    '            Case eRequestCMD.eSetStatus
    '                If SetSystemStatus(requestInfo.nSYSStatus) = False Then
    '                    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
    '                    '재 연결 후에 다시 작동
    '                    retryCount += 1
    '                Else
    '                    retryCount = 0
    '                End If

    '                'System 상태 감시
    '                If GetSystemStatus(m_PLCDatas.nSystemStatus) = False Then
    '                    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
    '                    '재 연결 후에 다시 작동
    '                    retryCount += 1
    '                Else
    '                    retryCount = 0
    '                    '시스템의 상태에 변화가 있으면 이벤트를 날린다.
    '                    If beforState.Length <> m_PLCDatas.nSystemStatus.Length Then
    '                        RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
    '                    Else
    '                        For i As Integer = 0 To beforState.Length - 1
    '                            If beforState(i) <> m_PLCDatas.nSystemStatus(i) Then
    '                                RaiseEvent evChangeSystemStatus(m_PLCDatas.nSystemStatus)
    '                            End If
    '                        Next
    '                    End If
    '                    '시스템의 상태를 갱신 한다.
    '                    beforState = m_PLCDatas.nSystemStatus.Clone

    '                    '시스템 상태에 Alarm이 발생하면 Alarm 상태를 읽는다.
    '                    For i As Integer = 0 To m_PLCDatas.nSystemStatus.Length - 1
    '                        If m_PLCDatas.nSystemStatus(i) = eSystemStatus.eAlarm Then
    '                            requestInfo.nCMD = eRequestCMD.eGetAlarm
    '                            Exit Do
    '                        End If
    '                    Next
    '                End If

    '            Case eRequestCMD.eGetAlarm
    '                Dim alarm(0) As eDISignal
    '                alarm(0) = eDISignal.eNoError
    '                m_PLCDatas.nDISignal = alarm.Clone
    '                If GetAlarm(m_PLCDatas.nDISignal) = False Then
    '                    '통신에 문제가 발생하면, 재시도 카운트를 증가 시킴, 10번 재시도후 문제가 발생하면, 통신에 문제가 발생한 것으로 판단하고 종료
    '                    '재 연결 후에 다시 작동
    '                    retryCount += 1
    '                Else
    '                    retryCount = 0
    '                    '알람의 상태에 변화가 있으면 이벤트를 날린다.
    '                    If beforAlarm.Length <> m_PLCDatas.nDISignal.Length Then
    '                        RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
    '                    Else

    '                        For i As Integer = 0 To beforAlarm.Length - 1
    '                            If beforAlarm(i) <> m_PLCDatas.nDISignal(i) Then
    '                                RaiseEvent evChangeAlarm(m_PLCDatas.nDISignal)
    '                            End If
    '                        Next
    '                    End If
    '                    '시스템의 상태를 갱신 한다.
    '                    beforAlarm = m_PLCDatas.nDISignal.Clone
    '                End If

    '        End Select

    '    Loop


    '    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "PLC Sequence Routine")

    'End Sub


#End Region




End Class
