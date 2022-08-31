Imports System.Threading
Imports System.IO
Imports System.Xml


Public Class frmMotionUI

#Region "Define"

    Dim myParent As frmMain


    Dim m_nMaxCh As Integer
    Dim m_bEnableDispUpdate As Boolean = False
    Dim g_MotionMode As eMotionMode
    Dim m_bIsLoaded As Boolean = False
    Dim m_bIsFrameShow As Boolean = False
    Dim m_ACFComponent As eACFComponent
    Dim m_bACFMeas As Boolean = False
    Dim m_bJOGMode As Boolean = False
    Dim m_saveInfo As CMcFile.sFILENAME = Nothing
    Dim m_MCRCnt As Integer

    Dim ucDispSrcCtrl As ucKeithleyOrM6000AndSW7000Manual

    Public Enum eMotionMode
        eCCD
        eSpectrometer
        eMCR
    End Enum

    Public Enum eACFComponent
        eM6000
        eKeithley
    End Enum

#End Region

#Region "Delegate"

    Private Delegate Sub DelCallSub()

    Private Delegate Function DelPanelControl() As Windows.Forms.Panel
    Private Delegate Function DelPictureBox() As Windows.Forms.PictureBox
    Private Delegate Sub DelPBControl(ByVal picture As Windows.Forms.PictureBox)
    Private Delegate Sub DelPBControl_Image(ByVal image As Image)
    Private Delegate Function AnalysisImage(ByRef grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData, ByRef procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData) As Boolean

    Private Delegate Sub DelSetBool(ByVal trueOrFalse As Boolean)
    Private Delegate Sub DelSetButtonString(ByVal ctrl As Windows.Forms.Button, ByVal str As String)
    Private Delegate Sub DelSetColor(ByVal ctrl As Windows.Forms.Button, ByVal col As Color)
    Private Delegate Sub DelSetString(ByVal str As String)

    Private Sub ClearListACFInfo()
        If listACFInfo.InvokeRequired = True Then
            Dim del As DelCallSub = New DelCallSub(AddressOf ClearListACFInfo)
            Invoke(del)
        Else
            listACFInfo.Items.Clear()
        End If
    End Sub

    'frmMotionUI.gbMotion.Enabled = True
    '  frmMotionUI.gbSourceCtrl.Enabled = True
    '  frmMotionUI.gbACFCameraCtrl.Enabled = True
    '  frmMotionUI.gbACFCtrl.Enabled = True
    'Public Sub SubControlHide()
    '    frmManualMeasCA310Wind.Hide()
    '    frmSrcCtrlWind.Hide()
    'End Sub

    Public Sub Enable_gbStrobe(ByVal trueOrFalse As Boolean)
    End Sub
    Public Sub SetAperture()
        Try

            If GroupBox2.InvokeRequired = True Then
                Dim Del2 As DelSetBool = New DelSetBool(AddressOf SetAperture)
                Invoke(Del2)
            Else
                '  btnThetaMove.Visible = trueOrFalse
                ucDispSrcCtrl.cbAperture.Items.Clear()
                For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList.Length - 1
                    ucDispSrcCtrl.cbAperture.Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList(i).sApertureName)
                Next
                ucDispSrcCtrl.cbAperture.SelectedIndex = 0
            End If
        Catch ex As Exception
            ucDispSrcCtrl.cbAperture.SelectedIndex = 0
        End Try
    End Sub

    Public Sub Enable_gbMotion(ByVal trueOrFalse As Boolean)
        If gbMotion.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbMotion)
            Invoke(Del2, trueOrFalse)
        Else
            gbMotion.Enabled = trueOrFalse
            '  btnThetaMove.Visible = trueOrFalse
            btnL.Enabled = trueOrFalse
        End If
    End Sub

    Public Sub Enable_btnThetaHomming(ByVal trueOfFalse As Boolean)
        If Button6.InvokeRequired = True Then
            Dim del2 As DelSetBool = New DelSetBool(AddressOf Enable_btnThetaHomming)
            Invoke(del2, trueOfFalse)
        Else
            Button6.Enabled = trueOfFalse

        End If
    End Sub

    Public Sub Enable_gbSourceCtrl(ByVal trueOrFalse As Boolean)
        If ucDispSrcCtrl.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbSourceCtrl)
            Invoke(Del2, trueOrFalse)
        Else
            ' gbSourceCtrl.Enabled = trueOrFalse
            ucDispSrcCtrl.Enabled = trueOrFalse
        End If
    End Sub

    Public Sub Enable_gbACFCameraCtrl(ByVal trueOrFalse As Boolean)
        If gbACFCameraCtrl.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbACFCameraCtrl)
            Invoke(Del2, trueOrFalse)
        Else
            gbACFCameraCtrl.Enabled = trueOrFalse
        End If
    End Sub

    Public Sub Enable_gbACFMeas(ByVal trueOrFalse As Boolean)
        If gbACFMeas.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbACFMeas)
            Invoke(Del2, trueOrFalse)
        Else
            gbACFMeas.Enabled = trueOrFalse
        End If
    End Sub

    Public Sub Enable_gbACFCtrl(ByVal trueOrFalse As Boolean)
        If gbACFCtrl.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbACFCtrl)
            Invoke(Del2, trueOrFalse)
        Else
            gbACFCtrl.Enabled = trueOrFalse
        End If
    End Sub

    Public Sub SetButtonText(ByVal ctrl As Windows.Forms.Button, ByVal str As String)
        If ctrl.InvokeRequired = True Then
            Dim Del2 As DelSetButtonString = New DelSetButtonString(AddressOf SetButtonText)
            Invoke(Del2, New Object() {ctrl, str})
        Else
            ctrl.Text = str
        End If
    End Sub

    Public Sub SetButtonColor(ByVal ctrl As Windows.Forms.Button, ByVal colors As Color)
        If ctrl.InvokeRequired = True Then
            Dim Del2 As DelSetColor = New DelSetColor(AddressOf SetButtonColor)
            Invoke(Del2, New Object() {ctrl, colors})
        Else
            ctrl.BackColor = colors
        End If
    End Sub


    Public Sub ShowFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf ShowFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            Try
                Me.Show()


                If myParent.cPLC Is Nothing = False Then
                    StartThread()
                End If

                ' ''If g_SystemInfo.isConnected = True Then    '추가 부분
                ' ''    If JogMode = True Then
                ' ''        btnJOGMode_ON.BackColor = Color.OrangeRed
                ' ''    Else
                ' ''        btnJOGMode_OFF.BackColor = Color.OrangeRed
                ' ''    End If
                ' ''End If


                If myParent.cVision Is Nothing = False Then
                    If myParent.cVision.myVisionCamera.IsConnectedToCamera = True Then
                        Thread.Sleep(200)
                        myParent.cVision.myVisionCamera.GrabDisplay()
                        Thread.Sleep(200)
                        'Application.DoEvents()
                        'Thread.Sleep(100)
                        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess

                    End If
                End If

                m_bIsFrameShow = True

                ' If myParent.cMatrixReader Is Nothing = False Then
                'LiveOn()
                '  End If


            Catch w As System.ComponentModel.Win32Exception

                Console.WriteLine(w.Message)
                Console.WriteLine(w.ErrorCode.ToString())
                Console.WriteLine(w.NativeErrorCode.ToString())
                Console.WriteLine(w.StackTrace)
                Console.WriteLine(w.Source)
                Dim e As New Exception()
                e = w.GetBaseException()
                Console.WriteLine(e.Message)
            End Try


        End If
    End Sub

    Public Sub HideFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf HideFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            Me.Hide()
            StopThread()
            m_bIsFrameShow = False

            If myParent.cVision Is Nothing = False Then
                myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode

            End If

            '  If myParent.cMatrixReader Is Nothing = False Then
            'LiveOff()
            ' End If

        End If
    End Sub

    Public Function GrabImgPanel() As Windows.Forms.Panel
        Return pnDispGrabImg
    End Function

    'Public Function GrabImgPanel() As Windows.Forms.PictureBox
    '    Return pbDispGrabImg
    'End Function
    Public Property JogMode As Boolean
        Get
            Return m_bJOGMode
        End Get
        Set(value As Boolean)
            m_bJOGMode = value
        End Set
    End Property

    Public ReadOnly Property ACFMeas As Boolean
        Get
            Return m_bACFMeas
        End Get
    End Property


    'Public Function GrabImgPictureBox() As Windows.Forms.PictureBox
    '    Return pbGrabImg
    'End Function

    'Public Function GrabPictureBox() As Windows.Forms.PictureBox
    '    Return PictureBox1
    'End Function

#End Region


#Region "Strobe Control"

    Public Sub PictureBox(ByVal image As Image)
    End Sub

    Public Function OnOffTrigger(ByVal sResult As String) As Boolean
        Return True
    End Function


    Public Sub TextString(ByVal str As String)
    End Sub

    Private Sub btnTriggerOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btnVCRClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
#End Region


#Region "Creator & Init"

    Public Sub New(ByVal maxCh As Integer, ByVal parent As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
        m_nMaxCh = maxCh
        init()
    End Sub

    Private Sub init()

        btnL.Dock = DockStyle.Fill
        btnLD.Dock = DockStyle.Fill
        btnLU.Dock = DockStyle.Fill
        btnR.Dock = DockStyle.Fill
        btnRD.Dock = DockStyle.Fill
        btnRU.Dock = DockStyle.Fill
        btnDown.Dock = DockStyle.Fill
        btnUP.Dock = DockStyle.Fill
        btnStop.Dock = DockStyle.Fill

        tlpJOG.Dock = DockStyle.Fill

        pnDispGrabImg.Dock = DockStyle.Fill

        ReDim g_motionPosSpectrometer(m_nMaxCh - 1)
        ReDim g_motionPosCCD(m_nMaxCh - 1)
        ReDim g_motionPosMCR(m_nMaxCh - 1)

        g_MotionMode = eMotionMode.eSpectrometer

        ucMotionIndicator.Channel = "HOME"
        ucMotionIndicator.OpticalHeaderPos = "Spectrometer"

        If LoadMotionPosSpectrometer() = False Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eDEV_MOTION_CHECK_POSITION_DATA_SPECTROMETER)
        End If

        If LoadMotionPosCCD() = False Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eDEV_MOTION_CHECK_POSITION_DATA_CCD)
        End If

        'If LoadMotionPosMCR() = False Then
        '    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eDEV_MOTION_CHECK_POSITION_DATA_MCR)
        'End If

        With cbChannel
            .Items.Clear()
            Dim sJIGName As String = Nothing

            For i As Integer = 0 To m_nMaxCh - 1
                If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                    sJIGName = Format(i + 1, "00")
                ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                    sJIGName = ucDispJIG.convertIncNumberToMatrixValue(i)
                End If

                ' sJIGName = ucDispJIG.convertIncNumberToMatrixValue(i) ' Format(i + 1, "00")
                .Items.Add(Format("TEG" & sJIGName))
            Next
            .SelectedIndex = 0


            'dispCh.ChannelNo = targetCh
            'dispCh.DispType = g_SystemOptions.sOptionData.DispGroup.ChDispType

            'ucDispJIG.convertIncNumberToMatrixValue(targetCh)

            'strMsg = "[TEG " & dispCh.DispChannel & "] " & strMsg 'ucDispJIG.convertIncNumberToMatrixValue(dispCh.DispChannel - 1) & "] " & strMsg


        End With

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eCamera Then

                Dim dispPanel As DelPanelControl
                dispPanel = New DelPanelControl(AddressOf GrabImgPanel)

                '    Dim dispPanel As DelPBControl
                '  dispPanel = New DelPBControl(AddressOf GrabImgPictureBox)
                myParent.cVision = New CDevVisionCameraAPI(CDevVisionCameraCommonNode.eModel._SVSCamera, dispPanel.Invoke, pnDispProcImage)

                '   myParent.cVision.SampleType = ucDispRcpCommon.eSampleType.eModule
            End If
        Next

        Display()

    End Sub


#End Region

    Public Sub Display()
        Dim nSourceComponent As ucKeithleyOrM6000AndSW7000Manual.eManualSourceComponent

        'If g_ConfigInfos.MotionConfig.Length > 3 Then
        '    btnThetaMove.Enabled = True
        '    chkZAndTheta.Text = "Z & Ɵ Axis"
        '    ucMotionIndicator.Label1.Visible = True
        '    ucMotionIndicator.Label5.Visible = True
        '    ucMotionIndicator.tbAnglePos.Visible = True
        'End If


        If myParent.cIVLSMU Is Nothing = False Then
            nSourceComponent = ucKeithleyOrM6000AndSW7000Manual.eManualSourceComponent.eKeithley
        ElseIf myParent.cM6000 Is Nothing = False Then
            nSourceComponent = ucKeithleyOrM6000AndSW7000Manual.eManualSourceComponent.eM6000
        ElseIf myParent.cIVLSMU Is Nothing = False And myParent.cM6000 Is Nothing = False Then
            nSourceComponent = ucKeithleyOrM6000AndSW7000Manual.eManualSourceComponent.eM6000AndKeithley
        End If

        nSourceComponent = ucKeithleyOrM6000AndSW7000Manual.eManualSourceComponent.eKeithley
        ucDispSrcCtrl = New ucKeithleyOrM6000AndSW7000Manual(myParent, nSourceComponent)

        If myParent.cVision Is Nothing = False Then
            initListACFInfo()
            ucDispSrcCtrl.Location = New System.Drawing.Point(gbMotion.Size.Width + gbMotion.Location.X + 10, TableLayoutPanel1.Size.Height + TableLayoutPanel1.Location.Y)

            For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                    m_ACFComponent = eACFComponent.eKeithley
                    Exit For
                ElseIf g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_M6000 Then
                    m_ACFComponent = eACFComponent.eM6000
                    If i = g_ConfigInfos.nDevice.Length - 1 Then
                        Exit For
                    End If
                   
                End If
            Next
            m_ACFComponent = eACFComponent.eKeithley


            'ucDispSrcCtrl.gbFreeRun.Size = New System.Drawing.Point(ucDispSrcCtrl.gbFreeRun.Size.Width + ucDispSrcCtrl.gbMeasData.Size.Width - ucDispSrcCtrl.ucKeithleySMUSettings.Size.Width - 50, ucDispSrcCtrl.gbFreeRun.Size.Height - ucDispSrcCtrl.gbMeasData.Size.Height + 10)
            'ucDispSrcCtrl.gbMeasData.Location = New System.Drawing.Point(ucDispSrcCtrl.gbSrcControl.Size.Width + ucDispSrcCtrl.gbSrcControl.Location.X + 10, ucDispSrcCtrl.gbSrcControl.Location.Y)

            'ucDispSrcCtrl.gbMeasData.Size = New Drawing.Size(ucDispSrcCtrl.ucMeasDataListview.Size.Width + 30 - ucDispSrcCtrl.ucKeithleySMUSettings.Size.Width, ucDispSrcCtrl.ucMeasDataListview.Height + 20)

            ucDispSrcCtrl.gbFreeRun.Size = New System.Drawing.Point(ucDispSrcCtrl.gbFreeRun.Size.Width + ucDispSrcCtrl.gbMeasData.Size.Width, ucDispSrcCtrl.gbFreeRun.Size.Height + 10)
            ucDispSrcCtrl.gbMeasData.Location = New System.Drawing.Point(ucDispSrcCtrl.gbSrcControl.Size.Width + ucDispSrcCtrl.gbSrcControl.Location.X + 10, ucDispSrcCtrl.gbSrcControl.Location.Y)

            ucDispSrcCtrl.gbMeasData.Size = New Drawing.Size(ucDispSrcCtrl.ucMeasDataListview.Size.Width + 70, ucDispSrcCtrl.ucMeasDataListview.Height + 150)

            ' ucDispSrcCtrl.ucKeithleySMUSettings.Location = New System.Drawing.Point(ucDispSrcCtrl.gbMeasData.Location.X + ucDispSrcCtrl.gbMeasData.Size.Width + 10, ucDispSrcCtrl.gbSrcControl.Location.Y)

        Else
            ucDispSrcCtrl.Location = New System.Drawing.Point(gbMotion.Size.Width + gbMotion.Location.X + 10, gbMotion.Location.Y)

            TableLayoutPanel1.Visible = False
            cbChangePosition.Visible = False
            gbMotion.Size = New Drawing.Size(gbMotion.Size.Width, gbMotion.Size.Height - cbChangePosition.Height)

        End If

        Me.Controls.Add(ucDispSrcCtrl)

        btnMove.Visible = g_SystemOptions.sOptionData.VisibleDisplay.bChannelMoveButton 'sOption.VisibleDisplay.bChannelMoveButton
        ucDispSrcCtrl.btnMotionMove.Visible = g_SystemOptions.sOptionData.VisibleDisplay.bAngleMoveButton 'sOption.VisibleDisplay.bAngleMoveButton\

    End Sub

    Public Sub ManualDeviceOption(ByVal sDeviceOption As frmMain.sDeviceOptions)
        ucDispSrcCtrl.DeviceOption = sDeviceOption
    End Sub

