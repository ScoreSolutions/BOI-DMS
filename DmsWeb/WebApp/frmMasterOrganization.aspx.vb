Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterOrganization
    Inherits System.Web.UI.Page

    Private Sub organization_type()
        Dim dt As DataTable
        dt = GetDataToList("select * from ORGANIZATION_TYPE order by thai_name")
        organization_type_id.SetItemList(dt, "thai_name", "id")
        dt = Nothing
    End Sub
    Private Sub SetCmbOfficerDirector()
        Dim oDt As New DataTable
        oDt = GetDataToList("select id, first_name + ' ' + last_name staff_name from officer where ltrim(first_name)<>'' and ltrim(last_name)<>'' order by first_name")
        cmbDirectorID.SetItemList(oDt, "staff_name", "id")
        oDt = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            organization_type()
            SetCmbOfficerDirector()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            Dim id As String = "0"
            If txtID.Text.Trim = "0" Then
                id = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from ORGANIZATION", "maxid")
                sqltmp = "insert into ORGANIZATION ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",org_code"
                sqltmp = sqltmp + ",org_name"
                sqltmp = sqltmp + ",org_thai_name"
                sqltmp = sqltmp + ",name_abb"
                sqltmp = sqltmp + ",org_eng_name"
                sqltmp = sqltmp + ",address_thai"
                sqltmp = sqltmp + ",address_eng"
                sqltmp = sqltmp + ",organization_type_id"
                sqltmp = sqltmp + ",type"
                sqltmp = sqltmp + ",efdate"
                sqltmp = sqltmp + ",epdate"
                sqltmp = sqltmp + ",tel"
                sqltmp = sqltmp + ",Fax"
                sqltmp = sqltmp + ",email"
                sqltmp = sqltmp + ",description"
                sqltmp = sqltmp + ",active"
                sqltmp = sqltmp + ",update_by"
                sqltmp = sqltmp + ",update_on"
                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on, director"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + "'" & id & "'"
                sqltmp = sqltmp + ",'" + org_code.Text + "'"
                sqltmp = sqltmp + ",'" + org_name.Text + "'"
                sqltmp = sqltmp + ",'" + org_thai_name.Text + "'"
                sqltmp = sqltmp + ",'" + name_abb.Text + "'"
                sqltmp = sqltmp + ",'" + org_eng_name.Text + "'"
                sqltmp = sqltmp + ",'" + address_thai.Text + "'"
                sqltmp = sqltmp + ",'" + address_eng.Text + "'"
                sqltmp = sqltmp + ",'" + organization_type_id.SelectedValue + "'"
                sqltmp = sqltmp + ",'" + type.SelectedValue + "'"
                sqltmp = sqltmp + "," + IIf(efdate.DateValue = Nothing, "null", "'" + efdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
                sqltmp = sqltmp + "," + IIf(epdate.DateValue = Nothing, "null", "'" + epdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
                sqltmp = sqltmp + ",'" + tel.Text + "'"
                sqltmp = sqltmp + ",'" + fax.Text + "'"
                sqltmp = sqltmp + ",'" + email.Text + "'"
                sqltmp = sqltmp + ",'" + description.Text + "'"
                sqltmp = sqltmp + ",'" + IIf(chkActive.Checked = True, "Y", "N") + "'"
                sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",getdate()"
                sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",getdate(),'" & cmbDirectorID.SelectedValue & "')"
            Else
                id = txtID.Text
                sqltmp = "update organization set "
                sqltmp = sqltmp + " org_code = '" + org_code.Text + "'"
                sqltmp = sqltmp + ",org_name = '" + org_name.Text + "'"
                sqltmp = sqltmp + ",org_thai_name = '" + org_thai_name.Text + "'"
                sqltmp = sqltmp + ",name_abb = '" + name_abb.Text + "'"
                sqltmp = sqltmp + ",org_eng_name = '" + org_eng_name.Text + "'"
                sqltmp = sqltmp + ",address_thai = '" + address_thai.Text + "'"
                sqltmp = sqltmp + ",address_eng = '" + address_eng.Text + "'"
                sqltmp = sqltmp + ",organization_type_id = '" + organization_type_id.SelectedValue + "'"
                sqltmp = sqltmp + ",type = '" + type.SelectedValue + "'"
                sqltmp = sqltmp + ",efdate = " + IIf(efdate.DateValue = Nothing, "null", "'" + efdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
                sqltmp = sqltmp + ",epdate = " + IIf(epdate.DateValue = Nothing, "null", "'" + epdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
                sqltmp = sqltmp + ",description = '" + description.Text + "'"
                sqltmp = sqltmp + ",tel = '" + tel.Text + "'"
                sqltmp = sqltmp + ",Fax = '" + fax.Text + "'"
                sqltmp = sqltmp + ",email = '" + email.Text + "'"
                sqltmp = sqltmp + ",active = '" + IIf(chkActive.Checked = True, "Y", "N") + "'"
                sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",update_on= getdate(), director='" & cmbDirectorID.SelectedValue & "'"
                sqltmp = sqltmp + " where id = " + id
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
        End If

        popup2.Show()
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If org_code.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกรหัส"
        ElseIf org_name.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกชื่อ"
        ElseIf org_thai_name.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกชื่อไทย"
        ElseIf organization_type_id.SelectedValue = "0" Then
            ret = False
            sys_msg.Text = "กรุณากรอกประเภทหน่วยงาน"
            'ElseIf efdate.DateValue = Nothing Then
            '    ret = False
            '    sys_msg.Text = "กรุณากรอกวันที่เริ่มใช้"
            'ElseIf epdate.DateValue = Nothing Then
            '    ret = False
            '    sys_msg.Text = "กรุณากรอกวันที่สิ้นสุด"
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from organization where id = " + ID.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString

            org_code.Text = Ds.Tables("DATA").Rows(0).Item("org_code").ToString
            org_name.Text = Ds.Tables("DATA").Rows(0).Item("org_name").ToString
            org_thai_name.Text = Ds.Tables("DATA").Rows(0).Item("org_thai_name").ToString
            name_abb.Text = Ds.Tables("DATA").Rows(0).Item("name_abb").ToString
            org_eng_name.Text = Ds.Tables("DATA").Rows(0).Item("org_eng_name").ToString
            address_thai.Text = Ds.Tables("DATA").Rows(0).Item("address_thai").ToString
            address_eng.Text = Ds.Tables("DATA").Rows(0).Item("address_eng").ToString
            description.Text = Ds.Tables("DATA").Rows(0).Item("description").ToString
            organization_type_id.SelectedValue = Ds.Tables("DATA").Rows(0).Item("organization_type_id").ToString
            type.SelectedValue = Ds.Tables("DATA").Rows(0).Item("type").ToString
            chkActive.Checked = (Ds.Tables("DATA").Rows(0).Item("active").ToString = "Y")

            If Not IsDBNull(Ds.Tables("DATA").Rows(0).Item("efdate")) Then
                efdate.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("efdate")))
            End If

            If Not IsDBNull(Ds.Tables("DATA").Rows(0).Item("epdate")) Then
                epdate.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("epdate")))
            End If

            tel.Text = Ds.Tables("DATA").Rows(0).Item("tel").ToString
            fax.Text = Ds.Tables("DATA").Rows(0).Item("fax").ToString
            email.Text = Ds.Tables("DATA").Rows(0).Item("email").ToString
            If Convert.IsDBNull(Ds.Tables("DATA").Rows(0).Item("director")) = False Then
                cmbDirectorID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("director").ToString
            End If

        End If
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable
        If IsClickSearch = True Then
            '<asp:ListItem Value="0">SECTOR</asp:ListItem>
            '<asp:ListItem Value="1">NON SECTOR</asp:ListItem>
            '<asp:ListItem Value="2">IC</asp:ListItem>


            sqltmp = "select o.id,o.org_code, o.name_abb, "
            sqltmp &= " case type when '0' then 'SECTOR' "
            sqltmp &= " when '1' then 'NON SECTOR' "
            sqltmp &= " when '2' then 'IC' end sector_type, o.org_name, o.org_thai_name, o.address_thai, o.email "
            sqltmp &= " from organization o "
            sqltmp &= " where o.org_code like '%" + txtSearch.Text.Trim() + "%' "
            sqltmp &= " or o.org_name like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.org_thai_name like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.name_abb like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.description like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.type like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.org_eng_name like '%" + txtSearch.Text + "%'"
            sqltmp &= " or o.organization_type_id like '%" + txtSearch.Text + "%'"
            dt = GetDataToList(sqltmp)
            Session("SearchResult") = dt
        Else
            'sqltmp = "select * from DOC_POSCRIPT order by id"
            'dt = GetDataToList(sqltmp)
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
        org_code.Text = ""
        org_name.Text = ""
        org_thai_name.Text = ""
        name_abb.Text = ""
        org_eng_name.Text = ""
        address_thai.Text = ""
        address_eng.Text = ""
        type.SelectedValue = "1"
        efdate.DateValue = Nothing
        epdate.DateValue = Nothing
        tel.Text = ""
        fax.Text = ""
        email.Text = ""
        organization_type_id.SelectedValue = "0"
        type.SelectedValue = "0"
        description.Text = ""
        cmbDirectorID.SelectedValue = "0"
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
        ClearData()
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM organization WHERE id=" + lbl.Text

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
