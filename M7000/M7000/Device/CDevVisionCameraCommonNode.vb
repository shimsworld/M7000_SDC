Public Class CDevVisionCameraCommonNode
    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False

    Shared sSupportDeviceList() As String = New String() {"GC1290", "SVSCamera"}

    Protected m_displayPanel As System.Windows.Forms.Panel
    Protected m_procPanel As System.Windows.Forms.Panel
    Protected CimgProc As CImageProcessCal = New CImageProcessCal
    Protected m_orgImgData As sGrabImageData
    Protected m_processedImgData As sImageProcessedData

    Protected m_GrabMode As eGrabMode = eGrabMode.eSyncMode 'eGrabMode.eContinue_NoImageProcess
    Protected m_AnalMode As eCenteringAnalysisMode = eCenteringAnalysisMode.eCenterBlob

    Protected m_GrabState As eGrabState = eGrabState.eNowGrabbing


    Protected m_nCCDResolutionX As Integer = 1280
    Protected m_nCCDResolutionY As Integer = 960

    Protected m_nImgProcThresholdVal1 As Integer = 20
    Protected m_nImgProcThresholdVal2 As Integer = 100
    Protected m_nDefThresholdValue As Integer = 0

    Protected m_dDisplayRatioX_GrabImg As Double
    Protected m_dDisplayRatioY_GrabImg As Double

    Protected m_dDisplayRatioX_ProcImg As Double
    Protected m_dDisplayRatioY_ProcImg As Double

    Protected m_bCheckStart As Boolean
    Protected m_bIsConnectedCamera As Boolean = False
    Protected m_eBlobFilter As eBlobFilter

    Protected m_nMinBlobRadius As Integer = 1   '노이즈에 의한 잡티 제거

    Protected m_sCCDAttribute() As String

    Protected m_bIsLoaded As Boolean = False

    Protected m_SampleType As ucSampleInfos.eSampleType

    Protected sSaveDiratory As String = g_SPATH_SystemData
    Protected sSavePath As String = sSaveDiratory & "GrabImage.bmp"

    Protected m_GrabImageData As System.Drawing.Bitmap

    Public Enum eModel
        _GC1290
        _SVSCamera
    End Enum


#Region "Structure"
    Public Structure sGrabImageData
        Public rawHistoX As Array
        Public rawHistoY As Array
        Public processedHistoX As Array
        Public processedHistoY As Array
        Public nGrayLevelOfMaxIntensity As Integer
        Public nMaxIntensity As Integer
    End Structure

    Public Structure sImageProcessedData
        Public centerRateX As Double
        Public centerRateY As Double
        Public blobCenterPosX As Double
        Public blobCenterPosY As Double
        Public nNumOfBlob As Integer
        Public dArea As Double
    End Structure

    Public Enum eBlobFilter
        EXCLUDE_AREA_LESS_EQUAL_50
        EXCLUDE_AREA_OUT_RANGE_50_50000
        EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5
        EXCLUDE_AREA_OUT_RANGE_1000_50000
    End Enum

    Public Enum eGrabMode
        eContinue_NoImageProcess
        eSyncMode
    End Enum

    Public Enum eCenteringAnalysisMode
        eCenterBlob
        eCenterEdge
    End Enum

    Public Enum eGrabState
        eIDle
        eNowGrabbing
        eCompletedGrab
        eImageAnalysising
        eCompletedImageAnalysis
        eFailed_Image_Grab
    End Enum
#End Region

