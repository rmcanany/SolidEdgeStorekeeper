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

    Private Property IsAsmeStud As Boolean

    Public Enum StackConfigurationConstants

        '  F Fastener
        '  S ASME Stud
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
        S_N_CO_N
    End Enum


    Public Sub New(_FMain As Form_Main)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.FMain = _FMain

    End Sub

    Private Sub Startup()

        Dim UP As New UtilsPreferences

        UP.GetFormFastenerStackSettings(Me)

        If Me.TableLayoutPanel1 IsNot Nothing Then UpdateForm()

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
            Me.FastenerFilename = FMain.GetFilenameFromPropsFormula(DefaultExtension:=Extension, New Logger("Form Load", Nothing))
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
        End If

        If Proceed AndAlso Not GenerateNeededFiles(Me.FileLogger.AddLogger("Generate needed files")) Then
            Proceed = False
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
                End If
            Else
                Proceed = False
            End If
        End If

        Dim InitialNumOccurrences As Integer = 0

        If Proceed Then
            InitialNumOccurrences = FMain.AsmDoc.Occurrences.Count
        End If

        If Proceed Then
            Proceed = AddStackElementAndDisperse(Me.TopFilename, Me.FileLogger.AddLogger("Add and disperse top fastener stack"))
        End If

        If Proceed And Not Me.BottomFilename = "" Then
            Proceed = AddStackElementAndDisperse(Me.BottomFilename, Me.FileLogger.AddLogger("Add and disperse top fastener stack"))
        End If

        If Proceed Then
            Proceed = CreateFastenerStackGroup(InitialNumOccurrences, Me.FileLogger.AddLogger("Create fastener stack group and maybe pattern"))
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

        If Not ConfigString.Contains("S_") Then
            If ConfigString.Contains("_N") Or ConfigString.Contains("_TT") Then
                Try
                    Dim V = CDbl(UC.FixLocaleDecimal(Me.ExtensionMin))
                Catch ex As Exception
                    Success = False
                    _ErrorLogger.AddMessage($"Could not resolve minimum extension: '{Me.ExtensionMin}'")
                End Try
            End If
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

        If Not Me.IsAsmeStud Then
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

        End If

        Dim ConfigString As String = Me.StackConfiguration.ToString

        Dim tmpSelectedNodeFullPath = FMain.SelectedNodeFullPath ' Save the original selected node.  Used to reset the form after processing.

        FMain.AddToLibraryOnly = True  ' We don't want to add the individual files to the user's assembly

        ' Generate the fastener if needed
        LabelStatus.Text = "Generating fastener"
        FMain.SelectedNodeFullPath = Me.TreeviewFastenerFullPath
        Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger:=_ErrorLogger))
        Me.FastenerFilename = FMain.GetFilenameFromPropsFormula(DefaultExtension:=DefaultExtension, _ErrorLogger)

        Try
            Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
        Catch ex As Exception
            _ErrorLogger.AddMessage("Error processing file")
            _ErrorLogger.AddMessage(ex.ToString)
        End Try

        ' Generate the flat washer if needed
        If Proceed And ConfigString.Contains("_FW_") Then
            LabelStatus.Text = "Generating flat washer"
            FMain.SelectedNodeFullPath = Me.TreeviewFlatWasherFullPath
            Try
                Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
            Catch ex As Exception
                _ErrorLogger.AddMessage("Error processing file")
                _ErrorLogger.AddMessage(ex.ToString)
            End Try
        End If

        ' Generate the lock washer if needed
        If Proceed And ConfigString.Contains("_LW_") Then
            LabelStatus.Text = "Generating lock washer"
            FMain.SelectedNodeFullPath = Me.TreeviewLockwasherFullPath
            Try
                Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
            Catch ex As Exception
                _ErrorLogger.AddMessage("Error processing file")
                _ErrorLogger.AddMessage(ex.ToString)
            End Try
        End If

        ' Generate the nut if needed
        If Proceed And ConfigString.Contains("_N") Then
            LabelStatus.Text = "Generating nut"
            FMain.SelectedNodeFullPath = Me.TreeviewNutFullPath
            Try
                Proceed = FMain.Process(ErrorLogger:=_ErrorLogger)
            Catch ex As Exception
                _ErrorLogger.AddMessage("Error processing file")
                _ErrorLogger.AddMessage(ex.ToString)
            End Try
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
                    Case "S.par"
                        ReplacementFilename = Me.FastenerFilename

                        Dim UC As New UtilsCommon
                        Dim tmpSEDoc As SolidEdgeFramework.SolidEdgeDocument = CType(tmpAsm, SolidEdgeFramework.SolidEdgeDocument)
                        Dim V As SolidEdgeFramework.variable = UC.GetDocVariable(tmpSEDoc, "ClampedThickness")
                        If V IsNot Nothing Then
                            V.Formula = Me.ClampedThickness
                            FMain.SEApp.DoIdle()
                        End If

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

            ' Get a unique name for the new assembly group
            Dim AssemblyGroupNames As New List(Of String)
            For Each AssemblyGroup As SolidEdgeAssembly.AssemblyGroup In FMain.AsmDoc.AssemblyGroups
                AssemblyGroupNames.Add(AssemblyGroup.Name)
            Next
            Dim j = 1
            Dim Stackname As String = Nothing
            While True
                Stackname = $"FastenerStack {CStr(j)}"
                If Not AssemblyGroupNames.Contains(Stackname) Then Exit While
                j += 1
            End While

            ' Create the group
            Dim NewGroup As SolidEdgeAssembly.AssemblyGroup = FMain.AsmDoc.AssemblyGroups.Add(NumFilesAdded, NewOccurrenceList.ToArray)
            NewGroup.Name = Stackname

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

    Private Function GetTopAssyTemplateName() As String

        RemoveUnusedStackAssyFiles()

        Dim Filename As String = ""

        Filename = Me.StackConfiguration.ToString.Split("_CO_")(0)
        Filename = Filename.Replace("_", "-")
        Filename = $"FastenerStackTop_{Filename}.asm"
        Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\{Filename}"

        Return Filename

    End Function

    Private Function GetBottomAssyTemplateName() As String

        RemoveUnusedStackAssyFiles()

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

        Dim ErrorLogger As Logger
        If Me.FileLogger IsNot Nothing Then
            ErrorLogger = Me.FileLogger
        Else
            ErrorLogger = New Logger("Get related filenames", Nothing)
        End If

        Dim SelectedNodeFullPath As String = FMain.SelectedNodeFullPath  ' Saving to reset back

        Me.IsAsmeStud = SelectedNodeFullPath.Contains("For Flange NPS") Or SelectedNodeFullPath.Contains("For_Flange_NPS")

        Me.TreeviewFastenerFullPath = SelectedNodeFullPath
        Dim FastenerNodeNameList = SelectedNodeFullPath.Split("\")
        For i = 0 To FastenerNodeNameList.Count - 1
            FastenerNodeNameList(i) = FMain.StringToXml(FastenerNodeNameList(i))
        Next

        Dim XmlDoc As System.Xml.XmlDocument = FMain.XmlDoc
        Dim ParentNode As XmlNode


        ' ###### FASTENER SIZE NODE ######

        Dim FastenerPath As String = ""
        ' The fastener size node will be one level up from the selected length node
        ' Except for an ASME stud.  In that case, the fastener size will be in the bottom node.

        Dim CountDecrement As Integer
        If Not IsAsmeStud Then
            CountDecrement = 1
        Else
            CountDecrement = 1
        End If
        For i = 0 To FastenerNodeNameList.Count - CountDecrement
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

            If IsAsmeStud Then FlatWasherSearchPath = $"..\{FlatWasherSearchPath}"

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
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger))
                Me.FlatWasherFilename = FMain.GetFilenameFromPropsFormula(DefaultExtension:=DefaultExtension, ErrorLogger)
                Exit For
            End If

        Next


        ' ###### LOCKWASHER FILENAME ######

        Me.LockwasherFilename = "Lock washer not found"
        Me.TreeviewLockwasherFullPath = ""

        For Each LockWasherSearchPath As String In Me.LockWasherSearchPaths
            ' SE2024 ..\..\..\Washer_Lock
            ' SE2019 NA 

            If IsAsmeStud Then LockWasherSearchPath = $"..\{LockWasherSearchPath}"

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
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger))
                LockwasherFilename = FMain.GetFilenameFromPropsFormula(DefaultExtension:=DefaultExtension, ErrorLogger)
                Exit For
            End If

        Next


        ' ###### NUT FILENAME ######

        Me.NutFilename = "Nut not found"
        Me.TreeviewNutFullPath = ""

        For Each NutSearchPath As String In Me.NutSearchPaths
            ' SE2024 ..\..\..\Washer_Flat
            ' SE2019 ..\..\..\..\ISO_WASHERS_-_Steel\ISO_7089_-_Plain_washers_-_Normal_series

            If IsAsmeStud Then
                NutSearchPath = $"..\{NutSearchPath}"
                NutSearchPath = NutSearchPath.Replace("Nut_Hex", "Nut_Heavy_Hex")
            End If

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
                Dim DefaultExtension As String = IO.Path.GetExtension(FMain.GetTemplateNameFormula(ErrorLogger))
                NutFilename = FMain.GetFilenameFromPropsFormula(DefaultExtension:=DefaultExtension, ErrorLogger)
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
                If Not Me.IsAsmeStud Then
                    If LengthNode.Name.Contains("Length_") Then
                        tmpLength = CDbl(UC.FixLocaleDecimal(LengthNode.InnerText))
                        If tmpLength >= LengthMin And tmpLength <= LengthMax Then
                            Node = LengthNode
                            Exit For
                        End If
                    End If
                Else
                    If LengthNode.HasChildNodes Then
                        For Each tmpLengthNode As XmlNode In LengthNode
                            If tmpLengthNode.Name.Contains("Length") Then
                                tmpLength = CDbl(UC.FixLocaleDecimal(tmpLengthNode.InnerText))
                                If tmpLength >= LengthMin And tmpLength <= LengthMax Then
                                    'Node = tmpLengthNode
                                    Node = LengthNode
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If Node IsNot Nothing Then Exit For
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

            Case StackConfigurationConstants.S_N_CO_N
                Me.FastenerMinLength = tmpClampedThickness + 2 * Me.NutThickness
                Me.FastenerMaxLength = 10000

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
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_N

                LabelBottomFlatWasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_LW_N

                LabelBottomLockwasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_LW_N

                LabelBottomLockwasher.Visible = True
                LabelBottomFlatWasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

        ' #### Top Flat Washer ####

            Case StackConfigurationConstants.F_FW_CO_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_N

                LabelTopFlatWasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_N

                LabelTopFlatWasher.Visible = True
                LabelBottomFlatWasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_LW_N

                LabelTopFlatWasher.Visible = True
                LabelBottomLockwasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_LW_N

                LabelTopFlatWasher.Visible = True
                LabelBottomFlatWasher.Visible = True
                LabelBottomLockwasher.Visible = True
                LabelBottomNut.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

        ' #### Thread Thru ####

            Case StackConfigurationConstants.F_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TT

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TT

                LabelTopFlatWasher.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TT

                LabelTopLockwasher.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TT

                LabelTopLockwasher.Visible = True
                LabelTopFlatWasher.Visible = True
                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True


        ' #### Thread Blind ####

            Case StackConfigurationConstants.F_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TB

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TB

                LabelTopFlatWasher.Visible = True
                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TB

                LabelTopLockwasher.Visible = True
                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True

            Case StackConfigurationConstants.F_LW_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TB

                LabelTopLockwasher.Visible = True
                LabelTopFlatWasher.Visible = True
                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True


        ' #### ASME Stud ####

            Case StackConfigurationConstants.S_N_CO_N
                PictureBox1.Image = My.Resources.FastenerStack_S_N_CO_N

                LabelClampedThickness.Visible = True
                LabelBottomNut.Visible = True

        End Select
    End Sub

    Public Sub HideOptionControls()
        LabelTopFlatWasher.Visible = False
        LabelTopLockwasher.Visible = False
        LabelThreadEngagementMin.Visible = False
        TextBoxThreadEngagementMin.Visible = False
        LabelThreadDepth.Visible = False
        TextBoxThreadDepth.Visible = False
        LabelBottomFlatWasher.Visible = False
        LabelBottomLockwasher.Visible = False
        LabelBottomNut.Visible = False
        LabelExtensionMin.Visible = False
        TextBoxExtensionMin.Visible = False

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

        Me.ErrorLogger.ReportErrors(UseMessageBox:=True)
    End Sub

    Public Sub DISEApplicationEvents_AfterCommandRun(ByVal theCommandID As Integer)
        If theCommandID = 39002 Then ' Assemble command
            AssembleCommandComplete = True
        End If
    End Sub

End Class

