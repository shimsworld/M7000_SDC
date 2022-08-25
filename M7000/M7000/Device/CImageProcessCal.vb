Imports ZedGraph
Imports Matrox.MatroxImagingLibrary

Public Class CImageProcessCal


#Region "Define"
    Dim nCCDResolutionX As Integer
    Dim nCCDResolutionY As Integer

    Dim CCDCenterPos As sXYPosition

    Public Structure sXYPosition
        Dim posX As Double
        Dim posY As Double
    End Structure

    Public Structure sCenterInfo
        Dim rateX As Double
        Dim rateY As Double
        Dim posX As Double
        Dim posY As Double
    End Structure


    Public Structure sFocusingInfo
        Dim dArea As Double
        Dim dFocusingLength As Double
        Dim dMaxIntensity As Double
        Dim nGrayScaleOfMaxIntensity As Integer
    End Structure


    Public Enum eLightingIntensity
        eDark
        eLowIntensity
        eCorrectIntensity
    End Enum

#End Region


#Region "Property"


    Public Property CCDResolutionX() As Integer
        Get
            Return nCCDResolutionX
        End Get
        Set(ByVal Value As Integer)
            nCCDResolutionX = Value
        End Set
    End Property

    Public Property CCDResolutiony() As Integer
        Get
            Return nCCDResolutionY
        End Get
        Set(ByVal Value As Integer)
            nCCDResolutionY = Value
        End Set
    End Property


