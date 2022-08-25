Public Class CDataQECal

#Region "Define"
    Public m_ColorName() As String = New String() {"Red", "Green", "Blue", "White"}

    Public Enum eNormalizeDataType
        ePercent
        eFactor
    End Enum

    Public Enum eColor
        eRed
        eGreen
        eBlue
        eWhite
    End Enum
#End Region




#Region "Structure"
    Public Structure sMaterial
        Dim sRed As sMeteralInfo
        Dim sGreen As sMeteralInfo
        Dim sBlue As sMeteralInfo
        Dim sWhite As sMeteralInfo
        Dim sColorName As String
        Dim dRealCurrent As Double
        Dim dCIE_x As Double
        Dim dCIE_y As Double
    End Structure

    Public Structure sMeteralInfo
        Dim dLuminanceRatio As Double           '휘도비
        Dim dBrightnessRequirements As Double       '요구휘도
        Dim dCIEx As Double
        Dim dCIEy As Double
        Dim dApertureRatio As Double            '개구율
        Dim dTransmittancePolarizers As Double  '편광판투과율
    End Structure
#End Region


#Region "Normalization"

    Public Function DataNormalization(ByVal inData() As Double, ByRef nELmax As Integer) As Double()

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim nIndexOfMaxVal As Integer
        Dim dDataBuf As Double
        Dim dNormalizedData() As Double

        nNumOfDataPoint = inData.Length
        ReDim dNormalizedData(nNumOfDataPoint - 1)

        '1. Max값 찾기
        dMaxValue = GetMaxValue(inData, nIndexOfMaxVal)

        '2. Max값을 기준으로 Normalization 시작
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            dDataBuf = inData(nCntDPoint) / dMaxValue

            dNormalizedData(nCntDPoint) = dDataBuf
        Next

        nELmax = nIndexOfMaxVal + 380
        Return dNormalizedData

    End Function

    Public Function GetMaxValue(ByVal inData() As Single, ByRef out_index As Integer) As Double

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim dIndexOfMaxVal As Integer

        nNumOfDataPoint = inData.Length
        '1. Max값 찾기
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            If dMaxValue < inData(nCntDPoint) Then
                dMaxValue = inData(nCntDPoint)
                dIndexOfMaxVal = nCntDPoint
            End If
        Next
        out_index = dIndexOfMaxVal
        Return dMaxValue
    End Function


#End Region

