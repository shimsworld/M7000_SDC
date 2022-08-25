Public Class CM600CalDataINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"File Info", "Common", "Device ID"}

    Private strKey() As String = New String() {"File Title", "FIle Version",
                                               "Comment",
                                               "DEV_CAL_DATA_DEV_ID",
                                               "DEV_CAL_DATA_RV_RATIO",
                                               "DEV_CAL_DATA_RV_OFFSET",
                                                "DEV_CAL_DATA_RC_RATIO",
                                                "DEV_CAL_DATA_RC_OFFSET",
                                                "DEV_CAL_DATA_BR_RATIO",
        "DEV_CAL_DATA_BR_OFFSET",
        "DEV_CAL_DATA_SDCV_RATIO",
        "DEV_CAL_DATA_SDCV_OFFSET",
        "DEV_CAL_DATA_SDCC_RATIO",
        "DEV_CAL_DATA_SDCC_OFFSET",
        "DEV_CAL_DATA_SACV_RATIO",
        "DEV_CAL_DATA_SACV_OFFSET",
        "DEV_CAL_DATA_SACC_RATIO",
        "DEV_CAL_DATA_SACC_OFFSET",
        "DEV_CAL_DATA_CMRR_RATIO",
        "DEV_CAL_DATA_CMRR_OFFSET"}


    Public Enum eSecID
        _FileInfo
        _Common
        _Device_Cal_Data
    End Enum

    Public Enum eKeyID
        _FILEINFO_TITLE       'File Info
        _FILEINFO_VERSION
        _Common_Comment
        _DEV_CAL_DATA_DEV_ID
        _DEV_CAL_DATA_RV_RATIO
        _DEV_CAL_DATA_RV_OFFSET
        _DEV_CAL_DATA_RC_RATIO
        _DEV_CAL_DATA_RC_OFFSET
        _DEV_CAL_DATA_BR_RATIO
        _DEV_CAL_DATA_BR_OFFSET
        _DEV_CAL_DATA_SDCV_RATIO
        _DEV_CAL_DATA_SDCV_OFFSET
        _DEV_CAL_DATA_SDCC_RATIO
        _DEV_CAL_DATA_SDCC_OFFSET
        _DEV_CAL_DATA_SACV_RATIO
        _DEV_CAL_DATA_SACV_OFFSET
        _DEV_CAL_DATA_SACC_RATIO
        _DEV_CAL_DATA_SACC_OFFSET
        _DEV_CAL_DATA_CMRR_RATIO
        _DEV_CAL_DATA_CMRR_OFFSET
    End Enum




    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String

        sSection = strSection(nSection)

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

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


    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection)

        Return IniReadValue(sSection, strKey(nkey))
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>+
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