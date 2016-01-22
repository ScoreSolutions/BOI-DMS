Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI
Imports Linq.Common.Utilities.SqlDB
Imports Engine.Master
Imports Para.TABLE
Imports Engine.Common
Imports Linq.TABLE


Partial Class WebApp_frmMMasterUserGroupPermission
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Button2.Attributes.Add("OnClick", "location.href='frmMasterGroupRole.aspx';")

        If Not Page.IsPostBack Then
            load_menu_moduile()

            If Request.Params("rowid") = Nothing Then
                load_menu_new()
                edit_mode = new_data
                txtgroupID.ReadOnly = False
                txtgroupID.BackColor = Drawing.Color.White
            Else
                docid = Request.Params("rowid").ToString
                load_data()
                load_menu_edit()
                edit_mode = edit_data
                txtgroupID.ReadOnly = True
                txtgroupID.BackColor = Drawing.Color.MintCream
            End If
        End If
    End Sub

    Private Sub load_data()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from ROLES where id = " + docid.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            rowid.Text = Ds.Tables("DATA").Rows(0).Item("id").ToString
            txtgroupID.Text = Ds.Tables("DATA").Rows(0).Item("role_code").ToString
            TxtGroupName.Text = Ds.Tables("DATA").Rows(0).Item("role_name").ToString
            txtActive.SelectedValue = Ds.Tables("DATA").Rows(0).Item("active").ToString
        End If
    End Sub

    Private Sub load_menu_moduile()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from MODULE order by order_seq"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        MenuModule.DataTextField = "module_name"
        MenuModule.DataValueField = "id"
        MenuModule.DataSource = Ds.Tables("DATA")
        MenuModule.DataBind()
    End Sub

    Private Sub load_menu_new()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select id as rowid,menu_code,menu_name,0 as active,0 as active_a,0 as active_e,0 as active_d "
        sqltmp = sqltmp + " from MENU "
        sqltmp = sqltmp + " Where module_id = " + MenuModule.SelectedValue + " "
        sqltmp = sqltmp + " order by menu_code"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")


        GridView1.PageSize = 20
        GridView1.DataSource = Ds
        GridView1.DataBind()
    End Sub

    Private Sub load_menu_edit()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select menu.id as rowid,menu_code,menu_name,1 as active,0 as active_a,0 as active_e,0 as active_d "
        sqltmp = sqltmp + " from MENU inner join ROLES_MENU on menu_code = menu_id "
        sqltmp = sqltmp + " Where module_id = " + MenuModule.SelectedValue + " "
        sqltmp = sqltmp + " and roles_id = " + rowid.Text
        sqltmp = sqltmp + " union all "
        sqltmp = sqltmp + " select menu.id as rowid,menu_code,menu_name,0 as active,0 as active_a,0 as active_e,0 as active_d "
        sqltmp = sqltmp + " from MENU "
        sqltmp = sqltmp + " Where module_id = " + MenuModule.SelectedValue + " "
        sqltmp = sqltmp + " and menu_code not in (select menu_id from ROLES_MENU where roles_id = " + rowid.Text + ")"

        sqltmp = sqltmp + " order by menu_code"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")


        GridView1.PageSize = 20
        GridView1.DataSource = Ds
        GridView1.DataBind()
    End Sub


    'Protected Sub chk_all_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CType(GridView1.HeaderRow.FindControl("chk_all"), CheckBox).Checked Then
    '        Dim i As Integer
    '        For i = 0 To GridView1.Rows.Count - 1
    '            Dim gvRow As GridViewRow = GridView1.Rows(i)
    '            CType(gvRow.FindControl("chk_id"), CheckBox).Checked = True
    '        Next
    '    Else
    '        Dim i As Integer
    '        For i = 0 To GridView1.Rows.Count - 1
    '            Dim gvRow As GridViewRow = GridView1.Rows(i)
    '            CType(gvRow.FindControl("chk_id"), CheckBox).Checked = False
    '        Next
    '    End If
    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("frmMasterGroupRole.aspx")
    End Sub

    Private Function Validated_Field() As Boolean
        If txtgroupID.Text = "" Then Return False
        If TxtGroupName.Text = "" Then Return False

        Return True
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Validated_Field Then
        If edit_mode = new_data Then
            save_new()
        Else
            save_update()
        End If
        'End If
    End Sub

    Public Sub save_new()
        condb()

        Dim COMMAND As New SqlCommand

        conn = New SqlConnection(cnstr)
        conn.Open()
        COMMAND.Connection = conn

        Try
            Dim txtID As String = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from ROLES_MENU", "maxid")

            sqltmp = " insert into ROLES (id,role_code,role_name,active,create_on,create_by) values ("
            sqltmp = sqltmp + txtID
            sqltmp = sqltmp + ",'" + txtgroupID.Text + "'"
            sqltmp = sqltmp + ",'" + TxtGroupName.Text + "'"
            sqltmp = sqltmp + ",'" + txtActive.SelectedValue + "'"
            sqltmp = sqltmp + ",'" + Format(Date.Now, "yyyy/MM/dd hh:mm") + "'"
            sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
            sqltmp = sqltmp + ")"


            COMMAND.CommandText = sqltmp
            COMMAND.ExecuteNonQuery()

            save_menu()

            rowid.Text = getdatafld("select max(id) from ROLES where create_by ='" + Config.GetLogOnUser.UserName + "'", "id")
            edit_mode = edit_data

            conn.Close()

            popup1.Show()
        Catch ex As Exception
            msg_err.Text = ex.Message
            popup2.Show()
        End Try
    End Sub

    Public Sub save_update()
        condb()

        Dim COMMAND As New SqlCommand

        conn = New SqlConnection(cnstr)
        conn.Open()
        COMMAND.Connection = conn

        Try
            sqltmp = " update ROLES set "
            sqltmp = sqltmp + " role_code = '" + txtgroupID.Text + "'"
            sqltmp = sqltmp + ",role_name = '" + TxtGroupName.Text + "'"
            sqltmp = sqltmp + ",active = '" + txtActive.SelectedValue + "'"
            sqltmp = sqltmp + ",update_on = '" + Format(Date.Now, "yyyy/MM/dd hh:mm") + "'"
            sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
            sqltmp = sqltmp + " where id = " + rowid.Text


            COMMAND.CommandText = sqltmp
            COMMAND.ExecuteNonQuery()

            save_menu()

            conn.Close()

            popup1.Show()
        Catch ex As Exception
            msg_err.Text = ex.Message
            popup2.Show()
        End Try
    End Sub

    Private Sub save_menu()
        condb()

        Dim i As Integer
        Dim isChecked As CheckBox
        'Dim isCheckedA As CheckBox
        'Dim isCheckedE As CheckBox
        'Dim isCheckedD As CheckBox
        Dim isLabel As Label
        Dim row As GridViewRow

        Dim COMMAND As New SqlCommand

        conn = New SqlConnection(cnstr)
        conn.Open()
        COMMAND.Connection = conn

        Try
            sqltmp = " delete from ROLES_MENU "
            sqltmp = sqltmp + " where menu_id in (select menu_code from MENU where module_id = " + MenuModule.SelectedValue + ")"
            sqltmp = sqltmp + " and roles_id = '" + rowid.Text + "'"

            COMMAND.CommandText = sqltmp
            COMMAND.ExecuteNonQuery()

            'Select the checkboxes from the GridView control
            For i = 0 To GridView1.Rows.Count - 1
                row = GridView1.Rows(i)

                isChecked = CType(row.FindControl("chk_id"), CheckBox)
                'isCheckedA = CType(row.FindControl("chk_a"), CheckBox)
                'isCheckedE = CType(row.FindControl("chk_e"), CheckBox)
                'isCheckedD = CType(row.FindControl("chk_d"), CheckBox)

                isLabel = CType(row.FindControl("txt_id"), Label)

                If isChecked.Checked Then
                    Dim txtID As String = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from ROLES_MENU", "maxid")

                    sqltmp = "insert into ROLES_MENU (id,roles_id,menu_id,create_on,create_by) values ("
                    sqltmp = sqltmp + txtID
                    sqltmp = sqltmp + ",'" + rowid.Text + "'"
                    sqltmp = sqltmp + ",'" + CType(row.FindControl("txt_menu_code"), Label).Text + "'"

                    sqltmp = sqltmp + ",'" + Format(Date.Now, "yyyy/MM/dd hh:mm") + "'"
                    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + ")"

                    COMMAND.CommandText = sqltmp
                    COMMAND.ExecuteNonQuery()
                End If
            Next

            conn.Close()
        Catch ex As Exception
            msg_err.Text = ex.Message
            popup2.Show()
        End Try
    End Sub


    Protected Sub MenuModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuModule.SelectedIndexChanged
        If edit_mode = edit_data Then
            load_menu_edit()
        Else
            load_menu_new()
        End If
    End Sub

    Protected Sub btnYes3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes3.Click
        Response.Redirect("frmMasterGroupRole.aspx")
    End Sub
End Class
