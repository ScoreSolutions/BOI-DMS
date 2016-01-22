﻿
Partial Class Report_rptBoard
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOrg.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อหน่วยงาน", Me, cmbOrg.ClientID)
            Exit Sub
        End If
        If txtDate1.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่", Me, txtDate1.ClientID)
            Exit Sub
        End If
        'Session.Remove("OrgID")
        'Session.Remove("formdt")

        'Session("OrgID") = cmbOrg.SelectedValue
        'Session("formdt") = txtDate1.DateValue
        ''Response.Redirect("../rptGrid/rptjobsectorforgm.aspx")
        Dim wh As String = "OrgID=" & cmbOrg.SelectedValue
        wh += "&DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        Config.PreviewReports("../rptGrid/rptjobsectorforgm.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")
            eng = Nothing
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cmbOrg.SelectedValue = "0"
        txtDate1.DateValue = New Date(1, 1, 1)
    End Sub
End Class
