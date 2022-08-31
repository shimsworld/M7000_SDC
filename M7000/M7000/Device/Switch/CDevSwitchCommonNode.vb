Public Class CDevSwitchCommonNode


#Region "Define"

    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False

    Shared sSupportDeviceList() As String = New String() {"SW7700", "SW7000", "K7001"}

    Public Enum eModel
        MC_SW7700
        MC_SW7000
        KEITHLEY_K7001
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


    'Public Property OffLineMode() As Boolean
    '    Get
    '        Return m_bIsOffLine
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_bIsOffLine = Value
    '    End Set
    'End Property


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

    Public Overridable Function Connection(ByVal configInfo As CCommLib.CComGPIB.sGPIBInfos) As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub

#End Region


#Region "Control Functions"

    Public Overridable Function Reset() As Boolean
        Return False
    End Function




    ''' <summary>
    ''' Selected Switch ON
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SwitchON(ByVal nCh As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SwitchON(ByVal nDevNum As Integer, ByVal nCh As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Selected Switch OFF
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SwitchOFF(ByVal nCh As Integer) As Boolean
        Return False
    End Function
    Public Overridable Function SwitchOFF(ByVal nDevNum As Integer, ByVal nCh As Integer) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' All Switch OFF
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function AllOFF() As Boolean
        Return False
    End Function
    Public Overridable Function AllOFF(ByVal nDevNum As Integer) As Boolean
        Return False
    End Function

    Public Overridable Function AllON() As Boolean
        Return False
    End Function
    Public Overridable Function AllON(ByVal nDevNum As Integer) As Boolean
        Return False
    End Function
#End Region

End Class
