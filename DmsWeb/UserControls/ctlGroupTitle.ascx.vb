Imports System.Data
Imports Engine.Master
Imports Para.TABLE

Partial Class UserControls_ctlGroupTitle
    Inherits System.Web.UI.UserControl

    Public gpara As GroupTitlePara
    Public req_text As String = "*"

    Public Event SelectedGroupTitle(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Overrides ReadOnly Property ClientID() As String
        Get
            Return txtGroupTitleCode.ClientID
        End Get
    End Property

    Public Function GetGroupTitlePara(ByVal vID As Long) As GroupTitlePara
        Dim fnc As New GroupTitleEng
        Dim para As GroupTitlePara
        para = fnc.GetGroupTitlePara(vID)
        Return para
    End Function

    Public WriteOnly Property Width() As Unit
        Set(ByVal value As Unit)
            txtGroupTitleName.Width = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return lblID.Text
        End Get
        Set(ByVal value As String)
            lblID.Text = value
        End Set
    End Property
    'Public ReadOnly Property getpr() As GroupTitlePara
    '    Get
    '        Return gpara
    '    End Get
    'End Property
    Public Property defval() As String
        Get
            Return txtGroupTitleCode.Text
        End Get
        Set(ByVal value As String)
            txtGroupTitleCode.Text = value
        End Set
    End Property
    Public WriteOnly Property DisplayOnly() As Boolean
        Set(ByVal value As Boolean)
            txtGroupTitleCode.Visible = Not value
            ImageSearch.Visible = Not value
        End Set
    End Property

    Public WriteOnly Property IsNotNull() As Boolean
        Set(ByVal value As Boolean)
            Label1.Visible = value
        End Set
    End Property

    Public Sub ClearValue()
        txtGroupTitleCode.Text = ""
        txtGroupTitleName.Text = ""
        lblID.Text = ""
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
        zPop.Show()
    End Sub

    Private Sub SetGridview(ByVal IsClickSearch As Boolean)

        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New GroupTitleEng
            dt = fnc.GetDataGroupTitleList("group_title_code like '" & txtGroupTitleCode.Text.Trim & "%' and group_title_name like '%" & txtsGroupTitleName.Text & "%' and isnull(group_title_name,'')<>'' ", "group_title_name")
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
            lblID.Text = dt.Rows(0)("id")
            txtGroupTitleCode.Text = dt.Rows(0)("group_title_code")
            txtGroupTitleName.Text = dt.Rows(0)("group_title_name")
            RaiseEvent SelectedGroupTitle(Nothing, Nothing)
        Else
            pcTop.SetMainGridView(GridView1)
            GridView1.DataSource = dt
            GridView1.DataBind()
            pcTop.Update(dt.Rows.Count)

            zPop.Show()
        End If
    End Sub

    Protected Sub likGroupTitleName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim fnc As New GroupTitleEng
        Dim para As GroupTitlePara
        para = fnc.GetGroupTitlePara(sender.CommandArgument)
        gpara = para
        lblID.Text = para.ID
        txtGroupTitleCode.Text = para.GROUP_TITLE_CODE
        txtGroupTitleName.Text = para.GROUP_TITLE_NAME

        txtsGroupTitleName.Text = ""

        RaiseEvent SelectedGroupTitle(sender, e)
    End Sub

    Protected Sub ImageSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSearch.Click
        SetGridview(True)
        zPop.Show()
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression = "DEFAULT" Then
            txtSortDir.Text = ""
            txtSortField.Text = ""
        Else
            If txtSortField.Text = e.SortExpression Then
                txtSortDir.Text = IIf(txtSortDir.Text.Trim = "", "DESC", "")
            Else : txtSortField.Text = e.SortExpression
            End If
        End If

        SetGridview(False)
        zPop.Show()
    End Sub

    Protected Sub txtGroupTitleCode_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupTitleCode.TextChange
        If txtGroupTitleCode.Text.Trim <> "" Then
            SetGridview(True)
        Else
            txtGroupTitleCode.Text = ""
            txtGroupTitleName.Text = ""
            lblID.Text = ""
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        txtGroupTitleCode.Text = ""
        SetGridview(True)
    End Sub

    Public Sub SetGroupTitle(ByVal vID As Long)
        Dim fnc As New GroupTitleEng
        Dim para As GroupTitlePara
        para = fnc.GetGroupTitlePara(vID)

        lblID.Text = para.ID
        txtGroupTitleCode.Text = para.GROUP_TITLE_CODE
        txtGroupTitleName.Text = para.GROUP_TITLE_NAME
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click

    End Sub

    Public Sub validate()
        Dim ret As Boolean = True
        If txtGroupTitleCode.Text = "" Then
            txtGroupTitleCode.ValidationText = req_text
            ret = False
        End If
        If txtGroupTitleName.Text = "" Then
            txtGroupTitleName.ValidationText = req_text
            ret = False
        End If
    End Sub
End Class
