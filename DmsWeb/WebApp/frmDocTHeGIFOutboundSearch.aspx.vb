Imports System.Data
Imports LinqWS.THeGIF.RequestTHeGIFLinqWS
Partial Class WebApp_frmDocTHeGIFOutboundSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            cmbStatus.SetItemList("ทั้งหมด", "0"c)
            cmbStatus.SetItemList("ยังไม่ส่งข้อมูลออนไลน์", "N")
            cmbStatus.SetItemList("ส่งข้อมูลออนไลน์แล้ว", "Y")
            cmbStatus.SelectedValue = "N"


            SetGridview(True)
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub

    Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim s As String = sender.commandargument
        Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim wh As String = " er.is_send_thegif <> '' "
        If txtBookNo.Text.Trim <> "" Then
            wh += " and dr.book_no like '%" & txtBookNo.Text.Trim & "%'"
        End If
        If txtBookoutNo.Text.Trim <> "" Then
            wh += " and dr.bookout_no like '%" & txtBookoutNo.Text.Trim & "%'"
        End If
        If txtSendDateFrom.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),er.send_date,112) >='" & txtSendDateFrom.GetDateCondition & "'"
        End If
        If txtSendDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),er.send_date,112) <='" & txtSendDateTo.GetDateCondition & "'"
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegisDateFrom.GetDateCondition & "'"
        End If
        If txtRegisDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
        End If
        If txtTitleName.Text.Trim <> "" Then
            wh += " and dr.title_name like '%" & txtTitleName.Text.Trim & "%'"
        End If
        If txtCompanyNameReceive.Text.Trim <> "" Then
            wh += " and er.company_name_receive like '%" & txtCompanyNameReceive.Text.Trim & "%' "
        End If
        If cmbStatus.SelectedValue <> "0" Then
            wh += " and er.is_send_thegif = '" & cmbStatus.SelectedValue & "'"
        End If

        Dim dt As New DataTable
        dt = Engine.WebService.THeGIFENG.SearchOutBoundTHeGIFDoc(wh)
        If dt.Rows.Count > 0 Then
            pcTop.Visible = True
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
            dt = Nothing
        Else
            pcTop.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookNo.Text = ""
        txtBookoutNo.Text = ""
        txtSendDateFrom.DateValue = New Date(1, 1, 1)
        txtSendDateTo.DateValue = New Date(1, 1, 1)
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
        txtTitleName.Text = ""
        txtCompanyNameReceive.Text = ""
        cmbStatus.SelectedValue = "0"c
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim imgSendToTHeGif As ImageButton = grv.FindControl("imgSendToTHeGif")
            If imgSendToTHeGif.Visible = True Then
                imgSendToTHeGif.Attributes.Add("onClick", "SendToTHeGif('" & grv.Cells(8).Text & "','" & imgSendToTHeGif.ClientID & "'); return false;")
                imgSendToTHeGif.ToolTip = "ส่งข้อมูลออนไลน์ไปยัง " & grv.Cells(4).Text
            End If
        End If
    End Sub

End Class
