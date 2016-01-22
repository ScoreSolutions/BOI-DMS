Imports System.Data

Partial Class WebApp_frmSearchBook
    Inherits System.Web.UI.Page

    Const SessSearchResult As String = "SearchResult"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetStatus()
            Session.Remove(SessSearchResult)
        End If
    End Sub

    Private Sub SetStatus()
        Dim eng As New Engine.Master.DocStatusEng
        Dim dt As DataTable = eng.GetStatusList("1=1")
        cmbStatus.SetItemList(dt, "doc_status_name", "id")
        dt.Dispose()
        eng = Nothing
    End Sub


    Public Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable

        If IsClickSearch = True Then
            Dim whText As String = " 1=1 "
            Dim irText As String = ""
            Dim erText As String = ""
            Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser

            Select Case cmbStatus.SelectedValue
                Case Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain, Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome, Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose
                    whText += " and dr.doc_status_id = '" & cmbStatus.SelectedValue & "' "
                Case -1 'ส่งภายใน
                    irText += " and ir.is_forward='Y'"
                Case -2 'ส่งภายนอก
                    whText += " and dr.bookout_no is not null"
            End Select

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
            dt = eng.SearchAllDocument(whText, irText, erText, uPara.ORG_DATA.ID, cmbStatus.SelectedValue)
            Session(SessSearchResult) = dt
        Else
            dt = Session(SessSearchResult)
        End If

        If dt.Rows.Count > 0 Then
            pcTop.Visible = True
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
            'cmbMoveTo.Visible = True
        Else
            'cmbMoveTo.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
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

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = Session(SessSearchResult)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookno.Text = ""
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
        txtReqNo.Text = ""
        txtTitleName.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyName.Text = ""
        'SetSearchFolder()
        SetStatus()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(12).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = Session(SessSearchResult)
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
End Class
