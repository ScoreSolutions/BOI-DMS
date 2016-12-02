Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Imports System.Data.SqlClient
Imports Linq.Common.Utilities.SqlDB
Imports Linq.Common.Utilities
Imports Para.Common.Utilities
Imports System.IO

Partial Class UserPageControls_ctlDocBookDetailShow
    Inherits System.Web.UI.UserControl


    Public ReadOnly Property PageTitle() As String
        Get
            Return Me.Page.Title
        End Get
    End Property

    Public ReadOnly Property DocID() As String
        Get
            Return lblID.Text
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("id") IsNot Nothing Then
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.DocumentRegisterPara
            Dim eng As New Engine.Document.DocumentRegisterENG
            para = eng.GetDocumentPara(Request("id"), trans) '
            ShowDocDetail(para, trans, eng)
            trans.CommitTransaction()
            eng = Nothing
        End If
    End Sub

    Public Sub SearchDocByBookNo(ByVal vBookNo As String)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim para As New Para.TABLE.DocumentRegisterPara
        Dim eng As New Engine.Document.DocumentRegisterENG
        para = eng.GetDocumentParaByBookNo(vBookNo, trans)
        If para.ID > 0 Then
            If para.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobIncome Then
                ShowDocDetail(para, trans, eng)
            Else
                ClearDocDetail()
                Config.SetAlert("เลขที่หนังสือ " & vBookNo & " ไม่อยู่ในสถานะที่สามารถแก้ไขได้", Me.Page)
            End If
        Else
            ClearDocDetail()
            Config.SetAlert("ไม่พบข้อมูล", Me.Page)
        End If

        trans.CommitTransaction()
        eng = Nothing
    End Sub

    Public Sub SearchBookNoForChangeCompany(ByVal vBookNo As String)
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim para As New Para.TABLE.DocumentRegisterPara
        Dim eng As New Engine.Document.DocumentRegisterENG
        para = eng.GetDocumentParaByBookNo(vBookNo, trans)
        If para.ID > 0 Then
            If para.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobClose Then
                ShowDocDetail(para, trans, eng)
            Else
                ClearDocDetail()
                Config.SetAlert("เลขที่หนังสือ " & vBookNo & " ไม่อยู่ในสถานะจบงาน", Me.Page)
            End If
        Else
            ClearDocDetail()
            Config.SetAlert("ไม่พบข้อมูล", Me.Page)
        End If

        trans.CommitTransaction()
        eng = Nothing
    End Sub


    Private Sub ShowDocDetail(ByVal para As Para.TABLE.DocumentRegisterPara, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal eng As Engine.Document.DocumentRegisterENG)
        lblID.Text = para.ID
        lblBookNo.Text = para.BOOK_NO
        If para.REGISTER_DATE.Value.Year <> 1 Then
            lblRegisDate.Text = para.REGISTER_DATE.Value.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If
        Me.Page.Title = "รายละเอียดหนังสือ เลขที่ : " & para.BOOK_NO

        lblRequestNo.Text = para.REQUEST_NO
        If para.REQUEST_NO.Trim <> "" Then
            lblRequestNo.Text += "&nbsp;&nbsp;<img src='../Images/TH.png' width='20' onClick='PrintReport(" & Chr(34) & "Report_TH" & Chr(34) & "," & para.ID & ")' title='พิมพ์ใบแจ้งการตอบรับการยื่นคำขอรับการส่งเสริมการลงทุน' style='cursor:pointer;' /> "
            lblRequestNo.Text += "&nbsp;<img src='../Images/USA.png' width='20' onClick='PrintReport(" & Chr(34) & "Report_EN" & Chr(34) & "," & para.ID & ")' title='NOTIFICATION OF RECEIPT OF APPLICATION FOR INVESTMENT PROMOTION' style='cursor:pointer;' /> "
        End If

        lblCompanyDocNo.Text = para.COMPANY_DOC_NO
        If para.COMPANY_DOC_DATE.Value.Year <> 1 Then
            lblCompanyDocDate.Text = para.COMPANY_DOC_DATE.Value.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If

        If para.REF_DOCUMENT_REGISTER_ID <> 0 Then
            Dim refPara As New Para.TABLE.DocumentRegisterPara
            refPara = eng.GetDocumentPara(para.REF_DOCUMENT_REGISTER_ID, trans)
            lblReferTo.Text = refPara.BOOK_NO
        End If

        Dim gPara As New Para.TABLE.GroupTitlePara
        Dim gEng As New Engine.Master.GroupTitleEng
        gPara = gEng.GetGroupTitlePara(para.GROUP_TITLE_ID)
        lblGroupTitleName.Text = gPara.GROUP_TITLE_NAME
        gPara = Nothing
        gEng = Nothing

        lblTitleName.Text = para.TITLE_NAME

        Dim bPara As Para.TABLE.BusinessTypePara = Engine.Master.CompanyEng.GetBusinessTypePara(para.BUSINESS_TYPE_ID)
        lblBusinessType.Text = bPara.BUSINESS_TYPE_NAME
        bPara = Nothing

        lblCompanyName.Text = para.COMPANY_NAME
        lblCompanyDocNo.Text = para.COMPANY_DOC_NO
        If para.COMPANY_DOC_DATE.Value.Year <> 1 Then
            lblCompanyDocDate.Text = para.COMPANY_DOC_DATE.Value.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If

        lblCompanySign.Text = para.COMPANY_SIGN
        lblRemarks.Text = para.REMARKS

        lblOrgOwnName.Text = para.ORGANIZATION_NAME
        lblOfficerOwnName.Text = para.OFFICER_NAME
        lblBookNo.Text = para.BOOK_NO
        Dim bookoutno As String = Engine.Document.DocumentRegisterENG.GetBookOutDetail(lblID.Text, trans)
        lblBookoutNo.Text = bookoutno

        Dim sttPara As New Para.TABLE.DocStatusPara
        Dim sttEng As New Engine.Master.DocStatusEng
        sttPara = sttEng.GetStatusPara(Convert.ToInt64(para.DOC_STATUS_ID))
        lblBookStatus.Text = sttPara.DOC_STATUS_NAME
        sttPara = Nothing
        sttEng = Nothing

        If para.EXPECT_FINISH_DATE.Value.Year <> 1 Then
            lblExpectFinishDate.Text = para.EXPECT_FINISH_DATE.Value.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If
        If para.CLOSE_DATE.Value.Year <> 1 Then
            lblCloseDate.Text = para.CLOSE_DATE.Value.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        End If

        Dim dt As New DataTable
        Dim SearchEng As New Engine.Document.SearchDocumentENG
        dt = SearchEng.GetDocumentSendList(para.ID, trans)

        If dt.Rows.Count > 0 Then
            dt.Columns.Add("No")
            Dim tmpNo As Int16 = dt.Rows.Count
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("No") = tmpNo
                tmpNo -= 1
            Next

            gvSendList.DataSource = dt
            gvSendList.DataBind()

        End If
        If para.ELECTRONIC_DOC_ID <> 0 Then
            imgPrintElec.Visible = True
            imgPrintElec.Attributes.Add("onClick", "PrintReport(" & GetPrintCond(para.ELECTRONIC_DOC_ID, trans) & "); return false;")
        End If

        If para.DOC_STATUS_ID = Constant.DocumentRegister.DocStatusID.JobRemain Then
            'If dt.Rows.Count > 0 Then
            If Convert.IsDBNull(dt.Rows(0)("organization_id_receive")) = False Then
                If Convert.ToInt64(dt.Rows(0)("organization_id_receive")) = Config.GetLogOnUser.ORG_DATA.ID Then
                    btnEdit.Visible = True
                End If
            End If
            'End If
        End If



        eng = New Engine.Document.DocumentRegisterENG
        dt = eng.GetAttachFileList(para.ID)
        dt.Columns.Add("no")
        dt.Columns.Add("file_byte", GetType(Byte()))
        If dt.Rows.Count > 0 Then
            Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
                If File.Exists(Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(i)("file_name")) = True Then
                    dt.Rows(i)("file_byte") = File.ReadAllBytes(Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(i)("file_name"))
                End If
                If Convert.IsDBNull(dt.Rows(i)("description")) = True Then
                    dt.Rows(i)("description") = "-"
                End If
            Next
        End If
        eng = Nothing

        Session(Constant.SessFileUploadList) = dt
        gvFiles.DataSource = dt
        gvFiles.DataBind()


        Config.SaveTransLog("แสดงรายละเอียดหนังสือเลขที่ :" & para.BOOK_NO, Config.GetLoginHistoryID)

        SearchEng = Nothing
        para = Nothing
        dt.Dispose()
    End Sub

    Protected Sub gvFiles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvFiles.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim img As ImageButton = e.Row.FindControl("imgDownload")
        '    Dim id As Long = e.Row.Cells(4).Text
        '    Dim RowID As Int16 = e.Row.RowIndex
        '    Dim grv As GridViewRow = e.Row

        '    Dim dt As DataTable
        '    Dim FileName As String = ""
        '    If id = "0" Then
        '        dt = Session(Constant.SessFileUploadList)
        '        FileName = Session.SessionID & dt.Rows(e.Row.RowIndex)("mime_type")
        '    Else
        '        Dim eng As New Engine.Document.DocumentRegisterENG
        '        dt = eng.GetAttachFileList(lblDocumentRegisterID.Text)
        '        FileName = dt.Rows(e.Row.RowIndex)("file_name")
        '        eng = Nothing
        '    End If

        'End If
    End Sub

    Protected Sub imgDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim img As ImageButton = sender
        Dim grv As GridViewRow = img.Parent.Parent
        Dim index As Integer = grv.RowIndex
        Dim dt As DataTable = Session(Constant.SessFileUploadList)

        If dt.Rows(index)("id").ToString = "0" Then
            Dim TmpDir As String = Engine.Common.FunctionENG.GetFileUploadPath() & "\TmpFile"
            If Directory.Exists(TmpDir) = False Then
                Directory.CreateDirectory(TmpDir)
            End If

            Dim FileName As String = Session.SessionID & dt.Rows(index)("mime_type")
            Dim TmpFile As String = TmpDir & "\" & FileName
            If File.Exists(TmpFile) = True Then
                File.Delete(TmpFile)
            End If
            Dim FileByte() As Byte = CType(dt.Rows(index)("file_byte"), Byte())

            Dim fs As FileStream
            Try
                fs = New FileStream(TmpFile, FileMode.CreateNew)
                fs.Write(FileByte, 0, FileByte.Length)
                fs.Close()
                Config.SaveTransLog("ดาวน์โหลดเอกสาร ชื่อ " & dt.Rows(index)("description"))
                Response.Redirect(Engine.Common.FunctionENG.GetFileUploadURL(Request) & "TmpFile/" & FileName & "?rnd=" & DateTime.Now.Millisecond)
            Catch ex As Exception
                Config.SetAlert(ex.Message, Me.Page)
            End Try
        Else
            Config.SaveTransLog("ดาวน์โหลดเอกสาร ชื่อ " & dt.Rows(index)("description"))
            Response.Redirect(Engine.Common.FunctionENG.GetFileUploadURL(Request) & dt.Rows(index)("file_name").ToString & "?rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    'Protected Sub gvFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvFiles.RowCommand
    '    Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
    '    Dim index As Integer = gvRow.RowIndex
    '    Dim dt As DataTable
    '    If lblDocumentRegisterID.Text = "0" Then
    '        dt = Session(Constant.SessFileUploadList)
    '    Else
    '        Dim en As New Engine.Document.DocumentRegisterENG
    '        dt = en.GetAttachFileList(lblDocumentRegisterID.Text)
    '        dt.Columns.Add("no")
    '        dt.Columns.Add("file_byte", GetType(Byte()))
    '        dt.Columns.Add("IsDel")
    '        If dt.Rows.Count > 0 Then
    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                dt.Rows(i)("no") = (i + 1)
    '                dt.Rows(i)("file_byte") = File.ReadAllBytes(Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(i)("file_name"))
    '                dt.Rows(i)("IsDel") = IIf(dt.Rows(i)("create_by").ToString = Config.GetLogOnUser.UserName, "Y", "N")
    '                If Convert.IsDBNull(dt.Rows(i)("description")) = True Then
    '                    dt.Rows(i)("description") = "-"
    '                End If
    '            Next
    '        End If
    '        en = Nothing
    '    End If

    '    If e.CommandName = "Edit" Then
    '        'CancelEdit(dt.Rows(index)("id"))
    '        Dim FilePara As New Para.Common.TmpFileUploadPara
    '        FilePara.TmpFileByte = dt.Rows(index)("file_byte")
    '        FilePara.FileExtent = dt.Rows(index)("mime_type")
    '        ctlBrowseFile1.TmpFileUploadPara = FilePara
    '        txtDescription.Text = dt.Rows(index)("description")
    '        lblDocumentRegisterID.Text = dt.Rows(index)("document_register_id")
    '        lblID.Text = dt.Rows(index)("id")
    '        lblRowIndex.Text = index
    '        lblRowNo.Text = dt.Rows(index)("no")
    '    ElseIf e.CommandName = "Delete" Then
    '        Dim ret As Boolean = True
    '        Dim _err As String = ""
    '        Dim FileName As String = ""

    '        If Convert.ToInt64(dt.Rows(index)("id")) > 0 Then
    '            Dim eng As New Engine.Document.DocumentRegisterENG
    '            ret = eng.DeleteAttachFile(Convert.ToInt64(dt.Rows(index)("id")))
    '            _err = eng.ErrorMessage
    '            eng = Nothing
    '            FileName = Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(index)("file_name")
    '        Else
    '            FileName = Engine.Common.FunctionENG.GetFileUploadPath() & "\TmpFile\" & Session.SessionID & dt.Rows(index)("mime_type")
    '        End If

    '        If ret = True Then
    '            If File.Exists(FileName) Then
    '                File.Delete(FileName)
    '            End If
    '            dt.Rows.RemoveAt(index)
    '            If dt.Rows.Count > 0 Then
    '                For i As Integer = 0 To dt.Rows.Count - 1
    '                    dt.Rows(i)("no") = (i + 1)
    '                Next
    '                gvFiles.DataSource = dt
    '                gvFiles.DataBind()
    '                Session(Constant.SessFileUploadList) = dt
    '            Else
    '                gvFiles.DataSource = Nothing
    '                gvFiles.DataBind()
    '                Session.Remove(Constant.SessFileUploadList)
    '            End If
    '        Else
    '            Config.SetAlert(_err, Me)
    '        End If
    '    Else
    '        Dim FileName As String = ""
    '        If dt.Rows(index)("id").ToString = "0" Then
    '            Dim TmpDir As String = Engine.Common.FunctionENG.GetFileUploadPath() & "\TmpFile"
    '            If Directory.Exists(TmpDir) = False Then
    '                Directory.CreateDirectory(TmpDir)
    '            End If

    '            FileName = Session.SessionID & dt.Rows(index)("mime_type")
    '            Dim TmpFile As String = TmpDir & "\" & FileName

    '            Dim fleList As String() = Directory.GetFiles(TmpDir)
    '            If fleList.Length > 0 Then
    '                For Each fla As String In fleList
    '                    Dim f As New FileInfo(fla)
    '                    If f.Name.Replace(f.Extension, "") = Session.SessionID Then
    '                        File.Delete(f.FullName)
    '                    End If
    '                Next
    '            End If

    '            Dim FileByte() As Byte = CType(dt.Rows(index)("file_byte"), Byte())
    '            Dim fs As FileStream
    '            Try
    '                fs = New FileStream(TmpFile, FileMode.CreateNew)
    '                fs.Write(FileByte, 0, FileByte.Length)
    '                fs.Close()
    '            Catch ex As Exception
    '                Config.SetAlert(ex.Message, Me)
    '            End Try
    '        Else
    '            FileName = dt.Rows(index)("file_name")
    '        End If

    '        Dim OpenDwnScr As String = "<script language='javascript'>OpenDownload('id=" & dt.Rows(index)("id").ToString & "&FileName=" & FileName & "&RowID=" & index & "&rnd=" & DateTime.Now.Millisecond & "');</script>"
    '        ScriptManager.RegisterStartupScript(Me, GetType(String), "OpenDwn", OpenDwnScr, False)
    '    End If
    'End Sub

    Private Sub ClearDocDetail()
        lblID.Text = "0"
        lblBookNo.Text = ""
        lblRegisDate.Text = ""
        lblRequestNo.Text = ""
        lblRequestNo.Text = ""
        lblCompanyDocNo.Text = ""
        lblCompanyDocDate.Text = ""
        lblReferTo.Text = ""
        lblGroupTitleName.Text = ""
        lblTitleName.Text = ""
        lblBusinessType.Text = ""
        lblCompanyName.Text = ""
        lblCompanyDocNo.Text = ""
        lblCompanyDocDate.Text = ""
        lblCompanySign.Text = ""
        lblRemarks.Text = ""
        lblOrgOwnName.Text = ""
        lblOfficerOwnName.Text = ""
        lblBookNo.Text = ""
        lblBookoutNo.Text = ""
        lblBookStatus.Text = ""
        lblExpectFinishDate.Text = ""
        lblCloseDate.Text = ""
        gvSendList.DataSource = Nothing
        gvSendList.DataBind()
    End Sub

    Private Function GetPrintCond(ByVal ElecDocID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
        Dim ret As String = ""
        Dim sql As String = "select doc_type from doc_trans where id='" & ElecDocID & "' "
        Dim dt As New DataTable
        dt = Linq.Common.Utilities.SqlDB.ExecuteTable(sql, trans.Trans)
        If dt.Rows.Count > 0 Then
            Dim docid As String = dt.Rows(0)("doc_type").ToString
            If docid = FormBookOutID Then
                ret = "'BOI_1'"
            ElseIf docid = FormBookInID Then
                ret = "'BOI_2'"
            ElseIf docid = FormBookSealID Then
                ret = "'BOI_3'"
            ElseIf docid = FormBookCommandID Then
                ret = "'BOI_4'"
            ElseIf docid = FormBookRuleID Then
                ret = "'BOI_5'"
            ElseIf docid = FormBookRegulationID Then
                ret = "'BOI_6'"
            ElseIf docid = FormBookNoticeID Then
                ret = "'BOI_7'"
            ElseIf docid = FormBookStateID Then
                ret = "'BOI_8'"
            ElseIf docid = FormBookNewsID Then
                ret = "'BOI_9'"
            ElseIf docid = FormBookAssureID Then
                ret = "'BOI_10'"
            ElseIf docid = FormBookMinutesID Then
                ret = "'BOI_11'"
            ElseIf docid = FormBookNoteID Then
                ret = "'BOI_12'"
            End If
            ret += ",'" & ElecDocID & "'"
            dt.Dispose()
        End If
        Return ret
    End Function

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Config.SaveTransLog("คลิกปุ่ม แก้ไขรายละเอียดเลขที่ " & lblBookNo.Text & " ชื่อเรื่อง :" & lblTitleName.Text, Config.GetLoginHistoryID)
        Response.Redirect("../WebApp/frmDocRegisterEdit.aspx?id=" & lblID.Text & "&rnd=" & DateTime.Now.Millisecond)
    End Sub
End Class
