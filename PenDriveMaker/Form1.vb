Imports System.Net

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
        Dim reader As String
        reader = ApiRest.GetEducatuxVersions()
        MessageBox.Show(reader)

    End Sub
End Class

