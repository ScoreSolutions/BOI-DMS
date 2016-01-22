Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_ctlSearchBookIn
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Public Sub NothingGridView()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
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
        dt.Columns.Add("user_receive")
        dt.Columns.Add("req_no")

        Dim dr As DataRow = dt.NewRow
        dr("id") = 1
        dr("bookno") = "54-000421"
        dr("book_from") = "เทคโน แอสโซชิเอะ (ประเทศไทย)"
        dr("book_date") = ""
        dr("book_title") = "1.98 งานวิเคราะห์โครงการเบื้องต้น"
        dr("speed") = "ปกติ"
        dr("secret") = "ปกติ"
        dr("chk") = "read"
        dr("date_register") = Today.Date
        dr("doc_no") = "54-00001"
        dr("user_send") = "ชาตรี ลิ้มผ่องใส"
        dr("dept") = "กบส"
        dr("user_receive") = "ชลีพร เฮงตระกูล"
        dr("req_no") = ""
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("id") = 2
        dr("bookno") = "54-000100"
        dr("book_from") = "บีโอไอ-กองสารสนเทศ"
        dr("book_date") = ""
        dr("book_title") = "27.97 หนังสือภายใน - งานรับเอกสาร / ส่งเอกสาร / รับคำขอฯ"
        dr("speed") = "ปกติ"
        dr("secret") = "ปกติ"
        dr("chk") = "read"
        dr("date_register") = Today.Date
        dr("doc_no") = "54-00002"
        dr("user_send") = "กอบเกื้อ เผ่าจำรูญ"
        dr("dept") = "ผช-อ"
        dr("user_receive") = "พิมลดา อู่อ้น"
        dr("req_no") = "54-2346"
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

    Public WriteOnly Property ShowSearch() As Boolean
        Set(ByVal value As Boolean)
            frmSearch.Visible = value
        End Set
    End Property
    Public WriteOnly Property ShowCheckboxColumn() As Boolean
        Set(ByVal value As Boolean)
            GridView1.Columns(0).Visible = False
        End Set
    End Property

    Protected Sub likBookNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("../BookIn/frmBookDetail.aspx")
    End Sub

End Class
