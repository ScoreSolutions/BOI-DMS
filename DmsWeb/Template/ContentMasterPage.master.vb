Imports Para.TABLE
Imports Para.Common
Imports Engine.Master
Imports Engine.Common
Imports System.Data

Partial Class Template_ContentMasterPage
    Inherits System.Web.UI.MasterPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uData As UserProfilePara = Config.GetLogOnUser
        If Not Page.IsPostBack Then
            If uData.UserName <> "" Then
                GetModule(uData)
                lblUser.Text = uData.FirstName & " " & uData.LastName
                lblUserOrg.Text = uData.ORG_DATA.ORG_THAI_NAME
            Else
                'lblUser.Text = "นายอัครวัฒน์ พุทธจันทร์"
                Response.Redirect("../WebApp/frmSessionExpire.aspx")
            End If
        End If

        getNewDoc(uData)
        getCount(uData)
        GetSendDoc(uData)

        uData = Nothing
    End Sub

    
    Public Function Null2Str(ByVal Ojb As Object) As String
        If Not IsNothing(Ojb) Then
            Try
                If Not IsDBNull(Ojb) Then
                    Return CStr(Ojb)
                End If
            Catch ex As Exception
            End Try
        End If
        Return ""
    End Function

    Public Sub GetSendDoc(ByVal uPara As Para.Common.UserProfilePara)
        'งานส่งภายในไปแล้วยังไม่ลงรับ
        lblDocSend.Visible = False

        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = " 1=1 "
        whText += " and ir.organization_id_send = '" & uPara.ORG_DATA.ID & "' "
        Dim eng As New Engine.Document.SearchDocumentENG
        Dim dt As New DataTable
        dt = eng.SearchDocumentRetrieve(whText, uPara)

        If dt.Rows.Count > 0 Then
            lblDocSend.Visible = True
            lblDocSend.Text = "<a href='../WebApp/frmSearchBookRetrieve.aspx?rnd=" & DateTime.Now.Millisecond & "' "
            lblDocSend.Text += " OnClick=""SaveTransLog('คลิกปุ่มมีเอกสารส่งภายในยังไม่ลงรับ','" & uPara.LOGIN_HISTORY_ID & "');"" title='มีเอกสารส่งภายในยังไม่ลงรับ(" & dt.Rows.Count & ")' >"
            lblDocSend.Text += "<table border='0' cellpadding='0' cellspacing='0' width='75px'>"
            lblDocSend.Text += " <tr>"
            lblDocSend.Text += "     <td width='25px'>"
            lblDocSend.Text += "         <img src='../Images/Module/03.png' width='24' height='24' border='0' title='มีเอกสารส่งภายในยังไม่ลงรับ(" & dt.Rows.Count & ")'  /> "
            lblDocSend.Text += "     </td>"
            lblDocSend.Text += "     <td >"
            lblDocSend.Text += "         <b><font color='#FFFFFF'>(" & dt.Rows.Count & ")</font></b>"
            lblDocSend.Text += "     </td>"
            lblDocSend.Text += " </tr>"
            lblDocSend.Text += "</table>"
            lblDocSend.Text += "</a>"
        End If

        dt.Dispose()
        'uPara = Nothing
        eng = Nothing
    End Sub

    Public Sub getNewDoc(ByVal uPara As Para.Common.UserProfilePara)
        'งานเข้า
        lblNewDoc.Visible = False
        'imgNewMsg.Visible = False

        Dim NewDoc As Long = 0
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " SELECT COUNT(dr.id) as countS "
        sql += " FROM   DOCUMENT_REGISTER dr "
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id"
        sql += "    and ir.id = (select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc) "
        sql += " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome & "'"
        sql += " and ir.receive_date is null and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive & "' "
        If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
            sql += " and isnull(ir.receiver_officer_username,'" & uPara.UserName & "') = '" & uPara.UserName & "' "
        End If
        sql += " and ir.organization_id_receive = '" & uPara.ORG_DATA.ID & "'"
        'sql += " and dr.ref_old_id is null"
        dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        trans.CommitTransaction()
        If (dt.Rows.Count > 0) Then
            If Convert.ToInt64(dt.Rows(0)("countS")) > 0 Then
                With dt.Rows(0)
                    NewDoc += Convert.ToInt64(Null2Str(.Item("countS")))
                End With
            End If
        End If
        dt.Dispose()

        ''########### เอาออกชั่วคราว ยังไม่ได้ใช้ #############
        ''########### 2013-01-18
        ''ตรวจสอบเอกสารอิเล็กทรอนิก
        'Dim eng As New Engine.Document.SearchDocumentENG
        'Dim eDt As New DataTable
        'eDt = eng.GetElecDocWaitRegis("", uPara)
        'If eDt.Rows.Count > 0 Then
        '    NewDoc += eDt.Rows.Count
        'End If
        'eDt = Nothing
        'eng = Nothing

        ''ตรวจสอบเอกสารใหม่จาก TH-eGIF
        'Dim tDt As New DataTable
        'tDt = Engine.WebService.THeGIFENG.SearchTHeGIFDoc("case when isnull(receive_notify_letterid,'') = '' then '1' else '2' end = '1'")
        'If tDt.Rows.Count > 0 Then
        '    NewDoc += tDt.Rows.Count
        'End If
        'tDt = Nothing
        ''###########################

        If NewDoc > 0 Then
            lblNewDoc.Visible = True
            lblNewDoc.Text = "<a href='../WebApp/frmDocToDoList.aspx?rnd=" & DateTime.Now.Millisecond & "' "
            lblNewDoc.Text += " OnClick=""SaveTransLog('คลิกปุ่มมีเอกสารใหม่','" & uPara.LOGIN_HISTORY_ID & "');"" title='มีเอกสารใหม่(" & NewDoc & ")' >"
            lblNewDoc.Text += "<table border='0' cellpadding='0' cellspacing='0' width='75px'>"
            lblNewDoc.Text += " <tr>"
            lblNewDoc.Text += "     <td width='25px'>"
            lblNewDoc.Text += "         <img src='../Images/Menu/new_msg.gif' width='24' height='24' border='0' /> "
            lblNewDoc.Text += "     </td>"
            lblNewDoc.Text += "     <td >"
            lblNewDoc.Text += "         <b><font color='#FFFFFF'>(" & NewDoc & ")</font></b>"
            lblNewDoc.Text += "     </td>"
            lblNewDoc.Text += " </tr>"
            lblNewDoc.Text += "</table>"
            lblNewDoc.Text += "</a>"
        End If

        'uPara = Nothing
    End Sub
    Public Sub getCount(ByVal uPara As Para.Common.UserProfilePara)
        'งานตีกลับโดยระบบ
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser

        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " SELECT COUNT(dr.id) as countS "
        sql += " FROM   DOCUMENT_REGISTER dr "
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id"
        sql += "    and ir.id = (select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)"
        sql += " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"
        sql += " and ir.receive_date is not null and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem & "' "
        If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
            sql += " and isnull(ir.receiver_officer_username,'" & uPara.UserName & "') = '" & uPara.UserName & "' "
        End If
        sql += " and organization_id_receive = '" & uPara.ORG_DATA.ID & "'"
        dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        trans.CommitTransaction()

        lblSysSendBack.Visible = False
        'imgBackSystem.Visible = False
        If dt.Rows.Count > 0 Then
            If Convert.ToInt64(dt.Rows(0)("countS")) > 0 Then
                With dt.Rows(0)
                    lblSysSendBack.Visible = True
                    lblSysSendBack.Text = "<a href='../WebApp/frmDocRemainSendBack.aspx?rnd=" & DateTime.Now.Millisecond & "' "
                    lblSysSendBack.Text += " OnClick=""SaveTransLog('คลิกปุ่มมีเอกสารตีกลับโดยระบบ','" & uPara.LOGIN_HISTORY_ID & "');"" title='มีเอกสารตีกลับโดยระบบ(" & .Item("countS") & ")' >"
                    lblSysSendBack.Text += "<table border='0' cellpadding='0' cellspacing='0' width='75px'>"
                    lblSysSendBack.Text += "    <tr>"
                    lblSysSendBack.Text += "        <td width='25px'>"
                    lblSysSendBack.Text += "            <img src='../Images/Menu/redletter.gif' width='24' height='24' border='0' />"
                    lblSysSendBack.Text += "        </td>"
                    lblSysSendBack.Text += "        <td>"
                    lblSysSendBack.Text += "            <b><font color='#FFFFFF'>(" & .Item("countS") & ")</font></b>"
                    lblSysSendBack.Text += "        </td>"
                    lblSysSendBack.Text += "    </tr>"
                    lblSysSendBack.Text += "</table>"
                    lblSysSendBack.Text += "</a>"
                End With
            End If
            dt.Dispose()
        End If
        'uPara = Nothing

    End Sub

    Function CreateMenuList(ByVal ModuleID As Long, ByVal RefMenuID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uData As UserProfilePara) As String
        Dim fnc As New MenuEng
        'Dim uPara As New Para.Common.UserProfilePara
        'uPara = Config.GetLogOnUser

        Dim dt As New DataTable
        dt = fnc.GetAuthMenuList(ModuleID, RefMenuID, uData, trans)
        Dim strHTML As New StringBuilder
        If dt.Rows.Count > 0 Then
            strHTML.Append(" <div class=""submenu"">")
            For Each dr In dt.Rows
                strHTML.Append(" <img src=" & dr("menu_icon") & " border=0>&nbsp;")
                If dr("menu_url").ToString <> "#" And dr("menu_url").ToString <> "" Then
                    strHTML.Append(" <a href=" & Chr(34) & dr("menu_url") & "?rnd=" & DateTime.Now.Millisecond & Chr(34) & " OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & dr("menu_name") & Chr(39) & "," & Chr(39) & uData.LOGIN_HISTORY_ID & Chr(39) & ");"" >" & dr("menu_name") & "</a>")
                Else
                    strHTML.Append(" <a href=" & Chr(34) & dr("menu_url") & Chr(34) & " >" & dr("menu_name") & "</a>")
                End If

                If dr("id").ToString = Engine.Common.FunctionENG.GetConfigValue("MenuElecDocWaitCheck") Then
                    strHTML.Append(fnc.GetNewCheckIcon(uData, dr("id"), trans))
                End If
                If dr("id").ToString = Engine.Common.FunctionENG.GetConfigValue("MenuElecDocWaitApprove") Then
                    strHTML.Append(fnc.GetNewApproveIcon(uData, dr("id"), trans))
                End If
                If dr("id").ToString = Engine.Common.FunctionENG.GetConfigValue("MenuElecDocWaitRegis") Then
                    strHTML.Append(fnc.GetNewRegisIcon(uData, dr("id"), trans))
                End If
                strHTML.Append("<br />")
                strHTML.Append(CreateMenuList(ModuleID, dr("id"), trans, uData))
            Next
            strHTML.Append(" </div>")
            dt.Dispose()
        End If
        fnc = Nothing
        'uPara = Nothing
        Return strHTML.ToString
    End Function

    Private Function CreateFolderList(ByVal fldID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
        Dim ret As String = ""
        Dim eng As New Engine.ModuleFolder.ModuleFolderEng
        Dim dt As DataTable = eng.GetFolderList(fldID, trans)
        If dt.Rows.Count > 0 Then
            ret &= " <div class=""submenu"">"
            For Each dr As DataRow In dt.Rows
                ret &= " <img src=" & dr("folder_icon") & " border=0>&nbsp;"
                If dr("folder_url").ToString <> "#" And dr("folder_url").ToString <> "" Then
                    ret &= " <a href=" & Chr(34) & dr("folder_url") & Chr(34) & "?rnd=" & DateTime.Now.Millisecond & " OnClick=""SaveTransLog(" & Chr(39) & "คลิกโฟล์เดอร์" & dr("folder_name") & Chr(39) & ");"" >" & dr("folder_name") & "</a><br/>"
                Else
                    ret &= " <a href=" & Chr(34) & dr("folder_url") & Chr(34) & " >" & dr("folder_name") & "</a><br/>"
                End If
                ret &= CreateFolderList(dr("id"), trans)
            Next
            ret &= " </div>"
        End If
        eng = Nothing
        dt.Dispose()

        Return ret
    End Function
    Public Sub GetModule(ByVal uData As UserProfilePara)
        Dim strHTML As New StringBuilder
        If Session(Para.Common.Utilities.Constant.UserMenuListSession) Is Nothing Then
            'If lblHTML.Text.Trim = "" Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            'Dim uPara As New UserProfilePara
            'uPara = Config.GetLogOnUser()

            strHTML.Append(" <div class=""applemenu"">")
            Dim fnc As New ModuleEng
            Dim dt As DataTable = fnc.GetAuthModuleList(uData, trans)
            For Each dr As DataRow In dt.Rows
                Dim para As ModulePara
                para = fnc.GetModulePara(dr("id"), trans)
                strHTML.Append(" <div class=""silverheader"">")
                If para.MODULE_URL <> "#" And para.MODULE_URL <> "" Then
                    strHTML.Append(" <a href=" & Chr(34) & para.MODULE_URL & Chr(34) & "?rnd=" & DateTime.Now.Millisecond & " OnClick=""SaveTransLog(" & Chr(39) & "คลิกเมนู" & para.MODULE_NAME & Chr(39) & "," & Chr(39) & uData.LOGIN_HISTORY_ID & Chr(39) & ");"" >" & para.MODULE_NAME.ToString & "</a></div>")
                Else
                    strHTML.Append(" <a href=" & Chr(34) & para.MODULE_URL & Chr(34) & ">" & para.MODULE_NAME.ToString & "</a></div>")
                End If
                strHTML.Append(CreateMenuList(dr("id"), 0, trans, uData))
                para = Nothing
            Next
            dt.Dispose()
            fnc = Nothing
            strHTML.Append("</div>")
            trans.CommitTransaction()
            'uPara = Nothing
            Session(Para.Common.Utilities.Constant.UserMenuListSession) = strHTML
        Else
            strHTML = DirectCast(Session(Para.Common.Utilities.Constant.UserMenuListSession), StringBuilder)
            lblHTML.Text = strHTML.ToString
        End If
        lblHTML.Text = strHTML.ToString
        'strHTML.Remove(0, strHTML.Length)
    End Sub

    Protected Sub likLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likLogout.Click
        Logout()
    End Sub

    Public Sub Logout()
        Dim eng As New Engine.Common.LogEng
        Dim LogID As Long = Config.GetLoginHistoryID
        eng.SetLogoutTime(LogID)
        eng = Nothing

        Session.RemoveAll()
        'Session.Abandon()
        For i As Integer = 0 To Request.Form.Count - 1
            If Request.Form(i).Trim <> "" Then
                Request.Form(i).Remove(0)
            End If
        Next
        Response.Redirect("../frmLoginLDAP.aspx?rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class

