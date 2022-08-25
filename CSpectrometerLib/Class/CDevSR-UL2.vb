Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevSR_UL2

    Inherits CDevSpectrometerCommonNode

    Public communicator As CComAPI

#Region "USB Communication DLL Load"

    Private Declare Function USBDrv_Init Lib "ITFUSBLIBDLL.dll" () As Integer
    Private Declare Function USBDrv_Open Lib "ITFUSBLIBDLL.dll" ( _
                                ByVal DeviceNo As Integer) As Boolean
    Private Declare Function USBDrv_Close Lib "ITFUSBLIBDLL.dll" ( _
                                ByVal DeviceNo As Integer) As Boolean
    Private Declare Function USBDrv_Write Lib "ITFUSBLIBDLL.dll" (ByVal DeviceNo As Integer, ByVal pWriteBuf As String, ByVal WriteLen As Integer, ByRef pWriteLen As Integer) As Boolean
    Private Declare Function USBDrv_Read Lib "ITFUSBLIBDLL.dll" ( _
                                ByVal DeviceNo As Integer, _
                                ByVal pReadBuf As String, _
                                ByVal ReadLen As Integer, _
                                ByRef pReadLen As Integer) As Boolean


#End Region

#Region "Defines"
    Private m_Data As tData
    Private m_nWavelength(399) As Integer
    Private m_dSpectralRadiance(399) As Double
    Private Const sDelimiter As String = vbCrLf
    Private m_bOffLine As Boolean
    Private m_nDeviceNo As Integer

    Public Event evDataTransfered(ByVal str As String, ByVal nState As eTransferState)
    Private m_eCommStatus As eTransferState
    Private Const SIZE_BUFFER As Integer = 64

    Private sAperatureName() As String = New String() {"2", "1", "0.2", "0.1'"}
    Private sMeasSpeedName() As String = New String() {"Nomal", "Fast"}

    Private sMeasuringField() As String = New String() {"FLD1", "FLD2", "FLD3", "FLD4"}
    Private sMeasuringSpeed() As String = New String() {"NS", "HS"}

#End Region

#Region "Enum"

    Public Enum eTransferState
        eReady
        eTransferingData
        eTransferFail
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Public Enum eMeasField
        e2
        e1
        e0R2
        e0R1
    End Enum

    Public Enum eMeasSpeed
        eNOMAL
        eFAST
    End Enum
#End Region


#Region "Creator, Disposer, Init"

    Public Sub New()
        MyBase.New()
        m_MyModel = eModel.SPECTROMETER_SRUL2
        m_bIsConnected = False
        m_bOffLine = False
        m_nDeviceNo = 1
    End Sub

#End Region

#Region "API Functions"

    Public Overrides Function Connection() As Boolean
        Dim lngConnect As Integer
        Dim blnResult As Boolean
        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False

        If m_bOffLine = True Then
            Return True
        End If

        lngConnect = USBDrv_Init()
        If lngConnect = 0 Then
            m_bIsConnected = False
            Return False
        End If
        ' 
        blnResult = USBDrv_Open(m_nDeviceNo)
        If blnResult = False Then Return False

        If GetDeviceinfos(sInfos) = False Then
            Return False
        Else
            MyBase.m_DeviceInfos = sInfos
        End If

        m_bIsConnected = True

        Return True
    End Function

    Public Overrides Function Connection(config As CCommLib.CComCommonNode.sCommInfo) As Boolean

        Dim sInfos As DeviceOption = Nothing

        m_bIsConnected = False
        m_ConfigInfo = config
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else

            If SetRemote() = False Then
                Return False
            End If

            If GetDeviceinfos(sInfos) = False Then
                Return False
            Else
                MyBase.m_DeviceInfos = sInfos
            End If

        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        '  If m_bIsConnected = True Then
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            communicator.Communicator.Disconnect()
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            USBDrv_Close(m_nDeviceNo)
        End If

        'End If
        m_bIsConnected = False
    End Sub

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

    Public Overrides Function SetDeviceInfos(ByVal sInfos As DeviceOption) As Boolean
        With sInfos
            If SetMeasuringField(.ApertureList(.ApertureIndex).nApertureCodeIndex) = False Then Return False
            If SetMeasuringSpeed(.MeasSpeedList(.MeasSpeedIndex).nMeasSpeedCodeIndex) = False Then Return False
        End With
        Return True
    End Function

    Public Overrides Function GetDeviceinfos(ByRef sInfos As DeviceOption) As Boolean  'SR-3AR은 Aperature 및 Speed 모드가 고정
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
        Return False
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

#End Region

