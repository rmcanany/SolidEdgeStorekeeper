Public Class FormSelectMaterial

    Private Property MaterialList As List(Of String)
    Public Property SelectedMaterial As String

    Public Sub New(_MaterialList As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MaterialList = _MaterialList

        For Each MaterialName As String In Me.MaterialList
            ComboBoxMaterial.Items.Add(MaterialName)
        Next

        ComboBoxMaterial.Text = Me.MaterialList(0)
        Me.SelectedMaterial = Me.MaterialList(0)

    End Sub
    Private Sub FormSelectMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub ComboBoxMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMaterial.SelectedIndexChanged
        Me.SelectedMaterial = ComboBoxMaterial.Text
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class