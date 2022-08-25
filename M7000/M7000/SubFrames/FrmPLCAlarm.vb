Public Class frmPLCAlarm
    Public strDIName() As String = New String() {"Fan Alarm 1", "Fan Alarm 2", "Fan Alarm 3", "Fan Alarm 4", "Fan Alarm 5", "Fan Alarm 6", "Smoke Alarm", "Temp Alarm(Light)", "Temp Alarm(Heavy}"}

    'Dim strCommonDIName() As String = New String() {"PANEL TEMP OVER #1-1", "PANEL TEMP OVER #1-2", "EMERGENCY STOP", "SMOKE ERROR", _
    '                                                "Coolingfan#1 ALARM", "Coolingfan#2 ALARM", "Coolingfan#3 ALARM", "Coolingfan#4 ALARM", _
    '                                                "Coolingfan#5 ALARM", "Coolingfan#6 ALARM", "Coolingfan#7 ALARM", "Coolingfan#8 ALARM"}

    Public ucMonitoring() As ucMonitorControl
    Public ucCommonMonitoring As ucMonitorControl

    Dim m_Parent As frmMain
    Private Delegate Sub DelCallSub()
    'Public Sub New(ByVal myParent As frmMain)

    '    ' 이 호출은 디자이너에 필요합니다.
    '    InitializeComponent()

    '    ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
    '    m_Parent = myParent

    '    init()
    'End Sub
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        'm_Parent = myParent

        init()
    End Sub

    Public Sub init()
        ' g_sSystemOption.sChIndicator.nColumnSize = 1
        ReDim ucMonitoring(0)

        For idx As Integer = 0 To 0
            If idx = 0 Then
                ucMonitoring(idx) = New UcMonitorControl(9, 3, False)
            Else
                ucMonitoring(idx) = New UcMonitorControl(9, 3, False)
            End If

            '  ucMonitoring(idx).lblControlName.Text = "Chamber ALARM (Zone # 0" & +idx + 1 & ")"

            ' If idx = 0 Then
            For jdx As Integer = 0 To strDIName.Length - 1
                ucMonitoring(idx).ucCH(jdx).lblName.Text = strDIName(jdx)
            Next
            'ElseIf idx = 1 Then
            '    For jdx As Integer = 0 To strDIName1.Length - 1
            '        ucMonitoring(idx).ucCH(jdx).lblName.Text = strDIName1(jdx)
            '    Next
            'Else
            '    For jdx As Integer = 0 To strDIName2.Length - 1
            '        ucMonitoring(idx).ucCH(jdx).lblName.Text = strDIName2(jdx)
            '    Next
            'End If

            Controls.Add(ucMonitoring(idx))
            ucMonitoring(idx).BringToFront()

            ' If idx = 0 Then
            ucMonitoring(idx).Location = New Point(0, 2 + (idx * ucMonitoring(idx).Height))
            'ElseIf idx = 1 Then
            'ucMonitoring(idx).Location = New Point(0, 10 + (idx * ucMonitoring(idx).Height) - 11)
            'ElseIf idx = 2 Then
            'ucMonitoring(idx).Location = New Point(0, 15 + (idx * ucMonitoring(idx).Height) - 20)
            'End If

            ucMonitoring(idx).AutoScroll = True
        Next

        'ucCommonMonitoring = New ucMonitorControl(12, 2, True)
        'ucCommonMonitoring.lblControlName.Text = "Common ALARM"
        'For idx As Integer = 0 To strCommonDIName.Length - 1
        '    ucCommonMonitoring.ucCH(idx).lblName.Text = strCommonDIName(idx)
        '    Controls.Add(ucCommonMonitoring)
        '    ucCommonMonitoring.BringToFront()
        '    ucCommonMonitoring.Location = New Point(-15, 5 + (2 * ucMonitoring(2).Height) + 240)
        '    ucCommonMonitoring.AutoScroll = True
        'Next

        'ucMonitoring.BorderStyle = BorderStyle.FixedSingle

        Me.Size = New Size(ucMonitoring(0).Size.Width, ucMonitoring(0).Size.Height) ', ucMonitoring(0).Size.Height + ucMonitoring(1).Size.Height + ucMonitoring(2).Size.Height + 30)

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
    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        Me.Hide()
    End Sub

    Public Sub ChangeChamberAlarmStatus(ByVal nZone As Integer, ByVal nDI As Integer, ByVal bOn As Boolean)
        If bOn = True Then
            ucMonitoring(nZone).ucCH(nDI).ledStatus.LedColor = Color.Red
            ucMonitoring(nZone).ucCH(nDI).lblName.BackColor = Color.Red
        Else
            ucMonitoring(nZone).ucCH(nDI).ledStatus.LedColor = Color.DarkGray
            ucMonitoring(nZone).ucCH(nDI).lblName.BackColor = Color.Gray
        End If
    End Sub

    'Public Sub ChangeChamberPLCStatus(ByVal nDI As Integer, ByVal bOn As Boolean)
    '    If bOn = True Then
    '        ucCommonMonitoring.ucCH(nDI).ledStatus.LedColor = Color.Red
    '        ucCommonMonitoring.ucCH(nDI).lblName.BackColor = Color.Red
    '    Else
    '        ucCommonMonitoring.ucCH(nDI).ledStatus.LedColor = Color.DarkGray
    '        ucCommonMonitoring.ucCH(nDI).lblName.BackColor = Color.Gray
    '    End If
    'End Sub
End Class