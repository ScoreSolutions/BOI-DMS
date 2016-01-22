Imports System.IO
Imports Para.Common.Utilities
Imports Engine.Common
Namespace WebService
    Public Class DmsDocScanServiceENG
        Public Shared Function GetDocScanJobPara(ByVal ClientIP As String) As Para.TABLE.DocumentScanJobPara
            Dim para As New Para.TABLE.DocumentScanJobPara
            Dim lnq As New Linq.TABLE.DocumentScanJobLinq
            Dim wh As String = " client_ip='" & ClientIP & "' "
            wh += " and convert(varchar(16),job_start_date, 120)>='" & DateAdd(DateInterval.Minute, -1, DateTime.Now).ToString("yyyy-MM-dd HH:mm") & "'"
            wh += " and start_status = '" & Constant.DocumentScanJob.StartStatus.StartProgram & "' "

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As DataTable = lnq.GetDataList(wh, "", trans.Trans)
            If dt.Rows.Count > 0 Then
                para = lnq.GetParameter(Convert.ToInt64(dt.Rows(0)("id")), trans.Trans)
            End If
            trans.CommitTransaction()

            Return para
        End Function

        Public Shared Function SaveScanJob(ByVal UserName As String, ByVal ClientPage As String, ByVal ClientBrowser As String, ByVal ClientSessionID As String, ByVal RefID As String) As Long
            Dim lnq As New Linq.TABLE.DocumentScanJobLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            lnq.JOB_START_DATE = DateTime.Now
            lnq.CLIENT_IP = Engine.Common.FunctionENG.GetIPAddress
            lnq.CLIENT_PAGE = ClientPage
            lnq.CLIENT_BROWSER = ClientBrowser
            lnq.CLIENT_SESSIONID = ClientSessionID
            lnq.REF_ID = RefID
            lnq.START_STATUS = Para.Common.Utilities.Constant.DocumentScanJob.StartStatus.StartProgram.ToString

            Dim ret As Boolean = lnq.InsertData(UserName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            Return lnq.ID
        End Function

        Public Shared Function SetJobStatus(ByVal vJobID As Long, ByVal JobStatusID As Integer) As Boolean
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New Linq.TABLE.DocumentScanJobLinq
            lnq.GetDataByPK(vJobID, trans.Trans)
            lnq.START_STATUS = JobStatusID.ToString

            Dim ret As Boolean = lnq.UpdateByPK("Scan", trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function

        Public Shared Function GetScanJobPara(ByVal vJobID As Long) As Para.TABLE.DocumentScanJobPara
            Dim para As New Para.TABLE.DocumentScanJobPara
            Dim lnq As New Linq.TABLE.DocumentScanJobLinq
            
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            para = lnq.GetParameter(vJobID, trans.Trans)
            trans.CommitTransaction()

            Return para
        End Function



        Public Shared Function SaveFileScan(ByVal vJobID As Long, ByVal FileByte() As Byte, ByVal FileExt As String, ByVal FileDesc As String) As Boolean
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim ret As Boolean = False
            Dim jLnq As New Linq.TABLE.DocumentScanJobLinq
            If jLnq.GetDataByPK(vJobID, trans.Trans).ID <> 0 Then
                Dim lnq As New Linq.TABLE.DocumentScanTempLinq
                lnq.DOCUMENT_SCAN_JOB_ID = vJobID
                lnq.FILE_BYTE = FileByte
                lnq.FILE_EXTENTION = FileExt
                lnq.DESCRIPTION = FileDesc
                lnq.REF_TABLE = jLnq.CLIENT_PAGE
                lnq.REF_ID = jLnq.REF_ID
                lnq.ATTACH_STATUS = Para.Common.Utilities.Constant.DocumentScanJob.AttachStatus.WaitSave.ToString

                ret = lnq.InsertData("Scan", trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If

            Return ret
        End Function
    End Class
End Namespace

