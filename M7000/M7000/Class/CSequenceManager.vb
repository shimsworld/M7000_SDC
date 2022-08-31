Imports System.IO
Imports System.Drawing
Imports CSMULib

Public Class CSequenceManager

    Dim sFileTitle As String = "M7000 Test System Sequence List"
    Dim sVersion As String = "V1.0.0"

    Dim m_SequenceInfo As sSequenceInfo
    Dim m_testRecipes() As ucSequenceBuilder.sRecipeInfo  'Test Recipes 는 실험의 Sequence의 Step을 저장/편집하기 위한 변수로, m_SequenceInfo로 값을 목사함.
    ' Dim m_testEndParam() As ucTestEndParam.sTestEndParam
    Dim m_CurrentRcp As ucSequenceBuilder.sRecipeInfo  '현재 Recipe   'ChangeReciep에서 변경

    Dim m_LoopCounter As Integer

    Dim m_CurrentSeqIndex As Integer ' 등록된 Recipe중에서 현재 레시피 번호
    Dim m_CurrentSeqIndexIVL As Integer
    Dim m_CurrentSeqIndexLifeTime As Integer '등록된 Recipe중에서 현재 LifeTime의 Recipe 번호
    Dim m_CurrentSeqIndexChangeTemp As Integer '등록된 Recipe 중에서 현재 ChangeTemp의 Recipe 번호
    Dim m_CurrentSeqIndexPatternMeas As Integer
    Dim m_CurrentSeqIndexViewAngle As Integer
    Dim m_CurrentSeqIndexLifetimeAndIVL As Integer
    Dim m_CurrentSeqIndexAging As Integer

    Dim m_nChID As Integer  'Sequence ID : Channel number

    Dim m_CurrentMeasIntervalIdx As Integer 'Meas Interval의 Index 를 관리
    Dim m_CurrentMeasInterval As CTime.sTimeValue   'Seqence List에 등록된 Test Recipe 중에서 현재 진행 중인 Recip의 Meas Interval(측정 시간 간격)을 반환
    Dim m_CurrentChangeInterval As CTime.sTimeValue  'Sequence List에 등록된 Test Recipe 중에서 현재 진행중인 Recipe의 Change Intervla(전환시간)을 반환
    Dim m_NextMeasureTime As CTime.sTimeValue   '측정 인터벌의 누적 시간 형태로,  다음 측정될 모드 타임을 저장 한다.
    Dim m_RequestedTest As Boolean   '외부 관리용 변수, Scheduler에서 현재 채널의 명령이 예약되었음을 나타냄(Set Sourcing, LifeTime Meas  등)
    Dim m_RequestedFirstTest As Boolean = False
    Dim m_IVLSweep As Boolean = False 'LifetimeAndIVL 모드에서 Lifetime 측정 후 IVLSweep 실험을 진행했는지 또는 진행중인지 판단하기 위해서
    Dim m_LifetimeAndIVL As Boolean = False
    Dim m_fIsLastSequence As Boolean = False
    Dim m_nIVLSweepMeasCnt As Integer
    Dim m_TestPanelDeviceSG As Boolean = False   '테스트 목적 임 차 후 변경 필요_PSK


    Public Structure sSequenceInfo
        Dim numOfRcpSteps As Integer
        Dim nCounter As Integer   'Sequence List에 등록된 total Test Recipe 수
        Dim nCounterLifeTime As Integer  'Cell, Panel, Module  Lifetime을 모두 더한 수(한개의 채널에 Cell, Panel, Mdoule 이 한꺼번에 있을 수는 없다. 채널1개는 소자 한개)
        Dim nCounterChangedTemp As Integer 'srecipes에 등록된 Recipe중에 ChangeTemperatur의 총 수량
        Dim nCounterIVL As Integer
        Dim nCounterImageSweep As Integer
        Dim nCounterGrayScaleSweep As Integer
        Dim nCounterPatternMeas As Integer
        Dim nCounterViewingAngle As Integer
        Dim nCounterLifetimeAndIVL As Integer
        Dim nCounterAging As Integer
        Dim nCurrentSeqIndex As Integer
        Dim nCurrentSeqIndex_LifeTime As Integer
        Dim nCurrentSeqIndex_ChangeTemp As Integer
        Dim nCurrentSeqIndex_IVL As Integer
        Dim nCurrentSeqIndex_ImageSweep As Integer
        Dim nCurrentSeqIndex_GrayScaleSweep As Integer
        Dim nCurrentSeqIndex_PatternMeas As Integer
        Dim nCurrentSeqIndex_ViewingAngle As Integer
        Dim nCurrentSeqIndex_LifetimeAndIVL As Integer
        Dim nCurrentSeqIndex_Aging As Integer
        Dim sSampleInfos As ucSampleInfos.sSampleInfos
        Dim sCommon As ucSequenceBuilder.sRcpCommon
        Dim sRecipes() As ucSequenceBuilder.sRecipeInfo
    End Structure

    Public Event evChangedSequenceInfo(ByVal sequenceInfo As sSequenceInfo)

    Public Sub New()
        ' m_CurrentSeqIndex = 0
        m_SequenceInfo.nCounter = 0
        m_SequenceInfo.nCounterChangedTemp = 0
        m_SequenceInfo.nCounterLifeTime = 0
        m_SequenceInfo.nCurrentSeqIndex = 0
        m_SequenceInfo.nCurrentSeqIndex_LifeTime = 0
        m_SequenceInfo.nCurrentSeqIndex_ChangeTemp = 0
        m_SequenceInfo.nCurrentSeqIndex_PatternMeas = 0
        m_SequenceInfo.nCurrentSeqIndex_ViewingAngle = 0
        m_SequenceInfo.nCurrentSeqIndex_LifetimeAndIVL = 0
        m_SequenceInfo.nCurrentSeqIndex_Aging = 0
        m_CurrentChangeInterval = CTime.Convert_HoureToTimeValue(0)
        m_CurrentMeasInterval = CTime.Convert_HoureToTimeValue(0)
        m_CurrentMeasIntervalIdx = 0
        m_CurrentRcp = Nothing
        m_CurrentSeqIndex = 0
        m_CurrentSeqIndexChangeTemp = 0
        m_CurrentSeqIndexLifeTime = 0
        m_CurrentSeqIndexIVL = 0
        m_CurrentSeqIndexPatternMeas = 0
        m_CurrentSeqIndexViewAngle = 0
        m_CurrentSeqIndexLifetimeAndIVL = 0
        m_CurrentSeqIndexAging = 0
        m_LoopCounter = 0
        m_RequestedFirstTest = False
        m_fIsLastSequence = False
        m_nIVLSweepMeasCnt = 0
    End Sub

#Region "Properties"

    Public Property Index As Integer
        Get
            Return m_nChID
        End Get
        Set(ByVal value As Integer)
            m_nChID = value
        End Set
    End Property

    Public ReadOnly Property Current As ucSequenceBuilder.sRecipeInfo
        Get
            Return m_CurrentRcp
        End Get
    End Property

    Public Property MeasInterval As CTime.sTimeValue
        Get
            Return m_CurrentMeasInterval
        End Get
        Set(ByVal value As CTime.sTimeValue)
            m_CurrentMeasInterval = value
        End Set
    End Property

    Public Property ChangeInterval As CTime.sTimeValue
        Get
            Return m_CurrentChangeInterval
        End Get
        Set(ByVal value As CTime.sTimeValue)
            m_CurrentChangeInterval = value
        End Set
    End Property

    Public Property NextMeasureTime As CTime.sTimeValue
        Get
            Return m_NextMeasureTime
        End Get
        Set(ByVal value As CTime.sTimeValue)
            m_NextMeasureTime = value
        End Set
    End Property

    Public Property RequestIVLSweep As Boolean
        Get
            Return m_IVLSweep
        End Get
        Set(ByVal value As Boolean)
            m_IVLSweep = value
        End Set
    End Property

    Public Property IVLSweepMeasCount As Integer
        Get
            Return m_nIVLSweepMeasCnt
        End Get
        Set(ByVal value As Integer)
            m_nIVLSweepMeasCnt = value
        End Set
    End Property

    Public Property RequestLifetimeAndIVL As Boolean
        Get
            Return m_LifetimeAndIVL
        End Get
        Set(ByVal value As Boolean)
            m_LifetimeAndIVL = value
        End Set
    End Property

    Public Property RequestTest As Boolean
        Get
            Return m_RequestedTest
        End Get
        Set(ByVal value As Boolean)
            m_RequestedTest = value
        End Set
    End Property

    Public ReadOnly Property TestEndParams() As ucTestEndParam.sTestEndParam()
        Get
            Return m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sLifetimeEnd  'm_SequenceInfo.nCurrentSeqIndex
        End Get
    End Property

    Public Property SequenceInfo As sSequenceInfo
        Get
            Return m_SequenceInfo
        End Get
        Set(ByVal value As sSequenceInfo)
            m_SequenceInfo = value
            m_testRecipes = value.sRecipes
        End Set
    End Property

    Public ReadOnly Property IsLastSequence() As Boolean
        Get
            Return m_fIsLastSequence
        End Get
    End Property

    Public Property LoopCount As Integer
        Get
            Return m_LoopCounter
        End Get
        Set(ByVal value As Integer)
            m_LoopCounter = value
            LoopCounter = m_LoopCounter
        End Set
    End Property

    Public Property CurrentRecipeIndex(Optional ByVal dDown As Boolean = False) As Integer
        Get
            Return m_CurrentSeqIndex
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndex = value
            If dDown = True Then
                recipeCounter = m_CurrentSeqIndex
            Else
                recipeCounter = m_CurrentSeqIndex + 1
            End If

            If recipeCounter >= m_SequenceInfo.nCounter Then
                m_fIsLastSequence = False
                recipeCounter = 0
                recipeCounter_LifeTime = 0
                recipeCounter_ChangeTemp = 0
                recipeCounter_LifetimeAndIVL = 0
                recipeCounter_Aging = 0
            Else
                m_fIsLastSequence = False
            End If
        End Set
    End Property

    Public Property CurrentRecipeIndex_LifeTime As Integer
        Get
            Return m_CurrentSeqIndexLifeTime
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexLifeTime = value
            recipeCounter_LifeTime = m_CurrentSeqIndexLifeTime + 1

            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_LifeTime = 0
            End If
        End Set
    End Property
    Public Property CurrentRecipeIndex_Aging As Integer
        Get
            Return m_CurrentSeqIndexAging
        End Get
        Set(value As Integer)
            m_CurrentSeqIndexAging = value
            recipeCounter_Aging = m_CurrentSeqIndexAging + 1

            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_Aging = 0
            End If
        End Set
    End Property

    Public Property CurrentRecipeIndex_IVLSweep As Integer
        Get
            Return m_CurrentSeqIndexIVL
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexIVL = value
            recipeCounter_LifeTime = m_CurrentSeqIndexIVL + 1

            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_LifeTime = 0
            End If
        End Set
    End Property


    Public Property CurrentRecipeIndex_ChangeTemp As Integer
        Get
            Return m_CurrentSeqIndexChangeTemp
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexChangeTemp = value
            recipeCounter_ChangeTemp = m_CurrentSeqIndexChangeTemp + 1
            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_ChangeTemp = 0
            End If
        End Set
    End Property

    Public Property CurrentRecipeIndex_PatternMeas As Integer
        Get
            Return m_CurrentSeqIndexPatternMeas
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexPatternMeas = value
            recipeCounter_PatternMeas = m_CurrentSeqIndexPatternMeas + 1
            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_PatternMeas = 0
            End If
        End Set
    End Property

    Public Property CurrentRecipeIndex_ViewingAngle As Integer
        Get
            Return m_CurrentSeqIndexViewAngle
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexViewAngle = value
            recipeCounter_ViewingAngle = m_CurrentSeqIndexViewAngle + 1
            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_ViewingAngle = 0
            End If
        End Set
    End Property

    Public Property CurrentRecipeIndex_LifetimeAndIVL As Integer
        Get
            Return m_CurrentSeqIndexLifetimeAndIVL
        End Get
        Set(ByVal value As Integer)
            m_CurrentSeqIndexLifetimeAndIVL = value
            recipeCounter_LifetimeAndIVL = m_CurrentSeqIndexLifetimeAndIVL + 1
            If recipeCounter >= m_SequenceInfo.nCounter Then
                recipeCounter_LifetimeAndIVL = 0
            End If
        End Set
    End Property

#End Region

