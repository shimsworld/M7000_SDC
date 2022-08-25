Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevCS2000
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI


#Region "Defines"
    Private m_Data As tData
    Private g_SetSpectrumString() As Integer = New Integer() {0, 100, 200, 300}
    Private g_SetSpectrumNumber As Integer

    Private sMeasSpeedName() As String = New String() {"Nomal", "Fast", "Multi", "Manual"}
    Private sMeasAperatureName() As String = New String() {"1", "0.2", "0.1"}
    Private sLensName() As String = New String() {"Standard", "Close-Up"}
    Private sNDFilterName() As String = New String() {"OFF", "ON", "AUTO"}

#End Region

#Region "Enum"

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eAperture
        e1
        e0R5
        e0R10
    End Enum

    Public Enum eMeasSpeed
        eNormal
        eFast
        eMulti
        eManual
    End Enum

    Public Enum eLens
        eNomal
        eCloseUp
    End Enum

    Public Enum eMeasMode
        eIntegrationTime
        eSpectral
        eColorimeteric
    End Enum

    Public Enum eSpectrum
        e380to479 = 1
        e480to579
        e580to679
        e680to780
    End Enum

    Public Enum eObserver
        e2
        e10
    End Enum


#End Region

#Region "Property"

#End Region

#Region "Structures"

#End Region

#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_CS2000
    End Sub
#End Region

