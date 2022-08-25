Imports System
Imports System.IO
Imports System.Threading
Imports CCommLib

Public Class CDevCS100A
    Inherits CDevColorAnalyzerCommonNode

#Region "Define"

    Dim m_SettingInfos As sSettings
    Dim m_MeasDatas As sDataInfos

#Region "Structure"

    Public Structure sSettings
        Dim calibrationMode As eCalibrationMode
        Dim measuringMode As eMeasuringMode
        Dim speedMode As eSpeedmode
    End Structure

    Public Structure sDatas
        Dim dY As Double
        Dim dCIEx As Double
        Dim dCIEy As Double
        Dim dDiff_Y As Double
        Dim dDiff_CIEx As Double
        Dim dDiff_CIEy As Double
    End Structure

#End Region

#Region "Enum"


    Public Enum eCalibrationMode
        _Preset      'MINOLTA calibration standard mode "00"
        _Vari          'Arbitrary calibration standard mode "01"
    End Enum

    Public Enum eMeasuringMode
        _ABS       'Color measuring mode "04"
        _DIFF      'Color difference measuring mode "05"
    End Enum

    Public Enum eSpeedmode
        _FAST      'Measuring response time 100msec. "06"
        _SLOW    'Measuring response time 400msec. "07"
    End Enum

#End Region

#End Region


#Region "Creator, Disposer and Init"

    Public Sub New()
        MyBase.New()
        MyBase.m_bIsConnected = False
        comm = New CComAPI(CComCommonNode.eCommType.eSerial)  ' = New CComSerial
        m_MyModel = eModel.eColorAnalyzer_CS100A
    End Sub

#End Region


  

#Region "Communication Functions"

    Public Overrides Function Connection(config As CCommLib.CComCommonNode.sCommInfo) As Boolean

        Dim ret As CComCommonNode.eReturnCode = comm.Communicator.Connect(config)

        If ret <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        MyBase.m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        comm.Communicator.Disconnect()
        MyBase.m_bIsConnected = False
    End Sub


    Public Overrides Function Initialization() As Boolean
        Return True
    End Function
    'Public Overrides Function Connection(ByVal info As stSgConfig) As Boolean

    '    Dim ret As Integer = comm.Communicator.Connect(info.sSerialInfo)

    '    If ret <> CComSerial.eReturnCode.OK Then '1 Then
    '        Return False
    '    End If

    '    Return True
    'End Function



#End Region


