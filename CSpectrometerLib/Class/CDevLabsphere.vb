Imports System.IO
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms
Imports System.Math
Imports Labsphere.SharedLibrary.HardwareDevices
Imports Labsphere.SharedLibrary.HardwareDevices.Spectrometers
Imports Labsphere.SharedLibrary.HardwareDevices.Spectrometers.OceanOpticsSpectrometers
Imports Labsphere.SharedLibrary.UtilityAndMathClasses
Imports Labsphere.SharedLibrary.UtilityAndMathClasses.ColorCalculations

Public Class CDevLabsphere
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI


#Region "Defines"

    Private objLabsphere As CDS1100_2100

    Private m_Data As tData
    Private m_LampFile As LambdaArray
    Private m_KCurve As LambdaArray
    Private m_SpectrumData As ScanData
    Private radArray As RadianceArray = New RadianceArray(RadianceArray.UnitsEnum.WattsPerMeterSquaredSteradianNanoMeter)
#End Region

#Region "Enum"
    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

#End Region

#Region "Structure"

#End Region

#Region "Property"

#End Region


#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_LABSPHERE
        objLabsphere = New CDS1100_2100("CDS1100_2100", 200, 850)
        objLabsphere.DarkCorrectionEnabled = True

        init()
    End Sub

    Public Sub init()
        Dim Lampdata As LambdaArray = Nothing
        Dim kcurvedata As LambdaArray = Nothing
        LampPowerCalData(Lampdata)

        m_LampFile = Lampdata

        K_CurveData(kcurvedata)

        m_KCurve = kcurvedata
    End Sub

#End Region

#Region "Communication"

    Public Overrides Function Connection() As Boolean
        If objLabsphere Is Nothing Then
            objLabsphere = New CDS1100_2100("CDS1100_2100", 200, 850)
        End If

        If objLabsphere.IsConnected = False Then
            objLabsphere.Connect()
            If objLabsphere.IsConnected = False Then
                m_bIsConnected = False
                Return False
            End If
        Else
            Return True
        End If
        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        '  If objLabsphere.IsConnected = True Then
        objLabsphere.Disconnect()
        m_bIsConnected = False
        '  End If
    End Sub
#End Region

#Region "API Functions"

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        If objLabsphere.InitiateAutoExposure() = False Then
            Return False
        End If

        While objLabsphere.AutoExposureInProgress
            Application.DoEvents()
        End While

        sInfo.NumOfAverage = objLabsphere.ScansToAverage
        sInfo.MeasSpeedValue = objLabsphere.GetIntegrationTime_mS
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Try
            objLabsphere.SetIntegrationTime_mS(sInfos.MeasSpeedValue)
            objLabsphere.ScansToAverage = sInfos.NumOfAverage

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        If m_bIsConnected = False Then Return False
        Try
            sInfos.MeasSpeedValue = objLabsphere.GetIntegrationTime_mS
            sInfos.NumOfAverage = objLabsphere.ScansToAverage
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim lamda() As Double = Nothing
        Dim intensity() As Double = Nothing

        If GetIntensity(lamda, intensity) = False Then Return False

        If GetMeasData(lamda, intensity) = False Then Return False

        outData = m_Data

        Return True
    End Function

    Public Overrides Function StartApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function EndApertureChange() As Boolean
        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Return True
    End Function

    Public Overrides Function DarkMeasure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim sData As ScanData = Nothing

        If objLabsphere.TakeDarkCorrectionScans = False Then
            Return False
            Exit Function
        Else
            While objLabsphere.DarkCorrectionScansInProgress
                Application.DoEvents()
            End While
            objLabsphere.DarkCorrectionEnabled = True

        End If
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function
#End Region

