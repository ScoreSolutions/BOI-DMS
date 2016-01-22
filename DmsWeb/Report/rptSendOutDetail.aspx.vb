Imports System.Data
Imports System.Data.OleDb
Partial Class Report_rptSendOutDetail
    Inherits System.Web.UI.Page

    Dim strConn As [String] = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Server.MapPath("~/Report/Book1.xlsx") + "; Extended Properties=Excel 12.0;"

    Dim DV As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowGrid()
    End Sub
    Private Sub ShowGrid()

        Dim ds As New DataSet()

        Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet3$] ", strConn)

        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0).DefaultView
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("rptDocDetail.aspx", True)
    End Sub
End Class
