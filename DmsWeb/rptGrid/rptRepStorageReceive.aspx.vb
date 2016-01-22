Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptRepStorageReceive
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Request("OrgID") IsNot Nothing Then
                Dim oEng As New Engine.Master.OrganizationEng
                Dim oPara As New Para.TABLE.OrganizationPara
                oPara = oEng.GetOrgPara(Request("OrgID"))
                lblStorageOrgName.Text = oPara.ORG_NAME
                oPara = Nothing
                oEng = Nothing
            End If

            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                Dim DateFrom As Date = Config.GetStringToDate(Request("DateFrom"))
                Dim DateTo As Date = Config.GetStringToDate(Request("DateTo"))

                lblDateInterval.Text = "ระหว่างวันที่ "
                lblDateInterval.Text += DateFrom.ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                lblDateInterval.Text += " ถึง "
                lblDateInterval.Text += DateTo.ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))

                Binddata(DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")), DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")), Request("OrgID"))
            End If
        End If
    End Sub

    Private Sub Binddata(ByVal DateFrom As String, ByVal DateTo As String, ByVal OrgID As String)
        Dim dt As New DataTable
        reports.OrgID = OrgID
        'Dim DateFrom As String = Convert.ToDateTime(Session("formdt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        'Dim DateTo As String = Convert.ToDateTime(Session("todt")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        dt = reports.GetDataStorage(OrgID, DateFrom, DateTo)
        If dt.Rows.Count > 0 Then
            Dim ret As String = ""
            Dim TotCheck As Long = 0
            Dim TotMachine As Long = 0
            Dim TotMaterial As Long = 0
            Dim TotStock As Long = 0
            Dim TotLand As Long = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                Dim aHref As String = "<a href='../rptGrid/rptDocList.aspx?vPage=rptRepStorageReceive&OrgID=" & dr("id") & "&DateFrom=" & DateFrom & "&DateTo=" & DateTo & "&ReceiveOrgID=" & OrgID
                ret += "<tr class='grid_Item' >"
                ret += "    <td align='center' >"
                ret += "        " & dr("name_abb").ToString
                ret += "    </td>"
                ret += "    <td align='center' >"
                ret += "        " & aHref & "&SendGroupTypeID=1' target='_blank' >" & dr("recheck").ToString
                ret += "        </a>"
                ret += "    </td>"
                ret += "    <td align='center' >"
                ret += "        " & aHref & "&SendGroupTypeID=2' target='_blank' >" & dr("machine").ToString
                ret += "        </a>"
                ret += "    </td>"
                ret += "    <td align='center' >"
                ret += "        " & aHref & "&SendGroupTypeID=3' target='_blank' >" & dr("material").ToString
                ret += "        </a>"
                ret += "    </td>"
                ret += "    <td align='center' >"
                ret += "        " & aHref & "&SendGroupTypeID=4' target='_blank' >" & dr("stock").ToString
                ret += "        </a>"
                ret += "    </td>"
                ret += "    <td align='center' >"
                ret += "        " & aHref & "&SendGroupTypeID=5' target='_blank' >" & dr("land").ToString
                ret += "        </a>"
                ret += "    </td>"

                Dim Total As Long = Convert.ToInt64(dr("recheck")) + Convert.ToInt64(dr("machine")) + Convert.ToInt64(dr("material")) + Convert.ToInt64(dr("stock")) + Convert.ToInt64(dr("land"))
                ret += "    <td align='center' >" & Total.ToString & "</td>"
                ret += "</tr>"

                TotCheck += Convert.ToInt64(dr("recheck"))
                TotMachine += Convert.ToInt64(dr("machine"))
                TotMaterial += Convert.ToInt64(dr("material"))
                TotStock += Convert.ToInt64(dr("stock"))
                TotLand += Convert.ToInt64(dr("land"))
            Next
            ret += "<tr class='grid_Header' >"
            ret += "    <td align='center' >รวม</td>"
            ret += "    <td align='center' >" & TotCheck & "</td>"
            ret += "    <td align='center' >" & TotMachine & "</td>"
            ret += "    <td align='center' >" & TotMaterial & "</td>"
            ret += "    <td align='center' >" & TotStock & "</td>"
            ret += "    <td align='center' >" & TotLand & "</td>"
            ret += "    <td align='center' >" & (TotCheck + TotMachine + TotMaterial + TotStock + TotLand) & "</td>"
            ret += "</tr>"
            lblDesc.Text = ret
        End If
        dt.Dispose()
    End Sub
End Class
