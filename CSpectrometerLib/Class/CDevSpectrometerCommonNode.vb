Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class CDevSpectrometerCommonNode

#Region "Define"

    Protected m_MyModel As eModel

    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo 'CCommLib.CComSerial.sSerialPortInfo 'CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False

    Protected m_ErrorCode As Integer

    '   Protected m_SpectrometerInfos As SetInfos
    Protected m_DeviceInfos As DeviceOption
    '   Protected m_Data As tData
    Protected m_DarkData As tData07
    Shared sSupportDeviceList() As String = New String() {"SR-3AR", "SR-UL2", "UA10", "PR650", "PR655", "PR670", "PR705", "PR730", "PR740", "CS-1000", "CS-1000A", "CS-2000", "CS-2000A", "AVANTES", "LABSPHERE", "DarsaPro", "OceanOptics"}

    Public m_bCalRead As Boolean
    Public m_bClsUpLense As Boolean
    Public m_nExposureTime As Integer

    Public Event evError(ByVal errorCode As Integer)

    Public Enum eModel
        SPECTROMETER_SR3AR
        SPECTROMETER_SRUL2
        SPECTROMETER_UA_10
        SPECTROMETER_PR650
        SPECTROMETER_PR655
        SPECTROMETER_PR670
        SPECTROMETER_PR705
        SPECTROMETER_PR730
        SPECTROMETER_PR740
        SPECTROMETER_CS1000
        SPECTROMETER_CS1000A
        SPECTROMETER_CS2000
        SPECTROMETER_CS2000A
        SPECTROMETER_AVANTES
        SPECTROMETER_LABSPHERE
        SPECTROMETER_DarsaPro
        SPECTROMETER_OceanOptics
    End Enum

#End Region

#Region "Properties"

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public ReadOnly Property DeviceInfos As DeviceOption
        Get
            Return m_DeviceInfos
        End Get
        '  Set(ByVal value As DeviceOption)
        '       m_DeviceInfos = value
        '  End Set
    End Property

 
    Public Property Model As eModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eModel)
            m_MyModel = value
        End Set
    End Property

    Public Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public ReadOnly Property ErrorCode As Integer
        Get
            Return m_ErrorCode
        End Get
    End Property

    Public Property DarkData As tData07
        Get
            Return m_DarkData
        End Get
        Set(ByVal value As tData07)
            m_DarkData = value
        End Set
    End Property

    Public Property LuminanceCalibrationFactor As Double()
        Get
            Return LuminanceCalFactor
        End Get
        Set(value As Double())
            LuminanceCalFactor = value
        End Set
    End Property

    Public Property PhotopicValue As Double()
        Get
            Return PhotopicConversion
        End Get
        Set(value As Double())
            PhotopicConversion = value
        End Set
    End Property

    Public Property CalReadUsed() As Boolean
        Get
            Return m_bCalRead
        End Get
        Set(value As Boolean)
            m_bCalRead = value
        End Set
    End Property

    Public Property CloseUpLenseUsed() As Boolean
        Get
            Return m_bClsUpLense
        End Get
        Set(value As Boolean)
            m_bClsUpLense = value
        End Set
    End Property

    Public Property ExposureTime() As Integer
        Get
            Return m_nExposureTime
        End Get
        Set(ByVal value As Integer)
            m_nExposureTime = value
        End Set
    End Property

#End Region