#Region "Communication"
    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        Else

            If SetRemoteMode() = False Then
                Return False
            End If

            If MeasuringSwitchEnable() = False Then
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
        '   End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"

    Public Overrides Function StartApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function EndApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Dim sCommand As String = "IDDR"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""
        Dim outputdata() As String = Nothing
        Dim sAperatureList() As sAperture = Nothing
        Dim sLensList() As sLens = Nothing
        Dim sNDFilterList() As sNDFilter = Nothing

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            sMsg = ErrorCheck(sRcvData)
            If sMsg = "True" Then

                ReDim sInfos.ApertureList(2)
                ReDim sInfos.LensList(1)
                ReDim sInfos.MeasSpeedList(3)
                ReDim sInfos.NDFilterList(2)

                For i As Integer = 0 To 2
                    sInfos.ApertureList(i).nApertureCodeIndex = i
                    sInfos.ApertureList(i).sApertureName = sMeasAperatureName(i)
                Next

                For i As Integer = 0 To 2
                    sInfos.NDFilterList(i).nNDFilterCodeIndex = i
                    sInfos.NDFilterList(i).sNDFilterName = sNDFilterName(i)
                Next

                For i As Integer = 0 To 1
                    sInfos.LensList(i).nLensCodeIndex = i
                    sInfos.LensList(i).sLensName = sLensName(i)
                Next

                For i As Integer = 0 To 3
                    sInfos.MeasSpeedList(i).nMeasSpeedCodeIndex = i
                    sInfos.MeasSpeedList(i).sSpeedName = sMeasSpeedName(i)
                Next

            Else
                Return False
            End If

        End If
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        With sInfos
            '    If SetAperture(.ApertureList(.ApertureIndex).nApertureCodeIndex) = False Then Return False
            If SetMeasSpeed(.MeasSpeedList(.MeasSpeedIndex).nMeasSpeedCodeIndex, .MeasSpeedValue, .NDIndex) = False Then Return False
            '    If SetLens(.LensList(.LensIndex).nLensCodeIndex) = False Then Return False

        End With
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

    Public Overrides Function Measure(ByRef outData As tData) As Boolean

        communicator.Communicator.TimeOut = 60

        If MeasurementStart() = False Then Return False

        Thread.Sleep(100)
        Dim sRcvData As String = ""
        '     Thread.Sleep((m_Data.GetInfo.nExposureTime + 2) * 1000)
        If communicator.Communicator.ReciveToString(sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        If ErrorCheck(sRcvData) <> "True" Then Return False

        If MeasColorimetric() = False Then Return False
        If MeasSpectrumData() = False Then Return False

        outData = m_Data

        Return True


    End Function

    Public Function MeasuringSwitchEnable() As Boolean

        Dim sCommand As String = "MSWE,0"
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return True
        End If
        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As tData) As Boolean
        If Measure(outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer, ByVal nMeasSpeedVal As Double, Optional nNDFilterIndex As Integer = 0) As Boolean
        If SetSpeed(nMeasSpeedIndex, nMeasSpeedVal, nNDFilterIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetLens(ByVal nLensIndex As Integer) As Boolean
        If SetLen(nLensIndex) = False Then Return False
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        If MeasurementStop() = False Then Return False
        Return True
    End Function

#End Region

#Region "Function"

    Public Function SetObserver(ByVal index As eObserver) As Boolean
        Dim sCommand As String = "OBSS," & index

        If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False

        Return True
    End Function

    Private Function ErrorCheck(ByVal ChkData As String) As String
        Dim sErrorchk As String

        Try
            sErrorchk = ChkData.Substring(0, 4)
        Catch ex As Exception
            Return "Null"

        End Try
        Select Case sErrorchk
            Case "OK00"
                Return "True"
            Case "ER00"
                MsgBox("ER00 invalid command string or number of parameters received.")
                Return "ER00 invalid command string or number of parameters received."
            Case "ER02"
                MsgBox("ER02 Measurement error")
                Return "ER02 Measurement error"
            Case "ER05"
                MsgBox("ER05 No user calibration values")
                Return "ER05 No user calibration values"
            Case "ER10"
                MsgBox("ER10 Over measurement range")
                Return "ER10 Over measurement range"
            Case "ER17"
                MsgBox("ER17 Parameter error")
                Return "ER17 Parameter error"
            Case "ER20"
                MsgBox("ER20 No data")
                Return "ER20 No data"
            Case "ER30"
                MsgBox("ER30 Flash memory error")
                Return "ER30 Flash memory error"
            Case "ER51"
                MsgBox("ER51 CCD Peltier abnormality")
                Return "ER51 CCD Peltier abnormality"
            Case "ER52"
                MsgBox("ER52 Temperature count abnormality")
                Return "ER52 Temperature count abnormality"
            Case "ER71"
                MsgBox("ER71 Outside synchronization signal range")
                Return "ER71 Outside synchronization signal range"
            Case "ER81"
                MsgBox("ER81 Shutter operation abnormality")
                Return "ER81 Shutter operation abnormality"
            Case "ER82"
                MsgBox("ER82 Internal ND filter operation malfunction")
                Return "ER82 Internal ND filter operation malfunction"
            Case "ER83"
                MsgBox("ER83 Measurement angle abnormality")
                Return "ER83 Measurement angle abnormality"
            Case "ER99"
                MsgBox("ER99 Program abnormality")
                Return "ER99 Program abnormality"
            Case Else
                Return "Null"

        End Select

    End Function


    Private Function StoreAllDataDelete() As Boolean
        Dim sCommand As String = "STAD"

        If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False
        Return True
    End Function

    Private Function SetSpeed(ByVal index As eMeasSpeed, ByVal nSpeedVal As Double, ByVal nNDFilter As Integer) As Boolean
        Dim sRcvData As String = ""

        If index = eMeasSpeed.eFast Or index = eMeasSpeed.eNormal Then
            Dim sCommand As String = "SPMS," & index & "," & nNDFilter
            If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        ElseIf index = eMeasSpeed.eMulti Then
            Dim sCommand As String = "SPMS," & index & "," & Format(nSpeedVal, "00")
            If nSpeedVal < 1 Or nSpeedVal > 16 Then
                MsgBox("Speed Time is not correct")
                Return False
            Else
                If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False
            End If

        ElseIf index = eMeasSpeed.eManual Then
            nSpeedVal = nSpeedVal * 1000000
            Dim sCommand As String = "SPMS," & index & "," & Format(nSpeedVal, "000000000") & "," & nNDFilter
            If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False
        End If

        Return True
    End Function

    Private Function SetLen(ByVal index As eLens) As Boolean
        Dim sCommand As String = "LNSS," & index
        Dim sRcvData As String = ""
        Dim sError As String = ""
        Dim nSelApertureIndex As eAperture

        If index = eLens.eNomal Then
            If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
            sError = ErrorCheck(sRcvData)
            If sError <> "True" Then
                Return False
            End If
        ElseIf index = eLens.eCloseUp Then
            If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
            sError = ErrorCheck(sRcvData)
            If sError <> "True" Then
                Return False
            End If

            If GetApertureSet(nSelApertureIndex) = False Then Return False
            If SetCloseupLensCompensationFactor(nSelApertureIndex) = False Then Return False

        End If
        Return True
    End Function

    Private Function SetCloseupLensCompensationFactor(ByVal nIndex As eAperture) As Boolean
        Dim sCommand As String = ""
        ' "ALFS," & nIndex & ","
        Dim sRcvData As String = ""
        Dim fFactor As Decimal
        Dim sMsg As String = ""

        For i As Integer = 0 To 400
            sCommand = "ALFS," & nIndex & "," & i & "," & fFactor
            If communicator.Communicator.SendToString(sCommand) = CComCommonNode.eReturnCode.FuncErr Then Return False
        Next
        sCommand = "ALFS,3"
        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False

        Return True
    End Function

    Private Function GetApertureSet(ByRef index As eAperture) As Boolean
        Dim sCommand As String = "STSR"
        Dim sRcvData As String = ""
        Dim sMsg As String
        Dim OutputData() As String = Nothing

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
        sMsg = ErrorCheck(sRcvData)
        If sMsg = "True" Then
            DivideAndGetEachData(sRcvData, OutputData)
            If OutputData(1) = "0" Then
                index = eAperture.e1
            ElseIf OutputData(1) = "1" Then
                index = eAperture.e0R5
            ElseIf OutputData(1) = "2" Then
                index = eAperture.e0R10
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Private Function GetMeasSpeed(ByRef index As eMeasSpeed, ByRef nMeasSpeedVal As Double) As Boolean
        Dim sCommand As String = "SPMR"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""
        Dim outputdata() As String = Nothing

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
        sMsg = ErrorCheck(sRcvData)
        If sMsg = "True" Then
            DivideAndGetEachData(sRcvData, outputdata)
            If outputdata(1) = "0" Then
                index = eMeasSpeed.eNormal
            ElseIf outputdata(1) = "1" Then
                index = eMeasSpeed.eFast
            ElseIf outputdata(1) = "2" Then
                index = eMeasSpeed.eMulti
                nMeasSpeedVal = outputdata(2)
            ElseIf outputdata(1) = "3" Then
                index = eMeasSpeed.eManual
                nMeasSpeedVal = outputdata(2).TrimStart("0") / 1000000
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Private Function GetObserver(ByRef index As eObserver) As Boolean
        Dim sCommand As String = "OBSR"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""
        Dim outputdata() As String = Nothing

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
        sMsg = ErrorCheck(sRcvData)
        If sMsg = "True" Then
            DivideAndGetEachData(sRcvData, outputdata)
            index = outputdata(1)
        End If
        Return True
    End Function

    Public Function MeasColorimetric() As Boolean

        Dim sCommand As String = "MEDR,2,0,00"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            sMsg = ErrorCheck(sRcvData)
            If sMsg = "True" Then
                If DataParser(sRcvData, eMeasMode.eColorimeteric) = False Then Return False
            Else
                Return False
            End If
        End If
        Return True
    End Function

    Public Function MeasSpectrumData() As Boolean

        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        ReDim m_Data.D5.s4Intensity(400)
        ReDim m_Data.D5.i3nm(400)

        'If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then

        'End If
        For i As Integer = 0 To g_SetSpectrumString.Length - 1
            sCommand = "MEDR,1,0,0" & i + 1
            g_SetSpectrumNumber = g_SetSpectrumString(i)

            Thread.Sleep(5)
            Application.DoEvents()
            If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
                Return False
            Else
                sMsg = ErrorCheck(sRcvData)
                If sMsg = "True" Then
                    If DataParser(sRcvData, eMeasMode.eSpectral) = False Then Return False
                Else
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function SetRemoteMode() As Boolean
        Dim sCommand As String = "RMTS,1"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function QuitRemoteMode() As Boolean
        Dim sCommand As String = "RMTS,0"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function MeasurementStart() As Boolean
        Dim sCommand As String = "MEAS,1"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            Application.DoEvents()
            Thread.Sleep(10)
   
            sMsg = ErrorCheck(sRcvData)

            If sMsg = "True" Then
                If DataParser(sRcvData, eMeasMode.eIntegrationTime) = False Then Return False
            Else

                Return False
            End If

            End If
            'sRcvData = ""
            'sCommand = ""
            'If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then

            'End If
            Return True
    End Function

    Public Function MeasurementStop() As Boolean
        Dim sCommand As String = "MEAS,0"
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        End If
        Return True
    End Function

    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean

        If nMode = eMeasMode.eIntegrationTime Then
            '  If DivideData03(strData) = False Then Return False
        ElseIf nMode = eMeasMode.eSpectral Then
            If DivideData02(strData) = False Then Return False
        ElseIf nMode = eMeasMode.eColorimeteric Then
            If DivideData01(strData) = False Then Return False
        End If
        Return True

    End Function

    Private Function DivideData01(ByVal In_strReceived As String) As Boolean
        Dim strData() As String = Nothing

        Try
            DivideAndGetEachData(In_strReceived, strData)

            '    .sLe = strData(1)
            Try
                m_Data.D5.s2IntegIntensity = strData(1)
            Catch ex As Exception
                m_Data.D5.s2IntegIntensity = 0
            End Try
            Try
                m_Data.D4.s2YY = strData(2)
            Catch ex As Exception
                m_Data.D4.s2YY = 0
            End Try
            Try
                m_Data.D2.s2XX = strData(3)
            Catch ex As Exception
                m_Data.D2.s2XX = 0
            End Try
            Try
                m_Data.D2.s3YY = strData(4)
            Catch ex As Exception
                m_Data.D2.s3YY = 0
            End Try
            Try
                m_Data.D2.s4ZZ = strData(5)
            Catch ex As Exception
                m_Data.D2.s4ZZ = 0
            End Try
            Try
                m_Data.D1.s3xx = strData(6)
            Catch ex As Exception
                m_Data.D1.s3xx = 0
            End Try
            Try
                m_Data.D1.s4yy = strData(7)
            Catch ex As Exception
                m_Data.D1.s4yy = 0
            End Try
            Try
                m_Data.D1.s2YY = strData(2)
            Catch ex As Exception
                m_Data.D1.s2YY = 0
            End Try
            Try
                m_Data.D3.s3uu = strData(8)
            Catch ex As Exception
                m_Data.D3.s3uu = 0
            End Try
            Try
                m_Data.D3.s4vv = strData(9)
            Catch ex As Exception
                m_Data.D3.s4vv = 0
            End Try
            Try
                m_Data.D3.s2YY = strData(2)
            Catch ex As Exception
                m_Data.D3.s2YY = 0
            End Try
            Try
                m_Data.D4.s3KelvinT = strData(10)
            Catch ex As Exception
                m_Data.D4.s3KelvinT = 0
            End Try
            Try
                m_Data.D4.s2YY = strData(2)
            Catch ex As Exception
                m_Data.D4.s2YY = 0
            End Try
            Try
                m_Data.D4.s4DevOfColorCoord = strData(11)
            Catch ex As Exception
                m_Data.D4.s4DevOfColorCoord = 0
            End Try
            Try
                m_Data.D6.s2YY = strData(2)
            Catch ex As Exception
                m_Data.D6.s2YY = 0
            End Try
            Try
                m_Data.D6.s3xx = strData(6)
            Catch ex As Exception
                m_Data.D6.s3xx = 0
            End Try
            Try
                m_Data.D6.s4yy = strData(7)
            Catch ex As Exception
                m_Data.D6.s4yy = 0
            End Try
            Try
                m_Data.D6.s5uu = strData(8)
            Catch ex As Exception
                m_Data.D6.s5uu = 0
            End Try
            Try
                m_Data.D6.s6vv = strData(9)
            Catch ex As Exception
                m_Data.D6.s6vv = 0
            End Try

        Catch ex As Exception
            MsgBox("ColorimetericData Measure Failed")
            Return False
        End Try
        Return True
        '        .sDelta_uv = strData(11)
    End Function

    Private Function DivideData02(ByVal In_strReceived As String) As Boolean
        Dim strData() As String = Nothing
        Dim i As Integer
        Try
            DivideAndGetEachData(In_strReceived, strData)

            For i = 0 To strData.Length - 2

                m_Data.D5.s4Intensity(i + g_SetSpectrumNumber) = strData(i + 1)
                m_Data.D5.i3nm(i + g_SetSpectrumNumber) = 380 + i + g_SetSpectrumNumber
            Next
        Catch ex As Exception
            MsgBox("SpectrumData Measure Failed")
            Return False
        End Try
        Return True
    End Function

    Private Function DivideData03(ByVal In_strReceived As String) As Boolean
        Dim strData() As String = Nothing
        Try
            DivideAndGetEachData(In_strReceived, strData)

            Try
                m_Data.GetInfo.nExposureTime = CInt(strData(1))
            Catch ex As Exception
                m_Data.GetInfo.nExposureTime = CInt(strData(1).Substring(0, 3))
            End Try

        Catch ex As Exception
            MsgBox("ExposureTime Measure Failed")
            Return False
        End Try
        Return True
    End Function

    Private Function DivideAndGetEachData(ByVal In_strLineInput As String, ByRef Out_strEach() As String) As Boolean
        Dim arrbuf As Array
        Dim i As Integer
        Try
            arrbuf = In_strLineInput.Split(",")

            For i = 0 To arrbuf.Length - 1
                ReDim Preserve Out_strEach(i)
                Out_strEach(i) = arrbuf(i)
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region
End Class
