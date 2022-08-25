Public Class ucDispMultiCtrlCommonNode

    Protected m_sequenceMgr() As CSequenceManager
    Protected m_nChannel() As Integer
    Protected m_nType As eType    '생성된 컨트롤의 타입
    Protected m_nSeedIndex As Integer   '컨트롤이 담당할 채널의 시작 번지 0번 부터 시작 할 수도 있고, n번부터 시작 할 수도 있으므로,
    Protected m_nMaxCh As Integer = 0 '현재 컨트롤에서 표시할 채널의 수
    Protected m_bIsLoadedSeq() As Boolean
    Protected m_sBeforSavePath As String

    Protected m_CaptionType_Title As eCaptionType

    Public DispChCustom_QC() As ucDispCtrlUIOfCustomTypeForQC ' ucDispCtrlUIOfCustomTypeForQC
    Public DispChSampleUI() As ucDispSampleUI
    Public dispJIG() As ucDispJIG

    Public Event evRunExperiment()
    Public Event evStopExperiment()

    Public Event evClickTempIndicator(ByVal nJIGNo As Integer)
    'Public Event evClickLoadSequence()
    'Public Event evClickUnloadSeqeunce()
    'Public Event evClickEditSequence()


    Public Enum eType
        ListType
        ListTypeForQC
        CustomTypeForQC
        JIGLayout
    End Enum

    Public Enum eCaptionType
        _Number_Increase
        _Color_RGB
    End Enum

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Protected Sub init()

        ReDim m_sequenceMgr(m_nMaxCh - 1)
        ReDim m_nChannel(m_nMaxCh - 1)
        ReDim m_bIsLoadedSeq(m_nMaxCh - 1)

        For i As Integer = 0 To m_nMaxCh - 1
            m_sequenceMgr(i) = New CSequenceManager
            AddHandler m_sequenceMgr(i).evChangedSequenceInfo, AddressOf ChangedSequenceInfo
        Next

    End Sub


#Region "Properties"
    'Public Property SavePath(ByVal Ch As Integer) As CMcFile.sFILENAME
    '    Get
    '        Select Case m_nType
    '            Case eType.CustomTypeForPMX
    '                Return dispPMXCh(Ch).m_sFileInfo
    '        End Select
    '    End Get
    '    Set(ByVal value As CMcFile.sFILENAME)
    '        Select Case m_nType
    '            Case eType.CustomTypeForPMX
    '                dispPMXCh(Ch).m_sFileInfo = value
    '        End Select
    '    End Set
    'End Property

    Public Property DefaultSavePath As String
        Get
            Return m_sBeforSavePath
        End Get
        Set(ByVal value As String)
            m_sBeforSavePath = value
        End Set
    End Property

    Public Overridable Property CaptionTypeOfTitle As eCaptionType
        Get
            Return m_CaptionType_Title
        End Get
        Set(value As eCaptionType)
            m_CaptionType_Title = value
        End Set
    End Property


    Public Overridable Property SequenceList(ByVal ch As Integer) As CSequenceManager
        Get
            Return m_sequenceMgr(ch)
        End Get
        Set(ByVal value As CSequenceManager)
            m_sequenceMgr(ch) = value
        End Set
    End Property

    Public Overridable Property Channel As Integer()
        Get
            Return m_nChannel.Clone
        End Get
        Set(ByVal value() As Integer)
            m_nChannel = value.Clone
        End Set
    End Property

    Public Overridable ReadOnly Property Type As eType
        Get
            Return m_nType
        End Get
    End Property

    Public Property IsSelected(ByVal nCh As Integer) As Boolean
        Get
            Select Case m_nType
                Case eType.CustomTypeForQC
                    Return DispChCustom_QC(nCh).IsSelected
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    Return DispChSampleUI(nCh).sample.IsSelected
                Case Else
                    Return False
            End Select

            Return True
        End Get
        Set(ByVal value As Boolean)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).IsSelected = value
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout

                    Dim myJIGNo As Integer
                    myJIGNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)
                    DispChSampleUI(nCh).sample.IsSelected = value
                    If dispJIG(myJIGNo).NumberOfCell = 1 Then
                        dispJIG(myJIGNo).IsSelected = value
                    End If
            End Select
        End Set
    End Property

    Public WriteOnly Property Status(ByVal nCh As Integer) As CScheduler.eChSchedulerSTATE
        Set(ByVal value As CScheduler.eChSchedulerSTATE)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).Status(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).sample.Status = value
            End Select
        End Set
    End Property


