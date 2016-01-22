
Partial Class Report_rptSendOutDP
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If cmbOrg.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกหน่วยงาน", Me, cmbOrg.ClientID)
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

        'Session.Remove("BookOutNoForm")
        'Session.Remove("BookOutNoTo")
        'Session.Remove("formdt")
        'Session.Remove("todt")
        'Session.Remove("orgID")

        'Session("BookOutNoForm") = txtBox1.Text.Trim
        'Session("BookOutNoTo") = txtBox2.Text.Trim
        'Session("formdt") = txtDate1.DateValue
        'Session("todt") = txtDate2.DateValue
        'Session("orgID") = cmbOrg.SelectedValue
        ''Response.Redirect("../rptGrid/rptdocoutorg.aspx")

        Dim wh As String = "DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&OrgID=" & cmbOrg.SelectedValue

        Dim whLog As String = wh
        If txtBox1.Text.Trim <> "" Then
            Dim ckiBookOutNoFrom As New HttpCookie("BookOutNoFrom", txtBox1.Text.Trim)
            Response.Cookies.Add(ckiBookOutNoFrom)
            whLog += " เลขที่หนังสืออกเริ่มต้น :" & txtBox1.Text.Trim
        End If
        If txtBox2.Text.Trim <> "" Then
            Dim ckiBookOutNoTo As New HttpCookie("BookOutNoTo", txtBox2.Text.Trim)
            Response.Cookies.Add(ckiBookOutNoTo)
            whLog += " เลขที่หนังสืออกสิ้นสุด :" & txtBox2.Text.Trim
        End If

        Config.SaveTransLog("เรียกดูรายงานสรุปเอกสารที่ส่งออกนอกสำนักงาน เงื่อนไข :" & whLog)
        Config.PreviewReports("../rptGrid/rptdocoutorg.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
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
        txtBox1.Text = ""
        txtBox2.Text = ""
        txtDate1.DateValue = New Date(1, 1, 1)
        txtDate2.DateValue = New Date(1, 1, 1)
    End Sub
End Class
