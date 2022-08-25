Imports System
Imports System.IO

Module MMainModule


#Region "Convert Function"
    Public Function fConvertInt8Byte(ByVal inValue As Byte) As Integer


        Dim bVal As Integer



        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.ByteData = inValue


        bVal = convertedValue.UINT8_Data



        Return bVal
    End Function
    Public Function fConvertByteInt16(ByVal inValue As Int16) As Byte()


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16
        convertedValue.UINT16_Data = inValue


        bVal(1) = (convertedValue.ByteData_L)
        bVal(0) = (convertedValue.ByteData_H)



        Return bVal
    End Function


    Public Function fConvertBytesShort(ByVal inValueArr() As Byte) As UShort
        Dim bVal(1) As Byte

        Dim convertedValue As CUnitCommonNode.SplitUShort

        convertedValue.ByteData_L = inValueArr(1)
        convertedValue.ByteData_H = inValueArr(0)
        Return convertedValue.UshortData
    End Function

    Public Function fConvertInt16Byte(ByVal inValueArr() As Byte) As Int16


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16



        convertedValue.ByteData_L = inValueArr(1)
        convertedValue.ByteData_H = inValueArr(0)



        Return convertedValue.UINT16_Data
    End Function
    Public Function fConvertInt24Byte(ByVal inValueArr() As Byte) As UInteger


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24



        convertedValue.ByteDataL = inValueArr(2)
        convertedValue.ByteDataM = inValueArr(1)
        convertedValue.ByteDataH = inValueArr(0)



        Return convertedValue.UINT24_Data
    End Function
    Public Function fConvert24ByteInt(ByVal inValue As UInteger) As Byte()


        Dim bVal(2) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24



        bVal(2) = convertedValue.ByteDataL
        bVal(1) = convertedValue.ByteDataM
        bVal(0) = convertedValue.ByteDataH



        Return bVal
    End Function
    Public Function fConvertSingleByte(ByVal inValueArr() As Byte) As Single

        Dim bVal(3) As Byte

        Try

            If inValueArr.Length = 4 Then
                Dim convertedValue As CUnitCommonNode.SplitSingle

                convertedValue.ByteData0_L = inValueArr(0)
                convertedValue.ByteData0_H = inValueArr(1)
                convertedValue.ByteData1_L = inValueArr(2)
                convertedValue.ByteData1_H = inValueArr(3)


                Return convertedValue.SingleData
            Else
                Return 0
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

        Return 0

    End Function

    Public Function fConvertInt32Byte(ByVal inValueArr() As Byte) As Int32

        Dim bVal(3) As Byte

        Try

            If inValueArr.Length = 4 Then
                Dim convertedValue As CUnitCommonNode.SplitUINT32

                convertedValue.ByteData0 = inValueArr(0)
                convertedValue.ByteData1 = inValueArr(1)
                convertedValue.ByteData2 = inValueArr(2)
                convertedValue.ByteData3 = inValueArr(3)

                Return convertedValue.UINT32_Data
            Else
                Return 0
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

        Return 0

    End Function
    Public Function fConver32tBytesInt(ByVal inValue As Int32) As Byte()

        Dim bVal(3) As Byte

        Dim byteArray As Byte() = BitConverter.GetBytes(inValue)

        bVal(0) = byteArray(0)
        bVal(1) = byteArray(1)
        bVal(2) = byteArray(2)
        bVal(3) = byteArray(3)

        Return bVal
    End Function

    Public Function fConvertBytesSingle(ByVal inValue As Single) As Byte()

        Dim bVal(3) As Byte

        Dim byteArray As Byte() = BitConverter.GetBytes(inValue)

        bVal(0) = byteArray(0)
        bVal(1) = byteArray(1)
        bVal(2) = byteArray(2)
        bVal(3) = byteArray(3)

        Return bVal
    End Function

    Public Function DecToBin(ByVal ival As Long) As String
        Dim redata As String = ""
        DecToBin = ""
        Do Until ival = 0
            DecToBin = CStr((ival Mod 2)) + DecToBin
            ival = ival \ 2
        Loop
        redata = DecToBin
        Return redata
    End Function

    Public Function Dec2Bin(ByVal inValue As Integer) As String
        Dim d As Integer
        Dim n As Integer = inValue
        Dim m As Integer
        Dim ret As String = ""

        Do
            d = n \ 2 '몫
            m = n Mod 2 '나머지
            ret = CStr(m) & ret '나머지 보관(문자열)

            n = d
        Loop Until d < 2

        If d > 0 Then ret = d & ret

        Return ret
    End Function



#End Region

End Module
