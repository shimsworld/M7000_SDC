Imports CCommLib
Imports CColorAnalyzerLib

Public Class frmColorAnalyzerControl


    Dim ColorAnalyzer() As CDevColorAnalyzerAPI

    '  Public ucCtrlDispConfig As New ucConfigRS232_RS485(CDevColorAnalyzerCommonNode.SupportDeviceNames)
    Public WithEvents ucCtrlCA310 As ucCA310
    Public WithEvents ucCtrlCAxxx As ucCAxxx
    Public WithEvents ucCtrlCS100 As ucCS100A
    Dim m_configs() As ucConfigRS232_Socket_GPIB.sConfig

    Dim m_devType As CDevColorAnalyzerCommonNode.eModel

    Dim m_settings As CDevColorAnalyzerCommonNode.sSetInfos

    Dim m_devNo As Integer = 0

    Public Sub New(ByVal objColorAnalyzer() As CDevColorAnalyzerAPI, ByVal configInfos() As ucConfigRS232_Socket_GPIB.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        ColorAnalyzer = objColorAnalyzer
        m_configs = configInfos
        init()
    End Sub

    Private Sub init()

        If m_configs Is Nothing Then
            MsgBox("설정 정보 입력이 필요합니다.")
            Exit Sub
        End If

        With cbSelDeviceNo
            .Items.Clear()
            For i As Integer = 0 To ColorAnalyzer.Length - 1
                .Items.Add(CStr(i))
            Next
            .SelectedIndex = 0
        End With

        cbSelDeviceNo.Enabled = False

        m_devNo = 0

        m_devType = m_configs(0).device

        'ColorAnalyzer(m_devNo) = New CDevColorAnalyzerAPI(m_devType)


        Select Case m_devType

            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode
                ucCtrlCA310 = New ucCA310
                Me.Controls.Add(ucCtrlCA310)
                ucCtrlCA310.Location = New System.Drawing.Point(0, 20)
                ucCtrlCA310.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlCA310.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCA310.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCA310.evZeroCal, AddressOf ZeroCal_Click
                AddHandler ucCtrlCA310.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlCA310.evSetSyncMode, AddressOf btnSetSyncMode_Click
                AddHandler ucCtrlCA310.evSetDispMode, AddressOf btnSetDispMode_Click
                AddHandler ucCtrlCA310.evSetAverageMode, AddressOf btnSetAverageMode_Click
                AddHandler ucCtrlCA310.evSetBrightnessUnit, AddressOf btnSetBrightnessUnit_Click
                AddHandler ucCtrlCA310.evSetCalMode, AddressOf btnSetCalMode_Click
                AddHandler ucCtrlCA310.evSetDispDigits, AddressOf btnSetDispDigits_Click
                AddHandler ucCtrlCA310.evUpdateState, AddressOf btnUpdateState_Click

            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode
                ucCtrlCAxxx = New ucCAxxx
                Me.Controls.Add(ucCtrlCAxxx)
                ucCtrlCAxxx.Location = New System.Drawing.Point(0, 20)
                ucCtrlCAxxx.Size = New System.Drawing.Size(720, 388)

                AddHandler ucCtrlCAxxx.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCAxxx.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCAxxx.evZeroCal, AddressOf ZeroCal_Click
                AddHandler ucCtrlCAxxx.evMeasure, AddressOf Measure_Click
                AddHandler ucCtrlCAxxx.evSetSyncMode, AddressOf btnSetSyncMode_Click
                AddHandler ucCtrlCAxxx.evSetDispMode, AddressOf btnSetDispMode_Click
                AddHandler ucCtrlCAxxx.evSetAverageMode, AddressOf btnSetAverageMode_Click
                AddHandler ucCtrlCAxxx.evSetBrightnessUnit, AddressOf btnSetBrightnessUnit_Click
                AddHandler ucCtrlCAxxx.evSetCalMode, AddressOf btnSetCalMode_Click
                AddHandler ucCtrlCAxxx.evSetDispDigits, AddressOf btnSetDispDigits_Click
                AddHandler ucCtrlCAxxx.evUpdateState, AddressOf btnUpdateState_Click

                '확인 필요
                'AddHandler ucCtrlCAxxx.evSetMemChannel, AddressOf btnSetMemChannel_Click
                'AddHandler ucCtrlCAxxx.evInitialStatus, AddressOf InitialStatus

            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A

                ucCtrlCS100 = New ucCS100A
                Me.Controls.Add(ucCtrlCS100)
                ucCtrlCS100.Location = New System.Drawing.Point(0, 20) 'ucCtrlDispConfig.Location.X + ucCtrlDispConfig.Size.Width, 5)
                ucCtrlCS100.Size = New System.Drawing.Size(651, 250)

                AddHandler ucCtrlCS100.evConnection, AddressOf Connection_Click
                AddHandler ucCtrlCS100.evDisconnection, AddressOf Disconnection_Click
                AddHandler ucCtrlCS100.evMeasure, AddressOf Measure_Click

                AddHandler ucCtrlCS100.evSetCalibrationMode, AddressOf CalibrationMode_click
                AddHandler ucCtrlCS100.evSetMeasMode, AddressOf MeasuringMode_Click
                AddHandler ucCtrlCS100.evSetSpeedMode, AddressOf SpeedMode_Click
                'AddHandler ucCtrlCS100.evSetMeasMode, AddressOf 

                m_settings.sCS100Settings.calibrationMode = CDevCS100A.eCalibrationMode._Preset
                m_settings.sCS100Settings.measuringMode = CDevCS100A.eMeasuringMode._ABS
                m_settings.sCS100Settings.speedMode = CDevCS100A.eSpeedmode._FAST

        End Select

    End Sub


    Private Sub frmColorAnalyzerControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ColorAnalyzer(m_devNo).myColorAnalyzer.IsConnected = True Then
            lblStatus.Text = "Connected"

            btnUpdateState_Click()
        Else
            lblStatus.Text = "Disconnected"
        End If
    End Sub


    Private Sub Connection_Click()
        'Dim serialInfo As CCommLib.CComSerial.sSerialPortInfo = Nothing

        ''serialInfo.sPortName = ucDispConfig.COMPORT
        ''serialInfo.nBaudRate = ucDispConfig.BAUDRATE
        ''serialInfo.nDataBits = 1
        ''serialInfo.nParity = ucDispConfig.PARITYBIT
        ''serialInfo.nStopBits = ucDispConfig.STOPBIT
        ''serialInfo.nHandShake = IO.Ports.Handshake.None
        ''serialInfo.sRcvTerminator = "CR"
        ''serialInfo.sSendTerminator = "CR"
        ''serialInfo.enableTerminator = True

        If ColorAnalyzer(m_devNo).myColorAnalyzer.Connection(m_configs(0).settings) = False Then
            MsgBox("Connection Failed, " & ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            lblStatus.Text = "Connection Failed"
        Else
            MsgBox("Connected")
            lblStatus.Text = "Connected"
        End If
    End Sub

    Private Sub Disconnection_Click()
        ColorAnalyzer(m_devNo).myColorAnalyzer.Disconnection()
        lblStatus.Text = "Disconnected"
    End Sub

    Private Sub InitialStatus()
        '확인 필요
        'ColorAnalyzer(m_devNo).myColorAnalyzer.SetInitialStatus()
    End Sub


    Private Sub ZeroCal_Click()
        ColorAnalyzer(m_devNo).myColorAnalyzer.ZeroCalibration()
    End Sub

    Private Sub btnSetting_Click(sender As System.Object, e As System.EventArgs)



        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings = ucCtrlCA310.Settings

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox("Error")
            End If

        Else

        End If

    End Sub


    Private Sub btnSetMemChannel_Click(ByVal ch As Integer)


        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            MsgBox("not support function")
            'm_settings.sCA310Settings.calMode = mode

            'If ColorAnalyzer.myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer.myColorAnalyzer.ErrorMessage)
            'End If
        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.nMemChannelNo = ch

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If
        End If


    End Sub

    Private Sub Measure_Click()
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then

            Dim data As CDevCAxxxCMD.sDatas

            If ColorAnalyzer(m_devNo).myColorAnalyzer.Measure(data) = True Then

                Dim sData As String

                sData = "X = " & data.X & vbCrLf
                sData = sData & "Y = " & data.Y & vbCrLf
                sData = sData & "Z = " & data.Z & vbCrLf
                sData = sData & "Lv = " & data.Lv & vbCrLf
                sData = sData & "x = " & data.sx & vbCrLf
                sData = sData & "y = " & data.sy & vbCrLf
                sData = sData & "u' = " & data.ud & vbCrLf
                sData = sData & "v' = " & data.vd & vbCrLf
                sData = sData & "duv = " & data.duv & vbCrLf
                sData = sData & "usUser = " & data.usUser & vbCrLf
                sData = sData & "vsUser = " & data.vsUser & vbCrLf
                sData = sData & "LsUser = " & data.LsUser & vbCrLf
                sData = sData & "dEUser = " & data.dEUser & vbCrLf
                sData = sData & "T = " & data.T & vbCrLf

                ucCtrlCAxxx.MeasuredData = sData
            Else
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If

        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            Dim data As CDevCAxxxCMD.sDatas

            If ColorAnalyzer(m_devNo).myColorAnalyzer.Measure(data) = True Then

                Dim sData As String

                sData = "X = " & data.X & vbCrLf
                sData = sData & "Y = " & data.Y & vbCrLf
                sData = sData & "Z = " & data.Z & vbCrLf
                sData = sData & "Lv = " & data.Lv & vbCrLf
                sData = sData & "x = " & data.sx & vbCrLf
                sData = sData & "y = " & data.sy & vbCrLf
                sData = sData & "u' = " & data.ud & vbCrLf
                sData = sData & "v' = " & data.vd & vbCrLf
                sData = sData & "duv = " & data.duv & vbCrLf
                sData = sData & "usUser = " & data.usUser & vbCrLf
                sData = sData & "vsUser = " & data.vsUser & vbCrLf
                sData = sData & "LsUser = " & data.LsUser & vbCrLf
                sData = sData & "dEUser = " & data.dEUser & vbCrLf
                sData = sData & "T = " & data.T & vbCrLf

                ucCtrlCA310.MeasuredData = sData
            Else
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If

        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A Then

            Dim data As CDevCS100A.sDatas

            If ColorAnalyzer(m_devNo).myColorAnalyzer.Measure(data) = True Then

                Dim sData As String

                sData = "Y = " & data.dY & vbCrLf
                sData = sData & "CIEx = " & data.dCIEx & vbCrLf
                sData = sData & "CIEy = " & data.dCIEy & vbCrLf
                sData = sData & "Difference Y = " & data.dDiff_Y & vbCrLf
                sData = sData & "Difference CIEx = " & data.dDiff_CIEx & vbCrLf
                sData = sData & "Difference CIEy = " & data.dDiff_CIEy & vbCrLf


                ucCtrlCS100.lblMeasuredDatas.Text = sData
                ucCtrlCS100.lblStateMessage.Text = ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage
            Else
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If
        End If



    End Sub


#Region "CA310 Functions"


    Private Sub btnSetSyncMode_Click(ByVal modeValue As Single)

        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.syncMode = modeValue

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If

        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.syncMode = modeValue

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If


        End If
    End Sub

    Private Sub btnSetDispMode_Click(ByVal mode As Integer)
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.dispMode = mode

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If

        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then

            m_settings.sCAxxxSettings.dispMode = mode

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If

        End If
    End Sub

    Private Sub btnSetAverageMode_Click(ByVal mode As Integer)
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.avgMode = mode

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If
        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.avgMode = mode

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If

        End If
    End Sub

    Private Sub btnSetDispDigits_Click(ByVal mode As Integer)
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.dispDigits = mode

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If
        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.dispDigits = mode

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub btnSetBrightnessUnit_Click(ByVal mode As Integer)
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.brightnessMode = mode

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If
        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.brightnessMode = mode

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub btnSetCalMode_Click(ByVal mode As Integer)
        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then

            'm_settings.sCA310Settings.calMode = mode

            'If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            '    MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            'End If
        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
            m_settings.sCAxxxSettings.calMode = mode

            If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
                MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
            End If
        End If
    End Sub

    Private Sub btnUpdateState_Click()


        If ColorAnalyzer(m_devNo).myColorAnalyzer.GetSettings(m_settings) = True Then

            If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then
                'ucCtrlCA310.Settings = m_settings.sCA310Settings
            ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then
                ucCtrlCAxxx.Settings = m_settings.sCAxxxSettings
            End If

        End If

        Dim sDevInfos As String

        If m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode Then


            'If ColorAnalyzer(m_devNo).myColorAnalyzer.GetDeviceInfo(m_settings.sCA310Settings.devInfo) = True Then

            '    With m_settings.sCA310Settings
            '        sDevInfos = "Model = " & .devInfo.sModel & vbCrLf
            '        sDevInfos = sDevInfos & "FW Version = " & .devInfo.sFirmwareVersion & vbCrLf
            '        sDevInfos = sDevInfos & "ID Number = " & CStr(.devInfo.nIDNumber) & vbCrLf
            '        sDevInfos = sDevInfos & "Comm. Port = " & .devInfo.sCommPort & vbCrLf
            '    End With

            '    ucCtrlCA310.lblDeviceInfo.Text = sDevInfos

            'End If

        ElseIf m_devType = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode Then

            If ColorAnalyzer(m_devNo).myColorAnalyzer.GetDeviceInfo(m_settings.sCAxxxSettings.devInfo) = True Then

                With m_settings.sCAxxxSettings
                    sDevInfos = "Model = " & .devInfo.sModel & vbCrLf
                    sDevInfos = sDevInfos & "FW Version = " & .devInfo.sFirmwareVersion & vbCrLf
                    sDevInfos = sDevInfos & "ID Number = " & CStr(.devInfo.nIDNumber) & vbCrLf
                    sDevInfos = sDevInfos & "Comm. Port = " & .devInfo.sCommPort & vbCrLf
                End With

                ucCtrlCAxxx.lblDeviceInfo.Text = sDevInfos

            End If

        End If


    End Sub


#End Region

#Region "CS100 Functions"

    Public Sub CalibrationMode_click(ByVal mode As CDevCS100A.eCalibrationMode)
        m_settings.sCS100Settings.calibrationMode = mode

        If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
        End If
    End Sub

    Public Sub MeasuringMode_Click(ByVal mode As CDevCS100A.eMeasuringMode)
        m_settings.sCS100Settings.measuringMode = mode

        If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
        End If
    End Sub

    Public Sub SpeedMode_Click(ByVal mode As CDevCS100A.eSpeedmode)

        m_settings.sCS100Settings.speedMode = mode

        If ColorAnalyzer(m_devNo).myColorAnalyzer.SetSettings(m_settings) = False Then
            MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage)
        End If

    End Sub

#End Region


    Private Sub cbSelDeviceNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelDeviceNo.SelectedIndexChanged
        m_devNo = cbSelDeviceNo.SelectedIndex
    End Sub


End Class