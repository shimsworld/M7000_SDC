Public Class ucDispRcpImageSticking

#Region "Define"

    Friend WithEvents ucDispModule As M7000.ucDispModule
    Dim m_sampleInfos As ucSampleInfos.sSampleInfos   'Target 샘플의 정보를 저장
    Dim m_ImageStickingInfos As ucSequenceBuilder.sRcpLifetime   'Lifetime과 관련 된 정보를 저장


    Public Event evADDImageStickingRcp(ByVal infos As ucSequenceBuilder.sRcpLifetime)
    Public Event evUpdateImageStickingRcp(ByVal infos As ucSequenceBuilder.sRcpLifetime)

#End Region


#Region "Properties"

    Public Property ImageStickingRecipe As ucSequenceBuilder.sRcpLifetime
        Get
            Return m_ImageStickingInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpLifetime)
            m_ImageStickingInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property SampleInfos As ucSampleInfos.sSampleInfos
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_sampleInfos = value
        End Set
    End Property

#End Region


#Region "Creator & init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()

    End Sub

    Public Sub Init()

        Me.ucDispModule = New M7000.ucDispModule(5)
        Me.Panel1.Controls.Add(Me.ucDispModule)
       
        '
        'ucDispModule
        '
        Me.ucDispModule.Location = New System.Drawing.Point(48, 16)
        Me.ucDispModule.Name = "ucDispModule"
        Me.ucDispModule.Size = New System.Drawing.Size(415, 249)
        Me.ucDispModule.TabIndex = 0
        Me.ucDispModule.VisibleInitCodeEditTabPage = True
        Me.ucDispModule.VisiblePatternEditTabPage = True
        Me.ucDispModule.VisiblePowerControlTabPage = True


        spContainer.Location = New System.Drawing.Point(0, 0)
        spContainer.Dock = DockStyle.Fill

        gbLifetimeCommon.Location = New System.Drawing.Point(0, 0)
        gbLifetimeCommon.Dock = DockStyle.Fill

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Dock = DockStyle.Fill

        ucDispModule.Location = New System.Drawing.Point(0, 0)
        ucDispModule.Dock = DockStyle.Fill

        btnADD.Location = New System.Drawing.Point(0, 0)
        btnADD.Dock = DockStyle.Fill
        btnUpdate.Location = New System.Drawing.Point(0, 0)
        btnUpdate.Dock = DockStyle.Fill
        btnEdit.Location = New System.Drawing.Point(0, 0)
        btnEdit.Dock = DockStyle.Fill
        btnMeasPoint.Location = New System.Drawing.Point(0, 0)
        btnMeasPoint.Dock = DockStyle.Fill

        ucDispModule.ucPGImageSweep.VisibleMode = ucDispPGImageSweep.eViewMode._ImageSticking

        ucDispModule.ucPGImageSweep.gbSettings.Visible = False
        ucDispModule.ucPGInitCode.gbImportExport.Visible = False
        ucDispModule.ucPGInitCode.gbControl.Visible = False

    End Sub
#End Region


#Region "Functions"

    Private Sub GetValueFromUI()
        m_ImageStickingInfos.nMyMode = ucSequenceBuilder.eRcpMode.eModule_ImageSticking

        If rbNoStress.Checked = True Then
            m_ImageStickingInfos.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping
        Else
            m_ImageStickingInfos.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation
        End If

        If rbLifeTimeEndBiasON.Checked = True Then
            m_ImageStickingInfos.sCommon.sEndStateInfos.bBiasOutput = True
        Else
            m_ImageStickingInfos.sCommon.sEndStateInfos.bBiasOutput = False
        End If

        m_ImageStickingInfos.sCommon.sSetInfosTheRefPD = ucRefPDSetting.Setting
        m_ImageStickingInfos.sCommon.sMeasureInterval = ucMeasureIntervalSetting.Setting
        m_ImageStickingInfos.sCommon.sLifetimeEnd = ucTestEndParam.Settings
        m_ImageStickingInfos.sModuleInfos = ucDispModule.Settings

    End Sub

    Public Sub SetValueToUI()
        'm_VisibleMode = m_LifetimeInfos.nMyMode

        Select Case m_ImageStickingInfos.sCommon.nMode

            Case ucDispRcpLifetime.eLifeTimeMode.Keeping
                rbNoStress.Checked = True
            Case ucDispRcpLifetime.eLifeTimeMode.Operation
                rbStress.Checked = True
        End Select

        If m_ImageStickingInfos.sCommon.sEndStateInfos.bBiasOutput = True Then
            rbLifeTimeEndBiasON.Checked = True
        Else
            rbLifeTimeEndBiasOFF.Checked = True
        End If

        ucRefPDSetting.Setting = m_ImageStickingInfos.sCommon.sSetInfosTheRefPD
        ucMeasureIntervalSetting.Setting = m_ImageStickingInfos.sCommon.sMeasureInterval
        ucTestEndParam.Settings = m_ImageStickingInfos.sCommon.sLifetimeEnd
        ucDispModule.Settings = m_ImageStickingInfos.sModuleInfos
        ' ucDispModule.ucPGImageSweep.FlushImageMemory()
    End Sub

#End Region


#Region "Event"

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        GetValueFromUI()
        RaiseEvent evADDImageStickingRcp(m_ImageStickingInfos)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        GetValueFromUI()
        RaiseEvent evUpdateImageStickingRcp(m_ImageStickingInfos)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim dlg As frmPatternGeneratorSetting = New frmPatternGeneratorSetting

        dlg.ucPGImageSweep.VisibleMode = ucDispPGImageSweep.eViewMode._ImageSticking

        dlg.ucPGPower.Datas = ucDispModule.ucPGPower.Datas
        dlg.ucPGInitCode.Datas = ucDispModule.ucPGInitCode.Datas
        dlg.ucPGImageSweep.Datas = ucDispModule.ucPGImageSweep.Datas

        If dlg.ShowDialog = DialogResult.OK Then
            Dim InitCodeInfos As UcDispPGInitCode.sInitCodeInfo = Nothing

            ucDispModule.ucPGInitCode.ucDataGrid.ClearRow()

            dlg.ucPGInitCode.GetPGInitCodeList(InitCodeInfos)

            ucDispModule.ucPGPower.Datas = dlg.ucPGPower.Datas
            ucDispModule.ucPGInitCode.Datas = InitCodeInfos 'dlg.ucPGInitCode.Datas
            ucDispModule.ucPGImageSweep.Datas = dlg.ucPGImageSweep.Datas
        End If

    End Sub

    Private Sub btnMeasPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasPoint.Click
        Dim dlg As frmMeasPointSetting = New frmMeasPointSetting
        dlg.targetSize = m_sampleInfos.SampleSize
        dlg.TargetType = m_sampleInfos.sampleType
        dlg.Settings = m_ImageStickingInfos.sCommon.sMeasPoints

        If dlg.ShowDialog = DialogResult.OK Then
            m_ImageStickingInfos.sCommon.sMeasPoints = dlg.Settings
        End If
    End Sub

#End Region

    Private Sub ucDispRcpImageSticking_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ucDispModule.Dispose()
    End Sub
End Class
