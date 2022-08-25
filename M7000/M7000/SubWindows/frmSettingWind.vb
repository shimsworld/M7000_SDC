Imports System.IO

Public Class frmSettingWind

#Region "Define"


    Dim m_Config As frmConfigDevice.sConfig
    Dim m_bIsLoaded As Boolean = False
    Dim m_Settings As sSystemSettings
    ' Dim m_AllocationInfos() As sChAllocationInfo
    ' Dim m_AllocationINfosBuff() As sChAllocationInfo
    Dim m_AlocItems() As eChAllocationItem
    Dim sSampleType() As String = New String() {"Unit Cell", "Panel", "Module"}


    'Dim sChAllocItemCaptions() As String = New String() {"Ch", "Dev No Of M6000", "Ch Of M6000", "Sample Type", "Pallet No", "JIG No", "Group No Of TC", "Dev No Of TC", "Ch Of TC",
    '                                             "Group Of SG", "Dev No Of SG", "Ch Of SG", "Dev No Of PD Measure", "Ch Of PD Measure",
    '                                             "Dev No Of PG", "Ch Of PG", "Group Of PG Power", "Dev No Of PG Power", "Ch Of PG Power",
    '                                             "Group Of PG Ctrl BD", "Dev No Of PG Ctrl BD", "Ch Of PG Ctrl BD"}

    Dim sChAllocItemCaptions() As String = New String() {"Ch", "Dev No Of M6000", "Board No Of M6000", "Ch Of M6000",
                                                         "Sample Type", "Pallet No", "JIG No", "Group No Of TC", "Dev No Of TC", "Ch Of TC",
                                                         "Group Of SG", "Dev No Of SG", "Ch Of SG", "Dev No Of PD Measure", "Ch Of PD Measure",
                                                         "Group of Module", "Ch of Module Group", _
                                                         "Dev No of GNTPG", "Dev No Of McPG", "Ch Of McPG", "Group Of McPGPower", "Dev No Of McPGPower", "Ch Of McPGPower",
                                                         "Group Of McPGCtrlBD", "Dev No Of McPGCtrlBD", "Ch Of McPGCtrlBD",
                                                         "Dev No Of Switch", "Ch Of Switch", "Ch Of Pair Switch",
                                                         "Dev No Of IVL SMU ", "Ch Of IVL SMU", "IVL Use.", "Lifetime Use.", "V/A Use."}


    Dim sJIGLayoutItemCaptions() As String = New String() {"JIGNo", "SampleType", "NumOfSample", "JIGSize", "JIGLocation", "CellLayoutCol", "CellLayoutRow", "JIGBackgroundColor", "JIGOutlineColor_Sel", "JIGOutlineColor_Unsel", "JIGOutlineWidth", "Font of status"}
    Dim sDisplayUI() As String = New String() {"ListType", "ListTypeForQC", "CustomTypeForQC", "JIGLayout"}

    'Public Enum eChAllocationItem
    '    eChannel
    '    eDevNoOfM6000
    '    eChOfM6000
    '    eSampleType
    '    ePallet_No
    '    eJIG_No
    '    eGroupOfTC   '485 통신의 포트 단위(TC는 공통으로 사용)
    '    eDevNoOfTC   '485 통신 포트에 병렬로 연결되어 있는 컨트롤러의 수
    '    eChOfTC      '컨트롤러의 채널수
    '    eGroupOfSG
    '    eDevNoOfSG
    '    eChOfSG
    '    eDevNoOfPDMeasUnit
    '    eChOfPDMeasUnit
    '    eDevNoOfPG
    '    eChOfPG
    '    eGroupOfPGPower
    '    eDevNoOfPGPower
    '    eChOfPGPower
    '    eGroupOfPGCtrlBD
    '    eDevNoOfPGCtrlBD
    '    eChOfPGCtrlBD
    'End Enum

    Public Enum eChAllocationItem
        eChannel
        eDevNoOfM6000
        eBoardNoOfM6000
        eChOfM6000
        eSampleType
        ePallet_No
        eJIG_No
        eGroupOfTC   '485 통신의 포트 단위(TC는 공통으로 사용)
        eDevNoOfTC   '485 통신 포트에 병렬로 연결되어 있는 컨트롤러의 수dd
        eChOfTC      '컨트롤러의 채널수
        eGroupOfSG    '패널 구동기
        eDevNoOfSG
        eChOfSG
        eDevNoOfPDMeasUnit
        eChOfPDMeasUnit
        eGroupOfModule    '모듈 구동기
        eChOfModuleGroup
        eDevNoOfGNTPG  'GNT Systems PG
        eDevNoOfMcPG   'McScience PG
        eChOfMcPG
        eGroupOfMcPGPower
        eDevNoOfMcPGPower
        eChOfMcPGPower
        eGroupOfMcPGCtrlBD
        eDevNoOfMcPGCtrlBD
        eChOfMcPGCtrlBD
        eDevNoOfSwitch
        eChOfSwitch
        eChOfPairSwitch
        eDevNoOfSMU_IVL
        eChOfSMU_IVL
        eIVLUse
        eLifetimeUse
        eVAUse
    End Enum

    Public Enum eJIGLayoutSettingsItem
        eJIGNo
        eSampleType
        eNumOfSample
        eJIGSize
        eJIGLocation
        eCellLayoutCol
        eCellLayoutRow
        eJIGBackgroundColor
        eJIGOutlineColor_Sel
        eJIGOutlineColor_Unsel
        eJIGOutlineWidth
        _StatusMsgFont
    End Enum

    'Public Enum eDisplayMode
    '    eListType
    '    eListTypeForQC
    '    eCustomTypeForQC
    '    eJIGLayout
    'End Enum

    Public Structure sSystemSettings
        Dim ChAllocationInfos() As sChAllocationInfo
        Dim JIGLayoutInfos() As sJIGLayoutInfo
        Dim DisplayMode As ucDispMultiCtrlCommonNode.eType
    End Structure

    Public Structure sChAllocationInfo
        Dim nItems() As eChAllocationItem
        Dim nChAlocValue() As Integer
    End Structure

    Public Structure sJIGLayoutInfo
        Dim JIGNo As Integer
        Dim sampleType As ucSampleInfos.eSampleType
        Dim AddText As String
        Dim numOfSample As Integer
        Dim JIGSize As Size    'Display Size
        Dim JIGLocation As Point   'Display Location
        Dim CellLayoutCol As Integer
        Dim CellLayoutRow As Integer
        Dim JIGBackgroundColor As Color
        Dim JIGOutlineColor_Selected As Color
        Dim JIGOutlineColor_Unselected As Color
        Dim JIGOutlineWidth As Integer
        Dim statusMsgFont As System.Drawing.Font
        Dim JIGSelectToMultiChannelSelect As Boolean
    End Structure

#End Region

