Public Class FormPropertySearchOptions

    Public Property FMain As Form_Main
    Public Property PropertiesData As HCPropertiesData
    Private Property PropertiesToSearchList As List(Of String)

    Private _AssemblyTemplate As String
    Public Property AssemblyTemplate As String
        Get
            Return _AssemblyTemplate
        End Get
        Set(value As String)
            _AssemblyTemplate = value
            If TableLayoutPanel1 IsNot Nothing Then
                TextBoxAssemblyTemplate.Text = value
            End If
        End Set
    End Property

    Private _PartTemplate As String
    Public Property PartTemplate As String
        Get
            Return _PartTemplate
        End Get
        Set(value As String)
            _PartTemplate = value
            If TableLayoutPanel1 IsNot Nothing Then
                TextBoxPartTemplate.Text = value
            End If
        End Set
    End Property

    Private _SheetmetalTemplate As String
    Public Property SheetmetalTemplate As String
        Get
            Return _SheetmetalTemplate
        End Get
        Set(value As String)
            _SheetmetalTemplate = value
            If TableLayoutPanel1 IsNot Nothing Then
                TextBoxSheetmetalTemplate.Text = value
            End If
        End Set
    End Property

    Private _CacheProperties As Boolean
    Public Property CacheProperties As Boolean
        Get
            Return _CacheProperties
        End Get
        Set(value As Boolean)
            _CacheProperties = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxCacheProperties.Checked = CacheProperties
            End If
        End Set
    End Property



    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FMain = _FMain

    End Sub

    Private Sub FormPropertySearchOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PropertiesData = FMain.PropertiesData
        AssemblyTemplate = FMain.AssemblyTemplate
        PartTemplate = FMain.PartTemplate
        SheetmetalTemplate = FMain.SheetmetalTemplate
        Me.CacheProperties = FMain.CacheProperties

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

    Private Sub ButtonAssemblyTemplate_Click(sender As Object, e As EventArgs) Handles ButtonAssemblyTemplate.Click
        Dim tmpFileDialog As New OpenFileDialog
        tmpFileDialog.Title = "Select an assembly template"
        tmpFileDialog.Filter = "Assembly Template|*.asm"

        If tmpFileDialog.ShowDialog() = DialogResult.OK Then
            AssemblyTemplate = tmpFileDialog.FileName
        End If

    End Sub

    Private Sub ButtonPartTemplate_Click(sender As Object, e As EventArgs) Handles ButtonPartTemplate.Click

        Dim tmpFileDialog As New OpenFileDialog
        tmpFileDialog.Title = "Select a part template"
        tmpFileDialog.Filter = "Part Template|*.par"

        If tmpFileDialog.ShowDialog() = DialogResult.OK Then
            PartTemplate = tmpFileDialog.FileName
        End If

    End Sub

    Private Sub ButtonSheetmetalTemplate_Click(sender As Object, e As EventArgs) Handles ButtonSheetmetalTemplate.Click

        Dim tmpFileDialog As New OpenFileDialog
        tmpFileDialog.Title = "Select a sheetmetal template"
        tmpFileDialog.Filter = "Sheetmetal Template|*.psm"

        If tmpFileDialog.ShowDialog() = DialogResult.OK Then
            SheetmetalTemplate = tmpFileDialog.FileName
        End If

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        PropertiesData.Populate({AssemblyTemplate, PartTemplate, SheetmetalTemplate}.ToList)

        FMain.PropertiesData = PropertiesData
        FMain.AssemblyTemplate = AssemblyTemplate
        FMain.PartTemplate = PartTemplate
        FMain.SheetmetalTemplate = SheetmetalTemplate
        FMain.CacheProperties = Me.CacheProperties

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

    Private Sub ButtonHelp_Click(sender As Object, e As EventArgs) Handles ButtonHelp.Click
        Dim Info = New ProcessStartInfo()
        Info.FileName = "https://github.com/rmcanany/SolidEdgeStorekeeper#property-search"
        Info.UseShellExecute = True
        System.Diagnostics.Process.Start(Info)
    End Sub

    Private Sub CheckBoxCacheProperties_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCacheProperties.CheckedChanged
        Me.CacheProperties = CheckBoxCacheProperties.Checked
    End Sub
End Class