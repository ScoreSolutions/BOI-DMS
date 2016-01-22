Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterCompany
    Inherits System.Web.UI.Page

    Private Sub comtypelist()
        Dim dt As DataTable
        Dim eng As New Engine.Master.CompanyTypeENG
        dt = eng.GetAllCompanyTypeTable() 'GetDataToList("select company_type_name,id  from COMPANY_TYPE order by company_type_name")
        If dt.Rows.Count > 0 Then
            cmbcomtype.SetItemList(dt, "company_type_name", "id")
            dt = Nothing
        End If
        eng = Nothing
    End Sub
    Private Sub SetCmbOrgList()
        Dim dt As New DataTable
        Dim eng As New Engine.Master.OrganizationEng
        dt = eng.GetAllOrganizationTable()
        If dt.Rows.Count > 0 Then
            cmbOrgID.SetItemList(dt, "org_name", "id")
            dt = Nothing
        End If
        eng = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            comtypelist()
            SetCmbOrgList()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            Dim id As String = "0"
            If txtID.Text.Trim = "0" Then
                id = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from COMPANY", "maxid")

                sqltmp = "insert into COMPANY ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",company_type_id"
                sqltmp = sqltmp + ",thaiName"
                sqltmp = sqltmp + ",engName"
                sqltmp = sqltmp + ",comID"
                sqltmp = sqltmp + ",description"
                sqltmp = sqltmp + ",addressID"
                sqltmp = sqltmp + ",active"
                sqltmp = sqltmp + ",ref_org_id"
                sqltmp = sqltmp + ",th_egif_org_code"
                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + "'" + id + "' "
                sqltmp = sqltmp + ",'" + cmbcomtype.SelectedValue + "'"
                sqltmp = sqltmp + ",'" + txtNameT.Text + "'"
                sqltmp = sqltmp + ",'" + txtNameE.Text + "'"
                sqltmp = sqltmp + ",'" + txtCode.Text + "'"
                sqltmp = sqltmp + ",'" + txtDesc.Text + "'"
                sqltmp = sqltmp + ", '" & txtAddress.Text & "'"
                sqltmp = sqltmp + ",'" + IIf(chkActive.Checked = True, "Y", "N") + "' "
                sqltmp = sqltmp + ",'" & cmbOrgID.SelectedValue & "'"
                sqltmp = sqltmp + ",'" + txtTHeGIFCode.Text + "'"
                sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",getdate())"
            Else
                id = txtID.Text
                sqltmp = "update COMPANY set "
                sqltmp = sqltmp + " company_type_id = '" + cmbcomtype.SelectedValue + "'"
                sqltmp = sqltmp + ",thaiName = '" + txtNameT.Text + "'"
                sqltmp = sqltmp + ",engName = '" + txtNameE.Text + "'"
                sqltmp = sqltmp + ",comID = '" + txtCode.Text + "'"
                sqltmp = sqltmp + ",description = '" + txtDesc.Text + "'"
                sqltmp = sqltmp + ",addressid = '" & txtAddress.Text & "'"
                sqltmp = sqltmp + ",active = '" + IIf(chkActive.Checked = True, "Y", "N") + "' "
                sqltmp = sqltmp + ",ref_org_id = '" & cmbOrgID.SelectedValue & "'"
                sqltmp = sqltmp + ",th_egif_org_code='" & txtTHeGIFCode.Text.Trim & "'"
                sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",update_on= getdate()"
                sqltmp = sqltmp + " where id = '" + id + "' "
            End If

            Dim msg As String = sql_data(sqltmp)
            If msg = "" Then
                txtID.Text = id
                SetGridview(True)
                ClearData()
                sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
            Else
                sys_msg.Text = msg
            End If

            popup2.Show()
        End If
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            'sys_msg.Text = "กรุณากรอกรหัส"
            Config.SetAlert("กรุณากรอกรหัส", Me, txtCode.ClientID)
            'ElseIf cmbcomtype.SelectedValue = "0" Then
            '    ret = False
            '    'sys_msg.Text = "กรุณาเลือกประเภทกิจการ"
            '    Config.SetAlert("กรุณาเลือกประเภทกิจการ", Me)
        ElseIf txtNameT.Text.Trim = "" Then
            ret = False
            'sys_msg.Text = "กรุณากรอกชื่อ"
            Config.SetAlert("กรุณากรอกชื่อ", Me, txtNameT.ClientID)
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from COMPANY where id = " + ID.ToString + " order by ID"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString
            Try
                cmbcomtype.SelectedValue = Ds.Tables("DATA").Rows(0).Item("company_type_id").ToString
            Catch ex As Exception
                cmbcomtype.SelectedValue = "0"
            End Try

            txtNameT.Text = Ds.Tables("DATA").Rows(0).Item("thaiName").ToString
            txtNameE.Text = Ds.Tables("DATA").Rows(0).Item("engName").ToString
            txtCode.Text = Ds.Tables("DATA").Rows(0).Item("comID").ToString
            txtAddress.Text = Ds.Tables("DATA").Rows(0).Item("addressid").ToString
            txtDesc.Text = Ds.Tables("DATA").Rows(0).Item("description").ToString
            If Convert.IsDBNull(Ds.Tables("DATA").Rows(0).Item("ref_org_id")) = False Then cmbOrgID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("ref_org_id").ToString
            If Convert.IsDBNull(Ds.Tables("DATA").Rows(0).Item("th_egif_org_code")) = False Then txtTHeGIFCode.Text = Ds.Tables("DATA").Rows(0).Item("th_egif_org_code").ToString
            If Ds.Tables("DATA").Rows(0).Item("active").ToString = "Y" Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If
        End If
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable
        If IsClickSearch = True Then
            sqltmp = "select c.id, c.comID, c.thaiName, c.engName, c.company_type_id, ct.company_type_name, c.active "
            sqltmp += " from COMPANY c "
            sqltmp += " left join COMPANY_TYPE ct on ct.id=c.company_type_id "
            sqltmp += " where "
            sqltmp &= " c.company_type_id like '%" + txtSearch.Text.Trim() + "%' or c.thaiName like '%" + txtSearch.Text + "%'"
            sqltmp &= "or c.engName like '%" + txtSearch.Text.Trim() + "%' or c.addressID like '%" + txtSearch.Text + "%'"
            sqltmp &= "or c.comID like '%" + txtSearch.Text.Trim() + "%' or c.description like '%" + txtSearch.Text + "%'"
            sqltmp &= "or c.ref_old_id like '%" + txtSearch.Text + "%'"
            dt = GetDataToList(sqltmp)
            Session("SearchResult") = dt
        Else
            dt = Session("SearchResult")
        End If

        GridView1.PageSize = 20
        pcTop.SetMainGridView(GridView1)
        GridView1.DataSource = dt
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub
    Private Sub ClearData()
        txtID.Text = "0"
        txtCode.Text = ""
        txtNameT.Text = ""
        txtNameE.Text = ""
        txtDesc.Text = ""
        txtAddress.Text = ""
        cmbcomtype.SelectedValue = "0"
        cmbOrgID.SelectedValue = "0"
        chkActive.Checked = True
        txtTHeGIFCode.Text = ""
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression = "DEFAULT" Then
            txtSortDir.Text = ""
            txtSortField.Text = ""
        Else
            If txtSortField.Text = e.SortExpression Then
                txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
            Else
                txtSortField.Text = e.SortExpression
            End If
        End If

        SetGridview(False)
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM COMPANY WHERE id=" + lbl.Text

        popup1.Show()
    End Sub

    Protected Sub btnYes1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes1.Click
        sql_data(sqltmp)
        SetGridview(True)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim row As GridViewRow = GridView1.Rows(e.NewEditIndex)
        Dim lbl As Label = row.FindControl("lblid")

        GetData(lbl.Text)
    End Sub

End Class
