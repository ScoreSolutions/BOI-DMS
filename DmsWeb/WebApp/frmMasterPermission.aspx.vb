Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmMasterPermission
    Inherits System.Web.UI.Page
    Protected Sub cbAll_OnCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkH As CheckBox = sender
        Dim grv As GridViewRow = chkH.Parent.Parent
        Dim gv As GridView = grv.Parent.Parent
        For i As Integer = 0 To gv.Rows.Count - 1
            Dim chk As CheckBox = gv.Rows(i).Cells(0).FindControl("cb")
            chk.Checked = chkH.Checked
        Next
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            GetRoleData()
            SetGridviewNoSelect()
            SetGridviewSeleted()
        End If
    End Sub
    Private Sub GetRoleData()
        Dim ID As String = Request.QueryString("group")
        Dim fnc As New RolesEng
        Dim para As RolesPara
        para = fnc.GetRolesPara(ID)
        txtID.Text = ID
        lblText.Text = para.ROLE_NAME

        para = Nothing
        fnc = Nothing

    End Sub
    Private Sub SetGridviewNoSelect()
        Dim dt As DataTable
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim fnc As New ModuleEng
        dt = fnc.GetDataModuleList(" and me.id not in (select menu_id from roles_menu where roles_id = '" & txtID.Text & "')", trans)
        trans.CommitTransaction()

        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            dt.Dispose()
            dt = Nothing
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
        
    End Sub
    Private Sub SetGridviewSeleted()
        Dim dt As DataTable

        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()
        Dim fnc As New ModuleEng
        dt = fnc.GetDataModuleList(" and me.id  in (select menu_id from roles_menu where roles_id = '" & txtID.Text & "')", trans)
        trans.CommitTransaction()

        If dt.Rows.Count > 0 Then
            GridView2.DataSource = dt
            GridView2.DataBind()
            dt.Dispose()
            dt = Nothing
        Else
            GridView2.DataSource = Nothing
            GridView2.DataBind()
        End If
    End Sub

    Private Sub SaveData(ByVal menuid As String)
        'Dim ID As String = Request.QueryString("group")
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        Dim para As New RolesMenuPara
        para.ID = 0
        para.ROLES_ID = txtID.Text
        para.MENU_ID = menuid

        Dim fnc As New RolesMenuEng
        If fnc.SaveRolesMenu(para, Config.GetLogOnUser.UserName, trans) = True Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
            Config.SetAlert(fnc.ErrorMessage, Me)
        End If
        para = Nothing
        fnc = Nothing

    End Sub
    Private Sub DeleteData(ByVal menuid As String)
        Dim ID As String = txtID.Text
        Dim trans As New Linq.Common.Utilities.TransactionDB
        Dim sql As String
        trans.CreateTransaction()
        sql = "delete from roles_menu where roles_id=" & ID & " and menu_id=" & menuid & " "
        Dim fnc As New RolesMenuEng
        fnc.DeleteRolesMenuParaBySql(sql, trans)
        trans.CommitTransaction()
        fnc = Nothing
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim grv As GridViewRow = GridView1.Rows(i)
            Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
            If chk.Checked = True Then
                SaveData(grv.Cells(3).Text)
            End If
        Next
        SetGridviewSeleted()
        SetGridviewNoSelect()
    End Sub

    Protected Sub btnNoSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoSelect.Click
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim grv As GridViewRow = GridView2.Rows(i)
            Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
            If chk.Checked = True Then
                DeleteData(grv.Cells(3).Text)
            End If
        Next
        SetGridviewSeleted()
        SetGridviewNoSelect()
    End Sub
End Class

