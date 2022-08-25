Imports System.Threading

Public Class frmPLCMotionControl
    Dim m_Main As frmMain

    Private Delegate Sub DelSetString(ByVal ctrl As Windows.Forms.Label, ByVal str As String)

    Public Sub SetLabelText(ByVal ctrl As Windows.Forms.Label, ByVal str As String)
        If ctrl.InvokeRequired = True Then
            Dim Del2 As DelSetString = New DelSetString(AddressOf SetLabelText)
            Invoke(Del2, New Object() {ctrl, str})
        Else
            ctrl.Text = str
        End If
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

    End Sub

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Dim sConfigInfo As CCommLib.CComCommonNode.sCommInfo = Nothing '.sSerialPortInfo 'CCommLib.CComCommonNode.sCommInfo = Nothing

        With sConfigInfo.sLanInfo
            'sConfigInfo.commType = g_ConfigInfos.PLCConfig(0).communicationType
            'sConfigInfo.sSerialInfo = g_ConfigInfos.PLCConfig(0).settings.sSerialInfo
            .sIPAddress = tbIPAdress1.Text & "." & tbIPAdress2.Text & "." & tbIPAdress3.Text & "." & tbIPAdress4.Text
            .nPort = 0  ' 디폴트설정 0아니면 1일듯? 
        End With

        '  m_Main.cPLC.Disconnection()

        If m_Main.cPLC.Connection(sConfigInfo) = False Then ', cbCheckSafety.Checked) = False Then
            MsgBox("Open Fail...")
            btnSend.Enabled = False
            ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            Exit Sub
        End If

        'Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Y ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'ReDim reqInfo.Param(1)

        'Try

        '    'If position < 0 Then
        '    '    MsgBox("음수 일 수 없습니다.")
        '    '    '  Return False
        '    'Else
        '    reqInfo.Param(0) = 0 * 1000
        '    reqInfo.Param(1) = 50 * 1000
        '    reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
        '    ' End If


        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    ' Return False
        'End Try

        'm_Main.cPLC.Request(reqInfo)

        'Application.DoEvents()
        'Thread.Sleep(500)

        'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eY)

        ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink
        Timer1.Enabled = True
        btnSend.Enabled = True

        Dim StatusCaptions() As String = m_Main.cPLC.PLCSignalInfo.sStatusCaptions.Clone   ' CDevPLC.sStatusCaption.Clone


        With cbSelStatus
            .Items.Clear()
            For i As Integer = 0 To StatusCaptions.Length - 1
                .Items.Add(StatusCaptions(i))
            Next
            .SelectedIndex = 0
        End With

        StartThread()

    End Sub

    Private Sub btnDisconnection_Click(sender As Object, e As EventArgs) Handles btnDisconnection.Click
        m_Main.cPLC.Disconnection()
        btnSend.Enabled = False
    End Sub

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main


        ' Dim StatusCaptions() As String = main.cPLC.PLCSignalInfo.sStatusCaptions.Clone   ' CDevPLC.sStatusCaption.Clone

        'With cbSelStatus
        '    .Items.Clear()
        '    For i As Integer = 0 To StatusCaptions.Length - 1
        '        .Items.Add(StatusCaptions(i))
        '    Next
        '    .SelectedIndex = 0
        'End With

        btnL.Dock = DockStyle.Fill
        btnR.Dock = DockStyle.Fill
        btnDown.Dock = DockStyle.Fill
        btnUP.Dock = DockStyle.Fill
        btnStop.Dock = DockStyle.Fill

        tlpJOG.Dock = DockStyle.Fill

        'StartThread()
    End Sub
    Dim trdMonitor As Thread
    Dim m_bEnableDispUpdate As Boolean = False
    Private Sub StartThread()
        m_bEnableDispUpdate = True
        trdMonitor = New Thread(AddressOf PositionDisplay)
        trdMonitor.Start()
    End Sub

    Private Sub StopThread()
        m_bEnableDispUpdate = False
    End Sub

    Public Sub PositionDisplay()
        Do While m_bEnableDispUpdate
            Application.DoEvents()

            ' If m_Main.cPLC.IsConnected = True Then

            Dim tPositionArr() As Double
            tPositionArr = m_Main.cPLC.CurrentPosition

            Try
                If tPositionArr Is Nothing Then
                    lblXPos.Text = "0.000"
                    lblYPos.Text = "0.000"
                    lblZPos.Text = "0.000"
                    lblTheta1Pos.Text = "0.000"
                    lblTheta2Pos.Text = "0.000"
                    lblTheta3Pos.Text = "0.000"
                    lblTheta4Pos.Text = "0.000"
                Else

                    For Cnt As Integer = 0 To tPositionArr.Length - 1
                        'If Cnt = 0 Then
                        '    SetLabelText(lblXPos, "X : " & Format(tPositionArr(Cnt), "0.000"))
                        If Cnt = 0 Then
                            SetLabelText(lblYPos, "Y : " & Format(tPositionArr(Cnt), "0.000"))
                        ElseIf Cnt = 1 Then
                            SetLabelText(lblZPos, "Z : " & Format(tPositionArr(Cnt), "0.000"))
                        ElseIf Cnt = 2 Then
                            SetLabelText(lblTheta1Pos, "θ1 : " & Format(tPositionArr(Cnt), "0.000"))
                        ElseIf Cnt = 3 Then
                            SetLabelText(lblTheta2Pos, "θ2 : " & Format(tPositionArr(Cnt), "0.000"))
                        ElseIf Cnt = 4 Then
                            SetLabelText(lblTheta3Pos, "θ3 : " & Format(tPositionArr(Cnt), "0.000"))
                        ElseIf Cnt = 5 Then
                            SetLabelText(lblTheta4Pos, "θ4 : " & Format(tPositionArr(Cnt), "0.000"))
                        End If
                    Next

                End If
            Catch ex As Exception

            End Try


            '  End If

            Thread.Sleep(200)

        Loop
    End Sub

    Private Sub btnSetVelocity_Click(sender As Object, e As EventArgs) Handles btnSetVelocity.Click
        '각 축 속도 SETTING
        ' If SetJOG_X_Velocity(CInt(tbVelocity_X.Text)) = False Then Exit Sub
        If SetJOG_Y_Velocity(CInt(tbVelocity_Y.Text)) = False Then Exit Sub
        If SetJOG_Z_Velocity(CInt(tbVelocity_Z.Text)) = False Then Exit Sub
        If SetJOG_Theta_Velocity(CInt(tbVelocity_Theta.Text)) = False Then Exit Sub
    End Sub

    Private Sub btnJogON_Click(sender As Object, e As EventArgs) Handles btnJogON.Click
        JogMode_ON()
    End Sub

    Private Sub btnJogOFF_Click(sender As Object, e As EventArgs) Handles btnJogOFF.Click
        JogMode_Off()
    End Sub

    Private Sub btnInterrock_Click(sender As Object, e As EventArgs) Handles btnInterrock.Click
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eInterrockON
        'reqInfo.nSYSStatus = Nothing ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Private Sub btnSetStatus_Click(sender As Object, e As EventArgs) Handles btnSetStatus.Click

        Dim selIdx As Integer = cbSelStatus.SelectedIndex

        Dim state As CDevPLCCommonNode.eSystemStatus = selIdx
        'Dim state As CDevPLCCommonNode.eSystemStatus = CDevPLC.nStatusValue(selIdx)

        'If selIdx = 0 Then
        '    state = CDevPLC.eSystemStatus.eDown
        'Else
        '    state = 2 ^ (selIdx - 1)
        'End If

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetStatus
        reqInfo.nSYSStatus = state ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Private Sub btnGetStatus_Click(sender As Object, e As EventArgs) Handles btnGetStatus.Click

    End Sub

    Private Sub btnSetDI_Click(sender As Object, e As EventArgs) Handles btnSetDI.Click

    End Sub

    Private Sub btnXmove_Click(sender As Object, e As EventArgs) Handles btnXmove.Click
        'Dim dPos As Double
        'Dim nVelocity As Integer

        'Try
        '    dPos = CDbl(txtPosition.Text)
        '    nVelocity = CInt(txtVelocity.Text)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    Exit Sub
        'End Try

        ''btnXmove.Enabled = False
        ''btnYmove.Enabled = False
        ''btnZmove.Enabled = False

        'XMove(dPos, nVelocity)

        'btnXmove.Enabled = True
        'btnYmove.Enabled = True
        'btnZmove.Enabled = True
    End Sub

    Private Sub btnYmove_Click(sender As Object, e As EventArgs) Handles btnYmove.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        YMove(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    Private Sub btnZmove_Click(sender As Object, e As EventArgs) Handles btnZmove.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        ZMove(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    Private Sub btnHomming_Click(sender As Object, e As EventArgs) Handles btnHomming.Click
        btnHomming.Enabled = False
        Homming()
        btnHomming.Enabled = True
    End Sub

    Private Sub btnGetPosition_Click(sender As Object, e As EventArgs) Handles btnGetPosition.Click
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_GET_Position ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing

        m_Main.cPLC.Request(reqInfo)
    End Sub
    Public Function SetJOG_X_Velocity(ByVal XVelocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_X_Velocity ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(0)
        Try
            reqInfo.Param(0) = CDbl(XVelocity)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        Return True
    End Function
    Public Function SetJOG_Y_Velocity(ByVal YVelocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Y_Velocity ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(0)
        Try
            reqInfo.Param(0) = CDbl(YVelocity) * 1000
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        Return True
    End Function
    Public Function SetJOG_Z_Velocity(ByVal ZVelocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Z_Velocity ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(0)
        Try
            reqInfo.Param(0) = CDbl(ZVelocity) * 1000
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        Return True
    End Function
    Public Function SetJOG_Theta_Velocity(ByVal ZVelocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Theta_Velocity ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(0)
        Try
            reqInfo.Param(0) = CDbl(ZVelocity) * 1000
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        Return True
    End Function
    Public Sub JogMode_ON()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Mode_Clear ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'm_Main.cPLC.Request(reqInfo)

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_ON ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)
    End Sub

    Public Sub JogMode_Off()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_OFF ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)
    End Sub

    Public Sub Homming()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Homming ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing

        m_Main.cPLC.Request(reqInfo)

        '  MoveCompletedAllAxis()
    End Sub

    Public Sub UpdateCurrentPosition()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_GET_Position ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Public Sub SetStop()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)


        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'm_Main.cPLC.Request(reqInfo)
    End Sub

    Public Function YMove(ByVal position As Double, ByVal velocity As Integer) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Y ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eY)

        Return True
    End Function

    ' Public Function XMove(ByVal position As Double, ByVal velocity As Integer) As Boolean
    'Dim reqInfo As CDevPLCCommonNode.sRequestInfo

    'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_X ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    'ReDim reqInfo.Param(1)
    'Try
    '    reqInfo.Param(0) = position * 1000
    '    reqInfo.Param(1) = velocity * 1000
    '    If rbAbs.Checked = True Then
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
    '    Else
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString)
    '    Return False
    'End Try

    'm_Main.cPLC.Request(reqInfo)

    'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eX)

    'Return True
    'End Function

    Public Function ZMove(ByVal position As Double, ByVal velocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Z ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eZ)

        Return True
    End Function

    Public Function Theta1Move(ByVal position As Double, ByVal velocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta1  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA1)

        Return True
    End Function


    Public Function Theta2Move(ByVal position As Double, ByVal velocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta2 ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA2)

        Return True
    End Function


    Public Function Theta3Move(ByVal position As Double, ByVal velocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta3 ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA3)

        Return True
    End Function


    Public Function Theta4Move(ByVal position As Double, ByVal velocity As Integer) As Boolean

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta4 ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            reqInfo.Param(0) = position * 1000
            reqInfo.Param(1) = velocity * 1000
            If rbAbs.Checked = True Then
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
            Else
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        m_Main.cPLC.Request(reqInfo)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA4)

        Return True
    End Function

    Public Sub MoveCompletedAllAxis(ByVal Axis As CDevPLCCommonNode.eAxis)
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        Application.DoEvents()
        Thread.Sleep(100)

        'If Axis = CDevPLCCommonNode.eAxis.eX Then
        '    m_Main.cPLC.XMoveCompleted = False
        '    Do
        '        Thread.Sleep(200)
        '        Application.DoEvents()
        '    Loop Until m_Main.cPLC.XMoveCompleted = True
        '    ''완료 후 ACK날림
        '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        '    reqInfo.Param = Nothing
        '    ReDim reqInfo.Param(0)
        '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eX
        '    m_Main.cPLC.Request(reqInfo)

        If Axis = CDevPLCCommonNode.eAxis.eY Then
            m_Main.cPLC.YMoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.YMoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eY
            m_Main.cPLC.Request(reqInfo)

        ElseIf Axis = CDevPLCCommonNode.eAxis.eZ Then
            m_Main.cPLC.ZMoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.ZMoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eZ
            m_Main.cPLC.Request(reqInfo)

        ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA1 Then
            m_Main.cPLC.Theta1MoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.Theta1MoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA1
            m_Main.cPLC.Request(reqInfo)
        ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA2 Then
            m_Main.cPLC.Theta2MoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.Theta2MoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA2
            m_Main.cPLC.Request(reqInfo)
        ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA3 Then
            m_Main.cPLC.Theta3MoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.Theta3MoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA3
            m_Main.cPLC.Request(reqInfo)
        ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA4 Then
            m_Main.cPLC.Theta4MoveCompleted = False
            Do
                Thread.Sleep(200)
                Application.DoEvents()
            Loop Until m_Main.cPLC.Theta4MoveCompleted = True
            ''완료 후 ACK날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA4
            m_Main.cPLC.Request(reqInfo)
        End If
    End Sub
    Public Sub MoveCompletedAllAxis()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        Application.DoEvents()
        Thread.Sleep(100)

        'm_Main.cPLC.XMoveCompleted = False
        'Do
        '    Thread.Sleep(500)
        '    Application.DoEvents()
        'Loop Until m_Main.cPLC.XMoveCompleted = True

        ''완료 후 ACK 신호 날림
        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'ReDim reqInfo.Param(0)
        'reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eX
        'm_Main.cPLC.Request(reqInfo)


        m_Main.cPLC.YMoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.YMoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eY
        m_Main.cPLC.Request(reqInfo)

        m_Main.cPLC.ZMoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.ZMoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eZ
        m_Main.cPLC.Request(reqInfo)

        m_Main.cPLC.Theta1MoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.Theta1MoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA1
        m_Main.cPLC.Request(reqInfo)

        m_Main.cPLC.Theta2MoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.Theta2MoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA2
        m_Main.cPLC.Request(reqInfo)

        m_Main.cPLC.Theta3MoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.Theta3MoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA3
        m_Main.cPLC.Request(reqInfo)

        m_Main.cPLC.Theta4MoveCompleted = False
        Do
            Thread.Sleep(500)
            Application.DoEvents()
        Loop Until m_Main.cPLC.Theta4MoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA4
        m_Main.cPLC.Request(reqInfo)

    End Sub
    Private Sub btnR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseUp, btnUP.MouseUp, btnDown.MouseUp, btnL.MouseUp

        'Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'm_Main.cPLC.Request(reqInfo)

        SetStop()

    End Sub
    'X Jog Move  ///////////////////////////////////////////////
    'R
    Private Sub btnR_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseDown
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        If rbMicroAdjust.Checked = False Then
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDbl(tbVelocity_Y.Text) * 1000
            '  reqInfo.Param = Nothing
            m_Main.cPLC.Request(reqInfo)
        Else
            Dim dDist As Double
            Try
                dDist = txtPosition.Text
            Catch ex As Exception
                MsgBox("입력 값이 잘못 되었습니다.")
                Exit Sub
            End Try
            dDist = Math.Abs(dDist) * -1
            '   myParent.cMotion.XMove(dDist, rbAbs.Checked)
        End If
    End Sub

    'X축 L
    Private Sub btnL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnL.MouseDown
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        If rbMicroAdjust.Checked = False Then
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_DownMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDbl(tbVelocity_Y.Text) * 1000
            '  reqInfo.Param = Nothing
            m_Main.cPLC.Request(reqInfo)
        Else
            Dim dDist As Double
            Try
                dDist = txtPosition.Text
            Catch ex As Exception
                MsgBox("입력 값이 잘못 되었습니다.")
                Exit Sub
            End Try
            dDist = Math.Abs(dDist)
            '  myParent.cMotion.XMove(dDist, rbAbs.Checked)
        End If
    End Sub

    'Y,Z Jog Move ///////////////////////////////////////////////
    Private Sub btnUP_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUP.MouseDown
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        If chkTheta1.Checked = True Then    'Y축 이동

            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                ' reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                ' myParent.cMotion.JogYuPMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist) * -1
                ' myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If
        ElseIf chkTheta2.Checked = True Then
            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                ' reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                ' myParent.cMotion.JogYuPMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist) * -1
                ' myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        ElseIf chkTheta3.Checked = True Then

            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                ' reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                ' myParent.cMotion.JogYuPMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist) * -1
                ' myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If
        ElseIf chkTheta4.Checked = True Then
            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                ' reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                ' myParent.cMotion.JogYuPMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist) * -1
                ' myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If
        Else    'Z축 이동

            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_UpMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Z.Text) * 1000
                '  reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogZUpMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist) * -1
                'myParent.cMotion.ZMove(dDist, rbAbs.Checked)
            End If

        End If
    End Sub

    Private Sub btnDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDown.MouseDown
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        If chkTheta1.Checked = True Then    'Y축 이동

            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_DownMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                'reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogYDownMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist)
                'myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If
        ElseIf chkTheta2.Checked = True Then
            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                'reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogYDownMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist)
                'myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        ElseIf chkTheta3.Checked = True Then
            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                'reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogYDownMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist)
                'myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        ElseIf chkTheta4.Checked = True Then
            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Theta.Text) * 1000
                'reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogYDownMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist)
                'myParent.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        Else    'Z축 이동

            If rbMicroAdjust.Checked = False Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = CDbl(tbVelocity_Z.Text) * 1000
                ' reqInfo.Param = Nothing
                m_Main.cPLC.Request(reqInfo)
                'myParent.cMotion.JogZDownMove()
            Else
                Dim dDist As Double
                Try
                    dDist = txtPosition.Text
                Catch ex As Exception
                    MsgBox("입력 값이 잘못 되었습니다.")
                    Exit Sub
                End Try
                dDist = Math.Abs(dDist)
                'myParent.cMotion.ZMove(dDist, rbAbs.Checked)
            End If

        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)


        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)

        ';myParent.cMotion.Set_Stop()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nInValue As Integer = tbInDex.Text
        Dim nBinery(7) As Integer

        If nInValue < 0 Or nInValue > 255 Then
            MsgBox("Input Value : 0 ~ 255")
            Exit Sub
        End If

        'aaaaaaaa
        nBinery = CDevPLCCommonNode.DecToBinery(nInValue) ' CDevPLC.DecToBinery(nInValue)

        Dim str As String = ""

        For i As Integer = nBinery.Length - 1 To 0 Step -1
            str = str & CStr(nBinery(i))
        Next
        tbOutBinery.Text = str
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nInValue As String = TextBox3.Text
        Dim nBinery() As Integer = Nothing
        'If nInValue < 0 Or nInValue > 255 Then
        '    MsgBox("Input Value : 0 ~ 255")
        '    Exit Sub
        'End If


        'aaa nBinery = m_Main.cPLC.myPLC.hex2bin(nInValue)

        Dim str As String = ""

        For i As Integer = nBinery.Length - 1 To 0 Step -1
            str = str & CStr(nBinery(i))
        Next
        TextBox4.Text = str
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        For i As Integer = 0 To m_Main.cPLC.Datas.nSystemStatus.Length - 1
            Select Case m_Main.cPLC.Datas.nSystemStatus(i)
                Case CDevPLCCommonNode.eSystemStatus.ePower_On
                    ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.ePower_Down
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eTeaching_Mode
                    ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eAuto_Mode
                    ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eManual_Mode
                    ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eProcessing
                    ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            End Select
        Next
        Timer1.Enabled = True
    End Sub

    Private Sub frmPLCMotionControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbSelStatus.SelectedIndex = 0

        ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
        ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

    End Sub

    Private Sub BtnAlaramReset_Click(sender As Object, e As EventArgs) Handles BtnAlaramReset.Click
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eAlarm_Reset ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)

    End Sub

    Private Sub btnAllReset_Click(sender As Object, e As EventArgs) Handles btnAllReset.Click
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eAll_Reset
        reqInfo.Param = Nothing
        m_Main.cPLC.Request(reqInfo)
    End Sub

   
  
    Private Sub btnTheta1Move_Click(sender As Object, e As EventArgs) Handles btnTheta1Move.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        Theta1Move(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    
    Private Sub btn_Theta2Move_Click(sender As Object, e As EventArgs) Handles btn_Theta2Move.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        Theta2Move(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    Private Sub btn_Theta3Move_Click(sender As Object, e As EventArgs) Handles btn_Theta3Move.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        Theta3Move(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    Private Sub btn_Theta4Move_Click(sender As Object, e As EventArgs) Handles btn_Theta4Move.Click
        Dim dPos As Double
        Dim nVelocity As Integer

        Try
            dPos = CDbl(txtPosition.Text)
            nVelocity = CInt(txtVelocity.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'btnXmove.Enabled = False
        'btnYmove.Enabled = False
        'btnZmove.Enabled = False

        Theta4Move(dPos, nVelocity)

        btnXmove.Enabled = True
        btnYmove.Enabled = True
        btnZmove.Enabled = True
    End Sub

    
End Class