Public Class UcMonitorControl

    Public ucCH() As ucMonitorParam

    Public m_chNum As Integer
    Public m_divNum As Integer
    Dim m_ChLine As Integer = 0

    Public Sub New(ByVal TotalCh As Integer, ByVal DivNo As Integer, ByVal bCommonLoad As Boolean)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_divNum = DivNo
        m_chNum = TotalCh

        init(bCommonLoad)
    End Sub

    Public Sub init(ByVal bLoad As Boolean)
        Dim ChNum As Integer = m_chNum

        'ReDim chkInput(ChNum - 1)
        ReDim ucCH(ChNum - 1)

        Dim cnt As Integer = 0
        Dim xLocation As Integer = 10
        Dim yLocation As Integer = 0

        Dim ucChX As Integer = 0
        Dim ucChY As Integer = 0

        Dim divCh As Integer = 0
        If bLoad = False Then
            For idx As Integer = 0 To m_chNum - 1

                If yLocation = 3 Then
                    yLocation = 0
                    xLocation = xLocation + 200
                End If

                ucCH(idx) = New ucMonitorParam

                ucCH(idx).lblName.Text = "CH" & Format(idx + 1, "00")

                Controls.Add(ucCH(idx))

                'chkInput(idx) = New CheckBox
                'Controls.Add(chkInput(idx))

                'AddHandler ucCh(idx).CheckedChanged, AddressOf CheckChannel
                'AddHandler chkInput(idx).CheckedChanged, AddressOf CheckChannel
                If idx <> 0 Then
                    If idx Mod 3 = 0 Then
                        divCh += 1
                    End If
                End If
                ucCH(idx).Location = New Point(xLocation, 2 + (15 * yLocation))
                'ucCh(idx).Text = "CH" & Format(idx + g_ConfigInfos.nStartCh, "00")
                ucCH(idx).Size = New Size(170, 13)
                'ucCh(idx).IsChecked = False

                'chkInput(idx).Location = New Point(10 + (65 * xLocation), yLocation)
                'chkInput(idx).Text = "CH" & Format(idx + 1, "00")
                'chkInput(idx).Size = New Size(60, 30)
                'chkInput(idx).BackColor = Color.DarkOrange

                ucCH(idx).Font = New System.Drawing.Font("Segoe UI", ucCH(idx).Font.Size, FontStyle.Bold)
                'chkInput(idx).Font = New System.Drawing.Font("Arial", chkInput(idx).Font.Size, FontStyle.Bold)

                yLocation += 1

                If ucCH(idx).Location.X > ucChX Then
                    ucChX = ucCH(idx).Location.X
                End If

                If ucCH(idx).Location.Y > ucChY Then
                    ucChY = ucCH(idx).Location.Y
                End If
            Next
            Me.Size = New Size(ucChX + 150 + 30, ucChY + 10 + 15)
        Else
            For idx As Integer = 0 To m_chNum - 1

                If yLocation = 6 Then
                    yLocation = 0
                    xLocation = xLocation + 155
                End If

                ucCH(idx) = New ucMonitorParam

                ucCH(idx).lblName.Text = "CH" & Format(idx + 1, "00")
                Controls.Add(ucCH(idx))

                'chkInput(idx) = New CheckBox
                'Controls.Add(chkInput(idx))

                'AddHandler ucCh(idx).CheckedChanged, AddressOf CheckChannel
                'AddHandler chkInput(idx).CheckedChanged, AddressOf CheckChannel

                ucCH(idx).Location = New Point(xLocation, 2 + (15 * yLocation))
                'ucCh(idx).Text = "CH" & Format(idx + g_ConfigInfos.nStartCh, "00")
                ucCH(idx).Size = New Size(155, 15)
                'ucCh(idx).IsChecked = False

                'chkInput(idx).Location = New Point(10 + (65 * xLocation), yLocation)
                'chkInput(idx).Text = "CH" & Format(idx + 1, "00")
                'chkInput(idx).Size = New Size(60, 30)
                'chkInput(idx).BackColor = Color.DarkOrange

                ucCH(idx).Font = New System.Drawing.Font("Segoe UI", ucCH(idx).Font.Size, FontStyle.Bold)
                'chkInput(idx).Font = New System.Drawing.Font("Arial", chkInput(idx).Font.Size, FontStyle.Bold)

                yLocation += 1

                If ucCH(idx).Location.X > ucChX Then
                    ucChX = ucCH(idx).Location.X
                End If

                If ucCH(idx).Location.Y > ucChY Then
                    ucChY = ucCH(idx).Location.Y
                End If
            Next
            Me.Size = New Size(ucChX + 155, ucChY + 10 + 15)
        End If
    End Sub

End Class
