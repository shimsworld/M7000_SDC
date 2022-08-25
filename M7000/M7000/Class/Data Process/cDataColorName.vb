Public Class cDataColorName

#Region "Define"
    Dim m_ColorName() As String = New String() {"Red", "Green", "Blue", "White"}

    Dim m_RedColorValue_R() As Integer = New Integer() {255, 250, 233, 240, 205, 220, 178, 139, 255}
    Dim m_RedColorValue_G() As Integer = New Integer() {160, 128, 150, 128, 92, 20, 34, 0, 0}
    Dim m_RedColorValue_B() As Integer = New Integer() {122, 114, 122, 128, 92, 60, 34, 0, 0}
    Dim m_GreenColorValue_R() As Integer = New Integer() {85, 128, 107, 154, 50, 0, 124, 127, 173, 0, 0, 144, 152, 143, 102, 60, 46, 34, 0, 0}
    Dim m_GreenColorValue_G() As Integer = New Integer() {107, 128, 142, 205, 205, 255, 252, 255, 255, 255, 250, 238, 251, 188, 205, 179, 139, 139, 128, 100}
    Dim m_GreenColorValue_B() As Integer = New Integer() {47, 0, 35, 50, 50, 0, 0, 0, 47, 127, 154, 144, 152, 143, 170, 113, 87, 34, 0, 0}
    Dim m_BlueColorValue_R() As Integer = New Integer() {176, 176, 173, 135, 135, 0, 30, 100, 70, 65, 0, 0, 0, 0, 25}
    Dim m_BlueColorValue_G() As Integer = New Integer() {196, 224, 216, 206, 206, 191, 144, 149, 130, 105, 0, 0, 0, 0, 25}
    Dim m_BlueColorValue_B() As Integer = New Integer() {222, 230, 230, 235, 250, 255, 255, 237, 180, 225, 255, 205, 139, 128, 112}
    Dim m_WhiteColorValue_R() As Integer = New Integer() {255, 255, 240, 245, 240, 240, 248, 245, 255, 245, 253, 255, 255, 250, 250, 255, 255}
    Dim m_WhiteColorValue_G() As Integer = New Integer() {255, 250, 255, 255, 255, 248, 248, 245, 245, 245, 245, 250, 255, 235, 240, 240, 228}
    Dim m_WhiteColorValue_B() As Integer = New Integer() {255, 250, 240, 250, 255, 255, 255, 245, 238, 220, 230, 240, 240, 215, 230, 245, 225}

    Dim m_RedColor_CIEx() As Double
    Dim m_RedColor_CIEy() As Double
    Dim m_GreenColor_CIEx() As Double
    Dim m_GreenColor_CIEy() As Double
    Dim m_BlueColor_CIEx() As Double
    Dim m_BlueColor_CIEy() As Double
    Dim m_WhiteColor_CIEx() As Double
    Dim m_WhiteColor_CIEy() As Double

    Dim m_Red() As Double = New Double() {0.41847, -0.15866, -0.082835}
    Dim m_Green() As Double = New Double() {-0.091169, 0.25243, 0.015708}
    Dim m_Blue() As Double = New Double() {0.0009209, -0.0025498, 0.1786}
    Dim m_ColorNamingFactor(,) As Double = New Double(,) {{0.41847, -0.15866, -0.082835}, {-0.091169, 0.25243, 0.015708}, {0.0009209, -0.0025498, 0.1786}}

    Public Enum eColor
        eRed
        eGreen
        eBlue
        eWhite
    End Enum
