Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.Common.Utilities.SqlDB
Imports Linq.Common.Utilities
Imports Para.Common.Utilities


Partial Class WebApp_frmDocInsideReceive
    Inherits System.Web.UI.Page
    Public dtimp As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If Me.IsPostBack = False Then
            SetGridview(uPara)
        End If
        uPara = Nothing
    End Sub

    Protected Sub cb1_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim chkH As CheckBox = sender
            Dim grv As GridViewRow = chkH.Parent.Parent
            Dim gv As GridView = grv.Parent.Parent
            For i As Integer = 0 To gv.Rows.Count - 1
                Dim chk As CheckBox = gv.Rows(i).Cells(0).Controls(1)
                chk.Checked = chkH.Checked
            Next
        Catch ex As Exception
        End Try

    End Sub
    Protected Sub btnReceiveInside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveInside1.Click
        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
            Config.SaveTransLog("คลิกปุ่มลงรับภายในสำนักงาน เลขที่หนังสือ " & SelectedDoc.SelectedBookNo)
            btnReceiveInside1.ShowPop(SelectedDoc.SelectedRowID)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการลงรับภายในสำนักงาน", Me)
        End If
    End Sub

    Protected Sub btnReceiveInside1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveInside1.YesClick
        Dim uPara As New Para.Common.UserProfilePara
        uPara = Config.GetLogOnUser
        If uPara.UserName.Trim <> "" Then
            Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
            If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
                InsideReceive(uPara)
                Config.SaveTransLog("frmDocInsideReceive.aspx ลงรับภายในสำนักงานเลขที่หนังสือ :" & SelectedDoc.SelectedBookNo, uPara.LOGIN_HISTORY_ID)
            Else
                Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการลงรับภายในสำนักงาน", Me)
            End If
        Else

        End If
    End Sub

    Private Sub InsideReceive(ByVal uPara As Para.Common.UserProfilePara)
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        For Each r In gridcontrol.Rows
            Dim chkb As CheckBox
            chkb = CType(r.Cells(0).FindControl("cb2"), CheckBox)
            Dim lblBookNo As LinkButton = DirectCast(r.FindControl("likBookNo"), LinkButton)
            If chkb.Checked Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_INT_RECEIVER_ID") = r.Cells(9).Text
                dr("DOCUMENT_REGISTER_ID") = r.Cells(10).Text
                dt.Rows.Add(dr)
            End If
        Next
        If dt.Rows.Count > 0 Then
            If uPara.UserName.Trim <> "" Then
                Dim eng As New Engine.Document.SearchDocumentENG
                Dim ret As Boolean = eng.ReceiveInternal(uPara, dt)
                If ret = True Then
                    SetGridview(uPara)
                    Master.getNewDoc(uPara)
                    Master.getCount(uPara)
                End If
                eng = Nothing
            Else
                Master.Logout()
            End If

            dt = Nothing
            uPara = Nothing
        End If
    End Sub

    Protected Sub btnRecieveAndSendIn1_AfterSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnRecieveAndSendIn1.AfterSendInside
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        SetGridview(uPara)
        'uPara = Nothing
    End Sub

    Protected Sub btnRecieveAndSendIn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecieveAndSendIn1.Click
        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
            Config.SaveTransLog("คลิกปุ่มลงรับพร้อมส่งภายใน เลขที่หนังสือ " & SelectedDoc.SelectedBookNo)
            btnRecieveAndSendIn1.ShowPop(SelectedDoc)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งภายในสำนักงาน", Me)
        End If
        SelectedDoc = Nothing
    End Sub

    Protected Sub btnRecieveAndSendIn1_ConfirmSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnRecieveAndSendIn1.ConfirmSendInside
        'Dim uPara As New Para.Common.UserProfilePara
        'uPara = Config.GetLogOnUser
        If uPara.UserName.Trim <> "" Then
            Dim p As Para.Document.SendInternalSelectedPara
            p = GetSelectedDocNo()
            Config.SaveTransLog("ลงรับพร้อมส่งภายในสำนักงาน เลขที่หนังสือ :" & p.SelectedBookNo, uPara.LOGIN_HISTORY_ID)
            p = Nothing

            InsideReceive(uPara)
        End If
        'uPara = Nothing
    End Sub

    Private Function GetSelectedDocNo() As Para.Document.SendInternalSelectedPara
        Dim para As New Para.Document.SendInternalSelectedPara
        para.SelectedRowID.Columns.Add("DOCUMENT_REGISTER_ID")
        para.SelectedRowID.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In gridcontrol.Rows
            Dim cb As CheckBox = grv.Cells(1).FindControl("cb2")
            Dim likBookNo As LinkButton = grv.Cells(3).FindControl("likBookNo")
            If cb.Checked = True Then
                If retNO = "" Then
                    retNO = likBookNo.Text
                Else
                    retNO += ", " & likBookNo.Text
                End If
                Dim dr As DataRow = para.SelectedRowID.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(10).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(9).Text
                para.SelectedRowID.Rows.Add(dr)
            End If
        Next
        If retNO <> "" Then
            para.SelectedBookNo = retNO
        End If

        Return para
    End Function


    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Function SearchData(ByVal uPara As Para.Common.UserProfilePara) As DataTable
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = " and ir.organization_id_receive = '" & uPara.ORG_DATA.ID & "'  "
        If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Constant.RoleID.RoleAdministration) = False Then
            whText += " and isnull(ir.receiver_officer_username,'" & uPara.UserName & "') = '" & uPara.UserName & "'"
        End If
        If txtBookno.Text <> "" Then
            whText += " and dr.book_no like '%" & txtBookno.Text.Trim & "%' "
        End If
        If txtReqNo.Text <> "" Then
            whText += " and dr.request_no like '%" & txtReqNo.Text.Trim & "%' "
        End If
        If txtCompanyDocNo.Text <> "" Then
            whText += " and dr.company_doc_no like '%" & txtCompanyDocNo.Text.Trim & "%' "
        End If
        If txtTitleName.Text <> "" Then
            whText += " and dr.title_name like '%" & txtTitleName.Text & "%' "
        End If
        If txtCompanyName.Text <> "" Then
            whText += " and c.thaiName like '%" & txtCompanyName.Text & "%' "
        End If
        If txtSendDateFrom.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),ir.send_date,112)>='" & txtSendDateFrom.GetDateCondition & "'"
        End If
        If txtSendDateTo.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),ir.send_date,112)<='" & txtSendDateTo.GetDateCondition & "'"
        End If
        If txtRegDateFrom.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112)>='" & txtRegDateFrom.GetDateCondition & "'"
        End If
        If txtRegDateTo.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112)<='" & txtRegDateTo.GetDateCondition & "'"
        End If
        Dim dt As New DataTable
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentReceive(whText)
        eng = Nothing
        uPara = Nothing

        Return dt
    End Function

    Private Sub SetGridview(ByVal uPara As Para.Common.UserProfilePara)
        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            gridcontrol.PageSize = 20
            pcTop.Visible = True
            pcTop.SetMainGridView(gridcontrol)
            gridcontrol.DataSource = dt
            gridcontrol.DataBind()
            pcTop.Update(dt.Rows.Count)

            btnReceiveInside1.Visible = True
            btnRecieveAndSendIn1.Visible = True
            btnCloseJob1.Visible = True
            btnRecieveAndSendOut1.Visible = True

            If dt.Rows.Count = 1 Then
                'กรณีค้นหาแล้วเจอ 1 รายการ ให้ติ๊กถูกให้เลย
                For Each grv As GridViewRow In gridcontrol.Rows
                    Dim cb As CheckBox = grv.Cells(1).FindControl("cb2")
                    cb.Checked = True
                Next
            End If
        Else
            gridcontrol.DataSource = Nothing
            gridcontrol.DataBind()
            pcTop.Visible = False
            btnReceiveInside1.Visible = False
            btnRecieveAndSendIn1.Visible = False
            btnCloseJob1.Visible = False
            btnRecieveAndSendOut1.Visible = False
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        SetGridview(uPara)
        uPara = Nothing
    End Sub
    
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookno.Text = ""
        txtSendDateFrom.DateValue = New Date(1, 1, 1)
        txtSendDateTo.DateValue = New Date(1, 1, 1)
        txtReqNo.Text = ""
        txtRegDateFrom.DateValue = New Date(1, 1, 1)
        txtRegDateTo.DateValue = New Date(1, 1, 1)
        txtCompanyDocNo.Text = ""
        txtCompanyName.Text = ""
        txtTitleName.Text = ""

        gridcontrol.DataSource = Nothing
        gridcontrol.DataBind()
    End Sub

   
    Protected Sub gridcontrol_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridcontrol.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'If Config.GetLogOnUser.UserName.Trim <> "" Then
            Dim grv As GridViewRow = e.Row
            Dim lblAttach As Label = CType(grv.FindControl("lblAttach"), Label)

            Dim DocQty As Integer = grv.Cells(11).Text
            If DocQty > 0 Then
                lblAttach.Text = grv.Cells(11).Text
                lblAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(10).Text & ",'" & btnSearch.ClientID & "'); return false;")
                lblAttach.Attributes.Add("style", "cursor:pointer;")
                lblAttach.ToolTip = "เอกสารแนบ (" & grv.Cells(11).Text & ")"
            Else
                lblAttach.Text = "<img src='../Images/NewDoc.jpg' width='16px' style='cursor:pointer;' onClick=""OpenAttachFileWindow(" & grv.Cells(10).Text & ",'" & btnSearch.ClientID & "'); return false;"" alt='เพิ่มเอกสารแนบ' title='เพิ่มเอกสารแนบ' />"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(10).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
            'End If
        End If
    End Sub

