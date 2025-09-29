Option Strict On
'Imports System.Security.AccessControl
Imports Newtonsoft.Json

Public Class HCPropertiesCache

    Public Property Items As List(Of FileCache)

    Private Property PropertiesData As HCPropertiesData
    Private Property FMain As Form_Main

    Public Sub New(_FMain As Form_Main)
        Me.FMain = _FMain

        Me.PropertiesData = Me.FMain.PropertiesData
        Me.Items = New List(Of FileCache)

        '###### Load saved PropertiesCache, if any ######

        Dim UP As New UtilsPreferences
        Dim Infile As String = UP.GetPropertiesCacheFilename(CheckExisting:=True)

        If Not Infile = "" Then
            Dim JSONString As String = IO.File.ReadAllText(Infile)

            Dim tmpList As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(JSONString)

            For Each PropertyCacheJSON As String In tmpList
                Try
                    Items.Add(New FileCache(PropertyCacheJSON))

                    Dim tmpFilename As String = Items(Items.Count - 1).Filename
                    Me.FMain.TextBoxStatus.Text = $"Retreiving cached properties {IO.Path.GetFileName(tmpFilename)}"
                    System.Windows.Forms.Application.DoEvents()

                Catch ex As Exception
                    Items.Clear()

                    Dim s As String = String.Format("Unable to load cached Property information.{0}", vbCrLf)
                    s = String.Format("{0}Reported error: {1}{2}", s, ex.Message, vbCrLf)
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            Next
        End If

    End Sub

    Public Sub Save()
        Dim UP As New UtilsPreferences
        Dim Outfile As String = UP.GetPropertiesCacheFilename(CheckExisting:=False)

        Dim JSONString As String
        Dim tmpList As New List(Of String)

        For Each Item As FileCache In Me.Items
            tmpList.Add(Item.ToJSON)
        Next

        JSONString = JsonConvert.SerializeObject(tmpList)

        IO.File.WriteAllText(Outfile, JSONString)

    End Sub

    Public Function Update(Filenames As List(Of String), ErrorLogger As Logger) As Boolean

        Dim Success As Boolean = True
        Dim SSDoc As HCStructuredStorageDoc = Nothing

        For Each Filename As String In Filenames

            Me.FMain.TextBoxStatus.Text = $"Check for changed files {IO.Path.GetFileName(Filename)}"
            System.Windows.Forms.Application.DoEvents()

            Dim tmpFileCache As FileCache = GetFileCache(Filename)
            Dim SystemModifiedDate = IO.File.GetLastWriteTimeUtc(Filename)

            If tmpFileCache IsNot Nothing Then

                ' Times in one test had a difference of 0.008s, even though the source was SystemModifiedDate for both
                Dim TimeDiff = (SystemModifiedDate - tmpFileCache.ModifiedDate).TotalSeconds
                TimeDiff = Math.Abs(TimeDiff)
                If TimeDiff < 1 Then
                    ' No action needed
                    'SSDoc.Close()
                    Continue For
                End If

                Try
                    SSDoc = New HCStructuredStorageDoc(Filename, _OpenReadWrite:=False)
                    SSDoc.ReadProperties(Me.PropertiesData)
                Catch ex As Exception
                    If SSDoc IsNot Nothing Then SSDoc.Close()
                    Success = False
                    ErrorLogger.AddMessage($"Could not process {Filename}")
                    ErrorLogger.AddMessage($"Error message was {ex}")
                    Continue For
                End Try

                ' Loop through all known properties and update the cache with current values in the file
                For Each PropertyData As PropertyData In Me.PropertiesData.Items

                    Dim PropertySetName As String = ""
                    Select Case PropertyData.PropertySetName
                        Case PropertyData.PropertySetNameConstants.Custom
                            PropertySetName = "Custom"
                        Case PropertyData.PropertySetNameConstants.System
                            PropertySetName = "System"
                        Case Else

                    End Select

                    Dim NewValue = SSDoc.GetPropValue(PropertySetName, PropertyData.EnglishName)
                    If NewValue IsNot Nothing Then
                        Dim tmpPropCache As PropCache = tmpFileCache.GetPropCache(PropertySetName, PropertyData.EnglishName)
                        If tmpPropCache IsNot Nothing Then
                            If tmpPropCache.Value IsNot Nothing Then
                                tmpPropCache.Value = NewValue
                            Else
                                tmpPropCache.Value = ""
                            End If
                        Else
                            ' Add it
                            tmpFileCache.AddPropCache(PropertySetName, PropertyData.EnglishName, CStr(PropertyData.TypeName), NewValue)
                        End If
                    End If
                Next


            Else
                ' Add it
                Try
                    SSDoc = New HCStructuredStorageDoc(Filename, _OpenReadWrite:=False)
                    SSDoc.ReadProperties(Me.PropertiesData)
                Catch ex As Exception
                    If SSDoc IsNot Nothing Then SSDoc.Close()
                    Success = False
                    ErrorLogger.AddMessage($"Could not process {Filename}")
                    ErrorLogger.AddMessage($"Error message was {ex}")
                    Continue For
                End Try

                tmpFileCache = New FileCache(Filename, SystemModifiedDate)
                tmpFileCache.PopulateProps(SSDoc)
                Me.Items.Add(tmpFileCache)
            End If

            If SSDoc IsNot Nothing Then SSDoc.Close()

        Next

        ' Check for files in the cache that are not in the file list

        For i = Me.Items.Count - 1 To 0 Step -1
            Dim tmpFilename As String = Me.Items(i).Filename

            Me.FMain.TextBoxStatus.Text = $"Check for unused files {IO.Path.GetFileName(tmpFilename)}"
            System.Windows.Forms.Application.DoEvents()

            If Not Filenames.Contains(Me.Items(i).Filename) Then
                Items.RemoveAt(i)
            End If
        Next


        If Success Then Save()

        Return Success
    End Function

    Public Function GetPropType(Filename As String, PropName As String) As String
        Dim TypeName As String = Nothing

        For Each PropertyCache As FileCache In Items
            For Each PropCache As PropCache In PropertyCache.PropCaches
                If PropName = PropCache.EnglishName Then
                    TypeName = PropCache.TypeName
                    Exit For
                End If
            Next
            If TypeName IsNot Nothing Then Exit For
        Next

        Return TypeName
    End Function

    Public Function GetPropValue(Filename As String, PropSetName As String, EnglishName As String) As Object
        Dim Value As Object = Nothing

        PropSetName = PropSetName.ToLower
        EnglishName = EnglishName.ToLower

        Dim FileCache As FileCache = GetFileCache(Filename)
        If FileCache IsNot Nothing Then
            For Each PropCache As PropCache In FileCache.PropCaches
                If PropSetName = PropCache.PropertySetName.ToLower And EnglishName = PropCache.EnglishName.ToLower Then
                    Value = PropCache.Value
                    Exit For
                End If
            Next
        End If
        'For Each PropertyCache As FileCache In Items
        '    If Value IsNot Nothing Then Exit For
        'Next

        Return Value
    End Function

    Private Function GetFileCache(Filename As String) As FileCache
        Dim tmpFileCache As FileCache = Nothing

        For Each FileCache As FileCache In Items
            If FileCache.Filename = Filename Then
                tmpFileCache = FileCache
                Exit For
            End If
        Next

        Return tmpFileCache
    End Function

    Private Function ContainsFilename(Filename As String) As Boolean
        Dim Contains As Boolean = False

        For Each FileCache As FileCache In Items
            If FileCache.Filename = Filename Then
                Contains = True
            End If
        Next

        Return Contains
    End Function
