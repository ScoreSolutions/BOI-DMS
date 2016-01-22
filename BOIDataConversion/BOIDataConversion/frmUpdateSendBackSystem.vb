Public Class frmUpdateSendBackSystem

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'If txtBookNo.Text.Trim = "" Then
        '    MessageBox.Show("กรุณาระบุเลขที่หนังสือ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtBookNo.Focus()
        'End If


        Dim sql As String = "select ir.id, dr.id document_register_id"
        sql += " from DOCUMENT_REGISTER dr"
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id"
        sql += " 	and ir.id=(select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)"
        sql += " where ir.receive_status_id = '" & Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem & "'"
        'sql += " and dr.book_no='" & txtBookNo.Text.Trim & "'"

        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        trans.CommitTransaction()
        'หารายการที่มีการตีกลับโดยระบบ และ User ยังไม่ได้ทำอะไรต่อ
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                trans = New Utilities.TransactionDB
                trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

                'Delete Movement ในการส่งภายในไปยังต้นทาง
                Dim ret As Boolean = Utilities.SqlDB.ExecuteNonQuery("delete from DOCUMENT_INT_RECEIVER where id='" & dr("id") & "'", trans.Trans)
                If ret = True Then
                    Dim dLnq As New TABLE.DocumentRegisterLinq
                    dLnq.GetDataByPK(dr("document_register_id"), trans.Trans)
                    If dLnq.HaveData = True Then

                        Dim iLnq As New TABLE.DocumentIntReceiverLinq
                        Dim iDt As DataTable = iLnq.GetDataList("document_register_id = '" & dr("document_register_id") & "'", "send_date desc", trans.Trans)
                        If iDt.Rows.Count > 0 Then
                            iLnq.GetDataByPK(iDt.Rows(0)("id"), trans.Trans)
                            If iLnq.HaveData = True Then
                                'Update สถานะการส่งของต้นทาง
                                dLnq.DOC_STATUS_ID = Utilities.Constant.DocumentRegister.DocStatusID.JobIncome   'งานเข้า
                                dLnq.ORGANIZATION_ID_PROCESS = iLnq.ORGANIZATION_ID_SEND
                                dLnq.ORGANIZATION_NAME_PROCESS = iLnq.ORGANIZATION_NAME_SEND
                                dLnq.ORGANIZATION_ABBNAME_PROCESS = iLnq.ORGANIZATION_APPNAME_SEND

                                Dim OfficerID As Long = Convert.ToInt64(GetOfficerIDByUserName(iLnq.SENDER_OFFICER_USERNAME, trans))
                                dLnq.OFFICER_ID_POSSESS = OfficerID
                                dLnq.OFFICER_NAME_POSSESS = iLnq.SENDER_OFFICER_FULLNAME

                                dLnq.ORGANIZATION_ID_OWNER = iLnq.ORGANIZATION_ID_SEND
                                dLnq.ORGANIZATION_NAME = iLnq.ORGANIZATION_NAME_SEND
                                dLnq.ORGANIZATION_APPNAME = iLnq.ORGANIZATION_APPNAME_SEND
                                dLnq.OFFICER_ID_APPROVE = OfficerID
                                dLnq.OFFICER_NAME = iLnq.SENDER_OFFICER_FULLNAME

                                If dLnq.UpdateByPK(iLnq.SENDER_OFFICER_USERNAME, trans.Trans) = True Then
                                    iLnq.IS_FORWARD = "N"
                                    If iLnq.UpdateByPK(trans.Trans) = True Then
                                        trans.CommitTransaction()
                                    Else
                                        trans.RollbackTransaction()
                                        CreateLogFile(iLnq.SqlInsert)
                                    End If
                                Else
                                    trans.RollbackTransaction()
                                    CreateLogFile(dLnq.SqlInsert)
                                End If
                            End If
                        End If
                        iLnq = Nothing
                        iDt = Nothing
                    End If
                    dLnq = Nothing
                End If
                trans.CommitTransaction()

                lblProgress.Text = "Current " & (i + 1) & "  Total : " & dt.Rows.Count
                Application.DoEvents()
            Next
            dt = Nothing
        End If
    End Sub
End Class