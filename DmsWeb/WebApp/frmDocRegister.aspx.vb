Imports Para.TABLE
Imports Para.Common.Utilities
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Para.Common.Utilities.Constant

Partial Class WebApp_frmDocRegister
    Inherits System.Web.UI.Page

    Private Sub SetDocSecret()
        Dim fnc As New DocSecretEng
        cmbDocSecretID.SetItemList(fnc.GetDataSecretList("active = 'Y'", "secret_code"), "secret_name", "secret_code")
    End Sub
    Private Sub SetDocSpeed()
        Dim fnc As New DocSpeedEng
        cmbDocSpeedID.SetItemList(fnc.GetDataSpeedList("active = 'Y' ", "speed_code"), "speed_name", "speed_code")
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
            If uPara.LOGIN_HISTORY_ID = 0 Then
                Response.Redirect("../WebApp/frmSessionExpire.aspx")
                Exit Sub
            End If

            'Session.Remove(SessSendList)
            Session.Remove(Constant.SessFileUploadList)
            'Session.Remove(Constant.SessCompanyListFromBCM)
            SetAllCombo()

            cdlOwnerOrgID.SelectedValue = uPara.ORG_DATA.ID
            cdlOwnerStaffID.SelectedValue = uPara.OFFICER_DATA.ID
            cdlReceiveOrgID.SelectedValue = uPara.ORG_DATA.ID
            cdlReceiveStaffID.SelectedValue = uPara.OFFICER_DATA.ID
            uPara = Nothing

            'cmbOwnerOrgID.Attributes.Add("onchange", "BindOrgIDChange('" & cmbOwnerOrgID.ClientID & "','" & cmbOwnerStaffID.ClientID & "');")
            'cmbReceiveOrgID.Attributes.Add("onchange", "BindOrgIDChange('" & cmbReceiveOrgID.ClientID & "','" & cmbReceiveStaffID.ClientID & "');")
            txtCompanyDocNo.Attributes.Add("onBlur", "return CheckCompanyDocNo();")
            txtCompanyID.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")


            If Request("RefDocID") IsNot Nothing Then
                SetRefElecDoc(Request("RefDocID"))
            ElseIf Request("THeGIFDocID") IsNot Nothing Then
                SetTHeGIFDoc(Convert.ToInt64(Request("THeGIFDocID")))
            End If
            uPara = Nothing
        End If
    End Sub

    Private Sub SetTHeGIFDoc(ByVal DocID As Long)
        Dim pPar As New Para.TABLE.ThEgifDocInboundPara
        pPar = Engine.WebService.THeGIFENG.GetDocDetail(DocID)

        txtTHeGIFDocID.Text = DocID
        txtTitle.Text = pPar.BODY_SUBJECT
        If pPar.BODY_SECRET_CODE.Trim <> "" Then
            cmbDocSecretID.SelectedValue = pPar.BODY_SECRET_CODE
        End If
        If pPar.BODY_SPEED_CODE.Trim <> "" Then
            cmbDocSpeedID.SelectedValue = pPar.BODY_SPEED_CODE
        End If
        rdiReceiveType.SelectedValue = "0"    'เอกสารรับจากภายนอก

        Dim cRet As String()
        Dim mEng As New Engine.Master.CompanyEng
        cRet = mEng.GetCompanyNameByTHeGIFCode(pPar.SENDER_DEPARTMENT_ORGANIZATION_ID)
        hdnCustValue.Text = cRet(0)
        txtCustName.Text = cRet(1)
        txtCompanyDocNo.Text = pPar.BODY_ID
        txtCompanyDocDate.DateValue = Engine.WebService.THeGIFENG.SetFormatDate(pPar.BODY_CORRESPONDENCE_DATE)
        mEng = Nothing
        cRet = Nothing

        If pPar.SIGNER_GIVEN_NAME.Trim <> "" Then
            txtCompanySignatureName.Text = pPar.SIGNER_GIVEN_NAME & " " & pPar.SIGNER_FAMILY_NAME
        End If

        Dim i As Integer = 0
        Dim fDt As New DataTable
        If pPar.MAIN_LETTER_MIME.Trim <> "" Then
            fDt = Engine.Document.DocumentRegisterENG.BuildFileUploadListDT()
            Dim fdr As DataRow = fDt.NewRow
            fdr("no") = (i + 1).ToString
            fdr("description") = "-"
            fdr("mime_type") = Engine.WebService.THeGIFENG.GetMimeType(pPar.MAIN_LETTER_MIME)
            fdr("file_byte") = Convert.FromBase64String(pPar.MAIN_LETTER_DATABASE64)
            fdr("id") = "0"
            fdr("document_register_id") = "0"
            fDt.Rows.Add(fdr)

            Session(Constant.SessFileUploadList) = fDt
            i += 1
        End If

        If pPar.CHILD_TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id.Rows.Count > 0 Then
            If Session(Constant.SessFileUploadList) Is Nothing Then
                fDt = Engine.Document.DocumentRegisterENG.BuildFileUploadListDT()
            End If
            For Each dr As DataRow In pPar.CHILD_TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id.Rows
                Dim fdr As DataRow = fDt.NewRow
                fdr("no") = (i + 1).ToString
                fdr("description") = "-"
                fdr("mime_type") = Engine.WebService.THeGIFENG.GetMimeType(dr("mime_code"))
                fdr("file_byte") = Convert.FromBase64String(dr("base64data").ToString)
                fdr("id") = "0"
                fdr("document_register_id") = "0"
                fdr("create_by") = "THeGIF"
                fdr("IsDel") = "N"
                fDt.Rows.Add(fdr)
                i += 1
            Next
            Session(Constant.SessFileUploadList) = fDt
        End If

        pPar = Nothing
    End Sub

    Private Sub SetRefElecDoc(ByVal DocID As String)
        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim dt As New DataTable
        dt = eng.GetElecDocDT(DocID)
        eng = Nothing

        txtDocRefID.Text = DocID
        txtTitle.Text = dt.Rows(0)("doc_title").ToString
        If Convert.IsDBNull(dt.Rows(0)("doc_secret")) = False Then cmbDocSecretID.SelectedValue = dt.Rows(0)("doc_secret").ToString
        If Convert.IsDBNull(dt.Rows(0)("doc_speed")) = False Then cmbDocSpeedID.SelectedValue = dt.Rows(0)("doc_speed").ToString
        rdiReceiveType.SelectedValue = "1"    'เอกสารรับจากภายใน

        Dim cRet As String()
        Dim mEng As New Engine.Master.CompanyEng
        cRet = mEng.GetCompanyNameByOrgID(Config.GetLogOnUser.ORG_DATA.ID)
        hdnCustValue.Text = cRet(0)
        txtCustName.Text = cRet(1)
        txtCompanyDocDate.DateValue = DateTime.Now

        If Convert.IsDBNull(dt.Rows(0)("doc_officeSign")) = False Then
            'Dim oEng As New Engine.Master.OfficerEng
            'Dim oPara As New Para.TABLE.OfficerPara
            'oPara = oEng.GetOfficerParaByUserName(dt.Rows(0)("doc_officeSign").ToString)
            txtCompanySignatureName.Text = dt.Rows(0)("doc_officeSign")
            'oEng = Nothing
            'oPara = Nothing
        End If
        dt = Nothing
    End Sub

    Private Function ValidAdd() As Boolean
        Dim ret As Boolean = True
        If cmbReceiveOrgID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกหน่วยงานผู้รับ", Me)
            ret = False
        ElseIf cmbReceiveStaffID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกเจ้าหน้าที่รับ", Me)
            ret = False
        ElseIf cmbPurpose.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกวัตถุประสงค์", Me)
            ret = False
        End If

        Return ret
    End Function
    Private Function BuiltSendList() As DataTable
        Dim dtimp As New DataTable()
        dtimp.Columns.Add(New DataColumn("OrgNameReceiveID", GetType(String)))
        dtimp.Columns.Add(New DataColumn("StaffNameReceiveID", GetType(String)))
        dtimp.Columns.Add(New DataColumn("PurposeID", GetType(String)))
        dtimp.Columns.Add(New DataColumn("remark_receive", GetType(String)))
        dtimp.Columns.Add(New DataColumn("OrgNameReceive", GetType(String)))
        dtimp.Columns.Add(New DataColumn("OrgAbbNameReceive", GetType(String)))
        dtimp.Columns.Add(New DataColumn("StaffNameReceive", GetType(String)))
        dtimp.Columns.Add(New DataColumn("Purpose", GetType(String)))
        Return dtimp
    End Function

    Private Const ColStaffNameReceiveID As Int16 = 7
    Private Const ColStaffNameReceive As Int16 = 1
    Private Const ColOrgNameReceiveID As Int16 = 6
    Private Const ColOrgNameReceive As Int16 = 0
    Private Const ColOrgAbbNameReceive As Int16 = 8
    Private Const ColPurposeID As Int16 = 5
    Private Const ColPurpose As Int16 = 2
    Private Const Colremark_receive As Int16 = 3

    Private Function GetSendList() As DataTable
        Dim dt As New DataTable
        dt = BuiltSendList()
        If gvSendList.Rows.Count > 0 Then
            For Each grv As GridViewRow In gvSendList.Rows
                Dim dr As DataRow = dt.NewRow
                dr("StaffNameReceiveID") = grv.Cells(ColStaffNameReceiveID).Text
                dr("StaffNameReceive") = grv.Cells(ColStaffNameReceive).Text
                dr("OrgNameReceiveID") = grv.Cells(ColOrgNameReceiveID).Text
                dr("OrgNameReceive") = grv.Cells(ColOrgNameReceive).Text
                dr("OrgAbbNameReceive") = grv.Cells(ColOrgAbbNameReceive).Text
                dr("PurposeID") = grv.Cells(ColPurposeID).Text
                dr("Purpose") = grv.Cells(ColPurpose).Text
                dr("remark_receive") = grv.Cells(Colremark_receive).Text.Replace("&nbsp;", "")

                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If ValidAdd() = True Then
            'Dim dt As New DataTable
            'If Session(SessSendList) Is Nothing Then
            '    dt = BuiltSendList()
            'Else
            '    dt = DirectCast(Session(SessSendList), DataTable)
            'End If

            'Dim rEng As New Engine.Master.OrganizationEng
            'Dim rPara As Para.TABLE.OrganizationPara = rEng.GetOrgPara(cmbReceiveOrgID.SelectedValue)
            'Dim dr As DataRow = dt.NewRow
            'If cmbReceiveStaffID.SelectedValue <> "0" Then
            '    dr("StaffNameReceiveID") = cmbReceiveStaffID.SelectedValue
            '    dr("StaffNameReceive") = cmbReceiveStaffID.SelectedItem.Text
            'End If
            'dr("OrgNameReceiveID") = rPara.ID
            'dr("OrgNameReceive") = rPara.ORG_THAI_NAME
            'dr("OrgAbbNameReceive") = rPara.NAME_RECEIVE
            'dr("PurposeID") = cmbPurpose.SelectedValue
            'dr("Purpose") = cmbPurpose.SelectedText
            'dr("remark_receive") = txtMessage.Text
            'dt.Rows.Add(dr)
            'rEng = Nothing
            'rPara = Nothing
            'If dt.Rows.Count > 0 Then
            '    gvSendList.Visible = True
            '    gvSendList.DataSource = dt
            '    gvSendList.DataBind()
            '    Session(SessSendList) = dt
            'Else
            '    gvSendList.Visible = False
            '    gvSendList.DataSource = Nothing
            '    gvSendList.DataBind()
            '    Session(SessSendList) = Nothing
            'End If
            'Config.SaveTransLog("frmDocumentRegister.aspx คลิกปุ่มเพิ่ม")
            'ClearSendForm()


            Dim dt As New DataTable
            dt = GetSendList()

            Dim rEng As New Engine.Master.OrganizationEng
            Dim rPara As Para.TABLE.OrganizationPara = rEng.GetOrgPara(cmbReceiveOrgID.SelectedValue)
            Dim dr As DataRow = dt.NewRow
            If cmbReceiveStaffID.SelectedValue <> "0" Then
                dr("StaffNameReceiveID") = cmbReceiveStaffID.SelectedValue
                dr("StaffNameReceive") = cmbReceiveStaffID.SelectedItem.Text
            End If
            dr("OrgNameReceiveID") = rPara.ID
            dr("OrgNameReceive") = rPara.ORG_THAI_NAME
            dr("OrgAbbNameReceive") = rPara.NAME_RECEIVE
            dr("PurposeID") = cmbPurpose.SelectedValue
            dr("Purpose") = cmbPurpose.SelectedText
            dr("remark_receive") = txtMessage.Text
            dt.Rows.Add(dr)
            rEng = Nothing
            rPara = Nothing
            If dt.Rows.Count > 0 Then
                gvSendList.Visible = True
                gvSendList.DataSource = dt
                gvSendList.DataBind()
                'Session(SessSendList) = dt
            Else
                gvSendList.Visible = False
                gvSendList.DataSource = Nothing
                gvSendList.DataBind()
                'Session(SessSendList) = Nothing
            End If
            Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มเพิ่ม")
            ClearSendForm(uPara)
            dt.Dispose()
        End If
        uPara = Nothing
    End Sub
    Private Sub ClearSendForm(ByVal uPara As Para.Common.UserProfilePara)
        SetPurpose()
        cdlReceiveOrgID.SelectedValue = uPara.ORG_DATA.ID
        cdlReceiveStaffID.SelectedValue = ""
        txtMessage.Text = ""
    End Sub
    Private Sub SetAllCombo()
        Call SetGroupTitle()
        Call SetDocSecret()
        Call SetDocSpeed()
        Call SetBusinessType()
        Call SetPurpose()
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
    Private Sub SetPurpose()
        Dim fnc As New Objective
        cmbPurpose.SetItemList(fnc.GetAllObjectiveTable, "objective_name", "id")
        fnc = Nothing
    End Sub

    Private Sub SetBusinessType()
        Dim fnc As New CompanyEng
        cmbBusinessTypeID.SetItemList(fnc.GetActiveBusinessType, "business_type_name", "id")
        fnc = Nothing
    End Sub
    
    Public Sub clearfrm(ByVal uPara As Para.Common.UserProfilePara)
        txtBookNo.Text = ""
        txtRequestNo.Text = ""
        SetGroupTitle()
        txtTitle.Text = ""
        txtReceiveDate.DateValue = DateTime.Now
        txtExpectDate.DateValue = New Date(1, 1, 1)
        SetAllCombo()
        cdlOwnerOrgID.SelectedValue = uPara.ORG_DATA.ID
        cdlOwnerStaffID.SelectedValue = uPara.OFFICER_DATA.ID
        cdlReceiveOrgID.SelectedValue = uPara.ORG_DATA.ID
        cdlReceiveStaffID.SelectedValue = uPara.OFFICER_DATA.ID
        txtRemarks.Text = ""
        rdiReceiveType.SelectedIndex = 0 'การลงทะเบียนรับจากภายนอก/ลงทะเบียนรับจากภายใน
        txtCompanyID.Text = ""
        txtCompanyIDCardNo.Text = ""
        txtCompanyPassportNo.Text = ""
        txtCustName.Text = ""
        hdnCustValue.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyDocDate.DateValue = DateTime.Now.Date
        txtCompanySignatureName.Text = ""
        rdiSupportCardNo.Checked = True
        'cmbPromoteNo.ClearCombo() 'เลขที่บัตรส่งเสริม
        chkCertNo.Items.Clear()
        cmbResolutionsNo.ClearCombo() 'เลขที่หนังสือแจ้งมติ
        txtScanJobID.Text = "0"

        ClearSendForm(uPara)
        cmbBusinessTypeID.clearval()
        Session.Remove(Constant.SessFileUploadList)
        uPara = Nothing
    End Sub
    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มเคลียร์")
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        Call clearfrm(uPara)
        uPara = Nothing
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
            'ElseIf txtCompanyDocNo.Text.Trim = "" Then
            '    ret = False
            '    Config.SetAlert("กรุณาระบุเลขที่หนังสือองค์กร", Me, txtCompanyDocNo.ClientID)
        ElseIf txtCompanyDocDate.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุวันที่หนังสือองค์กร", Me, txtCompanyDocDate.ClientID)
            'ElseIf txtCompanySignatureName.Text.Trim = "" Then
            '    ret = False
            '    Config.SetAlert("กรุณาระบุชื่อผู้ลงนาม", Me, txtCompanySignatureName.ClientID)
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

    Private Function ValidCloseJob() As Boolean
        Dim ret As Boolean = True
        If gvSendList.Rows.Count = 0 Then
            ret = False
            Config.SetAlert("กรุณาระบุหน่วยงานที่รับ", Me)
        ElseIf gvSendList.Rows.Count > 1 Then
            ret = False
            Config.SetAlert("กรุณาระบุชื่อผู้รับต้นเรื่องเพียง 1 รายการ", Me)
        End If
        Return ret
    End Function

    Private Function ValidInsideSend(ByVal dt As DataTable) As Boolean
        Dim ret As Boolean = True
        If dt.Rows.Count = 0 Then
            ret = False
            Config.SetAlert("กรุณาระบุหน่วยงานที่รับ", Me)
        End If
        Return ret
    End Function
