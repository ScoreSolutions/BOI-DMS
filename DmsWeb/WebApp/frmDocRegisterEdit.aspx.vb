Imports Para.TABLE
Imports Para.Common.Utilities
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Para.Common.Utilities.Constant

Partial Class WebApp_frmDocRegisterEdit
    Inherits System.Web.UI.Page


    Private Sub SetDocSecret()
        Dim fnc As New DocSecretEng
        Dim dt As New DataTable
        dt = fnc.GetDataSecretList("active = 'Y'", "secret_code")
        cmbDocSecretID.SetItemList(dt, "secret_name", "secret_code")
        fnc = Nothing
        dt = Nothing
    End Sub
    Private Sub SetDocSpeed()
        Dim fnc As New DocSpeedEng
        Dim dt As New DataTable
        dt = fnc.GetDataSpeedList("active = 'Y' ", "speed_code")
        cmbDocSpeedID.SetItemList(dt, "speed_name", "speed_code")
        dt = Nothing
        fnc = Nothing
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session.Remove(Constant.SessFileUploadList)
            SetAllCombo()

            Dim uPara As New Para.Common.UserProfilePara
            uPara = Config.GetLogOnUser
            cdlOwnerOrgID.SelectedValue = uPara.ORG_DATA.ID
            cdlOwnerStaffID.SelectedValue = uPara.OFFICER_DATA.ID
            uPara = Nothing

            txtCompanyDocNo.Attributes.Add("onBlur", "return CheckCompanyDocNo();")
            If Request("id") IsNot Nothing Then
                FillRegisterData(Request("id"))
            End If
        End If
    End Sub

    Private Sub FillRegisterData(ByVal vID As Long)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim para As New DocumentRegisterPara
        Dim eng As New Engine.Document.DocumentRegisterENG
        para = eng.GetDocumentPara(Request("id"), trans)
        trans.CommitTransaction()

        If para.ID <> 0 Then
            txtID.Text = para.ID
            txtBookNo.Text = para.BOOK_NO
            txtRequestNo.Text = para.REQUEST_NO
            cmbGroupTitle.SelectedValue = para.GROUP_TITLE_ID
            txtTitle.Text = para.TITLE_NAME
            txtReceiveDate.DateValue = para.REGISTER_DATE.Value
            txtExpectDate.DateValue = para.EXPECT_FINISH_DATE.Value
            If txtExpectDate.DateValue.Year <> 1 Then
                txtExpectDate.VisibleImg = False
            End If

            cmbDocSecretID.SelectedValue = para.DOC_SECRET_ID.ToString.PadLeft(3, "0")
            cmbDocSpeedID.SelectedValue = para.DOC_SPEED_ID.ToString.PadLeft(3, "0")
            cdlOwnerOrgID.SelectedValue = para.ORGANIZATION_ID_OWNER
            cdlOwnerStaffID.SelectedValue = para.OFFICER_ID_APPROVE
            txtRemarks.Text = para.REMARKS
            rdiReceiveType.SelectedValue = para.DOCUMENT_RECEIVE_TYPE
            If rdiReceiveType.SelectedValue = "1" Then
                'รับจากหน่วยงานภายใน
                txtCustName.Enabled = False
            End If

            hdnCustValue.Text = para.COMPANY_ID
            txtCustName.Text = para.COMPANY_NAME
            txtCompanyDocSysID.Text = para.COMPANY_DOC_SYS_ID

            If para.COMPANY_DOC_SYS_ID = Constant.CompanySourceType.BOICENTRAL Then
                Dim cEng As New Engine.Master.CompanyEng
                If para.COMPANY_NAME.Trim <> "" Then
                    Dim cDt As New DataTable
                    cDt = eng.GetNOTIFICATIONNO(para.COMPANY_NAME)
                    If cDt.Rows.Count > 0 Then
                        cmbResolutionsNo.SetItemList(cDt, "NOTIFICATIONNO", "Notif")
                    End If

                    cDt = New DataTable
                    cDt = eng.GetCERTIFICATENO(para.COMPANY_NAME)
                    chkCertNo.Items.Clear()
                    If cDt.Rows.Count > 0 Then
                        chkCertNo.DataSource = cDt
                        chkCertNo.DataValueField = "CERT"
                        chkCertNo.DataTextField = "CERTIFICATENO"
                        chkCertNo.DataBind()
                    End If
                End If
                cEng = Nothing
            End If

            txtCompanyDocNo.Text = para.COMPANY_DOC_NO
            txtCompanyDocDate.DateValue = para.COMPANY_DOC_DATE.Value
            txtCompanySignatureName.Text = para.COMPANY_SIGN

            If para.COMPANY_CERT_NO.Trim <> "" Then
                rdiSupportCardNo.Checked = True
                For Each CertNo As String In Split(para.COMPANY_CERT_NO, ",")
                    For i As Integer = 0 To chkCertNo.Items.Count - 1
                        If chkCertNo.Items(i).Value = CertNo Then
                            chkCertNo.Items(i).Selected = True
                        End If
                    Next
                Next

                cmbResolutionsNo.SelectedValue = "0"
                cmbResolutionsNo.Enabled = False
            End If
            If para.COMPANY_NOTIFY_NO.Trim <> "0" Then
                rdiResolutionBookNo.Checked = True
                cmbResolutionsNo.SelectedValue = para.COMPANY_NOTIFY_NO

                chkCertNo.Enabled = False
            End If
            cmbBusinessTypeID.SelectedValue = para.BUSINESS_TYPE_ID
            txtDocRefID.Text = para.ELECTRONIC_DOC_ID
            txtTHeGIFDocID.Text = para.REF_TH_EGIF_DOC_INBOUND_ID
            txtRefDocRegisID.Text = para.REF_DOCUMENT_REGISTER_ID

            Me.Page.Title = "แก้ไขรายละเอียด เลขที่หนังสือ : " & para.BOOK_NO

            eng = Nothing
            para = Nothing
        End If
    End Sub

    Private Sub SetAllCombo()
        Call SetGroupTitle()
        Call SetDocSecret()
        Call SetDocSpeed()
        Call SetBusinessType()
    End Sub

    Private Sub SetGroupTitle()
        Dim eng As New Engine.Master.GroupTitleEng
        Dim dt As New DataTable
        dt = eng.GetDataGroupTitleList("active='Y' and ltrim(group_title_name) <>''", "convert(float,group_title_code)")
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("group_title_name") = "เลือก"
            dr("id") = "0"
            dt.Rows.InsertAt(dr, 0)

            cmbGroupTitle.DataTextField = "group_title_name"
            cmbGroupTitle.DataValueField = "id"
            cmbGroupTitle.DataSource = dt
            cmbGroupTitle.DataBind()
            dt.Dispose()
            dt = Nothing
        End If
        eng = Nothing
    End Sub

    Private Sub SetBusinessType()
        Dim fnc As New CompanyEng
        cmbBusinessTypeID.SetItemList(fnc.GetAllBusinessType, "business_type_name", "id")
        fnc = Nothing
    End Sub

    Public Sub clearfrm()
        txtBookNo.Text = ""
        txtRequestNo.Text = ""
        SetGroupTitle()
        txtTitle.Text = ""
        txtReceiveDate.DateValue = DateTime.Now
        txtExpectDate.DateValue = New Date(1, 1, 1)
        SetAllCombo()
        cdlOwnerOrgID.SelectedValue = Config.GetLogOnUser.ORG_DATA.ID
        cdlOwnerStaffID.SelectedValue = Config.GetLogOnUser.OFFICER_DATA.ID
        txtRemarks.Text = ""
        rdiReceiveType.SelectedIndex = 0 'การลงทะเบียนรับจากภายนอก/ลงทะเบียนรับจากภายใน
        txtCustName.Text = ""
        hdnCustValue.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyDocDate.DateValue = DateTime.Now.Date
        txtCompanySignatureName.Text = ""
        rdiSupportCardNo.Checked = True
        chkCertNo.Items.Clear()
        cmbResolutionsNo.ClearCombo() 'เลขที่หนังสือแจ้งมติ
        txtScanJobID.Text = "0"

        cmbBusinessTypeID.clearval()
        Session.Remove(Constant.SessFileUploadList)
    End Sub

