Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class CDevDarsaPro
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI

    Private m_ExposureTime As Integer


#Region "Defines"
    Private m_Data As tData
#End Region

#Region "Enum"


    Public Enum eMeasurementStatus
        _SATURATION = 0
        _OK = 1
    End Enum

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eGain
        eAuto
        e1Gain
        e2Gain
        e3Gain
        e4Gain
    End Enum

#End Region

#Region "Creator, Disposer, Init"

    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_DarsaPro
        m_bIsConnected = False
    End Sub

#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfos As DeviceOption = Nothing

        If m_bIsConnected = True Then Return True

        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)

        communicator.Communicator.TimeOut = 10 'sec

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        Else

            If LocalMode() = False Then Return False
            If RemoteMode() = False Then Return False

        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        ' If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        ' End If
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

    Public Overrides Function SetAperture(ByVal nGainNumber As Integer) As Boolean
        If SetGain(nGainNumber) = False Then Return False
        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        outData = m_Data
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return Me.Meas(outData)
    End Function

    Public Overrides Function LocalMode() As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing

        sCommand = "OEMEND>"

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If CheckRcvFrame(sRcvData) = False Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function RemoteMode() As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing

        sCommand = "OEMSTART>"

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If CheckRcvFrame(sRcvData) = False Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function DarkMeasure() As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing

        sCommand = "OEMDMEAS>"
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If CheckRcvFrame(sRcvData) = False Then
            Return False
        End If

        Return True
    End Function


    Public Overrides Function Measure(ByRef outData As tData) As Boolean

        If Meas(outData) = False Then Return False

        Return True

    End Function

    Public Overrides Function Test() As Boolean
        Return DataParser("")
    End Function

#End Region

