
Imports System.Threading
Imports System.IO

Public Class frmMotionControl


    Dim fMain As frmMain

    Public ExitSW As Boolean = True
    Dim trdMonitor As Thread

#Region "Creator, Dispose and Init"


    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        fMain = main
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False

        Init()

        fMain.cMotion.Settings = g_ConfigInfos.MotionConfig
        trdMonitor = New Thread(AddressOf PoisionDisplay)
        trdMonitor.Start()
    End Sub
    Public Sub Init()

        cbo_axiscount.SelectedIndex = 2
        cbo_pulsemethod.SelectedIndex = 4
        cbo_encodermethod.SelectedIndex = 3

    End Sub
#End Region

#Region "Controls Event Handler Functions"

    Private Sub btn_Initialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Initialize.Click
        Motion_Board_Init()
    End Sub

    Private Sub btn_ServoOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ServoOn.Click
        Dim rebyte As Byte
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If
        '모션 Servo On
        fMain.cMotion.SERVO_ON()
        'CFS20endlink(1)
        'fMain.cMotion.Link()


    End Sub

    Private Sub btn_ServoOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ServoOff.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Servo Off
        fMain.cMotion.SERVO_OFF()

        ' fMain.cMotion.EndLink()
    End Sub

    Private Sub btn_Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Homing.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Homeing , 설정 된 축 모두 적용
        fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING)

        'Z축을 올리고 이동
        'fMain.cMotion.ZMove(20, True)   'Z 축 상승
        'fMain.cMotion.ZMove(5000, True)
        'fMain.cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        fMain.cMotion.Homming()

        'fMain.cMotion.MoveCompletedAllAxis()
    End Sub




    Private Sub btn_JogXR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JogXR.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog X 축 오른쪽으로 이동
        fMain.cMotion.JogXRMove()
    End Sub

    Private Sub JogXL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JogXL.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog X 축 왼쪽으로 이동
        fMain.cMotion.JogXLMove()
    End Sub

    Private Sub btn_Yup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Yup.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog Y 축 위쪽으로 이동
        fMain.cMotion.JogYuPMove()
    End Sub

    Private Sub btn_YDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_YDown.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog Y 축 아래쪽으로 이동
        fMain.cMotion.JogYDownMove()
    End Sub

    Private Sub btn_Zup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Zup.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog Z 축 위쪽으로 이동
        fMain.cMotion.JogZUpMove()
    End Sub

    Private Sub btn_Zdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Zdown.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog Z 축 아래쪽으로 이동
        fMain.cMotion.JogZDownMove()
    End Sub

    Private Sub btn_XLYU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_XLYU.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog ,  X 축 Left & Y 축 Up
        fMain.cMotion.JogXLYUpMove()
    End Sub

    Private Sub btn_XRYU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_XRYU.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog ,  X 축 Right & Y 축 Up
        fMain.cMotion.JogXRYUpMove()
    End Sub

    Private Sub btn_XLYD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_XLYD.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog ,  X 축 Left & Y 축 Down
        fMain.cMotion.JogXLYDownMove()
    End Sub

    Private Sub btn_XRYD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_XRYD.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Jog ,  X 축 Right & Y 축 Down
        fMain.cMotion.JogXRYDownMove()
    End Sub

    Private Sub btn_Xmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Xmove.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 X 축 이동
        Dim tDistance As Double = -100 '움직일 거리
        Dim tABs As Boolean = False '상대 & 절대 좌표 선택 True : 절대 좌표 , False : 상대 좌표 , * 설정 값 없으면 False

        fMain.cMotion.AxisMove(0, tDistance, tABs)
    
        ' fMain.cMotion.XMove(tDistance, tABs)
    End Sub

    Private Sub btn_Ymove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ymove.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Y 축 이동
        Dim tDistance As Double = 100 '움직일 거리
        Dim tABs As Boolean = False '상대 & 절대 좌표 선택 True : 절대 좌표 , False : 상대 좌표 , * 설정 값 없으면 False

        fMain.cMotion.AxisMove(1, tDistance, tABs)
        '  fMain.cMotion.YMove(tDistance, tABs)
    End Sub

    Private Sub btn_Zmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Zmove.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Z 축 이동
        Dim tDistance As Double = 100 '움직일 거리
        Dim tABs As Boolean = False '상대 & 절대 좌표 선택 True : 절대 좌표 , False : 상대 좌표 , * 설정 값 없으면 False

        fMain.cMotion.AxisMove(2, tDistance, tABs)
        '  fMain.cMotion.ZMove(tDistance, tABs)
    End Sub


    Private Sub btn_allStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_allStop.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 정지
     fMain.cMotion.Set_Stop()
    End Sub

    Private Sub btn_emgallStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_emgallStop.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 EMG 정지
        fMain.cMotion.Set_EStop()
        'fMain.cMotion.emer()
    End Sub

    Private Sub btn_stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_stop.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 설정 축 Stop
        Dim nAxisNum As Integer = fMain.cMotion.Settings.Length

        fMain.cMotion.MoveCompletedAllAxis()
        'For i As Integer = 0 To nAxisNum - 1
        '    fMain.cMotion.Set_Stop(i)
        'Next

    End Sub

    Private Sub btn_SetPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SetPosition.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        Dim tPosition As String = "1,2,3" 'X축 위치 , Y축 위치, Z축 위치
        '모션 Position 설정 및 이동
        fMain.cMotion.SetPosition(tPosition)
    End Sub

    Private Sub btn_GetPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetPosition.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        Dim tPositionArr() As Double
        '모션 Position 좌표 읽기
        tPositionArr = fMain.cMotion.GetCommandPosition   'GetActualPosition()

    End Sub


    Private Sub set_maxspeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles set_maxspeed.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If
        '모션 Max Speed 설정 
        For i As Integer = 0 To fMain.cMotion.Settings.Length - 1
            fMain.cMotion.MaxSpeed(i) = 200
            'fMain.cMotion.setMaxSpeed()
        Next
      
    End Sub

    Private Sub btn_getLimitlv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getLimitlv.Click
        If fMain.cMotion.IsConnected = False Then
            MsgBox("No connection to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        Dim tLimitArr() As Integer
        '모션 Position 좌표 읽기
        'tLimitArr = fMain.cMotion.GetLimitLevel()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ExitSW = False
    End Sub

    Public bSetZAxis As Boolean
    Private Sub chkZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkZ.CheckedChanged

        If chkZ.Checked = True Then
            bSetZAxis = True    'Z축 움직임 가능

            btnLU.Enabled = False
            btnL.Enabled = False
            btnLD.Enabled = False

            btnRU.Enabled = False
            btnR.Enabled = False
            btnRD.Enabled = False
        Else
            bSetZAxis = False    'Z축 움직임 불가능

            btnLU.Enabled = True
            btnL.Enabled = True
            btnLD.Enabled = True

            btnRU.Enabled = True
            btnR.Enabled = True
            btnRD.Enabled = True
        End If
    End Sub

    Private Sub btnXmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXmove.Click

        Dim dist As Double


        btnXmove.Enabled = False
        dist = CDbl(txtPosition.Text)

        ' fMain.cMotion.AxisMove(1, dist, rbAbs.Checked)
        fMain.cMotion.XMove(dist, rbAbs.Checked)
        btnXmove.Enabled = True
    End Sub

    Private Sub btnYmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYmove.Click


        Dim dDist As Double = CDbl(txtPosition.Text)
        btnYmove.Enabled = False
        ' fMain.cMotion.AxisMove(2, rbAbs.Checked)
        fMain.cMotion.YMove(dDist, rbAbs.Checked)
        btnYmove.Enabled = True
    End Sub

    Private Sub btnZmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZmove.Click



        btnZmove.Enabled = False
        Dim dDist As Double = CDbl(txtPosition.Text)
        'fMain.cMotion.AxisMove(4, rbAbs.Checked)
        fMain.cMotion.ZMove(dDist, rbAbs.Checked)
        btnZmove.Enabled = True

    End Sub
    Private Sub btnR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseUp, btnUP.MouseUp, btnDown.MouseUp, btnL.MouseUp, _
btnLU.MouseUp, btnRU.MouseUp, btnLD.MouseUp, btnRD.MouseUp
        fMain.cMotion.Set_EStop()
    End Sub
    'X Jog Move  ///////////////////////////////////////////////
    Private Sub btnR_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseDown

        Dim dDist As Double = txtPosition.Text

        If rbMicroAdjust.Checked = False Then
            fMain.cMotion.JogXRMove()
        Else
            fMain.cMotion.AxisMove(0, dDist, rbAbs.Checked)
            ' fMain.cMotion.XMove(dDist, rbAbs.Checked)
        End If

    End Sub

    Private Sub btnL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnL.MouseDown

        Dim dDist As Double = txtPosition.Text

        If rbMicroAdjust.Checked = False Then
            fMain.cMotion.JogXLMove()
        Else
            fMain.cMotion.AxisMove(0, dDist, rbAbs.Checked)
            ' fMain.cMotion.XMove(dDist, rbAbs.Checked)
        End If

    End Sub

    'Y,Z Jog Move ///////////////////////////////////////////////
    Private Sub btnUP_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUP.MouseDown
        Dim dDist As Double = CDbl(txtPosition.Text)


        If chkZ.Checked = False Then    'Y축 이동

            If rbMicroAdjust.Checked = False Then
                fMain.cMotion.JogYuPMove()
            Else
                fMain.cMotion.AxisMove(1, rbAbs.Checked)
                ' fMain.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        Else    'Z축 이동

            If rbMicroAdjust.Checked = False Then
                fMain.cMotion.JogZUpMove()
            Else
                fMain.cMotion.AxisMove(2, rbAbs.Checked)
                '   fMain.cMotion.ZMove(dDist, rbAbs.Checked)
            End If

        End If
    End Sub

    Private Sub btnDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDown.MouseDown

        Dim dDist As Double = CDbl(txtPosition.Text)


        If chkZ.Checked = False Then    'Y축 이동

            If rbMicroAdjust.Checked = False Then
                fMain.cMotion.JogYDownMove()
            Else
                fMain.cMotion.AxisMove(1, rbAbs.Checked)
                '   fMain.cMotion.YMove(dDist, rbAbs.Checked)
            End If

        Else    'Z축 이동

            If rbMicroAdjust.Checked = False Then
                fMain.cMotion.JogZDownMove()
            Else
                fMain.cMotion.AxisMove(2, rbAbs.Checked)
                '  fMain.cMotion.ZMove(dDist, rbAbs.Checked)
            End If

        End If
    End Sub
    Private Sub btnLU_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLU.MouseDown


        fMain.cMotion.JogXLYUpMove()

    End Sub
    Private Sub btnRU_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRU.MouseDown

        fMain.cMotion.JogXRYUpMove()
    End Sub
    Private Sub btnLD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLD.MouseDown

        fMain.cMotion.JogXLYDownMove()
    End Sub

    Private Sub btnRD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRD.MouseDown

        fMain.cMotion.JogXRYDownMove()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        fMain.cMotion.Set_Stop()
    End Sub

    Private Sub txt_xspeed_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_speed.DoubleClick
        txt_speed.Enabled = True
    End Sub

  

#End Region

#Region "Functions"

    Public Sub Motion_Board_Init()
        '모션 초기화
        With fMain.cMotion

            ' .InitializeMotion(g_ConfigInfos.MotionConfig)

            .InitAxt()
            .initMotion()  '펄스 출력 방식, 엔코더 입력 방식 설정
            .InitVariableSet()  'Unit/Pulse, Init Speed 설정

            ' IO_StateCheck()
        End With

        If fMain.cMotion.IsConnected = True Then

            MsgBox("Connection successful")
        Else
            MsgBox("Connection Failure")
        End If

    End Sub


    Public Sub IO_StateCheck()
        Dim retbyte As Byte
        Dim cnt_axis As Integer = cbo_axiscount.SelectedIndex

        'I/O Limit(+)(-)
        retbyte = CFS20get_pend_limit_level(cnt_axis)
        If CInt(retbyte) = 0 Then
            chkSpeedLimit_Plus.Checked = False
        Else
            chkSpeedLimit_Plus.Checked = True
        End If

        retbyte = CFS20get_nend_limit_level(cnt_axis)
        If CInt(retbyte) = 0 Then
            chkSpeedLimit_Minus.Checked = False
        Else
            chkSpeedLimit_Minus.Checked = True
        End If

        'I/O Slow Limit(+)(-) 
        retbyte = CFS20get_pslow_limit_level(cnt_axis)
        If CInt(retbyte) = 0 Then
            chkSlowLimit_Plus.Checked = False
        Else
            chkSlowLimit_Plus.Checked = True
        End If

        retbyte = CFS20get_nslow_limit_level(cnt_axis)
        If CInt(retbyte) = 0 Then
            chkSlowLimit_Minus.Checked = False
        Else
            chkSlowLimit_Minus.Checked = True
        End If

        'I/O Alarm
        retbyte = CFS20get_alarm_level(cnt_axis)
        If CInt(retbyte) = 0 Then
            chkAlarm.Checked = False
        Else
            chkAlarm.Checked = True
        End If
    End Sub

    Public Sub PoisionDisplay()
        Do While ExitSW
            Application.DoEvents()

            If fMain.cMotion.IsConnected = True Then

                Dim tPositionArr() As Double
                tPositionArr = fMain.cMotion.GetCommandPosition()   'GetActualPosition() 'GetCommandPosition()

                Try

                    If tPositionArr Is Nothing Then
                        lbl_AxisX.Text = "0.00"
                        lbl_AxisY.Text = "0.00"
                        lbl_AxisZ.Text = "0.00"
                        lbl_AxisTheta.Text = "0.00"
                    Else

                        For Cnt As Integer = 0 To tPositionArr.Length - 1

                            If Cnt = 1 Then
                                lbl_AxisX.Text = Format(tPositionArr(Cnt), "0.00")
                            ElseIf Cnt = 2 Then
                                lbl_AxisY.Text = Format(tPositionArr(Cnt), "0.00")
                            ElseIf Cnt = 4 Then
                                lbl_AxisZ.Text = Format(tPositionArr(Cnt), "0.00")
                            ElseIf Cnt = 5 Then
                                lbl_AxisTheta.Text = Format(tPositionArr(Cnt), "0.00")
                            End If
                        Next

                    End If
                Catch ex As Exception

                End Try


            End If

            Thread.Sleep(200)

        Loop
    End Sub

#End Region


   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'fMain.cMotion.TestFunc()
    End Sub


    Private Sub cbo_axiscount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_axiscount.SelectedIndexChanged

        Dim selIdx As Integer = cbo_axiscount.SelectedIndex

        If cbo_axiscount.SelectedIndex < 0 Then Exit Sub
        If fMain.cMotion Is Nothing Then Exit Sub
        If fMain.cMotion.Settings Is Nothing Then Exit Sub

        'cbo_pulsemethod.SelectedIndex = fMain.cMotion.Settings(selIdx).ePulseOutMethod
        'cbo_encodermethod.SelectedIndex = fMain.cMotion.Settings(selIdx).eEncInputMethod
        'txt_accel.Text = fMain.cMotion.Settings(selIdx).dAcceleration
        'txt_velocity.Text = fMain.cMotion.Settings(selIdx).dVelocity
        'txt_decel.Text = fMain.cMotion.Settings(selIdx).dDeceleration

        'txt_pulse.Text = fMain.cMotion.Settings(selIdx).dUnitPulse
        'txt_speed.Text = fMain.cMotion.Settings(selIdx).dInitSpeed

        IO_StateCheck()

    End Sub

  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CFS20start_move_2(1, 1000, 1000)
    End Sub


    Private Sub chkSpeedLimit_Plus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSpeedLimit_Plus.CheckedChanged
        If chkSpeedLimit_Plus.Checked = True Then
            CFS20set_pend_limit_level(cbo_axiscount.SelectedIndex, CByte(1))
            lblIO_Limit_P.BackColor = Color.Red
        Else
            CFS20set_pend_limit_level(cbo_axiscount.SelectedIndex, CByte(0))
            lblIO_Limit_P.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub chkSpeedLimit_Minus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSpeedLimit_Minus.CheckedChanged
        If chkSpeedLimit_Minus.Checked = True Then
            CFS20set_nend_limit_level(cbo_axiscount.SelectedIndex, CByte(1))
            lblIO_Limit_M.BackColor = Color.Red
        Else
            CFS20set_nend_limit_level(cbo_axiscount.SelectedIndex, CByte(0))
            lblIO_Limit_M.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub chkAlarm_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAlarm.CheckedChanged
        If chkAlarm.Checked = True Then
            CFS20set_alarm_level(cbo_axiscount.SelectedIndex, CByte(1))
            lblIO_Alarm.BackColor = Color.Red
        Else
            CFS20set_alarm_level(cbo_axiscount.SelectedIndex, CByte(0))
            lblIO_Alarm.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub chkSlowLimit_Plus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSlowLimit_Plus.CheckedChanged
        If chkSlowLimit_Plus.Checked = True Then
            CFS20set_pslow_limit_level(cbo_axiscount.SelectedIndex, CByte(1))
            lblIO_SLimit_P.BackColor = Color.Red
        Else
            CFS20set_pslow_limit_level(cbo_axiscount.SelectedIndex, CByte(0))
            lblIO_SLimit_P.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub chkSlowLimit_Minus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSlowLimit_Minus.CheckedChanged
        If chkSlowLimit_Minus.Checked = True Then
            CFS20set_nslow_limit_level(cbo_axiscount.SelectedIndex, CByte(1))
            lblIO_SLimit_M.BackColor = Color.Red
        Else
            CFS20set_nslow_limit_level(cbo_axiscount.SelectedIndex, CByte(0))
            lblIO_SLimit_M.BackColor = Color.Gainsboro
        End If
    End Sub



  
End Class
