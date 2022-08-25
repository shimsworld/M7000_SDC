Public Class frmSGCalibration


#Region "Defines"

    Dim myParent As frmSGControl
    Dim m_nSelDev As Integer

    Enum eSetMode
        eDACMode
        eADCMode
    End Enum

    Dim eMode As eSetMode = eSetMode.eDACMode
    Dim eChannelNum As Integer = 0
    Dim gConditionDac As UcDacChannel.Condi
    Dim gConditionAdc As UcADcChannel.Condi

#End Region

#Region "Properties"

    Public Property Mode As eSetMode
        Get
            Return eMode
        End Get
        Set(ByVal value As eSetMode)
            eMode = value
        End Set
    End Property

    Public Property ChannelNumber As Integer
        Get
            Return eChannelNum
        End Get
        Set(ByVal value As Integer)
            eChannelNum = value
        End Set
    End Property

    Public Property DACCondition As UcDacChannel.Condi
        Get
            Return gConditionDac
        End Get
        Set(ByVal value As UcDacChannel.Condi)
            gConditionDac = value
        End Set
    End Property

    Public Property ADCCondition As UcADcChannel.Condi
        Get
            Return gConditionAdc
        End Get
        Set(ByVal value As UcADcChannel.Condi)
            gConditionAdc = value
        End Set
    End Property

    Public Property selectedDevice As Integer
        Get
            Return m_nSelDev
        End Get
        Set(ByVal value As Integer)
            m_nSelDev = value
        End Set
    End Property

#End Region



#Region "Create, Dispose And Init"

    Public Sub New(ByVal parent As frmSGControl)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
    End Sub

#End Region


    Private Sub btn_Calibration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibration.Click

        fSetCalibration()
    End Sub
    Public Function fSetCalibration() As Boolean
        Dim sDispl0 As Single
        Dim sDispl1 As Single
        Dim sReal0 As Single
        Dim sReal1 As Single
        Dim sRatio As Single
        Dim sOffset As Single
        '  Dim strRcvData As String



        Try
            'Set Value
            sDispl0 = CDbl(tb_Disp1.Text)
            sDispl1 = CDbl(tb_Disp2.Text)

            sReal0 = CSng(tb_Real1.Text)
            sReal1 = CSng(tb_Real2.Text)


            If tb_Real1.Text = "" Or tb_Real2.Text = "" Then
                MsgBox("Real 값을 입력해 주세요.")
                Return False
            End If




            ''쓰기용
            If eMode = eSetMode.eDACMode Then '출력 일때
                sRatio = (sDispl0 - sDispl1) / (sReal0 - sReal1)
                sOffset = sDispl1 - (sRatio * sReal1)
            Else ''읽기용 입력 일때
                sRatio = (sReal0 - sReal1) / (sDispl0 - sDispl1)
                sOffset = sReal1 - (sRatio * sDispl1)
            End If

            tb_CalRatio.Text = Format(sRatio, "0.000000")
            tb_CalOffset.Text = Format(sOffset, "0.000000")

            'Cal 적용 함수 불러 오기
            If eMode = eSetMode.eDACMode Then

                Dim ret As Integer

                If myParent.myParent.cMcSG(m_nSelDev).cSG.Set_DacSlope(myParent.devAddr, myParent.devCH, ret, sRatio, eChannelNum) = False Then
                    Return False
                End If


                If myParent.myParent.cMcSG(m_nSelDev).cSG.Set_DacOffset(myParent.devAddr, myParent.devCH, ret, sOffset, eChannelNum) = False Then
                    Return False
                End If

            ElseIf eMode = eSetMode.eADCMode Then
                Dim ret As Integer
                If myParent.myParent.cMcSG(m_nSelDev).cSG.Set_ADcSlope(myParent.devAddr, myParent.devCH, ret, sRatio, eChannelNum) = False Then
                    Return False
                End If

                If myParent.myParent.cMcSG(m_nSelDev).cSG.Set_ADcOffset(myParent.devAddr, myParent.devCH, ret, sOffset, eChannelNum) = False Then
                    Return False
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function

    Private Sub frmCalibration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReadData1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadData1.Click
        If eMode = eSetMode.eDACMode Then
            If gConditionDac.ChkDacCh1 = True Then
                tb_Disp1.Text = myParent.UcDacFrame1.ChanDac(gConditionDac.ChannelNum).ReadDacLabelArr(0).Text

            ElseIf gConditionDac.ChkDacCh2 = True Then
                tb_Disp1.Text = myParent.UcDacFrame1.ChanDac(gConditionDac.ChannelNum).ReadDacLabelArr(1).Text

            End If

        ElseIf eMode = eSetMode.eADCMode Then
            tb_Disp1.Text = myParent.UcADcFrame1.ChanADc(gConditionAdc.m_ChannelNum).tbAdcAver.Text

        End If
    End Sub

    Private Sub btnReadData2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadData2.Click
        If eMode = eSetMode.eDACMode Then
            If gConditionDac.ChkDacCh1 = True Then
                tb_Disp2.Text = myParent.UcDacFrame1.ChanDac(gConditionDac.ChannelNum).ReadDacLabelArr(0).Text

            ElseIf gConditionDac.ChkDacCh2 = True Then
                tb_Disp2.Text = myParent.UcDacFrame1.ChanDac(gConditionDac.ChannelNum).ReadDacLabelArr(1).Text

            End If

        ElseIf eMode = eSetMode.eADCMode Then
            tb_Disp2.Text = myParent.UcADcFrame1.ChanADc(gConditionAdc.m_ChannelNum).tbAdcAver.Text
        End If
    End Sub
End Class