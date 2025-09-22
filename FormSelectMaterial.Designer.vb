<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelectMaterial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSelectMaterial))
        ComboBoxMaterial = New ComboBox()
        ButtonOK = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' ComboBoxMaterial
        ' 
        ComboBoxMaterial.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxMaterial.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxMaterial.FormattingEnabled = True
        ComboBoxMaterial.Location = New Point(15, 30)
        ComboBoxMaterial.Name = "ComboBoxMaterial"
        ComboBoxMaterial.Size = New Size(225, 23)
        ComboBoxMaterial.TabIndex = 0
        ' 
        ' ButtonOK
        ' 
        ButtonOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonOK.Location = New Point(160, 70)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(75, 23)
        ButtonOK.TabIndex = 1
        ButtonOK.Text = "OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(168, 15)
        Label1.TabIndex = 2
        Label1.Text = "Select the material for this part"
        ' 
        ' FormSelectMaterial
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(259, 101)
        Controls.Add(Label1)
        Controls.Add(ButtonOK)
        Controls.Add(ComboBoxMaterial)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximumSize = New Size(450, 140)
        MinimumSize = New Size(250, 140)
        Name = "FormSelectMaterial"
        StartPosition = FormStartPosition.CenterParent
        Text = "Select Material"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBoxMaterial As ComboBox
    Friend WithEvents ButtonOK As Button
    Friend WithEvents Label1 As Label
End Class
