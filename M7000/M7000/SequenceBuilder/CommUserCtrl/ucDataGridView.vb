Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading

Public Class ucDataGridView



  

#Region "Define"

    Dim sColumns() As String
    Dim m_CellColor() As Color
    Dim m_SortMode As DataGridViewColumnSortMode
    Dim m_SelectionMode As DataGridViewSelectionMode
    Dim m_ContentAlign As DataGridViewContentAlignment
    Dim m_bEnableEvent As Boolean = True

    Public m_Font As Font = New Font("궁서", 10)
    Public a() As String = {"A", "B", "C"}
    Dim dRowWidth As Integer
    Dim dColHeaderWidth() As Double = New Double() {20, 20, 20, 20, 20}
    Dim dRowHeaderWidth() As Double = New Double() {30, 30, 30, 30, 30}
    Public m_SelectedRowNum As Integer
    Public m_selectedCoulumNum As Integer
    Public m_SelectedComboItemNum As Integer
    Public m_SelectedCheckBoxState As Boolean
    Dim D_DataSave(,) As String = Nothing
    Public Event evCompoboxSelectedIndexChanged(ByVal selectedItemIdx As Integer, ByVal nRaw As Integer, ByVal nCol As Integer)
    Public Event evShowUI()
    Public Event evCellLineInfo(ByVal SelectColumnNum As Integer, ByVal SelectedRowNum As Integer)
    Public Event evEditData()
    Public Event evMeasPointEdit(ByVal MeasPoint As ucDispPointSetting.sMeasurePointInfos, ByVal SelectedRowNum As Integer)


    Public Enum eUcListErrCode
        eNoError
        eMisMatched_ColumnAndRowDataLen
        eNothingData
        eUnDefineError
        eNothingDataInSelectedColumn
        eNothingDataInSelectedRow
    End Enum

    Public Enum eContollerType
        eTextBox
        eComboBox
        eCheckBox
        eButton
        eLink
        eImage
    End Enum


#End Region

