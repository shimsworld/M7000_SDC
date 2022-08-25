Imports CCommLib
Imports System.Windows.Forms
Imports System.Threading

Public Class CDevM6100

    Inherits CDevSMUCommonNode

#Region "Defines"
    Dim communicator As CComAPI
    Dim m_M6100Infos As sM6100Setting
    Dim m_Ch As Integer
    Dim m_Board As Integer
    Dim m_Hw As Integer
    Dim m_numBoard As Integer
    Dim m_numChannel As Integer
    Dim CalParam As sCalParam
    Dim CalRangeParam As sCalParamCurrRange
    'Public sCurrentRange() As String = New String() {"100", "10", "1", "0.1", "0.01"}
    'Public dCurrentRange() As Double = New Double() {100, 10, 1, 0.1, 0.01}
    Public sCurrentRange() As String = New String() {"1", "0.1", "0.01", "0.001", "0.0001", "0.00001"}
    Public dCurrentRange() As Double = New Double() {1, 0.1, 0.01, 0.001, 0.0001, 0.00001}
    Dim m_DeviceRange As sRangeAndIntegTime

#Region "M6100 Command Set"
    Private Const MSG_TEST_GET_UNIT = 11
    Private Const MSG_TEST_GET_STATE = 12
    Private Const MSG_TEST_SET_STATE = 13
    Private Const MSG_TEST_RUN = 14
    Private Const MSG_TEST_STOP = 15
    Private Const MSG_TEST_RESUME = 16
    Private Const MSG_TEST_PAUSE = 17

    'Control Chamber
    Private Const MSG_CHAMB_GET_CHN_DATA = 71
    Private Const MSG_CHAMB_GET_ALL_DATA = 72
    Private Const MSG_CHAMB_GET_DATA_SIZE = 73
    Private Const MSG_CHAMB_SET_READ_CMD = 74
    Private Const MSG_CHAMB_SET_READ_LENGTH = 75
    Private Const MSG_CHAMB_SET_READ_FORMAT = 76
    Private Const MSG_CHAMB_SET_CHN_ENABLE = 77

    'Control System
    Private Const MSG_POLARONIX_GET_INFO = 151
    Private Const MSG_POLARONIX_GET_DATA = 152
    Private Const MSG_POLARONIX_SET_UPDATE_ENABLE = 153
    Private Const MSG_POLARONIX_SET_UPDATE_INTERVAL = 154
    Private Const MSG_POLARONIX_SET_DEBUG = 155
    Private Const MSG_POLARONIX_GET_UPDATE_ENABLE = 156
    Private Const MSG_POLARONIX_GET_UPDATE_INTERVAL = 157
    Private Const MSG_POLARONIX_GET_DEBUG = 158

    'Control Board
    Private Const MSG_BOARD_GET_CHANNEL_INFO = 31
    Private Const MSG_BOARD_GET_CHANNEL_DATA = 32
    Private Const MSG_BOARD_GET_ALL_DATA = 33
    Private Const MSG_BOARD_GET_CALIB_PARAM = 34
    Private Const MSG_BOARD_GET_CALC_BRIGHT_PARAM = 35

    Private Const MSG_BOARD_SET_ENABLE = 36
    Private Const MSG_BOARD_SET_RCALIB_VOLT = 37
    Private Const MSG_BOARD_SET_RCALIB_CURR1 = 38
    Private Const MSG_BOARD_SET_RCALIB_CURR2 = 39
    Private Const MSG_BOARD_SET_RCALIB_CURR3 = 40
    Private Const MSG_BOARD_SET_RCALIB_BRIGHT = 41
    Private Const MSG_BOARD_SET_BIAS_2 = 42
    Private Const MSG_BOARD_SET_RESET = 43
    Private Const MSG_BOARD_SET_BIAS = 44
    Private Const MSG_BOARD_SET_PULSE = 45
    Private Const MSG_BOARD_SET_SWITCH = 46
    Private Const MSG_BOARD_SET_ELECMODE = 47
    Private Const MSG_BOARD_SET_CURR_RANGE = 48
    Private Const MSG_BOARD_SET_COMPLIANCE = 49
    Private Const MSG_BOARD_SET_CALC_BRIGHT_PARAM = 50

    Private Const MSG_BOARD_GET_ENABLE = 51

    Private Const MSG_BOARD_SET_SCALB_VOLT = 52
    Private Const MSG_BOARD_SET_SCALB_CURR1 = 53
    Private Const MSG_BOARD_SET_SCALB_CURR2 = 54
    Private Const MSG_BOARD_SET_SCALB_CURR3 = 55

    'Read Calibration
    Private Const MSG_BOARD_GET_RCALB_VOLT = 62
    Private Const MSG_BOARD_GET_RCALB_CURR1 = 63
    Private Const MSG_BOARD_GET_RCALB_CURR2 = 64
    Private Const MSG_BOARD_GET_RCALB_CURR3 = 65
    Private Const MSG_BOARD_GET_RCALB_BRIGHT = 66

    Private Const MSG_BOARD_GET_SCALB_VOLT = 67
    Private Const MSG_BOARD_GET_SCALB_CURR1 = 68
    Private Const MSG_BOARD_GET_SCALB_CURR2 = 69
    Private Const MSG_BOARD_GET_SCALB_CURR3 = 70

    Private Const MSG_BOARD_GET_AC_SCALB_VOLT = 71
    Private Const MSG_BOARD_GET_AC_SCALB_CURR1 = 72
    Private Const MSG_BOARD_GET_AC_SCALB_CURR2 = 73
    Private Const MSG_BOARD_GET_AC_SCALB_CURR3 = 74
