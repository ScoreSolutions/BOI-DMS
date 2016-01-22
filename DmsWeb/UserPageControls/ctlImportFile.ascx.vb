Imports System.Data
Imports System.Data.OleDb
Imports System.Web

Partial Class UserPageControls_ctlImportFile
    Inherits System.Web.UI.UserControl
    'Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/BOISourcesafe/DmsWeb/Report/Book1.xlsx; Extended Properties=Excel 12.0;"


    Dim DV As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        zPop.Show()
        MultiView1.ActiveViewIndex = 0
        ShowGrid()
    End Sub
    Protected Sub bImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bImport.Click

        zPop.Show()
        MultiView1.ActiveViewIndex = 0
        ShowGrid()

    End Sub
    Private Sub ShowGrid()
        zPop.Show()
        Dim ds As New DataSet()
        Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Server.MapPath("~/Report/Book1.xlsx") + "; Extended Properties=Excel 12.0;"


        Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet6$] ", strConn)

        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0).DefaultView
        GridView1.DataBind()

    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        zPop.Show()
        If RadioButtonList1.SelectedIndex = 0 Then
            MultiView1.ActiveViewIndex = 0
        Else
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        zPop.Show()
        Image1.ImageUrl = "../../Images/testscan.png"
        txtBox2.Text = "1 of 1"
    End Sub


End Class
