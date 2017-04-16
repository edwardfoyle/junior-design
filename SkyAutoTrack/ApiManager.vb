Imports System.IO
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ApiManager

    Public Sub Query(app As MainWindow, useDefaultImage As Boolean, snapshotName As String, defaultImage As String)
        Dim thread As New System.Threading.Thread(Sub() asyncQuery(app, useDefaultImage, snapshotName, defaultImage))
        thread.Start()
    End Sub

    Private Sub asyncQuery(app As MainWindow, useDefaultImage As Boolean, snapshotName As String, defaultImage As String)
        Dim proc As New Process()
        ' TODO: change this to a dynamic path at some point
        proc.StartInfo.FileName = "C:\Python27\python.exe"
        Dim pyPath As String = Path.Combine(Environment.CurrentDirectory, "client25.py")
        Dim imPath As String
        Dim snapshot As Boolean = False
        If useDefaultImage Then
            imPath = Path.Combine(Environment.CurrentDirectory, defaultImage)
        Else
            imPath = Path.Combine(Environment.SpecialFolder.Desktop, snapshotName)
            snapshot = True
        End If
        proc.StartInfo.Arguments = """" + pyPath + """" + " -k ahhxdcgzhkqyxwas -u " + """" + imPath + """" + " -w"
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.Start()
        Dim stdout As String
        Using outStreamReader As StreamReader = proc.StandardOutput
            stdout = outStreamReader.ReadToEnd()
        End Using
        ' regular expression to match the last json object returned from the API query
        Dim pattern As String = "{((?!{).)*}\s*$"
        Dim match As Match = Regex.Match(stdout, pattern)
        stdout = match.Value
        Dim jsonObj As JObject = JObject.Parse(stdout)
        Dim ra As Double = jsonObj.Item("ra")
        Dim dec As Double = jsonObj.Item("dec")
        app.setRA_Dec_QueryResult(ra, dec)
        If snapshot Then
            My.Computer.FileSystem.DeleteFile(imPath)
            snapshot = False
        End If
    End Sub
End Class
