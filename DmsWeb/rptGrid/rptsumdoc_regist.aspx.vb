Imports System.Data
Imports System
Imports MycustomDG

Partial Class rptGrid_rptsumdoc_regist
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim DateFrom As New Date(1, 1, 1)
            Dim DateTo As New Date(1, 1, 1)
            Dim OrgID As String = ""
            If Request("DateFrom") IsNot Nothing Then
                DateFrom = Config.GetStringToDate(Request("DateFrom"))
                lbl_fromdt.Text = DateFrom.ToString("dd MMM yy", New Globalization.CultureInfo("th-TH"))
            Else
                lbl_fromdt.Text = ""
            End If
            If Request("DateTo") IsNot Nothing Then
                DateTo = Config.GetStringToDate(Request("DateTo"))
                lbl_todt.Text = DateTo.ToString("dd MMM yy", New Globalization.CultureInfo("th-TH"))
            Else
                lbl_todt.Text = ""
            End If
            If Request("OrgID") IsNot Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim oPara As New Para.TABLE.OrganizationPara
                Dim eng As New Engine.Master.OrganizationEng
                oPara = eng.GetOrgPara(OrgID)
                If oPara.ID <> 0 Then
                    lbl_organize.Text = oPara.ORG_NAME
                Else
                    lbl_organize.Text = ""
                End If
                oPara = Nothing
                eng = Nothing
            Else
                lbl_organize.Text = ""
            End If

            Binddata(DateFrom, DateTo, OrgID)
        End If
    End Sub
    Private Sub Binddata(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As Long)
        Try
            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.todt = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            If Request("GroupTitleID") IsNot Nothing Then
                Dim gPara As New Para.TABLE.GroupTitlePara
                Dim eng As New Engine.Master.GroupTitleEng
                gPara = eng.GetGroupTitlePara(Convert.ToInt64(Request("GroupTitleID")))
                If gPara.ID <> 0 Then
                    reports.group_title_name = gPara.GROUP_TITLE_NAME
                End If
                gPara = Nothing
                eng = Nothing
            End If

            Dim dt As New DataTable
            dt = reports.rptsumdocregist
            Dim ret As New StringBuilder
            If dt.Rows.Count > 0 Then
                ret = BuildReport(dt)
            End If
            dt = Nothing
            reports = Nothing
            lblDesc.Text = ret.ToString
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub

    Private Function BuildReport(ByVal dt As DataTable) As StringBuilder
        Dim ret As New StringBuilder
        If dt.Rows.Count > 0 Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim gDt As New DataTable
            gDt = dt.DefaultView.ToTable(True, "group_title_name", "id").Copy
            If gDt.Rows.Count > 0 Then
                For Each gdr As DataRow In gDt.Rows
                    ret.Append("    <tr>")
                    ret.Append("        <td colspan='9' style='background-color: #FFFBD6;font-size:18px'>" & gdr("group_title_name").ToString & "</td>")
                    ret.Append("    </tr>")

                    dt.DefaultView.RowFilter = "id='" & gdr("id") & "'"
                    Dim tmpDt As New DataTable
                    tmpDt = dt.DefaultView.ToTable.Copy
                    dt.DefaultView.RowFilter = ""
                    If tmpDt.Rows.Count > 0 Then
                        For j As Integer = 0 To tmpDt.Rows.Count - 1
                            Dim dr As DataRow = tmpDt.Rows(j)
                            If j Mod 2 = 0 Then
                                ret.Append("    <tr class='grid_Item' >")
                            Else
                                ret.Append("    <tr class='grid_AlternatingItem' >")
                            End If
                            ret.Append("        <td >" & (j + 1).ToString & "</td>")
                            ret.Append("        <td >")
                            ret.Append("            <a style='color:#6600CC;' href='../WebApp/frmDocBookDetailShow.aspx?id=" & dr("document_register_id") & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >" & dr("book_no") & "</a>")
                            If Convert.IsDBNull(dr("request_no")) = False Then
                                ret.Append("        คำขอ : <font color='red'>" & dr("request_no") & "</font>")
                            End If
                            ret.Append("        </td>")
                            ret.Append("        <td >" & dr("title_name").ToString & "</td>")
                            ret.Append("        <td >" & dr("company_name").ToString & "</td>")
                            ret.Append("        <td >" & dr("company_doc_no").ToString & "</td>")
                            ret.Append("        <td >" & dr("organization_appname").ToString & "</td>")
                            ret.Append("        <td align='center' >" & Convert.ToDateTime(dr("register_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")

                            'Create Status Column
                            If Convert.IsDBNull(dr("close_date")) = False Then
                                dr("doc_status_name") += " " + Convert.ToDateTime(dr("close_date")).ToString("d/MM/yyyy", New Globalization.CultureInfo("th-TH"))
                            End If
                            If Convert.IsDBNull(dr("bookout_no")) = False Then
                                dr("doc_status_name") += Engine.Document.DocumentRegisterENG.GetBookOutDetailReports(Convert.ToInt64(dr("document_register_id")), trans)
                            End If
                            ret.Append("        <td >" & dr("doc_status_name").ToString & "</td>")

                            If Convert.IsDBNull(dr("expect_finish_date")) = False Then
                                ret.Append("    <td >" & Convert.ToDateTime(dr("expect_finish_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                            Else
                                ret.Append("    <td>&nbsp;</td>")
                            End If
                            ret.Append("    </tr>")
                        Next
                        tmpDt.Dispose()
                    End If
                Next
                gDt.Dispose()
            End If
            trans.CommitTransaction()
        End If
        dt.Dispose()

        Return ret
    End Function
End Class
