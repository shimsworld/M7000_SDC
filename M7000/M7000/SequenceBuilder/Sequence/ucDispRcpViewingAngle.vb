Imports CSMULib

Public Class ucDispRcpViewingAngle

#Region "Define"

    Dim m_ViewAngleInfos As ucSequenceBuilder.sRcpViewingAngleSweep

    Public sCaptions_SourcingUnit() As String = New String() {"Keithley", "M6000"}
    Public sTitleDispM6000() As String = New String() {"Source Settings", "Red Source Settings", "Green Source Settings", "Blue Source Settings"}

    Public Event evADDViewingAngleRcp(ByVal infos As ucSequenceBuilder.sRcpViewingAngleSweep)
    Public Event evUpdateViewingAngleRcp(ByVal infos As ucSequenceBuilder.sRcpViewingAngleSweep)

    Public ucDispM6000(2) As ucDispCellLifetime
    Dim m_InitKeithleySettings As ucKeithleySMUSettings.sKeithley

    Dim m_devModel As CDevSMUCommonNode.eModel
#End Region

#Region "Structure And Enum"

    Public Structure sViewingAngleSweepCommonInfos
        Dim sweepType As ucDispRcpIVLSweep.eSweepType
        Dim nBiasMode As ucDispRcpIVLSweep.eBiasMode
        Dim measItem As ucDispRcpIVLSweep.eMeasureItems
        Dim dBiasValue As Double
        Dim sMeasureSweepParameter() As ucMeasureSweepRegion.sSetSweepRegion
        Dim sMeasureRGBSweepParameter() As ucMeasureRGBSweepRegion.sSetSweepRegion '220826 Update by JKY
        Dim dSweepList() As Double
        Dim dLumiCorrection As Double
    End Structure

    'Public Enum eSourcingUnit
    '    _IVLSMU
    '    _M6000
    'End Enum

#End Region


#Region "Property"

    Public Property ViewingAngleRecipe As ucSequenceBuilder.sRcpViewingAngleSweep
        Get
            GetValueFromUI()
            Return m_ViewAngleInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpViewingAngleSweep)
            m_ViewAngleInfos = value
            SetValueToUI()
        End Set
    End Property

    'Public WriteOnly Property VisibleDevieType As Boolean
    '    Set(ByVal value As Boolean)
    '        lblSelSource.Visible = value
    '        cbSelSource.Visible = value
    '    End Set
    'End Property

    'Public WriteOnly Property VisibleBiasMode As Boolean
    '    Set(ByVal value As Boolean)
    '        lblSelBiasMode.Visible = value
    '        cbSelBiasMode.Visible = value
    '    End Set
    'End Property

    'Public WriteOnly Property VisibleBias As Boolean
    '    Set(ByVal value As Boolean)
    '        lblBias.Visible = value
    '        tbBiasValue.Visible = value
    '        lblBiasValueUnit.Visible = value
    '    End Set
    'End Property

    Public WriteOnly Property VisibleSweepType As Boolean
        Set(ByVal value As Boolean)
            ucSweepSetting.Label1.Visible = value
            ucSweepSetting.cbSelSweepType.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSweepRegionSettings As Boolean
        Set(ByVal value As Boolean)
            ucSweepSetting.ucUserPatternList.Visible = value
            ucSweepSetting.ucSweepRegion.Visible = value
        End Set
    End Property


#End Region


