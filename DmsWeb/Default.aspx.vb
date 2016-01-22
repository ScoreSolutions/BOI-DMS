Imports System.Web.Security
Imports System.Xml.Serialization
Imports System.IO
Imports Engine.Auth
Imports Engine.Common
Imports Para.Common
Imports Para.Common.Utilities


Partial Class _Default
    Inherits System.Web.UI.Page

    Dim SerialUserData As String = ""
    Private Function CreateLoginSession(ByVal uPara As UserProfilePara) As LoginSessionPara
        Dim lSess As New LoginSessionPara
        lSess.LOGIN_HISTORY_ID = uPara.LOGIN_HISTORY_ID
        lSess.USER_NAME = uPara.UserName

        Return lSess
    End Function

    Private Function CreateUserProfile() As UserProfilePara
        'สร้าง Profile ของผู้ใช้งานกรณี Login ด้วย SSO
        Dim uPara As New UserProfilePara
        uPara.SsoID = Request.Form("id")
        'uPara.UserIDCardNo = Request.Form("pid")
        uPara.UserName = Request.Form("userlogin")
        'uPara.TitleName = Request.Form("prename")
        uPara.FirstName = Request.Form("firstname")
        uPara.LastName = Request.Form("lastname")
        'uPara.Sex = Request.Form("sex")
        'uPara.PostionName = Request.Form("position")
        'uPara.StaffLevel = Request.Form("level")
        'uPara.DivisionName = Request.Form("departmentoperation")
        'uPara.DepartmentName = Request.Form("department")
        'uPara.EMAIL = Request.Form("email")
        uPara.IS_SSO = "Y"


        ''สร้าง Profile  No SSO โดย Config
        ''Dim iniFile As Linq.Common.Utilities.IniReader
        ''iniFile = Linq.Common.Utilities.SqlDB.INIFileName
        'Dim cEng As New Engine.Master.OfficerEng
        'Dim cPara As New Para.TABLE.OfficerPara
        ''cPara = cEng.GetOfficerParaByUserName(iniFile.ReadString("TestUserName"))
        'cPara = cEng.GetOfficerParaByUserName(Login1.UserName)
        'Dim uPara As New UserProfilePara
        'uPara.SsoID = DateTime.Now.Millisecond
        'uPara.UserName = cPara.USERNAME
        'uPara.FirstName = cPara.FIRST_NAME
        'uPara.LastName = cPara.LAST_NAME
        'uPara.IS_SSO = "N"
        ''iniFile = Nothing
        'cPara = Nothing
        'cEng = Nothing

        Dim engS As New Engine.Master.OfficerEng
        uPara.OFFICER_DATA = engS.GetOfficerParaByUserName(uPara.UserName)
        Dim engO As New Engine.Master.OrganizationEng
        uPara.ORG_DATA = engO.GetOrgPara(uPara.OFFICER_DATA.ORGANIZATION_ID)

        Dim log As New LogEng
        log.SaveLoginHistory(uPara.UserName, Request)
        uPara.LOGIN_HISTORY_ID = log.LOGIN_HISTORY_ID

        Return uPara
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("result") IsNot Nothing Then
            If Request("result") = "True" Then
                Session.RemoveAll()
                'Dim uData As UserProfilePara
                'uData = CreateUserProfile()
                'Session(Constant.UserProfileSession) = uData

                Login1.UserName = Request("userlogin")
                Login1_Authenticate(sender, New System.Web.UI.WebControls.AuthenticateEventArgs)
                Login1_LoggedIn(sender, e)
            End If
        End If


        'Dim uData As UserProfilePara
        'uData = CreateUserProfile()
        'Session(Constant.UserProfileSession) = uData

        'Response.Redirect("WebApp/frmDocToDoList.aspx?rnd=" & Date.Now.Millisecond)
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        e.Authenticated = True
        Dim uData As UserProfilePara
        uData = CreateUserProfile()
        Session(Constant.UserProfileSession) = uData

        ''Create LoginSession
        'Dim sr As New XmlSerializer(GetType(UserProfilePara))
        'Dim st As New MemoryStream()
        'sr.Serialize(st, Session(Constant.UserProfileSession))
        'Dim b() As Byte = st.GetBuffer()
        'SerialUserData = Convert.ToBase64String(b)
    End Sub

    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        HttpContext.Current.Response.Cookies.Clear()
        'Dim fat As New FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddDays(1), True, SerialUserData)
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
