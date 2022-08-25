
Imports System.Threading
Imports System
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevPR730
    Inherits CDevSpectrometerCommonNode

    Dim communicator As CComAPI
    '   Dim m_bIsConnected As Boolean = False
    Dim dDelay As Integer

    ' Public WithEvents g_StateMsgHandl As New CStateMsg



#Region "Enums"

    Public Enum eCommands
        eSetsLCDBacklightLevel
        eClearCurrentSessionInstrumentErrors
        eDownloadsDataFromThePR730
        eTogglesTheEchoMode
        eMeasureFrequencyOfLightSource
        eRequestsInstrumentStatusOrErrorReport
        eDefinesMeasurementTitle
        eMeasureCommand
        eInititalizeDataLoggerMode
        eExitRemote
        eRecallStoredMeasurement
        eSetupMeasurmentParameters
        eSetLCDContrastLevel
    End Enum

    Public Enum eMeasMode
        eCIE1931_Yxy = 1  '1
        eXYZ
        eCIE1976_Yuv
        eYCd
        eSpectrumData
        eCIE1931CIE1976_Yxyuv
    End Enum

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eGain
        eNormal
        e1XFast
        e2XFast
        e4XFast
    End Enum

    Public Enum ePhotometric
        eEnglish
        eMetric
    End Enum


#End Region



    '    Public Structure tDataCommon
    '        Dim strDivider() As String
    '        Dim i0MeasQCode As Integer
    '        Dim striOMeasQCode As String
    '        Dim i1UnitValue0Value1Uncal2 As Integer 'Unit: Luminance0/illuminance1/Uncal2 or SpectralRadiance0/Spectralirradiance1
    '    End Structure


    '    Public Structure tData01
    '        Dim Comn As tDataCommon
    '        Dim s2YY As Single
    '        Dim s3xx As Single
    '        Dim s4yy As Single
    '    End Structure

    '    Public Structure tData02
    '        Dim Comn As tDataCommon
    '        Dim s2XX As Single
    '        Dim s3YY As Single
    '        Dim s4ZZ As Single
    '    End Structure

    '    Public Structure tData03
    '        Dim Comn As tDataCommon
    '        Dim s2YY As Single
    '        Dim s3uu As Single
    '        Dim s4vv As Single
    '    End Structure

    '    Public Structure tData04
    '        Dim Comn As tDataCommon
    '        Dim s2YY As Single
    '        Dim s3KelvinT As Single
    '        Dim s4DevOfColorCoord As Single
    '    End Structure

    '    Public Structure tData05
    '        Dim Comn As tDataCommon
    '        Dim s2IntegIntensity As Single
    '        Dim i3nm() As Integer
    '        Dim s4Intensity() As Single
    '        Dim iMax As Integer
    '    End Structure

    '    Public Structure tData06
    '        Dim Comn As tDataCommon
    '        Dim s2YY As Single
    '        Dim s3xx As Single
    '        Dim s4yy As Single
    '        Dim s5uu As Single
    '        Dim s6vv As Single
    '    End Structure

    '    Public Structure tGetTime
    '        Dim sMeasTime As Single
    '        Dim sDataGetTime As Single
    '    End Structure


    '    Public Structure tData
    '        Dim D1 As tData01
    '        Dim D2 As tData02
    '        Dim D3 As tData03
    '        Dim D4 As tData04
    '        Dim D5 As tData05
    '        Dim D6 As tData06
    '        Dim GetTime As tGetTime

    '        '    InCom As tInComming
    '    End Structure



    '    Public Property ExposureTime() As Integer
    '        '12 ~ 300,000 ms
    '        Get
    '            Return m_ExposureTime
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_ExposureTime = value
    '        End Set
    '    End Property
    '    Public Property Gain() As eGain
    '        '0 1 2 3 
    '        Get
    '            Return m_Gain
    '        End Get
    '        Set(ByVal value As eGain)
    '            m_Gain = value
    '        End Set
    '    End Property




