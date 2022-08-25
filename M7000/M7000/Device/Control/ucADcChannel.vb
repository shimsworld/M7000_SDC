Public Class UcADcChannel

    Public Event UcChannelMouseMove(ByVal gCondi As Condi)
    Public Event UcChannelADcRead(ByVal gCondi As Condi) '
    Public Event UcChannelADcSetAver(ByVal gCondi As Condi) '
    Public Event UcChannelADcSetLimit(ByVal gCondi As Condi) '
    Public Event UcChannelADcSetLimitTemp(ByVal gCondi As Condi) '

    Public Event UcChannelADcCheckClick(ByVal gCondi As Condi) 'D
    Public Event UcChannelADcCalSet(ByVal gCondi As Condi)
    Public Event UcChannelADcCalGet(ByVal gCondi As Condi)
    Public Structure Condi

        Public m_RealValue As Double
        Public m_ChannelNum As Double
        Public m_Min As Double
        Public m_Max As Double

        Public m_Abs As Double

        Public m_Average As Double

        Public m_Count As Double

        Public m_AverageCount As Double
        Public m_LimitValue As Double
        Public m_LimitValueTemp As Double
    End Structure
    Public gCondition As New Condi

    Public tMax As Double = -999999
    Public tMin As Double = 999999
    Public tAver As Double = 0
    Public tAbs As Double = 0
    Public tCount As Double = 0
    Private Sub btnAdcReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdcReset.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        init()
        fCheckButton(1)
    End Sub

    Public btnArr(6) As Button
    Public Sub init()
        tMax = -999999
        tMin = 999999
        tAver = 0
        tAbs = 0
        tCount = 0

        tbAdcMin.Text = "0"
        tbAdcMax.Text = "0"
        tbAdcAver.Text = "0"
        txt_ABSadc.Text = "0"
        tbAdcCount.Text = "0"

        gCondition.m_Min = 9999999
        gCondition.m_Max = -9999999
        gCondition.m_AverageCount = 1
        gCondition.m_LimitValue = 1
        gCondition.m_Count = 0
        gCondition.m_Abs = 0


        btnArr(0) = btnADCRead
        btnArr(1) = btnAdcReset
        btnArr(2) = btn_avercountset
        btnArr(3) = btn_limitcset
        btnArr(4) = btn_limittset
        btnArr(5) = btn_calSet
        btnArr(6) = btn_calget
    End Sub
    Public Sub fCheckButton(ByVal inIndex As Integer)
        For Cnt As Integer = 0 To btnArr.Length - 1
            If Cnt = inIndex Then
                btnArr(Cnt).BackColor = Color.DeepPink
            Else
                btnArr(Cnt).BackColor = Color.LightGray

            End If

        Next

    End Sub

    Private Sub btnADCRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADCRead.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcRead(gCondition)
        fCheckButton(0)
    End Sub

    Private Sub btn_avercountset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_avercountset.Click
        gCondition.m_AverageCount = CDbl(txt_avercount.Text)
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcSetAver(gCondition)

        fCheckButton(2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limitcset.Click
        gCondition.m_LimitValue = CDbl(txt_limit.Text)
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcSetLimit(gCondition)

        fCheckButton(3)
    End Sub

    Private Sub UcADcChannel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub UcADcChannel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub Chk_CH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_CH.CheckedChanged

    End Sub

    Private Sub Chk_CH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_CH.Click

        RaiseEvent UcChannelADcCheckClick(gCondition)
    End Sub

    Private Sub btn_limittset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limittset.Click
        gCondition.m_LimitValueTemp = CDbl(txt_limittemp.Text)
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcSetLimitTemp(gCondition)

        fCheckButton(4)
    End Sub

    Private Sub btn_calSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calSet.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcCalSet(gCondition)
        fCheckButton(5)
    End Sub

    Private Sub btn_calget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calget.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelADcCalGet(gCondition)
        fCheckButton(6)
    End Sub
End Class
