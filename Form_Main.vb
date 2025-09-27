Option Strict On

Imports System.Text.RegularExpressions
Imports System.Xml
Imports Microsoft.WindowsAPICodePack.Dialogs
'Imports SolidEdgeConstants

Public Class Form_Main

    Private Property Version As String = "2025.4"

    'Private Property PreviewVersion As String = ""  ' Empty string if not a preview
    Private Property PreviewVersion As String = "Preview 06"


    Private _SelectedNodeFullPath As String
    Public Property SelectedNodeFullPath As String
        Get
            Return _SelectedNodeFullPath
        End Get
        Set(value As String)
            _SelectedNodeFullPath = value
            If Me.XmlDoc IsNot Nothing Then
                UpdatePropertyTab()

                ' Deal with possible multiple entries in MaterialFormula

                '%{MaterialFormula}:STEEL
                '%{MaterialFormula}:STAINLESS, NYLON, TITANIUM, Wood\, Walnut

                Dim MaterialFormulas As List(Of Prop) = Props.GetPropsOfType("SEPropertyFormulaMaterial")

                If MaterialFormulas.Count > 0 Then

                    ' Use the lowest material formula in the tree
                    Dim LastIdx As Integer = MaterialFormulas.Count - 1
                    Dim MaterialName = MaterialFormulas(LastIdx).Value  ' Can be a single value or comma delimited list

                    ' Temporarily replace escaped commas for splitting
                    MaterialName = MaterialName.Replace("\,", "LITERALCOMMA")
                    Dim tmpMaterialsList As List(Of String) = MaterialName.Split(CChar(",")).ToList

                    ' Restore escaped commas and trim whitespace
                    For i = 0 To tmpMaterialsList.Count - 1
                        tmpMaterialsList(i) = tmpMaterialsList(i).Replace("LITERALCOMMA", ",").Trim
                    Next

                    Me.MaterialsList = tmpMaterialsList

                    If Me.ActiveMaterial = "" Then
                        If Me.MaterialsList.Count = 0 Then
                            ' No materials defined.  No action needed.
                        ElseIf Me.MaterialsList.Count = 1 Then
                            ' Only one material found.  Use it.
                            Me.ActiveMaterial = Me.MaterialsList(0)
                        Else
                            ' Prompt
                            'MsgBox("Select a material", vbOKOnly, "Select a Material")

                        End If
                    End If

                End If

                'MaterialFormulas(LastIdx).Value = MaterialName

            End If
        End Set
    End Property

    Public Property LibraryDirectory As String
    Public Property TemplateDirectory As String
    Public Property DataDirectory As String
    Public Property MaterialTable As String
    Public Property AlwaysReadExcel As Boolean
    Public Property AutoPattern As Boolean
    Public Property AddProp As Boolean
    Public Property DisableFineThreadWarning As Boolean
    Public Property CheckNewVersion As Boolean
    Public Property PropertiesToSearchList As List(Of String)
    Public Property PropertiesData As HCPropertiesData
    Public Property PropertiesCache As HCPropertiesCache
    Public Property AssemblyTemplate As String
    Public Property PartTemplate As String
    Public Property SheetmetalTemplate As String
    Private Property AlwaysOnTopTimer As Timer

    Private _AlwaysOnTop As Boolean
    Public Property AlwaysOnTop As Boolean
        Get
            Return _AlwaysOnTop
        End Get
        Set(value As Boolean)
            _AlwaysOnTop = value
            If Me.TabControl1 IsNot Nothing Then

                If AlwaysOnTop Then
                    If AlwaysOnTopTimer IsNot Nothing Then AlwaysOnTopTimer.Start()
                Else
                    If AlwaysOnTopTimer IsNot Nothing Then AlwaysOnTopTimer.Stop()
                End If
            End If
        End Set
    End Property

    Private _SaveInLibrary As Boolean
    Public Property SaveInLibrary As Boolean
        Get
            Return _SaveInLibrary
        End Get
        Set(value As Boolean)
            _SaveInLibrary = value
            If Me.TabControl1 IsNot Nothing Then
                If SaveInLibrary Then ComboBoxSaveIn.Text = "Library"
            End If
        End Set
    End Property

    Private _SaveInAssemblyDirectory As Boolean
    Public Property SaveInAssemblyDirectory As Boolean
        Get
            Return _SaveInAssemblyDirectory
        End Get
        Set(value As Boolean)
            _SaveInAssemblyDirectory = value
            If Me.TabControl1 IsNot Nothing Then
                If SaveInAssemblyDirectory Then ComboBoxSaveIn.Text = "Assy Dir"
            End If
        End Set
    End Property

    Private _SaveInOther As Boolean
    Public Property SaveInOther As Boolean
        Get
            Return _SaveInOther
        End Get
        Set(value As Boolean)
            _SaveInOther = value
            If Me.TabControl1 IsNot Nothing Then
                If SaveInOther Then ComboBoxSaveIn.Text = "Other"
            End If
        End Set
    End Property

    Public Property AssemblyDirectory As String

    'Private _PrePopulate As Boolean
    'Public Property PrePopulate As Boolean
    '    Get
    '        Return _PrePopulate
    '    End Get
    '    Set(value As Boolean)
    '        _PrePopulate = value
    '        If Me.TabControl1 IsNot Nothing Then

    '            ButtonPrepopulate.Checked = PrePopulate
    '            ButtonAddToLibrary.Visible = PrePopulate
    '            LabelAddToLibrary.Visible = PrePopulate

    '            If PrePopulate Then
    '                Me.Cursor = Cursors.WaitCursor
    '                TreeView1.CheckBoxes = True
    '                ButtonPrepopulate.Image = My.Resources.icons8_Checkbox_Checked
    '                LabelPrePopulate.BackColor = System.Drawing.Color.Orange
    '                Me.Cursor = Cursors.Default
    '            Else
    '                ButtonPrepopulate.Image = My.Resources.icons8_Checkbox_Unchecked
    '                LabelPrePopulate.BackColor = System.Drawing.Color.Transparent
    '                TreeView1.CheckBoxes = False
    '                TreeView1.CollapseAll()
    '                TreeView1.Nodes(0).Expand()
    '            End If
    '        End If
    '    End Set
    'End Property

    Public Property FileLogger As Logger
    Public Property ProcessTemplateInBackground As Boolean = True
    Public Property FailedConstraintSuppress As Boolean
    Public Property FailedConstraintAllow As Boolean = True
    Public Property SuspendMRU As Boolean = False
    'Public Property AllowCommaDelimiters As Boolean = False
    Public Property XmlCommaIndicator As String = "...."
    Public Property CacheProperties As Boolean
    Public Property XmlDoc As System.Xml.XmlDocument
    Public Property AddToLibraryOnly As Boolean
    Public Property SEApp As SolidEdgeFramework.Application
    Public Property AsmDoc As SolidEdgeAssembly.AssemblyDocument
    Public Property IncludeDrawing As Boolean

    Private _MaterialsList As List(Of String)
    Public Property MaterialsList As List(Of String)
        Get
            Return _MaterialsList
        End Get
        Set(value As List(Of String))
            _MaterialsList = value
            If Me.ComboBoxMaterials IsNot Nothing Then
                ComboBoxMaterials.Items.Clear()
                ComboBoxMaterials.Items.Add("")
                For Each s As String In _MaterialsList
                    ComboBoxMaterials.Items.Add(s)
                Next
                If _MaterialsList.Contains(Me.ActiveMaterial) Then
                    ComboBoxMaterials.Text = Me.ActiveMaterial
                Else
                    Me.ActiveMaterial = ""  ' Should take care of the combobox automatically
                End If
            End If
        End Set
    End Property

    Private _ActiveMaterial As String
    Public Property ActiveMaterial As String
        Get
            Return _ActiveMaterial
        End Get
        Set(value As String)
            _ActiveMaterial = value
            If Me.ComboBoxMaterials IsNot Nothing Then
                If Not ComboBoxMaterials.Text = _ActiveMaterial Then ComboBoxMaterials.Text = _ActiveMaterial
            End If
        End Set
    End Property


    Private Property Props As Props
    Private Property TemplateDoc As SolidEdgeFramework.SolidEdgeDocument
    Public Property AssemblyPasteComplete As Boolean
    Private Property NodeCount As Integer
    Private Property ErrorLogger As HCErrorLogger


    ' https://community.sw.siemens.com/s/question/0D5Vb00000Krsy5KAB/handling-events-how-to-use-help-example
    ' https://github.com/SolidEdgeCommunity/Samples/blob/master/General/EventHandling/vb/EventHandling/MainForm.vb
    Public SEAppEvents As SolidEdgeFramework.DISEApplicationEvents_Event

    Private Sub Startup()

        Dim Splash As New FormSplash()
        Splash.Show()
        Splash.UpdateStatus("Initializing")

        OleMessageFilter.Register()

        TextBoxStatus.Text = ""

        'AddHandler TreeView1.AfterSelect, AddressOf TreeView1_AfterSelect
        AddHandler TreeView1.NodeMouseClick, AddressOf TreeView1_NodeMouseClick

        Me.Props = New Props

        Dim UP As New UtilsPreferences

        Dim tmpStartupDirectory As String = UP.GetStartupDirectory
        Dim s As String = ""
        Dim Suffix As String = "SE2024"
        Dim tmpDirList As New List(Of String) From {UP.GetDefaultDataDirectory(Suffix), UP.GetDefaultTemplatesDirectory(Suffix)}
        For Each d As String In tmpDirList
            If Not IO.Directory.Exists(d) Then s = $"{s}  {d}{vbCrLf}"
        Next
        If Not s = "" Then
            s = $"Cannot continue without the following directories{vbCrLf}{s}{vbCrLf}{vbCrLf}"
            s = $"{s}If you cloned the program from the repo, "
            s = $"{s}please see the Installation section of the Readme "
            s = $"{s}to learn how to get the missing files. "
            MsgBox(s, vbOKOnly, "File not found")
            End
        End If

        Dim tmpPreferencesDirectory As String = UP.GetPreferencesDirectory
        If Not IO.Directory.Exists(tmpPreferencesDirectory) Then
            ' First run.  Set defaults.
            Me.AlwaysReadExcel = True
            Me.AutoPattern = True
            Me.AddProp = False
            Me.DisableFineThreadWarning = False
            Me.CheckNewVersion = True
            Me.AlwaysOnTop = False
            Me.SaveInLibrary = True
            Me.ProcessTemplateInBackground = False
            Me.FailedConstraintSuppress = False
            Me.FailedConstraintAllow = True
            Me.SuspendMRU = False
            Me.CacheProperties = False
            Me.IncludeDrawing = False
            Me.ActiveMaterial = ""
        End If

        UP.CreatePreferencesDirectory(Me)
        UP.GetFormMainSettings(Me)
        UP.CreateFilenameCharmap()

        LoadXml(Splash)

        If Me.MaterialsList Is Nothing Then
            Me.MaterialsList = New List(Of String)
        End If
        If Me.PropertiesToSearchList Is Nothing Then
            Me.PropertiesToSearchList = New List(Of String)
        End If

        Dim ColIdx As Integer
        DataGridViewVendorParts.Columns.Clear()
        ColIdx = DataGridViewVendorParts.Columns.Add("Filename", "Filename")
        DataGridViewVendorParts.Columns(ColIdx).Width = 150
        ColIdx = DataGridViewVendorParts.Columns.Add("Path", "Path")
        DataGridViewVendorParts.Columns(ColIdx).Width = 50
        For i = 0 To PropertiesToSearchList.Count - 1
            Dim PropString As String = PropertiesToSearchList(i)
            ColIdx = DataGridViewVendorParts.Columns.Add($"Prop_{i + 1}", PropString)
            DataGridViewVendorParts.Columns(ColIdx).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        Me.PropertiesData = New HCPropertiesData  ' Automatically loads saved settings if any.

        'Me.PropertiesCache = New HCPropertiesCache(Me)   ' Automatically loads saved settings if any.

        Splash.UpdateStatus("Checking version")

        UP.CheckVersionFormat(Me.Version)

        ' Form title
        If Me.PreviewVersion = "" Then
            Me.Text = $"Solid Edge Storekeeper {Me.Version}"
        Else
            Me.Text = $"Solid Edge Storekeeper {Me.Version} {Me.PreviewVersion}"
        End If

        If Me.CheckNewVersion Then
            UP.CheckForNewerVersion(Me.Version)
        End If

        TextBoxStatus.Text = $"{Me.NodeCount} items available"

        Splash.UpdateStatus("Initializing timer")

        AlwaysOnTopTimer = New Timer
        AlwaysOnTopTimer.Interval = 3000
        AddHandler AlwaysOnTopTimer.Tick, AddressOf HandleAlwaysOnTopTimerTick
        'AlwaysOnTopTimer.Start()

        Splash.Close()

        If Not IO.File.Exists(Me.MaterialTable) Then
            MsgBox($"Specify a material table before continuing.{vbCrLf}It is set on the Tree Search Options page.", vbOKOnly, "Specify a Material Table")
        End If

    End Sub


    ' ###### PROCESS SELECTED ITEM ######

    Private Function CheckStartConditions(
        PropertySearchFilename As String,
        ErrorLogger As Logger
        ) As Boolean

        Dim Success As Boolean = True
        Dim IsTreeSearch = PropertySearchFilename Is Nothing

        If Not IO.Directory.Exists(Me.LibraryDirectory) Then
            Success = False
            ErrorLogger.AddMessage($"Library directory not found '{Me.LibraryDirectory}'")
        End If

        If IsTreeSearch Then
            If Not IO.Directory.Exists(Me.TemplateDirectory) Then
                Success = False
                ErrorLogger.AddMessage($"Template directory not found '{Me.TemplateDirectory}'")
            End If
            If Not IO.Directory.Exists(Me.DataDirectory) Then
                Success = False
                ErrorLogger.AddMessage($"Data directory not found '{Me.DataDirectory}'")
            End If
            If Not IO.File.Exists(Me.MaterialTable) Then
                Success = False
                ErrorLogger.AddMessage($"Material table not found '{Me.MaterialTable}'")
            End If
            If Me.ActiveMaterial = "" And Me.MaterialsList.Count > 0 Then
                Success = False
                ErrorLogger.AddMessage($"Select a material")
            End If

        Else
            If PropertiesToSearchList.Count = 0 Then
                Success = False
                ErrorLogger.AddMessage("Enter at least one property to search on the options page")
            End If
            If Not IO.File.Exists(Me.AssemblyTemplate) Then
                Success = False
                ErrorLogger.AddMessage($"Assembly template not found '{Me.AssemblyTemplate}'")
            End If
            If Not IO.File.Exists(Me.PartTemplate) Then
                Success = False
                ErrorLogger.AddMessage($"Part template not found '{Me.PartTemplate}'")
            End If
            If Not IO.File.Exists(Me.SheetmetalTemplate) Then
                Success = False
                ErrorLogger.AddMessage($"Sheetmetal template not found '{Me.SheetmetalTemplate}'")
            End If
        End If

        Try
            SEApp = CType(MarshalHelper.GetActiveObject("SolidEdge.Application", throwOnError:=True), SolidEdgeFramework.Application)
        Catch ex As Exception
            Success = False
            ErrorLogger.AddMessage("Solid Edge not detected.  This command requires a running instance of Solid Edge with an assembly file active")
        End Try

        'If SEApp IsNot Nothing And Not Me.PrePopulate Then
        '    Try
        '        AsmDoc = CType(SEApp.ActiveDocument, SolidEdgeAssembly.AssemblyDocument)
        '    Catch ex As Exception
        '        Success = False
        '        ErrorLogger.AddMessage("No assembly file active.  This command requires a running instance of Solid Edge with an assembly file active")
        '    End Try
        'End If

        If SEApp IsNot Nothing Then
            Try
                AsmDoc = CType(SEApp.ActiveDocument, SolidEdgeAssembly.AssemblyDocument)
            Catch ex As Exception
                Success = False
                ErrorLogger.AddMessage("No assembly file active.  This command requires a running instance of Solid Edge with an assembly file active")
            End Try
        End If

        'If Not Me.PrePopulate Then
        '    If SEApp IsNot Nothing And AsmDoc IsNot Nothing AndAlso AsmDoc.Path = "" Then
        '        Success = False
        '        ErrorLogger.AddMessage("Assembly must be saved before adding parts")
        '    End If
        'End If

        If SEApp IsNot Nothing And AsmDoc IsNot Nothing AndAlso AsmDoc.Path = "" Then
            Success = False
            ErrorLogger.AddMessage("Assembly must be saved before adding parts")
        End If

        If SEApp IsNot Nothing Then
            Dim MaterialTableFolder As String
            Dim MaterialTableFolderObject As Object = Nothing

            Dim MTFConstant As SolidEdgeFramework.ApplicationGlobalConstants
            MTFConstant = SolidEdgeFramework.ApplicationGlobalConstants.seApplicationGlobalMatTableFolder

            SEApp.GetGlobalParameter(MTFConstant, MaterialTableFolderObject)
            Try
                MaterialTableFolder = CStr(MaterialTableFolderObject)
                If Not Me.MaterialTable.Contains(MaterialTableFolder) Then
                    Success = False
                    ErrorLogger.AddMessage($"Material table not in required folder: '{MaterialTableFolder}'")
                End If
            Catch ex As Exception

            End Try
        End If

        Return Success
    End Function

    Public Function Process(
        Optional PropertySearchFilename As String = Nothing,
        Optional Replace As Boolean = False,
        Optional ReplaceAll As Boolean = False,
        Optional ErrorLogger As Logger = Nothing
        ) As Boolean

        Dim Proceed As Boolean = True

        If ErrorLogger Is Nothing Then ErrorLogger = Me.FileLogger

        Dim UC As New UtilsCommon

        If Not CheckStartConditions(PropertySearchFilename, ErrorLogger) Then
            TextBoxStatus.Text = ""
            Return False
        End If

        'OleMessageFilter.Register()

        SEAppEvents = CType(SEApp.ApplicationEvents, SolidEdgeFramework.DISEApplicationEvents_Event)

        Dim Filename As String = Nothing
        If PropertySearchFilename Is Nothing Then
            TextBoxStatus.Text = "Getting filename"
            Dim SubLogger As Logger = ErrorLogger.AddLogger("Get filename")
            Filename = GetFilenameFormula(DefaultExtension:=IO.Path.GetExtension(GetTemplateNameFormula()), SubLogger)
            If Filename Is Nothing Then
                TextBoxStatus.Text = ""
                Proceed = False
            End If
        Else
            Filename = PropertySearchFilename
        End If

        If Proceed And Not IO.File.Exists(Filename) Then

            If Me.SuspendMRU Then
                ' API in SE2020 and earlier does not have SuspendMRU
                Try
                    SEApp.SuspendMRU()
                Catch ex As Exception
                End Try
            End If

            TextBoxStatus.Text = "Getting template name"
            Dim TemplateName As String = GetTemplateNameFormula()
            If TemplateName Is Nothing Then
                TextBoxStatus.Text = ""
                Proceed = False
                ErrorLogger.AddMessage("Unable to get template name")
            End If

            TextBoxStatus.Text = $"Opening '{IO.Path.GetFileName(TemplateName)}'"
            Dim SEDoc As SolidEdgeFramework.SolidEdgeDocument = Nothing

            If Proceed Then
                If Me.ProcessTemplateInBackground Then
                    SEDoc = CType(SEApp.Documents.Open(TemplateName, 8), SolidEdgeFramework.SolidEdgeDocument)
                Else
                    SEDoc = CType(SEApp.Documents.Open(TemplateName), SolidEdgeFramework.SolidEdgeDocument)
                End If
                SEApp.DoIdle()

                TextBoxStatus.Text = $"Saving '{IO.Path.GetFileName(Filename)}'"
                Dim Dir As String = IO.Path.GetDirectoryName(Filename)
                If Not IO.Directory.Exists(Dir) Then
                    IO.Directory.CreateDirectory(Dir)
                End If
                SEDoc.SaveAs(Filename)
                SEApp.DoIdle()

                ' Copy template drawing if present
                If Me.IncludeDrawing Then
                    Dim SubLogger As Logger = ErrorLogger.AddLogger("Copy template drawing")
                    CopyTemplateDrawing(SEApp, SEDoc, TemplateName, SubLogger)
                End If
            End If

            TextBoxStatus.Text = "Processing variables"
            If Proceed Then
                Dim SubLogger As Logger = ErrorLogger.AddLogger("Process variables")
                Proceed = ProcessVariables(SEApp, SEDoc, SubLogger)
            End If

            TextBoxStatus.Text = "Processing parameters"
            If Proceed Then
                Dim SubLogger As Logger = ErrorLogger.AddLogger("Process parameters")
                Proceed = ProcessParameters(SEApp, SEDoc, SubLogger)
            End If

            TextBoxStatus.Text = "Processing SE properties"
            If Proceed Then
                Dim SubLogger As Logger = ErrorLogger.AddLogger("Process SE properties")
                Proceed = ProcessSEProperties(SEApp, SEDoc, SubLogger)
            End If

            TextBoxStatus.Text = "Saving file"
            If Proceed Then
                SEDoc.Save()
                SEApp.DoIdle()
                SEDoc.Close()
                SEApp.DoIdle()
            Else
                SEDoc.Close()
                SEApp.DoIdle()
            End If

            If Me.SuspendMRU Then
                Try
                    SEApp.ResumeMRU()
                Catch ex As Exception
                End Try
            End If

        End If

        ' ###### ADD PART TO ASSEMBLY ######

        If Proceed And Not AddToLibraryOnly Then
            AddHandler SEAppEvents.AfterCommandRun, AddressOf DISEApplicationEvents_AfterCommandRun
            SEApp.DoIdle()
            AssemblyPasteComplete = False

            Me.TopMost = False
            System.Windows.Forms.Application.DoEvents()
            SEApp.Activate()
            SEApp.DoIdle()

            If Not Replace Then

                TextBoxStatus.Text = $"Adding '{IO.Path.GetFileName(Filename)}'"

                Dim Occurrences As SolidEdgeAssembly.Occurrences = AsmDoc.Occurrences
                Dim PreviousOccurrencesCount As Integer = Occurrences.Count

                Dim Occurrence = AsmDoc.Occurrences.AddByFilename(Filename)
                Dim SelectSet = AsmDoc.SelectSet
                SelectSet.RemoveAll()

                SelectSet.Add(Occurrence)
                Dim Cut = SolidEdgeConstants.AssemblyCommandConstants.AssemblyEditCut
                SEApp.StartCommand(CType(Cut, SolidEdgeFramework.SolidEdgeCommandConstants))
                Dim Paste = SolidEdgeConstants.AssemblyCommandConstants.AssemblyEditPaste

                Try
                    SEApp.StartCommand(CType(Paste, SolidEdgeFramework.SolidEdgeCommandConstants))

                    ' Wait for Paste command to complete

                    While Not AssemblyPasteComplete
                        Threading.Thread.Sleep(500)
                        'SEApp.DoIdle()
                    End While
                Catch ex As Exception
                    Try
                        SEApp.StartCommand(CType(Paste, SolidEdgeFramework.SolidEdgeCommandConstants))

                        ' Wait for Paste command to complete

                        While Not AssemblyPasteComplete
                            Threading.Thread.Sleep(500)
                            'SEApp.DoIdle()
                        End While
                    Catch ex2 As Exception
                        Proceed = False
                        ErrorLogger.AddMessage("Could not add part.  Please try again.")
                    End Try

                End Try

                RemoveHandler SEAppEvents.AfterCommandRun, AddressOf DISEApplicationEvents_AfterCommandRun

                If Proceed And Me.AutoPattern And Occurrences.Count > PreviousOccurrencesCount Then
                    Occurrence = CType(Occurrences(Occurrences.Count - 1), SolidEdgeAssembly.Occurrence)
                    MaybePatternOccurrence(Occurrence, PiggybackOccurrences:=Nothing)
                End If

            Else

                TextBoxStatus.Text = $"Replacing selected with'{IO.Path.GetFileName(Filename)}'"

                If SEApp.ActiveSelectSet.Count >= 1 Then

                    Dim objOcc As SolidEdgeAssembly.Occurrence = CType(SEApp.ActiveSelectSet.Item(1), SolidEdgeAssembly.Occurrence)
                    Dim objAsm As SolidEdgeAssembly.AssemblyDocument = CType(SEApp.ActiveDocument, SolidEdgeAssembly.AssemblyDocument)

                    If objOcc.Type = SolidEdgeFramework.ObjectType.igPart Or objOcc.Type = SolidEdgeFramework.ObjectType.igSubAssembly Then

                        SEApp.DelayCompute = True

                        If ReplaceAll Then

                            Dim tmpColl As New List(Of SolidEdgeAssembly.Occurrence)

                            For i = 1 To objAsm.Occurrences.Count
                                If objAsm.Occurrences.Item(i).OccurrenceFileName = objOcc.OccurrenceFileName Then tmpColl.Add(objAsm.Occurrences.Item(i))
                            Next

                            Dim tmpOcc = tmpColl.ToArray
                            If Me.FailedConstraintSuppress Then
                                objAsm.ReplaceComponents(CType(tmpOcc, Array), Filename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementSuppress)
                            ElseIf Me.FailedConstraintAllow Then
                                objAsm.ReplaceComponents(CType(tmpOcc, Array), Filename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementNone)
                            Else
                                Proceed = False
                                ErrorLogger.AddMessage("Option not set for treatment of failed constraints.  Set it on the Tree Search Options dialog.")
                            End If

                        Else

                            Dim tmpOcc As System.Array = {objOcc}
                            If Me.FailedConstraintSuppress Then
                                objAsm.ReplaceComponents(tmpOcc, Filename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementSuppress)
                            ElseIf Me.FailedConstraintAllow Then
                                objAsm.ReplaceComponents(tmpOcc, Filename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementNone)
                            Else
                                Proceed = False
                                ErrorLogger.AddMessage("Option not set for treatment of failed constraints.  Set it on the Tree Search Options dialog.")
                            End If

                        End If

                        SEApp.ActiveSelectSet.RefreshDisplay()
                        SEApp.DelayCompute = False

                    End If

                Else

                    Clipboard.Clear()
                    Clipboard.SetText(Filename)
                    SEApp.StartCommand(CType(SolidEdgeConstants.AssemblyCommandConstants.AssemblyEditPaste, SolidEdgeFramework.SolidEdgeCommandConstants))

                End If

                RemoveHandler SEAppEvents.AfterCommandRun, AddressOf DISEApplicationEvents_AfterCommandRun  'just because it is early initialized

            End If

            Me.TopMost = True
            System.Windows.Forms.Application.DoEvents()
            Me.TopMost = False


        End If
        TextBoxStatus.Text = ""

        Return Proceed

    End Function

    Private Function CopyTemplateDrawing(
        SEApp As SolidEdgeFramework.Application,
        SEDoc As SolidEdgeFramework.SolidEdgeDocument,
        ModelTemplateName As String,
        ErrorLogger As Logger
        ) As Boolean

        Dim Success As Boolean = True

        Dim DraftTemplateName As String = IO.Path.ChangeExtension(ModelTemplateName, "dft")
        Dim DraftName As String = IO.Path.ChangeExtension(SEDoc.FullName, "dft")
        Dim DraftDoc As SolidEdgeDraft.DraftDocument

        If Not IO.File.Exists(DraftTemplateName) Then
            Return True
        Else
            If Me.ProcessTemplateInBackground Then
                DraftDoc = CType(SEApp.Documents.Open(DraftTemplateName, 8), SolidEdgeDraft.DraftDocument)
            Else
                DraftDoc = CType(SEApp.Documents.Open(DraftTemplateName), SolidEdgeDraft.DraftDocument)
            End If
            SEApp.DoIdle()

            DraftDoc.SaveAs(DraftName)
            SEApp.DoIdle()

            Dim ModelLinks As SolidEdgeDraft.ModelLinks = DraftDoc.ModelLinks

            If ModelLinks IsNot Nothing Then
                For Each ModelLink As SolidEdgeDraft.ModelLink In ModelLinks
                    Dim tmpFilename As String = Nothing
                    If ModelLink.IsAssemblyFamilyMember Then
                        tmpFilename = ModelLink.FileName.Split("!"c)(0)
                    Else
                        tmpFilename = ModelLink.FileName
                    End If
                    If tmpFilename = ModelTemplateName Then
                        Try
                            ModelLink.ChangeSource(SEDoc.FullName)
                            SEApp.DoIdle()
                        Catch ex As Exception
                            Success = False
                            ErrorLogger.AddMessage("Unable to change drawing link")
                        End Try
                    End If
                Next
            End If

            For Each Sheet As SolidEdgeDraft.Sheet In DraftDoc.Sheets
                If Sheet.SectionType = SolidEdgeDraft.SheetSectionTypeConstants.igWorkingSection Then
                    For Each DrawingView As SolidEdgeDraft.DrawingView In Sheet.DrawingViews
                        Try
                            DrawingView.Update()
                            SEApp.DoIdle()
                        Catch ex As Exception
                            Success = False
                            ErrorLogger.AddMessage("Unable to update drawing view")
                        End Try
                    Next
                End If
            Next

            DraftDoc.Save()
            SEApp.DoIdle()
            DraftDoc.Close()
            SEApp.DoIdle()
        End If

        Return Success
    End Function
    Private Function ProcessVariables(
        SEApp As SolidEdgeFramework.Application,
        SEDoc As SolidEdgeFramework.SolidEdgeDocument,
        ErrorLogger As Logger
        ) As Boolean

        Dim Success As Boolean = True

        Dim UC As New UtilsCommon

        Dim VariableProps As List(Of Prop) = Props.GetPropsOfType("Variable")
        Dim VariableDict As Dictionary(Of String, SolidEdgeFramework.variable) = UC.GetDocVariables(SEDoc)

        SEApp.DelayCompute = True

        For Each Prop As Prop In VariableProps
            If VariableDict.Keys.Contains(Prop.Name) Then
                Try
                    VariableDict(Prop.Name).Formula = Prop.Value
                    'VariableDict(Prop.Name).Formula = Prop.Value.Replace(".", ",")
                Catch ex As Exception
                    ErrorLogger.AddMessage($"Cannot process value for '{Prop.Name}': '{Prop.Value}'")
                End Try
            Else
                ErrorLogger.AddMessage($"Variable not found: '{Prop.Name}'")
            End If
        Next

        SEApp.DelayCompute = False
        SEApp.DoIdle()

        If Not Me.ProcessTemplateInBackground And Success Then
            Select Case UC.GetDocType(SEDoc)
                Case "asm"
                    SEApp.StartCommand(CType(SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewFit, SolidEdgeFramework.SolidEdgeCommandConstants))
                    '##### Why viewfit ??? F.Arfilli
                Case "par", "psm"
                    SEApp.StartCommand(CType(SolidEdgeConstants.PartCommandConstants.PartViewFit, SolidEdgeFramework.SolidEdgeCommandConstants))
            End Select
        End If

        Return Success
    End Function

    Private Function ProcessParameters(
        SEApp As SolidEdgeFramework.Application,
        SEDoc As SolidEdgeFramework.SolidEdgeDocument,
        ErrorLogger As Logger
        ) As Boolean

        Dim Success As Boolean = True
        Dim UC As New UtilsCommon

        Dim ParameterStrings As List(Of Prop) = Props.GetPropsOfType("ParameterString")
        If ParameterStrings.Count = 0 Then Return True
        Dim Prop = ParameterStrings(0)
        Dim ThreadDescription = Prop.Value

        'Dim UnitsFormulas As List(Of Prop) = Props.GetPropsOfType("UnitsOfMeasure")
        'If UnitsFormulas.Count = 0 Then Return False
        'Dim UnitOfMeasure As String = UnitsFormulas(0).Value

        Dim Models As SolidEdgePart.Models = Nothing
        Dim Model As SolidEdgePart.Model
        Dim HoleData As SolidEdgePart.HoleData = Nothing

        Select Case UC.GetDocType(SEDoc)
            Case "par"
                Dim tmpSEDoc As SolidEdgePart.PartDocument = CType(SEDoc, SolidEdgePart.PartDocument)
                Models = tmpSEDoc.Models
            Case "psm"
                Dim tmpSEDoc As SolidEdgePart.SheetMetalDocument = CType(SEDoc, SolidEdgePart.SheetMetalDocument)
                Models = tmpSEDoc.Models
        End Select

        Model = CType(Models(0), SolidEdgePart.Model)

        If Model.Threads Is Nothing And Model.Holes Is Nothing Then
            Return True
        End If

        Dim ExternalThreads As SolidEdgePart.Threads = Model.Threads
        Dim ThreadedHoles As List(Of SolidEdgePart.Hole) = Nothing

        If Model.Holes.Count > 0 Then
            For Each Hole As SolidEdgePart.Hole In Model.Holes
                Dim tmpHoleData As SolidEdgePart.HoleData = CType(Hole.HoleData, SolidEdgePart.HoleData)
                Dim SubType As String = tmpHoleData.SubType
                If SubType.ToLower.Contains("Thread") Then
                    ThreadedHoles.Add(Hole)
                End If
            Next
        End If

        Dim HasExternalThreads As Boolean = ExternalThreads.Count > 0
        Dim HasThreadedHoles As Boolean = ThreadedHoles IsNot Nothing AndAlso ThreadedHoles.Count > 0

        If HasExternalThreads And HasThreadedHoles Then
            ErrorLogger.AddMessage("Cannot currently process models with both threaded holes AND external threads")
            Return False
        End If

        If HasExternalThreads Then
            Dim Thread As SolidEdgePart.Thread = CType(ExternalThreads(0), SolidEdgePart.Thread)
            HoleData = CType(Thread.HoleData, SolidEdgePart.HoleData)
        ElseIf HasThreadedHoles Then
            Dim Hole As SolidEdgePart.Hole = ThreadedHoles(0)
            HoleData = CType(Hole.HoleData, SolidEdgePart.HoleData)
        End If

        If HoleData IsNot Nothing Then

            'Select Case UnitOfMeasure.ToLower
            '    Case "inch"
            '        HoleData.Standard = "ANSI Inch"
            '    Case "mm"
            '        HoleData.Standard = "ISO Metric"
            'End Select

            HoleData.ThreadDescription = ThreadDescription
            HoleData.Size = ThreadDescription

            If Not Me.DisableFineThreadWarning And HasExternalThreads And ThreadDescription.ToLower.Contains("unf") Then
                ErrorLogger.AddMessage("Cannot correctly create external fine threads.  See Readme for details.")
            End If
        End If


        Return Success
    End Function

    Private Function ProcessSEProperties(
        SEApp As SolidEdgeFramework.Application,
        SEDoc As SolidEdgeFramework.SolidEdgeDocument,
        ErrorLogger As Logger
        ) As Boolean

        ' DescriptionProperty Type="SEPropertyName"	%{Custom.Description}
        ' HardwareProperty Type="SEPropertyName"	%{System.Hardware}
        ' MaterialProperty Type="SEPropertyName"	%{System.Material}

        ' DescriptionFormula Type="SEPropertyFormulaString"	FHCS %{Description} X %{Length}
        ' HardwareFormula Type="SEPropertyFormulaBoolean"	TRUE
        ' MaterialFormula Type="SEPropertyFormulaMaterial"	STEEL, STAINLESS, BRASS, NYLON

        Dim Success As Boolean = True

        Dim SEPropertyNames As List(Of Prop) = Props.GetPropsOfType("SEPropertyName")

        Dim StringFormulas As List(Of Prop) = Props.GetPropsOfType("SEPropertyFormulaString")
        Dim BooleanFormulas As List(Of Prop) = Props.GetPropsOfType("SEPropertyFormulaBoolean")
        Dim MaterialFormulas As List(Of Prop) = Props.GetPropsOfType("SEPropertyFormulaMaterial")

        Dim UC As New UtilsCommon

        For Each StringFormula As Prop In StringFormulas
            Dim PropName As String = StringFormula.Name.Replace("Formula", "Property") ' DescriptionFormula -> DescriptionPropertyName
            Dim SEPropertyNameProp As Prop = Props.GetProp(PropName) ' .Value = %{Custom.Description}
            If SEPropertyNames.Contains(SEPropertyNameProp) Then
                Dim PropertySetName As String = UC.PropSetFromFormula(SEPropertyNameProp.Value) ' Custom
                Dim PropertyName As String = UC.PropNameFromFormula(SEPropertyNameProp.Value) ' Description
                Dim Value = Props.SubstitutePropFormulas(StringFormula.Value, Me.ActiveMaterial, ErrorLogger) ' shcs_%{Name}_%{Length}.par -> shcs_0.250-20_0.500.par
                If Value Is Nothing Then
                    Success = False
                    ErrorLogger.AddMessage($"Unable to process formula {StringFormula.Value}")
                End If
                UC.SetPropValue(SEDoc, PropertySetName, PropertyName, ModelLinkIdx:=0, AddProp, Value)
            End If
        Next

        For Each BooleanFormula As Prop In BooleanFormulas
            Dim PropName As String = BooleanFormula.Name.Replace("Formula", "Property") ' HardwareFormula -> HardwareProperty
            Dim SEPropertyNameProp As Prop = Props.GetProp(PropName) ' .Value = %{System.Hardware}
            If SEPropertyNames.Contains(SEPropertyNameProp) Then
                Dim PropertySetName As String = UC.PropSetFromFormula(SEPropertyNameProp.Value) ' System
                Dim PropertyName As String = UC.PropNameFromFormula(SEPropertyNameProp.Value) ' Hardware
                Try
                    Dim Value = CBool(BooleanFormula.Value)
                    UC.SetPropValue(SEDoc, PropertySetName, PropertyName, ModelLinkIdx:=0, AddProp, Value)
                Catch ex As Exception
                    Success = False
                    ErrorLogger.AddMessage($"Unable to process formula {BooleanFormula.Value}")
                End Try
            End If
        Next

        If MaterialFormulas IsNot Nothing AndAlso MaterialFormulas.Count > 0 Then
            Dim MaterialFormula As Prop = MaterialFormulas(MaterialFormulas.Count - 1)

            Dim UM As New UtilsMaterials
            Dim SubLogger As Logger = ErrorLogger.AddLogger("Update material")

            Dim PropName As String = MaterialFormula.Name.Replace("Formula", "Property") ' MaterialFormula -> MaterialProperty
            Dim SEPropertyNameProp As Prop = Props.GetProp(PropName) ' .Value = %{System.Material}
            If SEPropertyNames.Contains(SEPropertyNameProp) Then
                Dim PropertySetName As String = UC.PropSetFromFormula(SEPropertyNameProp.Value) ' System
                Dim PropertyName As String = UC.PropNameFromFormula(SEPropertyNameProp.Value) ' Material
                'Dim Value = MaterialFormula.Value ' STEEL
                Dim Value = Me.ActiveMaterial
                If Not Value = "" Then
                    UC.SetPropValue(SEDoc, PropertySetName, PropertyName, ModelLinkIdx:=0, AddProp, Value)
                    UM.UpdateMaterialFromMaterialTable(SEApp, SEDoc, Me.MaterialTable, False, True, False, "", Nothing, False, False, SubLogger)
                Else
                    ErrorLogger.AddMessage("Active material not set")
                End If

            End If
        End If

        Return Success
    End Function


    Public Function GetFilenameFormula(
         DefaultExtension As String,
         ErrorLogger As Logger
         ) As String

        ' Examples
        ' bhcs_%{Name}_%{Length}.par
        ' Fasteners\BHCS\bhcs_%{Name}_%{Length}.par

        Dim Filename As String = Nothing
        Dim FilenameFormula As String = ""

        Dim tmpProps As List(Of Prop) = Props.GetPropsOfType("FilenameFormula")
        If tmpProps.Count = 0 Then
            ErrorLogger.AddMessage("No FilenameFormula specified")
            TextBoxStatus.Text = ""
            Return Nothing
        End If
        If tmpProps.Count > 1 Then
            ErrorLogger.AddMessage("Multiple FilenameFormulas specified")
            TextBoxStatus.Text = ""
            Return Nothing
        End If

        FilenameFormula = tmpProps(0).Value.Trim
        Filename = Props.SubstitutePropFormulas(FilenameFormula, Me.ActiveMaterial, ErrorLogger)

        If Not Me.SaveInLibrary Then
            If Me.AddToLibraryOnly Then
                ErrorLogger.AddMessage("Part can only be saved in the library directory")
                Return Nothing
            Else
                If Filename Is Nothing Then Filename = ""

                Dim tmpFileDialog As New CommonSaveFileDialog

                tmpFileDialog.Title = "Enter the file name for the new part"
                tmpFileDialog.DefaultFileName = Filename
                tmpFileDialog.EnsureFileExists = False
                tmpFileDialog.Filters.Add(New CommonFileDialogFilter("Solid Edge Files", $"*{DefaultExtension}"))
                If Me.SaveInAssemblyDirectory Then
                    If IO.Directory.Exists(Me.AssemblyDirectory) Then
                        tmpFileDialog.InitialDirectory = Me.AssemblyDirectory
                    End If
                End If

                If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
                Me.TopMost = False

                If tmpFileDialog.ShowDialog() = DialogResult.OK Then
                    If Me.AlwaysOnTopTimer IsNot Nothing And Me.AlwaysOnTop Then Me.AlwaysOnTopTimer.Start()
                    Filename = tmpFileDialog.FileName
                    If Me.SaveInAssemblyDirectory Then
                        Me.AssemblyDirectory = IO.Path.GetDirectoryName(Filename)
                    End If
                Else
                    If Me.AlwaysOnTopTimer IsNot Nothing And Me.AlwaysOnTop Then Me.AlwaysOnTopTimer.Start()
                    Return Nothing
                End If

            End If
        Else
            If Filename Is Nothing Then
                ErrorLogger.AddMessage($"Could not resolve filename formula: '{FilenameFormula}'")
                Return Nothing
            End If
            Filename = $"{Me.LibraryDirectory}\{Filename}"
        End If


        Dim UFC As New UtilsFilenameCharmap

        Dim Directory As String = IO.Path.GetDirectoryName(Filename)

        Filename = UFC.SubstituteIllegalCharacters(IO.Path.GetFileName(Filename))

        Filename = $"{Directory}\{Filename}"

        If Not Me.SaveInLibrary Then
            If IO.File.Exists(Filename) Then
                Dim Result = MsgBox($"'{IO.Path.GetFileName(Filename)}' exists.  Do you want to use that one?", vbYesNo, "Existing file")
                If Result = MsgBoxResult.No Then
                    Return Nothing
                End If
            End If
        Else
            ' No need to prompt.  Just use the existing file automatically.
        End If

        Return Filename
    End Function

    Public Function GetTemplateNameFormula(Optional ErrorLogger As Logger = Nothing) As String
        Dim TemplateName As String

        If ErrorLogger Is Nothing Then ErrorLogger = Me.FileLogger

        Dim tmpProps As List(Of Prop) = Props.GetPropsOfType("TemplateFormula")
        If tmpProps.Count = 0 Then
            ErrorLogger.AddMessage("No TemplateFormula specified")
            TextBoxStatus.Text = ""
            Return Nothing
        End If
        If tmpProps.Count > 1 Then
            ErrorLogger.AddMessage("Multiple TemplateFormulas specified")
            TextBoxStatus.Text = ""
            Return Nothing
        End If

        TemplateName = $"{Me.TemplateDirectory}\{tmpProps(0).Value}"

        If Not IO.File.Exists(TemplateName) Then
            ErrorLogger.AddMessage($"Template not found '{TemplateName}'")
            TextBoxStatus.Text = ""
            Return Nothing
        End If

        Return TemplateName
    End Function


    Public Function MaybePatternOccurrence(
        Occurrence As SolidEdgeAssembly.Occurrence,
        PiggybackOccurrences As List(Of SolidEdgeAssembly.Occurrence),
        Optional NameSuffix As String = ""
        ) As Boolean

        Dim Success As Boolean = True

        Dim Occurrence2 As SolidEdgeAssembly.Occurrence = Nothing
        Dim Face2 As SolidEdgeGeometry.Face = Nothing
        Dim Face2ID As Integer
        Dim IsTopologyReference As Boolean
        Dim TargetPattern As SolidEdgePart.Pattern = Nothing
        Dim TargetHole As SolidEdgePart.Hole = Nothing
        Dim TargetUserDefinedPattern As SolidEdgePart.UserDefinedPattern = Nothing

        Dim Relations3d As SolidEdgeAssembly.Relations3d = CType(Occurrence.Relations3d, SolidEdgeAssembly.Relations3d)
        Dim Element2 As SolidEdgeAssembly.TopologyReference = Nothing

        ' Start at the end of Relations3d collection.  After the stack assy dispersal, the last axial relation should be the one we want.
        For i = Relations3d.Count - 1 To 0 Step -1
            Dim AxialRelation3d As SolidEdgeAssembly.AxialRelation3d = TryCast(Relations3d(i), SolidEdgeAssembly.AxialRelation3d)
            If AxialRelation3d IsNot Nothing Then

                Occurrence2 = AxialRelation3d.Occurrence2

                Element2 = TryCast(AxialRelation3d.GetElement2(IsTopologyReference), SolidEdgeAssembly.TopologyReference)

                'Dim ComType = HCComObject.GetCOMObjectType(Element2)
                If Element2 IsNot Nothing Then
                    ' https://community.sw.siemens.com/s/question/0D5Vb00000lBzhzKAC/unique-identifier-for-any-occurences-within-an-assembly
                    ' https://community.sw.siemens.com/s/question/0D54O000061xps4SAA/creating-relations-between-suboccurrences
                    Face2 = TryCast(Element2.Object, SolidEdgeGeometry.Face)
                    If Face2 IsNot Nothing Then
                        Face2ID = Face2.ID
                        Exit For
                    End If
                End If
            End If
        Next

        If Occurrence2 IsNot Nothing And Face2 IsNot Nothing Then
            Success = ProcessPatterns(Occurrence, Occurrence2, Face2ID, PiggybackOccurrences, NameSuffix, Element2)

            If Not Success Then Success = ProcessUserDefinedPatterns(Occurrence, Occurrence2, Face2ID, PiggybackOccurrences, NameSuffix, Element2)
        Else
            Success = False
        End If

        Return Success
    End Function

    Private Function ProcessPatterns(
        Occurrence As SolidEdgeAssembly.Occurrence,
        Occurrence2 As SolidEdgeAssembly.Occurrence,
        Face2ID As Integer,
        PiggybackOccurrences As List(Of SolidEdgeAssembly.Occurrence),
        NameSuffix As String,
        Element2 As SolidEdgeAssembly.TopologyReference
        ) As Boolean

        Dim Success As Boolean = True

        Dim TargetPattern As SolidEdgePart.Pattern = Nothing
        Dim TargetHole As SolidEdgePart.Hole = Nothing
        Dim Models As SolidEdgePart.Models = Nothing

        Dim Occurrence2IsSubassembly As Boolean = False
        Dim Occurrence2Original As SolidEdgeAssembly.SubOccurrence = Nothing

        Dim Extension = IO.Path.GetExtension(Occurrence2.OccurrenceFileName)

        If Extension = ".asm" Then
            Occurrence2IsSubassembly = True

            Occurrence2Original = CType(Element2.Parent, SolidEdgeAssembly.SubOccurrence)

            Occurrence2 = CType(Element2.Parent, SolidEdgeAssembly.SubOccurrence).ThisAsOccurrence

            Extension = IO.Path.GetExtension(Occurrence2.OccurrenceFileName)
        End If

        Select Case Extension
            'Case ".asm"
            '    Return False
            Case ".par"
                Dim tmpOccurrence2Doc As SolidEdgePart.PartDocument = CType(Occurrence2.OccurrenceDocument, SolidEdgePart.PartDocument)
                Models = tmpOccurrence2Doc.Models
            Case ".psm"
                Dim tmpOccurrence2Doc As SolidEdgePart.SheetMetalDocument = CType(Occurrence2.OccurrenceDocument, SolidEdgePart.SheetMetalDocument)
                Models = tmpOccurrence2Doc.Models
        End Select

        For Each Model As SolidEdgePart.Model In Models

            If Model.Patterns IsNot Nothing AndAlso Model.Patterns.Count > 0 Then
                For Each Pattern As SolidEdgePart.Pattern In Model.Patterns

                    ' Check pattern input features for the selected hole face
                    Dim InputFeatures = Array.CreateInstance(GetType(Object), 0)
                    Pattern.GetInputFeatures(InputFeatures)
                    For Each InputFeature As Object In InputFeatures
                        Dim Hole As SolidEdgePart.Hole = TryCast(InputFeature, SolidEdgePart.Hole)
                        If Hole IsNot Nothing Then
                            Dim HoleSideFaces As SolidEdgeGeometry.Faces = CType(Hole.SideFaces, SolidEdgeGeometry.Faces)
                            'Dim ComType = HCComObject.GetCOMObjectType(HoleSideFaces)

                            For Each SideFace As SolidEdgeGeometry.Face In HoleSideFaces
                                If SideFace.ID = Face2ID Then
                                    TargetPattern = Pattern
                                    TargetHole = Hole
                                End If
                                If TargetPattern IsNot Nothing Then Exit For
                            Next
                        End If
                        If TargetPattern IsNot Nothing Then Exit For
                    Next

                    ' Check pattern occurrence features for the selected hole face
                    Dim OccurrenceCount As Integer
                    If Pattern.PatternType = SolidEdgePart.PatternTypeConstants.seSmartPattern Then
                        OccurrenceCount = Pattern.NumberOfOccurrences
                    Else
                        OccurrenceCount = 2
                    End If

                    Dim OccurrenceFeatures = Array.CreateInstance(GetType(Object), 0)
                    For i As Integer = 1 To OccurrenceCount
                        Pattern.GetOccurrence(i, OccurrenceFeatures)
                        For Each Feature As Object In OccurrenceFeatures
                            Dim Hole As SolidEdgePart.Hole = TryCast(Feature, SolidEdgePart.Hole)
                            If Hole IsNot Nothing Then
                                Dim HoleSideFaces As SolidEdgeGeometry.Faces = CType(Hole.SideFaces, SolidEdgeGeometry.Faces)
                                For Each SideFace As SolidEdgeGeometry.Face In HoleSideFaces
                                    If SideFace.ID = Face2ID Then
                                        TargetPattern = Pattern
                                        TargetHole = Hole
                                    End If
                                    If TargetPattern IsNot Nothing Then Exit For
                                Next
                            End If
                            If TargetPattern IsNot Nothing Then Exit For
                        Next
                        If TargetPattern IsNot Nothing Then Exit For
                    Next
                    If TargetPattern IsNot Nothing Then Exit For
                Next

            End If
            If TargetPattern IsNot Nothing Then Exit For
        Next

        If TargetPattern IsNot Nothing And TargetHole IsNot Nothing Then

            ' Get a unique name
            Dim ExistingNames As New List(Of String)
            For Each AssemblyPattern As SolidEdgeAssembly.AssemblyPattern In AsmDoc.AssemblyPatterns
                ExistingNames.Add(AssemblyPattern.Name)
            Next

            Dim Prefix As String = "Pattern_"
            Dim Suffix As Integer = 1
            While ExistingNames.Contains($"{Prefix}{CStr(Suffix)}")
                Suffix += 1
            End While

            ' Create pattern
            Dim SourceOccurrences As New List(Of SolidEdgeAssembly.Occurrence)
            SourceOccurrences.Add(Occurrence)
            If PiggybackOccurrences IsNot Nothing Then SourceOccurrences.AddRange(PiggybackOccurrences)

            Dim RefPattern As Object = Nothing
            Dim RefHole As Object = Nothing

            If Not Occurrence2IsSubassembly Then
                RefPattern = AsmDoc.CreateReference(Occurrence2, TargetPattern)
                RefHole = AsmDoc.CreateReference(Occurrence2, TargetHole)
            Else
                RefPattern = createTopASMRef(Occurrence2Original, TargetPattern)
                RefHole = createTopASMRef(Occurrence2Original, TargetHole)
            End If

            Dim AsmPattern As SolidEdgeAssembly.AssemblyPattern
            If NameSuffix = "" Then
                AsmPattern = AsmDoc.AssemblyPatterns.CreateEx($"{Prefix}{CStr(Suffix)}", SourceOccurrences.ToArray, RefPattern, RefHole)
            Else
                AsmPattern = AsmDoc.AssemblyPatterns.CreateEx($"{Prefix}{CStr(Suffix)}_{NameSuffix}", SourceOccurrences.ToArray, RefPattern, RefHole)
            End If

        Else
            Success = False
        End If


        Return Success
    End Function

    Private Function ProcessUserDefinedPatterns(
        Occurrence As SolidEdgeAssembly.Occurrence,
        Occurrence2 As SolidEdgeAssembly.Occurrence,
        Face2ID As Integer,
        PiggybackOccurrences As List(Of SolidEdgeAssembly.Occurrence),
        NameSuffix As String,
        Element2 As SolidEdgeAssembly.TopologyReference
        ) As Boolean

        Dim Success As Boolean = True

        Dim TargetPattern As SolidEdgePart.UserDefinedPattern = Nothing
        Dim TargetHole As SolidEdgePart.Hole = Nothing
        Dim Models As SolidEdgePart.Models = Nothing

        Dim Occurrence2IsSubassembly As Boolean = False
        Dim Occurrence2Original As SolidEdgeAssembly.SubOccurrence = Nothing

        Dim Extension = IO.Path.GetExtension(Occurrence2.OccurrenceFileName)

        If Extension = ".asm" Then
            Occurrence2IsSubassembly = True

            Occurrence2Original = CType(Element2.Parent, SolidEdgeAssembly.SubOccurrence)

            Occurrence2 = CType(Element2.Parent, SolidEdgeAssembly.SubOccurrence).ThisAsOccurrence

            Extension = IO.Path.GetExtension(Occurrence2.OccurrenceFileName)
        End If

        Select Case Extension
            'Case ".asm"
            Case ".par"
                Dim tmpOccurrence2Doc As SolidEdgePart.PartDocument = CType(Occurrence2.OccurrenceDocument, SolidEdgePart.PartDocument)
                Models = tmpOccurrence2Doc.Models
            Case ".psm"
                Dim tmpOccurrence2Doc As SolidEdgePart.SheetMetalDocument = CType(Occurrence2.OccurrenceDocument, SolidEdgePart.SheetMetalDocument)
                Models = tmpOccurrence2Doc.Models
        End Select

        For Each Model As SolidEdgePart.Model In Models

            If Model.UserDefinedPatterns IsNot Nothing AndAlso Model.UserDefinedPatterns.Count > 0 Then
                For Each UserDefinedPattern As SolidEdgePart.UserDefinedPattern In Model.UserDefinedPatterns

                    Dim InputFeatures = Array.CreateInstance(GetType(Object), 0)
                    UserDefinedPattern.GetInputFeatures(InputFeatures)
                    For Each InputFeature As Object In InputFeatures
                        Dim Hole As SolidEdgePart.Hole = TryCast(InputFeature, SolidEdgePart.Hole)
                        If Hole IsNot Nothing Then
                            Dim HoleSideFaces As SolidEdgeGeometry.Faces = CType(Hole.SideFaces, SolidEdgeGeometry.Faces)
                            'Dim ComType = HCComObject.GetCOMObjectType(HoleSideFaces)

                            For Each SideFace As SolidEdgeGeometry.Face In HoleSideFaces
                                If SideFace.ID = Face2ID Then
                                    TargetPattern = UserDefinedPattern
                                    TargetHole = Hole
                                End If
                                If TargetPattern IsNot Nothing Then Exit For
                            Next
                        End If
                        If TargetPattern IsNot Nothing Then Exit For
                    Next

                    If TargetPattern IsNot Nothing Then Exit For
                Next

            End If
            If TargetPattern IsNot Nothing Then Exit For
        Next

        If TargetPattern IsNot Nothing And TargetHole IsNot Nothing Then

            ' Get a unique name
            Dim ExistingNames As New List(Of String)
            For Each AssemblyPattern As SolidEdgeAssembly.AssemblyPattern In AsmDoc.AssemblyPatterns
                ExistingNames.Add(AssemblyPattern.Name)
            Next

            Dim Prefix As String = "Pattern_"
            Dim Suffix As Integer = 1
            While ExistingNames.Contains($"{Prefix}{CStr(Suffix)}")
                Suffix += 1
            End While

            ' Create the pattern
            Dim SourceOccurrences As New List(Of SolidEdgeAssembly.Occurrence)
            SourceOccurrences.Add(Occurrence)
            If PiggybackOccurrences IsNot Nothing Then SourceOccurrences.AddRange(PiggybackOccurrences)

            Dim RefPattern As Object = Nothing
            Dim RefHole As Object = Nothing

            If Not Occurrence2IsSubassembly Then
                RefPattern = AsmDoc.CreateReference(Occurrence2, TargetPattern)
                RefHole = AsmDoc.CreateReference(Occurrence2, TargetHole)
            Else
                RefPattern = createTopASMRef(Occurrence2Original, TargetPattern)
                RefHole = createTopASMRef(Occurrence2Original, TargetHole)
            End If

            Dim AsmPattern As SolidEdgeAssembly.AssemblyPattern
            If NameSuffix = "" Then
                AsmPattern = AsmDoc.AssemblyPatterns.CreateEx($"{Prefix}{CStr(Suffix)}", SourceOccurrences.ToArray, RefPattern, RefHole)
            Else
                AsmPattern = AsmDoc.AssemblyPatterns.CreateEx($"{Prefix}{CStr(Suffix)}_{NameSuffix}", SourceOccurrences.ToArray, RefPattern, RefHole)
            End If

        Else
            Success = False
        End If


        Return Success
    End Function

    Function createTopASMRef(
        ByVal pSubOcc As SolidEdgeAssembly.SubOccurrence,
        ByVal obj As Object
        ) As SolidEdgeFramework.Reference

        'https://community.sw.siemens.com/s/question/0D54O000061xps4SAA/creating-relations-between-suboccurrences
        'Function that creates a reference of object "obj" that is inside a suboccurrence "pSubOcc" placed at any sublevel inside the main assembly

        Dim pOcc As SolidEdgeAssembly.Occurrence
        Dim pRef As SolidEdgeFramework.Reference

        'We construct the reference of obj recursively to reach the top assembly
        'The first reference to start with is the reference of object "obj" to the immediate containing subassembly.
        'The references are always constructed referring the main top assembly, because we want the relationships are being generated there.
        pRef = CType(pSubOcc.TopLevelDocument.CreateReference(pSubOcc.ThisAsOccurrence, obj), SolidEdgeFramework.Reference)

        While True 'infinite loop
            Try
                'In each loop i get the immediate parent for the suboccurrence in the variable pSubOcc (the subassembly containing the subassembly ... etc)
                pSubOcc = CType(pSubOcc.Parent, SolidEdgeAssembly.SubOccurrence)
            Catch
                'When there is an error is because the immediate parent is not a suboccurrence anymore, but an occurrence of the main top assembly.
                'We have reached the top. pOcc is an Occurrence of the top assembly.
                'We generate the last reference and exit the loop
                pOcc = CType(pSubOcc.Parent, SolidEdgeAssembly.Occurrence)
                pRef = CType(pOcc.TopLevelDocument.CreateReference(pOcc, pRef), SolidEdgeFramework.Reference)
                Exit While
            End Try
            'If there is no error is because pSubOcc is still a suboccurrence (a subassembly inside a subassembly...)
            'I generate the reference of the last reference i generated to the object. (finally it is a reference of a reference of a reference...)
            pRef = CType(pSubOcc.TopLevelDocument.CreateReference(pSubOcc.ThisAsOccurrence, pRef), SolidEdgeFramework.Reference)
        End While

        'When i abandone the loop i have got the reference i was looking for. I return it.
        createTopASMRef = pRef

        'Clean it all.
        pSubOcc = Nothing
        pOcc = Nothing
        pRef = Nothing
        GC.Collect()
    End Function



    ' ###### DATA INSPECTOR TAB ######

    Private Sub UpdatePropertyTab()

        Me.Props.Items.Clear()

        Dim FullPathList = SelectedNodeFullPath.Split(CChar("\")).ToList
        For i = 0 To FullPathList.Count - 1
            FullPathList(i) = SpaceToUnderscore(FullPathList(i))
        Next

        Dim CurrentNode = XmlDoc.ChildNodes(1) ' Root node

        Dim TemplateFound As Boolean = False

        For i = 0 To FullPathList.Count - 1
            Dim NextNodeName = ""
            If i < FullPathList.Count - 1 Then NextNodeName = FullPathList(i + 1)

            Dim ChildNodes = CurrentNode.ChildNodes
            For Each tmpNode As Xml.XmlNode In ChildNodes

                If tmpNode.Name = NextNodeName.Replace(",", Me.XmlCommaIndicator) Then
                    CurrentNode = tmpNode
                    Continue For
                End If

                For Each Attribute As Xml.XmlAttribute In tmpNode.Attributes
                    If Attribute.Name = "Type" Then
                        If Not (Attribute.Value = "Node" Or Attribute.Value.Contains("LeafNode")) Then
                            Dim tmpName As String = tmpNode.Name
                            Dim tmpType As String = Attribute.Value
                            Dim tmpValue As String = tmpNode.InnerText
                            Dim Prop As New Prop(tmpName, tmpType, tmpValue)
                            Props.Items.Add(Prop)
                            If tmpType = "TemplateFormula" Then
                                UpdateThumbnail(tmpValue)
                                TemplateFound = True
                            End If
                        End If
                    End If
                Next
            Next
        Next

        If Not TemplateFound Then UpdateThumbnail("")

        DataGridViewDataInspector.Rows.Clear()

        For i = 0 To Props.Items.Count - 1
            Dim Prop = Props.Items(i)
            DataGridViewDataInspector.Rows.Add(New DataGridViewRow)
            DataGridViewDataInspector.Rows(i).Cells(0).Value = Prop.Name
            DataGridViewDataInspector.Rows(i).Cells(1).Value = Prop.Type
            DataGridViewDataInspector.Rows(i).Cells(2).Value = Prop.Value
        Next

    End Sub

    Private Sub UpdateThumbnail(TemplateFilename As String, Optional FullPathProvided As Boolean = False)
        '' https://community.sw.siemens.com/s/question/0D54O000061xolGSAQ/thumbnail
        Dim StartupDirectory As String = System.Windows.Forms.Application.StartupPath()
        Dim Thumbnail As Bitmap = Nothing

        If TemplateFilename = "" Then
            TemplateFilename = String.Format("{0}\thumbnail.bmp", Me.TemplateDirectory)
            If IO.File.Exists(TemplateFilename) Then
                Thumbnail = New Bitmap(TemplateFilename)
            End If
        Else
            If Not FullPathProvided Then
                TemplateFilename = $"{Me.TemplateDirectory}\{TemplateFilename}"
            Else
                TemplateFilename = TemplateFilename
            End If
            If IO.File.Exists(TemplateFilename) Then
                Dim FI As New IO.FileInfo(TemplateFilename)
                Thumbnail = Thumbnails.ExtractThumbNail(FI, New System.Drawing.Size(100, 75))
            End If
        End If

        If Thumbnail IsNot Nothing Then PictureBox1.Image = Thumbnail

    End Sub


    ' ###### TREEVIEW ######

    Private Function IsTreenode(XmlNode As Xml.XmlNode) As Boolean
        For Each Attribute As Xml.XmlAttribute In XmlNode.Attributes
            If Attribute.Name = "Type" Then
                If Attribute.Value = "Node" Or Attribute.Value.Contains("LeafNode") Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub PopulateTreeView(XmlDoc As System.Xml.XmlDocument, Splash As FormSplash)

        TreeView1.BeginUpdate()

        NodeCount = 0

        'Dim xmlnode As Xml.XmlNode = XmlDoc.ChildNodes(0)
        Dim xmlnode As Xml.XmlNode = XmlDoc.ChildNodes(1)
        TreeView1.Nodes.Clear()

        'TreeView1.Nodes.Add(New TreeNode(XmlDoc.DocumentElement.Name))
        TreeView1.Nodes.Add(New TreeNode(XmlDoc.DocumentElement.Name.Replace(Me.XmlCommaIndicator, ",")))

        Dim tNode As TreeNode = TreeView1.Nodes(0)
        AddNode(xmlnode, tNode, Splash, 1)

        TreeView1.Nodes(0).Expand()

        TreeView1.EndUpdate()

    End Sub

    Private Sub AddNode(ByVal inXmlNode As Xml.XmlNode, ByVal inTreeNode As TreeNode, Splash As FormSplash, NodeMultiplier As Integer)
        Dim xNode As Xml.XmlNode
        Dim tNode As TreeNode
        Dim childNodes As Xml.XmlNodeList

        NodeCount += NodeMultiplier

        Dim StatusMessage As String = inTreeNode.Text
        Dim ParentNode As TreeNode = inTreeNode.Parent
        While ParentNode IsNot Nothing
            StatusMessage = $"{ParentNode.Text}/{StatusMessage}"
            ParentNode = ParentNode.Parent
        End While
        StatusMessage = StatusMessage.Replace("Solid_Edge_Storekeeper/", "")

        If inXmlNode.HasChildNodes Then
            childNodes = inXmlNode.ChildNodes

            For i As Integer = 0 To childNodes.Count - 1
                xNode = childNodes(i)
                If xNode.Name = "MaterialFormula" Then
                    NodeMultiplier = xNode.InnerText.Split(CChar(",")).Count
                End If
                If IsTreenode(xNode) Then
                    Splash.UpdateStatus(StatusMessage)

                    'Dim n As Integer = inTreeNode.Nodes.Add(New TreeNode(UnderscoreToSpace(xNode.Name)))
                    Dim tmpName As String = UnderscoreToSpace(xNode.Name.Replace(Me.XmlCommaIndicator, ","))
                    Dim tmpTreeNode As TreeNode = New TreeNode(tmpName)
                    Dim Tooltip As String = ExtractTooltip(xNode.InnerXml)
                    If Not Tooltip = "" Then tmpTreeNode.ToolTipText = Tooltip
                    Dim n As Integer = inTreeNode.Nodes.Add(tmpTreeNode)

                    tNode = inTreeNode.Nodes(n)
                    AddNode(xNode, tNode, Splash, NodeMultiplier)
                End If
            Next

            inTreeNode.Text = UnderscoreToSpace(inXmlNode.Name.Replace(Me.XmlCommaIndicator, ","))

            ' Add the xml node type as a tag to the tree node
            For Each Attribute As Xml.XmlAttribute In inXmlNode.Attributes
                If Attribute.Name = "Type" Then
                    inTreeNode.Tag = Attribute.Value
                End If
            Next

        End If
    End Sub

    Private Function ExtractTooltip(InnerXml As String) As String
        Dim Tooltip As String = ""

        If InnerXml.Contains("TooltipFormula") Then
            ' <TooltipFormula Type="TooltipFormula">Button head capscrew</TooltipFormula><blah><blah><blah>
            Dim delimiter As String = "TooltipFormula"
            Dim result As List(Of String) = InnerXml.Split(New String() {delimiter}, StringSplitOptions.None).ToList
            If result(0).Count = 1 Then
                Tooltip = result(2)
                Tooltip = Tooltip.Split(CChar(">"))(1)
                Tooltip = Tooltip.Split(CChar("<"))(0)
            End If
        End If

        Return Tooltip
    End Function

    Public Function SpaceToUnderscore(InString As String) As String
        Return InString.Replace(" ", "_")
    End Function

    Public Function UnderscoreToSpace(InString As String) As String
        Return InString.Replace("_", " ")
    End Function

    Private Sub ExpandTreeview(FullPath As String)

        Dim FullPathList As List(Of String)
        Dim Nodes As TreeNodeCollection
        Dim Node As TreeNode
        Dim NextNode As TreeNode = Nothing

        If FullPath = "" Then Exit Sub

        FullPathList = FullPath.Split(CChar("\")).ToList

        If FullPath.Count < 2 Then Exit Sub ' The root node is already expanded.
        FullPath.Remove(0) ' Processing starts at the root node.  It needs to be removed from the list.

        Nodes = TreeView1.Nodes

        For Each NodeText As String In FullPathList
            For Each Node In Nodes
                If NodeText = Node.Text Then
                    Node.Expand()
                    Node.EnsureVisible()
                    NextNode = Node
                    Exit For
                End If
            Next
            Nodes = NextNode.Nodes
            If Nodes.Count = 0 Then Exit For
        Next
    End Sub

    Private Function TruncateDirectoryName(DirectoryName As String) As String
        ' C:\data\CAD\scripts\SolidEdgeStorekeeper\bin\Debug\net8.0-windows
        ' -> C:\data\...\SolidEdgeStorekeeper\bin\Debug\net8.0-windows

        Dim OutText As String = ""

        If DirectoryName Is Nothing Then Return OutText

        Dim MaxWidth As Integer = MyBase.Width - 75
        Dim PixelsPerCharacter As Integer = 7
        Dim MaxCharacters As Integer = CInt(CDbl(MaxWidth) / CDbl(PixelsPerCharacter))

        Dim tmpList As List(Of String) = DirectoryName.Split(CChar("\")).ToList
        tmpList.RemoveAt(tmpList.Count - 1)
        If tmpList.Count < 4 Then Return DirectoryName

        OutText = String.Format("{0}\{1}", tmpList(0), tmpList(1))
        tmpList.RemoveAt(1)
        tmpList.RemoveAt(0)

        Dim tmpText As String = String.Format("{0}\", tmpList(tmpList.Count - 1))
        tmpList.RemoveAt(tmpList.Count - 1)

        For i = tmpList.Count - 1 To 0 Step -1
            Dim tmptmpText As String = String.Format("{0}\{1}", tmpList(i), tmpText)
            If Not OutText.Count + tmptmpText.Count > MaxCharacters Then
                tmpText = tmptmpText
            Else
                Exit For
            End If
        Next

        If Not String.Format("{0}\{1}", OutText, tmpText) = DirectoryName Then
            OutText = String.Format("{0}\...\{1}", OutText, tmpText)
        Else
            OutText = DirectoryName
        End If


        Return OutText
    End Function


    ' ###### EXCEL AND XML ######

    Public Sub LoadXml(Splash As FormSplash)

        ''https://www.codemag.com/Article/2312031/Process-XML-Files-Easily-Using-.NET-6-7
        ''https://stackoverflow.com/questions/54606021/how-to-populate-winforms-treeview-from-xml-file-regardless-the-number-of-childr

        TextBoxStatus.Text = "Reading Excel file"
        Splash.UpdateStatus("Reading Excel file")

        Dim ExcelFilename As String = String.Format("{0}\Storekeeper.xls", Me.DataDirectory)
        Dim XmlFilename As String = IO.Path.ChangeExtension(ExcelFilename, "xml")

        If Me.AlwaysReadExcel Or Not IO.File.Exists(XmlFilename) Then
            Dim ExcelAll As List(Of List(Of String)) = ReadExcel(ExcelFilename)
            If ExcelAll Is Nothing Then Exit Sub  ' ReadExcel provides error feedback

            Splash.UpdateStatus("Converting to XML")

            Dim ExcelTopLevel = ExcelCleanup(ExcelAll, "TopLevel")
            Dim XmlList = ExcelToXml(ExcelTopLevel, ExcelAll, Splash)

            XmlList = SanitizeXMLTags(XmlList)

            IO.File.WriteAllLines(XmlFilename, XmlList)
        End If

        System.Windows.Forms.Application.DoEvents()

        Splash.UpdateStatus("Loading XML")

        Dim XmlString As String = IO.File.ReadAllText(XmlFilename)
        XmlDoc = New System.Xml.XmlDocument
        Try
            XmlDoc.LoadXml(XmlString)
        Catch ex As Exception
            ' The ',' character, hexadecimal value 0x2C, cannot be included in a name. Line 15, position 20.
            Dim tmpXmlList As List(Of String) = XmlString.Split(vbCrLf).ToList
            Dim tmpExAsList As List(Of String) = ex.Message.Split(" ").ToList
            Dim RowIdx As Integer = 0
            For i As Integer = 0 To tmpExAsList.Count - 1
                If tmpExAsList(i).ToLower = "line" Then
                    RowIdx = CInt(tmpExAsList(i + 1))
                    Exit For
                End If
            Next
            Dim s As String = ""
            If Not RowIdx = 0 Then
                s = $"Error reading Xml file.  Line {RowIdx}{vbCrLf}"
                s = $"{s}'{tmpXmlList(RowIdx - 1).Trim}'{vbCrLf}"
                s = $"{s}{vbCrLf}{ex.Message}"
            Else
                s = "Error reading Xml file."
                s = $"{s}{vbCrLf}{ex.Message}"
            End If
            MsgBox(s, vbOKOnly, "Error reading XML")
            End
        End Try

        Splash.UpdateStatus("Populating Treeview")

        PopulateTreeView(XmlDoc, Splash)

        ExpandTreeview(Me.SelectedNodeFullPath)

        TextBoxStatus.Text = ""

    End Sub

    Public Function SanitizeXMLTags(XmlList As List(Of String)) As List(Of String)

        Dim XmlOutList As New List(Of String)
        Dim InTag As Boolean = False
        Dim InQuotes As Boolean = False

        For Each Line As String In XmlList

            'If Not Me.AllowCommaDelimiters Then
            '    XmlOutList.Add(Line.Replace(",", "."))

            'Else
            '    ' Deal with repeated doublequotes
            '    Line = Line.Replace("""", Chr(182))

            '    Dim OutLine As String = ""

            '    For Each Character As String In Line
            '        If Character = Chr(182) Then InQuotes = Not InQuotes
            '        If Character = "<" And Not InQuotes Then InTag = True
            '        If Character = ">" And Not InQuotes Then InTag = False

            '        If InQuotes Then
            '            OutLine = $"{OutLine}{Character}"  ' Must be checked first to capture '<' or '>'
            '        ElseIf InTag Then
            '            If Character = "," Then
            '                OutLine = $"{OutLine}{Me.XmlCommaIndicator}"
            '            Else
            '                OutLine = $"{OutLine}{Character}"
            '            End If
            '        Else
            '            OutLine = $"{OutLine}{Character}"
            '        End If
            '    Next

            '    OutLine = OutLine.Replace(Chr(182), """")
            '    XmlOutList.Add(OutLine)

            'End If

            ' Deal with repeated doublequotes
            Line = Line.Replace("""", Chr(182))

            Dim OutLine As String = ""

            For Each Character As String In Line
                If Character = Chr(182) Then InQuotes = Not InQuotes
                If Character = "<" And Not InQuotes Then InTag = True
                If Character = ">" And Not InQuotes Then InTag = False

                If InQuotes Then
                    OutLine = $"{OutLine}{Character}"  ' Must be checked first to capture '<' or '>'
                ElseIf InTag Then
                    If Character = "," Then
                        OutLine = $"{OutLine}{Me.XmlCommaIndicator}"
                    Else
                        OutLine = $"{OutLine}{Character}"
                    End If
                Else
                    OutLine = $"{OutLine}{Character}"
                End If
            Next

            OutLine = OutLine.Replace(Chr(182), """")
            XmlOutList.Add(OutLine)

        Next

        Return XmlOutList
    End Function
    Public Function ReadExcel(FileName As String) As List(Of List(Of String))
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance) ' Needed by ExcelReader

        If Not IO.File.Exists(FileName) Then
            Dim s As String = $"File not found '{FileName}'{vbCrLf}{vbCrLf}"
            s = $"{s}Set it (and possibly the Library, Templates, and Data directories) in the Tree Search Options dialog "
            s = $"{s}then restart the program. "
            MsgBox(s, vbOKOnly, "File not found")
            Return Nothing
        End If

        Dim tmpList As New List(Of List(Of String))
        Dim i As Integer = 0

        Try
            Using stream = System.IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                ' Auto-detect format, supports:
                '  - Binary Excel files (2.0-2003 format; *.xls)
                '  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                Using reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream)
                    ' Choose one of either 1 or 2:

                    ' 1. Use the reader methods
                    Do ' Loops through a sheet at a time
                        While reader.Read() ' Reads a row at a time

                            Dim EmptyRow As Boolean = True
                            For ColIdx As Integer = 0 To reader.FieldCount - 1
                                Dim s As String = CStr(reader.GetValue(ColIdx))
                                If s IsNot Nothing AndAlso Not s.Trim = "" Then
                                    EmptyRow = False
                                    Exit For
                                End If
                            Next

                            If Not EmptyRow Then
                                Dim tmpInnerList As New List(Of String)
                                tmpInnerList.Add(reader.Name)
                                For ColIdx As Integer = 0 To reader.FieldCount - 1
                                    Dim s As String = CStr(reader.GetValue(ColIdx))
                                    If s IsNot Nothing Then
                                        ' Fix smart quotes
                                        s = s.Replace(ChrW(&H2018), CChar("'")).Replace(ChrW(&H2019), CChar("'"))
                                        s = s.Replace(ChrW(&H201A), CChar("""")).Replace(ChrW(&H201B), CChar(""""))
                                        s = s.Replace(ChrW(&H201C), CChar("""")).Replace(ChrW(&H201D), CChar(""""))
                                    Else
                                        s = ""
                                    End If
                                    tmpInnerList.Add(s)
                                Next
                                tmpList.Add(tmpInnerList)

                            End If

                        End While
                    Loop While reader.NextResult()

                    '' 2. Use the AsDataSet extension method
                    'Dim result = reader.AsDataSet()

                    '' The result of each spreadsheet is in result.Tables
                End Using
            End Using
        Catch ex As Exception
            MsgBox(String.Format("Could not open {0}.  It may be open elsewhere.", IO.Path.GetFileName(FileName)), vbOKOnly, "Unable to open file")
            Return Nothing
        End Try

        Return tmpList
    End Function

    Private Function ExcelCleanup(
        ExcelData As List(Of List(Of String)),
        Sheetname As String
        ) As List(Of List(Of String))

        Dim OutData As New List(Of List(Of String))

        For Each Row As List(Of String) In ExcelData
            If Not Row(0) = Sheetname Then Continue For

            Dim OutList As New List(Of String)
            Dim IndentCount As Integer = 0
            For Each Col As String In Row
                If Col IsNot Nothing AndAlso Not Col.Trim = "" AndAlso Not Col.Trim = Sheetname Then
                    If Col = "Node" Then
                        Col = String.Format("{0}_{1}", Col, CStr(IndentCount - 1))  ' Node -> Node_1
                    End If
                    OutList.Add(Col)
                End If
                IndentCount += 1
            Next
            If OutList.Count > 0 Then
                OutData.Add(OutList)
            End If
        Next

        Return OutData
    End Function

    Private Function ExcelToXml(
        ExcelTopLevel As List(Of List(Of String)),
        ExcelAll As List(Of List(Of String)),
        Splash As FormSplash
        ) As List(Of String)

        Dim XmlList As New List(Of String)
        Dim NextRow As Integer = 0
        Dim Stack As New Stack(Of String)
        Dim Token As String
        Dim Value As String
        Dim Level As Integer = 0
        Dim OldValue As String

        Dim ExcelDataReaderCache As New Dictionary(Of String, List(Of List(Of String)))

        Dim Indent = "    "
        Dim Indents As New List(Of String)
        For tmpLevel As Integer = 0 To 30
            If tmpLevel = 0 Then
                Indents.Add("")
            Else
                Indents.Add(String.Format("{0}{1}", Indents(tmpLevel - 1), Indent))
            End If
        Next

        XmlList.Add("<?xml version=""1.0"" encoding=""utf-8""?>")

        For Each Row As List(Of String) In ExcelTopLevel
            ' Row Examples
            ' ["Node_0", "Solid_Edge_Storekeeper"]
            ' ["Node_2", "FHCS"]
            Token = Row(0) ' "Node_2"
            Value = Row(1) ' "FHCS"

            Splash.UpdateStatus($"Building XML {Token} {Value}")

            If Token.Contains("Node_") Then
                Level = CInt(Token.Split(CChar("_"))(1))

                If Stack.Count < Level + 1 Then
                    Stack.Push(Value)
                    XmlList.Add(String.Format("{0}<{1} Type=""Node"">", Indents(Level), Value))
                Else
                    Do Until Stack.Count = Level
                        Dim tmpLevel As Integer = Stack.Count - 1
                        OldValue = Stack.Pop
                        XmlList.Add(String.Format("{0}</{1}>", Indents(tmpLevel), OldValue))
                    Loop
                    Stack.Push(Value)
                    XmlList.Add(String.Format("{0}<{1} Type=""Node"">", Indents(Level), Value))
                End If

            ElseIf Token = "Nodes" Then
                Dim tmpStartLevel = Level + 1
                Dim tmpDataSource = Value.Split(":")(0)  ' Sheet:AnsiFastenersBHCS -> Sheet, AnsiFasteners.xls:BHCS -> AnsiFasteners.xls
                Dim tmpSheetname = Value.Split(":")(1)  ' Sheet:AnsiFastenersBHCS -> AnsiFastenersBHCS, , AnsiFasteners.xls:BHCS -> BHCS
                Dim SubLevelList As List(Of String)
                If tmpDataSource = "Sheet" Then
                    SubLevelList = ExcelDetailSheetToXml(ExcelAll, tmpSheetname, tmpStartLevel, Indents)
                Else  ' It's an excel filename
                    tmpDataSource = $"{Me.DataDirectory}\{tmpDataSource}"
                    If Not ExcelDataReaderCache.Keys.Contains(tmpDataSource) Then
                        ExcelDataReaderCache(tmpDataSource) = ReadExcel(tmpDataSource)
                        If ExcelDataReaderCache(tmpDataSource) Is Nothing Then Return Nothing
                    End If
                    SubLevelList = ExcelDetailSheetToXml(ExcelDataReaderCache(tmpDataSource), tmpSheetname, tmpStartLevel, Indents)
                End If
                For Each s As String In SubLevelList
                    XmlList.Add(s)
                Next
            Else
                Dim PropertyOnly As String = Row(0).Split(" ")(0)
                XmlList.Add(String.Format("{0}<{1}>{2}</{3}>", Indents(Level), Row(0), Row(1), PropertyOnly))
            End If

        Next

        While Stack.Count > 0
            Dim tmpLevel As Integer = Stack.Count - 1
            OldValue = Stack.Pop
            XmlList.Add(String.Format("{0}</{1}>", Indents(tmpLevel), OldValue))
        End While

        '' ########## Code to find all current Types in the document when needed ##########

        'Dim KnownTypes As New List(Of String)
        'Dim Matches As MatchCollection
        ''Dim MatchString As Match
        'Dim Pattern As String

        'Pattern = "Type=""[^""]*"""  ' Any number of substrings that start with 'Type="' and end with the first encountered '"'.

        'For Each Line As String In XmlList
        '    Matches = Regex.Matches(Line, Pattern)
        '    If Matches.Count > 0 Then
        '        For Each MatchString As Match In Matches
        '            If Not KnownTypes.Contains(MatchString.Value) Then KnownTypes.Add(MatchString.Value)
        '        Next
        '    End If
        'Next

        Return XmlList
    End Function

    Private Function ExcelDetailSheetToXml(
        ExcelAll As List(Of List(Of String)),
        Sheetname As String,
        StartLevel As Integer,
        Indents As List(Of String)
        ) As List(Of String)

        Dim XmlList As New List(Of String)

        Dim tf As Boolean

        Dim ExcelSheet As New List(Of List(Of String))
        For Each RowList As List(Of String) In ExcelAll
            If RowList(0) = Sheetname Then
                Dim tmpList As New List(Of String)
                For Idx As Integer = 1 To RowList.Count - 1  ' Discard sheet name
                    tmpList.Add(RowList(Idx))
                Next
                ExcelSheet.Add(tmpList)
            End If
        Next

        If ExcelSheet.Count = 0 Then
            Return Nothing
        End If

        Dim NameList As List(Of String) = ExcelSheet(0) ' Include, Size, Name,   Description, OD,       Wall
        Dim TypeList As List(Of String) = ExcelSheet(1) ' Boolean, Node, String, String,      Variable, LeafNodeVariable
        ExcelSheet.RemoveAt(1)
        ExcelSheet.RemoveAt(0)

        Dim NodeIdx As Integer = -1
        Dim NodeCount As Integer = 0
        Dim IncludeIdx As Integer = -1
        For Idx As Integer = 0 To TypeList.Count - 1
            If TypeList(Idx) = "Node" Then
                NodeIdx = Idx
                NodeCount += 1
            End If
            If NameList(Idx) = "Include" And IncludeIdx = -1 Then
                IncludeIdx = Idx
            End If
        Next
        If Not NodeCount = 1 Then Return Nothing

        For Each Row As List(Of String) In ExcelSheet

            tf = Not IncludeIdx = -1
            tf = tf AndAlso Not Row(IncludeIdx).ToLower = "true"
            tf = tf AndAlso Not Row(IncludeIdx).ToLower = "t"
            If tf Then Continue For

            ' ###### Moved comma handling to SanitizeXMLTags ######

            'XmlList.Add(String.Format("{0}<{1}_{2} Type=""Node"">", Indents(StartLevel), NameList(NodeIdx), Row(NodeIdx).Replace(",", ".")))  ' #### No exposed commas
            XmlList.Add(String.Format("{0}<{1}_{2} Type=""Node"">", Indents(StartLevel), NameList(NodeIdx), Row(NodeIdx)))  ' #### No exposed commas

            For ColIdx As Integer = 0 To Row.Count - 1

                If ColIdx = NodeIdx Then Continue For
                If Row(ColIdx).Trim = "" Then Continue For

                If Not TypeList(ColIdx).Contains("LeafNode") Then
                    ' </NominalDiameter Type="Variable">0.164</NominalDiameter>
                    Dim tmpName As String = NameList(ColIdx)
                    Dim tmpType As String = TypeList(ColIdx)
                    Dim tmpValue As String = Row(ColIdx)

                    XmlList.Add(String.Format("{0}<{1} Type=""{2}"">{3}</{1}>", Indents(StartLevel + 1), tmpName, tmpType, tmpValue))
                Else
                    ' <Length_0.500 Type="LeafNode">
                    '     <Length Type="Double">0.500</Length>
                    ' </Length_0.500>

                    ' ###### Moved comma handling to SanitizeXMLTags ######

                    'Dim tmpValue As String = Row(ColIdx).Replace(",", ".") ' 0.500, 0,500 -> 0.500
                    Dim tmpValue As String = Row(ColIdx) ' 0.500, 0,500 -> 0.500

                    Dim tmpOuterName As String = String.Format("{0}_{1}", NameList(ColIdx), tmpValue) ' Length_0.500
                    Dim tmpOuterType As String = "LeafNode"
                    Dim tmpInnerName As String = NameList(ColIdx) ' Length
                    Dim tmpInnerType As String = TypeList(ColIdx).Replace("LeafNode", "") ' LeafNodeDouble -> Double

                    XmlList.Add(String.Format("{0}<{1} Type=""{2}"">", Indents(StartLevel + 1), tmpOuterName, tmpOuterType))
                    XmlList.Add(String.Format("{0}<{1} Type=""{2}"">{3}</{1}>", Indents(StartLevel + 2), tmpInnerName, tmpInnerType, tmpValue))
                    XmlList.Add(String.Format("{0}</{1}>", Indents(StartLevel + 1), tmpOuterName))

                End If
            Next

            ' ###### Moved comma handling to SanitizeXMLTags ######

            'XmlList.Add(String.Format("{0}</{1}_{2}>", Indents(StartLevel), NameList(NodeIdx), Row(NodeIdx).Replace(",", ".")))
            XmlList.Add(String.Format("{0}</{1}_{2}>", Indents(StartLevel), NameList(NodeIdx), Row(NodeIdx)))

            'XmlList.Add(String.Format("{0}</{1}_{2}>", Indents(StartLevel), NameList(NodeIdx), Row(NodeIdx)))
        Next

        Return XmlList
    End Function

    Public Function XmlNodeFromPath(FullPath As String) As XmlNode
        'Dim tmpProps As New Props

        Dim Node As XmlNode = Nothing
        Dim FullPathList As List(Of String) = FullPath.Split("\").ToList

        Dim CurrentNode = XmlDoc.ChildNodes(1) ' Root node

        For i = 0 To FullPathList.Count - 1
            Dim NextNodeName = ""
            If i < FullPathList.Count - 1 Then
                NextNodeName = FullPathList(i + 1)
            Else
                Node = CurrentNode
                Exit For
            End If

            Dim ChildNodes = CurrentNode.ChildNodes
            For Each tmpNode As Xml.XmlNode In ChildNodes

                If tmpNode.Name = NextNodeName.Replace(",", Me.XmlCommaIndicator) Then
                    CurrentNode = tmpNode
                    Continue For
                End If

            Next
        Next

        Return Node

    End Function

    Public Function PathFromXmlNode(Node As XmlNode) As String
        Dim FullPath As String = Nothing
        Dim ReversedList As New List(Of String)

        Dim CurrentNode As XmlNode = Node

        While CurrentNode IsNot Nothing
            ReversedList.Add(CurrentNode.Name)
            CurrentNode = CurrentNode.ParentNode
        End While

        ReversedList.RemoveAt(ReversedList.Count - 1)  ' Removes the #document entry

        For i = ReversedList.Count - 1 To 0 Step -1
            FullPath = $"{FullPath}\{ReversedList(i)}"
        Next

        Return FullPath
    End Function

    ' ###### ERROR REPORTING ######

    Public Sub ReportErrors(tmpErrorLogger As HCErrorLogger)
        If tmpErrorLogger.HasErrors Then
            tmpErrorLogger.Save()
            Try
                ' Try to use the default application to open the file.
                Diagnostics.Process.Start(tmpErrorLogger.LogfileName)
            Catch ex As Exception
                ' If none, open with notepad.exe
                Diagnostics.Process.Start("notepad.exe", tmpErrorLogger.LogfileName)
            End Try
        End If

    End Sub


    ' ###### EVENT HANDLERS ######

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup()
    End Sub


    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        If Not Me.SelectedNodeFullPath = e.Node.FullPath Then Me.SelectedNodeFullPath = e.Node.FullPath

        TreeView1.SelectedNode = e.Node

        If e.Node.Nodes.Count = 0 Then
            If e.Button = MouseButtons.Right Then
                ContextMenuStrip1.Show(TreeView1.PointToScreen(e.Location))
            End If
        End If

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        If ButtonClose.Text = "Stop" Then
            Me.ErrorLogger.RequestAbort()
        Else
            'Me.PrePopulate = False
            Me.AddToLibraryOnly = False

            Dim UP As New UtilsPreferences
            UP.SaveFormMainSettings(Me, SavingPresets:=False)
            Me.PropertiesData.Save()

            OleMessageFilter.Revoke()

            End
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles Me.FormClosing
        'Me.PrePopulate = False
        Me.AddToLibraryOnly = False

        Dim UP As New UtilsPreferences
        UP.SaveFormMainSettings(Me, SavingPresets:=False)
        Me.PropertiesData.Save()

        OleMessageFilter.Revoke()

        End
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim Node = TreeView1.SelectedNode
        If Node.Nodes.Count = 0 Then
            Me.ErrorLogger = New HCErrorLogger
            Me.FileLogger = Me.ErrorLogger.AddFile(Node.FullPath)
            Process()
            ReportErrors(Me.ErrorLogger)
        Else
            MsgBox("This is a category header, not an individual part.  It cannot be added to an assembly", vbOKOnly, "Category header")
        End If
    End Sub

    Private Sub ButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click

        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
        Me.TopMost = False

        Dim FO As New FormTreeSearchOptions(Me)
        FO.ShowDialog()

        If FO.DialogResult = DialogResult.OK Then
            ' Nothing to do here.  The options dialog updates parameters in Form_Main.
        End If

        If Me.AlwaysOnTopTimer IsNot Nothing And Me.AlwaysOnTop Then Me.AlwaysOnTopTimer.Start()

    End Sub

    Public Sub DISEApplicationEvents_AfterCommandRun(ByVal theCommandID As Integer)
        If theCommandID = 57637 Then ' SolidEdgeConstants.AssemblyCommandConstants.AssemblyEditPaste
            AssemblyPasteComplete = True
        End If
    End Sub

    Private Sub ButtonCollapse_Click(sender As Object, e As EventArgs) Handles ButtonCollapse.Click
        TreeView1.CollapseAll()
        TreeView1.Nodes(0).Expand()
    End Sub

    Private Sub LabelCollapse_Click(sender As Object, e As EventArgs) Handles LabelSaveIn.Click
        ButtonCollapse.PerformClick()
    End Sub

    Private Sub ButtonPropertySearchOptions_Click(sender As Object, e As EventArgs) Handles ButtonPropertySearchOptions.Click

        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
        Me.TopMost = False

        Dim FPSO As New FormPropertySearchOptions(Me)
        FPSO.ShowDialog()

        ' FormPropertySearchOptions populates relevant FMain properties on ButtonOK.Click

        If FPSO.DialogResult = DialogResult.OK Then
            Dim ColIdx As Integer

            DataGridViewVendorParts.Columns.Clear()
            ColIdx = DataGridViewVendorParts.Columns.Add("Filename", "Filename")
            DataGridViewVendorParts.Columns(ColIdx).Width = 150
            ColIdx = DataGridViewVendorParts.Columns.Add("Path", "Path")
            DataGridViewVendorParts.Columns(ColIdx).Width = 50
            For i = 0 To PropertiesToSearchList.Count - 1
                Dim PropString As String = PropertiesToSearchList(i)
                ColIdx = DataGridViewVendorParts.Columns.Add($"Prop_{i + 1}", PropString)
                DataGridViewVendorParts.Columns(ColIdx).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        End If

        If Me.AlwaysOnTopTimer IsNot Nothing And Me.AlwaysOnTop Then Me.AlwaysOnTopTimer.Start()

    End Sub

    Private Sub ButtonSearchProperties_Click(sender As Object, e As EventArgs) Handles ButtonSearchProperties.Click

        Dim s As String = ""

        If Not IO.Path.Exists(LibraryDirectory) Then
            s = $"{s}Library directory '{LibraryDirectory}' not found.  Set on the Tree Search toolbar.{vbCrLf}"
        End If
        If Not IO.Path.Exists(AssemblyTemplate) Then
            s = $"{s}Assembly template '{AssemblyTemplate}' not found.  Set on the Property Search toolbar.{vbCrLf}"
        End If
        If Not IO.Path.Exists(PartTemplate) Then
            s = $"{s}Part template '{PartTemplate}' not found.  Set on the Property Search toolbar.{vbCrLf}"
        End If
        If Not IO.Path.Exists(SheetmetalTemplate) Then
            s = $"{s}Sheetmetal template '{SheetmetalTemplate}' not found.  Set on the Property Search toolbar.{vbCrLf}"
        End If
        If PropertiesToSearchList.Count = 0 Then
            s = $"{s}Properties to search not specified.  Set on the Property Search toolbar.{vbCrLf}"
        End If

        If Not s = "" Then
            MsgBox(s, vbOKOnly, "Property search")
            Exit Sub
        End If

        If Me.CacheProperties And Me.PropertiesCache Is Nothing Then
            TextBoxStatus.Text = "Retrieving property cache"
            System.Windows.Forms.Application.DoEvents()
            Me.PropertiesCache = New HCPropertiesCache(Me)
            TextBoxStatus.Text = ""
        End If

        Dim SearchTerms As New List(Of String)
        For Each SearchTerm As String In TextBoxSearchTerms.Text.Trim.Split(CChar(" ")).ToList
            If Not SearchTerm.Trim = "" Then
                SearchTerms.Add(SearchTerm)
            End If
        Next

        Dim FileDict As New Dictionary(Of String, List(Of String))

        Dim ActiveFileExtensionsList As New List(Of String)
        ActiveFileExtensionsList.AddRange({"*.asm", "*.par", "*.psm"})

        Dim FoundFiles As New List(Of String)
        FoundFiles.AddRange(FileIO.FileSystem.GetFiles(LibraryDirectory,
                                FileIO.SearchOption.SearchAllSubDirectories,
                                ActiveFileExtensionsList.ToArray))

        Dim SSDoc As HCStructuredStorageDoc = Nothing

        If Me.CacheProperties Then
            Me.PropertiesCache.Update(FoundFiles, New Logger("CacheLogger", Nothing))
        End If

        For Each Filename As String In FoundFiles

            TextBoxStatus.Text = IO.Path.GetFileName(Filename)
            System.Windows.Forms.Application.DoEvents()

            If Not Me.CacheProperties Then
                Try
                    SSDoc = New HCStructuredStorageDoc(Filename, _OpenReadWrite:=False)
                    SSDoc.ReadProperties(Me.PropertiesData)
                Catch ex As Exception
                    If SSDoc IsNot Nothing Then SSDoc.Close()
                    Continue For
                End Try
            End If

            FileDict(Filename) = New List(Of String)

            Dim PropertySet As String = ""
            Dim PropertySetConstant As PropertyData.PropertySetNameConstants = PropertyData.PropertySetNameConstants.System
            Dim PropertyNameEnglish = ""
            Dim PropertyValue As String

            For Each PropertyName In PropertiesToSearchList

                PropertyName = PropertyName.Split(CChar("."))(1)  ' 'System.Title' -> 'Title'

                Dim tmpPropertyData As PropertyData

                tmpPropertyData = Me.PropertiesData.GetPropertyData(PropertyName)
                If tmpPropertyData IsNot Nothing Then
                    PropertySetConstant = tmpPropertyData.PropertySetName
                    Select Case PropertySetConstant
                        Case PropertyData.PropertySetNameConstants.Custom
                            PropertySet = "Custom"
                        Case PropertyData.PropertySetNameConstants.System
                            PropertySet = "System"
                    End Select

                    PropertyNameEnglish = tmpPropertyData.EnglishName
                End If

                PropertyValue = ""

                If Not Me.CacheProperties Then
                    PropertyValue = CStr(SSDoc.GetPropValue(PropertySet, PropertyNameEnglish))
                Else
                    PropertyValue = CStr(Me.PropertiesCache.GetPropValue(Filename, PropertySet, PropertyNameEnglish))
                End If

                If PropertyValue Is Nothing Then PropertyValue = ""

                FileDict(Filename).Add(PropertyValue)
            Next

            If Not Me.CacheProperties Then SSDoc.Close()

        Next

        Dim MatchDict As New Dictionary(Of String, List(Of String))

        If SearchTerms.Count > 0 Then
            For Each Filename As String In FileDict.Keys

                TextBoxStatus.Text = IO.Path.GetFileName(Filename)
                System.Windows.Forms.Application.DoEvents()

                Dim MatchList As New List(Of String)
                For Each PropValue As String In FileDict(Filename)
                    For Each SearchTerm As String In SearchTerms
                        If PropValue.ToLower.Contains(SearchTerm.ToLower) And Not MatchList.Contains(SearchTerm.ToLower) Then
                            MatchList.Add(SearchTerm.ToLower)
                            If MatchList.Count = SearchTerms.Count Then
                                MatchDict(Filename) = FileDict(Filename)
                                Exit For
                            End If
                        End If
                    Next
                    If MatchDict.Keys.Contains(Filename) Then
                        Exit For
                    End If
                Next
            Next
        End If

        Dim DisplayDict As Dictionary(Of String, List(Of String)) = Nothing

        If SearchTerms.Count > 0 Then
            DisplayDict = MatchDict
        Else
            DisplayDict = FileDict
        End If

        DataGridViewVendorParts.Rows.Clear()

        If DisplayDict.Count > 0 Then

            For Each Filename As String In DisplayDict.Keys

                TextBoxStatus.Text = IO.Path.GetFileName(Filename)
                System.Windows.Forms.Application.DoEvents()

                Dim RowIdx As Integer = DataGridViewVendorParts.Rows.Add()
                DataGridViewVendorParts.Rows(RowIdx).Cells(0).Value = IO.Path.GetFileName(Filename)
                DataGridViewVendorParts.Rows(RowIdx).Cells(1).Value = Filename
                For i = 0 To DisplayDict(Filename).Count - 1
                    DataGridViewVendorParts.Rows(RowIdx).Cells(i + 2).Value = DisplayDict(Filename)(i)
                Next
            Next
        End If

        TextBoxStatus.Text = $"{DisplayDict.Count} files found"

    End Sub

    Private Sub DataGridView2_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewVendorParts.CellMouseDown
        ' https://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagridview

        If Not (e.RowIndex = -1 Or e.ColumnIndex = -1) Then
            DataGridViewVendorParts.CurrentCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim PropertySearchFilename As String = CStr(DataGridViewVendorParts.Rows(e.RowIndex).Cells(1).Value)
            UpdateThumbnail(PropertySearchFilename, FullPathProvided:=True)

            If e.Button = MouseButtons.Right Then
            End If
        End If
    End Sub

    Private Sub AddToAssemblyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToAssemblyToolStripMenuItem.Click
        Dim RowIdx As Integer = DataGridViewVendorParts.CurrentCell.RowIndex
        Dim PropertySearchFilename As String = CStr(DataGridViewVendorParts.Rows(RowIdx).Cells(1).Value)

        Me.ErrorLogger = New HCErrorLogger
        Me.FileLogger = Me.ErrorLogger.AddFile(PropertySearchFilename)
        Process(PropertySearchFilename:=PropertySearchFilename)
        ReportErrors(Me.ErrorLogger)
    End Sub

    Private Sub ButtonHelp_Click(sender As Object, e As EventArgs) Handles ButtonHelp.Click
        Dim Info = New ProcessStartInfo()
        Info.FileName = "https://github.com/rmcanany/SolidEdgeStorekeeper#readme"
        Info.UseShellExecute = True
        System.Diagnostics.Process.Start(Info)
    End Sub

    Private Sub treeTestsSelection_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        ' https://stackoverflow.com/questions/7257356/checking-treeview-nodes

        If e.Action <> TreeViewAction.ByMouse And e.Action <> TreeViewAction.ByKeyboard Then Exit Sub

        CheckAllNodes(e.Node)
    End Sub

    Public Sub CheckAllNodes(ByRef TreeNodeToCheck As TreeNode)
        Dim val As Boolean = TreeNodeToCheck.Checked
        For Each n As TreeNode In TreeNodeToCheck.Nodes
            n.Checked = val
            If n.GetNodeCount(True) > 0 Then
                CheckAllNodes(n)
            End If
        Next
    End Sub

    Private Sub ButtonAddToLibrary_Click(sender As Object, e As EventArgs)
        Dim CheckedNodesList As New List(Of TreeNode)
        Dim RootNode = TreeView1.Nodes(0)
        GetCheckedNodes(RootNode, CheckedNodesList)
        Dim Count = CheckedNodesList.Count
        Dim MaxMsgCount = 30
        Dim s = ""

        If Count = 0 Then
            MsgBox("No checked items found", vbOKOnly)
            Exit Sub
        End If

        If Count = 1 Then
            s = $"Add this item to the library?{vbCrLf}{vbCrLf}"
        ElseIf Count <= MaxMsgCount Then
            s = $"Add these items to the library?{vbCrLf}{vbCrLf}"
        Else
            s = $"Add these items (and {Count - MaxMsgCount} more) to the library?{vbCrLf}{vbCrLf}"
        End If

        For i = 0 To CheckedNodesList.Count - 1
            If i = MaxMsgCount Then Exit For
            Dim Pathname = CheckedNodesList(i).FullPath
            Pathname = Pathname.Replace("Solid Edge Storekeeper\", "")
            s = $"{s}    {Pathname}{vbCrLf}"
        Next

        Dim Result = MsgBox(s, vbYesNo, "Add to Library")

        If Result = MsgBoxResult.Yes Then

            ErrorLogger = New HCErrorLogger

            AddToLibraryOnly = True
            ButtonClose.Text = "Stop"
            ButtonClose.BackColor = Color.Coral

            Dim AddedCount = 0

            For Each Node In CheckedNodesList
                Application.DoEvents()
                If ErrorLogger.Abort Then Exit For
                TreeView1.SelectedNode = Node
                FileLogger = ErrorLogger.AddFile(Node.FullPath)
                Node.EnsureVisible()
                Process()
                AddedCount += 1
            Next

            ReportErrors(ErrorLogger)

            ButtonClose.Text = "Close"
            ButtonClose.BackColor = Color.White
            AddToLibraryOnly = False
            TextBoxStatus.Text = $"Added {AddedCount} items to the library"
        End If

    End Sub

    Private Sub GetCheckedNodes(Node As TreeNode, CheckedNodesList As List(Of TreeNode))

        If Node.Nodes.Count = 0 Then
            If Node.Checked Then CheckedNodesList.Add(Node)
        Else
            For Each SubNode As TreeNode In Node.Nodes
                GetCheckedNodes(SubNode, CheckedNodesList)
            Next
        End If
    End Sub

    Private Sub ReplaceSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceSelectedToolStripMenuItem.Click

        Dim Node = TreeView1.SelectedNode
        If Node.Nodes.Count = 0 Then
            If Not (Me.FailedConstraintSuppress Or Me.FailedConstraintAllow) Then
                MsgBox("Set how to handle failed constraints on the Tree Search Options dialog", vbOKOnly, "Handling Failed Constraints")
                Exit Sub
            End If
            Me.ErrorLogger = New HCErrorLogger
            Me.FileLogger = Me.ErrorLogger.AddFile(Node.FullPath)
            Process(Replace:=True)
            ReportErrors(Me.ErrorLogger)
        Else
            MsgBox("This is a category header, not an individual part.  It cannot be added to an assembly", vbOKOnly, "Category header")
        End If

    End Sub

    Private Sub ReplaceAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceAllToolStripMenuItem.Click

        Dim Node = TreeView1.SelectedNode
        If Node.Nodes.Count = 0 Then
            If Not (Me.FailedConstraintSuppress Or Me.FailedConstraintAllow) Then
                MsgBox("Set how to handle failed constraints on the Tree Search Options dialog", vbOKOnly, "Handle Failed Constraints")
                Exit Sub
            End If
            Me.ErrorLogger = New HCErrorLogger
            Me.FileLogger = Me.ErrorLogger.AddFile(Node.FullPath)
            Process(Replace:=True, ReplaceAll:=True)
            ReportErrors(Me.ErrorLogger)
        Else
            MsgBox("This is a category header, not an individual part.  It cannot be added to an assembly", vbOKOnly, "Category header")
        End If

    End Sub

    Private Sub FastenerStackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FastenerStackToolStripMenuItem.Click

        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
        Me.TopMost = False

        Dim Node = TreeView1.SelectedNode

        Dim tmpErrorLogger As New HCErrorLogger
        Dim FastenerStackLogger = tmpErrorLogger.AddFile("Fastener Stack")
        Dim Proceed As Boolean = CheckStartConditions(Nothing, FastenerStackLogger) ' Handles multiple material choices

        If tmpErrorLogger.HasErrors Then
            ReportErrors(tmpErrorLogger)
        Else
            Dim FFS As New FormFastenerStack(Me)
            FFS.ShowDialog()
        End If

        If Me.AlwaysOnTopTimer IsNot Nothing And Me.AlwaysOnTop Then Me.AlwaysOnTopTimer.Start()

    End Sub

    Private Sub EventTest(sender As Object, e As EventArgs)
        If TextBoxStatus.Text = "" Then
            TextBoxStatus.Text = "Clicked Set Style"
        Else
            TextBoxStatus.Text = ""
        End If
        Dim i = 0
    End Sub

    Private Sub HandleAlwaysOnTopTimerTick(sender As Object, e As EventArgs)

        Me.TopMost = True

    End Sub

    Private Sub ComboBoxSaveIn_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxSaveIn.SelectedIndexChanged

        Select Case ComboBoxSaveIn.Text
            Case "Library"
                Me.SaveInLibrary = True
                Me.SaveInAssemblyDirectory = False
                Me.SaveInOther = False
            Case "Assy Dir"
                Me.SaveInLibrary = False
                Me.SaveInAssemblyDirectory = True
                Me.SaveInOther = False
            Case "Other"
                Me.SaveInLibrary = False
                Me.SaveInAssemblyDirectory = False
                Me.SaveInOther = True
        End Select

    End Sub

    Private Sub ComboBoxMaterials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMaterials.SelectedIndexChanged
        Me.ActiveMaterial = ComboBoxMaterials.Text
    End Sub

    Private Sub ComboBoxSaveIn_GotFocus(sender As Object, e As EventArgs) Handles ComboBoxSaveIn.GotFocus
        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
    End Sub

    Private Sub ComboBoxSaveIn_LostFocus(sender As Object, e As EventArgs) Handles ComboBoxSaveIn.LostFocus
        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Start()
    End Sub

    Private Sub ComboBoxMaterials_GotFocus(sender As Object, e As EventArgs) Handles ComboBoxMaterials.GotFocus
        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Stop()
    End Sub

    Private Sub ComboBoxMaterials_LostFocus(sender As Object, e As EventArgs) Handles ComboBoxMaterials.LostFocus
        If Me.AlwaysOnTopTimer IsNot Nothing Then Me.AlwaysOnTopTimer.Start()
    End Sub


End Class

Public Class Props
    Public Property Items As List(Of Prop)

    Public Sub New()
        Me.Items = New List(Of Prop)
    End Sub

    Public Function GetPropsOfType(Typename As String) As List(Of Prop)
        'Node
        'SEPropertyName             ' The name of a Property in the SE file.  Eg PartNumberProperty Type="SEPropertyName", %{Custom.PartNumber}
        'SEPropertyFormulaString    ' The value, of type String, to use to assign to the named property
        '                             PartNumberFormula Type="SEPropertyFormulaString", NA
        'SEPropertyFormulaBoolean   ' The value, of type Boolean, to use to assign to the named property
        '                             HardwareFormula Type="SEPropertyFormulaBoolean", TRUE
        'SEPropertyFormulaMaterial  ' The Material name.  This also causes other material properties to be updated.
        '                             MaterialFormula Type="SEPropertyFormulaMaterial", STEEL
        'TemplateFormula            ' The name of the template file
        'FilenameFormula            ' The name of the file to create (PROMPT is a special case that gets the name from the user)
        'String
        'Variable                   ' The name of a Variable in the SE file.
        'ParameterString            ' The API parameter to be used.  Any parameters must be handled in the file update code.
        '                             Currently the only valid ParameterString is ThreadDescription
        'LeafNode

        Dim PropList As New List(Of Prop)

        For Each Prop As Prop In Items
            If Prop.Type.ToLower = Typename.ToLower Then PropList.Add(Prop)
        Next

        Return PropList
    End Function

    Public Function GetProp(Name As String) As Prop
        Dim FoundProp As Prop = Nothing
        For Each Item As Prop In Me.Items
            If Item.Name = Name Then
                FoundProp = Item
                Exit For
            End If
        Next
        Return FoundProp
    End Function

    Public Function SubstitutePropFormulas(
        InString As String,
        ActiveMaterial As String,
        ErrorLogger As Logger
        ) As String

        Dim OutString As String = InString

        Dim PropDict As New Dictionary(Of String, String)

        For Each Item As Prop In Items
            If Not Item.Name = "MaterialFormula" Then
                Dim tmpValue = Item.Value
                PropDict($"%{{{Item.Name}}}") = tmpValue  ' "%{Length}": "0.500"
            Else
                PropDict($"%{{{Item.Name}}}") = ActiveMaterial
            End If
        Next

        For Each FormulaID In PropDict.Keys
            OutString = OutString.Replace(FormulaID, PropDict(FormulaID))
        Next

        Dim Matches As MatchCollection
        'Dim MatchString As Match
        Dim Pattern As String

        Pattern = "%{[^}]*}"  ' Any number of substrings that start with "%{" and end with the first encountered "}".
        Matches = Regex.Matches(OutString, Pattern)
        If Not Matches.Count = 0 Then
            If ErrorLogger IsNot Nothing Then ErrorLogger.AddMessage($"Some properties could not be resolved in '{OutString}'")
            Return Nothing
        End If

        Return OutString
    End Function

End Class

Public Class Prop
    Public Property Name As String
    Public Property Type As String
    Public Property Value As String

    Public Sub New(_Name As String, _Type As String, _Value As String)
        Me.Name = _Name
        Me.Type = _Type
        Me.Value = _Value
    End Sub
End Class

