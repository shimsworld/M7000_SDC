Public Class ucMonitorParam

    Private Delegate Sub DelLabelStatus(ByVal nState As Boolean)
    Private Delegate Sub DelSetString(ByVal str As String)


    Public Sub LabelStatus(ByVal nState As Boolean)  'ByVal label As System.Windows.Forms.StatusStrip,
        If ledStatus.InvokeRequired = True Then
            Dim del2 As DelLabelStatus = New DelLabelStatus(AddressOf LabelStatus)
            Try
                Invoke(del2, nState)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            If nState = True Then
                ledStatus.BackColor = Color.Red
                lblName.BackColor = Color.Red
            Else
                ledStatus.BackColor = Color.DarkGray
                lblName.BackColor = Color.Gray
            End If
        End If
    End Sub

    Public Sub LabelString(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If lblName.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf LabelString)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblName.Text = str
        End If
    End Sub

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        TableLayoutPanel1.Dock = DockStyle.Fill
    End Sub


End Class
