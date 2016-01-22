Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmMasterMenu
    Inherits System.Web.UI.Page
    Dim DVLst As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            GetModuleList()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")

            If Session("List1") Is Nothing Then
                SetGridview(True)
            Else
                DVLst = Session("SearchResult")
            End If
        Else
            ViewState("sortfield") = "menu_code"
            ViewState("sortdirection") = "desc"

        End If
    End Sub
    Private Sub GetModuleList()
        Dim dt As DataTable
        Dim fnc As New ModuleEng
        dt = fnc.GetAllModuleList(Nothing)
        cmbModule.SetItemList(dt, "module_name", "id")
        cmbModule.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPath As String = "../Images/Menu/"
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
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(fnc.ErrorMessage, Me)
            End If
        End If
    End Sub
    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรหัส", Me, txtCode.ClientID)
        ElseIf txtOrder.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกลำดับ", Me, txtOrder.ClientID)
        ElseIf cmbModule.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกโมดูล", Me)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me, txtName.ClientID)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรายละเอียด", Me, txtDescription.ClientID)
        ElseIf txtTooltip.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกคำอธิบาย", Me, txtTooltip.ClientID)
        ElseIf txtUrl.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอก Url", Me, txtUrl.ClientID)
        ElseIf txtID.Text.Trim = "0" Then

            'If FileUpload1.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) OrElse FileUpload1.PostedFile.InputStream Is Nothing Then
            '    ret = False
            '    Config.SetAlert("กรุณาเลือกไอคอน", Me)
            'End If

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

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim K As DataKey = GridView1.DataKeys(e.NewEditIndex)
        GetMenuData(K(0).ToString)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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
        SetGridview(True)
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If ViewState("sortfield") = e.SortExpression Then
            If ViewState("sortdirection") = "asc" Then ViewState("sortdirection") = "desc" Else ViewState("sortdirection") = "asc"
        Else
            ViewState("sortfield") = e.SortExpression
            ViewState("sortdirection") = "asc"
        End If
        DVLst.Sort = "[" & ViewState("sortfield") & "] " & ViewState("sortdirection")
        'Me.MyGridBind()
        GridView1.PageSize = 20
        'pcTop.SetMainGridView(GridView1)
        GridView1.DataSource = Session("SearchResult")
        GridView1.DataBind()
        ' pcTop.Update(Session("SearchResult").Rows.Count)
    End Sub
End Class
