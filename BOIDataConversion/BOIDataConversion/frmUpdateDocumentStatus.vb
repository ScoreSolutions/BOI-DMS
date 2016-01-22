Imports System.Data.SqlClient
Public Class frmUpdateDocumentStatus

    Dim strTime As Long = 0

    Private Sub ExecuteDocList(ByVal sql As String)
        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetOldConnection)
        Dim RegDT As New DataTable
        RegDT = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        trans.CommitTransaction()
        If RegDT.Rows.Count > 0 Then
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = RegDT.Rows.Count

            lblTotal.Text = "Total : " & RegDT.Rows.Count
            For Each OldDr As DataRow In RegDT.Rows
                Dim vRef() As String

                If CheckCurrentBookFromNewDB(OldDr) = False Then
                    vRef = Split(SaveNewDocumentRegister(OldDr, 0), "###")
                Else
                    vRef = Split(UpdateDocumentRegister(OldDr), "###")
                End If

                If vRef(0).Trim <> "" Then
                    InsertNewInternalReceiver(vRef(0), vRef(1))
                    InsertNewExternalReceiver(vRef(0), vRef(1))
                End If
                ProgressBar1.Value += 1
                lblCurrent.Text = "Current : " & ProgressBar1.Value
                Application.DoEvents()
            Next
            RegDT.Dispose()
            RegDT = Nothing
        End If
    End Sub

    Private Function CheckCurrentBookFromNewDB(ByVal dr As DataRow) As Boolean
        Dim ret As Boolean = False
        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

        Dim sql As String = "select top 1 id from document_register where book_no = '" & dr("id").ToString & "'"
        Dim dt As New DataTable
        dt = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        trans.CommitTransaction()

        Return ret
    End Function

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        lblTime.Text = "00:00:00"
        Timer1.Enabled = True

        Dim sql As String = " SELECT  [_Doc].[ID]" & vbNewLine
        sql += " ,[_Doc].[requestID]"
        sql += " ,[_Doc].[name]"
        sql += " ,[_Doc].[docCatID]"
        sql += " ,[_Doc].[registerDateTime]"
        sql += " ,[_Doc].[expectFinishDateTime]"
        sql += " ,[_Doc].[orgOwnerID]"
        sql += " ,[_Doc].[orgOwnerName]"
        sql += " ,[_Doc].[orgOwnerNameAbb]"
        sql += " ,[_Doc].[approverID]"
        sql += " ,[_Doc].[approverName]"
        sql += " ,[_Doc].[approverOrgID]"
        sql += " ,[_Doc].[priorityID]"
        sql += " ,[_Doc].[securityLevelID]"
        sql += " ,[_Doc].[remark]"
        sql += " ,[_Doc].[companyID]"
        sql += " ,[_Doc].[companyName]"
        sql += " ,[_Doc].[companyDocID]"
        sql += " ,[_Doc].[companyDocTypeID]"
        sql += " ,[_Doc].[companyDocSysID]"
        sql += " ,[_Doc].[companyReqID]"
        sql += " ,[_Doc].[companyDocDateTime]"
        sql += " ,[_Doc].[companySignature]"
        sql += " ,[_Doc].[businessTypeID]"
        sql += " ,[_Doc].[docStatusID]"
        sql += " ,[_Doc].[closeBy]"
        sql += " ,[_Doc].[closeByName]"
        sql += " ,[_Doc].[closeDateTime]"
        sql += " ,[_Doc].[storageID]"
        sql += " ,[_Doc].[storageName]"
        sql += " ,[_Doc].[isMustReceiveDoc]"
        sql += " ,[_Doc].[createBy]"
        sql += " ,[_Doc].[createDateTime]"
        sql += " ,[_Doc].[modifyBy]"
        sql += " ,[_Doc].[modifyDateTime]"
        sql += " ,( select top 1  e.publishID"
        sql += "    from [_ExtDocReceiver] e"
        sql += "    inner join [_DocSender] ds on ds.ID=e.senderID"
        sql += "    where ds.docID=_Doc.ID "
        sql += "    order by e.id desc) publishID"
        sql += " FROM [_Doc] "


        If txtBookNo.Text.Trim <> "" Then
            sql += " and [_Doc].id='" & txtBookNo.Text & "'"
            ExecuteDocList(sql)

            Exit Sub
        End If


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
        Dim dt As New DataTable

        Dim trans As New Utilities.TransactionDB
        trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

        dt = Utilities.SqlDB.ExecuteTable("select id, org_name from organization order by org_name", trans.Trans)
        trans.CommitTransaction()
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("org_name") = "ทั้งหมด"
            dr("id") = "0"
            dt.Rows.InsertAt(dr, 0)

            cmbOrgID.DisplayMember = "org_name"
            cmbOrgID.ValueMember = "id"
            cmbOrgID.DataSource = dt

            dt = Nothing
        End If
    End Sub
End Class
