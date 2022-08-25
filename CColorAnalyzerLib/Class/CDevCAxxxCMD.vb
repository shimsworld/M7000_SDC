Imports CCommLib

Public Class CDevCAxxxCMD
    Inherits CDevColorAnalyzerCommonNode

#Region "Define"

    Private m_CommSettings As CCommLib.CComSerial.sSerialPortInfo
    Private m_settings As sSettings
    Private m_nProbeID As Integer = 1

    Private m_sDefErrMsg() As String = New String() {"completed successfully",
                                                     "Current probe is defferent than the probe used for user calibration or target color setting.(Equivalent to E1 error message on instrument.) ",
                                                     "Ambient temperature has changed by more than a certain amount since aero calibration was performed.(Equivalent to E2 error message on instrument.)",
                                                    "Current probe is defferent than the probe used for user calibration or target color setting.(Equivalent to E1 error message on instrument.) & Ambient temperature has changed by more than a certain amount since aero calibration was performed.(Equivalent to E2 error message on instrument.)",
                                                    "Outside of measurement range.(Equivalent to blinking display on instrument)",
                                                    "Current probe is defferent than the probe used for user calibration or target color setting.(Equivalent to E1 error message on instrument.) & Outside of measurement range.(Equivalent to blinking display on instrument)",
                                                     "Ambient temperature has changed by more than a certain amount since aero calibration was performed.(Equivalent to E2 error message on instrument.) & Outside of measurement range.(Equivalent to blinking display on instrument)",
                                                     "Current probe is defferent than the probe used for user calibration or target color setting.(Equivalent to E1 error message on instrument.) & Ambient temperature has changed by more than a certain amount since aero calibration was performed.(Equivalent to E2 error message on instrument.) & Outside of measurement range.(Equivalent to blinking display on instrument)",
                                                     "Command error",
                                                     "Hold error(An attempt was made to measure color value while in flicker hold or flicker measurement was attempted while in color measurement hold",
                                                    "Improper external synchronization signal(when in EXT. mode; Equivalent to E7 error message on instrument.)",
                                                     "Light not completely blocked from reaching probe. LCD will Display 'TOO BRIGHT'",
                                                    "Over measurement range(Equivalent to OVER error message on instrument)",
                                                    "Offset error(Equivalent to OFFSET ERROR error message on instrument)",
                                                     "Outside of display range(when in dT uvLv mode)",
                                                     "Measured flicker value exceeds 100%",
                                                     "In Flicker mode, VSYNC setting exceeds setting range. (Setting is higher than 130Hz.)",
                                                     "In Flicker mode, measurement is not possible due to low luminance.",
                                                     "CA-210U or CA-210US probe is connected and Flicker mode is selected.",
                                                     "undefiend error"}


#Region "Structure"

    Public Structure sSettings
        Dim syncMode As Single
        Dim dispMode As CDevCAxxxCMD.eDispMode
        Dim dispDigits As CDevCAxxxCMD.eDispDigit
        Dim avgMode As CDevCAxxxCMD.eAveragingMode
        Dim brightnessMode As CDevCAxxxCMD.eBrightnessUnit
        Dim devInfo As CDevCAxxxCMD.sDevInfo
        Dim calMode As CDevCAxxxCMD.eCalibrationMode
        Dim nMemChannelNo As Integer
    End Structure

    Public Structure sDatas
        Dim X As Double
        Dim Y As Double
        Dim Z As Double
        Dim Lv As Double
        Dim sx As Double    'CIE1931
        Dim sy As Double
        Dim u As Double    'CIE1960
        Dim v As Double
        Dim ud As Double    'CIE1976 x
        Dim vd As Double    'CIE1976 y
        Dim T As Double
        Dim LsUser As Double
        Dim usUser As Double
        Dim vsUser As Double
        Dim dEUser As Double
        Dim duv As Double
        Dim Rvalue As Double
        Dim Bvalue As Double
        Dim Gvalue As Double

        Dim CCT As Double
        Dim BBL_x As Double
        Dim BBL_y As Double
        Dim BBL_u As Double
        Dim BBL_v As Double
        Dim MPCD As Double
    End Structure


    Public Structure sDevInfo
        Dim sModel As String
        Dim sFirmwareVersion As String
        Dim nIDNumber As Long
        Dim sCommPort As String
    End Structure