#Region "Motion Controls Event Handler Functions"

    Private Sub btn_ServoOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ServoOn.Click
        If myParent.cMotion.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        '모션 Servo On
        myParent.cMotion.SERVO_ON()
        gbManualCtrl.Enabled = True
        gbJOG.Enabled = True
        ' ControlEnable(True)

    End Sub

    Private Sub btn_ServoOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ServoOff.Click
        If myParent.cMotion.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        '모션 Servo Off
        myParent.cMotion.SERVO_OFF()
        gbManualCtrl.Enabled = False
        gbJOG.Enabled = False
        'ControlEnable(False)
    End Sub

    Private Sub btn_Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Homing.Click
        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        btn_Homing.Enabled = False
        ControlEnable(False)

        ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

        '모션 Homeing , 설정 된 축 모두 적용
        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING)

        XMove(0, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Application.DoEvents()
        Thread.Sleep(500)

        YMove(0, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Application.DoEvents()
        Thread.Sleep(500)

        ZMove(0, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Application.DoEvents()
        Thread.Sleep(500)


        'MoveCompletedAllAxis()

        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING_END)

        btn_Homing.Enabled = True
        ControlEnable(True)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        StopThread()
    End Sub

    Public bSetZAxis As Boolean

    Private Sub chkZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTheta1.CheckedChanged

        If chkTheta1.Checked = True Then
            bSetZAxis = True    'Z축 움직임 가능

            btnL.Enabled = False
            btnLU.Enabled = False
            btnLD.Enabled = False
            btnR.Enabled = False
            btnRU.Enabled = False
            btnRD.Enabled = False

            btnDown.Enabled = True
            btnUP.Enabled = True
        Else
            bSetZAxis = False    'Z축 움직임 불가능

            btnL.Enabled = True
            btnLU.Enabled = True
            btnLD.Enabled = True
            btnR.Enabled = True
            btnRU.Enabled = True
            btnRD.Enabled = True

        End If
    End Sub

    Private Sub btnXmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXmove.Click
        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        Dim dist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        ControlEnable(False)

        If rbAbs.Checked = True Then
            XMove(dist, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Else
            XMove(dist, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        End If
        'myParent.cMotion.AxisMove(0, dist, rbAbs.Checked)

        '  myParent.cMotion.XMove(dist, rbAbs.Checked)
        ControlEnable(True)

    End Sub

    Private Sub btnYmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYmove.Click

        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        ControlEnable(False)

        If rbAbs.Checked = True Then
            YMove(dDist, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Else
            YMove(dDist, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        End If
        'If g_ConfigInfos.MotionConfig(1).bDirectionInverting = False Then
        '    dDist = dDist * -1
        'End If
        '  myParent.cMotion.AxisMove(1, dDist, rbAbs.Checked)
        '  myParent.cMotion.YMove(dDist, rbAbs.Checked)
        ControlEnable(True)
    End Sub

    Private Sub btnZmove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZmove.Click
        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        ControlEnable(False)

        If rbAbs.Checked = True Then
            ZMove(dDist, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Else
            ZMove(dDist, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        End If

        'myParent.cMotion.AxisMove(2, dDist, rbAbs.Checked)
        'myParent.cMotion.ZMove(dDist, rbAbs.Checked)
        ControlEnable(True)
    End Sub

    Private Sub btnThetaMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThetaMove.Click
        ''If myParent.cPLC.IsConnected = False Then
        ''    MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
        ''    Exit Sub
        ''End If

        ''Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        ''ControlEnable(False)
        ''myParent.cMotion.ViewAngleMove(dDist, rbAbs.Checked)
        ''ControlEnable(True)
        'If myParent.cPLC.IsConnected = False Then
        '    MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
        '    Exit Sub
        'End If

        'Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        'ControlEnable(False)

        'If rbAbs.Checked = True Then
        '    Theta1Move(dDist, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Else
        '    Theta1Move(dDist, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        'End If

        ''myParent.cMotion.AxisMove(2, dDist, rbAbs.Checked)
        ''myParent.cMotion.ZMove(dDist, rbAbs.Checked)
        'ControlEnable(True)
    End Sub

#Region "JOG Control"

    Private Sub btnR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseUp, btnUP.MouseUp, btnDown.MouseUp, btnL.MouseUp
        If JogMode = True Then
            SetStop()
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub
    'X Jog Move  ///////////////////////////////////////////////
    Private Sub btnR_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseDown
        If JogMode = True Then
            Dim reqInfo As CDevPLCCommonNode.sRequestInfo

            If chkTheta1.Checked = True Then   'X 축 이동

                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_DownMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(2).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)
            ElseIf chkTheta2.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(3).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)
            ElseIf chkTheta3.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(4).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)
            ElseIf chkTheta4.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(5).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)
            Else

                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(0).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)

                ''Theta 축 이동 ,Theta축 없어서 구현안함
                'If rbMicroAdjust.Checked = False Then
                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                '    '   reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Theta_RMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                '    reqInfo.Param = Nothing
                '    myParent.cPLC.Request(reqInfo)
                'Else
                '    Dim dDist As Double
                '    Try
                '        dDist = txtPosition.Text
                '    Catch ex As Exception
                '        MsgBox("입력 값이 잘못 되었습니다.")
                '        Exit Sub
                '    End Try
                '    dDist = Math.Abs(dDist)
                '    ' ThetaMove(dDist, g_ConfigInfos.MotionConfig(3).dVelocity, rbAbs.Checked)
                'End If

            End If
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub

    Private Sub btnL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnL.MouseDown

        If JogMode = True Then
            Dim reqInfo As CDevPLCCommonNode.sRequestInfo
            If chkTheta1.Checked = True Then   'Y 축 이동

                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta1_UpMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(2).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)

            ElseIf chkTheta2.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta2_UpMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(3).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)

            ElseIf chkTheta3.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta3_UpMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(4).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)

            ElseIf chkTheta4.Checked = True Then
                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Jog_Theta4_UpMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(5).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)
            Else

                reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Y_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                reqInfo.Param = Nothing
                ReDim reqInfo.Param(0)
                reqInfo.Param(0) = g_ConfigInfos.MotionConfig(0).dVelocity * 1000
                myParent.cPLC.Request(reqInfo)

                'Theta 축 이동 (Theta축 없어서 구현안됨)
                'If rbMicroAdjust.Checked = False Then
                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Theta_RMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
                '    reqInfo.Param = Nothing
                '    myParent.cPLC.Request(reqInfo)
                'Else
                '    Dim dDist As Double
                '    Try
                '        dDist = txtPosition.Text
                '    Catch ex As Exception
                '        MsgBox("입력 값이 잘못 되었습니다.")
                '        Exit Sub
                '    End Try
                '    dDist = Math.Abs(dDist) * -1
                '    ThetaMove(dDist, g_ConfigInfos.MotionConfig(3).dVelocity, rbAbs.Checked)
                'End If
            End If
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub

    'Y,Z Jog Move ///////////////////////////////////////////////
    Private Sub btnUP_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUP.MouseDown
        If JogMode = True Then
            Dim reqInfo As CDevPLCCommonNode.sRequestInfo

            ' If chkTheta1.Checked = False Then    'Y축 이동

            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = g_ConfigInfos.MotionConfig(1).dVelocity * 1000
            myParent.cPLC.Request(reqInfo)

            'Else    'Z축 이동

            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_UpMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = g_ConfigInfos.MotionConfig(2).dVelocity * 1000
            '    myParent.cPLC.Request(reqInfo)
            '    'myParent.cMotion.JogZUpMove()
            'End If
        Else
        MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub

    Private Sub btnDown_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDown.MouseDown
        If JogMode = True Then

            Dim reqInfo As CDevPLCCommonNode.sRequestInfo

            '   If chkTheta1.Checked = False Then    'Y축 이동

            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_DownMove ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = g_ConfigInfos.MotionConfig(1).dVelocity * 1000
            myParent.cPLC.Request(reqInfo)

            'Else    'Z축 이동

            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Z_DownMove  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = g_ConfigInfos.MotionConfig(2).dVelocity * 1000
            '    myParent.cPLC.Request(reqInfo)
            '    'myParent.cMotion.JogZUpMove()
            'End If
        Else
        MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub
    Private Sub btnLU_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLU.MouseDown
        If JogMode = True Then
            If g_ConfigInfos.MotionConfig(0).eMotionAxisInverting = g_ConfigInfos.MotionConfig(1).eMotionAxisInverting Then
                MsgBox("축 설정이 잘 못 되었습니다...")
                Exit Sub
            End If

            Select Case g_ConfigInfos.MotionConfig(0).eMotionAxisInverting
                Case CDevMotion_AJIN.eMotionAxis.eX_Axis
                    myParent.cMotion.JogXLYUpMove()
                Case CDevMotion_AJIN.eMotionAxis.eY_Axis
                    If g_ConfigInfos.MotionConfig(0).bDirectionInverting = True Then
                        myParent.cMotion.JogXRYUpMove()
                    Else
                        myParent.cMotion.JogXLYUpMove()
                    End If

            End Select
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
        '  myParent.cMotion.JogXLYUpMove()

    End Sub
    Private Sub btnRU_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRU.MouseDown
        If JogMode = True Then
            If g_ConfigInfos.MotionConfig(0).eMotionAxisInverting = g_ConfigInfos.MotionConfig(1).eMotionAxisInverting Then
                MsgBox("축 설정이 잘 못 되었습니다...")
                Exit Sub
            End If

            Select Case g_ConfigInfos.MotionConfig(0).eMotionAxisInverting
                Case CDevMotion_AJIN.eMotionAxis.eX_Axis
                    myParent.cMotion.JogXRYUpMove()
                Case CDevMotion_AJIN.eMotionAxis.eY_Axis
                    If g_ConfigInfos.MotionConfig(0).bDirectionInverting = True Then
                        myParent.cMotion.JogXRYDownMove()
                    Else
                        myParent.cMotion.JogXLYDownMove()
                    End If

            End Select
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
        '  myParent.cMotion.JogXRYUpMove()

    End Sub
    Private Sub btnLD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLD.MouseDown
        If JogMode = True Then
            If g_ConfigInfos.MotionConfig(0).eMotionAxisInverting = g_ConfigInfos.MotionConfig(1).eMotionAxisInverting Then
                MsgBox("축 설정이 잘 못 되었습니다...")
                Exit Sub
            End If

            Select Case g_ConfigInfos.MotionConfig(0).eMotionAxisInverting
                Case CDevMotion_AJIN.eMotionAxis.eX_Axis
                    myParent.cMotion.JogXLYDownMove()
                Case CDevMotion_AJIN.eMotionAxis.eY_Axis
                    If g_ConfigInfos.MotionConfig(0).bDirectionInverting = True Then
                        myParent.cMotion.JogXLYUpMove()
                    Else
                        myParent.cMotion.JogXRYUpMove()
                    End If

            End Select
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
        '  myParent.cMotion.JogXLYDownMove()
    End Sub

    Private Sub btnRD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRD.MouseDown
        If JogMode = True Then
            If g_ConfigInfos.MotionConfig(0).eMotionAxisInverting = g_ConfigInfos.MotionConfig(1).eMotionAxisInverting Then
                MsgBox("축 설정이 잘 못 되었습니다...")
                Exit Sub
            End If

            Select Case g_ConfigInfos.MotionConfig(0).eMotionAxisInverting
                Case CDevMotion_AJIN.eMotionAxis.eX_Axis
                    myParent.cMotion.JogXRYDownMove()
                Case CDevMotion_AJIN.eMotionAxis.eY_Axis
                    If g_ConfigInfos.MotionConfig(0).bDirectionInverting = True Then
                        myParent.cMotion.JogXLYDownMove()
                    Else
                        myParent.cMotion.JogXRYDownMove()
                    End If

            End Select
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
        '   myParent.cMotion.JogXRYDownMove()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If JogMode = True Then
            SetStop()
        Else
            MsgBox("JOG Mode를 ON 후 사용해 주십시오.")
        End If
    End Sub