#Region "Creator,Disposer And Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        Init()
    End Sub

    Private Sub Init()

        spContainer.Dock = DockStyle.Fill

        gbCommon.Dock = DockStyle.Fill

        tlpPanel2.Dock = DockStyle.Fill
        Panel1.Dock = DockStyle.Fill

        'ucSweepSetting.Dock = DockStyle.Fill
        '  ucDispKeithley.Dock = DockStyle.Fill

        'ucUserPatternSweepList.Dock = DockStyle.Fill
        'ucMeasurementSweepSetting.Dock = DockStyle.Fill

        'With cbSweepType
        '    .Items.Clear()
        '    For i As Integer = 0 To ucSweepSetting.m_sCaptions_SweepType.Length - 1
        '        .Items.Add(ucSweepSetting.m_sCaptions_SweepType(i))
        '    Next
        '    .SelectedIndex = 0
        'End With

        'With cbSelSource
        '    .Items.Clear()
        '    For i As Integer = 0 To sCaptions_SourcingUnit.Length - 1
        '        .Items.Add(sCaptions_SourcingUnit(i))
        '    Next
        '    .SelectedIndex = 0
        '    m_ViewAngleInfos.sCommon.SourcingUnit = eSourcingUnit._IVLSMU
        'End With

        With cbBiasMode
            .Items.Clear()
            For i As Integer = 0 To ucDispRcpIVLSweep.m_sCaptions_BiasMode.Length - 1
                .Items.Add(ucDispRcpIVLSweep.m_sCaptions_BiasMode(i))
            Next
            .SelectedIndex = 1
        End With

        '=============
        'ucDispM6000
        '
        For i As Integer = 0 To ucDispM6000.Length - 1
            ucDispM6000(i) = New ucDispCellLifetime
            ucDispM6000(i).BackColor = System.Drawing.Color.Transparent
            ucDispM6000(i).MinimumSize = New System.Drawing.Size(190, 260)
            ucDispM6000(i).Size = New System.Drawing.Size(204, 263)
            ucDispM6000(i).TabIndex = 34
            ucDispM6000(i).ViewMode = M7000.ucDispCellLifetime.eViewMode.eAllView

            If ucDispM6000.Length > 1 Then
                ucDispM6000(i).Title = sTitleDispM6000(i + 1)
            Else
                ucDispM6000(i).Title = sTitleDispM6000(i)
            End If
        Next

        'ucDispM6000(0).Title = "Red Source Settings"
        'ucDispM6000(1).Title = "Green Source Settings"
        'ucDispM6000(2).Title = "Blue Source Settings"

        'Panel1
        '
        For i As Integer = 0 To ucDispM6000.Length - 1
            Me.Panel1.Controls.Add(ucDispM6000(i))
        Next
        ' Me.Panel1.Controls.Add(ucDispM6000(0))
        '  Me.Panel1.Controls.Add(ucDispM6000(1))
        ' Me.Panel1.Controls.Add(ucDispM6000(2))

        For i As Integer = 0 To ucDispM6000.Length - 1
            If i = 0 Then
                ucDispM6000(i).Location = New System.Drawing.Point(3, 3)
            Else
                ucDispM6000(i).Location = New System.Drawing.Point(ucDispM6000(i - 1).Location.X + ucDispM6000(i - 1).Size.Width, ucDispM6000(i - 1).Location.Y)
            End If
        Next

        '    ucDispM6000(0).Location = New System.Drawing.Point(3, 3)
        '    ucDispM6000(1).Location = New System.Drawing.Point(ucDispM6000(0).Location.X + ucDispM6000(0).Size.Width, ucDispM6000(0).Location.Y)
        '    ucDispM6000(2).Location = New System.Drawing.Point(ucDispM6000(1).Location.X + ucDispM6000(1).Size.Width, ucDispM6000(1).Location.Y)

        '---------------

        ucDispKeithley.Dock = DockStyle.Fill
        ucDispKeithley.rbCC.Enabled = False
        ucDispKeithley.rbCV.Enabled = False

        ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Degree
        ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Degree
        ucSweepSetting.ucSweepRegion.SweepType = ucMeasureSweepRegion.eSweepType._ViewingAngle

        m_devModel = g_ConfigInfos.SMUForIVLConfig(0).device

        ucDispKeithley.DisplayMode = m_devModel
        If g_ConfigInfos.SMUForIVLConfig(0).sRangeList.dCurrentListValue IsNot Nothing Then
            ucDispKeithley.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList
        End If

        Select Case m_devModel
            Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
                m_InitKeithleySettings = ucDispKeithley.Settings
                m_InitKeithleySettings.nIntegTimeIndex = 2
                ucDispKeithley.Settings = m_InitKeithleySettings
            Case CDevSMUCommonNode.eModel.KEITHLEY_K2400, CDevSMUCommonNode.eModel.KEITHLEY_K2410
                m_InitKeithleySettings = ucDispKeithley.Settings
                m_InitKeithleySettings.nIntegTimeIndex = 0
                m_InitKeithleySettings.WireMode = ucKeithleySMUSettings.eProve.e4Prove
                m_InitKeithleySettings.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                m_InitKeithleySettings.IntegTime_Sec = 1
                ucDispKeithley.Settings = m_InitKeithleySettings
        End Select

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                ucDispKeithley.Visible = True

                'For j As Integer = 0 To ucDispM6000.Length - 1
                '    ucDispM6000(i).Visible = False
                'Next

            ElseIf g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_M6000 Then
                ucDispKeithley.Visible = False
                For j As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(j).Visible = True
                Next
            End If
        Next


        btnADD.Dock = DockStyle.Fill
        btnUpdate.Dock = DockStyle.Fill
        btnEdit.Dock = DockStyle.Fill
        btnMeasPoint.Dock = DockStyle.Fill

        btnEdit.Enabled = False
        btnMeasPoint.Enabled = False

        'ucDispKeithley.rbCC.Enabled = False
        'ucDispKeithley.rbCV.Enabled = False
        'ucDispM6000(0).EnabledSourceMode = True
        'ucDispM6000(0).EnabledBias = True
        'ucDispM6000(1).EnabledSourceMode = True
        'ucDispM6000(1).EnabledBias = True
        'ucDispM6000(2).EnabledSourceMode = True
        'ucDispM6000(2).EnabledBias = True

        m_ViewAngleInfos.nMyMode = ucSequenceBuilder.eRcpMode.eViewingAngle

        '------------------------------------------------
        ReDim m_ViewAngleInfos.sCellInfos(ucDispM6000.Length - 1)

    End Sub

