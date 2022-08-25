Public Class CIOPatternList
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"LIST"}

    Private strKey() As String = New String() {"NAME", _
                                               "IMAGE", "MAIN", "SUB", "INIT", "RED", "GREEN", "BLUE", "VDD", "VCI", "ELVDD", "ELVSS", "CLOCK", "PAUSE"}


    Public Enum eSecID
        _LIST
    End Enum

    Public Enum eKeyID
        _NAME
        _IMAGE
        _MAIN
        _SUB
        _INIT
        _RED
        _GREEN
        _BLUE
        _VDD
        _VCI
        _ELVDD
        _ELVSS
        _CLOCK
        _PAUSE
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
        Dim sSection As String = strSection(nSection) & Format(rcpSectionIndex + 1, "0")

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
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "0")
        sKey = strKey(nKey) & Format(keyIndex + 1, "0")
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

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "0")

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
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "0")
        sKey = strKey(nkey) & Format(keyIndex + 1, "0")
        Return IniReadValue(sSection, sKey)
    End Function

End Class

