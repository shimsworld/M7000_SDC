Imports System.IO

Public Class ucDispSignalGenerator


#Region "Defines"

    Public g_sPATH_SYSINI As String = New String(Application.StartupPath & "\Recipes\Signal Generator\")
    Public g_SysConfig_FileName As String = "SignalGenerator.sgi"

    'Dim m_Param As sSGParam
    Dim m_traData As sSGDatas
    Dim nCntSignal As Integer = 0
    Dim m_bIsVisibleOnlyGrid As Boolean = False

    Dim m_sDefCaptionOfPGSignals() As String = New String() {"MainPower1", "MainPower2",
                                                                                    "SubPower1", "SubPower2", "SubPower3", "SubPower4", "SubPower5", "SubPower6", "SubPower7", "SubPower8", "SubPower9", "SubPower10", "SubPower11", "SubPower12",
                                                                                    "Signal1", "Signal2", "Signal3", "Signal4", "Signal5", "Signal6", "Signal7", "Signal8", "Signal9", "Signal10", "Signal11", "Signal12",
                                                                                    "Signal13", "Signal14", "Signal15", "Signal16", "Signal17", "Signal18", "Signal19", "Signal20", "Signal21", "Signal22", "Signal23", "Signal24", "Signal25", "Signal26"}


#Region "Enums"

    Enum ePGSignal
        MainPower1
        MainPower2
        SubPower1
        SubPower2
        SubPower3
        SubPower4
        SubPower5
        SubPower6
        SubPower7
        SubPower8
        SubPower9
        SubPower10
        SubPower11
        SubPower12
        Signal1
        Signal2
        Signal3
        Signal4
        Signal5
        Signal6
        Signal7
        Signal8
        Signal9
        Signal10
        Signal11
        Signal12
        Signal13
        Signal14
        Signal15
        Signal16
        Signal17
        Signal18
        Signal19
        Signal20
        Signal21
        Signal22
        Signal23
        Signal24
        Signal25
        Signal26
    End Enum

    'Enum ePGSourceMode
    '    CV
    '    PV
    'End Enum

#End Region

#Region "Structure"

    Public Structure sSGParam
        Dim eSignal As ePGSignal
        Dim sSignalName As String
        Dim eSrcMode As cDevSG.eDacMode
        Dim dBias As Double
        Dim dAmplitude As Double
        Dim sPulse As cDevSG.sPulseParam
        Dim sLimit As cDevSG.sLimit
    End Structure

    Public Structure sSGDatas
        Dim sParamData() As sSGParam
        Dim nPDAvgCount As Integer
        Dim nLenSignal As Integer
    End Structure

#End Region


#End Region


#Region "Properties"

    Public Property Settings() As sSGDatas
        Get
            Return m_traData
        End Get
        Set(ByVal value As sSGDatas)
            m_traData = value
            UpdateList()
            'SetValuetoGridView()

        End Set
    End Property


    Public Property IsVisibleOnlyGrid As Boolean
        Get
            Return m_bIsVisibleOnlyGrid
        End Get
        Set(ByVal value As Boolean)
            m_bIsVisibleOnlyGrid = value
            If m_bIsVisibleOnlyGrid = True Then
                SplitContainer1.SplitterDistance = SplitContainer1.Size.Width
                SplitContainer1.Panel2.Hide()
                SplitContainer2.Visible = False
            Else
                SplitContainer1.Panel2.Show()
                SplitContainer2.Visible = True
            End If

        End Set
    End Property

#End Region


#Region "Creator"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()

        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Dock = DockStyle.Fill
        ucDispDataGrid.Location = New System.Drawing.Point(0, 0)
        ucDispDataGrid.Dock = DockStyle.Fill

        gbControl.Location = New System.Drawing.Point(0, 0)
        gbControl.Dock = DockStyle.Fill
        gbImportExport.Location = New System.Drawing.Point(0, 0)
        gbImportExport.Dock = DockStyle.Fill


        SplitContainer1.Panel2.Show()

        SplitContainer2.Visible = True

        cboControlLine.Items.Clear()

        If g_ConfigInfos.SGOutputInfo.strSignalName Is Nothing = False Then
            For i As Integer = 0 To g_ConfigInfos.SGOutputInfo.strSignalName.Length - 1
                cboControlLine.Items.Add(g_ConfigInfos.SGOutputInfo.strSignalName(i))
            Next
        Else
            For i As Integer = 0 To m_sDefCaptionOfPGSignals.Length - 1
                cboControlLine.Items.Add(m_sDefCaptionOfPGSignals(i))
            Next
        End If
    End Sub

#End Region

    Public Sub ClearData()
        m_traData = Nothing
        nCntSignal = 0
        UpdateList()
    End Sub

 
    Public Sub DelData(ByVal nSelRow As Integer)
        Try
            Dim tempData As sSGDatas
            Dim nCnt As Integer

            ReDim tempData.sParamData(m_traData.sParamData.Length - 2)

            For i As Integer = 0 To m_traData.sParamData.Length - 1
                If i <> nSelRow Then
                    tempData.sParamData(nCnt) = m_traData.sParamData(i)
                    nCnt += 1
                End If
            Next

            m_traData.sParamData = tempData.sParamData.Clone
            m_traData.nLenSignal = m_traData.sParamData.Length
            nCntSignal -= 1
            UpdateList()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddData(ByVal bufData As sSGParam)

        If nCntSignal < 0 Then nCntSignal = 0 '카운터 에러 방지

        ReDim Preserve m_traData.sParamData(nCntSignal)         '고정으로 배열 40개를 만든 후 데이터를 저장함.
        m_traData.sParamData(nCntSignal) = bufData
        AddList(m_traData.sParamData(nCntSignal))
        nCntSignal += 1

        m_traData.nLenSignal = m_traData.sParamData.Length                  '데이터를 저장할 때마다 nLenSignal의 개수가 증가

    End Sub

    Public Sub UpdateList()
        ucDispDataGrid.ClearRow()
        If m_traData.sParamData Is Nothing Then Exit Sub
        For i As Integer = 0 To m_traData.sParamData.Length - 1
            AddList(m_traData.sParamData(i))
        Next

        txtPDAverage.Text = m_traData.nPDAvgCount
    End Sub

    Public Sub AddList(ByVal Param As sSGParam)    '
        Dim sData(9) As String
        '  Dim listindex As Integer

        sData(0) = Param.sSignalName
        sData(1) = Param.eSrcMode.ToString
        sData(2) = CStr(Param.dBias)
        sData(3) = CStr(Param.dAmplitude)
        sData(4) = CStr(Param.sPulse.Delay)
        sData(5) = CStr(Param.sPulse.Width)
        sData(6) = CStr(Param.sPulse.Period)
        sData(7) = CStr(Param.sLimit.dCurrentLimit)
        sData(8) = CStr(Param.sLimit.dTempLimit)
        sData(9) = CStr(Param.sLimit.nAverCount)

        'listindex = m_Param.eSignalName
        ucDispDataGrid.AddRowData(sData)  'm_traData.nLenSignal - 1

    End Sub

 


    Public Sub EditValue(ByVal bufdata() As Object)
        ucDispDataGrid.GetRowData(ucDispDataGrid.SelectedRowNum, bufdata)

        Try
            If cboControlLine.Items.Contains(bufdata(0)) = True Then            'cboControlLine.item에 Edit한 Data의 유무 판단
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSignal = cboControlLine.SelectedIndex ' cboControlLine.Items.IndexOf(bufdata(0))     '있으면 변경
                If g_ConfigInfos.SGOutputInfo.strSignalName Is Nothing = False Then
                    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sSignalName = g_ConfigInfos.SGOutputInfo.strSignalName(cboControlLine.SelectedIndex)
                Else
                    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sSignalName = m_sDefCaptionOfPGSignals(cboControlLine.SelectedIndex)
                End If
            Else
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(0).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSignal.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSignal = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSignal  '없으면 기존 데이터 사용
            End If

            If bufdata(1) = CDevSG.eDacMode.eDCMode.ToString Then              'ControlLine과 같은 방법
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSrcMode = CDevSG.eDacMode.eDCMode
            ElseIf bufdata(1) = CDevSG.eDacMode.ePulseMode.ToString Then
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSrcMode = CDevSG.eDacMode.ePulseMode
            Else
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(1).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSrcMode.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSrcMode = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).eSrcMode
            End If
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias = CDbl(bufdata(2))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(2).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude = CDbl(bufdata(3))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(3).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude
            End Try

            'Try
            '    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude = CDbl(bufdata(2))
            'Catch ex As Exception
            '    ucDispDataGrid.DataGridView1.Rows(ucDispDataGrid.SelectedRowNum).Cells(2).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude.ToString
            '    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dAmplitude
            'End Try
            'Try
            '    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias = CDbl(bufdata(3))
            'Catch ex As Exception
            '    ucDispDataGrid.DataGridView1.Rows(ucDispDataGrid.SelectedRowNum).Cells(3).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias.ToString
            '    m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias
            'End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Delay = CDbl(bufdata(4))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(4).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Delay.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Delay = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Delay
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Width = CDbl(bufdata(5))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(5).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Width.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Width = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Width
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Period = CDbl(bufdata(6))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(6).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Period.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Period = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sPulse.Period
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dCurrentLimit = CDbl(bufdata(7))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(7).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dCurrentLimit.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dCurrentLimit = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dCurrentLimit
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dTempLimit = CDbl(bufdata(8))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(8).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dTempLimit.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dTempLimit = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.dTempLimit
            End Try
            Try
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.nAverCount = CDbl(bufdata(9))
            Catch ex As Exception
                ucDispDataGrid.DataGridView.Rows(ucDispDataGrid.SelectedRowNum).Cells(9).Value = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.nAverCount.ToString
                m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.nAverCount = m_traData.sParamData(ucDispDataGrid.SelectedRowNum).sLimit.nAverCount
            End Try

            ModifyData(m_traData.sParamData(ucDispDataGrid.SelectedRowNum))
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ShowValueToUI(ByVal bufdata As sSGParam)
        cboControlLine.SelectedIndex = bufdata.eSignal
        If bufdata.eSrcMode = cDevSG.eDacMode.eDCMode Then
            rdoCV.Checked = True
        Else
            rdoPV.Checked = True
        End If
        tbBias.Text = bufdata.dBias
        tbAmplitude.Text = bufdata.dAmplitude
        txtdelay.Text = bufdata.sPulse.Delay
        txtwidth.Text = bufdata.sPulse.Width
        txtperiod.Text = bufdata.sPulse.Period
        tbAverage.Text = bufdata.sLimit.nAverCount


        If bufdata.eSignal = ePGSignal.MainPower2 Or bufdata.eSignal = ePGSignal.MainPower1 Then
            tbCurrentLimit.Text = bufdata.sLimit.dCurrentLimit
            tbTempLimit.Text = bufdata.sLimit.dTempLimit
        End If

    End Sub

    Public Function GetValueFromUI(ByRef param As sSGParam) As Boolean

        With param
            .eSignal = cboControlLine.SelectedIndex
            If g_ConfigInfos.SGOutputInfo.strSignalName Is Nothing = False Then
                .sSignalName = g_ConfigInfos.SGOutputInfo.strSignalName(.eSignal)
            Else
                .sSignalName = m_sDefCaptionOfPGSignals(.eSignal)
            End If

            If .eSignal = ePGSignal.MainPower1 Or .eSignal = ePGSignal.MainPower2 Then
                Try
                    .sLimit.dCurrentLimit = tbCurrentLimit.Text
                    .sLimit.dTempLimit = tbTempLimit.Text
                Catch ex As Exception
                    MsgBox("Limit Value Setting Error")
                    Return False
                End Try
            Else
                .sLimit.dCurrentLimit = 0
                .sLimit.dTempLimit = 0
            End If

            If rdoCV.Checked = True Then
                .eSrcMode = CDevSG.eDacMode.eDCMode
            Else
                .eSrcMode = CDevSG.eDacMode.ePulseMode
            End If

            Try
                .dBias = tbBias.Text
                .sLimit.nAverCount = tbAverage.Text
            Catch ex As Exception
                MsgBox("Bias or Average Count Setting Error")
                Return False
            End Try

            Try
                If .eSrcMode = CDevSG.eDacMode.eDCMode Then
                    .dAmplitude = 0
                    .sPulse.Delay = 0
                    .sPulse.Width = 0
                    .sPulse.Period = 0
                Else
                    .dAmplitude = tbAmplitude.Text
                    .sPulse.Delay = txtdelay.Text
                    .sPulse.Width = txtwidth.Text
                    .sPulse.Period = txtperiod.Text
                End If
            Catch ex As Exception
                .dBias = 0
                .sPulse.Delay = 0
                .sPulse.Width = 0
                .sPulse.Period = 0
                Return False
            End Try
        End With
        Return True
    End Function

    Public Sub SetValuetoGridView()
        For i As Integer = 0 To m_traData.sParamData.Length - 1
            For j As Integer = 0 To 9
                ucDispDataGrid.DataGridView.Rows(i).Cells(0).Value = m_traData.sParamData(i).eSignal.ToString
                ucDispDataGrid.DataGridView.Rows(i).Cells(1).Value = m_traData.sParamData(i).eSrcMode.ToString
                ucDispDataGrid.DataGridView.Rows(i).Cells(2).Value = CStr(m_traData.sParamData(i).dAmplitude)
                ucDispDataGrid.DataGridView.Rows(i).Cells(3).Value = CStr(m_traData.sParamData(i).dBias)
                ucDispDataGrid.DataGridView.Rows(i).Cells(4).Value = CStr(m_traData.sParamData(i).sPulse.Delay)
                ucDispDataGrid.DataGridView.Rows(i).Cells(5).Value = CStr(m_traData.sParamData(i).sPulse.Width)
                ucDispDataGrid.DataGridView.Rows(i).Cells(6).Value = CStr(m_traData.sParamData(i).sPulse.Period)
                ucDispDataGrid.DataGridView.Rows(i).Cells(7).Value = CStr(m_traData.sParamData(i).sLimit.dCurrentLimit)
                ucDispDataGrid.DataGridView.Rows(i).Cells(8).Value = CStr(m_traData.sParamData(i).sLimit.dTempLimit)
                ucDispDataGrid.DataGridView.Rows(i).Cells(9).Value = CStr(m_traData.sParamData(i).sLimit.nAverCount)
            Next
        Next
    End Sub

    Private Sub rdoCV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCV.CheckedChanged, rdoPV.CheckedChanged
        If rdoCV.Checked = True Then
            tbAmplitude.Text = Nothing
            tbAmplitude.Enabled = False
            txtdelay.Text = Nothing
            txtdelay.Enabled = False
            txtwidth.Text = Nothing
            txtwidth.Enabled = False
            txtperiod.Text = Nothing
            txtperiod.Enabled = False
        Else
            tbAmplitude.Enabled = True
            txtdelay.Enabled = True
            txtwidth.Enabled = True
            txtperiod.Enabled = True
        End If
    End Sub

    Private Sub UcDataGridView1_evEditData() Handles ucDispDataGrid.evEditData
        Dim BufData() As Object = Nothing

        If m_traData.sParamData Is Nothing Then
            Exit Sub
        End If
        EditValue(BufData)
    End Sub

    Private Sub UcDataGridView1_evShowUI() Handles ucDispDataGrid.evShowUI
        If m_traData.sParamData Is Nothing Then
            Exit Sub
        Else
            If m_traData.nLenSignal > ucDispDataGrid.SelectedRowNum Then
                ShowValueToUI(m_traData.sParamData(ucDispDataGrid.SelectedRowNum))
            End If
        End If

    End Sub

    Public Function SaveConfiguration(ByVal configInfos As sSGDatas) As Boolean

        Dim sFileTitle As String = "Signal Generator"

        Dim cFile As New CMcFile
        Dim FilePath As CMcFile.sFILENAME = Nothing
        If cFile.GetSaveFileName(CMcFile.eFileType._SGI, FilePath) = False Then
            Return False
        End If

        'If Directory.Exists(g_sPATH_SYSINI) = False Then
        '    Directory.CreateDirectory(g_sPATH_SYSINI)
        'End If

        Dim configSaver As New cls_INI(FilePath.strPathAndFName)

        Try
            configSaver.IniWriteValue("Signal Generator Setting Info", "Title", sFileTitle)
            configSaver.IniWriteValue("Info", "Number of RegData", m_traData.sParamData.Length)
            configSaver.IniWriteValue("Info", "Comments", txtComments.Text)
            configSaver.IniWriteValue("Info", "Average PD Measure Conunt", txtPDAverage.Text)

            With configInfos
                For i As Integer = 0 To m_traData.sParamData.Length - 1
                    configSaver.IniWriteValue("Reg " & i, "ControlLine", configInfos.sParamData(i).eSignal.ToString)
                    configSaver.IniWriteValue("Reg " & i, "SignalName", configInfos.sParamData(i).sSignalName)
                    configSaver.IniWriteValue("Reg " & i, "Mode", configInfos.sParamData(i).eSrcMode.ToString)
                    configSaver.IniWriteValue("Reg " & i, "VHigh", configInfos.sParamData(i).dAmplitude)
                    configSaver.IniWriteValue("Reg " & i, "VLow", configInfos.sParamData(i).dBias)
                    configSaver.IniWriteValue("Reg " & i, "Delay", configInfos.sParamData(i).sPulse.Delay)
                    configSaver.IniWriteValue("Reg " & i, "Width", configInfos.sParamData(i).sPulse.Width)
                    configSaver.IniWriteValue("Reg " & i, "Period", configInfos.sParamData(i).sPulse.Period)
                    configSaver.IniWriteValue("Reg " & i, "Current Limit", configInfos.sParamData(i).sLimit.dCurrentLimit)
                    configSaver.IniWriteValue("Reg " & i, "Temp Limit", configInfos.sParamData(i).sLimit.dTempLimit)
                    configSaver.IniWriteValue("Reg " & i, "Average", configInfos.sParamData(i).sLimit.nAverCount)
                Next

            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function LoadConfiguration() As Boolean

        Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        If file.GetLoadFileName(CMcFile.eFileType._SGI, fileInfo) = False Then Return False
        'If LoadSequence(fileInfo.strPathAndFName) = False Then Return False


        'If File.Exists(g_sPATH_SYSINI & g_SysConfig_FileName) = False Then
        '    MsgBox("Load할 파일이 없습니다.")
        'Else
        'End If

        Dim BufData() As sSGParam = Nothing
        Dim TempData As String
        Dim configLoader As New cls_INI(fileInfo.strPathAndFName) 'g_sPATH_SYSINI & g_SysConfig_FileName
        Dim numOfData As Integer

        Try

            numOfData = configLoader.IniReadValue("Info", "Number of RegData")
            txtComments.Text = configLoader.IniReadValue("Info", "Comments")
            txtPDAverage.Text = configLoader.IniReadValue("Info", "Average PD Measure Conunt")

            ReDim BufData(numOfData - 1)
            For i As Integer = 0 To numOfData - 1
                TempData = configLoader.IniReadValue("Reg " & i, "ControlLine")
                BufData(i).eSignal = ConvertStringToPGSignal(TempData)
                Try
                    BufData(i).sSignalName = configLoader.IniReadValue("Reg " & i, "SignalName")
                Catch ex As Exception
                    BufData(i).sSignalName = ""
                End Try
                TempData = configLoader.IniReadValue("Reg " & i, "Mode")
                If TempData = CDevSG.eDacMode.eDCMode.ToString Then
                    BufData(i).eSrcMode = CDevSG.eDacMode.eDCMode
                ElseIf TempData = CDevSG.eDacMode.ePulseMode.ToString Then
                    BufData(i).eSrcMode = CDevSG.eDacMode.ePulseMode
                Else
                    Return False
                End If
                BufData(i).dAmplitude = configLoader.IniReadValue("Reg " & i, "VHigh")
                BufData(i).dBias = configLoader.IniReadValue("Reg " & i, "VLow")
                BufData(i).sPulse.Delay = configLoader.IniReadValue("Reg " & i, "Delay")
                BufData(i).sPulse.Width = configLoader.IniReadValue("Reg " & i, "Width")
                BufData(i).sPulse.Period = configLoader.IniReadValue("Reg " & i, "Period")
                BufData(i).sLimit.dCurrentLimit = configLoader.IniReadValue("Reg " & i, "Current Limit")
                BufData(i).sLimit.dTempLimit = configLoader.IniReadValue("Reg " & i, "Temp Limit")
                BufData(i).sLimit.nAverCount = configLoader.IniReadValue("Reg " & i, "Average")
            Next

            m_traData.sParamData = BufData.Clone
            m_traData.nLenSignal = BufData.Length
            m_traData.nPDAvgCount = txtPDAverage.Text
            nCntSignal = BufData.Length
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim param As sSGParam = Nothing
        GetValueFromUI(param)
        AddData(param)
    End Sub

    Public Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If SaveConfiguration(m_traData) = True Then


        Else
            MsgBox("저장이 잘못되었습니다.")
        End If
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim BufData() As sSGParam = Nothing

        LoadConfiguration()
        UpdateList()

        'SetValuetoGridView()

        'Datas = m_traData
        ucDispDataGrid.ReAdjustRow()
    End Sub

    Private Sub cboControlLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboControlLine.SelectedIndexChanged

        If cboControlLine.SelectedIndex = 0 Or cboControlLine.SelectedIndex = 1 Then
            tbCurrentLimit.Enabled = True
            tbTempLimit.Enabled = True
        Else
            tbCurrentLimit.Enabled = False
            tbTempLimit.Enabled = False
        End If
        If cboControlLine.SelectedIndex > 13 And cboControlLine.SelectedIndex < 40 Then
            rdoCV.Checked = False
            rdoCV.Enabled = False
        Else
            rdoCV.Enabled = True
        End If
    End Sub


    Public Shared Function ConvertStringToPGSignal(ByVal str As String) As ePGSignal
        Select Case str
            Case ePGSignal.MainPower1.ToString
                Return ePGSignal.MainPower1
            Case ePGSignal.MainPower2.ToString
                Return ePGSignal.MainPower2
            Case ePGSignal.SubPower1.ToString
                Return ePGSignal.SubPower1
            Case ePGSignal.SubPower2.ToString
                Return ePGSignal.SubPower2
            Case ePGSignal.SubPower3.ToString
                Return ePGSignal.SubPower3
            Case ePGSignal.SubPower4.ToString
                Return ePGSignal.SubPower4
            Case ePGSignal.SubPower5.ToString
                Return ePGSignal.SubPower5
            Case ePGSignal.SubPower6.ToString
                Return ePGSignal.SubPower6
            Case ePGSignal.SubPower7.ToString
                Return ePGSignal.SubPower7
            Case ePGSignal.SubPower8.ToString
                Return ePGSignal.SubPower8
            Case ePGSignal.SubPower9.ToString
                Return ePGSignal.SubPower9
            Case ePGSignal.SubPower10.ToString
                Return ePGSignal.SubPower10
            Case ePGSignal.SubPower11.ToString
                Return ePGSignal.SubPower11
            Case ePGSignal.SubPower12.ToString
                Return ePGSignal.SubPower12
            Case ePGSignal.Signal1.ToString
                Return ePGSignal.Signal1
            Case ePGSignal.Signal2.ToString
                Return ePGSignal.Signal2
            Case ePGSignal.Signal3.ToString
                Return ePGSignal.Signal3
            Case ePGSignal.Signal4.ToString
                Return ePGSignal.Signal4
            Case ePGSignal.Signal5.ToString
                Return ePGSignal.Signal5
            Case ePGSignal.Signal6.ToString
                Return ePGSignal.Signal6
            Case ePGSignal.Signal7.ToString
                Return ePGSignal.Signal7
            Case ePGSignal.Signal8.ToString
                Return ePGSignal.Signal8
            Case ePGSignal.Signal9.ToString
                Return ePGSignal.Signal9
            Case ePGSignal.Signal10.ToString
                Return ePGSignal.Signal10
            Case ePGSignal.Signal11.ToString
                Return ePGSignal.Signal11
            Case ePGSignal.Signal12.ToString
                Return ePGSignal.Signal12
            Case ePGSignal.Signal13.ToString
                Return ePGSignal.Signal13
            Case ePGSignal.Signal14.ToString
                Return ePGSignal.Signal14
            Case ePGSignal.Signal15.ToString
                Return ePGSignal.Signal15
            Case ePGSignal.Signal16.ToString
                Return ePGSignal.Signal16
            Case ePGSignal.Signal17.ToString
                Return ePGSignal.Signal17
            Case ePGSignal.Signal18.ToString
                Return ePGSignal.Signal18
            Case ePGSignal.Signal19.ToString
                Return ePGSignal.Signal19
            Case ePGSignal.Signal20.ToString
                Return ePGSignal.Signal20
            Case ePGSignal.Signal21.ToString
                Return ePGSignal.Signal21
            Case ePGSignal.Signal22.ToString
                Return ePGSignal.Signal22
            Case ePGSignal.Signal23.ToString
                Return ePGSignal.Signal23
            Case ePGSignal.Signal24.ToString
                Return ePGSignal.Signal24
            Case ePGSignal.Signal25.ToString
                Return ePGSignal.Signal25
            Case ePGSignal.Signal26.ToString
                Return ePGSignal.Signal26
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertStringToPGDACMode(ByVal str As String) As cDevSG.eDacMode
        Select Case str
            Case cDevSG.eDacMode.eDCMode.ToString
                Return cDevSG.eDacMode.eDCMode
            Case Else
                Return cDevSG.eDacMode.ePulseMode
        End Select

    End Function

    Private Sub DelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem.Click
        Dim nSelRow As Integer = ucDispDataGrid.SelectedRowNum
        DelData(nSelRow)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ClearData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim nSelRow As Integer = ucDispDataGrid.SelectedRowNum
        DelData(nSelRow)
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim param As sSGParam = Nothing
        If GetValueFromUI(param) = False Then Exit Sub
        ModifyData(param)
    End Sub
    Public Sub ModifyData(ByVal bufData As sSGParam)
        Dim nSelRow As Integer = ucDispDataGrid.SelectedRowNum
        m_traData.sParamData(nSelRow) = bufData
        ModifyList(m_traData.sParamData(nSelRow))
    End Sub
    Public Sub ModifyList(ByVal Param As sSGParam)    '
        Dim sData(9) As String
        '  Dim listindex As Integer

        sData(0) = Param.sSignalName '.ToString
        sData(1) = Param.eSrcMode.ToString


        If g_SystemOptions.sOptionData.ParamRange.sAMX.Low.dMainPower > Param.dBias Or g_SystemOptions.sOptionData.ParamRange.sAMX.High.dMainPower < Param.dBias Then
            m_traData.sParamData(ucDispDataGrid.SelectedRowNum).dBias = 0
            Param.dBias = 0
            lbl_Bias.BackColor = Color.Red
        Else
            lbl_Bias.BackColor = Color.Transparent
        End If


        sData(2) = CStr(Param.dBias)
        sData(3) = CStr(Param.dAmplitude)
        sData(4) = CStr(Param.sPulse.Delay)
        sData(5) = CStr(Param.sPulse.Width)
        sData(6) = CStr(Param.sPulse.Period)
        sData(7) = CStr(Param.sLimit.dCurrentLimit)
        sData(8) = CStr(Param.sLimit.dTempLimit)
        sData(9) = CStr(Param.sLimit.nAverCount)

        'listindex = m_Param.eSignalName
        ucDispDataGrid.AddModifyData(sData)  'm_traData.nLenSignal - 1

    End Sub
    Private Sub tbBias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBias.TextChanged
        Dim TempText() As String = Split(tbBias.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbBias.Text)

            If g_SystemOptions.sOptionData.ParamRange.sAMX.Low.dMainPower > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sAMX.High.dMainPower < dValue Then
                tbBias.Text = 0
                lbl_Bias.BackColor = Color.Red
            Else
                lbl_Bias.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbBias.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub


    Private Sub tbAmplitude_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAmplitude.TextChanged
        Dim TempText() As String = Split(tbAmplitude.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            dValue = CDbl(tbAmplitude.Text)

            If g_SystemOptions.sOptionData.ParamRange.sAMX.Low.dMainPower > dValue Or _
                g_SystemOptions.sOptionData.ParamRange.sAMX.High.dMainPower < dValue Then
                tbAmplitude.Text = 0
                lbl_Amplitude.BackColor = Color.Red
            Else
                lbl_Amplitude.BackColor = Color.Transparent
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        If tbAmplitude.Text <> "" Then
            ' RaiseEvent evELVDDChange(dValue)
        End If
    End Sub

End Class
