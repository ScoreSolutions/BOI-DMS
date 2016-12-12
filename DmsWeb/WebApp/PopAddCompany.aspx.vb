Imports System.Data
Imports Para.Common.Utilities
Imports System.IO

Partial Class WebApp_PopAttachFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.CompanyTypeENG
            Dim dt As New DataTable
            dt = eng.GetAllCompanyTypeTable()
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.NewRow
                dr("id") = "0"
                dr("company_type_name") = "เลือก"
                dt.Rows.InsertAt(dr, 0)

                cmbCompanyType.DataTextField = "company_type_name"
                cmbCompanyType.DataValueField = "id"
                cmbCompanyType.DataSource = dt
                cmbCompanyType.DataBind()

            End If
            txtCompanyRegisNo.Attributes.Add("onBlur", "return ChkDupCompanyRegisNo();")

            Config.SaveTransLog("popAddCompany.aspx แสดงหน้าจอสำหรับเพิ่มชื่อองค์กร")

            dt.Dispose()
            eng = Nothing
        End If
    End Sub

    Private Function Valid() As Boolean
        Dim ret As Boolean = True
        

        Return ret
    End Function

    
    Protected Sub cmbCompanyType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompanyType.SelectedIndexChanged
        If cmbCompanyType.SelectedValue <> "0" Then
            Dim eng As New Engine.Master.CompanyTypeENG
            Dim dt As DataTable = eng.GetCompanyTypeID(cmbCompanyType.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtCompanyRequireRegisNo.Text = dt.Rows(0)("require_regis_no")
            End If
            dt.Dispose()
        End If
    End Sub
End Class
