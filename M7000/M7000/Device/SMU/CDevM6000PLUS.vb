Imports System.Threading
Imports CCommLib

Public Class CDevM6000PLUS
    Inherits CDevM6000CommonNode
    'Sourcing 방법 변경 -> Switch on -> bias set  (기존 bias set -> switch on)
#Region "Define"

    Dim m_ID As Integer   '객체 식별 코드

#Region "Const"

#Region "Communication_Serial" ' 안씀 삭제
    Public Const SERIAL_BAUDRATE As Integer = 38400
    Public Const SERIAL_DataBits As Integer = 8
    Public Const SERIAL_Terminator As String = "" 'vbCrLf
    Public Const SERIAL_CMDTerminator As String = ")" 'vbCrLf
    Public Const SERIAL_StopBit As System.IO.Ports.StopBits = IO.Ports.StopBits.One
    Public Const SERIAL_Parity As System.IO.Ports.Parity = IO.Ports.Parity.None
#End Region

#End Region

    Dim communicator As CComAPI
    Dim m_numBoard As Integer
    Dim m_numChannel As Integer

    Dim m_Settings() As sSettingParams
    Dim m_MeasureData() As sMeasParams
    Dim m_Config As CComCommonNode.sCommInfo
    Dim bIsConnected As Boolean = False
    Dim CalParam As sCalParam

    'Dim cSocketInfo() As CWinSock.sStateWinSock
    'Dim cComSerialInfo() As CComSerial.sSerialPortInfo

#Region "M6000 Command Set"

    'Test Unit
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
    ' Private Const MSG_BOARD_SET_COMPLIANCE = 49
    Private Const MSG_BOARD_SET_CURR_RANGE_MODE = 49
    Private Const MSG_BOARD_SET_CALC_BRIGHT_PARAM = 50

    Private Const MSG_BOARD_GET_ENABLE = 51

    Private Const MSG_BOARD_SET_SCALB_VOLT = 52
    Private Const MSG_BOARD_SET_SCALB_CURR1 = 53
    'Private Const MSG_BOARD_SET_SCALB_CURR2 = 54
    'Private Const MSG_BOARD_SET_SCALB_CURR3 = 55

    Private Const MSG_BOARD_SET_AC_SCALIB_VOLT = 56
    Private Const MSG_BOARD_SET_AC_SCALIB_CURR_1 = 57
    'Private Const MSG_BOARD_SET_AC_SCALIB_CURR_2 = 58
    'Private Const MSG_BOARD_SET_AC_SCALIB_CURR_3 = 59

    'Read Calibration
    Private Const MSG_BOARD_GET_RCALB_VOLT = 62
    Private Const MSG_BOARD_GET_RCALB_CURR1 = 63
    Private Const MSG_BOARD_GET_RCALB_CURR2 = 64 'Plus 에서는 Range1로 인덱스 조회
    Private Const MSG_BOARD_GET_RCALB_CURR3 = 65 'Plus 에서는 Range1로 인덱스 조회
    Private Const MSG_BOARD_GET_RCALB_BRIGHT = 66 'Plus 에서는 사용X

    Private Const MSG_BOARD_GET_SCALB_VOLT = 67
    Private Const MSG_BOARD_GET_SCALB_CURR1 = 68
    'Private Const MSG_BOARD_GET_SCALB_CURR2 = 69
    'Private Const MSG_BOARD_GET_SCALB_CURR3 = 70

    Private Const MSG_BOARD_GET_AC_SCALB_VOLT = 71
    'Private Const MSG_BOARD_GET_AC_SCALB_CURR1 = 72 'Pluse에서는 Range1로 인덱스 조회
    'Private Const MSG_BOARD_GET_AC_SCALB_CURR2 = 73 'Pluse에서는 Range1로 인덱스 조회
    'Private Const MSG_BOARD_GET_AC_SCALB_CURR3 = 74 'Pluse에서는 Range1로 인덱스 조회

    'IVL
    Private Const MSG_BOARD_GET_CHANNEL_IVLSTATUS = 120
    Private Const MSG_BOARD_SET_CHANNEL_IVLOPERATION = 121
    Private Const MSG_BOARD_GET_CHANNEL_IVLDATA = 122
    Private Const MSG_BOARD_SET_CHANNEL_IVLBIAS = 123
    Private Const MSG_BOARD_SET_CHANNEL_IVLCFG = 124
    Private Const MSG_BOARD_SET_CHANNEL_IVLMEASCONFIG = 125

    'add M6000 + 
    Private Const MSG_BOARD_SET_CALIB_ENABLE = 60
    Private Const MSG_BOARD_SET_PD_RANGE = 77 ' change to MSG_CHAMB_SET_CHN_ENABLE
    Private Const MSG_BOARD_SET_PROBE_MODE = 78
    Private Const MSG_BOARD_SET_CALIB_SAVE = 79
    Private Const MSG_BOARD_SET_PD_RANGE_MODE = 80
    Private Const MSG_BOARD_SET_PDCALIB_CURR_1 = 112
    Private Const MSG_BOARD_SET_PDCALIB_CURR_2 = 113
    Private Const MSG_BOARD_SET_PDCALIB_CURR_3 = 114
    Private Const MSG_BOARD_GET_PDCALIB_CURR_1 = 116
    Private Const MSG_BOARD_GET_PDCALIB_CURR_2 = 117
    Private Const MSG_BOARD_GET_PDCALIB_CURR_3 = 118

    Private Const MSG_BOARD_SET_OVERVOLT = 90
    Private Const MSG_BOARD_SET_OVERCURR = 91
    Private Const MSG_BOARD_SET_RANGE_VOLT = 92
    Private Const MSG_BOARD_SET_RANGE_CURR_1 = 93
    Private Const MSG_BOARD_SET_RANGE_CURR_2 = 94
    Private Const MSG_BOARD_SET_RANGE_CURR_3 = 95
    Private Const MSG_BOARD_SET_RANGE_PDCURR_1 = 96
    Private Const MSG_BOARD_SET_RANGE_PDCURR_2 = 97
    Private Const MSG_BOARD_SET_RANGE_PDCURR_3 = 98
    Private Const MSG_BOARD_GET_RANGE = 99

#End Region

