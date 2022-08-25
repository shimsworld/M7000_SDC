Public Class frmCA310ManualMeasUI


#Region "Define"
    Public myParent As frmMain
    Dim sCA310DataHeaders() As String = New String() {"[No]", "[Luminance(Cd/m2)]", "[CIE1931 x]", "[CIE1931 y]", "[CCT]", "[MPCD]", "[u]", "[v]"}
#End Region


#Region "Creator And Disposer"

    Public Sub New(ByVal main As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        myParent = main
        init()
    End Sub

    Private Sub init()
        Dim sData() As String

        ReDim sData(sCA310DataHeaders.Length - 2)

        ucCA310DataListview.ClearAllData()

        ucCA310DataListview.ColHeader = sCA310DataHeaders.Clone

        Dim colWidthRatio As String
        colWidthRatio = "7,25"
        Dim nWidth As Integer = Fix(100 / (sCA310DataHeaders.Length - 2))
        For i As Integer = 2 To sCA310DataHeaders.Length - 1
            colWidthRatio = colWidthRatio & "," & CStr(nWidth)
        Next
        ucCA310DataListview.ColHeaderWidthRatio = colWidthRatio

    End Sub

#End Region

    Private Function SaveData() As Boolean
        Dim cFile As New CMcFile
        Dim sLineBuf As String = ""
        Dim m_FileInfo As CMcFile.sFILENAME = Nothing
        Dim m_nFileNum As Integer = 10

        Dim datas() As ListViewItem.ListViewSubItem = Nothing

        If cFile.GetSaveFileName(CMcFile.eFileType._CSV, m_FileInfo) = False Then Return False

        Try
            FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            FileClose(m_nFileNum)
            Return False
        End Try

        For i As Integer = 0 To sCA310DataHeaders.Length - 1
            sLineBuf = sLineBuf & sCA310DataHeaders(i) & ","
        Next
        PrintLine(m_nFileNum, sLineBuf)


        For i As Integer = 0 To ucCA310DataListview.GetListItemCount - 1
            ucCA310DataListview.GetRowData(i, datas)

            sLineBuf = ""
            For j As Integer = 0 To datas.Length - 1
                sLineBuf = sLineBuf & datas(j).Text & ","
            Next
            PrintLine(m_nFileNum, sLineBuf)
        Next

        FileClose(m_nFileNum)

        Return True
    End Function

    Private Sub btnDataSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataSave.Click
        If SaveData() = False Then
            MsgBox("Data save fail.....")
        End If
    End Sub

    Private Sub btnListviewClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListviewClear.Click
        ucCA310DataListview.ClearAllData()
        nCnt = 0
    End Sub


    Dim nCnt As Integer = 0

    Private Sub btnCA310Meas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCA310Meas.Click
        Dim sData(sCA310DataHeaders.Length - 1) As String
        Dim measData As CColorAnalyzerLib.CDevCAxxxCMD.sDatas = Nothing

        If myParent.cColorAnalyzer(0).myColorAnalyzer.Measure(measData) = True Then

        Else
            ' MsgBox(ColorAnalyzer(m_devNo).myColorAnalyzer.ErrorMessage) 'LEX_20141202 ADd Exception Message
        End If


        sData(0) = nCnt
        sData(1) = measData.Lv
        sData(2) = measData.sx
        sData(3) = measData.sy
        sData(4) = measData.CCT
        sData(5) = measData.MPCD
        sData(6) = measData.u
        sData(7) = measData.v

        ucCA310DataListview.AddItems(sData)
        nCnt += 1

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub
End Class