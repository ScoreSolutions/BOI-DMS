Imports System.Data

Partial Class rptGrid_rptkpibyorg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Binddata()
            BindGroupTitleRequest()
            'Session.Remove("formdt")
            'Session.Remove("todt")
        End If
    End Sub

    Private Sub Binddata()
        Try
            Dim dt As New DataTable

            Dim reports As New Cls_Report
            Dim DateFrom As String = Request("DateFrom").ToString.Replace("-", "") 'Convert.ToDateTime(Session("formdt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim DateTo As String = Request("DateTo").ToString.Replace("-", "") 'Convert.ToDateTime(Session("todt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            dt = reports.GetDocCatType(DateFrom, DateTo)
            If dt.Rows.Count > 0 Then
                Dim ret As New StringBuilder
                ret.Append("<table style='width:100%;' >")
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)
                    ret.Append("<tr><td >&nbsp;</td></tr>")
                    ret.Append("<tr>")
                    ret.Append("    <td align='center' class='Csslbl'>ระหว่างวันที่ ")
                    ret.Append(Config.GetStringToDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")))
                    ret.Append(" ถึง ")
                    ret.Append(Config.GetStringToDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH")))
                    ret.Append("    </td>")
                    ret.Append("</tr>")
                    ret.Append("<tr>")
                    ret.Append("    <td align='center' class='Csslbl'>" & dr("group_type_name") & "</td>")
                    ret.Append("</tr>")
                    Dim dtt As New DataTable
                    dtt = reports.RetriveKPIAll(DateFrom, DateTo, Convert.ToInt64(dr("id")))
                    If dtt.Rows.Count > 0 Then
                        Dim sumOfficer As Long = 0
                        Dim sumIncome As Long = 0
                        Dim sumRemainOver As Long = 0
                        Dim sumRemainNotOver As Long = 0
                        Dim sumOutOver As Long = 0
                        Dim sumOutNotOver As Long = 0
                        Dim sumTotRemainOver As Long = 0
                        Dim sumTotRemainNotOver As Long = 0
                        Dim sumOverCount As Long = 0

                        ret.Append("<tr>")
                        ret.Append("    <td>")
                        ret.Append(BuildHeaderRow())
                        For j As Integer = 0 To dtt.Rows.Count - 1
                            Dim drr As DataRow = dtt.Rows(j)
                            ret.Append("<tr class='grid_Item' >")
                            ret.Append("    <td align='center' class='Csslbl'>")
                            ret.Append("        " & drr("name_abb"))
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' class='Csslbl'>")
                            ret.Append("        " & drr("count_officer"))
                            sumOfficer += Convert.ToInt64(drr("count_officer"))

                            ret.Append("    </td>")
                            ret.Append("    <td align='center'  class='Csslbl'>&nbsp;")
                            If Convert.ToInt64(drr("income")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=Income"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("income"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumIncome += Convert.ToInt64(drr("income"))
                            End If
                            ret.Append("    </td>")
                            'ค้างสะสมเกินกำหนด
                            ret.Append("    <td align='center'  class='Csslbl'>&nbsp;")
                            If Convert.ToInt64(drr("remain_over")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("remain_over"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumRemainOver += Convert.ToInt64(drr("remain_over"))
                            End If
                            ret.Append("    </td>")

                            'ค้างสะสมไม่เกินกำหนด
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainNotOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("remain_notover"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumRemainNotOver += Convert.ToInt64(drr("remain_notover"))
                            End If
                            ret.Append("    </td>")

                            'ค้างสะสมรวม
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_over")) + Convert.ToInt64(drr("remain_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainAll"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(Convert.ToInt64(drr("remain_over")) + Convert.ToInt64(drr("remain_notover")), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                            End If
                            ret.Append("    </td>")

                            'ออกเกิน
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("out_over")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=OutOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("out_over"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumOutOver += Convert.ToInt64(drr("out_over"))
                            End If
                            ret.Append("    </td>")

                            'ออกไม่เกิน
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("out_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=OutNotOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("out_notover"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumOutNotOver += Convert.ToInt64(drr("out_notover"))
                            End If
                            ret.Append("    </td>")

                            'ออกรวม
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("out_over")) + Convert.ToInt64(drr("out_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=OutAll"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(Convert.ToInt64(drr("out_over")) + Convert.ToInt64(drr("out_notover")), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                            End If
                            ret.Append("    </td>")

                            'ค้างคงเหลือเกิน
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_tot_over")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainTotOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("remain_tot_over"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumTotRemainOver += Convert.ToInt64(drr("remain_tot_over"))
                            End If
                            ret.Append("    </td>")

                            'ค้างคงเหลือไม่เกิน
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_tot_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainTotNotOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(drr("remain_tot_notover"), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumTotRemainNotOver += Convert.ToInt64(drr("remain_tot_notover"))
                            End If
                            ret.Append("    </td>")

                            'ค้างคงเหลือรวม
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("remain_tot_notover")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=RemainTotAll"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("remain_tot_notover")), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                            End If
                            ret.Append("    </td>")

                            'งานที่ใช้เวลาเกินกำหนด
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("out_over")) > 0 Then
                                Dim aHref As String = ""
                                aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPIByOrg&rpType=BookOver"
                                aHref += "&OrgID=" & drr("id")
                                aHref += "&DateFrom=" & DateFrom & "&DateTo=" & DateTo
                                aHref += "&KpiGroupTypeID=" & dr("id")
                                aHref += "' target='_blank'  >" & Format(Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("out_over")), "#,##0")
                                aHref += "</a>"
                                ret.Append("        " & aHref)
                                sumOverCount += Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("out_over"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center'  class='Csslbl'>")
                            If Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("remain_tot_notover")) + Convert.ToInt64(drr("out_over")) + Convert.ToInt64(drr("out_notover")) <> 0 Then
                                Dim vRemainTotOver As Long = Convert.ToInt64(drr("remain_tot_over"))
                                Dim vOutOver As Long = Convert.ToInt64(drr("out_over")) + Convert.ToInt64(drr("out_notover"))
                                Dim vRemainTot As Long = Convert.ToInt64(drr("remain_tot_over")) + Convert.ToInt64(drr("remain_tot_notover"))
                                Dim vPover As Double = ((vRemainTotOver + Convert.ToInt64(drr("out_over"))) / (vOutOver + vRemainTot)) * 100
                                ret.Append("        " & Format(Math.Round(vPover, 2), "0.00"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("</tr>")
                        Next

                        ret.Append("<tr class='grid_AlternatingItem' >")
                        ret.Append("    <td class='Csslbl' align='center'>รวมทั้งหมด</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumOfficer, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumIncome, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumRemainOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumRemainNotOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format((sumRemainOver + sumRemainNotOver), "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumOutOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumOutNotOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format((sumOutOver + sumOutNotOver), "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumTotRemainOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumTotRemainNotOver, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format((sumTotRemainOver + sumTotRemainNotOver), "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(sumOverCount, "#,##0") & "</td>")
                        ret.Append("    <td class='Csslbl' align='center'>" & Format(Math.Round(((sumOutOver + sumTotRemainOver) / (sumTotRemainNotOver + sumTotRemainOver + sumOutOver + sumOutNotOver)) * 100, 2), "0.00") & "</td>")
                        ret.Append("</tr>")
                        ret.Append("</table")

                        ret.Append("    </td>")
                        ret.Append("</tr>")
                    End If
                    dtt.Dispose()
                Next
                ret.Append("</table>")
                lblDesc.Text = ret.ToString
                ret = Nothing
            End If
            dt.Dispose()
            reports = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Function BuildHeaderRow() As String
        Dim ret As String = ""
        ret += "<table style='width:100%;' border='0' cellpadding='0' cellspacing='0'  >"
        ret += "    <tr class='grid_Header' >"
        ret += "        <td  rowspan='2' >"
        ret += "            หน่วยงาน</td>"
        ret += "        <td  rowspan='2' >"
        ret += "            จำนวนเจ้าหน้าที่</td>"
        ret += "        <td rowspan='2' >"
        ret += "            งานเข้า</td>"
        ret += "        <td colspan='3' >"
        ret += "            งานค้างสะสม</td>"
        ret += "        <td colspan='3' >"
        ret += "            งานออก</td>"
        ret += "        <td colspan='3' >"
        ret += "            งานค้างคงเหลือ</td>"
        ret += "         <td colspan='2' >"
        ret += "             งานที่ใช้เวลาเกินกำหนด</td>"
        ret += "    </tr>"
        ret += "    <tr class='grid_Header' >"
        ret += "        <td >เกิน</td>"
        ret += "        <td >ไม่เกิน</td>"
        ret += "        <td >รวม</td>"
        ret += "        <td >เกิน</td>"
        ret += "        <td >ไม่เกิน</td>"
        ret += "        <td >รวม</td>"
        ret += "        <td >เกิน</td>"
        ret += "        <td >ไม่เกิน</td>"
        ret += "        <td >รวม</td>"
        ret += "        <td >จำนวน</td>"
        ret += "        <td >%.</td>"
        ret += "    </tr>"
        Return ret
    End Function

    Private Sub BindGroupTitleRequest()
        Dim rep As New Cls_Report
        Dim dt As DataTable = rep.GetGroupTitleRequest()
        If dt.Rows.Count > 0 Then
            lblGroupTitleRequest.Text += "<table border='1' cellpadding='0' cellspacing='0' width='800px'>"
            Dim gDt As New DataTable
            gDt = dt.DefaultView.ToTable(True, "group_type_name", "id").Copy
            If gDt.Rows.Count > 0 Then
                Dim gID As String = "0"
                For i As Integer = 0 To gDt.Rows.Count - 1
                    Dim gdr As DataRow = gDt.Rows(i)
                    dt.DefaultView.RowFilter = "id = '" & gdr("id") & "'"
                    For Each dr As DataRowView In dt.DefaultView
                        lblGroupTitleRequest.Text += "  <tr>"
                        If dr("id") <> gID Then
                            lblGroupTitleRequest.Text += "      <td rowspan='" & dt.DefaultView.Count & "' width='150px' >" & (i + 1).ToString & ". " & gdr("group_type_name") & "</td>"
                        End If
                        lblGroupTitleRequest.Text += "      <td>" & dr("group_title_name") & "</td>"
                        lblGroupTitleRequest.Text += "  </tr>"
                        gID = dr("id")
                    Next
                    dt.DefaultView.RowFilter = ""
                Next
                gDt.Dispose()
            End If
            lblGroupTitleRequest.Text += "</table>"
            dt.Dispose()
        End If
        rep = Nothing
    End Sub
End Class
