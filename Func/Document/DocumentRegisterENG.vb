Imports Para.Common.Utilities
Imports Engine.Common

Namespace Document
    Public Class DocumentRegisterENG
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Function GetDataListBySql(ByVal sql As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)
            lnq = Nothing
            Return dt
        End Function

        Public Function GetDataListBySql(ByVal sql As String) As DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetDocumentPara(ByVal vID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As Para.TABLE.DocumentRegisterPara
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim p As New Para.TABLE.DocumentRegisterPara
            p = lnq.GetParameter(vID, trans.Trans)
            lnq = Nothing
            Return p
        End Function

        Public Function GetDocumentParaByBookNo(ByVal vBookNo As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Para.TABLE.DocumentRegisterPara
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim p As New Para.TABLE.DocumentRegisterPara
            p = lnq.GetParameterByBookNo(vBookNo, trans.Trans)
            lnq = Nothing
            Return p
        End Function

        Public Function ChkDupByBookNo(ByVal BookNo As String, ByVal vID As Long) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            ret = lnq.ChkDuplicateByBOOK_NO(BookNo, vID, Nothing)
            lnq = Nothing

            Return ret
        End Function

        Public Function GetAttachFileList(ByVal vID As Long) As DataTable
            Dim lnq As New Linq.TABLE.DocumentAttachFileLinq
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList("document_register_id=" & vID, "id", Nothing)
            lnq = Nothing
            'trans.CommitTransaction()
            Return dt
        End Function
        Public Function GetAttachFilePara(ByVal vAttachID As Long) As Para.TABLE.DocumentAttachFilePara
            Dim lnq As New Linq.TABLE.DocumentAttachFileLinq
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CommitTransaction()
            Dim p As New Para.TABLE.DocumentAttachFilePara
            p = lnq.GetParameter(vAttachID, Nothing)
            lnq = Nothing
            'trans.CommitTransaction()
            Return p
        End Function

        Public Function GetDocScanTmpList(ByVal vJobID As Long, ByVal vRefID As Long) As DataTable
            Dim lnq As New Linq.TABLE.DocumentScanTempLinq
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()

            Dim fSql As String = ""
            fSql += " select ds.id DOCUMENT_SCAN_TEMP_ID, ds.file_byte, ds.file_extention, ds.description, ds.ref_id, ds.ref_table"
            fSql += " from DOCUMENT_SCAN_TEMP ds"
            fSql += " inner join DOCUMENT_SCAN_JOB dj on dj.id=ds.document_scan_job_id"
            fSql += " where dj.id= '" & vJobID & "' and dj.ref_id = '" & vRefID & "'"

            Dim dt As New DataTable
            dt = lnq.GetListBySql(fSql, Nothing)
            'trans.CommitTransaction()
            Return dt
        End Function

        Public Function SaveOutsideSend(ByVal LoginName As String, ByVal para As Para.TABLE.DocumentExtReceiverPara, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.DOCUMENT_REGISTER_ID = para.DOCUMENT_REGISTER_ID
            lnq.ORGANIZATION_ID_SEND = para.ORGANIZATION_ID_SEND
            lnq.ORGANIZATION_NAME_SEND = para.ORGANIZATION_NAME_SEND
            lnq.ORGANIZATION_APPNAME_SEND = para.ORGANIZATION_APPNAME_SEND
            lnq.SEND_DATE = para.SEND_DATE
            lnq.SENDER_OFFICER_USERNAME = para.SENDER_OFFICER_USERNAME
            lnq.SENDER_OFFICER_FULLNAME = para.SENDER_OFFICER_FULLNAME
            lnq.BOOKOUT_NO = para.BOOKOUT_NO
            lnq.COMPANY_ID_RECEIVE = para.COMPANY_ID_RECEIVE
            lnq.COMPANY_REGIS_NO = para.COMPANY_REGIS_NO
            lnq.COMPANY_NAME_RECEIVE = para.COMPANY_NAME_RECEIVE
            lnq.COMPANY_DOC_SYSTEM_ID = para.COMPANY_DOC_SYSTEM_ID
            lnq.OFFICER_USERNAME = para.OFFICER_USERNAME
            lnq.OFFICER_FULLNAME = para.OFFICER_FULLNAME
            lnq.REMARKS = para.REMARKS
            lnq.SLOT_NO = para.SLOT_NO
            lnq.RECEIVE_STATUS_ID = para.RECEIVE_STATUS_ID
            lnq.PUBLISH_TYPE_ID = para.PUBLISH_TYPE_ID
            lnq.ORGANIZATION_ID_STORAGE = para.ORGANIZATION_ID_STORAGE
            lnq.ORGANIZATION_NAME_STORAGE = para.ORGANIZATION_NAME_STORAGE
            lnq.EXPECT_FINISH_DATE = para.EXPECT_FINISH_DATE
            lnq.MAXIMUM_PROCESSING_PERIOD = para.MAXIMUM_PROCESSING_PERIOD
            lnq.APPROVE_DATE = para.APPROVE_DATE
            lnq.REF_OLD_RECEIVE_ID = para.REF_OLD_RECEIVE_ID
            lnq.REF_OLD_SEND_ID = para.REF_OLD_SEND_ID
            lnq.IS_SEND_THEGIF = para.IS_SEND_THEGIF

            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(LoginName, trans.Trans)
            Else
                ret = lnq.InsertData(LoginName, trans.Trans)
                para.ID = lnq.ID
            End If
            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Function SaveSendBack(ByVal uPara As Para.Common.UserProfilePara, ByVal vOldID As Long, ByVal SendBackReason As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            'เปลี่ยนสถานะของ Record เดิมเป็น ตีกลับ
            Dim lnq As New Linq.TABLE.DocumentIntReceiverLinq
            lnq.GetDataByPK(vOldID, trans.Trans)
            lnq.SENDBACK_REASON = SendBackReason
            lnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.SendBack
            lnq.IS_FORWARD = "Y"

            ret = lnq.UpdateByPK(uPara.UserName, trans.Trans)
            If ret = True Then
                'เพิ่มข้อมูล Record ใหม่เพื่อส่งให้กับคนเดิม
                Dim NewLnq As New Linq.TABLE.DocumentIntReceiverLinq
                Dim DateNow As DateTime = DateTime.Now
                NewLnq.DOCUMENT_REGISTER_ID = lnq.DOCUMENT_REGISTER_ID
                NewLnq.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                NewLnq.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_NAME
                NewLnq.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_ABB
                NewLnq.SEND_DATE = DateNow
                NewLnq.RECEIVE_DATE = DateNow
                NewLnq.SENDER_OFFICER_USERNAME = uPara.UserName
                NewLnq.SENDER_OFFICER_FULLNAME = uPara.TitleName & uPara.FirstName & " " & uPara.LastName
                NewLnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                NewLnq.ORGANIZATION_ID_RECEIVE = lnq.ORGANIZATION_ID_SEND
                NewLnq.ORGANIZATION_NAME_RECEIVE = lnq.ORGANIZATION_NAME_SEND
                NewLnq.ORGANIZATION_APPNAME_RECEIVE = lnq.ORGANIZATION_APPNAME_SEND
                NewLnq.RECEIVER_OFFICER_USERNAME = lnq.SENDER_OFFICER_USERNAME
                NewLnq.RECEIVER_OFFICER_FULLNAME = lnq.SENDER_OFFICER_FULLNAME
                NewLnq.RECEIVE_TYPE_ID = lnq.RECEIVE_TYPE_ID
                NewLnq.RECEIVE_OBJECTIVE_ID = lnq.RECEIVE_OBJECTIVE_ID
                NewLnq.REMARKS = SendBackReason
                NewLnq.ORGANIZATION_ID_STORAGE = lnq.ORGANIZATION_ID_STORAGE
                NewLnq.ORGANIZATION_NAME_STORAGE = lnq.ORGANIZATION_NAME_STORAGE
                NewLnq.REF_OLD_SEND_ID = lnq.REF_OLD_SEND_ID
                NewLnq.REF_OLD_RECEIVE_ID = lnq.REF_OLD_RECEIVE_ID
                NewLnq.DOCUMENT_STATEMENT = lnq.DOCUMENT_STATEMENT
                NewLnq.DOCUMENT_INT_TYPE = lnq.DOCUMENT_INT_TYPE
                NewLnq.MODULE_FOLDER_ID = lnq.MODULE_FOLDER_ID
                NewLnq.IS_FORWARD = "N"
                'NewLnq.SENDBACK_REASON = lnq.SENDBACK_REASON
                'NewLnq.RETRIEVE_REASON = lnq.RETRIEVE_REASON

                ret = NewLnq.InsertData(uPara.UserName, trans.Trans)
                If ret = True Then
                    'Update ข้อมูลผู้ Process
                    Dim dLnq As New Linq.TABLE.DocumentRegisterLinq
                    dLnq.GetDataByPK(lnq.DOCUMENT_REGISTER_ID, trans.Trans)
                    dLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                    dLnq.ORGANIZATION_ID_PROCESS = NewLnq.ORGANIZATION_ID_RECEIVE
                    dLnq.ORGANIZATION_NAME_PROCESS = NewLnq.ORGANIZATION_NAME_RECEIVE
                    dLnq.ORGANIZATION_ABBNAME_PROCESS = NewLnq.ORGANIZATION_APPNAME_RECEIVE

                    Dim oLnq As New Para.TABLE.OfficerPara
                    Dim oEng As New Engine.Master.OfficerEng
                    oLnq = oEng.GetOfficerParaByUserName(NewLnq.RECEIVER_OFFICER_USERNAME)
                    dLnq.OFFICER_ID_POSSESS = oLnq.ID
                    dLnq.OFFICER_NAME_POSSESS = NewLnq.RECEIVER_OFFICER_FULLNAME
                    ret = dLnq.UpdateByPK(uPara.UserName, trans.Trans)

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = dLnq.ErrorMessage
                    End If
                Else
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                End If
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SaveRetrieve(ByVal uPara As Para.Common.UserProfilePara, ByVal vOldID As Long, ByVal RetrieveReason As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New Linq.TABLE.DocumentIntReceiverLinq
            lnq.GetDataByPK(vOldID, trans.Trans)
            lnq.RETRIEVE_REASON = RetrieveReason
            lnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Retrieve
            lnq.IS_FORWARD = "Y"

            ret = lnq.UpdateByPK(uPara.UserName, trans.Trans)
            If ret = True Then
                Dim NewLnq As New Linq.TABLE.DocumentIntReceiverLinq
                Dim DateNow As DateTime = DateTime.Now
                NewLnq.DOCUMENT_REGISTER_ID = lnq.DOCUMENT_REGISTER_ID
                NewLnq.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                NewLnq.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_NAME
                NewLnq.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_ABB
                NewLnq.SEND_DATE = DateNow
                NewLnq.RECEIVE_DATE = DateNow
                NewLnq.SENDER_OFFICER_USERNAME = uPara.UserName
                NewLnq.SENDER_OFFICER_FULLNAME = uPara.TitleName & uPara.FirstName & " " & uPara.LastName
                NewLnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                NewLnq.ORGANIZATION_ID_RECEIVE = lnq.ORGANIZATION_ID_SEND
                NewLnq.ORGANIZATION_NAME_RECEIVE = lnq.ORGANIZATION_NAME_SEND
                NewLnq.ORGANIZATION_APPNAME_RECEIVE = lnq.ORGANIZATION_APPNAME_SEND
                NewLnq.RECEIVER_OFFICER_USERNAME = lnq.SENDER_OFFICER_USERNAME
                NewLnq.RECEIVER_OFFICER_FULLNAME = lnq.SENDER_OFFICER_FULLNAME
                NewLnq.RECEIVE_TYPE_ID = lnq.RECEIVE_TYPE_ID
                NewLnq.RECEIVE_OBJECTIVE_ID = lnq.RECEIVE_OBJECTIVE_ID
                NewLnq.REMARKS = RetrieveReason
                NewLnq.ORGANIZATION_ID_STORAGE = lnq.ORGANIZATION_ID_STORAGE
                NewLnq.ORGANIZATION_NAME_STORAGE = lnq.ORGANIZATION_NAME_STORAGE
                NewLnq.REF_OLD_SEND_ID = lnq.REF_OLD_SEND_ID
                NewLnq.REF_OLD_RECEIVE_ID = lnq.REF_OLD_RECEIVE_ID
                NewLnq.DOCUMENT_STATEMENT = lnq.DOCUMENT_STATEMENT
                NewLnq.DOCUMENT_INT_TYPE = lnq.DOCUMENT_INT_TYPE
                NewLnq.MODULE_FOLDER_ID = lnq.MODULE_FOLDER_ID
                NewLnq.IS_FORWARD = "N"

                ret = NewLnq.InsertData(uPara.UserName, trans.Trans)
                If ret = True Then
                    Dim DocLnq As New Linq.TABLE.DocumentRegisterLinq
                    DocLnq.GetDataByPK(lnq.DOCUMENT_REGISTER_ID, trans.Trans)
                    DocLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                    DocLnq.OFFICER_ID_POSSESS = uPara.OFFICER_DATA.ID
                    DocLnq.OFFICER_NAME_POSSESS = uPara.TitleName & uPara.FirstName & " " & uPara.LastName
                    DocLnq.ORGANIZATION_ID_PROCESS = uPara.ORG_DATA.ID

                    ret = DocLnq.UpdateByPK(uPara.UserName, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = DocLnq.ErrorMessage
                    End If
                Else
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                End If
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function SaveCancelClose(ByVal uPara As Para.Common.UserProfilePara, ByVal DocRegID As Long, ByVal CancelReason As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim DateNow As DateTime = DateTime.Now

            Dim DocLnq As New Linq.TABLE.DocumentRegisterLinq
            DocLnq.GetDataByPK(DocRegID, trans.Trans)

            Dim lnq As New Linq.TABLE.DocumentCancelCloseLinq
            lnq.DOCUMENT_REGISTER_ID = DocRegID
            lnq.CANCEL_DATE = DateNow
            lnq.CANCEL_REASON = CancelReason
            lnq.ORGANIZATION_ID_CANCEL = uPara.ORG_DATA.ID
            lnq.ORGANIZATION_NAME_CANCEL = uPara.ORG_DATA.ORG_NAME
            lnq.ORGANIZATION_APPNAME_CANCEL = uPara.ORG_DATA.NAME_ABB
            lnq.OFFICER_FULLNAME_CANCEL = uPara.FirstName & " " & uPara.LastName
            lnq.OFFICER_USERNAME_CANCEL = uPara.UserName
            lnq.CLOSE_BY = DocLnq.CLOSE_BY
            lnq.CLOSE_BY_NAME = DocLnq.CLOSE_BY_NAME
            lnq.CLOSE_DATE = DocLnq.CLOSE_DATE
            lnq.CLOSE_REMARKS = DocLnq.CLOSE_REMARKS

            ret = lnq.InsertData(uPara.UserName, trans.Trans)
            If ret = True Then
                Dim iLnq As New Linq.TABLE.DocumentIntReceiverLinq
                iLnq.DOCUMENT_REGISTER_ID = DocRegID
                iLnq.ORGANIZATION_ID_SEND = uPara.ORG_DATA.ID
                iLnq.ORGANIZATION_NAME_SEND = uPara.ORG_DATA.ORG_NAME
                iLnq.ORGANIZATION_APPNAME_SEND = uPara.ORG_DATA.NAME_ABB
                iLnq.SEND_DATE = DateNow
                iLnq.SENDER_OFFICER_USERNAME = uPara.UserName
                iLnq.SENDER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                iLnq.RECEIVE_STATUS_ID = Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received
                iLnq.RECEIVE_DATE = DateNow
                iLnq.ORGANIZATION_ID_RECEIVE = uPara.ORG_DATA.ID
                iLnq.ORGANIZATION_NAME_RECEIVE = uPara.ORG_DATA.ORG_NAME
                iLnq.ORGANIZATION_APPNAME_RECEIVE = uPara.ORG_DATA.NAME_ABB
                iLnq.RECEIVER_OFFICER_USERNAME = uPara.UserName
                iLnq.RECEIVER_OFFICER_FULLNAME = uPara.FirstName & " " & uPara.LastName
                iLnq.REMARKS = CancelReason
                iLnq.DOCUMENT_INT_TYPE = "1"
                iLnq.MODULE_FOLDER_ID = 0
                iLnq.IS_FORWARD = "N"

                ret = iLnq.InsertData(uPara.UserName, trans.Trans)
                If ret = True Then
                    DocLnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain
                    DocLnq.OFFICER_ID_POSSESS = uPara.OFFICER_DATA.ID
                    DocLnq.OFFICER_NAME_POSSESS = uPara.FirstName & " " & uPara.LastName
                    DocLnq.ORGANIZATION_ID_PROCESS = uPara.ORG_DATA.ID
                    DocLnq.CLOSE_BY = ""
                    DocLnq.CLOSE_BY_NAME = ""
                    DocLnq.CLOSE_DATE = New Date(1, 1, 1)
                    DocLnq.CLOSE_REMARKS = ""

                    ret = DocLnq.UpdateByPK(uPara.UserName, trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        _err = lnq.ErrorMessage
                    End If
                Else
                    trans.RollbackTransaction()
                    _err = iLnq.ErrorMessage
                End If
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        'Public Function LoadCompanyFromBCM() As DataTable
        '    Dim dt As New DataTable
        '    Dim ws As New LinqWS.OneDB.CompanyInfoLinqWS
        '    dt = ws.GetCompanyList(Engine.Common.FunctionENG.GetConfigValue("BCM_WS_URL"))
        '    ws = Nothing
        '    Return dt
        'End Function

        Public Function SaveInsideSend(ByVal LoginName As String, ByVal para As Para.TABLE.DocumentIntReceiverPara, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New Linq.TABLE.DocumentIntReceiverLinq
            Try
                If para.ID <> 0 Then
                    lnq.GetDataByPK(para.ID, trans.Trans)
                End If

                lnq.DOCUMENT_REGISTER_ID = para.DOCUMENT_REGISTER_ID
                lnq.ORGANIZATION_ID_SEND = para.ORGANIZATION_ID_SEND
                lnq.ORGANIZATION_NAME_SEND = para.ORGANIZATION_NAME_SEND
                lnq.ORGANIZATION_APPNAME_SEND = para.ORGANIZATION_APPNAME_SEND
                lnq.SEND_DATE = para.SEND_DATE
                lnq.SENDER_OFFICER_USERNAME = para.SENDER_OFFICER_USERNAME
                lnq.SENDER_OFFICER_FULLNAME = para.SENDER_OFFICER_FULLNAME
                lnq.RECEIVE_STATUS_ID = para.RECEIVE_STATUS_ID
                lnq.RECEIVE_DATE = para.RECEIVE_DATE
                lnq.ORGANIZATION_ID_RECEIVE = para.ORGANIZATION_ID_RECEIVE
                lnq.ORGANIZATION_NAME_RECEIVE = para.ORGANIZATION_NAME_RECEIVE
                lnq.ORGANIZATION_APPNAME_RECEIVE = para.ORGANIZATION_APPNAME_RECEIVE
                lnq.RECEIVER_OFFICER_USERNAME = para.RECEIVER_OFFICER_USERNAME
                lnq.RECEIVER_OFFICER_FULLNAME = para.RECEIVER_OFFICER_FULLNAME
                lnq.RECEIVE_TYPE_ID = para.RECEIVE_TYPE_ID
                lnq.RECEIVE_OBJECTIVE_ID = para.RECEIVE_OBJECTIVE_ID
                lnq.REMARKS = para.REMARKS
                lnq.ORGANIZATION_ID_STORAGE = para.ORGANIZATION_ID_STORAGE
                lnq.ORGANIZATION_NAME_STORAGE = para.ORGANIZATION_NAME_STORAGE
                lnq.REF_OLD_SEND_ID = para.REF_OLD_SEND_ID
                lnq.REF_OLD_RECEIVE_ID = para.REF_OLD_RECEIVE_ID
                lnq.DOCUMENT_STATEMENT = para.DOCUMENT_STATEMENT
                lnq.DOCUMENT_INT_TYPE = para.DOCUMENT_INT_TYPE
                lnq.MODULE_FOLDER_ID = para.MODULE_FOLDER_ID
                lnq.IS_FORWARD = para.IS_FORWARD
                lnq.SENDBACK_REASON = para.SENDBACK_REASON
                lnq.RETRIEVE_REASON = para.RETRIEVE_REASON

                If lnq.ID <> 0 Then
                    ret = lnq.UpdateByPK(LoginName, trans.Trans)
                Else
                    ret = lnq.InsertData(LoginName, trans.Trans)
                End If

                If ret = False Then
                    Dim lEng As New Common.LogEng
                    lEng.SaveErrLog(LoginName, lnq.ErrorMessage, trans)
                    lEng = Nothing
                End If
            Catch ex As Exception
                ret = False
                Dim ErrPara As New Para.TABLE.LogErrorPara
                ErrPara.LOGIN_HIS_ID = 0
                ErrPara.ERROR_TIME = DateTime.Now
                ErrPara.ERROR_DESC = "Exception : " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & lnq.ErrorMessage

                Dim lo As New Common.LogEng
                lo.SaveErrLog(LoginName, ErrPara)
            End Try
            lnq = Nothing
            
            Return ret
        End Function

        Public Function SaveDocumentRegister(ByVal LoginName As String, ByVal para As Para.TABLE.DocumentRegisterPara, ByVal AttachFileDT As DataTable, ByVal ScanJobID As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As Long
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            If para.ID <> 0 Then
                lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.BOOK_NO = para.BOOK_NO
            lnq.REQUEST_NO = para.REQUEST_NO
            lnq.GROUP_TITLE_ID = para.GROUP_TITLE_ID
            lnq.TITLE_NAME = para.TITLE_NAME
            lnq.REGISTER_DATE = para.REGISTER_DATE
            lnq.EXPECT_FINISH_DATE = para.EXPECT_FINISH_DATE
            lnq.DOC_SECRET_ID = para.DOC_SECRET_ID
            lnq.DOC_SPEED_ID = para.DOC_SPEED_ID
            lnq.ORGANIZATION_ID_OWNER = para.ORGANIZATION_ID_OWNER
            lnq.ORGANIZATION_NAME = para.ORGANIZATION_NAME
            lnq.ORGANIZATION_APPNAME = para.ORGANIZATION_APPNAME
            lnq.OFFICER_ID_APPROVE = para.OFFICER_ID_APPROVE
            lnq.OFFICER_NAME = para.OFFICER_NAME
            lnq.OFFICER_ORGANIZATION_ID = para.OFFICER_ORGANIZATION_ID
            lnq.ADMINISTRATION_TYPE = para.ADMINISTRATION_TYPE
            lnq.REMARKS = para.REMARKS
            lnq.BUSINESS_TYPE_ID = para.BUSINESS_TYPE_ID
            lnq.COMPANY_ID = para.COMPANY_ID
            lnq.COMPANY_REGIS_NO = para.COMPANY_REGIS_NO
            lnq.COMPANY_NAME = para.COMPANY_NAME
            lnq.COMPANY_DOC_NO = para.COMPANY_DOC_NO
            lnq.COMPANY_DOC_TYPE_ID = para.COMPANY_DOC_TYPE_ID
            lnq.COMPANY_DOC_SYS_ID = para.COMPANY_DOC_SYS_ID
            lnq.COMPANY_REQ_ID = para.COMPANY_REQ_ID
            lnq.COMPANY_DOC_DATE = para.COMPANY_DOC_DATE
            lnq.COMPANY_SIGN = para.COMPANY_SIGN
            lnq.COMPANY_SIGN_DATE = para.COMPANY_SIGN_DATE
            lnq.DOC_STATUS_ID = para.DOC_STATUS_ID
            lnq.USERNAME_REGISTER = para.USERNAME_REGISTER
            lnq.ORGANIZATION_ID_REGISTER = para.ORGANIZATION_ID_REGISTER
            lnq.CLOSE_BY = para.CLOSE_BY
            lnq.CLOSE_BY_NAME = para.CLOSE_BY_NAME
            lnq.CLOSE_DATE = para.CLOSE_DATE
            lnq.CLOSE_REMARKS = para.CLOSE_REMARKS
            lnq.BOOKOUT_NO = para.BOOKOUT_NO
            lnq.ORGANIZATION_ID_PROCESS = para.ORGANIZATION_ID_PROCESS
            lnq.ORGANIZATION_NAME_PROCESS = para.ORGANIZATION_NAME_PROCESS
            lnq.ORGANIZATION_ABBNAME_PROCESS = para.ORGANIZATION_ABBNAME_PROCESS
            lnq.ORGANIZATION_ID_STORAGE = para.ORGANIZATION_ID_STORAGE
            lnq.ORGANIZATION_NAME_STORAGE = para.ORGANIZATION_NAME_STORAGE
            lnq.ID_MUST_RECEIVE_DOC = para.ID_MUST_RECEIVE_DOC.Value
            lnq.ELECTRONIC_DOC_ID = para.ELECTRONIC_DOC_ID
            lnq.DOC_SYS_CODE = para.DOC_SYS_CODE
            lnq.REF_OLD_ID = para.REF_OLD_ID
            lnq.DOCUMENT_RECEIVE_TYPE = para.DOCUMENT_RECEIVE_TYPE
            lnq.OFFICER_ID_POSSESS = para.OFFICER_ID_POSSESS
            lnq.OFFICER_NAME_POSSESS = para.OFFICER_NAME_POSSESS
            lnq.REF_DOCUMENT_REGISTER_ID = para.REF_DOCUMENT_REGISTER_ID
            lnq.COMPANY_CERT_NO = para.COMPANY_CERT_NO
            lnq.COMPANY_NOTIFY_NO = para.COMPANY_NOTIFY_NO
            lnq.REF_TH_EGIF_DOC_INBOUND_ID = para.REF_TH_EGIF_DOC_INBOUND_ID
            lnq.BOOKOUT_DATE = para.BOOKOUT_DATE

            Dim ret As Boolean = False
            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(LoginName, trans.Trans)
            Else
                ret = lnq.InsertData(LoginName, trans.Trans)
            End If

            If ret = False Then
                lnq.ID = 0
                _err = lnq.ErrorMessage
            Else
                SendTHeGifAcceiptLetterNotifier(LoginName, para.REF_TH_EGIF_DOC_INBOUND_ID, para.BOOK_NO)

                If AttachFileDT IsNot Nothing Then
                    Dim aRlnq As New Linq.TABLE.DocumentAttachFileLinq
                    Dim tmpDt As DataTable = aRlnq.GetDataList("document_register_id = '" & lnq.ID & "'", "", trans.Trans)
                    For Each tmpDr As DataRow In tmpDt.Rows
                        aRlnq.DeleteByPK(tmpDr("id"), trans.Trans)
                    Next
                    tmpDt = Nothing
                    aRlnq = Nothing

                    For Each aDr As DataRow In AttachFileDT.Rows
                        ret = SaveAttachFile(LoginName, lnq.ID, aDr, trans)
                        If ret = False Then
                            lnq.ID = 0
                            Exit For
                        End If
                    Next
                End If

                'หาข้อมูลไฟล์ที่มีการ Scan
                'Dim session As System.Web.SessionState.HttpSessionState = System.Web.HttpContext.Current.Session
                Dim FileDT As New DataTable
                Dim fLnq As New Linq.TABLE.DocumentScanJobLinq
                Dim fSql As String = ""
                fSql += " select ds.id DOCUMENT_SCAN_TEMP_ID, ds.file_byte, ds.file_extention, ds.description, ds.ref_id, ds.ref_table"
                fSql += " from DOCUMENT_SCAN_TEMP ds"
                fSql += " inner join DOCUMENT_SCAN_JOB dj on dj.id=ds.document_scan_job_id"
                fSql += " where dj.ref_id='0' and ds.ref_table = 'DOCUMENT_REGISTER' and ds.ref_id='0' "
                fSql += " and dj.start_status='" & Constant.DocumentScanJob.StartStatus.ProgramClosed & "' "
                fSql += " and ds.attach_status='" & Constant.DocumentScanJob.AttachStatus.WaitSave & "' "
                fSql += " and dj.client_ip = '" & Engine.Common.FunctionENG.GetIPAddress() & "' "
                fSql += " and dj.client_page = 'DOCUMENT_REGISTER' and dj.id = '" & ScanJobID & "' "

                FileDT = fLnq.GetListBySql(fSql, trans.Trans)
                If FileDT.Rows.Count > 0 Then
                    Dim i As Integer = 1
                    For Each FileDR As DataRow In FileDT.Rows
                        'Insert ข้อมูลลงใน DOCUMENT_ATTACH_FILE
                        Dim alnq As New Linq.TABLE.DocumentAttachFileLinq
                        If Convert.ToInt64(FileDR("ref_id")) <> 0 Then
                            alnq.GetDataByPK(Convert.ToInt64(FileDR("ref_id")), trans.Trans)
                        End If
                        Dim FileName As String = "DOCUMENT_REGISTER_" & lnq.ID & "_" & i & FileDR("file_extention")
                        alnq.DOCUMENT_REGISTER_ID = lnq.ID
                        alnq.FILE_NAME = FileName
                        alnq.FILE_PATH = Engine.Common.FunctionENG.GetFileUploadPath
                        alnq.DESCRIPTION = FileDR("description")
                        alnq.MIME_TYPE = FileDR("file_extention")

                        If alnq.ID <> 0 Then
                            ret = alnq.UpdateByPK(LoginName, trans.Trans)
                        Else
                            ret = alnq.InsertData(LoginName, trans.Trans)
                        End If

                        If ret = True Then
                            'สร้างไฟล์เก็บเอาไว้
                            ret = CreateFile(FileName, CType(FileDR("file_byte"), Byte()))
                            If ret = True Then
                                'Clear DOCUMENT_SCAN_TEMP
                                Dim dLnq As New Linq.TABLE.DocumentScanTempLinq
                                dLnq.GetDataByPK(Convert.ToInt64(FileDR("DOCUMENT_SCAN_TEMP_ID")), trans.Trans)
                                dLnq.FILE_BYTE = Nothing
                                dLnq.REF_ID = lnq.ID
                                dLnq.REF_TABLE = "DOCUMENT_REGISTER"
                                dLnq.ATTACH_STATUS = Constant.DocumentScanJob.AttachStatus.SaveComplete.ToString
                                dLnq.ATTACH_TIME = DateTime.Now
                                dLnq.DOCUMENT_ATTACH_FILE_ID = alnq.ID

                                ret = dLnq.UpdateByPK(LoginName, trans.Trans)
                                If ret = False Then
                                    lnq.ID = 0
                                    _err = dLnq.ErrorMessage
                                    Exit For
                                End If
                            Else
                                lnq.ID = 0
                                _err = "Cannot Create File"
                                Exit For
                            End If
                        Else
                            lnq.ID = 0
                            _err = alnq.ErrorMessage
                            Exit For
                        End If
                        alnq = Nothing
                        i += 1
                    Next
                End If
            End If

            Return lnq.ID
        End Function

        Public Function SendTHeGifAcceiptLetterNotifier(ByVal LoginName As String, ByVal vDocInboundID As String, ByVal BookNo As String) As Boolean
            'ส่งเลขที่หนังสือที่ลงรับกลับไปยังระบบ TH-eGIF
            Dim ret As Boolean = False

            If vDocInboundID.Trim = "" Then
                vDocInboundID = "0"
            End If

            If Convert.ToInt64(vDocInboundID) <> 0 Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim Doc As New Linq.TABLE.ThEgifDocInboundLinq
                Doc.GetDataByPK(vDocInboundID, trans.Trans)

                If Doc.ID <> 0 And Doc.RECEIVE_NOTIFY_LETTERID = "" Then
                    Dim p As New Para.THeGIF.SendAcceiptLetterNotifierPara
                    p.BodyAcceptID = BookNo
                    p.BodyCorrespondenceDate = Doc.BODY_CORRESPONDENCE_DATE
                    p.BodyLetterID = Doc.BODY_ID
                    p.BodySubject = Doc.BODY_SUBJECT
                    ret = Engine.WebService.THeGIFENG.SendAcceiptLetterNotifier(p)

                    If ret = True Then
                        Doc.RECEIVE_NOTIFY_LETTERID = BookNo
                        Doc.RECEIVE_NOTIFY_CORRESPONDENCE_DATE = Doc.BODY_CORRESPONDENCE_DATE
                        Doc.RECEIVE_NOTIFY_SUBJECT = Doc.BODY_SUBJECT
                        Doc.RECEIVE_NOTIFY_TIME = DateTime.Now
                        ret = Doc.UpdateByPK(LoginName, trans.Trans)
                        If ret = True Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    End If

                    p = Nothing
                Else
                    trans.CommitTransaction()
                End If
                Doc = Nothing
            End If

            Return ret
        End Function

        Private Function CreateFile(ByVal FileName As String, ByVal FileByte() As Byte) As Boolean
            Dim ret As Boolean = True
            Dim TmpFile As String = Engine.Common.FunctionENG.GetFileUploadPath & "\" & FileName
            If System.IO.File.Exists(TmpFile) = True Then
                System.IO.File.Delete(TmpFile)
            End If

            Dim fs As System.IO.FileStream
            Try
                fs = New System.IO.FileStream(TmpFile, System.IO.FileMode.CreateNew)
                fs.Write(FileByte, 0, FileByte.Length)
                fs.Close()
            Catch ex As Exception
                _err = ex.Message
                ret = False
            End Try

            Return ret
        End Function

        Private Function CreateByteToStringFile(ByVal FileName As String, ByVal FileByte() As Byte) As Boolean
            Dim ret As Boolean = True
            Dim TmpFile As String = Engine.Common.FunctionENG.GetFileUploadPath & "\" & FileName
            If System.IO.File.Exists(TmpFile) = True Then
                System.IO.File.Delete(TmpFile)
            End If

            Dim str As String = Convert.ToBase64String(FileByte)
            Dim objWriter As New System.IO.StreamWriter(FileName, True)
            objWriter.WriteLine(str)
            objWriter.Close()

            Return ret
        End Function

        Private Function CreateStringFileToByte(ByVal FileName As String, ByVal FileString As String) As Boolean
            Dim ret As Boolean = True
            Dim TmpFile As String = Engine.Common.FunctionENG.GetFileUploadPath & "\" & FileName
            If System.IO.File.Exists(TmpFile) = True Then
                System.IO.File.Delete(TmpFile)
            End If

            Dim FileByte() As Byte = Nothing
            If System.IO.File.Exists(Engine.Common.FunctionENG.GetFileUploadPath & FileString) = True Then
                FileByte = System.IO.File.ReadAllBytes(Engine.Common.FunctionENG.GetFileUploadPath & FileString)
            End If

            Dim fs As System.IO.FileStream
            Try
                fs = New System.IO.FileStream(TmpFile, System.IO.FileMode.CreateNew)
                fs.Write(FileByte, 0, FileByte.Length)
                fs.Close()
            Catch ex As Exception
                _err = ex.Message
                ret = False
            End Try

            Return ret
        End Function

        Public Function SaveAttachFile(ByVal LoginName As String, ByVal DocRegisID As Long, ByVal aDr As DataRow, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = True
            Dim alnq As New Linq.TABLE.DocumentAttachFileLinq
            If Convert.ToInt64(aDr("id")) <> 0 Then
                alnq.GetDataByPK(Convert.ToInt64(aDr("id")), trans.Trans)
            End If

            alnq.DOCUMENT_REGISTER_ID = DocRegisID
            alnq.FILE_NAME = "DOCUMENT_REGISTER_" & DocRegisID.ToString & "_" & aDr("no") & aDr("mime_type")
            alnq.FILE_PATH = Engine.Common.FunctionENG.GetFileUploadPath
            alnq.DESCRIPTION = aDr("description")
            alnq.MIME_TYPE = aDr("mime_type")

            If alnq.ID <> 0 Then
                ret = alnq.UpdateByPK(LoginName, trans.Trans)
            Else
                ret = alnq.InsertData(LoginName, trans.Trans)
            End If

            If ret = True Then
                ret = CreateFile(alnq.FILE_NAME, CType(aDr("file_byte"), Byte()))
            Else
                _err = alnq.ErrorMessage
                ret = False
            End If

            Return ret
        End Function

        Public Function SetCloseJob(ByVal uPara As Para.Common.UserProfilePara, ByVal vID As Long) As Boolean
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            lnq.GetDataByPK(vID, trans.Trans)
            lnq.CLOSE_BY = uPara.UserName
            lnq.CLOSE_BY_NAME = uPara.TitleName & uPara.FirstName & " " & uPara.LastName
            lnq.CLOSE_DATE = DateTime.Now
            lnq.DOC_STATUS_ID = Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose

            If lnq.UpdateByPK(uPara.UserName, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                _err = lnq.ErrorMessage
                trans.RollbackTransaction()
            End If
        End Function

        Public Function GetDocumentListByRefID(ByVal RefID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim dt As New DataTable
            'dt = GetDocumentCircleListByRefID(RefID, trans)

            'If dt.Rows.Count = 0 Then
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim sql As String = ""
            sql = " select ir.id, dr.book_no,ir.organization_name_receive OrgNameReceive, receiver_officer_fullname StaffNameReceive,oj.objective_name purpose"
            sql += " from DOCUMENT_INT_RECEIVER ir"
            sql += " inner join DOCUMENT_REGISTER dr on dr.id=ir.document_register_id"
            sql += " left join OBJECTIVE oj on oj.id=ir.receive_objective_id"
            sql += " where dr.id = " & RefID
            sql += " order by dr.id"

            dt = lnq.GetListBySql(sql, trans.Trans)
            'End If
            lnq = Nothing

            Return dt
        End Function

        Public Function GetDocumentCircleListByRefID(ByVal RefID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As DataTable
            Dim dt As New DataTable
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim sql As String = ""
            sql += " select ir.id, dr.book_no,ir.organization_name_receive OrgNameReceive, receiver_officer_fullname StaffNameReceive,oj.objective_name purpose"
            sql += " from DOCUMENT_INT_RECEIVER ir"
            sql += " inner join DOCUMENT_REGISTER dr on dr.id=ir.document_register_id"
            sql += " left join OBJECTIVE oj on oj.id=ir.receive_objective_id"
            sql += " where dr.ref_document_register_id = " & RefID
            sql += " order by dr.id"
            dt = lnq.GetListBySql(sql, trans.Trans)
            lnq = Nothing
            Return dt
        End Function

        Public Sub DeleteRegisterData(ByVal vID As Long)
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnqRg As New Linq.TABLE.DocumentRegisterLinq
            Dim dtRg As DataTable = lnqRg.GetDataList("ref_document_register_id = " & vID, "", trans.Trans)
            If dtRg.Rows.Count > 0 Then
                For Each drRg As DataRow In dtRg.Rows
                    Dim lnqInt As New Linq.TABLE.DocumentIntReceiverLinq
                    Dim dtInt As New DataTable
                    dtInt = lnqInt.GetDataList("document_register_id = '" & drRg("id") & "'", "", trans.Trans)
                    If dtInt.Rows.Count > 0 Then
                        lnqInt.DeleteByPK(Convert.ToInt64(dtInt.Rows(0)("id")), trans.Trans)
                    End If
                    lnqInt = Nothing
                    dtInt.Dispose()

                    Dim atLnq As New Linq.TABLE.DocumentAttachFileLinq
                    Dim dtAt As New DataTable
                    dtAt = atLnq.GetDataList("document_register_id = '" & drRg("id") & "'", "", trans.Trans)
                    For Each drAt As DataRow In dtAt.Rows
                        atLnq.DeleteByPK(Convert.ToInt64(drAt("id")), trans.Trans)
                    Next
                    atLnq = Nothing
                    dtAt.Dispose()

                    lnqRg.DeleteByPK(Convert.ToInt64(drRg("id")), trans.Trans)
                Next
                'lnqRg.DeleteByPK(vID, trans.Trans)
            Else
                dtRg = lnqRg.GetDataList("id = " & vID, "", trans.Trans)
                If dtRg.Rows.Count > 0 Then
                    Dim lnqInt As New Linq.TABLE.DocumentIntReceiverLinq
                    Dim dtInt As New DataTable
                    dtInt = lnqInt.GetDataList("document_register_id = '" & dtRg.Rows(0)("id") & "'", "", trans.Trans)
                    If dtInt.Rows.Count > 0 Then
                        For Each drInt As DataRow In dtInt.Rows
                            lnqInt.DeleteByPK(Convert.ToInt64(drInt("id")), trans.Trans)
                        Next
                    End If
                    dtInt.Dispose()
                    lnqInt = Nothing

                    Dim lnqExt As New Linq.TABLE.DocumentExtReceiverLinq
                    Dim dtExt As New DataTable
                    dtExt = lnqExt.GetDataList("document_register_id = '" & dtRg.Rows(0)("id") & "'", "", trans.Trans)
                    If dtExt.Rows.Count > 0 Then
                        For Each drExt As DataRow In dtExt.Rows
                            lnqExt.DeleteByPK(Convert.ToInt64(drExt("id")), trans.Trans)
                        Next
                    End If
                    lnqExt = Nothing
                    dtExt.Dispose()

                    Dim atLnq As New Linq.TABLE.DocumentAttachFileLinq
                    Dim dtAt As New DataTable
                    dtAt = atLnq.GetDataList("document_register_id = '" & dtRg.Rows(0)("id") & "'", "", trans.Trans)
                    For Each drAt As DataRow In dtAt.Rows
                        atLnq.DeleteByPK(Convert.ToInt64(drAt("id")), trans.Trans)
                    Next
                    atLnq = Nothing
                    dtAt.Dispose()

                    lnqRg.DeleteByPK(Convert.ToInt64(dtRg.Rows(0)("id")), trans.Trans)
                End If
            End If
            dtRg.Dispose()
            lnqRg = Nothing

            trans.CommitTransaction()
        End Sub

        Public Function DeleteAttachFile(ByVal vID As Long) As Boolean
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New Linq.TABLE.DocumentAttachFileLinq
            Dim ret As Boolean = lnq.DeleteByPK(vID, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                _err = lnq.ErrorMessage
            End If

            Return ret
        End Function

        Public Function GetOutsideCompanyDefault(ByVal DocRegisID As Long) As DataTable
            Dim ret As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()

            Dim sql As String = ""
            sql += " select gd.company_id company_id_receive, c.thaiName company_name_receive, gd.remarks,"
            sql += "'' username, '' staff_name, 0 officer_id, c.comid company_regis_no"
            sql += " from GROUP_TITLE_COMPANY_DEFAULT gd"
            sql += " inner join COMPANY c on c.id=gd.company_id"
            sql += " inner join DOCUMENT_REGISTER dr on gd.group_title_id=dr.group_title_id"
            sql += " where dr.id= " & DocRegisID
            sql += " and gd.active='Y'"

            Dim lnq As New Linq.TABLE.GroupTitleCompanyDefaultLinq
            ret = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return ret
        End Function

        Public Function GetCERTIFICATENO(ByVal CompanyEngName As String) As DataTable
            'เลขที่บัตรส่งเสริม
            Dim sql As String = ""
            sql += " select distinct CERTIFICATENO, CERTIFICATENO CERT "
            sql += " from COMPANY_PROJECT_CERTIFICATE "
            sql += " where comename = '" & CompanyEngName & "'"

            Dim dt As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql)
            'trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetNOTIFICATIONNO(ByVal CompanyEngName As String) As DataTable
            'เลขที่หนังสือแจ้งมติ
            Dim sql As String = ""
            sql += " select distinct NOTIFICATIONNO , NOTIFICATIONNO Notif "
            sql += " from COMPANY_PROJECT_CERTIFICATE "
            sql += " where comename = '" & CompanyEngName & "'"

            Dim dt As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql)
            'trans.CommitTransaction()
            Return dt
        End Function

        Public Function CalProcessDate(ByVal RegisterDate As DateTime, ByVal CloseDate As DateTime) As String
            Dim ret As String = DateDiff(DateInterval.Day, RegisterDate, CloseDate).ToString
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.HolidayLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("convert(varchar(8),holiday_date,112) between '" & RegisterDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "' and '" & CloseDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'", "", Nothing)
            If dt.Rows.Count > 0 Then
                ret -= dt.Rows.Count
            End If
            dt = Nothing
            lnq = Nothing
            Return ret
        End Function

        Public Function CalExpectFinishDate(ByVal tPara As Para.TABLE.GroupTitlePara) As DateTime
            Dim stDate As Date = Date.Now
            Dim endDate As Date = Nothing
            If tPara.MAX_PROC_PERIOD > 0 Then
                endDate = DateAdd(DateInterval.Day, Convert.ToDouble(tPara.MAX_PROC_PERIOD), stDate)
                Dim curDate As Date = stDate
                Do
                    Dim hDt As New DataTable
                    Dim hLnq As New Linq.TABLE.HolidayLinq
                    hDt = hLnq.GetDataList("convert(varchar(8),holiday_date,112) =  '" + curDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) + "' ", "holiday_date", Nothing)
                    If hDt.Rows.Count > 0 Then
                        endDate = DateAdd(DateInterval.Day, 1, endDate)
                    End If
                    hDt = Nothing
                    hLnq = Nothing
                    curDate = DateAdd(DateInterval.Day, 1, curDate)
                Loop While curDate <= endDate
            End If
            Return endDate
        End Function


        Public Function CalExpectFinishDate(ByVal tPara As Para.TABLE.GroupTitlePara, ByVal vDocRegisID As Long) As DateTime
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim d As New Engine.Document.DocumentRegisterENG
            Dim dPara As New Para.TABLE.DocumentRegisterPara
            dPara = d.GetDocumentPara(vDocRegisID, trans)
            trans.CommitTransaction()
            d = Nothing

            Dim endDate As Date = Nothing
            If tPara.MAX_PROC_PERIOD > 0 Then
                Dim stDate As Date = dPara.REGISTER_DATE
                endDate = DateAdd(DateInterval.Day, Convert.ToDouble(tPara.MAX_PROC_PERIOD), stDate)
                Dim curDate As Date = stDate
                Do
                    Dim hDt As New DataTable
                    Dim hLnq As New Linq.TABLE.HolidayLinq
                    hDt = hLnq.GetDataList("convert(varchar(8),holiday_date,112) =  '" + curDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) + "' ", "holiday_date", Nothing)
                    If hDt.Rows.Count > 0 Then
                        endDate = DateAdd(DateInterval.Day, 1, endDate)
                    End If
                    hDt = Nothing
                    hLnq = Nothing
                    curDate = DateAdd(DateInterval.Day, 1, curDate)
                Loop While curDate <= endDate
            End If
            dPara = Nothing

            Return endDate
        End Function

        Public Function CheckCompanyDocNo(ByVal vCompanyDocNo As String) As String
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()

            Dim lnq As New Linq.TABLE.DocumentRegisterLinq()
            Dim sql As String = " select top 1 r.id, r.book_no, r.title_name,r.company_doc_no "
            sql += " from document_register r"
            sql += " where r.company_doc_no = '" & vCompanyDocNo & "'"
            sql += " order by r.register_date desc"

            Dim ret As String = ""
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            If dt.Rows.Count > 0 Then
                ret = vbCrLf & "เลขที่หนังสือ : " & dt.Rows(0)("book_no") & vbCrLf & " เลขที่หนังสือองค์กร : " & dt.Rows(0)("company_doc_no") & vbCrLf & " ชื่อเรื่อง : " & dt.Rows(0)("title_name")
            End If

            'trans.CommitTransaction()
            dt.Dispose()
            dt = Nothing

            Return ret
        End Function

        Public Shared Function GetBookOutTable(ByVal vRegisID As Long) As DataTable
            Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("document_register_id = '" & vRegisID & "'", "id", Nothing)
            Return dt
        End Function

        Public Shared Function GetBookOutDetail(ByVal vRegisID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
            Dim ret As String = ""
            Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq

            Dim sql As String = "select e.* from Document_Ext_Receiver e"
            sql &= " where document_register_id='" & vRegisID & "'"
            Dim dt As DataTable = lnq.GetListBySql(sql, trans.Trans)

            'Dim dt As New DataTable
            'dt = lnq.GetDataList("document_register_id = '" & vRegisID & "'", "id", trans.Trans)

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim bookno As String = FunctionENG.GetThaiNumber(dr("bookout_no"))
                    Dim tmp = "<font color='Blue'>" & bookno & "</font> "
                    If Convert.IsDBNull(dr("company_regis_no")) = False Then
                        If dr("company_regis_no").ToString.Trim <> "" Then
                            tmp += " <font color='Black'> : เลขทะเบียนบริษัท :" & dr("company_regis_no")
                        End If
                    End If
                    tmp += " <font color='Gray'> : " & dr("company_name_receive")
                    tmp += " - ลงนาม " & Convert.ToDateTime(dr("approve_date")).ToString("d MMM yy")
                    tmp += ", ส่งออก " & Convert.ToDateTime(dr("send_date")).ToString("d MMM yy")
                    If ret = "" Then
                        ret = tmp
                    Else
                        ret += "<br />" & tmp
                    End If

                    Dim cPara As New Para.TABLE.CompanyPara
                    Dim eng As New Master.CompanyEng
                    cPara = eng.GetCompanyPara(dr("company_id_receive"))
                    If cPara.TH_EGIF_ORG_CODE <> "" Then
                        If Convert.IsDBNull(dr("is_send_thegif")) = False Then
                            If dr("is_send_thegif").ToString = "N" Then
                                ret += "&nbsp;&nbsp;<img id='imgSendToTHeGif" & dr("id").ToString & "' style='Height:20px;cursor:pointer;'"
                                ret += " src='../Images/TH-eGif_Logo.png' onClick=""SendToTHeGif(" & "'" & dr("id") & "'" & ",'imgSendToTHeGif" & dr("id").ToString & "')"" "
                                ret += " alt='ส่งข้อมูลออนไลน์ไปยัง " & cPara.THAINAME & "' title='ส่งข้อมูลออนไลน์ไปยัง " & cPara.THAINAME & "' />"
                            End If
                        End If
                    End If
                    cPara = Nothing
                    eng = Nothing
                Next
                dt = Nothing
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Shared Function GetBookOutDetailReports(ByVal vRegisID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
            Dim ret As String = ""
            Dim lnq As New Linq.TABLE.DocumentExtReceiverLinq
            Dim dt As New DataTable
            dt = lnq.GetDataList("document_register_id = '" & vRegisID & "'", "id", trans.Trans)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim tmp = "<br /><font color='Blue'>- " & dr("bookout_no") & "</font> "
                    If Convert.IsDBNull(dr("approve_date")) = False Then
                        tmp += "<br /><font color='Gray'>ลงนาม " & Convert.ToDateTime(dr("approve_date")).ToString("d MMM yy")
                    End If
                    If Convert.IsDBNull(dr("send_date")) = False Then
                        tmp += "<br />ส่งออก " & Convert.ToDateTime(dr("send_date")).ToString("d MMM yy") & "</font> "
                    End If

                    If ret = "" Then
                        ret = tmp
                    Else
                        ret += tmp
                    End If
                Next
                dt = Nothing
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Function GetBookNoByDocumentIntReceiverID(ByVal DocumentIntReceiverID As Long) As String
            Dim ret As String = ""
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim sql As String = "select top 1 dr.book_no "
            sql += " from document_register dr"
            sql += " inner join document_int_receiver ir on ir.document_register_id=dr.id"
            sql += " where ir.id= '" & DocumentIntReceiverID & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, Nothing)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("book_no")
            End If
            dt.Dispose()
            lnq = Nothing

            Return ret
        End Function

        Public Function GetElecDocDT(ByVal DocID As String) As DataTable
            Dim lnq As New Linq.TABLE.DocumentRegisterLinq
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            dt = lnq.GetListBySql("select * from doc_trans where id ='" & DocID & "'", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Shared Function BuildFileUploadListDT() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("no")
            dt.Columns.Add("description")
            dt.Columns.Add("mime_type")
            dt.Columns.Add("file_byte", GetType(Byte()))
            dt.Columns.Add("id")
            dt.Columns.Add("document_register_id")
            dt.Columns.Add("create_by")
            dt.Columns.Add("IsDel")
            Return dt
        End Function

        Public Function GetDocumentIntReceiverPara(ByVal vID As Long) As Para.TABLE.DocumentIntReceiverPara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.DocumentIntReceiverLinq
            Dim p As New Para.TABLE.DocumentIntReceiverPara
            p = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return p
        End Function


#Region "For Reports"
        Public Shared Function CalDueDate(ByVal ProcDate As Integer, ByVal ReceivedDate As DateTime) As DateTime
            Dim stDate As Date = ReceivedDate
            Dim endDate As Date = Nothing
            If ProcDate > 0 Then
                endDate = DateAdd(DateInterval.Day, ProcDate, stDate)
                Dim curDate As Date = stDate
                Do
                    Dim hDt As New DataTable
                    Dim hLnq As New Linq.TABLE.HolidayLinq
                    hDt = hLnq.GetDataList("convert(varchar(8),holiday_date,112) =  '" + curDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) + "' ", "holiday_date", Nothing)
                    If hDt.Rows.Count > 0 Then
                        endDate = DateAdd(DateInterval.Day, 1, endDate)
                    End If
                    hDt = Nothing
                    hLnq = Nothing
                    curDate = DateAdd(DateInterval.Day, 1, curDate)
                Loop While curDate <= endDate
            Else
                endDate = stDate
            End If
            Return endDate
        End Function
#End Region

    End Class
End Namespace