#Region "Indicator"


    '시간 Display용 추가 CJS
    Public WriteOnly Property TotalTime_Current(ByVal nCh As Integer) As TimeSpan
        Set(ByVal value As TimeSpan)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).TotalTime_Current(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout

            End Select
        End Set
    End Property

    Public WriteOnly Property TotalTime_setValue(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).TotalTime_SetValue(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout

            End Select
        End Set
    End Property

    Public WriteOnly Property ModeTime_Current(ByVal nCh As Integer) As TimeSpan
        Set(ByVal value As TimeSpan)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).ModeTime_Current(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).ModeTime_Current = value
            End Select
        End Set
    End Property

    Public WriteOnly Property ModeTime_SetValue(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).ModeTime_SetValue(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).ModeTime_SetValue = value
            End Select
        End Set
    End Property

    Public WriteOnly Property Cycle(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).Cycle(value)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout

            End Select
        End Set
    End Property

    Dim m_nNumOfRcp As Integer
    Dim m_CurrentRcpIdx As Integer

    Public WriteOnly Property NumOfRcp(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            m_nNumOfRcp = value
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).Progress(m_CurrentRcpIdx, m_nNumOfRcp)
                Case eType.ListType

                Case eType.ListTypeForQC
                Case eType.JIGLayout
            End Select
        End Set
    End Property

    Public WriteOnly Property CurrentRcpIndex(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            m_CurrentRcpIdx = value
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).Progress(m_CurrentRcpIdx, m_nNumOfRcp)
                Case eType.ListType

                Case eType.ListTypeForQC
                Case eType.JIGLayout

            End Select
        End Set
    End Property

    Public WriteOnly Property StopReason(ByVal nCh As Integer) As String
        'Set(ByVal value As String)
        '    Select Case m_nType
        '        Case eType.CustomTypeForQC
        '            DispChCustom_QC(nCh).Progress(m_CurrentRcpIdx, m_nNumOfRcp)
        '        Case eType.ListType

        '        Case eType.ListTypeForQC
        '        Case eType.JIGLayout

        '    End Select
        'End Set
        Set(ByVal value As String)

        End Set
    End Property

    Public Overridable ReadOnly Property LoadDefaultSequence(ByVal nCh As Integer) As Boolean
        Get
            Return False
        End Get
    End Property


    Public Overridable Property Temperature(ByVal nCh As Integer) As Double
        Get
            Select Case m_nType
                Case eType.CustomTypeForQC
                    Return DispChCustom_QC(nCh).Temperature
                Case eType.ListType
                    Return -1
                Case eType.ListTypeForQC
                    Return -1
                Case eType.JIGLayout
                    Return DispChSampleUI(nCh).sample.Temperatuer
                Case Else
                    Return -1
            End Select
        End Get
        Set(ByVal value As Double)
            Select Case m_nType
                Case eType.CustomTypeForQC
                    DispChCustom_QC(nCh).Progress(m_CurrentRcpIdx, m_nNumOfRcp)
                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).sample.Temperatuer = value
            End Select
        End Set
    End Property


    Public Overridable Property IsLoadedSequenceInfo(ByVal nCh As Integer) As Boolean
        Get
            Select Case m_nType
                Case eType.CustomTypeForQC
                    Return -1
                Case eType.ListType
                    Return -1
                Case eType.ListTypeForQC
                    Return -1
                Case eType.JIGLayout
                    Return DispChSampleUI(nCh).sample.IsLoadedSequenceInfo
                Case Else
                    Return -1
            End Select

        End Get
        Set(ByVal value As Boolean)
            Select Case m_nType
                Case eType.CustomTypeForQC

                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).sample.IsLoadedSequenceInfo = value
                Case Else

            End Select
        End Set
    End Property

    Public Overridable Property IsLoadedSavePath(ByVal nCh As Integer) As Boolean
        Get
            Select Case m_nType
                Case eType.CustomTypeForQC
                    Return -1
                Case eType.ListType
                    Return -1
                Case eType.ListTypeForQC
                    Return -1
                Case eType.JIGLayout
                    Return DispChSampleUI(nCh).sample.IsLoadedSavePath
                Case Else
                    Return -1
            End Select
        End Get
        Set(ByVal value As Boolean)
            Select Case m_nType
                Case eType.CustomTypeForQC

                Case eType.ListType

                Case eType.ListTypeForQC

                Case eType.JIGLayout
                    DispChSampleUI(nCh).sample.IsLoadedSavePath = value
                Case Else

            End Select
        End Set
    End Property