#End Region

#Region "Enums"

    Public Enum eErrorChkCode
        OK00
        OK01
        OK02
        OK03
        OK04
        OK05
        OK06
        OK07
        ER10
        ER15
        ER20
        ER21
        ER22
        ER23
        ER24
        ER50
        ER51
        ER52
        ER53
        ER_undef
    End Enum

    Public Enum eDispMode
        Lvxy
        Tdudv
        AnalyzerMode_NoAnalog
        AnalyzerMode_G_Standard
        AnalyzerMode_R_Standard
        uDot_vDot
        FlickerMode
        XYZ
        JEITAFlicker
    End Enum

    Public Enum eSyncMode
        NTSC
        PAL
        EXT
        UNIV
        Frequency
    End Enum

    Public Enum eRemoteMode
        RemoteOFF
        RemoteON
        RemoteLOCKED
    End Enum

    Public Enum eDispDigit
        digit_3
        digit_4
    End Enum

    Public Enum eAveragingMode
        SLOW
        FAST
        AUTO
    End Enum

    Public Enum eBrightnessUnit
        fL
        cd_m2
    End Enum

    Public Enum eCalibrationMode
        e6500K = 1
        e9300K
    End Enum

#End Region

#End Region


#Region "Properties"



#End Region




#Region "Creator & init"

    Public Sub New()
        MyBase.new()
        comm = New CCommLib.CComAPI(CComCommonNode.eCommType.eSerial)
        MyBase.m_bIsConnected = False
        m_MyModel = eModel.eColorAnalyzer_CAxxxCmdMode
    End Sub

    Public Sub Dispose()
        comm = Nothing
    End Sub

