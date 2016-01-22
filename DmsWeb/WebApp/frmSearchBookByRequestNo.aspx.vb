Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByRequestNo
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtRequestNo.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุเลขที่คำขอ", Me, txtRequestNo.ClientID)
            Exit Sub
        End If

        Config.SaveTransLog("ค้นหาจากเลขที่คำขอ : " & txtRequestNo.Text.Trim)
        Dim cki As New HttpCookie(Constant.SessSearchCondition, " and dr.request_no like '" & txtRequestNo.Text.Trim & "%' ")
        Response.Cookies.Add(cki)

        Config.PreviewReports("../WebApp/frmResultSearchByReqNo.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtRequestNo.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
