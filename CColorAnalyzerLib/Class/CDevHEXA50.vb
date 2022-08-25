Imports System
Imports System.IO
Imports System.Threading
Imports System.Math
Imports CCommLib
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class CDevHEXA50

    Inherits CDevColorAnalyzerCommonNode



#Region "Define"

    Dim m_SettingInfos As sSettings
    Dim m_MeasDatas As sDataInfos
    Public sIntegrationTime() As String = New String() {"1ms", "2ms", "4ms", "8ms", "16ms", "32ms", "64ms", "128ms", "256ms", "512ms", "1024ms"}
    Public sIntegrationTimeValue() As Double = New Double() {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024}
    Public sReferenceCurrent() As String = New String() {"20(Amp5)", "80(Amp4)", "320(Amp3)", "1280(Amp2)", "5120(Amp1)"}
    Public sDivider() As String = New String() {"1", "2", "4", "8", "16"}
    Public sOffset() As String = New String() {"0", "15", "31", "63"}
    Dim iowHandles(IOWKIT_MAX_DEVICES) As Integer
    Dim m_addr As Integer
    Dim m_Range As Integer
    Dim bDataTrue As Boolean

#Region "Register Address"

    Const MC30_SETSTX As Byte = &H2
    Const MC30_GETSTX As Byte = &H3
    Const MC30_SETADD As Byte = &HC3
    Const MC30_SETREG As Byte = &HC2
    Const MC30_SETREG2 As Byte = &HC4
    Const MC30_GETADD As Byte = &HB
    Const MC30_I2CWADD As Byte = &HE8
    Const MC30_I2CRADD As Byte = &HE9
    Const MC30_I2CRADDTEMP As Byte = &H90
    Const MC30_OSRREG As Byte = &H0
    Const MC30_AGENREG As Byte = &H2
    Const MC30_GREGLREG As Byte = &H6
    Const MC30_GREGHREG As Byte = &H7
    Const MC30_OPTREG As Byte = &H8
    Const MC30_BREAK As Byte = &H9
    Const MC30_EDGES As Byte = &HA

#End Region

#Region "Structure"

    Public Structure sSettings
        Dim CalibrationData() As sCalibrationData
        Dim nKFactorIndx As Integer
        Dim SettingInfo() As sSubSettings
        Dim Range As eRange
        Dim RangeIndex As Integer
        Dim RangeValue() As Double
        Dim FitParam() As sFitParam
        Dim Mode As eMeasMode
    End Structure

    Public Structure sFitParam
        Dim XFitA As Double
        Dim XFitB As Double
        Dim XFitC As Double
        Dim XFitD As Double
        Dim XFitE As Double
        Dim XFitF As Double
        Dim YFitA As Double
        Dim YFitB As Double
        Dim YFitC As Double
        Dim YFitD As Double
        Dim YFitE As Double
        Dim YFitF As Double
        Dim ZFitA As Double
        Dim ZFitB As Double
        Dim ZFitC As Double
        Dim ZFitD As Double
        Dim ZFitE As Double
        Dim ZFitF As Double
        Dim LFit As Double
        Dim xFit As Double
        Dim yFit As Double
    End Structure
    Public Structure sDatas
        Dim dACDXdigit As Double
        Dim dACDYdigit As Double
        Dim dACDZdigit As Double
        Dim dADCX As Double
        Dim dADCY As Double
        Dim dADCZ As Double
        Dim dX As Double
        Dim dY As Double
        Dim dZ As Double
        Dim dCIEx As Double
        Dim dCIEy As Double
        Dim dCIE1960u As Double
        Dim dCIE1960v As Double
        Dim dCIE1976u As Double
        Dim dCIE1976v As Double
        Dim dLprime As Double
        Dim dApirme As Double
        Dim dBprime As Double
        Dim dTemp As Double
        Dim CCT As Double
    End Structure


    Public Structure sCalibrationData
        Dim ReferenceData(,) As Double
        Dim SensorData(,) As Double
        Dim ElecOffset() As Double
        Dim BWOffset() As Double
        Dim KFactor(,) As Double
    End Structure

    Public Structure sSubSettings
        Dim Mode As eMode
        Dim IntegTime As eIntegTime
        Dim IntegTimeVal As Double
        Dim ReferenceCurrent As eRefCurrent
        Dim Divider As eDivider
        Dim Offset As eOffset
        Dim Delaytime As Double
        Dim NumofData As Double
        Dim sSerialNumber As String
        Dim dFactor As Double
    End Structure
#End Region

#Region "Enum"
    Public Enum eMode
        eCommand
        eContinuous
    End Enum

    Public Enum eMeasMode
        eAuto
        eManual
    End Enum

    Public Enum eIntegTime
        e1ms
        e2ms
        e4ms
        e8ms
        e16ms
        e32ms
        e64ms
        e128ms
        e256ms
        e512ms
        e1024ms
    End Enum

    Public Enum eRefCurrent
        e20
        e80
        e320
        e1280
        e5120
    End Enum

    Public Enum eDivider
        e1
        e2
        e4
        e8
        e16
    End Enum

    Public Enum eOffset
        e0
        e15
        e31
        e63
    End Enum

    Public Enum eRange
        eAuto
        e1
        e2
        e3
        e4
        e5
    End Enum
#End Region

#End Region


#Region "Creator, Disposer and Init"

    Public Sub New(ByVal addr As Integer)
        MyBase.New()
        MyBase.m_bIsConnected = False
        comm = New CComAPI(CComCommonNode.eCommType.eUSB)  ' = New CComSerial
        m_MyModel = eModel.eColorAnalyzer_HEXA50
        m_addr = addr
    End Sub

#End Region

