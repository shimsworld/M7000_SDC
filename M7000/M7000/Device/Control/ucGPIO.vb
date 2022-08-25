Public Class Ucgpio

    Public Event UcGPO_Set(ByVal gCondi As Condi)
    Public Event UcGPO_Read(ByVal gCondi As Condi)
    Public Event UcGPIO_OutSet(ByVal gCondi As Condi)
    Public Event UcGPIO_OutRead(ByVal gCondi As Condi)
    Public Event UcGPIO_IN_Read(ByVal gCondi As Condi)
    Public Event UcGPIO_Out_Set(ByVal gCondi As Condi)
    Public Event UcGPIO_Out_Read(ByVal gCondi As Condi)
    Public Structure Condi

        Public m_GPO As Double
        Public m_GPIO_D As Double
        Public m_GPIO_I As Double
        Public m_GPIO_O As Double

    End Structure
    Public gCondition As New Condi

    Private Sub Ucgpio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        init()
    End Sub
    Public Sub init()

        Dim ctrGPO() As CheckBox = {chkPO0, chkPO1, chkPO2, chkPO3, chkPO4, chkPO5, chkPO6, chkPO7, chkPO8, chkPO9, chkPO10, chkPO11, chkPO12, chkPO13, chkPO14, chkPO15}
        Dim ctrGpioD() As CheckBox = {chkGPIOD0, chkGPIOD1, chkGPIOD2, chkGPIOD3, chkGPIOD4, chkGPIOD5, chkGPIOD6, chkGPIOD7, chkGPIOD8, chkGPIOD9, chkGPIOD10, chkGPIOD11, chkGPIOD12, chkGPIOD13, chkGPIOD14, chkGPIOD15}
        Dim ctrGpioIn() As CheckBox = {chkGPIOIn_I0, chkGPIOIn_1, chkGPIOIn2, chkGPIOIn3, chkGPIOIn4, chkGPIOIn5, chkGPIOIn6, chkGPIOIn7, chkGPIOIn8, chkGPIOIn9, chkGPIOIn10, chkGPIOIn11, chkGPIOIn12, chkGPIOIn13, chkGPIOIn14, chkGPIOIn15}
        Dim ctlGpioOut() As CheckBox = {chkGPIOOut_0, chkGPIOOut_1, chkGPIOOut_I2, chkGPIOOut_3, chkGPIOOut_4, chkGPIOOut_5, chkGPIOOut_6, chkGPIOOut_7, chkGPIOOut_8, chkGPIOOut_9, chkGPIOOut_10, chkGPIOOut_11, chkGPIOOut_12, chkGPIOOut_13, chkGPIOOut_14, chkGPIOOut_15}

        For i As Integer = ctrGPO.Length - 1 To 0 Step -1

            If i <> ctrGPO.Length - 1 Then
                ctrGPO(i).Location = New System.Drawing.Point(ctrGPO(i + 1).Location.X + ctrGPO(i + 1).Size.Width, 21)
                ctrGpioD(i).Location = New System.Drawing.Point(ctrGpioD(i + 1).Location.X + ctrGpioD(i + 1).Size.Width, 21)
                ctrGpioIn(i).Location = New System.Drawing.Point(ctrGpioIn(i + 1).Location.X + ctrGpioIn(i + 1).Size.Width, 21)
                ctlGpioOut(i).Location = New System.Drawing.Point(ctlGpioOut(i + 1).Location.X + ctlGpioOut(i + 1).Size.Width, 21)

            Else


                ctrGPO(ctrGPO.Length - 1).Location = New System.Drawing.Point(ctrGPO(ctrGPO.Length - 1).Location.X, 21)
                ctrGpioD(ctrGPO.Length - 1).Location = New System.Drawing.Point(ctrGpioD(ctrGPO.Length - 1).Location.X, 21)
                ctrGpioIn(ctrGPO.Length - 1).Location = New System.Drawing.Point(ctrGpioIn(ctrGPO.Length - 1).Location.X, 21)
                ctlGpioOut(ctrGPO.Length - 1).Location = New System.Drawing.Point(ctlGpioOut(ctrGPO.Length - 1).Location.X, 21)

            End If

        Next

    End Sub

    Private Sub chk_gpoOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_gpoOut.CheckedChanged

    End Sub

    Private Sub chk_gpoOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_gpoOut.Click

        Dim ctrGPO() As CheckBox = {chkPO0, chkPO1, chkPO2, chkPO3, chkPO4, chkPO5, chkPO6, chkPO7, chkPO8, chkPO9, chkPO10, chkPO11, chkPO12, chkPO13, chkPO14, chkPO15}

        For i As Integer = ctrGPO.Length - 1 To 0 Step -1

            ctrGPO(i).Checked = chk_gpoOut.Checked


        Next
    End Sub

   
  

    Private Sub btnPOSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOSet.Click


        Dim ctrGPO() As CheckBox = {chkPO0, chkPO1, chkPO2, chkPO3, chkPO4, chkPO5, chkPO6, chkPO7, chkPO8, chkPO9, chkPO10, chkPO11, chkPO12, chkPO13, chkPO14, chkPO15}
        Dim strDataNum As String = ""
        Dim nDataNum As Integer = 0
        For i As Integer = 0 To ctrGPO.Length - 1
            If ctrGPO(i).Checked = True Then
                nDataNum += 2 ^ i
            End If
        Next

        gCondition.m_GPO = nDataNum

        RaiseEvent UcGPO_Set(gCondition)
    End Sub

    Private Sub btn_GPORead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GPORead.Click
        RaiseEvent UcGPO_Read(gCondition)
    End Sub

    Private Sub btn_GPIO_DSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GPIO_DSet.Click



        Dim ctrGpioD() As CheckBox = {chkGPIOD0, chkGPIOD1, chkGPIOD2, chkGPIOD3, chkGPIOD4, chkGPIOD5, chkGPIOD6, chkGPIOD7, chkGPIOD8, chkGPIOD9, chkGPIOD10, chkGPIOD11, chkGPIOD12, chkGPIOD13, chkGPIOD14, chkGPIOD15}
        Dim ctrGpioIn() As CheckBox = {chkGPIOIn_I0, chkGPIOIn_1, chkGPIOIn2, chkGPIOIn3, chkGPIOIn4, chkGPIOIn5, chkGPIOIn6, chkGPIOIn7, chkGPIOIn8, chkGPIOIn9, chkGPIOIn10, chkGPIOIn11, chkGPIOIn12, chkGPIOIn13, chkGPIOIn14, chkGPIOIn15}
        Dim ctlGpioOut() As CheckBox = {chkGPIOOut_0, chkGPIOOut_1, chkGPIOOut_I2, chkGPIOOut_3, chkGPIOOut_4, chkGPIOOut_5, chkGPIOOut_6, chkGPIOOut_7, chkGPIOOut_8, chkGPIOOut_9, chkGPIOOut_10, chkGPIOOut_11, chkGPIOOut_12, chkGPIOOut_13, chkGPIOOut_14, chkGPIOOut_15}

        For cnt As Integer = 0 To ctrGpioD.Length - 1

            ctlGpioOut(cnt).Checked = False
            ctrGpioIn(cnt).Checked = False

        Next

      


        Dim nDataNum As Integer = 0
        For cnt As Integer = 0 To ctrGpioD.Length - 1

            If ctrGpioD(cnt).Checked = True Then
                nDataNum += 2 ^ cnt
                ctlGpioOut(cnt).Enabled = True
                ctrGpioIn(cnt).Enabled = False
            Else
                ctlGpioOut(cnt).Enabled = False
                ctrGpioIn(cnt).Enabled = True

            End If
        Next


        gCondition.m_GPIO_D = nDataNum

        RaiseEvent UcGPIO_OutSet(gCondition)
    End Sub

    Private Sub btn_GPIO_DRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GPIO_DRead.Click
        RaiseEvent UcGPIO_OutRead(gCondition)
    End Sub

    Private Sub btnPEset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPEset.Click
        RaiseEvent UcGPIO_IN_Read(gCondition)
    End Sub

    Private Sub btnGPIO_Read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGPIO_Read.Click
        Dim SetValue As Double

        Dim ctlGpioOut() As CheckBox = {chkGPIOOut_0, chkGPIOOut_1, chkGPIOOut_I2, chkGPIOOut_3, chkGPIOOut_4, chkGPIOOut_5, chkGPIOOut_6, chkGPIOOut_7, chkGPIOOut_8, chkGPIOOut_9, chkGPIOOut_10, chkGPIOOut_11, chkGPIOOut_12, chkGPIOOut_13, chkGPIOOut_14, chkGPIOOut_15}
        For i As Integer = 0 To 15
            If ctlGpioOut(i).Checked = True Then
                SetValue += 2 ^ i
            End If
        Next


        gCondition.m_GPIO_O = SetValue
        RaiseEvent UcGPIO_Out_Set(gCondition)

    End Sub

    Private Sub btnGpioRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGpioRead.Click
        RaiseEvent UcGPIO_Out_Read(gCondition)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click



        Dim ctrGpioD() As CheckBox = {chkGPIOD0, chkGPIOD1, chkGPIOD2, chkGPIOD3, chkGPIOD4, chkGPIOD5, chkGPIOD6, chkGPIOD7, chkGPIOD8, chkGPIOD9, chkGPIOD10, chkGPIOD11, chkGPIOD12, chkGPIOD13, chkGPIOD14, chkGPIOD15}
        For i As Integer = 0 To 15
            ctrGpioD(i).Checked = CheckBox1.Checked


        Next


    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        Dim ctlGpioOut() As CheckBox = {chkGPIOOut_0, chkGPIOOut_1, chkGPIOOut_I2, chkGPIOOut_3, chkGPIOOut_4, chkGPIOOut_5, chkGPIOOut_6, chkGPIOOut_7, chkGPIOOut_8, chkGPIOOut_9, chkGPIOOut_10, chkGPIOOut_11, chkGPIOOut_12, chkGPIOOut_13, chkGPIOOut_14, chkGPIOOut_15}
        For i As Integer = 0 To ctlGpioOut.Length - 1
            ctlGpioOut(i).Checked = CheckBox2.Checked
        Next



    End Sub
End Class