#Region "QE Calcuration Functions"

    Public Function QuantumEfficiency(ByVal In_CellArea As Double, ByVal In_Curr As Double, ByVal In_Intensity() As Single) As Double
        Dim pi As Double
        Dim dQE As Double
        Dim dCv As Double
        Dim cntData As Integer
        Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()
        Dim dCe As Double

        cntData = 100 'UBound(In_Lambda)

        '전하량
        Dim dElectronCharge As Double = 1.6 * 10 ^ -19   'Coulomb
        '플랭크 상수
        Dim dPlanckConst As Double = 6.623 * 10 ^ -34   '플랑크상수(Joul.sec)
        '빛의 속도
        Dim dLightSpeed As Double = 2.998 * 10 ^ 8         '빛의속도(m/sec2)
        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#

        '### Calculation "F" ###
        Dim dF As Double
        dF = (pi * (In_CellArea * 10 ^ -2) * dElectronCharge) / (dPlanckConst * dLightSpeed * 10 ^ -9)


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + 4 * (380 + (i0 * 4)) * In_Intensity(i0) * LoadPhotopicResponse(i0 * 4)
        Next i0

        '   dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe

        dQE = dF * (dCe / In_Curr) * 100

        Return dQE

    End Function

    Public Function QuantumEfficiencyWaveLen1nm(ByVal in_Lum As Single, ByVal In_J As Single, ByVal in_CellSize As Double, ByVal In_Intensity1() As Double, ByVal nWaveLenStep As Integer) As Double

        Dim pi As Double
        Dim dQE As Double
        Dim dCv As Double
        Dim cntData As Integer
        Dim i As Integer

        Dim dCe As Double
        Dim dCn As Double
        Dim dK As Double
        Dim CellArea As Double = in_CellSize

        Dim nNumOfData As Integer = In_Intensity1.Length - 1
        'Dim OpticalPower As Double

        'dim Con_pi = 3.1415926535
        'Private Const Con_e = 1.6 * 10 ^ (-19)   
        'Private Const Con_n = 1.8                '굴절률
        'Private Const Con_h = 6.623 * 10 ^ (-34) '플랑크상수(Joul.sec)
        'Private Const Con_c = 2.998 * 10 ^ 8     '빛의속도(m/sec2)
        Dim In_Intensity(nNumOfData) As Single

        Dim k As Integer
        For k = 0 To nNumOfData
            In_Intensity(k) = CType(In_Intensity1(k), Single)
        Next


        '전하량
        Dim dElectronCharge As Double
        dElectronCharge = 1.6 * 10 ^ (-19)   'Coulomb

        '플랭크 상수
        Dim dPlanckConst As Double
        dPlanckConst = 6.623 * 10 ^ (-34)    '플랑크상수(Joul.sec)

        '빛의 속도
        Dim dLightSpeed As Double
        dLightSpeed = 2.998 * 10 ^ 8         '빛의속도(m/sec2)

        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#
        'cntData = 0
        cntData = nNumOfData '100 'UBound(In_Lambda)



        '### 시감도 곡선 데이터 로드 *************************************************
        ' LoadPhotopicResponse()
        Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()

        '### 굴절률(n)을 사용한 Cn 계산 *************************************************************
        '변경시 UI(frmDisplSet)에서 txtConstK.Text 값만 변경시켜준다.
        'Cn = n^2 * |1-root(1-1/n^2)|
        dK = CDbl(1)
        dCn = CDbl(1) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        '### Cell의 면적 *************************************************************
        'If bOneSpectrum = False Then
        '    CellArea = CDbl(mdlTestCondi.c03sCellHeight) * CDbl(mdlTestCondi.c04sCellWidth)
        'Else
        '    CellArea = CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellFillFactor) / 100
        '    bOneSpectrum = False
        'End If

        '### Calculation "F" ###
        Dim dF As Double
        dF = pi * dCn * in_Lum * CellArea


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + (380 + (i0 * nWaveLenStep)) * In_Intensity(i0)
        Next i0

        dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        '### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        'LG 화학
        'For i = 0 To cntData - 1
        '    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        'Next i

        For i = 0 To cntData
            dCv = dCv + LoadPhotopicResponse(i * nWaveLenStep) * In_Intensity(i)
            ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        Next i

        dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값


        '### 6.Quantum Efficiency Calculation ******************************************
        If dCv > 0 Then
            dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        End If

        Return dQE

        'Dim pi As Double
        'Dim dCv As Double
        'Dim cntData As Integer
        'Dim i As Integer

        'Dim dCe As Double
        'Dim dCn As Double
        'Dim dK As Double
        'Dim CellArea As Double
        'Dim In_Intensity(400) As Single
        ''Dim OpticalPower As Double

        'Dim k As Integer
        'For k = 0 To 400
        '    In_Intensity(k) = CType(In_Intensity1(k), Single)
        'Next

        'Dim dQE As Double

        ''dim Con_pi = 3.1415926535
        ''Private Const Con_e = 1.6 * 10 ^ (-19)   'Coulomb
        ''Private Const Con_n = 1.8                '굴절률
        ''Private Const Con_h = 6.623 * 10 ^ (-34) '플랑크상수(Joul.sec)
        ''Private Const Con_c = 2.998 * 10 ^ 8     '빛의속도(m/sec2)

        ''전하량
        'Dim dElectronCharge As Double
        'dElectronCharge = 1.6 * 10 ^ (-19)

        ''플랭크 상수
        'Dim dPlanckConst As Double
        'dPlanckConst = 6.623 * 10 ^ (-34)

        ''빛의 속도
        'Dim dLightSpeed As Double
        'dLightSpeed = 2.998 * 10 ^ 8

        ''initial value
        'pi = 3.14159265358979
        'dQE = 0.0#
        'dCv = 0.0#
        '' cntData = 0
        'cntData = 400


        ''(((pi* CellArea)/(dPlanckConst * dLightSpeed /dElectronCharge)) * (dCe/i)) * 100
        ''### 시감도 곡선 데이터 로드 *************************************************
        'Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()


        ''### 굴절률(n)을 사용한 Cn 계산 *************************************************************
        ''변경시 UI(frmDisplSet)에서 txtConstK.Text 값만 변경시켜준다.
        ''Cn = n^2 * |1-root(1-1/n^2)|
        'dK = 1 'CDbl(frmDisplSet.txtConstK.Text)
        'dCn = 1 'CDbl(frmDisplSet.txtConstK.Text) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        ''### Cell의 면적 *************************************************************
        'If IVLMODE = "3" Or IVLMODE = "4" Then
        '    CellArea = (CellWidth2 * CellHeight2)
        'ElseIf IVLMODE = "1" Or IVLMODE = "2" Then
        '    CellArea = (CellWidth2 * CellHeight2 * CellFillFactor2) / 100
        '    ' bOneSpectrum = False
        'End If

        '' dQE = (((pi * CellArea) / (dPlanckConst * dLightSpeed / dElectronCharge)) * (dCe / i)) * 100

        ''Return dQE
        ''Exit Function
        ''### Calculation "F" ###
        'Dim dF As Double
        'dF = pi * dCn * in_Lum * CellArea


        ''### Calculation "Ce" ###
        'Dim i0 As Integer

        'For i0 = 0 To cntData  '적분값
        '    dCe = dCe + (380 + i0) * In_Intensity(i0)
        'Next i0

        'dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        ''### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        ''LG 화학
        ''For i = 0 To cntData - 1
        ''    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        ''Next i

        'For i = 0 To cntData
        '    dCv = dCv + LoadPhotopicResponse(i) * In_Intensity(i)
        '    ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        'Next i

        'dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값


        ''### 6.Quantum Efficiency Calculation ******************************************
        'If dCv > 0 Then
        '    dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        'End If
        ''dQE = dCv

        'Return dQE
    End Function




    Public Function CalculateTotalFlux(ByVal In_Intensity1() As Double, ByVal nWaveLenStep As Integer) As Double

        Dim pi As Double
        Dim dQE As Double = 0
        Dim dCv As Double
        Dim cntData As Integer
        '
        Dim dCe As Double = 0
        '
        '  Dim CellArea As Double = in_CellSize
        'Dim OpticalPower As Double

        Dim In_Intensity() As Double

        In_Intensity = In_Intensity1

        '전하량
        Dim dElectronCharge As Double
        dElectronCharge = 1.6 * 10 ^ (-19)

        '플랭크 상수
        Dim dPlanckConst As Double
        dPlanckConst = 6.623 * 10 ^ (-34)

        '빛의 속도
        Dim dLightSpeed As Double
        dLightSpeed = 2.998 * 10 ^ 8

        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#
        'cntData = 0
        cntData = In_Intensity1.Length - 1 '/ nWaveLenStep 'UBound(In_Lambda)

        '### 시감도 곡선 데이터 로드 *************************************************


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + (380 + (i0 * nWaveLenStep)) * In_Intensity(i0)
        Next i0
        dCe = dCe * nWaveLenStep
        dCe = (dCe / (dPlanckConst * dLightSpeed))

        Return dCe
    End Function

    Public Function QuantumEfficiency(ByVal in_Lum As Single, ByVal In_J As Double, ByVal In_CellArea As Double, ByVal In_Intensity4() As Double) As Double

        Dim pi As Double
        Dim dQE As Double
        Dim dCv As Double
        Dim cntData As Integer
        Dim i As Integer

        Dim dCe As Double
        Dim dCn As Double
        Dim dK As Double
        Dim CellArea As Double = In_CellArea
        'Dim OpticalPower As Double

        'dim Con_pi = 3.1415926535
        'Private Const Con_e = 1.6 * 10 ^ (-19)   'Coulomb
        'Private Const Con_n = 1.8                '굴절률
        'Private Const Con_h = 6.623 * 10 ^ (-34) '플랑크상수(Joul.sec)
        'Private Const Con_c = 2.998 * 10 ^ 8     '빛의속도(m/sec2)
        Dim In_Intensity() As Double

        In_Intensity = In_Intensity4

        '전하량
        Dim dElectronCharge As Double
        dElectronCharge = 1.6 * 10 ^ (-19)

        '플랭크 상수
        Dim dPlanckConst As Double
        dPlanckConst = 6.623 * 10 ^ (-34)

        '빛의 속도
        Dim dLightSpeed As Double
        dLightSpeed = 2.998 * 10 ^ 8

        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#
        'cntData = 0
        cntData = 100 'UBound(In_Lambda)



        '### 시감도 곡선 데이터 로드 *************************************************
        ' LoadPhotopicResponse()
        Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()

        '### 굴절률(n)을 사용한 Cn 계산 *************************************************************
        '변경시 UI(frmDisplSet)에서 txtConstK.Text 값만 변경시켜준다.
        'Cn = n^2 * |1-root(1-1/n^2)|
        dK = CDbl(1)
        dCn = CDbl(1) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        '### Cell의 면적 *************************************************************
        'If bOneSpectrum = False Then
        '    CellArea = CDbl(mdlTestCondi.c03sCellHeight) * CDbl(mdlTestCondi.c04sCellWidth)
        'Else
        '    CellArea = CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellHeight) * CSng(frmInputSize.txtCellFillFactor) / 100
        '    bOneSpectrum = False
        'End If

        'If IVLMODE = "3" Or IVLMODE = "4" Then
        '    CellArea = (CellWidth2 * CellHeight2)
        'ElseIf IVLMODE = "1" Or IVLMODE = "2" Then
        '    CellArea = (CellWidth2 * CellHeight2) '* CellFillFactor2) / 100
        '    ' bOneSpectrum = False
        'End If


        '### Calculation "F" ###
        Dim dF As Double
        dF = pi * dCn * in_Lum * CellArea


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + 4 * (380 + (i0 * 4)) * In_Intensity(i0)
        Next i0

        dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        '### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        'LG 화학
        'For i = 0 To cntData - 1
        '    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        'Next i

        For i = 0 To cntData
            dCv = dCv + 4 * LoadPhotopicResponse(i * 4) * In_Intensity(i)
            ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        Next i

        dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값


        '### 6.Quantum Efficiency Calculation ******************************************
        If dCv > 0 Then
            dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        End If

        Return dQE

        'Dim pi As Double
        'Dim dCv As Double
        'Dim cntData As Integer
        'Dim i As Integer

        'Dim dCe As Double
        'Dim dCn As Double
        'Dim dK As Double
        'Dim CellArea As Double
        'Dim In_Intensity(400) As Single
        ''Dim OpticalPower As Double

        'Dim k As Integer
        'For k = 0 To 400
        '    In_Intensity(k) = CType(In_Intensity1(k), Single)
        'Next

        'Dim dQE As Double

        ''dim Con_pi = 3.1415926535
        ''Private Const Con_e = 1.6 * 10 ^ (-19)   'Coulomb
        ''Private Const Con_n = 1.8                '굴절률
        ''Private Const Con_h = 6.623 * 10 ^ (-34) '플랑크상수(Joul.sec)
        ''Private Const Con_c = 2.998 * 10 ^ 8     '빛의속도(m/sec2)

        ''전하량
        'Dim dElectronCharge As Double
        'dElectronCharge = 1.6 * 10 ^ (-19)

        ''플랭크 상수
        'Dim dPlanckConst As Double
        'dPlanckConst = 6.623 * 10 ^ (-34)

        ''빛의 속도
        'Dim dLightSpeed As Double
        'dLightSpeed = 2.998 * 10 ^ 8

        ''initial value
        'pi = 3.14159265358979
        'dQE = 0.0#
        'dCv = 0.0#
        '' cntData = 0
        'cntData = 400


        ''(((pi* CellArea)/(dPlanckConst * dLightSpeed /dElectronCharge)) * (dCe/i)) * 100
        ''### 시감도 곡선 데이터 로드 *************************************************
        'Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()


        ''### 굴절률(n)을 사용한 Cn 계산 *************************************************************
        ''변경시 UI(frmDisplSet)에서 txtConstK.Text 값만 변경시켜준다.
        ''Cn = n^2 * |1-root(1-1/n^2)|
        'dK = 1 'CDbl(frmDisplSet.txtConstK.Text)
        'dCn = 1 'CDbl(frmDisplSet.txtConstK.Text) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        ''### Cell의 면적 *************************************************************
        'If IVLMODE = "3" Or IVLMODE = "4" Then
        '    CellArea = (CellWidth2 * CellHeight2)
        'ElseIf IVLMODE = "1" Or IVLMODE = "2" Then
        '    CellArea = (CellWidth2 * CellHeight2 * CellFillFactor2) / 100
        '    ' bOneSpectrum = False
        'End If

        '' dQE = (((pi * CellArea) / (dPlanckConst * dLightSpeed / dElectronCharge)) * (dCe / i)) * 100

        ''Return dQE
        ''Exit Function
        ''### Calculation "F" ###
        'Dim dF As Double
        'dF = pi * dCn * in_Lum * CellArea


        ''### Calculation "Ce" ###
        'Dim i0 As Integer

        'For i0 = 0 To cntData  '적분값
        '    dCe = dCe + (380 + i0) * In_Intensity(i0)
        'Next i0

        'dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        ''### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        ''LG 화학
        ''For i = 0 To cntData - 1
        ''    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        ''Next i

        'For i = 0 To cntData
        '    dCv = dCv + LoadPhotopicResponse(i) * In_Intensity(i)
        '    ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        'Next i

        'dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값


        ''### 6.Quantum Efficiency Calculation ******************************************
        'If dCv > 0 Then
        '    dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        'End If
        ''dQE = dCv

        'Return dQE
    End Function

    Public Function QuantumEfficiency(ByVal in_Lum As Single, ByVal In_J As Double, ByVal In_CellArea As Double, ByVal In_Intensity1() As Double, ByVal nWaveLenStep As Integer) As Double


        Dim pi As Double
        Dim dQE As Double
        Dim dCv As Double
        Dim cntData As Integer
        Dim i As Integer

        Dim dCe As Double
        Dim dCn As Double
        Dim dK As Double
        Dim CellArea As Double = In_CellArea
        'Dim OpticalPower As Double

        Dim In_Intensity() As Double

        In_Intensity = In_Intensity1

        '전하량
        Dim dElectronCharge As Double
        dElectronCharge = 1.6 * 10 ^ (-19)

        '플랭크 상수
        Dim dPlanckConst As Double
        dPlanckConst = 6.623 * 10 ^ (-34)

        '빛의 속도
        Dim dLightSpeed As Double
        dLightSpeed = 2.998 * 10 ^ 8

        'initial value
        pi = 3.14159265358979
        dQE = 0.0#
        dCv = 0.0#
        'cntData = 0
        cntData = In_Intensity1.Length - 1 '/ nWaveLenStep 'UBound(In_Lambda)

        '### 시감도 곡선 데이터 로드 *************************************************
        Dim LoadPhotopicResponse() As Double = LoadPhotopicResponseData()

        dK = CDbl(1)
        dCn = CDbl(1) 'dK ^ 2 * (Abs(1 - Sqr(1 - (1 / dK ^ 2))))


        '### Calculation "F" ###
        Dim dF As Double
        dF = pi * dCn * in_Lum * CellArea


        '### Calculation "Ce" ###
        Dim i0 As Integer

        For i0 = 0 To cntData
            dCe = dCe + nWaveLenStep * (380 + (i0 * nWaveLenStep)) * In_Intensity(i0)
        Next i0

        dCe = (dElectronCharge / (dPlanckConst * dLightSpeed)) * dCe


        '### 시감도 곡선과 스펙트럼에 대한 적분값 계산 *******************************

        'LG 화학
        'For i = 0 To cntData - 1
        '    dCv = dCv + 4 * In_Intensity(i) * In_Lambda(i)
        'Next i

        For i = 0 To cntData
            dCv = dCv + nWaveLenStep * LoadPhotopicResponse(i * nWaveLenStep) * In_Intensity(i)
            ' dCv = dCv + m_TmpData.PhotopicCurve(i * 4) * In_Intensity(i)
        Next i

        dCv = 683 * dCv   '시감도 곡선과 스펙트럼에 대한 적분값

        '### 6.Quantum Efficiency Calculation ******************************************
        If dCv > 0 Then
            dQE = (dF * dCe) / (In_J * CellArea * dCv) * 10 ^ (-8)
        End If

        Return dQE
    End Function

    Public Function LoadPhotopicResponseData() As Double()
        Dim PhotopicCurve(400) As Double
        PhotopicCurve(0) = 0.000039
        PhotopicCurve(1) = 0.0000428
        PhotopicCurve(2) = 0.0000469
        PhotopicCurve(3) = 0.0000516
        PhotopicCurve(4) = 0.0000572
        PhotopicCurve(5) = 0.000064
        PhotopicCurve(6) = 0.0000723
        PhotopicCurve(7) = 0.0000822
        PhotopicCurve(8) = 0.0000935
        PhotopicCurve(9) = 0.000106
        PhotopicCurve(10) = 0.00012
        PhotopicCurve(11) = 0.000135
        PhotopicCurve(12) = 0.000151
        PhotopicCurve(13) = 0.00017
        PhotopicCurve(14) = 0.000192
        PhotopicCurve(15) = 0.000217
        PhotopicCurve(16) = 0.000247
        PhotopicCurve(17) = 0.000281
        PhotopicCurve(18) = 0.000319
        PhotopicCurve(19) = 0.000357
        PhotopicCurve(20) = 0.000396
        PhotopicCurve(21) = 0.000434
        PhotopicCurve(22) = 0.000473
        PhotopicCurve(23) = 0.000518
        PhotopicCurve(24) = 0.000572
        PhotopicCurve(25) = 0.00064
        PhotopicCurve(26) = 0.000725
        PhotopicCurve(27) = 0.000826
        PhotopicCurve(28) = 0.000941
        PhotopicCurve(29) = 0.00107
        PhotopicCurve(30) = 0.00121
        PhotopicCurve(31) = 0.00136
        PhotopicCurve(32) = 0.00153
        PhotopicCurve(33) = 0.00172
        PhotopicCurve(34) = 0.00194
        PhotopicCurve(35) = 0.00218
        PhotopicCurve(36) = 0.00245
        PhotopicCurve(37) = 0.00276
        PhotopicCurve(38) = 0.00312
        PhotopicCurve(39) = 0.00353
        PhotopicCurve(40) = 0.004
        PhotopicCurve(41) = 0.00455
        PhotopicCurve(42) = 0.00516
        PhotopicCurve(43) = 0.00583
        PhotopicCurve(44) = 0.00655
        PhotopicCurve(45) = 0.0073
        PhotopicCurve(46) = 0.00809
        PhotopicCurve(47) = 0.00891
        PhotopicCurve(48) = 0.00977
        PhotopicCurve(49) = 0.01066
        PhotopicCurve(50) = 0.0116
        PhotopicCurve(51) = 0.01257
        PhotopicCurve(52) = 0.01358
        PhotopicCurve(53) = 0.01463
        PhotopicCurve(54) = 0.01572
        PhotopicCurve(55) = 0.01684
        PhotopicCurve(56) = 0.01801
        PhotopicCurve(57) = 0.01921
        PhotopicCurve(58) = 0.02045
        PhotopicCurve(59) = 0.02172
        PhotopicCurve(60) = 0.023
        PhotopicCurve(61) = 0.02429
        PhotopicCurve(62) = 0.02561
        PhotopicCurve(63) = 0.02696
        PhotopicCurve(64) = 0.02835
        PhotopicCurve(65) = 0.0298
        PhotopicCurve(66) = 0.03131
        PhotopicCurve(67) = 0.03288
        PhotopicCurve(68) = 0.03452
        PhotopicCurve(69) = 0.03623
        PhotopicCurve(70) = 0.038
        PhotopicCurve(71) = 0.03985
        PhotopicCurve(72) = 0.04177
        PhotopicCurve(73) = 0.04377
        PhotopicCurve(74) = 0.04584
        PhotopicCurve(75) = 0.048
        PhotopicCurve(76) = 0.05024
        PhotopicCurve(77) = 0.05257
        PhotopicCurve(78) = 0.05498
        PhotopicCurve(79) = 0.05746
        PhotopicCurve(80) = 0.06
        PhotopicCurve(81) = 0.0626
        PhotopicCurve(82) = 0.06528
        PhotopicCurve(83) = 0.06804
        PhotopicCurve(84) = 0.07091
        PhotopicCurve(85) = 0.0739
        PhotopicCurve(86) = 0.07702
        PhotopicCurve(87) = 0.08027
        PhotopicCurve(88) = 0.08367
        PhotopicCurve(89) = 0.08723
        PhotopicCurve(90) = 0.09098
        PhotopicCurve(91) = 0.09492
        PhotopicCurve(92) = 0.09905
        PhotopicCurve(93) = 0.10337
        PhotopicCurve(94) = 0.10788
        PhotopicCurve(95) = 0.1126
        PhotopicCurve(96) = 0.11753
        PhotopicCurve(97) = 0.12267
        PhotopicCurve(98) = 0.12799
        PhotopicCurve(99) = 0.13345
        PhotopicCurve(100) = 0.13902
        PhotopicCurve(101) = 0.14468
        PhotopicCurve(102) = 0.15047
        PhotopicCurve(103) = 0.15646
        PhotopicCurve(104) = 0.16272
        PhotopicCurve(105) = 0.1693
        PhotopicCurve(106) = 0.17624
        PhotopicCurve(107) = 0.18356
        PhotopicCurve(108) = 0.19127
        PhotopicCurve(109) = 0.19942
        PhotopicCurve(110) = 0.20802
        PhotopicCurve(111) = 0.21712
        PhotopicCurve(112) = 0.22673
        PhotopicCurve(113) = 0.23686
        PhotopicCurve(114) = 0.24748
        PhotopicCurve(115) = 0.2586
        PhotopicCurve(116) = 0.27018
        PhotopicCurve(117) = 0.28229
        PhotopicCurve(118) = 0.29505
        PhotopicCurve(119) = 0.30858
        PhotopicCurve(120) = 0.323
        PhotopicCurve(121) = 0.3384
        PhotopicCurve(122) = 0.35469
        PhotopicCurve(123) = 0.3717
        PhotopicCurve(124) = 0.38929
        PhotopicCurve(125) = 0.4073
        PhotopicCurve(126) = 0.42563
        PhotopicCurve(127) = 0.44431
        PhotopicCurve(128) = 0.46339
        PhotopicCurve(129) = 0.48294
        PhotopicCurve(130) = 0.503
        PhotopicCurve(131) = 0.52357
        PhotopicCurve(132) = 0.54451
        PhotopicCurve(133) = 0.56569
        PhotopicCurve(134) = 0.58697
        PhotopicCurve(135) = 0.6082
        PhotopicCurve(136) = 0.62935
        PhotopicCurve(137) = 0.65031
        PhotopicCurve(138) = 0.67088
        PhotopicCurve(139) = 0.69084
        PhotopicCurve(140) = 0.71
        PhotopicCurve(141) = 0.72819
        PhotopicCurve(142) = 0.74546
        PhotopicCurve(143) = 0.76197
        PhotopicCurve(144) = 0.77784
        PhotopicCurve(145) = 0.7932
        PhotopicCurve(146) = 0.80811
        PhotopicCurve(147) = 0.8225
        PhotopicCurve(148) = 0.83631
        PhotopicCurve(149) = 0.84949
        PhotopicCurve(150) = 0.862
        PhotopicCurve(151) = 0.87381
        PhotopicCurve(152) = 0.88496
        PhotopicCurve(153) = 0.89549
        PhotopicCurve(154) = 0.90544
        PhotopicCurve(155) = 0.91485
        PhotopicCurve(156) = 0.92373
        PhotopicCurve(157) = 0.93209
        PhotopicCurve(158) = 0.93992
        PhotopicCurve(159) = 0.94723
        PhotopicCurve(160) = 0.954
        PhotopicCurve(161) = 0.96026
        PhotopicCurve(162) = 0.96601
        PhotopicCurve(163) = 0.97126
        PhotopicCurve(164) = 0.97602
        PhotopicCurve(165) = 0.9803
        PhotopicCurve(166) = 0.98409
        PhotopicCurve(167) = 0.98748
        PhotopicCurve(168) = 0.99031
        PhotopicCurve(169) = 0.99281
        PhotopicCurve(170) = 0.99495
        PhotopicCurve(171) = 0.99671
        PhotopicCurve(172) = 0.9981
        PhotopicCurve(173) = 0.99911
        PhotopicCurve(174) = 0.99975
        PhotopicCurve(175) = 1
        PhotopicCurve(176) = 0.99986
        PhotopicCurve(177) = 0.9993
        PhotopicCurve(178) = 0.99833
        PhotopicCurve(179) = 0.9969
        PhotopicCurve(180) = 0.995
        PhotopicCurve(181) = 0.9926
        PhotopicCurve(182) = 0.98974
        PhotopicCurve(183) = 0.98644
        PhotopicCurve(184) = 0.98272
        PhotopicCurve(185) = 0.9786
        PhotopicCurve(186) = 0.97408
        PhotopicCurve(187) = 0.96917
        PhotopicCurve(188) = 0.96386
        PhotopicCurve(189) = 0.95813
        PhotopicCurve(190) = 0.952
        PhotopicCurve(191) = 0.94545
        PhotopicCurve(192) = 0.9385
        PhotopicCurve(193) = 0.93116
        PhotopicCurve(194) = 0.92346
        PhotopicCurve(195) = 0.9154
        PhotopicCurve(196) = 0.90701
        PhotopicCurve(197) = 0.89828
        PhotopicCurve(198) = 0.8892
        PhotopicCurve(199) = 0.87978
        PhotopicCurve(200) = 0.87
        PhotopicCurve(201) = 0.85986
        PhotopicCurve(202) = 0.84939
        PhotopicCurve(203) = 0.83862
        PhotopicCurve(204) = 0.82758
        PhotopicCurve(205) = 0.8163
        PhotopicCurve(206) = 0.80479
        PhotopicCurve(207) = 0.79308
        PhotopicCurve(208) = 0.78119
        PhotopicCurve(209) = 0.76915
        PhotopicCurve(210) = 0.757
        PhotopicCurve(211) = 0.74475
        PhotopicCurve(212) = 0.73242
        PhotopicCurve(213) = 0.72
        PhotopicCurve(214) = 0.7075
        PhotopicCurve(215) = 0.6949
        PhotopicCurve(216) = 0.68222
        PhotopicCurve(217) = 0.66947
        PhotopicCurve(218) = 0.65667
        PhotopicCurve(219) = 0.64384
        PhotopicCurve(220) = 0.631
        PhotopicCurve(221) = 0.61816
        PhotopicCurve(222) = 0.60531
        PhotopicCurve(223) = 0.59248
        PhotopicCurve(224) = 0.57964
        PhotopicCurve(225) = 0.5668
        PhotopicCurve(226) = 0.55396
        PhotopicCurve(227) = 0.54114
        PhotopicCurve(228) = 0.52835
        PhotopicCurve(229) = 0.51563
        PhotopicCurve(230) = 0.503
        PhotopicCurve(231) = 0.49047
        PhotopicCurve(232) = 0.47803
        PhotopicCurve(233) = 0.46568
        PhotopicCurve(234) = 0.4534
        PhotopicCurve(235) = 0.4412
        PhotopicCurve(236) = 0.42908
        PhotopicCurve(237) = 0.41704
        PhotopicCurve(238) = 0.40503
        PhotopicCurve(239) = 0.39303
        PhotopicCurve(240) = 0.381
        PhotopicCurve(241) = 0.36892
        PhotopicCurve(242) = 0.35683
        PhotopicCurve(243) = 0.34478
        PhotopicCurve(244) = 0.33282
        PhotopicCurve(245) = 0.321
        PhotopicCurve(246) = 0.30934
        PhotopicCurve(247) = 0.29785
        PhotopicCurve(248) = 0.28659
        PhotopicCurve(249) = 0.27562
        PhotopicCurve(250) = 0.265
        PhotopicCurve(251) = 0.25476
        PhotopicCurve(252) = 0.24489
        PhotopicCurve(253) = 0.23533
        PhotopicCurve(254) = 0.22605
        PhotopicCurve(255) = 0.217
        PhotopicCurve(256) = 0.20816
        PhotopicCurve(257) = 0.19955
        PhotopicCurve(258) = 0.19116
        PhotopicCurve(259) = 0.18297
        PhotopicCurve(260) = 0.175
        PhotopicCurve(261) = 0.16722
        PhotopicCurve(262) = 0.15965
        PhotopicCurve(263) = 0.15228
        PhotopicCurve(264) = 0.14513
        PhotopicCurve(265) = 0.1382
        PhotopicCurve(266) = 0.1315
        PhotopicCurve(267) = 0.12502
        PhotopicCurve(268) = 0.11878
        PhotopicCurve(269) = 0.11277
        PhotopicCurve(270) = 0.107
        PhotopicCurve(271) = 0.10148
        PhotopicCurve(272) = 0.09619
        PhotopicCurve(273) = 0.09112
        PhotopicCurve(274) = 0.08626
        PhotopicCurve(275) = 0.0816
        PhotopicCurve(276) = 0.07712
        PhotopicCurve(277) = 0.07283
        PhotopicCurve(278) = 0.06871
        PhotopicCurve(279) = 0.06477
        PhotopicCurve(280) = 0.061
        PhotopicCurve(281) = 0.0574
        PhotopicCurve(282) = 0.05396
        PhotopicCurve(283) = 0.05067
        PhotopicCurve(284) = 0.04755
        PhotopicCurve(285) = 0.04458
        PhotopicCurve(286) = 0.04176
        PhotopicCurve(287) = 0.03908
        PhotopicCurve(288) = 0.03656
        PhotopicCurve(289) = 0.0342
        PhotopicCurve(290) = 0.032
        PhotopicCurve(291) = 0.02996
        PhotopicCurve(292) = 0.02808
        PhotopicCurve(293) = 0.02633
        PhotopicCurve(294) = 0.02471
        PhotopicCurve(295) = 0.0232
        PhotopicCurve(296) = 0.0218
        PhotopicCurve(297) = 0.0205
        PhotopicCurve(298) = 0.01928
        PhotopicCurve(299) = 0.01812
        PhotopicCurve(300) = 0.017
        PhotopicCurve(301) = 0.0159
        PhotopicCurve(302) = 0.01484
        PhotopicCurve(303) = 0.01381
        PhotopicCurve(304) = 0.01283
        PhotopicCurve(305) = 0.01192
        PhotopicCurve(306) = 0.01107
        PhotopicCurve(307) = 0.01027
        PhotopicCurve(308) = 0.00953
        PhotopicCurve(309) = 0.00885
        PhotopicCurve(310) = 0.00821
        PhotopicCurve(311) = 0.00762
        PhotopicCurve(312) = 0.00709
        PhotopicCurve(313) = 0.00659
        PhotopicCurve(314) = 0.00614
        PhotopicCurve(315) = 0.00572
        PhotopicCurve(316) = 0.00534
        PhotopicCurve(317) = 0.005
        PhotopicCurve(318) = 0.00468
        PhotopicCurve(319) = 0.00438
        PhotopicCurve(320) = 0.0041
        PhotopicCurve(321) = 0.00384
        PhotopicCurve(322) = 0.00359
        PhotopicCurve(323) = 0.00335
        PhotopicCurve(324) = 0.00313
        PhotopicCurve(325) = 0.00293
        PhotopicCurve(326) = 0.00274
        PhotopicCurve(327) = 0.00256
        PhotopicCurve(328) = 0.00239
        PhotopicCurve(329) = 0.00224
        PhotopicCurve(330) = 0.00209
        PhotopicCurve(331) = 0.00195
        PhotopicCurve(332) = 0.00182
        PhotopicCurve(333) = 0.0017
        PhotopicCurve(334) = 0.00159
        PhotopicCurve(335) = 0.00148
        PhotopicCurve(336) = 0.00138
        PhotopicCurve(337) = 0.00129
        PhotopicCurve(338) = 0.0012
        PhotopicCurve(339) = 0.00112
        PhotopicCurve(340) = 0.00105
        PhotopicCurve(341) = 0.000977
        PhotopicCurve(342) = 0.000911
        PhotopicCurve(343) = 0.00085
        PhotopicCurve(344) = 0.000793
        PhotopicCurve(345) = 0.00074
        PhotopicCurve(346) = 0.00069
        PhotopicCurve(347) = 0.000643
        PhotopicCurve(348) = 0.000599
        PhotopicCurve(349) = 0.000558
        PhotopicCurve(350) = 0.00052
        PhotopicCurve(351) = 0.000484
        PhotopicCurve(352) = 0.00045
        PhotopicCurve(353) = 0.000418
        PhotopicCurve(354) = 0.000389
        PhotopicCurve(355) = 0.000361
        PhotopicCurve(356) = 0.000335
        PhotopicCurve(357) = 0.000311
        PhotopicCurve(358) = 0.000289
        PhotopicCurve(359) = 0.000268
        PhotopicCurve(360) = 0.000249
        PhotopicCurve(361) = 0.000231
        PhotopicCurve(362) = 0.000215
        PhotopicCurve(363) = 0.000199
        PhotopicCurve(364) = 0.000185
        PhotopicCurve(365) = 0.000172
        PhotopicCurve(366) = 0.00016
        PhotopicCurve(367) = 0.000149
        PhotopicCurve(368) = 0.000138
        PhotopicCurve(369) = 0.000129
        PhotopicCurve(370) = 0.00012
        PhotopicCurve(371) = 0.000112
        PhotopicCurve(372) = 0.000104
        PhotopicCurve(373) = 0.0000973
        PhotopicCurve(374) = 0.0000908
        PhotopicCurve(375) = 0.0000848
        PhotopicCurve(376) = 0.0000791
        PhotopicCurve(377) = 0.0000739
        PhotopicCurve(378) = 0.0000689
        PhotopicCurve(379) = 0.0000643
        PhotopicCurve(380) = 0.00006
        PhotopicCurve(381) = 0.000056
        PhotopicCurve(382) = 0.0000522
        PhotopicCurve(383) = 0.0000487
        PhotopicCurve(384) = 0.0000454
        PhotopicCurve(385) = 0.0000424
        PhotopicCurve(386) = 0.0000396
        PhotopicCurve(387) = 0.0000369
        PhotopicCurve(388) = 0.0000344
        PhotopicCurve(389) = 0.0000321
        PhotopicCurve(390) = 0.00003
        PhotopicCurve(391) = 0.000028
        PhotopicCurve(392) = 0.0000261
        PhotopicCurve(393) = 0.0000244
        PhotopicCurve(394) = 0.0000227
        PhotopicCurve(395) = 0.0000212
        PhotopicCurve(396) = 0.0000198
        PhotopicCurve(397) = 0.0000185
        PhotopicCurve(398) = 0.0000172
        PhotopicCurve(399) = 0.0000161
        PhotopicCurve(400) = 0.000015
        Return PhotopicCurve
    End Function

