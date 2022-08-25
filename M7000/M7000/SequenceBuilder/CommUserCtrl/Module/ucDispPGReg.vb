Imports System.IO

Public Class ucDispPGReg

#Region "Define"


    Dim m_PGRegDatas As sPGReg

    Dim numData As Integer = 0

#Region "Structure"
    Public Structure sPGReg
        Dim numOfReg As Integer
        Dim sReg() As sPGRegParam
        Dim ePattern As ucMcPGControl.ePattern
    End Structure


    Public Structure sPGRegParam
        Dim sRegName As String
        Dim byCMD As Byte
        Dim nLenOfValue As Integer
        Dim byValue() As Byte
    End Structure

#End Region



#End Region



#Region "Properties"

    Public Property Datas() As sPGReg
        Get
            GetValuetoGridView()
            Return m_PGRegDatas
        End Get
        Set(ByVal value As sPGReg)
            m_PGRegDatas = value
            SetValuetoGridView()
        End Set
    End Property

#End Region


#Region "Creators"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        spcMain.Location = New System.Drawing.Point(0, 0)
        spcMain.Dock = DockStyle.Fill

        ucDispDataGrid.Location = New System.Drawing.Point(0, 0)
        ucDispDataGrid.Dock = DockStyle.Fill

        ucDispDataGrid.RowLineNum = 0

        gbImportExport.Location = New System.Drawing.Point(0, 0)
        gbImportExport.Dock = DockStyle.Fill

        gbSettings.Location = New System.Drawing.Point(0, 0)
        gbSettings.Dock = DockStyle.Fill

        cbo_Pattern.SelectedIndex = 0
    End Sub


#End Region



#Region "Functions"


    Private Sub GetValueFromUI()
        Dim patternIndex As ucMcPGControl.ePattern

        Select Case cbo_Pattern.SelectedIndex
            Case 0
                patternIndex = ucMcPGControl.ePattern.eSingleColor
            Case 1
                patternIndex = ucMcPGControl.ePattern.e5by5Pattern
            Case 2
                patternIndex = ucMcPGControl.ePattern.e5by5Pattern_UserDefColor
            Case 3
                patternIndex = ucMcPGControl.ePattern.eH_3ColorLine
            Case 4
                patternIndex = ucMcPGControl.ePattern.eV_3ColorLine
            Case Else
                patternIndex = -1
        End Select

        m_PGRegDatas.ePattern = patternIndex

    End Sub


    Private Sub SetValueToUI()

        Dim patternIndex As ucMcPGControl.ePattern

        Select Case m_PGRegDatas.ePattern
            Case ucMcPGControl.ePattern.eSingleColor
                cbo_Pattern.SelectedIndex = 0
            Case ucMcPGControl.ePattern.e5by5Pattern
                cbo_Pattern.SelectedIndex = 1
            Case ucMcPGControl.ePattern.e5by5Pattern_UserDefColor
                cbo_Pattern.SelectedIndex = 2
            Case ucMcPGControl.ePattern.eH_3ColorLine
                cbo_Pattern.SelectedIndex = 3
            Case ucMcPGControl.ePattern.eV_3ColorLine
                cbo_Pattern.SelectedIndex = 4
            Case Else
                patternIndex = -1
        End Select

    End Sub


#End Region


#Region "Event Functions"




