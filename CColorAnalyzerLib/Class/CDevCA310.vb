Imports CA200SRVRLib
Imports CCommLib

Public Class CDevCA310
    Inherits CDevColorAnalyzerCommonNode


#Region "Define"

    Public objCa200 As Ca200     'Application object
    Public objCas As Cas
    Public objCa As Ca               'CA-200 (instrument) object
    Public objOutputProbe As OutputProbes      'Probe object
    Public objProbe As Probe
    Public objMemory As Memory   'Memory object

    Private m_sProbeID As String = "P1"
    Private m_nDevID As Integer = 1


    Public nComPort As Integer
    Public nBaudRate As Integer





#Region "Structure"


    Public Structure sSettings
        Dim syncMode As Single
        Dim dispMode As CDevCA310.eDispMode
        Dim dispDigits As CDevCA310.eDispDigit
        Dim avgMode As CDevCA310.eAveragingMode
        Dim brightnessMode As CDevCA310.eBrightnessUnit
        Dim devInfo As CDevCA310.sDevInfo
        Dim calMode As CDevCA310.eCalibrationMode
    End Structure

    Public Structure sDatas
        Dim X As Double
        Dim Y As Double
        Dim Z As Double
        Dim sx As Double
        Dim sy As Double
        Dim Lv As Double
        Dim ud As Double
        Dim vd As Double
        Dim T As Double
        Dim LsUser As Double
        Dim usUser As Double
        Dim vsUser As Double
        Dim dEUser As Double
        Dim duv As Double
    End Structure


    Public Structure sDevInfo
        Dim sModel As String
        Dim sFirmwareVersion As String
        Dim nIDNumber As Long
        Dim sCommPort As String
    End Structure

#End Region



#Region "Enums"

    Public Enum eErrorChkCode
        OK00
        OK01
        OK02
        OK03
        OK04
        OK05
        OK06
        OK07
        ER10
        ER15
        ER20
        ER21
        ER22
        ER23
        ER24
        ER50
        ER51
        ER52
        ER53
        ER_undef
    End Enum

    Public Enum eDispMode
        Lvxy
        Tdudv
        AnalyzerMode_NoAnalog
        AnalyzerMode_G_Standard
        AnalyzerMode_R_Standard
        uDot_vDot
        FlickerMode
        XYZ
        JEITAFlicker
    End Enum

    Public Enum eSyncMode
        NTSC
        PAL
        EXT
        UNIV
        Frequency
    End Enum

    Public Enum eRemoteMode
        RemoteOFF
        RemoteON
        RemoteLOCKED
    End Enum

    Public Enum eDispDigit
        digit_3
        digit_4
    End Enum

    Public Enum eAveragingMode
        SLOW
        FAST
        AUTO
    End Enum

    Public Enum eBrightnessUnit
        fL
        cd_m2
    End Enum

    Public Enum eCalibrationMode
        e6500K = 1
        e9300K
    End Enum

#End Region


#End Region

#Region "Properties"




    Public Property SyncMode As Single
        Get
            Return objCa.SyncMode
        End Get
        Set(value As Single)
            objCa.SyncMode = value
        End Set
    End Property

    Public Property DisplayMode As eDispMode
        Get
            Return objCa.DisplayMode
        End Get
        Set(value As eDispMode)
            objCa.DisplayMode = value
        End Set
    End Property

    Public Property DisplayDigit As eDispDigit
        Get
            Return objCa.DisplayDigits
        End Get
        Set(value As eDispDigit)
            objCa.DisplayDigits = value
        End Set
    End Property

    Public Property AveragingMode As eAveragingMode
        Get
            Return objCa.AveragingMode
        End Get
        Set(value As eAveragingMode)
            objCa.AveragingMode = value
        End Set
    End Property

    Public Property BrightnessUnit As eBrightnessUnit
        Get
            Return objCa.BrightnessUnit
        End Get
        Set(value As eBrightnessUnit)
            objCa.BrightnessUnit = value
        End Set
    End Property


    Public Property CalibrationMode As eCalibrationMode
        Get
            Return objCa.CalStandard
        End Get
        Set(value As eCalibrationMode)
            objCa.CalStandard = value
        End Set
    End Property


#End Region


#Region "Creator & init"

    Public Sub New()
        MyBase.new()
        objCa200 = New Ca200
        comm = New CCommLib.CComAPI(CComCommonNode.eCommType.eSerial)
        MyBase.m_bIsConnected = False
    End Sub

    Public Sub Dispose()
        objCa200 = Nothing
        objCa = Nothing
        objProbe = Nothing
        objMemory = Nothing
    End Sub

