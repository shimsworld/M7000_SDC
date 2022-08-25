Imports System
Imports System.Threading
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Compatibility
Imports Matrox.MatroxImagingLibrary
Imports PvNET

Public Class CDevGC1290
    Inherits CDevVisionCameraCommonNode


#Region "Define"

    Dim Camera As New CKid.tCamera

    '***************************************************************************************8
    Dim MilApplication As MIL_ID = MIL.M_NULL ' Application identifier.
    Dim MilSystem As MIL_ID = MIL.M_NULL ' System identifier.
    Dim MilDisplay As MIL_ID = MIL.M_NULL ' Display identifier.
    Dim MilDisplay_Proc As MIL_ID = MIL.M_NULL
    Dim MilImage As MIL_ID = MIL.M_NULL ' Image buffer identifier.
    Dim MilAnalysisImage As MIL_ID = MIL.M_NULL

    Private Const HIST_NUM_INTENSITIES As Integer = 256
    Dim MilOverlayImage As MIL_ID = MIL.M_NULL ' Overlay image.
#End Region


#Region "Creator, Disoposer And Init"

    Public Sub New(ByVal dispPanel As System.Windows.Forms.Panel, ByVal procPanel As System.Windows.Forms.Panel)
        MyBase.new(dispPanel, procPanel)

        m_MyModel = eModel._GC1290
        m_displayPanel = dispPanel
        m_procPanel = procPanel
        init()
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


    Public Overrides Sub Dispose()
        'MIL(Free)

        If m_bIsConnectedCamera = True Then
            MIL.MbufFree(MilImage)
            MIL.MbufFree(MilAnalysisImage)
        End If

        '  MIL.MimFree(MilOverlayImage)

        ' Thread.Sleep(1000)
        MIL.MdispFree(MilDisplay)
        MIL.MdispFree(MilDisplay_Proc)
        MIL.MsysFree(MilSystem)
        MIL.MappFree(MilApplication)
        'MIL.MsysFree(MilSystem)
        'MIL.MdispFree(MilDisplay)
        ' MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MIL.M_NULL)

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

    Public Overrides Function InitAllied(ByRef errMsg As String) As Boolean

        Dim rst As tErr
        '   Dim coverter As System.IConvertible
        '   Dim strRst As String
        '  Dim strRst1 As String
        Dim nRst As Integer
        Dim nRst2 As Integer
        '  Dim n As UInt32

        rst = CPv.Initialize()

        nRst = Convert.ToInt32(rst)

        nRst2 = Convert.ToInt32(tErr.eErrSuccess)

        If nRst = nRst2 Then
            If CKid.WaitForCamera() = False Then

                CPv.UnInitialize()
                errMsg = "Can not found the camera"
                Return False
            End If


            If CKid.CameraGet(Camera) Then

                If CKid.CameraOpen(Camera) Then

                    errMsg = "camera {0} open " & Format(Camera.UID, "#####0")
                    If CKid.CameraSetup(Camera) Then
                    Else
                        errMsg = "failed to setup the camera"
                    End If
                Else
                    errMsg = "camera {0} failed to be open " & Format(Camera.UID, "#########0")
                End If
            Else
                errMsg = "failed to get a camera"
            End If
        Else
            errMsg = "failed to initialize the API : "
        End If

        m_bIsConnectedCamera = True
        Return True
    End Function

    Public Overrides Sub UninitAllied()
        If m_bIsConnectedCamera = True Then
            CKid.CameraClose(Camera)
            CPv.UnInitialize()
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
        Dim imgSize As System.Drawing.Size

        imgWidth = m_nCCDResolutionX ' milImage.FileInquire(sSavePath, Matrox.ActiveMIL.ImParameterConstants.imSizeX)
        imgHigh = m_nCCDResolutionY 'milImage.FileInquire(sSavePath, Matrox.ActiveMIL.ImParameterConstants.imSizeY)

        imgSize.Height = imgHigh
        imgSize.Width = imgWidth

        ' fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "Scheduler Start")

        If CKid.CameraSetup(Camera) Then
            Do While m_bCheckStart = True
                If CKid.CameraSnap(Camera) Then

                    Do

                        If m_bCheckStart = False Then Exit Do

                        If m_GrabMode = eGrabMode.eContinue_NoImageProcess Then
                            Exit Do
                        ElseIf m_GrabMode = eGrabMode.eSyncMode Then
                            Application.DoEvents()
                            Thread.Sleep(10)
                            If m_GrabState = eGrabState.eIDle Then
                                m_GrabState = eGrabState.eNowGrabbing
                                Exit Do
                            End If
                        End If

                    Loop


                    Try

                        If imgData Is Nothing = False Then
                            imgData.Dispose() '메모리 해제 안하면, C# 코드에 영향을 줌 따라서 꼭 해제 해야함.
                        End If
                        CKid.FrameSave(Camera)
                        imgData = CKid.gBitmapData

                        ' imgData.Save(sSavePath, System.Drawing.Imaging.ImageFormat.Bmp)   ', myEncoderParameters.Param(0).Enco

                        m_GrabImageData = imgData

                        '  MIL.MbufLoad(sSavePath, MilImage)
                        MIL.MbufPut(MilImage, Camera.Buffer)
                        MIL.MdispZoom(MilDisplay, m_dDisplayRatioX_GrabImg, m_dDisplayRatioY_GrabImg)

                    Catch ex As Exception
                        MsgBox(ex.Message())
                    End Try

                    If m_GrabMode = eGrabMode.eSyncMode Then

                        If AnalysisGrabImage(Camera.Buffer) = False Then
                            m_GrabState = eGrabState.eFailed_Image_Grab
                        End If

                    End If


                    m_GrabState = eGrabState.eCompletedGrab
                Else
                    m_GrabState = eGrabState.eFailed_Image_Grab
                End If

                Thread.Sleep(10)

            Loop

        Else
            'ListBox1.Items.Insert(0, "failed to setup the camera")
        End If

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
            If BlobInfoAnalysisOfCell(imgProcThresholdVal, m_processedImgData) = False Then    'imgProcThresholdVal
                MIL.MimFree(HistResult)
                Return False
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

    Private Shared ReadOnly CONTOUR_DRAW_COLOR As Integer = MIL.M_COLOR_GREEN
    Private Shared ReadOnly CONTOUR_LABEL_COLOR As Integer = MIL.M_COLOR_RED
    Private Const CONTOUR_MAX_RESULTS As Integer = 5
    Private Const CONTOUR_MAXIMUM_ELONGATION As Double = 0.8

    Dim CogX As Double
    Dim CogY As Double
    Dim Area As Double
    Dim MinX As Double
    Dim MaxX As Double
    Dim MinY As Double
    Dim MaxY As Double

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
        MIL.MbufRestore(MilAnalysisImage, MilSystem, MilImage)
        MIL.MdispSelect(MilDisplay, MilImage)

        ' Allocate a graphic list to hold the subpixel annotations to draw.
        MIL.MgraAllocList(MilSystem, MIL.M_DEFAULT, GraphicList)

        ' Associate the graphic list to the display for annotations.
        MIL.MdispControl(MilDisplay, MIL.M_ASSOCIATED_GRAPHIC_LIST_ID, GraphicList)

        ' Pause to show the original image.
        Console.Write(Constants.vbLf + "EDGE MODULE:" + Constants.vbLf)
        Console.Write("------------" + Constants.vbLf + Constants.vbLf)
        Console.Write("This program determines the outer seal diameters in the displayed image " + Constants.vbLf)
        Console.Write("by detecting and analyzing contours with the Edge Finder module." + Constants.vbLf)
        Console.Write("Press <Enter> to continue." + Constants.vbLf + Constants.vbLf)
        Console.ReadKey()

        ' Allocate a Edge Finder context.
        MIL.MedgeAlloc(MilSystem, MIL.M_CONTOUR, MIL.M_DEFAULT, MilEdgeContext)

        ' Allocate a result buffer.
        MIL.MedgeAllocResult(MilSystem, MIL.M_DEFAULT, MilEdgeResult)

        ' Enable features to compute.
        MIL.MedgeControl(MilEdgeContext, MIL.M_MOMENT_ELONGATION, MIL.M_ENABLE)
        MIL.MedgeControl(MilEdgeContext, MIL.M_FERET_MEAN_DIAMETER + MIL.M_SORT1_DOWN, MIL.M_ENABLE)

        ' Calculate edges and features.
        MIL.MedgeCalculate(MilEdgeContext, MilImage, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MilEdgeResult, MIL.M_DEFAULT)

        ' Get the number of edges found.
        MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_NUMBER_OF_CHAINS + MIL.M_TYPE_MIL_INT, NumEdgeFound)

        ' Draw edges in the source image to show the result.
        MIL.MgraColor(MIL.M_DEFAULT, EdgeDrawColor)
        MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        ' Pause to show the edges.
        Console.Write("{0} edges were found in the image." + Constants.vbLf, NumEdgeFound)
        Console.Write("Press <Enter> to continue." + Constants.vbLf + Constants.vbLf)
        Console.ReadKey()

        ' Exclude elongated edges.
        MIL.MedgeSelect(MilEdgeResult, MIL.M_EXCLUDE, MIL.M_MOMENT_ELONGATION, MIL.M_LESS, CONTOUR_MAXIMUM_ELONGATION, MIL.M_NULL)

        ' Exclude inner chains.
        MIL.MedgeSelect(MilEdgeResult, MIL.M_EXCLUDE, MIL.M_INCLUDED_EDGES, MIL.M_INSIDE_BOX, MIL.M_NULL, MIL.M_NULL)

        ' Draw remaining edges and their index to show the result.
        MIL.MgraClear(MIL.M_DEFAULT, GraphicList)
        MIL.MgraColor(MIL.M_DEFAULT, EdgeDrawColor)
        MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        ' Pause to show the results.
        Console.Write("Elongated edges and inner edges of each seal were removed." + Constants.vbLf)
        Console.Write("Press <Enter> to continue." + Constants.vbLf + Constants.vbLf)
        Console.ReadKey()

        ' Get the number of edges found.
        MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_NUMBER_OF_CHAINS + MIL.M_TYPE_MIL_INT, NumResults)

        ' If the right number of edges were found.
        If (NumResults >= 1) AndAlso (NumResults <= CONTOUR_MAX_RESULTS) Then
            ' Draw the index of each edge.
            MIL.MgraColor(MIL.M_DEFAULT, LabelDrawColor)
            MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, GraphicList, MIL.M_DRAW_INDEX, MIL.M_DEFAULT, MIL.M_DEFAULT)

            ' Get the mean Feret diameters.
            MIL.MedgeGetResult(MilEdgeResult, MIL.M_DEFAULT, MIL.M_FERET_MEAN_DIAMETER, MeanFeretDiameter)

            ' Print the results.
            Console.Write("Mean diameter of the {0} outer edges are:" + Constants.vbLf + Constants.vbLf, NumResults)
            Console.Write("Index   Mean diameter " + Constants.vbLf)
            For i = 0 To CType(NumResults - 1, Integer)
                Console.Write("{0,-11}{1,-13:0.00}" + Constants.vbLf, i, MeanFeretDiameter(i))
            Next i
        Else
            Console.Write("Edges have not been found or the number of found edges is greater than" + Constants.vbLf)
            Console.Write("the specified maximum number of edges !" + Constants.vbLf + Constants.vbLf)
        End If

        ''''

        MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_X, CogX)
        MIL.MedgeGetResult(MilEdgeResult, 0, MIL.M_CENTER_OF_GRAVITY_Y, CogY)

        Console.Write("X/Y Center Position" + Constants.vbLf)
        Console.Write(CogX & " / " & CogY)
        Console.Write(Constants.vbLf)

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

        '''''

        ' Wait for a key press.
        Console.Write(Constants.vbLf + "Press <Enter> to end." + Constants.vbLf)
        Console.ReadKey()

        ' Free MIL objects.
        MIL.MgraFree(GraphicList)
        MIL.MbufFree(MilImage)
        MIL.MedgeFree(MilEdgeContext)
        MIL.MedgeFree(MilEdgeResult)

        ' Free defaults.
        MIL.MappFreeDefault(MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MIL.M_NULL)



        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      
        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MdispControl(MilDisplay_Proc, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)
        MIL.MedgeDraw(MIL.M_DEFAULT, MilEdgeResult, MilOverlayImage, MIL.M_DRAW_BOX, MIL.M_INCLUDED_BLOBS, MIL.M_DEFAULT)   'MIL.M_DEFAULT

        Dim centeringInfo As CImageProcessCal.sCenterInfo

        outData.blobCenterPosX = CogX
        outData.blobCenterPosY = CogY
        'If CimgProc.CalCenteringRate(minX, minY, maxX, maxY, centeringInfo) = True Then

        '    With outData
        '        .dArea = dTotArea
        '        .nNumOfBlob = TotalBlobs
        '        .centerRateX = centeringInfo.rateX
        '        .centerRateY = centeringInfo.rateY
        '        .blobCenterPosX = centeringInfo.posX
        '        .blobCenterPosY = centeringInfo.posY
        '    End With

        '    ' Free all allocations.
        '    MIL.MblobFree(MilBlobResult)
        '    MIL.MblobFree(MilBlobFeatureList)
        '    MIL.MbufFree(MilBinImage)

        'Else

        '    With outData
        '        .dArea = dTotArea
        '        .nNumOfBlob = TotalBlobs
        '        .centerRateX = centeringInfo.rateX
        '        .centerRateY = centeringInfo.rateY
        '        .blobCenterPosX = centeringInfo.posX
        '        .blobCenterPosY = centeringInfo.posY
        '    End With


        '    ' Free all allocations.
        '    MIL.MedgeFree(MilEdgeResult)
        '    Return False
        'End If

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
        Const MIN_BLOB_AREA As Integer = 50
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

        Dim nNumber As UInt32

        Dim Attributes As IntPtr

        If Convert.ToInt32(CPv.AttrList(Camera.Handle, Attributes, nNumber)) = Convert.ToInt32(tErr.eErrSuccess) Then

            ReDim m_sCCDAttribute(Convert.ToInt32(nNumber) - 1)
            Dim index As Integer
            For index = 0 To Convert.ToInt32(nNumber) - 1
                Dim ptr As IntPtr = Marshal.ReadIntPtr(Attributes, IntPtr.Size * index)
                ' ListBox2.Items.Add(Marshal.PtrToStringAnsi(ptr))
                m_sCCDAttribute(index) = Marshal.PtrToStringAnsi(ptr)
                sAttri = m_sCCDAttribute.Clone()
            Next index
        Else
            Return False
        End If

        Return True
    End Function

    Public Overrides Function GetAttributeValue(ByRef attribute As String, ByRef dValue As Double, ByRef sValue As String, ByRef sCategory As String) As Boolean
        Dim Detail As tAttributeInfo = New tAttributeInfo

        If Convert.ToInt32(CPv.AttrInfo(Camera.Handle, attribute, Detail)) <> Convert.ToInt32(tErr.eErrSuccess) Then
            Return False
        End If

        sCategory = Detail.Category

        Select Case Convert.ToInt32(Detail.Datatype)

            Case Is = tDatatype.eDatatypeCommand

                sCategory = "Command"
                sCategory = "0"

            Case Is = tDatatype.eDatatypeString 'ePvDatatypeString

                Dim sTempVal As System.Text.StringBuilder = New System.Text.StringBuilder(" ", 128)
                Dim nLen As UInteger = 0

                sCategory = "String"

                If CPv.AttrStringGet(Camera.Handle, attribute, sTempVal, 128, nLen) = tErr.eErrSuccess Then
                    sValue = sTempVal.ToString
                Else
                    sValue = "Error!"
                End If

            Case Is = tDatatype.eDatatypeEnum 'ePvDatatypeEnum

                Dim EValue As System.Text.StringBuilder = New System.Text.StringBuilder(" ", 128)
                Dim nLen As UInteger


                sCategory = "Enumerate"

                If CPv.AttrEnumGet(Camera.Handle, attribute, EValue, 128, nLen) = tErr.eErrSuccess Then
                    sValue = EValue.ToString
                Else
                    sValue = "Error!"
                End If

            Case Is = tDatatype.eDatatypeUint32

                Dim UValue As UInt32

                If Convert.ToInt32(CPv.AttrUint32Get(Camera.Handle, attribute, UValue)) = Convert.ToInt32(tErr.eErrSuccess) Then
                    dValue = Convert.ToInt32(UValue)
                Else
                    dValue = "0"
                End If

            Case Is = tDatatype.eDatatypeFloat32

                Dim FValue As Single

                If Convert.ToInt32(CPv.AttrFloat32Get(Camera.Handle, attribute, FValue)) = Convert.ToInt32(tErr.eErrSuccess) Then
                    dValue = CDbl(FValue)
                Else
                    dValue = 0
                End If

        End Select

        Return True

    End Function

    Public Overrides Function SetAttributeValue(ByVal attribute As String, ByVal value As Double, ByVal sValue As String, ByRef sCategory As String) As Boolean
        Dim Detail As tAttributeInfo = New tAttributeInfo
        If Convert.ToInt32(CPv.AttrInfo(Camera.Handle, attribute, Detail)) <> Convert.ToInt32(tErr.eErrSuccess) Then
            Return False
        End If

        sCategory = Detail.Category

        Select Case Convert.ToInt32(Detail.Datatype)

            Case Is = tDatatype.eDatatypeCommand

                sCategory = "Command"

            Case Is = tDatatype.eDatatypeString 'ePvDatatypeString

                'Dim SValue As StringBuilder

                'Label6.Text = "String"

                'If PV.AttrStringGet(Camera.Handle, ListBox2.Text, SValue) = tErr.eErrSuccess Then
                '    Label4.Text = SValue.ToString
                'Else
                '    Label4.Text = "Error!"
                'End If

            Case Is = tDatatype.eDatatypeEnum 'ePvDatatypeEnum

                'Dim EValue As String
                'Label6.Text = "Enumerate"

                If Convert.ToInt32(CPv.AttrEnumSet(Camera.Handle, attribute, sValue)) = Convert.ToInt32(tErr.eErrSuccess) Then

                Else
                    Return False
                End If

                'If PV.AttrEnumGet(Camera.Handle, ListBox2.Text, EValue) = tErr.eErrSuccess Then
                '    Label4.Text = EValue
                'Else
                '    Label4.Text = "Error!"
                'End If

            Case Is = tDatatype.eDatatypeUint32

                Dim UValue As UInt32 = Convert.ToUInt32(value)



                If Convert.ToInt32(CPv.AttrUint32Set(Camera.Handle, attribute, UValue)) = Convert.ToInt32(tErr.eErrSuccess) Then

                Else
                    Return False
                End If

            Case Is = tDatatype.eDatatypeFloat32

                Dim FValue As Single = Convert.ToSingle(value)

                If Convert.ToInt32(CPv.AttrFloat32Set(Camera.Handle, attribute, FValue)) = Convert.ToInt32(tErr.eErrSuccess) Then

                Else
                    Return False
                End If

        End Select

        Return True

    End Function

#End Region

End Class
