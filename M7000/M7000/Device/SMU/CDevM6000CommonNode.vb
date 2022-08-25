Public Class CDevM6000CommonNode

    Protected m_MyModel As eModel

    Dim m_ID As Integer   '객체 식별 코드

    Protected m_bIsConnected As Boolean = False
    Public m_IVLState() As CDevM6000CommonNode.eIVLState
    Protected b_calread() As Boolean
    Public m_sRange() As sBoardRangeInfo

    Public Enum eModel
        _PMX
        _DCX
    End Enum

    Enum eMode
        eCC = 0
        eCV = 1
        ePC = 2
        ePV = 3
        ePCV = 4
    End Enum

    Enum eONOFF
        eOFF = 0
        eON = 1
    End Enum

    Public Enum eIVLState
        _IDLE = 0
        _RUN = 1
        _STOP = 2
    End Enum

    Enum eRetBiasSet
        _OK
        _SET_INFO_Failure
        _SET_MODE_Failure
        _SET_VALUE_Failure
        _SET_SWITCH_Failure
        _CALIBRATION_FACTOR_IS_NOTHING
    End Enum

    Public Enum eCurrentRange
        _RANGE_1 = 0
        _RANGE_2 = 1
    End Enum

    Public Enum ePhotocurrentRange
        _RANGE_1 = 0
        _RANGE_2 = 1
        _RANGE_3 = 2
    End Enum

    Public Enum eCalibrationEnable
        _ALL_DISABLE = 0
        _OUTPUT_ENABLE = 1
        _INPUT_ENABLE
        _ALL_ENABLE
    End Enum

    Public Enum eProbeMode
        _4WIRE = 0
        _2WIRE = 1
    End Enum
    Public Enum eAutoRangeMode
        _On = 0
        _OFF = 1
    End Enum
    Public Enum eSemiAutoMode
        _On = 0
        _OFF = 1
    End Enum

#Region "Structure"
    Public Structure sSettingParams
        Dim source As sBias
        Dim bOutputState As eONOFF
    End Structure

    Public Structure sMeasParams
        Dim Mode As eMode
        Dim dVoltage_Bias As Double
        Dim dVoltage_Amplitude As Double
        Dim dCurrent_Bias As Double
        Dim dCurrent_Amplitude As Double
        Dim dPDCurrent As Double
        Dim dLuminance_Candela As Double
        Dim sIVLData() As CDevM6000CommonNode.sIVLData
    End Structure

    Structure sBias
        Dim Mode As eMode
        Dim dBiasValue As Double
        Dim dAmplitude As Double
        Dim Pulse As sPulse
        Dim nConstantBrightnessMode As Boolean
    End Structure

    Structure sPulse
        Dim dFrequency As Double
        Dim dDuty As Double
    End Structure

    Structure sBoardRangeInfo
        Dim dMaxVolt As Double
        Dim dMinVolt As Double
        Dim dMaxCurr() As Double
        Dim dMinCurr() As Double
        Dim dMaxPhoto() As Double
        Dim dMinPhoto() As Double
    End Structure

    Public Structure sIVLData
        Dim dTime As Double
        Dim dVoltage As Double
        Dim dCurrent As Double
        Dim dPhoto As Double
    End Structure

#End Region

#Region "Property"
    Public Overridable ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overridable ReadOnly Property Settings() As sSettingParams()
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property MeasuredDatas() As sMeasParams()
        Get
            Return Nothing
        End Get
    End Property

    Public Property IVLState As CDevM6000CommonNode.eIVLState()
        Get
            Return m_IVLState
        End Get
        Set(value As CDevM6000CommonNode.eIVLState())
            m_IVLState = value
        End Set
    End Property

    Public Property RangeInfo As CDevM6000CommonNode.sBoardRangeInfo()
        Get
            Return m_sRange
        End Get
        Set(value As CDevM6000CommonNode.sBoardRangeInfo())
            m_sRange = value
        End Set
    End Property

    Public Overridable ReadOnly Property CalRead As Boolean()
        Get
            Return b_calread
        End Get
    End Property
#End Region

