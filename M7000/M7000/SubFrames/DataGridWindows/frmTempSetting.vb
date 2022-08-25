Public Class frmTempSetting

    Public fMain As frmMain

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub


    Private Sub btnCalcle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcle.Click
        Close()
    End Sub


    Private Sub frmTempSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim SequenceInfo As New CSequenceManager
        'Dim DataGrid As New ucDataGridView

        'SequenceInfo.LoadTestSequence(DataGrid.m_selectedCoulumNum)
        ''fDataGrid.UcDataGrid.m_SelectedComboItemNum()

        'UcTempSet.txtTargetTemp.Text = SequenceInfo.SequenceInfo.testRecipes(DataGrid.m_SelectedComboItemNum).TempModeParams.dTargetTemp
        'UcTempSet.txtModeTime.Text = SequenceInfo.SequenceInfo.testRecipes(DataGrid.m_SelectedComboItemNum).TempModeParams.StableTime.nSecond

    End Sub


End Class