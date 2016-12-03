Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmDocOutsideSend
    Inherits System.Web.UI.Page

    'Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim s As String = sender.commandargument
    '    Response.Redirect("../WebApp/frmDocBookDetailShow.aspx?id=" + s + "&rnd=" & DateTime.Now.Millisecond)
    'End Sub

    Private Function SearchData() As DataTable
        Dim dt As New DataTable
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser

        Dim whText As String = " 1=1 "
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
        Return dt
    End Function

    Private Sub SetGridView(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            pcTop.Visible = True
            GridView1.PageSize = 20
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
            btnSendOutside1.Visible = True

            If dt.Rows.Count = 1 Then
                'กรณีค้นหาแล้วเจอ 1 รายการ ให้ติ๊กถูกให้เลย
                For Each grv As GridViewRow In GridView1.Rows
                    Dim cb As CheckBox = grv.Cells(1).FindControl("cb1")
                    cb.Checked = True
                Next
            End If
        Else
            pcTop.Visible = False
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            btnSendOutside1.Visible = False
        End If
        dt.Dispose()
    End Sub

    Private Sub ClearCheckBox()
        chkOutDirector.Checked = False
    End Sub

    Protected Sub txtBookno_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookNo.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub txtReqNo_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReqNo.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub txtCompanyDocNo_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompanyDocNo.TextChange
        ClearCheckBox()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridView(True)
    End Sub

    Protected Sub btnSendOutside1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.Click
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser()
        If uPara.LOGIN_HISTORY_ID = 0 Then
            Response.Redirect("../WebApp/frmSessionExpire.aspx")
            Exit Sub
        End If

        Dim SelectedDoc As DataTable = GetSelectedDocNo()
        If SelectedDoc.Rows.Count > 0 Then
            If SelectedDoc.Rows.Count = 1 Then
                Dim dt As New DataTable
                dt.Columns.Add("id")
                dt.Columns.Add("bookno")
                dt.Columns.Add("book_title")
                dt.Columns.Add("dates_app", GetType(Date))
                dt.Columns.Add("company_name")
                dt.Columns.Add("company_id")
                dt.Columns.Add("company_regis_no")
                dt.Columns.Add("company_doc_sys_id")

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                For Each TmpDr As DataRow In SelectedDoc.Rows
                    Dim dPara As New Para.TABLE.DocumentRegisterPara
                    Dim eng As New Engine.Document.DocumentRegisterENG
                    dPara = eng.GetDocumentPara(Convert.ToInt64(TmpDr("DOCUMENT_REGISTER_ID")), trans)
                    Dim dr As DataRow = dt.NewRow
                    dr("id") = dPara.ID
                    dr("bookno") = dPara.BOOK_NO
                    dr("book_title") = dPara.TITLE_NAME
                    dr("dates_app") = DateTime.Now
                    dr("company_name") = dPara.COMPANY_NAME
                    dr("company_id") = dPara.COMPANY_ID
                    dr("company_regis_no") = dPara.COMPANY_REGIS_NO
                    dr("company_doc_sys_id") = dPara.COMPANY_DOC_SYS_ID
                    dt.Rows.Add(dr)

                    Config.SaveTransLog("frmOutsideSend.aspx คลิกปุ่มส่งออกนอกสำนักงาน เลขที่หนังสือ " & dPara.BOOK_NO)
                    dPara = Nothing
                    eng = Nothing
                Next
                trans.CommitTransaction()
                btnSendOutside1.ShowPop(dt, uPara)
            Else
                Config.SetAlert("ส่งออกนอกสำนักงานได้ครั้งละ 1 เรื่อง", Me)
            End If
        Else
            Config.SetAlert("กรุณาเลือกเลขที่หนังสือที่ต้องการส่งออกภายนอกสำนักงาน", Me)
        End If
        SelectedDoc.Dispose()
        uPara = Nothing
    End Sub

    Private Function GetSelectedDocNo() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("DOCUMENT_REGISTER_ID")
        dt.Columns.Add("DOCUMENT_INT_RECEIVER_ID")

        Dim retNO As String = ""
        For Each grv As GridViewRow In GridView1.Rows
            Dim cb As CheckBox = grv.Cells(1).FindControl("cb1")
            If cb.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("DOCUMENT_REGISTER_ID") = grv.Cells(0).Text
                dr("DOCUMENT_INT_RECEIVER_ID") = grv.Cells(10).Text
                dt.Rows.Add(dr)
            End If
        Next

        Return dt
    End Function

    Protected Sub btnSendOutside1_OkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendOutside1.OkClick
        SetGridView(True)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim grv As GridViewRow = e.Row
            Dim lblAttach As Label = CType(grv.FindControl("lblAttach"), Label)

            Dim DocQty As Integer = grv.Cells(11).Text
            If DocQty > 0 Then
                lblAttach.Text = grv.Cells(11).Text
                lblAttach.Attributes.Add("OnClick", "OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "')")
                lblAttach.Attributes.Add("style", "cursor:pointer;")
                lblAttach.ToolTip = "เอกสารแนบ (" & grv.Cells(11).Text & ")"
            Else
                lblAttach.Text = "<img src='../Images/NewDoc.jpg' width='16px' style='cursor:pointer;' onClick=""OpenAttachFileWindow(" & grv.Cells(0).Text & ",'" & btnSearch.ClientID & "');"" alt='เพิ่มเอกสารแนบ' title='เพิ่มเอกสารแนบ' />"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(grv.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + grv.Cells(0).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
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
        chkOutDirector.Checked = True
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim dt As New DataTable
        dt = SearchData()
        If dt.Rows.Count > 0 Then
            GridView1.PageIndex = pcTop.SelectPageIndex
            Config.GridViewSorting(GridView1, dt, txtSortDir, txtSortField, e, pcTop.SelectPageIndex)
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
        dt.Dispose()
    End Sub
End Class
