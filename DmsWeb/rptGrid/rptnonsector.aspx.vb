Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptnonsector
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim DateFrom As New Date(1, 1, 1)
            Dim OrgID As Long = 0
            If Not Request("DateFrom") Is Nothing Then
                DateFrom = Config.GetStringToDate(Request("DateFrom"))
                lbl_fromdt.Text = DateFrom.ToString("dd MMM yy")
            Else
                lbl_fromdt.Text = ""
            End If

            If Not Request("OrgID") Is Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim eng As New Engine.Master.OrganizationEng
                Dim para As New Para.TABLE.OrganizationPara
                para = eng.GetOrgPara(OrgID)
                lbl_organizename.Text = para.NAME_ABB
            Else
                lbl_organizename.Text = ""
            End If
            Binddata(DateFrom, OrgID.ToString)
            'Session.Remove("OrgID")
            'Session.Remove("formdt")
            Session.Remove("NonSectorList")
        End If
    End Sub
    Private Sub Binddata(ByVal DateFrom As Date, ByVal OrgID As String)
        Try
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim dttitle As New DataTable
            Dim drtitle As DataRow

            dttitle.Columns.Add("group_title_name")
            reports.fromdate = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            reports.OrgID = OrgID
            dt = reports.rptnotsector
            If dt.Rows.Count > 0 Then
                reports.BuildDueDate(dt)
                'dt.DefaultView.RowFilter = "overdue>0"    'งานค้าง Non Sector ให้แสดงทุกเรื่องที่เป็นงานค้าง
                dt = dt.DefaultView.ToTable
                If dt.Rows.Count > 0 Then
                    Session("NonSectorList") = dt
                    Dim dr() As DataRow = (From row As DataRow In dt.Rows.Cast(Of DataRow)() _
                                      Group row By randomField = row.Field(Of String)("group_title_name") Into Group _
                                      Select Group(0)).ToArray
                    dt2 = dr.CopyToDataTable()
                    For row As Integer = 0 To dt2.Rows.Count - 1
                        drtitle = dttitle.NewRow
                        drtitle(0) = dt2.Rows(row).Item("group_title_name").ToString
                        dttitle.Rows.Add(drtitle)
                    Next
                End If
            Else
                lbl_result.Text = "ไม่มีงานค้าง"
            End If


            If dttitle.Rows.Count > 0 Then
                DataList1.DataSource = dttitle
                DataList1.DataBind()
            End If
            dt.Dispose()
            dttitle.Dispose()
            dt2.Dispose()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
    Protected Sub dgvdetail_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_no As Label = DirectCast(e.Item.FindControl("lbl_no"), Label)
            lbl_no.Text = e.Item.ItemIndex + 1

            Dim vOverDue As Integer = Convert.ToInt64(e.Item.DataItem("overdue").ToString())
            Dim lblOverDue As Label = DirectCast(e.Item.FindControl("lbl_over_date"), Label)
            lblOverDue.Text = IIf(vOverDue > 0, vOverDue.ToString, "")
        End If
    End Sub

    Protected Sub dgvdetail_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'BookNo
            Dim lblBookNo As Label = CType(e.Item.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + e.Item.Cells(11).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' style='color:blue;text-decoration:underline;'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Try
            Dim dgvdetail As MyDg = DirectCast(e.Item.FindControl("dgvdetail"), MyDg)
            Dim lbl_group_title_name As Label = DirectCast(e.Item.FindControl("lbl_group_title_name"), Label)
            BindGrid(dgvdetail, lbl_group_title_name)
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
    Private Sub BindGrid(ByVal griddetail As MyDg, ByVal lblgroup_title_name As Label)
        Try
            Dim dt As New DataTable
            If Session("NonSectorList") IsNot Nothing Then
                dt = Session("NonSectorList")
                dt.DefaultView.RowFilter = "group_title_name = '" & lblgroup_title_name.Text & "'"

                dt = dt.DefaultView.ToTable
                If dt.Rows.Count > 0 Then
                    griddetail.PageSize = dt.Rows.Count
                    griddetail.PagerStyle.Visible = False
                    griddetail.DataSource = dt
                    griddetail.DataBind()
                End If
                dt.DefaultView.RowFilter = ""
            End If
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
End Class