#End Region

#Region "Range"
    Public Const Range_Change_For_Curr_01 = 1
    Public Const Range_Change_For_Curr_02 = 0.1
    Public Const Range_Change_For_Curr_03 = 0.01
    Public Const Range_Change_For_Curr_04 = 0.001
    Public Const Range_Change_For_Curr_05 = 0.0001
    Public Const Range_Change_For_Curr_06 = 0.00001
#End Region


#End Region

#Region "Enum"

    Public Enum eSMUMode
        eCurrent
        eVoltage
        ePulseVoltage
    End Enum
    Public Enum eTerminal
        eRear
        eFront
    End Enum
    Public Enum eWireMode
        e2Wire
        e4Wire
    End Enum
    Public Enum eDevice
        eM6100
    End Enum
#End Region

#Region "Structure"

    Public Structure sCalParamCurrRange
        Dim CurrRange() As String
    End Structure

    Public Structure sCalParam
        '****************************
        '''Dim RLV_Disp(,) As Double
        Dim RV_ratio(,) As String
        Dim RV_offset(,) As String

        '''Dim RLC_Disp(,) As Double
        Dim RC_ratio(,) As sCalParamCurrRange
        Dim RC_offset(,) As sCalParamCurrRange

        Dim BR_ratio(,) As String
        Dim BR_offset(,) As String

        '****************************
        '''Dim SLV_set(,) As Double
        Dim SDCV_ratio(,) As String
        Dim SDCV_offset(,) As String
        Dim SDCC_ratio(,) As sCalParamCurrRange
        Dim SDCC_offset(,) As sCalParamCurrRange

        '****************************
        Dim SACV_ratio(,) As String
        Dim SACV_offset(,) As String
        Dim SACC_ratio(,) As String
        Dim SACC_offset(,) As String

        'for CMRR
        Dim CMRR_ratio(,) As String
        Dim CMRR_offset(,) As String

    End Structure

    Public Structure sM6100Setting
        Dim SourceMode As eSMUMode
        Dim CurrentRange As Double
        '   Dim sCurrentRange() As String
    End Structure

#End Region

#Region "Property"

#End Region

#Region "Creator, Disposer, Init"
    Public Sub New(ByVal devType As eDevice, Optional ByVal numBoard As Integer = 0)

        MyBase.New()
        m_MyModel = devType

        m_numBoard = numBoard
        m_numChannel = numBoard * 4

        m_DeviceRange.sCurrentListName = sCurrentRange.Clone
        m_DeviceRange.dCurrentListValue = dCurrentRange.Clone
    End Sub

#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)
        Dim sIDNInfos As String = Nothing
        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        End If

        If ReadCalibrationData() = False Then
            Return False
        End If

        '     m_M6100Infos.sCurrentRange = sCurrentRange.Clone
        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        '   If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '   End If

        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"


    Public Overrides Sub GetRangeList(ByRef range As CDevSMUCommonNode.sRangeAndIntegTime)
        range = m_DeviceRange
    End Sub

    Public Overrides Function SetBias(ByVal dBias As Double) As Boolean
        If SetBiasValue(dBias) = False Then Return False

        'If SetBiasValue(dBias) = False Then Return False
        Return True
    End Function

    'Public Overrides Function SetBias(ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFrequency As Double, ByVal dduty As Double) As Boolean
    '    '    If BiasSettings(dBias, dAmplitude, dFrequency, dduty) = False Then Return False
    '    Return True
    'End Function

    Public Overrides Function OutputOn() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = "'"
        sCommands = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & "1)")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            If ErrorCheck(sRcvData) = False Then Return False
        End If
        Return True
    End Function

    Public Overrides Function OutputOff() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""
        sCommands = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & "0)")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            If ErrorCheck(sRcvData) = False Then Return False
        End If
        Return True
    End Function

    Public Overrides Function Measure(ByRef dVoltage As Double, ByRef dCurrent As Double) As Boolean

        '   If Measurement(dVoltage, dCurrent, dLVoltage, dLCurrent) = False Then Return False
        If Measurement(dVoltage, dCurrent) = False Then Return False

        Return True

    End Function

    Public Overrides Function InitializeSweep(ByVal SetInfos As sM6100Setting, ByVal ch As Integer) As Boolean
        Dim nHwnumber As Integer
        Dim nBoardnumber As Integer
        Dim nChannelnumber As Integer

        m_M6100Infos = SetInfos

        If cvtChToM6100Info(ch, nHwnumber, nBoardnumber, nChannelnumber) = False Then Return False

        m_Hw = nHwnumber
        m_Board = nBoardnumber
        m_Ch = nChannelnumber

        If SetInit() = False Then Return False

        If OutputOn() = False Then Return False

        Return True
    End Function

    Public Overrides Function Initializ(ByVal settings As sM6100Setting, ByVal ch As Integer) As Boolean
        Dim nHwnumber As Integer
        Dim nBoardnumber As Integer
        Dim nChannelnumber As Integer

        m_M6100Infos = settings

        If cvtChToM6100Info(ch, nHwnumber, nBoardnumber, nChannelnumber) = False Then Return False

        m_Hw = nHwnumber
        m_Board = nBoardnumber
        m_Ch = nChannelnumber

        If SetInit() = False Then Return False

        '  If OutputOn() = False Then Return False

        Return True
    End Function


    Public Overrides Function FinalizeSweep() As Boolean
        '  If Reset() = False Then Return False
        If SetBiasValue(0) = False Then Return False

        If OutputOff() = False Then Return False

        Return True
    End Function

    Public Overrides Sub SetBoardInit(ByVal numBoard As Integer)
        m_numBoard = numBoard
        m_numChannel = numBoard * 4
    End Sub

    Public Overrides Function ACK() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""

        sCommands = ("[" & MSG_POLARONIX_GET_INFO & "]")    '& " " & "(" & CStr(nBrdNum) & "," & CStr(nCh) & ")"
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Calibration"

    Public Function ReadCalibrationData() As Boolean

        Dim nBrdCnt As Integer = 0
        Dim nChCnt As Integer = 0
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        'nTotalCH = 0

        'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
        ReDim CalParam.RV_ratio(m_numBoard - 1, 0)
        ReDim CalParam.RV_offset(m_numBoard - 1, 0)

        ReDim CalParam.SDCV_ratio(m_numBoard - 1, 0)
        ReDim CalParam.SDCV_offset(m_numBoard - 1, 0)

        ReDim CalParam.SACV_ratio(m_numBoard - 1, 0)
        ReDim CalParam.SACV_offset(m_numBoard - 1, 0)

        'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
        ReDim CalParam.RC_ratio(m_numBoard - 1, 0)
        ReDim CalParam.RC_offset(m_numBoard - 1, 0)
        ReDim Preserve CalParam.RC_ratio(m_numBoard - 1, 0).CurrRange(5)
        ReDim Preserve CalParam.RC_offset(m_numBoard - 1, 0).CurrRange(5)

        ReDim CalParam.BR_ratio(m_numBoard - 1, 0)
        ReDim CalParam.BR_offset(m_numBoard - 1, 0)

        ReDim CalParam.SDCC_ratio(m_numBoard - 1, 0)
        ReDim CalParam.SDCC_offset(m_numBoard - 1, 0)
        ReDim Preserve CalParam.SDCC_ratio(m_numBoard - 1, 0).CurrRange(5)
        ReDim Preserve CalParam.SDCC_offset(m_numBoard - 1, 0).CurrRange(5)

        ReDim CalParam.SACC_ratio(m_numBoard - 1, 0)
        ReDim CalParam.SACC_offset(m_numBoard - 1, 0)

        'CMRR
        ReDim CalParam.CMRR_ratio(m_numBoard - 1, 0)
        ReDim CalParam.CMRR_offset(m_numBoard - 1, 0)

        Do
            'Application.DoEvents() 'YSR_

            For nBrdCnt = 0 To m_numBoard - 1
              
                    '*****************************************************************************************************
                    'Calibration (Cal_GetParam)
                    '채널정보 채크
                    'sendMsgSok1("[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")")
                    'frmMainWnd.stbString.Text = "[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")"

                    'Get RV
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_RV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                    Else
                        Return False
                    End If

                'Get RC
                For i As Integer = 0 To 5
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & i & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_RC(sRcvData, nBrdCnt, nChCnt, i) = False Then Return False
                    Else
                        Return False
                    End If
                Next

                    'Get BRIGHT
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_BRIGHT & "](" & nBrdCnt & "," & nChCnt & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_BRIGHT(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                    Else
                        Return False
                    End If

                    'Get SDCV
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "0" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SDCV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                    Else
                        Return False
                    End If

                'Get SDCC
                For i As Integer = 0 To 5
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "0" & "," & i & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SDCC(sRcvData, nBrdCnt, nChCnt, i) = False Then Return False
                    Else
                        Return False
                    End If
                Next
                'Get SACV
                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                    If Parse_Get_Param_SACV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                Else
                    Return False
                End If

                'Get SACC
                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & "," & "0" & ")")
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                    If Parse_Get_Param_SACC(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                Else
                    Return False
                End If

                'Get CMRR
                sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                    If Parse_Get_Param_CMRR(sRcvData, nBrdCnt, nChCnt) = False Then Return False
                Else
                    Return False
                End If

                ''*****************************************************************************************************
            Next

            Thread.Sleep(1)

            Exit Do
        Loop

        Return True
    End Function

    Private Function Parse_Get_Param_RV(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If
        '  If in_strParam.Length >= 11 Then
        '  in_strParam = in_strParam.Substring(8)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.RV_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.RV_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If
        '  End If


        Return True

    End Function

    Private Function Parse_Get_Param_RC(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer, ByVal in_Range As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        '  in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.RC_ratio(in_Brd, in_CH).CurrRange(in_Range) = arrBuf(arrBuf.Length - 2)
            CalParam.RC_offset(in_Brd, in_CH).CurrRange(in_Range) = arrBuf(arrBuf.Length - 1)
        End If
        'End If


        Return True

    End Function

    Private Function Parse_Get_Param_BRIGHT(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        '  in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.BR_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.BR_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If
        'End If


        Return True

    End Function

    Private Function Parse_Get_Param_SDCV(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        ' in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")
        If arrBuf.Length >= 3 Then
            CalParam.SDCV_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.SDCV_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If
        'Else
        'Return False
        'End If


        Return True

    End Function

    Private Function Parse_Get_Param_SDCC(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer, ByVal in_Range As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        ' in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")
        If arrBuf.Length >= 3 Then
            CalParam.SDCC_ratio(in_Brd, in_CH).CurrRange(in_Range) = arrBuf(arrBuf.Length - 2)
            CalParam.SDCC_offset(in_Brd, in_CH).CurrRange(in_Range) = arrBuf(arrBuf.Length - 1)
        End If
        '  End If

        Return True
    End Function

    Private Function Parse_Get_Param_SACV(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If
        'If in_strParam.Length >= 11 Then
        'in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.SACV_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.SACV_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If

        ' End If

        Return True

    End Function

    Private Function Parse_Get_Param_SACC(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If
        ' If in_strParam.Length >= 11 Then
        '  in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 3 Then
            CalParam.SACC_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.SACC_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If
        ' End If
        Return True
    End Function
    'CMRR
    Private Function Parse_Get_Param_CMRR(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        ' in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.CMRR_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.CMRR_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
        End If
        'End If

        Return True
    End Function

#End Region

#Region "Functions"

    Private Function BiasSettings(ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFrequency As Double, ByVal dduty As Double) As Boolean
        With m_M6100Infos
            If .SourceMode = eSMUMode.eVoltage Then
                If Set_CV(0, m_Board, m_Ch, dBias) = False Then Return False
            ElseIf .SourceMode = eSMUMode.eCurrent Then
                If Set_CC(0, m_Board, m_Ch, dBias) = False Then Return False
            ElseIf .SourceMode = eSMUMode.ePulseVoltage Then
                '    If Set_PCV(0, m_Board, m_Ch, dBias, dAmplitude, dFrequency, dduty) = False Then Return False
            End If

        End With

        Return True
    End Function

    Private Function Set_CV(ByVal nHwNum As Integer, ByVal nBoard As Integer, ByVal nCH As Object, ByVal dBias As Double) As Boolean                             ', ByVal Set_Amplitude As Double)

        Dim Set_Bias1 As Double
        Dim sCommands As String = Nothing
        Dim sRcvData As String = Nothing

        ''1. CV 모드를 선택한다. [47]

        'sCommands = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & CStr(nBoard) & "," & CStr(nCH) & "," & "1)")
        'If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
        '    Return False
        'End If

        '2. 전압값을 설정한다. [44]

        Set_Bias1 = dBias * CDbl(CalParam.SDCV_ratio(nBoard, nCH)) * 1000 + CDbl(CalParam.SDCV_offset(nBoard, nCH))
        sCommands = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & nBoard & "," & CStr(nCH) & "," & CStr(Set_Bias1) & ",0)")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        ' ''3. 스위치를 ON한다. [46]

        'sCommands = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & CStr(nBoard) & "," & CStr(nCH) & "," & "1)")
        'If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
        '    Return False
        'End If

        Return True
    End Function

    Private Function Set_CC(ByVal nHwNum As Integer, ByVal Set_Board As Integer, ByVal Set_CH As Integer, _
                        ByVal Set_Bias_Value As Double) As Boolean ', ByVal Set_Amplitude As Double)

        Dim Set_Bias1 As Double
        Dim sCommands As String = Nothing
        Dim sRcvData As String = Nothing
        Dim TempRange As Integer = 0
        Dim Set_Bias_A As Double
        ''3. CC 모드를 선택한다. [47]
        'sCommands = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
        'If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
        '    Return False
        'End If

        '입력한 Bias 값 판별 후, Range 선택하고 설정
        Set_Bias_A = Set_Bias_Value ' / 1000   'A

        If Set_Bias_A > 0.1 And Set_Bias_A <= 1 Then
            TempRange = 0
        ElseIf Set_Bias_A > 0.01 And Set_Bias_A <= 0.1 Then
            TempRange = 1
        ElseIf Set_Bias_A > 0.001 And Set_Bias_A <= 0.01 Then
            TempRange = 2
        ElseIf Set_Bias_A > 0.0001 And Set_Bias_A <= 0.001 Then
            TempRange = 3
        ElseIf Set_Bias_A > 0.00001 And Set_Bias_A <= 0.0001 Then
            TempRange = 4
        ElseIf Set_Bias_A > 0.000001 And Set_Bias_A <= 0.00001 Then
            TempRange = 5
        Else
            TempRange = 5
        End If

        If SetCurrentRange(TempRange) = False Then Return False
        If SetCurrentRangeFix() = False Then Return False

        '4. 전류값을 설정한다. [44]
        'A -> mA  Set_Bias1 = Set_Bias_Value * 1000
        Set_Bias1 = Set_Bias_Value * 1000 * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH).CurrRange(TempRange)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH).CurrRange(TempRange))
        sCommands = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        ''5. 스위치를 ON한다. [46]
        'sCommands = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        'If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
        '    Return False
        'End If

        Return True
    End Function


    'Private Function Set_PCV(ByVal nHwNum As Integer, ByVal Set_Board As Object, ByVal Set_CH As Object, _
    '                       ByVal Set_Bias_Value As Double, ByVal Set_Amplitude As Double, _
    '                       ByVal Set_Frequency As Double, ByVal Set_Duty As Double) As Boolean

    '    Dim Set_Bias1 As Double
    '    Dim Set_Amp1 As Double
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing

    '    ''1. PCV 모드를 선택한다. [47]   - Mode 2
    '    'sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "2)")
    '    'If communicator.Communicator.SendToString(sSendCommand, sRcvData) = False Then
    '    '    Return False
    '    'End If

    '    Set_Bias1 = Set_Bias_Value * CDbl(CalParam.SACV_ratio(Set_Board, Set_CH)) * 1000 + CDbl(CalParam.SACV_offset(Set_Board, Set_CH))
    '    Set_Amp1 = Set_Amplitude * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
    '    '2. Bias(V) 값을 설정한다. [44]
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Amp1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = False Then
    '        Return False
    '    End If

    '    '3. Amplitude(V) 값을 설정한다. [42]
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS_2 & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = False Then
    '        Return False
    '    End If

    '    '4. 주파수, 듀티값을 설정한다. [45]
    '    sSendCommand = ("[" & MSG_BOARD_SET_PULSE & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Frequency) & "," & CStr(100 - CDbl(Set_Duty)) & ")")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = False Then
    '        Return False
    '    End If

    '    ''5. 스위치를 ON한다. [46]
    '    'sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
    '    'If communicator.Communicator.SendToString(sSendCommand, sRcvData) = False Then
    '    '    Return False
    '    'End If

    '    Return True
    'End Function

    Private Function SetSourceMode() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""

        With m_M6100Infos
            If .SourceMode = eSMUMode.eVoltage Then
                sCommands = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & "1)")
                If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
                    Return False
                End If

            ElseIf .SourceMode = eSMUMode.eCurrent Then
                sCommands = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & "0)")
                If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
                    Return False
                End If
                'If SetCurrentRange() = False Then Return False
                'If SetCurrentRangeFix() = False Then Return False

            ElseIf .SourceMode = eSMUMode.ePulseVoltage Then
                '1. PCV 모드를 선택한다. [47]   - Mode 2
                sCommands = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & "2)")
                If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
                    Return False
                End If
                'If SetCurrentRange() = False Then Return False
                'If SetCurrentRangeFix() = False Then Return False
            End If
        End With
        Return True
    End Function

    Private Function SetCurrentRange(ByVal iRange As Integer) As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""
        ' Dim nCurrentRange As Integer

        ' nCurrentRange = SetRange_Current(iRange)

        sCommands = ("[" & MSG_BOARD_SET_CURR_RANGE & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & "," & CStr(iRange) & ")")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        End If

        Return True
    End Function

    Private Function SetCurrentRangeFix() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""

            sCommands = ("[" & MSG_BOARD_SET_COMPLIANCE & "]" & "(" & CStr(m_Board) & "," & CStr(m_Ch) & ")")
            If communicator.Communicator.SendToString(sCommands, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
                Return False
            End If

        Return True
    End Function

    Public Function SetBiasValue(ByVal dBias As Double) As Boolean

        With m_M6100Infos
            If .SourceMode = eSMUMode.eVoltage Then
                If Set_CV(0, m_Board, m_Ch, dBias) = False Then Return False
            ElseIf .SourceMode = eSMUMode.eCurrent Then
                If Set_CC(0, m_Board, m_Ch, dBias) = False Then Return False
            End If
        End With

        Return True
    End Function

    Private Function Measurement(ByRef dVoltage As Double, ByRef dCurrent As Double) As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""
        Dim sRcvDataBuff() As String = Nothing
        Dim HTempV As String = ""
        Dim HTempI As String = ""
        Dim LTempV As String = ""
        Dim LTempI As String = ""
        Dim TempBr As String = ""


        ''''''''''''''''''''High''''''''''''''''''''''
        sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "0" & ")")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "0" & ")")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        '데이터 비교문 추가 2013-04-05 승현
        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(m_Hw, m_Board, m_Ch, sRcvData, HTempV, HTempI, TempBr) = False Then

            sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "0" & ")")
            If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
                Return False
            End If

            SetParse(m_Hw, m_Board, m_Ch, sRcvData, HTempV, HTempI, TempBr)
        End If

        dVoltage = CDbl(HTempV)
        dCurrent = CDbl(HTempI)

        Return True
    End Function

    Private Function Measurement(ByRef dHVoltage As Double, ByRef dHCurrent As Double, ByRef dLVoltage As Double, ByRef dLCurrent As Double) As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""
        Dim sRcvDataBuff() As String = Nothing
        Dim HTempV As String = ""
        Dim HTempI As String = ""
        Dim LTempV As String = ""
        Dim LTempI As String = ""
        Dim TempBr As String = ""


        ''''''''''''''''''''High''''''''''''''''''''''
        sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "0" & ")")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        '데이터 비교문 추가 2013-04-05 승현
        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(m_Hw, m_Board, m_Ch, sRcvData, HTempV, HTempI, TempBr) = False Then

            sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "0" & ")")
            If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
                Return False
            End If

            SetParse(m_Hw, m_Board, m_Ch, sRcvData, HTempV, HTempI, TempBr)
        End If

        If m_M6100Infos.SourceMode = eSMUMode.ePulseVoltage Then

            ''''''''''''''''''''Low''''''''''''''''''''''
            sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "1" & ")")
            If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
                Return False
            End If

            '데이터 비교문 추가 2013-04-05 승현
            sRcvDataBuff = Split(sRcvData, "]")
            If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
                Return False
            End If

            If SetParse(m_Hw, m_Board, m_Ch, sRcvData, LTempV, LTempI, TempBr) = False Then

                sCommands = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & m_Board & "," & m_Ch & "," & "1" & ")")
                If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
                    Return False
                End If

                SetParse(m_Hw, m_Board, m_Ch, sRcvData, LTempV, LTempI, TempBr)
            End If
        Else
            LTempV = "0"
            LTempI = "0"
        End If



        dHVoltage = CDbl(HTempV)
        dHCurrent = CDbl(HTempI)
        dLVoltage = CDbl(LTempV)
        dLCurrent = CDbl(LTempI)
        '   meas_PDCurr = TempBr.Clone()
        Return True
    End Function

    Public Function ErrorCheck(ByVal sRcvData As String) As Boolean
        Dim sSplitData() As String

        Try
            sSplitData = sRcvData.Split("]")
            If sSplitData.Length = 2 Then
                If sSplitData(1).Substring(2, 1) <> "1" Then
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetInit() As Boolean

        If SetBiasValue(0) = False Then Return False
        If SetSourceMode() = False Then Return False

        '   If SetBiasValue(1) = False Then Return False
        Return True
    End Function

    Public Function Reset() As Boolean
        Dim sCommands As String
        Dim sRcvData As String = ""

        sCommands = ("[" & MSG_BOARD_SET_RESET & "]" & " " & "(" & CStr(m_Board) & "," & CStr(m_Ch) & ")")
        If communicator.Communicator.SendToString(sCommands, sRcvData) = False Then
            Return False
        End If

        Return True
    End Function



    Private Function SetParse(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nChPerBrd As Integer, ByVal in_Data As String, _
                                                                ByRef Out_V As String, ByRef Out_I As String, ByRef Out_Br As String) As Boolean
        SetParse = False

        Dim TempData As Array
        Dim TempRange As Integer = 0

        If in_Data.Length < 20 Then
            Exit Function
        End If

        in_Data = in_Data.TrimEnd(")")

        TempData = Split(in_Data, ",", -1)


        '***** 예외처리부 *****

        If TempData Is Nothing = False Then
            If TempData(1) = " Polaronix IV" Then
                Out_V = "Error"
                Out_I = "Error"

                Return False
            End If

            '***** 예외처리부 끝 *****
            Out_V = TempData(4)
            Out_I = TempData(5)
            Out_Br = TempData(6)

            '*************************************************************************************************************
            Out_I = Out_I / 1000

            If Out_I > 0.1 And Out_I <= 1 Then
                TempRange = 0
            ElseIf Out_I > 0.01 And Out_I <= 0.1 Then
                TempRange = 1
            ElseIf Out_I > 0.001 And Out_I <= 0.01 Then
                TempRange = 2
            ElseIf Out_I > 0.0001 And Out_I <= 0.001 Then
                TempRange = 3
            ElseIf Out_I > 0.00001 And Out_I <= 0.0001 Then
                TempRange = 4
            ElseIf Out_I > 0.000001 And Out_I <= 0.00001 Then
                TempRange = 5
            Else
                TempRange = 5
            End If

            Out_I = Out_I * 1000

            Try
                '결과값 캘리브레이션
                If nHwNum = 0 Then
                    Out_V = CDbl(Out_V) * CDbl(CalParam.RV_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RV_offset(nBrdNum, nChPerBrd))
                    Out_I = CDbl(Out_I) * CDbl(CalParam.RC_ratio(nBrdNum, nChPerBrd).CurrRange(TempRange)) + CDbl(CalParam.RC_offset(nBrdNum, nChPerBrd).CurrRange(TempRange))
                    Out_Br = CDbl(Out_Br) * CDbl(CalParam.BR_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.BR_offset(nBrdNum, nChPerBrd))
                Else
                    Out_V = CDbl(Out_V) * CDbl(CalParam.RV_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RV_offset(nBrdNum, nChPerBrd))
                    Out_I = CDbl(Out_I) * CDbl(CalParam.RC_ratio(nBrdNum, nChPerBrd).CurrRange(TempRange)) + CDbl(CalParam.RC_offset(nBrdNum, nChPerBrd).CurrRange(TempRange))
                    Out_Br = CDbl(Out_Br) * CDbl(CalParam.BR_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.BR_offset(nBrdNum, nChPerBrd))
                End If
            Catch ex As Exception
                Return False
            End Try


            Out_V = Out_V / 1000        'mV -> V
            Out_I = Out_I / 1000     'mA -> A
            Out_Br = Out_Br / 100       'mA -> uA

        Else
            Out_V = "Error"
            Out_I = "Error"
            Out_Br = "Error"
            Return False
        End If

        Return True

    End Function

    'Private Function SetRange_Current(ByVal sValueForRange As Double) As Integer
    '    Dim iRange012 As Integer
    '    If sValueForRange >= Range_Change_For_Curr_01 Then
    '        iRange012 = 0
    '    End If

    '    If sValueForRange < Range_Change_For_Curr_01 And sValueForRange >= Range_Change_For_Curr_02 Then
    '        iRange012 = 1
    '    End If

    '    If sValueForRange < Range_Change_For_Curr_02 And sValueForRange >= Range_Change_For_Curr_03 Then
    '        iRange012 = 2
    '    End If

    '    If sValueForRange < Range_Change_For_Curr_03 And sValueForRange >= Range_Change_For_Curr_04 Then
    '        iRange012 = 3
    '    End If

    '    If sValueForRange < Range_Change_For_Curr_04 And sValueForRange >= Range_Change_For_Curr_05 Then
    '        iRange012 = 4
    '    End If

    '    If sValueForRange < Range_Change_For_Curr_05 Then
    '        iRange012 = 5
    '    End If
    '    Return iRange012
    'End Function

    Public Function cvtChToM6100Info(ByVal nCh As Integer, ByRef nHWNum As Integer, ByRef nBrdNum As Integer, ByRef nChPerBrd As Integer) As Boolean
        nHWNum = cvtChToM6100HWNum(nCh)

        nBrdNum = cvtChToM6100BrdNum(nCh)

        nChPerBrd = cvtChToM6100ChPerBrd(nCh)
        If nChPerBrd = -1 Then
            Return False
        End If

        Return True
    End Function

    Private Function cvtChToM6100HWNum(ByVal nCh As Integer) As Integer
        Dim maxChOfM6000 As Integer = 32
        Dim dCvtVal0 As Double
        Dim nCvtVal1 As Integer

        If nCh < maxChOfM6000 Then
            nCvtVal1 = 0
        Else
            dCvtVal0 = nCh / maxChOfM6000
            nCvtVal1 = Fix(dCvtVal0)
        End If

        Return nCvtVal1
    End Function

    Private Function cvtChToM6100BrdNum(ByVal nCh As Integer) As Integer
        Dim maxChOfM6000 As Integer = 32
        Dim maxChPerBrdNum As Integer = 4
        Dim dCvtVal0 As Double
        Dim nCvtVal1 As Integer
        Dim dCalBuf As Double

        If nCh >= maxChOfM6000 Then
            dCalBuf = nCh / maxChOfM6000
            nCvtVal1 = Fix(dCalBuf)
            nCh = nCh - (nCvtVal1 * maxChOfM6000)
        End If

        dCvtVal0 = nCh / maxChPerBrdNum
        nCvtVal1 = Fix(dCvtVal0)

        Return nCvtVal1
    End Function

    Private Function cvtChToM6100ChPerBrd(ByVal nCh As Integer) As Integer
        Dim cvtVal1 As Integer
        Dim cvtVal2 As Double
        Dim cvtVal0 As Double
        cvtVal0 = (nCh + 1) / 4
        cvtVal1 = Fix(cvtVal0)
        cvtVal2 = cvtVal0 - cvtVal1
        Select Case cvtVal2
            Case 0.25
                Return 0
            Case 0.5
                Return 1
            Case 0.75
                Return 2
            Case 1.0
                Return 3
            Case 0.0
                Return 3
            Case Else 'Error
                Return -1
        End Select
    End Function

#End Region
End Class
