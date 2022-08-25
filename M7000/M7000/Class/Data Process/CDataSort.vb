Public Class CDataSort

    Public Shared Function BubbleSort_RemoveZero(ByVal datas() As Integer, ByVal n As Integer) As Integer()

        Dim dTempData As Double
        Dim i, j As Integer
        Dim nCnt As Integer

        Dim dSortDatas(n - 1) As Integer

        Dim sortedDatas() As Integer

        dSortDatas = datas.Clone

        For i = 0 To n - 1
            For j = 1 To n - 1

                If dSortDatas(j - 1) > dSortDatas(j) Then
                    '' 교환 
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = dSortDatas(j)
                    dSortDatas(j) = dTempData
                ElseIf dSortDatas(j - 1) = dSortDatas(j) Then
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = 0
                    dSortDatas(j) = (dTempData + (dSortDatas(j))) / 2
                End If
            Next
        Next

        For i = 0 To dSortDatas.Length - 1
            If dSortDatas(i) = 0 Then
                nCnt += 1
            End If
        Next

        ReDim sortedDatas(dSortDatas.Length - nCnt - 1)

        For i = 0 To sortedDatas.Length - 1
            sortedDatas(i) = dSortDatas(i + nCnt)
        Next

        Return sortedDatas.Clone

    End Function

    Public Shared Function BubbleSort_RemoveZero(ByVal datas() As Double, ByVal n As Integer) As Double()

        Dim dTempData As Double
        Dim i, j As Integer
        Dim nCnt As Integer

        Dim dSortDatas(n - 1) As Double

        Dim sortedDatas() As Double

        dSortDatas = datas.Clone

        For i = 0 To n - 1
            For j = 1 To n - 1

                If dSortDatas(j - 1) > dSortDatas(j) Then
                    '' 교환 
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = dSortDatas(j)
                    dSortDatas(j) = dTempData
                ElseIf dSortDatas(j - 1) = dSortDatas(j) Then
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = 0
                    dSortDatas(j) = (dTempData + (dSortDatas(j))) / 2
                End If
            Next
        Next

        For i = 0 To dSortDatas.Length - 1
            If dSortDatas(i) = 0 Then
                nCnt += 1
            End If
        Next

        ReDim sortedDatas(dSortDatas.Length - nCnt - 1)

        For i = 0 To sortedDatas.Length - 1
            sortedDatas(i) = dSortDatas(i + nCnt)
        Next

        Return sortedDatas.Clone

    End Function


    Public Shared Function BubbleSort(ByVal datas() As Double, ByVal n As Integer) As Double()

        Dim dTempData As Double
        Dim i, j As Integer

        Dim dSortDatas(n - 1) As Double

        dSortDatas = datas.Clone

        For i = 0 To n - 1
            For j = 1 To n - 1

                If dSortDatas(j - 1) > dSortDatas(j) Then
                    '' 교환 
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = dSortDatas(j)
                    dSortDatas(j) = dTempData
                ElseIf dSortDatas(j - 1) = dSortDatas(j) Then
                    dTempData = dSortDatas(j - 1)
                    dSortDatas(j - 1) = 0
                    dSortDatas(j) = (dTempData + (dSortDatas(j))) / 2
                End If
            Next
        Next

        Return dSortDatas.Clone

    End Function

    Public Shared Function MedianFilter(ByVal datas() As Double) As Double
        Dim sortedDatas() As Double = BubbleSort_RemoveZero(datas, datas.Length)

        If sortedDatas Is Nothing Then Return 0

        If sortedDatas.Length > 1 Then
            Return sortedDatas(Fix(sortedDatas.Length / 2))
        ElseIf sortedDatas.Length = 1 Then
            Return sortedDatas(sortedDatas.Length - 1)
        Else
            Return 0
        End If
    End Function

 

    Public Shared Function AverageFilter(ByVal datas() As Double) As Double
        Dim dataLen As Integer
        Dim dSum As Double = 0
        Dim dAvg As Double
        If datas Is Nothing Then Return 0

        dataLen = datas.Length

        If dataLen < 4 Then
            For i As Integer = 0 To dataLen - 1
                dSum += datas(i)
            Next
            dSum = dSum - datas.Min - datas.Max
            dAvg = dSum / (dataLen - 2)
        Else
            For i As Integer = 0 To dataLen - 1
                dSum += datas(i)
            Next
            dAvg = dSum / dataLen
        End If

        Return dAvg
    End Function


    Public Shared Function AverageFilter(ByVal datas() As CColorAnalyzerLib.CDevCAxxxCMD.sDatas) As CColorAnalyzerLib.CDevCAxxxCMD.sDatas

        Dim arrValue(24)() As Double

        Dim retData As CColorAnalyzerLib.CDevCAxxxCMD.sDatas

        For i As Integer = 0 To arrValue.Length - 1
            ReDim arrValue(i)(datas.Length - 1)
        Next

        For i As Integer = 0 To datas.Length - 1
            With datas(i)
                arrValue(0)(i) = .Lv
                arrValue(1)(i) = .sx
                arrValue(2)(i) = .sy
                arrValue(3)(i) = .CCT
                arrValue(4)(i) = .MPCD
                arrValue(5)(i) = .BBL_u
                arrValue(6)(i) = .BBL_v
                arrValue(7)(i) = .BBL_x
                arrValue(8)(i) = .BBL_y
                arrValue(9)(i) = .u
                arrValue(10)(i) = .v
                arrValue(11)(i) = .ud
                arrValue(12)(i) = .vd

                arrValue(13)(i) = .duv
                arrValue(14)(i) = .T
                arrValue(15)(i) = .Rvalue
                arrValue(16)(i) = .Gvalue
                arrValue(17)(i) = .Bvalue
                arrValue(18)(i) = .LsUser
                arrValue(19)(i) = .dEUser
                arrValue(20)(i) = .usUser
                arrValue(21)(i) = .vsUser
                arrValue(22)(i) = .X
                arrValue(23)(i) = .Y
                arrValue(24)(i) = .Z
            End With
        Next


        With retData
            .Lv = AverageFilter(arrValue(0))
            .sx = AverageFilter(arrValue(1))
            .sy = AverageFilter(arrValue(2))
            .CCT = AverageFilter(arrValue(3))
            .MPCD = AverageFilter(arrValue(4))
            .BBL_u = AverageFilter(arrValue(5))
            .BBL_v = AverageFilter(arrValue(6))
            .BBL_x = AverageFilter(arrValue(7))
            .BBL_y = AverageFilter(arrValue(8))
            .u = AverageFilter(arrValue(9))
            .v = AverageFilter(arrValue(10))
            .ud = AverageFilter(arrValue(11))
            .vd = AverageFilter(arrValue(12))
        End With

        Return retData
    End Function






End Class
