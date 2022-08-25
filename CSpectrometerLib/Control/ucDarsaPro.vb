Public Class ucDarsaPro


#Region "Defines"

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evSetRemoteMode()
    Public Event evSetLocalMode()
    Public Event evMeasure()
    Public Event evDarkMeasure()
    Public Event evSetGain(ByVal nGain As Integer)
#End Region

#Region "Property"

    Public WriteOnly Property MeasuredData As String
        Set(ByVal value As String)
            lblMeasuredDatas.Text = value
        End Set
    End Property

#End Region

#Region "Creator, Disposer And init"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        Init()
    End Sub


    Public Sub init()
        cbSetGain.SelectedIndex = 0
    End Sub
#End Region

#Region "Functions"

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemote.Click
        RaiseEvent evSetRemoteMode()
    End Sub

    Private Sub btnLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocal.Click
        RaiseEvent evSetLocalMode()
    End Sub

    Private Sub btnMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub


    Private Sub btnDarkMeas_Click(sender As System.Object, e As System.EventArgs) Handles btnDarkMeas.Click
        RaiseEvent evDarkMeasure()
    End Sub

    Private Sub btnSetGain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetGain.Click
        RaiseEvent evSetGain(cbSetGain.SelectedIndex)
    End Sub


#End Region

    

  
End Class
