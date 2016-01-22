﻿Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.TABLE
Imports Linq.Common.Utilities.SqlDB
Imports Para.Common.Utilities.Constant.ElecDocStatus

Partial Class UserPageControls_incBookCommand
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property VisibleCommand() As Boolean
        Set(ByVal value As Boolean)
            BookCommand.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleRule() As Boolean
        Set(ByVal value As Boolean)
            BookRule.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleRegulation() As Boolean
        Set(ByVal value As Boolean)
            BookRegulation.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleAll() As Boolean
        Set(ByVal value As Boolean)
            BookCommand.Visible = value
            BookRule.Visible = value
            BookRegulation.Visible = value
        End Set
    End Property


    Public Sub clear(ByVal Baction As Boolean, ByVal rowid As String, ByVal comm As Integer)
        If Baction Then
            If comm = FormBookCommandID Then
                txtDate11.DateValue = Nothing
                txtDate21.DateValue = Nothing
                txtBookNo1.Text = ""
                txtTitle1.Text = ""
                txtTitleCommand1.Text = ""
                ctlDetail1.Text = ""
                'cmbOfficeSignID1.SelectedValue = "0"
                txtPositionSign1.Text = ""
            End If

            If comm = FormBookRuleID Then
                txtDate12.DateValue = Nothing
                txtBookNo2.Text = ""
                TxtTitle2.Text = ""
                txtTitleCommand2.Text = ""
                ctlDetail2.Text = ""
                'cmbOfficeSignID2.SelectedValue = "0"
                txtPositionSign2.Text = ""
            End If

            If comm = FormBookRegulationID Then
                txtDate13.DateValue = Nothing
                txtBookNo3.Text = ""
                TxtTitle3.Text = ""
                txtTitleCommand3.Text = ""
                ctlDetail3.Text = ""
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
                If comm = FormBookCommandID Then
                    txtDate11.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtDate21.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date2")))
                    txtBookNo1.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    txtTitle1.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand1.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    ctlDetail1.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtOfficerSign1.Text = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign1.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If

                If comm = FormBookRuleID Then
                    txtDate12.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtBookNo2.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    TxtTitle2.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand2.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    ctlDetail2.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtOfficerSign2.Text = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign2.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If

                If comm = FormBookRegulationID Then
                    txtDate13.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("doc_date1")))
                    txtBookNo3.Text = Ds.Tables("DATA").Rows(0).Item("doc_refno").ToString
                    TxtTitle3.Text = Ds.Tables("DATA").Rows(0).Item("doc_title").ToString
                    txtTitleCommand3.Text = Ds.Tables("DATA").Rows(0).Item("doc_titlecommand").ToString
                    ctlDetail3.Text = Ds.Tables("DATA").Rows(0).Item("doc_detail").ToString
                    txtOfficerSign3.Text = Ds.Tables("DATA").Rows(0).Item("doc_officesign").ToString
                    txtPositionSign3.Text = Ds.Tables("DATA").Rows(0).Item("doc_positionsign").ToString
                End If
            End If
        End If
    End Sub

    Private Function validate_field(ByVal comm As Integer) As Boolean
        Dim retval As Boolean = True

        If comm = FormBookCommandID Then
            If txtDate11.DateValue = Nothing Then
                txtDate11.IsNotNull = True
                txtDate11.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ วันที่"
                retval = False
            Else
                txtDate11.IsNotNull = False
            End If

            If txtDate21.DateValue = Nothing Then
                txtDate21.IsNotNull = True
                txtDate21.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ตั้งแต่ วันที่"
                retval = False
            Else
                txtDate21.IsNotNull = False
            End If

            If ctlDetail1.Text.Trim = "" Then
                ctlDetail1.IsNotNull = True
                ctlDetail1.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                txtDate11.IsNotNull = False
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
                sys_err = "ยังไม่ได้กรอกข้อมูล คำสั่ง"
                retval = False
            Else
                txtTitleCommand1.IsNotNull = False
            End If
        End If

        If comm = FormBookRuleID Then
            If txtDate12.DateValue = Nothing Then
                txtDate12.IsNotNull = True
                txtDate12.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ วันที่"
                retval = False
            Else
                txtDate12.IsNotNull = False
            End If

            If ctlDetail2.Text.Trim = "" Then
                ctlDetail2.IsNotNull = True
                ctlDetail2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                txtDate12.IsNotNull = False
            End If

            If TxtTitle2.Text = "" Then
                TxtTitle2.IsNotNull = True
                TxtTitle2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ว่าด้วย"
                retval = False
            Else
                TxtTitle2.IsNotNull = False
            End If

            If txtTitleCommand2.Text = "" Then
                txtTitleCommand2.IsNotNull = True
                txtTitleCommand2.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ระเบียบ"
                retval = False
            Else
                txtTitleCommand2.IsNotNull = False
            End If
        End If

        If comm = FormBookRegulationID Then
            If txtDate13.DateValue = Nothing Then
                txtDate13.IsNotNull = True
                txtDate13.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ณ วันที่"
                retval = False
            Else
                txtDate13.IsNotNull = False
            End If

            If ctlDetail3.Text.Trim = "" Then
                ctlDetail3.IsNotNull = True
                ctlDetail3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล เนื้อความ"
                retval = False
            Else
                txtDate13.IsNotNull = False
            End If

            If TxtTitle3.Text = "" Then
                TxtTitle3.IsNotNull = True
                TxtTitle3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ว่าด้วย"
                retval = False
            Else
                TxtTitle3.IsNotNull = False
            End If
            If txtTitleCommand3.Text = "" Then
                txtTitleCommand3.IsNotNull = True
                txtTitleCommand3.Focus()
                sys_err = "ยังไม่ได้กรอกข้อมูล ข้อบังคับ"
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
        txtDate21.IsNotNull = True

        txtTitleCommand2.IsNotNull = True
        TxtTitle2.IsNotNull = True
        txtDate12.IsNotNull = True

        txtTitleCommand3.IsNotNull = True
        TxtTitle3.IsNotNull = True
        txtDate13.IsNotNull = True

        'validate_field()
        'SetOfficeSignID()
        'OfficeDescription()
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
                    If comm = FormBookCommandID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_refno"
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
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate21.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitle1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtOfficerSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookCommandID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookRuleID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_refno"
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
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(TxtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtOfficerSign2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookRuleID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If

                    If comm = FormBookRegulationID Then
                        sqltmp = "insert into DOC_TRANS ("
                        sqltmp = sqltmp + " doc_no"
                        sqltmp = sqltmp + ",doc_refno"
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
                        sqltmp = sqltmp + ",'" + Replace(txtBookNo3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Replace(TxtTitle3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtTitleCommand3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(ctlDetail3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtOfficerSign3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Replace(txtPositionSign3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + ",'" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",'" + cfg_docrunning + "'"
                        sqltmp = sqltmp + ", " + FormBookRegulationID.ToString + " "
                        sqltmp = sqltmp + ")"
                    End If
                Else
                    If comm = FormBookCommandID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_refno='" + Replace(txtBookNo1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate11.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate21.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(txtTitle1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + Replace(txtOfficerSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign1.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookRuleID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_refno='" + Replace(txtBookNo2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate12.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + Replace(TxtTitle2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + Replace(txtOfficerSign2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_positionsign='" + Replace(txtPositionSign2.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_edit_date='" + Format(DateAdd(DateInterval.Year, YearZoneSave, Date.Now), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_edit_by='" + Config.GetLogOnUser.UserName + "'"
                        sqltmp = sqltmp + " where id = " + rowid
                    End If

                    If comm = FormBookRegulationID Then
                        sqltmp = "update DOC_TRANS set "
                        sqltmp = sqltmp + " doc_refno='" + Replace(txtBookNo3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_date1='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_date2='" + Format(DateAdd(DateInterval.Year, YearZoneSave, txtDate13.DateValue), "yyyy/MM/dd") + "'"
                        sqltmp = sqltmp + ",doc_title='" + TxtTitle3.Text + "'"
                        sqltmp = sqltmp + ",doc_titleCommand='" + Replace(txtTitleCommand3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_detail='" + Replace(ctlDetail3.Text, "'", "''") + "'"
                        sqltmp = sqltmp + ",doc_officesign='" + Replace(txtOfficerSign3.Text, "'", "''") + "'"
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

    'Private Sub SetOfficeSignID()
    '    Dim dt As DataTable

    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.organization_id in (select organization_id from OFFICER where username = '" + Config.GetLogOnUser.UserName + "')"

    '    'dt = GetDataToList(sqltmp)
    '    'cmbOfficeSignID1.SetItemList(dt, "full_name", "username")
    '    'dt = GetDataToList(sqltmp)
    '    'cmbOfficeSignID2.SetItemList(dt, "full_name", "username")
    '    'dt = GetDataToList(sqltmp)
    '    'cmbOfficeSignID3.SetItemList(dt, "full_name", "username")

    '    'cmbOfficeSignID1.SelectedValue = Config.GetLogOnUser.UserName
    '    'cmbOfficeSignID2.SelectedValue = Config.GetLogOnUser.UserName
    '    'cmbOfficeSignID3.SelectedValue = Config.GetLogOnUser.UserName
    'End Sub

    'Private Sub OfficeDescription()
    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.username = '" + Config.GetLogOnUser.UserName + "'"

    '    txtPositionSign1.Text = getdatafld(sqltmp, "description")
    '    txtPositionSign2.Text = getdatafld(sqltmp, "description")
    '    txtPositionSign3.Text = getdatafld(sqltmp, "description")
    'End Sub


    'Protected Sub cmbOfficeSignID1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID1.SelectedIndexChanged
    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID1.SelectedValue + "'"

    '    txtPositionSign1.Text = getdatafld(sqltmp, "description")
    'End Sub

    'Protected Sub cmbOfficeSignID2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID2.SelectedIndexChanged
    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID2.SelectedValue + "'"

    '    txtPositionSign2.Text = getdatafld(sqltmp, "description")
    'End Sub

    'Protected Sub cmbOfficeSignID3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOfficeSignID3.SelectedIndexChanged
    '    sqltmp = "Select o.username ,o.officer_code,o.first_name_thai + '  ' + o.last_name_thai as full_name,o.description "
    '    sqltmp = sqltmp & "FROM OFFICER o inner join ORGANIZATION g on o.organization_id = g.id "
    '    sqltmp = sqltmp & "WHERE o.username = '" + cmbOfficeSignID3.SelectedValue + "'"

    '    txtPositionSign3.Text = getdatafld(sqltmp, "description")
    'End Sub
End Class
