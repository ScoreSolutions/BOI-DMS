Imports System.Data.SqlClient
Public Class frmUpdateDocumentNoMoveMent

    Dim strTime As Long = 0

    Private Sub ExecuteDocList(ByVal sql As String)
        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
        Dim RegDT As New DataTable
        RegDT = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        trans.CommitTransaction()
        If RegDT.Rows.Count > 0 Then
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = RegDT.Rows.Count

            lblTotal.Text = "Total : " & RegDT.Rows.Count
            For Each Dr As DataRow In RegDT.Rows
                trans = New Utilities.TransactionDB
                trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

                Dim dLnq As New TABLE.DocumentRegisterLinq
                dLnq.GetDataByPK(Dr("id"), trans.Trans)
                If dLnq.HaveData = True Then
                    Dim lnq As New TABLE.DocumentIntReceiverLinq
                    lnq.DOCUMENT_REGISTER_ID = dLnq.ID
                    lnq.ORGANIZATION_ID_SEND = dLnq.ORGANIZATION_ID_OWNER
                    lnq.ORGANIZATION_NAME_SEND = dLnq.ORGANIZATION_NAME
                    lnq.ORGANIZATION_APPNAME_SEND = dLnq.ORGANIZATION_APPNAME
                    lnq.SEND_DATE = IIf(dLnq.UPDATE_ON.Value.Year <> 1, dLnq.UPDATE_ON.Value, dLnq.CREATE_ON)
                    lnq.SENDER_OFFICER_USERNAME = GetUsernameByOfficerID(dLnq.OFFICER_ID_APPROVE, trans)
                    lnq.SENDER_OFFICER_FULLNAME = dLnq.OFFICER_NAME
                    lnq.RECEIVE_STATUS_ID = Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive

                    Dim oDt As DataTable = GetOrgByAbbName(Split(dLnq.BOOK_NO, "/")(1), trans)
                    If oDt.Rows.Count > 0 Then
                        lnq.ORGANIZATION_ID_RECEIVE = oDt.Rows(0)("id")
                        If Convert.IsDBNull(oDt.Rows(0)("org_name")) = False Then lnq.ORGANIZATION_NAME_RECEIVE = oDt.Rows(0)("org_name")
                        If Convert.IsDBNull(oDt.Rows(0)("name_abb")) = False Then lnq.ORGANIZATION_APPNAME_RECEIVE = oDt.Rows(0)("name_abb")
                    End If
                    lnq.IS_FORWARD = "N"
                    lnq.REMARKS = dLnq.REMARKS

                    If lnq.InsertData(trans.Trans) = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        CreateLogFile(lnq.ErrorMessage & "##### " & lnq.SqlInsert)
                    End If
                End If
                ProgressBar1.Value += 1
                lblCurrent.Text = "Current : " & ProgressBar1.Value
                Application.DoEvents()
            Next
            RegDT.Dispose()
            RegDT = Nothing
        End If
    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        lblTime.Text = "00:00:00"
        Timer1.Enabled = True

        Dim sql As String = "select dr.id, dr.organization_id_owner,dr.organization_name,dr.organization_appname,"
        sql += " dr.officer_id_approve, dr.officer_name"
        sql += " from document_register dr "
        sql += " where (select COUNT(id) from DOCUMENT_INT_RECEIVER where document_register_id=dr.id)=0"
        sql += " and CHARINDEX('/',dr.book_no)>0"
        sql += " and doc_status_id='2' "

        If txtBookNo.Text.Trim <> "" Then
            sql += " and dr.book_no='" & txtBookNo.Text & "'"
            ExecuteDocList(sql)

            Exit Sub
        End If
        ExecuteDocList(sql)

        Timer1.Enabled = False
    End Sub


    Private Sub InsertNewExternalReceiver(ByVal BookNo As String, ByVal vID As Long)
        Dim oDT As New DataTable
        oDT = GetOldExtReceiveDT(BookNo)
        If oDT.Rows.Count > 0 Then
            Dim nTrans As New Utilities.TransactionDB
            nTrans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
            Dim nDt As New DataTable
            nDt = Utilities.SqlDB.ExecuteTable("select id,REF_OLD_RECEIVE_ID from document_ext_receiver where document_register_id='" & vID & "' ", nTrans.Trans)
            If nDt.Rows.Count > 0 Then
                For i As Integer = oDT.Rows.Count - 1 To 0 Step -1
                    nDt.DefaultView.RowFilter = "REF_OLD_RECEIVE_ID='" & oDT.Rows(i)("id1") & "'"
                    If nDt.DefaultView.Count > 0 Then
                        oDT.Rows.RemoveAt(i)
                    End If
                    nDt.DefaultView.RowFilter = ""
                Next
            End If
            nTrans.CommitTransaction()


            If oDT.Rows.Count > 0 Then
                For Each dr As DataRow In oDT.Rows
                    InsertNewExtReceiver(dr, vID)
                Next
            End If
            oDT.Dispose()
            oDT = Nothing
        End If
    End Sub

    Private Sub InsertNewInternalReceiver(ByVal BookNo As String, ByVal vID As Long)
        Dim oDT As New DataTable
        oDT = GetOldIntReceiverDT(BookNo)
        If oDT.Rows.Count > 0 Then
            Dim nTrans As New Utilities.TransactionDB
            nTrans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
            Dim nDt As New DataTable
            nDt = Utilities.SqlDB.ExecuteTable("select id,ref_old_receive_id from document_int_receiver where document_register_id='" & vID & "' ", nTrans.Trans)
            If nDt.Rows.Count > 0 Then
                For i As Integer = oDT.Rows.Count - 1 To 0 Step -1
                    nDt.DefaultView.RowFilter = "ref_old_receive_id='" & oDT.Rows(i)("id") & "'"
                    If nDt.DefaultView.Count > 0 Then
                        oDT.Rows.RemoveAt(i)
                    End If
                    nDt.DefaultView.RowFilter = ""
                Next
            End If
            nTrans.CommitTransaction()

            If oDT.Rows.Count > 0 Then
                For Each dr As DataRow In oDT.Rows
                    InsertNewIntReceiver(dr, vID)
                Next
            End If
            oDT.Dispose()
            oDT = Nothing
        End If
    End Sub

    Private Function CheckUpdateStatusDocumentRegisterByDocNo(ByVal OldDr As DataRow, ByVal trans As Utilities.TransactionDB) As Long
        Dim ret As Long = 0
        Dim sql As String = "select top 1 id from document_register where book_no = '" & OldDr("id").ToString & "'"
        Dim dt As New DataTable
        dt = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        If dt.Rows.Count > 0 Then
            ret = Convert.ToInt64(dt.Rows(0)("id"))
        End If

        Return ret
    End Function

    Private Function UpdateDocumentRegister(ByVal dr As DataRow) As String
        Dim ret As String = ""
        Dim lnq As New TABLE.DocumentRegisterLinq
        Try
            Dim trans As New Utilities.TransactionDB
            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

            Dim vID As Long = CheckUpdateStatusDocumentRegisterByDocNo(dr, trans)
            If vID > 0 Then
                lnq.GetDataByPK(vID, trans.Trans)
                If lnq.DOC_STATUS_ID <> Convert.ToInt64(dr("docStatusID")) Then
                    SaveNewDocumentRegister(dr, vID)
                End If

                ret = lnq.BOOK_NO & "###" & lnq.ID
                lnq = Nothing
            End If
        Catch ex As Exception
            CreateLogFile("Exception " & ex.Message & " SQL:" & lnq.SqlInsert)
        End Try
        Return ret
    End Function




    'Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
    '    Dim sql As String = "select id, company_id from document_register where convert(varchar(4),register_date,120)='" & txtYear.Text.Trim & "'"

    '    Dim trans As New Utilities.TransactionDB
    '    trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
    '    Dim RegDT As New DataTable
    '    RegDT = Utilities.SqlDB.ExecuteTable(Sql, trans.Trans)
    '    trans.CommitTransaction()
    '    If RegDT.Rows.Count > 0 Then
    '        ProgressBar1.Maximum = RegDT.Rows.Count
    '        ProgressBar1.Value = 0
    '        For i As Integer = 0 To RegDT.Rows.Count - 1
    '            Application.DoEvents()
    '            trans = New Utilities.TransactionDB
    '            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
    '            If Convert.IsDBNull(RegDT.Rows(i)("company_id")) = False Then
    '                If SetCompanyID(RegDT.Rows(i)("id"), RegDT.Rows(i)("company_id"), trans) = True Then
    '                    trans.CommitTransaction()
    '                Else
    '                    trans.RollbackTransaction()
    '                End If
    '            End If
    '            ProgressBar1.Value = i + 1
    '        Next
    '    End If
    'End Sub

    Private Function SetCompanyID(ByVal vID As Long, ByVal vCompanyID As Long, ByVal trans As Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Dim lnq As New TABLE.DocumentRegisterLinq
        Dim sql As String = "select id from company where id='" & vCompanyID & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        If dt.Rows.Count > 0 Then
            'รับจากหน่วยงานภายนอก
            ret = lnq.UpdateBySql("update document_register set document_receive_type='0' where id=" & vID, trans.Trans)
        Else
            'รับจากหน่วยงานภายใน
            ret = lnq.UpdateBySql("update document_register set document_receive_type='1' where id=" & vID, trans.Trans)
        End If

        Return ret
    End Function









    Private Function GetFormatTimeFromSec(ByVal TimeSec As Integer) As String
        'แปลงเวลาจากวินาทีไปเป็น HH:mm:ss
        Dim tHour As Integer = 0
        Dim tMin As Integer = 0
        Dim tSec As Integer = 0
        If TimeSec >= 3600 Then
            tHour = Math.Floor(TimeSec / 3600)
            tMin = Math.Floor((TimeSec - (tHour * 3600)) / 60)
            tSec = (TimeSec - (tHour * 3600)) Mod 60
        Else
            tMin = Math.Floor(TimeSec / 60)
            tSec = TimeSec Mod 60
        End If

        Return tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
    End Function

    Private Function GetSecFromTimeFormat(ByVal TimeFormat As String) As Integer
        'แปลงเวลาในรูปแบบ HH:mm:ss ไปเป็นวินาที

        Dim ret As Int32 = 0
        If TimeFormat.Trim <> "" Then
            Dim tmp() As String = Split(TimeFormat, ":")
            Dim TimeSec As Integer = 0
            If Convert.ToInt64(tmp(0)) > 0 Then
                TimeSec += (Convert.ToInt64(tmp(0)) * 60 * 60)
            End If
            If Convert.ToInt64(tmp(1)) > 0 Then
                TimeSec += (Convert.ToInt64(tmp(1)) * 60)
            End If
            ret = TimeSec + Convert.ToInt32(tmp(2))
        End If
        Return ret
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        strTime += 1
        lblTime.Text = GetFormatTimeFromSec(strTime)
        Application.DoEvents()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
