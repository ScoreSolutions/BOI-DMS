Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptjobsector
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim OrgID As Long = 0
            Dim Date1 As New Date(1, 1, 1)
            If Request("OrgID") IsNot Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim oPara As New Para.TABLE.OrganizationPara
                Dim oEng As New Engine.Master.OrganizationEng
                oPara = oEng.GetOrgPara(OrgID)
                lbl_organize.Text = oPara.NAME_ABB
                oPara = Nothing
                oEng = Nothing
            End If
            If Request("Date1") IsNot Nothing Then
                Date1 = Config.GetStringToDate(Request("Date1"))
                lbl_fromdt.Text = "ณ วันที่ " & Convert.ToDateTime(Date1).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
            End If

            Binddata(OrgID, Date1)
        End If
    End Sub

    Const SessDataItem As String = "SessDataItem"
    Private Sub Binddata(ByVal OrgID As String, ByVal Date1 As Date)
        Dim dt As New DataTable
        Session.Remove(SessDataItem)
        reports.OrgID = OrgID
        reports.fromdate = Convert.ToDateTime(Date1).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        dt = reports.rptsector
        If dt.Rows.Count > 0 Then
            reports.BuildDueDate(dt, lbl_organize.Text)
            'dt.DefaultView.RowFilter = "overdue>0"         'งานค้าง Sector ให้แสดงทุกเรื่องที่ค้าง
            Session(SessDataItem) = dt.DefaultView.ToTable

            Dim gDt As New DataTable
            gDt = dt.DefaultView.ToTable(True, "group_title_name").Copy
            If gDt.Rows.Count > 0 Then
                Repeater1.DataSource = gDt
                Repeater1.DataBind()

                gDt.Dispose()
            End If
            dt.Dispose()
        End If
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblGroupTitleName As Label = DirectCast(e.Item.FindControl("lblGroupTitleName"), Label)

            Dim lblDesc As Label = DirectCast(e.Item.FindControl("lblDesc"), Label)
            Dim dt As New DataTable
            dt = Session(SessDataItem)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "group_title_name='" & lblGroupTitleName.Text & "'"
                Dim tmpDt As New DataTable
                tmpDt = dt.DefaultView.ToTable.Copy
                dt.DefaultView.RowFilter = ""
                If tmpDt.Rows.Count > 0 Then
                    Dim ret As New StringBuilder
                    For i As Integer = 0 To tmpDt.Rows.Count - 1
                        Dim dr As DataRow = tmpDt.Rows(i)

                        ret.Append("<tr class='grid_Item' >")
                        ret.Append("    <td align='center' >" & (i + 1).ToString & "</td>")
                        ret.Append("    <td align='center' >")
                        ret.Append("        <a href='../WebApp/frmDocBookDetailShow.aspx?id=" & dr("document_register_id") & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >" & dr("book_no") & "</a>")
                        ret.Append("    </td>")
                        ret.Append("    <td align='center' >" & Convert.ToDateTime(dr("register_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                        ret.Append("    <td align='center' >" & Convert.ToDateTime(dr("expect_finish_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                        ret.Append("    <td >" & dr("company_name").ToString & "</td>")
                        ret.Append("    <td align='center' >" & Convert.ToDateTime(dr("receive_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                        ret.Append("    <td align='center' >" & dr("organization_appname_send").ToString & "</td>")
                        ret.Append("    <td align='center' >" & Convert.ToDateTime(dr("due_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                        ret.Append("    <td >" & dr("officer_name_possess") & "</td>")
                        If Convert.ToInt64(dr("overdue")) <= 0 Then
                            ret.Append("    <td align='center' >&nbsp;</td>")
                        Else
                            ret.Append("    <td align='center' >" & dr("overdue") & "</td>")
                        End If
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")
                        ret.Append("    <td >&nbsp;</td>")

                        ret.Append("</tr>")
                    Next
                    lblDesc.Text = ret.ToString
                    tmpDt.Dispose()
                End If
                dt.Dispose()
            End If
        End If
    End Sub
End Class