#Region "Create and init"

    Public Sub New(ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Config = config
        init()
    End Sub

    Private Sub init()
        'UcChAllocation1.Location = New System.Drawing.Point(0, 0)
        'UcChAllocation1.Dock = DockStyle.Fill

        gbM6000.Visible = False
        gbSG.Visible = False
        gbPDUnit.Visible = False
        gbTC.Visible = False
        gbPGGroup.Visible = False
        gbSwitch.Visible = False
        gbSW7000.Visible = False
        gbSMUForIVL.Visible = False

        ReDim m_Settings.ChAllocationInfos(m_Config.MaxCh - 1)

        Dim nItemCnt As Integer = 0
        'Dim nItems() As eChAllocationItem
        ''  Dim nChAlocValue() As Integer
        ReDim Preserve m_AlocItems(nItemCnt)
        m_AlocItems(nItemCnt) = eChAllocationItem.eChannel
        nItemCnt += 1


        ReDim Preserve m_AlocItems(nItemCnt)
        m_AlocItems(nItemCnt) = eChAllocationItem.eSampleType
        nItemCnt += 1

        cbSelSampleType.DataSource = sSampleType
        cbSelSampleType.SelectedIndex = 0

        cbSelSampleType_tpJIGLayout.DataSource = sSampleType
        cbSelSampleType.SelectedIndex = 0

        If m_Config.numOfPallet > 0 Then
            lblPallet.Enabled = True
            cbSelPallet.Enabled = True
            ReDim Preserve m_AlocItems(nItemCnt)
            m_AlocItems(nItemCnt) = eChAllocationItem.ePallet_No
            nItemCnt += 1

            With cbSelPallet
                .Items.Clear()
                If m_Config.numOfPallet = 0 Then
                    .Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.numOfPallet - 1
                        .Items.Add(i)
                    Next
                    .SelectedIndex = 0
                End If
            End With

        Else
            lblPallet.Enabled = False
            cbSelPallet.Enabled = False
        End If

        If m_Config.numOfJIG > 0 Then

            lblJIG.Enabled = True
            cbSelJIG.Enabled = True

            ReDim Preserve m_AlocItems(nItemCnt)
            m_AlocItems(nItemCnt) = eChAllocationItem.eJIG_No
            nItemCnt += 1

            With cbSelJIG
                .Items.Clear()
                If m_Config.numOfJIG = 0 Then
                    cbSelJIG.Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.numOfJIG - 1
                        .Items.Add(i)
                    Next
                    .SelectedIndex = 0
                End If
            End With

            With cbSelJIG_tpJIGLayout
                .Items.Clear()
                If m_Config.numOfJIG = 0 Then
                    cbSelJIG.Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.numOfJIG - 1
                        .Items.Add(i)
                    Next
                    .SelectedIndex = 0
                End If
            End With
        Else
            lblJIG.Enabled = False
            cbSelJIG.Enabled = False
        End If

        For i As Integer = 0 To m_Config.nDevice.Length - 1

            Select Case m_Config.nDevice(i)
                Case frmConfigSystem.eDeviceItem.eSMU_M6000
                    gbM6000.Visible = True
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfM6000
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfM6000
                    nItemCnt += 1

                    cbSelM6000Device.Items.Clear()
             
                    If m_Config.M6000Config Is Nothing Then
                        cbSelM6000Device.Text = "Nothing"
                    Else
                        For n As Integer = 0 To m_Config.M6000Config.Length - 1
                            cbSelM6000Device.Items.Add(n)
                        Next

                        cbSelM6000Device.SelectedIndex = 0
                    End If



                Case frmConfigSystem.eDeviceItem.ePG
                    gbPGGroup.Visible = True

                    If m_Config.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then

                        gbPG.Visible = True
                        gbPGPower.Visible = True
                        gbPGCtrlBD.Visible = True

                        gbPG.Enabled = True
                        gbPGPower.Enabled = True
                        gbPGCtrlBD.Enabled = True

                        cbSelPGCh.Enabled = True
                        cbSelPGCh.Visible = True

                        lblPGCh.Visible = True

                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfMcPG
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eChOfMcPG
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eGroupOfMcPGPower
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfMcPGPower
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eChOfMcPGPower
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eGroupOfMcPGCtrlBD
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfMcPGCtrlBD
                        nItemCnt += 1
                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eChOfMcPGCtrlBD
                        nItemCnt += 1

                        With cbSelPGDevice
                            .Items.Clear()
                            If m_Config.PGConfig.McPGConfig Is Nothing Then
                                .Text = "Nothing"
                            Else
                                For n As Integer = 0 To m_Config.PGConfig.McPGConfig.Length - 1
                                    .Items.Add(n)   '"Device" & Format(i + 1, "00")
                                Next
                                .SelectedIndex = 0
                            End If
                        End With

                        With cbSelPGPwrGroup
                            .Items.Clear()
                            If m_Config.PGConfig.McPGPwrConfig Is Nothing Then
                                .Text = "Nothing"
                            Else
                                For n As Integer = 0 To m_Config.PGConfig.McPGPwrConfig.Length - 1
                                    .Items.Add(n) '"Device" & Format(i + 1, "00")
                                Next
                                .SelectedIndex = 0
                            End If
                        End With

                        With cbSelPGCtrlGroup
                            .Items.Clear()
                            If m_Config.PGConfig.McPGCtrlBDConfig Is Nothing Then
                                .Text = "Nothing"
                            Else
                                For n As Integer = 0 To m_Config.PGConfig.McPGCtrlBDConfig.Length - 1
                                    .Items.Add(n) '"Device" & Format(i + 1, "00")
                                Next
                                .SelectedIndex = 0
                            End If
                        End With


                    ElseIf m_Config.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Then

                        gbPG.Visible = True
                        gbPGPower.Visible = False
                        gbPGCtrlBD.Visible = False

                        gbPG.Enabled = True
                        gbPGPower.Enabled = False
                        gbPGCtrlBD.Enabled = False

                        cbSelPGDevice.Enabled = True
                        cbSelPGDevice.Visible = True

                        cbSelPGCh.Enabled = False
                        cbSelPGCh.Visible = False

                        lblPGCh.Visible = False


                        ReDim Preserve m_AlocItems(nItemCnt)
                        m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfGNTPG
                        nItemCnt += 1


                        With cbSelPGDevice
                            .Items.Clear()
                            If m_Config.PGConfig.G4sConfig.nNumberOfDev = 0 Or m_Config.PGConfig.G4sConfig.iAllocationCh Is Nothing Then
                                .Text = "Nothing"
                            Else
                                For n As Integer = 0 To m_Config.PGConfig.G4sConfig.nNumberOfDev - 1
                                    .Items.Add(n)   '"Device" & Format(i + 1, "00")
                                Next
                                .SelectedIndex = 0
                            End If
                        End With



                        'With cbSelPGPwrGroup
                        '    .Items.Clear()
                        '    If m_Config.PGConfig.McPGPwrConfig Is Nothing Then
                        '        .Text = "Nothing"
                        '    Else
                        '        For n As Integer = 0 To m_Config.PGConfig.McPGPwrConfig.Length - 1
                        '            .Items.Add(i) '"Device" & Format(i + 1, "00")
                        '        Next
                        '        .SelectedIndex = 0
                        '    End If
                        'End With

                        'With cbSelPGCtrlGroup
                        '    .Items.Clear()
                        '    If m_Config.PGConfig.McPGCtrlBDConfig Is Nothing Then
                        '        .Text = "Nothing"
                        '    Else
                        '        For n As Integer = 0 To m_Config.PGConfig.McPGCtrlBDConfig.Length - 1
                        '            .Items.Add(i) '"Device" & Format(i + 1, "00")
                        '        Next
                        '        .SelectedIndex = 0
                        '    End If
                        'End With

                    End If



                Case frmConfigSystem.eDeviceItem.eMcSG
                    gbSG.Visible = True
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eGroupOfSG
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfSG
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfSG
                    nItemCnt += 1

                    With cbSelSGGroup
                        .Items.Clear()
                        If m_Config.SGConfig Is Nothing Then
                            .Text = "Nothing"
                        Else
                            For n As Integer = 0 To m_Config.SGConfig.Length - 1
                                .Items.Add(i) '"Device" & Format(i + 1, "00")
                            Next
                            .SelectedIndex = 0
                        End If
                    End With

                Case frmConfigSystem.eDeviceItem.ePDMeasurement
                    gbPDUnit.Visible = True
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfPDMeasUnit
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfPDMeasUnit
                    nItemCnt += 1

                    cbSelPDUnitDevice.Enabled = False

                    If m_Config.PDMeasurementUnitMaxCh > 0 Then
                        With cbSelPDUnitCh
                            .Items.Clear()

                            For n As Integer = 0 To m_Config.PDMeasurementUnitMaxCh - 1
                                .Items.Add(n)   '"Device" & Format(i + 1, "00")
                            Next
                            .SelectedIndex = 0
                        End With
                    End If


                Case frmConfigSystem.eDeviceItem.ePLC

                Case frmConfigSystem.eDeviceItem.eSpectroradiometer

                    'Case frmConfigSystem.eDeviceItem.ePR705

                    'Case frmConfigSystem.eDeviceItem.eSR3AR

                Case frmConfigSystem.eDeviceItem.eSMU_IVL
                    gbSMUForIVL.Visible = True
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfSMU_IVL
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfSMU_IVL
                    nItemCnt += 1

                    cbSelSMUForIVLDevice.Enabled = True
                    cbSelSMUforIVLCh.Enabled = True

                    If m_Config.SMUForIVLConfig Is Nothing Then
                        cbSelSMUForIVLDevice.Text = "Nothing"
                    Else
                        With cbSelSMUForIVLDevice
                            .Items.Clear()
                            For n As Integer = 0 To m_Config.SMUForIVLConfig.Length - 1
                                .Items.Add(n)
                            Next
                            .SelectedIndex = 0
                        End With
                    End If

                Case frmConfigSystem.eDeviceItem.eSwitch
                    gbSwitch.Visible = True
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfSwitch
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfSwitch
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfPairSwitch
                    nItemCnt += 1

                    cbSelSwitchDevice.Enabled = True
                    cbSelSwitchCh.Enabled = True
                    cbSelSwitchPairCh.Enabled = True
                    cbSelSwitchDevice.Items.Clear()
                 
                    If m_Config.SwitchConfig Is Nothing Then
                        cbSelSwitchDevice.Text = "Nothing"
                    Else

                        For n As Integer = 0 To m_Config.SwitchConfig.Length - 1
                            cbSelSwitchDevice.Items.Add(n)
                        Next
                        cbSelSwitchDevice.SelectedIndex = 0
                    End If

                Case frmConfigSystem.eDeviceItem.eTC

                    gbTC.Visible = True
                    With cbSelTCGroup
                        .Items.Clear()
                        If m_Config.TCConfig Is Nothing Then
                            cbSelTCGroup.Text = "Nothing"
                        Else
                            For n As Integer = 0 To m_Config.TCConfig.Length - 1
                                .Items.Add(n) '"Device" & Format(i + 1, "00")
                            Next
                            .SelectedIndex = 0
                        End If
                    End With

                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eGroupOfTC
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfTC
                    nItemCnt += 1
                    ReDim Preserve m_AlocItems(nItemCnt)
                    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfTC
                    nItemCnt += 1

                    'Case frmConfigSystem.eDeviceItem.eTC_NX1
                    '    gbTC.Enabled = True
                    '    With cbSelTCGroup
                    '        .Items.Clear()
                    '        If m_Config.NX1Config Is Nothing Then
                    '            cbSelTCGroup.Text = "Nothing"
                    '        Else
                    '            For n As Integer = 0 To m_Config.NX1Config.Length - 1
                    '                .Items.Add(n) '"Device" & Format(i + 1, "00")
                    '            Next
                    '            .SelectedIndex = 0
                    '        End If
                    '    End With

                    '    ReDim Preserve m_AlocItems(nItemCnt)
                    '    m_AlocItems(nItemCnt) = eChAllocationItem.eGroupOfTC
                    '    nItemCnt += 1
                    '    ReDim Preserve m_AlocItems(nItemCnt)
                    '    m_AlocItems(nItemCnt) = eChAllocationItem.eDevNoOfTC
                    '    nItemCnt += 1
                    '    ReDim Preserve m_AlocItems(nItemCnt)
                    '    m_AlocItems(nItemCnt) = eChAllocationItem.eChOfTC
                    '    nItemCnt += 1
                    'Case frmConfigSystem.eDeviceItem.eTHC_98585

                Case frmConfigSystem.eDeviceItem.eCamera
            End Select
        Next

        ReDim Preserve m_AlocItems(nItemCnt)
        m_AlocItems(nItemCnt) = eChAllocationItem.eIVLUse
        nItemCnt += 1
        ReDim Preserve m_AlocItems(nItemCnt)
        m_AlocItems(nItemCnt) = eChAllocationItem.eLifetimeUse
        nItemCnt += 1
        ReDim Preserve m_AlocItems(nItemCnt)
        m_AlocItems(nItemCnt) = eChAllocationItem.eVAUse
        nItemCnt += 1

        For i As Integer = 0 To sDisplayUI.Length - 1
            cbDisplayMainUI.Items.Add(sDisplayUI(i))
        Next
        cbDisplayMainUI.SelectedIndex = 0

        Dim sListColHeader(m_AlocItems.Length - 1) As String
        Dim sListColWidthRatio As String
        Dim nColWidth As Integer = 95 / m_AlocItems.Length

        sListColHeader(0) = sChAllocItemCaptions(m_AlocItems(0))
        sListColWidthRatio = CStr(5)
        For i As Integer = 1 To m_AlocItems.Length - 1
            sListColHeader(i) = sChAllocItemCaptions(m_AlocItems(i))
            sListColWidthRatio = sListColWidthRatio & "," & nColWidth
        Next

        ucListChAllocation.ColHeader = sListColHeader
        ucListChAllocation.ColHeaderWidthRatio = sListColWidthRatio

        Me.GroupBox3.Controls.Add(Me.ucListJIGSettings)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 386)
        Me.GroupBox3.Size = New System.Drawing.Size(907, 279)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False


    End Sub

