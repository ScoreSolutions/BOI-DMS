Imports System.Data
Partial Class Report_rptRemainOrg
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOrg.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อหน่วยงาน", Me, cmbOrg.ClientID)
            Exit Sub
        End If
        'Session.Remove("OrgID")
        'Session("OrgID") = cmbOrg.SelectedValue
        Dim wh As String = "OrgID=" & cmbOrg.SelectedValue
        Config.SaveTransLog("เรียกดูรายงานสรุปงานค้างของสำนัก เงื่อนไข : " & wh)
        Config.PreviewReports("../rptGrid/rptRemainOrg.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            Dim dt As New DataTable
            dt = eng.GetAllOrganizationTable()
            cmbOrg.SetItemList(dt, "org_name", "id")
            dt = Nothing
            eng = Nothing
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cmbOrg.SelectedValue = "0"
    End Sub
End Class