#End Region


    Public Function InsertDocRegis(ByVal RefDocRegisID As Long, ByVal RefDocRegisBookNo As String, ByVal ReceiveAbbName As String, ByVal SendType As String, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) As Para.TABLE.DocumentRegisterPara
        'ลงทะเบียน
        Dim para As New Para.TABLE.DocumentRegisterPara

        para.BOOK_NO = DateTime.Now.ToString("yyyyMMddHHmmssffff")  'Temp Data Record
        para.GROUP_TITLE_ID = cmbGroupTitle.SelectedValue
        para.TITLE_NAME = txtTitle.Text
        para.REGISTER_DATE = txtReceiveDate.DateValue
        para.EXPECT_FINISH_DATE = txtExpectDate.DateValue
        para.DOC_SECRET_ID = cmbDocSecretID.SelectedValue
        para.DOC_SPEED_ID = cmbDocSpeedID.SelectedValue
        para.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobIncome

        Dim oEng As New Engine.Master.OrganizationEng
        Dim oPara As Para.TABLE.OrganizationPara = oEng.GetOrgPara(cmbOwnerOrgID.SelectedValue, trans)
        para.ORGANIZATION_ID_OWNER = oPara.ID
        para.ORGANIZATION_NAME = oPara.ORG_NAME
        para.ORGANIZATION_APPNAME = oPara.NAME_ABB

        para.ORGANIZATION_ID_PROCESS = oPara.ID
        para.ORGANIZATION_NAME_PROCESS = oPara.ORG_NAME
        para.ORGANIZATION_ABBNAME_PROCESS = oPara.NAME_ABB
        oPara = Nothing
        oEng = Nothing

        Dim sEng As New Engine.Master.OfficerEng
        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(cmbOwnerStaffID.SelectedValue, trans)
        para.OFFICER_ID_APPROVE = sPara.ID
        para.OFFICER_NAME = cmbOwnerStaffID.SelectedItem.Text
        para.OFFICER_ORGANIZATION_ID = sPara.ORGANIZATION_ID
        para.OFFICER_ID_POSSESS = sPara.ID
        para.OFFICER_NAME_POSSESS = cmbOwnerStaffID.SelectedItem.Text
        para.ADMINISTRATION_TYPE = "1"
        para.REMARKS = txtRemarks.Text
        sEng = Nothing
        sPara = Nothing

        'Set Compary ที่เป็นข้อมูลที่มาจากแต่ละที่
        para.COMPANY_REGIS_NO = txtCompanyID.Text.Trim
        para.COMPANY_IDCARD_NO = txtCompanyIDCardNo.Text.Trim
        para.COMPANY_PASSPORT_NO = txtCompanyPassportNo.Text.Trim
        para.COMPANY_NAME = txtCustName.Text
        If rdiReceiveType.SelectedValue = "0" Then
            'ลงทะเบียนรับจากหน่วยงานภายนอก
            If txtCustName.Text.IndexOf(Constant.CompanySourceType.BOICENTRAL) > 0 Then
                'Company มาจาก BOICENTRAL
                para.COMPANY_DOC_SYS_ID = Constant.CompanySourceType.BOICENTRAL
                para.COMPANY_NAME = txtCustName.Text.Replace("(" & Constant.CompanySourceType.BOICENTRAL & ")", "")
            Else
                'Company มาจาก DMS
                para.COMPANY_DOC_SYS_ID = Constant.CompanySourceType.DMS
                para.COMPANY_NAME = txtCustName.Text.Replace("(" & Constant.CompanySourceType.DMS & ")", "")
            End If
            para.COMPANY_ID = hdnCustValue.Text.Trim
        Else
            'ลงทะเบียนรับจากหน่วยงานภายใน
            Dim cEng As New Engine.Master.CompanyEng
            Dim cPara As Para.TABLE.CompanyPara = cEng.GetCompanyPara(hdnCustValue.Text, trans)
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

        para.USERNAME_REGISTER = uPara.UserName
        para.ORGANIZATION_ID_REGISTER = uPara.ORG_DATA.ID
        para.DOCUMENT_RECEIVE_TYPE = rdiReceiveType.SelectedValue
        para.REF_DOCUMENT_REGISTER_ID = RefDocRegisID
        para.COMPANY_CERT_NO = GetSelectedCertNo()
        para.COMPANY_NOTIFY_NO = cmbResolutionsNo.SelectedValue
        para.ELECTRONIC_DOC_ID = txtDocRefID.Text
        para.REF_TH_EGIF_DOC_INBOUND_ID = txtTHeGIFDocID.Text

        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim _ID As Long = eng.SaveDocumentRegister(uPara.UserName, para, Session(Constant.SessFileUploadList), txtScanJobID.Text, trans)
        If _ID > 0 Then
            'ให้มีการ Insert Document Register โดยที่ฟิลด์ BOOK_NO กับ  REQUEST_NO  เป็นค่า null ไปก่อนเพื่อให้ Lock Transaction
            'และป้องกันการ Generate เลขที่หนังสือซ้ำ
            para = New DocumentRegisterPara
            para = eng.GetDocumentPara(_ID, trans)

            'Gen เลขที่หนังสือ
            If RefDocRegisID = 0 Then
                para.BOOK_NO = Engine.Document.BookRunningENG.GetBookNo(rdiReceiveType.SelectedValue, SendType, uPara.ORG_DATA.NAME_ABB, trans)
            Else
                para.BOOK_NO = RefDocRegisBookNo & "/" & ReceiveAbbName
            End If

            'ถ้าเป็นเลขต้น และเป็นกลุ่มเรื่องคำขอ ถึงจะ Gen เลขที่คำขอ
            If ReceiveAbbName.Trim = "" Then
                Dim gEng As New Engine.Master.GroupTitleEng
                Dim gPara As Para.TABLE.GroupTitlePara = gEng.GetGroupTitlePara(cmbGroupTitle.SelectedValue, trans)
                If gPara.IS_GEN_REQ = "Y" Then
                    para.REQUEST_NO = Engine.Document.BookRunningENG.GetRequestNo(trans)
                    txtRequestNo.Text = para.REQUEST_NO
                End If
                gEng = Nothing
                gPara = Nothing
            Else
                para.REQUEST_NO = txtRequestNo.Text.Trim
            End If

            _ID = 0  'Reset ก่อน เพื่อให้แน่ใจว่าเป็นข้อมูลใหม่แน่ๆ
            _ID = eng.SaveDocumentRegister(uPara.UserName, para, Session(Constant.SessFileUploadList), txtScanJobID.Text, trans)

            If _ID > 0 Then
                para.ID = _ID
            Else
                para.ID = 0
            End If

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

