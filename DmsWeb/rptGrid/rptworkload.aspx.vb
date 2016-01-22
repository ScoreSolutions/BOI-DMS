Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptworkload
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Dim SqlDB As New cls_SqlDB
    Dim pcontrol As New PageControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim DateFrom As New Date(1, 1, 1)
            Dim DateTo As New Date(1, 1, 1)
            Dim OrgID As Long = Convert.ToInt64(Request("OrgID"))
            Dim rdiRepType As String = Request("rdiRepType")
            If Not Request("DateFrom") Is Nothing Then
                DateFrom = Config.GetStringToDate(Request("DateFrom"))
                lbl_fromdt.Text = DateFrom.ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
            Else
                lbl_fromdt.Text = ""
            End If
            If Not Request("DateTo") Is Nothing Then
                DateTo = Config.GetStringToDate(Request("DateTo"))
                lbl_todt.Text = DateTo.ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
            Else
                lbl_todt.Text = ""
            End If
            Dim eng As New Engine.Master.OrganizationEng
            Dim oPar As New Para.TABLE.OrganizationPara
            oPar = eng.GetOrgPara(OrgID)
            lblOrgName.Text = oPar.NAME_ABB
            eng = Nothing
            oPar = Nothing

            Select Case rdiRepType
                Case "0"
                    lblRepType.Text = "เข้า"
                Case "1"
                    lblRepType.Text = "ออก"
                Case "2"
                    lblRepType.Text = "ที่ถือครอง"
            End Select

            lblTimeFrame.Text = "Time frame = " & reports.GetTimeFrame(DateFrom, DateTo) & " วันทำการ"
            Binddata(DateFrom, DateTo, OrgID.ToString, rdiRepType)
        End If
    End Sub
    Private Sub Binddata(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String, ByVal rdiRepType As String)
        Try
            Dim ret As New StringBuilder
            ret.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            ret.Append(BuildReport(DateFrom, DateTo, OrgID, rdiRepType).ToString)
            ret.Append("</table>")
            ret.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            ret.Append("    <tr>")
            ret.Append("        <td class='Csslbl' align='left' >")
            ret.Append("            พิมพ์รายงาน ณ วันที่ : " & DateTime.Now.ToString("dd MMM yy", New Globalization.CultureInfo("th-TH")))
            ret.Append("        </td>")
            ret.Append("    </tr>")
            ret.Append("</table>")

            lblDesc.Text = ret.ToString
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub

    Private Function BuildReport(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String, ByVal rdiRepType As String) As StringBuilder
        Dim DinamicColQty As Integer = 0
        Dim DayHour As Double = 8

        Dim ret As New StringBuilder
        Dim dt As New DataTable
        dt = reports.RetreiveWorkLoad(OrgID, DateFrom, DateTo, rdiRepType)
        If dt.Rows.Count > 0 Then
            ret.Append("<tr>")
            ret.Append("    <td class='grid_Header' style='width: 20px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        ซี")
            ret.Append("    </td>")
            ret.Append("    <td class='grid_Header' style='border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        รายชื่อ")
            ret.Append("    </td>")

            Dim gDt As New DataTable
            gDt = dt.DefaultView.ToTable(True, "doc_cat_type_name").Copy
            gDt.Columns.Add("DayCol")
            gDt.Columns.Add("SumManday")
            Dim tmpTd As String = ""

            For i As Integer = 0 To gDt.Rows.Count - 1
                Dim gDr As DataRow = gDt.Rows(i)
                dt.DefaultView.RowFilter = "doc_cat_type_name = '" & gDr("doc_cat_type_name").ToString & "'"

                Dim DayCol As New DataTable
                dt.DefaultView.Sort = "std_proc_period desc"
                DayCol = dt.DefaultView.ToTable(True, "std_proc_period").Copy
                ret.Append("    <td class='grid_Header' style='border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' colspan='" & DayCol.Rows.Count & "' > ")
                ret.Append("        " & gDr("doc_cat_type_name"))
                ret.Append("    </td>")

                DinamicColQty += DayCol.Rows.Count
                For Each dr As DataRow In DayCol.Rows
                    tmpTd += "    <td class='grid_Header' style='width: 25px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;' >"
                    If Convert.ToDouble(dr("std_proc_period")) < 1 Then
                        tmpTd += "        งานที่<br />ใช้เวลา<br />" & (dr("std_proc_period") * DayHour) & " ชม."
                    Else
                        tmpTd += "        งานที่<br />ใช้เวลา<br />" & dr("std_proc_period") & " วัน"
                    End If
                    tmpTd += "    </td>"

                    If gDt.Rows(i)("DayCol").ToString = "" Then
                        gDt.Rows(i)("DayCol") = dr("std_proc_period")
                    Else
                        gDt.Rows(i)("DayCol") += "|" & dr("std_proc_period")
                    End If
                Next
                gDt.Rows(i)("SumManday") = 0

                DayCol = Nothing
                dt.DefaultView.RowFilter = ""
            Next
            ret.Append("    <td class='grid_Header' style='width: 80px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        ปริมาณ<br />(Man days)")
            ret.Append("    </td>")
            ret.Append("    <td class='grid_Header' style='width: 80px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        วันลา<br />(Days)")
            ret.Append("    </td>")
            ret.Append("    <td class='grid_Header' style='width: 80px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        กำลังคน<br />(Man days)")
            ret.Append("    </td>")
            ret.Append("    <td class='grid_Header' style='width: 80px; border-top: #91a7b4 1px solid; border-left: #91a7b4 1px solid;width:40px;' rowspan='2'> ")
            ret.Append("        Utilization <br />ของ จนท. <br />(%)")
            ret.Append("    </td>")
            ret.Append("</tr>")
            ret.Append("<tr>")
            ret.Append(tmpTd)
            ret.Append("</tr>")


            '######  Data Row    ###############
            Dim sumManDayQty As Double = 0
            Dim sumManDay As Double = 0


            Dim stDt As New DataTable
            dt.DefaultView.Sort = "officer_level desc"
            stDt = dt.DefaultView.ToTable(True, "officer_level", "officer_name", "officer_level_show").Copy
            For Each stDr As DataRow In stDt.Rows
                ret.Append("<tr>")
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid' >" & stDr("officer_level_show") & "</td>")
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid'>" & stDr("officer_name") & "</td>")

                Dim vDocQty As Double = 0
                Dim ManDayQty As Double = 0
                Dim vUtili As Double = 0
                For m As Integer = 0 To gDt.Rows.Count - 1
                    Dim gDr As DataRow = gDt.Rows(m)
                    dt.DefaultView.RowFilter = "doc_cat_type_name = '" & gDr("doc_cat_type_name").ToString & "' and officer_name = '" & stDr("officer_name") & "'"

                    Dim sumGroupManDay As Double = Convert.ToDouble(gDt.Rows(m)("SumManday"))
                    Dim ColData() As String = Split(gDr("DayCol"), "|")
                    Dim ColQty As Integer = ColData.Length
                    For j As Integer = 0 To ColQty - 1
                        Dim whText As String = ""
                        whText += " doc_cat_type_name = '" & gDr("doc_cat_type_name").ToString & "' "
                        whText += " and officer_name = '" & stDr("officer_name") & "'"
                        whText += " and std_proc_period = '" & ColData(j) & "'"
                        dt.DefaultView.RowFilter = whText

                        ret.Append("    <td class='Csslbl' align='center' style='border: #91a7b4 1px solid' >&nbsp;")
                        If dt.DefaultView.Count > 0 Then
                            Dim repType As String = ""
                            Select Case rdiRepType
                                Case "0"
                                    repType = "INCOME"
                                Case "1"
                                    repType = "OUT"
                                Case "2"
                                    repType = "REMAIN"
                            End Select

                            Dim aHref As String = ""
                            aHref += "<a href='../rptGrid/rptDocList.aspx?vPage=rptWorkLoad&rpType=" & repType
                            aHref += "&OfficerID=" & dt.DefaultView.Item(0)("officer_id").ToString
                            aHref += "&OrgID=" & OrgID & "&GroupTitleTypeID=" & dt.DefaultView.Item(0)("group_title_type_id").ToString
                            aHref += "&StdProc=" & ColData(j)
                            aHref += "&DateFrom=" & DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
                            aHref += "&DateTo=" & DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "' "
                            aHref += " target='_blank' >" & dt.DefaultView.Item(0)("count_doc").ToString & "</a>"

                            ret.Append(aHref)
                            ManDayQty += (Convert.ToDouble(dt.DefaultView.Item(0)("count_doc")) * Convert.ToDouble(ColData(j)))
                            sumGroupManDay += (Convert.ToDouble(dt.DefaultView.Item(0)("count_doc")) * Convert.ToDouble(ColData(j)))
                        End If
                        ret.Append("    </td>")
                    Next
                    gDt.Rows(m)("SumManday") = sumGroupManDay
                    dt.DefaultView.RowFilter = ""
                Next

                Dim vAbSent As Double = GetAbSent(DateFrom, DateTo)
                Dim ManDays As Double = (GetManDays(IIf(Convert.IsDBNull(stDr("officer_level")) = False, stDr("officer_level"), ""), DateFrom, DateTo) - vAbSent)
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid' align='center' >" & Format(ManDayQty, "#,##0.00") & "</td>")
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid' align='center' >" & vAbSent.ToString & "</td>")
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid' align='center' >" & ManDays & "</td>")
                ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid' align='center' >" & Format((ManDayQty * 100) / ManDays, "#,##0.00") & "</td>")
                sumManDayQty += ManDayQty
                sumManDay += ManDays
                dt.DefaultView.RowFilter = ""
                ret.Append("</tr>")
            Next


            '####### Footer Row
            For i As Integer = 0 To gDt.Rows.Count - 1
                ret.Append("<tr>")
                If i = 0 Then
                    ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>รวม จนท.</td>")
                    ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>" & stDt.Rows.Count & " คน</td>")
                Else
                    ret.Append("    <td>&nbsp;</td>")
                    ret.Append("    <td>&nbsp;</td>")
                End If
                ret.Append("    <td>&nbsp;</td>")
                ret.Append("    <td align='left' colspan='" & ((DinamicColQty - 4) / 2) & "' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;' >" & gDt.Rows(i)("doc_cat_type_name") & "</td>")
                ret.Append("    <td align='left' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>" & Format(Convert.ToDouble(gDt.Rows(i)("SumManday")), "#,##0.00") & "</td>")
                ret.Append("    <td align='left' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>Man days</td>")
                ret.Append("    <td>&nbsp;</td>")
                If i = 0 Then
                    ret.Append("    <td align='left'  colspan='" & ((DinamicColQty - 4) / 2) & "' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>รวมปริมาณงานของกอง</td>")
                    ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>" & Format(sumManDayQty, "#,##0.00") & "</td>")
                    ret.Append("    <td align='left' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;' >Man days</td>")
                ElseIf i = 1 Then
                    ret.Append("    <td align='left'  colspan='" & ((DinamicColQty - 4) / 2) & "' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;' >รวมกำลังคนของกอง</td>")
                    ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>" & Format(sumManDay, "#,##0.00") & "</td>")
                    ret.Append("    <td align='left' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;' >Man days</td>")
                ElseIf i = 2 Then
                    ret.Append("    <td align='left'  colspan='" & ((DinamicColQty - 4) / 2) & "' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>Utilization เฉลี่ยของ จนท.กอง</td>")
                    ret.Append("    <td class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>" & Format((sumManDayQty * 100) / sumManDay, "#,##0.00") & "</td>")
                    ret.Append("    <td align='left' class='Csslbl' style='border: #91a7b4 1px solid;background-color:#99CCFF;'>%</td>")
                End If
                ret.Append("</tr>")
            Next

            stDt = Nothing
            dt = Nothing
            gDt = Nothing
        End If

        Return ret
    End Function

    Private Function GetAbSent(ByVal vDateFrom As DateTime, ByVal vDateTo As DateTime) As Double
        Return 0
    End Function
    Private Function GetManDays(ByVal OfficerLevel As String, ByVal vDateFrom As DateTime, ByVal vDateTo As DateTime) As Double
        Dim StartDate As String = vDateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim EndDate As String = vDateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

        Dim hEng As New Engine.Master.HolidayEng
        Dim hDt As New DataTable
        hDt = hEng.GetDataHolidayList("convert(varchar(8),holiday_date,112) between '" & StartDate & "' and '" & EndDate & "'", "")

        Return ((DateDiff(DateInterval.Day, vDateFrom, vDateTo) + 1) - hDt.Rows.Count) * GetLostFactor(OfficerLevel)
    End Function

    Private Function GetLostFactor(ByVal OfficerLevel As String) As Double
        Dim ret As Double = 0.8
        If IsNumeric(OfficerLevel) = True Then
            If OfficerLevel >= 8 Then
                ret = 0.6
            ElseIf OfficerLevel >= 7 Then
                ret = 0.7
            Else
                ret = 0.8
            End If
        End If
        Return ret
    End Function

End Class
