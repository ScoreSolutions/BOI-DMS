Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptdocumentdetail
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not Request.QueryString("book_no").ToString() Is Nothing Then
                lbl_book_no.Text = Request.QueryString("book_no").ToString()
            Else
                lbl_book_no.Text = ""
            End If
            bindata_docregister()
            bindgrid_bindata_docregister()
        End If
    End Sub
    Private Sub bindata_docregister()
        Try
            Dim dt As New DataTable
            reports.book_no = lbl_book_no.Text.ToString.Trim
            dt = reports.rptsumdocregist
            If dt.Rows.Count > 0 Then
                lbl_register_date.Text = If(dt.Rows(0).Item("register_date").ToString() = "", "", Convert.ToDateTime(dt.Rows(0).Item("register_date")).ToString("dd MMM yy"))
                lbl_close_date.Text = If(dt.Rows(0).Item("close_date").ToString() = "", "", Convert.ToDateTime(dt.Rows(0).Item("close_date")).ToString("dd MMM yy"))
                lbl_request_no.Text = dt.Rows(0).Item("request_no").ToString
                lbl_company_doc_date.Text = If(dt.Rows(0).Item("company_doc_date").ToString() = "", "", Convert.ToDateTime(dt.Rows(0).Item("company_doc_date")).ToString("dd MMM yy"))
                lbl_group_title_name.Text = dt.Rows(0).Item("group_title_name").ToString()
                lbl_title_name.Text = dt.Rows(0).Item("title_name").ToString()
                lbl_company_sign.Text = dt.Rows(0).Item("company_sign").ToString()
                lbl_organization_appname.Text = dt.Rows(0).Item("organization_appname").ToString()
                lbl_expect_finish_date.Text = If(dt.Rows(0).Item("expect_finish_date").ToString() = "", "", Convert.ToDateTime(dt.Rows(0).Item("expect_finish_date")).ToString("dd MMM yy"))
                lbl_doc_status_name.Text = dt.Rows(0).Item("doc_status_name").ToString()
                lbl_company_doc_no.Text = dt.Rows(0).Item("company_doc_no").ToString()
                lbl_company.Text = dt.Rows(0).Item("company_name").ToString()
                lbl_business_type.Text = dt.Rows(0).Item("business_type_name").ToString()
                lbl_organization_name.Text = dt.Rows(0).Item("organization_name").ToString()
                lbl_remarks.Text = dt.Rows(0).Item("remarks").ToString()
                lbl_officer_name.Text = dt.Rows(0).Item("officer_app_name").ToString()
            Else
                lbl_register_date.Text = ""
                lbl_close_date.Text = ""
                lbl_request_no.Text = ""
                lbl_company_doc_date.Text = ""
                lbl_group_title_name.Text = ""
                lbl_title_name.Text = ""
                lbl_company_sign.Text = ""
                lbl_organization_appname.Text = ""
                lbl_expect_finish_date.Text = ""
                lbl_doc_status_name.Text = ""
                lbl_company_doc_no.Text = ""
                lbl_company.Text = ""
                lbl_business_type.Text = ""
                lbl_organization_name.Text = ""
                lbl_remarks.Text = ""
                lbl_officer_name.Text = ""
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
    Private Sub bindgrid_bindata_docregister()
        Try

            Dim dt As New DataTable
            reports.book_no = lbl_book_no.Text.ToString.Trim
            dt = reports.rptsumdocregistdtl
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString = "" Then
                    dgvdetail.ShowFooter = True
                    lbl_result.Text = "จำนวนเอกสารทั้งหมด :0 เรื่อง"

                Else
                    dgvdetail.ShowFooter = False
                    dgvdetail.PageSize = dt.Rows.Count
                    lbl_result.Text = "จำนวนเอกสารทั้งหมด : " & dt.Rows.Count & " เรื่อง"
                End If
            End If

            dgvdetail.PagerStyle.Visible = False
            dgvdetail.DataSource = dt
            dgvdetail.DataBind()
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
    Private Sub getdatadgv()
        Try
            'If dt.Rows.Count > 1 Then
            '    dgvdetail.PageSize = dt.Rows.Count
            '    dgvdetail.ShowFooter = False
            '    dgvdetail.PagerStyle.Visible = True
            'Else
            '    dgvdetail.ShowFooter = True
            '    dgvdetail.PagerStyle.Visible = False
            'End If



        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('" & ex.Message & "');", True)
            Exit Sub
        End Try
    End Sub
End Class
