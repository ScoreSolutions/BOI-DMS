Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_docrcv
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Binddata()
        End If
    End Sub
    Private Sub Binddata()
        Try
            If Request("OrgID") IsNot Nothing Then
                Dim oPara As New Para.TABLE.OrganizationPara
                Dim eng As New Engine.Master.OrganizationEng
                oPara = eng.GetOrgPara(Convert.ToInt64(Request("OrgID")))
                If oPara.ID <> 0 Then
                    lbl_result.Text = oPara.ORG_NAME & "<br />"
                Else
                    lbl_result.Text = ""
                End If
                oPara = Nothing
                eng = Nothing
            End If

            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                lbl_result.Text += "ระหว่างวันที่ " & Config.GetStringToDate(Request("DateFrom")).ToString("dd MMM yy", New Globalization.CultureInfo("th-TH"))
                lbl_result.Text += " ถึง " & Config.GetStringToDate(Request("DateTo")).ToString("dd MMM yy", New Globalization.CultureInfo("th-TH"))
            End If

            Dim dt As New DataTable
            'reports.OrgID = Session("OrgID")
            'reports.fromdate = Convert.ToDateTime(Session("formdt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            'reports.todt = Convert.ToDateTime(Session("todt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = Convert.ToInt64(Request("OrgID"))
            reports.fromdate = Request("DateFrom").Replace("-", "")
            reports.todt = Request("DateTo").Replace("-", "")
            dt = reports.rptdocrcv
            If dt.Rows.Count > 0 Then
                Dim ret As String = "<table width='100%' border='0' cellpadding='0' cellspacing='0'>"
                ret += GenerateReport(dt).ToString
                ret += "</table>"

                lblDesc.Text = ret
                dt.Dispose()
            Else
                lbl_result.Text = "ไม่พบข้อมูล"
            End If
            reports = Nothing
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub

    Private Function GenerateReport(ByVal dt As DataTable) As StringBuilder
        Dim ret As New StringBuilder
        ret.Append("<tr class='grid_Header'>")
        ret.Append("    <td style='width:80px;' align='center' >เลขที่หนังสือ</td>")
        ret.Append("    <td style='width:80px;' align='center' >วันที่ลงทะเบียน</td>")
        ret.Append("    <td style='width:350px;' align='center' >ชื่อเรื่อง</td>")
        ret.Append("    <td style='width:200px;' align='center' >หน่วยงาน</td>")
        ret.Append("    <td style='width:80px;' align='center' >เลขที่หนังสือองค์กร</td>")
        ret.Append("    <td style='width:60px;' align='center' >เลขที่คำขอ</td>")
        ret.Append("</tr>")

        Dim gDt As New DataTable
        gDt = dt.DefaultView.ToTable(True, "group_title_code", "group_title_name").Copy
        If gDt.Rows.Count > 0 Then
            For Each gDr As DataRow In gDt.Rows
                ret.Append("    <tr>")
                ret.Append("        <td colspan='6' style='background-color: #FFFBD6;font-size:18px'>" & gDr("group_title_name").ToString & "</td>")
                ret.Append("    </tr>")

                dt.DefaultView.RowFilter = "group_title_code = '" & gDr("group_title_code") & "' "
                Dim dv As DataView = dt.DefaultView
                Dim i As Integer = 0

                For Each dr As DataRowView In dv
                    If i Mod 2 = 0 Then
                        ret.Append("<tr class='grid_Item'>")
                    Else
                        ret.Append("<tr class='grid_AlternatingItem'>")
                    End If

                    ret.Append("    <td align='center' ><a href='../WebApp/frmDocBookDetailShow.aspx?id=" & dr("document_register_id") & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >" & dr("book_no") & "</a></td>")
                    ret.Append("    <td align='center' >" & Convert.ToDateTime(dr("register_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>")
                    ret.Append("    <td >" & dr("title_name") & "</td>")
                    ret.Append("    <td >" & dr("company_name") & "</td>")
                    ret.Append("    <td >" & dr("company_doc_no") & "</td>")
                    ret.Append("    <td >" & dr("request_no") & "</td>")
                    ret.Append("</tr>")
                    i += 1
                Next
                dv = Nothing
                dt.DefaultView.RowFilter = ""
            Next
        End If
        gDt.Dispose()

        Return ret
    End Function

End Class
