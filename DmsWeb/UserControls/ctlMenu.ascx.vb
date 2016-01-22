﻿Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_ctlMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'SetGridview(True)
            GetModuleList()
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        zPop.Show()
        SetGridview(True)
    End Sub
    Private Sub GetModuleList()
        Dim dt As DataTable
        Dim fnc As New ModuleEng
        dt = fnc.GetAllModuleList(Nothing)
        cmbModule.SetItemList(dt, "module_name", "id")
        cmbModule.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        zPop.Show()
        Dim strPath As String = "../Menu/"
        If ValidateData() = True Then

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New MenuPara
            para.ID = Convert.ToInt64(txtID.Text)
            para.MENU_CODE = txtCode.Text
            para.MENU_NAME = txtName.Text
            para.MENU_TOOLSTIP = txtTooltip.Text
            para.MENU_DESC = txtDescription.Text
            para.MODULE_ID = cmbModule.SelectedValue
            para.MENU_URL = txtUrl.Text
            para.ORDER_SEQ = txtOrder.Text
            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            If FileUpload1.HasFile Then
                Dim MIMEType As String
                MIMEType = Config.getMIMEType(FileUpload1.PostedFile.FileName)
                para.MENU_ICON = strPath + txtCode.Text + MIMEType
            End If




            Dim fnc As New MenuEng
            If fnc.SaveMenu(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetMenuData(fnc.ID)

                If FileUpload1.HasFile Then
                    Config.UploadFile(FileUpload1, txtCode.Text, Server.MapPath(strPath))
                End If

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
            Config.SetAlert("กรุณากรอกรหัส", Me.Page, txtCode.ClientID)
        ElseIf txtOrder.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกลำดับ", Me.Page, txtOrder.ClientID)
        ElseIf cmbModule.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกโมดูล", Me.Page)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me.Page, txtName.ClientID)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรายละเอียด", Me.Page, txtDescription.ClientID)
        ElseIf txtTooltip.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกคำอธิบาย", Me.Page, txtTooltip.ClientID)
        ElseIf txtUrl.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอก Url", Me.Page, txtUrl.ClientID)
        ElseIf txtID.Text.Trim = "0" Then

            If FileUpload1.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) OrElse FileUpload1.PostedFile.InputStream Is Nothing Then
                ret = False
                Config.SetAlert("กรุณาเลือกไอคอน", Me.Page)
            End If

        End If
        Return ret
    End Function
    Private Sub GetMenuData(ByVal ID As Long)
        Dim fnc As New MenuEng
        Dim para As MenuPara
        para = fnc.GetMenuPara(ID)

        txtID.Text = para.ID
        txtCode.Text = para.MENU_CODE
        txtName.Text = para.MENU_NAME
        txtDescription.Text = para.MENU_DESC
        txtTooltip.Text = para.MENU_TOOLSTIP
        cmbModule.SelectedValue = para.MODULE_ID
        txtUrl.Text = para.MENU_URL
        txtOrder.Text = para.ORDER_SEQ
        If para.ACTIVE = "Y" Then
            chkActive.Checked = True
        Else
            chkActive.Checked = False
        End If
    End Sub
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        zPop.Show()
        Dim dt As DataTable
        Dim sql As String

        sql = "select mo.id,mo.module_id,mo.menu_code,mo.menu_name,mo.menu_desc,mo.menu_icon, "
        sql &= "md.module_name,mo.active,mo.menu_toolstip,mo.menu_url,mo.order_seq  "
        sql &= "from MENU mo inner join module md "
        sql &= "on mo.module_id =md.id "

        If txtSearch.Text <> "" Then
            sql &= "where mo.menu_code like '%" & txtSearch.Text.Trim & "%' or mo.menu_name like '%" & txtSearch.Text.Trim & "%' "
            sql &= "or md.module_name like '%" & txtSearch.Text.Trim & "%' or mo.menu_url like '%" & txtSearch.Text.Trim & "%' "
        End If

        sql &= "order by mo.menu_code "

        If IsClickSearch = True Then
            Dim fnc As New MenuEng
            dt = fnc.GetMenuListBySql(sql)
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

        GridView1.PageSize = 10
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
        GetMenuData(K(0).ToString)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        zPop.Show()
        ClearData()
    End Sub
    Private Sub ClearData()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        txtDescription.Text = ""
        txtTooltip.Text = ""
        cmbModule.SelectedValue = "0"
        txtUrl.Text = ""
        txtOrder.Text = ""
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
