Imports System.Math
Imports System.IO

Public Class CCalibration



    Public Function MatrixMulti(ByVal mAmatrix(,) As Double, ByVal mBmatrix(,) As Double, ByRef mCmatrix(,) As Double) As Boolean
        Dim nArowcount As Integer = 0
        Dim nBrowcount As Integer = 0
        Dim nAcolcount As Integer = 0
        Dim nBcolcount As Integer = 0

        Try
            For i As Integer = 0 To mAmatrix.Length - 1
                Try
                    Dim buff As Double
                    buff = mAmatrix(i, 0)
                    nArowcount += 1

                Catch ex As Exception
                    Exit For
                End Try
            Next

            For i As Integer = 0 To mBmatrix.Length - 1
                Try
                    Dim buff As Double
                    buff = mBmatrix(0, i)
                    nBcolcount += 1

                Catch ex As Exception
                    Exit For
                End Try
            Next

            nAcolcount = mAmatrix.Length / nArowcount
            nBrowcount = mBmatrix.Length / nBcolcount

            If nAcolcount <> nBrowcount Then
                MsgBox("Do Not Multiplication")
                Return False
            End If

       
            ReDim mCmatrix(nArowcount - 1, nBcolcount - 1)
            Dim sum As Double = 0

            For i As Integer = 0 To nArowcount - 1

                For j As Integer = 0 To nBcolcount - 1
                    sum = 0
                    For k As Integer = 0 To mAmatrix.Length / nArowcount - 1
                        sum = sum + mAmatrix(i, k) * mBmatrix(k, j)
                    Next
                    mCmatrix(i, j) = sum
                Next
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function MatrixTrans(ByVal mAmatrix(,) As Double, ByRef mCmatrix(,) As Double) As Boolean
        Dim nAcolcount As Integer = 0
        Try

            For i As Integer = 0 To mAmatrix.Length - 1
                Try
                    Dim buff As Double
                    buff = mAmatrix(0, i)
                    nAcolcount += 1

                Catch ex As Exception
                    Exit For
                End Try
            Next
            Dim column As Integer = nAcolcount
            Dim row As Integer = mAmatrix.Length / nAcolcount

            ReDim mCmatrix(column - 1, row - 1)
            '      ReDim mCmatrix(row - 1, column - 1)
            '        ReDim mCmatrix(row - 1, column - 1)

            For i As Integer = 0 To column - 1
                For j As Integer = 0 To row - 1
                    mCmatrix(i, j) = mAmatrix(j, i)
                Next
            Next

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function MatrixInverse(ByVal mAmatrix(,) As Double, ByRef mCmatrix(,) As Double) As Boolean

        Try
            Inverse(mAmatrix, Math.Sqrt(mAmatrix.Length), mCmatrix)

            '    Cofactor(mAmatrix, Math.Sqrt(mAmatrix.Length), mCmatrix)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function Inverse(ByVal mAmatrix(,) As Double, ByVal n As Integer, ByRef mCmatrix(,) As Double) As Boolean

        ReDim Preserve mAmatrix(n - 1, 2 * n - 1)
        Dim ratio As Double
        Dim det As Double

        For i As Integer = 0 To n - 1

            For j As Integer = n To 2 * n - 1
                If i = (j - n) Then
                    mAmatrix(i, j) = 1
                Else
                    mAmatrix(i, j) = 0
                End If
            Next
        Next

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To n - 1
                If (i <> j) Then
                    ratio = mAmatrix(j, i) / mAmatrix(i, i)
                    For k As Integer = 0 To 2 * n - 1
                        mAmatrix(j, k) -= ratio * mAmatrix(i, k)
                    Next
                End If
            Next
        Next

        For i As Integer = 0 To n - 1
            det = mAmatrix(i, i)
            For j As Integer = 0 To 2 * n - 1
                mAmatrix(i, j) /= det
            Next
        Next

        Dim msmatrix(n - 1, n - 1) As Double
        Dim ncount As Integer = 0
        '   For k As Integer = 0 To n - 1
        For i As Integer = 0 To n - 1
            ncount = 0
            For j As Integer = n To 2 * n - 1
                msmatrix(i, ncount) = mAmatrix(i, j)
                ncount += 1
            Next
        Next
        '  Next

        mCmatrix = msmatrix.Clone
        Return True
    End Function

    Public Function Inverse2(ByVal mAmatrix(,) As Double, ByVal n As Integer, ByRef mCmatrix(,) As Double) As Boolean

        Dim det As Double

        Dim msmatrix(n - 1, n - 1) As Double

        det = mAmatrix(0, 0) * (mAmatrix(1, 1) * mAmatrix(2, 2) - mAmatrix(1, 2) * mAmatrix(2, 1)) - mAmatrix(0, 1) * (mAmatrix(1, 0) * mAmatrix(2, 2) - mAmatrix(1, 2) * mAmatrix(2, 0)) + mAmatrix(0, 2) * (mAmatrix(1, 0) * mAmatrix(2, 1) - mAmatrix(2, 0) * mAmatrix(1, 1))

        msmatrix(0, 0) = mAmatrix(1, 1) * mAmatrix(2, 2) - mAmatrix(1, 2) * mAmatrix(2, 1)
        msmatrix(0, 1) = -(mAmatrix(1, 0) * mAmatrix(2, 2) - mAmatrix(1, 2) * mAmatrix(2, 0))
        msmatrix(0, 2) = mAmatrix(1, 0) * mAmatrix(2, 1) - mAmatrix(1, 1) * mAmatrix(2, 0)
        msmatrix(1, 0) = -(mAmatrix(0, 1) * mAmatrix(2, 2) - mAmatrix(2, 1) * mAmatrix(0, 2))
        msmatrix(1, 1) = mAmatrix(0, 0) * mAmatrix(2, 2) - mAmatrix(0, 2) * mAmatrix(2, 0)
        msmatrix(1, 2) = -(mAmatrix(0, 0) * mAmatrix(2, 1) - mAmatrix(0, 1) * mAmatrix(2, 0))
        msmatrix(2, 0) = mAmatrix(0, 1) * mAmatrix(1, 2) - mAmatrix(0, 2) * mAmatrix(1, 1)
        msmatrix(2, 1) = -(mAmatrix(0, 0) * mAmatrix(1, 2) - mAmatrix(0, 2) * mAmatrix(1, 0))
        msmatrix(2, 2) = mAmatrix(0, 0) * mAmatrix(1, 1) - mAmatrix(0, 1) * mAmatrix(1, 0)

        MatrixTrans(msmatrix, mCmatrix)

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                mCmatrix(i, j) = mCmatrix(i, j) / det
            Next
        Next
        Return True
    End Function


End Class
