Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports Para.Common.Utilities.Constant

Partial Class UserControls_Button_btnSendInside
    Inherits System.Web.UI.UserControl

    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event YesSend(ByVal sender As Object, ByVal e As System.EventArgs, ByVal trans As Linq.Common.Utilities.TransactionDB)
    Public Event NoSend(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event YesClear(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event NoClear(ByVal sender As Object, ByVal e As System.EventArgs)

    Public WriteOnly Property NewRegisID() As String
        Set(ByVal value As String)
            txtNewID.Text = value
        End Set
    End Property

    Public Sub ShowPopupConfirm(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            gvComfirmSendList.DataSource = dt
            gvComfirmSendList.DataBind()
            zPopConfirm.Show()
        Else
            gvComfirmSendList.DataSource = Nothing
            gvComfirmSendList.DataBind()
        End If
    End Sub

    Private Sub SetConfirmList()
        Dim dt As New DataTable
        Dim eng As New Engine.Document.DocumentRegisterENG
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        dt = eng.GetDocumentListByRefID(Convert.ToInt64(txtNewID.Text), trans)
        trans.CommitTransaction()

        If dt.Rows.Count > 0 Then
            gvComfirmSendList.DataSource = dt
            gvComfirmSendList.DataBind()
        Else
            gvComfirmSendList.DataSource = Nothing
            gvComfirmSendList.DataBind()
        End If
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click
        'Dim Rdt As New DataTable
        'Rdt = DirectCast(Session(SessSendList), DataTable).Copy
        If gvComfirmSendList.Rows.Count > 0 Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            If trans.CreateTransaction() = True Then
                RaiseEvent YesSend(sender, e, trans)
                If txtNewID.Text.Trim <> "0" And txtNewID.Text.Trim <> "" Then
                    Dim dt As New DataTable
                    Dim eng As New Engine.Document.DocumentRegisterENG
                    If gvComfirmSendList.Rows.Count = 1 Then
                        dt = eng.GetDocumentListByRefID(Convert.ToInt64(txtNewID.Text), trans)
                    Else
                        dt = eng.GetDocumentCircleListByRefID(Convert.ToInt64(txtNewID.Text), trans)
                    End If

                    If dt.Rows.Count > 0 Then
                        gvConfirmList.DataSource = dt
                        gvConfirmList.DataBind()
                        dt = Nothing

                        Dim rPara As Para.TABLE.DocumentRegisterPara = eng.GetDocumentPara(Convert.ToInt64(txtNewID.Text), trans)
                        lblBookNo.Text = rPara.BOOK_NO
                        If rPara.REQUEST_NO.Trim <> "" Then
                            Dim LogID As Long = Config.GetLoginHistoryID
                            lblRequestNo.Text = "เลขที่คำขอ : " & rPara.REQUEST_NO & " "
                            lblRequestNo.Text += "<img src='../Images/TH.png' width='20' onClick='PrintReport(" & Chr(34) & "Report_TH" & Chr(34) & "," & rPara.ID & ");SaveTransLog(" & Chr(34) & "พิมพ์ใบตอบรับคำขอภาษาไทย เลขที่คำขอ : " & rPara.REQUEST_NO & Chr(34) & ", " & LogID & ")' title='พิมพ์ใบแจ้งการตอบรับการยื่นคำขอรับการส่งเสริมการลงทุน' style='cursor:pointer;' /> "
                            lblRequestNo.Text += "<img src='../Images/USA.png' width='20' onClick='PrintReport(" & Chr(34) & "Report_EN" & Chr(34) & "," & rPara.ID & ");SaveTransLog(" & Chr(34) & "พิมพ์ใบตอบรับคำขอภาษาอังกฤษ เลขที่คำขอ : " & rPara.REQUEST_NO & Chr(34) & ", " & LogID & ")' title='NOTIFICATION OF RECEIPT OF APPLICATION FOR INVESTMENT PROMOTION' style='cursor:pointer;' /> "
                        End If
                        rPara = Nothing
                        eng = Nothing

                        trans.CommitTransaction()
                        zPopConfirmClear.Show()
                    Else
                        trans.RollbackTransaction()
                        gvConfirmList.DataSource = Nothing
                        gvConfirmList.DataBind()

                        Response.Redirect("../WebApp/frmSessionExpire.aspx")
                    End If
                Else
                    trans.RollbackTransaction()
                    gvConfirmList.DataSource = Nothing
                    gvConfirmList.DataBind()
                    zPopConfirm.Hide()
                    Config.SetAlert("เกิดความผิดพลาดระหว่างการดำเนินการ ไม่สามารถบันทึกข้อมูลได้", Me.Page)
                End If
            End If
        Else
            gvConfirmList.DataSource = Nothing
            gvConfirmList.DataBind()
        End If
    End Sub

    Protected Sub btnYesClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYesClear.Click
        ClearSendComplete()
        RaiseEvent YesClear(sender, e)
    End Sub

    Protected Sub btnNoClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoClear.Click
        ClearSendComplete()
        RaiseEvent NoClear(sender, e)
    End Sub

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        ClearSendComplete()
        RaiseEvent Click(sender, e)

    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click
        ClearSendComplete()
        RaiseEvent NoSend(sender, e)
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        ClearSendComplete()
        RaiseEvent NoSend(sender, e)
    End Sub

    Private Sub ClearSendComplete()
        lblBookNo.Text = ""
        lblRequestNo.Text = ""
        gvConfirmList.DataSource = Nothing
        gvConfirmList.DataBind()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        ClearSendComplete()
        RaiseEvent NoClear(sender, e)
    End Sub
End Class