#Region "Functions"
    Public Function SetRemote() As Boolean
        Dim sCommand As String = "RM"
        Dim sRcvData As String = ""

        Select Case m_ConfigInfo.commType
            Case CComCommonNode.eCommType.eSerial
                If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
                If ErrorCheck(sRcvData) = False Then Return False
            Case CComCommonNode.eCommType.eUSB
                If SendCommand(sCommand) = False Then Return False
        End Select
        Return True
    End Function

    Public Function SetLocal() As Boolean
        Dim sCommand As String = "LM"
        Dim sRcvData As String = ""

        Select Case m_ConfigInfo.commType
            Case CComCommonNode.eCommType.eSerial
                If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
                If ErrorCheck(sRcvData) = False Then Return False
            Case CComCommonNode.eCommType.eUSB
                If SendCommand(sCommand) = False Then Return False
        End Select
        Return True
    End Function

    Public Function SetMeasuringField(ByVal mode As eMeasField) As Boolean
        Dim sRcvData As String = ""
        Select Case m_ConfigInfo.commType
            Case CComCommonNode.eCommType.eSerial
                If communicator.Communicator.SendToString(sMeasuringField(mode), sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
                If ErrorCheck(sRcvData) = False Then Return False
            Case CComCommonNode.eCommType.eUSB
                If SendCommand(sMeasuringField(mode)) = False Then Return False
        End Select
        Return True
    End Function

    Public Function SetMeasuringSpeed(ByVal nMeasSpeed As eMeasSpeed) As Boolean
        Dim sRcvData As String = ""
        Select Case m_ConfigInfo.commType
            Case CComCommonNode.eCommType.eSerial
                If communicator.Communicator.SendToString(sMeasuringSpeed(nMeasSpeed), sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
                If ErrorCheck(sRcvData) = False Then Return False
            Case CComCommonNode.eCommType.eUSB
                If SendCommand(sMeasuringSpeed(nMeasSpeed)) = False Then Return False
        End Select
        Return True
    End Function

    Public Function Meas(ByRef outdata As tData) As Boolean
        Dim sCommand As String = "ST"

        Select Case m_ConfigInfo.commType
            Case CComCommonNode.eCommType.eSerial
                If Meas_Serial(sCommand, outdata) = False Then Return False
            Case CComCommonNode.eCommType.eUSB
                If Meas_USB(sCommand, outdata) = False Then Return False
        End Select
        Return True
    End Function

    
    Public Function SendCommand(ByVal sCommand As String) As Boolean

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

    Private Function timer_Sec() As Single
        Return (Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000)
    End Function

    Private Function Meas_USB(ByVal sCommand As String, ByRef outData As tData) As Boolean
        Dim blnResult As Boolean

        ' Dim strBufferWrite As String
        Dim strBufferRead As String = New String(" ", SIZE_BUFFER)
        Dim lngLength As Integer
        Dim lngSuccessLength As Integer
        Dim sStartTime As Single
        Dim sDeltaTime As Single
        Dim nCntRcvData As Integer = 0

        strBufferRead = ""
        Dim temp As String
        temp = ""


        If SendCommand(sCommand) = False Then
            Return False
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

        If m_eCommStatus <> eTransferState.eReciveComplete Then
            Return False
        End If


        outData = m_Data
        Return True
    End Function

    Private Function Meas_Serial(ByVal sCommand As String, ByRef outData As tData) As Boolean

        Dim sRcvData As String = ""
        Dim arrBuf As Array = Nothing
        Dim arrBufSepctrum(1) As String
        Dim dCRI As Double = 0

        If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        If ErrorCheck(sRcvData) = False Then Return False

        sRcvData = ""

        Thread.Sleep(100)

        Do
            communicator.Communicator.SendToString(sCommand, sRcvData)
            If sRcvData = "" Then
            Else
                If sRcvData.Contains("END") = False Then
                Else
                    arrBuf = Split(sRcvData, vbCrLf, -1)

                    With m_Data
                        .GetInfo.sApertureName = CStr(arrBuf(1))
                        .GetInfo.nExposureTime = CStr(arrBuf(2))
                        .D5.s2IntegIntensity = CDbl(arrBuf(3))
                        .D1.s2YY = CSng(arrBuf(4))
                        .D2.s3YY = CSng(arrBuf(4))
                        .D3.s2YY = CSng(arrBuf(4))
                        .D4.s2YY = CSng(arrBuf(4))
                        .D6.s2YY = CSng(arrBuf(4))
                        .D2.s2XX = CSng(arrBuf(5))
                        .D2.s4ZZ = CSng(arrBuf(7))
                        .D1.s3xx = CSng(arrBuf(8))
                        .D1.s4yy = CSng(arrBuf(9))
                        .D3.s3uu = CSng(arrBuf(10))
                        .D3.s4vv = CSng(arrBuf(11))
                        .D6.s3xx = CSng(arrBuf(8))
                        .D6.s4yy = CSng(arrBuf(9))
                        .D6.s5uu = CSng(arrBuf(10))
                        .D6.s6vv = CSng(arrBuf(11))
                        .D4.s3KelvinT = CSng(arrBuf(12))

                        For i As Integer = 14 To arrBuf.Length - 1
                            arrBufSepctrum = Split(arrBuf(i), " ", -1)
                            m_nWavelength(i - 14) = arrBufSepctrum(0)
                            m_dSpectralRadiance(i - 4) = arrBufSepctrum(1)
                        Next

                        .D5.i3nm = m_nWavelength.Clone
                        .D5.s4Intensity = m_dSpectralRadiance.Clone

                        If arrBuf(arrBuf.Length) = "END" Then
                            outData = m_Data
                            Exit Do
                        End If

                    End With
                End If
            End If
        Loop
        Return True
    End Function

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
        Dim dCRI As Double

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

    Private Function ErrorCheck(ByVal str As String) As Boolean

        Dim sError As String = str.Substring(0, 2)

        If sError <> "OK" Then
            MsgBox("ReceiveData Error")
            Return False
        End If
        Return True
    End Function
#End Region
End Class
