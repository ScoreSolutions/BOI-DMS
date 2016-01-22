Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByBookOutNo
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'If txtBookOutNo.Text.Trim = "" Then
        '    Config.SetAlert("กรุณาระบุเลขที่หนังสือส่งออก (อก)", Me, txtBookOutNo.ClientID)
        '    Exit Sub
        'End If
        If txtSendDateFrom.DateValue.Year <> 1 And txtSendDateTo.DateValue.Year <> 1 Then
            If txtSendDateFrom.DateValue > txtSendDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่เริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If
        Dim whLog As String = ""
        Dim wh As String = ""
        Dim ImpText As String = ""

        If txtBookOutNo.Text.Trim <> "" Then
            wh += " and er.bookout_no like '%" & txtBookOutNo.Text.Trim & "%' "
            ImpText += " and dr.book_out_no like '%" & txtBookOutNo.Text.Trim & "%'"
            whLog += "เลขที่หนังสือ อก :" & txtBookOutNo.Text.Trim
        End If
        If txtCompanyName.Text.Trim <> "" Then
            wh += " and er.company_name_receive like '%" & txtCompanyName.Text.Trim & "%' "
            ImpText += " and dr.company_name like '%" & txtCompanyName.Text & "%'"
            whLog += "ชื่อบริษัท : " & txtCompanyName.Text.Trim
        End If

        If txtSendDateFrom.DateValue.Year <> 1 And txtSendDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),er.send_date,112) between '" & txtSendDateFrom.GetDateCondition & "' and '" & txtSendDateTo.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.close_date,112) between '" & txtSendDateFrom.GetDateCondition & "' and '" & txtSendDateTo.GetDateCondition & "'"
            whLog += "วันที่ส่งออกระหว่าง : " & txtSendDateFrom.GetDateCondition & " and " & txtSendDateTo.GetDateCondition
        Else
            If txtSendDateFrom.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),er.send_date,112) >= '" & txtSendDateFrom.GetDateCondition & "'"
                ImpText += " and convert(varchar(8),dr.close_date,112) >= '" & txtSendDateFrom.GetDateCondition & "'"
                whLog += "วันที่ส่งออกเริ่มต้น :" & txtSendDateFrom.GetDateCondition
            End If
            If txtSendDateTo.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),er.send_date,112) <= '" & txtSendDateTo.GetDateCondition & "'"
                ImpText += " and convert(varchar(8),dr.close_date,112) <= '" & txtSendDateTo.GetDateCondition & "'"
                whLog += "วันที่ส่งออกสิ้นสุด :" & txtSendDateTo.GetDateCondition
            End If
        End If

        Config.SaveTransLog("ค้นหาจากเลขที่หนังสือส่งออก (อก) " & whLog)
        Dim cki As New HttpCookie(Constant.SessSearchCondition, wh & "###" & ImpText)
        Response.Cookies.Add(cki)
        Config.PreviewReports("../WebApp/frmResultSearchByBookoutNo.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookOutNo.Text = ""
        txtCompanyName.Text = ""
        txtSendDateFrom.DateValue = New Date(1, 1, 1)
        txtSendDateTo.DateValue = New Date(1, 1, 1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session.Remove(Constant.SessSearchCondition)
            txtBookOutNo.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            txtCompanyName.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            txtSendDateFrom.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            txtSendDateTo.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
