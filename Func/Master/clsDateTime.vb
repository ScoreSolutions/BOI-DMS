Imports System.Collections.Generic
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Diagnostics
Imports System.Web
Imports System.Web.UI.WebControls


Public Class clsFormateDateTime

    Public Sub New()
    End Sub

    Public Function GetMonth_Year(ByVal y As String, ByVal m As String) As Integer
        If m = "" Then
            m = GetCurrentMonth()
        End If
        Dim full As String = y & m
        Return Convert.ToInt32(full)

    End Function

    Public Function DateTimeDB_current() As String

        Return DateTime.Now.ToString("MM/dd/yyyy", New CultureInfo("en-US"))

    End Function
    Public Function GetCurrentYear() As String
        Dim y As Integer = DateTime.Now.Year
        If y > 2500 Then
            Dim tem As Integer = y - 543

            Return tem.ToString()
        Else
            Return y.ToString()
        End If

    End Function

    Public Function GetYear(ByVal objYear As DateTime) As String
        Dim y As Integer = objYear.Year
        If y < 2500 Then
            Dim tem As Integer = y + 543

            Return tem.ToString()
        Else
            Return y.ToString()
        End If

    End Function

    Public Function GetCurrentMonth() As String
        Dim m As Integer = DateTime.Now.Month
        If m <= 9 Then

            Return "0" & m.ToString()
        Else
            Return m.ToString()
        End If

    End Function

    Public Function DateDisplay(ByVal dataD As Object) As String

        If dataD IsNot Nothing AndAlso dataD.[GetType]().Name = "DateTime" Then


            Dim d_ As DateTime = Convert.ToDateTime(dataD)
            Dim y As Integer = d_.Year

            Dim strM As String = ""
            Dim strD As String = ""
            If d_.Month <= 9 Then
                strM = "0" & d_.Month.ToString()
            Else
                strM = d_.Month.ToString()
            End If

            If d_.Day <= 9 Then
                strD = "0" & d_.Day.ToString()
            Else
                strD = d_.Day.ToString()
            End If



            If y > 2500 Then
                y = y - 543
            End If





            ' return Convert.ToDateTime(dataD).ToString("dd/MM/yyyy", new CultureInfo("th-TH"));

            Return strD & "/" & strM & "/" & y.ToString()
        Else
            Return "N/A"
        End If


    End Function

    Public Function DateTimeDisplay(ByVal dataD As Object) As String

        If dataD IsNot Nothing AndAlso dataD.[GetType]().Name = "DateTime" Then


            Return Convert.ToDateTime(dataD).ToString("dd/MM/yyyy HH:mm:ss", New CultureInfo("en-US"))
        Else
            Return ""
        End If


    End Function

    Public Function dateDisplyThaiInDB(ByVal dataD As Object) As String

        If dataD IsNot Nothing AndAlso dataD.[GetType]().Name = "DateTime" Then

            Dim d_ As DateTime = Convert.ToDateTime(dataD)
            Dim y As Integer = d_.Year
            Dim m As Integer = d_.Month
            Dim d As Integer = d_.Day

            If y < 2500 Then
                y = y + 543
            End If
            '  return Convert.ToDateTime(dataD).ToString("dd/MM/yyyy");

            Return m.ToString() & "/" & d.ToString() & "/" & y.ToString()
        Else
            Return "N/A"
        End If


    End Function

    Public Function isDate(ByVal dataD As Object) As Boolean

        Try
            Dim value As Object = DateDB(dataD)
            If value IsNot DBNull.Value Then
                Return True
            Else

                Return False

            End If
        Catch ex As Exception
            'objLog.writeLog_2(ex, base.ToString(), new StackFrame().GetMethod().ToString());

            Return False
        End Try


    End Function

    Public Function DateDisplay_News(ByVal dataD As Object) As String
        Try

            If dataD IsNot Nothing AndAlso dataD.[GetType]().Name = "DateTime" Then

                'string month = Convert.ToDateTime(dataD).Month();
                ' string[] arrary = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม"};
                Dim arrary As String() = {"January", "February", "March", "April", "May", "June", _
                 "July", "August", "September", "October", "November", "December"}

                Dim strAll As String = Convert.ToDateTime(dataD).ToString("dd/MM/yyyy")
                Dim strMonth As String() = strAll.Split("/"c)
                Dim indexMonth As Integer
                indexMonth = Convert.ToInt16(strMonth(1))

                If strMonth(2) <> "" AndAlso Convert.ToInt32(strMonth(2)) < 2500 Then

                    Dim temp As Integer = Convert.ToInt32(strMonth(2)) + 543


                    strMonth(2) = temp.ToString()
                End If


                Return strMonth(0).ToString() & " " & arrary(indexMonth - 1) & " พ.ศ." & strMonth(2).ToString()
            Else
                Return "N/A"
            End If
        Catch ex As Exception


            Throw ex
            Return "N/A"
        End Try

    End Function

    Public Function DateDB_DatePicter(ByVal dataD As Object) As Object

        Try

            If dataD IsNot Nothing AndAlso dataD.ToString() <> "" Then

                Dim dateString As String = dataD.ToString()
                Dim cultureName As String = System.Globalization.CultureInfo.CurrentCulture.ToString()
                Dim format As System.IFormatProvider = New System.Globalization.CultureInfo(cultureName)
                Dim dateString_ As String = ""
                If cultureName.Trim() = "en-US" Then
                    Dim arr As String() = dateString.Split("/"c)
                    If arr(1).Trim().Length <= 1 Then
                        arr(1) = "0" & arr(1)
                    End If
                    If arr(0).Trim().Length <= 1 Then
                        arr(0) = "0" & arr(0)
                    End If

                    dateString_ = arr(1) & "/" & arr(0) & "/" & arr(2)
                ElseIf cultureName.Trim() = "th-TH" Then
                    Dim arr As String() = dateString.Split("/"c)
                    Dim newYear As Integer = Convert.ToInt32(arr(2))
                    If newYear < 2200 Then
                        newYear += 543
                    End If

                    If arr(1).Trim().Length <= 1 Then
                        arr(1) = "0" & arr(1)
                    End If
                    If arr(0).Trim().Length <= 1 Then
                        arr(0) = "0" & arr(0)
                    End If


                    dateString_ = arr(1) & "/" & arr(0) & "/" & newYear.ToString()
                End If
                Dim newdate As DateTime = DateTime.Parse(dateString_, New System.Globalization.CultureInfo("en-US"))

                Return newdate
            Else
                Return DBNull.Value

            End If
        Catch ex As Exception
            Throw ex

            Return DBNull.Value
        End Try

    End Function


    Public Function DateDB(ByVal dataD As Object) As Object

        Try

            If dataD IsNot Nothing AndAlso dataD.ToString() <> "" Then

                Dim dateString As String = dataD.ToString()
                Dim cultureName As String = System.Globalization.CultureInfo.CurrentCulture.ToString()
                Dim format As System.IFormatProvider = New System.Globalization.CultureInfo(cultureName)
                Dim dateString_ As String = ""
                If cultureName.Trim() = "en-US" Then
                    Dim arr As String() = dateString.Split("/"c)

                    dateString_ = arr(1) & "/" & arr(0) & "/" & arr(2)
                ElseIf cultureName.Trim() = "th-TH" Then
                    Dim arr As String() = dateString.Split("/"c)
                    Dim newYear As Integer = Convert.ToInt32(arr(2))
                    If newYear < 2200 Then
                        newYear += 543
                    End If

                    dateString_ = arr(1) & "/" & arr(0) & "/" & newYear.ToString()
                End If
                Dim newdate As DateTime = DateTime.Parse(dateString_, New System.Globalization.CultureInfo("en-US"))

                Return newdate
            Else
                Return DBNull.Value

            End If
        Catch ex As Exception
            Throw ex

            Return DBNull.Value
        End Try

    End Function

    Public Function GetMonthName(ByVal indexMonth As Integer) As String
        Try

            Dim arrary As String() = {"January", "February", "March", "April", "May", "June", _
             "July", "August", "September", "October", "November", "December"}

            If indexMonth >= 1 Then
                Return arrary(indexMonth - 1).ToString()
            Else

                Return ""
            End If
        Catch ex As Exception

            Return ""
        End Try

    End Function

    Public Sub GenYearToList(ByRef ddlYear As DropDownList)
        ddlYear.Items.Clear()
        '============ gen year =========
        Dim year As Integer = DateTime.Now.Year
        Dim year_back As Integer = year - 15
        Dim year_forward As Integer = year + 5

        For i As Integer = year_back To year_forward
            ddlYear.Items.Add(New ListItem(i.ToString(), i.ToString()))
        Next

        ddlYear.SelectedValue = year.ToString()

    End Sub

    Public Sub GenMonthToList(ByRef ddlMonth As DropDownList)
        ddlMonth.Items.Clear()
        Dim arrary As String() = {"January", "February", "March", "April", "May", "June", _
         "July", "August", "September", "October", "November", "December"}

        '============ gen month =========
        Dim month As Integer = DateTime.Now.Month


        For i As Integer = 0 To 11
            Dim valueMonth As Integer = i + 1

            ddlMonth.Items.Add(New ListItem(arrary(i), valueMonth.ToString()))
        Next

        ddlMonth.SelectedValue = month.ToString()

    End Sub

    Public Function SetMoneyFormat(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" AndAlso objValue.ToString() <> "0" Then
            ' return String.Format("{0:0,0}", objValue);
            ' return String.Format("#,###.00", objValue);
            Return [String].Format("{0:#,#.##}", objValue)
        Else
            Return "0"
        End If
    End Function

    Public Function SetNumberFormatNoneDot(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" AndAlso Convert.ToDouble(objValue) <> 0 Then

            Return [String].Format(New CultureInfo("th-TH"), "{0:#,#}", objValue)
        Else
            Return "0"
        End If
    End Function
End Class