#Region "Define Global Variable"

    'LG 기술원 Accessory : (650) SL-1X , MS-75  /  (705) MS-55 , MS-1X 둘중 하나 선택 , (1도 , 1/8도 선택)


    Dim sCommands() As String = New String() {"B", "C", "D", "E", "F", "I", "L", "M", "O", "Q", "R", "S", "X"}

    Private sMeasSpeedName() As String = New String() {"Nomal", "Fast", "2X Fast", "4X Fast"}

    Private Const Meas_Cmd_Recv_Check_Repeat_Interval_ms = 100
    Private Const Meas_Cmd_Recv_Check_Interval_s = 5

    Private Const Incomming_Buffer_Size_Set = 30
    Private Const Incomming_Long_Buffer_Size_Set = 80

    Private Const Recv_End_Char_Wavelength_Waiting_Num = 121 '없어도 될 듯...


    'Private Const Serial_Comm_Speed_Set = "9600"
    ' Private Const Serial_Comm_Parity = "n"
    ' Private Const Serial_Comm_Data_Bits = "8"
    '  Private Const Serial_Comm_Stop_Bits = "1"

    'Private Const PR730_Cmd_First_Set_Command = "S01,,,,,,,1"   '기본 Set  - See Manual
    ' Private Const PR730_Cmd_First_Set_Command_SL1X = "S01,03,,,,,,1"        ' SL-1X  '[NDC !!]
    ' Private Const PR730_Cmd_First_Set_Command_ND2 = "S01,02,,,,,,1"         ' ND2    '[NDC !!]
    '  Private Const PR730_Cmd_First_Set_Command_SL1X_ND2 = "S01,03,02,,,,,1"  ' SL-1X & ND2  '[NDC !!]
    'Private Const WAVE_MAX_DIM = 400

    Private m_Data As tData

    Private g_eRS232Status As eTransferState

    Private m_fLongIncomingBufferFinish As Boolean
    Private m_strLongIncomingBuffer As String


    Public Event evDetectedError(ByVal nCode As Integer, ByVal strMsg As String)
    Public Event evDataTransfered(ByVal str As String, ByVal stat As eTransferState)


    'PR730 명령어
    Const CMD_ApertureList As String = "117" 'aperture list
    Const CMD_Remote As String = "PHOTO" 'remode
    Const CMD_Exposure As String = "SE" 'exposure time
    Const CMD_Gain As String = "SG" 'gain
    Const CMD_Lens As String = "SP" 'Lens Select
    Const CMD_DarkCurrMode As String = "SD" 'Dark Curr mode
    Const CMD_Sensitivity As String = "SH" 'sensitivity mode
    Const CMD_Sync As String = "SS" 'Sync mode
    Const CMD_Frequency As String = "SK" 'set Frequency
    Const CMD_CIEObserver As String = "SO" 'set CIE Observer
    Const CMD_Average As String = "SN" 'set Average
    Const CMD_AportureSelect As String = "SF" 'aperture Select
    Const CMD_Vers As String = "114" 'version
    Const CMD_AccessoryList As String = "116"
    Const CMD_PhotometricUnits As String = "SU"


    Private m_ExposureTime As Integer
    Private m_Gain As eGain

#End Region

#Region "Structures"

    'Public Structure DeviceOption
    '    Dim AperatureList() As sAperature
    '    Dim MeasSpeed() As sMeasSpeed
    '    Dim ALensList() As sLens
    'End Structure

    'Public Structure sAperature
    '    Dim nIndex As Integer
    '    Dim dAngle As Double
    'End Structure

    'Public Structure sMeasSpeed
    '    Dim nIndex As Integer
    '    Dim sSpeed As String
    'End Structure

    'Public Structure sLens
    '    Dim nIndex As Integer
    '    Dim sLensName As String
    'End Structure

#End Region


#Region "Creator, Disposer, Init"

    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_PR730
        dDelay = 100
        g_eRS232Status = eTransferState.eReady
        m_ExposureTime = 50
        m_Gain = eGain.eNormal
    End Sub

#End Region

    Private Sub aInitialize()

        'Set Dividers
        ReDim m_Data.D1.Comn.strDivider(1)
        m_Data.D1.Comn.strDivider(0) = ","
        m_Data.D1.Comn.strDivider(1) = vbCr + vbLf

        ReDim m_Data.D2.Comn.strDivider(1)
        m_Data.D2.Comn.strDivider(0) = ","
        m_Data.D2.Comn.strDivider(1) = vbCr + vbLf

        ReDim m_Data.D3.Comn.strDivider(1)
        m_Data.D3.Comn.strDivider(0) = ","
        m_Data.D3.Comn.strDivider(1) = vbCr + vbLf

        ReDim m_Data.D4.Comn.strDivider(1)
        m_Data.D4.Comn.strDivider(0) = ","
        m_Data.D4.Comn.strDivider(1) = vbCr + vbLf

        ReDim m_Data.D5.Comn.strDivider(2)
        m_Data.D5.Comn.strDivider(0) = ","
        m_Data.D5.Comn.strDivider(1) = vbCr
        m_Data.D5.Comn.strDivider(2) = vbCr + vbLf

        ReDim m_Data.D6.Comn.strDivider(1)
        m_Data.D6.Comn.strDivider(0) = ","
        m_Data.D6.Comn.strDivider(1) = vbCr + vbLf

    End Sub

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)

        m_ConfigInfo.sSerialInfo.nHandShake = IO.Ports.Handshake.RequestToSend

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else
            Dim VerStr As String = Nothing
            If SetRemoteMode() = False Then Return False
            If GetDeviceVer(VerStr) = False Then Return False
            If SetExposureTime(m_ExposureTime) = False Then Return False 'exposure set
            If SetGain(m_Gain) = False Then Return False 'gain set


            If GetDeviceInfos(sInfos) = False Then
                Return False
            Else
                MyBase.m_DeviceInfos = sInfos
            End If

        End If
        m_bIsConnected = True
        Return True
    End Function

    'Public Overrides Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean  ' CCommunicator.sCommInfo
    '    '  Config.sSendTerminator = vbCr
    '    ' Config.nHandShake = IO.Ports.Handshake.RequestToSend
    '    ' communicator.Communicator.TimeOut = 30  'Time out sec

    '    m_bIsConnected = False
    '    m_ConfigInfo = Config
    '    communicator = New CComAPI(CCommunicator.eCommType.eSerial)

    '    If communicator.Communicator.Connect(m_ConfigInfo) = False Then
    '        Return False
    '    Else
    '        Dim VerStr As String = Nothing
    '        If SetRemoteMode() = False Then Return False
    '        If GetDeviceVer(VerStr) = False Then Return False

    '    End If



    '    m_bIsConnected = True
    '    Return True
    'End Function

    Public Overrides Sub Disconnection()
        '   If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        ' End If
        m_bIsConnected = False
    End Sub


