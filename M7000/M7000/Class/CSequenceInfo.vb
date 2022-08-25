Public Class CSequenceInfo
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Time Info", "Sequence Info"}


    Private strKey() As String = New String() {"Ch_Num", _
                                               "ScheduleStatus", "IsSavedModeStartTime", "ModeStartTime", "IsSavedTestStartTime", _
                                               "TestStartTime", "IntervalStartTime", "IsSavedIntervalStartTime", "LifeTime", _
                                               "Counter", "CountLifeTime", "CounterChangedTemp", "nCurrentSeqIndex", _
                                               "ChSchedulerSTATE", "Meas_isRefPDCurr", "Meas_RefPDCurr", _
                                               "CurrentMeasInterval", "CurrentChangeInterval", "NextMeasTime",
                                               "LoopCounter", "CurrentSeqIndex_LifeTime", "CurrentSeqIndex_ChangeTemp", _
                                               "CurrentRecipeIndex_IVLSweep", "CurrentRecipeIndex_ViewingAngle", "CurrentRecipeIndex_LifeTimeAndIVL", _
                                              "DataSaver_numOfInfos", "DataSaver_StartTime", "DataSaver_SavedPointCounter"
                                              }



    Public Enum eSecID
        File_Info = 0
        Time_Info
        Sequence_Info
    End Enum

    Public Enum eKeyID
        Ch_Num = 0
        ScheduleStatus
        IsSavedModeStartTime
        ModeStartTime
        IsSavedTestStartTime
        TestStartTime
        IntervalStartTime
        IsSavedIntervalStartTime
        LifeTime    '신규 추가 20130404
        Counter
        CountLifeTime
        CounterChangedTemp
        nCurrentSeqIndex
        ChSchedulerSTATE
        Meas_isRefPDCurr
        Meas_RefPDCurr
        Current_MeasInterval  '신규 추가 20130404
        Current_ChangeInterval  '신규 추가 20130404
        NextMeasTime  '신규 추가 20130404
        LoopCounter  '신규 추가 20130404
        CurrentSeqIndex_LifeTime  '신규 추가 20130404
        CurrentSeqIndex_ChangeTemp  '신규 추가 20130404
        CurrentRecipeIndex_IVLSweep
        CurrentRecipeIndex_ViewingAngle
        CurrentRecipeIndex_LifeTimeAndIVL
        DataSaver_numOfInfos   '신규 추가 20130422
        DataSaver_StartTime   '신규 추가 20130422
        DataSaver_SavedPointCounter '신규 추가 20130422
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)


        Dim sSection As String
        If nSection = eSecID.File_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Time_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Sequence_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.File_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Time_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Sequence_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.File_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Time_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Sequence_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.File_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Time_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        ElseIf nSection = eSecID.Sequence_Info Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "000")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function




End Class