End Class

Public Class FileCache

    Public Property Filename As String
    Public Property ModifiedDate As DateTime
    Public Property PropCaches As List(Of PropCache)

    Public Sub New(JSONString As String)
        FromJSON(JSONString)
    End Sub

    Public Sub New(_Filename As String, _ModifiedDate As DateTime)
        Me.Filename = _Filename
        Me.ModifiedDate = _ModifiedDate
        Me.PropCaches = New List(Of PropCache)
    End Sub

    Public Sub AddPropCache(
        PropertySetName As String,
        EnglishName As String,
        TypeName As String,
        Value As Object)

        If GetPropCache(PropertySetName, EnglishName) Is Nothing Then
            Me.PropCaches.Add(New PropCache(PropertySetName, EnglishName, TypeName, Value))
        End If
    End Sub

    Public Function GetPropCache(PropertySetName As String, EnglishName As String) As PropCache
        Dim tmpPropCache As PropCache = Nothing

        For Each PropCache As PropCache In PropCaches
            If PropCache.PropertySetName = PropertySetName And PropCache.EnglishName = EnglishName Then
                tmpPropCache = PropCache
                Exit For
            End If
        Next

        Return tmpPropCache
    End Function

    Public Sub PopulateProps(SSDoc As HCStructuredStorageDoc)
        Me.PropCaches.Clear()

        Dim PropTuples As List(Of Tuple(Of String, String, String, Object)) = SSDoc.GetAllProps()
        Dim PropertySetName As String = ""

        For Each PropTuple As Tuple(Of String, String, String, Object) In PropTuples
            Dim PropertySetActualName As String = PropTuple.Item1
            Dim PropertyNameEnglish As String = PropTuple.Item2
            Dim TypeName As String = PropTuple.Item3
            Dim Value As Object = PropTuple.Item4

            If PropertySetActualName = "Custom" Then
                PropertySetName = "Custom"
            Else
                PropertySetName = "System"
            End If

            PropCaches.Add(New PropCache(PropertySetName, PropertyNameEnglish, TypeName, Value))
        Next

    End Sub

    Public Function ToJSON() As String

        Dim JSONString As String

        Dim tmpDict As New Dictionary(Of String, String)

        tmpDict("Filename") = Me.Filename
        tmpDict("ModifiedDate") = CStr(Me.ModifiedDate)

        Dim PropCachesList As New List(Of String)

        For Each PropCache As PropCache In Me.PropCaches
            PropCachesList.Add(PropCache.ToJSON)
        Next

        Dim PropCachesListJSON As String = JsonConvert.SerializeObject(PropCachesList)

        tmpDict("PropCachesListJSON") = PropCachesListJSON

        JSONString = JsonConvert.SerializeObject(tmpDict)

        Return JSONString

    End Function

    Public Sub FromJSON(JSONString As String)

        Me.PropCaches = New List(Of PropCache)

        Dim tmpDict As Dictionary(Of String, String)

        tmpDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(JSONString)

        Try
            Me.Filename = tmpDict("Filename")
            Me.ModifiedDate = CType(tmpDict("ModifiedDate"), DateTime)

            Dim PropCachesListJSON As String = tmpDict("PropCachesListJSON")
            Dim PropCachesList As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(PropCachesListJSON)

            For Each PropCacheJSON As String In PropCachesList
                Me.PropCaches.Add(New PropCache(PropCacheJSON))
            Next

        Catch ex As Exception
            Dim i = 0
        End Try

    End Sub

