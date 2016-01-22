Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterModuleFolder
    Inherits System.Web.UI.Page

    Private Sub officer_owner()
        Dim dt As DataTable
        dt = GetDataToList("select id,first_name + ' ' + last_name as fullname from OFFICER order by first_name")
        officer_id_owner.SetItemList(dt, "fullname", "id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            officer_owner()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If officer_id_owner.SelectedValue = "0" Then
            ret = False
            sys_msg.Text = "กรุณาเลือกเจ้าหน้าที่"
        ElseIf folder_name.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกชื่อโฟล์เดอร์"
        ElseIf folder_url.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกโฟล์เดอร์ URL"
        ElseIf folder_ref_id.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกโฟล์เดอร์อ้างอิง"
        ElseIf order_seq.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกลำดับ"
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from MODULE_FOLDER where id = " + ID.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString
            officer_id_owner.SelectedValue = Ds.Tables("DATA").Rows(0).Item("officer_id_owner").ToString
            folder_name.Text = Ds.Tables("DATA").Rows(0).Item("folder_name").ToString
            folder_toolstip.Text = Ds.Tables("DATA").Rows(0).Item("folder_toolstip").ToString
            folder_desc.Text = Ds.Tables("DATA").Rows(0).Item("folder_desc").ToString

            folder_url.Text = Ds.Tables("DATA").Rows(0).Item("folder_url").ToString
            folder_ref_id.Text = Ds.Tables("DATA").Rows(0).Item("folder_ref_id").ToString
            order_seq.Text = Ds.Tables("DATA").Rows(0).Item("order_seq").ToString

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
            sqltmp = "select t2.username,t1.* from MODULE_FOLDER t1 "
            sqltmp &= "inner join OFFICER t2 on t2.id = t1.officer_id_owner "
            sqltmp &= " where t1.folder_desc like '%" + txtSearch.Text.Trim() + "%' or t1.folder_name like '%" + txtSearch.Text + "%' order by t2.username"
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
        officer_id_owner.SelectedValue = "0"
        folder_name.Text = ""
        folder_desc.Text = ""
        folder_toolstip.Text = ""

        folder_ref_id.Text = ""
        folder_url.Text = ""
        order_seq.Text = ""

        chkActive.Checked = False
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPath As String = "../Images/Module/"
        If ValidateData() = True Then
            sqltmp = "update MODULE_FOLDER set "
            sqltmp = sqltmp + " officer_id_owner = '" + officer_id_owner.SelectedValue + "'"
            sqltmp = sqltmp + ",folder_name = '" + folder_name.Text + "'"
            sqltmp = sqltmp + ",folder_toolstip = '" + folder_toolstip.Text + "'"
            sqltmp = sqltmp + ",folder_desc = '" + folder_desc.Text + "'"

            sqltmp = sqltmp + ",folder_url = '" + folder_url.Text + "'"
            sqltmp = sqltmp + ",folder_ref_id = " + folder_ref_id.Text
            sqltmp = sqltmp + ",order_seq = " + order_seq.Text

            If FileUpload1.HasFile Then sqltmp = sqltmp + ",folder_icon = '" + strPath + FileUpload1.FileName + "'"

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
                If FileUpload1.HasFile Then
                    FileUpload1.SaveAs(Server.MapPath(strPath & FileUpload1.FileName))
                End If

                SetGridview(True)
                ClearData()
                sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
            Else
                sys_msg.Text = msg
            End If

            popup2.Show()
        End If
    End Sub

    Protected Sub btnSave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave0.Click
        Dim strPath As String = "../Images/Module/"

        If ValidateData() = True Then
            txtID.Text = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from MODULE_FOLDER", "maxid")

            sqltmp = "insert into MODULE_FOLDER ("
            sqltmp = sqltmp + " id"
            sqltmp = sqltmp + ",officer_id_owner"
            sqltmp = sqltmp + ",folder_name"
            sqltmp = sqltmp + ",folder_toolstip"
            sqltmp = sqltmp + ",folder_desc"
            sqltmp = sqltmp + ",folder_icon"

            sqltmp = sqltmp + ",folder_url"
            sqltmp = sqltmp + ",folder_ref_id "
            sqltmp = sqltmp + ",order_seq"

            sqltmp = sqltmp + ",active"
            sqltmp = sqltmp + ",create_by"
            sqltmp = sqltmp + ",create_on"
            sqltmp = sqltmp + ") values ("
            sqltmp = sqltmp + txtID.Text
            sqltmp = sqltmp + ",'" + officer_id_owner.SelectedValue + "'"
            sqltmp = sqltmp + ",'" + folder_name.Text + "'"
            sqltmp = sqltmp + ",'" + folder_toolstip.Text + "'"
            sqltmp = sqltmp + ",'" + folder_desc.Text + "'"

            sqltmp = sqltmp + ",'" + folder_url.Text + "'"
            sqltmp = sqltmp + "," + folder_ref_id.Text
            sqltmp = sqltmp + "," + order_seq.Text

            If FileUpload1.HasFile Then
                sqltmp = sqltmp + ",'" + strPath + FileUpload1.FileName + "'"
            Else
                sqltmp = sqltmp + ",''"
            End If

            If chkActive.Checked = True Then
                sqltmp = sqltmp + ",'Y'"
            Else
                sqltmp = sqltmp + ",'N'"
            End If

            sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
            sqltmp = sqltmp + ",getdate())"

            Dim msg As String = sql_data(sqltmp)
            If msg = "" Then
                If FileUpload1.HasFile Then
                    FileUpload1.SaveAs(Server.MapPath(strPath & FileUpload1.FileName))
                End If

                SetGridview(True)
                ClearData()

                sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
            Else
                sys_msg.Text = msg
            End If
        End If

        popup2.Show()
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM MODULE_FOLDER WHERE id=" + lbl.Text

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
