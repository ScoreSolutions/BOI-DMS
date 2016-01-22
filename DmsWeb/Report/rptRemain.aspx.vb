Imports System.Data
Partial Class Report_rptRemain
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOrg.SelectedValue = 0 Then
            Config.SetAlert("กรุณาระบุชื่อหน่วยงาน", Me, cmbOrg.ClientID)
            Exit Sub
        End If
        If txtDate1.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาเลือกวันที่", Me, txtDate1.ClientID)
            Exit Sub
        End If
        'Session.Remove("OrgID")
        'Session.Remove("Date1")

        'Session("OrgID") = cmbOrg.SelectedValue
        'Session("Date1") = txtDate1.DateValue
        Dim wh As String = "OrgID=" & cmbOrg.SelectedValue
        wh += "&Date1=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        Config.SaveTransLog("เรียกดูรายงานงานค้าง - [ สบท.1-4 , กปช , สพท , ศูนย์ภูมิภาค ] เงื่อนไข :" & wh)
        Config.PreviewReports("../rptGrid/rptjobsector.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            Dim dt As New DataTable
            dt = eng.GetOrgBySector("0")
            cmbOrg.SetItemList(dt, "org_name", "id")
            dt = Nothing
            eng = Nothing
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cmbOrg.SelectedValue = "0"
        txtDate1.DateValue = New Date(1, 1, 1)
    End Sub
End Class
