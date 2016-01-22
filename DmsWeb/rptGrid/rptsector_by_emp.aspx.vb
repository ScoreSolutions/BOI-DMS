Imports System
Imports System.Data
Imports MycustomDG
Partial Class rptGrid_rptsector_by_emp
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Dim SqlDb As New cls_SqlDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim OrgID As Long = 0
            Dim OfficerID As Long = 0
            Dim DateFrom As New Date(1, 1, 1)
            If Not Request("DateFrom") Is Nothing Then
                DateFrom = Config.GetStringToDate(Request("DateFrom"))
                lbl_fromdt.Text = DateFrom.ToString("dd MMM yy", New Globalization.CultureInfo("th-TH"))
            Else
                lbl_fromdt.Text = ""
            End If
            If Not Request("OrgID") Is Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim eng As New Engine.Master.OrganizationEng
                Dim para As New Para.TABLE.OrganizationPara
                para = eng.GetOrgPara(OrgID)
                lbl_organizename.Text = para.NAME_ABB
                para = Nothing
                eng = Nothing
            Else
                lbl_organizename.Text = ""
            End If
            If Not Request("OfficerID") Is Nothing Then
                OfficerID = Convert.ToInt64(Request("OfficerID"))
                Dim eng As New Engine.Master.OfficerEng
                Dim para As New Para.TABLE.OfficerPara
                para = eng.GetOfficerPara(OfficerID)
                lbl_officername.Text = para.FIRST_NAME & " " & para.LAST_NAME
                para = Nothing
                eng = Nothing
            Else
                reports.officer_id_possess = ""
            End If
            Binddata(DateFrom, OrgID.ToString, OfficerID.ToString)
        End If
    End Sub
    Private Sub Binddata(ByVal DateFrom As Date, ByVal OrgID As String, ByVal OfficerID As String)
        Try
            Dim dt As New DataTable

            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            reports.officer_id_possess = OfficerID

            dt = reports.RetreiveSectorbyemp
            If dt.Rows.Count > 0 Then
                reports.BuildDueDate(dt)
                Dim ret As String = "<table style='width:100%;' border='0' cellpadding='0' cellspacing='0'  >"
                ret += GetColumnHeader()
                Dim gDt As New DataTable
                gDt = dt.DefaultView.ToTable(True, "group_title_name").Copy
                For i As Integer = 0 To gDt.Rows.Count - 1
                    ret += "    <tr>"
                    ret += "        <td colspan='18' style='background-color: #FFFBD6;font-size:18px'>" & gDt.Rows(i)("group_title_name").ToString & "</td>"
                    ret += "    </tr>"

                    dt.DefaultView.RowFilter = "group_title_name = '" & gDt.Rows(i)("group_title_name").ToString & "'"
                    Dim tmpDt As New DataTable
                    tmpDt = dt.DefaultView.ToTable.Copy
                    dt.DefaultView.RowFilter = ""

                    For j As Integer = 0 To tmpDt.Rows.Count - 1
                        Dim dr As DataRow = tmpDt.Rows(j)
                        If j Mod 2 = 0 Then
                            ret += "    <tr class='grid_Item' >"
                        Else
                            ret += "    <tr class='grid_AlternatingItem' >"
                        End If
                        ret += "        <td align='center' >" & (j + 1).ToString & "</td>"
                        ret += "        <td ><a style='color:#6600CC;' href='../WebApp/frmDocBookDetailShow.aspx?id=" & dr("document_register_id") & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >" & dr("book_no") & "</a></td>"
                        ret += "        <td align='center' >" & Convert.ToDateTime(dr("register_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>"
                        ret += "        <td align='center' >" & Convert.ToDateTime(dr("expect_finish_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>"
                        ret += "        <td >" & dr("company_name") & "</td>"
                        ret += "        <td align='center' >" & Convert.ToDateTime(dr("register_date")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")) & "</td>"
                        ret += "        <td >" & IIf(Convert.IsDBNull(dr("officer_name")) = False, dr("officer_name").ToString, "&nbsp;") & "</td>"
                        If Convert.ToInt64(dr("overdue")) > 0 Then
                            ret += "        <td align='center' >" & dr("overdue") & "</td>"
                        Else
                            ret += "        <td align='center' >&nbsp;</td>"
                        End If
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "        <td style='width:50px' >&nbsp;</td>"
                        ret += "    </tr>"
                    Next
                    tmpDt.Dispose()
                Next
                ret += "</table>"
                lblDesc.Text = ret
                dt.Dispose()
                reports = Nothing
            Else
                lbl_result.Text = "data not found !!"
            End If
            dt.Dispose()
            lbl_fromdt.Text = "วันที่ " & DateFrom.ToString("dd MMM yy", System.Globalization.CultureInfo.GetCultureInfo("th-TH"))
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
    Private Function GetColumnHeader() As String
        Dim ret As String = ""
        ret += "    <tr class='grid_Header' >"
        ret += "        <td  style='width:30px;' rowspan='2' >ลำดับ</td>"
        ret += "        <td  style='width:100px;' rowspan='2' >ทะเบียน</td>"
        ret += "        <td  style='width:100px;' rowspan='2' >วันที่ลงทะเบียน</td>"
        ret += "        <td  style='width:100px;' rowspan='2' >ครบกำหนด<br />สนง.</td>"
        ret += "        <td  style='width:150px;' rowspan='2' >บริษัท</td>"
        ret += "        <td  style='width:100px;' rowspan='2' >วันที่รับ " & lbl_organizename.Text & "</td>"
        ret += "        <td  style='width:150px;' rowspan='2' >ผู้พิจารณา</td>"
        ret += "        <td  style='width:60px;' rowspan='2' >เกินกำหนด<br />(วัน)</td>"
        ret += "        <td  colspan='6' >สาเหตุ</td>"
        ret += "        <td  colspan='3' >การแก้ปัญหา</td>"
        ret += "        <td  rowspan='2' >กำหนดวัน<br />แล้วเสร็จ</td>"
        ret += "    </tr>"
        ret += "    <tr class='grid_Header' >"
        ret += "        <td style='width:50px' >รอข้อมูล</td>"
        ret += "        <td style='width:50px' >กำลัง<br />พิจารณา</td>"
        ret += "        <td style='width:50px' >รออนุมัติ</td>"
        ret += "        <td style='width:50px' >รอประชุม</td>"
        ret += "        <td style='width:50px' >รอนโยบาย</td>"
        ret += "        <td style='width:50px' >อื่นๆ<br />(ระบุรายละเอียด)</td>"
        ret += "        <td style='width:50px' >ออกหนังสือ</td>"
        ret += "        <td style='width:50px' >ให้มาชี้แจง</td>"
        ret += "        <td style='width:50px' >อื่นๆ<br />(ระบุรายละเอียด)</td>"
        ret += "    </tr>"

        Return ret
    End Function
End Class
