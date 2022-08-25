Imports System.IO

Public Class frmChannelRangeSetttings
    Public myParent As frmMain
    Const IVLCH As Integer = 24
    Dim m_nMaxCh As Integer

    Dim m_sRangeSetting() As sRangeSettings
    Dim m_sBoardRangeSetting() As CDevM6000CommonNode.sBoardRangeInfo
    Const m_sChRangeFileName As String = "ChRangeAllocation.ini"

    Public m_SelectBrdRow As Integer
    Public m_selectRangeRow As Integer

    Structure sBoardRangeInfo
        Dim dMaxVolt As Double
        Dim dMinVolt As Double
        Dim dMaxCurr() As Double
        Dim dMinCurr() As Double
        Dim dMaxPhoto() As Double
        Dim dMinPhoto() As Double
    End Structure

    Structure sRangeSettings
        Dim nCurrentRangeIndex As CDevM6000CommonNode.eCurrentRange
        Dim nCurrentRangeIVLIndex As CDevM6000CommonNode.eCurrentRange
        Dim nPhotoRangeIndex As CDevM6000CommonNode.ePhotocurrentRange
        Dim nProbeIndex As CDevM6000CommonNode.eProbeMode
        Dim nAutoRangeIndex As CDevM6000CommonNode.eAutoRangeMode
        Dim nSemiAutoRangeIndex As CDevM6000CommonNode.eSemiAutoMode
    End Structure


    Public ReadOnly Property RangeSet As sRangeSettings()
        Get
            Return m_sRangeSetting
        End Get
    End Property

    Public Sub New(ByVal fMain As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = fMain
        Dim NumberOfBoard As Integer = 0
        Dim SumCnt As Integer = 0
        ReDim m_sRangeSetting((g_nMaxCh) - 1)
        ' ReDim m_sBoardRangeSetting(g_nMaxCh / 4 - 1)

        For i As Integer = 0 To fMain.cM6000.Length - 1
            NumberOfBoard = g_ConfigInfos.M6000Config(i).numberOfBoard
            SumCnt += NumberOfBoard
        Next
        ReDim m_sBoardRangeSetting(SumCnt - 1)
        'Dim nDevNoOfM6000 As Integer = frmChAllocation.GetAllocationValue(nCh, frmChAllocation.eChAllocationItem.eDevNoOfM6000)
        'Dim nChNoOfM6000 As Integer = frmChAllocation.GetAllocationValue(nCh, frmChAllocation.eChAllocationItem.eChOfM6000)

        Dim nCnt As Integer = 0

        For idx As Integer = 0 To fMain.cM6000.Length - 1
            For jdx As Integer = 0 To (SumCnt / fMain.cM6000.Length) - 1 'fMain.cM6000(idx).McSMU.M6000.RangeInfo.Length - 1
                'Dim nDevNoOfM6000 As Integer = frmChAllocation.GetAllocationValue(idx, frmChAllocation.eChAllocationItem.eDevNoOfM6000)
                'Dim nBoardNoOfM6000 As Integer = frmChAllocation.GetAllocationValue(jdx, frmChAllocation.eChAllocationItem.eBoardNoOfM6000)

                '장비1개당 rangeinfo 8개씩 넣으면 된다.
                m_sBoardRangeSetting(nCnt) = fMain.cM6000(idx).McSMU.RangeInfo(jdx)
                nCnt += 1
            Next
        Next

        Init()

    End Sub


    Public Sub Init()
        If g_SystemInfo.isConnected = True Then
            SetBoardInfoValue()

            SetRangeSetInfoValue()

            rbCurrRange_1.Text = m_sBoardRangeSetting(0).dMaxCurr(0)
            rbCurrRange_2.Text = m_sBoardRangeSetting(0).dMaxCurr(1)
            rbPDRange_1.Text = m_sBoardRangeSetting(0).dMaxPhoto(0)
            rbPDRange_2.Text = m_sBoardRangeSetting(0).dMaxPhoto(1)
            rbPDRange_3.Text = m_sBoardRangeSetting(0).dMaxPhoto(2)
            rbCurrRangeIVL_1.Text = m_sBoardRangeSetting(0).dMaxCurr(0)
            rbCurrRangeIVL_2.Text = m_sBoardRangeSetting(0).dMaxCurr(1)

            'Defalut set
            rbCurrRange_1.Checked = True
            rbCurrRangeIVL_2.Checked = True
            rbPDRange_2.Checked = True
        End If
    End Sub

    Public strAutorange() As String = New String() {"ON", "OFF"}
    Public strSemiAutorange() As String = New String() {"ON", "OFF"}
    Public strProbe() As String = New String() {"4Wire", "2Wire"}

    Public Sub SetRangeSetInfoValue()
        ucDispRangeSet.ClearAllData()

        Dim sTemp(5) As String

        Dim nCnt As Integer = 0
        Dim jdx As Integer = 0

        For idx As Integer = 0 To (g_nMaxCh) - 1
            sTemp(0) = m_sBoardRangeSetting(nCnt).dMaxCurr(m_sRangeSetting(idx).nCurrentRangeIndex) 'strCurrentRange(m_sRangeSetting(idx).nCurrentRangeIndex)
            sTemp(1) = m_sBoardRangeSetting(nCnt).dMaxCurr(m_sRangeSetting(idx).nCurrentRangeIVLIndex)
            sTemp(2) = m_sBoardRangeSetting(nCnt).dMaxPhoto(m_sRangeSetting(idx).nPhotoRangeIndex) ' strPhotoRange(m_sRangeSetting(idx).nPhotoRangeIndex)
            sTemp(3) = strProbe(m_sRangeSetting(idx).nProbeIndex)
            sTemp(4) = strAutorange(m_sRangeSetting(idx).nAutoRangeIndex)
            sTemp(5) = strSemiAutorange(m_sRangeSetting(idx).nSemiAutoRangeIndex)
            ucDispRangeSet.AddRowDataAndNumber(sTemp)

            jdx += 1

            If jdx = 5 Then
                nCnt += 1
                jdx = 0
            End If
        Next
    End Sub

    Public Sub SetBoardInfoValue()
        Try


            ucDispBoardRange.ClearAllData()

            Dim dTemp(11) As String

            For idx As Integer = 0 To (g_nMaxCh) / 4 - 1
                dTemp(0) = m_sBoardRangeSetting(idx).dMinVolt
                dTemp(1) = m_sBoardRangeSetting(idx).dMaxVolt
                dTemp(2) = m_sBoardRangeSetting(idx).dMinCurr(0)
                dTemp(3) = m_sBoardRangeSetting(idx).dMaxCurr(0)
                dTemp(4) = m_sBoardRangeSetting(idx).dMinCurr(1)
                dTemp(5) = m_sBoardRangeSetting(idx).dMaxCurr(1)
                dTemp(6) = m_sBoardRangeSetting(idx).dMinPhoto(0)
                dTemp(7) = m_sBoardRangeSetting(idx).dMaxPhoto(0)
                dTemp(8) = m_sBoardRangeSetting(idx).dMinPhoto(1)
                dTemp(9) = m_sBoardRangeSetting(idx).dMaxPhoto(1)
                dTemp(10) = m_sBoardRangeSetting(idx).dMinPhoto(2)
                dTemp(11) = m_sBoardRangeSetting(idx).dMaxPhoto(2)

                ucDispBoardRange.AddRowDataAndNumber(dTemp)
            Next
        Catch ex As Exception
            MsgBox("Not Read Board Data")
        End Try
    End Sub


    Private Sub ucDispBoardRange_evSelectedIndexChanged(ByVal nRow As Integer) Handles ucDispBoardRange.evSelectedIndexChanged
        'Dim setting As CDevM6000CommonNode.sBoardRangeInfo = Nothing

        'Dim configBuf As sPGGroupInfos

        'If m_sConfigData Is Nothing Then Exit Sub

        'configBuf = m_sConfigData(nRow)

        'SetValueToUI(configBuf)

        m_SelectBrdRow = nRow
        SetValueToUI(m_sBoardRangeSetting(m_SelectBrdRow))
    End Sub

    Private Sub ucDispRangeSet_evSelectedIndexChanged(ByVal nRow As Integer) Handles ucDispRangeSet.evSelectedIndexChanged
        'Dim setting As CDevM6000CommonNode.sBoardRangeInfo = Nothing

        'Dim configBuf As sPGGroupInfos

        'If m_sConfigData Is Nothing Then Exit Sub

        'configBuf = m_sConfigData(nRow)

        'SetValueToUI(configBuf)
        Dim temp As Double
        Dim BoardNum As Integer
        m_selectRangeRow = nRow
        SetValueToUI(m_sRangeSetting(m_selectRangeRow))
        temp = nRow / 4
        BoardNum = Math.Floor(temp)
        rbCurrRange_1.Text = m_sBoardRangeSetting(BoardNum).dMaxCurr(0)
        rbCurrRange_2.Text = m_sBoardRangeSetting(BoardNum).dMaxCurr(1)
        rbCurrRangeIVL_1.Text = m_sBoardRangeSetting(BoardNum).dMaxCurr(0)
        rbCurrRangeIVL_2.Text = m_sBoardRangeSetting(BoardNum).dMaxCurr(1)
        rbPDRange_1.Text = m_sBoardRangeSetting(BoardNum).dMaxPhoto(0)
        rbPDRange_2.Text = m_sBoardRangeSetting(BoardNum).dMaxPhoto(1)
        rbPDRange_3.Text = m_sBoardRangeSetting(BoardNum).dMaxPhoto(2)

    End Sub

    Private Sub SetValueToUI(ByVal setting As CDevM6000CommonNode.sBoardRangeInfo)
        tbSetRangeVoltMin.Text = setting.dMinVolt
        tbSetRangeVoltMax.Text = setting.dMaxVolt
        tbSetRangeCurrMin1.Text = setting.dMinCurr(0)
        tbSetRangeCurrMax1.Text = setting.dMaxCurr(0)
        tbSetRangeCurrMin2.Text = setting.dMinCurr(1)
        tbSetRangeCurrMax2.Text = setting.dMaxCurr(1)
        tbSetRangePhotoMin1.Text = setting.dMinPhoto(0)
        tbSetRangePhotoMax1.Text = setting.dMaxPhoto(0)
        tbSetRangePhotoMin2.Text = setting.dMinPhoto(1)
        tbSetRangePhotoMax2.Text = setting.dMaxPhoto(1)
        tbSetRangePhotoMin3.Text = setting.dMinPhoto(2)
        tbSetRangePhotoMax3.Text = setting.dMaxPhoto(2)
    End Sub

    Private Sub GetValueToUI(ByRef setting As CDevM6000CommonNode.sBoardRangeInfo)
        ReDim setting.dMinCurr(1)
        ReDim setting.dMaxCurr(1)
        ReDim setting.dMinPhoto(2)
        ReDim setting.dMaxPhoto(2)
        setting.dMinVolt = tbSetRangeVoltMin.Text
        setting.dMaxVolt = tbSetRangeVoltMax.Text
        setting.dMinCurr(0) = tbSetRangeCurrMin1.Text
        setting.dMaxCurr(0) = tbSetRangeCurrMax1.Text
        setting.dMinCurr(1) = tbSetRangeCurrMin2.Text
        setting.dMaxCurr(1) = tbSetRangeCurrMax2.Text
        setting.dMinPhoto(0) = tbSetRangePhotoMin1.Text
        setting.dMaxPhoto(0) = tbSetRangePhotoMax1.Text
        setting.dMinPhoto(1) = tbSetRangePhotoMin2.Text
        setting.dMaxPhoto(1) = tbSetRangePhotoMax2.Text
        setting.dMinPhoto(2) = tbSetRangePhotoMin3.Text
        setting.dMaxPhoto(2) = tbSetRangePhotoMax3.Text
    End Sub

    Private Sub SetValueToUI(ByVal setting As sRangeSettings)

        If setting.nCurrentRangeIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1 Then
            rbCurrRange_1.Checked = True
        ElseIf setting.nCurrentRangeIndex = CDevM6000CommonNode.eCurrentRange._RANGE_2 Then
            rbCurrRange_2.Checked = True
        End If

        If setting.nCurrentRangeIVLIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1 Then
            rbCurrRangeIVL_1.Checked = True
        ElseIf setting.nCurrentRangeIVLIndex = CDevM6000CommonNode.eCurrentRange._RANGE_2 Then
            rbCurrRangeIVL_2.Checked = True
        End If

        If setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_1 Then
            rbPDRange_1.Checked = True
        ElseIf setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_2 Then
            rbPDRange_2.Checked = True
        ElseIf setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_3 Then
            rbPDRange_3.Checked = True
        End If

        If setting.nProbeIndex = CDevM6000CommonNode.eProbeMode._2WIRE Then
            rb2Wire.Checked = True
        ElseIf setting.nProbeIndex = CDevM6000CommonNode.eProbeMode._4WIRE Then
            rb4Wire.Checked = True
        End If
    End Sub

    Private Sub GetValueToUI(ByRef setting As sRangeSettings)
        If rbCurrRange_1.Checked = True Then
            setting.nCurrentRangeIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1
        ElseIf rbCurrRange_2.Checked = True Then
            setting.nCurrentRangeIndex = CDevM6000CommonNode.eCurrentRange._RANGE_2
        End If

        If rbCurrRangeIVL_1.Checked = True Then
            setting.nCurrentRangeIVLIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1
        ElseIf rbCurrRangeIVL_2.Checked = True Then
            setting.nCurrentRangeIVLIndex = CDevM6000CommonNode.eCurrentRange._RANGE_2
        End If

        If rbPDRange_1.Checked = True Then
            setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_1
        ElseIf rbPDRange_2.Checked = True Then
            setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_2
        ElseIf rbPDRange_3.Checked = True Then
            setting.nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_3
        End If

        If rb2Wire.Checked = True Then
            setting.nProbeIndex = CDevM6000CommonNode.eProbeMode._2WIRE
        ElseIf rb4Wire.Checked = True Then
            setting.nProbeIndex = CDevM6000CommonNode.eProbeMode._4WIRE
        End If

        If rbAutoRangeOn.Checked = True Then
            setting.nAutoRangeIndex = CDevM6000CommonNode.eAutoRangeMode._On
        ElseIf rbAutoRangeOFF.Checked = True Then
            setting.nAutoRangeIndex = CDevM6000CommonNode.eAutoRangeMode._OFF
        End If

        If rbSemiAutoRangeOn.Checked = True Then
            setting.nSemiAutoRangeIndex = CDevM6000CommonNode.eSemiAutoMode._On
        ElseIf rbSemiAutoRangeOff.Checked = True Then
            setting.nSemiAutoRangeIndex = CDevM6000CommonNode.eSemiAutoMode._OFF
        End If
    End Sub

    Private Sub btnBoardRangeSet_Click(sender As System.Object, e As System.EventArgs) Handles btnBoardRangeSet.Click
        'm_SelectRow set
        Dim setting As CDevM6000CommonNode.sBoardRangeInfo = Nothing
        GetValueToUI(setting)

        m_sBoardRangeSetting(m_SelectBrdRow) = setting

        ApplyAll()

        SetBoardInfoValue()
    End Sub


    Private Sub btnBoardRangeSetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnBoardRangeSetAll.Click
        Dim setting As CDevM6000CommonNode.sBoardRangeInfo = Nothing
        GetValueToUI(setting)

        For idx As Integer = 0 To (g_nMaxCh) / 4 - 1
            m_sBoardRangeSetting(idx) = setting
        Next

        ApplyAll()

        SetBoardInfoValue()
    End Sub

    Public Sub ApplyAll()

        Dim nCnt As Integer = 0

        For nDevNo As Integer = 0 To myParent.cM6000.Length - 1

            For nBrdNo As Integer = 0 To myParent.cM6000(nDevNo).McSMU.RangeInfo.Length - 1
                If myParent.cM6000(nDevNo).McSMU.Set_RangeVoltage(nBrdNo, m_sBoardRangeSetting(nCnt).dMinVolt, m_sBoardRangeSetting(nCnt).dMaxVolt) = False Then

                End If

                If myParent.cM6000(nDevNo).McSMU.Set_RangeCurrent(nBrdNo, CDevM6000CommonNode.eCurrentRange._RANGE_1, m_sBoardRangeSetting(nCnt).dMinCurr(0), m_sBoardRangeSetting(nCnt).dMaxCurr(0)) = False Then

                End If

                If myParent.cM6000(nDevNo).McSMU.Set_RangeCurrent(nBrdNo, CDevM6000CommonNode.eCurrentRange._RANGE_2, m_sBoardRangeSetting(nCnt).dMinCurr(1), m_sBoardRangeSetting(nCnt).dMaxCurr(1)) = False Then

                End If

                If myParent.cM6000(nDevNo).McSMU.Set_RangePhotoCurrent(nBrdNo, CDevM6000CommonNode.ePhotocurrentRange._RANGE_1, m_sBoardRangeSetting(nCnt).dMinPhoto(0), m_sBoardRangeSetting(nCnt).dMaxPhoto(0)) = False Then

                End If

                If myParent.cM6000(nDevNo).McSMU.Set_RangePhotoCurrent(nBrdNo, CDevM6000CommonNode.ePhotocurrentRange._RANGE_2, m_sBoardRangeSetting(nCnt).dMinPhoto(1), m_sBoardRangeSetting(nCnt).dMaxPhoto(1)) = False Then

                End If

                If myParent.cM6000(nDevNo).McSMU.Set_RangePhotoCurrent(nBrdNo, CDevM6000CommonNode.ePhotocurrentRange._RANGE_3, m_sBoardRangeSetting(nCnt).dMinPhoto(2), m_sBoardRangeSetting(nCnt).dMaxPhoto(2)) = False Then

                End If

                nCnt += 1
            Next
        Next

    End Sub

    Private Sub btnRangeSet_Click(sender As System.Object, e As System.EventArgs) Handles btnRangeSet.Click
        Dim setting As sRangeSettings = Nothing
        GetValueToUI(setting)

        m_sRangeSetting(m_selectRangeRow) = setting

        SetRangeSetInfoValue()
    End Sub

    Private Sub btnRangeSetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRangeSetAll.Click
        Dim setting As sRangeSettings = Nothing
        GetValueToUI(setting)

        For idx As Integer = 0 To (g_nMaxCh) - 1
            m_sRangeSetting(idx) = setting
        Next

        SetRangeSetInfoValue()
    End Sub



    'Range setting----------------------------------------------------------------------------------------------
    Public Shared Function SaveRangeData(ByVal RangeData() As sRangeSettings) As Boolean

        Dim sFileTitle As String = "Channel Range Information"
        Dim sVersion As String = "1.0.0"

        If RangeData Is Nothing Then Return False

        'If file.GetSaveFileName(CMcFile.eFileType.eINI, fileInfo) = False Then Return False

        If Directory.Exists(g_sPATH_ChannelAssign) = False Then
            Directory.CreateDirectory(g_sPATH_ChannelAssign)
        End If

        Dim AllocationSaver As New CRangeInfoINI(g_sPATH_ChannelAssign & m_sChRangeFileName)

        AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.FileTitle, sFileTitle)
        AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.FileVersion, sVersion)
        AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.eMaxCh, RangeData.Length)

        For idx As Integer = 0 To RangeData.Length - 1
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.eCurrentIndex, RangeData(idx).nCurrentRangeIndex)
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.eCurrentIVLIndex, RangeData(idx).nCurrentRangeIVLIndex)
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.ePhotoIndex, RangeData(idx).nPhotoRangeIndex)
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.eProbeIndex, RangeData(idx).nProbeIndex)
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.eAutoRangeIndex, RangeData(idx).nAutoRangeIndex)
            AllocationSaver.SaveIniValue(CRangeInfoINI.eSecID.eRangeData, idx, CRangeInfoINI.eKeyID.eSemiAutoRangeIndex, RangeData(idx).nSemiAutoRangeIndex)
        Next

        Return True
    End Function

    Public Shared Function LoadRangeData(ByRef RangeData() As sRangeSettings) As Boolean

        Dim sFileTitle As String = "Channel Range Information"
        Dim sVersion As String = "1.0.0"
        Dim sTemp As String
        Dim MaxCh As Integer

        '  If SystemChAllocation.M6000_AllocatioNData Is Nothing And SystemChAllocation.MC9_AllocationData Is Nothing Then Return False
        If File.Exists(g_sPATH_ChannelAssign & m_sChRangeFileName) = False Then
            Return False
        End If

        Dim AllocationLoader As New CRangeInfoINI(g_sPATH_ChannelAssign & m_sChRangeFileName)
        '============================================
        sTemp = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.FileTitle)
        If sFileTitle <> sTemp Then Return False

        sTemp = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.FileVersion)
        If sVersion <> sTemp Then Return False
        MaxCh = g_nMaxCh   ' AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eFileInfo, 0, CRangeInfoINI.eKeyID.eMaxCh)
        ReDim RangeData(MaxCh - 1)

        For i As Integer = 0 To RangeData.Length - 1
            Try
                RangeData(i).nCurrentRangeIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.eCurrentIndex)
            Catch ex As Exception
                RangeData(i).nCurrentRangeIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1
            End Try

            Try
                RangeData(i).nCurrentRangeIVLIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.eCurrentIVLIndex)
            Catch ex As Exception
                RangeData(i).nCurrentRangeIVLIndex = CDevM6000CommonNode.eCurrentRange._RANGE_1
            End Try

            Try
                RangeData(i).nPhotoRangeIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.ePhotoIndex)
            Catch ex As Exception
                RangeData(i).nPhotoRangeIndex = CDevM6000CommonNode.ePhotocurrentRange._RANGE_2
            End Try

            Try
                RangeData(i).nProbeIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.eProbeIndex)
            Catch ex As Exception
                RangeData(i).nProbeIndex = CDevM6000CommonNode.eProbeMode._2WIRE
            End Try

            Try
                RangeData(i).nAutoRangeIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.eAutoRangeIndex)
            Catch ex As Exception
                RangeData(i).nAutoRangeIndex = CDevM6000CommonNode.eAutoRangeMode._OFF
            End Try
            Try
                RangeData(i).nSemiAutoRangeIndex = AllocationLoader.LoadIniValue(CRangeInfoINI.eSecID.eRangeData, i, CRangeInfoINI.eKeyID.eSemiAutoRangeIndex)
            Catch ex As Exception
                RangeData(i).nSemiAutoRangeIndex = CDevM6000CommonNode.eAutoRangeMode._OFF
            End Try
        Next

        Return True
    End Function

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        SaveRangeData(m_sRangeSetting)

    End Sub

    Private Sub frmChannelRangeSetttings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadRangeData(m_sRangeSetting)
        SetRangeSetInfoValue()
    End Sub




End Class