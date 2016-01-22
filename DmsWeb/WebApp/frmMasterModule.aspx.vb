Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data

Partial Class WebApp_frmMasterModule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    
    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกรหัส"
        ElseIf txtOrder.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกลำดับ"
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกชื่อ"
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกรายละเอียด"
        ElseIf txtTooltip.Text.Trim = "" Then
            ret = False
            sys_msg.Text = "กรุณากรอกคำอธิบาย"
        ElseIf txtID.Text.Trim = "0" Then

            'If FileUpload1.PostedFile Is Nothing OrElse String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) OrElse FileUpload1.PostedFile.InputStream Is Nothing Then
            '    ret = False
            '    sys_msg.Text = "กรุณาเลือกไอคอน"
            'End If

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
        txtDescription.Text = ""
        txtTooltip.Text = ""
        txtOrder.Text = ""
        chkActive.Checked = False
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPath As String = "../Images/Module/"
        If ValidateData() = True Then

            'Dim trans As New DbTrans
            'trans.CreateTransaction()

            'Dim para As New ModulePara
            'para.ID = Convert.ToInt64(txtID.Text)
            'para.MODULE_CODE = txtCode.Text
            'para.MODULE_NAME = txtName.Text
            'para.MODULE_TOOLSTIP = txtTooltip.Text
            'para.MODULE_DESC = txtDescription.Text
            'para.ORDER_SEQ = txtOrder.Text

            'If chkActive.Checked = True Then
            '    para.ACTIVE = "Y"
            'Else
            '    para.ACTIVE = "N"
            'End If

            'If FileUpload1.HasFile Then
            '    Dim MIMEType As String
            '    MIMEType = Config.getMIMEType(FileUpload1.PostedFile.FileName)
            '    para.MODULE_ICON = strPath + txtCode.Text + MIMEType
            'End If




            'Dim fnc As New ModuleEng
            'If fnc.SaveModule(para, "Admin", trans) = True Then
            '    trans.CommitTransaction()
            '    GetModuleData(fnc.ID)

            '    If FileUpload1.HasFile Then
            '        Config.UploadFile(FileUpload1, txtCode.Text, Server.MapPath(strPath))
            '    End If

            '    SetGridview(True)
            '    ClearData()
            '    Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            'Else
            '    trans.RollbackTransaction()
            '    Config.SetAlert(fnc.ErrorMessage, Me)
            'End If

            sqltmp = "update MODULE set "
            sqltmp = sqltmp + " module_code = '" + txtCode.Text + "'"
            sqltmp = sqltmp + ",module_name = '" + txtName.Text + "'"
            sqltmp = sqltmp + ",module_toolstip = '" + txtTooltip.Text + "'"
            sqltmp = sqltmp + ",module_desc = '" + txtDescription.Text + "'"

            If FileUpload1.HasFile Then sqltmp = sqltmp + ",module_icon = '" + strPath + FileUpload1.FileName + "'"

            sqltmp = sqltmp + ",order_seq = '" + txtOrder.Text + "'"
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
            sqltmp = "insert into MODULE ("
            sqltmp = sqltmp + " module_code"
            sqltmp = sqltmp + ",module_name"
            sqltmp = sqltmp + ",module_desc"
            sqltmp = sqltmp + ",module_toolstip"
            sqltmp = sqltmp + ",module_icon"
            sqltmp = sqltmp + ",order_seq"
            sqltmp = sqltmp + ",active"
            sqltmp = sqltmp + ",create_by"
            sqltmp = sqltmp + ",create_on"
            sqltmp = sqltmp + ") values ("
            sqltmp = sqltmp + " '" + txtCode.Text + "'"
            sqltmp = sqltmp + ",'" + txtName.Text + "'"
            sqltmp = sqltmp + ",'" + txtDescription.Text + "'"
            sqltmp = sqltmp + ",'" + txtTooltip.Text + "'"

            If FileUpload1.HasFile Then
                sqltmp = sqltmp + ",'" + strPath + FileUpload1.FileName + "'"
            Else
                sqltmp = sqltmp + ",''"
            End If

            sqltmp = sqltmp + ",'" + txtOrder.Text + "'"

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

        sqltmp = "DELETE FROM MODULE WHERE id=" + lbl.Text

        popup1.Show()
    End Sub

    Protected Sub btnYes1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes1.Click
        sql_data(sqltmp)
        SetGridview(True)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim row As GridViewRow = GridView1.Rows(e.NewEditIndex)
        Dim lbl As Label = row.FindControl("lblid")

        GetModuleData(lbl.Text)
    End Sub
End Class
