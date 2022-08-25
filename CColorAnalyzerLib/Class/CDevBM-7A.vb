Imports System
Imports System.IO
Imports System.Threading
Imports System.Math
Imports CCommLib
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class CDevBM_7A
    Inherits CDevColorAnalyzerCommonNode

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


#Region "Define"

    Dim m_SettingInfos As sSettings
    Dim m_MeasDatas As sDataInfos

#Region "Structure"

    Public Structure sSettings
        Dim speedMode As eMeasSpeed
        Dim RangeMode As eMeasRange
        Dim AverageMode As eAverage
        Dim nFactorNumber As Integer
        Dim RangeXFactor As Double
        Dim RangeYFactor As Double
        Dim RangeZFactor As Double
    End Structure

    Public Structure sDatas
        Dim dY As Double
        Dim dCIEx As Double
        Dim dCIEy As Double
    End Structure

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
        _2
        _1
        _0R2
        _0R1
    End Enum

    Public Enum eMeasSpeed
        _SLOW
        _FAST
    End Enum

    Public Enum eMeasRange
        _AUTO
        _MANUAL
    End Enum

    Public Enum eMeasCorrection
        _Normal
        _Direct
    End Enum

    Public Enum eAverage
        _SINGLE
        _AVERAGE
    End Enum

#End Region


#End Region

#Region "Define Global Variable"

    '  Private g_bIsConnected As Boolean
    Private m_bOffLine As Boolean

    Private m_nDeviceNo As Integer

    Private Const ReceiveTerminator As String = vbCrLf
    Private Const SendTerminator As String = vbCrLf
    Private Const sEndStr As String = "END"

    Public Event evDataTransfered(ByVal str As String, ByVal nState As eTransferState)
    Private m_eCommStatus As eTransferState
    Private Const SIZE_BUFFER As Integer = 64

#End Region

#Region "Creator, Disposer and Init"

    Public Sub New()
        MyBase.New()
        MyBase.m_bIsConnected = False

        m_bOffLine = False
        m_nDeviceNo = 1
        m_MyModel = eModel.eColorAnalyzer_BM7A
    End Sub

#End Region