#Region "Functions"

    Public Function LampPowerCalData(ByRef lampdata As LambdaArray) As Boolean
        Dim calFilePath As String = Application.StartupPath & "\Data\Cal.txt"

        Dim startingWavelength As Double = 0
        Dim currentWavelength As Double = 0
        Dim line As String
        Dim bufData() As String = Nothing
        Dim sWaveLength() As String = Nothing
        Dim sLampCalFactor() As Double = Nothing
        Dim ncount As Integer = 0

        If File.Exists(calFilePath) = False Then
            MsgBox("Do not exist sample Cal file.")
            Return False
            Exit Function
        End If
        Try
            Using sr As StreamReader = New StreamReader(calFilePath)
                Dim previousWavelength As Double = 0
                Do
                    ReDim Preserve sWaveLength(ncount)
                    ReDim Preserve sLampCalFactor(ncount)

                    line = sr.ReadLine()
                    If line Is Nothing Then
                        ReDim Preserve sWaveLength(ncount - 1)
                        ReDim Preserve sLampCalFactor(ncount - 1)
                        Exit Do
                    End If
                    line = line.Trim()
                    If line = String.Empty Or line(0) = ";" Or line(0) = "[" Then
                    Else
                        bufData = line.Split("	")
                        sWaveLength(ncount) = bufData(0)
                        sLampCalFactor(ncount) = bufData(1)

                        ncount += 1
                    End If
                Loop Until line Is Nothing
                sr.Close()

            End Using

            lampdata = New LambdaArray(sWaveLength(0), sWaveLength(sWaveLength.Length - 1), 1, sLampCalFactor)

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function K_CurveData(ByRef kcurvedata As LambdaArray) As Boolean
        Dim k_curve As String = Application.StartupPath & "\Data\kCurve.txt"
        Dim startingWavelength As Double = 0
        Dim currentWavelength As Double = 0
        Dim line As String
        Dim bufData() As String = Nothing
        Dim sWaveLength() As String = Nothing
        Dim sK_CurveFactor() As Double = Nothing
        Dim ncount As Integer = 0

        If File.Exists(k_curve) = False Then
            MsgBox("Do not exist K_Curve Data")
            Return False
            Exit Function
        End If

        Try
            Using sr As StreamReader = New StreamReader(k_curve)
                Dim previousWavelength As Double = 0
                Do
                    ReDim Preserve sWaveLength(ncount)
                    ReDim Preserve sK_CurveFactor(ncount)

                    line = sr.ReadLine()
                    If line Is Nothing Then
                        ReDim Preserve sWaveLength(ncount - 1)
                        ReDim Preserve sK_CurveFactor(ncount - 1)
                        Exit Do
                    End If

                    line = line.Trim()

                    If line = String.Empty Or line(0) = ";" Or line(0) = "[" Then
                    Else
                        bufData = line.Split("	")
                        sWaveLength(ncount) = bufData(0)
                        sK_CurveFactor(ncount) = bufData(1)

                        ncount += 1
                    End If
                Loop Until line Is Nothing
                sr.Close()

            End Using

            kcurvedata = New LambdaArray(sWaveLength(0), sWaveLength(sWaveLength.Length - 1), 1, sK_CurveFactor)

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ProcessCalibration() As Boolean
        If m_bIsConnected = False Then Return False
        Dim sData As ScanData = m_SpectrumData
        Dim kCurveStart As Double = Math.Max(sData.Spectrum.StartLambda, m_LampFile.StartLambda)
        Dim kCurveEnd As Double = Math.Min(sData.Spectrum.EndLambda, m_LampFile.EndLambda)
        Dim filePath As String = Application.StartupPath & "\NewKCurve.txt"

        Try
            m_KCurve = New LambdaArray(kCurveStart, kCurveEnd, 1.0)

            For i As Double = kCurveStart To kCurveEnd
                m_KCurve(i) = sData.Spectrum(i) / (m_LampFile(i) * sData.IntegrationTime_mS)
            Next

            Dim writer As StreamWriter = New StreamWriter(filePath)
            For i As Double = m_KCurve.StartLambda To m_KCurve.EndLambda
                writer.WriteLine(i.ToString & "," & m_KCurve(i).ToString)
            Next

            writer.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetScopeData(ByRef m_LamdaData() As Double, ByRef m_ScopeData() As Double) As Boolean
        If m_bIsConnected = False Then Return False
        Dim sData As ScanData
        Try
            objLabsphere.RequestAveragedScan()

            While objLabsphere.TakeAveragedScanInProgress
                Application.DoEvents()
            End While

            sData = objLabsphere.LastScanData
            m_SpectrumData = sData

            ReDim m_LamdaData(sData.Spectrum.Length - 1)
            ReDim m_ScopeData(sData.Spectrum.Length - 1)

            For i As Integer = 0 To sData.Spectrum.Length - 1
                m_LamdaData(i) = sData.Spectrum.StartLambda + i
                m_ScopeData(i) = sData.Spectrum.Item(i)
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetIntensity(ByRef m_Lamda() As Double, ByRef m_Intensity() As Double) As Boolean
        If m_bIsConnected = False Then Return False
        Dim radianceValues() As Double = Nothing
        Dim IrrdianceIntensity() As Double = Nothing
        Dim m_LamdaData() As Double = Nothing
        Dim m_ScopeData() As Double = Nothing

        Dim kcurvedata As LambdaArray = Nothing
        Try
            If GetScopeData(m_ScopeData, m_LamdaData) = False Then
                Return False
                Exit Function
            End If

            radArray.SetCorrectedCounts(m_SpectrumData.Spectrum, m_SpectrumData.IntegrationTime_mS)

            If m_KCurve Is Nothing Then
                Return False
                Exit Function
            Else
                radArray.SensitivityCurve = m_KCurve
            End If

            Dim startWave As Integer = Math.Max(radArray.StartLambda, m_KCurve.StartLambda)
            Dim endWave As Integer = Math.Min(radArray.EndLambda, m_KCurve.EndLambda)

            ReDim radianceValues(400)
            ReDim IrrdianceIntensity(400)

            ReDim m_Lamda(400)
            For i As Integer = 0 To 400
                If radArray(i + startWave + 180).Radiance > 0 Then
                    radianceValues(i) = radArray(i + startWave + 180).Radiance
                    IrrdianceIntensity(i) = radArray(i + startWave + 180).Radiance * 12.56
                Else
                    radianceValues(i) = 0
                    IrrdianceIntensity(i) = 0
                End If
                m_Lamda(i) = startWave + i + 180
            Next

            m_Intensity = IrrdianceIntensity.Clone

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetMeasData(ByVal Wlengthdata() As Double, ByVal Intensitydata() As Double) As Boolean
        Dim SumX1 As Double
        Dim SumY1 As Double
        Dim SumZ1 As Double
        Dim Sumy2 As Double
        Dim Sumz2 As Double
        Dim Sumx2 As Double
        Dim Luminance As Double = 0
        Dim Radiance As Double
        Dim CTemp As Double
        Dim Pvalue As Double
        Dim dCRI As Double = 0
        Dim PeakVal As Double = 0
        Dim PeakLength As Double
        Dim nWlengthdata() As Integer = Nothing

        SumX1 = 0
        SumY1 = 0
        SumZ1 = 0

        ColorMatchingFuntions()

        Dim ColorCnt As Integer = 0

        For i = 0 To Wlengthdata.Length - 1
            If Wlengthdata(i) > 379 Then
                SumX1 = SumX1 + CMF(ColorCnt, 0) * (Intensitydata(i))
                SumY1 = SumY1 + CMF(ColorCnt, 1) * (Intensitydata(i))
                SumZ1 = SumZ1 + CMF(ColorCnt, 2) * (Intensitydata(i))
                Radiance = Radiance + Intensitydata(i)
                ColorCnt = ColorCnt + 1
                If ColorCnt >= 401 Then
                    Exit For
                End If
            End If
        Next

        For i = 0 To Wlengthdata.Length - 1

            If Intensitydata(i) > PeakVal Then
                PeakLength = Wlengthdata(i)
                PeakVal = Intensitydata(i)
            End If
        Next

        Luminance = (SumY1 * 683.002)

        Sumx2 = SumX1 / (SumX1 + SumY1 + SumZ1)
        Sumy2 = SumY1 / (SumX1 + SumY1 + SumZ1)
        Sumz2 = 1 - (Sumx2 + Sumy2)

        Pvalue = (Sumx2 - 0.332) / (Sumy2 - 0.1858)
        CTemp = 5520.33 - (6823.3 * Pvalue) + (3525 * Pvalue * Pvalue) - (449 * Pvalue * Pvalue * Pvalue)
        '    Luminousf = Illuminance * 0.0011468718473572638
        ' candela = Luminousf / Steredian
        ' Luminance = candela / 0.00140276977647 'Fiber 입사각 판별 후 적분구 입사각대비 평균 면적 산출(곱)

        Dim dn As Double
        dn = (-2 * Sumx2 + 12 * Sumy2 + 3)
        If dn = 0.0 Then
            dn = 1
        End If

        '    CRICalculation(Intensitydata, dCRI)

        m_Data.D1.s3xx = Format(Sumx2, "#0.000")
        m_Data.D1.s4yy = Format(Sumy2, "#0.000")
        '   g_MeasData.z_1931 = Format(Sumz2, "#0.000")
        '  g_MeasData.u_1960 = Format(4 * Sumx2 / dn, "#0.000")
        '  g_MeasData.v_1960 = Format(6 * Sumy2 / dn, "#0.000")
        m_Data.D3.s3uu = Format(4 * Sumx2 / dn, "#0.000")
        m_Data.D3.s4vv = Format(6 * Sumy2 / dn * (3 / 2), "#0.000")
        m_Data.D2.s2XX = Format(SumX1, "#0.00")
        m_Data.D2.s3YY = Format(SumY1, "#0.00")
        m_Data.D2.s4ZZ = Format(SumZ1, "#0.00")
        m_Data.D4.s3KelvinT = Format(CTemp, "#0")
        m_Data.D1.s2YY = Format(Luminance, "#0.00000")
        m_Data.D3.s2YY = Format(Luminance, "#0.00000")
        m_Data.D4.s2YY = Format(Luminance, "#0.00000")
        m_Data.D6.s2YY = Format(Luminance, "#0.00000")
        m_Data.D6.s3xx = Format(Sumx2, "#0.000")
        m_Data.D6.s4yy = Format(Sumy2, "#0.000")
        m_Data.D6.s5uu = Format(4 * Sumx2 / dn, "#0.000")
        m_Data.D6.s6vv = Format(6 * Sumy2 / dn * (3 / 2), "#0.000")
        'm_Data.D8.s3CRI = Format(dCRI, "0.0")
        'm_Data.D8.s2YY = Format(Luminance, "#0.00000")
        m_Data.D5.nMaxIntensity = Format(PeakVal, "0.00000")
        m_Data.D5.iMax = CInt(PeakLength)
        m_Data.D5.s2IntegIntensity = Format(Radiance, "0.000E-0")
        m_Data.D5.s4Intensity = Intensitydata.Clone
        m_Data.GetInfo.nAverage = objLabsphere.ScansToAverage
        m_Data.GetInfo.nExposureTime = objLabsphere.GetIntegrationTime_mS

        ReDim nWlengthdata(Wlengthdata.Length - 1)
        For i As Integer = 0 To Wlengthdata.Length - 1
            nWlengthdata(i) = CInt(Wlengthdata(i))
        Next
        m_Data.D5.i3nm = nWlengthdata.Clone
        Return True

    End Function

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function

#End Region
End Class
