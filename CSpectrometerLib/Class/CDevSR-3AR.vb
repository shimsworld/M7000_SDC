Imports System.Threading
Imports System.Windows.Forms
Imports CCommLib

Public Class CDevSR_3AR
    Inherits CDevSpectrometerCommonNode

#Region "USB Communication DLL Load"

    Private Declare Function USBDrv_Init Lib "topusb.dll" () As Integer
    Private Declare Function USBDrv_Open Lib "topusb.dll" ( _
                                ByVal DeviceNo As Integer) As Boolean
    Private Declare Function USBDrv_Close Lib "topusb.dll" ( _
                                ByVal DeviceNo As Integer) As Boolean
    Private Declare Function USBDrv_Write Lib "topusb.dll" (ByVal DeviceNo As Integer, ByVal pWriteBuf As String, ByVal WriteLen As Integer, ByRef pWriteLen As Integer) As Boolean
    Private Declare Function USBDrv_Read Lib "topusb.dll" ( _
                                ByVal DeviceNo As Integer, _
                                ByVal pReadBuf As String, _
                                ByVal ReadLen As Integer, _
                                ByRef pReadLen As Integer) As Boolean


#End Region


#Region "Enums"

    Public Enum eTransferState
        eReady
        eTransferingData
        eTransferFail
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eOutputData
        eAllData
        eAllDataWithoutSpectrumData
    End Enum

    'Public Enum eCommand
    '    eRemoteMode
    '    eLocalMode
    'End Enum

    Public Enum eMeasField
        _2
        _1
        _0R2
        _0R1
    End Enum

    Public Enum eMeasSpeed
        _NOMAL
        _FAST
    End Enum
#End Region

#Region "Define Global Variable"

    '  Private g_bIsConnected As Boolean
    Private m_bOffLine As Boolean

    Private m_nDeviceNo As Integer

    Private m_Data As tData

    Private Const sDelimiter As String = vbCrLf
    Private Const sEndStr As String = "END"

    Public Event evDataTransfered(ByVal str As String, ByVal nState As eTransferState)
    Private m_eCommStatus As eTransferState
    Private Const SIZE_BUFFER As Integer = 64

    '  Public g_MeasData As sData
    Private m_nWavelength(400) As Integer
    Private m_dSpectralRadiance(400) As Double

    Private sMeasuringField() As String = New String() {"FLD1", "FLD2", "FLD3", "FLD4"}
    Private sMeasuringSpeed() As String = New String() {"NS", "HS"}

    Private sAperatureName() As String = New String() {"2'", "1'", "0.2'", "0.1'"}
    Private sMeasSpeedName() As String = New String() {"Nomal", "Fast"}

    Private m_CurrentAperture As eMeasField = Nothing
    Private m_CurrentSpeedMode As eMeasSpeed = Nothing

    Public communicator As CComAPI
#End Region

#Region "Structures"

    'Public Structure DeviceOption
    '    Dim AperatureList() As sAperature
    '    Dim MeasSpeed() As sMeasSpeed
    '    Dim ALensList() As sLens
    'End Structure

    'Public Structure sAperature
    '    Dim nIndex As Integer
    '    Dim dAngle As Double
    'End Structure

    'Public Structure sMeasSpeed
    '    Dim nIndex As Integer
    '    Dim sSpeed As String
    'End Structure

    'Public Structure sLens
    '    Dim nIndex As Integer
    '    Dim sLensName As String
    'End Structure

    'Public Structure sData
    '    Dim dField As Double
    '    Dim nIntegTime_ms As Integer
    '    Dim dRadiance As Double
    '    Dim dLuminance As Double
    '    Dim dX As Double
    '    Dim dY As Double
    '    Dim dZ As Double
    '    Dim CIE1931x As Double
    '    Dim cIE1931y As Double
    '    Dim CIE1976u As Double
    '    Dim CIE1976v As Double
    '    Dim dColorTemp As Double
    '    Dim dDeviation As Double
    '    Dim bSpectrumMeasured As Boolean
    '    Dim Spectrum As sSpectrumData
    'End Structure

    'Public Structure sSpectrumData
    '    Dim nWavelength() As Integer
    '    Dim dSpectralRadiance() As Double
    'End Structure



#End Region

