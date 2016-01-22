﻿Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class WebApp_frmMasterSecret
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetGridview(True)
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "') ")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateData() = True Then

            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim para As New DocSecretPara
            para.ID = Convert.ToInt64(txtID.Text)
            para.SECRET_CODE = txtCode.Text
            para.SECRET_NAME = txtName.Text
            If chkActive.Checked = True Then
                para.ACTIVE = "Y"
            Else
                para.ACTIVE = "N"
            End If

            Dim fnc As New DocSecretEng
            If fnc.SaveDocSecret(para, "Admin", trans) = True Then
                trans.CommitTransaction()
                GetSecretData(fnc.ID)
                SetGridview(True)
                ClearData()
                Config.SetAlert("บันทึกข้อมูลเรียบร้อย", Me)
            Else
                trans.RollbackTransaction()
                Config.SetAlert(fnc.ErrorMessage, Me)
            End If
        End If
    End Sub
    Public Function ValidateData() As Boolean
        Dim ret = True
        If txtCode.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกรหัส", Me, txtCode.ClientID)
        ElseIf txtName.Text.Trim = "" Then
            ret = False
            Config.SetAlert("กรุณากรอกชื่อ", Me, txtName.ClientID)
        End If
        Return ret
    End Function
    Private Sub GetSecretData(ByVal ID As Long)
        Dim fnc As New DocSecretEng
        Dim para As DocSecretPara
        para = fnc.GetDocSecretPara(ID)

        txtID.Text = para.ID
        txtCode.Text = para.SECRET_CODE
        txtName.Text = para.SECRET_NAME
        If para.ACTIVE = "Y" Then
            chkActive.Checked = True
        Else
            chkActive.Checked = False
        End If
    End Sub
    Private Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As DataTable
        If IsClickSearch = True Then
            Dim fnc As New DocSecretEng
            dt = fnc.GetDataSecretList("secret_name like '%" + txtSearch.Text.Trim() + "%' or secret_code like '%" + txtSearch.Text + "%'", "secret_code")
            Session("SearchResult") = dt
        Else
            dt = Session("SearchResult")
        End If

        GridView1.PageSize = 20
        pcTop.SetMainGridView(GridView1)
        GridView1.DataSource = dt
        GridView1.DataBind()
        pcTop.Update(dt.Rows.Count)
    End Sub

    Protected Sub pcTop_PageChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcTop.PageChange
        GridView1.PageIndex = pcTop.SelectPageIndex
        SetGridview(False)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim id As Long = GridView1.Rows(e.RowIndex).Cells(0).Text

        Dim eng As New Engine.Master.DocSecretEng
        Dim ret As String = eng.DeleteDocSeret(id)
        If ret <> "" Then
            Config.SetAlert(ret, Me)
        End If
        SetGridview(True)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim K As DataKey = GridView1.DataKeys(e.NewEditIndex)
        GetSecretData(K(0).ToString)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub
    Private Sub ClearData()
        txtID.Text = "0"
        txtCode.Text = ""
        txtName.Text = ""
        chkActive.Checked = False
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SetGridview(True)
    End Sub
End Class