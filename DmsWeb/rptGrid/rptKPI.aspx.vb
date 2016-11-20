Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptKPI
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim OrgID As Long = 0
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
                lblOfficerID.Text = Request("OfficerID")
                Dim eng As New Engine.Master.OfficerEng
                Dim para As New Para.TABLE.OfficerPara
                para = eng.GetOfficerPara(Convert.ToInt64(lblOfficerID.Text))
                lbl_organizename.Text += "<br />เจ้าหน้าที่ " & para.FIRST_NAME & " " & para.LAST_NAME
                para = Nothing
                eng = Nothing


            End If
            Binddata(DateFrom, DateTo, OrgID)

            'Session.Remove("OrgID")
            'Session.Remove("OfficerID")
            'Session.Remove("todt")
            'Session.Remove("formdt")
        End If
    End Sub

    Dim dt As New DataTable

    Private Sub Binddata(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String)
        Try

            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.todt = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            reports.officer_id_approve = lblOfficerID.Text
            reports.havefinishdate = Request("IsExpectedFinishDate")
            dt = reports.RetreiveKPIByEMP
            If dt.Rows.Count > 0 Then
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
                If gDt.Rows.Count > 0 Then
                    rptDocCatType.DataSource = gDt
                    rptDocCatType.DataBind()
                End If
                gDt.Dispose()
                dt.Dispose()
            End If
            reports = Nothing
        Catch ex As Exception

        End Try
    End Sub

    'For Sum By Group Title
    Dim sumIncome As Double = 0
    Dim sumRemOver As Double = 0
    Dim sumRemNotOver As Double = 0
    Dim sumOutOver As Double = 0
    Dim sumOutNotOver As Double = 0
    Dim sumRemTotOver As Double = 0
    Dim sumRemTotNotOver As Double = 0

    Protected Sub rptDocCatType_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptDocCatType.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim wh As String = "doc_cat_type_name = '" & e.Item.DataItem("doc_cat_type_name") & "'"
        wh += " and (income <>0 or remain_over<>0 or remain_notover <> 0 or out_over <> 0 or out_notover <> 0 "
        wh += " or remain_tot_over <> 0 or remain_tot_notover <> 0)"
        dt.DefaultView.RowFilter = wh

        If dt.DefaultView.Count > 0 Then
            sumIncome = 0
            sumRemOver = 0
            sumRemNotOver = 0
            sumOutOver = 0
            sumOutNotOver = 0
            sumRemTotOver = 0
            sumRemTotNotOver = 0


            Dim rptGroupTitle As Repeater = e.Item.FindControl("rptGroupTitle")
            rptGroupTitle.DataSource = dt.DefaultView.ToTable.Copy
            rptGroupTitle.DataBind()

            Dim lblSumIncome As Label = e.Item.FindControl("lblSumIncome")
            lblSumIncome.Text = sumIncome.ToString("#,##0")
        End If
        dt.DefaultView.RowFilter = ""

    End Sub

    Dim iTitle As Integer = 0

    Protected Sub rptGroupTitle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim rItem As HtmlTableRow = e.Item.FindControl("rItem")
        Dim lblGroupTitleName As Label = e.Item.FindControl("lblGroupTitleName")
        Dim lblIncome As Label = e.Item.FindControl("lblIncome")

        If iTitle Mod 2 = 0 Then
            rItem.Attributes.Add("class", "grid_Item")
        Else
            rItem.Attributes.Add("class", "grid_AlternatingItem")
        End If

        lblGroupTitleName.Text = e.Item.DataItem("group_title_name")
        If Convert.ToInt32(e.Item.DataItem("income")) > 0 Then
            lblIncome.Text = "<a href='../rptGrid/rptDocList.aspx?vPage=rptKPI&rpType=INCOME"
            lblIncome.Text += "&gID=" & e.Item.DataItem("group_title_id") & "&orgID=" & reports.OrgID
            lblIncome.Text += IIf(lblOfficerID.Text.Trim <> "", "&OfficerID=" & lblOfficerID.Text.Trim, "")
            lblIncome.Text += "&DateFrom=" & reports.fromdate & "&DateTo=" & reports.todt & "&ExpFinish=" & Request("IsExpectedFinishDate") & "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >"
            lblIncome.Text += e.Item.DataItem("income").ToString
            lblIncome.Text += "</a>"

            sumIncome += Convert.ToInt32(e.Item.DataItem("income"))
        End If


        iTitle += 1
    End Sub
End Class
