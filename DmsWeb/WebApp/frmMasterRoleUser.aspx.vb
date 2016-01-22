Imports System.Data
Imports Engine.Master

Partial Class WebApp_frmMasterRoleUser
    Inherits System.Web.UI.Page
    Const SessSelectedOfficer As String = "SessSelectedOfficer"
    Protected Sub cbAll_OnCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkH As CheckBox = sender
        Dim grv As GridViewRow = chkH.Parent.Parent
        Dim gv As GridView = grv.Parent.Parent
        For i As Integer = 0 To gv.Rows.Count - 1
            Dim chk As CheckBox = gv.Rows(i).Cells(0).FindControl("cb")
            chk.Checked = chkH.Checked
        Next
    End Sub

    Private Function GetSelectedDT() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("staff_name")
        dt.Columns.Add("org_name")
        Return dt
    End Function

    Private Sub SetNoSelectGv()
        If cmbOrgID.SelectedValue = "" Or cmbOrgID.SelectedValue = "0" Then
            Exit Sub
        End If

        Dim dt As DataTable
        If Session(SessSelectedOfficer) Is Nothing Then
            dt = GetSelectedDT()
        Else
            dt = Session(SessSelectedOfficer)
        End If

        Dim oEng As New RolesEng
        Dim stDT As New DataTable
        stDT = oEng.GetOfficerNoSelectRoleList(txtID.Text, cmbOrgID.SelectedValue)
        If stDT.Rows.Count > 0 Then
            gvNoSeleteList.DataSource = stDT
            gvNoSeleteList.DataBind()
        Else
            gvNoSeleteList.DataSource = Nothing
            gvNoSeleteList.DataBind()
        End If
    End Sub


    Private Sub SetSelectGV()
        Dim dt As New DataTable
        
        Dim oEng As New RolesEng
        Dim stDT As New DataTable
        stDT = oEng.GetOfficerSelectedRoleList(txtID.Text)
        If stDT.Rows.Count > 0 Then
            gvSelected.DataSource = stDT
            gvSelected.DataBind()
        Else
            gvSelected.DataSource = Nothing
            gvSelected.DataBind()
        End If
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim ret As Boolean = False
        For i As Integer = gvNoSeleteList.Rows.Count - 1 To 0 Step -1
            Dim grv As GridViewRow = gvNoSeleteList.Rows(i)
            Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
            If chk.Checked = True Then
                Dim eng As New Engine.Master.RolesEng
                ret = eng.InsertRolesUser(Config.GetLogOnUser.UserName, grv.Cells(2).Text, txtID.Text)
                If ret = False Then
                    Exit For
                End If
            End If
        Next
        SetSelectGV()
        SetNoSelectGv()
    End Sub

    Protected Sub btnNoSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoSelect.Click
        For i As Integer = gvSelected.Rows.Count - 1 To 0 Step -1
            Dim grv As GridViewRow = gvSelected.Rows(i)
            Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
            If chk.Checked = True Then
                Dim eng As New Engine.Master.RolesEng
                eng.DeleteRoleUser(txtID.Text, grv.Cells(2).Text)
            End If
        Next
        SetSelectGV()
        SetNoSelectGv()
    End Sub

    Protected Sub cmbOrgID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrgID.SelectedIndexChanged
        If cmbOrgID.SelectedValue <> "0" Then
            SetNoSelectGv()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request("id") IsNot Nothing Then
                Dim eng As New Engine.Master.RolesEng
                Dim para As New Para.TABLE.RolesPara
                para = eng.GetRolesPara(Request("id"))
                txtID.Text = para.ID
                lblRoleName.Text = para.ROLE_NAME
                para = Nothing
                eng = Nothing

                SetSelectGV()
            End If
        End If
    End Sub
End Class
