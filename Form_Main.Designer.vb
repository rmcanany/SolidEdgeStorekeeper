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
        ButtonSaveDirectory = New ToolStripButton()
        LabelSaveDirectory = New ToolStripLabel()
        ButtonOptions = New ToolStripButton()
        TreeView1 = New TreeView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        ToolStripMenuItem1 = New ToolStripMenuItem()
        DataGridView1 = New DataGridView()
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
        DataGridView2 = New DataGridView()
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
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabPageTreeSearch.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TabPagePropertySearch.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip2.SuspendLayout()
        TabPageInspectData.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ButtonCollapse, ButtonSaveDirectory, LabelSaveDirectory, ButtonOptions})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(402, 25)
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
        ButtonCollapse.Text = "ToolStripButton1"
        ButtonCollapse.ToolTipText = "Collapse"
        ' 
        ' ButtonSaveDirectory
        ' 
        ButtonSaveDirectory.DisplayStyle = ToolStripItemDisplayStyle.Image
        ButtonSaveDirectory.Image = My.Resources.Resources.icons8_Folder_16
        ButtonSaveDirectory.ImageTransparentColor = Color.Magenta
        ButtonSaveDirectory.Name = "ButtonSaveDirectory"
        ButtonSaveDirectory.Size = New Size(23, 22)
        ButtonSaveDirectory.Text = "ButtonSaveDirectory"
        ButtonSaveDirectory.ToolTipText = "Library Directory"
        ' 
        ' LabelSaveDirectory
        ' 
        LabelSaveDirectory.Name = "LabelSaveDirectory"
        LabelSaveDirectory.Size = New Size(201, 22)
        LabelSaveDirectory.Text = "Select directory location for new files"
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
        ' TreeView1
        ' 
        TreeView1.ContextMenuStrip = ContextMenuStrip1
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
        TreeView1.Size = New Size(396, 392)
        TreeView1.TabIndex = 1
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(163, 26)
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(162, 22)
        ToolStripMenuItem1.Text = "Add to assembly"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3})
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 3)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Size = New Size(402, 423)
        DataGridView1.TabIndex = 0
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
        ButtonClose.Location = New Point(338, 123)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(75, 23)
        ButtonClose.TabIndex = 2
        ButtonClose.Text = "Close"
        ButtonClose.UseVisualStyleBackColor = True
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
        TabControl1.Size = New Size(416, 457)
        TabControl1.TabIndex = 1
        ' 
        ' TabPageTreeSearch
        ' 
        TabPageTreeSearch.Controls.Add(TableLayoutPanel2)
        TabPageTreeSearch.ImageKey = "icons8_Folders_16.png"
        TabPageTreeSearch.Location = New Point(4, 24)
        TabPageTreeSearch.Name = "TabPageTreeSearch"
        TabPageTreeSearch.Padding = New Padding(3)
        TabPageTreeSearch.Size = New Size(408, 429)
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
        TableLayoutPanel2.Size = New Size(402, 423)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' TabPagePropertySearch
        ' 
        TabPagePropertySearch.Controls.Add(TableLayoutPanel4)
        TabPagePropertySearch.ImageKey = "icons8_list_view_16.png"
        TabPagePropertySearch.Location = New Point(4, 24)
        TabPagePropertySearch.Name = "TabPagePropertySearch"
        TabPagePropertySearch.Padding = New Padding(3)
        TabPagePropertySearch.Size = New Size(408, 429)
        TabPagePropertySearch.TabIndex = 2
        TabPagePropertySearch.Text = "Property Search"
        TabPagePropertySearch.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(TableLayoutPanel5, 0, 0)
        TableLayoutPanel4.Controls.Add(DataGridView2, 0, 1)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 3)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Size = New Size(402, 423)
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
        TableLayoutPanel5.Size = New Size(396, 29)
        TableLayoutPanel5.TabIndex = 1
        ' 
        ' ButtonSearchProperties
        ' 
        ButtonSearchProperties.Image = My.Resources.Resources.icons8_search_16
        ButtonSearchProperties.Location = New Point(339, 3)
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
        TextBoxSearchTerms.Size = New Size(330, 23)
        TextBoxSearchTerms.TabIndex = 2
        ' 
        ' ButtonPropertySearchOptions
        ' 
        ButtonPropertySearchOptions.Image = My.Resources.Resources.Support_16
        ButtonPropertySearchOptions.Location = New Point(369, 3)
        ButtonPropertySearchOptions.Name = "ButtonPropertySearchOptions"
        ButtonPropertySearchOptions.Size = New Size(24, 23)
        ButtonPropertySearchOptions.TabIndex = 3
        ButtonPropertySearchOptions.UseVisualStyleBackColor = True
        ' 
        ' DataGridView2
        ' 
        DataGridViewCellStyle1.BackColor = Color.AliceBlue
        DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Columns.AddRange(New DataGridViewColumn() {Filename, Path})
        DataGridView2.ContextMenuStrip = ContextMenuStrip2
        DataGridView2.Dock = DockStyle.Fill
        DataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically
        DataGridView2.Location = New Point(3, 38)
        DataGridView2.MultiSelect = False
        DataGridView2.Name = "DataGridView2"
        DataGridView2.RowHeadersVisible = False
        DataGridView2.Size = New Size(396, 382)
        DataGridView2.TabIndex = 2
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
        TabPageInspectData.Controls.Add(DataGridView1)
        TabPageInspectData.ImageKey = "icons8-search-16.png"
        TabPageInspectData.Location = New Point(4, 24)
        TabPageInspectData.Name = "TabPageInspectData"
        TabPageInspectData.Padding = New Padding(3)
        TabPageInspectData.Size = New Size(408, 429)
        TabPageInspectData.TabIndex = 1
        TabPageInspectData.Text = "Inspect Data"
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
        TableLayoutPanel1.Size = New Size(422, 647)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.Controls.Add(ButtonClose, 2, 0)
        TableLayoutPanel3.Controls.Add(ButtonHelp, 1, 0)
        TableLayoutPanel3.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 466)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(416, 149)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom
        ButtonHelp.Location = New Point(257, 123)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(75, 23)
        ButtonHelp.TabIndex = 3
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = True
        ' 
        ' TextBoxStatus
        ' 
        TextBoxStatus.BackColor = SystemColors.Control
        TextBoxStatus.Dock = DockStyle.Fill
        TextBoxStatus.Location = New Point(3, 621)
        TextBoxStatus.Name = "TextBoxStatus"
        TextBoxStatus.Size = New Size(416, 23)
        TextBoxStatus.TabIndex = 3
        TextBoxStatus.Text = "Status"
        ' 
        ' Form_Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(422, 647)
        Controls.Add(TableLayoutPanel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form_Main"
        Text = "Solid Edge Storekeeper"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabPageTreeSearch.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TabPagePropertySearch.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataGridView1 As DataGridView
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
    Friend WithEvents ButtonSaveDirectory As ToolStripButton
    Friend WithEvents LabelSaveDirectory As ToolStripLabel
    Friend WithEvents TextBoxStatus As TextBox
    Friend WithEvents ButtonCollapse As ToolStripButton
    Friend WithEvents TabPagePropertySearch As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents ButtonSearchProperties As Button
    Friend WithEvents TextBoxSearchTerms As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Filename As DataGridViewTextBoxColumn
    Friend WithEvents Path As DataGridViewTextBoxColumn
    Friend WithEvents ButtonPropertySearchOptions As Button
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents AddToAssemblyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList

End Class
