Imports CCommLib
Public Class CDevSMUCommonNode

#Region "Define"

    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CComCommonNode.sCommInfo
    Protected m_CommStatus As CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False
    Shared sSupportDeviceList() As String = New String() {"K236", "K237", "K238", "K2400", "K2410", "K2420", "K2425", "K2430", "K2440", "K2450", "K2601", "K2602", "K2635", "K2636", "M6100"}

    Public Enum eModel
        KEITHLEY_K236
        KEITHLEY_K237
        kEITHLEY_K238
        KEITHLEY_K2400
        KEITHLEY_K2410
        KEITHLEY_K2420
        KEITHLEY_K2425
        KEITHLEY_K2430
        KEITHLEY_K2440
        KEITHLEY_K2450
        KEITHLEY_K2601
        KEITHLEY_K2602
        KEITHLEY_K2635
        KEITHLEY_K2636
        MCSCIENCE_M6100
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

    Public Property Config As CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property


#End Region


#Region "Structure"
    Public Structure sRangeAndIntegTime  ' IntegTimeList은 K23x에만 있고 다른 나머지는 입력 값임.
        Dim sCurrentListName() As String
        Dim sVoltageListName() As String
        Dim dCurrentListValue() As Double
        Dim dVoltageListValue() As Double
        Dim sIntegTimeListName() As String
        Dim sSourceModeName() As String
    End Structure
#End Region

#Region "Creator, Disoposer And Init"

    Public Sub New()
        m_bIsConnected = False
    End Sub

#End Region

#Region "Communication Functions"

    Public Overridable Function Connection(ByVal config As CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function


    Public Overridable Sub Disconnection()

    End Sub

#End Region


#Region "Control Functions"

    ''' <summary>
    ''' Init Keithley Settings And Cell On
    ''' </summary>
    ''' <param name="settings"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function InitializeSweep(ByVal settings As ucKeithleySMUSettings.sKeithley) As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Init McScienceM6100 Settings And Cell On
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function InitializeSweep(ByVal settings As CDevM6100.sM6100Setting, ByVal ch As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Bias Setting
    ''' </summary>
    ''' <param name="dBias"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetBias(ByVal dBias As Double) As Boolean
        Return False
    End Function



    ''' <summary>
    ''' Bias Setting(M6100_PCV)
    ''' </summary>
    ''' <param name="dBias"></param>
    ''' <param name="dAmplitude"></param>
    ''' <param name="dFrequency"></param>
    ''' <param name="dduty"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetBias(ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFrequency As Double, ByVal dduty As Double) As Boolean
        Return False
    End Function

    ' ''' <summary>
    ' '''  Keithley Pulse Parameter가 추가되어짐.
    ' ''' </summary>
    ' ''' <param name="dBias"></param>
    ' ''' <param name="dAmplitude"></param>
    ' ''' <param name="dPulseOnTime"></param>
    ' ''' <param name="dPulseOffTime"></param>
    ' ''' <param name="NumOfPulse"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Overridable Function SetBias(ByVal dBias As Double, Optional ByVal dAmplitude As Double = 0, Optional ByVal dPulseOnTime As Double = 0, Optional ByVal dPulseOffTime As Double = 0, Optional ByVal NumOfPulse As Double = 0) As Boolean
    '    Return False
    'End Function

    ''' <summary>
    ''' Data Read (Keithley, M6100)
    ''' </summary>
    ''' <param name="dVoltage"></param>
    ''' <param name="Current"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Measure(ByRef dVoltage As Double, ByRef Current As Double) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Data Read (M6100_PCV)
    ''' </summary>
    ''' <param name="dHVoltage"></param>
    ''' <param name="dHCurrent"></param>
    ''' <param name="dLVoltage"></param>
    ''' <param name="dLCurrent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Measure(ByRef dHVoltage As Double, ByRef dHCurrent As Double, ByRef dLVoltage As Double, ByRef dLCurrent As Double) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Reset And Cell Off
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function FinalizeSweep() As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Cell On
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function OutputOn() As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Cell Off
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function OutputOff() As Boolean
        Return False
    End Function
    ''' <summary>
    ''' Init Keithley Settings
    ''' </summary>
    ''' <param name="settings"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Initializ(ByVal settings As ucKeithleySMUSettings.sKeithley) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Init M6100 Settings
    ''' </summary>
    ''' <param name="settings"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Initializ(ByVal settings As CDevM6100.sM6100Setting, ByVal ch As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Get Range And IntegTime List
    ''' </summary>
    ''' <param name="range"></param>
    ''' <remarks></remarks>
    Public Overridable Sub GetRangeList(ByRef range As sRangeAndIntegTime)

    End Sub

    ''' <summary>
    ''' IDN
    ''' </summary>
    ''' <param name="sInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function IDN(ByRef sInfo As String) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' SetBoradNumberInit
    ''' </summary>
    ''' <param name="nBoardnumber"></param>
    ''' <remarks></remarks>
    Public Overridable Sub SetBoardInit(ByVal nBoardnumber As Integer)

    End Sub

    ''' <summary>
    '''  ACK
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ACK() As Boolean
        Return False
    End Function

    Public Overridable Function Test() As Boolean
        Return False
    End Function

#End Region


End Class
