Imports CSMULib

Public Class frmSourceControl

    Dim myParent As frmMain

    Public Sub New(ByVal parent As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
        init()
    End Sub

    Private Sub init()
        With cbChannel
            .Items.Clear()
            For i As Integer = 0 To g_nMaxCh - 1
                .Items.Add(Format(i + 1, "000"))
            Next
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub btnON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnON.Click

        Dim settings As ucKeithleySMUSettings.sKeithley = UcKeithleySMUSettings.Settings
        Dim nCh As Integer
        btnON.Enabled = False
        Try
            nCh = cbChannel.SelectedIndex
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            btnON.Enabled = True
            Exit Sub
        End Try


        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running)
            btnON.Enabled = True
            Exit Sub
        End If

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim nDeviceNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitchDev As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        Dim dBias As Double

        Try
            dBias = tbBias.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            btnON.Enabled = True
            Exit Sub
        End Try

        If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchON(nChOfSwitchDev) = False Then
            MsgBox("Error")
            btnON.Enabled = True
            Exit Sub
        End If

        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.InitializeSweep(settings) = False Then
            MsgBox("Error")
            btnON.Enabled = True
            Exit Sub
        End If
        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.SetBias(dBias) = False Then
            MsgBox("Error")
            btnON.Enabled = True
            Exit Sub
        End If

        btnON.Enabled = True
    End Sub

    Private Sub btnOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOFF.Click
        Dim nCh As Integer

        btnOFF.Enabled = False
        Try
            nCh = cbChannel.SelectedIndex
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            btnOFF.Enabled = True
            Exit Sub
        End Try


        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running)
            btnOFF.Enabled = True
            Exit Sub
        End If

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim nDeviceNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitchDev As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchOFF(nChOfSwitchDev) = False Then
            MsgBox("Error")
            btnOFF.Enabled = True
            Exit Sub
        End If

        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.FinalizeSweep() = False Then
            MsgBox("Error")
            btnOFF.Enabled = True
            Exit Sub
        End If
        btnOFF.Enabled = True
    End Sub

    Private Sub btnMeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim nCh As Integer = cbChannel.SelectedIndex

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then Exit Sub

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim dVoltage As Double
        Dim dCurrent As Double

        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.Measure(dVoltage, dCurrent) = True Then
            tbVoltage.Text = dVoltage
            tbCurrent.Text = dCurrent
        Else
            tbVoltage.Text = "Error"
            tbCurrent.Text = "Error"
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub btnLTSourceAllOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLTSourceAllOff.Click
        If myParent.cM6000 Is Nothing Then Exit Sub

        For i As Integer = 0 To myParent.cM6000.Length - 1
            myParent.cM6000(i).ResetAll()
        Next
    End Sub
End Class