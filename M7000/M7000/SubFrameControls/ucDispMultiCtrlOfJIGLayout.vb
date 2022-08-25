Public Class ucDispMultiCtrlOfJIGLayout
    Inherits ucDispMultiCtrlCommonNode

    Dim m_bIsLoaded As Boolean = False
    Dim m_JIGLayoutInfos() As frmSettingWind.sJIGLayoutInfo
    Dim tcMain = New TabControl()
    Dim tpMain = New TabPage("Main")
    Dim m_ucDispMain As ucDispMain
    '220825 Update by JKY : Max Checked Channel Check
    Dim m_nMaxCheckedOfJig As Integer
    Dim m_nCheckedCh() As Integer

    Public Sub New(ByVal maxCh As Integer, ByVal seedIdx As Integer, ByVal dispInfos() As frmSettingWind.sJIGLayoutInfo)
        MyBase.New()
        ' 이 호출은 디자이너에 필요합니다.fff
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        MyBase.m_nMaxCh = maxCh
        MyBase.m_nSeedIndex = seedIdx
        MyBase.init()
        MyBase.m_nType = eType.JIGLayout
        m_JIGLayoutInfos = dispInfos.Clone
        m_CaptionType_Title = eCaptionType._Number_Increase
        '220825 Update by JKY
        m_nMaxCheckedOfJig = 8
        ReDim m_nCheckedCh(g_ConfigInfos.numOfPallet - g_ConfigInfos.numOfIVLJIG)
        Initialization()
    End Sub

    Public WriteOnly Property ChannelStatus() As CScheduler.eChSchedulerSTATE
        Set(ByVal value As CScheduler.eChSchedulerSTATE)

        End Set

    End Property

