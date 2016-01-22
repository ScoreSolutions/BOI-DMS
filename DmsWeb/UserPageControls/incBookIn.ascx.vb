Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookIn
    Inherits System.Web.UI.UserControl


    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String)
        If Baction Then
            txtBookNo.Text = ""
            txtOrgBookOwner.Text = ""
            txtTitle.Text = ""
            txtLean.Text = ""
            ctlDetail.Text = ""
            txtPositionSign.Text = ""

            init_page()

            If edit_mode = edit_data Then
                load_trans(True, rowid)
            End If
        End If
    End Sub

    Public Sub load_trans(ByVal Baction As Boolean, ByVal rowid As String)
        If Baction Then
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
                cmbSpeenID.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_speed").ToString
                If Convert.IsDBNull(Ds.Tables("DATA").Rows(0).Item("doc_date1")) = False Then
                    txtDate1.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                End If
                txtBookNo.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                txtOrgBookOwner.Text = Ds.Tables("DATA").Rows(0).Item("doc_OrgBookOwner").ToString
                txtTitle.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                txtLean.Text = Ds.Tables("DATA").Rows(0).Item("doc_lean").ToString
                ctlDetail.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString

                If Ds.Tables("DATA").Rows(0)("doc_obj_to").ToString = Para.Common.Utilities.Constant.DocObjective.ObjApprove And Ds.Tables("DATA").Rows(0)("doc_approved").ToString = "1" And Ds.Tables("DATA").Rows(0)("doc_status").ToString = cfg_docstart Then
                    tbOfficerSign.Visible = True
                Else
                    tbOfficerSign.Visible = False
                    txtOfficerSign.Text = ""
                    txtPositionSign.Text = ""
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

        'If txtDate1.DateValue = Nothing Then
        '    txtDate1.IsNotNull = True
        '    txtDate1.Focus()
        '    sys_err = "ยังไม่ได้กรอกข้อมูล วันที่"
        '    retval = False
        'Else
        '    txtDate1.IsNotNull = False
        'End If

        Return retval
    End Function

    Public Function save_trans(ByVal Baction As Boolean, ByVal rowid As String) As Boolean


        If Baction Then
            If Not validate_field() Then Return False

            Dim cmd As SqlCommand
            Try
                Dim uPara As New Para.Common.UserProfilePara
                uPara = Config.GetLogOnUser

                If rowid Is Nothing Or rowid = "" Then
                    Dim docno As String = GetLastNo(YearZone)

                    sqltmp = "insert into DOC_TRANS ("
                    sqltmp = sqltmp + " doc_no"
                    sqltmp = sqltmp + ",doc_secret"
                    sqltmp = sqltmp + ",doc_speed"
                    sqltmp = sqltmp + ",doc_date1"
                    sqltmp = sqltmp + ",doc_refno"
                    sqltmp = sqltmp + ",doc_OrgBookOwner"
                    'sqltmp = sqltmp + ",doc_OwnerAddress"
                    sqltmp = sqltmp + ",doc_title"
                    sqltmp = sqltmp + ",doc_lean"
                    'sqltmp = sqltmp + ",doc_refto"
                    'sqltmp = sqltmp + ",doc_attach"
                    sqltmp = sqltmp + ",doc_detail"
                    'sqltmp = sqltmp + ",doc_poscript"
                    sqltmp = sqltmp + ",doc_officesign"
                    sqltmp = sqltmp + ",doc_positionsign"
                    'sqltmp = sqltmp + ",doc_TitleOwner"
                    'sqltmp = sqltmp + ",doc_tel"
                    'sqltmp = sqltmp + ",doc_fax"
                    'sqltmp = sqltmp + ",doc_addr"
                    'sqltmp = sqltmp + ",doc_ccto"
                    sqltmp = sqltmp + ",doc_create_date"
                    sqltmp = sqltmp + ",doc_create_by"
                    sqltmp = sqltmp + ",doc_status_date"
                    sqltmp = sqltmp + ",doc_status"
                    sqltmp = sqltmp + ",doc_type"
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
                    'sqltmp = sqltmp + ",'" + txtOwnerAddress.Text + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtTitle.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtLean.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",'" + txtRefTo.Text + "'"
                    'sqltmp = sqltmp + ",'" + txtAttach.Text + "'"
                    sqltmp = sqltmp + ",'" + Replace(ctlDetail.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",'" + cmbPoscriptID.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtOfficerSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",'" + Replace(txtPositionSign.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",'" + cmbTitleOwner.SelectedValue + "'"
                    'sqltmp = sqltmp + ",'" + txtTel.Text + "'"
                    'sqltmp = sqltmp + ",'" + txtFax.Text + "'"
                    'sqltmp = sqltmp + ",'" + txtOfficeAddress.Text + "'"
                    'sqltmp = sqltmp + ",'" + txtCCTo.Text + "'"
                    sqltmp = sqltmp + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) + "'"
                    sqltmp = sqltmp + ",'" + uPara.UserName + "'"
                    sqltmp = sqltmp + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) + "'"
                    sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                    sqltmp = sqltmp + ", " + FormBookInID.ToString + " "
                    sqltmp = sqltmp + ",'Y')"
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
                    'sqltmp = sqltmp + ",doc_OwnerAddress='" + txtOwnerAddress.Text + "'"
                    sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_lean='" + Replace(txtLean.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",doc_refto='" + txtRefTo.Text + "'"
                    'sqltmp = sqltmp + ",doc_attach='" + txtAttach.Text + "'"
                    sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",doc_poscript='" + cmbPoscriptID.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_officesign='" + Replace(txtOfficerSign.Text, "'", "''") + "'"
                    sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign.Text, "'", "''") + "'"
                    'sqltmp = sqltmp + ",doc_TitleOwner='" + cmbTitleOwner.SelectedValue + "'"
                    'sqltmp = sqltmp + ",doc_tel='" + txtTel.Text + "'"
                    'sqltmp = sqltmp + ",doc_fax='" + txtFax.Text + "'"
                    'sqltmp = sqltmp + ",doc_addr='" + txtOfficeAddress.Text + "'"
                    'sqltmp = sqltmp + ",doc_ccto='" + txtCCTo.Text + "'"
                    sqltmp = sqltmp + ",doc_edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US")) + "'"
                    sqltmp = sqltmp + ",doc_edit_by='" + uPara.UserName + "'"
                    'sqltmp = sqltmp + ",doc_status_date='" + Format(txtCreateDate.DateValue, "yyyy/MM/dd") + "'"
                    'sqltmp = sqltmp + ",doc_status='" + "2" + "'"
                    sqltmp = sqltmp + " where id = " + rowid
                End If
                uPara = Nothing

                condb()
                conn.Open()
                cmd = conn.CreateCommand()
                cmd = New SqlCommand(sqltmp, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
                Return True
            Catch ex As Exception
                conn.Close()
                Return False
            End Try
        End If
    End Function

    Private Sub init_page()
        cmbSecretID.Attributes.Add("OnChange", "MyApp(this)")
        OrgOwner()
        SetcmbSecretID()
        SetcmbSpeedID()
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
        Dim dt As DataTable
        dt = GetDataToList("select * from DOC_SPEED where active='Y' order by speed_code")
        cmbSpeenID.SetItemList(dt, "speed_name", "speed_code")
        dt = Nothing
    End Sub

    Private Sub OrgOwner()
        sqltmp = "Select g.org_name,g.address_thai "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

        txtOrgBookOwner.Text = getdatafld(sqltmp, "org_name")
    End Sub
End Class
