Public Class FrmSaveFileDialog
    Public Ch As Integer
    Public BeforeFileName()
    Public NewFileName()

    Public lbJIGnumber() As Label
    Dim bCancleFlag As Boolean = False
    Dim bOKFlag As Boolean = False
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        ReDim g_MultiSaveFileName(Ch)
        bOKFlag = True
        g_MultiSavePath = txtSavePath.Text

        Application.DoEvents()

        For idx As Integer = 0 To Ch - 1
            g_MultiSaveFileName(idx) = NewFileName(idx).TEXT
        Next

    End Sub

    Private Sub BtnSaveFilePath_Click(sender As Object, e As EventArgs) Handles BtnSaveFilePath.Click
        Dim fileDlg As New CMcFile()
        Dim strPath As String = Nothing

        If fileDlg.FindFolder(strPath) = True Then
            txtSavePath.Text = strPath
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        bCancleFlag = True
        Me.Close()
    End Sub

    Private Sub FrmSaveFileDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bCancleFlag = True Then
            e.Cancel = False
            Exit Sub
        End If
        'MsgBox("해당 폼은 강제 종료할 수 없습니다.")
        If bOKFlag = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Public Sub New(ByVal Chcnt, ByVal Chvalue(), ByVal Jignum(), ByVal OldFileName())

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init(Chcnt, Chvalue.Clone, Jignum.Clone, OldFileName.Clone)
    End Sub

    Public Sub init(chCnt, ChnumValue(), JIGnum(), OldFileName())

        Ch = chCnt

        ReDim BeforeFileName(chCnt)
        ReDim NewFileName(chCnt)
        ReDim lbJIGnumber(chCnt)

        For idx As Integer = 0 To chCnt - 1
            BeforeFileName(idx) = New TextBox
            NewFileName(idx) = New TextBox
            lbJIGnumber(idx) = New Label

            Panel2.Controls.Add(BeforeFileName(idx))
            Panel2.Controls.Add(NewFileName(idx))
            Panel2.Controls.Add(lbJIGnumber(idx))

            If idx = 0 Then
                BeforeFileName(idx).Location = New System.Drawing.Point(lbformat1.Location.X, lbformat1.Location.Y + lbformat1.Height + 3)
                NewFileName(idx).Location = New System.Drawing.Point(lbformat2.Location.X, lbformat2.Location.Y + lbformat2.Height + 3)
                lbJIGnumber(idx).Location = New System.Drawing.Point(lbJIGnum.Location.X, lbJIGnum.Location.Y + lbJIGnum.Height + 8.5)
            Else
                BeforeFileName(idx).Location = New System.Drawing.Point(lbformat1.Location.X, BeforeFileName(idx - 1).Location.Y + lbformat1.Height + 15)
                NewFileName(idx).Location = New System.Drawing.Point(lbformat2.Location.X, NewFileName(idx - 1).Location.Y + lbformat2.Height + 15)
                lbJIGnumber(idx).Location = New System.Drawing.Point(lbJIGnum.Location.X, lbJIGnumber(idx - 1).Location.Y + lbJIGnum.Height + 15)
            End If

            BeforeFileName(idx).Size = New System.Drawing.Point(lbformat1.Size.Width + 200, lbformat1.Size.Height)
            NewFileName(idx).Size = New System.Drawing.Point(lbformat1.Size.Width + 200, lbformat1.Size.Height)



            lbJIGnumber(idx).Text = "TEG" & JIGnum(idx)
            BeforeFileName(idx).text = OldFileName(idx)

            BeforeFileName(idx).BringToFront()
            NewFileName(idx).BringToFront()
        Next
        ' txtFileName.ImeMode = Windows.Forms.ImeMode.Alpha
    End Sub

    Private Sub txtMasterFileName_TextChanged(sender As Object, e As EventArgs) Handles txtMasterFileName.TextChanged
        For i As Integer = 0 To Ch - 1
            NewFileName(i).Text = txtMasterFileName.Text
        Next
    End Sub
End Class