Public Class ucDispRcpAging

#Region "Defiens"

    Dim m_VisibleMode As ucSequenceBuilder.eRcpMode = ucSequenceBuilder.eRcpMode.eCell_Aging

    Dim m_bVisibleRGBWRotation As Boolean = False
    Dim m_bVisibleViewingAngle As Boolean = False

    Dim m_sampleInfos As ucSampleInfos.sSampleInfos   'Target 샘플의 정보를 저장
    Dim m_LifetimeInfos As ucSequenceBuilder.sRcpLifetime    'Lifetime과 관련 된 정보를 저장

    Public sTitleDispM6000() As String = New String() {"Source Settings", "Red Source Settings", "Green Source Settings", "Blue Source Settings"}

    Public Event evADDAgingRcp(ByVal infos As ucSequenceBuilder.sRcpLifetime)
    Public Event evUpdateAgingRcp(ByVal infos As ucSequenceBuilder.sRcpLifetime)

    Dim tcComponentMain As TabControl

    Dim tpComponent As System.Windows.Forms.TabPage
    Dim tpRGBWRotation As System.Windows.Forms.TabPage
    Dim tpViewingAngle As System.Windows.Forms.TabPage

    Public ucDispM6000(0) As ucDispCellLifetime
    Public ucDispMcPG As ucDispModule
    Public ucDispMcSG As ucDispSignalGenerator
    Public ucDispMcPanelRGBWRotion As ucPanelRGBWRotation
    Public ucDispViewingAngle As ucSweepSetting

#Region "Enums"

    Public Enum eAgingMode
        Keeping
        Operation
    End Enum

#End Region

#Region "Structure"

    Public Structure sLifetimeCommonInfos
        Dim nMode As eAgingMode
        Dim sLifetimeEnd() As ucTestEndParam.sTestEndParam
        Dim sEndStateInfos As sEndState
        Dim sMeasureInterval() As ucMeasureIntervalSetting.sSetTime
        Dim sSetInfosTheRefPD As ucRefPDSetting.sLuminance
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos  '측정 포인트 정보
        Dim sIVLSweepMeas() As ucTestEndParam.sTestEndParam
    End Structure

    Public Structure sEndState   'Lifetime이 종료될때의 상태 설정
        Dim bBiasOutput As Boolean  'Lifetime 종료시 Bias ON/OFF 설정용 , True = Output ON, False = Output Off
    End Structure

#End Region

#End Region

#Region "Properties"

    Public Property VisibleMode As ucSequenceBuilder.eRcpMode
        Get
            Return m_VisibleMode
        End Get
        Set(ByVal value As ucSequenceBuilder.eRcpMode)
            If m_VisibleMode <> value Then
                m_VisibleMode = value
                SelectSettingMode()
            End If
        End Set
    End Property

    Public Property AgingRecipe As ucSequenceBuilder.sRcpLifetime
        Get
            GetValueFromUI()
            Return m_LifetimeInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpLifetime)
            m_LifetimeInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property SampleInfos As ucSampleInfos.sSampleInfos
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_sampleInfos = value
        End Set
    End Property


    Public WriteOnly Property VisibleOperationMode As Boolean
        Set(ByVal value As Boolean)
            gbStressMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleRefPDSetting As Boolean
        Set(ByVal value As Boolean)
            ucRefPDSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleEndActionSetting As Boolean
        Set(ByVal value As Boolean)
            gbLifeTimeEndSourceSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSaveIntervalSetting As Boolean
        Set(ByVal value As Boolean)
            ucMeasureIntervalSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleEndConditionSetting As Boolean
        Set(ByVal value As Boolean)
            ucTestEndParam.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleRGBWRotation As Boolean
        Set(ByVal value As Boolean)
            m_bVisibleRGBWRotation = value
            updateViewSetting()
        End Set
    End Property

    Public WriteOnly Property VisibleViewingAngle As Boolean
        Set(ByVal value As Boolean)
            m_bVisibleViewingAngle = value
            updateViewSetting()
        End Set
    End Property


#End Region


