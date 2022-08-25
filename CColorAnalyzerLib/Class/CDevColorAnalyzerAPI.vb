Public Class CDevColorAnalyzerAPI

    Public myColorAnalyzer As CDevColorAnalyzerCommonNode

    Public Sub New(ByVal device As CDevColorAnalyzerCommonNode.eModel, Optional ByVal addr As Integer = 0)

        Select Case device

            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CA310SDKMode
                'myColorAnalyzer = New CDevCA310
            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CAxxxCmdMode
                myColorAnalyzer = New CDevCAxxxCMD
            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_CS100A
                myColorAnalyzer = New CDevCS100A
            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50
                myColorAnalyzer = New CDevHEXA50(addr)
            Case CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_BM7A
                myColorAnalyzer = New CDevBM_7A
        End Select
    End Sub

End Class
