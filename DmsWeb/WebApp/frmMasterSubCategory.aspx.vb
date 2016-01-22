Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmMasterSubCategory
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            GetCategoryList()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            Config.SaveTransLog("แสดงรายการประเภทย่อย", Config.GetLogOnUser.LOGIN_HISTORY_ID)
        End If
    End Sub
    Private Sub GetCategoryList()
        Dim dt As DataTable
        Dim fnc As New DocCategoryEng
        dt = fnc.GetAllCategoryList()
        cmbCategory.SetItemList(dt, "category_name", "id")
        cmbCategory.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New DocSubcategoryPara
            para.ID = Convert.ToInt64(txtID.Text)
            para.DOC_CATEGORY_ID = cmbCategory.SelectedValue
            para.SUBCATEGORY_CODE = txtCode.Text
            para.SUBCATEGORY_NAME = txtName.Text
            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            Dim fnc As New DocSubCategoryEng
            If fnc.SaveDocSubCategory(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetSubCategoryData(fnc.ID)
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
        If cmbCategory.SelectedValue = 0 Then
            ret = False
            Config.SetAlert("กรุณาเลือกประเภท", Me)
        ElseIf txtCode.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรหัส", Me, txtCode.ClientID)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me, txtName.ClientID)
        Else
            Dim eng As New Engine.Master.DocSubCategoryEng
            Dim chkMsg As String = eng.ChkDupDocSubCategory(txtID.Text, txtCode.Text, txtName.Text)
            If chkMsg <> "" Then
                ret = False
                Config.SetAlert(chkMsg, Me)
            End If
        End If
        Return ret
    End Function
    Private Sub GetSubCategoryData(ByVal ID As Long)
        Dim fnc As New DocSubCategoryEng
        Dim para As DocSubcategoryPara
        para = fnc.GetDocSubCategoryPara(ID)

        txtID.Text = para.ID
        cmbCategory.SelectedValue = para.DOC_CATEGORY_ID
        txtCode.Text = para.SUBCATEGORY_CODE
        txtName.Text = para.SUBCATEGORY_NAME
        If para.ACTIVE = "Y" Then
            chkActive.Checked = True
        Else
            chkActive.Checked = False
        End If
    End Sub
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable
        Dim whText As String = ""
        If txtSearch.Text <> "" Then
            whText &= " subcategory_code like '%" & txtSearch.Text.Trim & "%' or subcategory_name like '%" & txtSearch.Text.Trim & "%' "
            whText &= " or category_name like '%" & txtSearch.Text.Trim & "%'"
        End If

        If IsClickSearch = True Then
            Dim fnc As New DocSubCategoryEng
            dt = fnc.GetDataSubCategoryList(whText, "id")
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

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim id As Long = GridView1.Rows(e.RowIndex).Cells(0).Text
        Dim eng As New Engine.Master.DocSubCategoryEng
        Dim ret As String = eng.DeleteDocSubCategory(id)
        If ret <> "" Then
            Config.SetAlert(ret, Me)
        End If
        SetGridview(True)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim K As DataKey = GridView1.DataKeys(e.NewEditIndex)
        GetSubCategoryData(K(0).ToString)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub
    Private Sub ClearData()
        GetCategoryList()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        chkActive.Checked = False
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub
End Class