#Region "Property"

    Public Property EnableEvent As Boolean
        Get
            Return m_bEnableEvent
        End Get
        Set(ByVal value As Boolean)
            m_bEnableEvent = value
        End Set
    End Property

    Public ReadOnly Property SelectedRowNum As Integer
        Get
            Return m_SelectedRowNum
        End Get
    End Property


    Public ReadOnly Property SelectedColumnNum As Integer
        Get
            Return m_selectedCoulumNum
        End Get
    End Property

    Public ReadOnly Property SelectedComboBoxItemNum As Integer
        Get
            Return m_SelectedComboItemNum
        End Get
    End Property

    Public ReadOnly Property SelectedCheckBoxState As Boolean
        Get
            Return m_SelectedCheckBoxState
        End Get
    End Property

    Public Property IsSelected(ByVal Ch As Integer) As Boolean
        Get
            If DataGridView.Rows(Ch).Cells(0).OwningColumn.CellType.Name = "DataGridViewCheckBoxCell" Then

                Dim CheckCell As DataGridViewCheckBoxCell = CType(DataGridView.Rows(Ch).Cells(0), DataGridViewCheckBoxCell)

                m_SelectedCheckBoxState = CheckCell.Value
            End If

            Return m_SelectedCheckBoxState
        End Get
        Set(ByVal value As Boolean)

            If DataGridView.Rows(Ch).Cells(0).OwningColumn.CellType.Name = "DataGridViewCheckBoxCell" Then

                Dim CheckCell As DataGridViewCheckBoxCell = CType(DataGridView.Rows(Ch).Cells(0), DataGridViewCheckBoxCell)

                CheckCell.Value = value

            End If

        End Set
    End Property

    Public Property ColumnSortMode As DataGridViewColumnSortMode
        Get
            Return m_SortMode
        End Get
        Set(ByVal value As DataGridViewColumnSortMode)
            m_SortMode = value
        End Set
    End Property

    Public Property ContentAlign As DataGridViewContentAlignment
        Get
            Return m_ContentAlign
        End Get
        Set(ByVal value As DataGridViewContentAlignment)
            m_ContentAlign = value
        End Set
    End Property

    Public Property ColumnSelectionMode As DataGridViewSelectionMode
        Get
            Return m_SelectionMode
        End Get
        Set(ByVal value As DataGridViewSelectionMode)
            m_SelectionMode = value
        End Set
    End Property

    Public Property RowLineNum As Integer 'Row(렬) 선언
        Get
            Return DataGridView.Rows.Count
        End Get
        Set(ByVal value As Integer)

            If value = 0 Then
                DataGridView.Rows.Clear()

            ElseIf value > 1 Then

                DataGridView.Rows.Clear()

                For i As Integer = 0 To (value - 1)
                    DataGridView.Rows.Add()
                Next

            End If

        End Set
    End Property



    Public Property CellColor As Color()
        Get
            Return m_CellColor
        End Get
        Set(ByVal value As Color())
            m_CellColor = value
        End Set
    End Property

    Public Property WrapMode As DataGridViewTriState

        Get
            Return DataGridView.DefaultCellStyle.WrapMode
        End Get
        Set(ByVal value As DataGridViewTriState)
            DataGridView.DefaultCellStyle.WrapMode = value
        End Set
    End Property


    Public Property RowHeaderVisible As Boolean
        Get
            Return DataGridView.RowHeadersVisible
        End Get
        Set(ByVal value As Boolean)
            DataGridView.RowHeadersVisible = value
        End Set
    End Property

    Public Property RowHeaderSize As Integer 'Row의 Header Width 설정 하는 부분.
        Get

            Return DataGridView.RowHeadersWidth

        End Get
        Set(ByVal value As Integer)

            DataGridView.RowHeadersWidth = value
        End Set
    End Property

    Public Property AutoSizeCoulumsMode() As DataGridViewAutoSizeColumnMode
        Get
            Return DataGridView.AutoSizeColumnsMode
        End Get
        Set(ByVal value As DataGridViewAutoSizeColumnMode)
            DataGridView.AutoSizeColumnsMode = value
        End Set
    End Property

    Public Property zContollerType() As eContollerType()
        Get

            Dim ControlType(DataGridView.Columns.Count - 1) As eContollerType
            For i As Integer = 0 To DataGridView.Columns.Count - 1

                Select Case DataGridView.Columns(i).CellType.Name
                    Case "DataGridViewTextBoxCell"
                        ControlType(i) = eContollerType.eTextBox
                    Case "DataGridViewComboBoxCell"
                        ControlType(i) = eContollerType.eComboBox
                    Case "DataGridViewCheckBoxCell"
                        ControlType(i) = eContollerType.eCheckBox
                    Case "DataGridViewButtonCell"
                        ControlType(i) = eContollerType.eButton
                    Case "DataGridViewLinkCell"
                        ControlType(i) = eContollerType.eLink
                    Case "DataGridViewImageCell"
                        ControlType(i) = eContollerType.eImage
                End Select
            Next

            Return ControlType

        End Get
        Set(ByVal value As eContollerType())

            If value Is Nothing = False Then

                Dim RowNum As Integer = DataGridView.Rows.Count
                Dim HeadTextBuff(DataGridView.Columns.Count - 1) As String

                For i As Integer = 0 To DataGridView.Columns.Count - 1
                    HeadTextBuff(i) = DataGridView.Columns(i).HeaderText
                Next

                DataGridView.Columns.Clear()
                For i As Integer = 0 To value.Length - 1
                    Select Case value(i)
                        Case eContollerType.eTextBox
                            Dim Column As New DataGridViewTextBoxColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                            Column.SortMode = m_SortMode        'TextBoxColumn은 SortMode가 자동적으로 AutoMatic. ColumnSelectionMode로 설정하기 위해선 NotSortable로 설정해줘야함. 
                        Case eContollerType.eComboBox
                            Dim Column As New DataGridViewComboBoxColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                            Column.FlatStyle = FlatStyle.Flat

                        Case (eContollerType.eCheckBox)
                            Dim Column As New DataGridViewCheckBoxColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                        Case eContollerType.eButton
                            Dim Column As New DataGridViewButtonColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                        Case eContollerType.eLink
                            Dim Column As New DataGridViewLinkColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                        Case eContollerType.eImage
                            Dim Column As New DataGridViewImageColumn
                            Column.HeaderText = HeadTextBuff(i).ToString
                            DataGridView.Columns.Add(Column)
                    End Select
                Next

                If RowNum = 0 Then
                Else
                    DataGridView.Rows.Add(RowNum)
                End If



                ReadjustColumnWidth()
                'For i As Integer = 0 To DataGridView1.Columns.Count - 1
                '    DataGridView1.Columns(i).Width = dColHeaderWidth(i)
                'Next
            End If
        End Set

    End Property


    Public Property ControllerHeaderText() As String()

        Get
            If DataGridView.Columns Is Nothing = True Then
                Return Nothing
            End If
            Dim HeaderTextbuff(DataGridView.Columns.Count - 1) As String

            For i As Integer = 0 To DataGridView.Columns.Count - 1
                HeaderTextbuff(i) = DataGridView.Columns(i).HeaderText
            Next

            Return HeaderTextbuff

        End Get

        Set(ByVal value As String())

            If value Is Nothing = False Then
                CreatInit(value.Length, RowLineNum)
                For i As Integer = 0 To value.Length - 1
                    DataGridView.Columns(i).HeaderText = value(i).ToString
                    Dim cellStyle As New System.Windows.Forms.DataGridViewCellStyle
                    cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                    DataGridView.Columns(i).HeaderCell.Style = New System.Windows.Forms.DataGridViewCellStyle(cellStyle)
                Next
            End If

        End Set
    End Property

    Public Property ColHeaderWidthRatio() As String

        Get
            Dim sBuf As String = Nothing

            For i As Integer = 0 To dColHeaderWidth.Length - 1
                sBuf = sBuf & dColHeaderWidth(i) & ","
            Next
            sBuf = sBuf.TrimEnd(",")
            Return sBuf
        End Get
        Set(ByVal Value As String)
            Dim arrBuf As Array

            arrBuf = Split(Value, ",", -1)

            If arrBuf Is Nothing Then
                MsgBox("값이 없습니다.")
                Exit Property
            End If

            Try
                ReDim dColHeaderWidth(arrBuf.Length - 1)
                For i As Integer = 0 To arrBuf.Length - 1
                    dColHeaderWidth(i) = CDbl(arrBuf(i))
                Next
                ReadjustColumnWidth()
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public ReadOnly Property RowCount As Integer
        Get
            Return DataGridView.RowCount
        End Get
    End Property

