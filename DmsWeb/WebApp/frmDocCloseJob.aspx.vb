Imports System.Data

Partial Class WebApp_frmDocCloseJob
    Inherits System.Web.UI.Page
    'Const SessSearchResult As String = "SearchResult"

    Protected Sub btnCloseJob1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseJob1.Click
        Dim SelectedDoc As DataTable = GetSelectedDocNo()
        If SelectedDoc.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("book_no")
            dt.Columns.Add("book_title")

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim tmpBookNo As String = ""
            For Each TmpDr As DataRow In SelectedDoc.Rows
                Dim dPara As New Para.TABLE.DocumentRegisterPara
                Dim eng As New Engine.Document.DocumentRegisterENG
                dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)

                Dim dr As DataRow = dt.NewRow
                dr("id") = dPara.ID
                dr("book_no") = dPara.BOOK_NO
                dr("book_title") = dPara.TITLE_NAME
                dt.Rows.Add(dr)

                If tmpBookNo = "" Then
                    tmpBookNo = dPara.BOOK_NO
                Else
                    tmpBookNo += ", " & dPara.BOOK_NO
                End If
                dPara = Nothing
                eng = Nothing
            Next
            trans.CommitTransaction()
            Config.SaveTransLog("frmDocCloseJob.aspx คลิกปุ่มจบงาน เลขที่หนังสือ " & tmpBookNo)
            btnCloseJob1.SetConfirmList(dt)
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการจบงาน", Me)
        End If
        SelectedDoc.Dispose()
    End Sub

    Private Function GetSelectedDocNo() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = grv.Cells(0).FindControl("cb2")
            If cb.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(8).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(9).Text
                dt.Rows.Add(dr)
            End If
        Next

        Return dt
    End Function

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Me.IsPostBack = False Then
    '        '    SetGridview(True)
    '        Session.Remove(SessSearchResult)
    '    End If
    'End Sub

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Function SearchData(ByVal uPara As Para.Common.UserProfilePara) As DataTable
        Dim dt As New DataTable
        'Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        Dim whText As String = "1=1"
        If txtBookNo.Text.Trim <> "" Then
            whText += " and dr.book_no like '%" & txtBookNo.Text.Trim & "%'"
        End If
        If txtRegDateFrom.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) >= '" & txtRegDateFrom.GetDateCondition & "'"
        End If
        If txtRegDateTo.DateValue.Year <> 1 Then
            whText += " and convert(varchar(8),dr.register_date,112) <= '" & txtRegDateTo.GetDateCondition & "'"
        End If
        If txtReqNo.Text.Trim <> "" Then
            whText += " and dr.request_no like '%" & txtReqNo.Text.Trim & "%'"
        End If
        If txtTitleName.Text.Trim <> "" Then
            whText += " and dr.title_name like '%" & txtTitleName.Text.Trim & "%' "
        End If
        If txtCompanyDocNo.Text.Trim <> "" Then
            whText += " and dr.company_doc_no like '%" & txtCompanyDocNo.Text.Trim & "%'"
        End If
        If txtCompanyName.Text.Trim <> "" Then
            whText += " and dr.company_name like '%" & txtCompanyName.Text.Trim & "%' "
        End If
        If chkOutDirector.Checked = True Then
            'กรณีออกจากห้องผู้บริหาร
            Dim oEng As New Engine.Master.OfficerEng
            Dim oPara As New Para.TABLE.OfficerPara
            oPara = oEng.GetOfficerPara(uPara.ORG_DATA.DIRECTOR)
            whText += " and ir.sender_officer_username = '" & oPara.USERNAME & "'"
            oEng = Nothing
            oPara = Nothing
        End If
        If chkInDirector.Checked = True Then
            'กรณีเสนอผู้บริหาร
            Dim oEng As New Engine.Master.OfficerEng
            Dim oPara As New Para.TABLE.OfficerPara
            oPara = oEng.GetOfficerPara(uPara.ORG_DATA.DIRECTOR)
            whText += " and ir.receiver_officer_username = '" & oPara.USERNAME & "'"
            oEng = Nothing
            oPara = Nothing
        End If
        Dim eng As New Engine.Document.SearchDocumentENG
        dt = eng.SearchDocumentSend(whText, uPara)
        eng = Nothing
        'uPara = Nothing

        Return dt
    End Function

    Private Sub SetGridview(ByVal uPara As Para.Common.UserProfilePara)
        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
            btnCloseJob1.Visible = True

            If dt.Rows.Count = 1 Then
                'กรณีค้นหาแล้วเจอ 1 รายการ ให้ติ๊กถูกให้เลย
                For Each grv As GridViewRow In GridView1.Rows
                    Dim cb As CheckBox = grv.Cells(0).FindControl("cb2")
                    cb.Checked = True
                Next
            End If
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            pcTop.Visible = False
            btnCloseJob1.Visible = False
        End If
        dt.Dispose()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If
        SetGridview(uPara)
        uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_OKClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.OKClick
        SetGridview(uPara)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim lblAttach As Label = CType(grv.FindControl("lblAttach"), Label)

            Dim DocQty As Integer = grv.Cells(10).Text
            If DocQty > 0 Then
                lblAttach.Text = grv.Cells(10).Text
                lblAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(8).Text & ",'" & btnSearch.ClientID & "')")
                lblAttach.Attributes.Add("style", "cursor:pointer;")
                lblAttach.ToolTip = "เอกสารแนบ (" & grv.Cells(10).Text & ")"
            Else
                lblAttach.Text = "<img src='../Images/NewDoc.jpg' width='16px' style='cursor:pointer;' onClick=""OpenAttachFileWindow(" & grv.Cells(8).Text & ",'" & btnSearch.ClientID & "');"" alt='เพิ่มเอกสารแนบ' title='เพิ่มเอกสารแนบ' />"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(8).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtBookNo.Text = ""
        txtRegDateFrom.DateValue = New Date(1, 1, 1)
        txtRegDateTo.DateValue = New Date(1, 1, 1)
        txtReqNo.Text = ""
        txtTitleName.Text = ""
        txtCompanyDocNo.Text = ""
        txtCompanyName.Text = ""
        'SetFolder()
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = SearchData(uPara)
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
        uPara = Nothing
    End Sub

    Protected Sub btnCloseJob1_YesClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal dt As System.Data.DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB, ByVal uPara As Para.Common.UserProfilePara) Handles btnCloseJob1.YesClick
        btnCloseJob1.CloseJobSuccess = "Y"
    End Sub
End Class
