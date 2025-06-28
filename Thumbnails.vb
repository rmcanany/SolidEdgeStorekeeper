' Code by Calum McLellan 9/2/2009 10:06:46 AM
' https://community.sw.siemens.com/s/question/0D54O000061xolGSAQ/thumbnail

Option Strict On

Imports System.IO
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Text

Friend Class Thumbnails

    Private Shared ReadOnly IID_ISHELLFOLDER As New Guid("000214E6-0000-0000-C000-000000000046")
    Private Shared ReadOnly IID_IEXTRACTIMAGE As New Guid("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1")

    Public Shared Function ExtractThumbNail(ByVal file As FileInfo) As Bitmap
        Return ExtractThumbNail(file, New System.Drawing.Size(100, 100))
    End Function

    Public Shared Function ExtractThumbNail(ByVal file As FileInfo, ByVal imageSize As Size) As Bitmap

        ' The native size of the extracted thumbnail appears to be 100x100 pixels
        ' Specifing a larger size pads with white space
        ' A smaller size crops
        ' The aspect ratio of an SE thumbnail appears to be 4:3
        ' So specifying a size of 100, 75 gets a clean image

        Dim thumbnail As Bitmap = Nothing
        'Dim alloc As IMalloc = Nothing
        Dim folder As IShellFolder = Nothing
        Dim item As IShellFolder = Nothing
        Dim pidlFolder As IntPtr = IntPtr.Zero
        Dim hBmp As IntPtr = IntPtr.Zero
        Dim tmpExtractImage As Object = Nothing
        Dim extractImage As IExtractImage = Nothing
        Dim pidl As IntPtr = IntPtr.Zero

        If (file.Exists) Then

            Try
                SHGetDesktopFolder(folder)

                If Not folder Is Nothing Then

                    Dim cParsed As Integer = 0
                    Dim pdwAttrib As Integer = 0

                    Dim HR As Integer = folder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero,
                     file.Directory.FullName, cParsed, pidlFolder,
                     pdwAttrib)
                    If HR < S_OK Then Return Nothing

                    If Not pidlFolder.Equals(IntPtr.Zero) Then

                        HR = folder.BindToObject(pidlFolder, IntPtr.Zero,
                            IID_ISHELLFOLDER, item)
                        If HR < S_OK Then Return Nothing

                        If Not item Is Nothing Then

                            HR = item.ParseDisplayName(IntPtr.Zero, IntPtr.Zero,
                                    file.Name, 0, pidl, 0)
                            Marshal.ThrowExceptionForHR(HR)

                            Dim prgf As Integer = 0
                            HR = item.GetUIObjectOf(0, 1, New IntPtr() {pidl},
                                IID_IEXTRACTIMAGE, prgf, tmpExtractImage)
                            If HR < S_OK Then Return Nothing

                            If Not tmpExtractImage Is Nothing Then

                                extractImage = CType(tmpExtractImage, IExtractImage)
                                Dim location As New StringBuilder(MAX_PATH, MAX_PATH)

                                Dim priority As Integer = 0
                                Dim requestedColorDepth As Integer = 32

                                Dim uFlags As Integer = IEIFLAG.IEIFLAG_ASPECT Or
                                    IEIFLAG.IEIFLAG_ORIGSIZE Or IEIFLAG.IEIFLAG_QUALITY

                                HR = extractImage.GetLocation(location, location.Capacity,
                                        priority, imageSize, requestedColorDepth,
                                        uFlags)
                                If HR < S_OK Then Return Nothing

                                HR = extractImage.Extract(hBmp)
                                If HR < S_OK Then Return Nothing
                                If Not hBmp.Equals(IntPtr.Zero) Then
                                    thumbnail = Bitmap.FromHbitmap(hBmp)
                                End If
                            End If
                        End If
                    End If
                End If
            Finally

                If Not hBmp.Equals(IntPtr.Zero) Then DeleteObject(hBmp)
                If Not pidlFolder.Equals(IntPtr.Zero) Then
                    Marshal.FreeCoTaskMem(pidlFolder)
                End If
                If Not extractImage Is Nothing Then
                    Marshal.ReleaseComObject(extractImage)
                    extractImage = Nothing
                End If
                If Not item Is Nothing Then
                    Marshal.ReleaseComObject(item)
                    item = Nothing
                End If
                If Not folder Is Nothing Then
                    Marshal.ReleaseComObject(folder)
                    folder = Nothing
                End If
            End Try
        End If
        Return thumbnail
    End Function

    Private Const S_OK As Integer = 0
    Public Shared ReadOnly IID_ContextMenu As New Guid("000214e4-0000-0000-c000-000000000046")

    Private Const MAX_PATH As Integer = 260

    <DllImport("gdi32", CharSet:=CharSet.Auto)> _
    Private Shared Function DeleteObject(ByVal hObject As IntPtr) As Integer
    End Function

    Private Declare Auto Function SHGetDesktopFolder Lib "shell32" ( _
            ByRef ppshf As IShellFolder) As Integer

End Class