End Class

Public Class PropCache

    Public PropertySetName As String
    Public Property EnglishName As String
    Public Property TypeName As String
    Public Property Value As Object

    'Public Enum TypeNameConstants
    '    ' Preceeding names with '_' to avoid VB reserved keywords
    '    _String
    '    _Integer
    '    _Double
    '    _Boolean
    '    _DateTime
    '    _Unknown
    'End Enum

    Public Sub New(JSONString As String)
        FromJSON(JSONString)
    End Sub

    Public Sub New(_PropertySetName As String, _EnglishName As String, _TypeName As String, _Value As Object)

        Me.PropertySetName = _PropertySetName
        Me.EnglishName = _EnglishName

        If _TypeName IsNot Nothing Then
            Me.TypeName = _TypeName
        Else
            Me.TypeName = ""
        End If

        If _Value IsNot Nothing Then
            Me.Value = _Value
        Else
            Me.Value = ""
        End If

    End Sub

    Public Function ToJSON() As String

        Dim JSONString As String

        Dim tmpDict As New Dictionary(Of String, String)

        tmpDict("PropertySetName") = Me.PropertySetName
        tmpDict("EnglishName") = Me.EnglishName
        tmpDict("TypeName") = Me.TypeName

        If Me.Value IsNot Nothing Then
            tmpDict("Value") = Me.Value.ToString
        Else
            tmpDict("Value") = ""
        End If

        JSONString = JsonConvert.SerializeObject(tmpDict)

        Return JSONString
    End Function

    Public Sub FromJSON(JSONString As String)

        Dim UC As New UtilsCommon

        Dim tmpDict As Dictionary(Of String, String)

        tmpDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(JSONString)

        Try
            Me.PropertySetName = tmpDict("PropertySetName")
            Me.EnglishName = tmpDict("EnglishName")
            If tmpDict("TypeName") IsNot Nothing Then
                Me.TypeName = tmpDict("TypeName")
            Else
                Me.TypeName = ""
            End If

            If tmpDict("Value") Is Nothing Then
                Me.Value = ""
            Else
                Select Case Me.TypeName.ToLower
                    Case "string"
                        Me.Value = tmpDict("Value")
                    Case "int32"
                        Me.Value = CInt(tmpDict("Value"))
                    Case "double"
                        Me.Value = CDbl(UC.FixLocaleDecimal(tmpDict("Value")))
                    Case "boolean"
                        Me.Value = CBool(tmpDict("Value"))
                    Case "datetime"
                        Me.Value = CType(tmpDict("Value"), DateTime)
                    Case Else
                        Me.Value = ""
                        'MsgBox($"HCPropertiesCache PropCache FromJSON: TypeName not recognized '{Me.TypeName}'", vbOKOnly)
                End Select
            End If

        Catch ex As Exception
            Dim i = 0
        End Try

    End Sub

End Class
