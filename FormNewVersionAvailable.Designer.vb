<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNewVersionAvailable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNewVersionAvailable))
        ExTableLayoutPanel1 = New TableLayoutPanel()
        LabelNewVersionAvailable = New Label()
        LinkLabelReleaseNotes = New LinkLabel()
        LinkLabelInstallationInstructions = New LinkLabel()
        LinkLabelDownloadPage = New LinkLabel()
        ExTableLayoutPanel2 = New TableLayoutPanel()
        ButtonOK = New Button()
        LabelDisable = New Label()
        ExTableLayoutPanel1.SuspendLayout()
        ExTableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' ExTableLayoutPanel1
        ' 
        ExTableLayoutPanel1.ColumnCount = 1
        ExTableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        ExTableLayoutPanel1.Controls.Add(LabelNewVersionAvailable, 0, 0)
        ExTableLayoutPanel1.Controls.Add(LinkLabelReleaseNotes, 0, 1)
        ExTableLayoutPanel1.Controls.Add(LinkLabelInstallationInstructions, 0, 2)
        ExTableLayoutPanel1.Controls.Add(LinkLabelDownloadPage, 0, 3)
        ExTableLayoutPanel1.Controls.Add(ExTableLayoutPanel2, 0, 4)
        ExTableLayoutPanel1.Location = New Point(0, 0)
        ExTableLayoutPanel1.Name = "ExTableLayoutPanel1"
        ExTableLayoutPanel1.RowCount = 5
        ExTableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        ExTableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        ExTableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        ExTableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        ExTableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        ExTableLayoutPanel1.Size = New Size(384, 161)
        ExTableLayoutPanel1.TabIndex = 0
        ' 
        ' LabelNewVersionAvailable
        ' 
        LabelNewVersionAvailable.Anchor = AnchorStyles.Left
        LabelNewVersionAvailable.AutoSize = True
        LabelNewVersionAvailable.Location = New Point(3, 7)
        LabelNewVersionAvailable.Name = "LabelNewVersionAvailable"
        LabelNewVersionAvailable.Padding = New Padding(5, 0, 0, 0)
        LabelNewVersionAvailable.Size = New Size(46, 15)
        LabelNewVersionAvailable.TabIndex = 0
        LabelNewVersionAvailable.Text = "Label1"
        ' 
        ' LinkLabelReleaseNotes
        ' 
        LinkLabelReleaseNotes.Anchor = AnchorStyles.Left
        LinkLabelReleaseNotes.AutoSize = True
        LinkLabelReleaseNotes.Location = New Point(3, 37)
        LinkLabelReleaseNotes.Name = "LinkLabelReleaseNotes"
        LinkLabelReleaseNotes.Padding = New Padding(5, 0, 0, 0)
        LinkLabelReleaseNotes.Size = New Size(85, 15)
        LinkLabelReleaseNotes.TabIndex = 1
        LinkLabelReleaseNotes.TabStop = True
        LinkLabelReleaseNotes.Text = "Release Notes"
        ' 
        ' LinkLabelInstallationInstructions
        ' 
        LinkLabelInstallationInstructions.Anchor = AnchorStyles.Left
        LinkLabelInstallationInstructions.AutoSize = True
        LinkLabelInstallationInstructions.Location = New Point(3, 67)
        LinkLabelInstallationInstructions.Name = "LinkLabelInstallationInstructions"
        LinkLabelInstallationInstructions.Padding = New Padding(5, 0, 0, 0)
        LinkLabelInstallationInstructions.Size = New Size(135, 15)
        LinkLabelInstallationInstructions.TabIndex = 2
        LinkLabelInstallationInstructions.TabStop = True
        LinkLabelInstallationInstructions.Text = "Installation Instructions"
        ' 
        ' LinkLabelDownloadPage
        ' 
        LinkLabelDownloadPage.Anchor = AnchorStyles.Left
        LinkLabelDownloadPage.AutoSize = True
        LinkLabelDownloadPage.Location = New Point(3, 97)
        LinkLabelDownloadPage.Name = "LinkLabelDownloadPage"
        LinkLabelDownloadPage.Padding = New Padding(5, 0, 0, 0)
        LinkLabelDownloadPage.Size = New Size(100, 15)
        LinkLabelDownloadPage.TabIndex = 3
        LinkLabelDownloadPage.TabStop = True
        LinkLabelDownloadPage.Text = "Downloads Page"
        ' 
        ' ExTableLayoutPanel2
        ' 
        ExTableLayoutPanel2.ColumnCount = 2
        ExTableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        ExTableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 75F))
        ExTableLayoutPanel2.Controls.Add(ButtonOK, 1, 0)
        ExTableLayoutPanel2.Controls.Add(LabelDisable, 0, 0)
        ExTableLayoutPanel2.Dock = DockStyle.Fill
        ExTableLayoutPanel2.Location = New Point(3, 123)
        ExTableLayoutPanel2.Name = "ExTableLayoutPanel2"
        ExTableLayoutPanel2.RowCount = 1
        ExTableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        ExTableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        ExTableLayoutPanel2.Size = New Size(378, 35)
        ExTableLayoutPanel2.TabIndex = 4
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.None
        ButtonOK.Location = New Point(306, 6)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(69, 23)
        ButtonOK.TabIndex = 4
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' LabelDisable
        ' 
        LabelDisable.Anchor = AnchorStyles.Left
        LabelDisable.AutoSize = True
        LabelDisable.Location = New Point(3, 10)
        LabelDisable.Name = "LabelDisable"
        LabelDisable.Size = New Size(282, 15)
        LabelDisable.TabIndex = 5
        LabelDisable.Text = "Disable this check on the Tree Search Options dialog"
        ' 
        ' FormNewVersionAvailable
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(384, 161)
        Controls.Add(ExTableLayoutPanel1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "FormNewVersionAvailable"
        StartPosition = FormStartPosition.CenterParent
        Text = "New Version Available"
        ExTableLayoutPanel1.ResumeLayout(False)
        ExTableLayoutPanel1.PerformLayout()
        ExTableLayoutPanel2.ResumeLayout(False)
        ExTableLayoutPanel2.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents ExTableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelNewVersionAvailable As Label
    Friend WithEvents LinkLabelReleaseNotes As LinkLabel
    Friend WithEvents LinkLabelInstallationInstructions As LinkLabel
    Friend WithEvents LinkLabelDownloadPage As LinkLabel
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ExTableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LabelDisable As Label
End Class
