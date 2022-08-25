Public Class CChDisp
   

    Dim m_nChNo As Integer
    Dim m_sDispCh As String

    Dim m_nDispType As eChannelDispType

    Dim m_sDispCh_JIGAndCell() As String

    Public Enum eChannelDispType
        eChannel
        eJIGAndCellNo
    End Enum

    ''' <summary>
    '''  Channel NO 0 ~ maxch - 1 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChannelNo As Integer
        Get
            Return m_nChNo
        End Get
        Set(ByVal value As Integer)
            m_nChNo = value
        End Set
    End Property


    ''' <summary>
    ''' 
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DispType As eChannelDispType
        Get
            Return m_nDispType
        End Get
        Set(ByVal value As eChannelDispType)
            m_nDispType = value
        End Set
    End Property

    ''' <summary>
    ''' Get Channel Name for Display
    ''' example) Channel No  or JIG No + Cell No
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DispChannel As String
        Get
            Return MakeDispChannelName()
        End Get
    End Property



    Public Sub New()

        ReDim m_sDispCh_JIGAndCell(g_nMaxCh - 1)

        Dim combindChNum() As Integer
        Dim nCntCh As Integer

        For i = 0 To g_ConfigInfos.numOfJIG - 1
            '같은 지그에 위치한 채널 확인
            combindChNum = frmSettingWind.CheckCombinedChannelAsJIG(i)

            For idx As Integer = 0 To combindChNum.Length - 1
                m_sDispCh_JIGAndCell(nCntCh) = Format(i + 1, "00") & "-" & Format(idx + 1, "00")
                nCntCh += 1
            Next
        Next


    End Sub




    Private Function MakeDispChannelName() As String

        Select Case m_nDispType

            Case eChannelDispType.eChannel
                m_sDispCh = Format(m_nChNo + 1, "000")
            Case eChannelDispType.eJIGAndCellNo
                m_sDispCh = m_sDispCh_JIGAndCell(m_nChNo)
        End Select
        Return m_sDispCh
    End Function




End Class
