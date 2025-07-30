Option Strict On
Imports System.Security.AccessControl

Public Class HCPropertiesCache

    Public Property Items As List(Of FileCache)

    Private Property PropertiesData As HCPropertiesData

    Public Sub New(_FMain As Form_Main)
        Me.PropertiesData = _FMain.PropertiesData
        Me.Items = New List(Of FileCache)
    End Sub

    Public Function Update(Filenames As List(Of String), ErrorLogger As Logger) As Boolean

        Dim Success As Boolean = True
        Dim SSDoc As HCStructuredStorageDoc = Nothing

        For Each Filename As String In Filenames
            Try
                SSDoc = New HCStructuredStorageDoc(Filename, _OpenReadWrite:=False)
                SSDoc.ReadProperties(Me.PropertiesData)
            Catch ex As Exception
                If SSDoc IsNot Nothing Then SSDoc.Close()
                Success = False
                ErrorLogger.AddMessage($"Could not process {Filename}")
                ErrorLogger.AddMessage($"Error message was {ex}")
            End Try

            If Success Then
                Dim tmpFileCache As FileCache = GetFileCache(Filename)
                Dim SSDocModifiedDate As DateTime = CDate(SSDoc.GetPropValue("System", "Last Save Date"))

                If tmpFileCache IsNot Nothing Then

                    If SSDocModifiedDate > tmpFileCache.ModifiedDate Then
                        ' No action needed
                        SSDoc.Close()
                        Continue For
                    Else

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
                                    tmpPropCache.Value = NewValue
                                Else
                                    ' Add it
                                    tmpFileCache.AddPropCache(PropertySetName, PropertyData.EnglishName, CStr(PropertyData.TypeName), NewValue)
                                End If
                            End If
                        Next

                    End If


                Else
                    ' Add it
                    tmpFileCache = New FileCache(Filename, SSDocModifiedDate)
                    tmpFileCache.PopulateProps(SSDoc)
                End If

            End If
            If SSDoc IsNot Nothing Then SSDoc.Close()

        Next

        ' Check for files in the cache that are not in the file list

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

    Public Function GetPropValue(Filename As String, PropName As String) As Object
        Dim Value As Object = Nothing

        For Each PropertyCache As FileCache In Items
            For Each PropCache As PropCache In PropertyCache.PropCaches
                If PropName = PropCache.EnglishName Then
                    Value = PropCache.Value
                    Exit For
                End If
            Next
            If Value IsNot Nothing Then Exit For
        Next

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
End Class

Public Class PropCache

    Public PropertySetName As String
    Public Property EnglishName As String
    Public Property TypeName As String
    Public Property Value As Object

    Public Sub New(_PropertySetName As String, _EnglishName As String, _TypeName As String, _Value As Object)

        Me.PropertySetName = _PropertySetName
        Me.EnglishName = _EnglishName
        Me.TypeName = _TypeName
        Me.Value = _Value

    End Sub

End Class