#Region "Creator"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        spContainer.Location = New System.Drawing.Point(0, 0)
        spContainer.Dock = DockStyle.Fill

        gbLifetimeCommon.Location = New System.Drawing.Point(0, 0)
        gbLifetimeCommon.Dock = DockStyle.Fill

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Dock = DockStyle.Fill
        Panel1.BackColor = Color.Transparent

        ucDispMcPG = New ucDispModule(0)
        ucDispMcSG = New ucDispSignalGenerator
        VisibleEndConditionSetting = True
        ' ucDispMcPanelRGBWRotion = New ucPanelRGBWRotation
        ' ucDispViewingAngle = New ucSweepSetting

        'ucDispViewingAngle.ucUserPatternList.Title = "User Pattern List"
        'ucDispViewingAngle.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Degree
        'ucDispViewingAngle.ucSweepRegion.SweepType = ucMeasureSweepRegion.eSweepType._ViewingAngle
        'ucDispViewingAngle.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Degree

        tcComponentMain = New TabControl
        tcComponentMain.Location = New System.Drawing.Point(0, 0)

        Panel1.Controls.Add(tcComponentMain)

        tcComponentMain.Dock = DockStyle.Fill

        tpComponent = New System.Windows.Forms.TabPage
        tpComponent.Text = "Component"

        'tpRGBWRotation = New System.Windows.Forms.TabPage
        'tpRGBWRotation.Text = "Rotation"

        'tpViewingAngle = New System.Windows.Forms.TabPage
        'tpViewingAngle.Text = "Viewing Angle"

        ' tpViewingAngle.BackColor = Color.Transparent
        tpComponent.BackColor = Color.Transparent
        ' tpRGBWRotation.BackColor = Color.Transparent

        tcComponentMain.Controls.Add(Me.tpComponent)
        'tcComponentMain.Controls.Add(Me.tpRGBWRotation)
        'tcComponentMain.Controls.Add(Me.tpViewingAngle)

        For i As Integer = 0 To ucDispM6000.Length - 1
            ucDispM6000(i) = New ucDispCellLifetime
            ucDispM6000(i).BackColor = System.Drawing.Color.Transparent
            ' ucDispM6000(i).MinimumSize = New System.Drawing.Size(190, 260)
            ucDispM6000(i).MinimumSize = New System.Drawing.Size(890, 260)
            ucDispM6000(i).Size = New System.Drawing.Size(204, 263)
            'ucDispM6000(i).TabIndex = 34
            ucDispM6000(i).ViewMode = M7000.ucDispCellLifetime.eViewMode.eAllView
            ucDispM6000(i).VisibleChkEnable = False
            ucDispM6000(i).VisibleConstantBright = False

            If ucDispM6000.Length > 1 Then
                ucDispM6000(i).Title = sTitleDispM6000(i + 1)
            Else
                ucDispM6000(i).Title = sTitleDispM6000(i)
            End If
        Next

        'ucDispM6000(0).Title = "Red Source Settings"
        'ucDispM6000(1).Title = "Green Source Settings"
        'ucDispM6000(2).Title = "Blue Source Settings"

        For i As Integer = 0 To ucDispM6000.Length - 1
            tpComponent.Controls.Add(Me.ucDispM6000(i))
        Next

        For i As Integer = 0 To ucDispM6000.Length - 1
            If i = 0 Then
                ucDispM6000(i).Location = New System.Drawing.Point(3, 3)
            Else
                ucDispM6000(i).Location = New System.Drawing.Point(ucDispM6000(i - 1).Location.X + ucDispM6000(i - 1).Size.Width, ucDispM6000(i - 1).Location.Y)
            End If
        Next

        'ucDispM6000(0).Location = New System.Drawing.Point(3, 3)
        'ucDispM6000(1).Location = New System.Drawing.Point(ucDispM6000(0).Location.X + ucDispM6000(0).Size.Width, ucDispM6000(0).Location.Y)
        'ucDispM6000(2).Location = New System.Drawing.Point(ucDispM6000(1).Location.X + ucDispM6000(1).Size.Width, ucDispM6000(1).Location.Y)

        tpComponent.Controls.Add(Me.ucDispMcPG)
        tpComponent.Controls.Add(Me.ucDispMcSG)

        ' tpRGBWRotation.Controls.Add(Me.ucDispMcPanelRGBWRotion)

        ' tpViewingAngle.Controls.Add(Me.ucDispViewingAngle)

        '   ucDispM6000(0).Location = New System.Drawing.Point(3, 3)

        'ucDispM6000(0).Size = New System.Drawing.Size(204, 263)   '204, 263
        'ucDispM6000(0).Title = "Red Source Settings"

        'ucDispM6000(1).Location = New System.Drawing.Point(ucDispM6000(0).Location.X + ucDispM6000(0).Size.Width, ucDispM6000(0).Location.Y)
        'ucDispM6000(1).Size = New System.Drawing.Size(204, 263)   '204, 263
        'ucDispM6000(1).Title = "Green Source Settings"

        'ucDispM6000(2).Location = New System.Drawing.Point(ucDispM6000(1).Location.X + ucDispM6000(1).Size.Width, ucDispM6000(1).Location.Y)
        'ucDispM6000(2).Size = New System.Drawing.Size(204, 263)   '204, 263
        'ucDispM6000(2).Title = "Blue Source Settings"

        ucDispMcPG.Dock = DockStyle.Fill
        ucDispMcSG.Dock = DockStyle.Fill
        'ucDispMcPanelRGBWRotion.Dock = DockStyle.Fill
        'ucDispViewingAngle.Dock = DockStyle.Fill
        '-------------------------------------------------

        btnADD.Location = New System.Drawing.Point(0, 0)
        btnADD.Dock = DockStyle.Fill
        btnUpdate.Location = New System.Drawing.Point(0, 0)
        btnUpdate.Dock = DockStyle.Fill
        btnEdit.Location = New System.Drawing.Point(0, 0)
        btnEdit.Dock = DockStyle.Fill
        btnMeasPoint.Location = New System.Drawing.Point(0, 0)
        btnMeasPoint.Dock = DockStyle.Fill

        btnEdit.Enabled = False
        btnMeasPoint.Enabled = False
        '----------------

        ReDim m_LifetimeInfos.sCellInfos(ucDispM6000.Length - 1)

    End Sub


