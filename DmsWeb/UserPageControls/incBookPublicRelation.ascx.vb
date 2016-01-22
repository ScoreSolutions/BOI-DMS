Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookPublicRelation
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property VisibleAll() As Boolean
        Set(ByVal value As Boolean)
            BookNotice.Visible = value
            BookState.Visible = value
            BookNews.Visible = value
        End Set
    End Property
    Public WriteOnly Property VisibleNotice() As Boolean
        Set(ByVal value As Boolean)
            BookNotice.Visible = value
        End Set
    End Property
    Public WriteOnly Property VisibleState() As Boolean
        Set(ByVal value As Boolean)
            BookState.Visible = value
        End Set
    End Property
    Public WriteOnly Property VisibleNews() As Boolean
        Set(ByVal value As Boolean)
            BookNews.Visible = value
        End Set
    End Property

    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String, ByVal comm As Integer)
        If Baction Then
            If comm = FormBookNoticeID Then
                txtDate11.DateValue = Nothing
                txtTitle1.Text = ""
                txtTitleCommand1.Text = ""
                ctlDetail1.Text = ""
                'cmbOfficeSignID1.SelectedValue = "0"
                txtPositionSign1.Text = ""
            End If

            If comm = FormBookStateID Then
                txtDate12.DateValue = Nothing
                txtBookNo2.Text = ""
                TxtTitle2.Text = ""
                txtTitleCommand2.Text = ""
                ctlDetail2.Text = ""
                txtTitleOwner2.Text = ""
            End If

            If comm = FormBookNewsID Then
                txtDate13.DateValue = Nothing
                txtBookNo3.Text = ""
                TxtTitle3.Text = ""
                txtTitleCommand3.Text = ""
                ctlDetail3.Text = ""
                txtTitleOwner3.Text = ""
            End If

            init_page()

            If edit_mode = edit_data Then
                load_trans(True, rowid, comm)
            End If
        End If
    End Sub

    Public Sub load_trans(ByVal Baction As Boolean, ByVal rowid As String, ByVal comm As Integer)
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
                If comm = FormBookNoticeID Then
                    txtDate11.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    'txtDate21.DateValue = CDate(Ds.Tables("DATA").Rows(0).Item("doc_date2"))
                    'txtBookNo1.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    txtTitle1.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand1.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    ctlDetail1.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    'cmbOfficeSignID1.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign1.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If

                If comm = FormBookStateID Then
                    txtDate12.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))

                    TxtTitle2.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand2.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    txtBookNo2.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    ctlDetail2.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtTitleOwner2.Text = Ds.Tables("DATA").Rows(0).Item("doc_TitleOwner").ToString
                End If

                If comm = FormBookNewsID Then
                    txtDate13.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtBookNo3.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    TxtTitle3.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand3.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    ctlDetail3.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtTitleOwner3.Text = Ds.Tables("DATA").Rows(0).Item("doc_TitleOwner").ToString
                End If
            End If
        End If
    End Sub

    Private Function validate_field(ByVal comm As Integer) As Boolean
        Dim retval As Boolean = True

        If comm = FormBookNoticeID Then
            If txtDate11.DateValue = Nothing Then
                txtDate11.IsNotNull = True
                txtDate11.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ.วันที่"
                retval = False
            Else
                txtDate11.IsNotNull = False
            End If

            If ctlDetail1.Text.Trim = "" Then
                ctlDetail1.Focus()
                ctlDetail1.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                ctlDetail1.IsNotNull = False
            End If

            If txtTitle1.Text = "" Then
                txtTitle1.IsNotNull = True
                txtTitle1.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เรื่อง"
                retval = False
            Else
                txtTitle1.IsNotNull = False
            End If

            If txtTitleCommand1.Text = "" Then
                txtTitleCommand1.IsNotNull = True
                txtTitleCommand1.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ประกาศ"
                retval = False
            Else
                txtTitleCommand1.IsNotNull = False
            End If
        End If

        If comm = FormBookStateID Then
            If txtDate12.DateValue = Nothing Then
                txtDate12.IsNotNull = True
                txtDate12.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ.วันที่"
                retval = False
            Else
                txtDate12.IsNotNull = False
            End If

            If ctlDetail2.Text.Trim = "" Then
                ctlDetail2.Focus()
                ctlDetail2.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                ctlDetail2.IsNotNull = False
            End If

            If TxtTitle2.Text = "" Then
                TxtTitle2.IsNotNull = True
                TxtTitle2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เรื่อง"
                retval = False
            Else
                TxtTitle2.IsNotNull = False
            End If

            
            If txtTitleCommand2.Text = "" Then
                txtTitleCommand2.IsNotNull = True
                txtTitleCommand2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล แถลงการณ์"
                retval = False
            Else
                txtTitleCommand2.IsNotNull = False
            End If
        End If

        If comm = FormBookNewsID Then
            If txtDate13.DateValue = Nothing Then
                txtDate13.IsNotNull = True
                txtDate13.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ.วันที่"
                retval = False
            Else
                txtDate13.IsNotNull = False
            End If

            If ctlDetail3.Text.Trim = "" Then
                ctlDetail3.Focus()
                ctlDetail3.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                ctlDetail3.IsNotNull = False
            End If

            If TxtTitle3.Text = "" Then
                TxtTitle3.IsNotNull = True
                TxtTitle3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เรื่อง"
                retval = False
            Else
                TxtTitle3.IsNotNull = False
            End If

            
            If txtTitleCommand3.Text = "" Then
                txtTitleCommand3.IsNotNull = True
                txtTitleCommand3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ข่าว"
                retval = False
            Else
                txtTitleCommand3.IsNotNull = False
            End If
        End If

        Return retval
    End Function


    Private Sub init_page()
        txtTitleCommand1.IsNotNull = True
        txtTitle1.IsNotNull = True
        txtDate11.IsNotNull = True

        txtTitleCommand2.IsNotNull = True
        TxtTitle2.IsNotNull = True
        txtDate12.IsNotNull = True

        txtTitleCommand3.IsNotNull = True
        TxtTitle3.IsNotNull = True
        txtDate13.IsNotNull = True

        OrgOwner()

        SetcmbSecretID()
        SetcmbSpeedID()
        'SetPoscriptID()   'รอ table
        SetOfficeSignID()
        OfficeDescription()
        SetTitleOwner()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            init_page()
        End If
    End Sub

    Public Function save_trans(ByVal Baction As Boolean, ByVal rowid As String, ByVal comm As Integer) As Boolean
        If Baction Then
            If Not validate_field(comm) Then Return False

            Dim cmd As SqlCommand
            Dim docno As String = GetLastNo(YearZone)

            Try
                If rowid Is Nothing Or rowid = "" Then
                    If comm = FormBookNoticeID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        sqltmp = sqltmp + ",doc_title"
                        sqltmp = sqltmp + ",doc_titleCommand"
                        sqltmp = sqltmp + ",doc_detail"
                        sqltmp = sqltmp + ",doc_officesign"
                        sqltmp = sqltmp + ",doc_positionsign"
                        sqltmp = sqltmp + ",doc_create_date"
                        sqltmp = sqltmp + ",doc_create_by"
                        sqltmp = sqltmp + ",doc_status_date"
                        sqltmp = sqltmp + ",doc_status"
                        sqltmp = sqltmp + ",doc_type"
                        sqltmp = sqltmp + ") values ("
                        sqltmp = sqltmp + " '" + docno + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(txtDate11.DateValue, "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitle1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + cmbOfficeSignID1.SelectedValue + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookNoticeID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookStateID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        sqltmp = sqltmp + ",doc_title"
                        sqltmp = sqltmp + ",doc_titleCommand"
                        sqltmp = sqltmp + ",doc_refno"
                        sqltmp = sqltmp + ",doc_detail"
                        'sqltmp = sqltmp + ",doc_officesign"
                        'sqltmp = sqltmp + ",doc_positionsign"
                        sqltmp = sqltmp + ",doc_TitleOwner"
                        sqltmp = sqltmp + ",doc_create_date"
                        sqltmp = sqltmp + ",doc_create_by"
                        sqltmp = sqltmp + ",doc_status_date"
                        sqltmp = sqltmp + ",doc_status"
                        sqltmp = sqltmp + ",doc_type"
                        sqltmp = sqltmp + ") values ("
                        sqltmp = sqltmp + " '" + docno + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(TxtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail2.Text, "'", "''") + "'"
                        'sqltmp = sqltmp + ",'" + cmbOfficeSignID2.SelectedValue + "'"
                        'sqltmp = sqltmp + ",'" + txtPositionSign2.Text + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleOwner2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookStateID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookNewsID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        sqltmp = sqltmp + ",doc_title"
                        sqltmp = sqltmp + ",doc_titleCommand"
                        sqltmp = sqltmp + ",doc_refno"
                        sqltmp = sqltmp + ",doc_detail"
                        'sqltmp = sqltmp + ",doc_officesign"
                        'sqltmp = sqltmp + ",doc_positionsign"
                        sqltmp = sqltmp + ",doc_TitleOwner"
                        sqltmp = sqltmp + ",doc_create_date"
                        sqltmp = sqltmp + ",doc_create_by"
                        sqltmp = sqltmp + ",doc_status_date"
                        sqltmp = sqltmp + ",doc_status"
                        sqltmp = sqltmp + ",doc_type"
                        sqltmp = sqltmp + ") values ("
                        sqltmp = sqltmp + " '" + docno + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(TxtTitle3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail3.Text, "'", "''") + "'"
                        'sqltmp = sqltmp + ",'" + cmbOfficeSignID3.SelectedValue + "'"
                        'sqltmp = sqltmp + ",'" + txtPositionSign3.Text + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleOwner3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookNewsID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If
                Else
                    If comm = FormBookNoticeID Then
                        sqltmp = "update DOC_TRANS set "
                        'sqltmp = sqltmp + " doc_no='" + "" + "'"
                        sqltmp = sqltmp + "doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + cmbOfficeSignID1.SelectedValue + "'"
                        sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookStateID Then
                        sqltmp = "update DOC_TRANS set "
                        'sqltmp = sqltmp + " doc_no='" + txtBookNo2.Text + "'"
                        sqltmp = sqltmp + "doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(TxtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_refno='" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail2.Text, "'", "''") + "'"
                        'sqltmp = sqltmp + ",doc_officesign='" + cmbOfficeSignID2.SelectedValue + "'"
                        'sqltmp = sqltmp + ",doc_positionsign'" + txtPositionSign2.Text + "'"
                        sqltmp = sqltmp + ",doc_TitleOwner='" + Replace(txtTitleOwner2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookNewsID Then
                        sqltmp = "update DOC_TRANS set "
                        'sqltmp = sqltmp + " doc_no='" + txtBookNo3.Text + "'"
                        sqltmp = sqltmp + "doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(TxtTitle3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_refno='" + Replace(txtBookNo3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail3.Text, "'", "''") + "'"
                        'sqltmp = sqltmp + ",doc_officesign='" + cmbOfficeSignID3.SelectedValue + "'"
                        'sqltmp = sqltmp + ",doc_positionsign'" + txtPositionSign3.Text + "'"
                        sqltmp = sqltmp + ",doc_TitleOwner='" + Replace(txtTitleOwner3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If
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



    Private Sub SetcmbSecretID()
        'Dim dt As DataTable
        'dt = GetDataToList("select * from DOC_SECRET where active='Y' order by secret_code")
        'cmbSecretID.SetItemList(dt, "secret_name", "secret_code")
    End Sub


    Private Sub SetcmbSpeedID()
        'Dim dt As DataTable
        'dt = GetDataToList("select * from DOC_SPEED where active='Y' order by speed_code")
        'cmbSpeenID.SetItemList(dt, "speed_name", "speed_code")
    End Sub

    Private Sub SetPoscriptID()
        'Dim dt As DataTable
        'dt = GetDataToList("select * from DOC_SPEED where active='Y' order by speed_code")
        'cmbPoscriptID.SetItemList(dt, "speed_name", "speed_code")
    End Sub

    Private Sub SetOfficeSignID()
        Dim dt As DataTable

        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.organization_id in (select organization_id from OFFICER where username = '" + Config.GetLogOnUser.UserName + "')"

        dt = GetDataToList(sqltmp)
        cmbOfficeSignID1.SetItemList(dt, "full_name", "username")

        cmbOfficeSignID1.SelectedValue = Config.GetLogOnUser.UserName
    End Sub

    Private Sub OfficeDescription()
        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

        txtPositionSign1.Text = getdatafld(sqltmp, "description")
    End Sub

    Private Sub OrgOwner()
        'sqltmp = "Select g.org_name,g.address_thai "
        'sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        'sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

        'txtOrgBookOwner.Text = getdatafld(sqltmp, "org_name")
        'txtOwnerAddress.Text = getdatafld(sqltmp, "address_thai")
    End Sub

    Private Sub SetTitleOwner()
        'Dim dt As DataTable

        'sqltmp = "select distinct org_name,org_code from ORGANIZATION where active = 'Y'"

        'dt = GetDataToList(sqltmp)
        'cmbTitleOwner.SetItemList(dt, "org_name", "org_code")

        'Dim txt As String
        'txt = getdatafld("select distinct org_name,org_code from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_code")
        'cmbTitleOwner.SelectedValue = txt
    End Sub

    Protected Sub cmbOfficeSignID1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID1.SelectedIndexChanged
        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID1.SelectedValue + "'"

        txtPositionSign1.Text = getdatafld(sqltmp, "description")
    End Sub
End Class
