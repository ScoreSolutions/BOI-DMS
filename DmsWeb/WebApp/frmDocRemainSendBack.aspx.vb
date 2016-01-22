Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmDocRemainSendBack
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If Me.IsPostBack = False Then
            SetGridView(uPara)
        End If
        uPara = Nothing
    End Sub

    Private Function SearchData(ByVal uPara As Para.Common.UserProfilePara) As DataTable
        Dim dt As New DataTable
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = "1=1"
        'งานตีกลับโดยระบบ
        whText += " and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem & "'"

        If txtBookno.Text.Trim <> "" Then
            whText += " and dr.book_no like '%" & txtBookno.Text.Trim & "%'"
        End If
        If txtRegDateFrom.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegDateFrom.GetDateCondition & "'"
        End If
        If txtRegDateTo.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegDateTo.GetDateCondition & "'"
        End If
        If txtReqNo.Text.Trim <> "" Then
            whText += " and dr.request_no like '%" & txtReqNo.Text.Trim & "%'"
        End If
        If txtTitleName.Text.Trim <> "" Then
            whText += " and dr.title_name like '%" & txtTitleName.Text.Trim & "%' "
        End If
        If txtCompanyDocNo.Text.Trim <> "" Then
            whText += " and dr.company_doc_no like '%" & txtCompanyDocNo.Text.Trim & "%'"
        End If
        If txtCompanyName.Text.Trim <> "" Then
            whText += " and dr.company_name like '%" & txtCompanyName.Text.Trim & "%' "
        End If
        If chkOutDirector.Checked = True Then
            'กรณีออกจากห้องผู้บริหาร
            Dim oEng As New Engine.Master.OfficerEng
            Dim oPara As New Para.TABLE.OfficerPara
            oPara = oEng.GetOfficerPara(uPara.ORG_DATA.DIRECTOR)
            whText += " and ir.sender_officer_username = '" & oPara.USERNAME & "'"
            oEng = Nothing
            oPara = Nothing
        End If
        If chkInDirector.Checked = True Then
            'กรณีเสนอผู้บริหาร
            Dim oEng As New Engine.Master.OfficerEng
            Dim oPara As New Para.TABLE.OfficerPara
            oPara = oEng.GetOfficerPara(uPara.ORG_DATA.DIRECTOR)
            whText += " and ir.receiver_officer_username = '" & oPara.USERNAME & "'"
            oEng = Nothing
            oPara = Nothing
        End If

        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentSend(whText, uPara, True)
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
            btnSendInside.Visible = True

            If dt.Rows.Count = 1 Then
                'กรณีค้นหาแล้วเจอ 1 รายการ ให้ติ๊กถูกให้เลย
                For Each grv As GridViewRow In GridView1.Rows
                    Dim cb As CheckBox = grv.Cells(1).FindControl("cb1")
                    cb.Checked = True
                Next
            End If
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
            btnSendInside.Visible = False
        End If
        dt.Dispose()
    End Sub

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Protected Sub btnSendInside_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside.Click
        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
            popSendInside1.SetDocRegisID(SelectedDoc.SelectedRowID)
            popSendInside1.SetBookNO(SelectedDoc.SelectedBookNo)
            If SelectedDoc.SelectedRowID.Rows.Count = 1 Then
                Dim Doc As New Para.TABLE.DocumentRegisterPara
                Dim dEng As New Engine.Document.DocumentRegisterENG
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Doc = dEng.GetDocumentPara(SelectedDoc.SelectedRowID.Rows(0)("DOCUMENT_REGISTER_ID"), trans)
                trans.CommitTransaction()
                popSendInside1.SetOnlyApproveID = Doc.OFFICER_ID_APPROVE
                popSendInside1.SetOnlyOrgID = Doc.ORGANIZATION_ID_OWNER
            End If
            Config.SaveTransLog("frmDocRemainSendBack.aspx คลิกปุ่มส่งภายในสำนักงาน เลขที่หนังสือ " & SelectedDoc.SelectedBookNo)
            popSendInside1.ShowPop()
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งภายในสำนักงาน", Me)
        End If
        SelectedDoc = Nothing
    End Sub

    Private Function SelectedDocNo() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = grv.Cells(1).FindControl("cb1")
            If cb.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(0).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(10).Text
                dt.Rows.Add(dr)
            End If
        Next

        Return dt
    End Function

    Private Function GetSelectedDocNo() As Para.Document.SendInternalSelectedPara
        Dim para As New Para.Document.SendInternalSelectedPara
        para.SelectedRowID.Columns.Add("DOCUMENT_REGISTER_ID")
        para.SelectedRowID.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = grv.Cells(1).FindControl("cb1")
            Dim likBookNo As LinkButton = grv.Cells(3).FindControl("likBookNo")
            If cb.Checked = True Then
                If retNO = "" Then
                    retNO = likBookNo.Text
                Else
                    retNO += ", " & likBookNo.Text
                End If
                Dim dr As DataRow = para.SelectedRowID.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(0).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(10).Text
                para.SelectedRowID.Rows.Add(dr)
            End If
        Next
        If retNO <> "" Then
            para.SelectedBookNo = retNO
        End If

        Return para
    End Function

    Protected Sub popSendInside1_AfterSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles popSendInside1.AfterSendInside
        Dim p As Para.Document.SendInternalSelectedPara
        p = GetSelectedDocNo()
        Config.SaveTransLog("frmDocRemainSendBack.aspx ส่งภายในสำนักงาน เลขที่หนังสือ :" & p.SelectedBookNo, uPara.LOGIN_HISTORY_ID)
        p = Nothing

        SetGridView(uPara)
    End Sub

    Private Sub ClearCheckBox()
        chkOutDirector.Checked = False
    End Sub

    Protected Sub txtBookno_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookno.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub txtReqNo_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReqNo.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub txtCompanyDocNo_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompanyDocNo.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridView(uPara)
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
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        txtBookno.Text = ""
        txtRegDateFrom.DateValue = Nothing
        txtRegDateTo.DateValue = Nothing
        txtReqNo.Text = ""
        txtTitleName.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyName.Text = ""
        chkOutDirector.Checked = True
        SetGridView(uPara)
        uPara = Nothing
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim grv As GridViewRow = e.Row
        '    Dim imgAttach As ImageButton = CType(grv.FindControl("imgAttach"), ImageButton)
        '    imgAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(0).Text & ")")
        '    imgAttach.ToolTip = "เอกสารแนบ (" & grv.Cells(11).Text & ")"
        'End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim lblAttach As Label = CType(grv.FindControl("lblAttach"), Label)

            Dim DocQty As Integer = grv.Cells(11).Text
            If DocQty > 0 Then
                lblAttach.Text = grv.Cells(11).Text
                lblAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "')")
                lblAttach.Attributes.Add("style", "cursor:pointer;")
                lblAttach.ToolTip = "เอกสารแนบ (" & grv.Cells(11).Text & ")"
            Else
                lblAttach.Text = "<img src='../Images/NewDoc.jpg' width='16px' style='cursor:pointer;' onClick=""OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "');"" alt='เพิ่มเอกสารแนบ' title='เพิ่มเอกสารแนบ' />"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(0).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