#End Region

#Region "Functions"


#Region "user define Functions"

    Private Function GetValueFromUI() As Boolean

        With m_ViewAngleInfos
            .nMyMode = ucSequenceBuilder.eRcpMode.eViewingAngle
            .sCommon.sweepType = ucSweepSetting.SweepType
            .sCommon.nBiasMode = cbBiasMode.SelectedIndex
        
            Try
                If .sCommon.nBiasMode = ucDispRcpIVLSweep.eBiasMode.eCC Then
                    .sCommon.dBiasValue = CDbl(tbBias1.Text) / 1000
                Else
                    .sCommon.dBiasValue = CDbl(tbBias1.Text)
                End If

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Return False
            End Try

            .sCommon.dLumiCorrection = CDbl(tbLumiCorrection.Text)

            .sCommon.sMeasureSweepParameter = ucSweepSetting.ucSweepRegion.Setting

            'If .sCommon.sMeasureSweepParameter Is Nothing Then
            '    Return False
            'End If

            If .sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
                .sCommon.dSweepList = CSeqProcessor.MakeSweepList(.sCommon.sMeasureSweepParameter) 'ucMeasurementSweepSetting.SweepList
            ElseIf .sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then
                .sCommon.dSweepList = ucSweepSetting.ucUserPatternList.Setting
            Else '220829 Update by JKY
                .sCommon.dSweepList = CSeqProcessor.MakeRGBSweepList(.sCommon.sMeasureRGBSweepParameter)
            End If

            If .sCommon.dSweepList Is Nothing Then Return False

            If .sCellInfos Is Nothing Then ReDim .sCellInfos(ucDispM6000.Length - 1)

            For i As Integer = 0 To ucDispM6000.Length - 1
                .sCellInfos(i) = ucDispM6000(i).Settings
                If ucDispM6000.Length = 1 Then
                    .sCellInfos(i).bEnable = True
                End If
            Next

            '     .sCellInfos(0) = ucDispM6000(0).Settings
            '   .sCellInfos(1) = ucDispM6000(1).Settings
            '  .sCellInfos(2) = ucDispM6000(2).Settings

            .sKeithleyInfos = ucDispKeithley.Settings

            '     .sCellInfos(0) = ucDispM6000(0).Settings
            '   .sCellInfos(1) = ucDispM6000(1).Settings
            '  .sCellInfos(2) = ucDispM6000(2).Settings

            'Select Case .sCommon.SourcingUnit
            '    Case eSourcingUnit._IVLSMU
            '        .sKeithleyInfos = ucDispKeithley.Settings
            '    Case eSourcingUnit._M6000

            'End Select
        End With

        Return True
    End Function

    Private Sub SetValueToUI()

        With m_ViewAngleInfos
            .nMyMode = ucSequenceBuilder.eRcpMode.eViewingAngle
            ucSweepSetting.SweepType = .sCommon.sweepType

            'cbSelSource.SelectedIndex = .sCommon.SourcingUnit

            cbBiasMode.SelectedIndex = .sCommon.nBiasMode

            If .sCommon.nBiasMode = ucDispRcpIVLSweep.eBiasMode.eCC Then
                tbBias1.Text = CStr(.sCommon.dBiasValue) * 1000
            Else
                tbBias1.Text = CStr(.sCommon.dBiasValue)
            End If

            tbLumiCorrection.Text = CStr(.sCommon.dLumiCorrection)

            If .sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
                ucSweepSetting.ucSweepRegion.Setting = .sCommon.sMeasureSweepParameter
            ElseIf .sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then
                ucSweepSetting.ucUserPatternList.Setting = .sCommon.dSweepList
            Else '220829 Update by JKY
                ucSweepSetting.ucRGBSweepRegion.Setting = .sCommon.sMeasureRGBSweepParameter
            End If


            'If .sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
            '    .sCommon.dSweepList = CSeqProcessor.MakeSweepList(.sCommon.sMeasureSweepParameter) 'ucMeasurementSweepSetting.SweepList
            'Else
            '    .sCommon.dSweepList = ucSweepSetting.ucUserPatternList.Setting
            'End If

            'If .sCommon.dSweepList Is Nothing Then Return False

            If .sCellInfos Is Nothing = False Then
                For i As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(i).Settings = .sCellInfos(i)
                Next
            End If

            ucDispKeithley.Settings = .sKeithleyInfos

            'If .sCellInfos Is Nothing = False Then
            '    ucDispM6000(0).Settings = .sCellInfos(0)
            '    ucDispM6000(1).Settings = .sCellInfos(1)
            '    ucDispM6000(2).Settings = .sCellInfos(2)

            'End If

            'Select Case .sCommon.SourcingUnit
            '    Case eSourcingUnit._IVLSMU
            '        ucDispKeithley.Settings = .sKeithleyInfos
            '    Case eSourcingUnit._M6000

            'End Select

        End With

    End Sub

