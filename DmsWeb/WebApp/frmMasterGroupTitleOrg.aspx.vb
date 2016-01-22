Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterGroupTitleOrg
    Inherits System.Web.UI.Page

    Private Sub organization()
        Dim dt As DataTable
        dt = GetDataToList("select * from ORGANIZATION order by org_name")
        organization_id.SetItemList(dt, "org_name", "id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            group_title_id.Text = Request.Params("id").ToString
            group_title_code.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_code")
            group_title_name.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_name")

            organization()
            SetGridview(True)
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            If getdatafld("select count(*) as cnt from GROUP_TITLE_ORG_RESPONSE where organization_id = " + organization_id.SelectedValue + " and group_title_id = " + group_title_id.Text + " and id <> " + txtID.Text, "cnt") = "0" Then
                
                sqltmp = "update GROUP_TITLE_ORG_RESPONSE set "
                sqltmp = sqltmp + " group_title_id = " + group_title_id.Text
                sqltmp = sqltmp + ",organization_type_id = '" + organization_type_id.SelectedValue + "'"
                sqltmp = sqltmp + ",organization_id = " + organization_id.SelectedValue
                sqltmp = sqltmp + ",std_proc_period = " + IIf(std_proc_period.Text.Trim = "", "null", std_proc_period.Text)
                sqltmp = sqltmp + ",max_proc_period = " + IIf(max_proc_period.Text.Trim = "", "null", max_proc_period.Text)
                sqltmp = sqltmp + ",organization_name = '" + getdatafld("select org_name from organization where id = " + organization_id.SelectedValue, "org_name") + "'"
                sqltmp = sqltmp + ",organization_appname = '" + getdatafld("select name_abb from organization where id = " + organization_id.SelectedValue, "name_abb") + "'"

                sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",update_on= getdate()"
                sqltmp = sqltmp + " where id = " + txtID.Text

                Dim msg As String = sql_data(sqltmp)
                If msg = "" Then
                    SetGridview(True)
                    ClearData()
                    sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
                Else
                    sys_msg.Text = msg
                End If
            Else
                sys_msg.Text = "มีช้อมูลหน่วยงานอยู่แล้วทำซ้ำไม่ได้"
            End If
        End If

        popup2.Show()
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If group_title_code.Text = "0" Then
            ret = False
            sys_msg.Text = "กรุณาเลือกกลุ่มเรื่อง"
        ElseIf organization_id.SelectedValue = "0" Then
            ret = False
            sys_msg.Text = "กรุณาเลือกหน่วยงาน"
            'ElseIf std_proc_period.Text.Trim = "" Then
            '    ret = False
            '    sys_msg.Text = "กรุณากรอกจำนวนวันมาตรฐาน"
            'ElseIf max_proc_period.Text.Trim = "" Then
            '    ret = False
            '    sys_msg.Text = "กรุณากรอกจำนวนวันกำหนดเสร็จ"
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from GROUP_TITLE_ORG_RESPONSE where id = " + ID.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString

            group_title_id.Text = Ds.Tables("DATA").Rows(0).Item("group_title_id").ToString
            group_title_code.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.text, "group_title_code")
            group_title_name.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_name")

            organization_type_id.SelectedValue = Ds.Tables("DATA").Rows(0).Item("organization_type_id").ToString
            organization_id.SelectedValue = Ds.Tables("DATA").Rows(0).Item("organization_id").ToString
            std_proc_period.Text = Ds.Tables("DATA").Rows(0).Item("std_proc_period").ToString
            max_proc_period.Text = Ds.Tables("DATA").Rows(0).Item("max_proc_period").ToString
        End If
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable

        sqltmp = "select * from GROUP_TITLE_ORG_RESPONSE where group_title_id = " + group_title_id.Text + " order by organization_name"
        dt = GetDataToList(sqltmp)

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
        organization_type_id.SelectedValue = "0"
        organization_id.SelectedValue = "0"
        std_proc_period.Text = ""
        max_proc_period.Text = ""
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

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        If ValidateData() = True Then
            If getdatafld("select count(*) as cnt from GROUP_TITLE_ORG_RESPONSE where organization_id = " + organization_id.SelectedValue + " and group_title_id = " + group_title_id.Text, "cnt") = "0" Then
                txtID.Text = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from GROUP_TITLE_ORG_RESPONSE", "maxid")

                sqltmp = "insert into GROUP_TITLE_ORG_RESPONSE ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",group_title_id"
                sqltmp = sqltmp + ",organization_type_id"
                sqltmp = sqltmp + ",organization_id"
                sqltmp = sqltmp + ",std_proc_period"
                sqltmp = sqltmp + ",max_proc_period"
                sqltmp = sqltmp + ",organization_name"
                sqltmp = sqltmp + ",organization_appname"
                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + txtID.Text
                sqltmp = sqltmp + "," + group_title_id.Text
                sqltmp = sqltmp + ",'" + organization_type_id.SelectedValue + "'"
                sqltmp = sqltmp + "," + organization_id.SelectedValue
                sqltmp = sqltmp + "," + IIf(std_proc_period.Text.Trim = "", "null", std_proc_period.Text)
                sqltmp = sqltmp + "," + IIf(max_proc_period.Text.Trim = "", "null", max_proc_period.Text)
                sqltmp = sqltmp + ",'" + getdatafld("select org_name from organization where id = " + organization_id.SelectedValue, "org_name") + "'"
                sqltmp = sqltmp + ",'" + getdatafld("select name_abb from organization where id = " + organization_id.SelectedValue, "name_abb") + "'"
                sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",getdate())"

                Dim msg As String = sql_data(sqltmp)
                If msg = "" Then
                    SetGridview(True)
                    ClearData()

                    sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
                Else
                    sys_msg.Text = msg
                End If
            Else
                sys_msg.Text = "มีช้อมูลหน่วยงานอยู่แล้วทำซ้ำไม่ได้"
            End If
        End If

        popup2.Show()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM GROUP_TITLE_ORG_RESPONSE WHERE id=" + lbl.Text

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

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmMasterGroupTitle.aspx")
    End Sub
End Class