#End Region


#Region "Brightness Requirements Calculation Functions"

    Public Function BrightnessRequirementsCalculationToRealCurrent(ByVal sOptionMeteralValue As sMaterial, ByRef sMeteralValue As sMaterial, ByVal sIVLData()() As frmMain.sCellIVLMeasure, ByVal dCIE_x As Double, ByVal dCIE_y As Double, ByVal nColor As eColor) As Boolean

        sMeteralValue = sOptionMeteralValue

        If nColor = eColor.eRed Then
            'option 값 사용
        ElseIf nColor = eColor.eGreen Then
            'option 값 사용
        ElseIf nColor = eColor.eBlue Then
            sMeteralValue.sBlue.dCIEx = dCIE_x
            sMeteralValue.sBlue.dCIEy = dCIE_y
        ElseIf nColor = eColor.eWhite Then
            sMeteralValue.sWhite.dCIEx = dCIE_x
            sMeteralValue.sWhite.dCIEy = dCIE_y
        End If
        ''색상 판단
        'If dX > dY And dX > dZ Then
        '    nColor = eColor.eRed
        '    sMeteralValue.sRed.dCIEx = dCIE_x
        '    sMeteralValue.sRed.dCIEy = dCIE_y
        'ElseIf dY > dX And dY > dZ Then
        '    nColor = eColor.eGreen
        '    sMeteralValue.sGreen.dCIEx = dCIE_x
        '    sMeteralValue.sGreen.dCIEy = dCIE_y
        'ElseIf dZ > dX And dZ > dY Then
        '    nColor = eColor.eBlue

        'End If

        sMeteralValue.sColorName = m_ColorName(nColor)

        Try
            'Cal LuminanceRatio
            Dim dGreenWhiteCIEyCal As Double     'Green.CIEy / White.CIEy
            Dim dRedWhiteCIEyCal As Double       'Red.CIEy - White.CIEy
            Dim dBlueRedCIExyCal As Double       'Blue.CIEx * Red.CIEy - Red.CIEx * Blue.CIEy
            Dim dWhiteRedCIExyCal As Double      'White.CIEx * Red.CIEy - Red.CIEx * White.CIEy
            Dim dRedBlueCIEyCal As Double        'Red.CIEy - Blue.CIEy
            Dim dRedGreenCIEyCal As Double       'Red.CIEy - Green.CIEy
            Dim dGreenRedCIExyCal As Double      'Green.CIEx * Red.CIEy - Red.CIEx * Green.CIEy

            Dim dWhiteCIEyCal As Double = 1 / sMeteralValue.sWhite.dCIEy
            Dim dRedCIEyCal As Double = 1 / sMeteralValue.sRed.dCIEy
            Dim dGreenCIEyCal As Double = 1 / sMeteralValue.sGreen.dCIEy
            Dim dBlueCIEyCal As Double = 1 / sMeteralValue.sBlue.dCIEy
            Dim dWhite_Red As Double             'WhiteCIEyCal - RedCIEyCal
            Dim dGreen_Red As Double             'GreenCIEyCal - RedCIEyCal
            Dim dBlue_Red As Double              'BlueCIEyCal - RedCIEyCal

            Dim dGreenRatioCalNumerator As Double
            Dim dGreenRatioCallDenominator As Double

            dGreenWhiteCIEyCal = sMeteralValue.sGreen.dCIEy / sMeteralValue.sWhite.dCIEy
            dRedWhiteCIEyCal = sMeteralValue.sRed.dCIEy - sMeteralValue.sWhite.dCIEy
            dBlueRedCIExyCal = sMeteralValue.sBlue.dCIEx * sMeteralValue.sRed.dCIEy - sMeteralValue.sRed.dCIEx * sMeteralValue.sBlue.dCIEy
            dWhiteRedCIExyCal = sMeteralValue.sWhite.dCIEx * sMeteralValue.sRed.dCIEy - sMeteralValue.sRed.dCIEx * sMeteralValue.sWhite.dCIEy
            dRedBlueCIEyCal = sMeteralValue.sRed.dCIEy - sMeteralValue.sBlue.dCIEy
            dRedGreenCIEyCal = sMeteralValue.sRed.dCIEy - sMeteralValue.sGreen.dCIEy
            dGreenRedCIExyCal = sMeteralValue.sGreen.dCIEx * sMeteralValue.sRed.dCIEy - sMeteralValue.sRed.dCIEx * sMeteralValue.sGreen.dCIEy

            dGreenRatioCalNumerator = dGreenWhiteCIEyCal * (dRedWhiteCIEyCal * dBlueRedCIExyCal - dWhiteRedCIExyCal * dRedBlueCIEyCal)
            dGreenRatioCallDenominator = dRedGreenCIEyCal * dBlueRedCIExyCal - dGreenRedCIExyCal * dRedBlueCIEyCal

            sMeteralValue.sGreen.dLuminanceRatio = dGreenRatioCalNumerator / dGreenRatioCallDenominator

            dWhite_Red = dWhiteCIEyCal - dRedCIEyCal
            dGreen_Red = dGreenCIEyCal - dRedCIEyCal
            dBlue_Red = dBlueCIEyCal - dRedCIEyCal

            sMeteralValue.sBlue.dLuminanceRatio = (dWhite_Red - sMeteralValue.sGreen.dLuminanceRatio * dGreen_Red) / dBlue_Red

            sMeteralValue.sRed.dLuminanceRatio = 1 - sMeteralValue.sGreen.dLuminanceRatio - sMeteralValue.sBlue.dLuminanceRatio

            sMeteralValue.sWhite.dLuminanceRatio = sMeteralValue.sRed.dLuminanceRatio + sMeteralValue.sGreen.dLuminanceRatio + sMeteralValue.sBlue.dLuminanceRatio

            'CalBrightnessRequirements
            sMeteralValue.sRed.dBrightnessRequirements = sMeteralValue.sRed.dLuminanceRatio * sMeteralValue.sWhite.dBrightnessRequirements / (sMeteralValue.sRed.dApertureRatio / 100) / (sMeteralValue.sRed.dTransmittancePolarizers / 100) * 3.0
            sMeteralValue.sGreen.dBrightnessRequirements = sMeteralValue.sGreen.dLuminanceRatio * sMeteralValue.sWhite.dBrightnessRequirements / (sMeteralValue.sRed.dApertureRatio / 100) / (sMeteralValue.sRed.dTransmittancePolarizers / 100) * 3.0
            sMeteralValue.sBlue.dBrightnessRequirements = sMeteralValue.sBlue.dLuminanceRatio * sMeteralValue.sWhite.dBrightnessRequirements / (sMeteralValue.sBlue.dApertureRatio / 100) / (sMeteralValue.sBlue.dTransmittancePolarizers / 100) * 3.0

        Catch ex As Exception
            sMeteralValue.sRed.dBrightnessRequirements = 0
            sMeteralValue.sGreen.dBrightnessRequirements = 0
            sMeteralValue.sBlue.dBrightnessRequirements = 0
            sMeteralValue.sWhite.dBrightnessRequirements = 0
            sMeteralValue.sRed.dLuminanceRatio = 0
            sMeteralValue.sGreen.dLuminanceRatio = 0
            sMeteralValue.sBlue.dLuminanceRatio = 0
            sMeteralValue.sWhite.dLuminanceRatio = 0
            Return False
        End Try


        '요구휘도를 가지고 Real Current계산을 한다...
        Dim dStandardLuminanceValue As Double
        Dim dRealCurrent As Double
        Dim dCurrent() As Double
        Dim dLuminace() As Double

        Dim nRowTop As Integer
        Dim nRowBotton As Integer
        Dim bRowTop As Boolean = False
        Dim bRowBotton As Boolean = False

        Select Case nColor
            Case eColor.eRed
                dStandardLuminanceValue = sMeteralValue.sRed.dBrightnessRequirements
            Case eColor.eGreen
                dStandardLuminanceValue = sMeteralValue.sGreen.dBrightnessRequirements
            Case eColor.eBlue
                dStandardLuminanceValue = sMeteralValue.sBlue.dBrightnessRequirements
            Case eColor.eWhite
                dStandardLuminanceValue = sMeteralValue.sWhite.dBrightnessRequirements
        End Select

        For i As Integer = 0 To sIVLData(0).Length - 1
            '요구휘도에 제일 가까운 2개의 점을 찾아야 한다.

            If dStandardLuminanceValue > sIVLData(0)(i).dLuminance_Fill_Cdm2 Then
                nRowBotton = i
                bRowBotton = True
            ElseIf dStandardLuminanceValue < sIVLData(0)(i).dLuminance_Fill_Cdm2 Then
                nRowTop = i
                bRowTop = True
            ElseIf dStandardLuminanceValue = sIVLData(0)(i).dLuminance_Fill_Cdm2 Then
                nRowBotton = i
                nRowTop = i
                bRowBotton = True
                bRowTop = True
            End If
        Next

        If bRowBotton = False Or bRowTop = False Then
            sMeteralValue.sColorName = "Fail..."
            sMeteralValue.dRealCurrent = 0
            Return False
        End If

        ReDim dCurrent(1)
        ReDim dLuminace(1)

        dLuminace(0) = sIVLData(0)(nRowBotton).dLuminance_Fill_Cdm2
        dLuminace(1) = sIVLData(0)(nRowTop).dLuminance_Fill_Cdm2
        dCurrent(0) = sIVLData(0)(nRowBotton).dCurrent
        dCurrent(1) = sIVLData(0)(nRowTop).dCurrent

        Interpolation(dCurrent, dLuminace, dRealCurrent, dStandardLuminanceValue)

        sMeteralValue.dRealCurrent = dRealCurrent

        Return True
    End Function

