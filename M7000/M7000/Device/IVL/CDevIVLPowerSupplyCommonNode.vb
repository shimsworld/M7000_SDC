Public Class CDevIVLPowerSupplyCommonNode
#Region "Define"

    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False

    Shared sSupportDeviceList() As String = New String() {"SPE3051"}

    Public Enum eModel
        SPE3051
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

#End Region


#Region "Creator, Disoposer And Init"

    Public Sub New()
        m_bIsConnected = False
    End Sub

#End Region

#Region "Communication Functions"

    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function

    Public Overridable Function Connection(ByVal config As CCommLib.CComSerial.sSerialPortInfo) As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub
#End Region
#Region "Control Functions"
    Public Overridable Function Reset() As Boolean
        Return False
    End Function
    Public Overridable ReadOnly Property IDN As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overridable Property OUTPUT As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
        End Set
    End Property

    Public Overridable Property Volt As Double
        Get
            Return 0
        End Get
        Set(value As Double)
        End Set
    End Property
    Public Overridable Property VoltLimit As Double
        Get
            Return 0
        End Get
        Set(value As Double)
        End Set
    End Property

    Public Overridable Property Current As Double
        Get
            Return 0
        End Get
        Set(value As Double)
        End Set
    End Property
    Public Overridable Property CurrentLimit As Double
        Get
            Return 0
        End Get
        Set(value As Double)
        End Set
    End Property
#End Region

End Class
