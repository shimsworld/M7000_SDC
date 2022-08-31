﻿Imports System

Public Class ucDispListView
    Inherits Windows.Forms.UserControl

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub



#Region "Define"

    Dim sColumns() As String
    Dim dColHeaderWidth() As Double = New Double() {25, 25, 25, 25}

    Dim fCheckBox As Boolean = True
    Dim fFullRawSelection As Boolean = True


    Public Event evCheckedItems(ByVal ItemChecked() As Boolean)
    Public Event evSelectedIndexChanged(ByVal nRow As Integer)
    Public selectedIndexColor As Integer


    Public Enum eUcListErrCode
        eNoError
        eMisMatched_ColumnAndRowDataLen
        eNothingData
        eUnDefineError
        eNothingDataInSelectedColumn
        eNothingDataInSelectedRow
    End Enum


#End Region

#Region "Delegate functions"

    Private Delegate Sub SetListViewItem(ByVal listItem As ListViewItem) 'ByVal form As System.Windows.Forms.StatusStrip, 
    Private Delegate Sub ClearListView()
    Private Delegate Sub DelRemoveAt(ByVal nRow As Integer)
    Private Delegate Sub DelInsert(ByVal nRow As Integer, ByVal item As ListViewItem)

    Private Delegate Function DelGetListViewItem(ByVal nRow As Integer) As String()

    Private Delegate Sub CallFunction()



    '  Private Delegate Sub SetStatusStripTextBox(ByVal text As String)

    'ListView1.Items.RemoveAt(nRow)

    '      ListView1.Items.Insert(nRow, item)
    Private Sub DelSetListViewItem(ByVal listItem As ListViewItem)  'ByVal label As System.Windows.Forms.StatusStrip,

        If ListView1.InvokeRequired = True Then
            Dim delListItem As SetListViewItem = New SetListViewItem(AddressOf DelSetListViewItem)
            Try
                Invoke(delListItem, New Object() {listItem})
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            ListView1.Items.AddRange(New ListViewItem() {listItem})
        End If
    End Sub

    Private Sub DelListViewUpdate()
        If ListView1.InvokeRequired = True Then
            Dim del As CallFunction = New CallFunction(AddressOf DelListViewUpdate)
            Try
                Invoke(del)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            ListView1.Update()
        End If
    End Sub

    Private Sub RemoveAt(ByVal nRow As Integer)  'ByVal label As System.Windows.Forms.StatusStrip,
        If ListView1.InvokeRequired = True Then
            Dim del1 As DelRemoveAt = New DelRemoveAt(AddressOf RemoveAt)
            Try
                Invoke(del1, New Object() {nRow})
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            If ListView1.Items.Count > 0 Then
                ListView1.Items.RemoveAt(nRow)
            End If

        End If
    End Sub


    Private Sub Insert(ByVal nRow As Integer, ByVal item As ListViewItem)  'ByVal label As System.Windows.Forms.StatusStrip,
        If ListView1.InvokeRequired = True Then
            Dim del2 As DelInsert = New DelInsert(AddressOf Insert)
            Try
                Invoke(del2, nRow, item)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            ListView1.Items.Insert(nRow, item)
            ' ListView1.Items.Insert(nRow, New Object() {item})
        End If
    End Sub


    Private Function GetListViewItem(ByVal nRow As Integer) As String()
        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String = Nothing

        If ListView1.InvokeRequired = True Then
            Dim delListItem As DelGetListViewItem = New DelGetListViewItem(AddressOf GetListViewItem)
            ' Try
            Invoke(delListItem, nRow)
            'Catch ex As Exception
            '    Return Nothing
            'End Try
        Else
            'If nRow > listItem.Count - 1 Then
            '    Return eUcListErrCode.eNothingDataInSelectedRow
            'End If

            ReDim sBufData(listColumn.Count - 2)

            For i As Integer = 1 To listColumn.Count - 1
                '    item = GetListViewItem(nRow)
                item = listItem.Item(nRow)
                subItem = item.SubItems(i)
                sBufData(i - 1) = subItem.Text
            Next

            Return sBufData.Clone
        End If

        Return sBufData.Clone
    End Function

    Public ReadOnly Property GetListItemCount() As Integer
        Get
            Return ListView1.Items.Count
        End Get
    End Property


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

    Public Property UseCheckBoxex() As Boolean
        Get
            Return fCheckBox
        End Get
        Set(ByVal value As Boolean)
            fCheckBox = value
            ListView1.CheckBoxes = fCheckBox
        End Set
    End Property

    Public Property FullRawSelection() As Boolean
        Get
            Return fFullRawSelection
        End Get
        Set(ByVal value As Boolean)
            fFullRawSelection = value
            ListView1.FullRowSelect = fFullRawSelection
        End Set
    End Property

    Public Property HideSelection As Boolean
        Get
            Return ListView1.HideSelection
        End Get
        Set(value As Boolean)
            ListView1.HideSelection = value
        End Set
    End Property

    Public Property LabelEdit As Boolean
        Get
            Return ListView1.LabelEdit
        End Get
        Set(value As Boolean)
            ListView1.LabelEdit = value
        End Set
    End Property

    Public Property LabelWrap As Boolean
        Get
            Return ListView1.LabelWrap
        End Get
        Set(value As Boolean)
            ListView1.LabelWrap = value
        End Set
    End Property


