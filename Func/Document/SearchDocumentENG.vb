Imports Linq.TABLE
Namespace Document
    'dt = getdatatable("SELECT  * FROM    v_doscinsidereceive")
    Public Class SearchDocumentENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property


        Public Function SearchDocumentReceive(ByVal whText As String) As DataTable
            'Dim trans As New Linq.Common.Utilities
            'trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            Dim sql As String = ""
            sql += " SELECT dr.book_no AS bookno, dr.register_date AS date_register, dr.title_name AS book_title, " & vbNewLine
            sql += " isnull(dr.company_name, c.thaiName) AS book_from,  ir.id, " & vbNewLine
            sql += " ir.document_register_id,  ir.sender_officer_fullname AS user_send, ir.send_date AS date_send, " & vbNewLine
            sql += " (select count(id) from document_attach_file where document_register_id=dr.id) count_file, " & vbNewLine
            sql += " ir.organization_appname_send, oj.objective_name"
            sql += " FROM DOCUMENT_REGISTER  dr" & vbNewLine
            sql += " INNER JOIN DOCUMENT_INT_RECEIVER ir ON dr.id = ir.document_register_id" & vbNewLine
            sql += "            and ir.id=(select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)"
            sql += " LEFT JOIN COMPANY c on c.id=dr.company_id" & vbNewLine
            sql += " LEFT JOIN OBJECTIVE oj on oj.id=ir.receive_objective_id" & vbNewLine
            sql += " where ir.receive_date is null and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive & "' " & vbNewLine
            sql += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome & "'" & vbNewLine
            sql += whText
            sql += " order by dr.book_no desc" & vbNewLine

            dt = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            Return dt
        End Function

        Public Function SearchDocumentSend(ByVal whText As String, ByVal uPara As Para.Common.UserProfilePara, Optional ByVal IsSysSendBack As Boolean = False) As DataTable
            Dim ScWh As String = whText
            whText += " and (ir.organization_id_receive = '" & uPara.ORG_DATA.ID & "' or ir.organization_appname_receive='" & uPara.ORG_DATA.NAME_ABB & "') " & vbNewLine
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                whText += " and isnull(dr.officer_id_possess,'" & uPara.OFFICER_DATA.ID & "') = '" & uPara.OFFICER_DATA.ID & "' " & vbNewLine
            End If
            'whText += " and ir.is_forward = 'N'" & vbNewLine 'กรณีเจ้าหน้าที่รับมาแล้วมีการส่งต่อให้ตัวเอง ก็ไม่ต้องแสดงข้อมูลในหน้านี้อีก จนกว่าจะลงรับภายใน
            whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' " & vbNewLine
            whText += " and ir.receive_date is not null " & vbNewLine
            If IsSysSendBack = False Then
                whText += " and ir.receive_status_id in ('" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received & "','" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBackSystem & "')"
            End If

            Dim sql As String = GetSqlQuerySearchDocument(whText, uPara.ORG_DATA.ID, Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain, ScWh)
            'Dim trans As New Common.DbTrans
            'trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Private Function GetSqlQuerySearchDocument(ByVal whText As String, ByVal OrgID As String, ByVal DocStatusID As String, ByVal ScWh As String) As String
            Dim sql As String = ""
            sql += " select dr.id, dr.book_no, dr.request_no, dr.title_name book_title, " & vbNewLine
            sql += " dr.register_date date_register, ir.sender_officer_fullname user_send, ir.sender_officer_username, ir.organization_id_send," & vbNewLine
            sql += " ir.organization_name_send, ir.organization_appname_send, ds.doc_status_name, ir.send_date, ir.organization_appname_receive,ir.organization_id_receive, " & vbNewLine
            sql += " ir.receiver_officer_fullname user_receive, ir.receiver_officer_username, ir.receive_date, ds.doc_status_name, " & vbNewLine
            sql += " ir.receive_type_id, ir.receive_objective_id, ir.remarks, '' folder_name,"
            sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, ir.id document_int_receiver_id, " & vbNewLine
            sql += " (select count(id) from document_attach_file where document_register_id=dr.id) count_file" & vbNewLine
            sql += " from DOCUMENT_REGISTER dr" & vbNewLine
            sql += " left join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id" & vbNewLine
            sql += "            and ir.id = (select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)" & vbNewLine
            sql += " inner join DOC_STATUS ds on ds.id=dr.doc_status_id " & vbNewLine
            sql += " where " & whText & vbNewLine

            If OrgID <> "0" Then
                If DocStatusID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain Then
                    'เห็นเฉพาะงานค้าง
                    sql += " Union all"
                    sql += " select dr.id, dr.book_no, dr.request_no, dr.title_name book_title, " & vbNewLine
                    sql += " dr.register_date date_register, ir.sender_officer_fullname user_send, ir.sender_officer_username, ir.organization_id_send," & vbNewLine
                    sql += " ir.organization_name_send, ir.organization_appname_send, ds.doc_status_name, ir.send_date, ir.organization_appname_receive,ir.organization_id_receive, " & vbNewLine
                    sql += " ir.receiver_officer_fullname user_receive, ir.receiver_officer_username, ir.receive_date, ds.doc_status_name, " & vbNewLine
                    sql += " ir.receive_type_id, ir.receive_objective_id, ir.remarks, '' folder_name,"
                    sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, ir.id document_int_receiver_id, " & vbNewLine
                    sql += " (select count(id) from document_attach_file where document_register_id=dr.id) count_file " & vbNewLine
                    sql += " from DOCUMENT_REGISTER dr" & vbNewLine
                    sql += " left join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id" & vbNewLine
                    sql += " inner join DOC_STATUS ds on ds.id=dr.doc_status_id " & vbNewLine
                    sql += " where dr.organization_id_owner = '" & OrgID & "' and dr.doc_status_id='" & DocStatusID & "'" & vbNewLine
                    sql += " and (select count(id) from document_int_receiver where document_register_id=dr.id) = 0" & vbNewLine
                    If ScWh.Trim <> "" Then
                        sql += " and " & ScWh & vbNewLine
                    End If
                End If
            End If
            sql += " order by  book_no desc" & vbNewLine

            Return sql
        End Function

        Public Function SendInternal(ByVal DocRegisID As String, ByVal SendPara As Para.Document.SendInternalPara, ByVal uPara As Para.Common.UserProfilePara) As Boolean
            Dim ret As Boolean = False

            Dim trans As New Linq.Common.Utilities.TransactionDB
            If trans.CreateTransaction() = True Then
                For Each vID As String In Split(DocRegisID, ",")
                    Dim dLnq As New DocumentRegisterLinq
                    dLnq.GetDataByPK(vID, trans.Trans)
                    If SendPara.ORG_RECEIVE_ID = uPara.ORG_DATA.ID Then
                        'ถ้าผู้รับกับผู้ส่งอยู่หน่วยงานเดียวกันก็ให้เป็นงานค้างของผู้รับเลข ไม่ต้องลงรับภายในอีก
                        dLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                    Else
                        dLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome
                    End If
                    dLnq.ORGANIZATION_ID_PROCESS = SendPara.ORG_RECEIVE_ID
                    dLnq.ORGANIZATION_NAME_PROCESS = SendPara.ORG_NAME
                    dLnq.ORGANIZATION_ABBNAME_PROCESS = SendPara.ORG_ABB_NAME
                    dLnq.OFFICER_ID_POSSESS = SendPara.STAFF_APPROVE_ID
                    dLnq.OFFICER_NAME_POSSESS = SendPara.STAFF_APPROVE_FULLNAME

                    dLnq.ORGANIZATION_ID_OWNER = SendPara.ORG_RECEIVE_ID
                    dLnq.ORGANIZATION_NAME = SendPara.ORG_NAME
                    dLnq.ORGANIZATION_APPNAME = SendPara.ORG_ABB_NAME
                    dLnq.OFFICER_ID_APPROVE = SendPara.STAFF_APPROVE_ID
                    dLnq.OFFICER_NAME = SendPara.STAFF_APPROVE_FULLNAME

                    ret = dLnq.UpdateByPK(uPara.UserName, trans.Trans)
                    If ret = True Then
                        Dim iPara As New Para.TABLE.DocumentIntReceiverPara
                        iPara.DOCUMENT_REGISTER_ID = dLnq.ID
                        iPara.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                        iPara.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_THAI_NAME
                        iPara.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_RECEIVE   'ชื่อย่อหน่วยงานผู้ส่ง
                        iPara.SEND_DATE = DateTime.Now
                        iPara.SENDER_OFFICER_USERNAME = uPara.UserName
                        iPara.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                        iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive
                        iPara.ORGANIZATION_ID_RECEIVE = SendPara.ORG_RECEIVE_ID
                        iPara.ORGANIZATION_NAME_RECEIVE = SendPara.ORG_NAME
                        iPara.ORGANIZATION_APPNAME_RECEIVE = SendPara.ORG_ABB_NAME   'ชื่อย่อหน่วยงานผู้รับ
                        iPara.RECEIVER_OFFICER_USERNAME = SendPara.STAFF_USERNAME
                        iPara.RECEIVER_OFFICER_FULLNAME = SendPara.STAFF_FULLNAME
                        iPara.RECEIVE_OBJECTIVE_ID = SendPara.OBJECTIVE_ID
                        iPara.RECEIVE_TYPE_ID = SendPara.OBJECTIVE_ID
                        iPara.REMARKS = SendPara.REMARKS

                        If SendPara.ORG_RECEIVE_ID = uPara.ORG_DATA.ID Then
                            'ถ้าผู้รับกับผู้ส่งอยู่หน่วยงานเดียวกัน
                            iPara.RECEIVE_DATE = DateTime.Now
                            iPara.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                        End If

                        Dim iEng As New DocumentRegisterENG
                        ret = iEng.SaveInsideSend(uPara.UserName, iPara, trans)
                        iPara = Nothing

                        If ret = False Then
                            _err = iEng.ErrorMessage
                            iEng = Nothing
                            Exit For
                        End If
                        iEng = Nothing
                    Else
                        _err = dLnq.ErrorMessage
                        dLnq = Nothing
                        Exit For
                    End If
                    dLnq = Nothing
                Next
            End If
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Function ReceiveInternal(ByVal uPara As Para.Common.UserProfilePara, ByVal dt As DataTable, ByVal StatusID As String) As Boolean
            Dim ret As Boolean = False
            If uPara.UserName.Trim <> "" Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                If trans.CreateTransaction() = True Then
                    For Each dr As DataRow In dt.Rows
                        Dim drLnq As New Linq.TABLE.DocumentRegisterLinq
                        drLnq.GetDataByPK(Convert.ToInt64(dr("DOCUMENT_REGISTER_ID")), trans.Trans)
                        drLnq.OFFICER_ID_POSSESS = uPara.OFFICER_DATA.ID
                        drLnq.OFFICER_NAME_POSSESS = uPara.FirstName & " " & uPara.LastName
                        drLnq.ORGANIZATION_ID_PROCESS = uPara.ORG_DATA.ID
                        drLnq.ORGANIZATION_NAME_PROCESS = uPara.ORG_DATA.ORG_NAME
                        drLnq.ORGANIZATION_ABBNAME_PROCESS = uPara.ORG_DATA.NAME_ABB
                        drLnq.DOC_STATUS_ID = StatusID

                        ret = drLnq.UpdateByPK(uPara.UserName, trans.Trans)
                        If ret = True Then
                            Dim InLnq As New Linq.TABLE.DocumentIntReceiverLinq
                            InLnq.GetDataByPK(Convert.ToInt64(dr("DOCUMENT_INT_RECEIVER_ID")), trans.Trans)
                            InLnq.RECEIVE_DATE = DateTime.Now
                            InLnq.RECEIVER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                            InLnq.RECEIVER_OFFICER_USERNAME = uPara.UserName
                            InLnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                            ret = InLnq.UpdateByPK(uPara.UserName, trans.Trans)

                            If ret = False Then
                                _err = InLnq.ErrorMessage
                                InLnq = Nothing
                                Exit For
                            End If
                            InLnq = Nothing
                        End If
                        drLnq = Nothing
                    Next

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                End If
            End If

            Return ret
        End Function

        Public Function ReceiveInternal(ByVal uPara As Para.Common.UserProfilePara, ByVal dt As DataTable) As Boolean
            Return ReceiveInternal(uPara, dt, Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain)
        End Function

        Public Function ReceiveIncome(ByVal uPara As Para.Common.UserProfilePara, ByVal dt As DataTable)
            Dim ret As Boolean = False

            For Each dr As DataRow In dt.Rows
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim InLnq As New Linq.TABLE.DocumentIntReceiverLinq
                InLnq.GetDataByPK(Convert.ToInt64(dr("DOCUMENT_INT_RECEIVER_ID")), trans.Trans)
                InLnq.RECEIVE_DATE = DateTime.Now
                InLnq.RECEIVER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                InLnq.RECEIVER_OFFICER_USERNAME = uPara.UserName
                InLnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                ret = InLnq.UpdateByPK(uPara.UserName, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    _err = InLnq.ErrorMessage

                    Dim lg As New Common.LogEng
                    lg.SaveErrLog(uPara.UserName, _err)
                    lg = Nothing
                    Exit For
                End If
            Next

            Return ret
        End Function

        Public Function SearchByCondition(ByVal whText As String, ByVal ImpText As String) As DataTable
            Dim sql As String = ""
            sql += " select dr.id, dr.book_no, dr.title_name, dr.request_no, dr.register_date, " & vbNewLine
            sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, dr.expect_finish_date, dr.close_date, " & vbNewLine
            sql += " isnull(dr.officer_name_possess, dr.officer_name) officer_name_process, " & vbNewLine
            sql += " case when o.id is null " & vbNewLine
            sql += " then isnull(dr.officer_name_possess, dr.officer_name)" & vbNewLine
            sql += " else" & vbNewLine
            sql += " 	o.first_name + ' ' + o.last_name end officer_name_approve, " & vbNewLine
            sql += " ds.doc_status_name, dr.bookout_no, dr.organization_appname," & vbNewLine
            sql += " (select count(id) from document_attach_file where document_register_id=dr.id) count_file, " & vbNewLine
            sql += " 'DOCUMENT_REGISTER' doc_group"
            sql += " from DOCUMENT_REGISTER dr" & vbNewLine
            sql += " inner join doc_status ds on ds.id=dr.doc_status_id " & vbNewLine
            sql += " inner join group_title gt on gt.id=dr.group_title_id " & vbNewLine
            sql += " left join officer o on o.id=dr.officer_id_approve " & vbNewLine
            sql += " where 1=1 " & whText
            sql += " union all " & vbNewLine

            sql += " select dr.id, dr.book_no, dr.title_name, '' request_no, dr.register_date, " & vbNewLine
            sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, dr.expected_finish_date, dr.close_date, " & vbNewLine
            sql += " o.first_name + ' ' + o.last_name officer_name_process,o.first_name + ' ' + o.last_name officer_name_approve, " & vbNewLine
            sql += " dr.book_status doc_status_name,dr.book_out_no, dr.org_code_owner organization_appname,0 count_file," & vbNewLine
            sql += " 'DOCUMENT_IMPORT_LASTSTATUS' doc_group" & vbNewLine
            sql += " from DOCUMENT_IMPORT_LASTSTATUS dr" & vbNewLine
            sql += " left join OFFICER o on o.identity_card=dr.staff_id_process" & vbNewLine
            sql += " where 1=1 " & ImpText
            sql += " order by dr.register_date desc,dr.book_no"

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function SearchByOfficerMovement(ByVal whText As String) As DataTable
            Dim sql As String = ""
            sql += " select dr.id, dr.book_no, dr.title_name, dr.request_no, dr.register_date, " & vbNewLine
            sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, dr.expect_finish_date, dr.close_date, " & vbNewLine
            sql += " isnull(dr.officer_name_possess, dr.officer_name) officer_name_process, "
            sql += " case when o.id is null " & vbNewLine
            sql += " then isnull(dr.officer_name_possess, dr.officer_name)" & vbNewLine
            sql += " else" & vbNewLine
            sql += " 	o.first_name + ' ' + o.last_name end officer_name_approve," & vbNewLine
            sql += " ds.doc_status_name, dr.bookout_no, dr.organization_appname" & vbNewLine
            sql += " from DOCUMENT_REGISTER dr" & vbNewLine
            sql += " inner join doc_status ds on ds.id=dr.doc_status_id " & vbNewLine
            sql += " inner join group_title gt on gt.id=dr.group_title_id " & vbNewLine
            sql += " inner join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id and ir.id=(select top 1 id from document_int_receiver ir where document_register_id=dr.id order by send_date desc)"
            sql += " left join OFFICER o on o.username = ir.receiver_officer_username " & vbNewLine
            sql += " where 1=1 " & whText
            sql += " order by dr.register_date desc,dr.book_no"

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function SearchBookSendOut(ByVal whText As String, ByVal ImpText As String) As DataTable
            Dim sql As String = ""
            sql += " select dr.id, er.bookout_no, dr.book_no, dr.title_name, er.company_name_receive, " & vbNewLine
            sql += " er.send_date, er.officer_fullname," & vbNewLine
            sql += " (select count(id) from document_attach_file where document_register_id=dr.id) count_file, " & vbNewLine
            sql += " 'DOCUMENT_REGISTER' doc_group"
            sql += " from DOCUMENT_REGISTER dr" & vbNewLine
            sql += " inner join doc_status ds on ds.id=dr.doc_status_id " & vbNewLine
            sql += " inner join group_title gt on gt.id=dr.group_title_id " & vbNewLine
            sql += " left join DOCUMENT_EXT_RECEIVER er on er.document_register_id=dr.id " & vbNewLine
            sql += " where 1=1 " & whText
            sql += " union all" & vbNewLine
            sql += " select dr.id, dr.book_out_no bookout_no, dr.book_no, dr.title_name,dr.company_name company_name_receive," & vbNewLine
            sql += " dr.close_date send_date,o.first_name + ' ' + o.last_name officer_fullname, 0 count_file," & vbNewLine
            sql += " 'DOCUMENT_IMPORT_LASTSTATUS' doc_group" & vbNewLine
            sql += " from DOCUMENT_IMPORT_LASTSTATUS dr" & vbNewLine
            sql += " left join OFFICER o on o.identity_card=dr.staff_id_process" & vbNewLine
            sql += " where 1=1 " & ImpText
            sql += " order by bookout_no"

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function SearchAllDocument(ByVal whText As String, ByVal irText As String, ByVal erText As String, ByVal OrgID As Long, ByVal StatusID As String) As DataTable
            Dim sql As String = ""
            If StatusID <> "-2" Then
                sql += " select dr.id, dr.book_no, dr.title_name book_title, dr.request_no, " & vbNewLine
                sql += " dr.register_date date_register, ir.sender_officer_fullname user_send," & vbNewLine
                sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, 'Inbox' folder_name," & vbNewLine
                sql += " ir.organization_name_send, dr.bookout_no, " & vbNewLine
                sql += " case when ir.is_forward='Y' then -1 " & vbNewLine
                sql += "      else dr.doc_status_id end doc_status_id, " & vbNewLine
                sql += " case when ir.is_forward='Y' then 'ส่งภายใน' " & vbNewLine
                sql += "      else  ds.doc_status_name end doc_status_name " & vbNewLine
                sql += " from DOCUMENT_REGISTER dr" & vbNewLine
                sql += " left join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id" & vbNewLine
                sql += "            and ir.id=(select MAX(id) from DOCUMENT_INT_RECEIVER"
                sql += "                        where document_register_id = dr.id )"
                sql += " inner join DOC_STATUS ds on ds.id=dr.doc_status_id" & vbNewLine
                sql += " where " & whText & irText & vbNewLine
                'sql += " UNION ALL" & vbNewLine
            ElseIf StatusID = "-2" Then
                sql = " select dr.id, dr.book_no, dr.title_name book_title, dr.request_no, " & vbNewLine
                sql += " dr.register_date date_register, er.sender_officer_fullname user_send," & vbNewLine
                sql += " dr.company_name, dr.company_doc_no, dr.company_doc_date, 'Inbox' folder_name," & vbNewLine
                sql += " er.organization_name_send, " & vbNewLine
                sql += " case when dr.bookout_no is not null then -2 " & vbNewLine
                sql += "      else dr.doc_status_id end doc_status_id, " & vbNewLine
                sql += " case when dr.bookout_no is not null then 'ส่งภายนอก' " & vbNewLine
                sql += "      else  ds.doc_status_name end doc_status_name " & vbNewLine
                sql += " from DOCUMENT_REGISTER dr" & vbNewLine
                sql += " inner join DOC_STATUS ds on ds.id=dr.doc_status_id " & vbNewLine
                sql += " inner join DOCUMENT_EXT_RECEIVER er on er.document_register_id=dr.id" & vbNewLine
                sql += "        and er.id=(select max(id) from document_ext_receiver where document_register_id=dr.id and organization_id_send='" & OrgID & "')"
                sql += " where " & whText & erText & vbNewLine
                sql += " order by dr.register_date" & vbNewLine
            End If

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function SearchDocumentSendBack(ByVal whText As String) As DataTable
            'รายการที่จะตีกลับ คือรายการที่ลงรับไปแล้ว และต้องการจะตีกลับไปยังต้นทาง
            whText += " and ir.receive_date is not null "
            whText += " and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received & "'"
            whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"

            Dim sql As String = GetSqlQuerySearchDocument(whText, "0", "0", "")
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function SearchDocumentRetrieve(ByVal whText As String, ByVal uPara As Para.Common.UserProfilePara) As DataTable
            'รายการที่จะดึงกลับ คือรายการที่ส่งแล้ว แต่ปลายทางยังไม่ได้ลงรับ
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                whText += " and ir.sender_officer_username = '" & uPara.UserName & "'"
            End If
            whText += " and ir.is_forward = 'N'"   'กรณีเจ้าหน้าที่รับมาแล้วมีการส่งต่อให้ตัวเอง ก็ไม่ต้องแสดงข้อมูลในหน้านี้อีก จนกว่าจะลงรับภายใน
            whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobIncome & "'"
            whText += " and ir.receive_date is null "
            whText += " and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendNoReceive & "'"
            whText += " and ir.organization_id_receive <> ir.organization_id_send"

            Dim sql As String = GetSqlQuerySearchDocument(whText, "0", "0", "")
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function SearchDocumentCancelCloseJob(ByVal whText As String) As DataTable
            'รายการที่จะยกเลิกจบงาน คือรายการงานถือครองที่จบงานไปแล้ว

            Dim sql As String = GetSqlQuerySearchDocument(whText, "0", "0", "")
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function SearchDocumentToDoList(ByVal whText As String, ByVal OrgID As String, ByVal DocStatusID As String) As DataTable
            'รายการที่ค้นหาในหน้า ToDoList

            Dim sql As String = GetSqlQuerySearchDocument(whText, OrgID, DocStatusID, "")
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New DocumentRegisterLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetElecDocWaitRegis(ByVal wh As String, ByVal uPara As Para.Common.UserProfilePara) As DataTable
            Dim sqltmp As String = ""
            sqltmp = "select t1.id as rowid,'1' as rownum,doc_no,isnull(doc_title,'-') doc_title,doc_create_date,org_name,"
            sqltmp += "'~/WebApp/' + ds.doc_form_url + 'docformid=' + rtrim(convert(char,doc_type)) + '&rowid=' + rtrim(convert(char,t1.id)) + "
            sqltmp += " case doc_approved when '1' then '&approved_mode=yes' else '&approved_mode=no' end as url_field,"
            sqltmp += " case when doc_status=0 and t1.doc_obj_to=2 then 'รออนุมัติ' "
            sqltmp += " when doc_status=1 then 'ยังไม่ได้ส่ง' "
            sqltmp += " when doc_status=2 then 'ส่งแล้ว' "
            sqltmp += " when doc_status=3 then 'รอลงทะเบียน' "
            sqltmp += " when doc_status=4 then 'ไม่อนุมัติ' "
            sqltmp += " when doc_status=9 then 'จบงาน' else '' end as process, "

            sqltmp += " case doc_status "
            sqltmp += " when 0 then 1 "
            sqltmp += " when 1 then 1 "
            sqltmp += " when 2 then 1 "
            sqltmp += " when 3 then 0  "
            sqltmp += " when 4 then 0 else '' end as send_status, "

            sqltmp += " case doc_status "
            sqltmp += " when 0 then 0 "
            sqltmp += " when 1 then 0 "
            sqltmp += " when 2 then 0 "
            sqltmp += " when 3 then 1 "
            sqltmp += " when 4 then 1 else '' end as nosend_status "

            sqltmp += " from DOC_TRANS t1 "
            sqltmp += " left join ORGANIZATION t2 on str(t2.id) = doc_TitleOwner "

            sqltmp += " inner join DOC_SUBCATEGORY ds on ds.id=t1.doc_type"
            sqltmp += " where 1=1 "
            sqltmp += " and doc_to in (select id from officer where organization_id = '" & uPara.ORG_DATA.ID & "')"
            If Engine.Auth.LogInEng.CheckUserRole(uPara.UserName, Para.Common.Utilities.Constant.RoleID.RoleAdministration) = False Then
                sqltmp = sqltmp + " and doc_to = '" + uPara.OFFICER_DATA.ID.ToString + "'"
            End If
            sqltmp = sqltmp + " and doc_status = '" & Para.Common.Utilities.Constant.ElecDocStatus.cfg_docapproved & "' "
            sqltmp = sqltmp + " and doc_obj_to = '" & Para.Common.Utilities.Constant.DocObjective.ObjApprove & "' "
            sqltmp = sqltmp + " and is_send = 'N' "
            sqltmp = sqltmp + " and t1.id not in (select electronic_doc_id from document_register)"
            sqltmp += wh
            sqltmp = sqltmp + " order by t1.id desc"

            Dim dt As New DataTable
            dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sqltmp)
            Return dt
        End Function

        Public Function GetDocumentSendList(ByVal vID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim ret As New DataTable
            Dim sql As String = ""
            sql += " select ir.receiver_officer_fullname user_receive, ir.receiver_officer_username ,ir.organization_appname_receive, ir.organization_id_receive, ir.receive_date , " & vbNewLine
            sql += " ir.sender_officer_fullname user_send, ir.organization_appname_send, ir.send_date, ir.remarks " & vbNewLine
            sql += " from DOCUMENT_REGISTER dr" & vbNewLine
            sql += " left join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id" & vbNewLine
            sql += " where dr.id = '" & vID & "'" & vbNewLine
            sql += " order by ir.send_date desc, ir.id desc " & vbNewLine

            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            ret = lnq.GetListBySql(sql, trans.Trans)
            Return ret
        End Function
    End Class
End Namespace