#End Region

    Public Sub New()
        nCCDResolutionX = 1280 '1280
        nCCDResolutionY = 960 '960

        CCDCenterPos.posX = nCCDResolutionX / 2
        CCDCenterPos.posY = nCCDResolutionY / 2
    End Sub


    Public Function CalCenteringRate(ByVal CenterX As Double, ByVal CenterY As Double, ByRef retoutinfo As sCenterInfo) As Boolean
        'Dim nBlobNum As Integer

        'If nBlobNum <= 0 Then
        '    Return False
        'End If

        retoutinfo.posX = CenterX
        retoutinfo.posY = CenterY
        retoutinfo.rateX = (CCDCenterPos.posX - CenterX) / CCDCenterPos.posX * 100
        retoutinfo.rateY = (CCDCenterPos.posY - CenterY) / CCDCenterPos.posY * 100

        Return True
    End Function

    Public Function CalCenteringRate(ByVal Xmin() As Double, ByVal Ymin() As Double, ByVal Xmax() As Double, _
                                     ByVal Ymax() As Double, ByRef outInfo As sCenterInfo) As Boolean
        Dim nBlobNum As Integer
        Dim i As Integer
        Dim bufXmin As Double = nCCDResolutionX
        Dim bufXmax As Double = 0
        Dim bufYmin As Double = nCCDResolutionY
        Dim bufYmax As Double = 0
        Dim minPos As sXYPosition
        Dim maxPos As sXYPosition
        Dim centerPos As sXYPosition

        nBlobNum = Xmin.Length

        If nBlobNum <= 0 Then
            Return False
        End If

        For i = 0 To nBlobNum - 1
            If bufXmin > Xmin(i) Then
                bufXmin = Xmin(i)
            End If

            If bufXmax < Xmax(i) Then
                bufXmax = Xmax(i)
            End If

            If bufYmin > Ymin(i) Then
                bufYmin = Ymin(i)
            End If

            If bufYmax < Ymax(i) Then
                bufYmax = Ymax(i)
            End If
        Next

        minPos.posX = bufXmin
        minPos.posY = bufYmin

        maxPos.posX = bufXmax
        maxPos.posY = bufYmax

        centerPos.posX = ((maxPos.posX - minPos.posX) / 2) + minPos.posX
        centerPos.posY = ((maxPos.posY - minPos.posY) / 2) + minPos.posY

        outInfo.posX = centerPos.posX
        outInfo.posY = centerPos.posY
        outInfo.rateX = (CCDCenterPos.posX - centerPos.posX) / CCDCenterPos.posX * 100
        outInfo.rateY = (CCDCenterPos.posY - centerPos.posY) / CCDCenterPos.posY * 100

        Return True
    End Function

    Public Function CalCenteringRateLeftTopCorner(ByVal Xmin() As Double, ByVal Ymin() As Double, ByVal Xmax() As Double, _
                                  ByVal Ymax() As Double, ByRef outInfo As sCenterInfo) As Boolean
        Dim nBlobNum As Integer
        Dim i As Integer
        Dim bufXmin As Integer = nCCDResolutionX
        Dim bufXmax As Double = 0
        Dim bufYmin As Integer = nCCDResolutionY
        Dim bufYmax As Double = 0

        Dim nScanRegionX As Integer = nCCDResolutionX * 0 ' 0.2   영상의 영역 설정
        Dim nScanRegionY As Integer = 0
        Dim minPos As sXYPosition

        nBlobNum = Xmax.Length

        If nBlobNum <= 0 Then
            Return False
        End If

        For i = 0 To nBlobNum - 1

            If Xmax(i) >= nScanRegionX Then
                If bufXmin > Xmax(i) Then
                    bufXmin = Xmax(i)
                End If
            End If

            If Ymin(i) >= nScanRegionY Then
                If bufYmin > Ymin(i) Then
                    bufYmin = Ymin(i)
                End If
            End If

        Next

        minPos.posX = bufXmin
        minPos.posY = bufYmin

        outInfo.posX = minPos.posX
        outInfo.posY = minPos.posY
        outInfo.rateX = (CCDCenterPos.posX - minPos.posX) / CCDCenterPos.posX * 100
        outInfo.rateY = (CCDCenterPos.posY - minPos.posY) / CCDCenterPos.posY * 100

        Return True
    End Function

    Public Function DecideAutoFocusingPosition(ByVal inImageInfo() As sFocusingInfo) As Boolean

        Return True

    End Function


    Private Const HIST_NUM_INTENSITIES As Integer = 256
    'Public Sub HistogramDataProcess(ByVal HistValues() As MIL_INT, ByVal displayGraph As AxCWUIControlsLib.AxCWGraph, ByVal threshold As Integer, ByRef outMaxVal As Integer, ByRef outGrayLevel As Integer)

    '    Dim maxValue As Integer = 0
    '    Dim grayLevelOfMaxVal As Integer

    '    Dim plotValX(HIST_NUM_INTENSITIES - threshold - 1) As Double
    '    Dim plotValY(HIST_NUM_INTENSITIES - threshold - 1) As Double

    '    For i As Integer = threshold To HIST_NUM_INTENSITIES - 1
    '        plotValX(i - threshold) = i
    '        plotValY(i - threshold) = HistValues(i)

    '        If maxValue < plotValY(i - threshold) Then
    '            maxValue = plotValY(i - threshold)
    '            grayLevelOfMaxVal = i
    '        End If
    '    Next

    '    outMaxVal = maxValue
    '    outGrayLevel = grayLevelOfMaxVal

    '    displayGraph.PlotXvsY(plotValX, plotValY)
    'End Sub


    Public Sub HistogramDataProcess(ByVal HistValues() As MIL_INT, ByVal displayGraph As ucDispGraph, ByVal threshold As Integer, ByRef outMaxVal As Integer, ByRef outGrayLevel As Integer)

        Dim maxValue As Integer = 0
        Dim grayLevelOfMaxVal As Integer

        Dim plotValX(HIST_NUM_INTENSITIES - threshold - 1) As Double
        Dim plotValY(HIST_NUM_INTENSITIES - threshold - 1) As Double

        For i As Integer = threshold To HIST_NUM_INTENSITIES - 1
            plotValX(i - threshold) = i
            plotValY(i - threshold) = HistValues(i)

            If maxValue < plotValY(i - threshold) Then
                maxValue = plotValY(i - threshold)
                grayLevelOfMaxVal = i
            End If
        Next

        outMaxVal = maxValue
        outGrayLevel = grayLevelOfMaxVal

        displayGraph.InitGraph()

        displayGraph.PlotData(plotValX.Length, plotValX, plotValY)

        ' displayGraph.PlotXvsY(plotValX, plotValY)
    End Sub

    Public Sub HistogramDataProcess(ByVal HistValues() As MIL_INT, _
                                     ByVal threshold As Integer, ByRef outMaxVal As Integer, ByRef outGrayLevel As Integer, _
                                     ByRef outHistoX() As Integer, ByRef outHistoY() As Integer)

        Dim maxValue As Integer = 0
        Dim grayLevelOfMaxVal As Integer

        Dim plotValX(HIST_NUM_INTENSITIES - threshold - 1) As Integer
        Dim plotValY(HIST_NUM_INTENSITIES - threshold - 1) As Integer

        For i As Integer = threshold To HIST_NUM_INTENSITIES - 1
            plotValX(i - threshold) = i
            plotValY(i - threshold) = HistValues(i)

            If maxValue < plotValY(i - threshold) Then
                maxValue = plotValY(i - threshold)
                grayLevelOfMaxVal = i
            End If
        Next

        outMaxVal = maxValue
        outGrayLevel = grayLevelOfMaxVal

        outHistoX = plotValX.Clone
        outHistoY = plotValY.Clone
    End Sub






End Class
