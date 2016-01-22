Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookEvidence
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property VisibleAll() As Boolean
        Set(ByVal value As Boolean)
            BookAssure.Visible = value
            BookMinutes.Visible = value
            BookNote.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleAssure() As Boolean
        Set(ByVal value As Boolean)
            BookAssure.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleMinutes() As Boolean
        Set(ByVal value As Boolean)
            BookMinutes.Visible = value
        End Set
    End Property
    Public WriteOnly Property VisibleNote() As Boolean
        Set(ByVal value As Boolean)
            BookNote.Visible = value
        End Set
    End Property

    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String, ByVal comm As Integer)
        If Baction Then
            If comm = FormBookAssureID Then
                txtDate11.DateValue = Nothing
                txtBookNo1.Text = ""
                txtTitleOwner1.Text = ""
                CtlDetail1.Text = ""
                'cmbOfficeSignID1.SelectedValue = "0"
                txtPositionSign1.Text = ""
            End If

            If comm = FormBookMinutesID Then
                txtDate12.DateValue = Nothing
                txtTime12.TimeText = ""

                txtDate22.DateValue = Nothing
                txtTime22.TimeText = ""

                txtBookNo2.Text = ""
                txtTitle2.Text = ""
                txtwhen2.Text = ""
                CtlDetail2.Text = ""
                txtat2.Text = ""
                txtregis2.Text = ""
                txtnomeet2.Text = ""
                txtmeet2.Text = ""
                cmbOfficeSignID2.Text = ""
            End If

            If comm = FormBookNoteID Then
                txtDate13.DateValue = Nothing
                txtLean3.Text = ""
                ctlTitleGroup3.SetGroupTitle(0)
                txtTitle3.Text = ""
                CtlDetail3.Text = ""
                'cmbOfficeSignID3.SelectedValue = "0"
                txtPositionSign3.Text = ""
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
                If comm = FormBookAssureID Then
                    txtDate11.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtBookNo1.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    txtTitleOwner1.Text = Ds.Tables("DATA").Rows(0).Item("doc_TitleOwner").ToString
                    CtlDetail1.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    cmbOfficeSignID1.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign1.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If

                If comm = FormBookMinutesID Then
                    txtDate12.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtTime12.TimeText = Format(CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")), "HH:mm")

                    txtDate22.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date2")))
                    txtTime22.TimeText = Format(CDate(Ds.Tables("DATA").Rows(0).Item("doc_date2")), "HH:mm")

                    txtBookNo2.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    txtTitle2.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtwhen2.Text = Ds.Tables("DATA").Rows(0).Item("doc_title_When").ToString
                    CtlDetail2.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtat2.Text = Ds.Tables("DATA").Rows(0).Item("doc_Title_at").ToString
                    txtregis2.Text = Ds.Tables("DATA").Rows(0).Item("doc_title_regis").ToString
                    txtnomeet2.Text = Ds.Tables("DATA").Rows(0).Item("doc_Title_nomeet").ToString
                    txtmeet2.Text = Ds.Tables("DATA").Rows(0).Item("doc_Title_meet").ToString
                    cmbOfficeSignID2.Text = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                End If

                If comm = FormBookNoteID Then
                    txtDate13.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtLean3.Text = Ds.Tables("DATA").Rows(0).Item("doc_lean").ToString

                    Dim gID As String
                    gID = getdatafld("select id from GROUP_TITLE where group_title_code = '" + Ds.Tables("DATA").Rows(0).Item("doc_title_group").ToString + "'", "id")
                    ctlTitleGroup3.SetGroupTitle(gID)

                    txtTitle3.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    CtlDetail3.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    cmbOfficeSignID3.SelectedValue = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign3.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If
            End If
        End If
    End Sub

    Private Function validate_field(ByVal comm As Integer) As Boolean
        Dim retval As Boolean = True

        If comm = FormBookAssureID Then
            If txtDate11.DateValue = Nothing Then
                txtDate11.IsNotNull = True
                txtDate11.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                txtDate11.IsNotNull = False
            End If

            If CtlDetail1.Text.Trim = "" Then
                CtlDetail1.Focus()
                CtlDetail1.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                CtlDetail1.IsNotNull = False
            End If
        End If

        If comm = FormBookMinutesID Then
            If txtTime22.TimeText = Nothing Then
                txtTime22.IsNotNull = True
                txtTime22.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เลิกประชุมเวลา"
                retval = False
            Else
                txtTime22.IsNotNull = False
            End If
            If txtDate22.DateValue = Nothing Then
                txtDate22.IsNotNull = True
                txtDate22.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เลิกประชุมวันที่"
                retval = False
            Else
                txtDate22.IsNotNull = False
            End If

            If CtlDetail2.Text.Trim = "" Then
                CtlDetail2.Focus()
                CtlDetail2.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                CtlDetail2.IsNotNull = False
            End If

            If txtTime12.TimeText = Nothing Then
                txtTime12.IsNotNull = True
                txtTime12.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เริ่มประชุมเวลา"
                retval = False
            Else
                txtTime12.IsNotNull = False
            End If

            If txtDate12.DateValue = Nothing Then
                txtDate12.IsNotNull = True
                txtDate12.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เริ่มประชุมวันที่"
                retval = False
            Else
                txtDate12.IsNotNull = False
            End If

            If txtat2.Text = "" Then
                txtat2.IsNotNull = True
                txtat2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ."
                retval = False
            Else
                txtat2.IsNotNull = False
            End If

            If txtBookNo2.Text = "" Then
                txtBookNo2.IsNotNull = True
                txtBookNo2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เมื่อ"
                retval = False
            Else
                txtBookNo2.IsNotNull = False
            End If

            If txtwhen2.Text = "" Then
                txtwhen2.IsNotNull = True
                txtwhen2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ครั้งที่"
                retval = False
            Else
                txtwhen2.IsNotNull = False
            End If
            If txtTitle2.Text = "" Then
                txtTitle2.IsNotNull = True
                txtTitle2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล รายงานการประชุม"
                retval = False
            Else
                txtTitle2.IsNotNull = False
            End If
        End If

        If comm = FormBookNoteID Then
            

            If txtDate13.DateValue = Nothing Then
                txtDate13.IsNotNull = True
                txtDate13.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล วันที่บันทึก"
                retval = False
            Else
                txtDate13.IsNotNull = False
            End If

            If CtlDetail3.Text.Trim = "" Then
                CtlDetail3.Focus()
                CtlDetail3.IsNotNull = True
                sys_err = "ยังไม่ได้กรอกข้อมูล สาระสำคัญ"
                retval = False
            Else
                CtlDetail3.IsNotNull = False
            End If

            If txtTitle3.Text = "" Then
                txtTitle3.IsNotNull = True
                txtTitle3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ชื่อเรื่อง"
                retval = False
            Else
                txtTitle3.IsNotNull = False
            End If

            If ctlTitleGroup3.Value = "" Then
                ctlTitleGroup3.IsNotNull = True
                ctlTitleGroup3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล กลุ่มเรื่อง"
                retval = False
            Else
                ctlTitleGroup3.IsNotNull = False
            End If

            If txtLean3.Text = "" Then
                txtLean3.IsNotNull = True
                txtLean3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล บันทึกถึง"
                retval = False
            Else
                txtLean3.IsNotNull = False
            End If
        End If

        Return retval
    End Function

    Private Sub init_page()
        'txtDate12.IsNotNull = True
        'txtTime12.IsNotNull = True
        'txtDate22.IsNotNull = True
        'txtTime22.IsNotNull = True
        'txtTitle2.IsNotNull = True
        'txtwhen2.IsNotNull = True
        'txtregis2.IsNotNull = True
        'txtmeet2.IsNotNull = True
        'txtnomeet2.IsNotNull = True
        'ctlTitleGroup3.IsNotNull = True
        'txtDate11.IsNotNull = True
        'txtDate13.IsNotNull = True
        'txtLean3.IsNotNull = True
        'validate_field()

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
                    If comm = FormBookAssureID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_refno"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        'sqltmp = sqltmp + ",doc_title"
                        sqltmp = sqltmp + ",doc_OrgBookOwner"
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
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        'sqltmp = sqltmp + ",'" + txtTitle1.Text + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleOwner1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(CtlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + cmbOfficeSignID1.SelectedValue + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookAssureID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookMinutesID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_refno"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        sqltmp = sqltmp + ",doc_title"
                        sqltmp = sqltmp + ",doc_title_When"
                        sqltmp = sqltmp + ",doc_title_at"
                        sqltmp = sqltmp + ",doc_title_regis"
                        sqltmp = sqltmp + ",doc_title_meet"
                        sqltmp = sqltmp + ",doc_title_nomeet"
                        sqltmp = sqltmp + ",doc_detail"
                        sqltmp = sqltmp + ",doc_officesign"
                        'sqltmp = sqltmp + ",doc_positionsign"
                        sqltmp = sqltmp + ",doc_create_date"
                        sqltmp = sqltmp + ",doc_create_by"
                        sqltmp = sqltmp + ",doc_status_date"
                        sqltmp = sqltmp + ",doc_status"
                        sqltmp = sqltmp + ",doc_type"
                        sqltmp = sqltmp + ") values ("
                        sqltmp = sqltmp + " '" + docno + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + " " + txtTime12.TimeText + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate22.DateValue), "yyyy/MM/dd") + " " + txtTime22.TimeText + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtwhen2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtat2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtregis2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtmeet2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtnomeet2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(CtlDetail2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(cmbOfficeSignID2.Text, "'", "''") + "'"
                        'sqltmp = sqltmp + ",'" + txtPositionSign2.Text + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookMinutesID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookNoteID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_date1"
                        sqltmp = sqltmp + ",doc_date2"
                        sqltmp = sqltmp + ",doc_lean"
                        sqltmp = sqltmp + ",doc_title_group"
                        sqltmp = sqltmp + ",doc_title"
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
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtLean3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + ctlTitleGroup3.defval + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitle3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(CtlDetail3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + cmbOfficeSignID3.SelectedValue + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookNoteID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If
                Else
                    If comm = FormBookAssureID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_refno='" + Replace(txtBookNo1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_OrgBookOwner='" + Replace(txtTitleOwner1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(CtlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + cmbOfficeSignID1.SelectedValue + "'"
                        sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookMinutesID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_refno='" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + " " + txtTime12.TimeText + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate22.DateValue), "yyyy/MM/dd") + " " + txtTime22.TimeText + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_When='" + Replace(txtwhen2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_at='" + Replace(txtat2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_regis='" + Replace(txtregis2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_meet='" + Replace(txtmeet2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_nomeet='" + Replace(txtnomeet2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(CtlDetail2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + Replace(cmbOfficeSignID2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookNoteID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_lean='" + Replace(txtLean3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_title_group='" + ctlTitleGroup3.defval + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(CtlDetail3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + cmbOfficeSignID3.SelectedValue + "'"
                        sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign3.Text, "'", "''") + "'"
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

        dt = GetDataToList(sqltmp)
        cmbOfficeSignID3.SetItemList(dt, "full_name", "username")
        cmbOfficeSignID3.SelectedValue = Config.GetLogOnUser.UserName
    End Sub


    Private Sub OfficeDescription()
        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

        txtPositionSign1.Text = getdatafld(sqltmp, "description")
        'txtPositionSign2.Text = getdatafld(sqltmp, "description")
        txtPositionSign3.Text = getdatafld(sqltmp, "description")
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
        'txt = getdatafld("select distinct org_name,id from ORGANIZATION where active = 'Y' and id in (select organization_id from ROLES_USER where login_username = '" + Config.GetLogOnUser.UserName + "') ", "org_name")
        txtTitleOwner1.Text = Config.GetLogOnUser.ORG_DATA.ORG_NAME
    End Sub

    Protected Sub cmbOfficeSignID1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID1.SelectedIndexChanged
        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID1.SelectedValue + "'"

        txtPositionSign1.Text = getdatafld(sqltmp, "description")
    End Sub

    Protected Sub cmbOfficeSignID3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID3.SelectedIndexChanged
        sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
        sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
        sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID3.SelectedValue + "'"

        txtPositionSign3.Text = getdatafld(sqltmp, "description")
    End Sub
End Class
