Imports System.IO.Ports
Imports System.Threading
Imports CCommLib

Public Class CDevMC9
    Inherits CDevTCCommonNode

#Region "Define"
    Dim communicator As CComAPI

    Dim m_nNumOfDev As Integer
    Dim m_numOfChPerDev As Integer
    Dim RegNoS() As Long         'Regitor 번지
    Dim WDataS() As Long
    Dim W_ParaNo As Long
    Dim myDP As Long
    Dim strFormat As String
    Dim WCNT As Integer          '데이터 개수
    Dim CH_NO As eCHANNEL        '채널 번호
    Dim ChksumV As Long = 0

    'Dim m_Settings() As sSettings

    'Public Structure sSettings
    '    Dim devID As Integer
    '    Dim numOfCh As Integer
    '    Dim m_Settings() As sParams
    'End Structure

    'Public Structure sParams
    '    Dim measTemp As Double
    '    Dim setTemp As Double
    '    Dim bIsRun As Boolean
    'End Structure

#Region "Spec & Parameter"

    Private Const Max_Temperature As Double = 999.9 '장비 온도(℃)
    Private Const Min_Temperature As Double = -199.9
    Private Const Max_HBC As Double = 100 '검출전류(A) 표시
    Private Const Min_HBC As Double = 0
    Private Const Max_LBA As Double = 200 '제어 루프 단선 경보 (Min)
    Private Const Min_LBA As Double = 0.1
    Private Const Max_LBD As Double = 100 '제어 루프 단선 경보 데드밴드 (sec)
    Private Const Min_LBD As Double = 0
    Private Const Max_ScanTime As Double = 100 '현재 표시하고 있는 채널에서 다음채널로 바뀔때 까지의 시간
    Private Const Min_ScanTime As Double = 1

#End Region

#Region "Protocol"

#Region "Read Only"
    'PV(Pointing Value) : 현재 온도값
    Private Const PV1 As Integer = 1
    Private Const PV2 As Integer = 2
    Private Const PV3 As Integer = 3
    Private Const PV4 As Integer = 4
    Private Const PV5 As Integer = 5
    Private Const PV6 As Integer = 6
    Private Const PV7 As Integer = 7
    Private Const PV8 As Integer = 8

    'SV(Setting Value) : 설정 온도값
    Private Const SV1 As Integer = 11
    Private Const SV2 As Integer = 12
    Private Const SV3 As Integer = 13
    Private Const SV4 As Integer = 14
    Private Const SV5 As Integer = 15
    Private Const SV6 As Integer = 16
    Private Const SV7 As Integer = 17
    Private Const SV8 As Integer = 18

    'MV  :현재 출력값
    Private Const MV1 As Integer = 101
    Private Const MV2 As Integer = 102
    Private Const MV3 As Integer = 103
    Private Const MV4 As Integer = 104
    Private Const MV5 As Integer = 105
    Private Const MV6 As Integer = 106
    Private Const MV7 As Integer = 107
    Private Const MV8 As Integer = 108

    'STS
    '(상태값 : 1:Meas.STOP, 2:Meas.Run, 4:AT(AutoRun Status), 128:FATAL ERROR)
    Private Const STS1 As Integer = 111
    Private Const STS2 As Integer = 112
    Private Const STS3 As Integer = 113
    Private Const STS4 As Integer = 114
    Private Const STS5 As Integer = 115
    Private Const STS6 As Integer = 116
    Private Const STS7 As Integer = 117
    Private Const STS8 As Integer = 118

    'INPUT_ERR(채널별 입력 에러 상태:
    '(0: +OVER,1:-OVER, 2:-RJC, 3:+RJC, 4:-BOUT, 5:+BOUT, 6:AD ERROR, 7:AD TIME)
    Private Const INPUT_ERR1 As Integer = 201
    Private Const INPUT_ERR2 As Integer = 202
    Private Const INPUT_ERR3 As Integer = 203
    Private Const INPUT_ERR4 As Integer = 204
    Private Const INPUT_ERR5 As Integer = 205
    Private Const INPUT_ERR6 As Integer = 206
    Private Const INPUT_ERR7 As Integer = 207
    Private Const INPUT_ERR8 As Integer = 208

    'HB : 히타 센싱값?
    Private Const HB1 As Integer = 211
    Private Const HB2 As Integer = 212
    Private Const HB3 As Integer = 213
    Private Const HB4 As Integer = 214
    Private Const HB5 As Integer = 215
    Private Const HB6 As Integer = 216
    Private Const HB7 As Integer = 217
    Private Const HB8 As Integer = 218