#End Region

#Region "Functions"

    Public Sub init()
        ListView1.Dock = DockStyle.Fill
        ListView1.FullRowSelect = fFullRawSelection
        ListView1.CheckBoxes = fCheckBox
        ListView1.GridLines = True
        ListView1.MultiSelect = False

    End Sub

    Private Sub SetColumnHeader()

        Dim nListWidth As Integer = ListView1.Size.Width
        Dim dColWidth As Double
        Dim dHeaderWidth As Double

        If sColumns Is Nothing Then
            Exit Sub
        End If

        dColWidth = nListWidth / 100

        ListView1.Columns.Clear()

        ListView1.View = View.Details
        ListView1.AllowColumnReorder = True
        ListView1.GridLines = True

        Try
            For i As Integer = 0 To sColumns.Length - 1
                dHeaderWidth = dColHeaderWidth(i)
                ListView1.Columns.Add(sColumns(i), CInt(dColWidth * dHeaderWidth) - 3, HorizontalAlignment.Center)
            Next
        Catch ex As Exception

        End Try


    End Sub

#Region "Function Overloading : ChangeRowData"
    Public Sub ChangeRowData(ByVal nRow As Integer, ByVal data() As Object)
        Dim i As Integer
        Dim colorType As Color
        Dim fontType As Font = New System.Drawing.Font("Arial", 9.0!)
        If data Is Nothing Then
            Exit Sub
        End If
        Dim item As ListViewItem = New ListViewItem(CStr(data(0)))
        item.UseItemStyleForSubItems = False
        For i = 1 To data.Length - 1
            If Object.ReferenceEquals(data(i).GetType(), colorType.GetType()) = True Then
                item.SubItems.Add(data(i).ToString, data(i), data(i), New System.Drawing.Font("Arial", 9.0!))
            ElseIf Object.ReferenceEquals(data(i).GetType(), fontType.GetType()) = True Then
                item.SubItems.Add(data(i).ToString, Color.Black, Color.Transparent, data(i))
            Else
                item.SubItems.Add(data(i))
            End If

        Next

        ListView1.Items.RemoveAt(nRow)
        ListView1.Items.Insert(nRow, item)
    End Sub

#End Region