#Region "ส่งออกภายนอกสำนักงาน"
    Protected Sub btnRecieveAndSendOut1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecieveAndSendOut1.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
            If SelectedDoc.SelectedRowID.Rows.Count = 1 Then
                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("bookno")
                dt.Columns.Add("book_title")
                dt.Columns.Add("dates_app", GetType(Date))
                dt.Columns.Add("company_name")
                dt.Columns.Add("company_id")

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                For Each TmpDr As DataRow In SelectedDoc.SelectedRowID.Rows
                    Dim dPara As New Para.TABLE.DocumentRegisterPara
                    Dim eng As New Engine.Document.DocumentRegisterENG
                    dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = dPara.ID
                    dr("bookno") = dPara.BOOK_NO
                    dr("book_title") = dPara.TITLE_NAME
                    dr("dates_app") = dPara.REGISTER_DATE.Value
                    dr("company_name") = dPara.COMPANY_NAME
                    dr("company_id") = dPara.COMPANY_ID
                    dt.Rows.Add(dr)
                Next
                trans.CommitTransaction()
                Config.SaveTransLog("frmDocInsideReceive.aspx คลิกปุ่มลงรับพร้อมส่งออกภายนอกสำนักงาน เลขที่หนังสือ " & SelectedDoc.SelectedBookNo)

                btnRecieveAndSendOut1.ShowPop(dt, uPara)
                dt.Dispose()
            Else
                Config.SetAlert("ส่งออกนอกสำนักงานได้ครั้งละ 1 เรื่อง", Me)
            End If
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งออกภายนอกสำนักงาน", Me)
        End If
        SelectedDoc = Nothing
        uPara = Nothing
    End Sub

    Protected Sub btnRecieveAndSendOut1_AfterExportClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnRecieveAndSendOut1.AfterExportClick
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")
        dt.Columns.Add("DOCUMENT_REGISTER_ID")

        For Each r In gridcontrol.Rows
            Dim chkb As CheckBox
            chkb = CType(r.Cells(0).FindControl("cb2"), CheckBox)
            If chkb.Checked Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_INT_RECEIVER_ID") = r.Cells(9).Text
                dr("DOCUMENT_REGISTER_ID") = r.Cells(10).Text
                dt.Rows.Add(dr)
            End If
        Next
        If dt.Rows.Count > 0 Then
            Dim eng As New Engine.Document.SearchDocumentENG
            Dim ret As Boolean = eng.ReceiveIncome(uPara, dt)

            If ret = True Then
                'SetGridview(True)
                If uPara.LOGIN_HISTORY_ID > 0 Then
                    Master.getNewDoc(uPara)
                    Master.getCount(uPara)
                End If
            End If
            eng = Nothing
        End If
        dt.Dispose()
    End Sub

    'Protected Sub btnRecieveAndSendOut1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecieveAndSendOut1.OkClick
    '    SetGridview(True)
    'End Sub
