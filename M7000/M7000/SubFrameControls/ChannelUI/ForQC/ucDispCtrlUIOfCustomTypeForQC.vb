Public Class ucDispCtrlUIOfCustomTypeForQC
    Inherits M7000.ucDispCtrlUICommonNode

#Region "Defines"


    Public Event evClickLoadSequence(ByVal ch As Integer)
    Public Event evClickSaveSeqeunce(ByVal ch As Integer)
    Public Event evClickEditSequence(ByVal ch As Integer)

  



    Dim m_dTemp As Double

#End Region


#Region "Delegate Functions"

    Private Delegate Sub DelSetString(ByVal str As String)
    Private Delegate Sub DelSetDouble(ByVal dValue As Double)
    Private Delegate Sub DelSetInteger(ByVal nVal As Integer)
    Private Delegate Sub DelSetProgress(ByVal current As Integer, ByVal total As Integer)
    Private Delegate Sub DelSetTimeSpan(ByVal value As TimeSpan)
    Private Delegate Sub DelSetTimeValue(ByVal value As CTime.sTimeValue)
    'Private Delegate Sub delSetMode(ByVal eMode As CDevM6000.eMode)
    'Private Delegate Sub DelSetEndPara(ByVal Endpara As ucTestEndParam.sTestEndParam())
    ''Private Delegate Sub DelInidiacatorVlaue(ByVal Indicatora As sIndicator)
    'Delegate Sub DelLIst(ByVal nrow As Integer, ByVal str() As String)


    Public Sub Status(ByVal nState As CScheduler.eChSchedulerSTATE)
        If lblStatus.InvokeRequired = True Then
            Dim Del2 As DelSetInteger = New DelSetInteger(AddressOf Status)
            Try
                Invoke(Del2, nState)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblStatus.Text = CScheduler.GetStateCaptions(nState) 'sStatus(nState)
        End If
    End Sub


    Public Sub Result(ByVal sResult As String)
        If lblResult.InvokeRequired = True Then
            Dim Del2 As DelSetString = New DelSetString(AddressOf Result)
            Try
                Invoke(Del2, sResult)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblResult.Text = sResult
        End If
    End Sub

    Public Sub RecipeTitle(ByVal sRcpName As String)
        If lblRecipeName.InvokeRequired = True Then
            Dim Del2 As DelSetString = New DelSetString(AddressOf RecipeTitle)
            Try
                Invoke(Del2, sRcpName)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblRecipeName.Text = sRcpName
        End If
    End Sub


    Public Sub Progress(ByVal current As Integer, ByVal total As Integer)
        If lblProgress.InvokeRequired = True Then
            Dim Del2 As DelSetProgress = New DelSetProgress(AddressOf Progress)
            Try
                Invoke(Del2, current, total)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblProgress.Text = Format(current, "00") & " of " & Format(total, "00")
        End If
    End Sub

    Public Sub Set_IndicatorValue_Stop(ByVal sMessage As String)
        'If Me.lblValue_Stop.InvokeRequired = True Then
        '    Dim Del2 As DelSetString = New DelSetString(AddressOf Set_IndicatorValue_Stop)
        '    Try
        '        Invoke(Del2, sMessage)
        '    Catch ex As Exception
        '        Exit Sub
        '    End Try
        'Else
        '    If sMessage = "[-]" Then
        '        lblValue_Stop.Text = sMessage
        '        lblValue_Stop.BackColor = Color.White
        '    Else
        '        lblValue_Stop.Text = sMessage
        '        lblValue_Stop.BackColor = Color.OrangeRed
        '    End If
        'End If
    End Sub

    Private Sub DispTemperature(ByVal dVal As Double)
        If lblTemp.InvokeRequired = True Then
            Dim Del2 As DelSetDouble = New DelSetDouble(AddressOf DispTemperature)
            Try
                Invoke(Del2, dVal)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblTemp.Text = Format(dVal, "00.00")
        End If
    End Sub

    Public Sub Cycle(ByVal nVal As Integer)
        If lblLoopCounter.InvokeRequired = True Then
            Dim Del2 As DelSetInteger = New DelSetInteger(AddressOf Cycle)
            Try
                Invoke(Del2, nVal)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblLoopCounter.Text = Format(nVal, "000")
        End If
    End Sub

    Public Sub Etc(ByVal str As String)
        If lblReserve.InvokeRequired = True Then
            Dim Del2 As DelSetString = New DelSetString(AddressOf Etc)
            Try
                Invoke(Del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblReserve.Text = str
        End If
    End Sub


    Public Sub TotalTime_Current(ByVal sTime As TimeSpan)
        If lblTotalTime_Current.InvokeRequired = True Then
            Dim Del2 As DelSetTimeSpan = New DelSetTimeSpan(AddressOf TotalTime_Current)
            Try
                Invoke(Del2, sTime)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblTotalTime_Current.Text = Format(sTime.Hours, "00") & ":" & Format(sTime.Minutes, "00") & ":" & Format(sTime.Seconds, "00")
        End If
    End Sub

    Public Sub TotalTime_SetValue(ByVal sTime As CTime.sTimeValue)
        If lblTotalTime_SetValue.InvokeRequired = True Then
            Dim Del2 As DelSetTimeValue = New DelSetTimeValue(AddressOf TotalTime_SetValue)
            Try
                Invoke(Del2, sTime)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblTotalTime_SetValue.Text = CTime.Convert_HourToHMS(sTime.dHour) ' Format(sTime(0), "00") & ":" & Format(sTime(1), "00") & ":" & Format(sTime(2), "00")
        End If
    End Sub

    Public Sub ModeTime_Current(ByVal sTime As TimeSpan)
        If lblModeTime_Current.InvokeRequired = True Then
            Dim Del2 As DelSetTimeSpan = New DelSetTimeSpan(AddressOf ModeTime_Current)
            Try
                Invoke(Del2, sTime)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblModeTime_Current.Text = Format(sTime.Hours, "00") & ":" & Format(sTime.Minutes, "00") & ":" & Format(sTime.Seconds, "00")
        End If
    End Sub

    Public Sub ModeTime_SetValue(ByVal sTime As CTime.sTimeValue)
        If lblModeTime_SetValue.InvokeRequired = True Then
            Dim Del2 As DelSetTimeValue = New DelSetTimeValue(AddressOf ModeTime_SetValue)
            Try
                Invoke(Del2, sTime)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblModeTime_SetValue.Text = CTime.Convert_HourToHMS(sTime.dHour) 'Format(sTime(0), "00") & ":" & Format(sTime(1), "00") & ":" & Format(sTime(2), "00")
        End If
    End Sub


#End Region

#Region "Creator And Initilization"

    Public Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        m_nType = eType.CustomTypeForQC

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill

        labelState.Location = New System.Drawing.Point(0, 0)
        labelState.Dock = DockStyle.Fill

        labelResult.Location = New System.Drawing.Point(0, 0)
        labelResult.Dock = DockStyle.Fill


        labelProgress.Location = New System.Drawing.Point(0, 0)
        labelProgress.Dock = DockStyle.Fill

        labelTotalTime.Location = New System.Drawing.Point(0, 0)
        labelTotalTime.Dock = DockStyle.Fill

        labelModeTime.Location = New System.Drawing.Point(0, 0)
        labelModeTime.Dock = DockStyle.Fill

        labelRecipe.Location = New System.Drawing.Point(0, 0)
        labelRecipe.Dock = DockStyle.Fill

        labelTemp.Location = New System.Drawing.Point(0, 0)
        labelTemp.Dock = DockStyle.Fill

        labelLoop.Location = New System.Drawing.Point(0, 0)
        labelLoop.Dock = DockStyle.Fill

        labelReserve.Location = New System.Drawing.Point(0, 0)
        labelReserve.Dock = DockStyle.Fill


        lblStatus.Location = New System.Drawing.Point(0, 0)
        lblStatus.Dock = DockStyle.Fill

        lblResult.Location = New System.Drawing.Point(0, 0)
        lblResult.Dock = DockStyle.Fill

        lblProgress.Location = New System.Drawing.Point(0, 0)
        lblProgress.Dock = DockStyle.Fill

        spcTotalTime.Location = New System.Drawing.Point(0, 0)
        spcTotalTime.Dock = DockStyle.Fill

        spcModeTime.Location = New System.Drawing.Point(0, 0)
        spcModeTime.Dock = DockStyle.Fill

        lblTotalTime_SetValue.Location = New System.Drawing.Point(0, 0)
        lblTotalTime_SetValue.Dock = DockStyle.Fill

        lblTotalTime_Current.Location = New System.Drawing.Point(0, 0)
        lblTotalTime_Current.Dock = DockStyle.Fill

        lblModeTime_SetValue.Location = New System.Drawing.Point(0, 0)
        lblModeTime_SetValue.Dock = DockStyle.Fill

        lblModeTime_Current.Location = New System.Drawing.Point(0, 0)
        lblModeTime_Current.Dock = DockStyle.Fill

        lblRecipeName.Dock = DockStyle.Fill

        lblTemp.Location = New System.Drawing.Point(0, 0)
        lblTemp.Dock = DockStyle.Fill

        lblLoopCounter.Location = New System.Drawing.Point(0, 0)
        lblLoopCounter.Dock = DockStyle.Fill

        lblReserve.Location = New System.Drawing.Point(0, 0)
        lblReserve.Dock = DockStyle.Fill

        btnLoad.Location = New System.Drawing.Point(0, 0)
        btnLoad.Dock = DockStyle.Fill

        btnSave.Location = New System.Drawing.Point(0, 0)
        btnSave.Dock = DockStyle.Fill

        btnEdit.Location = New System.Drawing.Point(0, 0)
        btnEdit.Dock = DockStyle.Fill

        tlpFuncButton.Location = New System.Drawing.Point(0, 0)
        tlpFuncButton.Dock = DockStyle.Fill

        pnChSelector.Location = New System.Drawing.Point(0, 0)
        pnChSelector.Dock = DockStyle.Fill

        chkCh.Location = New System.Drawing.Point(0, 0)
        chkCh.Dock = DockStyle.Fill
    End Sub

#End Region


#Region "Property"

    Public Overrides Property Channel As Integer
        Get
            Return MyBase.Channel
        End Get
        Set(ByVal value As Integer)
            MyBase.Channel = value
            '   sequenceMgr.Index = MyBase.Channel
            chkCh.Text = "CH" & Format(m_nChannel + 1, "00")
        End Set
    End Property

    Public Property IsSelected As Integer
        Get
            Return chkCh.Checked
        End Get
        Set(ByVal value As Integer)
            chkCh.Checked = value
        End Set
    End Property

    Public Property Temperature As Double
        Get
            Return m_dTemp
        End Get
        Set(ByVal value As Double)
            m_dTemp = value
            DispTemperature(m_dTemp)
        End Set
    End Property

#End Region


#Region "Control Event Handler Functions"

    Private Sub chkCh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCh.CheckedChanged

        If chkCh.Checked = False Then
            chkCh.BackColor = Color.LightGray
        Else
            chkCh.BackColor = Color.Green
        End If

    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        RaiseEvent evClickLoadSequence(MyBase.Channel)
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        RaiseEvent evClickSaveSeqeunce(MyBase.Channel)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        RaiseEvent evClickEditSequence(MyBase.Channel)
    End Sub

#End Region






End Class
