Imports System.IO
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Engine.Common

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DmsDocScanWebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function SendFileToServer(ByVal FileByte() As Byte, ByVal FileName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim fs As FileStream
            If File.Exists(FunctionENG.GetFileUploadPath & FileName) = True Then
                File.Delete(FunctionENG.GetFileUploadPath & FileName)
            End If

            fs = New FileStream(FunctionENG.GetFileUploadPath & FileName, FileMode.CreateNew)
            fs.Write(FileByte, 0, FileByte.Length)
            fs.Close()
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function SendFileStreamToServer(ByVal FileByte As String, ByVal FileName As String, FileCount As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            'Dim fs As FileStream
            'fs = New FileStream(FunctionENG.GetFileUploadPath & FileName, FileMode.CreateNew)
            'fs.Write(Convert.(FileByte), 0, FileByte.Length)
            'fs.Close()

            Dim FldName() As String = Split(FileName, ".")
            Dim DirPath As String = FunctionENG.GetFileUploadPath & FldName(0)
            If Directory.Exists(DirPath) = False Then
                Directory.CreateDirectory(DirPath)
            End If

            Dim fs As New StreamWriter(DirPath & "\" & FileCount & ".txt", True)
            fs.Write(FileByte)
            fs.Close()
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function ConvertStringFileToByte(ByVal FileName As String) As Boolean
        Dim ret As Boolean = False

        Dim FldName() As String = Split(FileName, ".")
        Dim DirPath As String = FunctionENG.GetFileUploadPath & FldName(0)
        For Each f As String In Directory.GetFiles(DirPath)
            Try
                Dim fByte() As Byte = Convert.FromBase64String(File.ReadAllText(f))
                Dim fs As FileStream
                fs = New FileStream(FunctionENG.GetFileUploadPath & FileName, FileMode.Append)
                fs.Write(fByte, 0, fByte.Length)
                fs.Close()

                ret = True
            Catch ex As Exception
                ret = False

                Dim fs As New StreamWriter(DirPath & "\ErrorLog_" & DateTime.Now.ToString("yyyyMMdd") & ".txt", True)
                fs.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & vbNewLine)
                fs.Close()
            End Try

            If ret = False Then
                Exit For
            End If
        Next
        Return ret
    End Function

    <WebMethod()> _
    Public Function DeleteIsDuplicateFile(ByVal FileName As String) As Boolean
        Dim ret As Boolean = False

        Dim FldName() As String = Split(FileName, ".")
        Dim FilePath As String = FunctionENG.GetFileUploadPath & FldName(0)
        If Directory.Exists(FilePath) = True Then
            For Each f As String In Directory.GetFiles(FilePath)
                Try
                    File.SetAttributes(f, FileAttributes.Normal)
                    File.Delete(f)
                    ret = True
                Catch ex As Exception

                End Try
            Next

            Directory.Delete(FilePath, True)
        End If
        Return ret
    End Function

    '<WebMethod()> _
    'Public Function LoadFileFromServer(ByVal FileName As String) As Byte()
    '    Dim FileByte() As Byte = Nothing
    '    If File.Exists(FunctionENG.GetFileUploadPath & FileName) = True Then
    '        FileByte = File.ReadAllBytes(FunctionENG.GetFileUploadPath & FileName)
    '    End If
    '    Return FileByte
    'End Function

    '<WebMethod()> _
    'Public Function GetDocumentDetail(ByVal vID As Long) As Para.TABLE.DocumentRegisterPara
    '    Dim trans As New Linq.Common.Utilities.TransactionDB
    '    trans.CreateTransaction()
    '    Dim para As New Para.TABLE.DocumentRegisterPara
    '    Dim eng As New Engine.Document.DocumentRegisterENG
    '    para = eng.GetDocumentPara(vID, trans)
    '    trans.CommitTransaction()
    '    Return para
    'End Function

    <WebMethod()> _
    Public Function CheckScanStartJob(ByVal ClientIP As String) As Para.TABLE.DocumentScanJobPara
        Return Engine.WebService.DmsDocScanServiceENG.GetDocScanJobPara(ClientIP)
    End Function

    <WebMethod()> _
    Public Function GetScanJobPara(ByVal vJobID As Long) As Para.TABLE.DocumentScanJobPara
        Return Engine.WebService.DmsDocScanServiceENG.GetDocScanJobPara(vJobID)
    End Function

    <WebMethod()> _
    Public Function GetCurrentFileList(ByVal vJobID As Long, ByVal RefID As Long) As DataTable
        Dim dt As New DataTable
        Dim eng As New Engine.Document.DocumentRegisterENG

        If RefID = 0 Then
            Dim tmpDt As New DataTable
            tmpDt = eng.GetDocScanTmpList(vJobID, RefID)
            If tmpDt.Rows.Count > 0 Then
                dt.Columns.Add("id")
                dt.Columns.Add("document_register_id")
                dt.Columns.Add("file_name")
                dt.Columns.Add("file_path")
                dt.Columns.Add("description")
                dt.Columns.Add("mime_type")
                dt.Columns.Add("file_byte", GetType(Byte()))

                For Each tmpDr As DataRow In tmpDt.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = tmpDr("DOCUMENT_SCAN_TEMP_ID")
                    dr("document_register_id") = RefID
                    dr("file_name") = ""
                    dr("file_path") = ""
                    dr("description") = tmpDr("description")
                    dr("mime_type") = tmpDr("file_extention")
                    dr("file_byte") = tmpDr("file_byte")
                    dt.Rows.Add(dr)
                Next

                tmpDt = Nothing
            End If
        Else
            dt = eng.GetAttachFileList(RefID)
            dt.Columns.Add("file_byte", GetType(Byte()))
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)
                    Dim FileName As String = dr("file_name")

                    If File.Exists(FunctionENG.GetFileUploadPath & FileName) = True Then
                        dt.Rows(i)("file_byte") = File.ReadAllBytes(FunctionENG.GetFileUploadPath & FileName)
                    End If
                Next
            End If
        End If
        eng = Nothing

        dt.TableName = "CurrentFileList"
        Return dt
    End Function

    <WebMethod()> _
    Public Function SaveFileScan(ByVal vJobID As Long, ByVal FileByte() As Byte, ByVal FileExt As String, ByVal FileDesc As String) As Boolean
        Return Engine.WebService.DmsDocScanServiceENG.SaveFileScan(vJobID, FileByte, FileExt, FileDesc)
    End Function

    <WebMethod()> _
    Public Function SetJobStatus(ByVal vJobID As Long, ByVal JobStatusID As JobStatus) As Boolean
        Return Engine.WebService.DmsDocScanServiceENG.SetJobStatus(vJobID, JobStatusID)
    End Function

    <WebMethod()> _
    Public Function DeleteAttachFile(ByVal vID As Long) As Boolean
        Dim eng As New Engine.Document.DocumentRegisterENG
        Return eng.DeleteAttachFile(vID)
    End Function

    '<WebMethod()> _
    'Public Function TestSaveFileScan() As Boolean
    '    Dim FileByte() As Byte = Nothing
    '    If File.Exists("C:\AlterTableCSI_20120619.sql") = True Then
    '        FileByte = File.ReadAllBytes("C:\AlterTableCSI_20120619.sql")
    '    End If
    '    Return SaveFileScan(17, FileByte, ".sql", "ทดสอบ")
    'End Function
End Class

Public Enum JobStatus As Integer
    ProgramStarted = Para.Common.Utilities.Constant.DocumentScanJob.StartStatus.ProgramStarted
    ProgramClosed = Para.Common.Utilities.Constant.DocumentScanJob.StartStatus.ProgramClosed
End Enum