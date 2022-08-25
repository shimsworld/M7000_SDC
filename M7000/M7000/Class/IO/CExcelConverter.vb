Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO

Public Class CExcelConverter

#Region "Define"

    Dim mVisible As Boolean = False
    Dim xlApp As Object
    Dim xlworkbook As Excel.Workbook
    Dim xlworksheet As Excel.Worksheet

#End Region

    Public Property visible As Boolean
        Get
            Return mVisible
        End Get
        Set(ByVal value As Boolean)
            mVisible = value
        End Set
    End Property

    Public Sub initialize()

    End Sub

    Public Sub saveWorkbook()
        xlworkbook.Save()
    End Sub

    Public Sub saveAsWorkbook(ByVal path As String)
        '파일이 있는지 검색 후 있으면 삭제
        If File.Exists(path) Then
            File.Delete(path)
        End If

        Try
            xlworkbook.SaveAs(path)
        Catch ex As Exception
            MsgBox("Data Save Fail...")
        End Try

    End Sub

    Public Function connectExcel() As Boolean
        Try
            GC.Collect()

            If xlApp Is Nothing = True Then
                xlApp = New Excel.Application
                xlApp.visible = mVisible
            End If

            If xlworkbook Is Nothing = False Then
                disconnectExcel()
            End If

            xlworkbook = xlApp.workbooks.add()

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Sub disconnectExcel()
        If mVisible = False Then
            xlworkbook.Close()
            xlApp.quit()
        End If

        xlworksheet = Nothing
        xlworkbook = Nothing
        xlApp.quit()
        xlApp = Nothing

        ExcelKill()
        GC.Collect()
    End Sub

    Private Sub ExcelKill()
        Dim proc As System.Diagnostics.Process
        Dim pList() As Process

        pList = Process.GetProcessesByName("EXCEL")

        For Each proc In pList
            proc.Kill()
        Next

    End Sub

    Private Function StartCellCheck(ByVal StartColumn As Integer, ByVal StartRow As Integer) As String
        Dim i, j As Integer
        Dim Temp As String

        StartCellCheck = Nothing

        Temp = ""
        If StartColumn > 0 And StartRow > 0 Then
            If StartColumn < 27 Then
                Temp = Chr(64 + StartColumn)
            Else
                i = StartColumn \ 26
                j = StartColumn Mod 26
                If i < 27 Then
                    If j > 0 Then
                        Temp = Chr(64 + i) & Chr(64 + j)
                    ElseIf j = 0 Then
                        Temp = Chr(64 + i - 1) & Chr(64 + 26)
                    End If
                Else   'AAA 이상(677이상)
                End If
            End If
            StartCellCheck = Temp & StartRow
        End If

        Return StartCellCheck

    End Function

    Public Sub SheetSelect(ByVal SheetIndex As Integer)
        xlApp.worksheets(SheetIndex).select()
    End Sub

    Public Function SheetSave(ByVal SheetIndex As Integer, ByVal StartColumn As Integer, ByVal StartRow As Integer, ByRef SheetData As Array) As Boolean
        Try
            Dim i As Integer = SheetData.GetUpperBound(0) + 1
            Dim j As Integer = SheetData.GetUpperBound(1) + 1

            xlApp.worksheets(SheetIndex).select()
            xlworksheet = xlworkbook.ActiveSheet

            xlworksheet.Range(StartCellCheck(StartColumn, StartRow)).Resize(i, j).Value = SheetData

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