#Region "ส่งหนังสือเวียน"
    Protected Sub btnSendCircle1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendCircle1.Click
        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectedDoc.SelectedRowID.Rows.Count > 0 Then
            If SelectedDoc.SelectedRowID.Rows.Count = 1 Then
                btnSendCircle1.SetShowPop()
                Config.SaveTransLog("frmDocRemainSendBack.aspx คลิกปุ่มส่งหนังสือเวียน เลขที่หนังสือ " & SelectedDoc.SelectedBookNo)
            Else
                Config.SetAlert("ส่งหนังสือเวียนได้ทีละ 1 เรื่อง", Me)
            End If
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งหนังสือเวียน", Me)
        End If
        SelectedDoc = Nothing
    End Sub

    Protected Sub btnSendCircle1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendCircle1.OkClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Config.SaveTransLog("frmDocRemainSendBack.aspx คลิกปุ่มตกลง")
        SetGridView(uPara)
        uPara = Nothing
    End Sub

    Protected Sub btnSendCircle1_SendClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal SelectOrgDT As System.Data.DataTable) Handles btnSendCircle1.SendClick
        Dim sePara As New Para.Document.SendCirclePara
        sePara.SEND_LIST = New DataTable
        sePara.SEND_LIST.Columns.Add("book_no")
        sePara.SEND_LIST.Columns.Add("OrgNameReceive")

        Dim _err As String = ""

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim ret As Boolean = False
        Dim SelectedDoc As Para.Document.SendInternalSelectedPara = GetSelectedDocNo()
        If SelectOrgDT.Rows.Count > 0 Then
            Dim eng As New Engine.Document.DocumentRegisterENG
            Dim bPara As New Para.TABLE.DocumentRegisterPara
            bPara = eng.GetDocumentPara(SelectedDoc.SelectedRowID.Rows(0)("DOCUMENT_REGISTER_ID"), trans)
            sePara.BOOK_NO = bPara.BOOK_NO

            For Each dr As DataRow In SelectOrgDT.Rows
                If eng.ChkDupByBookNo(bPara.BOOK_NO & "/" & dr("OrgAbbNameReceive"), 0) = False Then
                    Dim nPara As New Para.TABLE.DocumentRegisterPara
                    nPara.BOOK_NO = bPara.BOOK_NO & "/" & dr("OrgAbbNameReceive")
                    nPara.REQUEST_NO = bPara.REQUEST_NO
                    nPara.GROUP_TITLE_ID = bPara.GROUP_TITLE_ID
                    nPara.TITLE_NAME = bPara.TITLE_NAME
                    nPara.REGISTER_DATE = bPara.REGISTER_DATE
                    nPara.EXPECT_FINISH_DATE = bPara.EXPECT_FINISH_DATE
                    nPara.DOC_SECRET_ID = bPara.DOC_SECRET_ID
                    nPara.DOC_SPEED_ID = bPara.DOC_SPEED_ID
                    nPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome

                    nPara.ORGANIZATION_ID_OWNER = bPara.ORGANIZATION_ID_OWNER
                    nPara.ORGANIZATION_NAME = bPara.ORGANIZATION_NAME
                    nPara.ORGANIZATION_APPNAME = bPara.ORGANIZATION_APPNAME

                    nPara.ORGANIZATION_ID_PROCESS = bPara.ORGANIZATION_ID_PROCESS
                    nPara.ORGANIZATION_NAME_PROCESS = bPara.ORGANIZATION_NAME_PROCESS
                    nPara.ORGANIZATION_ABBNAME_PROCESS = bPara.ORGANIZATION_ABBNAME_PROCESS

                    nPara.OFFICER_ID_APPROVE = bPara.OFFICER_ID_APPROVE
                    nPara.OFFICER_NAME = bPara.OFFICER_NAME
                    nPara.OFFICER_ORGANIZATION_ID = bPara.OFFICER_ORGANIZATION_ID
                    nPara.OFFICER_ID_POSSESS = bPara.OFFICER_ID_POSSESS
                    nPara.OFFICER_NAME_POSSESS = bPara.OFFICER_NAME_POSSESS
                    nPara.ADMINISTRATION_TYPE = bPara.ADMINISTRATION_TYPE
                    nPara.REMARKS = bPara.REMARKS

                    nPara.COMPANY_ID = bPara.COMPANY_ID
                    nPara.COMPANY_NAME = bPara.COMPANY_NAME
                    nPara.COMPANY_DOC_NO = bPara.COMPANY_DOC_NO
                    nPara.COMPANY_DOC_DATE = bPara.COMPANY_DOC_DATE
                    nPara.COMPANY_SIGN = bPara.COMPANY_SIGN
                    nPara.COMPANY_SIGN_DATE = bPara.COMPANY_SIGN_DATE
                    nPara.BUSINESS_TYPE_ID = bPara.BUSINESS_TYPE_ID

                    nPara.USERNAME_REGISTER = bPara.USERNAME_REGISTER
                    nPara.ORGANIZATION_ID_REGISTER = bPara.ORGANIZATION_ID_REGISTER
                    nPara.DOCUMENT_RECEIVE_TYPE = bPara.DOCUMENT_RECEIVE_TYPE
                    nPara.REF_DOCUMENT_REGISTER_ID = bPara.ID
                    nPara.COMPANY_CERT_NO = bPara.COMPANY_CERT_NO
                    nPara.COMPANY_NOTIFY_NO = bPara.COMPANY_NOTIFY_NO
                    nPara.ELECTRONIC_DOC_ID = bPara.ELECTRONIC_DOC_ID
                    nPara.REF_TH_EGIF_DOC_INBOUND_ID = bPara.REF_TH_EGIF_DOC_INBOUND_ID

                    Dim DocRegisID As Long = eng.SaveDocumentRegister(uPara.UserName, nPara, Nothing, 0, trans)
                    If DocRegisID > 0 Then
                        ret = True
                        Dim iPara As New Para.TABLE.DocumentIntReceiverPara
                        iPara.DOCUMENT_REGISTER_ID = DocRegisID
                        iPara.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                        iPara.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
                        iPara.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE
                        iPara.SEND_DATE = DateTime.Now
                        iPara.SENDER_OFFICER_USERNAME = uPara.UserName
                        iPara.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                        iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive
                        iPara.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(dr("OrgNameReceiveID"))
                        iPara.ORGANIZATION_NAME_RECEIVE = dr("OrgNameReceive")
                        iPara.ORGANIZATION_APPNAME_RECEIVE = dr("OrgAbbNameReceive")

                        Dim sEng As New Engine.Master.OfficerEng
                        Dim sPara As Para.TABLE.OfficerPara = sEng.GetOfficerPara(Convert.ToInt64(dr("StaffNameReceiveID")))
                        iPara.RECEIVER_OFFICER_USERNAME = sPara.USERNAME
                        iPara.RECEIVER_OFFICER_FULLNAME = sPara.FIRST_NAME & " " & sPara.LAST_NAME
                        iPara.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(dr("PurposeID"))
                        iPara.RECEIVE_TYPE_ID = Convert.ToInt64(dr("PurposeID"))
                        iPara.REMARKS = dr("remark_receive")

                        If iPara.ORGANIZATION_ID_RECEIVE = iPara.ORGANIZATION_ID_SEND Then
                            'กรณีส่งหนังสือเวียน ถ้าส่งเวียนหาหน่วยงานตัวเอง ก็ให้คนที่ส่งนั่นแหละเป็นผู้รับเองซะเลย
                            Dim rPara As New Para.TABLE.DocumentRegisterPara
                            rPara = eng.GetDocumentPara(DocRegisID, trans)
                            rPara.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                            rPara.ORGANIZATION_APPNAME = uPara.ORG_DATA.NAME_ABB
                            rPara.ORGANIZATION_ID_OWNER = uPara.ORG_DATA.ID
                            rPara.ORGANIZATION_NAME = uPara.ORG_DATA.ORG_NAME

                            rPara.ORGANIZATION_ID_PROCESS = uPara.ORG_DATA.ID
                            rPara.ORGANIZATION_NAME_PROCESS = uPara.ORG_DATA.ORG_NAME
                            rPara.ORGANIZATION_ABBNAME_PROCESS = uPara.ORG_DATA.NAME_ABB
                            rPara.OFFICER_ID_POSSESS = uPara.OFFICER_DATA.ID
                            rPara.OFFICER_NAME_POSSESS = uPara.FirstName & " " & uPara.LastName
                            ret = eng.SaveDocumentRegister(uPara.UserName, rPara, Nothing, "0", trans)
                            If ret = True Then
                                iPara.RECEIVE_DATE = iPara.SEND_DATE
                                iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                                iPara.RECEIVER_OFFICER_USERNAME = uPara.UserName
                                iPara.RECEIVER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                            End If
                            rPara = Nothing
                        End If
                        If ret = True Then
                            ret = eng.SaveInsideSend(uPara.UserName, iPara, trans)
                            Config.SaveTransLog("frmDocRemainSendBack.aspx ส่งหนังสือเวียนต้นเรื่อง " & bPara.BOOK_NO & " เลขที่หนังสือ :" & nPara.BOOK_NO)
                        Else
                            ret = False
                            _err = eng.ErrorMessage
                            Exit For
                        End If

                        sEng = Nothing
                        sPara = Nothing
                        iPara = Nothing
                    Else
                        ret = False
                        _err = eng.ErrorMessage
                        Exit For
                    End If

                    If ret = False Then
                        _err = eng.ErrorMessage
                        nPara = Nothing
                        Exit For
                    Else
                        Dim seDr As DataRow = sePara.SEND_LIST.NewRow
                        seDr("book_no") = nPara.BOOK_NO
                        seDr("OrgNameReceive") = dr("OrgNameReceive").ToString
                        sePara.SEND_LIST.Rows.Add(seDr)
                        nPara = Nothing
                    End If
                Else
                    'กรณีส่งหนังสือเวียนซ้ำ
                    Dim seDr As DataRow = sePara.SEND_LIST.NewRow
                    seDr("book_no") = bPara.BOOK_NO & "/" & dr("OrgAbbNameReceive") & " <font color='red'>(ส่งซ้ำ)</font>"
                    seDr("OrgNameReceive") = dr("OrgNameReceive").ToString
                    sePara.SEND_LIST.Rows.Add(seDr)
                    ret = True
                    Config.SaveTransLog("frmDocRemainSendBack.aspx ส่งหนังสือเวียนซ้ำต้นเรื่อง " & bPara.BOOK_NO & " เลขที่หนังสือ :" & bPara.BOOK_NO & "/" & dr("OrgAbbNameReceive"))
                End If
            Next
            bPara = Nothing
            eng = Nothing
        End If

        If ret = True Then
            trans.CommitTransaction()
            btnSendCircle1.SetSendComplete(sePara)
        Else
            trans.RollbackTransaction()
            Config.SetAlert(_err, Me)
        End If

        uPara = Nothing
        SelectedDoc = Nothing
    End Sub

    'Private Function GetDocCirclePara(ByVal DocRegisID As Long) As Para.Document.SendCirclePara
    '    Dim trans As New Linq.Common.Utilities.TransactionDB
    '    trans.CreateTransaction()
    '    Dim eng As New Engine.Document.DocumentRegisterENG

    '    Dim para As New Para.Document.SendCirclePara
    '    para.SEND_LIST = New DataTable
    '    para.SEND_LIST = eng.GetDocumentCircleListByRefID(Convert.ToInt64(DocRegisID), trans)
    '    para.BOOK_NO = eng.GetDocumentPara(Convert.ToInt64(DocRegisID), trans).BOOK_NO
    '    trans.CommitTransaction()
    '    eng = Nothing
    '    Return para
    'End Function
