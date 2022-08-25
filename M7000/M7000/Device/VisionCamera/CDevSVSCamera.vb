Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Compatibility
Imports Matrox.MatroxImagingLibrary

Public Class CDevSVSCamera
    Inherits CDevVisionCameraCommonNode

#Region "Define"
    Public cSVS As cSVSCamera_API.cSVSCamera = New cSVSCamera_API.cSVSCamera
    Public TempList() As cSVSCamera_API.cSVSCamera.sConfigInfo

    '***************************************************************************************8
    Dim MilApplication As MIL_ID = MIL.M_NULL ' Application identifier.
    Dim MilSystem As MIL_ID = MIL.M_NULL ' System identifier.
    Dim MilDisplay As MIL_ID = MIL.M_NULL ' Display identifier.
    Dim MilDisplay_Proc As MIL_ID = MIL.M_NULL
    Dim MilImage As MIL_ID = MIL.M_NULL ' Image buffer identifier.
    Dim MilAnalysisImage As MIL_ID = MIL.M_NULL
    Private Const HIST_NUM_INTENSITIES As Integer = 256
    Private Shared ReadOnly CONTOUR_DRAW_COLOR As Integer = MIL.M_COLOR_GREEN
    Private Shared ReadOnly CONTOUR_LABEL_COLOR As Integer = MIL.M_COLOR_RED
    Private Const CONTOUR_MAX_RESULTS As Integer = 100
    Private Const CONTOUR_MAXIMUM_ELONGATION As Double = 0.9

    Dim MilOverlayImage As MIL_ID = MIL.M_NULL ' Overlay image.

#End Region

#Region "Creator, Disoposer And Init"

    Public Sub New(ByVal dispPanel As System.Windows.Forms.Panel, ByVal procPanel As System.Windows.Forms.Panel)
        MyBase.new(dispPanel, procPanel)

        m_MyModel = eModel._SVSCamera
        m_displayPanel = dispPanel
        m_procPanel = procPanel
        init()
    End Sub

    Public Overrides Sub Dispose()
        'MIL(Free)

        GrabStop()

        If m_bIsConnectedCamera = True Then
            MIL.MbufFree(MilImage)
            MIL.MbufFree(MilAnalysisImage)
        End If

        '  MIL.MimFree(MilOverlayImage)

        ' Thread.Sleep(1000)
        MIL.MdispFree(MilDisplay)
        MIL.MdispFree(MilDisplay_Proc)

        'CCD재연결 중 연결끊으면 여기 아래부분 애러뜬다. MsysFree, MappFree
        '원인은 윗단에 m_bIsConnectedCamera= true 아래부분에 bufFree가 된 후에 진행되야 하는데 안되서 그렇다
        MIL.MsysFree(MilSystem)
        MIL.MappFree(MilApplication)
        'MIL.MsysFree(MilSystem)
        'MIL.MdispFree(MilDisplay)
        ' MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MIL.M_NULL)

    End Sub

    Private Sub init()

        If File.Exists(sSavePath) = False Then
            File.Create(sSavePath)
        End If

        DispControlFit(m_displayPanel, m_dDisplayRatioX_GrabImg, m_dDisplayRatioY_GrabImg)
        DispControlFit(m_procPanel, m_dDisplayRatioX_ProcImg, m_dDisplayRatioY_ProcImg)

        'Allocate defaults.
        MIL.MappAllocDefault(MIL.M_DEFAULT, MilApplication, MilSystem, MilDisplay, CType(MIL.M_NULL, IntPtr), CType(MIL.M_NULL, IntPtr))

        MIL.MdispAlloc(MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, MilDisplay_Proc)

        '      MIL.MdispAlloc(MilSystem,    '(MIL.M_DEFAULT, MilApplication, MilSystem, MilDisplay, CType(MIL.M_NULL, IntPtr), CType(MIL.M_NULL, IntPtr))

    End Sub


    Public Overrides Sub DispControlFit()
        DispControlFit(m_displayPanel, m_dDisplayRatioX_GrabImg, m_dDisplayRatioY_GrabImg)
        DispControlFit(m_procPanel, m_dDisplayRatioX_ProcImg, m_dDisplayRatioY_ProcImg)
    End Sub


    Private Overloads Sub DispControlFit(ByVal ctrl As Windows.Forms.Panel, ByRef ratioX As Double, ByRef ratioY As Double)

        Dim bufSize As Size
        Dim bufSizeX As Integer
        Dim bufSizeY As Integer
        '   Dim bufLocationX As Integer
        '   Dim bufLocationY As Integer
        Dim nMarginX As Integer = 3
        Dim nMarginY As Integer = 3
        Dim nSeperatorArea As Integer = 0

        bufSizeX = ctrl.Size.Width
        bufSizeY = ctrl.Size.Height

        bufSize = New System.Drawing.Size(bufSizeX, bufSizeY)

        ' lblDispTitle2.Location = New System.Drawing.Point((bufSizeX / 2) - (lblDispTitle2.Size.Width / 2) + bufLocationX, 3)


        '디스플레이 비율 업데이트
        CalDispZoomRatio(ctrl, ratioX, ratioY)

    End Sub


    Private Sub CalDispZoomRatio(ByVal ctrl As Windows.Forms.Panel, ByRef ratioX As Double, ByRef ratioY As Double)
        ratioX = ctrl.Width / m_nCCDResolutionX
        ratioY = ctrl.Height / m_nCCDResolutionY
    End Sub
    Public Overrides Function Reconnection() As Boolean

        '1. Disconnection
        If m_bIsConnectedCamera = True Then
            If cSVS.bConnected() = True Then
                If cSVS.Disconnection(TempList(0)) = True Then
                End If
            End If
        End If

        Thread.Sleep(5000)  '5초 대기

        '2. Search할때마다 변경되므로 다시 search해서 연결함
        TempList = cSVS.Serach_Camera()

        If TempList.Length = 0 Then
            m_bIsConnectedCamera = False
            Return False
        End If

        If cSVS.Connection(TempList(0), 3) = True Then
            ' init() '연결다했으면 초기화해줘야함.  '/MdispAlloc 메모리할당 필요할줄알았는데 필요없네
            m_bIsConnectedCamera = True
        Else
            Return False
        End If

        Return True
    End Function

    Public Overrides Function InitAllied(ByRef errMsg As String) As Boolean

        TempList = cSVS.Serach_Camera()

        If cSVS.bConnected() = False Then
            If TempList.Length = 0 Then
                m_bIsConnectedCamera = False
                Return False
            End If
            If cSVS.Connection(TempList(0), 3) = True Then

            End If
        End If

        m_bIsConnectedCamera = True
        Return True
    End Function

    Public Overrides Sub UninitAllied()
        If m_bIsConnectedCamera = True Then
            If cSVS.bConnected() = True Then
                If cSVS.Disconnection(TempList(0)) = True Then
                End If
            End If
        End If
    End Sub

