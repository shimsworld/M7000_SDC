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
    <StructLayout(LayoutKind.Explicit)> Public Structure SplitUINT32
        <FieldOffset(0)> Public UINT32_Data As UInt32
        <FieldOffset(0)> Public ByteData0 As Byte
        <FieldOffset(1)> Public ByteData1 As Byte
        <FieldOffset(2)> Public ByteData2 As Byte
        <FieldOffset(3)> Public ByteData3 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure SplitINT16
        <FieldOffset(0)> Public INT16_Data As Int16
        <FieldOffset(0)> Public ByteData_L As Byte
        <FieldOffset(1)> Public ByteData_H As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)> Public Structure SplitINT32
        <FieldOffset(0)> Public INT32_Data As Int32
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


    <StructLayout(LayoutKind.Explicit)> Public Structure SplitDouble
        <FieldOffset(0)> Public DoubleData As Double
        <FieldOffset(0)> Public ByteData0_L As Byte
        <FieldOffset(1)> Public ByteData0_H As Byte
        <FieldOffset(2)> Public ByteData1_L As Byte
        <FieldOffset(3)> Public ByteData1_H As Byte
        <FieldOffset(4)> Public ByteData2_L As Byte
        <FieldOffset(5)> Public ByteData2_H As Byte
        <FieldOffset(6)> Public ByteData3_L As Byte
        <FieldOffset(7)> Public ByteData3_H As Byte
    End Structure


    Protected m_dValue As Double
    Protected m_sUnit As String    '변경된 값의 단위 저장
    Protected m_nDefUnitType As CUnitConverter.eType   '값의 기본 단위(V,A,W,m ...)
    Public m_dUnit() As Double = New Double() {10 ^ 18, 10 ^ 15, 10 ^ 12, 10 ^ 9, 10 ^ 6, 10 ^ 3, 10 ^ 2, 10 ^ 1, 10 ^ 0, 10 ^ -1, 10 ^ -2, 10 ^ -3, 10 ^ -6, 10 ^ -9, 10 ^ -12, 10 ^ -15, 10 ^ -18}
    Protected m_sUnitCaptions() As String '= New String() {"E", "P", "T", "G", "M", "K", "h", "deca", "", "deci", "c", "m", "u", "n", "p", "f", "a"}


    '  Protected m_sUnitCaption As String

    Public Overridable ReadOnly Property Unit() As String
        Get
            Return m_sUnit
        End Get
    End Property

    Public Overridable ReadOnly Property DefaultUnit() As String
        Get
            Return CUnitConverter.GetDefUnit(m_nDefUnitType)
        End Get
    End Property

    Public Overridable ReadOnly Property ValueType As String
        Get
            Return CUnitConverter.GetValueType(m_nDefUnitType)
        End Get
    End Property

#Region "Enums"


    Public Enum eMKSUnit
        Exa
        Peta
        Tera
        Giga
        Mega       '1000000
        Kilo       '1000
        hecto      '100
        deca       '10
        Def        '1   Default   =8
        deci       '1/10
        centi      '1/100
        mili       '1/1000
        micro      '1/1000000
        nano
        pico
        femto
        ato
    End Enum



#End Region

#Region "Creators"

    Public Sub New(ByVal value As Double)
        m_dValue = value
        m_sUnitCaptions = GetUnitList()
    End Sub

    Public Sub New()
    End Sub

#End Region

#Region "Sub Functions"



    Public Overridable Function ToExa() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Exa)
    End Function
    Public Overridable Function ToPeta() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Peta)
    End Function

    Public Overridable Function ToTera() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Tera)
    End Function

    Public Overridable Function ToGiga() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Giga)
    End Function

    Public Overridable Function ToMega() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Mega)
    End Function

    Public Overridable Function ToKilo() As Double
        Return m_dValue / m_dUnit(eMKSUnit.Kilo)
    End Function

    Public Overridable Function ToHecto() As Double
        Return m_dValue / m_dUnit(eMKSUnit.hecto)
    End Function

    Public Overridable Function ToDeca() As Double
        Return m_dValue / m_dUnit(eMKSUnit.deca)
    End Function

    Public Overridable Function ToDeci() As Double
        Return m_dValue / m_dUnit(eMKSUnit.deci)
    End Function

    Public Overridable Function ToCenti() As Double
        Return m_dValue / m_dUnit(eMKSUnit.centi)
    End Function

    Public Overridable Function ToMili() As Double
        Return m_dValue / m_dUnit(eMKSUnit.mili)
    End Function

    Public Overridable Function ToMicro() As Double
        Return m_dValue / m_dUnit(eMKSUnit.micro)
    End Function

    Public Overridable Function ToNano() As Double
        Return m_dValue / m_dUnit(eMKSUnit.nano)
    End Function

    Public Overridable Function ToPico() As Double
        Return m_dValue / m_dUnit(eMKSUnit.pico)
    End Function

    Public Overridable Function ToFemto() As Double
        Return m_dValue / m_dUnit(eMKSUnit.femto)
    End Function

    Public Overridable Function ToAto() As Double
        Return m_dValue / m_dUnit(eMKSUnit.ato)
    End Function

    Public Overridable Function ConvertToDef(ByVal dValue As Double, ByVal ValueUnit As eMKSUnit) As Double
        Return dValue * m_dUnit(ValueUnit)
    End Function

    Public Overridable Function ConvertToDef(ByVal dValue As Double, ByVal ValueUnit1 As eMKSUnit, ByVal ValueUnit2 As eMKSUnit) As Double

        Return 0
    End Function


    Public Overridable Function ConvertTo(ByVal targetUnit As eMKSUnit) As Double
        Return m_dValue / m_dUnit(targetUnit)
    End Function

    Public Overridable Function ConvertTo(ByVal targetAmpereUnit As CUnitCommonNode.eMKSUnit, ByVal targetAreaUnit As CUnitCommonNode.eMKSUnit) As Double

        Dim dOrder As Double
        'Dim dArea As Double
        'Dim dAmpere As Double

        'dArea = Math.Sqrt(m_dUnit(targetAreaUnit))
        'dAmpere = m_dUnit(targetAmpereUnit)

        'dOrder = dAmpere / dArea

        'm_dValue = m_dValue / dOrder

        'm_sUnit = m_sUnitCaptions(targetAmpereUnit) & m_sMyUnitCaption1 & "/" & m_sUnitCaptions(targetAmpereUnit) & m_sMyUnitCaption2

        Return dOrder
    End Function

    Public Shared Function GetUnitList() As String()
        Dim sUnit(16) As String

        '= New String() {"E", "P", "T", "G", "M", "K", "h", "deca", "", "deci", "c", "m", "u", "n", "p", "f", "a"}
        sUnit(0) = "E"
        sUnit(1) = "P"
        sUnit(2) = "T"
        sUnit(3) = "G"
        sUnit(4) = "M"
        sUnit(5) = "K"
        sUnit(6) = "h"
        sUnit(7) = "deca"
        sUnit(8) = ""
        sUnit(9) = "deci"
        sUnit(10) = "c"
        sUnit(11) = "m"
        sUnit(12) = "u"
        sUnit(13) = "n"
        sUnit(14) = "p"
        sUnit(15) = "f"
        sUnit(16) = "a"

        Return sUnit.Clone
    End Function


#End Region



    Public Overridable Function converter() As Double
        Return 1
    End Function

    Public Overloads Function ConvertUnit() As Double
        Return 2
    End Function

End Class
