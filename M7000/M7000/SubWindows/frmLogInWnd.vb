Imports System.Threading

Public Class frmLogInWnd
    Dim bLog As Boolean
    Dim m_strPassword As String
    Dim iSFrameSize As Integer = 290
    Dim iEFrameSize As Integer = 160

    Dim m_AutoCloseWindosw As Boolean = False

    Dim m_LogInMode As eLogInMode

    Public Enum eLogInMode
        _Admin
        _Safety
    End Enum

#Region "Creat & Initialize"

    Public Sub New(ByVal mode As eLogInMode)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_LogInMode = mode
    End Sub

#End Region

#Region "Property"

    Public Property bLoginInfo As Boolean
        Get
            Return bLog
        End Get
        Set(ByVal value As Boolean)
            bLog = value
        End Set
    End Property

    Public WriteOnly Property WindowAutoClosingWhenLogIn As Boolean
        Set(ByVal value As Boolean)
            m_AutoCloseWindosw = value
        End Set
    End Property
#End Region


    Private Sub frmLogInWnd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim optinfo As frmOptionWindow.sOPTIONDATa = Nothing

        ' DialogResult = Windows.Forms.DialogResult.Cancel

        If frmOptionWindow.LoadSystemOption(optinfo) = True Then

            If m_LogInMode = eLogInMode._Admin Then
                m_strPassword = optinfo.SystemAdmin.strPassword
                bLog = optinfo.SystemAdmin.bLogInStatus
            Else
                m_strPassword = optinfo.SafetyAdmin.strPassword
                bLog = optinfo.SafetyAdmin.bLogInStatus
            End If

            If bLog = True Then
                txtLogInPW.BackColor = Color.Lime
                btnLogIn.Text = "Log-Out"
                lblLogInStatus.Text = "You have logged. When you are finished, log out of your system settings."
                txtLogInPW.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        Dim optinfo As frmOptionWindow.sOPTIONDATa = Nothing

        If bLog = False Then
            If txtLogInPW.Text = m_strPassword Then
                txtLogInPW.Text = ""
                txtLogInPW.BackColor = Color.Lime
                'chkEnableSystemMenu.Enabled = True
                btnLogIn.Text = "Log-Out"
                lblLogInStatus.ForeColor = Color.Black
                lblLogInStatus.Text = "You have logged. When you are finished system settings, log out of your system administrator."
                txtLogInPW.Enabled = False
                bLog = True
            Else
                txtLogInPW.BackColor = Color.Red
                txtLogInPW.Text = ""
                btnLogIn.Text = "Log-In"
                lblLogInStatus.ForeColor = Color.Red
                lblLogInStatus.Text = "The password is incorrect."
                txtLogInPW.Enabled = True
                bLog = False
            End If
        ElseIf bLog = True Then
            txtLogInPW.BackColor = SystemColors.Window
            txtLogInPW.Text = ""
            btnLogIn.Text = "Log-In"
            lblLogInStatus.ForeColor = Color.Black
            lblLogInStatus.Text = "You have logged out."
            txtLogInPW.Enabled = True
            bLog = False
        End If

        If frmOptionWindow.LoadSystemOption(optinfo) = True Then

            If m_LogInMode = eLogInMode._Admin Then
                optinfo.SystemAdmin.bLogInStatus = bLog
            Else
                optinfo.SafetyAdmin.bLogInStatus = bLog
            End If

            frmOptionWindow.SaveSystemOption(optinfo)
        End If

        If m_AutoCloseWindosw = True Then
            If m_LogInMode = eLogInMode._Admin Then
                If optinfo.SystemAdmin.bLogInStatus = True Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                If optinfo.SafetyAdmin.bLogInStatus = True Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If

        End If

    End Sub

    Private Sub chkEnableSystemMenu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableSystemMenu.CheckedChanged
        If chkEnableSystemMenu.Checked = True Then
            For idx As Integer = iEFrameSize To iSFrameSize
                Application.DoEvents()
                Thread.Sleep(1)
                Me.Size = New System.Drawing.Size(443, idx)
            Next
        ElseIf chkEnableSystemMenu.Checked = False Then
            For idx As Integer = iSFrameSize To iEFrameSize Step -1
                Application.DoEvents()
                Thread.Sleep(1)
                Me.Size = New System.Drawing.Size(443, idx)
            Next
        End If
    End Sub

    Private Sub btnNewpassSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewpassSet.Click
        Dim optinfo As frmOptionWindow.sOPTIONDATa = Nothing

        Dim strExistPass As String = txtExistPass.Text
        Dim strNewPass As String = txtNewPass.Text

        If bLog = False Then
            lblLogInStatus.ForeColor = Color.Red
            lblLogInStatus.Text = "After logging in you can change."
        Else
            If strExistPass = m_strPassword Then
                m_strPassword = strNewPass
                If frmOptionWindow.LoadSystemOption(optinfo) = True Then

                    If m_LogInMode = eLogInMode._Admin Then
                        optinfo.SystemAdmin.strPassword = m_strPassword
                    Else
                        optinfo.SafetyAdmin.strPassword = m_strPassword
                    End If

                    frmOptionWindow.SaveSystemOption(optinfo)
                    lblLogInStatus.ForeColor = Color.Blue
                    lblLogInStatus.Text = "New password setting is complete."
                End If
            Else
                txtExistPass.Text = ""
                txtNewPass.Text = ""
                lblLogInStatus.ForeColor = Color.Red
                lblLogInStatus.Text = "Please enter your existing password correctly."
            End If
        End If

    End Sub

End Class