#Region "Function Overloading : SetRowData"



    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As Object) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim colorType As Color
        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(sData(0))) 'NO
                item.UseItemStyleForSubItems = False
                For i As Integer = 0 To sData.Length - 1
                    If Object.ReferenceEquals(sData(i).GetType(), colorType.GetType()) = True Then
                        item.SubItems.Add("", Color.Black, sData(i), New System.Drawing.Font("Arial", 9.0!))
                    Else
                        item.SubItems.Add(CStr(sData(i)))
                    End If

                Next
                ListView1.Items.RemoveAt(nRow)
                ListView1.Items.Insert(nRow, item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As Double) As eUcListErrCode

        Dim eErr As eUcListErrCode

        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(nRow)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(CStr(sData(i)))
                Next
                ListView1.Items.RemoveAt(nRow)
                ListView1.Items.Insert(nRow, item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    'Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode

    '    Dim eErr As eUcListErrCode

    '    eErr = ErrorCheck(sData)

    '    If eErr = eUcListErrCode.eNoError Then

    '        Try
    '            Dim item As New ListViewItem(CStr(nRow)) 'NO

    '            For i As Integer = 0 To sData.Length - 1
    '                item.SubItems.Add(sData(i))
    '            Next

    '            ' If ListView1.Items.Count > 0 Then
    '            RemoveAt(nRow)

    '            Insert(nRow, item)
    '            ' Else
    '            '  DelSetListViewItem(item)
    '            '  End If
    '        Catch ex As Exception
    '            Return eUcListErrCode.eUnDefineError
    '        End Try

    '    Else
    '        Return eErr
    '    End If

    '    Return eUcListErrCode.eNoError

    'End Function

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As String) As eUcListErrCode

        ' Dim eErr As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem() As ListViewItem.ListViewSubItem = Nothing

        Try

            item = listItem.Item(nRow)
            ReDim subItem(item.SubItems.Count - 1)

            For i As Integer = 0 To item.SubItems.Count - 1
                subItem(i) = item.SubItems.Item(i)
            Next

            For i As Integer = 0 To sData.Length - 1
                subItem(i).Text = sData(i)
                ' item.SubItems.Insert(i + 1, subItem(i + 1))
            Next
            '   subItem(0).Text = nRow '"CH" & Format(nRow + 1, "000") '데이터 채널번호 출력부 2013-04-22 승현

        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        Return eUcListErrCode.eNoError

    End Function


    Public Function SetRowData(ByVal nRow As Integer, ByVal index As String, ByVal lineColor As Color) As eUcListErrCode

        ' Dim eErr As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem() As ListViewItem.ListViewSubItem



        Try

            item = listItem.Item(nRow)

            ReDim subItem(item.SubItems.Count - 1)

            For i As Integer = 0 To item.SubItems.Count - 1
                subItem(i) = item.SubItems.Item(i)
            Next

            subItem(index).BackColor = lineColor

            Dim newItem As New ListViewItem(subItem(0).Text)
            newItem.UseItemStyleForSubItems = False
            newItem.SubItems.Add("", Color.Black, subItem(1).BackColor, New System.Drawing.Font("Arial", 9.0!))
            newItem.SubItems.Add("", Color.Black, subItem(2).BackColor, New System.Drawing.Font("Arial", 9.0!))
            newItem.SubItems.Add("", Color.Black, subItem(3).BackColor, New System.Drawing.Font("Arial", 9.0!))
            newItem.SubItems.Add("", Color.Black, subItem(4).BackColor, New System.Drawing.Font("Arial", 9.0!))
            '  item.SubItems(index).BackColor = lineColor

            '   Dim item As ListViewItem = ListView1.Items(nRow)
            'Dim subItems() As subitem
            '  item.SubItems.Item(index).BackColor = lineColor
            RemoveAt(nRow)

            Insert(nRow, newItem)
            'Insert(nRow, newItem)


            ' Else
            '  DelSetListViewItem(item)
            '  End If
        Catch ex As Exception
            Return eUcListErrCode.eUnDefineError
        End Try

        ListView1.Refresh()



        Return eUcListErrCode.eNoError



    End Function

    Public Function SetRowData(ByVal nRow As Integer, ByVal sData() As String, ByVal ListLineNo As Integer) As eUcListErrCode

        Dim eErr As eUcListErrCode

        eErr = ErrorCheck(sData)

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(nRow)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next
                item.SubItems(0).Text = CStr(ListLineNo)

                RemoveAt(nRow)

                Insert(nRow, item)

                ListView1.Refresh()
            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function


    Public Function ListUP() As eUcListErrCode

        Dim nRow As Integer
        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem = New ListViewItem '(CStr(0))
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String

        If GetSelectedRowNumber(nRow) <> eUcListErrCode.eNoError Then
            Return eUcListErrCode.eNothingDataInSelectedColumn
        End If

        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 2)

        For i As Integer = 1 To listColumn.Count - 1
            item.SubItems.Add(listItem.Item(nRow - 1).SubItems(i))
            subItem = item.SubItems(i)
        Next
        item.SubItems(0).Text = listItem.Item(nRow - 1).SubItems(0).Text

        RemoveAt(nRow - 1)
        ListView1.Items.Insert(nRow, item)

        Return eUcListErrCode.eNoError

    End Function

    Public Function ListDOWN() As eUcListErrCode

        Dim nRow As Integer
        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem = New ListViewItem '(CStr(0))
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String

        If GetSelectedRowNumber(nRow) = eUcListErrCode.eNoError Then
        End If

        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 2)

        For i As Integer = 1 To listColumn.Count - 1
            item.SubItems.Add(listItem.Item(nRow).SubItems(i))
            subItem = item.SubItems(i)
        Next
        item.SubItems(0).Text = listItem.Item(nRow).SubItems(0).Text

        RemoveAt(nRow)
        'Insert(nRow, item)
        ListView1.Items.Insert(nRow + 1, item)

        Return eUcListErrCode.eNoError

    End Function
