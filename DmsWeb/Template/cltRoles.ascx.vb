Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class Template_cltRoles
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        zPop.Show()
        SetGridview(True)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        zPop.Show()
        If ValidateData() = True Then

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New RolesPara
            para.ID = Convert.ToInt64(txtID.Text)
            para.ROLE_CODE = txtCode.Text
            para.ROLE_NAME = txtName.Text
            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            Dim fnc As New RolesEng
            If fnc.SaveRoles(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetRoleData(fnc.ID)
                SetGridview(True)
                ClearData()
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me.Page)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(fnc.ErrorMessage, Me.Page)
            End If
        End If
    End Sub
    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรหัสกลุ่ม", Me.Page, txtCode.ClientID)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อกลุ่ม", Me.Page, txtName.ClientID)
        End If
        Return ret
    End Function
    Private Sub GetRoleData(ByVal ID As Long)
        Dim fnc As New RolesEng
        Dim para As RolesPara
        para = fnc.GetRolesPara(ID)

        txtID.Text = para.ID
        txtCode.Text = para.ROLE_CODE
        txtName.Text = para.ROLE_NAME
        If para.ACTIVE = "Y" Then
            chkActive.Checked = True
        Else
            chkActive.Checked = False
        End If
    End Sub
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        zPop.Show()
        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New RolesEng
            dt = fnc.GetDataRolesList("role_name like '%" + txtSearch.Text.Trim() + "%' or role_code like '%" + txtSearch.Text + "%'", "role_code")
            Session("SearchResult") = dt
        Else
            Dim sortStr As String = ""
            If txtSortField.Text.Trim <> "" Then
                sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
            End If
            dt = Session("SearchResult")
            dt.DefaultView.Sort = sortStr
            dt = dt.DefaultView.ToTable()
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
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        zPop.Show()
        Dim K As DataKey = GridView1.DataKeys(e.NewEditIndex)
        GetRoleData(K(0).ToString)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        zPop.Show()
        ClearData()
    End Sub
    Private Sub ClearData()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        chkActive.Checked = False
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        zPop.Show()
        SetGridview(True)
    End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression = "DEFAULT" Then
            txtSortDir.Text = ""
            txtSortField.Text = ""
        Else
            If txtSortField.Text = e.SortExpression Then
                txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
            Else : txtSortField.Text = e.SortExpression
            End If
        End If

        SetGridview(False)
    End Sub
End Class
