Imports System.Runtime.InteropServices

Public Class CUnitCommonNode
    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUINT24
        <FieldOffset(0)> Public UINT24_Data As UInteger

        <FieldOffset(0)> Public ByteDataL As Byte
        <FieldOffset(1)> Public ByteDataM As Byte
        <FieldOffset(2)> Public ByteDataH As Byte
    End Structure
    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUINT8
        <FieldOffset(0)> Public UINT8_Data As UInteger
        <FieldOffset(0)> Public ByteData As Byte

    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUINT16
        <FieldOffset(0)> Public UINT16_Data As UInt16
        <FieldOffset(0)> Public ByteData_L As Byte
        <FieldOffset(1)> Public ByteData_H As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUShort
        <FieldOffset(0)> Public UshortData As UShort
        <FieldOffset(0)> Public ByteData_L As Byte
        <FieldOffset(1)> Public ByteData_H As Byte
    End Structure


    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUINT32
        <FieldOffset(0)> Public UINT32_Data As UInt32
        <FieldOffset(0)> Public ByteData0 As Byte
        <FieldOffset(1)> Public ByteData1 As Byte
        <FieldOffset(2)> Public ByteData2 As Byte
        <FieldOffset(3)> Public ByteData3 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure SplitSingle
        <FieldOffset(0)> Public SingleData As Single
        <FieldOffset(0)> Public ByteData0_L As Byte
        <FieldOffset(1)> Public ByteData0_H As Byte
        <FieldOffset(2)> Public ByteData1_L As Byte
        <FieldOffset(3)> Public ByteData1_H As Byte
    End Structure

End Class