#Region "Communication Functions"

    Public Overrides Function Connection() As Boolean
        Dim numIows As Integer
        Dim nSerialNumber() As Byte = Nothing

        Try
            iowHandles(0) = IowKitOpenDevice()
            ' Fail if can't open
            If iowHandles(0) = 0 Then
                ' Barf and exit from program
                MsgBox("Can not open device!", 0, "Error")
                Return False
            End If

            ReDim m_DeviceInfos.sHEXA50Settings.SettingInfo(4)

            If GetNumOfDevices(numIows) = False Then Return False

            If GetDeviceHandles(numIows) = False Then Return False

            For i As Integer = 0 To numIows - 1
                If GetSerialNumber(i, nSerialNumber) = False Then Return False
            Next

            For i As Integer = 0 To m_DeviceInfos.sHEXA50Settings.SettingInfo.Length - 1
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).sSerialNumber = System.Text.UnicodeEncoding.Unicode.GetString(nSerialNumber)
            Next
            For i As Integer = 0 To numIows - 1
                If Ready(i) = False Then Return False
            Next

            MyBase.m_bIsConnected = True
        Catch ex As Exception
            MyBase.m_bIsConnected = False
            Return False
        End Try

        Return True
    End Function

    Public Overrides Sub Disconnection(ByVal nAddress As Integer)
        Try
            IowKitCloseDevice(iowHandles(nAddress))
            m_bIsConnected = False
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Overrides Function Initialization() As Boolean
        Return True
    End Function

    Public Overrides Function SetSettings(ByVal infos As sSetInfos) As Boolean

        m_Range = 0
        If SubSettings(infos) = False Then Return False

        If SetFitParam(infos) = False Then Return False
        Return True
    End Function

    Public Overrides Function SetSettingsOneRange(ByVal nRangeIndex As Integer, ByVal infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        m_Range = nRangeIndex

        If SubSettings(infos) = False Then Return False

        If SetFitParam(infos) = False Then Return False

        Return True
    End Function

    Public Function SubSettings(ByVal infos As sSetInfos) As Boolean

        If SetAllConfigReg(m_addr, infos.sHEXA50Settings.SettingInfo(m_Range)) = False Then Return False
        infos.sHEXA50Settings.SettingInfo(m_Range).dFactor = CalculationFactors(infos.sHEXA50Settings.SettingInfo(m_Range))

        ReDim m_DeviceInfos.sHEXA50Settings.CalibrationData(infos.sHEXA50Settings.CalibrationData.Length - 1)
        ReDim m_DeviceInfos.sHEXA50Settings.SettingInfo(infos.sHEXA50Settings.SettingInfo.Length - 1)

        For i As Integer = 0 To infos.sHEXA50Settings.CalibrationData.Length - 1
            If infos.sHEXA50Settings.CalibrationData(i).BWOffset IsNot Nothing Then
                m_DeviceInfos.sHEXA50Settings.CalibrationData(i).BWOffset = infos.sHEXA50Settings.CalibrationData(i).BWOffset.Clone
                m_DeviceInfos.sHEXA50Settings.CalibrationData(i).ElecOffset = infos.sHEXA50Settings.CalibrationData(i).ElecOffset.Clone
                m_DeviceInfos.sHEXA50Settings.CalibrationData(i).KFactor = infos.sHEXA50Settings.CalibrationData(i).KFactor.Clone
                m_DeviceInfos.sHEXA50Settings.CalibrationData(i).ReferenceData = infos.sHEXA50Settings.CalibrationData(i).ReferenceData.Clone
                m_DeviceInfos.sHEXA50Settings.CalibrationData(i).SensorData = infos.sHEXA50Settings.CalibrationData(i).SensorData.Clone
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).Divider = infos.sHEXA50Settings.SettingInfo(i).Divider
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).IntegTime = infos.sHEXA50Settings.SettingInfo(i).IntegTime
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).IntegTimeVal = infos.sHEXA50Settings.SettingInfo(i).IntegTimeVal
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).Mode = infos.sHEXA50Settings.SettingInfo(i).Mode
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).NumofData = infos.sHEXA50Settings.SettingInfo(i).NumofData
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).Offset = infos.sHEXA50Settings.SettingInfo(i).Offset
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).ReferenceCurrent = infos.sHEXA50Settings.SettingInfo(i).ReferenceCurrent
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).Delaytime = infos.sHEXA50Settings.SettingInfo(i).Delaytime
                m_DeviceInfos.sHEXA50Settings.SettingInfo(i).dFactor = infos.sHEXA50Settings.SettingInfo(i).dFactor
            End If
        Next
        Return True
    End Function

    Public Function SetFitParam(ByVal infos As sSetInfos) As Boolean

        ReDim m_DeviceInfos.sHEXA50Settings.FitParam(infos.sHEXA50Settings.FitParam.Length - 1)

        For i As Integer = 0 To infos.sHEXA50Settings.FitParam.Length - 1
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitA = infos.sHEXA50Settings.FitParam(i).XFitA
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitB = infos.sHEXA50Settings.FitParam(i).XFitB
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitC = infos.sHEXA50Settings.FitParam(i).XFitC
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitD = infos.sHEXA50Settings.FitParam(i).XFitD
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitE = infos.sHEXA50Settings.FitParam(i).XFitE
            m_DeviceInfos.sHEXA50Settings.FitParam(i).XFitF = infos.sHEXA50Settings.FitParam(i).XFitF
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitA = infos.sHEXA50Settings.FitParam(i).YFitA
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitB = infos.sHEXA50Settings.FitParam(i).YFitB
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitC = infos.sHEXA50Settings.FitParam(i).YFitC
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitD = infos.sHEXA50Settings.FitParam(i).YFitD
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitE = infos.sHEXA50Settings.FitParam(i).YFitE
            m_DeviceInfos.sHEXA50Settings.FitParam(i).YFitF = infos.sHEXA50Settings.FitParam(i).YFitF
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitA = infos.sHEXA50Settings.FitParam(i).ZFitA
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitB = infos.sHEXA50Settings.FitParam(i).ZFitB
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitC = infos.sHEXA50Settings.FitParam(i).ZFitC
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitD = infos.sHEXA50Settings.FitParam(i).ZFitD
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitE = infos.sHEXA50Settings.FitParam(i).ZFitE
            m_DeviceInfos.sHEXA50Settings.FitParam(i).ZFitF = infos.sHEXA50Settings.FitParam(i).ZFitF
        Next


        Return True
    End Function

    'Public Overrides Function Connection(ByVal info As stSgConfig) As Boolean

    '    Dim ret As Integer = comm.Communicator.Connect(info.sSerialInfo)

    '    If ret <> CComSerial.eReturnCode.OK Then '1 Then
    '        Return False
    '    End If

    '    Return True
    'End Function



