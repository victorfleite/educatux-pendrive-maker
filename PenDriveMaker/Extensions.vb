Public Module Extensions
    Public Sub RunCMD(command As String, Optional ShowWindow As Boolean = False, Optional WaitForProcessComplete As Boolean = False, Optional permanent As Boolean = False)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(ShowWindow AndAlso permanent, "/K", "/C") + " " + command
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
End Module