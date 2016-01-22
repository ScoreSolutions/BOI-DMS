Imports System.Data

Partial Class WebApp_frmToDoList
    Inherits System.Web.UI.Page

    Protected Sub cb1_OnCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkH As CheckBox = sender
        Dim grv As GridViewRow = chkH.Parent.Parent
        Dim gv As GridView = grv.Parent.Parent
        For i As Integer = 0 To gv.Rows.Count - 1
            Dim chk As CheckBox = gv.Rows(i).Cells(2).FindControl("cb2")
            chk.Checked = chkH.Checked
        Next
    End Sub

    Private Function SearchData(ByVal uPara As Para.Common.UserProfilePara) As DataTable
        Dim dt As New DataTable
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = " 1=1 "
        If cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain Then
            whText += " and ir.organization_id_receive = '" & uPara.ORG_DATA.ID & "' "
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                whText += " and isnull(dr.officer_id_possess,'" & uPara.OFFICER_DATA.ID & "') = '" & uPara.OFFICER_DATA.ID & "' "
            End If
            whText += " and ir.is_forward = 'N'"   'กรณีเจ้าหน้าที่รับมาแล้วมีการส่งต่อให้ตัวเอง ก็ไม่ต้องแสดงข้อมูลในหน้านี้อีก จนกว่าจะลงรับภายใน
            whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"
            whText += " and ir.receive_date is not null "
            whText += " and ir.receive_status_id in ('" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received & "','" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem & "')"
        ElseIf cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome Then
            whText += " and dr.doc_status_id = '" & cmbJobStatus.SelectedValue & "'"
            whText += " and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive & "'"
            whText += " and ir.organization_id_receive='" & uPara.ORG_DATA.ID & "'"
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                whText += " and isnull(ir.receiver_officer_username,'" & uPara.UserName & "') = '" & uPara.UserName & "'"
            End If
            whText += " and ir.receive_date is null "
        End If

        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentToDoList(whText, uPara.ORG_DATA.ID, cmbJobStatus.SelectedValue)
        eng = Nothing
        'uPara = Nothing

        Return dt
    End Function

    Private Sub SetGridView(ByVal uPara As Para.Common.UserProfilePara)
        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)

            If cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome Then
                btnReceiveInside1.Visible = True
                btnCloseJob1.Visible = False
            ElseIf cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain Then
                btnReceiveInside1.Visible = False
                btnCloseJob1.Visible = True
            End If

            If dt.Rows.Count = 1 Then
                'กรณีค้นหาแล้วเจอ 1 รายการ ให้ติ๊กถูกให้เลย
                For Each grv As GridViewRow In GridView1.Rows
                    Dim cb As CheckBox = grv.Cells(2).FindControl("cb2")
                    cb.Checked = True
                Next
            End If
        Else
            btnReceiveInside1.Visible = False
            btnCloseJob1.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
        End If
        dt.Dispose()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Dim uPara As New Para.Common.UserProfilePara
            uPara = Config.GetLogOnUser
            If uPara.LOGIN_HISTORY_ID = 0 Then
                Response.Redirect("../WebApp/frmSessionExpire.aspx")
                Exit Sub
            End If

            SetJobStatusCombo()
            SetGridView(uPara)
            SetSentBackBySystem(uPara)
            uPara = Nothing

            '2013-01-11 ยังไม่ได้ใช้หรอก ปิดไปก่อน
            'SetGridviewElecDoc()
            'SetGridviewTHeGifDoc()
        End If
    End Sub

    Private Sub SetGridviewTHeGifDoc()
        'If Request.Url.Host = "10.0.0.147" Then
        '    'Get New Inbound
        '    Dim uPara As New Para.Common.UserProfilePara
        '    uPara = Config.GetLogOnUser
        '    Engine.WebService.THeGIFENG.GetNewInbound(uPara.UserName)
        '    uPara = Nothing
        'End If

        Dim dt As New DataTable
        dt = Engine.WebService.THeGIFENG.SearchTHeGIFDoc("case when isnull(receive_notify_letterid,'') = '' then '1' else '2' end = '1'")
        If dt.Rows.Count > 0 Then
            pc3.Visible = True
            pc3.SetMainGridView(gvTHeGif)
            gvTHeGif.DataSource = dt
            gvTHeGif.DataBind()
            pc3.Update(dt.Rows.Count)
            dt = Nothing
        Else
            pc3.Visible = False
            gvTHeGif.DataSource = Nothing
            gvTHeGif.DataBind()
        End If
    End Sub

    Private Sub SetGridviewElecDoc()
        Dim eng As New Engine.Document.SearchDocumentENG
        Dim dt As New DataTable
        dt = eng.GetElecDocWaitRegis("", Config.GetLogOnUser)
        eng = Nothing
        If dt.Rows.Count > 0 Then
            pc2.Visible = True
            pc2.SetMainGridView(gvElectronic)
            gvElectronic.DataSource = dt
            gvElectronic.DataBind()
            pc2.Update(dt.Rows.Count)
            dt = Nothing
        Else
            pc2.Visible = False
            gvElectronic.DataSource = Nothing
            gvElectronic.DataBind()
        End If
    End Sub

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Sub SetJobStatusCombo()
        cmbJobStatus.SetItemList("งานเข้า", "2")
        cmbJobStatus.SetItemList("งานค้าง", "1")
    End Sub

    Private Sub InsideReceive(ByVal uPara As Para.Common.UserProfilePara)
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        Dim TmpBookNo As String = ""
        For Each r As GridViewRow In GridView1.Rows
            Dim chkb As CheckBox
            chkb = CType(r.Cells(2).FindControl("cb2"), CheckBox)
            Dim lblBookNo As LinkButton = DirectCast(r.FindControl("likBookNo"), LinkButton)
            If chkb.Checked Then
                If r.Cells(11).Text.Trim = "งานเข้า" Then
                    Dim dr As DataRow = dt.NewRow
                    dr("DOCUMENT_INT_RECEIVER_ID") = r.Cells(1).Text
                    dr("DOCUMENT_REGISTER_ID") = r.Cells(0).Text
                    dt.Rows.Add(dr)

                    If TmpBookNo = "" Then
                        TmpBookNo = lblBookNo.Text
                    Else
                        TmpBookNo += "," & lblBookNo.Text
                    End If
                End If
            End If
        Next
        If dt.Rows.Count > 0 Then
            Dim eng As New Engine.Document.SearchDocumentENG
            If uPara.UserName.Trim <> "" Then
                Dim ret As Boolean = eng.ReceiveInternal(uPara, dt)
                eng = Nothing
                If ret = True Then
                    SetGridView(uPara)
                    Master.getNewDoc(uPara)
                    Master.getCount(uPara)
                    Config.SaveTransLog("ลงรับภายในสำนักงานเลขที่ " & TmpBookNo)
                Else
                    Config.SetAlert(eng.ErrorMessage, Me)
                End If
            Else
                Master.Logout()
            End If

        End If
    End Sub

    Protected Sub btnReceiveInside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveInside1.Click
        Dim SelectedDoc As DataTable = GetSelectedDocNo()
        If SelectedDoc.Rows.Count > 0 Then
            Config.SaveTransLog("คลิกปุ่มลงรับภายในสำนักงาน")
            btnReceiveInside1.ShowPop(SelectedDoc)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการลงรับภายในสำนักงาน", Me)
        End If
    End Sub
    Protected Sub btnReceiveInside1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveInside1.YesClick
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        If uPara.UserName.Trim <> "" Then
            Dim SelectedDoc As DataTable = GetSelectedDocNo()
            If SelectedDoc.Rows.Count > 0 Then
                InsideReceive(uPara)
            Else
                Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการลงรับภายในสำนักงาน", Me)
            End If
        Else
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
        End If
        uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.Click
        Dim SelectedDoc As DataTable = GetSelectedDocNo()
        If SelectedDoc.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("book_no")
            dt.Columns.Add("book_title")

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            For Each TmpDr As DataRow In SelectedDoc.Rows
                Dim dPara As New Para.TABLE.DocumentRegisterPara
                Dim eng As New Engine.Document.DocumentRegisterENG
                dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)

                Dim dr As DataRow = dt.NewRow
                dr("id") = dPara.ID
                dr("book_no") = dPara.BOOK_NO
                dr("book_title") = dPara.TITLE_NAME
                dt.Rows.Add(dr)
            Next
            trans.CommitTransaction()
            Config.SaveTransLog("คลิกปุ่มจบงาน", Config.GetLoginHistoryID)
            btnCloseJob1.SetConfirmList(dt)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการจบงาน", Me)
        End If
        SelectedDoc.Dispose()
    End Sub

    Private Function GetSelectedDocNo() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = grv.Cells(2).FindControl("cb2")
            If cb.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(0).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(1).Text
                dt.Rows.Add(dr)
            End If
        Next

        Return dt
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Config.SaveTransLog("คลิกปุ่มค้นหา", Config.GetLoginHistoryID)
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridView(uPara)
        uPara = Nothing
    End Sub

    Protected Sub cmbJobStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbJobStatus.SelectedIndexChanged
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome Then
            btnReceiveInside1.Visible = True
            btnCloseJob1.Visible = False
            Config.SaveTransLog("เลือก Dropdownlist งานเข้า", Config.GetLoginHistoryID)
        ElseIf cmbJobStatus.SelectedValue = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain Then
            btnReceiveInside1.Visible = False
            btnCloseJob1.Visible = True
            Config.SaveTransLog("เลือก Dropdownlist งานค้าง", Config.GetLoginHistoryID)
        End If
        SetGridView(uPara)
        uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.OKClick
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        SetGridView(uPara)
        'uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As System.Data.DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.YesClick
        btnCloseJob1.CloseJobSuccess = "Y"
    End Sub

    
    Protected Sub gvElectronic_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvElectronic.RowCommand
        If e.CommandName = "Register" Then
            Response.Redirect("../WebApp/frmDocRegister.aspx?RefDocID=" & e.CommandArgument & "&rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    Protected Sub gvTHeGif_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTHeGif.RowCommand
        If e.CommandName = "Register" Then
            Response.Redirect("../WebApp/frmDocRegister.aspx?THeGIFDocID=" & e.CommandArgument & "&rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

    Private Sub SetSentBackBySystem(ByVal uPara As Para.Common.UserProfilePara)
        Dim vSendBackDay As Integer = Convert.ToInt64(Engine.Common.FunctionENG.GetConfigValue("SEND_BACK_DAY"))

        Dim endDate As DateTime = DateAdd(DateInterval.Day, (-1 - vSendBackDay), DateTime.Now)
        Dim curDate As Date = DateTime.Now
        Do
            Dim hDt As New DataTable
            Dim hLnq As New Linq.TABLE.HolidayLinq
            hDt = hLnq.GetDataList("convert(varchar(8),holiday_date,112) =  '" + curDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) + "' ", "holiday_date", Nothing)
            If hDt.Rows.Count > 0 Then
                endDate = DateAdd(DateInterval.Day, -1, endDate)
            End If
            hDt = Nothing
            hLnq = Nothing
            curDate = DateAdd(DateInterval.Day, -1, curDate)
        Loop While curDate >= endDate

        Dim dt As New DataTable
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentRetrieve("convert(varchar(8),ir.send_date,112) <= '" & endDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'", uPara)
        If dt.Rows.Count > 0 Then
            Dim DateNow As DateTime = DateTime.Now
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)

                'ข้อมูล DocumentIntReceiver รายการเดิม
                Dim pOld As New Para.TABLE.DocumentIntReceiverPara
                Dim pEng As New Engine.Document.DocumentRegisterENG
                pOld = pEng.GetDocumentIntReceiverPara(dr("document_int_receiver_id"))
                pOld.IS_FORWARD = "Y"

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim iEng As New Engine.Document.DocumentRegisterENG
                If iEng.SaveInsideSend(uPara.UserName, pOld, trans) = True Then
                    Dim p As New Para.TABLE.DocumentIntReceiverPara
                    If Convert.IsDBNull(dr("id")) = False Then p.DOCUMENT_REGISTER_ID = dr("id")
                    If Convert.IsDBNull(dr("organization_id_send")) = False Then p.ORGANIZATION_ID_SEND = dr("organization_id_send")
                    If Convert.IsDBNull(dr("organization_name_send")) = False Then p.ORGANIZATION_NAME_SEND = dr("organization_name_send")
                    If Convert.IsDBNull(dr("organization_appname_send")) = False Then p.ORGANIZATION_APPNAME_SEND = dr("organization_appname_send")
                    p.SEND_DATE = DateNow
                    If Convert.IsDBNull(dr("sender_officer_username")) = False Then p.SENDER_OFFICER_USERNAME = dr("sender_officer_username")
                    If Convert.IsDBNull(dr("user_send")) = False Then p.SENDER_OFFICER_FULLNAME = dr("user_send")

                    p.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem
                    p.RECEIVE_DATE = DateNow
                    If Convert.IsDBNull(dr("organization_id_send")) = False Then p.ORGANIZATION_ID_RECEIVE = dr("organization_id_send")
                    If Convert.IsDBNull(dr("organization_name_send")) = False Then p.ORGANIZATION_NAME_RECEIVE = dr("organization_name_send")
                    If Convert.IsDBNull(dr("organization_appname_send")) = False Then p.ORGANIZATION_APPNAME_RECEIVE = dr("organization_appname_send")
                    If Convert.IsDBNull(dr("sender_officer_username")) = False Then p.RECEIVER_OFFICER_USERNAME = dr("sender_officer_username")
                    If Convert.IsDBNull(dr("user_send")) = False Then p.RECEIVER_OFFICER_FULLNAME = dr("user_send")
                    If Convert.IsDBNull(dr("receive_type_id")) = False Then p.RECEIVE_TYPE_ID = dr("receive_type_id")
                    If Convert.IsDBNull(dr("receive_objective_id")) = False Then p.RECEIVE_OBJECTIVE_ID = dr("receive_objective_id")
                    p.REMARKS = "ตีกลับโดยระบบ"

                    If iEng.SaveInsideSend(uPara.UserName, p, trans) = True Then
                        Dim dLnq As New Linq.TABLE.DocumentRegisterLinq
                        dLnq.GetDataByPK(dr("id"), trans.Trans)

                        dLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                        dLnq.ORGANIZATION_ID_PROCESS = p.ORGANIZATION_ID_SEND
                        dLnq.ORGANIZATION_NAME_PROCESS = p.ORGANIZATION_NAME_SEND
                        dLnq.ORGANIZATION_ABBNAME_PROCESS = p.ORGANIZATION_APPNAME_SEND

                        Dim ofEng As New Engine.Master.OfficerEng
                        Dim ofPara As New Para.TABLE.OfficerPara
                        ofPara = ofEng.GetOfficerParaByUserName(p.SENDER_OFFICER_USERNAME)
                        dLnq.OFFICER_ID_POSSESS = ofPara.ID
                        dLnq.OFFICER_NAME_POSSESS = p.SENDER_OFFICER_FULLNAME

                        dLnq.ORGANIZATION_ID_OWNER = p.ORGANIZATION_ID_SEND
                        dLnq.ORGANIZATION_NAME = p.ORGANIZATION_NAME_SEND
                        dLnq.ORGANIZATION_APPNAME = p.ORGANIZATION_APPNAME_SEND
                        dLnq.OFFICER_ID_APPROVE = ofPara.ID
                        dLnq.OFFICER_NAME = p.SENDER_OFFICER_FULLNAME
                        ofEng = Nothing
                        ofPara = Nothing

                        If dLnq.UpdateByPK(uPara.UserName, trans.Trans) = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    Else
                        trans.RollbackTransaction()
                    End If
                    p = Nothing
                Else
                    trans.RollbackTransaction()
                End If
                iEng = Nothing
            Next
        End If
        dt.Dispose()
        eng = Nothing
        uPara = Nothing
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row

            Dim lblAttach As Label = CType(grv.FindControl("lblAttach"), Label)
            Dim DocQty As Integer = grv.Cells(12).Text
            If DocQty > 0 Then
                lblAttach.Text = DocQty.ToString
                lblAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "')")
                lblAttach.Attributes.Add("style", "cursor:pointer;")
                lblAttach.ToolTip = "เอกสารแนบ (" & DocQty.ToString & ")"
            Else
                lblAttach.Text = "<img src='../Images/NewDoc.jpg' width='16px' style='cursor:pointer;' onClick=""OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "');"" alt='เพิ่มเอกสารแนบ' title='เพิ่มเอกสารแนบ' />"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(0).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

End Class