#Region "Test Recipe Management Functions"

    Private recipeCounter As Integer = 0 'Recipe  Count 용 변수
    Private recipeCounter_LifeTime As Integer = 0
    Private recipeCounter_IVLSweep As Integer = 0
    Private recipeCounter_ChangeTemp As Integer = 0
    Private recipeCounter_PatternMeas As Integer = 0
    Private recipeCounter_ViewingAngle As Integer = 0  'Add 20150305
    Private recipeCounter_LifetimeAndIVL As Integer = 0
    Private recipeCounter_Aging As Integer = 0
    Private LoopCounter As Integer = 0 'Recipe 전체 Count 회수 체크용 변수 2013-03-19

    Public Sub ChangeNextRecipe(Optional ByVal bDown As Boolean = False)
        m_CurrentSeqIndex = recipeCounter
        m_CurrentRcp = m_SequenceInfo.sRecipes(m_CurrentSeqIndex)
        m_LoopCounter = LoopCounter
        m_CurrentSeqIndexLifeTime = recipeCounter_LifeTime
        m_CurrentSeqIndexIVL = recipeCounter_IVLSweep
        m_CurrentSeqIndexChangeTemp = recipeCounter_ChangeTemp
        m_CurrentSeqIndexPatternMeas = recipeCounter_PatternMeas
        m_CurrentSeqIndexViewAngle = recipeCounter_ViewingAngle
        m_CurrentSeqIndexLifetimeAndIVL = recipeCounter_LifetimeAndIVL
        m_CurrentSeqIndexAging = recipeCounter_Aging
        m_CurrentMeasIntervalIdx = 0

        If bDown = False Then
            m_NextMeasureTime = CTime.Convert_SecToTimeValue(0)
        End If

        If m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or
            m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Or
            m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Then

            m_CurrentMeasInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Interval
            m_CurrentChangeInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Change

            recipeCounter_LifeTime += 1

        ElseIf m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then

            recipeCounter_ChangeTemp += 1

        ElseIf m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Or
            m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eModuel_IVL Or
            m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.ePanel_IVL Then

            recipeCounter_IVLSweep += 1

        ElseIf m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then

            recipeCounter_ViewingAngle += 1

        ElseIf m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_Aging Then
            recipeCounter_Aging += 1

        ElseIf m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
            m_CurrentMeasInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Interval
            m_CurrentChangeInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Change
            recipeCounter_LifetimeAndIVL += 1
        End If

        recipeCounter += 1
        'm_LoopCounter += 1

        If recipeCounter >= m_SequenceInfo.nCounter Then
            'm_fIsLastSequence = True

            m_fIsLastSequence = False '마지막 되면 온도 올리는 단계로 올라가서 재실행. '2013-03-15 승현
            recipeCounter = 0
            recipeCounter_LifeTime = 0
            recipeCounter_ChangeTemp = 0
            recipeCounter_PatternMeas = 0
            recipeCounter_IVLSweep = 0
            recipeCounter_ViewingAngle = 0
            recipeCounter_LifetimeAndIVL = 0
            recipeCounter_Aging = 0
            LoopCounter += 1
        Else
            m_fIsLastSequence = False
        End If
    End Sub

    Public Sub SetCurrentRecipe(ByVal idx As Integer)
        m_CurrentRcp = m_SequenceInfo.sRecipes(idx)
    End Sub

    Public Sub UpdateCurrentRecipe()
        m_CurrentRcp = m_SequenceInfo.sRecipes(m_CurrentSeqIndex)
    End Sub

    Public Sub ChangeMeasInterval()
        If m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Or m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Or m_CurrentRcp.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Then
            m_CurrentMeasIntervalIdx += 1
            If m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval.Length - 1 >= m_CurrentMeasIntervalIdx Then '인터벌 및 체인지 타임 없음
                m_CurrentMeasInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Interval
                m_CurrentChangeInterval = m_SequenceInfo.sRecipes(m_CurrentSeqIndex).sLifetimeInfo.sCommon.sMeasureInterval(m_CurrentMeasIntervalIdx).Change
            End If
        End If
    End Sub

    Public Sub AccumulateMeasTime()
        Dim calBuff_Hour As Double
        calBuff_Hour = m_NextMeasureTime.dHour + m_CurrentMeasInterval.dHour
        m_NextMeasureTime = CTime.Convert_HoureToTimeValue(calBuff_Hour)
    End Sub

    Public Sub ChageCurrentRecipeToTestEnd()
        '  m_CurrentRcp.nState = ucControlPannel.eState.TestFinishing
        recipeCounter = 0
        recipeCounter_LifeTime = 0
        recipeCounter_ChangeTemp = 0
        recipeCounter_PatternMeas = 0
        recipeCounter_ViewingAngle = 0
        recipeCounter_LifetimeAndIVL = 0
        m_RequestedFirstTest = False
        m_fIsLastSequence = False
    End Sub


    Public Sub Create(ByVal infos As ucSampleInfos.sSampleInfos, ByVal savePath As String)
        m_SequenceInfo.sSampleInfos = infos
        SaveSequence(savePath)
    End Sub

    'Public Sub SetCommonSettings(ByVal settings As ucSequenceBuilder.sRcpCommon)
    '    m_SequenceInfo.sCommon = settings

    '    ' RaiseEvent evChangedCommonInfo(m_SequenceInfo.CommSettings)

    '    RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    'End Sub


    Public Sub SetCommonSettings(ByVal settings As ucSequenceBuilder.sRcpCommon, ByVal sampleInfo As ucSampleInfos.sSampleInfos)
        m_SequenceInfo.sCommon = settings
        m_SequenceInfo.sSampleInfos = sampleInfo

        ' RaiseEvent evChangedCommonInfo(m_SequenceInfo.CommSettings)

        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    End Sub

    Public Sub SetCommonSettings(ByVal settings As ucSequenceBuilder.sRcpCommon)
        m_SequenceInfo.sCommon = settings

        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    End Sub

    Public Sub SetSampleSettings(ByVal settings As ucSampleInfos.sSampleInfos)
        m_SequenceInfo.sSampleInfos = settings

        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    End Sub

    Public Sub AddTestReciep(ByVal settings As ucSequenceBuilder.sRecipeInfo)
        ReDim Preserve m_testRecipes(m_SequenceInfo.nCounter)

        For idx As Integer = 0 To m_SequenceInfo.nCounter - 1
            m_testRecipes(idx) = m_SequenceInfo.sRecipes(idx)
        Next

        m_testRecipes(m_SequenceInfo.nCounter) = settings
        m_testRecipes(m_SequenceInfo.nCounter).recipeIndex = m_SequenceInfo.nCounter

        Select Case m_testRecipes(m_SequenceInfo.nCounter).nMode

            Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_ChangeTemp = m_SequenceInfo.nCounterChangedTemp  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                m_SequenceInfo.nCounterChangedTemp += 1
            Case ucSequenceBuilder.eRcpMode.eCell_IVL
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'IVL만 누적한 정보, 즉, 전체 recipe중에서 IVL의 총 수량
                m_SequenceInfo.nCounterIVL += 1
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'IVL만 누적한 정보, 즉, 전체 recipe중에서 IVL의 총 수량
                m_SequenceInfo.nCounterIVL += 1
            Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_ImageSweep = m_SequenceInfo.nCounterImageSweep
                m_SequenceInfo.nCounterImageSweep += 1
            Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_GrayScaleSweep = m_SequenceInfo.nCounterGrayScaleSweep
                m_SequenceInfo.nCounterGrayScaleSweep += 1
            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                m_SequenceInfo.nCounterLifeTime += 1
            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                m_SequenceInfo.nCounterLifeTime += 1
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                m_SequenceInfo.nCounterLifeTime += 1
            Case ucSequenceBuilder.eRcpMode.eViewingAngle
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_ViewingAngle = m_SequenceInfo.nCounterViewingAngle
                m_SequenceInfo.nCounterViewingAngle += 1
            Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                m_testRecipes(m_SequenceInfo.nCounter).recipeIndex_LifetimeAndIVL = m_SequenceInfo.nCounterLifetimeAndIVL
                m_SequenceInfo.nCounterLifetimeAndIVL += 1
            Case ucSequenceBuilder.eRcpMode.eCell_Aging
                m_testRecipes(m_SequenceInfo.nCounter).recipeindex_Aging = m_SequenceInfo.nCounterAging
                m_SequenceInfo.nCounterAging += 1
        End Select

        m_SequenceInfo.nCounter += 1
        m_SequenceInfo.sRecipes = m_testRecipes.Clone
        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    End Sub

    Public Function DelTestRecipe(ByVal selIndex As Integer) As Boolean
        ReDim Preserve m_testRecipes(m_SequenceInfo.nCounter - 1)

        For idx As Integer = 0 To m_SequenceInfo.nCounter - 1
            m_testRecipes(idx) = m_SequenceInfo.sRecipes(idx)
        Next

        If m_SequenceInfo.nCounter = 0 Then Return False

        If m_SequenceInfo.nCounter = 1 Then
            m_testRecipes = Nothing
            m_SequenceInfo.nCounter = 0
            m_SequenceInfo.nCounterChangedTemp = 0
            m_SequenceInfo.nCounterLifeTime = 0
            m_SequenceInfo.nCounterPatternMeas = 0
            m_SequenceInfo.nCounterViewingAngle = 0
            m_SequenceInfo.nCounterIVL = 0
            m_SequenceInfo.nCounterLifetimeAndIVL = 0
        Else

            Dim buffRcpList(m_SequenceInfo.nCounter - 2) As ucSequenceBuilder.sRecipeInfo
            m_SequenceInfo.nCounterChangedTemp = 0
            m_SequenceInfo.nCounterLifeTime = 0
            m_SequenceInfo.nCounterPatternMeas = 0
            m_SequenceInfo.nCounterViewingAngle = 0
            m_SequenceInfo.nCounterIVL = 0
            m_SequenceInfo.nCounterLifetimeAndIVL = 0

            Dim cnt As Integer
            For i As Integer = 0 To m_testRecipes.Length - 1
                If i <> selIndex Then '선택되지 않은 인덱스는 복사, 선택된 인덱스는 버림.

                    Select Case m_testRecipes(i).nMode

                        Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                            m_testRecipes(i).recipeIndex_ChangeTemp = m_SequenceInfo.nCounterChangedTemp  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                            m_SequenceInfo.nCounterChangedTemp += 1
                        Case ucSequenceBuilder.eRcpMode.eCell_IVL
                            m_testRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                            m_SequenceInfo.nCounterIVL += 1
                        Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                            m_testRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                            m_SequenceInfo.nCounterIVL += 1
                        Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep
                            '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                        Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
                            '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                            m_testRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                            m_SequenceInfo.nCounterLifeTime += 1
                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            m_testRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                            m_SequenceInfo.nCounterLifeTime += 1
                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                            m_testRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                            m_SequenceInfo.nCounterLifeTime += 1
                        Case ucSequenceBuilder.eRcpMode.eViewingAngle
                            m_testRecipes(i).recipeIndex_ViewingAngle = m_SequenceInfo.nCounterViewingAngle
                            m_SequenceInfo.nCounterViewingAngle += 1
                        Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL = m_SequenceInfo.nCounterLifetimeAndIVL
                            m_SequenceInfo.nCounterLifetimeAndIVL += 1
                        Case ucSequenceBuilder.eRcpMode.eCell_Aging
                            m_testRecipes(i).recipeindex_Aging = m_SequenceInfo.nCounterAging
                            m_SequenceInfo.nCurrentSeqIndex_Aging += 1
                    End Select

                    buffRcpList(cnt) = m_testRecipes(i)
                    cnt += 1
                End If

            Next

            m_testRecipes = buffRcpList.Clone

            m_SequenceInfo.nCounter = m_testRecipes.Length

            m_SequenceInfo.sRecipes = m_testRecipes.Clone
        End If

        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)

        Return True
    End Function

    Public Function RecipeUP(ByVal selIdx As Integer) As Boolean

        If m_SequenceInfo.nCounter = 0 Then Return False

        If selIdx <= 0 Then Return False

        Dim bufRcp As ucSequenceBuilder.sRecipeInfo

        bufRcp = m_SequenceInfo.sRecipes(selIdx - 1)
        m_SequenceInfo.sRecipes(selIdx - 1) = m_SequenceInfo.sRecipes(selIdx)
        m_SequenceInfo.sRecipes(selIdx) = bufRcp

        m_SequenceInfo.nCounter = 0
        m_SequenceInfo.nCounterChangedTemp = 0
        m_SequenceInfo.nCounterGrayScaleSweep = 0
        m_SequenceInfo.nCounterImageSweep = 0
        m_SequenceInfo.nCounterIVL = 0
        m_SequenceInfo.nCounterLifeTime = 0
        m_SequenceInfo.nCounterPatternMeas = 0
        m_SequenceInfo.nCounterViewingAngle = 0
        m_SequenceInfo.nCounterLifetimeAndIVL = 0

        For i As Integer = 0 To m_SequenceInfo.sRecipes.Length - 1
            m_SequenceInfo.sRecipes(i).recipeIndex = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ChangeTemp = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_GrayScaleSweep = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ImageSweep = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_IVL = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_PatternMeasure = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ViewingAngle = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_LifetimeAndIVL = 0
        Next

        For i As Integer = 0 To m_SequenceInfo.sRecipes.Length - 1
            m_SequenceInfo.sRecipes(i).recipeIndex = i
            Select Case m_SequenceInfo.sRecipes(i).nMode
                Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                    m_SequenceInfo.sRecipes(i).recipeIndex_ChangeTemp = m_SequenceInfo.nCounterChangedTemp  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterChangedTemp += 1
                Case ucSequenceBuilder.eRcpMode.eCell_IVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterIVL += 1
                Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterIVL += 1
                Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep
                    '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
                    '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.eViewingAngle
                    m_SequenceInfo.sRecipes(i).recipeIndex_ViewingAngle = m_SequenceInfo.nCounterViewingAngle
                    m_SequenceInfo.nCounterViewingAngle += 1
                Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifetimeAndIVL = m_SequenceInfo.nCounterLifetimeAndIVL
                    m_SequenceInfo.nCounterLifetimeAndIVL += 1
                Case ucSequenceBuilder.eRcpMode.eCell_Aging
                    m_SequenceInfo.sRecipes(i).recipeindex_Aging = m_SequenceInfo.nCounterAging
                    m_SequenceInfo.nCounterAging += 1
            End Select

            m_SequenceInfo.nCounter += 1
        Next

        m_testRecipes = m_SequenceInfo.sRecipes.Clone
        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
        Return True
    End Function

    Public Function RecipeDown(ByVal selIdx As Integer) As Boolean
        If m_SequenceInfo.nCounter <= 0 Then Return False 'Empty Sequence

        If (m_SequenceInfo.nCounter - 1) <= selIdx Then Return False 'Overflower

        Dim bufRcp As ucSequenceBuilder.sRecipeInfo

        bufRcp = m_SequenceInfo.sRecipes(selIdx + 1)
        m_SequenceInfo.sRecipes(selIdx + 1) = m_SequenceInfo.sRecipes(selIdx)
        m_SequenceInfo.sRecipes(selIdx) = bufRcp

        m_SequenceInfo.nCounter = 0
        m_SequenceInfo.nCounterChangedTemp = 0
        m_SequenceInfo.nCounterGrayScaleSweep = 0
        m_SequenceInfo.nCounterImageSweep = 0
        m_SequenceInfo.nCounterIVL = 0
        m_SequenceInfo.nCounterLifeTime = 0
        m_SequenceInfo.nCounterPatternMeas = 0
        m_SequenceInfo.nCounterViewingAngle = 0
        m_SequenceInfo.nCounterLifetimeAndIVL = 0

        For i As Integer = 0 To m_SequenceInfo.sRecipes.Length - 1
            m_SequenceInfo.sRecipes(i).recipeIndex = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ChangeTemp = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_GrayScaleSweep = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ImageSweep = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_IVL = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_PatternMeasure = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_ViewingAngle = 0
            m_SequenceInfo.sRecipes(i).recipeIndex_LifetimeAndIVL = 0
        Next

        For i As Integer = 0 To m_SequenceInfo.sRecipes.Length - 1

            m_SequenceInfo.sRecipes(i).recipeIndex = i

            Select Case m_SequenceInfo.sRecipes(i).nMode
                Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                    m_SequenceInfo.sRecipes(i).recipeIndex_ChangeTemp = m_SequenceInfo.nCounterChangedTemp  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterChangedTemp += 1
                Case ucSequenceBuilder.eRcpMode.eCell_IVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterIVL += 1
                Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_IVL = m_SequenceInfo.nCounterIVL  'changetemp만 누적한 정보, 즉, 전체 recipe중에서 changTemp의 총 수량
                    m_SequenceInfo.nCounterIVL += 1
                Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep
                    '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
                    '어디도 편입 시켜야 하나? 분리 해서 카운드 해야 하나, LEX_20030719
                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifeTime = m_SequenceInfo.nCounterLifeTime
                    m_SequenceInfo.nCounterLifeTime += 1
                Case ucSequenceBuilder.eRcpMode.eViewingAngle
                    m_SequenceInfo.sRecipes(i).recipeIndex_ViewingAngle = m_SequenceInfo.nCounterViewingAngle
                    m_SequenceInfo.nCounterViewingAngle += 1
                Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                    m_SequenceInfo.sRecipes(i).recipeIndex_LifetimeAndIVL = m_SequenceInfo.nCounterLifetimeAndIVL
                    m_SequenceInfo.nCounterLifetimeAndIVL += 1
                Case ucSequenceBuilder.eRcpMode.eCell_Aging
                    m_SequenceInfo.sRecipes(i).recipeindex_Aging = m_SequenceInfo.nCounterAging
                    m_SequenceInfo.nCounterAging += 1
            End Select

            m_SequenceInfo.nCounter += 1
        Next

        m_testRecipes = m_SequenceInfo.sRecipes.Clone
        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
        Return True
    End Function

    Public Function UpdateTestRecipe(ByVal selIndex As Integer, ByVal settings As ucSequenceBuilder.sRecipeInfo) As Boolean
        'ReDim Preserve m_testRecipes(m_SequenceInfo.nCounter - 1)

        'For idx As Integer = 0 To m_SequenceInfo.nCounter - 1
        '    m_testRecipes(idx) = m_SequenceInfo.sRecipes(idx)
        'Next

        'm_testRecipes(selIndex) = settings
        If selIndex < 0 Then
            Return False
        End If
        m_SequenceInfo.sRecipes(selIndex) = settings ' = m_testRecipes.Clone
        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
        Return True
    End Function

    Public Sub ResetSequenceState()
        '  m_CurrentSeqIndex = 0
        m_SequenceInfo.nCurrentSeqIndex = 0
        m_SequenceInfo.nCurrentSeqIndex_IVL = 0
        m_SequenceInfo.nCurrentSeqIndex_LifeTime = 0
        m_SequenceInfo.nCurrentSeqIndex_ChangeTemp = 0
        m_SequenceInfo.nCurrentSeqIndex_PatternMeas = 0
        m_SequenceInfo.nCurrentSeqIndex_ViewingAngle = 0
        m_SequenceInfo.nCurrentSeqIndex_LifetimeAndIVL = 0
        m_SequenceInfo.nCurrentSeqIndex_Aging = 0

        m_CurrentChangeInterval = CTime.Convert_HoureToTimeValue(0)
        m_CurrentMeasInterval = CTime.Convert_HoureToTimeValue(0)
        m_CurrentMeasIntervalIdx = 0
        m_CurrentSeqIndex = 0
        m_CurrentSeqIndexChangeTemp = 0
        m_CurrentSeqIndexLifeTime = 0
        m_CurrentSeqIndexIVL = 0
        m_CurrentSeqIndexPatternMeas = 0
        m_CurrentSeqIndexViewAngle = 0
        m_CurrentSeqIndexLifetimeAndIVL = 0
        m_CurrentSeqIndexAging = 0

        m_LoopCounter = 0
        m_RequestedFirstTest = False
        m_fIsLastSequence = False

        recipeCounter = 0 'Recipe Loop Count 용 변수
        recipeCounter_LifeTime = 0
        recipeCounter_IVLSweep = 0
        recipeCounter_ChangeTemp = 0
        recipeCounter_PatternMeas = 0
        recipeCounter_ViewingAngle = 0
        recipeCounter_LifetimeAndIVL = 0
        recipeCounter_Aging = 0

        LoopCounter = 0 'Recipe 전체 Count 회수 체크용 변수 2013-03-19

    End Sub

    Public Sub ClearTestRecipe()
        m_testRecipes = Nothing
        m_fIsLastSequence = False
        m_SequenceInfo.sRecipes = Nothing
        m_SequenceInfo.nCounter = 0
        m_SequenceInfo.nCounterChangedTemp = 0
        m_SequenceInfo.nCounterLifeTime = 0
        m_SequenceInfo.nCounterIVL = 0
        m_SequenceInfo.nCounterPatternMeas = 0
        m_SequenceInfo.nCounterViewingAngle = 0
        m_SequenceInfo.nCounterLifetimeAndIVL = 0
        m_SequenceInfo.nCounterAging = 0

        m_SequenceInfo.nCurrentSeqIndex = 0
        m_SequenceInfo.nCurrentSeqIndex_IVL = 0
        m_SequenceInfo.nCurrentSeqIndex_LifeTime = 0
        m_SequenceInfo.nCurrentSeqIndex_ChangeTemp = 0
        m_SequenceInfo.nCurrentSeqIndex_PatternMeas = 0
        m_SequenceInfo.nCurrentSeqIndex_ViewingAngle = 0
        m_SequenceInfo.nCurrentSeqIndex_LifetimeAndIVL = 0
        m_SequenceInfo.nCurrentSeqIndex_Aging = 0

        m_NextMeasureTime = CTime.Convert_SecToTimeValue(0)
        RaiseEvent evChangedSequenceInfo(m_SequenceInfo)
    End Sub

    Public Function SaveTestSequence() As Boolean
        Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing

        If m_SequenceInfo.nCounter = 0 Then Return False

        If file.GetSaveFileName(CMcFile.eFileType._SEQ, fileInfo) = False Then Return False

        If SaveSequence(fileInfo.strPathAndFName) = False Then Return False

        Return True
    End Function

    Public Function SaveTestSequence(ByVal nCh As String) As Boolean   'LEX_20130729 (파라메터가 명확하게 정의되면 구현)
        If Directory.Exists(g_sPATH_SystemData_Sequence) = False Then
            Directory.CreateDirectory(g_sPATH_SystemData_Sequence)
        End If

        If File.Exists(g_sPATH_SystemData_Sequence & "Ch" & Format(nCh + 1, "000") & ".Seq") = True Then
            File.Delete(g_sPATH_SystemData_Sequence & "Ch" & Format(nCh + 1, "000") & ".Seq")
        End If

        If SaveSequence(g_sPATH_SystemData_Sequence & "Ch" & Format(nCh + 1, "000") & ".Seq") = False Then Return False
        Return True
    End Function

    Public Function SaveSequence(ByVal sPath As String) As Boolean    'LEX_20130729 (파라메터가 명확하게 정의되면 구현)

        Dim rcpSaver As New CRcpINI(sPath)   'sPath = Sequence 파일 저장 경로

        rcpSaver.SaveIniValue(CRcpINI.eSecID.eFileInfo, 0, CRcpINI.eKeyID.FileTitle, sFileTitle & "," & sVersion)
        '  hh()
        'Sample Info
        With m_SequenceInfo.sSampleInfos
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Type, .sampleType.ToString)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_ColorType, .sampleColor.nDefColor.ToString)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Color, .sampleColor.sampleColor.ToString)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Title, .sTitle)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Size, ConvertSampleSizeToString(.SampleSize))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_FF, .dFillFactor)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Comment, .sComment)
        End With

        'Sequence Common Settings
        With m_SequenceInfo.sCommon
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_PathAndName, .saveInfo.strPathAndFName)  'Report 파일 저장 경로
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_OnlyFName, .saveInfo.strOnlyFName)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_OnlyExt, .saveInfo.strOnlyExt)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_FPath, .saveInfo.strFPath)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_FNameAndExt, .saveInfo.strFNameAndExt)
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_Date, .saveInfo.strDate)

            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Default_Temp, CStr(.dDefaultTemp))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_ACFMode, CInt(.nACFMode))

            If .sSequenceEnd Is Nothing = True Then 'Seq End para
                rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_TestEndSetting, CStr(0))
            Else
                rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_TestEndSetting, CStr(.sSequenceEnd.Length))
                For n As Integer = 0 To .sSequenceEnd.Length - 1
                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_TestEndParam_TypeOfParam, n, .sSequenceEnd(n).nTypeOfParam.ToString)
                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_TestEndParam_Value, n, CStr(.sSequenceEnd(n).dValue))
                Next
            End If

            If .sLimits Is Nothing = True Then 'Limit Para
                rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LimitSetting, CStr(0))
            Else
                rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LimitSetting, CStr(.sLimits.Length))
                For n As Integer = 0 To .sLimits.Length - 1
                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_TypeOfParam, n, .sLimits(n).eTypeOfValue.ToString)
                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_MaxValue, n, CStr(.sLimits(n).LimitValue.dMax))
                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_MinValue, n, CStr(.sLimits(n).LimitValue.dMin))
                Next
            End If

            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveOpt_AccumulateTempChangeTime, CStr(.saveOptions.isAccumulateTempChangeTime))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveOpt_ContinuousDataSave, CStr(.saveOptions.bContinuousDataSave))

            '----------------------------------------------------------------------
        End With

        'Recipe Info 
        With m_SequenceInfo
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_TestRecipe, CStr(.nCounter))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LifeTimeMode, CStr(.nCounterLifeTime))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ChangeTemp, CStr(.nCounterChangedTemp))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_IVLSweep, CStr(.nCounterIVL))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ImageSweep, CStr(.nCounterImageSweep))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_GrayScasleSweep, CStr(.nCounterGrayScaleSweep))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_PatternMeas, CStr(.nCounterPatternMeas))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ViewingAngle, CStr(.nCounterViewingAngle))
            rcpSaver.SaveIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LifetimeAndIVL, CStr(.nCounterLifetimeAndIVL))

            For i As Integer = 0 To .nCounter - 1

                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMode, .sRecipes(i).nMode.ToString)

                Select Case .sRecipes(i).nMode

                    Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eChangeTemp_TargetTemp, CStr(.sRecipes(i).sChangeTemp.dTargetTemp))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eChangeTemp_StableTime, CStr(.sRecipes(i).sChangeTemp.StableTime.nSecound))

                    Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL
                        '1. IVLSweep Common infos
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Average, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nAverage))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.biasMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CycleDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dCycleDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_DelayState, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.DelayState.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLevel, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLevel))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasItem, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.measItem.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasureDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dMeasureDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_OffsetBias, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dOffsetBias))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepLine.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMethod, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepType, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepType.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ViewingAngle, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLimit, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLimit))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CurrentLimit, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dCurrentLimit))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LumiCorrection, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dLumiCorrection))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasInvert, .sRecipes(i).sIVLSweepInfo.sCommon.dBiasInvert)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ValueForFast, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.ValueforFast))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FastNormalMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.DetectorMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FastBiasMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.fastBiasMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LimitIsAnd, .sRecipes(i).sIVLSweepInfo.sCommon.LimitCompareAnd)

                        '2. Standard SweepParameter
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nPoint))
                                '    rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nLevel))

                            Next
                        End If

                        '220829 Update by JKY : RGB SweepParameter
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).nPoint))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Type, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).SweepType))
                                For m As Integer = 0 To 4
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_Type, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).PowerType))
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopV, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).dStopV))
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopC, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).dStopC))
                                Next
                            Next
                        End If

                        '3. UserSweepList
                        If .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepList.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Bias, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepList(n)))
                            Next
                        End If

                        'ColorList
                        '20150324_PSK
                        If .sRecipes(i).sIVLSweepInfo.sCommon.nColorList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nColorList.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.nColorList.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Color, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nColorList(n)))
                            Next
                        End If

                        '4. Measment Points
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If


                        'Panel 구동 SMU가 키슬리인지 SG인지 판단해서 설정 값 저장 시켜야 함._PSK
                        If .sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.ePanel_IVL And m_TestPanelDeviceSG = True Then
                            '    5. SG Sourcing Info  
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Counter_SignalLine, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.nLenSignal))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.nLenSignal - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Name, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).eSignal.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_SrcMode, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).eSrcMode.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VLow, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).dBias))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VHigh, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).dAmplitude))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Delay, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Delay))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Width, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Width))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Period, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Period))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Current, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.dCurrentLimit))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Temp, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.dTempLimit))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Average, n, CStr(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.nAverCount))
                            Next
                        Else
                            '5. Keithley Infos
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTime, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.IntegTime_Sec))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTimeIndex, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nIntegTimeIndex))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitCurrent, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitCurrent))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitVoltage, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitVoltage))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_CurrentRange, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex)

                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_keithley_MeasureDelay, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelay_Sec))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureDelayAuto, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelayAuto.ToString)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode.ToString))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_NumofMeasData, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.NumOfMeasData))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_VoltageRange, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex)

                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceDelay_Sec))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode.ToString))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_TerminalMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode.ToString))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_WireMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode.ToString))
                        End If


                        If .sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.ePanel_IVL Then
                            '6. SweepLine
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepLine.ToString))
                            '7. RGB
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Red, CStr(.sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dRed))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Green, CStr(.sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dGreen))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Blue, CStr(.sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dBlue))
                        End If



                    Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                        '1. IVLSweep Common infos
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Average, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nAverage))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.biasMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CycleDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dCycleDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_DelayState, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.DelayState.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLevel, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLevel))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasItem, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.measItem.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasureDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dMeasureDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_OffsetBias, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dOffsetBias))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepDelay, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepDelay))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepLine.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMethod, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMode, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepType, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sweepType.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ViewingAngle, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FirstSweep, .sRecipes(i).sIVLSweepInfo.sCommon.bFirstSweep.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLimit, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLimit))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CurrentLimit, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dCurrentLimit))

                        '5. Keithley Infos
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTime, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.IntegTime_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTimeIndex, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nIntegTimeIndex))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitCurrent, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitCurrent))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitVoltage, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitVoltage))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_CurrentRange, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_keithley_MeasureDelay, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelay_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureDelayAuto, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelayAuto.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_NumofMeasData, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.NumOfMeasData))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_VoltageRange, .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceDelay_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_TerminalMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_WireMode, CStr(.sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode.ToString))

                        '2. Standard SweepParameter
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nPoint))
                                '    rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nLevel))

                            Next
                        End If

                        '220829 Update by JKY : RGB SweepParameter
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).nPoint))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Type, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).SweepType))
                                For m As Integer = 0 To 4
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_Type, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).PowerType))
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopV, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).dStopV))
                                    rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopC, n, m, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter(n).setPowerValue(m).dStopC))
                                Next
                            Next
                        End If

                        '3. UserSweepList
                        If .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepList.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Bias, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.dSweepList(n)))
                            Next
                        End If

                        'ColorList
                        '20150324_PSK
                        If .sRecipes(i).sIVLSweepInfo.sCommon.nColorList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nColorList.Length))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.nColorList.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Color, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.nColorList(n)))
                            Next
                        End If

                        '4. Measment Points
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode, .sRecipes(i).sLifetimeInfo.sCommon.nMode.ToString)
                        '2. Ref PD Value Setting
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal, .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound))
                        '3. LifeTime End State
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        '4. Meausrement Interval
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval.dHour))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change.dHour))
                            Next
                        End If

                        '5. Lifetime End Condition
                        If .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).dValue))
                            Next
                        End If

                        '6. IVL Sweep Meas. Condition
                        If .sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestIVLSweepMeasSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestIVLSweepMeasSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestIVLSweepMeasParam_TypeOfParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestIVLSweepMeasParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas(n).dValue))
                            Next
                        End If

                        '7. Measment Points
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                        'Cell Sourcing Info
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting, .sRecipes(i).sLifetimeInfo.sCellInfos.Length)
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCellInfos.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnable)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).Mode.ToString)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dBias))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dAmplitude))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnableRevMode))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dDuty))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.bEnableDutyDivision))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dFrequency))
                        Next

                        'Added 20150305
                        'Measurement to Viewing Angle
                        '2. Standard SweepParameter
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType, CInt(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType))

                        If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).nPoint))
                                '    rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nLevel))
                            Next
                        End If

                        '3. UserSweepList
                        If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList(n)))
                            Next
                        End If

                    Case ucSequenceBuilder.eRcpMode.eCell_Lifetime

                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode, .sRecipes(i).sLifetimeInfo.sCommon.nMode.ToString)
                        '2. Ref PD Value Setting
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal, .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound))
                        '3. LifeTime End State
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현
                        '4. Meausrement Interval
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval.dHour))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change.dHour))
                            Next
                        End If
                        '5. Lifetime End Condition
                        If .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).dValue))
                            Next
                        End If

                        '6. Measment Points
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                        'Cell Sourcing Info
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting, .sRecipes(i).sLifetimeInfo.sCellInfos.Length)
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCellInfos.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnable)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).Mode.ToString)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dBias))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dAmplitude))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnableRevMode))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dDuty))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.bEnableDutyDivision))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dFrequency))
                        Next

                        'Integral WaveLength
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_IntegralWLCount, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWLCount)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL1_START, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_Start)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL1_STOP, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_End)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL2_START, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_Start)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL2_STOP, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_End)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL3_START, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_Start)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL3_STOP, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_End)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL4_START, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_Start)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL4_STOP, .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_End)

                        'Added 20150305
                        'Measurement to Viewing Angle
                        '2. Standard SweepParameter
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType, CInt(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType))

                        If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter(n).nPoint))
                                '    rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nLevel))
                            Next
                        End If

                        '3. UserSweepList
                        If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n, CStr(.sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList(n)))
                            Next
                        End If

                    Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime

                        'LifeTime Common
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode, .sRecipes(i).sLifetimeInfo.sCommon.nMode.ToString)

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal, .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound))

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval.dHour))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change.dHour))
                            Next
                        End If

                        If .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).dValue))
                            Next
                        End If

                        '6. Measment Points
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                        'Panel Sourcing Info
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Counter_SignalLine, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Name, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).eSignal.ToString))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_SrcMode, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).eSrcMode.ToString))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VLow, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).dBias))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VHigh, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).dAmplitude))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Delay, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Delay))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Width, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Width))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Period, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Period))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Current, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.dCurrentLimit))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Temp, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.dTempLimit))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Average, n, CStr(.sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.nAverCount))

                        Next


                    Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                        'LifeTime Common
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode, .sRecipes(i).sLifetimeInfo.sCommon.nMode.ToString)

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal, .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound))

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval.dHour))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change.dHour))
                            Next
                        End If

                        If .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).dValue))
                            Next
                        End If

                        '6. Measment Points
                        If .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                        'Module Sourcing Info
                        'PG Power
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n)))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay))
                        Next
                        'PG Image Infos
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage(n).sDelayTime))

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage(n).sDelayTime))
                        Next

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_ModelName, .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.modelName)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_Enable_ModelDownload, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.bEnableModelDownload))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_ACFImageIdx, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.nACFImageIdx))

                        'PG Gray Scale
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nWhite))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nRed))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nGreen))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nBlue))

                        'PG Register
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.ePattern.ToString))  'LEX
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg(n).sRegName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg(n).byCMD))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg(n).nLenOfValue))

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim sTemp As String = ""
                            For m As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg(n).byValue.Length - 1
                                sTemp = sTemp & "," & .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg(n).byValue(m).ToString
                            Next
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n, sTemp)
                        Next

                    Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep

                        '1. PG Image Sweep List
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_Counter_Image, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage))
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_IsSelected, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasItems(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_ImageName, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasItems(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_FilePath, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasItems(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_DelayTime, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasItems(n).sDelayTime))


                            '1-1. Measment Points
                            If .sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint Is Nothing Then
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, n, CStr(0))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.Y))
                            Else
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).MeasPoint.Length))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.Y))

                                Dim sXPos As String = ""
                                Dim sYPos As String = ""
                                Dim sColor As String = ""
                                For m As Integer = 0 To .sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).MeasPoint.Length - 1
                                    sXPos = sXPos & "," & CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).MeasPoint(m).X)
                                    sYPos = sYPos & "," & CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).MeasPoint(m).Y)
                                    sColor = sColor & "," & CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).MeasPoint(m).ptColor.ToArgb)
                                Next

                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, sXPos)
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, sYPos)
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, sColor)
                            End If
                        Next
                        '이미지 로드를 여기서 해야 하나? Lex_20130822

                        '2. PG Infos 'Module Sourcing Info
                        '2-1. PG Power
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n)))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay))
                        Next

                        '2-2. PG Image Infos(필요 없을 것 같음) _Lex_20130822
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage))
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.measImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.measImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.measImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.measImage(n).sDelayTime))

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sDelayTime))
                        Next

                        '2-3. PG Gray Scale
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nWhite))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nRed))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nGreen))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nBlue))

                        '2-4. PG Register
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.ePattern.ToString)) 'LEX
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg))
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg(n).sRegName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg(n).byCMD))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n, CStr(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg(n).nLenOfValue))

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim sTemp As String = ""
                            For m As Integer = 0 To .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg(n).byValue.Length - 1
                                sTemp = sTemp & "," & .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg(n).byValue(m).ToString
                            Next
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n, sTemp)
                        Next



                    Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
                        '1. Gray Scale Sweep infos
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_Mode, .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.nSweepMode.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_LenSweepValue, CStr(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.numOfData))
                        Dim sTempWhite As String = ""
                        Dim sTempRed As String = ""
                        Dim sTempGreen As String = ""
                        Dim sTempBlue As String = ""
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.numOfData - 1
                            sTempWhite = sTempWhite & "," & CStr(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nWhite)
                            sTempRed = sTempRed & "," & CStr(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nRed)
                            sTempGreen = sTempGreen & "," & CStr(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nGreen)
                            sTempBlue = sTempBlue & "," & CStr(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nBlue)
                        Next
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_White, sTempWhite)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Red, sTempRed)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Green, sTempGreen)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Blue, sTempBlue)

                        '2. PG Infos
                        '2-1. PG Power
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length))
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n)))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n, CStr(.sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay))
                        Next

                        '2-2. PG Image Infos(필요 없을 것 같음) _Lex_20130822
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage))
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.measImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.measImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.measImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.measImage(n).sDelayTime))

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).bIsSelected))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sImageName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sPathImageFile))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.SlideImage(n).sDelayTime))
                        Next

                        '2-3. PG Gray Scale
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nWhite))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nRed))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nGreen))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nBlue))

                        '2-4. PG Register
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.ePattern.ToString)) 'LEX
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg))
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg(n).sRegName))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg(n).byCMD))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg(n).nLenOfValue))

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim sTemp As String = ""
                            For m As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg(n).byValue.Length - 1
                                sTemp = sTemp & "," & .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg(n).byValue(m).ToString
                            Next
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n, sTemp)
                        Next

                        '3. Measment Points
                        If .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(0))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.Y))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint.Length))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.X))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.Y))
                            For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint(n).X))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n, CStr(.sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint(n).Y))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n, .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint(n).ptColor.ToArgb)
                            Next
                        End If

                    Case ucSequenceBuilder.eRcpMode.eViewingAngle
                        '///Viewing Angle Parameters
                        '1. Common Settings
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType, CInt(.sRecipes(i).sViewingAngleInfo.sCommon.sweepType))
                        'rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SrcDevice, CInt(.sRecipes(i).sViewingAngleInfo.sCommon.SourcingUnit))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_BiasMode, CInt(.sRecipes(i).sViewingAngleInfo.sCommon.nBiasMode))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_BiasValue, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.dBiasValue))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_LumiCorrection, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.dLumiCorrection))

                        '2. Sweep Region Settings
                        If .sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter.Length))
                            For n As Integer = 0 To .sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter(n).nSweepNumber))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter(n).dStart))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter(n).dStop))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter(n).dStep))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter(n).nPoint))
                                '    rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter(n).nLevel))
                            Next
                        End If

                        '3. UserSweepList
                        If .sRecipes(i).sViewingAngleInfo.sCommon.dSweepList Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.dSweepList.Length))
                            For n As Integer = 0 To .sRecipes(i).sViewingAngleInfo.sCommon.dSweepList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n, CStr(.sRecipes(i).sViewingAngleInfo.sCommon.dSweepList(n)))
                            Next
                        End If

                        '4.Keithley Settings
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_IntegTime, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.IntegTime_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_IntegTimeIndex, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nIntegTimeIndex))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_LimitCurrent, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitCurrent))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_LimitVoltage, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitVoltage))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_CurrentRange, .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nCurrentRangeIndex)

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_keithley_MeasureDelay, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelay_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_MeasureDelayAuto, .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelayAuto.ToString)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_MeasureMode, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_NumofMeasData, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.NumOfMeasData))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_VoltageRange, .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nVoltageRangeIndex)

                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_SourceDelay, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceDelay_Sec))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_SourceMode, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_TerminalMode, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.TerminalMode.ToString))
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_WireMode, CStr(.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.WireMode.ToString))

                        '5.M600 Settings
                        'Cell Sourcing Info
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting, .sRecipes(i).sViewingAngleInfo.sCellInfos.Length)
                        For n As Integer = 0 To .sRecipes(i).sViewingAngleInfo.sCellInfos.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n, .sRecipes(i).sViewingAngleInfo.sCellInfos(n).bEnable)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n, .sRecipes(i).sViewingAngleInfo.sCellInfos(n).Mode.ToString)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).dBias))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).dAmplitude))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).bEnableRevMode))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).Pulse.dDuty))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).Pulse.bEnableDutyDivision))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n, CStr(.sRecipes(i).sViewingAngleInfo.sCellInfos(n).Pulse.dFrequency))
                        Next

                    Case ucSequenceBuilder.eRcpMode.eCell_Aging

                        'Aging Common
                        '1. Aging Mode(Operation, Keeping)
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_Mode, .sRecipes(i).sLifetimeInfo.sCommon.nMode.ToString)
                        '2. Aging End State
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_EndBiasStatus, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현
                        '3. Aging End Condition
                        If .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing Then
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_Counter_TestEndSetting, CStr(0))
                        Else
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_Counter_TestEndSetting, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length))
                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_TestEndParam_TypeofParam, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).nTypeOfParam.ToString))
                                rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_TestEndParam_Value, n, CStr(.sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd(n).dValue))
                            Next
                        End If

                        'Cell Sourcing Info
                        rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting, .sRecipes(i).sLifetimeInfo.sCellInfos.Length)
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sCellInfos.Length - 1
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnable)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n, .sRecipes(i).sLifetimeInfo.sCellInfos(n).Mode.ToString)
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dBias))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).dAmplitude))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).bEnableRevMode))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dDuty))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.bEnableDutyDivision))
                            rcpSaver.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n, CStr(.sRecipes(i).sLifetimeInfo.sCellInfos(n).Pulse.dFrequency))
                        Next

                End Select
            Next
        End With

        Return True
    End Function

    Public Function LoadTestSequence() As Boolean

        Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        If file.GetLoadFileName(CMcFile.eFileType._SEQ, fileInfo) = False Then Return False
        If LoadSequence(fileInfo.strPathAndFName) = False Then Return False
        Return True
    End Function

    Public Function LoadTestSequence(ByVal nCh As String) As Boolean   ''LEX_20130729 (파라메터가 명확하게 정의되면 구현)
        Dim LoadFilePath As String = g_sPATH_SystemData_Sequence & "Ch" & Format(nCh + 1, "000") & ".Seq"

        If Directory.Exists(g_sPATH_SystemData_Sequence) = False Then
            Directory.CreateDirectory(g_sPATH_SystemData_Sequence)
            Return False
        End If

        If File.Exists(LoadFilePath) = False Then 'ini 데이터 호출
            Return False
        End If

        If LoadSequence(LoadFilePath) = False Then Return False
        Return True
    End Function

    Public Function LoadSequence(ByVal sPath As String) As Boolean   'LEX_20130729 (파라메터가 명확하게 정의되면 구현)
        Dim sTemp As String
        Dim arrBuf As Array
        'Dim commonSettings As ucControlPannel.sCommonInfos
        'Dim measSetting() As ucMeasureIntervalSetting.sSetTime  '측정 설정 Measure Interval, Change Time
        'Dim endCondition() As ucTestEndParam.sTestEndParam   '종료 조건 설정
        'Dim testRcp() As ucControlPannel.sTestRecipe
        'Dim nCntTotalTestRcp As Integer
        'Dim nCntLifeTimeRcp As Integer
        'Dim nCntTempRcp As Integer
        Dim nCnt As Integer

        'Dim SequenceEndPara() As ucTestEndParam.sTestEndParam '2013-03-28 Sequence 종료 조건
        'Dim LimitValue() As ucLimitSetting.sLimitSetting '2013-03-28 제한 조건

        Dim rcpLoader As New CRcpINI(sPath)

        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eFileInfo, 0, CRcpINI.eKeyID.FileTitle)

        arrBuf = Split(sTemp, ",", -1)

        If arrBuf(0) <> sFileTitle Then Return False
        If arrBuf(1) <> sVersion Then Return False

        'Sample Info
        With m_SequenceInfo.sSampleInfos
            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Type)
            Select Case sTemp
                Case ucSampleInfos.eSampleType.eCell.ToString
                    .sampleType = ucSampleInfos.eSampleType.eCell
                Case ucSampleInfos.eSampleType.ePanel.ToString
                    .sampleType = ucSampleInfos.eSampleType.ePanel
                Case ucSampleInfos.eSampleType.eModule.ToString
                    .sampleType = ucSampleInfos.eSampleType.eModule
            End Select
            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_ColorType)
            .sampleColor.nDefColor = ConvertStringToSampleColorType(sTemp)
            .sampleColor.sampleColor = Color.FromName(rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Color))
            .sTitle = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Title)
            .SampleSize = ConvertStringToSampleSize(rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Size))
            .dFillFactor = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_FF))
            .sComment = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SampleInfo_Comment)
        End With

        'Sequence Common Settings
        With m_SequenceInfo.sCommon
            .saveInfo.strPathAndFName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_PathAndName)  'Report 파일 저장 경로
            .saveInfo.strOnlyFName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_OnlyFName)
            .saveInfo.strOnlyExt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_OnlyExt)
            .saveInfo.strFPath = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_FPath)
            .saveInfo.strFNameAndExt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_FNameAndExt)
            .saveInfo.strDate = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveInfo_Date)

            .dDefaultTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Default_Temp)

            Try
                .nACFMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_ACFMode)
            Catch ex As Exception
                .nACFMode = frmOptionWindow.eACFMode.eDisable_FixedPosition
            End Try


            Try
                nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_TestEndSetting)
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt > 0 Then
                Dim sSequenceEnd(nCnt - 1) As ucTestEndParam.sTestEndParam
                For n As Integer = 0 To nCnt - 1
                    sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_TestEndParam_TypeOfParam, n)
                    sSequenceEnd(n).nTypeOfParam = ucTestEndParam.ConvertEnumEndParamStringToInt(sTemp)
                    sSequenceEnd(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_TestEndParam_Value, n))
                Next
                .sSequenceEnd = sSequenceEnd.Clone
            Else
                .sSequenceEnd = Nothing
            End If


            Try
                nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LimitSetting))
            Catch ex As Exception
                nCnt = 0
            End Try

            If nCnt > 0 Then
                Dim sLimits(nCnt - 1) As ucLimitSetting.sLimitSetting
                For n As Integer = 0 To nCnt - 1
                    sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_TypeOfParam, n)
                    Select Case sTemp
                        Case ucLimitSetting.eLimitValueType.eVoltage.ToString
                            sLimits(n).eTypeOfValue = ucLimitSetting.eLimitValueType.eVoltage
                        Case ucLimitSetting.eLimitValueType.eCurrent.ToString
                            sLimits(n).eTypeOfValue = ucLimitSetting.eLimitValueType.eCurrent
                    End Select
                    sLimits(n).LimitValue.dMax = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_MaxValue, n)
                    sLimits(n).LimitValue.dMin = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Limit_MinValue, n)
                Next
                .sLimits = sLimits.Clone
            Else
                .sLimits = Nothing
            End If


            .saveOptions.isAccumulateTempChangeTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveOpt_AccumulateTempChangeTime)
            .saveOptions.bContinuousDataSave = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_SaveOpt_ContinuousDataSave)

            '----------------------------------------------------------------------
        End With


        'Recipe Info 
        With m_SequenceInfo

            .nCounter = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_TestRecipe)
            .nCounterLifeTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LifeTimeMode)
            .nCounterChangedTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ChangeTemp)
            .nCounterIVL = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_IVLSweep)
            .nCounterImageSweep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ImageSweep)
            .nCounterGrayScaleSweep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_GrayScasleSweep)

            Try
                .nCounterPatternMeas = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_PatternMeas)
                .nCounterViewingAngle = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_ViewingAngle)
                .nCounterLifetimeAndIVL = rcpLoader.LoadIniValue(CRcpINI.eSecID.eCommonSettings, 0, CRcpINI.eKeyID.SeqCommon_Counter_LifetimeAndIVL)
            Catch ex As Exception
                .nCounterPatternMeas = 0
                .nCounterViewingAngle = 0
                .nCounterLifetimeAndIVL = 0
            End Try

            ReDim m_SequenceInfo.sRecipes(.nCounter - 1)

            For i As Integer = 0 To .nCounter - 1
                sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMode)
                .sRecipes(i).nMode = ConvertRecipeModeStringToInt(sTemp)
                .sRecipes(i).recipeIndex = i

                Select Case .sRecipes(i).nMode
                    Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                        .sRecipes(i).sChangeTemp.dTargetTemp = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eChangeTemp_TargetTemp))
                        .sRecipes(i).sChangeTemp.StableTime = CTime.Convert_SecToTimeValue(CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eChangeTemp_StableTime)))
                        .sRecipes(i).recipeIndex_ChangeTemp = i
                    Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL
                        .sRecipes(i).recipeIndex_IVL = i
                        .sRecipes(i).sIVLSweepInfo.nMyMode = .sRecipes(i).nMode

                        '1. IVLSweep Common infos
                        .sRecipes(i).sIVLSweepInfo.sCommon.nAverage = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Average))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasMode)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eBiasMode.eCC.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.biasMode = ucDispRcpIVLSweep.eBiasMode.eCC
                            Case ucDispRcpIVLSweep.eBiasMode.eCV.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.biasMode = ucDispRcpIVLSweep.eBiasMode.eCV
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dCycleDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CycleDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_DelayState)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eOutputState.eOFF.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DelayState = ucDispRcpIVLSweep.eOutputState.eOFF
                            Case ucDispRcpIVLSweep.eOutputState.eON.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DelayState = ucDispRcpIVLSweep.eOutputState.eON
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLevel = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLevel))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLimit = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLimit))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dCurrentLimit = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CurrentLimit))
                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.dLumiCorrection = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LumiCorrection))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.dLumiCorrection = 100
                        End Try

                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.dBiasInvert = CBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasInvert))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.dBiasInvert = False
                        End Try

                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.LimitCompareAnd = CBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LimitIsAnd))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.LimitCompareAnd = False
                        End Try

                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.ValueforFast = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ValueForFast))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.ValueforFast = 0
                        End Try

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FastNormalMode)

                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eDetectorMode.eNormal.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eNormal
                            Case ucDispRcpIVLSweep.eDetectorMode.eFast.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eFast
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FastBiasMode)

                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eBiasMode.eCC.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.fastBiasMode = ucDispRcpIVLSweep.eBiasMode.eCC
                            Case ucDispRcpIVLSweep.eBiasMode.eCV.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.fastBiasMode = ucDispRcpIVLSweep.eBiasMode.eCV
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasItem)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eMeasureItems.eIV.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIV
                            Case ucDispRcpIVLSweep.eMeasureItems.eIVL.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dMeasureDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasureDelay))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dOffsetBias = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_OffsetBias))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dSweepDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepLine.eELVSS.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVDD
                            Case ucDispRcpIVLSweep.eSweepLine.eELVDD.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVSS
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMethod)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepMethod.eStair.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.eStair
                            Case ucDispRcpIVLSweep.eSweepMethod.ePulse.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse
                            Case ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMode)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepMode.eSingle.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMode = ucDispRcpIVLSweep.eSweepMode.eSingle
                            Case ucDispRcpIVLSweep.eSweepMode.eCycle.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMode = ucDispRcpIVLSweep.eSweepMode.eCycle
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepType)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepType.eStandard.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard
                            Case ucDispRcpIVLSweep.eSweepType.eUserPattern.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern
                            Case ucDispRcpIVLSweep.eSweepType.eRGBPattern.ToString '220826 Update by JKY
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern
                        End Select

                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ViewingAngle)
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle = 0
                        End Try

                        '2. Standard SweepParameter
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting)

                        ' 220829 Update by JKY
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then
                            Dim standardSweepSettings(nCnt - 1) As ucMeasureRGBSweepRegion.sSetSweepRegion

                            For n As Integer = 0 To nCnt - 1
                                ReDim standardSweepSettings(nCnt - 1).setPowerValue(4)
                                standardSweepSettings(n).nSweepNumber = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n))
                                standardSweepSettings(n).dStart = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n))
                                standardSweepSettings(n).dStop = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n))
                                standardSweepSettings(n).dStep = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n))
                                standardSweepSettings(n).nPoint = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n))
                                standardSweepSettings(n).SweepType = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Type, n))
                                For m As Integer = 0 To 4
                                    standardSweepSettings(n).setPowerValue(m).PowerType = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_Type, n, m))
                                    standardSweepSettings(n).setPowerValue(m).dStopV = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopV, n, m))
                                    standardSweepSettings(n).setPowerValue(m).dStopC = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopC, n, m))
                                    standardSweepSettings(n).setPowerValue(m).bIsUse = If(standardSweepSettings(n).setPowerValue(m).dStopV = 0, False, True)
                                Next
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter = standardSweepSettings.Clone
                        Else
                            Dim standardSweepSettings(nCnt - 1) As ucMeasureSweepRegion.sSetSweepRegion

                            For n As Integer = 0 To nCnt - 1
                                standardSweepSettings(n).nSweepNumber = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n))
                                standardSweepSettings(n).dStart = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n))
                                standardSweepSettings(n).dStop = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n))
                                standardSweepSettings(n).dStep = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n))
                                standardSweepSettings(n).nPoint = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n))
                                'Try
                                '    standardSweepSettings(n).nLevel = CDbl(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_SweepSetting_Level, n))

                                'Catch ex As Exception
                                '    standardSweepSettings(n).nLevel = 0

                                'End Try


                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter = standardSweepSettings.Clone

                        End If

                        If .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = CSeqProcessor.MakeSweepList(.sRecipes(i).sIVLSweepInfo.sCommon)
                        ElseIf .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then

                            '3. SweepList
                            nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList)
                            Dim dSweepList(nCnt - 1) As Double

                            For n As Integer = 0 To nCnt - 1
                                '  userSweepParameter.nNumber(n) = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number))
                                dSweepList(n) = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Bias, n))
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = dSweepList.Clone
                        Else '220829 Update by JKY
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = CSeqProcessor.MakeRGBSweepList(.sRecipes(i).sIVLSweepInfo.sCommon)
                        End If



                        'ColorList
                        '20150324_PSK
                        Try
                            nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList)
                            If nCnt > 0 Then
                                Dim colorList(nCnt - 1) As ucMeasureColorList.eColor

                                For n As Integer = 0 To nCnt - 1
                                    colorList(n) = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Color, n))
                                Next
                                .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = colorList.Clone
                            Else
                                .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = Nothing
                            End If
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = Nothing
                        End Try



                        '4. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If


                        'Panel 구동 SMU가 키슬리인지 SG인지 판단해서 설정 값 불러올 수 있게 시켜야 함(Keithley 동일하게 사용하고 Panel에서 구분 지어야 한다) _PSK
                        If .sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.ePanel_IVL And m_TestPanelDeviceSG = True Then
                            ' 5. SG Sourcing Info
                            .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.nLenSignal = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Counter_SignalLine)
                            Dim sgParam(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.nLenSignal - 1) As ucDispSignalGenerator.sSGParam
                            ReDim .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(.sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.nLenSignal - 1)

                            For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal - 1
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).eSignal = ucDispSignalGenerator.ConvertStringToPGSignal(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Name, n))
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).eSrcMode = ucDispSignalGenerator.ConvertStringToPGDACMode(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_SrcMode, n))
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VLow, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VHigh, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Delay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Delay, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Width = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Width, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sPulse.Period = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Period, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.dCurrentLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Current, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.dTempLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Temp, n)
                                .sRecipes(i).sIVLSweepInfo.sSignalGeneratorInfos.sParamData(n).sLimit.nAverCount = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Average, n)
                            Next

                        Else

                            '5. Keithley Infos
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.IntegTime_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTime))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nIntegTimeIndex = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTimeIndex))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitCurrent = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitCurrent))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitVoltage = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitVoltage))
                            Try
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_CurrentRange))
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_VoltageRange))
                            Catch ex As Exception
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = 0
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = 0
                            End Try

                            If .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = 0 Then
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.CurrentAutoRange = True
                            Else
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.CurrentAutoRange = False
                            End If

                            If .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = 0 Then
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.VoltageAutoRange = True
                            Else
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.VoltageAutoRange = False
                            End If

                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_keithley_MeasureDelay))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelayAuto = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureDelayAuto))

                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureMode)
                            Select Case sTemp
                                Case ucKeithleySMUSettings.eMeasValue.eCurrent.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eCurrent
                                Case ucKeithleySMUSettings.eMeasValue.eVoltage.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eVoltage
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eVoltage
                                Case ucKeithleySMUSettings.eMeasValue.ePower.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.ePower
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.ePower
                                Case ucKeithleySMUSettings.eMeasValue.eResistance.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eResistance
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eResistance
                            End Select

                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.NumOfMeasData = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_NumofMeasData))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay))

                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceMode)
                            Select Case sTemp
                                Case ucKeithleySMUSettings.eSMUMode.eCurrent.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent
                                Case ucKeithleySMUSettings.eSMUMode.eVoltage.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage
                            End Select


                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_TerminalMode)
                            Select Case sTemp
                                Case ucKeithleySMUSettings.eTerminalMode.eRear.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                                Case ucKeithleySMUSettings.eTerminalMode.eFront.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eFront
                            End Select


                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_WireMode)
                            Select Case sTemp
                                Case ucKeithleySMUSettings.eProve.e2Prove.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e2Prove
                                Case ucKeithleySMUSettings.eProve.e4Prove.ToString
                                    .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e4Prove
                            End Select
                        End If

                        If .sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.ePanel_IVL Then
                            '6. SweepLine
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine)
                            Select Case sTemp
                                Case ucDispRcpIVLSweep.eSweepLine.eELVSS.ToString
                                    .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVSS
                                Case ucDispRcpIVLSweep.eSweepLine.eELVDD.ToString
                                    .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVDD
                            End Select

                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay))

                            '7. RGB
                            .sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dRed = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Red))
                            .sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dGreen = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Green))
                            .sRecipes(i).sIVLSweepInfo.sRGBSignalInfos.dBlue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLRGBSignal_Blue))
                        End If


                    Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                        .sRecipes(i).recipeIndex_LifetimeAndIVL = i
                        .sRecipes(i).sIVLSweepInfo.nMyMode = .sRecipes(i).nMode
                        .sRecipes(i).sLifetimeInfo.nMyMode = .sRecipes(i).nMode

                        'IVL
                        '1. IVLSweep Common infos
                        .sRecipes(i).sIVLSweepInfo.sCommon.nAverage = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Average))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_BiasMode)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eBiasMode.eCC.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.biasMode = ucDispRcpIVLSweep.eBiasMode.eCC
                            Case ucDispRcpIVLSweep.eBiasMode.eCV.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.biasMode = ucDispRcpIVLSweep.eBiasMode.eCV
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dCycleDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_CycleDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_DelayState)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eOutputState.eOFF.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DelayState = ucDispRcpIVLSweep.eOutputState.eOFF
                            Case ucDispRcpIVLSweep.eOutputState.eON.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.DelayState = ucDispRcpIVLSweep.eOutputState.eON
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLevel = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLevel))

                        .sRecipes(i).sIVLSweepInfo.sCommon.dLMeasLimit = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LMeasLimit))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dCurrentLimit = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_LumiCorrection))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasItem)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eMeasureItems.eIV.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIV
                            Case ucDispRcpIVLSweep.eMeasureItems.eIVL.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sCommon.dMeasureDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_MeasureDelay))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dOffsetBias = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_OffsetBias))
                        .sRecipes(i).sIVLSweepInfo.sCommon.dSweepDelay = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepLine)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepLine.eELVSS.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVDD
                            Case ucDispRcpIVLSweep.eSweepLine.eELVDD.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepLine = ucDispRcpIVLSweep.eSweepLine.eELVSS
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMethod)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepMethod.eStair.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.eStair
                            Case ucDispRcpIVLSweep.eSweepMethod.ePulse.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse
                            Case ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepMode)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepMode.eSingle.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMode = ucDispRcpIVLSweep.eSweepMode.eSingle
                            Case ucDispRcpIVLSweep.eSweepMode.eCycle.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepMode = ucDispRcpIVLSweep.eSweepMode.eCycle
                        End Select

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepType)
                        Select Case sTemp
                            Case ucDispRcpIVLSweep.eSweepType.eStandard.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard
                            Case ucDispRcpIVLSweep.eSweepType.eUserPattern.ToString
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern
                            Case ucDispRcpIVLSweep.eSweepType.eRGBPattern.ToString '220826 Update by JKY
                                .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern
                        End Select

                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_ViewingAngle)
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.dViewingAngle = 0
                        End Try


                        Try
                            .sRecipes(i).sIVLSweepInfo.sCommon.bFirstSweep = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_FirstSweep))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.bFirstSweep = False
                        End Try

                        '2. Standard SweepParameter
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting)
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepSetting)

                        '220829 Update by JKY
                        If .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then
                            Dim standardSweepSettings(nCnt - 1) As ucMeasureRGBSweepRegion.sSetSweepRegion

                            For n As Integer = 0 To nCnt - 1
                                ReDim standardSweepSettings(nCnt - 1).setPowerValue(4)
                                standardSweepSettings(n).nSweepNumber = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n))
                                standardSweepSettings(n).dStart = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n))
                                standardSweepSettings(n).dStop = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n))
                                standardSweepSettings(n).dStep = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n))
                                standardSweepSettings(n).nPoint = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n))
                                standardSweepSettings(n).SweepType = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Type, n))
                                For m As Integer = 0 To 4
                                    standardSweepSettings(n).setPowerValue(m).PowerType = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_Type, n, m))
                                    standardSweepSettings(n).setPowerValue(m).dStopV = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopV, n, m))
                                    standardSweepSettings(n).setPowerValue(m).dStopC = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_PowerSetting_StopC, n, m))
                                    standardSweepSettings(n).setPowerValue(m).bIsUse = If(standardSweepSettings(n).setPowerValue(m).dStopV = 0, False, True)
                                Next
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureRGBSweepParameter = standardSweepSettings.Clone
                        Else
                            Dim standardSweepSettings(nCnt - 1) As ucMeasureSweepRegion.sSetSweepRegion

                            For n As Integer = 0 To nCnt - 1
                                standardSweepSettings(n).nSweepNumber = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Number, n))
                                standardSweepSettings(n).dStart = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Start, n))
                                standardSweepSettings(n).dStop = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Stop, n))
                                standardSweepSettings(n).dStep = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Step, n))
                                standardSweepSettings(n).nPoint = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepSetting_Point, n))
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasureSweepParameter = standardSweepSettings.Clone

                        End If

                        If .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = CSeqProcessor.MakeSweepList(.sRecipes(i).sIVLSweepInfo.sCommon)
                        ElseIf .sRecipes(i).sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then

                            '3. SweepList
                            nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_SweepList)
                            Dim dSweepList(nCnt - 1) As Double

                            For n As Integer = 0 To nCnt - 1
                                '  userSweepParameter.nNumber(n) = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number))
                                dSweepList(n) = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Bias, n))
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = dSweepList.Clone
                        Else '220829 Update by JKY
                            .sRecipes(i).sIVLSweepInfo.sCommon.dSweepList = CSeqProcessor.MakeRGBSweepList(.sRecipes(i).sIVLSweepInfo.sCommon)
                        End If

                        'ColorList
                        '20150324_PSK
                        Try
                            nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_Count_ColorList)
                            If nCnt > 0 Then
                                Dim colorList(nCnt - 1) As ucMeasureColorList.eColor

                                For n As Integer = 0 To nCnt - 1
                                    colorList(n) = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLCommon_SweepList_Color, n))
                                Next
                                .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = colorList.Clone
                            Else
                                .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = Nothing
                            End If
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sCommon.nColorList = Nothing
                        End Try

                        '4. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try
                            Next
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If

                        '5. Keithley Infos
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.IntegTime_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTime))
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nIntegTimeIndex = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTimeIndex))
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitCurrent = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitCurrent))
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.LimitVoltage = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitVoltage))
                        Try
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_CurrentRange))
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_VoltageRange))
                        Catch ex As Exception
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = 0
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = 0
                        End Try

                        If .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nCurrentRangeIndex = 0 Then
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.CurrentAutoRange = True
                        Else
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.CurrentAutoRange = False
                        End If

                        If .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.nVoltageRangeIndex = 0 Then
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.VoltageAutoRange = True
                        Else
                            .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.VoltageAutoRange = False
                        End If

                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_keithley_MeasureDelay))
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureDelayAuto = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureDelayAuto))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eMeasValue.eCurrent.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eCurrent
                            Case ucKeithleySMUSettings.eMeasValue.eVoltage.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eVoltage
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eVoltage
                            Case ucKeithleySMUSettings.eMeasValue.ePower.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.ePower
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.ePower
                            Case ucKeithleySMUSettings.eMeasValue.eResistance.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eResistance
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eResistance
                        End Select

                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.NumOfMeasData = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_NumofMeasData))
                        .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eSMUMode.eCurrent.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent
                            Case ucKeithleySMUSettings.eSMUMode.eVoltage.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage
                        End Select


                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_TerminalMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eTerminalMode.eRear.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                            Case ucKeithleySMUSettings.eTerminalMode.eFront.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eFront
                        End Select


                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_WireMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eProve.e2Prove.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e2Prove
                            Case ucKeithleySMUSettings.eProve.e4Prove.ToString
                                .sRecipes(i).sIVLSweepInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e4Prove
                        End Select


                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode)
                        .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.ConvertStrLifetimeModeToInt(sTemp)

                        '2. Ref PD Value Setting
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal)
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.ConvertStrRefPDModeToInt(sTemp)
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime = CTime.Convert_SecToTimeValue(CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime)))

                        '3. LifeTime End State
                        .sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        '4. Meausrement Interval
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting)
                        Dim measInterval(nCnt - 1) As ucMeasureIntervalSetting.sSetTime

                        ReDim .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(nCnt - 1)

                        For n As Integer = 0 To nCnt - 1
                            measInterval(n).Interval = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n))
                            measInterval(n).Change = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n))


                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval = measInterval(n).Interval
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change = measInterval(n).Change
                        Next

                        '5. Lifetime End Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting)
                        Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n)

                            sEndCondition(n).nTypeOfParam = ucTestEndParam.ConvertStrTestEndParamToInt(sTemp)

                            sEndCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd = sEndCondition.Clone

                        '6. IVL Sweep Meas. Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestIVLSweepMeasSetting)
                        Dim sIVLSweepMeasCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestIVLSweepMeasParam_TypeOfParam, n)

                            sIVLSweepMeasCondition(n).nTypeOfParam = ucTestEndParam.ConvertStrTestEndParamToInt(sTemp)

                            sIVLSweepMeasCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestIVLSweepMeasParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sIVLSweepMeas = sIVLSweepMeasCondition.Clone

                        '7. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try
                            Next
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If

                        'Cell Sourcing Info
                        Dim cellInfos() As ucDispCellLifetime.sSourceSetting
                        Dim LenSrcSetting As Integer
                        LenSrcSetting = frmBuilderSettings.ConvertToInteger(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting))
                        If LenSrcSetting > 0 Then
                            ReDim cellInfos(LenSrcSetting - 1)

                            For n As Integer = 0 To LenSrcSetting - 1
                                cellInfos(n).bEnable = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n))
                                sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n)
                                cellInfos(n).Mode = CDevM6000PLUS.ConvertStringModeToInt(sTemp)
                                cellInfos(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n)
                                cellInfos(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n)
                                cellInfos(n).bEnableRevMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n)
                                cellInfos(n).Pulse.dDuty = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n)
                                cellInfos(n).Pulse.bEnableDutyDivision = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n)
                                cellInfos(n).Pulse.dFrequency = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n)
                            Next
                            .sRecipes(i).sLifetimeInfo.sCellInfos = cellInfos.Clone
                        Else
                            cellInfos = Nothing
                            .sRecipes(i).sLifetimeInfo.sCellInfos = Nothing
                        End If

                        'Viewing Angle
                        Try
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType)

                            If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then

                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter = sweepParamters.Clone
                            ElseIf .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then '220829 Update by JKY
                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureRGBSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureRGBSweepParameter = sweepParamters.Clone
                            End If

                            '3. UserSweepList
                            Dim CntSweepList As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList)
                            Dim dBiasList(CntSweepList - 1) As Double

                            For n As Integer = 0 To dBiasList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                dBiasList(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n)
                            Next
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList = dBiasList.Clone

                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter = Nothing
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList = Nothing
                        End Try

                    Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                        .sRecipes(i).recipeIndex_LifeTime = i
                        .sRecipes(i).sLifetimeInfo.nMyMode = .sRecipes(i).nMode
                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode)
                        .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.ConvertStrLifetimeModeToInt(sTemp)

                        '2. Ref PD Value Setting
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal)
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.ConvertStrRefPDModeToInt(sTemp)
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime = CTime.Convert_SecToTimeValue(CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime)))

                        '3. LifeTime End State
                        .sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        '4. Meausrement Interval
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting)
                        Dim measInterval(nCnt - 1) As ucMeasureIntervalSetting.sSetTime

                        ReDim .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(nCnt - 1)

                        For n As Integer = 0 To nCnt - 1
                            measInterval(n).Interval = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n))
                            measInterval(n).Change = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n))


                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Interval = measInterval(n).Interval
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval(n).Change = measInterval(n).Change
                        Next
                        '5. Lifetime End Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting)
                        Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n)

                            sEndCondition(n).nTypeOfParam = ucTestEndParam.ConvertStrTestEndParamToInt(sTemp)

                            sEndCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd = sEndCondition.Clone

                        '6. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try
                            Next
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If

                        'Cell Sourcing Info
                        Dim cellInfos() As ucDispCellLifetime.sSourceSetting
                        Dim LenSrcSetting As Integer
                        LenSrcSetting = frmBuilderSettings.ConvertToInteger(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting))
                        If LenSrcSetting > 0 Then
                            ReDim cellInfos(LenSrcSetting - 1)

                            For n As Integer = 0 To LenSrcSetting - 1
                                cellInfos(n).bEnable = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n))
                                sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n)
                                cellInfos(n).Mode = CDevM6000PLUS.ConvertStringModeToInt(sTemp)
                                cellInfos(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n)
                                cellInfos(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n)
                                cellInfos(n).bEnableRevMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n)
                                cellInfos(n).Pulse.dDuty = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n)
                                cellInfos(n).Pulse.bEnableDutyDivision = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n)
                                cellInfos(n).Pulse.dFrequency = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n)
                            Next

                            .sRecipes(i).sLifetimeInfo.sCellInfos = cellInfos.Clone
                        Else
                            cellInfos = Nothing
                            .sRecipes(i).sLifetimeInfo.sCellInfos = Nothing
                        End If

                        'Integral WaveLength
                        Try

                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWLCount = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_IntegralWLCount)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_Start = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL1_START)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_End = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL1_STOP)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_Start = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL2_START)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_End = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL2_STOP)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_Start = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL3_START)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_End = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL3_STOP)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_Start = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL4_START)
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_End = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_WL4_STOP)
                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWLCount = 1
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_Start = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick1_End = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_Start = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick2_End = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_Start = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick3_End = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_Start = 380
                            .sRecipes(i).sLifetimeInfo.sCommon.nIntegralWL_Pick4_End = 380
                        End Try

                        'Viewing Angle
                        Try
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType)

                            If .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then

                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter = sweepParamters.Clone
                            ElseIf .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then '220829 Update by JKY
                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureRGBSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureRGBSweepParameter = sweepParamters.Clone
                            End If

                            '3. UserSweepList
                            Dim CntSweepList As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList)
                            Dim dBiasList(CntSweepList - 1) As Double

                            For n As Integer = 0 To dBiasList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                dBiasList(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n)
                            Next
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList = dBiasList.Clone

                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureSweepParameter = Nothing
                            .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.dSweepList = Nothing
                        End Try

                    Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                        .sRecipes(i).recipeIndex_LifeTime = i
                        .sRecipes(i).sLifetimeInfo.nMyMode = .sRecipes(i).nMode
                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode)
                        Select Case sTemp
                            Case ucDispRcpLifetime.eLifeTimeMode.Operation.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation
                            Case ucDispRcpLifetime.eLifeTimeMode.Keeping.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping
                        End Select
                        '2. Ref PD Value Setting
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal)
                        Select Case sTemp
                            Case ucRefPDSetting.eRefPDMode.OFF.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.OFF
                            Case ucRefPDSetting.eRefPDMode.Once.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.Once
                            Case ucRefPDSetting.eRefPDMode.ChangeRecipe.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe
                        End Select
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime = CTime.Convert_SecToTimeValue(CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime)))
                        '3. LifeTime End State
                        .sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus) '바이어스 계속 유지 여부 설정용 파라미터
                        '4. Meausrement Interval
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting)
                        Dim measInterval(nCnt - 1) As ucMeasureIntervalSetting.sSetTime
                        For n As Integer = 0 To nCnt - 1
                            measInterval(n).Interval = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n))
                            measInterval(n).Change = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval = measInterval.Clone
                        '5. Lifetime End Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting)
                        Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n)
                            Select Case sTemp
                                Case ucTestEndParam.eTestEndParam.eVolt.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eVolt
                                Case ucTestEndParam.eTestEndParam.eCurr.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eCurr
                                Case ucTestEndParam.eTestEndParam.eHightVolt.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHightVolt
                                Case ucTestEndParam.eTestEndParam.eHighCurrent.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHighCurrent
                                Case ucTestEndParam.eTestEndParam.ePDCurr.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.ePDCurr
                                Case ucTestEndParam.eTestEndParam.eLumi.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi
                                Case ucTestEndParam.eTestEndParam.eTime.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime
                                Case ucTestEndParam.eTestEndParam.eLumi_Delta.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi_Delta
                            End Select
                            sEndCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd = sEndCondition.Clone

                        '6. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try

                            Next
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If

                        'Panel Sourcing Info
                        .sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Counter_SignalLine)
                        Dim sgParam(.sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal - 1) As ucDispSignalGenerator.sSGParam
                        ReDim .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(.sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal - 1)

                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sPanelInfos.nLenSignal - 1
                            ' sgParam(n).eSignalName = ucDispSignalGenerator.ConvertStringToPGSignal(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.ePanel_Signal_Name, n))
                            'sgParam(n).eSrcMode = ucDispSignalGenerator.ConvertStringToPGDACMode(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.ePanel_Signal_SrcMode, n))
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).eSignal = ucDispSignalGenerator.ConvertStringToPGSignal(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Name, n))
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).eSrcMode = ucDispSignalGenerator.ConvertStringToPGDACMode(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_SrcMode, n))
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VLow, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_VHigh, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Delay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Delay, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Width = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Width, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sPulse.Period = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Pulse_Period, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.dCurrentLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Current, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.dTempLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Temp, n)
                            .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData(n).sLimit.nAverCount = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.ePanel_Signal_Limit_Average, n)
                        Next
                        ' .sRecipes(i).sLifetimeInfo.sPanelInfos.sParamData = sgParam.Clone '(n).eSignalName.ToString)    'What? 초기화해줌
                    Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                        .sRecipes(i).recipeIndex_LifeTime = i
                        .sRecipes(i).sLifetimeInfo.nMyMode = .sRecipes(i).nMode
                        'LifeTime Common
                        '1. Lifetime Mode(Operation, Keeping)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Mode)
                        Select Case sTemp
                            Case ucDispRcpLifetime.eLifeTimeMode.Operation.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation
                            Case ucDispRcpLifetime.eLifeTimeMode.Keeping.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping
                        End Select
                        '2. Ref PD Value Setting
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_EnableRenewal)
                        Select Case sTemp
                            Case ucRefPDSetting.eRefPDMode.OFF.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.OFF
                            Case ucRefPDSetting.eRefPDMode.Once.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.Once
                            Case ucRefPDSetting.eRefPDMode.ChangeRecipe.ToString
                                .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe
                        End Select
                        .sRecipes(i).sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime = CTime.Convert_SecToTimeValue(CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_RefPDSet_RenewalTime)))
                        '3. LifeTime End State
                        .sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_EndBiasStatus) '바이어스 계속 유지 여부 설정용 파라미터
                        '4. Meausrement Interval
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_MeasSetting)
                        Dim measInterval(nCnt - 1) As ucMeasureIntervalSetting.sSetTime
                        For n As Integer = 0 To nCnt - 1
                            measInterval(n).Interval = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_Interval, n))
                            measInterval(n).Change = CTime.Convert_HoureToTimeValue(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_MeasSetting_ChangeTime, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sMeasureInterval = measInterval.Clone
                        '5. Lifetime End Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_Counter_TestEndSetting)
                        Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_TypeOfParam, n)
                            Select Case sTemp
                                Case ucTestEndParam.eTestEndParam.eVolt.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eVolt
                                Case ucTestEndParam.eTestEndParam.eCurr.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eCurr
                                Case ucTestEndParam.eTestEndParam.eHightVolt.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHightVolt
                                Case ucTestEndParam.eTestEndParam.eHighCurrent.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHighCurrent
                                Case ucTestEndParam.eTestEndParam.ePDCurr.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.ePDCurr
                                Case ucTestEndParam.eTestEndParam.eLumi.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi
                                Case ucTestEndParam.eTestEndParam.eTime.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime
                                Case ucTestEndParam.eTestEndParam.eLumi_Delta.ToString
                                    sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi_Delta
                            End Select
                            sEndCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eLTCommon_TestEndParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd = sEndCondition.Clone

                        '6. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        If nCnt > 0 Then
                            Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                            For n As Integer = 0 To nCnt - 1
                                measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                                measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                                Try
                                    measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                                Catch ex As Exception
                                    measPoint(n).ptColor = Color.Black
                                End Try

                            Next
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = measPoint.Clone
                        Else
                            .sRecipes(i).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint = Nothing
                        End If

                        'Module Sourcing Info
                        'PG Power
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(nCnt - 1)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(nCnt - 1)
                        'Dim sPower(nCnt - 1) As ucDispPGPower.sPGPwrParam
                        For n As Integer = 0 To nCnt - 1
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n)
                        Next
                        ' .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower = sPower.Clone

                        'PG Image Infos
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image)
                        Dim measImage(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        Dim slideImage(.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem

                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            measImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n)
                            measImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n)
                            measImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n)
                            measImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n)

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            slideImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n)
                            slideImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n)
                            slideImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n)
                            slideImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n)
                        Next
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage = measImage.Clone
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage = slideImage.Clone

                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.modelName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_ModelName)
                        Try
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.bEnableModelDownload = CBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_Enable_ModelDownload))
                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.bEnableModelDownload = False
                        End Try

                        Try
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.nACFImageIdx = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GnT_ACFImageIdx))
                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.nACFImageIdx = 0
                        End Try


                        'PG Gray Scale
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nWhite = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White)
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nRed = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red)
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nGreen = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green)
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sGrayScale.nBlue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue)

                        'PG Register
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.ePattern = ConvertStringToMdlDefPattern(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern)) 'LEX
                        Try
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg)
                        Catch ex As Exception
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg = 0
                        End Try

                        Dim PGReg(.sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg - 1) As ucDispPGReg.sPGRegParam
                        For n As Integer = 0 To .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.numOfReg - 1
                            PGReg(n).sRegName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n)
                            PGReg(n).byCMD = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n)
                            PGReg(n).nLenOfValue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n)

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim byValue(PGReg(n).nLenOfValue - 1) As Byte
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n)
                            sTemp = sTemp.TrimStart(",")
                            arrBuf = Split(sTemp, ",", -1)
                            For m As Integer = 0 To arrBuf.Length - 1
                                byValue(m) = Convert.ToByte(CInt(arrBuf(m)))
                            Next
                            PGReg(n).byValue = byValue.Clone
                        Next
                        .sRecipes(i).sLifetimeInfo.sModuleInfos.sReg.sReg = PGReg.Clone

                    Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep
                        .sRecipes(i).recipeIndex_ImageSweep = i
                        '1. PG Image Sweep List
                        '.sRecipes(i).sImageSweepInfo.PGImageList.numOfImage = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eImageSweep_Counter_Image))
                        'Dim ImageSweepList(.sRecipes(i).sImageSweepInfo.PGImageList.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        'For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.PGImageList.numOfImage - 1
                        '    ImageSweepList(n).bIsSelected = rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eImageSweep_IsSelected, n)
                        '    ImageSweepList(n).sImageName = rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eImageSweep_ImageName, n)
                        '    ImageSweepList(n).sPathImageFile = rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eImageSweep_FilePath, n)
                        '    ImageSweepList(n).sDelayTime = rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eImageSweep_DelayTime, n)
                        'Next
                        '.sRecipes(i).sImageSweepInfo.PGImageList.measImage = ImageSweepList.Clone
                        '이미지 로드를 여기서 해야 하나? Lex_20130822


                        .sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_Counter_Image)
                        Dim ImageSweepList(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage - 1) As ucDispPGImageSweep.sImageListItem
                        Dim MeasPoint(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage - 1) As ucDispPointSetting.sMeasurePointInfos
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.ImageSweepInfo.numofImage - 1
                            ImageSweepList(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_IsSelected, n)
                            ImageSweepList(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_ImageName, n)
                            ImageSweepList(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_FilePath, n)
                            ImageSweepList(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eImageSweep_DelayTime, n)


                            '1-1. Measment Points
                            If .sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint Is Nothing Then
                                rcpLoader.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, n, CStr(0))
                                rcpLoader.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.X))
                                rcpLoader.SaveIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, n, CStr(.sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint(n).marginFromAlignMark.Y))
                            Else

                                nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter, n)
                                MeasPoint(n).marginFromAlignMark.X = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X, n)
                                MeasPoint(n).marginFromAlignMark.Y = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y, n)

                                Dim points(nCnt - 1) As ucDispPointSetting.sPoint
                                Dim sXPos As String = ""
                                Dim sYPos As String = ""
                                Dim sColor As String = ""

                                sXPos = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n)
                                sYPos = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n)
                                sColor = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n)

                                sXPos = sXPos.TrimStart(",")
                                sYPos = sYPos.TrimStart(",")
                                sColor = sColor.TrimStart(",")

                                arrBuf = Split(sXPos, ",", -1)
                                For m As Integer = 0 To arrBuf.Length - 1
                                    points(m).X = arrBuf(m)
                                Next

                                arrBuf = Split(sYPos, ",", -1)
                                For m As Integer = 0 To arrBuf.Length - 1
                                    points(m).Y = arrBuf(m)
                                Next

                                arrBuf = Split(sColor, ",", -1)
                                For m As Integer = 0 To arrBuf.Length - 1
                                    points(m).ptColor = Color.FromArgb(arrBuf(m))
                                Next

                                MeasPoint(n).MeasPoint = points.Clone

                            End If
                        Next

                        .sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasItems = ImageSweepList.Clone
                        .sRecipes(i).sImageSweepInfo.ImageSweepInfo.MeasPoint = MeasPoint.Clone

                        '2. PG Infos 'Module Sourcing Info
                        '2-1. PG Power
                        'PG Power
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(nCnt - 1)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(nCnt - 1)
                        'Dim sPower(nCnt - 1) As ucDispPGPower.sPGPwrParam
                        For n As Integer = 0 To nCnt - 1
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n)
                        Next

                        '2-2. PG Image Infos(필요 없을 것 같음) _Lex_20130822
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image)
                        Dim measImage(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        Dim slideImage(.sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            measImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n)
                            measImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n)
                            measImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n)
                            measImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n)

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            slideImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n)
                            slideImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n)
                            slideImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n)
                            slideImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n)
                        Next
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.measImage = measImage.Clone
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sImageInfos.SlideImage = slideImage.Clone
                        '2-3. PG Gray Scale
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nWhite = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White)
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nRed = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red)
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nGreen = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green)
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sGrayScale.nBlue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue)

                        '2-4. PG Register
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.ePattern = ConvertStringToMdlDefPattern(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern)) 'LEX

                        Try
                            .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg)
                        Catch ex As Exception
                            .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg = 0
                        End Try

                        Dim sPGReg(.sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg - 1) As ucDispPGReg.sPGRegParam
                        For n As Integer = 0 To .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.numOfReg - 1
                            sPGReg(n).sRegName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n)
                            sPGReg(n).byCMD = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n)
                            sPGReg(n).nLenOfValue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n)

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim byValue(sPGReg(n).nLenOfValue - 1) As Byte
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n)
                            sTemp = sTemp.TrimStart(",")
                            arrBuf = Split(sTemp, ",", -1)
                            For m As Integer = 0 To arrBuf.Length - 1
                                byValue(m) = Convert.ToByte(CInt(arrBuf(m)))
                            Next
                            sPGReg(n).byValue = byValue.Clone
                        Next
                        .sRecipes(i).sImageSweepInfo.sModuleInfos.sReg.sReg = sPGReg.Clone

                        '3. Measment Points
                        'nCnt = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eMeasPos_Counter))
                        'Dim measPoint(nCnt - 1) As System.Drawing.Point
                        '.sRecipes(i).sImageSweepInfo.sMeasPoints.marginFromAlignMark.X = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eMeasPos_Margin_X))
                        '.sRecipes(i).sImageSweepInfo.sMeasPoints.marginFromAlignMark.Y = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eMeasPos_Margin_Y))
                        'For n As Integer = 0 To nCnt - 1
                        '    measPoint(n).X = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eMeasPos_X, n))
                        '    measPoint(n).Y = CInt(rcpLoader.LoadIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eMeasPos_Y, n))
                        'Next
                        '.sRecipes(i).sImageSweepInfo.sMeasPoints.MeasPoint = measPoint.Clone

                    Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep

                        .sRecipes(i).recipeIndex_GrayScaleSweep = i

                        '1. Gray Scale Sweep infos

                        .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.nSweepMode = ucDispRcpGrayScaleSweep.ConvertStringToGrayScaleMode(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_Mode))
                        .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.numOfData = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_LenSweepValue)
                        Dim sweepValue(.sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.numOfData - 1) As ucDispPGGrayScale.sPGGrayScale

                        Dim arrWhite As Array = Nothing
                        Dim arrRed As Array = Nothing
                        Dim arrGreen As Array = Nothing
                        Dim arrBlue As Array = Nothing
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_White)
                        sTemp = sTemp.TrimStart(",")
                        arrWhite = Split(sTemp, ",", -1)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Red)
                        sTemp = sTemp.TrimStart(",")
                        arrRed = Split(sTemp, ",", -1)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Green)
                        sTemp = sTemp.TrimStart(",")
                        arrGreen = Split(sTemp, ",", -1)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eGrayScaleSweep_SweepValue_Blue)
                        sTemp = sTemp.TrimStart(",")
                        arrBlue = Split(sTemp, ",", -1)
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.numOfData - 1
                            .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nWhite = arrWhite(n)
                            .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nRed = arrRed(n)
                            .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nGreen = arrGreen(n)
                            .sRecipes(i).sGrayScaleSweepInfo.sSweepInfos.sweepValues(n).nBlue = arrBlue(n)
                        Next


                        '2. PG Infos
                        '2-1. PG Power
                        'PG Power
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_PwrLine)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(nCnt - 1)
                        ReDim .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(nCnt - 1)
                        'Dim sPower(nCnt - 1) As ucDispPGPower.sPGPwrParam
                        For n As Integer = 0 To nCnt - 1
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.nPwrNO(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Ch, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dVoltage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_Volt, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dCurrentLimit = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_CurrentLimit, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dONDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_ONDelay, n)
                            .sRecipes(i).sLifetimeInfo.sModuleInfos.sPwr.sPower(n).dOFFDelay = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Pwr_OFFDelay, n)
                        Next
                        ' .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sPwr.sPower = sPower.Clone

                        '2-2. PG Image Infos(필요 없을 것 같음) _Lex_20130822
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Image)
                        Dim measImage(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        Dim slideImage(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1) As ucDispPGImageSweep.sImageListItem
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.numOfImage - 1
                            measImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_IsSelected, n)
                            measImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_ImageName, n)
                            measImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_FilePath, n)
                            measImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_MeasImage_DelayTime, n)

                            '이미지 로드를 여기서 해야 하나? Lex_20130821
                            slideImage(n).bIsSelected = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_IsSelected, n)
                            slideImage(n).sImageName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_ImageName, n)
                            slideImage(n).sPathImageFile = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_FilePath, n)
                            slideImage(n).sDelayTime = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_SlideImage_DelayTime, n)
                        Next
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.measImage = measImage.Clone
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sImageInfos.SlideImage = slideImage.Clone

                        '2-3. PG Gray Scale
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nWhite = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_White)
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nRed = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Red)
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nGreen = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Green)
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sGrayScale.nBlue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_GrayScale_Blue)

                        '2-4. PG Register
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.ePattern = ConvertStringToMdlDefPattern(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Def_Pattern)) 'LEX
                        Try
                            .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Counter_Reg)
                        Catch ex As Exception
                            .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg = 0
                        End Try

                        Dim sPGReg(.sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg - 1) As ucDispPGReg.sPGRegParam
                        For n As Integer = 0 To .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.numOfReg - 1
                            sPGReg(n).sRegName = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Name, n)
                            sPGReg(n).byCMD = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_CMD, n)
                            sPGReg(n).nLenOfValue = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_LenOfValue, n)

                            'Byte를 스트링으로 변환하여 저장하고, 읽은 다음 다시 바이트로 변환하여 저장해야함. Lex_20130821
                            Dim byValue(sPGReg(n).nLenOfValue - 1) As Byte
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eModule_Reg_Value, n)
                            sTemp = sTemp.TrimStart(",")
                            arrBuf = Split(sTemp, ",", -1)
                            For m As Integer = 0 To arrBuf.Length - 1
                                byValue(m) = Convert.ToByte(CInt(arrBuf(m)))
                            Next
                            sPGReg(n).byValue = byValue.Clone
                        Next
                        .sRecipes(i).sGrayScaleSweepInfo.sModuleInfos.sReg.sReg = sPGReg.Clone

                        '3. Measment Points
                        nCnt = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Counter))
                        Dim measPoint(nCnt - 1) As ucDispPointSetting.sPoint
                        .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_X))
                        .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.marginFromAlignMark.Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Margin_Y))
                        For n As Integer = 0 To nCnt - 1
                            measPoint(n).X = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_X, n))
                            measPoint(n).Y = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPos_Y, n))
                            measPoint(n).ptColor = Color.FromArgb(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eMeasPtColor, n))
                        Next
                        .sRecipes(i).sGrayScaleSweepInfo.sMeasPoints.MeasPoint = measPoint.Clone
                    Case ucSequenceBuilder.eRcpMode.eViewingAngle

                        '///Viewing Angle Parameters
                        '1. Common Settings
                        Try
                            .sRecipes(i).sViewingAngleInfo.sCommon.sweepType = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SweepType))
                            '.sRecipes(i).sViewingAngleInfo.sCommon.SourcingUnit = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_SrcDevice))
                            .sRecipes(i).sViewingAngleInfo.sCommon.nBiasMode = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_BiasMode))
                            .sRecipes(i).sViewingAngleInfo.sCommon.dBiasValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_BiasValue))

                            Try
                                .sRecipes(i).sViewingAngleInfo.sCommon.dLumiCorrection = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Common_LumiCorrection))
                            Catch ex As Exception
                                .sRecipes(i).sViewingAngleInfo.sCommon.dLumiCorrection = 100
                            End Try


                            If .sRecipes(i).sViewingAngleInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard Then

                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter = sweepParamters.Clone
                            ElseIf .sRecipes(i).sViewingAngleInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then '220829 Update by JKY
                                Dim numOfRegions As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepSetting)
                                Dim sweepParamters(numOfRegions - 1) As ucMeasureRGBSweepRegion.sSetSweepRegion

                                For n As Integer = 0 To sweepParamters.Length - 1
                                    sweepParamters(n).nSweepNumber = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Number, n)
                                    sweepParamters(n).dStart = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Start, n)
                                    sweepParamters(n).dStop = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Stop, n)
                                    sweepParamters(n).dStep = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Step, n)
                                    sweepParamters(n).nPoint = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepSetting_Point, n)
                                Next

                                .sRecipes(i).sLifetimeInfo.sViewingAngleInfos.sMeasureRGBSweepParameter = sweepParamters.Clone
                            End If

                            '3. UserSweepList
                            Dim CntSweepList As Integer = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Count_SweepList)
                            Dim dBiasList(CntSweepList - 1) As Double

                            For n As Integer = 0 To dBiasList.Length - 1
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(.sRecipes(i).sIVLSweepInfo.sCommon.sMeasureUserSweepList.nNumber(n)))
                                '  rcpSaver.SaveIniValue(CRcp.eSecID.eRecipe, i, CRcp.eKeyID.eIVLCommon_UserSweepSetting_Number, n, CStr(n))
                                dBiasList(n) = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_SweepList_Bias, n)
                            Next
                            .sRecipes(i).sViewingAngleInfo.sCommon.dSweepList = dBiasList.Clone

                        Catch ex As Exception
                            .sRecipes(i).sViewingAngleInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eStandard
                            '.sRecipes(i).sViewingAngleInfo.sCommon.SourcingUnit = ucDispRcpViewingAngle.eSourcingUnit._IVLSMU
                            .sRecipes(i).sViewingAngleInfo.sCommon.nBiasMode = ucDispRcpIVLSweep.eBiasMode.eCC
                            .sRecipes(i).sViewingAngleInfo.sCommon.dBiasValue = 0
                            .sRecipes(i).sViewingAngleInfo.sCommon.sMeasureSweepParameter = Nothing
                            .sRecipes(i).sViewingAngleInfo.sCommon.dSweepList = Nothing
                        End Try

                        ''4.Keithley Settings

                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.IntegTime_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_IntegTime))
                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nIntegTimeIndex = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_IntegTimeIndex))
                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitCurrent = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_LimitCurrent))
                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitVoltage = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_LimitVoltage))
                        Try
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nCurrentRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_CurrentRange))
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nVoltageRangeIndex = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_VoltageRange))
                        Catch ex As Exception
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nCurrentRangeIndex = 0
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nVoltageRangeIndex = 0
                        End Try

                        If .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nCurrentRangeIndex = 0 Then
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.CurrentAutoRange = True
                        Else
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.CurrentAutoRange = False
                        End If

                        If .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.nVoltageRangeIndex = 0 Then
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.VoltageAutoRange = True
                        Else
                            .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.VoltageAutoRange = False
                        End If

                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_keithley_MeasureDelay))
                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelayAuto = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_MeasureDelayAuto))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_MeasureMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eMeasValue.eCurrent.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eCurrent
                            Case ucKeithleySMUSettings.eMeasValue.eVoltage.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eVoltage
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eVoltage
                            Case ucKeithleySMUSettings.eMeasValue.ePower.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.ePower
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.ePower
                            Case ucKeithleySMUSettings.eMeasValue.eResistance.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eResistance
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eResistance
                        End Select

                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.NumOfMeasData = CInt(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_NumofMeasData))
                        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceDelay_Sec = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_SourceDelay))

                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_SourceMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eSMUMode.eCurrent.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent
                            Case ucKeithleySMUSettings.eSMUMode.eVoltage.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage
                        End Select


                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_TerminalMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eTerminalMode.eRear.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                            Case ucKeithleySMUSettings.eTerminalMode.eFront.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eFront
                        End Select


                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eViewingAngle_Keithley_WireMode)
                        Select Case sTemp
                            Case ucKeithleySMUSettings.eProve.e2Prove.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e2Prove
                            Case ucKeithleySMUSettings.eProve.e4Prove.ToString
                                .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e4Prove
                        End Select
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.IntegTime_Sec = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_IntegTime)
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitCurrent = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitCurrent)
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.LimitVoltage = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_LimitVoltage)
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureAutoRange = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureAutoRange))
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelay_Sec = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_keithley_MeasureDelay)
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureDelayAuto = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureDelayAuto))
                        'sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_MeasureMode)
                        'Select Case sTemp
                        '    Case ucKeithleySMUSettings.eMeasValue.eCurrent.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eCurrent
                        '    Case ucKeithleySMUSettings.eMeasValue.eVoltage.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eVoltage
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eVoltage
                        '    Case ucKeithleySMUSettings.eMeasValue.ePower.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.ePower
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.ePower
                        '    Case ucKeithleySMUSettings.eMeasValue.eResistance.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureMode = ucKeithleySMUSettings.eMeasValue.eResistance
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eResistance
                        'End Select

                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.NumOfMeasData = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_NumofMeasData)
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceAutoRange = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceAutoRange))
                        '.sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceDelay_Sec = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceDelay)

                        'sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_SourceMode)
                        'Select Case sTemp
                        '    Case ucKeithleySMUSettings.eSMUMode.eCurrent.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent
                        '    Case ucKeithleySMUSettings.eSMUMode.eVoltage.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage
                        'End Select

                        'sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_TerminalMode)
                        'Select Case sTemp
                        '    Case ucKeithleySMUSettings.eTerminalMode.eRear.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                        '    Case ucKeithleySMUSettings.eTerminalMode.eFront.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eFront
                        'End Select

                        'sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eIVLDevice_Keithley_WireMode)
                        'Select Case sTemp
                        '    Case ucKeithleySMUSettings.eProve.e2Prove.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e2Prove
                        '    Case ucKeithleySMUSettings.eProve.e4Prove.ToString
                        '        .sRecipes(i).sViewingAngleInfo.sKeithleyInfos.WireMode = ucKeithleySMUSettings.eProve.e4Prove
                        'End Select

                        '5.M600 Settings
                        'Cell Sourcing Info
                        Dim cellInfos() As ucDispCellLifetime.sSourceSetting
                        Dim LenSrcSetting As Integer
                        LenSrcSetting = frmBuilderSettings.ConvertToInteger(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting))
                        If LenSrcSetting > 0 Then
                            ReDim cellInfos(LenSrcSetting - 1)
                            For n As Integer = 0 To LenSrcSetting - 1
                                cellInfos(n).bEnable = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n))
                                sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n)
                                cellInfos(n).Mode = CDevM6000PLUS.ConvertStringModeToInt(sTemp)
                                cellInfos(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n)
                                cellInfos(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n)
                                cellInfos(n).bEnableRevMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n)
                                cellInfos(n).Pulse.dDuty = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n)
                                cellInfos(n).Pulse.bEnableDutyDivision = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n)
                                cellInfos(n).Pulse.dFrequency = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n)
                            Next
                            .sRecipes(i).sViewingAngleInfo.sCellInfos = cellInfos.Clone
                        Else
                            cellInfos = Nothing
                            .sRecipes(i).sViewingAngleInfo.sCellInfos = Nothing
                        End If

                        'sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.Mode = CDevM6000.ConvertStringModeToInt(sTemp)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.bEnableRevMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.Pulse.dDuty = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.Pulse.bEnableDutyDivision = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision)
                        '.sRecipes(i).sViewingAngleInfo.sCellInfos.Pulse.dFrequency = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency)
                        '=====================

                    Case ucSequenceBuilder.eRcpMode.eCell_Aging
                        .sRecipes(i).recipeindex_Aging = i
                        .sRecipes(i).sLifetimeInfo.nMyMode = .sRecipes(i).nMode

                        '1. Aging Mode(Operation, Keeping)
                        sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_Mode)
                        .sRecipes(i).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.ConvertStrLifetimeModeToInt(sTemp)

                        '2. LifeTime End State
                        .sRecipes(i).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_EndBiasStatus) '바이어스 계속 유지 여부 설정용 파라미터 2013-03-28 승현

                        '3. Aging End Condition
                        nCnt = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_Counter_TestEndSetting)
                        Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                        For n As Integer = 0 To nCnt - 1
                            sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_TestEndParam_TypeofParam, n)

                            sEndCondition(n).nTypeOfParam = ucTestEndParam.ConvertStrTestEndParamToInt(sTemp)

                            sEndCondition(n).dValue = CDbl(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eAging_TestEndParam_Value, n))
                        Next
                        .sRecipes(i).sLifetimeInfo.sCommon.sLifetimeEnd = sEndCondition.Clone

                        'Cell Sourcing Info
                        Dim cellInfos() As ucDispCellLifetime.sSourceSetting
                        Dim LenSrcSetting As Integer
                        LenSrcSetting = frmBuilderSettings.ConvertToInteger(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Counter_M6000SrcSetting))
                        If LenSrcSetting > 0 Then
                            ReDim cellInfos(LenSrcSetting - 1)

                            For n As Integer = 0 To LenSrcSetting - 1
                                cellInfos(n).bEnable = ConvertStringToBool(rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.sCell_Enable_M6000SrcSetting, n))
                                sTemp = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Mode, n)
                                cellInfos(n).Mode = CDevM6000PLUS.ConvertStringModeToInt(sTemp)
                                cellInfos(n).dBias = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Bias, n)
                                cellInfos(n).dAmplitude = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Amplitude, n)
                                cellInfos(n).bEnableRevMode = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_EnableRevMode, n)
                                cellInfos(n).Pulse.dDuty = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Duty, n)
                                cellInfos(n).Pulse.bEnableDutyDivision = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_EnableDutyDivision, n)
                                cellInfos(n).Pulse.dFrequency = rcpLoader.LoadIniValue(CRcpINI.eSecID.eRecipe, i, CRcpINI.eKeyID.eCell_M6000SrcSetting_Pulse_Frequency, n)
                            Next
                            .sRecipes(i).sLifetimeInfo.sCellInfos = cellInfos.Clone
                        Else
                            cellInfos = Nothing
                            .sRecipes(i).sLifetimeInfo.sCellInfos = Nothing
                        End If

                End Select
            Next
        End With

        'RaiseEvent evChangedRecipes(m_SequenceInfo)


        ''UpdateList(m_testRecipe)
        Return True
    End Function


