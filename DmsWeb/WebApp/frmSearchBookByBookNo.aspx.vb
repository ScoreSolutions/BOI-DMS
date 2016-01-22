Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByBookNo
    Inherits System.Web.UI.Page

    
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtBookno.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุเลขที่หนังสือ", Me, txtBookno.ClientID)
            Exit Sub
        End If
        Config.SaveTransLog("ค้นหาเลขที่หนังสือ " & txtBookno.Text.Trim)
        Dim cki As New HttpCookie(Constant.SessSearchCondition, " and dr.book_no like '" & txtBookno.Text.Trim & "%' " & "###" & " and dr.book_no like '" & txtBookno.Text.Trim & "%'")
        Response.Cookies.Add(cki)

        Config.PreviewReports("../WebApp/frmSearchBookByCondition.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookno.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