#End Region


#Region "Event Handler Functions"

    Private Sub ChangedSweeptype(ByVal type As ucSweepSetting.eSweepType) Handles ucSweepSetting.ChangedSweepType
        m_ViewAngleInfos.sCommon.sweepType = type

        'If m_ViewAngleInfos.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
        '    ucMeasurementSweepSetting.Visible = True
        '    ucUserPatternSweepList.Visible = False

        'ElseIf m_ViewAngleInfos.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then
        '    ucMeasurementSweepSetting.Visible = False
        '    ucUserPatternSweepList.Visible = True
        'End If

    End Sub

    'Private Sub cbSelSource_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    '    m_ViewAngleInfos.sCommon.SourcingUnit = cbSelSource.SelectedIndex

    '    Select Case m_ViewAngleInfos.sCommon.SourcingUnit

    '        Case eSourcingUnit._IVLSMU
    '            ucDispKeithley.Visible = True
    '            ucDispM6000.Visible = False
    '        Case eSourcingUnit._M6000
    '            ucDispKeithley.Visible = False
    '            ucDispM6000.Visible = True
    '    End Select

    'End Sub

    'Private Sub cbSelBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If cbSelBiasMode.SelectedIndex = 1 Then
    '        lblBiasValueUnit.Text = "V"
    '        ucDispKeithley.rbCV.Checked = True
    '        ucDispM6000.cbBiasMode.SelectedIndex = ucDispRcpIVLSweep.eBiasMode.eCV

    '    ElseIf cbSelBiasMode.SelectedIndex = 0 Then
    '        lblBiasValueUnit.Text = "mA"
    '        ucDispKeithley.rbCC.Checked = True
    '        ucDispM6000.cbBiasMode.SelectedIndex = ucDispRcpIVLSweep.eBiasMode.eCC
    '    End If
    'End Sub

    'Private Sub tbBiasValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ucDispM6000.SetValue = tbBiasValue.Text
    'End Sub

