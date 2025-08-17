Option Strict On
Imports System.Xml

Public Class FormFastenerStack

    ' Interform communication
    ' https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp

    Public Property FMain As Form_Main


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


    Public Sub Process()
        Dim Proceed As Boolean = True

        GenerateNeededFiles()

        If Not CheckStartConditions() Then Proceed = False

        Dim AssyList As List(Of SolidEdgeAssembly.AssemblyDocument) = PrepTmpAssys()

    End Sub

    Private Function CheckStartConditions() As Boolean

        Dim Success As Boolean = True
        Dim ErrorMessages As New List(Of String)

        If Not IO.File.Exists(Me.FastenerFilename) Then ErrorMessages.Add($"Fastener not found: '{Me.FastenerFilename}'")

        Try
            Dim V = CDbl(Me.ClampedThickness)
        Catch ex As Exception
            ErrorMessages.Add($"Could not resolve clamped thickness: '{Me.ClampedThickness}'")
        End Try

        Dim ConfigString As String = Me.StackConfiguration.ToString

        If ConfigString.Contains("_N") Then
            If Not IO.File.Exists(Me.NutFilename) Then ErrorMessages.Add($"Nut not found: '{Me.NutFilename}'")
        End If

        If ConfigString.Contains("_FW_") Then
            If Not IO.File.Exists(Me.FlatWasherFilename) Then ErrorMessages.Add($"Flat washer not found: '{Me.FlatWasherFilename}'")
        End If

        If ConfigString.Contains("_LW_") Then
            If Not IO.File.Exists(Me.LockwasherFilename) Then ErrorMessages.Add($"Lock washer not found: '{Me.LockwasherFilename}'")
        End If

        If ConfigString.Contains("_N") Or ConfigString.Contains("_TT") Then
            Try
                Dim V = CDbl(Me.ExtensionMin)
            Catch ex As Exception
                ErrorMessages.Add($"Could not resolve minimum extension: '{Me.ExtensionMin}'")
            End Try
        End If

        If ConfigString.Contains("_TB") Then
            Try
                Dim V = CDbl(Me.ThreadEngagementMin)
            Catch ex As Exception
                ErrorMessages.Add($"Could not resolve minimum thread engagement: '{Me.ThreadEngagementMin}'")
            End Try
            Try
                Dim V = CDbl(Me.ThreadDepth)
            Catch ex As Exception
                ErrorMessages.Add($"Could not resolve thread depth: '{Me.ThreadDepth}'")
            End Try
        End If

        If ErrorMessages.Count > 0 Then
            Success = False
            Dim msg As String = $"Please resolve the following before proceeding {vbCrLf}{vbCrLf}"
            Dim Indent As String = "    "
            For Each s As String In ErrorMessages
                msg = $"{msg}{Indent}{s}{vbCrLf}"
            Next
            MsgBox(msg, vbOKOnly, "Check Start Conditions")
        End If

        Return Success

    End Function

    Private Sub GenerateNeededFiles()

        Dim tmpTreeviewFastenerFullPath As String
        tmpTreeviewFastenerFullPath = GetCorrectLengthFastenerFullPath(
            Me.TreeviewFastenerFullPath, Me.FastenerMinLength, Me.FastenerMaxLength)

        If tmpTreeviewFastenerFullPath IsNot Nothing Then
            Me.TreeviewFastenerFullPath = tmpTreeviewFastenerFullPath
        Else
            MsgBox("No fastener length satisfies given parameters", vbOKOnly, "Fastener Length Not Found")
            Exit Sub
        End If

        Dim ConfigString As String = Me.StackConfiguration.ToString

        Dim tmpSelectedNodeFullPath = FMain.SelectedNodeFullPath
        FMain.AddToLibraryOnly = True

        FMain.SelectedNodeFullPath = Me.TreeviewFastenerFullPath
        Me.FastenerFilename = FMain.GetFilenameFormula(DefaultExtension:=IO.Path.GetExtension(FMain.GetTemplateNameFormula()))
        FMain.Process()

        If ConfigString.Contains("_FW_") Then
            FMain.SelectedNodeFullPath = Me.TreeviewFlatWasherFullPath
            FMain.Process()
        End If

        If ConfigString.Contains("_LW_") Then
            FMain.SelectedNodeFullPath = Me.TreeviewLockwasherFullPath
            FMain.Process()
        End If

        If ConfigString.Contains("_N") Then
            FMain.SelectedNodeFullPath = Me.TreeviewNutFullPath
            FMain.Process()
        End If

        FMain.AddToLibraryOnly = False
        FMain.SelectedNodeFullPath = tmpSelectedNodeFullPath

    End Sub

    Private Function PrepTmpAssys() As List(Of SolidEdgeAssembly.AssemblyDocument)

        Dim Outlist As New List(Of SolidEdgeAssembly.AssemblyDocument)

        If FMain.SEApp Is Nothing Or FMain.AsmDoc Is Nothing Then
            MsgBox("Unable to connect to Solid Edge, or an assembly file is not open")
            Return Nothing
        End If

        For Each AssyFilename In {GetTopAssyFilename(), GetBottomAssyFilename()}

            Dim tmpAssyFilename = $"{IO.Path.GetDirectoryName(AssyFilename)}\tmp{IO.Path.GetFileName(AssyFilename)}"

            Dim tmpAsm As SolidEdgeAssembly.AssemblyDocument = Nothing
            If Me.FMain.ProcessTemplateInBackground Then
                tmpAsm = CType(FMain.SEApp.Documents.Open(AssyFilename, 8), SolidEdgeAssembly.AssemblyDocument)
            Else
                tmpAsm = CType(Me.FMain.SEApp.Documents.Open(AssyFilename), SolidEdgeAssembly.AssemblyDocument)
            End If
            FMain.SEApp.DoIdle()

            'TextBoxStatus.Text = $"Saving '{IO.Path.GetFileName(Filename)}'"
            tmpAsm.SaveAs(tmpAssyFilename)
            FMain.SEApp.DoIdle()

            Outlist.Add(tmpAsm)

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
                        MsgBox($"FastenerStack.PrepTmpAssys unrecognized filename: '{IO.Path.GetFileName(OccurrenceFilename)}'")
                        Return Nothing
                End Select

                If FMain.FailedConstraintSuppress Then
                    tmpAsm.ReplaceComponents({Occurrence}, ReplacementFilename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementSuppress)
                ElseIf FMain.FailedConstraintAllow Then
                    tmpAsm.ReplaceComponents({Occurrence}, ReplacementFilename, SolidEdgeAssembly.ConstraintReplacementConstants.seConstraintReplacementNone)
                    'Else
                    '    Me.FileLogger.AddMessage("Option not set for treatment of for failed constraints.  Set it on the Tree Search Options dialog.")
                End If

            Next

            tmpAsm.Save()
            FMain.SEApp.DoIdle()
            tmpAsm.Close()
            FMain.SEApp.DoIdle()

        Next

        Return Outlist
    End Function

    Private Function GetTopAssyFilename() As String
        Dim Filename As String = ""

        Filename = Me.StackConfiguration.ToString.Split("_CO_")(0)
        Filename = Filename.Replace("_", "-")
        Filename = $"FastenerStackTop_{Filename}.asm"
        Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\{Filename}"

        Return Filename
    End Function

    Private Function GetBottomAssyFilename() As String
        Dim Filename As String = ""

        Filename = Me.StackConfiguration.ToString.Split("_CO_")(1)
        Filename = Filename.Replace("_", "-")
        Filename = $"FastenerStackBottom_{Filename}.asm"
        Filename = $"{FMain.TemplateDirectory}\FastenerStackTemplates\{Filename}"

        Return Filename
    End Function

    Public Sub GetRelatedFilenames()
        Dim SelectedNodeFullPath As String = FMain.SelectedNodeFullPath  ' Saving to reset back
        Me.TreeviewFastenerFullPath = SelectedNodeFullPath
        Dim tmpSelectedNodeFullPath As String = FMain.SpaceToUnderscore(SelectedNodeFullPath)
        Dim tmpList = tmpSelectedNodeFullPath.Split("\")

        Dim XmlDoc As System.Xml.XmlDocument = FMain.XmlDoc
        Dim ParentNode As XmlNode

        Dim FastenerPath As String = ""
        Dim FlatWasherFullPath As String = ""
        Dim LockwasherFullPath As String = ""
        Dim NutFullPath As String = ""

        ' The selected fastener will be 1 level down from the fastener size node
        For i = 0 To tmpList.Count - 2
            If i = 0 Then
                FastenerPath = tmpList(i)
            Else
                FastenerPath = $"{FastenerPath}\{tmpList(i)}"
            End If
        Next

        ' The nut and washer category nodes will be 3 levels up from the fastener length node
        For i = 0 To tmpList.Count - 4
            If i = 0 Then
                FlatWasherFullPath = tmpList(i)
                LockwasherFullPath = tmpList(i)
                NutFullPath = tmpList(i)
            Else
                FlatWasherFullPath = $"{FlatWasherFullPath}\{tmpList(i)}"
                LockwasherFullPath = $"{LockwasherFullPath}\{tmpList(i)}"
                NutFullPath = $"{NutFullPath}\{tmpList(i)}"
            End If
        Next

        ' Add category-specific node names
        FlatWasherFullPath = $"{FlatWasherFullPath}\Washer_Flat"
        LockwasherFullPath = $"{LockwasherFullPath}\Washer_Lock"
        NutFullPath = $"{NutFullPath}\Nut_Hex"

        Dim NominalDiameter As Double
        Dim ThreadDescription As String
        Dim MatchingNode As XmlNode

        ' Find the Fastener NominalDiameter and ThreadDescription
        ParentNode = FMain.XmlNodeFromPath(FastenerPath)
        'Me.TreeviewFastenerFullPath = FastenerPath
        NominalDiameter = GetNominalDiameter(ParentNode)
        ThreadDescription = GetThreadDescription(ParentNode)

        ' Find the FlatWasher with the same NominalDiameter as the Fastener
        ParentNode = FMain.XmlNodeFromPath(FlatWasherFullPath)
        MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription:=Nothing)
        FlatWasherThickness = GetThickness(MatchingNode)
        FlatWasherFullPath = $"{FlatWasherFullPath}\{MatchingNode.Name}"
        Me.TreeviewFlatWasherFullPath = FlatWasherFullPath
        FMain.SelectedNodeFullPath = FlatWasherFullPath
        FlatWasherFilename = FMain.GetFilenameFormula(DefaultExtension:=IO.Path.GetExtension(FMain.GetTemplateNameFormula()))

        ' Find the Lockwasher with the same NominalDiameter as the Fastener
        ParentNode = FMain.XmlNodeFromPath(LockwasherFullPath)
        MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription:=Nothing)
        LockWasherThickness = GetThickness(MatchingNode)
        LockwasherFullPath = $"{LockwasherFullPath}\{MatchingNode.Name}"
        Me.TreeviewLockwasherFullPath = LockwasherFullPath
        FMain.SelectedNodeFullPath = LockwasherFullPath
        LockwasherFilename = FMain.GetFilenameFormula(DefaultExtension:=IO.Path.GetExtension(FMain.GetTemplateNameFormula()))

        ' Find the Nut with the same NominalDiameter and ThreadDescription as the Fastener
        ParentNode = FMain.XmlNodeFromPath(NutFullPath)
        MatchingNode = GetMatchingNode(ParentNode, NominalDiameter, ThreadDescription)
        NutThickness = GetThickness(MatchingNode)
        NutFullPath = $"{NutFullPath}\{MatchingNode.Name}"
        Me.TreeviewNutFullPath = NutFullPath
        FMain.SelectedNodeFullPath = NutFullPath
        NutFilename = FMain.GetFilenameFormula(DefaultExtension:=IO.Path.GetExtension(FMain.GetTemplateNameFormula()))

        FMain.SelectedNodeFullPath = SelectedNodeFullPath

        Dim j = 0
    End Sub

    Private Function GetThickness(ParentNode As XmlNode) As Double
        Dim Value As Double = Nothing

        If ParentNode.HasChildNodes Then
            For Each ChildNode As XmlNode In ParentNode.ChildNodes
                If ChildNode.Name = "Thickness" Then
                    Value = CDbl(ChildNode.InnerText)
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

        Dim SizeNode As XmlNode = FMain.XmlNodeFromPath(FMain.SpaceToUnderscore(CurrentFastenerFullPath))
        SizeNode = SizeNode.ParentNode

        Dim Node As XmlNode = Nothing
        Dim tmpLength As Double = 0

        If SizeNode.HasChildNodes Then
            For Each LengthNode As XmlNode In SizeNode
                If LengthNode.Name.Contains("Length_") Then
                    tmpLength = CDbl(LengthNode.InnerText)
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

        If CategoryNode.HasChildNodes Then
            For Each SizeNode As XmlNode In CategoryNode.ChildNodes
                If SizeNode.HasChildNodes Then
                    For Each ChildNode As XmlNode In SizeNode.ChildNodes
                        If ChildNode.Name = "NominalDiameter" Then
                            tmpNominalDiameter = CDbl(ChildNode.InnerText)
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
        Dim Value As Double = Nothing

        If ParentNode.HasChildNodes Then
            For Each ChildNode As XmlNode In ParentNode.ChildNodes
                If ChildNode.Name = "NominalDiameter" Then
                    Value = CDbl(ChildNode.InnerText)
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

        For Each V As String In {Me.ClampedThickness, Me.ThreadEngagementMin, Me.ThreadDepth, Me.ExtensionMin}
            Try
                Dim tmpV = CDbl(V)
            Catch ex As Exception
                Exit Sub
            End Try
        Next

        Select Case Me.StackConfiguration
            Case StackConfigurationConstants.F_CO_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_FW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_LW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_CO_FW_LW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_FW_CO_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_FW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + 2 * Me.FlatWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_LW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_FW_LW_N
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + 2 * Me.FlatWasherThickness + Me.LockWasherThickness + Me.NutThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_CO_TT
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_FW_CO_TT
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_LW_CO_TT
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000
            Case StackConfigurationConstants.F_LW_FW_CO_TT
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + Me.LockWasherThickness + CDbl(Me.ExtensionMin)
                Me.FastenerMaxLength = 10000

            Case StackConfigurationConstants.F_CO_TB
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + CDbl(Me.ThreadEngagementMin)
                Me.FastenerMaxLength = CDbl(Me.ClampedThickness) + CDbl(Me.ThreadDepth)
            Case StackConfigurationConstants.F_FW_CO_TB
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + CDbl(Me.ThreadEngagementMin)
                Me.FastenerMaxLength = CDbl(Me.ClampedThickness) + Me.FlatWasherThickness + CDbl(Me.ThreadDepth)
            Case StackConfigurationConstants.F_LW_CO_TB
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + CDbl(Me.ThreadEngagementMin)
                Me.FastenerMaxLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + CDbl(Me.ThreadDepth)
            Case StackConfigurationConstants.F_LW_FW_CO_TB
                Me.FastenerMinLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + Me.FlatWasherThickness + CDbl(Me.ThreadEngagementMin)
                Me.FastenerMaxLength = CDbl(Me.ClampedThickness) + Me.LockWasherThickness + Me.FlatWasherThickness + CDbl(Me.ThreadDepth)
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
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_N

                LabelBottomFlatWasher.Visible = True
                ButtonPasteBottomFlatWasher.Visible = True
                ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_LW_N

                LabelBottomLockwasher.Visible = True
                ButtonPasteBottomLockwasher.Visible = True
                ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_FW_LW_N

                LabelBottomLockwasher.Visible = True
                ButtonPasteBottomLockwasher.Visible = True
                ButtonLockBottomLockwasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                ButtonPasteBottomFlatWasher.Visible = True
                ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

        ' #### Top Flat Washer ####

            Case StackConfigurationConstants.F_FW_CO_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_N

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_N

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                ButtonPasteBottomFlatWasher.Visible = True
                ButtonLockBottomFlatWasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_LW_N

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelBottomLockwasher.Visible = True
                ButtonPasteBottomLockwasher.Visible = True
                ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_FW_LW_N
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_FW_LW_N

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelBottomFlatWasher.Visible = True
                ButtonPasteBottomFlatWasher.Visible = True
                ButtonLockBottomFlatWasher.Visible = True

                LabelBottomLockwasher.Visible = True
                ButtonPasteBottomLockwasher.Visible = True
                ButtonLockBottomLockwasher.Visible = True

                LabelBottomNut.Visible = True
                ButtonPasteBottomNut.Visible = True
                ButtonLockBottomNut.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

        ' #### Thread Thru ####

            Case StackConfigurationConstants.F_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TT

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TT

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TT

                LabelTopLockwasher.Visible = True
                ButtonPasteTopLockwasher.Visible = True
                ButtonLockTopLockwasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True

            Case StackConfigurationConstants.F_LW_FW_CO_TT
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TT

                LabelTopLockwasher.Visible = True
                ButtonPasteTopLockwasher.Visible = True
                ButtonLockTopLockwasher.Visible = True

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelExtensionMin.Visible = True
                TextBoxExtensionMin.Visible = True
                ButtonLockExtensionMin.Visible = True


        ' #### Thread Blind ####

            Case StackConfigurationConstants.F_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_CO_TB

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                ButtonLockThreadDepth.Visible = True

            Case StackConfigurationConstants.F_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_FW_CO_TB

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                ButtonLockThreadDepth.Visible = True

            Case StackConfigurationConstants.F_LW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_CO_TB

                LabelTopLockwasher.Visible = True
                ButtonPasteTopLockwasher.Visible = True
                ButtonLockTopLockwasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                ButtonLockThreadDepth.Visible = True


            Case StackConfigurationConstants.F_LW_FW_CO_TB
                PictureBox1.Image = My.Resources.FastenerStack_F_LW_FW_CO_TB

                LabelTopLockwasher.Visible = True
                ButtonPasteTopLockwasher.Visible = True
                ButtonLockTopLockwasher.Visible = True

                LabelTopFlatWasher.Visible = True
                ButtonPasteTopFlatWasher.Visible = True
                ButtonLockTopFlatWasher.Visible = True

                LabelThreadEngagementMin.Visible = True
                TextBoxThreadEngagementMin.Visible = True
                ButtonLockThreadEngagementMin.Visible = True

                LabelThreadDepth.Visible = True
                TextBoxThreadDepth.Visible = True
                ButtonLockThreadDepth.Visible = True



        End Select
    End Sub

    Public Sub HideOptionControls()
        LabelTopFlatWasher.Visible = False
        ButtonPasteTopFlatWasher.Visible = False
        ButtonLockTopFlatWasher.Visible = False

        LabelTopLockwasher.Visible = False
        ButtonPasteTopLockwasher.Visible = False
        ButtonLockTopLockwasher.Visible = False

        LabelThreadEngagementMin.Visible = False
        TextBoxThreadEngagementMin.Visible = False
        ButtonLockThreadEngagementMin.Visible = False

        LabelThreadDepth.Visible = False
        TextBoxThreadDepth.Visible = False
        ButtonLockThreadDepth.Visible = False

        LabelBottomFlatWasher.Visible = False
        ButtonPasteBottomFlatWasher.Visible = False
        ButtonLockBottomFlatWasher.Visible = False

        LabelBottomLockwasher.Visible = False
        ButtonPasteBottomLockwasher.Visible = False
        ButtonLockBottomLockwasher.Visible = False

        LabelBottomNut.Visible = False
        ButtonPasteBottomNut.Visible = False
        ButtonLockBottomNut.Visible = False

        LabelExtensionMin.Visible = False
        TextBoxExtensionMin.Visible = False
        ButtonLockExtensionMin.Visible = False


    End Sub

    Private Sub LabelTopFastener_Click(sender As Object, e As EventArgs) Handles LabelTopFastener.Click

    End Sub

    Private Sub LabelStackConfiguration_Click(sender As Object, e As EventArgs) Handles LabelStackConfiguration.Click
        ButtonStackConfiguration_Click(sender, e)
    End Sub

    Private Sub ButtonStackConfiguration_Click(sender As Object, e As EventArgs) Handles ButtonStackConfiguration.Click
        'Me.FMain.TextBoxStatus.Text = ""
        Dim FSS As New FormStackConfiguration(Me.FMain)
        Dim Result = FSS.ShowDialog()

        If Result = DialogResult.OK Then
            Me.StackConfiguration = CType(FSS.StackConfiguration, StackConfigurationConstants)
        End If
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Dim UP As New UtilsPreferences
        UP.SaveFormFastenerStackSettings(Me)
        Me.Dispose()
    End Sub

    Private Sub FormFastenerStack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim UP As New UtilsPreferences
        UP.GetFormFastenerStackSettings(Me)
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
        Process()
    End Sub
End Class

Public Class FastenerStack

    Public Property StackConfiguration As StackConfigurationConstants
    Public Property TopFilename As String
    Public Property BottomFilename As String
    Public Property FastenerFilename As String
    Public Property FlatWasherFilename As String
    Public Property LockwasherFilename As String
    Public Property NutFilename As String


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

    Public Sub New()

    End Sub

End Class