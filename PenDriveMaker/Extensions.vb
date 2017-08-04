Public Module Extensions
    Public Sub RunCMD(command As String, Optional ShowWindow As Boolean = False, Optional WaitForProcessComplete As Boolean = False, Optional permanent As Boolean = False)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " & If(ShowWindow AndAlso permanent, "/K", "/C") & " " & command
        pi.FileName = "cmd.exe"
        pi.CreateNoWindow = Not ShowWindow
        If ShowWindow Then
            pi.WindowStyle = ProcessWindowStyle.Normal
        Else
            pi.WindowStyle = ProcessWindowStyle.Hidden
        End If
        p.StartInfo = pi
        p.Start()
        If WaitForProcessComplete Then Do Until p.HasExited : Loop
    End Sub

    Public Function ExecuteDosScript(ByVal BatchScriptLines As List(Of String)) As String
        Dim OutputString As String = String.Empty
        Using Process As New Process
            AddHandler Process.OutputDataReceived, Sub(sender As Object, LineOut As DataReceivedEventArgs)
                                                       OutputString = OutputString & LineOut.Data & vbCrLf
                                                   End Sub
            Process.StartInfo.FileName = "cmd"
            Process.StartInfo.UseShellExecute = False
            Process.StartInfo.CreateNoWindow = True
            Process.StartInfo.RedirectStandardInput = True
            Process.StartInfo.RedirectStandardOutput = True
            Process.StartInfo.RedirectStandardError = True
            Process.Start()
            Process.BeginOutputReadLine()
            Using InputStream As System.IO.StreamWriter = Process.StandardInput
                InputStream.AutoFlush = False
                For Each ScriptLine As String In BatchScriptLines
                    InputStream.Write(ScriptLine & vbCrLf)
                Next
            End Using
            Do
                Application.DoEvents()
            Loop Until Process.HasExited
        End Using
        Return OutputString
    End Function
End Module