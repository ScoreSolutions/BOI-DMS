Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Web.UI
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class WebApp_frmDocFormBookOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("SessReferTo")
            Session.Remove("SessAttach")

            If Request.QueryString("docformid") Is Nothing Then
                docid = 0
            Else
                docid = CInt(Request.QueryString("docformid"))
            End If

            If Request.QueryString("rowid") Is Nothing Then
                edit_mode = new_data
                rowid.Text = ""
                edit_rowid = "0"
            Else
                edit_mode = edit_data
                edit_rowid = Request.QueryString("rowid")
                rowid.Text = Request.QueryString("rowid")
                txtRefID.Text = getdatafld("select isnull(id_ref,id) id from doc_trans where id='" & rowid.Text & "'", "id")
                SetDocRead()
            End If
            SetVisibleForm()
            SetVisibleButton()
        End If

        btnPrint.Attributes.Remove("onClick")
        btnPrint.Attributes.Add("onClick", "PrintReport('" & txtReportName.Text & "','" & rowid.Text & "'); return false;")
    End Sub

    Private Sub SetDocRead()
        Dim IsRead As Boolean = True
        Dim sSql As String = "select is_read from DOC_TRANS where id='" & rowid.Text & "' "
        Dim dt As New DataTable
        dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sSql)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("is_read").ToString = "N" Then
                IsRead = False
            End If
            dt = Nothing
        End If

        If IsRead = False Then
            'ถ้ายังไม่เปิดอ่าน ก็ให้ Update ว่าอ่านแล้ว
            Dim sql As String = "update DOC_TRANS "
            sql += " set is_read = 'Y'"
            sql += " where id='" & rowid.Text & "'"

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sql, trans.Trans) > 0 Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        End If
    End Sub

    Private Sub SetVisibleButton()
        If Request.Params("approved_mode") = "yes" Then
            'Disable 
            btnCancel.Visible = False
            btnSave.Visible = False
            btnSaveSend.Visible = False
            btnSend.Visible = False
            btnSendBack.Visible = False

            'visable
            btnPrint.Visible = True
            btnApprove.Visible = True
            btnNotApprove.Visible = True

            edit_mode = edit_data
            load_form(docid)

            status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")
            If CInt(status_id.Text) = CInt(cfg_docapproved) Then
                btnSend.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = False
                btnApprove.Visible = False
                btnSave.Visible = False
                btnSaveSend.Visible = False
                btnNotApprove.Visible = False
            ElseIf CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                btnSend.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = True
                btnApprove.Visible = False
                btnSave.Visible = True
                btnSaveSend.Visible = True
                btnNotApprove.Visible = False
            End If
        End If

        If Request.Params("approved_mode") = "no" Then
            'Disable 
            btnSaveSend.Visible = False
            btnApprove.Visible = False
            btnNotApprove.Visible = False

            'visable
            btnCancel.Visible = True
            btnSave.Visible = True
            btnPrint.Visible = True
            btnSend.Visible = True
            btnSendBack.Visible = True

            edit_mode = edit_data
            load_form(docid)

            status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")
            If CInt(status_id.Text) = CInt(cfg_docapproved) Or CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                btnSend.Visible = False
                btnSendBack.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = False
                btnApprove.Visible = False
                btnNotApprove.Visible = False
                btnSave.Visible = False
                btnSaveSend.Visible = False
            ElseIf CInt(status_id.Text) = CInt(cfg_docissend) Then
                'ถ้าสถานะเป็นส่งแล้ว
                btnSend.Visible = False
                btnSendBack.Visible = False
            ElseIf CInt(status_id.Text) = CInt(cfg_docnoapproveedit) Then
                btnSave.Visible = True
                btnSaveSend.Visible = True
                btnCancel.Visible = True
                btnPrint.Visible = True
                btnSend.Visible = False
                btnSendBack.Visible = False

            ElseIf CInt(status_id.Text) = CInt(cfg_docnoapprovesend) Then
                'กรณีแก้ไข และส่งไปแล้ว
                btnSave.Visible = False
                btnSaveSend.Visible = False
                btnCancel.Visible = False
                btnPrint.Visible = True
                btnSend.Visible = False
                btnSendBack.Visible = False
            End If
        End If

        If Request.Params("approved_mode") = Nothing Then
            btnSend.Visible = True
            btnSendBack.Visible = True
            btnPrint.Visible = True
            btnCancel.Visible = True
            btnApprove.Visible = True
            btnNotApprove.Visible = True
            btnSave.Visible = True
            btnSaveSend.Visible = True

            If edit_mode = edit_data Then
                status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")

                load_form(docid)

                btnApprove.Visible = False
                btnNotApprove.Visible = False

                If CInt(status_id.Text) = CInt(cfg_docstart) Then
                    btnSend.Visible = False
                End If

                If CInt(status_id.Text) >= CInt(cfg_docissend) Then
                    btnSend.Visible = False
                    btnSendBack.Visible = False
                    btnCancel.Visible = False
                    btnSave.Visible = False
                    btnSaveSend.Visible = False
                End If

                If CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                    btnSend.Visible = False
                    btnSendBack.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = True
                    btnApprove.Visible = False
                    btnNotApprove.Visible = False
                    btnSave.Visible = True
                    btnSaveSend.Visible = True
                End If

                If CInt(status_id.Text) = CInt(cfg_docnoapproveedit) Then
                    btnSend.Visible = False
                    btnSendBack.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = True
                    btnApprove.Visible = False
                    btnNotApprove.Visible = False
                    btnSave.Visible = True
                    btnSaveSend.Visible = True
                End If

                If CInt(status_id.Text) = CInt(cfg_docapproved) Then
                    btnSend.Visible = False
                    btnSendBack.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = False
                    btnApprove.Visible = False
                    btnNotApprove.Visible = False
                    btnSave.Visible = False
                    btnSaveSend.Visible = False
                End If
                'btnPrint.Attributes.Add("onClick", "PrintReport('" & txtReportName.Text & "','" & rowid.Text & "'); return false;")
            Else
                btnSend.Visible = False
                btnSendBack.Visible = False
                btnPrint.Visible = False
                btnApprove.Visible = False
                btnNotApprove.Visible = False
            End If
        End If
    End Sub

    Private Sub SetAllVisibleFalse()
        incBookOut1.Visible = False
        incBookIn1.Visible = False
        incBookSeal1.Visible = False
        incBookCommand1.Visible = False
        incBookPublicRelation1.Visible = False
        incBookEvidence1.Visible = False
    End Sub

    Private Sub SetVisibleForm()
        SetAllVisibleFalse()

        If docid <> 0 Then
            docname.Text = Array_docname(docid - 1)
            If docid = FormBookOutID Then
                incBookOut1.Visible = True
                txtReportName.Text = "BOI_1"
            ElseIf docid = FormBookInID Then
                incBookIn1.Visible = True
                txtReportName.Text = "BOI_2"
            ElseIf docid = FormBookSealID Then
                incBookSeal1.Visible = True
                txtReportName.Text = "BOI_3"
            ElseIf docid = FormBookCommandID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleCommand = True
                txtReportName.Text = "BOI_4"
            ElseIf docid = FormBookRuleID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleRule = True
                txtReportName.Text = "BOI_5"
            ElseIf docid = FormBookRegulationID Then
                incBookCommand1.Visible = True
                incBookCommand1.VisibleAll = False
                incBookCommand1.VisibleRegulation = True
                txtReportName.Text = "BOI_6"
            ElseIf docid = FormBookNoticeID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleNotice = True
                txtReportName.Text = "BOI_7"
            ElseIf docid = FormBookStateID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleState = True
                txtReportName.Text = "BOI_8"
            ElseIf docid = FormBookNewsID Then
                incBookPublicRelation1.Visible = True
                incBookPublicRelation1.VisibleAll = False
                incBookPublicRelation1.VisibleNews = True
                txtReportName.Text = "BOI_9"
            ElseIf docid = FormBookAssureID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleAssure = True
                txtReportName.Text = "BOI_10"
            ElseIf docid = FormBookMinutesID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleMinutes = True
                txtReportName.Text = "BOI_11"
            ElseIf docid = FormBookNoteID Then
                incBookEvidence1.Visible = True
                incBookEvidence1.VisibleAll = False
                incBookEvidence1.VisibleNote = True
                txtReportName.Text = "BOI_12"
            End If
        End If
    End Sub

    Private Function Get_lastrecordNo(ByVal username As String, ByVal doc_type As String) As String
        condb()

        Dim sqltxt As String

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()
        sqltxt = "select id from DOC_TRANS where doc_create_by = '" + username + "' and doc_type = " + doc_type + " order by id desc "
        Da = New SqlDataAdapter(sqltxt, conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            Return Ds.Tables("DATA").Rows(0).Item("id").ToString
        Else
            Return ""
        End If
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim status As String
        If save_form(docid) Then
            If edit_mode = new_data Then
                edit_mode = edit_data
                'rowid.Text = Get_lastrecordNo(Config.GetLogOnUser.UserName, docid.ToString)
                rowid.Text = GetLastID("DOC_TRANS")
            Else
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapprove Then update_status(cfg_docnoapproveedit, "DOC_TRANS", rowid.Text)
            End If
            btnPrint.Visible = True
            btnPrint.Attributes.Add("onClick", "PrintReport('" & txtReportName.Text & "','" & rowid.Text & "'); return false;")
            Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
        Else
            If sys_err <> "" Then
                Config.SetAlert(sys_err, Me)
            End If
        End If
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        SetObjective()
        cmbOfficeSignID.Items.Clear()
        popup1.Show()
    End Sub

    Protected Sub btnSendBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendBack.Click
        popSendBack.Show()
    End Sub

    Protected Sub btnSendBackNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendBackNow.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If txtSendBackRemarks.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุหมายเหตุ", Me)
            popSendBack.Show()
            Exit Sub
        End If

        sqltmp = "INSERT INTO DOC_TRANS (" & vbNewLine
        sqltmp += " [id_ref],[doc_no],[doc_secret],[doc_speed],[doc_date1]" & vbNewLine
        sqltmp += ",[doc_date2],[doc_OrgBookOwner],[doc_OwnerAddress],[doc_title]" & vbNewLine
        sqltmp += ",[doc_titleCommand],[doc_refno],[doc_title_when],[doc_title_at]" & vbNewLine
        sqltmp += ",[doc_title_regis],[doc_title_meet],[doc_title_nomeet],[doc_title_group]" & vbNewLine
        sqltmp += ",[doc_memo_woner],[doc_content],[doc_lean],[doc_refto],[doc_attach]" & vbNewLine
        sqltmp += ",[doc_poscript],[doc_officeSign],[doc_position],[doc_positionSign]" & vbNewLine
        sqltmp += ",[doc_TitleOwner],[doc_tel],[doc_fax],[doc_addr],[doc_ccto]" & vbNewLine
        sqltmp += ",[doc_detail],[doc_type],[doc_user],[doc_status],[doc_status_date]" & vbNewLine
        sqltmp += ",[doc_create_date],[doc_create_by]" & vbNewLine
        sqltmp += ",[doc_send_by],[doc_send_date],[doc_org_from],[doc_to],[doc_org_to]" & vbNewLine
        sqltmp += ",[doc_obj_to],[doc_approved],[doc_OwnerAddress2],[sendback_remarks])" & vbNewLine

        sqltmp += " select [id_ref],[doc_no],[doc_secret],[doc_speed],[doc_date1]" & vbNewLine
        sqltmp += ",[doc_date2],[doc_OrgBookOwner],[doc_OwnerAddress],[doc_title]" & vbNewLine
        sqltmp += ",[doc_titleCommand],[doc_refno],[doc_title_when],[doc_title_at]" & vbNewLine
        sqltmp += ",[doc_title_regis],[doc_title_meet],[doc_title_nomeet],[doc_title_group]" & vbNewLine
        sqltmp += ",[doc_memo_woner],[doc_content],[doc_lean],[doc_refto],[doc_attach]" & vbNewLine
        sqltmp += ",[doc_poscript],[doc_officeSign],[doc_position],[doc_positionSign]" & vbNewLine
        sqltmp += ",[doc_TitleOwner],[doc_tel],[doc_fax],[doc_addr],[doc_ccto]" & vbNewLine
        sqltmp += ",[doc_detail],[doc_type],[doc_user],'" + cfg_docnoapproveedit + "',getdate()" & vbNewLine
        sqltmp += ",getdate(),'" + uPara.UserName + "'" & vbNewLine

        Dim SqlDocTmp As String = "select o.id, og.org_code "
        SqlDocTmp += " from DOC_TRANS dt "
        SqlDocTmp += " inner join officer o on o.username=dt.doc_create_by "
        SqlDocTmp += " inner join organization og on og.id=o.organization_id"
        SqlDocTmp += " where dt.id='" & txtRefID.Text & "'"
        Dim vDocToID As New DataTable
        vDocToID = getdatatable(SqlDocTmp)
        sqltmp += ",'" + uPara.UserName + "', getdate(),'" + uPara.ORG_DATA.ORG_CODE + "','" & vDocToID.Rows(0)("id").ToString & "','" & vDocToID.Rows(0)("org_code").ToString & "'" & vbNewLine
        sqltmp += ",[doc_obj_to], [doc_approved],[doc_OwnerAddress2],'" & txtSendBackRemarks.Text.Trim & "'" & vbNewLine
        sqltmp += " from DOC_TRANS where id = " + rowid.Text
        vDocToID = Nothing

        Dim lnq As New Linq.TABLE.DocStatusLinq
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp, trans.Trans) > 0 Then
            If CopyDocChildItem(rowid.Text, trans) = True Then
                trans.CommitTransaction()
                'Change status
                change_status(cfg_docnoapproveedit, cfg_docnoapprovesend, cfg_docissend, "DOC_TRANS", rowid.Text)

                UpdateIsSend()

                Dim status As String
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapproveedit Then update_status(cfg_docnoapprovesend, "DOC_TRANS", rowid.Text)

                btnSave.Visible = False
                btnSaveSend.Visible = False
                btnCancel.Visible = False
                btnPrint.Visible = True
                btnSend.Visible = False
                btnSendBack.Visible = False

                Master.GetModule(uPara)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(Linq.Common.Utilities.SqlDB.ErrorMessage, Me)
            End If
        Else
            trans.RollbackTransaction()
            Config.SetAlert(Linq.Common.Utilities.SqlDB.ErrorMessage, Me)
        End If
    End Sub



    Protected Sub btnSaveSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveSend.Click
        Dim status As String
        If save_form(docid) Then
            If edit_mode = new_data Then
                edit_mode = edit_data
                'rowid.Text = Get_lastrecordNo(Config.GetLogOnUser.UserName, docid.ToString)
                rowid.Text = GetLastID("DOC_TRANS")
            Else
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapprove Then update_status(cfg_docnoapproveedit, "DOC_TRANS", rowid.Text)
            End If
            SetObjective()
            cmbOfficeSignID.Items.Clear()
            popup1.Show()
        Else
            If sys_err <> "" Then
                Config.SetAlert(sys_err, Me)
            End If
        End If
    End Sub

    Private Function load_form(ByVal FdocID As Integer) As Boolean
        If FdocID <> 0 Then
            If FdocID = FormBookOutID Then
                incBookOut1.load_trans(True, rowid.Text)
            ElseIf FdocID = FormBookInID Then
                incBookIn1.load_trans(True, rowid.Text)
            ElseIf FdocID = FormBookSealID Then
                incBookSeal1.load_trans(True, rowid.Text)
            ElseIf FdocID = FormBookCommandID Then
                incBookCommand1.load_trans(True, rowid.Text, FormBookCommandID)
            ElseIf FdocID = FormBookRuleID Then
                incBookCommand1.load_trans(True, rowid.Text, FormBookRuleID)
            ElseIf FdocID = FormBookRegulationID Then
                incBookCommand1.load_trans(True, rowid.Text, FormBookRegulationID)
            ElseIf FdocID = FormBookNoticeID Then
                incBookPublicRelation1.load_trans(True, rowid.Text, FormBookNoticeID)
            ElseIf FdocID = FormBookStateID Then
                incBookPublicRelation1.load_trans(True, rowid.Text, FormBookStateID)
            ElseIf FdocID = FormBookNewsID Then
                incBookPublicRelation1.load_trans(True, rowid.Text, FormBookNewsID)
            ElseIf FdocID = FormBookAssureID Then
                incBookEvidence1.load_trans(True, rowid.Text, FormBookAssureID)
            ElseIf FdocID = FormBookMinutesID Then
                incBookEvidence1.load_trans(True, rowid.Text, FormBookMinutesID)
            ElseIf FdocID = FormBookNoteID Then
                incBookEvidence1.load_trans(True, rowid.Text, FormBookNoteID)
            End If
        End If
    End Function

    Private Function save_form(ByVal FdocID As Integer) As Boolean
        If FdocID <> 0 Then
            If FdocID = FormBookOutID Then
                If incBookOut1.save_trans(True, rowid.Text) Then Return True Else Return False
            ElseIf FdocID = FormBookInID Then
                If incBookIn1.save_trans(True, rowid.Text) Then Return True Else Return False
            ElseIf FdocID = FormBookSealID Then
                If incBookSeal1.save_trans(True, rowid.Text) Then Return True Else Return False
            ElseIf FdocID = FormBookCommandID Then
                If incBookCommand1.save_trans(True, rowid.Text, FormBookCommandID) Then Return True Else Return False
            ElseIf FdocID = FormBookRuleID Then
                If incBookCommand1.save_trans(True, rowid.Text, FormBookRuleID) Then Return True Else Return False
            ElseIf FdocID = FormBookRegulationID Then
                If incBookCommand1.save_trans(True, rowid.Text, FormBookRegulationID) Then Return True Else Return False
            ElseIf FdocID = FormBookNoticeID Then
                If incBookPublicRelation1.save_trans(True, rowid.Text, FormBookNoticeID) Then Return True Else Return False
            ElseIf FdocID = FormBookStateID Then
                If incBookPublicRelation1.save_trans(True, rowid.Text, FormBookStateID) Then Return True Else Return False
            ElseIf FdocID = FormBookNewsID Then
                If incBookPublicRelation1.save_trans(True, rowid.Text, FormBookNewsID) Then Return True Else Return False
            ElseIf FdocID = FormBookAssureID Then
                If incBookEvidence1.save_trans(True, rowid.Text, FormBookAssureID) Then Return True Else Return False
            ElseIf FdocID = FormBookMinutesID Then
                If incBookEvidence1.save_trans(True, rowid.Text, FormBookMinutesID) Then Return True Else Return False
            ElseIf FdocID = FormBookNoteID Then
                If incBookEvidence1.save_trans(True, rowid.Text, FormBookNoteID) Then Return True Else Return False
            End If
        End If
    End Function

    Private Function clear_form(ByVal FdocID As Integer) As Boolean
        If FdocID <> 0 Then
            If FdocID = FormBookOutID Then
                incBookOut1.clear(True, rowid.Text)
            ElseIf FdocID = FormBookInID Then
                incBookIn1.clear(True, rowid.Text)
            ElseIf FdocID = FormBookSealID Then
                incBookSeal1.clear(True, rowid.Text)
            ElseIf FdocID = FormBookCommandID Then
                incBookCommand1.clear(True, rowid.Text, FormBookCommandID)
            ElseIf FdocID = FormBookRuleID Then
                incBookCommand1.clear(True, rowid.Text, FormBookRuleID)
            ElseIf FdocID = FormBookRegulationID Then
                incBookCommand1.clear(True, rowid.Text, FormBookRegulationID)
            ElseIf FdocID = FormBookNoticeID Then
                incBookPublicRelation1.clear(True, rowid.Text, FormBookNoticeID)
            ElseIf FdocID = FormBookStateID Then
                incBookPublicRelation1.clear(True, rowid.Text, FormBookStateID)
            ElseIf FdocID = FormBookNewsID Then
                incBookPublicRelation1.clear(True, rowid.Text, FormBookNewsID)
            ElseIf FdocID = FormBookAssureID Then
                incBookEvidence1.clear(True, rowid.Text, FormBookAssureID)
            ElseIf FdocID = FormBookMinutesID Then
                incBookEvidence1.clear(True, rowid.Text, FormBookMinutesID)
            ElseIf FdocID = FormBookNoteID Then
                incBookEvidence1.clear(True, rowid.Text, FormBookNoteID)
            End If
        End If
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear_form(docid)
    End Sub

    Private Sub SetObjective()
        Dim dt As DataTable

        sqltmp = "select distinct id,objective_name from DOC_OBJECTIVE "

        dt = GetDataToList(sqltmp)
        cmbObjTo.SetItemList(dt, "objective_name", "id")
        dt = Nothing
    End Sub

    Private Function CopyDocChildItem(ByVal vSourceID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = True
        Try
            Dim vDocLastID As Long = Linq.Common.Utilities.SqlDB.GetLastID("DOC_TRANS", trans.Trans)
            Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
            Dim DateNowStr As String = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss", New Globalization.CultureInfo("en-US"))

            Dim aDt As New DataTable
            Dim aLnq As New Linq.TABLE.DocTransAttachLinq
            aDt = aLnq.GetDataList("doc_trans_id = '" & vSourceID.ToString & "'", "id", trans.Trans)
            If aDt.Rows.Count > 0 Then
                For Each aDr As DataRow In aDt.Rows
                    aLnq = New Linq.TABLE.DocTransAttachLinq
                    aLnq.DOC_TRANS_ID = vDocLastID
                    aLnq.ATTACH = aDr("attach").ToString
                    ret = aLnq.InsertData(uPara.UserName, trans.Trans)
                    If ret = False Then
                        Exit For
                    End If
                Next
            End If

            If ret = True Then
                Dim rDt As New DataTable
                Dim rLnq As New Linq.TABLE.DocTransReferLinq
                rDt = rLnq.GetDataList("doc_trans_id = '" & vSourceID.ToString & "'", "id", trans.Trans)
                If rDt.Rows.Count > 0 Then
                    For Each rDr As DataRow In rDt.Rows
                        rLnq = New Linq.TABLE.DocTransReferLinq
                        rLnq.DOC_TRANS_ID = vDocLastID
                        rLnq.REFER_TO = rDr("refer_to").ToString
                        ret = rLnq.InsertData(uPara.UserName, trans.Trans)
                        If ret = False Then
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            ret = False
        End Try
        
        Return ret
    End Function

    Protected Sub btnSendDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendDoc.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If cmbTitleOwnerTo.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกหน่วยงานที่รับ", Me)
            popup1.Show()
            Exit Sub
        End If
        If cmbObjTo.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกวัตถุประสงค์การส่ง", Me)
            popup1.Show()
            Exit Sub
        End If

        sqltmp = "INSERT INTO DOC_TRANS ("
        sqltmp = sqltmp + " [id_ref],[doc_no]"
        sqltmp = sqltmp + ",[doc_secret]"
        sqltmp = sqltmp + ",[doc_speed]"
        sqltmp = sqltmp + ",[doc_date1]"
        sqltmp = sqltmp + ",[doc_date2]"
        sqltmp = sqltmp + ",[doc_OrgBookOwner]"
        sqltmp = sqltmp + ",[doc_OwnerAddress]"
        sqltmp = sqltmp + ",[doc_title]"
        sqltmp = sqltmp + ",[doc_titleCommand]"
        sqltmp = sqltmp + ",[doc_refno]"
        sqltmp = sqltmp + ",[doc_title_when]"
        sqltmp = sqltmp + ",[doc_title_at]"
        sqltmp = sqltmp + ",[doc_title_regis]"
        sqltmp = sqltmp + ",[doc_title_meet]"
        sqltmp = sqltmp + ",[doc_title_nomeet]"
        sqltmp = sqltmp + ",[doc_title_group]"
        sqltmp = sqltmp + ",[doc_memo_woner]"
        sqltmp = sqltmp + ",[doc_content]"
        sqltmp = sqltmp + ",[doc_lean]"
        sqltmp = sqltmp + ",[doc_refto]"
        sqltmp = sqltmp + ",[doc_attach]"
        sqltmp = sqltmp + ",[doc_poscript]"
        sqltmp = sqltmp + ",[doc_officeSign]"
        sqltmp = sqltmp + ",[doc_position]"
        sqltmp = sqltmp + ",[doc_positionSign]"
        sqltmp = sqltmp + ",[doc_TitleOwner]"
        sqltmp = sqltmp + ",[doc_tel]"
        sqltmp = sqltmp + ",[doc_fax]"
        sqltmp = sqltmp + ",[doc_addr]"
        sqltmp = sqltmp + ",[doc_ccto]"
        sqltmp = sqltmp + ",[doc_detail]"
        sqltmp = sqltmp + ",[doc_type]"
        sqltmp = sqltmp + ",[doc_user]"
        sqltmp = sqltmp + ",[doc_status]"
        sqltmp = sqltmp + ",[doc_status_date]"
        sqltmp = sqltmp + ",[doc_create_date]"
        sqltmp = sqltmp + ",[doc_create_by]"
        sqltmp = sqltmp + ",[doc_send_by]"
        sqltmp = sqltmp + ",[doc_send_date]"
        sqltmp = sqltmp + ",[doc_org_from]"
        sqltmp = sqltmp + ",[doc_to]"
        sqltmp = sqltmp + ",[doc_org_to]"
        sqltmp = sqltmp + ",[doc_obj_to]"
        sqltmp = sqltmp + ",[doc_approved]"
        sqltmp = sqltmp + ",[doc_OwnerAddress2]"
        sqltmp = sqltmp + " )"
        sqltmp = sqltmp + " select isnull([id_ref],[id]),[doc_no]"
        sqltmp = sqltmp + ",[doc_secret]"
        sqltmp = sqltmp + ",[doc_speed]"
        sqltmp = sqltmp + ",[doc_date1]"
        sqltmp = sqltmp + ",[doc_date2]"
        sqltmp = sqltmp + ",[doc_OrgBookOwner]"
        sqltmp = sqltmp + ",[doc_OwnerAddress]"
        sqltmp = sqltmp + ",[doc_title]"
        sqltmp = sqltmp + ",[doc_titleCommand]"
        sqltmp = sqltmp + ",[doc_refno]"
        sqltmp = sqltmp + ",[doc_title_when]"
        sqltmp = sqltmp + ",[doc_title_at]"
        sqltmp = sqltmp + ",[doc_title_regis]"
        sqltmp = sqltmp + ",[doc_title_meet]"
        sqltmp = sqltmp + ",[doc_title_nomeet]"
        sqltmp = sqltmp + ",[doc_title_group]"
        sqltmp = sqltmp + ",[doc_memo_woner]"
        sqltmp = sqltmp + ",[doc_content]"
        sqltmp = sqltmp + ",[doc_lean]"
        sqltmp = sqltmp + ",[doc_refto]"
        sqltmp = sqltmp + ",[doc_attach]"
        sqltmp = sqltmp + ",[doc_poscript]"
        sqltmp = sqltmp + ",[doc_officeSign]"
        sqltmp = sqltmp + ",[doc_position]"
        sqltmp = sqltmp + ",[doc_positionSign]"
        sqltmp = sqltmp + ",[doc_TitleOwner]"
        sqltmp = sqltmp + ",[doc_tel]"
        sqltmp = sqltmp + ",[doc_fax]"
        sqltmp = sqltmp + ",[doc_addr]"
        sqltmp = sqltmp + ",[doc_ccto]"
        sqltmp = sqltmp + ",[doc_detail]"
        sqltmp = sqltmp + ",[doc_type]"
        sqltmp = sqltmp + ",[doc_user]"
        sqltmp = sqltmp + ",'" + cfg_docstart + "'"
        sqltmp = sqltmp + ",getdate()"
        sqltmp = sqltmp + ",getdate()"
        sqltmp = sqltmp + ",'" & uPara.UserName & "'"
        sqltmp = sqltmp + ",'" + uPara.UserName + "'"
        sqltmp = sqltmp + ", getdate()"
        sqltmp = sqltmp + ",'" + uPara.ORG_DATA.ORG_CODE + "'"
        sqltmp = sqltmp + ",'" + cmbOfficeSignID.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + cmbTitleOwnerTo.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + cmbObjTo.SelectedValue + "'"
        If cmbObjTo.SelectedValue = Para.Common.Utilities.Constant.DocObjective.OjbKnow Then
            sqltmp = sqltmp + ",'0'"
        ElseIf cmbObjTo.SelectedValue = Para.Common.Utilities.Constant.DocObjective.ObjApprove Then
            sqltmp = sqltmp + ",'1'"
        End If
        sqltmp = sqltmp + ",[doc_OwnerAddress2]"
        sqltmp = sqltmp + " from DOC_TRANS where id = " + rowid.Text

        Dim lnq As New Linq.TABLE.DocStatusLinq
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp, trans.Trans) > 0 Then
            If CopyDocChildItem(rowid.Text, trans) = True Then
                trans.CommitTransaction()
                'Change status
                change_status(cfg_docnoapproveedit, cfg_docnoapprovesend, cfg_docissend, "DOC_TRANS", rowid.Text)
                UpdateIsSend()
                Dim status As String
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapproveedit Then update_status(cfg_docnoapprovesend, "DOC_TRANS", rowid.Text)

                btnSend.Visible = False
                btnSendBack.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = False
                btnApprove.Visible = False
                btnSave.Visible = False
                btnSaveSend.Visible = False
                btnNotApprove.Visible = False
                Master.GetModule(uPara)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(Linq.Common.Utilities.SqlDB.ErrorMessage, Me)
            End If
        Else
            trans.RollbackTransaction()
            Config.SetAlert(Linq.Common.Utilities.SqlDB.ErrorMessage, Me)
        End If
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        pop_app.Show()
    End Sub

    Protected Sub btnYesApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYesApprove.Click
        If save_form(docid) Then
            approver_book(cfg_docapproved)

            btnSend.Visible = False
            btnPrint.Visible = True
            btnCancel.Visible = False
            btnApprove.Visible = False
            btnSave.Visible = False
            btnSaveSend.Visible = False
            btnNotApprove.Visible = False
        Else
            If sys_err <> "" Then
                Config.SetAlert(sys_err, Me)
            End If
        End If
        
    End Sub

    Protected Sub btnNoApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoApprove.Click
        approver_book(cfg_docnoapprove)

        btnSend.Visible = False
        btnPrint.Visible = True
        btnCancel.Visible = False
        btnApprove.Visible = False
        btnSave.Visible = False
        btnSaveSend.Visible = False
        btnNotApprove.Visible = False
    End Sub

    Protected Sub btnNotApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNotApprove.Click
        popNoApprove.Show()
    End Sub

    Private Function UpdateIsSend() As Boolean
        Dim sql As String = "update doc_trans set is_send='Y' where id='" & rowid.Text & "'"
        Return ExecuteNonQuery(sql) > 0
    End Function

    Private Sub approver_book(ByVal status As String)
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        sqltmp = "update DOC_TRANS set doc_status = '" + status + "'"
        sqltmp = sqltmp + " where id = " + rowid.Text
        If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp, trans.Trans) > 0 Then
            trans.CommitTransaction()
            UpdateIsSend()

            sqltmp = "INSERT INTO DOC_TRANS ("
            sqltmp = sqltmp + " [id_ref],[doc_no]"
            sqltmp = sqltmp + ",[doc_secret]"
            sqltmp = sqltmp + ",[doc_speed]"
            sqltmp = sqltmp + ",[doc_date1]"
            sqltmp = sqltmp + ",[doc_date2]"
            sqltmp = sqltmp + ",[doc_OrgBookOwner]"
            sqltmp = sqltmp + ",[doc_OwnerAddress]"
            sqltmp = sqltmp + ",[doc_OwnerAddress2]"
            sqltmp = sqltmp + ",[doc_title]"
            sqltmp = sqltmp + ",[doc_titleCommand]"
            sqltmp = sqltmp + ",[doc_refno]"
            sqltmp = sqltmp + ",[doc_title_when]"
            sqltmp = sqltmp + ",[doc_title_at]"
            sqltmp = sqltmp + ",[doc_title_regis]"
            sqltmp = sqltmp + ",[doc_title_meet]"
            sqltmp = sqltmp + ",[doc_title_nomeet]"
            sqltmp = sqltmp + ",[doc_title_group]"
            sqltmp = sqltmp + ",[doc_memo_woner]"
            sqltmp = sqltmp + ",[doc_content]"
            sqltmp = sqltmp + ",[doc_lean]"
            sqltmp = sqltmp + ",[doc_refto]"
            sqltmp = sqltmp + ",[doc_attach]"
            sqltmp = sqltmp + ",[doc_poscript]"
            sqltmp = sqltmp + ",[doc_officeSign]"
            sqltmp = sqltmp + ",[doc_position]"
            sqltmp = sqltmp + ",[doc_positionSign]"
            sqltmp = sqltmp + ",[doc_TitleOwner]"
            sqltmp = sqltmp + ",[doc_tel]"
            sqltmp = sqltmp + ",[doc_fax]"
            sqltmp = sqltmp + ",[doc_addr]"
            sqltmp = sqltmp + ",[doc_ccto]"
            sqltmp = sqltmp + ",[doc_detail]"
            sqltmp = sqltmp + ",[doc_type]"
            sqltmp = sqltmp + ",[doc_user]"
            sqltmp = sqltmp + ",[doc_status]"
            sqltmp = sqltmp + ",[doc_status_date]"
            sqltmp = sqltmp + ",[doc_create_date]"
            sqltmp = sqltmp + ",[doc_create_by]"
            sqltmp = sqltmp + ",[doc_send_by]"
            sqltmp = sqltmp + ",[doc_send_date]"
            sqltmp = sqltmp + ",[doc_org_from]"
            sqltmp = sqltmp + ",[doc_to]"
            sqltmp = sqltmp + ",[doc_org_to]"
            sqltmp = sqltmp + ",[doc_obj_to]"
            sqltmp = sqltmp + ",[doc_approved]"
            sqltmp = sqltmp + " )"
            sqltmp = sqltmp + " select isnull([id_ref],[id]),[doc_no]"
            sqltmp = sqltmp + ",[doc_secret]"
            sqltmp = sqltmp + ",[doc_speed]"
            sqltmp = sqltmp + ",[doc_date1]"
            sqltmp = sqltmp + ",[doc_date2]"
            sqltmp = sqltmp + ",[doc_OrgBookOwner]"
            sqltmp = sqltmp + ",[doc_OwnerAddress]"
            sqltmp = sqltmp + ",[doc_OwnerAddress2]"
            sqltmp = sqltmp + ",[doc_title]"
            sqltmp = sqltmp + ",[doc_titleCommand]"
            sqltmp = sqltmp + ",[doc_refno]"
            sqltmp = sqltmp + ",[doc_title_when]"
            sqltmp = sqltmp + ",[doc_title_at]"
            sqltmp = sqltmp + ",[doc_title_regis]"
            sqltmp = sqltmp + ",[doc_title_meet]"
            sqltmp = sqltmp + ",[doc_title_nomeet]"
            sqltmp = sqltmp + ",[doc_title_group]"
            sqltmp = sqltmp + ",[doc_memo_woner]"
            sqltmp = sqltmp + ",[doc_content]"
            sqltmp = sqltmp + ",[doc_lean]"
            sqltmp = sqltmp + ",[doc_refto]"
            sqltmp = sqltmp + ",[doc_attach]"
            sqltmp = sqltmp + ",[doc_poscript]"
            sqltmp = sqltmp + ",[doc_officeSign]"
            sqltmp = sqltmp + ",[doc_position]"
            sqltmp = sqltmp + ",[doc_positionSign]"
            sqltmp = sqltmp + ",[doc_TitleOwner]"
            sqltmp = sqltmp + ",[doc_tel]"
            sqltmp = sqltmp + ",[doc_fax]"
            sqltmp = sqltmp + ",[doc_addr]"
            sqltmp = sqltmp + ",[doc_ccto]"
            sqltmp = sqltmp + ",[doc_detail]"
            sqltmp = sqltmp + ",[doc_type]"
            sqltmp = sqltmp + ",[doc_user]"
            sqltmp = sqltmp + ",'" + status + "'"
            sqltmp = sqltmp + ",getdate()"
            sqltmp = sqltmp + ",getdate()"
            sqltmp = sqltmp + ",'" & Config.GetLogOnUser.UserName & "'"
            sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
            sqltmp = sqltmp + ",getdate()"
            sqltmp = sqltmp + ",'" + Config.GetLogOnUser.ORG_DATA.ORG_CODE + "'"

            Dim SqlDocTmp As String = "select o.id, og.org_code "
            SqlDocTmp += " from DOC_TRANS dt "
            SqlDocTmp += " inner join officer o on o.username=dt.doc_create_by "
            SqlDocTmp += " inner join organization og on og.id=o.organization_id"
            SqlDocTmp += " where dt.id='" & txtRefID.Text & "'"
            Dim vDocToID As New DataTable
            vDocToID = getdatatable(SqlDocTmp)

            sqltmp = sqltmp + ",'" & vDocToID.Rows(0)("id").ToString & "'"
            sqltmp = sqltmp + ",'" & vDocToID.Rows(0)("org_code").ToString & "'"
            sqltmp = sqltmp + ",[doc_obj_to]"
            sqltmp = sqltmp + ",'1'"
            sqltmp = sqltmp + " from DOC_TRANS where id = " + rowid.Text

            trans = New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp, trans.Trans) > 0 Then
                If CopyDocChildItem(rowid.Text, trans) = True Then
                    trans.CommitTransaction()
                    Master.GetModule(uPara)
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
        Else
            trans.RollbackTransaction()
        End If
    End Sub


End Class
