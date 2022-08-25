Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

#Region "Ua_core2. Enums"

Public Enum UaDeviceType
    UA_TYPE_10_SL = 100
    UA_TYPE_10_SH = 101
    UA_TYPE_10_WL = 102
    UA_TYPE_10_WH = 103
    UA_TYPE_200_S = 201
    UA_TYPE_200_WS = 202
End Enum

Public Enum UaError
    eUA_NO_ERROR
    eUA_NO_PARAMETER_FILE
    eUA_CANNOT_LOAD_PARAMETER_FILE
    eUA_NO_CONNECTABLE_DEVICE
    eUA_NULL_POINTER_ERROR
    eUA_INVALID_ARGUMENT
    eUA_CANNOT_CONNECT_TO_DEVICE
    eUA_CANNOT_FIND_THE_FILE
    eUA_MEMORY_ERROR
    eUA_INVALID_PATH
    eUA_INVALID_OPERATION
    eUA_CANNOT_START_CAPTURE
    eUA_CANNOT_STOP_CAPTURE
    eUA_CANNOT_COMMUNICATE_WITH_DETECTOR
End Enum

Public Enum UaDataType
    eUA_DATA_TRISTMULUS_X = 1
    eUA_DATA_TRISTMULUS_Y = 2
    eUA_DATA_TRISTMULUS_Z = 4
    eUA_DATA_CHROMATICITY_X = 8
    eUA_DATA_CHROMATICITY_Y = 10
    eUA_DATA_CHROMATICITY_U = 20
    eUA_DATA_CHROMATICITY_V = 40
    eUA_DATA_COLOR_TEMPERATURE = 80
    eUA_DATA_DUV = 100
    eUA_DATA_DOMINANT_WAVELENGTH = 200
    eUA_DATA_EXCITATION_PURITY = 400
    eUA_DATA_TRISTIMULUS_XYZ = 7
    eUA_DATA_CHROMATICITY_XY = 18
    eUA_DATA_CHROMATICITY_UV = 60
    eUA_DATA_COLOR_TEMP_DUV = 180
    eUA_DATA_WAVELENGTH_PURITY = 600
    eUA_DATA_ALL = 2047
End Enum

Public Enum UaColorSpaceType
    eUA_COLOR_SPACE_CIE1931_XYZ
    eUA_COLOR_SPACE_CIE1976_LUV
End Enum

Public Enum UaWhitePointType
    eUA_WHITE_POINT_A
    eUA_WHITE_POINT_B
    eUA_WHITE_POINT_C
    eUA_WHITE_POINT_D65
End Enum

Public Enum UaBinningType
    eUA_BINNING_IXI
End Enum

Public Enum UaNDFilterType
    eUA_NO_ND_FILTER = 1
    eUA_ND_FILTER_ONE_TENTH
End Enum

Public Enum UaLensType
    eUA_LENS_WIDE
    eUA_LENS_STANDARD
End Enum

Public Enum UaCaptureMode
    eUA_CAPTURE_MANUAL
    eUA_CAPTURE_LIVE
End Enum

Public Enum UaCaptureFilterType
    eUA_CAPTURE_FILTER_X = 1
    eUA_CAPTURE_FILTER_Y = 2
    eUA_CAPTURE_FILTER_Z = 4
    eUA_CAPTURE_FILTER_XY = 3
    eUA_CAPTURE_FILTER_XZ = 5
    eUA_CAPTURE_FILTER_YZ = 6
    eUA_CAPTURE_FILTER_XYZ = 7
End Enum

Public Enum UaImageMaskMode
    eUA_IMAGE_MASK_VALUE
    eUA_IMAGE_MASK_LABEL
End Enum

Public Enum UaColorCorrectionType
    eUA_COLOR_CORRECTION_CCFL
    eUA_COLOR_CORRECTION_LED
    eUA_NO_COLOR_CORRECTION
End Enum

Public Enum UaSpotShape
    eUA_SPOT_SHAPE_CIRCLE
    eUA_SPOT_SHAPE_SQUARE
End Enum

Public Enum UaOptimizationCondition
    eUA_OPTIMIZE_COND_GAIN_FIX_ND_FIX
    eUA_OPTIMIZE_COND_GAIN_FIX_ND_OPTIMUM
    eUA_OPTIMIZE_COND_GAIN_OPTIMUM_ND_FIX
    eUA_OPTIMIZE_COND_GAIN_OPTIMUM_ND_OPTIMUM
End Enum
#End Region

#Region "Ua_core2. Structures"
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaConfiguration
    Public num_installed As Integer
    Public num_connected As Integer
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    Public installed_product_ids() As String
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    Public connected_product_ids() As String
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaSystem
    Public ua_10 As IntPtr
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaDevice
    Public type As UaDeviceType
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
    Public product_id() As Byte
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> _
    Public mac_address() As Byte
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    Public ip_address() As Byte
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    Public subnet_mask() As Byte
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    Public default_gateway() As Byte
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaDeviceProperty
    Public device_type As UaDeviceType
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
    Public product_id() As Byte
    Public capture_mode As UaCaptureMode
    Public binning_type As UaBinningType
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    Public gain() As Integer
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    Public aperture() As UaNDFilterType
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    Public exposure_time() As Double
    Public measurement_distance As Integer
    '<MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    'Public nd_filter() As UaNDFilterType
    Public lens_type As UaLensType
    ' Public internal_obj As IntPtr
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaPoint
    Public x As Double
    Public y As Double
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaSize64f
    Public width As Double
    Public height As Double
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaRecipe
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
    Public comment() As Byte
    Public average_auto As Integer
    Public exposure_auto As Integer
    Public average_count As Integer
    Public frequency As Integer
    Public use_frequency As Integer
    Public capture_filter_type As UaCaptureFilterType
    Public color_correction_type As UaColorCorrectionType
    Public optimization_condition As UaOptimizationCondition
    Public device_property As IntPtr
    Public reference_white_point As UaPoint
    Public internal_obj As IntPtr
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaCaptureData
    Public width As Integer
    Public height As Integer
    Public size As Integer
    Public X As Single
    Public Y As Single
    Public Z As Single
    Public device_Property As IntPtr
    Public area As UaSize64f
    Public resolution As UaSize64f
    Public timestamp As ULong
    Public internal_obj As IntPtr
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaChromaticity
    Public type As UaColorSpaceType
    Public x As Double
    Public y As Double
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaChromaticityImage
    Public type As UaColorSpaceType
    Public width As Integer
    Public height As Integer
    Public size As Integer
    Public x As Single
    Public y As Single
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaImage
    Public width As Integer
    Public height As Integer
    Public size As Integer
    Public data As Double
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaRect
    Public x As Integer
    Public y As Integer
    Public width As Integer
    Public height As Integer
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaSize
    Public width As Integer
    Public height As Integer
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaSpot
    Public id As Integer
    Public shape As UaSpotShape
    Public x As Integer
    Public y As Integer
    Public width As Single
    Public height As Single
    Public point_data As IntPtr
    Public point_size As Integer
    Public threshold_x As Single
    Public threshold_y As Single
    Public threshold_z As Single
    Public LX As Single
    Public LY As Single
    Public LZ As Single
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaSpotList
    Public size As Integer
    Public data As IntPtr
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
Public Structure UaXYZImage
    Public width As Integer
    Public height As Integer
    Public size As Integer
    Public LX As Single
    Public LY As Single
    Public LZ As Single
    Public device_property As IntPtr
    Public area As UaSize64f
    Public resolution As UaSize64f
    Public time_t As Int64
    Public processing_time As Double
End Structure

#End Region

Module MCommonMeasure