#Region "ลงทะเบียนพร้อมส่งภายใน"
    Private Function SaveInsideSend(ByVal DocRegisID As Long, ByVal dr As DataRow, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) As Boolean
        Dim ret As Boolean = True
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim para As New Para.TABLE.DocumentIntReceiverPara
        para.DOCUMENT_REGISTER_ID = DocRegisID
        para.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
        para.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
        para.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE
        para.SEND_DATE = DateTime.Now
        para.SENDER_OFFICER_USERNAME = uPara.UserName
        para.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
        para.RECEIVE_STATUS_ID = Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive
        para.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(dr("OrgNameReceiveID"))
        para.ORGANIZATION_NAME_RECEIVE = dr("OrgNameReceive")
        para.ORGANIZATION_APPNAME_RECEIVE = dr("OrgAbbNameReceive")

        Dim sEng As New Engine.Master.OfficerEng
        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(Convert.ToInt64(dr("StaffNameReceiveID")))
        para.RECEIVER_OFFICER_USERNAME = sPara.USERNAME
        para.RECEIVER_OFFICER_FULLNAME = sPara.FIRST_NAME & " " & sPara.LAST_NAME
        para.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(dr("PurposeID"))
        para.RECEIVE_TYPE_ID = Convert.ToInt64(dr("PurposeID"))
        para.REMARKS = dr("remark_receive")
        sEng = Nothing

        Dim eng As New Engine.Document.DocumentRegisterENG
        If para.ORGANIZATION_ID_RECEIVE = para.ORGANIZATION_ID_SEND Then
            'ถ้าผู้รับกับผู้ส่งอยู่หน่วยงานเดียวกันกำหนดให้เป็นงานค้างของผู้รับเลย
            Dim rPara As New Para.TABLE.DocumentRegisterPara
            rPara = eng.GetDocumentPara(DocRegisID, trans)
            rPara.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobRemain
            rPara.ORGANIZATION_ID_PROCESS = para.ORGANIZATION_ID_RECEIVE
            rPara.ORGANIZATION_NAME_PROCESS = para.ORGANIZATION_NAME_RECEIVE
            rPara.ORGANIZATION_ABBNAME_PROCESS = para.ORGANIZATION_APPNAME_RECEIVE
            rPara.OFFICER_ID_POSSESS = sPara.ID
            rPara.OFFICER_NAME_POSSESS = sPara.FIRST_NAME & " " & sPara.LAST_NAME
            ret = eng.SaveDocumentRegister(uPara.UserName, rPara, Nothing, txtScanJobID.Text, trans)
            If ret = True Then
                para.RECEIVE_DATE = para.SEND_DATE
                para.RECEIVE_STATUS_ID = Constant.DocumentIntReceiver.ReceiveStatusID.Received
            End If
        End If
        If ret = True Then
            ret = eng.SaveInsideSend(uPara.UserName, para, trans)
        End If
        eng = Nothing
        para = Nothing
        sPara = Nothing

        Return ret
    End Function

    Private Function SaveInsideSendCloseJob(ByVal DocRegisID As Long, ByVal dr As DataRow, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) As Boolean
        Dim ret As Boolean = True

        Dim DataNow As DateTime = DateTime.Now
        Dim para As New Para.TABLE.DocumentIntReceiverPara
        para.DOCUMENT_REGISTER_ID = DocRegisID
        para.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
        para.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
        para.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE
        para.SEND_DATE = DataNow
        para.SENDER_OFFICER_USERNAME = uPara.UserName
        para.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
        para.RECEIVE_STATUS_ID = Constant.DocumentIntReceiver.ReceiveStatusID.Received
        para.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(dr("OrgNameReceiveID"))
        para.ORGANIZATION_NAME_RECEIVE = dr("OrgNameReceive")
        para.ORGANIZATION_APPNAME_RECEIVE = dr("OrgAbbNameReceive")

        Dim sEng As New Engine.Master.OfficerEng
        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(Convert.ToInt64(dr("StaffNameReceiveID")))
        para.RECEIVE_DATE = DataNow
        para.RECEIVER_OFFICER_USERNAME = sPara.USERNAME
        para.RECEIVER_OFFICER_FULLNAME = sPara.FIRST_NAME & " " & sPara.LAST_NAME
        para.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(dr("PurposeID"))
        para.RECEIVE_TYPE_ID = Convert.ToInt64(dr("PurposeID"))
        para.REMARKS = dr("remark_receive")

        Dim eng As New Engine.Document.DocumentRegisterENG
        ret = eng.SaveInsideSend(uPara.UserName, para, trans)
        If ret = False Then
            Config.SaveErrorLog(eng.ErrorMessage, uPara.LOGIN_HISTORY_ID)
        End If

        sEng = Nothing
        eng = Nothing
        para = Nothing
        sPara = Nothing

        Return ret
    End Function

    Protected Sub btnSendInside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside1.Click
        If ValidRegis() = True Then
            Dim dt As New DataTable
            dt = GetSendList()
            'If dt.Rows.Count > 0 Then
            If ValidInsideSend(dt) = True Then
                Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มส่งภายในสำนักงาน")
                btnSendInside1.ShowPopupConfirm(dt)
            End If
            'End If
            dt.Dispose()
        End If
    End Sub

    Protected Sub btnSendInside1_YesSend(ByVal sender As Object, ByVal e As System.EventArgs, ByVal trans As Linq.Common.Utilities.TransactionDB) Handles btnSendInside1.YesSend
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim ret As Boolean = False
        Dim dt As New DataTable
        dt = GetSendList()
        If dt.Rows.Count > 0 Then
            Dim SendType As String = "I"
            Dim dPara As New Para.TABLE.DocumentRegisterPara
            'Dim NewBookNo As String = Engine.Document.BookRunningENG.GetBookNo(rdiReceiveType.SelectedValue, SendType, uPara.ORG_DATA.NAME_ABB, trans)
            dPara = InsertDocRegis(0, "", "", SendType, trans, uPara)   'SendType=I  ส่งภายในสำนักงาน
            If dPara.ID > 0 Then
                txtID.Text = dPara.ID

                ' กรณีส่งหาหลายคน
                If dt.Rows.Count > 1 Then
                    'ต้นเรื่องให้ส่งหาผู้พิจารณา
                    Dim sdr As DataRow = BuiltSendList().NewRow
                    sdr("OrgNameReceiveID") = cmbOwnerOrgID.SelectedValue
                    sdr("StaffNameReceiveID") = cmbOwnerStaffID.SelectedValue
                    sdr("OrgNameReceive") = cmbOwnerOrgID.SelectedItem.Text
                    Dim rEng As New Engine.Master.OrganizationEng
                    Dim rPara As Para.TABLE.OrganizationPara = rEng.GetOrgPara(cmbReceiveOrgID.SelectedValue)
                    sdr("OrgAbbNameReceive") = rPara.NAME_RECEIVE
                    sdr("StaffNameReceive") = cmbOwnerStaffID.SelectedItem.Text
                    sdr("PurposeID") = "0"
                    sdr("remark_receive") = ""
                    rEng = Nothing
                    rPara = Nothing

                    ret = SaveInsideSend(txtID.Text, sdr, trans, uPara)
                    If ret = True Then
                        Dim i As Integer = 0
                        For Each dr As DataRow In dt.Rows
                            Dim OrgDocRegisID As Long = InsertDocRegis(txtID.Text, dPara.BOOK_NO, dr("OrgAbbNameReceive") & "-" & (i + 1), SendType, trans, uPara).ID
                            If OrgDocRegisID > 0 Then
                                ret = SaveInsideSend(OrgDocRegisID, dr, trans, uPara)
                            Else
                                ret = False
                            End If
                            If ret = False Then
                                Exit For
                            End If
                            i += 1
                        Next
                    End If
                Else
                    'กรณีส่งหาคนเดียว
                    Dim dr As DataRow = dt.Rows(0)
                    ret = SaveInsideSend(dPara.ID, dr, trans, uPara)
                End If

                Config.SaveTransLog("frmDocRegister.aspx ส่งภายในสำนักงาน เลขที่หนังสือ " & dPara.BOOK_NO)
            End If

            dPara = Nothing
        End If
        dt.Dispose()
        If ret = True Then
            btnSendInside1.NewRegisID = txtID.Text
        End If
        uPara = Nothing
    End Sub

    Protected Sub btnSendInside1_NoClear(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside1.NoClear
        txtBookNo.Text = ""
        txtRequestNo.Text = ""
        Session.Remove(Constant.SessFileUploadList)
        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มไม่ใช่ เพื่อไม่เคลียร์หน้าจอ")
    End Sub

    Protected Sub btnSendInside1_NoSend(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside1.NoSend
        txtBookNo.Text = ""
        txtRequestNo.Text = ""
        txtID.Text = "0"
        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มไม่ใช่")
    End Sub

    Protected Sub btnSendInside1_YesClear(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside1.YesClear
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        txtID.Text = "0"
        clearfrm(uPara)
        ClearSendForm(uPara)
        'Session.Remove(SessSendList)
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()
        gvSendList.Visible = False
        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มใช่ เพื่อเคลียร์หน้าจอ")
        uPara = Nothing
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มเคลียร์")
        ClearSendForm(uPara)
        uPara = Nothing
    End Sub

    Protected Sub gvSendList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSendList.RowCommand
        If e.CommandName = "Delete" Then
            Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim index As Integer = gvRow.RowIndex
            Dim dt As DataTable = GetSendList()
            dt.Rows.RemoveAt(index)

            gvSendList.DataSource = dt
            gvSendList.DataBind()
            'Session(SessSendList) = dt
            Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มลบรายการผู้รับ")
        End If
    End Sub

    Protected Sub gvSendList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSendList.RowDeleting
        'ต้องมีไว้ ไม่งั้นลบไม่ได้
    End Sub

#End Region

#Region "ลงทะเบียนพร้อมจบงาน"
    Protected Sub btnCloseJob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If ValidRegis() = True Then
            If ValidCloseJob() = True Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim SendType As String = "I"
                Dim dPara As New Para.TABLE.DocumentRegisterPara
                'Dim NewBookNo As String = Engine.Document.BookRunningENG.GetBookNo(rdiReceiveType.SelectedValue, SendType, uPara.ORG_DATA.NAME_ABB, trans)
                dPara = InsertDocRegis(0, "", "", SendType, trans, uPara)   'SendType=I  ส่งภายในสำนักงาน

                If dPara.ID > 0 Then
                    trans.CommitTransaction()
                    txtID.Text = dPara.ID
                    Dim dt As New DataTable
                    dt.Columns.Add("id")
                    dt.Columns.Add("book_no")
                    dt.Columns.Add("book_title")

                    Dim dr As DataRow = dt.NewRow
                    dr("id") = dPara.ID
                    dr("book_no") = dPara.BOOK_NO
                    dr("book_title") = dPara.TITLE_NAME
                    dt.Rows.Add(dr)
                    btnCloseJob1.ScanJobID = txtScanJobID.Text
                    btnCloseJob1.SetConfirmList(dt)

                    Config.SaveTransLog("frmDocumentRegister.aspx คลิกปุ่มลงทะเบียนพร้อมจบงาน เลขที่หนังสือ " & dPara.BOOK_NO)
                Else
                    trans.RollbackTransaction()
                End If
            End If
        End If
    End Sub

    Protected Sub btnCloseJob1_NoClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.NoClick
        txtBookNo.Text = ""
        txtRequestNo.Text = ""

        Dim eng As New Engine.Document.DocumentRegisterENG
        eng.DeleteRegisterData(Convert.ToInt64(txtID.Text))
        eng = Nothing
        txtID.Text = "0"
    End Sub

    Protected Sub btnCloseJob1_OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.OKClick
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        clearfrm(uPara)
        ClearSendForm(uPara)
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()
        gvSendList.Visible = False
    End Sub

    Protected Sub btnCloseJob1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As System.Data.DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.YesClick
        Dim ret As Boolean = False

        Dim dtt As New DataTable
        'dtt = GetSendList()
        dtt = BuiltSendList()
        Dim dr As DataRow = dtt.NewRow
        Dim oPara As New OrganizationPara
        Dim oEng As New Engine.Master.OrganizationEng
        oPara = oEng.GetOrgPara(cmbOwnerOrgID.SelectedValue)
        dr("OrgNameReceive") = cmbOwnerOrgID.Text
        dr("OrgNameReceiveID") = cmbOwnerOrgID.SelectedValue
        dr("OrgAbbNameReceive") = oPara.NAME_RECEIVE
        oPara = Nothing
        oEng = Nothing

        Dim sPara As New OfficerPara
        Dim sEng As New OfficerEng
        sPara = sEng.GetOfficerPara(cmbOwnerStaffID.SelectedValue)
        dr("StaffNameReceiveID") = sPara.ID
        dr("StaffNameReceive") = sPara.FIRST_NAME & " " & sPara.LAST_NAME
        sPara = Nothing
        sEng = Nothing

        dr("Purpose") = ""
        dr("PurposeID") = "0"
        dr("remark_receive") = ""

        dtt.Rows.Add(dr)
        If dtt.Rows.Count > 0 Then
            For Each ddr As DataRow In dtt.Rows
                If SaveInsideSendCloseJob(txtID.Text, ddr, trans, uPara) = True Then
                    btnCloseJob1.CloseJobSuccess = "Y"
                Else
                    Config.SetAlert("เกิดข้อผิดพลาดในการบันทีกข้อมูล กรุณาติดต่อผู้ดูแลระบบ", Me)
                    Exit For
                End If
            Next
        End If
    End Sub
#End Region

#Region "ลงทะเบียนพร้อมส่งออกภายนอก"
    Protected Sub btnSendOutside1_AfterExportClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnSendOutside1.AfterExportClick

        Dim dtt As New DataTable
        dtt = GetSendList()
        If dtt.Rows.Count > 0 Then
            If uPara.UserName.Trim <> "" Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                If trans.CreateTransaction() = True Then
                    Dim ret As Boolean = False
                    Dim _err As String = ""
                    For Each ddr As DataRow In dtt.Rows
                        Dim DateNow As DateTime = DateTime.Now
                        Dim para As New Para.TABLE.DocumentIntReceiverPara
                        para.DOCUMENT_REGISTER_ID = txtID.Text
                        para.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                        para.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
                        para.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_ABB
                        para.SEND_DATE = DateNow
                        para.SENDER_OFFICER_USERNAME = uPara.UserName
                        para.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                        para.RECEIVE_STATUS_ID = Constant.DocumentIntReceiver.ReceiveStatusID.Received
                        para.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(ddr("OrgNameReceiveID"))
                        para.ORGANIZATION_NAME_RECEIVE = ddr("OrgNameReceive")
                        para.ORGANIZATION_APPNAME_RECEIVE = ddr("OrgAbbNameReceive")

                        Dim sEng As New Engine.Master.OfficerEng
                        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(Convert.ToInt64(ddr("StaffNameReceiveID")))
                        para.RECEIVE_DATE = DateNow
                        para.RECEIVER_OFFICER_USERNAME = sPara.USERNAME
                        para.RECEIVER_OFFICER_FULLNAME = sPara.FIRST_NAME & " " & sPara.LAST_NAME
                        para.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(ddr("PurposeID"))
                        para.RECEIVE_TYPE_ID = Convert.ToInt64(ddr("PurposeID"))
                        para.REMARKS = ddr("remark_receive")
                        sEng = Nothing
                        sPara = Nothing

                        Dim eng As New Engine.Document.DocumentRegisterENG
                        ret = eng.SaveInsideSend(uPara.UserName, para, trans)
                        If ret = False Then
                            _err = eng.ErrorMessage
                        End If
                        eng = Nothing
                        para = Nothing
                    Next

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        Config.SetAlert("เกิดข้อผิดพลาดในการบันทีกข้อมูล กรุณาติดต่อผู้ดูแลระบบ " & _err, Me)
                    End If
                Else
                    Config.SetAlert(trans.ErrorMessage, Me)
                End If
            Else
                Config.SetAlert("เกิดข้อผิดพลาดในการบันทีกข้อมูล กรุณาติดต่อผู้ดูแลระบบ", Me)
            End If
        End If
        dtt.Dispose()
    End Sub

    Protected Sub btnSendOutside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If ValidRegis() = True Then
            Dim dtS As New DataTable
            dtS = GetSendList()
            If ValidInsideSend(dtS) = True Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim SendType As String = "I"    'การลงทะเบียนพร้อมจบงาน จะต้อง Gen เลขลงทะเบียนก่อน
                Dim dPara As New Para.TABLE.DocumentRegisterPara
                'Dim NewBookNo As String = Engine.Document.BookRunningENG.GetBookNo(rdiReceiveType.SelectedValue, SendType, uPara.ORG_DATA.NAME_ABB, trans)
                dPara = InsertDocRegis(0, "", "", SendType, trans, uPara)   'SendType=I  ส่งภายในสำนักงาน

                If dPara.ID > 0 Then
                    trans.CommitTransaction()
                    txtID.Text = dPara.ID

                    Dim dt As New DataTable
                    dt.Columns.Add("id")
                    dt.Columns.Add("bookno")
                    dt.Columns.Add("book_title")
                    dt.Columns.Add("dates_app", GetType(Date))
                    dt.Columns.Add("company_name")
                    dt.Columns.Add("company_id")
                    dt.Columns.Add("company_regis_no")
                    dt.Columns.Add("company_doc_sys_id")

                    Dim dr As DataRow = dt.NewRow
                    dr("id") = dPara.ID
                    dr("bookno") = dPara.BOOK_NO
                    dr("book_title") = dPara.TITLE_NAME
                    dr("dates_app") = DateTime.Now
                    dr("company_name") = dPara.COMPANY_NAME
                    dr("company_id") = dPara.COMPANY_ID
                    dr("company_regis_no") = dPara.COMPANY_REGIS_NO
                    dr("company_doc_sys_id") = dPara.COMPANY_DOC_SYS_ID
                    dt.Rows.Add(dr)

                    Config.SaveTransLog("frmDocumentRegister.aspx คลิกปุ่มส่งออกภายนอกสำนักงาน")
                    btnSendOutside1.ScanJobID = txtScanJobID.Text
                    btnSendOutside1.ShowPop(dt, uPara)
                Else
                    trans.RollbackTransaction()
                    Config.SaveErrorLog("เกิดความผิดพลาด ไม่สามารถบันทึกข้อมูลได้ กรุณาติดต่อผู้ดูแลระบบ", Config.GetLogOnUser.LOGIN_HISTORY_ID)
                    Config.SetAlert("เกิดความผิดพลาด ไม่สามารถบันทึกข้อมูลได้ กรุณาติดต่อผู้ดูแลระบบ", Me)
                End If
            End If
            dtS.Dispose()
        End If
    End Sub

    Protected Sub btnSendOutside1_CancelSendClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As DataTable) Handles btnSendOutside1.CancelSendClick
        'Dim dt As DataTable = Session("SessDocRegisList")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim eng As New Engine.Document.DocumentRegisterENG
                eng.DeleteRegisterData(Convert.ToInt64(dr("id")))
                eng = Nothing
            Next
        End If
    End Sub

    Protected Sub btnSendOutside1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.OkClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        clearfrm(uPara)
        ClearSendForm(uPara)
        'Session.Remove(SessSendList)
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()
        gvSendList.Visible = False
        uPara = Nothing
    End Sub
#End Region

    
#Region "การส่งหนังสือเวียน"
    Protected Sub btnSendCircle1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendCircle1.Click
        If ValidRegis() = True Then
            Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มส่งหนังสือเวียน")
            btnSendCircle1.SetShowPop()
        End If
    End Sub

    Protected Sub btnSendCircle1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendCircle1.OkClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Config.SaveTransLog("frmDocRegister.aspx คลิกปุ่มตกลง")
        clearfrm(uPara)
        ClearSendForm(uPara)
        'Session.Remove(SessSendList)
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()
        'gvSendList.Visible = False
        uPara = Nothing
    End Sub

    Protected Sub btnSendCircle1_SendClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As DataTable) Handles btnSendCircle1.SendClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim para As New Para.Document.SendCirclePara
        para.SEND_LIST = New DataTable
        para.SEND_LIST.Columns.Add("book_no")
        para.SEND_LIST.Columns.Add("OrgNameReceive")

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        Dim ret As Boolean = False
        Dim SendType As String = "I"
        Dim dPara As New Para.TABLE.DocumentRegisterPara
        'Dim NewBookNo As String = Engine.Document.BookRunningENG.GetBookNo(rdiReceiveType.SelectedValue, SendType, uPara.ORG_DATA.NAME_ABB, trans)
        dPara = InsertDocRegis(0, "", "", SendType, trans, uPara)   'SendType=I  ส่งภายในสำนักงาน

        If dPara.ID > 0 Then
            txtID.Text = dPara.ID
            If dt.Rows.Count > 0 Then
                'ต้นเรื่องให้ส่งหาผู้พิจารณา
                Dim sdr As DataRow = BuiltSendList().NewRow
                sdr("OrgNameReceiveID") = cmbOwnerOrgID.SelectedValue
                sdr("StaffNameReceiveID") = cmbOwnerStaffID.SelectedValue
                sdr("OrgNameReceive") = cmbOwnerOrgID.SelectedItem.Text
                Dim rEng As New Engine.Master.OrganizationEng
                Dim rPara As Para.TABLE.OrganizationPara = rEng.GetOrgPara(cmbReceiveOrgID.SelectedValue)
                sdr("OrgAbbNameReceive") = rPara.NAME_ABB
                sdr("StaffNameReceive") = cmbOwnerStaffID.SelectedItem.Text
                sdr("PurposeID") = "0"
                sdr("remark_receive") = ""
                rEng = Nothing
                rPara = Nothing

                ret = SaveInsideSend(dPara.ID, sdr, trans, uPara)
                If ret = True Then
                    para.BOOK_NO = dPara.BOOK_NO
                    For Each dr As DataRow In dt.Rows
                        Dim OrgDocRegisID As Long = InsertDocRegis(dPara.ID, dPara.BOOK_NO, dr("OrgAbbNameReceive"), SendType, trans, uPara).ID
                        If OrgDocRegisID > 0 Then
                            Dim seDr As DataRow = para.SEND_LIST.NewRow
                            seDr("book_no") = dPara.BOOK_NO & "/" & dr("OrgAbbNameReceive")
                            seDr("OrgNameReceive") = dr("OrgNameReceive").ToString
                            para.SEND_LIST.Rows.Add(seDr)

                            ret = SaveInsideSend(OrgDocRegisID, dr, trans, uPara)
                            Config.SaveTransLog("frmDocumentRegister.aspx ส่งหนังสือเวียนต้นเรื่อง " & para.BOOK_NO & " เลขที่หนังสือ :" & dPara.BOOK_NO & "/" & dr("OrgAbbNameReceive"))
                        Else
                            ret = False
                        End If

                        If ret = False Then
                            Exit For
                        End If
                    Next
                End If
            End If
        End If

        If ret = True Then
            trans.CommitTransaction()
            btnSendCircle1.SetSendComplete(para)
        Else
            trans.RollbackTransaction()
        End If
        uPara = Nothing
    End Sub

    'Private Function GetDocCirclePara() As Para.Document.SendCirclePara
    '    Dim trans As New Linq.Common.Utilities.TransactionDB
    '    trans.CreateTransaction()
    '    Dim eng As New Engine.Document.DocumentRegisterENG

    '    Dim para As New Para.Document.SendCirclePara
    '    para.SEND_LIST = New DataTable
    '    para.SEND_LIST = eng.GetDocumentCircleListByRefID(Convert.ToInt64(txtID.Text), trans)
    '    para.BOOK_NO = eng.GetDocumentPara(Convert.ToInt64(txtID.Text), trans).BOOK_NO
    '    trans.CommitTransaction()
    '    eng = Nothing
    '    Return para
    'End Function
#End Region

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


    Protected Sub AutoCompleteExtender1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.Unload
        AutoCompleteExtender1.Dispose()
    End Sub

End Class
