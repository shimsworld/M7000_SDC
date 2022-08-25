Public Class CSavePosition
    Inherits cls_INI
    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub
    Private strSection() As String = New String() {"File Info", "CH"}
    '   "THC_98585", _

    Private strKey() As String = New String() {"FileTitle", "X", "Y", "Z"}

    Public Enum eSecID
        eFileInfo
        eCh
    End Enum

    '  eTHC98585

    Public Enum eKeyID
        FileTitle        'File Info
        X
        Y
        Z
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)


        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function
End Class
