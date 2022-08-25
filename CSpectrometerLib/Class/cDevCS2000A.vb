Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms
Imports CS2000Cal
Imports CS2000SDK_AutoMeas





''calibration Factor 적용
' 1) Closeup Lense 미사용 시, standard Calibration Factor 적용만 하면됨
' 2) Closeup Lense 사용 시, Closeup Lense 사용 Factor 적용 후 Standard Calibration 재적용 필요
' 절차
' - CS-S210w S/W 필요(코니카 미놀타 Driver 설치용,Lock-key 필요(업체 대여)
' - CS-S210W 장치 연결 후, Instrument-User Calibration 선택
' - Lens Calibraiton에 Closeup 선택 후, Write 버튼을 눌러 Closeup 렌즈에 동봉되어 있는 Cal.File(.LCF) 불러서 CS-2000A로 Write
' - Instrument-Instrument Setting에 Closeup Lense 선택 OR SetClsUpLensCondition(Short) Function으로 모드 선택
' - GetCalibrationData Function으로 Calibration Factor Read (경로 C\CS2000\장치Serial 폴더내 생성)
' - 완료

Public Class cDevCS2000A
    Inherits CDevSpectrometerCommonNode

    Public cs2000A As CS2000CalClass
    Public cs2000Auto As CS2000SDK_AutoClass
    Dim m_Port As String

#Region "Creator, Disposer, Init"

    Public Sub New()

        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_CS2000A
        cs2000A = New CS2000CalClass
        cs2000Auto = New CS2000SDK_AutoClass
    End Sub

#End Region

    Public Structure sMeasureData
        Dim dSpectrum() As Single
        Dim dColor() As Single
        Dim dLevel As Single
    End Structure

