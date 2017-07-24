<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BtnDownload = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.progressBarLabel = New System.Windows.Forms.Label()
        Me.comboBoxVersions = New System.Windows.Forms.ComboBox()
        Me.EducatuxVersionLabel = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.DownloadTab = New System.Windows.Forms.TabPage()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.DownloadingLabel = New System.Windows.Forms.Label()
        Me.MakePenDriveTab = New System.Windows.Forms.TabPage()
        Me.CreatePenDriveBtn = New System.Windows.Forms.Button()
        Me.IsoFileNameTxt = New System.Windows.Forms.TextBox()
        Me.SearchIsoBtn = New System.Windows.Forms.Button()
        Me.noConnectionLabel = New System.Windows.Forms.Label()
        Me.IsoFolderGroup = New System.Windows.Forms.GroupBox()
        Me.IsoFolderName = New System.Windows.Forms.TextBox()
        Me.SeachIsoFolderBtn = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.advertisingImg = New System.Windows.Forms.PictureBox()
        Me.openIsoVersion = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBoxPortuguese = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBoxEnglish = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl.SuspendLayout()
        Me.DownloadTab.SuspendLayout()
        Me.MakePenDriveTab.SuspendLayout()
        Me.IsoFolderGroup.SuspendLayout()
        CType(Me.advertisingImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnDownload
        '
        Me.BtnDownload.BackColor = System.Drawing.Color.Transparent
        Me.BtnDownload.Location = New System.Drawing.Point(240, 109)
        Me.BtnDownload.Name = "BtnDownload"
        Me.BtnDownload.Size = New System.Drawing.Size(75, 23)
        Me.BtnDownload.TabIndex = 0
        Me.BtnDownload.Text = "Download"
        Me.BtnDownload.UseVisualStyleBackColor = False
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(17, 37)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(298, 12)
        Me.progressBar.TabIndex = 1
        Me.progressBar.Visible = False
        '
        'progressBarLabel
        '
        Me.progressBarLabel.AutoSize = True
        Me.progressBarLabel.Location = New System.Drawing.Point(15, 21)
        Me.progressBarLabel.Name = "progressBarLabel"
        Me.progressBarLabel.Size = New System.Drawing.Size(0, 13)
        Me.progressBarLabel.TabIndex = 2
        Me.progressBarLabel.Visible = False
        '
        'comboBoxVersions
        '
        Me.comboBoxVersions.FormattingEnabled = True
        Me.comboBoxVersions.Location = New System.Drawing.Point(17, 82)
        Me.comboBoxVersions.Name = "comboBoxVersions"
        Me.comboBoxVersions.Size = New System.Drawing.Size(298, 21)
        Me.comboBoxVersions.TabIndex = 4
        '
        'EducatuxVersionLabel
        '
        Me.EducatuxVersionLabel.AutoSize = True
        Me.EducatuxVersionLabel.Location = New System.Drawing.Point(14, 66)
        Me.EducatuxVersionLabel.Name = "EducatuxVersionLabel"
        Me.EducatuxVersionLabel.Size = New System.Drawing.Size(95, 13)
        Me.EducatuxVersionLabel.TabIndex = 5
        Me.EducatuxVersionLabel.Text = "Educatux Versions"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.DownloadTab)
        Me.TabControl.Controls.Add(Me.MakePenDriveTab)
        Me.TabControl.Location = New System.Drawing.Point(12, 29)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(342, 188)
        Me.TabControl.TabIndex = 6
        '
        'DownloadTab
        '
        Me.DownloadTab.Controls.Add(Me.BtnCancel)
        Me.DownloadTab.Controls.Add(Me.DownloadingLabel)
        Me.DownloadTab.Controls.Add(Me.EducatuxVersionLabel)
        Me.DownloadTab.Controls.Add(Me.comboBoxVersions)
        Me.DownloadTab.Controls.Add(Me.BtnDownload)
        Me.DownloadTab.Controls.Add(Me.progressBarLabel)
        Me.DownloadTab.Controls.Add(Me.progressBar)
        Me.DownloadTab.Location = New System.Drawing.Point(4, 22)
        Me.DownloadTab.Name = "DownloadTab"
        Me.DownloadTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DownloadTab.Size = New System.Drawing.Size(334, 162)
        Me.DownloadTab.TabIndex = 0
        Me.DownloadTab.Text = "Download"
        Me.DownloadTab.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.Location = New System.Drawing.Point(159, 109)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'DownloadingLabel
        '
        Me.DownloadingLabel.AutoSize = True
        Me.DownloadingLabel.Location = New System.Drawing.Point(205, 21)
        Me.DownloadingLabel.Name = "DownloadingLabel"
        Me.DownloadingLabel.Size = New System.Drawing.Size(78, 13)
        Me.DownloadingLabel.TabIndex = 6
        Me.DownloadingLabel.Text = "Downloading..."
        Me.DownloadingLabel.Visible = False
        '
        'MakePenDriveTab
        '
        Me.MakePenDriveTab.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.MakePenDriveTab.Controls.Add(Me.CreatePenDriveBtn)
        Me.MakePenDriveTab.Controls.Add(Me.IsoFileNameTxt)
        Me.MakePenDriveTab.Controls.Add(Me.SearchIsoBtn)
        Me.MakePenDriveTab.Location = New System.Drawing.Point(4, 22)
        Me.MakePenDriveTab.Name = "MakePenDriveTab"
        Me.MakePenDriveTab.Padding = New System.Windows.Forms.Padding(3)
        Me.MakePenDriveTab.Size = New System.Drawing.Size(334, 162)
        Me.MakePenDriveTab.TabIndex = 1
        Me.MakePenDriveTab.Text = "Create a Pen Drive"
        Me.MakePenDriveTab.UseVisualStyleBackColor = True
        '
        'CreatePenDriveBtn
        '
        Me.CreatePenDriveBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.CreatePenDriveBtn.Enabled = False
        Me.CreatePenDriveBtn.Location = New System.Drawing.Point(97, 105)
        Me.CreatePenDriveBtn.Name = "CreatePenDriveBtn"
        Me.CreatePenDriveBtn.Size = New System.Drawing.Size(148, 35)
        Me.CreatePenDriveBtn.TabIndex = 2
        Me.CreatePenDriveBtn.Text = "Create a Pen Drive"
        Me.CreatePenDriveBtn.UseVisualStyleBackColor = True
        '
        'IsoFileNameTxt
        '
        Me.IsoFileNameTxt.Enabled = False
        Me.IsoFileNameTxt.Location = New System.Drawing.Point(17, 65)
        Me.IsoFileNameTxt.Name = "IsoFileNameTxt"
        Me.IsoFileNameTxt.Size = New System.Drawing.Size(216, 20)
        Me.IsoFileNameTxt.TabIndex = 1
        Me.IsoFileNameTxt.Text = "Select an iso file"
        '
        'SearchIsoBtn
        '
        Me.SearchIsoBtn.Location = New System.Drawing.Point(239, 63)
        Me.SearchIsoBtn.Name = "SearchIsoBtn"
        Me.SearchIsoBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchIsoBtn.TabIndex = 0
        Me.SearchIsoBtn.Text = "Search File"
        Me.SearchIsoBtn.UseVisualStyleBackColor = True
        '
        'noConnectionLabel
        '
        Me.noConnectionLabel.AutoSize = True
        Me.noConnectionLabel.Location = New System.Drawing.Point(37, 238)
        Me.noConnectionLabel.Name = "noConnectionLabel"
        Me.noConnectionLabel.Size = New System.Drawing.Size(293, 13)
        Me.noConnectionLabel.TabIndex = 7
        Me.noConnectionLabel.Text = "No connection. Check the internet connection and try again."
        Me.noConnectionLabel.Visible = False
        '
        'IsoFolderGroup
        '
        Me.IsoFolderGroup.Controls.Add(Me.IsoFolderName)
        Me.IsoFolderGroup.Controls.Add(Me.SeachIsoFolderBtn)
        Me.IsoFolderGroup.Location = New System.Drawing.Point(11, 230)
        Me.IsoFolderGroup.Name = "IsoFolderGroup"
        Me.IsoFolderGroup.Size = New System.Drawing.Size(342, 57)
        Me.IsoFolderGroup.TabIndex = 8
        Me.IsoFolderGroup.TabStop = False
        Me.IsoFolderGroup.Text = "Iso Folder"
        '
        'IsoFolderName
        '
        Me.IsoFolderName.Enabled = False
        Me.IsoFolderName.Location = New System.Drawing.Point(21, 21)
        Me.IsoFolderName.Name = "IsoFolderName"
        Me.IsoFolderName.Size = New System.Drawing.Size(203, 20)
        Me.IsoFolderName.TabIndex = 1
        Me.IsoFolderName.Text = "Select a folder for iso"
        '
        'SeachIsoFolderBtn
        '
        Me.SeachIsoFolderBtn.Location = New System.Drawing.Point(230, 19)
        Me.SeachIsoFolderBtn.Name = "SeachIsoFolderBtn"
        Me.SeachIsoFolderBtn.Size = New System.Drawing.Size(88, 23)
        Me.SeachIsoFolderBtn.TabIndex = 0
        Me.SeachIsoFolderBtn.Text = "Search Folder"
        Me.SeachIsoFolderBtn.UseVisualStyleBackColor = True
        '
        'advertisingImg
        '
        Me.advertisingImg.Image = CType(resources.GetObject("advertisingImg.Image"), System.Drawing.Image)
        Me.advertisingImg.Location = New System.Drawing.Point(12, 302)
        Me.advertisingImg.Name = "advertisingImg"
        Me.advertisingImg.Size = New System.Drawing.Size(338, 196)
        Me.advertisingImg.TabIndex = 9
        Me.advertisingImg.TabStop = False
        '
        'openIsoVersion
        '
        Me.openIsoVersion.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ContactToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(364, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBoxPortuguese, Me.ToolStripTextBoxEnglish})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(71, 20)
        Me.ToolStripMenuItem1.Text = "Language"
        '
        'ToolStripTextBoxPortuguese
        '
        Me.ToolStripTextBoxPortuguese.Name = "ToolStripTextBoxPortuguese"
        Me.ToolStripTextBoxPortuguese.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripTextBoxPortuguese.Text = "Portuguese"
        '
        'ToolStripTextBoxEnglish
        '
        Me.ToolStripTextBoxEnglish.Name = "ToolStripTextBoxEnglish"
        Me.ToolStripTextBoxEnglish.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripTextBoxEnglish.Text = "English"
        '
        'ContactToolStripMenuItem
        '
        Me.ContactToolStripMenuItem.Name = "ContactToolStripMenuItem"
        Me.ContactToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ContactToolStripMenuItem.Text = "Contact"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.BackColor = System.Drawing.Color.GhostWhite
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AboutUsToolStripMenuItem.Text = "About us"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 510)
        Me.Controls.Add(Me.advertisingImg)
        Me.Controls.Add(Me.IsoFolderGroup)
        Me.Controls.Add(Me.noConnectionLabel)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Educatux Magic"
        Me.TabControl.ResumeLayout(False)
        Me.DownloadTab.ResumeLayout(False)
        Me.DownloadTab.PerformLayout()
        Me.MakePenDriveTab.ResumeLayout(False)
        Me.MakePenDriveTab.PerformLayout()
        Me.IsoFolderGroup.ResumeLayout(False)
        Me.IsoFolderGroup.PerformLayout()
        CType(Me.advertisingImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnDownload As Button
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents progressBarLabel As Label
    Friend WithEvents comboBoxVersions As ComboBox
    Friend WithEvents EducatuxVersionLabel As Label
    Friend WithEvents TabControl As TabControl
    Friend WithEvents DownloadTab As TabPage
    Friend WithEvents MakePenDriveTab As TabPage
    Friend WithEvents DownloadingLabel As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents noConnectionLabel As Label
    Friend WithEvents IsoFolderGroup As GroupBox
    Friend WithEvents IsoFolderName As TextBox
    Friend WithEvents SeachIsoFolderBtn As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents advertisingImg As PictureBox
    Friend WithEvents openIsoVersion As OpenFileDialog
    Friend WithEvents IsoFileNameTxt As TextBox
    Friend WithEvents SearchIsoBtn As Button
    Friend WithEvents CreatePenDriveBtn As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContactToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBoxPortuguese As ToolStripMenuItem
    Friend WithEvents ToolStripTextBoxEnglish As ToolStripMenuItem
End Class
