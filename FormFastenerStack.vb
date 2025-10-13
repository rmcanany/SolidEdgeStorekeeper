Option Strict On
Imports System.Xml

Public Class FormFastenerStack

    ' Interform communication
    ' https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp

    Public Property FMain As Form_Main

    'Private _ThreadDepthDouble As Double
    'Public Property ThreadDepthDouble As Double
    '    Get
    '        Return _ThreadDepthDouble
    '    End Get
    '    Set(value As Double)
    '        If value = -1 Then
    '            Me.Activate()
    '            MsgBox("Select a tapped hole", vbOKOnly)
    '        Else
    '            _ThreadDepthDouble = value
    '        End If

    '    End Set
    'End Property

    'Private WithEvents Command As SolidEdgeFramework.Command
    'Private WithEvents Mouse As SolidEdgeFramework.Mouse


    Private _StackConfiguration As StackConfigurationConstants
    Public Property StackConfiguration As StackConfigurationConstants
        Get
            Return _StackConfiguration
        End Get
        Set(value As StackConfigurationConstants)
            _StackConfiguration = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                UpdateForm()
                SetFastenerMinMaxLength()
            End If
        End Set
    End Property

    Public Property TopFilename As String
    Public Property BottomFilename As String

    Private _FastenerFilename As String
    Public Property FastenerFilename As String
        Get
            Return _FastenerFilename
        End Get
        Set(value As String)
            _FastenerFilename = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.LabelTopFastener.Text = IO.Path.GetFileName(_FastenerFilename)

                GetRelatedFilenames()
            End If
        End Set
    End Property

    Private _FlatWasherFilename As String
    Public Property FlatWasherFilename As String
        Get
            Return _FlatWasherFilename
        End Get
        Set(value As String)
            _FlatWasherFilename = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.LabelTopFlatWasher.Text = IO.Path.GetFileName(_FlatWasherFilename)
                Me.LabelBottomFlatWasher.Text = IO.Path.GetFileName(_FlatWasherFilename)
            End If
        End Set
    End Property

    Private _LockwasherFilename As String
    Public Property LockwasherFilename As String
        Get
            Return _LockwasherFilename
        End Get
        Set(value As String)
            _LockwasherFilename = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.LabelTopLockwasher.Text = IO.Path.GetFileName(_LockwasherFilename)
                Me.LabelBottomLockwasher.Text = IO.Path.GetFileName(_LockwasherFilename)
            End If
        End Set
    End Property

    Private _NutFilename As String
    Public Property NutFilename As String
        Get
            Return _NutFilename
        End Get
        Set(value As String)
            _NutFilename = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.LabelBottomNut.Text = IO.Path.GetFileName(_NutFilename)
            End If
        End Set
    End Property

    Private _FlatWasherThickness As Double
    Public Property FlatWasherThickness As Double
        Get
            Return _FlatWasherThickness
        End Get
        Set(value As Double)
            _FlatWasherThickness = value
            SetFastenerMinMaxLength()
        End Set
    End Property

    Private _LockWasherThickness As Double
    Public Property LockWasherThickness As Double
        Get
            Return _LockWasherThickness
        End Get
        Set(value As Double)
            _LockWasherThickness = value
            SetFastenerMinMaxLength()
        End Set
    End Property

    Private _NutThickness As Double
    Public Property NutThickness As Double
        Get
            Return _NutThickness
        End Get
        Set(value As Double)
            _NutThickness = value
            SetFastenerMinMaxLength()
        End Set
    End Property


    Private _ClampedThickness As String
    Public Property ClampedThickness As String
        Get
            Return _ClampedThickness
        End Get
        Set(value As String)
            _ClampedThickness = value
            SetFastenerMinMaxLength()
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.TextBoxClampedThickness.Text = _ClampedThickness
            End If
        End Set
    End Property

    Private _ThreadEngagementMin As String
    Public Property ThreadEngagementMin As String
        Get
            Return _ThreadEngagementMin
        End Get
        Set(value As String)
            _ThreadEngagementMin = value
            SetFastenerMinMaxLength()
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.TextBoxThreadEngagementMin.Text = _ThreadEngagementMin
            End If
        End Set
    End Property

    Private _ThreadDepth As String
    Public Property ThreadDepth As String
        Get
            Return _ThreadDepth
        End Get
        Set(value As String)
            _ThreadDepth = value
            SetFastenerMinMaxLength()
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.TextBoxThreadDepth.Text = _ThreadDepth
            End If
        End Set
    End Property

    Private _ExtensionMin As String
    Public Property ExtensionMin As String
        Get
            Return _ExtensionMin
        End Get
        Set(value As String)
            _ExtensionMin = value
            SetFastenerMinMaxLength()
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.TextBoxExtensionMin.Text = _ExtensionMin
            End If
        End Set
    End Property

    Private _Units As String
    Public Property Units As String
        Get
            Return _Units
        End Get
        Set(value As String)
            _Units = value
            If Me.TableLayoutPanel1 IsNot Nothing Then
                Me.ComboBoxUnits.Text = _Units
                UpdateLabelsWithUnits()
            End If
        End Set
    End Property

    Public Property FastenerMinLength As Double
    Public Property FastenerMaxLength As Double
    Public Property TreeviewFastenerFullPath As String
    Public Property TreeviewFlatWasherFullPath As String
    Public Property TreeviewLockwasherFullPath As String
    Public Property TreeviewNutFullPath As String


    ' Xml relative search paths starting from a fastener

    ' SE2024 ..\..\..\Washer_Flat
    ' SE2019 ..\..\..\..\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series
    Public Property FlatWasherSearchPaths As List(Of String)

    ' SE2024 ..\..\..\Washer_Lock
    ' SE2019 NA
    Public Property LockWasherSearchPaths As List(Of String)

    ' SE2024 ..\..\Nut_Hex
    ' SE2019 ..\..\..\..\ISO_NUTS_-_Steel\ISO_4032_-_Hexagon_regular_nuts, ..\..\..\ISO_NUTS_-_Steel\ISO_8673_-_Hexagon_regular_nuts_-_fine_pitch
    Public Property NutSearchPaths As List(Of String)

    Private Property ErrorLogger As HCErrorLogger
    Private Property FileLogger As Logger

    Private Property AssembleCommandComplete As Boolean

    'Private SEAppEvents As SolidEdgeFramework.DISEApplicationEvents_Event


    Public Enum StackConfigurationConstants

        '  F Fastener
        ' CO Clamped Object
        '  N Nut
        ' FW Flat Washer
        ' LW Lock Washer
        ' TT Thread Thru
        ' TB Thread Blind

        F_CO_N
        F_CO_FW_N
        F_CO_LW_N
        F_CO_FW_LW_N
        F_FW_CO_N
        F_FW_CO_FW_N
        F_FW_CO_LW_N
        F_FW_CO_FW_LW_N
        F_CO_TT
        F_FW_CO_TT
        F_LW_CO_TT
        F_LW_FW_CO_TT
        F_CO_TB
        F_FW_CO_TB
        F_LW_CO_TB
        F_LW_FW_CO_TB
    End Enum


    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.FMain = _FMain

    End Sub

    Private Sub Startup()
        'Me.ErrorLogger = New HCErrorLogger

        Dim UP As New UtilsPreferences

        'Dim tmpFastenerFilename As String = Me.FastenerFilename
        UP.GetFormFastenerStackSettings(Me)
        'Me.FastenerFilename = tmpFastenerFilename

        If Not (Me.Units = "in" Or Me.Units = "mm") Then
            Me.Units = "in"
        End If

        Dim Proceed As Boolean = UP.CreateSearchPathFiles()

        If Not Proceed Then
            MsgBox("FFS.Load: Could not create Xml search path files")
            Me.Dispose()
        Else
            Dim DataVersion As String = Nothing
            If FMain.DataDirectory.Contains("SE2019") Then
                DataVersion = "SE2019"
            ElseIf FMain.DataDirectory.Contains("SE2024") Then
                DataVersion = "SE2024"
            Else
                MsgBox($"FFS.Load: Unrecognzied data directory '{FMain.DataDirectory}'")
                Me.Dispose()
            End If

            Me.FlatWasherSearchPaths = UP.GetFlatWasherSearchPath(DataVersion)
            Me.LockWasherSearchPaths = UP.GetLockWasherSearchPath(DataVersion)
            Me.NutSearchPaths = UP.GetNutSearchPath(DataVersion)

            Dim TemplateFilename As String = FMain.GetTemplateNameFormula(ErrorLogger:=New Logger("Form Load", Nothing))
            Dim Extension As String = IO.Path.GetExtension(TemplateFilename)
            Me.FastenerFilename = FMain.GetFilenameFormula(DefaultExtension:=Extension, New Logger("Form Load", Nothing))
            Dim i = 0
            'Me.FileLogger = Me.ErrorLogger.AddFile(Me.FastenerFilename)
        End If
    End Sub

    Public Sub Process()
        Dim Proceed As Boolean = True

        'If FMain.SEApp Is Nothing Then
        '    Proceed = False
        '    Me.FileLogger.AddMessage("Solid Edge not running")
        'End If

        'If Proceed And FMain.AsmDoc Is Nothing Then
        '    Proceed = False
        '    Me.FileLogger.AddMessage("Assembly file not active")
        'End If

        If Proceed AndAlso Not CheckStartConditions(Me.FileLogger.AddLogger("Check start conditions")) Then
            Proceed = False
            'Me.FileLogger.AddMessage("Some start conditions not met")
        End If

        If Proceed AndAlso Not GenerateNeededFiles(Me.FileLogger.AddLogger("Generate needed files")) Then
            Proceed = False
            'Me.FileLogger.AddMessage("Could not generate all needed files")
        End If

        If Proceed Then
            FMain.SEApp.DisplayAlerts = False

            Dim StackAssyFilenames As List(Of String) = Nothing
            Dim NumAddedItems As Dictionary(Of String, Integer) = Nothing

            StackAssyFilenames = PrepStackAssemblies(Me.FileLogger.AddLogger("Prep temporary stack subassemblies"))
            If StackAssyFilenames IsNot Nothing Then
                If StackAssyFilenames.Count = 1 Then
                    Me.TopFilename = StackAssyFilenames(0)
                    Me.BottomFilename = ""
                ElseIf StackAssyFilenames.Count = 2 Then
                    Me.TopFilename = StackAssyFilenames(0)
                    Me.BottomFilename = StackAssyFilenames(1)
                Else
                    Proceed = False
                    'Me.FileLogger.AddMessage("Problem preparing temporary assembly files")
                End If
            Else
                Proceed = False
                'Me.FileLogger.AddMessage("Problem preparing temporary assembly files")
            End If
        End If

        Dim InitialNumOccurrences As Integer = 0

        If Proceed Then
            InitialNumOccurrences = FMain.AsmDoc.Occurrences.Count
        End If

        If Proceed Then
            Proceed = AddStackElementAndDisperse(Me.TopFilename, Me.FileLogger.AddLogger("Add and disperse top fastener stack"))
            'If Not Proceed Then Me.FileLogger.AddMessage("Problem adding or dispersing top fastener stack")
        End If

        If Proceed And Not Me.BottomFilename = "" Then
            Proceed = AddStackElementAndDisperse(Me.BottomFilename, Me.FileLogger.AddLogger("Add and disperse top fastener stack"))
            'If Not Proceed Then Me.FileLogger.AddMessage("Problem adding or dispersing bottom fastener stack")
        End If

        If Proceed Then
            Proceed = CreateFastenerStackGroup(InitialNumOccurrences, Me.FileLogger.AddLogger("Create fastener stack group"))
            'If Not Proceed Then Me.FileLogger.AddMessage("Problem creating assembly group")
        End If

        If FMain.SEApp IsNot Nothing Then FMain.SEApp.DisplayAlerts = True

        Me.TopMost = True

    End Sub

    Private Function CheckStartConditions(_ErrorLogger As Logger) As Boolean

        Dim UC As New UtilsCommon

        Dim Success As Boolean = True

        'If Not IO.File.Exists(Me.FastenerFilename) Then
        '    Success = False
        '    Me.FileLogger.AddMessage($"Fastener not found: '{Me.FastenerFilename}'")
        'End If

        If Not (Me.Units = "in" Or Me.Units = "mm") Then
            Success = False
            _ErrorLogger.AddMessage("Units not set to 'in' or 'mm'")
        End If

        Try
            Dim V = CDbl(UC.FixLocaleDecimal(Me.ClampedThickness))
        Catch ex As Exception
            Success = False
            _ErrorLogger.AddMessage($"Could not resolve clamped thickness: '{Me.ClampedThickness}'")
        End Try

        Dim ConfigString As String = Me.StackConfiguration.ToString

        If ConfigString.Contains("_N") Then
            If Me.NutFilename.ToLower.Contains("not found") Then
                Success = False
                _ErrorLogger.AddMessage(Me.NutFilename)
            End If
        End If

        If ConfigString.Contains("_FW_") Then
            If Me.FlatWasherFilename.ToLower.Contains("not found") Then
                Success = False
                _ErrorLogger.AddMessage(Me.FlatWasherFilename)
            End If
        End If

        If ConfigString.Contains("_LW_") Then
            If Me.LockwasherFilename.ToLower.Contains("not found") Then
                Success = False
                _ErrorLogger.AddMessage(Me.LockwasherFilename)
            End If
        End If

        If ConfigString.Contains("_N") Or ConfigString.Contains("_TT") Then
            Try
                Dim V = CDbl(UC.FixLocaleDecimal(Me.ExtensionMin))
            Catch ex As Exception
                Success = False
                _ErrorLogger.AddMessage($"Could not resolve minimum extension: '{Me.ExtensionMin}'")
            End Try
        End If

        If ConfigString.Contains("_TB") Then
            Try
                Dim V = CDbl(UC.FixLocaleDecimal(Me.ThreadEngagementMin))
            Catch ex As Exception
                Success = False
                _ErrorLogger.AddMessage($"Could not resolve minimum thread engagement: '{Me.ThreadEngagementMin}'")
            End Try
            Try
                Dim V = CDbl(UC.FixLocaleDecimal(Me.ThreadDepth))
            Catch ex As Exception
                Success = False
                _ErrorLogger.AddMessage($"Could not resolve thread depth: '{Me.ThreadDepth}'")
            End Try
        End If

        Return Success

    End Function

    Private Function GenerateNeededFiles(_ErrorLogger As Logger) As Boolean

        Dim Proceed As Boolean = True

        Dim tmpTreeviewFastenerFullPath As String

        ' Get the correct length of fastener for the given parameters
        LabelStatus.Text = "Getting fastener with correct length"
        tmpTreeviewFastenerFullPath = GetCorrectLengthFastenerFullPath(
            Me.TreeviewFastenerFullPath, Me.FastenerMinLength, Me.FastenerMaxLength)

        If tmpTreeviewFastenerFullPath IsNot Nothing Then
            Me.TreeviewFastenerFullPath = tmpTreeviewFastenerFullPath
        Else
            _ErrorLogger.AddMessage("No fastener length satisfies given parameters")
            LabelStatus.Text = ""
            Return False
        End If

        Dim ConfigString As String = Me.StackConfiguration.ToString

        Dim tmpSelectedNodeFullPath = FMain.SelectedNodeFullPath ' Save the original selected node.  Used to reset the form after processing.

        FMain.AddToLibraryOnly = True  ' We don't want to add the individual files to the user's assembly

        ' Generate the fastener if needed
        LabelStatus.Text = "Generating fastener"
        FMain.SelectedNodeFullPath = Me.TreeviewFastenerFullPath
        Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger:=_ErrorLogger))
        Me.FastenerFilename = FMain.GetFilenameFormula(DefaultExtension:=DefaultExtension, _ErrorLogger)
        Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)

        ' Generate the flat washer if needed
        If Proceed And ConfigString.Contains("_FW_") Then
            LabelStatus.Text = "Generating flat washer"
            FMain.SelectedNodeFullPath = Me.TreeviewFlatWasherFullPath
            Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
        End If

        ' Generate the lock washer if needed
        If Proceed And ConfigString.Contains("_LW_") Then
            LabelStatus.Text = "Generating lock washer"
            FMain.SelectedNodeFullPath = Me.TreeviewLockwasherFullPath
            Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
        End If

        ' Generate the nut if needed
        If Proceed And ConfigString.Contains("_N") Then
            LabelStatus.Text = "Generating nut"
            FMain.SelectedNodeFullPath = Me.TreeviewNutFullPath
            Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
        End If

        ' Reset to original conditions
        FMain.AddToLibraryOnly = False
        FMain.SelectedNodeFullPath = tmpSelectedNodeFullPath

        LabelStatus.Text = ""

        Return Proceed

    End Function

    Private Function PrepStackAssemblies(_ErrorLogger As Logger) As List(Of String)

        Dim Outlist As New List(Of String)

        If FMain.SEApp Is Nothing Or FMain.AsmDoc Is Nothing Then
            _ErrorLogger.AddMessage("Unable to connect to Solid Edge, or an assembly file is not open")
            LabelStatus.Text = ""
            Return Nothing
        End If

        LabelStatus.Text = "Generating fastener stack assemblies"

        For Each TemplateName In {GetTopAssyTemplateName(), GetBottomAssyTemplateName()}

            If TemplateName = "" Then Continue For  ' Some configurations do not have a bottom stack assembly

            ' A blank TemplateName is valid.  Check that before this.
            If Not IO.File.Exists(TemplateName) Then
                _ErrorLogger.AddMessage($"Template file not found `{TemplateName}`")
                Return Nothing
            End If


            Dim tmpAssyFilename As String
            tmpAssyFilename = $"{IO.Path.GetDirectoryName(TemplateName)}"  '                                 c:\...\FastenerStackTemplates
            tmpAssyFilename = $"{tmpAssyFilename}\Temp"  '                                                   c:\...\FastenerStackTemplates\Temp
            tmpAssyFilename = $"{tmpAssyFilename}\tmp{IO.Path.GetFileNameWithoutExtension(TemplateName)}"  ' c:\...\FastenerStackTemplates\Temp\FastenerStackTop_F-FW
            tmpAssyFilename = $"{tmpAssyFilename}_{GetStackAssyFilesLastIdx() + 1:0000}"  '                  c:\...\FastenerStackTemplates\Temp\FastenerStackTop_F-FW_0024
            tmpAssyFilename = $"{tmpAssyFilename}.asm"  '                                                    c:\...\FastenerStackTemplates\Temp\FastenerStackTop_F-FW_0024.asm

            Dim tmpAsm As SolidEdgeAssembly.AssemblyDocument = Nothing
            If Me.FMain.ProcessTemplateInBackground Then
                tmpAsm = CType(FMain.SEApp.Documents.Open(TemplateName, 8), SolidEdgeAssembly.AssemblyDocument)
            Else
                tmpAsm = CType(Me.FMain.SEApp.Documents.Open(TemplateName), SolidEdgeAssembly.AssemblyDocument)
            End If
            FMain.SEApp.DoIdle()

            tmpAsm.SaveAs(tmpAssyFilename)
            FMain.SEApp.DoIdle()

            Outlist.Add(tmpAssyFilename)

            For Each Occurrence As SolidEdgeAssembly.Occurrence In tmpAsm.Occurrences
                Dim OccurrenceFilename As String = Occurrence.OccurrenceFileName
                Dim ReplacementFilename As String = ""

                Select Case IO.Path.GetFileName(OccurrenceFilename)
                    Case "F.par"
                        ReplacementFilename = Me.FastenerFilename
                    Case "FW.par"
                        ReplacementFilename = Me.FlatWasherFilename
                    Case "LW.par"
                        ReplacementFilename = Me.LockwasherFilename
                    Case "N.par"
                        ReplacementFilename = Me.NutFilename
                    Case Else
                        _ErrorLogger.AddMessage($"FastenerStack.PrepStackAssemblies unrecognized filename: '{IO.Path.GetFileName(OccurrenceFilename)}'")
                        LabelStatus.Text = ""
                        Return Nothing
                End Select

                LabelStatus.Text = $"Processing {IO.Path.GetFileName(ReplacementFilename)}"

                If FMain.FailedConstraintSuppress Then
                    tmpAsm.ReplaceComponents({Occurrence}, ReplacementFilename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementSuppress)
                ElseIf FMain.FailedConstraintAllow Then
                    tmpAsm.ReplaceComponents({Occurrence}, ReplacementFilename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementNone)
                Else
                    _ErrorLogger.AddMessage("Option not set for treatment of for failed constraints.  Set it on the Tree Search Options dialog.")
                    LabelStatus.Text = ""
                    Return Nothing
                End If

            Next

            tmpAsm.Save()
            FMain.SEApp.DoIdle()
            tmpAsm.Close()
            FMain.SEApp.DoIdle()

        Next

        LabelStatus.Text = ""

        Return Outlist
    End Function

    Private Function AddStackElementAndDisperse(Filename As String, _ErrorLogger As Logger) As Boolean
        Dim Success As Boolean = True

        AddHandler FMain.SEAppEvents.AfterCommandRun, AddressOf DISEApplicationEvents_AfterCommandRun
        FMain.SEApp.DoIdle()
        Me.TopMost = False
        System.Windows.Forms.Application.DoEvents()
        FMain.AsmDoc.Activate()
        FMain.SEApp.DoIdle()

        Dim Occurrences As SolidEdgeAssembly.Occurrences = FMain.AsmDoc.Occurrences
        Dim Occurrence As SolidEdgeAssembly.Occurrence
        Dim PreviousNumOccurrences As Integer = Occurrences.Count
        Dim TickCount As Integer = 0
        Dim TickCountMax As Integer = 30

        Dim HighlightSet As SolidEdgeFramework.HighlightSet

        AssembleCommandComplete = False

        Clipboard.Clear()
        Clipboard.SetText(Filename)
        Dim Paste = CType(SolidEdgeConstants.AssemblyCommandConstants.AssemblyEditPaste, SolidEdgeFramework.SolidEdgeCommandConstants)
        FMain.SEApp.StartCommand(Paste)

        LabelStatus.Text = $"Adding {IO.Path.GetFileName(Filename)}"

        ' Wait until the new occurrence shows up
        While Occurrences.Count = PreviousNumOccurrences
            Threading.Thread.Sleep(100)
            TickCount += 1
            If TickCount >= TickCountMax Then
                'LabelStatus.Text = "Paste timeout"
                _ErrorLogger.AddMessage("Add occurrence command timed out")
                Return False
            End If
        End While

        ' Get a reference to the new occurrence
        Occurrence = CType(Occurrences(PreviousNumOccurrences), SolidEdgeAssembly.Occurrence)

        FMain.AsmDoc.DisperseSubassembly(Occurrence, bAllOccurrences:=False)

        ' Get a reference to the first occurrence dispersed from the stack assembly
        Occurrence = CType(Occurrences(PreviousNumOccurrences), SolidEdgeAssembly.Occurrence)
        FMain.SEApp.ActiveSelectSet.RemoveAll()

        HighlightSet = FMain.AsmDoc.HighlightSets.Add
        'objApp.GetGlobalParameter(SolidEdgeFramework.ApplicationGlobalConstants.seApplicationGlobalColorSelected, objHLSet.Color)

        HighlightSet.AddItem(Occurrence)
        HighlightSet.Draw()
        FMain.SEApp.ActiveSelectSet.Add(HighlightSet)
        FMain.SEApp.ActiveSelectSet.RefreshDisplay()

        Threading.Thread.Sleep(750)
        HighlightSet.Delete()

        ' TODO Remove the occurrence ground constraint if present
        Dim Relations3d As SolidEdgeAssembly.Relations3d = CType(Occurrence.Relations3d, SolidEdgeAssembly.Relations3d)
        For i = 0 To Relations3d.Count - 1
            Dim Ground As SolidEdgeAssembly.GroundRelation3d = TryCast(Relations3d(i), SolidEdgeAssembly.GroundRelation3d)
            If Ground IsNot Nothing Then
                Ground.Delete()
                Exit For
            End If
        Next

        LabelStatus.Text = "Position stack as needed.  Press ESCAPE when done."

        ' Start the assemble command (CommandID 39002)
        FMain.SEApp.StartCommand(CType(39002, SolidEdgeFramework.SolidEdgeCommandConstants))

        TickCount = 0


        While Not AssembleCommandComplete
            Threading.Thread.Sleep(100)
            'TickCount += 1
            'If TickCount >= TickCountMax Then
            '    TickCount = 0
            '    If Not LabelStatus.Text = "Press the escape key once the part is constrained" Then
            '        LabelStatus.Text = "Press the escape key once the part is constrained"
            '    Else
            '        LabelStatus.Text = ""
            '    End If
            'End If
        End While

        Try
            HighlightSet.Delete()
        Catch ex As Exception
        End Try

        LabelStatus.Text = ""
        Return Success
    End Function

    Private Function CreateFastenerStackGroup(InitialNumOccurrences As Integer, _ErrorLogger As Logger) As Boolean
        Dim Success As Boolean = True
        Dim Occurrences As SolidEdgeAssembly.Occurrences = FMain.AsmDoc.Occurrences

        Dim NewOccurrenceList As New List(Of SolidEdgeAssembly.Occurrence)
        Dim NumFilesAdded As Integer = Occurrences.Count - InitialNumOccurrences

        If NumFilesAdded > 0 Then
            For i = InitialNumOccurrences To Occurrences.Count - 1
                NewOccurrenceList.Add(CType(Occurrences(i), SolidEdgeAssembly.Occurrence))
            Next

            Dim NewGroup As SolidEdgeAssembly.AssemblyGroup = FMain.AsmDoc.AssemblyGroups.Add(NumFilesAdded, NewOccurrenceList.ToArray)
            NewGroup.Name = $"FastenerStack {FMain.AsmDoc.AssemblyGroups.Count}"

            If FMain.AutoPattern Then
                ' This returns False if no pattern is found.  That is not an error.
                Dim tmpSuccess As Boolean = MaybePatternOccurrences(InitialNumOccurrences, NewGroup.Name, _ErrorLogger)
            End If

        Else
            Success = False
            _ErrorLogger.AddMessage("No new occurrences detected.  Unable to create a fastener stack assembly group.")
        End If

        Return Success
    End Function

    Private Function MaybePatternOccurrences(
        InitialNumOccurrences As Integer,
        FastenerStackName As String,
        _ErrorLogger As Logger
        ) As Boolean

        Dim Success As Boolean = True

        Dim Occurrences As SolidEdgeAssembly.Occurrences = FMain.AsmDoc.Occurrences

        Dim PrimaryOccurrence As SolidEdgeAssembly.Occurrence
        Dim PiggyBackOccurrences As New List(Of SolidEdgeAssembly.Occurrence)
        Dim NumFilesAdded As Integer = Occurrences.Count - InitialNumOccurrences

        If NumFilesAdded > 0 Then
            PrimaryOccurrence = CType(Occurrences(InitialNumOccurrences), SolidEdgeAssembly.Occurrence)

            For i = InitialNumOccurrences + 1 To Occurrences.Count - 1
                PiggyBackOccurrences.Add(CType(Occurrences(i), SolidEdgeAssembly.Occurrence))
            Next

            Success = FMain.MaybePatternOccurrence(PrimaryOccurrence, PiggyBackOccurrences, _ErrorLogger, FastenerStackName)
        Else
            Success = False
        End If


        Return Success
    End Function

    'Private Function AddStackToAssembly() As Dictionary(Of String, Integer)

    '    Dim NumAddedItems As New Dictionary(Of String, Integer)
    '    NumAddedItems("NumOccurrencesAdded") = 0
    '    NumAddedItems("NumTopSubOccurrencesAdded") = 0
    '    NumAddedItems("NumBottomSubOccurrencesAdded") = 0
    '    NumAddedItems("NumRelations3dAdded") = 0

    '    Dim Success As Boolean = True

    '    AddHandler FMain.SEAppEvents.AfterCommandRun, AddressOf FMain.DISEApplicationEvents_AfterCommandRun
    '    FMain.SEApp.DoIdle()
    '    Me.TopMost = False
    '    System.Windows.Forms.Application.DoEvents()
    '    FMain.AsmDoc.Activate()
    '    FMain.SEApp.DoIdle()

    '    Dim Occurrences As SolidEdgeAssembly.Occurrences = FMain.AsmDoc.Occurrences
    '    Dim StartingNumOccurrences As Integer = Occurrences.Count

    '    Dim Relations3d As SolidEdgeAssembly.Relations3d = FMain.AsmDoc.Relations3d
    '    Dim StartingNumRelations3d As Integer = Relations3d.Count

    '    Dim NumFilesAdded As Integer = 0

    '    For Each Filename As String In ({Me.TopFilename, Me.BottomFilename})
    '        If Filename = "" Then Continue For

    '        Dim IsTop As Boolean = False
    '        Dim IsBottom As Boolean = False

    '        If IO.Path.GetFileName(Filename).Contains("Top") Then IsTop = True
    '        If IO.Path.GetFileName(Filename).Contains("Bottom") Then IsBottom = True

    '        If Not (IsTop Or IsBottom) Then
    '            MsgBox($"FormFastenerStack.AddStackToAssembly: Filename error '{Filename}'", vbOKOnly, "Filename Error")
    '            Return Nothing
    '        End If

    '        Dim PreviousOccurrencesCount As Integer = Occurrences.Count
    '        Dim Occurrence As SolidEdgeAssembly.Occurrence = Nothing


    '        While Not FMain.AssemblyPasteComplete
    '            Threading.Thread.Sleep(100)
    '        End While

    '        Threading.Thread.Sleep(500)

    '        If Occurrences.Count > PreviousOccurrencesCount Then
    '            Occurrence = CType(Occurrences(Occurrences.Count - 1), SolidEdgeAssembly.Occurrence)
    '            If IsTop Then
    '                NumAddedItems("NumTopSubOccurrencesAdded") += Occurrence.SubOccurrences.Count
    '            Else
    '                NumAddedItems("NumBottomSubOccurrencesAdded") += Occurrence.SubOccurrences.Count
    '            End If
    '        End If

    '    Next

    '    RemoveHandler FMain.SEAppEvents.AfterCommandRun, AddressOf FMain.DISEApplicationEvents_AfterCommandRun

    '    NumAddedItems("NumOccurrencesAdded") = Occurrences.Count - StartingNumOccurrences
    '    NumAddedItems("NumRelations3dAdded") = Relations3d.Count - StartingNumRelations3d

    '    Return NumAddedItems

    'End Function

    'Private Function Disperse(NumAddedItems As Dictionary(Of String, Integer)) As Boolean
    '    Dim Success As Boolean = True

    '    Dim NumOccurrencesAdded = NumAddedItems("NumOccurrencesAdded")
    '    Dim NumTopSubOccurrencesAdded = NumAddedItems("NumTopSubOccurrencesAdded")
    '    Dim NumBottomSubOccurrencesAdded = NumAddedItems("NumBottomSubOccurrencesAdded")
    '    Dim NumRelations3dAdded = NumAddedItems("NumRelations3dAdded")

    '    ' The stack subassemblies have not been dispersed.  When they are, 
    '    ' the assembly relationships will be deleted.  If the first part in the
    '    ' subassembly was grounded, it will be grounded in the assembly.
    '    ' If not, no new relationships will be added.
    '    ' We need to capture the relationships from the subassembly and reapply
    '    ' to the dipersed parts in the assembly.

    '    Dim Relations3d As SolidEdgeAssembly.Relations3d = FMain.AsmDoc.Relations3d
    '    'Dim Relations3dList As New List(Of Object)
    '    Dim AxialRelation3dNeededInfo As New List(Of Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean))
    '    Dim PlanarRelation3dNeededInfo As New List(Of Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean))

    '    For i = Relations3d.Count - NumRelations3dAdded To Relations3d.Count - 1

    '        Dim AxialRelation3d As SolidEdgeAssembly.AxialRelation3d = TryCast(Relations3d(i), SolidEdgeAssembly.AxialRelation3d)
    '        If AxialRelation3d IsNot Nothing Then
    '            AxialRelation3dNeededInfo.Add(ExtractAxialRelation3dInfo(AxialRelation3d))
    '        End If

    '        Dim PlanarRelation3d As SolidEdgeAssembly.PlanarRelation3d = TryCast(Relations3d(i), SolidEdgeAssembly.PlanarRelation3d)
    '        If PlanarRelation3d IsNot Nothing Then
    '            PlanarRelation3dNeededInfo.Add(ExtractPlanarRelation3dInfo(PlanarRelation3d))
    '        End If

    '    Next

    '    Dim Occurrences As SolidEdgeAssembly.Occurrences = FMain.AsmDoc.Occurrences

    '    Dim IdxTopAssy As Integer = Occurrences.Count - 2

    '    FMain.AsmDoc.DisperseSubassembly(Occurrences(IdxTopAssy), bAllOccurrences:=False)
    '    FMain.AsmDoc.DisperseSubassembly(Occurrences(IdxTopAssy), bAllOccurrences:=False) ' Not a typo.  TopAssy occurence was removed.

    '    Dim IdxTopFirstOccurrence = Occurrences.Count - (NumTopSubOccurrencesAdded + NumBottomSubOccurrencesAdded)
    '    Dim IdxBottomFirstOccurrence = Occurrences.Count - NumBottomSubOccurrencesAdded

    '    Dim Face1Ref As SolidEdgeAssembly.TopologyReference
    '    Dim tmpOccurrence As SolidEdgeAssembly.Occurrence = CType(Occurrences(IdxTopFirstOccurrence), SolidEdgeAssembly.Occurrence)
    '    Face1Ref = CType(FMain.AsmDoc.CreateReference(tmpOccurrence, AxialRelation3dNeededInfo.Item(0)), SolidEdgeAssembly.TopologyReference)

    '    Relations3d.AddAxial(Face1Ref, AxialRelation3dNeededInfo.Item(1), NormalsAligned:=True)

    '    Dim NumFilesAdded = NumTopSubOccurrencesAdded + NumBottomSubOccurrencesAdded
    '    Dim NewOccurrenceList As New List(Of SolidEdgeAssembly.Occurrence)

    '    ' Single files do not need to be added to a group
    '    If NumFilesAdded > 1 Then
    '        For i = 0 To NumFilesAdded - 1
    '            ' Need to add in reverse order
    '            NewOccurrenceList.Add(CType(Occurrences(Occurrences.Count - 1 - i), SolidEdgeAssembly.Occurrence))
    '        Next
    '        Dim NewGroup As SolidEdgeAssembly.AssemblyGroup = FMain.AsmDoc.AssemblyGroups.Add(NumFilesAdded, NewOccurrenceList.ToArray)
    '        NewGroup.Name = $"FastenerStack {FMain.AsmDoc.AssemblyGroups.Count}"
    '    End If

    '    Return Success
    'End Function

    'Private Function ExtractAxialRelation3dInfo(
    '    AxialRelation3d As SolidEdgeAssembly.AxialRelation3d
    '    ) As Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean)

    '    'https://docs.sw.siemens.com/documentation/external/PL20220830878154140/en-US/api/content/SolidEdgeAssembly~Relations3d~AddAxial.html
    '    'Public Function AddAxial( _
    '    '   ByVal Axis1 As Object, _
    '    '   ByVal Axis2 As Object, _
    '    '   ByVal NormalsAligned As Boolean _
    '    ') As AxialRelation3d

    '    Dim IsTopoRef1 As Boolean
    '    Dim IsTopoRef2 As Boolean
    '    Dim Element1 As SolidEdgeAssembly.TopologyReference = CType(AxialRelation3d.GetElement1(IsTopoRef1), SolidEdgeAssembly.TopologyReference)
    '    Dim Element2 As SolidEdgeAssembly.TopologyReference = CType(AxialRelation3d.GetElement2(IsTopoRef2), SolidEdgeAssembly.TopologyReference)

    '    Dim Face1 As SolidEdgeGeometry.Face = TryCast(Element1.Object, SolidEdgeGeometry.Face)
    '    Dim Face2 As SolidEdgeGeometry.Face = TryCast(Element2.Object, SolidEdgeGeometry.Face)

    '    Dim Occurrence2 As SolidEdgeAssembly.Occurrence = AxialRelation3d.Occurrence2

    '    Dim FaceRef2 As SolidEdgeAssembly.TopologyReference = CType(FMain.AsmDoc.CreateReference(Occurrence2, Face2), SolidEdgeAssembly.TopologyReference)

    '    Dim OutTuple As Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean) = Nothing
    '    OutTuple = Tuple.Create(Face1, FaceRef2, False)

    '    Return OutTuple
    'End Function

    'Private Function ExtractPlanarRelation3dInfo(
    '    PlanarRelation3d As SolidEdgeAssembly.PlanarRelation3d
    '    ) As Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean)

    '    'https://docs.sw.siemens.com/documentation/external/PL20220830878154140/en-US/api/content/SolidEdgeAssembly~Relations3d~AddPlanar.html
    '    'Public Function AddPlanar( _
    '    '   ByVal Plane1 As Object, _
    '    '   ByVal Plane2 As Object, _
    '    '   ByVal NormalsAligned As Boolean, _
    '    '   ByRef ConstrainingPoint1() As Double, _
    '    '   ByRef ConstrainingPoint2() As Double _
    '    ') As PlanarRelation3d
    '    ' For a Mate, NormalsAligned = True (even if that is backwards)

    '    Dim IsTopoRef1 As Boolean
    '    Dim IsTopoRef2 As Boolean
    '    Dim Element1 As SolidEdgeAssembly.TopologyReference = CType(PlanarRelation3d.GetElement1(IsTopoRef1), SolidEdgeAssembly.TopologyReference)
    '    Dim Element2 As SolidEdgeAssembly.TopologyReference = CType(PlanarRelation3d.GetElement1(IsTopoRef2), SolidEdgeAssembly.TopologyReference)

    '    Dim Face1 As SolidEdgeGeometry.Face = TryCast(Element1.Object, SolidEdgeGeometry.Face)
    '    Dim Face2 As SolidEdgeGeometry.Face = TryCast(Element2.Object, SolidEdgeGeometry.Face)

    '    Dim Occurrence2 As SolidEdgeAssembly.Occurrence = PlanarRelation3d.Occurrence2

    '    Dim FaceRef2 As SolidEdgeAssembly.TopologyReference = CType(FMain.AsmDoc.CreateReference(Occurrence2, Face2), SolidEdgeAssembly.TopologyReference)

    '    Dim OutTuple As Tuple(Of SolidEdgeGeometry.Face, SolidEdgeAssembly.TopologyReference, Boolean) = Nothing
    '    OutTuple = Tuple.Create(Face1, FaceRef2, False)

    '    Return OutTuple

    'End Function

    Private Function GetTopAssyTemplateName() As String

        RemoveUnusedStackAssyFiles()

        'Dim LastIdx As Integer = GetStackAssyFilesLastIdx()

        'Dim Filename As String = ""

        'Filename = Me.StackConfiguration.ToString.Split("_CO_")(0)
        'Filename = Filename.Replace("_", "-")
        'Filename = $"FastenerStackTop_{Filename}_{LastIdx + 1:0000}.asm"
        'Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\Temp\{Filename}"

        'Return Filename

        Dim Filename As String = ""

        Filename = Me.StackConfiguration.ToString.Split("_CO_")(0)
        Filename = Filename.Replace("_", "-")
        Filename = $"FastenerStackTop_{Filename}.asm"
        Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\{Filename}"

        Return Filename

    End Function

    Private Function GetBottomAssyTemplateName() As String

        RemoveUnusedStackAssyFiles()
        'Dim LastIdx As Integer = GetStackAssyFilesLastIdx()

        'Dim Filename As String = ""

        'Filename = Me.StackConfiguration.ToString.Split("_CO_")(1)

        '' Thru or blind threaded holes don't have any bottom components
        'If Filename.Contains("TB") Or Filename.Contains("TT") Then Return ""

        'Filename = Filename.Replace("_", "-")
        'Filename = $"FastenerStackBottom_{Filename}_{LastIdx + 1:0000}.asm"
        'Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\Temp\{Filename}"

        'Return Filename

        Dim Filename As String = ""

        Filename = Me.StackConfiguration.ToString.Split("_CO_")(1)

        ' Thru or blind threaded holes don't have any bottom components
        If Filename.Contains("TB") Or Filename.Contains("TT") Then Return ""

        Filename = Filename.Replace("_", "-")
        Filename = $"FastenerStackBottom_{Filename}.asm"
        Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\{Filename}"

        Return Filename

    End Function

    Private Sub RemoveUnusedStackAssyFiles()
        Dim Directory As String = $"{FMain.TemplateDirectory}\FastenerStackTemplates\Temp"

        If IO.Directory.Exists(Directory) Then
            Dim FoundFiles As IReadOnlyCollection(Of String) = Nothing

            FoundFiles = FileIO.FileSystem.GetFiles(Directory,
                                     FileIO.SearchOption.SearchTopLevelOnly,
                                     {"*.asm", "*.cfg"})

            If FoundFiles IsNot Nothing AndAlso FoundFiles.Count > 0 Then
                For Each FoundFile As String In FoundFiles
                    Try
                        IO.File.Delete(FoundFile)
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If

    End Sub

    Private Function GetStackAssyFilesLastIdx() As Integer
        ' Examples
        ' tmpFastenerStackBottom_FW-LW-N_0024.asm
        ' tmpFastenerStackTop_F-FW_0001.asm

        Dim LastIdx As Integer = 0

        Dim Directory As String = $"{FMain.TemplateDirectory}\FastenerStackTemplates\Temp"
        Dim FoundFiles As IReadOnlyCollection(Of String) = Nothing

        FoundFiles = FileIO.FileSystem.GetFiles(Directory,
                                     FileIO.SearchOption.SearchTopLevelOnly,
                                     {"*.asm"})

        If FoundFiles IsNot Nothing AndAlso FoundFiles.Count > 0 Then
            For Each FoundFile As String In FoundFiles
                FoundFile = FoundFile.Replace(".asm", "")  ' tmpFastenerStackBottom_FW-LW-N_0024.asm -> tmpFastenerStackBottom_FW-LW-N_0024
                Dim SplitList As List(Of String) = FoundFile.Split("_").ToList  ' tmpFastenerStackBottom_FW-LW-N_0024 -> tmpFastenerStackBottom, FW-LW-N, 0024
                Dim LastIdxString = SplitList(SplitList.Count - 1)  ' 0024
                Try
                    Dim tmpLastIdx As Integer = CInt(LastIdxString)
                    If tmpLastIdx > LastIdx Then
                        LastIdx = tmpLastIdx
                    End If
                Catch ex As Exception
                End Try
            Next
        End If


        Return LastIdx
    End Function

    Public Function GetRelatedFilenames() As Boolean

        ' Traverses the Xml tree to find a flat washer, lock washer and nut
        ' The SelectedNodeFullPath will be a fastener length node
        ' Examples for SE2024
        ' Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\HHCS\Size_0.250-20\Length_0.500
        ' Solid_Edge_Storekeeper\Ansi_Fasteners_Stainless\HHCS\Size_0.250-20\Length_0.500
        ' Examples for SE2019
        ' Solid_Edge_Storekeeper\ISO_Screws_-_Steel\ISO_4014_-_Hexagon_head_bolts_-_normal_pitch\Size_M5\L_30

        Dim Proceed As Boolean = True
        Dim ErrorMessages As New List(Of String)

        Dim SelectedNodeFullPath As String = FMain.SelectedNodeFullPath  ' Saving to reset back

        Me.TreeviewFastenerFullPath = SelectedNodeFullPath
        'Dim tmpSelectedNodeFullPath As String = FMain.SpaceToUnderscore(SelectedNodeFullPath)
        Dim FastenerNodeNameList = SelectedNodeFullPath.Split("\")
        For i = 0 To FastenerNodeNameList.Count - 1
            FastenerNodeNameList(i) = FMain.StringToXml(FastenerNodeNameList(i))
        Next

        Dim XmlDoc As System.Xml.XmlDocument = FMain.XmlDoc
        Dim ParentNode As XmlNode


        ' ###### FASTENER SIZE NODE ######

        Dim FastenerPath As String = ""
        ' The fastener size node will be one level up from the selected length node
        For i = 0 To FastenerNodeNameList.Count - 1 - 1
            If i = 0 Then
                FastenerPath = FastenerNodeNameList(i) '                      Solid_Edge_Storekeeper
            Else
                FastenerPath = $"{FastenerPath}\{FastenerNodeNameList(i)}"  ' Solid_Edge_Storekeeper\node_name\node_name\...
            End If
        Next

        Dim NominalDiameter As Double
        Dim ThreadDescription As String
        Dim MatchingNode As XmlNode

        ' ###### FASTENER NOMINAL DIAMETER AND THREAD DESCRIPTION ######

        ParentNode = FMain.XmlNodeFromPath(FastenerPath)
        NominalDiameter = GetNominalDiameter(ParentNode)
        If NominalDiameter = -1 Then
            Proceed = False
            ErrorMessages.Add("Fastener nominal diameter not found")
        End If
        ThreadDescription = GetThreadDescription(ParentNode)
        If ThreadDescription = Nothing Then
            Proceed = False
            ErrorMessages.Add("Fastener thread description not found")
        End If


        ' ###### FLAT WASHER FILENAME ######

        Me.FlatWasherFilename = "Flat washer not found"
        Me.TreeviewFlatWasherFullPath = ""

        For Each FlatWasherSearchPath As String In Me.FlatWasherSearchPaths
            ' SE2024 ..\..\..\Washer_Flat
            ' SE2019 ..\..\..\..\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series

            Dim tmpPathList As List(Of String) = FlatWasherSearchPath.Split(CChar("\")).ToList
            Dim FlatWasherFullPath As String = ""

            ' ###### Find the number of '..' in the search path ######
            Dim n As Integer = 0 ' the number of '..' in the path
            For i = 0 To tmpPathList.Count - 1
                If tmpPathList(i) = ".." Then n += 1
            Next

            ' ###### Populate the beginning from the fastener path ######
            ' Examples
            ' Fastener path: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\HHCS\Size_0.250-20\Length_0.500
            ' Search path:   ..\..\..\Washer_Flat
            ' Output:        Solid_Edge_Storekeeper\Ansi_Fasteners_Steel
            For i = 0 To FastenerNodeNameList.Count - 1 - n
                If i = 0 Then
                    FlatWasherFullPath = FastenerNodeNameList(i)
                Else
                    FlatWasherFullPath = $"{FlatWasherFullPath}\{FastenerNodeNameList(i)}"
                End If
            Next

            ' ###### Populate the end from the search path ######
            ' Output: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\Washer_Flat
            For i = 0 To tmpPathList.Count - 1
                If Not tmpPathList(i) = ".." Then
                    FlatWasherFullPath = $"{FlatWasherFullPath}\{tmpPathList(i)}"
                End If
            Next

            ' ###### Find the FlatWasher with the same NominalDiameter as the Fastener ######
            ParentNode = FMain.XmlNodeFromPath(FlatWasherFullPath)
            MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription:=Nothing)

            If MatchingNode IsNot Nothing Then
                FlatWasherThickness = GetThickness(MatchingNode)
                If FlatWasherThickness = -1 Then
                    Proceed = False
                    ErrorMessages.Add("Flat washer thickness variable not found")
                End If
                FlatWasherFullPath = $"{FlatWasherFullPath}\{MatchingNode.Name}"
                Me.TreeviewFlatWasherFullPath = FlatWasherFullPath
                FMain.SelectedNodeFullPath = FlatWasherFullPath
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger:=Me.FileLogger))
                Me.FlatWasherFilename = FMain.GetFilenameFormula(DefaultExtension:=DefaultExtension, Me.FileLogger)
                Exit For
            End If

        Next


        ' ###### LOCKWASHER FILENAME ######

        Me.LockwasherFilename = "Lock washer not found"
        Me.TreeviewLockwasherFullPath = ""

        For Each LockWasherSearchPath As String In Me.LockWasherSearchPaths
            ' SE2024 ..\..\..\Washer_Lock
            ' SE2019 NA 

            Dim tmpPathList As List(Of String) = LockWasherSearchPath.Split(CChar("\")).ToList
            Dim LockWasherFullPath As String = ""

            ' ###### Find the number of '..' in the search path ######
            Dim n As Integer = 0 ' the number of '..' in the path
            For i = 0 To tmpPathList.Count - 1
                If tmpPathList(i) = ".." Then n += 1
            Next

            ' ###### Populate the beginning from the FASTENER path ######

            ' Example
            ' Fastener path: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\HHCS\Size_0.250-20\Length_0.500
            ' Search path:   ..\..\..\Washer_Flat
            ' Output:        Solid_Edge_Storekeeper\Ansi_Fasteners_Steel

            ' Example
            ' Fastener path: Solid_Edge_Storekeeper\ISO_SCREWS_-_Steel\ISO_4014_-_Hexagon_head_bolts_-_normal_pitch\Size_M5\Length_25
            ' Search path:   ..\..\..\..\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series
            ' Output:        Solid_Edge_Storekeeper

            For i = 0 To FastenerNodeNameList.Count - 1 - n
                If i = 0 Then
                    LockWasherFullPath = FastenerNodeNameList(i)
                Else
                    LockWasherFullPath = $"{LockWasherFullPath}\{FastenerNodeNameList(i)}"
                End If
            Next

            ' ###### Populate the end from the SEARCH path ######
            ' Output: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\Washer_Flat
            ' Output: Solid_Edge_Storekeeper\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series

            For i = 0 To tmpPathList.Count - 1
                If Not tmpPathList(i) = ".." Then
                    LockWasherFullPath = $"{LockWasherFullPath}\{tmpPathList(i)}"
                End If
            Next

            ' ###### Find the LockWasher with the same NominalDiameter as the Fastener ######
            ParentNode = FMain.XmlNodeFromPath(LockWasherFullPath)
            MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription:=Nothing)

            If MatchingNode IsNot Nothing Then
                LockWasherThickness = GetThickness(MatchingNode)
                If LockWasherThickness = -1 Then
                    Proceed = False
                    ErrorMessages.Add("Lock washer thickness variable not found")
                End If
                LockWasherFullPath = $"{LockWasherFullPath}\{MatchingNode.Name}"
                Me.TreeviewLockwasherFullPath = LockWasherFullPath
                FMain.SelectedNodeFullPath = LockWasherFullPath
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger:=Me.FileLogger))
                LockwasherFilename = FMain.GetFilenameFormula(DefaultExtension:=DefaultExtension, Me.FileLogger)
                Exit For
            End If

        Next


        ' ###### NUT FILENAME ######

        Me.NutFilename = "Nut not found"
        Me.TreeviewNutFullPath = ""

        For Each NutSearchPath As String In Me.NutSearchPaths
            ' SE2024 ..\..\..\Washer_Flat
            ' SE2019 ..\..\..\..\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series

            Dim tmpPathList As List(Of String) = NutSearchPath.Split(CChar("\")).ToList
            Dim NutFullPath As String = ""

            ' ###### Find the number of '..' in the search path ######
            Dim n As Integer = 0 ' the number of '..' in the path
            For i = 0 To tmpPathList.Count - 1
                If tmpPathList(i) = ".." Then n += 1
            Next

            ' ###### Populate the beginning from the fastener path ######
            ' Examples
            ' Fastener path: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\HHCS\Size_0.250-20\Length_0.500
            ' Search path:   ..\..\..\Washer_Flat
            ' Output:        Solid_Edge_Storekeeper\Ansi_Fasteners_Steel
            For i = 0 To FastenerNodeNameList.Count - 1 - n
                If i = 0 Then
                    NutFullPath = FastenerNodeNameList(i)
                Else
                    NutFullPath = $"{NutFullPath}\{FastenerNodeNameList(i)}"
                End If
            Next

            ' ###### Populate the end from the search path ######
            ' Output: Solid_Edge_Storekeeper\Ansi_Fasteners_Steel\Washer_Flat
            For i = 0 To tmpPathList.Count - 1
                If Not tmpPathList(i) = ".." Then
                    NutFullPath = $"{NutFullPath}\{tmpPathList(i)}"
                End If
            Next

            ' ###### Find the Nut with the same NominalDiameter and ThreadDescription as the Fastener ######
            ParentNode = FMain.XmlNodeFromPath(NutFullPath)
            MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription)

            If MatchingNode IsNot Nothing Then
                NutThickness = GetThickness(MatchingNode)
                If NutThickness = -1 Then
                    Proceed = False
                    ErrorMessages.Add("Nut thickness variable not found")
                End If
                NutFullPath = $"{NutFullPath}\{MatchingNode.Name}"
                Me.TreeviewNutFullPath = NutFullPath
                FMain.SelectedNodeFullPath = NutFullPath
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger:=Me.FileLogger))
                NutFilename = FMain.GetFilenameFormula(DefaultExtension:=DefaultExtension, Me.FileLogger)
                Exit For
            End If

        Next


        ' ###### Reset the selected node back to the fastener ######

        FMain.SelectedNodeFullPath = SelectedNodeFullPath

        If Not Proceed Then
            Dim s As String = $"Please resolve the following before continuing{vbCrLf}{vbCrLf}"
            Dim Indent As String = "    "
            For Each s1 As String In ErrorMessages
                s = $"{s}{Indent}{s1}{vbCrLf}"
            Next
            MsgBox(s, vbOKOnly, "Components not found")
        End If

        Return Proceed

    End Function

    Private Function GetThickness(ParentNode As XmlNode) As Double
        Dim Value As Double = -1

        Dim UC As New UtilsCommon

        If ParentNode.HasChildNodes Then
            For Each ChildNode As XmlNode In ParentNode.ChildNodes
                If ChildNode.Name = "Thickness" Then
                    ''https://stackoverflow.com/questions/14513468/detect-decimal-separator
                    'Dim a As Char = CChar(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    'If a = CChar(".") Then
                    '    Value = CDbl(ChildNode.InnerText.Replace(",", "."))
                    'Else
                    '    Value = CDbl(ChildNode.InnerText.Replace(".", ","))
                    'End If
                    Value = CDbl(UC.FixLocaleDecimal(ChildNode.InnerText))
                    Exit For
                End If
            Next
        End If

        Return Value
    End Function

    Private Function GetCorrectLengthFastenerFullPath(
        CurrentFastenerFullPath As String,
        LengthMin As Double,
        LengthMax As Double
        ) As String

        Dim NewFastenerFullPath As String = Nothing

        Dim UC As New UtilsCommon

        Dim tmpNodeNameList As List(Of String) = CurrentFastenerFullPath.Split(CChar("\")).ToList
        Dim tmpXmlNodePath As String = ""
        For i = 0 To tmpNodeNameList.Count - 1
            If i = 0 Then
                tmpXmlNodePath = FMain.StringToXml(tmpNodeNameList(i))
            Else
                tmpXmlNodePath = $"{tmpXmlNodePath}\{FMain.StringToXml(tmpNodeNameList(i))}"
            End If
        Next

        Dim SizeNode As XmlNode = FMain.XmlNodeFromPath(tmpXmlNodePath)

        SizeNode = SizeNode.ParentNode

        Dim Node As XmlNode = Nothing
        Dim tmpLength As Double = 0

        If SizeNode.HasChildNodes Then
            For Each LengthNode As XmlNode In SizeNode
                If LengthNode.Name.Contains("Length_") Then
                    tmpLength = CDbl(UC.FixLocaleDecimal(LengthNode.InnerText))
                    If tmpLength >= LengthMin And tmpLength <= LengthMax Then
                        Node = LengthNode
                        Exit For
                    End If
                End If
            Next
        End If

        If Node IsNot Nothing Then NewFastenerFullPath = FMain.PathFromXmlNode(Node)

        Return NewFastenerFullPath
    End Function

    Private Function GetMatchingNode(
        CategoryNode As XmlNode,
        NominalDiameter As Double,
        ThreadDescription As String
        ) As XmlNode

        ' CategoryNode is the parent of the size nodes for the item in question

        ' Set ThreadDescription to Nothing for washers

        Dim Node As XmlNode = Nothing
        Dim tmpNominalDiameter As Double = -1
        Dim tmpThreadDescription As String = ""

        Dim UC As New UtilsCommon

        If CategoryNode.HasChildNodes Then
            For Each SizeNode As XmlNode In CategoryNode.ChildNodes
                If SizeNode.HasChildNodes Then
                    For Each ChildNode As XmlNode In SizeNode.ChildNodes
                        If ChildNode.Name = "NominalDiameter" Then
                            tmpNominalDiameter = CDbl(UC.FixLocaleDecimal(ChildNode.InnerText))
                        End If
                        If ChildNode.Name = "ThreadDescription" Then
                            tmpThreadDescription = ChildNode.InnerText
                        End If
                    Next
                    If tmpNominalDiameter = NominalDiameter Then
                        If ThreadDescription IsNot Nothing Then
                            If tmpThreadDescription = ThreadDescription Then
                                Node = SizeNode
                                Exit For
                            End If
                        Else
                            Node = SizeNode
                            Exit For
                        End If
                    End If
                End If

            Next

        End If

        Return Node
    End Function

    Private Function GetNominalDiameter(ParentNode As XmlNode) As Double
        Dim Value As Double = -1

        Dim UC As New UtilsCommon

        If ParentNode.HasChildNodes Then
            For Each ChildNode As XmlNode In ParentNode.ChildNodes
                If ChildNode.Name = "NominalDiameter" Then
                    Value = CDbl(UC.FixLocaleDecimal(ChildNode.InnerText))
                    Exit For
                End If
            Next
        End If

        Return Value
    End Function

    Private Function GetThreadDescription(ParentNode As XmlNode) As String
        Dim ThreadDescription As String = Nothing

        If ParentNode.HasChildNodes Then
            For Each ChildNode As XmlNode In ParentNode.ChildNodes
                If ChildNode.Name = "ThreadDescription" Then
                    ThreadDescription = ChildNode.InnerText
                    Exit For
                End If
            Next
        End If

        Return ThreadDescription
    End Function

    Private Sub SetFastenerMinMaxLength()

        Dim UC As New UtilsCommon

        For Each V As String In {Me.ClampedThickness, Me.ThreadEngagementMin, Me.ThreadDepth, Me.ExtensionMin}
            Try
                Dim tmpV = CDbl(UC.FixLocaleDecimal(V))
            Catch ex As Exception
                Exit Sub
            End Try
        Next

        Dim tmpClampedThickness As Double = CDbl(UC.FixLocaleDecimal(Me.ClampedThickness))
        Dim tmpThreadEngagementMin As Double = CDbl(UC.FixLocaleDecimal(Me.ThreadEngagementMin))
        Dim tmpThreadDepth As Double = CDbl(UC.FixLocaleDecimal(Me.ThreadDepth))
        Dim tmpExtensionMin As Double = CDbl(UC.FixLocaleDecimal(Me.ExtensionMin))

        Select Case Me.StackConfiguration
            Case StackConfigurationConstants.F_CO_N
                Me.FastenerMinLength = tmpClampedThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_FW_N
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_LW_N
                Me.FastenerMinLength = tmpClampedThickness + Me.LockWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_FW_LW_N
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_FW_CO_N
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_FW_N
                Me.FastenerMinLength = tmpClampedThickness + 2 * Me.FlatWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_LW_N
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_FW_LW_N
                Me.FastenerMinLength = tmpClampedThickness + 2 * Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_CO_TT
                Me.FastenerMinLength = tmpClampedThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_TT
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_LW_CO_TT
                Me.FastenerMinLength = tmpClampedThickness + Me.LockWasherThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_LW_FW_CO_TT
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + Me.LockWasherThickness + tmpExtensionMin
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_CO_TB
                Me.FastenerMinLength = tmpClampedThickness + tmpThreadEngagementMin
                Me.FastenerMaxLength = tmpClampedThickness + tmpThreadDepth
            Case StackConfigurationConstants.F_FW_CO_TB
                Me.FastenerMinLength = tmpClampedThickness + Me.FlatWasherThickness + tmpThreadEngagementMin
                Me.FastenerMaxLength = tmpClampedThickness + Me.FlatWasherThickness + tmpThreadDepth
            Case StackConfigurationConstants.F_LW_CO_TB
                Me.FastenerMinLength = tmpClampedThickness + Me.LockWasherThickness + tmpThreadEngagementMin
                Me.FastenerMaxLength = tmpClampedThickness + Me.LockWasherThickness + tmpThreadDepth
            Case StackConfigurationConstants.F_LW_FW_CO_TB
                Me.FastenerMinLength = tmpClampedThickness + Me.LockWasherThickness + Me.FlatWasherThickness + tmpThreadEngagementMin
                Me.FastenerMaxLength = tmpClampedThickness + Me.LockWasherThickness + Me.FlatWasherThickness + tmpThreadDepth
        End Select
    End Sub

    Private Sub UpdateLabelsWithUnits()
        LabelClampedThickness.Text = $"Clamped thickness ({Me.Units})"
        LabelThreadEngagementMin.Text = $"Minimum thread engagement ({Me.Units})"
        LabelThreadDepth.Text = $"Thread depth ({Me.Units})"
        LabelExtensionMin.Text = $"Minimum extension ({Me.Units})"
    End Sub

    Public Sub UpdateForm()

        ' Hide all the option labels/buttons, then selectively show based on configuration
        HideOptionControls()

        Select Case Me.StackConfiguration

        ' #### Top No Flat Washer

            Case StackConfigurationConstants.F_CO_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_N

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_N

                LabelBottomFlatWasher.Visible = True
                'ButtonPasteBottomFlatWasher.Visible = True
                'ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_LW_N

                LabelBottomLockwasher.Visible = True
                'ButtonPasteBottomLockwasher.Visible = True
                'ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_LW_N

                LabelBottomLockwasher.Visible = True
                'ButtonPasteBottomLockwasher.Visible = True
                'ButtonLockBottomLockwasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                'ButtonPasteBottomFlatWasher.Visible = True
                'ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

        ' #### Top Flat Washer ####

            Case StackConfigurationConstants.F_FW_CO_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_N

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_N

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                'ButtonPasteBottomFlatWasher.Visible = True
                'ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_LW_N

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelBottomLockwasher.Visible = True
                'ButtonPasteBottomLockwasher.Visible = True
                'ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_LW_N

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                'ButtonPasteBottomFlatWasher.Visible = True
                'ButtonLockBottomFlatWasher.Visible = True

                LabelBottomLockwasher.Visible = True
                'ButtonPasteBottomLockwasher.Visible = True
                'ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                'ButtonPasteBottomNut.Visible = True
                'ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

        ' #### Thread Thru ####

            Case StackConfigurationConstants.F_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TT

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TT

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TT

                LabelTopLockwasher.Visible = True
                'ButtonPasteTopLockwasher.Visible = True
                'ButtonLockTopLockwasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TT

                LabelTopLockwasher.Visible = True
                'ButtonPasteTopLockwasher.Visible = True
                'ButtonLockTopLockwasher.Visible = True

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                'ButtonLockExtensionMin.Visible = True


        ' #### Thread Blind ####

            Case StackConfigurationConstants.F_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TB

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                'ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                'ButtonLockThreadDepth.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TB

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                'ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                'ButtonLockThreadDepth.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TB

                LabelTopLockwasher.Visible = True
                'ButtonPasteTopLockwasher.Visible = True
                'ButtonLockTopLockwasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                'ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                'ButtonLockThreadDepth.Visible = True


            Case StackConfigurationConstants.F_LW_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TB

                LabelTopLockwasher.Visible = True
                'ButtonPasteTopLockwasher.Visible = True
                'ButtonLockTopLockwasher.Visible = True

                LabelTopFlatWasher.Visible = True
                'ButtonPasteTopFlatWasher.Visible = True
                'ButtonLockTopFlatWasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                'ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                'ButtonLockThreadDepth.Visible = True



        End Select
    End Sub

    Public Sub HideOptionControls()
        LabelTopFlatWasher.Visible = False
        'ButtonPasteTopFlatWasher.Visible = False
        'ButtonLockTopFlatWasher.Visible = False

        LabelTopLockwasher.Visible = False
        'ButtonPasteTopLockwasher.Visible = False
        'ButtonLockTopLockwasher.Visible = False

        LabelThreadEngagementMin.Visible = False
        TextBoxThreadEngagementMin.Visible = False
        'ButtonLockThreadEngagementMin.Visible = False

        LabelThreadDepth.Visible = False
        TextBoxThreadDepth.Visible = False
        'ButtonLockThreadDepth.Visible = False

        LabelBottomFlatWasher.Visible = False
        'ButtonPasteBottomFlatWasher.Visible = False
        'ButtonLockBottomFlatWasher.Visible = False

        LabelBottomLockwasher.Visible = False
        'ButtonPasteBottomLockwasher.Visible = False
        'ButtonLockBottomLockwasher.Visible = False

        LabelBottomNut.Visible = False
        'ButtonPasteBottomNut.Visible = False
        'ButtonLockBottomNut.Visible = False

        LabelExtensionMin.Visible = False
        TextBoxExtensionMin.Visible = False
        'ButtonLockExtensionMin.Visible = False


    End Sub

    Private Sub LabelTopFastener_Click(sender As Object, e As EventArgs) Handles LabelTopFastener.Click

    End Sub

    Private Sub LabelStackConfiguration_Click(sender As Object, e As EventArgs) Handles LabelStackConfiguration.Click
        ButtonStackConfiguration_Click(sender, e)
    End Sub

    Private Sub ButtonStackConfiguration_Click(sender As Object, e As EventArgs) Handles ButtonStackConfiguration.Click
        Me.TopMost = False

        Dim FSS As New FormStackConfiguration(Me.FMain)
        Dim Result = FSS.ShowDialog()

        If Result = DialogResult.OK Then
            Me.StackConfiguration = CType(FSS.StackConfiguration, StackConfigurationConstants)
        End If

        Me.TopMost = True
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Dim UP As New UtilsPreferences
        UP.SaveFormFastenerStackSettings(Me)
        Me.Dispose()
    End Sub


    Private Sub FormFastenerStack_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Startup()

    End Sub

    Private Sub TextBoxClampedThickness_TextChanged(sender As Object, e As EventArgs) Handles TextBoxClampedThickness.TextChanged
        Me.ClampedThickness = TextBoxClampedThickness.Text
    End Sub

    Private Sub TextBoxThreadEngagementMin_TextChanged(sender As Object, e As EventArgs) Handles TextBoxThreadEngagementMin.TextChanged
        Me.ThreadEngagementMin = TextBoxThreadEngagementMin.Text
    End Sub

    Private Sub TextBoxThreadDepth_TextChanged(sender As Object, e As EventArgs) Handles TextBoxThreadDepth.TextChanged
        Me.ThreadDepth = TextBoxThreadDepth.Text
    End Sub

    Private Sub TextBoxExtensionMin_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExtensionMin.TextChanged
        Me.ExtensionMin = TextBoxExtensionMin.Text
    End Sub

    Private Sub ComboBoxUnits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUnits.SelectedIndexChanged
        Me.Units = ComboBoxUnits.Text
    End Sub

    Private Sub ButtonAddToAssy_Click(sender As Object, e As EventArgs) Handles ButtonAddToAssy.Click
        Me.ErrorLogger = New HCErrorLogger("Storekeeper")
        Dim Config As String = Me.StackConfiguration.ToString
        Dim Filename As String = IO.Path.GetFileName("Add to assembly")
        Me.FileLogger = ErrorLogger.AddFile($"Fastener: {Filename}, Config: {Config}")
        Process()
        'FMain.ReportErrors(Me.ErrorLogger)
        Me.ErrorLogger.ReportErrors(UseMessageBox:=True)
    End Sub

    Public Sub DISEApplicationEvents_AfterCommandRun(ByVal theCommandID As Integer)
        If theCommandID = 39002 Then ' Assemble command
            AssembleCommandComplete = True
        End If
    End Sub

    '    Private Sub GetThreadDepthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetThreadDepthToolStripMenuItem.Click
    '        'MsgBox("Get thread depth")
    '        'Dim Command As SolidEdgeFramework.Command
    '        'Mouse = Nothing

    '        OleMessageFilter.Register()

    '        If FMain.SEApp Is Nothing Then

    '            Try
    '                FMain.SEApp = CType(MarshalHelper.GetActiveObject("SolidEdge.Application", throwOnError:=True), SolidEdgeFramework.Application)
    '                FMain.SEApp.DoIdle()
    '                FMain.AsmDoc = CType(FMain.SEApp.ActiveDocument, SolidEdgeAssembly.AssemblyDocument)
    '                'FMain.AsmDoc.Activate()
    '                FMain.SEApp.DoIdle()
    '            Catch ex As Exception
    '                MsgBox("Solid Edge not detected.  This command requires a running instance of Solid Edge with an assembly file active")
    '                Exit Sub
    '            End Try
    '        End If

    '        Command = FMain.SEApp.CreateCommand(SolidEdgeConstants.seCmdFlag.seNoDeactivate)
    '        'Command = FMain.SEApp.CreateCommand(SolidEdgeConstants.seCmdFlag.seTerminateAfterActivation)

    '        If Not Command() Is Nothing Then
    '            Mouse = Command.Mouse
    '        End If

    '        Command.Start()

    '        Command.OnEditOwnerChange = 1
    '        Command.OnEnvironmentChange = 1

    '        'Mouse.LocateMode = SolidEdgeConstants.seLocateModes.seLocateSimple
    '        Mouse.LocateMode = SolidEdgeConstants.seLocateModes.seLocateQuickPick
    '        Mouse.DynamicsMode = SolidEdgeConstants.seDynamicsModes.seDynamicsOff
    '        Mouse.ClearLocateFilter()
    '        Mouse.AddToLocateFilter(SolidEdgeConstants.seLocateFilterConstants.seLocateFace)

    '    End Sub

    '    Private Async Sub m_mouse_MouseClick(
    '        ByVal sButton As Short,
    '        ByVal sShift As Short,
    '        ByVal dX As Double,
    '        ByVal dY As Double,
    '        ByVal dZ As Double,
    '        ByVal pWindowDispatch As Object,
    '        ByVal lKeyPointType As Integer,
    '        ByVal pGraphicDispatch As Object
    '        ) Handles Mouse.MouseClick

    '        Dim FaceReference As SolidEdgeFramework.Reference = Nothing
    '        'Dim ThreadDepth As Double

    '        Dim tmpThreadDepthDouble As Double

    '        Try
    '            FaceReference = CType(pGraphicDispatch, SolidEdgeFramework.Reference)

    '            'ReleaseComObject(CType(Command(), Object))
    '            'ReleaseComObject(CType(Mouse, Object))

    '            tmpThreadDepthDouble = Await GetThreadDepthAsync(FaceReference)

    '            Command.Done = True

    '        Catch ex As Exception
    '            MsgBox($"Await exception: {ex.Message}")
    '        End Try

    '        TextBoxThreadDepth.BeginInvoke(Sub()
    '                                           TextBoxThreadDepth.Text = CStr(tmpThreadDepthDouble)
    '                                       End Sub)

    '    End Sub

    '    Private Function GetThreadDepthAsync(FaceReference As SolidEdgeFramework.Reference) As Task(Of Double)
    '        'Return Task.Run(AddressOf GetThreadDepth)
    '        Return Task.Run(Function() As Double
    '                            Return GetThreadDepth(FaceReference)
    '                        End Function)
    '    End Function

    '    Private Function GetThreadDepth(FaceReference As SolidEdgeFramework.Reference) As Double
    '        Dim tmpThreadDepthDouble As Double = -1

    '        Dim CylinderGeometryForm As Integer = 10
    '        Dim Face As SolidEdgeGeometry.Face = Nothing
    '        Dim FaceID As Integer = 0
    '        Dim ImmediateParentOccurrence As SolidEdgeAssembly.Occurrence
    '        'Dim ImmediateParentSubOccurrence As SolidEdgeAssembly.SubOccurrence
    '        Dim OccurrenceDoc As SolidEdgeFramework.SolidEdgeDocument = Nothing
    '        Dim Models As SolidEdgePart.Models = Nothing

    '        Try
    '            Face = CType(FaceReference.Object, SolidEdgeGeometry.Face)
    '            FaceID = Face.ID
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Return -1
    '        End Try

    '        Try
    '            Dim tmpRef As SolidEdgeFramework.Reference = CType(FaceReference.ImmediateParent, SolidEdgeFramework.Reference)
    '            ImmediateParentOccurrence = CType(tmpRef.Object, SolidEdgeAssembly.Occurrence)
    '            OccurrenceDoc = CType(ImmediateParentOccurrence.OccurrenceDocument, SolidEdgeFramework.SolidEdgeDocument)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '        Dim Extension As String = IO.Path.GetExtension(OccurrenceDoc.FullName)

    '        Select Case Extension
    '            Case ".par"
    '                Dim tmpSEDoc As SolidEdgePart.PartDocument = CType(OccurrenceDoc, SolidEdgePart.PartDocument)
    '                Models = tmpSEDoc.Models
    '            Case ".psm"
    '                Dim tmpSEDoc As SolidEdgePart.SheetMetalDocument = CType(OccurrenceDoc, SolidEdgePart.SheetMetalDocument)
    '                Models = tmpSEDoc.Models
    '            Case Else
    '                MsgBox($"Unable to process face parent file type: '{Extension}'", vbOKOnly, "Cannot Process File Type")
    '                'Exit Sub
    '        End Select

    '        For Each Model As SolidEdgePart.Model In Models
    '            For Each HoleGeometry As SolidEdgePart.HoleGeometry In Model.HoleGeometries
    '                Dim HoleFaces As SolidEdgeGeometry.Faces = CType(HoleGeometry.Faces, SolidEdgeGeometry.Faces)

    '                For Each tmpFace As SolidEdgeGeometry.Face In HoleFaces
    '                    If tmpFace.ID = FaceID Then
    '                        Dim HoleData As SolidEdgePart.HoleData = CType(HoleGeometry.HoleData, SolidEdgePart.HoleData)
    '                        If HoleData.HoleType = SolidEdgePart.FeaturePropertyConstants.igRegularHole Then
    '                            If HoleData.TreatmentType = SolidEdgePart.FeaturePropertyConstants.igTappedHole Then
    '                                'If HoleData.ThreadDepthMethod = SolidEdgePart.FeaturePropertyConstants.igThroughAll Then ' 16
    '                                'End If
    '                                'If HoleData.ThreadDepthMethod = SolidEdgePart.FeaturePropertyConstants.igToNext Then
    '                                'End If
    '                                If HoleData.ThreadDepthMethod = SolidEdgePart.FeaturePropertyConstants.igFinite Then
    '                                    tmpThreadDepthDouble = HoleData.ThreadDepth
    '                                    If HoleData.Units = SolidEdgePart.HoleDataUnitsConstants.igHoleDataUnitsInches Then
    '                                        tmpThreadDepthDouble = tmpThreadDepthDouble * 1000 / 25.4
    '                                        Exit For
    '                                    Else
    '                                        tmpThreadDepthDouble = tmpThreadDepthDouble * 1000
    '                                        Exit For
    '                                    End If
    '                                Else
    '                                End If
    '                            Else
    '                            End If
    '                        End If
    '                    End If

    '                Next
    '                If Not tmpThreadDepthDouble = -1 Then Exit For
    '            Next
    '            If Not tmpThreadDepthDouble = -1 Then Exit For
    '        Next

    '        Return tmpThreadDepthDouble
    '    End Function

    '    Private Sub Command_Terminate() Handles Command.Terminate
    '        Try
    '            If Mouse IsNot Nothing Then Mouse = Nothing
    '            If Command() IsNot Nothing Then Command = Nothing
    '        Catch ex As Exception
    '            Dim i = 0
    '        End Try
    '        'MsgBox("No partially-tapped hole found.  Please restart the command and try again.", vbOKOnly, "Select a Partially-Tapped Hole")
    '    End Sub

    '    ''https://stackoverflow.com/questions/70760292/how-to-implement-async-await-function
    '    'Private Async Sub btnSubMain_Click(sender As Object, e As EventArgs) Handles btnSubMain.Click
    '    '    Dim answer As Integer
    '    '    Try
    '    '        btnSubMain.Enabled = False
    '    '        ' async call, UI continues to run
    '    '        answer = Await SomeIntegerAsync()
    '    '    Finally
    '    '        btnSubMain.Enabled = True
    '    '    End Try
    '    '    MessageBox.Show(answer.ToString())

    '    '    Try
    '    '        btnSubMain.Enabled = False
    '    '        ' synchronous call, UI is blocked
    '    '        answer = SomeInteger()
    '    '    Finally
    '    '        btnSubMain.Enabled = True
    '    '    End Try
    '    '    MessageBox.Show(answer.ToString())
    '    'End Sub

    '    'Function SomeIntegerAsync() As Task(Of Integer)
    '    '    Return Task.Run(AddressOf SomeInteger)
    '    'End Function

    '    'Function SomeInteger() As Integer
    '    '    Thread.Sleep(5000)
    '    '    Return 34
    '    'End Function

    '    Public Sub ReleaseComObject(ByRef obj As Object)
    '        If obj IsNot Nothing Then
    '            ' Call FinalReleaseComObject. This call means that this tool MUST NOT try to reference the object again, even from another variable.
    '            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(obj)
    '            obj = Nothing
    '        End If
    '    End Sub

End Class

