Imports System.Windows.Forms

Public Class dlgSettings
    Public item As String = ""
    Private Sub dlgSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGPS_Source.Text = My.Settings.GPS_Source
        txtLatitude.Text = My.Settings.Latitude
        txtLongitude.Text = My.Settings.Longitude
        txtAltitude_Source.Text = My.Settings.Altitude_Source
        txtKMLColor.ForeColor = My.Settings.KMLLineColor
        txtKMLColor.Text = My.Settings.KMLLineColor.A.ToString("X2") & My.Settings.KMLLineColor.B.ToString("X2") & My.Settings.KMLLineColor.G.ToString("X2") & My.Settings.KMLLineColor.R.ToString("X2")
        nudKMLLineWidth.Value = My.Settings.KMLLineWidth
        nudMinAlt.Value = My.Settings.MinAltitude
        nudMaxAlt.Value = My.Settings.MaxAltitude
        nudAltOffset.Value = My.Settings.AltitudeOffset
        nudAnnimationDelay.Value = My.Settings.AnnimationDelay
        chkUseAltitude.Checked = My.Settings.Use_Altitude
        chkOpenApp.Checked = My.Settings.OpenApp
        cboKMLAltitideMode.SelectedText = My.Settings.KMLAltitudeMode
    End Sub

    Private Sub btnGPSColumn_Click(sender As Object, e As EventArgs) Handles btnGPSColumn.Click
        item = "GPS"
        If dlgChoose.ShowDialog(Me) = DialogResult.OK Then
            txtGPS_Source.Text = My.Settings.GPS_Source
        End If
    End Sub
    Private Sub btnAltitudeColumn_Click(sender As Object, e As EventArgs) Handles btnAltitudeColumn.Click
        item = "Altitude"
        If dlgChoose.ShowDialog(Me) = DialogResult.OK Then
            txtAltitude_Source.Text = My.Settings.Altitude_Source
        End If
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim MyDialog As New ColorDialog()

        MyDialog.AllowFullOpen = True
        MyDialog.ShowHelp = True
        MyDialog.Color = txtKMLColor.ForeColor
        If (MyDialog.ShowDialog() = DialogResult.OK) Then
            txtKMLColor.Text = MyDialog.Color.A.ToString("X2") & MyDialog.Color.B.ToString("X2") & MyDialog.Color.G.ToString("X2") & MyDialog.Color.R.ToString("X2")
            txtKMLColor.ForeColor = MyDialog.Color
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.GPS_Source = txtGPS_Source.Text
        My.Settings.Latitude = txtLatitude.Text
        My.Settings.Longitude = txtLongitude.Text
        My.Settings.Altitude_Source = txtAltitude_Source.Text
        My.Settings.KMLLineColor = txtKMLColor.ForeColor
        My.Settings.KMLLineWidth = nudKMLLineWidth.Value
        My.Settings.MinAltitude = nudMinAlt.Value
        My.Settings.MaxAltitude = nudMaxAlt.Value
        My.Settings.AltitudeOffset = nudAltOffset.Value
        My.Settings.Use_Altitude = chkUseAltitude.Checked
        My.Settings.KMLAltitudeMode = cboKMLAltitideMode.Text
        My.Settings.AnnimationDelay = nudAnnimationDelay.Value
        My.Settings.OpenApp = chkOpenApp.Checked
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
