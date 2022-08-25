Public Class frmCrateNewSeq


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        ucCommonInfo.Location = New System.Drawing.Point(0, 0)

        With g_SequenceBuilderOptions

            'Common Recipe
            ucCommonInfo.VisibleSeqTitle = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SequenceTitle)
            ucCommonInfo.VisibleSampleType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleType)
            ucCommonInfo.VisibleSampleColor = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleColor)
            ucCommonInfo.VisibleSampleSize = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleSize)
            ucCommonInfo.VisibleFillFactor = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_FillFactor)
            ucCommonInfo.VisibleComment = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_Comment)
            'ucCommonInfo.VisibleDefTemp = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_DefaultTemp)
            'ucCommonInfo.VisibleACFMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_ACFMode)
            'ucCommonInfo.VisibleLimitSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_LimitSetting)
            'ucCommonInfo.VisibleSeqEndCondition = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SequenceEndSetting)

        End With

    End Sub
  
End Class