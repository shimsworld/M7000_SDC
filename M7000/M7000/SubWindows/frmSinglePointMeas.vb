Imports System.Threading
Imports CSMULib
Imports CSpectrometerLib

Public Class frmSinglePointMeas

#Region "Define"

    Dim myParent As frmMain

#End Region

#Region "Property"

    Public Property Channel As Integer
        Get
            Return cbChannel.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            cbChannel.SelectedIndex = value
        End Set
    End Property
#End Region

#Region "Creator And Init"

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

#End Region

#Region "Functions"


    Private Sub btnON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnON.Click

        Dim settings As ucKeithleySMUSettings.sKeithley = UcKeithleySMUSettings.Settings
        Dim nCh As Integer = cbChannel.SelectedIndex

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then Exit Sub

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim nDeviceNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitchDev As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        Dim dBias As Double

        Try
            dBias = tbBias.Text
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Exit Sub
        End Try

        If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchON(nChOfSwitchDev) = False Then
            MsgBox("Error")
            Exit Sub
        End If

        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.InitializeSweep(settings) = False Then
            MsgBox("Error")
            Exit Sub
        End If
        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.SetBias(dBias) = False Then
            MsgBox("Error")
            Exit Sub
        End If
    End Sub

    Private Sub btnOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOFF.Click
        Dim nCh As Integer = cbChannel.SelectedIndex

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then Exit Sub

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim nDeviceNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitchDev As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchOFF(nChOfSwitchDev) = False Then
            MsgBox("Error")
            Exit Sub
        End If

        If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.FinalizeSweep() = False Then
            MsgBox("Error")
            Exit Sub
        End If
    End Sub

    Private Sub btnMeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim nCh As Integer = cbChannel.SelectedIndex

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then Exit Sub

        Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        Dim dVoltage As Double
        Dim dCurrent As Double
        Dim measData As CDevSpectrometerCommonNode.tData = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nWavelengthInterval As Integer = Nothing
        Dim dSampleWidth As Double = CDbl(tbSampleWidth.Text)
        Dim dSampleHight As Double = CDbl(tbSampleHight.Text)
        Dim dSampleArea As Double = dSampleWidth * dSampleHight / 100
        Dim dFillFactor As Double = CDbl(tbFillFactor.Text)
        Dim dLuminance As Double
        Dim dcdPerAmpare As Double
        Dim dlmW As Double
        Dim dQE As Double
        Dim dJ As Double

        Dim nTimeOutCnt As Integer = 0


        btnMeas.Enabled = False
        btnMeas.Text = "Measuring"

        If chkLMeas.Checked = False Then
            If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.Measure(dVoltage, dCurrent) = True Then
                dJ = (dCurrent * 1000) / (dSampleArea * dFillFactor) * 100
                tbVoltage.Text = dVoltage
                tbCurrent.Text = dCurrent
                tbCurrentdensity.Text = dJ
            Else
                tbVoltage.Text = "Error"
                tbCurrent.Text = "Error"
                tbCurrentdensity.Text = "Error"
            End If


        Else

            'Motion Move
            If myParent.cMotion.SetPosition(g_motionPosSpectrometer(nCh)) = False Then

                Exit Sub
            End If

            'myParent.cMotion.MoveCompletedAllAxis()
            Application.DoEvents()
            Thread.Sleep(1000)


            'IV Meas
            If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.Measure(dVoltage, dCurrent) = True Then
                dJ = (dCurrent * 1000) / (dSampleArea * dFillFactor) * 100
                tbVoltage.Text = dVoltage
                tbCurrent.Text = dCurrent
                tbCurrentdensity.Text = dJ
            Else
                tbVoltage.Text = "Error"
                tbCurrent.Text = "Error"
                tbCurrentdensity.Text = "Error"
            End If




            nTimeOutCnt = 0
            Do
                If nTimeOutCnt > 5 Then
                    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
                    tbLuminance.Text = "Error"
                    tbCdPerAmpare.Text = "Error"
                    tbCIE1931x.Text = "Error"
                    tbCIE1931y.Text = "Error"
                    tbCIE1976u.Text = "Error"
                    tbCIE1976v.Text = "Error"
                    tbQE.Text = "Error"
                    Exit Sub
                End If

                If myParent.cSpectormeter(0).mySpectrometer.Measure(measData) = True Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop




            nTimeOutCnt = 0
            Do
                If nTimeOutCnt > 5 Then
                    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
                    tbLuminance.Text = "Error"
                    tbCdPerAmpare.Text = "Error"
                    tbCIE1931x.Text = "Error"
                    tbCIE1931y.Text = "Error"
                    tbCIE1976u.Text = "Error"
                    tbCIE1976v.Text = "Error"
                    tbQE.Text = "Error"
                    Exit Sub
                End If

                If myParent.cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop


            'If myParent.cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then

            'Else
            '    tbLuminance.Text = "Error"
            '    tbCdPerAmpare.Text = "Error"
            '    tbCIE1931x.Text = "Error"
            '    tbCIE1931y.Text = "Error"
            '    tbCIE1976u.Text = "Error"
            '    tbCIE1976v.Text = "Error"
            '    tbQE.Text = "Error"
            'End If

            dLuminance = measData.D6.s2YY
            nWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)

            dcdPerAmpare = dLuminance / (dJ * 10)
            dlmW = dcdPerAmpare / dVoltage * Math.PI
            dQE = cDataQE.QuantumEfficiency(dLuminance, dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)

            tbLuminance.Text = dLuminance
            tbCdPerAmpare.Text = dcdPerAmpare
            tbCIE1931x.Text = measData.D6.s3xx
            tbCIE1931y.Text = measData.D6.s4yy
            tbCIE1976u.Text = measData.D3.s3uu
            tbCIE1976v.Text = measData.D3.s4vv
            tbQE.Text = dQE


        End If
        btnMeas.Enabled = True
        btnMeas.Text = "MEASURE"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub


#End Region





End Class