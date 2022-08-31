Imports System.IO.Ports
Imports System.Threading
Imports CCommLib

Public Class CDevIVLPowersupply
    Inherits CDevIVLPowerSupplyCommonNode

#Region "Define"

    Dim m_nBeforOnChannel As Integer

    Public Event evDataTransfered(ByVal str As String)

    Public communicator As CComAPI ' CCommLib.CComAPI(CCommLib.CComCommonNode.eCommType.eGPIB)
    '  Dim m_Config As CComCommonNode.sCommInfo
#End Region

#Region "Creator, Disposer And Initialization"

    Public Sub New()
        MyBase.New()
        ' m_CommStatus = eTransferState.eReady

        '  m_bIsConnected = False
        '   communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        m_MyModel = eModel.SPE3051
    End Sub

    Private Sub init()

    End Sub

#End Region



#Region "Communication"

    Public Overrides Function Connection(ByVal configInfo As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = configInfo
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(configInfo) = False Then

            m_bIsConnected = False
            Return False
        Else
            m_bIsConnected = True

            Return True
        End If
    End Function

    Public Overrides Function Connection(ByVal configInfo As CComSerial.sSerialPortInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo.sSerialInfo = configInfo

        If communicator.Communicator.Connect(configInfo) = False Then
            m_bIsConnected = False
            Return False
        Else
            m_bIsConnected = True

            Return True
        End If
    End Function

    Public Overrides Sub Disconnection()
        If m_bIsConnected = True Then
            communicator.Communicator.Disconnect()
        End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "API Functions"
    'Public Overrides Sub Reset()
    '    Dim sCommand As String = "*RST?\r\n"
    '    Dim sRcvData As String = ""
    '    communicator.Communicator.SendToString(sCommand, sRcvData)
    '    sRcvData.Replace("\r\n", "")
    'End Sub
    Public Overrides ReadOnly Property IDN As Boolean
        Get
            Dim sCommand As String = "*IDN?"
            Dim sRcvData As String = ""

            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return ""
            sRcvData.Replace("\r\n", "")
            Return sRcvData <> ""

        End Get
    End Property
    Public Overrides Property OUTPUT As Boolean
        Get
            Dim sCommand As String = "OUTP?"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return 0
            sRcvData.Replace("\r\n", "")
            Return CDbl(sRcvData.Replace("\r\n", ""))
        End Get
        Set(value As Boolean)
            Dim sCommand As String = If(value, "OUTP ON", "OUTP OFF")
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

            End If
        End Set
    End Property
    Public Overrides Property Volt As Double
        Get
            Dim sCommand As String = "MEAS:VOLT?"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return 0

            Return CDbl(sRcvData.Replace("\r\n", ""))
        End Get
        Set(value As Double)
            Dim sCommand As String = $"VOLT {value}"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

            End If
        End Set
    End Property
    Public Overrides Property VoltLimit As Double
        Get
            Dim sCommand As String = "VOLT:LIM?"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return 0

            Return CDbl(sRcvData.Replace("\r\n", ""))
        End Get
        Set(value As Double)
            Dim sCommand As String = $"VOLT:LIM {value}"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

            End If
        End Set
    End Property

    Public Overrides Property Current As Double
        Get
            Dim sCommand As String = "MEAS:CURR?"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return 0

            Return CDbl(sRcvData.Replace("\r\n", ""))
        End Get
        Set(value As Double)
            Dim sCommand As String = $"CURR {value}"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

            End If
        End Set
    End Property
    Public Overrides Property CurrentLimit As Double
        Get
            Dim sCommand As String = "CURR:LIM?"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return 0

            Return CDbl(sRcvData.Replace("\r\n", ""))
        End Get
        Set(value As Double)
            Dim sCommand As String = $"CURR:LIM {value}"
            Dim sRcvData As String = ""
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then

            End If
        End Set
    End Property
#End Region

#Region "Serial Communication Function"


    Private g_sRcvData As String

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function


#End Region

    Private Function ReceiveData(ByVal strRcvData As String) As Boolean
        Dim bStatus As Boolean
        On Error GoTo ErrorHandler

        If strRcvData <> "" Then
            bStatus = True
        Else
            bStatus = False
        End If
        Return bStatus

ErrorHandler:

        bStatus = False
        Return bStatus

    End Function

End Class
