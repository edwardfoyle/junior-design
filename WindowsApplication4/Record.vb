Imports Excel = Microsoft.Office.Interop.Excel


Public Class Record

    Dim APP As New Excel.Application
    Dim worksheet As New Excel.Worksheet
    Dim workbook As New Excel.Workbook

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles recordBtn.Click

    End Sub

    Private Sub Record_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        workbook = APP.Workbooks.Open("Path\temp.xlsx")
        worksheet = workbook.Worksheets("sheet1")
    End Sub
End Class