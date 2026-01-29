<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSettings
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
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        btnGPSColumn = New Button()
        nudMaxAlt = New NumericUpDown()
        Label7 = New Label()
        nudMinAlt = New NumericUpDown()
        Label8 = New Label()
        nudKMLLineWidth = New NumericUpDown()
        Label6 = New Label()
        btnColor = New Button()
        Label5 = New Label()
        txtKMLColor = New TextBox()
        chkOpenApp = New CheckBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        chkUseAltitude = New CheckBox()
        txtAltitude_Source = New TextBox()
        txtLongitude = New TextBox()
        txtLatitude = New TextBox()
        txtGPS_Source = New TextBox()
        nudAltOffset = New NumericUpDown()
        Label9 = New Label()
        btnAltitudeColumn = New Button()
        TableLayoutPanel1.SuspendLayout()
        CType(nudMaxAlt, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMinAlt, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudKMLLineWidth, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudAltOffset, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(528, 266)
        TableLayoutPanel1.Margin = New Padding(5, 6, 5, 6)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(243, 56)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = AnchorStyles.None
        OK_Button.Location = New Point(5, 6)
        OK_Button.Margin = New Padding(5, 6, 5, 6)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(111, 44)
        OK_Button.TabIndex = 0
        OK_Button.Text = "OK"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(126, 6)
        Cancel_Button.Margin = New Padding(5, 6, 5, 6)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(112, 44)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' btnGPSColumn
        ' 
        btnGPSColumn.Location = New Point(356, 21)
        btnGPSColumn.Name = "btnGPSColumn"
        btnGPSColumn.Size = New Size(44, 34)
        btnGPSColumn.TabIndex = 41
        btnGPSColumn.Text = "..."
        btnGPSColumn.UseVisualStyleBackColor = True
        ' 
        ' nudMaxAlt
        ' 
        nudMaxAlt.Location = New Point(569, 197)
        nudMaxAlt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudMaxAlt.Minimum = New Decimal(New Integer() {100000, 0, 0, Integer.MinValue})
        nudMaxAlt.Name = "nudMaxAlt"
        nudMaxAlt.Size = New Size(150, 31)
        nudMaxAlt.TabIndex = 40
        nudMaxAlt.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(419, 197)
        Label7.Name = "Label7"
        Label7.Size = New Size(112, 25)
        Label7.TabIndex = 39
        Label7.Text = "Max Altitude"
        ' 
        ' nudMinAlt
        ' 
        nudMinAlt.Location = New Point(569, 152)
        nudMinAlt.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudMinAlt.Minimum = New Decimal(New Integer() {100000, 0, 0, Integer.MinValue})
        nudMinAlt.Name = "nudMinAlt"
        nudMinAlt.Size = New Size(150, 31)
        nudMinAlt.TabIndex = 38
        nudMinAlt.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(419, 158)
        Label8.Name = "Label8"
        Label8.Size = New Size(109, 25)
        Label8.TabIndex = 37
        Label8.Text = "Min Altitude"
        ' 
        ' nudKMLLineWidth
        ' 
        nudKMLLineWidth.DecimalPlaces = 1
        nudKMLLineWidth.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        nudKMLLineWidth.Location = New Point(569, 66)
        nudKMLLineWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudKMLLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudKMLLineWidth.Name = "nudKMLLineWidth"
        nudKMLLineWidth.Size = New Size(150, 31)
        nudKMLLineWidth.TabIndex = 36
        nudKMLLineWidth.TextAlign = HorizontalAlignment.Right
        nudKMLLineWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(419, 72)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 25)
        Label6.TabIndex = 35
        Label6.Text = "KML Line Width"
        ' 
        ' btnColor
        ' 
        btnColor.Location = New Point(710, 20)
        btnColor.Name = "btnColor"
        btnColor.Size = New Size(44, 34)
        btnColor.TabIndex = 34
        btnColor.Text = "..."
        btnColor.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(419, 29)
        Label5.Name = "Label5"
        Label5.Size = New Size(130, 25)
        Label5.TabIndex = 33
        Label5.Text = "KML Line Color"
        ' 
        ' txtKMLColor
        ' 
        txtKMLColor.Location = New Point(569, 23)
        txtKMLColor.Name = "txtKMLColor"
        txtKMLColor.Size = New Size(150, 31)
        txtKMLColor.TabIndex = 32
        ' 
        ' chkOpenApp
        ' 
        chkOpenApp.AutoSize = True
        chkOpenApp.Location = New Point(250, 281)
        chkOpenApp.Name = "chkOpenApp"
        chkOpenApp.Size = New Size(246, 29)
        chkOpenApp.TabIndex = 31
        chkOpenApp.Text = "Open KML App After Save"
        chkOpenApp.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(25, 158)
        Label4.Name = "Label4"
        Label4.Size = New Size(141, 25)
        Label4.TabIndex = 30
        Label4.Text = "Altitude Column"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(25, 115)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 25)
        Label3.TabIndex = 29
        Label3.Text = "Longitude"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(25, 72)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 25)
        Label2.TabIndex = 28
        Label2.Text = "Latitude"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(170, 25)
        Label1.TabIndex = 27
        Label1.Text = "GPS Source Column"
        ' 
        ' chkUseAltitude
        ' 
        chkUseAltitude.AutoSize = True
        chkUseAltitude.Location = New Point(208, 193)
        chkUseAltitude.Name = "chkUseAltitude"
        chkUseAltitude.Size = New Size(192, 29)
        chkUseAltitude.TabIndex = 26
        chkUseAltitude.Text = "Use Altitude in KML"
        chkUseAltitude.UseVisualStyleBackColor = True
        ' 
        ' txtAltitude_Source
        ' 
        txtAltitude_Source.Location = New Point(211, 152)
        txtAltitude_Source.Name = "txtAltitude_Source"
        txtAltitude_Source.Size = New Size(150, 31)
        txtAltitude_Source.TabIndex = 25
        ' 
        ' txtLongitude
        ' 
        txtLongitude.Location = New Point(211, 110)
        txtLongitude.Name = "txtLongitude"
        txtLongitude.Size = New Size(150, 31)
        txtLongitude.TabIndex = 24
        ' 
        ' txtLatitude
        ' 
        txtLatitude.Location = New Point(211, 66)
        txtLatitude.Name = "txtLatitude"
        txtLatitude.Size = New Size(150, 31)
        txtLatitude.TabIndex = 23
        ' 
        ' txtGPS_Source
        ' 
        txtGPS_Source.Location = New Point(211, 23)
        txtGPS_Source.Name = "txtGPS_Source"
        txtGPS_Source.Size = New Size(150, 31)
        txtGPS_Source.TabIndex = 22
        ' 
        ' nudAltOffset
        ' 
        nudAltOffset.Location = New Point(569, 110)
        nudAltOffset.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        nudAltOffset.Minimum = New Decimal(New Integer() {100000, 0, 0, Integer.MinValue})
        nudAltOffset.Name = "nudAltOffset"
        nudAltOffset.Size = New Size(150, 31)
        nudAltOffset.TabIndex = 43
        nudAltOffset.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(419, 116)
        Label9.Name = "Label9"
        Label9.Size = New Size(128, 25)
        Label9.TabIndex = 42
        Label9.Text = "Altitude Offset"
        ' 
        ' btnAltitudeColumn
        ' 
        btnAltitudeColumn.Location = New Point(356, 150)
        btnAltitudeColumn.Name = "btnAltitudeColumn"
        btnAltitudeColumn.Size = New Size(44, 34)
        btnAltitudeColumn.TabIndex = 44
        btnAltitudeColumn.Text = "..."
        btnAltitudeColumn.UseVisualStyleBackColor = True
        ' 
        ' dlgSettings
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(785, 337)
        Controls.Add(btnAltitudeColumn)
        Controls.Add(nudAltOffset)
        Controls.Add(Label9)
        Controls.Add(btnGPSColumn)
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
        Controls.Add(chkUseAltitude)
        Controls.Add(txtAltitude_Source)
        Controls.Add(txtLongitude)
        Controls.Add(txtLatitude)
        Controls.Add(txtGPS_Source)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(5, 6, 5, 6)
        MaximizeBox = False
        MinimizeBox = False
        Name = "dlgSettings"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Settings"
        TableLayoutPanel1.ResumeLayout(False)
        CType(nudMaxAlt, ComponentModel.ISupportInitialize).EndInit()
        CType(nudMinAlt, ComponentModel.ISupportInitialize).EndInit()
        CType(nudKMLLineWidth, ComponentModel.ISupportInitialize).EndInit()
        CType(nudAltOffset, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnGPSColumn As Button
    Friend WithEvents nudMaxAlt As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents nudMinAlt As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents nudKMLLineWidth As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents btnColor As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtKMLColor As TextBox
    Friend WithEvents chkOpenApp As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkUseAltitude As CheckBox
    Friend WithEvents txtAltitude_Source As TextBox
    Friend WithEvents txtLongitude As TextBox
    Friend WithEvents txtLatitude As TextBox
    Friend WithEvents txtGPS_Source As TextBox
    Friend WithEvents nudAltOffset As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents btnAltitudeColumn As Button

End Class
