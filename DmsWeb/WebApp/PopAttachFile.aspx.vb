Imports System.Data
Imports Para.Common.Utilities
Imports System.IO

Partial Class WebApp_PopAttachFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim dt As New DataTable
            If Request("id") = "0" Then
                If Session(Constant.SessFileUploadList) IsNot Nothing Then
                    dt = Session(Constant.SessFileUploadList)
                End If
            Else
                lblDocumentRegisterID.Text = Request("id")
                Dim eng As New Engine.Document.DocumentRegisterENG
                dt = eng.GetAttachFileList(lblDocumentRegisterID.Text)
                dt.Columns.Add("no")
                dt.Columns.Add("file_byte", GetType(Byte()))
                dt.Columns.Add("IsDel")
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
                        dt.Rows(i)("IsDel") = IIf(dt.Rows(i)("create_by").ToString = uPara.UserName, "Y", "N")
                    Next
                    'Session(Constant.SessFileUploadList) = dt
                End If
                eng = Nothing
                Config.SaveTransLog("แสดงรายละเอียดเอกสารแนบ : DOCUMENT_REGISTER_ID=" & lblDocumentRegisterID.Text)
            End If

            GridView1.DataSource = dt
            GridView1.DataBind()
            dt = Nothing
        End If
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        If ctlBrowseFile1.HasFile = False Then
            ret = False
            Config.SetAlert("กรุณาเลือกไฟล์เอกสารที่ต้องการแนบ", Me)
        ElseIf txtDescription.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณาระบุรายละเอียด", Me, txtDescription.ClientID)
        End If

        Return ret
    End Function

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If Valid() = True Then
            Dim dt As New DataTable
            Dim dr As DataRow
            If lblDocumentRegisterID.Text = "0" Then
                'หน้าจอลงทะเบียน
                If Session(Constant.SessFileUploadList) Is Nothing Then
                    dt = Engine.Document.DocumentRegisterENG.BuildFileUploadListDT()
                Else
                    dt = Session(Constant.SessFileUploadList)
                End If

                If lblRowNo.Text = "0" Then
                    'กรณีเพิ่มจากหน้าลงทะเบียน
                    dr = dt.NewRow
                    dr("description") = txtDescription.Text
                    dr("mime_type") = ctlBrowseFile1.TmpFileUploadPara.FileExtent
                    dr("file_byte") = ctlBrowseFile1.TmpFileUploadPara.TmpFileByte
                    dr("document_register_id") = lblDocumentRegisterID.Text
                    dr("id") = "0"
                    dr("create_by") = Config.GetLogOnUser.UserName
                    dt.Rows.Add(dr)
                Else
                    'กรณีแก้ไข จากหน้าลงทะเบียน
                    dr = dt.Rows(lblRowIndex.Text)
                    dr("description") = txtDescription.Text
                    dr("mime_type") = ctlBrowseFile1.TmpFileUploadPara.FileExtent
                    dr("file_byte") = ctlBrowseFile1.TmpFileUploadPara.TmpFileByte
                    dr("document_register_id") = lblDocumentRegisterID.Text
                    dr("id") = dt.Rows(lblRowIndex.Text)("id")
                End If
                Session(Constant.SessFileUploadList) = dt
            Else
                'หน้าจออื่นๆ
                dt = Engine.Document.DocumentRegisterENG.BuildFileUploadListDT()
                dr = dt.NewRow
                dr("description") = txtDescription.Text
                dr("mime_type") = ctlBrowseFile1.TmpFileUploadPara.FileExtent
                dr("file_byte") = ctlBrowseFile1.TmpFileUploadPara.TmpFileByte
                dr("document_register_id") = lblDocumentRegisterID.Text
                dr("id") = lblID.Text
                dr("no") = (GridView1.Rows.Count + 1)

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                Dim eng As New Engine.Document.DocumentRegisterENG
                If eng.SaveAttachFile(Config.GetLogOnUser.UserName, Convert.ToInt64(lblDocumentRegisterID.Text), dr, trans) = True Then
                    trans.CommitTransaction()

                    dt = eng.GetAttachFileList(lblDocumentRegisterID.Text)
                    dt.Columns.Add("no")
                    dt.Columns.Add("file_byte", GetType(Byte()))
                Else
                    trans.RollbackTransaction()
                End If
                eng = Nothing
            End If

            If dt.Rows.Count > 0 Then
                If dt.Columns.Contains("IsDel") = False Then
                    dt.Columns.Add("IsDel")
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = (i + 1)
                    dt.Rows(i)("IsDel") = IIf(dt.Rows(i)("create_by").ToString = Config.GetLoginSessionPara.USER_NAME, "Y", "N")
                Next
                GridView1.DataSource = dt
                GridView1.DataBind()
            End If
            Config.SaveTransLog("เพิ่มเอกสารแนบ")

            ClearForm()
        End If
    End Sub

    Private Sub ClearForm()
        txtDescription.Text = ""
        ctlBrowseFile1.ClearFile()
        lblRowIndex.Text = "0"
        lblRowNo.Text = "0"
        lblID.Text = "0"
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
                Config.SetAlert(ex.Message, Me)
            End Try
        Else
            Config.SaveTransLog("ดาวน์โหลดเอกสาร ชื่อ " & dt.Rows(index)("description"))
            Response.Redirect(Engine.Common.FunctionENG.GetFileUploadURL(Request) & dt.Rows(index)("file_name").ToString & "?rnd=" & DateTime.Now.Millisecond)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim gvRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        Dim dt As DataTable
        If lblDocumentRegisterID.Text = "0" Then
            dt = Session(Constant.SessFileUploadList)
        Else
            Dim en As New Engine.Document.DocumentRegisterENG
            dt = en.GetAttachFileList(lblDocumentRegisterID.Text)
            dt.Columns.Add("no")
            dt.Columns.Add("file_byte", GetType(Byte()))
            dt.Columns.Add("IsDel")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = (i + 1)
                    dt.Rows(i)("file_byte") = File.ReadAllBytes(Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(i)("file_name"))
                    dt.Rows(i)("IsDel") = IIf(dt.Rows(i)("create_by").ToString = Config.GetLogOnUser.UserName, "Y", "N")
                    If Convert.IsDBNull(dt.Rows(i)("description")) = True Then
                        dt.Rows(i)("description") = "-"
                    End If
                Next
            End If
            en = Nothing
        End If

        If e.CommandName = "Edit" Then
            'CancelEdit(dt.Rows(index)("id"))
            Dim FilePara As New Para.Common.TmpFileUploadPara
            FilePara.TmpFileByte = dt.Rows(index)("file_byte")
            FilePara.FileExtent = dt.Rows(index)("mime_type")
            ctlBrowseFile1.TmpFileUploadPara = FilePara
            txtDescription.Text = dt.Rows(index)("description")
            lblDocumentRegisterID.Text = dt.Rows(index)("document_register_id")
            lblID.Text = dt.Rows(index)("id")
            lblRowIndex.Text = index
            lblRowNo.Text = dt.Rows(index)("no")
        ElseIf e.CommandName = "Delete" Then
            Dim ret As Boolean = True
            Dim _err As String = ""
            Dim FileName As String = ""

            If Convert.ToInt64(dt.Rows(index)("id")) > 0 Then
                Dim eng As New Engine.Document.DocumentRegisterENG
                ret = eng.DeleteAttachFile(Convert.ToInt64(dt.Rows(index)("id")))
                _err = eng.ErrorMessage
                eng = Nothing
                FileName = Engine.Common.FunctionENG.GetFileUploadPath & dt.Rows(index)("file_name")
            Else
                FileName = Engine.Common.FunctionENG.GetFileUploadPath() & "\TmpFile\" & Session.SessionID & dt.Rows(index)("mime_type")
            End If

            If ret = True Then
                If File.Exists(FileName) Then
                    File.Delete(FileName)
                End If
                dt.Rows.RemoveAt(index)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("no") = (i + 1)
                    Next
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    Session(Constant.SessFileUploadList) = dt
                Else
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()
                    Session.Remove(Constant.SessFileUploadList)
                End If
            Else
                Config.SetAlert(_err, Me)
            End If
        Else
            Dim FileName As String = ""
            If dt.Rows(index)("id").ToString = "0" Then
                Dim TmpDir As String = Engine.Common.FunctionENG.GetFileUploadPath() & "\TmpFile"
                If Directory.Exists(TmpDir) = False Then
                    Directory.CreateDirectory(TmpDir)
                End If

                FileName = Session.SessionID & dt.Rows(index)("mime_type")
                Dim TmpFile As String = TmpDir & "\" & FileName

                Dim fleList As String() = Directory.GetFiles(TmpDir)
                If fleList.Length > 0 Then
                    For Each fla As String In fleList
                        Dim f As New FileInfo(fla)
                        If f.Name.Replace(f.Extension, "") = Session.SessionID Then
                            File.Delete(f.FullName)
                        End If
                    Next
                End If

                Dim FileByte() As Byte = CType(dt.Rows(index)("file_byte"), Byte())
                Dim fs As FileStream
                Try
                    fs = New FileStream(TmpFile, FileMode.CreateNew)
                    fs.Write(FileByte, 0, FileByte.Length)
                    fs.Close()
                Catch ex As Exception
                    Config.SetAlert(ex.Message, Me)
                End Try
            Else
                FileName = dt.Rows(index)("file_name")
            End If

            Dim OpenDwnScr As String = "<script language='javascript'>OpenDownload('id=" & dt.Rows(index)("id").ToString & "&FileName=" & FileName & "&RowID=" & index & "&rnd=" & DateTime.Now.Millisecond & "');</script>"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OpenDwn", OpenDwnScr, False)
        End If
    End Sub

    Private Sub CancelEdit(ByVal vID As Long)
        If vID <> 0 Then
            Dim p As New Para.TABLE.DocumentAttachFilePara
            Dim eng As New Engine.Document.DocumentRegisterENG
            p = eng.GetAttachFilePara(vID)

            Dim FilePara As New Para.Common.TmpFileUploadPara
            FilePara.TmpFileByte = File.ReadAllBytes(Engine.Common.FunctionENG.GetFileUploadPath & p.FILE_NAME)
            FilePara.FileExtent = p.MIME_TYPE
            ctlBrowseFile1.TmpFileUploadPara = FilePara
            txtDescription.Text = p.DESCRIPTION
            lblDocumentRegisterID.Text = p.DOCUMENT_REGISTER_ID
            lblID.Text = vID.ToString
        Else
            ClearForm()
        End If
        
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim img As ImageButton = e.Row.FindControl("imgDownload")
            Dim imgDel As ImageButton = e.Row.FindControl("imgDelete")
            Dim id As Long = e.Row.Cells(4).Text
            Dim RowID As Int16 = e.Row.RowIndex
            Dim grv As GridViewRow = e.Row

            Dim dt As DataTable
            Dim FileName As String = ""
            If id = "0" Then
                dt = Session(Constant.SessFileUploadList)
                FileName = Session.SessionID & dt.Rows(e.Row.RowIndex)("mime_type")
            Else
                Dim eng As New Engine.Document.DocumentRegisterENG
                dt = eng.GetAttachFileList(lblDocumentRegisterID.Text)
                FileName = dt.Rows(e.Row.RowIndex)("file_name")
                eng = Nothing
            End If
            'img.Attributes.Add("OnClick", "OpenDownload('id=" & id & "&FileName=" & FileName & "&RowID=" & RowID & "&rnd=" & DateTime.Now.Millisecond & "')")

            If dt.Rows.Count > 0 Then
                imgDel.Visible = (grv.Cells(5).Text = "Y")
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CancelEdit(lblID.Text)
    End Sub
End Class
