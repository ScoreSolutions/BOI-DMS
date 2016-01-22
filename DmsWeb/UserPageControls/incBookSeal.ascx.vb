Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookSeal
    Inherits System.Web.UI.UserControl

    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String)
        If Baction Then
            'cmbSecretID.SelectedValue = "0"
            'cmbSpeenID.SelectedValue = "0"
            txtBookNo.Text = ""
            txtOrgBookOwner.Text = ""
            txtLean.Text = ""
            ctlDetail.Text = ""
            txtOrgTitleOwner.Text = ""
            txtTel.Text = ""
            txtFax.Text = ""
            txtOfficeAddress.Text = ""

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
                txtBookNo.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                txtOrgBookOwner.Text = Ds.Tables("DATA").Rows(0).Item("doc_OrgBookOwner").ToString
                txtLean.Text = Ds.Tables("DATA").Rows(0).Item("doc_lean").ToString
                ctlDetail.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                txtOrgTitleOwner.Text = Ds.Tables("DATA").Rows(0).Item("doc_TitleOwner").ToString
                txtTel.Text = Ds.Tables("DATA").Rows(0).Item("doc_tel").ToString
                txtFax.Text = Ds.Tables("DATA").Rows(0).Item("doc_fax").ToString
                txtOfficeAddress.Text = Ds.Tables("DATA").Rows(0).Item("doc_addr").ToString
            End If
        End If
    End Sub

    Private Function validate_field() As Boolean
        Dim retval As Boolean = True

        If txtOrgTitleOwner.Text = "" Then
            txtOrgTitleOwner.IsNotNull = True
            txtOrgTitleOwner.Focus()
            sys_err = "ยังไม่ได้กรอกข้อมูล ส่วนราชการเจ้าของเรื่อง"
            retval = False
        Else
            txtOrgTitleOwner.IsNotNull = False
        End If

        If txtOrgBookOwner.Text = "" Then
            txtOrgBookOwner.IsNotNull = True
            txtOrgBookOwner.Focus()
            sys_err = "ยังไม่ได้กรอกข้อมูล ส่วนราชการ"
            retval = False
        Else
            txtOrgBookOwner.IsNotNull = False
        End If

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
            sys_err = "ยังไม่ได้กรอกข้อมูล ถึง"
            retval = False
        Else
            txtLean.IsNotNull = False
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
                    sqltmp = sqltmp + ",doc_lean"
                    sqltmp = sqltmp + ",doc_detail"
                    sqltmp = sqltmp + ",doc_TitleOwner"
                    sqltmp = sqltmp + ",doc_tel"
                    sqltmp = sqltmp + ",doc_fax"
                    sqltmp = sqltmp + ",doc_addr"
                    sqltmp = sqltmp + ",doc_create_date"
                    sqltmp = sqltmp + ",doc_create_by"
                    sqltmp = sqltmp + ",doc_status_date"
                    sqltmp = sqltmp + ",doc_status"
                    sqltmp = sqltmp + ",doc_type"
                    sqltmp = sqltmp + ") values ("
                    sqltmp = sqltmp + " '" + docno + "'"
                    sqltmp = sqltmp + ",'" + cmbSecretID.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + cmbSpeenID.SelectedValue + "'"
                    sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",'" + txtBookNo.Text + "'"
                    sqltmp = sqltmp + ",'" + txtOrgBookOwner.Text + "'"
                    sqltmp = sqltmp + ",'" + txtLean.Text + "'"
                    sqltmp = sqltmp + ",'" + ctlDetail.Text + "'"
                    sqltmp = sqltmp + ",'" + txtOrgTitleOwner.Text + "'"
                    sqltmp = sqltmp + ",'" + txtTel.Text + "'"
                    sqltmp = sqltmp + ",'" + txtFax.Text + "'"
                    sqltmp = sqltmp + ",'" + txtOfficeAddress.Text + "'"
                    sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                    sqltmp = sqltmp + ", " + FormBookSealID.ToString + " "
                    sqltmp = sqltmp + ")"
                Else
                    sqltmp = "update DOC_TRANS set "
                    sqltmp = sqltmp + "doc_secret='" + cmbSecretID.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_speed='" + cmbSpeenID.SelectedValue + "'"
                    sqltmp = sqltmp + ",doc_refno='" + txtBookNo.Text + "'"
                    sqltmp = sqltmp + ",doc_OrgBookOwner='" + txtOrgBookOwner.Text + "'"
                    sqltmp = sqltmp + ",doc_lean='" + txtLean.Text + "'"
                    sqltmp = sqltmp + ",doc_detail='" + ctlDetail.Text + "'"
                    sqltmp = sqltmp + ",doc_TitleOwner='" + txtOrgTitleOwner.Text + "'"
                    sqltmp = sqltmp + ",doc_tel='" + txtTel.Text + "'"
                    sqltmp = sqltmp + ",doc_fax='" + txtFax.Text + "'"
                    sqltmp = sqltmp + ",doc_addr='" + txtOfficeAddress.Text + "'"
                    sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                    sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                    sqltmp = sqltmp + " where id = " + rowid
                End If

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
        txtLean.IsNotNull = True
        txtOrgTitleOwner.IsNotNull = True
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

        If dt.Rows.Count > 0 Then
            dt.Rows(0)("secret_name") = "ชั้นความลับ (ถ้ามี)"

            cmbSecretID.DataTextField = "secret_name"
            cmbSecretID.DataValueField = "secret_code"
            cmbSecretID.DataSource = dt
            cmbSecretID.DataBind()

            cmbSecret1.DataTextField = "secret_name"
            cmbSecret1.DataValueField = "secret_code"
            cmbSecret1.DataSource = dt
            cmbSecret1.DataBind()

            dt = Nothing
        End If
    End Sub

    Private Sub SetcmbSpeedID()
        Dim dt As DataTable
        dt = GetDataToList("select * from DOC_SPEED where active='Y' order by speed_code")
        If dt.Rows.Count > 0 Then
            dt.Rows(0)("speed_name") = "ชั้นความเร็ว (ถ้ามี)"
            cmbSpeenID.SetItemList(dt, "speed_name", "speed_code")
        End If
        dt = Nothing
    End Sub

    Private Sub OrgOwner()
        sqltmp = "Select g.org_name,g.address_thai "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

        txtOrgBookOwner.Text = getdatafld(sqltmp, "org_name")
    End Sub

End Class
