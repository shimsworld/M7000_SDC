Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevPR705
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI 'New CCommLib.CComAPI(CCommLib.CComCommonNode.eCommType.eSerial)



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

    Public Enum eBacklightMode
        eOff
        eLow
        eMedium
        eFull
    End Enum

    Public Enum eAccessories
        eMS_55
        eMS_5X
    End Enum

    Public Enum eAperture
        e1
        e0R5
        e0R25
        e0R125
        e2
    End Enum

  
#End Region


#Region "Define Global Variable"
    Dim sCommands() As String = New String() {"B", "C", "D", "E", "F", "I", "L", "M", "O", "Q", "R", "S", "X"}
    Private Const PR650_Cmd_First_Set_Command = "S01,,,,,,,1"   '기본 Set  - See Manual
    Private Const PR650_Cmd_First_Set_Command_SL1X = "S01,03,,,,,,1"        ' SL-1X  '[NDC !!]
    Private Const PR650_Cmd_First_Set_Command_ND2 = "S01,02,,,,,,1"         ' ND2    '[NDC !!]
    Private Const PR650_Cmd_First_Set_Command_SL1X_ND2 = "S01,03,02,,,,,1"  ' SL-1X & ND2  '[NDC !!]
    Private m_Data As tData
    Private m_BeforLuminance As Single = 0
    Private m_CurrentAperture As eAperture = eAperture.e0R125

    'S Command 설명
    '    1         2              3             4              5                  6                       7                8                9               10              11             12
    'S<Lens>,<Add-on Lens1>,<Add-on Lens2>,<Aperture>,<Photometric Units>,<Detector Exposure Time>,<Capture Mode>,<Meas. To Average>,<Power or Energy>,<Trigger Mode>,<View Shutter>,<CIE Observer>
    '기본 렌즈 및 Aperature 코드 찾는 방법
    '"D116"을 보내면 Rcv "Erroe code, Lens code, Lens name, Lens type, photometric units, radiometric units"
    ' Lens code 0 = MS-55   1 = MS-5X
    '"D117"를 보내면 Rcv "Error code, Aperature code, Aperature name, Bandwidth"
    ' Aperature code 0 = 1'  1 = 1/2' 2 = 1/4' 3 = 1/8' 4 = 2'

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
        m_MyModel = eModel.SPECTROMETER_PR705
    End Sub

#End Region

