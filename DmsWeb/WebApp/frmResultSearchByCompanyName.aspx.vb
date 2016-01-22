Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmResultSearchByCompanyName
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'If Session(Constant.SessSearchCondition) IsNot Nothing Then
            '    SetGridview(Session(Constant.SessSearchCondition))
            '    Session.Remove(Constant.SessSearchCondition)
            'End If
            If Not IsNothing(Request.Cookies(Constant.SessSearchCondition)) Then
                Dim WhText() As String = Split(Request.Cookies(Constant.SessSearchCondition).Value, "###")
                SetGridview(WhText(0), WhText(1))

                Dim delCookie As New HttpCookie(Constant.SessSearchCondition)
                delCookie.Expires = DateTime.Now.AddDays(-1D)
                Response.Cookies.Add(delCookie)
            End If
        End If
    End Sub


    Public Sub SetGridview(ByVal wh As String, ByVal ImpText As String)
        Dim dt As New DataTable
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchByCondition(wh, ImpText)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")

            'Create Status Column
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            For i As Int64 = 0 To dt.Rows.Count - 1
                If Convert.IsDBNull(dt.Rows(i)("close_date")) = False Then
                    dt.Rows(i)("doc_status_name") += " " + Convert.ToDateTime(dt.Rows(i)("close_date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
                End If
                If Convert.IsDBNull(dt.Rows(i)("bookout_no")) = False Then
                    dt.Rows(i)("doc_status_name") += Engine.Document.DocumentRegisterENG.GetBookOutDetailReports(Convert.ToInt64(dt.Rows(i)("id")), trans)
                End If
                dt.Rows(i)("no") = (i + 1)
            Next
            trans.CommitTransaction()

            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblNoData.Visible = True
        End If
        eng = Nothing
        dt = Nothing

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(9).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub
End Class
