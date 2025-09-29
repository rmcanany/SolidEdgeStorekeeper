Option Strict On

Imports System.Net.Http
Imports System.Security.AccessControl
Imports Newtonsoft.Json
Imports SolidEdgeAssembly

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

        Dim s As String = ""

        Dim SkipProps As New List(Of String)
        SkipProps.AddRange({"hcpropertiesdata", "logger", "hcpropertiescache", "xmldocument", "application", "assemblydocument"})

        For Each PropInfo As System.Reflection.PropertyInfo In PropInfos

            PropType = PropInfo.PropertyType.Name.ToLower

            Dim tf As Boolean
            tf = PropInfo.Module.ToString.ToLower.Contains("storekeeper")
            tf = tf Or {"Left", "Top", "Width", "Height"}.ToList.Contains(PropInfo.Name)

            If Not tf Then Continue For
            If SkipProps.Contains(PropType) Then Continue For

            Value = Nothing

            Select Case PropType
                Case "string", "double", "int32", "boolean"
                    Value = CStr(PropInfo.GetValue(FMain, Nothing))
                Case "list`1"
                    Value = JsonConvert.SerializeObject(PropInfo.GetValue(FMain, Nothing))
                    'Case "hcpropertiesdata", "logger"
                    '    ' Nothing to do here.  HCPropertiesData is saved separately.
                    'Case "hcpropertiescache"
                    '    ' Nothing to do here.  HCPropertiesCache is saved separately.
                Case Else
                    If s = "" Then
                        s = $"In UtilsPreferences.SaveFormMainSettings: PropInfo.PropertyType.Name not recognized{vbCrLf}"
                    End If
                    s = $"{s}    '{PropInfo.PropertyType.Name}'{vbCrLf}"
                    'MsgBox(String.Format("PropInfo.PropertyType.Name '{0}' not recognized", PropType))
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
                        'Case "hcpropertiesdata", "logger"
                        '    ' Nothing to do here.  HCPropertiesData is saved separately.
                        'Case "hcpropertiescache"
                        '    ' Nothing to do here.  HCPropertiesCache is saved separately.
                    Case Else
                        'MsgBox(String.Format("In UtilsPreferences.SaveFormMainSettings: PropInfo.PropertyType.Name '{0}' not recognized", PropInfo.PropertyType.Name))
                End Select
            End If

            If Value IsNot Nothing Then
                tmpJSONDict(PropInfo.Name) = Value
            End If

        Next

        If Not s = "" Then
            MsgBox(s)
        End If
        JSONString = JsonConvert.SerializeObject(tmpJSONDict)

        IO.File.WriteAllText(Outfile, JSONString)


    End Sub

    Public Sub GetFormMainSettings(FMain As Form_Main)

        Dim tmpJSONDict As New Dictionary(Of String, String)
        Dim JSONString As String

        Dim UC As New UtilsCommon

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
                            PropInfo.SetValue(FMain, CDbl(UC.FixLocaleDecimal(tmpJSONDict(PropInfo.Name))))
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

                Dim tmpDir As String
                Dim SuffixList As New List(Of String)
                SuffixList.AddRange({"SE2019", "SE2024"})

                For Each Suffix As String In SuffixList
                    tmpDir = $"{PreferencesDirectory}\Data{Suffix}"
                    FileIO.FileSystem.CreateDirectory(tmpDir)
                    FileIO.FileSystem.CopyDirectory(GetDefaultDataDirectory(Suffix), tmpDir)
                    If Suffix = "SE2024" Then FMain.DataDirectory = tmpDir

                    tmpDir = $"{PreferencesDirectory}\Templates{Suffix}"
                    FileIO.FileSystem.CreateDirectory(tmpDir)
                    FileIO.FileSystem.CopyDirectory(GetDefaultTemplatesDirectory(Suffix), tmpDir)
                    If Suffix = "SE2024" Then FMain.TemplateDirectory = tmpDir
                Next

                tmpDir = $"{PreferencesDirectory}\Library"
                FileIO.FileSystem.CreateDirectory(tmpDir)
                FMain.LibraryDirectory = tmpDir

            Catch ex As Exception
                Dim s As String = String.Format("Unable to create Preferences directory '{0}'.  ", PreferencesDirectory)
                s = String.Format("{0}You may not have the correct permissions.", s)
                MsgBox(s, vbOKOnly)
            End Try
        End If
    End Sub

    Public Function GetDefaultDataDirectory(Suffix As String) As String
        Dim StartupPath As String = GetStartupDirectory()
        Dim DefaultDataDirectory = $"DefaultData{Suffix}"
        Return String.Format("{0}\{1}", StartupPath, DefaultDataDirectory)
    End Function

    Public Function GetDefaultTemplatesDirectory(Suffix As String) As String
        Dim StartupPath As String = GetStartupDirectory()
        Dim DefaultTemplatesDirectory = $"DefaultTemplates{Suffix}"
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

        Try
            ' https://stackoverflow.com/questions/70185058/how-to-replace-obsolete-webclient-with-httpclient-in-net-6
            Dim HttpClient As New HttpClient
            HttpClient.DefaultRequestHeaders.Add("User-Agent", {"Other"}.ToList)
            Dim Request = New HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/rmcanany/solidedgestorekeeper/releases/latest")
            Dim Response = HttpClient.Send(Request)
            Dim Reader = New IO.StreamReader(Response.Content.ReadAsStream())
            s = Reader.ReadToEnd
            Reader.Close()
        Catch ex As Exception
            Exit Sub
        End Try

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


    '###### FORM FASTENER STACK ######

    Public Function GetFormFastenerStackSettingsFilename(CheckExisting As Boolean) As String
        Dim Filename = "form_fastener_stack.json"
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

    Public Sub SaveFormFastenerStackSettings(FFS As FormFastenerStack)

        Dim tmpJSONDict As New Dictionary(Of String, String)
        Dim JSONString As String

        Dim Outfile = GetFormFastenerStackSettingsFilename(CheckExisting:=False)

        Dim FormType As Type = FFS.GetType()
        Dim PropInfos = New List(Of System.Reflection.PropertyInfo)(FormType.GetProperties())
        Dim Value As String
        Dim PropType As String

        Dim s As String = ""

        For Each PropInfo As System.Reflection.PropertyInfo In PropInfos

            PropType = PropInfo.PropertyType.Name.ToLower

            Dim tf As Boolean
            tf = PropInfo.Module.ToString.ToLower.Contains("storekeeper")
            'tf = tf Or {"Left", "Top", "Width", "Height"}.ToList.Contains(PropInfo.Name)

            If Not tf Then Continue For
            If {"FastenerFilename", "FlatWasherFilename", "LockWasherFilename", "NutFilename"}.ToList.Contains(PropInfo.Name) Then Continue For
            If PropType = "form_main" Then Continue For

            Value = Nothing

            Select Case PropType
                Case "string", "double", "int32", "boolean"
                    Value = CStr(PropInfo.GetValue(FFS, Nothing))
                Case "stackconfigurationconstants"
                    Value = CStr(CInt(PropInfo.GetValue(FFS, Nothing)))
                Case "list`1"
                    Value = JsonConvert.SerializeObject(PropInfo.GetValue(FFS, Nothing))
                Case Else
                    'MsgBox(String.Format("PropInfo.PropertyType.Name '{0}' not recognized", PropType))
            End Select


            If Value Is Nothing Then
                Select Case PropType
                    Case "string"
                        Value = ""
                    Case "double", "int32"
                        Value = "0"
                    Case "boolean"
                        Value = "False"
                    Case "stackconfigurationconstants"
                        Value = "0"
                    Case "list`1"
                        Value = JsonConvert.SerializeObject(New List(Of String))
                        MsgBox(String.Format("PropInfo.PropertyType.Name '{0}' detected", PropInfo.PropertyType.Name))
                    Case Else
                        If s = "" Then
                            s = $"In UtilsPreferences.SaveFormMainSettings: PropInfo.PropertyType.Name not recognized{vbCrLf}"
                        End If
                        s = $"{s}    '{PropInfo.PropertyType.Name}'{vbCrLf}"
                        'MsgBox(String.Format("In UtilsPreferences.SaveFormMainSettings: PropInfo.PropertyType.Name '{0}' not recognized", PropInfo.PropertyType.Name))
                End Select
            End If

            If Value IsNot Nothing Then
                tmpJSONDict(PropInfo.Name) = Value
            End If

        Next

        If Not s = "" Then
            MsgBox(s)
        End If

        JSONString = JsonConvert.SerializeObject(tmpJSONDict)

        IO.File.WriteAllText(Outfile, JSONString)


    End Sub

    Public Sub GetFormFastenerStackSettings(FFS As FormFastenerStack)

        Dim tmpJSONDict As New Dictionary(Of String, String)
        Dim JSONString As String

        Dim UC As New UtilsCommon

        Dim Infile = GetFormFastenerStackSettingsFilename(CheckExisting:=True)

        Dim FormType As Type = FFS.GetType()
        Dim PropInfos = New List(Of System.Reflection.PropertyInfo)(FormType.GetProperties())

        If Not Infile = "" Then
            JSONString = IO.File.ReadAllText(Infile)

            tmpJSONDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(JSONString)

            For Each PropInfo As System.Reflection.PropertyInfo In PropInfos

                'If PropInfo.Name = "Width" Then
                '    MsgBox($"{tmpJSONDict(PropInfo.Name)} {FFS.Width}")
                'End If


                If tmpJSONDict.Keys.Contains(PropInfo.Name) Then
                    Dim PropTypestring = PropInfo.PropertyType.Name

                    Select Case PropInfo.PropertyType.Name.ToLower
                        Case "string"
                            PropInfo.SetValue(FFS, CStr(tmpJSONDict(PropInfo.Name)))
                        Case "double"
                            PropInfo.SetValue(FFS, CDbl(UC.FixLocaleDecimal(tmpJSONDict(PropInfo.Name))))
                        Case "int32"
                            PropInfo.SetValue(FFS, CInt(tmpJSONDict(PropInfo.Name)))
                        Case "boolean"
                            PropInfo.SetValue(FFS, CBool(tmpJSONDict(PropInfo.Name)))
                        Case "stackconfigurationconstants"
                            PropInfo.SetValue(FFS, CInt(tmpJSONDict(PropInfo.Name)))
                            Dim i = 0
                        Case "list`1"
                            Dim L = JsonConvert.DeserializeObject(Of List(Of String))(tmpJSONDict(PropInfo.Name))
                            PropInfo.SetValue(FFS, L)
                    End Select

                End If
            Next
        End If

    End Sub


    '###### FASTENER STACK XML SEARCH PATHS ######

    'Private Function GetSearchPathFilename(ComponentType As String, DataVersion As String) As String
    '    Dim Filename As String = Nothing

    '    Select Case ComponentType
    '        Case "FlatWasher", "LockWasher", "Nut"
    '            Filename = $"{GetPreferencesDirectory()}\{ComponentType}"
    '        Case Else
    '            MsgBox($"UP.GetSearchPathFilename: Unrecognized ComponentType '{ComponentType}'")
    '            Filename = Nothing
    '    End Select

    '    Select Case DataVersion
    '        Case "SE2019", "SE2024"
    '            If Filename IsNot Nothing Then Filename = $"{Filename}{DataVersion}.json"
    '        Case Else
    '            MsgBox($"UP.GetSearchPathFilename: Unrecognized DataVersion '{DataVersion}'")
    '    End Select

    '    If Filename IsNot Nothing AndAlso Not IO.File.Exists(Filename) Then
    '        Dim Success As Boolean = CreateSearchPathFiles()
    '        If Not Success Then Filename = Nothing
    '    End If

    '    Return Filename
    'End Function

    Public Function CreateSearchPathFiles() As Boolean
        Dim Success As Boolean = True

        Dim ComponentTypes As New List(Of String)
        ComponentTypes.AddRange({"FlatWasher", "LockWasher", "Nut"})

        Dim DataVersions As New List(Of String)
        DataVersions.AddRange({"SE2019", "SE2024"})

        Dim SearchPathList As New List(Of String)
        Dim BareFilename As String
        Dim Filename As String

        For Each ComponentType As String In ComponentTypes
            For Each DataVersion As String In DataVersions

                SearchPathList.Clear()
                BareFilename = $"{ComponentType}{DataVersion}"

                Select Case BareFilename
                    Case "FlatWasherSE2019"
                        SearchPathList.Add("..\..\..\..\..\ISO_DIN_WASHERS\ISO_7089_-_Plain_washers_-_Normal_series")
                    Case "LockWasherSE2019"
                        SearchPathList.Add("..\..\..\..\..\OTHER_-_Steel\ISO_2982-2_-_Lockwashers")
                    Case "NutSE2019"
                        SearchPathList.Add("..\..\..\..\..\ISO_DIN_NUTS\Hexagonal\ISO_4032_-_Hexagon_regular_nuts")
                        SearchPathList.Add("..\..\..\..\..\ISO_DIN_NUTS\Hexagonal\ISO_8673_-_Hexagon_regular_nuts_-_fine_pitch")
                    Case "FlatWasherSE2024"
                        SearchPathList.Add("..\..\..\Washer_Flat")
                    Case "LockWasherSE2024"
                        SearchPathList.Add("..\..\..\Washer_Lock")
                    Case "NutSE2024"
                        SearchPathList.Add("..\..\..\Nut_Hex")

                End Select

                Filename = $"{GetPreferencesDirectory()}\{BareFilename}.json"

                If Not IO.File.Exists(Filename) Then
                    If SearchPathList.Count > 0 Then
                        Dim JSONString = JsonConvert.SerializeObject(SearchPathList)
                        IO.File.WriteAllText(Filename, JSONString)
                    End If
                End If
            Next
        Next
        Return Success
    End Function

    Public Function GetFlatWasherSearchPath(DataVersion As String) As List(Of String)
        Dim OutList As List(Of String) = Nothing

        Dim Filename As String = $"{GetPreferencesDirectory()}\FlatWasher{DataVersion}.json"
        If IO.File.Exists(Filename) Then
            Dim JSONString = IO.File.ReadAllText(Filename)
            OutList = JsonConvert.DeserializeObject(Of List(Of String))(JSONString)
        End If

        Return OutList
    End Function

    Public Function GetLockWasherSearchPath(DataVersion As String) As List(Of String)
        Dim OutList As List(Of String) = Nothing

        Dim Filename As String = $"{GetPreferencesDirectory()}\LockWasher{DataVersion}.json"
        If IO.File.Exists(Filename) Then
            Dim JSONString = IO.File.ReadAllText(Filename)
            OutList = JsonConvert.DeserializeObject(Of List(Of String))(JSONString)
        End If

        Return OutList
    End Function

    Public Function GetNutSearchPath(DataVersion As String) As List(Of String)
        Dim OutList As List(Of String) = Nothing

        Dim Filename As String = $"{GetPreferencesDirectory()}\Nut{DataVersion}.json"
        If IO.File.Exists(Filename) Then
            Dim JSONString = IO.File.ReadAllText(Filename)
            OutList = JsonConvert.DeserializeObject(Of List(Of String))(JSONString)
        End If

        Return OutList
    End Function

End Class
