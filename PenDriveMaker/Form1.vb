Imports System.Net
Imports Newtonsoft.Json

Public Class Form1
    Dim WithEvents WC As New WebClient

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnStartDownload.Click
        Dim client As WebClient = New WebClient
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        client.DownloadFileAsync(New Uri("https://downloads.sourceforge.net/project/educatux/Debian/stretch/prod/educatux-debian9-cinnamon-i386.iso?r=https%3A%2F%2Fwww.educatux.com.br%2Fpromo%2Fdownload.php&ts=1500777543&use_mirror=ufpr"), "C:\tmp\educatux.iso")
        btnStartDownload.Text = "Download in Progress"
        btnStartDownload.Enabled = False
        progressBar.Visible = True
    End Sub
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        progressBarLabel.Text = Util.FormatBytes(bytesIn) & "/" & Util.FormatBytes(totalBytes)

        progressBar.Value = Integer.Parse(Math.Truncate(percentage).ToString())
    End Sub
    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MessageBox.Show("Download Complete")
        btnStartDownload.Text = "Start Download"
        btnStartDownload.Enabled = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim jsonString As String
        Dim versions As List(Of Version)

        jsonString = ApiRest.GetEducatuxVersions()
        versions = JsonConvert.DeserializeObject(Of List(Of Version))(jsonString)

        For Each version As Version In versions
            MessageBox.Show(version.version)
        Next
    End Sub
End Class


Public Class Version
    Public Property name As String
    Public Property version As String
    Public Property checksum As String
    Public Property iso As String
End Class