<ComImportAttribute(), _
GuidAttribute("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1"), _
InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
Friend Interface IExtractImage

    <PreserveSig()> _
     Function GetLocation(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszPathBuffer As StringBuilder, _
     ByVal cch As Integer, ByRef pdwPriority As Integer, ByRef prgSize As Size, _
     ByVal dwRecClrDepth As Integer, ByRef pdwFlags As Integer) As Integer

    <PreserveSig()> _
    Function Extract(<Out()> ByRef phBmpThumbnail As IntPtr) As Integer

End Interface

<ComImportAttribute(), _
 InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), _
 Guid("000214E6-0000-0000-C000-000000000046")> _
Friend Interface IShellFolder
    <PreserveSig()> _
    Function ParseDisplayName( _
        ByVal hwndOwner As IntPtr, _
        ByVal pbcReserved As IntPtr, _
        <MarshalAs(UnmanagedType.LPWStr)> _
        ByVal lpszDisplayName As String, _
        ByRef pchEaten As Integer, _
        ByRef ppidl As IntPtr, _
        ByRef pdwAttributes As Integer) As Integer

    <PreserveSig()> _
    Function EnumObjects( _
        ByVal hwndOwner As Integer, _
        <MarshalAs(UnmanagedType.U4)> ByVal _
        grfFlags As Integer, _
        ByRef ppenumIDList As IntPtr) As Integer

    <PreserveSig()> _
    Function BindToObject( _
        ByVal pidl As IntPtr, _
        ByVal pbcReserved As IntPtr, _
        ByRef riid As Guid, _
        ByRef ppvOut As IShellFolder) As Integer
    'IShellFolder) As Integer

    <PreserveSig()> _
    Function BindToStorage( _
        ByVal pidl As IntPtr, _
        ByVal pbcReserved As IntPtr, _
        ByRef riid As Guid, _
        ByVal ppvObj As IntPtr) As Integer

    <PreserveSig()> _
    Function CompareIDs( _
        ByVal lParam As IntPtr, _
        ByVal pidl1 As IntPtr, _
        ByVal pidl2 As IntPtr) As Integer

    <PreserveSig()> _
    Function CreateViewObject( _
        ByVal hwndOwner As IntPtr, _
        ByRef riid As Guid, _
        ByRef ppvOut As IntPtr) As Integer
    'IUnknown) As Integer

    <PreserveSig()> _
    Function GetAttributesOf( _
        ByVal cidl As Integer, _
        <MarshalAs(UnmanagedType.LPArray, sizeparamindex:=0)> _
        ByVal apidl() As IntPtr, _
        ByRef rgfInOut As Integer) As Integer

    <PreserveSig()> _
    Function GetUIObjectOf( _
        ByVal hwndOwner As Integer, _
        ByVal cidl As Integer, _
        <MarshalAs(UnmanagedType.LPArray, sizeparamindex:=0)> _
        ByVal apidl() As IntPtr, _
        ByRef riid As Guid, _
        <Out()> ByRef prgfInOut As Integer, _
        <Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvOut As Object) As Integer
    'ByRef ppvOut As IUnknown) As Integer
    'ByRef ppvOut As IDropTarget) As Integer

    <PreserveSig()> _
    Function GetDisplayNameOf( _
        ByVal pidl As IntPtr, _
        <MarshalAs(UnmanagedType.U4)> _
        ByVal uFlags As Integer, _
        ByVal lpName As IntPtr) As Integer

    <PreserveSig()> _
    Function SetNameOf( _
        ByVal hwndOwner As Integer, _
        ByVal pidl As IntPtr, _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal _
        lpszName As String, _
        <MarshalAs(UnmanagedType.U4)> ByVal _
        uFlags As Integer, _
        ByRef ppidlOut As IntPtr) As Integer

End Interface

<Flags()> _
Friend Enum IEIFLAG
    IEIFLAG_ASYNC = &H1     ' ask the extractor if it supports ASYNC extract (free threaded)
    IEIFLAG_CACHE = &H2      'returned from the extractor if it does NOT cache the thumbnail
    IEIFLAG_ASPECT = &H4      ' passed to the extractor to beg it to render to the aspect ratio of the supplied rect
    IEIFLAG_OFFLINE = &H8     ' if the extractor shouldn't hit the net to get any content needed for the rendering
    IEIFLAG_GLEAM = &H10     'does the image have a gleam ? this will be returned if it does
    IEIFLAG_SCREEN = &H20      ' render as if for the screen  (this is exlusive with IEIFLAG_ASPECT )
    IEIFLAG_ORIGSIZE = &H40      ' render to the approx size passed, but crop if neccessary
    IEIFLAG_NOSTAMP = &H80      ' returned from the extractor if it does NOT want an icon stamp on the thumbnail
    IEIFLAG_NOBORDER = &H100      'returned from the extractor if it does NOT want an a border around the thumbnail
    IEIFLAG_QUALITY = &H200      ' passed to the Extract method to indicate that a slower, higher quality image is desired, re-compute the thumbnail
End Enum
