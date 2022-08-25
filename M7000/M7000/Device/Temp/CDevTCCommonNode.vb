Imports System.Threading

Public Class CDevTCCommonNode

    Protected m_MyModel As eModel
    Protected m_bIsConnected As Boolean = False
    Public ID485 As Integer = 1  '어드레스 주소
    Dim m_numOfChPerDev As Integer
    Protected m_bIsOffLine As Boolean
    Shared sSupportDeviceList() As String = New String() {"NX1", "MC9", "TD500", "SP790", "THC98585", "TOHO_TTM004", "K601"}

    Public Event evChangedOutputEvent(ByVal state As eOutputStatus)


#Region "Define"

    Public m_Settings() As sSettings

    Public Structure sSettings
        Dim devID As Integer
        Dim numOfCh As Integer
        Dim Setting() As sParams
    End Structure

    Public Structure sParams
        Dim measTemp As Double 'PV
        Dim setTemp As Double 'SP
        Dim bIsRun As Boolean
        ' Dim dLimitAlarmOffset As Boolean   'SP(설정 온도)에서 LimitAlarmOffset값을 더한 값을 설정
        Dim bEnableEvent1 As Boolean
        Dim dEvent1LimitVal_High As Double
        Dim dEvent1LimitVal_Low As Double
        Dim nOutputState() As eOutputStatus
    End Structure

#Region "Enum"

    Public Enum eModel
        _NX1
        _MC9
        _TD500
        _SP790
        _THC98585
        _TOHO_TTM004
        _K601
    End Enum

    Public Enum eReturnCode
        NoSupport = 0
        OK
        FuncErr
        Communication_Error
        RcvDataParsing_Error
        RcvData_NAK
    End Enum

    Public Enum eCHA1NNEL
        CH1 = 0
    End Enum

    Public Enum eOutputStatus
        _Nothing
        _Undefiend
        _Limit_Alarm_EV2 = 2
        _Limit_Alarm_EV1
        _OUT2
        _OUT1
    End Enum

#End Region

#End Region

#Region "Define"

    'Public Structure sSettingParam
    '    Dim devID As Integer
    '    Dim chOfDev As eCHANNEL
    '    Dim dTargetTemp As Double
    'End Structure

    'Public Structure sMeasuredData
    '    Dim dMeasuredTemp() As Double

    'End Structure

#End Region


#Region "Creator & Disposer"

    Public Sub New()

    End Sub

    Public Overridable Sub Dispose()
        Disconnection()
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


#Region "Property"

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public Overridable Property DevAddr As Integer
        Get
            Return ID485
        End Get
        Set(ByVal value As Integer)
            ID485 = value
        End Set
    End Property

    Public Overridable ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overridable Property NumOfChannelPerDev As Integer
        Get
            Return m_numOfChPerDev
        End Get
        Set(ByVal value As Integer)
            m_numOfChPerDev = value
        End Set
    End Property

    Public Overridable Property Settings As sSettings()
        Get
            Return m_Settings.Clone
        End Get
        Set(ByVal value As sSettings())
            m_Settings = value.Clone
        End Set
    End Property

    Public Overridable ReadOnly Property Model As eModel
        Get
            Return m_MyModel
        End Get
    End Property




#End Region


#Region "Connect"

    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return eReturnCode.NoSupport
    End Function
    Public Overridable Function Connection(ByVal config As CCommLib.CComSerial.sSerialPortInfo) As Boolean
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Sub Disconnection()

    End Sub

#End Region


#Region "Function"

    Public Overridable Function DevINFO(ByVal addr As Integer, ByRef sInfo As String) As eReturnCode
        Return eReturnCode.NoSupport
    End Function


    Public Overridable Function OperationRun() As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function OperationRun(ByVal addr As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function OperationRun(ByVal addr As Integer, ByVal nCh As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function


    Public Overridable Function OperationStop() As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function OperationStop(ByVal addr As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function OperationStop(ByVal addr As Integer, ByVal nCh As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function





    Public Overridable Function SetTemperature(ByVal addr As Integer, ByVal DataNum As Integer, ByVal Temperature As String) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function SetTemperature(ByVal addr As Integer, ByVal nCh As Integer, ByVal sRunStop As Boolean, ByVal dTemperature As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function SetTemperature(ByVal Ch_No As CDevMC9.eCHANNEL, ByVal SetData As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function SetTemperature(ByVal addr As Integer, ByVal Ch_No As CDevMC9.eCHANNEL, ByVal SetData As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function SetTemperature(ByVal addr As Integer, ByVal dTemperature As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    'Public Overridable Function SetLimitAlarm(ByVal addr As Integer, ByVal Limit_Low As Double, ByVal Limit_High As Double) As eReturnCode
    '    Return eReturnCode.NoSupport
    'End Function


    Public Overridable Function Get_Status(ByRef GetData() As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function Get_Status(ByVal addr As Integer, ByVal devID As Integer, ByRef GetData() As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetOutputStatus(ByVal addr As Integer, ByRef state() As eOutputStatus) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetTemperature(ByVal addr As Integer, ByRef retData As sParams) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetTemperature(ByVal addr As Integer, ByRef dTemperature As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetTemperature(ByVal Ch_No As CDevMC9.eCHANNEL, ByRef OutData As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetTemperature(ByVal addr As Integer, ByVal Ch_No As CDevMC9.eCHANNEL, ByRef OutData As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetTemperature(ByVal addr As Integer, ByRef dCurrTemp As Double, ByRef dSetTemp As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function GetSetTemperature(ByVal addr As Integer, ByRef dSetTemp As Double) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

#End Region




End Class