#End Region

    'Meas. RUn/STOP 설정
    Private Const RUN_STOP As Integer = 305

    'SV 설정
    Private Const SV As Integer = 401

    'Data Scan Time 설정
    Private Const SCANTIME As Integer = 507

    '허용 온도(Full Range High/Low) 설정
    Private Const FR_H As Integer = 608 ' 최고 온도 설정
    Private Const FR_L As Integer = 609 ' 최저 온도 설정

    'Bias Setting(Offset 값 설정)
    Private Const BIAS1 As Integer = 811
    Private Const BIAS2 As Integer = 812
    Private Const BIAS3 As Integer = 813
    Private Const BIAS4 As Integer = 814
    Private Const BIAS5 As Integer = 815
    Private Const BIAS6 As Integer = 816
    Private Const BIAS7 As Integer = 817
    Private Const BIAS8 As Integer = 818

    'Parameter Setting(채널별 ZONE1만 사용) 
    Private Const PARA_CH1_ZONE1 As Integer = 1001
    Private Const PARA_CH1_ZONE2 As Integer = 1002
    Private Const PARA_CH1_ZONE3 As Integer = 1003
    Private Const PARA_CH1_ZONE4 As Integer = 1004
    Private Const PARA_CH1_ZONE5 As Integer = 1005
    Private Const PARA_CH1_ZONE6 As Integer = 1006
    Private Const PARA_CH1_ZONE7 As Integer = 1007
    Private Const PARA_CH1_ZONE8 As Integer = 1008

    Private Const PARA_CH2_ZONE1 As Integer = 1009
    Private Const PARA_CH2_ZONE2 As Integer = 1010
    Private Const PARA_CH2_ZONE3 As Integer = 1011
    Private Const PARA_CH2_ZONE4 As Integer = 1012
    Private Const PARA_CH2_ZONE5 As Integer = 1013
    Private Const PARA_CH2_ZONE6 As Integer = 1014
    Private Const PARA_CH2_ZONE7 As Integer = 1015
    Private Const PARA_CH2_ZONE8 As Integer = 1016

    Private Const PARA_CH3_ZONE1 As Integer = 1017
    Private Const PARA_CH3_ZONE2 As Integer = 1018
    Private Const PARA_CH3_ZONE3 As Integer = 1019
    Private Const PARA_CH3_ZONE4 As Integer = 1020
    Private Const PARA_CH3_ZONE5 As Integer = 1021
    Private Const PARA_CH3_ZONE6 As Integer = 1022
    Private Const PARA_CH3_ZONE7 As Integer = 1023
    Private Const PARA_CH3_ZONE8 As Integer = 1024

    Private Const PARA_CH4_ZONE1 As Integer = 1025
    Private Const PARA_CH4_ZONE2 As Integer = 1026
    Private Const PARA_CH4_ZONE3 As Integer = 1027
    Private Const PARA_CH4_ZONE4 As Integer = 1028
    Private Const PARA_CH4_ZONE5 As Integer = 1029
    Private Const PARA_CH4_ZONE6 As Integer = 1030
    Private Const PARA_CH4_ZONE7 As Integer = 1031
    Private Const PARA_CH4_ZONE8 As Integer = 1032

    Private Const PARA_CH5_ZONE1 As Integer = 1101
    Private Const PARA_CH5_ZONE2 As Integer = 1102
    Private Const PARA_CH5_ZONE3 As Integer = 1103
    Private Const PARA_CH5_ZONE4 As Integer = 1104
    Private Const PARA_CH5_ZONE5 As Integer = 1105
    Private Const PARA_CH5_ZONE6 As Integer = 1106
    Private Const PARA_CH5_ZONE7 As Integer = 1107
    Private Const PARA_CH5_ZONE8 As Integer = 1108

    Private Const PARA_CH6_ZONE1 As Integer = 1109
    Private Const PARA_CH6_ZONE2 As Integer = 1110
    Private Const PARA_CH6_ZONE3 As Integer = 1111
    Private Const PARA_CH6_ZONE4 As Integer = 1112
    Private Const PARA_CH6_ZONE5 As Integer = 1113
    Private Const PARA_CH6_ZONE6 As Integer = 1114
    Private Const PARA_CH6_ZONE7 As Integer = 1115
    Private Const PARA_CH6_ZONE8 As Integer = 1116

    Private Const PARA_CH7_ZONE1 As Integer = 1117
    Private Const PARA_CH7_ZONE2 As Integer = 1118
    Private Const PARA_CH7_ZONE3 As Integer = 1119
    Private Const PARA_CH7_ZONE4 As Integer = 1120
    Private Const PARA_CH7_ZONE5 As Integer = 1121
    Private Const PARA_CH7_ZONE6 As Integer = 1122
    Private Const PARA_CH7_ZONE7 As Integer = 1123
    Private Const PARA_CH7_ZONE8 As Integer = 1124

    Private Const PARA_CH8_ZONE1 As Integer = 1125
    Private Const PARA_CH8_ZONE2 As Integer = 1126
    Private Const PARA_CH8_ZONE3 As Integer = 1127
    Private Const PARA_CH8_ZONE4 As Integer = 1128
    Private Const PARA_CH8_ZONE5 As Integer = 1129
    Private Const PARA_CH8_ZONE6 As Integer = 1130
    Private Const PARA_CH8_ZONE7 As Integer = 1131
    Private Const PARA_CH8_ZONE8 As Integer = 1132


#End Region

#End Region

#Region "Property"

    Public Overrides Property NumOfChannelPerDev As Integer
        Get
            Return m_numOfChPerDev
        End Get
        Set(ByVal value As Integer)
            m_numOfChPerDev = value
        End Set
    End Property

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

#End Region

#Region "Enum"
    Public Enum eCHANNEL
        CH1 = 0
        CH2
        CH3
        CH4
        CH5
        CH6
        CH7
        Ch8
    End Enum

    Public Enum eZONE
        ZONE1 = 0
        ZONE2
        ZONE3
        ZONE4
        ZONE5
        ZONE6
        ZONE7
        ZONE8
    End Enum
#End Region

#Region "Communication"

#Region "Connection/Disconnection"


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

    Public Overrides Sub Disconnection()
        communicator.Communicator.Disconnect()
    End Sub

#End Region

#Region "Check"

    Public Function RcvCheck(ByVal rcvData As String) As Boolean


        Dim DataLength As Integer = rcvData.ToCharArray.Length - 1

        If DataLength <= 0 Then Return False

        Dim RcvArrData(DataLength) As Char
        Dim CheckArray(2) As Char

        RcvArrData = rcvData.ToCharArray

        CheckArray(0) = Chr(79)
        CheckArray(1) = Chr(75)

        If RcvArrData(DataLength - 3) <> CheckArray(0) Then
            Return False
        ElseIf RcvArrData(DataLength - 2) <> CheckArray(1) Then
            Return False
        End If

        Return True

    End Function


#End Region

#End Region

#Region "Creator & Dispose"



    Public Sub New(ByVal numOfDev As Integer)
        MyBase.New()
        m_MyModel = eModel._MC9
        m_nNumOfDev = numOfDev
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        ReDim m_Settings(m_nNumOfDev - 1)
        m_numOfChPerDev = 8

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

#End Region


