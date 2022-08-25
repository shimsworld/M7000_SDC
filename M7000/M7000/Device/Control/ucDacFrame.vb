Public Class UcDacFrame
    Public ChanDac() As UcDacChannel
    Public Event UcChannelMouseMove(ByVal gCondi As UcDacChannel.Condi)
    Public Event UcChannelDacGet(ByVal gCondi As UcDacChannel.Condi)
    Public Event UcChannelDacSet(ByVal gCondi As UcDacChannel.Condi)
    Public Event UcChannelDacOnOFF(ByVal gCondi As UcDacChannel.Condi)
    Public Event UcChannelDacCheckClick(ByVal gCondi As UcDacChannel.Condi) 'DAC Chkbox read
    Public Event UcChannelCalSet(ByVal gCondi As UcDacChannel.Condi)
    Public Event UcChannelCalGet(ByVal gCondi As UcDacChannel.Condi) 'DAC Chkbox read

    Private Sub UcDacFrame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
    End Sub
    Public Sub init()

        Dim cnt As Integer = 0
        Dim AddSize As Integer = 0
        Dim tChCNt As Integer = -1

        ReDim ChanDac(cDevSG.Max_Pulse_Channel - 1)
        For cnt = 0 To cDevSG.Max_Pulse_Channel - 1
            ChanDac(cnt) = New UcDacChannel(cnt)
            Me.Controls.Add(ChanDac(cnt))
            If cnt < 1 Then
                ChanDac(cnt).Location = New System.Drawing.Point(2, 3)
                ChanDac(cnt).Chk_CH.Text = "CH" & Format(cnt, "00")

                AddSize = AddSize + ChanDac(cnt).Height
            Else
                ChanDac(cnt).Location = New System.Drawing.Point(2, AddSize + 10)
                ChanDac(cnt).Chk_CH.Text = "CH" & Format(cnt, "00")
                AddSize = AddSize + ChanDac(cnt).Height + 5
            End If

            ChanDac(cnt).gCondition.ChannelNum = cnt
            ChanDac(cnt).lbl_dacnum1.Text = "DAC " & Format(tChCNt + 1, "00")
            ChanDac(cnt).lbl_dacnum2.Text = "DAC " & Format(tChCNt + 2, "00")
            ChanDac(cnt).gCondition.DacChannelNum(0) = Int(cnt * 2 + 0)
            ChanDac(cnt).gCondition.DacChannelNum(1) = Int(cnt * 2 + 1)

            AddHandler ChanDac(cnt).UcChannelMouseMove, AddressOf fUcChannelMouseMove
            AddHandler ChanDac(cnt).UcChannelDacGet, AddressOf fUcChannelDacGet
            AddHandler ChanDac(cnt).UcChannelDacSet, AddressOf fUcChannelDacSet
            AddHandler ChanDac(cnt).UcChannelDacOnOFF, AddressOf fUcChannelDacOnOFF
            AddHandler ChanDac(cnt).UcChannelDacCheckClick, AddressOf fUcChannelDacCheckClick
            AddHandler ChanDac(cnt).UcChannelCalSet, AddressOf fUcChannelCalSet
            AddHandler ChanDac(cnt).UcChannelCalGet, AddressOf fUcChannelCalGet

            tChCNt = tChCNt + 2

        Next

    End Sub
    Public Sub fUcChannelMouseMove(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelMouseMove(gCondi)
    End Sub
    Public Sub fUcChannelDacGet(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelDacGet(gCondi)
    End Sub
    Public Sub fUcChannelDacSet(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelDacSet(gCondi)
    End Sub
    Public Sub fUcChannelDacOnOFF(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelDacOnOFF(gCondi)
    End Sub
    Public Sub fUcChannelDacCheckClick(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelDacCheckClick(gCondi)

    End Sub
    Public Sub fUcChannelCalSet(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelCalSet(gCondi)
    End Sub
    Public Sub fUcChannelCalGet(ByVal gCondi As UcDacChannel.Condi)
        RaiseEvent UcChannelCalGet(gCondi)

    End Sub
End Class