#End Region
    Private Sub cbChangePosition_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChangePosition.CheckedChanged
        If myParent.cPLC.IsConnected = False Then
            MsgBox("PLC와 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Return
        End If

        ControlEnable(False)

        If g_MotionMode = eMotionMode.eSpectrometer Then
            Move_SetPos(cbChannel.SelectedIndex, eMotionMode.eCCD)
        ElseIf g_MotionMode = eMotionMode.eCCD Then
            Move_SetPos(cbChannel.SelectedIndex, eMotionMode.eSpectrometer)
        End If

        ControlEnable(True)
    End Sub

    Private Sub btnPositionSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPositionSave.Click
        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        Dim strFilePath As String = ""
        Dim nCh As Integer

        Try
            nCh = cbChannel.SelectedIndex
        Catch ex As Exception
            Exit Sub
        End Try

        If g_MotionMode = eMotionMode.eCCD Then
            strFilePath = g_sFilePath_MotionPosCCD
            g_motionPosCCD(cbChannel.SelectedIndex) = CStr(nCh) & "," & ucMotionIndicator.tbXPos.Text & "," & ucMotionIndicator.tbYPos.Text & "," & ucMotionIndicator.tbZPos.Text
        ElseIf g_MotionMode = eMotionMode.eSpectrometer Then
            strFilePath = g_sFilePath_MotionPosSpectrometer
            g_motionPosSpectrometer(cbChannel.SelectedIndex) = CStr(nCh) & "," & ucMotionIndicator.tbXPos.Text & "," & ucMotionIndicator.tbYPos.Text & "," & ucMotionIndicator.tbZPos.Text
        ElseIf g_MotionMode = eMotionMode.eMCR Then
            strFilePath = g_sFilePath_MotionPosMCR
            g_motionPosMCR(cbChannel.SelectedIndex) = CStr(nCh) & "," & ucMotionIndicator.tbXPos.Text & "," & ucMotionIndicator.tbYPos.Text & "," & ucMotionIndicator.tbZPos.Text
        End If

        'SaveMotionPosition(strFilePath, g_MotionMode)
        SavePosition(strFilePath, g_MotionMode, nCh)
    End Sub


    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If myParent.cPLC.IsConnected = False Then
            MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If

        Dim nCh As Integer

        Try
            nCh = cbChannel.SelectedIndex
        Catch ex As Exception
            MsgBox("채널을 선택하지 않았습니다.")
            Exit Sub
        End Try

        ControlEnable(False)

        'Z축을 올리고 이동
        'myParent.cMotion.ZMove(10, True)
        'myParent.cMotion.MoveCompletedAllAxis()
        '  ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

        If Move_SetPos_XYAxisMovingFirst(nCh, g_MotionMode, 0, 0) = False Then
            MsgBox("Check the motion position data")
        End If

        ControlEnable(True)
    End Sub

    Public Function Move_SetPos(ByVal in_CH As Integer, ByVal mode As eMotionMode) As Boolean

        ucMotionIndicator.OpticalHeaderPos = "Moving..."

        Thread.Sleep(200)

        If mode = eMotionMode.eSpectrometer Then
            If SetPosition(g_motionPosSpectrometer(in_CH)) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eSpectrometer
                ucMotionIndicator.OpticalHeaderPos = "Spectrometer"
            End If

        ElseIf mode = eMotionMode.eCCD Then
            If SetPosition(g_motionPosCCD(in_CH)) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                g_MotionMode = eMotionMode.eCCD
                Return False
            Else
                g_MotionMode = eMotionMode.eCCD
                ucMotionIndicator.OpticalHeaderPos = "CCD Camera"
            End If
        End If

        Dim sJIGName As String = Nothing

        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
            sJIGName = "[ CH" & Format(in_CH + 1, "00") & " ]"
        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
            sJIGName = "[ PANEL" & ucDispJIG.convertIncNumberToMatrixValue(in_CH) & " ]"
        End If

        ucMotionIndicator.Channel = sJIGName '"[ CH" & CStr(in_CH + 1) & " ]"

        Return True

    End Function
    Public Function SetPosition(ByVal setPos As String) As Boolean
        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        If arrPos.Length < 3 Then Return False
        If SetPosition(arrPos) = False Then
            Return False
        End If
        Return True
    End Function
    Private Function SetPosition(ByVal inPosition() As String) As Boolean


        Dim nNumAxis As Integer = 3

        If inPosition Is Nothing Then
            Return False
        End If

        Dim dDistance(nNumAxis - 1) As Double

        'True : CW, False : CCW 

        Try

            dDistance(0) = CDbl(inPosition(1))
            dDistance(1) = CDbl(inPosition(2))
            dDistance(2) = CDbl(inPosition(3)) '+ 119.644

            'For axis As Integer = 0 To nNumAxis - 1
            '    If g_ConfigInfos.MotionConfig(axis).bDirectionInverting = True Then
            '        dDistance(axis) = -dDistance(axis)
            '    Else
            '        dDistance(axis) = dDistance(axis)

            '    End If
            'Next

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        'XMove(dDistance(0), g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Application.DoEvents()
        'Thread.Sleep(50)

        YMove(dDistance(1), g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Application.DoEvents()
        Thread.Sleep(50)

        ZMove(dDistance(2), g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        Application.DoEvents()
        Thread.Sleep(50)

        Return True
    End Function

    Public Function Move_SetPos(ByVal in_CH As Integer, ByVal mode As eMotionMode, ByVal xOffset As Double, ByVal yOffset As Double) As Boolean

        Dim arrBuf As Array

        ucMotionIndicator.OpticalHeaderPos = "Moving..."

        Thread.Sleep(200)

        If mode = eMotionMode.eSpectrometer Then
            If g_motionPosSpectrometer(in_CH) = "" Or g_motionPosSpectrometer(in_CH) = Nothing Then Return False
            arrBuf = Split(g_motionPosSpectrometer(in_CH), ",", -1)   'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            If arrBuf.Length < 4 Then Return False
            arrBuf(1) = arrBuf(1) - xOffset   '측정 기준의 왼쪽(방향 값이 감소하는 방향)일때는 빼고, 반대로 증가 할때는 더해야 한다.
            arrBuf(2) = arrBuf(2) + yOffset
            If SetPosition(arrBuf) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eSpectrometer
                ucMotionIndicator.OpticalHeaderPos = "Spectrometer"
            End If

        ElseIf mode = eMotionMode.eCCD Then
            If g_motionPosCCD(in_CH) = "" Or g_motionPosCCD(in_CH) = Nothing Then Return False
            arrBuf = Split(g_motionPosCCD(in_CH), ",", -1)  'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            If arrBuf.Length < 4 Then Return False
            arrBuf(1) = arrBuf(1) + xOffset
            arrBuf(2) = arrBuf(2) + yOffset
            If SetPosition(arrBuf) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eCCD
                ucMotionIndicator.OpticalHeaderPos = "CCD Camera"
            End If

        ElseIf mode = eMotionMode.eMCR Then
            If g_motionPosMCR(in_CH) = "" Or g_motionPosMCR(in_CH) = Nothing Then Return False
            arrBuf = Split(g_motionPosMCR(in_CH), ",", -1)  'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            If arrBuf.Length < 4 Then Return False
            arrBuf(1) = arrBuf(1) + xOffset
            arrBuf(2) = arrBuf(2) + yOffset
            If SetPosition(arrBuf) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eMCR
                ucMotionIndicator.OpticalHeaderPos = "MCR"
            End If
        End If

        Dim sJIGName As String = Nothing

        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
            sJIGName = "[ CH" & Format(in_CH + 1, "00") & " ]"
        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
            sJIGName = "[ TEG" & ucDispJIG.convertIncNumberToMatrixValue(in_CH) & " ]"
        End If

        ucMotionIndicator.Channel = sJIGName '"[ CH" & CStr(in_CH + 1) & " ]"

        Return True

    End Function
    Public Function SetPositionXYAxisMovingFirst(ByVal setPos As String, Optional ByVal xOffset As Double = 0, Optional ByVal yOffset As Double = 0) As Boolean
        Dim arrPos() As String = Nothing
        If setPos = "" Or setPos = Nothing Then Return False
        arrPos = Split(setPos, ",", -1)
        If arrPos.Length < 3 Then Return False
        If SetPositionXYAxisMovingFirst(arrPos, xOffset, yOffset) = False Then
            If SetPositionXYAxisMovingFirst(arrPos, xOffset, yOffset) = False Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Function SetPositionXYAxisMovingFirst(ByVal inPosition() As String, ByVal xOffset As Double, ByVal yOffset As Double) As Boolean

        ' Dim cnt_axis As Integer
        Dim nNumAxis As Integer = 3 'g_ConfigInfos.MotionConfig.Length

        If inPosition Is Nothing Then
            Return False
        End If

        Dim dDistance(nNumAxis - 1) As Double
        Dim dPos(nNumAxis - 1) As Double

        'True : CW, False : CCW 

        Try

            dDistance(0) = CDbl(inPosition(1))
            dDistance(1) = CDbl(inPosition(2)) - xOffset
            dDistance(2) = CDbl(inPosition(3)) + yOffset
            '   dDistance(3) = 0


            dPos(0) = CDbl(inPosition(1))
            dPos(1) = CDbl(inPosition(2))
            dPos(2) = CDbl(inPosition(3))

            'm_Distance = dDistance.Clone

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Dim GetCMDPos() As Double = Nothing
        Dim chkPos As Boolean = False
        Dim cnt As Integer = 0
        Dim cntTimeOut As Integer = 0
        Dim sTemp As String = ""

        'Loop Until chkPos
        XMove(dDistance(0), g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

        'Application.DoEvents()
        'Thread.Sleep(1000)
        'MoveCompletedAllAxis()

        YMove(dDistance(1), g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

        'Application.DoEvents()
        'Thread.Sleep(1000)
        'MoveCompletedAllAxis()

        ZMove(dDistance(2), g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

        'Application.DoEvents()
        'Thread.Sleep(1000)
        'MoveCompletedAllAxis()

        Return True
    End Function

    Public Function Move_SetPos_XYAxisMovingFirst(ByVal in_CH As Integer, ByVal mode As eMotionMode, ByVal xOffset As Double, ByVal yOffset As Double) As Boolean

        Dim arrBuf As Array

        ucMotionIndicator.OpticalHeaderPos = "Moving..."

        Thread.Sleep(200)

        If mode = eMotionMode.eSpectrometer Then
            If g_motionPosSpectrometer(in_CH) = "" Or g_motionPosSpectrometer(in_CH) = Nothing Then Return False
            arrBuf = Split(g_motionPosSpectrometer(in_CH), ",", -1)   'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            If arrBuf.Length < 4 Then Return False
            arrBuf(1) = arrBuf(1) - xOffset   '측정 기준의 왼쪽(방향 값이 감소하는 방향)일때는 빼고, 반대로 증가 할때는 더해야 한다.
            arrBuf(2) = arrBuf(2) + yOffset
            If SetPositionXYAxisMovingFirst(arrBuf, 0, 0) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eSpectrometer
                ucMotionIndicator.OpticalHeaderPos = "Spectrometer"
            End If

        ElseIf mode = eMotionMode.eCCD Then
            If g_motionPosCCD(in_CH) = "" Or g_motionPosCCD(in_CH) = Nothing Then Return False
            arrBuf = Split(g_motionPosCCD(in_CH), ",", -1)  'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            If arrBuf.Length < 4 Then Return False
            arrBuf(1) = arrBuf(1) + xOffset
            arrBuf(2) = arrBuf(2) + yOffset
            If SetPosition(arrBuf) = False Then
                myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_Not_Found_MotionPos) '("Can not find motion position infomation.")
                ucMotionIndicator.Channel = "Failed Moving"
                ucMotionIndicator.OpticalHeaderPos = "-"
                Return False
            Else
                g_MotionMode = eMotionMode.eCCD
                ucMotionIndicator.OpticalHeaderPos = "CCD Camera"
            End If
        End If

        Dim sJIGName As String = Nothing

        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
            sJIGName = "[ CH" & Format(in_CH + 1, "00") & " ]"
        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
            sJIGName = "[ TEG" & ucDispJIG.convertIncNumberToMatrixValue(in_CH) & " ]"
        End If

        ucMotionIndicator.Channel = sJIGName '"[ CH" & CStr(in_CH + 1) & " ]"

        Return True

    End Function

#End Region

#Region "Functions About Motion Control"

    Dim trdMonitor As Thread

    Private Sub StartThread()
        m_bEnableDispUpdate = True
        trdMonitor = New Thread(AddressOf PositionDisplay)
        trdMonitor.Start()
    End Sub

    Private Sub StopThread()
        m_bEnableDispUpdate = False
    End Sub

    Private Sub PositionDisplay()
        Do While m_bEnableDispUpdate

            Application.DoEvents()
            Thread.Sleep(100)

            If myParent.cPLC.IsConnected = True Then

                Dim tPositionArr() As Double
                tPositionArr = myParent.cPLC.CurrentPosition    'GetActualPosition   'GetCommandPosition()

                Try

                    If tPositionArr Is Nothing Then
                        ucMotionIndicator.XPos = 0
                        ucMotionIndicator.YPos = 0
                        ucMotionIndicator.ZPos = 0
                        ucMotionIndicator.Theta1Pos = 0
                        ucMotionIndicator.Theta2Pos = 0
                        ucMotionIndicator.Theta3Pos = 0
                        ucMotionIndicator.Theta4Pos = 0
                    Else

                        For Cnt As Integer = 0 To tPositionArr.Length - 1

                            If Cnt = 0 Then
                                ucMotionIndicator.XPos = tPositionArr(Cnt)
                            ElseIf Cnt = 0 Then
                                ucMotionIndicator.YPos = tPositionArr(Cnt)
                            ElseIf Cnt = 1 Then
                                ucMotionIndicator.ZPos = tPositionArr(Cnt)
                            ElseIf Cnt = 2 Then
                                ucMotionIndicator.Theta1Pos = tPositionArr(Cnt)
                            ElseIf Cnt = 3 Then
                                ucMotionIndicator.Theta2Pos = tPositionArr(Cnt)
                            ElseIf Cnt = 4 Then
                                ucMotionIndicator.Theta3Pos = tPositionArr(Cnt)
                            ElseIf Cnt = 5 Then
                                ucMotionIndicator.Theta4Pos = tPositionArr(Cnt)
                            End If
                        Next

                    End If
                Catch ex As Exception

                End Try


            End If


        Loop
    End Sub
    ' jkjhkhjkjhjkh
    Private Sub SavePosition(ByVal FilePath As String, ByVal mode As eMotionMode, ByVal nch As Integer)
        Dim arrBuf As Array = Nothing
        Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim sFileTitle As String = "Motion Position Information"

        If Directory.Exists(g_SPATH_SystemData) = False Then
            Directory.CreateDirectory(g_SPATH_SystemData)
        End If

        Dim MotionPositionSaver As New CSavePosition(FilePath)

        MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileTitle, sFileTitle)

        If mode = eMotionMode.eCCD Then
            arrBuf = Split(g_motionPosCCD(nch), ",", -1)  'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.X, arrBuf(1))
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.Y, arrBuf(2))
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.Z, arrBuf(3))

        ElseIf mode = eMotionMode.eSpectrometer Then
            arrBuf = Split(g_motionPosSpectrometer(nch), ",", -1)  'ArrBuf Index : 0 = Channel, 1 = X Pos, 2 = Y Pos, 3 = Z Pos
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.X, arrBuf(1))
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.Y, arrBuf(2))
            MotionPositionSaver.SaveIniValue(CSavePosition.eSecID.eCh, nch, CSavePosition.eKeyID.Z, arrBuf(3))

        End If
    End Sub
    Private Sub SaveMotionPosition(ByVal Filepath As String, ByVal mode As eMotionMode)
        Dim i As Integer

        If Directory.Exists(g_SPATH_SystemData) = False Then
            Directory.CreateDirectory(g_SPATH_SystemData)
        End If

        FileOpen(1, Filepath, OpenMode.Output)

        If mode = eMotionMode.eCCD Then
            PrintLine(1, "[CCD Motion Position Information]")
            For i = 0 To g_motionPosCCD.Length - 1
                PrintLine(1, g_motionPosCCD(i))
            Next
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eDEV_POSITION_DATA_SAVE_CCD)

        ElseIf mode = eMotionMode.eSpectrometer Then
            PrintLine(1, "[Spectrometer Motion Position Information]")
            For i = 0 To g_motionPosSpectrometer.Length - 1
                PrintLine(1, g_motionPosSpectrometer(i))
            Next
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eDEV_POSITION_DATA_SAVE_SPECTROMETER)

        ElseIf mode = eMotionMode.eMCR Then
            PrintLine(1, "[MCR Motion Position Information]")
            For i = 0 To g_motionPosMCR.Length - 1
                PrintLine(1, g_motionPosMCR(i))
            Next
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eDEV_POSITION_DATA_SAVE_SPECTROMETER)
        End If

        FileClose(1)

    End Sub
    Private Function LoadMotionPosSpectrometer() As Boolean
        Dim sFileTitle As String = "Motion Position Information"

        Dim sTemp As String
        Dim X As String
        Dim Y As String
        Dim Z As String
        Dim nCnt As Integer


        If File.Exists(g_sFilePath_MotionPosSpectrometer) = False Then
            Return False
        End If

        Dim MotionPositionLoader As New CSavePosition(g_sFilePath_MotionPosSpectrometer)

        For i As Integer = 0 To g_nMaxCh - 1
            X = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.X)
            Y = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.Y)
            Z = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.Z)
            sTemp = i & "," & X & "," & Y & "," & Z
            g_motionPosSpectrometer(i) = sTemp
            nCnt += 1
        Next

        If nCnt <> g_motionPosSpectrometer.Length Then Return False

        Return True
    End Function
    Private Function LoadMotionPosCCD() As Boolean
        Dim sFileTitle As String = "Motion Position Information"

        Dim sTemp As String
        Dim X As String
        Dim Y As String
        Dim Z As String
        Dim nCnt As Integer


        If File.Exists(g_sFilePath_MotionPosCCD) = False Then
            Return False
        End If

        Dim MotionPositionLoader As New CSavePosition(g_sFilePath_MotionPosCCD)

        For i As Integer = 0 To g_nMaxCh - 1
            X = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.X)
            Y = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.Y)
            Z = MotionPositionLoader.LoadIniValue(CSavePosition.eSecID.eCh, i, CSavePosition.eKeyID.Z)
            sTemp = i & "," & X & "," & Y & "," & Z
            g_motionPosCCD(i) = sTemp
            nCnt += 1
        Next

        If nCnt <> g_motionPosCCD.Length Then Return False

        Return True
    End Function
    'Private Function LoadMotionPosSpectrometer() As Boolean

    '    Dim fs1 As FileStream
    '    Dim sr1 As StreamReader

    '    If File.Exists(g_sFilePath_MotionPosSpectrometer) = False Then
    '        Return False
    '    Else
    '        fs1 = New FileStream(g_sFilePath_MotionPosSpectrometer, FileMode.Open, FileAccess.Read)
    '        sr1 = New StreamReader(fs1, System.Text.Encoding.Default)
    '    End If

    '    Dim nCnt As Integer = 0
    '    Dim sLine As String = sr1.ReadLine()
    '    Dim arrVal As Array

    '    If sLine <> "[Spectrometer Motion Position Information]" Then
    '        'MsgBox("File Load Error.")
    '        fs1.Close()
    '        sr1.Close()
    '        Return False
    '    End If

    '    While (Not sLine Is Nothing)
    '        sLine = sr1.ReadLine()
    '        If sLine = "" Then Exit While
    '        arrVal = Split(sLine, ",", -1)
    '        If arrVal.Length <> 4 Then Exit While
    '        If nCnt >= g_motionPosSpectrometer.Length Then Exit While
    '        g_motionPosSpectrometer(nCnt) = sLine
    '        nCnt += 1
    '        'motionPosSpectrometer(arrVal(0)) = arrVal(1) & "," & arrVal(2) & "," & arrVal(3)
    '    End While

    '    fs1.Close()
    '    sr1.Close()

    '    If nCnt <> g_motionPosSpectrometer.Length Then Return False

    '    '(Not sLine Is Nothing)
    '    Return True
    'End Function

    'Private Function LoadMotionPosCCD() As Boolean

    '    Dim fs1 As FileStream
    '    Dim sr1 As StreamReader

    '    If File.Exists(g_sFilePath_MotionPosCCD) = False Then
    '        Return False
    '    Else
    '        fs1 = New FileStream(g_sFilePath_MotionPosCCD, FileMode.Open, FileAccess.Read)
    '        sr1 = New StreamReader(fs1, System.Text.Encoding.Default)
    '    End If

    '    Dim nCnt As Integer = 0
    '    Dim sLine As String = sr1.ReadLine()
    '    Dim arrVal As Array

    '    If sLine <> "[CCD Motion Position Information]" Then
    '        'MsgBox("File Load Error.")
    '        fs1.Close()
    '        sr1.Close()
    '        Return False
    '    End If

    '    While (Not sLine Is Nothing)
    '        sLine = sr1.ReadLine()
    '        If sLine = "" Then Exit While
    '        arrVal = Split(sLine, ",", -1)
    '        If arrVal.Length <> 4 Then Exit While
    '        If nCnt >= g_motionPosCCD.Length Then Exit While
    '        g_motionPosCCD(nCnt) = sLine
    '        nCnt += 1
    '        'motionPosSpectrometer(arrVal(0)) = arrVal(1) & "," & arrVal(2) & "," & arrVal(3)
    '    End While
    '    '(Not sLine Is Nothing)

    '    fs1.Close()
    '    sr1.Close()

    '    If nCnt <> g_motionPosCCD.Length Then Return False

    '    Return True
    'End Function

    Private Function LoadMotionPosMCR() As Boolean

        Dim fs1 As FileStream
        Dim sr1 As StreamReader

        If File.Exists(g_sFilePath_MotionPosMCR) = False Then
            Return False
        Else
            fs1 = New FileStream(g_sFilePath_MotionPosMCR, FileMode.Open, FileAccess.Read)
            sr1 = New StreamReader(fs1, System.Text.Encoding.Default)
        End If

        Dim nCnt As Integer = 0
        Dim sLine As String = sr1.ReadLine()
        Dim arrVal As Array

        If sLine <> "[MCR Motion Position Information]" Then
            'MsgBox("File Load Error.")
            fs1.Close()
            sr1.Close()
            Return False
        End If

        While (Not sLine Is Nothing)
            sLine = sr1.ReadLine()
            If sLine = "" Then Exit While
            arrVal = Split(sLine, ",", -1)
            If arrVal.Length <> 4 Then Exit While
            If nCnt >= g_motionPosMCR.Length Then Exit While
            g_motionPosMCR(nCnt) = sLine
            nCnt += 1
            'motionPosSpectrometer(arrVal(0)) = arrVal(1) & "," & arrVal(2) & "," & arrVal(3)
        End While
        '(Not sLine Is Nothing)

        fs1.Close()
        sr1.Close()

        If nCnt <> g_motionPosMCR.Length Then Return False

        Return True
    End Function

