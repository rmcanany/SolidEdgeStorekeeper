<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFastenerStack
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFastenerStack))
        PictureBox1 = New PictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        LabelTopFastener = New Label()
        LabelTopLockwasher = New Label()
        LabelTopFlatWasher = New Label()
        LabelBottomFlatWasher = New Label()
        LabelBottomLockwasher = New Label()
        LabelBottomNut = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        TextBoxClampedThickness = New TextBox()
        LabelClampedThickness = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        TextBoxThreadEngagementMin = New TextBox()
        LabelThreadEngagementMin = New Label()
        TableLayoutPanel5 = New TableLayoutPanel()
        TextBoxThreadDepth = New TextBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        GetThreadDepthToolStripMenuItem = New ToolStripMenuItem()
        LabelThreadDepth = New Label()
        TableLayoutPanel6 = New TableLayoutPanel()
        TextBoxExtensionMin = New TextBox()
        LabelExtensionMin = New Label()
        ButtonPasteTopFastener = New Button()
        ButtonPasteTopLockwasher = New Button()
        ButtonPasteTopFlatWasher = New Button()
        ButtonPasteBottomFlatWasher = New Button()
        ButtonPasteBottomLockwasher = New Button()
        ButtonPasteBottomNut = New Button()
        ButtonLockTopLockwasher = New Button()
        ButtonLockTopFlatWasher = New Button()
        ButtonLockClampedThickness = New Button()
        ButtonLockThreadEngagementMin = New Button()
        ButtonLockThreadDepth = New Button()
        ButtonLockBottomFlatWasher = New Button()
        ButtonLockBottomLockwasher = New Button()
        ButtonLockBottomNut = New Button()
        ButtonLockExtensionMin = New Button()
        TableLayoutPanel2 = New TableLayoutPanel()
        ToolStrip1 = New ToolStrip()
        ButtonStackConfiguration = New ToolStripButton()
        LabelStackConfiguration = New ToolStripLabel()
        ToolStripSeparator1 = New ToolStripSeparator()
        ComboBoxUnits = New ToolStripComboBox()
        ToolStripSeparator2 = New ToolStripSeparator()
        Panel1 = New Panel()
        TableLayoutPanel7 = New TableLayoutPanel()
        ButtonHelp = New Button()
        ButtonClose = New Button()
        ButtonAddToAssy = New Button()
        LabelStatus = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        ToolStrip1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel7.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.FastenerStack_F_CO_N
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(312, 391)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 30F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(LabelTopFastener, 2, 0)
        TableLayoutPanel1.Controls.Add(LabelTopLockwasher, 2, 1)
        TableLayoutPanel1.Controls.Add(LabelTopFlatWasher, 2, 2)
        TableLayoutPanel1.Controls.Add(LabelBottomFlatWasher, 2, 10)
        TableLayoutPanel1.Controls.Add(LabelBottomLockwasher, 2, 11)
        TableLayoutPanel1.Controls.Add(LabelBottomNut, 2, 12)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 1, 7)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel4, 1, 8)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel5, 1, 9)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel6, 1, 13)
        TableLayoutPanel1.Controls.Add(ButtonPasteTopFastener, 1, 0)
        TableLayoutPanel1.Controls.Add(ButtonPasteTopLockwasher, 1, 1)
        TableLayoutPanel1.Controls.Add(ButtonPasteTopFlatWasher, 1, 2)
        TableLayoutPanel1.Controls.Add(ButtonPasteBottomFlatWasher, 1, 10)
        TableLayoutPanel1.Controls.Add(ButtonPasteBottomLockwasher, 1, 11)
        TableLayoutPanel1.Controls.Add(ButtonPasteBottomNut, 1, 12)
        TableLayoutPanel1.Controls.Add(ButtonLockTopLockwasher, 0, 1)
        TableLayoutPanel1.Controls.Add(ButtonLockTopFlatWasher, 0, 2)
        TableLayoutPanel1.Controls.Add(ButtonLockClampedThickness, 0, 7)
        TableLayoutPanel1.Controls.Add(ButtonLockThreadEngagementMin, 0, 8)
        TableLayoutPanel1.Controls.Add(ButtonLockThreadDepth, 0, 9)
        TableLayoutPanel1.Controls.Add(ButtonLockBottomFlatWasher, 0, 10)
        TableLayoutPanel1.Controls.Add(ButtonLockBottomLockwasher, 0, 11)
        TableLayoutPanel1.Controls.Add(ButtonLockBottomNut, 0, 12)
        TableLayoutPanel1.Controls.Add(ButtonLockExtensionMin, 0, 13)
        TableLayoutPanel1.Location = New Point(318, 13)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 16
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        TableLayoutPanel1.Size = New Size(297, 369)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' LabelTopFastener
        ' 
        LabelTopFastener.Anchor = AnchorStyles.Left
        LabelTopFastener.AutoSize = True
        LabelTopFastener.Location = New Point(63, 5)
        LabelTopFastener.Name = "LabelTopFastener"
        LabelTopFastener.Size = New Size(51, 15)
        LabelTopFastener.TabIndex = 1
        LabelTopFastener.Text = "Fastener"
        ' 
        ' LabelTopLockwasher
        ' 
        LabelTopLockwasher.Anchor = AnchorStyles.Left
        LabelTopLockwasher.AutoSize = True
        LabelTopLockwasher.Location = New Point(63, 31)
        LabelTopLockwasher.Name = "LabelTopLockwasher"
        LabelTopLockwasher.Size = New Size(72, 15)
        LabelTopLockwasher.TabIndex = 8
        LabelTopLockwasher.Text = "Lock washer"
        ' 
        ' LabelTopFlatWasher
        ' 
        LabelTopFlatWasher.Anchor = AnchorStyles.Left
        LabelTopFlatWasher.AutoSize = True
        LabelTopFlatWasher.Location = New Point(63, 57)
        LabelTopFlatWasher.Name = "LabelTopFlatWasher"
        LabelTopFlatWasher.Size = New Size(68, 15)
        LabelTopFlatWasher.TabIndex = 9
        LabelTopFlatWasher.Text = "Flat Washer"
        ' 
        ' LabelBottomFlatWasher
        ' 
        LabelBottomFlatWasher.Anchor = AnchorStyles.Left
        LabelBottomFlatWasher.AutoSize = True
        LabelBottomFlatWasher.Location = New Point(63, 265)
        LabelBottomFlatWasher.Name = "LabelBottomFlatWasher"
        LabelBottomFlatWasher.Size = New Size(66, 15)
        LabelBottomFlatWasher.TabIndex = 13
        LabelBottomFlatWasher.Text = "Flat washer"
        ' 
        ' LabelBottomLockwasher
        ' 
        LabelBottomLockwasher.Anchor = AnchorStyles.Left
        LabelBottomLockwasher.AutoSize = True
        LabelBottomLockwasher.Location = New Point(63, 291)
        LabelBottomLockwasher.Name = "LabelBottomLockwasher"
        LabelBottomLockwasher.Size = New Size(72, 15)
        LabelBottomLockwasher.TabIndex = 14
        LabelBottomLockwasher.Text = "Lock washer"
        ' 
        ' LabelBottomNut
        ' 
        LabelBottomNut.Anchor = AnchorStyles.Left
        LabelBottomNut.AutoSize = True
        LabelBottomNut.Location = New Point(63, 317)
        LabelBottomNut.Name = "LabelBottomNut"
        LabelBottomNut.Size = New Size(27, 15)
        LabelBottomNut.TabIndex = 15
        LabelBottomNut.Text = "Nut"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel3, 2)
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(TextBoxClampedThickness, 0, 0)
        TableLayoutPanel3.Controls.Add(LabelClampedThickness, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(33, 185)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(261, 20)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' TextBoxClampedThickness
        ' 
        TextBoxClampedThickness.Dock = DockStyle.Fill
        TextBoxClampedThickness.Location = New Point(3, 3)
        TextBoxClampedThickness.Name = "TextBoxClampedThickness"
        TextBoxClampedThickness.Size = New Size(44, 23)
        TextBoxClampedThickness.TabIndex = 0
        TextBoxClampedThickness.Text = "0"
        TextBoxClampedThickness.TextAlign = HorizontalAlignment.Right
        ' 
        ' LabelClampedThickness
        ' 
        LabelClampedThickness.Anchor = AnchorStyles.Left
        LabelClampedThickness.AutoSize = True
        LabelClampedThickness.Location = New Point(53, 2)
        LabelClampedThickness.Name = "LabelClampedThickness"
        LabelClampedThickness.Size = New Size(128, 15)
        LabelClampedThickness.TabIndex = 1
        LabelClampedThickness.Text = "Clamped thickness (in)"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel4, 2)
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(TextBoxThreadEngagementMin, 0, 0)
        TableLayoutPanel4.Controls.Add(LabelThreadEngagementMin, 1, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(33, 211)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel4.Size = New Size(261, 20)
        TableLayoutPanel4.TabIndex = 3
        ' 
        ' TextBoxThreadEngagementMin
        ' 
        TextBoxThreadEngagementMin.Dock = DockStyle.Fill
        TextBoxThreadEngagementMin.Location = New Point(3, 3)
        TextBoxThreadEngagementMin.Name = "TextBoxThreadEngagementMin"
        TextBoxThreadEngagementMin.Size = New Size(44, 23)
        TextBoxThreadEngagementMin.TabIndex = 0
        TextBoxThreadEngagementMin.Text = "0"
        TextBoxThreadEngagementMin.TextAlign = HorizontalAlignment.Right
        ' 
        ' LabelThreadEngagementMin
        ' 
        LabelThreadEngagementMin.Anchor = AnchorStyles.Left
        LabelThreadEngagementMin.AutoSize = True
        LabelThreadEngagementMin.Location = New Point(53, 2)
        LabelThreadEngagementMin.Name = "LabelThreadEngagementMin"
        LabelThreadEngagementMin.Size = New Size(188, 15)
        LabelThreadEngagementMin.TabIndex = 1
        LabelThreadEngagementMin.Text = "Minimum thread engagement (in)"
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 2
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel5, 2)
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.Controls.Add(TextBoxThreadDepth, 0, 0)
        TableLayoutPanel5.Controls.Add(LabelThreadDepth, 1, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(33, 237)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel5.Size = New Size(261, 20)
        TableLayoutPanel5.TabIndex = 4
        ' 
        ' TextBoxThreadDepth
        ' 
        TextBoxThreadDepth.ContextMenuStrip = ContextMenuStrip1
        TextBoxThreadDepth.Dock = DockStyle.Fill
        TextBoxThreadDepth.Location = New Point(3, 3)
        TextBoxThreadDepth.Name = "TextBoxThreadDepth"
        TextBoxThreadDepth.Size = New Size(44, 23)
        TextBoxThreadDepth.TabIndex = 0
        TextBoxThreadDepth.Text = "0"
        TextBoxThreadDepth.TextAlign = HorizontalAlignment.Right
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {GetThreadDepthToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(164, 26)
        ' 
        ' GetThreadDepthToolStripMenuItem
        ' 
        GetThreadDepthToolStripMenuItem.Name = "GetThreadDepthToolStripMenuItem"
        GetThreadDepthToolStripMenuItem.Size = New Size(163, 22)
        GetThreadDepthToolStripMenuItem.Text = "Get thread depth"
        ' 
        ' LabelThreadDepth
        ' 
        LabelThreadDepth.Anchor = AnchorStyles.Left
        LabelThreadDepth.AutoSize = True
        LabelThreadDepth.Location = New Point(53, 2)
        LabelThreadDepth.Name = "LabelThreadDepth"
        LabelThreadDepth.Size = New Size(99, 15)
        LabelThreadDepth.TabIndex = 1
        LabelThreadDepth.Text = "Thread depth (in)"
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 2
        TableLayoutPanel1.SetColumnSpan(TableLayoutPanel6, 2)
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel6.Controls.Add(TextBoxExtensionMin, 0, 0)
        TableLayoutPanel6.Controls.Add(LabelExtensionMin, 1, 0)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(33, 341)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 1
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel6.Size = New Size(261, 20)
        TableLayoutPanel6.TabIndex = 5
        ' 
        ' TextBoxExtensionMin
        ' 
        TextBoxExtensionMin.Dock = DockStyle.Fill
        TextBoxExtensionMin.Location = New Point(3, 3)
        TextBoxExtensionMin.Name = "TextBoxExtensionMin"
        TextBoxExtensionMin.Size = New Size(44, 23)
        TextBoxExtensionMin.TabIndex = 0
        TextBoxExtensionMin.Text = "0"
        TextBoxExtensionMin.TextAlign = HorizontalAlignment.Right
        ' 
        ' LabelExtensionMin
        ' 
        LabelExtensionMin.Anchor = AnchorStyles.Left
        LabelExtensionMin.AutoSize = True
        LabelExtensionMin.Location = New Point(53, 2)
        LabelExtensionMin.Name = "LabelExtensionMin"
        LabelExtensionMin.Size = New Size(134, 15)
        LabelExtensionMin.TabIndex = 1
        LabelExtensionMin.Text = "Minimum extension (in)"
        ' 
        ' ButtonPasteTopFastener
        ' 
        ButtonPasteTopFastener.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteTopFastener.Location = New Point(33, 3)
        ButtonPasteTopFastener.Name = "ButtonPasteTopFastener"
        ButtonPasteTopFastener.Size = New Size(19, 20)
        ButtonPasteTopFastener.TabIndex = 0
        ButtonPasteTopFastener.UseVisualStyleBackColor = True
        ' 
        ' ButtonPasteTopLockwasher
        ' 
        ButtonPasteTopLockwasher.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteTopLockwasher.Location = New Point(33, 29)
        ButtonPasteTopLockwasher.Name = "ButtonPasteTopLockwasher"
        ButtonPasteTopLockwasher.Size = New Size(19, 20)
        ButtonPasteTopLockwasher.TabIndex = 6
        ButtonPasteTopLockwasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonPasteTopFlatWasher
        ' 
        ButtonPasteTopFlatWasher.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteTopFlatWasher.Location = New Point(33, 55)
        ButtonPasteTopFlatWasher.Name = "ButtonPasteTopFlatWasher"
        ButtonPasteTopFlatWasher.Size = New Size(19, 20)
        ButtonPasteTopFlatWasher.TabIndex = 7
        ButtonPasteTopFlatWasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonPasteBottomFlatWasher
        ' 
        ButtonPasteBottomFlatWasher.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteBottomFlatWasher.Location = New Point(33, 263)
        ButtonPasteBottomFlatWasher.Name = "ButtonPasteBottomFlatWasher"
        ButtonPasteBottomFlatWasher.Size = New Size(19, 20)
        ButtonPasteBottomFlatWasher.TabIndex = 10
        ButtonPasteBottomFlatWasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonPasteBottomLockwasher
        ' 
        ButtonPasteBottomLockwasher.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteBottomLockwasher.Location = New Point(33, 289)
        ButtonPasteBottomLockwasher.Name = "ButtonPasteBottomLockwasher"
        ButtonPasteBottomLockwasher.Size = New Size(19, 20)
        ButtonPasteBottomLockwasher.TabIndex = 11
        ButtonPasteBottomLockwasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonPasteBottomNut
        ' 
        ButtonPasteBottomNut.Image = My.Resources.Resources.icons8_paste_16
        ButtonPasteBottomNut.Location = New Point(33, 315)
        ButtonPasteBottomNut.Name = "ButtonPasteBottomNut"
        ButtonPasteBottomNut.Size = New Size(19, 20)
        ButtonPasteBottomNut.TabIndex = 12
        ButtonPasteBottomNut.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockTopLockwasher
        ' 
        ButtonLockTopLockwasher.Image = My.Resources.Resources.unlocked
        ButtonLockTopLockwasher.Location = New Point(3, 29)
        ButtonLockTopLockwasher.Name = "ButtonLockTopLockwasher"
        ButtonLockTopLockwasher.Size = New Size(24, 20)
        ButtonLockTopLockwasher.TabIndex = 16
        ButtonLockTopLockwasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockTopFlatWasher
        ' 
        ButtonLockTopFlatWasher.Image = My.Resources.Resources.unlocked
        ButtonLockTopFlatWasher.Location = New Point(3, 55)
        ButtonLockTopFlatWasher.Name = "ButtonLockTopFlatWasher"
        ButtonLockTopFlatWasher.Size = New Size(24, 20)
        ButtonLockTopFlatWasher.TabIndex = 17
        ButtonLockTopFlatWasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockClampedThickness
        ' 
        ButtonLockClampedThickness.Image = My.Resources.Resources.unlocked
        ButtonLockClampedThickness.Location = New Point(3, 185)
        ButtonLockClampedThickness.Name = "ButtonLockClampedThickness"
        ButtonLockClampedThickness.Size = New Size(24, 20)
        ButtonLockClampedThickness.TabIndex = 18
        ButtonLockClampedThickness.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockThreadEngagementMin
        ' 
        ButtonLockThreadEngagementMin.Image = My.Resources.Resources.unlocked
        ButtonLockThreadEngagementMin.Location = New Point(3, 211)
        ButtonLockThreadEngagementMin.Name = "ButtonLockThreadEngagementMin"
        ButtonLockThreadEngagementMin.Size = New Size(24, 20)
        ButtonLockThreadEngagementMin.TabIndex = 19
        ButtonLockThreadEngagementMin.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockThreadDepth
        ' 
        ButtonLockThreadDepth.Image = My.Resources.Resources.unlocked
        ButtonLockThreadDepth.Location = New Point(3, 237)
        ButtonLockThreadDepth.Name = "ButtonLockThreadDepth"
        ButtonLockThreadDepth.Size = New Size(24, 20)
        ButtonLockThreadDepth.TabIndex = 20
        ButtonLockThreadDepth.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockBottomFlatWasher
        ' 
        ButtonLockBottomFlatWasher.Image = My.Resources.Resources.unlocked
        ButtonLockBottomFlatWasher.Location = New Point(3, 263)
        ButtonLockBottomFlatWasher.Name = "ButtonLockBottomFlatWasher"
        ButtonLockBottomFlatWasher.Size = New Size(24, 20)
        ButtonLockBottomFlatWasher.TabIndex = 21
        ButtonLockBottomFlatWasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockBottomLockwasher
        ' 
        ButtonLockBottomLockwasher.Image = My.Resources.Resources.unlocked
        ButtonLockBottomLockwasher.Location = New Point(3, 289)
        ButtonLockBottomLockwasher.Name = "ButtonLockBottomLockwasher"
        ButtonLockBottomLockwasher.Size = New Size(24, 20)
        ButtonLockBottomLockwasher.TabIndex = 22
        ButtonLockBottomLockwasher.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockBottomNut
        ' 
        ButtonLockBottomNut.Image = My.Resources.Resources.unlocked
        ButtonLockBottomNut.Location = New Point(3, 315)
        ButtonLockBottomNut.Name = "ButtonLockBottomNut"
        ButtonLockBottomNut.Size = New Size(24, 20)
        ButtonLockBottomNut.TabIndex = 23
        ButtonLockBottomNut.UseVisualStyleBackColor = True
        ' 
        ' ButtonLockExtensionMin
        ' 
        ButtonLockExtensionMin.Image = My.Resources.Resources.unlocked
        ButtonLockExtensionMin.Location = New Point(3, 341)
        ButtonLockExtensionMin.Name = "ButtonLockExtensionMin"
        ButtonLockExtensionMin.Size = New Size(24, 20)
        ButtonLockExtensionMin.TabIndex = 24
        ButtonLockExtensionMin.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(ToolStrip1, 0, 0)
        TableLayoutPanel2.Controls.Add(Panel1, 0, 1)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel7, 0, 2)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 400F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        TableLayoutPanel2.Size = New Size(624, 486)
        TableLayoutPanel2.TabIndex = 2
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ButtonStackConfiguration, LabelStackConfiguration, ToolStripSeparator1, ComboBoxUnits, ToolStripSeparator2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(624, 25)
        ToolStrip1.TabIndex = 0
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ButtonStackConfiguration
        ' 
        ButtonStackConfiguration.DisplayStyle = ToolStripItemDisplayStyle.Image
        ButtonStackConfiguration.Image = My.Resources.Resources.icons8_choose_16
        ButtonStackConfiguration.ImageTransparentColor = Color.Magenta
        ButtonStackConfiguration.Name = "ButtonStackConfiguration"
        ButtonStackConfiguration.Size = New Size(23, 22)
        ButtonStackConfiguration.ToolTipText = "Select fastener stack configuration"
        ' 
        ' LabelStackConfiguration
        ' 
        LabelStackConfiguration.Name = "LabelStackConfiguration"
        LabelStackConfiguration.Size = New Size(81, 22)
        LabelStackConfiguration.Text = "Configuration"
        LabelStackConfiguration.ToolTipText = "Select fastener stack configuration"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' ComboBoxUnits
        ' 
        ComboBoxUnits.AutoSize = False
        ComboBoxUnits.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxUnits.DropDownWidth = 50
        ComboBoxUnits.Items.AddRange(New Object() {"in", "mm"})
        ComboBoxUnits.Name = "ComboBoxUnits"
        ComboBoxUnits.Size = New Size(50, 23)
        ComboBoxUnits.ToolTipText = "Select units"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 25)
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 33)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(618, 394)
        Panel1.TabIndex = 1
        ' 
        ' TableLayoutPanel7
        ' 
        TableLayoutPanel7.ColumnCount = 4
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 90F))
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 75F))
        TableLayoutPanel7.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 75F))
        TableLayoutPanel7.Controls.Add(ButtonHelp, 3, 0)
        TableLayoutPanel7.Controls.Add(ButtonClose, 2, 0)
        TableLayoutPanel7.Controls.Add(ButtonAddToAssy, 1, 0)
        TableLayoutPanel7.Controls.Add(LabelStatus, 0, 0)
        TableLayoutPanel7.Dock = DockStyle.Fill
        TableLayoutPanel7.Location = New Point(3, 433)
        TableLayoutPanel7.Name = "TableLayoutPanel7"
        TableLayoutPanel7.RowCount = 1
        TableLayoutPanel7.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel7.Size = New Size(618, 50)
        TableLayoutPanel7.TabIndex = 2
        ' 
        ' ButtonHelp
        ' 
        ButtonHelp.Anchor = AnchorStyles.Bottom
        ButtonHelp.Location = New Point(546, 22)
        ButtonHelp.Name = "ButtonHelp"
        ButtonHelp.Size = New Size(69, 25)
        ButtonHelp.TabIndex = 0
        ButtonHelp.Text = "Help"
        ButtonHelp.UseVisualStyleBackColor = True
        ' 
        ' ButtonClose
        ' 
        ButtonClose.Anchor = AnchorStyles.Bottom
        ButtonClose.Location = New Point(471, 22)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(69, 25)
        ButtonClose.TabIndex = 1
        ButtonClose.Text = "Close"
        ButtonClose.UseVisualStyleBackColor = True
        ' 
        ' ButtonAddToAssy
        ' 
        ButtonAddToAssy.Anchor = AnchorStyles.Bottom
        ButtonAddToAssy.Location = New Point(381, 22)
        ButtonAddToAssy.Name = "ButtonAddToAssy"
        ButtonAddToAssy.Size = New Size(84, 25)
        ButtonAddToAssy.TabIndex = 2
        ButtonAddToAssy.Text = "Add to Assy"
        ButtonAddToAssy.UseVisualStyleBackColor = True
        ' 
        ' LabelStatus
        ' 
        LabelStatus.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        LabelStatus.AutoSize = True
        LabelStatus.Location = New Point(3, 35)
        LabelStatus.Name = "LabelStatus"
        LabelStatus.Size = New Size(39, 15)
        LabelStatus.TabIndex = 3
        LabelStatus.Text = "Status"
        ' 
        ' FormFastenerStack
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(624, 486)
        Controls.Add(TableLayoutPanel2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(640, 525)
        MinimumSize = New Size(640, 525)
        Name = "FormFastenerStack"
        Text = "Fastener Stack"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        Panel1.ResumeLayout(False)
        TableLayoutPanel7.ResumeLayout(False)
        TableLayoutPanel7.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonPasteTopFastener As Button
    Friend WithEvents LabelTopFastener As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonStackConfiguration As ToolStripButton
    Friend WithEvents LabelStackConfiguration As ToolStripLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TextBoxClampedThickness As TextBox
    Friend WithEvents LabelClampedThickness As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TextBoxThreadEngagementMin As TextBox
    Friend WithEvents LabelThreadEngagementMin As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TextBoxThreadDepth As TextBox
    Friend WithEvents LabelThreadDepth As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TextBoxExtensionMin As TextBox
    Friend WithEvents LabelExtensionMin As Label
    Friend WithEvents ButtonPasteTopLockwasher As Button
    Friend WithEvents ButtonPasteTopFlatWasher As Button
    Friend WithEvents LabelTopLockwasher As Label
    Friend WithEvents LabelTopFlatWasher As Label
    Friend WithEvents ButtonPasteBottomFlatWasher As Button
    Friend WithEvents ButtonPasteBottomLockwasher As Button
    Friend WithEvents ButtonPasteBottomNut As Button
    Friend WithEvents LabelBottomFlatWasher As Label
    Friend WithEvents LabelBottomLockwasher As Label
    Friend WithEvents LabelBottomNut As Label
    Friend WithEvents ComboBoxUnits As ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonLockTopLockwasher As Button
    Friend WithEvents ButtonLockTopFlatWasher As Button
    Friend WithEvents ButtonLockClampedThickness As Button
    Friend WithEvents ButtonLockThreadEngagementMin As Button
    Friend WithEvents ButtonLockThreadDepth As Button
    Friend WithEvents ButtonLockBottomFlatWasher As Button
    Friend WithEvents ButtonLockBottomLockwasher As Button
    Friend WithEvents ButtonLockBottomNut As Button
    Friend WithEvents ButtonLockExtensionMin As Button
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents ButtonHelp As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ButtonAddToAssy As Button
    Friend WithEvents LabelStatus As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents GetThreadDepthToolStripMenuItem As ToolStripMenuItem
End Class
