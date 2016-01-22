
Partial Class WebApp_frmDocBookAddRoute
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.Title = ctlDocBookDetailShow1.PageTitle

            SetPurpose()
        End If
    End Sub

    Private Sub SetPurpose()
        Dim fnc As New Engine.Master.Objective
        cmbPurpose.SetItemList(fnc.GetAllObjectiveTable, "objective_name", "id")
        fnc = Nothing
    End Sub

    Private Function Valid() As Boolean

        If cmbSendOrgID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกหน่วยงานผู้ส่ง", Me, cmbSendOrgID.ClientID)
            Return False
        End If

        If cmbSendStaffID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกชื่อผู้ส่ง", Me, cmbSendStaffID.ClientID)
            Return False
        End If

        If cmbReceiveOrgID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกหน่วยงานผู้รับ", Me, cmbReceiveOrgID.ClientID)
            Return False
        End If

        If cmbReceiveStaffID.SelectedValue = "" Then
            Config.SetAlert("กรุณาเลือกชื่อผู้รับ", Me, cmbReceiveStaffID.ClientID)
            Return False
        End If

        If cmbPurpose.SelectedValue = "0" Then
            Config.SetAlert("กรุณาเลือกวัตถุประสงค์", Me, cmbPurpose.ClientID)
            Return False
        End If

        Return True
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Valid() = False Then
            Exit Sub
        End If

        Dim oEng As New Engine.Master.OrganizationEng
        Dim soPara As New Para.TABLE.OrganizationPara
        soPara = oEng.GetOrgPara(cmbSendOrgID.SelectedValue)

        Dim roPara As New Para.TABLE.OrganizationPara
        roPara = oEng.GetOrgPara(cmbReceiveOrgID.SelectedValue)

        Dim sEng As New Engine.Master.OfficerEng
        Dim ssPara As New Para.TABLE.OfficerPara
        ssPara = sEng.GetOfficerPara(cmbSendStaffID.SelectedValue)

        Dim rsPara As New Para.TABLE.OfficerPara
        rsPara = sEng.GetOfficerPara(cmbReceiveStaffID.SelectedValue)

        Dim iPara As New Para.TABLE.DocumentIntReceiverPara
        iPara.DOCUMENT_REGISTER_ID = Convert.ToInt64(ctlDocBookDetailShow1.DocID)
        iPara.ORGANIZATION_ID_SEND = soPara.ID
        iPara.ORGANIZATION_NAME_SEND = soPara.ORG_THAI_NAME
        iPara.ORGANIZATION_APPNAME_SEND = soPara.NAME_RECEIVE   'ชื่อย่อหน่วยงานผู้ส่ง
        iPara.SEND_DATE = DateTime.Now
        iPara.SENDER_OFFICER_USERNAME = ssPara.USERNAME
        iPara.SENDER_OFFICER_FULLNAME = ssPara.FIRST_NAME & " " & ssPara.LAST_NAME
        iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive
        iPara.ORGANIZATION_ID_RECEIVE = roPara.ID
        iPara.ORGANIZATION_NAME_RECEIVE = roPara.ORG_NAME
        iPara.ORGANIZATION_APPNAME_RECEIVE = roPara.NAME_ABB   'ชื่อย่อหน่วยงานผู้รับ
        iPara.RECEIVER_OFFICER_USERNAME = rsPara.USERNAME
        iPara.RECEIVER_OFFICER_FULLNAME = rsPara.FIRST_NAME & " " & rsPara.LAST_NAME
        iPara.RECEIVE_OBJECTIVE_ID = cmbPurpose.SelectedValue
        iPara.RECEIVE_TYPE_ID = cmbPurpose.SelectedValue
        iPara.REMARKS = txtMessage.Text.Trim

        If soPara.ID = roPara.ID Then
            'ถ้าผู้รับกับผู้ส่งอยู่หน่วยงานเดียวกัน
            iPara.RECEIVE_DATE = DateTime.Now
            iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
        End If


        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        Else
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim eng As New Engine.Document.DocumentRegisterENG
            Dim ret As Boolean = eng.SaveInsideSend(uPara.UserName, iPara, trans)
            If ret = True Then
                trans.CommitTransaction()
                ctlDocBookDetailShow1.SearchDocByBookNo(txtSearchBookNo.Text.Trim)
                ClearForm()
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                Dim lo As New Engine.Common.LogEng
                lo.SaveErrLog(uPara.UserName, "frmDocBookAddRoute_btnAdd_Click " & eng.ErrorMessage)
                lo = Nothing
            End If
        End If

        oEng = Nothing
        soPara = Nothing
        roPara = Nothing
        ssPara = Nothing
        rsPara = Nothing
    End Sub

    Private Sub ClearForm()
        cdlSendOrgID.SelectedValue = ""
        cdlReceiveOrgID.SelectedValue = ""
        cdlSendStaffID.SelectedValue = ""
        cdlReceiveStaffID.SelectedValue = ""
        cmbPurpose.SelectedValue = "0"
        txtMessage.Text = ""
    End Sub

    Protected Sub btnSearchDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDoc.Click
        ctlDocBookDetailShow1.SearchDocByBookNo(txtSearchBookNo.Text.Trim)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
