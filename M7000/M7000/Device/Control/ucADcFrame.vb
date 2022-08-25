Public Class UcADcFrame
    Public ChanADc() As UcADcChannel
  
    Public Event UcChannelMouseMove(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcRead(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcSetAver(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcSetLimit(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcCheckClick(ByVal gCondi As UcADcChannel.Condi) '
    Public Event UcChannelADcCalSet(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcCalGet(ByVal gCondi As UcADcChannel.Condi)
    Public Event UcChannelADcSetLimitTemp(ByVal gCondi As UcADcChannel.Condi) '

    Private Sub UcADcFrame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
    End Sub
    Public Sub init()

        Dim cnt As Integer = 0
        Dim AddSize As Integer = 0
        Dim tChCNt As Integer = -1

        ReDim ChanADc(cDevSG.Max_ADC_Channel - 1)
        For cnt = 0 To cDevSG.Max_ADC_Channel - 1
            ChanADc(cnt) = New UcADcChannel
            Me.Controls.Add(ChanADc(cnt))
            If cnt < 1 Then
                ChanADc(cnt).Location = New System.Drawing.Point(2, 3)
                ChanADc(cnt).Chk_CH.Text = "CH" & Format(cnt, "00")

                AddSize = AddSize + ChanADc(cnt).Height
            Else
                ChanADc(cnt).Location = New System.Drawing.Point(2, AddSize + 10)
                ChanADc(cnt).Chk_CH.Text = "CH" & Format(cnt, "00")
                AddSize = AddSize + ChanADc(cnt).Height + 5
            End If

            ChanADc(cnt).gCondition.m_ChannelNum = cnt
            'ChanADc(cnt).lbl_dacnum1.Text = "DAC " & Format(tChCNt + 1, "00")
            'ChanADc(cnt).lbl_dacnum2.Text = "DAC " & Format(tChCNt + 2, "00")
            'ChanADc(cnt).gCondition.DacChannelNum1 = tChCNt + 1
            'ChanADc(cnt).gCondition.DacChannelNum2 = tChCNt + 2

            AddHandler ChanADc(cnt).UcChannelMouseMove, AddressOf fUcChannelMouseMove
            AddHandler ChanADc(cnt).UcChannelADcRead, AddressOf fUcChannelADcRead
            AddHandler ChanADc(cnt).UcChannelADcSetAver, AddressOf fUcChannelADcSetAver
            AddHandler ChanADc(cnt).UcChannelADcSetLimit, AddressOf fUcChannelADcSetLimit
            AddHandler ChanADc(cnt).UcChannelADcSetLimitTemp, AddressOf fUcChannelADcSetLimitTemp
            AddHandler ChanADc(cnt).UcChannelADcCheckClick, AddressOf fUcChannelADcCheckClick
            AddHandler ChanADc(cnt).UcChannelADcCalSet, AddressOf fUcChannelADcCalSet
            AddHandler ChanADc(cnt).UcChannelADcCalGet, AddressOf fUcChannelADcCalGet


        Next

    

    End Sub
    Public Sub fUcChannelMouseMove(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelMouseMove(gCondi)
    End Sub
    Public Sub fUcChannelADcRead(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcRead(gCondi)
    End Sub
    Public Sub fUcChannelADcSetAver(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcSetAver(gCondi)
    End Sub
    Public Sub fUcChannelADcSetLimit(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcSetLimit(gCondi)
    End Sub
    Public Sub fUcChannelADcCheckClick(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcCheckClick(gCondi)

    End Sub
    Public Sub fUcChannelADcCalSet(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcCalSet(gCondi)
    End Sub
    Public Sub fUcChannelADcCalGet(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcCalGet(gCondi)

    End Sub
    Public Sub fUcChannelADcSetLimitTemp(ByVal gCondi As UcADcChannel.Condi)
        RaiseEvent UcChannelADcSetLimitTemp(gCondi)

    End Sub
End Class