#End Region

    Public Overrides Function Connection(ByVal commInfos As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim sPortNo As String

        If objCa200 Is Nothing Then
            objCa200 = New Ca200
        End If

        Try
            sPortNo = commInfos.sSerialInfo.sPortName.Substring(3, commInfos.sSerialInfo.sPortName.Length - 3)
            nComPort = CInt(sPortNo)
            nBaudRate = commInfos.sSerialInfo.nBaudRate

            objCa200.SetConfiguration(1, "1", nComPort, nBaudRate)

            objCas = objCa200.Cas

            objCa = objCas.ItemOfNumber(1)
            objOutputProbe = objCa.OutputProbes
            objOutputProbe.RemoveAll()
            objOutputProbe.Add(m_sProbeID)
            objProbe = objOutputProbe.Item(m_sProbeID)
            objMemory = objCa.Memory

        Catch ex As System.Runtime.InteropServices.COMException
            m_sErrMsg = ex.Message.ToString
            Return False
        End Try
        MyBase.m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        MyBase.m_bIsConnected = False
        Try
            objCa.RemoteMode = 0
            objCa200 = Nothing
            objCas = Nothing
            objCa = Nothing
            objProbe = Nothing
            objMemory = Nothing
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Exit Sub
        End Try

    End Sub

    Public Overrides Function ZeroCalibration() As Boolean
        Try
            objCa.CalZero()
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        Return True
    End Function


    Public Overrides Function GetDeviceInfo(ByRef infos As sDevInfo) As Boolean

        Try
            With infos
                .sModel = objCa.CAType
                .sFirmwareVersion = objCa.CAVersion
                .nIDNumber = objCa.Number
                .sCommPort = objCa.PortID
            End With
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        Return True
    End Function

    Public Overrides Function SetSettings(infos As sSetInfos) As Boolean
        Try
            With objCa
                .DisplayProbe = m_sProbeID

                .SyncMode = infos.sCA310Settings.syncMode '0
                .AveragingMode = infos.sCA310Settings.avgMode '2
                .BrightnessUnit = infos.sCA310Settings.brightnessMode '1
                .DisplayDigits = infos.sCA310Settings.dispDigits ' 0
                .CalStandard = infos.sCA310Settings.calMode '2
                .DisplayMode = infos.sCA310Settings.dispMode

                .OutputProbes.Add(m_sProbeID)
                .Memory.ChannelNO = 0
            End With
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try
       
        Return True
    End Function

    Public Overrides Function GetSettings(ByRef infos As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean

        Try
            With infos.sCA310Settings
                .syncMode = objCa.SyncMode
                .avgMode = objCa.AveragingMode
                .brightnessMode = objCa.BrightnessUnit
                .dispDigits = objCa.DisplayDigits
                .calMode = objCa.CalStandard
                .dispMode = objCa.DisplayMode

            End With
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        Return True
    End Function

    'Public Overrides Function Measure(ByRef measuredDatas As sDataInfos) As Boolean

    '    Try
    '        objCa.Measure()
    '    Catch ex As System.Runtime.InteropServices.COMException
    '        MyBase.m_sErrMsg = ex.Message
    '        Return False
    '    End Try
    '    fghfghfgh()
    '    rtyry()
    '    With measuredDatas.sCA310Datas
    '        .X = objCa.OutputProbes.Item(m_sProbeID).X
    '        .Y = objCa.OutputProbes.Item(m_sProbeID).Y
    '        .Z = objCa.OutputProbes.Item(m_sProbeID).Z
    '        .sx = objCa.OutputProbes.Item(m_sProbeID).sx
    '        .sy = objCa.OutputProbes.Item(m_sProbeID).sy
    '        .Lv = objCa.OutputProbes.Item(m_sProbeID).Lv
    '        .ud = objCa.OutputProbes.Item(m_sProbeID).ud
    '        .vd = objCa.OutputProbes.Item(m_sProbeID).vd
    '        .duv = objCa.OutputProbes.Item(m_sProbeID).duv
    '        .dEUser = objCa.OutputProbes.Item(m_sProbeID).dEUser
    '        .LsUser = objCa.OutputProbes.Item(m_sProbeID).LsUser
    '        .T = objCa.OutputProbes.Item(m_sProbeID).T
    '        .usUser = objCa.OutputProbes.Item(m_sProbeID).usUser
    '        .vsUser = objCa.OutputProbes.Item(m_sProbeID).vsUser
    '    End With


    '    Return True
    'End Function

    Public Overrides Function Measure(ByRef measuredDatas As CDevColorAnalyzerCommonNode.sDataInfos) As Boolean
        Try
            objCa.Measure()
        Catch ex As System.Runtime.InteropServices.COMException
            MyBase.m_sErrMsg = ex.Message
            Return False
        End Try

        With measuredDatas.Data
            .dX = objCa.OutputProbes.Item(m_sProbeID).X
            .dY = objCa.OutputProbes.Item(m_sProbeID).Y
            .dZ = objCa.OutputProbes.Item(m_sProbeID).Z
            .dCIEx = objCa.OutputProbes.Item(m_sProbeID).sx
            .dCIEy = objCa.OutputProbes.Item(m_sProbeID).sy
            .dLuminance = objCa.OutputProbes.Item(m_sProbeID).Lv
            .dCIE1976u = objCa.OutputProbes.Item(m_sProbeID).ud
            .dCIE1976v = objCa.OutputProbes.Item(m_sProbeID).vd
            .duv = objCa.OutputProbes.Item(m_sProbeID).duv
            .dEUser = objCa.OutputProbes.Item(m_sProbeID).dEUser
            .LsUser = objCa.OutputProbes.Item(m_sProbeID).LsUser
            .CCT = objCa.OutputProbes.Item(m_sProbeID).T
            .usUser = objCa.OutputProbes.Item(m_sProbeID).usUser
            .vsUser = objCa.OutputProbes.Item(m_sProbeID).vsUser
        End With

        Return True
    End Function



End Class
