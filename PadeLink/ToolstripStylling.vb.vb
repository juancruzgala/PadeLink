Imports System.Drawing
Imports System.Windows.Forms

Public Module ToolstripStyling
    Public Sub FixToolStrip(ts As ToolStrip)
        If ts Is Nothing Then Exit Sub

        ts.Dock = DockStyle.Top
        ts.GripStyle = ToolStripGripStyle.Hidden
        ts.RenderMode = ToolStripRenderMode.Professional
        ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
        ts.ImageScalingSize = New Size(24, 24)

        ts.AutoSize = False
        ts.Height = 40
        ts.Padding = New Padding(6, 4, 6, 4)
        ts.Margin = New Padding(0)

        For Each it As ToolStripItem In ts.Items
            it.AutoSize = False
            it.Margin = New Padding(2, 0, 2, 0)
            it.Padding = New Padding(0)

            If TypeOf it Is ToolStripButton Then
                Dim b = DirectCast(it, ToolStripButton)
                b.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                b.TextImageRelation = TextImageRelation.ImageBeforeText
                b.ImageScaling = ToolStripItemImageScaling.SizeToFit
                b.ImageTransparentColor = Color.Transparent
                b.Width = 90
            ElseIf TypeOf it Is ToolStripSeparator Then
                Dim s = DirectCast(it, ToolStripSeparator)
                s.AutoSize = False
                s.Width = 6
            End If
        Next
    End Sub
End Module