#Region "Validation Data"
    Public Function ValidRegis() As Boolean
        Dim ret As Boolean = True
        If cmbGroupTitle.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกกลุ่มเรื่อง", Me, cmbGroupTitle.ClientID)
        ElseIf txtTitle.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุชื่อเรื่อง", Me, txtTitle.ClientID)
        ElseIf txtReceiveDate.TxtBox.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุวันที่รับ", Me, txtReceiveDate.ClientID)
        ElseIf cmbOwnerOrgID.SelectedValue = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือกหน่วยงานเจ้าของเรื่อง", Me, cmbOwnerOrgID.ClientID)
        ElseIf cmbOwnerStaffID.SelectedValue = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือกผู้พิจารณา", Me, cmbOwnerStaffID.ClientID)
        ElseIf hdnCustValue.Text = "" Then
            ret = False
            Config.SetAlert("กรุณาเลือกชื่อองค์กร", Me, txtCustName.ClientID)
        ElseIf txtCompanyDocDate.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุวันที่หนังสือองค์กร", Me, txtCompanyDocDate.ClientID)
        End If
        If ret = True Then
            Dim gEng As New Engine.Master.GroupTitleEng
            Dim gPara As New Para.TABLE.GroupTitlePara
            gPara = gEng.GetGroupTitlePara(cmbGroupTitle.SelectedValue)
            If gPara.IS_GEN_REQ = "Y" Then
                If cmbBusinessTypeID.SelectedValue = "0" Then
                    ret = False
                    Config.SetAlert("กลุ่มเรื่องคำขอ กรุณาเลือกประเภทกิจการ", Me)
                End If
            End If
            gPara = Nothing
            gEng = Nothing
        End If

        Return ret
    End Function