#End Region

    '  Public fDataGrid As frmDataGridWind

    ' Public frmmain As Form1
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        ' CreatInit(3, 1)
        init()




    End Sub

    Private Sub init()
        With DataGridView
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End With

        DataGridView.MultiSelect = False
        DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect 'DataGridViewSelectionMode.FullRowSelect 'DataGridViewSelectionMode.CellSelect
        DataGridView.Dock = DockStyle.Fill
    End Sub

    Private Sub CreatInit(ByVal numOfColumn As Integer, ByVal RowNumber As Integer)
        'DataGridView 생성
        With DataGridView
            .Rows.Clear()
            .ColumnCount = numOfColumn '행 생성
            If numOfColumn > 0 And RowNumber > 0 Then
                .Rows.Add(RowNumber) '열 생성
            End If

            .TabIndex = 0 ' 시작 번지 0 
            .Dock = DockStyle.Fill
        End With
    End Sub

#Region "Function"

    Public Sub AddRow()
        DataGridView.Rows.Add()
    End Sub

    Public Sub DelLastRow()
        DataGridView.Rows.RemoveAt(DataGridView.Rows.Count - 1)
    End Sub

    Public Sub ReAdjustRow()            'RowHeader 번호 출력

        Dim nRowNum As Integer = DataGridView.Rows.Count

        For i As Integer = 0 To nRowNum - 1
            DataGridView.Rows(i).HeaderCell.Value = CStr(i + 1)
        Next
    End Sub

    Public Sub ReAdjustColumn()         'ColumnHeader 번호 출력

        Dim nColumnNum As Integer = DataGridView.Columns.Count

        For i As Integer = 0 To nColumnNum - 1
            DataGridView.Columns(i).HeaderText = CStr(i + 1)
        Next
    End Sub


    Private Sub ReadjustColumnWidth()

        Dim DataGridViewWidth As Double = DataGridView.Size.Width - DataGridView.RowHeadersWidth

        For i As Integer = 0 To DataGridView.Columns.Count - 1
            DataGridView.Columns(i).Width = (DataGridViewWidth / 100) * dColHeaderWidth(i)
        Next

    End Sub


    Public Function AddComboItems(ByVal sData() As String, ByVal defItemIdx As Integer) As eUcListErrCode

        Dim ComboBox As DataGridViewComboBoxCell
        'Dim TextBox As DataGridViewTextBoxCell


        Try
            For i As Integer = 0 To RowLineNum - 1
                For j As Integer = 0 To DataGridView.Columns.Count - 1
                    If Object.Equals("DataGridViewTextBoxCell", DataGridView.Columns(j).CellType.Name) Then
                        '   TextBox = DataGridView1.Rows(i).Cells(j)


                    ElseIf Object.Equals("DataGridViewComboBoxCell", DataGridView.Columns(j).CellType.Name) Then

                        'DataGridView1.Rows(i).Cells(j). = False
                        ComboBox = DataGridView.Rows(i).Cells(j)
                        ComboBox.Items.Clear()

                        If ComboBox.Items.Count <> 0 Then
                        Else

                            For k As Integer = 0 To sData.Length - 1
                                ComboBox.Items.AddRange(sData(k))


                            Next
                            ComboBox.Value = ComboBox.Items(defItemIdx).ToString
                            ''  

                        End If
                        '  DataGridView1.Rows(i).Cells(j).Value = DataGridView1.Rows(i).Cells(j).Value


                    End If
                Next
            Next

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function


