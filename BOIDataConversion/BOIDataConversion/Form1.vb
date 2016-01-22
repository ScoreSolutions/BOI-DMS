Imports System.Data.SqlClient
Public Class Form1

    Dim strTime As Long = 0

    Private Function GetOldQueryData() As String
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

        Return sql
    End Function

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
                'ถ้ามี Record เดิมอยู่แล้ว
                'trans = New Utilities.TransactionDB
                'trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
                'Dim oDt As DataTable = Utilities.SqlDB.ExecuteTable("select id from document_register where book_no='" & OldDr("id") & "'", trans.Trans)
                'trans.CommitTransaction()
                'Dim vId As Long = 0
                'If oDt.Rows.Count > 0 Then
                '    vId = Convert.ToInt64(oDt.Rows(0)("id"))
                'End If

                


                'Dim vRef() As String = Split(SaveNewDocumentRegister(OldDr, 0), "###")
                Dim vRef() As String = Split(InsertNewDocumentRegister(OldDr), "###")
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

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        lblTime.Text = "00:00:00"
        Timer1.Enabled = True

        

        If txtBookNo.Text.Trim <> "" Then
            Dim sql As String = GetOldQueryData()
            sql += " where [_Doc].[ID]='" & txtBookNo.Text & "'"
            ExecuteDocList(sql)

            Exit Sub
        End If

        For y As Integer = txtYear.Text To txtYearTo.Text
            For i As Integer = txtMonthFrom.Text To txtMonthTo.Text
                lblMonth.Text = MonthName(i) & " " & y.ToString
                Dim sql = GetOldQueryData()
                sql += " where CONVERT(varchar(6), [_Doc].registerDateTime,112)='" & y & i.ToString.PadLeft(2, "0") & "' "
                sql += " and [_Doc].docstatusid='3'"
                If txtBookNo.Text.Trim <> "" Then
                    sql += " and [_Doc].[ID]='" & txtBookNo.Text & "'"
                End If
                'If cmbOrgID.SelectedValue <> "0" Then
                '    sql += " and [_Doc].approverOrgID = '" & cmbOrgID.SelectedValue & "'"
                '    sql += " and [_Doc].docStatusID in ('1','2')"
                '    'sql += " "
                'End If

                ExecuteDocList(sql)
            Next
        Next
        Timer1.Enabled = False
    End Sub

    Private Sub InsertNewExternalReceiver(ByVal BookNo As String, ByVal vID As Long)
        'Dim sql As String = ""
        'sql += " SELECT dbo._DocSender.Id, dbo._ExtDocReceiver.createBy, dbo._ExtDocReceiver.createDateTime, "
        'sql += " dbo._ExtDocReceiver.modifyBy, dbo._ExtDocReceiver.modifyDateTime, dbo._DocSender.orgID, "
        'sql += " dbo._DocSender.orgName, dbo._DocSender.orgNameAbb, dbo._DocSender.createDateTime , dbo._DocSender.userID,"
        'sql += " dbo._DocSender.userName, dbo._ExtDocReceiver.publishID,dbo._ExtDocReceiver.CompanyID, "
        'sql += " dbo._ExtDocReceiver.CompanyName,dbo._ExtDocReceiver.CompanyDocsystemID,dbo._ExtDocReceiver.userID , "
        'sql += " dbo._ExtDocReceiver.userName , dbo._ExtDocReceiver.remark, dbo._ExtDocReceiver.slotNo, "
        'sql += " dbo._ExtDocReceiver.receiveStatusID, dbo._ExtDocReceiver.publishTypeID, dbo._ExtDocReceiver.storageID,"
        'sql += " dbo._ExtDocReceiver.storageName, dbo._ExtDocReceiver.expectFinishDateTime, "
        'sql += " dbo._ExtDocReceiver.maximumProcessingPeriod, dbo._ExtDocReceiver.approvalDateTime, "
        'sql += " dbo._ExtDocReceiver.ID "
        'sql += " FROM dbo._DocSender "
        'sql += " INNER JOIN dbo._ExtDocReceiver ON dbo._DocSender.ID = dbo._ExtDocReceiver.senderID "
        'sql += " where [_DocSender].[docID] = '" & BookNo & "'"

        'Dim oTrans As New Utilities.TransactionDB
        'oTrans.CreateTransaction(Utilities.SqlDB.GetOldConnection)
        'Dim oDT As New DataTable
        'oDT = Utilities.SqlDB.ExecuteTable(sql, oTrans.Trans)
        'oTrans.CommitTransaction()

        Dim oDT As New DataTable
        oDT = GetOldExtReceiveDT(BookNo)
        If oDT.Rows.Count > 0 Then
            For Each dr As DataRow In oDT.Rows
                InsertNewExtReceiver(dr, vID)
                'Try
                '    Dim trans As New Utilities.TransactionDB
                '    trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
                '    Dim lnq As New TABLE.DocumentExtReceiverLinq

                '    If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
                '    If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
                '    If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
                '    If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
                '    lnq.DOCUMENT_REGISTER_ID = vID
                '    If Convert.IsDBNull(dr("orgID")) = False Then lnq.ORGANIZATION_ID_SEND = dr("orgID")
                '    If Convert.IsDBNull(dr("orgName")) = False Then lnq.ORGANIZATION_NAME_SEND = dr("orgName")
                '    If Convert.IsDBNull(dr("orgNameAbb")) = False Then lnq.ORGANIZATION_APPNAME_SEND = dr("orgNameAbb")
                '    If Convert.IsDBNull(dr("createDateTime1")) = False Then lnq.SEND_DATE = Convert.ToDateTime(dr("createDateTime1"))
                '    If Convert.IsDBNull(dr("userID")) = False Then lnq.SENDER_OFFICER_USERNAME = dr("userID")
                '    If Convert.IsDBNull(dr("userName")) = False Then lnq.SENDER_OFFICER_FULLNAME = dr("userName")
                '    If Convert.IsDBNull(dr("publishID")) = False Then lnq.BOOKOUT_NO = dr("publishID")
                '    If Convert.IsDBNull(dr("CompanyID")) = False Then lnq.COMPANY_ID_RECEIVE = GetCompanyID(dr("CompanyID"), trans)
                '    If Convert.IsDBNull(dr("CompanyName")) = False Then lnq.COMPANY_NAME_RECEIVE = dr("CompanyName")
                '    If Convert.IsDBNull(dr("CompanyDocsystemID")) = False Then lnq.COMPANY_DOC_SYSTEM_ID = dr("CompanyDocsystemID")
                '    If Convert.IsDBNull(dr("userName1")) = False Then lnq.OFFICER_FULLNAME = dr("userName1")
                '    If Convert.IsDBNull(dr("userID1")) = False Then lnq.OFFICER_USERNAME = dr("userID1")
                '    If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
                '    If Convert.IsDBNull(dr("slotNo")) = False Then lnq.SLOT_NO = dr("slotNo")
                '    If Convert.IsDBNull(dr("receiveStatusID")) = False Then lnq.RECEIVE_STATUS_ID = dr("receiveStatusID")
                '    If Convert.IsDBNull(dr("publishTypeID")) = False Then lnq.PUBLISH_TYPE_ID = dr("publishTypeID")
                '    If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = IIf(dr("storageID").ToString = "", 0, dr("storageID").ToString)
                '    If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
                '    If Convert.IsDBNull(dr("expectFinishDateTime")) = False Then lnq.EXPECT_FINISH_DATE = dr("expectFinishDateTime")
                '    If Convert.IsDBNull(dr("maximumProcessingPeriod")) = False Then lnq.MAXIMUM_PROCESSING_PERIOD = dr("maximumProcessingPeriod")
                '    If Convert.IsDBNull(dr("approvalDateTime")) = False Then lnq.APPROVE_DATE = Convert.ToDateTime(dr("approvalDateTime"))
                '    If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_SEND_ID = dr("id")
                '    If Convert.IsDBNull(dr("id1")) = False Then lnq.REF_OLD_RECEIVE_ID = dr("id1")

                '    Dim ret As Boolean = lnq.InsertData(trans.Trans)
                '    If ret = True Then
                '        trans.CommitTransaction()
                '    Else
                '        trans.RollbackTransaction()
                '        CreateLogFile("InsertNewExternalReceiver : " & lnq.ErrorMessage & Chr(13) & lnq.SqlInsert)
                '    End If
                '    lnq = Nothing
                'Catch ex As Exception
                '    CreateLogFile("InsertNewExternalReceiver : " & ex.Message & " " & sql)
                'End Try
            Next
            oDT.Dispose()
            oDT = Nothing
        End If
    End Sub

    Private Sub InsertNewInternalReceiver(ByVal BookNo As String, ByVal vID As Long)
        Dim oDT As New DataTable
        oDT = GetOldIntReceiverDT(BookNo)
        If oDT.Rows.Count > 0 Then
            For Each dr As DataRow In oDT.Rows
                InsertNewIntReceiver(dr, vID)

                'Try
                '    Dim trans As New Utilities.TransactionDB
                '    trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)
                '    Dim lnq As New TABLE.DocumentIntReceiverLinq

                '    If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
                '    If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
                '    If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
                '    If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
                '    lnq.DOCUMENT_REGISTER_ID = vID
                '    If Convert.IsDBNull(dr("orgID1")) = False Then lnq.ORGANIZATION_ID_SEND = Convert.ToInt64(dr("orgID1"))
                '    If Convert.IsDBNull(dr("orgName1")) = False Then lnq.ORGANIZATION_NAME_SEND = dr("orgName1")
                '    If Convert.IsDBNull(dr("orgNameAbb1")) = False Then lnq.ORGANIZATION_APPNAME_SEND = dr("orgNameAbb1")
                '    If Convert.IsDBNull(dr("createDateTime1")) = False Then lnq.SEND_DATE = Convert.ToDateTime(dr("createDateTime1"))
                '    If Convert.IsDBNull(dr("userID1")) = False Then lnq.SENDER_OFFICER_USERNAME = dr("userID1")
                '    If Convert.IsDBNull(dr("userName1")) = False Then
                '        lnq.SENDER_OFFICER_FULLNAME = dr("userName1")
                '    Else
                '        lnq.SENDER_OFFICER_FULLNAME = GetOfficerFullNameByUserName(dr("userName1"), trans)
                '    End If

                '    If Convert.IsDBNull(dr("receiveStatusID")) = False Then lnq.RECEIVE_STATUS_ID = dr("receiveStatusID")
                '    If Convert.IsDBNull(dr("receiveDateTime")) = False Then lnq.RECEIVE_DATE = Convert.ToDateTime(dr("receiveDateTime"))
                '    If Convert.IsDBNull(dr("orgID")) = False Then lnq.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(dr("orgID"))
                '    If Convert.IsDBNull(dr("orgName")) = False Then lnq.ORGANIZATION_NAME_RECEIVE = dr("orgName")
                '    If Convert.IsDBNull(dr("orgNameAbb")) = False Then lnq.ORGANIZATION_APPNAME_RECEIVE = dr("orgNameAbb")
                '    If Convert.IsDBNull(dr("userID")) = False Then lnq.RECEIVER_OFFICER_USERNAME = dr("userID")
                '    If Convert.IsDBNull(dr("userName")) = False Then lnq.RECEIVER_OFFICER_FULLNAME = dr("userName")
                '    If Convert.IsDBNull(dr("receiveTypeID")) = False Then lnq.RECEIVE_TYPE_ID = dr("receiveTypeID")
                '    If Convert.IsDBNull(dr("receiveTypeID")) = False Then lnq.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(IIf(dr("receiveTypeID").ToString = "", Nothing, dr("receiveTypeID")))
                '    If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
                '    If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = Convert.ToInt64(IIf(dr("storageID").ToString = "", Nothing, dr("storageID")))
                '    If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
                '    If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_RECEIVE_ID = dr("id")
                '    If Convert.IsDBNull(dr("senderID")) = False Then lnq.REF_OLD_SEND_ID = dr("senderID")

                '    Dim ret As Boolean = lnq.InsertData(trans.Trans)
                '    If ret = True Then
                '        trans.CommitTransaction()
                '    Else
                '        trans.RollbackTransaction()
                '        CreateLogFile("InsertNewInternalReceiver : " & lnq.ErrorMessage & Chr(13) & lnq.SqlInsert)
                '    End If
                '    lnq = Nothing
                'Catch ex As Exception
                '    CreateLogFile("InsertNewInternalReceiver : " & ex.Message & " ###" & Sql)
                'End Try
            Next
            oDT.Dispose()
            oDT = Nothing
        End If
    End Sub

    Private Function DeleteDocumentRegisterByDocNo(ByVal vBookNo As String, ByVal trans As Utilities.TransactionDB) As Boolean
        Dim ret As Boolean = True
        Dim sql As String = "select id from document_register where book_no = '" & vBookNo & "'"
        Dim dt As New DataTable
        dt = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim dSql As String = "delete from DOCUMENT_INT_RECEIVER where document_register_id = '" & dr("id") & "'"
                Utilities.SqlDB.ExecuteNonQuery(dSql, trans.Trans)

                dSql = "delete from DOCUMENT_EXT_RECEIVER where document_register_id = '" & dr("id") & "'"
                Utilities.SqlDB.ExecuteNonQuery(dSql, trans.Trans)

                dSql = "delete from DOCUMENT_REGISTER where id='" & dr("id") & "'"
                ret = (Utilities.SqlDB.ExecuteNonQuery(dSql, trans.Trans) > 0)
            Next
        End If

        Return ret
    End Function

    Private Function InsertNewDocumentRegister(ByVal dr As DataRow) As String
        Dim ret As String = ""
        Try
            Dim trans As New Utilities.TransactionDB
            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

            If DeleteDocumentRegisterByDocNo(dr("id"), trans) = True Then
                trans.CommitTransaction()
                ret = SaveNewDocumentRegister(dr, 0)

                'If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
                'If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
                'If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
                'If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
                'If Convert.IsDBNull(dr("id")) = False Then lnq.BOOK_NO = dr("id")
                'If Convert.IsDBNull(dr("requestID")) = False Then lnq.REQUEST_NO = dr("requestID")
                'If Convert.IsDBNull(dr("docCatID")) = False Then lnq.GROUP_TITLE_ID = GetGroupTitleID(dr("docCatID"), trans)
                'If Convert.IsDBNull(dr("name")) = False Then lnq.TITLE_NAME = dr("name")
                'If Convert.IsDBNull(dr("registerDateTime")) = False Then lnq.REGISTER_DATE = dr("registerDateTime")
                'If Convert.IsDBNull(dr("expectFinishDateTime")) = False Then lnq.EXPECT_FINISH_DATE = Convert.ToDateTime(dr("expectFinishDateTime"))
                'If Convert.IsDBNull(dr("securityLevelID")) = False Then lnq.DOC_SECRET_ID = Convert.ToInt64(dr("securityLevelID")) '[Input_DOC_2012].[securityLevelID]
                'If Convert.IsDBNull(dr("priorityID")) = False Then lnq.DOC_SPEED_ID = Convert.ToInt64(dr("priorityID"))
                'If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_OWNER = Convert.ToInt64(dr("orgOwnerID"))
                'If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_PROCESS = Convert.ToInt64(dr("orgOwnerID"))
                'If Convert.IsDBNull(dr("orgOwnerName")) = False Then lnq.ORGANIZATION_NAME = dr("orgOwnerName")
                'If Convert.IsDBNull(dr("orgOwnerNameAbb")) = False Then lnq.ORGANIZATION_APPNAME = dr("orgOwnerNameAbb")
                'If Convert.IsDBNull(dr("approverID")) = False Then lnq.OFFICER_ID_APPROVE = GetOfficerIDByUserName(dr("approverID"), trans)
                'If Convert.IsDBNull(dr("approverID")) = False Then lnq.OFFICER_ID_POSSESS = GetOfficerIDByUserName(dr("approverID"), trans)
                'If Convert.IsDBNull(dr("approverName")) = False Then lnq.OFFICER_NAME = dr("approverName")
                'If Convert.IsDBNull(dr("approverOrgID")) = False Then lnq.OFFICER_ORGANIZATION_ID = Convert.ToInt64(IIf(dr("approverOrgID").ToString.Trim = "", 0, dr("approverOrgID")))
                'lnq.ADMINISTRATION_TYPE = "1"
                'lnq.COMPANY_NOTIFY_NO = "0"

                'If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
                'If Convert.IsDBNull(dr("companyID")) = False Then lnq.COMPANY_ID = GetCompanyID(dr("companyID"), trans)
                'If Convert.IsDBNull(dr("companyName")) = False Then lnq.COMPANY_NAME = dr("companyName")
                'If Convert.IsDBNull(dr("companyDocID")) = False Then lnq.COMPANY_DOC_NO = dr("companyDocID")
                'If Convert.IsDBNull(dr("companyDocDateTime")) = False Then lnq.COMPANY_DOC_DATE = Convert.ToDateTime(dr("companyDocDateTime"))
                'If Convert.IsDBNull(dr("companyDocTypeID")) = False Then lnq.COMPANY_DOC_TYPE_ID = dr("companyDocTypeID")
                'If Convert.IsDBNull(dr("companyDocSysID")) = False Then lnq.COMPANY_DOC_SYS_ID = dr("companyDocSysID")
                'If Convert.IsDBNull(dr("companyReqID")) = False Then lnq.COMPANY_REQ_ID = dr("companyReqID")
                'If Convert.IsDBNull(dr("companySignature")) = False Then lnq.COMPANY_SIGN = dr("companySignature")
                'If Convert.IsDBNull(dr("companyDocDateTime")) = False Then lnq.COMPANY_SIGN_DATE = Convert.ToDateTime(dr("companyDocDateTime"))
                'If Convert.IsDBNull(dr("businessTypeID")) = False Then lnq.BUSINESS_TYPE_ID = Convert.ToInt64(IIf(dr("businessTypeID").ToString.Trim = "", 0, dr("businessTypeID")))
                'If Convert.IsDBNull(dr("docStatusID")) = False Then lnq.DOC_STATUS_ID = Convert.ToInt64(dr("docStatusID"))
                'If Convert.IsDBNull(dr("createBy")) = False Then lnq.USERNAME_REGISTER = dr("createBy")
                'If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_REGISTER = Convert.ToInt64(dr("orgOwnerID"))
                'If Convert.IsDBNull(dr("closeBy")) = False Then lnq.CLOSE_BY = dr("closeBy")
                'If Convert.IsDBNull(dr("closeByName")) = False Then lnq.CLOSE_BY_NAME = dr("closeByName")
                'If Convert.IsDBNull(dr("closeDateTime")) = False Then lnq.CLOSE_DATE = dr("closeDateTime")
                'If Convert.IsDBNull(dr("publishID")) = False Then lnq.BOOKOUT_NO = dr("publishID")
                'If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = Convert.ToInt64(IIf(dr("storageID").ToString.Trim = "", 0, dr("storageID")))
                'If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
                'If Convert.IsDBNull(dr("isMustReceiveDoc")) = False Then lnq.ID_MUST_RECEIVE_DOC = dr("isMustReceiveDoc")
                'If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_ID = dr("id").ToString

                'If lnq.InsertData(dr("createBy"), trans.Trans) = True Then
                '    trans.CommitTransaction()
                'Else
                '    trans.RollbackTransaction()
                '    CreateLogFile(lnq.ErrorMessage & " : " & lnq.SqlInsert)
                'End If
                'ret = lnq.BOOK_NO & "###" & lnq.ID
                'lnq = Nothing
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            CreateLogFile("Exception " & ex.Message)
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

    'Private Function SetCompanyID(ByVal vID As Long, ByVal vCompanyID As Long, ByVal trans As Utilities.TransactionDB) As Boolean
    '    Dim ret As Boolean = False
    '    Dim lnq As New TABLE.DocumentRegisterLinq
    '    Dim sql As String = "select id from company where id='" & vCompanyID & "'"
    '    Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
    '    If dt.Rows.Count > 0 Then
    '        'รับจากหน่วยงานภายนอก
    '        ret = lnq.UpdateBySql("update document_register set document_receive_type='0' where id=" & vID, trans.Trans)
    '    Else
    '        'รับจากหน่วยงานภายใน
    '        ret = lnq.UpdateBySql("update document_register set document_receive_type='1' where id=" & vID, trans.Trans)
    '    End If

    '    Return ret
    'End Function

    'Private Function GetCompanyID(ByVal CompanyID As String, ByVal trans As Utilities.TransactionDB) As String
    '    Dim sql As String = ""
    '    sql += " select id from company where ref_old_id='" & CompanyID & "'"
    '    Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

    '    Dim ret As String = "0"
    '    If CompanyID.Trim <> "" Then
    '        If dt.Rows.Count > 0 Then
    '            ret = dt.Rows(0)("id")
    '            dt.Dispose()
    '            dt = Nothing
    '        Else
    '            ret = "-1"
    '        End If
    '    End If
    '    Return ret
    'End Function

    'Private Function GetGroupTitleID(ByVal DocCatID As String, ByVal trans As Utilities.TransactionDB) As String
    '    Dim sql As String = ""
    '    sql += " select id from group_title where ref_old_id='" & DocCatID & "'"
    '    Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

    '    Dim ret As String = "0"
    '    If dt.Rows.Count > 0 Then
    '        ret = dt.Rows(0)("id")
    '        dt.Dispose()
    '        dt = Nothing
    '    End If

    '    Return ret
    'End Function

    'Private Function GetOfficerIDByUserName(ByVal UserName As String, ByVal trans As Utilities.TransactionDB) As String
    '    Dim sql As String = ""
    '    sql += " select id from officer where username='" & UserName & "'"
    '    Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

    '    Dim ret As String = "0"
    '    If dt.Rows.Count > 0 Then
    '        ret = dt.Rows(0)("id")
    '        dt.Dispose()
    '        dt = Nothing
    '    End If

    '    Return ret
    'End Function

    'Private Function GetOfficerFullNameByUserName(ByVal UserName As String, ByVal trans As Utilities.TransactionDB) As String
    '    Dim sql As String = ""
    '    sql += " select first_name + ' ' + last_name staff_name from officer where username='" & UserName & "'"
    '    Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

    '    Dim ret As String = ""
    '    If dt.Rows.Count > 0 Then
    '        ret = dt.Rows(0)("staff_name")
    '        dt.Dispose()
    '        dt = Nothing
    '    End If

    '    Return ret
    'End Function

    'Private Sub CreateLogFile(ByVal TextMsg As String)
    '    Dim FILE_NAME As String = Application.StartupPath & "\" & DateTime.Now.ToString("yyyyyMMddHH") & ".log"
    '    Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
    '    objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & TextMsg & Chr(13) & Chr(13))
    '    objWriter.Close()
    'End Sub

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
