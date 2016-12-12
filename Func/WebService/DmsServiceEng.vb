Imports System.Data
Imports Para.TABLE
Imports Linq.TABLE
Imports Linq.Common.Utilities


Namespace WebService
    Public Class DmsServiceEng
        Public Function GetAutoCompleteList(ByVal tbName As String, ByVal fldName As String, ByVal prefixText As String) As String()
            Dim str As String = ""
            str += " select distinct " & fldName
            str += " from " & tbName
            str += " where " & fldName & " like '" & prefixText & "%' "
            str += " order by " & fldName

            Dim dt As DataTable = SqlDB.ExecuteTable(str)
            Dim items As New List(Of String)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    items.Add(dr(fldName).ToString())
                Next
            End If

            Return items.ToArray()
        End Function

        

        Public Function StartProcSendDocLastStatus(ByVal SystemID As String, ByVal RecordCount As Integer) As Para.DmsService.StartSendDocumentResPara
            Dim ret As New Para.DmsService.StartSendDocumentResPara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If trans.Trans IsNot Nothing Then
                Dim lnq As New WsSenddocLogLinq
                lnq.SYSTEMID = SystemID
                lnq.RECORDCOUNT = RecordCount
                lnq.START_TIME = DateTime.Now

                If lnq.InsertData(SystemID, trans.Trans) = True Then
                    trans.CommitTransaction()
                    ret.Result = True
                    ret.SendREfID = lnq.ID
                Else
                    trans.RollbackTransaction()
                    ret.ErrorMessage = lnq.ErrorMessage
                    ret.Result = False
                End If
            Else
                ret.ErrorMessage = "Database Connection Fail!!!"
                ret.Result = False
            End If

            Return ret
        End Function

        Public Function SendDocument(ByVal para As Para.DmsService.SendDocumentReqPara) As Para.DmsService.SendDocumentResPara
            Dim ret As New Para.DmsService.SendDocumentResPara
            If Valid(para, ret) = True Then
                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                If trans.Trans IsNot Nothing Then
                    Dim lLnq As New WsSenddocLogLinq
                    lLnq.GetDataByPK(para.SendRefID, trans.Trans)
                    If lLnq.ID <> 0 Then
                        Dim lnq As New WsImportDocLaststatusLinq
                        lnq.WS_SENDDOC_LOG_ID = para.SendRefID
                        lnq.BOOK_NO = para.BookNo
                        lnq.REGISTER_DATE = para.RegisterDate
                        lnq.EXPECTED_FINISH_DATE = para.ExpectedFinishDate
                        lnq.COMPANY_DOC_NO = para.CompanyDocNo
                        lnq.COMPANY_DOC_DATE = para.CompanyDocDate
                        lnq.REFER_TO = para.ReferTo
                        lnq.GROUP_TITLE_CODE = para.GroupTitleCode
                        lnq.TITLE_NAME = para.TitleName
                        lnq.COMPANY_NAME = para.CompanyName
                        lnq.COMPANY_SIGN = para.CompanySign
                        lnq.REMARKS = para.Remarks
                        lnq.ORG_CODE_OWNER = para.OrgCodeOwner
                        lnq.OFFICER_ID_APPORVE = para.OfficerIDApprove
                        lnq.BOOK_OUT_NO = para.BookOutNo
                        lnq.BOOK_STATUS = para.BookStatus
                        lnq.CLOSE_DATE = para.CloseDate
                        lnq.ORG_CLOSE_PROCESS = para.OrgCloseProcess
                        lnq.STAFF_ID_PROCESS = para.StaffIDProcess
                        lnq.STAFF_OTHER_PROCESS = para.StaffOtherProcess

                        ret.Result = lnq.InsertData(lLnq.SYSTEMID, trans.Trans)
                        If ret.Result = True Then
                            ret.Result = UpdateDocumentLastStatus(lnq, trans)
                            If ret.Result = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                                ret.ErrorMessage = "Cannot update document"
                            End If
                        Else
                            trans.RollbackTransaction()
                            ret.ErrorMessage = lnq.ErrorMessage
                        End If
                    Else
                        ret.Result = False
                        ret.ErrorMessage = "Incorrect SendRefID"
                    End If
                Else
                    ret.ErrorMessage = "Database Connection Fail!!!"
                    ret.Result = False
                End If
            End If
            Return ret
        End Function

        Private Function UpdateDocumentLastStatus(ByVal wLnq As WsImportDocLaststatusLinq, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            If wLnq.ID <> 0 Then
                Dim lnq As New DocumentImportLaststatusLinq
                Dim chkData As Boolean = lnq.ChkDataByBOOK_NO(wLnq.BOOK_NO, trans.Trans)

                lnq.BOOK_NO = wLnq.BOOK_NO
                lnq.REGISTER_DATE = wLnq.REGISTER_DATE
                lnq.EXPECTED_FINISH_DATE = wLnq.EXPECTED_FINISH_DATE
                lnq.COMPANY_DOC_NO = wLnq.COMPANY_DOC_NO
                lnq.COMPANY_DOC_DATE = wLnq.COMPANY_DOC_DATE
                lnq.REFER_TO = wLnq.REFER_TO
                lnq.GROUP_TITLE_CODE = wLnq.GROUP_TITLE_CODE
                lnq.TITLE_NAME = wLnq.TITLE_NAME
                lnq.COMPANY_NAME = wLnq.COMPANY_NAME
                lnq.COMPANY_SIGN = wLnq.COMPANY_SIGN
                lnq.REMARKS = wLnq.REMARKS
                lnq.ORG_CODE_OWNER = wLnq.ORG_CODE_OWNER
                lnq.OFFICER_ID_APPORVE = wLnq.OFFICER_ID_APPORVE
                lnq.BOOK_OUT_NO = wLnq.BOOK_OUT_NO
                lnq.BOOK_STATUS = wLnq.BOOK_STATUS
                lnq.CLOSE_DATE = wLnq.CLOSE_DATE
                lnq.ORG_CLOSE_PROCESS = wLnq.ORG_CLOSE_PROCESS
                lnq.STAFF_ID_PROCESS = wLnq.STAFF_ID_PROCESS
                lnq.STAFF_OTHER_PROCESS = wLnq.STAFF_OTHER_PROCESS
                lnq.REF_WS_IMPORT_DOC_LASTSTATUS = wLnq.ID

                If chkData = False Then
                    ret = lnq.InsertData(wLnq.CREATE_BY, trans.Trans)
                Else
                    ret = lnq.UpdateByPK(wLnq.CREATE_BY, trans.Trans)
                End If
                lnq = Nothing
            End If

            Return ret
        End Function

        Private Function Valid(ByVal para As Para.DmsService.SendDocumentReqPara, ByVal ret As Para.DmsService.SendDocumentResPara) As Boolean
            Dim chk As Boolean = True
            If para.BookNo.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุเลขที่หนังสือ"
            ElseIf para.RegisterDate.Year = 1 Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุวันที่ลงทะเบียน"
            ElseIf para.GroupTitleCode.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุรหัสกลุ่มเรื่อง"
            ElseIf para.TitleName.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุชื่อเรื่อง"
            ElseIf para.CompanyName.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุชื่อหน่วยงาน"
            ElseIf para.OrgCodeOwner.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุรหัสหน่วยงานเจ้าของเรื่อง"
            ElseIf para.OfficerIDApprove.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุรหัสเจ้าหน้าที่ผู้พิจารณา"
            ElseIf para.BookStatus.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุสถานะหนังสือ"
            ElseIf para.OrgCloseProcess.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุหน่วยงานผู้ถือครองล่าสุด"
            ElseIf para.StaffIDProcess.Trim = "" Then
                chk = False
                ret.ErrorMessage = "กรุณาระบุรหัสผู้ถือครองล่าสุด"
            End If
            ret.Result = chk

            Return chk
        End Function

        Private Function ChkRecordCount(ByVal SendRefID As Integer, ByVal RecordCount As Integer, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim ret As Boolean = False
            Dim lnq As New Linq.TABLE.WsImportDocLaststatusLinq
            Dim dt As DataTable = lnq.GetDataList("ws_senddoc_log_id = " & SendRefID, "", trans.Trans)
            If dt.Rows.Count = RecordCount Then
                ret = True
            End If
            Return ret
        End Function

        Public Function FinishProcSendDocLastStatus(ByVal SendRefID As Integer) As Para.DmsService.FinishSendDocumentResPara
            Dim ret As New Para.DmsService.FinishSendDocumentResPara
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If trans.Trans IsNot Nothing Then
                Dim lnq As New WsSenddocLogLinq
                lnq.GetDataByPK(SendRefID, trans.Trans)
                lnq.END_TIME = DateTime.Now
                If ChkRecordCount(SendRefID, lnq.RECORDCOUNT, trans) = False Then
                    lnq.ERR_MESSAGE = "จำนวนเอกสารที่นำเข้าไม่ครบถ้วน"
                    ret.Result = False
                    ret.ErrorMessage = lnq.ERR_MESSAGE
                Else
                    ret.Result = True
                End If

                If lnq.UpdateByPK(lnq.SYSTEMID, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    ret.ErrorMessage = lnq.ErrorMessage
                    ret.Result = False
                End If
            Else
                ret.ErrorMessage = "Database Connection Fail!!!"
                ret.Result = False
            End If

            Return ret
        End Function
    End Class
End Namespace
