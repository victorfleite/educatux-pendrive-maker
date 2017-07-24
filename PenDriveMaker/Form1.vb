﻿Imports System.Net
Imports Newtonsoft.Json
Imports System.IO

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

            client.DownloadFileAsync(New Uri(versionSelected.iso), isoFolderName.Text & "\" & versionSelected.filename)

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
        MessageBox.Show("Download Complete")

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
            advertisingImg.Visible = False

            noConnectionLabel.Visible = True

        Else

            advertisingImg.Visible = True
            btnCancel.Enabled = False
            btnDownload.Enabled = True
            LoadVersionCombo()
            isoFolderName.Text = "C:\tmp"
            FolderBrowserDialog1.SelectedPath = isoFolderName.Text


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

    Private Sub searchIsoBtn_Click(sender As Object, e As EventArgs) Handles searchIsoBtn.Click

        openIsoVersion.InitialDirectory = FolderBrowserDialog1.SelectedPath
        openIsoVersion.FileName = Nothing


        ' Display the openFile dialog.
        Dim result As DialogResult = openIsoVersion.ShowDialog()

        ' OK button was pressed.
        If (result = DialogResult.OK) Then
            isoFileNameTxt.Text = openIsoVersion.FileName
            createPenDriveBtn.Enabled = True
            'TODO Checksum validation
            Try
                ' Output the requested file in richTextBox1.
                Dim s As Stream = openIsoVersion.OpenFile()
                s.Close()


            Catch exp As Exception
                MessageBox.Show("An error occurred while attempting to load the file. The error is:" _
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine)

            End Try
            Invalidate()


            ' Cancel button was pressed.
        ElseIf (result = DialogResult.Cancel) Then
            Return
        End If





    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles createPenDriveBtn.Click

    End Sub

End Class


Public Class Version

    Public Property name As String
    Public Property version As String
    Public Property checksum As String
    Public Property iso As String
    Public Property size As String
    Public Property filename As String

End Class