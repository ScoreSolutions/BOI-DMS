Imports System.Data

Partial Class WebApp_frmDocSearchBook
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            SetGridview(True)
            SetMoveTo()
        End If
    End Sub

    Private Sub SetMoveTo()
        cmbMoveTo.SetItemList("ย้ายไปที่", "0")
        cmbMoveTo.SetItemList("Inbox", "1")
        cmbMoveTo.SetItemList("งานด่วน", "2")
        cmbMoveTo.SetItemList("BOI", "3")
    End Sub

    Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../BookIn/frmBookDetailShow.aspx")
    End Sub

    Public Sub SetGridview(ByVal IsClickSearch As Boolean)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("bookno")
        dt.Columns.Add("book_from")
        dt.Columns.Add("book_date")
        dt.Columns.Add("book_title")
        dt.Columns.Add("speed")
        dt.Columns.Add("secret")
        dt.Columns.Add("chk")
        dt.Columns.Add("date_register")
        dt.Columns.Add("doc_no")
        dt.Columns.Add("user_send")
        dt.Columns.Add("dept")
        dt.Columns.Add("status_name")
        dt.Columns.Add("req_no")
        dt.Columns.Add("folder_name")

        Dim dr As DataRow = dt.NewRow
        dr("id") = 1
        dr("bookno") = "สกท-49-000"
        dr("book_from") = "บีโอไอ-กองสารสนเทศ"
        dr("book_date") = ""
        dr("book_title") = "อนุมัติเดินทางไปราชการ"
        dr("speed") = "ปกติ"
        dr("secret") = "ปกติ"
        dr("chk") = "read"
        dr("date_register") = Today.Date
        dr("doc_no") = "54-00001"
        dr("user_send") = "กอบเกื้อ เผ่าจำรูญ"
        dr("dept") = "ผช-อ"
        dr("status_name") = "จบงาน"
        dr("req_no") = "2345"
        dr("folder_name") = "Inbox"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("id") = 2
        dr("bookno") = "สกท-49-001"
        dr("book_from") = "บีโอไอ-กองสารสนเทศ"
        dr("book_date") = ""
        dr("book_title") = "อนุมัติเดินทางไปราชการ"
        dr("speed") = "ปกติ"
        dr("secret") = "ปกติ"
        dr("chk") = "read"
        dr("date_register") = Today.Date
        dr("doc_no") = "54-00002"
        dr("user_send") = "กอบเกื้อ เผ่าจำรูญ"
        dr("dept") = "ผช-อ"
        dr("status_name") = "งานค้าง"
        dr("req_no") = "2345"
        dr("folder_name") = "Inbox"
        dt.Rows.Add(dr)

        If IsClickSearch = True Then
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

    Protected Sub btnRetrieve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
        lblTitleName.Text = "ดึงเรื่องกลับ"
        lblMsg.Text = "คุณต้องการดึงเรื่องกลับใช่หรือไม่ ?"
        zPop.Show()
    End Sub

    Protected Sub btnSendBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendBack.Click
        lblTitleName.Text = "ตีกลับ"
        lblMsg.Text = "คุณต้องการตีกลับไปยังต้นทาง ใช่หรือไม่ ?"
        zPop.Show()
    End Sub
End Class
