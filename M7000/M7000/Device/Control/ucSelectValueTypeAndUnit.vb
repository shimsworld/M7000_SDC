Public Class ucSelectValueTypeAndUnit



    Dim m_nValueType As CUnitConverter.eType = CUnitConverter.eType.Voltage

    Dim m_nSelectedUnit(1) As CUnitCommonNode.eMKSUnit


#Region "Properties"

    Public Property ValueType As CUnitConverter.eType
        Get
            Return m_nValueType
        End Get
        Set(ByVal value As CUnitConverter.eType)
            m_nValueType = value
            cbSelValueType.SelectedIndex = m_nValueType
            updateUnitList()
        End Set
    End Property

    Public Property CanSelectValueType As Boolean
        Get
            Return cbSelValueType.Enabled
        End Get
        Set(ByVal value As Boolean)
            cbSelValueType.Enabled = value
        End Set
    End Property



    Public Property SelectedUnit As CUnitCommonNode.eMKSUnit()
        Get
            Return m_nSelectedUnit
        End Get
        Set(ByVal value As CUnitCommonNode.eMKSUnit())
            m_nSelectedUnit = value
            If m_nSelectedUnit Is Nothing Then Exit Property
            If m_nValueType <> CUnitConverter.eType.CurrentDensity Then
                cbSelUnit1.SelectedIndex = m_nSelectedUnit(0)
            Else
                cbSelUnit1.SelectedIndex = m_nSelectedUnit(0)
                cbSelUnit2.SelectedIndex = m_nSelectedUnit(1)
            End If
        End Set
    End Property

#End Region

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
        updateUnitList()
    End Sub


    Private Sub init()

        Dim sCaptions() As String = CUnitConverter.GetValueType.Clone

        cbSelValueType.Items.Clear()
        For i As Integer = 0 To sCaptions.Length - 1
            cbSelValueType.Items.Add(sCaptions(i))
        Next
        cbSelValueType.SelectedIndex = m_nValueType
    End Sub

    Private Sub updateUnitList()

        Dim sDefUnitCaption() As String = CUnitConverter.GetDefUnit
        Dim sUnitLise() As String = CUnitCommonNode.GetUnitList
        Dim nValueType As CUnitConverter.eType = cbSelValueType.SelectedIndex

        m_nValueType = nValueType
        If nValueType <> CUnitConverter.eType.CurrentDensity Then
            cbSelUnit1.Items.Clear()
            For i As Integer = 0 To sUnitLise.Length - 1
                cbSelUnit1.Items.Add(sUnitLise(i) & sDefUnitCaption(nValueType))
            Next
            cbSelUnit1.SelectedIndex = 8

            cbSelUnit2.Visible = False
            lblDevider.Visible = False
        Else
            cbSelUnit1.Items.Clear()
            For i As Integer = 0 To sUnitLise.Length - 1
                cbSelUnit1.Items.Add(sUnitLise(i) & sDefUnitCaption(CUnitConverter.eType.Ampere))
            Next
            cbSelUnit1.SelectedIndex = 8


            cbSelUnit2.Visible = True
            lblDevider.Visible = True

            cbSelUnit2.Items.Clear()
            For i As Integer = 0 To sUnitLise.Length - 1
                cbSelUnit2.Items.Add(sUnitLise(i) & sDefUnitCaption(CUnitConverter.eType.Area))
            Next
            cbSelUnit2.SelectedIndex = 8
        End If

       
    End Sub

    Private Sub cbSelValueType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelValueType.SelectedIndexChanged
        updateUnitList()
    End Sub


    Private Sub cbSelUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelUnit1.SelectedIndexChanged
        m_nSelectedUnit(0) = cbSelUnit1.SelectedIndex
    End Sub


    Private Sub cbSelUnit2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelUnit2.SelectedIndexChanged
        m_nSelectedUnit(1) = cbSelUnit2.SelectedIndex
    End Sub

End Class
