Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms
Imports System.IO

Public Class CDevPR670

    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI
    Dim m_sLogPath As String = Application.StartupPath & "\Spectrum Log"

#Region "Defines"
    Private m_Data As tData

    ' Private m_ErrorCode As Integer
#End Region

#Region "Enum"

    Public Enum eCommands
        eSetsLCDBacklightLevel
        eClearCurrentSessionInstrumentErrors
        eDownloadsDataFromThePR670
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

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eMeasMode
        eCIE1931_Yxy = 1  '1
        eXYZ
        eCIE1976_Yuv
        eYCd
        eSpectrumData
        eCIE1931CIE1976_Yxyuv
    End Enum

    Public Enum eObserver
        e2
        e10
    End Enum

    Public Enum eBacklightMode
        eOff
        eLow
        eMedium
        eFull
    End Enum

    Public Enum eAccessories
        eMS_75 = 1
    End Enum


#End Region

#Region "Property"

#End Region

#Region "Structures"

#End Region

#Region "Commands"

    Dim sCommands() As String = New String() {"B", "C", "D", "E", "F", "I", "L", "M", "O", "Q", "R", "S", "X"}
#End Region

#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_PR670
    End Sub
#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)
        communicator.Communicator.TimeOut = 120

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        Else

            If SetRemoteMode() = False Then Return False

            If GetDeviceInfos(sInfos) = False Then Return False
            m_DeviceInfos = sInfos

            '      If SetExposureTime(m_DeviceInfos.ExposeTime) = False Then Return False
            If SetObserver(eObserver.e2) = False Then Return False
        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        '    If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '   End If
        m_bIsConnected = False
    End Sub
#End Region