#End Region


#End Region


    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        GetValueFromUI()
        RaiseEvent evADDViewingAngleRcp(m_ViewAngleInfos)
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        GetValueFromUI()
        RaiseEvent evUpdateViewingAngleRcp(m_ViewAngleInfos)
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

    End Sub

    Private Sub btnMeasPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasPoint.Click

    End Sub


    Private Sub FitUISize()

        '   If tpo Is Nothing Then Exit Sub

        If ucDispM6000 Is Nothing Then Exit Sub

        Dim parentSize As Size = Panel1.Size

        Dim eachSize As Size = New System.Drawing.Size(parentSize.Height / 3, parentSize.Height)

        For i As Integer = 0 To ucDispM6000.Length - 1
            If ucDispM6000(i) Is Nothing Then Exit Sub
            If i = 0 Then
                ucDispM6000(i).Location = New System.Drawing.Point(3, 3)
                ucDispM6000(i).Size = New System.Drawing.Size(eachSize)   '204, 263
            Else
                ucDispM6000(i).Location = New System.Drawing.Point(ucDispM6000(i - 1).Location.X + ucDispM6000(i - 1).Size.Width, ucDispM6000(i - 1).Location.Y)
                ucDispM6000(i).Size = New System.Drawing.Size(eachSize)   '204, 263
            End If
        Next

        'If ucDispM6000(0) Is Nothing Then Exit Sub
        'ucDispM6000(0).Location = New System.Drawing.Point(3, 3)
        'ucDispM6000(0).Size = New System.Drawing.Size(eachSize)   '204, 263

        'If ucDispM6000(1) Is Nothing Then Exit Sub
        'ucDispM6000(1).Location = New System.Drawing.Point(ucDispM6000(0).Location.X + ucDispM6000(0).Size.Width, ucDispM6000(0).Location.Y)
        'ucDispM6000(1).Size = New System.Drawing.Size(eachSize)   '204, 263

        'If ucDispM6000(2) Is Nothing Then Exit Sub
        'ucDispM6000(2).Location = New System.Drawing.Point(ucDispM6000(1).Location.X + ucDispM6000(1).Size.Width, ucDispM6000(1).Location.Y)
        'ucDispM6000(2).Size = New System.Drawing.Size(eachSize)   '204, 263
    End Sub

    Private Sub ucDispRcpViewingAngle_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        FitUISize()
    End Sub

    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBiasMode.SelectedIndexChanged
        If cbBiasMode.SelectedIndex = ucDispRcpIVLSweep.eBiasMode.eCV Then
            'lblOffsetBiasValueUnit.Text = "V"
            lblBias1Unit.Text = "V"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Degree
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Degree
            ucDispKeithley.cboBiasMode.SelectedItem = "Voltage"
        ElseIf cbBiasMode.SelectedIndex = ucDispRcpIVLSweep.eBiasMode.eCC Then
            'lblOffsetBiasValueUnit.Text = "mA"
            lblBias1Unit.Text = "mA"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Degree
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Degree
            ucDispKeithley.cboBiasMode.SelectedItem = "Current"
        End If
    End Sub

  
End Class