#Region "Structures"

    'Public Structure SetInfossss
    '    Dim SR3AR As CDevSR_3AR.DeviceOption
    '    Dim PR705 As CDevPR705.DeviceOption
    '    Dim PR730 As CDevPR730.DeviceOption
    'End Structure

    'Public Structure sSettings
    '    Dim ApertureInfos As sAperture
    '    Dim MeasSpeedInfos As sMeasSpeed
    '    Dim ALensInfos As sLens
    'End Structure

    Public Structure DeviceOption
        Dim ApertureIndex As Integer
        Dim MeasSpeedIndex As Integer
        Dim LensIndex As Integer
        Dim NDIndex As Integer
        Dim MeasSpeedValue As Double   'CS2000 Manual Speed Mode 선택시, Value값 설정 or Labsphere /avantes IntegrationTime 20141021 Jeongsoo 추가
        Dim NumOfAverage As Integer  'Labsphere / Avantes Average Count 20141022 Jeongsoo 추가
        Dim BoxWidth As Integer 'OceanOptics Value 20150810 Jeongsoo 추가
        Dim ExposeTime As Integer
        Dim ExposeTimeONOFF As Integer
        Dim DeviceIndex As Integer
        Dim DeviceList() As sDevice
        Dim ApertureList() As sAperture
        Dim MeasSpeedList() As sMeasSpeed
        Dim LensList() As sLens
        Dim NDFilterList() As sNDFilter  'CS2000 Speed Mode 선택시, ND Filter 적용을 선택할 수 있도록 추가
        Dim ua10Property As UaDeviceProperty
        Dim ua10Recipe As UaRecipe
    End Structure

    Public Structure sDevice
        Dim nDeviceCodeIndex As Integer
        Dim sDeviceSerialName As String
    End Structure

    Public Structure sAperture
        Dim nApertureCodeIndex As Integer
        Dim sApertureName As String
    End Structure

    Public Structure sMeasSpeed
        Dim nMeasSpeedCodeIndex As Integer
        Dim sSpeedName As String
    End Structure

    Public Structure sLens
        Dim nLensCodeIndex As Integer
        Dim sLensName As String
    End Structure

    Public Structure sNDFilter
        Dim nNDFilterCodeIndex As Integer
        Dim sNDFilterName As String
    End Structure

    Public Structure sInstrument
        Dim sLensName As String
        Dim sApertureName As String
        Dim nAverage As Integer
        Dim sExposureMode As String
        Dim nExposureTime As Integer
        Dim nPhotoUnit As Integer
    End Structure

    Public Structure tDataCommon
        Dim strDivider() As String
        Dim i0MeasQCode As Integer
        Dim striOMeasQCode As String
        Dim i1UnitValue0Value1Uncal2 As Integer 'Unit: Luminance0/illuminance1/Uncal2 or SpectralRadiance0/Spectralirradiance1
    End Structure

    Public Structure tData01
        Dim Comn As tDataCommon
        Dim s2YY As Single
        Dim s3xx As Single
        Dim s4yy As Single
    End Structure

    Public Structure tData02
        Dim Comn As tDataCommon
        Dim s2XX As Single
        Dim s3YY As Single
        Dim s4ZZ As Single
    End Structure

    Public Structure tData03
        Dim Comn As tDataCommon
        Dim s2YY As Single
        Dim s3uu As Single
        Dim s4vv As Single
    End Structure

    Public Structure tData04
        Dim Comn As tDataCommon
        Dim s2YY As Single
        Dim s3KelvinT As Single
        Dim s4DevOfColorCoord As Single
    End Structure

    Public Structure tData05
        Dim Comn As tDataCommon
        Dim s2IntegIntensity As Double
        Dim i3nm() As Integer
        Dim s4Intensity() As Double
        Dim iMax As Integer
        Dim nMaxIntensity As Double
    End Structure

    Public Structure tData06
        Dim Comn As tDataCommon
        Dim s2YY As Single
        Dim s3xx As Single
        Dim s4yy As Single
        Dim s5uu As Single
        Dim s6vv As Single
    End Structure

    Public Structure tData07
        Dim Comn As tDataCommon
        Dim s2DarkScope() As Double
        Dim i3nm() As Double
    End Structure

    Public Structure tData08
        Dim Comn As tDataCommon
        Dim s2IrradCalFactor() As Double
        Dim s4Transferfunction() As Double
        Dim i3nm() As Double
    End Structure

    Public Structure tGetTime
        Dim sMeasTime As Single
        Dim sDataGetTime As Single
    End Structure

    Public Structure tData
        Dim D1 As tData01
        Dim D2 As tData02
        Dim D3 As tData03
        Dim D4 As tData04
        Dim D5 As tData05
        Dim D6 As tData06
        Dim D7 As tData07
        Dim D8 As tData08
        Dim GetTime As tGetTime
        Dim GetInfo As sInstrument
        Dim IntegrationTime As Double
        '    InCom As tInComming
    End Structure

    Public Structure tDataArray
        Dim D1(,) As tData01
        Dim D2(,) As tData02
        Dim D3(,) As tData03
        Dim D4(,) As tData04
        Dim D5(,) As tData05
        Dim D6(,) As tData06
        Dim D7(,) As tData07
        Dim D8(,) As tData08
        Dim GetTime(,) As tGetTime
        Dim GetInfo(,) As sInstrument
        '    InCom As tInComming
    End Structure

    Public Structure sColorCIEParam
        Dim CIEx As Double   'CIE1931
        Dim CIEy As Double
        Dim CIE1960_u As Double   'CIE1960
        Dim CIE1960_v As Double
        Dim CIE1976_ud As Double   'CIE1976
        Dim CIE1976_vd As Double
        Dim CCT As Double
        Dim BBL_x As Double
        Dim BBL_y As Double
        Dim BBL_u As Double
        Dim BBL_v As Double
        Dim MPCD As Double
    End Structure

    '#Region "Ua_core2. Structures"
    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaConfiguration
    '        Public num_installed As Integer
    '        Public num_connected As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public installed_product_ids() As String
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public connected_product_ids() As String
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaSystem
    '        Public ua_10 As IntPtr
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaDevice
    '        Public type As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=17)> _
    '        Public product_id() As Byte
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> _
    '        Public mac_address() As Byte
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    '        Public ip_address() As Byte
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    '        Public subnet_mask() As Byte
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    '        Public default_gateway() As Byte
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaDeviceProperty
    '        Public device_type As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
    '        Public product_id() As Byte
    '        Public capture_mode As Integer
    '        Public binning_type As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    '        Public gain() As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    '        Public aperture() As Integer
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    '        Public exposure_time() As Double
    '        Public measurement_distance As Integer
    '        Public internal_obj As IntPtr
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaPoint
    '        Public x As Double
    '        Public y As Double
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaSize64f
    '        Public width As Double
    '        Public height As Double
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaRecipe
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public comment() As Byte
    '        Public average_auto As Integer
    '        Public exposure_auto As Integer
    '        Public average_count As Integer
    '        Public frequency As Integer
    '        Public use_frequency As Integer
    '        Public color_correction_type As Integer
    '        Public device_property As IntPtr
    '        Public reference_white_point As UaPoint
    '        Public internal_obj As IntPtr
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaCaptureData
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public width As Integer
    '        Public height As Integer
    '        Public size As Integer
    '        Public X As UShort
    '        Public Y As UShort
    '        Public Z As UShort
    '        Public device_Property As IntPtr
    '        Public area As UaSize64f
    '        Public resolution As UaSize64f
    '        Public timestamp As Date
    '        Public internal_obj As IntPtr
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaChromaticity
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public type As UaColorSpaceType
    '        Public x As Double
    '        Public y As Double
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaChromaticityImage
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public type As UaColorSpaceType
    '        Public width As Integer
    '        Public height As Integer
    '        Public size As Integer
    '        Public x As Single
    '        Public y As Single
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaImage
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public width As Integer
    '        Public height As Integer
    '        Public size As Integer
    '        Public data As Double
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaRect
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public x As Integer
    '        Public y As Integer
    '        Public width As Integer
    '        Public height As Integer
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaSize
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public width As Integer
    '        Public height As Integer
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaSpot
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public id As Integer
    '        Public shape As UaSpotShape
    '        Public x As Integer
    '        Public y As Integer
    '        Public width As Single
    '        Public height As Single
    '        Public point_data As IntPtr
    '        Public point_size As Integer
    '        Public threshold_x As Single
    '        Public threshold_y As Single
    '        Public threshold_z As Single
    '        Public LX As Single
    '        Public LY As Single
    '        Public LZ As Single
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaSpotList
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public size As Integer
    '        Public data As IntPtr
    '    End Structure

    '    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    '    Public Structure UaXYZImage
    '        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    '        Public width As Integer
    '        Public height As Integer
    '        Public size As Integer
    '        Public LX As Single
    '        Public LY As Single
    '        Public LZ As Single
    '        Public device_property As IntPtr
    '        Public area As UaSize64f
    '        Public resolution As UaSize64f
    '        Public time_t As Date
    '        Public processing_time As Double
    '    End Structure

    '#End Region
