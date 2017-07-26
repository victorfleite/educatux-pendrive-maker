Option Strict On
Option Explicit On

Imports Microsoft.Win32.SafeHandles
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Public Class VolumeInfo

    Private Const GenericRead As Integer = &H80000000
    Private Const FileShareRead As Integer = 1
    Private Const Filesharewrite As Integer = 2
    Private Const OpenExisting As Integer = 3
    Private Const IoctlVolumeGetVolumeDiskExtents As Integer = &H560000
    Private Const IncorrectFunction As Integer = 1
    Private Const ErrorInsufficientBuffer As Integer = 122

    Private Class NativeMethods
        <DllImport("kernel32", CharSet:=CharSet.Unicode, SetLastError:=True)>
        Public Shared Function CreateFile(
            ByVal fileName As String,
            ByVal desiredAccess As Integer,
            ByVal shareMode As Integer,
            ByVal securityAttributes As IntPtr,
            ByVal creationDisposition As Integer,
            ByVal flagsAndAttributes As Integer,
            ByVal hTemplateFile As IntPtr) As SafeFileHandle
        End Function

        <DllImport("kernel32", SetLastError:=True)>
        Public Shared Function DeviceIoControl(
            ByVal hVol As SafeFileHandle,
            ByVal controlCode As Integer,
            ByVal inBuffer As IntPtr,
            ByVal inBufferSize As Integer,
            ByRef outBuffer As DiskExtents,
            ByVal outBufferSize As Integer,
            ByRef bytesReturned As Integer,
            ByVal overlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("kernel32", SetLastError:=True)>
        Public Shared Function DeviceIoControl(
            ByVal hVol As SafeFileHandle,
            ByVal controlCode As Integer,
            ByVal inBuffer As IntPtr,
            ByVal inBufferSize As Integer,
            ByVal outBuffer As IntPtr,
            ByVal outBufferSize As Integer,
            ByRef bytesReturned As Integer,
            ByVal overlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    ' DISK_EXTENT in the msdn.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure DiskExtent
        Public DiskNumber As Integer
        Public StartingOffset As Long
        Public ExtentLength As Long
    End Structure

    ' DISK_EXTENTS
    <StructLayout(LayoutKind.Sequential)>
    Private Structure DiskExtents
        Public numberOfExtents As Integer
        Public first As DiskExtent ' We can't marhsal an array if we don't know its size.
    End Structure

    ' A Volume could be on many physical drives.
    ' Returns a list of string containing each physical drive the volume uses.
    ' For CD Drives with no disc in it will return an empty list.
    Public Shared Function GetPhysicalDriveStrings(ByVal driveInfo As DriveInfo) As List(Of String)
        Dim sfh As SafeFileHandle = Nothing
        Dim physicalDrives As New List(Of String)(1)
        Dim path As String = "\\.\" & driveInfo.RootDirectory.ToString.TrimEnd("\"c)
        Try
            sfh = NativeMethods.CreateFile(path, GenericRead, FileShareRead Or Filesharewrite, IntPtr.Zero,
                                                           OpenExisting, 0, IntPtr.Zero)
            Dim bytesReturned As Integer
            Dim de1 As DiskExtents = Nothing
            Dim numDiskExtents As Integer = 0
            Dim result As Boolean = NativeMethods.DeviceIoControl(sfh, IoctlVolumeGetVolumeDiskExtents, IntPtr.Zero,
                                                                  0, de1, Marshal.SizeOf(de1), bytesReturned, IntPtr.Zero)
            If result = True Then
                ' there was only one disk extent. So the volume lies on 1 physical drive.
                physicalDrives.Add("\\.\PhysicalDrive" & de1.first.DiskNumber.ToString)
                Return physicalDrives
            End If
            If Marshal.GetLastWin32Error = IncorrectFunction Then
                ' The drive is removable and removed, like a CDRom with nothing in it.
                Return physicalDrives
            End If
            If Marshal.GetLastWin32Error <> ErrorInsufficientBuffer Then
                Throw New Win32Exception
            End If
            ' Houston, we have a spanner. The volume is on multiple disks.
            ' Untested...
            ' We need a blob of memory for the DISK_EXTENTS structure, and all the DISK_EXTENTS
            Dim blobSize As Integer = Marshal.SizeOf(GetType(DiskExtents)) +
                                      (de1.numberOfExtents - 1) * Marshal.SizeOf(GetType(DiskExtent))
            Dim pBlob As IntPtr = Marshal.AllocHGlobal(blobSize)
            result = NativeMethods.DeviceIoControl(sfh, IoctlVolumeGetVolumeDiskExtents, IntPtr.Zero, 0, pBlob,
                                                   blobSize, bytesReturned, IntPtr.Zero)
            If result = False Then Throw New Win32Exception
            ' Read them out one at a time.
            Dim pNext As New IntPtr(pBlob.ToInt32 + 4) ' is this always ok on 64 bit OSes? ToInt64?
            For i As Integer = 0 To de1.numberOfExtents - 1
                Dim diskExtentN As DiskExtent = DirectCast(Marshal.PtrToStructure(pNext, GetType(DiskExtent)), DiskExtent)
                physicalDrives.Add("\\.\PhysicalDrive" & diskExtentN.DiskNumber.ToString)
                pNext = New IntPtr(pNext.ToInt32 + Marshal.SizeOf(GetType(DiskExtent)))
            Next
            Return physicalDrives
        Finally
            If sfh IsNot Nothing Then
                If sfh.IsInvalid = False Then
                    sfh.Close()
                End If
                sfh.Dispose()
            End If
        End Try
    End Function

End Class