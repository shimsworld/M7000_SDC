Imports System.Threading
Imports CCommLib


Public Class CDevStrobe

#Region "Communication_Serial"
    Public Const SERIAL_BAUDRATE As Integer = 38400
    Public Const SERIAL_DataBits As Integer = 8
    Public Const SERIAL_RcvTerminator As String = vbLf
    Public Const SERIAL_SndTerminator As String = vbCr
    Public Const SERIAL_StopBit As System.IO.Ports.StopBits = IO.Ports.StopBits.One
    Public Const SERIAL_Parity As System.IO.Ports.Parity = IO.Ports.Parity.None
#End Region

    Dim communicator As CComAPI

    Dim m_Config As CComCommonNode.sCommInfo
    Dim m_bIsConnected As Boolean = False
    Public StrobeSetting As sSetTrigger

    Shared sSupportDeviceList() As String = New String() {"Strobe"}

    Public Enum eModel
        Strobe
    End Enum

    Public Sub New()

    End Sub

#Region "Property"

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

#End Region

#Region "Structure"

    Public Structure sSetTrigger
        Dim Ch As Integer
        Dim Enable As Integer
        Dim Rf As Integer
        Dim DelayTime As Integer
        Dim OnTime As Integer
        Dim HoldTime As Integer
        Dim Repeat As Integer
    End Structure

#End Region

#Region "Communication"

    Public Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim strVer As String = ""

        m_bIsConnected = False
        m_Config = Config
        communicator = New CComAPI(m_Config.commType)
        If communicator.Communicator.Connect(m_Config) <> CComCommonNode.eReturnCode.OK Then Return False
        If Version(strVer) = True Then
            If SetMode(True) = False Then Return False

        Else
            Return False
        End If

        If ReadStrobe() = False Then
            Return False
        End If

        TurnOff()

        m_bIsConnected = True

        Return True
    End Function

    Public Sub Disconnection()
        If communicator Is Nothing = False Then
            communicator.Communicator.Disconnect()
        End If

        m_bIsConnected = False
    End Sub

#End Region

#Region "Function"
    Public Function SetMode(ByVal bMode As Boolean) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "setmode " & CInt(bMode)
        If communicator.Communicator.SendToString(sSendCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function GetMode(ByRef bMode As Boolean) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "getmode"
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        Dim arr As Array = sRcvData.Split(" ")
        bMode = CBool(arr(1))

        Return True
    End Function

    Public Function ReadStrobe() As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "geterrstatus"
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        If Parse_StrobeGet(sRcvData, sSendCommand) = False Then Return False

        Return True
    End Function

    Public Function Version(ByRef strVer As String) As Boolean
        Dim sSendCommand As String = Nothing

        sSendCommand = "getfwversion"

        If communicator.Communicator.SendToString(sSendCommand, strVer) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function GetOnOff(ByRef bState As Boolean) As Boolean
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "getonoff 0"
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
            Dim arr As Array = sRcvData.Split(" ")
            bState = CBool(arr(2))
        End If

        Return True
    End Function

    Public Sub TurnOn()
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "setonoff 0 1"
        If communicator.Communicator.SendToString(sSendCommand) = CComCommonNode.eReturnCode.OK Then
        End If
    End Sub

    Public Sub TurnOff()
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        sSendCommand = "setonoff 0 0"
        If communicator.Communicator.SendToString(sSendCommand) = CComCommonNode.eReturnCode.OK Then
        End If
    End Sub

    Public Sub SetBrightness(ByVal Brightness As Integer)
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        If Brightness >= 0 And Brightness <= 255 Then
            sSendCommand = "setbright 0 " & Brightness
            If communicator.Communicator.SendToString(sSendCommand) = CComCommonNode.eReturnCode.OK Then
            End If
        End If
    End Sub

    Public Function GetBrightness() As Integer
        GetBrightness = 0
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        Dim Bright As Integer
        sSendCommand = "getbrightness 0"
        If communicator.Communicator.SendToString(sSendCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
            If Parse_StrobeGet(sRcvData, "getbrightness", Bright) = True Then
                GetBrightness = Bright
            Else
                GetBrightness = 0
            End If
        End If
    End Function

    Public Sub SaveBrightness(ByVal Index As Integer)
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        If Index >= 0 And Index <= 9 Then
            sSendCommand = "savebright " & Index
            If communicator.Communicator.SendToString(sSendCommand) = CComCommonNode.eReturnCode.OK Then
            End If
        End If
    End Sub

    Public Sub LoadBrightness(ByVal Index As Integer)
        Dim sSendCommand As String = Nothing
        Dim sRcvData As String = Nothing
        If Index >= 0 And Index <= 9 Then
            sSendCommand = "loadbright " & Index
            If communicator.Communicator.SendToString(sSendCommand) = CComCommonNode.eReturnCode.OK Then
            End If
        End If
    End Sub

    Public Function Parse_StrobeGet(ByRef In_Data As String, ByVal Snd As String, Optional ByRef Bright As Integer = 0) As Boolean
        Parse_StrobeGet = False
        Dim TempData As Array
        If In_Data.Length < 15 Then
            Exit Function
        End If
        In_Data = In_Data.Substring(0, In_Data.Length - 1)
        TempData = Split(In_Data, " ", -1)
        If Snd = "geterrstatus" Then
            If TempData(0) = Snd And TempData(1) = "0" And TempData(2) = "0" Then
                Parse_StrobeGet = True
            End If
        ElseIf Snd = "getbrightness" Then
            If TempData(0) = Snd And TempData(1) = "0" And TempData(2) = "0" Then
                Bright = TempData(3)
                Parse_StrobeGet = True
            End If
        End If
    End Function

    Public Function Parse_StrobeSet(ByVal In_Data As String) As Boolean
        Parse_StrobeSet = False
        Dim TempData As Array
        If In_Data.Length < 20 Then
            Exit Function
        End If
        TempData = Split(In_Data, " ", -1)
    End Function

#End Region

    
End Class
