<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTreeSearchOptions
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTreeSearchOptions))
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        ButtonOK = New Button()
        ButtonCancel = New Button()
        ButtonHelp = New Button()
        CheckBoxCheckNewVersion = New CheckBox()
        CheckBoxDisableFineThreadWarning = New CheckBox()
        CheckBoxAddProp = New CheckBox()
        CheckBoxAutoPattern = New CheckBox()
        CheckBoxAlwaysReadExcel = New CheckBox()
        Label4 = New Label()
        ButtonMaterialLibrary = New Button()
        LabelMaterialLibrary = New Label()
        ButtonDataDirectory = New Button()
        LabelDataDirectory = New Label()
        ButtonTemplateDirectory = New Button()
        LabelTemplateDirectory = New Label()
        ButtonLibraryDirectory = New Button()
        LabelLibraryDirectory = New Label()
        ToolTip1 = New ToolTip(components)
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.White
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 11)
        TableLayoutPanel1.Controls.Add(CheckBoxCheckNewVersion, 0, 9)
        TableLayoutPanel1.Controls.Add(CheckBoxDisableFineThreadWarning, 0, 8)
        TableLayoutPanel1.Controls.Add(CheckBoxAddProp, 0, 7)
        TableLayoutPanel1.Controls.Add(CheckBoxAutoPattern, 0, 6)
        TableLayoutPanel1.Controls.Add(CheckBoxAlwaysReadExcel, 0, 5)
        TableLayoutPanel1.Controls.Add(Label4, 0, 4)
        TableLayoutPanel1.Controls.Add(ButtonMaterialLibrary, 0, 3)
        TableLayoutPanel1.Controls.Add(LabelMaterialLibrary, 1, 3)
        TableLayoutPanel1.Controls.Add(ButtonDataDirectory, 0, 2)
        TableLayoutPanel1.Controls.Add(LabelDataDirectory, 1, 2)
        TableLayoutPanel1.Controls.Add(ButtonTemplateDirectory, 0, 1)
        TableLayoutPanel1.Controls.Add(LabelTemplateDirectory, 1, 1)
        TableLayoutPanel1.Controls.Add(ButtonLibraryDirectory, 0, 0)
        TableLayoutPanel1.Controls.Add(LabelLibraryDirectory, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 12
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(623, 343)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.Controls.Add(ButtonOK, 0, 0)
        TableLayoutPanel2.Controls.Add(ButtonCancel, 1, 0)
        TableLayoutPanel2.Controls.Add(ButtonHelp, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(99, 303)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(521, 37)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonOK.Location = New Point(281, 11)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(75, 23)
        ButtonOK.TabIndex = 1
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Anchor = AnchorStyles.Bottom
        ButtonCancel.Location = New Point(362, 11)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 23)
        ButtonCancel.TabIndex = 0
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonHelp.Location = New Point(443, 11)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(75, 23)
        ButtonHelp.TabIndex = 2
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxCheckNewVersion
        ' 
        CheckBoxCheckNewVersion.Anchor = AnchorStyles.Left
        CheckBoxCheckNewVersion.AutoSize = True
        CheckBoxCheckNewVersion.Checked = True
        CheckBoxCheckNewVersion.CheckState = CheckState.Checked
        TableLayoutPanel1.SetColumnSpan(CheckBoxCheckNewVersion, 2)
        CheckBoxCheckNewVersion.Location = New Point(3, 275)
        CheckBoxCheckNewVersion.Name = "CheckBoxCheckNewVersion"
        CheckBoxCheckNewVersion.Padding = New Padding(5, 0, 0, 0)
        CheckBoxCheckNewVersion.Size = New Size(209, 19)
        CheckBoxCheckNewVersion.TabIndex = 11
        CheckBoxCheckNewVersion.Text = "    Check for new version at statup"
        CheckBoxCheckNewVersion.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxDisableFineThreadWarning
        ' 
        CheckBoxDisableFineThreadWarning.Anchor = AnchorStyles.Left
        CheckBoxDisableFineThreadWarning.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxDisableFineThreadWarning, 2)
        CheckBoxDisableFineThreadWarning.Location = New Point(3, 245)
        CheckBoxDisableFineThreadWarning.Name = "CheckBoxDisableFineThreadWarning"
        CheckBoxDisableFineThreadWarning.Padding = New Padding(5, 0, 0, 0)
        CheckBoxDisableFineThreadWarning.Size = New Size(187, 19)
        CheckBoxDisableFineThreadWarning.TabIndex = 10
        CheckBoxDisableFineThreadWarning.Text = "    Disable fine thread warning"
        CheckBoxDisableFineThreadWarning.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAddProp
        ' 
        CheckBoxAddProp.Anchor = AnchorStyles.Left
        CheckBoxAddProp.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxAddProp, 2)
        CheckBoxAddProp.Location = New Point(3, 215)
        CheckBoxAddProp.Name = "CheckBoxAddProp"
        CheckBoxAddProp.Padding = New Padding(5, 0, 0, 0)
        CheckBoxAddProp.Size = New Size(229, 19)
        CheckBoxAddProp.TabIndex = 6
        CheckBoxAddProp.Text = "    Add any property not already in file"
        ToolTip1.SetToolTip(CheckBoxAddProp, "Add missing SE file properties")
        CheckBoxAddProp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAutoPattern
        ' 
        CheckBoxAutoPattern.Anchor = AnchorStyles.Left
        CheckBoxAutoPattern.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxAutoPattern, 2)
        CheckBoxAutoPattern.Location = New Point(3, 185)
        CheckBoxAutoPattern.Name = "CheckBoxAutoPattern"
        CheckBoxAutoPattern.Padding = New Padding(5, 0, 0, 0)
        CheckBoxAutoPattern.Size = New Size(380, 19)
        CheckBoxAutoPattern.TabIndex = 17
        CheckBoxAutoPattern.Text = "     Automatically pattern a part if assembled to a patterned feature"
        CheckBoxAutoPattern.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAlwaysReadExcel
        ' 
        CheckBoxAlwaysReadExcel.Anchor = AnchorStyles.Left
        CheckBoxAlwaysReadExcel.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxAlwaysReadExcel, 2)
        CheckBoxAlwaysReadExcel.Location = New Point(3, 155)
        CheckBoxAlwaysReadExcel.Name = "CheckBoxAlwaysReadExcel"
        CheckBoxAlwaysReadExcel.Padding = New Padding(5, 0, 0, 0)
        CheckBoxAlwaysReadExcel.Size = New Size(324, 19)
        CheckBoxAlwaysReadExcel.TabIndex = 12
        CheckBoxAlwaysReadExcel.Text = "    Read the Excel file each time the program is launched"
        CheckBoxAlwaysReadExcel.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Left
        Label4.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label4, 2)
        Label4.Location = New Point(3, 127)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 15)
        Label4.TabIndex = 16
        Label4.Text = "OPTIONS"
        ' 
        ' ButtonMaterialLibrary
        ' 
        ButtonMaterialLibrary.Anchor = AnchorStyles.Left
        ButtonMaterialLibrary.BackColor = Color.White
        ButtonMaterialLibrary.Location = New Point(3, 93)
        ButtonMaterialLibrary.Name = "ButtonMaterialLibrary"
        ButtonMaterialLibrary.Padding = New Padding(5, 0, 0, 0)
        ButtonMaterialLibrary.Size = New Size(90, 24)
        ButtonMaterialLibrary.TabIndex = 7
        ButtonMaterialLibrary.Text = "Matl Table"
        ToolTip1.SetToolTip(ButtonMaterialLibrary, "Select Material Library")
        ButtonMaterialLibrary.UseVisualStyleBackColor = False
        ' 
        ' LabelMaterialLibrary
        ' 
        LabelMaterialLibrary.Anchor = AnchorStyles.Left
        LabelMaterialLibrary.AutoSize = True
        LabelMaterialLibrary.Location = New Point(99, 97)
        LabelMaterialLibrary.Name = "LabelMaterialLibrary"
        LabelMaterialLibrary.Size = New Size(122, 15)
        LabelMaterialLibrary.TabIndex = 8
        LabelMaterialLibrary.Text = "Select a material table"
        ' 
        ' ButtonDataDirectory
        ' 
        ButtonDataDirectory.BackColor = Color.White
        ButtonDataDirectory.Location = New Point(3, 63)
        ButtonDataDirectory.Name = "ButtonDataDirectory"
        ButtonDataDirectory.Size = New Size(90, 24)
        ButtonDataDirectory.TabIndex = 14
        ButtonDataDirectory.Text = "Data Dir"
        ToolTip1.SetToolTip(ButtonDataDirectory, "Data Directory")
        ButtonDataDirectory.UseVisualStyleBackColor = False
        ' 
        ' LabelDataDirectory
        ' 
        LabelDataDirectory.Anchor = AnchorStyles.Left
        LabelDataDirectory.AutoSize = True
        LabelDataDirectory.Location = New Point(99, 67)
        LabelDataDirectory.Name = "LabelDataDirectory"
        LabelDataDirectory.Size = New Size(123, 15)
        LabelDataDirectory.TabIndex = 15
        LabelDataDirectory.Text = "Select a data directory"
        ' 
        ' ButtonTemplateDirectory
        ' 
        ButtonTemplateDirectory.Anchor = AnchorStyles.Left
        ButtonTemplateDirectory.BackColor = Color.White
        ButtonTemplateDirectory.Location = New Point(3, 33)
        ButtonTemplateDirectory.Name = "ButtonTemplateDirectory"
        ButtonTemplateDirectory.Padding = New Padding(5, 0, 0, 0)
        ButtonTemplateDirectory.Size = New Size(90, 24)
        ButtonTemplateDirectory.TabIndex = 1
        ButtonTemplateDirectory.Text = "Template Dir"
        ToolTip1.SetToolTip(ButtonTemplateDirectory, "Select Template Directory")
        ButtonTemplateDirectory.UseVisualStyleBackColor = False
        ' 
        ' LabelTemplateDirectory
        ' 
        LabelTemplateDirectory.Anchor = AnchorStyles.Left
        LabelTemplateDirectory.AutoSize = True
        LabelTemplateDirectory.Location = New Point(99, 37)
        LabelTemplateDirectory.Name = "LabelTemplateDirectory"
        LabelTemplateDirectory.Size = New Size(147, 15)
        LabelTemplateDirectory.TabIndex = 2
        LabelTemplateDirectory.Text = "Select a template directory"
        ' 
        ' ButtonLibraryDirectory
        ' 
        ButtonLibraryDirectory.Location = New Point(3, 3)
        ButtonLibraryDirectory.Name = "ButtonLibraryDirectory"
        ButtonLibraryDirectory.Size = New Size(90, 24)
        ButtonLibraryDirectory.TabIndex = 18
        ButtonLibraryDirectory.Text = "Library Dir"
        ButtonLibraryDirectory.UseVisualStyleBackColor = True
        ' 
        ' LabelLibraryDirectory
        ' 
        LabelLibraryDirectory.Anchor = AnchorStyles.Left
        LabelLibraryDirectory.AutoSize = True
        LabelLibraryDirectory.Location = New Point(99, 7)
        LabelLibraryDirectory.Name = "LabelLibraryDirectory"
        LabelLibraryDirectory.Size = New Size(133, 15)
        LabelLibraryDirectory.TabIndex = 19
        LabelLibraryDirectory.Text = "Select a library directory"
        ' 
        ' FormTreeSearchOptions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(623, 343)
        Controls.Add(TableLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FormTreeSearchOptions"
        StartPosition = FormStartPosition.CenterParent
        Text = "Tree Search Options"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonTemplateDirectory As Button
    Friend WithEvents LabelTemplateDirectory As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents CheckBoxAddProp As CheckBox
    Friend WithEvents ButtonMaterialLibrary As Button
    Friend WithEvents LabelMaterialLibrary As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CheckBoxDisableFineThreadWarning As CheckBox
    Friend WithEvents CheckBoxCheckNewVersion As CheckBox
    Friend WithEvents CheckBoxAlwaysReadExcel As CheckBox
    Friend WithEvents ButtonDataDirectory As Button
    Friend WithEvents LabelDataDirectory As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonHelp As Button
    Friend WithEvents CheckBoxAutoPattern As CheckBox
    Friend WithEvents ButtonLibraryDirectory As Button
    Friend WithEvents LabelLibraryDirectory As Label
End Class
