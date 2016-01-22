Imports System.IO
Imports System.Data
Imports Para.Common.Utilities
Partial Class WebApp_PopAttachFileDownload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("id") IsNot Nothing And Request("RowID") IsNot Nothing Then
            If Request("id").ToString = "0" Then
                Dim FileName As String = Request("FileName")
                Response.Redirect(Engine.Common.FunctionENG.GetFileUploadURL(Request) & "TmpFile/" & FileName & "?rnd=" & DateTime.Now.Millisecond)
            Else
                Response.Redirect(Engine.Common.FunctionENG.GetFileUploadURL(Request) & Request("FileName").ToString & "?rnd=" & DateTime.Now.Millisecond)
            End If
        End If
    End Sub
End Class
