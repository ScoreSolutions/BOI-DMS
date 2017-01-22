Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient

Partial Class WebApp_frmMasterOfficer
    Inherits System.Web.UI.Page

    Private Sub organization()
        Dim dt As DataTable
        dt = GetDataToList("select * from ORGANIZATION order by id")
        organization_id.SetItemList(dt, "org_name", "id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            organization()
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            'Dim id As String = "0"
            'If txtID.Text.Trim = "0" Then
            '    id = getdatafld("select CASE WHEN MAX(id) IS NULL THEN 1 ELSE MAX(id) + 1 END as maxid from OFFICER", "maxid")

            '    sqltmp = "insert into OFFICER ("
            '    sqltmp = sqltmp + " id"
            '    sqltmp = sqltmp + ",username"
            '    sqltmp = sqltmp + ",pwd"
            '    sqltmp = sqltmp + ",officer_code"
            '    sqltmp = sqltmp + ",first_name"
            '    sqltmp = sqltmp + ",last_name"
            '    sqltmp = sqltmp + ",first_name_thai"
            '    sqltmp = sqltmp + ",last_name_thai"
            '    sqltmp = sqltmp + ",first_name_eng"
            '    sqltmp = sqltmp + ",last_name_eng"
            '    sqltmp = sqltmp + ",description"
            '    sqltmp = sqltmp + ",organization_id"
            '    sqltmp = sqltmp + ",gender"
            '    sqltmp = sqltmp + ",birth_date"
            '    sqltmp = sqltmp + ",efdate"
            '    sqltmp = sqltmp + ",epdate"
            '    sqltmp = sqltmp + ",officer_level"
            '    sqltmp = sqltmp + ",identity_card"
            '    sqltmp = sqltmp + ",tel"
            '    sqltmp = sqltmp + ",Fax"
            '    sqltmp = sqltmp + ",email"
            '    sqltmp = sqltmp + ",update_by"
            '    sqltmp = sqltmp + ",update_on"
            '    sqltmp = sqltmp + ",create_by"
            '    sqltmp = sqltmp + ",create_on"
            '    sqltmp = sqltmp + ") values ("
            '    sqltmp = sqltmp + "'" & id & "' "
            '    sqltmp = sqltmp + ",'" + username.Text + "'"
            '    sqltmp = sqltmp + ",'BOI'"
            '    sqltmp = sqltmp + ",'" + officer_code.Text + "'"
            '    sqltmp = sqltmp + ",'" + first_name.Text + "'"
            '    sqltmp = sqltmp + ",'" + last_name.Text + "'"
            '    sqltmp = sqltmp + ",'" + first_name_thai.Text + "'"
            '    sqltmp = sqltmp + ",'" + last_name_thai.Text + "'"
            '    sqltmp = sqltmp + ",'" + first_name_eng.Text + "'"
            '    sqltmp = sqltmp + ",'" + last_name_eng.Text + "'"
            '    sqltmp = sqltmp + ",'" + description.Text + "'"
            '    sqltmp = sqltmp + ",'" + organization_id.SelectedValue + "'"
            '    sqltmp = sqltmp + ",'" + gender.SelectedValue + "'"
            '    sqltmp = sqltmp + "," + IIf(birth_date.DateValue = Nothing, "null", "'" + birth_date.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + "," + IIf(efdate.DateValue = Nothing, "null", "'" + efdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + "," + IIf(epdate.DateValue = Nothing, "null", "'" + epdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + ",'" + officer_level.Text + "'"
            '    sqltmp = sqltmp + ",'" + identity_card.Text + "'"
            '    sqltmp = sqltmp + ",'" + tel.Text + "'"
            '    sqltmp = sqltmp + ",'" + fax.Text + "'"
            '    sqltmp = sqltmp + ",'" + email.Text + "'"
            '    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
            '    sqltmp = sqltmp + ",getdate()"
            '    sqltmp = sqltmp + ",'" + Config.GetLogOnUser.UserName + "'"
            '    sqltmp = sqltmp + ",getdate())"
            'Else
            '    id = txtID.Text
            '    sqltmp = "update OFFICER set "
            '    sqltmp = sqltmp + " username = '" + username.Text + "'"
            '    sqltmp = sqltmp + ",officer_code = '" + officer_code.Text + "'"
            '    sqltmp = sqltmp + ",first_name = '" + first_name.Text + "'"
            '    sqltmp = sqltmp + ",last_name = '" + last_name.Text + "'"
            '    sqltmp = sqltmp + ",first_name_thai = '" + first_name_thai.Text + "'"
            '    sqltmp = sqltmp + ",last_name_thai = '" + last_name_thai.Text + "'"
            '    sqltmp = sqltmp + ",first_name_eng = '" + first_name_eng.Text + "'"
            '    sqltmp = sqltmp + ",last_name_eng = '" + last_name_eng.Text + "'"
            '    sqltmp = sqltmp + ",description = '" + description.Text + "'"
            '    sqltmp = sqltmp + ",organization_id = '" + organization_id.SelectedValue + "'"
            '    sqltmp = sqltmp + ",gender = '" + gender.SelectedValue + "'"
            '    sqltmp = sqltmp + ",birth_date = " + IIf(birth_date.DateValue = Nothing, "null", "'" + birth_date.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + ",efdate = " + IIf(efdate.DateValue = Nothing, "null", "'" + efdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + ",epdate = " + IIf(epdate.DateValue = Nothing, "null", "'" + epdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            '    sqltmp = sqltmp + ",officer_level = '" + officer_level.Text + "'"
            '    sqltmp = sqltmp + ",identity_card = '" + identity_card.Text + "'"
            '    sqltmp = sqltmp + ",tel = '" + tel.Text + "'"
            '    sqltmp = sqltmp + ",Fax = '" + fax.Text + "'"
            '    sqltmp = sqltmp + ",email = '" + email.Text + "'"
            '    sqltmp = sqltmp + ",update_by = '" + Config.GetLogOnUser.UserName + "'"
            '    sqltmp = sqltmp + ",update_on= getdate()"
            '    sqltmp = sqltmp + " where id = '" & id & "'"
            'End If

            Dim _BirthDate As String = IIf(birth_date.DateValue = Nothing, "null", "'" + birth_date.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            Dim _EfDate As String = IIf(efdate.DateValue = Nothing, "null", "'" + efdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")
            Dim _EpDate As String = IIf(epdate.DateValue = Nothing, "null", "'" + epdate.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'")

            Dim eng As New Engine.Master.OfficerEng
            Dim msg() As String = Split(eng.SaveOfficerData(txtID.Text, username.Text, officer_code.Text, identity_card.Text, first_name.Text, last_name.Text, first_name_eng.Text, last_name_eng.Text, gender.SelectedValue, organization_id.SelectedValue, officer_code.Text, tel.Text, fax.Text, _BirthDate, email.Text, description.Text, _EfDate, _EpDate, Config.GetLogOnUser.UserName), "|")
            If msg.Length = 2 Then
                If msg(0) = "true" Then
                    txtID.Text = msg(1)
                    SetGridview(True)
                    ClearData()
                    sys_msg.Text = "บันทึกข้อมูลเรียบร้อย"
                Else
                    sys_msg.Text = msg(0)
                End If
            End If
        End If

        popup2.Show()
    End Sub

    Public Function ValidateData() As Boolean
        Dim ret = True
        If username.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรหัส", Me, username.ClientID)
        ElseIf first_name.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอชื่อเจ้าหน้าที่", Me, first_name.ClientID)
        ElseIf last_name.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกนามสกุลเจ้าหน้าที่", Me, last_name.ClientID)
        End If
        Return ret
    End Function

    Private Sub GetData(ByVal ID As Long)
        condb()

        Dim Da As New SqlDataAdapter
        Dim Ds As New DataSet

        conn = New SqlConnection(cnstr)
        Ds.Tables.Clear()

        sqltmp = "select * from OFFICER where id = " + ID.ToString

        Da = New SqlDataAdapter(sqltmp, conn)
        Da.Fill(Ds, "DATA")

        If (Ds.Tables("DATA").Rows.Count > 0) Then
            txtID.Text = Ds.Tables("DATA").Rows(0).Item("ID").ToString

            username.Text = Ds.Tables("DATA").Rows(0).Item("username").ToString
            officer_code.Text = Ds.Tables("DATA").Rows(0).Item("officer_code").ToString
            first_name.Text = Ds.Tables("DATA").Rows(0).Item("first_name").ToString
            last_name.Text = Ds.Tables("DATA").Rows(0).Item("last_name").ToString
            first_name_thai.Text = Ds.Tables("DATA").Rows(0).Item("first_name_thai").ToString
            last_name_thai.Text = Ds.Tables("DATA").Rows(0).Item("last_name_thai").ToString
            first_name_eng.Text = Ds.Tables("DATA").Rows(0).Item("first_name_eng").ToString
            last_name_eng.Text = Ds.Tables("DATA").Rows(0).Item("last_name_eng").ToString
            description.Text = Ds.Tables("DATA").Rows(0).Item("description").ToString
            organization_id.SelectedValue = Ds.Tables("DATA").Rows(0).Item("organization_id").ToString
            gender.SelectedValue = Ds.Tables("DATA").Rows(0).Item("gender").ToString

            If Not IsDBNull(Ds.Tables("DATA").Rows(0).Item("birth_date")) Then
                birth_date.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("birth_date")))
            End If
            If Not IsDBNull(Ds.Tables("DATA").Rows(0).Item("efdate")) Then
                efdate.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("efdate")))
            End If

            If Not IsDBNull(Ds.Tables("DATA").Rows(0).Item("epdate")) Then
                epdate.DateValue = DateAdd(DateInterval.Year, YearZone, CDate(Ds.Tables("DATA").Rows(0).Item("epdate")))
            End If

            officer_level.Text = Ds.Tables("DATA").Rows(0).Item("officer_level").ToString
            identity_card.Text = Ds.Tables("DATA").Rows(0).Item("identity_card").ToString
            tel.Text = Ds.Tables("DATA").Rows(0).Item("tel").ToString
            fax.Text = Ds.Tables("DATA").Rows(0).Item("fax").ToString
            email.Text = Ds.Tables("DATA").Rows(0).Item("email").ToString
        End If
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable
        If IsClickSearch = True Then
            sqltmp = "select o.id, o.first_name + ' ' + o.last_name staff_name, og.org_name,o.email "
            sqltmp &= " from OFFICER o "
            sqltmp &= " inner join ORGANIZATION og on og.id=o.organization_id"
            sqltmp &= " where username like '%" + txtSearch.Text.Trim() + "%' "
            sqltmp &= " or officer_code like '%" + txtSearch.Text + "%'"
            sqltmp &= " or first_name like '%" + txtSearch.Text + "%'"
            sqltmp &= " or last_name like '%" + txtSearch.Text + "%'"
            sqltmp &= " or identity_card like '%" + txtSearch.Text + "%'"
            sqltmp &= " or org_name like '%" + txtSearch.Text + "%'"
            dt = GetDataToList(sqltmp)
            Session("SearchResult") = dt
        Else
            'sqltmp = "select * from DOC_POSCRIPT order by id"
            'dt = GetDataToList(sqltmp)
            dt = Session("SearchResult")
        End If

        GridView1.PageSize = 20
        pcTop.SetMainGridView(GridView1)
        GridView1.DataSource = dt
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub
    Private Sub ClearData()
        txtID.Text = "0"
        username.Text = ""
        officer_code.Text = ""
        first_name.Text = ""
        last_name.Text = ""
        first_name_thai.Text = ""
        last_name_thai.Text = ""
        first_name_eng.Text = ""
        last_name_eng.Text = ""
        description.Text = ""
        gender.SelectedValue = "1"
        birth_date.DateValue = Nothing
        efdate.DateValue = Nothing
        epdate.DateValue = Nothing
        officer_level.Text = ""
        identity_card.Text = ""
        tel.Text = ""
        fax.Text = ""
        email.Text = ""
        organization_id.SelectedValue = "0"
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression = "DEFAULT" Then
            txtSortDir.Text = ""
            txtSortField.Text = ""
        Else
            If txtSortField.Text = e.SortExpression Then
                txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
            Else
                txtSortField.Text = e.SortExpression
            End If
        End If

        SetGridview(False)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim lbl As Label = row.FindControl("lblid")

        sqltmp = "DELETE FROM OFFICER WHERE id=" + lbl.Text

        popup1.Show()
    End Sub

    Protected Sub btnYes1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes1.Click
        sql_data(sqltmp)
        SetGridview(True)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim row As GridViewRow = GridView1.Rows(e.NewEditIndex)
        Dim lbl As Label = row.FindControl("lblid")

        GetData(lbl.Text)
    End Sub
End Class
