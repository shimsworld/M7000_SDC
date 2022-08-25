Public Class ucLimitSetting



#Region "Define"

    Dim m_LimitValues() As sLimitSetting

    Public Enum eLimitValueType
        eVoltage
        eCurrent
    End Enum

    Public Structure sLimitSetting
        Dim eTypeOfValue As eLimitValueType
        Dim LimitValue As sLimitValue
    End Structure


    Public Structure sLimitValue
        Dim dMin As Double
        Dim dMax As Double
    End Structure


#End Region


#Region "Creator & Disposer & init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        gbLimit.Location = New System.Drawing.Point(0, 0)
        gbLimit.Dock = DockStyle.Fill

        ReDim m_LimitValues(4)
    End Sub

#End Region


#Region "Property"

    Public Property Title() As String
        Get
            Return gbLimit.Text
        End Get
        Set(ByVal value As String)
            gbLimit.Text = value
        End Set
    End Property

    Public Property Settings As sLimitSetting()
        Get
            GetValueFromUI()
            Return m_LimitValues
        End Get
        Set(ByVal value As sLimitSetting())
            m_LimitValues = value
            SetValueToUI()
        End Set
    End Property

#End Region

    Private Sub GetValueFromUI()
        Dim tempValues(1) As sLimitSetting

        tempValues(0).eTypeOfValue = eLimitValueType.eVoltage
        tempValues(1).eTypeOfValue = eLimitValueType.eCurrent
  

        Try
            tempValues(0).LimitValue.dMax = CDbl(tbVoltLow_Max.Text)
            tempValues(0).LimitValue.dMin = CDbl(tbVoltLow_Min.Text)
        Catch ex As Exception
            tempValues(0).LimitValue.dMax = 0
            tempValues(0).LimitValue.dMin = 0
        End Try


        Try
            tempValues(1).LimitValue.dMax = CDbl(tbCurrentLow_Max.Text)
            tempValues(1).LimitValue.dMin = CDbl(tbCurrentLow_Min.Text)
        Catch ex As Exception
            tempValues(1).LimitValue.dMax = 0
            tempValues(1).LimitValue.dMin = 0
        End Try
  
    
        m_LimitValues = tempValues.Clone
    End Sub



    Private Sub SetValueToUI()

        If m_LimitValues Is Nothing Then Exit Sub

        For i As Integer = 0 To m_LimitValues.Length - 1
            Select Case m_LimitValues(i).eTypeOfValue
                Case eLimitValueType.eVoltage
                    tbVoltLow_Max.Text = m_LimitValues(i).LimitValue.dMax
                    tbVoltLow_Min.Text = m_LimitValues(i).LimitValue.dMin
                Case eLimitValueType.eCurrent
                    tbCurrentLow_Max.Text = m_LimitValues(i).LimitValue.dMax
                    tbCurrentLow_Min.Text = m_LimitValues(i).LimitValue.dMin
            End Select
        Next

    End Sub








End Class
