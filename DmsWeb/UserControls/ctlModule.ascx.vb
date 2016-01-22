Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_ctlModule
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
        Dim strPath As String = "../Module/"
        If ValidateData() = True Then

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New ModulePara
            para.ID = Convert.ToInt64(txtID.Text)
            para.MODULE_CODE = txtCode.Text
            para.MODULE_NAME = txtName.Text
            para.MODULE_TOOLSTIP = txtTooltip.Text
            para.MODULE_DESC = txtDescription.Text
            para.ORDER_SEQ = txtOrder.Text

            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            If FileUpload1.HasFile Then
                Dim MIMEType As String
                MIMEType = Config.getMIMEType(FileUpload1.PostedFile.FileName)
                para.MODULE_ICON = strPath + txtCode.Text + MIMEType
            End If


            Dim fnc As New ModuleEng
            If fnc.SaveModule(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetModuleData(fnc.ID)

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
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me.Page, txtName.ClientID)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรายละเอียด", Me.Page, txtDescription.ClientID)
        ElseIf txtTooltip.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกคำอธิบาย", Me.Page, txtTooltip.ClientID)
        ElseIf txtID.Text.Trim = "0" Then

            If FileUpload1.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) OrElse FileUpload1.PostedFile.InputStream Is Nothing Then
                ret = False
                Config.SetAlert("กรุณาเลือกไอคอน", Me.Page)
            End If

        End If
        Return ret
    End Function
    Private Sub GetModuleData(ByVal ID As Long)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim fnc As New ModuleEng
        Dim para As ModulePara
        para = fnc.GetModulePara(ID, trans)

        txtID.Text = para.ID
        txtCode.Text = para.MODULE_CODE
        txtName.Text = para.MODULE_NAME
        txtDescription.Text = para.MODULE_DESC
        txtTooltip.Text = para.MODULE_TOOLSTIP
        txtOrder.Text = para.ORDER_SEQ
        If para.ACTIVE = "Y" Then
            chkActive.Checked = True
        Else
            chkActive.Checked = False
        End If

        trans.CommitTransaction()
    End Sub
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        zPop.Show()
        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim fnc As New ModuleEng
            'dt = fnc.GetDataModuleList("module_name like '%" + txtSearch.Text.Trim() + "%' or module_code like '%" _
            '     + txtSearch.Text + "%'  or module_desc like '%" + txtSearch.Text.Trim() + "%' or module_toolstip like '%" + txtSearch.Text.Trim() + "%'", "module_code", trans)

            Session("SearchResult") = dt

            trans.CommitTransaction()
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
        GetModuleData(K(0).ToString)
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
