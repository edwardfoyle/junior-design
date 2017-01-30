Public Class ProcessExecutor
    Implements IDisposable

#Region "IDisposable Support"
    Private disposedValue As Boolean = False ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If process IsNot Nothing Then
                    process.Kill()
                    process.Dispose()
                    process = Nothing
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        GC.SuppressFinalize(Me)
    End Sub

    Public Event OutputRead(ByVal output As String)

    Private WithEvents process As Process

    Public Sub Execute(ByVal filePath As String, ByVal args As String)
        If process IsNot Nothing Then
            Throw New Exception("Already watching process")
        End If
        process = New Process()
        process.StartInfo.FileName = filePath
        process.StartInfo.Arguments = args
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.Start()
        process.BeginOutputReadLine()
    End Sub

    Private Sub process_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles process.OutputDataReceived
        If process.HasExited Then
            process.Dispose()
            process = Nothing
        End If
        RaiseEvent OutputRead(e.Data)
    End Sub
#End Region
End Class
