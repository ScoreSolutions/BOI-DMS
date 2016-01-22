Imports System.Data
Imports System.Data.OleDb
Imports System.Web
Partial Class UserControls_Button_btnAttachFile
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click

        RaiseEvent Click(sender, e)
        zPop.Show()
        MultiView1.ActiveViewIndex = 0
        ShowGrid()
    End Sub

    Public Sub ShowPop()
        MultiView1.ActiveViewIndex = 0
        ShowGrid()
        zPop.Show()
    End Sub
    Private Sub ShowGrid()

        'Dim ds As New DataSet()
        'Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Server.MapPath("~/Report/Book1.xlsx") + "; Extended Properties=Excel 12.0;"
        'Dim da As New OleDbDataAdapter("SELECT * FROM [Sheet6$] ", strConn)
        'da.Fill(ds)

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("detail")

        Dim dr As DataRow = dt.NewRow
        dr("id") = 1
        dr("detail") = "เอกสารแนบ 1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("id") = 2
        dr("detail") = "เอกสารแนบ 2"
        dt.Rows.Add(dr)

        GridView1.DataSource = dt
        GridView1.DataBind()
        zPop.Show()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        zPop.Show()
        If RadioButtonList1.SelectedIndex = 0 Then
            MultiView1.ActiveViewIndex = 0
        Else
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        zPop.Show()
        Image1.ImageUrl = "../../Images/testscan.png"
        txtBox2.Text = "1 of 1"
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Not FileUpload1.PostedFile Is Nothing Then

            Dim filepath As String = FileUpload1.PostedFile.FileName
            Dim pat As String = "\\(?:.+)\\(.+)\.(.+)"
            Dim r As Regex = New Regex(pat)
            'run
            Dim m As Match = r.Match(filepath)
            Dim file_ext As String = m.Groups(2).Captures(0).ToString()
            Dim filename As String = m.Groups(1).Captures(0).ToString()
            Dim file As String = filename & "." & file_ext

            'save the file to the server 
            FileUpload1.PostedFile.SaveAs(Server.MapPath(".\") & file)
            'lblStatus.Text = "File Saved to: " & Server.MapPath(".\") & file

        End If

    End Sub


End Class
