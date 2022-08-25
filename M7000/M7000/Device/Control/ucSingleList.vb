Public Class ucSingleList
    Inherits System.Windows.Forms.UserControl
    Public Event ListDBClick()
#Region " Windows Form 디자이너에서 생성한 코드 "

    Public Sub New()
        MyBase.New()

        '이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()

        'InitializeComponent()를 호출한 다음에 초기화 작업을 추가하십시오.
        init()
    End Sub

    'User`은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    'Windows Form 디자이너를 사용하여 수정할 수 있습니다.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    Friend WithEvents listSingle As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.listSingle = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'listSingle
        '
        Me.listSingle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listSingle.Location = New System.Drawing.Point(0, 0)
        Me.listSingle.MultiSelect = False
        Me.listSingle.Name = "listSingle"
        Me.listSingle.Size = New System.Drawing.Size(611, 404)
        Me.listSingle.TabIndex = 0
        Me.listSingle.UseCompatibleStateImageBehavior = False
        '
        'ucSingleList
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.listSingle)
        Me.Name = "ucSingleList"
        Me.Size = New System.Drawing.Size(611, 404)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Define"

    Dim sColumns() As String
    Dim dColHeaderWidth() As Integer = New Integer() {10, 30, 30, 30}


    Public Enum eUcListErrCode
        eNoError
        eMisMatched_ColumnAndRowDataLen
        eNothingData
        eUnDefineError
        eNothingDataInSelectedColumn
        eNothingDataInSelectedRow
    End Enum


#End Region


#Region "Propertys"

    Public Property ColHeader() As String()
        Get
            Return sColumns
        End Get
        Set(ByVal Value As String())

            sColumns = Value
            SetColumnHeader()
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

            If arrBuf.Length <> sColumns.Length Then
                MsgBox("Column Header의 수와 일치해야 합니다.")
            Else
                Try
                    ReDim dColHeaderWidth(arrBuf.Length - 1)
                    For i As Integer = 0 To arrBuf.Length - 1
                        dColHeaderWidth(i) = CDbl(arrBuf(i))
                    Next
                    SetColumnHeader()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End Set
    End Property
    Public ReadOnly Property RowCounts() As Double

        Get
            Dim listColumn As ListView.ColumnHeaderCollection = listSingle.Columns

            Dim listItem As ListView.ListViewItemCollection = listSingle.Items


            Return (listItem.Count)
        End Get

    End Property
#End Region


#Region "Functions"


    Public Sub init()
        listSingle.Dock = DockStyle.Fill
    End Sub


    Private Sub SetColumnHeader()
        listSingle.FullRowSelect = True
        listSingle.MultiSelect = True

        Dim nListWidth As Integer = listSingle.Size.Width
        Dim nColWidth As Integer

        If sColumns Is Nothing Then
            Exit Sub
        End If

        nColWidth = nListWidth / 200

        listSingle.Clear()

        listSingle.View = View.Details
        listSingle.AllowColumnReorder = True
        listSingle.GridLines = True

        Try
            For i As Integer = 0 To sColumns.Length - 1

                listSingle.Columns.Add(sColumns(i), nColWidth * dColHeaderWidth(i), HorizontalAlignment.Center)
            Next
        Catch ex As Exception

        End Try


    End Sub

#Region "Function Overloading : SetRowData"

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As Double) As eUcListErrCode

        Dim eErr As eUcListErrCode

        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(nRow)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(CStr(sData(i)))
                Next
                listSingle.Items.RemoveAt(nRow)
                listSingle.Items.Insert(nRow, item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode

        Dim eErr As eUcListErrCode

        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(nRow)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next
                listSingle.Items.RemoveAt(nRow)

                listSingle.Items.Insert(nRow, item)


                
            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function
    Public Function SetInsertData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode

        Dim eErr As eUcListErrCode

        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(nRow)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next


                listSingle.Items.Insert(nRow, item)



            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function
#End Region


 

#Region "Function Overloading : AddRowData"

    Public Function AddRowData(ByVal sData() As Double) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = listSingle.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(Format(sData(i)))
                Next

                listSingle.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData() As Integer) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = listSingle.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(Format(sData(i)))
                Next

                listSingle.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData As Integer) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection


        listItem = listSingle.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                item.SubItems.Add(Format(sData))

                listSingle.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function
    Public Function AddRowData(ByVal sData As String) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection


        listItem = listSingle.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                item.SubItems.Add(Format(sData))

                listSingle.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function
    Public Function AddRowData(ByVal sData() As String) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = listSingle.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next

                listSingle.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

