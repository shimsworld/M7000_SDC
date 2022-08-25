Public Class ucDispPGPower




#Region "Define"

    Dim m_sPGPwrData As sPGPwr

#Region "Structures"

    Public Structure sPGPwrParam
        Dim dVoltage As Double
        Dim dCurrentLimit As Double
        Dim dONDelay As Double
        Dim dOFFDelay As Double
    End Structure


    Public Structure sPGPwr
        Dim nPwrNO() As Integer  '선택된 Power의 번호를 저장하는 변수
        Dim sPower() As sPGPwrParam
    End Structure

#End Region

#End Region


#Region "Creator"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub


    Private Sub init()


    End Sub


#End Region

#Region "Properties"

    Public Property Datas() As sPGPwr
        Get
            If GetValueFromUI() = False Then
                MsgBox("입력 조건이 잘못되었습니다.")
                Return Nothing
            End If
            Return m_sPGPwrData
        End Get
        Set(ByVal value As sPGPwr)
            m_sPGPwrData = value
            SetValueToUI()
        End Set
    End Property
#End Region

#Region "Functions"


    Public Function GetValueFromUI() As Boolean
        Dim pgPwr(4) As sPGPwrParam

        With pgPwr(0)
            .dONDelay = tbOnDelay_V1.Text
            .dVoltage = tbVoltage_V1.Text
            .dOFFDelay = tbOffDelay_V1.Text
            .dCurrentLimit = tbILimit_V1.Text
        End With

        With pgPwr(1)
            .dONDelay = tbOnDelay_V2.Text
            .dVoltage = tbVoltage_V2.Text
            .dOFFDelay = tbOffDelay_V2.Text
            .dCurrentLimit = tbILimit_V2.Text
        End With

        With pgPwr(2)
            .dONDelay = tbOnDelay_V3.Text
            .dVoltage = tbVoltage_V3.Text
            .dOFFDelay = tbOffDelay_V3.Text
            .dCurrentLimit = tbILimit_V3.Text
        End With

        With pgPwr(3)
            .dONDelay = tbOnDelay_V4.Text
            .dVoltage = tbVoltage_V4.Text
            .dOFFDelay = tbOffDelay_V4.Text
            .dCurrentLimit = tbILimit_V4.Text
        End With

        With pgPwr(4)
            .dONDelay = tbOnDelay_V5.Text
            .dVoltage = tbVoltage_V5.Text
            .dOFFDelay = tbOffDelay_V5.Text
            .dCurrentLimit = tbILimit_V5.Text
        End With


        Dim selPowerNo() As Integer = Nothing
        Dim nCntPower As Integer = 0

        If chkSelV1.Checked = True Then
            ReDim Preserve selPowerNo(nCntPower)
            selPowerNo(nCntPower) = 0
            nCntPower += 1
        End If

        If chkSelV2.Checked = True Then
            ReDim Preserve selPowerNo(nCntPower)
            selPowerNo(nCntPower) = 1
            nCntPower += 1
        End If

        If chkSelV3.Checked = True Then
            ReDim Preserve selPowerNo(nCntPower)
            selPowerNo(nCntPower) = 2
            nCntPower += 1
        End If

        If chkSelV4.Checked = True Then
            ReDim Preserve selPowerNo(nCntPower)
            selPowerNo(nCntPower) = 3
            nCntPower += 1
        End If

        If chkSelV5.Checked = True Then
            ReDim Preserve selPowerNo(nCntPower)
            selPowerNo(nCntPower) = 4
            nCntPower += 1
        End If

        m_sPGPwrData.sPower = pgPwr.Clone
        If selPowerNo Is Nothing = False Then
            m_sPGPwrData.nPwrNO = selPowerNo.Clone
        Else
            Return False
        End If

        Return True
    End Function

    Public Sub SetValueToUI()

        If m_sPGPwrData.sPower Is Nothing Then Exit Sub
        If m_sPGPwrData.sPower.Length = 0 Then Exit Sub

        With m_sPGPwrData.sPower(0)
            tbOnDelay_V1.Text = .dONDelay
            tbVoltage_V1.Text = .dVoltage
            tbOffDelay_V1.Text = .dOFFDelay
            tbILimit_V1.Text = .dCurrentLimit
        End With

        With m_sPGPwrData.sPower(1)
            tbOnDelay_V2.Text = .dONDelay
            tbVoltage_V2.Text = .dVoltage
            tbOffDelay_V2.Text = .dOFFDelay
            tbILimit_V2.Text = .dCurrentLimit
        End With

        With m_sPGPwrData.sPower(2)
            tbOnDelay_V3.Text = .dONDelay
            tbVoltage_V3.Text = .dVoltage
            tbOffDelay_V3.Text = .dOFFDelay
            tbILimit_V3.Text = .dCurrentLimit
        End With

        With m_sPGPwrData.sPower(3)
            tbOnDelay_V4.Text = .dONDelay
            tbVoltage_V4.Text = .dVoltage
            tbOffDelay_V4.Text = .dOFFDelay
            tbILimit_V4.Text = .dCurrentLimit
        End With

        With m_sPGPwrData.sPower(4)
            tbOnDelay_V5.Text = .dONDelay
            tbVoltage_V5.Text = .dVoltage
            tbOffDelay_V5.Text = .dOFFDelay
            tbILimit_V5.Text = .dCurrentLimit
        End With

        chkSelV1.Checked = False
        chkSelV2.Checked = False
        chkSelV3.Checked = False
        chkSelV4.Checked = False
        chkSelV5.Checked = False

        For i As Integer = 0 To m_sPGPwrData.nPwrNO.Length - 1
            Dim nCh As Integer
            nCh = m_sPGPwrData.nPwrNO(i)
            Select Case nCh
                Case 0
                    chkSelV1.Checked = True
                Case 1
                    chkSelV2.Checked = True
                Case 2
                    chkSelV3.Checked = True
                Case 3
                    chkSelV4.Checked = True
                Case 4
                    chkSelV5.Checked = True
            End Select
        Next

    End Sub