#End Region


#Region "Function Overloading : AddRowData"
    Public Function AddModifyData(ByVal sData() As String) As eUcListErrCode           'String데이터 AddRow 함수


        For cnt As Integer = 0 To sData.Length - 1
            DataGridView.Rows.Item(m_SelectedRowNum).Cells(cnt).Value = sData(cnt)
        Next

        Try
            For i As Integer = 0 To sData.Length - 1
                If DataGridViewTextBoxCell.Equals("DataGridViewTextBoxCell", DataGridView.Columns(i).CellType.Name) Then

                Else
                    DataGridView.Rows.Item(RowLineNum - 1).Cells(i).Value = Nothing
                End If
            Next
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try
        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData() As String) As eUcListErrCode           'String데이터 AddRow 함수

        DataGridView.Rows.Add(sData)

        Try
            For i As Integer = 0 To sData.Length - 1
                If DataGridViewTextBoxCell.Equals("DataGridViewTextBoxCell", DataGridView.Columns(i).CellType.Name) Then

                Else
                    DataGridView.Rows.Item(RowLineNum - 1).Cells(i).Value = Nothing
                End If
            Next
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try
        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData As DataGridViewRow) As eUcListErrCode            'DataGridViewRow AddRow 함수


        Try
            DataGridView.Rows.Add(sData)

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData As DataGridViewCell) As eUcListErrCode            'DataGridViewRow AddRow 함수


        Try
            DataGridView.Rows.Add(sData)

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData() As Double) As eUcListErrCode               'Double데이터 AddRow 함수

        Try
            For i As Integer = 0 To sData.Length - 1
                If DataGridViewTextBoxCell.Equals("DataGridViewTextBoxCell", DataGridView.Columns(i).CellType.Name) Then

                Else
                    DataGridView.Rows.Item(RowLineNum - 1).Cells(i).Value = Nothing
                End If
            Next
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

#End Region

#Region "Function Overloading : AddColumns"
    Public Function AddColumns(ByVal column As DataGridViewCheckBoxColumn) As eUcListErrCode
        ' Dim column As New DataGridViewCheckBoxColumn()
        Try
            DataGridView.Columns.AddRange(column)  '오른쪽 Column 추가
            'DataGridView1.Rows(m_Selecte)dRowNum).Cells(m_selectedCoulumNum + 1) = New DataGridViewCheckBoxCell  '선택 셀 오른쪽 셀 하나 변경
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function

    Public Function AddColumns(ByVal column As DataGridViewButtonColumn) As eUcListErrCode
        ' Dim column As New DataGridViewButtonColumn()
        Try
            DataGridView.Columns.AddRange(column)  '오른쪽 Column 추가
            'DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum + 1) = New DataGridViewButtonCell  '선택 셀 오른쪽 셀 하나 변경
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function

    Public Function AddColumns(ByVal column As DataGridViewTextBoxColumn) As eUcListErrCode
        'DataGridView1.Columns.AddRange(column)   '오른쪽 Column 추가
        ' Dim column As New DataGridViewTextBoxColumn()
        Try
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView.Columns.AddRange(column)  '오른쪽 Column 추가
            'DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum + 1) = New DataGridViewTextBoxCell  '선택 셀 오른쪽 셀 하나 변경
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function


    Public Function AddColumns(ByVal column As DataGridViewComboBoxColumn) As eUcListErrCode
        Dim column1 As New DataGridViewComboBoxCell()
        Try
            DataGridView.Columns.AddRange(column)  '오른쪽 Column 추가
            'DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum + 1) = New DataGridViewComboBoxCell '선택 셀 오른쪽 셀 하나 변경

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function


