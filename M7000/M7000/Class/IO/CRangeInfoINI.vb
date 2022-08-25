Public Class CRangeInfoINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Range Data"}

    Private strKey() As String = New String() {"File Title", "File Version",
                                               "MaxCh", "CurrentIndex", "IVLCurrentIndex", "PhotocurrentIndex", "ProbeIndex", "AutoRangeIndex", "SemiAutoRangeIndex"}

    Public Enum eSecID
        eFileInfo
        eRangeData
    End Enum

    Public Enum eKeyID
        FileTitle
        FileVersion
        eMaxCh
        eCurrentIndex
        eCurrentIVLIndex
        ePhotoIndex
        eProbeIndex
        eAutoRangeIndex
        eSemiAutoRangeIndex
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)

        Dim sSection As String
        If nSection = eSecID.eRangeData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRangeData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eRangeData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRangeData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function

End Class
