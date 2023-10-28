Imports BingoManager.SystemManager.Engine
Imports System.Data.OleDb
Imports BingoManager.Reports.bingoDataSetTableAdapters


Public Class ReportViewer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub ReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using connection = ConnectionProvider.Connection()
            Dim sqlCommand As String = "Select SerialNumber,B,I,N,G,O from PlayingCards"
            Dim da As New OleDbDataAdapter(sqlCommand, connection)
             Dim bingodataset As New bingoDataSet()
            da.Fill(bingodataset, "PlayingCards")
            Dim rePort As New CrystalReport1()
            rePort.SetDataSource(bingodataset)
            CrystalReportViewer1.ReportSource = rePort
            CrystalReportViewer1.Refresh()
        End Using
    End Sub
End Class