#Region "Property"

    'Public ReadOnly Property IsConnected() As Boolean
    '    Get
    '        Return g_bIsConnected
    '    End Get
    'End Property

    'Public Property OffLineMode() As Boolean
    '    Get
    '        Return g_bOffLine
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        g_bOffLine = Value
    '    End Set
    'End Property

    'Public Property DeviceNo() As Integer
    '    Get
    '        Return g_nDeviceNo
    '    End Get
    '    Set(ByVal Value As Integer)
    '        g_nDeviceNo = Value
    '    End Set
    'End Property

    'Public ReadOnly Property GetMeasuredData() As sData
    '    Get
    '        Return g_MeasData
    '    End Get
    'End Property

#End Region

#Region "Creator, Disposer, Init"

    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_SR3AR
        m_bIsConnected = False
        m_bOffLine = False
        m_nDeviceNo = 1
    End Sub

#End Region

#Region "API Functions"
    Public Overrides Function StartApertureChange() As Boolean

        Return True
    End Function

    Public Overrides Function EndApertureChange() As Boolean

        Return True
    End Function

    Public Overrides Function RemoteMode() As Boolean
        If SetRemote() = False Then Return False
        Return True
    End Function

    Public Overrides Function LocalMode() As Boolean
        If SetLocal() = False Then Return False
        Return True
    End Function

    Public Overrides Function Measure(ByRef outData As tData) As Boolean
        If Meas(outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function DownloadData(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        outData = m_Data
        Return True
    End Function

    Public Overrides Function MeasureFixedAperture(ByRef outData As CDevSpectrometerCommonNode.tData) As Boolean
        If Meas(outData) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetDeviceInfos(ByVal sInfos As DeviceOption) As Boolean
        With sInfos
            If SetMeasuringField(.ApertureList(.ApertureIndex).nApertureCodeIndex) = False Then Return False
            If SetMeasuringSpeed(.MeasSpeedList(.MeasSpeedIndex).nMeasSpeedCodeIndex) = False Then Return False
        End With
        Return True
    End Function

    Public Overrides Function GetDeviceinfos(ByRef sInfos As DeviceOption) As Boolean
        ReDim sInfos.ApertureList(sAperatureName.Length - 1)
        ReDim sInfos.MeasSpeedList(sMeasSpeedName.Length - 1)
        ReDim sInfos.LensList(0)

        For i As Integer = 0 To sAperatureName.Length - 1
            sInfos.ApertureList(i).nApertureCodeIndex = i
            sInfos.ApertureList(i).sApertureName = sAperatureName(i)
        Next

        For i As Integer = 0 To sMeasSpeedName.Length - 1
            sInfos.MeasSpeedList(i).nMeasSpeedCodeIndex = i
            sInfos.MeasSpeedList(i).sSpeedName = sMeasSpeedName(i)
        Next

        sInfos.LensList(0).nLensCodeIndex = 0
        sInfos.LensList(0).sLensName = "Nothing"

        ' DeviceInfos = sInfos
        Return True
    End Function

    ''' <summary>
    ''' SR3-AR은 렌즈 선택 명령이 없고, 접사 렌즈를 사용할 경우에는 보정 수치를 넣어줘야 함. 현재 업체에서는 값이 많이 차이가 나지 않아서 그냥 쓰고 있는 상태임.
    ''' </summary>
    ''' <param name="nLensIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function SetLens(ByVal nLensIndex As Integer) As Boolean

        Return True
    End Function

    Public Overrides Function SetAperture(ByVal nAperature As Integer) As Boolean
        If SetMeasuringField(nAperature) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetMeasSpeed(ByVal nMeasSpeed As Integer) As Boolean
        If SetMeasuringSpeed(nMeasSpeed) = False Then Return False
        Return True
    End Function

    Public Overrides Function AutoExpose(ByRef sInfo As DeviceOption) As Boolean
        Return True
    End Function

    Public Overrides Function MeasureStop() As Boolean
        Return True
    End Function
    'Public Overrides Function DownloadData(ByRef outData As tData) As Boolean
    'If ReadData(eMeasMode.eXYZ, outData) = False Then Return False
    'If ReadData(eMeasMode.eSpectrumData, outData) = False Then Return False

    '   Return True
    ' End Function

#End Region

    Public Overrides Function Connection(ByVal Config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim lngConnect As Integer
        Dim blnResult As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False

        If Config.commType = CCommLib.CComCommonNode.eCommType.eUSB Then
            m_ConfigInfo = Config
            If m_bOffLine = True Then
                Return True
            End If

            lngConnect = USBDrv_Init()
            If lngConnect = 0 Then
                m_bIsConnected = False
                Return False
            End If
            ' 
            blnResult = USBDrv_Open(lngConnect)

            If RemoteMode() = False Then Return False

            If GetDeviceinfos(sInfos) = False Then
                Return False
            Else
                MyBase.m_DeviceInfos = sInfos
            End If
        Else


            m_ConfigInfo = Config

            communicator = New CComAPI(m_ConfigInfo.commType)

            communicator.Communicator.TimeOut = 180

            If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
                Return False
            Else
                If RemoteMode() = False Then Return False

                If GetDeviceinfos(sInfos) = False Then
                    Return False
                Else
                    MyBase.m_DeviceInfos = sInfos
                End If

            End If

        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Function Connection() As Boolean
        Dim lngConnect As Integer
        Dim blnResult As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False


        If m_bOffLine = True Then
            Return True
        End If

        m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB

        lngConnect = USBDrv_Init()
        If lngConnect = 0 Then
            m_bIsConnected = False
            Return False
        End If
        ' 
        blnResult = USBDrv_Open(lngConnect)
        If blnResult = False Then Return False

        If RemoteMode() = False Then Return False

        If GetDeviceinfos(sInfos) = False Then
            Return False
        Else
            MyBase.m_DeviceInfos = sInfos
        End If

        m_bIsConnected = True

        Return True
    End Function

    Public Overrides Sub Disconnection()

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            '   If m_bIsConnected = True Then
            USBDrv_Close(m_nDeviceNo)
            '  End If
        Else
            communicator.Communicator.Disconnect()
        End If

        m_bIsConnected = False
    End Sub
    'Public Function DriverOpen() As Boolean

    '    Dim lngConnect As Integer
    '    Dim blnResult As Boolean

    '    If g_bOffLine = True Then
    '        Return True
    '    End If

    '    lngConnect = USBDrv_Init()
    '    If lngConnect = 0 Then
    '        m_bIsConnected = False
    '        Return False
    '    End If

    '    ' 
    '    blnResult = USBDrv_Open(g_nDeviceNo)
    '    If blnResult = False Then
    '        m_bIsConnected = False
    '        Return False
    '    End If

    '    m_bIsConnected = True

    '    Return True

    'End Function

    'Public Function DriverClose() As Boolean

    '    Dim blnResult As Boolean = False

    '    If m_bIsConnected = True Then
    '        blnResult = USBDrv_Close(g_nDeviceNo)
    '    End If

    '    Return blnResult

    'End Function

    Public Function SetRemote() As Boolean
        Dim strBufRead As String = New String(" ", SIZE_BUFFER)

        If SendCommand("RM") = False Then
            Return False
        End If

        Return True

    End Function

    Public Function SetLocal() As Boolean
        Dim strBufRead As String = New String(" ", SIZE_BUFFER)

        If SendCommand("LM") = False Then
            Return False
        End If

        Return True
    End Function

    Public Function SetMeasuringField(ByVal mode As eMeasField) As Boolean
        If m_CurrentAperture <> Nothing Then
            If m_CurrentAperture = mode Then Return True
        End If

        If SendCommand(sMeasuringField(mode)) = False Then
            Return False
        End If

        m_CurrentAperture = mode

        Return True
    End Function

    Public Function SetMeasuringSpeed(ByVal mode As eMeasSpeed) As Boolean
        If m_CurrentSpeedMode <> Nothing Then
            If m_CurrentSpeedMode = mode Then Return True
        End If

        If SendCommand(sMeasuringSpeed(mode)) = False Then
            Return False
        End If

        Return True
    End Function

    Public Function SetDataOutput(ByVal mode As eOutputData) As Boolean

        Dim sCommands() As String = New String() {"D0", "D1"}

        If SendCommand(sCommands(mode)) = False Then
            Return False
        End If

        Return True

    End Function

    Public Function Meas(ByRef outData As tData) As Boolean

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            Meas_USB()
        Else
            Meas_Serial()
        End If

        If m_eCommStatus <> eTransferState.eReciveComplete Then
            Return False
        End If


        outData = m_Data

        Return True
    End Function

    Private Sub Meas_USB()

        Dim lngLength As Integer
        Dim lngSuccessLength As Integer
        Dim sStartTime As Single
        Dim sDeltaTime As Single
        Dim blnResult As Boolean
        Dim strBufferRead As String = New String(" ", SIZE_BUFFER)
        Dim nCntRcvData As Integer = 0
        Dim temp As String

        temp = ""
        strBufferRead = ""

        If SendCommand("ST") = False Then
            m_eCommStatus = eTransferState.eReciveFail_NoData
            Exit Sub
        End If

        strBufferRead = New String("", SIZE_BUFFER)
        lngLength = SIZE_BUFFER

        Dim pos As Integer
        pos = 0

        sStartTime = timer_Sec()

        Do
            Application.DoEvents()
            Thread.Sleep(1)

            strBufferRead = New String(" ", SIZE_BUFFER)
            blnResult = USBDrv_Read(m_nDeviceNo, strBufferRead, lngLength, lngSuccessLength)
            If (blnResult = False) Then
                m_eCommStatus = eTransferState.eReciveFail_NoData
                Exit Do
            End If

            If (lngSuccessLength > 0) Then
                temp = strBufferRead
                If ChkDelimiter(temp) = True And ("OK" <> temp.Substring(0, 2)) Then
                    nCntRcvData += 1
                    DataParser(nCntRcvData, temp)
                Else
                    temp = temp & strBufferRead
                End If
            End If

            pos = InStr(temp, "END")

            If (pos <> 0) Then
                m_eCommStatus = eTransferState.eReciveComplete
                Exit Do
            End If

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > 60 Then
                m_eCommStatus = eTransferState.eReciveFail_TimeOut
                Exit Do
            End If
        Loop

    End Sub

    Private Sub Meas_Serial()

        Dim nCntRcvData As Integer = 0
        Dim sRcvData As String = ""
        Dim temp As String = ""
        Dim sStartTime As Single
        Dim sDeltaTime As Single
        Dim pos As Integer

        Dim arrBuf As Array = Nothing
        Dim chkLastdata As Boolean = False

        pos = 0

        If SendCommand("ST") = False Then
            m_eCommStatus = eTransferState.eReciveFail_NoData
            Exit Sub
        End If

        sStartTime = timer_Sec()

        Do
            communicator.Communicator.ReciveToString(sRcvData)

            If sRcvData = "" Then
                If chkLastdata = True Then
                    m_eCommStatus = eTransferState.eReciveFail_TimeOut
                    Exit Do
                End If
            Else
                chkLastdata = True
                temp = sRcvData
                If ChkDelimiter(temp) = True And ("OK" <> temp.Substring(0, 2)) Then
                    arrBuf = Split(sRcvData, vbCrLf, -1)
                    For i As Integer = 0 To arrBuf.Length - 2
                        nCntRcvData += 1
                        DataParser(nCntRcvData, arrBuf(i))
                    Next
                Else
                    temp = temp & sRcvData
                End If
            End If


            pos = InStr(temp, "END")

            If (pos <> 0) Then
                m_eCommStatus = eTransferState.eReciveComplete
                Exit Do
            End If

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > 60 Then
                m_eCommStatus = eTransferState.eReciveFail_TimeOut
                Exit Do
            End If
        Loop

    End Sub

    Private Function ChkDelimiter(ByVal str As String) As Boolean

        Dim strTemp As String
        Dim pp As Integer = 0

        strTemp = Trim(str)

        pp = InStr(strTemp, Chr(13))

        If pp <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub DataParser(ByVal index As Integer, ByVal str As String)

        Dim sRcvData As String
        Dim nBufWavelength As Integer
        Dim nBufSpectral As Double
        Dim arrBuf As Array

        On Error GoTo errhandler1

        sRcvData = Trim(str)

        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)

        If sRcvData = "END" Then
            Exit Sub
        End If

        ' g_MeasData.bSpectrumMeasured = False

        Select Case index

            Case 1
                '  g_MeasData.dField = CDbl(sRcvData)
            Case 2
                '  g_MeasData.nIntegTime_ms = CInt(sRcvData)
            Case 3
                '   g_MeasData.dRadiance = CDbl(sRcvData)
            Case 4
                m_Data.D1.s2YY = CSng(sRcvData)
                m_Data.D3.s2YY = CSng(sRcvData)
                m_Data.D4.s2YY = CSng(sRcvData)
                m_Data.D6.s2YY = CSng(sRcvData)

                'g_MeasData.dLuminance = CDbl(sRcvData)
            Case 5
                m_Data.D2.s2XX = CSng(sRcvData)
                '     g_MeasData.dX = CDbl(sRcvData)
            Case 6
                m_Data.D2.s3YY = CSng(sRcvData)
                '   g_MeasData.dY = CDbl(sRcvData)
            Case 7
                m_Data.D2.s4ZZ = CSng(sRcvData)
                '  g_MeasData.dZ = CDbl(sRcvData)
            Case 8
                m_Data.D1.s3xx = CSng(sRcvData)
                m_Data.D6.s3xx = CSng(sRcvData)
                '    g_MeasData.CIE1931x = CDbl(sRcvData)
            Case 9
                m_Data.D1.s4yy = CSng(sRcvData)
                m_Data.D6.s4yy = CSng(sRcvData)
                '   g_MeasData.cIE1931y = CDbl(sRcvData)
            Case 10
                m_Data.D3.s3uu = CSng(sRcvData)
                m_Data.D6.s5uu = CSng(sRcvData)
                '  g_MeasData.CIE1976u = CDbl(sRcvData)
            Case 11
                m_Data.D3.s4vv = CSng(sRcvData)
                m_Data.D6.s6vv = CSng(sRcvData)
                'g_MeasData.CIE1976v = CDbl(sRcvData)
            Case 12
                '   g_MeasData.dColorTemp = CDbl(sRcvData)
            Case 13
                '   g_MeasData.dDeviation = CDbl(sRcvData)
            Case Else  'Spectrum
                '  g_MeasData.bSpectrumMeasured = True
                arrBuf = Split(sRcvData, " ", -1)
                m_nWavelength(index - 14) = arrBuf(0)
                m_dSpectralRadiance(index - 14) = arrBuf(1)

                m_Data.D5.i3nm = m_nWavelength
                m_Data.D5.s4Intensity = m_dSpectralRadiance
                '    g_MeasData.Spectrum.nWavelength = g_nWavelength
                ' g_MeasData.Spectrum.dSpectralRadiance = g_dSpectralRadiance

        End Select

        'If g_MeasData.bSpectrumMeasured = True Then

        'End If

errhandler1:

    End Sub

    Private Function USBSendCommand(ByVal sCommand As String) As Boolean

        Dim bRst As Boolean

        Dim strBufWrite As String
        Dim strBufRead As String = New String(" ", SIZE_BUFFER)
        Dim nLen As Integer
        Dim nSuccessLen As Integer
        Dim sStartTime As Single
        Dim sDeltaTime As Single

        ' 명령어 조합
        strBufWrite = sCommand & sDelimiter ' vbCrLf
        nLen = Len(strBufWrite)
        bRst = USBDrv_Write(m_nDeviceNo, strBufWrite, nLen, nSuccessLen)
        If (bRst = False) Then
            ' 몭륪렪봲궻궫귕뢎뿹
            bRst = USBDrv_Close(m_nDeviceNo)
            m_eCommStatus = eTransferState.eTransferFail
            Return False
        End If

        sStartTime = timer_Sec()

        Do
            Application.DoEvents()
            Thread.Sleep(10)

            ' 롷륪긢??벶귒뜛귒
            strBufRead = New String(" ", SIZE_BUFFER)
            bRst = USBDrv_Read(m_nDeviceNo, strBufRead, SIZE_BUFFER, nSuccessLen)  '양승록 확인 필요   USBDrv_Read
            If (bRst = False) Then
                m_eCommStatus = eTransferState.eReciveFail_NoData
                Exit Do
            End If
            If (nSuccessLen > 0) Then
                If ("OK" = strBufRead.Substring(0, 2)) Then
                    m_eCommStatus = eTransferState.eReciveComplete
                    Exit Do
                End If
            End If

            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > 30 Then
                m_eCommStatus = eTransferState.eReciveFail_TimeOut
                Exit Do
            End If
        Loop

        If m_eCommStatus <> eTransferState.eReciveComplete Then
            Return False
        End If

        Return True
    End Function

    Private Function SerialSendCommand(ByVal sCommand As String) As Boolean

        Dim sRcv As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcv) = CComCommonNode.eReturnCode.FuncErr Then Return False

        Return True
    End Function

    Public Function SendCommand(ByVal sCommand As String) As Boolean

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If USBSendCommand(sCommand) = False Then Return False
        Else
            If SerialSendCommand(sCommand) = False Then Return False
        End If

        Return True

    End Function

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function

End Class
