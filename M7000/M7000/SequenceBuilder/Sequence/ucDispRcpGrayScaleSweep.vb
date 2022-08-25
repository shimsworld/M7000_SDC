Public Class ucDispRcpGrayScaleSweep

#Region "Defines"
    Friend WithEvents ucDispModule As M7000.ucDispModule
    Dim m_GraySweepMode As eGrayScaleMode = eGrayScaleMode.eRed
    Dim m_GraySweepInfos As ucSequenceBuilder.sRcpGrayScaleSweep    'GrayScaleSweep과 관련 된 정보를 저장

    Dim m_sampleInfos As ucSampleInfos.sSampleInfos   'Target 샘플의 정보를 저장

    Public Event evADDGraySweepRcp(ByVal infos As ucSequenceBuilder.sRcpGrayScaleSweep)
    Public Event evUpdateGraySweepRcp(ByVal infos As ucSequenceBuilder.sRcpGrayScaleSweep)


    Public Structure sGrayScaleInfos
        Dim nSweepMode As eGrayScaleMode
        Dim numOfData As Integer
        Dim sweepValues() As ucDispPGGrayScale.sPGGrayScale
        Dim sMeasureSweepParameter() As ucMeasureSweepRegion.sSetSweepRegion
        Dim dSweepList() As Double
    End Structure

    Public Enum eGrayScaleMode
        eRed
        eGreen
        eBlue
        eWhite
        eGrayUserPattern
    End Enum

#End Region
   
#Region "Creator & init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()

    End Sub

    Public Sub Init()

        Me.ucDispModule = New M7000.ucDispModule(4)

        Me.Panel1.Controls.Add(Me.ucDispModule)
        '
        'ucDispModule
        '
        Me.ucDispModule.AutoScroll = True
        Me.ucDispModule.Location = New System.Drawing.Point(18, 24)
        Me.ucDispModule.Name = "ucDispModule"
        Me.ucDispModule.Size = New System.Drawing.Size(455, 282)
        Me.ucDispModule.TabIndex = 1
        Me.ucDispModule.VisibleInitCodeEditTabPage = True
        Me.ucDispModule.VisiblePatternEditTabPage = True
        Me.ucDispModule.VisiblePowerControlTabPage = True

        spContainer.Location = New System.Drawing.Point(0, 0)
        spContainer.Dock = DockStyle.Fill

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Dock = DockStyle.Fill

        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Dock = DockStyle.Fill

        ucGrayScaleSweepRegion.Location = New System.Drawing.Point(0, 0)
        ucGrayScaleSweepRegion.Dock = DockStyle.Fill

        ucGrayScaleSweepTable.Location = New System.Drawing.Point(0, 0)
        ucGrayScaleSweepTable.Dock = DockStyle.Fill

        gbSelectSweepMode.Location = New System.Drawing.Point(0, 0)
        gbSelectSweepMode.Dock = DockStyle.Fill

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

        rdoRed.Checked = True
        ucDispModule.ucPGInitCode.gbImportExport.Visible = False
        ucDispModule.ucPGInitCode.gbControl.Visible = False
    End Sub
#End Region

#Region "Properties"

    Public Property GraySweepRecipe As ucSequenceBuilder.sRcpGrayScaleSweep
        Get
            Return m_GraySweepInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpGrayScaleSweep)
            m_GraySweepInfos = value
            SetValueToUI()
        End Set
    End Property


    Public Property GrayScaleSweepRegionOrTable As eGrayScaleMode
        Get
            Return m_GraySweepMode
        End Get
        Set(ByVal value As eGrayScaleMode)
            m_GraySweepMode = value

            If m_GraySweepMode = eGrayScaleMode.eGrayUserPattern Then
                ucGrayScaleSweepRegion.Hide()
                ucGrayScaleSweepTable.Show()
                ucGrayScaleSweepRegion.SweepType = ucMeasureSweepRegion.eSweepType._UserPattern
            Else
                ucGrayScaleSweepRegion.Show()
                ucGrayScaleSweepTable.Hide()
                ucGrayScaleSweepRegion.SweepType = ucMeasureSweepRegion.eSweepType._GraySweep
            End If

        End Set
    End Property

    Public WriteOnly Property SampleInfos As ucSampleInfos.sSampleInfos
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_sampleInfos = value
        End Set
    End Property

#End Region