#End Region

    Public Overrides Sub TriggerSyncModeGrab()
        m_GrabState = eGrabState.eIDle
    End Sub

#Region "Image Grap From CCD Camera"

    Public Overrides Function GrabStart() As Boolean

        If m_bCheckStart = True Then Return True

        If File.Exists(sSavePath) = True Then
            ''Restore source image into image buffer.
            MIL.MbufRestore(sSavePath, MilSystem, MilImage)
            MIL.MdispSelectWindow(MilDisplay, MilImage, CType(m_displayPanel.Handle, IntPtr))
            MIL.MdispZoom(MilDisplay, m_dDisplayRatioX_GrabImg, m_dDisplayRatioY_GrabImg)

            ''for image analysis
            'MIL.MbufAlloc2d(MilSystem, m_nCCDResolutionX, m_nCCDResolutionY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC + MIL.M_DISP, MilAnalysisImage)
            '' Display the buffer and prepare for overlay annotations.
            MIL.MbufRestore(sSavePath, MilSystem, MilAnalysisImage)
            MIL.MdispSelectWindow(MilDisplay_Proc, MilAnalysisImage, CType(m_procPanel.Handle, IntPtr))   'displayPanel.Handle
            MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY, MIL.M_ENABLE)
            MIL.MdispInquire(MilDisplay_Proc, MIL.M_OVERLAY_ID, MilOverlayImage)

            MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)
        Else
            Return False
        End If

        m_bCheckStart = True
        GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        Dim t1 As Thread = New Thread(AddressOf GetImage)
        t1.Start()

        Return True
    End Function

    Public Overrides Sub GrabStop()
        m_bCheckStart = False
    End Sub

    Private Sub GetImage()

        Dim imgData As System.Drawing.Bitmap = Nothing
        Dim imgHigh As Integer
        Dim imgWidth As Integer
        '   Dim imgSize As System.Drawing.Size
        Dim bResult As Boolean
        '  Dim img As Bitmap = Nothing
        Dim imsibuffer() As Byte = Nothing
        Dim bErrcount As Integer = 0
        imgWidth = m_nCCDResolutionX ' milImage.FileInquire(sSavePath, Matrox.ActiveMIL.ImParameterConstants.imSizeX)
        imgHigh = m_nCCDResolutionY 'milImage.FileInquire(sSavePath, Matrox.ActiveMIL.ImParameterConstants.imSizeY)

        '    imgSize.Height = imgHigh
        '  imgSize.Width = imgWidth

        ' fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "Scheduler Start")

        '  bResult = cSVS.GetimgData(img, imsibuffer)

        Do While m_bCheckStart = True
            Application.DoEvents()
            Thread.Sleep(150)
            bResult = cSVS.GetimgData(m_GrabImageData, imsibuffer)

            If bResult = True Then

                Do

                    If m_bCheckStart = False Then Exit Do

                    If m_GrabMode = eGrabMode.eContinue_NoImageProcess Then
                        Exit Do
                    ElseIf m_GrabMode = eGrabMode.eSyncMode Then
                        Application.DoEvents()
                        Thread.Sleep(50)
                        If m_GrabState = eGrabState.eIDle Then
                            m_GrabState = eGrabState.eNowGrabbing
                            Exit Do
                        End If
                    End If

                Loop
                '  GC.Collect()
                Try

                    ' m_GrabImageData.Save(sSavePath, System.Drawing.Imaging.ImageFormat.Bmp)   ', myEncoderParameters.Param(0).Enco

                    If m_bCheckStart = False Then Exit Do
                    ' MIL.MbufLoad(sSavePath, MilImage)
                    MIL.MbufPut(MilImage, imsibuffer)
                    MIL.MdispZoom(MilDisplay, m_dDisplayRatioX_GrabImg, m_dDisplayRatioY_GrabImg)

                    GC.Collect()
                    m_GrabImageData = Nothing

                Catch ex As Exception
                    'MsgBox(ex.Message())
                    '  frmMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed, "Get Image Routine Error" & ex.Message)
                    WriteLogMsg("Get Image Routine Error")
                End Try

                If m_GrabMode = eGrabMode.eSyncMode Then

                    If AnalysisGrabImage(imsibuffer) = False Then
                        m_GrabState = eGrabState.eFailed_Image_Grab
                    End If

                End If
                m_GrabState = eGrabState.eCompletedGrab
                ' imsibuffer = Nothing

            Else
                '' ''연결해제하고 재연결 5번시도 이후도 실패하면 fail처리함
                ' ''For idx As Integer = 0 To 5
                ' ''    If Reconnection() = False Then
                ' ''        ' frmMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed, "try to Reconnection fail / time : " & idx + 1)
                ' ''        WriteLogMsg("try to Reconnection fail / time : " & idx + 1)
                ' ''        bErrcount += 1
                ' ''    Else
                ' ''        ' frmMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed, "try to Reconnection / time : " & idx + 1)
                ' ''        WriteLogMsg("try to Reconnection fail / time : " & idx + 1)
                ' ''        bErrcount = 0
                ' ''        Exit For
                ' ''    End If

                ' ''    If bErrcount = 5 Then
                ' ''        m_GrabState = eGrabState.eFailed_Image_Grab
                ' ''        'frmMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed, "Reconnection Fail (5 Times)")
                ' ''        WriteLogMsg("Reconnection Fail (5 Times)")
                ' ''    End If
                ' ''Next
                '' '' m_GrabState = eGrabState.eFailed_Image_Grab
            End If

            Thread.Sleep(10)
        Loop

    End Sub

    Public Overrides Sub GrabDisplay()
        MIL.MdispSelectWindow(MilDisplay, MilImage, CType(m_displayPanel.Handle, IntPtr))
        MIL.MdispSelectWindow(MilDisplay_Proc, MilAnalysisImage, CType(m_procPanel.Handle, IntPtr))   'displayPanel.Handle
    End Sub

