Imports System.Windows.Forms

Module DocumentENG
    Public Function GetOldQueryData() As String
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

    Public Function SaveNewDocumentRegister(ByVal dr As DataRow, ByVal vID As Long) As String
        Dim ret As String = ""
        Dim lnq As New TABLE.DocumentRegisterLinq
        Try
            Dim trans As New Utilities.TransactionDB
            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

            If vID <> 0 Then
                lnq.GetDataByPK(vID, trans.Trans)
            End If

            If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
            If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
            If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
            If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
            If Convert.IsDBNull(dr("id")) = False Then lnq.BOOK_NO = dr("id")
            If Convert.IsDBNull(dr("requestID")) = False Then lnq.REQUEST_NO = dr("requestID")
            If Convert.IsDBNull(dr("docCatID")) = False Then lnq.GROUP_TITLE_ID = GetGroupTitleID(dr("docCatID"), trans)
            If Convert.IsDBNull(dr("name")) = False Then lnq.TITLE_NAME = dr("name")
            If Convert.IsDBNull(dr("registerDateTime")) = False Then lnq.REGISTER_DATE = dr("registerDateTime")
            If Convert.IsDBNull(dr("expectFinishDateTime")) = False Then lnq.EXPECT_FINISH_DATE = Convert.ToDateTime(dr("expectFinishDateTime"))
            If Convert.IsDBNull(dr("securityLevelID")) = False Then lnq.DOC_SECRET_ID = Convert.ToInt64(dr("securityLevelID")) '[Input_DOC_2012].[securityLevelID]
            If Convert.IsDBNull(dr("priorityID")) = False Then lnq.DOC_SPEED_ID = Convert.ToInt64(dr("priorityID"))
            If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_OWNER = Convert.ToInt64(dr("orgOwnerID"))
            If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_PROCESS = Convert.ToInt64(dr("orgOwnerID"))
            If Convert.IsDBNull(dr("orgOwnerName")) = False Then lnq.ORGANIZATION_NAME = dr("orgOwnerName")
            If Convert.IsDBNull(dr("orgOwnerNameAbb")) = False Then lnq.ORGANIZATION_APPNAME = dr("orgOwnerNameAbb")
            If Convert.IsDBNull(dr("approverID")) = False Then lnq.OFFICER_ID_APPROVE = GetOfficerIDByUserName(dr("approverID"), trans)
            If Convert.IsDBNull(dr("approverID")) = False Then lnq.OFFICER_ID_POSSESS = GetOfficerIDByUserName(dr("approverID"), trans)
            If Convert.IsDBNull(dr("approverName")) = False Then lnq.OFFICER_NAME = dr("approverName")
            If Convert.IsDBNull(dr("approverOrgID")) = False Then lnq.OFFICER_ORGANIZATION_ID = Convert.ToInt64(IIf(dr("approverOrgID").ToString.Trim = "", 0, dr("approverOrgID")))
            lnq.ADMINISTRATION_TYPE = "1"
            lnq.COMPANY_NOTIFY_NO = "0"

            If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
            If Convert.IsDBNull(dr("companyID")) = False Then lnq.COMPANY_ID = GetCompanyID(dr("companyID"), trans)
            If Convert.IsDBNull(dr("companyName")) = False Then lnq.COMPANY_NAME = dr("companyName")
            If Convert.IsDBNull(dr("companyDocID")) = False Then lnq.COMPANY_DOC_NO = dr("companyDocID")
            If Convert.IsDBNull(dr("companyDocDateTime")) = False Then lnq.COMPANY_DOC_DATE = Convert.ToDateTime(dr("companyDocDateTime"))
            If Convert.IsDBNull(dr("companyDocTypeID")) = False Then lnq.COMPANY_DOC_TYPE_ID = dr("companyDocTypeID")
            If Convert.IsDBNull(dr("companyDocSysID")) = False Then lnq.COMPANY_DOC_SYS_ID = dr("companyDocSysID")
            If Convert.IsDBNull(dr("companyReqID")) = False Then lnq.COMPANY_REQ_ID = dr("companyReqID")
            If Convert.IsDBNull(dr("companySignature")) = False Then lnq.COMPANY_SIGN = dr("companySignature")
            If Convert.IsDBNull(dr("companyDocDateTime")) = False Then lnq.COMPANY_SIGN_DATE = Convert.ToDateTime(dr("companyDocDateTime"))
            If Convert.IsDBNull(dr("businessTypeID")) = False Then lnq.BUSINESS_TYPE_ID = Convert.ToInt64(IIf(dr("businessTypeID").ToString.Trim = "", 0, dr("businessTypeID")))
            If Convert.IsDBNull(dr("docStatusID")) = False Then lnq.DOC_STATUS_ID = Convert.ToInt64(dr("docStatusID"))
            If Convert.IsDBNull(dr("createBy")) = False Then lnq.USERNAME_REGISTER = dr("createBy")
            If Convert.IsDBNull(dr("orgOwnerID")) = False Then lnq.ORGANIZATION_ID_REGISTER = Convert.ToInt64(dr("orgOwnerID"))
            If Convert.IsDBNull(dr("closeBy")) = False Then lnq.CLOSE_BY = dr("closeBy")
            If Convert.IsDBNull(dr("closeByName")) = False Then lnq.CLOSE_BY_NAME = dr("closeByName")
            If Convert.IsDBNull(dr("closeDateTime")) = False Then lnq.CLOSE_DATE = dr("closeDateTime")
            If Convert.IsDBNull(dr("publishID")) = False Then lnq.BOOKOUT_NO = dr("publishID")
            If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = Convert.ToInt64(IIf(dr("storageID").ToString.Trim = "", 0, dr("storageID")))
            If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
            If Convert.IsDBNull(dr("isMustReceiveDoc")) = False Then lnq.ID_MUST_RECEIVE_DOC = dr("isMustReceiveDoc")
            If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_ID = dr("id").ToString

            Dim r As Boolean = False
            If lnq.ID <> 0 Then
                r = lnq.UpdateByPK(dr("modifyBy"), trans.Trans)
            Else
                r = lnq.InsertData(dr("createBy"), trans.Trans)
            End If

            If r = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateLogFile(lnq.ErrorMessage & " : " & lnq.SqlInsert)
            End If
            ret = lnq.BOOK_NO & "###" & lnq.ID
            lnq = Nothing
        Catch ex As Exception
            CreateLogFile("Exception " & ex.Message & " SQL:" & lnq.SqlInsert)
        End Try
        Return ret
    End Function

    Public Function GetOldIntReceiverDT(ByVal BookNo As String) As DataTable
        Dim sql As String = "SELECT  [_IntDocReceiver].[ID]"
        sql += " ,[_IntDocReceiver].[docID]"
        sql += " ,[_IntDocReceiver].[senderID]"
        sql += " ,[_IntDocReceiver].[receiveStatusID]"
        sql += " ,[_IntDocReceiver].[receiveDateTime]"
        sql += " ,[_IntDocReceiver].[userID]"
        sql += " ,[_IntDocReceiver].[userName]"
        sql += " ,[_IntDocReceiver].[orgID]"
        sql += " ,[_IntDocReceiver].[orgName]"
        sql += " ,[_IntDocReceiver].[orgNameAbb]"
        sql += " ,[_IntDocReceiver].[receiveTypeID]"
        sql += " ,[_IntDocReceiver].[remark]"
        sql += " ,[_IntDocReceiver].[storageID]"
        sql += " ,[_IntDocReceiver].[storageName]"
        sql += " ,[_IntDocReceiver].[createBy]"
        sql += " ,[_IntDocReceiver].[createDateTime]"
        sql += " ,[_IntDocReceiver].[modifyBy]"
        sql += " ,[_IntDocReceiver].[modifyDateTime]"
        sql += " ,_DocSender.createDateTime"
        sql += " ,_DocSender.userID"
        sql += " ,_DocSender.userName"
        sql += " ,_DocSender.orgID"
        sql += " ,_DocSender.orgName"
        sql += " ,_DocSender.orgNameAbb"
        sql += " FROM [_IntDocReceiver] "
        sql += " inner join _DocSender on _DocSender.ID = _IntDocReceiver.senderID "
        sql += " where [_DocSender].[docID] = '" & BookNo & "'"

        Dim oTrans As New Utilities.TransactionDB
        oTrans.CreateTransaction(Utilities.SqlDB.GetOldConnection)
        Dim oDT As New DataTable
        oDT = Utilities.SqlDB.ExecuteTable(sql, oTrans.Trans)
        oTrans.CommitTransaction()
        Return oDT
    End Function

    Public Function GetOldExtReceiveDT(ByVal BookNo As String) As DataTable
        Dim sql As String = ""
        sql += " SELECT dbo._DocSender.Id, dbo._ExtDocReceiver.createBy, dbo._ExtDocReceiver.createDateTime, "
        sql += " dbo._ExtDocReceiver.modifyBy, dbo._ExtDocReceiver.modifyDateTime, dbo._DocSender.orgID, "
        sql += " dbo._DocSender.orgName, dbo._DocSender.orgNameAbb, dbo._DocSender.createDateTime , dbo._DocSender.userID,"
        sql += " dbo._DocSender.userName, dbo._ExtDocReceiver.publishID,dbo._ExtDocReceiver.CompanyID, "
        sql += " dbo._ExtDocReceiver.CompanyName,dbo._ExtDocReceiver.CompanyDocsystemID,dbo._ExtDocReceiver.userID , "
        sql += " dbo._ExtDocReceiver.userName , dbo._ExtDocReceiver.remark, dbo._ExtDocReceiver.slotNo, "
        sql += " dbo._ExtDocReceiver.receiveStatusID, dbo._ExtDocReceiver.publishTypeID, dbo._ExtDocReceiver.storageID,"
        sql += " dbo._ExtDocReceiver.storageName, dbo._ExtDocReceiver.expectFinishDateTime, "
        sql += " dbo._ExtDocReceiver.maximumProcessingPeriod, dbo._ExtDocReceiver.approvalDateTime, "
        sql += " dbo._ExtDocReceiver.ID id1 "
        sql += " FROM dbo._DocSender "
        sql += " INNER JOIN dbo._ExtDocReceiver ON dbo._DocSender.ID = dbo._ExtDocReceiver.senderID "
        sql += " where [_DocSender].[docID] = '" & BookNo & "'"

        Dim oTrans As New Utilities.TransactionDB
        oTrans.CreateTransaction(Utilities.SqlDB.GetOldConnection)
        Dim oDT As New DataTable
        oDT = Utilities.SqlDB.ExecuteTable(sql, oTrans.Trans)
        oTrans.CommitTransaction()

        Return oDT
    End Function

    Public Sub InsertNewIntReceiver(ByVal dr As DataRow, ByVal vID As Long)
        Dim lnq As New TABLE.DocumentIntReceiverLinq
        Try
            Dim trans As New Utilities.TransactionDB
            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

            If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
            If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
            If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
            If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
            lnq.DOCUMENT_REGISTER_ID = vID
            If Convert.IsDBNull(dr("orgID1")) = False Then lnq.ORGANIZATION_ID_SEND = Convert.ToInt64(dr("orgID1"))
            If Convert.IsDBNull(dr("orgName1")) = False Then lnq.ORGANIZATION_NAME_SEND = dr("orgName1")
            If Convert.IsDBNull(dr("orgNameAbb1")) = False Then lnq.ORGANIZATION_APPNAME_SEND = dr("orgNameAbb1")
            If Convert.IsDBNull(dr("createDateTime1")) = False Then lnq.SEND_DATE = Convert.ToDateTime(dr("createDateTime1"))
            If Convert.IsDBNull(dr("userID1")) = False Then lnq.SENDER_OFFICER_USERNAME = dr("userID1")
            If Convert.IsDBNull(dr("userName1")) = False Then
                lnq.SENDER_OFFICER_FULLNAME = dr("userName1")
            Else
                lnq.SENDER_OFFICER_FULLNAME = GetOfficerFullNameByUserName(dr("userName1"), trans)
            End If

            If Convert.IsDBNull(dr("receiveStatusID")) = False Then lnq.RECEIVE_STATUS_ID = dr("receiveStatusID")
            If Convert.IsDBNull(dr("receiveDateTime")) = False Then lnq.RECEIVE_DATE = Convert.ToDateTime(dr("receiveDateTime"))
            If Convert.IsDBNull(dr("orgID")) = False Then lnq.ORGANIZATION_ID_RECEIVE = Convert.ToInt64(dr("orgID"))
            If Convert.IsDBNull(dr("orgName")) = False Then lnq.ORGANIZATION_NAME_RECEIVE = dr("orgName")
            If Convert.IsDBNull(dr("orgNameAbb")) = False Then lnq.ORGANIZATION_APPNAME_RECEIVE = dr("orgNameAbb")
            If Convert.IsDBNull(dr("userID")) = False Then lnq.RECEIVER_OFFICER_USERNAME = dr("userID")
            If Convert.IsDBNull(dr("userName")) = False Then lnq.RECEIVER_OFFICER_FULLNAME = dr("userName")
            If Convert.IsDBNull(dr("receiveTypeID")) = False Then lnq.RECEIVE_TYPE_ID = dr("receiveTypeID")
            If Convert.IsDBNull(dr("receiveTypeID")) = False Then lnq.RECEIVE_OBJECTIVE_ID = Convert.ToInt64(IIf(dr("receiveTypeID").ToString = "", Nothing, dr("receiveTypeID")))
            If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
            If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = Convert.ToInt64(IIf(dr("storageID").ToString = "", Nothing, dr("storageID")))
            If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
            If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_RECEIVE_ID = dr("id")
            If Convert.IsDBNull(dr("senderID")) = False Then lnq.REF_OLD_SEND_ID = dr("senderID")

            Dim ret As Boolean = lnq.InsertData(trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateLogFile("InsertNewInternalReceiver : " & lnq.ErrorMessage & Chr(13) & lnq.SqlInsert)
            End If
            lnq = Nothing
        Catch ex As Exception
            CreateLogFile("InsertNewInternalReceiver : " & ex.Message & " #### " & lnq.SqlInsert)
        End Try
    End Sub

    Public Sub InsertNewExtReceiver(ByVal dr As DataRow, ByVal vID As Long)
        Dim lnq As New TABLE.DocumentExtReceiverLinq
        Try
            Dim trans As New Utilities.TransactionDB
            trans.CreateTransaction(Utilities.SqlDB.GetNewConnection)

            If Convert.IsDBNull(dr("createBy")) = False Then lnq.CREATE_BY = dr("createBy")
            If Convert.IsDBNull(dr("createDateTime")) = False Then lnq.CREATE_ON = Convert.ToDateTime(dr("createDateTime"))
            If Convert.IsDBNull(dr("modifyBy")) = False Then lnq.UPDATE_BY = dr("modifyBy")
            If Convert.IsDBNull(dr("modifyDateTime")) = False Then lnq.UPDATE_ON = Convert.ToDateTime(dr("modifyDateTime"))
            lnq.DOCUMENT_REGISTER_ID = vID
            If Convert.IsDBNull(dr("orgID")) = False Then lnq.ORGANIZATION_ID_SEND = dr("orgID")
            If Convert.IsDBNull(dr("orgName")) = False Then lnq.ORGANIZATION_NAME_SEND = dr("orgName")
            If Convert.IsDBNull(dr("orgNameAbb")) = False Then lnq.ORGANIZATION_APPNAME_SEND = dr("orgNameAbb")
            If Convert.IsDBNull(dr("createDateTime1")) = False Then lnq.SEND_DATE = Convert.ToDateTime(dr("createDateTime1"))
            If Convert.IsDBNull(dr("userID")) = False Then lnq.SENDER_OFFICER_USERNAME = dr("userID")
            If Convert.IsDBNull(dr("userName")) = False Then lnq.SENDER_OFFICER_FULLNAME = dr("userName")
            If Convert.IsDBNull(dr("publishID")) = False Then lnq.BOOKOUT_NO = dr("publishID")
            If Convert.IsDBNull(dr("CompanyID")) = False Then lnq.COMPANY_ID_RECEIVE = GetCompanyID(dr("CompanyID"), trans)
            If Convert.IsDBNull(dr("CompanyName")) = False Then lnq.COMPANY_NAME_RECEIVE = dr("CompanyName")
            If Convert.IsDBNull(dr("CompanyDocsystemID")) = False Then lnq.COMPANY_DOC_SYSTEM_ID = dr("CompanyDocsystemID")
            If Convert.IsDBNull(dr("userName1")) = False Then lnq.OFFICER_FULLNAME = dr("userName1")
            If Convert.IsDBNull(dr("userID1")) = False Then lnq.OFFICER_USERNAME = dr("userID1")
            If Convert.IsDBNull(dr("remark")) = False Then lnq.REMARKS = dr("remark")
            If Convert.IsDBNull(dr("slotNo")) = False Then lnq.SLOT_NO = dr("slotNo")
            If Convert.IsDBNull(dr("receiveStatusID")) = False Then lnq.RECEIVE_STATUS_ID = dr("receiveStatusID")
            If Convert.IsDBNull(dr("publishTypeID")) = False Then lnq.PUBLISH_TYPE_ID = dr("publishTypeID")
            If Convert.IsDBNull(dr("storageID")) = False Then lnq.ORGANIZATION_ID_STORAGE = IIf(dr("storageID").ToString = "", 0, dr("storageID").ToString)
            If Convert.IsDBNull(dr("storageName")) = False Then lnq.ORGANIZATION_NAME_STORAGE = dr("storageName")
            If Convert.IsDBNull(dr("expectFinishDateTime")) = False Then lnq.EXPECT_FINISH_DATE = dr("expectFinishDateTime")
            If Convert.IsDBNull(dr("maximumProcessingPeriod")) = False Then lnq.MAXIMUM_PROCESSING_PERIOD = dr("maximumProcessingPeriod")
            If Convert.IsDBNull(dr("approvalDateTime")) = False Then lnq.APPROVE_DATE = Convert.ToDateTime(dr("approvalDateTime"))
            If Convert.IsDBNull(dr("id")) = False Then lnq.REF_OLD_SEND_ID = dr("id")
            If Convert.IsDBNull(dr("id1")) = False Then lnq.REF_OLD_RECEIVE_ID = dr("id1")

            Dim ret As Boolean = lnq.InsertData(trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateLogFile("InsertNewExternalReceiver : " & lnq.ErrorMessage & Chr(13) & lnq.SqlInsert)
            End If
            lnq = Nothing
        Catch ex As Exception
            CreateLogFile("InsertNewExternalReceiver : " & ex.Message & " ### " & lnq.SqlInsert)
        End Try
    End Sub

    Private Function GetGroupTitleID(ByVal DocCatID As String, ByVal trans As Utilities.TransactionDB) As String
        Dim sql As String = ""
        sql += " select id from group_title where ref_old_id='" & DocCatID & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Dim ret As String = "0"
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("id")
            dt.Dispose()
            dt = Nothing
        End If

        Return ret
    End Function

    Public Function GetOfficerIDByUserName(ByVal UserName As String, ByVal trans As Utilities.TransactionDB) As String
        Dim sql As String = ""
        sql += " select id from officer where username='" & UserName & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Dim ret As String = "0"
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("id")
            dt.Dispose()
            dt = Nothing
        End If

        Return ret
    End Function

    Public Function GetUsernameByOfficerID(ByVal vID As Long, ByVal trans As Utilities.TransactionDB) As String
        Dim sql As String = ""
        sql += " select username from officer where id='" & vID & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("username")
            dt.Dispose()
            dt = Nothing
        End If

        Return ret
    End Function

    Public Function GetOrgByAbbName(ByVal vAbbName As String, ByVal trans As Utilities.TransactionDB) As DataTable
        Dim sql As String = ""
        sql += " select * from organization where name_abb='" & vAbbName & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Return dt
    End Function




    Private Function GetOfficerFullNameByUserName(ByVal UserName As String, ByVal trans As Utilities.TransactionDB) As String
        Dim sql As String = ""
        sql += " select first_name + ' ' + last_name staff_name from officer where username='" & UserName & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("staff_name")
            dt.Dispose()
            dt = Nothing
        End If

        Return ret
    End Function

    Private Function GetCompanyID(ByVal CompanyID As String, ByVal trans As Utilities.TransactionDB) As String
        Dim sql As String = ""
        sql += " select id from company where ref_old_id='" & CompanyID & "'"
        Dim dt As DataTable = Utilities.SqlDB.ExecuteTable(sql, trans.Trans)

        Dim ret As String = "0"
        If CompanyID.Trim <> "" Then
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("id")
                dt.Dispose()
                dt = Nothing
            Else
                ret = "-1"
            End If
        End If
        Return ret
    End Function

    Public Sub CreateLogFile(ByVal TextMsg As String)
        Dim FILE_NAME As String = Application.StartupPath & "\" & DateTime.Now.ToString("yyyyyMMddHH") & ".log"
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & TextMsg & Chr(13) & Chr(13))
        objWriter.Close()
    End Sub
End Module
