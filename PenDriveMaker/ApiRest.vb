Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Module ApiRest

    Public Function GetEducatuxVersions() As String
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        Try
            ' Create the web request  
            request = DirectCast(WebRequest.Create("https://statistics.educatux.com.br/service/api/www/index.php/v1/educatux/get-versions"), HttpWebRequest)

            ' Get response  
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Get the response stream into a reader  
            reader = New StreamReader(response.GetResponseStream())

            Return reader.ReadToEnd()
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Function


End Module