#Region "Structure"


    'Public Structure sSettingParams
    '    Dim source As sBias
    '    Dim bOutputState As eONOFF
    'End Structure

    'Public Structure sMeasParams
    '    Dim dVoltage_Bias As Double
    '    Dim dVoltage_Amplitude As Double
    '    Dim dCurrent_Bias As Double
    '    Dim dCurrent_Amplitude As Double
    '    Dim dPDCurrent As Double
    '    Dim dLuminance_Candela As Double
    'End Structure

    'Structure sBias
    '    Dim Mode As eMode
    '    Dim dBiasValue As Double
    '    Dim dAmplitude As Double
    '    Dim Pulse As sPulse
    '    Dim nConstantBrightnessMode As Boolean
    'End Structure

    'Structure sPulse
    '    Dim dFrequency As Double
    '    Dim dDuty As Double
    'End Structure


    Public Structure sCalParam
        '****************************
        '''Dim RLV_Disp(,) As Double
        Dim RV_ratio(,) As String
        Dim RV_offset(,) As String

        '''Dim RLC_Disp(,) As Double
        Dim RC_ratio(,) As String
        Dim RC_offset(,) As String

        Dim BR_ratio(,) As String
        Dim BR_offset(,) As String

        '****************************
        '''Dim SLV_set(,) As Double
        Dim SDCV_ratio(,) As String
        Dim SDCV_offset(,) As String
        Dim SDCC_ratio(,) As String
        Dim SDCC_offset(,) As String

        '****************************
        Dim SACV_ratio(,) As String
        Dim SACV_offset(,) As String
        Dim SACC_ratio(,) As String
        Dim SACC_offset(,) As String

        'for CMRR
        Dim CMRR_ratio(,) As String
        Dim CMRR_offset(,) As String

    End Structure

#Region "Enum"
    Enum AutoMode
        Auto
        Manual
        SemiAuto
    End Enum
    'Enum eMode
    '    eCC = 0
    '    eCV = 1
    '    ePC = 2
    '    ePV = 3
    '    ePCV = 4
    'End Enum

    'Enum eONOFF
    '    eOFF = 0
    '    eON = 1
    'End Enum

#End Region

#End Region

#Region "Property"

    Public Overrides ReadOnly Property IsConnected As Boolean
        Get
            Return bIsConnected
        End Get
    End Property

    Public Overrides ReadOnly Property Settings() As sSettingParams()
        Get
            Return m_Settings
        End Get
    End Property

    Public Overrides ReadOnly Property MeasuredDatas() As sMeasParams()
        Get
            Return m_MeasureData
        End Get
    End Property

#End Region

#End Region

    Public Sub New(ByVal id As Integer, ByVal numBoard As Integer)
        MyBase.new()
        m_ID = id
        m_numBoard = numBoard
        m_numChannel = numBoard * 4
        RedimValue()
    End Sub

    Public Sub RedimValue()
        ReDim m_MeasureData(m_numChannel - 1)
        ReDim m_Settings(m_numChannel - 1)
        ReDim m_IVLState(m_numChannel - 1)
        ReDim m_sRange(m_numBoard - 1)
    End Sub


#Region "Communication"
    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean

        bIsConnected = False
        m_Config = Config

        If communicator Is Nothing = True Then
            communicator = New CComAPI(m_Config.commType)
        End If

        If communicator.Communicator.Connect(m_Config) <> CComCommonNode.eReturnCode.OK Then Return False

        If ACK() = False Then Return False

        'If LoadCalibrationDatas() = False Then  '파일로 저장된 Calibaration 데이터를 로딩, 저장된 파일이 없으면 장비에서 읽어옴
        '    If ReadCalibrationData() = False Then
        '        Return False
        '    End If
        'End If

        If ReadCalibrationData() = False Then
            Return False
        End If

        '여기서 각 보드의 정상 유무를 판단
        If InitializeM6000() = False Then Return False


        bIsConnected = True
        Return True
    End Function

    Public Overrides Function Connection() As Boolean

        bIsConnected = False

        If communicator Is Nothing Then Return False

        If communicator.Communicator.Connect(m_Config) <> CComCommonNode.eReturnCode.OK Then Return False

        If ACK() = False Then Return False

        'If InitializeM6000() = False Then Return False

        'If LoadCalibrationDatas() = False Then  '파일로 저장된 Calibaration 데이터를 로딩, 저장된 파일이 없으면 장비에서 읽어옴
        '    If ReadCalibrationData() = False Then
        '        Return False
        '    End If
        'End If

        bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        If communicator Is Nothing = False Then
            communicator.Communicator.Disconnect()
        End If

        bIsConnected = False
    End Sub

#End Region


#Region "Function"

#Region "Calibration"

    Public Overrides Function InitializeM6000(ByVal nCh As Integer, ByVal settings As frmChannelRangeSetttings.sRangeSettings, ByVal biassetting As sSettingParams) As Boolean

        'Auto Range Set
        If settings.nAutoRangeIndex = eAutoRangeMode._On Then

            If biassetting.source.Mode = eMode.ePC Or biassetting.source.Mode = eMode.ePCV Or biassetting.source.Mode = eMode.ePV Then

                If Set_AutoRange_Current(nCh, AutoMode.Manual) = False Then
                    Return False
                End If

                If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then

                    Application.DoEvents()
                    Thread.Sleep(600)

                    If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then
                        Return False
                    End If
                End If

                If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then
                    Return False
                End If

                If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                    Application.DoEvents()
                    Thread.Sleep(600)

                    If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
                        Return False
                    End If
                End If
            Else

                If Set_AutoRange_Current(nCh, AutoMode.Auto) = False Then
                    Return False
                End If

                If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then

                    Application.DoEvents()
                    Thread.Sleep(600)

                    If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then
                        Return False
                    End If
                End If

                If settings.nSemiAutoRangeIndex = eSemiAutoMode._On Then
                    If Set_AutoRange_PD(nCh, AutoMode.SemiAuto) = False Then
                        Return False
                    End If
                Else

                    If Set_AutoRange_PD(nCh, AutoMode.Auto) = False Then
                        Return False
                    End If
                End If

                If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                    Application.DoEvents()
                    Thread.Sleep(600)

                    If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
                        ' LogMsg("Initalize Set Photo Range Fail")
                        Return False
                    End If
                End If
            End If

            Application.DoEvents()
            Thread.Sleep(50)

            If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

                Application.DoEvents()
                Thread.Sleep(600)

                If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then
                    '  LogMsg("Initalize Set Probe Mode Fail")
                    Return False
                End If
            End If
            'Manual Range Set
        Else

            If Set_AutoRange_Current(nCh, AutoMode.Manual) = False Then
                Return False
            End If

            If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then

                Application.DoEvents()
                Thread.Sleep(600)

                If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then
                    Return False
                End If
            End If

            If biassetting.source.Mode = eMode.ePC Or biassetting.source.Mode = eMode.ePCV Or biassetting.source.Mode = eMode.ePV Then

                If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then
                    Return False
                End If

                If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                    Application.DoEvents()
                    Thread.Sleep(600)

                    If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                        ' LogMsg("Initalize Set Photo Range Fail")

                        Return False
                    End If
                End If
            Else

                If settings.nSemiAutoRangeIndex = eSemiAutoMode._On Then

                    If Set_AutoRange_PD(nCh, AutoMode.SemiAuto) = False Then

                        Return False

                    End If
                Else
                    If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then

                        Return False

                    End If
                End If

                If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                    Application.DoEvents()

                    Thread.Sleep(600)

                    If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

                        ' LogMsg("Initalize Set Photo Range Fail")

                        Return False

                    End If

                End If

            End If

            Application.DoEvents()

            Thread.Sleep(50)

            If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

                Application.DoEvents()

                Thread.Sleep(600)

                If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

                    '  LogMsg("Initalize Set Probe Mode Fail")

                    Return False

                End If

            End If

            Application.DoEvents()

            Thread.Sleep(50)

        End If

        Return True
        'If settings.nAutoRangeIndex = eAutoRangeMode._On Then
        '    If Set_AutoRange_Current(nCh, AutoMode.Auto) = False Then
        '        Return False
        '    End If

        '    If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then

        '        Application.DoEvents()
        '        Thread.Sleep(600)

        '        If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then
        '            Return False
        '        End If
        '    End If

        '    If biassetting.source.Mode = eMode.ePC Or biassetting.source.Mode = eMode.ePCV Or biassetting.source.Mode = eMode.ePV Then

        '        If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then
        '            Return False
        '        End If

        '        If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '            Application.DoEvents()
        '            Thread.Sleep(600)

        '            If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
        '                Return False
        '            End If
        '        End If
        '    Else

        '        If settings.nSemiAutoRangeIndex = eSemiAutoMode._On Then
        '            If Set_AutoRange_PD(nCh, AutoMode.SemiAuto) = False Then
        '                Return False
        '            End If
        '        Else

        '            If Set_AutoRange_PD(nCh, AutoMode.Auto) = False Then
        '                Return False
        '            End If
        '        End If

        '        If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '            Application.DoEvents()
        '            Thread.Sleep(600)

        '            If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
        '                ' LogMsg("Initalize Set Photo Range Fail")
        '                Return False
        '            End If
        '        End If
        '    End If

        '    Application.DoEvents()
        '    Thread.Sleep(50)

        '    If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

        '        Application.DoEvents()
        '        Thread.Sleep(600)

        '        If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then
        '            '  LogMsg("Initalize Set Probe Mode Fail")
        '            Return False
        '        End If
        '    End If
        '    'Manual Range Set
        'Else

        '    If Set_AutoRange_Current(nCh, AutoMode.Manual) = False Then
        '        Return False
        '    End If

        '    If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then

        '        Application.DoEvents()
        '        Thread.Sleep(600)

        '        If Set_CurrentRange(nCh, settings.nCurrentRangeIndex) = False Then
        '            Return False
        '        End If
        '    End If

        '    If biassetting.source.Mode = eMode.ePC Or biassetting.source.Mode = eMode.ePCV Or biassetting.source.Mode = eMode.ePV Then

        '        If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then
        '            Return False
        '        End If

        '        If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '            Application.DoEvents()
        '            Thread.Sleep(600)

        '            If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '                ' LogMsg("Initalize Set Photo Range Fail")

        '                Return False
        '            End If
        '        End If
        '    Else

        '        If settings.nSemiAutoRangeIndex = eSemiAutoMode._On Then

        '            If Set_AutoRange_PD(nCh, AutoMode.SemiAuto) = False Then

        '                Return False

        '            End If
        '        Else
        '            If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then

        '                Return False

        '            End If
        '        End If

        '        If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '            Application.DoEvents()

        '            Thread.Sleep(600)

        '            If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then

        '                ' LogMsg("Initalize Set Photo Range Fail")

        '                Return False

        '            End If

        '        End If

        '    End If

        '    Application.DoEvents()

        '    Thread.Sleep(50)

        '    If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

        '        Application.DoEvents()

        '        Thread.Sleep(600)

        '        If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then

        '            '  LogMsg("Initalize Set Probe Mode Fail")

        '            Return False

        '        End If

        '    End If

        '    Application.DoEvents()

        '    Thread.Sleep(50)

        'End If

        'Return True

    End Function
    Public Overrides Function InitializeM6000IVL(ByVal nCh As Integer, ByVal settings As frmChannelRangeSetttings.sRangeSettings) As Boolean ' ByVal settings As ucSequenceBuilder.sRcpCommon) As Boolean

        'Manual Range Settings

        If Set_AutoRange_PD(nCh, AutoMode.Manual) = False Then
            Return False
        End If

        If Set_AutoRange_Current(nCh, AutoMode.Manual) = False Then
            Return False
        End If

        If Set_CurrentRange(nCh, settings.nCurrentRangeIVLIndex) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If Set_CurrentRange(nCh, settings.nCurrentRangeIVLIndex) = False Then
                Return False
            End If
        End If

        If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If Set_PhotoRange(nCh, settings.nPhotoRangeIndex) = False Then
                ' LogMsg("Initalize Set Photo Range Fail")
                Return False
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(50)

        If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If Set_ProbeMode(nCh, settings.nProbeIndex) = False Then
                '  LogMsg("Initalize Set Probe Mode Fail")
                Return False
            End If
        End If

        Return True
    End Function
    Public Overloads Function InitializeM6000() As Boolean
        Dim nBrdCnt As Integer = 0
        Dim nChCnt As Integer = 0

        ReDim b_calread(m_numChannel - 1)
        For nBrdCnt = 0 To m_numBoard - 1

            Dim retbrdInfo As CDevM6000CommonNode.sBoardRangeInfo = Nothing

            If Get_BoardRangeInfo(nBrdCnt, retbrdInfo) = True Then
                m_sRange(nBrdCnt) = retbrdInfo
            End If

            For nChCnt = 0 To 3
                Dim nRealCh As Integer = nBrdCnt * 4 + nChCnt
                Application.DoEvents()
                Thread.Sleep(10)

                If Set_Calibration_Eanble(nRealCh, CDevM6000CommonNode.eCalibrationEnable._ALL_ENABLE) = False Then
                    b_calread(nRealCh) = False
                Else
                    b_calread(nRealCh) = True
                    '  Return False
                End If

            Next
        Next

        Return True
    End Function

    Public Overrides Function ReadCalibrationData() As Boolean

        Dim nBrdCnt As Integer = 0
        Dim nChCnt As Integer = 0
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim nCount As Integer = 0
        'nTotalCH = 0

        ReDim b_calread(m_numChannel - 1)

        'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
        ReDim CalParam.RV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RV_offset(m_numBoard - 1, 3)

        ReDim CalParam.SDCV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SDCV_offset(m_numBoard - 1, 3)

        ReDim CalParam.SACV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SACV_offset(m_numBoard - 1, 3)


        'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
        ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RC_offset(m_numBoard - 1, 3)

        ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RC_offset(m_numBoard - 1, 3)

        ReDim CalParam.BR_ratio(m_numBoard - 1, 3)
        ReDim CalParam.BR_offset(m_numBoard - 1, 3)

        ReDim CalParam.SDCC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SDCC_offset(m_numBoard - 1, 3)

        ReDim CalParam.SACC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SACC_offset(m_numBoard - 1, 3)

        'CMRR
        ReDim CalParam.CMRR_ratio(m_numBoard - 1, 3)
        ReDim CalParam.CMRR_offset(m_numBoard - 1, 3)

        Do
            'Application.DoEvents() 'YSR_

            For nBrdCnt = 0 To m_numBoard - 1
                For nChCnt = 0 To 3
                    Dim TempBuff() As String = Nothing
                    '*****************************************************************************************************
                    'Calibration (Cal_GetParam)
                    '채널정보 채크
                    'sendMsgSok1("[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")")
                    'frmMainWnd.stbString.Text = "[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")"

                    'Get RV
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_RV(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If

                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If


                    'Get RC
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "0" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_RC(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If

                    'Get BRIGHT
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_BRIGHT & "](" & nBrdCnt & "," & nChCnt & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_BRIGHT(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If

                    'Get SDCV
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "0" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SDCV(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If

                    'Get SDCC
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "0" & "," & "0" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SDCC(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If

                    '(Pulse Amplitude 관련)
                    'Get SACV
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SACV(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If

                    'Get SACC
                    sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & "," & "0" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_SACC(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If
                    'Get CMRR
                    sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        If Parse_Get_Param_CMRR(sRcvData, nBrdCnt, nChCnt) = False Then
                            b_calread(nCount) = False
                        Else
                            b_calread(nCount) = True
                        End If
                    Else
                        b_calread(nCount) = False
                        ' Return False
                    End If
                    ''*****************************************************************************************************
                    nCount += 1
                Next
            Next


            Thread.Sleep(1)

            Exit Do
        Loop

        '데이터 저장
        SaveCalibrationDatas()

        Return True
    End Function
    'Public Overrides Function ReadCalibrationData() As Boolean

    '    Dim nBrdCnt As Integer = 0
    '    Dim nChCnt As Integer = 0
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing
    '    'nTotalCH = 0

    '    'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
    '    ReDim CalParam.RV_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.RV_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.SDCV_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.SDCV_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.SACV_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.SACV_offset(m_numBoard - 1, 3)


    '    'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
    '    ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.RC_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.RC_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.BR_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.BR_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.SDCC_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.SDCC_offset(m_numBoard - 1, 3)

    '    ReDim CalParam.SACC_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.SACC_offset(m_numBoard - 1, 3)

    '    'CMRR
    '    ReDim CalParam.CMRR_ratio(m_numBoard - 1, 3)
    '    ReDim CalParam.CMRR_offset(m_numBoard - 1, 3)

    '    Do
    '        'Application.DoEvents() 'YSR_

    '        For nBrdCnt = 0 To m_numBoard - 1

    '            For nChCnt = 0 To 3

    '                '*****************************************************************************************************
    '                'Calibration (Cal_GetParam)
    '                '채널정보 채크
    '                'sendMsgSok1("[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")")
    '                'frmMainWnd.stbString.Text = "[" & MSG_BOARD_GET_CHANNEL_INFO & "](" & nBrdCnt & "," & nChCnt & ")"

    '                'Get RV
    '                sSendCommand = ("[" & MSG_BOARD_GET_RCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_RV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get RC
    '                sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "0" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_RC(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get BRIGHT
    '                sSendCommand = ("[" & MSG_BOARD_GET_RCALB_BRIGHT & "](" & nBrdCnt & "," & nChCnt & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_BRIGHT(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get SDCV
    '                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "0" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_SDCV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get SDCC
    '                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "0" & "," & "0" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_SDCC(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If



    '                '(Pulse Amplitude 관련)
    '                'Get SACV
    '                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_VOLT & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_SACV(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get SACC
    '                sSendCommand = ("[" & MSG_BOARD_GET_SCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & "," & "0" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_SACC(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                'Get CMRR
    '                sSendCommand = ("[" & MSG_BOARD_GET_RCALB_CURR1 & "](" & nBrdCnt & "," & nChCnt & "," & "1" & ")")
    '                If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
    '                    If Parse_Get_Param_CMRR(sRcvData, nBrdCnt, nChCnt) = False Then Return False
    '                Else
    '                    Return False
    '                End If

    '                ''*****************************************************************************************************

    '            Next
    '        Next


    '        Thread.Sleep(1)

    '        Exit Do
    '    Loop

    '    '데이터 저장
    '    SaveCalibrationDatas()

    '    Return True
    'End Function


#Region "Parser"

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

    Private Function Parse_Get_Param_RC(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        '  in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length >= 2 Then
            CalParam.RC_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.RC_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
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

    Private Function Parse_Get_Param_SDCC(ByVal in_strParam As String, ByVal in_Brd As Integer, ByVal in_CH As Integer) As Boolean

        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        ' If in_strParam.Length >= 11 Then
        ' in_strParam = in_strParam.Substring(11)
        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")
        If arrBuf.Length >= 3 Then
            CalParam.SDCC_ratio(in_Brd, in_CH) = arrBuf(arrBuf.Length - 2)
            CalParam.SDCC_offset(in_Brd, in_CH) = arrBuf(arrBuf.Length - 1)
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


#End Region


#Region "Measure"


#End Region

#Region "Calibration Data Save/Load"

    Dim sCalData_FileTitle As String = "M600 Calibration Data"
    Dim sCalData_FileVersion As String = "1.0.0"

    Private Sub SaveCalibrationDatas()

        Dim saver As New CM600CalDataINI(g_sFilePath_M600CalData)

        saver.SaveIniValue(CM600CalDataINI.eSecID._FileInfo, CM600CalDataINI.eKeyID._FILEINFO_TITLE, sCalData_FileTitle)
        saver.SaveIniValue(CM600CalDataINI.eSecID._FileInfo, CM600CalDataINI.eKeyID._FILEINFO_VERSION, sCalData_FileVersion)

        Dim cntCalData As Integer = 0

        saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_DEV_ID, m_ID)

        For nBrdCnt = 0 To m_numBoard - 1
            For nChCnt = 0 To 3

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_BR_OFFSET, cntCalData, CalParam.BR_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_BR_RATIO, cntCalData, CalParam.BR_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_CMRR_OFFSET, cntCalData, CalParam.CMRR_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_CMRR_RATIO, cntCalData, CalParam.CMRR_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RC_OFFSET, cntCalData, CalParam.RC_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RC_RATIO, cntCalData, CalParam.RC_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RV_OFFSET, cntCalData, CalParam.RV_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RV_RATIO, cntCalData, CalParam.RV_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACC_OFFSET, cntCalData, CalParam.SACC_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACC_RATIO, cntCalData, CalParam.SACC_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACV_OFFSET, cntCalData, CalParam.SACV_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACV_RATIO, cntCalData, CalParam.SACV_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCC_OFFSET, cntCalData, CalParam.SDCC_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCC_RATIO, cntCalData, CalParam.SDCC_ratio(nBrdCnt, nChCnt))

                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCV_OFFSET, cntCalData, CalParam.SDCV_offset(nBrdCnt, nChCnt))
                saver.SaveIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCV_RATIO, cntCalData, CalParam.SDCV_ratio(nBrdCnt, nChCnt))

                cntCalData += 1
            Next

        Next

    End Sub

    Private Function LoadCalibrationDatas() As Boolean

        Dim loader As New CM600CalDataINI(g_sFilePath_M600CalData)

        Dim sTemp As String

        sTemp = loader.LoadIniValue(CM600CalDataINI.eSecID._FileInfo, CM600CalDataINI.eKeyID._FILEINFO_TITLE)
        If sCalData_FileTitle <> sTemp Then Return False

        sTemp = loader.LoadIniValue(CM600CalDataINI.eSecID._FileInfo, CM600CalDataINI.eKeyID._FILEINFO_VERSION)
        If sCalData_FileVersion <> sTemp Then Return False

        sTemp = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_DEV_ID)

        If CStr(m_ID) <> sTemp Then Return False

        ReDim CalParam.RV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RV_offset(m_numBoard - 1, 3)

        ReDim CalParam.SDCV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SDCV_offset(m_numBoard - 1, 3)

        ReDim CalParam.SACV_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SACV_offset(m_numBoard - 1, 3)


        'ReDim Cal_GetParam1.RLC_Disp(in_NumBoard - 1, 3)
        ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RC_offset(m_numBoard - 1, 3)

        ReDim CalParam.RC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.RC_offset(m_numBoard - 1, 3)

        ReDim CalParam.BR_ratio(m_numBoard - 1, 3)
        ReDim CalParam.BR_offset(m_numBoard - 1, 3)

        ReDim CalParam.SDCC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SDCC_offset(m_numBoard - 1, 3)

        ReDim CalParam.SACC_ratio(m_numBoard - 1, 3)
        ReDim CalParam.SACC_offset(m_numBoard - 1, 3)

        'CMRR
        ReDim CalParam.CMRR_ratio(m_numBoard - 1, 3)
        ReDim CalParam.CMRR_offset(m_numBoard - 1, 3)

        Dim cntCalData As Integer = 0

        For nBrdCnt = 0 To m_numBoard - 1
            For nChCnt = 0 To 3

                CalParam.BR_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_BR_OFFSET, cntCalData)
                CalParam.BR_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_BR_RATIO, cntCalData)

                CalParam.CMRR_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_CMRR_OFFSET, cntCalData)
                CalParam.CMRR_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_CMRR_RATIO, cntCalData)

                CalParam.RC_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RC_OFFSET, cntCalData)
                CalParam.RC_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RC_RATIO, cntCalData)

                CalParam.RV_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RV_OFFSET, cntCalData)
                CalParam.RV_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_RV_RATIO, cntCalData)

                CalParam.SACC_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACC_OFFSET, cntCalData)
                CalParam.SACC_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACC_RATIO, cntCalData)

                CalParam.SACV_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACV_OFFSET, cntCalData)
                CalParam.SACV_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SACV_RATIO, cntCalData)

                CalParam.SDCC_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCC_OFFSET, cntCalData)
                CalParam.SDCC_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCC_RATIO, cntCalData)

                CalParam.SDCV_offset(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCV_OFFSET, cntCalData)
                CalParam.SDCV_ratio(nBrdCnt, nChCnt) = loader.LoadIniValue(CM600CalDataINI.eSecID._Device_Cal_Data, m_ID, CM600CalDataINI.eKeyID._DEV_CAL_DATA_SDCV_RATIO, cntCalData)

                cntCalData += 1
            Next

        Next

        Return True
    End Function

#End Region


    Public Function TestEndCheck(ByVal nCh As Integer, ByVal SystemStatus As String, ByVal EndPara As String) As Boolean

        If CDbl(EndPara) = 0 Then
            Return True
        End If

        If CDbl(SystemStatus) <= CDbl(EndPara) Then
            Return False
        End If
        Return True
    End Function

#Region "Setting"

    Public Overrides Function ACK() As Boolean

        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        '1. 채널 Reset(종료). [43]

        sSendCommand = ("[" & MSG_POLARONIX_GET_INFO & "]")    '& " " & "(" & CStr(nBrdNum) & "," & CStr(nCh) & ")"
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
            If sRcvData Is Nothing Then Return False
        Else
            ' LogMsg("ACK Fail")
            Return False
        End If

        Return True
    End Function

    Public Overrides Function CellON(ByVal nCh As Integer) As Boolean

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        '1. 채널 Reset(종료). [43]

        If Set_Switch(nCh, True) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If Set_Switch(nCh, True) = False Then
                Return False
            End If
        End If
        ' Return False

        Return True
    End Function

    Public Overrides Function CellOFF(ByVal nCh As Integer) As Boolean

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        If Set_Switch(nCh, False) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If Set_Switch(nCh, False) = False Then
                Return False
            End If
        End If


        Application.DoEvents()
        Thread.Sleep(100)

        If Reset(nCh) = False Then Return False

        Return True
    End Function

    Public Overrides Function Reset(ByVal nCh As Integer) As Boolean

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
                '  LogMsg("Reset cvtChToM6000Info")
                Return False
            End If
        End If
        '1. 채널 Reset(종료). [43]

        sSendCommand = ("[" & MSG_BOARD_SET_RESET & "]" & " " & "(" & CStr(nBrdNum) & "," & CStr(nBrdPerCh) & ")")
        'LogMsg("Reset Send msg :" & sSendCommand)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Reset Send To String Fail")
                Return False
            End If
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                If rcvDataSuccess(sRcvData) = False Then
                    '  LogMsg("(Reset Fail)")
                    Return False
                End If
            End If
        End If
        '  fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Set_Switch Data Read Fail)")
        'LogMsg("(Reset Fail)")
        'Return False
        '  LogMsg("Reset Recieve :" & sRcvData)
        Return True
    End Function

    Public Function HWRunStop(ByVal nCh As Integer, ByRef Out_Data As eONOFF) As Boolean
        Dim nBrdNum As Integer
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sRcvDataBuff As String = Nothing
        ' Dim GetData As eONOFF = Nothing

        ' CH ON/OFF GET [35] Reset 하면 의미없다 쓰지말자?
        sSendCommand = ("[" & MSG_BOARD_GET_CALC_BRIGHT_PARAM & "]" & " " & "(" & CStr(nBrdNum) & "," & CStr(nCh) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else
            sRcvDataBuff = sRcvData.Substring(sRcvData.Length - 3, 1)
        End If

        Select Case sRcvDataBuff
            Case sRcvDataBuff = CStr(0)
                Out_Data = eONOFF.eOFF
            Case sRcvDataBuff = CStr(1)
                Out_Data = eONOFF.eON
            Case Else
                Return False
        End Select

        Return True
    End Function

#Region "Bias Setting"

    Public Overrides Function BiasSettings(ByVal nCh As Integer, ByVal in_Mode As eMode, ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFreq As Double, ByVal dDuty As Double, ByRef retSetInfo As eRetBiasSet) As Boolean
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If
        Select Case in_Mode
            Case eMode.eCV
                If Meas_CV(nHwNum, nBrdNum, nBrdPerCh, dBias) <> eRetBiasSet._OK Then
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Meas_CV(nHwNum, nBrdNum, nBrdPerCh, dBias) <> eRetBiasSet._OK Then
                        Return False
                    End If
                Else
                    retSetInfo = Meas_CV(nHwNum, nBrdNum, nBrdPerCh, dBias)
                End If
            Case eMode.eCC
                If Meas_CC(nHwNum, nBrdNum, nBrdPerCh, dBias) <> eRetBiasSet._OK Then
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Meas_CC(nHwNum, nBrdNum, nBrdPerCh, dBias) <> eRetBiasSet._OK Then
                        Return False
                    End If
                Else
                    retSetInfo = Meas_CC(nHwNum, nBrdNum, nBrdPerCh, dBias)
                End If
            Case eMode.ePV
                '    retSetInfo = Meas_PV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                If Meas_PV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Meas_PV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                        Return False
                    End If
                Else
                    retSetInfo = Meas_PV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                End If
            Case eMode.ePC
                'retSetInfo = Meas_PC(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                If Meas_PC(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Meas_PC(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                        Return False
                    End If
                Else
                    retSetInfo = Meas_PC(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                End If
            Case eMode.ePCV
                '  retSetInfo = Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                If Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty) <> eRetBiasSet._OK Then
                        Return False
                    End If
                Else
                    retSetInfo = Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                End If
        End Select

        If retSetInfo <> eRetBiasSet._OK Then
            Return False
        End If
        Application.DoEvents()
        Thread.Sleep(30)
        Return True
    End Function

    Public Overrides Function BiasSettings(ByVal nCh As Integer, ByVal Settings As sSettingParams, ByRef retSetInfo As eRetBiasSet) As Boolean
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        With Settings.source
            'Select Case Settings.source.Mode
            '    Case eMode.eCV
            '        retSetInfo = Meas_CV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue)
            '    Case eMode.eCC
            '        retSetInfo = Meas_CC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue)
            '    Case eMode.ePV
            '        retSetInfo = Meas_PV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
            '    Case eMode.ePC
            '        retSetInfo = Meas_PC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
            '    Case eMode.ePCV
            '        retSetInfo = Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
            'End Select
            Select Case Settings.source.Mode
                Case eMode.eCV
                    If Meas_CV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue) <> eRetBiasSet._OK Then
                        Application.DoEvents()
                        Thread.Sleep(600)
                        If Meas_CV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue) <> eRetBiasSet._OK Then
                            Return False
                        End If
                        'Else
                        '    retSetInfo = Meas_CV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue)
                    End If
                Case eMode.eCC
                    If Meas_CC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue) <> eRetBiasSet._OK Then
                        Application.DoEvents()
                        Thread.Sleep(600)
                        If Meas_CC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue) <> eRetBiasSet._OK Then
                            Return False
                        End If
                        'Else
                        '    retSetInfo = Meas_CC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue)
                    End If
                Case eMode.ePV
                    '    retSetInfo = Meas_PV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                    If Meas_PV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                        Application.DoEvents()
                        Thread.Sleep(600)
                        If Meas_PV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                            Return False
                        End If
                        'Else
                        '    retSetInfo = Meas_PV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
                    End If
                Case eMode.ePC
                    'retSetInfo = Meas_PC(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                    If Meas_PC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                        Application.DoEvents()
                        Thread.Sleep(600)
                        If Meas_PC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                            Return False
                        End If
                        'Else
                        '    retSetInfo = Meas_PC(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
                    End If
                Case eMode.ePCV
                    '  retSetInfo = Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, dBias, dAmplitude, dFreq, dDuty)
                    If Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                        Application.DoEvents()
                        Thread.Sleep(600)
                        If Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty) <> eRetBiasSet._OK Then
                            Return False
                        End If
                        'Else
                        '    retSetInfo = Meas_PCV(nHwNum, nBrdNum, nBrdPerCh, .dBiasValue, .dAmplitude, .Pulse.dFrequency, .Pulse.dDuty)
                    End If
            End Select
        End With

        m_Settings(nCh) = Settings

        'If retSetInfo <> eRetBiasSet._OK Then
        '    Return False
        'End If
        Application.DoEvents()
        Thread.Sleep(30)
        Return True
    End Function


    Private Function Meas_CV(ByVal nHwNum As Integer, ByVal nBoard As Integer, ByVal nCH As Object, ByVal dBias As Double) As eRetBiasSet                              ', ByVal Set_Amplitude As Double)

        Dim Set_Bias1 As Double
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing


        '1. CV 모드를 선택한다. [47]
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & CStr(nBoard) & "," & CStr(nCH) & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            ' LogMsg("Meas_CV (_SET_MODE_Failure)")
            Return eRetBiasSet._SET_MODE_Failure
        End If
        'LogMsg("Select CV Mode   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_MODE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_MODE_Failure
                End If
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        '2. 전압값을 설정한다. [44]
        'If CalParam.SDCV_ratio(nBoard, nCH) = Nothing Or CalParam.SDCV_offset(nBoard, nCH) = Nothing Then Return False

        Set_Bias1 = dBias '* CDbl(CalParam.SDCV_ratio(nBoard, nCH)) * 1000 + CDbl(CalParam.SDCV_offset(nBoard, nCH))
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & nBoard & "," & CStr(nCH) & "," & CStr(Set_Bias1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                'LogMsg("Select CV Value+" & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
                'LogMsg("Meas_CV (_SET_VALUE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
            End If
        End If
        'LogMsg("Select CV Value" & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & "           VALUE : " & Set_Bias1 & "      " & sRcvData)
        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                'LogMsg("Select CV Value+" & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
                'LogMsg("Meas_CV (_SET_VALUE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        ''3. 스위치를 ON한다. [46]
        Application.DoEvents()
        Thread.Sleep(10)

        sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & CStr(nBoard) & "," & CStr(nCH) & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                'LogMsg("Switch On2" & nCH + 1 & sRcvData)
                'LogMsg("Meas_CV (_SET_SWITCH_Failure)")
                Return eRetBiasSet._SET_SWITCH_Failure
            End If
        End If

        'LogMsg("Switch On" & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                'LogMsg("Switch On+" & nCH + 1 & sRcvData)
                'LogMsg("Meas_CV (_SET_SWITCH_Failure)")
                Return eRetBiasSet._SET_SWITCH_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_SWITCH_Failure
                End If
            End If
        End If

        Return eRetBiasSet._OK
    End Function


    Private Function Meas_PV(ByVal nHwNum As Integer, ByVal Set_Board As Object, ByVal Set_CH As Object, _
                           ByVal Set_Bias_Value As Double, ByVal Set_Amplitude As Double, _
                           ByVal Set_Frequency As Double, ByVal Set_Duty As Double) As eRetBiasSet

        Dim Set_Bias1 As Double
        Dim Set_Amp1 As Double
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        '1. CV 모드를 선택한다. [47]
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Application.DoEvents()
        Thread.Sleep(10)


        Set_Bias1 = Set_Bias_Value '* CDbl(CalParam.SACV_ratio(Set_Board, Set_CH)) * 1000 + CDbl(CalParam.SACV_offset(Set_Board, Set_CH))
        Set_Amp1 = Set_Amplitude '* CDbl(CalParam.SDCV_ratio(Set_Board, Set_CH)) * 1000 + CDbl(CalParam.SDCV_offset(Set_Board, Set_CH))

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_MODE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_MODE_Failure
                End If
            End If
        End If

        '2. Bias(V) 값을 설정한다. [44]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias_Value) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        '3. Amplitude(V) 값을 설정한다. [42]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS_2 & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Amp1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        '4. 주파수, 듀티값을 설정한다. [45]
        sSendCommand = ("[" & MSG_BOARD_SET_PULSE & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Frequency) & "," & CStr(100 - CDbl(Set_Duty)) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        '5. 스위치를 ON한다. [46]
        sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_SWITCH_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_SWITCH_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_SWITCH_Failure
                End If
            End If
        End If

        Return eRetBiasSet._OK
    End Function

    'Private Function Meas_CC(ByVal nHwNum As Integer, ByVal Set_Board As Integer, ByVal Set_CH As Integer, _
    '                     ByVal Set_Bias_Value As Double) As Boolean ', ByVal Set_Amplitude As Double)

    '    Dim Set_Bias1 As Double
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing
    '    Dim Set_PreBias As Double = 0.05


    '    '1. CC 모드를 선택한다. [47]
    '    sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '2. 0mA 설정
    '    Set_Bias1 = Set_PreBias * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '3. delay 100
    '    Thread.Sleep(100)

    '    '4. 스위치를 ON한다. [46]
    '    sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '5. Delay 500
    '    Thread.Sleep(500)

    '    '6. 전류값을 설정한다. [44]
    '    Set_Bias1 = Set_Bias_Value * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If



    '    Return True
    'End Function

    'Private Function Meas_CC(ByVal nHwNum As Integer, ByVal Set_Board As Integer, ByVal Set_CH As Integer, _
    '                      ByVal Set_Bias_Value As Double) As Boolean ', ByVal Set_Amplitude As Double)

    '    Dim Set_Bias1 As Double
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing


    '    '3. CC 모드를 선택한다. [47]
    '    sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '4. 전류값을 설정한다. [44]
    '    Set_Bias1 = Set_Bias_Value * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '5. 스위치를 ON한다. [46]
    '    sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    Return True
    'End Function

    'Test1
    Private Function Meas_CC(ByVal nHwNum As Integer, ByVal Set_Board As Integer, ByVal Set_CH As Integer, _
                          ByVal Set_Bias_Value As Double) As eRetBiasSet ', ByVal Set_Amplitude As Double)

        Dim Set_Bias1 As Double
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''1. CC 모드를 선택한다. [47]
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            'LogMsg("_SET_MODE_Failure")
            Return eRetBiasSet._SET_MODE_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_MODE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_MODE_Failure
                End If
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(10)


        '2. 전류값을 설정한다. [44]
        Set_Bias1 = Set_Bias_Value * 0.001 '* CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            ' LogMsg("_SET_VALUE_Failure")
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        '3. 스위치를 ON한다. [46]
        sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            'LogMsg("_SET_SWITCH_Failure")
            Return eRetBiasSet._SET_SWITCH_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_SWITCH_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_SWITCH_Failure
                End If
            End If
        End If

        Return eRetBiasSet._OK
    End Function

    'Test2
    'Private Function Meas_CC(ByVal nHwNum As Integer, ByVal Set_Board As Integer, ByVal Set_CH As Integer, _
    '                      ByVal Set_Bias_Value As Double) As Boolean ', ByVal Set_Amplitude As Double)

    '    Dim Set_Bias1 As Double
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing


    '    '1. 전류값을 설정한다. [44]
    '    Set_Bias1 = Set_Bias_Value * CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
    '    sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ",0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '2. CV 모드를 선택한다. [47]
    '    sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '3. 스위치를 ON한다. [46]
    '    sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    '4. CC 모드를 선택한다. [47]
    '    sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
    '    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If



    '    Return True
    'End Function

    Private Function Meas_PC(ByVal nHwNum As Integer, ByVal Set_Board As Object, ByVal Set_CH As Object, _
                           ByVal Set_Bias_Value As Double, ByVal Set_Amplitude As Double, _
                           ByVal Set_Frequency As Double, ByVal Set_Duty As Double) As eRetBiasSet

        Dim Set_Bias1 As Double
        Dim Set_Amp1 As Double
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        '1. CC모드 선택[47]
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "0)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_MODE_Failure
        End If

        Set_Bias1 = Set_Bias_Value * 0.001
        Set_Amp1 = Set_Amplitude * 0.001

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_MODE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_MODE_Failure
                End If
            End If
        End If

        '2. Bias(V) 값을 설정한다. [44]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        '3. Amplitude(V) 값을 설정한다. [42]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS_2 & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Amp1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If


        '4. 주파수, 듀티값을 설정한다. [45]
        sSendCommand = ("[" & MSG_BOARD_SET_PULSE & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Frequency) & "," & CStr(100 - CDbl(Set_Duty)) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If


        Application.DoEvents()
        Thread.Sleep(10)

        '5. 스위치를 ON한다. [46]
        sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_SWITCH_Failure
        End If

        If rcvDataSuccess(sRcvData) = False Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return eRetBiasSet._SET_SWITCH_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_SWITCH_Failure
                End If
            End If
        End If

        Return eRetBiasSet._OK
    End Function

    Private Function Meas_PCV(ByVal nHwNum As Integer, ByVal Set_Board As Object, ByVal Set_CH As Object, _
                            ByVal Set_Bias_Value As Double, ByVal Set_Amplitude As Double, _
                            ByVal Set_Frequency As Double, ByVal Set_Duty As Double) As eRetBiasSet

        Dim Set_Bias1 As Double
        Dim Set_Amp1 As Double
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing


        '1. PCV 모드를 선택한다. [47]   - Mode 2
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & Set_Board & "," & Set_CH & "," & "2)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_MODE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_MODE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_MODE_Failure
                End If
            End If
        End If

        Set_Bias1 = Set_Bias_Value 'Plus에서는 V단위 그대로 보내야함.  '* CDbl(CalParam.SACV_ratio(Set_Board, Set_CH)) * 1000 + CDbl(CalParam.SACV_offset(Set_Board, Set_CH))
        Set_Amp1 = Set_Amplitude / 1000 'Plus에서는 A단위로 변환해서 보내야함'* CDbl(CalParam.SDCC_ratio(Set_Board, Set_CH)) + CDbl(CalParam.SDCC_offset(Set_Board, Set_CH))
        '2. Bias(V) 값을 설정한다. [44]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Bias1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If


        '3. Amplitude(V) 값을 설정한다. [42]
        sSendCommand = ("[" & MSG_BOARD_SET_BIAS_2 & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Amp1) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If


        '4. 주파수, 듀티값을 설정한다. [45]
        sSendCommand = ("[" & MSG_BOARD_SET_PULSE & "]" & "(" & Set_Board & "," & Set_CH & "," & CStr(Set_Frequency) & "," & CStr(100 - CDbl(Set_Duty)) & ")")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_VALUE_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_VALUE_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_VALUE_Failure
                End If
            End If
        End If

        '5. 스위치를 ON한다. [46]
        sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & Set_Board & "," & Set_CH & "," & "1)")
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return eRetBiasSet._SET_SWITCH_Failure
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(100)
            'LogMsg("Select CV Mode+   " & "Board :  " & nBoard & "  Ch :  " & nCH + 1 & sRcvData)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("Meas_CV (_SET_MODE_Failure)")
                Return eRetBiasSet._SET_SWITCH_Failure
                If rcvDataSuccess(sRcvData) = False Then
                    Return eRetBiasSet._SET_SWITCH_Failure
                End If
            End If
        End If

        Return eRetBiasSet._OK
    End Function

    Private Function chkRcvData(ByRef sRcvData As String) As Boolean

        Dim ack As String = Nothing
        Dim doexit As Boolean

        Dim nTimeOut As Integer

        doexit = False

        Do
            'Application.DoEvents()
            ' Thread.Sleep(5)

            'SyncLock cSocket.m_errQueue.SyncRoot

            '    If cSocket.m_rcvQueue.Count <> 0 Then
            '        ack = cSocket.m_rcvQueue.Dequeue()
            '        doexit = True
            '    End If

            'End SyncLock

            If doexit Then
                Exit Do
            End If

            nTimeOut = nTimeOut + 1

            If nTimeOut > 1000 Then
                Return False
            End If

        Loop

        sRcvData = ack.Clone()

        Return True

    End Function



#End Region

#Region "? 모르겠음"

    Public Function cvtChToM6000Info(ByVal nCh As Integer, ByRef nHWNum As Integer, ByRef nBrdNum As Integer, ByRef nChPerBrd As Integer) As Boolean
        nHWNum = cvtChToM6000HWNum(nCh)

        nBrdNum = cvtChToM6000BrdNum(nCh)

        nChPerBrd = cvtChToM6000ChPerBrd(nCh)
        If nChPerBrd = -1 Then
            Return False
        End If

        Return True
    End Function

    Private Function cvtChToM6000HWNum(ByVal nCh As Integer) As Integer
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

    Private Function cvtChToM6000BrdNum(ByVal nCh As Integer) As Integer
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

    Private Function cvtChToM6000ChPerBrd(ByVal nCh As Integer) As Integer
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


#End Region

#Region "Get"

    Public Overrides Function Measurement(ByVal nCh As Integer, ByVal in_Mode As eMode, _
                                   ByRef measHV As String, ByRef measLV As String, ByRef measHI As String, ByRef measLI As String, _
                                    ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        Select Case in_Mode
            Case eMode.eCV
                If Get_MeasCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, nLimitChk, ChkBoardError) = False Then
                    measLV = "0"
                    measLI = "0"
                    Return False
                End If
            Case eMode.eCC
                If Get_MeasCC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, nLimitChk, ChkBoardError) = False Then
                    measLV = "0"
                    measLI = "0"
                    Return False
                End If
            Case eMode.ePV
                If Get_MeasPV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, nLimitChk, ChkBoardError) = False Then
                    Return False
                End If
            Case eMode.ePC
                If Get_MeasPC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, nLimitChk, ChkBoardError) = False Then
                    Return False
                End If
            Case eMode.ePCV
                If Get_MeasPCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, nLimitChk, ChkBoardError) = False Then
                    Return False
                End If
        End Select

        Return True
    End Function

    Public Overrides Function Measurement(ByVal nCh As Integer, _
                               ByRef measHV As String, ByRef measLV As String, ByRef measHI As String, ByRef measLI As String, _
                                ByRef meas_PDCurr As String, ByRef sLimichk As String, ByRef ChkBoardError As Boolean) As Boolean
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        Select Case m_Settings(nCh).source.Mode
            Case eMode.eCV
                If Get_MeasCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                    measLV = "0"
                    measLI = "0"
                    '  LogMsg("CH : " & nCh + 1 & " MeasureMent Fail (Get_MeasCV)")
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Get_MeasCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                        measLV = "0"
                        measLI = "0"
                        '  LogMsg("CH : " & nCh + 1 & " MeasureMent Fail (Get_MeasCV)")
                        Return False
                    End If
                End If
            Case eMode.eCC
                If Get_MeasCC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                    measLV = "0"
                    measLI = "0"
                    'LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasCC")
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Get_MeasCC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                        measLV = "0"
                        measLI = "0"
                        ' LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasCC")
                        Return False
                    End If
                End If
            Case eMode.ePV
                If Get_MeasPV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                    'LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPV")
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Get_MeasPV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                        '  LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPV")
                        Return False
                    End If
                End If
            Case eMode.ePC
                If Get_MeasPC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                    ' LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPC")
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Get_MeasPC(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                        '   LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPC")
                        Return False
                    End If
                End If
            Case eMode.ePCV
                If Get_MeasPCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                    ' LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPCV")
                    Application.DoEvents()
                    Thread.Sleep(600)
                    If Get_MeasPCV(nHwNum, nBrdNum, nBrdPerCh, measHV, measHI, measLV, measLI, meas_PDCurr, sLimichk, ChkBoardError) = False Then
                        '   LogMsg("CH : " & nCh + 1 & "MeasureMent Fail (Get_MeasPCV")
                        Return False
                    End If
                End If
        End Select

        Return True
    End Function

    Private Function Get_MeasCV(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, _
                                ByRef meas_V As String, ByRef meas_I As String, ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        'Data Parse -> Meas
        Dim TempV As String = "0"
        Dim TempI As String = "0"
        Dim TempBr As String = "0"
        Dim nOverChk As String = Nothing
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sRcvDataBuff() As String ' 데이터 비교용 버퍼 함수  2013-04-05 승현
        Dim sRcvErrorChkBuff() As String = Nothing

        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

        End If
        '처음에 잘못된 데이터 들어올 수 있으므로 2번 처리한다.
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                Return False
            End If
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, TempV, TempI, TempBr, nOverChk) = False Then

            Application.DoEvents()
            Thread.Sleep(10)

            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
            If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, TempV, TempI, TempBr, nOverChk) = False Then Return False
        End If

        nLimitChk = nOverChk ' Add 리밋체크
        meas_V = TempV.Clone()
        meas_I = TempI.Clone()
        meas_PDCurr = TempBr.Clone()
        Return True

    End Function

    '20080820 : OverCurrent 발생에 따른 예외처리 추가
    Private Function Get_MeasCC(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, _
                                ByRef meas_V As String, ByRef meas_I As String, ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        'GetTemperature(CStr(nCH - 1))

        'Data Parse -> xMeas
        Dim TempV As String = "0"
        Dim TempI As String = "0"
        Dim TempBr As String = "0"
        Dim nOverChk As String = Nothing
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sRcvDataBuff() As String ' 데이터 비교용 버퍼 함수  2013-04-05 승현
        Dim sRcvErrorChkBuff() As String = Nothing

        '첫번째 측정 데이터가 잘못들어올수도 있으므로 두번씩 측정한다.
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
        Application.DoEvents()
        Thread.Sleep(10)

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
        End If
        '처음에 잘못된 데이터 들어올 수 있으므로 2번 처리한다.

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If


        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, TempV, TempI, TempBr, nOverChk) = False Then

            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, TempV, TempI, TempBr, nOverChk) = False Then Return False

        nLimitChk = nOverChk '리밋체크
        meas_V = TempV.Clone()
        meas_I = TempI.Clone()
        meas_PDCurr = TempBr.Clone()
        Return True
    End Function

    Private Function Get_MeasPV(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, _
                                ByRef meas_HV As String, ByRef meas_HI As String, ByRef meas_LV As String, ByRef meas_LI As String, _
                                 ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        'GetTemperature(CStr(nCH - 1))
        Dim High_V As String = "0"
        Dim High_I As String = "0"
        Dim Low_V As String = "0"
        Dim Low_I As String = "0"
        Dim Bright As String = "0"
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim nOverChk As String = Nothing
        Dim sRcvDataBuff() As String ' 데이터 비교용 버퍼 함수  2013-04-05 승현
        Dim sRcvErrorChkBuff() As String = Nothing


        '*** High
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
        Application.DoEvents()
        Thread.Sleep(10)

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
        End If
        '처음에 잘못된 데이터 들어올 수 있으므로 2번 처리한다.

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If

        '데이터 비교문 추가 2013-04-05 승현
        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk) = False Then
            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
            SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk)
        End If

        Bright = 0 'PC/PV/PCV 의 Bright 는 LOW 기준으로 계산으로 HIGH Bright 초기화 2013-02-20 승현

        '*** Low
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
        Application.DoEvents()
        Thread.Sleep(10)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If

        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then
            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(10)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                    ' Return False
                End If
            End If
            If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then Return False
        End If

        nLimitChk = nOverChk '리밋체크
        meas_HV = High_V.Clone()
        meas_HI = High_I.Clone()
        meas_LV = Low_V.Clone()
        meas_LI = Low_I.Clone()
        meas_PDCurr = Bright.Clone()

        Return True
    End Function

    Private Function Get_MeasPC(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, _
                                ByRef meas_HV As String, ByRef meas_HI As String, ByRef meas_LV As String, ByRef meas_LI As String, _
                                ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        Dim High_V As String = "0"
        Dim High_I As String = "0"
        Dim Low_V As String = "0"
        Dim Low_I As String = "0"
        Dim Bright As String = "0"
        Dim nOverChk As String = Nothing

        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sRcvDataBuff() As String ' 데이터 비교용 버퍼 함수  2013-04-05 승현
        Dim sRcvErrorChkBuff() As String = Nothing

        '임시 측정
        '*** High ***
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
        Application.DoEvents()
        Thread.Sleep(10)

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
        End If
        '처음에 잘못된 데이터 들어올 수 있으므로 2번 처리한다.

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If

        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk) = False Then
            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(10)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                    ' Return False
                End If
            End If
            SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk)
        End If

        Bright = 0 'PC/PV/PCV 의 Bright 는 LOW 기준으로 계산으로 HIGH Bright 초기화 2013-02-20 승현

        '*** Low ***
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
        Application.DoEvents()
        Thread.Sleep(10)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If


        '데이터 비교문 추가 2013-04-05 승현
        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then
            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(10)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                    ' Return False
                End If
            End If
            If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then Return False
        End If

        nLimitChk = nOverChk '리밋체크
        meas_HV = High_V.Clone()
        meas_HI = High_I.Clone()
        meas_LV = Low_V.Clone()
        meas_LI = Low_I.Clone()
        meas_PDCurr = Bright.Clone()
        Return True
    End Function

    Private Function Get_MeasPCV(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, _
                                 ByRef meas_HV As String, ByRef meas_HI As String, ByRef meas_LV As String, ByRef meas_LI As String, _
                                 ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        Dim High_V As String = "0"
        Dim High_I As String = "0"
        Dim Low_V As String = "0"
        Dim Low_I As String = "0"
        Dim Bright As String = "0"
        Dim nOverChk As String = Nothing
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sRcvDataBuff() As String ' 데이터 비교용 버퍼 함수  2013-04-05 승현
        Dim sRcvErrorChkBuff() As String = Nothing

        '*** High ***
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
        Application.DoEvents()
        Thread.Sleep(10)

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
        End If
        '처음에 잘못된 데이터 들어올 수 있으므로 2번 처리한다.

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If

        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk) = False Then

            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(100)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                    ' Return False
                End If
            End If
            SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, High_V, High_I, Bright, nOverChk)
        End If

        Bright = 0 'PC/PV/PCV 의 Bright 는 LOW 기준으로 계산으로 HIGH Bright 초기화 2013-02-20 승현


        '*** Low ***
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
        Application.DoEvents()
        Thread.Sleep(10)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                ' Return False
            End If
        End If

        sRcvDataBuff = Split(sRcvData, "]")
        If sRcvDataBuff(0).ToString <> ("[" & MSG_BOARD_GET_CHANNEL_DATA) Then
            Return False
        End If

        If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then
            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_DATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1" & ")")
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(100)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                    ' Return False
                End If
            End If
            If SetParse(nHwNum, nBrdNum, nBrdPerCh, sRcvData, Low_V, Low_I, Bright, nOverChk) = False Then Return False
        End If

        nLimitChk = nOverChk '리밋체크
        meas_HV = High_V.Clone()
        meas_HI = High_I.Clone()
        meas_LV = Low_V.Clone()
        meas_LI = Low_I.Clone()
        meas_PDCurr = Bright.Clone()
        Return True
    End Function

    Private Function SetParse(ByVal nHwNum As Integer, ByVal nBrdNum As Integer, ByVal nChPerBrd As Integer, ByVal in_Data As String, _
                                                                 ByRef Out_V As String, ByRef Out_I As String, ByRef Out_Br As String, ByRef nOverCheck As Integer) As Boolean

        SetParse = False

        Dim TempData As Array

        If in_Data.Length < 20 Then
            Exit Function
        End If

        in_Data = in_Data.TrimEnd(")")

        TempData = Split(in_Data, ",", -1)


        '***** 예외처리부 *****

        If TempData Is Nothing = False Then
            If TempData(1) = " Polaronix IV" Then
                Out_V = "-10000"
                Out_I = "-10000"

                Return False
            End If
            Try
                '***** 예외처리부 끝 *****
                Out_V = TempData(4)
                Out_I = TempData(5)
                Out_Br = TempData(6)
                nOverCheck = TempData(10)
                '*************************************************************************************************************


                '결과값 캘리브레이션
                If nHwNum = 0 Then
                    Out_V = CDbl(Out_V) '* CDbl(CalParam.RV_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RV_offset(nBrdNum, nChPerBrd))
                    Out_I = CDbl(Out_I) ' * CDbl(CalParam.RC_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RC_offset(nBrdNum, nChPerBrd))
                    Out_Br = CDbl(Out_Br) '* CDbl(CalParam.BR_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.BR_offset(nBrdNum, nChPerBrd))
                Else
                    Out_V = CDbl(Out_V) '* CDbl(CalParam.RV_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RV_offset(nBrdNum, nChPerBrd))
                    Out_I = CDbl(Out_I) '* CDbl(CalParam.RC_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RC_offset(nBrdNum, nChPerBrd))
                    Out_Br = CDbl(Out_Br) '* CDbl(CalParam.BR_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.BR_offset(nBrdNum, nChPerBrd))
                End If
            Catch ex As Exception
                Return False
            End Try

            Out_V = Out_V '/ 1000        'mV -> V
            Out_Br = Out_Br '/ 100       'mA -> uA

        Else
            Out_V = "-10000"
            Out_I = "-10000"
            Out_Br = "-10000"
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Function IVL"

    Public Overrides Function GetIVLState(ByVal nCh As Integer, ByRef nState As CDevM6000CommonNode.eIVLState) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If
        Application.DoEvents()
        Thread.Sleep(10)
        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_IVLSTATUS & "]" & "(" & nBrdNum & "," & nBrdPerCh & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        Else

            ' If rcvDataSuccess(sRcvData) = False Then '데이터가 제대로 들어올때만 parse
            '    Return False
            'End If
            'Data Parsing
            If Parse_IVLState(sRcvData, nState) = False Then
                ' LogMsg("(GetIVLState Parse Fail)" & "CH :" & nCh & "      RcvData : " & sRcvData)

                Application.DoEvents()
                Thread.Sleep(600)

                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                Else
                    If Parse_IVLState(sRcvData, nState) = False Then
                        Return False
                        ' fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(GetIVLState Parse Fail)")

                        ' communicator.Communicator.SendToString(sSendCommand, sRcvData)
                    Else
                        'LogMsg("GetIVLState Recieve :" & sRcvData)
                    End If
                    ' LogMsg("(GetIVLState Parse Fail)" & "CH :" & nCh & "RcvData : " & sRcvData)
                    ' If Parse_IVLState(sRcvData, nState) = False Then Return False

                    '  Loop Until Parse_IVLState(sRcvData, nState) = True
                End If
            End If
        End If

        '   nState = Status
        Return True

        Application.DoEvents()
        Thread.Sleep(50)
    End Function

    Public Function Parse_IVLState(ByVal in_strParam As String, ByRef nRetState As CDevM6000CommonNode.eIVLState) As Boolean

        Dim arrBuf As Array

        in_strParam = in_strParam.TrimEnd(")")
        arrBuf = in_strParam.Split(",")

        If arrBuf.Length <> 4 Then
            Return False
        End If
        ' Return False

        Dim nState As Integer = CInt(arrBuf(3))

        nRetState = nState

        Return True
    End Function

    Public Overrides Function SetIVLState(ByVal nCh As Integer, ByVal nState As CDevM6000CommonNode.eIVLState) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            ' LogMsg("SetIVLState cvtchtom6000info")
            Return False
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        sSendCommand = ("[" & MSG_BOARD_SET_CHANNEL_IVLOPERATION & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nState & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If

        If rcvDataSuccess(sRcvData) = False Then
            '  Return False
            'Application.DoEvents()
            'Thread.Sleep(50)
            'communicator.Communicator.SendToString(sSendCommand, sRcvData)
            'fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(SetIVLState Data Read Fail)")
            'LogMsg("CH : " & nCh + 1 & "(SetIVLState Data Read Fail)")
            Return False
        End If
        Application.DoEvents()
        Thread.Sleep(10)
        Return True
    End Function

    Public Function GetSingleIVLData(ByVal nCh As Integer, ByVal nPoint As Integer, ByRef sRetData As CDevM6000CommonNode.sIVLData) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        Dim outIndex As String = Nothing
        Dim outTime As String = Nothing
        Dim outVoltage As String = Nothing
        Dim outCurrent As String = Nothing
        Dim outPhoto As String = Nothing

        sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_IVLDATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nPoint & ")")

        Application.DoEvents()
        Thread.Sleep(10)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ' LogMsg("GetSingleIVLDATA SendTostring fail")
                Return False
            End If
        Else
            If Parse_IVLData(nBrdNum, nBrdPerCh, sRcvData, outIndex, outTime, outVoltage, outCurrent, outPhoto) = True Then
                If outIndex = nPoint Then
                    sRetData.dTime = outTime
                    sRetData.dVoltage = outVoltage
                    sRetData.dCurrent = outCurrent
                    sRetData.dPhoto = outPhoto
                    ' LogMsg("[Ch] : " & nCh & "  [Point] : " & nPoint & "   <Parse_IVL Success>" & "      <BrdNum,  BrdCHnum :  >" & nBrdNum & nBrdPerCh & "      RcvData   : " & sRcvData)
                End If
            Else
                ' LogMsg("[Ch] : " & nCh & "  [Point] : " & nPoint & "   <Parse_IVL Fail>" & "      <BrdNum,  BrdCHnum :  >" & nBrdNum & nBrdPerCh & "      RcvData   : " & sRcvData)
                Return False
                End
            End If
        End If
        Return True
    End Function

    Public Function GetIVLData(ByVal nCh As Integer, ByVal nPoint As Integer, ByRef sRetData() As CDevM6000CommonNode.sIVLData) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        ReDim sRetData(nPoint - 1)

        Dim outIndex As String = Nothing
        Dim outTime As String = Nothing
        Dim outVoltage As String = Nothing
        Dim outCurrent As String = Nothing
        Dim outPhoto As String = Nothing

        For idx As Integer = 0 To nPoint - 1

            Application.DoEvents()
            Thread.Sleep(5)

            sSendCommand = ("[" & MSG_BOARD_GET_CHANNEL_IVLDATA & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nPoint & ")")

            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(100)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If
                End If
                '  Return False
            Else

                If Parse_IVLData(nBrdNum, nBrdPerCh, sRcvData, outIndex, outTime, outVoltage, outCurrent, outPhoto) = True Then
                    If outIndex = idx Then
                        sRetData(idx).dTime = outTime
                        sRetData(idx).dVoltage = outVoltage
                        sRetData(idx).dCurrent = outCurrent
                        sRetData(idx).dPhoto = outPhoto
                    End If
                Else
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Application.DoEvents()
                        Thread.Sleep(100)
                        If Parse_IVLData(nBrdNum, nBrdPerCh, sRcvData, outIndex, outTime, outVoltage, outCurrent, outPhoto) = True Then
                            If outIndex = idx Then
                                sRetData(idx).dTime = outTime
                                sRetData(idx).dVoltage = outVoltage
                                sRetData(idx).dCurrent = outCurrent
                                sRetData(idx).dPhoto = outPhoto
                            End If
                        Else
                            Return False
                        End If
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Public Function SetIVLBias(ByVal nCh As Integer, ByVal mode As CDevM6000CommonNode.eMode, ByVal nStartBias As String, ByVal nStopBias As String) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        'If mode = eMode.eCV Then
        '    nStartBias = CDbl(nStartBias) * 1000
        '    nStopBias = CDbl(nStopBias) * 1000
        'End If

        'If mode = eMode.eCV Then
        '    If CalParam.SDCV_ratio(nBrdNum, nBrdPerCh) = "" Or CalParam.SDCV_offset(nBrdNum, nBrdPerCh) = "" Then Return False

        '    nStartBias = CDbl(nStartBias) * CDbl(CalParam.SDCV_ratio(nBrdNum, nBrdPerCh)) * 1000 + CDbl(CalParam.SDCV_offset(nBrdNum, nBrdPerCh))
        '    nStopBias = CDbl(nStopBias) * CDbl(CalParam.SDCV_ratio(nBrdNum, nBrdPerCh)) * 1000 + CDbl(CalParam.SDCV_offset(nBrdNum, nBrdPerCh))
        'ElseIf mode = eMode.eCC Then
        '    If CalParam.SDCC_ratio(nBrdNum, nBrdPerCh) = "" Or CalParam.SDCC_offset(nBrdNum, nBrdPerCh) = "" Then Return False

        '    nStartBias = CDbl(nStartBias) * CDbl(CalParam.SDCC_ratio(nBrdNum, nBrdPerCh)) + CDbl(CalParam.SDCC_offset(nBrdNum, nBrdPerCh))
        '    nStopBias = CDbl(nStopBias) * CDbl(CalParam.SDCC_ratio(nBrdNum, nBrdPerCh)) + CDbl(CalParam.SDCC_offset(nBrdNum, nBrdPerCh))
        'End If

        sSendCommand = ("[" & MSG_BOARD_SET_CHANNEL_IVLBIAS & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nStartBias & "," & nStopBias & ")")

        'If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
        '    Return False
        'End If
        Application.DoEvents()
        Thread.Sleep(100)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If
        If rcvDataSuccess(sRcvData) = False Then
            '.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(SetIVLBias Data Read Fail)")
            ' LogMsg("(SetIVLBias Data Read Fail)")
            Return False
        End If

        Return True
    End Function

    Public Function SetIVLConfig(ByVal nCh As Integer, ByVal nPoints As String, ByVal nHoldTime As String) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_CHANNEL_IVLCFG & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nPoints & "," & nHoldTime & ")")

        'If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
        '    Return False
        'End If
        Application.DoEvents()
        Thread.Sleep(100)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If

        If rcvDataSuccess(sRcvData) = False Then
            '  fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(SetIVLConfig Data Read Fail)")
            ' LogMsg("(SetIVLConfig Data Read Fail)")
            Return False
        End If

        Return True
    End Function

    Public Function SetIVLMeasConfig(ByVal nCh As Integer, ByVal nDelay As Integer, ByVal nAverage As Integer) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_CHANNEL_IVLMEASCONFIG & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nDelay & "," & nAverage & ")")

        Application.DoEvents()
        Thread.Sleep(100)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
            ' Return False
        End If

        If rcvDataSuccess(sRcvData) = False Then
            '  fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(SetIVLMeasConfig Data Read Fail)")
            ' LogMsg("(SetIVLMeasConfig Data Read Fail)")
            Return False
        End If

        Return True
    End Function

#Region "Parser IVL"
    Private Function Parse_IVLData(ByVal nBrdNum As Integer, ByVal nChPerBrd As Integer, ByVal strData As String, ByRef out_Index As String, ByRef out_Time As String, ByRef out_Voltage As String, _
                                 ByRef out_Current As String, ByRef out_Photo As String) As Boolean

        Dim TempData As Array = Nothing

        If strData.Length < 10 Then
            Return False
        End If

        TempData = Split(strData, "(", -1)
        TempData(1) = TempData(1).ToString.TrimEnd(")")

        TempData = Split(TempData(1), ",", -1)


        If TempData.Length <> 8 Then
            Return False
        End If
        '***** 예외처리부 *****

        If TempData Is Nothing = False Then
            If TempData(0) <> 1 Then
                Return False
            End If

            '***** 예외처리부 끝 *****
            out_Index = TempData(3)
            out_Time = TempData(4)
            out_Voltage = TempData(5)
            out_Current = TempData(6)
            out_Photo = TempData(7)

            Try
                '여기 아래부분 에러뜰때있음 쓰레기값 들어오면 형변환안됨 ..에러처리필요함 일단 try로..YJS
                out_Voltage = CDbl(out_Voltage) '* CDbl(CalParam.RV_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RV_offset(nBrdNum, nChPerBrd))
                out_Current = CDbl(out_Current) '* CDbl(CalParam.RC_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.RC_offset(nBrdNum, nChPerBrd))
                out_Photo = CDbl(out_Photo) '* CDbl(CalParam.BR_ratio(nBrdNum, nChPerBrd)) + CDbl(CalParam.BR_offset(nBrdNum, nChPerBrd))

                '단위변환
                out_Voltage = out_Voltage
                out_Current = out_Current * 1000
                out_Photo = out_Photo * 10 ^ 6

            Catch ex As Exception
                ' LogMsg("Parse_IVLDATA Read fail" & "Try~catch Error Msg : " & ex.Message &  "Volt : " & out_Voltage & "  Curr : "& out_Current & "   Photo : " & out_Photo)
                Return False
            End Try
        Else
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Function"

    Public Function SetBiasMode(ByVal nCh As Integer, ByVal nBiasMode As eMode) As Boolean ', ByVal Set_Amplitude As Double)

        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        '3. CC/CV 모드를 선택한다. [47]
        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nBiasMode & ")")

        'If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
        '    Return False
        'End If
        Application.DoEvents()
        Thread.Sleep(10)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If

        'Do
        If rcvDataSuccess(sRcvData) = False Then
            Application.DoEvents()
            Thread.Sleep(50)
            'fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(SetBias Data Read Fail)")
            ' communicator.Communicator.SendToString(sSendCommand, sRcvData)
            'LogMsg("(SetBias Data Read Fail)")
            Return False
        End If
        'Loop Until rcvDataSuccess(sRcvData) = True

        Return True
    End Function

    Public Function SetBiasMode(ByVal nBrdNum As Integer, ByVal nBrdPerCh As Integer, ByVal nBiasMode As eMode) As Boolean
        '3. CC/CV 모드를 선택한다. [47]
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        sSendCommand = ("[" & MSG_BOARD_SET_ELECMODE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & nBiasMode & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function Set_BiasValue(ByVal nCh As Integer, ByVal nBiasMode As eMode, ByVal bAC As Boolean, ByVal dValue As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        Dim Set_Bias1 As Double

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        '2. 전압값을 설정한다. [44]
        Set_Bias1 = dValue
        'If nBiasMode = eMode.eCV Then
        '    If bAC = False Then
        '        Set_Bias1 = dValue * CDbl(CalParam.SDCV_ratio(nBrdNum, nBrdPerCh)) * 1000 + CDbl(CalParam.SDCV_offset(nBrdNum, nBrdPerCh))
        '    Else
        '        Set_Bias1 = dValue * CDbl(CalParam.SACV_ratio(nBrdNum, nBrdPerCh)) * 1000 + CDbl(CalParam.SACV_offset(nBrdNum, nBrdPerCh))
        '    End If
        'ElseIf nBiasMode = eMode.eCC Then
        '    If bAC = False Then
        '        Set_Bias1 = dValue * CDbl(CalParam.SDCC_ratio(nBrdNum, nBrdPerCh)) + CDbl(CalParam.SDCC_offset(nBrdNum, nBrdPerCh))
        '    Else
        '        Set_Bias1 = dValue * CDbl(CalParam.SACC_ratio(nBrdNum, nBrdPerCh)) + CDbl(CalParam.SACC_offset(nBrdNum, nBrdPerCh))
        '    End If
        'End If

        If bAC = False Then
            sSendCommand = ("[" & MSG_BOARD_SET_BIAS & "]" & "(" & nBrdNum & "," & CStr(nCh) & "," & CStr(Set_Bias1) & ")")
        Else
            sSendCommand = ("[" & MSG_BOARD_SET_BIAS_2 & "]" & "(" & nBrdNum & "," & CStr(nCh) & "," & CStr(Set_Bias1) & ")")
        End If

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function Set_Pulse(ByVal nCh As Integer, ByVal dFrequency As Double, ByVal dDuty As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_PULSE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & CStr(dFrequency) & "," & CStr(100 - CDbl(dDuty)) & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function Set_Switch(ByVal nCh As Integer, ByVal bONOFF As Boolean) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        If bONOFF = True Then
            '5. 스위치를 ON한다. [46]
            sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "1)")
            ' LogMsg("SetSwitch ON Send msg : " & sSendCommand)
            Application.DoEvents()
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(100)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        ' LogMsg("Switch On Fail")
                        Return False
                    End If
                    '  Return False
                End If
            End If
        Else
            sSendCommand = ("[" & MSG_BOARD_SET_SWITCH & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & "0)")
            ' LogMsg("SetSwitch OFF Send msg : " & sSendCommand)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(100)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Application.DoEvents()
                    Thread.Sleep(100)
                    If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        ' LogMsg("Switch OFF Fail")
                        Return False
                    End If
                End If
            End If
        End If
        'LogMsg("SetSwitch Receive : " & sRcvData)

        If rcvDataSuccess(sRcvData) = False Then
            Return False
        End If
        '    '  fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Set_Switch Data Read Fail)")
        '    LogMsg("(Set_Switch Data Read Fail)")
        '    Return False
        'End If


        Return True
    End Function

    Public Overrides Function Set_CalibrationSave(ByVal nCh As Integer) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        Dim strRange As String = ""

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_CALIB_SAVE & "]" & "(" & nBrdNum & "," & nBrdPerCh & ")")

        'RaiseEvent evtCMD("SEND :" & sSendCommand)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Application.DoEvents()
        Thread.Sleep(1000)

        Return True

    End Function

    Public Overrides Function Set_AutoRange_PD(ByVal nCh As Integer, ByVal Mode As Integer) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        Dim strRange As String = ""

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If
        'Mode 0 : Auto, 1: Manual
        sSendCommand = ("[" & MSG_BOARD_SET_PD_RANGE_MODE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & Mode & ")")

        'RaiseEvent evtCMD("SEND :" & sSendCommand)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True

    End Function
    Public Overrides Function Set_AutoRange_Current(ByVal nCh As Integer, ByVal Mode As Integer) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        Dim strRange As String = ""

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If
        'Mode 0 : Auto, 1: Manual
        sSendCommand = ("[" & MSG_BOARD_SET_CURR_RANGE_MODE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & Mode & ")")

        'RaiseEvent evtCMD("SEND :" & sSendCommand)
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True

    End Function
    Public Overrides Function Set_Calibration_Eanble(ByVal nCh As Integer, ByVal eCalEnable As eCalibrationEnable) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim sBufData() As String = Nothing
        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            ''  LogMsg(nCh + 1 & " Set Calibration cvtChToM6000Info 실패")
            Return False
        End If

        Dim strRange As String = ""

        If eCalEnable = eCalibrationEnable._ALL_DISABLE Then
            strRange = "0"
        ElseIf eCalEnable = eCalibrationEnable._OUTPUT_ENABLE Then
            strRange = "1"
        ElseIf eCalEnable = eCalibrationEnable._INPUT_ENABLE Then
            strRange = "16"
        ElseIf eCalEnable = eCalibrationEnable._ALL_ENABLE Then
            strRange = "17"
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_CALIB_ENABLE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & strRange & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            ''LogMsg(nCh + 1 & " Set Calibration communicator fail")
            Return False
        End If

        sBufData = sRcvData.Split(" ")

        If sBufData(sBufData.Length - 1).Substring(1, 1) = 0 Then
            ''  LogMsg(nCh + 1 & sRcvData & "Set Calibration Substring fail (1 time)")
            Application.DoEvents()
            Thread.Sleep(20)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                ''   LogMsg(nCh + 1 & " Set Calibration communicator fail")
                Return False
            End If
            sBufData = sRcvData.Split(" ")
            If sBufData(sBufData.Length - 1).Substring(1, 1) = 0 Then
                ''  LogMsg(nCh + 1 & sRcvData & "Set Calibration Substring fail(2 time)")
                Return False
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Public Overrides Function Set_CurrentRange(ByVal nCh As Integer, ByVal eCurrRange As eCurrentRange) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        Dim strRange As String = ""

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        If eCurrRange = eCurrentRange._RANGE_1 Then
            strRange = 0
        ElseIf eCurrRange = eCurrentRange._RANGE_2 Then
            strRange = 1
        Else
            strRange = eCurrRange
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_CURR_RANGE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & strRange & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Application.DoEvents()
            Thread.Sleep(10)
            If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Application.DoEvents()
                Thread.Sleep(10)
                If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If
        ' Return False
        If rcvDataSuccess(sRcvData) = False Then
            '  fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(Set CurrentRange Data Read Fail)")
            '  LogMsg("(Set CurrentRange Data Read Fail)")
            Return False
        End If
        Return True
    End Function

    Public Overrides Function Set_PhotoRange(ByVal nCh As Integer, ByVal ePDRange As ePhotocurrentRange) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        Dim strRange As String = ""

        If ePDRange = ePhotocurrentRange._RANGE_1 Then
            strRange = "0"
        ElseIf ePDRange = ePhotocurrentRange._RANGE_2 Then
            strRange = "1"
        ElseIf ePDRange = ePhotocurrentRange._RANGE_3 Then
            strRange = "2"
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_PD_RANGE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & strRange & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If rcvDataSuccess(sRcvData) = False Then Return False

        Return True

    End Function

    Public Overrides Function Set_ProbeMode(ByVal nCh As Integer, ByVal eMode As eProbeMode) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        Dim strMode As String = ""

        If eMode = eProbeMode._2WIRE Then
            strMode = "1"
        ElseIf eMode = eProbeMode._4WIRE Then
            strMode = "0"
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_PROBE_MODE & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & strMode & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If rcvDataSuccess(sRcvData) = False Then Return False
        Return True
    End Function


    'Range 설정
    Public Overrides Function Set_OverVoltageValue(ByVal nCh As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_OVERVOLT & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & dMin & "," & dMax & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If rcvDataSuccess(sRcvData) = False Then Return False
        Return True
    End Function

    Public Overrides Function Set_OverCurrentValue(ByVal nCh As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim nHwNum As Integer
        Dim nBrdNum As Integer
        Dim nBrdPerCh As Integer

        If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
            Return False
        End If

        sSendCommand = ("[" & MSG_BOARD_SET_OVERCURR & "]" & "(" & nBrdNum & "," & nBrdPerCh & "," & dMin & "," & dMax & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If rcvDataSuccess(sRcvData) = False Then Return False
        Return True
    End Function

    Public Overrides Function Set_RangeVoltage(ByVal nBrdNo As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing


        sSendCommand = ("[" & MSG_BOARD_SET_RANGE_VOLT & "]" & "(" & nBrdNo & "," & dMin & "," & dMax & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function Set_RangeCurrent(ByVal nBrdNum As Integer, ByVal eRange As eCurrentRange, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim strCmd As Integer

        If eRange = eCurrentRange._RANGE_1 Then
            strCmd = MSG_BOARD_SET_RANGE_CURR_1
        ElseIf eRange = eCurrentRange._RANGE_2 Then
            strCmd = MSG_BOARD_SET_RANGE_CURR_2
        End If

        sSendCommand = ("[" & strCmd & "]" & "(" & nBrdNum & "," & dMin & "," & dMax & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function Set_RangePhotoCurrent(ByVal nBrdNum As Integer, ByVal eRange As ePhotocurrentRange, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing

        Dim strCmd As Integer

        If eRange = ePhotocurrentRange._RANGE_1 Then
            strCmd = MSG_BOARD_SET_RANGE_PDCURR_1
        ElseIf eRange = ePhotocurrentRange._RANGE_2 Then
            strCmd = MSG_BOARD_SET_RANGE_PDCURR_2
        ElseIf eRange = ePhotocurrentRange._RANGE_3 Then
            strCmd = MSG_BOARD_SET_RANGE_PDCURR_3
        End If

        sSendCommand = ("[" & strCmd & "]" & "(" & nBrdNum & "," & dMin & "," & dMax & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function


    Public Overrides Function Get_BoardRangeInfo(ByVal nBrdNum As Integer, ByRef sRetBoardRangeInfo As sBoardRangeInfo) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing


        sSendCommand = ("[" & MSG_BOARD_GET_RANGE & "]" & "(" & nBrdNum & ")")

        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If Parser_BoardInfo(sRcvData, sRetBoardRangeInfo) = False Then
            Return False
        End If

        Return True
    End Function

    Private Function Parser_BoardInfo(ByVal in_strParam As String, ByRef sretInfo As sBoardRangeInfo) As Boolean
        Dim arrBuf As Array = Nothing

        If in_strParam Is Nothing Or in_strParam = "" Then
            Return False
        End If

        Try
            in_strParam = in_strParam.TrimEnd(")")
            arrBuf = in_strParam.Split(",")

            ReDim sretInfo.dMaxCurr(1)
            ReDim sretInfo.dMinCurr(1)
            ReDim sretInfo.dMaxPhoto(2)
            ReDim sretInfo.dMinPhoto(2)

            sretInfo.dMaxVolt = arrBuf(1)
            sretInfo.dMinVolt = arrBuf(2)
            sretInfo.dMaxCurr(0) = arrBuf(3)
            sretInfo.dMinCurr(0) = arrBuf(4)
            sretInfo.dMaxCurr(1) = arrBuf(5)
            sretInfo.dMinCurr(1) = arrBuf(6)
            sretInfo.dMaxPhoto(0) = arrBuf(9)
            sretInfo.dMinPhoto(0) = arrBuf(10)
            sretInfo.dMaxPhoto(1) = arrBuf(11)
            sretInfo.dMinPhoto(1) = arrBuf(12)
            sretInfo.dMaxPhoto(2) = arrBuf(13)
            sretInfo.dMinPhoto(2) = arrBuf(14)
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function
#End Region


    'Public Overrides Function IVLMeasureStart(ByVal nCh As Integer, ByVal sIVLSet As ucDispRcpCellIVL.sCellIVLSettings) As Boolean
    '    Dim nHwNum As Integer
    '    Dim nBrdNum As Integer
    '    Dim nBrdPerCh As Integer
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing
    '    Dim nState As CDevM6000CommonNode.eIVLState = CDevM6000CommonNode.eIVLState._IDLE
    '    '  Dim sRetData() As CDevM6000CommonNode.sIVLData = Nothing

    '    'set 2번하자
    '    If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
    '        '  LogMsg("IVLMeasureStart cvtm6000info false")
    '        Return False
    '    End If
    '    'Application.DoEvents()
    '    'Thread.Sleep(20)

    '    'If GetIVLState(nCh, m_IVLState(nCh)) = False Then
    '    '    Return False
    '    'End If

    '    'Application.DoEvents()
    '    'Thread.Sleep(20)

    '    'If nState <> CDevM6000CommonNode.eIVLState._IDLE Then
    '    '    Return False
    '    'End If

    '    If CellOFF(nCh) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)   '실패 시 딜레이 후 재시도
    '        If CellOFF(nCh) = False Then
    '            ' LogMsg("IVLMeasureStart CellOFF false")
    '            Return False
    '        End If
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    '스위치 먼저 턴온해야됌
    '    If Set_Switch(nCh, True) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        If Set_Switch(nCh, True) = False Then
    '            Return False
    '        End If
    '    End If


    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    If SetBiasMode(nCh, sIVLSet.Mode) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        ' LogMsg("(IVLMeasureStart SetBiasMode Retry")
    '        If SetBiasMode(nCh, sIVLSet.Mode) = False Then
    '            '  LogMsg("(IVLMeasureStart SetBiasMode Retry Fail")
    '            Return False
    '        End If
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    If Set_CurrentRange(nCh, sIVLSet.nCurrRange) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        ' LogMsg("(IVLMeasureStart Set_CurrentRange Retry")
    '        If Set_CurrentRange(nCh, sIVLSet.nCurrRange) = False Then
    '            '  LogMsg("(IVLMeasureStart Set_CurrentRange Retry Fail")
    '            Return False
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    If SetIVLBias(nCh, sIVLSet.Mode, sIVLSet.dStart, sIVLSet.dStop) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        ' LogMsg("(IVLMeasureStart SetIVLBias Retry")
    '        If SetIVLBias(nCh, sIVLSet.Mode, sIVLSet.dStart, sIVLSet.dStop) = False Then
    '            ' LogMsg("(IVLMeasureStart SetIVLBias Retry Fail")
    '            Return False
    '        End If
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    If SetIVLConfig(nCh, sIVLSet.nPoint, sIVLSet.dHoldTime) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        '  LogMsg("(IVLMeasureStart SetIVLConfig Retry")
    '        If SetIVLConfig(nCh, sIVLSet.nPoint, sIVLSet.dHoldTime) = False Then
    '            '  LogMsg("(IVLMeasureStart SetIVLConfig Retry Fail")
    '            Return False
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(50)

    '    If SetIVLMeasConfig(nCh, sIVLSet.dDelay, sIVLSet.nAverage) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        ' LogMsg("(IVLMeasureStart SetIVLMeasConfig Retry")
    '        If SetIVLMeasConfig(nCh, sIVLSet.dDelay, sIVLSet.nAverage) = False Then
    '            '  LogMsg("(IVLMeasureStart SetIVLMeasConfig Retry Fail")
    '            Return False
    '        End If
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(50)


    '    If SetIVLState(nCh, CDevM6000CommonNode.eIVLState._RUN) = True Then
    '        m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._RUN
    '        '' LogMsg("(SetIVLState Complete)" & "  CH : " & nCh + 1 + (m_ID * 32))
    '        'LogMsg("State Run Convert" & ", CH : " & nCh & "     State : " & m_IVLState(nCh))
    '    Else
    '        Application.DoEvents()
    '        Thread.Sleep(600)
    '        If SetIVLState(nCh, CDevM6000CommonNode.eIVLState._RUN) = True Then
    '            m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._RUN
    '            Application.DoEvents()
    '            Thread.Sleep(50)
    '            ''   LogMsg("(SetIVLState Complete)" & "  CH : " & nCh + 1 + (m_ID * 32))
    '            ' LogMsg("Retry     " & "CH : " & nCh & "     State : " & m_IVLState(nCh))
    '        Else
    '            '  LogMsg("(IVLMeasureStart SetIVLState = Run Setting Fail")
    '            Return False
    '        End If
    '    End If

    '    Return True

    'End Function

    Public Overrides Function IVLGetData(ByVal nCh As Integer, ByVal nCntPoint As Integer, ByRef sRetIVLData() As CDevM6000CommonNode.sIVLData) As Boolean
        'Dim nState As CDevM6000CommonNode.eIVLState = CDevM6000CommonNode.eIVLState._IDLE

        If CellOFF(nCh) = False Then
            Application.DoEvents()
            Thread.Sleep(600)   'Sleep Time is over 500
            If CellOFF(nCh) = False Then
                'LogMsg("CellOff Fail (IVLGETDATA)")
                Return False
            End If
        End If

        Dim nCnt As Integer = 0

        ReDim sRetIVLData(nCntPoint - 1)

        Do

            'If GetIVLState(nCh, m_IVLState(nCh)) = True Then

            '    If m_IVLState(nCh) <> CDevM6000CommonNode.eIVLState._STOP Then Exit Do
            'Else
            '    If GetIVLState(nCh, m_IVLState(nCh)) = True Then
            '        If m_IVLState(nCh) <> CDevM6000CommonNode.eIVLState._STOP Then Exit Do
            '    Else
            '        Return False
            '    End If
            'End If

            '3번까지 읽고 못읽으면 False로 처리함
            If GetSingleIVLData(nCh, nCnt, sRetIVLData(nCnt)) = False Then
                ' nCnt = 0
                Application.DoEvents()
                Thread.Sleep(600)   'Sleep Time is over 500
                If GetSingleIVLData(nCh, nCnt, sRetIVLData(nCnt)) = False Then
                    '  LogMsg("CH :" & nCh & "  2try GetsingleIVLData")
                    ' nCnt = 0
                    Application.DoEvents()
                    Thread.Sleep(600)  'Sleep Time is over 500
                    If GetSingleIVLData(nCh, nCnt, sRetIVLData(nCnt)) = False Then
                        '  LogMsg("CH :" & nCh & "  3try GetsingleIVLData -> Fail")
                        ' nCnt = 0
                        Application.DoEvents()
                        Thread.Sleep(600)  'Sleep Time is over 500
                    End If
                End If
            End If
            Application.DoEvents()
            Thread.Sleep(10)

            nCnt += 1
        Loop Until nCnt = nCntPoint

        Application.DoEvents()
        Thread.Sleep(50)

        '  Do
        ' LogMsg("CH :" & nCh & "  (IVLGETDATA) GO IDLE State")
        If SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE) = False Then
            Application.DoEvents()
            Thread.Sleep(600)
            If SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE) = False Then
                '   LogMsg("(IVLGetData Function SetIVLState Retry Fail")
                Return False
                'SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE)
            End If
        End If
        ' Loop Until SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE) = True

        Application.DoEvents()
        Thread.Sleep(30)

        m_IVLState(nCh) = eIVLState._IDLE

        Return True
    End Function


    'Public Overrides Function MeasureIVL(ByVal nCh As Integer, ByVal sIVLSet As ucDispRcpCellIVL.sCellIVLSettings, ByRef sRetIVLData() As CDevM6000CommonNode.sIVLData) As Boolean
    '    Dim nHwNum As Integer
    '    Dim nBrdNum As Integer
    '    Dim nBrdPerCh As Integer
    '    Dim sSendCommand As String = Nothing
    '    Dim sRcvData As String = Nothing
    '    'Dim nState As CDevM6000CommonNode.eIVLState = CDevM6000CommonNode.eIVLState._IDLE
    '    '  Dim sRetData() As CDevM6000CommonNode.sIVLData = Nothing

    '    'set
    '    If cvtChToM6000Info(nCh, nHwNum, nBrdNum, nBrdPerCh) = False Then
    '        Return False
    '    End If


    '    If GetIVLState(nCh, m_IVLState(nCh)) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        If GetIVLState(nCh, m_IVLState(nCh)) = False Then
    '            Return False
    '        End If
    '    End If

    '    If m_IVLState(nCh) <> CDevM6000CommonNode.eIVLState._IDLE Then
    '        Return False
    '    End If


    '    Application.DoEvents()
    '    Thread.Sleep(100)


    '    If CellOFF(nCh) = False Then
    '        Return False
    '    End If


    '    Application.DoEvents()
    '    Thread.Sleep(100)


    '    If SetBiasMode(nCh, sIVLSet.Mode) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        If SetBiasMode(nCh, sIVLSet.Mode) = False Then
    '            Return False
    '        End If
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(100)

    '    If Set_CurrentRange(nCh, sIVLSet.nCurrRange) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        If Set_CurrentRange(nCh, sIVLSet.nCurrRange) = False Then
    '            Return False
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(100)


    '    If SetIVLBias(nCh, sIVLSet.Mode, sIVLSet.dStart, sIVLSet.dStop) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        If SetIVLBias(nCh, sIVLSet.Mode, sIVLSet.dStart, sIVLSet.dStop) = False Then
    '            Return False
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(100)

    '    If SetIVLConfig(nCh, sIVLSet.nPoint, sIVLSet.dHoldTime) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        'MsgBox("Failed")
    '        If SetIVLConfig(nCh, sIVLSet.nPoint, sIVLSet.dHoldTime) = False Then
    '            Return False
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(100)

    '    If SetIVLMeasConfig(nCh, sIVLSet.dDelay, sIVLSet.nAverage) = False Then
    '        Application.DoEvents()
    '        Thread.Sleep(10)
    '        If SetIVLMeasConfig(nCh, sIVLSet.dDelay, sIVLSet.nAverage) = False Then
    '            Return False 'MsgBox("Failed")
    '        End If
    '    End If
    '    Application.DoEvents()
    '    Thread.Sleep(100)

    '    If Set_Switch(nCh, True) = False Then
    '        If Set_Switch(nCh, True) = False Then
    '            Return False
    '        End If
    '    End If

    '    If SetIVLState(nCh, CDevM6000CommonNode.eIVLState._RUN) = True Then
    '        m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._RUN

    '        Application.DoEvents()
    '        Thread.Sleep(1000)

    '        Do

    '            Application.DoEvents()
    '            Thread.Sleep(800)
    '            ' LogMsg("State Convert to stop")
    '            ' LogMsg("CH : " & nCh & "State : " & m_IVLState(nCh))
    '            If m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._STOP Then
    '                SetIVLState(nCh, CDevM6000CommonNode.eIVLState._STOP)
    '            End If

    '            Application.DoEvents()
    '            Thread.Sleep(200)

    '            If GetIVLState(nCh, m_IVLState(nCh)) = True Then

    '                If m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._STOP Then Exit Do
    '            Else
    '                If GetIVLState(nCh, m_IVLState(nCh)) = True Then

    '                    If m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._STOP Then Exit Do
    '                Else
    '                    Return False
    '                End If

    '                Application.DoEvents()
    '                Thread.Sleep(100)
    '            End If
    '        Loop Until m_IVLState(nCh) = CDevM6000CommonNode.eIVLState._STOP

    '        If CellOFF(nCh) = False Then
    '            If CellOFF(nCh) = False Then
    '                Return False
    '            End If
    '        End If
    '        Application.DoEvents()
    '        Thread.Sleep(100)

    '        ' Do
    '        'SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE)

    '        SetIVLState(nCh, CDevM6000CommonNode.eIVLState._IDLE)

    '        ' Loop Until m_IVLState(nCh) = eIVLState._IDLE

    '        Application.DoEvents()
    '        Thread.Sleep(100)
    '    Else
    '        ' fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateType.eMSGOutput, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "(MeasureIVL : SetIVLState Error)")
    '        ' LogMsg("(MeasureIVL : SetIVLState Error)")
    '        Return False
    '    End If


    '    Dim nCnt As Integer = 0

    '    ReDim sRetIVLData(sIVLSet.nPoint - 1)

    '    Do

    '        Application.DoEvents()
    '        Thread.Sleep(100)


    '        If GetIVLState(nCh, m_IVLState(nCh)) = True Then

    '            If m_IVLState(nCh) <> CDevM6000CommonNode.eIVLState._IDLE Then
    '                '  LogMsg("CH : " & nCh & "State is not IDLE")
    '                Exit Do
    '            End If
    '            'Exit Do
    '        Else
    '            ' LogMsg("MesureIVL GetIVLSTATE False")
    '            Return False
    '        End If

    '        If GetSingleIVLData(nCh, nCnt, sRetIVLData(nCnt)) = True Then

    '        Else
    '            MsgBox("데이터를 읽어오는데 실패했습니다.")
    '            Exit Do
    '        End If

    '        nCnt += 1
    '    Loop Until nCnt = sIVLSet.nPoint

    '    Return True
    'End Function
    Public Function rcvDataSuccess(ByVal rcvData As String) As Boolean
        Dim buff As Array

        buff = rcvData.Split(" ")
        If buff.Length <> 2 Then Return False
        Dim nSuccess As Integer = buff(1).ToString.Substring(1, 1)
        If nSuccess = 1 Then
            Return True
        ElseIf nSuccess = 0 Then
            Return False
        Else
            Return False
        End If
    End Function
    Public Shared Function ConvertStringModeToInt(ByVal str As String) As eMode
        Select Case str
            Case eMode.eCC.ToString
                Return eMode.eCC
            Case eMode.eCV.ToString
                Return eMode.eCV
            Case eMode.ePC.ToString
                Return eMode.ePC
            Case eMode.ePV.ToString
                Return eMode.ePV
            Case eMode.ePCV.ToString
                Return eMode.ePCV
            Case Else
                Return -1
        End Select
    End Function
    'Public Sub LogMsg(ByVal STR As String)
    '    Try
    '        FileOpen(4, g_sFilePath_SystemLog, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
    '    Catch ex As Exception
    '        FileClose(4)
    '    End Try

    '    Dim cYear As String = Now.Year 'Format(Now, "yyyy")
    '    Dim cMonth As String = Now.Month ' Format(Now, "MM")
    '    Dim cDay As String = Now.Day  'Format(Now, "dd")

    '    Dim cHour As String = Now.Hour '(Now, "HH")
    '    Dim cMin As String = Now.Minute ' Format(Now, "mm")
    '    Dim cSec As String = Now.Second 'Format(Now, "ss")

    '    STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

    '    PrintLine(4, STR)

    '    '파일에 쓰고
    '    FileClose(4)
    'End Sub
#End Region

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
