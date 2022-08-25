Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms


Public Class CDevCS1000A
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI

#Region "Defines"
    Private m_Data As tData

    Private sMeasSpeedName() As String = New String() {"Nomal", "Fast"}
    Private sMeasAperatureName() As String = New String() {"1"}
    Private sMeasLensName() As String = New String() {"Standard", "Micro"}

    Private g_SetSpectrumString() As Integer = New Integer() {0, 28, 56, 84, 112, 140, 168, 196, 224, 252, 280, 308, 336, 364, 392}
    Private g_SetSpectrumNumber As Integer

#End Region

#Region "Enum"

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eMeasSpeed
        eNormal
        eFast
        eManual
    End Enum

    Public Enum eAperture
        e1
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
        m_MyModel = eModel.SPECTROMETER_CS1000A
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
        ' If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '  End If
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

    Public Overrides Function DarkMeasure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        Dim sAperatureList() As sAperture = Nothing
        Dim sLensList() As sLens = Nothing

        ReDim sInfos.ApertureList(0)
        ReDim sInfos.LensList(1)
        ReDim sInfos.MeasSpeedList(1)

        For i As Integer = 0 To sInfos.ApertureList.Length - 1
            sInfos.ApertureList(i).nApertureCodeIndex = i
            sInfos.ApertureList(i).sApertureName = sMeasAperatureName(i)
        Next
        For i As Integer = 0 To sInfos.LensList.Length - 1
            sInfos.LensList(i).nLensCodeIndex = i
            sInfos.LensList(i).sLensName = sMeasLensName(i)
        Next
        For i As Integer = 0 To sInfos.MeasSpeedList.Length - 1
            sInfos.MeasSpeedList(i).nMeasSpeedCodeIndex = i
            sInfos.MeasSpeedList(i).sSpeedName = sMeasSpeedName(i)
        Next

        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        If Measure(outData) = False Then Return False
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

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        '  Application.DoEvents()
        communicator.Communicator.TimeOut = 120

        If MeasurementStart() = False Then Return False

        Dim sRcvData As String = ""
        If communicator.Communicator.ReciveToString(sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        If ErrorCheck(sRcvData) <> "True" Then Return False

        If MeasColorimetric() = False Then Return False

        If MeasSpectrumData() = False Then Return False

        '  If MeasurementStop() = False Then Return False

        outData = m_Data
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        If MeasurementStop() = False Then Return False
        Return True
    End Function

    Public Overrides Function SetAperture(ByVal nAperatureIndex As Integer) As Boolean
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        With sInfos
            If SetMeasSpeed(.MeasSpeedList(.MeasSpeedIndex).nMeasSpeedCodeIndex, .MeasSpeedValue) = False Then Return False
        End With
        Return True
    End Function

    Public Overrides Function SetLens(ByVal nLensIndex As Integer) As Boolean
        Return True
    End Function

    Public Overrides Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer, ByVal nMeasSpeedVal As Double, Optional nNDFilterIndex As Integer = 0) As Boolean
        If SetSpeed(nMeasSpeedIndex, nMeasSpeedVal) = False Then Return False
        Return True
    End Function
#End Region

