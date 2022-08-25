Public Class frmWADSet

    Private m_WAD As frmOptionWindow.sWADCalFactor
    Public Const nNumOfFactor As Integer = 7

    Dim tbWAD_X() As TextBox
    Dim tbWAD_Y() As TextBox
    Dim tbWAD_Z() As TextBox
    Dim lbNUM() As Label

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


#Region "Propertys"

    Public Property Settings() As frmOptionWindow.sWADCalFactor
        Get
            GetValueToUI()
            Return m_WAD
        End Get
        Set(ByVal value As frmOptionWindow.sWADCalFactor)
            m_WAD = value
        End Set
    End Property

#End Region
    
#Region "Create&Initialize"

    Public Sub init()

        ReDim tbWAD_X(nNumOfFactor - 1)
        ReDim tbWAD_Y(nNumOfFactor - 1)
        ReDim tbWAD_Z(nNumOfFactor - 1)
        ReDim lbNUM(nNumOfFactor - 1)

        For idx As Integer = 0 To nNumOfFactor - 1
            tbWAD_X(idx) = New TextBox
            tbWAD_Y(idx) = New TextBox
            tbWAD_Z(idx) = New TextBox
            lbNUM(idx) = New Label

            Controls.Add(tbWAD_X(idx))
            Controls.Add(tbWAD_Y(idx))
            Controls.Add(tbWAD_Z(idx))
            Controls.Add(lbNUM(idx))

            If idx = 0 Then
                lbNUM(idx).Location = New System.Drawing.Point(Lb_Display_num.Location.X, lblWADFactor_X.Location.Y + lblWADFactor_X.Height + 5)
                tbWAD_X(idx).Location = New System.Drawing.Point(lblWADFactor_X.Location.X, lblWADFactor_X.Location.Y + lblWADFactor_X.Height + 5)
                tbWAD_Y(idx).Location = New System.Drawing.Point(lblWADFactor_Y.Location.X, lblWADFactor_Y.Location.Y + lblWADFactor_Y.Height + 5)
                tbWAD_Z(idx).Location = New System.Drawing.Point(lblWADFactor_Z.Location.X, lblWADFactor_Z.Location.Y + lblWADFactor_Z.Height + 5)

            Else

                lbNUM(idx).Location = New System.Drawing.Point(Lb_Display_num.Location.X, tbWAD_X(idx - 1).Location.Y + tbWAD_X(idx - 1).Height + 3)
                tbWAD_X(idx).Location = New System.Drawing.Point(lblWADFactor_X.Location.X, tbWAD_X(idx - 1).Location.Y + tbWAD_X(idx - 1).Height + 3)
                tbWAD_Y(idx).Location = New System.Drawing.Point(lblWADFactor_Y.Location.X, tbWAD_Y(idx - 1).Location.Y + tbWAD_Y(idx - 1).Height + 3)
                tbWAD_Z(idx).Location = New System.Drawing.Point(lblWADFactor_Z.Location.X, tbWAD_Z(idx - 1).Location.Y + tbWAD_Z(idx - 1).Height + 3)
            End If

            tbWAD_X(idx).Size = New System.Drawing.Point(lblWADFactor_X.Size.Width, lblWADFactor_X.Size.Height)
            tbWAD_X(idx).TextAlign = HorizontalAlignment.Center
            tbWAD_X(idx).BorderStyle = BorderStyle.FixedSingle
            tbWAD_X(idx).Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
            tbWAD_X(idx).ForeColor = Color.OrangeRed
            tbWAD_X(idx).BackColor = Color.White

            tbWAD_X(idx).BringToFront()

            tbWAD_Y(idx).Size = New System.Drawing.Point(lblWADFactor_Y.Size.Width, lblWADFactor_Y.Size.Height)
            tbWAD_Y(idx).TextAlign = HorizontalAlignment.Center
            tbWAD_Y(idx).BorderStyle = BorderStyle.FixedSingle
            tbWAD_Y(idx).Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
            tbWAD_Y(idx).ForeColor = Color.OrangeRed
            tbWAD_Y(idx).BackColor = Color.White

            tbWAD_Y(idx).BringToFront()

            tbWAD_Z(idx).Size = New System.Drawing.Point(lblWADFactor_Z.Size.Width, lblWADFactor_Z.Size.Height)
            tbWAD_Z(idx).TextAlign = HorizontalAlignment.Center
            tbWAD_Z(idx).BorderStyle = BorderStyle.FixedSingle
            tbWAD_Z(idx).Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
            tbWAD_Z(idx).ForeColor = Color.OrangeRed
            tbWAD_Z(idx).BackColor = Color.White

            tbWAD_Z(idx).BringToFront()


            lbNUM(idx).Size = New System.Drawing.Point(Lb_Display_num.Size.Width, Lb_Display_num.Size.Height)
            lbNUM(idx).TextAlign = HorizontalAlignment.Center
            lbNUM(idx).BorderStyle = BorderStyle.FixedSingle
            lbNUM(idx).Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
            lbNUM(idx).ForeColor = Color.Black
            lbNUM(idx).BackColor = Color.White
            If idx = 0 Then
                lbNUM(idx).Text = "OffSet"
            Else
                lbNUM(idx).Text = "x^" & idx
            End If
            lbNUM(idx).BringToFront()
        Next

    End Sub

#End Region
   
    
    Private Sub frmWADSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetValueToUI()
    End Sub

    Private Sub SetValueToUI()
        If m_WAD.dWAD_X Is Nothing Then Exit Sub
        If m_WAD.dWAD_Y Is Nothing Then Exit Sub
        If m_WAD.dWAD_Z Is Nothing Then Exit Sub

        With m_WAD
            For idx As Integer = 0 To nNumOfFactor - 1
                tbWAD_X(idx).Text = .dWAD_X(idx)
                tbWAD_Y(idx).Text = .dWAD_Y(idx)
                tbWAD_Z(idx).Text = .dWAD_Z(idx)
            Next
        End With

    End Sub

    Private Sub GetValueToUI()
        With m_WAD
            For idx As Integer = 0 To nNumOfFactor - 1
                .dWAD_X(idx) = tbWAD_X(idx).Text
                .dWAD_Y(idx) = tbWAD_Y(idx).Text
                .dWAD_Z(idx) = tbWAD_Z(idx).Text
            Next
        End With
    End Sub

  
End Class