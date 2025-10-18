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
        CheckBoxAlwaysReadExcel = New CheckBox()
        Label4 = New Label()
        ButtonMaterialLibrary = New Button()
        LabelMaterialLibrary = New Label()
        ButtonLibraryDirectory = New Button()
        LabelLibraryDirectory = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        ButtonOK = New Button()
        ButtonCancel = New Button()
        ButtonHelp = New Button()
        CheckBoxAddProp = New CheckBox()
        CheckBoxDisableFineThreadWarning = New CheckBox()
        CheckBoxProcessTemplateInBackground = New CheckBox()
        CheckBoxFailedConstraintSuppress = New CheckBox()
        CheckBoxFailedConstraintAllow = New CheckBox()
        CheckBoxSuspendMRU = New CheckBox()
        CheckBoxIncludeDrawing = New CheckBox()
        LabelAlwaysOnTopRefreshTime = New Label()
        TextBoxAlwaysOnTopRefreshTime = New TextBox()
        ButtonDataDirectory = New Button()
        LabelDataDirectory = New Label()
        ButtonTemplateDirectory = New Button()
        LabelTemplateDirectory = New Label()
        CheckBoxCheckNewVersion = New CheckBox()
        TextBoxPartPlacementTimeout = New TextBox()
        LabelPartPlacementTimeout = New Label()
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
        TableLayoutPanel1.Controls.Add(CheckBoxAlwaysReadExcel, 0, 5)
        TableLayoutPanel1.Controls.Add(Label4, 0, 4)
        TableLayoutPanel1.Controls.Add(ButtonMaterialLibrary, 0, 3)
        TableLayoutPanel1.Controls.Add(LabelMaterialLibrary, 1, 3)
        TableLayoutPanel1.Controls.Add(ButtonLibraryDirectory, 0, 0)
        TableLayoutPanel1.Controls.Add(LabelLibraryDirectory, 1, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 20)
        TableLayoutPanel1.Controls.Add(CheckBoxAddProp, 0, 6)
        TableLayoutPanel1.Controls.Add(CheckBoxDisableFineThreadWarning, 0, 7)
        TableLayoutPanel1.Controls.Add(CheckBoxProcessTemplateInBackground, 0, 8)
        TableLayoutPanel1.Controls.Add(CheckBoxFailedConstraintSuppress, 0, 9)
        TableLayoutPanel1.Controls.Add(CheckBoxFailedConstraintAllow, 0, 10)
        TableLayoutPanel1.Controls.Add(CheckBoxSuspendMRU, 0, 11)
        TableLayoutPanel1.Controls.Add(CheckBoxIncludeDrawing, 0, 12)
        TableLayoutPanel1.Controls.Add(LabelAlwaysOnTopRefreshTime, 1, 13)
        TableLayoutPanel1.Controls.Add(TextBoxAlwaysOnTopRefreshTime, 0, 13)
        TableLayoutPanel1.Controls.Add(ButtonDataDirectory, 0, 1)
        TableLayoutPanel1.Controls.Add(LabelDataDirectory, 1, 1)
        TableLayoutPanel1.Controls.Add(ButtonTemplateDirectory, 0, 2)
        TableLayoutPanel1.Controls.Add(LabelTemplateDirectory, 1, 2)
        TableLayoutPanel1.Controls.Add(CheckBoxCheckNewVersion, 0, 15)
        TableLayoutPanel1.Controls.Add(TextBoxPartPlacementTimeout, 0, 14)
        TableLayoutPanel1.Controls.Add(LabelPartPlacementTimeout, 1, 14)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 21
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
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(472, 560)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' CheckBoxAlwaysReadExcel
        ' 
        CheckBoxAlwaysReadExcel.Anchor = AnchorStyles.Left
        CheckBoxAlwaysReadExcel.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxAlwaysReadExcel, 2)
        CheckBoxAlwaysReadExcel.Location = New Point(3, 155)
        CheckBoxAlwaysReadExcel.Name = "CheckBoxAlwaysReadExcel"
        CheckBoxAlwaysReadExcel.Padding = New Padding(5, 0, 0, 0)
        CheckBoxAlwaysReadExcel.Size = New Size(312, 19)
        CheckBoxAlwaysReadExcel.TabIndex = 12
        CheckBoxAlwaysReadExcel.Text = "Read the Excel file each time the program is launched"
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
        LabelMaterialLibrary.Location = New Point(109, 97)
        LabelMaterialLibrary.Name = "LabelMaterialLibrary"
        LabelMaterialLibrary.Size = New Size(122, 15)
        LabelMaterialLibrary.TabIndex = 8
        LabelMaterialLibrary.Text = "Select a material table"
        ' 
        ' ButtonLibraryDirectory
        ' 
        ButtonLibraryDirectory.Anchor = AnchorStyles.Left
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
        LabelLibraryDirectory.Location = New Point(109, 7)
        LabelLibraryDirectory.Name = "LabelLibraryDirectory"
        LabelLibraryDirectory.Size = New Size(133, 15)
        LabelLibraryDirectory.TabIndex = 19
        LabelLibraryDirectory.Text = "Select a library directory"
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
        TableLayoutPanel2.Location = New Point(109, 483)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(360, 74)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonOK.Location = New Point(120, 48)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(75, 23)
        ButtonOK.TabIndex = 1
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Anchor = AnchorStyles.Bottom
        ButtonCancel.Location = New Point(201, 48)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 23)
        ButtonCancel.TabIndex = 0
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonHelp.Location = New Point(282, 48)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(75, 23)
        ButtonHelp.TabIndex = 2
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAddProp
        ' 
        CheckBoxAddProp.Anchor = AnchorStyles.Left
        CheckBoxAddProp.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxAddProp, 2)
        CheckBoxAddProp.Location = New Point(3, 185)
        CheckBoxAddProp.Name = "CheckBoxAddProp"
        CheckBoxAddProp.Padding = New Padding(5, 0, 0, 0)
        CheckBoxAddProp.Size = New Size(217, 19)
        CheckBoxAddProp.TabIndex = 6
        CheckBoxAddProp.Text = "Add any property not already in file"
        ToolTip1.SetToolTip(CheckBoxAddProp, "Add missing SE file properties")
        CheckBoxAddProp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxDisableFineThreadWarning
        ' 
        CheckBoxDisableFineThreadWarning.Anchor = AnchorStyles.Left
        CheckBoxDisableFineThreadWarning.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxDisableFineThreadWarning, 2)
        CheckBoxDisableFineThreadWarning.Location = New Point(3, 215)
        CheckBoxDisableFineThreadWarning.Name = "CheckBoxDisableFineThreadWarning"
        CheckBoxDisableFineThreadWarning.Padding = New Padding(5, 0, 0, 0)
        CheckBoxDisableFineThreadWarning.Size = New Size(175, 19)
        CheckBoxDisableFineThreadWarning.TabIndex = 10
        CheckBoxDisableFineThreadWarning.Text = "Disable fine thread warning"
        CheckBoxDisableFineThreadWarning.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxProcessTemplateInBackground
        ' 
        CheckBoxProcessTemplateInBackground.Anchor = AnchorStyles.Left
        CheckBoxProcessTemplateInBackground.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxProcessTemplateInBackground, 2)
        CheckBoxProcessTemplateInBackground.Location = New Point(3, 245)
        CheckBoxProcessTemplateInBackground.Name = "CheckBoxProcessTemplateInBackground"
        CheckBoxProcessTemplateInBackground.Padding = New Padding(5, 0, 0, 0)
        CheckBoxProcessTemplateInBackground.Size = New Size(206, 19)
        CheckBoxProcessTemplateInBackground.TabIndex = 20
        CheckBoxProcessTemplateInBackground.Text = "Process templates in background"
        CheckBoxProcessTemplateInBackground.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxFailedConstraintSuppress
        ' 
        CheckBoxFailedConstraintSuppress.Anchor = AnchorStyles.Left
        CheckBoxFailedConstraintSuppress.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxFailedConstraintSuppress, 2)
        CheckBoxFailedConstraintSuppress.Location = New Point(3, 275)
        CheckBoxFailedConstraintSuppress.Name = "CheckBoxFailedConstraintSuppress"
        CheckBoxFailedConstraintSuppress.Padding = New Padding(5, 0, 0, 0)
        CheckBoxFailedConstraintSuppress.Size = New Size(237, 19)
        CheckBoxFailedConstraintSuppress.TabIndex = 21
        CheckBoxFailedConstraintSuppress.Text = "Replace part: Suppress failed constraint"
        CheckBoxFailedConstraintSuppress.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxFailedConstraintAllow
        ' 
        CheckBoxFailedConstraintAllow.Anchor = AnchorStyles.Left
        CheckBoxFailedConstraintAllow.AutoSize = True
        CheckBoxFailedConstraintAllow.Checked = True
        CheckBoxFailedConstraintAllow.CheckState = CheckState.Checked
        TableLayoutPanel1.SetColumnSpan(CheckBoxFailedConstraintAllow, 2)
        CheckBoxFailedConstraintAllow.Location = New Point(3, 305)
        CheckBoxFailedConstraintAllow.Name = "CheckBoxFailedConstraintAllow"
        CheckBoxFailedConstraintAllow.Padding = New Padding(5, 0, 0, 0)
        CheckBoxFailedConstraintAllow.Size = New Size(220, 19)
        CheckBoxFailedConstraintAllow.TabIndex = 22
        CheckBoxFailedConstraintAllow.Text = "Replace part: Allow failed constraint"
        CheckBoxFailedConstraintAllow.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxSuspendMRU
        ' 
        CheckBoxSuspendMRU.Anchor = AnchorStyles.Left
        CheckBoxSuspendMRU.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxSuspendMRU, 2)
        CheckBoxSuspendMRU.Location = New Point(3, 335)
        CheckBoxSuspendMRU.Name = "CheckBoxSuspendMRU"
        CheckBoxSuspendMRU.Padding = New Padding(5, 0, 0, 0)
        CheckBoxSuspendMRU.Size = New Size(330, 19)
        CheckBoxSuspendMRU.TabIndex = 23
        CheckBoxSuspendMRU.Text = "Do not add files to the Recently Used list (SE2020 and up)"
        CheckBoxSuspendMRU.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxIncludeDrawing
        ' 
        CheckBoxIncludeDrawing.Anchor = AnchorStyles.Left
        CheckBoxIncludeDrawing.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxIncludeDrawing, 2)
        CheckBoxIncludeDrawing.Location = New Point(3, 365)
        CheckBoxIncludeDrawing.Name = "CheckBoxIncludeDrawing"
        CheckBoxIncludeDrawing.Padding = New Padding(5, 0, 0, 0)
        CheckBoxIncludeDrawing.Size = New Size(206, 19)
        CheckBoxIncludeDrawing.TabIndex = 26
        CheckBoxIncludeDrawing.Text = "Include drawing of part if present"
        CheckBoxIncludeDrawing.UseVisualStyleBackColor = True
        ' 
        ' LabelAlwaysOnTopRefreshTime
        ' 
        LabelAlwaysOnTopRefreshTime.Anchor = AnchorStyles.Left
        LabelAlwaysOnTopRefreshTime.AutoSize = True
        LabelAlwaysOnTopRefreshTime.Location = New Point(109, 397)
        LabelAlwaysOnTopRefreshTime.Name = "LabelAlwaysOnTopRefreshTime"
        LabelAlwaysOnTopRefreshTime.Padding = New Padding(5, 0, 0, 0)
        LabelAlwaysOnTopRefreshTime.Size = New Size(192, 15)
        LabelAlwaysOnTopRefreshTime.TabIndex = 28
        LabelAlwaysOnTopRefreshTime.Text = "On top refresh time (milliseconds)"
        ' 
        ' TextBoxAlwaysOnTopRefreshTime
        ' 
        TextBoxAlwaysOnTopRefreshTime.Dock = DockStyle.Fill
        TextBoxAlwaysOnTopRefreshTime.Location = New Point(3, 393)
        TextBoxAlwaysOnTopRefreshTime.Name = "TextBoxAlwaysOnTopRefreshTime"
        TextBoxAlwaysOnTopRefreshTime.Size = New Size(100, 23)
        TextBoxAlwaysOnTopRefreshTime.TabIndex = 27
        TextBoxAlwaysOnTopRefreshTime.Text = "3000"
        TextBoxAlwaysOnTopRefreshTime.TextAlign = HorizontalAlignment.Right
        ' 
        ' ButtonDataDirectory
        ' 
        ButtonDataDirectory.Anchor = AnchorStyles.Left
        ButtonDataDirectory.BackColor = Color.White
        ButtonDataDirectory.Location = New Point(3, 33)
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
        LabelDataDirectory.Location = New Point(109, 37)
        LabelDataDirectory.Name = "LabelDataDirectory"
        LabelDataDirectory.Size = New Size(123, 15)
        LabelDataDirectory.TabIndex = 15
        LabelDataDirectory.Text = "Select a data directory"
        ' 
        ' ButtonTemplateDirectory
        ' 
        ButtonTemplateDirectory.Anchor = AnchorStyles.Left
        ButtonTemplateDirectory.BackColor = Color.White
        ButtonTemplateDirectory.Location = New Point(3, 63)
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
        LabelTemplateDirectory.Location = New Point(109, 67)
        LabelTemplateDirectory.Name = "LabelTemplateDirectory"
        LabelTemplateDirectory.Size = New Size(147, 15)
        LabelTemplateDirectory.TabIndex = 2
        LabelTemplateDirectory.Text = "Select a template directory"
        ' 
        ' CheckBoxCheckNewVersion
        ' 
        CheckBoxCheckNewVersion.Anchor = AnchorStyles.Left
        CheckBoxCheckNewVersion.AutoSize = True
        CheckBoxCheckNewVersion.Checked = True
        CheckBoxCheckNewVersion.CheckState = CheckState.Checked
        TableLayoutPanel1.SetColumnSpan(CheckBoxCheckNewVersion, 2)
        CheckBoxCheckNewVersion.Location = New Point(3, 455)
        CheckBoxCheckNewVersion.Name = "CheckBoxCheckNewVersion"
        CheckBoxCheckNewVersion.Padding = New Padding(5, 0, 0, 0)
        CheckBoxCheckNewVersion.Size = New Size(197, 19)
        CheckBoxCheckNewVersion.TabIndex = 11
        CheckBoxCheckNewVersion.Text = "Check for new version at statup"
        CheckBoxCheckNewVersion.UseVisualStyleBackColor = True
        ' 
        ' TextBoxPartPlacementTimeout
        ' 
        TextBoxPartPlacementTimeout.Dock = DockStyle.Fill
        TextBoxPartPlacementTimeout.Location = New Point(3, 423)
        TextBoxPartPlacementTimeout.Name = "TextBoxPartPlacementTimeout"
        TextBoxPartPlacementTimeout.Size = New Size(100, 23)
        TextBoxPartPlacementTimeout.TabIndex = 29
        TextBoxPartPlacementTimeout.TextAlign = HorizontalAlignment.Right
        ' 
        ' LabelPartPlacementTimeout
        ' 
        LabelPartPlacementTimeout.Anchor = AnchorStyles.Left
        LabelPartPlacementTimeout.AutoSize = True
        LabelPartPlacementTimeout.Location = New Point(109, 427)
        LabelPartPlacementTimeout.Name = "LabelPartPlacementTimeout"
        LabelPartPlacementTimeout.Padding = New Padding(5, 0, 0, 0)
        LabelPartPlacementTimeout.Size = New Size(238, 15)
        LabelPartPlacementTimeout.TabIndex = 30
        LabelPartPlacementTimeout.Text = "Time out for part placement (milliseconds)"
        ' 
        ' FormTreeSearchOptions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(472, 560)
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
    Friend WithEvents ButtonLibraryDirectory As Button
    Friend WithEvents LabelLibraryDirectory As Label
    Friend WithEvents CheckBoxProcessTemplateInBackground As CheckBox
    Friend WithEvents CheckBoxFailedConstraintSuppress As CheckBox
    Friend WithEvents CheckBoxFailedConstraintAllow As CheckBox
    Friend WithEvents CheckBoxSuspendMRU As CheckBox
    Friend WithEvents CheckBoxIncludeDrawing As CheckBox
    Friend WithEvents TextBoxAlwaysOnTopRefreshTime As TextBox
    Friend WithEvents LabelAlwaysOnTopRefreshTime As Label
    Friend WithEvents TextBoxPartPlacementTimeout As TextBox
    Friend WithEvents LabelPartPlacementTimeout As Label
End Class