#Region "Functions"

    Private Function GetValueFromUI() As Boolean
        Dim i As Integer

        m_GraySweepInfos.nMyMode = ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep

        With m_GraySweepInfos.sSweepInfos

            If rdoRed.Checked = True Then
                .nSweepMode = eGrayScaleMode.eRed
            ElseIf rdoGreen.Checked = True Then
                .nSweepMode = eGrayScaleMode.eGreen
            ElseIf rdoBlue.Checked = True Then
                .nSweepMode = eGrayScaleMode.eBlue
            ElseIf rdoAll.Checked = True Then
                .nSweepMode = eGrayScaleMode.eWhite
            ElseIf rdoUserPattern.Checked = True Then
                .nSweepMode = eGrayScaleMode.eGrayUserPattern
            End If

            If .nSweepMode = eGrayScaleMode.eGrayUserPattern Then
                .sMeasureSweepParameter = ucGrayScaleSweepTable.Setting
            Else
                .sMeasureSweepParameter = ucGrayScaleSweepRegion.Setting
            End If

            If .sMeasureSweepParameter Is Nothing Then
                Return False
            End If

            'GraySweepList 만드는 부분 색상별

            If .nSweepMode = eGrayScaleMode.eGrayUserPattern Then
                ReDim .sweepValues(.sMeasureSweepParameter.Length - 1)

                For i = 0 To .sMeasureSweepParameter.Length - 1
                    .sweepValues(i).nRed = .sMeasureSweepParameter(i).nRed
                    .sweepValues(i).nGreen = .sMeasureSweepParameter(i).nGreen
                    .sweepValues(i).nBlue = .sMeasureSweepParameter(i).nBlue
                Next
                .numOfData = .sMeasureSweepParameter.Length
            Else
                .dSweepList = ucGrayScaleSweepRegion.SweepList
                .numOfData = ucGrayScaleSweepRegion.SweepList.Length

                ReDim .sweepValues(.numOfData - 1)

                For i = 0 To .dSweepList.Length - 1
                    Select Case .nSweepMode
                        Case eGrayScaleMode.eRed
                            .sweepValues(i).nRed = CInt(.dSweepList(i))
                            .sweepValues(i).nGreen = 0
                            .sweepValues(i).nBlue = 0
                        Case eGrayScaleMode.eGreen
                            .sweepValues(i).nRed = 0
                            .sweepValues(i).nGreen = CInt(.dSweepList(i))
                            .sweepValues(i).nBlue = 0
                        Case eGrayScaleMode.eBlue
                            .sweepValues(i).nRed = 0
                            .sweepValues(i).nGreen = 0
                            .sweepValues(i).nBlue = CInt(.dSweepList(i))
                        Case eGrayScaleMode.eWhite
                            .sweepValues(i).nRed = CInt(.dSweepList(i))
                            .sweepValues(i).nGreen = CInt(.dSweepList(i))
                            .sweepValues(i).nBlue = CInt(.dSweepList(i))
                    End Select
                Next

            End If

        End With

        m_GraySweepInfos.sModuleInfos = ucDispModule.Settings

        Return True
    End Function

   

    Public Sub SetValueToUI()
        ' m_GraySweepMode = m_GraySweepInfos.nMyMode

        With m_GraySweepInfos.sSweepInfos

            If .nSweepMode = eGrayScaleMode.eRed Then
                rdoRed.Checked = True
            ElseIf .nSweepMode = eGrayScaleMode.eGreen Then
                rdoGreen.Checked = True
            ElseIf .nSweepMode = eGrayScaleMode.eBlue Then
                rdoBlue.Checked = True
            ElseIf .nSweepMode = eGrayScaleMode.eWhite Then
                rdoAll.Checked = True
            ElseIf .nSweepMode = eGrayScaleMode.eGrayUserPattern Then
                rdoUserPattern.Checked = True
            End If

            If GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern Then
                ucGrayScaleSweepTable.GraySetting = .sweepValues
                ucGrayScaleSweepRegion.ucListMeasSweep.ClearAllData()
            Else
                ucGrayScaleSweepRegion.Setting = .sMeasureSweepParameter
                ucGrayScaleSweepTable.ucListMeasSweep.ClearAllData()

            End If

        End With

        ucDispModule.Settings = m_GraySweepInfos.sModuleInfos

        ' .sMeasPoints()? _PSK

    End Sub