#Region "Function"

    Public Overrides Function DevINFO(ByVal addr As Integer, ByRef sInfo As String) As CDevTCCommonNode.eReturnCode
        sInfo = ""
        Return eReturnCode.OK
    End Function

    Public Overrides Function Get_Status(ByRef GetData() As Double) As eReturnCode

        Dim rcvData As String = Nothing
        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim ReByte() As Byte
        Dim outdata1(41) As Double

        ReDim RegNoS(0)
        ReDim WDataS(0)
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)

        ReByte = MC9_Array(0, 2000) 'PV/SV/MV/HB 데이터 수신

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return eReturnCode.FuncErr
        End If

        RcvArrData = Split(rcvData, ",")
        If RcvArrData.Length <= 1 Then Return False
        If RcvArrData(1) <> "OK" Then
            Return eReturnCode.FuncErr
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            Mod10(dRcvArrData, GetData)
            ' GetData = dRcvArrData
        End If

        ReByte = MC9_Array(0, 2001) 'Meas Run/Stop

        sCmd = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return eReturnCode.FuncErr
        End If

        ReDim dRcvArrData(ReByte.Length - 1)

        RcvArrData = Split(rcvData, ",")

        If RcvArrData(1) <> "OK" Then
            Return eReturnCode.FuncErr
        Else
            HextoDouble(RcvArrData, dRcvArrData)

            For cnt3 = 0 To GetData.Length - 1
                outdata1(cnt3) = GetData(cnt3)
            Next

            outdata1(34) = dRcvArrData(2)
            outdata1(35) = dRcvArrData(3)
            outdata1(36) = dRcvArrData(4)
            outdata1(37) = dRcvArrData(5)
            outdata1(38) = dRcvArrData(6)
            outdata1(39) = dRcvArrData(7)
            outdata1(40) = dRcvArrData(8)
            outdata1(41) = dRcvArrData(9)

            GetData = outdata1
        End If

        Return eReturnCode.OK

    End Function

    Public Overrides Function Get_Status(ByVal addr As Integer, ByVal devID As Integer, ByRef GetData() As Double) As eReturnCode

        Dim rcvData As String = Nothing
        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim ReByte() As Byte
        Dim outdata1(41) As Double
        ReDim RegNoS(0)
        ReDim WDataS(0)

        ID485 = addr
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)

        ReByte = MC9_Array(0, 2000) 'PV/SV/MV/HB 데이터 수신

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return eReturnCode.FuncErr
        End If

        RcvArrData = Split(rcvData, ",")

        If RcvArrData.Length <= 1 Then Return False

        If RcvArrData(1) <> "OK" Then
            Return eReturnCode.FuncErr
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            Mod10(dRcvArrData, GetData)
            ' GetData = dRcvArrData
        End If

        ReByte = MC9_Array(0, 2001) 'Meas Run/Stop

        sCmd = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return eReturnCode.FuncErr
        End If

        ReDim dRcvArrData(ReByte.Length - 1)

        RcvArrData = Split(rcvData, ",")


        If RcvArrData.Length <= 2 Then Return eReturnCode.FuncErr

        If RcvArrData(1) <> "OK" Then
            Return eReturnCode.FuncErr
        Else

            Try
                HextoDouble(RcvArrData, dRcvArrData)

                For cnt3 = 0 To GetData.Length - 1
                    outdata1(cnt3) = GetData(cnt3)
                Next

                outdata1(34) = dRcvArrData(2)
                outdata1(35) = dRcvArrData(3)
                outdata1(36) = dRcvArrData(4)
                outdata1(37) = dRcvArrData(5)
                outdata1(38) = dRcvArrData(6)
                outdata1(39) = dRcvArrData(7)
                outdata1(40) = dRcvArrData(8)
                outdata1(41) = dRcvArrData(9)

                GetData = outdata1
            Catch ex As Exception
                Return eReturnCode.FuncErr
            End Try
           
        End If

        For i As Integer = 0 To m_Settings(devID).Setting.Length - 1
            m_Settings(devID).Setting(i).measTemp = GetData(2 + i)
            m_Settings(devID).Setting(i).setTemp = GetData(10 + i)

            If GetData(34 + i) = 2 Then
                m_Settings(devID).Setting(i).bIsRun = True
            Else
                m_Settings(devID).Setting(i).bIsRun = False
            End If
        Next

        Return eReturnCode.OK

    End Function

    Public Overrides Function OperationRun() As eReturnCode

        ReDim RegNoS(0)
        ReDim WDataS(0)
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)

        Dim rcvData As String = Nothing

        WCNT = 1
        RegNoS(0) = 305
        WDataS(0) = 1

        Dim ReByte() As Byte
        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 100)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function OperationRun(ByVal addr As Integer) As eReturnCode

        ReDim RegNoS(0)
        ReDim WDataS(0)
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)

        Dim rcvData As String = Nothing

        ID485 = addr

        WCNT = 1
        RegNoS(0) = 305
        WDataS(0) = 1

        Dim ReByte() As Byte
        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 100)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function OperationStop() As eReturnCode
        ReDim RegNoS(0)
        ReDim WDataS(0)
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)

        WCNT = 1
        RegNoS(0) = 305
        WDataS(0) = 0

        Dim rcvData As String = Nothing

        Dim ReByte() As Byte
        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 100)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)

        Return True
    End Function

    Public Overrides Function OperationStop(ByVal addr As Integer) As eReturnCode
        ReDim RegNoS(0)
        ReDim WDataS(0)
        'ReDim RegNoS(0 To 1)
        'ReDim WDataS(0 To 1)
        ID485 = addr
        WCNT = 1
        RegNoS(0) = 305
        WDataS(0) = 0

        Dim rcvData As String = Nothing

        Dim ReByte() As Byte
        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 100)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)

        Return True
    End Function

    Public Overrides Function SetTemperature(ByVal Ch_No As eCHANNEL, ByVal SetData As Double) As eReturnCode

        If SetData > Max_Temperature Then
            Return False
        ElseIf SetData < Min_Temperature Then
            Return False
        End If

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = SetData * 10

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = PARA_CH1_ZONE1
            Case eCHANNEL.CH2
                RegNoS(0) = PARA_CH2_ZONE1
            Case eCHANNEL.CH3
                RegNoS(0) = PARA_CH3_ZONE1
            Case eCHANNEL.CH4
                RegNoS(0) = PARA_CH4_ZONE1
            Case eCHANNEL.CH5
                RegNoS(0) = PARA_CH5_ZONE1
            Case eCHANNEL.CH6
                RegNoS(0) = PARA_CH6_ZONE1
            Case eCHANNEL.CH7
                RegNoS(0) = PARA_CH7_ZONE1
            Case eCHANNEL.Ch8
                RegNoS(0) = PARA_CH8_ZONE1
        End Select


        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)

        Return True

    End Function

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal Ch_No As eCHANNEL, ByVal SetData As Double) As eReturnCode

        If SetData > Max_Temperature Then
            Return False
        ElseIf SetData < Min_Temperature Then
            Return False
        End If

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)
        ID485 = addr
        WCNT = 1
        WDataS(0) = SetData * 10

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = PARA_CH1_ZONE1
            Case eCHANNEL.CH2
                RegNoS(0) = PARA_CH2_ZONE1
            Case eCHANNEL.CH3
                RegNoS(0) = PARA_CH3_ZONE1
            Case eCHANNEL.CH4
                RegNoS(0) = PARA_CH4_ZONE1
            Case eCHANNEL.CH5
                RegNoS(0) = PARA_CH5_ZONE1
            Case eCHANNEL.CH6
                RegNoS(0) = PARA_CH6_ZONE1
            Case eCHANNEL.CH7
                RegNoS(0) = PARA_CH7_ZONE1
            Case eCHANNEL.Ch8
                RegNoS(0) = PARA_CH8_ZONE1
        End Select


        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)

        Return True

    End Function

    Public Overrides Function GetTemperature(ByVal Ch_No As eCHANNEL, ByRef OutData As Double) As eReturnCode

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = 1

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = SV1
            Case eCHANNEL.CH2
                RegNoS(0) = SV2
            Case eCHANNEL.CH3
                RegNoS(0) = SV3
            Case eCHANNEL.CH4
                RegNoS(0) = SV4
            Case eCHANNEL.CH5
                RegNoS(0) = SV5
            Case eCHANNEL.CH6
                RegNoS(0) = SV6
            Case eCHANNEL.CH7
                RegNoS(0) = SV7
            Case eCHANNEL.Ch8
                RegNoS(0) = SV8
        End Select

        ReByte = MC9_Array(0, 101)
        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Overrides Function GetTemperature(ByVal addr As Integer, ByVal Ch_No As eCHANNEL, ByRef OutData As Double) As eReturnCode

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)
        ID485 = addr
        WCNT = 1
        WDataS(0) = 1

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = SV1
            Case eCHANNEL.CH2
                RegNoS(0) = SV2
            Case eCHANNEL.CH3
                RegNoS(0) = SV3
            Case eCHANNEL.CH4
                RegNoS(0) = SV4
            Case eCHANNEL.CH5
                RegNoS(0) = SV5
            Case eCHANNEL.CH6
                RegNoS(0) = SV6
            Case eCHANNEL.CH7
                RegNoS(0) = SV7
            Case eCHANNEL.Ch8
                RegNoS(0) = SV8
        End Select

        ReByte = MC9_Array(0, 101)
        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Function Get_PointingValue(ByVal Ch_No As eCHANNEL, ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = 1

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = PV1
            Case eCHANNEL.CH2
                RegNoS(0) = PV2
            Case eCHANNEL.CH3
                RegNoS(0) = PV3
            Case eCHANNEL.CH4
                RegNoS(0) = PV4
            Case eCHANNEL.CH5
                RegNoS(0) = PV5
            Case eCHANNEL.CH6
                RegNoS(0) = PV6
            Case eCHANNEL.CH7
                RegNoS(0) = PV7
            Case eCHANNEL.Ch8
                RegNoS(0) = PV8
        End Select

        ReByte = MC9_Array(0, 101)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Function Get_PointingValue(ByVal addr As Integer, ByVal Ch_No As eCHANNEL, ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)
        ID485 = addr
        WCNT = 1
        WDataS(0) = 1

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = PV1
            Case eCHANNEL.CH2
                RegNoS(0) = PV2
            Case eCHANNEL.CH3
                RegNoS(0) = PV3
            Case eCHANNEL.CH4
                RegNoS(0) = PV4
            Case eCHANNEL.CH5
                RegNoS(0) = PV5
            Case eCHANNEL.CH6
                RegNoS(0) = PV6
            Case eCHANNEL.CH7
                RegNoS(0) = PV7
            Case eCHANNEL.Ch8
                RegNoS(0) = PV8
        End Select

        ReByte = MC9_Array(0, 101)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Function Get_BiasValue(ByVal addr As Integer, ByVal Ch_No As eCHANNEL, ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        ID485 = addr
        WCNT = 1
        WDataS(0) = 1

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = BIAS1
            Case eCHANNEL.CH2
                RegNoS(0) = BIAS2
            Case eCHANNEL.CH3
                RegNoS(0) = BIAS3
            Case eCHANNEL.CH4
                RegNoS(0) = BIAS4
            Case eCHANNEL.CH5
                RegNoS(0) = BIAS5
            Case eCHANNEL.CH6
                RegNoS(0) = BIAS6
            Case eCHANNEL.CH7
                RegNoS(0) = BIAS7
            Case eCHANNEL.Ch8
                RegNoS(0) = BIAS8
        End Select

        ReByte = MC9_Array(0, 101)
        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")

        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Function Set_BiasValue(ByVal addr As Integer, ByVal Ch_No As eCHANNEL, ByVal SetData As Double) As Boolean

        If SetData > Max_Temperature Then
            Return False
        ElseIf SetData < Min_Temperature Then
            Return False
        End If

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)
        ID485 = addr

        WCNT = 1
        WDataS(0) = SetData * 10

        Select Case Ch_No
            Case eCHANNEL.CH1
                RegNoS(0) = BIAS1
            Case eCHANNEL.CH2
                RegNoS(0) = BIAS2
            Case eCHANNEL.CH3
                RegNoS(0) = BIAS3
            Case eCHANNEL.CH4
                RegNoS(0) = BIAS4
            Case eCHANNEL.CH5
                RegNoS(0) = BIAS5
            Case eCHANNEL.CH6
                RegNoS(0) = BIAS6
            Case eCHANNEL.CH7
                RegNoS(0) = BIAS7
            Case eCHANNEL.Ch8
                RegNoS(0) = BIAS8
        End Select


        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)

        Return True

    End Function

    Public Function Set_ScanTime(ByVal SetData As Double) As Boolean

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = SetData
        RegNoS(0) = SCANTIME

        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)
        Return True
    End Function

    Public Function Get_ScanTime(ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = 1
        RegNoS(0) = SCANTIME

        ReByte = MC9_Array(0, 101)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = dRcvArrData(2) ' (/ 10)
        End If

        Return True

    End Function

    Public Function Set_MaxOperateTemp(ByVal SetData As Double) As Boolean

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = SetData * 10
        RegNoS(0) = FR_H

        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next
        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)
        Return True
    End Function

    Public Function Get_MaxOperateTemp(ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = 1
        RegNoS(0) = 608

        ReByte = MC9_Array(0, 101)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function

    Public Function Set_MinOperateTemp(ByVal SetData As Double) As Boolean

        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = SetData * 10
        RegNoS(0) = FR_L

        'Dim Rebyte As String = Nothing
        ReByte = MC9_Array(0, 232)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        If RcvCheck(rcvData) = False Then
            Return False
        End If

        'Thread.Sleep(DELAY_TIME)
        Return True
    End Function

    Public Function Get_MinOperateTemp(ByRef OutData As Double) As Boolean

        Dim RcvArrData() As String = Nothing
        Dim dRcvArrData() As Integer = Nothing
        Dim rcvData As String = Nothing
        Dim ReByte() As Byte

        ReDim RegNoS(0)
        ReDim WDataS(0)

        WCNT = 1
        WDataS(0) = 1
        RegNoS(0) = FR_L

        ReByte = MC9_Array(0, 101)

        Dim sCmd As String = ""
        For i As Integer = 0 To ReByte.Length - 1
            sCmd = sCmd & Chr(ReByte(i))
        Next

        If communicator.Communicator.SendToString(sCmd, rcvData) = False Then
            Return False
        End If

        RcvArrData = Split(rcvData, ",")


        If RcvArrData(1) <> "OK" Then
            Return False
        Else
            HextoDouble(RcvArrData, dRcvArrData)
            OutData = (dRcvArrData(2) / 10)
        End If

        Return True

    End Function


#End Region

#Region "Data Convert"

    Private Function MC9_Array(ByVal S_Step As Long, ByVal N_Step As Long) As Byte()
        '데이터 형식 생성자

        'tmrTX.Enabled = False

        Dim DCnt As Long

        If N_Step > 0 Then
            S_Step = N_Step
            N_Step = 0
        End If

        Select Case S_Step
            Case 1
                DCnt = 27

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 402
                RegNoS(1) = 701 'INP
                RegNoS(2) = 1
                RegNoS(3) = 2
                RegNoS(4) = 3
                RegNoS(5) = 4
                RegNoS(6) = 5
                RegNoS(7) = 6
                RegNoS(8) = 7
                RegNoS(9) = 8
                RegNoS(10) = 11
                RegNoS(11) = 12
                RegNoS(12) = 13
                RegNoS(13) = 14
                RegNoS(14) = 15
                RegNoS(15) = 16
                RegNoS(16) = 17
                RegNoS(17) = 18
                RegNoS(18) = 101
                RegNoS(19) = 102
                RegNoS(20) = 103
                RegNoS(21) = 104
                RegNoS(22) = 105
                RegNoS(23) = 106
                RegNoS(24) = 107
                RegNoS(25) = 108
                RegNoS(26) = 305

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 2
                DCnt = 24

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 111
                RegNoS(1) = 112
                RegNoS(2) = 113
                RegNoS(3) = 114
                RegNoS(4) = 115
                RegNoS(5) = 116
                RegNoS(6) = 117
                RegNoS(7) = 118
                RegNoS(8) = 201
                RegNoS(9) = 202
                RegNoS(10) = 203
                RegNoS(11) = 204
                RegNoS(12) = 205
                RegNoS(13) = 206
                RegNoS(14) = 207
                RegNoS(15) = 208
                RegNoS(16) = 211
                RegNoS(17) = 212
                RegNoS(18) = 213
                RegNoS(19) = 214
                RegNoS(20) = 215
                RegNoS(21) = 216
                RegNoS(22) = 217
                RegNoS(23) = 218

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 3 'ALM Ststus
                DCnt = 24

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 129
                RegNoS(1) = 130
                RegNoS(2) = 131
                RegNoS(3) = 132
                RegNoS(4) = 133
                RegNoS(5) = 134
                RegNoS(6) = 135
                RegNoS(7) = 136
                RegNoS(8) = 145
                RegNoS(9) = 146
                RegNoS(10) = 147
                RegNoS(11) = 148
                RegNoS(12) = 149
                RegNoS(13) = 150
                RegNoS(14) = 151
                RegNoS(15) = 152
                RegNoS(16) = 161
                RegNoS(17) = 162
                RegNoS(18) = 163
                RegNoS(19) = 164
                RegNoS(20) = 165
                RegNoS(21) = 166
                RegNoS(22) = 167
                RegNoS(23) = 168

                'Call Send_IRR(ID485, DCnt, RegNoS)
            Case 21
                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 301
                RegNoS(1) = 302
                RegNoS(2) = 305
                RegNoS(3) = 401
                RegNoS(4) = 403
                RegNoS(5) = 404
                RegNoS(6) = 405
                RegNoS(7) = 406
                RegNoS(8) = 407
                RegNoS(9) = 408
                RegNoS(10) = 409
                RegNoS(11) = 410
                RegNoS(12) = 411
                RegNoS(13) = 412
                RegNoS(14) = 413
                RegNoS(15) = 414
                RegNoS(16) = 415
                '        RegNoS(17) = 501
                RegNoS(17) = 416
                RegNoS(18) = 502
                RegNoS(19) = 503
                RegNoS(20) = 504
                RegNoS(21) = 505
                RegNoS(22) = 506
                RegNoS(23) = 507
                RegNoS(24) = 508
                RegNoS(25) = 509
                RegNoS(26) = 417
                RegNoS(27) = 418
                RegNoS(28) = 419
                RegNoS(29) = 608
                RegNoS(30) = 609
                RegNoS(31) = 704 'SYSDATA (HC)

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 30
                DCnt = 21

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 701 'INP
                RegNoS(1) = 702 'OUT1
                RegNoS(2) = 703 'OUT2
                RegNoS(3) = 704 'SYSDATA (HC)
                RegNoS(4) = 417 'ALT1
                RegNoS(5) = 418 'ALT2
                RegNoS(6) = 419 'ALT3
                RegNoS(7) = 507 'SCAN
                RegNoS(8) = 508 'LOCK1
                RegNoS(9) = 509 'LOCK2
                RegNoS(10) = 608 'FR-H
                RegNoS(11) = 609 'FR-L
                RegNoS(12) = 801 'HBA1
                RegNoS(13) = 802 'HBA2
                RegNoS(14) = 803 'HBA3
                RegNoS(15) = 804 'HBA4
                RegNoS(16) = 805 'HBA5
                RegNoS(17) = 806 'HBA6
                RegNoS(18) = 807 'HBA7
                RegNoS(19) = 808 'HBA8
                RegNoS(20) = 416 'DISL

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 31
                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 811 'BIAS1
                RegNoS(1) = 812 'BIAS2
                RegNoS(2) = 813 'BIAS3
                RegNoS(3) = 814 'BIAS4
                RegNoS(4) = 815 'BIAS5
                RegNoS(5) = 816 'BIAS6
                RegNoS(6) = 817 'BIAS7
                RegNoS(7) = 818 'BIAS8
                RegNoS(8) = 821 'FILT1
                RegNoS(9) = 822 'FILT2
                RegNoS(10) = 823 'FILT3
                RegNoS(11) = 824 'FILT4
                RegNoS(12) = 825 'FILT5
                RegNoS(13) = 826 'FILT6
                RegNoS(14) = 827 'FILT7
                RegNoS(15) = 828 'FILT8
                RegNoS(16) = 901 'CT1
                RegNoS(17) = 902 'CT2
                RegNoS(18) = 903 'CT3
                RegNoS(19) = 904 'CT4
                RegNoS(20) = 905 'CT5
                RegNoS(21) = 906 'CT6
                RegNoS(22) = 907 'CT7
                RegNoS(23) = 908 'CT8
                RegNoS(24) = 911 'CTC1
                RegNoS(25) = 912 'CTC2
                RegNoS(26) = 913 'CTC3
                RegNoS(27) = 914 'CTC4
                RegNoS(28) = 915 'CTC5
                RegNoS(29) = 916 'CTC6
                RegNoS(30) = 917 'CTC7
                RegNoS(31) = 918 'CTC8

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 32
                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 1001 'C1Z1
                RegNoS(1) = 1002 'C1Z2
                RegNoS(2) = 1003 'C1Z3
                RegNoS(3) = 1004 'C1Z4
                RegNoS(4) = 1005 'C1Z5
                RegNoS(5) = 1006 'C1Z6
                RegNoS(6) = 1007 'C1Z7
                RegNoS(7) = 1008 'C1Z8
                RegNoS(8) = 1009 'C2Z1
                RegNoS(9) = 1010 'C2Z2
                RegNoS(10) = 1011 'C2Z3
                RegNoS(11) = 1012 'C2Z4
                RegNoS(12) = 1013 'C2Z5
                RegNoS(13) = 1014 'C2Z6
                RegNoS(14) = 1015 'C2Z7
                RegNoS(15) = 1016 'C2Z8
                RegNoS(16) = 1017 'C3Z1
                RegNoS(17) = 1018 'C3Z2
                RegNoS(18) = 1019 'C3Z3
                RegNoS(19) = 1020 'C3Z4
                RegNoS(20) = 1021 'C3Z5
                RegNoS(21) = 1022 'C3Z6
                RegNoS(22) = 1023 'C3Z7
                RegNoS(23) = 1024 'C3Z8
                RegNoS(24) = 1025 'C4Z1
                RegNoS(25) = 1026 'C4Z2
                RegNoS(26) = 1027 'C4Z3
                RegNoS(27) = 1028 'C4Z4
                RegNoS(28) = 1029 'C4Z5
                RegNoS(29) = 1030 'C4Z6
                RegNoS(30) = 1031 'C4Z7
                RegNoS(31) = 1032 'C4Z8

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 33
                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 1101 'C5Z1
                RegNoS(1) = 1102 'C5Z2
                RegNoS(2) = 1103 'C5Z3
                RegNoS(3) = 1104 'C5Z4
                RegNoS(4) = 1105 'C5Z5
                RegNoS(5) = 1106 'C5Z6
                RegNoS(6) = 1107 'C5Z7
                RegNoS(7) = 1108 'C5Z8
                RegNoS(8) = 1109 'C6Z1
                RegNoS(9) = 1110 'C6Z2
                RegNoS(10) = 1111 'C6Z3
                RegNoS(11) = 1112 'C6Z4
                RegNoS(12) = 1113 'C6Z5
                RegNoS(13) = 1114 'C6Z6
                RegNoS(14) = 1115 'C6Z7
                RegNoS(15) = 1116 'C6Z8
                RegNoS(16) = 1117 'C7Z1
                RegNoS(17) = 1118 'C7Z2
                RegNoS(18) = 1119 'C7Z3
                RegNoS(19) = 1120 'C7Z4
                RegNoS(20) = 1121 'C7Z5
                RegNoS(21) = 1122 'C7Z6
                RegNoS(22) = 1123 'C7Z7
                RegNoS(23) = 1124 'C7Z8
                RegNoS(24) = 1125 'C8Z1
                RegNoS(25) = 1126 'C8Z2
                RegNoS(26) = 1127 'C8Z3
                RegNoS(27) = 1128 'C8Z4
                RegNoS(28) = 1129 'C8Z5
                RegNoS(29) = 1130 'C8Z6
                RegNoS(30) = 1131 'C8Z7
                RegNoS(31) = 1132 'C8Z8

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 40
                DCnt = 21

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 701 'INP
                RegNoS(1) = 702 'OUT1
                RegNoS(2) = 703 'OUT2
                RegNoS(3) = 704 'SYSDATA (HC)
                RegNoS(4) = 417 'ALT1
                RegNoS(5) = 418 'ALT2
                RegNoS(6) = 419 'ALT3
                RegNoS(7) = 507 'SCAN
                RegNoS(8) = 508 'LOCK1
                RegNoS(9) = 509 'LOCK2
                RegNoS(10) = 608 'FR-H
                RegNoS(11) = 609 'FR-L
                RegNoS(12) = 801 'HBA1
                RegNoS(13) = 802 'HBA2
                RegNoS(14) = 803 'HBA3
                RegNoS(15) = 804 'HBA4
                RegNoS(16) = 805 'HBA5
                RegNoS(17) = 806 'HBA6
                RegNoS(18) = 807 'HBA7
                RegNoS(19) = 808 'HBA8
                RegNoS(20) = 416 'DISL

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 41
                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = 811 'BIAS1
                RegNoS(1) = 812 'BIAS2
                RegNoS(2) = 813 'BIAS3
                RegNoS(3) = 814 'BIAS4
                RegNoS(4) = 815 'BIAS5
                RegNoS(5) = 816 'BIAS6
                RegNoS(6) = 817 'BIAS7
                RegNoS(7) = 818 'BIAS8
                RegNoS(8) = 821 'FILT1
                RegNoS(9) = 822 'FILT2
                RegNoS(10) = 823 'FILT3
                RegNoS(11) = 824 'FILT4
                RegNoS(12) = 825 'FILT5
                RegNoS(13) = 826 'FILT6
                RegNoS(14) = 827 'FILT7
                RegNoS(15) = 828 'FILT8
                RegNoS(16) = 901 'CT1
                RegNoS(17) = 902 'CT2
                RegNoS(18) = 903 'CT3
                RegNoS(19) = 904 'CT4
                RegNoS(20) = 905 'CT5
                RegNoS(21) = 906 'CT6
                RegNoS(22) = 907 'CT7
                RegNoS(23) = 908 'CT8
                RegNoS(24) = 911 'CTC1
                RegNoS(25) = 912 'CTC2
                RegNoS(26) = 913 'CTC3
                RegNoS(27) = 914 'CTC4
                RegNoS(28) = 915 'CTC5
                RegNoS(29) = 916 'CTC6
                RegNoS(30) = 917 'CTC7
                RegNoS(31) = 918 'CTC8

                Return Send_DRR(ID485, DCnt, RegNoS)

            Case 100 'Data Write 형식
                Return Send_DWR(ID485, WCNT, RegNoS, WDataS)

            Case 101 'Data Read 형식
                Return Send_DRR(ID485, WCNT, RegNoS)

            Case 132 'ParaNo Write -> refresh (ZONE,CH)
                DCnt = 1

                ReDim RegNoS(0 To DCnt - 1)
                ReDim WDataS(0 To DCnt - 1)

                RegNoS(0) = 1000
                WDataS(0) = W_ParaNo

                'Call Send_DWR(ID485, DCnt, RegNoS, WDataS)
            Case 140, 232 'Parameter Write -> refresh
                ' Call Send_DWR(ID485, 1, RegNoS, WDataS)

                Return Send_DWR(ID485, 1, RegNoS, WDataS)

            Case 2000 'PV/SV/MV/HB Read 형식

                DCnt = 32

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = PV1
                RegNoS(1) = PV2
                RegNoS(2) = PV3
                RegNoS(3) = PV4
                RegNoS(4) = PV5
                RegNoS(5) = PV6
                RegNoS(6) = PV7
                RegNoS(7) = PV8
                RegNoS(8) = SV1
                RegNoS(9) = SV2
                RegNoS(10) = SV3
                RegNoS(11) = SV4
                RegNoS(12) = SV5
                RegNoS(13) = SV6
                RegNoS(14) = SV7
                RegNoS(15) = SV8
                RegNoS(16) = MV1
                RegNoS(17) = MV2
                RegNoS(18) = MV3
                RegNoS(19) = MV4
                RegNoS(20) = MV5
                RegNoS(21) = MV6
                RegNoS(22) = MV7
                RegNoS(23) = MV8
                RegNoS(24) = HB1
                RegNoS(25) = HB2
                RegNoS(26) = HB3
                RegNoS(27) = HB4
                RegNoS(28) = HB5
                RegNoS(29) = HB6
                RegNoS(30) = HB7
                RegNoS(31) = HB8

                Return Send_DRR(ID485, DCnt, RegNoS)

            Case 2001 'Meas Run/Stop Read 형식

                DCnt = 8

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = STS1
                RegNoS(1) = STS2
                RegNoS(2) = STS3
                RegNoS(3) = STS4
                RegNoS(4) = STS5
                RegNoS(5) = STS6
                RegNoS(6) = STS7
                RegNoS(7) = STS8

                Return Send_DRR(ID485, DCnt, RegNoS)
            Case 2002 'PV/SV/Meas.Run/Stop 형식

                DCnt = 23

                ReDim RegNoS(0 To DCnt - 1)

                RegNoS(0) = PV1
                RegNoS(1) = PV2
                RegNoS(2) = PV3
                RegNoS(3) = PV4
                RegNoS(4) = PV5
                RegNoS(5) = PV6
                RegNoS(6) = PV7
                RegNoS(7) = PV8
                RegNoS(8) = SV1
                RegNoS(9) = SV2
                RegNoS(10) = SV3
                RegNoS(11) = SV4
                RegNoS(12) = SV5
                RegNoS(13) = SV6
                RegNoS(14) = SV7
                RegNoS(15) = SV8
                RegNoS(16) = STS1
                RegNoS(17) = STS2
                RegNoS(18) = STS3
                RegNoS(19) = STS4
                RegNoS(20) = STS5
                RegNoS(21) = STS6
                RegNoS(22) = STS7
                RegNoS(23) = STS8

                Return Send_DRR(ID485, DCnt, RegNoS)


        End Select

        Return Nothing
    End Function


    Private Function Send_DRR(ByVal Addr As Long, ByVal CNT As Long, ByVal RegNo() As Long) As Byte()
        Dim SendBuf() As Byte
        Dim i As Long
        Dim myUBound As Long

        myUBound = (10 + (CNT * 5) + ChksumV + 1) - 3
        ReDim SendBuf(0 To myUBound)

        SendBuf(0) = &H2
        SendBuf(1) = Asc(CStr(Addr \ 10))
        SendBuf(2) = Asc(CStr(Addr Mod 10))
        SendBuf(3) = Asc("D")
        SendBuf(4) = Asc("R")
        SendBuf(5) = Asc("R")
        SendBuf(6) = Asc(",")
        SendBuf(7) = Asc(CStr(CNT \ 10))
        SendBuf(8) = Asc(CStr(CNT Mod 10))
        For i = 1 To CNT
            SendBuf((i - 1) * 5 + 9) = Asc(",")
            SendBuf((i - 1) * 5 + 10) = Asc(CStr(RegNo(i - 1) \ 1000))
            SendBuf((i - 1) * 5 + 11) = Asc(CStr(RegNo(i - 1) Mod 1000) \ 100)
            SendBuf((i - 1) * 5 + 12) = Asc(CStr(RegNo(i - 1) Mod 100) \ 10)
            SendBuf((i - 1) * 5 + 13) = Asc(CStr(RegNo(i - 1) Mod 10))
        Next i

        If ChksumV > 0 Then
            Call Add_Chksum(SendBuf)
        End If
        'SendBuf(myUBound - 2) = &HD
        'SendBuf(myUBound - 1) = &HA

        'SendBuf(myUBound) = (&H0)
        Return SendBuf

    End Function

    Private Function Send_DWR(ByVal Addr As Long, ByVal CNT As Long, ByVal RegNo() As Long, ByVal WData() As Long) As Byte()
        Dim SendBuf() As Byte
        Dim i As Long
        Dim myUBound As Long
        Dim HexStr As String

        myUBound = 10 + (CNT * 10) + ChksumV + 1
        ReDim SendBuf(0 To myUBound)

        SendBuf(0) = &H2
        SendBuf(1) = Asc(CStr(Addr \ 10))
        SendBuf(2) = Asc(CStr(Addr Mod 10))
        SendBuf(3) = Asc("D")
        SendBuf(4) = Asc("W")
        SendBuf(5) = Asc("R")
        SendBuf(6) = Asc(",")
        SendBuf(7) = Asc(CStr(CNT \ 10))
        SendBuf(8) = Asc(CStr(CNT Mod 10))
        For i = 1 To CNT
            SendBuf((i - 1) * 10 + 9) = Asc(",")
            SendBuf((i - 1) * 10 + 10) = Asc(CStr(RegNo(i - 1) \ 1000))
            SendBuf((i - 1) * 10 + 11) = Asc(CStr(RegNo(i - 1) Mod 1000) \ 100)
            SendBuf((i - 1) * 10 + 12) = Asc(CStr(RegNo(i - 1) Mod 100) \ 10)
            SendBuf((i - 1) * 10 + 13) = Asc(CStr(RegNo(i - 1) Mod 10))
            SendBuf((i - 1) * 10 + 14) = Asc(",")

            HexStr = Dec2Hex(CLng(WData(i - 1)), 4)
            SendBuf((i - 1) * 10 + 15) = Asc(Mid(HexStr, 1, 1))
            SendBuf((i - 1) * 10 + 16) = Asc(Mid(HexStr, 2, 1))
            SendBuf((i - 1) * 10 + 17) = Asc(Mid(HexStr, 3, 1))
            SendBuf((i - 1) * 10 + 18) = Asc(Mid(HexStr, 4, 1))
        Next i

        If ChksumV > 0 Then
            Call Add_Chksum(SendBuf)
        End If
        'SendBuf(myUBound - 2) = &HD
        'SendBuf(myUBound - 1) = &HA
        'SendBuf(myUBound) = &H0

        Return SendBuf

        'CommOBJ.RThreshold = 1
        'If CommOBJ.PortOpen = True Then
        '    Comm_ErrOBJ.Enabled = True

        '    CommOBJ.RTSEnable = True
        '    CommOBJ.Output = SendBuf
        '    CommOBJ.Output = Chr(&H0)
        '    CommOBJ.RTSEnable = False
        'End If
    End Function

    Private Function Dec2Hex(ByVal sDec As Long, ByVal HexSize As Long) As String
        Dim i As Long
        Dim sHex As String
        Dim sDec2Hex As String = Nothing
        'Dec2Hex = Nothing

        If sDec < 0 Then
            sDec = 65536 + sDec
        End If

        sHex = Hex(sDec)

        For i = Len(sHex) + 1 To HexSize
            sDec2Hex = sDec2Hex & "0"
        Next i
        sDec2Hex = sDec2Hex & sHex
        Return sDec2Hex
    End Function

    Private Sub Add_Chksum(ByRef addData As Object)
        Dim i As Long
        Dim chksum As Long

        For i = 1 To UBound(addData) - 4
            chksum = chksum + addData(i)
        Next i
        chksum = chksum Mod 256

        addData(UBound(addData) - 3) = Asc(Hex(chksum \ 16))
        addData(UBound(addData) - 2) = Asc(Hex(chksum Mod 16))
    End Sub


    Private Function HextoDouble(ByVal in_data() As String, ByRef out_data() As Integer) As Boolean

        Dim length As Integer
        Dim sdata(in_data.Length - 1) As String
        Dim bdata(3) As Byte

        length = in_data.Length

        Dim out_databuff(in_data.Length - 1) As Integer

        For Cnt = 0 To (length - 1)
            ' sdata(1) = Mid(in_data(Cnt), 1, 1)

            For Cnt2 = 0 To 3
                sdata(Cnt) = Nothing
                sdata(Cnt) = Mid(in_data(Cnt), Cnt2 + 1, 1)

                '                Thread.Sleep(5)

                Select Case sdata(Cnt)
                    Case CStr(0)
                        bdata(Cnt2) = 0
                    Case CStr(1)
                        bdata(Cnt2) = 1
                    Case CStr(2)
                        bdata(Cnt2) = 2
                    Case CStr(3)
                        bdata(Cnt2) = 3
                    Case CStr(4)
                        bdata(Cnt2) = 4
                    Case CStr(5)
                        bdata(Cnt2) = 5
                    Case CStr(6)
                        bdata(Cnt2) = 6
                    Case CStr(7)
                        bdata(Cnt2) = 7
                    Case CStr(8)
                        bdata(Cnt2) = 8
                    Case CStr(9)
                        bdata(Cnt2) = 9
                    Case "A"
                        bdata(Cnt2) = 10
                    Case "B"
                        bdata(Cnt2) = 11
                    Case "C"
                        bdata(Cnt2) = 12
                    Case "D"
                        bdata(Cnt2) = 13
                    Case "E"
                        bdata(Cnt2) = 14
                    Case "F"
                        bdata(Cnt2) = 15
                End Select

            Next

            If Cnt > 1 Then
                out_databuff(Cnt) = (CInt(bdata(0)) * (4096)) + (CInt(bdata(1)) * (256)) + (CInt(bdata(2)) * 16) + CInt(bdata(3))

                If out_databuff(Cnt) > 63536 Then ' 음수값 연산
                    ' EX) 음수 대역 프로토콜 수신 값
                    ' 65535(FFFF) = -0.1, 63534(FFFB) = -0.2, 63537(F831) = -199.9
                    out_databuff(Cnt) = out_databuff(Cnt) - 65536
                End If
            End If

            If Cnt = length - 1 Then
                out_data = out_databuff
            End If

        Next
        Return True
    End Function

    Private Sub Mod10(ByVal in_data() As Integer, ByRef out_data() As Double)
        '프로토콜 데이터 형변환(Arr 데이터 용)
        'EX) 수신 데이터 1000 일 경우 화면상에는 100.0 입니다.

        ReDim out_data(in_data.Length - 1)

        For cnt = 0 To in_data.Length - 1
            out_data(cnt) = in_data(cnt) / 10
        Next


    End Sub


#End Region


End Class
