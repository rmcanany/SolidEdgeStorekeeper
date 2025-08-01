Option Strict On

Imports System.Net.Http
Imports Newtonsoft.Json

Public Class UtilsPreferences

    Public Sub New()

    End Sub


    '###### FORM MAIN ######

    Public Function GetFormMainSettingsFilename(CheckExisting As Boolean) As String
        Dim Filename = "form_main_settings.json"
        Filename = String.Format("{0}\{1}", GetPreferencesDirectory, Filename)

        If CheckExisting Then
            If FileIO.FileSystem.FileExists(Filename) Then
                Return Filename
            Else
                Return ""
            End If
        Else
            Return Filename
        End If

    End Function

    Public Sub SaveFormMainSettings(FMain As Form_Main, SavingPresets As Boolean)

        Dim tmpJSONDict As New Dictionary(Of String, String)
        Dim JSONString As String

        Dim Outfile = GetFormMainSettingsFilename(CheckExisting:=False)

        Dim FormType As Type = FMain.GetType()
        Dim PropInfos = New List(Of System.Reflection.PropertyInfo)(FormType.GetProperties())
        Dim Value As String
        Dim PropType As String

        ' ###### For reporting Properties not processed.  For occasional checks.  Can cause an exception closing the form.
        Dim ReportIgnoredProperties As Boolean = True
        Dim IgnoredList As New List(Of String)

        Dim MaxIgnoredShowPerPage = 20
        Dim IgnoredCount As Integer = 0
        Dim s As String = ""

        Dim KeepProps As New List(Of String)
        'KeepProps.AddRange({"TLAAutoIncludeTLF", "WarnBareTLA", "TLAIncludePartCopies", "TLAReportUnrelatedFiles", "TLATopDown", "TLABottomUp"})
        'KeepProps.AddRange({"DraftAndModelSameName", "FastSearchScopeFilename", "TLAIgnoreIncludeInReports"})

        ''KeepProps.AddRange({"LinkManagementFilename", "LinkManagementOrder"})
        'KeepProps.AddRange({"LinkManagementFilename"})

        'KeepProps.AddRange({"ProcessAsAvailable", "ProcessAsAvailableRevert", "ProcessAsAvailableChange"})
        'KeepProps.AddRange({"StatusAtoX", "StatusBtoX", "StatusIRtoX", "StatusIWtoX", "StatusOtoX", "StatusRtoX"})
        'KeepProps.AddRange({"SortNone", "KeepUnsortedDuplicates", "SortAlphabetical", "SortDependency", "SortIncludeNoDependencies"})
        'KeepProps.AddRange({"SortRandomSample", "SortRandomSampleFraction"})
        'KeepProps.AddRange({"AssemblyTemplate", "PartTemplate", "SheetmetalTemplate", "DraftTemplate", "MaterialTable", "UseTemplateProperties"})
        'KeepProps.AddRange({"UseCurrentSession", "WarnSave", "NoUpdateMRU", "RemindFilelistUpdate"})
        'KeepProps.AddRange({"ListViewUpdateFrequency", "FileListFontSize", "GroupFiles", "RememberTasks", "RunInBackground"})
        'KeepProps.AddRange({"PropertyFilterIncludeDraftModel", "PropertyFilterIncludeDraftItself", "CheckForNewerVersion"})
        'KeepProps.AddRange({"WarnNoImportedProperties", "EnablePropertyFilter", "EnableFileWildcard", "FileWildcard", "FileWildcardList", "SolidEdgeRequired"})
        'KeepProps.AddRange({"PropertyFilterDictJSON", "TemplatePropertyDictJSON", "TemplatePropertyList", "ListOfColumnsJSON"})
        'KeepProps.AddRange({"ServerConnectionString", "ServerQuery"})
        'KeepProps.AddRange({"FilterAsm", "FilterPar", "FilterPsm", "FilterDft"})
        'KeepProps.AddRange({"TCCachePath", "TCItemIDRx", "TCRevisionRx"})

        'If Not SavingPresets Then KeepProps.AddRange({"Left", "Top", "Width", "Height"})

        For Each PropInfo As System.Reflection.PropertyInfo In PropInfos

            PropType = PropInfo.PropertyType.Name.ToLower

            Dim tf As Boolean
            tf = PropInfo.Module.ToString.ToLower.Contains("storekeeper")
            tf = tf Or {"Left", "Top", "Width", "Height"}.ToList.Contains(PropInfo.Name)

            If Not tf Then Continue For
            If PropType = "xmldocument" Then Continue For

            'If Not KeepProps.Contains(PropInfo.Name) Then

            '    If ReportIgnoredProperties Then
            '        s = String.Format("{0}, {1}, {2}, {3}", PropInfo.Module, PropInfo.PropertyType.FullName, PropInfo.Name, PropType)
            '        IgnoredList.Add(s)
            '        'If IgnoredCount > 0 And IgnoredCount Mod MaxIgnoredShowPerPage = 0 Then
            '        '    s = String.Format("IGNORED PROPERTIES{0}{1}", vbCrLf, s)
            '        '    MsgBox(s, vbOKOnly)
            '        '    s = ""
            '        '    IgnoredCount = -1
            '        'End If
            '        'IgnoredCount += 1

            '    End If

            '    Continue For
            'End If

            Value = Nothing

            Select Case PropType
                Case "string", "double", "int32", "boolean"
                    Value = CStr(PropInfo.GetValue(FMain, Nothing))
                Case "list`1"
                    Value = JsonConvert.SerializeObject(PropInfo.GetValue(FMain, Nothing))
                Case "hcpropertiesdata", "logger"
                    ' Nothing to do here.  HCPropertiesData is saved separately.
                Case "hcpropertiescache"
                    ' Nothing to do here.  HCPropertiesCache is saved separately.
                Case Else
                    MsgBox(String.Format("PropInfo.PropertyType.Name '{0}' not recognized", PropType))
            End Select


            If Value Is Nothing Then
                Select Case PropType
                    Case "string"
                        Value = ""
                    Case "double", "int32"
                        Value = "0"
                    Case "boolean"
                        Value = "False"
                    Case "list`1"
                        Value = JsonConvert.SerializeObject(New List(Of String))
                        MsgBox(String.Format("PropInfo.PropertyType.Name '{0}' detected", PropInfo.PropertyType.Name))
                    Case "hcpropertiesdata", "logger"
                        ' Nothing to do here.  HCPropertiesData is saved separately.
                    Case "hcpropertiescache"
                        ' Nothing to do here.  HCPropertiesCache is saved separately.
                    Case Else
                        MsgBox(String.Format("In UtilsPreferences.SaveFormMainSettings: PropInfo.PropertyType.Name '{0}' not recognized", PropInfo.PropertyType.Name))
                End Select
            End If

            If Value IsNot Nothing Then
                tmpJSONDict(PropInfo.Name) = Value
            End If

        Next

        JSONString = JsonConvert.SerializeObject(tmpJSONDict)

        IO.File.WriteAllText(Outfile, JSONString)


    End Sub

    Public Sub GetFormMainSettings(FMain As Form_Main)

        Dim tmpJSONDict As New Dictionary(Of String, String)
        Dim JSONString As String

        Dim Infile = GetFormMainSettingsFilename(CheckExisting:=True)

        Dim FormType As Type = FMain.GetType()
        Dim PropInfos = New List(Of System.Reflection.PropertyInfo)(FormType.GetProperties())

        If Not Infile = "" Then
            JSONString = IO.File.ReadAllText(Infile)

            tmpJSONDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(JSONString)

            For Each PropInfo As System.Reflection.PropertyInfo In PropInfos

                If tmpJSONDict.Keys.Contains(PropInfo.Name) Then
                    Dim PropTypestring = PropInfo.PropertyType.Name

                    Select Case PropInfo.PropertyType.Name.ToLower
                        Case "string"
                            PropInfo.SetValue(FMain, CStr(tmpJSONDict(PropInfo.Name)))
                        Case "double"
                            PropInfo.SetValue(FMain, CDbl(tmpJSONDict(PropInfo.Name)))
                        Case "int32"
                            PropInfo.SetValue(FMain, CInt(tmpJSONDict(PropInfo.Name)))
                        Case "boolean"
                            PropInfo.SetValue(FMain, CBool(tmpJSONDict(PropInfo.Name)))
                        Case "list`1"
                            Dim L = JsonConvert.DeserializeObject(Of List(Of String))(tmpJSONDict(PropInfo.Name))
                            PropInfo.SetValue(FMain, L)
                    End Select

                End If
            Next
        End If

    End Sub

    Public Function GetFormMainSettingsJSON() As String

        Dim JSONString As String = ""

        Dim Infile = GetFormMainSettingsFilename(CheckExisting:=True)

        If Not Infile = "" Then
            JSONString = IO.File.ReadAllText(Infile)
        End If

        Return JSONString
    End Function

    Public Sub SaveFormMainSettingsJSON(JSONString As String)

        Dim Outfile = GetFormMainSettingsFilename(CheckExisting:=False)

        IO.File.WriteAllText(Outfile, JSONString)

    End Sub


    '###### FOLDERS ######

    Public Function GetStartupDirectory() As String

        ' Returns the location of Housekeeper.exe

        Dim StartupDirectory As String = System.Windows.Forms.Application.StartupPath()

        ' Remove trailing '\'
        If StartupDirectory(StartupDirectory.Count - 1) = "\" Then
            StartupDirectory = StartupDirectory.Substring(0, StartupDirectory.Count - 1)
        End If

        Return StartupDirectory
    End Function

    Public Function GetPreferencesDirectory() As String
        Dim StartupPath As String = GetStartupDirectory()
        Dim PreferencesDirectory = "Preferences"
        Return String.Format("{0}\{1}", StartupPath, PreferencesDirectory)
    End Function

    Public Sub CreatePreferencesDirectory(FMain As Form_Main)
        Dim PreferencesDirectory = GetPreferencesDirectory()
        If Not FileIO.FileSystem.DirectoryExists(PreferencesDirectory) Then
            Try
                FileIO.FileSystem.CreateDirectory(PreferencesDirectory)

                Dim tmpDataDirectory As String = $"{PreferencesDirectory}\Data"
                FileIO.FileSystem.CreateDirectory(tmpDataDirectory)
                FileIO.FileSystem.CopyDirectory(GetDefaultDataDirectory, tmpDataDirectory)
                FMain.DataDirectory = tmpDataDirectory

                Dim tmpTemplatesDirectory As String = $"{PreferencesDirectory}\Templates"
                FileIO.FileSystem.CreateDirectory(tmpTemplatesDirectory)
                FileIO.FileSystem.CopyDirectory(GetDefaultTemplatesDirectory, tmpTemplatesDirectory)
                FMain.TemplateDirectory = tmpTemplatesDirectory

                Dim tmpLibraryDirectory As String = $"{PreferencesDirectory}\Library"
                FileIO.FileSystem.CreateDirectory(tmpLibraryDirectory)
                FMain.LibraryDirectory = tmpLibraryDirectory

            Catch ex As Exception
                Dim s As String = String.Format("Unable to create Preferences directory '{0}'.  ", PreferencesDirectory)
                s = String.Format("{0}You may not have the correct permissions.", s)
                MsgBox(s, vbOKOnly)
            End Try
        End If
    End Sub

    Public Function GetDefaultDataDirectory() As String
        Dim StartupPath As String = GetStartupDirectory()
        Dim DefaultDataDirectory = "DefaultData"
        Return String.Format("{0}\{1}", StartupPath, DefaultDataDirectory)
    End Function

    Public Function GetDefaultTemplatesDirectory() As String
        Dim StartupPath As String = GetStartupDirectory()
        Dim DefaultTemplatesDirectory = "DefaultTemplates"
        Return String.Format("{0}\{1}", StartupPath, DefaultTemplatesDirectory)
    End Function


    '###### FILENAME CHARMAP ######

    Public Sub CreateFilenameCharmap()
        Dim UFC As New UtilsFilenameCharmap()  ' Creates the file filename_charmap.txt if it does not exist.
    End Sub


    '###### PROPERTIES DATA ######

    Public Function GetPropertiesDataFilename(CheckExisting As Boolean) As String
        Dim Filename = "properties_data.json"
        Filename = String.Format("{0}\{1}", GetPreferencesDirectory, Filename)

        If CheckExisting Then
            If FileIO.FileSystem.FileExists(Filename) Then
                Return Filename
            Else
                Return ""
            End If
        Else
            Return Filename
        End If

    End Function


    '###### PROPERTIES CACHE ######

    Public Function GetPropertiesCacheFilename(CheckExisting As Boolean) As String
        Dim Filename = "properties_cache.json"
        Filename = String.Format("{0}\{1}", GetPreferencesDirectory, Filename)

        If CheckExisting Then
            If FileIO.FileSystem.FileExists(Filename) Then
                Return Filename
            Else
                Return ""
            End If
        Else
            Return Filename
        End If

    End Function


    '###### VERSION ######

    Public Sub CheckForNewerVersion(CurrentVersion As String)
        ' Version example '2024.2' or '2024.2.1' but the last number is currently ignored for this check
        ' tag_name example '"tag_name":"v2024.1"'

        Dim tf As Boolean
        Dim s As String = ""
        Dim NewList As New List(Of String)

        Dim CurrentYear As Integer
        Dim NewYear As Integer
        Dim CurrentIdx As Integer
        Dim NewIdx As Integer

        Dim DoubleQuote As Char = Chr(34)

        Dim CurrentVersionList As List(Of String) = CurrentVersion.Split(CChar(".")).ToList

        CurrentYear = CInt(CurrentVersionList(0))
        CurrentIdx = CInt(CurrentVersionList(1))

        ' https://stackoverflow.com/questions/70185058/how-to-replace-obsolete-webclient-with-httpclient-in-net-6
        Dim HttpClient As New HttpClient
        HttpClient.DefaultRequestHeaders.Add("User-Agent", {"Other"}.ToList)
        Dim Request = New HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/rmcanany/solidedgestorekeeper/releases/latest")
        Dim Response = HttpClient.Send(Request)
        Dim Reader = New IO.StreamReader(Response.Content.ReadAsStream())
        s = Reader.ReadToEnd
        Reader.Close()

        NewList = s.Split(CChar(",")).ToList

        For Each s In NewList
            If s.Contains("tag_name") Then
                Exit For
            End If
        Next

        If Not s.Contains("tag_name") Then Exit Sub

        s = s.ToLower
        s = s.Replace(DoubleQuote, "")  ' '"tag_name":"v2024.1"' -> 'tag_name:v2024.1'
        s = s.Split(CChar(":"))(1)      ' 'tag_name:v2024.1' -> 'v2024.1'
        s = s.Replace("v", "")          ' 'v2024.1' -> '2024.1'

        Dim NewVersion As String = s

        Dim NewVersionList As List(Of String) = NewVersion.Split(CChar(".")).ToList

        NewYear = CInt(NewVersionList(0))
        NewIdx = CInt(NewVersionList(1))

        tf = NewYear > CurrentYear
        tf = tf Or (NewYear = CurrentYear) And (NewIdx > CurrentIdx)

        If tf Then
            Dim FNVA As New FormNewVersionAvailable(CurrentVersion, NewVersion)
            FNVA.ShowDialog()
        End If


    End Sub

    Public Sub CheckVersionFormat(Version As String)
        Dim s As String = ""
        Dim indent As String = "    "

        Dim CurrentVersionList As List(Of String) = Version.Split(CChar(".")).ToList
        If Not CurrentVersionList.Count = 2 Then
            If CurrentVersionList.Count = 3 Then
                ' OK
            Else
                s = String.Format("{0}Version incorrect format.  Should be 'YYYY.N', not '{1}'{2}", s, Version, vbCrLf)
            End If
        Else
            Try
                Dim i As Integer
                i = CInt(CurrentVersionList(0))
                i = CInt(CurrentVersionList(1))
            Catch ex As Exception
                s = String.Format("{0}Version incorrect format.  '{1}' contains at least one non-integer{2}", s, Version, vbCrLf)
            End Try
        End If
        If Not s = "" Then
            MsgBox(s, vbOKOnly)
        End If

    End Sub


End Class