#Region "Properties"

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property


    Public Property Model As eModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eModel)
            m_MyModel = value
        End Set
    End Property

    Public Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property


    Public Property CCDResolutionX() As Integer
        Get
            Return m_nCCDResolutionX
        End Get
        Set(ByVal Value As Integer)
            m_nCCDResolutionX = Value
        End Set
    End Property

    Public Property CCDResolutionY() As Integer
        Get
            Return m_nCCDResolutionY
        End Get
        Set(ByVal Value As Integer)
            m_nCCDResolutionY = Value
        End Set
    End Property


    Public Property DefaultThresholdValue() As Integer
        Get
            Return m_nDefThresholdValue
        End Get
        Set(ByVal Value As Integer)

            If Value < 0 Or Value > 255 Then
                MsgBox("Threshold 값은 0 ~ 255 사이의 값이어야 합니다.")
                Exit Property
            Else
                m_nDefThresholdValue = Value
            End If

        End Set
    End Property

    Public Property ThresholdValue1() As Integer
        Get
            Return m_nImgProcThresholdVal1
        End Get
        Set(ByVal Value As Integer)

            If Value < 0 Or Value > 255 Then
                MsgBox("Threshold 값은 0 ~ 255 사이의 값이어야 합니다.")
                Exit Property
            Else
                m_nImgProcThresholdVal1 = Value
            End If

        End Set
    End Property

    Public Property ThresholdValue2() As Integer
        Get
            Return m_nImgProcThresholdVal2
        End Get
        Set(ByVal Value As Integer)

            If Value < 0 Or Value > 255 Then
                MsgBox("Threshold 값은 0 ~ 255 사이의 값이어야 합니다.")
                Exit Property
            Else
                m_nImgProcThresholdVal2 = Value
            End If

        End Set
    End Property

    Public ReadOnly Property IsConnectedToCamera() As Boolean
        Get
            Return m_bIsConnectedCamera
        End Get
    End Property

    Public Property MinBlobRadius() As Integer
        Get
            Return m_nMinBlobRadius
        End Get
        Set(ByVal Value As Integer)
            m_nMinBlobRadius = Value
        End Set
    End Property

    Public ReadOnly Property GrabState() As eGrabState
        Get
            Return m_GrabState
        End Get
    End Property

    Public Property BlobFilter() As eBlobFilter
        Get
            Return m_eBlobFilter
        End Get
        Set(ByVal Value As eBlobFilter)
            m_eBlobFilter = Value
        End Set
    End Property

    Public Property GrabMode() As eGrabMode
        Get
            Return m_GrabMode
        End Get
        Set(ByVal Value As eGrabMode)
            m_GrabMode = Value
        End Set
    End Property

    Public Property AnalysisMode() As eCenteringAnalysisMode
        Get
            Return m_AnalMode
        End Get
        Set(ByVal value As eCenteringAnalysisMode)
            m_AnalMode = value
        End Set
    End Property

    Public ReadOnly Property OriginalImgData
        Get
            Return m_orgImgData
        End Get
    End Property

    Public ReadOnly Property ProcImgData As sImageProcessedData
        Get
            Return m_processedImgData
        End Get
    End Property

    Public WriteOnly Property SampleType As ucSampleInfos.eSampleType
        Set(ByVal value As ucSampleInfos.eSampleType)
            m_SampleType = value
        End Set
    End Property

#End Region


#Region "Creator, Disoposer And Init"

    Public Sub New(ByVal dispPanel As System.Windows.Forms.Panel, ByVal procPanel As System.Windows.Forms.Panel)
        m_bIsConnected = False
    End Sub

    Public Overridable Sub Dispose()

    End Sub

    Public Overridable Function InitAllied(ByRef errMsg As String) As Boolean
        Return False
    End Function

    Public Overridable Sub UninitAllied()

    End Sub
#End Region

#Region "Control Function"
    Public Overridable Sub DispControlFit()

    End Sub

    Public Overridable Function GrabStart() As Boolean
        Return False
    End Function

    Public Overridable Sub GrabStop()
        m_bCheckStart = False
    End Sub

    Public Overridable Sub GrabDisplay()

    End Sub

    Public Overridable Function AnalysisGrabImage(ByVal imageData() As Byte) As Boolean
        Return False
    End Function

    Public Overridable Function SaveAFInfo(ByVal nCh As Integer, ByVal dDist() As Double, ByVal nArea() As Double, ByVal nGrayLevel() As Integer, ByVal nIntensity() As Integer, Optional ByVal dBias As Double = 0) As Boolean
        Return False
    End Function

    Public Overridable Function SaveGrabImage(ByVal sSavePath As String) As Boolean
        Return False
    End Function

    Public Overridable Function GetAttributeList(ByRef sAttri() As String) As Boolean
        Return True
    End Function

    Public Overridable Function GetAttributeValue(ByRef attribute As String, ByRef dValue As Double, ByRef sValue As String, ByRef sCategory As String) As Boolean
        Return True
    End Function

    Public Overridable Function SetAttributeValue(ByVal attribute As String, ByVal value As Double, ByVal sValue As String, ByRef sCategory As String) As Boolean
        Return True
    End Function

    Public Overridable Function Reconnection() As Boolean
        Return True
    End Function
    Public Overridable Sub TriggerSyncModeGrab()

    End Sub
#End Region




End Class
