Public Class frmCharts
    Dim frmMain As frmMain
    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frm As frmMain = CType(Me.Owner, frmMain)
        Dim tab As DataTable = CType(frm.DataGridView1.DataSource, DataTable)
        If tab Is Nothing Then
            MessageBox.Show("No data loaded, please open a log file first...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If
        For Each col As DataColumn In tab.Columns
            If col.ColumnName <> "Date" AndAlso col.ColumnName <> "Time" Then
                clbColumns.Items.Add(col.ColumnName)
            End If
        Next
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

                ' Convert Y to numeric if needed
                Dim yVal As Double
                If Double.TryParse(row(colName)?.ToString(), yVal) Then
                    series.Points.AddXY(xDate, yVal)
                End If
            Next
        Next

    End Sub
End Class