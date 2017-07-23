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
        Me.btnStartDownload = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.progressBarLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStartDownload
        '
        Me.btnStartDownload.Location = New System.Drawing.Point(146, 251)
        Me.btnStartDownload.Name = "btnStartDownload"
        Me.btnStartDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnStartDownload.TabIndex = 0
        Me.btnStartDownload.Text = "Download"
        Me.btnStartDownload.UseVisualStyleBackColor = True
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(15, 31)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(339, 23)
        Me.progressBar.TabIndex = 1
        Me.progressBar.Visible = False
        '
        'progressBarLabel
        '
        Me.progressBarLabel.AutoSize = True
        Me.progressBarLabel.Location = New System.Drawing.Point(12, 15)
        Me.progressBarLabel.Name = "progressBarLabel"
        Me.progressBarLabel.Size = New System.Drawing.Size(0, 13)
        Me.progressBarLabel.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "LoadCombo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 358)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.progressBarLabel)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.btnStartDownload)
        Me.Name = "Form1"
        Me.Text = "Educatux Magic"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStartDownload As Button
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents progressBarLabel As Label
    Friend WithEvents Button1 As Button
End Class
