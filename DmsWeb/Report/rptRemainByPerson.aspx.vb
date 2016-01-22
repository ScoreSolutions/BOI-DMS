
Partial Class Report_rptRemainByPerson
    Inherits System.Web.UI.Page

 
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If cmbOrg.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อหน่วยงาน", Me, cmbOrg.ClientID)
            Exit Sub
        End If
        If cmbOfficer.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อเจ้าหน้าที่", Me, cmbOfficer.ClientID)
            Exit Sub
        End If
        If txtDate1.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่", Me, txtDate1.ClientID)
            Exit Sub
        End If

        'Session.Remove("OrgID")
        'Session.Remove("officerid")
        'Session.Remove("formdt")

        'Session("OrgID") = cmbOrg.SelectedValue
        'Session("officerid") = cmbOfficer.SelectedValue
        'Session("formdt") = txtDate1.DateValue
        ''Response.Redirect("../rptGrid/rptsector_by_emp.aspx")
        Dim wh As String = "OrgID=" & cmbOrg.SelectedValue
        wh += "&OfficerID=" & cmbOfficer.SelectedValue
        wh += "&DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        Config.SaveTransLog("เรียกดูรายงานงานค้างรายบุคคล เงื่อนไข :" & wh)
        Config.PreviewReports("../rptGrid/rptsector_by_emp.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")
            eng = Nothing
            cmbOrg.AutoPosBack = True
        End If
    End Sub

 
    Protected Sub cmbOrg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrg.SelectedIndexChanged
        Dim eng As New Engine.Master.OrganizationEng
        cmbOfficer.ClearCombo()
        cmbOfficer.SetItemList(eng.GetStaffByOrgID(cmbOrg.SelectedValue), "staff_name", "id")
        eng = Nothing
    End Sub

    
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim eng As New Engine.Master.OrganizationEng
        cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")

        cmbOfficer.ClearCombo()
        cmbOfficer.SetItemList(eng.GetStaffByOrgID(cmbOrg.SelectedValue), "staff_name", "id")
        eng = Nothing

        txtDate1.DateValue = New Date(1, 1, 1)
    End Sub
End Class
