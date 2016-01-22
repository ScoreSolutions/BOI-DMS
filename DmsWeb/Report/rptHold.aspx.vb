
Partial Class Report_rptHold
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOrg.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อหน่วยงาน", Me, cmbOrg.ClientID)
            Exit Sub
        End If
        'Session.Remove("OrgID")
        'Session.Remove("HaveFinishDate")

        'Session("OrgID") = cmbOrg.SelectedValue
        'If CheckBox1.Checked = True Then
        '    Session("HaveFinishDate") = "Y"
        'End If
        'Response.Redirect("../rptGrid/rptonwer.aspx")

        Dim wh As String = "OrgID=" & cmbOrg.SelectedValue
        If CheckBox1.Checked = True Then
            wh += "&HaveFinishDate=Y"
        End If
        Config.SaveTransLog("เรียกดูรายงานงานถือครอง เงื่อนไข : " & wh)
        Config.PreviewReports("../rptGrid/rptonwer.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cmbOrg.SelectedValue = "0"
        CheckBox1.Checked = False
    End Sub
End Class
