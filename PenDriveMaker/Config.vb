Public Class Config

    Dim iniFile As IniFile

    Sub New()
        Dim ini As New IniFile
        ini.Load("Config.ini")
        iniFile = ini
    End Sub

    Public Function GetTranslation(ByVal LanguageCode As String, ByVal Key As String) As String
        Dim value As String
        value = Me.iniFile.GetKeyValue("LANGUAGE_" & LanguageCode, Key)

        If String.IsNullOrEmpty(value) Then
            Return Key
        End If

        Return value
    End Function

    Public Function GetKeyValue(ByVal Key As String) As String

        Return Me.iniFile.GetKeyValue("CONFIG", Key)

    End Function

End Class
