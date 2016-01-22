Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByTitleName
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtTitleName.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุชื่อเรื่อง", Me, txtTitleName.ClientID)
            Exit Sub
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            If txtRegisDateFrom.DateValue > txtRegisDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่เริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If

        Dim wh As String = " and dr.title_name like '%" & txtTitleName.Text.Trim & "%' "
        Dim ImpText As String = " and dr.title_name like '%" & txtTitleName.Text.Trim & "%' "
        Dim whLog As String = "ชื่อเรื่อง :" & txtTitleName.Text.Trim

        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and '" & txtRegisDateTo.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and '" & txtRegisDateTo.GetDateCondition & "'"
            whLog += "ระหว่างวันที่ : " & txtRegisDateFrom.GetDateCondition & " and " & txtRegisDateTo.GetDateCondition
        Else
            If txtRegisDateFrom.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                ImpText += " and convert(varchar(8),dr.register_date,112) between '" & txtRegisDateFrom.GetDateCondition & "' and convert(varchar(8),getdate(),112)"
                whLog += "วันที่เริ่มต้น " & txtRegisDateFrom.GetDateCondition
            End If
            If txtRegisDateTo.DateValue.Year <> 1 Then
                wh += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
                ImpText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
                whLog += "วันที่สิ้นสุด " & txtRegisDateTo.GetDateCondition
            End If
        End If
        
        Config.SaveTransLog("ค้นหาจากชื่อเรื่อง : " & whLog)
        'Session.Remove(Constant.SessSearchCondition)
        'Session(Constant.SessSearchCondition) = wh
        Dim cki As New HttpCookie(Constant.SessSearchCondition, wh & "###" & ImpText)
        Response.Cookies.Add(cki)
        Config.PreviewReports("../WebApp/frmSearchBookByCondition.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtTitleName.Text = ""
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