#End Region


#Region "FWHM Calculation Functions"


#End Region

    Public Function Cal_FWHM(ByVal nELmax As Integer, ByVal dNomrIntensity() As Double, ByVal nWavelength() As Integer, ByVal nRowCount As Integer, ByRef dFWHM As Double) As Boolean
        Dim sELData As sSpectrumData
        Dim dL_EL_Wavelength, dR_EL_Wavelength As Double
        Dim dBuf_Intensity As Double
        Dim nLSerchNumber As Integer
        Dim nRSerchNumber As Integer
        Dim dStandardValue As Double = 0.5
        Dim dWave() As Double = Nothing
        Dim dIntensity() As Double = Nothing
        Dim cnt As Integer = 0

        nLSerchNumber = nELmax - nWavelength(0)
        nRSerchNumber = nWavelength(nWavelength.Length - 1) - nELmax

        'Serch Left Min(top), Max(botton)
        For i As Integer = 0 To nLSerchNumber Step nRowCount
            dBuf_Intensity = dStandardValue - dNomrIntensity(cnt)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dLeft_Top_Intensity Or sELData.dLeft_Top_Intensity = 0 Then
                    sELData.dLeft_Top_Intensity = dBuf_Intensity
                    sELData.dLeft_Top_Wavelength = nWavelength(cnt)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dLeft_Botton_Intensity Or sELData.dLeft_Botton_Intensity = 0 Then
                    sELData.dLeft_Botton_Intensity = dBuf_Intensity
                    sELData.dLeft_Botton_Wavelength = nWavelength(cnt)
                End If
            End If
            cnt += 1
        Next

        cnt = 0
        Dim nStartIndex As Integer = nLSerchNumber / nRowCount
        'Serch Right Min(top), Max(botton)
        For i As Integer = nLSerchNumber To nRSerchNumber + nLSerchNumber Step nRowCount
            dBuf_Intensity = dStandardValue - dNomrIntensity(nStartIndex + cnt)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dRight_Top_Intensity Or sELData.dRight_Top_Intensity = 0 Then
                    sELData.dRight_Top_Intensity = dBuf_Intensity
                    sELData.dRight_Top_Wavelength = nWavelength(nStartIndex + cnt)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dRight_Botton_Intensity Or sELData.dRight_Botton_Intensity = 0 Then
                    sELData.dRight_Botton_Intensity = dBuf_Intensity
                    sELData.dRight_Botton_Wavelength = nWavelength(nStartIndex + cnt)
                End If
            End If
            cnt += 1
        Next

        'Interpolation

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dLeft_Botton_Wavelength
        dWave(1) = sELData.dLeft_Top_Wavelength
        dIntensity(0) = sELData.dLeft_Botton_Intensity
        dIntensity(1) = sELData.dLeft_Top_Intensity

        Interpolation(dWave, dIntensity, dL_EL_Wavelength, 0)

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dRight_Botton_Wavelength
        dWave(1) = sELData.dRight_Top_Wavelength
        dIntensity(0) = sELData.dRight_Botton_Intensity
        dIntensity(1) = sELData.dRight_Top_Intensity

        Interpolation(dWave, dIntensity, dR_EL_Wavelength, 0)


        'sELData()
        'dL_EL_Intensity_Top, dL_EL_Intensity_Botton, dR_EL_Intensity_Top, dR_EL_Intensity_Botton
        'dL_EL_Wavelength_Top, dL_EL_Wavelength_Botton, dR_EL_Wavelength_Top, dR_EL_Wavelength_Botton

        'return dL_EL_Wavelength, dR_EL_Wavelength
        dFWHM = Math.Abs(dR_EL_Wavelength - dL_EL_Wavelength)

        Return True
        'Dim sELData As sSpectrumData
        'Dim dL_EL_Wavelength, dR_EL_Wavelength As Double
        'Dim dBuf_Intensity As Double
        'Dim nLSerchNumber As Integer
        'Dim nRSerchNumber As Integer
        'Dim dStandardValue As Double = 0.5
        'Dim dWave() As Double = Nothing
        'Dim dIntensity() As Double = Nothing

        'nLSerchNumber = nELmax - 380
        'nRSerchNumber = 780 - nELmax

        ''Serch Left Min(top), Max(botton)
        'For i As Integer = 0 To nLSerchNumber Step nRowCount
        '    dBuf_Intensity = dStandardValue - dNomrIntensity(i)

        '    'dStandard 값이 -면 top, +면 botton
        '    If dBuf_Intensity <= 0 Then
        '        'top
        '        If dBuf_Intensity > sELData.dLeft_Top_Intensity Or sELData.dLeft_Top_Intensity = 0 Then
        '            sELData.dLeft_Top_Intensity = dBuf_Intensity
        '            sELData.dLeft_Top_Wavelength = nWavelength(i)
        '        End If
        '    Else
        '        'botton
        '        If dBuf_Intensity <= sELData.dLeft_Botton_Intensity Or sELData.dLeft_Botton_Intensity = 0 Then
        '            sELData.dLeft_Botton_Intensity = dBuf_Intensity
        '            sELData.dLeft_Botton_Wavelength = nWavelength(i)
        '        End If
        '    End If
        'Next

        'cnt = 0
        'Dim nStartIndex As Integer = nLSerchNumber / nRowCount

        ''Serch Right Min(top), Max(botton)
        'For i As Integer = nLSerchNumber To nRSerchNumber + nLSerchNumber Step nRowCount
        '    dBuf_Intensity = dStandardValue - dNomrIntensity(i)

        '    'dStandard 값이 -면 top, +면 botton
        '    If dBuf_Intensity <= 0 Then
        '        'top
        '        If dBuf_Intensity > sELData.dRight_Top_Intensity Or sELData.dRight_Top_Intensity = 0 Then
        '            sELData.dRight_Top_Intensity = dBuf_Intensity
        '            sELData.dRight_Top_Wavelength = nWavelength(i)
        '        End If
        '    Else
        '        'botton
        '        If dBuf_Intensity <= sELData.dRight_Botton_Intensity Or sELData.dRight_Botton_Intensity = 0 Then
        '            sELData.dRight_Botton_Intensity = dBuf_Intensity
        '            sELData.dRight_Botton_Wavelength = nWavelength(i)
        '        End If
        '    End If
        'Next

        ''Interpolation

        'ReDim dWave(1)
        'ReDim dIntensity(1)

        'dWave(0) = sELData.dLeft_Botton_Wavelength
        'dWave(1) = sELData.dLeft_Top_Wavelength
        'dIntensity(0) = sELData.dLeft_Botton_Intensity
        'dIntensity(1) = sELData.dLeft_Top_Intensity

        'Interpolation(dWave, dIntensity, dL_EL_Wavelength, dStandardValue)

        'ReDim dWave(1)
        'ReDim dIntensity(1)

        'dWave(0) = sELData.dRight_Botton_Wavelength
        'dWave(1) = sELData.dRight_Top_Wavelength
        'dIntensity(0) = sELData.dRight_Botton_Intensity
        'dIntensity(1) = sELData.dRight_Top_Intensity

        'Interpolation(dWave, dIntensity, dR_EL_Wavelength, dStandardValue)


        ''sELData()
        ''dL_EL_Intensity_Top, dL_EL_Intensity_Botton, dR_EL_Intensity_Top, dR_EL_Intensity_Botton
        ''dL_EL_Wavelength_Top, dL_EL_Wavelength_Botton, dR_EL_Wavelength_Top, dR_EL_Wavelength_Botton

        ''return dL_EL_Wavelength, dR_EL_Wavelength
        'dFWHM = Math.Abs(dR_EL_Wavelength - dL_EL_Wavelength)

        'Return True
    End Function
    Public Function Cal_FWHM(ByVal nELmax As Integer, ByVal dNomrIntensity() As Double, ByVal nWavelength() As Integer, ByRef dFWHM As Double) As Boolean
        Dim sELData As sSpectrumData
        Dim dL_EL_Wavelength, dR_EL_Wavelength As Double
        Dim dBuf_Intensity As Double
        Dim nLSerchNumber As Integer
        Dim nRSerchNumber As Integer
        Dim dStandardValue As Double = 0.5
        Dim dWave() As Double = Nothing
        Dim dIntensity() As Double = Nothing

        nLSerchNumber = nELmax - 380
        nRSerchNumber = 780 - nELmax

        'Serch Left Min(top), Max(botton)
        For i As Integer = 0 To nLSerchNumber
            dBuf_Intensity = dStandardValue - dNomrIntensity(i)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dLeft_Top_Intensity Or sELData.dLeft_Top_Intensity = 0 Then
                    sELData.dLeft_Top_Intensity = dBuf_Intensity
                    sELData.dLeft_Top_Wavelength = nWavelength(i)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dLeft_Botton_Intensity Or sELData.dLeft_Botton_Intensity = 0 Then
                    sELData.dLeft_Botton_Intensity = dBuf_Intensity
                    sELData.dLeft_Botton_Wavelength = nWavelength(i)
                End If
            End If
        Next

        'Serch Right Min(top), Max(botton)
        For i As Integer = nLSerchNumber To nRSerchNumber + nLSerchNumber
            dBuf_Intensity = dStandardValue - dNomrIntensity(i)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dRight_Top_Intensity Or sELData.dRight_Top_Intensity = 0 Then
                    sELData.dRight_Top_Intensity = dBuf_Intensity
                    sELData.dRight_Top_Wavelength = nWavelength(i)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dRight_Botton_Intensity Or sELData.dRight_Botton_Intensity = 0 Then
                    sELData.dRight_Botton_Intensity = dBuf_Intensity
                    sELData.dRight_Botton_Wavelength = nWavelength(i)
                End If
            End If
        Next

        'Interpolation

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dLeft_Botton_Wavelength
        dWave(1) = sELData.dLeft_Top_Wavelength
        dIntensity(0) = sELData.dLeft_Botton_Intensity
        dIntensity(1) = sELData.dLeft_Top_Intensity

        Interpolation(dWave, dIntensity, dL_EL_Wavelength, 0)

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dRight_Botton_Wavelength
        dWave(1) = sELData.dRight_Top_Wavelength
        dIntensity(0) = sELData.dRight_Botton_Intensity
        dIntensity(1) = sELData.dRight_Top_Intensity

        Interpolation(dWave, dIntensity, dR_EL_Wavelength, 0)


        'sELData()
        'dL_EL_Intensity_Top, dL_EL_Intensity_Botton, dR_EL_Intensity_Top, dR_EL_Intensity_Botton
        'dL_EL_Wavelength_Top, dL_EL_Wavelength_Botton, dR_EL_Wavelength_Top, dR_EL_Wavelength_Botton

        'return dL_EL_Wavelength, dR_EL_Wavelength
        dFWHM = Math.Abs(dR_EL_Wavelength - dL_EL_Wavelength)

        Return True
    End Function

    Public Function Interpolation(ByVal x() As Double, ByVal y() As Double, ByRef ref_x As Double, ByVal ref_y As Double) As Boolean
        ref_x = (x(1) - x(0)) * (ref_y - y(0)) / (y(1) - y(0)) + x(0)
        Return True
    End Function

    Public Structure sSpectrumData
        Dim dLeft_Top_Wavelength As Double
        Dim dLeft_Top_Intensity As Double
        Dim dLeft_Botton_Wavelength As Double
        Dim dLeft_Botton_Intensity As Double
        Dim dRight_Top_Wavelength As Double
        Dim dRight_Top_Intensity As Double
        Dim dRight_Botton_Wavelength As Double
        Dim dRight_Botton_Intensity As Double
    End Structure
    Public Function IntegralToData(ByVal In_Intensity1() As Double, ByVal In_Lamda() As Integer, ByVal StartWaveLen As Integer, ByVal EndWaveLen As Integer, ByVal nRow As Integer) As Double
        Dim ResultValue As Double = Nothing
        Dim TempData As Double = Nothing
        'start가 380이고 end가 540이면
        '람다의 idx가 379보다 크고 541보다 작으면 
        For idx As Integer = 0 To In_Intensity1.Length - 1
            If In_Lamda(idx) > StartWaveLen - 1 And In_Lamda(idx) < EndWaveLen + 1 Then
                TempData = TempData + (In_Lamda(idx) * In_Intensity1(idx))
            End If
        Next
        ResultValue = TempData * nRow
        Return ResultValue
    End Function

    Public Function IntegralToData_Photopic(ByVal In_Intensity1() As Double, ByVal In_Lamda() As Integer, ByVal StartWaveLen As Integer, ByVal EndWaveLen As Integer, ByVal nRow As Integer) As Double
        Dim ResultValue As Double = Nothing
        Dim TempData As Double = Nothing
        ColorMatchingFuntions()

        'start가 380이고 end가 540이면
        '람다의 idx가 379보다 크고 541보다 작으면 
        For idx As Integer = 0 To In_Intensity1.Length - 1
            If In_Lamda(idx) > StartWaveLen - 1 And In_Lamda(idx) < EndWaveLen + 1 Then
                TempData = TempData + (In_Lamda(idx) * In_Intensity1(idx) * CMF(idx, 1))
            End If
        Next
        ResultValue = TempData * nRow
        Return ResultValue
    End Function

    Public Function DataNormalization(ByVal inData() As Double, ByVal RowCount As Integer, ByRef nELmax As Integer) As Double()

        'Dim nNumOfDataPoint As Integer
        'Dim nCntDPoint As Integer
        'Dim dMaxValue As Double = 0
        'Dim nIndexOfMaxVal As Integer
        'Dim dDataBuf As Double
        'Dim dNormalizedData() As Double

        'nNumOfDataPoint = inData.Length
        'ReDim dNormalizedData(nNumOfDataPoint - 1)

        ''1. Max값 찾기
        'dMaxValue = GetMaxValue(inData, nIndexOfMaxVal)

        ''2. Max값을 기준으로 Normalization 시작
        'For nCntDPoint = 0 To nNumOfDataPoint - 1
        '    dDataBuf = inData(nCntDPoint) / dMaxValue

        '    dNormalizedData(nCntDPoint) = dDataBuf
        'Next

        'nELmax = nIndexOfMaxVal + 380
        'Return dNormalizedData
        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim nIndexOfMaxVal As Integer
        Dim dDataBuf As Double
        Dim dNormalizedData() As Double

        nNumOfDataPoint = inData.Length
        ReDim dNormalizedData(nNumOfDataPoint - 1)

        '1. Max값 찾기
        dMaxValue = GetMaxValue(inData, nIndexOfMaxVal)

        '2. Max값을 기준으로 Normalization 시작
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            dDataBuf = inData(nCntDPoint) / dMaxValue

            dNormalizedData(nCntDPoint) = dDataBuf
        Next

        nELmax = (nIndexOfMaxVal * RowCount) + 380
        Return dNormalizedData
    End Function

    Public Function GetMaxValue(ByVal inData() As Double, ByRef out_index As Integer) As Double

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim dIndexOfMaxVal As Integer

        nNumOfDataPoint = inData.Length
        '1. Max값 찾기
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            If dMaxValue < inData(nCntDPoint) Then
                dMaxValue = inData(nCntDPoint)
                dIndexOfMaxVal = nCntDPoint
            End If
        Next
        out_index = dIndexOfMaxVal
        Return dMaxValue
    End Function

End Class