#End Region


#Region "Functions"

    Private Sub updateViewSetting()

        tcComponentMain.Controls.Clear()

        tcComponentMain.Controls.Add(Me.tpComponent)

        If m_bVisibleViewingAngle = True Then tcComponentMain.Controls.Add(Me.tpViewingAngle)
        If m_bVisibleRGBWRotation = True Then tcComponentMain.Controls.Add(Me.tpRGBWRotation)

    End Sub

    Private Sub SelectSettingMode()

        Select Case m_VisibleMode

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                ucDispMcSG.Visible = False
                ucDispMcPG.Visible = False
                For i As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(i).Visible = True
                Next

                ucDispMcPanelRGBWRotion.Enabled = False
                ucDispViewingAngle.Visible = True
                btnEdit.Enabled = False
                btnMeasPoint.Enabled = False
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                ucDispMcSG.Visible = False
                ucDispMcPG.Visible = True
                For i As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(i).Visible = False
                Next

                btnEdit.Enabled = True
                btnMeasPoint.Enabled = True
                ucDispMcPanelRGBWRotion.Enabled = False
                ucDispMcPG.ucPGImageSweep.gbSettings.Visible = True
                ucDispMcPG.ucPGInitCode.gbImportExport.Visible = False
                ucDispMcPG.ucPGInitCode.gbControl.Visible = False
                ucDispMcPG.ucPGImageSweep.SplitContainer2.SplitterDistance = 250
                ucDispMcPG.ucPGImageSweep.SplitContainer3.SplitterDistance = 100
            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                ucDispMcSG.Visible = True
                ucDispMcPG.Visible = False
                For i As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(i).Visible = False
                Next

                btnEdit.Enabled = True
                btnMeasPoint.Enabled = True
                ucDispMcPanelRGBWRotion.Enabled = True
            Case Else
                MsgBox("This parameter is not available.")
                m_VisibleMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime
                ucDispMcSG.Visible = False
                ucDispMcPG.Visible = False
                For i As Integer = 0 To ucDispM6000.Length - 1
                    ucDispM6000(i).Visible = True
                Next
        End Select
    End Sub

    Private Sub GetValueFromUI()
        m_LifetimeInfos.nMyMode = m_VisibleMode

        If rbNoStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eAgingMode.Keeping
        Else
            m_LifetimeInfos.sCommon.nMode = eAgingMode.Operation
        End If

        If rbLifeTimeEndBiasON.Checked = True Then
            m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = True
        Else
            m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = False
        End If

        m_LifetimeInfos.sCommon.sSetInfosTheRefPD = ucRefPDSetting.Setting
        m_LifetimeInfos.sCommon.sMeasureInterval = ucMeasureIntervalSetting.Setting
        m_LifetimeInfos.sCommon.sLifetimeEnd = ucTestEndParam.Settings

        Select Case m_LifetimeInfos.nMyMode

            Case ucSequenceBuilder.eRcpMode.eCell_Aging
                For i As Integer = 0 To ucDispM6000.Length - 1
                    m_LifetimeInfos.sCellInfos(i) = ucDispM6000(i).Settings

                    If ucDispM6000.Length = 1 Then
                        m_LifetimeInfos.sCellInfos(i).bEnable = True
                    End If
                Next
                '   m_LifetimeInfos.sCellInfos(0) = ucDispM6000(0).Settings
                '   m_LifetimeInfos.sCellInfos(1) = ucDispM6000(1).Settings
                '  m_LifetimeInfos.sCellInfos(2) = ucDispM6000(2).Settings
        End Select

        'm_AgingInfos.sViewingAngleInfos.sweepType = ucDispViewingAngle.SweepType
        'Select Case m_AgingInfos.sViewingAngleInfos.sweepType
        '    Case ucDispRcpIVLSweep.eSweepType.eStandard
        '        m_AgingInfos.sViewingAngleInfos.sMeasureSweepParameter = ucDispViewingAngle.ucSweepRegion.Setting
        '        m_AgingInfos.sViewingAngleInfos.dSweepList = CSeqProcessor.MakeSweepList(m_AgingInfos.sViewingAngleInfos.sMeasureSweepParameter)
        '    Case ucDispRcpIVLSweep.eSweepType.eUserPattern
        '        m_AgingInfos.sViewingAngleInfos.dSweepList = ucDispViewingAngle.ucUserPatternList.Setting
        'End Select

    End Sub

    Public Sub SetValueToUI()
        m_VisibleMode = m_LifetimeInfos.nMyMode

        Select Case m_LifetimeInfos.sCommon.nMode

            Case eAgingMode.Keeping
                rbNoStress.Checked = True
            Case eAgingMode.Operation
                rbStress.Checked = True
        End Select

        If m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = True Then
            rbLifeTimeEndBiasON.Checked = True
        Else
            rbLifeTimeEndBiasOFF.Checked = True
        End If

        ucRefPDSetting.Setting = m_LifetimeInfos.sCommon.sSetInfosTheRefPD
        ucMeasureIntervalSetting.Setting = m_LifetimeInfos.sCommon.sMeasureInterval
        ucTestEndParam.Settings = m_LifetimeInfos.sCommon.sLifetimeEnd

        Select Case m_LifetimeInfos.nMyMode

            Case ucSequenceBuilder.eRcpMode.eCell_Aging
                If m_LifetimeInfos.sCellInfos Is Nothing = False Then
                    For i As Integer = 0 To ucDispM6000.Length - 1
                        ucDispM6000(i).Settings = m_LifetimeInfos.sCellInfos(i)
                    Next
                    '  ucDispM6000(0).Settings = m_LifetimeInfos.sCellInfos(0)
                    'ucDispM6000(1).Settings = m_LifetimeInfos.sCellInfos(1)
                    '  ucDispM6000(2).Settings = m_LifetimeInfos.sCellInfos(2)
                End If
        End Select

        'ucDispViewingAngle.SweepType = m_AgingInfos.sViewingAngleInfos.sweepType
        'Select Case m_AgingInfos.sViewingAngleInfos.sweepType
        '    Case ucDispRcpIVLSweep.eSweepType.eStandard
        '        ucDispViewingAngle.ucSweepRegion.Setting = m_AgingInfos.sViewingAngleInfos.sMeasureSweepParameter
        '    Case ucDispRcpIVLSweep.eSweepType.eUserPattern
        '        ucDispViewingAngle.ucUserPatternList.Setting = m_AgingInfos.sViewingAngleInfos.dSweepList
        'End Select

    End Sub

