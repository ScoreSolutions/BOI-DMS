Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Public Class CLASS_LISTITEM

    Private objDB As New clsDB()
    Private formatD As New clsFormateDateTime()
    Public Function SetOrderIcon(ByVal strFieldOrder As String, ByVal strOrder As String, ByVal headerName As String) As String
        Dim strSortIcon As String = ""
        If strFieldOrder <> "" Then
            If strOrder = "desc" Then


                strSortIcon = "<span class='SortZA'>" & headerName & "</span>"
            Else
                'strSortIcon = "iconSortUp.png";

                'strSortIcon = "iconSortDown.png";

                strSortIcon = "<span class='SortAZ'>" & headerName & "</span>"

            End If
        End If
        Return strSortIcon
    End Function

    ' private string[] arrJobLevel = { "ขึ้นตรงหัวหน้าสายงาน", "พนักงาน", "ผู้จัดการฝ่าย", "หัวหน้าสายงาน", "หัวหน้าสายงาน/MD" };

    Public Function SetRowIndex(ByVal index As Integer) As String
        'index++;
        Return index.ToString("#,##0")
    End Function

    Public Function SetDeleteAble(ByVal objID As Object) As String
        Dim strID As String = objID.ToString().Trim()
        Dim strReturn As String = ""

        strReturn = "<input name=""dataID"" type=""checkbox"" value=""" & strID & """  onclick=""Toggle(this, document.frmMain)"">"
        Return strReturn

    End Function

    Public Function SetMoneyFormat(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" AndAlso objValue.ToString() <> "0" Then
            ' return String.Format("{0:0,0}", objValue);
            objValue = Convert.ToDouble(objValue)
            Return [String].Format("{0:#,#.##}", objValue)
        Else
            Return "0"
        End If
    End Function

    Public Function SetMoneyFormat_float(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" AndAlso objValue.ToString() <> "0" Then
            ' return String.Format("{0:0,0}", objValue);
            objValue = Convert.ToDouble(objValue)
            ' return String.Format("{0:0,#.##}", objValue);
            Return [String].Format("{0:F2}", objValue)
        Else
            Return "0"
        End If
    End Function
    Public Function SetMonthName(ByVal intMonth As Object) As String
        If intMonth IsNot Nothing Then
            Return formatD.GetMonthName(Convert.ToInt16(intMonth))
        Else
            Return ""
        End If

    End Function

    Public Function SetStatus(ByVal objStatus As Object) As String
        If objStatus IsNot Nothing Then
            Dim value As Integer = Convert.ToInt32(objStatus)

            If value = 0 Then

                Return "<span class='hi-light'>Inactived</span>"
            ElseIf value = 1 Then
                Return "<span class='Active'>Actived</span>"
            ElseIf value = -1 Then
                Return "<span>ถูกลบ</span>"
            End If


            Return ""
        Else
            Return ""
        End If

    End Function




    Public Function SetAuthenDoc(ByVal objID As Object, ByVal typeDoc As Object, ByVal employeeId As String, ByVal objSubject As Object, ByVal pageGo As String, ByVal authen As Object) As String
        Dim strReturn As String = ""
        Dim nonePer As String = "1"
        '==== public =====

        If typeDoc.ToString() = "Public" Then
        Else
            Dim sql As String = "SELECT INT_DOC_AUTHEN_ID  FROM TBL_DOC_AUTHEN WHERE INT_DOC_ID=" & objID.ToString() & " AND INT_EMPLOYEE_ID=" & employeeId
            If objDB.ExecuteScalar(sql).ToString() = "" Then
                strReturn = "<font color='#0000FF'>!</font>"

                nonePer = "0"
                '==== private =====
            End If
        End If

        Dim strID As String = objID.ToString()
        Dim strSubject As String = objSubject.ToString()

        Dim url As String = pageGo & "?id=" & strID & "&mode=edit"
        If authen IsNot Nothing AndAlso Convert.ToInt32(authen) >= 2 Then
            '  strReturn += "<a href=\"" + url + "\" >" + strSubject + "</a>";

            strReturn += "<a href=""#1"" onclick=callDialogDetail('" & strID & "','" & nonePer & "')>" & strSubject & "</a>"
        Else
            strReturn += strSubject
        End If


        Return strReturn

    End Function


    Public Function SetAdminEditAble_Popup(ByVal objID As Object, ByVal objYear As Object, ByVal pageGo As String, ByVal authen As Object, ByVal height As Object, ByVal width As Object) As String
        Dim strID As String = objID.ToString().Trim()
        Dim strYear As String = objYear.ToString().Trim()
        Dim strReturn As String = ""
        Dim url As String = ""
        If pageGo.IndexOf("?"c) <> -1 Then
            url = pageGo & "&id=" & strID & "&mode=edit"
        Else
            url = pageGo & "?id=" & strID & "&mode=edit"
        End If

        If authen IsNot Nothing AndAlso Convert.ToInt32(authen) >= 3 Then
            strReturn = "<a href='#1' onclick=""return showDialog_scroll('" & url & "','" & Convert.ToString(height) & "','" & Convert.ToString(width) & "');"">" & strYear & "</a>"
        Else
            strReturn = strYear
        End If
        Return strReturn

    End Function

    Public Function SetAdminEditAble(ByVal objID As Object, ByVal objSubject As Object, ByVal pageGo As String, ByVal authen As Object) As String
        Dim strID As String = objID.ToString().Trim()
        Dim strSubject As String = objSubject.ToString().Trim()
        Dim strReturn As String = ""

        Dim url As String = pageGo & "?id=" & strID & "&mode=edit"
        If authen IsNot Nothing AndAlso Convert.ToInt32(authen) >= 3 Then
            strReturn = "<a href=""" & url & """ >" & strSubject & "</a>"
        Else
            strReturn = strSubject
        End If
        Return strReturn

    End Function

    Public Function SetAprovedInfo(ByVal objSubject As Object, ByVal objDate As Object) As String
        Dim strSubject As String = "-"
        If objSubject.ToString() IsNot Nothing AndAlso objSubject.ToString() <> "" Then
            strSubject = objSubject.ToString()
        End If
        If objDate IsNot Nothing AndAlso objDate.ToString() <> "" Then

            strSubject += " : " & formatD.DateTimeDisplay(objDate)
        End If
        Return strSubject
    End Function

    Public Function SetContent(ByVal objSubject As Object) As String
        Dim strSubject As String = objSubject.ToString().Trim()
        Return strSubject
    End Function

    Public Function SetContentPhone(ByVal objSubject As Object, ByVal objSubject2 As Object) As String
        Dim strSubject As String = ""
        If objSubject IsNot Nothing AndAlso objSubject.ToString() <> "" Then
            strSubject = objSubject.ToString()
        End If

        If objSubject2 IsNot Nothing AndAlso objSubject2.ToString() <> "" Then
            strSubject += " ต่อ " & objSubject2.ToString()
        End If

        Return strSubject
    End Function


    Public Function SetAbsentCount(ByVal objStatus As Object) As String

        If objStatus IsNot Nothing AndAlso objStatus.ToString() <> "" Then
            Dim value As Integer = Convert.ToInt32(objStatus)

            If value = 0 Then

                Return "ไม่ระบุ"
            Else
                Return objStatus.ToString()


            End If
        Else
            Return ""
        End If

    End Function





    Public Function SetContentEmail(ByVal objSubject As Object, ByVal objSubject2 As Object) As String
        Dim strSubject As String = ""
        If objSubject IsNot Nothing AndAlso objSubject.ToString() <> "" Then
            strSubject = objSubject.ToString()
        ElseIf objSubject2 IsNot Nothing AndAlso objSubject2.ToString() <> "" Then
            strSubject = objSubject2.ToString()
        End If

        Return strSubject

    End Function

    Public Function SetDateFormat_Incident(ByVal objValue As Object) As String
        If objValue IsNot Nothing Then
            Dim arr As String() = objValue.ToString().Split(" "c)
            If arr.Length > 0 AndAlso arr(0).Trim() <> "" Then

                Dim temp As String() = arr(0).Split("/"c)
                Return temp(0) & "/" & temp(1) & "/" & temp(2)
            Else
                Return ""

            End If
        Else
            Return ""
        End If
    End Function

    Public Function SetDateFormat(ByVal objValue As Object) As String
        If objValue IsNot Nothing Then
            Dim formatD As New clsFormateDateTime()
            Return formatD.DateDisplay(objValue)
        Else
            Return ""
        End If
    End Function

    Public Function SetDateTimeFormat(ByVal objValue As Object) As String
        If objValue IsNot Nothing Then
            Dim formatD As New clsFormateDateTime()
            Return formatD.DateTimeDisplay(objValue)
        Else
            Return ""
        End If
    End Function


    Public Function SetDateAbsentFormat(ByVal type As Object, ByVal start As Object, ByVal [end] As Object, ByVal absentDate As Object) As String
        Dim format As String = ""

        If type IsNot Nothing Then
            If type.ToString() = "Day" Then
                format = formatD.DateDisplay(start) & " - " & formatD.DateDisplay([end])
            End If
            If type.ToString() = "Hour" Then
                Dim f_ As String = formatD.DateDisplay(absentDate)
                format = f_ & " - " & f_
            End If
            If type.ToString() = "Weekend" OrElse type.ToString() = "Holiday" Then
                Dim f_ As String = formatD.DateDisplay(absentDate)
                format = f_ & " - " & f_

            End If
        End If

        Return format

    End Function




    Public Function SetAction(ByVal objValue As Object, ByVal pageGo As String) As String
        If objValue IsNot Nothing Then
            Dim link As String = pageGo & "?mode=edit&id=" & objValue.ToString()
            Dim htmlAll As String = "<a href='" & link & "'><img src='img/icon/b_edit.png'/></a>"

            Return htmlAll
        Else
            Return ""
        End If

    End Function



    Public Function SetNumberFormat(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" Then
            Return objValue.ToString()
        Else
            Return "0"
        End If
    End Function

    Public Function SetNumberFormat2(ByVal objValue As Object) As String
        If objValue IsNot Nothing AndAlso objValue.ToString() <> "" AndAlso objValue.ToString() <> "0" Then
            Return objValue.ToString()
        Else
            Return "-"
        End If
    End Function
    Private Function GetFileType(ByVal fileName As String) As String

        Dim fileType As String = fileName.Substring(fileName.Length - 4, 4)
        If fileType.PadLeft(1) = "." Then

            fileType = fileType.PadRight(3)
        Else

            fileType = fileType.PadLeft(3)
        End If

        Return fileType

    End Function

    Public Function GetFileIcon(ByVal strFileName As String) As String
        strFileName = strFileName.ToLower()
        Dim arrFileType As String() = {"DOC", "File", "FLV", "HTML", "JPG", "GIF", _
         "PDF", "PPT", "TXT", "XLS", "ZIP", "RAR", _
         "PNG"}
        Dim indexOf As Integer = -1
        Dim strIcon As String = "iconFile.gif"
        For i As Integer = 0 To arrFileType.Length - 1
            indexOf = strFileName.IndexOf(arrFileType(i).ToString().ToLower())
            If indexOf <> -1 Then
                strIcon = "icon" & arrFileType(i).ToString() & ".gif"
                Return "<img src='img/fileType/" & strIcon & "' class='iconsLeft' />"
            End If
        Next

        Return "<img src='img/fileType/" & strIcon & "' class='iconsLeft' />"


    End Function

    Public Function getSelectAction(ByVal authenMenu As Integer) As String
        Dim htmlAll As String = ""


        If authenMenu = 1 Then
        End If
        If authenMenu = 2 Then
            htmlAll += "<option value='active'>Set Active</option>"
            htmlAll += "<option value='preview'>Set Preview</option>"
            '  htmlAll += "<option value='Delete'>Delete</option>";


            htmlAll += "<option value='inactive'>Set inactive</option>"
        End If
        If authenMenu = 3 Then
            htmlAll += "<option value='active'>Set Active</option>"
            htmlAll += "<option value='preview'>Set Preview</option>"
            htmlAll += "<option value='inactive'>Set inactive</option>"
            htmlAll += "<option value='Delete'>Delete</option>"
        End If


        Return htmlAll
    End Function

    Public Function GetColorCss(ByVal statusID As Object) As String
        If statusID IsNot Nothing AndAlso statusID.ToString() <> "" Then

            If statusID.ToString().Trim() = "1" Then
                Return "green"
            ElseIf statusID.ToString().Trim() = "2" Then

                Return "gold"
            ElseIf statusID.ToString().Trim() = "3" Then

                Return "red"


            End If
        End If
        Return "green"

    End Function

End Class
