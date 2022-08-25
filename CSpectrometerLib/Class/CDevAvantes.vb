Imports System.IO
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms
Imports System.IntPtr
Imports System.Math
Imports System.Runtime.InteropServices

Public Class CDevAvantes
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI

#Region "Defines"
    Private m_Data As tData        'CDevSpectrometerCommonNode에 정의
    Private m_DeviceHandle() As IntPtr
    Private objAvantesParameter() As DeviceConfigType
    Private m_StopScan As Integer = 0
    Private m_pLambda As PixelArrayType = New PixelArrayType
    Private m_pScopeda As PixelArrayType = New PixelArrayType
    Private m_NrPixels As UShort
    Private l_Active() As AvsIdentityType = Nothing

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

#Region "USB Command"
    Public Const WM_USER As Integer = &H400
    Public Const WM_MEAS_READY As Integer = WM_USER + 1
    Public Const WM_DBG_INFOAs As Integer = WM_USER + 2
    Public Const WM_DEVICE_RESET As Integer = WM_USER + 3

    Public Const USB_STATE_ATTACHED As Short = 0
    Public Const USB_STATE_DETACHED As Short = 1

    Public Const NR_FIT_COEF As Short = 5
    Public Const MAX_NR_CHANNELS As Short = 8
    Public Const MAX_NR_PIXELS_PER_CHANNEL As Short = 2048

    Public Const SUCCESS As Short = 0
    Public Const INVALID_PARAMETER As Short = -1
    Public Const INVALID_PIXEL_RANGE As Short = -2
    Public Const NO_INT_DELAY_SUPPORT As Short = -3

    ' Return error codes
    Public Const ERR_SUCCESS As Integer = 0
    Public Const ERR_INVALID_PARAMETER As Integer = -1
    Public Const ERR_OPERATION_NOT_SUPPORTED As Integer = -2
    Public Const ERR_DEVICE_NOT_FOUND As Integer = -3
    Public Const ERR_INVALID_DEVICE_ID As Integer = -4
    Public Const ERR_OPERATION_PENDING As Integer = -5
    Public Const ERR_TIMEOUT As Integer = -6
    Public Const ERR_INVALID_PASSWORD As Integer = -7
    Public Const ERR_INVALID_MEAS_DATA As Integer = -8
    Public Const ERR_INVALID_SIZE As Integer = -9
    Public Const ERR_INVALID_PIXEL_RANGE As Integer = -10
    Public Const ERR_INVALID_INT_TIME As Integer = -11
    Public Const ERR_INVALID_COMBINATION As Integer = -12
    Public Const ERR_INVALID_CONFIGURATION As Integer = -13
    Public Const ERR_NO_MEAS_BUFFER_AVAIL As Integer = -14
    Public Const ERR_UNKNOWN As Integer = -15
    Public Const ERR_COMMUNICATION As Integer = -16
    Public Const ERR_NO_SPECTRA_IN_RAM As Integer = -17
    Public Const ERR_INVALID_DLL_VERSION As Integer = -18
    Public Const ERR_NO_MEMORY As Integer = -19
    Public Const ERR_DLL_INITIALISATION As Integer = -20
    Public Const ERR_INVALID_STATE As Integer = -21

    ' Return error codes; DeviceData check
    Public Const ERR_INVALID_PARAMETER_NR_PIXELS As Integer = -100
    Public Const ERR_INVALID_PARAMETER_ADC_GAIN As Integer = -101
    Public Const ERR_INVALID_PARAMETER_ADC_OFFSET As Integer = -102

    ' Return error codes; PrepareMeasurement check
    Public Const ERR_INVALID_MEASPARAM_AVG_SAT2 As Integer = -110
    Public Const ERR_INVALID_MEASPARAM_AVG_RAM As Integer = -111
    Public Const ERR_INVALID_MEASPARAM_SYNC_RAM As Integer = -112
    Public Const ERR_INVALID_MEASPARAM_LEVEL_RAM As Integer = -113
    Public Const ERR_INVALID_MEASPARAM_SAT2_RAM As Integer = -114
    Public Const ERR_INVALID_MEASPARAM_FWVER_RAM As Integer = -115

    'StoreToRAM in 0.20.0.0 and later
    Public Const ERR_INVALID_MEASPARAM_DYNDARK As Integer = -116

    'Return error codes; SetSensitivityMode check
    Public Const ERR_NOT_SUPPORTED_BY_SENSOR_TYPE As Integer = -120
    Public Const ERR_NOT_SUPPORTED_BY_FW_VER As Integer = -121
    Public Const ERR_NOT_SUPPORTED_BY_FPGA_VER As Integer = -122

    Public Const UNCONFIGURED_DEVICE_OFFSET As Integer = 256
    Public Const INVALID_AVS_HANDLE_VALUE As Long = 1000L

    Public Const USER_ID_LEN As Byte = 64
    Public Const NR_WAVELEN_POL_COEF As Byte = 5
    Public Const NR_NONLIN_POL_COEF As Byte = 8
    Public Const NR_DEFECTIVE_PIXELS As Byte = 30
    Public Const MAX_NR_PIXELS As UShort = 4096
    Public Const NR_TEMP_POL_COEF As Byte = 5
    Public Const MAX_TEMP_SENSORS As Byte = 3
    Public Const ROOT_NAME_LEN As Byte = 6
    Public Const AVS_SERIAL_LEN As Byte = 10
    Public Const MAX_PIXEL_VALUE As UShort = &HFFFC
    Public Const MAX_VIDEO_CHANNELS As Byte = 2
    Public Const MAX_LASER_WIDTH As UShort = &HFFFF

    Public Const HW_TRIGGER_MODE As Byte = 1
    Public Const SW_TRIGGER_MODE As Byte = 0

    Public Const Ext_TRIGGER_MODE As Byte = 1
    Public Const SYNCH_TRIGGER_MODE As Byte = 0

    Public Const EDGE_TRIGGER_SOURCE As Byte = 0
    Public Const LEVEL_TRIGGER_SOURCE As Byte = 1

    Public Const MAX_TRIGGER_MODE As Byte = 1
    Public Const MAX_TRIGGER_SOURCE As Byte = 1
    Public Const MAX_TRIGGER_SOURCE_TYPE As Byte = 1
    Public Const MAX_INTEGRATION_TIME As UInteger = 600000    ' 600 seconds

    Public Const SAT_DISABLE_DET As Byte = 0
    Public Const SAT_ENABLE_DET As Byte = 1
    Public Const SAT_PEAK_INVERSION As Byte = 2
    Public Const NR_DAC_POL_COEF As Byte = 2

    Private Const UINT32_LEN As UInteger = 4
    Private Const UINT16_Len As UShort = 2
    Private Const DETECTOR_TYPE_LEN As UShort = 1 + 2 + 4 * NR_WAVELEN_POL_COEF + 1 + 8 * NR_NONLIN_POL_COEF + 2 * 8 + 4 * MAX_VIDEO_CHANNELS + 4 + 4 * MAX_VIDEO_CHANNELS + 4 + 2 * NR_DEFECTIVE_PIXELS
    Private Const IRRADIANCE_TYPE_LEN As UShort = 2 + 1 + 4 + 4 * MAX_NR_PIXELS + 1 + 4
    Private Const SPECTRUM_CALIBRATION_TYPE_LEN As UShort = 2 + 1 + 4 + 4 * MAX_NR_PIXELS
    Private Const SPECTRUM_CORRECTION_TYPE_Len As UShort = 4 * MAX_NR_PIXELS

    Private Const STAND_ALONE_TYPE_LEN As UShort = 1 + 2 + 2 + 4 + 4 + 4 + 1 + 1 + 2 + 1 + 1 + 1 + 1 + 1 + 2 + 4 + 4 + 4 + 2 + 2 + 1 + 1 + ROOT_NAME_LEN + 2 + 2

    Private Const TEMP_SENSOR_TYPE_LEN As UShort = 4 * NR_TEMP_POL_COEF
    Private Const TEC_CONTROL_TYPE_LEN As UShort = 1 + 4 + 4 * NR_DAC_POL_COEF
    Private Const PROC_CONTROL_TYPE_LEN As UShort = 96 '24*4

    Public Const SETTINGS_RESERVED_LEN As UShort = ((62 * 1024) - UINT32_LEN - _
                                                                    (UINT16_Len + _
                                                                     UINT16_Len + _
                                                                     USER_ID_LEN + _
                                                                     DETECTOR_TYPE_LEN + _
                                                                     IRRADIANCE_TYPE_LEN + _
                                                                     SPECTRUM_CALIBRATION_TYPE_LEN + _
                                                                     SPECTRUM_CORRECTION_TYPE_Len + _
                                                                     STAND_ALONE_TYPE_LEN + _
                                                                    (TEMP_SENSOR_TYPE_LEN) * MAX_TEMP_SENSORS + _
                                                                     TEC_CONTROL_TYPE_LEN + _
                                                                     PROC_CONTROL_TYPE_LEN))

    ' Structures needed to pass arrays

    Enum SENS_TYPE
        SENS_HAMS8378_256 = 1
        SENS_HAMS8378_1024 = 2
        SENS_ILX554 = 3
        SENS_HAMS9201 = 4
        SENS_TCD1304 = 5
        SENS_TSL1301 = 6
        SENS_TSL1401 = 7
        SENS_HAMS8378_512 = 8
        SENS_HAMS9840 = 9
        SENS_ILX511 = 10
        SENS_HAMS10420_2048X64 = 11
        SENS_HAMS11071_2048X64 = 12
        SENS_HAMS7031_1024X122 = 13
        SENS_HAMS7031_1024X58 = 14
        SENS_HAMS11071_2048X16 = 15
        SENS_HAMS11155 = 16
        SENS_SU256LSB = 17
        SENS_SU512LDB = 18
    End Enum 'SENS_TYPE

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure String16Type
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> _
        Public String16 As String
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure PixelArrayType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NR_PIXELS)> _
        Public Value() As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure SaturatedArrayType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NR_PIXELS)> _
        Public Value() As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure ControlSettingsType
        Public m_StrobeControl As UShort
        Public m_LaserDelay As UInteger
        Public m_LaserWidth As UInteger
        Public m_LaserWaveLength As Single
        Public m_StoreToRam As UShort
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure DarkCorrectionType
        Public m_Enable As Byte
        Public m_ForgetPercentage As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure DetectorType
        Public m_SensorType As Byte
        Public m_NrPixels As UShort
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=NR_WAVELEN_POL_COEF)> _
        Public m_aFit() As Single
        Public m_NLEnable As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=NR_NONLIN_POL_COEF)> _
        Public m_aNLCorrect() As Double
        Public m_aLowNLCounts As Double
        Public m_aHighNLCounts As Double
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_VIDEO_CHANNELS)> _
        Public m_Gain() As Single
        Public m_Reserved As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_VIDEO_CHANNELS)> _
        Public m_Offset() As Single
        Public m_ExtOffset As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=NR_DEFECTIVE_PIXELS)> _
        Public m_DefectivePixels() As UShort
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure SmoothingType
        Public m_SmoothPix As UShort
        Public m_SmoothModel As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure SpectrumCalibrationType
        Public m_Smoothing As SmoothingType
        Public m_CalInttime As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NR_PIXELS)> _
        Public m_aCalibConvers() As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure IrradianceType
        Public m_IntensityCalib As SpectrumCalibrationType
        Public m_CalibrationType As Byte
        Public m_FiberDiameter As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure TriggerType
        Public m_Mode As Byte
        Public m_Source As Byte
        Public m_SourceType As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure MeasConfigType
        Public m_StartPixel As UShort
        Public m_StopPixel As UShort
        Public m_IntegrationTime As Single
        Public m_IntegrationDelay As UInteger
        Public m_NrAverages As UInteger
        Public m_CorDynDark As DarkCorrectionType
        Public m_Smoothing As SmoothingType
        Public m_SaturationDetection As Byte
        Public m_Trigger As TriggerType
        Public m_Control As ControlSettingsType
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure TimeStampType
        Public m_Date As UShort
        Public m_Time As UShort
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure SDCardType
        Public m_Enable As Byte
        Public m_SpectrumType As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=ROOT_NAME_LEN)> _
        Public m_aFileRootName() As Byte
        Public m_TimeStamp As TimeStampType
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure SpectrumCorrectionType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_NR_PIXELS)> _
        Public m_aSpectrumCorrect() As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure StandAloneType
        Public m_Enable As Byte
        Public m_Meas As MeasConfigType
        Public m_Nmsr As Short
        Public m_SDCard As SDCardType
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure TempSensorType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=NR_TEMP_POL_COEF)> _
        Public m_aFit() As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure TecControlType
        Public m_Enable As Byte
        Public m_Setpoint As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=NR_DAC_POL_COEF)> _
        Public m_aFit() As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure ProcessControlType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> _
        Public AnalogLow() As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> _
        Public AnalogHigh() As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> _
        Public DigitalLow() As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> _
        Public DigitalHigh() As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure DeviceConfigType
        Public m_Len As UShort '2
        Public m_ConfigVersion As UShort '2
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=USER_ID_LEN)> _
        Public m_aUserFriendlyId() As Byte '1
        Public m_Detector As DetectorType '188
        Public m_Irradiance As IrradianceType '16396
        Public m_Reflectance As SpectrumCalibrationType '16391
        Public m_SpectrumCorrect As SpectrumCorrectionType '16384
        Public m_StandAlone As StandAloneType '62
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_TEMP_SENSORS)> _
        Public m_aTemperature() As TempSensorType '20*3=60
        Public m_TecControl As TecControlType '13
        Public m_ProcessControl As ProcessControlType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=SETTINGS_RESERVED_LEN)> _
        Public m_aReserved() As Byte
    End Structure

    Enum DEVICE_STATUS
        UNKNOWN = 0
        AVAILABLE = 1
        IN_USE_BY_APPLICATION = 2
        IN_USE_BY_OTHER = 3
    End Enum

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure AvsIdentityType
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)> _
        Public SerialNumber As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=64)> _
        Public UserFriendlyName As String
        Public Status As Byte
    End Structure

    ' Function prototypes

    Declare Function AVS_Init Lib "as5216" Alias "AVS_Init" (ByVal COMPort As Integer) As Integer
    Declare Function AVS_Done Lib "as5216" Alias "AVS_Done" () As Integer
    Declare Function AVS_GetNrOfDevices Lib "as5216" Alias "AVS_GetNrOfDevices" () As Integer
    Declare Function AVS_GetList Lib "as5216" Alias "AVS_GetList" (ByVal ListSize As UInteger, ByRef RequiredSize As UInteger, <[In](), Out()> ByVal List As AvsIdentityType()) As Integer
    Declare Function AVS_Activate Lib "as5216" Alias "AVS_Activate" (ByRef a_DeviceId As AvsIdentityType) As Integer
    Declare Function AVS_Deactivate Lib "as5216" Alias "AVS_Deactivate" (ByVal DeviceHandle As IntPtr) As Integer
    Declare Function AVS_GetHandleFromSerial Lib "as5216" Alias "AVS_GetHandleFromSerial" (ByRef Serial As Byte) As Integer
    Declare Function AVS_Register Lib "as5216" Alias "AVS_Register" (ByVal winID As Integer) As Integer
    Declare Function AVS_PrepareMeasure Lib "as5216" Alias "AVS_PrepareMeasure" (ByVal DeviceHandle As IntPtr, ByRef MeasConfig As MeasConfigType) As Integer
    Declare Function AVS_Measure Lib "as5216" Alias "AVS_Measure" (ByVal DeviceHandle As IntPtr, ByVal winID As Integer, ByVal Nmsr As Short) As Integer
    Declare Function AVS_GetLambda Lib "as5216" Alias "AVS_GetLambda" (ByVal DeviceHandle As IntPtr, ByRef WaveLength As PixelArrayType) As Integer
    Declare Function AVS_GetNumPixels Lib "as5216" Alias "AVS_GetNumPixels" (ByVal DeviceHandle As IntPtr, ByRef NumPixels As UShort) As Integer
    Declare Function AVS_GetParameter Lib "as5216" Alias "AVS_GetParameter" (ByVal DeviceHandle As IntPtr, ByVal Size As UInteger, ByRef RequiredSize As UInteger, ByRef DeviceParm As DeviceConfigType) As Integer
    Declare Function AVS_GetSecure Lib "as5216" Alias "AVS_GetSecure" () As Integer
    Declare Function AVS_GetScopeData Lib "as5216" Alias "AVS_GetScopeData" (ByVal DeviceHandle As IntPtr, ByRef TimeLabel As UInteger, ByRef pSpectrum As PixelArrayType) As Integer
    Declare Function AVS_GetSaturatedPixels Lib "as5216" Alias "AVS_GetSaturatedPixels" (ByVal DeviceHandle As IntPtr, ByRef a_pSaturated As SaturatedArrayType) As Integer
    Declare Function AVS_GetAnalogIn Lib "as5216" Alias "AVS_GetAnalogIn" (ByVal DeviceHandle As IntPtr, ByVal AnalogInId As Byte, ByRef AnalogIn As Single) As Integer
    Declare Function AVS_GetDigIn Lib "as5216" Alias "AVS_GetDigIn" (ByVal DeviceHandle As IntPtr, ByVal DigInId As Byte, ByRef DigIn As Byte) As Integer
    Declare Function AVS_GetDLLVersion Lib "as5216" Alias "AVS_GetDLLVersion" () As Integer
    Declare Function AVS_GetVersionInfo Lib "as5216" Alias "AVS_GetVersionInfo" (ByVal DeviceHandle As IntPtr, ByRef FPGAVersion As String16Type, ByRef FirmwareVersion As String16Type, ByRef DLLVersion As String16Type) As Integer
    Declare Function AVS_SaveSpectraToSDCard Lib "as5216" Alias "AVS_SaveSpectraToSDCard" (ByVal DeviceHandle As IntPtr, ByVal Enable As Boolean, ByVal SpectrumType As Byte, ByVal FileRootName As Byte, ByVal TimeStamp As TimeStampType) As Integer
    Declare Function AVS_SetParameter Lib "as5216" Alias "AVS_SetParameter" (ByVal DeviceHandle As IntPtr, ByRef DeviceParm As DeviceConfigType) As Integer
    Declare Function AVS_SetSecure Lib "as5216" Alias "AVS_SetSecure" () As Integer
    Declare Function AVS_SetAnalogOut Lib "as5216" Alias "AVS_SetAnalogOut" (ByVal DeviceHandle As IntPtr, ByVal PortId As Byte, ByVal Value As Single) As Integer
    Declare Function AVS_SetDigOut Lib "as5216" Alias "AVS_SetDigOut" (ByVal DeviceHandle As IntPtr, ByVal PortId As Byte, ByVal Status As Byte) As Integer
    Declare Function AVS_PollScan Lib "as5216" Alias "AVS_PollScan" (ByVal DeviceHandle As IntPtr) As Integer
    Declare Function AVS_SetPwmOut Lib "as5216" Alias "AVS_SetPwmOut" (ByVal DeviceHandle As IntPtr, ByVal PortId As Byte, ByVal Freq As UInteger, ByVal Duty As Byte) As Integer
    Declare Function AVS_StopMeasure Lib "as5216" Alias "AVS_StopMeasure" (ByVal DeviceHandle As IntPtr) As Integer
    Declare Function AVS_SetSyncMode Lib "as5216" Alias "AVS_SetSyncMode" (ByVal DeviceHandle As IntPtr, ByVal Enable As Byte) As Integer
    Declare Function AVS_GetFileSize Lib "as5216" Alias "AVS_GetFileSize" (ByVal DeviceHandle As IntPtr, ByRef a_pName As Byte, ByRef Size As UInteger) As Integer
    Declare Function AVS_GetFile Lib "as5216" Alias "AVS_GetFile" (ByVal DeviceHandle As IntPtr, ByRef Name As Byte, ByRef Dest As Byte, ByVal Size As UInteger) As Integer
    Declare Function AVS_GetFirstFile Lib "as5216" Alias "AVS_GetFirstFile" (ByVal DeviceHandle As IntPtr, ByRef Name As Byte) As Integer
    Declare Function AVS_GetNextFile Lib "as5216" Alias "AVS_GetNextFile" (ByVal DeviceHandle As IntPtr, ByRef PrevName As Byte, ByRef NextName As Byte) As Integer
    Declare Function AVS_DeleteFile Lib "as5216" Alias "AVS_DeleteFile" (ByVal DeviceHandle As IntPtr, ByRef Name As Byte) As Integer
    Declare Function AVS_SetPrescanMode Lib "as5216" Alias "AVS_SetPrescanMode" (ByVal a_hDevice As IntPtr, ByVal a_Prescan As Boolean) As Integer
    Declare Function AVS_UseHighResAdc Lib "as5216" Alias "AVS_UseHighResAdc" (ByVal a_hDevice As IntPtr, ByVal a_Enable As Boolean) As Integer
    Declare Function AVS_GetFirstDirectory Lib "as5216" Alias "AVS_GetFirstDirectory" (ByVal a_hDevice As IntPtr, ByRef a_pName As Byte) As Integer
    Declare Function AVS_GetNextDirectory Lib "as5216" Alias "AVS_GetNextDirectory" (ByVal a_hDevice As IntPtr, ByRef a_pPrevName As Byte, ByRef a_pNextName As Byte) As Integer
    Declare Function AVS_DeleteDirectory Lib "as5216" Alias "AVS_DeleteDirectory" (ByVal a_hDevice As IntPtr, ByRef a_pName As Byte) As Integer
    Declare Function AVS_SetDirectory Lib "as5216" Alias "AVS_SetDirectory" (ByVal a_hDevice As IntPtr, ByRef a_DirectoryName As Byte) As Integer '[ROOT_NAME_LEN]'Byte
    Declare Function AVS_SetSensitivityMode Lib "as5216" Alias "AVS_SetSensitivityMode" (ByVal a_hDevice As IntPtr, ByVal a_SensitivityMode As UInteger) As Integer