#Region "Communication"
    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else

            If SetRemoteMode() = False Then
                Return False
            End If

            If GetDeviceInfos(sInfos) = False Then
                Return False
            Else
                MyBase.m_DeviceInfos = sInfos
            End If

        End If

        m_bIsConnected = True
        Return True
    End Function

    'Public Overrides Function Connection(ByVal Config As CComSerial.sSerialPortInfo) As Boolean
    '    m_bIsConnected = False
    '    m_ConfigInfo = Config
    '    communicator = New CComAPI(CComCommonNode.eCommType.eSerial)

    '    If communicator.Communicator.Connect(m_ConfigInfo) = False Then
    '        Return False
    '    Else
    '        If SetRemoteMode() = False Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End If

    '    m_bIsConnected = True
    '    Return True

    'End Function

    Public Overrides Sub Disconnection()
        ' If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        ' End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"
    Public Overrides Function StartApertureChange() As Boolean

        If m_CurrentAperture = eAperture.e1 Then Return True '이미 1'어퍼처에 위치하고 있으므로 변경할 피요가 없음.
        If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e1, 1, 1, 0) = False Then Return False
        Application.DoEvents()
        Thread.Sleep(5000)
        m_CurrentAperture = eAperture.e1
        Return True
    End Function

    Public Overrides Function EndApertureChange() As Boolean
        If m_CurrentAperture = eAperture.e0R125 Then Return True '이미 1/8'어퍼처에 위치하고 있으므로 변경할 피요가 없음.
        If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e0R125, 1, 1, 0) = False Then Return False
        Application.DoEvents()
        Thread.Sleep(5000)
        m_CurrentAperture = eAperture.e0R125
        Return True
    End Function

    Public Overrides Function RemoteMode() As Boolean
        If SetRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function LocalMode() As Boolean
        If QuitRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As DeviceOption) As Boolean
        With sInfos
            If SetSetup(.LensList(.LensIndex).nLensCodeIndex, .ApertureList(.ApertureIndex).nApertureCodeIndex, 1, 1, 0) = False Then Return False
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
        ReDim sInfos.MeasSpeedList(0)

        For i As Integer = 0 To sAperatureList.Length - 1
            sInfos.ApertureList(i).nApertureCodeIndex = sAperatureList(i).nApertureCodeIndex
            sInfos.ApertureList(i).sApertureName = sAperatureList(i).sApertureName
        Next

        For i As Integer = 0 To sLensList.Length - 1
            sInfos.LensList(i).nLensCodeIndex = sLensList(i).nLensCodeIndex
            sInfos.LensList(i).sLensName = sLensList(i).sLensName
        Next

        sInfos.MeasSpeedList(0).nMeasSpeedCodeIndex = 0
        sInfos.MeasSpeedList(0).sSpeedName = "Nothing"

        ' DeviceInfos = sInfos

        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As tData) As Boolean
        If Meas(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return MeasFixedAperture(eMeasMode.eCIE1931CIE1976_Yxyuv, outData)
    End Function

    Public Overrides Function DownloadData(ByRef outData As tData) As Boolean
        If ReadData(eMeasMode.eXYZ, outData) = False Then Return False
        If ReadData(eMeasMode.eSpectrumData, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1976_Yuv, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True
    End Function

#End Region


#Region "Function"
    Public Function SetRemoteMode() As Boolean
        Dim sRcvData As String = Nothing
        Dim sCmd As String = "PR705"

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function QuitRemoteMode() As Boolean
        Dim sCmd As String = sCommands(eCommands.eExitRemote)

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function SetBacklight(ByVal mode As eBacklightMode) As Boolean
        Dim sCmd As String = sCommands(eCommands.eSetsLCDBacklightLevel) & CStr(mode)

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function SetSetup(ByVal Accessoricode As eAccessories, ByVal Aperaturecode As eAperture, _
                             ByVal sPhotoUnit As String, ByVal sMeasCnt As String, ByVal sExposureTime As String) As Boolean
        Dim sRcvData As String = Nothing
        Dim strErrMsg As String = Nothing
        Dim sCmd As String = sCommands(eCommands.eSetupMeasurmentParameters) & Accessoricode & "," & _
                             "," & _
                             "," & _
                             Aperaturecode & "," & _
                             sPhotoUnit & "," & _
                             sExposureTime & "," & _
                             "," & _
                             sMeasCnt


        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If


        '에러 체크 필요
        If ErrorStatus(CInt(sRcvData), strErrMsg) = False Then
            MsgBox(strErrMsg)
            Return False
        End If

        Return True
    End Function

    Public Function GetInstrumentSetup(ByRef sRcvData As String, ByRef mPRInfo As tData) As Boolean
        Dim sCmd As String = "D602"
        Dim arrBuf As Array = Nothing

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        arrBuf = Split(sRcvData, ",", -1)

        With m_Data.GetInfo
            .sLensName = arrBuf(1)
            .sApertureName = arrBuf(4)
            .nPhotoUnit = arrBuf(5)
            .sExposureMode = arrBuf(6)
            .nExposureTime = arrBuf(7)
            .nAverage = arrBuf(9)
        End With

        mPRInfo = m_Data
        Return True
    End Function

    Public Function GetSoftwareVersion(ByRef sSoftwareVersion As String) As Boolean
        Dim sCmd As String = "D114"
        Dim sRcvData As String = Nothing

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        sSoftwareVersion = sRcvData
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

    'Public Function GetAccessory(ByRef sAccessory() As String) As Boolean
    '    Dim sCmd As String = "D116"
    '    Dim sRcvData As String = Nothing
    '    Dim arrLineBuf As Array = Nothing
    '    Dim arrCommaBuf As Array = Nothing
    '    Dim sItemBuf As String = Nothing
    '    Dim nCnt As Integer

    '    If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    arrLineBuf = Split(sRcvData, vbCrLf, -1)

    '    For nCnt = 0 To arrLineBuf.Length - 2
    '        arrCommaBuf = Split(arrLineBuf(nCnt), ",", -1)
    '        sItemBuf = sItemBuf & arrCommaBuf(2) & ","
    '    Next

    '    sAccessory = Split(sItemBuf, ",", -1)
    '    Return True
    'End Function

    'Public Function GetApertures(ByRef sApertures() As String) As Boolean
    '    Dim sCmd As String = "D117"
    '    Dim sRcvData As String = Nothing
    '    Dim arrLineBuf As Array = Nothing
    '    Dim arrCommaBuf As Array = Nothing
    '    Dim sItemBuf As String = Nothing
    '    Dim nCnt As Integer

    '    If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
    '        Return False
    '    End If

    '    arrLineBuf = Split(sRcvData, vbCrLf, -1)

    '    For nCnt = 0 To arrLineBuf.Length - 2
    '        arrCommaBuf = Split(arrLineBuf(nCnt), ",", -1)
    '        sItemBuf = sItemBuf & arrCommaBuf(2) & ","
    '    Next

    '    sApertures = Split(sItemBuf, ",", -1)
    '    Return True
    'End Function

    Public Function Meas(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCmd As String = sCommands(eCommands.eMeasureCommand) & CStr(nMode)
        Dim sRcvData As String = Nothing
        Dim TwoDegApertureRange As Single = 1700


        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If DataParser(sRcvData, nMode) = False Then
            If m_ErrorCode = -4996 Then

                If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e0R125, 1, 1, 0) = True Then
                    Application.DoEvents()
                    Thread.Sleep(7000)

                    If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If

                    If DataParser(sRcvData, nMode) = False Then
                        outData = m_Data
                        Return False
                    End If

                Else
                    Return False
                End If
            Else
                outData = m_Data
                Return False
            End If
        End If



        If m_BeforLuminance < m_Data.D6.s2YY Then  '점점 밝아지는 경우 

            If m_Data.D6.s2YY > (TwoDegApertureRange * 0.3) Then  '2도 Appertuer의 최대(1700 Cd/m2)의 70%에 도달 하면 레인지 가변

                If EndApertureChange() = True Then

                End If

                'If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e0R125, 0, 0, 0) = True Then
                '    Application.DoEvents()
                '    Thread.Sleep(7000)
                'Else
                '    Return False
                'End If

            End If

        Else '점점 어두워 지는 경우
            '  If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperature.e1, 0, 0, 0) = False Then Return False

           
            If m_Data.D6.s2YY < (TwoDegApertureRange * 0.3) Then '2도 Appertuer의 최대(1700 Cd/m2)의 70%에 도달 하면 레인지 가변

                If StartApertureChange() = True Then

                End If

                'If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e1, 0, 0, 0) = True Then
                '    Application.DoEvents()
                '    Thread.Sleep(7000)

                'Else
                '    Return False
                'End If

            End If
           

        End If

        m_BeforLuminance = m_Data.D6.s2YY

        outData = m_Data

        Return True

    End Function


    Public Function MeasFixedAperture(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCmd As String = sCommands(eCommands.eMeasureCommand) & CStr(nMode)
        Dim sRcvData As String = Nothing

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If DataParser(sRcvData, nMode) = False Then
            If m_ErrorCode = -4996 Then

                If SetSetup(CDevPR705.eAccessories.eMS_55, CDevPR705.eAperture.e0R125, 1, 1, 0) = True Then
                    Application.DoEvents()
                    Thread.Sleep(7000)

                    If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                        Return False
                    End If

                    If DataParser(sRcvData, nMode) = False Then
                        outData = m_Data
                        Return False
                    End If

                Else
                    Return False
                End If
            Else
                outData = m_Data
                Return False
            End If
        End If

        outData = m_Data

        Return True

    End Function

    Public Function ReadData(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean

        Dim sCmd As String = sCommands(eCommands.eDownloadsDataFromThePR730) & CStr(nMode)
        Dim sRcvData As String = Nothing

        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If DataParser(sRcvData, nMode) = False Then
            Return False
        Else
            outData = m_Data
        End If

        Return True

    End Function

    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean

        Dim strErrMsg As String = Nothing

        If Trim(strData) <> "" Then
            Select Case nMode
                Case eMeasMode.eCIE1931_Yxy   '1
                    DivideData01(strData)
                Case eMeasMode.eXYZ  '2
                    DivideData02(strData)
                Case eMeasMode.eCIE1976_Yuv   '3
                    DivideData03(strData)
                Case eMeasMode.eYCd  '4
                    DivideData04(strData)
                Case eMeasMode.eSpectrumData  '5   'Sepectrum Data
                    DivideData05(strData)
                Case eMeasMode.eCIE1931CIE1976_Yxyuv  '6
                    DivideData06(strData)
            End Select
        End If

        '에러 체크 필요
        If ErrorStatus(nMode, strErrMsg) = False Then
            MyBase.RaiseErrorEvent(m_ErrorCode)
            '  MsgBox(strErrMsg)
            Return False
        End If

        Return True
    End Function

    Private Sub DivideData01(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D1
            ' .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0
            '   DivideAndGetEachData(In_strReceived, m_Data.D1.Comn.strDivider, strData)
            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = CInt(strData(0))
            .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            .s2YY = CSng(strData(2))
            .s3xx = CSng(strData(3))
            .s4yy = CSng(strData(4))


        End With

        Exit Sub
ErrHandler:

    End Sub

    Private Sub DivideData02(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D2
            ' .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2XX = 0
            .s3YY = 0
            .s4ZZ = 0
            '  DivideAndGetEachData(In_strReceived, m_Data.D2.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = CInt(strData(0))
            .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            .s2XX = CSng(strData(2))
            .s3YY = CSng(strData(3))
            .s4ZZ = CSng(strData(4))


        End With

        Exit Sub
ErrHandler:

    End Sub

    Private Sub DivideData03(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D3
            '    .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3uu = 0
            .s4vv = 0
            '  DivideAndGetEachData(In_strReceived, m_Data.D3.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = CInt(strData(0))
            .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            .s2YY = CSng(strData(2))
            .s3uu = CSng(strData(3))
            .s4vv = CSng(strData(4))


        End With

        Exit Sub
ErrHandler:

    End Sub

    Private Sub DivideData04(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D4
            '  .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3KelvinT = 0
            .s4DevOfColorCoord = 0
            '   DivideAndGetEachData(In_strReceived, m_Data.D4.Comn.strDivider, strData)
            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = CInt(strData(0))
            .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            .s2YY = CSng(strData(2))
            .s3KelvinT = CSng(strData(3))
            .s4DevOfColorCoord = CSng(strData(4))


        End With

        Exit Sub
ErrHandler:

    End Sub

    Private Sub DivideData05(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String
        Dim iMax As Integer
        Dim k As Integer = 0
        Dim nCnt As Integer
        Dim arrLineBuf As Array = Nothing
        Dim arrSpectrumData As Array = Nothing

        arrLineBuf = Split(In_strReceived, vbCrLf, -1)

        strData = Split(arrLineBuf(0), ",", -1)

        ReDim m_Data.D5.i3nm(arrLineBuf.Length - 3)
        ReDim m_Data.D5.s4Intensity(arrLineBuf.Length - 3)

        '스펙트럼 갯수 체크 필요
        For nCnt = 1 To m_Data.D5.i3nm.Length
            arrSpectrumData = Split(arrLineBuf(nCnt), ",", -1)
            m_Data.D5.i3nm(nCnt - 1) = arrSpectrumData(0)
            m_Data.D5.s4Intensity(nCnt - 1) = arrSpectrumData(1)
        Next

        m_Data.D5.Comn.i0MeasQCode = CInt(strData(0))
        m_ErrorCode = CInt(strData(0))
        m_Data.D5.Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
        m_Data.D5.iMax = CInt(strData(2))
        m_Data.D5.s2IntegIntensity = CSng(strData(3))


        Exit Sub
ErrHandler:

    End Sub

    Private Sub DivideData06(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D6

            '   .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0
            .s5uu = 0
            .s6vv = 0
            '   DivideAndGetEachData(In_strReceived, m_Data.D6.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = CInt(strData(0))
            .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
            .s2YY = CSng(strData(2))
            .s3xx = CSng(strData(3))
            .s4yy = CSng(strData(4))
            .s5uu = CSng(strData(5))
            .s6vv = CSng(strData(6))


        End With

        Exit Sub
ErrHandler:

    End Sub

    Private Function ErrorStatus(ByVal nMode As eMeasMode, ByRef Out_strStatus As String) As Boolean

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
                Return True
                '   Case 77
                '    Out_strStatus = "Communication Lost"
            Case -2000
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Response code."
            Case -1999
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid ASCII command."
            Case -1998
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Field overflow S command."
            Case -1997
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Primary accessory."
            Case -1996
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Primary accessory 1."
            Case -1995
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Primary accessory 2."
            Case -1994
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Add On accessory 2 same as 1."
            Case -1993
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Aperture."
            Case -1992
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Units."
            Case -1991
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Integration time out of range."
            Case -1990
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Capture Mode."
            Case -1989
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Number of Cycles out of range."
            Case -1988
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Calc Mode."
            Case -1987
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Trigger Mode."
            Case -1986
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid View Shutter command."
            Case -1985
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid CIE Observer."
            Case -1984
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Invalid Meas Index."
            Case -1983
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Field overflow R cmd."
            Case -1982
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /String overflow L cmd."
            Case -1981
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Disk Empty."
            Case -1980
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Measurement required."
            Case -1979
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Excessive length."
            Case -1978
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Empty string."
            Case -5000
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Weak Signal."
            Case -4999
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Time Underflow Level Overflow."
            Case -4996
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /A2D overflow Measuring Light."
            Case -4995
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /A2D overflow Measuring Dark."
            Case -4994
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Variable Light Level."
            Case -4993
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /Adaptive Time Limit."
            Case -7999
                Out_strStatus = "Error" + CStr(iMeasQCode) + " Detetor Pressure error."
            Case -7998
                Out_strStatus = "Error" + CStr(iMeasQCode) + " Detetor Pressure sensor failure."
            Case -7997
                Out_strStatus = "Error" + CStr(iMeasQCode) + " Detetor Temperature is out od spec."
            Case -7996
                Out_strStatus = "Error" + CStr(iMeasQCode) + " Detetor Temperature device failure."
            Case -7995
                Out_strStatus = "Error" + CStr(iMeasQCode) + " Maximum Internal Temperature Exceeded."
            Case -9999
                Out_strStatus = "Error" + CStr(iMeasQCode) + " File Opening."
        End Select

        Return False

    End Function
#End Region
End Class