#End Region

    
    Private Function GetSelectedDocItem() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In gridcontrol.Rows
            Dim cb As CheckBox = grv.Cells(0).FindControl("cb2")
            If cb.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(10).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(9).Text
                dt.Rows.Add(dr)
            End If
        Next

        Return dt
    End Function

    Protected Sub btnCloseJob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.Click
        Dim SelectedDoc As DataTable = GetSelectedDocItem()
        If SelectedDoc.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("book_no")
            dt.Columns.Add("book_title")

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim TmpBookNo As String = ""
            For Each TmpDr As DataRow In SelectedDoc.Rows
                Dim dPara As New Para.TABLE.DocumentRegisterPara
                Dim eng As New Engine.Document.DocumentRegisterENG
                dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)

                Dim dr As DataRow = dt.NewRow
                dr("id") = dPara.ID
                dr("book_no") = dPara.BOOK_NO
                dr("book_title") = dPara.TITLE_NAME
                dt.Rows.Add(dr)

                If TmpBookNo = "" Then
                    TmpBookNo = dPara.BOOK_NO
                Else
                    TmpBookNo += ", " & dPara.BOOK_NO
                End If
                dPara = Nothing
                eng = Nothing
            Next
            trans.CommitTransaction()
            Config.SaveTransLog("frmDocInsideReceive.aspx คลิกปุ่มลงรับพร้อมจบงาน เลขที่หนังสือ" & TmpBookNo)
            btnCloseJob1.SetConfirmList(dt)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการจบงาน", Me)
        End If
    End Sub

    Protected Sub btnCloseJob1_OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.OKClick
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridview(uPara)
        'uPara = Nothing
    End Sub

    Protected Sub btnRecieveAndSendOut1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecieveAndSendOut1.OkClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridview(uPara)
        uPara = Nothing
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            gridcontrol.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(gridcontrol)
            gridcontrol.DataSource = dt
            gridcontrol.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As System.Data.DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.YesClick
        Dim cDt As DataTable = GetSelectedDocItem()
        If cDt.Rows.Count > 0 Then
            Dim ret As Boolean = False
            For Each cDr As DataRow In cDt.Rows
                ret = SaveInsideSendCloseJob(cDr("DOCUMENT_INT_RECEIVER_ID"), trans, uPara)
                If ret = False Then
                    Exit For
                End If
            Next
            If ret = True Then
                btnCloseJob1.CloseJobSuccess = "Y"
            End If
        End If
        cDt.Dispose()
    End Sub


    Private Function SaveInsideSendCloseJob(ByVal DocIntID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) As Boolean
        Dim ret As Boolean = False
        If uPara.UserName.Trim <> "" Then
            Dim DataNow As DateTime = DateTime.Now
            Dim para As New Para.TABLE.DocumentIntReceiverPara
            Dim lnq As New Linq.TABLE.DocumentIntReceiverLinq
            para = lnq.GetParameter(DocIntID, trans.Trans)
            If para.ID <> 0 Then
                para.RECEIVE_DATE = DataNow
                para.RECEIVE_STATUS_ID = Constant.DocumentIntReceiver.ReceiveStatusID.Received
                para.ORGANIZATION_ID_RECEIVE = uPara.ORG_DATA.ID
                para.ORGANIZATION_NAME_RECEIVE = uPara.ORG_DATA.ORG_NAME
                para.ORGANIZATION_APPNAME_RECEIVE = uPara.ORG_DATA.NAME_RECEIVE
                para.RECEIVER_OFFICER_USERNAME = uPara.UserName
                para.RECEIVER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName

                Dim eng As New Engine.Document.DocumentRegisterENG
                ret = eng.SaveInsideSend(uPara.UserName, para, trans)
                If ret = False Then
                    Config.SetAlert(eng.ErrorMessage, Me)
                End If
                eng = Nothing
            End If
            para = Nothing
            uPara = Nothing
        Else
            Config.SetAlert("เกิดความผิดพลาดระหว่างการบันทึกข้อมูล ไม่สามารถจบงานได้ กรุณาติดต่อผู้ดูแลระบบ", Me)
        End If
        
        Return ret
    End Function

    Protected Sub gridcontrol_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridcontrol.Sorting
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            gridcontrol.PageIndex = pcTop.SelectPageIndex
            Config.GridViewSorting(gridcontrol, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(gridcontrol)
            gridcontrol.DataSource = dt
            gridcontrol.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub
End Class