#End Region

#Region "Frame Event Haneler functions"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If MsgBox("Are you sure?", MsgBoxStyle.OkCancel, "ChAllocation") = MsgBoxResult.Ok Then
            '   SaveAllocationData(SystemChAllocation)  'YSR
            GetSettingValueFromDisplayTabPage(m_Settings)

            GetValueFromJIGLayoutTabPage(m_Settings.JIGLayoutInfos)
            If SaveSystemSettings(m_Settings) = False Then
                Exit Sub
            End If

            ListUPChannelAllocation(m_Settings.ChAllocationInfos)
        End If
    End Sub

    Private Sub frmChAllocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If LoadSystemSettings(m_Settings) = True Then
            ListUPChannelAllocation(m_Settings.ChAllocationInfos)

            ucListJIGSettings.ClearAllData()
            For i As Integer = 0 To m_Settings.JIGLayoutInfos.Length - 1
                AddJIGLayoutList(m_Settings.JIGLayoutInfos(i))
            Next
        Else
            m_Settings.ChAllocationInfos = Nothing
            m_Settings.JIGLayoutInfos = Nothing
        End If

        'YSR
        'If LoadAllocationData(SystemChAllocation) = False Then
        '    Exit Sub
        'End If

        '   UcChAllocation1.SysAllocationSet = SystemChAllocation
        cbSelJIG_tpJIGLayout.SelectedIndex = ucJIG.JIGNo
        cbSelSampleType_tpJIGLayout.SelectedIndex = ucJIG.SampleType
        tbNumOfSample_tpJIGLayout.Text = ucJIG.NumberOfCell
        lblJIGBackColor_tpJIGLayout.BackColor = ucJIG.JIGColor
        lblJIGOutlineColorAtSel_tpJIGLayout.BackColor = ucJIG.OutlineColor_Selected
        lblJIGOutlineColorAtUnsel_tpJIGLayout.BackColor = ucJIG.OutlineColor_Unselected
        tbJIGOutlineWidth_tpJIGLayout.Text = ucJIG.OutlineWidth
        tbJIGSizeHeight_tpJIGLayout.Text = ucJIG.Size.Height
        tbJIGSizeWidth_tpJIGLayout.Text = ucJIG.Size.Width
        tbCellLayoutCol_tpJIGLayout.Text = ucJIG.CellLayout_Col
        tbCellLayoutRow_tpJIGLayout.Text = ucJIG.CellLayout_Row

        cbDisplayMainUI.SelectedIndex = m_Settings.DisplayMode
        m_bIsLoaded = True
    End Sub

    Private Sub btnCalcle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcle.Click
        Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' SaveAllocationData(SystemChAllocation)
        If SaveSystemSettings(m_Settings) = False Then
            Exit Sub
        End If
        '   ListUPChannelAllocation(m_Settings.ChAllocationInfos)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        'LoadAllocationData(SystemChAllocation)
        'UcChAllocation1.SysAllocationSet = SystemChAllocation
        If LoadSystemSettings(m_Settings) = False Then
            Exit Sub
        End If
        ListUPChannelAllocation(m_Settings.ChAllocationInfos)
    End Sub

#End Region