#Region "Functions"

    Public Function SetGain(ByVal nGain As eGain) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing

        sCommand = "FGAIN " & nGain & ">"

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If CheckRcvFrame(sRcvData) = False Then
            Return False
        End If

        Return True
    End Function

    Public Function Meas(ByRef outData As tData) As Boolean
        Dim sCommand As String
        Dim sRcvData As String = Nothing

        sCommand = "OEMMEAS>"

        '  Dim tDalyTime As Integer = 10
        '  communicator.Communicator.TimeOut = tDalyTime
        Application.DoEvents()

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If CheckRcvFrame(sRcvData) = False Then
            Return False
        End If

        If DataParser(sRcvData) = False Then Return False

        outData = m_Data

        Return True
    End Function

    Public Function CheckRcvFrame(ByVal sRcvFrame As String) As Boolean

        Try

            If sRcvFrame Is Nothing Then Return False
            If sRcvFrame.Length = 0 Then Return False

            sRcvFrame = sRcvFrame.TrimStart(Chr(2))  '19
            sRcvFrame = sRcvFrame.TrimEnd(vbLf)
            sRcvFrame = sRcvFrame.TrimEnd(vbCr)

            Dim State As String = sRcvFrame.Substring(sRcvFrame.Length - 2, 2)


            If State = "OK" Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Return False
        End Try


        Return True
    End Function

    Private Function ErrorStatus(ByRef Out_strStatus As String, ByVal nMode As Object) As Integer

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
                Out_strStatus = "Communication Lost"
            Case Else
                Out_strStatus = "Error" + CStr(iMeasQCode) + " /See PR650 Manual B-30"
        End Select

        Return iMeasQCode

    End Function

    Private Sub Initialize()

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

    Private Function DataParser(ByVal strData As String) As Boolean

        '  "Y:33585.590, x:0.2488, y:0.2318, F:1" & vbCrLf & "380,780,10" & vbCrLf & "68,216,215,123,134,140,128,111,119,143,173,162,
        '   110,109,139,114,96,114,182,484,420,115,77,71,77,99,97,94,75,53,116,123,70,66,20,26,15,2,24,30,7," & vbCrLf & "OK" & vbCrLf & ""
        'strData = "Y:33585.590, x:0.2488, y:0.2318, F:1" & vbCrLf & "380,780,10" & vbCrLf & "68,216,215,123,134,140,128,111,119,143,173,162, 110,109,139,114,96,114,182,484,420,115,77,71,77,99,97,94,75,53,116,123,70,66,20,26,15,2,24,30,7," & vbCrLf & "OK" & vbCrLf & ""

        strData = strData.TrimStart(Chr(2))  '19
        strData = strData.TrimEnd(vbLf)
        strData = strData.TrimEnd(vbCr)

        If strData = "" Then Return False

        '  Dim sCaption As Byte = vbLf
        Dim arrBuf As Array = Split(strData, vbCrLf, -1)

        If arrBuf Is Nothing = True Then Return False

        Dim strLxyData As String = arrBuf(0)
        Dim strWavelengthData As String = arrBuf(1)
        Dim strIntensityData As String = arrBuf(2)
        Dim strStatus As String = arrBuf(3)

        If strStatus <> "OK" Then Return False

        Dim measurementStatus As eMeasurementStatus
        Dim dLv As Double
        Dim dx As Double
        Dim dy As Double
        Dim strTemp As String

        arrBuf = Split(strLxyData, ",", -1)

        'Y : Luminance
        strTemp = arrBuf(0)
        dLv = strTemp.Substring(2, strTemp.Length - 2)

        'x : CIE x
        strTemp = arrBuf(1)
        strTemp = strTemp.TrimStart(" ")
        dx = strTemp.Substring(2, strTemp.Length - 2)

        'y : CIE y
        strTemp = arrBuf(2)
        strTemp = strTemp.TrimStart(" ")
        dy = strTemp.Substring(2, strTemp.Length - 2)

        'Measurement Status
        strTemp = arrBuf(3)
        strTemp = strTemp.TrimStart(" ")
        measurementStatus = strTemp.Substring(2, strTemp.Length - 2)

        'Wavelength &   Intensisy
        arrBuf = Split(strWavelengthData, ",", -1)
        Dim nWavelength_Start As Integer = CDbl(arrBuf(0))
        Dim nWavelength_End As Integer = CDbl(arrBuf(1))
        Dim nWavelength_Step As Integer = CDbl(arrBuf(2))
        Dim numOfWavelength As Integer = (nWavelength_End - nWavelength_Start) + 1

        Dim nWavelength(numOfWavelength - 1) As Integer
        Dim dIntensity(numOfWavelength - 1) As Double

        strIntensityData = strIntensityData.TrimEnd(",")
        arrBuf = Split(strIntensityData, ",", -1)

        For i As Integer = 0 To numOfWavelength - 1
            nWavelength(i) = nWavelength_Start + (i * nWavelength_Step)
            dIntensity(i) = CDbl(arrBuf(i))
        Next

        Dim sParam As sColorCIEParam = CalculateCIEParam(dx, dy)

        With m_Data.D1
            .Comn.i0MeasQCode = measurementStatus
            .s2YY = dLv
            .s3xx = dx
            .s4yy = dy
        End With

        With m_Data.D4
            .Comn.i0MeasQCode = measurementStatus
            .s2YY = dLv
            .s3KelvinT = sParam.CCT
        End With

        With m_Data.D5
            .Comn.i0MeasQCode = measurementStatus
            .i3nm = nWavelength.Clone
            .s4Intensity = dIntensity.Clone
            .iMax = dIntensity.Max
        End With

        With m_Data.D6
            .Comn.i0MeasQCode = measurementStatus
            .s2YY = dLv
            .s3xx = dx
            .s4yy = dy
            .s5uu = sParam.CIE1976_ud
            .s6vv = sParam.CIE1976_vd
        End With

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

        Dim strData() As String = Nothing

        With m_Data.D2
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2XX = 0
            .s3YY = 0
            .s4ZZ = 0
            DivideAndGetEachData(In_strReceived, m_Data.D2.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
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

        Dim strData() As String = Nothing

        With m_Data.D3
            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3uu = 0
            .s4vv = 0
            DivideAndGetEachData(In_strReceived, m_Data.D3.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
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

        Dim strData() As String = Nothing

        With m_Data.D4

            .Comn.i0MeasQCode = eTransferState.eReciveFail_TimeOut
            .s2YY = 0
            .s3KelvinT = 0
            .s4DevOfColorCoord = 0

            DivideAndGetEachData(In_strReceived, m_Data.D4.Comn.strDivider, strData)

            .Comn.i0MeasQCode = CInt(strData(0))
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

End Class