#End Region



#Region "ACF Function"


#Region "Define about ACF"

    Dim trdAF As Thread
    Dim trdAC As Thread
    ' Dim trdIntensityAdj As Thread
    Dim bIsStopACThread As Boolean = True
    Dim bIsStopAFThread As Boolean = True
    '  Dim bIsStopIntensityAdjThread As Boolean = True

#End Region

#Region "Enums about Auto Focusing"

    Public Enum eAFDirection
        eCurrentPos
        eUP
        eDown
    End Enum

#End Region

#Region "ACF Test Button Event"


    Private Sub btnRunACF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunACF.Click

        If g_MotionMode <> eMotionMode.eCCD Then
            MsgBox("CCD로 전환 후 사용하십시오.")
            Exit Sub
        End If

        Dim nCh As Integer = cbChannel.SelectedIndex
        Dim nSampleType As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eSampleType)

        'If RunACF(cbChannel.SelectedIndex,
        '          g_SystemOptions.sOptionData.ACFData, frmOptionWindow.eACFMode.eEnable_AutoCenteringAndFocusing,
        '          nSampleType,
        '          Nothing, ucSequenceBuilder.eRcpMode.eNothing, False) = True Then
        '    MsgBox("Completed ACF")
        'Else
        '    MsgBox("Failed ACF")
        'End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        '  Dim sPath As String

        '        sPath = "D:\Data\tt.bmp"
        '  PictureBox1.Image.Save(sPath, System.Drawing.Imaging.ImageFormat.Bmp)
        ClearListACF()
    End Sub

    Private Sub btnIntensityAdj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensityAdj.Click
        If g_MotionMode <> eMotionMode.eCCD Then
            MsgBox("CCD로 전환 후 사용하십시오.")
            Exit Sub
        End If

        btnIntensityAdj.Enabled = False

        Dim dAdjACFBias As Double
        Dim settings As CDevM6000PLUS.sSettingParams

        If m_ACFComponent = eACFComponent.eM6000 Then
            With settings
                .source.dBiasValue = 0
                .bOutputState = CDevM6000PLUS.eONOFF.eON
                .source.dAmplitude = 0
                .source.Pulse.dDuty = 0
                .source.Pulse.dFrequency = 0
                .source.Mode = CDevM6000PLUS.eMode.eCV
            End With
        End If

        If IntensityAdjLoop(cbChannel.SelectedIndex, g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Bias, g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Limit, dAdjACFBias, settings, False) = True Then
            MsgBox("Adjusted ACF Bias = " & CStr(dAdjACFBias))
        Else
            MsgBox("Failed")
        End If

        btnIntensityAdj.Enabled = True
    End Sub

    Private Sub btnAnalysisImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalysisImage.Click

        If g_MotionMode <> eMotionMode.eCCD Then
            MsgBox("CCD로 전환 후 사용하십시오.")
            Exit Sub
        End If

        Dim grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData = Nothing
        Dim procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData
        btnAnalysisImage.Enabled = False
        Dim nTimeOutCnt As Integer = 0
        ' BlobInfoAnalysis(dtotArea)
        Thread.Sleep(500)

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
        procImgInfo = myParent.cVision.myVisionCamera.ProcImgData

        SetListACFInfo(1, grabImgInfo, procImgInfo)

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess

        btnAnalysisImage.Enabled = True
    End Sub

    Private Sub btnAutoFocusing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoFocusing.Click

        cbChangePosition.Enabled = False
        btnAutoCentering.Enabled = False

        If g_MotionMode <> eMotionMode.eCCD Then
            MsgBox("CCD로 전환 후 사용하십시오.")
            cbChangePosition.Enabled = True
            btnAutoCentering.Enabled = True
            Exit Sub
        End If

        'MoveCompletedAllAxis()

        If bIsStopAFThread = True Then
            btnAutoFocusing.Text = "Stop AF(Running...)"
            btnAutoFocusing.BackColor = Color.OrangeRed
            StartAFThread(cbChannel.SelectedIndex)
        Else
            StopAFThread()
        End If

        cbChangePosition.Enabled = True
        btnAutoCentering.Enabled = True
        btnAutoFocusing.Text = "Focusing"
        btnAutoFocusing.BackColor = Color.Transparent 'System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnAutoCentering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoCentering.Click

        cbChangePosition.Enabled = False
        btnAutoCentering.Enabled = False
        If g_MotionMode <> eMotionMode.eCCD Then
            MsgBox("CCD로 전환 후 사용하십시오.")
            cbChangePosition.Enabled = True
            btnAutoCentering.Enabled = True
            Exit Sub
        End If

        ' MoveCompletedAllAxis()

        If bIsStopACThread = True Then
            btnAutoCentering.Text = "Stop AC(Running...)"
            btnAutoCentering.BackColor = Color.Orange

            'AutoCentering(cbChannel.SelectedIndex)
            StartACThread(cbChannel.SelectedIndex)
        Else
            StopACThread()
        End If

        cbChangePosition.Enabled = True
        btnAutoCentering.Enabled = True
        btnAutoCentering.Text = "Centering"
        btnAutoCentering.BackColor = Color.Transparent '.Drawing.SystemColors.Control
    End Sub

#End Region


