Public Class frmCheckPassword


    Dim m_sPassWord As String


    Public Sub New(ByVal Password As String)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_sPassWord = Password
        init()
    End Sub
    Private Sub init()
        Me.BringToFront()
        Me.TopMost = True
    End Sub
    Private Sub tbPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPassword.TextChanged

        Dim sPassWord As String = tbPassword.Text

        If m_sPassWord = sPassWord Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            lblMessage.Text = "The password is invalid. Please check and try again."
        End If

    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


End Class