#End Region

    Public Shared Function ConvertStringToGrayScaleMode(ByVal str As String) As eGrayScaleMode
        Select Case str
            Case eGrayScaleMode.eRed.ToString
                Return eGrayScaleMode.eRed
            Case eGrayScaleMode.eGreen.ToString
                Return eGrayScaleMode.eGreen
            Case eGrayScaleMode.eBlue.ToString
                Return eGrayScaleMode.eBlue
            Case eGrayScaleMode.eWhite.ToString
                Return eGrayScaleMode.eWhite
            Case Else
                Return eGrayScaleMode.eGrayUserPattern
        End Select
    End Function


    Private Sub rdoRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoRed.CheckedChanged
        If rdoRed.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eRed
        ElseIf rdoGreen.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGreen
        ElseIf rdoBlue.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eBlue
        ElseIf rdoAll.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eWhite
        ElseIf rdoUserPattern.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern
        End If
    End Sub

    Private Sub rdoGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGreen.CheckedChanged
        If rdoRed.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eRed
        ElseIf rdoGreen.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGreen
        ElseIf rdoBlue.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eBlue
        ElseIf rdoAll.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eWhite
        ElseIf rdoUserPattern.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern
        End If
    End Sub

    Private Sub rdoBlue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBlue.CheckedChanged
        If rdoRed.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eRed
        ElseIf rdoGreen.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGreen
        ElseIf rdoBlue.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eBlue
        ElseIf rdoAll.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eWhite
        ElseIf rdoUserPattern.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern
        End If
    End Sub

    Private Sub rdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAll.CheckedChanged
        If rdoRed.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eRed
        ElseIf rdoGreen.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGreen
        ElseIf rdoBlue.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eBlue
        ElseIf rdoAll.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eWhite
        ElseIf rdoUserPattern.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern
        End If
    End Sub

    Private Sub rdoUserPattern_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUserPattern.CheckedChanged
        If rdoRed.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eRed
        ElseIf rdoGreen.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGreen
        ElseIf rdoBlue.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eBlue
        ElseIf rdoAll.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eWhite
        ElseIf rdoUserPattern.Checked = True Then
            GrayScaleSweepRegionOrTable = eGrayScaleMode.eGrayUserPattern
        End If
    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        If GetValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If
        RaiseEvent evADDGraySweepRcp(m_GraySweepInfos)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If GetValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If
        RaiseEvent evUpdateGraySweepRcp(m_GraySweepInfos)
    End Sub
   

    Private Sub btnMeasPoint_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasPoint.Click
        Dim dlg As frmMeasPointSetting = New frmMeasPointSetting
        dlg.targetSize = m_sampleInfos.SampleSize
        dlg.TargetType = m_sampleInfos.sampleType
        dlg.Settings = m_GraySweepInfos.sMeasPoints

        If dlg.ShowDialog = DialogResult.OK Then
            m_GraySweepInfos.sMeasPoints = dlg.Settings
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Dim dlg As frmPatternGeneratorSetting = New frmPatternGeneratorSetting

        dlg.ucPGPower.Datas = ucDispModule.ucPGPower.Datas
        '   dlg.ucPGGrayScale.Datas = ucDispModule.ucPGGrayScale.Datas
        dlg.ucPGInitCode.Datas = ucDispModule.ucPGInitCode.Datas
        '    dlg.ucPGImageSweep.Datas = ucDispModule.ucPGImageSweep.Datas

        If dlg.ShowDialog = DialogResult.OK Then
            Dim InitCodeInfos As UcDispPGInitCode.sInitCodeInfo = Nothing

            ucDispModule.ucPGInitCode.ucDataGrid.ClearRow()

            dlg.ucPGInitCode.GetPGInitCodeList(InitCodeInfos)

            ucDispModule.ucPGPower.Datas = dlg.ucPGPower.Datas
            '  ucDispModule.ucPGGrayScale.Datas = dlg.ucPGGrayScale.Datas
            ucDispModule.ucPGInitCode.Datas = InitCodeInfos 'dlg.ucPGInitCode.Datas
            '  ucDispModule.ucPGImageSweep.Datas = dlg.ucPGImageSweep.Datas
        End If
    End Sub


    Private Sub ucDispRcpGrayScaleSweep_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ucDispModule.Dispose()
    End Sub
End Class