#Region "API Functions"

    Public Overrides Function EndApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function StartApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Return True
    End Function

    Public Overrides Function LocalMode() As Boolean
        If QuitRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function RemoteMode() As Boolean
        If SetRemoteMode() = False Then Return False
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function SetLens(ByVal nLensIndex As Integer) As Boolean
        If SetPR670Lens(nLensIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer) As Boolean
        If SetExposureTime(nMeasSpeedIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetAperture(ByVal nAperatureIndex As Integer) As Boolean
        If SetPR670Aperture(nAperatureIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        With sInfos
            If SetAperture(.ApertureList(.ApertureIndex).nApertureCodeIndex) = False Then Return False
            If SetLens(.LensList(.LensIndex).nLensCodeIndex) = False Then Return False
            If SetExposureTime(.ExposeTime) = False Then Return False
            '     If SetSensitiveMode(0) = False Then Return False
        End With

        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Dim sLensList() As sLens = Nothing
        Dim sApertureList() As sAperture = Nothing

        '   If GetApertures(sAperatureList) = False Then Return False
        If GetAccessory(sLensList) = False Then Return False
        If GetApertures(sApertureList) = False Then Return False

        ReDim sInfos.ApertureList(sApertureList.Length - 1)
        ReDim sInfos.LensList(sLensList.Length - 1)
        ReDim sInfos.MeasSpeedList(0)


        For i As Integer = 0 To sApertureList.Length - 1
            sInfos.ApertureList(i).nApertureCodeIndex = sApertureList(i).nApertureCodeIndex
            sInfos.ApertureList(i).sApertureName = sApertureList(i).sApertureName
        Next

        For i As Integer = 0 To sLensList.Length - 1
            sInfos.LensList(i).nLensCodeIndex = sLensList(i).nLensCodeIndex
            sInfos.LensList(i).sLensName = sLensList(i).sLensName
        Next

        sInfos.MeasSpeedList(0).nMeasSpeedCodeIndex = 0
        sInfos.MeasSpeedList(0).sSpeedName = "Nothing"

        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As tData) As Boolean

        If Meas(eMeasMode.eXYZ, outData) = False Then Return False
        Thread.Sleep(100)
        Application.DoEvents()

        If DownloadData(outData) = False Then Return False
        Return True

    End Function

    Public Overrides Function DownloadData(ByRef outData As tData) As Boolean
        '     If ReadData(eMeasMode.eXYZ, outData) = False Then Return False
        If ReadData(eMeasMode.eSpectrumData, outData) = False Then Return False
        If ReadData(eMeasMode.eYCd, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1931_Yxy, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1976_Yuv, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then Return False
        Return True
    End Function


    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function
#End Region

#Region "Functions"

    Public Function Meas(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = ""

        sCommand = sCommands(eCommands.eMeasureCommand) & CStr(nMode)

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
     
        Application.DoEvents()

        If ErrCheck(sRcvData) = False Then
            Return False
        End If

        DataParser(sRcvData, nMode)
        outData = m_Data

        Return True
    End Function

    Public Function GetExposeTime(ByVal sRcvData As String) As Boolean

        Dim sBufData() As String = Nothing
        Dim sTime As String = ""

        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)
        sRcvData = sRcvData.TrimEnd("c")
        sRcvData = sRcvData.TrimEnd("e")
        sRcvData = sRcvData.TrimEnd("s")
        sRcvData = sRcvData.TrimEnd("m")
        sRcvData = sRcvData.TrimEnd(" ")
        sBufData = Split(sRcvData, ",")

        sTime = sBufData(2)
        If sTime Mod 1000 <> 0 Then
            sTime = sTime / 1000 + 1
        Else
            sTime = sTime / 1000
        End If
        m_Data.GetInfo.nExposureTime = sTime
        Return True
    End Function

    Public Function GetAccessory(ByRef sAccessory() As sLens) As Boolean
        Dim sCmd As String = "D116"
        Dim sRcvData As String = Nothing
        Dim arrLineBuf As Array = Nothing
        Dim arrCommaBuf As Array = Nothing
        Dim nCnt As Integer


        'Dim sBufCommInfo As CComCommonNode.sCommInfo = Nothing
        'Dim sBufRcvT As String = Nothing
        'sBufCommInfo.sSerialInfo = communicator.Communicator.Configure
        'sBufRcvT = sBufCommInfo.sSerialInfo.sRcvTerminator
        'sBufCommInfo.sSerialInfo.sRcvTerminator = ""
        'communicator.Communicator.Configure = sBufCommInfo.sSerialInfo
        'communicator.Communicator.TimeOut = 1

        'communicator.Communicator.ReciveToString(sRcvData)

        'sBufCommInfo.sSerialInfo.sRcvTerminator = sBufRcvT
        'communicator.Communicator.Configure = sBufCommInfo.sSerialInfo
        'communicator.Communicator.TimeOut = 120

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

    Public Function SetExposureTime(ByVal inTime As Integer) As Boolean
        'set exposure time
        Dim sCommand As String
        '    Dim sRcvData As String = Nothing

        sCommand = "SE" & CStr(inTime)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        'If SendCommand(sCommand, sRcvData) = False Then
        '    Return False
        'End If

        Return True

    End Function

    Public Function SetObserver(ByVal inObs As eObserver) As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
   
        sCommand = "SO"

        If inObs = eObserver.e2 Then
            sCommand = sCommand & "2"
        ElseIf inObs = eObserver.e10 Then
            sCommand = sCommand & "10"
        End If
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return ErrCheck(sRcvData)


    End Function

    Public Function SetPR670Lens(ByVal nLensCode As Integer) As Boolean

        Dim sCommand As String
        Dim sRcvData As String = Nothing
  
        sCommand = "SP" & CStr(nLensCode)
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return ErrCheck(sRcvData)

    End Function

    Public Function SetPR670Aperture(ByVal nApertureCode As Integer) As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
  
        sCommand = "SF" & CStr(nApertureCode)
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return ErrCheck(sRcvData)
    End Function

    Public Function SetSensitiveMode(ByVal nMode As Integer) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = ""

        sCommand = "SH" & CStr(nMode)
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return ErrCheck(sRcvData)
    End Function

    Public Function SetRemoteMode() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim sBufCommInfo As CComCommonNode.sCommInfo = Nothing
        Dim sBufRcvT As String = Nothing

        sCommand = "PHOTO"

        sBufCommInfo.sSerialInfo = communicator.Communicator.Configure
        sBufRcvT = sBufCommInfo.sSerialInfo.sRcvTerminator
        sBufCommInfo.sSerialInfo.sRcvTerminator = "None"
        communicator.Communicator.Configure = sBufCommInfo.sSerialInfo

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        communicator.Communicator.TimeOut = 1
        sBufCommInfo.sSerialInfo.sRcvTerminator = sBufRcvT
        communicator.Communicator.Configure = sBufCommInfo.sSerialInfo
        communicator.Communicator.ReciveToString(sRcvData)
        communicator.Communicator.TimeOut = 120
        'sBufCommInfo.sSerialInfo.sRcvTerminator = sBufRcvT
        'communicator.Communicator.Configure = sBufCommInfo.sSerialInfo

        aInitialize()
        Return True

    End Function

    Public Function QuitRemoteMode() As Boolean
        Dim sCommand As String
        sCommand = sCommands(eCommands.eExitRemote)
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function ReadData(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean

        Dim sCmd As String = sCommands(eCommands.eDownloadsDataFromThePR670) & CStr(nMode)
        Dim sRcvData As String = Nothing

        Application.DoEvents()
        If communicator.Communicator.SendToString(sCmd, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If ErrCheck(sRcvData) = False Then
            Return False
        End If


        If DataParser(sRcvData, nMode) = False Then
            Return False
        Else
            outData = m_Data
        End If

        Return True

    End Function

    Public Function ErrCheck(ByVal inRcv As String) As Boolean

        Try
            Dim ErrCode As Integer
            If inRcv.Substring(0, 1) = "-" Then
                ErrCode = Int(inRcv.Substring(0, 5))
            Else
                ErrCode = Int(inRcv.Substring(0, 4))
            End If

            Select Case ErrCode
                Case 0
                    Return True
                Case -1
                    ' MsgBox("Light source not constant.")
                    logOutput("Light source not constant")
                Case -2
                    '   MsgBox("Light overload – signal too intense.")
                    logOutput("Light overload – signal too intense.")
                Case -3
                    '  MsgBox("Cannot Sync to light source. Light source frequency below 20Hz," & vbCrLf & " above 400 Hz or signal too low to Sync.")
                    logOutput("Cannot Sync to light source. Light source frequency below 20Hz," & vbCrLf & " above 400 Hz or signal too low to Sync.")
                Case -4
                    ' MsgBox("Adaptive mode error.")
                    logOutput("Adaptive mode error.")
                Case -8
                    Return True
                    ' MsgBox("Weak light – insufficient signal.")
                Case -9
                    ' MsgBox("Sync Error.")
                    logOutput("Sync Error.")
                Case -10
                    '   MsgBox("Cannot Auto Sync to light source.")
                    logOutput("Cannot Auto Sync to light source.")
                Case -12
                    ' MsgBox("Adaptive mode time out. Light source not constant.")
                    logOutput("Adaptive mode time out. Light source not constant.")
                Case -1000
                    ' MsgBox("Illegal command")
                    logOutput("Illegal command")
                Case -1001
                    ' MsgBox("Too many fields in setup command")
                    logOutput("Too many fields in setup command")
                Case -1002
                    '   MsgBox("Invalid primary accessory code")
                    logOutput("Invalid primary accessory code")
                Case -1003
                    '   MsgBox("Invalid Addon 1 accessory code")
                    logOutput("Invalid Addon 1 accessory code")
                Case -1004
                    ' MsgBox("Invalid Addon 2 accessory code")
                    logOutput("Invalid Addon 2 accessory code")
                Case -1005
                    '   MsgBox("Accessory is not a primary accessory")
                    logOutput("Accessory is not a primary accessory")
                Case -1006
                    '  MsgBox("Accessory is not an Addon accessory")
                    logOutput("Accessory is not an Addon accessory")
                Case -1007
                    '  MsgBox("Accessory already selected")
                    logOutput("Accessory already selected")
                Case -1008
                    ' MsgBox("Invalid Aperture index (PR-670 only)")
                    logOutput("Invalid Aperture index (PR-670 only)")
                Case -1009
                    ' MsgBox("Invalid units code")
                    logOutput("Invalid units code")
                Case -1010
                    '  MsgBox("Invalid Exposure value")
                    logOutput("Invalid Exposure value")
                Case -1011
                    ' MsgBox("Invalid Gain code")
                    logOutput("Invalid Gain code")
                Case -1012
                    'MsgBox("Invalid average cycles")
                    logOutput("Invalid average cycles")
                Case -1015
                    '  MsgBox("Invalid CIE observer")
                    logOutput("Invalid CIE observer")
                Case -1017
                    ' MsgBox("Invalid Dark measurement mode")
                    logOutput("Invalid Dark measurement mode")
                Case -1019
                    ' MsgBox("Invalid Sync mode")
                    logOutput("Invalid Sync mode")
                Case -1021
                    '   MsgBox("Measurement title too long")
                    logOutput("Measurement title too long")
                Case -1022
                    ' MsgBox("Measurement title field empty after sending L command")
                    logOutput("Measurement title field empty after sending L command")
                Case -1023
                    ' MsgBox("Invalid user Sync period")
                    logOutput("Invalid user Sync period")
                Case -1024
                    '    MsgBox("Invalid R command")
                    logOutput("Invalid R command")
                Case -1025
                    '  MsgBox("Invalid Addon 3 accessory code")
                    logOutput("Invalid Addon 3 accessory code")
                Case -1026
                    ' MsgBox("Invalid sensitivity mode")
                    logOutput("Invalid sensitivity mode")
                Case -1035
                    '  MsgBox("Parameter not applicable to this instrument")
                    logOutput("Parameter not applicable to this instrument")
                Case -2000
                    '  MsgBox("This error code is returned whenever a response code is requested that does not exist, or when no other D command has been sent previously.")
                    logOutput("This error code is returned whenever a response code is requested that does not exist, or when no other D command has been sent previously.")

            End Select
            Return False
        Catch ex As Exception
            Return False
        End Try


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
            Case -8
                iMeasQCode = 0
                Out_strStatus = "" 'OK
            Case eTransferState.eReciveFail_TimeOut
                'Out_strStatus = "Communication Lost"
            Case Else
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /See PR650 Manual B-30"
        End Select

        Return iMeasQCode

    End Function

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


    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean

        Dim strErrMsg As String = ""
        Dim nErrCode As Integer


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
                    'm_Data.D1.Comn.i0MeasQCode = m_Data.D6.Comn.i0MeasQCode
                    'm_Data.D1.Comn.i1UnitValue0Value1Uncal2 = m_Data.D6.Comn.i1UnitValue0Value1Uncal2
                    'm_Data.D1.s2YY = m_Data.D6.s2YY
                    'm_Data.D1.s3xx = m_Data.D6.s3xx
                    'm_Data.D1.s4yy = m_Data.D6.s4yy
            End Select

        End If

        nErrCode = ErrorStatus(nMode, strErrMsg)
        If nErrCode <> 0 Then
            MsgBox(strErrMsg)
            Return False
        End If

        Return True
    End Function

    Private Sub DivideData01(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing

        With m_Data.D1
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0
            DivideAndGetEachData(In_strReceived, m_Data.D1.Comn.strDivider, strData)
            .Comn.i0MeasQCode = CInt(strData(0))

            If m_ErrorCode = -8 Then
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(0)
                .s3xx = CSng(0)
                .s4yy = CSng(0)
            Else
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3xx = CSng(strData(3))
                .s4yy = CSng(strData(4))
            End If

        End With


        Exit Sub
ErrHandler:


    End Sub

    Private Sub DivideData02(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing

        With m_Data.D2
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2XX = 0
            .s3YY = 0
            .s4ZZ = 0
            DivideAndGetEachData(In_strReceived, m_Data.D2.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
            m_ErrorCode = .Comn.i0MeasQCode
            If m_ErrorCode = -8 Then
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2XX = CSng(0)
                .s3YY = CSng(0)
                .s4ZZ = CSng(0)
            Else
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2XX = CSng(strData(2))
                .s3YY = CSng(strData(3))
                .s4ZZ = CSng(strData(4))
            End If

        End With


        Exit Sub
ErrHandler:


    End Sub

    Private Sub DivideData03(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing

        With m_Data.D3
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3uu = 0
            .s4vv = 0
            DivideAndGetEachData(In_strReceived, m_Data.D3.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))

            If m_ErrorCode = -8 Then
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(0)
                .s3uu = CSng(0)
                .s4vv = CSng(0)
            Else
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3uu = CSng(strData(3))
                .s4vv = CSng(strData(4))
            End If


        End With


        Exit Sub
ErrHandler:


    End Sub

    Private Sub DivideData04(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing

        With m_Data.D4

            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3KelvinT = 0
            .s4DevOfColorCoord = 0

            DivideAndGetEachData(In_strReceived, m_Data.D4.Comn.strDivider, strData)
            .Comn.i0MeasQCode = CInt(strData(0))

            If m_ErrorCode = -8 Then
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(0)
                .s3KelvinT = CSng(0)
                .s4DevOfColorCoord = CSng(0)
            Else
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3KelvinT = CSng(strData(3))
                .s4DevOfColorCoord = CSng(strData(4))
            End If


        End With

        Exit Sub
ErrHandler:


    End Sub
    Private Sub DivideData05(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing
        Dim i As Integer
        Dim iMax As Integer
        Dim k As Integer = 0

        With m_Data.D5
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut

            DivideAndGetEachData(In_strReceived, m_Data.D5.Comn.strDivider, strData)

            iMax = UBound(strData, 1) - 5

            If (iMax + 1) Mod 2 <> 0 Then GoTo ErrHandler

            m_Data.D5.Comn.i0MeasQCode = CInt(strData(0))

            If m_ErrorCode = -8 Then
                m_Data.D5.Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                m_Data.D5.s2IntegIntensity = CSng(0)

                '만약 Data 짝이 안맞으면..
                If iMax Mod 2 = 0 Then
                    m_Data.D5.Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
                End If

                k = 0

                For i = 0 To iMax - 1 Step 2

                    ReDim Preserve m_Data.D5.i3nm(k)
                    ReDim Preserve m_Data.D5.s4Intensity(k)

                    m_Data.D5.i3nm(k) = CInt(0)
                    m_Data.D5.s4Intensity(k) = CSng(0)

                    k = k + 1
                Next i
            Else
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

                    m_Data.D5.i3nm(k) = CInt(strData(5 + i))
                    m_Data.D5.s4Intensity(k) = CSng(strData(6 + i))

                    k = k + 1
                Next i
            End If


        End With

        Exit Sub
ErrHandler:


    End Sub

    Private Sub DivideData06(ByVal In_strReceived As String)

        On Error GoTo ErrHandler

        Dim strData() As String = Nothing

        With m_Data.D6

            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3xx = 0
            .s4yy = 0
            .s5uu = 0
            .s6vv = 0
            DivideAndGetEachData(In_strReceived, m_Data.D6.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))

            If m_ErrorCode = -8 Then
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(0)
                .s3xx = CSng(0)
                .s4yy = CSng(0)
                .s5uu = CSng(0)
                .s6vv = CSng(0)
            Else
                .Comn.i1UnitValue0Value1Uncal2 = CInt(strData(1))
                .s2YY = CSng(strData(2))
                .s3xx = CSng(strData(3))
                .s4yy = CSng(strData(4))
                .s5uu = CSng(strData(5))
                .s6vv = CSng(strData(6))
            End If


        End With


        Exit Sub
ErrHandler:


    End Sub

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
    Private Sub logOutput(ByVal msg As String)
        Dim sPath As String = m_sLogPath & "\" & CStr(Now.Year) & CStr(Now.Month) & CStr(Now.Day) & ".txt"

        If Directory.Exists(m_sLogPath) = False Then
            Directory.CreateDirectory(m_sLogPath)
        End If
        FileOpen(1, sPath, OpenMode.Append, OpenAccess.Write, OpenShare.Default)
        WriteLine(1, Now.Year & "_" & Now.Month & "_" & Now.Day & "_" & Now.Hour & "_" & Now.Minute & "_" & Now.Second & ":" & msg)
        FileClose(1)
    End Sub
#End Region
End Class
