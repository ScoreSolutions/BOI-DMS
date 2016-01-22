Imports Para.TABLE
'Imports Func.Master
Imports Engine.Master
'Imports Func.Common
Imports Engine.Common
Imports System.Data
Imports System.Web.UI
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class WebApp_frmDocFormEntry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        msg_send.Text = ""

        If Not IsPostBack Then
            txtCreateDate.DefaultCurrentDate = False
            txtCreateDate.DateValue = DateAdd(DateInterval.Year, YearZone, Date.Now)

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
            End If


            SetVisibleForm()
            SetVisibleButton()
        End If
    End Sub

    Private Sub SetVisibleButton()
        If Request.Params("approved_mode") = "yes" Then
            'Disable 
            btnCancel.Visible = False
            btnSave.Visible = False
            btnSaveSend.Visible = False

            'visable
            btnSend.Visible = True
            btnPrint.Visible = True
            btnApprove.Visible = True

            edit_mode = edit_data
            load_form(docid)

            status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")

            If CInt(status_id.Text) = CInt(cfg_docapproved) Or CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                btnSend.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = False
                btnApprove.Visible = False
                btnSave.Visible = False
                btnSaveSend.Visible = False
            End If
        End If

        If Request.Params("approved_mode") = "no" Then
            'Disable 
            btnCancel.Visible = False
            btnSave.Visible = False
            btnSaveSend.Visible = False

            'visable
            btnSend.Visible = True
            btnPrint.Visible = True
            btnApprove.Visible = False

            edit_mode = edit_data
            load_form(docid)

            status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")

            If CInt(status_id.Text) = CInt(cfg_docapproved) Or CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                btnSend.Visible = False
                btnPrint.Visible = True
                btnCancel.Visible = False
                btnApprove.Visible = False
                btnSave.Visible = False
                btnSaveSend.Visible = False
            End If
        End If

        If Request.Params("approved_mode") = Nothing Then
            btnSend.Visible = True
            btnPrint.Visible = True
            btnCancel.Visible = True
            btnApprove.Visible = True
            btnSave.Visible = True
            btnSaveSend.Visible = True

            If edit_mode = edit_data Then
                status_id.Text = getdatafld("select doc_status from DOC_TRANS where id = " + rowid.Text, "doc_status")

                load_form(docid)

                btnApprove.Visible = False

                If CInt(status_id.Text) = CInt(cfg_docstart) Then
                    btnSend.Visible = False
                End If

                If CInt(status_id.Text) >= CInt(cfg_docissend) Then
                    btnSend.Visible = False
                    btnCancel.Visible = False
                    btnSave.Visible = False
                    btnSaveSend.Visible = False
                End If

                If CInt(status_id.Text) = CInt(cfg_docnoapprove) Then
                    btnSend.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = True
                    btnApprove.Visible = False
                    btnSave.Visible = True
                    btnSaveSend.Visible = True
                End If

                If CInt(status_id.Text) = CInt(cfg_docnoapproveedit) Then
                    btnSend.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = True
                    btnApprove.Visible = False
                    btnSave.Visible = True
                    btnSaveSend.Visible = True
                End If

                If CInt(status_id.Text) = CInt(cfg_docapproved) Then
                    btnSend.Visible = False
                    btnPrint.Visible = True
                    btnCancel.Visible = False
                    btnApprove.Visible = False
                    btnSave.Visible = False
                    btnSaveSend.Visible = False
                End If
                btnPrint.Attributes.Add("onClick", "PrintReport('" & txtReportName.Text & "','" & rowid.Text & "'); return false;")
            Else
                btnSend.Visible = False
                btnPrint.Visible = False
                btnApprove.Visible = False
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
                'Call BookoutInit()
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

        'sqltxt = "select id from DOC_TRANS where doc_create_by = '" + username + "' and doc_create_date = '" + Format(Date.Now, "yyyy/MM/dd") + "' and doc_type = " + doc_type + " order by id desc "
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
                rowid.Text = Get_lastrecordNo(Config.GetLogOnUser.UserName, docid.ToString)
            Else
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapprove Then update_status(cfg_docnoapproveedit, "DOC_TRANS", rowid.Text)
            End If

            update_owner()
            btnPrint.Visible = True
            btnPrint.Attributes.Add("onClick", "PrintReport('" & txtReportName.Text & "','" & rowid.Text & "'); return false;")
            sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
            msg_pop.Show()
        Else
            If sys_err <> "" Then
                sys_msg.Text = sys_err
                msg_pop.Show()
            End If
        End If
    End Sub

    Private Sub update_owner()
        condb()

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        sqltmp = "update DOC_TRANS set doc_titleowner = '" + getdatafld("select distinct id from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "id") + "'"
        sqltmp = sqltmp + " where id = " + rowid.Text
        sqltmp = sqltmp + " and (doc_titleowner is null or doc_titleowner = '' or doc_titleowner = '0')"

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()
        conn.Close()
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        ClearGridviewSendData()
        doc_send_query()
        'SetTitleOwnerTo()
        SetObjective()
        cmbOfficeSignID.Items.Clear()
        popup1.Show()

        'Dim status As String
        'status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
        'If status = cfg_docnoapproveedit Then update_status(cfg_docnoapprovesend, Lookup_table, rowid.Text)
    End Sub

    Protected Sub btnSaveSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveSend.Click
        Dim status As String
        If save_form(docid) Then
            If edit_mode = new_data Then
                edit_mode = edit_data
                rowid.Text = Get_lastrecordNo(Config.GetLogOnUser.UserName, docid.ToString)
            Else
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapprove Then update_status(cfg_docnoapproveedit, "DOC_TRANS", rowid.Text)
            End If

            update_owner()

            ClearGridviewSendData()
            doc_send_query()

            'SetTitleOwnerTo()
            SetObjective()
            cmbOfficeSignID.Items.Clear()

            popup1.Show()

            'Dim status As String
            'status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
            'If status = cfg_docnoapproveedit Then update_status(cfg_docnoapprovesend, Lookup_table, rowid.Text)
        Else
            If sys_err <> "" Then
                sys_msg.Text = sys_err
                msg_pop.Show()
            End If
        End If
    End Sub

    Private Sub ClearGridviewSendData()
        condb()

        Dim str As New StringBuilder

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        sqltmp = "delete from DOC_TEMP_LIST where login_key = '" + Config.GetLogOnUser.UserName + "'"

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub doc_send_query()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from DOC_TEMP_LIST where login_key = '" + Config.GetLogOnUser.UserName + "'"

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        GridviewSendList.DataSource = Ds
        GridviewSendList.DataBind()
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

    'Private Sub SetOfficeSignID()
    '    Dim dt As DataTable

    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    'sqltmp = sqltmp & "WHERE o.organization_id = '" + cmbTitleOwnerTo.SelectedValue + "'"
    '    cmbOfficeSignID.ClearCombo()
    '    dt = GetDataToList(sqltmp)
    '    cmbOfficeSignID.SetItemList(dt, "full_name", "username")
    'End Sub


    'Private Sub SetTitleOwnerTo()
    '    Dim dt As DataTable

    '    sqltmp = "select distinct org_name,org_code from ORGANIZATION where active = 'Y' order by org_name"
    '    cmbTitleOwnerTo.ClearCombo()
    '    dt = GetDataToList(sqltmp)
    '    cmbTitleOwnerTo.SetItemList(dt, "org_name", "org_code")

    '    'Dim txt As String
    '    'txt = getdatafld("select distinct org_name,org_code from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_code")
    '    'cmbTitleOwner.SelectedValue = txt
    'End Sub

    Private Sub SetObjective()
        Dim dt As DataTable

        sqltmp = "select distinct Objective_name,Objective_code from OBJECTIVE "

        dt = GetDataToList(sqltmp)
        cmbObjTo.SetItemList(dt, "Objective_name", "Objective_code")

        'Dim txt As String
        'txt = getdatafld("select distinct org_name,org_code from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_code")
        'cmbTitleOwner.SelectedValue = txt
    End Sub

    Protected Sub btnYes2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes2.Click
        If Not AddGridviewSendData() Then
            msg_send.Text = "การเพิ่มรายการผู้รับ มีข้อมูลไม่สมบูรณ์ หรือ เป็นรายการที่มีอยู่แล้ว กรุณาลองใหม่อีกครั้ง"
        Else
            'cmbTitleOwnerTo.SelectedValue = "0"
            'cmbOfficeSignID.SelectedValue = "0"
            cdlOwnerOrgID.SelectedValue = "0"
            cdlOwnerStaffID.SelectedValue = ""
            cmbObjTo.SelectedValue = "0"
            txttitleTo.Text = ""
        End If

        doc_send_query()
        popup1.Show()
    End Sub

    Private Function validate_field() As Boolean
        If cmbTitleOwnerTo.SelectedValue = "0" Then Return False
        If cmbOfficeSignID.SelectedValue = "0" Then Return False
        'If cmbObjTo.SelectedValue = "0" Then Return False

        Return True
    End Function

    Private Function chk_dup() As Boolean
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        Da = New SqlDataAdapter("select * from DOC_TEMP_LIST where send_Owner_code = '" + cmbTitleOwnerTo.SelectedValue + "' and send_to_code = '" + cmbOfficeSignID.SelectedValue + "' and login_key = '" + Config.GetLogOnUser.UserName + "'", conn)
        Da.Fill(Ds, "DATA")

        If Ds.Tables("DATA").Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function AddGridviewSendData() As Boolean
        If Not validate_field() Then Return False
        If Not chk_dup() Then Return False

        condb()

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        sqltmp = "insert into DOC_TEMP_LIST (send_Owner_code,send_Owner_Name,send_to_code,send_to_name,send_obj_code,send_obj_name,send_date,login_key) "
        sqltmp = sqltmp + " values ("

        sqltmp = sqltmp + " '" + cmbTitleOwnerTo.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + cmbTitleOwnerTo.SelectedItem.Text + "'"
        sqltmp = sqltmp + ",'" + cmbOfficeSignID.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + cmbOfficeSignID.SelectedItem.Text + "'"
        sqltmp = sqltmp + ",'" + cmbObjTo.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + IIf(cmbObjTo.SelectedValue = "0", "''", cmbObjTo.SelectedText) + "'"
        sqltmp = sqltmp + ",'" + Format(Date.Now, "yyyy/MM/dd hh:mm") + "'"
        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
        sqltmp = sqltmp + ")"

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()
        conn.Close()

        Return True
    End Function

    'Protected Sub cmbTitleOwnerTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitleOwnerTo.SelectedIndexChanged

    '    cmbOfficeSignID.ClearCombo()

    '    If cmbTitleOwnerTo.SelectedValue <> "0" Then
    '        Dim dt As DataTable

    '        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '        sqltmp = sqltmp & "WHERE g.org_code = '" + cmbTitleOwnerTo.SelectedValue + "'"

    '        dt = GetDataToList(sqltmp)
    '        cmbOfficeSignID.SetItemList(dt, "full_name", "username")

    '        popup1.Show()
    '    End If
    'End Sub

    Protected Sub btnNo3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo3.Click
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        Dim row As GridViewRow
        Dim isChecked As New CheckBox
        Dim apChecked As CheckBox
        Dim apLabel As New Label
        Dim chk_cnt As Integer = 0

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        Ds.Tables.Clear()

        Da = New SqlDataAdapter("select * from DOC_TEMP_LIST where login_key = '" + Config.GetLogOnUser.UserName + "'", conn)
        Da.Fill(Ds, "DATA")

        msg_send.Text = ""
        If Ds.Tables("DATA").Rows.Count > 0 Then
            For r = 0 To GridviewSendList.Rows.Count - 1
                row = GridviewSendList.Rows(r)
                apChecked = CType(row.FindControl("chk_ap"), CheckBox)
                If apChecked.Checked Then
                    apLabel = CType(row.FindControl("txt_ap"), Label)
                    chk_cnt = chk_cnt + 1
                End If
            Next

            msg_send.Text = ""
            If chk_cnt = 0 Or chk_cnt > 1 Then
                If chk_cnt = 0 Then msg_send.Text = "ท่านยังไม่ได้กำหนดผู้มีอำนาจในการอนุมัติ"
                If chk_cnt > 1 Then msg_send.Text = "ท่านกำหนดผู้มีอำนาจในการอนุมัติมากกว่าหนึ่งคน"
                popup1.Show()
            Else
                For i = 0 To Ds.Tables("DATA").Rows.Count - 1
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
                    sqltmp = sqltmp + ",[doc_edit_date]"
                    sqltmp = sqltmp + ",[doc_edit_by]"
                    sqltmp = sqltmp + ",[doc_send_by]"
                    sqltmp = sqltmp + ",[doc_send_date]"
                    sqltmp = sqltmp + ",[doc_org_from]"
                    sqltmp = sqltmp + ",[doc_to]"
                    sqltmp = sqltmp + ",[doc_org_to]"
                    sqltmp = sqltmp + ",[doc_obj_to]"
                    sqltmp = sqltmp + ",[doc_approved]"
                    sqltmp = sqltmp + ",[doc_OwnerAddress2]"
                    sqltmp = sqltmp + " )"
                    sqltmp = sqltmp + " select [id],[doc_no]"
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
                    sqltmp = sqltmp + ",[doc_status_date]"
                    sqltmp = sqltmp + ",[doc_create_date]"
                    sqltmp = sqltmp + ",[doc_create_by]"
                    sqltmp = sqltmp + ",[doc_edit_date]"
                    sqltmp = sqltmp + ",[doc_edit_by]"
                    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",'" + getdatafld("Select org_code FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id WHERE o.username = '" + Config.GetLogOnUser.UserName + "'", "org_code") + "'"
                    sqltmp = sqltmp + ",'" + Ds.Tables("DATA").Rows(i).Item("send_to_code").ToString + "'"
                    sqltmp = sqltmp + ",'" + Ds.Tables("DATA").Rows(i).Item("send_Owner_code").ToString + "'"
                    sqltmp = sqltmp + ",'" + Ds.Tables("DATA").Rows(i).Item("send_obj_code").ToString + "'"
                    If Ds.Tables("DATA").Rows(i).Item("send_to_code").ToString = apLabel.Text Then
                        sqltmp = sqltmp + ",'1'"
                    Else
                        sqltmp = sqltmp + ",'0'"
                    End If
                    sqltmp = sqltmp + ",[doc_OwnerAddress2]"
                    sqltmp = sqltmp + " from DOC_TRANS where id = " + rowid.Text

                    COMMAND.CommandText = sqltmp
                    COMMAND.ExecuteNonQuery()

                    'Change status
                    change_status(cfg_docnoapproveedit, cfg_docnoapprovesend, cfg_docissend, "DOC_TRANS", rowid.Text)
                Next

                Dim status As String
                status = getdatafld("select doc_status from doc_trans where id = " + rowid.Text, "doc_status")
                If status = cfg_docnoapproveedit Then update_status(cfg_docnoapprovesend, "DOC_TRANS", rowid.Text)

                SetVisibleButton()
            End If
        Else
            msg_send.Text = "ท่านยังไม่ได้เลือกรายการผู้รับเอกสาร"
            popup1.Show()
        End If

        conn.Close()
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        pop_app.Show()
        SetVisibleButton()
    End Sub

    Protected Sub btnYes4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes4.Click
        approver_book(cfg_docapproved)
        Response.Redirect("frmElecDocUserList.aspx")
    End Sub

    Protected Sub btnNo4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo4.Click
        approver_book(cfg_docnoapprove)
        Response.Redirect("frmElecDocUserList.aspx")
    End Sub

    Private Sub approver_book(ByVal status As String)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        sqltmp = "update DOC_TRANS set doc_status = '" + status + "'"
        sqltmp = sqltmp + " where id = " + rowid.Text

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()


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
        sqltmp = sqltmp + ",[doc_edit_date]"
        sqltmp = sqltmp + ",[doc_edit_by]"
        sqltmp = sqltmp + ",[doc_send_by]"
        sqltmp = sqltmp + ",[doc_send_date]"
        sqltmp = sqltmp + ",[doc_org_from]"
        sqltmp = sqltmp + ",[doc_to]"
        sqltmp = sqltmp + ",[doc_org_to]"
        sqltmp = sqltmp + ",[doc_obj_to]"
        sqltmp = sqltmp + ",[doc_approved]"
        sqltmp = sqltmp + " )"
        sqltmp = sqltmp + " select [id],[doc_no]"
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
        sqltmp = sqltmp + ",[doc_status_date]"
        sqltmp = sqltmp + ",[doc_create_date]"
        sqltmp = sqltmp + ",[doc_create_by]"
        sqltmp = sqltmp + ",[doc_edit_date]"
        sqltmp = sqltmp + ",[doc_edit_by]"
        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
        sqltmp = sqltmp + ",'" + getdatafld("Select org_code FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id WHERE o.username = '" + Config.GetLogOnUser.UserName + "'", "org_code") + "'"
        sqltmp = sqltmp + ",[doc_send_by]"
        sqltmp = sqltmp + ",[doc_org_to]"
        sqltmp = sqltmp + ",[doc_obj_to]"
        sqltmp = sqltmp + ",'0'"
        sqltmp = sqltmp + " from DOC_TRANS where id = " + rowid.Text

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()

        conn.Close()
    End Sub

    
    Protected Sub GridviewSendList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridviewSendList.RowCommand
        If e.CommandName = "Delete" Then
            Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim isLabel As Label = CType(gvRow.FindControl("txt_id"), Label)
            Try
                sqltmp = " delete from DOC_TEMP_LIST where id = " + isLabel.Text
                Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sqltmp)
                doc_send_query()
            Catch ex As Exception
            Finally

            End Try
        End If
        popup1.Show()
    End Sub

    Protected Sub GridviewSendList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridviewSendList.RowDeleting

    End Sub
End Class
