Public Class FormPropertiesToSearch

    Private Property FMain As Form_Main
    Private Property PropertiesToSearchList As List(Of String)

    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FMain = _FMain
    End Sub

    Private Sub PropertiesToSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PropertiesToSearchList = FMain.PropertiesToSearchList

        DataGridView1.AutoGenerateColumns = False

        If PropertiesToSearchList IsNot Nothing AndAlso PropertiesToSearchList.Count > 0 Then
            ' System.Title, Custom.Whatever, ...
            For Each PropString As String In PropertiesToSearchList
                Dim Splitter = PropString.Split(CChar("."))
                Dim SystemOrCustom As String = Splitter(0)
                Dim PropertyName As String = Splitter(1)
                DataGridView1.Rows.Add(SystemOrCustom, PropertyName)
            Next
        Else
            PropertiesToSearchList = New List(Of String)
        End If
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Dim tf As Boolean

        PropertiesToSearchList.Clear()

        For Each tmpRow As DataGridViewRow In DataGridView1.Rows
            If Not tmpRow.IsNewRow Then
                Dim SystemOrCustom As String = tmpRow.Cells("SystemOrCustom").Value
                If SystemOrCustom Is Nothing Then SystemOrCustom = ""
                Dim PropertyName As String = tmpRow.Cells("PropertyName").Value
                If PropertyName Is Nothing Then PropertyName = ""

                If Not PropertyName.Trim = "" Then
                    If SystemOrCustom.ToLower = "system" Or SystemOrCustom.ToLower = "custom" Then
                        PropertiesToSearchList.Add($"{SystemOrCustom}.{PropertyName}")
                    Else
                        MsgBox($"{PropertyName}: Type ('System' or 'Custom') required", vbOKOnly)
                        Exit Sub
                    End If
                End If
            End If
        Next
        FMain.PropertiesToSearchList = PropertiesToSearchList
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class