Imports System.Threading

Public Class CDevPGAPI

#Region "Defines"

    Public PatternGenerator() As CDevPGCommonNode


    Public Event evChangedConnectedClients(ByVal list() As String)
    Public Event evStatusMessage(ByVal msg As String)

#End Region


#Region "Creator, Disposer and init"

    Public Sub New(ByVal parent As frmMain, ByVal initParam As CDevPGCommonNode.sPGConfigParams)

        Select Case initParam.nDevice
            Case CDevPGCommonNode.eDevModel._McPG
                ReDim PatternGenerator(initParam.sMcPGConfig.Length - 1)
                For i As Integer = 0 To initParam.sMcPGConfig.Length - 1
                    PatternGenerator(i) = New CSeqRoutineMcPG(parent, initParam.sMcPGConfig(i))
                    AddHandler PatternGenerator(i).evStatusMessage, AddressOf statusMessageEventHandler
                    AddHandler PatternGenerator(i).evChangedConnectedClients, AddressOf changeConnectedDevListEventHandler
                Next
            Case CDevPGCommonNode.eDevModel._G4S
                ReDim PatternGenerator(0)
                Dim configInfos As CDevG4S.sInitParam = initParam.sG4SConfig
                Dim arrBuf As Array

                arrBuf = Split(configInfos.sSeedIP, ".", -1)
                PatternGenerator(0) = New CDevG4S(parent, arrBuf(3), configInfos.nNumberOfDev)

                AddHandler PatternGenerator(0).evStatusMessage, AddressOf statusMessageEventHandler
                AddHandler PatternGenerator(0).evChangedConnectedClients, AddressOf changeConnectedDevListEventHandler
        End Select

    End Sub

    Public Sub Dispose()
        If PatternGenerator Is Nothing = False Then
            For i As Integer = 0 To PatternGenerator.Length - 1
                PatternGenerator(i).Dispose()
            Next
        End If
    End Sub

#End Region


    Public Sub Disconnection()
        If PatternGenerator Is Nothing = False Then
            For i As Integer = 0 To PatternGenerator.Length - 1
                PatternGenerator(i).Disconnection()
            Next
        End If
    End Sub


    Public Function Connection(ByVal config As CCommLib.CComSocket.sSockInfos, ByVal timeOut As Single) As Boolean
        If PatternGenerator Is Nothing = False Then
            If PatternGenerator(0).Connection(config, timeOut) = False Then Return False
        End If
        Return True
    End Function



    Private Sub statusMessageEventHandler(ByVal msg As String)
        RaiseEvent evStatusMessage(msg)
        Application.DoEvents()
        Thread.Sleep(10)
    End Sub

    Private Sub changeConnectedDevListEventHandler(ByVal list() As String)
        RaiseEvent evChangedConnectedClients(list)
    End Sub



End Class
