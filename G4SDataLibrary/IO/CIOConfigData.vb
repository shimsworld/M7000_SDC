Public Class CIOConfigData
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"T_CONFIG", "Firmware", "Fpga", "FTP"}

    Private strKey() As String = New String() {"LOGIN_PASSWORD", "COUNT_RACK", "COUNT_HUB", "EDIT", "IMAGE_DELAY", _
                                               "NAME", _
                                               "NAME", _
                                               "URL", "Directory", "Name", "Password"}


    Public Enum eSecID
        _T_CONFIG
        _FIRMWARE
        _FPGA
        _FTP
    End Enum

    Public Enum eKeyID
        _T_CONFIG_LOGIN_PASSWORD
        _T_CONFIG_COUNT_RACK
        _T_CONFIG_COUNT_HUB
        _T_CONFIG_EDIT
        _T_CONFIG_IMAGE_DELAY
        _FIRMWARE_NAME
        _FPGA_NAME
        _FTP_URL
        _FTP_DIRECTORY
        _FTP_NAME
        _FTP_PASSWORD
    End Enum


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="nKey"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String = strSection(nSection)

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
        Dim sSection As String = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

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
    ''' <param name="nkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nkey As eKeyID) As String
        Dim sSection As String = strSection(nSection)

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
