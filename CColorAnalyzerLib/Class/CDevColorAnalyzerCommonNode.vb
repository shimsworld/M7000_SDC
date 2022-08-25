Imports CCommLib

Public Class CDevColorAnalyzerCommonNode

#Region "Define"

    Protected m_MyModel As eModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_DeviceInfos As sSetInfos
    Protected m_bIsConnected As Boolean = False
    Shared sSupportDeviceList() As String = New String() {"None", "HEXA50", "CA310_SDK", "CAXXX_CMD", "CS100A", "BM-7A"}

    Protected m_sErrMsg As String

    Protected comm As CCommLib.CComAPI  'Communication Object

    Public OriginCalibration As CDevColorAnalyzerCommonNode.sSetInfos = Nothing

    Public Structure sSetInfos
        'Dim sCA310Settings As CDevCA310.sSettings
        Dim sCS100Settings As CDevCS100A.sSettings
        Dim sCAxxxSettings As CDevCAxxxCMD.sSettings
        Dim sHEXA50Settings As CDevHEXA50.sSettings
        Dim sBM7ASettings As CDevBM_7A.sSettings
    End Structure

    Public Structure sDataInfos
        'Dim sCA310Datas As CDevCA310.sDatas
        Dim sCS100Datas As CDevCS100A.sDatas
        Dim sCAxxxDatas As CDevCAxxxCMD.sDatas
        Dim sHEXA50Datas As CDevHEXA50.sDatas
        Dim sBM7ADatas As CDevBM_7A.sDatas
        Dim Data As sDatas
    End Structure

    Public Structure sDatas
        Dim dACDXdigit As Double
        Dim dACDYdigit As Double
        Dim dACDZdigit As Double
        Dim dADCX As Double
        Dim dADCY As Double
        Dim dADCZ As Double
        Dim dX As Double
        Dim dY As Double
        Dim dZ As Double
        Dim dLuminance As Double
        Dim dCIEx As Double
        Dim dCIEy As Double
        Dim dCIE1960u As Double
        Dim dCIE1960v As Double
        Dim dCIE1976u As Double
        Dim dCIE1976v As Double
        Dim dLV As Double
        Dim dDiff_Y As Double
        Dim dDiff_CIEx As Double
        Dim dDiff_CIEy As Double
        Dim dLprime As Double
        Dim dApirme As Double
        Dim dBprime As Double
        Dim dTemp As Double
        Dim CCT As Double
        Dim LsUser As Double
        Dim usUser As Double
        Dim vsUser As Double
        Dim dEUser As Double
        Dim duv As Double
        Dim Rvalue As Double
        Dim Bvalue As Double
        Dim Gvalue As Double
        Dim BBL_x As Double
        Dim BBL_y As Double
        Dim BBL_u As Double
        Dim BBL_v As Double
        Dim MPCD As Double
    End Structure


    Public Structure sColorCIEParam
        Dim CIEx As Double   'CIE1931
        Dim CIEy As Double
        Dim CIE1960_u As Double   'CIE1960
        Dim CIE1960_v As Double
        Dim CIE1976_ud As Double   'CIE1976
        Dim CIE1976_vd As Double
        Dim CCT As Double
        Dim BBL_x As Double
        Dim BBL_y As Double
        Dim BBL_u As Double
        Dim BBL_v As Double
        Dim MPCD As Double
    End Structure

    Public Enum eModel
        eColorAnalyzer_None
        eColorAnalyzer_HEXA50
        eColorAnalyzer_CA310SDKMode
        eColorAnalyzer_CAxxxCmdMode
        eColorAnalyzer_CS100A
        eColorAnalyzer_BM7A
    End Enum

#End Region

#Region "Properties"


    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_sErrMsg
        End Get
    End Property


    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public Property Model As eModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eModel)
            m_MyModel = value
        End Set
    End Property

    Public Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Property DeviceInfos As sSetInfos
        Get
            Return m_DeviceInfos
        End Get
        Set(value As sSetInfos)
            m_DeviceInfos = value
        End Set
        '  Set(ByVal value As DeviceOption)
        '       m_DeviceInfos = value
        '  End Set
    End Property
#End Region


#Region "Creator, Disoposer And Init"

    Public Sub New()
        m_bIsConnected = False
    End Sub

#End Region

#Region "Communication Functions"

    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function

    Public Overridable Function Connection() As Boolean
        Return False
    End Function

    Public Overridable Sub Disconnection()

    End Sub

    Public Overridable Sub Disconnection(ByVal addr As Integer)

    End Sub

#End Region

