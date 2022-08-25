Imports System.Windows.Forms
Imports CCommLib

Public Class CDevMcTC
    Public communicator As CComAPI
    Dim m_bIsConnected As Boolean = False
    Dim m_ConfigInfo As CComCommonNode.sCommInfo
    Public SupportDeviceNames() As String = New String() {"TC"}


    Dim CommandSeparator As String = ";"
    Dim SCPISeparator As String = ":"
    Dim QueryCommand As String = "?"
    Dim SpaceSeparator As String = " "

    Public Enum eModel
        TC 'UART  ComType : Serial,  BPS : 9600, Parity:None, Stop Bit : 1, Data Length :8, RcvTerm : LF, SndTerm : LF
    End Enum

    Public Function Connection(ByVal sCommInfo As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = sCommInfo
        communicator = New CComAPI(m_ConfigInfo.commType)

        Dim str As String = ""
        If communicator.Communicator.Connect(sCommInfo) = False Then

            m_bIsConnected = False
            Return False
        Else

            'If IDN() = False Then
            '    m_bIsConnected = False
            '    Return False
            'End If
            If GetSerialNumber(1, str) = False Then
                m_bIsConnected = False
                Return False
            End If

            m_bIsConnected = True

            Return True
        End If
        Return True
    End Function


    Public Function RST(ByVal adress As Integer, ByRef ret As String) As Boolean 'Initializes the settings

        Dim sCommand As String = "*RST"
        Dim sAdress As String = ""

        If adress < 10 Then
            sAdress = "0" & adress
        Else
            sAdress = adress.ToString
        End If

        sCommand = sAdress & sCommand

        If communicator.Communicator.SendToString(sCommand, ret) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True

    End Function

    Public Function SetSerialNumber(ByVal adress As Integer, ByVal serialnumber As String, ByRef ret As String) As Boolean


        Dim sCommand As String = "SYS:SN" & SpaceSeparator & serialnumber
        'Dim sRcvData As String = ""
        Dim sAdress As String = ""

        If adress < 10 Then
            sAdress = "0" & adress
        Else
            sAdress = adress.ToString
        End If


        sCommand = sAdress & sCommand

        If communicator.Communicator.SendToString(sCommand, ret) <> CComCommonNode.eReturnCode.OK Then Return False

        'ret = sRcvData
        Return True
    End Function

    Public Function GetSerialNumber(ByVal adress As Integer, ByRef serialnumber As String) As Boolean
        Dim sCommand As String = "SYS:SN" & QueryCommand
        Dim sAdress As String = ""

        If adress < 10 Then
            sAdress = "0" & adress
        Else
            sAdress = adress.ToString
        End If

        sCommand = sAdress & sCommand

        If communicator.Communicator.SendToString(sCommand, serialnumber) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function




    Public Function GetTemp(ByVal adress As Integer, ch As Integer, ByRef temp As Double) As Boolean
        Dim sCommand As String = "MEAS:TEMP" & QueryCommand & SpaceSeparator
        Dim sRcvData As String = ""
        Dim sAdress As String = ""

        If ch < 10 Then
            Dim send As String = "0" & ch
            sCommand = sCommand & send
        Else
            sCommand = sCommand & ch
        End If

        If adress < 10 Then
            sAdress = "0" & adress
        Else
            sAdress = adress.ToString
        End If

        sCommand = sAdress & sCommand

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Dim buff() As String

        buff = sRcvData.Split(" ")

        'buff(0) 채널정보
        'buff(1) 온도정보

        'If adress <> Convert.ToInt16(buff(0).Chars(0)) Then
        '    Return False
        'End If

        'If ch <> Convert.ToInt16(buff(0).Chars(1)) * 10 + Convert.ToInt16(buff(0).Chars(2)) Then
        '    Return False
        'End If

        temp = Convert.ToDouble(buff(1))

        Return True


    End Function

    Public Function GetTempAll(ByVal adress As Integer, ByRef temp() As Double, Optional ByVal num As Integer = 16) As Boolean
        Dim sCommand As String = "MEAS:TEMP" & QueryCommand & SpaceSeparator & "00"
        Dim sRcvData As String = ""
        Dim sAdress As String = ""
        ReDim temp(num - 1)
        If adress < 10 Then
            sAdress = "0" & adress
        Else
            sAdress = adress.ToString
        End If

        sCommand = sAdress & sCommand

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Dim buff() As String

        buff = sRcvData.Split(" ")

        For i As Integer = 1 To num
            temp(i - 1) = Convert.ToDouble(buff(i))
        Next


        Return True
    End Function


End Class
