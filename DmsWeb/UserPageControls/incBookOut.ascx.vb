Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookOut
    Inherits System.Web.UI.UserControl


    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String)
        If Baction Then
            txtDate1.DateValue = Nothing
            txtBookNo.Text = ""
            txtOrgBookOwner.Text = "สำนักงานคณะกรรมการส่งเสริมการลงทุน"
            txtOwnerAddress.Text = "555 ถ.วิภาวดี รังสิต"
            txtOwnerAddress2.Text = "เขตจตุจักร กรุงเทพฯ 10900"
            txtTitle.Text = ""
            txtLean.Text = ""
            txtrefto.Text = ""
            txtattach.Text = ""
            ctlDetail.Text = ""
            txtPositionSign.Text = ""
            Txttel.Text = ""
            txtFax.Text = ""
            txtCCTo.Text = ""

            init_page()
            If edit_mode = edit_data Then
                load_trans(True, rowid)
            End If
        End If
    End Sub

    Public Sub load_trans(ByVal Baction As Boolean, ByVal rowid As String)
        If Baction Then
            txtDate1.DefaultCurrentDate = False

            condb()

            Dim Da As New SqlDataAdapter
            Dim Ds As New DataSet

            conn = New SqlConnection(cnstr)
            Ds.Tables.Clear()

            sqltmp = "select * from DOC_TRANS where id = " + rowid

            Da = New SqlDataAdapter(sqltmp, conn)
            Da.Fill(Ds, "DATA")

            If Ds.Tables("DATA").Rows.Count > 0 Then
                cmbSecretID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_secret").ToString
                cmbSecret1.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_secret").ToString

                cmbSpeenID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_speed").ToString
                If Convert.IsDBNull(Ds.Tables("DATA").Rows(0).Item("doc_date1")) = False Then
                    txtDate1.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                End If
                txtBookNo.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                txtOrgBookOwner.Text = Ds.Tables("DATA").Rows(0).Item("doc_OrgBookOwner").ToString
                txtOwnerAddress.Text = Ds.Tables("DATA").Rows(0).Item("doc_OwnerAddress").ToString
                txtTitle.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                txtLean.Text = Ds.Tables("DATA").Rows(0).Item("doc_lean").ToString
                txtrefto.Text = Ds.Tables("DATA").Rows(0).Item("doc_refto").ToString
                txtattach.Text = Ds.Tables("DATA").Rows(0).Item("doc_attach").ToString
                ctlDetail.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                txtdetail = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                cmbPoscriptID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_poscript").ToString
                cmbTitleOwner.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_TitleOwner").ToString
                Txttel.Text = Ds.Tables("DATA").Rows(0).Item("doc_tel").ToString
                txtFax.Text = Ds.Tables("DATA").Rows(0).Item("doc_fax").ToString
                txtCCTo.Text = Ds.Tables("DATA").Rows(0).Item("doc_ccto").ToString
                txtOwnerAddress2.Text = Ds.Tables("DATA").Rows(0).Item("doc_OwnerAddress2").ToString

                If Ds.Tables("DATA").Rows(0)("doc_obj_to").ToString = Para.Common.Utilities.Constant.DocObjective.ObjApprove And Ds.Tables("DATA").Rows(0)("doc_approved").ToString = "1" And Ds.Tables("DATA").Rows(0)("doc_status").ToString = cfg_docstart Then
                    trOfficerSign.Visible = True
                Else
                    trOfficerSign.Visible = False
                    txtOfficerSign.Text = ""
                    txtPositionSign.Text = ""
                End If

                Dim rSql As String = "select id, refer_to from DOC_TRANS_REFER where doc_trans_id='" & rowid & "'"
                Dim rDt As New DataTable
                rDt = SqlDB.ExecuteTable(rSql)
                If rDt.Rows.Count > 0 Then
                    gvReferToList.DataSource = rDt
                    gvReferToList.DataBind()
                    Session(SessReferTo) = rDt
                    'rDt = Nothing
                Else
                    gvReferToList.DataSource = Nothing
                    gvReferToList.DataBind()
                    Session.Remove(SessReferTo)
                End If

                Dim aSql As String = "select id, attach from DOC_TRANS_ATTACH where doc_trans_id='" & rowid & "'"
                Dim aDt As New DataTable
                aDt = SqlDB.ExecuteTable(aSql)
                If aDt.Rows.Count > 0 Then
                    gvAttachList.DataSource = aDt
                    gvAttachList.DataBind()
                    Session(SessAttach) = aDt
                    'aDt = Nothing
                Else
                    gvAttachList.DataSource = Nothing
                    gvAttachList.DataBind()
                    Session.Remove(SessAttach)
                End If
            End If
        End If
    End Sub

    Private Function validate_field() As Boolean
        Dim retval As Boolean = True

        If ctlDetail.Text = "" Then
            ctlDetail.IsNotNull = True
            ctlDetail.Focus()
            sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
            retval = False
        Else
            ctlDetail.IsNotNull = False
        End If

        If txtLean.Text = "" Then
            txtLean.IsNotNull = True
            txtLean.Focus()
            sys_err = "ยังไม่ได้กรอกข้อมูล เรียน"
            retval = False
        Else
            txtLean.IsNotNull = False
        End If

        If txtTitle.Text = "" Then
            txtTitle.IsNotNull = True
            txtTitle.Focus()
            sys_err = "ยังไม่ได้กรอกข้อมูล เรื่อง"
            retval = False
        Else
            txtTitle.IsNotNull = False
        End If

        Return retval
    End Function

    Public Function save_trans(ByVal Baction As Boolean, ByVal rowid As String) As Boolean
        If Baction Then
            If Not validate_field() Then Return False

            Dim cmd As SqlCommand
            Try
                If rowid Is Nothing Or rowid = "" Then
                    Dim docno As String = GetLastNo(YearZone)
                    sqltmp = "insert into DOC_TRANS ("
                    sqltmp = sqltmp + " doc_no"
                    sqltmp = sqltmp + ",doc_secret"
                    sqltmp = sqltmp + ",doc_speed"
                    sqltmp = sqltmp + ",doc_date1"
                    sqltmp = sqltmp + ",doc_refno"
                    sqltmp = sqltmp + ",doc_OrgBookOwner"
                    sqltmp = sqltmp + ",doc_OwnerAddress"
                    sqltmp = sqltmp + ",doc_title"
                    sqltmp = sqltmp + ",doc_lean"
                    sqltmp = sqltmp + ",doc_refto"
                    sqltmp = sqltmp + ",doc_attach"
                    sqltmp = sqltmp + ",doc_detail"
                    sqltmp = sqltmp + ",doc_poscript"
                    sqltmp = sqltmp + ",doc_officesign"
                    sqltmp = sqltmp + ",doc_positionsign"
                    sqltmp = sqltmp + ",doc_TitleOwner"
                    sqltmp = sqltmp + ",doc_tel"
                    sqltmp = sqltmp + ",doc_fax"
                    sqltmp = sqltmp + ",doc_addr"
                    'sqltmp = sqltmp + ",doc_ccto"
                    sqltmp = sqltmp + ",doc_create_date"
                    sqltmp = sqltmp + ",doc_create_by"
                    sqltmp = sqltmp + ",doc_status_date"
                    sqltmp = sqltmp + ",doc_status"
                    sqltmp = sqltmp + ",doc_type"
                    sqltmp = sqltmp + ",doc_OwnerAddress2 "
                    sqltmp = sqltmp + ",is_read"
                    sqltmp = sqltmp + ") values ("
                    sqltmp = sqltmp + " '" + docno + "'"
                    sqltmp = sqltmp + ",'" + cmbSecretID.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + cmbSpeenID.SelectedValue + "'"
                    If txtDate1.DateValue.Year <> 1 Then
                        Dim db As New SqlDB
                        sqltmp = sqltmp + "," + db.SetDate(txtDate1.DateValue)
                        db = Nothing
                    Else
                        sqltmp = sqltmp + ",null "
                    End If

                    sqltmp = sqltmp + ",'" + Replace(txtBookNo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtOrgBookOwner.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtOwnerAddress.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtTitle.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtLean.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtRefTo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtAttach.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(ctlDetail.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + cmbPoscriptID.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtOfficerSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtPositionSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + cmbTitleOwner.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtTel.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtFax.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtCCTo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) + "'"
                    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) + "'"
                    sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                    sqltmp = sqltmp + ", " + FormBookOutID.ToString + " "
                    sqltmp = sqltmp + ", '" + txtOwnerAddress2.Text + "' "
                    sqltmp = sqltmp + ", 'Y'"
                    sqltmp = sqltmp + ")"
                Else
                    sqltmp = "update DOC_TRANS set "
                    sqltmp = sqltmp + "doc_secret='" + cmbSecretID.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_speed='" + cmbSpeenID.SelectedValue + "'"
                    If txtDate1.DateValue.Year <> 1 Then
                        Dim db As New SqlDB
                        sqltmp = sqltmp + ",doc_date1=" + db.SetDate(txtDate1.DateValue)
                        db = Nothing
                    Else
                        sqltmp = sqltmp + ",doc_date1=null "
                    End If
                    sqltmp = sqltmp + ",doc_refno='" + Replace(txtBookNo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_OrgBookOwner='" + Replace(txtOrgBookOwner.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_OwnerAddress='" + Replace(txtOwnerAddress.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_lean='" + Replace(txtLean.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_refto='" + Replace(txtRefTo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_attach='" + Replace(txtAttach.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_poscript='" + cmbPoscriptID.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_officesign='" + Replace(txtOfficerSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_TitleOwner='" + cmbTitleOwner.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_tel='" + Replace(txtTel.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_fax='" + Replace(txtFax.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_ccto='" + Replace(txtCCTo.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + ",doc_OwnerAddress2='" & txtOwnerAddress2.Text.Trim & "'"
                    sqltmp = sqltmp + " where id = " + rowid
                End If

                Dim trans As New TransactionDB
                trans.CreateTransaction()
                If SqlDB.ExecuteNonQuery(sqltmp, trans.Trans) > 0 Then
                    trans.CommitTransaction()
                    If rowid Is Nothing Or rowid = "" Then
                        rowid = GetLastID("DOC_TRANS")
                    End If

                    'Save Refer to
                    SqlDB.ExecuteNonQuery("delete from DOC_TRANS_REFER where doc_trans_id = '" & rowid & "'")
                    If Session(SessReferTo) IsNot Nothing Then
                        Dim rDt As New DataTable
                        rDt = DirectCast(Session(SessReferTo), DataTable)
                        If rDt.Rows.Count > 0 Then
                            Dim ret As Boolean = False
                            For Each rDr As DataRow In rDt.Rows
                                trans = New TransactionDB
                                trans.CreateTransaction()
                                Dim rID As Long = SqlDB.GetNextID("id", "DOC_TRANS_REFER", trans.Trans)
                                Dim sql As String = " INSERT INTO [DOC_TRANS_REFER]([id],[create_by],[create_on],[doc_trans_id],[refer_to]) "
                                sql += " values ('" & rID & "','" & Config.GetLogOnUser.UserName & "',getdate(),'" & rowid & "','" & rDr("refer_to").ToString & "')"
                                ret = SqlDB.ExecuteNonQuery(sql, trans.Trans) > 0
                                If ret = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                End If
                            Next
                            rDt = Nothing
                        End If
                    End If

                    SqlDB.ExecuteNonQuery("delete from DOC_TRANS_ATTACH where doc_trans_id = '" & rowid & "'")
                    If Session(SessAttach) IsNot Nothing Then
                        Dim rDt As New DataTable
                        rDt = DirectCast(Session(SessAttach), DataTable)
                        If rDt.Rows.Count > 0 Then
                            Dim ret As Boolean = False
                            For Each rDr As DataRow In rDt.Rows
                                trans = New TransactionDB
                                trans.CreateTransaction()
                                Dim rID As Long = SqlDB.GetNextID("id", "DOC_TRANS_ATTACH", trans.Trans)
                                Dim sql As String = " INSERT INTO [DOC_TRANS_ATTACH]([id],[create_by],[create_on],[doc_trans_id] ,[attach])"
                                sql += " values('" & rID & "','" & Config.GetLogOnUser.UserName & "',getdate(),'" & rowid & "','" & rDr("attach") & "')"
                                ret = SqlDB.ExecuteNonQuery(sql, trans.Trans) > 0
                                If ret = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                End If
                            Next
                            rDt = Nothing
                        End If
                    End If
                Else
                    trans.RollbackTransaction()
                End If

                sys_err = ""
                Return True
            Catch ex As Exception
                sys_err = ex.Message
                Return False
            End Try
        End If
    End Function

    Private Sub init_page()
        cmbSecretID.Attributes.Add("OnChange", "MyApp(this)")
        SetcmbSecretID()
        SetcmbSpeedID()
        SetPoscriptID()
        SetTitleOwner()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            init_page()
        End If
    End Sub

    Private Sub SetcmbSecretID()
        Dim dt As DataTable
        dt = GetDataToList("select secret_name,secret_code from DOC_SECRET where active='Y' order by secret_code")
        dt.Rows(0)("secret_name") = "ชั้นความลับ(ถ้ามี)"

        cmbSecretID.DataTextField = "secret_name"
        cmbSecretID.DataValueField = "secret_code"
        cmbSecretID.DataSource = dt
        cmbSecretID.DataBind()

        cmbSecret1.DataTextField = "secret_name"
        cmbSecret1.DataValueField = "secret_code"
        cmbSecret1.DataSource = dt
        cmbSecret1.DataBind()
        dt = Nothing
    End Sub


    Private Sub SetcmbSpeedID()
        Dim fnc As New DocSpeedEng
        cmbSpeenID.SetItemList(fnc.GetDataSpeedList("active = 'Y' ", "speed_code"), "speed_name", "speed_code")
        fnc = Nothing
    End Sub

    Private Sub SetPoscriptID()
        Dim dt As DataTable
        dt = GetDataToList("select * from DOC_POSCRIPT order by poscript_code")
        cmbPoscriptID.SetItemList(dt, "poscript_name", "poscript_code")
        dt = Nothing
    End Sub

    'Private Sub SetOfficeSignID()
    '    Dim dt As DataTable

    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.organization_id in (select organization_id from OFFICER where username = '" + Config.GetLogOnUser.UserName + "')"

    '    dt = GetDataToList(sqltmp)

    '    cmbOfficeSignID.Items.Clear()
    '    cmbOfficeSignID.DataSource = dt
    '    cmbOfficeSignID.DataTextField = "full_name"
    '    cmbOfficeSignID.DataValueField = "username"
    '    cmbOfficeSignID.DataBind()
    '    dt = Nothing
    'End Sub

    Private Sub SetTitleOwner()
        Dim dt As DataTable

        sqltmp = "select distinct org_name,id from ORGANIZATION where active = 'Y' order by org_name"

        dt = GetDataToList(sqltmp)
        cmbTitleOwner.SetItemList(dt, "org_name", "id")
        dt = Nothing
        'Dim txt As String
        'txt = getdatafld("select distinct org_name,id from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "id")
        cmbTitleOwner.SelectedValue = Config.GetLogOnUser.ORG_DATA.ID
    End Sub

    'Private Sub SetPositionSign(ByVal UserName As String)
    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.username = '" + UserName + "'"

    '    txtPositionSign.Text = getdatafld(sqltmp, "description")
    'End Sub

#Region "ReferTo"
    Const SessReferTo As String = "SessReferTo"

    Protected Sub btnAddReferTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddReferTo.Click
        If txtrefto.Text.Trim <> "" Then
            Dim dt As New DataTable
            If Session(SessReferTo) Is Nothing Then
                dt.Columns.Add("id")
                dt.Columns.Add("refer_to")
            Else
                dt = Session(SessReferTo)
            End If

            Dim dr As DataRow = dt.NewRow
            dr("id") = "0"
            dr("refer_to") = txtrefto.Text
            dt.Rows.Add(dr)

            If dt.Rows.Count > 0 Then
                gvReferToList.DataSource = dt
                gvReferToList.DataBind()
                Session(SessReferTo) = dt
                txtrefto.Text = ""
            Else
                gvReferToList.DataSource = Nothing
                gvReferToList.DataBind()
                Session.Remove(SessReferTo)
            End If
        Else
            Config.SetAlert("กรุณากรอกอ้างถึง", Me.Page, txtrefto.ClientID)
        End If
    End Sub

    Protected Sub gvReferToList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvReferToList.RowCommand
        If e.CommandName = "Delete" Then
            Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim index As Integer = gvRow.RowIndex
            Dim dt As DataTable = Session(SessReferTo)
            dt.Rows.RemoveAt(index)

            gvReferToList.DataSource = dt
            gvReferToList.DataBind()
            Session(SessReferTo) = dt
        End If
    End Sub

    Protected Sub gvReferToList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvReferToList.RowDeleting

    End Sub
#End Region

#Region "Attach"
    Const SessAttach As String = "SessAttach"

    Protected Sub btnAddAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddAttach.Click
        If txtattach.Text.Trim <> "" Then
            Dim dt As New DataTable
            If Session(SessAttach) Is Nothing Then
                dt.Columns.Add("id")
                dt.Columns.Add("attach")
            Else
                dt = Session(SessAttach)
            End If

            Dim dr As DataRow = dt.NewRow
            dr("id") = "0"
            dr("attach") = txtattach.Text
            dt.Rows.Add(dr)

            If dt.Rows.Count > 0 Then
                gvAttachList.DataSource = dt
                gvAttachList.DataBind()
                Session(SessAttach) = dt
                txtattach.Text = ""
            Else
                gvAttachList.DataSource = Nothing
                gvAttachList.DataBind()
                Session.Remove(SessAttach)
            End If
        Else
            Config.SetAlert("กรุณากรอกอ้างถึง", Me.Page, txtattach.ClientID)
        End If
    End Sub

    Protected Sub gvAttachList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAttachList.RowCommand
        If e.CommandName = "Delete" Then
            Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
            Dim index As Integer = gvRow.RowIndex
            Dim dt As DataTable = Session(SessAttach)
            dt.Rows.RemoveAt(index)

            gvAttachList.DataSource = dt
            gvAttachList.DataBind()
            Session(SessAttach) = dt
        End If
    End Sub

    Protected Sub gvAttachList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAttachList.RowDeleting

    End Sub
#End Region

    
End Class
