Imports System.IO.Ports
Imports System.Threading
Imports CCommLib

Public Class CDevEIPPG
    Inherits CDevPGCommonNode '김세훈

    Public communicator As CComAPI ' CCommLib.CComAPI(CCommLib.CComCommonNode.eCommType.eGPIB)
    '  Dim m_Config As CComCommonNode.sCommInfo



#Region "Creator, Disposer And Initialization"

    Public Sub New()
        MyBase.New()
        ' m_CommStatus = eTransferState.eReady

        '  m_bIsConnected = False
        '   communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        m_MyModel = eDevModel._EIP
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

    '김세훈 8.26 PG_ON
    Public Overrides Function EIPPG_ON() As Boolean

        If m_bIsConnected = False Then
            Return False
        End If
        Dim p_ON(8) As Byte

        p_ON(0) = 2
        p_ON(1) = 0
        p_ON(2) = 128
        p_ON(3) = 2
        p_ON(4) = 129
        p_ON(5) = 0
        p_ON(6) = 3
        p_ON(7) = 3
        If communicator.Communicator.SendToBytes(p_ON) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function
    '김세훈 8.26 PG_OFF
    Public Overrides Function EIPPG_OFF() As Boolean

        If m_bIsConnected = False Then
            Return False
        End If

        Dim p_OFF(8) As Byte
        p_OFF(0) = 2
        p_OFF(1) = 0
        p_OFF(2) = 128
        p_OFF(3) = 2
        p_OFF(4) = 130
        p_OFF(5) = 0
        p_OFF(6) = 0
        p_OFF(7) = 3

        If communicator.Communicator.SendToBytes(p_OFF) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function
End Class