#End Region

    Public Sub New()
        init()
    End Sub

    Public Sub init()
        Dim dX As Double
        Dim dY As Double
        Dim dZ As Double
        Dim dCIEx() As Double
        Dim dCIEy() As Double
        Dim dInverseColorNamingFactor(,) As Double = Nothing
        Dim dRGB(,) As Double = Nothing
        Dim dXYZ(,) As Double = Nothing

        'Red
        ReDim dCIEx(m_RedColorValue_R.Length - 1)
        ReDim dCIEy(m_RedColorValue_R.Length - 1)
        ReDim dRGB(2, 0)
        For i As Integer = 0 To dCIEx.Length - 1
            '행열 계산 필요

            dRGB(0, 0) = m_RedColorValue_R(i)
            dRGB(1, 0) = m_RedColorValue_G(i)
            dRGB(2, 0) = m_RedColorValue_B(i)

            MatrixInverse(m_ColorNamingFactor, dInverseColorNamingFactor)
            MatrixMulti(dInverseColorNamingFactor, dRGB, dXYZ)

            dX = dXYZ(0, 0)
            dY = dXYZ(1, 0)
            dZ = dXYZ(2, 0)

            'Chromaticity diagram
            dCIEx(i) = dX / (dX + dY + dZ)
            dCIEy(i) = dY / (dX + dY + dZ)

        Next
        m_RedColor_CIEx = dCIEx.Clone
        m_RedColor_CIEy = dCIEy.Clone



        'Green
        ReDim dCIEx(m_GreenColorValue_R.Length - 1)
        ReDim dCIEy(m_GreenColorValue_R.Length - 1)
        ReDim dRGB(2, 0)
        For i As Integer = 0 To dCIEx.Length - 1
            '행열 계산 필요

            dRGB(0, 0) = m_GreenColorValue_R(i)
            dRGB(1, 0) = m_GreenColorValue_G(i)
            dRGB(2, 0) = m_GreenColorValue_B(i)

            MatrixInverse(m_ColorNamingFactor, dInverseColorNamingFactor)
            MatrixMulti(dInverseColorNamingFactor, dRGB, dXYZ)

            dX = dXYZ(0, 0)
            dY = dXYZ(1, 0)
            dZ = dXYZ(2, 0)
            'Chromaticity diagram
            dCIEx(i) = dX / (dX + dY + dZ)
            dCIEy(i) = dY / (dX + dY + dZ)
        Next
        m_GreenColor_CIEx = dCIEx.Clone
        m_GreenColor_CIEy = dCIEy.Clone

        'Blue
        ReDim dCIEx(m_BlueColorValue_R.Length - 1)
        ReDim dCIEy(m_BlueColorValue_R.Length - 1)
        ReDim dRGB(2, 0)
        For i As Integer = 0 To dCIEx.Length - 1
            '행열 계산 필요

            dRGB(0, 0) = m_BlueColorValue_R(i)
            dRGB(1, 0) = m_BlueColorValue_G(i)
            dRGB(2, 0) = m_BlueColorValue_B(i)

            MatrixInverse(m_ColorNamingFactor, dInverseColorNamingFactor)
            MatrixMulti(dInverseColorNamingFactor, dRGB, dXYZ)

            dX = dXYZ(0, 0)
            dY = dXYZ(1, 0)
            dZ = dXYZ(2, 0)
            'Chromaticity diagram
            dCIEx(i) = dX / (dX + dY + dZ)
            dCIEy(i) = dY / (dX + dY + dZ)
        Next
        m_BlueColor_CIEx = dCIEx.Clone
        m_BlueColor_CIEy = dCIEy.Clone

        'White
        ReDim dCIEx(m_WhiteColorValue_R.Length - 1)
        ReDim dCIEy(m_WhiteColorValue_R.Length - 1)
        ReDim dRGB(2, 0)
        For i As Integer = 0 To dCIEx.Length - 1
            '행열 계산 필요

            dRGB(0, 0) = m_WhiteColorValue_R(i)
            dRGB(1, 0) = m_WhiteColorValue_G(i)
            dRGB(2, 0) = m_WhiteColorValue_B(i)

            MatrixInverse(m_ColorNamingFactor, dInverseColorNamingFactor)
            MatrixMulti(dInverseColorNamingFactor, dRGB, dXYZ)

            dX = dXYZ(0, 0)
            dY = dXYZ(1, 0)
            dZ = dXYZ(2, 0)

            'Chromaticity diagram
            dCIEx(i) = dX / (dX + dY + dZ)
            dCIEy(i) = dY / (dX + dY + dZ)
        Next
        m_WhiteColor_CIEx = dCIEx.Clone
        m_WhiteColor_CIEy = dCIEy.Clone


    End Sub


    Public Function ColorAnalysis(ByVal dCIEx As Double, ByVal dCIEy As Double, ByRef nColor As eColor) As Boolean
        Dim dR As Double
        Dim dTempR As Double

        Try
            'Red
            For i As Integer = 0 To m_RedColor_CIEx.Length - 1
                dR = Math.Sqrt((dCIEx - m_RedColor_CIEx(i)) ^ 2 + (dCIEy - m_RedColor_CIEy(i)) ^ 2)
                '처음에는 값이 없어서 Red 처음 계산할 때 넣어줌
                If i = 0 Then
                    dTempR = dR
                    nColor = eColor.eRed
                End If
                If dR < dTempR Then
                    dTempR = dR
                    nColor = eColor.eRed
                End If
            Next

            'Green
            For i As Integer = 0 To m_GreenColor_CIEx.Length - 1
                dR = Math.Sqrt((dCIEx - m_GreenColor_CIEx(i)) ^ 2 + (dCIEy - m_GreenColor_CIEy(i)) ^ 2)
                If dR < dTempR Then
                    dTempR = dR
                    nColor = eColor.eGreen
                End If
            Next

            'Blue
            For i As Integer = 0 To m_BlueColor_CIEx.Length - 1
                dR = Math.Sqrt((dCIEx - m_BlueColor_CIEx(i)) ^ 2 + (dCIEy - m_BlueColor_CIEy(i)) ^ 2)
                If dR < dTempR Then
                    dTempR = dR
                    nColor = eColor.eBlue
                End If
            Next

            'White
            For i As Integer = 0 To m_WhiteColor_CIEx.Length - 1
                dR = Math.Sqrt((dCIEx - m_WhiteColor_CIEx(i)) ^ 2 + (dCIEy - m_WhiteColor_CIEy(i)) ^ 2)
                If dR < dTempR Then
                    dTempR = dR
                    nColor = eColor.eWhite
                End If
            Next
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

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

End Class
