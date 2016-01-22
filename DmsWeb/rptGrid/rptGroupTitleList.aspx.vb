Imports System.Data
Partial Class rptGrid_rptGroupTitleList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim eng As New Engine.Master.GroupTitleEng
            Dim dt As New DataTable
            dt = eng.GetDataGroupTitleList("active='Y' and ltrim(group_title_name)<>''", "convert(float,group_title_code)")
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("no")
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("no") = (i + 1).ToString
                Next
                GridView1.DataSource = dt
                GridView1.DataBind()
                dt = Nothing
            End If
            eng = Nothing
        End If
    End Sub
End Class
