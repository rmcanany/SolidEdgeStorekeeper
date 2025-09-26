<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
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
        components = New ComponentModel.Container()
        Dim TreeNode1 As TreeNode = New TreeNode("Node0")
        Dim TreeNode2 As TreeNode = New TreeNode("Node4")
        Dim TreeNode3 As TreeNode = New TreeNode("Node2", New TreeNode() {TreeNode2})
        Dim TreeNode4 As TreeNode = New TreeNode("Node3")
        Dim TreeNode5 As TreeNode = New TreeNode("Node1", New TreeNode() {TreeNode3, TreeNode4})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        ToolStrip1 = New ToolStrip()
        ButtonCollapse = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        LabelSaveIn = New ToolStripLabel()
        ComboBoxSaveIn = New ToolStripComboBox()
        ToolStripSeparator2 = New ToolStripSeparator()
        ButtonOptions = New ToolStripButton()
        ComboBoxMaterials = New ToolStripComboBox()
        LabelMaterials = New ToolStripLabel()
        TreeView1 = New TreeView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ReplaceSelectedToolStripMenuItem = New ToolStripMenuItem()
        ReplaceAllToolStripMenuItem = New ToolStripMenuItem()
        FastenerStackToolStripMenuItem = New ToolStripMenuItem()
        DataGridViewDataInspector = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        PictureBox1 = New PictureBox()
        ButtonClose = New Button()
        TabControl1 = New TabControl()
        TabPageTreeSearch = New TabPage()
        TableLayoutPanel2 = New TableLayoutPanel()
        TabPagePropertySearch = New TabPage()
        TableLayoutPanel4 = New TableLayoutPanel()
        TableLayoutPanel5 = New TableLayoutPanel()
        ButtonSearchProperties = New Button()
        TextBoxSearchTerms = New TextBox()
        ButtonPropertySearchOptions = New Button()
        DataGridViewVendorParts = New DataGridView()
        Filename = New DataGridViewTextBoxColumn()
        Path = New DataGridViewTextBoxColumn()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        AddToAssemblyToolStripMenuItem = New ToolStripMenuItem()
        TabPageInspectData = New TabPage()
        ImageList1 = New ImageList(components)
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        ButtonHelp = New Button()
        TextBoxStatus = New TextBox()
        ToolStrip1.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        CType(DataGridViewDataInspector, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabPageTreeSearch.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TabPagePropertySearch.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        CType(DataGridViewVendorParts, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip2.SuspendLayout()
        TabPageInspectData.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ButtonCollapse, ToolStripSeparator1, LabelSaveIn, ComboBoxSaveIn, ToolStripSeparator2, ButtonOptions, ComboBoxMaterials, LabelMaterials})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.RenderMode = ToolStripRenderMode.System
        ToolStrip1.Size = New Size(478, 25)
        ToolStrip1.Stretch = True
        ToolStrip1.TabIndex = 0
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ButtonCollapse
        ' 
        ButtonCollapse.DisplayStyle = ToolStripItemDisplayStyle.Image
        ButtonCollapse.Image = My.Resources.Resources.collapse
        ButtonCollapse.ImageTransparentColor = Color.Magenta
        ButtonCollapse.Name = "ButtonCollapse"
        ButtonCollapse.Size = New Size(23, 22)
        ButtonCollapse.ToolTipText = "Collapse the tree"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' LabelSaveIn
        ' 
        LabelSaveIn.Name = "LabelSaveIn"
        LabelSaveIn.Size = New Size(44, 22)
        LabelSaveIn.Text = "Save in"
        LabelSaveIn.ToolTipText = "Collapse the tree"
        ' 
        ' ComboBoxSaveIn
        ' 
        ComboBoxSaveIn.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxSaveIn.Items.AddRange(New Object() {"Library", "Assy Dir", "Other"})
        ComboBoxSaveIn.Name = "ComboBoxSaveIn"
        ComboBoxSaveIn.Size = New Size(75, 25)
        ComboBoxSaveIn.ToolTipText = "Save in directory"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 25)
        ' 
        ' ButtonOptions
        ' 
        ButtonOptions.Alignment = ToolStripItemAlignment.Right
        ButtonOptions.DisplayStyle = ToolStripItemDisplayStyle.Image
        ButtonOptions.Image = My.Resources.Resources.Support_16
        ButtonOptions.ImageTransparentColor = Color.Magenta
        ButtonOptions.Name = "ButtonOptions"
        ButtonOptions.Size = New Size(23, 22)
        ButtonOptions.Text = "ToolStripButton1"
        ButtonOptions.ToolTipText = "Options"
        ' 
        ' ComboBoxMaterials
        ' 
        ComboBoxMaterials.Alignment = ToolStripItemAlignment.Right
        ComboBoxMaterials.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxMaterials.Name = "ComboBoxMaterials"
        ComboBoxMaterials.Size = New Size(150, 25)
        ComboBoxMaterials.ToolTipText = "Materials"
        ' 
        ' LabelMaterials
        ' 
        LabelMaterials.Alignment = ToolStripItemAlignment.Right
        LabelMaterials.Name = "LabelMaterials"
        LabelMaterials.Size = New Size(31, 22)
        LabelMaterials.Text = "Matl"
        ' 
        ' TreeView1
        ' 
        TreeView1.Dock = DockStyle.Fill
        TreeView1.Location = New Point(3, 28)
        TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Node0"
        TreeNode2.Name = "Node4"
        TreeNode2.Text = "Node4"
        TreeNode3.Name = "Node2"
        TreeNode3.Text = "Node2"
        TreeNode4.Name = "Node3"
        TreeNode4.Text = "Node3"
        TreeNode5.Name = "Node1"
        TreeNode5.Text = "Node1"
        TreeView1.Nodes.AddRange(New TreeNode() {TreeNode1, TreeNode5})
        TreeView1.ShowNodeToolTips = True
        TreeView1.Size = New Size(472, 392)
        TreeView1.TabIndex = 1
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, ReplaceSelectedToolStripMenuItem, ReplaceAllToolStripMenuItem, FastenerStackToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(163, 92)
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(162, 22)
        ToolStripMenuItem1.Text = "Add to assembly"
        ' 
        ' ReplaceSelectedToolStripMenuItem
        ' 
        ReplaceSelectedToolStripMenuItem.Name = "ReplaceSelectedToolStripMenuItem"
        ReplaceSelectedToolStripMenuItem.Size = New Size(162, 22)
        ReplaceSelectedToolStripMenuItem.Text = "Replace selected"
        ' 
        ' ReplaceAllToolStripMenuItem
        ' 
        ReplaceAllToolStripMenuItem.Name = "ReplaceAllToolStripMenuItem"
        ReplaceAllToolStripMenuItem.Size = New Size(162, 22)
        ReplaceAllToolStripMenuItem.Text = "Replace all"
        ' 
        ' FastenerStackToolStripMenuItem
        ' 
        FastenerStackToolStripMenuItem.Name = "FastenerStackToolStripMenuItem"
        FastenerStackToolStripMenuItem.Size = New Size(162, 22)
        FastenerStackToolStripMenuItem.Text = "Fastener stack"
        ' 
        ' DataGridViewDataInspector
        ' 
        DataGridViewDataInspector.AllowUserToResizeRows = False
        DataGridViewDataInspector.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewDataInspector.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3})
        DataGridViewDataInspector.Dock = DockStyle.Fill
        DataGridViewDataInspector.Location = New Point(3, 3)
        DataGridViewDataInspector.Name = "DataGridViewDataInspector"
        DataGridViewDataInspector.RowHeadersVisible = False
        DataGridViewDataInspector.Size = New Size(478, 423)
        DataGridViewDataInspector.TabIndex = 0
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Property"
        Column1.Name = "Column1"
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column2.HeaderText = "Type"
        Column2.Name = "Column2"
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Value"
        Column3.Name = "Column3"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Left
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(212, 143)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' ButtonClose
        ' 
        ButtonClose.Anchor = AnchorStyles.Bottom
        ButtonClose.BackColor = Color.White
        ButtonClose.Location = New Point(303, 116)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(90, 30)
        ButtonClose.TabIndex = 2
        ButtonClose.Text = "Close"
        ButtonClose.UseVisualStyleBackColor = False
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPageTreeSearch)
        TabControl1.Controls.Add(TabPagePropertySearch)
        TabControl1.Controls.Add(TabPageInspectData)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.ImageList = ImageList1
        TabControl1.Location = New Point(3, 3)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(492, 457)
        TabControl1.TabIndex = 1
        ' 
        ' TabPageTreeSearch
        ' 
        TabPageTreeSearch.Controls.Add(TableLayoutPanel2)
        TabPageTreeSearch.ImageKey = "icons8_Folders_16.png"
        TabPageTreeSearch.Location = New Point(4, 24)
        TabPageTreeSearch.Name = "TabPageTreeSearch"
        TabPageTreeSearch.Padding = New Padding(3)
        TabPageTreeSearch.Size = New Size(484, 429)
        TabPageTreeSearch.TabIndex = 0
        TabPageTreeSearch.Text = "Tree Search"
        TabPageTreeSearch.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(ToolStrip1, 0, 0)
        TableLayoutPanel2.Controls.Add(TreeView1, 0, 1)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle())
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(478, 423)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' TabPagePropertySearch
        ' 
        TabPagePropertySearch.Controls.Add(TableLayoutPanel4)
        TabPagePropertySearch.ImageKey = "icons8_list_view_16.png"
        TabPagePropertySearch.Location = New Point(4, 24)
        TabPagePropertySearch.Name = "TabPagePropertySearch"
        TabPagePropertySearch.Padding = New Padding(3)
        TabPagePropertySearch.Size = New Size(484, 429)
        TabPagePropertySearch.TabIndex = 2
        TabPagePropertySearch.Text = "Property Search"
        TabPagePropertySearch.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(TableLayoutPanel5, 0, 0)
        TableLayoutPanel4.Controls.Add(DataGridViewVendorParts, 0, 1)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 3)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(478, 423)
        TableLayoutPanel4.TabIndex = 0
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 30F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 30F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel5.Controls.Add(ButtonSearchProperties, 1, 0)
        TableLayoutPanel5.Controls.Add(TextBoxSearchTerms, 0, 0)
        TableLayoutPanel5.Controls.Add(ButtonPropertySearchOptions, 2, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(3, 3)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle())
        TableLayoutPanel5.Size = New Size(472, 29)
        TableLayoutPanel5.TabIndex = 1
        ' 
        ' ButtonSearchProperties
        ' 
        ButtonSearchProperties.Image = My.Resources.Resources.icons8_search_16
        ButtonSearchProperties.Location = New Point(415, 3)
        ButtonSearchProperties.Name = "ButtonSearchProperties"
        ButtonSearchProperties.Size = New Size(24, 23)
        ButtonSearchProperties.TabIndex = 0
        ButtonSearchProperties.UseVisualStyleBackColor = True
        ' 
        ' TextBoxSearchTerms
        ' 
        TextBoxSearchTerms.Dock = DockStyle.Fill
        TextBoxSearchTerms.Location = New Point(3, 3)
        TextBoxSearchTerms.Name = "TextBoxSearchTerms"
        TextBoxSearchTerms.Size = New Size(406, 23)
        TextBoxSearchTerms.TabIndex = 2
        ' 
        ' ButtonPropertySearchOptions
        ' 
        ButtonPropertySearchOptions.Image = My.Resources.Resources.Support_16
        ButtonPropertySearchOptions.Location = New Point(445, 3)
        ButtonPropertySearchOptions.Name = "ButtonPropertySearchOptions"
        ButtonPropertySearchOptions.Size = New Size(24, 23)
        ButtonPropertySearchOptions.TabIndex = 3
        ButtonPropertySearchOptions.UseVisualStyleBackColor = True
        ' 
        ' DataGridViewVendorParts
        ' 
        DataGridViewCellStyle1.BackColor = Color.AliceBlue
        DataGridViewVendorParts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewVendorParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewVendorParts.Columns.AddRange(New DataGridViewColumn() {Filename, Path})
        DataGridViewVendorParts.ContextMenuStrip = ContextMenuStrip2
        DataGridViewVendorParts.Dock = DockStyle.Fill
        DataGridViewVendorParts.EditMode = DataGridViewEditMode.EditProgrammatically
        DataGridViewVendorParts.Location = New Point(3, 38)
        DataGridViewVendorParts.MultiSelect = False
        DataGridViewVendorParts.Name = "DataGridViewVendorParts"
        DataGridViewVendorParts.RowHeadersVisible = False
        DataGridViewVendorParts.Size = New Size(472, 382)
        DataGridViewVendorParts.TabIndex = 2
        ' 
        ' Filename
        ' 
        Filename.HeaderText = "Filename"
        Filename.Name = "Filename"
        Filename.Width = 150
        ' 
        ' Path
        ' 
        Path.HeaderText = "Path"
        Path.Name = "Path"
        Path.Width = 50
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {AddToAssemblyToolStripMenuItem})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(163, 26)
        ' 
        ' AddToAssemblyToolStripMenuItem
        ' 
        AddToAssemblyToolStripMenuItem.Name = "AddToAssemblyToolStripMenuItem"
        AddToAssemblyToolStripMenuItem.Size = New Size(162, 22)
        AddToAssemblyToolStripMenuItem.Text = "Add to assembly"
        ' 
        ' TabPageInspectData
        ' 
        TabPageInspectData.Controls.Add(DataGridViewDataInspector)
        TabPageInspectData.ImageKey = "icons8-search-16.png"
        TabPageInspectData.Location = New Point(4, 24)
        TabPageInspectData.Name = "TabPageInspectData"
        TabPageInspectData.Padding = New Padding(3)
        TabPageInspectData.Size = New Size(484, 429)
        TabPageInspectData.TabIndex = 1
        TabPageInspectData.Text = "Data Inspector"
        TabPageInspectData.UseVisualStyleBackColor = True
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "icons8_Folders_16.png")
        ImageList1.Images.SetKeyName(1, "icons8-search-16.png")
        ImageList1.Images.SetKeyName(2, "icons8_list_view_16.png")
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(TabControl1, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 0, 1)
        TableLayoutPanel1.Controls.Add(TextBoxStatus, 0, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 155F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(498, 647)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel3.Controls.Add(ButtonHelp, 2, 0)
        TableLayoutPanel3.Controls.Add(ButtonClose, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 466)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(492, 149)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom
        ButtonHelp.BackColor = Color.White
        ButtonHelp.Location = New Point(399, 116)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(90, 30)
        ButtonHelp.TabIndex = 3
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = False
        ' 
        ' TextBoxStatus
        ' 
        TextBoxStatus.BackColor = SystemColors.Control
        TextBoxStatus.Dock = DockStyle.Fill
        TextBoxStatus.Location = New Point(3, 621)
        TextBoxStatus.Name = "TextBoxStatus"
        TextBoxStatus.Size = New Size(492, 23)
        TextBoxStatus.TabIndex = 3
        TextBoxStatus.Text = "Status"
        ' 
        ' Form_Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(498, 647)
        Controls.Add(TableLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form_Main"
        Text = "Solid Edge Storekeeper"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        CType(DataGridViewDataInspector, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabPageTreeSearch.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TabPagePropertySearch.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        CType(DataGridViewVendorParts, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip2.ResumeLayout(False)
        TabPageInspectData.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonOptions As ToolStripButton
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridViewDataInspector As DataGridView
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageTreeSearch As TabPage
    Friend WithEvents TabPageInspectData As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents ButtonHelp As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents TextBoxStatus As TextBox
    Friend WithEvents ButtonCollapse As ToolStripButton
    Friend WithEvents TabPagePropertySearch As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents ButtonSearchProperties As Button
    Friend WithEvents TextBoxSearchTerms As TextBox
    Friend WithEvents DataGridViewVendorParts As DataGridView
    Friend WithEvents Filename As DataGridViewTextBoxColumn
    Friend WithEvents Path As DataGridViewTextBoxColumn
    Friend WithEvents ButtonPropertySearchOptions As Button
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents AddToAssemblyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents LabelSaveIn As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ReplaceSelectedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReplaceAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FastenerStackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ComboBoxMaterials As ToolStripComboBox
    Friend WithEvents ComboBoxSaveIn As ToolStripComboBox
    Friend WithEvents LabelMaterials As ToolStripLabel

End Class