#End Region



    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sParam As sPGRegParam

        'Dim sValue As String
        Dim byValues() As Byte = Nothing
        Dim byValue As Byte
        Dim sData(3) As String

        With sParam
            .sRegName = tbRegName.Text
            sData(0) = .sRegName

            sData(1) = tbAddress.Text
            If ConverStringToByte(tbAddress.Text, byValue) = False Then
                MsgBox("Check the input values")
                Exit Sub
            End If
            .byCMD = byValue

            sData(3) = tbValue.Text
            If ConvertStringToByteArray(tbValue.Text, " ", byValues) = False Then
                MsgBox("Check the input values")
                Exit Sub
            End If
            .byValue = byValues.Clone
            .nLenOfValue = .byValue.Length
            sData(2) = CStr(.nLenOfValue)
        End With


        ucDispDataGrid.AddRowData(sData)

        numData = m_PGRegDatas.numOfReg

        numData += 1

        m_PGRegDatas.numOfReg = numData

    End Sub


    Private Function ConvertStringToByteArray(ByVal str As String, ByVal seperator As String, ByRef byteArr As Byte()) As Boolean

        Dim arrVal As Array = Split(str, seperator, -1)
        Dim bVal(arrVal.Length - 1) As Byte
        Try
            For i As Integer = 0 To arrVal.Length - 1
                bVal(i) = "&H" & arrVal(i)
            Next
        Catch ex As Exception
            Return False
        End Try

        byteArr = bVal.Clone
        Return True
    End Function


    Private Function ConverStringToByte(ByVal str As String, ByRef byteValue As Byte) As Boolean

        Dim bVal As Byte
        Try
            bVal = "&H" & str
        Catch ex As Exception
            Return False
        End Try

        byteValue = bVal
        Return True
    End Function



    Private Sub UPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPToolStripMenuItem.Click

    End Sub

    Private Sub DOWNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOWNToolStripMenuItem.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ucDispDataGrid.ClearRow()

        m_PGRegDatas.numOfReg = 0
        m_PGRegDatas.sReg = Nothing
        numData = 0
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        LoadConfiguration()
        SetValuetoGridView()

        'Datas = m_traData
        ucDispDataGrid.ReAdjustRow()
    End Sub


    Public g_sPATH_SYSINI As String = New String(Application.StartupPath & "\Recipes\PG Register\")

    Public g_SysConfig_FileName As String = "PatternGenerator.pgi"

    Public Function LoadConfiguration() As Boolean

        If File.Exists(g_sPATH_SYSINI & g_SysConfig_FileName) = False Then
            MsgBox("Load할 파일이 없습니다.")
        Else
        End If

        Dim BufData As sPGReg = Nothing
        ' Dim TempData As String
        Dim configLoader As New cls_INI(g_sPATH_SYSINI & g_SysConfig_FileName)

        'configSaver.IniWriteValue("Info", "Number of RegData", m_PGRegDatas.numOfReg)
        BufData.numOfReg = configLoader.IniReadValue("Info", "Number of RegData")
        ReDim BufData.sReg(BufData.numOfReg - 1)

        Try
            txtComments.Text = configLoader.IniReadValue("Info", "Comments")

            ucDispDataGrid.ClearRow()

            For i As Integer = 0 To BufData.numOfReg - 1

                BufData.sReg(i).sRegName = configLoader.IniReadValue("Reg " & i, "RegName")
                BufData.sReg(i).byCMD = configLoader.IniReadValue("Reg " & i, "CMD")
                BufData.sReg(i).nLenOfValue = configLoader.IniReadValue("Reg " & i, "Length")

                ReDim BufData.sReg(i).byValue(BufData.sReg(i).nLenOfValue - 1)

                For idx As Integer = 0 To BufData.sReg(i).nLenOfValue - 1
                    BufData.sReg(i).byValue(idx) = configLoader.IniReadValue("Reg " & i, "Value " & idx)
                Next
            Next

            m_PGRegDatas.numOfReg = BufData.numOfReg
            m_PGRegDatas.sReg = BufData.sReg

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Sub GetValuetoGridView()

        Dim Index As ucMcPGControl.ePattern

        Select Case cbo_Pattern.SelectedIndex
            Case 0
                Index = ucMcPGControl.ePattern.eSingleColor
            Case 1
                Index = ucMcPGControl.ePattern.e5by5Pattern
            Case 2
                Index = ucMcPGControl.ePattern.e5by5Pattern_UserDefColor
            Case 3
                Index = ucMcPGControl.ePattern.eH_3ColorLine
            Case 4
                Index = ucMcPGControl.ePattern.eV_3ColorLine
            Case Else
                Index = -1
        End Select

        m_PGRegDatas.ePattern = Index

        ReDim m_PGRegDatas.sReg(m_PGRegDatas.numOfReg - 1)

        For i As Integer = 0 To m_PGRegDatas.numOfReg - 1

            m_PGRegDatas.sReg(i).sRegName = ucDispDataGrid.DataGridView.Rows(i).Cells(0).Value
            m_PGRegDatas.sReg(i).byCMD = ucDispDataGrid.DataGridView.Rows(i).Cells(1).Value
            m_PGRegDatas.sReg(i).nLenOfValue = ucDispDataGrid.DataGridView.Rows(i).Cells(2).Value

            Dim imsi As String = Nothing
            imsi = ucDispDataGrid.DataGridView.Rows(i).Cells(3).Value

            Dim arrVal As Array = Split(imsi, " ", -1)

            If arrVal(arrVal.Length - 1) = "" Then
                ReDim m_PGRegDatas.sReg(i).byValue(arrVal.Length - 2)
            Else
                ReDim m_PGRegDatas.sReg(i).byValue(arrVal.Length - 1)
            End If


            For idx As Integer = 0 To m_PGRegDatas.sReg(i).byValue.Length - 1
                m_PGRegDatas.sReg(i).byValue(idx) = arrVal(idx)
            Next
        Next
    End Sub

    Public Sub SetValuetoGridView()

        ucDispDataGrid.ClearRow()

        Dim sData(2) As String
        sData(0) = ""
        sData(1) = ""
        sData(2) = ""

        Select Case m_PGRegDatas.ePattern
            Case ucMcPGControl.ePattern.eSingleColor
                cbo_Pattern.SelectedIndex = 0
            Case ucMcPGControl.ePattern.e5by5Pattern
                cbo_Pattern.SelectedIndex = 1
            Case ucMcPGControl.ePattern.e5by5Pattern_UserDefColor
                cbo_Pattern.SelectedIndex = 2
            Case ucMcPGControl.ePattern.eH_3ColorLine
                cbo_Pattern.SelectedIndex = 3
            Case ucMcPGControl.ePattern.eV_3ColorLine
                cbo_Pattern.SelectedIndex = 4
        End Select


        For idx As Integer = 0 To m_PGRegDatas.numOfReg - 1
            ucDispDataGrid.AddRowData(sData)
        Next

        For i As Integer = 0 To m_PGRegDatas.numOfReg - 1

            ucDispDataGrid.DataGridView.Rows(i).Cells(0).Value = m_PGRegDatas.sReg(i).sRegName
            ucDispDataGrid.DataGridView.Rows(i).Cells(1).Value = m_PGRegDatas.sReg(i).byCMD
            ucDispDataGrid.DataGridView.Rows(i).Cells(2).Value = m_PGRegDatas.sReg(i).nLenOfValue

            Dim imsi As String = Nothing

            For idx As Integer = 0 To m_PGRegDatas.sReg(i).nLenOfValue - 1
                imsi = imsi & m_PGRegDatas.sReg(i).byValue(idx).ToString & " "
            Next

            ucDispDataGrid.DataGridView.Rows(i).Cells(3).Value = imsi 'm_PGRegDatas.sReg(i).byValue
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        GetValuetoGridView()

        If SaveConfiguration(m_PGRegDatas) = True Then
        Else
            MsgBox("저장이 잘못되었습니다.")
        End If
    End Sub

    Public Function SaveConfiguration(ByVal configInfos As sPGReg) As Boolean

        Dim sFileTitle As String = "Patttern Generator"

        If Directory.Exists(g_sPATH_SYSINI) = False Then
            Directory.CreateDirectory(g_sPATH_SYSINI)
        End If

        Dim configSaver As New cls_INI(g_sPATH_SYSINI & g_SysConfig_FileName)

        Try
            configSaver.IniWriteValue("Pattern Generator Setting Info", "Title", sFileTitle)
            configSaver.IniWriteValue("Info", "Number of RegData", m_PGRegDatas.numOfReg)
            configSaver.IniWriteValue("Info", "Comments", txtComments.Text)

            With configInfos
                For i As Integer = 0 To m_PGRegDatas.numOfReg - 1

                    configSaver.IniWriteValue("Reg " & i, "RegName", configInfos.sReg(i).sRegName.ToString)
                    configSaver.IniWriteValue("Reg " & i, "CMD", configInfos.sReg(i).byCMD.ToString)
                    configSaver.IniWriteValue("Reg " & i, "Length", configInfos.sReg(i).nLenOfValue)

                    For idx As Integer = 0 To configInfos.sReg(i).nLenOfValue - 1
                        configSaver.IniWriteValue("Reg " & i, "Value " & idx, configInfos.sReg(i).byValue(idx).ToString)
                    Next

                Next

            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