#Region "Enum"

    Public Enum eMeasureMode
        _Auto
        _Manual
    End Enum

    Enum ePORT_STATE
        _CLOSE = 0
        _OPEN
    End Enum

    Enum ePORT_RETURN
        _COMPLETE_NORMALLY = 0
        _THE_PROFREADING_DATE_AND_TIME_DO_NOT_ACCORD = 20
        _PARAMETER_DOES_NOT_CORRECT = -1
        _CONNECTION_IS_NOT_CORRECT = -2
        _PORT_OPEN_DO_NOT_FAILED = -3
        _TEH_SERIAL_NUMBER_OF_CONNECTED_CS2000A_DOES_NOT_CORRECT = -100
        _THERE_IS_NOT_KEY_FILE = -101
    End Enum

    Enum eND_CONDITION
        _OUT = 0
        _IN
    End Enum

    Enum eND_CONDITION_RETURN
        _COMPLETED_NORMALLY = 0
        _PARAMETER_ERR = -1
        _CONNECTION_IS_NOT_COMPLETE = -2
    End Enum

    Enum eFS_CONDITION
        _OPEN = 0
        _CLOSE
    End Enum

    Enum eFS_CONDITION_RETURN
        _COMPLETED_NORMALLY = 0
        _PARAMETER_ERR = -1
        _CONNECTION_IS_NOT_COMPLETE = -2
    End Enum

    Enum eUSERCAL_CONDITION
        _DO_NOT_THE_USER_CALIBRATION = 0
        _DO_THE_USER_CALIBRATION_01
        _DO_THE_USER_CALIBRATION_02
        _DO_THE_USER_CALIBRATION_03
        _DO_THE_USER_CALIBRATION_04
        _DO_THE_USER_CALIBRATION_05
        _DO_THE_USER_CALIBRATION_06
        _DO_THE_USER_CALIBRATION_07
        _DO_THE_USER_CALIBRATION_08
        _DO_THE_USER_CALIBRATION_09
        _DO_THE_USER_CALIBRATION_10
    End Enum

    Enum eUSERCAL_CONDITION_RETURN
        _COMPLETED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -2
        _THE_CALIBRATION_DATA_DO_NOT_EXIST = -5
    End Enum

    Enum eOPTIONAL_ND_CONDITION
        _DO_NOT_OPTIONAL_ND = 0
        _USER_THE_ND_01
        _USER_THE_ND_02
    End Enum

    Enum eOPTIONAL_ND_CONDITION_RETURN
        _COMPLETED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -2
        _THE_CALIBRATION_DATA_DO_NOT_EXIST = -5
        _FLASH_MEMORY_ERR = -30
    End Enum

    Enum eCLSUP_LENS_CONDITION
        _DO_NOT_CLOSEUP_LENS = 0
        _SET_THE_CLOSEUP_LENS
    End Enum

    Enum eCLSUP_LENS_CONDITION_RETURN
        _COMPLETED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -2
        _THE_CALIBRATION_DATA_DO_NOT_EXIST = -5
        _FLASH_MEMORY_ERR = -30
    End Enum

    Enum eDARK_TYPE
        _USE_THE_DARK_DATA_OF_DARKMEASUREMENT_FUNCTION = 0
        _USE_THE_DARK_DATA_OF_DARKMEASUREMENT_USING_A_EXPOSURE_TIME
    End Enum

    Enum eMEASURE_TYPE
        _XYZ = 0
        _xyLv
    End Enum

    Enum eMEASUREMENT_RETURN
        _COMPLETED_NORMALLY = 0
        _PARAMETER_DOES_NOT_CORRET = -1
        _CONNECTION_IS_NOT_COMPLETE = -2
        _MEASUREMENT_CALCULRATION_FAILED = -10
        _CALIBRATION_DATA_DOES_NOT_EXIST = -20
        _DARK_DATA_DOES_NOT_EXIST = -21
        _DO_NOT_MEASUREMENT_TOO_DARK = -90
        _DO_NOT_MEASUREMENT_TOO_BRIGHT = -91
    End Enum

    Enum eDARK_MEASURE_RETURN
        _COMPLETE_NORMALLY = 0
        _COMPLETE_IS_NOT_COMPLETE = -2
    End Enum

    Enum eGET_CALDATA_RETURN
        _COMPLETEED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -1
        _SERIAL_NUMBER_DOES_NOT_EXIST = -4
    End Enum

    Enum eSET_CALDATA_RETURN
        _COMPLETEED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -1
    End Enum

    Enum eCOM_RETURN
        _COMPLETEED_NORMALLY = 0
        _CONNECTION_IS_NOT_COMPLETE = -2
    End Enum


#Region "Propertys"

#End Region

#End Region
    
    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim retData As Short

        m_bIsConnected = False
        m_Port = Config.sSerialInfo.sPortName

        retData = cs2000A.ConnectInstrument(ePORT_STATE._OPEN, m_Port)

        Application.DoEvents()
        Thread.Sleep(10)

        If retData = eCOM_RETURN._CONNECTION_IS_NOT_COMPLETE Then
            'MsgBox("Connection Failure" & "(" & retData & ")")
            Return False
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If InitializeDevice() = False Then Return False

        m_bIsConnected = True

        Return True
    End Function

    Public Overrides Sub Disconnection()
        cs2000A.ConnectInstrument(ePORT_STATE._CLOSE, m_Port)

        Application.DoEvents()
        Thread.Sleep(10)

        m_bIsConnected = False
    End Sub

    Public Function InitializeDevice() As Boolean
        Dim retData As Short

        If m_bCalRead = True Then

            retData = cs2000A.GetCalibrationData()

            Application.DoEvents()
            Thread.Sleep(10)

            If retData <> 0 Then Return False
        End If

        retData = cs2000A.SetCalibrationData()

        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> 0 Then Return False

        retData = cs2000A.SetClsUpLensCondition(1)

        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> 0 Then Return False


        'retData = cs2000A.DarkMeasurement()
        'Application.DoEvents()
        'Thread.Sleep(10)
        Return True
    End Function

