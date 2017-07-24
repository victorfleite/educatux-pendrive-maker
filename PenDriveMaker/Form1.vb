﻿Imports System.Net
Imports Newtonsoft.Json
Imports System.IO

Public Class Form1
    Dim config As Config
    Dim languageCode As String
    Dim WithEvents client As New WebClient
    Dim versionList As List(Of Version)
    Dim versionSelected As Version

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.languageCode = "pt_BR"
        Me.config = New Config()
        Me.Text = Me.Text & " - " & config.GetKeyValue("version")
        TranslateAll(languageCode)

        If Not Util.CheckForInternetConnection Then

            BtnCancel.Visible = False
            BtnDownload.Visible = False
            TabControl.Visible = False
            IsoFolderGroup.Visible = False
            advertisingImg.Visible = False
            noConnectionLabel.Visible = True

        Else

            advertisingImg.Visible = True
            BtnCancel.Enabled = False
            BtnDownload.Enabled = True
            LoadVersionCombo()
            IsoFolderName.Text = Me.config.GetKeyValue("isoFolder")
            FolderBrowserDialog1.SelectedPath = IsoFolderName.Text


        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnDownload.Click

        If versionSelected IsNot Nothing Then

            client = New WebClient
            AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
            AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted

            client.DownloadFileAsync(New Uri(versionSelected.iso), IsoFolderName.Text & "\" & versionSelected.filename)

            BtnCancel.Enabled = True
            BtnDownload.Enabled = False

            progressBar.Visible = True
            progressBarLabel.Visible = True
            DownloadingLabel.Visible = True
            DownloadingLabel.Text = config.GetTranslation(languageCode, "Downloading...")

        Else

            MessageBox.Show(config.GetTranslation(languageCode, "Please, choose one version of Educatux"))

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

        BtnDownload.Enabled = True
        DownloadingLabel.Text = config.GetTranslation(languageCode, "Download Complete")
        MessageBox.Show(config.GetTranslation(languageCode, "Download Complete"))

    End Sub


    Private Sub LoadVersionCombo()

        Dim jsonString As String
        jsonString = ApiRest.GetEducatuxVersions()
        Me.versionList = JsonConvert.DeserializeObject(Of List(Of Version))(jsonString)
        comboBoxVersions.Items.Clear()
        For Each version As Version In Me.versionList
            comboBoxVersions.Items.Add(version.name & " - " & version.version & " [ " & version.size & " ]")
        Next
        comboBoxVersions.Text = config.GetTranslation(languageCode, "Select...")

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BtnCancel.Click

        client.CancelAsync()
        progressBar.Visible = False
        progressBarLabel.Visible = False
        DownloadingLabel.Visible = False
        progressBarLabel.Text = ""
        DownloadingLabel.Text = ""
        BtnCancel.Enabled = False
        BtnDownload.Enabled = True

    End Sub

    Private Sub comboBoxVersions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxVersions.SelectedIndexChanged

        Me.versionSelected = Me.versionList(comboBoxVersions.SelectedIndex)

    End Sub

    Private Sub seachIsoFolderBtn_Click(sender As Object, e As EventArgs) Handles SeachIsoFolderBtn.Click

        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then

            IsoFolderName.Text = FolderBrowserDialog1.SelectedPath

        End If


    End Sub

    Private Sub searchIsoBtn_Click(sender As Object, e As EventArgs) Handles SearchIsoBtn.Click

        openIsoVersion.InitialDirectory = FolderBrowserDialog1.SelectedPath
        openIsoVersion.FileName = Nothing


        ' Display the openFile dialog.
        Dim result As DialogResult = openIsoVersion.ShowDialog()

        ' OK button was pressed.
        If (result = DialogResult.OK) Then
            IsoFileNameTxt.Text = openIsoVersion.FileName
            CreatePenDriveBtn.Enabled = True
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

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles CreatePenDriveBtn.Click

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBoxPortuguese.Click
        languageCode = "pt_BR"
        TranslateAll(languageCode)
    End Sub

    Private Sub ToolStripTextBox2_Click(sender As Object, e As EventArgs) Handles ToolStripTextBoxEnglish.Click
        languageCode = "en"
        TranslateAll(languageCode)
    End Sub

    Private Sub TranslateAll(languageCode As String)

        'Menu
        ToolStripMenuItem1.Text = config.GetTranslation(languageCode, "Language")
        ToolStripTextBoxPortuguese.Text = config.GetTranslation(languageCode, "Portuguese")
        ToolStripTextBoxEnglish.Text = config.GetTranslation(languageCode, "English")
        ContactToolStripMenuItem.Text = config.GetTranslation(languageCode, "Contact")
        AboutUsToolStripMenuItem.Text = config.GetTranslation(languageCode, "About us")
        DownloadTab.Text = config.GetTranslation(languageCode, "Download")
        MakePenDriveTab.Text = config.GetTranslation(languageCode, "Create a Pen Drive")
        DownloadingLabel.Text = config.GetTranslation(languageCode, "Downloading...")
        EducatuxVersionLabel.Text = config.GetTranslation(languageCode, "Educatux Versions")
        BtnCancel.Text = config.GetTranslation(languageCode, "Cancel")
        BtnDownload.Text = config.GetTranslation(languageCode, "Download")
        IsoFolderGroup.Text = config.GetTranslation(languageCode, "Iso Folder")
        IsoFolderName.Text = config.GetTranslation(languageCode, "Select a folder for iso")
        SeachIsoFolderBtn.Text = config.GetTranslation(languageCode, "Search Folder")
        IsoFileNameTxt.Text = config.GetTranslation(languageCode, "Select an iso file")
        SearchIsoBtn.Text = config.GetTranslation(languageCode, "Search File")
        CreatePenDriveBtn.Text = config.GetTranslation(languageCode, "Create a Pen Drive")


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