#End Region

#Region "Image Processing"

    Public Overrides Function AnalysisGrabImage(ByVal imageData() As Byte) As Boolean

        Dim histoX As Array = Nothing
        Dim histoY As Array = Nothing
        Dim nMaxIntensity As Integer
        Dim nGrayLevel As Integer
        Dim imgProcThresholdVal As Integer
        ' Dim dtotArea As Double

        Dim HistResult As MIL_ID = MIL.M_NULL
        Dim HistValues(HIST_NUM_INTENSITIES - 1) As MIL_INT

        If File.Exists(sSavePath) = False Then
            Return False
        End If

        'MIL.MbufLoad(MIL.M_INTERACTIVE, MilAnalysisImage)    'sSavePath
        ' MIL.MbufLoad(sSavePath, MilAnalysisImage)    'sSavePath
        MIL.MbufPut(MilAnalysisImage, imageData)

        MIL.MdispZoom(MilDisplay_Proc, m_dDisplayRatioX_ProcImg, m_dDisplayRatioY_ProcImg)



        ' Allocate a histogram result buffer.
        MIL.MimAllocResult(MilSystem, HIST_NUM_INTENSITIES, MIL.M_HIST_LIST, HistResult)

        ' Calculate the histogram.
        MIL.MimHistogram(MilAnalysisImage, HistResult)

        ' Get the results.
        MIL.MimGetResult(HistResult, MIL.M_VALUE, HistValues)

        CimgProc.HistogramDataProcess(HistValues, m_nDefThresholdValue, nMaxIntensity, nGrayLevel, histoX, histoY)

        If nGrayLevel < 254 Then
            imgProcThresholdVal = m_nImgProcThresholdVal1
        Else
            imgProcThresholdVal = m_nImgProcThresholdVal2
        End If

        With m_orgImgData
            .nGrayLevelOfMaxIntensity = nGrayLevel
            .nMaxIntensity = nMaxIntensity
            .processedHistoX = histoX.Clone()
            .processedHistoY = histoY.Clone()
        End With

        If m_SampleType = ucSampleInfos.eSampleType.eCell Then

            If g_SystemOptions.sOptionData.CCDData.ImageAnalysisMode = eCenteringAnalysisMode.eCenterBlob Then
                If BlobInfoAnalysisOfCell(imgProcThresholdVal, m_processedImgData) = False Then    'imgProcThresholdVal
                    MIL.MimFree(HistResult)
                    Return False
                End If

            ElseIf g_SystemOptions.sOptionData.CCDData.ImageAnalysisMode = eCenteringAnalysisMode.eCenterEdge Then
                If BlobInfoAnalysisOfPanelAndModule(imgProcThresholdVal, m_processedImgData) = False Then    'imgProcThresholdVal
                    MIL.MimFree(HistResult)
                    Return False
                End If
                'If EdgeInfoAnalysisOfCell(imgProcThresholdVal, m_processedImgData) = False Then
                '    MIL.MimFree(HistResult)
                '    Return False
                'End If
            End If
        Else
            If BlobInfoAnalysisOfPanelAndModule(imgProcThresholdVal, m_processedImgData) = False Then    'imgProcThresholdVal
                MIL.MimFree(HistResult)
                Return False
            End If
        End If

        MIL.MimFree(HistResult)

        Return True

    End Function

    Private Function EdgeInfoAnalysisOfCell(ByVal inThresholdVal As Integer, ByRef outData As sImageProcessedData) As Boolean

        Dim GraphicList As MIL_ID = MIL.M_NULL                      ' Graphic list identifier.
        Dim MilEdgeContext As MIL_ID = MIL.M_NULL                   ' Edge context.
        Dim MilEdgeResult As MIL_ID = MIL.M_NULL                    ' Edge result identifier.
        Dim EdgeDrawColor As Double = CONTOUR_DRAW_COLOR            ' Edge draw color.
        Dim LabelDrawColor As Double = CONTOUR_LABEL_COLOR          ' Text draw color.
        Dim NumEdgeFound As MIL_INT = 0                             ' Number of edges found.
        Dim NumResults As MIL_INT = 0                               ' Number of results found.
        Dim i As Integer = 0
        Dim MeanFeretDiameter(CONTOUR_MAX_RESULTS - 1) As Double    ' Edge mean Feret diameter.

        Dim drawingSize As System.Drawing.Size = New System.Drawing.Size(m_nCCDResolutionX, m_nCCDResolutionY)

        ' Allocate defaults.
        MIL.MappAllocDefault(MIL.M_DEFAULT, MilApplication, MilSystem, MilDisplay, CType(MIL.M_NULL, IntPtr), CType(MIL.M_NULL, IntPtr))

        ' Restore the image and display it.
        'MIL.MbufRestore(MilAnalysisImage, MilSystem, MilImage)
        'MIL.MdispSelect(MilDisplay, MilImage)

        ' Allocate a graphic list to hold the subpixel annotations to draw.
        MIL.MgraAllocList(MilSystem, MIL.M_DEFAULT, GraphicList)

        ' Associate the graphic list to the display for annotations.
        MIL.MdispControl(MilDisplay, MIL.M_ASSOCIATED_GRAPHIC_LIST_ID, GraphicList)

        ' Allocate a Edge Finder context.
        MIL.MedgeAlloc(MilSystem, MIL.M_CONTOUR, MIL.M_DEFAULT, MilEdgeContext)

        ' Allocate a result buffer.
        MIL.MedgeAllocResult(MilSystem, MIL.M_DEFAULT, MilEdgeResult)

        ' Enable features to compute.
        MIL.MedgeControl(MilEdgeContext, MIL.M_MOMENT_ELONGATION, MIL.M_ENABLE)
        MIL.MedgeControl(MilEdgeContext, MIL.M_FILTER_SMOOTHNESS, 100)
        MIL.MedgeControl(MilEdgeContext, MIL.M_FILTER_TYPE, MIL.M_SHEN)
        MIL.MedgeControl(MilEdgeContext, MIL.M_FERET_MEAN_DIAMETER + MIL.M_SORT1_DOWN, MIL.M_ENABLE)

        ' Calculate edges and features.
        MIL.MedgeCalculate(MilEdgeContext, MilImage, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MilEdgeResult, MIL.M_DEFAULT)

        ' Get the number of edges found.
        MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_NUMBER_OF_CHAINS + MIL.M_TYPE_MIL_INT, NumEdgeFound)

        ' Draw edges in the source image to show the result.
        MIL.MgraColor(MIL.M_DEFAULT, EdgeDrawColor)
        MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        ' Pause to show the edges.
        ' Console.Write("{0} edges were found in the image." + Constants.vbLf, NumEdgeFound)


        ' '' '' Exclude elongated edges.
        '' ''MIL.MedgeSelect(MilEdgeResult, MIL.M_EXCLUDE, MIL.M_MOMENT_ELONGATION, MIL.M_LESS, CONTOUR_MAXIMUM_ELONGATION, MIL.M_NULL)

        ' '' '' Exclude inner chains.
        '' ''MIL.MedgeSelect(MilEdgeResult, MIL.M_EXCLUDE, MIL.M_INCLUDED_EDGES, MIL.M_INSIDE_BOX, MIL.M_NULL, MIL.M_NULL)

        ' '' '' Draw remaining edges and their index to show the result.
        '' ''MIL.MgraClear(MIL.M_DEFAULT, GraphicList)
        '' ''MIL.MgraColor(MIL.M_DEFAULT, EdgeDrawColor)
        '' ''MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        ' '' '' Pause to show the results.
        ' '' ''Console.Write("Elongated edges and inner edges of each seal were removed." + Constants.vbLf)

        ' '' '' Get the number of edges found.
        '' ''MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_NUMBER_OF_CHAINS + MIL.M_TYPE_MIL_INT, NumResults)

        ' If the right number of edges were found.
        If (NumEdgeFound >= 1) AndAlso (NumEdgeFound <= CONTOUR_MAX_RESULTS) Then
            ' Draw the index of each edge.
            MIL.MgraColor(MIL.M_DEFAULT, LabelDrawColor)
            MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_INDEX, MIL.M_DEFAULT, MIL.M_DEFAULT)

            ' Get the mean Feret diameters.
            MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_FERET_MEAN_DIAMETER, MeanFeretDiameter)

            ' Print the results.
            'Console.Write("Mean diameter of the {0} outer edges are:" + Constants.vbLf + Constants.vbLf, NumResults)
            'For i = 0 To CType(NumResults - 1, Integer)
            '    Console.Write("{0,-11}{1,-13:0.00}" + Constants.vbLf, i, MeanFeretDiameter(i))
            'Next i
        Else
            Return False
            'Console.Write("Edges have not been found or the number of found edges is greater than" + Constants.vbLf)
        End If

        ''''
        Dim dCenterPosX As Double
        Dim dCenterPosY As Double

        MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_X, dCenterPosX)
        MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_Y, dCenterPosY)

        'Console.Write("X/Y Center Position" + Constants.vbLf)
        'Console.Write(dPosX & " / " & dPosY)
        'Console.Write(Constants.vbLf)

        'Dim MIN_BLOB_AREA As Integer = 50
        'Dim CogX As Double
        'Dim CogY As Double
        'Dim TotalBlobs As MIL_INT = 0
        ''MIL.MedgeSelect(MilEdgeResult, MIL.M_EXCLUDE, MIL.M_AREA, MIL.M_LESS_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL)

        'MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_X, CogX)
        'MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_Y, CogY)

        ' '' Get the total number of selected blobs.
        ''MIL.MblobGetNumber(MilEdgeResult, TotalBlobs)
        ''Console.Write("There are {0} objects ", TotalBlobs)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '  MIL.MgraText(MIL.M_DEFAULT, GraphicList, dCenterPosX + 20, dCenterPosY + 20, "X :" & dCenterPosX)
        '  MIL.MgraText(MIL.M_DEFAULT, GraphicList, dCenterPosX + 20, dCenterPosY + 40, "Y :" & dCenterPosY)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)
        MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, MilOverlayImage, MIL.M_DRAW_BOX, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT)   'MIL.M_DEFAULT

        Dim centeringInfo As CImageProcessCal.sCenterInfo

        If CimgProc.CalCenteringRate(dCenterPosX, dCenterPosY, centeringInfo) = False Then

            ' Free all allocations.
            ' Free MIL objects.
            MIL.MgraFree(GraphicList)
            MIL.MbufFree(MilImage)
            MIL.MedgeFree(MilEdgeContext)
            MIL.MedgeFree(MilEdgeResult)

            ' Free defaults.
            MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MIL.M_NULL)

            Return False
        End If

        With outData
            .centerRateX = centeringInfo.rateX
            .centerRateY = centeringInfo.rateY
            .blobCenterPosX = centeringInfo.posX
            .blobCenterPosY = centeringInfo.posY
            .nNumOfBlob = 1
            .dArea = Nothing
        End With

        ' Free all allocations.
        ' Free MIL objects.
        'MIL.MgraFree(GraphicList)

        MIL.MedgeFree(MilEdgeContext)
        MIL.MedgeFree(MilEdgeResult)
        'MIL.MbufFree(MilImage)

        ' Free defaults.
        'MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MIL.M_NULL)

        Return True
    End Function

    Private Function BlobInfoAnalysisOfCell(ByVal inThresholdVal As Integer, ByRef outData As sImageProcessedData) As Boolean

        ' Local variables.
        Dim MilBinImage As MIL_ID = MIL.M_NULL ' Binary image buffer identifier.
        Dim MilBlobResult As MIL_ID = MIL.M_NULL ' Blob result buffer identifier.
        Dim MilBlobFeatureList As MIL_ID = MIL.M_NULL ' Feature list identifier.
        Dim TotalBlobs As MIL_INT = 0 ' Total number of blobs.
        '    Dim nBlobsWithHoles As Long         ' number of blobs with holes
        '    Dim nBlobsWithRoughHoles As Long    ' number of blobs with rough holes
        Dim MIN_BLOB_RADIUS As Integer = m_nMinBlobRadius '최소 Blob 반경
        Dim nImgProc_ThresholdValue As Integer = inThresholdVal
        Const MIN_BLOB_AREA As Integer = 10

        '    Const MAX_BLOB_AREA As Integer = 50000

        Dim drawingSize As System.Drawing.Size = New System.Drawing.Size(m_nCCDResolutionX, m_nCCDResolutionY)

        'displayImageProcess.Zoom(m_dDisplayRatioX, m_dDisplayRatioY)
        ' Allocate a binary image buffer for fast processing.
        MIL.MbufAlloc2d(MilSystem, MIL.MbufInquire(MilAnalysisImage, MIL.M_SIZE_X, MIL.M_NULL), MIL.MbufInquire(MilAnalysisImage, MIL.M_SIZE_Y, MIL.M_NULL), 1 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, MilBinImage)

        ' Binarize image.
        MIL.MimBinarize(MilAnalysisImage, MilBinImage, MIL.M_FIXED + MIL.M_GREATER_OR_EQUAL, inThresholdVal, MIL.M_NULL)

        ' Remove small particles and then remove small holes.
        MIL.MimOpen(MilBinImage, MilBinImage, MIN_BLOB_RADIUS, MIL.M_BINARY)
        MIL.MimClose(MilBinImage, MilBinImage, MIN_BLOB_RADIUS, MIL.M_BINARY)

        ' Allocate a feature list.
        MIL.MblobAllocFeatureList(MilSystem, MilBlobFeatureList)

        ' Enable the Area and Center Of Gravity feature calculation.
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_AREA)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_CENTER_OF_GRAVITY)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_X_MIN)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_X_MAX)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_Y_MIN)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_Y_MAX)


        ' Allocate a blob result buffer.
        MIL.MblobAllocResult(MilSystem, MilBlobResult)

        ' Calculate selected features for each blob.
        MIL.MblobCalculate(MilBinImage, MIL.M_NULL, MilBlobFeatureList, MilBlobResult)

        ' Exclude blobs whose area is too small.
        'MIL.MblobSelect(MilBlobResult, MIL.M_MERGE, MIL.M_AREA, MIL.M_GREATER_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL)
        MIL.MblobSelect(MilBlobResult, MIL.M_EXCLUDE, MIL.M_AREA, MIL.M_LESS_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL)

        ' Get the total number of blobs.
        MIL.MblobGetNumber(MilBlobResult, TotalBlobs)

        Dim dArea(TotalBlobs - 1) As Double
        Dim dTotArea As Double
        Dim minX(TotalBlobs - 1) As Double
        Dim minY(TotalBlobs - 1) As Double
        Dim maxX(TotalBlobs - 1) As Double
        Dim maxY(TotalBlobs - 1) As Double

        If TotalBlobs <> MIL.M_NULL Then
            Dim i As Integer



            ' Get the results.
            MIL.MblobGetResult(MilBlobResult, MIL.M_AREA, dArea)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_X_MIN, minX)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_X_MAX, maxX)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_Y_MIN, minY)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_Y_MAX, maxY)

            For i = 0 To TotalBlobs - 1
                dTotArea = dTotArea + dArea(i)
            Next
        End If

        ' Draw a cross at the center of gravity of each blob.

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)
        MIL.MblobDraw(MIL.M_DEFAULT, MilBlobResult, MilOverlayImage, MIL.M_DRAW_BOX, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT)   'MIL.M_DEFAULT

        Dim centeringInfo As CImageProcessCal.sCenterInfo

        If CimgProc.CalCenteringRate(minX, minY, maxX, maxY, centeringInfo) = True Then

            With outData
                .dArea = dTotArea
                .nNumOfBlob = TotalBlobs
                .centerRateX = centeringInfo.rateX
                .centerRateY = centeringInfo.rateY
                .blobCenterPosX = centeringInfo.posX
                .blobCenterPosY = centeringInfo.posY
            End With

            ' Free all allocations.
            MIL.MblobFree(MilBlobResult)
            MIL.MblobFree(MilBlobFeatureList)
            MIL.MbufFree(MilBinImage)

        Else

            With outData
                .dArea = dTotArea
                .nNumOfBlob = TotalBlobs
                .centerRateX = centeringInfo.rateX
                .centerRateY = centeringInfo.rateY
                .blobCenterPosX = centeringInfo.posX
                .blobCenterPosY = centeringInfo.posY
            End With


            ' Free all allocations.
            MIL.MblobFree(MilBlobResult)
            MIL.MblobFree(MilBlobFeatureList)
            MIL.MbufFree(MilBinImage)
            Return False
        End If

        Return True
    End Function

    Private Function BlobInfoAnalysisOfPanelAndModule(ByVal inThresholdVal As Integer, ByRef outData As sImageProcessedData) As Boolean

        ' Local variables.
        Dim MilBinImage As MIL_ID = MIL.M_NULL ' Binary image buffer identifier.
        Dim MilBlobResult As MIL_ID = MIL.M_NULL ' Blob result buffer identifier.
        Dim MilBlobFeatureList As MIL_ID = MIL.M_NULL ' Feature list identifier.
        Dim TotalBlobs As MIL_INT = 0 ' Total number of blobs.
        '    Dim nBlobsWithHoles As Long         ' number of blobs with holes
        '    Dim nBlobsWithRoughHoles As Long    ' number of blobs with rough holes
        Dim MIN_BLOB_RADIUS As Integer = m_nMinBlobRadius '최소 Blob 반경
        Dim nImgProc_ThresholdValue As Integer = inThresholdVal
        Const MIN_BLOB_AREA As Integer = 10
        '    Const MAX_BLOB_AREA As Integer = 50000

        Dim drawingSize As System.Drawing.Size = New System.Drawing.Size(m_nCCDResolutionX, m_nCCDResolutionY)

        'displayImageProcess.Zoom(m_dDisplayRatioX, m_dDisplayRatioY)
        ' Allocate a binary image buffer for fast processing.
        MIL.MbufAlloc2d(MilSystem, MIL.MbufInquire(MilAnalysisImage, MIL.M_SIZE_X, MIL.M_NULL), MIL.MbufInquire(MilAnalysisImage, MIL.M_SIZE_Y, MIL.M_NULL), 1 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, MilBinImage)

        ' Binarize image.
        MIL.MimBinarize(MilAnalysisImage, MilBinImage, MIL.M_FIXED + MIL.M_GREATER_OR_EQUAL, inThresholdVal, MIL.M_NULL)

        ' Remove small particles and then remove small holes.
        MIL.MimOpen(MilBinImage, MilBinImage, MIN_BLOB_RADIUS, MIL.M_BINARY)
        MIL.MimClose(MilBinImage, MilBinImage, MIN_BLOB_RADIUS, MIL.M_BINARY)

        ' Allocate a feature list.
        MIL.MblobAllocFeatureList(MilSystem, MilBlobFeatureList)

        ' Enable the Area and Center Of Gravity feature calculation.
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_AREA)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_CENTER_OF_GRAVITY)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_X_MIN)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_X_MAX)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_Y_MIN)
        MIL.MblobSelectFeature(MilBlobFeatureList, MIL.M_BOX_Y_MAX)


        ' Allocate a blob result buffer.
        MIL.MblobAllocResult(MilSystem, MilBlobResult)

        ' Calculate selected features for each blob.
        MIL.MblobCalculate(MilBinImage, MIL.M_NULL, MilBlobFeatureList, MilBlobResult)

        ' Exclude blobs whose area is too small.
        ' MIL.MblobSelect(MilBlobResult, MIL.M_EXCLUDE, MIL.M_AREA, MIL.M_LESS_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL)   'MilBlobResult, MIL.M_EXCLUDE, MIL.M_AREA, MIL.M_LESS_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL
        MIL.MblobSelect(MilBlobResult, MIL.M_MERGE, MIL.M_AREA, MIL.M_GREATER_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL)   'MilBlobResult, MIL.M_EXCLUDE, MIL.M_AREA, MIL.M_LESS_OR_EQUAL, MIN_BLOB_AREA, MIL.M_NULL

        ' Get the total number of blobs.
        MIL.MblobGetNumber(MilBlobResult, TotalBlobs)

        Dim dArea(TotalBlobs - 1) As Double
        Dim dTotArea As Double
        Dim minX(TotalBlobs - 1) As Double
        Dim minY(TotalBlobs - 1) As Double
        Dim maxX(TotalBlobs - 1) As Double
        Dim maxY(TotalBlobs - 1) As Double

        If TotalBlobs <> MIL.M_NULL Then
            Dim i As Integer

            ' Get the results.
            MIL.MblobGetResult(MilBlobResult, MIL.M_AREA, dArea)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_X_MIN, minX)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_X_MAX, maxX)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_Y_MIN, minY)
            MIL.MblobGetResult(MilBlobResult, MIL.M_BOX_Y_MAX, maxY)

            For i = 0 To TotalBlobs - 1
                dTotArea = dTotArea + dArea(i)
            Next
        End If

        ' Draw a cross at the center of gravity of each blob.

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)
        MIL.MblobDraw(MIL.M_DEFAULT, MilBlobResult, MilOverlayImage, MIL.M_DRAW_BOX, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT)   'MIL.M_DEFAULT

        Dim centeringInfo As CImageProcessCal.sCenterInfo

        If CimgProc.CalCenteringRateLeftTopCorner(minX, minY, maxX, maxY, centeringInfo) = True Then

            With outData
                .dArea = dTotArea
                .nNumOfBlob = TotalBlobs
                .centerRateX = centeringInfo.rateX
                .centerRateY = centeringInfo.rateY
                .blobCenterPosX = centeringInfo.posX
                .blobCenterPosY = centeringInfo.posY
            End With

            ' Free all allocations.
            MIL.MblobFree(MilBlobResult)
            MIL.MblobFree(MilBlobFeatureList)
            MIL.MbufFree(MilBinImage)

        Else

            With outData
                .dArea = dTotArea
                .nNumOfBlob = TotalBlobs
                .centerRateX = centeringInfo.rateX
                .centerRateY = centeringInfo.rateY
                .blobCenterPosX = centeringInfo.posX
                .blobCenterPosY = centeringInfo.posY
            End With


            ' Free all allocations.
            MIL.MblobFree(MilBlobResult)
            MIL.MblobFree(MilBlobFeatureList)
            MIL.MbufFree(MilBinImage)
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Save the ACF Infomation data"
    Public Overrides Function SaveGrabImage(ByVal localPath As String) As Boolean
        '   m_GrabImageData.Save(sSavePath, System.Drawing.Imaging.ImageFormat.Bmp)
        Dim bResult As Boolean
        '  Dim img As Bitmap = Nothing
        Dim imsibuffer() As Byte = Nothing
        Dim image As System.Drawing.Bitmap = Nothing

        bResult = cSVS.GetimgData(image, imsibuffer)

        image.Save(localPath, System.Drawing.Imaging.ImageFormat.Bmp)

        'Do
        '    If File.Exists("D:\McScience\Src\M7000_20170526_000\M7000\M7000\bin\Debug\SystemData\Image.bmp") = True Then
        '        Try
        '            File.Move("D:\McScience\Src\M7000_20170526_000\M7000\M7000\bin\Debug\SystemData\Image.bmp", localPath)
        '            File.Copy("D:\McScience\Src\M7000_20170526_000\M7000\M7000\bin\Debug\SystemData\Image.bmp", localPath)
        '        Catch ex As Exception

        '        End Try

        '        Exit Do
        '    End If
        'Loop


        Return True
    End Function

    Public Overrides Function SaveAFInfo(ByVal nCh As Integer, ByVal dDist() As Double, ByVal nArea() As Double, ByVal nGrayLevel() As Integer, ByVal nIntensity() As Integer, Optional ByVal dBias As Double = 0) As Boolean
        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")

        Dim sDate As String = "_" & cYear & cMonth & cDay & "_" & cHour & cMin & cSec

        '  Dim ret As Boolean
        Dim newfilepath As String = ""
        Dim iFileNum As Integer = 50

        Dim strMsg As String

        Try
            FileClose(iFileNum)
            newfilepath = sSaveDiratory & "CH" & Format(nCh, "000") & sDate & ".csv"

            FileOpen(iFileNum, newfilepath, OpenMode.Output) '파일을 열고

            strMsg = "Bias : " & "," & CStr(dBias)
            PrintLine(iFileNum, strMsg)

            strMsg = "Z Axis" & "," & "Cell Area(Pixel)" & "," & "Gray Level" & "," & "Intensity"
            PrintLine(iFileNum, strMsg)
            For i As Integer = 0 To dDist.Length - 1
                strMsg = CStr(dDist(i)) & "," & CStr(nArea(i)) & "," & CStr(nGrayLevel(i)) & "," & CStr(nIntensity(i))
                PrintLine(iFileNum, strMsg)
            Next

            FileClose(iFileNum)
        Catch ex As Exception
            FileClose(iFileNum)
            Return False
        End Try
        Return True

    End Function

#End Region

#Region "CCD Settings"

    Public Overrides Function GetAttributeList(ByRef sAttri() As String) As Boolean
        Return True
    End Function

    Public Overrides Function GetAttributeValue(ByRef attribute As String, ByRef dValue As Double, ByRef sValue As String, ByRef sCategory As String) As Boolean
        Return True
    End Function

    Public Overrides Function SetAttributeValue(ByVal attribute As String, ByVal value As Double, ByVal sValue As String, ByRef sCategory As String) As Boolean
        Return True
    End Function
    Public Sub WriteLogMsg(ByVal STR As String)
        Dim sr As StreamWriter '= New StreamWriter(g_sFilePath_SystemLog, True)

        Try
            sr = New StreamWriter(g_sFilePath_SystemLog, True)

            'FileOpen(4, g_sFilePath_SystemLog, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            sr.Close()
            ' FileClose(4)
        End Try

        Dim cYear As String = Now.Year 'Format(Now, "yyyy")
        Dim cMonth As String = Now.Month ' Format(Now, "MM")
        Dim cDay As String = Now.Day  'Format(Now, "dd")

        Dim cHour As String = Now.Hour '(Now, "HH")
        Dim cMin As String = Now.Minute ' Format(Now, "mm")
        Dim cSec As String = Now.Second 'Format(Now, "ss")

        STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

        ' PrintLine(4, STR)
        Try
            sr.WriteLine(STR)
        Catch ex As Exception

        End Try

        '파일에 쓰고
        ' FileClose(4)
        sr.Close()
    End Sub
#End Region
End Class
