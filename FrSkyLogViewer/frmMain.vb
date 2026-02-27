Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock


Public Class frmMain
    Dim MyFile As DialogResult
    Dim blDataLoaded As Boolean = False

    Dim kmldata As DataTable
    Dim colmn As Integer
    Dim GPS As Integer = -1

    Private Function ShellExecute(ByVal File As String) As Boolean
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
        Return True
    End Function

    Private Function AddOverlay() As String
        Dim kmlContent As New System.Text.StringBuilder()
        kmlContent.AppendLine("<ScreenOverlay>")
        kmlContent.AppendLine("<name>Legend</name>")
        kmlContent.AppendLine("<visibility>0</visibility>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://earth.google.com/images/kml-icons/track-directional/track-0.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("<overlayXY x = ""0"" y=""0"" xunits=""fraction"" yunits=""fraction""/>")
        kmlContent.AppendLine("<screenXY x = ""0.05"" y=""0.05"" xunits=""fraction"" yunits=""fraction""/>")
        kmlContent.AppendLine("<size x = ""0"" y=""0"" xunits=""pixels"" yunits=""pixels""/>")
        kmlContent.AppendLine("</ScreenOverlay>")
        Return kmlContent.ToString
    End Function
    Private Function KMLHeader() As String
        Dim kmlContent As New System.Text.StringBuilder()
        Dim startTime As DateTime = DateTime.Parse(kmldata.Rows(0)("When"))
        Dim endTime As DateTime = DateTime.Parse(kmldata.Rows(kmldata.Rows.Count - 1)("When"))
        startTime = startTime.AddSeconds(-10)
        endTime = endTime.AddSeconds(10)

        kmlContent.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        kmlContent.AppendLine("<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"" xmlns:kml=""http://www.opengis.net/kml/2.2"" xmlns:atom=""http://www.w3.org/2005/Atom"">")
        kmlContent.AppendLine("<Document>")
        kmlContent.AppendLine($"<name>Flight Path: {Text}</name>")
        kmlContent.AppendLine("<description>Exported from FrSky GPS Log to KML by Pete Garyga</description>")
        kmlContent.AppendLine("<visibility>1</visibility>")
        kmlContent.AppendLine("<LookAt>")
        kmlContent.AppendLine($"<longitude>{kmldata.Rows(0)("Longitude")}</longitude>")
        kmlContent.AppendLine($"<latitude>{kmldata.Rows(0)("Latitude")}</latitude>")
        kmlContent.AppendLine("<altitude>0</altitude>")
        kmlContent.AppendLine("<range>1000</range>")
        kmlContent.AppendLine("<tilt>60</tilt>")
        kmlContent.AppendLine("<heading>90</heading>")
        kmlContent.AppendLine("<altitudeMode>clampToGround</altitudeMode>")
        kmlContent.AppendLine("<gx:TimeSpan>")
        kmlContent.AppendLine($"<begin>{startTime.ToString("yyyy-MM-ddTHH:mm:ssZ")}</begin>")
        kmlContent.AppendLine($"<end>{endTime.ToString("yyyy-MM-ddTHH:mm:ssZ")}</end>")
        kmlContent.AppendLine("</gx:TimeSpan>")
        kmlContent.AppendLine("</LookAt>")
        Return kmlContent.ToString
    End Function

    Private Function KMLFooter() As String
        Dim kmlContent As New System.Text.StringBuilder()
        kmlContent.AppendLine("</Document>")
        kmlContent.AppendLine("</kml>")
        Return kmlContent.ToString
    End Function
    Private Function GenerKMLStyles() As String
        Dim kmlContent As New System.Text.StringBuilder()
        Dim col As String = My.Settings.KMLLineColor.A.ToString("X2") & My.Settings.KMLLineColor.B.ToString("X2") & My.Settings.KMLLineColor.G.ToString("X2") & My.Settings.KMLLineColor.R.ToString("X2")

        kmlContent.AppendLine("<Style id=""multiTrack_n"" >")
        kmlContent.AppendLine("<IconStyle>")
        kmlContent.AppendLine("<scale>1</scale>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://earth.google.com/images/kml-icons/track-directional/track-0.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine("<color>99ffac59</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth }</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Style id=""multiTrack_h"" >")
        kmlContent.AppendLine("<IconStyle>")
        kmlContent.AppendLine("<scale>1</scale>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://earth.google.com/images/kml-icons/track-directional/track-0.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine($"<color>{col}</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth * 1.5 }</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<StyleMap id=""multiTrack"" >")
        kmlContent.AppendLine("<Pair>")
        kmlContent.AppendLine("<key>normal</key>")
        kmlContent.AppendLine("<styleUrl>#multiTrack_n</styleUrl>")
        kmlContent.AppendLine("</Pair>")
        kmlContent.AppendLine("<Pair>")
        kmlContent.AppendLine("<key>highlight</key>")
        kmlContent.AppendLine("<styleUrl>#multiTrack_h</styleUrl>")
        kmlContent.AppendLine("</Pair>")
        kmlContent.AppendLine("</StyleMap>")

        kmlContent.AppendLine("<Style id=""line-style-dim"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine("<color>55000000</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth / 2}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Style id=""line-style"">")
        '  kmlContent.AppendLine("<IconStyle> id=""showpin"">")
        '  kmlContent.AppendLine("<Icon>")
        '  kmlContent.AppendLine("<href>http://earth.google.com/images/kml-icons/track-directional/track-0.png</href>")
        '  kmlContent.AppendLine("<scale>2</scale>")
        '  kmlContent.AppendLine("</Icon>")
        '  kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine($"<color>{col}</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Style id=""line-style-red"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine("<color>bb0000ff</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Style id=""line-style-blue"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine("<color>bbff0000</color>")
        kmlContent.AppendLine($"<width>{My.Settings.KMLLineWidth}</width>")
        kmlContent.AppendLine("</LineStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<Style id=""line-style-green"">")
        kmlContent.AppendLine("<LineStyle>")
        kmlContent.AppendLine("<color>bb00ff00</color>")
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

        kmlContent.AppendLine("<Style id=""normalPlacemark"" >")
        kmlContent.AppendLine("<IconStyle>")
        kmlContent.AppendLine("<Icon>")
        kmlContent.AppendLine("<href>http://maps.google.com/mapfiles/kml/paddle/red-blank.png</href>")
        kmlContent.AppendLine("</Icon>")
        kmlContent.AppendLine("</IconStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine("<StyleMap id=""PointerStyleMap"" >")
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

        kmlContent.AppendLine("<Schema id=""schema"" >")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""throttle"" type=""int"">")
        kmlContent.AppendLine("<displayName>Throttle</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""elevator"" type=""int"">")
        kmlContent.AppendLine("<displayName>Elevator</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""rudder"" type=""int"">")
        kmlContent.AppendLine("<displayName>Rudder</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""aileron"" type=""int"">")
        kmlContent.AppendLine("<displayName>Aileron</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""speed"" type=""float"">")
        kmlContent.AppendLine("<displayName>Speed (kph)</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("<gx:SimpleArrayField name=""altitude"" type=""float"">")
        kmlContent.AppendLine("<displayName>Altitude (m)</displayName>")
        kmlContent.AppendLine("</gx:SimpleArrayField>")
        kmlContent.AppendLine("</Schema>")
        Return kmlContent.ToString
    End Function
    Private Function GenerateEndPointKML(iPos As Integer) As String
        Dim altitude As String = kmldata.Rows(iPos)("altitude").ToString()
        Dim latitude As String = kmldata.Rows(iPos)("Latitude").ToString()
        Dim longitude As String = kmldata.Rows(iPos)("Longitude").ToString()
        Dim kmlContent As New System.Text.StringBuilder()

        kmlContent.AppendLine("<Placemark>")
        If iPos = 0 Then
            kmlContent.AppendLine("<name>Start</name>")
        Else
            kmlContent.AppendLine("<name>End</name>")
        End If

        kmlContent.AppendLine("<styleUrl>#PointerStyleMap</styleUrl>")
        kmlContent.AppendLine("<Point>")
        kmlContent.AppendLine("<coordinates>")
        kmlContent.AppendLine($"{longitude},{latitude},{altitude}")
        kmlContent.AppendLine("</coordinates>")
        kmlContent.AppendLine("</Point>")
        kmlContent.AppendLine("</Placemark>")
        Return kmlContent.ToString
    End Function


    Private Function GenerateKML() As String
        Dim kmlContent As New System.Text.StringBuilder

        Dim latitude As String
        Dim longitude As String
        Dim lastLatitude As String
        Dim lastLongitude As String
        Dim altitude As String
        Dim lastAltitude As String

        Dim timGPS As String

        kmlContent.AppendLine("<Folder>")
        kmlContent.AppendLine("<name>Static Flight Path</name>")
        kmlContent.AppendLine("<visibility>1</visibility>")


        For Each row As DataRow In kmldata.Rows
            latitude = row("Latitude").ToString()
            longitude = row("Longitude").ToString()
            altitude = row("altitude").ToString()
            lastLatitude = row("lastLatitude").ToString()
            lastLongitude = row("lastLongitude").ToString()
            lastAltitude = row("lastAltitude").ToString()
            timGPS = row("When").ToString()
            If Not String.IsNullOrEmpty(lastLatitude) AndAlso Not String.IsNullOrEmpty(lastLongitude) AndAlso Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) AndAlso (latitude <> lastLatitude And longitude <> lastLongitude) Then
                kmlContent.AppendLine("<Placemark>")
                kmlContent.AppendLine($"<name>{timGPS} - {altitude}m</name>")
                kmlContent.AppendLine("<styleUrl>#line-style-dim</styleUrl>")
                kmlContent.AppendLine("<LineString>")
                kmlContent.AppendLine($"<altitudeMode>{My.Settings.KMLAltitudeMode}</altitudeMode>")
                kmlContent.AppendLine("<visibility>0</visibility>")
                kmlContent.AppendLine("<tessellate>1</tessellate>")
                kmlContent.AppendLine("<coordinates>")
                kmlContent.AppendLine($"{lastLongitude},{lastLatitude},{lastAltitude},{longitude},{latitude},{altitude}")
                kmlContent.AppendLine("</coordinates>")
                kmlContent.AppendLine("</LineString>")
                kmlContent.AppendLine("</Placemark>")
            End If
        Next

        kmlContent.AppendLine("</Folder>")

        Return kmlContent.ToString
    End Function

    Private Function GenerateAniKML() As String
        Dim kmlContent As New System.Text.StringBuilder
        Dim kmlCoords As New System.Text.StringBuilder

        Dim i As Integer = 0

        kmlContent.AppendLine($"<name>Colour Coded Animated Flight Path: {Text}</name>")
        kmlContent.AppendLine("<description>Exported from FrSky GPS Log to KML by Pete Garyga</description>")
        kmlContent.AppendLine("<open>1</open>")

        kmlContent.AppendLine("<gx:Tour>")
        kmlContent.AppendLine("<name>Double-click here to see the animated flight path</name>")
        kmlContent.AppendLine("<gx:Playlist>")
        kmlContent.AppendLine("<gx:Wait> <gx:duration>0.1</gx:duration></gx:Wait> <!-- short pause at the beginning -->")

        For Each row As DataRow In kmldata.Rows
            Dim GPSWhen As String = row("When").ToString()
            Dim GPSLat As String = row("Latitude").ToString()
            Dim GPSLong As String = row("Longitude").ToString()
            Dim GPSAlt As String = row("Altitude").ToString()
            Dim GPSspeed As Long = row("Speed")
            Dim lastLatitude As String = row("LastLatitude").ToString()
            Dim lastLongitude As String = row("LastLongitude").ToString()
            Dim lastAltitude As String = row("LastAltitude").ToString()
            Dim Pitch As Long = row("Pitch")

            If lastLongitude <> "" AndAlso lastLatitude <> "" Then

                kmlContent.AppendLine("<gx:AnimatedUpdate>")
                kmlContent.AppendLine("<Update>")
                kmlContent.AppendLine("<Change>")
                kmlContent.AppendLine($"<Placemark targetId=""{i}"">")
                kmlContent.AppendLine("<visibility>1</visibility>")
                ' kmlContent.AppendLine("<IconStyle targetId = ""showpin"" >")
                'kmlContent.AppendLine("<scale>20.0</scale>")
                'kmlContent.AppendLine("</IconStyle>")
                kmlContent.AppendLine("</Placemark>")
                kmlContent.AppendLine("</Change>")
                kmlContent.AppendLine("</Update>")
                kmlContent.AppendLine("</gx:AnimatedUpdate>")
                kmlContent.AppendLine($"<gx:Wait><gx:duration>{My.Settings.AnnimationDelay}</gx:duration></gx:Wait>")

                kmlCoords.AppendLine($"<Placemark id=""{i}"">")
                kmlCoords.AppendLine($"<name>{GPSWhen} - Alt:{GPSAlt}m Speed:{GPSspeed}kmh</name>")
                If i = 0 Then
                    kmlCoords.AppendLine("<visibility>1</visibility>")
                Else
                    kmlCoords.AppendLine("<visibility>0</visibility>")
                End If

                kmlCoords.AppendLine("<tessellate>1</tessellate>")

                'Select Case (Pitch)
                'Case < 5
                'kmlCoords.AppendLine("<styleUrl>#line-style-red</styleUrl>")
                'Case = 0
                'kmlCoords.AppendLine("<styleUrl>#line-style-blue</styleUrl>")
                'Case > 5
                'kmlCoords.AppendLine("<styleUrl>#line-style-green</styleUrl>")
                'Case Else
                'kmlCoords.AppendLine("<styleUrl>#line-style</styleUrl>")
                'End Select

                Select Case (GPSAlt - lastAltitude)
                    Case <= -5
                        kmlCoords.AppendLine("<styleUrl>#line-style-red</styleUrl>")
                    Case = 0
                        kmlCoords.AppendLine("<styleUrl>#line-style-blue</styleUrl>")
                    Case >= 5
                        kmlCoords.AppendLine("<styleUrl>#line-style-green</styleUrl>")
                    Case Else
                        kmlCoords.AppendLine("<styleUrl>#line-style</styleUrl>")
                End Select

                kmlCoords.AppendLine("<LineString>")
                kmlCoords.AppendLine($"<altitudeMode>{My.Settings.KMLAltitudeMode}</altitudeMode>")
                kmlCoords.AppendLine("<coordinates>")
                kmlCoords.AppendLine($"{GPSLong},{GPSLat},{GPSAlt},{lastLongitude},{lastLatitude},{lastAltitude}")
                kmlCoords.AppendLine("</coordinates>")
                kmlCoords.AppendLine("</LineString>")
                'kmlCoords.AppendLine("<Point>")                 kmlCoords.AppendLine($"<coordinates>{GPSLong},{GPSLat},{GPSAlt}</coordinates>")                 kmlCoords.AppendLine("</Point>")
                kmlCoords.AppendLine("</Placemark>")
            End If
            i += 1
        Next

        kmlContent.AppendLine("<gx:Wait> <gx:duration>1</gx:duration></gx:Wait>")
        kmlContent.AppendLine("</gx:Playlist>")
        kmlContent.AppendLine("</gx:Tour>")

        kmlContent.AppendLine("<Folder>")
        kmlContent.AppendLine("<name>Animated Flight Path</name>")
        kmlContent.AppendLine("<Style>")
        kmlContent.AppendLine("<ListStyle>")
        'kmlContent.AppendLine("<listItemType>checkHideChildren</listItemType>")
        kmlContent.AppendLine("</ListStyle>")
        kmlContent.AppendLine("</Style>")

        kmlContent.AppendLine(kmlCoords.ToString())

        kmlContent.AppendLine("</Folder>")

        Return kmlContent.ToString

    End Function
    Private Function GenerateTrackKML() As String
        Dim kmlContent As New System.Text.StringBuilder
        Dim kmlCoords As New System.Text.StringBuilder
        Dim kmlRudderDataVals As New System.Text.StringBuilder
        Dim kmlElevatorDataVals As New System.Text.StringBuilder
        Dim kmlThrottleDataVals As New System.Text.StringBuilder
        Dim kmlAileronDataVals As New System.Text.StringBuilder
        Dim kmlSpeedDataVals As New System.Text.StringBuilder
        Dim kmlAltitudeDataVals As New System.Text.StringBuilder

        kmlContent.AppendLine("<Folder>")
        kmlContent.AppendLine("<name>Flight Track</name>")
        kmlContent.AppendLine("<Placemark>")
        kmlContent.AppendLine("<visibility>0</visibility>")
        'kmlContent.AppendLine("<name>Flight</name>")
        kmlContent.AppendLine("<styleUrl>#multiTrack</styleUrl>")
        kmlContent.AppendLine("<gx:Track>")
        kmlContent.AppendLine($"<altitudeMode>{My.Settings.KMLAltitudeMode}</altitudeMode>")
        ' kmlContent.AppendLine("<extrude>1</extrude>")
        kmlContent.AppendLine("<gx:interpolate> 1</gx:interpolate>")

        Dim startTime As DateTime = DateTime.Parse(kmldata.Rows(0)("When"))
        Dim endTime As DateTime = DateTime.Parse(kmldata.Rows(kmldata.Rows.Count - 1)("When"))
        startTime = startTime.AddSeconds(-60)
        endTime = endTime.AddSeconds(30)

        Dim GPSLat0 As String = kmldata.Rows(0)("Latitude").ToString()
        Dim GPSLong0 As String = kmldata.Rows(0)("Longitude").ToString()
        Dim GPSAlt0 As String = kmldata.Rows(0)("Altitude").ToString()

        kmlContent.AppendLine($"<when>{startTime.ToString("yyyy-MM-ddTHH:mm:ssZ")}</when>")

        kmlCoords.AppendLine($"<gx:coord>{GPSLong0} {GPSLat0} {GPSAlt0}</gx:coord>")

        kmlAileronDataVals.AppendLine("<gx:value> </gx:value>")
        kmlElevatorDataVals.AppendLine("<gx:value> </gx:value>")
        kmlThrottleDataVals.AppendLine("<gx:value> </gx:value>")
        kmlRudderDataVals.AppendLine("<gx:value> </gx:value>")
        kmlSpeedDataVals.AppendLine("<gx:value> </gx:value>")
        kmlAltitudeDataVals.AppendLine("<gx:value> </gx:value>")

        For Each row As DataRow In kmldata.Rows
            Dim GPSWhen As String = row("When").ToString()
            Dim GPSLat As String = row("Latitude").ToString()
            Dim GPSLong As String = row("Longitude").ToString()
            Dim GPSAlt As String = row("Altitude").ToString()
            Dim LastAltitude As String = row("LastAltitude").ToString()
            Dim GPSspeed As Long = row("Speed")
            'Dim RXBatt As Long = row("RXBatt(V)")
            Dim AccX As Long = row("AccX(g)")
            Dim AccY As Long = row("AccY(g)")
            Dim AccZ As Long = row("AccZ(g)")
            Dim Rudder As Integer = row("Rudder")
            Dim Elevator As Integer = row("Elevator")
            Dim Throttle As Integer = row("Throttle")
            Dim Aileron As Integer = row("Aileron")

            kmlContent.AppendLine($"<when>{GPSWhen}</when>")
            kmlCoords.AppendLine($"<gx:coord>{GPSLong} {GPSLat} {GPSAlt}</gx:coord>")



            '          Select Case (GPSAlt - LastAltitude)
            '         Case <= -5
            '        kmlCoords.AppendLine("<styleUrl>#line-style-red</styleUrl>")
            '       Case = 0
            '      kmlCoords.AppendLine("<styleUrl>#line-style-blue</styleUrl>")
            '     Case >= 5
            '    kmlCoords.AppendLine("<styleUrl>#line-style-green</styleUrl>")
            '   Case Else
            '  kmlCoords.AppendLine("<styleUrl>#line-style</styleUrl>")
            ' End Select

            kmlAileronDataVals.AppendLine($"<gx:value>{Aileron}</gx:value>")
            kmlElevatorDataVals.AppendLine($"<gx:value>{Elevator}</gx:value>")
            kmlThrottleDataVals.AppendLine($"<gx:value>{Throttle}</gx:value>")
            kmlRudderDataVals.AppendLine($"<gx:value>{Rudder}</gx:value>")
            kmlSpeedDataVals.AppendLine($"<gx:value>{GPSspeed}</gx:value>")
            kmlAltitudeDataVals.AppendLine($"<gx:value>{GPSAlt}</gx:value>")
        Next

        GPSLat0 = kmldata.Rows(kmldata.Rows.Count - 1)("Latitude").ToString()
        GPSLong0 = kmldata.Rows(kmldata.Rows.Count - 1)("Longitude").ToString()
        GPSAlt0 = kmldata.Rows(kmldata.Rows.Count - 1)("Altitude").ToString()

        kmlContent.AppendLine($"<when>{endTime.ToString("yyyy-MM-ddTHH:mm:ssZ")}</when>")
        kmlCoords.AppendLine($"<gx:coord>{GPSLong0} {GPSLat0} {GPSAlt0}</gx:coord>")

        kmlAileronDataVals.AppendLine("<gx:value> </gx:value>")
        kmlElevatorDataVals.AppendLine("<gx:value> </gx:value>")
        kmlThrottleDataVals.AppendLine("<gx:value> </gx:value>")
        kmlRudderDataVals.AppendLine("<gx:value> </gx:value>")
        kmlSpeedDataVals.AppendLine("<gx:value> </gx:value>")
        kmlAltitudeDataVals.AppendLine("<gx:value> </gx:value>")

        kmlContent.AppendLine(kmlCoords.ToString())

        kmlContent.AppendLine("<ExtendedData>")
        kmlContent.AppendLine("<SchemaData schemaUrl=""#schema"" >")

        kmlContent.AppendLine("<gx:SimpleArrayData name=""aileron"">")
        kmlContent.AppendLine(kmlAileronDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")
        kmlContent.AppendLine("<gx:SimpleArrayData name=""elevator"">")
        kmlContent.AppendLine(kmlElevatorDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")
        kmlContent.AppendLine("<gx:SimpleArrayData name=""throttle"">")
        kmlContent.AppendLine(kmlThrottleDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")
        kmlContent.AppendLine("<gx:SimpleArrayData name=""rudder"">")
        kmlContent.AppendLine(kmlRudderDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")
        kmlContent.AppendLine("<gx:SimpleArrayData name=""speed"">")
        kmlContent.AppendLine(kmlSpeedDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")
        kmlContent.AppendLine("<gx:SimpleArrayData name=""altitude"">")
        kmlContent.AppendLine(kmlAltitudeDataVals.ToString())
        kmlContent.AppendLine("</gx:SimpleArrayData>")

        kmlContent.AppendLine("</SchemaData>")
        kmlContent.AppendLine("</ExtendedData>")

        kmlContent.AppendLine("</gx:Track>")
        kmlContent.AppendLine("</Placemark>")
        kmlContent.AppendLine("</Folder>")

        Return kmlContent.ToString
    End Function

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim dialogResult1 = dlgSettings.ShowDialog(Me)
    End Sub

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object,
ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
    Handles DataGridView1.CellFormatting
        'colour altitude cells based on min/max settings
        If DataGridView1.Columns(e.ColumnIndex).Name.Equals(My.Settings.Altitude_Source) Then
            If e.Value Is Nothing OrElse IsNumeric(e.Value) = False OrElse e.Value Is DBNull.Value Then
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

    Private Sub PopulateKMLData()
        Dim lastLatitude As String = ""
        Dim lastLongitude As String = ""
        Dim timGPS As String

        Dim csvTable As DataTable = DataGridView1.DataSource

        Dim Altitude As Long = 0
        Dim lastAltitude As Long = 0
        Dim altCol = My.Settings.Altitude_Source

        kmldata = New DataTable
        kmldata.Columns.Add("When")
        kmldata.Columns.Add("Latitude")
        kmldata.Columns.Add("Longitude")
        kmldata.Columns.Add("LastLatitude")
        kmldata.Columns.Add("LastLongitude")
        kmldata.Columns.Add("Altitude")
        kmldata.Columns.Add("LastAltitude")
        kmldata.Columns.Add("Speed")
        kmldata.Columns.Add("RXBatt(V)")
        kmldata.Columns.Add("AccX(g)")
        kmldata.Columns.Add("AccY(g)")
        kmldata.Columns.Add("AccZ(g)")
        kmldata.Columns.Add("Rudder")
        kmldata.Columns.Add("Elevator")
        kmldata.Columns.Add("Throttle")
        kmldata.Columns.Add("Aileron")
        kmldata.Columns.Add("Pitch")
        kmldata.Columns.Add("Roll")

        If csvTable.Columns(My.Settings.GPS_Source) IsNot Nothing Then
            GPS = csvTable.Columns(My.Settings.GPS_Source).Ordinal
        Else
            GPS = -1
            MessageBox.Show("GPS column not found in the data. Please check your settings and ensure the GPS source column is correct.", "GPS Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        For Each row As DataRow In DataGridView1.DataSource.Rows
            Dim latitude As String = ""
            Dim longitude As String = ""
            If GPS >= 0 Then
                Dim rowGPS = row(GPS).Split(" "c)
                If rowGPS.Length > 1 Then
                    latitude = rowGPS(0)
                    longitude = rowGPS(1)
                End If
            End If

            If My.Settings.Use_Altitude AndAlso DataGridView1.DataSource.Columns.Contains(altCol) AndAlso IsNumeric(row(altCol)) Then
                Dim iAltval As Long = row(My.Settings.Altitude_Source) + My.Settings.AltitudeOffset
                If iAltval < My.Settings.MinAltitude Then iAltval = My.Settings.MinAltitude
                If iAltval > My.Settings.MaxAltitude Then iAltval = My.Settings.MaxAltitude
                Altitude = iAltval
            End If
            If Not String.IsNullOrEmpty(latitude) AndAlso Not String.IsNullOrEmpty(longitude) AndAlso (latitude <> lastLatitude And longitude <> lastLongitude) Then 'Good data
                If lastLatitude = "" Then lastLatitude = latitude
                If lastLongitude = "" Then lastLongitude = longitude
                '   If row("GPS clock()") IsNot DBNull.Value AndAlso row("GPS clock()") <> "" Then
                '   Dim dt As DateTime = DateTime.Parse(row("GPS clock()").ToString())
                '   If DatePart(DateInterval.Hour, dt) > 0 Then
                '   timGPS = dt.ToString("yyyy-MM-ddTHH:mm:ssZ")
                ' Else
                '     timGPS = row("Date").ToString() & "T" & row("Time").ToString() & "Z"
                ' End If
                ' Else
                timGPS = row("Date").ToString() & "T" & row("Time").ToString() & "Z"
                '    End If
                'Add a row to KML data table
                Dim rowValues(kmldata.Columns.Count - 1)
                rowValues(0) = timGPS
                rowValues(1) = latitude
                rowValues(2) = longitude
                rowValues(3) = lastLatitude
                rowValues(4) = lastLongitude
                rowValues(5) = Altitude
                rowValues(6) = lastAltitude
                rowValues(7) = row("GPS speed(km/h)")
                rowValues(8) = row("RXBatt(V)")
                rowValues(9) = row("AccX(g)")
                rowValues(10) = row("AccY(g)")
                rowValues(11) = row("AccZ(g)")
                rowValues(12) = row("Rudder")
                rowValues(13) = row("Elevator")
                rowValues(14) = row("Throttle")
                rowValues(15) = row("Aileron")
                rowValues(16) = row("P.angle(°)")
                rowValues(17) = row("R.angle(°)")

                kmldata.Rows.Add(rowValues)

                lastLatitude = latitude
                lastLongitude = longitude
                lastAltitude = Altitude
            End If
        Next

    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        OpenFileDialog1.Filter = "Log Files|*.log;*.csv|All Files|*.*"
        OpenFileDialog1.Title = "Open FrSky GPS Log File"
        OpenFileDialog1.FileName = My.Settings.Filename
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath = OpenFileDialog1.FileName
            Text = "FrSky Log Viewer - " & filePath

            Dim lines = IO.File.ReadAllLines(filePath)
            Dim dataTable As New DataTable

            ' Assuming the first line contains headers
            Dim headers = lines(0).Split(","c)

            For Each header In headers
                Try
                    dataTable.Columns.Add(header)
                Catch ex As Exception
                    dataTable.Columns.Add(header + "1")
                End Try
            Next
            For i = 1 To lines.Length - 1
                Dim rowValues() = lines(i).Split(","c)
                If dataTable.Columns.Count = rowValues.Count Then
                    dataTable.Rows.Add(rowValues)
                End If
            Next
            If dataTable.Columns.Contains("Column1") Then
                dataTable.Columns.Remove("Column1")
            End If

            DataGridView1.DataSource = dataTable
            PopulateKMLData()
            MyFile = DialogResult.OK
            blDataLoaded = True
            My.Settings.Filename = OpenFileDialog1.FileName
        Else
            MyFile = DialogResult.Cancel
        End If

    End Sub

    Private Sub KMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KMLToolStripMenuItem.Click
        If blDataLoaded Then
            If GPS < 0 Then
                MessageBox.Show("No GPS data in the file. Please open a log file containing GPS data.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "KML Files|*.kml|All Files|*.*"
                saveFileDialog.FileName = Mid(Me.Text, 19) & ".kml"
                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim kmlContent As New System.Text.StringBuilder

                    kmlContent.AppendLine(KMLHeader())
                    kmlContent.AppendLine(AddOverlay())
                    kmlContent.AppendLine(GenerKMLStyles())
                    kmlContent.AppendLine(GenerateEndPointKML(0))

                    kmlContent.Append(GenerateKML())
                    kmlContent.Append(GenerateAniKML())
                    kmlContent.Append(GenerateTrackKML())
                    kmlContent.AppendLine(GenerateEndPointKML(kmldata.Rows.Count - 1))
                    kmlContent.AppendLine(KMLFooter())

                    System.IO.File.WriteAllText(saveFileDialog.FileName, kmlContent.ToString)
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


    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        If blDataLoaded Then

            frmCharts.ShowDialog(Me)
        Else
            MessageBox.Show("No data to view. Please open a log file first.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class
