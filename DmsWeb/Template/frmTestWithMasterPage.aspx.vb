
Partial Class Template_frmTestWithMasterPage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            img1.Attributes.Add("onClick", "SetStyle('" & img1.ClientID & "'); return false;")
        End If
    End Sub

    Protected Sub OnPostBack()
        Dim aaa As String = ""
    End Sub

    Protected Sub hdnCustValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hdnCustValue.TextChanged
        Dim bbb As String = ""
    End Sub
End Class
