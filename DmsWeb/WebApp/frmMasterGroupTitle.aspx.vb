Imports System.Data
Imports Engine.Master
Partial Class WebApp_frmMasterGroupTitle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetGroupTitleGV()
            SetAllCombox()
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub

    Const SessGroupTitle As String = "SessGroupTitle"
    Private Sub SetGroupTitleGV()
        Dim eng As New Engine.Master.GroupTitleEng
        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " select g.id, g.group_title_code, g.group_title_name , dc.doc_cat_type_name group_title_type_name,g.std_proc_period,g.max_proc_period,g.active"
        sql += " from GROUP_TITLE g"
        sql += " inner join DOC_CAT_TYPE dc on dc.id=g.group_title_type_id "
        sql += " where g.group_title_name<>''"
        If txtSearch.Text.Trim <> "" Then
            sql += " and g.group_title_name like '%" & txtSearch.Text.Trim & "%' or dc.doc_cat_type_name like '%" & txtSearch.Text.Trim & "%'"
        End If
        sql += " order by convert(float, g.group_title_code) "
        dt = eng.GetGroupTitleList(sql)
        If dt.Rows.Count > 0 Then
            pcTop.Visible = True
            pcTop.SetMainGridView(gvGroupTitle)
            gvGroupTitle.DataSource = dt
            gvGroupTitle.DataBind()
            pcTop.Update(dt.Rows.Count)
            Session(SessGroupTitle) = dt
        Else
            pcTop.Visible = False
            gvGroupTitle.DataSource = Nothing
            gvGroupTitle.DataBind()
            Session.Remove(SessGroupTitle)
        End If
    End Sub

    Private Sub SetAllCombox()
        Dim dt As New DataTable
        Dim eng As New GroupTitleEng
        dt = eng.GetGroupTitleDDlList()
        If dt.Rows.Count > 0 Then
            cmbGroupTitleTypeID.SetItemList(dt, "doc_cat_type_name", "id")
            dt.Dispose()
            dt = Nothing
        End If

        cmbSubjectID.SetItemList("เลือก", 1)
        cmbSubjectID.SetItemList("เรื่องแก้ไขโครงการ", 2)
        cmbSubjectID.SetItemList("เรื่องคำขอรับการส่งเสริม", 3)
    End Sub

    Protected Sub btnAddOrg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddOrg.Click
        ShopPopOrg()
    End Sub
    Private Sub ShopPopOrg()
        ClearGrpOrgForm()
        cmbOrgTypeID.ClearCombo()
        cmbOrgTypeID.SetItemList("SECTOR", 0)
        cmbOrgTypeID.SetItemList("NON SECTOR", 1)
        cmbOrgTypeID.SetItemList("IC", 2)
        SetOrgID()

        zPopOrg.Show()
    End Sub

    Protected Sub btnAddCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCompany.Click
        ClearCompanyForm()
        zPopCompany.Show()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidSave() = True Then
            Dim gPara As New Para.TABLE.GroupTitlePara
            gPara.ID = txtID.Text
            gPara.GROUP_TITLE_CODE = txtCode.Text.Trim
            gPara.GROUP_TITLE_NAME = txtName.Text.Trim
            gPara.GROUP_TITLE_TYPE_ID = cmbGroupTitleTypeID.SelectedValue
            If txtStdProcPerd.Text.Trim <> "" Then
                gPara.STD_PROC_PERIOD = Convert.ToDouble(txtStdProcPerd.Text.Trim)
            End If
            If txtMaxProcPerd.Text.Trim <> "" Then
                gPara.MAX_PROC_PERIOD = Convert.ToDouble(txtMaxProcPerd.Text.Trim)
            End If
            gPara.SUBJECT_ID = cmbSubjectID.SelectedValue
            gPara.IS_GEN_REQ = IIf(chkIsGenReqNo.Checked, "Y"c, "N"c)
            gPara.ACTIVE = IIf(chkActive.Checked, "Y", "N")
            gPara.NO_DEFAULT_TITLE = IIf(chkNoDefaultTitle.Checked, "Y", "N")

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim eng As New Engine.Master.GroupTitleEng
            Dim ret As Boolean = eng.SaveGroupTitle(Config.GetLogOnUser.UserName, gPara, Session(SessGrpOrg), Session(SessCompany), trans)
            If ret = True Then
                trans.CommitTransaction()
                txtID.Text = eng.GroupTitleID
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(eng.ErrorMessage, Me)
            End If
            eng = Nothing
            gPara = Nothing
        End If
    End Sub

    Private Function ValidSave() As Boolean
        Dim ret As Boolean = True
        If txtCode.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรหัสกลุ่มเรื่อง", Me, txtCode.ClientID)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุชื่อกลุ่มเรื่อง", Me, txtName.ClientID)
        ElseIf cmbGroupTitleTypeID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกประเภทงาน", Me)
        Else
            Dim eng As New Engine.Master.GroupTitleEng
            Dim msg As String = eng.ChkDupGroupTitle(txtCode.Text, txtName.Text, txtID.Text)
            If msg <> "" Then
                ret = False
                Config.SetAlert(msg, Me)
            End If
            eng = Nothing
        End If

        Return ret
    End Function

