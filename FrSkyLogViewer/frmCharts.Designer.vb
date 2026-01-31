<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCharts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        clbColumns = New CheckedListBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Chart1 = New DataVisualization.Charting.Chart()
        TableLayoutPanel1.SuspendLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' clbColumns
        ' 
        clbColumns.Dock = DockStyle.Fill
        clbColumns.FormattingEnabled = True
        clbColumns.Location = New Point(3, 3)
        clbColumns.Name = "clbColumns"
        clbColumns.Size = New Size(222, 444)
        clbColumns.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(clbColumns, 0, 0)
        TableLayoutPanel1.Controls.Add(Chart1, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(800, 450)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' Chart1
        ' 
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Chart1.Dock = DockStyle.Fill
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(231, 3)
        Chart1.Name = "Chart1"
        Chart1.Size = New Size(566, 444)
        Chart1.TabIndex = 1
        Chart1.Text = "Chart1"
        ' 
        ' frmCharts
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Name = "frmCharts"
        Text = "Log Charts"
        TableLayoutPanel1.ResumeLayout(False)
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents clbColumns As CheckedListBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
