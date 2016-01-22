Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByCompanyBookNo
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtCompanyBookNo.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุเลขที่หนังสือองค์กร", Me, txtCompanyBookNo.ClientID)
            Exit Sub
        End If

        Config.SaveTransLog("ค้นหาจากเลขที่หนังสือองค์กร " & txtCompanyBookNo.Text.Trim)
        'Session(Constant.SessSearchCondition) = " and dr.company_doc_no like '" & txtCompanyBookNo.Text.Trim & "%' "
        Dim cki As New HttpCookie(Constant.SessSearchCondition, " and dr.company_doc_no like '" & txtCompanyBookNo.Text.Trim & "%' " & "###" & " and dr.company_doc_no like '" & txtCompanyBookNo.Text.Trim & "%'")
        Response.Cookies.Add(cki)
        Config.PreviewReports("../WebApp/frmResultSearchByCompanyBookNo.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCompanyBookNo.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session.Remove(Constant.SessSearchCondition)
            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
