Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterGroupTitleComDef
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            group_title_id.Text = Request.Params("id").ToString
            group_title_code.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_code")
            group_title_name.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_name")

            SetGridview(True)
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            If getdatafld("select count(*) as cnt from GROUP_TITLE_COMPANY_DEFAULT where company_id = " + company_id.Text + " and group_title_id = " + group_title_id.Text + " and id <> " + txtID.Text, "cnt") = "0" Then

                sqltmp = "update GROUP_TITLE_COMPANY_DEFAULT set "
                sqltmp = sqltmp + " group_title_id = " + group_title_id.Text
                sqltmp = sqltmp + ",company_id = " + company_id.Text
                sqltmp = sqltmp + ",officer_sign_name = '" + officer_sign_name.Text + "'"
                sqltmp = sqltmp + ",remarks = '" + remarks.Text + "'"

                If chkActive.Checked = True Then
                    sqltmp = sqltmp + ",active = 'Y'"
                Else
                    sqltmp = sqltmp + ",active = 'N'"
                End If

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
                sys_msg.Text = "มีช้อมูลบริษัทอยู่แล้วทำซ้ำไม่ได้"
            End If
        End If

        popup2.Show()
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If company_id.Text = "" Then
            ret = False
            sys_msg.Text = "กรุณาเลือกบริษัท"
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from GROUP_TITLE_COMPANY_DEFAULT where id = " + ID.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString

            group_title_id.Text = Ds.Tables("DATA").Rows(0).Item("group_title_id").ToString
            group_title_code.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_code")
            group_title_name.Text = getdatafld("select * from GROUP_TITLE where id = " + group_title_id.Text, "group_title_name")

            company_id.Text = Ds.Tables("DATA").Rows(0).Item("company_id").ToString
            company_name.Text = getdatafld("select thainame from company where id = " + company_id.Text, "thainame")

            officer_sign_name.Text = Ds.Tables("DATA").Rows(0).Item("officer_sign_name").ToString
            remarks.Text = Ds.Tables("DATA").Rows(0).Item("remarks").ToString

            If Ds.Tables("DATA").Rows(0).Item("active").ToString = "Y" Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If
        End If
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable

        sqltmp = "select t1.*,t2.thainame from GROUP_TITLE_COMPANY_DEFAULT t1 "
        sqltmp &= " inner join COMPANY t2 on t1.company_id = t2.id "
        sqltmp &= " where group_title_id = " + group_title_id.Text + " order by t2.thainame"
        dt = GetDataToList(sqltmp)

        GridView1.PageSize = 15
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
        company_id.Text = ""
        company_name.Text = ""
        officer_sign_name.Text = ""
        remarks.Text = ""
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
            If getdatafld("select count(*) as cnt from GROUP_TITLE_COMPANY_DEFAULT where company_id = " + company_id.Text + " and group_title_id = " + group_title_id.Text, "cnt") = "0" Then
                txtID.Text = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from GROUP_TITLE_COMPANY_DEFAULT", "maxid")

                sqltmp = "insert into GROUP_TITLE_COMPANY_DEFAULT ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",group_title_id"
                sqltmp = sqltmp + ",company_id"
                sqltmp = sqltmp + ",officer_sign_name"
                sqltmp = sqltmp + ",remarks"
                sqltmp = sqltmp + ",active"

                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + txtID.Text
                sqltmp = sqltmp + "," + group_title_id.Text
                sqltmp = sqltmp + "," + company_id.Text
                sqltmp = sqltmp + ",'" + officer_sign_name.Text + "'"
                sqltmp = sqltmp + ",'" + remarks.Text + "'"

                If chkActive.Checked = True Then
                    sqltmp = sqltmp + ",'Y'"
                Else
                    sqltmp = sqltmp + ",'N'"
                End If

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
                sys_msg.Text = "มีช้อมูลบริษัทอยู่แล้วทำซ้ำไม่ได้"
            End If
        End If

        popup2.Show()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM GROUP_TITLE_COMPANY_DEFAULT WHERE id=" + lbl.Text

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

    Protected Sub GridView4_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView4.RowCommand
        If e.CommandName = "comname" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView4.Rows(index)
            Dim lbl As Label = row.FindControl("comid")

            company_id.Text = getdatafld("select id from company where id = " + lbl.Text, "id")
            company_name.Text = getdatafld("select thainame from company where id = " + lbl.Text, "thainame")
        End If
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmMasterGroupTitle.aspx")
    End Sub

    Protected Sub ImageButton12_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton12.Click
        SetGridviewCom()
        popup3.Show()
    End Sub

    Private Sub SetGridviewCom()
        Dim dt As DataTable

        sqltmp = "select top 50 * from COMPANY t1 where thainame <> '' "
        sqltmp &= "and (thaiName like '%" + company_find.Text.Trim + "%' or engName like '%" + company_find.Text.Trim + "%'"

        If IsNumeric(company_find.Text.Trim) Then sqltmp &= "or id = " + company_find.Text.Trim

        sqltmp &= ") order by thainame"
        dt = GetDataToList(sqltmp)

        GridView4.PageSize = 15
        pcTop0.SetMainGridView(GridView4)
        GridView4.DataSource = dt
        GridView4.DataBind()
        pcTop0.Update(dt.Rows.Count)
    End Sub

    Protected Sub btnYes14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes14.Click
        SetGridviewCom()
        popup3.Show()
    End Sub


    Protected Sub pcTop0_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop0.PageChange
        GridView4.PageIndex = pcTop0.SelectPageIndex
        SetGridviewCom()
        popup3.Show()
    End Sub
End Class
