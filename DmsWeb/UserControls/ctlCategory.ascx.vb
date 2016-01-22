Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_ctlCategory
    Inherits System.Web.UI.UserControl
    Public WriteOnly Property AddStatus() As Boolean
        Set(ByVal value As Boolean)
            txtBox1.Visible = False
            ImageSearch.Visible = False
            txtBox2.Visible = False
            ImageButton1.Visible = True
            lblCaption.Visible = True
            GridView1.Columns(6).Visible = False
        End Set
    End Property
    Public WriteOnly Property SelectStatus() As Boolean
        Set(ByVal value As Boolean)
            txtBox1.Visible = True
            ImageSearch.Visible = True
            txtBox2.Visible = True
            ImageButton1.Visible = False
            lblCaption.Visible = False
            GridView1.Columns(6).Visible = True
        End Set
    End Property
    Public Property Value() As String
        Get
            Return lblID.Text
        End Get
        Set(ByVal value As String)
            lblID.Text = value
        End Set
    End Property
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

            Dim para As New DocCategoryPara
            para.ID = Convert.ToInt64(txtID.Text)
            para.CATEGORY_CODE = txtCode.Text
            para.CATEGORY_NAME = txtName.Text

            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            Dim fnc As New DocCategoryEng
            If fnc.SaveDocCategory(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetCategoryData(fnc.ID)
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
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me.Page, txtName.ClientID)
        End If
        Return ret
    End Function
    Private Sub GetCategoryData(ByVal ID As Long)
        Dim fnc As New DocCategoryEng
        Dim para As DocCategoryPara
        para = fnc.GetDocCategoryPara(ID)

        txtID.Text = para.ID
        txtCode.Text = para.CATEGORY_CODE
        txtName.Text = para.CATEGORY_NAME
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
            Dim fnc As New DocCategoryEng
            dt = fnc.GetDataCategoryList("category_name like '%" + txtSearch.Text.Trim() + "%' or category_code like '%" + txtSearch.Text + "%'", "category_code")
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
        zPop.Show()
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        zPop.Show()
        Dim K As DataKey = GridView1.DataKeys(e.NewEditIndex)
        GetCategoryData(K(0).ToString)
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
        SetGridview(True)
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim fnc As New DocCategoryEng
        Dim para As DocCategoryPara
        Dim K As DataKey = GridView1.DataKeys(e.NewSelectedIndex)
        para = fnc.GetDocCategoryPara(K(0))

        lblID.Text = para.ID
        txtBox1.Text = para.CATEGORY_CODE
        txtBox2.Text = para.CATEGORY_NAME

        txtSearch.Text = ""
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
    Protected Sub txtBox1_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBox1.TextChange
        If txtBox1.Text.Trim <> "" Then
            Search(True)
        Else

            txtBox1.Text = ""
            txtBox2.Text = ""
            lblID.Text = ""
            txtSearch.Text = ""

        End If

    End Sub
    Private Sub Search(ByVal IsClickSearch As Boolean)
        lblID.Text = ""
        txtBox2.Text = ""
        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New DocCategoryEng
            dt = fnc.GetDataCategoryList("category_code like '%" & txtBox1.Text & "'", "category_code")
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

        If dt.Rows.Count = 1 Then
            txtBox1.Text = dt.Rows(0)("category_code")
            txtBox2.Text = dt.Rows(0)("category_name")
            lblID.Text = dt.Rows(0)("id")
        Else
            If dt.Rows.Count = 0 Then
                Dim fnc As New DocCategoryEng
                dt = fnc.GetDataCategoryList("", "") 'ถ้าผลลัพธ์ที่ได้มี 0 รายการ ให้แสดงออกมาทั้งหมด
            End If

            GridView1.PageSize = 10
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
            zPop.Show()
        End If
    End Sub
    Protected Sub ImageSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSearch.Click
        Search(True)
    End Sub
    Public ReadOnly Property CategoryParameter() As DocCategoryPara
        Get
            Dim para As New DocCategoryPara
            If lblID.Text.Trim <> "" And lblID.Text.Trim <> "0" Then
                Dim fnc As New DocCategoryEng
                para = fnc.GetDocCategoryPara(lblID.Text)
            End If
            Return para
        End Get
    End Property
    Private Sub ClearAllField()
        txtBox1.Text = ""
        txtBox2.Text = ""
        lblID.Text = ""
        txtSearch.Text = ""
    End Sub
    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Dim para As DocCategoryPara = CategoryParameter()
        If para.ID = 0 Then
            ClearAllField()
            txtBox1.Focus()
        End If
    End Sub
End Class