#Region "XYZFunctions"
    Public CMF(450, 2) As Double
    Sub ColorMatchingFuntions()
        CMF(0, 0) = 0.001368
        CMF(0, 1) = 0.000039
        CMF(0, 2) = 0.006450001
        CMF(1, 0) = 0.00150205
        CMF(1, 1) = 0.000044
        CMF(1, 2) = 0.007083216
        CMF(2, 0) = 0.001642328
        CMF(2, 1) = 0.000049
        CMF(2, 2) = 0.007745488
        CMF(3, 0) = 0.001802382
        CMF(3, 1) = 0.000054
        CMF(3, 2) = 0.008501152
        CMF(4, 0) = 0.001995757
        CMF(4, 1) = 0.000059
        CMF(4, 2) = 0.009414544
        CMF(5, 0) = 0.002236
        CMF(5, 1) = 0.000064
        CMF(5, 2) = 0.01054999
        CMF(6, 0) = 0.002535385
        CMF(6, 1) = 0.0000752
        CMF(6, 2) = 0.0119658
        CMF(7, 0) = 0.002892603
        CMF(7, 1) = 0.0000864
        CMF(7, 2) = 0.01365587
        CMF(8, 0) = 0.003300829
        CMF(8, 1) = 0.0000976
        CMF(8, 2) = 0.01558805
        CMF(9, 0) = 0.003753236
        CMF(9, 1) = 0.0001088
        CMF(9, 2) = 0.01773015
        CMF(10, 0) = 0.004243
        CMF(10, 1) = 0.00012
        CMF(10, 2) = 0.02005001
        CMF(11, 0) = 0.004762389
        CMF(11, 1) = 0.0001394
        CMF(11, 2) = 0.02251136
        CMF(12, 0) = 0.005330048
        CMF(12, 1) = 0.0001588
        CMF(12, 2) = 0.02520288
        CMF(13, 0) = 0.005978712
        CMF(13, 1) = 0.0001782
        CMF(13, 2) = 0.02827972
        CMF(14, 0) = 0.006741117
        CMF(14, 1) = 0.0001976
        CMF(14, 2) = 0.03189704
        CMF(15, 0) = 0.00765
        CMF(15, 1) = 0.000217
        CMF(15, 2) = 0.03621
        CMF(16, 0) = 0.008751373
        CMF(16, 1) = 0.0002528
        CMF(16, 2) = 0.04143771
        CMF(17, 0) = 0.01002888
        CMF(17, 1) = 0.0002886
        CMF(17, 2) = 0.04750372
        CMF(18, 0) = 0.0114217
        CMF(18, 1) = 0.0003244
        CMF(18, 2) = 0.05411988
        CMF(19, 0) = 0.01286901
        CMF(19, 1) = 0.0003602
        CMF(19, 2) = 0.06099803
        CMF(20, 0) = 0.01431
        CMF(20, 1) = 0.000396
        CMF(20, 2) = 0.06785001
        CMF(21, 0) = 0.01570443
        CMF(21, 1) = 0.0004448
        CMF(21, 2) = 0.07448632
        CMF(22, 0) = 0.01714744
        CMF(22, 1) = 0.0004936
        CMF(22, 2) = 0.08136156
        CMF(23, 0) = 0.01878122
        CMF(23, 1) = 0.0005424
        CMF(23, 2) = 0.08915364
        CMF(24, 0) = 0.02074801
        CMF(24, 1) = 0.0005912
        CMF(24, 2) = 0.09854048
        CMF(25, 0) = 0.02319
        CMF(25, 1) = 0.00064
        CMF(25, 2) = 0.1102
        CMF(26, 0) = 0.02620736
        CMF(26, 1) = 0.000754
        CMF(26, 2) = 0.1246133
        CMF(27, 0) = 0.02978248
        CMF(27, 1) = 0.000868
        CMF(27, 2) = 0.1417017
        CMF(28, 0) = 0.03388092
        CMF(28, 1) = 0.000982
        CMF(28, 2) = 0.1613035
        CMF(29, 0) = 0.03846824
        CMF(29, 1) = 0.0011
        CMF(29, 2) = 0.1832568
        CMF(30, 0) = 0.04351
        CMF(30, 1) = 0.00121
        CMF(30, 2) = 0.2074
        CMF(31, 0) = 0.0489956
        CMF(31, 1) = 0.0014
        CMF(31, 2) = 0.2336921
        CMF(32, 0) = 0.0550226
        CMF(32, 1) = 0.0016
        CMF(32, 2) = 0.2626114
        CMF(33, 0) = 0.0617188
        CMF(33, 1) = 0.00179
        CMF(33, 2) = 0.2947746
        CMF(34, 0) = 0.069212
        CMF(34, 1) = 0.00199
        CMF(34, 2) = 0.3307985
        CMF(35, 0) = 0.07763
        CMF(35, 1) = 0.00218
        CMF(35, 2) = 0.3713
        CMF(36, 0) = 0.08695811
        CMF(36, 1) = 0.00254
        CMF(36, 2) = 0.4162091
        CMF(37, 0) = 0.09717672
        CMF(37, 1) = 0.00291
        CMF(37, 2) = 0.4654642
        CMF(38, 0) = 0.1084063
        CMF(38, 1) = 0.00327
        CMF(38, 2) = 0.5196948
        CMF(39, 0) = 0.1207672
        CMF(39, 1) = 0.00364
        CMF(39, 2) = 0.5795303
        CMF(40, 0) = 0.13438
        CMF(40, 1) = 0.004
        CMF(40, 2) = 0.6456
        CMF(41, 0) = 0.1493582
        CMF(41, 1) = 0.00466
        CMF(41, 2) = 0.7184838
        CMF(42, 0) = 0.1653957
        CMF(42, 1) = 0.00532
        CMF(42, 2) = 0.7967133
        CMF(43, 0) = 0.1819831
        CMF(43, 1) = 0.00598
        CMF(43, 2) = 0.8778459
        CMF(44, 0) = 0.198611
        CMF(44, 1) = 0.00664
        CMF(44, 2) = 0.959439
        CMF(45, 0) = 0.21477
        CMF(45, 1) = 0.0073
        CMF(45, 2) = 1.0390501
        CMF(46, 0) = 0.2301868
        CMF(46, 1) = 0.00816
        CMF(46, 2) = 1.1153673
        CMF(47, 0) = 0.2448797
        CMF(47, 1) = 0.00902
        CMF(47, 2) = 1.1884971
        CMF(48, 0) = 0.2587773
        CMF(48, 1) = 0.00988
        CMF(48, 2) = 1.2581233
        CMF(49, 0) = 0.2718079
        CMF(49, 1) = 0.01074
        CMF(49, 2) = 1.3239296
        CMF(50, 0) = 0.2839
        CMF(50, 1) = 0.0116
        CMF(50, 2) = 1.3856
        CMF(51, 0) = 0.2949438
        CMF(51, 1) = 0.01265
        CMF(51, 2) = 1.4426352
        CMF(52, 0) = 0.3048965
        CMF(52, 1) = 0.0137
        CMF(52, 2) = 1.4948035
        CMF(53, 0) = 0.3137873
        CMF(53, 1) = 0.01474
        CMF(53, 2) = 1.5421903
        CMF(54, 0) = 0.3216454
        CMF(54, 1) = 0.01579
        CMF(54, 2) = 1.5848807
        CMF(55, 0) = 0.3285
        CMF(55, 1) = 0.01684
        CMF(55, 2) = 1.62296
        CMF(56, 0) = 0.3343513
        CMF(56, 1) = 0.01807
        CMF(56, 2) = 1.6564048
        CMF(57, 0) = 0.3392101
        CMF(57, 1) = 0.0193
        CMF(57, 2) = 1.6852959
        CMF(58, 0) = 0.3431213
        CMF(58, 1) = 0.02054
        CMF(58, 2) = 1.7098745
        CMF(59, 0) = 0.3461296
        CMF(59, 1) = 0.02177
        CMF(59, 2) = 1.7303821
        CMF(60, 0) = 0.34828
        CMF(60, 1) = 0.023
        CMF(60, 2) = 1.74706
        CMF(61, 0) = 0.3495999
        CMF(61, 1) = 0.02436
        CMF(61, 2) = 1.7600446
        CMF(62, 0) = 0.3501474
        CMF(62, 1) = 0.02572
        CMF(62, 2) = 1.7696233
        CMF(63, 0) = 0.350013
        CMF(63, 1) = 0.02708
        CMF(63, 2) = 1.7762637
        CMF(64, 0) = 0.349287
        CMF(64, 1) = 0.02844
        CMF(64, 2) = 1.7804334
        CMF(65, 0) = 0.34806
        CMF(65, 1) = 0.0298
        CMF(65, 2) = 1.7826
        CMF(66, 0) = 0.3463733
        CMF(66, 1) = 0.03144
        CMF(66, 2) = 1.7829682
        CMF(67, 0) = 0.3442624
        CMF(67, 1) = 0.03308
        CMF(67, 2) = 1.7816998
        CMF(68, 0) = 0.3418088
        CMF(68, 1) = 0.03472
        CMF(68, 2) = 1.7791982
        CMF(69, 0) = 0.3390941
        CMF(69, 1) = 0.03636
        CMF(69, 2) = 1.7758671
        CMF(70, 0) = 0.3362
        CMF(70, 1) = 0.038
        CMF(70, 2) = 1.77211
        CMF(71, 0) = 0.3331977
        CMF(71, 1) = 0.04
        CMF(71, 2) = 1.7682589
        CMF(72, 0) = 0.3300411
        CMF(72, 1) = 0.042
        CMF(72, 2) = 1.764039
        CMF(73, 0) = 0.3266357
        CMF(73, 1) = 0.044
        CMF(73, 2) = 1.7589438
        CMF(74, 0) = 0.3228868
        CMF(74, 1) = 0.046
        CMF(74, 2) = 1.7524663
        CMF(75, 0) = 0.3187
        CMF(75, 1) = 0.048
        CMF(75, 2) = 1.7441
        CMF(76, 0) = 0.3140251
        CMF(76, 1) = 0.0504
        CMF(76, 2) = 1.7335595
        CMF(77, 0) = 0.308884
        CMF(77, 1) = 0.0528
        CMF(77, 2) = 1.7208581
        CMF(78, 0) = 0.3032904
        CMF(78, 1) = 0.0552
        CMF(78, 2) = 1.7059369
        CMF(79, 0) = 0.2972579
        CMF(79, 1) = 0.0576
        CMF(79, 2) = 1.6887372
        CMF(80, 0) = 0.2908
        CMF(80, 1) = 0.06
        CMF(80, 2) = 1.6692
        CMF(81, 0) = 0.2839701
        CMF(81, 1) = 0.06278
        CMF(81, 2) = 1.6475287
        CMF(82, 0) = 0.2767214
        CMF(82, 1) = 0.06556
        CMF(82, 2) = 1.6234127
        CMF(83, 0) = 0.2689178
        CMF(83, 1) = 0.06834
        CMF(83, 2) = 1.5960223
        CMF(84, 0) = 0.2604227
        CMF(84, 1) = 0.07112
        CMF(84, 2) = 1.564528
        CMF(85, 0) = 0.2511
        CMF(85, 1) = 0.0739
        CMF(85, 2) = 1.5281
        CMF(86, 0) = 0.2408475
        CMF(86, 1) = 0.07732
        CMF(86, 2) = 1.4861114
        CMF(87, 0) = 0.2298512
        CMF(87, 1) = 0.08073
        CMF(87, 2) = 1.4395215
        CMF(88, 0) = 0.2184072
        CMF(88, 1) = 0.08415
        CMF(88, 2) = 1.3898799
        CMF(89, 0) = 0.2068115
        CMF(89, 1) = 0.08756
        CMF(89, 2) = 1.3387362
        CMF(90, 0) = 0.19536
        CMF(90, 1) = 0.09098
        CMF(90, 2) = 1.28764
        CMF(91, 0) = 0.0953
        CMF(91, 2) = 1.2374223
        CMF(92, 0) = 0.1733273
        CMF(92, 1) = 0.09963
        CMF(92, 2) = 1.1878243
        CMF(93, 0) = 0.1626881
        CMF(93, 1) = 0.10395
        CMF(93, 2) = 1.1387611
        CMF(94, 0) = 0.1522833
        CMF(94, 1) = 0.10828
        CMF(94, 2) = 1.090148
        CMF(95, 0) = 0.1421
        CMF(95, 1) = 0.1126
        CMF(95, 2) = 1.0419
        CMF(96, 0) = 0.1321786
        CMF(96, 1) = 0.11788
        CMF(96, 2) = 0.9941976
        CMF(97, 0) = 0.1225696
        CMF(97, 1) = 0.12317
        CMF(97, 2) = 0.9473473
        CMF(98, 0) = 0.1132752
        CMF(98, 1) = 0.12845
        CMF(98, 2) = 0.9014531
        CMF(99, 0) = 0.1042979
        CMF(99, 1) = 0.13374
        CMF(99, 2) = 0.8566193
        CMF(100, 0) = 0.09564
        CMF(100, 1) = 0.13902
        CMF(100, 2) = 0.8129501
        CMF(101, 0) = 0.08729955
        CMF(101, 1) = 0.14508
        CMF(101, 2) = 0.7705173
        CMF(102, 0) = 0.07930804
        CMF(102, 1) = 0.15113
        CMF(102, 2) = 0.7294448
        CMF(103, 0) = 0.07171776
        CMF(103, 1) = 0.15719
        CMF(103, 2) = 0.6899136
        CMF(104, 0) = 0.06458099
        CMF(104, 1) = 0.16324
        CMF(104, 2) = 0.6521049
        CMF(105, 0) = 0.05795001
        CMF(105, 1) = 0.1693
        CMF(105, 2) = 0.6162
        CMF(106, 0) = 0.05186211
        CMF(106, 1) = 0.17704
        CMF(106, 2) = 0.5823286
        CMF(107, 0) = 0.04628152
        CMF(107, 1) = 0.18479
        CMF(107, 2) = 0.5504162
        CMF(108, 0) = 0.04115088
        CMF(108, 1) = 0.19253
        CMF(108, 2) = 0.5203376
        CMF(109, 0) = 0.03641283
        CMF(109, 1) = 0.200028
        CMF(109, 2) = 0.4919673
        CMF(110, 0) = 0.03201
        CMF(110, 1) = 0.20802
        CMF(110, 2) = 0.46518
        CMF(111, 0) = 0.0279172
        CMF(111, 1) = 0.21814
        CMF(111, 2) = 0.4399246
        CMF(112, 0) = 0.0241444
        CMF(112, 1) = 0.22825
        CMF(112, 2) = 0.4161836
        CMF(113, 0) = 0.020687
        CMF(113, 1) = 0.23837
        CMF(113, 2) = 0.3938822
        CMF(114, 0) = 0.0175404
        CMF(114, 1) = 0.24848
        CMF(114, 2) = 0.3729459
        CMF(115, 0) = 0.0147
        CMF(115, 1) = 0.2586
        CMF(115, 2) = 0.3533
        CMF(116, 0) = 0.01216179
        CMF(116, 1) = 0.27148
        CMF(116, 2) = 0.3348578
        CMF(117, 0) = 0.00991996
        CMF(117, 1) = 0.28436
        CMF(117, 2) = 0.3175521
        CMF(118, 0) = 0.00796724
        CMF(118, 1) = 0.29724
        CMF(118, 2) = 0.3013375
        CMF(119, 0) = 0.006296346
        CMF(119, 1) = 0.31012
        CMF(119, 2) = 0.2861686
        CMF(120, 0) = 0.0049
        CMF(120, 1) = 0.323
        CMF(120, 2) = 0.272
        CMF(121, 0) = 0.003777173
        CMF(121, 1) = 0.33986
        CMF(121, 2) = 0.2588171
        CMF(122, 0) = 0.00294532
        CMF(122, 1) = 0.35672
        CMF(122, 2) = 0.2464838
        CMF(123, 0) = 0.00242488
        CMF(123, 1) = 0.37358
        CMF(123, 2) = 0.2347718
        CMF(124, 0) = 0.002236293
        CMF(124, 1) = 0.39044
        CMF(124, 2) = 0.2234533
        CMF(125, 0) = 0.0024
        CMF(125, 1) = 0.4073
        CMF(125, 2) = 0.2123
        CMF(126, 0) = 0.00292552
        CMF(126, 1) = 0.42644
        CMF(126, 2) = 0.2011692
        CMF(127, 0) = 0.00383656
        CMF(127, 1) = 0.44558
        CMF(127, 2) = 0.1901196
        CMF(128, 0) = 0.00517484
        CMF(128, 1) = 0.46472
        CMF(128, 2) = 0.1792254
        CMF(129, 0) = 0.00698208
        CMF(129, 1) = 0.48386
        CMF(129, 2) = 0.1685608
        CMF(130, 0) = 0.0093
        CMF(130, 1) = 0.503
        CMF(130, 2) = 0.1582
        CMF(131, 0) = 0.01214949
        CMF(131, 1) = 0.52404
        CMF(131, 2) = 0.1481383
        CMF(132, 0) = 0.01553588
        CMF(132, 1) = 0.54508
        CMF(132, 2) = 0.1383758
        CMF(133, 0) = 0.01947752
        CMF(133, 1) = 0.56612
        CMF(133, 2) = 0.1289942
        CMF(134, 0) = 0.02399277
        CMF(134, 1) = 0.58716
        CMF(134, 2) = 0.1200751
        CMF(135, 0) = 0.0291
        CMF(135, 1) = 0.6082
        CMF(135, 2) = 0.1117
        CMF(136, 0) = 0.03481485
        CMF(136, 1) = 0.62856
        CMF(136, 2) = 0.1039048
        CMF(137, 0) = 0.04112016
        CMF(137, 1) = 0.64892
        CMF(137, 2) = 0.09666748
        CMF(138, 0) = 0.04798504
        CMF(138, 1) = 0.66928
        CMF(138, 2) = 0.08998272
        CMF(139, 0) = 0.05537861
        CMF(139, 1) = 0.68964
        CMF(139, 2) = 0.08384531
        CMF(140, 0) = 0.06327
        CMF(140, 1) = 0.71
        CMF(140, 2) = 0.07824999
        CMF(141, 0) = 0.07163501
        CMF(141, 1) = 0.72664
        CMF(141, 2) = 0.07320899
        CMF(142, 0) = 0.08046224
        CMF(142, 1) = 0.74328
        CMF(142, 2) = 0.06867816
        CMF(143, 0) = 0.08973996
        CMF(143, 1) = 0.75992
        CMF(143, 2) = 0.06456784
        CMF(144, 0) = 0.09945645
        CMF(144, 1) = 0.77656
        CMF(144, 2) = 0.06078835
        CMF(145, 0) = 0.1096
        CMF(145, 1) = 0.7932
        CMF(145, 2) = 0.05725001
        CMF(146, 0) = 0.1201674
        CMF(146, 1) = 0.80696
        CMF(146, 2) = 0.05390435
        CMF(147, 0) = 0.1311145
        CMF(147, 1) = 0.82072
        CMF(147, 2) = 0.05074664
        CMF(148, 0) = 0.1423679
        CMF(148, 1) = 0.83448
        CMF(148, 2) = 0.04775276
        CMF(149, 0) = 0.1538542
        CMF(149, 1) = 0.84824
        CMF(149, 2) = 0.04489859
        CMF(150, 0) = 0.1655
        CMF(150, 1) = 0.862
        CMF(150, 2) = 0.04216
        CMF(151, 0) = 0.1772571
        CMF(151, 1) = 0.87257
        CMF(151, 2) = 0.03950728
        CMF(152, 0) = 0.18914
        CMF(152, 1) = 0.88314
        CMF(152, 2) = 0.03693564
        CMF(153, 0) = 0.2011694
        CMF(153, 1) = 0.89371
        CMF(153, 2) = 0.03445836
        CMF(154, 0) = 0.2133658
        CMF(154, 1) = 0.90428
        CMF(154, 2) = 0.03208872
        CMF(155, 0) = 0.2257499
        CMF(155, 1) = 0.91485
        CMF(155, 2) = 0.02984
        CMF(156, 0) = 0.2383209
        CMF(156, 1) = 0.92268
        CMF(156, 2) = 0.02771181
        CMF(157, 0) = 0.2510668
        CMF(157, 1) = 0.93051
        CMF(157, 2) = 0.02569444
        CMF(158, 0) = 0.2639922
        CMF(158, 1) = 0.93834
        CMF(158, 2) = 0.02378716
        CMF(159, 0) = 0.2771017
        CMF(159, 1) = 0.94617
        CMF(159, 2) = 0.02198925
        CMF(160, 0) = 0.2904
        CMF(160, 1) = 0.954
        CMF(160, 2) = 0.0203
        CMF(161, 0) = 0.3038912
        CMF(161, 1) = 0.95926
        CMF(161, 2) = 0.01871805
        CMF(162, 0) = 0.3175726
        CMF(162, 1) = 0.96452
        CMF(162, 2) = 0.01724036
        CMF(163, 0) = 0.3314384
        CMF(163, 1) = 0.96978
        CMF(163, 2) = 0.01586364
        CMF(164, 0) = 0.3454828
        CMF(164, 1) = 0.97504
        CMF(164, 2) = 0.01458461
        CMF(165, 0) = 0.3597
        CMF(165, 1) = 0.9803
        CMF(165, 2) = 0.0134
        CMF(166, 0) = 0.3740839
        CMF(166, 1) = 0.98323
        CMF(166, 2) = 0.01230723
        CMF(167, 0) = 0.3886396
        CMF(167, 1) = 0.98616
        CMF(167, 2) = 0.01130188
        CMF(168, 0) = 0.4033784
        CMF(168, 1) = 0.98909
        CMF(168, 2) = 0.01037792
        CMF(169, 0) = 0.4183115
        CMF(169, 1) = 0.99202
        CMF(169, 2) = 0.009529306
        CMF(170, 0) = 0.4334499
        CMF(170, 1) = 0.99495
        CMF(170, 2) = 0.008749999
        CMF(171, 0) = 0.4487953
        CMF(171, 1) = 0.99596
        CMF(171, 2) = 0.0080352
        CMF(172, 0) = 0.464336
        CMF(172, 1) = 0.99697
        CMF(172, 2) = 0.0073816
        CMF(173, 0) = 0.480064
        CMF(173, 1) = 0.99798
        CMF(173, 2) = 0.0067854
        CMF(174, 0) = 0.4959713
        CMF(174, 1) = 0.99899
        CMF(174, 2) = 0.0062428
        CMF(175, 0) = 0.5120501
        CMF(175, 1) = 1
        CMF(175, 2) = 0.005749999
        CMF(176, 0) = 0.5282959
        CMF(176, 1) = 0.999
        CMF(176, 2) = 0.0053036
        CMF(177, 0) = 0.5446916
        CMF(177, 1) = 0.998
        CMF(177, 2) = 0.0048998
        CMF(178, 0) = 0.5612094
        CMF(178, 1) = 0.997
        CMF(178, 2) = 0.0045342
        CMF(179, 0) = 0.5778215
        CMF(179, 1) = 0.996
        CMF(179, 2) = 0.0042024
        CMF(180, 0) = 0.5945
        CMF(180, 1) = 0.995
        CMF(180, 2) = 0.0039
        CMF(181, 0) = 0.6112209
        CMF(181, 1) = 0.99172
        CMF(181, 2) = 0.0036232
        CMF(182, 0) = 0.6279758
        CMF(182, 1) = 0.98844
        CMF(182, 2) = 0.0033706
        CMF(183, 0) = 0.6447602
        CMF(183, 1) = 0.98516
        CMF(183, 2) = 0.0031414
        CMF(184, 0) = 0.6615697
        CMF(184, 1) = 0.98188
        CMF(184, 2) = 0.0029348
        CMF(185, 0) = 0.6784
        CMF(185, 1) = 0.9786
        CMF(185, 2) = 0.002749999
        CMF(186, 0) = 0.6952392
        CMF(186, 1) = 0.97328
        CMF(186, 2) = 0.0025852
        CMF(187, 0) = 0.7120586
        CMF(187, 1) = 0.96796
        CMF(187, 2) = 0.0024386
        CMF(188, 0) = 0.7288284
        CMF(188, 1) = 0.96264
        CMF(188, 2) = 0.0023094
        CMF(189, 0) = 0.7455188
        CMF(189, 1) = 0.95732
        CMF(189, 2) = 0.0021968
        CMF(190, 0) = 0.7621
        CMF(190, 1) = 0.952
        CMF(190, 2) = 0.0021
        CMF(191, 0) = 0.7785432
        CMF(191, 1) = 0.94468
        CMF(191, 2) = 0.002017733
        CMF(192, 0) = 0.7948256
        CMF(192, 1) = 0.93736
        CMF(192, 2) = 0.0019482
        CMF(193, 0) = 0.8109264
        CMF(193, 1) = 0.93004
        CMF(193, 2) = 0.0018898
        CMF(194, 0) = 0.8268248
        CMF(194, 1) = 0.92272
        CMF(194, 2) = 0.001840933
        CMF(195, 0) = 0.8425
        CMF(195, 1) = 0.9154
        CMF(195, 2) = 0.0018
        CMF(196, 0) = 0.8579325
        CMF(196, 1) = 0.90632
        CMF(196, 2) = 0.001766267
        CMF(197, 0) = 0.8730816
        CMF(197, 1) = 0.89724
        CMF(197, 2) = 0.0017378
        CMF(198, 0) = 0.8878944
        CMF(198, 1) = 0.88816
        CMF(198, 2) = 0.0017112
        CMF(199, 0) = 0.9023181
        CMF(199, 1) = 0.87908
        CMF(199, 2) = 0.001683067
        CMF(200, 0) = 0.9163
        CMF(200, 1) = 0.87
        CMF(200, 2) = 0.001650001
        CMF(201, 0) = 0.9297995
        CMF(201, 1) = 0.85926
        CMF(201, 2) = 0.001610133
        CMF(202, 0) = 0.9427984
        CMF(202, 1) = 0.84852
        CMF(202, 2) = 0.0015644
        CMF(203, 0) = 0.9552776
        CMF(203, 1) = 0.83778
        CMF(203, 2) = 0.0015136
        CMF(204, 0) = 0.9672179
        CMF(204, 1) = 0.82704
        CMF(204, 2) = 0.001458533
        CMF(205, 0) = 0.9786
        CMF(205, 1) = 0.8163
        CMF(205, 2) = 0.0014
        CMF(206, 0) = 0.9893856
        CMF(206, 1) = 0.80444
        CMF(206, 2) = 0.001336667
        CMF(207, 0) = 0.9995488
        CMF(207, 1) = 0.79258
        CMF(207, 2) = 0.00127
        CMF(208, 0) = 1.0090892
        CMF(208, 1) = 0.78072
        CMF(208, 2) = 0.001205
        CMF(209, 0) = 1.0180064
        CMF(209, 1) = 0.76886
        CMF(209, 2) = 0.001146667
        CMF(210, 0) = 1.0263
        CMF(210, 1) = 0.757
        CMF(210, 2) = 0.0011
        CMF(211, 0) = 1.0339827
        CMF(211, 1) = 0.74458
        CMF(211, 2) = 0.0010688
        CMF(212, 0) = 1.040986
        CMF(212, 1) = 0.73216
        CMF(212, 2) = 0.0010494
        CMF(213, 0) = 1.047188
        CMF(213, 1) = 0.71974
        CMF(213, 2) = 0.0010356
        CMF(214, 0) = 1.0524667
        CMF(214, 1) = 0.70732
        CMF(214, 2) = 0.0010212
        CMF(215, 0) = 1.0567
        CMF(215, 1) = 0.6949
        CMF(215, 2) = 0.001
        CMF(216, 0) = 1.0597944
        CMF(216, 1) = 0.68212
        CMF(216, 2) = 0.00096864
        CMF(217, 0) = 1.0617992
        CMF(217, 1) = 0.66934
        CMF(217, 2) = 0.00092992
        CMF(218, 0) = 1.0628068
        CMF(218, 1) = 0.65656
        CMF(218, 2) = 0.00088688
        CMF(219, 0) = 1.0629096
        CMF(219, 1) = 0.64378
        CMF(219, 2) = 0.00084256
        CMF(220, 0) = 1.0622
        CMF(220, 1) = 0.631
        CMF(220, 2) = 0.0008
        CMF(221, 0) = 1.0607352
        CMF(221, 1) = 0.61816
        CMF(221, 2) = 0.00076096
        CMF(222, 0) = 1.0584436
        CMF(222, 1) = 0.60532
        CMF(222, 2) = 0.00072368
        CMF(223, 0) = 1.0552244
        CMF(223, 1) = 0.59248
        CMF(223, 2) = 0.00068592
        CMF(224, 0) = 1.0509768
        CMF(224, 1) = 0.57964
        CMF(224, 2) = 0.00064544
        CMF(225, 0) = 1.0456
        CMF(225, 1) = 0.5668
        CMF(225, 2) = 0.0006
        CMF(226, 0) = 1.0390369
        CMF(226, 1) = 0.55404
        CMF(226, 2) = 0.000547867
        CMF(227, 0) = 1.0313608
        CMF(227, 1) = 0.54128
        CMF(227, 2) = 0.0004916
        CMF(228, 0) = 1.0226662
        CMF(228, 1) = 0.52852
        CMF(228, 2) = 0.0004354
        CMF(229, 0) = 1.0130477
        CMF(229, 1) = 0.51576
        CMF(229, 2) = 0.000383467
        CMF(230, 0) = 1.0026
        CMF(230, 1) = 0.503
        CMF(230, 2) = 0.00034
        CMF(231, 0) = 0.9913675
        CMF(231, 1) = 0.49064
        CMF(231, 2) = 0.000307253
        CMF(232, 0) = 0.9793314
        CMF(232, 1) = 0.47828
        CMF(232, 2) = 0.00028316
        CMF(233, 0) = 0.9664916
        CMF(233, 1) = 0.46592
        CMF(233, 2) = 0.00026544
        CMF(234, 0) = 0.9528479
        CMF(234, 1) = 0.45356
        CMF(234, 2) = 0.000251813
        CMF(235, 0) = 0.9384
        CMF(235, 1) = 0.4412
        CMF(235, 2) = 0.00024
        CMF(236, 0) = 0.923194
        CMF(236, 1) = 0.42916
        CMF(236, 2) = 0.000229547
        CMF(237, 0) = 0.907244
        CMF(237, 1) = 0.41712
        CMF(237, 2) = 0.00022064
        CMF(238, 0) = 0.890502
        CMF(238, 1) = 0.40508
        CMF(238, 2) = 0.00021196
        CMF(239, 0) = 0.87292
        CMF(239, 1) = 0.39304
        CMF(239, 2) = 0.000202187
        CMF(240, 0) = 0.8544499
        CMF(240, 1) = 0.381
        CMF(240, 2) = 0.00019
        CMF(241, 0) = 0.835084
        CMF(241, 1) = 0.369
        CMF(241, 2) = 0.000174213
        CMF(242, 0) = 0.814946
        CMF(242, 1) = 0.357
        CMF(242, 2) = 0.00015564
        CMF(243, 0) = 0.794186
        CMF(243, 1) = 0.345
        CMF(243, 2) = 0.00013596
        CMF(244, 0) = 0.772954
        CMF(244, 1) = 0.333
        CMF(244, 2) = 0.000116853
        CMF(245, 0) = 0.7514
        CMF(245, 1) = 0.321
        CMF(245, 2) = 0.0001
        CMF(246, 0) = 0.7295836
        CMF(246, 1) = 0.3098
        CMF(246, 2) = 0.0000861333
        CMF(247, 0) = 0.7075888
        CMF(247, 1) = 0.2986
        CMF(247, 2) = 0.0000746
        CMF(248, 0) = 0.6856022
        CMF(248, 1) = 0.2874
        CMF(248, 2) = 0.000065
        CMF(249, 0) = 0.6638104
        CMF(249, 1) = 0.2762
        CMF(249, 2) = 0.0000569333
        CMF(250, 0) = 0.6424
        CMF(250, 1) = 0.265
        CMF(250, 2) = 0.00005
        CMF(251, 0) = 0.6215149
        CMF(251, 1) = 0.2554
        CMF(251, 2) = 0.00004416
        CMF(252, 0) = 0.6011138
        CMF(252, 1) = 0.2458
        CMF(252, 2) = 0.00003948
        CMF(253, 0) = 0.5811052
        CMF(253, 1) = 0.2362
        CMF(253, 2) = 0.00003572
        CMF(254, 0) = 0.5613977
        CMF(254, 1) = 0.2266
        CMF(254, 2) = 0.00003264
        CMF(255, 0) = 0.5419
        CMF(255, 1) = 0.217
        CMF(255, 2) = 0.00003
        CMF(256, 0) = 0.5225995
        CMF(256, 1) = 0.2086
        CMF(256, 2) = 0.0000276533
        CMF(257, 0) = 0.5035464
        CMF(257, 1) = 0.2002
        CMF(257, 2) = 0.00002556
        CMF(258, 0) = 0.4847436
        CMF(258, 1) = 0.1918
        CMF(258, 2) = 0.00002364
        CMF(259, 0) = 0.4661939
        CMF(259, 1) = 0.1834
        CMF(259, 2) = 0.0000218133
        CMF(260, 0) = 0.4479
        CMF(260, 1) = 0.175
        CMF(260, 2) = 0.00002
        CMF(261, 0) = 0.4298613
        CMF(261, 1) = 0.16764
        CMF(261, 2) = 0.0000181333
        CMF(262, 0) = 0.412098
        CMF(262, 1) = 0.16028
        CMF(262, 2) = 0.0000162
        CMF(263, 0) = 0.394644
        CMF(263, 1) = 0.15292
        CMF(263, 2) = 0.0000142
        CMF(264, 0) = 0.3775333
        CMF(264, 1) = 0.14556
        CMF(264, 2) = 0.0000121333
        CMF(265, 0) = 0.3608
        CMF(265, 1) = 0.1382
        CMF(265, 2) = 0.00001
        CMF(266, 0) = 0.3444563
        CMF(266, 1) = 0.13196
        CMF(266, 2) = 0.00000773333
        CMF(267, 0) = 0.3285168
        CMF(267, 1) = 0.12572
        CMF(267, 2) = 0.0000054
        CMF(268, 0) = 0.3130192
        CMF(268, 1) = 0.11948
        CMF(268, 2) = 0.0000032
        CMF(269, 0) = 0.2980011
        CMF(269, 1) = 0.11324
        CMF(269, 2) = 0.00000133333
        CMF(270, 0) = 0.2835
        CMF(270, 1) = 0.107
        CMF(270, 2) = 0
        CMF(271, 0) = 0.2695448
        CMF(271, 1) = 0.10192
        CMF(271, 2) = 0
        CMF(272, 0) = 0.2561184
        CMF(272, 1) = 0.09684
        CMF(272, 2) = 0
        CMF(273, 0) = 0.2431896
        CMF(273, 1) = 0.09176
        CMF(273, 2) = 0
        CMF(274, 0) = 0.2307272
        CMF(274, 1) = 0.08668
        CMF(274, 2) = 0
        CMF(275, 0) = 0.2187
        CMF(275, 1) = 0.0816
        CMF(275, 2) = 0
        CMF(276, 0) = 0.2070971
        CMF(276, 1) = 0.07748
        CMF(276, 2) = 0
        CMF(277, 0) = 0.1959232
        CMF(277, 1) = 0.07336
        CMF(277, 2) = 0
        CMF(278, 0) = 0.1851708
        CMF(278, 1) = 0.06924
        CMF(278, 2) = 0
        CMF(279, 0) = 0.1748323
        CMF(279, 1) = 0.06512
        CMF(279, 2) = 0
        CMF(280, 0) = 0.1649
        CMF(280, 1) = 0.061
        CMF(280, 2) = 0
        CMF(281, 0) = 0.1553667
        CMF(281, 1) = 0.05772
        CMF(281, 2) = 0
        CMF(282, 0) = 0.14623
        CMF(282, 1) = 0.05443
        CMF(282, 2) = 0
        CMF(283, 0) = 0.13749
        CMF(283, 1) = 0.05115
        CMF(283, 2) = 0
        CMF(284, 0) = 0.1291467
        CMF(284, 1) = 0.04786
        CMF(284, 2) = 0
        CMF(285, 0) = 0.1212
        CMF(285, 1) = 0.04458
        CMF(285, 2) = 0
        CMF(286, 0) = 0.1136397
        CMF(286, 1) = 0.04206
        CMF(286, 2) = 0
        CMF(287, 0) = 0.106465
        CMF(287, 1) = 0.03955
        CMF(287, 2) = 0
        CMF(288, 0) = 0.09969044
        CMF(288, 1) = 0.03703
        CMF(288, 2) = 0
        CMF(289, 0) = 0.09333061
        CMF(289, 1) = 0.03452
        CMF(289, 2) = 0
        CMF(290, 0) = 0.0874
        CMF(290, 1) = 0.032
        CMF(290, 2) = 0
        CMF(291, 0) = 0.08190096
        CMF(291, 1) = 0.03024
        CMF(291, 2) = 0
        CMF(292, 0) = 0.07680428
        CMF(292, 1) = 0.02848
        CMF(292, 2) = 0
        CMF(293, 0) = 0.07207712
        CMF(293, 1) = 0.02672
        CMF(293, 2) = 0
        CMF(294, 0) = 0.06768664
        CMF(294, 1) = 0.02496
        CMF(294, 2) = 0
        CMF(295, 0) = 0.0636
        CMF(295, 1) = 0.0232
        CMF(295, 2) = 0
        CMF(296, 0) = 0.05980685
        CMF(296, 1) = 0.02196
        CMF(296, 2) = 0
        CMF(297, 0) = 0.05628216
        CMF(297, 1) = 0.02072
        CMF(297, 2) = 0
        CMF(298, 0) = 0.05297104
        CMF(298, 1) = 0.01948
        CMF(298, 2) = 0
        CMF(299, 0) = 0.04981861
        CMF(299, 1) = 0.01824
        CMF(299, 2) = 0
        CMF(300, 0) = 0.04677
        CMF(300, 1) = 0.017
        CMF(300, 2) = 0
        CMF(301, 0) = 0.04378405
        CMF(301, 1) = 0.01598
        CMF(301, 2) = 0
        CMF(302, 0) = 0.04087536
        CMF(302, 1) = 0.01497
        CMF(302, 2) = 0
        CMF(303, 0) = 0.03807264
        CMF(303, 1) = 0.01395
        CMF(303, 2) = 0
        CMF(304, 0) = 0.03540461
        CMF(304, 1) = 0.01294
        CMF(304, 2) = 0
        CMF(305, 0) = 0.0329
        CMF(305, 1) = 0.01192
        CMF(305, 2) = 0
        CMF(306, 0) = 0.03056419
        CMF(306, 1) = 0.01118
        CMF(306, 2) = 0
        CMF(307, 0) = 0.02838056
        CMF(307, 1) = 0.01044
        CMF(307, 2) = 0
        CMF(308, 0) = 0.02634484
        CMF(308, 1) = 0.00969
        CMF(308, 2) = 0
        CMF(309, 0) = 0.02445275
        CMF(309, 1) = 0.00895
        CMF(309, 2) = 0
        CMF(310, 0) = 0.0227
        CMF(310, 1) = 0.00821
        CMF(310, 2) = 0
        CMF(311, 0) = 0.02108429
        CMF(311, 1) = 0.00771
        CMF(311, 2) = 0
        CMF(312, 0) = 0.01959988
        CMF(312, 1) = 0.00722
        CMF(312, 2) = 0
        CMF(313, 0) = 0.01823732
        CMF(313, 1) = 0.00672
        CMF(313, 2) = 0
        CMF(314, 0) = 0.01698717
        CMF(314, 1) = 0.00622
        CMF(314, 2) = 0
        CMF(315, 0) = 0.01584
        CMF(315, 1) = 0.005723
        CMF(315, 2) = 0
        CMF(316, 0) = 0.01479064
        CMF(316, 1) = 0.0054
        CMF(316, 2) = 0
        CMF(317, 0) = 0.01383132
        CMF(317, 1) = 0.00507
        CMF(317, 2) = 0
        CMF(318, 0) = 0.01294868
        CMF(318, 1) = 0.00475
        CMF(318, 2) = 0
        CMF(319, 0) = 0.0121292
        CMF(319, 1) = 0.00443
        CMF(319, 2) = 0
        CMF(320, 0) = 0.01135916
        CMF(320, 1) = 0.004102
        CMF(320, 2) = 0
        CMF(321, 0) = 0.01062935
        CMF(321, 1) = 0.00387
        CMF(321, 2) = 0
        CMF(322, 0) = 0.009938846
        CMF(322, 1) = 0.00363
        CMF(322, 2) = 0
        CMF(323, 0) = 0.009288422
        CMF(323, 1) = 0.0034
        CMF(323, 2) = 0
        CMF(324, 0) = 0.008678854
        CMF(324, 1) = 0.00316
        CMF(324, 2) = 0
        CMF(325, 0) = 0.008110916
        CMF(325, 1) = 0.002929
        CMF(325, 2) = 0
        CMF(326, 0) = 0.007582388
        CMF(326, 1) = 0.00276
        CMF(326, 2) = 0
        CMF(327, 0) = 0.007088746
        CMF(327, 1) = 0.00259
        CMF(327, 2) = 0
        CMF(328, 0) = 0.006627313
        CMF(328, 1) = 0.00243
        CMF(328, 2) = 0
        CMF(329, 0) = 0.006195408
        CMF(329, 1) = 0.00226
        CMF(329, 2) = 0
        CMF(330, 0) = 0.005790346
        CMF(330, 1) = 0.002091
        CMF(330, 2) = 0
        CMF(331, 0) = 0.005409826
        CMF(331, 1) = 0.00197
        CMF(331, 2) = 0
        CMF(332, 0) = 0.005052583
        CMF(332, 1) = 0.00185
        CMF(332, 2) = 0
        CMF(333, 0) = 0.004717512
        CMF(333, 1) = 0.00173
        CMF(333, 2) = 0
        CMF(334, 0) = 0.004403507
        CMF(334, 1) = 0.00161
        CMF(334, 2) = 0
        CMF(335, 0) = 0.004109457
        CMF(335, 1) = 0.001484
        CMF(335, 2) = 0
        CMF(336, 0) = 0.003833913
        CMF(336, 1) = 0.0014
        CMF(336, 2) = 0
        CMF(337, 0) = 0.003575748
        CMF(337, 1) = 0.00131
        CMF(337, 2) = 0
        CMF(338, 0) = 0.003334342
        CMF(338, 1) = 0.00122
        CMF(338, 2) = 0
        CMF(339, 0) = 0.003109075
        CMF(339, 1) = 0.00113
        CMF(339, 2) = 0
        CMF(340, 0) = 0.002899327
        CMF(340, 1) = 0.001047
        CMF(340, 2) = 0
        CMF(341, 0) = 0.002704348
        CMF(341, 1) = 0.000986
        CMF(341, 2) = 0
        CMF(342, 0) = 0.00252302
        CMF(342, 1) = 0.000924
        CMF(342, 2) = 0
        CMF(343, 0) = 0.002354168
        CMF(343, 1) = 0.000863
        CMF(343, 2) = 0
        CMF(344, 0) = 0.002196616
        CMF(344, 1) = 0.000801
        CMF(344, 2) = 0
        CMF(345, 0) = 0.00204919
        CMF(345, 1) = 0.00074
        CMF(345, 2) = 0
        CMF(346, 0) = 0.00191096
        CMF(346, 1) = 0.000696
        CMF(346, 2) = 0
        CMF(347, 0) = 0.001781438
        CMF(347, 1) = 0.000652
        CMF(347, 2) = 0
        CMF(348, 0) = 0.00166011
        CMF(348, 1) = 0.000608
        CMF(348, 2) = 0
        CMF(349, 0) = 0.001546459
        CMF(349, 1) = 0.000564
        CMF(349, 2) = 0
        CMF(350, 0) = 0.001439971
        CMF(350, 1) = 0.00052
        CMF(350, 2) = 0
        CMF(351, 0) = 0.001340042
        CMF(351, 1) = 0.000488
        CMF(351, 2) = 0
        CMF(352, 0) = 0.001246275
        CMF(352, 1) = 0.000456
        CMF(352, 2) = 0
        CMF(353, 0) = 0.001158471
        CMF(353, 1) = 0.000125
        CMF(353, 2) = 0
        CMF(354, 0) = 0.00107643
        CMF(354, 1) = 0.000393
        CMF(354, 2) = 0
        CMF(355, 0) = 0.000999949
        CMF(355, 1) = 0.0003611
        CMF(355, 2) = 0
        CMF(356, 0) = 0.000928736
        CMF(356, 1) = 0.000339
        CMF(356, 2) = 0
        CMF(357, 0) = 0.000862433
        CMF(357, 1) = 0.000316
        CMF(357, 2) = 0
        CMF(358, 0) = 0.00080075
        CMF(358, 1) = 0.000294
        CMF(358, 2) = 0
        CMF(359, 0) = 0.000743396
        CMF(359, 1) = 0.000271
        CMF(359, 2) = 0
        CMF(360, 0) = 0.000690079
        CMF(360, 1) = 0.0002492
        CMF(360, 2) = 0
        CMF(361, 0) = 0.000640516
        CMF(361, 1) = 0.000234
        CMF(361, 2) = 0
        CMF(362, 0) = 0.000594502
        CMF(362, 1) = 0.000218
        CMF(362, 2) = 0
        CMF(363, 0) = 0.000551865
        CMF(363, 1) = 0.000203
        CMF(363, 2) = 0
        CMF(364, 0) = 0.000512429
        CMF(364, 1) = 0.000187
        CMF(364, 2) = 0
        CMF(365, 0) = 0.000476021
        CMF(365, 1) = 0.0001719
        CMF(365, 2) = 0
        CMF(366, 0) = 0.000442454
        CMF(366, 1) = 0.000162
        CMF(366, 2) = 0
        CMF(367, 0) = 0.000411512
        CMF(367, 1) = 0.000151
        CMF(367, 2) = 0
        CMF(368, 0) = 0.000382981
        CMF(368, 1) = 0.000141
        CMF(368, 2) = 0
        CMF(369, 0) = 0.000356649
        CMF(369, 1) = 0.00013
        CMF(369, 2) = 0
        CMF(370, 0) = 0.000332301
        CMF(370, 1) = 0.00012
        CMF(370, 2) = 0
        CMF(371, 0) = 0.000309759
        CMF(371, 1) = 0.000113
        CMF(371, 2) = 0
        CMF(372, 0) = 0.000288887
        CMF(372, 1) = 0.000106
        CMF(372, 2) = 0
        CMF(373, 0) = 0.000269539
        CMF(373, 1) = 0.000099
        CMF(373, 2) = 0
        CMF(374, 0) = 0.000251568
        CMF(374, 1) = 0.000092
        CMF(374, 2) = 0
        CMF(375, 0) = 0.000234826
        CMF(375, 1) = 0.0000848
        CMF(375, 2) = 0
        CMF(376, 0) = 0.000219171
        CMF(376, 1) = 0.00008
        CMF(376, 2) = 0
        CMF(377, 0) = 0.000204526
        CMF(377, 1) = 0.000075
        CMF(377, 2) = 0
        CMF(378, 0) = 0.000190841
        CMF(378, 1) = 0.00007
        CMF(378, 2) = 0
        CMF(379, 0) = 0.000178065
        CMF(379, 1) = 0.000065
        CMF(379, 2) = 0
        CMF(380, 0) = 0.000166151
        CMF(380, 1) = 0.00006
        CMF(380, 2) = 0
        CMF(381, 0) = 0.000155024
        CMF(381, 1) = 0.0000564
        CMF(381, 2) = 0
        CMF(382, 0) = 0.000144622
        CMF(382, 1) = 0.0000528
        CMF(382, 2) = 0
        CMF(383, 0) = 0.00013491
        CMF(383, 1) = 0.0000492
        CMF(383, 2) = 0
        CMF(384, 0) = 0.000125852
        CMF(384, 1) = 0.0000456
        CMF(384, 2) = 0
        CMF(385, 0) = 0.000117413
        CMF(385, 1) = 0.0000424
        CMF(385, 2) = 0
        CMF(386, 0) = 0.000109552
        CMF(386, 1) = 0.0000396
        CMF(386, 2) = 0
        CMF(387, 0) = 0.000102225
        CMF(387, 1) = 0.0000372
        CMF(387, 2) = 0
        CMF(388, 0) = 0.0000953945
        CMF(388, 1) = 0.0000348
        CMF(388, 2) = 0
        CMF(389, 0) = 0.0000890239
        CMF(389, 1) = 0.0000324
        CMF(389, 2) = 0
        CMF(390, 0) = 0.0000830753
        CMF(390, 1) = 0.00003
        CMF(390, 2) = 0
        CMF(391, 0) = 0.0000775127
        CMF(391, 1) = 0.0000282
        CMF(391, 2) = 0
        CMF(392, 0) = 0.000072313
        CMF(392, 1) = 0.0000264
        CMF(392, 2) = 0
        CMF(393, 0) = 0.0000674578
        CMF(393, 1) = 0.0000246
        CMF(393, 2) = 0
        CMF(394, 0) = 0.0000629284
        CMF(394, 1) = 0.0000228
        CMF(394, 2) = 0
        CMF(395, 0) = 0.0000587065
        CMF(395, 1) = 0.0000212
        CMF(395, 2) = 0
        CMF(396, 0) = 0.0000547703
        CMF(396, 1) = 0.0000198
        CMF(396, 2) = 0
        CMF(397, 0) = 0.0000510992
        CMF(397, 1) = 0.0000186
        CMF(397, 2) = 0
        CMF(398, 0) = 0.0000476765
        CMF(398, 1) = 0.0000174
        CMF(398, 2) = 0
        CMF(399, 0) = 0.0000444857
        CMF(399, 1) = 0.0000162
        CMF(399, 2) = 0
        CMF(400, 0) = 0.0000415099
        CMF(400, 1) = 0.00001499
        CMF(400, 2) = 0
        CMF(401, 0) = 0.0000387332
        CMF(401, 1) = 0.0000139873
        CMF(401, 2) = 0
        CMF(402, 0) = 0.000036142
        CMF(402, 1) = 0.0000130516
        CMF(402, 2) = 0
        CMF(403, 0) = 0.0000337235
        CMF(403, 1) = 0.0000121782
        CMF(403, 2) = 0
        CMF(404, 0) = 0.0000314649
        CMF(404, 1) = 0.0000113625
        CMF(404, 2) = 0
        CMF(405, 0) = 0.0000293533
        CMF(405, 1) = 0.0000106
        CMF(405, 2) = 0
        CMF(406, 0) = 0.0000273757
        CMF(406, 1) = 0.00000988588
        CMF(406, 2) = 0
        CMF(407, 0) = 0.0000255243
        CMF(407, 1) = 0.0000092173
        CMF(407, 2) = 0
        CMF(408, 0) = 0.0000237938
        CMF(408, 1) = 0.00000859236
        CMF(408, 2) = 0
        CMF(409, 0) = 0.0000221787
        CMF(409, 1) = 0.00000800913
        CMF(409, 2) = 0
        CMF(410, 0) = 0.0000206738
        CMF(410, 1) = 0.0000074657
        CMF(410, 2) = 0
        CMF(411, 0) = 0.0000192723
        CMF(411, 1) = 0.00000695957
        CMF(411, 2) = 0
        CMF(412, 0) = 0.0000179664
        CMF(412, 1) = 0.000006488
        CMF(412, 2) = 0
        CMF(413, 0) = 0.0000167499
        CMF(413, 1) = 0.0000060487
        CMF(413, 2) = 0
        CMF(414, 0) = 0.0000156165
        CMF(414, 1) = 0.0000056394
        CMF(414, 2) = 0
        CMF(415, 0) = 0.0000145598
        CMF(415, 1) = 0.0000052578
        CMF(415, 2) = 0
        CMF(416, 0) = 0.0000135739
        CMF(416, 1) = 0.00000490177
        CMF(416, 2) = 0
        CMF(417, 0) = 0.0000126544
        CMF(417, 1) = 0.00000456972
        CMF(417, 2) = 0
        CMF(418, 0) = 0.0000117972
        CMF(418, 1) = 0.00000426019
        CMF(418, 2) = 0
        CMF(419, 0) = 0.0000109984
        CMF(419, 1) = 0.00000397174
        CMF(419, 2) = 0
        CMF(420, 0) = 0.000010254
        CMF(420, 1) = 0.0000037029
        CMF(420, 2) = 0
        CMF(421, 0) = 0.00000955965
        CMF(421, 1) = 0.00000345216
        CMF(421, 2) = 0
        CMF(422, 0) = 0.00000891204
        CMF(422, 1) = 0.0000032183
        CMF(422, 2) = 0
        CMF(423, 0) = 0.00000830836
        CMF(423, 1) = 0.0000030003
        CMF(423, 2) = 0
        CMF(424, 0) = 0.00000774577
        CMF(424, 1) = 0.00000279714
        CMF(424, 2) = 0
        CMF(425, 0) = 0.00000722146
        CMF(425, 1) = 0.0000026078
        CMF(425, 2) = 0
        CMF(426, 0) = 0.00000673248
        CMF(426, 1) = 0.00000243122
        CMF(426, 2) = 0
        CMF(427, 0) = 0.00000627642
        CMF(427, 1) = 0.00000226653
        CMF(427, 2) = 0
        CMF(428, 0) = 0.0000058513
        CMF(428, 1) = 0.00000211301
        CMF(428, 2) = 0
        CMF(429, 0) = 0.00000545512
        CMF(429, 1) = 0.00000196994
        CMF(429, 2) = 0
        CMF(430, 0) = 0.00000508587
        CMF(430, 1) = 0.0000018366
        CMF(430, 2) = 0
        CMF(431, 0) = 0.00000474147
        CMF(431, 1) = 0.00000171223
        CMF(431, 2) = 0
        CMF(432, 0) = 0.00000442024
        CMF(432, 1) = 0.00000159623
        CMF(432, 2) = 0
        CMF(433, 0) = 0.00000412078
        CMF(433, 1) = 0.00000148809
        CMF(433, 2) = 0
        CMF(434, 0) = 0.00000384172
        CMF(434, 1) = 0.00000138731
        CMF(434, 2) = 0
        CMF(435, 0) = 0.00000358165
        CMF(435, 1) = 0.0000012934
        CMF(435, 2) = 0
        CMF(436, 0) = 0.00000333913
        CMF(436, 1) = 0.00000120582
        CMF(436, 2) = 0
        CMF(437, 0) = 0.00000311295
        CMF(437, 1) = 0.00000112414
        CMF(437, 2) = 0
        CMF(438, 0) = 0.00000290212
        CMF(438, 1) = 0.00000104801
        CMF(438, 2) = 0
        CMF(439, 0) = 0.00000270565
        CMF(439, 1) = 0.000000977058
        CMF(439, 2) = 0
        CMF(440, 0) = 0.00000252253
        CMF(440, 1) = 0.00000091093
        CMF(440, 2) = 0
        CMF(441, 0) = 0.00000235173
        CMF(441, 1) = 0.000000849251
        CMF(441, 2) = 0
        CMF(442, 0) = 0.00000219242
        CMF(442, 1) = 0.000000791721
        CMF(442, 2) = 0
        CMF(443, 0) = 0.0000020439
        CMF(443, 1) = 0.00000073809
        CMF(443, 2) = 0
        CMF(444, 0) = 0.0000019055
        CMF(444, 1) = 0.00000068811
        CMF(444, 2) = 0
        CMF(445, 0) = 0.00000177651
        CMF(445, 1) = 0.00000064153
        CMF(445, 2) = 0
        CMF(446, 0) = 0.00000165622
        CMF(446, 1) = 0.00000059809
        CMF(446, 2) = 0
        CMF(447, 0) = 0.00000154402
        CMF(447, 1) = 0.000000557575
        CMF(447, 2) = 0
        CMF(448, 0) = 0.00000143944
        CMF(448, 1) = 0.000000519808
        CMF(448, 2) = 0
        CMF(449, 0) = 0.00000134198
        CMF(449, 1) = 0.000000484612
        CMF(449, 2) = 0
        CMF(450, 0) = 0.00000125114
        CMF(450, 1) = 0.00000045181
        CMF(450, 2) = 0
    End Sub
    Public LuminanceCalFactor() As Double
    Public PhotopicConversion() As Double

