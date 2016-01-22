Imports System.Data

Partial Class UserControls_Button_btnCloseJob
    Inherits System.Web.UI.UserControl

    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara)
    Public Event NoClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)

    Private Const SessCloseJobList As String = "SessCloseJobList"

    Public WriteOnly Property ButtonText() As String
        Set(ByVal value As String)
            btnButton1.Text = value
        End Set
    End Property

    Public WriteOnly Property CloseJobSuccess() As String
        Set(ByVal value As String)
            txtIsCloseSuccess.Text = value
        End Set
    End Property

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
    End Sub

    Public Sub SetConfirmList(ByVal dt As DataTable)
        gvConfirmCloseList.DataSource = dt
        gvConfirmCloseList.DataBind()
        Session(SessCloseJobList) = dt

        zPopConfirmCloseJob.Show()
    End Sub
    Private Function SetCloseJobList(ByVal dt As DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) As Boolean
        Dim ret As Boolean = False
        If dt.Rows.Count > 0 Then
            Dim _err As String = ""
            dt.Columns.Add("close_by_name")

            If uPara.UserName.Trim <> "" Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)

                    Dim stEng As New Engine.Master.OfficerEng
                    Dim stPara As New Para.TABLE.OfficerPara
                    Dim grv As GridViewRow = gvConfirmCloseList.Rows(i)
                    Dim cmbOfficerIDClose As UserControls_cmbComboBox = grv.FindControl("cmbOfficerIDClose")
                    stPara = stEng.GetOfficerPara(cmbOfficerIDClose.SelectedValue, trans)

                    Dim oOrgaEng As New Engine.Master.OrganizationEng
                    Dim oOrgPara As New Para.TABLE.OrganizationPara
                    oOrgPara = oOrgaEng.GetOrgPara(stPara.ORGANIZATION_ID, trans)

                    Dim dPara As New Para.TABLE.DocumentRegisterPara
                    Dim eng As New Engine.Document.DocumentRegisterENG
                    dPara = eng.GetDocumentPara(Convert.ToInt64(dr("id")), trans)
                    dPara.ORGANIZATION_ID_OWNER = stPara.ORGANIZATION_ID
                    dPara.ORGANIZATION_APPNAME = oOrgPara.NAME_RECEIVE
                    dPara.ORGANIZATION_NAME = oOrgPara.ORG_NAME
                    dPara.OFFICER_ID_APPROVE = stPara.ID
                    dPara.OFFICER_NAME = stPara.FIRST_NAME & " " & stPara.LAST_NAME
                    dPara.OFFICER_ORGANIZATION_ID = stPara.ORGANIZATION_ID

                    dPara.ORGANIZATION_ID_PROCESS = stPara.ORGANIZATION_ID
                    dPara.ORGANIZATION_NAME_PROCESS = oOrgPara.ORG_NAME
                    dPara.ORGANIZATION_ABBNAME_PROCESS = oOrgPara.NAME_RECEIVE
                    dPara.OFFICER_ID_POSSESS = stPara.ID
                    dPara.OFFICER_NAME_POSSESS = stPara.FIRST_NAME & " " & stPara.LAST_NAME

                    dPara.CLOSE_BY = uPara.UserName
                    dPara.CLOSE_BY_NAME = uPara.FirstName & " " & uPara.LastName
                    dPara.CLOSE_DATE = DateTime.Now
                    dPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose
                    dt.Rows(i)("close_by_name") = dPara.CLOSE_BY_NAME

                    Dim txtRemarks As UserControls_txtBox = grv.FindControl("txtRemarks")
                    dPara.CLOSE_REMARKS = txtRemarks.Text
                    Dim cmbOrgIDStorage As UserControls_cmbComboBox = grv.FindControl("cmbOrgIDStorage")
                    If cmbOrgIDStorage.SelectedValue <> "0" Then
                        dPara.ORGANIZATION_ID_STORAGE = cmbOrgIDStorage.SelectedValue
                        dPara.ORGANIZATION_NAME_STORAGE = cmbOrgIDStorage.SelectedText
                    End If
                    ret = (eng.SaveDocumentRegister(uPara.UserName, dPara, Session(Para.Common.Utilities.Constant.SessFileUploadList), txtScanJobID.Text, trans) > 0)

                    Config.SaveTransLog("btnCloseJob.ascx : จบงาน เลขที่หนังสือ : " & dPara.BOOK_NO, uPara.LOGIN_HISTORY_ID)
                    If ret = True Then
                        If cmbOfficerIDClose.SelectedValue <> "0" Then
                            Dim DateNow As DateTime = DateTime.Now
                            Dim dSend As New Para.TABLE.DocumentIntReceiverPara
                            dSend.DOCUMENT_REGISTER_ID = dPara.ID
                            dSend.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                            dSend.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
                            dSend.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE   'ชื่อย่อหน่วยงานผู้ส่ง
                            dSend.SEND_DATE = DateNow
                            dSend.SENDER_OFFICER_USERNAME = uPara.UserName
                            dSend.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName

                            dSend.RECEIVE_DATE = DateNow
                            dSend.RECEIVER_OFFICER_FULLNAME = stPara.FIRST_NAME & " " & stPara.LAST_NAME
                            dSend.RECEIVER_OFFICER_USERNAME = stPara.USERNAME
                            dSend.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received

                            Dim oStPara As New Para.TABLE.OrganizationPara
                            Dim oStEng As New Engine.Master.OrganizationEng
                            oStPara = oStEng.GetOrgPara(stPara.ORGANIZATION_ID, trans)
                            dSend.ORGANIZATION_ID_RECEIVE = stPara.ORGANIZATION_ID
                            dSend.ORGANIZATION_NAME_RECEIVE = oStPara.ORG_NAME
                            dSend.ORGANIZATION_APPNAME_RECEIVE = oStPara.NAME_RECEIVE
                            dSend.REMARKS = txtRemarks.Text

                            ret = eng.SaveInsideSend(uPara.UserName, dSend, trans)
                            If ret = False Then
                                _err = eng.ErrorMessage
                            End If
                            dSend = Nothing

                            oStPara = Nothing
                            oStEng = Nothing
                        End If

                        If ret = True Then
                            'กรณีหน่วยงานจัดเก็บไม่ใช่หน่วยงานตัวเอง ให้ออกเลขและส่งไปจัดเก็บด้วย
                            If dPara.ORGANIZATION_ID_STORAGE <> uPara.ORG_DATA.ID Then
                                'บันทึกข้อมูลสำหรับส่งภายในไปให้กับหน่วยงานจัดเก็บ
                                Dim vStorageAbbName As String = GetStorageAbbName(cmbOrgIDStorage.SelectedValue, trans)
                                Dim vNewBookNo As String = dPara.BOOK_NO
                                If vStorageAbbName.Trim <> "" Then
                                    vNewBookNo = dPara.BOOK_NO & "/" & vStorageAbbName
                                End If

                                Dim srPara As New Para.TABLE.DocumentRegisterPara
                                srPara.BOOK_NO = vNewBookNo
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
                                srPara.ORGANIZATION_ID_STORAGE = dPara.ORGANIZATION_ID_STORAGE
                                srPara.ORGANIZATION_NAME_STORAGE = dPara.ORGANIZATION_NAME_STORAGE
                                srPara.REF_DOCUMENT_REGISTER_ID = dPara.ID
                                srPara.CLOSE_BY = dPara.CLOSE_BY
                                srPara.CLOSE_BY_NAME = dPara.CLOSE_BY_NAME
                                srPara.CLOSE_DATE = dPara.CLOSE_DATE
                                srPara.CLOSE_REMARKS = dPara.CLOSE_REMARKS
                                srPara.REF_TH_EGIF_DOC_INBOUND_ID = dPara.REF_TH_EGIF_DOC_INBOUND_ID
                                srPara.BOOKOUT_DATE = dPara.BOOKOUT_DATE
                                srPara.BOOKOUT_NO = dPara.BOOKOUT_NO

                                Dim srID As Long = eng.SaveDocumentRegister(uPara.UserName, srPara, Nothing, txtScanJobID.Text, trans)
                                If srID > 0 Then
                                    Config.SaveTransLog("btnCloseJob.ascx : จบงาน เลขที่ส่งเก็บ : " & srPara.BOOK_NO, uPara.LOGIN_HISTORY_ID)
                                    Dim iPara As New Para.TABLE.DocumentIntReceiverPara
                                    iPara.DOCUMENT_REGISTER_ID = srID
                                    iPara.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                                    iPara.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
                                    iPara.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE
                                    iPara.SEND_DATE = DateTime.Now
                                    iPara.SENDER_OFFICER_USERNAME = uPara.UserName
                                    iPara.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                                    iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive

                                    Dim stoEng As New Engine.Master.OrganizationEng
                                    Dim oPara As New Para.TABLE.OrganizationPara
                                    oPara = stoEng.GetOrgPara(cmbOrgIDStorage.SelectedValue, trans)
                                    iPara.ORGANIZATION_ID_RECEIVE = cmbOrgIDStorage.SelectedValue
                                    iPara.ORGANIZATION_NAME_RECEIVE = cmbOrgIDStorage.SelectedText
                                    iPara.ORGANIZATION_APPNAME_RECEIVE = oPara.NAME_RECEIVE
                                    stEng = Nothing
                                    stPara = Nothing
                                    oPara = Nothing
                                    stoEng = Nothing

                                    ret = eng.SaveInsideSend(uPara.UserName, iPara, trans)
                                    If ret = False Then
                                        _err = eng.ErrorMessage
                                        Exit For
                                    End If
                                Else
                                    ret = False
                                    _err = eng.ErrorMessage
                                    Exit For
                                End If
                            End If
                        Else
                            _err = eng.ErrorMessage
                        End If
                    Else
                        _err = eng.ErrorMessage
                        Exit For
                    End If
                    dPara = Nothing
                    eng = Nothing

                    stPara = Nothing
                    stEng = Nothing
                Next
            Else
                _err = "เกิดความผิดพลาดในขณะบันทึกข้อมูล ไม่สามารถบันทึกข้อมูลได้"
            End If

            If ret = True Then
                gvCloseList.DataSource = dt
                gvCloseList.DataBind()
                Session.Remove(SessCloseJobList)
                zPopClosedJob.Show()
            Else
                Config.SetAlert(_err, Me.Page)
            End If
        Else
            Config.SetAlert("เกิดข้อผิดพลาด ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", Me.Page)
        End If

        Return ret
    End Function

    Private Function GetStorageAbbName(ByVal OrgID As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
        Dim vStorageAbbName As String = ""
        Dim stoEng As New Engine.Master.OrganizationEng
        Dim stoPara As New Para.TABLE.OrganizationStoragePara
        stoPara = stoEng.GetOrgStoragePara(OrgID, trans)
        vStorageAbbName = stoPara.STORAGE_ABB_NAME.Trim

        If vStorageAbbName.Trim = "" Then
            If Session("OrgStorageList") IsNot Nothing Then
                Dim stDt As New DataTable
                stDt = DirectCast(Session("OrgStorageList"), DataTable)
                If stDt.Rows.Count > 0 Then
                    stDt.DefaultView.RowFilter = "organization_id='" & OrgID & "'"
                    If stDt.DefaultView.Count > 0 Then
                        vStorageAbbName = stDt.DefaultView(0)("storage_abb_name")
                    End If
                End If
                stDt.Dispose()
            End If
        End If
        stoEng = Nothing
        stoPara = Nothing

        Return vStorageAbbName
    End Function


    Private Const ColID As Int16 = 0
    Private Const ColBookNo As Int16 = 1
    Private Const ColBookTitle As Int16 = 2
    Private Function GetCloseJobList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("book_no")
        dt.Columns.Add("book_title")
        If gvConfirmCloseList.Rows.Count > 0 Then
            For Each grv As GridViewRow In gvConfirmCloseList.Rows
                Dim dr As DataRow = dt.NewRow
                dr("id") = grv.Cells(ColID).Text
                dr("book_no") = grv.Cells(ColBookNo).Text
                dr("book_title") = grv.Cells(ColBookTitle).Text
                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim ret As Boolean = False

        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.UserName.Trim <> "" Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            If trans.CreateTransaction() = True Then
                Dim dt As New DataTable
                dt = GetCloseJobList()
                If dt IsNot Nothing Then
                    RaiseEvent YesClick(sender, e, dt, trans, uPara)
                    If txtIsCloseSuccess.Text.Trim = "Y" Then
                        ret = SetCloseJobList(dt, trans, uPara)
                    End If
                End If

                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    Config.SetAlert("เกิดข้อผิดพลาด ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", Me.Page)
                    Config.SaveErrorLog("เกิดข้อผิดพลาด ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", uPara.LOGIN_HISTORY_ID)
                    Response.Redirect("../WebApp/frmSessionExpire.aspx")
                End If
            Else
                Config.SetAlert(trans.ErrorMessage, Me.Page)
                Config.SaveErrorLog(trans.ErrorMessage, uPara.LOGIN_HISTORY_ID)
                Response.Redirect("../WebApp/frmSessionExpire.aspx")
            End If
        Else
            Config.SetAlert("เกิดข้อผิดพลาด ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", Me.Page)
            Config.SaveErrorLog("เกิดข้อผิดพลาด ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", uPara.LOGIN_HISTORY_ID)
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
        End If
        
        uPara = Nothing
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Session.Remove(SessCloseJobList)
        txtIsCloseSuccess.Text = "N"
        Config.SaveTransLog("btnCloseJob.ascx : คลิกปุ่ม ตกลง", uPara.LOGIN_HISTORY_ID)
        RaiseEvent OKClick(sender, e, uPara)
        uPara = Nothing
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        txtIsCloseSuccess.Text = "N"
        RaiseEvent NoClick(sender, e)
        Config.SaveTransLog("btnCloseJob.ascx : คลิกปุ่ม ไม่ใช่", Config.GetLoginHistoryID)
        Session.Remove(SessCloseJobList)
    End Sub

    Protected Sub gvConfirmCloseList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvConfirmCloseList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim cmbOrgIDStorage As UserControls_cmbComboBox = grv.FindControl("cmbOrgIDStorage")

            Dim uPara As New Para.Common.UserProfilePara
            uPara = Config.GetLogOnUser
            Dim eng As New Engine.Master.OrganizationEng
            Dim dt As New DataTable
            dt = eng.GetOrgStorageList()
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.NewRow
                dr("id") = uPara.ORG_DATA.ID
                dr("org_name") = uPara.ORG_DATA.ORG_NAME
                dt.Rows.InsertAt(dr, 0)
                cmbOrgIDStorage.SetItemList(dt, "org_name", "id")
            End If
            dt = Nothing
            eng = Nothing

            Dim cmbOfficerIDClose As UserControls_cmbComboBox = grv.FindControl("cmbOfficerIDClose")
            Dim sEng As New Engine.Master.OrganizationEng
            Dim sDt As New DataTable
            sDt = sEng.GetStaffByOrgID(uPara.ORG_DATA.ID)
            If sDt.Rows.Count > 0 Then
                cmbOfficerIDClose.SetItemList(sDt, "staff_name", "id")

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim dDoc As New Para.TABLE.DocumentRegisterPara
                Dim dEng As New Engine.Document.DocumentRegisterENG
                dDoc = dEng.GetDocumentPara(grv.Cells(0).Text, trans)
                cmbOfficerIDClose.SelectedValue = dDoc.OFFICER_ID_APPROVE
                dDoc = Nothing
                dEng = Nothing
                trans.CommitTransaction()

                sDt = Nothing
            End If
            sEng = Nothing
        End If
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        RaiseEvent NoClick(sender, e)
        Session.Remove(SessCloseJobList)
        txtIsCloseSuccess.Text = "N"
        Config.SaveTransLog("btnCloseJob.ascx : คลิกปุ่มปิด", Config.GetLoginHistoryID)
    End Sub

    Public WriteOnly Property ScanJobID() As String
        Set(ByVal value As String)
            txtScanJobID.Text = value
        End Set
    End Property
End Class
