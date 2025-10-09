Option Strict On

Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class FormTreeSearchOptions

    Private FMain As Form_Main

    Private _LibraryDirectory As String
    Public Property LibraryDirectory As String
        Get
            Return _LibraryDirectory
        End Get
        Set(value As String)
            _LibraryDirectory = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                LabelLibraryDirectory.Text = FMain.TruncateDirectoryName(value, Me.Width)
            End If
        End Set
    End Property

    Private _TemplateDirectory As String
    Public Property TemplateDirectory As String
        Get
            Return _TemplateDirectory
        End Get
        Set(value As String)
            _TemplateDirectory = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                LabelTemplateDirectory.Text = FMain.TruncateDirectoryName(value, Me.Width)
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
                LabelDataDirectory.Text = FMain.TruncateDirectoryName(value, Me.Width)
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
                LabelMaterialLibrary.Text = FMain.TruncateDirectoryName(value, Me.Width)
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

    'Private _AutoPattern As Boolean
    'Public Property AutoPattern As Boolean
    '    Get
    '        Return _AutoPattern
    '    End Get
    '    Set(value As Boolean)
    '        _AutoPattern = value
    '        If Me.TableLayoutPanel1 IsNot Nothing Then
    '            CheckBoxAutoPattern.Checked = value
    '        End If
    '    End Set
    'End Property

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

    Private _ProcessTemplateInBackground As Boolean
    Public Property ProcessTemplateInBackground As Boolean
        Get
            Return _ProcessTemplateInBackground
        End Get
        Set(value As Boolean)
            _ProcessTemplateInBackground = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxProcessTemplateInBackground.Checked = ProcessTemplateInBackground
            End If
        End Set
    End Property

    Private _FailedConstraintSuppress As Boolean
    Public Property FailedConstraintSuppress As Boolean
        Get
            Return _FailedConstraintSuppress
        End Get
        Set(value As Boolean)
            _FailedConstraintSuppress = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxFailedConstraintSuppress.Checked = FailedConstraintSuppress
            End If
        End Set
    End Property

    Private _FailedConstraintAllow As Boolean
    Public Property FailedConstraintAllow As Boolean
        Get
            Return _FailedConstraintAllow
        End Get
        Set(value As Boolean)
            _FailedConstraintAllow = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxFailedConstraintAllow.Checked = FailedConstraintAllow
            End If
        End Set
    End Property

    Private _SuspendMRU As Boolean
    Public Property SuspendMRU As Boolean
        Get
            Return _SuspendMRU
        End Get
        Set(value As Boolean)
            _SuspendMRU = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxSuspendMRU.Checked = SuspendMRU
            End If
        End Set
    End Property

    'Private _AllowCommaDelimiters As Boolean
    'Public Property AllowCommaDelimiters As Boolean
    '    Get
    '        Return _AllowCommaDelimiters
    '    End Get
    '    Set(value As Boolean)
    '        _AllowCommaDelimiters = value
    '        If Me.TableLayoutPanel1 IsNot Nothing Then
    '            CheckBoxAllowCommaDelimiters.Checked = AllowCommaDelimiters
    '        End If
    '    End Set
    'End Property

    'Private _AlwaysOnTop As Boolean
    'Public Property AlwaysOnTop As Boolean
    '    Get
    '        Return _AlwaysOnTop
    '    End Get
    '    Set(value As Boolean)
    '        _AlwaysOnTop = value
    '        If Me.TableLayoutPanel1 IsNot Nothing Then
    '            CheckBoxAlwaysOnTop.Checked = value
    '        End If
    '    End Set
    'End Property

    Private _IncludeDrawing As Boolean
    Public Property IncludeDrawing As Boolean
        Get
            Return _IncludeDrawing
        End Get
        Set(value As Boolean)
            _IncludeDrawing = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                CheckBoxIncludeDrawing.Checked = value
            End If
        End Set
    End Property

    Private _AlwaysOnTopRefreshTime As String
    Public Property AlwaysOnTopRefreshTime As String
        Get
            Return _AlwaysOnTopRefreshTime
        End Get
        Set(value As String)
            _AlwaysOnTopRefreshTime = value
            If Me.TextBoxAlwaysOnTopRefreshTime IsNot Nothing Then
                If Not TextBoxAlwaysOnTopRefreshTime.Text = _AlwaysOnTopRefreshTime Then
                    TextBoxAlwaysOnTopRefreshTime.Text = _AlwaysOnTopRefreshTime
                End If
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

    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not FMain.LibraryDirectory = "" Then
            Me.LibraryDirectory = Me.FMain.LibraryDirectory
        Else
            Me.LibraryDirectory = "Select a directory to store your standard parts"
        End If

        If Not FMain.TemplateDirectory = "" Then
            Me.TemplateDirectory = Me.FMain.TemplateDirectory
        Else
            Me.TemplateDirectory = "Select a directory with your standard part templates"
        End If

        If Not FMain.DataDirectory = "" Then
            Me.DataDirectory = Me.FMain.DataDirectory
        Else
            Me.DataDirectory = "Select a directory with your data files"
        End If

        If Not FMain.MaterialTable = "" Then
            Me.MaterialTable = Me.FMain.MaterialTable
        Else
            Me.MaterialTable = "Select a material table"
        End If


        Me.AlwaysReadExcel = FMain.AlwaysReadExcel
        'Me.AutoPattern = FMain.AutoPattern
        Me.AddProp = FMain.AddProp
        Me.DisableFineThreadWarning = FMain.DisableFineThreadWarning
        Me.ProcessTemplateInBackground = FMain.ProcessTemplateInBackground
        Me.FailedConstraintSuppress = FMain.FailedConstraintSuppress
        Me.FailedConstraintAllow = FMain.FailedConstraintAllow
        Me.SuspendMRU = FMain.SuspendMRU
        'Me.AllowCommaDelimiters = FMain.AllowCommaDelimiters
        'Me.AlwaysOnTop = FMain.AlwaysOnTop
        Me.IncludeDrawing = FMain.IncludeDrawing
        Me.AlwaysOnTopRefreshTime = FMain.AlwaysOnTopRefreshTime
        Me.CheckNewVersion = FMain.CheckNewVersion

    End Sub
    Private Sub ButtonLibraryDirectory_Click(sender As Object, e As EventArgs) Handles ButtonLibraryDirectory.Click
        Dim tmpFolderDialog As New CommonOpenFileDialog
        tmpFolderDialog.IsFolderPicker = True

        If tmpFolderDialog.ShowDialog() = DialogResult.OK Then
            Me.LibraryDirectory = tmpFolderDialog.FileName
        End If

    End Sub

    Private Sub ButtonTemplateDirectory_Click(sender As Object, e As EventArgs) Handles ButtonTemplateDirectory.Click
        Dim tmpFolderDialog As New CommonOpenFileDialog
        tmpFolderDialog.IsFolderPicker = True

        If tmpFolderDialog.ShowDialog() = DialogResult.OK Then
            Me.TemplateDirectory = tmpFolderDialog.FileName
        End If

    End Sub

    Private Sub ButtonDataDirectory_Click(sender As Object, e As EventArgs) Handles ButtonDataDirectory.Click
        Dim tmpFolderDialog As New CommonOpenFileDialog
        tmpFolderDialog.IsFolderPicker = True

        If tmpFolderDialog.ShowDialog() = DialogResult.OK Then
            Me.DataDirectory = tmpFolderDialog.FileName
        End If

    End Sub

    Private Sub ButtonMaterialLibrary_Click(sender As Object, e As EventArgs) Handles ButtonMaterialLibrary.Click
        Dim tmpFileDialog As New OpenFileDialog
        tmpFileDialog.Title = "Select a material library"
        tmpFileDialog.Filter = "Material Library files|*.mtl"

        If tmpFileDialog.ShowDialog() = DialogResult.OK Then
            Me.MaterialTable = tmpFileDialog.FileName
        End If

    End Sub



    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If Me.TemplateDirectory(Me.TemplateDirectory.Count - 1) = "\" Then
            Me.TemplateDirectory = Me.TemplateDirectory.Substring(0, Me.TemplateDirectory.Count - 1)
        End If

        Me.FMain.LibraryDirectory = Me.LibraryDirectory
        Me.FMain.TemplateDirectory = Me.TemplateDirectory
        Me.FMain.DataDirectory = Me.DataDirectory
        FMain.MaterialTable = Me.MaterialTable

        FMain.AlwaysReadExcel = Me.AlwaysReadExcel
        'FMain.AutoPattern = Me.AutoPattern
        FMain.AddProp = Me.AddProp
        FMain.DisableFineThreadWarning = Me.DisableFineThreadWarning
        FMain.ProcessTemplateInBackground = Me.ProcessTemplateInBackground
        FMain.FailedConstraintSuppress = Me.FailedConstraintSuppress
        FMain.FailedConstraintAllow = Me.FailedConstraintAllow
        FMain.SuspendMRU = Me.SuspendMRU
        'FMain.AllowCommaDelimiters = Me.AllowCommaDelimiters
        'FMain.AlwaysOnTop = Me.AlwaysOnTop
        FMain.IncludeDrawing = Me.IncludeDrawing
        FMain.AlwaysOnTopRefreshTime = Me.AlwaysOnTopRefreshTime
        FMain.CheckNewVersion = Me.CheckNewVersion

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub CheckBoxAddProp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAddProp.CheckedChanged
        Me.AddProp = CheckBoxAddProp.Checked
    End Sub

    Private Sub CheckBoxDisableFineThreadWarning_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDisableFineThreadWarning.CheckedChanged
        Me.DisableFineThreadWarning = CheckBoxDisableFineThreadWarning.Checked
    End Sub

    Private Sub CheckBoxCheckNewVersion_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCheckNewVersion.CheckedChanged
        Me.CheckNewVersion = CheckBoxCheckNewVersion.Checked
    End Sub

    Private Sub CheckBoxAlwaysReadExcel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAlwaysReadExcel.CheckedChanged
        Me.AlwaysReadExcel = CheckBoxAlwaysReadExcel.Checked
    End Sub

    Private Sub CheckBoxAutoPattern_CheckedChanged(sender As Object, e As EventArgs)
        'Me.AutoPattern = CheckBoxAutoPattern.Checked
    End Sub

    Private Sub ButtonHelp_Click(sender As Object, e As EventArgs) Handles ButtonHelp.Click
        Dim Info = New ProcessStartInfo()
        Info.FileName = "https://github.com/rmcanany/SolidEdgeStorekeeper#tree-search"
        Info.UseShellExecute = True
        System.Diagnostics.Process.Start(Info)

    End Sub

    Private Sub CheckBoxProcessTemplateInBackground_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProcessTemplateInBackground.CheckedChanged
        Me.ProcessTemplateInBackground = CheckBoxProcessTemplateInBackground.Checked
    End Sub

    Private Sub CheckBoxFailedConstraintSuppress_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFailedConstraintSuppress.CheckedChanged
        Me.FailedConstraintSuppress = CheckBoxFailedConstraintSuppress.Checked
        Me.FailedConstraintAllow = Not Me.FailedConstraintSuppress
    End Sub

    Private Sub CheckBoxFailedConstraintAllow_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFailedConstraintAllow.CheckedChanged
        Me.FailedConstraintAllow = CheckBoxFailedConstraintAllow.Checked
        Me.FailedConstraintSuppress = Not Me.FailedConstraintAllow
    End Sub

    Private Sub CheckBoxSuspendMRU_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSuspendMRU.CheckedChanged
        Me.SuspendMRU = CheckBoxSuspendMRU.Checked
    End Sub

    'Private Sub CheckBoxAllowCommaDelimiters_CheckedChanged(sender As Object, e As EventArgs)
    '    AllowCommaDelimiters = CheckBoxAllowCommaDelimiters.Checked
    'End Sub

    Private Sub CheckBoxAlwaysOnTop_CheckedChanged(sender As Object, e As EventArgs)
        'Me.AlwaysOnTop = CheckBoxAlwaysOnTop.Checked
    End Sub

    Private Sub CheckBoxIncludeDrawing_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeDrawing.CheckedChanged
        Me.IncludeDrawing = CheckBoxIncludeDrawing.Checked
    End Sub

    Private Sub TextBoxAlwaysOnTopRefreshTime_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAlwaysOnTopRefreshTime.TextChanged
        Me.AlwaysOnTopRefreshTime = TextBoxAlwaysOnTopRefreshTime.Text
    End Sub
End Class