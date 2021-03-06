﻿Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterObjective
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            If txtID.Text.Trim = "0" Or txtID.Text.Trim = "" Then
                txtID.Text = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from OBJECTIVE", "maxid")
                sqltmp = "insert into OBJECTIVE ("
                sqltmp = sqltmp + " id"
                sqltmp = sqltmp + ",Objective_code"
                sqltmp = sqltmp + ",Objective_name"
                sqltmp = sqltmp + ",active"
                sqltmp = sqltmp + ",create_by"
                sqltmp = sqltmp + ",create_on"
                sqltmp = sqltmp + ") values ("
                sqltmp = sqltmp + txtID.Text
                sqltmp = sqltmp + ",'" + txtCode.Text + "'"
                sqltmp = sqltmp + ",'" + txtName.Text + "'"

                If chkActive.Checked = True Then
                    sqltmp = sqltmp + ",'Y'"
                Else
                    sqltmp = sqltmp + ",'N'"
                End If
                sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",getdate())"
            Else
                sqltmp = "update Objective set "
                sqltmp = sqltmp + " Objective_code = '" + txtCode.Text + "'"
                sqltmp = sqltmp + ",Objective_name = '" + txtName.Text + "'"
                If chkActive.Checked = True Then
                    sqltmp = sqltmp + ",active = 'Y'"
                Else
                    sqltmp = sqltmp + ",active = 'N'"
                End If
                sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
                sqltmp = sqltmp + ",update_on= getdate()"
                sqltmp = sqltmp + " where id = " + txtID.Text
            End If

            Dim msg As String = sql_data(sqltmp)
            If msg = "" Then
                SetGridview(True)
                ClearData()
                'sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                Config.SetAlert(msg, Me) 'sys_msg.Text = msg
            End If
            'popup2.Show()
        End If
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            'sys_msg.Text = "กรุณากรอกรหัส"
            Config.SetAlert("กรุณากรอกรหัส", Me, txtCode.ClientID)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            'sys_msg.Text = "กรุณากรอกชื่อ"
            Config.SetAlert("กรุณากรอกชื่อ", Me, txtName.ClientID)
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from Objective where id = " + ID.ToString + " order by ID"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString
            txtCode.Text = Ds.Tables("DATA").Rows(0).Item("Objective_code").ToString
            txtName.Text = Ds.Tables("DATA").Rows(0).Item("Objective_name").ToString

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
            sqltmp = "select * from Objective where Objective_name like '%" + txtSearch.Text.Trim() + "%' or Objective_code like '%" + txtSearch.Text + "%' order by id"
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
        txtCode.Text = ""
        txtName.Text = ""
        chkActive.Checked = False
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

    'Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
    '    If ValidateData() = True Then

    '        txtID.Text = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from OBJECTIVE", "maxid")

    '        sqltmp = "insert into OBJECTIVE ("
    '        sqltmp = sqltmp + " id"
    '        sqltmp = sqltmp + ",Objective_code"
    '        sqltmp = sqltmp + ",Objective_name"
    '        sqltmp = sqltmp + ",active"
    '        sqltmp = sqltmp + ",create_by"
    '        sqltmp = sqltmp + ",create_on"
    '        sqltmp = sqltmp + ") values ("
    '        sqltmp = sqltmp + txtID.Text
    '        sqltmp = sqltmp + ",'" + txtCode.Text + "'"
    '        sqltmp = sqltmp + ",'" + txtName.Text + "'"

    '        If chkActive.Checked = True Then
    '            sqltmp = sqltmp + ",'Y'"
    '        Else
    '            sqltmp = sqltmp + ",'N'"
    '        End If

    '        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
    '        sqltmp = sqltmp + ",getdate())"

    '        Dim msg As String = sql_data(sqltmp)
    '        If msg = "" Then
    '            SetGridview(True)
    '            ClearData()

    '            sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
    '        Else
    '            sys_msg.Text = msg
    '        End If
    '    End If

    '    popup2.Show()
    'End Sub



    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM Objective WHERE id=" + lbl.Text

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
