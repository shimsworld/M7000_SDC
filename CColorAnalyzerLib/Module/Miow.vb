﻿Option Strict Off
Option Explicit On


Module Miow

#Region "Defines DLL API Function"
    ' Required kernel32 functions
    Public Declare Function GetLastError Lib "kernel32" () As Integer

    ' IOW SDK V1.5

    ' IO-Warrior vendor & product IDs
    Public Const IOWKIT_VENDOR_ID As Integer = &H7C0S
    Public Const IOWKIT_VID As Integer = IOWKIT_VENDOR_ID

    ' IO-Warrior 40
    Public Const IOWKIT_PRODUCT_ID_IOW40 As Integer = &H1500S
    Public Const IOWKIT_PID_IOW40 As Integer = IOWKIT_PRODUCT_ID_IOW40

    ' IO-Warrior 24
    Public Const IOWKIT_PRODUCT_ID_IOW24 As Integer = &H1501S
    Public Const IOWKIT_PID_IOW24 As Integer = IOWKIT_PRODUCT_ID_IOW24

    ' IO-Warrior PowerVampire
    Public Const IOWKIT_PRODUCT_ID_IOWPV1 As Integer = &H1511S
    Public Const IOWKIT_PID_IOWPV1 As Integer = IOWKIT_PRODUCT_ID_IOWPV1
    Public Const IOWKIT_PRODUCT_ID_IOWPV2 As Integer = &H1512S
    Public Const IOWKIT_PID_IOWPV2 As Integer = IOWKIT_PRODUCT_ID_IOWPV2

    ' IO-Warrior 56
    Public Const IOWKIT_PRODUCT_ID_IOW56 As Integer = &H1503S
    Public Const IOWKIT_PID_IOW56 As Integer = IOWKIT_PRODUCT_ID_IOW56

    ' Max number of pipes per IOW device
    Public Const IOWKIT_MAX_PIPES As Integer = 2

    ' pipe names
    Public Const IOW_PIPE_IO_PINS As Integer = 0
    Public Const IOW_PIPE_SPECIAL_MODE As Integer = 1

    ' Max number of IOW devices in system
    Public Const IOWKIT_MAX_DEVICES As Integer = 16

    ' IOW Legacy devices open modes
    Public Const IOW_OPEN_SIMPLE As Integer = 1
    Public Const IOW_OPEN_COMPLEX As Integer = 2

    ' first IO-Warrior revision with serial numbers
    Public Const IOW_NON_LEGACY_REVISION As Short = &H1010S

    ' IO-Warrior low-level library API functions

    'Public Declare Function IowKitOpenDevice Lib "..\..\DLL\iowkit" () As Integer

    'Public Declare Sub IowKitCloseDevice Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer)

    'Public Declare Function IowKitWrite Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    'Public Declare Function IowKitRead Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    'Public Declare Function IowKitReadNonBlocking Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    'Public Declare Function IowKitReadImmediate Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByRef Value As Integer) As Integer

    '' Get number of IOW devices
    'Public Declare Function IowKitGetNumDevs Lib "..\..\DLL\iowkit" () As Integer

    '' Get Nth IOW device handle
    'Public Declare Function IowKitGetDeviceHandle Lib "..\..\DLL\iowkit" (ByVal numDevice As Integer) As Integer

    'Public Declare Function IowKitSetLegacyOpenMode Lib "..\..\DLL\iowkit" (ByVal openMode As Integer) As Integer

    'Public Declare Function IowKitGetProductId Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer) As Integer

    'Public Declare Function IowKitGetRevision Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer) As Integer

    'Public Declare Function IowKitGetThreadHandle Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer) As Integer

    'Public Declare Function IowKitGetSerialNumber Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByRef serialNumber As Byte) As Integer

    'Public Declare Function IowKitSetTimeout Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal TimeOut As Integer) As Integer

    'Public Declare Function IowKitSetWriteTimeout Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal TimeOut As Integer) As Integer

    'Public Declare Function IowKitCancelIo Lib "..\..\DLL\iowkit" (ByVal iowHandle As Integer, ByVal numPipe As Integer) As Integer

    Public Declare Function IowKitOpenDevice Lib "DLL\iowkit.dll" () As Integer

    Public Declare Sub IowKitCloseDevice Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer)

    Public Declare Function IowKitWrite Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    Public Declare Function IowKitRead Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    Public Declare Function IowKitReadNonBlocking Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal numPipe As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    Public Declare Function IowKitReadImmediate Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByRef Value As Integer) As Integer

    ' Get number of IOW devices
    Public Declare Function IowKitGetNumDevs Lib "DLL\iowkit.dll" () As Integer

    ' Get Nth IOW device handle
    Public Declare Function IowKitGetDeviceHandle Lib "DLL\iowkit.dll" (ByVal numDevice As Integer) As Integer

    Public Declare Function IowKitSetLegacyOpenMode Lib "DLL\iowkit.dll" (ByVal openMode As Integer) As Integer

    Public Declare Function IowKitGetProductId Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer) As Integer

    Public Declare Function IowKitGetRevision Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer) As Integer

    Public Declare Function IowKitGetThreadHandle Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer) As Integer

    Public Declare Function IowKitGetSerialNumber Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByRef serialNumber As Byte) As Integer

    Public Declare Function IowKitSetTimeout Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal TimeOut As Integer) As Integer

    Public Declare Function IowKitSetWriteTimeout Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal TimeOut As Integer) As Integer

    Public Declare Function IowKitCancelIo Lib "DLL\iowkit.dll" (ByVal iowHandle As Integer, ByVal numPipe As Integer) As Integer


   
#End Region


#Region "Functions"

#End Region

End Module