#End Region

    

#End Region

#Region "Sequence Manager Event Handler Functions"

    Protected Overridable Sub ChangedSequenceInfo(ByVal sequenceInfo As CSequenceManager.sSequenceInfo)



    End Sub


#End Region



#Region "Context Menu Items Event Functions"

    Private Sub 실험시작ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험시작ToolStripMenuItem.Click
        RaiseEvent evRunExperiment()
    End Sub

    Private Sub 실험정지ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험정지ToolStripMenuItem.Click
        RaiseEvent evStopExperiment()
    End Sub

    Private Sub LoadSequenceToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSequenceToolStripMenuItem.Click

        Dim sFileInfos As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile
        Dim sDefPath As String = Application.StartupPath & "\Sequence"
        Dim bRst As Boolean = True
        Dim sMsg As String = ""
        Dim nJIGNumber As Integer = Nothing
        Dim bIVL As Boolean = False
        Dim bLT As Boolean = False

        If fileDlg.GetLoadFileName(CMcFile.eFileType._SEQ, sDefPath, sFileInfos) = False Then
            Exit Sub
        End If

        Select Case m_nType
            Case eType.CustomTypeForQC

            Case eType.ListType

            Case eType.ListTypeForQC

            Case eType.JIGLayout

                For i As Integer = 0 To m_nMaxCh - 1
                    bRst = True
                    If DispChSampleUI(i).IsSelected = True Then
                        If m_sequenceMgr(i).LoadSequence(sFileInfos.strPathAndFName) = False Then

                        Else
                            Dim nDevM6000 As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                            Dim sJIGName As String = Nothing

                            'IVL 등록쪽 업데이트 YJS 20200727
                            For j As Integer = 0 To m_sequenceMgr(i).SequenceInfo.sRecipes.Length - 1
                                'If m_sequenceMgr(i).SequenceInfo.sRecipes(j).nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
                                '    nJIGNumber = ucDispJIG.convertIncNumberToMatrixValue(i)
                                '    If nJIGNumber <> 8 Then
                                '        sJIGName = "TEG" & ucDispJIG.convertIncNumberToMatrixValue2(i)
                                '        sMsg = sMsg & "," & sJIGName
                                '        bIVL = True
                                '        bRst = False
                                '    End If
                                '    Exit For
                                'End If

                                If (m_sequenceMgr(i).SequenceInfo.sRecipes(j).nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or m_sequenceMgr(i).SequenceInfo.sRecipes(j).nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL) And nDevM6000 < 0 Then
                                    If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                        sJIGName = "TEG" & Format(i + 1, "00")
                                    ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                        sJIGName = "TEG" & ucDispJIG.convertIncNumberToMatrixValue2(i)
                                    End If

                                    bRst = False
                                    sMsg = sMsg & "," & sJIGName '& "_" & i + 1
                                    bLT = True
                                    Exit For
                                End If
                            Next

                            If bRst = True Then
                                DispChSampleUI(i).sample.RecipeTitle = m_sequenceMgr(i).SequenceInfo.sSampleInfos.sTitle
                                DispChSampleUI(i).sample.IsLoadedSequenceInfo = True
                                DispChSampleUI(i).sample.SavePath = "Nothing"
                                DispChSampleUI(i).sample.IsLoadedSavePath = False
                            End If
                        End If
                    End If
                Next

                If sMsg <> "" Then
                    sMsg.TrimStart(",")
                    If bLT = True Then
                        MsgBox("해당 채널은 Lifetime 실험을 할 수 없습니다.[대상채널 : " & sMsg & "]")
                    ElseIf bIVL = True Then
                        MsgBox("해당 채널은 IVL 실험을 할 수 없습니다.[대상채널 : " & sMsg & "]")
                    End If
                    Exit Sub
                End If
            Case Else
                    MsgBox("Function Error")
        End Select
    End Sub

    Private Sub UnloadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadSequenceToolStripMenuItem.Click
        Select Case m_nType
            Case eType.CustomTypeForQC

            Case eType.ListType

            Case eType.ListTypeForQC

            Case eType.JIGLayout
                For i As Integer = 0 To m_nMaxCh - 1
                    If DispChSampleUI(i).IsSelected = True Then
                        m_sequenceMgr(i).ClearTestRecipe()
                        DispChSampleUI(i).sample.RecipeTitle = "Nothing"
                        DispChSampleUI(i).sample.IsLoadedSequenceInfo = False
                        DispChSampleUI(i).sample.SavePath = "Nothing"
                        DispChSampleUI(i).sample.IsLoadedSavePath = False
                    End If
                Next
            Case Else
                MsgBox("Function Error")
        End Select
    End Sub

    Private Sub SavePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePathToolStripMenuItem.Click
        Select Case m_nType
            Case eType.CustomTypeForQC

            Case eType.ListType

            Case eType.ListTypeForQC

            Case eType.JIGLayout
               SetSavePath
            Case Else
                MsgBox("Function Error")
        End Select
    End Sub

    Private Sub EditSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSequenceToolStripMenuItem.Click
        Dim seqBuilder As New frmSequenceBuilder
        seqBuilder.ShowDialog()
    End Sub

    Private Sub SetSavePath()
        Dim sFileInfo As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile

        Dim bRst As Boolean = True
        Dim sMsg As String = ""
        Dim sJIGName As String = Nothing

        Dim SelectedCh() As String = Nothing
        Dim JIGNum() As String = Nothing
        Dim nSelectedCnt As Integer = 0
        Dim nCnt As Integer = 0
        Dim BeforeFileName() As String = Nothing

        '1.Check SequenceMgr
        For nCh As Integer = 0 To m_nMaxCh - 1
            If DispChSampleUI(nCh).IsSelected = True Then
                If m_sequenceMgr(nCh) Is Nothing Then
                    If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                        sJIGName = "TEG" & Format(nCh + 1, "00")
                    ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                        sJIGName = "TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh)
                    End If

                    bRst = False
                    sMsg = sMsg & "," & sJIGName '"TEG" & nCh + 1 'Format(nCh + 1, "000")
                End If
            End If
        Next

        If bRst = False Then
            sMsg.TrimStart(",")
            MsgBox("No experimental information available. After setting experiment information, please try again. [Target channel: " & sMsg & "]") 'yjs
            Exit Sub
        End If

        '2.Check IsLoadedSequenceInfo
        sMsg = ""
        For nCh As Integer = 0 To m_nMaxCh - 1
            If DispChSampleUI(nCh).IsSelected = True Then
                If DispChSampleUI(nCh).sample.IsLoadedSequenceInfo = False Then
                    If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                        sJIGName = "TEG" & Format(nCh + 1, "00")
                    ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                        sJIGName = "TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh)
                    End If
                    bRst = False
                    sMsg = sMsg & "," & sJIGName '"TEG" & nCh + 1 'Format(nCh + 1, "000")
                End If
            End If

        Next

        If bRst = False Then
            sMsg.TrimStart(",")
            MsgBox("No experimental information available. After setting experiment information, please try again. [Target channel: " & sMsg & "]") 'yjs
            Exit Sub
        End If


        '3. Save Path
        If fileDlg.GetSaveFileName(CMcFile.eFileType._CSV, m_sBeforSavePath, sFileInfo) = False Then
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

        '    If fileDlg.GetSaveMultiFileName(CMcFile.eFileType._CSV, m_sBeforSavePath, sFileInfo, nSelectedCnt, SelectedCh, SelectedCh, BeforeFileName) = False Then
        '        Exit Sub
        '    End If
        'End If


        For nCh As Integer = 0 To m_nMaxCh - 1
            If DispChSampleUI(nCh).IsSelected = True Then
                '주의 필요 : 이 부분 때문에 메모리가 하나로 묶일 수 있을것 같음.
                Dim seqInfo As CSequenceManager.sSequenceInfo = m_sequenceMgr(nCh).SequenceInfo
                seqInfo.sCommon.saveInfo = sFileInfo
                m_sequenceMgr(nCh).SequenceInfo = seqInfo
                m_sBeforSavePath = m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strFPath
                DispChSampleUI(nCh).sample.SavePath = m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strFPath & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh) & _
                   "_" & m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strFNameAndExt
                'DispChSampleUI(nCh).sample.SavePath = m_sequenceMgr(nCh).SequenceInfo.sCommon.saveInfo.strPathAndFName
                DispChSampleUI(nCh).sample.IsLoadedSavePath = True
                nCnt += 1
            End If
        Next

    End Sub

