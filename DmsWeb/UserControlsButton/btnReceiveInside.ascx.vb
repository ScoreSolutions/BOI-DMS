Imports System.Data
Partial Class UserControls_Button_btnReceiveInside
    Inherits System.Web.UI.UserControl

    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event YesClick(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
    End Sub

    Public Sub ShowPop(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim tmp As String = ""
            For Each dr As DataRow In dt.Rows
                If tmp = "" Then
                    tmp = dr("DOCUMENT_REGISTER_ID").ToString
                Else
                    tmp += "," & dr("DOCUMENT_REGISTER_ID").ToString
                End If
            Next
            Dim uPara As New Para.Common.UserProfilePara
            uPara = Config.GetLogOnUser
            Dim whText As String = " and organization_id_receive = '" & uPara.ORG_DATA.ID & "'"
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                whText += " and isnull(ir.receiver_officer_username,'" & uPara.UserName & "') = '" & uPara.UserName & "'"
            End If
            'whText += " and ir.is_forward = 'N'"
            uPara = Nothing

            Dim eng As New Engine.Document.SearchDocumentENG
            Dim tmpDt As New DataTable
            tmpDt = eng.SearchDocumentReceive(whText & " and dr.id in (" & tmp & ")")
            If tmpDt.Rows.Count > 0 Then
                gvComfirmReceiveList.DataSource = tmpDt
                gvComfirmReceiveList.DataBind()
            Else
                gvComfirmReceiveList.DataSource = Nothing
                gvComfirmReceiveList.DataBind()
            End If
        Else
            gvComfirmReceiveList.DataSource = Nothing
            gvComfirmReceiveList.DataBind()
        End If
        zPopConfirm.Show()
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        RaiseEvent YesClick(sender, e)
    End Sub


    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Config.SaveTransLog("btnReceiveInside.ascx : คลิกปุ่มไม่ใช่", Config.GetLoginHistoryID)
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Config.SaveTransLog("btnReceiveInside.ascx : คลิกปุ่มปิด", Config.GetLoginHistoryID)
    End Sub
End Class
