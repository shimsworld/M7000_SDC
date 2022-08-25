Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib

Public Class CDevK7001
    Inherits CDevSwitchCommonNode

    Public communicator As CComAPI ' CCommLib.CComAPI(CCommLib.CComCommonNode.eCommType.eGPIB)
    '  Dim m_Config As CComCommonNode.sCommInfo

#Region "Define"
    Dim maxChOfCard As Integer = 10
    Dim maxCard As Integer = 2
    Dim maxChOfK7001 As Integer = maxChOfCard * maxCard
#End Region

#Region "Structure"

    Public Structure sIDNInfo
        Dim sManufacture As String
        Dim sModel As String
        Dim sSerial As String
        Dim sFirmware As String
    End Structure

#End Region


#Region "Create, Dispose And Init"

    Public Sub New()
        MyBase.new()
        m_MyModel = eModel.KEITHLEY_K7001
        '  communicator = New CComAPI(CComCommonNode.eCommType.eGPIB)
    End Sub

    Public Overridable Sub Dispose()
        communicator = Nothing

    End Sub

#End Region

#Region "Communication"

    '  Public Overrides Function Connection(ByVal configInfo As CComGPIB.sGPIBInfos) As Boolean
    Public Overrides Function Connection(ByVal configInfo As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = configInfo
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(m_ConfigInfo) = False Then Return False

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        If m_bIsConnected = True Then
            communicator.Communicator.Disconnect()
        End If
        m_bIsConnected = False
    End Sub
#End Region

#Region "API Functions"
    Public Overrides Function Reset() As Boolean
        Dim sCmd As String = "*RST"

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function AllOFF() As Boolean           'All Switch Open
        Dim sCmd As String = ":open all"

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Function SwitchON(ByVal nCh As Integer) As Boolean
        Dim sCardNum As String = Nothing
        Dim sChNumOfCard As String = Nothing

        'nCh 는 Switch장비 전체의 접점(채널수)을 0 ~ MaxCh 수로 나타낸 값
        'nCh 에서 카드 번호와 카드의 채널 번호로 컨버팅하는 함수 필요함.

        ConvertChToK7001Info(nCh, sCardNum, sChNumOfCard)

        Return SetSelectChClose(sCardNum, sChNumOfCard)
    End Function

    Public Overrides Function SwitchOFF(ByVal nCh As Integer) As Boolean
        Dim sCardNum As String = Nothing
        Dim sChNumOfCard As String = Nothing

        ConvertChToK7001Info(nCh, sCardNum, sChNumOfCard)

        Return SetSelectChOpen(sCardNum, sChNumOfCard)
    End Function
#End Region

#Region "Function"
    'H/W 회로적인 의미로 사용한다
    'Open = Off
    'Clese = On
    Public Function IDN(ByRef identifyInfos As sIDNInfo) As Boolean
        Dim sCmd As String = "*IDN?"
        Dim sRcvData As String = ""
        Dim arrBuf As Array = Nothing

        If communicator.Communicator.SendToString(sCmd, sRcvData) = CComCommonNode.eReturnCode.OK Then
            If Parser(sRcvData, arrBuf) = True Then
                identifyInfos.sManufacture = arrBuf(0)
                identifyInfos.sModel = arrBuf(1)
                identifyInfos.sSerial = arrBuf(2)
                identifyInfos.sFirmware = arrBuf(3)
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Private Function ConvertChToK7001Info(ByVal nCh As Integer, ByRef sCardNumber As String, ByRef sChNumber As String) As Boolean
        Dim nCardNO As Integer
        Dim nChOfCard As Integer


        nCardNO = Fix(nCh / maxChOfCard) + 1
        nChOfCard = (nCh - Fix(nCh / maxChOfCard) * maxChOfCard) + 1

        sCardNumber = CStr(nCardNO)
        sChNumber = CStr(nChOfCard)

        Return True
    End Function
    'Off
    Public Function SetSelectChOpen(ByVal sCardNumber As String, ByVal sChNumber As String) As Boolean
        Dim sCmd As String = ":open (@" & sCardNumber & "!" & sChNumber & ")"
        Dim sCmdMake As String = Nothing

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    'On
    Public Function SetSelectChClose(ByVal sCardNumber As String, ByVal sChNumber As String) As Boolean
        Dim sCmd As String = ":clos (@" & sCardNumber & "!" & sChNumber & ")"

        If communicator.Communicator.SendToString(sCmd) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function
#End Region

    Private Function Parser(ByVal sRcvData As String, ByRef arrBuf As Array) As Boolean

        sRcvData = sRcvData.TrimStart(Chr(19))   'STX
        sRcvData = sRcvData.TrimEnd(Chr(10))  'EOT
        sRcvData = sRcvData.TrimEnd(Chr(13))
        sRcvData = sRcvData.TrimEnd(Chr(17))

        If sRcvData Is Nothing Then Return False
        If sRcvData.Length = 0 Then Return False

        Dim byValue(sRcvData.Length - 1) As Byte

        For i As Integer = 0 To sRcvData.Length - 1
            byValue(i) = System.Convert.ToByte(Asc(sRcvData.Substring(i, 1)))
        Next

        arrBuf = Split(sRcvData, ",", -1)

        Return True
    End Function

#Region "Support Functions"

#End Region
End Class