#End Region


#Region "Support Functions"

    Public Shared Function ConvertStringToMdlDefPattern(ByVal str As String) As ucMcPGControl.ePattern
        Select Case str
            Case ucMcPGControl.ePattern.eSingleColor.ToString
                Return ucMcPGControl.ePattern.eSingleColor
            Case ucMcPGControl.ePattern.e5by5Pattern.ToString
                Return ucMcPGControl.ePattern.e5by5Pattern
            Case ucMcPGControl.ePattern.e5by5Pattern_UserDefColor.ToString
                Return ucMcPGControl.ePattern.e5by5Pattern_UserDefColor
            Case ucMcPGControl.ePattern.eH_3ColorLine.ToString
                Return ucMcPGControl.ePattern.eH_3ColorLine
            Case ucMcPGControl.ePattern.eV_3ColorLine.ToString
                Return ucMcPGControl.ePattern.eV_3ColorLine
            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertRecipeModeStringToInt(ByVal str As String) As ucSequenceBuilder.eRcpMode
        Dim mode As ucSequenceBuilder.eRcpMode
        Select Case str
            Case ucSequenceBuilder.eRcpMode.eCell_IVL.ToString
                mode = ucSequenceBuilder.eRcpMode.eCell_IVL
            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime.ToString
                mode = ucSequenceBuilder.eRcpMode.eCell_Lifetime
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL.ToString
                mode = ucSequenceBuilder.eRcpMode.ePanel_IVL
            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime.ToString
                mode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime
            Case ucSequenceBuilder.eRcpMode.eModuel_IVL.ToString
                mode = ucSequenceBuilder.eRcpMode.eModuel_IVL
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime.ToString
                mode = ucSequenceBuilder.eRcpMode.eModule_Lifetime
            Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep.ToString
                mode = ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep
            Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep.ToString
                mode = ucSequenceBuilder.eRcpMode.eModule_ImageSweep
            Case ucSequenceBuilder.eRcpMode.eChangeTemperature.ToString
                mode = ucSequenceBuilder.eRcpMode.eChangeTemperature
            Case ucSequenceBuilder.eRcpMode.eViewingAngle.ToString
                mode = ucSequenceBuilder.eRcpMode.eViewingAngle
            Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL.ToString
                mode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
            Case ucSequenceBuilder.eRcpMode.eCell_Aging.ToString
                mode = ucSequenceBuilder.eRcpMode.eCell_Aging
            Case Else
                mode = -1
        End Select
        Return mode
    End Function

    Public Shared Function ConvertLifetimeModeStringToInt(ByVal str As String) As ucDispRcpLifetime.eLifeTimeMode
        Dim mode As ucDispRcpLifetime.eLifeTimeMode
        Select Case str
            Case ucDispRcpLifetime.eLifeTimeMode.Keeping.ToString
                mode = ucDispRcpLifetime.eLifeTimeMode.Keeping
            Case ucDispRcpLifetime.eLifeTimeMode.Operation.ToString
                mode = ucDispRcpLifetime.eLifeTimeMode.Operation
            Case Else
                mode = -1
        End Select
        Return mode
    End Function

    'Public Function ConvertSourcingModeStringToInt(ByVal str As String) As CDevM6000.eMode    'LEX_20130719
    '    Dim mode As CDevM6000.eMode
    '    Select Case str
    '        Case CDevM6000.eMode.eCC.ToString
    '            mode = CDevM6000.eMode.eCC
    '        Case CDevM6000.eMode.eCV.ToString
    '            mode = CDevM6000.eMode.eCV
    '        Case CDevM6000.eMode.ePC.ToString
    '            mode = CDevM6000.eMode.ePC
    '        Case CDevM6000.eMode.ePCV.ToString
    '            mode = CDevM6000.eMode.ePCV
    '        Case CDevM6000.eMode.ePV.ToString
    '            mode = CDevM6000.eMode.ePV
    '        Case Else
    '            mode = -1
    '    End Select
    '    Return mode
    'End Function

    Public Shared Function ConvertTestEndParamStringToInt(ByVal str As String) As ucTestEndParam.eTestEndParam
        Dim mode As ucTestEndParam.eTestEndParam
        Select Case str
            Case ucTestEndParam.eTestEndParam.eCurr.ToString
                mode = ucTestEndParam.eTestEndParam.eCurr
            Case ucTestEndParam.eTestEndParam.eLumi.ToString
                mode = ucTestEndParam.eTestEndParam.eLumi
            Case ucTestEndParam.eTestEndParam.ePDCurr.ToString
                mode = ucTestEndParam.eTestEndParam.ePDCurr
            Case ucTestEndParam.eTestEndParam.eTime.ToString
                mode = ucTestEndParam.eTestEndParam.eTime
            Case ucTestEndParam.eTestEndParam.eVolt.ToString
                mode = ucTestEndParam.eTestEndParam.eVolt
            Case ucTestEndParam.eTestEndParam.eLoopCount.ToString
                mode = ucTestEndParam.eTestEndParam.eLoopCount
            Case ucTestEndParam.eTestEndParam.eLumi_Delta.ToString
                mode = ucTestEndParam.eTestEndParam.eLumi_Delta
            Case Else
                mode = -1
        End Select
        Return mode
    End Function

    Public Shared Function ConvertLimitStringToInt(ByVal str As String) As ucLimitSetting.eLimitValueType
        Dim mode As ucLimitSetting.eLimitValueType
        Select Case str
            Case ucLimitSetting.eLimitValueType.eVoltage.ToString
                mode = ucLimitSetting.eLimitValueType.eVoltage
            Case ucLimitSetting.eLimitValueType.eCurrent.ToString
                mode = ucLimitSetting.eLimitValueType.eCurrent
            Case Else
                mode = -1
        End Select
        Return mode
    End Function

    'Public Shared Function ValueToArray(ByVal tempSettings As ucControlPannel.sTempParams) As String()
    '    Dim sTemp(2) As String
    '    '  Dim str As String
    '    'With tempSettings
    '    '    sTemp(0) = .dtargertTemp
    '    '    sTemp(1) = .sEndTime
    '    '    sTemp(2) = .sSettngTime
    '    'End With
    '    Return sTemp.Clone
    'End Function

    ' Public Shared Function ValueToArray(ByVal lifetimeSettings As ucSequenceBuilder.sRcpLifetime) As String()
    'Dim sTemp(9 + (lifetimeSettings.sMeasureInterval.Length * 2) - 1) As String
    'With lifetimeSettings
    '    sTemp(0) = .LifeTimeMode 'Continuous, Sweep
    '    sTemp(1) = .sSourceSetting.bEnableRevMode        'Sweep Mode
    '    sTemp(2) = .sSourceSetting.dAmplitude
    '    sTemp(3) = .sSourceSetting.dBias  'Frequency
    '    sTemp(4) = .sSourceSetting.Mode
    '    sTemp(5) = .sLuminanceSettings.bEnableRenewalMode.ToString
    '    sTemp(6) = .sLuminanceSettings.RenewalTime.nSecound
    '    sTemp(7) = .sSourceSetting.Pulse.bEnableDutyDivision
    '    sTemp(8) = .sSourceSetting.Pulse.dDuty
    '    sTemp(9) = .sSourceSetting.Pulse.dFrequency
    '    For i As Integer = 0 To lifetimeSettings.sMeasureInterval.Length - 1
    '        sTemp(10 + (i * 2)) = CStr(lifetimeSettings.sMeasureInterval(i).Interval.dHoure)
    '        sTemp(10 + ((i * 2) + 1)) = CStr(lifetimeSettings.sMeasureInterval(i).Change.dHoure)
    '    Next
    'End With
    '  Return sTemp.Clone

    '  End Function

    Private Shared Function ConvertSampleSizeToString(ByVal sampleSize As ucSampleInfos.sSampleSize) As String
        Dim sWidth As String
        Dim sHeight As String
        Dim sRst As String

        sWidth = "Width=" & CStr(sampleSize.Width)
        sHeight = "Height=" & CStr(sampleSize.Height)
        sRst = "{" & sWidth & "," & sHeight & "}"
        Return sRst
    End Function

    Private Shared Function ConvertStringToSampleSize(ByVal str As String) As ucSampleInfos.sSampleSize
        Dim arrTemp As Array
        Dim sWidth As String
        Dim sHeight As String
        Dim SizeValue As ucSampleInfos.sSampleSize
        str = str.TrimStart("{")
        str = str.TrimEnd("}")
        arrTemp = Split(str, ",", -1)
        sWidth = arrTemp(0)
        sHeight = arrTemp(1)
        arrTemp = Split(sWidth, "=", -1)
        sWidth = arrTemp(1)
        arrTemp = Split(sHeight, "=", -1)
        sHeight = arrTemp(1)
        SizeValue.Width = CDbl(sWidth)
        SizeValue.Height = CDbl(sHeight)
        Return SizeValue
    End Function


    Public Shared Function ConvertStringToSize(ByVal str As String) As System.Drawing.Size
        Dim arrTemp As Array
        Dim sWidth As String
        Dim sHeight As String
        Dim SizeValue As Size
        str = str.TrimStart("{")
        str = str.TrimEnd("}")
        arrTemp = Split(str, ",", -1)
        sWidth = arrTemp(0)
        sHeight = arrTemp(1)
        arrTemp = Split(sWidth, "=", -1)
        sWidth = arrTemp(1)
        arrTemp = Split(sHeight, "=", -1)
        sHeight = arrTemp(1)
        SizeValue = New System.Drawing.Size(CInt(sWidth), CInt(sHeight))
        Return SizeValue
    End Function

    Public Shared Function ConvertStringToPoint(ByVal str As String) As System.Drawing.Point
        Dim arrTemp As Array
        Dim sX As String
        Dim sY As String
        Dim PointValue As Point
        str = str.TrimStart("{")
        str = str.TrimEnd("}")
        arrTemp = Split(str, ",", -1)
        sX = arrTemp(0)
        sY = arrTemp(1)
        arrTemp = Split(sX, "=", -1)
        sX = arrTemp(1)
        arrTemp = Split(sY, "=", -1)
        sY = arrTemp(1)
        PointValue = New System.Drawing.Point(CInt(sX), CInt(sY))
        Return PointValue
    End Function

    'Public Shared Function Seqdata()

    Public Shared Function CloneSequenceInfo(ByVal seqinfo As sSequenceInfo) As sSequenceInfo
        Dim buf As sSequenceInfo = Nothing

        buf.sCommon = seqinfo.sCommon
        buf.nCounter = seqinfo.nCounter
        buf.nCounterChangedTemp = seqinfo.nCounterChangedTemp
        buf.nCounterGrayScaleSweep = seqinfo.nCounterGrayScaleSweep
        buf.nCounterImageSweep = seqinfo.nCounterImageSweep
        buf.nCounterIVL = seqinfo.nCounterIVL
        buf.nCounterLifeTime = seqinfo.nCounterLifeTime
        buf.nCounterPatternMeas = seqinfo.nCounterPatternMeas
        buf.nCurrentSeqIndex = seqinfo.nCurrentSeqIndex
        buf.nCurrentSeqIndex_ChangeTemp = seqinfo.nCurrentSeqIndex_ChangeTemp
        buf.nCurrentSeqIndex_GrayScaleSweep = seqinfo.nCurrentSeqIndex_GrayScaleSweep
        buf.nCurrentSeqIndex_ImageSweep = seqinfo.nCurrentSeqIndex_ImageSweep
        buf.nCurrentSeqIndex_IVL = seqinfo.nCurrentSeqIndex_IVL
        buf.nCurrentSeqIndex_LifeTime = seqinfo.nCurrentSeqIndex_LifeTime
        buf.nCurrentSeqIndex_PatternMeas = seqinfo.nCurrentSeqIndex_PatternMeas
        buf.sSampleInfos = seqinfo.sSampleInfos
        buf.sRecipes = seqinfo.sRecipes.Clone

        Return buf
    End Function

    Public Shared Function ConvertStringToBool(ByVal str As String) As Boolean
        Select Case str
            Case "True"
                Return True
            Case "False"
                Return False
            Case Else
                Return False
        End Select
    End Function


    Public Shared Function ConvertStringToSampleColorType(ByVal str As String) As ucSampleInfos.eSampleColor
        Dim RstColor As ucSampleInfos.eSampleColor
        Select Case str
            Case ucSampleInfos.eSampleColor._SingleColor_R.ToString
                RstColor = ucSampleInfos.eSampleColor._SingleColor_R
            Case ucSampleInfos.eSampleColor._SingleColor_G.ToString
                RstColor = ucSampleInfos.eSampleColor._SingleColor_G
            Case ucSampleInfos.eSampleColor._SingleColor_B.ToString
                RstColor = ucSampleInfos.eSampleColor._SingleColor_B
            Case ucSampleInfos.eSampleColor._SingleColor_W.ToString
                RstColor = ucSampleInfos.eSampleColor._SingleColor_W
            Case ucSampleInfos.eSampleColor._MixedColor.ToString
                RstColor = ucSampleInfos.eSampleColor._MixedColor
        End Select
        Return RstColor
    End Function

#End Region

End Class
