Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI
Imports Linq.Common.Utilities.SqlDB
Imports Engine.Master
Imports Para.TABLE
Imports Engine.Common
Imports Linq.TABLE
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class WebApp_frmElecDocList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        msg_send.Text = ""

        If Not Page.IsPostBack Then
            doc_query()
        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        doc_query()
    End Sub


    Private Sub doc_query()
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select max(t1.id) as rowid,max(t1.doc_status_date),doc_no,doc_title,doc_create_date,org_name, case when isnull(doc_refno,'')='' then '-' else doc_refno end doc_refno,"

        sqltmp = sqltmp + " '~/WebApp/frmDocFormEntry.aspx?docformid=' + rtrim(convert(char,doc_type)) + '&rowid=' + rtrim(convert(char,max(t1.id))) as url_field,"
        sqltmp = sqltmp + " case max(doc_status) when 0 then '" + Array_status(0) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 1 then '" + Array_status(1) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 2 then '" + Array_status(2) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 3 then '" + Array_status(3) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 4 then '" + Array_status(4) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 5 then '" + Array_status(5) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 6 then '" + Array_status(6) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 7 then '" + Array_status(7) + "' else "
        sqltmp = sqltmp + " case max(doc_status) when 8 then '" + Array_status(8) + "' else '' end end end end end end end end end as process, "

        sqltmp = sqltmp + " case max(doc_status) when 0 then 1 else "
        sqltmp = sqltmp + " case max(doc_status) when 1 then 1 else "
        sqltmp = sqltmp + " case max(doc_status) when 2 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 3 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 4 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 5 then 1 else "
        sqltmp = sqltmp + " case max(doc_status) when 6 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 7 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 8 then 0 else '' end end end end end end end end end as send_status, "

        sqltmp = sqltmp + " case max(doc_status) when 0 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 1 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 2 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 3 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 4 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 5 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 6 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 7 then 0 else "
        sqltmp = sqltmp + " case max(doc_status) when 8 then 0 else '' end end end end end end end end end as nosend_status "

        sqltmp = sqltmp + " from DOC_TRANS t1 "
        sqltmp = sqltmp + " left join ORGANIZATION t2 on str(t2.id) = doc_TitleOwner "
        sqltmp = sqltmp + " where 1=1 "
        If txtDate1.DateValue <> Nothing Then sqltmp = sqltmp + " and doc_create_date >= '" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate1.DateValue), "yyyy/MM/dd") + "'"
        If txtDate2.DateValue <> Nothing Then sqltmp = sqltmp + " and doc_create_date <= '" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate2.DateValue), "yyyy/MM/dd") + "'"
        If Trim(txttitle.Text) <> "" Then sqltmp = sqltmp + " and doc_title like '%" + Trim(txttitle.Text) + "%'"
        sqltmp = sqltmp + " and doc_create_by = '" + Config.GetLogOnUser.UserName + "'"
        sqltmp = sqltmp + " and doc_status not in ('" + cfg_docnoapprovecancel + "','" + cfg_doccancel + "')"
        sqltmp = sqltmp + " group by doc_no, doc_refno,doc_title,doc_create_date,org_name,doc_type"
        sqltmp = sqltmp + " order by max(t1.doc_status_date) desc,doc_no desc "

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        GridView1.PageSize = 20
        GridView1.DataSource = Ds
        GridView1.DataBind()


        pcTop.SetMainGridView(GridView1)
        pcTop.Update(Ds.Tables("DATA").Rows.Count)
        pcTop.DataBind()
    End Sub

    Private Sub SetOfficeSignID()
        Dim dt As DataTable

        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        'sqltmp = sqltmp & "WHERE o.organization_id = '" + cmbTitleOwnerTo.SelectedValue + "'"

        dt = GetDataToList(sqltmp)
        cmbOfficeSignID.SetItemList(dt, "full_name", "username")
    End Sub

    Private Sub SetTitleOwnerTo()
        Dim dt As DataTable

        sqltmp = "select distinct org_name,org_code from ORGANIZATION where active = 'Y' order by org_name"

        dt = GetDataToList(sqltmp)
        cmbTitleOwnerTo.SetItemList(dt, "org_name", "org_code")

        'Dim txt As String
        'txt = getdatafld("select distinct org_name,org_code from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_code")
        'cmbTitleOwner.SelectedValue = txt
    End Sub

    Private Sub SetObjective()
        Dim dt As DataTable

        sqltmp = "select distinct Objective_name,Objective_code from OBJECTIVE order by Objective_name"

        dt = GetDataToList(sqltmp)
        cmbObjTo.SetItemList(dt, "Objective_name", "Objective_code")

        'Dim txt As String
        'txt = getdatafld("select distinct org_name,org_code from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_code")
        'cmbTitleOwner.SelectedValue = txt
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_send.Click
        If GridviewCheck(GridView1) Then
            ClearGridviewSendData()
            doc_send_query()

            SetTitleOwnerTo()
            SetObjective()
            cmbOfficeSignID.ClearCombo()

            popup1.Show()
        Else
            sys_msg.Text = "กรุณาเลือกเอกสารที่ต้องการส่ง"
            msg_pop.Show()
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

        If Ds.Tables("DATA").Rows.Count > 0 Then Return False

        Return True
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
        sqltmp = sqltmp + ",'" + cmbTitleOwnerTo.SelectedText + "'"
        sqltmp = sqltmp + ",'" + cmbOfficeSignID.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + cmbOfficeSignID.SelectedText + "'"
        sqltmp = sqltmp + ",'" + cmbObjTo.SelectedValue + "'"
        sqltmp = sqltmp + ",'" + IIf(cmbObjTo.SelectedValue = "0", "''", cmbObjTo.SelectedText) + "'"
        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd hh:mm") + "'"
        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
        sqltmp = sqltmp + ")"

        COMMAND.CommandText = sqltmp
        COMMAND.ExecuteNonQuery()
        conn.Close()

        Return True
    End Function

    Protected Sub btnYes0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes0.Click
        If Not AddGridviewSendData() Then
            msg_send.Text = "การเพิ่มรายการผู้รับ มีข้อมูลไม่สมบูรณ์ หรือ เป็นรายการที่มีอยู่แล้ว กรุณาลองใหม่อีกครั้ง"
        Else
            cmbTitleOwnerTo.SelectedValue = "0"
            cmbOfficeSignID.SelectedValue = "0"
            cmbObjTo.SelectedValue = "0"
            txttitleTo.Text = ""
        End If

        doc_send_query()
        popup1.Show()
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

    Protected Sub btnNo0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo0.Click
        If GridviewCheck(GridviewSendList) Then
            GridviewDeleteData(GridviewSendList, "DOC_TEMP_LIST", "id")
            doc_send_query()
        Else
            msg_send.Text = "ยังไม่ได้เลือกรายการที่ต้องการลบ"
        End If

        popup1.Show()
    End Sub


    Protected Sub cmbTitleOwnerTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitleOwnerTo.SelectedIndexChanged
        cmbOfficeSignID.ClearCombo()
        If cmbTitleOwnerTo.SelectedValue <> "0" Then
            Dim dt As DataTable

            sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
            sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
            sqltmp = sqltmp & "WHERE g.org_code = '" + cmbTitleOwnerTo.SelectedValue + "'"

            dt = GetDataToList(sqltmp)
            cmbOfficeSignID.SetItemList(dt, "full_name", "username")

            popup1.Show()
        End If
    End Sub

    Protected Sub btnNo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo1.Click
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet
        Dim row As GridViewRow
        Dim isChecked As CheckBox
        Dim apChecked As CheckBox
        Dim isLabel As Label
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


            If chk_cnt = 0 Or chk_cnt > 1 Then
                If chk_cnt = 0 Then msg_send.Text = "ท่านยังไม่ได้กำหนดผู้มีอำนาจในการอนุมัติ"
                If chk_cnt > 1 Then msg_send.Text = "ท่านกำหนดผู้มีอำนาจในการอนุมัติมากกว่าหนึ่งคน"
                popup1.Show()
            Else
                For r = 0 To GridView1.Rows.Count - 1
                    row = GridView1.Rows(r)
                    isChecked = CType(row.FindControl("chk_id"), CheckBox)
                    isLabel = CType(row.FindControl("txt_id"), Label)

                    If isChecked.Checked Then
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

                            sqltmp = sqltmp + " from DOC_TRANS where id = " + isLabel.Text

                            COMMAND.CommandText = sqltmp
                            COMMAND.ExecuteNonQuery()
                        Next

                        'Change status
                        change_status(cfg_docnoapproveedit, cfg_docnoapprovesend, cfg_docissend, "DOC_TRANS", isLabel.Text)
                    End If
                Next
            End If

            doc_query()
        Else
            msg_send.Text = "ท่านยังไม่ได้เลือกรายการผู้รับเอกสาร"
            popup1.Show()
        End If

        conn.Close()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If GridviewCheck(GridView1) Then
            popup2.Show()
        Else
            sys_msg.Text = "กรุณาเลือกเอกสารที่ต้องการส่ง"
            msg_pop.Show()
        End If
    End Sub

    Protected Sub btnYes4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes4.Click
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet
        Dim row As GridViewRow
        Dim isChecked As CheckBox
        Dim isLabel As Label
        Dim apLabel As New Label
        Dim chk_cnt As Integer = 0

        conn = New SqlConnection(cnstr)

        Dim COMMAND As New SqlCommand

        conn.Open()
        COMMAND.Connection = conn

        Ds.Tables.Clear()

        Da = New SqlDataAdapter("select * from DOC_TEMP_LIST where login_key = '" + Config.GetLogOnUser.UserName + "'", conn)
        Da.Fill(Ds, "DATA")

        For r = 0 To GridView1.Rows.Count - 1
            row = GridView1.Rows(r)
            isChecked = CType(row.FindControl("chk_id"), CheckBox)
            isLabel = CType(row.FindControl("txt_id"), Label)

            If isChecked.Checked Then
                sqltmp = "update DOC_TRANS set doc_status = '" + cfg_doccancel + "'"
                sqltmp = sqltmp + " where id = " + isLabel.Text

                COMMAND.CommandText = sqltmp
                COMMAND.ExecuteNonQuery()
            End If
        Next


        conn.Close()

        doc_query()
    End Sub
End Class