#Region "ACF Functions"


    Public Function RunMCR(ByVal in_Ch As Integer, ByRef sResult As String) As Boolean
    End Function

    Public Sub CheckThetaPosition(ByVal index As Integer, ByRef degree As Double)

        If index = 0 Or index = 1 Or index = 2 Or index = 6 Or index = 7 Or index = 8 Or index = 12 Or index = 13 Or index = 14 Or index = 18 Or index = 19 Or index = 20 Then
            degree = -90
        Else
            degree = 90
        End If
    End Sub
    Public Function RunACF(ByVal in_Ch As Integer,
                           ByVal ACFOptions As frmOptionWindow.sACF,
                           ByVal ACFMode As frmOptionWindow.eACFMode,
                           ByVal sampleType As ucSampleInfos.eSampleType,
                           ByVal saveInfo As CMcFile.sFILENAME,
                           ByVal nMode As ucSequenceBuilder.eRcpMode,
                           ByVal bManualACF As Boolean, Optional ByRef dAdjACFBias As Double = 0, Optional ByVal bMainMeas As Boolean = True) As Boolean

        ''현재 측정중인 채널
        'lblTarget.Text = "CH : " & CStr(g_nCH + 1)   'Sequence Indicator Current Channel
        'lblTarget.ForeColor = Color.Blue
        ''==============================================               
        'lblAFCH.Text = "[ CH " & CStr(g_nCH + 1) & " ]"    'Single/Motion Control Window Channel Display
        ''==============================================

        Dim nDevNoOfIVLSMU As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nDevNoOfSW As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChNoOfSW As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eChOfSwitch)
        Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eChOfM6000)
        Dim nDevNoOfGNTPG As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Dim nChOfPallet As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.ePallet_No)
        Dim nChOfJIG As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eJIG_No)
        ' Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Dim nTimeOutCnt As Integer = 0
        Dim dThetaDegree As Double = 0
        ' myParent.ucMeasurementState.MeasurementState = ucMultiMeasurementState.eState.eACF

        If ACFMode = frmOptionWindow.eACFMode.eDisable_FixedPosition Then
            '55인치 패널 측정 시스템 전용
            'myParent.cMotion.ZMove(10, True)
            Move_SetPos(in_Ch, eMotionMode.eSpectrometer)
            Return True
        End If

        If myParent.cVision.myVisionCamera.IsConnectedToCamera = False Then Return False

        myParent.cVision.myVisionCamera.SampleType = sampleType

        'Trigger Mode 추가
        If myParent.cVision.myVisionCamera.SetAttributeValue("FrameStartTriggerMode", 0, "Freerun", Nothing) = False Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_MSG_Function_Error)
            Return False
        End If

        '      g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING_END)

        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Ready, " ACF Bias 인가.")
        Thread.Sleep(100)

        '1. 채널 좌표로 이동
        Move_SetPos(in_Ch, eMotionMode.eCCD)

        ' MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)
        CheckThetaPosition(nChOfJIG, dThetaDegree)

        If nChOfPallet = 0 Then
            If Theta1Move(dThetaDegree, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta1 Move Function")
            End If
        ElseIf nChOfPallet = 1 Then
            If Theta2Move(dThetaDegree, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta2 Move Function")
            End If
        ElseIf nChOfPallet = 2 Then
            If Theta3Move(dThetaDegree, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta3 Move Function")
            End If
        ElseIf nChOfPallet = 3 Then
            If Theta4Move(dThetaDegree, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta4 Move Function")
            End If
        End If


        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Cell_Intensity_Adjust, " Cell Intensity 확인")
        Thread.Sleep(1000)

        '샘플 구동
        If sampleType = ucSampleInfos.eSampleType.eCell Then

            Dim settings As CDevM6000PLUS.sSettingParams

            If m_ACFComponent = eACFComponent.eKeithley Then
                'If IntensityAdjLoop(in_Ch, ACFOptions.dIntensityAdj_Bias, ACFOptions.dIntensityAdj_Limit, dAdjACFBias, settings, bMainMeas) = False Then
                '    myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Fail_Cell_Intensity_Adjust_Check_Cell, " Fail...")
                '    myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep()
                '    Return False
                'Else
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchON(nChNoOfSW) = False Then Return False
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.InitializeSweep(ACFOptions.sIntensityAdj_Settings) = False Then Return False
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.SetBias(dAdjACFBias) = False Then Return False
                'End If

                'If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchON(nChNoOfSW) = False Then Return False

            ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                'With settings
                '    .source.dBiasValue = 0
                '    .bOutputState = CDevM6000PLUS.eONOFF.eON
                '    .source.dAmplitude = 0
                '    .source.Pulse.dDuty = 0
                '    .source.Pulse.dFrequency = 0
                '    If g_SystemOptions.sOptionData.ACFData.sSoruceMode = frmOptionWindow.ACFSourceMode.eCV Then
                '        .source.Mode = CDevM6000PLUS.eMode.eCV
                '    Else
                '        .source.Mode = CDevM6000PLUS.eMode.eCC
                '    End If
                'End With

                If IntensityAdjLoop(in_Ch, ACFOptions.dIntensityAdj_Bias, ACFOptions.dIntensityAdj_Limit, dAdjACFBias, settings, bMainMeas) = False Then
                    myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Fail_Cell_Intensity_Adjust_Check_Cell, " Fail...")
                    ' If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                    Return False
                Else
                    'Bias Setting
                    settings.source.dBiasValue = dAdjACFBias
                    'If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eFastSetSource, settings, Nothing) = False Then
                    '    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION)
                    'End If

                    'FastSetSource 상태는 Bias 인가 후 IDEL 상태로 변경하기 때문에 IDEL상태가 되었는지 확인 하면 된다.
                    '   myParent.cQueueProcessor.CompletedSettingsOfM6000(nDevNoOfM6000, nChNoOfM6000, 10, CSeqRoutineM6000.eSequenceState.eMeasuring)
                    nTimeOutCnt = 0
                    'Do
                    '    Application.DoEvents()
                    '    Thread.Sleep(30)
                    '    If nTimeOutCnt > 30 Then
                    '        Exit Do
                    '    End If
                    '    nTimeOutCnt += 1
                    'Loop Until myParent.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring
                End If
            End If

        Else
            ' Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

            If nDevNoOfGNTPG <> -1 Then
                'Module, Panel 
                myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eON)
                Do
                    Thread.Sleep(1000)
                    Application.DoEvents()
                Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eMeasuring
                myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eSetPattern, ACFOptions.nModulePatternNo)
                Do
                    Thread.Sleep(1000)
                    Application.DoEvents()
                Loop Until myParent.cPG.PatternGenerator(0).MeasuredData(nDevNoOfGNTPG).sG4S.nPatternIdx = ACFOptions.nModulePatternNo
            End If

        End If

        '2. 센터링 좌표로 이동
        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_RunningAC, " Centering...")

        If AutoCentering(in_Ch) = False Then

            If sampleType = ucSampleInfos.eSampleType.eCell Then
                'Cell
                'If m_ACFComponent = eACFComponent.eKeithley Then
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                'End If
            Else
                If nDevNoOfGNTPG <> -1 Then
                    'Module, Panel
                    myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)
                    Do
                        'Check Status
                        Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                End If
            End If

            Return False
        End If

        ' MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        '3. 센터링 상태 확인
        If ACFMode = frmOptionWindow.eACFMode.eEnable_AutoCentering Then 'Auto Centering 만 수행하면 여기까지 하고 종료

            If AutoCentering(in_Ch) = False Then
                If sampleType = ucSampleInfos.eSampleType.eCell Then
                    'If m_ACFComponent = eACFComponent.eKeithley Then
                    '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                    '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                    'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                    '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                    'End If

                Else
                    If nDevNoOfGNTPG <> -1 Then
                        'Module, Panel
                        myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)
                        Do
                            'Check Status
                            Thread.Sleep(1000)
                            Application.DoEvents()
                        Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                    End If
                End If

                Return False
            End If


            myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Completed_AC, "")

            If sampleType = ucSampleInfos.eSampleType.eCell Then
                'Cell
                If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'If m_ACFComponent = eACFComponent.eKeithley Then
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                'End If
            Else
                'Module, Panel
                If nDevNoOfGNTPG <> -1 Then
                    myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)

                    Do
                        'Check Status
                        Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                End If

            End If
            Return True
        End If


        '4. Auto Focusing 1

        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_RunningAF, " Focusing...")
        If AutoFocusing(in_Ch) = False Then
            'Cell
            If sampleType = ucSampleInfos.eSampleType.eCell Then
                'If m_ACFComponent = eACFComponent.eKeithley Then
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                'End If
            Else
                'Module, Panel
                If nDevNoOfGNTPG <> -1 Then
                    'Module, Panel
                    myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)

                    Do
                        'Check Status
                        Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                End If

            End If
            Return False
        End If

        '5. Auto Focusing 2
        If AutoFocusing(in_Ch) = False Then

            If sampleType = ucSampleInfos.eSampleType.eCell Then
                'If m_ACFComponent = eACFComponent.eKeithley Then
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                'End If
            Else
                ' Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                If nDevNoOfGNTPG <> -1 Then
                    'Module, Panel
                    myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)

                    Do
                        'Check Status
                        Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                End If

            End If


            Return False
        End If

        '6. 다시 센터링
        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_RunningAC, " Centering...")

        If AutoCentering(in_Ch) = False Then
            If sampleType = ucSampleInfos.eSampleType.eCell Then
                'If m_ACFComponent = eACFComponent.eKeithley Then
                '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
                '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
                'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
                '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
                'End If

            Else
                ' Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_Ch, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                If nDevNoOfGNTPG <> -1 Then
                    'Module, Panel
                    myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)

                    Do
                        'Check Status
                        Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
                End If

            End If

            Return False

        End If


        ' If m_bIsFrameShow = True Then
        'myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        '  Else
        '  Dim nTimeOutCnt As Integer

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        Dim sDataTypeFolder As String = Nothing
        Dim sJIGName As String = Nothing
        Dim sSaveFolder As String = Nothing

        If saveInfo.strFPath Is Nothing = False Then

            If bManualACF = True Then
                sJIGName = Format(in_Ch + 1, "00")
                '파일 이름 입력 폴더 생성후 저장
                ' If Directory.Exists(saveInfo.strFPath & saveInfo.strOnlyFName & "\") = False Then Directory.CreateDirectory(saveInfo.strFPath & saveInfo.strOnlyFName & "\")
                '    myParent.cVision.myVisionCamera.SaveGrabImage(saveInfo.strFPath & saveInfo.strOnlyFName & "\" & _
                '             "Ch" & sJIGName & "_ACFImage_" & saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".bmp")
                myParent.cVision.myVisionCamera.SaveGrabImage(saveInfo.strFPath & _
                                                      "Ch" & sJIGName & "_ACFImage_" & saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".bmp")
            Else
                myParent.g_DataSaver(in_Ch).DataTypeFolder(sDataTypeFolder, nMode)

                If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                    sJIGName = Format(in_Ch + 1, "00")
                ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                    sJIGName = ucDispJIG.convertIncNumberToMatrixValue(in_Ch)
                End If

                '   sSaveFolder = saveInfo.strFPath & sDataTypeFolder & saveInfo.strOnlyFName & "\" & "ACF_Image\"
                sSaveFolder = saveInfo.strFPath & "ACF_Image\"
                If Directory.Exists(sSaveFolder) = False Then Directory.CreateDirectory(sSaveFolder)

                myParent.cVision.myVisionCamera.SaveGrabImage(sSaveFolder & "TEG" & sJIGName & "_ACFImage_" & saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".bmp")
            End If

        End If

        If m_bIsFrameShow = True Then
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        Else
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        End If

        myParent.g_StateMsgHandler.messageToUserErrorCode(in_Ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Completed_AC, "")

        If sampleType = ucSampleInfos.eSampleType.eCell Then
            'If m_ACFComponent = eACFComponent.eKeithley Then
            '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
            '    If myParent.cSwitch(nDevNoOfSW).mySwitch.SwitchOFF(nChNoOfSW) = False Then Return False
            'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
            '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
            'End If
        Else
            'Module, Panel
            If nDevNoOfGNTPG <> -1 Then
                myParent.cPG.PatternGenerator(0).Request(nDevNoOfGNTPG, CDevPGCommonNode.eSequenceState.eReset)

                Do
                    'Check Status
                    Thread.Sleep(1000)
                    Application.DoEvents()
                Loop Until myParent.cPG.PatternGenerator(0).ChannelStatus(nDevNoOfGNTPG) = CDevPGCommonNode.eSequenceState.eidle
            End If
        End If
        Return True
    End Function