#End Region

    Private Sub rbNoStress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoStress.CheckedChanged, rbStress.CheckedChanged

        If rbNoStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eAgingMode.Keeping

            For i As Integer = 0 To ucDispM6000.Length - 1
                If ucDispM6000 Is Nothing = False Then
                    ucDispM6000(i).Enabled = False
                End If
            Next

            rbLifeTimeEndBiasOFF.Checked = True

        ElseIf rbStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eAgingMode.Operation

            For i As Integer = 0 To ucDispM6000.Length - 1
                If ucDispM6000(i) Is Nothing = False Then
                    ucDispM6000(i).Enabled = True
                End If

            Next
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Select Case m_VisibleMode

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                Dim dlg As frmSignalGenerator = New frmSignalGenerator

                dlg.UcDispSignalGenerator1.Settings = ucDispMcSG.Settings
                If dlg.ShowDialog = DialogResult.OK Then

                    ucDispMcSG.Settings = dlg.UcDispSignalGenerator1.Settings

                End If
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                Dim dlg As frmPatternGeneratorSetting = New frmPatternGeneratorSetting

                Dim pgImageSweepInfo As M7000.ucDispPGImageSweep.sPGImageInfos

                dlg.VisibleInitCodeTabPage = ucDispMcPG.VisibleInitCodeEditTabPage
                dlg.VisiblePowerCtrlTabPage = ucDispMcPG.VisiblePowerControlTabPage
                dlg.VisiblePatternTabPage = ucDispMcPG.VisiblePatternEditTabPage

                dlg.ucPGPower.Datas = ucDispMcPG.ucPGPower.Datas
                '  dlg.ucPGGrayScale.Datas = ucDispModule.ucPGGrayScale.Datas
                dlg.ucPGInitCode.Datas = ucDispMcPG.ucPGInitCode.Datas
                pgImageSweepInfo = ucDispMcPG.ucPGImageSweep.Datas
                dlg.ucPGImageSweep.Datas = pgImageSweepInfo
                dlg.ucPGImageSweep.VisibleMode = ucDispPGImageSweep.eViewMode._Lifetime_G4S


                If dlg.ShowDialog = DialogResult.OK Then
                    Dim InitCodeInfos As UcDispPGInitCode.sInitCodeInfo = Nothing
                    'Dim sData(2) As String
                    'sData(0) = ""
                    'sData(1) = ""
                    'sData(2) = ""

                    'ucDispModule.Settings =  dlg.Datas

                    dlg.ucPGInitCode.GetPGInitCodeList(InitCodeInfos)

                    ucDispMcPG.ucPGInitCode.ucDataGrid.ClearRow()

                    'For idx As Integer = 0 To dlg.ucPGRegistor.Datas.numOfReg - 1
                    '    ucDispModule.ucPGRegistor.ucDispDataGrid.AddRowData(sData)
                    'Next

                    ucDispMcPG.ucPGPower.Datas = dlg.ucPGPower.Datas
                    '   ucDispModule.ucPGGrayScale.Datas = dlg.ucPGGrayScale.Datas
                    ucDispMcPG.ucPGInitCode.Datas = InitCodeInfos 'dlg.ucPGInitCode.Datas



                    pgImageSweepInfo = dlg.ucPGImageSweep.Datas

                    ucDispMcPG.ucPGImageSweep.Datas = pgImageSweepInfo

                    dlg.ucPGImageSweep.FlushImageMemory()
                    dlg.ucPGImageSweep.Dispose()
                Else

                    'dlg.ucPGImageSweep.FlushImageMemory()
                    dlg.ucPGImageSweep.Dispose()
                End If

            Case Else

        End Select

    End Sub


    Private Sub btnEditMeasP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasPoint.Click
        Dim dlg As frmMeasPointSetting = New frmMeasPointSetting
        dlg.Settings = m_LifetimeInfos.sCommon.sMeasPoints
        dlg.targetSize = m_sampleInfos.SampleSize
        dlg.TargetType = m_sampleInfos.sampleType

        If dlg.ShowDialog = DialogResult.OK Then
            m_LifetimeInfos.sCommon.sMeasPoints = dlg.Settings
        End If

    End Sub


    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        GetValueFromUI()

        RaiseEvent evADDAgingRcp(m_LifetimeInfos)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        GetValueFromUI()

        RaiseEvent evUpdateAgingRcp(m_LifetimeInfos)
    End Sub

    Private Sub ucDispRcpLifetime_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ucDispMcPG.Dispose()
    End Sub


    Public Shared Function ConvertStrLifetimeModeToInt(ByVal str As String) As eAgingMode
        Select Case str
            Case eAgingMode.Keeping.ToString
                Return eAgingMode.Keeping
            Case eAgingMode.Operation.ToString
                Return eAgingMode.Operation
            Case Else
                Return -1
        End Select
    End Function

    Private Sub ucDispRcpLifetime_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        FitUISize()
    End Sub

    Private Sub FitUISize()

        If tpComponent Is Nothing Then Exit Sub

        Dim parentSize As Size = tpComponent.Size

        Dim eachSize As Size = New System.Drawing.Size(parentSize.Height / 3, parentSize.Height)

        If ucDispM6000 Is Nothing Then Exit Sub

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

        'ucDispM6000(0).Location = New System.Drawing.Point(3, 3)

        'ucDispM6000(0).Size = New System.Drawing.Size(eachSize)   '204, 263

        'ucDispM6000(1).Location = New System.Drawing.Point(ucDispM6000(0).Location.X + ucDispM6000(0).Size.Width, ucDispM6000(0).Location.Y)
        'ucDispM6000(1).Size = New System.Drawing.Size(eachSize)   '204, 263

        'ucDispM6000(2).Location = New System.Drawing.Point(ucDispM6000(1).Location.X + ucDispM6000(1).Size.Width, ucDispM6000(1).Location.Y)
        'ucDispM6000(2).Size = New System.Drawing.Size(eachSize)   '204, 263
    End Sub
End Class