#End Region

    Public Function DelRowData() As Boolean
        If listSingle.Items.Count = 0 Or listSingle.SelectedItems.Count = 0 Then
            Return False
        Else
            listSingle.Items.RemoveAt(listSingle.SelectedIndices.Item(0))
        End If

        Return True
    End Function

    Public Function DelRowData(ByVal inRow As Double) As Boolean
        If listSingle.Items.Count = 0 Then
            Return False
        Else
            listSingle.Items.RemoveAt(inRow)
        End If

        Return True
    End Function
    Public Sub ClearAllData()
        listSingle.Items.Clear()
    End Sub


#Region "Function Overloading : ErrorCheck"
    Private Function ErrorCheck(ByVal sData() As Double) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then   'No는 빼고, R,G,B 의 레지스터 값 의 수만 비교
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

    Private Function ErrorCheck(ByVal sData() As Integer) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then   'No는 빼고, R,G,B 의 레지스터 값 의 수만 비교
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function

    Private Function ErrorCheck(ByVal sData() As String) As eUcListErrCode
        If sData Is Nothing Then
            Return eUcListErrCode.eNothingData
        End If

        If sColumns.Length - 1 <> sData.Length Then   'No는 빼고, R,G,B 의 레지스터 값 의 수만 비교
            Return eUcListErrCode.eMisMatched_ColumnAndRowDataLen
        End If

        Return eUcListErrCode.eNoError
    End Function
#End Region


    Public Function GetColumnData(ByVal nCol As Integer, ByRef dColDatas() As Double) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = listSingle.Columns
        Dim listItem As ListView.ListViewItemCollection = listSingle.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim dBufData() As Double


        If nCol > listColumn.Count Then
            Return eUcListErrCode.eNothingDataInSelectedColumn
        End If

        ReDim dBufData(listItem.Count - 1)

        For i As Integer = 0 To listItem.Count - 1
            item = listItem.Item(i)
            subItem = item.SubItems(nCol)
            dBufData(i) = CDbl(subItem.Text)
        Next

        dColDatas = dBufData.Clone

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetRowData(ByVal nRow As Integer, ByRef sRowData() As String) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = listSingle.Columns
        Dim listItem As ListView.ListViewItemCollection = listSingle.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String


        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 2)

        For i As Integer = 1 To listColumn.Count - 1
            item = listItem.Item(nRow)
            subItem = item.SubItems(i)
            sBufData(i - 1) = subItem.Text
        Next

        sRowData = sBufData.Clone

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetNumOfRowData(ByRef nRow As Integer) As eUcListErrCode

        Return eUcListErrCode.eNoError
    End Function
  
#End Region

    Private Sub ucSingleList_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        '   SetColumnHeader()
    End Sub

    Private Sub ucSingleList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub listSingle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listSingle.SelectedIndexChanged
      
    End Sub
    Public Function SelectData() As String
        Try
            Dim tViewCollection As System.Windows.Forms.ListView.SelectedListViewItemCollection
            tViewCollection = listSingle.SelectedItems
            Dim item As ListViewItem
            Dim subItem As ListViewItem.ListViewSubItem

            item = tViewCollection.Item(0)
            subItem = item.SubItems(1)

            Return subItem.Text
        Catch ex As Exception
            Return ""
        End Try
    
    End Function
    Private Sub listSingle_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listSingle.MouseDoubleClick

      
        RaiseEvent ListDBClick()
    End Sub
    Event ListEventClick()

    Private Sub listSingle_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listSingle.MouseClick
        RaiseEvent ListEventClick()
    End Sub
End Class