#End Region


#Region "API Funtions"
    Public Overrides Function Measure(ByRef outdata As sDataInfos) As Boolean

        Dim bufByteData() As Byte = Nothing
        Dim bufByteTemp() As Byte = Nothing
        Dim dData() As Double = Nothing
        Dim nCount As Integer = 0

            If MeasurementStart(m_addr) = False Then Return False
            Dim sStartTime As Date = Now
            Dim sDeltaTime As TimeSpan
            Do
                sDeltaTime = Now - sStartTime
                Application.DoEvents()
        Loop Until sDeltaTime.TotalMilliseconds >= (m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).IntegTimeVal)

            If SetPointToData(m_addr) = False Then Return False
            If GetMeasureData(m_addr, bufByteData) = False Then Return False

            If SetTemperatureRegistor(m_addr) = False Then Return False
            If GetTemperature(m_addr, bufByteTemp) = False Then Return False

            If ConvertADCData(bufByteData, bufByteTemp, dData) = False Then Return False

            If ConvertToColorimetic(dData, outdata) = False Then Return False

        Return True
    End Function

    Public Overrides Function AutoRangeMeasure(ByRef outdata As sDataInfos) As Boolean

        Dim bufByteData() As Byte = Nothing
        Dim bufByteTemp() As Byte = Nothing
        Dim dData() As Double = Nothing
        Dim nCount As Integer = 0
        bDataTrue = False

        Do Until bDataTrue

            m_Range = nCount

            If SubSettings(m_DeviceInfos) = False Then Return False

            If MeasurementStart(m_addr) = False Then Return False
            Dim sStartTime As Date = Now
            Dim sDeltaTime As TimeSpan
            Do
                sDeltaTime = Now - sStartTime
                Application.DoEvents()
            Loop Until sDeltaTime.TotalMilliseconds >= (m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).IntegTimeVal + 10)

            If SetPointToData(m_addr) = False Then Return False
            If GetMeasureData(m_addr, bufByteData) = False Then Return False

            '       Thread.Sleep(10)
            Application.DoEvents()

            If SetTemperatureRegistor(m_addr) = False Then Return False
            If GetTemperature(m_addr, bufByteTemp) = False Then Return False

            If ConvertADCData(bufByteData, bufByteTemp, dData) = False Then Return False

            If ConvertToColorimetic(dData, outdata) = False Then Return False

            If m_Range = 0 Then
                If outdata.Data.dY < 10000 Then
                    bDataTrue = True
                    Exit Do
                Else
                    bDataTrue = False
                    nCount += 1
                End If
            ElseIf m_Range = 1 Then
                If outdata.Data.dY >= 10000 And outdata.Data.dY <= 75000 Then
                    bDataTrue = True
                    Exit Do
                Else
                    bDataTrue = True
                    Exit Do
                End If
            End If

        Loop

        Return True
    End Function
#End Region

