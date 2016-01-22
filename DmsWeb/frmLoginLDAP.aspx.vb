Imports System.Web.Security
Imports System.Xml.Serialization
Imports System.IO
Imports Engine.Auth
Imports Engine.Common
Imports Para.Common
Imports Para.Common.Utilities
Imports System.DirectoryServices
Imports System.Data

Partial Class frmLoginLDAP
    Inherits System.Web.UI.Page
    Dim SerialUserData As String = ""

    'Private Function CreateUserProfile(ByVal UserName As String) As UserProfilePara
    '    'สร้าง Profile  No SSO โดย Config
    '    Dim uPara As New UserProfilePara
    '    Dim cEng As New Engine.Master.OfficerEng
    '    Dim cPara As New Para.TABLE.OfficerPara
    '    cPara = cEng.GetOfficerParaByUserName(UserName)
    '    If cPara.ID <> 0 Then
    '        uPara.UserName = cPara.USERNAME

    '        Dim log As New LogEng
    '        log.SaveLoginHistory(uPara.UserName, Request)
    '        uPara.LOGIN_HISTORY_ID = log.LOGIN_HISTORY_ID
    '        log = Nothing
    '        If uPara.LOGIN_HISTORY_ID <> 0 Then
    '            Dim tmp As New LoginSessionPara
    '            tmp.LOGIN_HISTORY_ID = uPara.LOGIN_HISTORY_ID
    '            tmp.USER_NAME = uPara.UserName
    '            Session(Constant.UserProfileSession) = tmp

    '            Dim eng As New Engine.Master.OrganizationEng
    '            Dim stDt As New DataTable
    '            stDt = eng.GetDataOrgStorageList()
    '            If stDt.Rows.Count > 0 Then
    '                Session("OrgStorageList") = stDt.Copy
    '            End If
    '            stDt.Dispose()
    '            eng = Nothing
    '        End If
    '    End If
    '    cPara = Nothing
    '    cEng = Nothing

    '    Return uPara
    'End Function

    Private Function CreateUserProfile(ByVal UserName As String) As UserProfilePara
        'สร้าง Profile  No SSO โดย Config
        Dim uPara As New UserProfilePara
        Dim cEng As New Engine.Master.OfficerEng
        Dim cPara As New Para.TABLE.OfficerPara
        cPara = cEng.GetOfficerParaByUserName(UserName)
        If cPara.ID <> 0 Then
            uPara.UserName = cPara.USERNAME
            
            Dim log As New LogEng
            log.SaveLoginHistory(uPara.UserName, Request)
            uPara.LOGIN_HISTORY_ID = log.LOGIN_HISTORY_ID
            log = Nothing
            If uPara.LOGIN_HISTORY_ID <> 0 Then
                Dim tmp As New LoginSessionPara
                tmp.LOGIN_HISTORY_ID = uPara.LOGIN_HISTORY_ID
                tmp.USER_NAME = uPara.UserName
                Session(Constant.UserProfileSession) = tmp

                Dim eng As New Engine.Master.OrganizationEng
                Dim stDt As New DataTable
                stDt = eng.GetDataOrgStorageList()
                If stDt.Rows.Count > 0 Then
                    Session("OrgStorageList") = stDt.Copy
                End If
                stDt.Dispose()
                eng = Nothing
            End If
        End If
        cPara = Nothing
        cEng = Nothing

        Return uPara
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Session.Remove(Para.Common.Utilities.Constant.UserProfileSession)
            Session.Remove(Para.Common.Utilities.Constant.SessFileUploadList)
            Session.Remove(Para.Common.Utilities.Constant.UserMenuListSession)
        End If
    End Sub

    Dim _err As String = ""
    Private Function CheckLDAP(ByVal UserName As String, ByVal pwd As String) As Boolean

        'Dim Msg As String = ""
        Dim ret As Boolean = False
        Dim ip As String() = Split(FunctionENG.GetConfigValue("LDAP_IP"), "###")
        For Each i As String In ip
            Try
                'Dim DirEntry As New DirectoryEntry("LDAP://boi.go.th/DC=boi,DC=go,DC=th", UserName, pwd, AuthenticationTypes.Secure)
                Dim DirEntry As New DirectoryEntry("LDAP://" & i & "/DC=boi,DC=go,DC=th", UserName, pwd, AuthenticationTypes.Secure)
                Dim DirSer As New DirectorySearcher
                DirSer.ClientTimeout = System.TimeSpan.FromSeconds(3)
                DirSer.SearchRoot = DirEntry
                DirSer.Filter = "(&(ObjectClass=user)(anr=" + UserName + "))"

                Dim RetCol As SearchResultCollection = DirSer.FindAll
                If RetCol.Count > 0 Then
                    Dim dt As DataTable = Engine.Common.BOICentralENG.GetOfficerByUserID(UserName)
                    If dt IsNot Nothing Then
                        If dt.Rows.Count > 0 Then
                            UpdateUserProfile(dt.Rows(0))
                            dt = Nothing
                            ret = True
                            Exit For
                        Else
                            ret = False
                        End If
                    Else
                        ret = False
                    End If

                    'ret = True
                    'Exit For
                Else
                    ret = False
                End If
                RetCol.Dispose()
                DirSer.Dispose()
                DirEntry.Dispose()
            Catch ex As DirectoryServicesCOMException
                'Config.SetAlert("ชื่อเข้าระบบหรือรหัสผ่านไม่ถูกต้อง", Me)
                _err = "DirectoryServicesCOMException :" & "ชื่อเข้าระบบหรือรหัสผ่านไม่ถูกต้อง"
                ret = False
            Catch ex As DirectoryNotFoundException
                _err = "DirectoryNotFoundException :" & ex.Message & ex.StackTrace
                Config.SaveErrorLog(_err, 0)
                ret = False
            Catch ex As System.Runtime.InteropServices.COMException
                _err = " System.Runtime.InteropServices.COMException " & ex.Message & ex.StackTrace
                Config.SaveErrorLog(_err, 0)
                ret = False
            End Try
        Next
        
        Return ret
    End Function

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If Login1.UserName.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุชื่อเข้าระบบ", Me)
        ElseIf Login1.Password.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรหัสผ่าน", Me)
        End If
        Return ret
    End Function

    Private Sub UpdateUserProfile(ByVal dr As DataRow)
        Dim sqltmp As String = "update OFFICER set "
        sqltmp = sqltmp + "officer_code = '" + dr("officer_code").ToString + "'"
        sqltmp = sqltmp + ",first_name = '" + dr("TNAME").ToString + "'"
        sqltmp = sqltmp + ",last_name = '" + dr("TLASTNAME").ToString + "'"
        If Convert.IsDBNull(dr("TNAME")) = False Then sqltmp = sqltmp + ",first_name_thai = '" + dr("TNAME").ToString + "'"
        If Convert.IsDBNull(dr("TLASTNAME")) = False Then sqltmp = sqltmp + ",last_name_thai = '" + dr("TLASTNAME").ToString + "'"
        If Convert.IsDBNull(dr("ENAME")) = False Then sqltmp = sqltmp + ",first_name_eng = '" + dr("ENAME").ToString + "'"
        If Convert.IsDBNull(dr("ELASTNAME")) = False Then sqltmp = sqltmp + ",last_name_eng = '" + dr("ELASTNAME").ToString + "'"
        If Convert.IsDBNull(dr("DESCRIPTION")) = False Then sqltmp = sqltmp + ",description = '" + dr("DESCRIPTION").ToString + "'"
        If Convert.IsDBNull(dr("ORGANIZATION_D")) = False Then sqltmp = sqltmp + ",organization_id = '" + dr("ORGANIZATION_D").ToString + "'"
        If Convert.IsDBNull(dr("GENDER")) = False Then sqltmp = sqltmp + ",gender = '" + dr("GENDER").ToString + "'"
        If Convert.IsDBNull(dr("BIRTHDATE")) = False Then sqltmp = sqltmp + ",birth_date = '" + Convert.ToDateTime(dr("BIRTHDATE")).ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'"
        If Convert.IsDBNull(dr("EFDATE")) = False Then sqltmp = sqltmp + ",efdate = '" + Convert.ToDateTime(dr("EFDATE")).ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'"
        If Convert.IsDBNull(dr("EPDATE")) = False Then sqltmp = sqltmp + ",epdate = '" + Convert.ToDateTime(dr("EPDATE")).ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) + "'"
        If Convert.IsDBNull(dr("OFFICERLEVEL")) = False Then sqltmp = sqltmp + ",officer_level = '" + dr("OFFICERLEVEL").ToString + "'"
        If Convert.IsDBNull(dr("IDENTITYCARD")) = False Then sqltmp = sqltmp + ",identity_card = '" + dr("IDENTITYCARD").ToString + "'"
        If Convert.IsDBNull(dr("TEL")) = False Then sqltmp = sqltmp + ",tel = '" + dr("TEL").ToString + "'"
        If Convert.IsDBNull(dr("fax")) = False Then sqltmp = sqltmp + ",Fax = '" + dr("fax").ToString + "'"
        If Convert.IsDBNull(dr("email")) = False Then sqltmp = sqltmp + ",email = '" + dr("email").ToString + "'"
        sqltmp = sqltmp + ",update_by = '" + dr("username") + "'"
        sqltmp = sqltmp + ",update_on= getdate()"
        sqltmp = sqltmp + " where username = '" & dr("username") & "'"

        Dim eng As New Engine.Master.OfficerEng
        eng.UpdateUserProfile(sqltmp)
        eng = Nothing
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        If Valid() = True Then
            If Login1.UserName.ToUpper <> "AKKARAWAT" Then
                If CheckLDAP(Login1.UserName, Login1.Password) = True Then
                    Dim uData As UserProfilePara
                    uData = CreateUserProfile(Login1.UserName)
                    If uData.UserName <> "" Then
                        e.Authenticated = True
                    Else
                        e.Authenticated = False
                        Config.SetAlert(_err, Me)
                    End If
                Else
                    e.Authenticated = False
                    Config.SaveErrorLog(_err, 0)
                    Config.SetAlert(_err, Me)
                End If
            Else
                If CheckLoginFromDB(Login1.UserName, Login1.Password) = True Then
                    CreateUserProfile(Login1.UserName)
                    e.Authenticated = True
                Else
                    e.Authenticated = False
                    Config.SaveErrorLog(_err, 0)
                    Config.SetAlert(_err, Me)
                End If
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
        Else
            e.Authenticated = False
        End If
    End Sub

    Private Function CheckLoginFromDB(ByVal UserName As String, ByVal Pwd As String) As Boolean
        Dim ret As Boolean = False
        Dim eng As New Engine.Auth.LogInEng
        ret = eng.CheckLogin(UserName, Pwd)
        If ret = False Then
            _err = eng.ErrorMessage
        End If

        eng = Nothing
        Return ret
    End Function

    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        'HttpContext.Current.Response.Cookies.Clear()
        'Dim fat As New FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(60), False, SerialUserData.ToString)
        'Dim ck As New System.Web.HttpCookie(".BOIDMS")
        'ck.Value = FormsAuthentication.Encrypt(fat)
        'ck.Expires = fat.Expiration
        'HttpContext.Current.Response.Cookies.Add(ck)

        If Request("ReturnUrl") Is Nothing Or Request("ReturnUrl") = "" Then
            Response.Redirect("WebApp/frmDocToDoList.aspx?rnd=" & Date.Now.Millisecond)
        Else
            Response.Redirect(Request("ReturnUrl"))
        End If
    End Sub

    Protected Sub Login1_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoginError

    End Sub
End Class