#Region "API Functions"
    'Public Overrides Function StartAperatureChange() As Boolean
    'If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperature.e1, 0, 0, 0) = False Then Return False

    'Application.DoEvents()
    'Thread.Sleep(5000)
    '    Return True
    '   End Function

    '    Public Overrides Function EndAperatureChange() As Boolean
    'If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperature.e0R125, 0, 0, 0) = False Then Return False

    'Application.DoEvents()
    'Thread.Sleep(5000)
    '      Return True
    '   End Function

    Public Overrides Function RemoteMode() As Boolean
        If SetRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function LocalMode() As Boolean
        If QuitRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function SetAperture(ByVal nAperatureIndex As Integer) As Boolean
        If SetPR730Aperture(nAperatureIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetLens(ByVal nLensIndex As Integer) As Boolean
        If SetPR730Lens(nLensIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer) As Boolean
        If SetGain(nMeasSpeedIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As DeviceOption) As Boolean
        With sInfos
            If SetPR730Aperture(.ApertureList(.ApertureIndex).nApertureCodeIndex) = False Then Return False
            If SetPR730Lens(.LensList(.LensIndex).nLensCodeIndex) = False Then Return False
            If SetGain(.MeasSpeedList(.MeasSpeedIndex).nMeasSpeedCodeIndex) = False Then Return False
        End With
   
        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As DeviceOption) As Boolean
        Dim sAperatureList() As sAperture = Nothing
        Dim sLensList() As sLens = Nothing

        If GetApertures(sAperatureList) = False Then Return False
        If GetAccessory(sLensList) = False Then Return False

        ReDim sInfos.ApertureList(sAperatureList.Length - 1)
        ReDim sInfos.LensList(sLensList.Length - 1)
        ReDim sInfos.MeasSpeedList(sMeasSpeedName.Length - 1)


        For i As Integer = 0 To sMeasSpeedName.Length - 1
            sInfos.MeasSpeedList(i).nMeasSpeedCodeIndex = i
            sInfos.MeasSpeedList(i).sSpeedName = sMeasSpeedName(i)
        Next

        For i As Integer = 0 To sAperatureList.Length - 1
            sInfos.ApertureList(i).nApertureCodeIndex = sAperatureList(i).nApertureCodeIndex
            sInfos.ApertureList(i).sApertureName = sAperatureList(i).sApertureName
        Next

        For i As Integer = 0 To sLensList.Length - 1
            sInfos.LensList(i).nLensCodeIndex = sLensList(i).nLensCodeIndex
            sInfos.LensList(i).sLensName = sLensList(i).sLensName
        Next
        '   DeviceInfos = sInfos

        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As tData) As Boolean
        If Meas(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then
            If Meas(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As tData) As Boolean
        Dim nCnt As Integer
        Dim bReMeas As Boolean = False

        For nCnt = 0 To 10
            If ReadData(eMeasMode.eXYZ, outData) = True And ReadData(eMeasMode.eSpectrumData, outData) = True Then
                Exit For
            Else
                If Measure(outData) = False Then
                    If Measure(outData) = False Then Return False
                End If
            End If

            If nCnt >= 10 Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True

    End Function

    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function
#End Region

#Region "Control Functions"


    Public Function SetRemoteMode() As Boolean
        'Remode Command ?
        Dim sCommand As String
        Dim sRcvData As String = ""

        sCommand = "PHOTO"
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        'Dim backup As CComSerial.sSerialPortInfo = communicator.Communicator.Configure
        'Dim backup1 As CComSerial.sSerialPortInfo = communicator.Communicator.Configure

        'backup1.sCMDTerminator = ""
        'communicator.Communicator.Configure = backup1

        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If
        'communicator.Communicator.Configure = backup
        ' aInitialize()
        Return True

    End Function

    Public Function QuitRemoteMode() As Boolean
        'Quit Remode
        Dim sCommand As String

        sCommand = sCommands(eCommands.eExitRemote)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        'If SendCommand(sCommand) = False Then
        '    Return False
        'End If
        Return True
    End Function

    Public Function GetDeviceVer(ByRef OutData As String) As Boolean
        'Get Ver
        Dim sCommand As String = "D114"
        Dim sRcvData As String = Nothing
        OutData = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If
        OutData = sRcvData
        Return True

    End Function

    Public Function GetAccessory(ByRef sAccessory() As sLens) As Boolean
        Dim sCmd As String = "D116"
        Dim sRcvData As String = Nothing
        Dim arrLineBuf As Array = Nothing
        Dim arrCommaBuf As Array = Nothing
        Dim nCnt As Integer

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        arrLineBuf = Split(sRcvData, vbCrLf, -1)

        ReDim sAccessory(arrLineBuf.Length - 2)

        For nCnt = 0 To arrLineBuf.Length - 2
            arrCommaBuf = Split(arrLineBuf(nCnt), ",", -1)
            sAccessory(nCnt).nLensCodeIndex = arrCommaBuf(1)
            sAccessory(nCnt).sLensName = arrCommaBuf(2)
        Next

        Return True
    End Function

    Public Function GetApertures(ByRef sApertures() As sAperture) As Boolean
        Dim sCmd As String = "D117"
        Dim sRcvData As String = Nothing
        Dim arrLineBuf As Array = Nothing
        Dim arrCommaBuf As Array = Nothing
        Dim nCnt As Integer

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        arrLineBuf = Split(sRcvData, vbCrLf, -1)

        ReDim sApertures(arrLineBuf.Length - 2)

        For nCnt = 0 To arrLineBuf.Length - 2
            arrCommaBuf = Split(arrLineBuf(nCnt), ",", -1)
            sApertures(nCnt).nApertureCodeIndex = arrCommaBuf(1)
            sApertures(nCnt).sApertureName = arrCommaBuf(2)
        Next

        Return True
    End Function

    Public Function SetExposureTime(ByVal inTime As Integer) As Boolean
        'set exposure time
        Dim sCommand As String
        '    Dim sRcvData As String = Nothing

        sCommand = CMD_Exposure & CStr(inTime)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function SetGain(ByVal inGain As eGain) As Boolean
        'set Gain
        Dim sCommand As String
        '    Dim sRcvData As String = Nothing

        sCommand = CMD_Gain & CStr(inGain)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function SetPR730Lens(ByVal nLensCode As Integer) As Boolean
        '렌즈 선택 기본값 은 1?
        Dim sCommand As String
        ' Dim sRcvData As String = Nothing

        sCommand = CMD_Lens & CStr(nLensCode)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvData) = False Then

        '    Return False
        'End If

        Return True

    End Function

    Public Function SetPR730Aperture(ByVal nApertureCode As Integer) As Boolean
        '렌즈 선택 기본값 은 1?
        Dim sCommand As String
        ' Dim sRcvData As String = Nothing

        sCommand = CMD_AportureSelect & CStr(nApertureCode)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvData) = False Then

        '    Return False
        'End If

        Return True

    End Function


    Public Function SetPhotometricUnits(ByVal PhotometriUnitType As ePhotometric) As Boolean
        'SetPhotometricUnits
        Dim sCommand As String
        '    Dim sRcvData As String = Nothing

        sCommand = CMD_PhotometricUnits & CStr(PhotometriUnitType)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function Meas(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing


        sCommand = sCommands(eCommands.eMeasureCommand) & CStr(nMode)
        Dim tDalyTime As Integer = m_ExposureTime * 2

        communicator.Communicator.TimeOut = tDalyTime

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else
            If DataParser(sRcvData, nMode) = False Then
                ErrorSave("Meas SendCommand = " & sCommand & vbCrLf & "Meas RcvCommand = " & sRcvData)
                Return False
            Else
                outData = m_Data
            End If
        End If

        '   rst = SendCommand(sCommand, sRcvData)

        'If rst = False Then
        '    Return False
        'Else
        '    If DataParser(sRcvData, nMode) = False Then
        '        ErrorSave("Meas SendCommand = " & sCommand & vbCrLf & "Meas RcvCommand = " & sRcvData)
        '        Return False
        '    Else
        '        outData = m_Data
        '    End If

        'End If

        Return True

    End Function

    Private Sub ErrorSave(ByVal sMsg As String)
        'Dim strData As String
        'Dim cDat As String = Format(Now, "yyyy.MM.dd")
        'Dim cTime As String = Format(Now, "HH:mm:ss")
        '    Dim sFilepath As String = g_sPATH_SYSTEM_LOG & "PR_Log"


        'FileOpen(10, sFilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)

        'strData = cDat & "/" & cTime & vbTab & sMsg
        'PrintLine(10, strData)

        'FileClose(10)

    End Sub

    Public Function ReadData(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean

        Dim sCommand As String
        Dim sRcvData As String = Nothing
        '  Dim rst As Boolean

        sCommand = sCommands(eCommands.eDownloadsDataFromThePR730) & CStr(nMode)
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False

        Else
            If DataParser(sRcvData, nMode) = False Then
                ErrorSave("Read SendCommand = " & sCommand & vbCrLf & "Read RcvCommand = " & sRcvData)
                Return False
            Else
                outData = m_Data
            End If
        End If
        Return True

    End Function


    Private Function ErrorStatus(ByVal nMode As eMeasMode, ByRef Out_strStatus As String) As Integer

        Dim iMeasQCode As Integer

        Select Case nMode '2/6/4 만 사용..
            Case 1
                iMeasQCode = m_Data.D1.Comn.i0MeasQCode
            Case 2
                iMeasQCode = m_Data.D2.Comn.i0MeasQCode
            Case 3
                iMeasQCode = m_Data.D3.Comn.i0MeasQCode
            Case 4
                iMeasQCode = m_Data.D4.Comn.i0MeasQCode
            Case 5
                iMeasQCode = m_Data.D5.Comn.i0MeasQCode
            Case 6
                iMeasQCode = m_Data.D6.Comn.i0MeasQCode
        End Select

        Select Case iMeasQCode
            Case 0
                Out_strStatus = "" 'OK
            Case eTransferState.eReciveFail_TimeOut
                Out_strStatus = "Communication Lost"
            Case -1
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Light source not constant."
                MsgBox(Out_strStatus)
            Case -2
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Light overload – signal too intense."
                MsgBox(Out_strStatus)
            Case -3
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Cannot Sync to light source. Light source frequency below 20Hz, above 400 Hz or signal too low to Sync."
                MsgBox(Out_strStatus)
            Case -4
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Adaptive mode error."
                MsgBox(Out_strStatus)
            Case -8
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Weak light – insufficient signal."
                'MsgBox(Out_strStatus)
            Case -9
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Sync Error."
                MsgBox(Out_strStatus)
            Case -10
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Cannot Auto Sync to light source."
                MsgBox(Out_strStatus)
            Case -12
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Adaptive mode time out. Light source not constant."
                MsgBox(Out_strStatus)
            Case -1000
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Illegal command"
                MsgBox(Out_strStatus)
            Case -1001
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Too many fields in setup command"
                MsgBox(Out_strStatus)
            Case -1002
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid primary accessory code."
                MsgBox(Out_strStatus)
            Case -1003
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Addon 1 accessory code."
                MsgBox(Out_strStatus)
            Case -1004
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Addon 2 accessory code"
                MsgBox(Out_strStatus)
            Case -1005
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Accessory is not a primary accessory."
                MsgBox(Out_strStatus)
            Case -1006
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Accessory is not an Addon accessory"
                MsgBox(Out_strStatus)
            Case -1007
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Accessory already selected."
                MsgBox(Out_strStatus)
            Case -1008
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Aperture index (PR-730/735 only)"
                MsgBox(Out_strStatus)
            Case -1009
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid units code" '0= English , 1=Metric
                MsgBox(Out_strStatus)
            Case -1010
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Exposure value." '6 to 30000 ms
                MsgBox(Out_strStatus)
            Case -1011
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Gain code." '0 = Normal ,1= 1 for AC source , 2=10X ,3=100X
                MsgBox(Out_strStatus)
            Case -1012
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid average cycles." '1 to 99
                MsgBox(Out_strStatus)
            Case -1013
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Calc Mode."
                MsgBox(Out_strStatus)
            Case -1014
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Trigger Mode."
                MsgBox(Out_strStatus)
            Case -1015
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid CIE observer" '2 or 10
                MsgBox(Out_strStatus)
            Case -1017
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Dark measurement mode." ' 0 =Disable Smart Dark , 1= Enable Smart Dark
                MsgBox(Out_strStatus)
            Case -1019
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Sync mode" '0 = No Sync , 1=Auto Sync , 3= User Frequency
                MsgBox(Out_strStatus)
            Case -1021
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Measurement title too long" ' > 20 characters
                MsgBox(Out_strStatus)
            Case -1022
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Measurement title field empty after sending L command"
                MsgBox(Out_strStatus)
            Case -1023
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid user Sync period" '20 to 400 Hz
                MsgBox(Out_strStatus)
            Case -1024
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid R command"
                MsgBox(Out_strStatus)
            Case -1025
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Addon 3 accessory code"
                MsgBox(Out_strStatus)
            Case -1026
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid sensitivity mode" ' 0 = Standard Mde , 1=Extended Mode
                MsgBox(Out_strStatus)
            Case -1035
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Parameter not applicable to this instrument"
                MsgBox(Out_strStatus)
            Case -2000
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /This error code is returned whenever a response code is requested that does not exist, or when no other D command has been sent previously."
                MsgBox(Out_strStatus)

        End Select


        Select Case nMode '2/6/4 만 사용..
            Case 1
                m_Data.D1.Comn.striOMeasQCode = Out_strStatus
            Case 2
                m_Data.D2.Comn.striOMeasQCode = Out_strStatus
            Case 3
                m_Data.D3.Comn.striOMeasQCode = Out_strStatus
            Case 4
                m_Data.D4.Comn.striOMeasQCode = Out_strStatus
            Case 5
                m_Data.D5.Comn.striOMeasQCode = Out_strStatus
            Case 6
                m_Data.D6.Comn.striOMeasQCode = Out_strStatus
        End Select



        Return iMeasQCode

    End Function

    Public Function d3strGetStusUnit01PR730() As String

        Dim iUnit As Integer
        Dim strUnit As String = Nothing

        iUnit = m_Data.D1.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal

        Select Case iUnit
            Case 0
                strUnit = "Cd/m2"
            Case 1
                strUnit = "lux"
            Case 2
                strUnit = "Uncal"
        End Select

        d3strGetStusUnit01PR730 = strUnit

        '    Out_iUnit(0) = m_Data.D1.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(1) = m_Data.D2.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(2) = m_Data.D3.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(3) = m_Data.D4.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(4) = m_Data.D5.Comn.i1UnitValue0Value1Uncal2 '0:W/m2/sr/nm  1:W/m2/nm  2:Uncal

    End Function

    Public Function d4strGetStusUnit02PR730Spectrum() As String

        Dim iUnit As Integer
        Dim strUnit As String = Nothing

        iUnit = m_Data.D5.Comn.i1UnitValue0Value1Uncal2 '0:W/m2/sr/nm  1:W/m2/nm  2:Uncal

        Select Case iUnit
            Case 0
                strUnit = "W/m2/sr/nm"
            Case 1
                strUnit = "W/m2/nm"
            Case 2
                strUnit = "Uncal"
        End Select

        d4strGetStusUnit02PR730Spectrum = strUnit

        '    Out_iUnit(0) = m_Data.D1.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(1) = m_Data.D2.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(2) = m_Data.D3.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(3) = m_Data.D4.Comn.i1UnitValue0Value1Uncal2 '0:cd/m2  1:lux  2:Uncal
        '    Out_iUnit(4) = m_Data.D5.Comn.i1UnitValue0Value1Uncal2 '0:W/m2/sr/nm  1:W/m2/nm  2:Uncal

    End Function

    'Public Sub d5GetDataPR730(ByVal Out_sCdm2 As Single, ByVal Out_sCIEx As Single, ByVal Out_sCIEy As Single)

    '    'Y x y  (Resp. Code 1)
    '    'Y:1931 CIE Y
    '    '  x:1931 CIE x
    '    '    y:1931 CIE y

    '    Out_sCdm2 = m_Data.D1.s2YY
    '    Out_sCIEx = m_Data.D1.s3xx
    '    Out_sCIEy = m_Data.D1.s4yy

    'End Sub

    'Public Sub d55GetDataPR730(ByVal Out_sCIEu As Single, ByVal Out_sCIEv As Single)

    '    Out_sCIEu = m_Data.D6.s5uu
    '    Out_sCIEv = m_Data.D6.s6vv

    'End Sub

    'Public Sub d10RecvDataCorimetic(ByVal Out_sColorimetic() As Single)

    '    '    Dim iDimMax As Integer
    '    '
    '    '    'Redim
    '    '    iDimMax = m_TmpData.a0iDimMax
    '    '
    '    '    'Le Lv X Y Z x y u' v' T Duv
    '    '    ' 0  1 2 3 4 5 6 7  8  9 10
    '    '
    '    '    m_TmpData.f6sCIEu(iDimMax) = In_sColrimetic(7)
    '    '    m_TmpData.f7sCIEv(iDimMax) = In_sColrimetic(8)
    '    '
    '    '    m_TmpData.h0sLe(iDimMax) = In_sColrimetic(0)
    '    '    m_TmpData.h1sT(iDimMax) = In_sColrimetic(9)
    '    '    m_TmpData.h2sDuv(iDimMax) = In_sColrimetic(10)
    '    '    m_TmpData.h3sX(iDimMax) = In_sColrimetic(2)
    '    '    m_TmpData.h4sY(iDimMax) = In_sColrimetic(3)
    '    '    m_TmpData.h5sZ(iDimMax) = In_sColrimetic(4)

    '    Out_sColorimetic(5) = m_Data.D6.s3xx
    '    Out_sColorimetic(6) = m_Data.D6.s4yy
    '    Out_sColorimetic(7) = m_Data.D6.s5uu
    '    Out_sColorimetic(8) = m_Data.D6.s6vv

    '    Out_sColorimetic(0) = m_Data.D6.s2YY

    '    Out_sColorimetic(2) = m_Data.D2.s2XX
    '    Out_sColorimetic(3) = m_Data.D2.s3YY
    '    Out_sColorimetic(4) = m_Data.D2.s4ZZ

    '    Out_sColorimetic(9) = m_Data.D4.s3KelvinT
    '    Out_sColorimetic(10) = m_Data.D4.s4DevOfColorCoord


    'End Sub

    'Public Sub d6GetWavelengthData(ByVal Out_inm() As Integer, ByVal Out_sIntensity() As Double)

    '    'Out_sIntegInten = m_Data.D5.s2IntegIntensity
    '    Out_inm = m_Data.D5.i3nm
    '    Out_sIntensity = m_Data.D5.s4Intensity

    'End Sub

    Public Sub z1GetDeltaTime(ByVal Out_sDataGetTime As Double, ByVal Out_sMeasTime As Double)

        Out_sDataGetTime = m_Data.GetTime.sDataGetTime
        Out_sMeasTime = m_Data.GetTime.sMeasTime

    End Sub

    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean

        Dim strErrMsg As String = Nothing
        Dim nErrCode As Integer



        If Trim(strData) <> "" Then

            Select Case nMode
                Case eMeasMode.eCIE1931_Yxy   '1
                    If DivideData01(strData) = False Then Return False
                Case eMeasMode.eXYZ  '2
                    If DivideData02(strData) = False Then Return False
                Case eMeasMode.eCIE1976_Yuv   '3
                    If DivideData03(strData) = False Then Return False
                Case eMeasMode.eYCd  '4
                    If DivideData04(strData) = False Then Return False
                Case eMeasMode.eSpectrumData  '5   'Sepectrum Data
                    If DivideData05(strData) = False Then Return False
                Case eMeasMode.eCIE1931CIE1976_Yxyuv  '6
                    If DivideData06(strData) = False Then Return False
                    'm_Data.D1.Comn.i0MeasQCode = m_Data.D6.Comn.i0MeasQCode
                    'm_Data.D1.Comn.i1UnitValue0Value1Uncal2 = m_Data.D6.Comn.i1UnitValue0Value1Uncal2
                    'm_Data.D1.s2YY = m_Data.D6.s2YY
                    'm_Data.D1.s3xx = m_Data.D6.s3xx
                    'm_Data.D1.s4yy = m_Data.D6.s4yy
            End Select

        End If

        nErrCode = ErrorStatus(nMode, strErrMsg)

        If nErrCode <> 0 Then
            RaiseEvent evDetectedError(nErrCode, strErrMsg)
        End If


        Return True
    End Function

    Private Function DivideData01(ByVal In_strReceived As String) As Boolean

        Dim strData() As String = Nothing

        With m_Data.D1
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0

            DivideAndGetEachData(In_strReceived, m_Data.D1.Comn.strDivider, strData)

            For i As Integer = 2 To strData.Length - 1
                If strData(i) = "0" Then
                    Return False
                End If
            Next

            Try
                .Comn.i0MeasQCode = CInt(strData(0))
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3xx = CSng(strData(3))
                .s4yy = CSng(strData(4))
            Catch ex As Exception

            End Try

        End With

        Return True
    End Function

    Private Function DivideData02(ByVal In_strReceived As String) As Boolean


        Dim strData() As String = Nothing

        With m_Data.D2
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2XX = 0
            .s3YY = 0
            .s4ZZ = 0
            DivideAndGetEachData(In_strReceived, m_Data.D2.Comn.strDivider, strData)

            For i As Integer = 2 To strData.Length - 1
                If strData(i) = "0" Then
                    Return False
                End If
            Next

            Try
                .Comn.i0MeasQCode = CInt(strData(0))
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2XX = CSng(strData(2))
                .s3YY = CSng(strData(3))
                .s4ZZ = CSng(strData(4))
            Catch ex As Exception
                Return False
            End Try

        End With

        Return True
    End Function

    Private Function DivideData03(ByVal In_strReceived As String) As Boolean

        Dim strData() As String = Nothing

        With m_Data.D3
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3uu = 0
            .s4vv = 0
            DivideAndGetEachData(In_strReceived, m_Data.D3.Comn.strDivider, strData)

            For i As Integer = 2 To strData.Length - 1
                If strData(i) = "0" Then
                    Return False
                End If
            Next


            Try
                .Comn.i0MeasQCode = CInt(strData(0))
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3uu = CSng(strData(3))
                .s4vv = CSng(strData(4))
            Catch ex As Exception

            End Try


        End With

        Return True
    End Function

    Private Function DivideData04(ByVal In_strReceived As String) As Boolean

        Dim strData() As String = Nothing

        With m_Data.D4

            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3KelvinT = 0
            .s4DevOfColorCoord = 0

            DivideAndGetEachData(In_strReceived, m_Data.D4.Comn.strDivider, strData)

            For i As Integer = 2 To strData.Length - 1
                If strData(i) = "0" Then
                    Return False
                End If
            Next


            Try
                .Comn.i0MeasQCode = CInt(strData(0))
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3KelvinT = CSng(strData(3))
                .s4DevOfColorCoord = CSng(strData(4))
            Catch ex As Exception

            End Try


        End With

        Return True
    End Function

    Private Function DivideData05(ByVal In_strReceived As String) As Boolean

        Dim strData() As String = Nothing
        Dim i As Integer
        Dim iMax As Integer
        Dim k As Integer = 0

        With m_Data.D5
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut

            DivideAndGetEachData(In_strReceived, m_Data.D5.Comn.strDivider, strData)

            iMax = UBound(strData, 1) - 5

            If (iMax + 1) Mod 2 <> 0 Then Return False

            m_Data.D5.Comn.i0MeasQCode = CInt(strData(0))
            m_Data.D5.Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            m_Data.D5.s2IntegIntensity = CSng(strData(3))

            '만약 Data 짝이 안맞으면..
            If iMax Mod 2 = 0 Then
                m_Data.D5.Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            End If

            k = 0

            For i = 0 To iMax - 1 Step 2

                ReDim Preserve m_Data.D5.i3nm(k)
                ReDim Preserve m_Data.D5.s4Intensity(k)

                Try
                    m_Data.D5.i3nm(k) = CInt(strData(5 + i))
                    m_Data.D5.s4Intensity(k) = CSng(strData(6 + i))

                    k = k + 1
                Catch ex As Exception
                    Return False
                End Try

            Next i
            If m_Data.D5.i3nm.Length <> 401 Or m_Data.D5.i3nm Is Nothing Then
                Return False
            End If

        End With


        Return True
    End Function

    Private Function DivideData06(ByVal In_strReceived As String) As Boolean


        Dim strData() As String = Nothing

        With m_Data.D6

            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0
            .s5uu = 0
            .s6vv = 0
            DivideAndGetEachData(In_strReceived, m_Data.D6.Comn.strDivider, strData)

            For i As Integer = 2 To strData.Length - 1
                If strData(i) = "0" Then
                    Return False
                End If
            Next

            Try
                .Comn.i0MeasQCode = CInt(strData(0))
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))

                .s2YY = CSng(strData(2))
                .s3xx = CSng(strData(3))
                .s4yy = CSng(strData(4))
                .s5uu = CSng(strData(5))
                .s6vv = CSng(strData(6))
            Catch ex As Exception

            End Try


        End With


        Return True
    End Function

    Private Sub DivideAndGetEachData(ByVal In_strLineInput As String, ByVal In_strDivider() As String, ByRef Out_strEach() As String)

        Dim i As Integer
        Dim iStrLen As String
        Dim iPrev As String
        Dim iDimMax As Integer

        Dim k As Integer
        Dim kMax As Integer
        Dim fDivide As Boolean
        Dim iDividerLen As Integer

        iStrLen = Len(In_strLineInput)
        iPrev = 1
        iDimMax = 0

        i = 1

        Do Until i > iStrLen
            'Divider ====== (Divider 길이제한 없음)
            fDivide = False
            kMax = UBound(In_strDivider, 1)
            iDividerLen = 0

            For k = 0 To kMax
                If Mid(In_strLineInput, i, Len(In_strDivider(k))) = In_strDivider(k) Then
                    fDivide = True

                    '제일 긴 Divider 사용
                    If iDividerLen <= Len(In_strDivider(k)) Then
                        iDividerLen = Len(In_strDivider(k))
                    End If
                End If
            Next k
            '==============

            'Divide
            If fDivide Then
                ReDim Preserve Out_strEach(iDimMax)

                Out_strEach(iDimMax) = Mid(In_strLineInput, iPrev, i - iPrev)

                iDimMax = iDimMax + 1
                iPrev = i + iDividerLen
            Else
                iDividerLen = 1
            End If

            i = i + iDividerLen
        Loop

        If iDimMax = 0 Then
            '기본
            ReDim Out_strEach(0)
            Out_strEach(0) = In_strLineInput
        Else
            If fDivide Then
                '나머지 (Divider가 뒤에 있을때)
                'OK
            Else
                '나머지 (Divider가 뒤에 없을때)
                ReDim Preserve Out_strEach(iDimMax)
                Out_strEach(iDimMax) = Mid(In_strLineInput, iPrev, i - iPrev)
            End If
        End If

    End Sub


#End Region


#Region "Serial Communication Function"


    'Private g_sRcvData As String
    ' Public Sub WriteSendRcv(ByVal inTxTBox As TextBox, ByVal inStr As String)  '테스트용
    '    inTxTBox.Text = inTxTBox.Text & vbCrLf & inStr
    '  End Sub
    'Public Function SendCommand(ByVal inComm As String, ByRef outData As String) As Boolean



    '    g_sRcvData = ""
    '    g_eRS232Status = eTransferState.eTransferingData

    '    '  WriteSendRcv(FrmPR730Control.txtRcv, "Send : " & CStr(inComm))
    '    If communicator.Communicator.SendToString(inComm, g_sRcvData) <> CComSerial.eReturnCode.OK Then

    '        Return False
    '    End If
    '    ' WriteSendRcv(FrmPR730Control.txtRcv, "Recieve : " & CStr(g_sRcvData))
    '    outData = g_sRcvData


    '    Return True

    'End Function

    Public Function SendCommand(ByVal inComm As String) As Boolean
        ' WriteSendRcv(FrmPR730Control.txtRcv, "Send : " & CStr(inComm))
        If communicator.Communicator.SendToString(inComm) <> CComSerial.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function


#End Region




End Class
