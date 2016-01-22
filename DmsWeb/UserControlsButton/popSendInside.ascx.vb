Imports System.Data
Imports Engine.Master

Partial Class UserControls_Button_popSendInside
    Inherits System.Web.UI.UserControl

    Public Event ConfirmSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)
    Public Event AfterSendInside(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara)

    Private Sub SetPurpose()
        Dim eng As New Engine.Master.Objective
        cmbPurpose.SetItemList(eng.GetObjectList(), "objective_name", "id")
        eng = Nothing
    End Sub

    Public Sub ShowPop()
        SetPurpose()
        SetCmbOrgReceiveID()

        cmbStaffReceiveID.ClearCombo()
        cmbStaffReceiveID.SetItemList("เลือก", "0")

        cmbStaffApproveID.ClearCombo()
        cmbStaffApproveID.SetItemList("เลือก", "0")

        txtRemarks.Text = ""
        zPop.Show()
    End Sub

    'Private Sub SetOrgReceive()
    '    cdlReceiveOrgID.SelectedValue = ""
    'End Sub

    Public Sub SetBookNO(ByVal BookNo As String)
        lblBookNo.Text = BookNo
    End Sub
    Public WriteOnly Property SetOnlyApproveID() As String
        Set(ByVal value As String)
            txtOnlyApproveID.Text = value
        End Set
    End Property
    Public WriteOnly Property SetOnlyOrgID() As String
        Set(ByVal value As String)
            txtOnlyOrgID.Text = value
        End Set
    End Property

    Public Sub SetDocRegisID(ByVal SelectedID As DataTable)
        Dim DocID As String = ""
        If SelectedID.Rows.Count > 0 Then
            For Each dr As DataRow In SelectedID.Rows
                If DocID = "" Then
                    DocID = dr("DOCUMENT_REGISTER_ID")
                Else
                    DocID += "," & dr("DOCUMENT_REGISTER_ID")
                End If
            Next
        End If
        txtDocRegisID.Text = DocID
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If cmbOrgReceiveID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกหน่วยงานผู้รับ", Me.Page)
        ElseIf cmbStaffReceiveID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกชื่อผู้รับ", Me.Page)
        ElseIf cmbStaffApproveID.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกชื่อผู้พิจารณา", Me.Page)
        ElseIf cmbPurpose.SelectedValue = "0" Then
            ret = False
            Config.SetAlert("กรุณาเลือกวัตถุประสงค์", Me.Page)
        End If

        Return ret
    End Function
    Protected Sub btnSendInside2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendInside2.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If Valid() = True Then
            RaiseEvent ConfirmSendInside(sender, e, uPara)
            Dim sPara As New Para.Document.SendInternalPara
            sPara.ORG_RECEIVE_ID = cmbOrgReceiveID.SelectedValue
            Dim oPara As New Para.TABLE.OrganizationPara
            Dim oEng As New OrganizationEng
            oPara = oEng.GetOrgPara(sPara.ORG_RECEIVE_ID)

            sPara.OBJECTIVE_ID = cmbPurpose.SelectedValue
            sPara.ORG_ABB_NAME = oPara.NAME_RECEIVE    'ชื่อย่อหน่วยงานผู้รับ
            sPara.ORG_NAME = oPara.ORG_THAI_NAME
            sPara.REMARKS = txtRemarks.Text.Trim

            If cmbStaffReceiveID.SelectedValue <> "" Then
                sPara.STAFF_RECEIVE_ID = cmbStaffReceiveID.SelectedValue
                Dim stPara As New Para.TABLE.OfficerPara
                Dim sEng As New OfficerEng
                stPara = sEng.GetOfficerPara(sPara.STAFF_RECEIVE_ID)

                sPara.STAFF_FULLNAME = stPara.FIRST_NAME & " " & stPara.LAST_NAME
                sPara.STAFF_USERNAME = stPara.USERNAME

                stPara = Nothing
                sEng = Nothing
            End If
            If cmbStaffApproveID.SelectedValue <> "" Then
                sPara.STAFF_APPROVE_ID = cmbStaffApproveID.SelectedValue
                sPara.STAFF_APPROVE_FULLNAME = cmbStaffApproveID.SelectedText
            End If
            Dim eng As New Engine.Document.SearchDocumentENG
            If eng.SendInternal(txtDocRegisID.Text, sPara, uPara) = True Then
                RaiseEvent AfterSendInside(sender, e, uPara)
            Else
                Config.SetAlert(eng.ErrorMessage, Me.Page)
            End If
            sPara = Nothing
            eng = Nothing

        Else
            zPop.Show()
        End If
        uPara = Nothing
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        lblBookNo.Text = ""
        txtDocRegisID.Text = ""
        txtOnlyApproveID.Text = "0"
        txtOnlyOrgID.Text = "0"
    End Sub

    Private Sub SetDefaultStaffApproveID(ByVal uData As Para.Common.UserProfilePara)
        'Dim uData As New Para.Common.UserProfilePara
        'uData = Config.GetLogOnUser

        Dim eng As New Engine.Master.OrganizationEng
        Dim vDirectorID As String = eng.GetOrgPara(cmbOrgReceiveID.SelectedValue).DIRECTOR
        If uData.ORG_DATA.ID <> cmbOrgReceiveID.SelectedValue Then
            If cmbStaffApproveID.DataSource IsNot Nothing Then
                cmbStaffApproveID.SelectedValue = vDirectorID
            End If
        Else
            If txtOnlyApproveID.Text.Trim <> "0" Then
                If cmbStaffApproveID.DataSource IsNot Nothing Then
                    Dim dt As DataTable = cmbStaffApproveID.DataSource
                    dt.DefaultView.RowFilter = "id='" & txtOnlyApproveID.Text.Trim & "'"
                    If dt.DefaultView.Count = 0 Then
                        cmbStaffApproveID.SelectedValue = vDirectorID
                    Else
                        cmbStaffApproveID.SelectedValue = txtOnlyApproveID.Text
                    End If
                    dt.DefaultView.RowFilter = ""
                End If
            Else
                cmbStaffApproveID.SelectedValue = vDirectorID
            End If
        End If
        'uData = Nothing
        eng = Nothing
    End Sub

    Private Sub SetCmbOrgReceiveID()
        Dim eng As New Engine.Master.OrganizationEng
        Dim dt As New DataTable
        dt = eng.GetAllOrganizationTable()
        cmbOrgReceiveID.SetItemList(dt, "org_name", "id")
        dt.Dispose()
        eng = Nothing
    End Sub

    Private Sub SetCmbStaff(ByVal OrgID As Long)
        Dim eng As New Engine.Master.OrganizationEng
        Dim dt As New DataTable
        dt = eng.GetStaffByOrgID(OrgID)
        If dt.Rows.Count > 0 Then
            Dim oPara As New Para.TABLE.OrganizationPara
            oPara = eng.GetOrgPara(OrgID)
            If oPara.DIRECTOR > 0 Then
                dt.DefaultView.RowFilter = "id='" & oPara.DIRECTOR & "'"
                'ถ้าชื่อ ผอ. ไม่ได้อยู่ในหน่วยงานเดียวกัน
                If dt.DefaultView.Count = 0 Then
                    Dim sPara As New Para.TABLE.OfficerPara
                    Dim sEng As New Engine.Master.OfficerEng
                    sPara = sEng.GetOfficerPara(oPara.DIRECTOR)
                    If sPara.ID > 0 Then
                        Dim dr As DataRow = dt.NewRow
                        dr("id") = oPara.DIRECTOR
                        dr("staff_name") = sPara.FIRST_NAME & " " & sPara.LAST_NAME
                        dr("officer_level") = sPara.OFFICER_LEVEL
                        dt.Rows.Add(dr)

                        dt.DefaultView.RowFilter = ""
                        dt.DefaultView.Sort = "staff_name"
                        dt = dt.DefaultView.ToTable
                    End If
                    sPara = Nothing
                    sEng = Nothing
                End If
                dt.DefaultView.RowFilter = ""
            End If
            Dim rDt As New DataTable
            rDt = dt.Copy

            Dim pDt As New DataTable
            pDt = dt.Copy

            cmbStaffReceiveID.SetItemList(rDt, "staff_name", "id")
            cmbStaffApproveID.SetItemList(pDt, "staff_name", "id")


            Dim aDt As New DataTable
            aDt = eng.GetStaffAdmintrationByOrgID(OrgID)
            If aDt.Rows.Count > 0 Then
                cmbStaffReceiveID.SelectedValue = aDt.Rows(0)("id")
            End If
            aDt.Dispose()
            rDt.Dispose()
            pDt.Dispose()
        Else
            cmbStaffReceiveID.ClearCombo()
            cmbStaffReceiveID.SetItemList("เลือก", "0")

            cmbStaffApproveID.ClearCombo()
            cmbStaffApproveID.SetItemList("เลือก", "0")
        End If
        dt.Dispose()
        eng = Nothing
    End Sub

    Protected Sub cmbOrgReceiveID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrgReceiveID.SelectedIndexChanged
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        If cmbOrgReceiveID.SelectedValue <> "0" Then
            SetCmbStaff(cmbOrgReceiveID.SelectedValue)
            SetDefaultStaffApproveID(uPara)
        Else
            cmbOrgReceiveID.SelectedValue = "0"

            cmbStaffReceiveID.ClearCombo()
            cmbStaffReceiveID.SetItemList("เลือก", "0")

            cmbStaffApproveID.ClearCombo()
            cmbStaffApproveID.SetItemList("เลือก", "0")
        End If
        zPop.Show()
        uPara = Nothing
    End Sub
End Class
