Imports System.Data
Imports Engine.Master
Imports Engine.Common
Imports Para.TABLE

Partial Class WebApp_frmMasterHoliday
    Inherits System.Web.UI.Page
    Private Sub GetYear()
        For y As Integer = 2545 To Date.Today.ToString("yyyy") + 5
            DDyear.SetItemList(y, y)
        Next
        DDyear.SelectedValue = DateTime.Now.ToString("yyyy")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            GetYear()
            If Request("date") IsNot Nothing Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                txtHoliday.TxtBox.Text = Request("date")
                Dim fnc As New HolidayEng
                Dim para As HolidayPara = fnc.GetHoliday(txtHoliday.DateValue, trans)
                txtID.Text = para.ID
                txtDescription.Text = para.DESCRIPTION
                trans.CommitTransaction()
                DDyear.SelectedValue = Right(Request("date").ToString, 4)
            End If
            SetCalendar(DDyear.SelectedValue)
        End If
    End Sub

    Private Sub SetCalendar(ByVal thYear As Integer)
        '  Generates report for current year
        lnkCalendar.Text = "<table width='600px'>"

        Dim horizontalRepeat As Integer = 3     '   number of months in horizontal direction
        Dim month As Integer

        For month = 1 To 12
            If (month Mod horizontalRepeat = 1) Then
                lnkCalendar.Text += "<tr valign='top'>"
            End If
            lnkCalendar.Text += "<td>" + generateCalendar(month, thYear - 543) + "</td>"
            If (month Mod horizontalRepeat = 0) Then
                lnkCalendar.Text += "</tr>"
            End If
        Next

        lnkCalendar.Text += "</table>"
    End Sub

    Private Function generateCalendar(ByVal month As Integer, ByVal year As Integer) As String
        '  generates the calendar as per the booking status
        Dim wholeCalendar(5, 6) As Integer
        Dim weeks As Integer = 0
        Dim day As String = ""
        Dim tmpDate As DateTime
        Dim myDate As Integer
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        For myDate = 1 To 31
            Try
                tmpDate = New DateTime(year, month, myDate)
                If (day = "Saturday") Then
                    weeks += 1
                End If
                day = tmpDate.DayOfWeek.ToString()

                If (day = "Sunday") Then
                    'If (wholeCalendar(weeks, 0) > 0) Then weeks += 1
                    wholeCalendar(weeks, 0) = myDate
                ElseIf (day = "Monday") Then
                    'If (wholeCalendar(weeks, 1) > 0) Then weeks += 1
                    wholeCalendar(weeks, 1) = myDate
                ElseIf (day = "Tuesday") Then
                    'If (wholeCalendar(weeks, 2) > 0) Then weeks += 1
                    wholeCalendar(weeks, 2) = myDate
                ElseIf (day = "Wednesday") Then
                    'If (wholeCalendar(weeks, 3) > 0) Then weeks += 1
                    wholeCalendar(weeks, 3) = myDate
                ElseIf (day = "Thursday") Then
                    'If (wholeCalendar(weeks, 4) > 0) Then weeks += 1
                    wholeCalendar(weeks, 4) = myDate
                ElseIf (day = "Friday") Then
                    'If (wholeCalendar(weeks, 5) > 0) Then weeks += 1
                    wholeCalendar(weeks, 5) = myDate
                ElseIf (day = "Saturday") Then
                    'If (wholeCalendar(weeks, 6) > 0) Then weeks += 1
                    wholeCalendar(weeks, 6) = myDate
                End If
            Catch ex As Exception
                Exit For
            End Try


        Next

        '   Generates the HTML calendar
        Dim htmlCalendar As String = ""
        Dim objEventsDAO As New HolidayEng
        Dim dt As DataTable
        Dim i As Integer, j As Integer
        htmlCalendar += "<table class='calendarFrame' cellspacing=0>"
        htmlCalendar += "<tr class='calendarMonthYear' style='text-align: center;'><td colspan='7'>" + getMonthName(month) + " " + (year + 543).ToString() + "</td></tr>"
        htmlCalendar += "<tr class='calendarDay' style='text-align: center;'> <td>อา</td>  <td>จ</td>  <td>อ</td>  <td>พ</td>  <td>พฤ</td>  <td>ศ</td>  <td>ส</td> </tr>"

        For i = 0 To 5
            htmlCalendar += "<tr>"
            For j = 0 To 6
                If wholeCalendar(i, j) > 0 Then
                    Dim toolTip As String = ""
                    Dim cssClass As String = ""
                    Dim pamDate As Date = New DateTime(year, month, wholeCalendar(i, j))
                    dt = objEventsDAO.GetHoliday(wholeCalendar(i, j), month, year, trans)
                    If (dt.Rows.Count > 0) Then
                        toolTip = dt.Rows(0)("description").ToString()
                        Dim mDay As String = pamDate.DayOfWeek.ToString
                        If mDay = "Sunday" Or mDay = "Saturday" Then
                            If toolTip = "วันเสาร์" Or toolTip = "วันอาทิตย์" Then
                                'htmlCalendar += "<td class='WeekEnd' title=""" + toolTip + """>" + wholeCalendar(i, j).ToString() + "</td>"
                                cssClass = "WeekEnd"
                            Else
                                'htmlCalendar += "<td class='hasEvent' title=""" + toolTip + """>" + wholeCalendar(i, j).ToString() + "</td>"
                                cssClass = "hasEvent"
                            End If
                        Else
                            'htmlCalendar += "<td class='hasEvent' title=""" + toolTip + """>" + wholeCalendar(i, j).ToString() + "</td>"
                            cssClass = "hasEvent"
                        End If

                    Else
                        'htmlCalendar += ""
                        cssClass = "hasNoEvent"
                    End If
                    htmlCalendar += "<td class='" & cssClass & "' title='" & toolTip & "' ><a href='frmMasterHoliday.aspx?date=" & pamDate.ToString("dd/MM/yyyy") & "&rnd=" & DateTime.Now.Millisecond & "' >" + wholeCalendar(i, j).ToString() + "</a></td>"
                Else
                    htmlCalendar += "<td class='hasNoEvent'>&nbsp;</td>"
                End If
            Next
            htmlCalendar += "</tr>"
        Next
        htmlCalendar += "</table>"
        trans.CommitTransaction()

        '   returns the generated HTML calendar
        Return htmlCalendar

    End Function
    Private Function getMonthName(ByVal month As Integer) As String
        'Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
        Dim months() As String = {"มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"}

        Return months(month - 1)
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New HolidayPara
            para.ID = txtID.Text
            para.HOLIDAY_DATE = txtHoliday.DateValue
            para.DESCRIPTION = txtDescription.Text.Trim

            Dim fnc As New HolidayEng
            If fnc.SaveHoliday(para, Config.GetLogOnUser().UserName, trans) = True Then
                trans.CommitTransaction()
                ClearForm()
                SetCalendar(DDyear.SelectedValue)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(fnc.ErrorMessage, Me)
            End If
        End If
    End Sub

    Private Function ValidateData() As Boolean
        Dim ret As Boolean = True
        If txtHoliday.DateValue.Year = 1 Then
            ret = False
            Config.SetAlert("กรุณาเลือกวันที่", Me, txtHoliday.ClientID)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุความสำคัญ", Me, txtDescription.ClientID)
        End If

        Return ret
    End Function

    Private Sub ClearForm()
        txtID.Text = 0
        txtHoliday.DateValue = New DateTime(1, 1, 1)
        txtDescription.Text = ""
    End Sub

    Protected Sub DDyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDyear.SelectedIndexChanged
        Dim eng As New HolidayEng
        eng.SaveHolidayByYear(DDyear.SelectedValue - 543)
        eng = Nothing

        SetCalendar(DDyear.SelectedValue)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
