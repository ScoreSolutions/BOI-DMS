
Partial Class Report_rptKPI
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOwnerOrgID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกสำนัก", Me)
            Exit Sub
        End If
        If cmbOwnerStaffID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกเจ้าหน้าที่", Me)
            Exit Sub
        End If
        If txtDate1.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่เริ่มต้น", Me, txtDate1.ClientID)
            Exit Sub
        End If
        If txtDate2.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่", Me, txtDate2.ClientID)
            Exit Sub
        End If
        If DateDiff(DateInterval.Day, txtDate1.DateValue, txtDate2.DateValue) < 0 Then
            Config.SetAlert("กรุณาระบุวันที่สิ้นสุดมากกว่าวันที่เริ่มต้น", Me, txtDate2.ClientID)
            Exit Sub
        End If
        'Session.Remove("formdt")
        'Session.Remove("todt")
        'Session.Remove("OrgID")
        'Session.Remove("OfficerID")
        'Session.Remove("IsExpectedFinishDate")

        'Session("formdt") = txtDate1.DateValue
        'Session("todt") = txtDate2.DateValue
        'Session("OrgID") = cmbOwnerOrgID.SelectedValue
        'Session("OfficerID") = cmbOwnerStaffID.SelectedValue
        'Session("IsExpectedFinishDate") = IIf(chkIsExpectedFinishDate.Checked, "Y", "N")
        ''Response.Redirect("../rptGrid/rptkpibyemp.aspx")
        Dim wh As String = "OrgID=" & cmbOwnerOrgID.SelectedValue
        wh += "&OfficerID=" & cmbOwnerStaffID.SelectedValue
        wh += "&DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&IsExpectedFinishDate=" & IIf(chkIsExpectedFinishDate.Checked, "Y", "N")
        Config.SaveTransLog("เรียกดู KPI รายบุคคล เงื่อนไข : " & wh)
        Config.PreviewReports("../rptGrid/rptkpibyemp.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If IsPostBack = False Then
    '        'Dim eng As New Engine.Master.OrganizationEng
    '        'cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")
    '    End If
    'End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cdlOwnerOrgID.SelectedValue = ""
        txtDate1.DateValue = New Date(1, 1, 1)
        txtDate2.DateValue = New Date(1, 1, 1)
        chkIsExpectedFinishDate.Checked = False
    End Sub
End Class
