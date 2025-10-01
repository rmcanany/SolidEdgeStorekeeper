<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPropertySearchOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPropertySearchOptions))
        TableLayoutPanel1 = New TableLayoutPanel()
        ButtonSheetmetalTemplate = New Button()
        ButtonPartTemplate = New Button()
        ButtonAssemblyTemplate = New Button()
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        SystemOrCustom = New DataGridViewTextBoxColumn()
        PropertyName = New DataGridViewTextBoxColumn()
        Label2 = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        ButtonCancel = New Button()
        ButtonOK = New Button()
        ButtonHelp = New Button()
        CheckBoxCacheProperties = New CheckBox()
        LabelAssemblyTemplate = New Label()
        LabelPartTemplate = New Label()
        LabelSheetmetalTemplate = New Label()
        TableLayoutPanel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(ButtonSheetmetalTemplate, 0, 5)
        TableLayoutPanel1.Controls.Add(ButtonPartTemplate, 0, 4)
        TableLayoutPanel1.Controls.Add(ButtonAssemblyTemplate, 0, 3)
        TableLayoutPanel1.Controls.Add(Label1, 0, 2)
        TableLayoutPanel1.Controls.Add(DataGridView1, 0, 1)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 9)
        TableLayoutPanel1.Controls.Add(CheckBoxCacheProperties, 0, 6)
        TableLayoutPanel1.Controls.Add(LabelAssemblyTemplate, 1, 3)
        TableLayoutPanel1.Controls.Add(LabelPartTemplate, 1, 4)
        TableLayoutPanel1.Controls.Add(LabelSheetmetalTemplate, 1, 5)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 10
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 125F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        TableLayoutPanel1.Size = New Size(427, 351)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' ButtonSheetmetalTemplate
        ' 
        ButtonSheetmetalTemplate.Anchor = AnchorStyles.Left
        ButtonSheetmetalTemplate.Location = New Point(3, 248)
        ButtonSheetmetalTemplate.Name = "ButtonSheetmetalTemplate"
        ButtonSheetmetalTemplate.Size = New Size(75, 23)
        ButtonSheetmetalTemplate.TabIndex = 3
        ButtonSheetmetalTemplate.Text = "Sheetmetal"
        ButtonSheetmetalTemplate.UseVisualStyleBackColor = True
        ' 
        ' ButtonPartTemplate
        ' 
        ButtonPartTemplate.Anchor = AnchorStyles.Left
        ButtonPartTemplate.Location = New Point(3, 218)
        ButtonPartTemplate.Name = "ButtonPartTemplate"
        ButtonPartTemplate.Size = New Size(75, 23)
        ButtonPartTemplate.TabIndex = 2
        ButtonPartTemplate.Text = "Part"
        ButtonPartTemplate.UseVisualStyleBackColor = True
        ' 
        ' ButtonAssemblyTemplate
        ' 
        ButtonAssemblyTemplate.Anchor = AnchorStyles.Left
        ButtonAssemblyTemplate.Location = New Point(3, 188)
        ButtonAssemblyTemplate.Name = "ButtonAssemblyTemplate"
        ButtonAssemblyTemplate.Size = New Size(75, 23)
        ButtonAssemblyTemplate.TabIndex = 1
        ButtonAssemblyTemplate.Text = "Assembly"
        ButtonAssemblyTemplate.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label1, 2)
        Label1.Location = New Point(3, 162)
        Label1.Name = "Label1"
        Label1.Size = New Size(315, 15)
        Label1.TabIndex = 0
        Label1.Text = "Solid Edge Template Files (used to populate file properties)"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {SystemOrCustom, PropertyName})
        TableLayoutPanel1.SetColumnSpan(DataGridView1, 2)
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 33)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 30
        DataGridView1.Size = New Size(421, 119)
        DataGridView1.TabIndex = 8
        ' 
        ' SystemOrCustom
        ' 
        SystemOrCustom.HeaderText = "System/Custom"
        SystemOrCustom.Name = "SystemOrCustom"
        ' 
        ' PropertyName
        ' 
        PropertyName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        PropertyName.HeaderText = "Property Name"
        PropertyName.Name = "PropertyName"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(Label2, 2)
        Label2.Location = New Point(3, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 15)
        Label2.TabIndex = 9
        Label2.Text = "Properties to search"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.Controls.Add(ButtonCancel, 1, 0)
        TableLayoutPanel2.Controls.Add(ButtonOK, 0, 0)
        TableLayoutPanel2.Controls.Add(ButtonHelp, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(84, 308)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(340, 40)
        TableLayoutPanel2.TabIndex = 7
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Anchor = AnchorStyles.Bottom
        ButtonCancel.Location = New Point(181, 14)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 23)
        ButtonCancel.TabIndex = 0
        ButtonCancel.Text = "Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonOK.Location = New Point(100, 14)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(75, 23)
        ButtonOK.TabIndex = 1
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom
        ButtonHelp.Location = New Point(262, 14)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(75, 23)
        ButtonHelp.TabIndex = 2
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxCacheProperties
        ' 
        CheckBoxCacheProperties.Anchor = AnchorStyles.Left
        CheckBoxCacheProperties.AutoSize = True
        TableLayoutPanel1.SetColumnSpan(CheckBoxCacheProperties, 2)
        CheckBoxCacheProperties.Location = New Point(3, 280)
        CheckBoxCacheProperties.Name = "CheckBoxCacheProperties"
        CheckBoxCacheProperties.Padding = New Padding(5, 0, 0, 0)
        CheckBoxCacheProperties.Size = New Size(262, 19)
        CheckBoxCacheProperties.TabIndex = 10
        CheckBoxCacheProperties.Text = "Cache library file properties for faster search"
        CheckBoxCacheProperties.UseVisualStyleBackColor = True
        ' 
        ' LabelAssemblyTemplate
        ' 
        LabelAssemblyTemplate.Anchor = AnchorStyles.Left
        LabelAssemblyTemplate.AutoSize = True
        LabelAssemblyTemplate.Location = New Point(84, 192)
        LabelAssemblyTemplate.Name = "LabelAssemblyTemplate"
        LabelAssemblyTemplate.Size = New Size(140, 15)
        LabelAssemblyTemplate.TabIndex = 11
        LabelAssemblyTemplate.Text = "Select assembly template"
        ' 
        ' LabelPartTemplate
        ' 
        LabelPartTemplate.Anchor = AnchorStyles.Left
        LabelPartTemplate.AutoSize = True
        LabelPartTemplate.Location = New Point(84, 222)
        LabelPartTemplate.Name = "LabelPartTemplate"
        LabelPartTemplate.Size = New Size(112, 15)
        LabelPartTemplate.TabIndex = 12
        LabelPartTemplate.Text = "Select part template"
        ' 
        ' LabelSheetmetalTemplate
        ' 
        LabelSheetmetalTemplate.Anchor = AnchorStyles.Left
        LabelSheetmetalTemplate.AutoSize = True
        LabelSheetmetalTemplate.Location = New Point(84, 252)
        LabelSheetmetalTemplate.Name = "LabelSheetmetalTemplate"
        LabelSheetmetalTemplate.Size = New Size(149, 15)
        LabelSheetmetalTemplate.TabIndex = 13
        LabelSheetmetalTemplate.Text = "Select sheetmetal template"
        ' 
        ' FormPropertySearchOptions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(427, 351)
        Controls.Add(TableLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FormPropertySearchOptions"
        StartPosition = FormStartPosition.CenterParent
        Text = "Property Search Options"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonAssemblyTemplate As Button
    Friend WithEvents ButtonPartTemplate As Button
    Friend WithEvents ButtonSheetmetalTemplate As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonOK As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents SystemOrCustom As DataGridViewTextBoxColumn
    Friend WithEvents PropertyName As DataGridViewTextBoxColumn
    Friend WithEvents ButtonHelp As Button
    Friend WithEvents CheckBoxCacheProperties As CheckBox
    Friend WithEvents LabelAssemblyTemplate As Label
    Friend WithEvents LabelPartTemplate As Label
    Friend WithEvents LabelSheetmetalTemplate As Label
End Class
