Imports System.Data
Imports System
Imports MycustomDG

Partial Class rptGrid_rptdocsendout
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim DateFrom As New Date(1, 1, 1)
            Dim DateTo As New Date(1, 1, 1)
            Dim OrgID As Long = 0
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
                    lbl_organizename.Text = oPara.ORG_NAME
                Else
                    lbl_organizename.Text = ""
                End If
                oPara = Nothing
                eng = Nothing
            End If

            BindGrid(DateFrom, DateTo, OrgID.ToString)
        End If
    End Sub

    Protected Sub dgvdetail_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgvdetail.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_no As Label = DirectCast(e.Item.FindControl("lbl_no"), Label)
            lbl_no.Text = e.Item.ItemIndex + 1
        End If
    End Sub
    Private Sub BindGrid(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String)
        Try
            Dim dt As New DataTable
            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.todt = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            dt = reports.rptdocout
            If dt.Rows.Count > 0 Then
                'Create Status Column
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                For i As Integer = 0 To dt.Rows.Count - 1
                    If Convert.IsDBNull(dt.Rows(i)("close_date")) = False Then
                        dt.Rows(i)("doc_status_name") += " " + Convert.ToDateTime(dt.Rows(i)("close_date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
                    End If
                    If Convert.IsDBNull(dt.Rows(i)("bookout_no")) = False Then
                        dt.Rows(i)("doc_status_name") += Engine.Document.DocumentRegisterENG.GetBookOutDetailReports(Convert.ToInt64(dt.Rows(i)("document_register_id")), trans)
                    End If
                Next
                trans.CommitTransaction()

                dgvdetail.PageSize = dt.Rows.Count
                dgvdetail.PagerStyle.Visible = False
                dgvdetail.DataSource = dt
                dgvdetail.DataBind()
                dt.Dispose()
            End If
            reports = Nothing
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub

    Protected Sub dgvdetail_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgvdetail.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'BookNo
            Dim lblBookNo As Label = CType(e.Item.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + e.Item.Cells(9).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' style='color:blue;' >" & lblBookNo.Text & "</a>"
        End If
    End Sub
End Class
