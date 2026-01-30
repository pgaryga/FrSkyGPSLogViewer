Public Class frmMain
    Dim MyFile As DialogResult
    Dim colmn As Integer
    Dim GPS As Integer

    Private Function ShellExecute(ByVal File As String) As Boolean
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
        Return True
    End Function

    Private Function GenerKMLStyles() As String
        Dim kmlContent As New System.Text.StringBuilder()
        Dim col As String = My.Settings.KMLLineColor.A.ToString("X2") & My.Settings.KMLLineColor.B.ToString("X2") & My.Settings.KMLLineColor.G.ToString("X2") & My.Settings.KMLLineColor.R.ToString("X2")

        kmlContent.AppendLine("<Style id=""line-style"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine($"<color>{col}</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")
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
        kmlContent.AppendLine("<StyleMap id = ""PointerStyleMap"" >")
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
        kmlContent.AppendLine("</Style>")
        Return kmlContent.ToString
    End Function
    Private Function GenerateStartKML() As String
        Dim dataTable As DataTable = DataGridView1.DataSource
        Dim kmlContent As New System.Text.StringBuilder()
        Dim altitude As Long = 0

        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<name>Start</name>")
        kmlContent.AppendLine("<styleUrl>#PointerStyleMap</styleUrl>")
        kmlContent.AppendLine("<Point>")
        kmlContent.AppendLine("<coordinates>")
        For Each row As DataRow In dataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()

            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source) + My.Settings.AltitudeOffset
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                altitude = iAltval
            End If
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) Then
                kmlContent.AppendLine($"{longitude},{latitude},{altitude}")
                Exit For
            End If
        Next

        kmlContent.AppendLine("</coordinates>")
        kmlContent.AppendLine("</Point>")
        kmlContent.AppendLine("</Placemark>")
        Return kmlContent.ToString
    End Function
    Private Function GenerateAniKML() As String
        Dim dataTable As DataTable = DataGridView1.DataSource
        Dim lastLatitude As String = ""
        Dim lastLongitude As String = ""
        Dim lastAltitude As Long = 0



        Dim kmlContent As New System.Text.StringBuilder()
        Dim dat As String = dataTable.Rows(0)("Date").ToString()
        Dim tim As String = dataTable.Rows(0)("Time").ToString()
        Dim altitude As Long = 0
        kmlContent.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        kmlContent.AppendLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"" xmlns:kml=""http://www.opengis.net/kml/2.2"" xmlns:atom=""http://www.w3.org/2005/Atom"">")
        kmlContent.AppendLine("<Document>")
        kmlContent.AppendLine($"<name>Flight Path: {dat} - {tim}</name>")
        kmlContent.AppendLine("<description>Exported from FrSky GPS Log to KML by Pete Garyga</description>")
        kmlContent.AppendLine("<open>1</open>")


        kmlContent.AppendLine(GenerKMLStyles())
        kmlContent.AppendLine(GenerateStartKML())

        kmlContent.AppendLine("<gx:Tour>")
        kmlContent.AppendLine("<name>Double-click here to see the animated flightpath</name>")
        kmlContent.AppendLine("<gx:Playlist>")
        kmlContent.AppendLine("<gx:Wait> <gx:duration>0.5</gx:duration></gx:Wait> <!-- short pause at the beginning -->")
        'loop through each point to create animated segments
        Dim i As Integer = 0
        For Each row As DataRow In dataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()
            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source) + My.Settings.AltitudeOffset
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                lastAltitude = iAltval
            End If
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) AndAlso latitude <> lastLatitude AndAlso longitude <> lastLongitude Then
                lastLatitude = latitude
                lastLongitude = longitude
                kmlContent.AppendLine("<gx:AnimatedUpdate>")
                kmlContent.AppendLine("<Update>")
                kmlContent.AppendLine($"<Change><Placemark targetId=""{i}""><visibility>1</visibility></Placemark></Change>")
                kmlContent.AppendLine("</Update>")
                kmlContent.AppendLine("</gx:AnimatedUpdate>")
                kmlContent.AppendLine($"<gx:Wait><gx:duration>{My.Settings.AnnimationDelay}</gx:duration></gx:Wait>")
                i += 1
            End If
        Next

        kmlContent.AppendLine("<gx:Wait> <gx:duration>1</gx:duration></gx:Wait>")
        kmlContent.AppendLine("</gx:Playlist>")
        kmlContent.AppendLine("</gx:Tour>")

        kmlContent.AppendLine("<Folder>")
        kmlContent.AppendLine("<name>Flightpath</name>")
        kmlContent.AppendLine("<Style>")
        kmlContent.AppendLine("<ListStyle>")
        kmlContent.AppendLine("<listItemType>checkHideChildren</listItemType>")
        kmlContent.AppendLine("</ListStyle>")
        kmlContent.AppendLine("</Style>")

        Dim plcID As Integer = 1
        For Each row As DataRow In dataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()

            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source) + My.Settings.AltitudeOffset
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                altitude = iAltval
            End If
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) AndAlso latitude <> lastLatitude AndAlso longitude <> lastLongitude Then

                kmlContent.AppendLine($"<Placemark id=""{plcID}"">")
                kmlContent.AppendLine($"<name>{plcID}</name>")
                kmlContent.AppendLine("<visibility>0</visibility>")
                kmlContent.AppendLine("<styleUrl>#line-style</styleUrl>")
                kmlContent.AppendLine("<LineString>")
                kmlContent.AppendLine("<tessellate>1</tessellate>")
                kmlContent.AppendLine("<altitudeMode>relativeToSeaFloor</altitudeMode>")
                kmlContent.AppendLine("<coordinates>")
                kmlContent.AppendLine($"{lastLongitude},{lastLatitude},{lastAltitude},{longitude},{latitude},{altitude}")
                kmlContent.AppendLine("</coordinates>")
                kmlContent.AppendLine("</LineString>")
                kmlContent.AppendLine("</Placemark>")
                lastLatitude = latitude
                lastLongitude = longitude
                lastAltitude = altitude
                plcID += 1
            End If
        Next

        kmlContent.AppendLine("</Folder>")
        kmlContent.AppendLine("</Document>")
        kmlContent.AppendLine("</kml>")

        Return kmlContent.ToString
    End Function

    Private Function GenerateKML() As String
        Dim dataTable As DataTable = DataGridView1.DataSource
        Dim lastLatitude As String = ""
        Dim lastLongitude As String = ""


        Dim kmlContent As New System.Text.StringBuilder()
        Dim dat As String = dataTable.Rows(0)("Date").ToString()
        Dim tim As String = dataTable.Rows(0)("Time").ToString()
        Dim altitude As Long = 0
        kmlContent.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        kmlContent.AppendLine("<kml xmlns=""http://www.opengis.net/kml/2.2"">")
        kmlContent.AppendLine("<Document>")
        kmlContent.AppendLine($"<name>Flight Path: {dat} - {tim}</name>")
        kmlContent.AppendLine("<description>Exported from FrSky GPS Log to KML by Pete Garyga</description>")

        kmlContent.AppendLine(GenerKMLStyles())
        kmlContent.AppendLine(GenerateStartKML())

        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<name>Flight Path</name>")
        kmlContent.AppendLine("<styleUrl>#flightLine</styleUrl>")
        kmlContent.AppendLine("<LineString>")
        kmlContent.AppendLine("<tessellate>1</tessellate>")
        kmlContent.AppendLine("<altitudeMode>relativeToGround</altitudeMode>")
        kmlContent.AppendLine("<coordinates>")

        For Each row As DataRow In dataTable.Rows
            Dim latitude As String = row(My.Settings.Latitude).ToString()
            Dim longitude As String = row(My.Settings.Longitude).ToString()

            If My.Settings.Use_Altitude Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source) + My.Settings.AltitudeOffset
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                altitude = iAltval
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
        kmlContent.AppendLine("<styleUrl>#PointerStyleMap</styleUrl>")
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

    Private Sub ExportKMLToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim dialogResult1 = dlgSettings.ShowDialog(Me)
    End Sub

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object,
ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
    Handles DataGridView1.CellFormatting
        'colour altitude cells based on min/max settings
        If DataGridView1.Columns(e.ColumnIndex).Name.Equals(My.Settings.Altitude_Source) Then
            If e.Value Is Nothing OrElse e.Value Is DBNull.Value Then
                Return
            End If
            If CInt(e.Value) < My.Settings.MinAltitude Then
                e.CellStyle.BackColor = Color.Red
                e.CellStyle.SelectionBackColor = Color.DarkRed
            ElseIf CInt(e.Value) > My.Settings.MaxAltitude Then
                e.CellStyle.BackColor = Color.LightBlue
                e.CellStyle.SelectionBackColor = Color.Blue

            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        OpenFileDialog1.Filter = "Log Files|*.log;*.csv|All Files|*.*"
        OpenFileDialog1.Title = "Open FrSky GPS Log File"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath = OpenFileDialog1.FileName
            Text = "FrSky Log Viewer - " & filePath

            Dim lines = IO.File.ReadAllLines(filePath)
            Dim dataTable As New DataTable

            ' Assuming the first line contains headers
            Dim headers = lines(0).Split(","c)
            colmn = 0
            GPS = -1
            For Each header In headers
                Try
                    colmn += 1
                    dataTable.Columns.Add(header)
                    If header = My.Settings.GPS_Source Then  ' Special handling for GPS column
                        dataTable.Columns.Add(My.Settings.Latitude)
                        dataTable.Columns.Add(My.Settings.Longitude)
                        GPS = colmn - 1
                    End If
                Catch ex As Exception
                    dataTable.Columns.Add(header + "1")
                End Try
            Next
            ' Add the rest of the lines as rows

            For i = 1 To lines.Length - 1
                Dim rowValues = lines(i).Split(","c)
                dataTable.Rows.Add(rowValues)
                If GPS > -1 AndAlso rowValues(GPS) <> "" Then
                    Dim rowGPS = rowValues(GPS).Split(" "c)
                    dataTable.Rows(i - 1)(My.Settings.Latitude) = rowGPS(0) ' GPS Latitude
                    dataTable.Rows(i - 1)(My.Settings.Longitude) = rowGPS(1) ' GPS Longitude
                End If
            Next
            If headers(headers.Count - 1) = "" Then ' remove empty trailing column if present
                dataTable.Columns.RemoveAt(dataTable.Columns.Count - 1)
            End If
            DataGridView1.DataSource = dataTable
            MyFile = DialogResult.OK
        Else
            MyFile = DialogResult.Cancel
        End If

    End Sub

    Private Sub KMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KMLToolStripMenuItem.Click
        If MyFile = DialogResult.OK Then
            If GPS < 0 Then
                MessageBox.Show("No GPS data in the file. Please open a log file containing GPS data.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
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
            End If
        Else
            MessageBox.Show("No data to export. Please open a log file first.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AnimatedKMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnimatedKMLToolStripMenuItem.Click
        If MyFile = DialogResult.OK Then
            If GPS < 0 Then
                MessageBox.Show("No GPS data in the file. Please open a log file containing GPS data.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "KML Files|*.kml|All Files|*.*"
                saveFileDialog.FileName = Mid(Me.Text, 19) & ".ani.kml"
                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    System.IO.File.WriteAllText(saveFileDialog.FileName, GenerateAniKML())
                    If My.Settings.OpenApp Then
                        ShellExecute(saveFileDialog.FileName)
                    Else
                        MessageBox.Show("Animated KML file exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Else
            MessageBox.Show("No data to export. Please open a log file first.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
