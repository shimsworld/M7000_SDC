Public Class frmLogWin
    Inherits System.Windows.Forms.Form

#Region " Windows Form 디자이너에서 생성한 코드 "

    Public Sub New(ByVal nMaxCh As Integer)
        MyBase.New()

        '이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()

        'InitializeComponent()를 호출한 다음에 초기화 작업을 추가하십시오.
        m_nMaxCh = nMaxCh
        initCtrl()
    End Sub

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblSchedulerCnt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    'Windows Form 디자이너를 사용하여 수정할 수 있습니다.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    Friend WithEvents pn1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pn1 = New System.Windows.Forms.Panel()
        Me.lblSchedulerCnt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pn1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pn1
        '
        Me.pn1.AutoScroll = True
        Me.pn1.Controls.Add(Me.lblSchedulerCnt)
        Me.pn1.Controls.Add(Me.Label1)
        Me.pn1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pn1.Location = New System.Drawing.Point(0, 0)
        Me.pn1.Name = "pn1"
        Me.pn1.Size = New System.Drawing.Size(993, 565)
        Me.pn1.TabIndex = 0
        '
        'lblSchedulerCnt
        '
        Me.lblSchedulerCnt.AutoSize = True
        Me.lblSchedulerCnt.Location = New System.Drawing.Point(151, 9)
        Me.lblSchedulerCnt.Name = "lblSchedulerCnt"
        Me.lblSchedulerCnt.Size = New System.Drawing.Size(23, 12)
        Me.lblSchedulerCnt.TabIndex = 1
        Me.lblSchedulerCnt.Text = "000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Scheduler Counter :"
        '
        'frmLogWin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(993, 565)
        Me.ControlBox = False
        Me.Controls.Add(Me.pn1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogWin"
        Me.Text = "frmLogWin"
        Me.pn1.ResumeLayout(False)
        Me.pn1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Delegate"

    Private Delegate Sub DelSetString(ByVal ch As Integer, ByVal str As String)
    Private Delegate Sub DelString(ByVal str As String)

    Public Sub SetStateMsg(ByVal ch As Integer, ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If tbFlagState(ch).InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf SetStateMsg)
            Try
                Invoke(del2, ch, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbFlagState(ch).Text = str
            ' ListView1.Items.Insert(nRow, New Object() {item})
        End If
    End Sub

    Public Sub SetStartTime(ByVal ch As Integer, ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If tbStartTime(ch).InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf SetStartTime)
            Try
                Invoke(del2, ch, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbStartTime(ch).Text = str
        End If
    End Sub

    Public Sub SchedulerCounter(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If lblSchedulerCnt.InvokeRequired = True Then
            Dim del2 As DelString = New DelString(AddressOf SchedulerCounter)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblSchedulerCnt.Text = str
        End If
    End Sub

#End Region

    Private m_nMaxCh As Integer

    Dim tbStartTime() As System.Windows.Forms.TextBox
    Dim tbFlagState() As System.Windows.Forms.TextBox

    Private Sub initCtrl()

        Dim i As Integer

        ReDim tbStartTime(m_nMaxCh - 1)
        ReDim tbFlagState(m_nMaxCh - 1)

        For i = 0 To m_nMaxCh - 1
            SetLocation_tbStartTime(i)
            SetLocation_tbFlagState(i)
        Next
    End Sub


    Private Sub SetLocation_tbStartTime(ByVal in_Num As Integer)

        Dim lblLocation_X, lblLocation_Y, lblSize_H, lblSize_W As Double
        Dim dH As Integer = 1

        tbStartTime(in_Num) = New System.Windows.Forms.TextBox

        Me.pn1.Controls.Add(tbStartTime(in_Num))

        lblSize_H = 21
        lblSize_W = 280
        lblLocation_X = 8  '48
        lblLocation_Y = 50 + lblSize_H * in_Num

        'ratio_X = 296
        'ratio_Y = 72

        With tbStartTime(in_Num)

            .AccessibleRole = AccessibleRole.Default
            .BorderStyle = BorderStyle.Fixed3D
            .Font = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
            .BackColor = Color.Black
            .ForeColor = Color.Cyan
            .Location = New System.Drawing.Point(lblLocation_X, lblLocation_Y)
            .Size = New System.Drawing.Size(lblSize_W, lblSize_H)
            .Name = "tbStartTime" & Format(in_Num + 1, "0")
            .TextAlign = HorizontalAlignment.Right
            '.TextAlign = 'System.Drawing.ContentAlignment.MiddleRight
            .TabIndex = in_Num ' + g_nMaxCh
            .Tag = in_Num '+ g_nMaxCh
            .Text = "0.000"
        End With


    End Sub

    Private Sub SetLocation_tbFlagState(ByVal in_Num As Integer)

        Dim lblLocation_X, lblLocation_Y, lblSize_H, lblSize_W As Double
        Dim dH As Integer = 1

        tbFlagState(in_Num) = New System.Windows.Forms.TextBox

        Me.pn1.Controls.Add(tbFlagState(in_Num))

        lblSize_H = 21
        lblSize_W = 600
        lblLocation_X = 288  '48
        lblLocation_Y = 50 + lblSize_H * in_Num

        'ratio_X = 296
        'ratio_Y = 72

        With tbFlagState(in_Num)

            .AccessibleRole = AccessibleRole.Default
            .BorderStyle = BorderStyle.Fixed3D
            .Font = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
            .BackColor = Color.Black
            .ForeColor = Color.Cyan
            .Location = New System.Drawing.Point(lblLocation_X, lblLocation_Y)
            .Size = New System.Drawing.Size(lblSize_W, lblSize_H)
            .Name = "tbFlagState" & Format(in_Num + 1, "0")
            .TextAlign = HorizontalAlignment.Right
            '.TextAlign = 'System.Drawing.ContentAlignment.MiddleRight
            .TabIndex = in_Num ' + g_nMaxCh
            .Tag = in_Num '+ g_nMaxCh
            .Text = "0.000"
        End With


    End Sub



End Class
