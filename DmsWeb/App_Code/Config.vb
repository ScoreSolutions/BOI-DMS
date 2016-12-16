Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Security
Imports System.Web.HttpContext
Imports System.Web.UI
Imports System.Configuration
Imports System.Xml.Serialization
Imports System.IO
Imports Para.Common
Imports Para.Common.Utilities
Imports Engine.Auth
Imports Para.TABLE
Imports Engine.Common
Imports System.Data

Public Class Config

    Public Shared Function GetUserName() As String
        Dim p As New Page
        Return p.User.Identity.Name.Trim
    End Function
    Public Shared Function ChkLogin() As Boolean
        Dim User As UserProfilePara = GetLogOnUser()
        Return (User.UserName.Trim <> "")
    End Function

    Public Shared Function ChkPermission(ByVal MenuID As Long) As Boolean
        Dim User As UserProfilePara = GetLogOnUser()
        Return True
    End Function

    Public Shared Function GetScannerPath() As String
        Return "C:/ScoreSolution/BOIScan/BOIScan.exe "
    End Function
    Public Shared Function CreateActiveFunction() As String
        Dim ret As String = ""
        ret += "MyObject = new ActiveXObject(""WScript.Shell"");" & vbNewLine
        ret += "MyObject.Run(path);"
        Return ret
    End Function

    'Public Shared Function GetLogOnUser() As UserProfilePara
    '    Dim ret As New UserProfilePara
    '    Try
    '        'Dim id As FormsIdentity = HttpContext.Current.User.Identity
    '        'Dim tik As FormsAuthenticationTicket = id.Ticket
    '        'Dim sr As New XmlSerializer(GetType(UserProfilePara))
    '        'Dim st As New MemoryStream(Convert.FromBase64String(tik.UserData))
    '        'ret = sr.Deserialize(st)

    '        Dim session As HttpSessionState = HttpContext.Current.Session
    '        If session(Constant.UserProfileSession) IsNot Nothing Then
    '            ret = session(Constant.UserProfileSession)
    '        Else
    '            'ret.SsoID = DateTime.Now.Millisecond
    '            'ret.UserIDCardNo = "1111111111111"
    '            'ret.UserName = "akkarawat"
    '            'ret.TitleName = "นาย"
    '            'ret.FirstName = "อัครวัฒน์"
    '            'ret.LastName = "พุทธจันทร์"
    '            'ret.Sex = "M"
    '            'ret.PostionName = "Administrator"
    '            'ret.StaffLevel = "เชี่ยวชาญเป็นพิเศษ"
    '            'ret.DivisionName = "IT"
    '            'ret.DepartmentName = "IT"
    '            'ret.EMAIL = "akkarawatp_hotmail.com"
    '            'ret.IS_SSO = "N"
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Return ret
    'End Function

    Public Shared Function GetLoginSessionPara() As LoginSessionPara
        Dim tmp As New LoginSessionPara
        Try
            'Dim id As FormsIdentity = HttpContext.Current.User.Identity
            'Dim tik As FormsAuthenticationTicket = id.Ticket
            'Dim sr As New XmlSerializer(GetType(LoginSessionPara))
            'Using st As New MemoryStream(Convert.FromBase64String(tik.UserData))
            '    tmp = sr.Deserialize(st)
            'End Using
            tmp = System.Web.HttpContext.Current.Session(Constant.UserProfileSession)
        Catch ex As Exception
            Dim Err As String = "Config.GetLoginSessionPara Exception :" & ex.Message & "###" & ex.StackTrace
            Err += "### SessionID:" & System.Web.HttpContext.Current.Session.SessionID
            Err += "### IP Address:" & System.Web.HttpContext.Current.Request.UserHostAddress
            Config.SaveErrorLog(Err, 0)
        End Try

        Return tmp
    End Function
    
    Public Shared Function GetLoginHistoryID() As Long
        Dim tmp As LoginSessionPara
        tmp = GetLoginSessionPara()
        Dim ret As Long = tmp.LOGIN_HISTORY_ID
        tmp = Nothing
        Return ret
    End Function

    Public Shared Function GetLogOnUser() As UserProfilePara
        Dim ret As New UserProfilePara
        Try
            'Dim tmp As LoginSessionPara
            'Dim id As FormsIdentity = HttpContext.Current.User.Identity
            'Dim tik As FormsAuthenticationTicket = id.Ticket
            'Dim sr As New XmlSerializer(GetType(LoginSessionPara))
            'Dim st As New MemoryStream(Convert.FromBase64String(tik.UserData))
            'tmp = sr.Deserialize(st)

            Dim tmp As LoginSessionPara
            tmp = GetLoginSessionPara()

            'Get UserProfile From Table in DB
            Dim lHis As New LoginHistoryPara
            lHis = LogInEng.GetLoginHistoryPara(tmp.LOGIN_HISTORY_ID)

            ret.LOGIN_HISTORY_ID = tmp.LOGIN_HISTORY_ID
            ret.SsoID = DateTime.Now.Millisecond
            ret.UserName = lHis.USERNAME
            ret.FirstName = Split(lHis.STAFF_NAME, " ")(0)
            ret.LastName = Split(lHis.STAFF_NAME, " ")(1)
            ret.IS_SSO = lHis.IS_SSO

            Dim cEng As New Engine.Master.OfficerEng
            Dim cPara As New Para.TABLE.OfficerPara
            cPara = cEng.GetOfficerParaByUserName(ret.UserName)
            ret.OFFICER_DATA = cPara

            Dim engO As New Engine.Master.OrganizationEng
            ret.ORG_DATA = engO.GetOrgPara(ret.OFFICER_DATA.ORGANIZATION_ID)

            engO = Nothing
            cEng = Nothing
            cPara = Nothing
            tmp = Nothing
            lHis = Nothing
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Public Shared Sub SetAlert(ByVal msg As String, ByVal frm As Page)
        Dim popupScript As String = "<script language='javascript'>  alert('" & msg & "');  </script>"
        ScriptManager.RegisterStartupScript(frm, GetType(String), "SetAlert1", popupScript, False)
    End Sub

    Public Shared Sub SetAlert(ByVal msg As String, ByVal frm As Page, ByVal ClientID As String)
        Dim popupScript As String = "<script language='javascript'> " & _
        " alert('" & msg & "'); " & _
        " document.getElementById('" & ClientID & "').focus();" & _
        " </script>"
        ScriptManager.RegisterStartupScript(frm, GetType(String), "SetAlert1", popupScript, False)
    End Sub
    Public Shared Function GetUploadPath() As String
        Return Engine.Common.FunctionENG.GetFileUploadPath()
    End Function

    Public Shared Function GetUploadURL() As String

    End Function
    Public Shared Function GetIconURL(ByVal req As HttpRequest) As String
        Return ConfigurationSettings.AppSettings("IconURL").ToString
    End Function
    Public Shared Function getServerPath() As String
        Return ConfigurationManager.AppSettings("UploadPath").ToString
    End Function
    Public Shared Function UploadFile(ByVal FileUpload1 As FileUpload, ByVal fileName As String, ByVal fldName As String) As Boolean
        'Upload and save file at directory
        Dim ret As Boolean = True

        If FileUpload1.HasFile = True Then
            Dim extension As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
            Dim MIMEType As String = ""

            Try
                MIMEType = getMIMEType(FileUpload1.PostedFile.FileName)
                If MIMEType = "" Then
                    Return False
                    Exit Function
                End If

                Dim X As String = Path.GetFileName(fileName)
                X = fldName & X & MIMEType
                'Ex.  D:\ElawUpload\   Document\Contract\   fileName.ext

                If Directory.Exists(fldName) = False Then
                    Directory.CreateDirectory(fldName)
                End If
                FileUpload1.PostedFile.SaveAs(X)
                ret = True
            Catch ex As Exception
                ret = False

            End Try
        End If

        Return ret
    End Function
    Public Shared Function getMIMEType(ByVal vFileName As String) As String
        Dim extension As String = System.IO.Path.GetExtension(vFileName).ToLower()
        Dim MIMEType As String = ""

        Select Case extension
            Case ".jpg", ".jpeg", ".jpe"
                MIMEType = ".jpg"
            Case ".csv", ".xls", ".xlsx", ".pdf", ".doc", ".docx", ".txt", ".png", ".gif"
                MIMEType = extension
            Case ".htm", ".html"
                MIMEType = ".html"
            Case Else
                MIMEType = ""
        End Select

        Return MIMEType

    End Function
    Public Shared Function BaseURL(ByVal req As HttpRequest) As String
        Return req.Url.Host & ConfigurationManager.AppSettings("UploadURL").ToString()
    End Function

    Public Shared Sub SaveLogEditDocument(ByVal LoginHisID As Long, ByVal UserName As String, ByVal DocRegisID As Long, ByVal GroupTitleIDOld As Long, ByVal GroupTitleIDNew As Long, ByVal GroupTitleNameOld As String, ByVal GroupTitleNameNew As String, ByVal TitleNameOld As String, ByVal TitleNameNew As String, ByVal BizTypeIDOld As Long, ByVal BizTypeIDNew As Long, ByVal BizNameOld As String, ByVal BizNameNew As String)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Try
            Dim sql As String = "insert into LOG_EDIT_DOCUMENT(create_by, create_on, login_his_id, log_date, document_register_id,"
            sql += "group_title_id_old,group_title_id_new, group_title_name_old, group_title_name_new, "
            sql += " title_name_old, title_name_new, business_type_id_old, business_type_id_new, business_type_name_old, business_type_name_new) "
            sql += " values('" & UserName & "',getdate()," & LoginHisID & ",getdate(), " & DocRegisID & ","
            sql += " " & GroupTitleIDOld & "," & GroupTitleIDNew & ",'" & GroupTitleNameOld & "','" & GroupTitleIDNew & "',"
            sql += " '" & TitleNameOld & "', '" & TitleNameNew & "', " & BizTypeIDOld & ", " & BizTypeIDNew & ", '" & BizNameOld & "','" & BizNameNew & "')"

            If Linq.Common.Utilities.SqlDB.ExecuteNonQuery(sql, trans.Trans) > 0 Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                SaveErrorLog(Linq.Common.Utilities.SqlDB.ErrorMessage, LoginHisID)
            End If

        Catch ex As Exception
            trans.RollbackTransaction()
            SaveErrorLog(ex.Message, LoginHisID)
        End Try

    End Sub

    Public Shared Sub SaveTransLog(ByVal TransDesc As String, ByVal LoginHisID As Long)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Try
            Dim lLnq As New Linq.TABLE.LoginHistoryLinq
            lLnq.GetDataByPK(LoginHisID, trans.Trans)

            Dim para As New LogTransPara
            para.LOGIN_HIS_ID = LoginHisID
            para.TRANS_DATE = DateTime.Now
            para.TRANS_DESC = TransDesc

            Dim fnc As New LogEng
            If fnc.SaveTransLog(lLnq.USERNAME, para, trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                SaveErrorLog(fnc.ErrorMessage, LoginHisID)
            End If
            para = Nothing
            fnc = Nothing
            lLnq = Nothing
        Catch ex As Exception
            trans.RollbackTransaction()
            SaveErrorLog(ex.Message, LoginHisID)
        End Try
    End Sub

    Public Shared Sub SaveTransLog(ByVal TransDesc As String)
        Dim LoginHisID As Long = GetLoginHistoryID()

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Try
            Dim lLnq As New Linq.TABLE.LoginHistoryLinq
            lLnq.GetDataByPK(LoginHisID, trans.Trans)

            Dim para As New LogTransPara
            para.LOGIN_HIS_ID = LoginHisID
            para.TRANS_DATE = DateTime.Now
            para.TRANS_DESC = TransDesc

            Dim fnc As New LogEng
            If fnc.SaveTransLog(lLnq.USERNAME, para, trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                SaveErrorLog(fnc.ErrorMessage, LoginHisID)
            End If
            para = Nothing
            fnc = Nothing
            lLnq = Nothing
        Catch ex As Exception
            trans.RollbackTransaction()
            SaveErrorLog(ex.Message, LoginHisID)
        End Try
    End Sub

    Public Shared Sub SaveErrorLog(ByVal ErrDesc As String, ByVal LoginHisID As Long)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Try
            Dim lLnq As New Linq.TABLE.LoginHistoryLinq
            lLnq.GetDataByPK(LoginHisID, trans.Trans)

            Dim para As New LogErrorPara
            para.LOGIN_HIS_ID = LoginHisID
            para.ERROR_TIME = DateTime.Now
            para.ERROR_DESC = ErrDesc

            Dim fnc As New LogEng
            If fnc.SaveErrLog(lLnq.USERNAME, para, trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            para = Nothing
            fnc = Nothing
            lLnq = Nothing
        Catch ex As Exception
            trans.RollbackTransaction()
        End Try
    End Sub

    Public Shared Sub PreviewReports(ByVal url As String, ByVal frm As Page)
        Dim popupScript As String = "<script language='javascript'> " & _
        " PreviewReport('" & url & "'); " & _
        " </script>"
        ScriptManager.RegisterStartupScript(frm, GetType(String), "PreviewReport", popupScript, False)
    End Sub

    Public Shared Sub GridViewSorting(ByVal gv As GridView, ByVal dt As DataTable, ByVal txtSortDir As TextBox, ByVal txtSortField As TextBox, ByVal e As GridViewSortEventArgs, ByVal PageIndex As Long)
        If e.SortExpression = "DEFAULT" Then
            txtSortDir.Text = e.SortDirection
            txtSortField.Text = e.SortExpression
        Else
            If txtSortField.Text = e.SortExpression Then
                txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
            Else : txtSortField.Text = e.SortExpression
            End If
        End If

        Dim sortStr As String = ""
        If txtSortField.Text.Trim <> "" Then
            sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
        End If

        gv.PageIndex = PageIndex
        dt.DefaultView.Sort = sortStr
        dt = dt.DefaultView.ToTable()
        If dt.Columns.Contains("no") Then
            '    Config.ReRuningNo(dt)
            'Else
            Config.BuildNoColumn(dt)
        End If
    End Sub

    Public Shared Sub GridViewSorting(ByVal gv As GridView, ByVal dt As DataTable, ByVal txtSortDir As TextBox, ByVal txtSortField As TextBox, ByVal e As EventArgs, ByVal PageIndex As Long)
        Dim sortStr As String = ""
        If txtSortField.Text.Trim <> "" Then
            sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
        End If

        gv.PageIndex = PageIndex
        dt.DefaultView.Sort = sortStr
        dt = dt.DefaultView.ToTable()
        If dt.Columns.Contains("no") Then
            '    Config.ReRuningNo(dt)
            'Else
            Config.BuildNoColumn(dt)
        End If
    End Sub

    Public Shared Sub BuildNoColumn(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            If dt.Columns.Contains("NO") = False Then
                dt.Columns.Add("NO")
            End If
            Dim i As Integer = 1
            For Each dr As DataRow In dt.Rows
                dr("no") = i
                i += 1
            Next
        End If
    End Sub
    Public Shared Function GetStringToDate(ByVal StrDate As String) As Date
        'แปลง String จาก yyyy-MM-dd ให้เป็นวันที่
        Dim ret As New Date(1, 1, 1)
        If StrDate.Length = "10" Then
            Dim vDate() As String = Split(StrDate, "-")
            ret = New Date(vDate(0), vDate(1), vDate(2))
        End If
        Return ret
    End Function

End Class
