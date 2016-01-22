Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptkpibyemp
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim OrgID As Long = 0
            Dim OfficerID As String = ""
            Dim DateFrom As New Date(1, 1, 1)
            Dim DateTo As New Date(1, 1, 1)

            If Not Request("DateFrom") Is Nothing Then
                DateFrom = Config.GetStringToDate(Request("DateFrom"))
                lbl_fromdt.Text = DateFrom.ToString("dd MMM yy")
            Else
                lbl_fromdt.Text = ""
            End If
            If Not Request("DateTo") Is Nothing Then
                DateTo = Config.GetStringToDate(Request("DateTo"))
                lbl_todt.Text = DateTo.ToString("dd MMM yy")
            Else
                lbl_todt.Text = ""
            End If
            If Not Request("OrgID") Is Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim eng As New Engine.Master.OrganizationEng
                Dim para As New Para.TABLE.OrganizationPara
                para = eng.GetOrgPara(OrgID)
                lbl_organizename.Text = para.NAME_ABB
                eng = Nothing
                para = Nothing
            Else
                lbl_organizename.Text = ""
            End If
            If Request("OfficerID") IsNot Nothing Then
                OfficerID = Request("OfficerID")
                Dim eng As New Engine.Master.OfficerEng
                Dim para As New Para.TABLE.OfficerPara
                para = eng.GetOfficerPara(Convert.ToInt64(OfficerID))
                lbl_organizename.Text += "<br />เจ้าหน้าที่ " & para.FIRST_NAME & " " & para.LAST_NAME
                para = Nothing
                eng = Nothing
            End If
            Binddata(DateFrom, DateTo, OrgID, OfficerID, Request("IsExpectedFinishDate"))

            'Session.Remove("OrgID")
            'Session.Remove("OfficerID")
            'Session.Remove("todt")
            'Session.Remove("formdt")
        End If
    End Sub
    Private Sub Binddata(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String, ByVal OfficerID As String, ByVal IsExpectedFinishDate As String)
        Try
            Dim dt As New DataTable
            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.todt = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            reports.officer_id_approve = OfficerID 'IIf(Session("OfficerID") IsNot Nothing, Session("OfficerID"), "")
            reports.havefinishdate = IsExpectedFinishDate 'Session("IsExpectedFinishDate")
            dt = reports.RetreiveKPIByEMP
            If dt.Rows.Count > 0 Then
                lblDesc.Text = "<table style='width:100%;' border='1' cellpadding='0' cellspacing='0'  >"
                lblDesc.Text += "   <tr class='grid_Header' >"
                lblDesc.Text += "       <td style='border-bottom:0px;' >เรื่อง</td>"
                lblDesc.Text += "       <td style='border-bottom:0px;background-color:#FFFBD6;' >เข้า</td>"
                lblDesc.Text += "       <td colspan='3' style='width:150px;'>ค้างสะสม</td>"
                lblDesc.Text += "       <td colspan='3' style='background-color:#FFFBD6;' >ออก</td>"
                lblDesc.Text += "       <td colspan='3' >ค้างคงเหลือ</td>"
                lblDesc.Text += "       <td colspan='4' style='background-color:#FFFBD6;' >KPI</td>"
                lblDesc.Text += "   </tr>"
                lblDesc.Text += "   <tr class='grid_Header' >"
                lblDesc.Text += "       <td style='border-top:0px;'>&nbsp;</td>"
                lblDesc.Text += "       <td style='width:50px;border-top:0px;background-color:#FFFBD6;'>&nbsp;</td>"
                lblDesc.Text += "       <td style='width:50px;'>เกิน</td>"
                lblDesc.Text += "       <td style='width:50px;'>ไม่เกิน</td>"
                lblDesc.Text += "       <td style='width:50px;'>รวม</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;'>เกิน</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;'>ไม่เกิน</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;'>รวม</td>"
                lblDesc.Text += "       <td style='width:50px;'>เกิน</td>"
                lblDesc.Text += "       <td style='width:50px;'>ไม่เกิน</td>"
                lblDesc.Text += "       <td style='width:50px;'>รวม</td> "
                lblDesc.Text += "       <td style='background-color: #FFFBD6;width:50px; '>กำหนด</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;width:50px; '>AVG.</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;width:50px; '>MAX.</td>"
                lblDesc.Text += "       <td style='background-color: #FFFBD6;width:50px; '>MIN.</td>"
                lblDesc.Text += "   </tr>"


                'For Total Sum
                Dim totIncome As Double = 0
                Dim totRemOver As Double = 0
                Dim totRemNotOver As Double = 0
                Dim totOutOver As Double = 0
                Dim totOutNotOver As Double = 0
                Dim totRemTotOver As Double = 0
                Dim totRemTotNotOver As Double = 0

                Dim gDt As New DataTable
                gDt = dt.DefaultView.ToTable(True, "doc_cat_type_name").Copy
                For Each gDr As DataRow In gDt.Rows
                    Dim ret As New StringBuilder

                    'For Sum By Group Title
                    Dim sumIncome As Double = 0
                    Dim sumRemOver As Double = 0
                    Dim sumRemNotOver As Double = 0
                    Dim sumOutOver As Double = 0
                    Dim sumOutNotOver As Double = 0
                    Dim sumRemTotOver As Double = 0
                    Dim sumRemTotNotOver As Double = 0

                    Dim tmpDt As New DataTable
                    dt.DefaultView.RowFilter = "doc_cat_type_name = '" & gDr("doc_cat_type_name") & "'"
                    tmpDt = dt.DefaultView.ToTable.Copy
                    dt.DefaultView.RowFilter = ""
                    Dim IsShowTotal As Boolean = False
                    For i As Integer = 0 To tmpDt.Rows.Count - 1
                        Dim dr As DataRow = tmpDt.Rows(i)
                        If Convert.ToDouble(dr("income")) <> 0 Or Convert.ToDouble(dr("remain_over")) <> 0 Or Convert.ToDouble(dr("remain_notover")) <> 0 Or Convert.ToDouble(dr("out_over")) <> 0 Or Convert.ToInt64(dr("out_notover")) <> 0 Or Convert.ToInt64(dr("remain_tot_over")) <> 0 Or Convert.ToInt64(dr("remain_tot_notover")) <> 0 Then
                            IsShowTotal = True
                            If i Mod 2 = 0 Then
                                ret.Append("<tr class='grid_Item'>")
                            Else
                                ret.Append("<tr class='grid_AlternatingItem'>")
                            End If

                            ret.Append("    <td align='left'>")
                            ret.Append("        " & dr("group_title_name"))
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;' >&nbsp;")
                            If Convert.ToDouble(dr("income")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=INCOME")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("income").ToString)
                                ret.Append("</a>")
                                sumIncome += Convert.ToDouble(dr("income"))
                            End If
                            ret.Append("    </td>")

                            'ค้างสะสม
                            ret.Append("    <td align='center'>&nbsp;")
                            If Convert.ToDouble(dr("remain_over")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("remain_over").ToString)
                                ret.Append("</a>")
                                sumRemOver += Convert.ToDouble(dr("remain_over"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center'>&nbsp;")
                            If Convert.ToDouble(dr("remain_notover")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainNotOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("remain_notover").ToString)
                                ret.Append("</a>")
                                sumRemNotOver += Convert.ToDouble(dr("remain_notover"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center'>&nbsp;")
                            Dim vRemainTotal As Double = Convert.ToInt64(dr("remain_over")) + Convert.ToInt64(dr("remain_notover"))
                            If vRemainTotal <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainAll")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(vRemainTotal.ToString)
                                ret.Append("</a>")
                            End If
                            ret.Append("    </td>")

                            'ออก
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            If Convert.ToDouble(dr("out_over")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=OutOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("out_over").ToString)
                                ret.Append("</a>")
                                sumOutOver += Convert.ToDouble(dr("out_over"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            If Convert.ToDouble(dr("out_notover")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=OutNotOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("out_notover").ToString)
                                ret.Append("</a>")
                                sumOutNotOver += Convert.ToDouble(dr("out_notover"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            Dim vTotOut As Double = Convert.ToInt64(dr("out_over")) + Convert.ToInt64(dr("out_notover"))
                            If vTotOut <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=OutAll")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(vTotOut.ToString)
                                ret.Append("</a>")
                            End If
                            ret.Append("    </td>")

                            'ค้างคงเหลือ
                            ret.Append("    <td align='center'>&nbsp;")
                            If Convert.ToInt64(dr("remain_tot_over")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainTotOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("remain_tot_over").ToString)
                                ret.Append("</a>")
                                sumRemTotOver += Convert.ToInt64(dr("remain_tot_over"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center'>&nbsp;")
                            If Convert.ToInt64(dr("remain_tot_notover")) <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainTotNotOver")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(dr("remain_tot_notover").ToString)
                                ret.Append("</a>")
                                sumRemTotNotOver += Convert.ToInt64(dr("remain_tot_notover"))
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center'>&nbsp;")
                            Dim vRemTotOver As Double = Convert.ToInt64(dr("remain_tot_over")) + Convert.ToInt64(dr("remain_tot_notover"))
                            If vRemTotOver <> 0 Then
                                ret.Append("<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=RemainTotAll")
                                ret.Append("&gID=" & dr("group_title_id") & "&orgID=" & reports.OrgID)
                                ret.Append(IIf(OfficerID.Trim <> "", "&OfficerID=" & OfficerID.Trim, ""))
                                ret.Append("&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & IsExpectedFinishDate & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >")
                                ret.Append(vRemTotOver.ToString)
                                ret.Append("</a>")
                            End If
                            ret.Append("    </td>")
                            'KPI
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>")
                            ret.Append("        " & Convert.ToDouble(dr("max_proc_period")))
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            If Convert.ToInt64(dr("out_over")) + Convert.ToInt64(dr("out_notover")) <> 0 Then
                                Dim vKpiAvg As Double = (dr("sumworkday") / (Convert.ToInt64(dr("out_over")) + Convert.ToInt64(dr("out_notover"))))
                                ret.Append("        " & Math.Round(vKpiAvg, 2))
                            Else
                                ret.Append("0")
                            End If
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            ret.Append("        " & dr("kpi_max"))
                            ret.Append("    </td>")
                            ret.Append("    <td align='center' style='background-color: #FFFBD6;'>&nbsp;")
                            ret.Append("        " & dr("kpi_min"))
                            ret.Append("    </td>")
                            ret.Append("</tr>")
                        End If
                    Next
                    If IsShowTotal = True Then
                        ret.Append("<tr class='grid_Header' style='background-color:#B1B1B1;'>")
                        ret.Append("    <td align='center'>รวม</td>")
                        ret.Append("    <td align='center'>" & sumIncome.ToString("#,##0") & "</td>")
                        ret.Append("    <td align='center'>" & sumRemOver & "</td>")
                        ret.Append("    <td align='center'>" & sumRemNotOver & "</td>")
                        ret.Append("    <td align='center'>" & (sumRemOver + sumRemNotOver) & "</td>")
                        ret.Append("    <td align='center'>" & sumOutOver & "</td>")
                        ret.Append("    <td align='center'>" & sumOutNotOver & "</td>")
                        ret.Append("    <td align='center'>" & (sumOutOver + sumOutNotOver) & "</td>")
                        ret.Append("    <td align='center'>" & sumRemTotOver & "</td>")
                        ret.Append("    <td align='center'>" & sumRemTotNotOver & "</td>")
                        ret.Append("    <td align='center'>" & (sumRemTotOver + sumRemTotNotOver) & "</td>")
                        ret.Append("    <td align='center'>&nbsp;</td>")
                        ret.Append("    <td align='center'>&nbsp;</td>")
                        ret.Append("    <td align='center'>&nbsp;</td>")
                        ret.Append("    <td align='center'>&nbsp;</td>")
                        ret.Append("</tr>")

                        totIncome += sumIncome
                        totRemOver += sumRemOver
                        totRemNotOver += sumRemNotOver
                        totOutOver += sumOutOver
                        totOutNotOver += sumOutNotOver
                        totRemTotOver += sumRemTotOver
                        totRemTotNotOver += sumRemTotNotOver
                    End If

                    lblDesc.Text += ret.ToString
                    ret = Nothing
                    tmpDt.Dispose()
                Next
                lblDesc.Text += "<tr class='grid_Header' style='background-color:#B1B1B1;'>"
                lblDesc.Text += "    <td align='center'>รวมทั้งสิ้น</td>"
                lblDesc.Text += "    <td align='center'>" & totIncome.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totRemOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totRemNotOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & (totRemOver + totRemNotOver).ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totOutOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totOutNotOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & (totOutOver + totOutNotOver).ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totRemTotOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & totRemTotNotOver.ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>" & (totRemTotOver + totRemTotNotOver).ToString("#,##0") & "</td>"
                lblDesc.Text += "    <td align='center'>&nbsp;</td>"
                lblDesc.Text += "    <td align='center'>&nbsp;</td>"
                lblDesc.Text += "    <td align='center'>&nbsp;</td>"
                lblDesc.Text += "    <td align='center'>&nbsp;</td>"
                lblDesc.Text += "</tr>"
                lblDesc.Text += "</table>"
                gDt.Dispose()
                dt.Dispose()
            End If
            reports = Nothing
        Catch ex As Exception

        End Try
    End Sub
    
End Class
