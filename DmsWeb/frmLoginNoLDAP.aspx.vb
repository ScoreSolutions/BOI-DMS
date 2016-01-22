Imports System.Web.Security
Imports System.Xml.Serialization
Imports System.IO
Imports Engine.Auth
Imports Engine.Common
Imports Para.Common
Imports Para.Common.Utilities
Imports System.Data

Partial Class frmLoginNoLDAP
    Inherits System.Web.UI.Page

    Dim SerialUserData As String = ""
    Private Function CreateLoginSession(ByVal uPara As UserProfilePara) As LoginSessionPara
        Dim lSess As New LoginSessionPara
        lSess.LOGIN_HISTORY_ID = uPara.LOGIN_HISTORY_ID
        lSess.USER_NAME = uPara.UserName

        Return lSess
    End Function

    Private Function CreateUserProfile() As UserProfilePara
        'สร้าง Profile  No SSO โดย Config
        Dim uPara As New UserProfilePara
        Dim cEng As New Engine.Master.OfficerEng
        Dim cPara As New Para.TABLE.OfficerPara
        cPara = cEng.GetOfficerParaByUserName(Login1.UserName)
        If cPara.ID <> 0 Then
            uPara.UserName = cPara.USERNAME

            Dim log As New LogEng
            log.SaveLoginHistory(uPara.UserName, Request)
            uPara.LOGIN_HISTORY_ID = log.LOGIN_HISTORY_ID
            log = Nothing
            If uPara.LOGIN_HISTORY_ID <> 0 Then
                Session(Constant.UserProfileSession) = CreateLoginSession(uPara)

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
            Session(Para.Common.Utilities.Constant.UserProfileSession) = Nothing
            Session(Para.Common.Utilities.Constant.SessFileUploadList) = Nothing
            Session(Para.Common.Utilities.Constant.UserMenuListSession) = Nothing
        End If
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        e.Authenticated = True
        CreateUserProfile()

    End Sub

    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        If Request("ReturnUrl") Is Nothing Or Request("ReturnUrl") = "" Then
            Response.Redirect("WebApp/frmDocToDoList.aspx?rnd=" & Date.Now.Millisecond)
        Else
            Response.Redirect(Request("ReturnUrl"))
        End If
    End Sub

    Protected Sub Login1_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoginError

    End Sub
End Class
