Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmResultSearchByReqNo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'If Session(Constant.SessSearchCondition) IsNot Nothing Then
            '    SetGridview(Session(Constant.SessSearchCondition))
            '    Session.Remove(Constant.SessSearchCondition)
            'End If

            If Not IsNothing(Request.Cookies(Constant.SessSearchCondition)) Then
                SetGridview(Request.Cookies(Constant.SessSearchCondition).Value)

                Dim delCookie As New HttpCookie(Constant.SessSearchCondition)
                delCookie.Expires = DateTime.Now.AddDays(-1D)
                Response.Cookies.Add(delCookie)
            End If
        End If
    End Sub

    Public Sub SetGridview(ByVal wh As String)
        Dim dt As New DataTable
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchByCondition(wh, " and 1<>1")
        If dt.Rows.Count > 0 Then
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
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(6).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub
End Class
