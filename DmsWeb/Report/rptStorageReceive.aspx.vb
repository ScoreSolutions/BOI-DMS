
Partial Class Report_rptStorageReceive
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

        Dim tmp As String = "DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & ""
        tmp += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & ""
        tmp += "&OrgID=" & cmbOrg.SelectedValue
        Config.SaveTransLog("เรียกดูรายงานการรับหนังสือหน่วยจัดเก็บเอกสารกลาง เงื่อนไข :" & tmp)
        Config.PreviewReports("../rptGrid/rptRepStorageReceive.aspx?" & tmp & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Private Sub SetOrgID()
        Dim eng As New Engine.Master.OrganizationEng
        Dim dt As System.Data.DataTable
        dt = eng.GetOrgStorageList
        cmbOrg.SetItemList(dt, "org_name", "id")
        'cmbOrg.SelectedValue = "20080207001"  'หน่วยจัดเก็บเอกสารกลาง
        dt = Nothing
        eng = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetOrgID()
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        SetOrgID()
        txtDate1.DateValue = New Date(1, 1, 1)
        txtDate2.DateValue = New Date(1, 1, 1)
    End Sub
End Class
