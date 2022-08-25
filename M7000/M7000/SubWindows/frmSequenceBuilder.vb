Imports System.Threading

Public Class frmSequenceBuilder

    Dim WithEvents ucDispSeqBuilder As ucSequenceBuilder

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        ucDispSeqBuilder = New ucSequenceBuilder
        Me.Controls.Add(Me.ucDispSeqBuilder)

        ucDispSeqBuilder.Location = New System.Drawing.Point(0, 0)
        ucDispSeqBuilder.Dock = DockStyle.Fill
        '   ucDispSeqBuilder.Size = New System.Drawing.Size(Me.ClientSize.Width, btnOK.Location.Y - 3)
        ' ucDispSeqBuilder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Top), System.Windows.Forms.AnchorStyles)
    End Sub

    'Private Sub frmSequenceBuilder_Enter(sender As Object, e As System.EventArgs) Handles Me.Enter

    'End Sub

    Private Sub frmSequenceBuilder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ucDispSeqBuilder.Dispose()
    End Sub

    Private Sub GetUIState()
        g_SequenceBuilderOptions.UISettings.nFrameSize_Height = Me.Size.Height
        g_SequenceBuilderOptions.UISettings.nFrameSize_Width = Me.Size.Width
    End Sub

    Private Sub updateUISettings()
        With g_SequenceBuilderOptions
            If .UISettings.nFrameSize_Height > 0 And .UISettings.nFrameSize_Width > 0 Then
                Me.Size = New System.Drawing.Size(.UISettings.nFrameSize_Width, .UISettings.nFrameSize_Height)
                ' ucDispSeqBuilder.Size = New System.Drawing.Size(Me.ClientSize.Width, btnOK.Location.Y - 3)
                ' ucDispSeqBuilder.Dock = DockStyle.Fill
            End If
        End With
    End Sub

    Private Sub frmSequenceBuilder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        GetUIState()
        ucDispSeqBuilder.GetUISizeInfos()
        frmBuilderSettings.SaveSeqBuilderSetting(g_SequenceBuilderOptions)
        ucDispSeqBuilder.Dispose()
    End Sub

    Private Sub frmSequenceBuilder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If frmBuilderSettings.LoadSeqBuilderSetting(g_SequenceBuilderOptions) = True Then
            updateUISettings()
            ucDispSeqBuilder.updateBuilderSetting()
            ucDispSeqBuilder.SetUISizeInfos()
        End If

    End Sub

    'Private Sub frmSequenceBuilder_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
    '    updateUISettings()
    'End Sub

End Class