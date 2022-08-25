Imports System.Threading

Public Class frmSVSCamera

    Public cSVS As cSVSCamera_API.cSVSCamera = New cSVSCamera_API.cSVSCamera
    Dim TempList() As cSVSCamera_API.cSVSCamera.sConfigInfo
    Dim m_Connected As Boolean = False

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        init()
    End Sub

    Public Sub init()
        '    cbSelAlarm1Type.DataSource = m_Main.cTC(m_nSelDevGroup).sAlarmTypes

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TempList = cSVS.Serach_Camera()

        If TempList Is Nothing = False Then
            If TempList.Length > 0 Then
                With ComboBox1
                    .Items.Clear()
                    For i As Integer = 0 To TempList.Length - 1
                        .Items.Add(TempList(i).hCamera.ToString)
                        .SelectedIndex = 0
                    Next
                End With
            End If
        End If

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            If cSVS.bConnected() = False Then
                If cSVS.Connection(TempList(ComboBox1.SelectedIndex), 3) = True Then
                    IDN()
                    btnConnect.BackColor = Color.YellowGreen
                    m_Connected = True
                    Label12.Text = "Connect Complete"
                End If
            End If
        Catch ex As Exception
            MsgBox("Connection Error")
            btnConnect.BackColor = Color.Red
            m_Connected = False
        End Try
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        Try
            If cSVS.bConnected() = True Then
                If cSVS.Disconnection(TempList(ComboBox1.SelectedIndex)) = True Then
                    btnConnect.BackColor = Color.Red
                    Label12.Text = "Disconnect Complete"
                End If
            End If
        Catch ex As Exception
            MsgBox("Disconnection Error")
        End Try

        m_Connected = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        IDN()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If cSVS.bConnected = True Then
                If cSVS.Disconnection(TempList(ComboBox1.SelectedIndex)) = True Then
                End If
            End If
        Catch ex As Exception
            MsgBox("Disconnection Error")
        End Try
        m_Connected = False
    End Sub

    Dim bStop As Boolean = False

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        bStop = True
        UpdateImage()
    End Sub

    Public Sub IDN()
        If cSVS.bConnected() = True Then
            Dim Temp_IDN As cSVSCamera_API.cSVSCamera.sDeviceInfo = Nothing
            If cSVS.Identify(TempList(ComboBox1.SelectedIndex), Temp_IDN) = True Then
                Label2.Text = Temp_IDN.Model
                Label3.Text = Temp_IDN.Manufactor
                Label5.Text = Temp_IDN.Device_Version
                Label7.Text = Temp_IDN.Serial_Number
                Label9.Text = Temp_IDN.User_Defined_Name
            End If
        Else
            Label2.Text = ""
            Label3.Text = ""
            Label5.Text = ""
            Label7.Text = ""
            Label9.Text = ""
            MsgBox("Disconnection Error")
        End If
    End Sub

    Private Sub UpdateImage()
        Dim img As Bitmap = Nothing
        Dim imsibuffer() As Byte = Nothing

        Do

            If cSVS.GetimgData(img, imsibuffer) = False Then
                MsgBox("Data is Empty.")
                bStop = False
                Exit Sub
            End If

            PictureBox1.Image = img

            Dim str As String = Nothing

            For idx As Integer = 0 To 20
                str = str & " " & CStr(imsibuffer(idx))
            Next

            Label11.Text = str

            Application.DoEvents()
            Thread.Sleep(10)

        Loop Until bStop = False
    End Sub


    Private Sub btnSTOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTOP.Click
        If bStop = True Then bStop = False

    End Sub


    Private Sub btnGRAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGRAP.Click
        Dim img As Bitmap = Nothing
        Dim imsibuffer() As Byte = Nothing

        If cSVS.GetimgData(img, imsibuffer) = False Then
            MsgBox("Data is Empty.")
        End If

        'cSVS.aaa(img)

        PictureBox1.Image = img

        Dim str As String = Nothing

        For idx As Integer = 0 To 20
            str = str & " " & CStr(imsibuffer(idx))
        Next

        Label11.Text = str
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Width = 720
        PictureBox1.Height = 680
    End Sub

    Private Sub btnImageSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImageSave.Click
        Dim img As Bitmap = Nothing
        Dim imsibuffer() As Byte = Nothing
        Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        With SavefileDlg
            .Title = "SaveFile"
            .Filter = "BMP(*.bmp)|*.bmp"
            .InitialDirectory = "App.path" 'SYSTemOption.outPut.strDefSavePathOfRcpFile
            .OverwritePrompt = False
            .AddExtension = True
        End With

        If SavefileDlg.ShowDialog = DialogResult.OK Then
            If cSVS.GetimgData(img, imsibuffer) = False Then
                MsgBox("Data is Empty.")
            End If

            img.Save(SavefileDlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
        End If



    End Sub

End Class