#Region "Functions"

    Public Function Ready(ByVal addr As Integer) As Boolean

        Dim sData(8) As Byte
        sData(0) = &H1
        sData(1) = &H1
        sData(2) = &H0
        sData(3) = &H0
        sData(4) = &HDC
        sData(5) = &H63
        If WriteData(addr, sData) = False Then Return False

        Return True
    End Function

    Public Function CancleIO(ByVal nAddress As Integer) As Boolean
        Try
            IowKitCancelIo(iowHandles(nAddress), 1)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetDeviceHandles(ByVal nNumIow As Integer) As Boolean

        Try

            For I = 1 To nNumIow
                iowHandles(I - 1) = IowKitGetDeviceHandle(I)
            Next I
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function GetSerialNumber(ByVal nNumIow As Integer, ByRef bSerialNumber() As Byte) As Boolean
        Dim returnVal As Integer
        ReDim bSerialNumber(15)
        '  Dim bSerialNumber As Byte
        returnVal = IowKitGetSerialNumber(iowHandles(nNumIow), bSerialNumber(0))
        '   nNumber = Hex(bSerialNumber)
        Return True
    End Function

    Public Function GetNumOfDevices(ByRef numIows As Integer) As Boolean
        Try
            numIows = IowKitGetNumDevs()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function GetAllConfigReg(ByVal nAddress As Integer, ByRef sData() As Byte, ByRef Config As sSubSettings) As Boolean
        If SetPointToReg(nAddress) = False Then Return False
        ' Threading.Thread.Sleep(5000)
        If GetOffSet(nAddress, sData) = True Then

            If ConvertCREGLToHex(Config.ReferenceCurrent, Config.IntegTime, sData(10)) = False Then Return False
            If ConvertCREGHToHex(Config.Mode, Config.Divider, sData(11)) = False Then Return False
            If ConvertOPTREGToHex(Config.Offset, sData(12)) = False Then Return False
        Else
            MsgBox("Get Configuration Error")
            Return False
        End If
        Return True
    End Function

    Public Function SetAllConfigReg(ByVal nAddress As Integer, ByVal config As sSubSettings) As Boolean
        If SetConfiguration(nAddress) = False Then Return False
        If SetPWDownMode(nAddress) = False Then Return False
        If SetRefCurrIntegtime(nAddress, config.ReferenceCurrent, config.IntegTime) = False Then Return False
        If SetModeDivider(nAddress, config.Mode, config.Divider) = False Then Return False
        If SetOffset(nAddress, config.Offset) = False Then Return False
        Return True
    End Function

    Public Function GetOffSet(ByVal nAddress As Integer, ByRef sReturnData() As Byte) As Boolean

        Dim sData(7) As Byte
        sData(0) = MC30_GETSTX
        sData(1) = MC30_GETADD
        sData(2) = MC30_I2CRADD
        sData(3) = &H0
        sData(4) = MC30_I2CRADD
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If ReadData(nAddress, 11, sData, sReturnData) = False Then Return False
        Return True
    End Function

    Public Function SetConfiguration(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = MC30_OSRREG
        sData(4) = &H2
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False
        Return True
    End Function

    Public Function SetPWDownMode(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = MC30_OSRREG
        sData(4) = &H0
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False
        Return True
    End Function

    Public Function SetRefCurrIntegtime(ByVal nAddress As Integer, ByVal nRefCurr As eRefCurrent, ByVal nIntegtime As eIntegTime) As Boolean

        Dim sData(7) As Byte
        Dim returnVal As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = MC30_GREGLREG
        ConvertCREGLToBin(nRefCurr, nIntegtime, returnVal)
        sData(4) = returnVal
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False

        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).ReferenceCurrent = nRefCurr
        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).IntegTime = nIntegtime
        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).IntegTimeVal = sIntegrationTimeValue(nIntegtime)
        Return True
    End Function

    Public Function SetModeDivider(ByVal nAddress As Integer, ByVal nMode As eMode, ByVal nDivider As eDivider) As Boolean
        Dim sData(7) As Byte
        Dim returnVal As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = MC30_GREGHREG
        ConvertCREGHToBin(nMode, nDivider, returnVal)
        sData(4) = returnVal
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False

        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).Mode = nMode
        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).Divider = nDivider

        Return True
    End Function

    Public Function SetOffset(ByVal nAddress As Integer, ByVal nOffset As eOffset) As Boolean
        Dim sData(7) As Byte
        Dim returnVal As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = MC30_OPTREG
        ConvertOPTREGToBin(nOffset, returnVal)
        sData(4) = returnVal
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False

        m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).Offset = nOffset

        Return True
    End Function

    Public Function SetPointToReg(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETREG
        sData(2) = MC30_I2CWADD
        sData(3) = &H0
        sData(4) = &H0
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False
        Return True
    End Function


    Public Function MeasurementStart(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETADD
        sData(2) = MC30_I2CWADD
        sData(3) = &H0
        sData(4) = &H83
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False

        If sReturnData(0) = 0 Then
            Return False
        End If
        Return True
    End Function


    Public Function SetPointToData(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETREG
        sData(2) = MC30_I2CWADD
        sData(3) = &H0
        sData(4) = &H20
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False
        Return True
    End Function

    Public Function GetMeasureData(ByVal nAddress As Integer, ByRef sReturnData() As Byte) As Boolean
        Dim sData(7) As Byte
        '  Dim sReturnData() As Byte = Nothing

        sData(0) = MC30_GETSTX
        sData(1) = MC30_GETADD
        sData(2) = MC30_I2CRADD
        sData(3) = &H0
        sData(4) = MC30_I2CRADD
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If ReadData(nAddress, 8, sData, sReturnData) = False Then Return False

        Return True
    End Function


    Public Function SetTemperatureRegistor(ByVal nAddress As Integer) As Boolean
        Dim sData(7) As Byte
        Dim sReturnData() As Byte = Nothing
        sData(0) = MC30_SETSTX
        sData(1) = MC30_SETREG
        sData(2) = MC30_I2CRADDTEMP
        sData(3) = &H0
        sData(4) = &HA0
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0
        If WriteData(nAddress, 8, sData, sReturnData) = False Then Return False

        Return True
    End Function

    Public Function GetTemperature(ByVal nAddress As Integer, ByRef sReturnData() As Byte) As Boolean
        Dim sData(7) As Byte
        sData(0) = MC30_GETSTX
        sData(1) = MC30_SETSTX
        sData(2) = &H91
        sData(3) = &H0
        sData(4) = &H0
        sData(5) = &H0
        sData(6) = &H0
        sData(7) = &H0

        If ReadData(nAddress, 6, sData, sReturnData) = False Then Return False
        Return True
    End Function

    Public Function ConvertCREGLToBin(ByVal nRefCurr As eRefCurrent, ByVal nIntegtime As eIntegTime, ByRef returnVal As Byte) As Boolean
        Dim ValRef As String = ""
        Dim ValInteg As String = ""

        If nRefCurr = eRefCurrent.e20 Then
            ValRef = "000"
        ElseIf nRefCurr = eRefCurrent.e80 Then
            ValRef = "001"
        ElseIf nRefCurr = eRefCurrent.e320 Then
            ValRef = "010"
        ElseIf nRefCurr = eRefCurrent.e1280 Then
            ValRef = "011"
        ElseIf nRefCurr = eRefCurrent.e5120 Then
            ValRef = "100"
        End If

        If nIntegtime = eIntegTime.e1ms Then
            ValInteg = "0000"
        ElseIf nIntegtime = eIntegTime.e2ms Then
            ValInteg = "0001"
        ElseIf nIntegtime = eIntegTime.e4ms Then
            ValInteg = "0010"
        ElseIf nIntegtime = eIntegTime.e8ms Then
            ValInteg = "0011"
        ElseIf nIntegtime = eIntegTime.e16ms Then
            ValInteg = "0100"
        ElseIf nIntegtime = eIntegTime.e32ms Then
            ValInteg = "0101"
        ElseIf nIntegtime = eIntegTime.e64ms Then
            ValInteg = "0110"
        ElseIf nIntegtime = eIntegTime.e128ms Then
            ValInteg = "0111"
        ElseIf nIntegtime = eIntegTime.e256ms Then
            ValInteg = "1000"
        ElseIf nIntegtime = eIntegTime.e512ms Then
            ValInteg = "1001"
        ElseIf nIntegtime = eIntegTime.e1024ms Then
            ValInteg = "1010"
        Else
            ValInteg = "1011"
        End If

        returnVal = Bin2Hex("1" + ValRef + ValInteg)
        Return True
    End Function

    Public Function ConvertCREGHToBin(ByVal nMode As eMode, ByVal nDivider As eDivider, ByRef returnVal As Byte) As Boolean
        Dim ValMode As String = ""
        Dim ValDivider As String = ""
        Dim ValENDIV As String = ""

        If nMode = eMode.eCommand Then
            ValMode = "01"
        Else
            ValMode = "00"
        End If

        If nDivider = eDivider.e1 Then
            ValDivider = "00"
            ValENDIV = "0"
        ElseIf nDivider = eDivider.e2 Then
            ValDivider = "00"
            ValENDIV = "1"
        ElseIf nDivider = eDivider.e4 Then
            ValDivider = "01"
            ValENDIV = "1"
        ElseIf nDivider = eDivider.e8 Then
            ValDivider = "10"
            ValENDIV = "1"
        ElseIf nDivider = eDivider.e16 Then
            ValDivider = "11"
            ValENDIV = "1"
        End If

        returnVal = Bin2Hex("000" + ValMode + ValDivider + ValENDIV)
        Return True
    End Function

    Public Function ConvertOPTREGToBin(ByVal nOffset As eOffset, ByRef returnVal As Byte) As Boolean
        Dim ValOffset As String = ""

        If nOffset = eOffset.e0 Then
            ValOffset = "00"
        ElseIf nOffset = eOffset.e15 Then
            ValOffset = "01"
        ElseIf nOffset = eOffset.e31 Then
            ValOffset = "10"
        ElseIf nOffset = eOffset.e63 Then
            ValOffset = "11"
        End If

        returnVal = Bin2Hex("000000" + ValOffset)
        Return True
    End Function

    Public Function ConvertCREGLToHex(ByRef nRefCurr As eRefCurrent, ByRef nIntegtime As eIntegTime, ByVal Value As Byte) As Boolean
        Dim sHex As String = ""
        Dim returnBin As String = ""
        Dim sBuff As String = ""

        If CStr(Value).Length = 1 Then
            sHex = CStr("&H0" & Hex(Value))
        Else
            sHex = CStr("&H" & Hex(Value))
        End If
        returnBin = Hex2Bin(sHex)

        sBuff = returnBin.Substring(1, 3)
        If sBuff = "000" Then
            nRefCurr = eRefCurrent.e20
        ElseIf sBuff = "001" Then
            nRefCurr = eRefCurrent.e80
        ElseIf sBuff = "010" Then
            nRefCurr = eRefCurrent.e320
        ElseIf sBuff = "011" Then
            nRefCurr = eRefCurrent.e1280
        Else
            nRefCurr = eRefCurrent.e5120
        End If

        sBuff = returnBin.Substring(4, 4)
        If sBuff = "0000" Then
            nIntegtime = eIntegTime.e1ms
        ElseIf sBuff = "0001" Then
            nIntegtime = eIntegTime.e2ms
        ElseIf sBuff = "0010" Then
            nIntegtime = eIntegTime.e4ms
        ElseIf sBuff = "0011" Then
            nIntegtime = eIntegTime.e8ms
        ElseIf sBuff = "0100" Then
            nIntegtime = eIntegTime.e16ms
        ElseIf sBuff = "0101" Then
            nIntegtime = eIntegTime.e32ms
        ElseIf sBuff = "0110" Then
            nIntegtime = eIntegTime.e64ms
        ElseIf sBuff = "0111" Then
            nIntegtime = eIntegTime.e128ms
        ElseIf sBuff = "1000" Then
            nIntegtime = eIntegTime.e256ms
        ElseIf sBuff = "1001" Then
            nIntegtime = eIntegTime.e512ms
        ElseIf sBuff = "1010" Then
            nIntegtime = eIntegTime.e1024ms
        Else
            nIntegtime = eIntegTime.e1ms
        End If

        Return True
    End Function

    Public Function ConvertCREGHToHex(ByRef nMode As eMode, ByRef nDivider As eDivider, ByVal Value As Byte) As Boolean
        Dim sHex As String = ""
        Dim returnBin As String = ""
        Dim sBuff As String = ""

        If CStr(Value).Length = 1 Then
            sHex = CStr("&H0" & Hex(Value))
        Else
            sHex = CStr("&H" & Hex(Value))
        End If
        '   sHex = CStr("&H" & Hex(Value))
        returnBin = Hex2Bin(sHex)

        sBuff = returnBin.Substring(3, 2)
        If sBuff = "00" Then
            nMode = eMode.eContinuous
        ElseIf sBuff = "01" Then
            nMode = eMode.eCommand
        End If

        sBuff = returnBin.Substring(7, 1)
        If sBuff = "0" Then
            nDivider = eDivider.e1
        ElseIf sBuff = "1" Then
            sBuff = returnBin.Substring(5, 2)
            If sBuff = "00" Then
                nDivider = eDivider.e2
            ElseIf sBuff = "01" Then
                nDivider = eDivider.e4
            ElseIf sBuff = "10" Then
                nDivider = eDivider.e8
            ElseIf sBuff = "11" Then
                nDivider = eDivider.e16
            End If
        End If
        Return True
    End Function

    Public Function ConvertOPTREGToHex(ByRef nOffset As eOffset, ByRef Value As Byte) As Boolean
        Dim sHex As String = ""
        Dim returnBin As String = ""
        Dim sBuff As String = ""

        If CStr(Value).Length = 1 Then
            sHex = CStr("&H0" & Hex(Value))
        Else
            sHex = CStr("&H" & Hex(Value))
        End If
        returnBin = Hex2Bin(sHex)

        sBuff = returnBin.Substring(6, 2)
        If sBuff = "00" Then
            nOffset = eOffset.e0
        ElseIf sBuff = "01" Then
            nOffset = eOffset.e15
        ElseIf sBuff = "10" Then
            nOffset = eOffset.e31
        ElseIf sBuff = "11" Then
            nOffset = eOffset.e63
        End If

        Return True
    End Function

    Public Function Bin2Hex(ByVal sBin As String)
        Dim sHex As String
        Dim lenBin As Integer
        Dim jBin As Integer

        sHex = "&H"
        lenBin = Len(sBin)
        If lenBin > 0 Then
            Dim splitLen As Integer
            Dim splitBin As String
            Dim iBin As Integer

            If lenBin Mod 4 <> 0 Then
                For BHi = 1 To 4 - (lenBin Mod 4)
                    sBin = "0" & sBin
                Next
            End If
            lenBin = Len(sBin)
            splitLen = lenBin / 4
            For BHi = 1 To splitLen
                splitBin = Mid(sBin, ((BHi - 1) * 4) + 1, 4)

                jBin = 8
                iBin = 0
                For BHj = 1 To 4
                    If Mid(splitBin, BHj, 1) = "1" Then
                        iBin = iBin + jBin
                    End If
                    jBin = jBin / 2
                Next
                sHex = sHex & Hex(iBin)
            Next
        End If

        Bin2Hex = sHex
    End Function


    Public Function Hex2Bin(ByVal sHex As String)
        Dim sBin As String
        Dim nCount As Integer

        sBin = ""
        If Len(sHex) > 2 Then
            sHex = UCase(sHex)
            If Left(sHex, 2) = "&H" Then
                Dim iHex As Integer, jHex As Integer
                Dim cHex As String
                Dim HBi As Integer
                Dim HBin As String

                sHex = Mid(sHex, 3)
                If Len(sHex) = 1 Then
                    nCount = Len(sHex) + 1
                Else
                    nCount = Len(sHex)
                End If
                For HBi = 1 To nCount
                    cHex = Mid(sHex, HBi, 1)
                    Select Case cHex
                        Case "A", "B", "C", "D", "E", "F"
                            iHex = Asc(cHex) - 55
                        Case Else
                            iHex = Val(cHex)
                    End Select

                    HBin = ""
                    jHex = 8
                    For HBj = 1 To 4
                        If iHex >= jHex Then
                            HBin = HBin & "1"
                            iHex = iHex - jHex
                        Else
                            HBin = HBin & "0"
                        End If
                        jHex = jHex / 2
                    Next
                    sBin = sBin & HBin
                Next
            End If
        End If

        Hex2Bin = sBin
    End Function

    Public Function ReadData(ByVal nAddress As Integer, ByVal Datalength As Integer, ByVal sData() As Byte, ByRef sData1() As Byte) As Boolean
        Dim Res As Integer
        Dim sReturnData() As Byte = Nothing

        Res = IowKitWrite(iowHandles(nAddress), 1, sData(0), 8)

        Dim nLoop As Integer
        If (Datalength Mod 6) <> 0 Then
            nLoop = Datalength / 8 + 1
        Else
            nLoop = Datalength / 8
        End If

        ReDim sData1(nLoop * 8 - 1)
        ReDim sReturnData(nLoop * 8 - 1)
        For i As Integer = 0 To nLoop - 1
            Res = IowKitRead(iowHandles(nAddress), 1, sReturnData(0), 8)
            For j As Integer = 0 To sData.Length - 1
                sData1(i * 8 + j) = sReturnData(j)
            Next
        Next
        Return True
    End Function

    Public Function WriteData(ByVal nAddress As Integer, ByVal Datalength As Integer, ByVal sData() As Byte, ByRef sDataReturn() As Byte) As Boolean

        Dim Res As Integer
        '  Dim bReturn As Integer

        ReDim sDataReturn(Datalength - 1)


        Res = IowKitWrite(iowHandles(nAddress), 1, sData(0), 8)

        Res = IowKitRead(iowHandles(nAddress), 1, sDataReturn(0), 8)

        If sDataReturn(0) = 0 Then Return False

        Return True
    End Function

    Public Function WriteData(ByVal nAddress As Integer, ByVal sData() As Byte) As Boolean

        Dim Res As Integer
        '   Dim N As Integer
        ' Dim Pid As Integer
        '     Dim dData(2) As Byte

        Res = IowKitWrite(iowHandles(nAddress), 1, sData(0), 8)

        Return True
    End Function

    Public Function ConvertADCData(ByVal sData() As Byte, ByVal sDataTemp() As Byte, ByRef MeasData() As Double) As Boolean

        Dim buffData(1) As Byte
        Dim sBuffShort As UShort
        ReDim MeasData(3)

        If sDataTemp(3) = 0 Then
            sBuffShort = sDataTemp(2)
            MeasData(3) = CDbl(sBuffShort)
        Else
            sBuffShort = CDbl(sDataTemp(2))
            MeasData(3) = CDbl(sBuffShort) + 0.5
        End If

        buffData(0) = sData(5)
        buffData(1) = sData(4)
        sBuffShort = fConvertBytesShort(buffData)
        MeasData(0) = CDbl(sBuffShort)

        buffData(0) = sData(7)
        buffData(1) = sData(6)
        sBuffShort = fConvertBytesShort(buffData)
        MeasData(2) = CDbl(sBuffShort)

        buffData(0) = sData(11)
        buffData(1) = sData(10)
        sBuffShort = fConvertBytesShort(buffData)
        MeasData(1) = CDbl(sBuffShort)

        'If MeasData(0) = 65535 Or MeasData(1) = 65535 Or MeasData(2) = 65535 Then
        '    '  MsgBox("Saturation!!")
        'End If

        Return True
    End Function

    Public Function ConvertToColorimetic(ByVal dDATA() As Double, ByRef outdata As sDataInfos) As Boolean
        Try
            Dim sReferenceCurrent() As Double = New Double() {19.8, 79.2, 316.8, 1267.2, 5068.8}
            Application.DoEvents()
            Dim ADCPrime(,) As Double = Nothing
            Dim XYZ(,) As Double = Nothing
            Dim n As Double
            Dim cct As Double
            Dim XDD As Double = 0
            Dim YDD As Double = 0
            Dim ZDD As Double = 0
            Dim uprime, vprime, u, v As Double
            Dim XD As Double = 0
            Dim YD As Double = 0
            Dim ZD As Double = 0

            outdata.Data.dACDXdigit = dDATA(0)
            outdata.Data.dACDYdigit = dDATA(1)
            outdata.Data.dACDZdigit = dDATA(2)
            outdata.Data.dADCX = dDATA(0) '/ m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).dFactor
            outdata.Data.dADCY = dDATA(1) '/ m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).dFactor
            outdata.Data.dADCZ = dDATA(2) '/ m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).dFactor
            outdata.Data.dTemp = dDATA(3)

            'If outdata.Data.dADCX >= sReferenceCurrent(m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).ReferenceCurrent) Or outdata.Data.dADCY >= sReferenceCurrent(m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).ReferenceCurrent) Or outdata.Data.dADCZ >= sReferenceCurrent(m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).ReferenceCurrent) Then
            '    '     MsgBox("Saturation!!")
            'End If

            ReDim ADCPrime(2, 0)
            For i As Integer = 0 To dDATA.Length - 2
                ' ADCPrime(i, 0) = dDATA(i) / m_DeviceInfos.sHEXA50Settings.SettingInfo(m_Range).dFactor - m_DeviceInfos.sHEXA50Settings.CalibrationData(m_Range).ElecOffset(i) - m_DeviceInfos.sHEXA50Settings.CalibrationData(m_Range).BWOffset(i)

                ADCPrime(i, 0) = dDATA(i) - m_DeviceInfos.sHEXA50Settings.CalibrationData(m_Range).ElecOffset(i) - m_DeviceInfos.sHEXA50Settings.CalibrationData(m_Range).BWOffset(i)
            Next

            If MatrixMulti(m_DeviceInfos.sHEXA50Settings.CalibrationData(m_Range).KFactor, ADCPrime, XYZ) = False Then Return False
            outdata.Data.dX = XYZ(0, 0)
            outdata.Data.dY = XYZ(1, 0)
            outdata.Data.dZ = XYZ(2, 0)



            'If outdata.Data.dY < 1 Then

            'Else

            '    XD = outdata.Data.dX * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitA ^ 5 + outdata.Data.dX * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitB ^ 4 + _
            '        outdata.Data.dX * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitC ^ 3 + outdata.Data.dX * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitD ^ 2 + _
            '        outdata.Data.dX * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitE ^ 1 + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitF

            '    YD = outdata.Data.dY * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitA ^ 5 + outdata.Data.dY * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitB ^ 4 + _
            '   outdata.Data.dY * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitC ^ 3 + outdata.Data.dY * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitD ^ 2 + _
            '   outdata.Data.dY * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitE ^ 1 + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitF

            '    ZD = outdata.Data.dZ * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitA ^ 5 + outdata.Data.dZ * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitB ^ 4 + _
            '   outdata.Data.dZ * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitC ^ 3 + outdata.Data.dZ * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitD ^ 2 + _
            '   outdata.Data.dZ * m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitE ^ 1 + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitF


            '    'Dim XD As Double = (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitA * outdata.Data.dX) + (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).XFitB)
            '    'Dim YD As Double = (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitA * outdata.Data.dY) + (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).YFitB)
            '    'Dim ZD As Double = (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitA * outdata.Data.dZ) + (m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).ZFitB)

            'outdata.Data.dX = XD
            'outdata.Data.dY = YD
            'outdata.Data.dZ = ZD
            'End If

            XD = outdata.Data.dX
            YD = outdata.Data.dY
            ZD = outdata.Data.dZ

            XDD = XD / YD * 100
            YDD = YD / YD * 100
            ZDD = ZD / YD * 100

            Try
                outdata.Data.dCIEx = XDD / (XDD + YDD + ZDD)
                outdata.Data.dCIEy = YDD / (XDD + YDD + ZDD)

                'If outdata.Data.dCIEx <> 0 Then
                '    Dim FitCIEX As Double
                '    FitCIEX = outdata.Data.dCIEx + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).xFit
                '    outdata.Data.dCIEx = FitCIEX
                'End If
                'If outdata.Data.dCIEy <> 0 Then
                '    Dim FitCIEY As Double
                '    FitCIEY = outdata.Data.dCIEy + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).yFit
                '    outdata.Data.dCIEy = FitCIEY
                'End If

                If (outdata.Data.dX + outdata.Data.dY + outdata.Data.dZ) = 0 Then
                    outdata.Data.dCIEx = 0
                    outdata.Data.dCIEy = 0
                    outdata.Data.CCT = 0
                Else
                    n = ((outdata.Data.dCIEx - 0.332) / (outdata.Data.dCIEy - 0.1858))
                    cct = 5520.33 - (6823.3 * n) + (3535 * n * n) - (449 * n * n * n)
                    outdata.Data.CCT = cct
                End If
            Catch ex As Exception

            End Try

            Try
                uprime = 4 * XDD / (XDD + YDD * 15 + ZDD * 3)
                vprime = 9 * YDD / (XDD + YDD * 15 + ZDD * 3)
                u = 4 * XDD / (XDD + YDD * 15 + ZDD * 3)
                v = 6 * YDD / (XDD + YDD * 15 + ZDD * 3)
                If (XDD + YDD * 15 + ZDD * 3) = 0 Then
                    uprime = 0
                    vprime = 0
                    u = 0
                    v = 0
                End If
            Catch ex As Exception

            End Try

            outdata.Data.dLuminance = outdata.Data.dY

            'If outdata.Data.dLuminance <> 0 Then
            '    outdata.Data.dLuminance = outdata.Data.dLuminance + m_DeviceInfos.sHEXA50Settings.FitParam(m_Range).LFit
            'Else
            '    outdata.Data.dLuminance = outdata.Data.dLuminance
            'End If

            'Dim xn, yn, zn, fx, fy, fz, Lprime, aprime, bprime As Double

            'xn = outdata.Data.dX / 94.811
            'yn = outdata.Data.dY / 100
            'zn = outdata.Data.dZ / 107.304

            'If xn > 0.008856 Then
            '    fx = Math.Pow(xn, 1 / 3)
            'Else
            '    fx = (903.3 * xn + 16) / 116
            'End If
            'If yn > 0.008856 Then
            '    fy = Math.Pow(yn, 1 / 3)
            'Else
            '    fy = (903.3 * yn + 16) / 116
            'End If
            'If zn > 0.008856 Then
            '    fz = Math.Pow(zn, 1 / 3)
            'Else
            '    fz = (903.3 * zn + 16) / 116
            'End If

            'Lprime = 116 * fy - 16
            'aprime = 500 * (fx - fy)
            'bprime = 200 * (fy - fz)

            outdata.Data.dCIE1960u = u
            outdata.Data.dCIE1960v = v
            outdata.Data.dCIE1976u = uprime
            outdata.Data.dCIE1976v = vprime
            'outdata.Data.dLprime = Lprime
            'outdata.Data.dApirme = aprime
            'outdata.Data.dBprime = bprime


            If outdata.Data.dX < 0 Then
                outdata.Data.dX = 0
            End If
            If outdata.Data.dY < 0 Then
                outdata.Data.dY = 0
            End If
            If outdata.Data.dZ < 0 Then
                outdata.Data.dZ = 0
            End If
            If outdata.Data.dCIEx < 0 Then
                outdata.Data.dCIEx = 0
            End If
            If outdata.Data.dCIEy < 0 Then
                outdata.Data.dCIEy = 0
            End If
            If outdata.Data.dCIE1960u < 0 Then
                outdata.Data.dCIE1960u = 0
            End If
            If outdata.Data.dCIE1960v < 0 Then
                outdata.Data.dCIE1960v = 0
            End If
            If outdata.Data.dCIE1976u < 0 Then
                outdata.Data.dCIE1976u = 0
            End If
            If outdata.Data.dCIE1976v < 0 Then
                outdata.Data.dCIE1976v = 0
            End If
            If outdata.Data.CCT < 0 Then
                outdata.Data.CCT = 0
            End If
        
        Catch ex As Exception

        End Try
        Return True
    End Function


    Public Function MatrixMulti(ByVal mAmatrix(,) As Double, ByVal mBmatrix(,) As Double, ByRef mCmatrix(,) As Double) As Boolean
        Dim nArowcount As Integer = 0
        Dim nBrowcount As Integer = 0
        Dim nAcolcount As Integer = 0
        Dim nBcolcount As Integer = 0

        Try
            For i As Integer = 0 To mAmatrix.Length - 1
                Try
                    Dim buff As Double
                    buff = mAmatrix(i, 0)
                    nArowcount += 1

                Catch ex As Exception
                    Exit For
                End Try
            Next

            For i As Integer = 0 To mBmatrix.Length - 1
                Try
                    Dim buff As Double
                    buff = mBmatrix(0, i)
                    nBcolcount += 1

                Catch ex As Exception
                    Exit For
                End Try
            Next

            nAcolcount = mAmatrix.Length / nArowcount
            nBrowcount = mBmatrix.Length / nBcolcount

            If nAcolcount <> nBrowcount Then
                MsgBox("Do Not Multiplication")
                Return False
            End If


            ReDim mCmatrix(nArowcount - 1, nBcolcount - 1)
            Dim sum As Double = 0

            For i As Integer = 0 To nArowcount - 1

                For j As Integer = 0 To nBcolcount - 1
                    sum = 0
                    For k As Integer = 0 To mAmatrix.Length / nArowcount - 1
                        sum = sum + mAmatrix(i, k) * mBmatrix(k, j)
                    Next
                    mCmatrix(i, j) = sum
                Next
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function CalculationFactors(ByVal config As sSubSettings) As Double

        Dim dIntegFactor As Double = 0
        Dim dAmpFactor As Double = 0

        With config
            dIntegFactor = 0.2 * Math.Pow(2, .IntegTime)
            dAmpFactor = dIntegFactor * Math.Pow(4, 4 - .ReferenceCurrent)

        End With

        Return dAmpFactor
    End Function

#End Region



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
