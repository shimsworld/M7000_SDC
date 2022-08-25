Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO.Ports
Imports System.Threading
Imports System.Convert
Imports CCommLib
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Image1


Public Class CDevUA_10
    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI
    Public imageProcess As Resistance = New Resistance





#Region "Defines"
    Private m_UaDevice As UaDevice
    Private m_UaSystem As UaSystem
    Private m_xyzimage As UaXYZImage
    Private m_captureData As UaCaptureData
    Private m_DeviceProperty As UaDeviceProperty
    Private m_DevicePropertyPtr As IntPtr
    Private m_DevicePtr As IntPtr
    Private m_CaptureDataPtr As IntPtr
    Private m_XYZImagePtr As IntPtr
    Private m_ChromaticityPtr As IntPtr
    Private m_Image As IntPtr
    Private m_Recipe As UaRecipe
    Private m_sinfo As CDevSpectrometerCommonNode.DeviceOption
    Private m_Size_Width As Integer
    Private m_Size_Height As Integer
    Private m_Data As tDataArray

#End Region

#Region "Const"
    Const UA_SUCCESS = 1
    Const UA_FAILURE = 0
    Const UA_INVALID_VALUE = -1.0F
#End Region


    Public Overrides Function Connection() As Boolean
        Dim sParamPath As String = "E:\Components\Spectrometer\trunk\SpectrometerTester\param"
        Dim config_ua_10 As UaConfiguration = Nothing
        Dim device As UaDevice = Nothing
        Dim sVersion As String = ""

        'If GetVersion(sVersion) = False Then Return False

        'If Initialize(sParamPath, config_ua_10) = False Then Return False

        'If OpenDevice(config_ua_10.connected_product_ids(0), UaDeviceType.UA_TYPE_10_SL, device) = False Then Return False

        ' Dim ptr As Integer = UA10Connection(sParamPath)
        Dim ptr As IntPtr = UA10Connection(sParamPath)
        device = Marshal.PtrToStructure(ptr, GetType(UaDevice))

        If device.ip_address Is Nothing Then Return False

        '  If UA10Connection(sParamPath) = UA_FAILURE Then Return False


        m_UaDevice = device



        If GetDeviceInfos(m_sinfo) = False Then Return False

        Return True
    End Function

    Public Overrides Sub Disconnection()
        If DestroyXYZImage(m_xyzimage) = False Then Exit Sub
        If DestroyCaptureData(m_captureData) = False Then Exit Sub
        If CloseDevice(m_UaDevice) = False Then Exit Sub
        If Finalization(m_UaSystem) = False Then Exit Sub
    End Sub

    Public Overrides Function GetDeviceInfos(ByRef sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean
        Dim nAverageCount As Integer


        If CreateDeviceProperty(m_DeviceProperty) = False Then Return False
        sInfos.ua10Property = m_DeviceProperty

        If CreateRecipe(m_Recipe) = False Then Return False
        sInfos.ua10Recipe = m_Recipe

        If GetOptimumAverageCount(m_UaDevice, 0, m_DeviceProperty.exposure_time(1), nAverageCount, m_DevicePropertyPtr) = False Then Return False

        sInfos.NumOfAverage = nAverageCount

        m_sinfo = sInfos

        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption) As Boolean

        sInfos = m_sinfo
        Dim ptr As IntPtr = m_DevicePropertyPtr
        Marshal.StructureToPtr(sInfos.ua10Property, ptr, False)

        If uaSetDeviceProperty(m_UaDevice, sInfos.ua10Property) = False Then Return False

        m_DeviceProperty = sInfos.ua10Property
        m_sinfo = sInfos
        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As CDevSpectrometerCommonNode.tDataArray, ByRef image As Bitmap) As Boolean
        Dim dCaptureData As UaCaptureData = Nothing
        Dim dXYZImage As UaXYZImage = Nothing
        Dim dImage As UaImage = Nothing
        Dim dChromaticityImage As UaChromaticityImage = Nothing
        Dim dColorTemp As UaImage = Nothing
        Dim dDuv As UaImage = Nothing

        Dim X() As Double = Nothing
        Dim Y() As Double = Nothing
        Dim Z() As Double = Nothing
        Dim xx() As Double = Nothing
        Dim yy() As Double = Nothing
        Dim uu() As Double = Nothing
        Dim vv() As Double = Nothing
        Dim ctemp() As Double = Nothing
        Dim duvdata() As Double = Nothing
        Dim bCaptureImage As Image = Nothing
        Dim bImage As Bitmap = Nothing
        Dim bImageData As BitmapData = Nothing
        Dim nAverageCount As Integer
        Dim bImagePicture As PictureBox = Nothing

        If GetOptimumAverageCount(m_UaDevice, 0, m_DeviceProperty.exposure_time(1), nAverageCount, m_DevicePropertyPtr) = False Then Return False

        If CreateCaptureData(UaDeviceType.UA_TYPE_10_SL, dCaptureData) = False Then Return False
        If CreateChromaticityImage(UaDeviceType.UA_TYPE_10_SL, dChromaticityImage) = False Then Return False
        If CreateXYZImage(UaDeviceType.UA_TYPE_10_SL, UaDataType.eUA_DATA_TRISTIMULUS_XYZ, dXYZImage) = False Then Return False
        If CreateImage(dCaptureData.width, dCaptureData.height, dImage) = False Then Return False

        If StartCapture(m_UaDevice) = False Then Return False
        If CaptureImage(m_UaDevice, dCaptureData, UaCaptureFilterType.eUA_CAPTURE_FILTER_XYZ, 1, dCaptureData) = False Then Return False
        m_Size_Height = dCaptureData.height
        m_Size_Width = dCaptureData.width

        Dim lBitmap As Bitmap = New Bitmap(m_Size_Width, m_Size_Height, PixelFormat.Format24bppRgb)
        Dim lRect As Rectangle = New Rectangle(New Point(0, 0), New Size(m_Size_Width, m_Size_Height))
        Dim lData As BitmapData = lBitmap.LockBits(lRect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)

        ReDim m_Data.D1(m_Size_Width - 1, m_Size_Height - 1)
        ReDim m_Data.D2(m_Size_Width - 1, m_Size_Height - 1)
        ReDim m_Data.D3(m_Size_Width - 1, m_Size_Height - 1)
        ReDim m_Data.D4(m_Size_Width - 1, m_Size_Height - 1)
        ReDim m_Data.D5(m_Size_Width - 1, m_Size_Height - 1)
        ReDim m_Data.D6(m_Size_Width - 1, m_Size_Height - 1)
        Thread.Sleep(200)
        If ToXYZImage(m_UaDevice, dXYZImage, X, Y, Z) = False Then Return False
        If ToChromaticityImage(dXYZImage, dChromaticityImage, xx, yy, uu, vv) = False Then Return False
        If ComputeColorTempAndDuvImage(dChromaticityImage, dColorTemp, dDuv, ctemp, duvdata) = False Then Return False

        Try
            lBitmap.UnlockBits(lData)
            Dim r As Integer
            Dim g As Integer
            Dim b As Integer
            For y1 As Integer = 0 To m_Size_Height - 1
                For x1 As Integer = 0 To m_Size_Width - 1
                    YUV2RGB(CInt(Y(y1 * m_Size_Width + x1)), CSng(uu(y1 * m_Size_Width + x1)), CSng(vv(y1 * m_Size_Width + x1)), r, g, b)
                    '  YUV2RGB(CInt(Y(y1 * m_Size_Width + x1)), CSng(2 / 3 * Y(y1 * m_Size_Width + x1)), CSng(Y(y1 * m_Size_Width + x1)), r, g, b)
                    ' XYZ2RGB(CInt(X(y1 * m_Size_Width + x1)), CInt(Y(y1 * m_Size_Width + x1)), CInt(Z(y1 * m_Size_Width + x1)), r, g, b)
                    lBitmap.SetPixel(x1, y1, Color.FromArgb(r, g, b))
                Next
            Next
            image = lBitmap.Clone(lRect, PixelFormat.Format24bppRgb)
            lBitmap.Save(Application.StartupPath & "\1.jpg")
            lBitmap.Dispose()
        Catch ex As Exception
            image = lBitmap.Clone(lRect, PixelFormat.Format24bppRgb)
            lBitmap.Save(Application.StartupPath & "\1.jpg")
            lBitmap.Dispose()
        End Try




        Resistance.Anal(Application.StartupPath & "\1.jpg", bImage)

        image = bImage.Clone()

        If StopCapture(m_UaDevice) = False Then Return False
        If DestroyXYZImage(dXYZImage) = False Then Return False
        If DestroyChromaticityImage(dChromaticityImage) = False Then Return False
        If DestroyCaptureData(dCaptureData) = False Then Return False


        outData = m_Data

        Return True
    End Function

    Public Sub YUV2RGB(ByVal Y As Integer, ByVal U As Single, ByVal V As Single, ByRef R As Integer, ByRef G As Integer, ByRef B As Integer)

        '   U -= 128
        '   V -= 128

        ' Conversion (clamped to 0..255)
        Try


            R = Math.Min(Math.Max(0, CInt(Y + 1.14 * CSng(V))), 255)
            G = Math.Min(Math.Max(0, CInt(Y - 0.395 * CSng(U) - 0.581 * CSng(V))), 255)
            B = Math.Min(Math.Max(0, CInt(Y + 2.032 * CSng(U))), 255)

            'R = Math.Min(Math.Max(0, CInt(Y + 1.370705 * CSng(V))), 255)
            'G = Math.Min(Math.Max(0, CInt(Y - 0.698001 * CSng(V) - 0.337633 * CSng(U))), 255)
            'B = Math.Min(Math.Max(0, CInt(Y + 1.732446 * CSng(U))), 255)
        Catch ex As Exception
            R = 0
            G = 0
            B = 0
        End Try

    End Sub

    Public Sub XYZ2RGB(ByVal X As Integer, ByVal Y As Single, ByVal Z As Single, ByRef R As Integer, ByRef G As Integer, ByRef B As Integer)

        'U -= 128
        'V -= 128

        ' Conversion (clamped to 0..255)
        Try

            R = 3.2406 * X - 1.5372 * Y - 0.4986 * Z
            G = -0.9689 * X + 1.8758 * Y + 0.0415 * Z
            B = 0.0557 * X - 0.204 * Y + 1.057 * Z

            '  R = Math.Min(Math.Max(0, CInt(Y + 1.14 * CSng(V))), 255)
            '   G = Math.Min(Math.Max(0, CInt(Y - 0.395 * CSng(U) - 0.581 * CSng(V))), 255)
            '  B = Math.Min(Math.Max(0, CInt(Y + 2.032 * CSng(U))), 255)

            'R = Math.Min(Math.Max(0, CInt(Y + 1.370705 * CSng(V))), 255)
            'G = Math.Min(Math.Max(0, CInt(Y - 0.698001 * CSng(V) - 0.337633 * CSng(U))), 255)
            'B = Math.Min(Math.Max(0, CInt(Y + 1.732446 * CSng(U))), 255)
        Catch ex As Exception
            R = 0
            G = 0
            B = 0
        End Try

    End Sub
    Public Function GetVersion(ByRef sVer As String) As Boolean
        Dim sVersion As String
        Try
            sVersion = Marshal.PtrToStringAnsi(uaGetVersion())
            sVer = sVersion
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetErrorString(ByVal index As Integer, ByRef serror As String) As Boolean
        Dim errorIntptr As IntPtr

        Try
            errorIntptr = uaGetErrorString(index)
            serror = Marshal.PtrToStringAnsi(errorIntptr)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function Initialize(ByVal sPath As String, ByRef config_ua_10 As UaConfiguration) As Boolean
        Dim sInstallProductID As String = ""
        Dim sConnectProductID As String = ""
        Try
            Dim system_ptr As IntPtr = uaInitialize(sPath)
            Dim system As UaSystem = Marshal.PtrToStructure(system_ptr, GetType(UaSystem))
            config_ua_10 = Marshal.PtrToStructure(system.ua_10, GetType(UaConfiguration))

            If config_ua_10.num_connected = 0 Then
                MsgBox("Failed to Connected Detector.")
                Return False
            End If

            Dim i As Integer
            For i = 0 To config_ua_10.num_installed - 1
                sInstallProductID = (config_ua_10.installed_product_ids(i))
            Next

            For i = 0 To config_ua_10.num_connected - 1
                sConnectProductID = (config_ua_10.connected_product_ids(i))
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function OpenDevice(ByVal connected_Product_id As String, ByVal type As UaDeviceType, ByRef device As UaDevice) As Boolean

        Try
            Dim device_ptr As IntPtr = uaOpenDevice(connected_Product_id, type)
            device = Marshal.PtrToStructure(device_ptr, GetType(UaDevice))
            m_DevicePtr = device_ptr
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function Finalization(ByVal system As UaSystem) As Boolean
        Try
            If uaFinalize(system) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CloseDevice(ByVal device As UaDevice) As Boolean

        Try
            If uaCloseDevice(device) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function StartCapture(ByVal device As UaDevice) As Boolean
        Try
            If UA10StartCapture(device) <> UA_SUCCESS Then Return False

            '   If uaStartCapture(m_DevicePtr) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function StopCapture(ByVal device As UaDevice) As Boolean
        Try
            If UA10StopCapture(device) <> UA_SUCCESS Then Return False
            '    If uaStopCapture(device) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateRecipe(ByRef recipe As UaRecipe) As Boolean
        Try
            Dim recipe_ptr As IntPtr = UA10CreateRecipe(UaDeviceType.UA_TYPE_10_SL)
            recipe = Marshal.PtrToStructure(recipe_ptr, GetType(UaRecipe))
            'Dim recipe_ptr As IntPtr = uaCreateRecipe()
            'recipe = Marshal.PtrToStructure(recipe_ptr, GetType(UaRecipe))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateDeviceProperty(ByRef device_property As UaDeviceProperty) As Boolean
        Try

            Dim deviceproperty_ptr As IntPtr = UA10CreateProperty(UaDeviceType.UA_TYPE_10_SL)
            device_property = Marshal.PtrToStructure(deviceproperty_ptr, GetType(UaDeviceProperty))
            'Dim deviceproperty_ptr As IntPtr = uaCreateDeviceProperty(UaDeviceType.UA_TYPE_10_SL)
            'device_property = Marshal.PtrToStructure(deviceproperty_ptr, GetType(UaDeviceProperty))
            m_DevicePropertyPtr = deviceproperty_ptr
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyDeviceProperty(ByVal device As UaDeviceProperty) As Boolean
        Try
            If uaDestroyDeviceProperty(device) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetDeviceProperty(ByVal device As UaDevice, ByVal dProperty As UaDeviceProperty) As Boolean
        Try
            Dim deviceproperty_ptr As IntPtr = uaGetDeviceProperty(device)
            dProperty = Marshal.PtrToStructure(deviceproperty_ptr, GetType(UaDeviceProperty))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    'Public Function SetDeviceProperty(ByVal device As UaDevice, ByVal dProperty As UaDeviceProperty) As Boolean
    '    Dim Ptr As IntPtr
    '    Ptr = m_DevicePropertyPtr
    '    Try
    '        If uaSetDeviceProperty(device, dProperty) <> UA_SUCCESS Then Return False
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    Return True
    'End Function

    Public Function OptimizeDeviceProperty(ByVal device As UaDevice, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Boolean
        Try
            Dim dPropertyptr As IntPtr
            If uaOptimizeDeviceProperty(device, condition, dPropertyptr) <> UA_SUCCESS Then Return False
            dproperty = Marshal.PtrToStructure(dPropertyptr, GetType(UaDeviceProperty))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function OptimizeDevicePropertyFreq(ByVal device As UaDevice, ByVal nfreq As Integer, ByVal condition As UaOptimizationCondition, ByRef dProperty As UaDeviceProperty) As Boolean
        Try
            If uaOptimizeDevicePropertyFreq(device, nfreq, condition, dProperty) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function OptimizeDevicePropertyROI(ByVal device As UaDevice, ByVal roi As UaRect, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Boolean
        Try
            If uaOptimizeDevicePropertyROI(device, roi, condition, dproperty) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function OptimizeDevicePropertyROIFreq(ByVal device As UaDevice, ByVal roi As UaRect, ByVal nFreq As Integer, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Boolean
        Try
            If uaOptimizeDevicePropertyROIFreq(device, roi, nFreq, condition, dproperty) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyRecipe(ByRef recipe As UaRecipe) As Boolean
        Try
            If uaDestroyRecipe(recipe) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetOptimumAverageCount(ByVal device As UaDevice, ByVal target_freq_hz As Integer, ByVal exposeTime As Double, ByRef averge_count As Integer, ByVal dproperty_ptr As IntPtr) As Boolean
        Try

            averge_count = UA10GetOptimumAverageCount(device, target_freq_hz, exposeTime, dproperty_ptr)

            '       If uaGetOptimumAverageCount(device, target_freq_hz, exposeTime, averge_count) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CaptureImage(ByVal device As UaDevice, ByVal data As UaCaptureData, ByVal filter_type As UaCaptureFilterType, ByVal averge_count As Integer, ByRef redata As UaCaptureData) As Boolean
        Try
            Dim XDATA(1228799) As UShort
            Dim YDATA(1228799) As UShort
            Dim ZDATA(1228799) As UShort
            '  Dim nReturn As Integer
            '
            Dim ptr As IntPtr = m_CaptureDataPtr
            If UA10CaptureImage(device, ptr, filter_type, averge_count) <> UA_SUCCESS Then Return False
            redata = Marshal.PtrToStructure(ptr, GetType(UaCaptureData))

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateImage(ByVal width As Integer, ByVal height As Integer, ByRef image As UaImage) As Boolean
        Try
            Dim Image_ptr As IntPtr = UA10CreateImage(width, height)
            image = Marshal.PtrToStructure(Image_ptr, GetType(UaImage))
            m_Image = Image_ptr
            '   If uaCreateImage(width, height) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateCaptureData(ByVal device_type As UaDeviceType, ByRef data As UaCaptureData) As Boolean
        Try

            '     data = UA10CreateCaptureData(device_type)

            Dim data_ptr As IntPtr = UA10CreateCaptureData(device_type)
            data = Marshal.PtrToStructure(data_ptr, GetType(UaCaptureData))
            m_CaptureDataPtr = data_ptr
            'Dim data_ptr As IntPtr = uaCreateCaptureData(device_type)
            'data = Marshal.PtrToStructure(data_ptr, GetType(UaCaptureData))
            'm_CaptureDataPtr = data_ptr
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyCaptureData(ByVal data As UaCaptureData) As Boolean
        Try
            If UA10DestroyCaptureData(m_CaptureDataPtr) <> UA_SUCCESS Then Return False
            data = Marshal.PtrToStructure(m_CaptureDataPtr, GetType(UaCaptureData))
            '    If uaDestroyCaptureData(data) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateXYZImage(ByVal type As UaDeviceType, ByVal data_type As UaDataType, ByRef xyzimage As UaXYZImage) As Boolean

        Try

            Dim xyzimage_ptr As IntPtr = UA10CreateXYZImage(type, data_type)
            xyzimage = Marshal.PtrToStructure(xyzimage_ptr, GetType(UaXYZImage))
            m_XYZImagePtr = xyzimage_ptr
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyXYZImage(ByVal xyz_image As UaXYZImage) As Boolean
        Try

            If UA10DestroyXYZImage(m_XYZImagePtr) <> UA_SUCCESS Then Return False
            xyz_image = Marshal.PtrToStructure(m_XYZImagePtr, GetType(UaXYZImage))
            '   If uaDestroyXYZImage(xyz_image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateChromaticityImage(ByVal device_type As UaDeviceType, ByRef dChromaticityimage As UaChromaticityImage) As Boolean
        Try
            Dim Chromaticity_ptr As IntPtr = UA10CreateChromaticityImage(device_type)
            dChromaticityimage = Marshal.PtrToStructure(Chromaticity_ptr, GetType(UaChromaticityImage))
            m_ChromaticityPtr = Chromaticity_ptr
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyChromaticityImage(ByVal dChromaticityimage As UaChromaticityImage) As Boolean
        Try

            If UA10DestroyChromaticityImage(m_ChromaticityPtr) <> UA_SUCCESS Then Return False
            dChromaticityimage = Marshal.PtrToStructure(m_ChromaticityPtr, GetType(UaChromaticityImage))
            '   If uaDestroyXYZImage(xyz_image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestroyImage(ByVal image As UaImage) As Boolean
        Try
            If uaDestroyImage(image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SaveMeasurementData(ByVal path As String, ByVal file_name As String, ByVal xyz_image As UaXYZImage, ByVal recipe As UaRecipe) As Boolean
        Try
            If uaSaveMeasurementData(path, file_name, xyz_image, recipe) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function LoadMeasurementData(ByVal file_path As String, ByRef xyz_image As UaXYZImage, ByRef recipe As UaRecipe) As Boolean
        Try
            If uaLoadMeasurementData(file_path, xyz_image, recipe) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ToXYZImage(ByVal device As UaDevice, ByRef xyzimage As UaXYZImage, ByRef XXdata() As Double, ByRef YYdata() As Double, ByRef ZZdata() As Double) As Boolean
        Dim xBufData(1228799) As Single
        Dim yBufData(1228799) As Single
        Dim zBufData(1228799) As Single
        Dim ptrCapture As IntPtr = m_CaptureDataPtr
        Dim ptrXYZimage As IntPtr = m_XYZImagePtr
        '  Dim ptrY As IntPtr


        Try
            If UA10XYZImage(device, ptrCapture, ptrXYZimage, xBufData(0), yBufData(0), zBufData(0)) <> UA_SUCCESS Then Return False
            '      Dim rreturn As Integer = UA10CorrectColor(device, ptrXYZimage, UaColorCorrectionType.eUA_NO_COLOR_CORRECTION, xBufData(0), yBufData(0), zBufData(0))
            '  If CorrectColor(device, ptrXYZimage, UaColorCorrectionType.eUA_NO_COLOR_CORRECTION, xBufData, yBufData, zBufData) = False Then Return False

            ConvertToDoubleArray(xBufData, XXdata)
            ConvertToDoubleArray(yBufData, YYdata)
            ConvertToDoubleArray(zBufData, ZZdata)

            xyzimage = Marshal.PtrToStructure(ptrXYZimage, GetType(UaXYZImage))

            For y1 As Integer = 0 To m_Size_Height - 1
                For x1 As Integer = 0 To m_Size_Width - 1
                    m_Data.D6(x1, y1).s2YY = YYdata(y1 * m_Size_Width + x1)
                    m_Data.D2(x1, y1).s2XX = XXdata(y1 * m_Size_Width + x1)
                    m_Data.D2(x1, y1).s3YY = YYdata(y1 * m_Size_Width + x1)
                    m_Data.D2(x1, y1).s4ZZ = ZZdata(y1 * m_Size_Width + x1)

                Next
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CorrectXYZImageLevel(ByVal xyz_image As UaXYZImage, ByVal X_factor As Single, ByVal Y_factor As Single, ByVal Z_factor As Single) As Boolean
        Try
            If uaCorrectXYZImageLevel(xyz_image, X_factor, Y_factor, Z_factor) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CorrectColor(ByVal device As UaDevice, ByVal xyz_image As IntPtr, ByVal type As UaColorCorrectionType, ByRef XXdata() As Single, ByRef YYdata() As Single, ByRef ZZdata() As Single) As Boolean
        Dim xBufData(1228799) As Single
        Dim yBufData(1228799) As Single
        Dim zBufData(1228799) As Single
        Dim ptrXYZimage As IntPtr = m_XYZImagePtr
        Try

            '   If uaCorrectColor(device, xyz_image, type) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ComputeAverageOfGrid(ByVal src_image As Single, ByVal image_width As Integer, ByVal image_height As Integer, ByVal num_partitions_x As Integer, ByVal num_partitions_y As Integer, ByRef dst_image As UaImage) As Boolean
        Try
            If uaComputeAverageOfGrid(src_image, image_width, image_height, num_partitions_x, num_partitions_y, dst_image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function LoadAreaCorrection(ByVal filename As String, ByRef area_coef_x As UaImage, ByRef area_coef_y As UaImage, ByRef area_coef_z As UaImage) As Boolean
        Try
            If uaLoadAreaCorrection(filename, area_coef_x, area_coef_y, area_coef_z) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CorrectArea(ByVal xyz_image As UaXYZImage, ByVal area_coef_x As UaImage, ByVal area_coef_y As UaImage, ByVal area_coef_z As UaImage) As Boolean
        Try
            If uaCorrectArea(xyz_image, area_coef_x, area_coef_y, area_coef_z) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CorrectSpot(ByVal spot_correction_filename As String, ByVal xyz_image As UaXYZImage) As Boolean
        Try
            If uaCorrectSpot(spot_correction_filename, xyz_image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ToChromaticity(ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal color_space_type As UaColorSpaceType, ByRef chromaticity As UaChromaticity) As Boolean
        Try
            If uaToChromaticity(X, Y, Z, color_space_type, chromaticity) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ToChromaticityImage(ByVal xyz_image As UaXYZImage, ByRef chromaticity As UaChromaticityImage, ByRef xData() As Double, ByRef yData() As Double, ByRef uData() As Double, ByRef vData() As Double) As Boolean

        Dim xBufData(1228799) As Single
        Dim yBufData(1228799) As Single
        Dim uBufData(1228799) As Single
        Dim vBufData(1228799) As Single

        Try
            Dim ptr As IntPtr = m_ChromaticityPtr
            Dim xyzimageptr As IntPtr = m_XYZImagePtr
            If UA10ChromaticityImage(xyzimageptr, UaColorSpaceType.eUA_COLOR_SPACE_CIE1931_XYZ, m_ChromaticityPtr, xBufData(0), yBufData(0)) <> UA_SUCCESS Then Return False
            chromaticity = Marshal.PtrToStructure(ptr, GetType(UaChromaticityImage))

            If UA10ChromaticityImage(xyzimageptr, UaColorSpaceType.eUA_COLOR_SPACE_CIE1976_LUV, m_ChromaticityPtr, uBufData(0), vBufData(0)) <> UA_SUCCESS Then Return False
            chromaticity = Marshal.PtrToStructure(ptr, GetType(UaChromaticityImage))

            ConvertToDoubleArray(xBufData, xData)
            ConvertToDoubleArray(yBufData, yData)
            ConvertToDoubleArray(uBufData, uData)
            ConvertToDoubleArray(vBufData, vData)

            For y1 As Integer = 0 To m_Size_Height - 1
                For x1 As Integer = 0 To m_Size_Width - 1
                    m_Data.D6(x1, y1).s3xx = xData(y1 * m_Size_Width + x1)
                    m_Data.D6(x1, y1).s4yy = yData(y1 * m_Size_Width + x1)
                    m_Data.D6(x1, y1).s5uu = uData(y1 * m_Size_Width + x1)
                    m_Data.D6(x1, y1).s6vv = vData(y1 * m_Size_Width + x1)
                Next
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ComputeColorTempAndDuv(ByVal uv As UaChromaticity, ByRef color_Temp As Double, ByRef duv As Double) As Boolean
        Try
            If uaComputeColorTempAndDuv(uv, color_Temp, duv) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ComputeColorTempAndDuvImage(ByVal uv As UaChromaticityImage, ByRef color_temp As UaImage, ByRef duv As UaImage, ByRef color_tempData() As Double, ByRef duvData() As Double) As Boolean
        Try
            Dim xBufData(1228799) As Single
            Dim yBufData(1228799) As Single
            Dim ptr As IntPtr = m_ChromaticityPtr
            Dim ptr_imagecolortemp As IntPtr = m_Image
            Dim ptr_imageduv As IntPtr = m_Image
            If UA10ComputeColorTempAndDuvImage(ptr, ptr_imagecolortemp, ptr_imageduv, xBufData(0), yBufData(0)) <> UA_SUCCESS Then Return False

            color_temp = Marshal.PtrToStructure(ptr_imagecolortemp, GetType(UaImage))
            duv = Marshal.PtrToStructure(ptr_imageduv, GetType(UaImage))

            For y1 As Integer = 0 To m_Size_Height - 1
                For x1 As Integer = 0 To m_Size_Width - 1
                    m_Data.D4(x1, y1).s3KelvinT = xBufData(y1 * m_Size_Width + x1)
                    m_Data.D4(x1, y1).s4DevOfColorCoord = yBufData(y1 * m_Size_Width + x1)
                Next
            Next
            'If uaComputeColorTempAndDuvImage(uv, color_temp, duv) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ComputeWavelengthAndPurity(ByVal xy As UaChromaticity, ByVal ref_white_point As UaPoint, ByRef wavelength As Double, ByRef purity As Double) As Boolean
        Try
            If uaComputeWavelengthAndPurity(xy, ref_white_point, wavelength, purity) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ComputeWavelengthAndPurityImage(ByVal xy As UaChromaticityImage, ByVal ref_white_point As UaPoint, ByRef wavelength As UaImage, ByRef purity As UaImage) As Boolean
        Try
            If uaComputeWavelengthAndPurityImage(xy, ref_white_point, wavelength, purity) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CreateSpotList(ByVal size As Integer, ByRef spot_list As UaSpotList) As Boolean
        Try
            Dim spot_ptr As IntPtr = uaCreateSpotList(size)
            spot_list = Marshal.PtrToStructure(spot_ptr, GetType(UaSpotList))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DestorySpotList(ByVal spot_list As UaSpotList) As Boolean
        Try
            If uaDestroySpotList(spot_list) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetCircleSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal center As UaPoint, ByVal threshold_x As Double, ByVal threshold_y As Double, ByVal threshold_z As Double) As Boolean
        Try
            If uaSetCircleSpot(spot_list, index, spot_id, center, threshold_x, threshold_y, threshold_z) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetSqureSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal center As UaPoint, ByVal threshold_x As Double, ByVal threshold_y As Double, ByVal threshold_z As Double) As Boolean
        Try
            If uaSetSqureSpot(spot_list, index, spot_id, center, threshold_x, threshold_y, threshold_z) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetPolygonSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal point_data As UaPoint, ByVal point_size As Integer, ByVal threshold_x As Double, ByVal threshold_y As Double, ByVal threshold_z As Double) As Boolean
        Try
            If uaSetPolygonSpot(spot_list, index, spot_id, point_data, point_size, threshold_x, threshold_y, threshold_z) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function LoadSpotList(ByVal filename As String, ByRef spot_list As UaSpotList) As Boolean
        Try
            Dim spot_ptr As IntPtr = uaLoadSpotList(filename)
            spot_list = Marshal.PtrToStructure(spot_ptr, GetType(UaSpotList))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetSpot(ByVal xyz_image As UaXYZImage, ByVal spot As UaSpot) As Boolean
        Try
            If uaGetSpot(xyz_image, spot) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetSpotList(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList) As Boolean
        Try
            If uaGetSpotList(xyz_image, spot_list) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetMaskedSpot(ByVal xyz_image As UaXYZImage, ByVal spot As UaSpot) As Boolean
        Try
            If uaGetMaskedSpot(xyz_image, spot) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetMaskedSpotList(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList) As Boolean
        Try
            If uaGetMaskedSpotList(xyz_image, spot_list) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function MaskXYZImageWithSpot(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList, ByVal mask_mode As UaImageMaskMode, ByRef result_image As UaXYZImage) As Boolean
        Try
            If uaMaskXYZImageWithSpot(xyz_image, spot_list, mask_mode, result_image) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function LoadRecipe(ByVal filename As String, ByRef recipe As UaRecipe) As Boolean
        Try
            Dim recipe_ptr As IntPtr = uaLoadRecipe(filename)
            recipe = Marshal.PtrToStructure(recipe_ptr, GetType(UaRecipe))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SaveRecipe(ByVal recipe As UaRecipe, ByVal filename As String) As Boolean
        Try
            If uaSaveRecipe(recipe, filename) <> UA_SUCCESS Then Return False
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function ConvertToDoubleArray(ByVal inData() As Single, ByRef outData() As Double) As Boolean
        Dim dataBuf(inData.Length - 1) As Double
        If inData Is Nothing Then Return False
        For i As Integer = 0 To inData.Length - 1
            dataBuf(i) = Convert.ToDouble(inData(i))
        Next
        outData = dataBuf.Clone()
        Return True
    End Function


    Public Function Scale_exter(ByVal inPixelsX() As Double, ByVal inPixelsY() As Double, ByVal inPixelsZ() As Double) As Image
        Dim bmpCropped As New Bitmap(m_Size_Width, m_Size_Height, Imaging.PixelFormat.Format8bppIndexed)
        Dim Value As Integer = 0
        Dim rImage As Image = Nothing
        For y1 As Integer = 0 To m_Size_Height - 1
            For x1 As Integer = 0 To m_Size_Width - 1
                Application.DoEvents()
                Try

                    bmpCropped.SetPixel(x1, y1, Color.FromArgb(Convert.ToInt32(inPixelsX(y1 * m_Size_Width + x1)), Convert.ToInt32(inPixelsY(y1 * m_Size_Width + x1)), Convert.ToInt32(inPixelsZ(y1 * m_Size_Width + x1))))
                    '    frmMain.UcframePG1.TextBox3.Text = frmMain.UcframePG1.TextBox3.Text & CStr(y1 * m_Size_Width + x1 * 3 + 0) & "," & CStr(y1 * m_Size_Width + x1 * 3 + 1) & "," & CStr(y1 * m_Size_Width + x1 * 3 + 2) & vbCrLf

                Catch ex As Exception
                    Return rImage
                End Try
            Next
        Next

        Return bmpCropped

    End Function

End Class