#End Region

#Region "Creator, Disoposer And Init"

    Public Sub New()
        m_bIsConnected = False
    End Sub

#End Region

#Region "Communication Functions"

    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function

    'Public Overridable Function Connection(ByVal Config As CCommLib.CComCommonNode.sCommInfo, Optional ByVal bSetClsupLens As Boolean = False) As Boolean
    '    Return False
    'End Function

    'Public Overridable Function Connection(ByVal config As CCommLib.CComSerial.sSerialPortInfo) As Boolean
    '    Return False
    'End Function

    Public Overridable Function Connection() As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub

#End Region


#Region "Control Functions"

    Public Overridable Function StartApertureChange() As Boolean
        Return False
    End Function

    Public Overridable Function EndApertureChange() As Boolean
        Return False
    End Function

    Public Overridable Function Measure(ByRef outData As tData) As Boolean
        Return False
    End Function

    Public Overridable Function MeasureFixedAperture(ByRef outData As tData) As Boolean
        Return False
    End Function

    Public Overridable Function Measure(ByRef outdata As tDataArray, ByRef image As Bitmap) As Boolean
        Return False
    End Function

    Public Overridable Function DarkMeasure(ByRef outData As tData) As Boolean
        Return False
    End Function

    Public Overridable Function Measure(ByVal measMode As cDevCS2000A.eMeasureMode, ByRef outData As tData, ByRef ErrorCode As Short) As Boolean
        Return False
    End Function

    Public Overridable Function Measure(ByVal expTime As Integer, ByVal measType As cDevCS2000A.eMEASURE_TYPE, ByRef sMeasData As cDevCS2000A.sMeasureData) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Support device list is below
    ''' - DarsaPro
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function DarkMeasure() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Data Read
    ''' </summary>
    ''' <param name="outData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function DownloadData(ByRef outData As tData) As Boolean
        Return False
    End Function


    Public Overridable Function RemoteMode() As Boolean
        Return False
    End Function

    Public Overridable Function LocalMode() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Set Device Accessory, Aperture, Meas Speed
    ''' </summary>
    ''' <param name="sInfos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetDeviceInfos(ByVal sInfos As DeviceOption) As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Get Device Accessory, Aperture, Meas Speed
    ''' </summary>
    ''' <param name="sInfos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetDeviceInfos(ByRef sInfos As DeviceOption) As Boolean
        Return False
    End Function


    Public Overridable Function SetDeviceInfos(ByVal index As Integer, ByVal sInfos As DeviceOption) As Boolean
        Return False
    End Function

    Public Overridable Function GetDeviceInfos(ByVal index As Integer, ByRef sInfos As DeviceOption) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Selected Aperture Set(SR-3AR, PR705, PR730)
    ''' </summary>
    ''' <param name="nAperatureIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetAperture(ByVal nAperatureIndex As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Selected Lens Set(PR705, PR730, PR655) 
    ''' </summary>
    ''' <param name="nLensIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetLens(ByVal nLensIndex As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Selected Meas Speed Set(SR-3AR, PR730)
    ''' </summary>
    ''' <param name="nMeasSpeedIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Selected Meas Speed Set(CS2000)
    ''' </summary>
    ''' <param name="nMeasSpeedIndex"></param>
    ''' <param name="nMeasSpeedVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetMeasSpeed(ByVal nMeasSpeedIndex As Integer, ByVal nMeasSpeedVal As Double, Optional ByVal nNDFilterIndex As Integer = 0) As Boolean
        Return False
    End Function

    ''' <summary>
    '''Auto Set Expose Time(Labsphere)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Measurement Stop
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function MeasureStop() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Device Active 
    ''' </summary>
    ''' <param name="nDeviceIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function DeviceActive(ByVal nDeviceIndex As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Device DeActive 
    ''' </summary>
    ''' <param name="nDeviceIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function DeviceDeActive(ByVal nDeviceIndex As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Ocean Optics LoadIrradianceFactor
    ''' </summary>
    ''' <param name="dData"></param>
    ''' <param name="outdata"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function LoadIrradianceFactor(ByVal dData() As Double, ByRef outdata As tData) As Boolean
        Return False
    End Function


    Public Overridable Function LoadTransferfunction(ByVal dData() As Double, ByRef outdata As tData) As Boolean
        Return False
    End Function

    Public Overridable Function Test() As Boolean
        Return False
    End Function


#End Region


    Protected Sub RaiseErrorEvent(ByVal errCode As Integer)
        RaiseEvent evError(errCode)
    End Sub

    Public Shared Function CalculateCIEParam(ByVal CIEx As Double, ByVal CIEy As Double) As sColorCIEParam
        Dim xe As Double = 0.332
        Dim ye As Double = 0.1858
        Dim n As Double = (CIEx - xe) / (CIEy - ye)

        Dim tempbblx3, tempbbly3 As Double
        Dim tempbblx2, tempbbly2 As Double
        Dim tempbblx1, tempbbly1 As Double
        Dim tempbblxConst, tempbblyConst As Double
        Dim tempbblxValueIndex, tempbblyValueIndex As Integer

        Dim sParams As sColorCIEParam

        Dim bblx3() As Double = New Double() {-0.2661239 * 10 ^ 9, -3.0258469 * 10 ^ 9}
        Dim bblx2() As Double = New Double() {-0.234358 * 10 ^ 6, 2.1070379 * 10 ^ 6}
        Dim bblx1() As Double = New Double() {0.8776956 * 10 ^ 3, 0.2226347 * 10 ^ 3}
        Dim bbly3() As Double = New Double() {-1.1063814, -0.9549476, 3.081758}
        Dim bbly2() As Double = New Double() {-1.3481102, -1.37418593, -5.8733867}
        Dim bbly1() As Double = New Double() {2.18555832, 2.09137015, 3.75112997}
        Dim bblxConst() As Double = New Double() {0.17991, 0.24039}
        Dim bblyConst() As Double = New Double() {-0.20219683, -0.16748867, -0.37001483}

        With sParams
            .CIEx = CIEx
            .CIEy = CIEy
            .CIE1960_u = 4 * CIEx / (3 + 12 * CIEy - 2 * CIEx)
            .CIE1960_v = 6 * CIEy / (3 + 12 * CIEy - 2 * CIEx)
            .CIE1976_ud = .CIE1960_u
            .CIE1976_vd = 3 / 2 * .CIE1960_v
            .CCT = (-449 * n ^ 3) + (3525 * n ^ 2) - (6823.3 * n) + 5520.33

            If .CCT < 4000 Then
                tempbblxValueIndex = 0
            Else
                tempbblxValueIndex = 1
            End If

            tempbblx3 = bblx3(tempbblxValueIndex)
            tempbblx2 = bblx2(tempbblxValueIndex)
            tempbblx1 = bblx1(tempbblxValueIndex)
            tempbblxConst = bblxConst(tempbblxValueIndex)

            .BBL_x = (tempbblx3 / .CCT ^ 3) + (tempbblx2 / .CCT ^ 2) + (tempbblx1 / .CCT + tempbblxConst)

            If .CCT < 2222 Then
                tempbblyValueIndex = 0
            ElseIf .CCT >= 2222 And .CCT < 4000 Then
                tempbblyValueIndex = 1
            ElseIf .CCT >= 4000 And .CCT < 25000 Then
                tempbblyValueIndex = 2
            Else
                tempbblyValueIndex = -1
            End If

            If tempbblyValueIndex <> -1 Then
                tempbbly3 = bbly3(tempbblyValueIndex)
                tempbbly2 = bbly2(tempbblyValueIndex)
                tempbbly1 = bbly1(tempbblyValueIndex)
                tempbblyConst = bblyConst(tempbblyValueIndex)

                .BBL_y = (tempbbly3 * .BBL_x ^ 3) + (tempbbly2 * .BBL_x ^ 2) + (tempbbly1 * .BBL_x) + tempbblyConst

            Else
                .BBL_y = 0
            End If


            .BBL_u = 4 * .BBL_x / (3 + 12 * .BBL_y - 2 * .BBL_x)
            .BBL_v = 6 * .BBL_y / (3 + 12 * .BBL_y - 2 * .BBL_x)

            Dim calCIEv As Double

            calCIEv = .CIE1960_v - .BBL_v

            If calCIEv < 0 Then
                .MPCD = -1 * Math.Sqrt((.CIE1960_u - .BBL_u) ^ 2 + (.CIE1960_v - .BBL_v) ^ 2) / 0.0005
            Else
                .MPCD = Math.Sqrt((.CIE1960_u - .BBL_u) ^ 2 + (.CIE1960_v - .BBL_v) ^ 2) / 0.0005
            End If

            .CIE1960_u = Format(.CIE1960_u, "0.0000")
            .CIE1960_v = Format(.CIE1960_v, "0.0000")
            .CIE1976_ud = Format(.CIE1976_ud, "0.0000")
            .CIE1976_vd = Format(.CIE1976_vd, "0.0000")
            .CCT = Format(.CCT, "0.0000")

        End With



        Return sParams

    End Function

End Class
