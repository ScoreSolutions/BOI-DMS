Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI
Imports Linq.Common.Utilities.SqlDB
Imports Engine.Master
Imports Para.TABLE
Imports Engine.Common
Imports Linq.TABLE

Partial Class WebApp_frmMMasterUserGroup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            doc_query()
        End If
    End Sub


    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        doc_query()
    End Sub

    Private Sub doc_query()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select row_number() OVER (ORDER BY login_username) AS rownum,"

        'sqltmp = "select '1' as rownum,"

        sqltmp = sqltmp + " login_username,user_full_name,organization_id,organization_name, "
        sqltmp = sqltmp + " '~/WebApp/frmMasterUser.aspx?userid=' + rtrim(login_username) as url_field "
        sqltmp = sqltmp + " from ROLES_USER t1 "
        sqltmp = sqltmp + " LEFT JOIN ROLES t2 on t2.id = t1.roles_id "
        sqltmp = sqltmp + " where 1=1 "

        If Trim(txtUserID.Text) <> "" Then
            If Trim(TxtUserName.Text) <> "" Then
                sqltmp = sqltmp + " and (login_username like '%" + Trim(txtUserID.Text) + "%'"
                sqltmp = sqltmp + " or user_full_name like '%" + Trim(TxtUserName.Text) + "%')"
            Else
                sqltmp = sqltmp + " and login_username like '%" + Trim(txtUserID.Text) + "%'"
            End If
        Else
            If Trim(TxtUserName.Text) <> "" Then
                sqltmp = sqltmp + " and user_full_name like '%" + Trim(TxtUserName.Text) + "%'"
            End If
        End If


        sqltmp = sqltmp + " group by login_username, user_full_name, organization_id, organization_name,'~/WebApp/frmMasterUser.aspx?userid=' + rtrim(login_username)"
        sqltmp = sqltmp + " order by login_username"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")


        GridView1.PageSize = 20
        GridView1.DataSource = Ds
        GridView1.DataBind()


        pcTop.SetMainGridView(GridView1)
        pcTop.Update(Ds.Tables("DATA").Rows.Count)
        pcTop.DataBind()

        'If Ds.Tables("DATA").Rows.Count > 0 Then

        'End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        doc_query()
    End Sub


    Private Sub PGridviewDeleteData(ByVal gd As GridView, ByVal TBdata As String, ByVal fldkey As String)
        condb()

        Dim str As New StringBuilder
        Dim i As Integer
        Dim isChecked As CheckBox
        Dim isLabel As Label
        Dim row As GridViewRow

        Dim sqltmp As String
        'Dim myTrans As OleDbTransaction

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        'Select the checkboxes from the GridView control
        For i = 0 To gd.Rows.Count - 1
            row = gd.Rows(i)
            isChecked = CType(row.FindControl("chk_id"), CheckBox)
            isLabel = CType(row.FindControl("txt_id"), Label)

            If isChecked.Checked Then
                Try
                    sqltmp = " delete from " + TBdata + " where " + fldkey + " = '" + isLabel.Text + "'"

                    COMMAND.CommandText = sqltmp
                    COMMAND.ExecuteNonQuery()
                Catch ex As Exception
                Finally

                End Try
            End If
        Next
    End Sub

    Protected Sub btnYes0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes0.Click
        PGridviewDeleteData(GridView1, "ROLES_USER", "login_username")

        doc_query()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        If GridviewCheck(GridView1) Then
            popup1.Show()
        Else
            popup2.Show()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("frmMasterUser.aspx?rowid=")
    End Sub
End Class