#Region "API Functions"
    Public Overrides Function Measure(ByVal measMode As eMeasureMode, ByRef outData As tData, ByRef ErrorCode As Short) As Boolean
        Dim retData As Short
        Dim measType As eMEASURE_TYPE
        Dim sMeasData As sMeasureData

        Dim nRetExposureTime As Integer = 0

      
        ReDim sMeasData.dSpectrum(400)
        ReDim sMeasData.dColor(2)

        measType = eMEASURE_TYPE._XYZ

        If measMode = eMeasureMode._Auto Then
            retData = cs2000A.DarkMeasurement()
            Application.DoEvents()
            Thread.Sleep(10)

            If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then Return False

            retData = cs2000Auto.AutoMeasurement(cs2000A, nRetExposureTime, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel, 60, measType, 2)

        ElseIf measMode = eMeasureMode._Manual Then

            retData = cs2000A.SetFSCondition(eFS_CONDITION._CLOSE)

            Application.DoEvents()
            Thread.Sleep(10)

            If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then Return False

            retData = cs2000A.DarkMeasurement()
            Application.DoEvents()
            Thread.Sleep(10)

            If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then Return False

            retData = cs2000A.DoMeasurement(m_nExposureTime, eDARK_TYPE._USE_THE_DARK_DATA_OF_DARKMEASUREMENT_USING_A_EXPOSURE_TIME, measType, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel)

            If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then Return False

            retData = cs2000A.SetFSCondition(eFS_CONDITION._OPEN)
        End If

        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then
            ErrorCode = retData
            Return False
        End If

        outData.IntegrationTime = CDbl(nRetExposureTime)

        outData.D2.s2XX = sMeasData.dColor(0)
        outData.D2.s3YY = sMeasData.dColor(1)
        outData.D2.s4ZZ = sMeasData.dColor(2)
        outData.D6.s2YY = sMeasData.dColor(1)

        Dim SumX1 As Double = outData.D2.s2XX
        Dim SumY1 As Double = outData.D2.s3YY
        Dim SumZ1 As Double = outData.D2.s4ZZ
        Dim Sumx2 As Double
        Dim Sumy2 As Double
        Dim Sumz2 As Double
        Dim Pvalue As Double
        Dim CTemp As Double
        Dim Luminance As Double = 0
        Dim PeakVal As Double
        Dim PeakLength As Integer

        ReDim outData.D5.s4Intensity(400)
        ReDim outData.D5.i3nm(400)

        For idx As Integer = 0 To sMeasData.dSpectrum.Length - 1
            outData.D5.i3nm(idx) = 380 + idx
            outData.D5.s4Intensity(idx) = CDbl(sMeasData.dSpectrum(idx))
        Next

        Luminance = (SumY1)
        Sumx2 = SumX1 / (SumX1 + SumY1 + SumZ1)
        Sumy2 = SumY1 / (SumX1 + SumY1 + SumZ1)
        Sumz2 = 1 - (Sumx2 + Sumy2)

        Pvalue = (Sumx2 - 0.332) / (Sumy2 - 0.1858)
        CTemp = 5520.33 - (6823.3 * Pvalue) + (3525 * Pvalue * Pvalue) - (449 * Pvalue * Pvalue * Pvalue)

        Dim dn As Double
        dn = (-2 * Sumx2 + 12 * Sumy2 + 3)
        If dn = 0.0 Then
            dn = 1
        End If

        For i As Integer = 0 To outData.D5.i3nm.Length - 1
            If outData.D5.s4Intensity(i) > PeakVal Then
                PeakLength = outData.D5.i3nm(i)
                PeakVal = outData.D5.s4Intensity(i)
            End If
        Next

        outData.D5.iMax = PeakLength
        outData.D5.nMaxIntensity = PeakVal

        outData.D1.s3xx = Sumx2 'Format(Sumx2, "#0.000")
        outData.D1.s4yy = Sumy2 'Format(Sumy2, "#0.000")
        outData.D3.s3uu = 4 * Sumx2 / dn 'Format(4 * Sumx2 / dn, "#0.000")
        outData.D3.s4vv = 6 * Sumy2 / dn * (3 / 2) 'Format(6 * Sumy2 / dn * (3 / 2), "#0.000")
        outData.D2.s2XX = SumX1 ' Format(SumX1, "#0.00")
        outData.D2.s3YY = SumY1 'Format(SumY1, "#0.00")
        outData.D2.s4ZZ = SumZ1 ' Format(SumZ1, "#0.00")
        outData.D4.s3KelvinT = CTemp 'Format(CTemp, "#0")
        outData.D1.s2YY = Format(Luminance, "#0.00000")
        outData.D3.s2YY = Format(Luminance, "#0.00000")
        outData.D4.s2YY = Format(Luminance, "#0.00000")
        outData.D6.s2YY = Format(Luminance, "#0.00000")
        outData.D6.s3xx = Sumx2 ' Format(Sumx2, "#0.000")
        outData.D6.s4yy = Sumy2 'Format(Sumy2, "#0.000")
        outData.D6.s5uu = 4 * Sumx2 / dn 'Format(4 * Sumx2 / dn, "#0.000")
        outData.D6.s6vv = 6 * Sumy2 / dn * (3 / 2) 'Format(6 * Sumy2 / dn * (3 / 2), "#0.000")

        Return True
    End Function
    'Public Overrides Function Measure(ByVal measMode As eMeasureMode, ByRef outData As tData, ByRef ErrorCode As Short) As Boolean
    '    Dim retData As Short
    '    Dim measType As eMEASURE_TYPE
    '    Dim sMeasData As sMeasureData

    '    Dim nRetExposureTime As Integer

    '    retData = cs2000A.SetFSCondition(eFS_CONDITION._CLOSE)

    '    Application.DoEvents()
    '    Thread.Sleep(10)

    '    If retData <> 0 Then Return False

    '    retData = cs2000A.DarkMeasurement()
    '    Application.DoEvents()
    '    Thread.Sleep(10)

    '    If retData <> 0 Then Return False
    '    'If measMode = eMeasureMode._Manual Then
    '    '    retData = cs2000A.DarkMeasurement()
    '    '    Application.DoEvents()
    '    '    Thread.Sleep(10)

    '    '    If retData <> 0 Then Return False
    '    'End If

    '    ReDim sMeasData.dSpectrum(400)
    '    ReDim sMeasData.dColor(2)

    '    measType = eMEASURE_TYPE._XYZ

    '    If measMode = eMeasureMode._Auto Then
    '        retData = cs2000Auto.AutoMeasurement(cs2000A, nRetExposureTime, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel, 60, measType, 2)
    '    ElseIf measMode = eMeasureMode._Manual Then
    '        retData = cs2000A.DoMeasurement(m_nExposureTime, eDARK_TYPE._USE_THE_DARK_DATA_OF_DARKMEASUREMENT_USING_A_EXPOSURE_TIME, measType, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel)
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(10)

    '    If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then
    '        ErrorCode = retData
    '        Return False
    '    End If

    '    outData.IntegrationTime = CDbl(nRetExposureTime)
    '    outData.D6.s2YY = sMeasData.dColor(1)
    '    outData.D2.s2XX = sMeasData.dColor(0)
    '    outData.D2.s3YY = sMeasData.dColor(1)
    '    outData.D2.s4ZZ = sMeasData.dColor(2)

    '    ReDim outData.D5.s4Intensity(400)
    '    ReDim outData.D5.i3nm(400)

    '    For idx As Integer = 0 To sMeasData.dSpectrum.Length - 1
    '        outData.D5.i3nm(idx) = 380 + idx
    '        outData.D5.s4Intensity(idx) = CDbl(sMeasData.dSpectrum(idx))
    '    Next
    '    'outData.D5.s4Intensity = sMeasData.dSpectrum.Clone

    '    measType = eMEASURE_TYPE._xyLv

    '    If measMode = eMeasureMode._Manual Then
    '        retData = cs2000A.DarkMeasurement()
    '        Application.DoEvents()
    '        Thread.Sleep(10)

    '        If retData <> 0 Then Return False
    '    End If

    '    If measMode = eMeasureMode._Auto Then
    '        retData = cs2000Auto.AutoMeasurement(cs2000A, nRetExposureTime, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel, 60, measType, 2)
    '    ElseIf measMode = eMeasureMode._Manual Then
    '        retData = cs2000A.DoMeasurement(m_nExposureTime, eDARK_TYPE._USE_THE_DARK_DATA_OF_DARKMEASUREMENT_USING_A_EXPOSURE_TIME, measType, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel)
    '    End If

    '    Application.DoEvents()
    '    Thread.Sleep(10)

    '    If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then
    '        ErrorCode = retData
    '        Return False
    '    End If

    '    outData.D1.s3xx = sMeasData.dColor(0)
    '    outData.D1.s4yy = sMeasData.dColor(1)
    '    outData.D6.s3xx = sMeasData.dColor(0)
    '    outData.D6.s4yy = sMeasData.dColor(1)

    '    retData = cs2000A.SetFSCondition(eFS_CONDITION._OPEN)


    '    Dim SumX1 As Double = outData.D2.s2XX
    '    Dim SumY1 As Double = outData.D2.s3YY
    '    Dim SumZ1 As Double = outData.D2.s4ZZ
    '    Dim Sumx2 As Double
    '    Dim Sumy2 As Double
    '    Dim Sumz2 As Double
    '    Dim Pvalue As Double
    '    Dim CTemp As Double

    '    Sumx2 = SumX1 / (SumX1 + SumY1 + SumZ1)
    '    Sumy2 = SumY1 / (SumX1 + SumY1 + SumZ1)
    '    Sumz2 = 1 - (Sumx2 + Sumy2)

    '    Pvalue = (Sumx2 - 0.332) / (Sumy2 - 0.1858)
    '    CTemp = 5520.33 - (6823.3 * Pvalue) + (3525 * Pvalue * Pvalue) - (449 * Pvalue * Pvalue * Pvalue)
    '    '    Luminousf = Illuminance * 0.0011468718473572638
    '    ' candela = Luminousf / Steredian
    '    ' Luminance = candela / 0.00140276977647 'Fiber 입사각 판별 후 적분구 입사각대비 평균 면적 산출(곱)

    '    Dim dn As Double
    '    dn = (-2 * Sumx2 + 12 * Sumy2 + 3)
    '    If dn = 0.0 Then
    '        dn = 1
    '    End If

    '    outData.D3.s3uu = Format(4 * Sumx2 / dn, "#0.000")
    '    outData.D3.s4vv = Format(6 * Sumy2 / dn * (3 / 2), "#0.000")
    '    outData.D6.s5uu = Format(4 * Sumx2 / dn, "#0.000")
    '    outData.D6.s6vv = Format(6 * Sumy2 / dn * (3 / 2), "#0.000")
    '    outData.D4.s3KelvinT = Format(CTemp, "#0")

    '    If retData <> 0 Then Return False

    '    Application.DoEvents()
    '    Thread.Sleep(10)

    '    Return True
    'End Function

    Public Overrides Function Measure(ByVal expTime As Integer, ByVal measType As eMEASURE_TYPE, ByRef sMeasData As sMeasureData) As Boolean
        Dim retData As Short

        retData = cs2000A.SetFSCondition(eFS_CONDITION._CLOSE)

        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> 0 Then Return False

        retData = cs2000A.DarkMeasurement()
        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> 0 Then Return False

        ReDim sMeasData.dSpectrum(400)
        ReDim sMeasData.dColor(2)

        retData = cs2000A.DoMeasurement(expTime, eDARK_TYPE._USE_THE_DARK_DATA_OF_DARKMEASUREMENT_FUNCTION, measType, sMeasData.dSpectrum, sMeasData.dColor, sMeasData.dLevel)

        Application.DoEvents()
        Thread.Sleep(10)

        If retData <> eMEASUREMENT_RETURN._COMPLETED_NORMALLY Then
            Return False
        End If

        retData = cs2000A.SetFSCondition(eFS_CONDITION._OPEN)

        If retData <> 0 Then Return False

        Application.DoEvents()
        Thread.Sleep(10)

        Return True
    End Function

#End Region



End Class
