Imports System.Data
Imports Para.Common.Utilities

Partial Class WebApp_frmSearchBookByCompanyName
    Inherits System.Web.UI.Page


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If hdnCustValue.Text.Trim = "" Then
            Config.SetAlert("กรุณาระบุชื่อองค์กร / บริษัท", Me, txtComName.ClientID)
            Exit Sub
        End If
        If txtRegisDateFrom.DateValue.Year <> 1 And txtRegisDateTo.DateValue.Year <> 1 Then
            If txtRegisDateFrom.DateValue > txtRegisDateTo.DateValue Then
                Config.SetAlert("กรุณาเลือกวันที่เริ่มต้น น้อยกว่าวันที่สิ้นสุด", Me)
                Exit Sub
            End If
        End If

        'Dim ComName As String = ""
        'If txtComName.Text.Trim.IndexOf("(" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")") > 0 Then
        '    ComName = txtComName.Text.Replace("(" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")", "")
        'ElseIf txtComName.Text.Trim.IndexOf("(" & Para.Common.Utilities.Constant.CompanySourceType.BOICENTRAL & ")") > 0 Then
        '    ComName = txtComName.Text.Replace("(" & Para.Common.Utilities.Constant.CompanySourceType.BOICENTRAL & ")", "")
        'Else
        '    ComName = txtComName.Text.Trim
        'End If
        'Dim wh As String = " and REPLACE(dr.company_name,' ','') like '" & ComName.Trim.Replace(" ", "") & "%' "
        'Dim ImpText As String = " and REPLACE(dr.company_name,' ','') like '" & ComName.Trim.Replace(" ", "") & "%' "


        Dim wh As String = ""
        Dim ImpText As String = ""

        Dim ComName As String = txtComName.Text.Trim
        If txtComName.Text.Trim.IndexOf("(" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")") > 0 Then
            ComName = txtComName.Text.Replace("(" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")", "")
            wh = " and ltrim(rtrim(dr.company_name))='" & ComName.Trim & "'"
            ImpText = " and ltrim(rtrim(dr.company_name))='" & ComName.Trim & "'"
        ElseIf txtComName.Text.Trim.IndexOf("(" & Para.Common.Utilities.Constant.CompanySourceType.BOICENTRAL & ")") > 0 Then
            ComName = txtComName.Text.Replace("(" & Para.Common.Utilities.Constant.CompanySourceType.BOICENTRAL & ")", "")
            wh = " and ltrim(rtrim(dr.company_name))='" & ComName.Trim & "'"
            ImpText = " and ltrim(rtrim(dr.company_name))='" & ComName.Trim & "'"
        Else
            wh = " and dr.company_name='" & ComName.Trim & "'"
            ImpText = " and ltrim(rtrim(dr.company_name))='" & ComName.Trim & "'"
        End If

        Dim whLog As String = "ชื่อองค์กร :" & ComName
        If txtRegisDateFrom.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegisDateFrom.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegisDateFrom.GetDateCondition & "'"
            whLog += " วันที่เริ่มต้น: " & txtRegisDateFrom.GetDateCondition
        End If
        If txtRegisDateTo.DateValue.Year <> 1 Then
            wh += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
            ImpText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegisDateTo.GetDateCondition & "'"
            whLog += " วันที่สิ้นสุด: " & txtRegisDateTo.GetDateCondition
        End If

        Config.SaveTransLog("ค้นหาจากชื่อองค์กร : " & whLog)
        Dim cki As New HttpCookie(Constant.SessSearchCondition, wh & "###" & ImpText)
        Response.Cookies.Add(cki)
        Config.PreviewReports("../WebApp/frmResultSearchByCompanyName.aspx?rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtComName.Text = ""
        txtRegisDateFrom.DateValue = New Date(1, 1, 1)
        txtRegisDateTo.DateValue = New Date(1, 1, 1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session.Remove(Constant.SessSearchCondition)
            Me.Form.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
End Class