#End Region

#Region "UA_Core2.h"

#Region "Core Functinos CJS"
    'Public Declare Ansi Function UA10Connection Lib "UA10Lib.dll" (ByVal parameter_directory As String) As Short
    'Public Declare Ansi Function UA10CreateProperty Lib "UA10Lib.dll" (ByVal devicetype As UaDeviceType) As IntPtr
    'Public Declare Ansi Function UA10CreateRecipe Lib "UA10Lib.dll" (ByVal devicetype As UaDeviceType) As IntPtr
    'Public Declare Ansi Function UA10GetDeviceInfos Lib "UA10Lib.dll" (ByVal device As UaDevice, ByRef dproperty As UaDeviceProperty, ByRef count As Integer) As Integer
    'Public Declare Ansi Function UA10CreateCaptureData Lib "UA10Lib.dll" (ByVal device_type As UaDeviceType) As IntPtr
    'Public Declare Ansi Function UA10CreateXYZImage Lib "UA10Lib.dll" (ByVal device_type As UaDeviceType, ByVal data_type As UaDataType) As IntPtr
    'Public Declare Ansi Function UA10StartCapture Lib "UA10Lib.dll" (ByVal device As UaDevice) As Integer
    'Public Declare Ansi Function UA10CaptureImage Lib "UA10Lib.dll" (ByVal device As UaDevice, ByVal filter_type As UaCaptureFilterType, ByVal average_count As Integer, ByRef XData As UShort, ByRef YData As UShort, ByRef ZData As UShort) As Integer

    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10Connection(ByVal parameter_directory As String) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateProperty(ByVal devicetype As UaDeviceType) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateRecipe(ByVal devicetype As UaDeviceType) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10GetOptimumAverageCount(ByVal device As UaDevice, ByVal freq As Integer, ByVal exposetime As Double, ByVal dproperty As IntPtr) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateCaptureData(ByVal device_type As UaDeviceType) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateImage(ByVal width As Integer, ByVal height As Integer) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateXYZImage(ByVal device_type As UaDeviceType, ByVal data_type As UaDataType) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CreateChromaticityImage(ByVal device_type As UaDeviceType) As IntPtr
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10StartCapture(ByVal device As UaDevice) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10StopCapture(ByVal device As UaDevice) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CaptureImage(ByVal device As UaDevice, ByVal data As IntPtr, ByVal filter_type As UaCaptureFilterType, ByVal average_count As Integer) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10Meas(ByVal device As UaDevice, ByVal data As UaCaptureData, ByVal xyzimage As UaXYZImage, ByVal filter_type As UaCaptureFilterType, ByVal average_count As Integer, ByRef XData As Int16, ByRef YData As Int16, ByRef ZData As Int16) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10XYZImage(ByVal device As UaDevice, ByVal data As IntPtr, ByVal xyzimage As IntPtr, ByRef XData As Single, ByRef YData As Single, ByRef ZData As Single) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10CorrectColor(ByVal device As UaDevice, ByVal xyzimage As IntPtr, ByVal type As UaColorCorrectionType, ByRef XData As Single, ByRef YData As Single, ByRef ZData As Single) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10ComputeColorTempAndDuvImage(ByVal uv As IntPtr, ByVal colortemp As IntPtr, ByVal duv As IntPtr, ByRef xData As Single, ByRef yData As Single) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10ChromaticityImage(ByVal xyzimage As IntPtr, ByVal color_type As UaColorSpaceType, ByVal data As IntPtr, ByRef xData As Single, ByRef yData As Single) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10DestroyCaptureData(ByVal data As IntPtr) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10DestroyXYZImage(ByVal data As IntPtr) As Integer
    End Function
    <DllImport("UA10Lib.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function UA10DestroyChromaticityImage(ByVal data As IntPtr) As Integer
    End Function
#End Region
#Region "Core Functions"
    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function uaGetVersion() As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetErrorString(ByVal i As Integer) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaInitialize(<MarshalAs(UnmanagedType.LPStr)> ByVal parameter_directory As String) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaFinalize(ByVal system As UaSystem) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaOpenDevice(ByVal product_id As String, ByVal device_type As UaDeviceType) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCloseDevice(ByVal device As UaDevice) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaStartCapture(ByVal device As IntPtr) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaStopCapture(ByVal device As UaDevice) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateRecipe() As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateDeviceProperty(ByVal device_type As UaDeviceType) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyDeviceProperty(ByVal device As UaDeviceProperty) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetDeviceProperty(ByVal device As UaDevice) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSetDeviceProperty(ByVal device As UaDevice, ByVal dproperty As UaDeviceProperty) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaOptimizeDeviceProperty(ByVal device As UaDevice, ByVal condition As UaOptimizationCondition, ByVal dproperty As IntPtr) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaOptimizeDevicePropertyFreq(ByVal device As UaDevice, ByVal nfrequency As Integer, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaOptimizeDevicePropertyROI(ByVal device As UaDevice, ByVal roi As UaRect, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaOptimizeDevicePropertyROIFreq(ByVal device As UaDevice, ByVal roi As UaRect, ByVal nfrequency As Integer, ByVal condition As UaOptimizationCondition, ByRef dproperty As UaDeviceProperty) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyRecipe(ByRef recipe As UaRecipe) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetOptimumAverageCount(ByRef device As UaDevice, ByVal target_frequency_hz As Integer, ByVal expose_time As Double, _
                                         ByRef average_count As Integer) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCaptureImage(ByVal device As IntPtr, ByVal filter_type As UaCaptureFilterType, ByVal average_count As Integer, ByVal data As IntPtr) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateImage(ByVal width As Integer, ByVal height As Integer) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateCaptureData(ByVal device_type As UaDeviceType) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyCaptureData(ByVal data As UaCaptureData) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateXYZImage(ByVal device_type As UaDeviceType, ByVal data_type As Integer) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyXYZImage(ByVal xyz_image As UaXYZImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateChromaticityImage(ByVal device_type As UaDeviceType) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyChromaticityImage(ByVal chromaticity As UaChromaticityImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroyImage(ByVal image As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSaveMeasurementData(ByVal directory_path As String, ByVal file_name As String, ByVal xyz_imange As UaXYZImage, ByVal recipe As UaRecipe) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaLoadMeasurementData(ByVal file_path As String, ByRef xyz_image As UaXYZImage, ByRef recipe As UaRecipe) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaToXYZImage(ByVal device As IntPtr, ByVal data As IntPtr, ByVal xyz_image As IntPtr) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCorrectXYZImageLevel(ByVal xyz_image As UaXYZImage, ByVal X_factor As Single, ByVal Y_factor As Single, ByVal Z_factor As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCorrectColor(ByVal device As UaDevice, ByVal xyz_image As UaXYZImage, ByVal type As UaColorCorrectionType) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaComputeAverageOfGrid(ByVal src_image As Single, ByVal image_width As Integer, ByVal image_height As Integer, ByVal num_partitions_x As Integer, ByVal num_partitions_y As Integer, ByRef dst_image As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaLoadAreaCorrection(ByVal filename As String, ByRef area_coef_x As UaImage, ByRef area_coef_y As UaImage, ByRef area_coef_z As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCorrectArea(ByVal xyz_image As UaXYZImage, ByVal area_coef_x As UaImage, ByVal area_coef_y As UaImage, ByVal area_coef_z As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCorrectSpot(ByVal spot_Correction_filename As String, ByVal xyz_image As UaXYZImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaToChromaticity(ByVal X As Single, ByVal Y As Single, ByVal Z As Single, ByVal color_space_type As UaColorSpaceType, ByRef chromaticity As UaChromaticity) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaToChromaticityImage(ByVal xyz_image As IntPtr, ByVal color_space_type As UaColorSpaceType, ByVal chromaticity As IntPtr) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaComputeColorTempAndDuv(ByVal uv As UaChromaticity, ByRef color_temp As Single, ByRef duv As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaComputeColorTempAndDuvImage(ByVal uv As UaChromaticityImage, ByRef color_temp As UaImage, ByRef duv As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaComputeWavelengthAndPurity(ByVal xy As UaChromaticity, ByVal ref_white_point As UaPoint, ByRef wavelength As Single, ByRef purity As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaComputeWavelengthAndPurityImage(ByVal xy As UaChromaticityImage, ByVal ref_white_point As UaPoint, ByRef wavelength As UaImage, ByRef purity As UaImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaCreateSpotList(ByVal size As Integer) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaDestroySpotList(ByVal spot_list As UaSpotList) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSetCircleSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal center As UaPoint, ByVal threshold_x As Single, ByVal threshold_y As Single, ByVal threshold_z As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSetSqureSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal center As UaPoint, ByVal threshold_x As Single, ByVal threshold_y As Single, ByVal threshold_z As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSetPolygonSpot(ByVal spot_list As UaSpotList, ByVal index As Integer, ByVal spot_id As Integer, ByVal point_data As UaPoint, ByVal point_size As Integer, ByVal threshold_x As Single, ByVal threshold_y As Single, ByVal threshold_z As Single) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaLoadSpotList(ByVal filename As String) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetSpot(ByVal xyz_image As UaXYZImage, ByVal spot As UaSpot) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetSpotList(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetMaskedSpot(ByVal xyz_image As UaXYZImage, ByVal spot As UaSpot) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaGetMaskedSpotList(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaMaskXYZImageWithSpot(ByVal xyz_image As UaXYZImage, ByVal spot_list As UaSpotList, ByVal mask_mode As UaImageMaskMode, ByRef result_image As UaXYZImage) As Integer
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaLoadRecipe(ByVal filename As String) As IntPtr
    End Function

    <DllImport("ua_core2.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Function _
                uaSaveRecipe(ByVal recipe As UaRecipe, ByVal filename As String) As Integer
    End Function
#End Region

#End Region
End Module