#Region "Control Functions"


    Public Overrides Function SetSettings(infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        If SetMeauringMode(infos.sCS100Settings.measuringMode) = False Then Return False
        If SetCalibrationMode(infos.sCS100Settings.calibrationMode) = False Then Return False
        If SetSpeedMode(infos.sCS100Settings.speedMode) = False Then Return False

        Return True
    End Function


    Public Function SetMeauringMode(ByVal mode As eMeasuringMode) As Boolean
        Dim sCommand As String = "MDS,"

        Select Case mode

            Case eMeasuringMode._ABS
                sCommand = sCommand & "04"
            Case eMeasuringMode._DIFF
                sCommand = sCommand & "05"
            Case Else
                MyBase.m_sErrMsg = "Undefined mode selected"
                Return False
        End Select

        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            MyBase.m_sErrMsg = comm.Communicator.StateMessage
            Return False
        End If

        sRcvData = sRcvData.TrimStart("?")

        If ErrCheck(sRcvData) = False Then Return False

        m_SettingInfos.measuringMode = mode

        Return True
    End Function

    Public Function SetCalibrationMode(ByVal mode As eCalibrationMode) As Boolean
        Dim sCommand As String = "MDS,"

        Select Case mode
            Case eCalibrationMode._Preset
                sCommand = sCommand & "00"
            Case eCalibrationMode._Vari
                sCommand = sCommand & "01"
            Case Else
                MyBase.m_sErrMsg = "Undefined mode selected"
                Return False
        End Select

        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            MyBase.m_sErrMsg = comm.Communicator.StateMessage
            Return False
        End If

        sRcvData = sRcvData.TrimStart("?")

        If ErrCheck(sRcvData) = False Then Return False

        m_SettingInfos.calibrationMode = mode

        Return True
    End Function

    Public Function SetSpeedMode(ByVal mode As eSpeedmode) As Boolean
        Dim sCommand As String = "MDS,"

        Select Case mode
            Case eSpeedmode._FAST
                sCommand = sCommand & "06"
            Case eSpeedmode._SLOW
                sCommand = sCommand & "07"
            Case Else
                MyBase.m_sErrMsg = "Undefined mode selected"
                Return False
        End Select

        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            MyBase.m_sErrMsg = comm.Communicator.StateMessage
            Return False
        End If

        sRcvData = sRcvData.TrimStart("?")

        If ErrCheck(sRcvData) = False Then Return False

        m_SettingInfos.speedMode = mode

        Return True
    End Function

    Public Overrides Function Measure(ByRef measuredDatas As sDataInfos) As Boolean
        Dim sCommand As String = "MES"
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            MyBase.m_sErrMsg = comm.Communicator.StateMessage
            Return False
        End If

        sRcvData = sRcvData.TrimStart("?")

        If ErrCheck(sRcvData) = False Then Return False

        Dim strEachDatas() As String = Nothing
        Dim strStateMsg As String = ""
        If DivideAndGetEachData(sRcvData, strEachDatas) = False Then
            MyBase.m_sErrMsg = "Data Parsing Error"
            Return False
        End If

        strStateMsg = strEachDatas(0).Substring(0, 2)

        With m_MeasDatas

            If strStateMsg = "OK" Then

                If m_SettingInfos.measuringMode = eMeasuringMode._ABS Then
                    .Data.dCIEx = strEachDatas(2)
                    .Data.dCIEy = strEachDatas(3)

                ElseIf m_SettingInfos.measuringMode = eMeasuringMode._DIFF Then
                    Dim strSign As String  '부호(Sign) 문자
                    Dim dVal As Double
                    strSign = strEachDatas(1).Substring(0, 1)
                    dVal = strEachDatas(1).Substring(1, strEachDatas(1).Length - 1)
                    If strSign <> "+" Then
                        dVal = dVal * -1
                    End If
                    .Data.dDiff_Y = dVal 'strEachDatas(1)

                    strSign = strEachDatas(2).Substring(0, 1)
                    dVal = strEachDatas(2).Substring(1, strEachDatas(2).Length - 1)
                    If strSign <> "+" Then
                        dVal = dVal * -1
                    End If

                    .Data.dDiff_CIEx = dVal 'strEachDatas(2)

                    strSign = strEachDatas(3).Substring(0, 1)
                    dVal = strEachDatas(3).Substring(1, strEachDatas(3).Length - 1)
                    If strSign <> "+" Then
                        dVal = dVal * -1
                    End If
                    .Data.dDiff_CIEy = dVal 'strEachDatas(3)
                End If

            Else
                MyBase.m_sErrMsg = "Received Data Error"
                Return False
            End If

        End With

        measuredDatas = m_MeasDatas

        Return True
    End Function

    Private Function DivideAndGetEachData(ByVal In_strLineInput As String, ByRef Out_strEach() As String) As Boolean
        Dim arrbuf As Array
        Dim i As Integer

        arrbuf = In_strLineInput.Split(",")

        For i = 0 To arrbuf.Length - 1
            ReDim Preserve Out_strEach(i)
            Out_strEach(i) = arrbuf(i)
        Next

        Return True
    End Function

    Private Function ErrCheck(ByVal inRcvStr As String) As Boolean
        Dim ErrMsg() As String = inRcvStr.Split(",")
        Dim sMsg() As String = ErrMsg(0).Split(vbCrLf)
        Dim bStr() As String = inRcvStr.Split(vbCrLf)
        Select Case sMsg(0)
            Case "OK00"
                MyBase.m_sErrMsg = "No Error"
            Case "OK11"
                MyBase.m_sErrMsg = "Chromaticity measuring range over"
            Case "OK12"
                MyBase.m_sErrMsg = "Luminance range over"
            Case "OK13"
                MyBase.m_sErrMsg = "Luminance range under"
            Case "ER00"
                MyBase.m_sErrMsg = "CS100 Command Error"
                Return False
            Case "ER01"
                MyBase.m_sErrMsg = "CS100 Setting Error"
                Return False
            Case "ER11"
                MyBase.m_sErrMsg = "CS100 Memory Value Error"
                Return False
            Case "ER10"
                MyBase.m_sErrMsg = "CS100 Yxy Range Over"
                Return False
            Case "ER12"
                MyBase.m_sErrMsg = "CS100 Display Range Simultaneous Over"
                Return False
            Case "ER19"
                MyBase.m_sErrMsg = "CS100 Display Range Over"
                Return False
            Case "ER20"
                MyBase.m_sErrMsg = "CS100 EEPROM Error"
                Return False
            Case "ER30"
                MyBase.m_sErrMsg = "CS100 Battery Out"
                Return False
            Case Else
                MyBase.m_sErrMsg = "Unknow Error"
                Return False
        End Select

        Return True
    End Function


#End Region

End Class
