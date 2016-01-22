
Partial Class Template_TestPage
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = Engine.Common.FunctionENG.GetThaiNumber(TextBox1.Text)
    End Sub
End Class
