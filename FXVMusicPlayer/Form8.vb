Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Dim ficha As New MusicDB
        Dim dx As DataSet
        dx = ficha.Le_TelefoneDataset(Me)
        dx.Tables(0).TableName = "DataSet1"
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Report1.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dx.Tables("DataSet1")))
        ReportViewer1.RefreshReport()
    End Sub
End Class