#Region "Communication"

    Public Overridable Function Connection(ByVal Config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function

    Public Overridable Function Connection() As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub

#End Region


#Region "Function"
    Public Overridable Function ReadCalibrationData() As Boolean
        Return False
    End Function

    Public Overridable Function ACK() As Boolean
        Return False
    End Function
    Public Overridable Function InitializeM6000(ByVal nCh As Integer, ByVal settings As frmChannelRangeSetttings.sRangeSettings, ByVal biassetting As sSettingParams) As Boolean
        Return False
    End Function
    Public Overridable Function InitializeM6000IVL(ByVal nCh As Integer, ByVal settings As frmChannelRangeSetttings.sRangeSettings) As Boolean
        Return False
    End Function

    'Public Function Reset(ByVal nCh As Integer) As Boolean
    '    Return False
    'End Function

    Public Overridable Function CellON(ByVal nCh As Integer) As Boolean
        Return False
    End Function

    Public Overridable Function CellOFF(ByVal nCh As Integer) As Boolean
        Return False
    End Function

    'PMX
    Public Overridable Function BiasSettings(ByVal nCh As Integer, ByVal in_Mode As eMode, ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFreq As Double, ByVal dDuty As Double, ByRef retSetinfo As eRetBiasSet) As Boolean
        Return False
    End Function

    'DCX
    Public Overridable Function BiasSettings(ByVal nCh As Integer, ByVal in_Mode As eMode, ByVal dBias As Double) As Boolean
        Return False
    End Function

    Public Overridable Function BiasSettings(ByVal nCh As Integer, ByVal Settings As sSettingParams, ByRef retSetinfo As eRetBiasSet) As Boolean
        Return False
    End Function

    Public Overridable Function Measurement(ByVal nCh As Integer, ByVal in_Mode As eMode, _
                                ByRef measV As String, ByRef measI As String, ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean
        Return False
    End Function

    Public Overridable Function Measurement(ByVal nCh As Integer, ByVal in_Mode As eMode, _
                                 ByRef measHV As String, ByRef measLV As String, ByRef measHI As String, ByRef measLI As String, _
                                  ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean

        Return False
    End Function

    Public Overridable Function Measurement(ByVal nCh As Integer, _
                            ByRef measHV As String, ByRef measLV As String, ByRef measHI As String, ByRef measLI As String, _
                             ByRef meas_PDCurr As String, ByRef nLimitChk As String, ByRef ChkBoardError As Boolean) As Boolean
        Return False
    End Function

    'Public Overridable Function IVLMeasureStart(ByVal nCh As Integer, ByVal sIVLSet As ucDispRcpCellIVL.sCellIVLSettings) As Boolean
    '    Return False
    'End Function

    Public Overridable Function IVLGetData(ByVal nCh As Integer, ByVal nCntPoint As Integer, ByRef sRetIVLData() As CDevM6000CommonNode.sIVLData) As Boolean
        Return False
    End Function

    'Public Overridable Function MeasureIVL(ByVal nCh As Integer, ByVal sIVLSet As ucDispRcpCellIVL.sCellIVLSettings, ByRef sRetIVLData() As CDevM6000CommonNode.sIVLData) As Boolean
    '    Return False
    'End Function

    Public Overridable Function SetIVLState(ByVal nCh As Integer, ByVal nState As CDevM6000CommonNode.eIVLState) As Boolean
        Return False
    End Function

    Public Overridable Function GetIVLState(ByVal nCh As Integer, ByRef nState As CDevM6000CommonNode.eIVLState) As Boolean
        Return False
    End Function

    Public Overridable Function Set_Calibration_Eanble(ByVal nCh As Integer, ByVal eCalEnable As eCalibrationEnable) As Boolean
        Return False
    End Function

    '2w/4w
    Public Overridable Function Set_ProbeMode(ByVal nCh As Integer, ByVal eMode As eProbeMode) As Boolean
        Return False
    End Function

    'Photo Range 1-3
    Public Overridable Function Set_PhotoRange(ByVal nCh As Integer, ByVal ePDRange As ePhotocurrentRange) As Boolean
        Return False
    End Function

    'Current Range 1-2
    Public Overridable Function Set_CurrentRange(ByVal nCh As Integer, ByVal eCurrRange As eCurrentRange) As Boolean
        Return False
    End Function

    'Over Value (Limit)
    Public Overridable Function Set_OverCurrentValue(ByVal nCh As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Return False
    End Function
    Public Overridable Function Set_OverVoltageValue(ByVal nCh As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Return False
    End Function

    'Range Value Set
    Public Overridable Function Set_RangePhotoCurrent(ByVal nBrdNum As Integer, ByVal eRange As ePhotocurrentRange, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Return False
    End Function

    Public Overridable Function Get_BoardRangeInfo(ByVal nBrdNum As Integer, ByRef sRetBoardRangeInfo As sBoardRangeInfo) As Boolean
        Return False
    End Function

    Public Overridable Function Set_RangeCurrent(ByVal nBrdNum As Integer, ByVal eRange As eCurrentRange, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Return False
    End Function

    Public Overridable Function Set_RangeVoltage(ByVal nBrdNo As Integer, ByVal dMin As Double, ByVal dMax As Double) As Boolean
        Return False
    End Function

    Public Overridable Function Set_CalibrationSave(ByVal nCh As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function Reset(ByVal nch As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function Set_AutoRange_PD(ByVal nch As Integer, ByVal Mode As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function Set_AutoRange_Current(ByVal nch As Integer, ByVal Mode As Integer) As Boolean
        Return False
    End Function
#End Region

End Class
