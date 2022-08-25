<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUITest
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.UcDispSampleUnitCell1 = New M7000.ucDispSampleUnitCell()
        Me.UcDispPanelModule1 = New M7000.ucDispSamplePanelModule()
        Me.UcDispUnitCellJIG16 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG15 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG14 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG13 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG5 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG3 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG2 = New M7000.ucDispJIG()
        Me.UcDispUnitCellJIG1 = New M7000.ucDispJIG()
        Me.SuspendLayout()
        '
        'UcDispSampleUnitCell1
        '
        Me.UcDispSampleUnitCell1.CellColor_Meas = System.Drawing.Color.Empty
        Me.UcDispSampleUnitCell1.CellColor_OFF = System.Drawing.Color.Black
        Me.UcDispSampleUnitCell1.CellColor_ON = System.Drawing.Color.White
        Me.UcDispSampleUnitCell1.CellNo = 0
        Me.UcDispSampleUnitCell1.CellStatus = M7000.ucDispSampleCommonNode.eCellState.eOFF
        Me.UcDispSampleUnitCell1.Channel = 0
        Me.UcDispSampleUnitCell1.IsLoadedSavePath = False
        Me.UcDispSampleUnitCell1.IsLoadedSequenceInfo = False
        Me.UcDispSampleUnitCell1.IsSelected = False
        Me.UcDispSampleUnitCell1.Location = New System.Drawing.Point(952, 12)
        Me.UcDispSampleUnitCell1.Name = "UcDispSampleUnitCell1"
        Me.UcDispSampleUnitCell1.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispSampleUnitCell1.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispSampleUnitCell1.OutlineWidth = 3.0R
        Me.UcDispSampleUnitCell1.Size = New System.Drawing.Size(173, 115)
        Me.UcDispSampleUnitCell1.TabIndex = 19
        Me.UcDispSampleUnitCell1.Temperatuer = 0.0R
        Me.UcDispSampleUnitCell1.VisibleTemp = False
        '
        'UcDispPanelModule1
        '
        Me.UcDispPanelModule1.CellColor_Meas = System.Drawing.Color.Empty
        Me.UcDispPanelModule1.CellColor_OFF = System.Drawing.Color.Black
        Me.UcDispPanelModule1.CellColor_ON = System.Drawing.Color.White
        Me.UcDispPanelModule1.CellNo = 0
        Me.UcDispPanelModule1.CellStatus = M7000.ucDispSampleCommonNode.eCellState.eOFF
        Me.UcDispPanelModule1.Channel = 0
        Me.UcDispPanelModule1.IsLoadedSavePath = False
        Me.UcDispPanelModule1.IsLoadedSequenceInfo = False
        Me.UcDispPanelModule1.IsSelected = False
        Me.UcDispPanelModule1.Location = New System.Drawing.Point(952, 147)
        Me.UcDispPanelModule1.Name = "UcDispPanelModule1"
        Me.UcDispPanelModule1.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispPanelModule1.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispPanelModule1.OutlineWidth = 3.0R
        Me.UcDispPanelModule1.Size = New System.Drawing.Size(312, 187)
        Me.UcDispPanelModule1.TabIndex = 18
        Me.UcDispPanelModule1.Temperatuer = 0.0R
        Me.UcDispPanelModule1.VisibleTemp = False
        '
        'UcDispUnitCellJIG16
        '
        Me.UcDispUnitCellJIG16.CellLayout_Col = 1
        Me.UcDispUnitCellJIG16.CellLayout_Row = 1
        Me.UcDispUnitCellJIG16.IsSelected = False
        Me.UcDispUnitCellJIG16.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG16.JIGNo = 0
        Me.UcDispUnitCellJIG16.Location = New System.Drawing.Point(583, 454)
        Me.UcDispUnitCellJIG16.Name = "UcDispUnitCellJIG16"
        Me.UcDispUnitCellJIG16.NumberOfCell = 1
        Me.UcDispUnitCellJIG16.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG16.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG16.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG16.SampleType = M7000.ucSampleInfos.eSampleType.ePanel
        Me.UcDispUnitCellJIG16.Size = New System.Drawing.Size(346, 215)
        Me.UcDispUnitCellJIG16.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG16.TabIndex = 16
        '
        'UcDispUnitCellJIG15
        '
        Me.UcDispUnitCellJIG15.CellLayout_Col = 1
        Me.UcDispUnitCellJIG15.CellLayout_Row = 1
        Me.UcDispUnitCellJIG15.IsSelected = False
        Me.UcDispUnitCellJIG15.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG15.JIGNo = 0
        Me.UcDispUnitCellJIG15.Location = New System.Drawing.Point(246, 261)
        Me.UcDispUnitCellJIG15.Name = "UcDispUnitCellJIG15"
        Me.UcDispUnitCellJIG15.NumberOfCell = 1
        Me.UcDispUnitCellJIG15.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG15.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG15.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG15.SampleType = M7000.ucSampleInfos.eSampleType.ePanel
        Me.UcDispUnitCellJIG15.Size = New System.Drawing.Size(220, 340)
        Me.UcDispUnitCellJIG15.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG15.TabIndex = 15
        '
        'UcDispUnitCellJIG14
        '
        Me.UcDispUnitCellJIG14.CellLayout_Col = 1
        Me.UcDispUnitCellJIG14.CellLayout_Row = 1
        Me.UcDispUnitCellJIG14.IsSelected = False
        Me.UcDispUnitCellJIG14.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG14.JIGNo = 0
        Me.UcDispUnitCellJIG14.Location = New System.Drawing.Point(583, 233)
        Me.UcDispUnitCellJIG14.Name = "UcDispUnitCellJIG14"
        Me.UcDispUnitCellJIG14.NumberOfCell = 1
        Me.UcDispUnitCellJIG14.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG14.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG14.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG14.SampleType = M7000.ucSampleInfos.eSampleType.ePanel
        Me.UcDispUnitCellJIG14.Size = New System.Drawing.Size(346, 215)
        Me.UcDispUnitCellJIG14.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG14.TabIndex = 14
        '
        'UcDispUnitCellJIG13
        '
        Me.UcDispUnitCellJIG13.CellLayout_Col = 1
        Me.UcDispUnitCellJIG13.CellLayout_Row = 1
        Me.UcDispUnitCellJIG13.IsSelected = False
        Me.UcDispUnitCellJIG13.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG13.JIGNo = 0
        Me.UcDispUnitCellJIG13.Location = New System.Drawing.Point(583, 12)
        Me.UcDispUnitCellJIG13.Name = "UcDispUnitCellJIG13"
        Me.UcDispUnitCellJIG13.NumberOfCell = 1
        Me.UcDispUnitCellJIG13.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG13.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG13.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG13.SampleType = M7000.ucSampleInfos.eSampleType.eModule
        Me.UcDispUnitCellJIG13.Size = New System.Drawing.Size(346, 215)
        Me.UcDispUnitCellJIG13.StatusMsgFont = New System.Drawing.Font("굴림체", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.UcDispUnitCellJIG13.TabIndex = 13
        '
        'UcDispUnitCellJIG5
        '
        Me.UcDispUnitCellJIG5.CellLayout_Col = 1
        Me.UcDispUnitCellJIG5.CellLayout_Row = 2
        Me.UcDispUnitCellJIG5.IsSelected = False
        Me.UcDispUnitCellJIG5.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG5.JIGNo = 0
        Me.UcDispUnitCellJIG5.Location = New System.Drawing.Point(31, 261)
        Me.UcDispUnitCellJIG5.Name = "UcDispUnitCellJIG5"
        Me.UcDispUnitCellJIG5.NumberOfCell = 2
        Me.UcDispUnitCellJIG5.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG5.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG5.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG5.SampleType = M7000.ucSampleInfos.eSampleType.eCell
        Me.UcDispUnitCellJIG5.Size = New System.Drawing.Size(172, 215)
        Me.UcDispUnitCellJIG5.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG5.TabIndex = 8
        '
        'UcDispUnitCellJIG3
        '
        Me.UcDispUnitCellJIG3.CellLayout_Col = 2
        Me.UcDispUnitCellJIG3.CellLayout_Row = 3
        Me.UcDispUnitCellJIG3.IsSelected = False
        Me.UcDispUnitCellJIG3.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG3.JIGNo = 0
        Me.UcDispUnitCellJIG3.Location = New System.Drawing.Point(368, 12)
        Me.UcDispUnitCellJIG3.Name = "UcDispUnitCellJIG3"
        Me.UcDispUnitCellJIG3.NumberOfCell = 5
        Me.UcDispUnitCellJIG3.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG3.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG3.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG3.SampleType = M7000.ucSampleInfos.eSampleType.eCell
        Me.UcDispUnitCellJIG3.Size = New System.Drawing.Size(172, 215)
        Me.UcDispUnitCellJIG3.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG3.TabIndex = 3
        '
        'UcDispUnitCellJIG2
        '
        Me.UcDispUnitCellJIG2.CellLayout_Col = 2
        Me.UcDispUnitCellJIG2.CellLayout_Row = 3
        Me.UcDispUnitCellJIG2.IsSelected = False
        Me.UcDispUnitCellJIG2.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG2.JIGNo = 0
        Me.UcDispUnitCellJIG2.Location = New System.Drawing.Point(190, 12)
        Me.UcDispUnitCellJIG2.Name = "UcDispUnitCellJIG2"
        Me.UcDispUnitCellJIG2.NumberOfCell = 5
        Me.UcDispUnitCellJIG2.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG2.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG2.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG2.SampleType = M7000.ucSampleInfos.eSampleType.eCell
        Me.UcDispUnitCellJIG2.Size = New System.Drawing.Size(172, 215)
        Me.UcDispUnitCellJIG2.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG2.TabIndex = 2
        '
        'UcDispUnitCellJIG1
        '
        Me.UcDispUnitCellJIG1.CellLayout_Col = 2
        Me.UcDispUnitCellJIG1.CellLayout_Row = 3
        Me.UcDispUnitCellJIG1.IsSelected = False
        Me.UcDispUnitCellJIG1.JIGColor = System.Drawing.Color.LightGray
        Me.UcDispUnitCellJIG1.JIGNo = 0
        Me.UcDispUnitCellJIG1.Location = New System.Drawing.Point(12, 12)
        Me.UcDispUnitCellJIG1.Name = "UcDispUnitCellJIG1"
        Me.UcDispUnitCellJIG1.NumberOfCell = 5
        Me.UcDispUnitCellJIG1.OutlineColor_Selected = System.Drawing.Color.Lime
        Me.UcDispUnitCellJIG1.OutlineColor_Unselected = System.Drawing.Color.Black
        Me.UcDispUnitCellJIG1.OutlineWidth = 3.0R
        Me.UcDispUnitCellJIG1.SampleType = M7000.ucSampleInfos.eSampleType.eCell
        Me.UcDispUnitCellJIG1.Size = New System.Drawing.Size(172, 215)
        Me.UcDispUnitCellJIG1.StatusMsgFont = Nothing
        Me.UcDispUnitCellJIG1.TabIndex = 1
        '
        'frmUITest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1278, 706)
        Me.Controls.Add(Me.UcDispSampleUnitCell1)
        Me.Controls.Add(Me.UcDispPanelModule1)
        Me.Controls.Add(Me.UcDispUnitCellJIG16)
        Me.Controls.Add(Me.UcDispUnitCellJIG15)
        Me.Controls.Add(Me.UcDispUnitCellJIG14)
        Me.Controls.Add(Me.UcDispUnitCellJIG13)
        Me.Controls.Add(Me.UcDispUnitCellJIG5)
        Me.Controls.Add(Me.UcDispUnitCellJIG3)
        Me.Controls.Add(Me.UcDispUnitCellJIG2)
        Me.Controls.Add(Me.UcDispUnitCellJIG1)
        Me.DoubleBuffered = True
        Me.Name = "frmUITest"
        Me.Text = "frmUITest"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcDispUnitCellJIG1 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG2 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG3 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG5 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG13 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG14 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG15 As M7000.ucDispJIG
    Friend WithEvents UcDispUnitCellJIG16 As M7000.ucDispJIG
    Friend WithEvents UcDispPanelModule1 As M7000.ucDispSamplePanelModule
    Friend WithEvents UcDispSampleUnitCell1 As M7000.ucDispSampleUnitCell
End Class