#End Region
#Region "จบงาน"
    Protected Sub btnCloseJob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.Click
        Dim SelectedDoc As DataTable = SelectedDocNo()
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
            Next
            trans.CommitTransaction()
            Config.SaveTransLog("frmDocRemainSendBack.aspx คลิกปุ่มจบงาน เลขที่หนังสือ " & TmpBookNo)
            btnCloseJob1.SetConfirmList(dt)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการจบงาน", Me)
        End If
    End Sub

    Protected Sub btnCloseJob1_OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.OKClick
        SetGridView(uPara)
    End Sub
    Protected Sub btnCloseJob1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As System.Data.DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.YesClick
        btnCloseJob1.CloseJobSuccess = "Y"
    End Sub
#End Region

#Region "ส่งออกนอกสำนักงาน"
    Protected Sub btnSendOutside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim SelectedDoc As DataTable = SelectedDocNo()
        If SelectedDoc.Rows.Count > 0 Then
            If SelectedDoc.Rows.Count = 1 Then
                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("bookno")
                dt.Columns.Add("book_title")
                dt.Columns.Add("dates_app", GetType(Date))
                dt.Columns.Add("company_name")
                dt.Columns.Add("company_id")

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim TmpBookNo As String = ""
                For Each TmpDr As DataRow In SelectedDoc.Rows
                    Dim dPara As New Para.TABLE.DocumentRegisterPara
                    Dim eng As New Engine.Document.DocumentRegisterENG
                    dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = dPara.ID
                    dr("bookno") = dPara.BOOK_NO
                    dr("book_title") = dPara.TITLE_NAME
                    dr("dates_app") = DateTime.Now
                    dr("company_name") = dPara.COMPANY_NAME
                    dr("company_id") = dPara.ID
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
                Config.SaveTransLog("frmDocRemainSendBack.aspx คลิกปุ่มส่งออกนอกสำนักงาน เลขที่หนังสือ " & TmpBookNo)
                btnSendOutside1.ShowPop(dt, uPara)
            Else
                Config.SetAlert("ส่งออกนอกสำนักงานได้ครั้งละ 1 เรื่อง", Me)
            End If
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งออกภายนอกสำนักงาน", Me)
        End If
        SelectedDoc.Dispose()
        uPara = Nothing
    End Sub

    Protected Sub btnSendOutside1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.OkClick
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridView(uPara)
        uPara = Nothing
    End Sub
#End Region


End Class
