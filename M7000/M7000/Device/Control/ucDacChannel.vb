Imports System.IO

Public Class UcDacChannel

    Dim m_nMyCh As Integer
    Dim m_sRcpFilePath As String
    Dim m_bIsLoaded As Boolean = False
    Public g_sPathSetting As String = Application.StartupPath & "\Settings"
    Public g_sPath_DAC As String = g_sPathSetting & "\DAC\"
    Public g_sPath_ADC As String = g_sPathSetting & "\ADC\"
    Public g_sPath_GPIO As String = g_sPathSetting & "\GPIO\"


    Public ReadDacLabelArr(1) As Label
    Public Structure Condi
        Public ChannelNum As Double

        Public ChkMode As Integer

        Public ChkDacCh1 As Boolean
        Public ChkDacCh2 As Boolean

        Public OnOff As Boolean

        'Public DacChannelNum1 As Integer
        'Public DacChannelNum2 As Integer

        Public DacChannelNum() As Integer
        Public DacSetVolt() As Double
        'Public DacSetVoltLow As Double
        'Public DacSetVoltHigh As Double

        Public Period As Double
        Public Width As Double
        Public Delay As Double
    End Structure
    Public gCondition As New Condi
    Public Event UcChannelMouseMove(ByVal gCondi As Condi)
    Public Event UcChannelDacSet(ByVal gCondi As Condi) 'DAC 출력 set
    Public Event UcChannelDacGet(ByVal gCondi As Condi) 'DAC 출력 read
    Public Event UcChannelDacOnOFF(ByVal gCondi As Condi) 'DAC 출력 read
    Public Event UcChannelDacCheckClick(ByVal gCondi As Condi) 'DAC Chkbox read
    Public Event UcChannelSettingClk(ByVal gCondi As Condi) 'DAC Chkbox read
    Public Event UcChannelCalSet(ByVal gCondi As Condi)
    Public Event UcChannelCalGet(ByVal gCondi As Condi)
    Private Sub rdo_dcMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_dcMode.Click

        RaiseEvent UcChannelMouseMove(gCondition)
        If rdo_dcMode.Checked = True Then

            rdo_ch1.Enabled = True
            rdo_ch1.Enabled = True


            GroupBox4.Enabled = False
            gCondition.ChkMode = 0
        End If
    End Sub


    Private Sub rdo_pulseMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_pulseMode.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        If rdo_pulseMode.Checked = True Then

            rdo_ch1.Enabled = False
            rdo_ch1.Enabled = False

            GroupBox4.Enabled = True
            gCondition.ChkMode = 1
        End If
    End Sub

    Private Sub lbl_dacnum1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_dacnum1.Click


    End Sub

    Private Sub lbl_dacnum2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_dacnum2.Click

    End Sub

    Private Sub btnSetDAC_Low_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDAC_Low.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        If CheckSetError() = True Then
            RaiseEvent UcChannelDacSet(gCondition)
            fCheckButton(0)
        End If



    End Sub
    Public Function CheckSetError() As Boolean

        Try
            If CDbl(txt_LowDAC.Text) < -5 Or CDbl(txt_LowDAC.Text) > 5 Then
                MsgBox("Dac 설정 값 이 최대 범위를 초과 하였습니다!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If

            If CDbl(txt_HighDAC.Text) < -5 Or CDbl(txt_HighDAC.Text) > 5 Then
                MsgBox("Dac 설정 값 이 최대 범위를 초과 하였습니다!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If

            gCondition.Period = CDbl(txt_period.Text)
            gCondition.Width = CDbl(txt_width.Text)
            gCondition.Delay = CDbl(txt_delay.Text)


            gCondition.DacSetVolt(0) = CDbl(txt_LowDAC.Text)
            gCondition.DacSetVolt(1) = CDbl(txt_HighDAC.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True

    End Function

    Private Sub btn_GetDacLow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetDacLow.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelDacGet(gCondition)
        fCheckButton(1)
    End Sub


    Private Sub rdo_ch1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub rdo_ch2_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Public btnArr(3) As Button
    Private Sub UcDacChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        init()
    End Sub
    Public Sub init()
        gCondition.ChkDacCh1 = True
        gCondition.ChkDacCh2 = True
        gCondition.ChkMode = 0

        gCondition.Period = 100
        gCondition.Width = 100
        gCondition.Delay = 100

        gCondition.OnOff = False


        ReDim gCondition.DacChannelNum(1)
        ReDim gCondition.DacSetVolt(1)


        ReadDacLabelArr(0) = lbl_realdac1
        ReadDacLabelArr(1) = lbl_realdac2




        btnArr(0) = btnSetDAC_Low
        btnArr(1) = btn_GetDacLow
        btnArr(2) = btn_calSet
        btnArr(3) = btn_calget

    End Sub

    Private Sub btnOnOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnOff.Click

        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelDacOnOFF(gCondition)

    End Sub
    Public Sub fCheckButton(ByVal inIndex As Integer)
        For Cnt As Integer = 0 To btnArr.Length - 1
            If Cnt = inIndex Then
                btnArr(Cnt).BackColor = Color.DeepPink
            Else
                btnArr(Cnt).BackColor = Color.LightGray

            End If

        Next

    End Sub

    Private Sub rdo_pulseMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_pulseMode.CheckedChanged

    End Sub

    Private Sub chk_ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chk_ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Chk_CH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_CH.CheckedChanged

    End Sub

    Private Sub Chk_CH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_CH.Click

        RaiseEvent UcChannelDacCheckClick(gCondition)
    End Sub

    Private Sub rdo_dcMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_dcMode.CheckedChanged

    End Sub

    Private Sub btn_calSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calSet.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelCalSet(gCondition)
        fCheckButton(2)
    End Sub

    Private Sub btn_calget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calget.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        RaiseEvent UcChannelCalGet(gCondition)
        fCheckButton(3)
    End Sub

    Private Sub rdo_ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_ch2.CheckedChanged

    End Sub

    Private Sub rdo_ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_ch1.CheckedChanged

    End Sub

    Private Sub rdo_ch1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_ch1.Click
        RaiseEvent UcChannelMouseMove(gCondition)


        If rdo_ch1.Checked = True Then

            gCondition.ChkDacCh1 = True
            gCondition.ChkDacCh2 = False
        Else
            gCondition.ChkDacCh1 = False
            gCondition.ChkDacCh2 = True
        End If
    End Sub

    Private Sub rdo_ch2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_ch2.Click
        RaiseEvent UcChannelMouseMove(gCondition)
        If rdo_ch2.Checked = True Then
            gCondition.ChkDacCh2 = True
            gCondition.ChkDacCh1 = False
        Else
            gCondition.ChkDacCh2 = False
            gCondition.ChkDacCh1 = True
        End If
    End Sub


    Public Function LoadRecipe() As Boolean

        If m_bIsLoaded = False Then Return False
        If File.Exists(m_sRcpFilePath) = False Then Return False

        Dim sFileTitle As String = "Recipe Info"
        Dim Loader As New CIODacInfo(m_sRcpFilePath)
        Dim sTemp As String
        Dim nValue As String

        sTemp = Loader.LoadIniValue(CIODacInfo.eSecID.eFileInfo, 0, CIODacInfo.eKeyID.FileTitle)
        If sTemp <> sFileTitle Then Return False

        nValue = Loader.LoadIniValue(CIODacInfo.eSecID.eFileInfo, 0, CIODacInfo.eKeyID.eChannelNumber)
        If m_nMyCh <> nValue Then Return False

        gCondition.ChkMode = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.eMode)
        gCondition.ChkDacCh1 = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.eIsSelectedDAC_High)
        gCondition.ChkDacCh2 = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.eIsSelectedDAC_Low)
        gCondition.DacSetVolt(0) = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.eDAC_High_Value)
        gCondition.DacSetVolt(1) = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.eDAC_Low_Value)

        gCondition.Delay = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.ePulse_Delay)
        gCondition.Width = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.ePulse_Width)
        gCondition.Period = Loader.LoadIniValue(CIODacInfo.eSecID.eRecipe, 0, CIODacInfo.eKeyID.ePulse_Period)

        Return True
    End Function

    Public Sub SetValueToUI()

        If m_bIsLoaded = False Then Exit Sub
        If gCondition.ChkMode = 0 Then
            rdo_dcMode.Checked = True
        Else
            rdo_pulseMode.Checked = True
        End If

        If gCondition.ChkDacCh1 = True Then
            rdo_ch1.Checked = True
        End If

        If gCondition.ChkDacCh2 = True Then
            rdo_ch2.Checked = True
        End If

        txt_HighDAC.Text = Format(gCondition.DacSetVolt(0), "0.0##")
        txt_LowDAC.Text = Format(gCondition.DacSetVolt(1), "0.0##")

        txt_delay.Text = gCondition.Delay / 1000
        txt_width.Text = gCondition.Width / 1000
        txt_period.Text = gCondition.Period / 1000
    End Sub

    Public Sub New(ByVal nCh As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_nMyCh = nCh
        m_sRcpFilePath = g_sPath_DAC & "CH" & Format(nCh + 1, "00") & ".ini"
    End Sub
End Class


Public Class CIODacInfo
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Recipe Infos"}


    Private strKey() As String = New String() {
"File Title", "Channel Number", _
"Mode", "Is Selected High DAC", "Is Selected Low DAC", "Value Of High DAC", "Value Of Low DAC", "Pulse Delay", "Pulse Width", "Pulse Period", "Ratio", "Offset"
 }


    Public Enum eSecID
        eFileInfo
        eRecipe
    End Enum

    Public Enum eKeyID
        FileTitle
        eChannelNumber
        eMode
        eIsSelectedDAC_High
        eIsSelectedDAC_Low
        eDAC_High_Value
        eDAC_Low_Value
        ePulse_Delay
        ePulse_Width
        ePulse_Period
        eRatio
        eOffset
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
