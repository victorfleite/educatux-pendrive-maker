Imports System.Net
Imports Newtonsoft.Json

Public Class Form1
    Dim WithEvents client As New WebClient
    Dim versionList As List(Of Version)
    Dim versionSelected As Version

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnDownload.Click

        If versionSelected IsNot Nothing Then

            client = New WebClient
            AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
            AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted

            Dim fileName As String = versionSelected.name.Replace(" ", "") & "_" & versionSelected.version & "_" & versionSelected.size & ".iso"
            client.DownloadFileAsync(New Uri(versionSelected.iso), isoFolderName.Text & "\" & fileName)

            btnCancel.Enabled = True
            btnDownload.Enabled = False

            progressBar.Visible = True
            progressBarLabel.Visible = True
            downloadingLabel.Visible = True
            downloadingLabel.Text = "Downloading..."

        Else

            MessageBox.Show("Please, choose one version of Educatux")

        End If

    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        progressBarLabel.Text = Util.FormatBytes(bytesIn) & "/" & Util.FormatBytes(totalBytes)
        progressBar.Value = Integer.Parse(Math.Truncate(percentage).ToString())

    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        btnDownload.Enabled = True
        btnDownload.Text = "Download Complete"

    End Sub


    Private Sub LoadVersionCombo()

        Dim jsonString As String
        jsonString = ApiRest.GetEducatuxVersions()
        Me.versionList = JsonConvert.DeserializeObject(Of List(Of Version))(jsonString)
        comboBoxVersions.Items.Clear()
        For Each version As Version In Me.versionList
            comboBoxVersions.Items.Add(version.name & " - " & version.version & " [ " & version.size & " ]")
        Next
        comboBoxVersions.Text = "Select..."

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Util.CheckForInternetConnection Then

            btnCancel.Visible = False
            btnDownload.Visible = False
            tabControl1.Visible = False
            isoFolderGroup.Visible = False
            noConnectionLabel.Visible = True

        Else

            btnCancel.Enabled = False
            btnDownload.Enabled = True
            LoadVersionCombo()
            isoFolderName.Text = "C:\tmp"


        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click

        client.CancelAsync()
        progressBar.Visible = False
        progressBarLabel.Visible = False
        downloadingLabel.Visible = False
        progressBarLabel.Text = ""
        downloadingLabel.Text = ""
        btnCancel.Enabled = False
        btnDownload.Enabled = True

    End Sub

    Private Sub comboBoxVersions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxVersions.SelectedIndexChanged

        Me.versionSelected = Me.versionList(comboBoxVersions.SelectedIndex)

    End Sub

    Private Sub seachIsoFolderBtn_Click(sender As Object, e As EventArgs) Handles seachIsoFolderBtn.Click

        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then

            isoFolderName.Text = FolderBrowserDialog1.SelectedPath

        End If


    End Sub

End Class


Public Class Version

    Public Property name As String
    Public Property version As String
    Public Property checksum As String
    Public Property iso As String
    Public Property size As String

End Class