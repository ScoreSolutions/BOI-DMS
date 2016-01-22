
Partial Class Report_rptWorkload
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
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

        'Session.Remove("rdiRepType")
        'Session.Remove("formdt")
        'Session.Remove("todt")
        'Session.Remove("OrgID")

        'Session("rdiRepType") = rdiRepType.SelectedValue
        'Session("formdt") = txtDate1.DateValue
        'Session("todt") = txtDate2.DateValue
        'Session("OrgID") = cmbOrg.SelectedValue
        ''Response.Redirect("../rptGrid/rptworkload.aspx?rnd=" & DateTime.Now.Millisecond, True)
        Dim wh As String = "rdiRepType=" & rdiRepType.SelectedValue
        wh += "&DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&OrgID=" & cmbOrg.SelectedValue
        Config.SaveTransLog("เรียกดูรายงาน Workload เงื่อนไข :" & wh)
        Config.PreviewReports("../rptGrid/rptworkload.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
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
        txtDate2.DateValue = New Date(1, 1, 1)
        rdiRepType.SelectedValue = "0"
    End Sub
End Class
