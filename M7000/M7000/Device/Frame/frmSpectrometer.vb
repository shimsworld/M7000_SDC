Imports CCommLib
Imports CSpectrometerLib
Imports System.IO
Imports System.Windows.Forms
Imports System.Threading

Public Class frmSpectrometer

    Public Spectrometer As CDevSpectrometerAPI

    Public ucCtrlDispConfig As New ucConfigRS232_Socket_GPIB(CDevSpectrometerCommonNode.SupportDeviceNames)

    Public WithEvents ucCtrlSR3_AR As ucSR3AR
    Public WithEvents ucCtrlPR705 As ucPR705
    Public WithEvents ucCtrlPR730 As ucPR730
    Public WithEvents ucCtrlPR740 As ucPR740
    Public WithEvents ucCtrlCS1000 As ucCS1000
    Public WithEvents ucCtrlCS1000A As ucCS1000A
    Public WithEvents ucCtrlCS2000 As ucCS2000
    Public WithEvents ucCtrlAvantes As ucAvantes
    Public WithEvents ucCtrlLabsphere As ucLabsphere
    Public WithEvents ucCtrlPR650 As ucPR650
    Public WithEvents ucCtrlPR655 As ucPR655
    Public WithEvents ucCtrlPR670 As ucPR670
    Public WithEvents ucCtrlSR_UL2 As ucSRUL2
    Public WithEvents ucCtrlDarsa As ucDarsaPro

    Dim m_Config As frmConfigDevice.sConfig
    Dim m_Main As frmMain
    Dim m_configs(0) As ucConfigRS232_Socket_GPIB.sConfig

    Dim m_devType As CDevSpectrometerCommonNode.eModel

    Dim m_settings As CDevSpectrometerCommonNode.DeviceOption

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        m_Main = main
        m_configs(0) = config.SpectrometerConfig(0)
        init()
    End Sub

    Private Sub init()

        Me.Controls.Add(Me.ucCtrlDispConfig)

        ucCtrlDispConfig.Location = New System.Drawing.Point(5, 5)
        ucCtrlDispConfig.Size = New System.Drawing.Size(540, 533)

        ucCtrlDispConfig.Setting = m_configs

    End Sub

    Private Sub btnCreateObj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateObj.Click

        m_configs = ucCtrlDispConfig.Setting

        If m_configs Is Nothing Then
            MsgBox("설정 정보 입력이 필요합니다.")
            Exit Sub
        End If

        m_devType = m_configs(0).device

        Spectrometer = New CDevSpectrometerAPI(m_devType)


        Select Case m_devType

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740
                ucCtrlPR740 = New ucPR740
                Me.Controls.Add(ucCtrlPR740)
                ucCtrlPR740.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR740.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR740.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR740.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR740.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR740.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR740.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR740.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlPR740.evSetAperture, AddressOf btnSetAperture_Click
                'AddHandler ucCtrlPR740.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR
                ucCtrlSR3_AR = New ucSR3AR
                Me.Controls.Add(ucCtrlSR3_AR)
                ucCtrlSR3_AR.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlSR3_AR.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlSR3_AR.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlSR3_AR.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlSR3_AR.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlSR3_AR.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlSR3_AR.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlSR3_AR.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlSR3_AR.evSetAperture, AddressOf btnSetAperture_Click
                AddHandler ucCtrlSR3_AR.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2
                ucCtrlSR_UL2 = New ucSRUL2
                Me.Controls.Add(ucCtrlSR_UL2)
                ucCtrlSR_UL2.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlSR_UL2.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlSR_UL2.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlSR_UL2.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlSR_UL2.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlSR_UL2.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlSR_UL2.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlSR_UL2.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlSR_UL2.evSetAperture, AddressOf btnSetAperture_Click
                AddHandler ucCtrlSR_UL2.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650
                ucCtrlPR650 = New ucPR650
                Me.Controls.Add(ucCtrlPR650)
                ucCtrlPR650.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR650.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR650.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR650.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR650.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR650.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR650.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR650.evSetDeviceSettings, AddressOf SetSettings_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655
                ucCtrlPR655 = New ucPR655
                Me.Controls.Add(ucCtrlPR655)
                ucCtrlPR655.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR655.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR655.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR655.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR655.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR655.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR655.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR655.evSetDeviceSettings, AddressOf SetSettings_Click


            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670
                ucCtrlPR670 = New ucPR670
                Me.Controls.Add(ucCtrlPR670)
                ucCtrlPR670.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR670.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR670.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR670.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR670.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR670.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR670.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR670.evSetDeviceSettings, AddressOf SetSettings_Click
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705
                ucCtrlPR705 = New ucPR705
                Me.Controls.Add(ucCtrlPR705)
                ucCtrlPR705.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR705.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR705.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR705.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR705.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR705.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR705.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR705.evSetDeviceSettings, AddressOf SetSettings_Click

                ' AddHandler ucCtrlPR705.evSetAperture, AddressOf btnSetAperture_Click
                ' AddHandler ucCtrlPR705.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730
                ucCtrlPR730 = New ucPR730
                Me.Controls.Add(ucCtrlPR730)
                ucCtrlPR730.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlPR730.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlPR730.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlPR730.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlPR730.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlPR730.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlPR730.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlPR730.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlPR730.evSetAperture, AddressOf btnSetAperture_Click
                AddHandler ucCtrlPR730.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click
                AddHandler ucCtrlPR730.evSetLens, AddressOf btnLens_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000
                ucCtrlCS1000 = New ucCS1000
                Me.Controls.Add(ucCtrlCS1000)
                ucCtrlCS1000.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlCS1000.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlCS1000.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCS1000.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCS1000.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlCS1000.evMeasureStop, AddressOf MeasureStop_Click

                AddHandler ucCtrlCS1000.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlCS1000.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlCS1000.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlCS1000.evSetAperture, AddressOf btnSetAperture_Click

                AddHandler ucCtrlCS1000.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A
                ucCtrlCS1000A = New ucCS1000A
                Me.Controls.Add(ucCtrlCS1000A)
                ucCtrlCS1000A.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlCS1000A.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlCS1000A.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCS1000A.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCS1000A.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlCS1000A.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlCS1000A.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlCS1000A.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlCS1000A.evSetAperture, AddressOf btnSetAperture_Click
                AddHandler ucCtrlCS1000A.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000
                ucCtrlCS2000 = New ucCS2000
                Me.Controls.Add(ucCtrlCS2000)
                ucCtrlCS2000.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlCS2000.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlCS2000.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCS2000.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCS2000.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlCS2000.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlCS2000.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlCS2000.evSetDeviceSettings, AddressOf SetSettings_Click

                AddHandler ucCtrlCS2000.evSetLens, AddressOf btnLens_Click
                AddHandler ucCtrlCS2000.evSetAperture, AddressOf btnSetAperture_Click
                AddHandler ucCtrlCS2000.evSetMeasuringSpeed, AddressOf btnMeasuringSpeed_Click

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES
                ucCtrlAvantes = New ucAvantes
                Me.Controls.Add(ucCtrlAvantes)
                ucCtrlAvantes.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlAvantes.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlAvantes.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlAvantes.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlAvantes.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlAvantes.evSetDeviceSettings, AddressOf SetSettings_Click
                AddHandler ucCtrlAvantes.evSetIntegtimeAverage, AddressOf btnSetIntegAverage_Click
                AddHandler ucCtrlAvantes.evDarkMeasure, AddressOf btnDarkMeasure
                AddHandler ucCtrlAvantes.evActive, AddressOf btnActive
                AddHandler ucCtrlAvantes.evDeActive, AddressOf btnDeActive

                Dim lamda(1023) As Double
                Dim Scope(1023) As Double
                Dim darkdata As CDevSpectrometerCommonNode.tData07 = Nothing
                For i As Integer = 0 To 1023
                    lamda(i) = i
                    Scope(i) = i
                Next
                darkdata.i3nm = lamda.Clone
                darkdata.s2DarkScope = Scope.Clone

                Spectrometer.mySpectrometer.DarkData = darkdata

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE
                ucCtrlLabsphere = New ucLabsphere
                Me.Controls.Add(ucCtrlLabsphere)
                ucCtrlLabsphere.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlLabsphere.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlLabsphere.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlLabsphere.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlLabsphere.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlLabsphere.evSetDeviceSettings, AddressOf SetSettings_Click
                AddHandler ucCtrlLabsphere.evSetIntegtimeAverage, AddressOf btnSetIntegAverage_Click
                AddHandler ucCtrlLabsphere.evDarkMeasure, AddressOf btnDarkMeasure

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro
                ucCtrlDarsa = New ucDarsaPro
                Me.Controls.Add(ucCtrlDarsa)
                ucCtrlDarsa.Location = New System.Drawing.Point(ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlDarsa.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlDarsa.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlDarsa.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlDarsa.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlDarsa.evSetRemoteMode, AddressOf SetRemote_Click
                AddHandler ucCtrlDarsa.evSetLocalMode, AddressOf SetLocal_Click
                AddHandler ucCtrlDarsa.evDarkMeasure, AddressOf btnDarkMeasure
                AddHandler ucCtrlDarsa.evSetGain, AddressOf btnSetGain
        End Select


        btnCreateObj.Enabled = False
    End Sub


#Region "Spectrometer Common Functions"

    Private Sub Connection_Click()

       
        If m_configs(0).communicationType = CComCommonNode.eCommType.eUSB Then
            If Spectrometer.mySpectrometer.Connection() = False Then
                MsgBox("Connection Failed, " & Spectrometer.mySpectrometer.ErrorCode)
            Else
                MsgBox("Connected")
            End If
        Else

            If Spectrometer.mySpectrometer.IsConnected = True Then
                MsgBox("Already Connected")
                Exit Sub
            End If


            If Spectrometer.mySpectrometer.Connection(m_configs(0).settings) = False Then
                ' If Spectrometer.mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Then
                'MsgBox("Connected")
                '  Exit Sub
                '   End If
                MsgBox("Connection Failed, " & Spectrometer.mySpectrometer.ErrorCode)
                Exit Sub
            Else
                MsgBox("Connected")
            End If
        End If


        m_settings = Spectrometer.mySpectrometer.DeviceInfos 'm_DeviceInfos 'DeviceInfos


        Select Case m_devType

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR
                ucCtrlSR3_AR.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlSR3_AR.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2
                ucCtrlSR_UL2.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlSR_UL2.Settings = m_settings


            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650
                ucCtrlPR650.ControlUIInit(m_settings)

                m_settings.LensIndex = 0
                m_settings.MeasSpeedValue = 10
                m_settings.NumOfAverage = 1

                ucCtrlPR650.Settings = m_settings
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655

                ucCtrlPR655.ControlUIInit(m_settings)

                m_settings.LensIndex = 0
                m_settings.ApertureIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlPR655.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670
                ucCtrlPR670.ControlUIInit(m_settings)

                m_settings.LensIndex = 0
                m_settings.ApertureIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlPR670.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705
                ucCtrlPR705.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlPR705.Settings = m_settings
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730
                ucCtrlPR730.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlPR730.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740
                ucCtrlPR740.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlPR740.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000
                ucCtrlCS1000.ControlUIInit(m_settings)

                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0


                ucCtrlCS1000.Settings = m_settings
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A
                ucCtrlCS1000A.ControlUIInit(m_settings)

                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlCS1000A.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000
                ucCtrlCS2000.ControlUIInit(m_settings)

                '파일에서 Index번호를 가져온다 설정이 안되어 있으면 0
                m_settings.ApertureIndex = 0
                m_settings.LensIndex = 0
                m_settings.MeasSpeedIndex = 0

                ucCtrlCS2000.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES
                ucCtrlAvantes.ControlUIInit(m_settings)

                m_settings.MeasSpeedValue = 10
                m_settings.NumOfAverage = 1

                ucCtrlAvantes.Settings = m_settings

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE
                ucCtrlLabsphere.ControlUIInit(m_settings)

                m_settings.MeasSpeedValue = 8
                m_settings.NumOfAverage = 10

                ucCtrlLabsphere.Settings = m_settings
        End Select

    End Sub

    Private Sub Disconnection_Click()
        Spectrometer.mySpectrometer.Disconnection()
    End Sub

    Private Sub SetRemote_Click()
        If Spectrometer.mySpectrometer.RemoteMode() = False Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub SetLocal_Click()
        If Spectrometer.mySpectrometer.LocalMode() = False Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub SetSettings_Click(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)
        If Spectrometer.mySpectrometer.SetDeviceInfos(sInfos) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnSetAperture_Click(ByVal nCodeNumber As Integer)
        If Spectrometer.mySpectrometer.SetAperture(nCodeNumber) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnMeasuringSpeed_Click(ByVal nCodeNumber As Integer, ByVal value As Double, ByVal index As Integer)
        If Spectrometer.mySpectrometer.SetMeasSpeed(nCodeNumber, value, index) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnMeasuringSpeed_Click(ByVal nCodeNumber As Integer)
        If Spectrometer.mySpectrometer.SetMeasSpeed(nCodeNumber) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnMeasuringSpeed_Click(ByVal nCodeNumber As Integer, ByVal dValue As Double)
        If Spectrometer.mySpectrometer.SetMeasSpeed(nCodeNumber, dValue) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnSetIntegAverage_Click(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)
        If Spectrometer.mySpectrometer.SetDeviceInfos(sInfos) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnSetAutoExpose_Click(ByRef sInfo As CDevSpectrometerCommonNode.DeviceOption)
        If Spectrometer.mySpectrometer.AutoExpose(sInfo) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnSetGain(ByVal nGain As Integer)
        If Spectrometer.mySpectrometer.SetAperture(nGain) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnDarkMeasure()
        Dim data As CDevSpectrometerCommonNode.tData = Nothing
        Dim sData As String

        If m_devType <> CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Then
            If Spectrometer.mySpectrometer.DarkMeasure(data) = False Then
                MsgBox(Spectrometer.mySpectrometer.ErrorCode)
            Else
                sData = "Dark Measuring Success"
                If m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES Then
                    ucCtrlAvantes.lblStateMessage.Text = sData
                ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE Then
                    ucCtrlLabsphere.lblStateMessage.Text = sData
                End If
            End If

        Else


            If Spectrometer.mySpectrometer.DarkMeasure() = False Then
                MsgBox(Spectrometer.mySpectrometer.ErrorCode)
            Else
                sData = "Dark Measuring Success"
                ucCtrlDarsa.lblStateMessage.Text = sData
            End If
        End If

    End Sub

    Private Sub btnActive(ByVal nIndex As Integer)
        If Spectrometer.mySpectrometer.DeviceActive(nIndex) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

    Private Sub btnDeActive(ByVal nIndex As Integer)
        If Spectrometer.mySpectrometer.DeviceDeActive(nIndex) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub

#Region "PR705 Functions"
    Private Sub btnLens_Click(ByVal nCodeNumber As Integer)
        If Spectrometer.mySpectrometer.SetLens(nCodeNumber) = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub
#End Region

    Private Sub Measure_Click()
        Dim data As CDevSpectrometerCommonNode.tData = Nothing
        Dim sData As String

        'If Spectrometer.mySpectrometer.test = True Then
        '    MsgBox("Ok")
        'Else
        '    MsgBox("Error")
        'End If

        If Spectrometer.mySpectrometer.Measure(data) = True Then

            sData = "Luminance = " & data.D6.s2YY & vbCrLf
            sData = sData & "CIEx = " & data.D6.s3xx & vbCrLf
            sData = sData & "CIEy = " & data.D6.s4yy & vbCrLf
            sData = sData & "CIEu = " & data.D6.s5uu & vbCrLf
            sData = sData & "CIEv = " & data.D6.s6vv & vbCrLf
            sData = sData & "X = " & data.D2.s2XX & vbCrLf
            sData = sData & "Y = " & data.D2.s3YY & vbCrLf
            sData = sData & "Z = " & data.D2.s4ZZ & vbCrLf

            For nCnt As Integer = 0 To data.D5.i3nm.Length - 1
                sData = sData & "Wavelength = " & data.D5.i3nm(nCnt) & vbTab & "Intensity = " & data.D5.s4Intensity(nCnt) & vbCrLf
            Next

            If m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR Then
                ucCtrlSR3_AR.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2 Then
                ucCtrlSR_UL2.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650 Then
                ucCtrlPR650.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655 Then
                ucCtrlPR655.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705 Then
                ucCtrlPR705.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730 Then
                ucCtrlPR730.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740 Then
                ucCtrlPR740.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000 Then
                ucCtrlCS1000.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A Then
                ucCtrlCS1000A.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000 Then
                ucCtrlCS2000.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES Then
                ucCtrlAvantes.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE Then
                ucCtrlLabsphere.MeasuredData = sData
            ElseIf m_devType = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Then
                ucCtrlDarsa.MeasuredData = sData
            End If
        Else
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If

    End Sub

    Private Sub MeasureStop_Click()
        If Spectrometer.mySpectrometer.MeasureStop = False Then
            MsgBox(Spectrometer.mySpectrometer.ErrorCode)
        End If
    End Sub
#End Region

    Private Sub frmSpectrometer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Spectrometer.mySpectrometer.Disconnection()
    End Sub
End Class