#End Region


#Region "Functiion Overloading : GetRowData"

    Public Function GetRowData(ByVal nRow As Integer, ByRef sData() As String) As eUcListErrCode            'Row 데이터 Get 함수

        Dim sBufData() As String
        Dim item As DataGridViewRow
        Dim nColumnNum As Integer = DataGridView.Columns.Count

        ReDim sBufData(nColumnNum - 1)

        Try
            For i As Integer = 0 To nColumnNum - 1
                item = DataGridView.Rows.Item(nRow)
                sBufData(i) = item.Cells(i).Value
            Next

            sData = sBufData.Clone
        Catch ex As Exception

        End Try

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetRowData(ByVal nRow As Integer, ByRef sData() As Double) As eUcListErrCode            'Row 데이터 Get 함수

        Dim sBufData() As String
        Dim item As DataGridViewRow
        Dim nColumnNum As Integer = DataGridView.Columns.Count

        ReDim sBufData(nColumnNum - 1)

        Try
            For i As Integer = 0 To nColumnNum - 1
                item = DataGridView.Rows.Item(nRow)
                sBufData(i) = item.Cells(i).Value
            Next

            sData = sBufData.Clone
        Catch ex As Exception
        End Try

        Return eUcListErrCode.eNoError
    End Function

#End Region

#Region "Function Overloading : GetColumnData"
    Public Function GetColumnData(ByVal nRow As Integer, ByRef sData() As String) As eUcListErrCode            'Column 데이터 Get 함수

        Dim sBufData() As String

        ReDim sBufData(RowLineNum - 1)

        Try
            For i As Integer = 0 To RowLineNum - 1
                sBufData(i) = DataGridView.Rows(i).Cells(nRow).Value

            Next

            sData = sBufData.Clone
        Catch ex As Exception

        End Try

        Return eUcListErrCode.eNoError
    End Function
    Public Function GetColumnData(ByVal nRow As Integer, ByRef sData() As Double) As eUcListErrCode            'Column 데이터 Get 함수

        Dim sBufData() As String

        ReDim sBufData(RowLineNum - 1)

        Try
            For i As Integer = 0 To RowLineNum - 1
                sBufData(i) = DataGridView.Rows(i).Cells(nRow).Value
            Next

            sData = sBufData.Clone
        Catch ex As Exception

        End Try

        Return eUcListErrCode.eNoError
    End Function
#End Region


    Public Function SetCellData(ByVal col As Integer, ByVal row As Integer, ByVal sdata As String) As eUcListErrCode
        Try
            DataGridView.Rows(row).Cells(col).Value = sdata
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try
        Return eUcListErrCode.eNoError
    End Function


#Region "Function Overloading : SetColumnData"
    Public Function SetColumnData(ByVal nRow As Integer, ByVal sData() As Double) As eUcListErrCode        'Column 데이터 Set 함수
        Try
            For i As Integer = 0 To RowLineNum - 1
                DataGridView.Rows(i).Cells(nRow).Value = sData(i)
            Next

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

    Public Function SetColumnData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode        'Column 데이터 Set 함수

        Try
            For i As Integer = 0 To RowLineNum - 1
                DataGridView.Rows(i).Cells(nRow).Value = sData(i)
            Next

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function
#End Region

#Region "Function Overloading : SetRowData"

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As Double) As eUcListErrCode        'Row 데이터 Set 함수

        Try
            DataGridView.Rows(nRow).SetValues(sData)

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode        'Row 데이터 Set 함수

        Try
            DataGridView.Rows(nRow).SetValues(sData)

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

#End Region


#Region "Function Overloading : ErrorCheck"
    Private Function ErrorCheck(ByVal sData() As Double) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

    Private Function ErrorCheck(ByVal sData() As Integer) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

    Private Function ErrorCheck(ByVal sData() As String) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If DataGridView.Columns.Count <> sData.Length Then   'No는 빼고, R,G,B 의 레지스터 값 의 수만 비교
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

    Private Function ErrorCheck(ByVal sData() As Object) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then   'No는 빼고, R,G,B 의 레지스터 값 의 수만 비교
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