#Region "Intensity Adjust for ACF"

    Public Function IntensityAdjLoop(ByVal inCh As Integer, ByVal StartBias As Double, ByVal dLimit As Double, ByRef AdjACFBias As Double, ByVal settings As CDevM6000PLUS.sSettingParams, ByVal bMainMeas As Boolean) As Boolean

        Dim grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData = Nothing
        Dim procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData

        Dim nDevNoOfIVLSMU As Integer = frmSettingWind.GetAllocationValue(inCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nDeviceNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(inCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitchDev As Integer = frmSettingWind.GetAllocationValue(inCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(inCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(inCh, frmSettingWind.eChAllocationItem.eChOfM6000)
        ' Dim settings As CDevM6000.sSettingParams

        Dim dOnCellAdjVal As Double = g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Step
        Dim dOffCellAdjVal As Double = g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Step  '0.3
        Dim dSetVoltage As Double
        Dim dLimitSetVoltage As Double = dLimit

        Dim nTimeOutCnt As Integer = 0

        ClearListACF()

        'dSetVoltage = StartBias

        'If m_ACFComponent = eACFComponent.eKeithley Then
        '    If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchON(nChOfSwitchDev) = False Then Return False
        '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.InitializeSweep(g_SystemOptions.sOptionData.ACFData.sIntensityAdj_Settings) = False Then Return False
        '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.SetBias(dSetVoltage) = False Then Return False

        'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
        '    If g_SystemOptions.sOptionData.ACFData.sSoruceMode = frmOptionWindow.ACFSourceMode.eCV Then
        '        settings.source.Mode = CDevM6000CommonNode.eMode.eCV
        '        settings.source.dBiasValue = dSetVoltage
        '    Else
        '        settings.source.Mode = CDevM6000CommonNode.eMode.eCC
        '        settings.source.dBiasValue = dSetVoltage
        '    End If

        '    'Bias Setting
        '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eFastSetSource, settings, Nothing) = False Then
        '        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION)
        '    End If

        '    nTimeOutCnt = 0
        '    Do
        '        Application.DoEvents()
        '        Thread.Sleep(30)
        '        If nTimeOutCnt > 30 Then
        '            Exit Do
        '        End If
        '        nTimeOutCnt += 1
        '    Loop Until myParent.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring
        '    'FastSetSource 상태는 Bias 인가 후 IDEL 상태로 변경하기 때문에 IDEL상태가 되었는지 확인 하면 된다.
        '    'myParent.cQueueProcessor.CompletedSettingsOfM6000(nDevNoOfM6000, nChNoOfM6000, 10, CSeqRoutineM6000.eSequenceState.eMeasuring)
        'End If

        Dim ret As Boolean = False

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        Do

            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
            myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

            nTimeOutCnt = 0
            Do
                Application.DoEvents()
                Thread.Sleep(50)
                If nTimeOutCnt > 20 Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

            grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
            procImgInfo = myParent.cVision.myVisionCamera.ProcImgData

            If procImgInfo.nNumOfBlob < 1 Then  'Off
                'myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_AC_Fail_NotDetectedCellBlob)
                dSetVoltage = dSetVoltage + dOffCellAdjVal
                '   Application.DoEvents()
                '   Thread.Sleep(1000)

            Else
                If grabImgInfo.nMaxIntensity < g_SystemOptions.sOptionData.ACFData.dLowIntensityLimit Or _
                    grabImgInfo.nGrayLevelOfMaxIntensity < g_SystemOptions.sOptionData.ACFData.nGrayLevelLimit Then 'ON

                    myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_AC_Fail_LowIntensity)
                    dSetVoltage = dSetVoltage + dOnCellAdjVal

                Else
                    myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Completed_Cell_Intensity_Adjust)
                    ret = True
                    Exit Do
                End If
            End If

            'If dLimitSetVoltage >= dSetVoltage Then
            '    If m_ACFComponent = eACFComponent.eKeithley Then
            '        myParent.g_StateMsgHandler.messageToUserErrorCode(inCh, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Ready, "ACF Bias 인가 = " & dSetVoltage)

            '        If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.SetBias(dSetVoltage) = False Then
            '            myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Fail_ACF_Bias_Setting)
            '            ret = False
            '            Exit Do
            '        End If

            '    ElseIf m_ACFComponent = eACFComponent.eM6000 Then
            '        settings.source.dBiasValue = dSetVoltage
            '        'Bias Setting
            '        If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eFastSetSource, settings, Nothing) = False Then
            '            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION)
            '        End If
            '        nTimeOutCnt = 0

            '        Do
            '            Application.DoEvents()
            '            Thread.Sleep(30)
            '            If nTimeOutCnt > 30 Then
            '                Exit Do
            '            End If
            '            nTimeOutCnt += 1
            '        Loop Until myParent.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring

            '        'FastSetSource 상태는 Bias 인가 후 IDEL 상태로 변경하기 때문에 IDEL상태가 되었는지 확인 하면 된다.
            '        'myParent.cQueueProcessor.CompletedSettingsOfM6000(nDevNoOfM6000, nChNoOfM6000, 10, CSeqRoutineM6000.eSequenceState.eidle)
            '    End If

            '    Application.DoEvents()
            '    Thread.Sleep(50)
            'Else
            '    '   myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_State_Log_Meas_State_Text, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Fail_Cell_Intensity_Adjust_Check_Cell)
            '    ret = False
            '    Exit Do
            'End If

            '     VisionModule.IsGrabbedImage = False

            'Application.DoEvents()
            'Thread.Sleep(500)

            If bMainMeas = False Then
                If m_bACFMeas = False Then
                    Return False
                End If
            End If
        Loop

        'AdjACFBias = dSetVoltage

        'If m_ACFComponent = eACFComponent.eKeithley Then
        '    If myParent.cIVLSMU(nDevNoOfIVLSMU).mySMU.FinalizeSweep() = False Then Return False
        '    If myParent.cSwitch(nDeviceNoOfSwitch).mySwitch.SwitchOFF(nChOfSwitchDev) = False Then Return False
        'ElseIf m_ACFComponent = eACFComponent.eM6000 Then
        '    If myParent.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, CSeqRoutineM6000.eSequenceState.eReset) = False Then Return False
        'End If

        If m_bIsFrameShow = True Then
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        Else
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        End If

        Return ret
    End Function

#End Region

#Region "Auto Centering"
    Dim nCHofAC As Integer

    Public Sub StartACThread(ByVal targetCh As Integer)
        trdAC = New Thread(AddressOf ACLoop)
        bIsStopACThread = False
        nCHofAC = targetCh
        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_RunningAC)
        trdAC.Start()
    End Sub

    Public Sub StopACThread()
        bIsStopACThread = True
    End Sub

    Public Sub ACLoop()

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode

        If AutoCentering(nCHofAC) = True Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Completed_AC)
        End If

        bIsStopACThread = True
        ' SetButtonText(btnAutoCentering, "Run AC")
        'SetButtonColor(btnAutoCentering, Color.SkyBlue)
    End Sub

    Public Function AutoCentering(ByVal inCh As Integer) As Boolean

        '  Dim dtotArea As Double
        Dim grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData = Nothing
        Dim procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData
        Dim distToCenterX As Double
        Dim distToCenterY As Double
        Dim nTimeOutCnt As Integer = 0
        ' Dim ImgAnalysis As AnalysisImage
        ' ImgAnalysis = New AnalysisImage(AddressOf myParent.cVision.myVisionCamera.AnalysisGrabImage)

        'BlobInfoAnalysis(dtotArea)
        ' MoveCompletedAllAxis()
        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()
        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
        procImgInfo = myParent.cVision.myVisionCamera.ProcImgData

        '   VisionModule.AnalysisGrabImage(grabImgInfo, procImgInfo)

        If procImgInfo.nNumOfBlob < 1 Then
            Application.DoEvents()
            Thread.Sleep(1000)
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
            myParent.cVision.myVisionCamera.TriggerSyncModeGrab()
            nTimeOutCnt = 0
            Do
                Application.DoEvents()
                Thread.Sleep(50)
                If nTimeOutCnt > 20 Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

            grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
            procImgInfo = myParent.cVision.myVisionCamera.ProcImgData

            If procImgInfo.nNumOfBlob < 1 Then
                myParent.g_StateMsgHandler.messageToString(inCh, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_AC_Fail_NotDetectedCellBlob)
                Return False
            End If
        End If

        'If grabImgInfo.nMaxIntensity < g_SYSOpt.dLowIntensityLimit Or grabImgInfo.nGrayLevelOfMaxIntensity < (g_SYSOpt.nGrayLevelLimit - 300) Then  '양승록
        '    frmMainWnd.g_ACFCtrl.Status = CV7000ACFState.eACFState.eAC_Fail_LowIntensity
        '    Return False
        'End If

        With g_SystemOptions.sOptionData.ACFData
            distToCenterX = (.nCCDCenterPos_X - procImgInfo.blobCenterPosX) * .dDistanceOfOnePixel_X
            distToCenterY = (.nCCDCenterPos_Y - procImgInfo.blobCenterPosY) * .dDistanceOfOnePixel_Y  '(CCD Y Center Pixel - Blob의 기준) * 1pixel의 거리
        End With

        If m_bIsFrameShow = True Then
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        Else
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        End If

        '   myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        '  myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

        'nTimeOutCnt = 0
        'Do
        '    Application.DoEvents()
        '    Thread.Sleep(50)
        '    If nTimeOutCnt > 20 Then
        '        Exit Do
        '    End If
        '    nTimeOutCnt += 1
        'Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        'SetListACFInfo(2, grabImgInfo, procImgInfo)
        YMove(-distToCenterX, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)

        Application.DoEvents()
        Thread.Sleep(1000) '

        ' YMove(-distToCenterY, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)

        'Y축 이동거리 반대임
        ZMove(-distToCenterY, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)

        Application.DoEvents()
        Thread.Sleep(1000)

        '  MoveCompletedAllAxis()

        'Update Position
        Dim strFPath As String
        Dim mode As eMotionMode

        Dim compos0 As Double
        Dim compos1 As Double
        Dim compos2 As Double

        ' 지정축의 Command 위치를 확인한다.
        compos0 = myParent.cPLC.CurrentPosition(0)   'Position 값 return
        compos1 = myParent.cPLC.CurrentPosition(1)  'CFS20get_command_position(1)    'Position 값 return
        compos2 = myParent.cPLC.CurrentPosition(2)   'CFS20get_command_position(2)    'Position 값 return
        ucMotionIndicator.YPos = compos0
        ucMotionIndicator.ZPos = compos1
        ucMotionIndicator.XPos = compos2

        mode = eMotionMode.eCCD
        strFPath = g_sFilePath_MotionPosCCD
        g_motionPosCCD(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos) & "," & CStr(ucMotionIndicator.YPos) & "," & CStr(ucMotionIndicator.ZPos)

        'SaveMotionPosition(strFPath, mode)
        SavePosition(strFPath, mode, inCh)  'yjs

        mode = eMotionMode.eSpectrometer
        strFPath = g_sFilePath_MotionPosSpectrometer
        With g_SystemOptions.sOptionData.ACFData
            g_motionPosSpectrometer(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos + .dCCDtoSpectrometerPosX) & "," & CStr(ucMotionIndicator.YPos + .dCCDtoSpectrometerPosY) & "," & CStr(ucMotionIndicator.ZPos + .dCCDtoSpectrometerPosZ)
            'SaveMotionPosition(strFPath, mode)
            SavePosition(strFPath, mode, inCh)  'yjs
        End With

        'mode = eMotionMode.eMCR
        'strFPath = g_sFilePath_MotionPosMCR

        'Dim nPosCh As Integer
        'Dim dX As Double
        'Dim dY As Double
        'Dim dZ As Double

        'nPosCh = inCh Mod 4

        ''With g_SystemOptions.sOptionData.ACFData

        ''    Select Case nPosCh
        ''        Case 0
        ''            dX = .dCCD1toMCRPosX
        ''            dY = .dCCD1toMCRPosY
        ''            dZ = .dCCD1toMCRPosZ
        ''        Case 1
        ''            dX = .dCCD2toMCRPosX
        ''            dY = .dCCD2toMCRPosY
        ''            dZ = .dCCD2toMCRPosZ
        ''        Case 2
        ''            dX = .dCCD3toMCRPosX
        ''            dY = .dCCD3toMCRPosY
        ''            dZ = .dCCD3toMCRPosZ
        ''        Case 3
        ''            dX = .dCCD4toMCRPosX
        ''            dY = .dCCD4toMCRPosY
        ''            dZ = .dCCD4toMCRPosZ
        ''    End Select

        'g_motionPosMCR(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos + dX) & "," & CStr(ucMotionIndicator.YPos + dY) & "," & CStr(ucMotionIndicator.ZPos + dZ)
        'SaveMotionPosition(strFPath, mode)
        '  End With

        Return True
    End Function

#End Region

