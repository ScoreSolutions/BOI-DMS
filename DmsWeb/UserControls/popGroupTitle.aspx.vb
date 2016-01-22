Imports System.Data
Imports Engine.Master

Partial Class UserControls_popGroupTitle
    Inherits System.Web.UI.Page


    Private Sub SetGridview(ByVal IsClickSearch As Boolean)

        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New GroupTitleEng
            dt = fnc.GetDataGroupTitleList("group_title_name like '%" & txtsGroupTitleName.Text & "%' and isnull(group_title_name,'')<>'' ", "group_title_name")
            Session("GroupTitleSearchResult") = dt
        Else
            Dim sortStr As String = ""
            If txtSortField.Text.Trim <> "" Then
                sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
            End If
            dt = Session("GroupTitleSearchResult")
            dt.DefaultView.Sort = sortStr
            dt = dt.DefaultView.ToTable()
        End If

        If dt.Rows.Count = 1 Then
            'lblID.Text = dt.Rows(0)("id")
            'txtGroupTitleCode.Text = dt.Rows(0)("group_title_code")
            'txtGroupTitleName.Text = dt.Rows(0)("group_title_name")
        Else
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetGridview(True)
    End Sub
End Class