#Region "Functions"
    Public Function SetRemoteMode() As Boolean
        Dim sCommand As String = "RMT,1"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False
        Return True
    End Function

    Public Function QuitRemoteMode() As Boolean
        Dim sCommand As String = "RMT,0"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False
        Return True
    End Function

    Private Function SetSpeed(ByVal index As eMeasSpeed, ByVal nSpeedVal As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If index = eMeasSpeed.eNormal Then
            sCommand = "SPS,"
            sCommand = sCommand & index
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False

            sCommand = "MMS" & "," & "0" & "," & ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False
        ElseIf index = eMeasSpeed.eFast Then
            sCommand = "SPS,"
            sCommand = sCommand & index
            Thread.Sleep(100)
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False

            sCommand = "MMS" & "," & "0" & "," & ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False
        ElseIf index = eMeasSpeed.eManual Then
            If nSpeedVal < 0.04 Or nSpeedVal > 60 Then
                MsgBox("Speed Time is not correct")
                Return False
            End If
            sCommand = "MMS" & "," & "3" & "," & nSpeedVal
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False
        End If

        Return True
    End Function

    Private Function GetSpeed(ByRef index As eMeasSpeed, ByRef nSpeedVal As Double) As Boolean
        Dim sCommand As String = "SPR"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""
        Dim sStatus() As String = Nothing

        If GetStatus(sRcvData) = False Then Return False
        sStatus = sRcvData.Split(",")
        If sStatus(1) = "3" Then
            index = eMeasSpeed.eManual
            nSpeedVal = CDbl(sStatus(3))
        Else
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            If sMsg <> "True" Then Return False
            sStatus = sRcvData.Split(",")
            If sStatus(1) = "0" Then
                index = eMeasSpeed.eNormal
                nSpeedVal = 0
            ElseIf sStatus(1) = "1" Then
                index = eMeasSpeed.eFast
                nSpeedVal = 0
            End If
        End If

        Return True
    End Function

    Private Function GetStatus(ByRef sOutData As String) As Boolean
        Dim sCommand As String = "STR"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False

        sRcvData = sOutData
        Return True
    End Function

    Public Function MeasurementStart() As Boolean
        Dim sCommand As String = "MES,1"
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        Else
            Application.DoEvents()
            Thread.Sleep(5)
            sMsg = ErrorCheck(sRcvData)

            If sMsg = "True" Then
                If DataParser(sRcvData, eMeasMode.eIntegrationTime) = False Then Return False
            Else
                Return False
            End If
        End If
        Return True
    End Function


    Public Function MeasurementStop() As Boolean
        Dim sCommand As String = "MES,0"
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then
            Return False
        End If
        Return True
    End Function

    Public Function MeasColorimetric() As Boolean
        Dim sCommand As String = "BDR,1," & eObserver.e2 & ",0" 'BDR, Colorimetric, 2',Text
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        'If sRcvData.Length < 4 Then
        '    If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        'End If
        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False

        sCommand = "&"
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        Application.DoEvents()
        Thread.Sleep(5)

        If DataParser(sRcvData, eMeasMode.eColorimeteric) = False Then Return False

        Return True
    End Function

    Public Function MeasSpectrumData() As Boolean
        Dim sCommand As String = "BDR,0," & eObserver.e2 & ",0" 'BDR, Spectrum, 2',Text
        Dim sRcvData As String = ""
        Dim sMsg As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        sMsg = ErrorCheck(sRcvData)
        If sMsg <> "True" Then Return False

        ReDim m_Data.D5.s4Intensity(400)
        ReDim m_Data.D5.i3nm(400)

        For i As Integer = 0 To g_SetSpectrumString.Length - 1
            sCommand = "&"
            Application.DoEvents()
            Thread.Sleep(5)
            g_SetSpectrumNumber = g_SetSpectrumString(i)
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            sMsg = ErrorCheck(sRcvData)
            ' If sMsg = "True" Then
            If DataParser(sRcvData, eMeasMode.eSpectral) = False Then Return False
            '   End If
        Next
        Return True
    End Function


    Private Function DataParser(ByVal strData As String, ByVal nMode As eMeasMode) As Boolean


        Select Case nMode
            Case eMeasMode.eColorimeteric
                If DivideData01(strData) = False Then Return False

            Case eMeasMode.eSpectral
                If DivideData02(strData) = False Then Return False

            Case eMeasMode.eIntegrationTime
                If DivideData03(strData) = False Then Return False
        End Select
        Return True
    End Function

    Private Function DivideData01(ByVal In_strReceived As String)
        Dim strData() As String = Nothing

        DivideAndGetEachData(In_strReceived, strData)
        Try
            With m_Data
                Try
                    .D1.s2YY = strData(1)
                Catch ex As Exception
                    .D1.s2YY = 0
                End Try
                Try
                    .D1.s3xx = strData(5)
                Catch ex As Exception
                    .D1.s3xx = 0
                End Try
                Try
                    .D1.s4yy = strData(6)
                Catch ex As Exception
                    .D1.s4yy = 0
                End Try
                Try
                    .D2.s2XX = strData(2)
                Catch ex As Exception
                    .D2.s2XX = 0
                End Try
                Try
                    .D2.s3YY = strData(3)
                Catch ex As Exception
                    .D2.s3YY = 0
                End Try
                Try
                    .D2.s4ZZ = strData(4)
                Catch ex As Exception
                    .D2.s4ZZ = 0
                End Try
                Try
                    .D3.s2YY = strData(1)
                Catch ex As Exception
                    .D3.s2YY = 0
                End Try
                Try
                    .D3.s3uu = strData(7)
                Catch ex As Exception
                    .D3.s3uu = 0
                End Try
                Try
                    .D3.s4vv = strData(8)
                Catch ex As Exception
                    .D3.s4vv = 0
                End Try
                Try
                    .D4.s2YY = strData(1)
                Catch ex As Exception
                    .D4.s2YY = 0
                End Try
                Try
                    .D4.s3KelvinT = strData(9)
                Catch ex As Exception
                    .D4.s3KelvinT = 0
                End Try
                Try
                    .D4.s4DevOfColorCoord = strData(10)
                Catch ex As Exception
                    .D4.s4DevOfColorCoord = 0
                End Try
                Try
                    .D5.s2IntegIntensity = strData(0)
                Catch ex As Exception
                    .D5.s2IntegIntensity = 0
                End Try
                Try
                    .D6.s2YY = strData(1)
                Catch ex As Exception
                    .D6.s2YY = 0
                End Try
                Try
                    .D6.s3xx = strData(5)
                Catch ex As Exception
                    .D6.s3xx = 0
                End Try
                Try
                    .D6.s4yy = strData(6)
                Catch ex As Exception
                    .D6.s4yy = 0
                End Try
                Try
                    .D6.s5uu = strData(7)
                Catch ex As Exception
                    .D6.s5uu = 0
                End Try
                Try
                    .D6.s6vv = strData(8)
                Catch ex As Exception
                    .D6.s6vv = 0
                End Try

            End With

        Catch ex As Exception
            MsgBox("ColorimetericData Measure Failed")
            Return False
        End Try
        Return True
    End Function

    Private Function DivideData02(ByVal In_strReceived As String) As Boolean
        Dim strData() As String = Nothing
        DivideAndGetEachData(In_strReceived, strData)
        Try
            For i = 0 To strData.Length - 1
                m_Data.D5.s4Intensity(i + g_SetSpectrumNumber) = strData(i)
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
            With m_Data.GetInfo

                DivideAndGetEachData(In_strReceived, strData)
                .nExposureTime = CInt(strData(1))

            End With
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

    Private Function ErrorCheck(ByVal ChkData As String) As String
        Dim sErrorchk As String
        Dim SplitData() As String

        SplitData = ChkData.Split(",")
        Try
            If SplitData(0).Length < 4 Then
                sErrorchk = SplitData(0).Substring(0, 2)
            Else
                sErrorchk = SplitData(0).Substring(0, 4)
            End If
        Catch ex As Exception
            Return "false"
        End Try


        Select Case sErrorchk
            Case "OK"
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
#End Region
End Class