#Region "Auto Focusing"


    Dim nCHofAF As Integer

    Public Sub StartAFThread(ByVal targetCh As Integer)
        trdAF = New Thread(AddressOf AFLoop)
        bIsStopAFThread = False
        nCHofAF = targetCh
        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_RunningAF) ' CV7000ACFState.eACFState.eRunningAF
        trdAF.Start()
    End Sub

    Public Sub StopAFThread()
        bIsStopAFThread = True
    End Sub

    Public Sub AFLoop()

        If AutoFocusing(nCHofAC) = True Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_Completed_AF) ' CV7000ACFState.eACFState.eCompleted_AF
        End If

        bIsStopAFThread = True
        ' SetButtonText(btnAutoFocusing, "Run AF")
        ' SetButtonColor(btnAutoFocusing, Color.SkyBlue)

    End Sub

    Public Function AutoFocusing(ByVal inCh As Integer) As Boolean

        Dim grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData = Nothing
        Dim procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData
        Dim eAFDir As eAFDirection
        Dim evaluationPos(2) As Double
        Dim evaluationArea(2) As Double
        Dim nTimeOutCnt As Integer = 0
        bIsStopAFThread = False

        With g_SystemOptions.sOptionData.ACFData

            evaluationPos(eAFDirection.eCurrentPos) = myParent.cPLC.CurrentPosition(2) '(CFS20get_command_position(2)) / myParent.cMotion.CalDataRealDistanceZ 'g_SystemOptions.sOptionData.MotionData.

            If .nFocusParam >= evaluationPos(eAFDirection.eCurrentPos) Then  '현재 CCD가 기준보다 위쪽에 위치하므로.
                eAFDir = eAFDirection.eDown
                ZMove(.dACFRegion_Start, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
            ElseIf .nFocusParam < evaluationPos(eAFDirection.eCurrentPos) Then '현재 CCD가 기준보다 아래쪽에서 위치하므로.
                eAFDir = eAFDirection.eUP
                ZMove(.dACFRegion_Stop, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
            Else
                eAFDir = eAFDirection.eDown
                ZMove(.dACFRegion_Start, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
            End If
        End With

        Application.DoEvents()
        Thread.Sleep(2000)
        ' MoveCompletedAllAxis()

        evaluationPos(eAFDirection.eCurrentPos) = myParent.cPLC.CurrentPosition(2)
        evaluationPos(eAFDirection.eUP) = evaluationPos(eAFDirection.eCurrentPos) - 2
        evaluationPos(eAFDirection.eDown) = evaluationPos(eAFDirection.eCurrentPos) + 2

        '현재 위치에서 Sweep 방향 결정 위 or 아래로

        For i As Integer = 0 To 2

            ZMove(evaluationPos(i), g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

            evaluationPos(i) = myParent.cPLC.CurrentPosition(2)
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
            myParent.cVision.myVisionCamera.TriggerSyncModeGrab()

            nTimeOutCnt = 0
            Do
                Application.DoEvents()
                Thread.Sleep(50)
                If nTimeOutCnt > 20 Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

            grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
            procImgInfo = myParent.cVision.myVisionCamera.ProcImgData


            evaluationArea(i) = procImgInfo.dArea
        Next

        ZMove(evaluationPos(eAFDirection.eCurrentPos), g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Image 상태 검사
        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()
        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.TriggerSyncModeGrab()
        nTimeOutCnt = 0
        Do
            Application.DoEvents()
            Thread.Sleep(50)
            If nTimeOutCnt > 20 Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

        grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
        procImgInfo = myParent.cVision.myVisionCamera.ProcImgData


        ' VisionModule.AnalysisGrabImage(grabImgInfo, procImgInfo)
        If procImgInfo.nNumOfBlob < 1 Then  '셀 이미지가 켜졌는지 확인
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eSYSTEM_MSG_ACF_AF_Fail_NotDetectedCellBlob) 'CV7000ACFState.eACFState.eAF_Fail_NotDetectedCellBlob

            If m_bIsFrameShow = True Then
                myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
            Else
                myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
            End If
            'myParent.cVision.GrabMode = CM7000Vision.eGrabMode.eContinue_NoImageProcess
            Return False
        End If

        'If grabImgInfo.nMaxIntensity < g_SYSOpt.dLowIntensityLimit Or grabImgInfo.nGrayLevelOfMaxIntensity < (g_SYSOpt.nGrayLevelLimit - 300) Then  '양승록
        '    frmMainWnd.g_ACFCtrl.Status = CV7000ACFState.eACFState.eAF_Fail_LowIntensity
        '    Return False
        'End If

        '면적이 작아지는 방향을 Sweep 방향으로 
        'If evaluationArea(eAFDirection.eCurrentPos) > evaluationArea(eAFDirection.eDown) Then
        '    eAFDir = eAFDirection.eDown
        'ElseIf evaluationArea(eAFDirection.eCurrentPos) > evaluationArea(eAFDirection.eUP) Then
        '    eAFDir = eAFDirection.eUP
        'End If

        Dim dAFArea() As Double = Nothing
        Dim dZDistance() As Double = Nothing
        Dim nGrayLevel() As Integer = Nothing
        Dim nIntensity() As Integer = Nothing
        Dim nCnt As Integer = 0
        Dim dCurrPos As Double = evaluationPos(eAFDir)

        Do

            If bIsStopAFThread = True Then
                Exit Do
            End If

            ReDim Preserve dAFArea(nCnt)
            ReDim Preserve dZDistance(nCnt)
            ReDim Preserve nGrayLevel(nCnt)
            ReDim Preserve nIntensity(nCnt)

            If eAFDir = eAFDirection.eDown Then
                dCurrPos += g_SystemOptions.sOptionData.ACFData.dScanResolution
            ElseIf eAFDir = eAFDirection.eUP Then
                dCurrPos -= g_SystemOptions.sOptionData.ACFData.dScanResolution
            End If
            ZMove(dCurrPos, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
            'Application.DoEvents()
            'Thread.Sleep(200)

            dCurrPos = myParent.cPLC.CurrentPosition(2)
            ucMotionIndicator.ZPos = dCurrPos
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
            myParent.cVision.myVisionCamera.TriggerSyncModeGrab()
            nTimeOutCnt = 0
            Do
                Application.DoEvents()
                Thread.Sleep(50)
                If nTimeOutCnt > 20 Then
                    Exit Do
                End If
                nTimeOutCnt += 1
            Loop Until myParent.cVision.myVisionCamera.GrabState = CDevVisionCameraCommonNode.eGrabState.eCompletedGrab

            grabImgInfo = myParent.cVision.myVisionCamera.OriginalImgData
            procImgInfo = myParent.cVision.myVisionCamera.ProcImgData

            dAFArea(nCnt) = procImgInfo.dArea

            dZDistance(nCnt) = dCurrPos
            nGrayLevel(nCnt) = grabImgInfo.nGrayLevelOfMaxIntensity
            nIntensity(nCnt) = grabImgInfo.nMaxIntensity

            If nCnt <> 0 Then

                If dAFArea(nCnt) > dAFArea(nCnt - 1) Then
                    ZMove(dZDistance(nCnt - 1), g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                    Exit Do
                End If
            End If

            nCnt += 1
        Loop


        If m_bIsFrameShow = True Then
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        Else
            myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eSyncMode
        End If
        ' myParent.cVision.GrabMode = CM7000Vision.eGrabMode.eContinue_NoImageProcess

        '   myParent.cVision.myVisionCamera.SaveAFInfo(nCHofAF + 1, dZDistance, dAFArea, nGrayLevel, nIntensity, g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Bias)


        'Update Position
        Dim strFPath As String
        Dim mode As eMotionMode

        Dim compos0 As Double
        Dim compos1 As Double
        Dim compos2 As Double

        ' 지정축의 Command 위치를 확인한다.
        compos0 = myParent.cPLC.CurrentPosition(0) 'CFS20get_command_position(0)    'Position 값 return
        compos1 = myParent.cPLC.CurrentPosition(1) 'CFS20get_command_position(1)    'Position 값 return
        compos2 = myParent.cPLC.CurrentPosition(2) 'CFS20get_command_position(2)    'Position 값 return
        ucMotionIndicator.XPos = compos0
        ucMotionIndicator.YPos = compos1
        ucMotionIndicator.ZPos = compos2

        mode = eMotionMode.eCCD
        strFPath = g_sFilePath_MotionPosCCD
        g_motionPosCCD(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos) & "," & CStr(ucMotionIndicator.YPos) & "," & CStr(ucMotionIndicator.ZPos)

        'SaveMotionPosition(strFPath, mode)
        SavePosition(strFPath, mode, inCh)  'yjs

        mode = eMotionMode.eSpectrometer
        strFPath = g_sFilePath_MotionPosSpectrometer
        With g_SystemOptions.sOptionData.ACFData
            g_motionPosSpectrometer(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos + .dCCDtoSpectrometerPosX) & "," & CStr(ucMotionIndicator.YPos + .dCCDtoSpectrometerPosY) & "," & CStr(ucMotionIndicator.ZPos + .dCCDtoSpectrometerPosZ)
            '   SaveMotionPosition(strFPath, mode)
            SavePosition(strFPath, mode, inCh)  'yjs
        End With

        mode = eMotionMode.eMCR
        strFPath = g_sFilePath_MotionPosMCR
        With g_SystemOptions.sOptionData.ACFData
            g_motionPosMCR(inCh) = CStr(inCh) & "," & CStr(ucMotionIndicator.XPos + .dCCDtoMCRPosX) & "," & CStr(ucMotionIndicator.YPos + .dCCDtoMCRPosY) & "," & CStr(ucMotionIndicator.ZPos + .dCCDtoMCRPosZ)
            'SaveMotionPosition(strFPath, mode)
            SavePosition(strFPath, mode, inCh)  'yjs
        End With

        Return True

        'BlobInfoAnalysis(dtotArea)
    End Function

#End Region

#End Region



#Region "ACF Image 분석 데이터 출력용 List View 함수"

    '그리드에 써주는 부분

    Private Sub initListACFInfo()

        With listACFInfo
            .Clear()
            .View = View.Details
            .AllowColumnReorder = True
            .GridLines = True
            .Columns.Add("No", 30, HorizontalAlignment.Center)
            .Columns.Add("Gray Level ", 90, HorizontalAlignment.Center)
            .Columns.Add("Intensity", 90, HorizontalAlignment.Center)
            .Columns.Add("Centering Rate X", 90, HorizontalAlignment.Center)
            .Columns.Add("Centering Rate Y", 90, HorizontalAlignment.Center)
            .Columns.Add("Center Pos. X", 90, HorizontalAlignment.Center)
            .Columns.Add("Center Pos. Y", 90, HorizontalAlignment.Center)
            .Columns.Add("Blob Number", 90, HorizontalAlignment.Center)
            .Columns.Add("Area", 90, HorizontalAlignment.Center)
        End With
    End Sub

    Private Sub SetListACFInfo(ByVal LisNo As Integer, ByVal grabImgInfo As CDevVisionCameraCommonNode.sGrabImageData, ByVal procImgInfo As CDevVisionCameraCommonNode.sImageProcessedData)

        Try
            Dim item As New ListViewItem(CStr(LisNo))  'NO
            item.SubItems.Add(CStr(grabImgInfo.nGrayLevelOfMaxIntensity))   'Yw
            item.SubItems.Add(CStr(grabImgInfo.nMaxIntensity))   'Yw
            item.SubItems.Add(Format(procImgInfo.centerRateX, "####0.000")) 'Ywa
            item.SubItems.Add(Format(procImgInfo.centerRateY, "####0.000"))
            item.SubItems.Add(Format(procImgInfo.blobCenterPosX, "####0.000"))
            item.SubItems.Add(Format(procImgInfo.blobCenterPosY, "####0.000"))

            item.SubItems.Add(CStr(procImgInfo.nNumOfBlob))
            item.SubItems.Add(Format(procImgInfo.dArea, "####0.000"))

            listACFInfo.Items.AddRange(New ListViewItem() {item})

        Catch ex As Exception
            Debug.WriteLine("Try Catch Error : Set data to ListGamma")
        End Try

    End Sub

    Private Sub ClearListACF()
        ClearListACFInfo()
        '        listACFInfo.Items.Clear()
    End Sub

#End Region

#End Region

    Private Sub btnInitCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitCamera.Click
        Dim sMsg As String = ""
        If myParent.cVision.myVisionCamera.IsConnectedToCamera = False Then
            If myParent.cVision.myVisionCamera.InitAllied(sMsg) = False Then
                MsgBox(sMsg)
            End If
        Else
            MsgBox("Alrady connected to camera")
        End If

    End Sub

    Private Sub btnAlliedStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlliedStart.Click

        If myParent.cVision.myVisionCamera.IsConnectedToCamera = False Then
            MsgBox("카메라와 연결되지 않았습니다. 통신 연결후 사용하십시오.")
            Exit Sub
        End If

        myParent.cVision.myVisionCamera.GrabMode = CDevVisionCameraCommonNode.eGrabMode.eContinue_NoImageProcess
        If myParent.cVision.myVisionCamera.GrabStart() = False Then
            MsgBox("CCD Fail...")
        End If

    End Sub

    Private Sub btnAlliedStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlliedStop.Click
        ' myParent.cVision.GrabMode = CM7000Vision.eGrabMode.eSyncMode
        myParent.cVision.myVisionCamera.GrabStop()
    End Sub

    Private Sub frmMotionUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_bIsLoaded = True
        '        myParent.cVision.DispControlFit()
    End Sub

    Private Sub frmMotionUI_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If m_bIsLoaded = False Then Exit Sub

        If myParent.cVision Is Nothing Then Exit Sub
        myParent.cVision.myVisionCamera.DispControlFit()
    End Sub



#Region "Alarm Signal ON/OFF 함수"
    '//Alarm Signal ON

    Public Sub OnRunLamp()
        If myParent.g_StateLamp.RunLampState = CV7000StateLamp.eLampState.eOFF Then
            CFS20set_output_bit(0, 2)
            myParent.g_StateLamp.RunLampState = CV7000StateLamp.eLampState.eON
        End If
    End Sub

    '//Alarm Signal OFF
    Public Sub OffRunLamp()
        If myParent.g_StateLamp.RunLampState = CV7000StateLamp.eLampState.eON Then
            CFS20reset_output_bit(0, 2)
            myParent.g_StateLamp.RunLampState = CV7000StateLamp.eLampState.eOFF
        End If
    End Sub

    '//Alarm Signal All Stop
    Public Sub Alarm_AllStop()
        CFS20reset_output_bit(0, 2)
    End Sub

#End Region

    Private Sub cbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nChannel As Integer = cbChannel.SelectedIndex
        Dim nDevM6000 As Integer = frmSettingWind.GetAllocationValue(nChannel, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nDevSMU As Integer = frmSettingWind.GetAllocationValue(nChannel, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nChannel) = CScheduler.eChSchedulerSTATE.eIdle Then

            If nDevM6000 <= -1 Then
                If nDevSMU <= -1 Then
                    MsgBox("선택하신 채널은 사용 할 수 없습니다...")
                Else
                    ucDispSrcCtrl.rdoKeithley.Checked = True
                    ucDispSrcCtrl.rdoM6000.Enabled = False
                End If

            Else
                ucDispSrcCtrl.rdoM6000.Enabled = True
            End If
        Else
            MsgBox("Select Channel is not IDEL")
        End If
    End Sub

    Public Sub ControlEnable(ByVal able As Boolean)
        gbJOG.Enabled = able
        gbManualCtrl.Enabled = able
        gbMotion.Enabled = able
        TableLayoutPanel1.Enabled = able
        ucDispSrcCtrl.Enabled = able
        ' gbSourceCtrl.Enabled = able
        'gbACFCameraCtrl.Enabled = able
        'gbACFCtrl.Enabled = able
    End Sub

    Public Function GetChannelComboBoxToSelectNumber() As Integer
        Return cbChannel.SelectedIndex
    End Function

    Private Function ChannelStringToACFMeasChannel(ByVal sInputChannel As String, ByRef nMeasChannel() As Integer) As Boolean
        Dim sComma() As String
        Dim sMinus() As String
        Dim nMax As Integer
        Dim nMin As Integer
        Dim sData() As Integer = Nothing
        Dim sBufData() As Integer = Nothing
        Dim nCnt As Integer
        Dim nStart As Integer
        Dim nEnd As Integer
        Dim nBufLength As Integer = 0

        sComma = Split(sInputChannel, ",", -1)

        For i As Integer = 0 To sComma.Length - 1
            sMinus = Split(sComma(i), "-", -1)
            Try
                If sMinus.Length > 2 Then
                    Return False
                ElseIf sMinus.Length = 1 Then
                    nMin = sMinus(0)
                    nMax = sMinus(0)
                ElseIf sMinus.Length = 2 Then
                    nMin = sMinus(0)
                    nMax = sMinus(1)
                End If
            Catch ex As Exception
                Return False
            End Try

            If nMin > nMax Then
                nStart = nMax
                nEnd = nMin
            ElseIf nMin = nMax Then
                nStart = nMin
                nEnd = nMin
            ElseIf nMin < nMax Then
                nStart = nMin
                nEnd = nMax
            End If

            nCnt = nEnd - nStart
            ReDim sBufData(nCnt)
            For j As Integer = 0 To nCnt
                sBufData(j) = nStart + j
            Next

            If i = 0 Then
                sData = sBufData.Clone
            Else
                For j As Integer = 0 To sData.Length - 1
                    For k As Integer = 0 To sBufData.Length - 1
                        If sData(j) = sBufData(k) Then
                            Return False
                        End If
                    Next

                Next

                ReDim Preserve sData(sData.Length + sBufData.Length - 1)

                For j As Integer = 0 To sBufData.Length - 1
                    sData(nBufLength + j) = sBufData(j)
                Next

            End If

            nBufLength = sData.Length
        Next

        sData = CDataSort.BubbleSort_RemoveZero(sData, sData.Length)

        nMeasChannel = sData.Clone
        Return True
    End Function

    Private Sub btnACFStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACFStart.Click
        Dim nMeasChannel() As Integer = Nothing
        Dim sACFChannel As String
        Dim ACFOptions As frmOptionWindow.sACF = g_SystemOptions.sOptionData.ACFData
        Dim sChannel As String = Nothing
        Dim nCheckChannel As Integer

        sACFChannel = tbACFChannel.Text
        tbACFMeasState.Text = ""

        If tbACFSavePath.Text = "" Then
            MsgBox("SavePath 설정을 확인해 주세요...")
            Exit Sub
        End If

        If ChannelStringToACFMeasChannel(sACFChannel, nMeasChannel) = False Then
            MsgBox("ACF Meas 채널 입력을 확인해 주세요...")
            Exit Sub
        End If

        For i As Integer = 0 To nMeasChannel.Length - 1
            If myParent.cTimeScheduler.g_ChSchedulerStatus(nMeasChannel(i)) <> CScheduler.eChSchedulerSTATE.eIdle Then
                nCheckChannel += 1
                sChannel = sChannel & "Ch" & Format(nMeasChannel(i), "00") & "/"
            End If
        Next

        If nCheckChannel <> 0 Then
            MsgBox("실험중인 채널은 사용 할 수 없습니다...(" & sChannel & ")")
        End If

        Application.DoEvents()
        Thread.Sleep(500)

        tbACFMeasState.Text = "ACF 실험이 시작 되었습니다..."

        Enable_gbMotion(False)
        Enable_gbSourceCtrl(False)
        Enable_gbACFCameraCtrl(False)
        Enable_gbACFCtrl(False)
        Enable_gbACFMeas(False)
        Enable_gbStrobe(False)

        m_bACFMeas = True

        For i As Integer = 0 To nMeasChannel.Length - 1
            tbACFMeasState.Text = "Ch" & Format(nMeasChannel(i), "00") & " ACF 실험 진행 중입니다..."
            If m_bACFMeas = False Then
                Exit For
            End If

            'ACF 진행
            'If RunACF(nMeasChannel(i) - 1, ACFOptions, frmOptionWindow.eACFMode.eEnable_AutoCenteringAndFocusing, ucSampleInfos.eSampleType.eCell, _
            '         m_saveInfo, ucSequenceBuilder.eRcpMode.eNothing, True, 0, False) = False Then
            'End If

        Next

        Enable_gbMotion(True)
        Enable_gbSourceCtrl(True)
        Enable_gbACFCameraCtrl(True)
        Enable_gbACFCtrl(True)
        Enable_gbACFMeas(True)
        Enable_gbStrobe(True)

        m_bACFMeas = False

        tbACFMeasState.Text = "ACF 실험이 완료 되었습니다..."
    End Sub

    Private Sub btnACFStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACFStop.Click
        m_bACFMeas = False
    End Sub

    Private Sub btnSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePath.Click
        Dim file As New CMcFile

        tbACFSavePath.Text = ""

        If file.GetSaveFileName(CMcFile.eFileType._BMP, m_saveInfo) = False Then
            MsgBox("Save Path Fail...")
        Else
            tbACFSavePath.Text = m_saveInfo.strPathAndFName
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' myParent.cStrobe.TurnOn()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  myParent.cStrobe.TurnOff()
    End Sub

    Public Event evLIVE(ByVal bChecked As Boolean)

    Private Sub chkLiveOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub Homming()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Homming ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing

        myParent.cPLC.Request(reqInfo)
        Application.DoEvents()
        Thread.Sleep(1000)

        MoveCompletedAllAxis()
    End Sub
    Public Function XMove(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_X ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                '  reqInfo.Param(0) = (myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(0) = (position * 1000) ' (myParent.cPLC.CurrentPosition(0)) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Application.DoEvents()
        Thread.Sleep(500)

        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eX)
        Return True
    End Function

    Public Function Theta1Move(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta1  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)

        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) '(myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Thread.Sleep(100)
        Application.DoEvents()
        '정현기
        'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA1)

        Return True
    End Function

    Public Function Theta2Move(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta2  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)

        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) '(myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Thread.Sleep(100)
        Application.DoEvents()
        '정현기
        'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA2)

        Return True
    End Function

    Public Function Theta3Move(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta3  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)

        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) '(myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Thread.Sleep(100)
        Application.DoEvents()
        '정현기
        'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA3)

        Return True
    End Function

    Public Function Theta4Move(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta4  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)

        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) '(myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Thread.Sleep(100)
        Application.DoEvents()
        '정현기
        'MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eTHETA4)

        Return True
    End Function

    'Public Function ThetaHomming() As Boolean

    '    Dim reqInfo As CDevPLCCommonNode.sRequestInfo

    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta1  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    ReDim reqInfo.Param(1)

    '    Try

    '        reqInfo.Param(0) = 0 * 1000
    '        reqInfo.Param(1) = g_ConfigInfos.MotionConfig(2).dVelocity * 1000
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try

    '    myParent.cPLC.Request(reqInfo)

    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta2  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    ReDim reqInfo.Param(1)

    '    Try

    '        reqInfo.Param(0) = 0 * 1000
    '        reqInfo.Param(1) = g_ConfigInfos.MotionConfig(3).dVelocity * 1000
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try

    '    myParent.cPLC.Request(reqInfo)


    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta3  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    ReDim reqInfo.Param(1)

    '    Try

    '        reqInfo.Param(0) = 0 * 1000
    '        reqInfo.Param(1) = g_ConfigInfos.MotionConfig(4).dVelocity * 1000
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try

    '    myParent.cPLC.Request(reqInfo)


    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Theta4  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    ReDim reqInfo.Param(1)

    '    Try

    '        reqInfo.Param(0) = 0 * 1000
    '        reqInfo.Param(1) = g_ConfigInfos.MotionConfig(5).dVelocity * 1000
    '        reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        Return False
    '    End Try

    '    myParent.cPLC.Request(reqInfo)


    '    MoveCompletedThetaAxis()

    '    Return True
    'End Function


    Public Function YMove(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Y ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)

        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) '(myParent.cPLC.CurrentPosition(1) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)

        Thread.Sleep(100)
        Application.DoEvents()
        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eY)
        '  Thread.Sleep(100)
        '  Application.DoEvents()
        Return True
    End Function
    Public Function ZMove(ByVal position As Double, ByVal velocity As Integer, ByVal MovingMethod As CDevPLCCommonNode.eMovingMethod) As Boolean
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Move_Z ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        ReDim reqInfo.Param(1)
        Try
            If MovingMethod = CDevPLCCommonNode.eMovingMethod.eABS Then

                'If position < 0 Then
                '    MsgBox("음수 일 수 없습니다.")
                '    Return False
                'Else
                reqInfo.Param(0) = position * 1000
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eABS
                '  End If
            Else
                reqInfo.Param(0) = (position * 1000) ' (myParent.cPLC.CurrentPosition(2) * 1000) + (position * 1000) ' (ucMotionIndicator.XPos * 1000) + (position * 1000)
                reqInfo.Param(1) = velocity * 1000
                reqInfo.eMovingMethod = CDevPLCCommonNode.eMovingMethod.eINC
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        myParent.cPLC.Request(reqInfo)


        Thread.Sleep(100)
        Application.DoEvents()
        MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eZ)
     
        Return True
    End Function
    Public Sub MoveCompletedAllAxis(ByVal Axis As CDevPLCCommonNode.eAxis)
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        If Axis = CDevPLCCommonNode.eAxis.eX Then
            myParent.cPLC.XMoveCompleted = False
            Do
                Thread.Sleep(100)
                Application.DoEvents()
            Loop Until myParent.cPLC.XMoveCompleted = True

            '완료 후 ACK 신호 날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eX
            myParent.cPLC.Request(reqInfo)


        ElseIf Axis = CDevPLCCommonNode.eAxis.eY Then
            myParent.cPLC.YMoveCompleted = False
            Do
                Thread.Sleep(100)
                Application.DoEvents()
            Loop Until myParent.cPLC.YMoveCompleted = True

            '완료 후 ACK 신호 날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eY
            myParent.cPLC.Request(reqInfo)


        ElseIf Axis = CDevPLCCommonNode.eAxis.eZ Then
            myParent.cPLC.ZMoveCompleted = False
            Do
                Thread.Sleep(100)
                Application.DoEvents()
            Loop Until myParent.cPLC.ZMoveCompleted = True

            '완료 후 ACK 신호 날림
            reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            reqInfo.Param = Nothing
            ReDim reqInfo.Param(0)
            reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eZ
            myParent.cPLC.Request(reqInfo)

            'ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA1 Then
            '    myParent.cPLC.Theta1MoveCompleted = False
            '    Do
            '        Thread.Sleep(100)
            '        Application.DoEvents()
            '    Loop Until myParent.cPLC.Theta1MoveCompleted = True

            '    '완료 후 ACK 신호 날림
            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    reqInfo.Param = Nothing
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA1
            '    myParent.cPLC.Request(reqInfo)


            'ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA2 Then
            '    myParent.cPLC.Theta2MoveCompleted = False
            '    Do
            '        Thread.Sleep(100)
            '        Application.DoEvents()
            '    Loop Until myParent.cPLC.Theta2MoveCompleted = True

            '    '완료 후 ACK 신호 날림
            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    reqInfo.Param = Nothing
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA2
            '    myParent.cPLC.Request(reqInfo)


            'ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA3 Then
            '    myParent.cPLC.Theta3MoveCompleted = False
            '    Do
            '        Thread.Sleep(100)
            '        Application.DoEvents()
            '    Loop Until myParent.cPLC.Theta3MoveCompleted = True

            '    '완료 후 ACK 신호 날림
            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    reqInfo.Param = Nothing
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA3
            '    myParent.cPLC.Request(reqInfo)


            'ElseIf Axis = CDevPLCCommonNode.eAxis.eTHETA4 Then
            '    myParent.cPLC.Theta4MoveCompleted = False
            '    Do
            '        Thread.Sleep(100)
            '        Application.DoEvents()
            '    Loop Until myParent.cPLC.Theta4MoveCompleted = True

            '    '완료 후 ACK 신호 날림
            '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
            '    reqInfo.Param = Nothing
            '    ReDim reqInfo.Param(0)
            '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA4
            '    myParent.cPLC.Request(reqInfo)

        End If
    End Sub

    Public Sub MoveCompletedAllAxis()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        Application.DoEvents()
        Thread.Sleep(100)
        myParent.cPLC.XMoveCompleted = False
        Do
            Thread.Sleep(100)
            Application.DoEvents()
        Loop Until myParent.cPLC.XMoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eX
        myParent.cPLC.Request(reqInfo)

        myParent.cPLC.YMoveCompleted = False
        Do
            Thread.Sleep(100)
            Application.DoEvents()
        Loop Until myParent.cPLC.YMoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eY
        myParent.cPLC.Request(reqInfo)

        myParent.cPLC.ZMoveCompleted = False
        Do
            Thread.Sleep(100)
            Application.DoEvents()
        Loop Until myParent.cPLC.ZMoveCompleted = True

        '완료 후 ACK 신호 날림
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        ReDim reqInfo.Param(0)
        reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eZ
        myParent.cPLC.Request(reqInfo)

        'myParent.cPLC.Theta1MoveCompleted = False
        'Do
        '    Thread.Sleep(100)
        '    Application.DoEvents()
        'Loop Until myParent.cPLC.Theta1MoveCompleted = True

        ''완료 후 ACK 신호 날림
        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'ReDim reqInfo.Param(0)
        'reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA1
        'myParent.cPLC.Request(reqInfo)

        'myParent.cPLC.Theta2MoveCompleted = False
        'Do
        '    Thread.Sleep(100)
        '    Application.DoEvents()
        'Loop Until myParent.cPLC.Theta2MoveCompleted = True

        ''완료 후 ACK 신호 날림
        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'ReDim reqInfo.Param(0)
        'reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA2
        'myParent.cPLC.Request(reqInfo)

        'myParent.cPLC.Theta3MoveCompleted = False
        'Do
        '    Thread.Sleep(100)
        '    Application.DoEvents()
        'Loop Until myParent.cPLC.Theta3MoveCompleted = True

        ''완료 후 ACK 신호 날림
        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'ReDim reqInfo.Param(0)
        'reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA3
        'myParent.cPLC.Request(reqInfo)

        'myParent.cPLC.Theta4MoveCompleted = False
        'Do
        '    Thread.Sleep(100)
        '    Application.DoEvents()
        'Loop Until myParent.cPLC.Theta4MoveCompleted = True

        ''완료 후 ACK 신호 날림
        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'ReDim reqInfo.Param(0)
        'reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA4
        'myParent.cPLC.Request(reqInfo)
    End Sub
    'Public Sub MoveCompletedThetaAxis()
    '    Dim reqInfo As CDevPLCCommonNode.sRequestInfo
    '    '   Application.DoEvents()
    '    '  Thread.Sleep(100)

    '    myParent.cPLC.Theta1MoveCompleted = False
    '    Do
    '        Thread.Sleep(50)
    '        Application.DoEvents()
    '    Loop Until myParent.cPLC.Theta1MoveCompleted = True

    '    '완료 후 ACK 신호 날림
    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    reqInfo.Param = Nothing
    '    ReDim reqInfo.Param(0)
    '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA1
    '    myParent.cPLC.Request(reqInfo)

    '    myParent.cPLC.Theta2MoveCompleted = False
    '    Do
    '        Thread.Sleep(50)
    '        Application.DoEvents()
    '    Loop Until myParent.cPLC.Theta2MoveCompleted = True

    '    '완료 후 ACK 신호 날림
    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    reqInfo.Param = Nothing
    '    ReDim reqInfo.Param(0)
    '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA2
    '    myParent.cPLC.Request(reqInfo)

    '    myParent.cPLC.Theta3MoveCompleted = False
    '    Do
    '        Thread.Sleep(50)
    '        Application.DoEvents()
    '    Loop Until myParent.cPLC.Theta3MoveCompleted = True

    '    '완료 후 ACK 신호 날림
    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    reqInfo.Param = Nothing
    '    ReDim reqInfo.Param(0)
    '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA3
    '    myParent.cPLC.Request(reqInfo)

    '    myParent.cPLC.Theta4MoveCompleted = False
    '    Do
    '        Thread.Sleep(50)
    '        Application.DoEvents()
    '    Loop Until myParent.cPLC.Theta4MoveCompleted = True

    '    '완료 후 ACK 신호 날림
    '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
    '    reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Complete_ACK ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
    '    reqInfo.Param = Nothing
    '    ReDim reqInfo.Param(0)
    '    reqInfo.Param(0) = CDevPLCCommonNode.eAxis.eTHETA4
    '    myParent.cPLC.Request(reqInfo)
    'End Sub

    Public Sub SetStop()
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Set_Jog_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        reqInfo.Param = Nothing
        myParent.cPLC.Request(reqInfo)


        'reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        'reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_Pos_Stop ' CDevPLC.eSystemStatus.ePauseAndProcess 'state
        'reqInfo.Param = Nothing
        'myParent.cPLC.Request(reqInfo)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnJOGMode_ON.Click

        btnJOGMode_ON.BackColor = Color.OrangeRed
        JogMode = True
        btnJOGMode_OFF.BackColor = Color.Silver

        Thread.Sleep(10)    '전환 시 약간 대기 필요

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo = Nothing

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_ON
        reqInfo.Param = Nothing

        myParent.cPLC.Request(reqInfo)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnJOGMode_OFF.Click
        btnJOGMode_OFF.BackColor = Color.OrangeRed
        JogMode = False
        btnJOGMode_ON.BackColor = Color.Silver

        Thread.Sleep(10) '전환 시 약간 대기 필요

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo = Nothing

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
        reqInfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_OFF
        reqInfo.Param = Nothing

        myParent.cPLC.Request(reqInfo)
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'If myParent.cPLC.IsConnected = False Then
        '    MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
        '    Exit Sub
        'End If

        'Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        'ControlEnable(False)

        'If rbAbs.Checked = True Then
        '    Theta3Move(dDist, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Else
        '    Theta3Move(dDist, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        'End If

        ''myParent.cMotion.AxisMove(2, dDist, rbAbs.Checked)
        ''myParent.cMotion.ZMove(dDist, rbAbs.Checked)
        'ControlEnable(True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If myParent.cPLC.IsConnected = False Then
        '    MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
        '    Exit Sub
        'End If

        'Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        'ControlEnable(False)

        'If rbAbs.Checked = True Then
        '    Theta2Move(dDist, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Else
        '    Theta2Move(dDist, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        'End If

        ''myParent.cMotion.AxisMove(2, dDist, rbAbs.Checked)
        ''myParent.cMotion.ZMove(dDist, rbAbs.Checked)
        'ControlEnable(True)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'If myParent.cPLC.IsConnected = False Then
        '    MsgBox("Motion 과 연결이 되지 않았습니다!!", MsgBoxStyle.Critical, "Care!!")
        '    Exit Sub
        'End If

        'Dim dDist As Double = frmBuilderSettings.ConvertToDouble(txtPosition.Text)

        'ControlEnable(False)

        'If rbAbs.Checked = True Then
        '    Theta4Move(dDist, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
        'Else
        '    Theta4Move(dDist, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eINC)
        'End If

        ''myParent.cMotion.AxisMove(2, dDist, rbAbs.Checked)
        ''myParent.cMotion.ZMove(dDist, rbAbs.Checked)
        'ControlEnable(True)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


        'ControlEnable(False)
        'ThetaHomming()
        'Application.DoEvents()
        'Thread.Sleep(1000)
        'ControlEnable(True)
    End Sub
End Class