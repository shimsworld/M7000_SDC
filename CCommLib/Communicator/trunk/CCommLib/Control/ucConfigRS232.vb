Imports System
Imports System.IO.Ports

Public Class ucConfigRs232

#Region "Define String"

    Private g_nBaudTable() As Integer = New Integer() {50, 75, 110, 134, 150, 300, 600, _
                                                       1200, 1800, 2400, 4800, 7200, 9600, _
                                                       19200, 38400, 57600, 115200, 128000, 230400, 460800, 921600}

    Private g_strParityTable() As String = New String() {Parity.None.ToString, Parity.Odd.ToString, _
                                                         Parity.Even.ToString, Parity.Mark.ToString, _
                                                         Parity.Space.ToString}

    Private g_nByteSizeTable() As Integer = New Integer() {5, 6, 7, 8}

    Private g_strStopBitsTable() As String = New String() {StopBits.None.ToString, StopBits.One.ToString, StopBits.Two.ToString, StopBits.OnePointFive.ToString}

    Private g_strTerminator() As String = New String() {")", vbCr, vbLf, vbCrLf, "^", Chr(3), Chr(4), "?", ""}

    Private g_sCapTerminator() As String = New String() {"McScience", "CR", "LF", "CR+LF", "^", "H3", "H4", "?", "None"}

    Dim sComports() As String = Nothing

#End Region

#Region "Define Enums"


    Public Enum eTerminator
        McScience_EOT
        CR
        LF
        CRLF
        caret '^
        Hex3
        Hex4
        QuestionMark
        None
    End Enum
 

#End Region

#Region "Initialization"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        Init()
    End Sub

    Private Sub Init()

        Dim nCnt As Integer


        gbTitle.Location = New Drawing.Point(0, 0)
        gbTitle.Dock = Windows.Forms.DockStyle.Fill

        CComSerial.FindComPorts(sComports)

        If sComports.Length > 0 Then
            With cbComports
                .Items.Clear()
                For nCnt = 0 To sComports.Length - 1
                    .Items.Add(sComports(nCnt))
                Next
                .SelectedIndex = 0
            End With

        Else
            cbComports.Text = "Nothing"
        End If
      

        With cbBaudRate
            .Items.Clear()
            For nCnt = 0 To g_nBaudTable.Length - 1
                .Items.Add(CStr(g_nBaudTable(nCnt)))
            Next
            .SelectedIndex = 13
        End With

        With cbParity
            .Items.Clear()
            For nCnt = 0 To g_strParityTable.Length - 1
                .Items.Add(g_strParityTable(nCnt))
            Next
            .SelectedIndex = 0
        End With

        With cbStop
            .Items.Clear()
            For nCnt = 0 To g_strStopBitsTable.Length - 1
                .Items.Add(g_strStopBitsTable(nCnt))
            Next
            .SelectedIndex = 1
        End With

        With cbDataLen
            .Items.Clear()
            For nCnt = 0 To g_nByteSizeTable.Length - 1
                .Items.Add(CStr(g_nByteSizeTable(nCnt)))
            Next
            .SelectedIndex = 3
        End With

        With cbRcvTerminator
            .Items.Clear()
            For nCnt = 0 To g_sCapTerminator.Length - 1
                .Items.Add(g_sCapTerminator(nCnt))
            Next
            .SelectedIndex = 3
        End With

        With cbSendTerminator
            .Items.Clear()
            For nCnt = 0 To g_sCapTerminator.Length - 1
                .Items.Add(g_sCapTerminator(nCnt))
            Next
            .SelectedIndex = 3
        End With


        gbTitle.ForeColor = Me.ForeColor
        Label1.ForeColor = Me.ForeColor
        Label2.ForeColor = Me.ForeColor
        Label3.ForeColor = Me.ForeColor
        Label4.ForeColor = Me.ForeColor
        Label5.ForeColor = Me.ForeColor
        '   Label6.ForeColor = Me.ForeColor
    End Sub

#End Region