#Region "Channel Allocation Functions"

    Private Sub cbSelM6000Device_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelM6000Device.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelM6000Device.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try
        With cbSelM6000Ch
            .Items.Clear()
            If m_Config.M6000Config Is Nothing Then
                cbSelM6000Ch.Text = "Nothing"
            Else
                Dim nCh As Integer = m_Config.M6000Config(nDevice).numberOfBoard * 4
                For i As Integer = 0 To nCh - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0
            End If
        End With
    End Sub


    Private Sub cbSelTCGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelTCGroup.SelectedIndexChanged
        Dim nGroup As Integer

        Try
            nGroup = cbSelTCGroup.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.TCConfig Is Nothing = False Then
            With cbSelTCDevice
                .Items.Clear()
                If m_Config.TCConfig Is Nothing Then
                    cbSelTCDevice.Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.TCConfig(nGroup).numberOfDevice - 1
                        .Items.Add(i)   '"Device" & Format(i + 1, "00")
                    Next
                    .SelectedIndex = 0
                End If
            End With
        End If

    End Sub

    Private Sub cbSelTCDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelTCDevice.SelectedIndexChanged
        Dim nDevice As Integer
        Dim nGroup As Integer
        Try
            nDevice = cbSelTCDevice.SelectedIndex
            nGroup = cbSelTCGroup.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.TCConfig Is Nothing = False Then

            Select Case g_ConfigInfos.TCConfig(nGroup).device

                Case CDevTCCommonNode.eModel._NX1
                    With cbSelTCChannel
                        .Items.Clear()
                        If m_Config.TCConfig Is Nothing Then
                            cbSelTCChannel.Text = "Nothing"
                        Else
                            'For i As Integer = 0 To 7
                            .Items.Add(0)   '"Device" & Format(i + 1, "00")
                            ' Next
                            .SelectedIndex = 0
                        End If
                    End With
                Case CDevTCCommonNode.eModel._MC9
                    With cbSelTCChannel
                        .Items.Clear()
                        If m_Config.TCConfig Is Nothing Then
                            cbSelTCChannel.Text = "Nothing"
                        Else
                            For i As Integer = 0 To 7
                                .Items.Add(i)   '"Device" & Format(i + 1, "00")
                            Next
                            .SelectedIndex = 0
                        End If
                    End With
                Case CDevTCCommonNode.eModel._TOHO_TTM004
                    With cbSelTCChannel
                        .Items.Clear()
                        If m_Config.TCConfig Is Nothing Then
                            cbSelTCChannel.Text = "Nothing"
                        Else
                            .Items.Add(0)   '"Device" & Format(i + 1, "00")
                            .SelectedIndex = 0
                        End If
                    End With
                Case CDevTCCommonNode.eModel._K601
                    With cbSelTCChannel
                        .Items.Clear()
                        If m_Config.TCConfig Is Nothing Then
                            cbSelTCChannel.Text = "Nothing"
                        Else
                            For i As Integer = 0 To 15
                                .Items.Add(i)   '"Device" & Format(i + 1, "00")
                            Next
                            .SelectedIndex = 0
                        End If
                    End With
            End Select
        End If

    End Sub

    Private Sub cbSelSGGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSGGroup.SelectedIndexChanged
        Dim nGroup As Integer

        Try
            nGroup = cbSelSGGroup.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        With cbSelSGDevice
            .Items.Clear()
            If m_Config.SGConfig Is Nothing Then
                .Text = "Nothing"
            Else
                For i As Integer = 0 To m_Config.SGConfig(nGroup).numberOfDevice - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub cbSelSGDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSGDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelSGDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try
        With cbSelSGCh
            .Items.Clear()
            If m_Config.SGConfig Is Nothing Then
                .Text = "Nothing"
            Else
                Dim nCh As Integer = m_Config.SGConfig(nDevice).iAllocationCh.Length
                For i As Integer = 0 To nCh - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub cbSelPDUnitDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPDUnitDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelPDUnitDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try
        With cbSelPDUnitCh
            .Items.Clear()

            Dim nCh As Integer = m_Config.PDMeasurementUnitMaxCh
            For i As Integer = 0 To nCh - 1
                .Items.Add(i)   '"Device" & Format(i + 1, "00")
            Next
            .SelectedIndex = 0

        End With
    End Sub

    Private Sub cbSelPGDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPGDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelPGDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then

            With cbSelPGCh
                .Items.Clear()

                Dim nCh As Integer = m_Config.PGConfig.McPGConfig(nDevice).iAllocationCh.Length
                For i As Integer = 0 To nCh - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0

            End With

        End If

    End Sub

    Private Sub cbSelPGPwrGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPGPwrGroup.SelectedIndexChanged
        Dim nGroup As Integer

        Try
            nGroup = cbSelPGPwrGroup.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
            With cbSelPGPwrDevice
                .Items.Clear()
                If m_Config.PGConfig.McPGPwrConfig Is Nothing Then
                    .Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.PGConfig.McPGPwrConfig(nGroup).numberOfDevice - 1
                        .Items.Add(i)   '"Device" & Format(i + 1, "00")
                    Next
                    .SelectedIndex = 0
                End If
            End With
        End If

    End Sub

    Private Sub cbSelPGPwrDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPGPwrDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelPGPwrDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
            With cbSelPGPwrCh
                .Items.Clear()

                Dim nCh As Integer = 1
                For i As Integer = 0 To nCh - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0

            End With
        End If

    End Sub

    Private Sub cbSelPGCtrlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPGCtrlGroup.SelectedIndexChanged
        Dim nGroup As Integer

        Try
            nGroup = cbSelPGPwrGroup.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
            With cbSelPGCtrlDevice
                .Items.Clear()
                If m_Config.PGConfig.McPGCtrlBDConfig Is Nothing Then
                    .Text = "Nothing"
                Else
                    For i As Integer = 0 To m_Config.PGConfig.McPGCtrlBDConfig(nGroup).numberOfDevice - 1
                        .Items.Add(i)   '"Device" & Format(i + 1, "00")
                    Next
                    .SelectedIndex = 0
                End If
            End With
        End If

    End Sub

    Private Sub cbSelPGCtrlDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelPGCtrlDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelPGCtrlDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
            With cbSelPGCtrlCh
                .Items.Clear()

                Dim nCh As Integer = 4
                For i As Integer = 0 To nCh - 1
                    .Items.Add(i)   '"Device" & Format(i + 1, "00")
                Next
                .SelectedIndex = 0

            End With
        End If

    End Sub

    Private Sub cbSelSwitchDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSwitchDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelSwitchDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try
        With cbSelSwitchCh
            .Items.Clear()

            For i As Integer = 0 To m_Config.SwitchConfig(nDevice).iAllocationCh.Length - 1
                .Items.Add(i)   '"Device" & Format(i + 1, "00")
            Next
            .SelectedIndex = 0
        End With

        With cbSelSwitchPairCh
            .Items.Clear()
            For i As Integer = 0 To m_Config.SwitchConfig(nDevice).iAllocationCh.Length - 1
                .Items.Add(i)
            Next
            .SelectedIndex = 0
        End With
    End Sub

    'Private Sub cbSelSW7000Device_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSW7000Device.SelectedIndexChanged
    '    Dim nDevice As Integer

    '    Try
    '        nDevice = cbSelSW7000Device.SelectedIndex
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    With cbSelSW7000Ch
    '        .Items.Clear()

    '        For i As Integer = 0 To m_Config.SW7000Config(nDevice).iAllocationCh.Length - 1
    '            .Items.Add(i)   '"Device" & Format(i + 1, "00")
    '        Next
    '        .SelectedIndex = 0
    '    End With
    'End Sub

    Private Sub cbSelK23xDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSMUForIVLDevice.SelectedIndexChanged
        Dim nDevice As Integer

        Try
            nDevice = cbSelSMUForIVLDevice.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try
        With cbSelSMUforIVLCh
            .Items.Clear()
            'For i As Integer = 0 To m_Config.K23XConfig(nDevice).iAllocationCh.Length - 1
            .Items.Add(0)   '"Device" & Format(i + 1, "00")
            'Next
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub UcChAllocation1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  SystemConfig = 'frmSystemConfig.sSytemConfig
        If LoadSystemSettings(m_Settings) = False Then
            Exit Sub
        End If
        ListUPChannelAllocation(m_Settings.ChAllocationInfos)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim AllocationDataBuff As sChAllocationInfo = Nothing

        GetForm_AllocationData(AllocationDataBuff)

        AddChAllocationInfo(AllocationDataBuff)

        ListUPChannelAllocation(m_Settings.ChAllocationInfos)

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        ucListChAllocation.ClearAllData()

        m_Settings.ChAllocationInfos = Nothing
        '     ReDim m_Settings.ChAllocationInfos(m_Config.MaxCh - 1)

    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        Dim SelectedLine As Integer

        ucListChAllocation.GetSelectedRowNumber(SelectedLine)

        DelChAllocationInfo(SelectedLine)

        ListUPChannelAllocation(m_Settings.ChAllocationInfos)

        'ucDispChAllocation.DelSelectedRow(SelectedLine)

    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click

        Dim SelectedLine As Integer
        Dim AllocationDataBuff As sChAllocationInfo = Nothing

        GetForm_AllocationData(AllocationDataBuff)

        ucListChAllocation.GetSelectedRowNumber(SelectedLine)

        UpdateAllocationInfo(SelectedLine, AllocationDataBuff)

        ListUPChannelAllocation(m_Settings.ChAllocationInfos)

    End Sub

    Private Sub GetForm_AllocationData(ByRef AllocationData As sChAllocationInfo)
        With AllocationData

            ReDim AllocationData.nItems(m_AlocItems.Length - 1)
            ReDim AllocationData.nChAlocValue(m_AlocItems.Length - 1)

            For i As Integer = 0 To m_AlocItems.Length - 1

                Select Case m_AlocItems(i)

                    Case eChAllocationItem.eChannel
                        AllocationData.nItems(i) = eChAllocationItem.eChannel
                        AllocationData.nChAlocValue(i) = 0   'List에 등록 될때 자동으로 변경시켜야함.

                    Case eChAllocationItem.eDevNoOfM6000
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfM6000
                        If chkEnableM6000.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelM6000Device.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfM6000
                        AllocationData.nItems(i) = eChAllocationItem.eChOfM6000
                        If chkEnableM6000.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelM6000Ch.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfPDMeasUnit
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfPDMeasUnit
                        If chkEnablePDUnit.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPDUnitDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfPDMeasUnit
                        AllocationData.nItems(i) = eChAllocationItem.eChOfPDMeasUnit
                        If chkEnablePDUnit.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPDUnitCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eGroupOfMcPGCtrlBD
                        AllocationData.nItems(i) = eChAllocationItem.eGroupOfMcPGCtrlBD
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGCtrlGroup.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eGroupOfMcPGPower
                        AllocationData.nItems(i) = eChAllocationItem.eGroupOfMcPGPower
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGPwrGroup.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfGNTPG
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfGNTPG
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfMcPG
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfMcPG
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfMcPGCtrlBD
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfMcPGCtrlBD
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGCtrlDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfMcPGPower
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfMcPGPower
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGPwrDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfMcPG
                        AllocationData.nItems(i) = eChAllocationItem.eChOfMcPG
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfMcPGCtrlBD
                        AllocationData.nItems(i) = eChAllocationItem.eChOfMcPGCtrlBD
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGCtrlCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfMcPGPower
                        AllocationData.nItems(i) = eChAllocationItem.eChOfMcPGPower
                        If chkEnablePG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelPGPwrCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eGroupOfSG
                        AllocationData.nItems(i) = eChAllocationItem.eGroupOfSG
                        If chkEnableSG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSGGroup.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfSG
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfSG
                        If chkEnableSG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSGDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfSG
                        AllocationData.nItems(i) = eChAllocationItem.eChOfSG
                        If chkEnableSG.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSGCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfTC
                        AllocationData.nItems(i) = eChAllocationItem.eChOfTC
                        If chkEnableTC.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelTCChannel.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfTC
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfTC
                        If chkEnableTC.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelTCDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eGroupOfTC
                        AllocationData.nItems(i) = eChAllocationItem.eGroupOfTC
                        If chkEnableTC.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelTCGroup.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eJIG_No
                        AllocationData.nItems(i) = eChAllocationItem.eJIG_No
                        AllocationData.nChAlocValue(i) = cbSelJIG.SelectedIndex
                    Case eChAllocationItem.ePallet_No
                        AllocationData.nItems(i) = eChAllocationItem.ePallet_No
                        AllocationData.nChAlocValue(i) = cbSelPallet.SelectedIndex
                    Case eChAllocationItem.eSampleType
                        AllocationData.nItems(i) = eChAllocationItem.eSampleType
                        AllocationData.nChAlocValue(i) = cbSelSampleType.SelectedIndex
                    Case eChAllocationItem.eDevNoOfSwitch
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfSwitch
                        If chkEnableK7001.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSwitchDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfSwitch
                        AllocationData.nItems(i) = eChAllocationItem.eChOfSwitch
                        If chkEnableK7001.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSwitchCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If

                    Case eChAllocationItem.eChOfPairSwitch
                        AllocationData.nItems(i) = eChAllocationItem.eChOfPairSwitch
                        If chkEnableK7001.Checked = True Then
                            AllocationData.nChAlocValue(i) = cbSelSwitchPairCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eDevNoOfSMU_IVL
                        AllocationData.nItems(i) = eChAllocationItem.eDevNoOfSMU_IVL
                        If chkEnableSMU_IVL.Enabled = True Then
                            AllocationData.nChAlocValue(i) = cbSelSMUForIVLDevice.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eChOfSMU_IVL
                        AllocationData.nItems(i) = eChAllocationItem.eChOfSMU_IVL
                        If chkEnableSMU_IVL.Enabled = True Then
                            AllocationData.nChAlocValue(i) = cbSelSMUforIVLCh.SelectedIndex
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If

                    Case eChAllocationItem.eIVLUse
                        AllocationData.nItems(i) = eChAllocationItem.eIVLUse
                        If chkIVLSweepUse.Checked = True Then
                            AllocationData.nChAlocValue(i) = 0
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eLifetimeUse
                        AllocationData.nItems(i) = eChAllocationItem.eLifetimeUse
                        If chkLifetimeUse.Checked = True Then
                            AllocationData.nChAlocValue(i) = 0
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                    Case eChAllocationItem.eVAUse
                        AllocationData.nItems(i) = eChAllocationItem.eVAUse
                        If chkViewingAngleUse.Checked = True Then
                            AllocationData.nChAlocValue(i) = 0
                        Else
                            AllocationData.nChAlocValue(i) = -1
                        End If
                End Select
            Next
        End With

    End Sub

  

    Private Sub AddChAllocationInfo(ByVal AllocationData As sChAllocationInfo)
        If m_Settings.ChAllocationInfos Is Nothing Then
            ReDim m_Settings.ChAllocationInfos(0)
            m_Settings.ChAllocationInfos(0) = AllocationData
        Else
            ReDim Preserve m_Settings.ChAllocationInfos(m_Settings.ChAllocationInfos.Length)
            m_Settings.ChAllocationInfos(m_Settings.ChAllocationInfos.Length - 1) = AllocationData
        End If
    End Sub

    Private Sub DelChAllocationInfo(ByVal index As Integer)

        Dim AllocationDataBuff() As sChAllocationInfo = Nothing

        If m_Settings.ChAllocationInfos Is Nothing Then
            Exit Sub
        End If

        ' AllocationDataBuff = m_AllocationINfosBuff.Clone
        ReDim AllocationDataBuff(m_Settings.ChAllocationInfos.Length - 2)

        For i As Integer = 0 To AllocationDataBuff.Length - 1
            If i < index Then
                AllocationDataBuff(i) = m_Settings.ChAllocationInfos(i)
            Else
                AllocationDataBuff(i) = m_Settings.ChAllocationInfos(i + 1)
            End If
        Next

        m_Settings.ChAllocationInfos = AllocationDataBuff.Clone

    End Sub

    Private Sub UpdateAllocationInfo(ByVal index As Integer, ByVal AllocationData As sChAllocationInfo)

        Dim AllocationDataBuff() As sChAllocationInfo = Nothing

        If m_Settings.ChAllocationInfos Is Nothing Then
            Exit Sub
        Else
            AllocationDataBuff = m_Settings.ChAllocationInfos.Clone
            AllocationDataBuff(index) = AllocationData
        End If

        m_Settings.ChAllocationInfos = AllocationDataBuff.Clone
    End Sub

    Private Sub ListUPChannelAllocation(ByVal AllocationData() As sChAllocationInfo)

        Dim sData(m_AlocItems.Length - 1) As String

        ucListChAllocation.ClearAllData()

        For i As Integer = 0 To AllocationData.Length - 1
            sData(0) = i + 1

            If AllocationData(i).nChAlocValue Is Nothing = False Then
                If sData.Length = AllocationData(i).nChAlocValue.Length Then
                    For n As Integer = 1 To AllocationData(i).nChAlocValue.Length - 1
                        If AllocationData(i).nItems(n) = eChAllocationItem.eSampleType Then
                            sData(n) = sSampleType(AllocationData(i).nChAlocValue(n))
                        Else
                            sData(n) = AllocationData(i).nChAlocValue(n).ToString
                        End If
                    Next
                    ucListChAllocation.AddRowData(sData)
                End If
                
            End If
        Next
    End Sub

