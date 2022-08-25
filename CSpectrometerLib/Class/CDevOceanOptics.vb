'Imports OmniDriver
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.VisualBasic
Public Class CDevOceanOptics
    Inherits CDevSpectrometerCommonNode

#Region "Defines"
    Private m_Data As tData        'CDevSpectrometerCommonNode에 정의
    ' Private wrapper As CCoWrapper
    Dim Omni As OmniDriverDLL.OmniDLL = New OmniDriverDLL.OmniDLL
    ' Dim Omni As OmniDriver.Omnidriver = New OmniDriver.Omnidriver
    Private Handler As Long
    Private nSpectrometer As Integer
    Private Pixel As Integer
    Private Name As String
    Private SerialNumber As String
    Private steradian As Double
    Private sphereDiameter As Double = 3.3 * 25.4
    Private FibercoreDiameter As Double = 0.6
    Private NA As Double = 0.22


#End Region

#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_OceanOptics
        'wrapper = New CCoWrapper


    End Sub
#End Region

#Region "Enum"
    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eTrigger
        eNormal
        eSoftware
        eSynchronization
        eHardware
        eSingleShot
    End Enum

#End Region

#Region "Communication"
    Public Overrides Function Connection() As Boolean

    
        Try
            Dim numberOfSpectrometers As Integer
            Dim m_Pixel As Integer = 0
            Dim s_Name As String = ""
            Dim s_Serial As String = ""

            If Omni.openAllSpectrometers(Handler, numberOfSpectrometers) = True Then
                If numberOfSpectrometers = -1 Then
                    m_bIsConnected = False
                    Return False
                ElseIf numberOfSpectrometers = 0 Then
                    MsgBox("No spectrometers were found.")
                    m_bIsConnected = False
                    Return False
                Else
                    nSpectrometer = numberOfSpectrometers - 1
                End If

                'If GetNameOfSpectrometer(nSpectrometer, s_Name) = False Then Return False
                'Name = s_Name
                If GetSerialNumber(nSpectrometer, s_Serial) = False Then Return False
                SerialNumber = s_Serial
                If GetNumberOfPixels(nSpectrometer, m_Pixel) = False Then Return False
                Pixel = m_Pixel

                steradian = Math.PI * (Math.Tan(Math.Asin(NA) * 180 / Math.PI) * sphereDiameter + (FibercoreDiameter / 2)) ^ 2 * 0.01 * 2 * 10 ^ -3
                steradian = 1 / steradian
            Else
                m_bIsConnected = False
                Return False
            End If
        Catch ex As Exception

        End Try

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        Try
            Omni.closeSpectrometers(Handler)
            ' wrapper.closeAllSpectrometers()
            m_bIsConnected = False
        Catch ex As Exception

        End Try
    End Sub

#End Region


#Region "API Functions"

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean

        If SetIntegrationTime(nSpectrometer, sInfos.MeasSpeedValue) = False Then Return False
        If SetScanToAverage(nSpectrometer, sInfos.NumOfAverage) = False Then Return False
        If SetBoxCarWidth(nSpectrometer, 1) = False Then Return False
        If SetCorrectForElectricalDark(nSpectrometer, 0) = False Then Return False
        If SetCorrectForDetectorNonlinearity(nSpectrometer, 0) = False Then Return False
        If SetExternalTriggerMode(nSpectrometer, eTrigger.eNormal) = False Then Return False
        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        If GetIntegrationTime(nSpectrometer, sInfos.MeasSpeedValue) = False Then Return False

        Return True
    End Function

    Public Overrides Function DarkMeasure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim dData() As Double = Nothing
        Dim dDataLamda() As Double = Nothing

        If SetStrobeEnable(nSpectrometer, 0) = False Then Return False

        If GetSpectrum(nSpectrometer, dData) = False Then Return False

        If GetWavelength(nSpectrometer, dDataLamda) = False Then Return False

        m_Data.D7.s2DarkScope = dData.Clone
        m_Data.D7.i3nm = dDataLamda.Clone

        outData = m_Data
        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim m_Lamda() As Double = Nothing
        Dim m_Intensity() As Double = Nothing

        If SetStrobeEnable(nSpectrometer, 1) = False Then Return False

        If GetIntensity(m_Lamda, m_Intensity) = False Then Return False

        If GetMeasData(m_Lamda, m_Intensity) = False Then Return False

        outData = m_Data
        Return True
    End Function
