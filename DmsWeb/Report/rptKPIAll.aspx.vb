
Partial Class Report_rptKPIAll
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtDate1.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่เริ่มต้น", Me, txtDate1.ClientID)
            Exit Sub
        End If
        If txtDate2.DateValue.Year = 1 Then
            Config.SetAlert("กรุณาระบุวันที่", Me, txtDate2.ClientID)
            Exit Sub
        End If
        If DateDiff(DateInterval.Day, txtDate1.DateValue, txtDate2.DateValue) < 0 Then
            Config.SetAlert("กรุณาระบุวันที่สิ้นสุดมากกว่าวันที่เริ่มต้น", Me, txtDate2.ClientID)
            Exit Sub
        End If
        'Session("formdt") = txtDate1.DateValue
        'Session("todt") = txtDate2.DateValue

        ''Response.Redirect("../rptGrid/rptkpibyorg.aspx")
        Dim wh As String = "DateFrom=" & txtDate1.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        wh += "&DateTo=" & txtDate2.DateValue.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
        Config.PreviewReports("../rptGrid/rptkpibyorg.aspx?" & wh & "&rnd=" & DateTime.Now.Millisecond, Me)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtDate1.DateValue = New Date(1, 1, 1)
        txtDate2.DateValue = New Date(1, 1, 1)
    End Sub
End Class
