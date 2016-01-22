Imports System.Data

Partial Class WebApp_frmSearchBookRetrieve
    Inherits System.Web.UI.Page

    'Const SessSearchResult As String = "SearchResult"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'Session.Remove(SessSearchResult)
            SetGridview()
        End If
    End Sub

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Function SearchData() As DataTable
        Dim dt As New DataTable
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser

        Dim whText As String = " 1=1 "
        whText += " and ir.organization_id_send = '" & uPara.ORG_DATA.ID & "' "

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

        dt = eng.SearchDocumentRetrieve(whText, uPara)
        uPara = Nothing
        eng = Nothing

        Return dt
    End Function

    Public Sub SetGridview()
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            pcTop.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
        dt.Dispose()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Retrieve" Then
            lblTitleName.Text = "ดึงเรื่องกลับ"
            lblMsg.Text = "คุณต้องการดึงเรื่องกลับใช่หรือไม่ ?"
            txtRetrieveReason.Text = "ส่งผิดสำนัก"
            txtIntID.Text = e.CommandArgument

            Dim grv As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim lbl As LinkButton = DirectCast(grv.FindControl("likBookNo"), LinkButton)
            Config.SaveTransLog("คลิกปุ่มดึงกลับ เลขที่หนังสือ " & lbl.Text)
            zPop.Show()
        End If
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        Dim eng As New Engine.Document.DocumentRegisterENG
        If eng.SaveRetrieve(uPara, Convert.ToInt64(txtIntID.Text), txtRetrieveReason.Text.Trim) = True Then
            Config.SaveTransLog("ดึงเรื่องกลับ เลขที่หนังสือ " & eng.GetBookNoByDocumentIntReceiverID(Convert.ToInt64(txtIntID.Text)) & " สาเหตุ " & txtRetrieveReason.Text.Trim, uPara.LOGIN_HISTORY_ID)
            SetGridview()
        Else
            Config.SetAlert(eng.ErrorMessage, Me)
        End If
        eng = Nothing
        uPara = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            If txtRegisDateFrom.DateValue > txtRegisDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่เริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If
        SetGridview()
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
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(0).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
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