#End Region


    Public Sub DeleteLastRow() ' 맨 마지막 Row 지워지는 기능
        Dim nrow As DataGridViewRow = Nothing
        'GetSelectedRowNumber(nrow)
        Dim nRowNum As Integer = DataGridView.Rows.Count
        nrow = DataGridView.Rows(nRowNum - 1)
        If nRowNum = 1 Then
            MsgBox("첫번째 줄입니다.")
            Exit Sub
        End If
        If DataGridView.Rows.IndexOf(nrow) = nRowNum Then
            MsgBox("커밋되지 않은 마지막 행입니다.")
            Exit Sub
        End If

        With DataGridView.Rows
            .Remove(nrow)
        End With
        ReAdjustRow()
    End Sub


    Public Sub DeleteSelectedRow(ByVal nrownum As Integer) '선택한 Row 지워지는 기능
        Dim nrow As DataGridViewRow = Nothing
        nrow = DataGridView.Rows(nrownum)

        If DataGridView.Rows.Count = 1 Then
            MsgBox("첫번째 줄입니다.")
            Exit Sub
        End If
        'If DataGridView.Rows.IndexOf(nrow) = DataGridView.Rows.Count - 1 Then
        '    MsgBox("커밋되지 않은 마지막 행입니다.")
        '    Exit Sub
        'End If
        With DataGridView.Rows
            If nrow.Index = 0 Then
                MsgBox("첫번째 줄입니다.")
                Exit Sub
            End If
            .Remove(nrow)
        End With
        'ReAdjustRow()
    End Sub


    Public Sub DeleteSelectedColumn(ByVal nrownum As Integer) '선택한 Column 지워지는 기능
        Dim nrow As DataGridViewColumn = Nothing

        nrow = DataGridView.Columns(nrownum)

        With DataGridView.Columns
            .Remove(nrow)
        End With
    End Sub

    Public Sub ClearRow()
        Dim RowCount As Integer = RowLineNum
        DataGridView.Rows.Clear()

    End Sub

    'Public Function GetSelectedRowNumber(ByRef nRow As DataGridViewRow) '사용 안함
    '    Dim selListItem As Integer
    '    Dim list As DataGridViewSelectedRowCollection

    '    list = DataGridView1.SelectedRows
    '    Try
    '        nRow = list.Item(selListItem)

    '    Catch ex As Exception
    '        Return False
    '    End Try

    '    Return True
    'End Function

    'Public Function GetSelectedRowNumber(ByRef nRow As Integer) '사용 안함
    '    Dim selListItem As Integer
    '    Dim list As DataGridViewSelectedRowCollection

    '    list = DataGridView1.SelectedRows
    '    Try
    '        nRow = list.Item(selListItem).Index

    '    Catch ex As Exception
    '        Return False
    '    End Try

    '    Return True
    'End Function


    'Public Sub List_Up()
    '    Dim data1() As String = Nothing
    '    Dim data2() As String = Nothing
    '    GetRowData(m_SelectedRowNum, data1)
    '    GetRowData(m_SelectedRowNum - 1, data2)
    '    SetRowData(m_SelectedRowNum, data2)
    '    SetRowData(m_SelectedRowNum - 1, data1)
    'End Sub

    'Public Sub List_Down()
    '    Dim data1() As String = Nothing
    '    Dim data2() As String = Nothing
    '    GetRowData(m_SelectedRowNum, data1)
    '    GetRowData(m_SelectedRowNum + 1, data2)
    '    SetRowData(m_SelectedRowNum, data2)
    '    SetRowData(m_SelectedRowNum + 1, data1)
    'End Sub
    Public ComboBox As DataGridViewComboBoxCell

    Public Function LoadData(ByVal sData(,) As Object) As eUcListErrCode

        Try
            For i As Integer = 0 To RowLineNum - 1
                For j As Integer = 0 To DataGridView.Columns.Count - 1

                    If Object.Equals("DataGridViewTextBoxCell", DataGridView.Rows(i).Cells(j).OwningColumn.CellType.Name) Then
                        If sData Is Nothing Then
                            DataGridView.Rows(i).Cells(j).Value = Nothing
                        Else
                            DataGridView.Rows(i).Cells(j).Value = sData(i, j)
                        End If
                    ElseIf Object.Equals("DataGridViewComboBoxCell", DataGridView.Rows(i).Cells(j).OwningColumn.CellType.Name) Then
                        ComboBox = DataGridView.Rows(i).Cells(j)
                        If ComboBox.Items.Count <> 0 Then
                        Else
                            'ComboBox.Items.AddRange(a)  'ComboBox item 설정
                        End If
                        If sData Is Nothing Then
                            DataGridView.Rows(i).Cells(j).Value = Nothing 'Nothing
                        Else
                            DataGridView.Rows(i).Cells(j).Value = sData(i, j)
                        End If
                    Else

                    End If
                Next
            Next
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError
    End Function

    Public Sub DataSet()
        For i As Integer = 0 To RowLineNum - 1
            DataSave(i)
        Next
        LoadData(D_DataSave)
    End Sub


    Public Function DataSave(ByVal nrownum As Integer) As eUcListErrCode   '셀 값 데이터 저장 함수
        Dim ArrayBuff(,) As String = Nothing

        For i As Integer = 0 To RowLineNum - 1
            For j As Integer = 0 To DataGridView.Columns.Count - 1

                ReDim Preserve ArrayBuff(nrownum, j)
                For k As Integer = 0 To nrownum - 1
                    ArrayBuff(k, j) = D_DataSave(k, j)
                Next
                ArrayBuff(nrownum, j) = DataGridView.Rows(nrownum).Cells(j).Value
            Next

        Next
        D_DataSave = ArrayBuff.Clone

        Return eUcListErrCode.eNoError
    End Function