#Region "Control Functions"

    Public Overridable Function Initialization() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' 장치의 
    ''' </summary>
    ''' <param name="infos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetSettings(ByVal infos As sSetInfos) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="infos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetSettings(ByRef infos As sSetInfos) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' HEXA50 레인지 선택 설정 값
    ''' </summary>
    ''' <param name="nRangeIndex"></param>
    ''' <param name="infos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SetSettingsOneRange(ByVal nRangeIndex As Integer, ByVal infos As sSetInfos) As Boolean
        Return False
    End Function

    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="infos"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Overridable Function GetDeviceInfo(ByRef infos As CDevCA310.sDevInfo) As Boolean
    '    Return False
    'End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="infos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetDeviceInfo(ByRef infos As CDevCAxxxCMD.sDevInfo) As Boolean
        Return False
    End Function


    Public Overridable Function ZeroCalibration() As Boolean
        Return False
    End Function


    '' ''' <summary>
    '' ''' Measuring Data 
    '' ''' for CA310
    '' ''' </summary>
    '' ''' <param name="measuredDatas"></param>
    '' ''' <returns></returns>
    '' ''' <remarks></remarks>
    'Public Overridable Function Measure(ByRef measuredDatas As CDevCA310.sDatas) As Boolean
    '    Return False
    'End Function

    ''' <summary>
    ''' CAXXX Serise Command mode
    ''' </summary>
    ''' <param name="measuredDatas"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Measure(ByRef measuredDatas As CDevCAxxxCMD.sDatas) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Measuring Data
    ''' CS100A
    ''' </summary>
    ''' <param name="measuredDatas"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Measure(ByRef measuredDatas As CDevCS100A.sDatas) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Measuring Data
    ''' MC30
    ''' </summary>
    ''' <param name="measuredDatas"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Measure(ByRef measuredDatas As CDevHEXA50.sDatas) As Boolean
        Return False
    End Function

    Public Overridable Function Measure(ByRef measuredDatas As sDataInfos) As Boolean
        Return False
    End Function

    Public Overridable Function AutoRangeMeasure(ByRef measuredDatas As sDataInfos) As Boolean
        Return False
    End Function

    Public Overridable Function Test() As Boolean
        Return False
    End Function


    Public Shared Function CalculateCIEParam(ByVal CIEx As Double, ByVal CIEy As Double) As sColorCIEParam
        Dim xe As Double = 0.332
        Dim ye As Double = 0.1858
        Dim n As Double = (CIEx - xe) / (CIEy - ye)

        Dim tempbblx3, tempbbly3 As Double
        Dim tempbblx2, tempbbly2 As Double
        Dim tempbblx1, tempbbly1 As Double
        Dim tempbblxConst, tempbblyConst As Double
        Dim tempbblxValueIndex, tempbblyValueIndex As Integer

        Dim sParams As sColorCIEParam

        Dim bblx3() As Double = New Double() {-0.2661239 * 10 ^ 9, -3.0258469 * 10 ^ 9}
        Dim bblx2() As Double = New Double() {-0.234358 * 10 ^ 6, 2.1070379 * 10 ^ 6}
        Dim bblx1() As Double = New Double() {0.8776956 * 10 ^ 3, 0.2226347 * 10 ^ 3}
        Dim bbly3() As Double = New Double() {-1.1063814, -0.9549476, 3.081758}
        Dim bbly2() As Double = New Double() {-1.3481102, -1.37418593, -5.8733867}
        Dim bbly1() As Double = New Double() {2.18555832, 2.09137015, 3.75112997}
        Dim bblxConst() As Double = New Double() {0.17991, 0.24039}
        Dim bblyConst() As Double = New Double() {-0.20219683, -0.16748867, -0.37001483}

        With sParams
            .CIEx = CIEx
            .CIEy = CIEy
            .CIE1960_u = 4 * CIEx / (3 + 12 * CIEy - 2 * CIEx)
            .CIE1960_v = 6 * CIEy / (3 + 12 * CIEy - 2 * CIEx)
            .CIE1976_ud = .CIE1960_u
            .CIE1976_vd = 3 / 2 * .CIE1960_v
            .CCT = (-449 * n ^ 3) + (3525 * n ^ 2) - (6823.3 * n) + 5520.33

            If .CCT < 4000 Then
                tempbblxValueIndex = 0
            Else
                tempbblxValueIndex = 1
            End If

            tempbblx3 = bblx3(tempbblxValueIndex)
            tempbblx2 = bblx2(tempbblxValueIndex)
            tempbblx1 = bblx1(tempbblxValueIndex)
            tempbblxConst = bblxConst(tempbblxValueIndex)

            .BBL_x = (tempbblx3 / .CCT ^ 3) + (tempbblx2 / .CCT ^ 2) + (tempbblx1 / .CCT + tempbblxConst)

            If .CCT < 2222 Then
                tempbblyValueIndex = 0
            ElseIf .CCT >= 2222 And .CCT < 4000 Then
                tempbblyValueIndex = 1
            ElseIf .CCT >= 4000 And .CCT < 25000 Then
                tempbblyValueIndex = 2
            Else
                tempbblyValueIndex = -1
            End If

            If tempbblyValueIndex <> -1 Then
                tempbbly3 = bbly3(tempbblyValueIndex)
                tempbbly2 = bbly2(tempbblyValueIndex)
                tempbbly1 = bbly1(tempbblyValueIndex)
                tempbblyConst = bblyConst(tempbblyValueIndex)

                .BBL_y = (tempbbly3 * .BBL_x ^ 3) + (tempbbly2 * .BBL_x ^ 2) + (tempbbly1 * .BBL_x) + tempbblyConst

            Else
                .BBL_y = 0
            End If


            .BBL_u = 4 * .BBL_x / (3 + 12 * .BBL_y - 2 * .BBL_x)
            .BBL_v = 6 * .BBL_y / (3 + 12 * .BBL_y - 2 * .BBL_x)

            Dim calCIEv As Double

            calCIEv = .CIE1960_v - .BBL_v

            If calCIEv < 0 Then
                .MPCD = -1 * Math.Sqrt((.CIE1960_u - .BBL_u) ^ 2 + (.CIE1960_v - .BBL_v) ^ 2) / 0.0005
            Else
                .MPCD = Math.Sqrt((.CIE1960_u - .BBL_u) ^ 2 + (.CIE1960_v - .BBL_v) ^ 2) / 0.0005
            End If

        End With

        Return sParams

    End Function


#End Region


End Class
