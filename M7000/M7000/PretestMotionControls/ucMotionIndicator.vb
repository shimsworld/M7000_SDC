Public Class ucMotionIndicator

#Region "Defiens"

    Dim m_sChannel As String
    Dim m_sOpticalHeaderPos As String
    Dim m_dXPos As Double
    Dim m_dYPos As Double
    Dim m_dZPos As Double
    Dim m_dTheta1Pos As Double
    Dim m_dTheta2Pos As Double
    Dim m_dTheta3Pos As Double
    Dim m_dTheta4Pos As Double

    '  Dim m_dThetaYPos As Double
    ' Dim m_dThetaPos As Double
    '  Dim m_dAngelPos As Double

#End Region

#Region "Delegate"


    Private Delegate Sub DelSetString(ByVal str As String)

    Private Sub delFuncChannel(ByVal str As String)
        If lblChannel.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncChannel)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblChannel.Text = str
        End If
    End Sub

    Private Sub delFuncOpticalHeaderPos(ByVal str As String)
        If lblOpticalHeaderPos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncOpticalHeaderPos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblOpticalHeaderPos.Text = str
        End If
    End Sub

    Private Sub delFuncXPos(ByVal str As String)
        If tbXPos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncXPos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbXPos.Text = str
        End If
    End Sub

    Private Sub delFuncYPos(ByVal str As String)
        If tbYPos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncYPos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbYPos.Text = str
        End If
    End Sub

    Public Sub delFuncZPos(ByVal str As String)
        If tbZPos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncZPos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbZPos.Text = str
        End If
    End Sub

    Public Sub delFuncTheta1Pos(ByVal str As String)
        If tbTheta1Pos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncTheta1Pos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbTheta1Pos.Text = str
        End If
    End Sub

    Public Sub delFuncTheta2Pos(ByVal str As String)
        If tbTheta2Pos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncTheta2Pos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbTheta2Pos.Text = str
        End If
    End Sub

    Public Sub delFuncTheta3Pos(ByVal str As String)
        If tbTheta3Pos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncTheta3Pos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbTheta3Pos.Text = str
        End If
    End Sub

    Public Sub delFuncTheta4Pos(ByVal str As String)
        If tbTheta4Pos.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf delFuncTheta4Pos)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbTheta4Pos.Text = str
        End If
    End Sub

    'Private Sub delFuncThetaYPos(ByVal str As String)
    '    If tbThetaYPos.InvokeRequired = True Then
    '        Dim del2 As DelSetString = New DelSetString(AddressOf delFuncThetaYPos)
    '        Try
    '            Invoke(del2, str)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        tbThetaYPos.Text = str
    '    End If
    'End Sub

    'Public Sub delFuncAnglePos(ByVal str As String)
    '    If tbAnglePos.InvokeRequired = True Then
    '        Dim del2 As DelSetString = New DelSetString(AddressOf delFuncAnglePos)
    '        Try
    '            Invoke(del2, str)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        tbAnglePos.Text = str
    '    End If
    'End Sub

#End Region

#Region "Properties"

    Public Property Channel As String
        Get
            Return m_sChannel
        End Get
        Set(ByVal value As String)
            m_sChannel = value
            delFuncChannel(m_sChannel)
        End Set
    End Property


    Public Property OpticalHeaderPos As String
        Get
            Return m_sOpticalHeaderPos
        End Get
        Set(ByVal value As String)
            m_sOpticalHeaderPos = value
            delFuncOpticalHeaderPos(m_sOpticalHeaderPos)
        End Set
    End Property

    Public Property XPos As Double
        Get
            Return m_dXPos
        End Get
        Set(ByVal value As Double)
            m_dXPos = value
            delFuncXPos(Format(m_dXPos, "0.000"))
        End Set
    End Property

    Public Property YPos As Double
        Get
            Return m_dYPos
        End Get
        Set(ByVal value As Double)
            m_dYPos = value
            delFuncYPos(Format(m_dYPos, "0.000"))
        End Set
    End Property

    Public Property ZPos As Double
        Get
            Return m_dZPos
        End Get
        Set(ByVal value As Double)
            m_dZPos = value
            delFuncZPos(Format(m_dZPos, "0.000"))
        End Set
    End Property

    Public Property Theta1Pos As Double
        Get
            Return m_dTheta1Pos
        End Get
        Set(ByVal value As Double)
            m_dTheta1Pos = value
            delFuncTheta1Pos(Format(m_dTheta1Pos, "0.000"))
        End Set
    End Property

    Public Property Theta2Pos As Double
        Get
            Return m_dTheta2Pos
        End Get
        Set(ByVal value As Double)
            m_dTheta2Pos = value
            delFuncTheta2Pos(Format(m_dTheta2Pos, "0.000"))
        End Set
    End Property

    Public Property Theta3Pos As Double
        Get
            Return m_dTheta3Pos
        End Get
        Set(ByVal value As Double)
            m_dTheta3Pos = value
            delFuncTheta3Pos(Format(m_dTheta3Pos, "0.000"))
        End Set

    End Property

    Public Property Theta4Pos As Double
        Get
            Return m_dTheta4Pos
        End Get
        Set(ByVal value As Double)
            m_dTheta4Pos = value
            delFuncTheta4Pos(Format(m_dTheta4Pos, "0.000"))
        End Set
    End Property
    'Public Property ThetaYPos As Double
    '    Get
    '        Return m_dThetaYPos
    '    End Get
    '    Set(ByVal value As Double)
    '        m_dThetaYPos = value
    '        delFuncThetaYPos(Format(m_dThetaYPos, "0.000"))
    '    End Set
    'End Property

    'Public Property ThetaPos As Double
    '    Get
    '        Return m_dThetaPos
    '    End Get
    '    Set(ByVal value As Double)
    '        m_dThetaPos = value
    '        delFuncAnglePos(Format(m_dThetaPos, "0.000"))
    '    End Set
    'End Property

    'Public Property AnglePos As Double
    '    Get
    '        Return m_dAngelPos
    '    End Get
    '    Set(ByVal value As Double)
    '        m_dAngelPos = value
    '        delFuncAnglePos(Format(m_dAngelPos, "0.000"))
    '    End Set
    'End Property
    Public Property Title As String
        Get
            'Return gbMain.Text
        End Get
        Set(ByVal value As String)
            'gbMain.Text = value
        End Set
    End Property


#End Region

    


#Region "Creator, Disposer and init"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        init()
    End Sub

    Private Sub init()

        'gbMain.Dock = DockStyle.Fill

    End Sub

#End Region



End Class
