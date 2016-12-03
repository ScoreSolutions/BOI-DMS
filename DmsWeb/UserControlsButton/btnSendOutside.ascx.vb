Imports System.Data
Imports Para.Common.Utilities

Partial Class UserControls_Button_btnSendOutside
    Inherits System.Web.UI.UserControl


    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AfterExportClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)
    Public Event OkClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event CancelSendClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As DataTable)

    'Const SessDocRegisList As String = "SessDocRegisList"
    'Const SessCompanyList As String = "SessCompanyList"
    'Const SessPopCompanySearchResult As String = "PopCompanySearchResult"

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
    End Sub

    Public WriteOnly Property VisibleButton1() As Boolean
        Set(ByVal value As Boolean)
            btnButton1.Visible = value
        End Set
    End Property

    Public Sub ShowPop(ByVal dt As DataTable,uPara As Para.Common.UserProfilePara)
        'Session(SessDocRegisList) = dt
        gvShowData.DataSource = dt
        gvShowData.DataBind()

        SetCompanyDefault(dt)
        dt.Dispose()

        'Dim uPara As New Para.Common.UserProfilePara
        'uPara = Config.GetLogOnUser

        Dim sEng As New Engine.Master.OrganizationEng
        Dim sDt As New DataTable
        sDt = sEng.GetStaffByOrgID(uPara.ORG_DATA.ID)
        If sDt.Rows.Count > 0 Then
            Dim oDt As New DataTable
            oDt = sEng.GetOfficerSignByOrgID(uPara.ORG_DATA.ID)
            If oDt.Rows.Count > 0 Then
                For Each oDr As DataRow In oDt.Rows
                    Dim sDr As DataRow = sDt.NewRow
                    sDr("staff_name") = oDr("officer_name")
                    sDr("id") = oDr("id")
                    sDr("officer_level") = oDr("officer_level")
                    sDt.Rows.Add(sDr)
                Next
            End If
            oDt.Dispose()

            sDt.Columns.Add("sort_officer_level", GetType(Int32))
            For i As Integer = 0 To sDt.Rows.Count - 1
                If Convert.IsDBNull(sDt.Rows(i)("officer_level")) = False Or sDt.Rows(i)("officer_level").ToString <> "" Then
                    sDt.Rows(i)("sort_officer_level") = Convert.ToInt32(sDt.Rows(i)("officer_level"))
                Else
                    sDt.Rows(i)("sort_officer_level") = -3
                End If
            Next
            sDt.DefaultView.Sort = "sort_officer_level desc,staff_name"
            sDt = sDt.DefaultView.ToTable

            cmbStaffSignID.SetItemList(sDt, "staff_name", "id")
        End If
        sDt.Dispose()

        Dim stDt As New DataTable
        stDt = sEng.GetOrgStorageList()
        Dim stDr As DataRow = stDt.NewRow
        stDr("id") = uPara.ORG_DATA.ID
        stDr("org_name") = uPara.ORG_DATA.ORG_NAME
        stDt.Rows.Add(stDr)
        cmbOrgKeepID.SetItemList(stDt, "org_name", "id")

        stDt.Dispose()
        sEng = Nothing

        zPopShowData.Show()
    End Sub

    Private Function GetDocumentList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        'dt.Columns.Add("bookno")
        'dt.Columns.Add("book_title")
        'dt.Columns.Add("dates_app", GetType(Date))
        'dt.Columns.Add("company_name")
        'dt.Columns.Add("company_id")
        If gvShowData.Rows.Count > 0 Then
            For Each grv As GridViewRow In gvShowData.Rows
                Dim dr As DataRow = dt.NewRow
                dr("id") = grv.Cells(0).Text
                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        RaiseEvent CancelSendClick(sender, e, GetDocumentList())
        CancelSendOutside()
    End Sub

    Private Sub CancelSendOutside()
        'Session.Remove(SessDocRegisList)
        'Session.Remove(SessCompanyList)

        ClearCompanyForm()
        zPopShowData.Hide()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent CancelSendClick(sender, e, GetDocumentList())
        CancelSendOutside()
    End Sub


    Private Sub SetCompanyDefault(ByVal dt As DataTable)
        'Session.Remove(SessCompanyList)
        
        Dim ret As DataTable = SetSessionCompanyList()
        If dt.Rows.Count > 0 Then
            hdnCustValue.Text = dt.Rows(0)("company_id")
            txtCustName.Text = dt.Rows(0)("company_name")
            hdnCompanyRegisNo.Text = dt.Rows(0)("company_regis_no")

            Dim i As Integer = 0
            For Each dr As DataRow In dt.Rows
                Dim eng As New Engine.Document.DocumentRegisterENG
                Dim tmp As DataTable = eng.GetOutsideCompanyDefault(Convert.ToInt64(dr("id")))
                If tmp.Rows.Count > 0 Then
                    For Each drTmp As DataRow In tmp.Rows
                        Dim rdr As DataRow = ret.NewRow
                        rdr("no") = (i + 1).ToString
                        rdr("remarks") = drTmp("remarks")
                        rdr("StaffNameSign") = drTmp("staff_name")
                        rdr("CompanyNameReceive") = drTmp("company_name_receive")
                        rdr("officer_id") = drTmp("officer_id")
                        rdr("company_id") = drTmp("company_id_receive")
                        rdr("company_regis_no") = drTmp("company_regis_no")
                        ret.Rows.Add(rdr)
                        i += 1
                    Next
                    tmp = Nothing
                End If
                eng = Nothing
            Next
            dt = Nothing
        End If

        If ret.Rows.Count > 0 Then
            'Session(SessCompanyList) = ret
            gvSendList.DataSource = ret
            gvSendList.DataBind()
            ret = Nothing
        Else
            'Session.Remove(SessCompanyList)
            gvSendList.DataSource = Nothing
            gvSendList.DataBind()
        End If
    End Sub


    Private Function ValidExport() As Boolean
        Dim ret As Boolean = True
        If gvSendList.Rows.Count = 0 Then
            ret = False
            Config.SetAlert("กรุณาเลือกหน่วยงานที่ต้องการส่งออกภายนอกสำนักงาน", Me.Page)
        ElseIf cmbOrgKeepID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกหน่วยงานจัดเก็บหนังสือ", Me.Page, cmbOrgKeepID.ClientID)
        End If
        Return ret
    End Function

    Const ColNo As Integer = 0
    Const ColRemarks As Integer = 2
    Const ColStaffNameSign As Integer = 3
    Const ColOfficerID As Integer = 5
    Const ColCompanyNameReceive As Integer = 1
    Const ColCompanyID As Integer = 6
    Const ColCompanySource As Integer = 7
    Const ColCompanyRegisNo As Integer = 8

    

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If ValidExport() = True Then
            Dim DocDT As New DataTable
            DocDT.Columns.Add("DocumentRegisterPara", GetType(Para.TABLE.DocumentRegisterPara))

            Dim SendDT As New DataTable
            SendDT.Columns.Add("DocumentExtReceiverPara", GetType(Para.TABLE.DocumentExtReceiverPara))

            Dim ret As Boolean = False
            'Dim uPara As New Para.Common.UserProfilePara
            'uPara = Config.GetLogOnUser
            If uPara.UserName.Trim <> "" Then
                Dim _err As String = ""
                Dim trans As New Linq.Common.Utilities.TransactionDB
                If trans.CreateTransaction() = True Then
                    For Each drv As GridViewRow In gvShowData.Rows
                        Dim DocRegisID As Long = Convert.ToInt64(drv.Cells(0).Text)
                        Dim eng As New Engine.Document.DocumentRegisterENG
                        Dim dPara As New Para.TABLE.DocumentRegisterPara
                        dPara = eng.GetDocumentPara(DocRegisID, trans)

                        Dim vBookOutNo As String = ""
                        Dim tmpDt As DataTable = GetCompanySendList() 'Session(SessCompanyList)
                        Dim DateNow As DateTime = DateTime.Now
                        For Each tmpDr As DataRow In tmpDt.Rows
                            Dim para As New Para.TABLE.DocumentExtReceiverPara
                            para.DOCUMENT_REGISTER_ID = DocRegisID
                            para.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                            para.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_NAME
                            para.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_ABB
                            para.SEND_DATE = DateNow
                            para.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                            para.SENDER_OFFICER_USERNAME = uPara.UserName
                            para.BOOKOUT_NO = Engine.Document.BookRunningENG.GetBookNo("", "O", uPara.ORG_DATA.ORG_CODE, trans)
                            If vBookOutNo = "" Then
                                vBookOutNo = para.BOOKOUT_NO
                            Else
                                vBookOutNo += ", " & para.BOOKOUT_NO
                            End If
                            para.APPROVE_DATE = DateTime.Now

                            'Company
                            Dim cEng As New Engine.Master.CompanyEng
                            Dim cPara As New Para.TABLE.CompanyPara
                            cPara = cEng.GetCompanyPara(tmpDr("company_id"))
                            If cPara.TH_EGIF_ORG_CODE.Trim <> "" Then
                                para.IS_SEND_THEGIF = "N"c
                            Else
                                para.IS_SEND_THEGIF = "I"c
                            End If
                            cPara = Nothing
                            cEng = Nothing

                            para.COMPANY_ID_RECEIVE = Convert.ToInt64(tmpDr("company_id"))
                            para.COMPANY_NAME_RECEIVE = tmpDr("CompanyNameReceive").ToString
                            para.COMPANY_REGIS_NO = tmpDr("CompanyRegisNo").ToString

                            Dim sEng As New Engine.Master.OfficerEng
                            Dim sPara As New Para.TABLE.OfficerPara
                            sPara = sEng.GetOfficerPara(Convert.ToInt64(tmpDr("officer_id")))
                            para.OFFICER_USERNAME = sPara.USERNAME
                            para.OFFICER_FULLNAME = sPara.FIRST_NAME & " " & sPara.LAST_NAME
                            para.REMARKS = tmpDr("remarks").ToString
                            sEng = Nothing
                            sPara = Nothing

                            'Storage
                            para.ORGANIZATION_ID_STORAGE = cmbOrgKeepID.SelectedValue
                            para.ORGANIZATION_NAME_STORAGE = cmbOrgKeepID.SelectedText

                            ret = eng.SaveOutsideSend(uPara.UserName, para, trans)
                            Config.SaveTransLog("btnSendOutside.ascx ส่งออกภายนอกสำนักงาน ต้นเรื่อง " & dPara.BOOK_NO & " เลขที่ " & para.BOOKOUT_NO)
                            If ret = False Then
                                _err = eng.ErrorMessage
                                Exit For
                            Else
                                Dim SendDR As DataRow = SendDT.NewRow
                                SendDR("DocumentExtReceiverPara") = para
                                SendDT.Rows.Add(SendDR)
                            End If
                        Next

                        dPara.BOOKOUT_NO = vBookOutNo
                        dPara.ORGANIZATION_ID_STORAGE = cmbOrgKeepID.SelectedValue
                        dPara.ORGANIZATION_NAME_STORAGE = cmbOrgKeepID.SelectedText
                        dPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                        dPara.BOOKOUT_DATE = DateNow

                        'ถ้าเลือกที่จบงานด้วย
                        Dim chk As CheckBox = CType(drv.Cells(4).FindControl("chkCloseJob"), CheckBox)
                        If chk.Checked = True Then
                            dPara.CLOSE_BY = uPara.UserName
                            dPara.CLOSE_BY_NAME = uPara.FirstName & " " & uPara.LastName
                            dPara.CLOSE_DATE = DateTime.Now
                            dPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose
                        End If
                        ret = eng.SaveDocumentRegister(uPara.UserName, dPara, Session(Para.Common.Utilities.Constant.SessFileUploadList), txtScanJobID.Text, trans) > 0

                        If ret = True Then
                            Dim DocDr As DataRow = DocDT.NewRow
                            DocDr("DocumentRegisterPara") = dPara
                            DocDT.Rows.Add(DocDr)

                            If dPara.ORGANIZATION_ID_STORAGE <> uPara.ORG_DATA.ID Then
                                'บันทึกข้อมูลสำหรับส่งภายในไปให้กับหน่วยงานจัดเก็บ
                                Dim kEng As New Engine.Master.OrganizationEng
                                Dim kPara As New Para.TABLE.OrganizationStoragePara
                                kPara = kEng.GetOrgStoragePara(cmbOrgKeepID.SelectedValue, trans)

                                Dim srPara As New Para.TABLE.DocumentRegisterPara
                                srPara.BOOK_NO = dPara.BOOK_NO & "/" & kPara.STORAGE_ABB_NAME
                                srPara.REQUEST_NO = dPara.REQUEST_NO
                                srPara.GROUP_TITLE_ID = dPara.GROUP_TITLE_ID
                                srPara.TITLE_NAME = dPara.TITLE_NAME
                                srPara.REGISTER_DATE = dPara.REGISTER_DATE
                                srPara.EXPECT_FINISH_DATE = dPara.EXPECT_FINISH_DATE
                                srPara.DOC_SECRET_ID = dPara.DOC_SECRET_ID
                                srPara.DOC_SPEED_ID = dPara.DOC_SPEED_ID
                                srPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome
                                srPara.ORGANIZATION_ID_OWNER = dPara.ORGANIZATION_ID_OWNER
                                srPara.ORGANIZATION_NAME = dPara.ORGANIZATION_NAME
                                srPara.ORGANIZATION_APPNAME = dPara.ORGANIZATION_APPNAME
                                srPara.ORGANIZATION_ID_PROCESS = dPara.ORGANIZATION_ID_PROCESS
                                srPara.ORGANIZATION_NAME_PROCESS = dPara.ORGANIZATION_NAME_PROCESS
                                srPara.ORGANIZATION_ABBNAME_PROCESS = dPara.ORGANIZATION_ABBNAME_PROCESS
                                srPara.OFFICER_ID_APPROVE = dPara.OFFICER_ID_APPROVE
                                srPara.OFFICER_NAME = dPara.OFFICER_NAME
                                srPara.OFFICER_ORGANIZATION_ID = dPara.OFFICER_ORGANIZATION_ID
                                srPara.OFFICER_ID_POSSESS = dPara.OFFICER_ID_POSSESS
                                srPara.OFFICER_NAME_POSSESS = dPara.OFFICER_NAME_POSSESS
                                srPara.ADMINISTRATION_TYPE = "1"
                                srPara.REMARKS = dPara.REMARKS
                                srPara.COMPANY_REGIS_NO = dPara.COMPANY_REGIS_NO
                                srPara.COMPANY_ID = dPara.COMPANY_ID
                                srPara.COMPANY_NAME = dPara.COMPANY_NAME
                                srPara.COMPANY_DOC_NO = dPara.COMPANY_DOC_NO
                                srPara.COMPANY_DOC_DATE = dPara.COMPANY_DOC_DATE
                                srPara.COMPANY_SIGN = dPara.COMPANY_SIGN
                                srPara.COMPANY_SIGN_DATE = dPara.COMPANY_SIGN_DATE
                                srPara.BUSINESS_TYPE_ID = dPara.BUSINESS_TYPE_ID
                                srPara.USERNAME_REGISTER = dPara.USERNAME_REGISTER
                                srPara.ORGANIZATION_ID_REGISTER = dPara.ORGANIZATION_ID_REGISTER
                                srPara.DOCUMENT_RECEIVE_TYPE = dPara.DOCUMENT_RECEIVE_TYPE
                                srPara.REF_DOCUMENT_REGISTER_ID = DocRegisID
                                srPara.REF_TH_EGIF_DOC_INBOUND_ID = "0"
                                srPara.BOOKOUT_DATE = DateNow
                                srPara.BOOKOUT_NO = vBookOutNo

                                Dim srID As Long = eng.SaveDocumentRegister(uPara.UserName, srPara, Nothing, txtScanJobID.Text, trans)
                                If srID > 0 Then
                                    lblKeepBookNo.Text = " เลขที่ : <font color='#0000A0'><b>" & srPara.BOOK_NO & "</b></font>"

                                    Dim iPara As New Para.TABLE.DocumentIntReceiverPara
                                    iPara.DOCUMENT_REGISTER_ID = srID
                                    iPara.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                                    iPara.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_NAME
                                    iPara.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE
                                    iPara.SEND_DATE = DateTime.Now
                                    iPara.SENDER_OFFICER_USERNAME = uPara.UserName
                                    iPara.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                                    iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive

                                    Dim oPara As New Para.TABLE.OrganizationPara
                                    oPara = kEng.GetOrgPara(cmbOrgKeepID.SelectedValue)
                                    iPara.ORGANIZATION_ID_RECEIVE = cmbOrgKeepID.SelectedValue
                                    iPara.ORGANIZATION_NAME_RECEIVE = cmbOrgKeepID.SelectedText
                                    iPara.ORGANIZATION_APPNAME_RECEIVE = oPara.NAME_RECEIVE

                                    ret = eng.SaveInsideSend(uPara.UserName, iPara, trans)

                                    oPara = Nothing
                                    iPara = Nothing
                                    If ret = False Then
                                        _err = eng.ErrorMessage
                                        Exit For
                                    End If
                                Else
                                    ret = False
                                    _err = eng.ErrorMessage
                                    Exit For
                                End If
                                kEng = Nothing
                                kPara = Nothing
                            End If
                        Else
                            _err = eng.ErrorMessage
                            Exit For
                        End If
                        eng = Nothing
                        tmpDt.Dispose()
                    Next
                    If ret = True Then
                        trans.CommitTransaction()
                        ShowPopSendComplete(DocDT, SendDT)

                        zPopSendComplete.Show()
                        RaiseEvent AfterExportClick(sender, e, uPara)
                    Else
                        trans.RollbackTransaction()
                        Config.SetAlert(_err, Me.Page)
                        Response.Redirect("../WebApp/frmSessionExpire.aspx")
                    End If
                Else
                    Config.SetAlert(trans.ErrorMessage, Me.Page)
                    Response.Redirect("../WebApp/frmSessionExpire.aspx")
                End If
            Else
                Response.Redirect("../WebApp/frmSessionExpire.aspx")
            End If
            DocDT.Dispose()
            SendDT.Dispose()
        Else
            zPopShowData.Show()
        End If
        uPara = Nothing
    End Sub

    Private Sub ShowPopSendComplete(ByVal DocDT As DataTable, ByVal SendDT As DataTable)
        Dim dt As New DataTable
        dt.Columns.Add("document_ext_receiver_id")
        dt.Columns.Add("bookout_no")
        dt.Columns.Add("CompanyNameReceive")
        dt.Columns.Add("StaffNameSign")
        dt.Columns.Add("th_egif_org_code")

        For Each DocDR As DataRow In DocDT.Rows
            Dim dPara As Para.TABLE.DocumentRegisterPara = CType(DocDR("DocumentRegisterPara"), Para.TABLE.DocumentRegisterPara)
            If lblCompleteBookNo.Text = "" Then
                lblCompleteBookNo.Text = dPara.BOOK_NO
                lblOrgKeep.Text = dPara.ORGANIZATION_NAME_STORAGE
            Else
                lblCompleteBookNo.Text += ", " & dPara.BOOK_NO
                lblOrgKeep.Text += ", " & dPara.ORGANIZATION_NAME_STORAGE
            End If
        Next
        For Each SendDR As DataRow In SendDT.Rows
            Dim para As Para.TABLE.DocumentExtReceiverPara = CType(SendDR("DocumentExtReceiverPara"), Para.TABLE.DocumentExtReceiverPara)
            Dim dr As DataRow = dt.NewRow
            dr("document_ext_receiver_id") = para.ID
            dr("bookout_no") = para.BOOKOUT_NO
            dr("CompanyNameReceive") = para.COMPANY_NAME_RECEIVE
            dr("StaffNameSign") = para.OFFICER_FULLNAME

            Dim eng As New Engine.Master.CompanyEng
            Dim cPara As New Para.TABLE.CompanyPara
            cPara = eng.GetCompanyPara(para.COMPANY_ID_RECEIVE)
            dr("th_egif_org_code") = cPara.TH_EGIF_ORG_CODE
            dt.Rows.Add(dr)

            para = Nothing
            eng = Nothing
            cPara = Nothing
        Next

        txtBookQty.Text = SendDT.Rows.Count
        If dt.Rows.Count > 0 Then
            gvSendComplete.DataSource = dt
            gvSendComplete.DataBind()
        Else
            gvSendComplete.DataSource = Nothing
            gvSendComplete.DataBind()
        End If
    End Sub

    Protected Sub gvSendComplete_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSendComplete.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim img As ImageButton = grv.FindControl("imgSendToTHeGif")
            If img.Visible = True Then
                img.Attributes.Add("onClick", "SendToTHeGif('" & grv.Cells(4).Text & "','" & img.ClientID & "'); return false;")
                img.ToolTip = "ส่งข้อมูลออนไลน์ไปยัง " & grv.Cells(1).Text
            End If
            'OnClientClick="SendToTHeGif(<%# Bind("document_ext_receiver_id") %>); return false;" 
        End If
    End Sub

    Private Function ValidAddCompany() As Boolean
        Dim ret As Boolean = True
        If txtCustName.Text.Trim = "" Or hdnCustValue.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณเลือกชื่อหน่วยงานรับ", Me.Page, txtCustName.ClientID)
        End If
        If cmbStaffSignID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกชื่อผู้ลงนาม", Me.Page)
        End If
        Return ret
    End Function
    Private Function GetCompanySendList() As DataTable
        Dim ret As New DataTable
        ret = SetSessionCompanyList()
        If gvSendList.Rows.Count > 0 Then
            For Each grv As GridViewRow In gvSendList.Rows
                Dim dr As DataRow = ret.NewRow
                dr("no") = Convert.ToInt16(grv.Cells(ColNo).Text)
                dr("remarks") = grv.Cells(ColRemarks).Text.Replace("&nbsp;", "")
                dr("StaffNameSign") = grv.Cells(ColStaffNameSign).Text
                dr("officer_id") = grv.Cells(ColOfficerID).Text
                dr("CompanyNameReceive") = grv.Cells(ColCompanyNameReceive).Text
                dr("company_id") = grv.Cells(ColCompanyID).Text
                dr("CompanySource") = grv.Cells(ColCompanySource).Text
                dr("CompanyRegisNo") = grv.Cells(ColCompanyRegisNo).Text
                ret.Rows.Add(dr)
            Next
        End If
        Return ret
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        zPopShowData.Show()
        If ValidAddCompany() = True Then
            Dim dt As New DataTable
            dt = GetCompanySendList()

            Dim dr As DataRow = dt.NewRow
            dr("remarks") = txtRemarks.Text
            If cmbStaffSignID.SelectedValue <> "0" Then
                dr("StaffNameSign") = cmbStaffSignID.SelectedText
                dr("officer_id") = cmbStaffSignID.SelectedValue
            End If

            Dim CompanyName As String = txtCustName.Text
            Dim CompanySource As String = ""
            If CompanyName.IndexOf("(" & Constant.CompanySourceType.DMS & ")") > 0 Then
                CompanyName = txtCustName.Text.Replace("(" & Constant.CompanySourceType.DMS & ")", "").Trim
                CompanySource = Constant.CompanySourceType.DMS
            ElseIf CompanyName.IndexOf("(" & Constant.CompanySourceType.BOICENTRAL & ")") > 0 Then
                CompanyName = txtCustName.Text.Replace("(" & Constant.CompanySourceType.BOICENTRAL & ")", "").Trim
                CompanySource = Constant.CompanySourceType.BOICENTRAL
            End If
            dr("CompanyNameReceive") = CompanyName
            dr("company_id") = hdnCustValue.Text
            dr("CompanySource") = CompanySource
            dr("CompanyRegisNo") = hdnCompanyRegisNo.Text
            If txtNo.Text.Trim = "" Then
                dr("no") = dt.Rows.Count + 1
            Else
                dr("no") = Convert.ToInt16(txtNo.Text)
            End If
            If txtIsEdit.Text = "Y" Then
                dt.Rows.RemoveAt(txtRowID.Text)
                dt.Rows.InsertAt(dr, txtRowID.Text)
            Else
                dt.Rows.Add(dr)
            End If
            dt.DefaultView.Sort = "no"
            dt = dt.DefaultView.ToTable
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next
            Config.SaveTransLog("frmSendOutside.ascx คลิกปุ่มเพิ่มชื่อบริษัท " & CompanyName)
            'Session(SessCompanyList) = dt
            gvSendList.DataSource = dt
            gvSendList.DataBind()
            ClearCompanyForm()
            dt.Dispose()
        End If
    End Sub

    Protected Sub gvSendList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSendList.RowCommand
        Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        Dim dt As DataTable = GetCompanySendList() 'Session(SessCompanyList)

        If e.CommandName = "Delete" Then
            Config.SaveTransLog("btnSendOutside.ascx ลบชื่อบริษัท")
            dt.Rows.RemoveAt(index)
            gvSendList.DataSource = dt
            gvSendList.DataBind()
            'Session(SessCompanyList) = dt
        ElseIf e.CommandName = "Edit" Then
            Config.SaveTransLog("btnSendOutside.ascx แก้ไขชื่อบริษัท")
            txtRowID.Text = index
            hdnCustValue.Text = dt.Rows(index)("company_id").ToString
            txtCustName.Text = dt.Rows(index)("CompanyNameReceive").ToString
            cmbStaffSignID.SelectedValue = dt.Rows(index)("officer_id").ToString
            txtRemarks.Text = dt.Rows(index)("remarks").ToString
            txtNo.Text = dt.Rows(index)("no").ToString
            txtIsEdit.Text = "Y"
        End If
        zPopShowData.Show()
    End Sub

    Protected Sub gvSendList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvSendList.RowDeleting

    End Sub
    Protected Sub gvSendList_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvSendList.RowEditing

    End Sub
    Private Sub ClearCompanyForm()
        cmbStaffSignID.SelectedValue = "0"
        txtRemarks.Text = ""
        txtCustName.Text = ""
        hdnCustValue.Text = ""
        hdnCompanyRegisNo.Text = ""
        txtRowID.Text = ""
        txtIsEdit.Text = "N"
        txtNo.Text = ""
    End Sub

    Private Function SetSessionCompanyList() As DataTable
        Dim ret As New DataTable
        ret.Columns.Add("no", GetType(Long))
        ret.Columns.Add("remarks")
        ret.Columns.Add("StaffNameSign")
        ret.Columns.Add("officer_id")
        ret.Columns.Add("CompanyNameReceive")
        ret.Columns.Add("company_id")
        ret.Columns.Add("CompanySource")
        ret.Columns.Add("CompanyRegisNo")
        Return ret
    End Function

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Config.SaveTransLog("btnSendOutside.ascx คลิกปุ่มลบ")
        ClearCompanyForm()
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SendCompleteOK()
        Config.SaveTransLog("btnSendOutside.ascx คลิกปุ่มตกลง")
        RaiseEvent OkClick(sender, e)
    End Sub

    Private Sub SendCompleteOK()
        'Session.Remove(SessCompanyList)
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()

        lblCompleteBookNo.Text = ""
        lblOrgKeep.Text = ""
        lblKeepBookNo.Text = ""

        ClearCompanyForm()

        gvSendComplete.DataSource = Nothing
        gvSendComplete.DataBind()
    End Sub
    
    Protected Sub imgSendCompleteClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSendCompleteClose.Click
        SendCompleteOK()
    End Sub

    Public WriteOnly Property ScanJobID() As String
        Set(ByVal value As String)
            txtScanJobID.Text = value
        End Set
    End Property
End Class