#End Region

#Region "Structure"

#End Region

#Region "Property"

#End Region

#Region "Creator, Disposer, Init"
    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_AVANTES
    End Sub
#End Region

#Region "Communication"
    Public Overrides Function Connection() As Boolean
        Dim sInfos As DeviceOption = Nothing

        ' m_DeviceHandle = INVALID_AVS_HANDLE_VALUE
        m_StopScan = 0
        Dim l_Res As Integer = 0
        Dim m_NrPixel As Integer = 0
        Dim l_hDevice() As Integer
        '     Dim l_Active() As AvsIdentityType = Nothing

        Dim l_Port As Integer = AVS_Init(0)

        AVS_Register(INVALID_AVS_HANDLE_VALUE)

        If (l_Port > 0) Then
            ' Status1.Text = "Connected: USB"
            UpdateList(l_Active)
        Else
            AVS_Done()
            l_Port = AVS_Init(-1)
            ' try RS-232/bluetooth autodetect
            ' an alternative and faster connection through
            ' RS-232 can be done by specifying the
            ' portnr in the argument, e.g.
            ' AVS_Init(2) if the device is connected to COM2

            If (l_Port > 0) Then
                '  Status1.Text = "Connected: RS-232"
                UpdateList(l_Active)
            Else
                '  Status1.Text = "Open communication failed"
                AVS_Done()
                '  Me.Cursor = Cursors.Default
                ' MsgBox("Open communication failed", MsgBoxStyle.Exclamation, "Error")
                '  Me.Close()
                m_bIsConnected = False
                Return False
            End If
        End If
        ReDim l_hDevice(l_Active.Length - 1)
        For i As Integer = 0 To l_Active.Length - 1
            l_hDevice(i) = AVS_Activate(l_Active(i))
            m_DeviceHandle(i) = l_hDevice(i)
        Next



        ''*******************************************************************************
        ''                               Activate Spectrometer
        ''*******************************************************************************
        'Dim l_hDevice As IntPtr
        'Dim l_ByteArray(74) As Byte

        ''Array.Copy(l_Active.SerialNumber, 0, l_ByteArray, 0, AVS_SERIAL_LEN)
        ''Array.Copy(l_Active.UserFriendlyName, 0, l_ByteArray, AVS_SERIAL_LEN, USER_ID_LEN)
        'l_ByteArray(74) = l_Active.Status

        'l_hDevice = AVS_Activate(l_Active)

        ''m_DeviceHandle = l_hDevice
        ''UpdateList(l_Active)
        ''ConnectGui()

        'If (INVALID_AVS_HANDLE_VALUE = l_hDevice) Then
        '    MsgBox("Error opening device " & l_Active.SerialNumber, MsgBoxStyle.Exclamation, "Error")
        'Else
        '    m_DeviceHandle = l_hDevice
        '    UpdateList(l_Active)

        '    Get_DeviceInfo()

        '    Get_NrPixel(m_NrPixel)
        '    ' ConnectGui()
        'End If
        ' Me.Cursor = Cursors.Default

        ReDim sInfos.DeviceList(l_Active.Length - 1)
        For i As Integer = 0 To l_Active.Length - 1
            sInfos.DeviceList(i).nDeviceCodeIndex = i
            sInfos.DeviceList(i).sDeviceSerialName = l_Active(i).SerialNumber
        Next
        m_DeviceInfos = sInfos


        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Function Connection(ByVal config As CComCommonNode.sCommInfo) As Boolean
        'Dim sInfos As DeviceOption = Nothing

        'm_DeviceHandle = INVALID_AVS_HANDLE_VALUE
        'm_StopScan = 0
        'Dim nPort As Integer
        'Dim l_Res As Integer = 0
        'Dim m_NrPixel As Integer = 0

        '' Dim l_Active() As AvsIdentityType = Nothing
        'nPort = config.sSerialInfo.sPortName.Substring(2, config.sSerialInfo.sPortName.Length - 3)
        'Dim l_Port As Integer = AVS_Init(nPort)

        'AVS_Register(m_DeviceHandle)

        'If l_Port > 0 Then
        '    UpdateList(l_Active)
        'Else
        '    AVS_Done()
        '    m_bIsConnected = False
        '    Return False
        'End If

        'ReDim sInfos.DeviceList(l_Active.Length - 1)
        'For i As Integer = 0 To l_Active.Length - 1
        '    sInfos.DeviceList(i).nDeviceCodeIndex = i
        '    sInfos.DeviceList(i).sDeviceSerialName = l_Active(i).SerialNumber
        'Next
        'm_DeviceInfos = sInfos

        'm_bIsConnected = True
        'Return True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        Dim l_Res As Integer
        If (m_DeviceHandle(0) <> INVALID_AVS_HANDLE_VALUE) Then
            For i As Integer = 0 To m_DeviceHandle.Length - 1
                l_Res = AVS_StopMeasure(m_DeviceHandle(i))
                If (ERR_SUCCESS <> l_Res) Then
                    MsgBox("Error in AVS_StopMeasure, code:" & Str(l_Res), MsgBoxStyle.OkOnly, "Error")
                End If
            Next

        End If
        'Erase m_pLambda.Value
        m_NrPixels = 0
        l_Res = AVS_Done()
        If (ERR_SUCCESS <> l_Res) Then
            Exit Sub
        End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"
    Public Overrides Function SetDeviceInfos(ByVal index As Integer, ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        If m_bIsConnected = False Then Return False
        Dim l_Size As UInteger
        Dim l_Res As Integer = 0

        '   For i As Integer = 0 To m_DeviceHandle.Length - 1
        l_Res = AVS_GetParameter(m_DeviceHandle(index), 0, l_Size, objAvantesParameter(index))

        If (l_Res = ERR_INVALID_SIZE) Then
            l_Res = AVS_GetParameter(m_DeviceHandle(index), l_Size, l_Size, objAvantesParameter(index))
        End If

        objAvantesParameter(index).m_StandAlone.m_Meas.m_IntegrationTime = sInfos.MeasSpeedValue
        objAvantesParameter(index).m_StandAlone.m_Meas.m_NrAverages = sInfos.NumOfAverage

        l_Res = AVS_SetParameter(m_DeviceHandle(index), objAvantesParameter(index))
        If l_Res <> 0 Then
            Return False
        End If
        ' Next

        Return True
    End Function

    Public Overrides Function GetDeviceInfos(ByVal index As Integer, ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        If m_bIsConnected = False Then Return False
        Dim l_Size As UInteger
        Dim l_Res As Integer = 0

        '   For i As Integer = 0 To m_DeviceHandle.Length - 1
        l_Res = AVS_GetParameter(m_DeviceHandle(index), 0, l_Size, objAvantesParameter(index))

        If (l_Res = ERR_INVALID_SIZE) Then
            l_Res = AVS_GetParameter(m_DeviceHandle(index), l_Size, l_Size, objAvantesParameter(index))
        End If

        If l_Res <> 0 Then
            Return False
        End If
        '   Next

        sInfos.MeasSpeedValue = objAvantesParameter(index).m_StandAlone.m_Meas.m_IntegrationTime
        sInfos.NumOfAverage = objAvantesParameter(index).m_StandAlone.m_Meas.m_NrAverages
        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim lamda()() As Double = Nothing
        Dim intensity()() As Double = Nothing

        If GetIntensity(lamda, intensity) = False Then Return False

        If GetMeasData(lamda, intensity) = False Then Return False

        outData = m_Data
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        Dim l_Res As Integer
        l_Res = StopMeasure()
        If l_Res <> 0 Then
            Return False
        End If
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

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True
    End Function

    Public Overrides Function DarkMeasure(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        Dim dLamda()() As Double = Nothing
        Dim dScope()() As Double = Nothing

        If GetScope(dLamda, dScope) = False Then Return False
        'ReDim dLamda()
        'ReDim dScope(100)

        'For i As Integer = 0 To 100
        '    dLamda(i) = i
        '    dScope(i) = i
        'Next

        m_Data.D7.i3nm = dLamda(0).Clone
        m_Data.D7.s2DarkScope = dScope(0).Clone

        outData = m_Data
        Return True
    End Function
#End Region

#Region "Functions"

    Public Overrides Function DeviceActive(ByVal nIndex As Integer) As Boolean

        'Dim l_hDevice As IntPtr
        'Dim l_ByteArray(74) As Byte
        'Dim m_NrPixel As UShort
        'Try

        '    l_ByteArray(74) = l_Active(nIndex).Status

        '    l_hDevice = AVS_Activate(l_Active(nIndex))

        '    If (INVALID_AVS_HANDLE_VALUE = l_hDevice) Then
        '        MsgBox("Error opening device " & l_Active(nIndex).SerialNumber, MsgBoxStyle.Exclamation, "Error")
        '        Return False
        '    Else
        '        m_DeviceHandle = l_hDevice
        '        Get_DeviceInfo()

        '        Get_NrPixel(m_NrPixel)
        '    End If
        'Catch ex As Exception
        '    Return False
        'End Try

        'm_DeviceInfos.DeviceIndex = nIndex
        Return True
    End Function

    Public Overrides Function DeviceDeActive(ByVal nIndex As Integer) As Boolean
        Dim l_hDevice As IntPtr

        Try
            l_hDevice = m_DeviceHandle(nIndex)
            AVS_Deactivate(l_hDevice)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub UpdateList(ByRef l_Id() As AvsIdentityType)

        Dim i As Integer = 0
        Dim l_Size As UInteger = 0
        Dim l_RequiredSize As UInteger = 0
        Dim l_NrDevices As Integer
        Dim l_pId() As AvsIdentityType
        Dim count As Integer = 0

        l_NrDevices = AVS_GetNrOfDevices()
        l_RequiredSize = l_NrDevices * 75

        ReDim l_Id(l_NrDevices - 1)
        If (l_RequiredSize > 0) Then
            l_pId = New AvsIdentityType(l_NrDevices - 1) {}
            l_Size = l_RequiredSize
            l_NrDevices = AVS_GetList(l_Size, l_RequiredSize, l_pId)
            For i = 0 To (l_NrDevices - 1)
                Select Case l_pId(i).Status
                    Case DEVICE_STATUS.UNKNOWN
                        '    Status3.Text = "Unknown Device found!"
                    Case DEVICE_STATUS.AVAILABLE
                        l_Id(i).SerialNumber = l_pId(i).SerialNumber
                        l_Id(i).Status = l_pId(i).Status
                        l_Id(i).UserFriendlyName = l_pId(i).UserFriendlyName
                        '  Status3.Text = "Spectrometer " & l_pId(i).SerialNumber & " found!"
                        ' count += 1
                    Case DEVICE_STATUS.IN_USE_BY_APPLICATION
                        '  Status3.Text = "Spectrometer is used by the application "
                        '  Exit For
                    Case DEVICE_STATUS.IN_USE_BY_OTHER
                        ' Status3.Text = "Device is used by other"
                    Case Else
                        ' Status3.Text = "??????"
                End Select
            Next i
            '   l_Id = l_pId.Clone
            Erase l_pId
        End If
    End Sub

    Public Function Get_DeviceInfo() As Integer
        Dim l_Res As Integer = 0
        Dim a_Fpga As String16Type = Nothing
        Dim a_As5216 As String16Type = Nothing
        Dim a_Dll As String16Type = Nothing
        For i As Integer = 0 To m_DeviceHandle.Length - 1
            l_Res = AVS_GetVersionInfo(m_DeviceHandle(i), a_Fpga, a_As5216, a_Dll)
        Next
        Return l_Res
    End Function

    Public Function Get_NrPixel(ByRef NrPixel As UShort) As Boolean
        If m_bIsConnected = False Then Return False
        For i As Integer = 0 To m_DeviceHandle.Length - 1
            If (ERR_SUCCESS = AVS_GetNumPixels(m_DeviceHandle(i), NrPixel)) Then
            Else
                Return False
            End If
        Next

        Return True
    End Function

    Public Function PreMeasurement(ByVal index As Integer) As Integer

        Dim l_Res As Integer = 0

        '  For i As Integer = 0 To m_DeviceHandle.Length - 1
        l_Res = AVS_PrepareMeasure(m_DeviceHandle(index), objAvantesParameter(index).m_StandAlone.m_Meas)
        '  Next

        Return l_Res
    End Function

    Public Function GetScope(ByRef m_LamdaData()() As Double, ByRef m_ScopeData()() As Double) As Boolean
        If m_bIsConnected = False Then Return False
        Dim l_Res As Integer = 0
        ReDim m_LamdaData(m_DeviceHandle.Length - 1)
        ReDim m_ScopeData(m_DeviceHandle.Length - 1)

        For i As Integer = 0 To m_DeviceHandle.Length - 1
            l_Res = PreMeasurement(i)
            If l_Res <> 0 Then Return False
            Thread.Sleep(1)
            l_Res = AVS_Measure(m_DeviceHandle(i), m_DeviceHandle(i), 1)
            If l_Res <> 0 Then Return False
            Thread.Sleep(objAvantesParameter(i).m_StandAlone.m_Meas.m_IntegrationTime * 10 + 1560)
            l_Res = GetScopeData(i, m_LamdaData(i), m_ScopeData(i))
            If l_Res <> 0 Then Return False
            Thread.Sleep(1)
            l_Res = StopMeasure(i)
            If l_Res <> 0 Then Return False
        Next

        Return True
    End Function

    Public Function StopMeasure() As Integer
        If m_bIsConnected = False Then Return False
        Dim l_Res As Integer = 0
        For i As Integer = 0 To m_DeviceHandle.Length - 1
            l_Res = AVS_StopMeasure(m_DeviceHandle(i))
        Next

        Return l_Res
    End Function

    Public Function StopMeasure(ByVal index As Integer) As Integer
        If m_bIsConnected = False Then Return False
        Dim l_Res As Integer = 0
        'For i As Integer = 0 To m_DeviceHandle.Length - 1
        l_Res = AVS_StopMeasure(m_DeviceHandle(index))

        ' Next

        Return l_Res
    End Function

    Public Function GetScopeData(ByVal index As Integer, ByRef m_LamdaData() As Double, ByRef m_ScopeData() As Double) As Integer
        Dim l_Res As Integer = 0
        Dim l_Time As UInteger
        ' l_Res = Get_LamdaData(m_LamdaData)
       

        l_Res = AVS_GetLambda(m_DeviceHandle(index), m_pLambda)
        l_Res = AVS_GetScopeData(m_DeviceHandle(index), l_Time, m_pScopeda)

        If l_Res <> 0 Then MsgBox("Error : " & l_Res)
        m_ScopeData = m_pScopeda.Value.Clone
        m_LamdaData = m_pLambda.Value.Clone

        Return l_Res
    End Function

    Public Function Get_LamdaData(ByRef m_LamdaData()() As Double) As Integer
        If m_bIsConnected = False Then Return False
        Dim l_Res As Integer = 0

        ReDim m_LamdaData(m_DeviceHandle.Length - 1)
        For i As Integer = 0 To m_DeviceHandle.Length - 1
            l_Res = AVS_GetLambda(m_DeviceHandle(i), m_pLambda)
            m_LamdaData(i) = m_pLambda.Value.Clone
        Next

        Return l_Res
    End Function

    Public Function GetIntensity(ByRef m_Lamda()() As Double, ByRef m_Intensity()() As Double) As Boolean
        Dim i As Integer = 0
        Dim l_Res As Integer = 0
        Dim line As String = 0
        Dim NodataFit(,) As Double
        Dim CaldataFit(,) As Double
        Dim lamda()() As Double = Nothing
        Dim scope()() As Double = Nothing
        Dim xdata1() As Double = Nothing '파장데이타
        Dim ydata1() As Double = Nothing '측정데이타
        Dim Nodata1() As Double = Nothing '노이즈 데이타
        Dim Nodata2() As Double = Nothing '노이즈 데이타
        Dim Caldata1() As Double = Nothing
        Dim Caldata2() As Double = Nothing
        Dim m_intensitydata() As Double = Nothing
        Dim m_lamddata() As Double = Nothing

        ReDim m_Lamda(m_DeviceHandle.Length - 1)
        ReDim m_Intensity(m_DeviceHandle.Length - 1)

        If m_Data.D7.i3nm.Length = 0 Then
            m_Data.D7 = m_DarkData
        End If

        For i = 0 To m_Data.D7.i3nm.Length - 1
            Nodata1(i) = m_Data.D7.i3nm(i)
            Nodata2(i) = m_Data.D7.s2DarkScope(i)
        Next

        NodataFit = (AverageData1_1(Nodata1, Nodata2))

        Thread.Sleep(10)
        If GetScope(lamda, scope) = False Then
            MsgBox("Measurement Error")
            Return False
        End If


        For j As Integer = 0 To m_DeviceHandle.Length - 1
            ReDim xdata1(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            ReDim ydata1(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            ReDim Nodata1(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            ReDim Nodata2(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            ReDim Caldata1(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            ReDim Caldata2(objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
            For i = 0 To (objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
                xdata1(i) = lamda(j)(i)
                ydata1(i) = scope(j)(i)
            Next

            For i = 0 To (objAvantesParameter(j).m_StandAlone.m_Meas.m_StopPixel - objAvantesParameter(j).m_StandAlone.m_Meas.m_StartPixel)
                Caldata1(i) = lamda(j)(i)
                Caldata2(i) = objAvantesParameter(j).m_Irradiance.m_IntensityCalib.m_aCalibConvers(i)
            Next

            CaldataFit = AverageData1_1(Caldata1, Caldata2)

            Dim ReValue(,) As Double
            ReValue = AverageData1_1(xdata1, ydata1)
            For i = 0 To UBound(ReValue, 2)

                ReDim Preserve m_intensitydata(i)
                ReDim Preserve m_lamddata(i)
                m_lamddata(i) = ReValue(0, i)
                If (ReValue(1, i) - NodataFit(1, i)) / CaldataFit(1, i) < 0 Then
                    m_intensitydata(i) = 0
                Else
                    m_intensitydata(i) = (((ReValue(1, i) - NodataFit(1, i)) / CaldataFit(1, i)) * (objAvantesParameter(j).m_Irradiance.m_IntensityCalib.m_CalInttime / objAvantesParameter(j).m_StandAlone.m_Meas.m_IntegrationTime) * (10 ^ -2))
                End If

            Next
            m_Lamda(j) = m_lamddata.Clone
            m_Intensity(j) = m_intensitydata.Clone
        Next


        '    m_Lamda = m_Lamda.Clone
        '   m_Intensity = m_Intensity.Clone
        Return True
    End Function

    Function AverageData1_1(ByVal m_pLambda() As Double, ByVal l_pSpectrum() As Double) As Double(,)
        Dim ReturnValue(1, 1) As Double
        Try
            Dim i, j, k As Integer
            Dim Startj As Integer = 0

            k = 0
            For i = Fix(m_pLambda(0)) + 1 To Fix(m_pLambda(m_pLambda.Length - 1))
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

    Public Function GetMeasData(ByVal Wlengthdata()() As Double, ByVal Intensitydata()() As Double) As Boolean
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
        Dim TotalWavelength() As Double = Nothing
        Dim TotalIntensity() As Double = Nothing
        Dim ncount As Integer = 0
        SumX1 = 0
        SumY1 = 0
        SumZ1 = 0

        ColorMatchingFuntions()

        If m_DeviceHandle.Length = 1 Then
            For j As Integer = 0 To Wlengthdata(0).Length - 1
                ReDim Preserve TotalWavelength(ncount)
                ReDim Preserve TotalIntensity(ncount)
                TotalWavelength(ncount) = Wlengthdata(0)(j)
                TotalIntensity(ncount) = Intensitydata(0)(j)
                ncount += 1
            Next
        Else
            For i As Integer = 0 To m_DeviceHandle.Length - 1
                For j As Integer = 0 To Wlengthdata(i).Length - 1
                    If i = 0 Then
                        If Wlengthdata(i)(j) > 379 And Wlengthdata(i)(j) < 1051 Then
                            ReDim Preserve TotalWavelength(ncount)
                            ReDim Preserve TotalIntensity(ncount)
                            TotalWavelength(ncount) = Wlengthdata(i)(j)
                            TotalIntensity(ncount) = Intensitydata(i)(j)
                            ncount += 1
                        End If
                    Else
                        If Wlengthdata(i)(j) > 1050 And Wlengthdata(i)(j) < 1701 Then
                            ReDim Preserve TotalWavelength(ncount)
                            ReDim Preserve TotalIntensity(ncount)
                            TotalWavelength(ncount) = Wlengthdata(i)(j)
                            TotalIntensity(ncount) = Intensitydata(i)(j)
                            ncount += 1
                        End If
                    End If
                Next
            Next
        End If


        Dim ColorCnt As Integer = 0

        For i = 0 To TotalWavelength.Length - 1
            If TotalWavelength(i) > 379 Then
                SumX1 = SumX1 + (PhotopicConversion(i) * LuminanceCalFactor(i) * (TotalIntensity(i)))
                SumY1 = SumY1 + (PhotopicConversion(i) * LuminanceCalFactor(i) * (TotalIntensity(i)))
                SumZ1 = SumZ1 + (PhotopicConversion(i) * LuminanceCalFactor(i) * (TotalIntensity(i)))
                Radiance = Radiance + TotalIntensity(i)
                ColorCnt = ColorCnt + 1
                If ColorCnt >= 401 Then
                    Exit For
                End If
            End If
        Next

        For i = 0 To TotalWavelength.Length - 1
            If TotalIntensity(i) > PeakVal Then
                PeakLength = TotalWavelength(i)
                PeakVal = TotalIntensity(i)
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
        m_Data.D5.s4Intensity = TotalIntensity.Clone

        ' m_Data.GetInfo.nAverage = CInt(objAvantesParameter.m_StandAlone.m_Meas.m_NrAverages)
        ' m_Data.GetInfo.nExposureTime = CInt(objAvantesParameter.m_StandAlone.m_Meas.m_IntegrationTime)

        ReDim nWlengthdata(TotalWavelength.Length - 1)
        For i As Integer = 0 To TotalWavelength.Length - 1
            nWlengthdata(i) = CInt(TotalWavelength(i))
        Next
        m_Data.D5.i3nm = nWlengthdata.Clone
        Return True
    End Function

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function

#End Region
End Class