#Region "Initialization Custom Control for QC"


    Private Sub Initialization()

        ReDim DispChSampleUI(m_nMaxCh - 1)
        ReDim dispJIG(g_ConfigInfos.numOfJIG - 1)

        Me.Size = New Drawing.Size(Me.Size.Width, 100 * g_nMaxCh)

        scJIG.Location = New System.Drawing.Point(0, 0)
        scJIG.Dock = DockStyle.Fill

        '220824 Update by JKY : TapControl (Designer 추가), JIG 개수만큼 TapPage 생성
        tcMain = New TabControl()
        tpMain = New TabPage("Main")

        scJIG.Controls.Add(tcMain)
        tcMain.Location = New Point(0, 0)
        tcMain.Dock = DockStyle.Fill
        '220825 Update by SSH : MainUI 호출 및 tp binding
        m_ucDispMain = New ucDispMain(g_ConfigInfos.numOfPallet, g_ConfigInfos.numOfIVLJIG)
        m_ucDispMain.Dock = DockStyle.Fill
        m_ucDispMain.SetPanelPosition()

        tpMain.Controls.Add(m_ucDispMain)
        '
        tcMain.TabPages.Add(tpMain)
        '220825 Update by JKY : IVL JIG 개수 config 추가
        For i = 1 To g_ConfigInfos.numOfPallet - g_ConfigInfos.numOfIVLJIG
            Dim tp As TabPage
            tp = New TabPage($"JIG #{i}")
            tcMain.TabPages.Add(tp)
        Next
        If g_ConfigInfos.numOfIVLJIG > 0 Then
            For i = 1 To g_ConfigInfos.numOfIVLJIG
                Dim tp As TabPage
                tp = New TabPage($"IVL #{i}")
                tcMain.TabPages.Add(tp)
            Next
        End If

        Dim sampleType As ucSampleInfos.eSampleType

        For i = 0 To m_nMaxCh - 1
            sampleType = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eSampleType)
            DispChSampleUI(i) = New ucDispSampleUI(sampleType, m_sequenceMgr(i))

            With DispChSampleUI(i) 'testButton(in_Num) '
                .Channel = MyBase.m_nSeedIndex + i

                'AddHandler DispChSampleUI(i).evRunExperiment, 
                'addhandler DispChSampleUI(i).evStopExperiment
                AddHandler DispChSampleUI(i).evClickEditSequence, AddressOf EditSequenceButton_Click
                AddHandler DispChSampleUI(i).evClickLoadSequence, AddressOf Channel_LoadSequenceButton_Click
                AddHandler DispChSampleUI(i).evClickUnloadSeqeunce, AddressOf Channel_UnloadSequenceButton_Click
                AddHandler DispChSampleUI(i).evSavePath, AddressOf SetSavePath
                AddHandler DispChSampleUI(i).evSelected, AddressOf CellEvent_Selected
                AddHandler DispChSampleUI(i).evUnSelected, AddressOf CellEvent_UnSelected
            End With

        Next

        Dim combindChNum() As Integer

        For i = 0 To g_ConfigInfos.numOfJIG - 1
            '같은 지그에 위치한 채널 확인
            combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(i)
            Dim sampleUi(combindChNum.Length - 1) As ucDispSampleUI

            Dim nCntCaptionIdx As Integer = 0

            For idx As Integer = 0 To combindChNum.Length - 1
                sampleUi(idx) = DispChSampleUI(combindChNum(idx))
                'Cell 초기화 ' Sample UI 초기화
                sampleUi(idx).sample.CellNo = idx

                Select Case MyBase.m_CaptionType_Title

                    Case eCaptionType._Number_Increase
                        sampleUi(idx).sample.Title = Format(idx + 1, "00")
                    Case eCaptionType._Color_RGB
                        Dim sCaptions() As String = New String() {"R", "G", "B"}
                        sampleUi(idx).sample.Title = sCaptions(nCntCaptionIdx)
                        nCntCaptionIdx += 1
                        If nCntCaptionIdx >= sCaptions.Length Then
                            nCntCaptionIdx = 0
                        End If
                    Case Else
                        '  lblTitle.Text = "Undef."
                End Select

            Next

            '샘플 및 지그 생성
            dispJIG(i) = New ucDispJIG(sampleUi, m_JIGLayoutInfos(i))
            dispJIG(i).Visible = False
            dispJIG(i).VisibleTemp = False
            'AddHandler DispChSampleUI(i).evRunExperiment, 
            'addhandler DispChSampleUI(i).evStopExperiment
            AddHandler dispJIG(i).evClickEditSequence, AddressOf EditSequenceButton_Click
            AddHandler dispJIG(i).evClickLoadSequence, AddressOf JIG_LoadSequenceButton_Click
            AddHandler dispJIG(i).evClickUnloadSeqeunce, AddressOf JIG_UnloadSequenceButton_Click
            AddHandler dispJIG(i).evSavePath, AddressOf JIG_SetSavePath
            AddHandler dispJIG(i).evClickTempIndicator, AddressOf ClickJIGTempIndicator

            'scJIG.Controls.Add(dispJIG(i))
            '220824 Update by JKY : JIG(Pallet) 마다 dispJIG 추가
            Dim pallet = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.ePallet_No)
            tcMain.TabPages(pallet + 1).Controls.Add(dispJIG(i))

            '위치 및 크기 설정 기능 추가
            'With m_JIGLayoutInfos(i)
            '    dispJIG(i).OutlineColor_Selected = .JIGOutlineColor_Selected
            '    dispJIG(i).OutlineColor_Unselected = .JIGOutlineColor_Unselected
            '    dispJIG(i).OutlineWidth = .JIGOutlineWidth
            '    dispJIG(i).JIGNo = i + 1
            '    dispJIG(i).JIGColor = .JIGBackgroundColor
            'End With
            '    If dispJIG(i).SampleType = ucDispRcpCommon.eSampleType.eCell Then
            '  Try

            '  Catch ex As Exception
            'MsgBox(ex.ToString)
            '  End Try

            '  Else
            '   scJIG.Panel2.Controls.Add(dispJIG(i))
            '   End If

        Next

        'For i As Integer = 0 To g_ConfigInfos.numOfJIG - 1
        '    scJIG.Controls.Add(dispJIG(i))
        '    '    dispJIG(i).Visible = True
        'Next

        'Update()

    End Sub

    ' Dim g_SizeW As Integer = 80
    Dim g_LocOffset_Y As Integer = 8
    Dim g_LocOffset_Y1 As Integer = 3

    Private Sub SetControlLocation()
        Dim ctrlPos As Point

        For i As Integer = 0 To dispJIG.Length - 1
            dispJIG(i).Size = New System.Drawing.Size(m_JIGLayoutInfos(i).JIGSize)

            ctrlPos.X = g_SystemSettings.JIGLayoutInfos(i).JIGLocation.X
            ctrlPos.Y = g_SystemSettings.JIGLayoutInfos(i).JIGLocation.Y
            dispJIG(i).Location = New System.Drawing.Point(ctrlPos)

        Next
    End Sub

    'Private Sub CreateChannel(ByVal in_Num As Integer)

    '    Dim Location_X, Location_Y, Size_H, Size_W As Double
    '    Dim dH As Integer = 1
    '    Dim nPontsize As Integer = 12

    '    Size_H = 105
    '    Size_W = 1550
    '    Location_X = 0
    '    Location_Y = ((Size_H + g_LocOffset_Y1) * in_Num) + g_LocOffset_Y


    '    DispChSampleUI(in_Num) = New ucDispSampleUI() '.eType.CustomTypeForQC)

    '    Me.Controls.Add(DispChCustom_QC(in_Num))
    '    '    Me.Controls.Add(testButton(in_Num))
    'End Sub


    Private Sub CellEvent_Selected(ByVal nCh As Integer, ByVal cellNo As Integer)

        If m_bIsLoaded = False Then Exit Sub

        Dim myJIGNo As Integer
        Dim myPalletNo As Integer
        Dim combindChNum() As Integer
        myJIGNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)
        myPalletNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.ePallet_No)

        '20220825 Update By SSH : Set Cell at Main UI Jig
        combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(myJIGNo)

        If m_nCheckedCh(myPalletNo) >= m_nMaxCheckedOfJig Then
            dispJIG(myJIGNo).IsSelected = False
            Exit Sub
        Else
            m_ucDispMain.SetCell(myPalletNo, myJIGNo, True)
            m_nCheckedCh(myPalletNo) += 1
        End If
        dispJIG(myJIGNo).PreviouslySelectedCellIdx = cellNo

        If dispJIG(myJIGNo).NumberOfCell = 1 Then
            dispJIG(myJIGNo).IsSelected = True
        Else
            If dispJIG(myJIGNo).EnabelMultiSelect = False Then
                For i As Integer = 0 To combindChNum.Length - 1
                    If combindChNum(i) <> nCh Then
                        DispChSampleUI(combindChNum(i)).IsSelected = False
                    End If
                Next
            End If

        End If

        Dim nCntselected As Integer

        For i As Integer = 0 To combindChNum.Length - 1
            If DispChSampleUI(combindChNum(i)).IsSelected = True Then
                nCntselected += 1
            End If
        Next

        If nCntselected = combindChNum.Length Then
            dispJIG(myJIGNo).IsSelected = True
        End If

    End Sub

    Private Sub CellEvent_UnSelected(ByVal nCh As Integer, ByVal CellNo As Integer)

        If m_bIsLoaded = False Then Exit Sub

        Dim myJIGNo As Integer
        Dim myPalletNo As Integer

        Dim combindChNum() As Integer
        myJIGNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)
        myPalletNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.ePallet_No)

        m_ucDispMain.SetCell(myPalletNo, myJIGNo, False)

        '   dispJIG(myJIGNo).PreviouslySelectedCellIdx = CellNo
        If m_nCheckedCh(myPalletNo) > 0 Then
            m_nCheckedCh(myPalletNo) -= 1
        Else
            combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(myJIGNo)
        End If


        If dispJIG(myJIGNo).NumberOfCell = 1 Then
            dispJIG(myJIGNo).IsSelected = False
        Else

            Dim nCntUnselected As Integer

            For i As Integer = 0 To combindChNum.Length - 1

                If DispChSampleUI(combindChNum(i)).IsSelected = False Then
                    nCntUnselected += 1
                End If
            Next

            If nCntUnselected = combindChNum.Length Then
                dispJIG(myJIGNo).IsSelected = False
            End If

        End If

    End Sub

    Private Sub EditSequenceButton_Click()
        Dim builder As New frmSequenceBuilder
        builder.ShowDialog()
    End Sub


    Private Sub SetSavePath(ByVal ch As Integer)
        Dim sFileInfo As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile
        Dim SelectedCh() As String = Nothing
        Dim JIGNum() As String = Nothing
        Dim nSelectedCnt As Integer = 0
        Dim BeforeFileName() As String = Nothing

        If m_sequenceMgr(ch) Is Nothing Then
            MsgBox("No experimental information available. Please retry after setting experiment information.")
            Exit Sub
        End If

        If DispChSampleUI(ch).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            If DispChSampleUI(ch).sample.IsLoadedSequenceInfo = True Then

                If DispChSampleUI(ch).IsSelected = True Then
                    'nSelectedCnt += 1
                    ReDim Preserve SelectedCh(nSelectedCnt)
                    SelectedCh(nSelectedCnt) = ch

                    ReDim Preserve JIGNum(nSelectedCnt)
                    JIGNum(nSelectedCnt) = ch

                    ReDim BeforeFileName(nSelectedCnt)
                End If

                For idx As Integer = 0 To SelectedCh.Length - 1 '변환해서 넣음
                    BeforeFileName(idx) = m_sequenceMgr(SelectedCh(idx)).SequenceInfo.sCommon.saveInfo.strOnlyFName
                    SelectedCh(nSelectedCnt) = ucDispJIG.convertIncNumberToMatrixValue(SelectedCh(idx))
                    JIGNum(idx) = ucDispJIG.convertIncNumberToMatrixValue_ForJIGNum(JIGNum(idx))
                Next

                If fileDlg.GetSaveFileName(CMcFile.eFileType._CSV, sFileInfo) = True Then
                    ' If fileDlg.GetSaveMultiFileName(CMcFile.eFileType._CSV, MyBase.m_sBeforSavePath, sFileInfo, nSelectedCnt + 1, SelectedCh, SelectedCh, BeforeFileName) = True Then
                    '  m_sequenceMgr(ch).SequenceInfo.sCommon.saveInfo = sFileInfo
                    Dim seqInfo As CSequenceManager.sSequenceInfo = m_sequenceMgr(ch).SequenceInfo
                    seqInfo.sCommon.saveInfo = sFileInfo
                    m_sequenceMgr(ch).SequenceInfo = seqInfo
                    MyBase.m_sBeforSavePath = m_sequenceMgr(ch).SequenceInfo.sCommon.saveInfo.strFPath
                    DispChSampleUI(ch).sample.IsLoadedSavePath = True
                    DispChSampleUI(ch).sample.SavePath = m_sequenceMgr(ch).SequenceInfo.sCommon.saveInfo.strFPath & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(ch) &
                   "_" & m_sequenceMgr(ch).SequenceInfo.sCommon.saveInfo.strFNameAndExt
                    'DispChSampleUI(ch).sample.SavePath = m_sequenceMgr(ch).SequenceInfo.sCommon.saveInfo.strPathAndFName
                End If
            Else
                MsgBox("No experimental information available. Please retry after setting experiment information.")
            End If
        End If
    End Sub

    Private Sub Channel_LoadSequenceButton_Click(ByVal ch As Integer)

        Dim sFileInfos As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile
        Dim sDefPath As String = Application.StartupPath & "\Sequence"

        'LGC
        If DispChSampleUI(ch).IsSelected = False Then
            MsgBox("Please use after selecting channel.")
            Exit Sub
        End If

        If DispChSampleUI(ch).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            If fileDlg.GetLoadFileName(CMcFile.eFileType._SEQ, sDefPath, sFileInfos) = False Then
                Exit Sub
            End If

            If m_sequenceMgr(ch).LoadSequence(sFileInfos.strPathAndFName) = False Then

            Else
                'IVL 등록쪽 업데이트 YJS 20200727 연동을 LT, IVL use로 구분하는게 좋은데 일단 보류
                Dim nDevM6000 As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                Dim bLTUse As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eLifetimeUse)
                Dim sJIGName As String = Nothing
                Dim nJIGNumber As Integer = Nothing
                For i As Integer = 0 To m_sequenceMgr(ch).SequenceInfo.sRecipes.Length - 1

                    'If m_sequenceMgr(ch).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
                    '    nJIGNumber = ucDispJIG.convertIncNumberToMatrixValue(ch)
                    '    If nJIGNumber <> 8 Then
                    '        sJIGName = ucDispJIG.convertIncNumberToMatrixValue2(ch)
                    '        MsgBox("해당 채널은 IVL 실험을 할 수 없습니다. [대상 채널 :" & "TEG" & sJIGName & "]")
                    '        Exit Sub
                    '    End If


                    'End If

                    If (m_sequenceMgr(ch).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or m_sequenceMgr(ch).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL) And nDevM6000 < 0 Then
                        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                            sJIGName = Format(ch + 1, "00")
                        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                            sJIGName = ucDispJIG.convertIncNumberToMatrixValue2(ch)
                        End If

                        MsgBox("해당 채널은 Lifetime 실험을 할 수 없습니다. [대상 채널 :" & "TEG" & sJIGName & "]") 'ch + 1
                        Exit Sub
                    End If
                Next

                DispChSampleUI(ch).sample.RecipeTitle = m_sequenceMgr(ch).SequenceInfo.sSampleInfos.sTitle
                DispChSampleUI(ch).sample.IsLoadedSequenceInfo = True
                DispChSampleUI(ch).sample.SavePath = "Nothing"
                DispChSampleUI(ch).sample.IsLoadedSavePath = False
                ''Dim seqCopyInfo As CSequenceManager.sSequenceInfo = Nothing
                ''seqCopyInfo = CSequenceManager.CloneSequenceInfo(m_sequenceMgr(ch).SequenceInfo)

                'For i As Integer = 0 To m_nMaxCh - 1
                '    If DispChSampleUI(i).IsSelected = True Then
                '        m_sequenceMgr(i).SequenceInfo = CSequenceManager.CloneSequenceInfo(m_sequenceMgr(ch).SequenceInfo)
                '        DispChSampleUI(i).sample.RecipeTitle = m_sequenceMgr(i).SequenceInfo.sSampleInfos.sTitle
                '        DispChSampleUI(i).sample.IsLoadedSequenceInfo = True
                '    End If
                'Next
            End If
        End If
    End Sub

    Private Sub Channel_UnloadSequenceButton_Click(ByVal ch As Integer)

        If DispChSampleUI(ch).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            If DispChSampleUI(ch).CellStatus <> ucDispSampleCommonNode.eCellState.eOFF Then
                MsgBox("An experimental channel can not be unloaded...")
                Exit Sub
            End If

            'LGC
            If DispChSampleUI(ch).IsSelected = False Then
                MsgBox("Please use after selecting channel.")
                Exit Sub
            End If

            m_sequenceMgr(ch).ClearTestRecipe()
            DispChSampleUI(ch).sample.RecipeTitle = "Nothing"
            DispChSampleUI(ch).sample.IsLoadedSequenceInfo = False
            DispChSampleUI(ch).sample.SavePath = "Nothing"
            DispChSampleUI(ch).sample.IsLoadedSavePath = False
        End If
    End Sub

    Private Sub JIG_LoadSequenceButton_Click(ByVal nJIGNo As Integer)

        Dim sFileInfos As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile
        Dim sDefPath As String = Application.StartupPath & "\Sequence"
        Dim bRst As Boolean = True
        Dim sMsg As String = ""
        Dim combindChNum() As Integer
        combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(nJIGNo)


        If DispChSampleUI(combindChNum(0)).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            If fileDlg.GetLoadFileName(CMcFile.eFileType._SEQ, sDefPath, sFileInfos) = False Then
                'MsgBox("Canceled")
                Exit Sub
            End If

            For i As Integer = 0 To combindChNum.Length - 1
                bRst = True


                If DispChSampleUI(combindChNum(i)).IsSelected = True Then
                    If m_sequenceMgr(combindChNum(i)).LoadSequence(sFileInfos.strPathAndFName) = False Then

                    Else
                        Dim nDevM6000 As Integer = frmSettingWind.GetAllocationValue(combindChNum(i), frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                        Dim sJIGName As String = Nothing

                        For j As Integer = 0 To m_sequenceMgr(combindChNum(i)).SequenceInfo.sRecipes.Length - 1
                            If (m_sequenceMgr(combindChNum(i)).SequenceInfo.sRecipes(j).nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or m_sequenceMgr(combindChNum(i)).SequenceInfo.sRecipes(j).nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL) And nDevM6000 < 0 Then
                                If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                    sJIGName = Format(combindChNum(i) + 1, "00")
                                ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                    sJIGName = ucDispJIG.convertIncNumberToMatrixValue(combindChNum(i))
                                End If

                                bRst = False
                                sMsg = sMsg & "," & "TEG" & sJIGName 'combindChNum(i) + 1
                                Exit For
                            End If
                        Next

                        If bRst = True Then
                            DispChSampleUI(combindChNum(i)).sample.RecipeTitle = m_sequenceMgr(combindChNum(i)).SequenceInfo.sSampleInfos.sTitle
                            DispChSampleUI(combindChNum(i)).sample.IsLoadedSequenceInfo = True
                            DispChSampleUI(combindChNum(i)).sample.SavePath = "Nothing"
                            DispChSampleUI(combindChNum(i)).sample.IsLoadedSavePath = False
                        End If

                    End If
                End If

            Next

            If sMsg <> "" Then
                sMsg.TrimStart(",")
                MsgBox("Lifetime 실험을 할 수 없습니다. 실험 정보 설정후 재시도 하십시오.[대상채널 : " & sMsg & "]")
                Exit Sub
            End If
        End If
        'Dim seqMgr As New CSequenceManager

        'If seqMgr.LoadTestSequence = False Then
        '    MsgBox("Canceled")
        '    Exit Sub
        'End If

        'Dim combindChNum() As Integer
        'combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(nJIGNo)

        'For nCh As Integer = 0 To combindChNum.Length - 1
        '    If DispChSampleUI(nCh).IsSelected = True Then
        '        m_sequenceMgr(nCh).SequenceInfo = CSequenceManager.CloneSequenceInfo(seqMgr.SequenceInfo)
        '        DispChSampleUI(nCh).sample.RecipeTitle = m_sequenceMgr(nCh).SequenceInfo.sSampleInfos.sTitle
        '        DispChSampleUI(nCh).sample.IsLoadedSequenceInfo = True
        '    End If
        'Next

    End Sub

    Private Sub JIG_UnloadSequenceButton_Click(ByVal nJIGNo As Integer)


        Dim combindChNum() As Integer

        combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(nJIGNo)
        If DispChSampleUI(combindChNum(0)).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            For i As Integer = 0 To combindChNum.Length - 1

                If DispChSampleUI(combindChNum(i)).IsSelected = True Then
                    If DispChSampleUI(i).CellStatus <> ucDispSampleCommonNode.eCellState.eOFF Then
                        MsgBox("An experimental channel can not be unloaded....")
                        Exit Sub
                    End If

                    m_sequenceMgr(combindChNum(i)).ClearTestRecipe()
                    DispChSampleUI(combindChNum(i)).sample.RecipeTitle = "Nothing"
                    DispChSampleUI(combindChNum(i)).sample.IsLoadedSequenceInfo = False
                    DispChSampleUI(combindChNum(i)).sample.SavePath = "Nothing"
                    DispChSampleUI(combindChNum(i)).sample.IsLoadedSavePath = False

                End If
            Next
        End If
    End Sub

    Private Sub JIG_SetSavePath(ByVal nJIGNo As Integer)
        Dim sFileInfo As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile

        Dim bRst As Boolean = True
        Dim sMsg As String = ""
        Dim combindChNum() As Integer
        Dim sJIGName As String = Nothing
        Dim SelectedCh() As String = Nothing
        Dim JIGNum() As String = Nothing
        Dim nSelectedCnt As Integer = 0
        Dim cnt As Integer = 0
        Dim BeforeFileName() As String = Nothing

        combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(nJIGNo)

        If DispChSampleUI(combindChNum(0)).sample.Status = CScheduler.eChSchedulerSTATE.eIdle Then


            '1.Check SequenceMgr
            For nCh As Integer = 0 To combindChNum.Length - 1
                If DispChSampleUI(combindChNum(nCh)).IsSelected = True Then
                    If m_sequenceMgr(combindChNum(nCh)) Is Nothing Then
                        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                            sJIGName = Format(combindChNum(nCh) + 1, "00")
                        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                            sJIGName = ucDispJIG.convertIncNumberToMatrixValue(combindChNum(nCh))
                        End If

                        bRst = False
                        sMsg = sMsg & "," & "TEG" & sJIGName 'combindChNum(nCh) + 1 'Format(nCh + 1, "000")
                    End If
                End If
            Next

            If bRst = False Then
                sMsg.TrimStart(",")
                MsgBox("No experimental information available. After setting the experiment information, please retry. [Target channel : " & sMsg & "]")
                Exit Sub
            End If

            '2.Check IsLoadedSequenceInfo
            sMsg = ""
            For nCh As Integer = 0 To combindChNum.Length - 1
                If DispChSampleUI(combindChNum(nCh)).IsSelected = True Then
                    If DispChSampleUI(combindChNum(nCh)).sample.IsLoadedSequenceInfo = False Then
                        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                            sJIGName = Format(combindChNum(nCh) + 1, "00")
                        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                            sJIGName = ucDispJIG.convertIncNumberToMatrixValue(combindChNum(nCh))
                        End If

                        bRst = False
                        sMsg = sMsg & "," & "TEG" & sJIGName 'combindChNum(nCh) + 1 'Format(nCh + 1, "000")
                    End If
                End If
            Next

            If bRst = False Then
                sMsg.TrimStart(",")
                MsgBox("No experimental information available. After setting the experiment information, please retry. [Target channel : " & sMsg & "]")
                Exit Sub
            End If


            '3. Save Path


            If fileDlg.GetSaveFileName(CMcFile.eFileType._CSV, sFileInfo) = False Then
                Exit Sub
            End If

            For nch As Integer = 0 To m_nMaxCh - 1
                If DispChSampleUI(nch).IsSelected = True Then
                    nSelectedCnt += 1
                    ReDim Preserve SelectedCh(nSelectedCnt - 1)
                    SelectedCh(nSelectedCnt - 1) = nch

                    ReDim Preserve JIGNum(nSelectedCnt - 1)
                    JIGNum(nSelectedCnt - 1) = nch

                    ReDim BeforeFileName(nSelectedCnt - 1)
                End If
            Next

            For idx As Integer = 0 To SelectedCh.Length - 1 '변환해서 넣음
                BeforeFileName(idx) = m_sequenceMgr(SelectedCh(idx)).SequenceInfo.sCommon.saveInfo.strOnlyFName
                SelectedCh(idx) = ucDispJIG.convertIncNumberToMatrixValue(SelectedCh(idx))
                JIGNum(idx) = ucDispJIG.convertIncNumberToMatrixValue_ForJIGNum(JIGNum(idx))
            Next


            'If g_SystemOptions.sOptionData.SaveOptions.nFileType = cDataOutput.eFileType.eCSV Then
            '    If fileDlg.GetSaveMultiFileName(CMcFile.eFileType._CSV, MyBase.m_sBeforSavePath, sFileInfo, nSelectedCnt, SelectedCh, JIGNum, BeforeFileName) = False Then
            '        Exit Sub
            '    End If
            'End If

            For i As Integer = 0 To combindChNum.Length - 1
                If DispChSampleUI(combindChNum(i)).IsSelected = True Then
                    '주의 필요 : 이 부분 때문에 메모리가 하나로 묶일 수 있을것 같음.
                    Dim seqInfo As CSequenceManager.sSequenceInfo = m_sequenceMgr(combindChNum(i)).SequenceInfo
                    seqInfo.sCommon.saveInfo = sFileInfo
                    m_sequenceMgr(combindChNum(i)).SequenceInfo = seqInfo
                    MyBase.m_sBeforSavePath = m_sequenceMgr(combindChNum(i)).SequenceInfo.sCommon.saveInfo.strFPath
                    DispChSampleUI(combindChNum(i)).sample.IsLoadedSavePath = True
                    DispChSampleUI(combindChNum(i)).sample.SavePath = m_sequenceMgr(combindChNum(i)).SequenceInfo.sCommon.saveInfo.strFPath & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(combindChNum(i)) &
                        "_" & m_sequenceMgr(combindChNum(i)).SequenceInfo.sCommon.saveInfo.strFNameAndExt ' m_sequenceMgr(combindChNum(i)).SequenceInfo.sCommon.saveInfo.strPathAndFName
                    cnt += 1
                End If
            Next
        End If
    End Sub


    Public Sub ClickJIGTempIndicator(ByVal nJIGNo As Integer)
        MyBase.ClickTempIndicator(nJIGNo)
    End Sub

#End Region

    Public Overrides ReadOnly Property LoadDefaultsequence(ByVal nCh As Integer) As Boolean
        Get
            Dim bool As Boolean = False
            If m_sequenceMgr(nCh).LoadTestSequence(nCh) = False Then
                Return False
            Else
                DispChSampleUI(nCh).sample.RecipeTitle = m_sequenceMgr(nCh).SequenceInfo.sSampleInfos.sTitle
                DispChSampleUI(nCh).sample.IsLoadedSequenceInfo = True
                DispChSampleUI(nCh).sample.SavePath = m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strFPath & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh) &
               "_" & m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strFNameAndExt
                'DispChSampleUI(nCh).sample.SavePath = m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strPathAndFName
                DispChSampleUI(nCh).sample.IsLoadedSavePath = True
                Return True
            End If
            Return bool
        End Get
    End Property


#Region "Control Event Functions"

    Private Sub ucDispMultiCtrlOfJIGLayout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_bIsLoaded = True
        SetControlLocation()

        For i As Integer = 0 To dispJIG.Length - 1
            dispJIG(i).Visible = True
        Next

    End Sub

    Private Sub ucDispMultiCtrlOfJIGLayout_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If m_bIsLoaded = False Then Exit Sub
        SetControlLocation()

    End Sub

#End Region



End Class
