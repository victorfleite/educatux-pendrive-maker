Imports System.Management
Imports System.Management.Instrumentation

Public Class DeviceUsb

    Shared mo_HD As ManagementObject

    Private Shared Function DiscoInfo(ByVal strDrive As String) As ManagementObject
        'Verifica se a letra do drive foi informada. O padrão é a letra C
        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Try
            'Usa Win32_LogicalDisk para obter as propriedades do HD
            Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")
            Return moHD
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function NumeroSerial(ByVal strDrive As String) As String
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega o Serial
            Return mo_HD("VolumeSerialNumber").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function Tamanho(ByVal strDrive As String) As Double
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega o tamanho do HD
            Return Convert.ToDouble(mo_HD("Size"))
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function EspacoLivre(ByVal strDrive As String) As Double
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega o espaço livre
            Return Convert.ToDouble(mo_HD("FreeSpace"))
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function TipoDrive(ByVal strDrive As String) As String
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega o tipo de drive
            Return mo_HD("DriveType").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function Sistema(ByVal strDrive As String) As String
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega info do sistema
            Return mo_HD("FileSystem").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function Modelo(ByVal strDrive As String) As String
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega tipo da media
            Return mo_HD("MediaType").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class