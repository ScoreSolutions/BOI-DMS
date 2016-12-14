Imports System.Data
Imports Engine.Document.DocumentRegisterENG

Partial Class WebApp_frmDocChangeBookOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.Title = ctlDocBookDetailShow1.PageTitle

        End If
    End Sub


    Private Function Valid() As Boolean
        If cmbBookOutNo.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือส่งออก", Me, cmbBookOutNo.ClientID)
            Return False
        End If

        'ต้องมีการทำรายการด้วย เช่น เลือกชื่อบริษัท หรือ เลือกชื่อหน่วยงาน
        'ไม่สามารถเป็นค่าว่างทั้งหมดได้
        If txtCompanyID.Text.Trim = "" And txtNewBookNo.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุเลขทะเบียนบริษัทหรือเลขที่หนังสือ", Me, txtCompanyID.ClientID)
            Return False
        End If

        Return True
    End Function

    Private Sub ClearForm()
        cmbBookOutNo.SelectedValue = "0"
        txtCompanyID.Text = ""
        'cdlSendOrgID.SelectedValue = lblSendOrgID.Text
        txtCustName.Text = ""
        hdnCustValue.Text = ""
        txtNewBookNo.Text = ""
        lblNewDocumentRegisterID.Text = "0"
    End Sub

    Protected Sub btnSearchDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDoc.Click
        ctlDocBookDetailShow1.SearchBookNoForChangeCompany(txtSearchBookNo.Text.Trim)
        If ctlDocBookDetailShow1.DocID > "0" Then
            SetCmbBookOut()

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.DocumentRegisterPara
            Dim eng As New Engine.Document.DocumentRegisterENG
            para = eng.GetDocumentParaByBookNo(txtSearchBookNo.Text.Trim, trans)
            If para.ID > 0 Then
                'cdlSendOrgID.SelectedValue = para.ORGANIZATION_ID_OWNER
                'lblSendOrgID.Text = para.ORGANIZATION_ID_OWNER
            End If
            trans.CommitTransaction()
        End If
    End Sub

    Private Sub SetCmbBookOut()
        Dim dt As DataTable = GetBookOutTable(ctlDocBookDetailShow1.DocID)
        If dt.Rows.Count > 0 Then
            cmbBookOutNo.SetItemList(dt, "bookout_no", "id")
        End If

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Valid() = False Then
            Exit Sub
        End If

        Dim dt As New DataTable
        dt.Columns.Add("book_no")
        dt.Columns.Add("company_id")
        dt.Columns.Add("company_name")
        dt.Columns.Add("company_regis_no")
        dt.Columns.Add("bookout_no")
        Dim dr As DataRow = dt.NewRow

        dr("book_no") = txtNewBookNo.Text
        dr("company_id") = hdnCustValue.Text
        dr("company_name") = txtCustName.Text
        dr("company_regis_no") = txtCompanyID.Text
        dr("bookout_no") = cmbBookOutNo.SelectedText
        dt.Rows.Add(dr)

        gvComfirmChangeList.DataSource = dt
        gvComfirmChangeList.DataBind()

        zPopConfirm.Show()

    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq
        lnq.GetDataByPK(cmbBookOutNo.SelectedValue, trans.Trans)
        If lnq.ID > 0 Then
            If txtCompanyID.Text.Trim <> "" And txtNewBookNo.Text.Trim <> "" Then
                'New Company and Now Bookno
                Dim cmEng As New Engine.Master.CompanyEng
                Dim cmPara As Para.TABLE.CompanyPara = cmEng.GetCompanyParaByComID(txtCompanyID.Text, trans)
                lnq.COMPANY_ID_RECEIVE = cmPara.ID
                lnq.COMPANY_NAME_RECEIVE = cmPara.THAINAME
                lnq.DOCUMENT_REGISTER_ID = lblNewDocumentRegisterID.Text
            ElseIf txtCompanyID.Text.Trim <> "" Then
                'New Company Only
                Dim cmEng As New Engine.Master.CompanyEng
                Dim cmPara As Para.TABLE.CompanyPara = cmEng.GetCompanyParaByComID(txtCompanyID.Text, trans)
                lnq.COMPANY_ID_RECEIVE = cmPara.ID
                lnq.COMPANY_NAME_RECEIVE = cmPara.THAINAME
            ElseIf txtNewBookNo.Text.Trim <> "" Then
                'New Bookno Only
                lnq.DOCUMENT_REGISTER_ID = lblNewDocumentRegisterID.Text
            End If

            'Update to New Information
            If lnq.UpdateByPK(uPara.UserName, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                Config.SetAlert(lnq.ErrorMessage, Me, txtNewBookNo.ClientID)
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Else
            trans.RollbackTransaction()
        End If

        ClearForm()
        ctlDocBookDetailShow1.SearchBookNoForChangeCompany(txtSearchBookNo.Text)
        zPopConfirm.Hide()
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        ClearForm()
        zPopConfirm.Hide()
    End Sub

    Protected Sub txtNewBookNo_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewBookNo.TextChange
        'Document
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim para As New Para.TABLE.DocumentRegisterPara
        Dim eng As New Engine.Document.DocumentRegisterENG
        para = eng.GetDocumentParaByBookNo(txtNewBookNo.Text.Trim, trans)
        If para.ID > 0 Then
            lblNewDocumentRegisterID.Text = para.ID
        Else
            Config.SetAlert("ไม่พบเลขที่หนังสือที่ต้องการ", Me, txtNewBookNo.ClientID)
        End If
        para = Nothing
        eng = Nothing
        trans.CommitTransaction()
    End Sub
End Class
