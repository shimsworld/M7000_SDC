Imports System.IO.Ports
Imports System.Threading
Imports CCommLib

Public Class CDevIVLPowersupply
    Inherits CDevSwitchCommonNode

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
        m_MyModel = eModel.MC_SW7000
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

    ReadOnly Property IDN As Boolean
        Get
            Dim sCommand As String = "*IDN?\r\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return sRcvData <> ""
        End Get
    End Property
    Property OUTPUT As Boolean
        Get
            Dim sCommand As String = "OUTP?\r\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return sRcvData = "1"
        End Get
        Set(value As Boolean)
            Dim sCommand As String = If(value, "OUTP ON\r\n", "OUTP OFF\r\n")
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
        End Set
    End Property
    Property Volt As Double
        Get
            Dim sCommand As String = "MEAS:VOLT?\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return CDbl(sRcvData)
        End Get
        Set(value As Double)
            Dim sCommand As String = $"VOLT {value}\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
        End Set
    End Property
    Property VoltLimit As Double
        Get
            Dim sCommand As String = "VOLT:LIM?\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return CDbl(sRcvData)
        End Get
        Set(value As Double)
            Dim sCommand As String = $"VOLT:LIM {value}\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
        End Set
    End Property

    Property Current As Double
        Get
            Dim sCommand As String = "MEAS:CURR?\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return CDbl(sRcvData)
        End Get
        Set(value As Double)
            Dim sCommand As String = $"CURR {value}\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
        End Set
    End Property
    Property CurrentLimit As Double
        Get
            Dim sCommand As String = "CURR:LIM?\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
            sRcvData.Replace("\r\n", "")
            Return CDbl(sRcvData)
        End Get
        Set(value As Double)
            Dim sCommand As String = $"CURR:LIM {value}\t\n"
            Dim sRcvData As String = ""
            communicator.Communicator.SendToString(sCommand, sRcvData)
        End Set
    End Property
#End Region

#Region "API Functions"
    Public Overrides Function AllOFF() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim bStatus As Boolean

        On Error GoTo ErrorHandler

        If m_bIsConnected = False Then
            Return False
        End If

        sCommand = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        bStatus = ReceiveData(sRcvData)
        Return bStatus

ErrorHandler:
        Return False
    End Function

    Public Overrides Function AllON() As Boolean

        Dim sCommand As String
        Dim sRcvData As String = ""
        Dim bStatus As Boolean

        On Error GoTo ErrorHandler

        If m_bIsConnected = False Then
            Return False
        End If

        sCommand = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        bStatus = ReceiveData(sRcvData)
        Return bStatus

ErrorHandler:
        Return False
    End Function

    Public Overrides Function SwitchON(ByVal nCh As Integer) As Boolean
    End Function

    Public Overrides Function SwitchOFF(ByVal nCh As Integer) As Boolean
    End Function
#End Region


#Region "Serial Communication Function"


    Private g_sRcvData As String

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function


#End Region

    Private Function ReceiveData(ByVal strRcvData As String) As Boolean
        Dim readBuff() As String
        Dim bStatus As Boolean
        '  Dim strDevComm As String = sSendDataChk

        On Error GoTo ErrorHandler

        If strRcvData <> "" Then

            ReDim readBuff(5)

            If strRcvData.Length = 10 Then

                readBuff = Split(strRcvData, ",", -1)
            Else
                bStatus = True

            End If
        Else
            bStatus = False

        End If

        Return bStatus

ErrorHandler:

        bStatus = False
        Return bStatus

    End Function

End Class