#End Region


    Protected Sub ClickTempIndicator(ByVal nJIGNo As Integer)
        RaiseEvent evClickTempIndicator(nJIGNo)
    End Sub

  
    Private Sub SelectUnselectAGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectUnselectAGroupToolStripMenuItem.Click
        Dim BGroupBegin As Integer = 25
        Dim BGroupEnd As Integer = 33

        For i As Integer = 0 To 24
            If DispChSampleUI(i).IsSelected = True Then
                DispChSampleUI(i).IsSelected = False
            Else
                DispChSampleUI(i).IsSelected = True
            End If
        Next
    End Sub

    Private Sub SelectUnselectBGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectUnselectBGroupToolStripMenuItem.Click
        Dim BGroupBegin As Integer = 25
        Dim BGroupEnd As Integer = 33
        For i As Integer = 25 To 30
            If DispChSampleUI(i).IsSelected = True Then
                DispChSampleUI(i).IsSelected = False
            Else
                DispChSampleUI(i).IsSelected = True
            End If
        Next
    End Sub

    Private Sub SelectUnselectCGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectUnselectCGroupToolStripMenuItem.Click
       
        For i As Integer = 34 To g_nMaxCh - 1
            If DispChSampleUI(i).IsSelected = True Then
                DispChSampleUI(i).IsSelected = False
            Else
                DispChSampleUI(i).IsSelected = True
            End If
        Next
    End Sub

    Private Sub SelectUnselectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectUnselectToolStripMenuItem.Click

        'For i As Integer = 0 To g_nMaxCh - 1
        '    If dispJIG(i).IsSelected = True Then
        '        dispJIG(i).IsSelected = False

        '    Else
        '        dispJIG(i).IsSelected = True
        '    End If
        'Next

        Dim bSelectJig As Boolean

        If g_SystemInfo.bSequenceLoadChk = False Then
            bSelectJig = False
            g_SystemInfo.bSequenceLoadChk = True
        Else
            bSelectJig = True
            g_SystemInfo.bSequenceLoadChk = False
        End If

        For i As Integer = 0 To g_nMaxJIG - 1
            If IsLoadedSequenceInfo(i) = True Then
                dispJIG(i).IsSelected = bSelectJig
            End If

        Next

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        For i As Integer = 0 To dispJIG.Length - 1
            dispJIG(i).IsSelected = True
        Next
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For i As Integer = 0 To dispJIG.Length - 1
            dispJIG(i).IsSelected = False
        Next
    End Sub

End Class