#End Region


#Region "JIG Layout Functions"


#Region "control event handler functions of JIG Layout Tabpage"


    Private Sub lblJIGBackColor_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblJIGBackColor_tpJIGLayout.Click
        Dim colorDlg As New ColorDialog

        If colorDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblJIGBackColor_tpJIGLayout.BackColor = colorDlg.Color
            ucJIG.JIGColor = colorDlg.Color
        End If
    End Sub

    Private Sub lblJIGOutlineColorAtSel_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblJIGOutlineColorAtSel_tpJIGLayout.Click
        Dim colorDlg As New ColorDialog

        If colorDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblJIGOutlineColorAtSel_tpJIGLayout.BackColor = colorDlg.Color
            ucJIG.OutlineColor_Selected = colorDlg.Color
        End If
    End Sub

    Private Sub lblJIGOutlineColorAtUnsel_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblJIGOutlineColorAtUnsel_tpJIGLayout.Click
        Dim colorDlg As New ColorDialog

        If colorDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblJIGOutlineColorAtUnsel_tpJIGLayout.BackColor = colorDlg.Color
            ucJIG.OutlineColor_Unselected = colorDlg.Color
        End If
    End Sub

    Private Sub lblJIGLayout_StatusMsgFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblJIGLayout_StatusMsgFont.Click
        Dim fontDlg As New Windows.Forms.FontDialog
        Dim fontInfo As System.Drawing.Font

        If fontDlg.ShowDialog Then
            fontInfo = fontDlg.Font
            lblJIGLayout_StatusMsgFont.Font = fontInfo
            lblJIGLayout_StatusMsgFont.Text = fontInfo.ToString
            ucJIG.StatusMsgFont = fontInfo
        End If
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        GetValueFromJIGLayoutTabPage(m_Settings.JIGLayoutInfos)
    End Sub

    Private Sub cbSelSampleType_tpJIGLayout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSampleType_tpJIGLayout.SelectedIndexChanged
        If m_bIsLoaded = False Then Exit Sub
        Try
            ucJIG.SampleType = cbSelSampleType_tpJIGLayout.SelectedIndex
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tbNumOfSample_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumOfSample_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Try
            ucJIG.NumberOfCell = tbNumOfSample_tpJIGLayout.Text

            If ucJIG.NumberOfCell > 1 Then
                chkSelJIGToMultiChannelSelect_tpJIGLayout.Enabled = True
            Else
                chkSelJIGToMultiChannelSelect_tpJIGLayout.Enabled = False
                chkSelJIGToMultiChannelSelect_tpJIGLayout.Checked = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tbJIGOutlineWidth_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJIGOutlineWidth_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Try
            ucJIG.OutlineWidth = tbJIGOutlineWidth_tpJIGLayout.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tbJIGSizeWidth_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJIGSizeWidth_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Dim width As Integer
        Dim height As Integer
        Try
            width = CInt(tbJIGSizeWidth_tpJIGLayout.Text)
            height = CInt(tbJIGSizeHeight_tpJIGLayout.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        ucJIG.Size = New System.Drawing.Size(width, height)
    End Sub

    Private Sub tbJIGSizeHeight_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJIGSizeHeight_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Dim width As Integer
        Dim height As Integer
        Try
            width = CInt(tbJIGSizeWidth_tpJIGLayout.Text)
            height = CInt(tbJIGSizeHeight_tpJIGLayout.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        ucJIG.Size = New System.Drawing.Size(width, height)
    End Sub

    Private Sub tbCellLayoutCol_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCellLayoutCol_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Dim col As Integer
        Try
            col = CInt(tbCellLayoutCol_tpJIGLayout.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        ucJIG.CellLayout_Col = col
    End Sub

    Private Sub tbCellLayoutRow_tpJIGLayout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCellLayoutRow_tpJIGLayout.TextChanged
        If m_bIsLoaded = False Then Exit Sub
        Dim row As Integer
        Try
            row = CInt(tbCellLayoutRow_tpJIGLayout.Text)
        Catch ex As Exception
            Exit Sub
        End Try
        ucJIG.CellLayout_Row = row
    End Sub

    Private Sub btnEditJIGLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditJIGLocation_tpJIGLayout.Click
        Dim dlg As frmEditJIGLayout

        GetValueFromJIGLayoutTabPage(m_Settings.JIGLayoutInfos)

        If m_Settings.JIGLayoutInfos Is Nothing = True Then
            MsgBox("JIG Information not set.")
            Exit Sub
        End If

        If m_Settings.JIGLayoutInfos.Length <= 0 Then
            MsgBox("JIG Information not set.")
            Exit Sub
        End If

        dlg = New frmEditJIGLayout(m_Settings.JIGLayoutInfos)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim locationInfos() As System.Drawing.Point = dlg.JIGLocation.Clone
            Dim sizeInfos() As System.Drawing.Size = dlg.JIGSize.Clone

            For i As Integer = 0 To m_Settings.JIGLayoutInfos.Length - 1
                m_Settings.JIGLayoutInfos(i).JIGLocation = New System.Drawing.Point(locationInfos(i).X, locationInfos(i).Y)
                m_Settings.JIGLayoutInfos(i).JIGSize = New System.Drawing.Size(sizeInfos(i).Width, sizeInfos(i).Height)
            Next

        End If

    End Sub


    Private Sub btnADD_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD_tpJIGLayout.Click
        Dim buff As sJIGLayoutInfo = Nothing

        GetSettingValueFromJIGLayoutTabPage(buff)

        AddJIGLayoutList(buff)
        'AllocationData_Update_Each(AllocationDataBuff)

        'ListUPChannelAllocation(m_AllocationINfosBuff)

        'AllocationData_Updata_Finish()
    End Sub

    Private Sub btnDEL_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDEL_tpJIGLayout.Click
        DelSelectedRowJIGLayout()
    End Sub

    Private Sub btnChange_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange_tpJIGLayout.Click

        Dim buff As sJIGLayoutInfo = Nothing

        GetSettingValueFromJIGLayoutTabPage(buff)
        UpdateDataListJIGLayout(buff)
    End Sub

    Private Sub btnClear_tpJIGLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear_tpJIGLayout.Click
        ucListJIGSettings.ClearAllData()
    End Sub

#End Region


    Private Function GetSettingValueFromJIGLayoutTabPage(ByRef settings As sJIGLayoutInfo) As Boolean

        settings.JIGNo = cbSelJIG_tpJIGLayout.SelectedIndex
        settings.sampleType = cbSelSampleType_tpJIGLayout.SelectedIndex
        settings.AddText = tbAddText_tpJIGLayout.Text
        Try
            Dim size As Size = New System.Drawing.Size(tbJIGSizeWidth_tpJIGLayout.Text, tbJIGSizeHeight_tpJIGLayout.Text)
            settings.JIGSize = size
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        Try
            settings.CellLayoutCol = tbCellLayoutCol_tpJIGLayout.Text
            settings.CellLayoutRow = tbCellLayoutRow_tpJIGLayout.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        settings.JIGBackgroundColor = lblJIGBackColor_tpJIGLayout.BackColor
        settings.JIGOutlineColor_Selected = lblJIGOutlineColorAtSel_tpJIGLayout.BackColor
        settings.JIGOutlineColor_Unselected = lblJIGOutlineColorAtUnsel_tpJIGLayout.BackColor

        Try
            settings.JIGOutlineWidth = tbJIGOutlineWidth_tpJIGLayout.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
        settings.JIGSelectToMultiChannelSelect = chkSelJIGToMultiChannelSelect_tpJIGLayout.Checked
     
        settings.statusMsgFont = ucJIG.StatusMsgFont

        Return True
    End Function

    Private Function GetSettingValueFromDisplayTabPage(ByRef settings As sSystemSettings) As Boolean
        settings.DisplayMode = cbDisplayMainUI.SelectedIndex
        Return True
    End Function

    Private Function GetValueFromJIGLayoutTabPage(ByRef settings() As sJIGLayoutInfo) As Boolean

        If ucListJIGSettings.GetListItemCount <= 0 Then Return False

        Dim rowData() As ListViewItem.ListViewSubItem = Nothing

        ReDim Preserve settings(ucListJIGSettings.GetListItemCount - 1)

        For i As Integer = 0 To ucListJIGSettings.GetListItemCount - 1

            If ucListJIGSettings.GetRowData(i, rowData) <> ucDispListView.eUcListErrCode.eNoError Then Return False
            settings(i).JIGNo = rowData(0).Text
            Select Case rowData(1).Text
                Case sSampleType(ucSampleInfos.eSampleType.eCell)
                    settings(i).sampleType = ucSampleInfos.eSampleType.eCell
                Case sSampleType(ucSampleInfos.eSampleType.ePanel)
                    settings(i).sampleType = ucSampleInfos.eSampleType.ePanel
                Case sSampleType(ucSampleInfos.eSampleType.eModule)
                    settings(i).sampleType = ucSampleInfos.eSampleType.eModule
            End Select

            settings(i).JIGSize = CSequenceManager.ConvertStringToSize(rowData(2).Text)
            Dim arrBuf As Array = Split(rowData(3).Text, ",", -1)
            settings(i).CellLayoutCol = arrBuf(0)
            settings(i).CellLayoutRow = arrBuf(1)
            settings(i).JIGBackgroundColor = rowData(4).BackColor
            settings(i).JIGOutlineColor_Selected = rowData(5).BackColor
            settings(i).JIGOutlineColor_Unselected = rowData(6).BackColor
            settings(i).JIGOutlineWidth = rowData(7).Text
            settings(i).statusMsgFont = rowData(8).Font
            settings(i).AddText = rowData(10).Text
            If rowData(9).Text = "True" Then
                settings(i).JIGSelectToMultiChannelSelect = True
            Else
                settings(i).JIGSelectToMultiChannelSelect = False
            End If
        Next

        Return True
    End Function

    Private Sub AddJIGLayoutList(ByVal settings As sJIGLayoutInfo)
        Dim sData(10) As Object

        sData(0) = settings.JIGNo
        sData(1) = sSampleType(settings.sampleType)
        sData(2) = settings.JIGSize.ToString
        sData(3) = CStr(settings.CellLayoutCol) & "," & CStr(settings.CellLayoutRow)
        sData(4) = settings.JIGBackgroundColor
        sData(5) = settings.JIGOutlineColor_Selected
        sData(6) = settings.JIGOutlineColor_Unselected
        sData(7) = CStr(settings.JIGOutlineWidth)
        sData(8) = settings.statusMsgFont
        sData(9) = settings.JIGSelectToMultiChannelSelect.ToString
        sData(10) = settings.AddText
        ucListJIGSettings.AddRowData(sData)
    End Sub

    Private Sub DelSelectedRowJIGLayout()
        Dim nSelectedRow As Integer
        If ucListJIGSettings.GetSelectedRowNumber(nSelectedRow) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub
        If ucListJIGSettings.DelSelectedRow(nSelectedRow) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub
    End Sub

    Private Sub UpdateDataListJIGLayout(ByVal settings As sJIGLayoutInfo)
        Dim sData(9) As Object
        Dim nSelectedRow As Integer

        sData(0) = settings.JIGNo
        sData(1) = sSampleType(settings.sampleType)
        sData(2) = settings.JIGSize.ToString
        sData(3) = CStr(settings.CellLayoutCol) & "," & CStr(settings.CellLayoutRow)
        sData(4) = settings.JIGBackgroundColor
        sData(5) = settings.JIGOutlineColor_Selected
        sData(6) = settings.JIGOutlineColor_Unselected
        sData(7) = CStr(settings.JIGOutlineWidth)
        sData(8) = settings.statusMsgFont
        sData(9) = settings.JIGSelectToMultiChannelSelect.ToString

        If ucListJIGSettings.GetSelectedRowNumber(nSelectedRow) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub


        ucListJIGSettings.ChangeRowData(nSelectedRow, sData)
        '   If ucListJIGSettings.SetRowData(nSelectedRow, sData) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub
    End Sub


#End Region




#Region "Shared Functions"

    Public Shared Function ConvertStrToChAllocationItem(ByVal str As String) As eChAllocationItem

        Select Case str
            Case eChAllocationItem.eChannel.ToString
                Return eChAllocationItem.eChannel
            Case eChAllocationItem.eDevNoOfM6000.ToString
                Return eChAllocationItem.eDevNoOfM6000
            Case eChAllocationItem.eChOfM6000.ToString
                Return eChAllocationItem.eChOfM6000
            Case eChAllocationItem.eSampleType.ToString
                Return eChAllocationItem.eSampleType
            Case eChAllocationItem.ePallet_No.ToString
                Return eChAllocationItem.ePallet_No
            Case eChAllocationItem.eJIG_No.ToString
                Return eChAllocationItem.eJIG_No
            Case eChAllocationItem.eGroupOfTC.ToString   '485 통신의 포트 단위(TC는 공통으로 사용)
                Return eChAllocationItem.eGroupOfTC
            Case eChAllocationItem.eDevNoOfTC.ToString   '485 통신 포트에 병렬로 연결되어 있는 컨트롤러의 수
                Return eChAllocationItem.eDevNoOfTC
            Case eChAllocationItem.eChOfTC.ToString      '컨트롤러의 채널수
                Return eChAllocationItem.eChOfTC
            Case eChAllocationItem.eGroupOfSG.ToString
                Return eChAllocationItem.eGroupOfSG
            Case eChAllocationItem.eDevNoOfSG.ToString
                Return eChAllocationItem.eDevNoOfSG
            Case eChAllocationItem.eChOfSG.ToString
                Return eChAllocationItem.eChOfSG
            Case eChAllocationItem.eDevNoOfPDMeasUnit.ToString
                Return eChAllocationItem.eDevNoOfPDMeasUnit
            Case eChAllocationItem.eChOfPDMeasUnit.ToString
                Return eChAllocationItem.eChOfPDMeasUnit
            Case eChAllocationItem.eDevNoOfGNTPG.ToString
                Return eChAllocationItem.eDevNoOfGNTPG
            Case eChAllocationItem.eDevNoOfMcPG.ToString
                Return eChAllocationItem.eDevNoOfMcPG
            Case eChAllocationItem.eChOfMcPG.ToString
                Return eChAllocationItem.eChOfMcPG
            Case eChAllocationItem.eGroupOfMcPGPower.ToString
                Return eChAllocationItem.eGroupOfMcPGPower
            Case eChAllocationItem.eDevNoOfMcPGPower.ToString
                Return eChAllocationItem.eDevNoOfMcPGPower
            Case eChAllocationItem.eChOfMcPGPower.ToString
                Return eChAllocationItem.eChOfMcPGPower
            Case eChAllocationItem.eGroupOfMcPGCtrlBD.ToString
                Return eChAllocationItem.eGroupOfMcPGCtrlBD
            Case eChAllocationItem.eDevNoOfMcPGCtrlBD.ToString
                Return eChAllocationItem.eDevNoOfMcPGCtrlBD
            Case eChAllocationItem.eChOfMcPGCtrlBD.ToString
                Return eChAllocationItem.eChOfMcPGCtrlBD    
            Case eChAllocationItem.eDevNoOfSwitch.ToString
                Return eChAllocationItem.eDevNoOfSwitch
            Case eChAllocationItem.eChOfSwitch.ToString
                Return eChAllocationItem.eChOfSwitch
            Case eChAllocationItem.eChOfPairSwitch.ToString
                Return eChAllocationItem.eChOfPairSwitch
            Case eChAllocationItem.eDevNoOfSMU_IVL.ToString
                Return eChAllocationItem.eDevNoOfSMU_IVL
            Case eChAllocationItem.eChOfSMU_IVL.ToString
                Return eChAllocationItem.eChOfSMU_IVL
            Case eChAllocationItem.eIVLUse.ToString
                Return eChAllocationItem.eIVLUse
            Case eChAllocationItem.eLifetimeUse.ToString
                Return eChAllocationItem.eLifetimeUse
            Case eChAllocationItem.eVAUse.ToString
                Return eChAllocationItem.eVAUse
            Case Else
                Return -1
        End Select

    End Function

    Public Shared Function SaveSystemSettings(ByVal settings As sSystemSettings) As Boolean
        Dim sFileTitle As String = "Allocation Channel Information"
        Dim sVersion As String = "1.0.1"

        If settings.ChAllocationInfos Is Nothing Then Return False

        'If file.GetSaveFileName(CMcFile.eFileType.eINI, fileInfo) = False Then Return False

        If Directory.Exists(g_sPATH_ChannelAssign) = False Then
            Directory.CreateDirectory(g_sPATH_ChannelAssign)
        End If

        Dim AllocationSaver As New CAllocationINI(g_sPATH_ChannelAssign & m_sChAllocationFileName)

        AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.FileTitle, sFileTitle)
        AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.FileVersion, sVersion)
        AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.eMaxCh, settings.ChAllocationInfos.Length)
        AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.eNumOfItem, settings.ChAllocationInfos(0).nItems.Length)

        'Display
        AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eDisplay, 0, CAllocationINI.eKeyID.eDisplayMode, settings.DisplayMode.ToString)

        For i As Integer = 0 To settings.ChAllocationInfos.Length - 1
            For n As Integer = 0 To settings.ChAllocationInfos(i).nItems.Length - 1
                With settings.ChAllocationInfos(i)
                    AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eAllocationData, i, CAllocationINI.eKeyID.eChAlocItem, n, .nItems(n).ToString)
                    AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eAllocationData, i, CAllocationINI.eKeyID.eValue, n, CStr(.nChAlocValue(n)))
                End With
            Next
        Next

        'JIG Layout Info
        If settings.JIGLayoutInfos Is Nothing = False Then
            For i As Integer = 0 To settings.JIGLayoutInfos.Length - 1
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGNo, i, CStr(settings.JIGLayoutInfos(i).JIGNo))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_CellLayoutCol, i, CStr(settings.JIGLayoutInfos(i).CellLayoutCol))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_CellLayoutRow, i, CStr(settings.JIGLayoutInfos(i).CellLayoutRow))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGBackgroundColor, i, settings.JIGLayoutInfos(i).JIGBackgroundColor.ToString & "," & CStr(settings.JIGLayoutInfos(i).JIGBackgroundColor.ToArgb))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGLocation, i, settings.JIGLayoutInfos(i).JIGLocation.ToString)
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineColor_Sel, i, settings.JIGLayoutInfos(i).JIGOutlineColor_Selected.ToString & "," & CStr(settings.JIGLayoutInfos(i).JIGOutlineColor_Selected.ToArgb))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineColor_Unsel, i, settings.JIGLayoutInfos(i).JIGOutlineColor_Unselected.ToString & "," & CStr(settings.JIGLayoutInfos(i).JIGOutlineColor_Unselected.ToArgb))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineWidth, i, CStr(settings.JIGLayoutInfos(i).JIGOutlineWidth))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGSize, i, settings.JIGLayoutInfos(i).JIGSize.ToString)
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_NumOfSample, i, CStr(settings.JIGLayoutInfos(i).numOfSample))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_SampleType, i, settings.JIGLayoutInfos(i).sampleType.ToString)
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID._JL_StatusMsgFont, i, settings.JIGLayoutInfos(i).statusMsgFont.ToString)
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID._JL_StatusMsgFont_FontStyle, i, CInt(settings.JIGLayoutInfos(i).statusMsgFont.Style))
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGEnableMultiSelect, i, settings.JIGLayoutInfos(i).JIGSelectToMultiChannelSelect.ToString)
                AllocationSaver.SaveIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGAddText, i, settings.JIGLayoutInfos(i).AddText.ToString)
            Next
        End If
        

        Return True
    End Function

    Public Shared Function LoadSystemSettings(ByRef settings As sSystemSettings) As Boolean

        Dim sFileTitle As String = "Allocation Channel Information"
        Dim sVersion As String = "1.0.1"
        Dim sTemp As String
        Dim MaxCh As Integer
        Dim nItemLen As Integer
        '  If SystemChAllocation.M6000_AllocatioNData Is Nothing And SystemChAllocation.MC9_AllocationData Is Nothing Then Return False
        If File.Exists(g_sPATH_ChannelAssign & m_sChAllocationFileName) = False Then
            Return False
        End If

        Dim AllocationLoader As New CAllocationINI(g_sPATH_ChannelAssign & m_sChAllocationFileName)
        '============================================
        sTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.FileTitle)
        If sFileTitle <> sTemp Then Return False

        sTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.FileVersion)
        If sVersion <> sTemp Then
            MsgBox("The version of the system configuration file is not up to date. You need to reset.")
            Return False
        End If

        MaxCh = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.eMaxCh)
        ReDim settings.ChAllocationInfos(MaxCh - 1)

        nItemLen = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eFileInfo, 0, CAllocationINI.eKeyID.eNumOfItem)

        Select Case AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eDisplay, 0, CAllocationINI.eKeyID.eDisplayMode)
            Case ucDispMultiCtrlCommonNode.eType.ListType.ToString
                settings.DisplayMode = ucDispMultiCtrlCommonNode.eType.ListType
            Case ucDispMultiCtrlCommonNode.eType.ListTypeForQC.ToString
                settings.DisplayMode = ucDispMultiCtrlCommonNode.eType.ListTypeForQC
            Case ucDispMultiCtrlCommonNode.eType.CustomTypeForQC.ToString
                settings.DisplayMode = ucDispMultiCtrlCommonNode.eType.CustomTypeForQC
            Case ucDispMultiCtrlCommonNode.eType.JIGLayout.ToString
                settings.DisplayMode = ucDispMultiCtrlCommonNode.eType.JIGLayout
            Case Else
                Return False
        End Select

        For i As Integer = 0 To settings.ChAllocationInfos.Length - 1
            ReDim settings.ChAllocationInfos(i).nItems(nItemLen - 1)
            ReDim settings.ChAllocationInfos(i).nChAlocValue(nItemLen - 1)
            For n As Integer = 0 To settings.ChAllocationInfos(i).nItems.Length - 1
                With settings.ChAllocationInfos(i)
                    .nItems(n) = ConvertStrToChAllocationItem(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eAllocationData, i, CAllocationINI.eKeyID.eChAlocItem, n))
                    .nChAlocValue(n) = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eAllocationData, i, CAllocationINI.eKeyID.eValue, n)
                End With
            Next
        Next

        'JIG Layout Info
        ReDim settings.JIGLayoutInfos(g_ConfigInfos.numOfJIG - 1)
        Dim arrBuf As Array
        Dim strTemp As String
        Dim strTemp01 As String

        For i As Integer = 0 To settings.JIGLayoutInfos.Length - 1
            Try
                'Dim colorConverter As New System.Drawing.ColorConverter()

                settings.JIGLayoutInfos(i).JIGNo = CInt(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGNo, i))
                settings.JIGLayoutInfos(i).CellLayoutCol = CInt(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_CellLayoutCol, i))
                settings.JIGLayoutInfos(i).CellLayoutRow = CInt(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_CellLayoutRow, i))
                strTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGBackgroundColor, i)
                arrBuf = Split(strTemp, ",", -1)
                settings.JIGLayoutInfos(i).JIGBackgroundColor = Color.FromArgb(CInt(arrBuf(arrBuf.Length - 1)))     'Color.FromName
                settings.JIGLayoutInfos(i).JIGLocation = CSequenceManager.ConvertStringToPoint(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGLocation, i))
                strTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineColor_Sel, i)
                arrBuf = Split(strTemp, ",", -1)
                settings.JIGLayoutInfos(i).JIGOutlineColor_Selected = Color.FromArgb(arrBuf(arrBuf.Length - 1))
                strTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineColor_Unsel, i)
                arrBuf = Split(strTemp, ",", -1)
                settings.JIGLayoutInfos(i).JIGOutlineColor_Unselected = Color.FromArgb(CInt(arrBuf(arrBuf.Length - 1)))
                settings.JIGLayoutInfos(i).JIGOutlineWidth = CInt(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGOutlineWidth, i))
                settings.JIGLayoutInfos(i).JIGSize = CSequenceManager.ConvertStringToSize(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGSize, i))
                settings.JIGLayoutInfos(i).numOfSample = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_NumOfSample, i)
                strTemp = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID._JL_StatusMsgFont, i)
                strTemp01 = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID._JL_StatusMsgFont_FontStyle, i)
                settings.JIGLayoutInfos(i).JIGSelectToMultiChannelSelect = CSequenceManager.ConvertStringToBool(AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGEnableMultiSelect, i))

                Try
                    settings.JIGLayoutInfos(i).AddText = AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_JIGAddText, i)
                Catch ex As Exception
                    settings.JIGLayoutInfos(i).AddText = ""
                End Try

                Dim Style As System.Drawing.FontStyle
                If strTemp01 <> "" Then
                    Style = CInt(strTemp01)
                Else
                    Style = FontStyle.Bold
                End If

                If strTemp <> "" Then
                    strTemp = strTemp.TrimStart("[")
                    strTemp = strTemp.TrimEnd("]")
                    arrBuf = Split(strTemp, ",", -1)
                    If arrBuf.Length = 5 Then

                        Dim arrTemp As Array

                        arrTemp = Split(arrBuf(0), "=", -1)
                        Dim sFont As String = arrTemp(arrTemp.Length - 1)
                        arrTemp = Split(arrBuf(1), "=", -1)
                        Dim nSize As Single = CSng(arrTemp(arrTemp.Length - 1))
                        arrTemp = Split(arrBuf(2), "=", -1)
                        Dim nUnit As System.Drawing.GraphicsUnit = CInt(arrTemp(arrTemp.Length - 1))
                        arrTemp = Split(arrBuf(3), "=", -1)
                        Dim GdiCharSet As Byte = CByte(arrTemp(arrTemp.Length - 1))
                        arrTemp = Split(arrBuf(4), "=", -1)
                        Dim GdiVerticalFont As Boolean = CBool(arrTemp(arrTemp.Length - 1))

                        settings.JIGLayoutInfos(i).statusMsgFont = New System.Drawing.Font(sFont, nSize, Style, nUnit, GdiCharSet, GdiVerticalFont) ', GdiChorSet, GdiVerticalFont)
                        '   settings.JIGLayoutInfos(i).statusMsgFont = New System.Drawing.Font(sFont,nSize,
                    Else
                        settings.JIGLayoutInfos(i).statusMsgFont = Nothing
                    End If
                Else
                    settings.JIGLayoutInfos(i).statusMsgFont = Nothing
                End If



                ' 

                ' settings.JIGLayoutInfos(i).statusMsgFont
                Select Case AllocationLoader.LoadIniValue(CAllocationINI.eSecID.eJIGLayoutData, i, CAllocationINI.eKeyID.eJL_SampleType, i)
                    Case ucSampleInfos.eSampleType.eCell.ToString
                        settings.JIGLayoutInfos(i).sampleType = ucSampleInfos.eSampleType.eCell
                    Case ucSampleInfos.eSampleType.ePanel.ToString
                        settings.JIGLayoutInfos(i).sampleType = ucSampleInfos.eSampleType.ePanel
                    Case ucSampleInfos.eSampleType.eModule.ToString
                        settings.JIGLayoutInfos(i).sampleType = ucSampleInfos.eSampleType.eModule
                    Case Else
                        Return False
                End Select
            Catch ex As Exception
                Return False
            End Try
         
        Next

        Return True
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllocationValue(ByVal nCh As Integer, ByVal type As eChAllocationItem) As Integer

        Dim nValue As Integer

        
            For i As Integer = 0 To g_SystemSettings.ChAllocationInfos(nCh).nItems.Length - 1
                If g_SystemSettings.ChAllocationInfos(nCh).nItems(i) = type Then
                    nValue = g_SystemSettings.ChAllocationInfos(nCh).nChAlocValue(i)
                End If
            Next

            Return nValue
        

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="devNo"></param>
    ''' <param name="chOfDev"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChannelNoFromM6000DevNoAndCh(ByVal devNo As Integer, ByVal chOfDev As Integer) As Integer
        Dim nValue As Integer
        For i As Integer = 0 To g_nMaxCh - 1
            If (frmSettingWind.GetAllocationValue(i, eChAllocationItem.eDevNoOfM6000) = devNo And frmSettingWind.GetAllocationValue(i, eChAllocationItem.eChOfM6000) = chOfDev) Then

                nValue = i
                Exit For
            End If
        Next

        Return nValue

    End Function

    ''' <summary>
    '''   '동일한 온도 설정이 적용되는 채널의(같인 온도컨트롤러를 사용하는 채널) 번호를 배열로 정렬하여 리턴 한다.
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckCombinedChannelAsTC(ByVal nCh As Integer) As Integer()
        Dim combinedChIndex() As Integer = Nothing
        Dim cnt As Integer = 0
        Dim myGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfTC)
        Dim myDevOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfTC)
        Dim myChOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfTC) ' g_ChAllocationInfos(nCh).nJIG_No

        For i As Integer = 0 To g_nMaxCh - 1
            If frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eGroupOfTC) = myGroupOfTC And
                frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eDevNoOfTC) = myDevOfTC And
               frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eChOfTC) = myChOfTC Then
                ReDim Preserve combinedChIndex(cnt)
                combinedChIndex(cnt) = i
                cnt += 1
            End If
        Next
        Return combinedChIndex
    End Function

    ''' <summary>
    ''' 지그 번호를 입력 하면, 입력한 지그에 설정된 샘플. 즉, 채널의 수를 리턴 한다.
    ''' </summary>
    ''' <param name="nJIG"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckCombinedChannelAsJIG(ByVal nJIG As Integer) As Integer()
        Dim combinedChNum() As Integer = Nothing
        Dim cnt As Integer = 0

        For i As Integer = 0 To g_nMaxCh - 1
            If frmSettingWind.GetAllocationValue(i, eChAllocationItem.eJIG_No) = nJIG Then
                ReDim Preserve combinedChNum(cnt)
                combinedChNum(cnt) = i
                cnt += 1
            End If
        Next
        Return combinedChNum
    End Function

    ''' <summary>
    ''' 온도 컨트롤러 장비의 번호를 주면 해당 하는 지그 번호를 리턴 한다.
    ''' </summary>
    ''' <param name="nTC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTCNumberToJIGNumber(ByVal nTC As Integer) As Integer
        Dim nJIGNumber As Integer = Nothing
        Dim nTCNumber As Integer = Nothing

        For i As Integer = 0 To g_nMaxCh - 1
            nTCNumber = frmSettingWind.GetAllocationValue(i, eChAllocationItem.eDevNoOfTC)
            If nTCNumber = nTC Then
                nJIGNumber = frmSettingWind.GetAllocationValue(i, eChAllocationItem.eJIG_No)
                Exit For
            End If
        Next
        Return nJIGNumber
    End Function


    Public Shared Function CheckChannelAsJig(ByVal nCh As Integer) As Integer
        Dim JigNo As Integer
        JigNo = frmSettingWind.GetAllocationValue(nCh, eChAllocationItem.eJIG_No)

        Return JigNo
    End Function

#End Region



   
End Class