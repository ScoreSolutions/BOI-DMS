Imports System.Data

Partial Class Report_rptSummaryRegister
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbOrg.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกสำนัก", Me)
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
        'Session.Remove("Organizename")
        'Session.Remove("GroupTitleName")

        'Session("formdt") = txtDate1.DateValue
        'Session("todt") = txtDate2.DateValue
        'Session("OrgID") = cmbOrg.SelectedValue
        'Session("Organizename") = cmbOrg.SelectedText
        'If cmbGroupTitle.SelectedValue <> "0" Then
        '    Session("GroupTitleName") = cmbGroupTitle.SelectedItem.Text
        'End If

        Dim wh As String = "DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&OrgID=" & cmbOrg.SelectedValue
        If cmbGroupTitle.SelectedValue <> "0" Then
            wh += "&GroupTitleID=" & cmbGroupTitle.SelectedValue
        End If
        Config.SaveTransLog("เรียกดูรายงานสรุปเอกสารที่ลงทะเบียน เงื่อนไข :" & wh)
        Config.PreviewReports("../rptGrid/rptsumdoc_regist.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.OrganizationEng
            cmbOrg.SetItemList(eng.GetAllOrganizationTable(), "org_name", "id")
            eng = Nothing

            SetGroupTitle()
        End If
    End Sub

    Private Sub SetGroupTitle()
        Dim eng As New Engine.Master.GroupTitleEng
        Dim dt As New DataTable
        dt = eng.GetDataGroupTitleList("active='Y' and ltrim(group_title_name) <>''", "group_title_code")
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("group_title_name") = "เลือก"
            dr("id") = "0"
            dt.Rows.InsertAt(dr, 0)

            cmbGroupTitle.DataTextField = "group_title_name"
            cmbGroupTitle.DataValueField = "id"
            cmbGroupTitle.DataSource = dt
            cmbGroupTitle.DataBind()
            dt.Dispose()
            dt = Nothing
        End If
        eng = Nothing
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cmbOrg.SelectedValue = "0"
        cmbGroupTitle.SelectedValue = "0"
        txtDate1.DateValue = New Date(1, 1, 1)
        txtDate2.DateValue = New Date(1, 1, 1)
    End Sub
End Class
