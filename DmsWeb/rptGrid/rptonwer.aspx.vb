Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptonwer
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Dim Sqldb As New cls_SqlDB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            lbl_fromdt.Text = DateTime.Now.ToString("dd MMM yy HH:mm:ss", New Globalization.CultureInfo("th-TH"))
            Dim OrgID As Long = 0
            If Not Request("OrgID") Is Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim eng As New Engine.Master.OrganizationEng
                lblOrgName.Text = eng.GetOrgPara(OrgID).NAME_ABB
                lblOrgID.Text = OrgID
                eng = Nothing
            End If
            Binddata(OrgID.ToString)
        End If
    End Sub

    Private Sub Binddata(ByVal OrgID As String)
        Try
            Dim dt As New DataTable
            Dim dtgrid As New DataTable
            
            reports.OrgID = OrgID
            If Request("HaveFinishDate") IsNot Nothing Then
                reports.havefinishdate = "Y"
            End If
            dt = reports.RetreiveTitle

            Dim dtowner As New DataTable
            dtowner = reports.RetreiveDoc
            For col As Integer = 0 To dtowner.Rows.Count - 1
                Dim TemplateColumn As New TemplateColumn
                TemplateColumn.HeaderText = dtowner.Rows(col).Item("first_name").ToString
                dgvdetail.Columns.Add(TemplateColumn)
            Next
            If dt.Rows.Count > 0 Then
                dgvdetail.ShowFooter = False
                dgvdetail.PageSize = dt.Rows.Count
                dgvdetail.PagerStyle.Visible = False
            Else
                lbl_result.Text = ""
                dgvdetail.ShowFooter = True
            End If

            dgvdetail.DataSource = dt
            dgvdetail.DataBind()

            Dim tmpDt As New DataTable
            tmpDt = reports.RetreiveOwnerbytitle
            If tmpDt.Rows.Count > 0 Then
                Dim dgv As DataGridItem
                For Each dgv In dgvdetail.Items
                    For col As Integer = 0 To dtowner.Rows.Count - 1
                        Dim lbl As New Label
                        Dim lbl_group_title_name As Label = dgv.FindControl("lbl_group_title_name")
                        Dim lblGroupTitleID As Label = DirectCast(dgv.FindControl("lblGroupTitleID"), Label)
                        Dim OfficerID As String = dtowner.Rows(col).Item("officer_id_approve").ToString
                        Dim owner As String = "owner_row" & dgv.ItemIndex + 1 & "_col" & col
                        lbl.ID = owner
                        lbl.ForeColor = Drawing.Color.Black
                        'lbl.Width = 40

                        tmpDt.DefaultView.RowFilter = "group_title_id='" & lblGroupTitleID.Text & "' and officer_id_approve = '" & OfficerID & "'"
                        If tmpDt.DefaultView.Count > 0 Then
                            Dim dv As DataRowView = tmpDt.DefaultView.Item(0)
                            lbl.Text = "<center><a href='../rptGrid/rptDocList.aspx?vPage=rptOwner"
                            lbl.Text += "&gID=" & lblGroupTitleID.Text
                            lbl.Text += "&OfficerID=" & OfficerID
                            lbl.Text += "&OrgID=" & lblOrgID.Text
                            If Request("HaveFinishDate") IsNot Nothing Then
                                lbl.Text += "&HaveFinishDate=Y"
                            End If
                            lbl.Text += "&rnd=" & DateTime.Now.Millisecond & "' target='_blank' >" & dv("countdoc").ToString & "</a></center>"
                            dv = Nothing
                        Else
                            lbl.Text = "&nbsp;"
                        End If
                        dgvdetail.Items(dgv.ItemIndex).Cells(col + 1).Controls.Add(lbl)
                        tmpDt.DefaultView.RowFilter = ""
                    Next
                Next
            End If
            tmpDt.Dispose()
            dt.Dispose()
            dtowner.Dispose()
            reports = Nothing
            dtgrid.Dispose()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
End Class
