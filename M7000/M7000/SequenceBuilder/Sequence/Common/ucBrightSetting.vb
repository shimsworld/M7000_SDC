

Public Class ucBrightSetting

    Public lbChName() As Label
    Public lbName() As Label
    Public tbInput(,) As TextBox


    Public chkInput() As CheckBox
    Public AllchkInput As CheckBox
    Public AddFactorName() As Label
    Public AddFactorInput() As TextBox

    Public btnSetInput() As Button
    Public btnGetInput() As Button

    Public m_ChNum As Integer
    Public m_ParamNum As Integer
    Public m_CheckBoxVisible As Boolean

    Public Sub New(ByVal ParamNum As Integer, ByVal ChNum As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_ParamNum = ParamNum
        m_ChNum = ChNum

        init()
    End Sub
    Public Property CheckBoxVisible() As Boolean
        Get
            Return m_CheckBoxVisible
        End Get
        Set(ByVal value As Boolean)
            CheckBoxVis(value)
            m_CheckBoxVisible = value
        End Set
    End Property
    Public Property FactorName(ByVal index As Integer) As String
        Get
            Return lbName(index).Text
        End Get
        Set(ByVal value As String)
            lbName(index).Text = value
            AddFactorName(index).Text = value
        End Set
    End Property

    Public Property ChannelName(ByVal ch As Integer) As String
        Get
            Return lbChName(ch).Text
        End Get
        Set(ByVal value As String)
            lbChName(ch).Text = value & ch + 1
        End Set
    End Property

    Public Property ChannelLine As Integer
        Get
            Return m_ChLine
        End Get
        Set(ByVal value As Integer)
            m_ChLine = value
        End Set
    End Property

    Dim m_ChLine As Integer = 0

    Public Sub init()

        Dim ChNum As Integer = m_ChNum

        ReDim lbChName(ChNum - 1)

        ReDim chkInput(ChNum - 1)
        ReDim AddFactorName(m_ParamNum - 1)
        ReDim AddFactorInput(m_ParamNum - 1)

        ReDim lbName(m_ParamNum - 1)
        ReDim tbInput(m_ParamNum - 1, ChNum - 1)

        For idx As Integer = 0 To m_ParamNum - 1
            lbName(idx) = New Label
            Controls.Add(lbName(idx))
            lbName(idx).Location = New Point(60 + (100 * idx), 20)
            lbName(idx).Text = FactorName(idx)
            lbName(idx).Size = New Size(90, 12)

            lbName(idx).Font = New System.Drawing.Font("Arial", lbName(idx).Font.Size, FontStyle.Bold)
        Next


        For idx As Integer = 0 To m_ParamNum - 1

            AddFactorName(idx) = New Label
            Controls.Add(AddFactorName(idx))
            AddFactorName(idx).Location = New Point(lbName(m_ParamNum - 1).Location.X + 100 + 30, 20 * (idx * 2 + 1))
            AddFactorName(idx).Text = FactorName(idx)
            AddFactorName(idx).Size = New Size(90, 12)
            AddFactorName(idx).Font = New System.Drawing.Font("Arial", lbName(idx).Font.Size, FontStyle.Bold)
            AddFactorName(idx).BringToFront()


            AddFactorInput(idx) = New TextBox
            Controls.Add(AddFactorInput(idx))
            AddFactorInput(idx).Location = New Point(lbName(m_ParamNum - 1).Location.X + 100 + 30, 20 * (idx * 2 + 2))
            AddFactorInput(idx).Text = FactorName(idx)
            AddFactorInput(idx).Size = New Size(90, 12)
            AddFactorInput(idx).Font = New System.Drawing.Font("Arial", lbName(idx).Font.Size, FontStyle.Bold)
            AddFactorInput(idx).BringToFront()

            AddHandler AddFactorInput(idx).TextChanged, AddressOf CheckFactorWrite

        Next





        For idx As Integer = 0 To m_ParamNum - 1
            For i As Integer = 0 To ChNum - 1

                tbInput(idx, i) = New TextBox

                If idx = 0 Then

                    lbChName(i) = New Label
                    Controls.Add(lbChName(i))
                    Controls.Add(tbInput(idx, i))

                    chkInput(i) = New CheckBox 'jhlee
                    Controls.Add(chkInput(i))
                    AddHandler chkInput(i).CheckedChanged, AddressOf CheckChannel

                    If i = 0 Then
                        lbChName(i).Location = New Point(0, 40)

                        'all check

                        'chkInput(i) = New CheckBox 'jhlee
                        'Controls.Add(chkInput(i))
                        'chkInput(i).Location = New Point(10, 30) 'jhle
                        'chkInput(i).Text = "All Check"
                        'chkInput(i).BringToFront()
                        'chkInput(i).AutoSize = True

                        'all check

                        AllchkInput = New CheckBox
                        Controls.Add(AllchkInput)
                        AllchkInput.Location = New Point(15, 20) 'jhle
                        AllchkInput.Text = "All"
                        AllchkInput.BringToFront()
                        AllchkInput.AutoSize = True
                        AddHandler AllchkInput.CheckedChanged, AddressOf AllCheck

                        chkInput(i).Location = New Point(40, 43) 'jhle

                        'ElseIf i Mod 50 = 0 Then '20
                        '    lbChName(i).Location = New Point(lbChName(i - 1).Location.X + 300, 40) 'lbChName(i - 1).Location.Y + lbChName(i - 1).Size.Height + 10)
                        '    chkInput(i).Location = New Point(chkInput(i - 1).Location.X + 300, 43) 'jhle
                    Else
                        lbChName(i).Location = New Point(lbChName(i - 1).Location.X, lbChName(i - 1).Location.Y + lbChName(i - 1).Size.Height + 10)
                        chkInput(i).Location = New Point(chkInput(i - 1).Location.X, lbChName(i - 1).Location.Y + lbChName(i - 1).Size.Height + 13) 'jhle
                    End If




                    lbChName(i).Text = ChannelName(i)
                    lbChName(i).Size = New Size(55, 12)


                    chkInput(i).Text = ""
                    chkInput(i).BringToFront()
                    chkInput(i).AutoSize = True

                    tbInput(idx, i).Location = New Point(lbChName(i).Location.X + lbChName(i).Size.Width + 5, lbChName(i).Location.Y)
                    tbInput(idx, i).Visible = True
                    tbInput(idx, i).Text = "0"
                Else
                    Controls.Add(tbInput(idx, i))

                    tbInput(idx, i).Location = New Point(tbInput(idx - 1, i).Location.X + tbInput(idx - 1, i).Size.Width + 5, tbInput(idx - 1, i).Location.Y)
                    tbInput(idx, i).Visible = True
                    tbInput(idx, i).Text = "0"
                End If


            Next
        Next

    End Sub
    Private Sub AllCheck()

        For Cnt As Integer = 0 To chkInput.Length - 1
            chkInput(Cnt).Checked = AllchkInput.Checked
        Next
    End Sub
    Private Sub CheckChannel()

        For Cnt As Integer = 0 To chkInput.Length - 1
            If chkInput(Cnt).Checked = True Then
                lbChName(Cnt).ForeColor = Color.OrangeRed
            ElseIf chkInput(Cnt).Checked = False Then
                lbChName(Cnt).ForeColor = Color.Black
            End If
        Next


    End Sub
    Private Sub CheckBoxVis(ByVal inBool As Boolean)
        AllchkInput.Visible = inBool
        For Cnt As Integer = 0 To chkInput.Length - 1
            chkInput(Cnt).Visible = inBool

        Next

        For Cnt1 As Integer = 0 To AddFactorName.Length - 1
            AddFactorName(Cnt1).Visible = inBool
            AddFactorInput(Cnt1).Visible = inBool

        Next
    End Sub
    Private Sub CheckFactorWrite()

        For Cnt As Integer = 0 To chkInput.Length - 1
            If chkInput(Cnt).Checked = True Then

                For Cnt1 As Integer = 0 To m_ParamNum - 1


                    tbInput(Cnt1, Cnt).Text = AddFactorInput(Cnt1).Text


                Next


            End If
        Next


    End Sub

   

End Class