#End Region
#Region "Functions"

    Public Function GetIntensity(ByRef m_Lamda() As Double, ByRef m_Intensity() As Double) As Boolean
        Dim i As Integer = 0
        Dim l_Res As Integer = 0
        Dim line As String = 0
        Dim m_pScopeda() As Double = Nothing
        Dim m_pLamda() As Double = Nothing
        Dim NodataFit(,) As Double
        Dim CaldataFit(,) As Double
        Dim xdata1(Pixel - 1) As Double '파장데이타
        Dim ydata1(Pixel - 1) As Double '측정데이타
        Dim Nodata1(Pixel - 1) As Double '노이즈 데이타
        Dim Nodata2(Pixel - 1) As Double '노이즈 데이타
        Dim Caldata1(Pixel - 1) As Double
        Dim Caldata2(Pixel - 1) As Double
        '     Dim m_CalibrationFactor As CCoIrradianceCalibrationFactor
        Dim nIntegrationTime As Integer
        Dim Trans(Pixel - 1) As Double


        '     m_CalibrationFactor = Omni.getFeatureControllerIrradianceCalibrationFactor(nSpectrometer)

        Omni.GetIntegrationTime(Handler, nSpectrometer, nIntegrationTime)
        m_Data.GetInfo.nExposureTime = nIntegrationTime / 1000

        Nodata1 = m_Data.D7.i3nm.Clone
        Nodata2 = m_Data.D7.s2DarkScope.Clone

        NodataFit = (AverageData1_1(Nodata1, Nodata2))

        If GetWavelength(nSpectrometer, m_pLamda) = False Then Return False

        If GetSpectrum(nSpectrometer, m_pScopeda) = False Then
            MsgBox("Measurement Error")
            Return False
        End If

        xdata1 = m_pLamda.Clone
        ydata1 = m_pScopeda.Clone

        Caldata1 = m_pLamda.Clone
        Caldata2 = m_Data.D8.s2IrradCalFactor.Clone
        CaldataFit = AverageData1_1(Caldata1, Caldata2)

        Trans = m_Data.D8.s4Transferfunction.Clone

        Dim ReValue(,) As Double
        ReValue = AverageData1_1(xdata1, ydata1)
        For i = 0 To UBound(ReValue, 2)

            ReDim Preserve m_Intensity(i)
            ReDim Preserve m_Lamda(i)
            m_Lamda(i) = ReValue(0, i)
            ' m_Intensity(i) = (291 / m_Data.GetInfo.nExposureTime) * ((ReValue(1, i) - NodataFit(1, i)) * CaldataFit(1, i) * (10 ^ 3))

            '291 : Calibration 당시 Integtime ( 데이터 측정 후, 분석한 값 (정확하지 않을 수 있음)
            If (ReValue(1, i) - NodataFit(1, i)) * CaldataFit(1, i) * Trans(i) < 0 Then
                m_Intensity(i) = 0
            Else
                '    m_Intensity(i) = (291 / m_Data.GetInfo.nExposureTime) * ((ReValue(1, i) - NodataFit(1, i)) * CaldataFit(1, i)) * (10 ^ 3)
                m_Intensity(i) = (1200 / m_Data.GetInfo.nExposureTime) * ((ReValue(1, i) - NodataFit(1, i)) * CaldataFit(1, i)) * (10 ^ 6) * 0.00021 * Trans(i) * steradian
            End If
        Next


        m_Lamda = m_Lamda.Clone
        m_Intensity = m_Intensity.Clone
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

        SumX1 = SumX1 * 683.002
        SumY1 = SumY1 * 683.002
        SumZ1 = SumZ1 * 683.002


        For i = 0 To Wlengthdata.Length - 1
            If Intensitydata(i) > PeakVal Then
                PeakLength = Wlengthdata(i)
                PeakVal = Intensitydata(i)
            End If
        Next

        Luminance = (SumY1)

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

        '  CRICalculation(Intensitydata, dCRI)

        m_Data.D1.s3xx = Format(Sumx2, "#0.000")
        m_Data.D1.s4yy = Format(Sumy2, "#0.000")
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
        m_Data.D5.iMax = PeakLength
        m_Data.D5.s2IntegIntensity = Format(Radiance, "0.000E-0")
        m_Data.D5.s4Intensity = Intensitydata.Clone

        ReDim nWlengthdata(Wlengthdata.Length - 1)
        For i As Integer = 0 To Wlengthdata.Length - 1
            nWlengthdata(i) = CInt(Wlengthdata(i))
        Next
        m_Data.D5.i3nm = nWlengthdata.Clone
        Return True
        Return True
    End Function

    Function AverageData1_1(ByVal m_pLambda() As Double, ByVal l_pSpectrum() As Double) As Double(,)
        Dim ReturnValue(1, 1) As Double
        Try
            Dim i, j, k As Integer
            Dim Startj As Integer = 0

            k = 0
            For i = 380 To 780
                For j = Startj To m_pLambda.Length - 2

                    If m_pLambda(j) < CType(i, Double) And m_pLambda(j + 1) > CType(i, Double) Then
                        ReDim Preserve ReturnValue(1, k)
                        ReturnValue(0, k) = Fix(m_pLambda(j) + 1)
                        ReturnValue(1, k) = ((l_pSpectrum(j + 1) - l_pSpectrum(j)) / (m_pLambda(j + 1) - m_pLambda(j))) * (CType(i, Double) - m_pLambda(j)) + l_pSpectrum(j)

                        k = k + 1
                        Startj = j
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
        Return ReturnValue
    End Function

    Public Function GetNameOfSpectrometer(ByVal nSpectrometer As Integer, ByRef sName As String) As Boolean

        Try
            If Omni.GetNameOfSpectrometer(Handler, nSpectrometer, sName) = False Then Return False
            '  sName = VBStrFromAnsiPtr(lName)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetSerialNumber(ByVal nSpectrometer As Integer, ByRef sSerialNumber As String) As Boolean
        Try
            If Omni.GetSerialNumber(Handler, nSpectrometer, sSerialNumber) = False Then Return False
            '  sSerialNumber = wrapper.getSerialNumber(nSpectrometer)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetNumberOfPixels(ByVal nSpectrometer As Integer, ByRef nPixel As Integer) As Boolean
        Try
            If Omni.GetNumberOfPixels(Handler, nSpectrometer, nPixel) = False Then Return False
            '    nPixel = wrapper.getNumberOfPixels(nSpectrometer)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetIntegrationTime(ByVal nSpectrometer As Integer, ByVal nIntegtime As Integer) As Boolean
        Dim nSetIntegtime As Integer = nIntegtime * 1000
        Try
            If Omni.SetIntegrationTime(Handler, nSpectrometer, nSetIntegtime) = False Then Return False
            'wrapper.setIntegrationTime(nSpectrometer, nSetIntegtime)
            'Integration Time = microseconds
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetIntegrationTime(ByVal nSpectrometer As Integer, ByRef nIntegtime As Integer) As Boolean
        Dim nGetIntegtime As Integer
        Try
            If Omni.GetIntegrationTime(Handler, nSpectrometer, nGetIntegtime) = False Then Return False
            '   nGetIntegtime = wrapper.getIntegrationTime(nSpectrometer)
            nIntegtime = nGetIntegtime / 1000
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetSpectrum(ByVal nSpectrometer As Integer, ByRef dData() As Double) As Boolean
        Dim dPixelData() As Double = Nothing
        Try
            Application.DoEvents()
            If Omni.GetSpectrum(Handler, nSpectrometer, dPixelData) = False Then Return False

            ' dPixelData = wrapper.getSpectrum(nSpectrometer)
            dData = dPixelData.Clone
        Catch ex As Exception
            Return False
        End Try
        dData = dPixelData.Clone
        Return True
    End Function

    Public Function GetWavelength(ByVal nSpectrometer As Integer, ByRef dData() As Double) As Boolean
        Dim dWavelength() As Double = Nothing
        Try
            Application.DoEvents()
            If Omni.GetWavelength(Handler, nSpectrometer, dWavelength) = False Then Return False
            ' dWavelength = wrapper.getWavelengths(nSpectrometer)
            dData = dWavelength.Clone
        Catch ex As Exception
            Return False
        End Try
        dData = dWavelength.Clone
        Return True
    End Function

    Public Function SetScanToAverage(ByVal nSpectrometer As Integer, ByVal nAverage As Integer) As Boolean
        Try
            If Omni.SetScanToAverage(Handler, nSpectrometer, nAverage) = False Then Return False
            '   wrapper.setScansToAverage(nSpectrometer, nAverage)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetAutoToggleStrobeLamp(ByVal nSpectrometer As Integer, ByVal bEnable As Boolean) As Boolean
        Try
            If Omni.SetAutoToggleStrobeLamp(Handler, nSpectrometer, bEnable) = False Then Return False
            ' wrapper.setAutoToggleStrobeLampEnable(nSpectrometer, bEnable)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetBoxCarWidth(ByVal nSpectrometer As Integer, ByVal nWidth As Integer) As Boolean
        Try
            If Omni.SetBoXCarWidth(Handler, nSpectrometer, nWidth) = False Then Return False
            ' wrapper.setBoxcarWidth(nSpectrometer, nWidth)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetCorrectForDetectorNonlinearity(ByVal nSpectrometer As Integer, ByVal bEnable As Boolean) As Boolean
        Try
            If Omni.SetCorrectForDetectorNonlinearity(Handler, nSpectrometer, bEnable) = False Then Return False
            '  wrapper.setCorrectForDetectorNonlinearity(nSpectrometer, bEnable)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetCorrectForElectricalDark(ByVal nSpectrometer As Integer, ByVal bEnable As Boolean) As Boolean
        Try
            If Omni.SetCorrectForElectricalDark(Handler, nSpectrometer, bEnable) = False Then Return False
            ' wrapper.setCorrectForElectricalDark(nSpectrometer, bEnable)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetStrobeEnable(ByVal nSpectrometer As Integer, ByVal bEnable As Boolean) As Boolean
        Try
            If Omni.SetStrobeEnable(Handler, nSpectrometer, bEnable) = False Then Return False
            '   wrapper.setStrobeEnable(nSpectrometer, bEnable)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetExternalTriggerMode(ByVal nSpectrometer As Integer, ByVal mode As eTrigger) As Boolean
        Try
            If Omni.SetExternalTriggerMode(Handler, nSpectrometer, mode) = False Then Return False
            'wrapper.setExternalTriggerMode(nSpectrometer, mode)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overrides Function LoadIrradianceFactor(ByVal factor() As Double, ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Try
            m_Data.D8.s2IrradCalFactor = factor.Clone

            outData = m_Data
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overrides Function LoadTransferfunction(dData() As Double, ByRef outdata As CDevSpectrometerCommonNode.tData) As Boolean
        Try
            m_Data.D8.s4Transferfunction = dData.Clone
            outdata = m_Data
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region

    Private Function s_Serialw() As String
        Throw New NotImplementedException
    End Function

End Class
