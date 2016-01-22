Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByGroupTitle
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cmbGroupTitle.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกกลุ่มเรื่อง", Me)
            Exit Sub
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            If txtRegisDateFrom.DateValue > txtRegisDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่ลงทะเบียนเริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If
        If txtCloseDateFrom.DateValue.Year <> 1 And txtCloseDateTo.DateValue.Year <> 1 Then
            If txtCloseDateFrom.DateValue > txtCloseDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่จบงานเริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If

        Dim tPara As New Para.TABLE.GroupTitlePara
        Dim eng As New Engine.Master.GroupTitleEng
        tPara = eng.GetGroupTitlePara(cmbGroupTitle.SelectedValue)

        Dim wh As String = " and dr.group_title_id = '" & cmbGroupTitle.SelectedValue & "' "
        Dim ImpText As String = " and dr.group_title_code = '" & tPara.GROUP_TITLE_CODE & "'"
        Dim whLog As String = "กลุ่มเรื่อง " & cmbGroupTitle.SelectedItem.Text
        If cmbOrgID.SelectedValue <> "" Then
            wh += " and dr.organization_id_owner = '" & cmbOrgID.SelectedValue & "'"

            Dim oPara As New Para.TABLE.OrganizationPara
            Dim oEng As New Engine.Master.OrganizationEng
            oPara = oEng.GetOrgPara(cmbOrgID.SelectedValue)
            ImpText += " and dr.org_code_owner = '" & oPara.NAME_ABB & "'"
            whLog += "ชื่อหน่วยงาน :" & cmbOrgID.SelectedItem.Text

            oPara = Nothing
            oEng = Nothing
        End If
        If cmbStatus.SelectedValue <> "0" Then
            wh += " and dr.doc_status_id = '" & cmbStatus.SelectedValue & "'"
            ImpText += " and dr.book_status = '" & cmbStatus.SelectedValue & "'"
            whLog += "สถานะ :" & cmbStatus.SelectedText
        End If

        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and '" & txtRegisDateTo.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and '" & txtRegisDateTo.GetDateCondition & "'"
            whLog += "วันที่ลงทะเบียนระหว่าง : " & txtRegisDateFrom.GetDateCondition & " and " & txtRegisDateTo.GetDateCondition
        Else
            If txtRegisDateFrom.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                ImpText += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                whLog += "วันที่ลงทะเบียนเริ่มต้น :" & txtRegisDateFrom.GetDateCondition
            End If
            If txtRegisDateTo.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
                ImpText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
                whLog += "วันที่ลงทะเบียนถึง :" & txtRegisDateTo.GetDateCondition
            End If
        End If

        If txtCloseDateFrom.DateValue.Year <> 1 And txtCloseDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.close_date,112) between '" & txtCloseDateFrom.GetDateCondition & "' and '" & txtCloseDateTo.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.close_date,112) between '" & txtCloseDateFrom.GetDateCondition & "' and '" & txtCloseDateTo.GetDateCondition & "'"
            whLog += "วันที่จบงานระหว่าง :" & txtCloseDateFrom.GetDateCondition & " and " & txtCloseDateTo.GetDateCondition
        Else
            If txtCloseDateFrom.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.close_date,112) between '" & txtCloseDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                ImpText += " and convert(varchar(8),dr.close_date,112) between '" & txtCloseDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                whLog += "วันที่จบงานเริ่มต้น :" & txtCloseDateFrom.GetDateCondition
            End If
            If txtCloseDateTo.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.close_date,112) <= '" & txtCloseDateTo.GetDateCondition & "'"
                ImpText += " and convert(varchar(8),dr.close_date,112) <= '" & txtCloseDateTo.GetDateCondition & "'"
                whLog += "วันที่จบงานถึง :" & txtCloseDateTo.GetDateCondition
            End If
        End If
        
        If chkNoSlash.Checked = True Then
            wh += " and CHARINDEX('/',dr.book_no) = 0 "
            ImpText += " and CHARINDEX('/',dr.book_no) = 0 "
            whLog += "เฉพาะเลขที่ไม่มี /"
        End If

        eng = Nothing
        tPara = Nothing

        Config.SaveTransLog("ค้นหาจากกลุ่มเรื่อง " & whLog)
        'Session.Remove(Constant.SessSearchCondition)
        'Session(Constant.SessSearchCondition) = wh
        Dim cki As New HttpCookie(Constant.SessSearchCondition, wh & "###" & ImpText)
        Response.Cookies.Add(cki)
        Config.PreviewReports("../WebApp/frmSearchBookByCondition.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        SetGroupTitle()
        SetStatus()
        cdlOwnerOrgID.SelectedValue = ""
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
        txtCloseDateFrom.DateValue = New Date(1, 1, 1)
        txtCloseDateTo.DateValue = New Date(1, 1, 1)
    End Sub

    Private Sub SetGroupTitle()
        Dim eng As New Engine.Master.GroupTitleEng
        Dim dt As New DataTable
        dt = eng.GetDataGroupTitleList("active='Y' and ltrim(group_title_name) <>''", "group_title_code")
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("group_title_name") = "เลือก"
            dr("id") = "0"
            dt.Rows.InsertAt(dr, 0)

            cmbGroupTitle.DataTextField = "group_title_name"
            cmbGroupTitle.DataValueField = "id"
            cmbGroupTitle.DataSource = dt
            cmbGroupTitle.DataBind()
            dt.Dispose()
            dt = Nothing
        End If
        eng = Nothing
    End Sub
    Private Sub SetStatus()
        Dim eng As New Engine.Master.DocStatusEng
        Dim dt As DataTable = eng.GetStatusList("1=1")
        cmbStatus.SetItemList(dt, "doc_status_name", "id")
        dt = Nothing
        eng = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            SetGroupTitle()
            SetStatus()

            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
