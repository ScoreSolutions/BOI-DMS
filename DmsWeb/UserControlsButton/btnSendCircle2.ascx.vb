Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_Button_btnSendCircle2
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
        If Session("chkSelect") < 1 Then
            Config.SetAlert("กรุณาเลือกเรื่องที่จะส่งหนังสือเวียน", Me.Page)
            Exit Sub
        ElseIf Session("chkSelect") > 1 Then
            Config.SetAlert("เลือกส่งหนังสือเวียนได้ครั้งละ 1 เรื่องเท่านั้น", Me.Page)
            Exit Sub
        Else
            zPop.Show()
            GData()
            GSelect()
        End If

        zPop.Show()
        GData()
        GSelect()
    End Sub
    Private Sub GData()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("OrgNameReceive")


        For i As Integer = 0 To 1
            Dim dr As DataRow = dt.NewRow
            dr("id") = i + 1
            dr("OrgNameReceive") = "สำนักการตลาด " & i + 1


            dt.Rows.Add(dr)
        Next
        gvSendList.DataSource = dt
        gvSendList.DataBind()
    End Sub
    Private Sub GSelect()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("OrgNameReceive")


        For i As Integer = 0 To 1
            Dim dr As DataRow = dt.NewRow
            dr("id") = i + 1
            dr("OrgNameReceive") = "งานคลัง " & i + 1


            dt.Rows.Add(dr)
        Next
        gvSelect.DataSource = dt
        gvSelect.DataBind()
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        zPop.Show()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        zPop.Show()
    End Sub
    Private Sub GData2()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("OrgNameReceive")
        dt.Columns.Add("StaffNameReceive")


        For i As Integer = 0 To 1
            Dim dr As DataRow = dt.NewRow
            dr("id") = i + 1
            dr("OrgNameReceive") = "54-000421" & "/"
            dr("StaffNameReceive") = "งานคลัง " & i + 1


            dt.Rows.Add(dr)
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        zPop.Hide()
        zPop2.Show()
        GData2()
        lblno.Text = "54-000421"
    End Sub
End Class