#Region "Define Property"

    Public Property Title() As String
        Get
            Return gbTitle.Text
        End Get
        Set(ByVal Value As String)
            gbTitle.Text = Value
        End Set
    End Property

    Public Property COMPORT() As String
        Get
            Return cbComports.SelectedItem
        End Get
        Set(ByVal value As String)
            For i As Integer = 0 To sComports.Length - 1
                If sComports(i) = value Then
                    cbComports.SelectedIndex = i
                End If
            Next
        End Set

    End Property

    Public Property BAUDRATE() As Integer
        Get
            Return g_nBaudTable(cbBaudRate.SelectedIndex)
        End Get
        Set(value As Integer)

            For i As Integer = 0 To g_nBaudTable.Length - 1
                If g_nBaudTable(i) = value Then
                    cbBaudRate.SelectedIndex = i
                End If
            Next
        End Set
    End Property

    Public Property PARITYBIT() As System.IO.Ports.Parity
        Get
            Return cbParity.SelectedIndex
        End Get
        Set(value As System.IO.Ports.Parity)
            cbParity.SelectedIndex = value
        End Set
    End Property


    Public Property STOPBIT() As System.IO.Ports.StopBits
        Get
            Return cbStop.SelectedIndex
        End Get
        Set(value As System.IO.Ports.StopBits)
            cbStop.SelectedIndex = value
        End Set
    End Property

    Public Property DATABIT() As Integer
        Get
            Return g_nByteSizeTable(cbDataLen.SelectedIndex)
        End Get
        Set(value As Integer)
            For i As Integer = 0 To g_nByteSizeTable.Length - 1
                If g_nByteSizeTable(i) = value Then
                    cbDataLen.SelectedIndex = i
                End If
            Next
        End Set
    End Property

    Public Property RcvTerminator() As eTerminator
        Get
            Return cbRcvTerminator.SelectedIndex
        End Get
        Set(ByVal value As eTerminator)
            cbRcvTerminator.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property SendTerminator() As eTerminator
        Get
            Return cbSendTerminator.SelectedIndex
        End Get
        Set(ByVal value As eTerminator)
            cbSendTerminator.SelectedIndex = CInt(value)
        End Set
    End Property

#End Region

    Private Sub ucConfigRs232_ForeColorChanged(sender As Object, e As System.EventArgs) Handles Me.ForeColorChanged
        gbTitle.ForeColor = Me.ForeColor
        Label1.ForeColor = Me.ForeColor
        Label2.ForeColor = Me.ForeColor
        Label3.ForeColor = Me.ForeColor
        Label4.ForeColor = Me.ForeColor
        Label5.ForeColor = Me.ForeColor
        '  Label6.ForeColor = Me.ForeColor
    End Sub

    Public Shared Function ConvertIntTerminatorToString(ByVal terminator As eTerminator) As String
        Dim sTerminator(8) As String
        sTerminator(0) = ")"
        sTerminator(1) = vbCr
        sTerminator(2) = vbLf
        sTerminator(3) = vbCrLf
        sTerminator(4) = "^"
        sTerminator(5) = Chr(3)
        sTerminator(6) = Chr(4)
        sTerminator(7) = "?"
        sTerminator(8) = "" 'None
        Return sTerminator(terminator)
    End Function

    Public Shared Function ConvertStringToIntTerminator(ByVal str As String) As eTerminator
        Dim sTerminator(8) As String
        Dim terminator As eTerminator
        sTerminator(0) = ")"
        sTerminator(1) = vbCr
        sTerminator(2) = vbLf
        sTerminator(3) = vbCrLf
        sTerminator(4) = "^"
        sTerminator(5) = Chr(3)
        sTerminator(6) = Chr(4)
        sTerminator(7) = "?"
        sTerminator(8) = ""
        Select Case str
            Case sTerminator(0)    '  ")"
                terminator = eTerminator.McScience_EOT
            Case sTerminator(1)   ' vbCr
                terminator = eTerminator.CR
            Case sTerminator(2)   '   vbLf
                terminator = eTerminator.LF
            Case sTerminator(3)   '  vbCrLf
                terminator = eTerminator.CRLF
            Case sTerminator(4)   '   "^"
                terminator = eTerminator.caret
            Case sTerminator(5)
                terminator = eTerminator.Hex3
            Case sTerminator(6)
                terminator = eTerminator.Hex4
            Case sTerminator(7)
                terminator = eTerminator.QuestionMark
            Case sTerminator(8)
                terminator = eTerminator.None
        End Select
        Return terminator
    End Function
End Class