#End Region


#Region "Event Functions"


#End Region



    Dim m_BeforData As ucDispPGPower.sPGPwr = Nothing

    Private Function InputValueErrorCheck() As Boolean
        Dim m_OptInfo As frmOptionWindow.sOPTIONDATa = Nothing
        frmOptionWindow.LoadSystemOption(m_OptInfo)

        For idx As Integer = 0 To m_sPGPwrData.nPwrNO.Length - 1
            If m_OptInfo.ParamRange.sMDX.Low.dVoltage > m_sPGPwrData.sPower(idx).dVoltage Or _
               m_OptInfo.ParamRange.sMDX.High.dVoltage < m_sPGPwrData.sPower(idx).dVoltage Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub chkSelV1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelV1.CheckedChanged
        If chkSelV1.Checked = True Then
            chkSelV1.BackColor = Color.DeepSkyBlue
        Else
            chkSelV1.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub chkSelV2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelV2.CheckedChanged
        If chkSelV2.Checked = True Then
            chkSelV2.BackColor = Color.DeepSkyBlue
        Else
            chkSelV2.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub chkSelV3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelV3.CheckedChanged
        If chkSelV3.Checked = True Then
            chkSelV3.BackColor = Color.DeepSkyBlue
        Else
            chkSelV3.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub chkSelV4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelV4.CheckedChanged
        If chkSelV4.Checked = True Then
            chkSelV4.BackColor = Color.DeepSkyBlue
        Else
            chkSelV4.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub chkSelV5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelV5.CheckedChanged
        If chkSelV5.Checked = True Then
            chkSelV5.BackColor = Color.DeepSkyBlue
        Else
            chkSelV5.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub tbVoltage_V1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVoltage_V1.TextChanged
        Dim TempText() As String = Split(tbVoltage_V1.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbVoltage_V1.Text)

            If g_SystemOptions.sOptionData.ParamRange.sMDX.Low.dVoltage > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sMDX.High.dVoltage < dValue Then
                tbVoltage_V1.Text = 0
                lbV1_BackColor.BackColor = Color.Red
            Else
                lbV1_BackColor.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbVoltage_V1.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub

    Private Sub tbVoltage_V2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVoltage_V2.TextChanged
        Dim TempText() As String = Split(tbVoltage_V2.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbVoltage_V2.Text)

            If g_SystemOptions.sOptionData.ParamRange.sMDX.Low.dVoltage > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sMDX.High.dVoltage < dValue Then
                tbVoltage_V2.Text = 0
                lbV2_BackColor.BackColor = Color.Red
            Else
                lbV2_BackColor.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbVoltage_V2.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub

    Private Sub tbVoltage_V3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVoltage_V3.TextChanged
        Dim TempText() As String = Split(tbVoltage_V3.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbVoltage_V3.Text)

            If g_SystemOptions.sOptionData.ParamRange.sMDX.Low.dVoltage > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sMDX.High.dVoltage < dValue Then
                tbVoltage_V3.Text = 0
                lbV3_BackColor.BackColor = Color.Red
            Else
                lbV3_BackColor.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbVoltage_V3.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub

    Private Sub tbVoltage_V4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVoltage_V4.TextChanged
        Dim TempText() As String = Split(tbVoltage_V4.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbVoltage_V4.Text)

            If g_SystemOptions.sOptionData.ParamRange.sMDX.Low.dVoltage > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sMDX.High.dVoltage < dValue Then
                tbVoltage_V4.Text = 0
                lbV4_BackColor.BackColor = Color.Red
            Else
                lbV4_BackColor.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbVoltage_V4.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub

    Private Sub tbVoltage_V5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVoltage_V5.TextChanged
        Dim TempText() As String = Split(tbVoltage_V5.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbVoltage_V5.Text)

            If g_SystemOptions.sOptionData.ParamRange.sMDX.Low.dVoltage > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sMDX.High.dVoltage < dValue Then
                tbVoltage_V5.Text = 0
                lbV5_BackColor.BackColor = Color.Red
            Else
                lbV5_BackColor.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbVoltage_V5.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub
  





End Class
