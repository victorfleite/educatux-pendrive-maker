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
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.progressBarLabel = New System.Windows.Forms.Label()
        Me.comboBoxVersions = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.downloadTab = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.downloadingLabel = New System.Windows.Forms.Label()
        Me.makePenDriveTab = New System.Windows.Forms.TabPage()
        Me.noConnectionLabel = New System.Windows.Forms.Label()
        Me.isoFolderGroup = New System.Windows.Forms.GroupBox()
        Me.isoFolderName = New System.Windows.Forms.TextBox()
        Me.seachIsoFolderBtn = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tabControl1.SuspendLayout()
        Me.downloadTab.SuspendLayout()
        Me.isoFolderGroup.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.BackColor = System.Drawing.Color.Transparent
        Me.btnDownload.Location = New System.Drawing.Point(240, 109)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 0
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Educatux Versions"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.downloadTab)
        Me.tabControl1.Controls.Add(Me.makePenDriveTab)
        Me.tabControl1.Location = New System.Drawing.Point(12, 221)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(342, 181)
        Me.tabControl1.TabIndex = 6
        '
        'downloadTab
        '
        Me.downloadTab.Controls.Add(Me.btnCancel)
        Me.downloadTab.Controls.Add(Me.downloadingLabel)
        Me.downloadTab.Controls.Add(Me.Label1)
        Me.downloadTab.Controls.Add(Me.comboBoxVersions)
        Me.downloadTab.Controls.Add(Me.btnDownload)
        Me.downloadTab.Controls.Add(Me.progressBarLabel)
        Me.downloadTab.Controls.Add(Me.progressBar)
        Me.downloadTab.Location = New System.Drawing.Point(4, 22)
        Me.downloadTab.Name = "downloadTab"
        Me.downloadTab.Padding = New System.Windows.Forms.Padding(3)
        Me.downloadTab.Size = New System.Drawing.Size(334, 155)
        Me.downloadTab.TabIndex = 0
        Me.downloadTab.Text = "Download"
        Me.downloadTab.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(159, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'downloadingLabel
        '
        Me.downloadingLabel.AutoSize = True
        Me.downloadingLabel.Location = New System.Drawing.Point(237, 21)
        Me.downloadingLabel.Name = "downloadingLabel"
        Me.downloadingLabel.Size = New System.Drawing.Size(78, 13)
        Me.downloadingLabel.TabIndex = 6
        Me.downloadingLabel.Text = "Downloading..."
        Me.downloadingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.downloadingLabel.Visible = False
        '
        'makePenDriveTab
        '
        Me.makePenDriveTab.Location = New System.Drawing.Point(4, 22)
        Me.makePenDriveTab.Name = "makePenDriveTab"
        Me.makePenDriveTab.Padding = New System.Windows.Forms.Padding(3)
        Me.makePenDriveTab.Size = New System.Drawing.Size(334, 255)
        Me.makePenDriveTab.TabIndex = 1
        Me.makePenDriveTab.Text = "Make PenDrive"
        Me.makePenDriveTab.UseVisualStyleBackColor = True
        '
        'noConnectionLabel
        '
        Me.noConnectionLabel.AutoSize = True
        Me.noConnectionLabel.Location = New System.Drawing.Point(37, 205)
        Me.noConnectionLabel.Name = "noConnectionLabel"
        Me.noConnectionLabel.Size = New System.Drawing.Size(293, 13)
        Me.noConnectionLabel.TabIndex = 7
        Me.noConnectionLabel.Text = "No connection. Check the internet connection and try again."
        Me.noConnectionLabel.Visible = False
        '
        'isoFolderGroup
        '
        Me.isoFolderGroup.Controls.Add(Me.isoFolderName)
        Me.isoFolderGroup.Controls.Add(Me.seachIsoFolderBtn)
        Me.isoFolderGroup.Location = New System.Drawing.Point(12, 418)
        Me.isoFolderGroup.Name = "isoFolderGroup"
        Me.isoFolderGroup.Size = New System.Drawing.Size(332, 57)
        Me.isoFolderGroup.TabIndex = 8
        Me.isoFolderGroup.TabStop = False
        Me.isoFolderGroup.Text = "Iso Folder"
        '
        'isoFolderName
        '
        Me.isoFolderName.Enabled = False
        Me.isoFolderName.Location = New System.Drawing.Point(21, 21)
        Me.isoFolderName.Name = "isoFolderName"
        Me.isoFolderName.Size = New System.Drawing.Size(203, 20)
        Me.isoFolderName.TabIndex = 1
        Me.isoFolderName.Text = "Select a folder for iso"
        '
        'seachIsoFolderBtn
        '
        Me.seachIsoFolderBtn.Location = New System.Drawing.Point(230, 18)
        Me.seachIsoFolderBtn.Name = "seachIsoFolderBtn"
        Me.seachIsoFolderBtn.Size = New System.Drawing.Size(88, 23)
        Me.seachIsoFolderBtn.TabIndex = 0
        Me.seachIsoFolderBtn.Text = "Search Folder"
        Me.seachIsoFolderBtn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(338, 190)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 487)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.isoFolderGroup)
        Me.Controls.Add(Me.noConnectionLabel)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.Text = "Educatux Magic"
        Me.tabControl1.ResumeLayout(False)
        Me.downloadTab.ResumeLayout(False)
        Me.downloadTab.PerformLayout()
        Me.isoFolderGroup.ResumeLayout(False)
        Me.isoFolderGroup.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDownload As Button
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents progressBarLabel As Label
    Friend WithEvents comboBoxVersions As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tabControl1 As TabControl
    Friend WithEvents downloadTab As TabPage
    Friend WithEvents makePenDriveTab As TabPage
    Friend WithEvents downloadingLabel As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents noConnectionLabel As Label
    Friend WithEvents isoFolderGroup As GroupBox
    Friend WithEvents isoFolderName As TextBox
    Friend WithEvents seachIsoFolderBtn As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents PictureBox1 As PictureBox
End Class