#Region "CellChange Funcion"
    'Public Function CellChange(ByVal ColumnType As DataGridViewColumn) As eUcListErrCode
    '    Dim columns As New DataGridViewTextBoxColumn()
    '    Dim columns1 As New DataGridViewComboBoxColumn()
    '    If DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum).Value = "TextBox" Then
    '        AddColumns(columns)
    '        ColumnType = columns
    '    ElseIf DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum).Value = "ComboBox" Then
    '        AddColumns(columns1)
    '        ColumnType = columns
    '    Else

    '    End If
    '    Return eUcListErrCode.eNoError
    'End Function

#End Region

#Region "InsertRow Function"
    Public Function InsertRow(ByVal sData() As String) As eUcListErrCode    'Row 삽입 함수

        DataGridView.Rows.Insert(m_SelectedRowNum, sData) '선택한 Cell 아래에 1ROW 삽입

        Try
            For i As Integer = 0 To sData.Length - 1
                If Object.Equals("DataGridViewTextBoxCell", DataGridView.Columns(i).CellType.Name) Then

                ElseIf Object.Equals("DataGridViewComboBoxCell", DataGridView.Columns(i).CellType.Name) Then

                End If
            Next
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

    Public Function InsertRow(ByVal sData As DataGridViewRow) As eUcListErrCode     'Row 삽입 함수

        Try
            DataGridView.Rows.Insert(m_SelectedRowNum + 1, 1)  '선택한 Cell 아래에 1ROW 삽입
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function

