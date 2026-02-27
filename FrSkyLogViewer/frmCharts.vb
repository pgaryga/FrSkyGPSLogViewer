Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmCharts
    Dim frmMain As frmMain
    Dim filename As String
    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frm As frmMain = CType(Me.Owner, frmMain)
        Dim tab As DataTable = CType(frm.DataGridView1.DataSource, DataTable)
        clbColumns.CheckOnClick = True

        If tab Is Nothing Then
            MessageBox.Show("No data loaded, please open a log file first...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If
        If filename <> My.Settings.Filename Then
            filename = My.Settings.Filename
            clbColumns.Items.Clear()
            Chart1.Series.Clear()
            For Each col As DataColumn In tab.Columns
                If col.ColumnName <> "Date" AndAlso col.ColumnName <> "Time" Then
                    clbColumns.Items.Add(col.ColumnName)
                End If
            Next
        End If
    End Sub
    Private Sub clbColumns_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbColumns.ItemCheck
        ' Redraw chart with selected columns
        Dim frm As frmMain = CType(Me.Owner, frmMain)
        Dim tab As DataTable = CType(frm.DataGridView1.DataSource, DataTable)
        If tab Is Nothing Then
            Return
        End If
        Dim selectedColumns As New List(Of String)
        For i As Integer = 0 To clbColumns.Items.Count - 1
            If clbColumns.GetItemChecked(i) Then
                selectedColumns.Add(clbColumns.Items(i).ToString())
            End If
        Next
        ' Include the item being checked/unchecked
        If e.NewValue = CheckState.Checked Then
            selectedColumns.Add(clbColumns.Items(e.Index).ToString())
        Else
            selectedColumns.Remove(clbColumns.Items(e.Index).ToString())
        End If

        ' Clear existing series
        Chart1.Series.Clear()
        ' Add series for each selected column
        For Each colName As String In selectedColumns
            Dim series = Chart1.Series.Add(colName)
            Chart1.ChartAreas(0).AxisX.LabelStyle.Format = "HH:mm:ss"
            series.ChartType = DataVisualization.Charting.SeriesChartType.Line
            For Each row As DataRow In tab.Rows
                Dim xDate As DateTime = row(0)
                Dim xTim = row(1)


                If xTim Is Nothing OrElse Convert.IsDBNull(xTim) Then
                    Continue For
                End If

                If TypeOf xTim Is DateTime Then
                    xDate = CType(xTim, DateTime)
                ElseIf TypeOf xTim Is TimeOnly Then
                    ' Convert TimeOnly to a DateTime for charting (use any reference date)
                    xDate = xDate.Add(CType(xTim, TimeOnly).ToTimeSpan())
                Else
                    Dim s = xTim.ToString()
                    Dim t As TimeOnly
                    Dim dt As DateTime
                    If TimeOnly.TryParse(s, t) Then
                        xDate = xDate.Add(t.ToTimeSpan())
                    ElseIf DateTime.TryParse(s, dt) Then
                        xDate = dt
                    Else
                        ' skip row or log parsing failure
                        Continue For
                    End If
                End If

                Dim yVal As Double
                ' Convert Y to numeric if needed
                Try
                    If row(colName) IsNot Nothing AndAlso Double.TryParse(row(colName)?.ToString(), yVal) Then
                        series.Points.AddXY(xDate, yVal)
                    End If
                Catch ex As Exception
                    Exit For
                End Try

            Next
        Next

    End Sub


    ' Assumes a Chart named Chart1, with an ChartArea named "ChartArea1"
    Private isSelecting As Boolean = False
    Private rectStart As Point
    Private selectionRect As Rectangle

    ' 1. MouseDown: Start capturing the zoom area
    Private Sub Chart1_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart1.MouseDown
        If e.Button = MouseButtons.Left Then
            isSelecting = True
            rectStart = e.Location
        End If
    End Sub

    ' 2. MouseMove: Draw the selection rectangle
    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove
        If isSelecting Then
            Dim currentPoint As Point = e.Location
            ' Calculate rectangle dimensions
            Dim x As Integer = Math.Min(rectStart.X, currentPoint.X)
            Dim y As Integer = Math.Min(rectStart.Y, currentPoint.Y)
            Dim width As Integer = Math.Abs(rectStart.X - currentPoint.X)
            Dim height As Integer = Math.Abs(rectStart.Y - currentPoint.Y)
            selectionRect = New Rectangle(x, y, width, height)
            Chart1.Invalidate() ' Force repaint to show rectangle
        End If
    End Sub

    ' 3. Paint: Draw the selection box visually
    Private Sub Chart1_Paint(sender As Object, e As PaintEventArgs) Handles Chart1.Paint
        If isSelecting Then
            Using pen As New Pen(Color.Red, 1)
                e.Graphics.DrawRectangle(pen, selectionRect)
            End Using
        End If
    End Sub

    ' 4. MouseUp: Apply the zoom
    Private Sub Chart1_MouseUp(sender As Object, e As MouseEventArgs) Handles Chart1.MouseUp
        If isSelecting Then
            isSelecting = False

            ' Convert pixels to chart values
            Dim ca As ChartArea = Chart1.ChartAreas("ChartArea1")
            Dim xMin As Double = ca.AxisX.PixelPositionToValue(selectionRect.Left)
            Dim xMax As Double = ca.AxisX.PixelPositionToValue(selectionRect.Right)
            Dim yMin As Double = ca.AxisY.PixelPositionToValue(selectionRect.Bottom)
            Dim yMax As Double = ca.AxisY.PixelPositionToValue(selectionRect.Top)

            ' Apply new zoom range
            ca.AxisX.Minimum = xMin
            ca.AxisX.Maximum = xMax
            ca.AxisY.Minimum = yMin
            ca.AxisY.Maximum = yMax

            Chart1.Invalidate()
        End If
    End Sub

    ' 5. Optional: Right-click to reset zoom
    Private Sub Chart1_MouseClick(sender As Object, e As MouseEventArgs) Handles Chart1.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim ca As ChartArea = Chart1.ChartAreas("ChartArea1")
            ca.AxisX.ScaleView.ZoomReset()
            ca.AxisY.ScaleView.ZoomReset()
            ' Reset axis to auto-scale if necessary
            ca.AxisX.Minimum = Double.NaN
            ca.AxisX.Maximum = Double.NaN
            ca.AxisY.Minimum = Double.NaN
            ca.AxisY.Maximum = Double.NaN
        End If
    End Sub


End Class