#Region "กองงานรับผิดชอบ"
    Const SessGrpOrg As String = "SessGrpOrg"

    Private Sub SetOrgID()
        Dim eng As New OrganizationEng
        Dim dt As New DataTable
        dt = eng.GetOrgBySector(cmbOrgTypeID.SelectedValue)
        If dt.Rows.Count > 0 Then
            cmbOrgID.SetItemList(dt, "org_name", "id")
            dt.Dispose()
            dt = Nothing
        Else
            cmbOrgID.ClearCombo()
        End If
        zPopOrg.Show()
    End Sub

    Protected Sub cmbOrgTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrgTypeID.SelectedIndexChanged
        SetOrgID()
    End Sub

    Private Function ValidGrpOrg() As Boolean
        Dim ret As Boolean = True
        If cmbOrgID.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกหน่วยงาน", Me)
            ret = False
        End If
        zPopOrg.Show()
        Return ret
    End Function

    Private Sub ClearGrpOrgForm()
        cmbOrgTypeID.SelectedValue = "0"
        SetOrgID()
        txtStdPerd.Text = ""
        txtMaxPerd.Text = ""
        txtGrpOrgRowIndex.Text = ""

        If gvOrgList.Rows.Count > 0 Then
            trOrgHeaderRow.Visible = False
        Else
            trOrgHeaderRow.Visible = True
        End If
    End Sub

    Protected Sub btnSaveGrpOrg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveGrpOrg.Click
        If ValidGrpOrg() = True Then
            Dim dt As New DataTable
            If Session(SessGrpOrg) Is Nothing Then
                dt.Columns.Add("id")
                dt.Columns.Add("org_sector_id")
                dt.Columns.Add("org_group_name")
                dt.Columns.Add("org_id")
                dt.Columns.Add("org_name")
                dt.Columns.Add("org_abb_name")
                dt.Columns.Add("std_proc")
                dt.Columns.Add("max_proc")
            Else
                dt = Session(SessGrpOrg)
            End If

            Dim oPara As New Para.TABLE.OrganizationPara
            Dim oEng As New Engine.Master.OrganizationEng
            oPara = oEng.GetOrgPara(cmbOrgID.SelectedValue)

            If txtGrpOrgRowIndex.Text.Trim <> "" Then
                Dim ind As Long = txtGrpOrgRowIndex.Text
                dt.Rows(ind)("id") = txtGrpOrgID.Text
                dt.Rows(ind)("org_sector_id") = cmbOrgTypeID.SelectedValue
                dt.Rows(ind)("org_group_name") = cmbOrgTypeID.SelectedText
                dt.Rows(ind)("org_id") = cmbOrgID.SelectedValue
                dt.Rows(ind)("org_name") = cmbOrgID.SelectedText
                dt.Rows(ind)("org_abb_name") = oPara.NAME_ABB
                dt.Rows(ind)("std_proc") = txtStdPerd.Text
                dt.Rows(ind)("max_proc") = txtMaxPerd.Text
            Else
                Dim dr As DataRow = dt.NewRow
                dr("id") = 0
                dr("org_sector_id") = cmbOrgTypeID.SelectedValue
                dr("org_group_name") = cmbOrgTypeID.SelectedText
                dr("org_id") = cmbOrgID.SelectedValue
                dr("org_name") = cmbOrgID.SelectedText
                dr("org_abb_name") = oPara.NAME_ABB
                dr("std_proc") = txtStdPerd.Text
                dr("max_proc") = txtMaxPerd.Text
                dt.Rows.Add(dr)
            End If
            oPara = Nothing
            oEng = Nothing

            SetGvOrg(dt)
            ClearGrpOrgForm()
        End If
    End Sub

    Private Sub SetGvOrg(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            trOrgHeaderRow.Visible = False
            gvOrgList.DataSource = dt
            gvOrgList.DataBind()
            Session(SessGrpOrg) = dt
        Else
            trOrgHeaderRow.Visible = True
            gvOrgList.DataSource = Nothing
            gvOrgList.DataBind()
            Session.Remove(SessGrpOrg)
        End If
    End Sub

    Protected Sub btnCancelGrpOrg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelGrpOrg.Click
        ClearGrpOrgForm()
    End Sub

    Protected Sub gvOrgList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvOrgList.RowCommand
        Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        Dim dt As New DataTable
        dt = Session(SessGrpOrg)

        If e.CommandName = "Edit" Then
            ShopPopOrg()
            txtGrpOrgID.Text = dt.Rows(index)("id")
            txtGrpOrgRowIndex.Text = index
            cmbOrgTypeID.SelectedValue = dt.Rows(index)("org_sector_id")
            SetOrgID()
            cmbOrgID.SelectedValue = dt.Rows(index)("org_id")
            txtStdPerd.Text = dt.Rows(index)("std_proc")
            txtMaxPerd.Text = dt.Rows(index)("max_proc")
        ElseIf e.CommandName = "Delete" Then
            If dt.Rows.Count > 0 Then
                dt.Rows.RemoveAt(index)
            End If
            SetGvOrg(dt)
        End If
    End Sub

    Protected Sub gvOrgList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvOrgList.RowDeleting

    End Sub

    Protected Sub gvOrgList_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvOrgList.RowEditing

    End Sub
#End Region

#Region "องค์กรรับ"
    Const SessCompany As String = "SessCompany"

    Protected Sub gvCompany_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCompany.RowCommand
        Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        Dim dt As New DataTable
        dt = Session(SessCompany)
        If e.CommandName = "Edit" Then
            ClearCompanyForm()
            txtGrpComRowIndex.Text = index
            txtGrpCompanyID.Text = dt.Rows(index)("id")
            hdnCustValue.Text = dt.Rows(index)("company_id")
            txtCustName.Text = IIf(Convert.IsDBNull(dt.Rows(index)("company_name")) = False, dt.Rows(index)("company_name").ToString, "")
            txtRemarks.Text = IIf(Convert.IsDBNull(dt.Rows(index)("remarks")) = False, dt.Rows(index)("remarks").ToString, "")
            zPopCompany.Show()
        ElseIf e.CommandName = "Delete" Then
            If dt.Rows.Count > 0 Then
                dt.Rows.RemoveAt(index)
            End If
            SetGvCompany(dt)
        End If
    End Sub

    Protected Sub gvCompany_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCompany.RowDeleting

    End Sub

    Protected Sub gvCompany_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvCompany.RowEditing

    End Sub

    Private Function ValidCompany() As Boolean
        Dim ret As Boolean = True
        If hdnCustValue.Text = "0" Or hdnCustValue.Text = "" Then
            Config.SetAlert("กรุณาเลือกองค์กร", Me)
            ret = False
        End If
        zPopCompany.Show()

        Return ret
    End Function

    Protected Sub btnSaveGrpCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveGrpCompany.Click
        If ValidCompany() = True Then
            Dim dt As New DataTable
            If Session(SessCompany) Is Nothing Then
                dt.Columns.Add("id")
                dt.Columns.Add("company_name")
                dt.Columns.Add("company_id")
                dt.Columns.Add("company_sign")
                dt.Columns.Add("remarks")
            Else
                dt = Session(SessCompany)
            End If

            If txtGrpComRowIndex.Text.Trim <> "" Then
                Dim ind As Long = txtGrpComRowIndex.Text
                dt.Rows(ind)("id") = txtGrpComRowIndex.Text
                dt.Rows(ind)("company_name") = txtCustName.Text
                dt.Rows(ind)("company_id") = hdnCustValue.Text
                dt.Rows(ind)("remarks") = txtRemarks.Text
            Else
                Dim dr As DataRow = dt.NewRow
                dr("id") = 0
                dr("company_name") = txtCustName.Text
                dr("company_id") = hdnCustValue.Text
                dr("remarks") = txtRemarks.Text
                dt.Rows.Add(dr)
            End If

            SetGvCompany(dt)
            ClearCompanyForm()
        End If
    End Sub

    Private Sub SetGvCompany(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            tr1.Visible = False
            gvCompany.DataSource = dt
            gvCompany.DataBind()
            Session(SessCompany) = dt
        Else
            tr1.Visible = True
            gvCompany.DataSource = Nothing
            gvCompany.DataBind()
            Session.Remove(SessCompany)
        End If
    End Sub

    Private Sub ClearCompanyForm()
        txtGrpComRowIndex.Text = ""
        txtGrpCompanyID.Text = "0"
        txtCustName.Text = ""
        hdnCustValue.Text = ""
        txtRemarks.Text = ""

        If gvCompany.Rows.Count > 0 Then
            tr1.Visible = False
        Else
            tr1.Visible = True
        End If
    End Sub
    Protected Sub btnCancelGrpCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelGrpCompany.Click
        ClearCompanyForm()
    End Sub
#End Region

    
    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        gvGroupTitle.PageIndex = pcTop.SelectPageIndex
        SetGroupTitleGV()
    End Sub

    Private Sub SetGroupTitleForm(ByVal vID As Long)
        Dim eng As New Engine.Master.GroupTitleEng
        Dim gPara As New Para.TABLE.GroupTitlePara
        gPara = eng.GetGroupTitlePara(vID)
        txtID.Text = gPara.ID
        txtCode.Text = gPara.GROUP_TITLE_CODE
        txtName.Text = gPara.GROUP_TITLE_NAME
        cmbGroupTitleTypeID.SelectedValue = gPara.GROUP_TITLE_TYPE_ID
        cmbSubjectID.SelectedValue = gPara.SUBJECT_ID
        txtStdProcPerd.Text = gPara.STD_PROC_PERIOD
        txtMaxProcPerd.Text = gPara.MAX_PROC_PERIOD
        If gPara.IS_GEN_REQ = "Y" Then chkIsGenReqNo.Checked = True Else chkIsGenReqNo.Checked = False
        If gPara.ACTIVE = "Y" Then chkActive.Checked = True Else chkActive.Checked = False
        If gPara.NO_DEFAULT_TITLE = "Y" Then chkNoDefaultTitle.Checked = True Else chkNoDefaultTitle.Checked = False

        Dim oDt As New DataTable
        oDt = eng.GetGroupTitleOrgList(vID)
        SetGvOrg(oDt)
        oDt.Dispose()
        oDt = Nothing

        Dim cDt As New DataTable
        cDt = eng.GetGroupTitleComList(vID)
        SetGvCompany(cDt)
        cDt.Dispose()
        cDt = Nothing

        eng = Nothing
        gPara = Nothing
    End Sub

    Protected Sub gvGroupTitle_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvGroupTitle.RowCommand
        Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        Dim dt As New DataTable
        dt = Session(SessGroupTitle)
        If e.CommandName = "Edit" Then
            'SetGroupTitleForm(dt.Rows(index)("id"))
            SetGroupTitleForm(Convert.ToInt64(e.CommandArgument))
        ElseIf e.CommandName = "Delete" Then

        End If
    End Sub

    Protected Sub gvGroupTitle_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvGroupTitle.RowDeleting

    End Sub

    Protected Sub gvGroupTitle_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvGroupTitle.RowEditing

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGroupTitleGV()
    End Sub
End Class