#End Region

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellClick

        Dim SelectedCell As DataGridViewSelectedCellCollection

        SelectedCell = DataGridView.SelectedCells

        If SelectedCell.Count <= 0 Then
            Exit Sub
        End If

        m_SelectedRowNum = SelectedCell.Item(0).RowIndex ' 현재 선택된 Cell의 RowIndex
        m_selectedCoulumNum = SelectedCell.Item(0).ColumnIndex '현재 선택된 Cell 의 Coulum Index

        If DataGridView.Parent.Name = "ucDispDataGrid" Then

            If m_bEnableEvent = True Then
                RaiseEvent evShowUI()
            End If


        ElseIf DataGridView.Parent.Name = "ucDataGridView" Then
            If m_bEnableEvent = True Then
                RaiseEvent evCellLineInfo(m_selectedCoulumNum, m_SelectedRowNum)
            End If
        End If


        If Equals(DataGridView.Columns(m_selectedCoulumNum).CellType.Name, "DataGridViewButtonCell") Then      '2013-08-09 추가 : ucDispImageSweep에서 DatagridviewButton 클릭시 발생.
            Dim dlg As New frmMeasPointSetting

            If dlg.ShowDialog = DialogResult.OK Then
                If m_bEnableEvent = True Then
                    RaiseEvent evMeasPointEdit(dlg.ucDispPointSetting.Settings, m_SelectedRowNum)
                End If

            End If
        End If


    End Sub





    'Public Sub dataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
    '    If Object.Equals("DataGridViewCheckBoxCell", DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum).OwningColumn.CellType.Name) Then
    '        If DataGridView1.IsCurrentCellDirty Then
    '            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '        End If

    '    Else
    '    End If
    'End Sub

    'Public Sub dataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

    '    If DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum).OwningColumn.CellType.Name = "DataGridViewCheckBoxCell" Then

    '        Dim CheckCell As DataGridViewCheckBoxCell = CType(DataGridView1.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum), DataGridViewCheckBoxCell)
    '        m_SelectedCheckBoxState = CheckCell.Value
    '    Else
    '    End If
    'End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView.DataError
        For j As Integer = 0 To DataGridView.Columns.Count - 1
            If DataGridView.Columns.Item(j).CellType.Name = "DataGridViewTextBoxCell" Then
            Else
                For i As Integer = 0 To RowLineNum - 1
                    DataGridView.Rows(i).Cells(j).Value = Nothing
                Next
            End If
        Next
    End Sub

    Public Event DataGridSelect()

    Public Event DataGridComboSelect()

    Private Sub EditingComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim comboBox As ComboBox = CType(sender, ComboBox)

        Dim cboBoxEditCtrl As System.Windows.Forms.DataGridViewComboBoxEditingControl = comboBox

        Dim col As Integer = m_selectedCoulumNum ' cboBoxEditCtrl.EditingControlRowIndex


        m_SelectedComboItemNum = comboBox.SelectedIndex

        If m_bEnableEvent = True Then
            RaiseEvent evCompoboxSelectedIndexChanged(m_SelectedComboItemNum, m_SelectedRowNum, col)
        End If
    End Sub

    Public Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView.EditingControlShowing

        If Object.Equals("DataGridViewComboBoxCell", DataGridView.Rows(m_SelectedRowNum).Cells(m_selectedCoulumNum).OwningColumn.CellType.Name) Then
            Dim EditingComboBox As ComboBox = CType(e.Control, ComboBox)


            If e.Control Is EditingComboBox Then
                If Not EditingComboBox Is Nothing Then

                    RemoveHandler EditingComboBox.SelectedIndexChanged, AddressOf EditingComboBox_SelectedIndexChanged
                    AddHandler EditingComboBox.SelectedIndexChanged, AddressOf EditingComboBox_SelectedIndexChanged
                End If
            End If
        End If

    End Sub

    Public Sub SelectIndex(ByVal idx As Integer, ByVal Combo As DataGridViewComboBoxCell)

        Combo.Value = Combo.Items(idx).tostring
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView.RowsAdded
        ' AddComboItems(ucSequenceBuilder.GetModeList, 0)
    End Sub



    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellEndEdit
        If DataGridView.Parent.Name = "ucDispDataGrid" Then
            RaiseEvent evEditData()
        ElseIf DataGridView.Parent.Name = "ucSweepImageDataGrid" Then
            RaiseEvent evEditData()
        End If
    End Sub


   

    'Public Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
    '    If e.Button = MouseButtons.Left Then

    '        Dim SelectedCell As DataGridViewSelectedCellCollection
    '        SelectedCell = DataGridView1.SelectedCells
    '        m_SelectedRowNum = SelectedCell.Item(0).RowIndex ' 현재 선택된 Cell의 RowIndex
    '        m_selectedCoulumNum = SelectedCell.Item(0).ColumnIndex '현재 선택된 Cell 의 Coulum Index

    '        If DataGridView1.Parent.Name = "ucDispDataGrid" Then
    '            RaiseEvent evShowUI()
    '        Else
    '        End If

    '        If e.RowIndex < 0 OrElse Not e.ColumnIndex = DataGridView1.Columns("Meas.Point").Index Then Return

    '        MsgBox("Meas.Point")

    '    Else
    '    End If

    'End Sub

    Public Sub ColReadOnly(ByVal nCol As Integer, ByVal bReadOnly As Boolean) 'Col 수정 가능 여부
        DataGridView.Columns.Item(nCol).ReadOnly = True
    End Sub

    Public Sub RowReadOnly(ByVal bReadonly As Boolean) '맨 마지막 Row 수정 가능 여부 및 색 변경
        Dim color As Color

        If bReadonly = True Then
            color = Drawing.Color.White
        Else
            color = Drawing.Color.LightBlue
        End If

        DataGridView.Rows.Item(DataGridView.Rows.GetLastRow(DataGridViewElementStates.None)).DefaultCellStyle.BackColor = color
        DataGridView.Rows.Item(DataGridView.Rows.GetLastRow(DataGridViewElementStates.None)).ReadOnly = bReadonly
    End Sub

    Public Sub RowColorChange(ByVal color As Color)
        DataGridView.Rows.Item(DataGridView.Rows.GetLastRow(DataGridViewElementStates.None)).DefaultCellStyle.BackColor = color
    End Sub


    Private Sub ucDataGridView_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        ReadjustColumnWidth()
    End Sub

End Class