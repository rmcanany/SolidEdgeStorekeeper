Option Strict On

Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class FormTreeSearchOptions

    Private FMain As Form_Main

    Private _TemplateDirectory As String
    Public Property TemplateDirectory As String
        Get
            Return _TemplateDirectory
        End Get
        Set(value As String)
            _TemplateDirectory = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                LabelTemplateDirectory.Text = value
            End If
        End Set
    End Property

    Private _DataDirectory As String
    Public Property DataDirectory As String
        Get
            Return _DataDirectory
        End Get
        Set(value As String)
            _DataDirectory = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                LabelDataDirectory.Text = value
            End If
        End Set
    End Property

    Private _MaterialTable As String
    Public Property MaterialTable As String
        Get
            Return _MaterialTable
        End Get
        Set(value As String)
            _MaterialTable = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                LabelMaterialLibrary.Text = value
            End If
        End Set
    End Property

    Private _AlwaysReadExcel As Boolean
    Public Property AlwaysReadExcel As Boolean
        Get
            Return _AlwaysReadExcel
        End Get
        Set(value As Boolean)
            _AlwaysReadExcel = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxAlwaysReadExcel.Checked = value
            End If
        End Set
    End Property

    Private _AutoPattern As Boolean
    Public Property AutoPattern As Boolean
        Get
            Return _AutoPattern
        End Get
        Set(value As Boolean)
            _AutoPattern = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxAutoPattern.Checked = value
            End If
        End Set
    End Property

    Private _AddProp As Boolean
    Public Property AddProp As Boolean
        Get
            Return _AddProp
        End Get
        Set(value As Boolean)
            _AddProp = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxAddProp.Checked = value
            End If
        End Set
    End Property

    Private _DisableFineThreadWarning As Boolean
    Public Property DisableFineThreadWarning As Boolean
        Get
            Return _DisableFineThreadWarning
        End Get
        Set(value As Boolean)
            _DisableFineThreadWarning = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxDisableFineThreadWarning.Checked = value
            End If
        End Set
    End Property

    Private _CheckNewVersion As Boolean
    Public Property CheckNewVersion As Boolean
        Get
            Return _CheckNewVersion
        End Get
        Set(value As Boolean)
            _CheckNewVersion = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxCheckNewVersion.Checked = value
            End If
        End Set
    End Property


    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FMain = _FMain

    End Sub

    Private Sub ButtonTemplateDirectory_Click(sender As Object, e As EventArgs) Handles ButtonTemplateDirectory.Click
        Dim tmpFolderDialog As New CommonOpenFileDialog
        tmpFolderDialog.IsFolderPicker = True

        If tmpFolderDialog.ShowDialog() = DialogResult.OK Then
            Me.TemplateDirectory = tmpFolderDialog.FileName
        End If

    End Sub

    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not FMain.TemplateDirectory = "" Then
            Me.TemplateDirectory = Me.FMain.TemplateDirectory
        Else
            Me.TemplateDirectory = "Select a directory with your standard part templates."
        End If
        If Not FMain.DataDirectory = "" Then
            Me.DataDirectory = Me.FMain.DataDirectory
        Else
            Me.TemplateDirectory = "Select a directory with your data files."
        End If
        Me.MaterialTable = FMain.MaterialTable
        'Me.ShowAnsi = Me.FMain.ShowAnsi
        'Me.ShowIso = Me.FMain.ShowIso
        Me.AlwaysReadExcel = FMain.AlwaysReadExcel
        Me.AddProp = FMain.AddProp
        Me.DisableFineThreadWarning = FMain.DisableFineThreadWarning
        Me.CheckNewVersion = FMain.CheckNewVersion
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If Me.TemplateDirectory(Me.TemplateDirectory.Count - 1) = "\" Then
            Me.TemplateDirectory = Me.TemplateDirectory.Substring(0, Me.TemplateDirectory.Count - 1)
        End If

        Me.FMain.TemplateDirectory = Me.TemplateDirectory
        Me.FMain.DataDirectory = Me.DataDirectory
        FMain.MaterialTable = Me.MaterialTable
        'Me.FMain.ShowAnsi = Me.ShowAnsi
        'Me.FMain.ShowIso = Me.ShowIso
        FMain.AlwaysReadExcel = Me.AlwaysReadExcel
        FMain.AutoPattern = Me.AutoPattern
        FMain.AddProp = Me.AddProp
        FMain.DisableFineThreadWarning = Me.DisableFineThreadWarning
        FMain.CheckNewVersion = Me.CheckNewVersion

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ButtonMaterialLibrary_Click(sender As Object, e As EventArgs) Handles ButtonMaterialLibrary.Click
        Dim tmpFileDialog As New OpenFileDialog
        tmpFileDialog.Title = "Select a material library"
        tmpFileDialog.Filter = "Material Library files|*.mtl"

        If tmpFileDialog.ShowDialog() = DialogResult.OK Then
            Me.MaterialTable = tmpFileDialog.FileName
        End If

    End Sub

    'Private Sub CheckBoxShowAnsi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAnsi.CheckedChanged
    '    Me.ShowAnsi = CheckBoxShowAnsi.Checked
    'End Sub

    'Private Sub CheckBoxShowIso_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowIso.CheckedChanged
    '    Me.ShowIso = CheckBoxShowIso.Checked
    'End Sub

    Private Sub CheckBoxAddProp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAddProp.CheckedChanged
        Me.AddProp = CheckBoxAddProp.Checked
    End Sub

    Private Sub CheckBoxDisableFineThreadWarning_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDisableFineThreadWarning.CheckedChanged
        Me.DisableFineThreadWarning = CheckBoxDisableFineThreadWarning.Checked
    End Sub

    Private Sub CheckBoxCheckNewVersion_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCheckNewVersion.CheckedChanged
        Me.CheckNewVersion = CheckBoxCheckNewVersion.Checked
    End Sub

    Private Sub ButtonDataDirectory_Click(sender As Object, e As EventArgs) Handles ButtonDataDirectory.Click
        Dim tmpFolderDialog As New CommonOpenFileDialog
        tmpFolderDialog.IsFolderPicker = True

        If tmpFolderDialog.ShowDialog() = DialogResult.OK Then
            Me.DataDirectory = tmpFolderDialog.FileName
        End If

    End Sub

    Private Sub CheckBoxAlwaysReadExcel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAlwaysReadExcel.CheckedChanged
        Me.AlwaysReadExcel = CheckBoxAlwaysReadExcel.Checked
    End Sub

    Private Sub CheckBoxAutoPattern_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoPattern.CheckedChanged
        Me.AutoPattern = CheckBoxAutoPattern.Checked
    End Sub
End Class