#Region "Communication Functions"

    Public Overrides Function Connection() As Boolean

        Dim lngConnect As Integer
        Dim blnResult As Boolean
        Dim sInfos As sSetInfos = Nothing
        m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB
        Dim sModel As String = ""

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

        If GetSettings(sInfos) = False Then
            Return False
        Else
            MyBase.m_DeviceInfos = sInfos
        End If

        If GetModelName(sModel) = False Then Return False

        m_bIsConnected = True

        Return True
        MyBase.m_bIsConnected = True
        Return True
    End Function

    Public Overrides Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean

        Dim sInfos As sSetInfos = Nothing
        Dim sModel As String = ""
        m_bIsConnected = False
        m_ConfigInfo = config
        comm = New CComAPI(m_ConfigInfo.commType)

        If comm.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            Return False
        Else

            'If SetRemote() = False Then
            '    Return False
            'End If

            If GetSettings(sInfos) = False Then
                Return False
            Else
                MyBase.m_DeviceInfos = sInfos
            End If

            If GetModelName(sModel) = False Then Return False
        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            comm.Communicator.Disconnect()
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            USBDrv_Close(m_nDeviceNo)
        End If

        '   End If
        m_bIsConnected = False
    End Sub

    Public Overrides Function SetSettings(infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        If SetSpeedMode(infos.sBM7ASettings.speedMode) = False Then Return False
        If SetAverage(infos.sBM7ASettings.AverageMode) = False Then Return False
        If SetRangeMode(infos.sBM7ASettings.RangeMode, infos.sBM7ASettings.RangeXFactor, _
                        infos.sBM7ASettings.RangeYFactor, infos.sBM7ASettings.RangeZFactor) = False Then Return False
        If SetCorrectionFactorNumber(infos.sBM7ASettings.nFactorNumber) = False Then Return False

        Return True
    End Function

    Public Overrides Function Measure(ByRef measuredDatas As CDevColorAnalyzerCommonNode.sDataInfos) As Boolean

        Dim sCommand As String = "ST"

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If Meas_Serial(sCommand, measuredDatas) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If Meas_USB(sCommand, measuredDatas) = False Then Return False
        End If

        Return True
    End Function

    Public Overrides Function GetSettings(ByRef infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        Return True
    End Function

    Public Function ZeroAdjustment() As Boolean

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            Dim sCommand As String = "CA"
            Dim sRcvData As String = ""
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False

            If comm.Communicator.ReciveToString(sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then

        End If

        Return True
    End Function

    Public Function SetSpeedMode(ByVal mode As eMeasSpeed) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        If mode = eMeasSpeed._FAST Then
            sCommand = "TF"
        ElseIf mode = eMeasSpeed._SLOW Then
            sCommand = "TS"
        End If
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False

        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function SetRangeMode(ByVal mode As eMeasRange, ByVal X As Double, ByVal Y As Double, ByVal Z As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        If X < 1 Or X > 5 Then
            MsgBox("Range value Error")
            Return False
        End If
        If Y < 1 Or Y > 5 Then
            MsgBox("Range value Error")
            Return False
        End If
        If Z < 1 Or Z > 5 Then
            MsgBox("Range value Error")
            Return False
        End If

        If mode = eMeasRange._AUTO Then
            sCommand = "MA"
        ElseIf mode = eMeasRange._MANUAL Then
            sCommand = "MM_X" & X & "_Y" & Y & "_Z" & Z
        End If

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function GetCorrectionFactorNumber(ByRef dFactorNumber As Double) As Boolean
        Dim sCommand As String = "FR"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False

            dFactorNumber = sBufData(1)
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function SetCorrectionFactorNumber(ByVal dFactorNumber As Double) As Boolean
        Dim sCommand As String = "F"
        Dim sRcvData As String = ""

        If dFactorNumber < 0 Or dFactorNumber > 15 Then
            MsgBox("Correction FactorNumber value Error")
            Return False
        End If
        sCommand = sCommand & dFactorNumber
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function GetCorrectionFactor(ByRef dFactor As Double) As Boolean
        Dim sCommand As String = "R"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False
            dFactor = sBufData(1)

        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function SetCorrectionFactor(ByVal dFactor As Double) As Boolean
        Dim sCommand As String = "F"
        Dim sRcvData As String = ""

        If dFactor < 1 Or dFactor > 15 Then
            MsgBox("Correction FactorNumber value Error")
            Return False
        End If
        sCommand = sCommand & dFactor
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function ClearCorrectionFactor(ByVal dFactorNumber As Double) As Boolean
        Dim sCommand As String = "CF"
        Dim sRcvData As String = ""

        If dFactorNumber < 1 Or dFactorNumber > 15 Then
            MsgBox("Correction FactorNumber value Error")
            Return False
        End If

        sCommand = sCommand & dFactorNumber
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function SetCorrectionMode(ByVal mode As eMeasCorrection) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        If mode = eMeasCorrection._Normal Then
            sCommand = "FK1"
        ElseIf mode = eMeasCorrection._Direct Then
            sCommand = "FK2"
        End If

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function GetCorrectionMode(ByRef mode As eMeasCorrection) As Boolean
        Dim sCommand As String = "FKR"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing
        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False

            mode = sBufData(1)

        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function


    Public Function GetModelName(ByRef sModel As String) As Boolean
        Dim sCommand As String = "WHO"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

            If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False

            sModel = sBufData(1)

        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If

        Return True
    End Function

    Public Function GetVersion(ByRef sVersion As String) As Boolean
        Dim sCommand As String = "VER"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
              If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False

            sVersion = sBufData(1)
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function GetSerialNumber(ByRef sSerialNumber As String) As Boolean
        Dim sCommand As String = "SRL"
        Dim sRcvData As String = ""
        Dim sBufData() As String = Nothing

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
         If ErrorCheck(sRcvData) = False Then Return False
            If DivideAndGetEachData(sRcvData, sBufData) = False Then Return False

            sSerialNumber = sBufData(1)
        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
        Return True
    End Function

    Public Function SetAverage(ByVal mode As eAverage) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        If mode = eAverage._AVERAGE Then
            sCommand = "AM"
        ElseIf mode = eAverage._SINGLE Then
            sCommand = "SM"
        End If

        If m_ConfigInfo.commType = CComCommonNode.eCommType.eSerial Then
            If comm.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False
            If ErrorCheck(sRcvData) = False Then Return False

        ElseIf m_ConfigInfo.commType = CComCommonNode.eCommType.eUSB Then
            If SendCommand(sCommand) = False Then Return False
        End If
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
        strBufWrite = sCommand & SendTerminator  ' vbCrLf
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

    Private Function Meas_USB(ByVal sCommand As String, ByRef outData As sDataInfos) As Boolean
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


        outData = m_MeasDatas
        Return True
    End Function

    Private Function Meas_Serial(ByVal sCommand As String, ByRef outData As sDataInfos) As Boolean

        Dim sRcvData As String = ""
        Dim arrBuf As Array = Nothing
        Dim arrBufSepctrum(1) As String
        '  Dim dCRI As Double
        comm.Communicator.TimeOut = 30

        If comm.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False

        If ErrorCheck(sRcvData) = False Then Return False

        sRcvData = ""

        Thread.Sleep(100)

        Do
            Try
                If comm.Communicator.ReciveToString(sRcvData) = CComCommonNode.eReturnCode.FuncErr Then Return False
                If sRcvData = "" Then
                Else
                    If sRcvData.Contains("END") = False Then
                    Else
                        sRcvData = sRcvData.TrimEnd(vbLf)
                        sRcvData = sRcvData.TrimEnd(vbCr)
                        arrBuf = Split(sRcvData, vbCrLf, -1)

                        With m_MeasDatas

                            Try
                                .Data.dY = CSng(arrBuf(11))
                            Catch ex As Exception
                                .Data.dY = 0
                            End Try
                            Try
                                .Data.dLuminance = CSng(arrBuf(11))
                            Catch ex As Exception
                                .Data.dLuminance = 0
                            End Try
                            Try
                                .Data.dX = CSng(arrBuf(12))
                            Catch ex As Exception
                                .Data.dX = 0
                            End Try
                            Try
                                .Data.dZ = CSng(arrBuf(14))
                            Catch ex As Exception
                                .Data.dZ = 0
                            End Try
                            Try
                                .Data.dCIEx = CSng(arrBuf(15))
                            Catch ex As Exception
                                .Data.dCIEx = 0
                            End Try
                            Try
                                .Data.dCIEy = CSng(arrBuf(16))
                            Catch ex As Exception
                                .Data.dCIEy = 0
                            End Try
                            Try
                                .Data.dCIE1976u = CSng(arrBuf(17))
                            Catch ex As Exception
                                .Data.dCIE1976u = 0
                            End Try
                            Try
                                .Data.dCIE1976v = CSng(arrBuf(18))
                            Catch ex As Exception
                                .Data.dCIE1976v = 0
                            End Try
                            Try
                                .Data.CCT = CSng(arrBuf(19))
                            Catch ex As Exception
                                .Data.CCT = 0
                            End Try

                            If arrBuf(arrBuf.Length - 1) = "END" Then
                                outData = m_MeasDatas
                                Exit Do
                            End If

                        End With
                    End If
                End If
            Catch ex As Exception
                Return False
            End Try

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
                m_MeasDatas.Data.dY = CSng(sRcvData)
                m_MeasDatas.Data.dLuminance = CSng(sRcvData)
                'g_MeasData.dLuminance = CDbl(sRcvData)
            Case 5
                m_MeasDatas.Data.dX = CSng(sRcvData)
                '     g_MeasData.dX = CDbl(sRcvData)
            Case 6
                m_MeasDatas.Data.dY = CSng(sRcvData)
                '   g_MeasData.dY = CDbl(sRcvData)
            Case 7
                m_MeasDatas.Data.dZ = CSng(sRcvData)
                '  g_MeasData.dZ = CDbl(sRcvData)
            Case 8
                m_MeasDatas.Data.dCIEx = CSng(sRcvData)
                m_MeasDatas.Data.dCIEx = CSng(sRcvData)
                '    g_MeasData.CIE1931x = CDbl(sRcvData)
            Case 9
                m_MeasDatas.Data.dCIEy = CSng(sRcvData)
                m_MeasDatas.Data.dCIEy = CSng(sRcvData)
                '   g_MeasData.cIE1931y = CDbl(sRcvData)
            Case 10
                m_MeasDatas.Data.dCIE1976u = CSng(sRcvData)
                m_MeasDatas.Data.dCIE1976u = CSng(sRcvData)
                '  g_MeasData.CIE1976u = CDbl(sRcvData)
            Case 11
                m_MeasDatas.Data.dCIE1976v = CSng(sRcvData)
                m_MeasDatas.Data.dCIE1976v = CSng(sRcvData)
                'g_MeasData.CIE1976v = CDbl(sRcvData)
            Case 12
                '   g_MeasData.dColorTemp = CDbl(sRcvData)
            Case 13
                '   g_MeasData.dDeviation = CDbl(sRcvData)
            Case Else  'Spectrum
                '  g_MeasData.bSpectrumMeasured = True


        End Select

        'If g_MeasData.bSpectrumMeasured = True Then

        'End If

errhandler1:

    End Sub

    Private Function ErrorCheck(ByVal str As String) As Boolean

        Dim sErrorchk As String
        Dim sErrorBuf() As String = Nothing
        sErrorBuf = str.Split(vbCrLf)

        If sErrorBuf(0).Length < 4 Then
            sErrorchk = str.Substring(0, 2)
        Else
            sErrorchk = str.Substring(0, 4)
        End If
        If sErrorchk = "OK" Then
            Return True
        ElseIf sErrorchk = "E003" Then
            MsgBox("Displayed when there is an abnormal measurement angle.")
            Return False
        ElseIf sErrorchk = "E004" Then
            MsgBox("Displayed when a measurement command is sent before executing zero adjustment.")
            Return False
        ElseIf sErrorchk = "E005" Then
            MsgBox("Displayed when time has elapsed since the previous calibration and it is necessary to execute calibration by TOPCON TECHNOHOUSE factory.")
            Return False
        ElseIf sErrorchk = "E006" Then
            MsgBox("Displayed when the value of the correction factor is abnormal.")
            Return False
        ElseIf sErrorchk = "E007" Then
            MsgBox("Displayed when the value of the area correction factor is abnormal.")
            Return False
        ElseIf sErrorchk = "E008" Then
            MsgBox("Area correction limit write error.")
            Return False
        ElseIf sErrorchk = "E009" Then
            MsgBox("Area correction limit write error.")
            Return False
        ElseIf sErrorchk = "E010" Then
            MsgBox("Area correction limit write error.")
            Return False
        ElseIf sErrorchk = "E011" Then
            MsgBox("Area correction limit write error.")
            Return False
        ElseIf sErrorchk = "E012" Then
            MsgBox("Displayed when the signal correction/direct correction dip switch setting and communication command setting do not match.")
            Return False
        ElseIf sErrorchk = "E013" Then
            MsgBox("Displayed when zero-adjustment is abnormal.")
            Return False
        ElseIf sErrorchk = "E014" Then
            MsgBox("Displayed when the internal shutter is abnormal.")
            Return False
        ElseIf sErrorchk = "E015" Then
            MsgBox("Displayed when average measurmenet is abnormal.")
            Return False
        End If

    End Function

    Private Function DivideAndGetEachData(ByVal In_strLineInput As String, ByRef Out_strEach() As String) As Boolean
        Dim sBuf() As String = Nothing

        In_strLineInput.TrimEnd("")
        In_strLineInput = In_strLineInput.TrimEnd(vbLf)
        In_strLineInput = In_strLineInput.TrimEnd(vbCr)
        sBuf = In_strLineInput.Split(vbCrLf)
        For i As Integer = 0 To sBuf.Length - 1
            sBuf(i) = sBuf(i).TrimStart(vbLf)
        Next

        If sBuf(sBuf.Length - 1) <> "END" Then Return False

        Out_strEach = sBuf.Clone
        Return True
    End Function
#End Region

End Class