#End Region

    Public Overrides Function Connection(ByVal commInfo As CCommLib.CComCommonNode.sCommInfo) As Boolean
        m_CommSettings = commInfo.sSerialInfo

        If comm.Communicator.Connect(m_CommSettings) = CComCommonNode.eReturnCode.OK Then

            If SetRemoteMode(eRemoteMode.RemoteON) = False Then Return False

        Else
            m_sErrMsg = "Failed to port open"
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub Disconnection()

        SetRemoteMode(eRemoteMode.RemoteOFF)
        comm.Communicator.Disconnect()
    End Sub

    Public Function SetRemoteMode(ByVal mode As eRemoteMode) As Boolean
        Dim sCmd As String = "COM, " & CInt(mode)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Public Overrides Function Initialization() As Boolean
        If SetDispProbe(m_nProbeID) = False Then Return False
        '   If SetOutputProbe(m_nProbeID) = False Then Return False
        Return True
    End Function

    Public Overrides Function ZeroCalibration() As Boolean
        Dim sCmd As String = "ZRC"
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Public Overrides Function GetDeviceInfo(ByRef infos As CDevCAxxxCMD.sDevInfo) As Boolean
        Dim sCmd As String = "IDO"
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        Dim sDatas() As String = Nothing
        If DataParser(sRcvData, sDatas) = False Then Return False

        If sDatas Is Nothing Then Return False

        'Dim arrBuf As Array

        'arrBuf = Split(sDatas(0), " ", -1)


        infos.sModel = sDatas(0).Substring(0, 16)

        infos.sFirmwareVersion = sDatas(0).Substring(16, sDatas(0).Length - 16)

        infos.nIDNumber = m_nProbeID

        Return True
    End Function

    Public Overrides Function SetSettings(infos As sSetInfos) As Boolean
        Try
            With infos.sCAxxxSettings
                '  .syncMode = objCa.SyncMode
                If .syncMode <> m_settings.syncMode Then
                    If SetSyncMode(.syncMode) = False Then Return False
                End If

                '.avgMode = objCa.AveragingMode
                If .avgMode <> m_settings.avgMode Then
                    If SetAveragingMode(.avgMode) = False Then Return False
                End If

                '.calMode = objCa.CalStandard
                If .calMode <> m_settings.calMode Then
                    If SetCalibrationMode(.calMode) = False Then Return False
                End If

                '.dispMode = objCa.DisplayMode
                If .dispMode <> m_settings.dispMode Then
                    If SetDisplayMode(.dispMode) = False Then Return False
                End If

                ' .brightnessMode = objCa.BrightnessUnit
                If .brightnessMode <> m_settings.brightnessMode Then
                    If SetBrightnessUnit(.brightnessMode) = False Then Return False
                End If

                '.dispDigits = objCa.DisplayDigits
                If .dispDigits <> m_settings.dispDigits Then
                    If SetDispDigit(.dispDigits) = False Then Return False
                End If



                '    If SetOutputProbe(m_nProbeID) = False Then Return False
            End With
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        Return True
    End Function

    Public Overrides Function GetSettings(ByRef infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        Try
            With infos.sCAxxxSettings

                If GetSyncMode(.syncMode) = False Then Return False

                If GetAveragingMode(.avgMode) = False Then Return False
            
                If GetDispDigit(.dispDigits) = False Then Return False

                If GetCalibrationMode(.calMode) = False Then Return False

                If GetDisplayMode(.dispMode) = False Then Return False

                If GetBrightnessUnit(.brightnessMode) = False Then Return False
            End With
         
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        Return True
    End Function


    'Public Overrides Function Measure(ByRef measuredDatas As sDatas) As Boolean

    '    Return True
    'End Function


    'Public Overrides Function Measure(ByRef measuredDatas As CDevColorAnalyzerCommonNode.sDataInfos) As Boolean
    '    Dim sCmd As String = "MES"
    '    Dim sRcvData As String = Nothing

    '    If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        m_sErrMsg = "Communication Error"
    '        Return False
    '    End If

    '    Dim sDatas() As String = Nothing
    '    If DataParser(sRcvData, sDatas) = False Then Return False

    '    If sDatas Is Nothing Then Return False

    '    Dim sData As String = sDatas(0).Substring(3, sDatas(0).Length - 3)


    '    sDatas = Split(sData, ";", -1)

    '    Select Case m_settings.dispMode

    '        Case eDispMode.Lvxy
    '            measuredDatas.Lv = CDbl(sDatas(2))
    '            measuredDatas.sx = CDbl("0." & sDatas(0))
    '            measuredDatas.sy = CDbl("0." & sDatas(1))

    '            Dim sParam As sColorCIEParam = CalculateCIEParam(measuredDatas.sx, measuredDatas.sy)

    '            measuredDatas.u = sParam.CIE1960_u
    '            measuredDatas.v = sParam.CIE1960_v
    '            measuredDatas.ud = sParam.CIE1976_ud
    '            measuredDatas.vd = sParam.CIE1976_vd
    '            measuredDatas.CCT = sParam.CCT
    '            measuredDatas.BBL_x = sParam.BBL_x
    '            measuredDatas.BBL_y = sParam.BBL_y
    '            measuredDatas.BBL_u = sParam.BBL_u
    '            measuredDatas.BBL_v = sParam.BBL_v

    '            measuredDatas.MPCD = sParam.MPCD


    '        Case eDispMode.Tdudv
    '            measuredDatas.T = CDbl(sDatas(0))
    '            measuredDatas.duv = CDbl(sDatas(1))
    '            measuredDatas.Lv = CDbl(sDatas(2))
    '        Case eDispMode.uDot_vDot
    '            measuredDatas.ud = CDbl(sDatas(0))
    '            measuredDatas.vd = CDbl(sDatas(1))
    '            measuredDatas.Lv = CDbl(sDatas(2))

    '        Case eDispMode.FlickerMode

    '        Case eDispMode.XYZ
    '            measuredDatas.X = CDbl(sDatas(0))
    '            measuredDatas.Y = CDbl(sDatas(1))
    '            measuredDatas.Z = CDbl(sDatas(2))

    '        Case eDispMode.AnalyzerMode_G_Standard
    '            'R value, B value, G value
    '            measuredDatas.Rvalue = CDbl(sDatas(0))
    '            measuredDatas.Bvalue = CDbl(sDatas(1))
    '            measuredDatas.Gvalue = CDbl(sDatas(2))
    '        Case eDispMode.AnalyzerMode_NoAnalog
    '            'R value, B value, G value
    '            measuredDatas.Rvalue = CDbl(sDatas(0))
    '            measuredDatas.Bvalue = CDbl(sDatas(1))
    '            measuredDatas.Gvalue = CDbl(sDatas(2))
    '        Case eDispMode.AnalyzerMode_R_Standard
    '            'R value, B value, G value
    '            measuredDatas.Rvalue = CDbl(sDatas(0))
    '            measuredDatas.Bvalue = CDbl(sDatas(1))
    '            measuredDatas.Gvalue = CDbl(sDatas(2))
    '    End Select

    '    Return True
    ' End Function



    Public Overrides Function Measure(ByRef measuredDatas As CDevColorAnalyzerCommonNode.sDataInfos) As Boolean


        Dim sCmd As String = "MES"
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        Dim sDatas() As String = Nothing
        If DataParser(sRcvData, sDatas) = False Then Return False

        If sDatas Is Nothing Then Return False

        Dim sData As String = sDatas(0).Substring(3, sDatas(0).Length - 3)


        sDatas = Split(sData, ";", -1)

        Select Case m_settings.dispMode

            Case eDispMode.Lvxy
                measuredDatas.Data.dY = CDbl(sDatas(2))
                measuredDatas.Data.dCIEx = CDbl("0." & sDatas(0))
                measuredDatas.Data.dCIEy = CDbl("0." & sDatas(1))

                Dim sParam As sColorCIEParam = CalculateCIEParam(measuredDatas.Data.dCIEx, measuredDatas.Data.dCIEy)

                measuredDatas.Data.dCIE1960u = sParam.CIE1960_u
                measuredDatas.Data.dCIE1960v = sParam.CIE1960_v
                measuredDatas.Data.dCIE1976u = sParam.CIE1976_ud
                measuredDatas.Data.dCIE1976v = sParam.CIE1976_vd
                measuredDatas.Data.CCT = sParam.CCT
                measuredDatas.Data.BBL_x = sParam.BBL_x
                measuredDatas.Data.BBL_y = sParam.BBL_y
                measuredDatas.Data.BBL_u = sParam.BBL_u
                measuredDatas.Data.BBL_v = sParam.BBL_v

                measuredDatas.Data.MPCD = sParam.MPCD


            Case eDispMode.Tdudv
                measuredDatas.Data.CCT = CDbl(sDatas(0))
                measuredDatas.Data.duv = CDbl(sDatas(1))
                measuredDatas.Data.dY = CDbl(sDatas(2))
            Case eDispMode.uDot_vDot
                measuredDatas.Data.dCIE1976u = CDbl(sDatas(0))
                measuredDatas.Data.dCIE1976v = CDbl(sDatas(1))
                measuredDatas.Data.dY = CDbl(sDatas(2))

            Case eDispMode.FlickerMode

            Case eDispMode.XYZ
                measuredDatas.Data.dX = CDbl(sDatas(0))
                measuredDatas.Data.dY = CDbl(sDatas(1))
                measuredDatas.Data.dZ = CDbl(sDatas(2))

            Case eDispMode.AnalyzerMode_G_Standard
                'R value, B value, G value
                measuredDatas.Data.Rvalue = CDbl(sDatas(0))
                measuredDatas.Data.Bvalue = CDbl(sDatas(1))
                measuredDatas.Data.Gvalue = CDbl(sDatas(2))
            Case eDispMode.AnalyzerMode_NoAnalog
                'R value, B value, G value
                measuredDatas.Data.Rvalue = CDbl(sDatas(0))
                measuredDatas.Data.Bvalue = CDbl(sDatas(1))
                measuredDatas.Data.Gvalue = CDbl(sDatas(2))
            Case eDispMode.AnalyzerMode_R_Standard
                'R value, B value, G value
                measuredDatas.Data.Rvalue = CDbl(sDatas(0))
                measuredDatas.Data.Bvalue = CDbl(sDatas(1))
                measuredDatas.Data.Gvalue = CDbl(sDatas(2))
        End Select

        Return True
     
    End Function



    '==============================================================================================================

    Public Function SetDisplayMode(ByVal mode As eDispMode) As Boolean
        Dim sCmd As String = "MDS, " & CInt(mode)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        m_settings.dispMode = mode

        Return True
    End Function

    Public Function GetDisplayMode(ByRef mode As eDispMode) As Boolean
        Dim sCmd As String = "STR, 0"
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        mode = CInt(sData(0))

        m_settings.dispMode = mode

        Return True
    End Function

    Public Function SetSyncMode(ByVal mode As eSyncMode, Optional ByVal dFreq As Double = 0) As Boolean
        Dim sCmd As String
        Dim sRcvData As String = Nothing

        If mode = eSyncMode.Frequency Then
            If dFreq < 40.5 Or dFreq > 200 Then
                m_sErrMsg = "Out of range, 40hz ~ 200 hz"
                Return False
            End If
            sCmd = "SCS, " & Format(dFreq, "0.0")
        Else
            sCmd = "SCS, " & CInt(mode)
        End If

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        If mode = eSyncMode.Frequency Then
            m_settings.syncMode = CSng(dFreq)
        Else
            m_settings.syncMode = mode
        End If


        Return True
    End Function

    Public Function GetSyncMode(ByRef mode As Single) As Boolean
        Dim sCmd As String = "STR, 1"
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        mode = CInt(sData(0))

        If mode = eSyncMode.Frequency Then  ' INT Mode Same mean
            If GetFrequency(mode) = False Then

                Return False
            End If
        End If

        m_settings.syncMode = mode
        Return True
    End Function

    Private Function GetFrequency(ByVal mode As Single) As Boolean
        Dim sCmd As String = "STR, 2" 'INT Mode Frequency
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False
        If sData Is Nothing Then Return False

        mode = CSng(sData(0))
        Return True
    End Function

    Public Function SetMemoryChannel(ByVal ch As Integer) As Boolean
        Dim sCmd As String = "MCH, " & CStr(ch)
        Dim sRcvData As String = Nothing

        If ch < 0 Or ch > 99 Then
            m_sErrMsg = "Out of range, 0 ~ 99"
            Return False
        End If

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Public Function GetMemoryChannel(ByVal ch As Integer) As Boolean
        Dim sCmd As String = "STR, 3" 'Current memory channel number
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        ch = CInt(sData(0))
        Return True
    End Function

    Public Function SetIDName(ByVal memChannel As Integer, ByVal sNames As String) As Boolean

        If sNames.Length > 10 Then
            m_sErrMsg = "Length of ID Name up to 10 characters"
            Return False
        End If

        If memChannel < 0 Or memChannel > 99 Then
            m_sErrMsg = "Out of range"
            Return False
        End If

        Dim sCmd As String = "IDS, " & CStr(memChannel) & ", " & sNames
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Private Function GetIDName(ByVal sName As String) As Boolean
        Dim sCmd As String = "STR, 4" 'ID Name for currently selected memory channel
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        sName = sData(0)

        Return True
    End Function

    ''' <summary>
    ''' Sets the initial status settings(the settings used when the instrument is switched on) to the currently used settings for the following items
    ''' 1. Measurement mode
    ''' 2. Measurement Synchronization mode
    ''' 3. Display probe number
    ''' 4. Memory channel
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetInitialStatus() As Boolean

        Dim sCmd As String = "INI"
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Public Function SetAnalogDispRange(ByVal range1 As String, ByVal range2 As String) As Boolean

        Dim sCmd As String = "ARS, "

        If m_settings.dispMode = CDevCAxxxCMD.eDispMode.FlickerMode Then
            sCmd = sCmd & range1 & ", " & range1
        ElseIf m_settings.dispMode = CDevCAxxxCMD.eDispMode.Tdudv Or _
                 m_settings.dispMode = CDevCAxxxCMD.eDispMode.XYZ Or _
                 m_settings.dispMode = CDevCAxxxCMD.eDispMode.uDot_vDot Then

            sCmd = sCmd & range1 & ", " & range2
        End If

        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Private Function GetAnalogDispRange(ByRef range1 As String, ByRef range2 As String) As Boolean
        Dim sCmd As String = "STR, 5" 'Analog Display rnage
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        range1 = sData(0)
        range2 = sData(1)
        Return True
    End Function

    Public Function SetBrightnessUnit(ByVal unit As eBrightnessUnit) As Boolean

        Dim sCmd As String = "LUS, " & CStr(unit)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        m_settings.brightnessMode = unit
        Return True
    End Function

    Private Function GetBrightnessUnit(ByRef unit As eBrightnessUnit) As Boolean
        Dim sCmd As String = "STR, 6" 'Luminance unit settings
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        unit = CInt(sData(0))
        m_settings.brightnessMode = unit
        Return True
    End Function

    Public Function SetAveragingMode(ByVal avgMode As eAveragingMode) As Boolean
        Dim sCmd As String = "FSC, " & CStr(avgMode)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        m_settings.avgMode = avgMode

        Return True
    End Function

    Private Function GetAveragingMode(ByRef avgMode As eAveragingMode) As Boolean
        Dim sCmd As String = "STR, 7" 'Averaging(FAST/SLOW) Mode Settings
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        avgMode = CInt(sData(0))

        m_settings.avgMode = avgMode
        Return True
    End Function

    Public Function SetDispDigit(ByVal dispDigit As eDispDigit) As Boolean
        Dim sCmd As String = "SNF, " & CStr(dispDigit)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        m_settings.dispDigits = dispDigit

        Return True
    End Function

    Private Function GetDispDigit(ByRef dispDigit As eDispDigit) As Boolean
        Dim sCmd As String = "STR, 8" 'number of display digits
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        dispDigit = CInt(sData(0))

        m_settings.dispDigits = dispDigit
        Return True
    End Function

    Public Function SetCalibrationMode(ByVal calMode As eCalibrationMode) As Boolean

        Dim sCmd As String = "MSS, " & CStr(calMode)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        m_settings.calMode = calMode
        Return True
    End Function

    Private Function GetCalibrationMode(ByRef calMode As eCalibrationMode) As Boolean
        Dim sCmd As String = "STR, 9" 'number of display digits
        Dim sRcvData As String = Nothing
        Dim sData() As String = Nothing
        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData, sData) = False Then Return False

        If sData Is Nothing Then Return False

        calMode = CInt(sData(0))
        m_settings.calMode = calMode
        Return True
    End Function

    Public Function SetDispProbe(ByVal probeNo As Integer) As Boolean
        Dim sCmd As String = "DPR, " & CStr(probeNo)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function

    Public Function SetOutputProbe(ByVal sProbeNos As Integer) As Boolean
        Dim sCmd As String = "OPR, " & CStr(sProbeNos)
        Dim sRcvData As String = Nothing

        If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            m_sErrMsg = "Communication Error"
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        Return True
    End Function


    Private Function DataParser(ByVal sRcvData As String, Optional ByRef paseredDatas() As String = Nothing) As Boolean

        If sRcvData Is Nothing Then
            m_sErrMsg = "nothing received data"
            Return False
        End If

        If sRcvData.Length <= 0 Then
            m_sErrMsg = "nothing received data"
            Return False
        End If


        sRcvData = sRcvData.TrimEnd(vbCr)

        Dim errorCode As String = Nothing
        Dim data As String
        Dim arrTemp As Array

        arrTemp = Split(sRcvData, ",", -1)

        If arrTemp.Length = 0 Then
            m_sErrMsg = "nothing received data, parsing data length is 0"
            Return False
        ElseIf arrTemp.Length = 1 Then
            errorCode = arrTemp(0)
        ElseIf arrTemp.Length > 1 Then
            errorCode = arrTemp(0)
            data = arrTemp(1)
            paseredDatas = Split(data, ",", -1)
        End If

        Dim errChkCode As eErrorChkCode = ErrorCheck(errorCode)
        errorCode = errorCode.Substring(0, 2)

        If errorCode <> "OK" Then Return False

        Return True
    End Function

    Private Function ErrorCheck(ByVal sErrChkCode As String) As eErrorChkCode

        Select Case sErrChkCode

            Case eErrorChkCode.OK00.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK00)
                Return eErrorChkCode.OK00
            Case eErrorChkCode.OK01.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK01)
                Return eErrorChkCode.OK01
            Case eErrorChkCode.OK02.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK02)
                Return eErrorChkCode.OK02
            Case eErrorChkCode.OK03.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK03)
                Return eErrorChkCode.OK03
            Case eErrorChkCode.OK04.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK04)
                Return eErrorChkCode.OK04
            Case eErrorChkCode.OK05.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK05)
                Return eErrorChkCode.OK05
            Case eErrorChkCode.OK06.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK06)
                Return eErrorChkCode.OK06
            Case eErrorChkCode.OK07.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.OK07)
                Return eErrorChkCode.OK07
            Case eErrorChkCode.ER10.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER10)
                Return eErrorChkCode.ER10
            Case eErrorChkCode.ER15.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER15)
                Return eErrorChkCode.ER15
            Case eErrorChkCode.ER20.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER20)
                Return eErrorChkCode.ER20
            Case eErrorChkCode.ER22.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER22)
                Return eErrorChkCode.ER22
            Case eErrorChkCode.ER23.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER23)
                Return eErrorChkCode.ER23
            Case eErrorChkCode.ER24.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER24)
                Return eErrorChkCode.ER24
            Case eErrorChkCode.ER50.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER50)
                Return eErrorChkCode.ER50
            Case eErrorChkCode.ER51.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER51)
                Return eErrorChkCode.ER51
            Case eErrorChkCode.ER52.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER52)
                Return eErrorChkCode.ER52
            Case eErrorChkCode.ER53.ToString
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER53)
                Return eErrorChkCode.ER53
            Case Else
                m_sErrMsg = m_sDefErrMsg(eErrorChkCode.ER_undef)
                Return eErrorChkCode.ER_undef
        End Select
    End Function



    'Public Function ReadCalibrationData(ByRef calDatas()() As Byte) As Boolean
    '    Dim sCmd As String = "CDR, " & CStr(0)
    '    Dim sRcvData As String = Nothing

    '    If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        m_sErrMsg = "Communication Error"
    '        Return False
    '    End If

    '    If DataParser(sRcvData) = False Then Return False

    '    'For nCh As Integer = 0 To 99

    '    'Next


    '    Return True
    'End Function

    'Public Function Measurement() As Boolean
    '    Dim sCmd As String = "MES"
    '    Dim sRcvData As String = Nothing

    '    If comm.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        m_sErrMsg = "Communication Error"
    '        Return False
    '    End If

    '    If DataParser(sRcvData) = False Then Return False

    '    Return True
    'End Function

  

End Class
