Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports FrSkyLogViewer.My

Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGPS_Source.Text = My.Settings.GPS_Source
        txtLatitude.Text = My.Settings.Latitude
        txtLongitude.Text = My.Settings.Longitude
        txtAltitude_Source.Text = My.Settings.Altitude_Source
        txtKMLColor.ForeColor = My.Settings.KMLLineColor
        txtKMLColor.Text = My.Settings.KMLLineColor.A.ToString("X2") & My.Settings.KMLLineColor.B.ToString("X2") & My.Settings.KMLLineColor.G.ToString("X2") & My.Settings.KMLLineColor.R.ToString("X2")
        nudKMLLineWidth.Value = My.Settings.KMLLineWidth
        nudMinAlt.Value = My.Settings.MinAltitude
        nudMaxAlt.Value = My.Settings.MaxAltitude
        chkUseAltitude.Checked = My.Settings.Use_Altitude
        chkOpenApp.Checked = My.Settings.OpenApp
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.GPS_Source = txtGPS_Source.Text
        My.Settings.Latitude = txtLatitude.Text
        My.Settings.Longitude = txtLongitude.Text
        My.Settings.Altitude_Source = txtAltitude_Source.Text
        My.Settings.KMLLineColor = txtKMLColor.ForeColor
        My.Settings.KMLLineWidth = nudKMLLineWidth.Value
        My.Settings.MinAltitude = nudMinAlt.Value
        My.Settings.MaxAltitude = nudMaxAlt.Value
        My.Settings.Use_Altitude = chkUseAltitude.Checked
        My.Settings.OpenApp = chkOpenApp.Checked
        My.Settings.Save()
        Me.Close()
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class