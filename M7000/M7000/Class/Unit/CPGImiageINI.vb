Public Class CPGImiageINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Image State", "Image Manager Info"
                                               }


    Private strKey() As String = New String() {"File Title", "File Version", "Image Counter", "Image Index", "Image Name", "Image Path", "Image SyncStatus"}

    Public Enum eSecID
        eFileInfo
        eImageState
        eImageManagerInfo
    End Enum

    Public Enum eKeyID
        eFileTitle
        eFileVersion
        eImageCounter
        eImageIndex       'File Info
        eImageName
        eImagePath
        eImageSyncStatus
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)


        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="keyIndex">0부터 입력</param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Return IniReadValue(sSection, strKey(nkey))
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nkey"></param>
    ''' <param name="keyIndex">0 부터 입력</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
