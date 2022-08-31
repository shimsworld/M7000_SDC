Public Class frmMessage
    Dim m_Message As String
    Dim m_MessageSize As Double

    Private Delegate Sub DelCallSub()

#Region "Delegate"
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
                'lblMessage.Text = m_Message
                Me.Location = New Drawing.Point(600, 400)
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
        End If
    End Sub
#End Region


#Region "Create, Dispose and init"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub init()
        'lblMessage.Location = New System.Drawing.Point(0, 0)
        'lblMessage.Dock = DockStyle.Fill
        'lblMessage.Text = "No Error."
    End Sub
#End Region

    Public WriteOnly Property Message As String
        Set(ByVal value As String)
            m_Message = value
        End Set
    End Property
End Class