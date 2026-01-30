<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        mnuOpen = New ToolStripMenuItem()
        ExportToolStripMenuItem = New ToolStripMenuItem()
        KMLToolStripMenuItem = New ToolStripMenuItem()
        AnimatedKMLToolStripMenuItem = New ToolStripMenuItem()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        OpenFileDialog1 = New OpenFileDialog()
        DataGridView1 = New DataGridView()
        MenuStrip1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, SettingsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1178, 33)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {mnuOpen, ExportToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(54, 29)
        FileToolStripMenuItem.Text = "&File"
        ' 
        ' mnuOpen
        ' 
        mnuOpen.Name = "mnuOpen"
        mnuOpen.Size = New Size(270, 34)
        mnuOpen.Text = "&Open"
        ' 
        ' ExportToolStripMenuItem
        ' 
        ExportToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {KMLToolStripMenuItem, AnimatedKMLToolStripMenuItem})
        ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        ExportToolStripMenuItem.Size = New Size(270, 34)
        ExportToolStripMenuItem.Text = "&Export"
        ' 
        ' KMLToolStripMenuItem
        ' 
        KMLToolStripMenuItem.Name = "KMLToolStripMenuItem"
        KMLToolStripMenuItem.Size = New Size(270, 34)
        KMLToolStripMenuItem.Text = "&KML"
        ' 
        ' AnimatedKMLToolStripMenuItem
        ' 
        AnimatedKMLToolStripMenuItem.Name = "AnimatedKMLToolStripMenuItem"
        AnimatedKMLToolStripMenuItem.Size = New Size(270, 34)
        AnimatedKMLToolStripMenuItem.Text = "&Animated KML"
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(92, 29)
        SettingsToolStripMenuItem.Text = "&Settings"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 33)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1178, 711)
        DataGridView1.TabIndex = 1
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1178, 744)
        Controls.Add(DataGridView1)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "frmMain"
        Text = "Log to KML"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuOpen As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnimatedKMLToolStripMenuItem As ToolStripMenuItem

End Class
