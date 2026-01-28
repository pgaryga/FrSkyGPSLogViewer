<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        txtGPS_Source = New TextBox()
        txtLatitude = New TextBox()
        txtLongitude = New TextBox()
        txtAltitude_Source = New TextBox()
        chkUseAltitude = New CheckBox()
        btnOK = New Button()
        btnCancel = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        chkOpenApp = New CheckBox()
        txtKMLColor = New TextBox()
        Label5 = New Label()
        btnColor = New Button()
        Label6 = New Label()
        nudKMLLineWidth = New NumericUpDown()
        Label8 = New Label()
        nudMinAlt = New NumericUpDown()
        Label7 = New Label()
        nudMaxAlt = New NumericUpDown()
        CType(nudKMLLineWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMinAlt, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMaxAlt, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtGPS_Source
        ' 
        txtGPS_Source.Location = New Point(176, 25)
        txtGPS_Source.Name = "txtGPS_Source"
        txtGPS_Source.Size = New Size(150, 31)
        txtGPS_Source.TabIndex = 0
        ' 
        ' txtLatitude
        ' 
        txtLatitude.Location = New Point(176, 76)
        txtLatitude.Name = "txtLatitude"
        txtLatitude.Size = New Size(150, 31)
        txtLatitude.TabIndex = 1
        ' 
        ' txtLongitude
        ' 
        txtLongitude.Location = New Point(176, 127)
        txtLongitude.Name = "txtLongitude"
        txtLongitude.Size = New Size(150, 31)
        txtLongitude.TabIndex = 2
        ' 
        ' txtAltitude_Source
        ' 
        txtAltitude_Source.Location = New Point(176, 178)
        txtAltitude_Source.Name = "txtAltitude_Source"
        txtAltitude_Source.Size = New Size(150, 31)
        txtAltitude_Source.TabIndex = 3
        ' 
        ' chkUseAltitude
        ' 
        chkUseAltitude.AutoSize = True
        chkUseAltitude.Location = New Point(134, 220)
        chkUseAltitude.Name = "chkUseAltitude"
        chkUseAltitude.Size = New Size(192, 29)
        chkUseAltitude.TabIndex = 4
        chkUseAltitude.Text = "Use Altitude in KML"
        chkUseAltitude.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(200, 318)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(112, 34)
        btnOK.TabIndex = 5
        btnOK.Text = "&Save"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(368, 318)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 34)
        btnCancel.TabIndex = 6
        btnCancel.Text = "&Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(26, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 25)
        Label1.TabIndex = 7
        Label1.Text = "GPS Source Col"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(26, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 25)
        Label2.TabIndex = 8
        Label2.Text = "Latitude"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(26, 128)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 25)
        Label3.TabIndex = 9
        Label3.Text = "Longitude"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(26, 178)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 25)
        Label4.TabIndex = 10
        Label4.Text = "Altitude"
        ' 
        ' chkOpenApp
        ' 
        chkOpenApp.AutoSize = True
        chkOpenApp.Location = New Point(134, 269)
        chkOpenApp.Name = "chkOpenApp"
        chkOpenApp.Size = New Size(207, 29)
        chkOpenApp.TabIndex = 11
        chkOpenApp.Text = "Open App After Save"
        chkOpenApp.UseVisualStyleBackColor = True
        ' 
        ' txtKMLColor
        ' 
        txtKMLColor.Location = New Point(495, 28)
        txtKMLColor.Name = "txtKMLColor"
        txtKMLColor.Size = New Size(150, 31)
        txtKMLColor.TabIndex = 12
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(345, 31)
        Label5.Name = "Label5"
        Label5.Size = New Size(130, 25)
        Label5.TabIndex = 13
        Label5.Text = "KML Line Color"
        ' 
        ' btnColor
        ' 
        btnColor.Location = New Point(651, 25)
        btnColor.Name = "btnColor"
        btnColor.Size = New Size(44, 34)
        btnColor.TabIndex = 14
        btnColor.Text = "..."
        btnColor.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(345, 82)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 25)
        Label6.TabIndex = 15
        Label6.Text = "KML Line Width"
        ' 
        ' nudKMLLineWidth
        ' 
        nudKMLLineWidth.DecimalPlaces = 1
        nudKMLLineWidth.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        nudKMLLineWidth.Location = New Point(495, 80)
        nudKMLLineWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudKMLLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudKMLLineWidth.Name = "nudKMLLineWidth"
        nudKMLLineWidth.Size = New Size(150, 31)
        nudKMLLineWidth.TabIndex = 16
        nudKMLLineWidth.TextAlign = HorizontalAlignment.Right
        nudKMLLineWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(345, 178)
        Label8.Name = "Label8"
        Label8.Size = New Size(69, 25)
        Label8.TabIndex = 17
        Label8.Text = "Min Alt"
        ' 
        ' nudMinAlt
        ' 
        nudMinAlt.Location = New Point(495, 178)
        nudMinAlt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudMinAlt.Minimum = New Decimal(New Integer() {100000, 0, 0, Integer.MinValue})
        nudMinAlt.Name = "nudMinAlt"
        nudMinAlt.Size = New Size(150, 31)
        nudMinAlt.TabIndex = 18
        nudMinAlt.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(345, 224)
        Label7.Name = "Label7"
        Label7.Size = New Size(72, 25)
        Label7.TabIndex = 19
        Label7.Text = "Max Alt"
        ' 
        ' nudMaxAlt
        ' 
        nudMaxAlt.Location = New Point(495, 218)
        nudMaxAlt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudMaxAlt.Minimum = New Decimal(New Integer() {100000, 0, 0, Integer.MinValue})
        nudMaxAlt.Name = "nudMaxAlt"
        nudMaxAlt.Size = New Size(150, 31)
        nudMaxAlt.TabIndex = 20
        nudMaxAlt.TextAlign = HorizontalAlignment.Right
        ' 
        ' frmSettings
        ' 
        AcceptButton = btnOK
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(709, 364)
        Controls.Add(nudMaxAlt)
        Controls.Add(Label7)
        Controls.Add(nudMinAlt)
        Controls.Add(Label8)
        Controls.Add(nudKMLLineWidth)
        Controls.Add(Label6)
        Controls.Add(btnColor)
        Controls.Add(Label5)
        Controls.Add(txtKMLColor)
        Controls.Add(chkOpenApp)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnCancel)
        Controls.Add(btnOK)
        Controls.Add(chkUseAltitude)
        Controls.Add(txtAltitude_Source)
        Controls.Add(txtLongitude)
        Controls.Add(txtLatitude)
        Controls.Add(txtGPS_Source)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterParent
        Text = "Settings"
        TopMost = True
        CType(nudKMLLineWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(nudMinAlt, ComponentModel.ISupportInitialize).EndInit()
        CType(nudMaxAlt, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtGPS_Source As TextBox
    Friend WithEvents txtLatitude As TextBox
    Friend WithEvents txtLongitude As TextBox
    Friend WithEvents txtAltitude_Source As TextBox
    Friend WithEvents chkUseAltitude As CheckBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkOpenApp As CheckBox
    Friend WithEvents txtKMLColor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnColor As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nudKMLLineWidth As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents nudMinAlt As NumericUpDown
    Friend WithEvents nudMaxAlt As NumericUpDown
End Class
