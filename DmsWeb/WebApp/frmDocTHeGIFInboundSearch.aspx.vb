Imports System.Data
Imports LinqWS.THeGIF.RequestTHeGIFLinqWS
Partial Class WebApp_frmDocTHeGIFInboundSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Url.Host = "10.0.0.147" Then
            GetNewInbound()
        End If
        If IsPostBack = False Then
            cmbStatus.SetItemList("ทั้งหมด", "0")
            cmbStatus.SetItemList("รอลงทะเบียน", "1")
            cmbStatus.SetItemList("ลงทะเบียนแล้ว", "2")
            cmbStatus.SelectedValue = "1"

            SetGridview(True)
        End If
    End Sub

    Private Sub SaveBase64ToFile(ByVal Base64String As String, ByVal ContentType As String)
        Dim imageBytes As Byte() = Convert.FromBase64String(Base64String)
        Dim fs As New System.IO.FileStream(Engine.Common.FunctionENG.GetFileUploadPath & "TestFile.doc", System.IO.FileMode.CreateNew)
        fs.Write(imageBytes, 0, imageBytes.Length)
        fs.Close()
    End Sub

    Private Sub GetNewInbound()
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        Engine.WebService.THeGIFENG.GetNewInbound(uPara.UserName)
        uPara = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim wh As String = "1=1"
        If txtBookID.Text.Trim <> "" Then
            wh += " and body_id like '%" & txtBookID.Text.Trim & "%'"
        End If
        If txtReqNo.Text.Trim <> "" Then
            wh += " and receive_notify_letterid like '%" & txtReqNo.Text.Trim & "%'"
        End If
        If txtCorrDateFrom.DateValue.Year <> 1 Then
            wh += " and body_correspondence_date>='" & txtCorrDateFrom.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & "'"
        End If
        If txtCorrDateTo.DateValue.Year <> 1 Then
            wh += " and body_correspondence_date<='" & txtCorrDateTo.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & "'"
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),receive_notify_time,112) <= '" & txtRegisDateFrom.GetDateCondition & "'"
        End If
        If txtRegisDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),receive_notify_time,112) >= '" & txtRegisDateTo.GetDateCondition & "'"
        End If
        If txtTitleName.Text.Trim <> "" Then
            wh += " and body_subject like '%" & txtTitleName.Text.Trim & "%'"
        End If
        If txtOrganizationName.Text.Trim <> "" Then
            wh += " and (c.thainame like '" & txtOrganizationName.Text.Trim & "' or c.engname like '" & txtOrganizationName.Text.Trim & "') "
        End If
        If cmbStatus.SelectedValue <> "0" Then
            wh += " and case when isnull(receive_notify_letterid,'') = '' then '1' else '2' end = '" & cmbStatus.SelectedValue & "'"
        End If

        Dim dt As New DataTable
        dt = Engine.WebService.THeGIFENG.SearchTHeGIFDoc(wh)
        If dt.Rows.Count > 0 Then
            pcTop.Visible = True
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        Else
            pcTop.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Register" Then
            Response.Redirect("../WebApp/frmDocRegister.aspx?THeGIFDocID=" & e.CommandArgument & "&rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub
End Class
