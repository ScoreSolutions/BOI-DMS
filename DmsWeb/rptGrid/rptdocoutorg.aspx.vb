Imports System.Data
Imports System
Imports MycustomDG

Partial Class rptGrid_rptdocoutorg
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            'If Not Session("formdt") Is Nothing Then
            '    If IsDate(Session("formdt")) Then
            '        lbl_fromdt.Text = Convert.ToDateTime(Session("formdt")).ToString("dd MMM yy")
            '    Else
            '        lbl_fromdt.Text = ""
            '    End If
            'Else
            '    lbl_fromdt.Text = ""
            'End If
            'If Not Session("todt") Is Nothing Then
            '    If IsDate(Session("todt")) Then
            '        lbl_todt.Text = Convert.ToDateTime(Session("todt")).ToString("dd MMM yy")
            '    Else
            '        lbl_todt.Text = ""
            '    End If
            'Else
            '    lbl_todt.Text = ""
            'End If
            'If Not Session("BookOutNoForm") Is Nothing Then
            '    If Session("BookOutNoForm") <> "" Then
            '        reports.booknoout_from = Session("BookOutNoForm")
            '    Else
            '        reports.booknoout_from = ""
            '    End If
            'Else
            '    reports.booknoout_from = ""
            'End If
            'If Not Session("BookOutNoTo") Is Nothing Then
            '    If Session("BookOutNoTo") <> "" Then
            '        reports.booknoout_to = Session("BookOutNoTo")
            '    Else
            '        reports.booknoout_to = ""
            '    End If
            'Else
            '    reports.booknoout_to = ""
            'End If
            'If Not Session("orgID") Is Nothing Then
            '    If Session("orgID") <> "" Then
            '        reports.OrgID = Session("orgID")
            '    Else
            '        reports.OrgID = ""
            '    End If
            'Else
            '    reports.Companyname = ""
            'End If

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
            End If

            Dim BookoutFrom As String = ""
            Dim BookoutTo As String = ""
            If Not IsNothing(Request.Cookies("BookOutNoFrom")) Then
                BookoutFrom = Request.Cookies("BookOutNoFrom").Value
            End If
            If Not IsNothing(Request.Cookies("BookOutNoTo")) Then
                BookoutTo = Request.Cookies("BookOutNoTo").Value
            End If

            BindGrid(DateFrom, DateTo, OrgID, BookoutFrom, BookoutTo)

            Dim delBookoutFrom As New HttpCookie("BookOutNoFrom")
            delBookoutFrom.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(delBookoutFrom)

            Dim delBookoutTo As New HttpCookie("BookOutNoTo")
            delBookoutTo.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(delBookoutTo)
        End If
    End Sub
    Protected Sub dgvdetail_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgvdetail.ItemCreated
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_no As Label = DirectCast(e.Item.FindControl("lbl_no"), Label)
            lbl_no.Text = e.Item.ItemIndex + 1
        End If
    End Sub
    Private Sub BindGrid(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal OrgID As String, ByVal BookoutFrom As String, ByVal BookoutTo As String)
        Try
            Dim dt As New DataTable
            reports.fromdate = DateFrom.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
            reports.todt = DateTo.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            reports.booknoout_from = BookoutFrom
            reports.booknoout_to = BookoutTo
            dt = reports.rptdocoutside

            If dt.Rows.Count > 0 Then
                dgvdetail.PageSize = dt.Rows.Count
                dgvdetail.PagerStyle.Visible = False
                dgvdetail.DataSource = dt
                dgvdetail.DataBind()
            Else
                dgvdetail.DataSource = Nothing
                dgvdetail.DataBind()
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub

    Protected Sub dgvdetail_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgvdetail.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'BookNo
            Dim lblBookNo As Label = CType(e.Item.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + e.Item.Cells(8).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' style='color:blue;'>" & lblBookNo.Text & "</a>"
        End If
    End Sub
End Class
