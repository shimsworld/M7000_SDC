Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevPR650

    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI

#Region "Defines"
    Private m_Data As tData
#End Region

#Region "Enum"
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

#Region "Define Global Variable"
    Dim sCommands() As String = New String() {"S", "M", "D", "F", "E", "B"}
    Private Const PR650_Cmd_First_Set_Command = "S01,,,,,10,01,1"   '기본 Set  - See Manual

    'S Command 설명
    '    1         2              3             4              5                  6                       7                8                9
    'S<Lens>,<Add-on Lens1>,<Add-on Lens2>,<Add-on Lens3>,<Add-on Lens4>,<Sync Frequency>,<Integratioin Time>,<Meas. To Average>,<Units Type>


#End Region

#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_PR650
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

    Public Overrides Sub Disconnection()
        '   If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '  End If
        m_bIsConnected = False
    End Sub
#End Region

#Region "API Functions"
    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean

        '    Dim sAperatureList() As sAperture = Nothing
        Dim sLensList() As sLens = Nothing

        '   If GetApertures(sAperatureList) = False Then Return False
        If GetAccessory(sLensList) = False Then Return False

        ReDim sInfos.ApertureList(0)
        ReDim sInfos.LensList(sLensList.Length - 1)
        ReDim sInfos.MeasSpeedList(0)


        sInfos.ApertureList(0).nApertureCodeIndex = 0
        sInfos.ApertureList(0).sApertureName = "1"


        For i As Integer = 0 To sLensList.Length - 1
            sInfos.LensList(i).nLensCodeIndex = sLensList(i).nLensCodeIndex
            sInfos.LensList(i).sLensName = sLensList(i).sLensName
        Next

        sInfos.MeasSpeedList(0).nMeasSpeedCodeIndex = 0
        sInfos.MeasSpeedList(0).sSpeedName = "Nothing"

        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        If SetSetup(eAccessories.eMS_75, 1, sInfos.NumOfAverage, sInfos.MeasSpeedValue) = False Then Return False
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

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        If Meas(eMeasMode.eCIE1931CIE1976_Yxyuv, outData) = False Then Return False

        If DownloadData(outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function StartApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function EndApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        If ReadData(eMeasMode.eXYZ, outData) = False Then Return False
        If ReadData(eMeasMode.eYCd, outData) = False Then Return False
        If ReadData(eMeasMode.eSpectrumData, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1931_Yxy, outData) = False Then Return False
        If ReadData(eMeasMode.eCIE1976_Yuv, outData) = False Then Return False

        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True
    End Function
#End Region

#Region "Functions"

    Private Function SetRemoteMode() As Boolean
        Dim sCommand As String = "E"

        If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False
        Return True
    End Function

    Private Function QuitRemoteMode() As Boolean

        Return True
    End Function

    Public Function SetSetup(ByVal Accessoricode As eAccessories, _
                                 ByVal sPhotoUnit As String, ByVal sMeasCnt As String, ByVal sExposureTime As String) As Boolean
        Dim sCommand As String = "S" & Accessoricode & ",,,,," & sExposureTime & "," & sMeasCnt & "," & sPhotoUnit
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        Dim sErrorChk As String = ErrorCheck(sRcvData)
        If sErrorChk <> "True" Then
            Return False
        End If
        Return True
    End Function

    Public Function GetSoftwareVersion(ByRef sSoftwareVersion As String) As Boolean
        Dim sCommand As String = "D114"
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
        sSoftwareVersion = sRcvData.Clone
        Return True
    End Function

    Public Function GetAccessory(ByRef sAccessory() As sLens) As Boolean
        Dim sCommand As String = "D113"
        Dim sRcvData As String = ""
        Dim arrLineBuf As Array = Nothing
        Dim arrCommaBuf As Array = Nothing
        Dim nCnt As Integer
        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        arrLineBuf = Split(sRcvData, vbCrLf, -1)

        ReDim sAccessory(arrLineBuf.Length - 2)

        For nCnt = 0 To arrLineBuf.Length - 2
            arrCommaBuf = Split(arrLineBuf(nCnt), ",", -1)
            sAccessory(nCnt).sLensName = arrCommaBuf(1)
            sAccessory(nCnt).nLensCodeIndex = nCnt
        Next

        Return True
    End Function

    Public Function SetBacklight(ByVal mode As eBacklightMode) As Boolean
        Dim sCommand As String = "B" & CStr(mode)

        If communicator.Communicator.SendToString(sCommand) = False Then Return False
        Return True
    End Function

    Public Function Meas(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCommand As String = "M" & CStr(nMode)
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        Dim sErrorChk As String = ErrorCheck(sRcvData)
        If sErrorChk <> "True" Then
            Return False
        End If

        If DataParser(sRcvData, nMode) = False Then Return False

        outData = m_Data
        Return True
    End Function

    Public Function ReadData(ByVal nMode As eMeasMode, ByRef outData As tData) As Boolean
        Dim sCommand As String = "D" & CStr(nMode)
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        Dim sErrorChk As String = ErrorCheck(sRcvData)
        If sErrorChk <> "True" Then
            Return False
        End If

        If DataParser(sRcvData, nMode) = False Then Return False

        outData = m_Data
        Return True
    End Function

    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean

        If nMode = eMeasMode.eCIE1931_Yxy Then
            DivideData01(strData)
        ElseIf nMode = eMeasMode.eXYZ Then
            DivideData02(strData)
        ElseIf nMode = eMeasMode.eCIE1976_Yuv Then
            DivideData03(strData)
        ElseIf nMode = eMeasMode.eYCd Then
            DivideData04(strData)
        ElseIf nMode = eMeasMode.eSpectrumData Then
            DivideData05(strData)
        ElseIf nMode = eMeasMode.eCIE1931CIE1976_Yxyuv Then
            DivideData06(strData)
        End If
        Return True
    End Function

    Private Sub DivideData01(ByVal In_strReceived As String)
        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D1
            .Comn.i0MeasQCode = strData(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData(1)
            .s2YY = strData(2)
            .s3xx = strData(3)
            .s4yy = strData(4)
        End With
    End Sub

    Private Sub DivideData02(ByVal In_strReceived As String)
        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)

        With m_Data.D2
            .Comn.i0MeasQCode = strData(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData(1)
            .s2XX = strData(2)
            .s3YY = strData(3)
            .s4ZZ = strData(4)
        End With
    End Sub

    Private Sub DivideData03(ByVal In_strReceived As String)
        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)
        With m_Data.D3
            .Comn.i0MeasQCode = strData(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData(1)
            .s2YY = strData(2)
            .s3uu = strData(3)
            .s4vv = strData(4)
        End With
    End Sub

    Private Sub DivideData04(ByVal In_strReceived As String)
        Dim strData() As String

        strData = Split(In_strReceived, ",", -1)
        With m_Data.D4
            .Comn.i0MeasQCode = strData(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData(1)
            .s2YY = strData(2)
            .s3KelvinT = strData(3)
            .s4DevOfColorCoord = strData(4)
        End With
    End Sub

    Private Sub DivideData05(ByVal In_strReceived As String)
        Dim strData() As String
        Dim strData1() As String
        ' Dim iMax As Integer = 0
        '  Dim k As Integer = 0
        Dim nCnt As Integer
        Dim arrLineBuf As Array = Nothing
        Dim arrSpectrumData As Array = Nothing

        arrLineBuf = Split(In_strReceived, vbCrLf, -1)

        strData = Split(arrLineBuf(0), vbCr, -1)

        strData1 = Split(strData(0), ",", -1)

        ReDim m_Data.D5.i3nm(arrLineBuf.Length - 2)
        ReDim m_Data.D5.s4Intensity(arrLineBuf.Length - 2)

        For nCnt = 1 To m_Data.D5.i3nm.Length
            arrSpectrumData = Split(arrLineBuf(nCnt), ",", -1)
            m_Data.D5.i3nm(nCnt - 1) = arrSpectrumData(0)
            m_Data.D5.s4Intensity(nCnt - 1) = arrSpectrumData(1)
        Next

        With m_Data.D5
            .Comn.i0MeasQCode = strData1(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData1(1)
            .s2IntegIntensity = strData(1)
        End With

    End Sub

    Private Sub DivideData06(ByVal In_strReceived As String)
        Dim strData() As String
        strData = Split(In_strReceived, ",", -1)

        With m_Data.D6
            .Comn.i0MeasQCode = strData(0)
            .Comn.i1UnitValue0Value1Uncal2 = strData(1)
            .s2YY = strData(2)
            .s3xx = strData(3)
            .s4yy = strData(4)
            .s5uu = strData(5)
            .s6vv = strData(6)
        End With
    End Sub

    Private Function ErrorCheck(ByVal ChkData As String) As String
        Try
            Dim sChkData As String = ChkData.Substring(0, 2)

            Select Case sChkData
                Case "00"
                    Return "True"
                Case "1"
                    MsgBox("NO EOS Signal at start of measurement")
                    Return "NO EOS Signal at start of measurement"
                Case "03"
                    MsgBox("No start signal")
                    Return "No start signal"
                Case "04"
                    MsgBox("NO EOS Signal to start integration time")
                    Return "NO EOS Signal to start integration time"
                Case "05"
                    MsgBox("DMA(failure)")
                    Return "DMA(failure)"
                Case "06"
                    MsgBox("NO EOS after changed to SYNC Mode")
                    Return "NO EOS after changed to SYNC Mode"
                Case "07"
                    MsgBox("Unable to sync to light source")
                    Return "Unable to sync to light source"
                Case "08"
                    MsgBox("Sync lost during measurements")
                    Return "Sync lost during measurements"
                Case "10"
                    MsgBox("Weak light signal")
                    Return "Weak light signal"
                Case "12"
                    MsgBox("Unspecified hardware malfunction")
                    Return "Unspecified hardware malfunction"
                Case "13"
                    MsgBox("Software error")
                    Return "Software error"
                Case "14"
                    MsgBox("No Sample in L*u*v or L*a*b calculation")
                    Return "No Sample in L*u*v or L*a*b calculation"
                Case "16"
                    MsgBox("Adaptive inefration taking too much time finding correct integration time indicating possible")
                    Return "Adaptive inefration taking too much time finding correct integration time indicating possible"
                Case "17"
                    MsgBox("Main(Battery is low)")
                    Return "Main(Battery is low)"
                Case "18"
                    MsgBox("Low light level")
                    Return "Low light level"
                Case "19"
                    MsgBox("Light  level too high(overload)")
                    Return "Light  level too high(overload)"
                Case "20"
                    MsgBox("No sync signal")
                    Return "No sync signal"
                Case "21"
                    MsgBox("RAM error")
                    Return "RAM error"
                Case "29"
                    MsgBox("Corrupted(Data)")
                    Return "Corrupted(Data)"
                Case "30"
                    MsgBox("Noisy(signal)")
                    Return "Noisy(signal)"
                Case Else
                    Return "Null"
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "Null"
        End Try


    End Function

#End Region
End Class
