
Imports System.Net
Imports Newtonsoft.Json
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Management

Public Class Form1

    Public Const ASSETS_NAME_FOLDER As String = "\assets\"

    Dim localPath As String
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

        Dim P As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Me.localPath = New Uri(P).LocalPath

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

        Dim query
        Dim objWMI
        Dim diskDrives
        Dim diskDrive
        Dim partitions
        Dim partition ' will contain the drive & partition numbers
        Dim logicalDisks
        Dim logicalDisk ' will contain the drive letter
        Dim partitionIndex As Integer = 1
        Dim logicIndex As Integer = 1

        objWMI = GetObject("winmgmts:\\.\root\cimv2")
        diskDrives = objWMI.ExecQuery("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'") ' First get out the physical drives
        For Each diskDrive In diskDrives
            query = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + diskDrive.DeviceID + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition" ' link the physical drives to the partitions
            partitions = objWMI.ExecQuery(query)
            partitionIndex = 1
            For Each partition In partitions
                If (partitionIndex = 1) Then
                    query = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition.DeviceID + "'} WHERE AssocClass = Win32_LogicalDiskToPartition"  ' link the partitions to the logical disks 
                    logicalDisks = objWMI.ExecQuery(query)
                    logicIndex = 1
                    For Each logicalDisk In logicalDisks
                        If (logicIndex = 1) Then
                            'MessageBox.Show(logicalDisk.DeviceID & " - " & partition.Caption & " - " & diskDrive.Size)

                            Dim dev As Device = New Device()
                            dev.index = diskDrive.Index
                            dev.caption = diskDrive.Model
                            dev.unit = logicalDisk.DeviceID
                            dev.phisicalName = diskDrive.DeviceID
                            dev.size = diskDrive.Size
                            DeviceComboBox.Items.Add("( " & dev.unit & " ) " & dev.caption.Substring(0, 20) & " / " & Util.FormatBytes(dev.size))
                            deviceList.Add(dev)
                        End If
                    Next
                End If
            Next
        Next

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

        'Create assets if not exists
        Dim assets = localPath & ASSETS_NAME_FOLDER
        If Not Directory.Exists(assets) Then
            Directory.CreateDirectory(assets)
        End If

        Dim tmpFolder = assets & Util.GenerateHash()
        If Not Directory.Exists(tmpFolder) Then
            Directory.CreateDirectory(tmpFolder)
        End If

        Dim cmd As String = CreateCmdStep(tmpFolder)
        'MessageBox.Show(cmd)
        RunProcess(cmd, True, True, True)

    End Sub

    Public Sub RunProcess(cmd As String, showWindow As Boolean, waitProcess As Boolean, permanent As Boolean)
        Try
            Extensions.RunCMD("""" & cmd & """", showWindow, waitProcess, permanent)
        Finally

        End Try
    End Sub

    Private Function CreateCmdStep(tmpFolder As String)

        '@echo off
        'set "CMD=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\dd.exe"
        'echo cmd /K ""%CMD%" if=\dev\zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"
        'cmd /K ""%CMD%" if=/dev/zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"

        Dim sb As New System.Text.StringBuilder

        sb.AppendLine("@echo off")
        sb.AppendLine("cls()")
        sb.AppendLine("set ""CMD=" & localPath & "\dd.exe""")
        'sb.AppendLine("echo cmd /K """"%CMD%"" if=\dev\zero of=\\?\Device\Harddisk" & deviceSelected.index & "\Partition0 bs=512 count=1 --size --progress""")
        sb.AppendLine("call /K """"%CMD%"" if=/dev/zero of=\\?\Device\Harddisk" & deviceSelected.index & "\Partition0 bs=512 count=1 --size --progress""")
        sb.AppendLine("")
        sb.AppendLine("")


        'Diskpart commands
        'Select disk 1
        'clean
        'create Partition primary
        'Format fs = ntfs quick

        Dim sb1 As New System.Text.StringBuilder
        sb1.AppendLine("Select disk " & deviceSelected.index)
        sb1.AppendLine("clean")
        sb1.AppendLine("create Partition primary")
        'sb1.AppendLine("Format fs = ntfs quick")

        IO.File.WriteAllText(tmpFolder & "\diskpart_commands.txt", sb1.ToString())


        '@echo off
        'set "COMMANDS=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\assets\diskpart_commands.txt"
        'set "LOGFILE=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\assets\logfile.txt"
        'diskpart / s "%COMMANDS%" > "%LOGFILE%" 

        sb.AppendLine("@echo off")
        sb.AppendLine("cls()")
        sb.AppendLine("set ""COMMANDS=" & tmpFolder & "\diskpart_commands.txt""")
        sb.AppendLine("set ""LOGFILE=" & tmpFolder & "\diskpart_logfile.txt""")
        sb.AppendLine("call diskpart /s ""%COMMANDS%"" > ""%LOGFILE%""")
        sb.AppendLine("")
        sb.AppendLine("")

        '@echo off
        'set "CMD=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\dd.exe"
        'set "ISO=e:\educatux\e.iso"
        'echo cmd / K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=1M --size --progress"
        'cmd / K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=1M --size --progress"

        sb.AppendLine("@echo off")
        sb.AppendLine("cls()")
        sb.AppendLine("set ""CMD=" & localPath & "\dd.exe""")
        sb.AppendLine("set ""ISO=" & IsoFileNameTxt.Text & """")
        sb.AppendLine("echo **************************************")
        sb.AppendLine("echo:")
        sb.AppendLine("echo  EDUCATUX USB PENDRIVE MAGIC " & config.GetKeyValue("version"))
        sb.AppendLine("echo:")
        sb.AppendLine("echo  " & config.GetTranslation(languageCode, "Waint... Transfering data to") & " " & deviceSelected.unit)
        sb.AppendLine("echo:")
        sb.AppendLine("echo **************************************")
        sb.AppendLine("echo Many thanks John Newbigin for the excellent dd project.")
        'sb.AppendLine("echo cmd /K """"%CMD%"" if=""%ISO%"" of=\\?\Device\Harddisk" & deviceSelected.index & "\Partition0 bs=1M --size --progress""")
        sb.AppendLine("call cmd /K """"%CMD%"" if=""%ISO%"" of=\\?\Device\Harddisk" & deviceSelected.index & "\Partition0 bs=1M --size --progress""")
        Dim name As String = tmpFolder & "\steps.cmd"
        IO.File.WriteAllText(name, sb.ToString())
        Return name

    End Function


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
        RefreshBtn.Text = config.GetTranslation(languageCode, "Refresh")


    End Sub



    Private Sub DeviceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DeviceComboBox.SelectedIndexChanged
        Me.deviceSelected = Me.deviceList(DeviceComboBox.SelectedIndex)
        If Not IsNothing(deviceSelected) And Not String.IsNullOrEmpty(IsoFileNameTxt.Text) Then
            CreatePenDriveBtn.Enabled = True
        End If

    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        DeviceComboBox.Items.Clear()
        LoadDevicesCombo()
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
    Public Property index As Integer
    Public Property unit As String
    Public Property caption As String
    Public Property phisicalName As String
    Public Property size As Long
End Class