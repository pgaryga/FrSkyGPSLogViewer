Public Class frmMain
    Dim MyFile As DialogResult
    Dim GPS, col As Integer
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Log Files|*.log;*.csv|All Files|*.*"
        OpenFileDialog1.Title = "Open FrSky GPS Log File"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog1.FileName
            Me.Text = "FrSky Log Viewer - " & filePath

            Dim lines As String() = System.IO.File.ReadAllLines(filePath)
            Dim dataTable As New DataTable()

            ' Assuming the first line contains headers
            Dim headers As String() = lines(0).Split(","c)
            col = 0
            For Each header As String In headers
                Try
                    col += 1
                    dataTable.Columns.Add(header)
                    If header = My.Settings.GPS_Source Then  ' Special handling for GPS column
                        dataTable.Columns.Add(My.Settings.Latitude)
                        dataTable.Columns.Add(My.Settings.Longitude)
                        GPS = col - 1
                    End If
                Catch ex As Exception
                    dataTable.Columns.Add(header + "1")
                End Try

            Next
            ' Add the rest of the lines as rows
            For i As Integer = 1 To lines.Length - 1
                Dim rowValues As String() = lines(i).Split(","c)
                dataTable.Rows.Add(rowValues)
                If rowValues(GPS) <> "" Then
                    Dim rowGPS As String() = rowValues(GPS).Split(" "c)
                    dataTable.Rows(i - 1)(My.Settings.Latitude) = rowGPS(0) ' GPS Latitude
                    dataTable.Rows(i - 1)(My.Settings.Longitude) = rowGPS(1) ' GPS Longitude
                End If
            Next
            DataGridView1.DataSource = dataTable
            MyFile = DialogResult.OK
        Else
            MyFile = DialogResult.Cancel
        End If



    End Sub


    Private Function ShellExecute(ByVal File As String) As Boolean
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Function

    Private Function GenerateKML() As String
        Dim dataTable As DataTable = DataGridView1.DataSource
        Dim lastLatitude As String = ""
        Dim lastLongitude As String = ""
        Dim col As String = My.Settings.KMLLineColor.A.ToString("X2") & My.Settings.KMLLineColor.B.ToString("X2") & My.Settings.KMLLineColor.G.ToString("X2") & My.Settings.KMLLineColor.R.ToString("X2")

        Dim kmlContent As New System.Text.StringBuilder()
        Dim dat As String = DataTable.Rows(0)("Date").ToString()
        Dim tim As String = DataTable.Rows(0)("Time").ToString()
        Dim altitude As String = "0"
        kmlContent.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        kmlContent.AppendLine("<kml xmlns=""http://www.opengis.net/kml/2.2"">")
        kmlContent.AppendLine("<Document>")
        kmlContent.AppendLine($"<name>Flight Path: {dat} - {tim}</name>")
        kmlContent.AppendLine("<description>Exported from FrSky Log Viewer by Pete Garyga</description>")
        kmlContent.AppendLine("<Style id=""highlightPlacemark"">")
        kmlContent.AppendLine("<IconStyle>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://maps.google.com/mapfiles/kml/paddle/red-stars.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("</Style>")
        kmlContent.AppendLine("<Style id = ""normalPlacemark"" >")
        kmlContent.AppendLine("<IconStyle>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://maps.google.com/mapfiles/kml/paddle/red-blank.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("</Style>")
        kmlContent.AppendLine("<StyleMap id = ""exampleStyleMap"" >")
        kmlContent.AppendLine("<Pair>")
        kmlContent.AppendLine("<key>normal</key>")
        kmlContent.AppendLine("<styleUrl>#normalPlacemark</styleUrl>")
        kmlContent.AppendLine("</Pair>")
        kmlContent.AppendLine("<Pair>")
        kmlContent.AppendLine("<key>highlight</key>")
        kmlContent.AppendLine("<styleUrl>#highlightPlacemark</styleUrl>")
        kmlContent.AppendLine("</Pair>")
        kmlContent.AppendLine("</StyleMap>")
        kmlContent.AppendLine("<Style id=""flightLine"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine($"<color>{col}</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("<PolyStyle>")
        kmlContent.AppendLine("<color>7f00ff00</color>")
        kmlContent.AppendLine("</PolyStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<name>Start</name>")
        kmlContent.AppendLine("<styleUrl>#exampleStyleMap</styleUrl>")
        kmlContent.AppendLine("<Point>")
        kmlContent.AppendLine("<coordinates>")
        For Each row As DataRow In DataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()

            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source)
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                altitude = iAltval.ToString()
            End If

            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) Then
                kmlContent.AppendLine($"{longitude},{latitude},{altitude}")
                'lastLatitude = latitude
                'lastLongitude = longitude
                Exit For
            End If
        Next

        kmlContent.AppendLine("</coordinates>")
        kmlContent.AppendLine("</Point>")
        kmlContent.AppendLine("</Placemark>")

        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<name>Flight Path</name>")
        kmlContent.AppendLine("<styleUrl>#flightLine</styleUrl>")
        kmlContent.AppendLine("<LineString>")
        kmlContent.AppendLine("<tessellate>1</tessellate>")
        kmlContent.AppendLine("<altitudeMode>absolute</altitudeMode>")
        kmlContent.AppendLine("<coordinates>")

        For Each row As DataRow In DataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()

            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source)
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                'If iAltval < My.Settings.MinAltitude Then iAltval += 800 '= My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                altitude = iAltval.ToString()
            End If
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) AndAlso latitude <> lastLatitude AndAlso longitude <> lastLongitude Then
                lastLatitude = latitude
                lastLongitude = longitude
                kmlContent.AppendLine($"{longitude},{latitude},{altitude}")
            End If
        Next
        kmlContent.AppendLine("</coordinates>")
        kmlContent.AppendLine("</LineString>")
        kmlContent.AppendLine("</Placemark>")

        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<name>End</name>")
        kmlContent.AppendLine("<styleUrl>#exampleStyleMap</styleUrl>")
        kmlContent.AppendLine("<Point>")
        kmlContent.AppendLine("<coordinates>")
        kmlContent.AppendLine($"{lastLongitude},{lastLatitude},{altitude}")
        kmlContent.AppendLine("</coordinates>")
        kmlContent.AppendLine("</Point>")
        kmlContent.AppendLine("</Placemark>")

        kmlContent.AppendLine("</Document>")
        kmlContent.AppendLine("</kml>")

        Return kmlContent.ToString
    End Function
    Private Sub ExportKMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportKMLToolStripMenuItem.Click
        If MyFile = DialogResult.OK Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "KML Files|*.kml|All Files|*.*"
            saveFileDialog.FileName = Mid(Me.Text, 19) & ".kml"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                System.IO.File.WriteAllText(saveFileDialog.FileName, GenerateKML())
                If My.Settings.OpenApp Then
                    ShellExecute(saveFileDialog.FileName)
                Else
                    MessageBox.Show("KML file exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("No data to export. Please open a log file first.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim dialogResult1 = frmSettings.ShowDialog()
    End Sub
End Class