#End Region


    Public Function SaveDocRegis(ByVal RefDocRegisID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As Para.TABLE.DocumentRegisterPara 'ลงทะเบียน

        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim para As Para.TABLE.DocumentRegisterPara = eng.GetDocumentPara(txtID.Text, trans)

        para.ID = txtID.Text
        para.REQUEST_NO = txtRequestNo.Text
        para.BOOK_NO = txtBookNo.Text
        para.GROUP_TITLE_ID = cmbGroupTitle.SelectedValue
        para.TITLE_NAME = txtTitle.Text
        para.REGISTER_DATE = txtReceiveDate.DateValue
        para.EXPECT_FINISH_DATE = txtExpectDate.DateValue
        para.DOC_SECRET_ID = cmbDocSecretID.SelectedValue
        para.DOC_SPEED_ID = cmbDocSpeedID.SelectedValue
        para.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobRemain   'งานค้าง

        Dim oEng As New Engine.Master.OrganizationEng
        Dim oPara As Para.TABLE.OrganizationPara = oEng.GetOrgPara(cmbOwnerOrgID.SelectedValue)
        para.ORGANIZATION_ID_OWNER = oPara.ID
        para.ORGANIZATION_NAME = oPara.ORG_NAME
        para.ORGANIZATION_APPNAME = oPara.NAME_ABB

        para.ORGANIZATION_ID_PROCESS = oPara.ID
        para.ORGANIZATION_NAME_PROCESS = oPara.ORG_NAME
        para.ORGANIZATION_ABBNAME_PROCESS = oPara.NAME_ABB

        Dim sEng As New Engine.Master.OfficerEng
        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(cmbOwnerStaffID.SelectedValue)
        para.OFFICER_ID_APPROVE = sPara.ID
        para.OFFICER_NAME = cmbOwnerStaffID.SelectedItem.Text
        para.OFFICER_ORGANIZATION_ID = sPara.ORGANIZATION_ID
        para.OFFICER_ID_POSSESS = sPara.ID
        para.OFFICER_NAME_POSSESS = cmbOwnerStaffID.SelectedItem.Text
        para.ADMINISTRATION_TYPE = "1"
        para.REMARKS = txtRemarks.Text
        para.DOCUMENT_RECEIVE_TYPE = rdiReceiveType.SelectedValue
        sEng = Nothing
        sPara = Nothing

        'Set Compary ที่เป็นข้อมูลที่มาจากแต่ละที่
        If rdiReceiveType.SelectedValue = "0" Then
            'ลงทะเบียนรับจากหน่วยงานภายนอก
            para.COMPANY_DOC_SYS_ID = IIf(txtCompanyDocSysID.Text <> "", txtCompanyDocSysID.Text, "DMS")
            para.COMPANY_ID = hdnCustValue.Text

            If txtCustName.Text.IndexOf(Constant.CompanySourceType.BOICENTRAL) > 0 Then
                para.COMPANY_NAME = txtCustName.Text.Replace("(" & Constant.CompanySourceType.BOICENTRAL & ")", "")
            Else
                para.COMPANY_NAME = txtCustName.Text.Replace("(" & Constant.CompanySourceType.DMS & ")", "")
            End If
        Else
            'ลงทะเบียนรับจากหน่วยงานภายใน
            Dim cEng As New Engine.Master.CompanyEng
            Dim cPara As Para.TABLE.CompanyPara = cEng.GetCompanyPara(hdnCustValue.Text)
            If cPara.ID <> 0 Then
                para.COMPANY_ID = cPara.ID
                para.COMPANY_NAME = cPara.THAINAME
            End If
            cEng = Nothing
            cPara = Nothing
        End If

        para.COMPANY_DOC_NO = txtCompanyDocNo.Text
        para.COMPANY_DOC_DATE = txtCompanyDocDate.DateValue
        para.COMPANY_SIGN = txtCompanySignatureName.Text
        para.COMPANY_SIGN_DATE = txtCompanyDocDate.DateValue
        para.BUSINESS_TYPE_ID = cmbBusinessTypeID.SelectedValue

        para.USERNAME_REGISTER = Config.GetLogOnUser.UserName
        para.ORGANIZATION_ID_REGISTER = Config.GetLogOnUser.ORG_DATA.ID
        para.DOCUMENT_RECEIVE_TYPE = rdiReceiveType.SelectedValue
        para.REF_DOCUMENT_REGISTER_ID = RefDocRegisID
        para.COMPANY_CERT_NO = GetSelectedCertNo()
        para.COMPANY_NOTIFY_NO = cmbResolutionsNo.SelectedValue
        para.ELECTRONIC_DOC_ID = txtDocRefID.Text
        para.REF_TH_EGIF_DOC_INBOUND_ID = txtTHeGIFDocID.Text

        Dim _ID As Long = eng.SaveDocumentRegister(Config.GetLogOnUser.UserName, para, Session(Constant.SessFileUploadList), txtScanJobID.Text, trans)
        If _ID > 0 Then
            para.ID = _ID
        End If
        eng = Nothing
        Return para
    End Function

    Private Function GetSelectedCertNo() As String
        Dim ret As String = ""
        For Each rdi As ListItem In chkCertNo.Items
            If rdi.Selected = True Then
                If ret = "" Then
                    ret = rdi.Value
                Else
                    ret += "," & rdi.Value
                End If
            End If
        Next
        Return ret
    End Function

    Protected Sub btnSetCert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetCert.Click
        If hdnCustValue.Text.Trim <> "" Then
            Dim dt As New DataTable
            Dim eng As New Engine.Document.DocumentRegisterENG
            Dim cEng As New Engine.Master.CompanyEng
            Dim cPara As New Para.TABLE.CompanyPara
            cPara = cEng.GetCompanyPara(hdnCustValue.Text)
            dt = eng.GetNOTIFICATIONNO(cPara.ENGNAME)
            cmbResolutionsNo.ClearCombo()
            If dt.Rows.Count > 0 Then
                cmbResolutionsNo.SetItemList(dt, "NOTIFICATIONNO", "Notif")
            End If

            dt = New DataTable
            dt = eng.GetCERTIFICATENO(cPara.ENGNAME)
            chkCertNo.Items.Clear()
            If dt.Rows.Count > 0 Then
                chkCertNo.DataSource = dt
                chkCertNo.DataValueField = "CERT"
                chkCertNo.DataTextField = "CERTIFICATENO"
                chkCertNo.DataBind()
            End If

            dt.Dispose()
            dt = Nothing
            eng = Nothing
            cEng = Nothing
            cPara = Nothing
        End If
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidRegis() = True Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If SaveDocRegis(txtRefDocRegisID.Text, trans).ID <> 0 Then
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
                trans.CommitTransaction()
                Config.SaveTransLog("บันทึกการแก้ไขข้อมูลเลขที่ :" & txtBookNo.Text & " ชื่อเรื่อง :" & txtTitle.Text, Config.GetLogOnUser.LOGIN_HISTORY_ID)
            Else
                Config.SetAlert("เกิดความผิดพลาดในขณะแก้ไขข้อมูล ไม่สามารถบันทึกข้อมูลได้", Me)
                trans.RollbackTransaction()
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        FillRegisterData(txtID.Text)
    End Sub
End Class