#End Region

#Region "Function Overloading : AddRowData"
    Public Function AddRowDataAndNumber(ByVal sData() As String) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(Format(listItem.Count + 1, "000")))  'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next

                DelSetListViewItem(item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function
    Public Function AddRowData(ByVal sData() As Double) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count)) 'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(Format(sData(i)))
                Next

                ListView1.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData() As Object, ByVal colors As Color) ''

        Dim listItem As ListView.ListViewItemCollection
        Dim item As New ListViewItem

        listItem = ListView1.Items
        ' listItem2 = listItem
        Try
            item.SubItems(0).Text = CStr(listItem.Count + 1)
            item.UseItemStyleForSubItems = False

            item.SubItems.Add(sData(0))
            'item.SubItems.Add(sData(1).ToString)


            item.SubItems.Add("", Color.Black, colors, New System.Drawing.Font("Arial", 9.0!))

            ListView1.Items.AddRange(New ListViewItem() {item})

            item.Checked = True

        Catch ex As Exception
            Return True
        End Try

        Return True

    End Function

    Public Function AddRowData(ByVal sData() As Integer) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(Format(sData(i)))
                Next

                ListView1.Items.AddRange(New ListViewItem() {item})

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


        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                item.SubItems.Add(Format(sData))

                ListView1.Items.AddRange(New ListViewItem() {item})

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal sData() As Object, ByVal colors As KnownColor)

        Dim listItem As ListView.ListViewItemCollection
        Dim item As New ListViewItem
        Dim Color As Color

        listItem = ListView1.Items
        ' listItem2 = listItem
        Try
            item.SubItems(0).Text = CStr(listItem.Count + 1)
            item.UseItemStyleForSubItems = False

            item.SubItems.Add(sData(0))
            'item.SubItems.Add(sData(1).ToString)

            Color = Color.FromArgb(colors)

            item.SubItems.Add("", Color.Black, Color, New System.Drawing.Font("Arial", 9.0!))
            ListView1.Items.AddRange(New ListViewItem() {item})

            item.Checked = True

        Catch ex As Exception
            Return True
        End Try

        Return True

    End Function

    Public Sub AddItems(ByVal data() As String)

        Dim i As Integer

        If data Is Nothing Then
            Exit Sub
        End If
        Dim item As ListViewItem = New ListViewItem(CStr(data(0)))
        For i = 1 To data.Length - 1
            item.SubItems.Add(CStr(data(i)))
        Next
        ListView1.Items.Add(item)
    End Sub


    Public Sub AddInit()
        Dim listItem As ListView.ListViewItemCollection
        Dim sData(2) As String

        For i As Integer = 0 To 40
            listItem = ListView1.Items

            Dim item As New ListViewItem(CStr(listItem.Count))  'NO

            For idx As Integer = 0 To sData.Length - 1
                item.SubItems.Add(Format(sData(idx)))
            Next

            DelSetListViewItem(item)

        Next

    End Sub

    Public Function AddRowData_AutoCountListNo(ByVal sData() As String) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        eErr = ErrorCheck(sData)

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO

                For i As Integer = 0 To sData.Length - 1
                    item.SubItems.Add(sData(i))
                Next


                DelSetListViewItem(item)
                '                ListView1.Items.AddRange(New ListViewItem() {item})



            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal index As String, ByVal lineColor As Color) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO
                item.UseItemStyleForSubItems = False
                item.SubItems.Add(index)
                item.SubItems.Add("", Color.Black, lineColor, New System.Drawing.Font("Arial", 9.0!))

                DelSetListViewItem(item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        DelListViewUpdate()

        Return eUcListErrCode.eNoError

    End Function

    Public Function AddRowData(ByVal colors() As Color) As eUcListErrCode

        Dim eErr As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection

        listItem = ListView1.Items

        If eErr = eUcListErrCode.eNoError Then

            Try
                Dim item As New ListViewItem(CStr(listItem.Count))  'NO
                item.UseItemStyleForSubItems = False
                For i As Integer = 0 To colors.Length - 1
                    item.SubItems.Add("", Color.Black, colors(i), New System.Drawing.Font("Arial", 9.0!))
                Next

                DelSetListViewItem(item)

            Catch ex As Exception
                Return eUcListErrCode.eUnDefineError
            End Try

        Else
            Return eErr
        End If

        DelListViewUpdate()

        Return eUcListErrCode.eNoError

    End Function

    Public Sub AddRowData(ByVal data() As String)

        Dim i As Integer

        If data Is Nothing Then
            Exit Sub
        End If
        Dim item As ListViewItem = New ListViewItem(CStr(data(0)))
        For i = 1 To data.Length - 1
            item.SubItems.Add(CStr(data(i)))
        Next
        ListView1.Items.Add(item)
        ListView1.Refresh()
    End Sub


    Public Sub AddRowData(ByVal data() As Object)

        Dim i As Integer
        Dim colorType As Color
        Dim fontType As Font = New System.Drawing.Font("Arial", 9.0!)
        If data Is Nothing Then
            Exit Sub
        End If
        Dim item As ListViewItem = New ListViewItem(CStr(data(0)))
        item.UseItemStyleForSubItems = False
        For i = 1 To data.Length - 1

            If data(i) Is Nothing = False Then
                If Object.ReferenceEquals(data(i).GetType(), colorType.GetType()) = True Then
                    item.SubItems.Add(data(i).ToString, data(i), data(i), New System.Drawing.Font("Arial", 9.0!))
                ElseIf Object.ReferenceEquals(data(i).GetType(), fontType.GetType()) = True Then
                    fontType = data(i)
                    item.SubItems.Add(data(i).ToString, Color.Black, Color.Transparent, fontType)
                Else

                    item.SubItems.Add(data(i))
                End If
            Else
                item.SubItems.Add("Nothing")
            End If
            'End If

        Next
        ListView1.Items.Add(item)
    End Sub


    'Public Sub AddItems(ByVal data() As frmSpectrumCal.sWaveCalData)
    '    Dim i As Integer

    '    If data Is Nothing Then
    '        Exit Sub
    '    End If

    '    ListView1.Items.Clear()

    '    Dim item(data.Length - 1) As ListViewItem

    '    For i = 0 To data.Length - 1
    '        item(i) = New ListViewItem(CStr(i + 1))
    '        item(i).SubItems.Add(CStr(data(i).dRefWaveLen))
    '        item(i).SubItems.Add(CStr(data(i).nMeasuredPixel))
    '        item(i).SubItems.Add(CStr(data(i).dMeasuredSpecPeck))
    '        item(i).SubItems.Add(CStr(data(i).dDistance))
    '    Next
    '    ListView1.Items.AddRange(item)
    'End Sub


#End Region


    Public Sub ClearAllData()
        If ListView1.InvokeRequired = True Then
            Dim delClear As ClearListView = New ClearListView(AddressOf ClearAllData)
            Try
                Invoke(delClear)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            ListView1.Items.Clear()
        End If
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

    Public Function GetColumnData(ByVal nCol As Integer, ByRef dColDatas() As Double) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
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

    Public Function GetColumnData(ByVal nCol As Integer, ByRef dColDatas() As Integer) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim dBufData() As Integer


        If nCol > listColumn.Count Then
            Return eUcListErrCode.eNothingDataInSelectedColumn
        End If

        ReDim dBufData(listItem.Count - 1)

        For i As Integer = 0 To listItem.Count - 1
            item = listItem.Item(i)
            subItem = item.SubItems(nCol)
            dBufData(i) = CInt(subItem.Text)
        Next

        dColDatas = dBufData.Clone

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetColumnData(ByVal nCol As Integer, ByRef sColDatas() As String) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String


        If nCol > listColumn.Count Then
            Return eUcListErrCode.eNothingDataInSelectedColumn
        End If

        ReDim sBufData(listItem.Count - 1)

        For i As Integer = 0 To listItem.Count - 1
            item = listItem.Item(i)
            subItem = item.SubItems(nCol)
            sBufData(i) = subItem.Text
        Next

        sColDatas = sBufData.Clone

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetRowData(ByVal nRow As Integer, ByRef sRowData() As String) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String


        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 2)

        For i As Integer = 1 To listColumn.Count - 1
            '    item = GetListViewItem(nRow)
            item = listItem.Item(nRow)
            subItem = item.SubItems(i)
            sBufData(i - 1) = subItem.Text
        Next

        sRowData = sBufData.Clone   'GetListViewItem(nRow) '

        Return eUcListErrCode.eNoError
    End Function

    Public Function GetRowData(ByVal nRow As Integer, ByRef datas() As ListViewItem.ListViewSubItem) As eUcListErrCode
        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As ListViewItem.ListViewSubItem


        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 1)

        For i As Integer = 0 To listColumn.Count - 1
            '    item = GetListViewItem(nRow)
            item = listItem.Item(nRow)
            subItem = item.SubItems(i)
            sBufData(i) = subItem
        Next

        datas = sBufData.Clone   'GetListViewItem(nRow) '

        Return eUcListErrCode.eNoError
    End Function


    Public Function GetRowData(ByVal nRow As Integer, ByRef sRowData() As Object, ByRef lineColor As Color) As eUcListErrCode

        Dim listColumn As ListView.ColumnHeaderCollection = ListView1.Columns
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        Dim sBufData() As String


        If nRow > listItem.Count - 1 Then
            Return eUcListErrCode.eNothingDataInSelectedRow
        End If

        ReDim sBufData(listColumn.Count - 2)

        For i As Integer = 1 To listColumn.Count - 1
            '    item = GetListViewItem(nRow)
            item = listItem.Item(nRow)
            subItem = item.SubItems(i)
            sBufData(i - 1) = subItem.Text

            If sBufData(i - 1).ToString = "" Then
                sBufData(i - 1) = item.SubItems(i).BackColor.ToArgb
                lineColor = item.SubItems(i).BackColor
            End If
        Next

        sRowData = sBufData.Clone   'GetListViewItem(nRow) '

        Return eUcListErrCode.eNoError
    End Function


    Public Function GetNumOfRowData(ByRef nRow As Integer) As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        nRow = listItem.Count
        Return eUcListErrCode.eNoError
    End Function

    Public Function GetSelectedRowNumber(ByRef nRow As Integer) As eUcListErrCode
        Dim selListItem As ListView.SelectedListViewItemCollection
        ' Dim list As ListViewItem
        If ListView1.Items.Count < 1 Then
            Return eUcListErrCode.eNothingData
        End If

        selListItem = ListView1.SelectedItems
        '    list = ListView1.FocusedItem
        Try
            nRow = ListView1.FocusedItem.Index 'list.Index
        Catch ex As Exception
            '   MsgBox("선택되지 않았습니다.")
            Return eUcListErrCode.eNothingDataInSelectedRow
        End Try

        Return eUcListErrCode.eNoError
    End Function

    Public Function SetLastRowSelect() As eUcListErrCode
        Dim listItem As ListView.ListViewItemCollection = ListView1.Items
        Dim nRow As Integer

        nRow = listItem.Count - 1

        SetSelectedRowNumber(nRow)
        Return eUcListErrCode.eNoError
    End Function

    Public Function SetSelectedRowNumber(ByVal nRow As Integer) As eUcListErrCode
        '   Dim selLimstItem As ListView.SelectedListViewItemCollection
        '   Dim list As ListViewItem = Nothing

        If ListView1.Items.Count < 1 Then
            Return eUcListErrCode.eNothingData
        End If

        ListView1.FocusedItem = ListView1.Items(nRow)

        ListView1.FocusedItem.Selected = True

        If ListView1.CheckBoxes = True Then
            ListView1.FocusedItem.Checked = True
        End If

        'selLimstItem = ListView1.SelectedItems
        'ListView1.FocusedItem = selLimstItem.Item(nRow)


        'ListView1.FocusedItem = list
        Return eUcListErrCode.eNoError
    End Function

    Public Function DelSelectedRow(ByVal nRow As Integer) As Boolean

        ' Dim itemCollection As ListView.ListViewItemCollection

        If ListView1.Items.Count < 1 Then
            Return eUcListErrCode.eNothingData
        End If

        '  itemCollection = ListView1.Items

        ListView1.Items(nRow).Remove()

        Return eUcListErrCode.eNoError
    End Function

#End Region

    Private Sub ucSingleList_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        SetColumnHeader()
    End Sub

    Dim selectedIndex() As Boolean


    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Dim eve As ItemCheckedEventArgs = e
        Dim send As System.Windows.Forms.ListView = sender
        Dim nLen As Integer

        nLen = send.Items.Count

        ReDim Preserve selectedIndex(nLen - 1)

        If eve.Item.Checked = True Then
            selectedIndex(eve.Item.Index) = True
        Else
            selectedIndex(eve.Item.Index) = False
        End If

        RaiseEvent evCheckedItems(selectedIndex)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim nRow As Integer

        If GetSelectedRowNumber(nRow) <> eUcListErrCode.eNothingDataInSelectedRow Then

            If nRow = -1 Then
                Exit Sub
            End If

            RaiseEvent evSelectedIndexChanged(nRow)
        End If

    End Sub

End Class
