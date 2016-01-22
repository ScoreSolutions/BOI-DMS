Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data

Partial Class UserControls_ctlCompany_ascx
    Inherits System.Web.UI.UserControl

    Public Event SelectedIndexChange(ByVal EngName As String)

    Public Property Value() As String
        Get
            Return lblID.Text
        End Get
        Set(ByVal value As String)
            lblID.Text = value
        End Set
    End Property
    Public ReadOnly Property CompanyPara() As CompanyPara
        Get
            If lblID.Text.Trim = "" Then
                Return New CompanyPara
            Else
                Return GetCompanyData(lblID.Text)
            End If

        End Get
    End Property
    
    Public Overrides ReadOnly Property ClientID() As String
        Get
            Return txtBox1.ClientID
        End Get
    End Property
    Public WriteOnly Property Width() As Unit
        Set(ByVal value As Unit)
            txtBox2.Width = value
        End Set
    End Property
    Public WriteOnly Property IsNotNull() As Boolean
        Set(ByVal value As Boolean)
            Label1.Visible = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            'SetGridview(True)
            txtCode.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            txtName.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
            txtEngName.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    
    Private Function GetCompanyData(ByVal ID As Long) As CompanyPara
        Dim fnc As New CompanyEng
        Dim para As CompanyPara
        para = fnc.GetCompanyPara(ID)

        txtID.Text = para.ID
        txtCode.Text = para.COMID
        txtName.Text = para.THAINAME
        txtEngName.Text = para.ENGNAME
        Return para
    End Function
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        zPop.Show()

        lblID.Text = ""
        txtBox2.Text = ""
        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New CompanyEng
            Dim sqlWh As String = " 1=1 "
            If txtBox1.Text.Trim <> "" Then
                sqlWh += " and comid like '%" & txtBox1.Text.Trim & "%'"
            End If
            If txtCode.Text.Trim <> "" Then
                sqlWh += " and comid like '%" & txtCode.Text.Trim & "%'"
            End If
            If txtName.Text.Trim <> "" Then
                sqlWh += " and thainame like '%" & txtName.Text.Trim & "%'"
            End If
            If txtEngName.Text.Trim <> "" Then
                sqlWh += " and engname like '%" & txtEngName.Text.Trim & "%'"
            End If
            dt = fnc.GetDataCompanyList(sqlWh, "comid")
            Session("PopCompanySearchResult") = dt
        Else
            Dim sortStr As String = ""
            If txtSortField.Text.Trim <> "" Then
                sortStr = " " & txtSortField.Text & " " & txtSortDir.Text
            End If
            dt = Session("PopCompanySearchResult")
            dt.DefaultView.Sort = sortStr
            dt = dt.DefaultView.ToTable()
        End If

        GridView1.PageSize = 10
        pcTop.SetMainGridView(GridView1)
        GridView1.DataSource = dt
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        zPop.Show()
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
    End Sub

    Private Sub ClearData()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        txtEngName.Text = ""

    End Sub

    Public Sub ClearValue()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        txtEngName.Text = ""
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim fnc As New CompanyEng
        Dim para As CompanyPara
        Dim K As DataKey = GridView1.DataKeys(e.NewSelectedIndex)
        para = fnc.GetCompanyPara(K(0))

        lblID.Text = para.ID
        txtBox1.Text = para.COMID
        txtBox2.Text = para.THAINAME
        RaiseEvent SelectedIndexChange(para.ENGNAME)

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
    End Sub
    Protected Sub txtBox1_TextChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBox1.TextChange
        If txtBox1.Text.Trim <> "" Then
            SetGridview(True)
        Else
            txtBox1.Text = ""
            txtBox2.Text = ""
            lblID.Text = ""
        End If
    End Sub
    
    Protected Sub ImageSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageSearch.Click
        SetGridview(True)
    End Sub
    Public ReadOnly Property CategoryParameter() As CompanyPara
        Get
            Dim para As New CompanyPara
            If lblID.Text.Trim <> "" And lblID.Text.Trim <> "0" Then
                Dim fnc As New CompanyEng
                para = fnc.GetCompanyPara(lblID.Text)
            End If
            Return para
        End Get
    End Property
    Private Sub ClearAllField()
        txtBox1.Text = ""
        txtBox2.Text = ""
        lblID.Text = ""
    End Sub
    

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Dim para As CompanyPara = CategoryParameter()
        If para.ID = 0 Then
            ClearAllField()
            txtBox1.Focus()
        End If
    End Sub

    Protected Sub likThaiName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCode.Text = ""
        txtName.Text = ""
        txtEngName.Text = ""
        SetCompany(sender.CommandArgument)
    End Sub

    Public Sub SetCompany(ByVal vID As Long)
        Dim fnc As New CompanyEng
        Dim para As CompanyPara
        para = fnc.GetCompanyPara(vID)

        lblID.Text = para.ID
        txtBox1.Text = para.COMID
        txtBox2.Text = para.THAINAME
        RaiseEvent SelectedIndexChange(para.ENGNAME)
    End Sub

    Public Sub clearval()
        txtBox1.Text = ""
        txtBox2.Text = ""
    End Sub
    Public Sub disabledata()
        txtBox1.Enabled = False
        ImageSearch.Visible = False
    End Sub
    Public Sub enabledata()
        txtBox1.Enabled = True
        ImageSearch.Visible = True
    End Sub
End Class
