Imports System.Data

Partial Class WebApp_frmSearchBookCancelCloseJob
    Inherits System.Web.UI.Page

    'Const SessSearchResult As String = "SearchResult"

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Me.IsPostBack = False Then
    '        'Session.Remove(SessSearchResult)
    '        'SetGridview(True)
    '    End If
    'End Sub

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Function SearchData() As DataTable
        Dim dt As New DataTable
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = " 1=1 "
        If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
            whText += " and isnull(dr.officer_id_possess,'" & uPara.OFFICER_DATA.ID & "') = '" & uPara.OFFICER_DATA.ID & "'"
        End If
        whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        whText += " and ir.organization_id_receive  = '" & uPara.OFFICER_DATA.ORGANIZATION_ID & "'"

        If txtBookno.Text.Trim <> "" Then
            whText += " and dr.book_no like '%" & txtBookno.Text.Trim & "%'"
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegisDateFrom.GetDateCondition & "'"
        End If
        If txtRegisDateTo.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
        End If
        If txtReqNo.Text.Trim <> "" Then
            whText += " and dr.request_no like '%" & txtReqNo.Text.Trim & "%'"
        End If
        If txtTitleName.Text.Trim <> "" Then
            whText += " and dr.title_name like '%" & txtTitleName.Text.Trim & "%' "
        End If
        If txtCompanyDocNo.Text.Trim <> "" Then
            whText += " and dr.company_doc_no like '%" & txtCompanyDocNo.Text.Trim & "%'"
        End If
        If txtCompanyName.Text.Trim <> "" Then
            whText += " and dr.company_name like '%" & txtCompanyName.Text.Trim & "%' "
        End If
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentCancelCloseJob(whText)
        eng = Nothing
        uPara = Nothing
        Return dt
    End Function
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
        End If
        dt.Dispose()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "CancelCloseJob" Then
            lblTitleName.Text = "ยกเลิกจบงาน"
            lblMsg.Text = "คุณต้องการยกเลิกจบงาน ใช่หรือไม่ ?"
            txtCancelReason.Text = "ขอเอกสารเพิ่มเติม"
            txtDocRegisID.Text = e.CommandArgument

            Dim grv As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim lbl As LinkButton = DirectCast(grv.FindControl("likBookNo"), LinkButton)
            Config.SaveTransLog("คลิกปุ่มยกเลิกจบงาน เลขที่หนังสือ " & lbl.Text)

            zPop.Show()
        End If
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        If uPara.UserName.Trim <> "" Then
            Dim eng As New Engine.Document.DocumentRegisterENG
            If eng.SaveCancelClose(uPara, Convert.ToInt64(txtDocRegisID.Text), txtCancelReason.Text.Trim) = True Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim vBookNo As String = eng.GetDocumentPara(Convert.ToInt64(txtDocRegisID.Text), trans).BOOK_NO
                trans.CommitTransaction()
                Config.SaveTransLog("ยกเลิกจบงาน เลขที่หนังสือ " & vBookNo & " สาเหตุ " & txtCancelReason.Text.Trim, uPara.LOGIN_HISTORY_ID)

                txtCancelReason.Text = ""
                SetGridview(True)
            Else
                Config.SetAlert(eng.ErrorMessage, Me)
                Master.Logout()
            End If
            eng = Nothing
            uPara = Nothing
        Else
            Config.SetAlert("Session Expired", Me.Page)
            Master.Logout()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            If txtRegisDateFrom.DateValue > txtRegisDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่เริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If
        SetGridview(True)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookno.Text = ""
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
        txtReqNo.Text = ""
        txtTitleName.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyName.Text = ""
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(10).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Config.SaveTransLog("คลิกปุ่มไม่ใช่")
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Config.SaveTransLog("คลิกปุ่มปิด")
    End Sub
End Class
