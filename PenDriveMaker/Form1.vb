
Imports System.Net
Imports Newtonsoft.Json
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Management

Public Class Form1
    Dim config As Config
    Dim languageCode As String
    Dim WithEvents client As New WebClient
    Dim versionList As New List(Of Version)
    Dim versionSelected As Version = Nothing
    Dim deviceList As New List(Of Device)
    Dim deviceSelected As Device = Nothing

    Dim lastUpdate As DateTime
    Dim lastBytes As Long = 0

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
            LoadDevicesCombo()
            advertisingImg.Visible = True
            BtnCancel.Enabled = False
            BtnDownload.Enabled = True
            LoadVersionCombo()
            IsoFileNameTxt.Text = Nothing
            IsoFolderName.Text = Me.config.GetKeyValue("isoFolder")
            FolderBrowserDialog1.SelectedPath = IsoFolderName.Text


        End If

    End Sub

    Private Sub LoadDevicesCombo()

        Dim Scope As New ManagementScope("\\.\ROOT\cimv2")

        'Get a result of WML query 
        Dim Query As New ObjectQuery("SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'")

        'Create object searcher
        Dim Searcher As New ManagementObjectSearcher(Scope, Query)

        'Get a collection of WMI objects
        Dim queryCollection As ManagementObjectCollection = Searcher.Get

        'Enumerate wmi object 
        For Each currentObject As ManagementObject In queryCollection
            'write out some property value
            Dim dev As Device = New Device()
            dev.caption = currentObject("Caption").ToString
            dev.phisicalName = currentObject("DeviceID").ToString()

            DeviceComboBox.Items.Add("[" & dev.phisicalName & "] " & dev.caption)
            deviceList.Add(dev)
        Next

        'For Each di As System.IO.DriveInfo In My.Computer.FileSystem.Drives
        '    If di.DriveType = IO.DriveType.Removable Then
        '        'For Each di As DriveInfo In DriveInfo.GetDrives
        '        Dim drivesList As List(Of String) = VolumeInfo.GetPhysicalDriveStrings(di)

        '        Dim drives As New StringBuilder
        '        If drivesList.Count > 0 Then
        '            For Each s As String In drivesList
        '                Dim dev As Device = New Device()
        '                dev.name = di.VolumeLabel.ToString
        '                dev.phisicalName = s
        '                dev.unit = di.RootDirectory.FullName
        '                dev.size = di.TotalSize
        '                DeviceComboBox.Items.Add("[" & dev.unit & "] " & dev.name & " - " & Util.FormatBytes(dev.size))
        '                deviceList.Add(dev)
        '            Next
        '        End If
        '    End If

        'Next
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

        'MeasuringTime.Text = GetBytesPerSecond(bytesIn).ToString & " B/s"
    End Sub

    Private Function GetBytesPerSecond(bytes As Long) As Long
        Dim bytesPerSecond As Long = 0
        If lastBytes = 0 Then
            lastUpdate = DateTime.Now
            lastBytes = bytes
            Return 0
        End If

        Dim now = DateTime.Now
        Dim timeSpan = now - lastUpdate
        If Not timeSpan.Seconds = 0 Then
            Dim bytesChange = bytes - lastBytes
            bytesPerSecond = (bytesChange / timeSpan.Seconds)
            lastBytes = bytes
            lastUpdate = now
            Return bytesChange / timeSpan.Seconds
        End If
        Return bytesPerSecond
    End Function


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

            If Not IsNothing(deviceSelected) And Not String.IsNullOrEmpty(IsoFileNameTxt.Text) Then
                CreatePenDriveBtn.Enabled = True
            End If

            ' Cancel button was pressed.
        ElseIf (result = DialogResult.Cancel) Then
                Return
        End If




    End Sub

    Private Function ChecksumValid(fileName As String) As Boolean
        Dim availableChecksum = False
        For Each version As Version In Me.versionList
            MessageBox.Show(Util.sha_256(fileName) & " - " & version.checksum)

            If String.Equals(Util.sha_256(fileName), version.checksum) Then
                availableChecksum = True
            End If
        Next

        Return availableChecksum
    End Function

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles CreatePenDriveBtn.Click

        StartProcess()
        'Dim CreatePenDriveForm As New Form2()
        'CreatePenDriveForm.Show()

        'If ChecksumValid(openIsoVersion.FileName) Then
        'Dim extractPath As String = Path.GetTempPath()
        'ZipFile.ExtractToDirectory(openIsoVersion.FileName, extractPath)

        'Else

        'MessageBox.Show(config.GetTranslation(languageCode, "Iso file is corrupted. Try to download again."))

        'End If
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
        MakePenDriveTab.Text = config.GetTranslation(languageCode, "Create Pen Drives")
        DownloadingLabel.Text = config.GetTranslation(languageCode, "Downloading...")
        EducatuxVersionLabel.Text = config.GetTranslation(languageCode, "Educatux Versions")
        BtnCancel.Text = config.GetTranslation(languageCode, "Cancel")
        BtnDownload.Text = config.GetTranslation(languageCode, "Download")
        IsoFolderGroup.Text = config.GetTranslation(languageCode, "Iso Folder")
        IsoFolderName.Text = config.GetTranslation(languageCode, "Select a folder for iso")
        SeachIsoFolderBtn.Text = config.GetTranslation(languageCode, "Search Folder")
        SelectIsoLabel.Text = config.GetTranslation(languageCode, "File of iso")
        IsoFileNameTxt.Text = config.GetTranslation(languageCode, "Select an iso file")
        SelectPenDriveLabel.Text = config.GetTranslation(languageCode, "Pen Drive Unit")
        SearchIsoBtn.Text = config.GetTranslation(languageCode, "Search File")
        CreatePenDriveBtn.Text = config.GetTranslation(languageCode, "Create a PenDrive Educatux")


    End Sub

    Public Sub StartProcess()

        ' Define variables to track the peak
        ' memory usage of the process.
        Dim peakPagedMem As Long = 0
        Dim peakWorkingSet As Long = 0
        Dim peakVirtualMem As Long = 0

        Dim myProcess As Process = Nothing

        Try

            ' Start the process.
            MessageBox.Show("dd.exe if=" & IsoFileNameTxt.Text & " of=" & deviceSelected.phisicalName & " bs=1M --size --progress")

            'myProcess = Process.Start("dd.exe", "if=" & IsoFileNameTxt.Text & " of=" & deviceSelected.phisicalName & " bs=1M --size --progress")

            ' Display process statistics until
            ' the user closes the program.
            Do

                If Not myProcess.HasExited Then
                    If myProcess.Responding Then
                        Console.WriteLine("Status = Running")
                    Else
                        MessageBox.Show("Process not responding...")
                    End If
                End If
            Loop While Not myProcess.WaitForExit(1000)
            MessageBox.Show("Process finished.")

        Finally
            If Not myProcess Is Nothing Then
                myProcess.Close()
            End If
        End Try

    End Sub

    Private Sub DeviceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DeviceComboBox.SelectedIndexChanged
        Me.deviceSelected = Me.deviceList(DeviceComboBox.SelectedIndex)
        If Not IsNothing(deviceSelected) And Not String.IsNullOrEmpty(IsoFileNameTxt.Text) Then
            CreatePenDriveBtn.Enabled = True
        End If

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

Public Class Device
    Public Property caption As String
    Public Property phisicalName As String
End Class