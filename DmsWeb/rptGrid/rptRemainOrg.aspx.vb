Imports System.Data
Imports System
Imports MycustomDG
Partial Class rptGrid_rptRemainOrg
    Inherits System.Web.UI.Page
    Dim reports As New Cls_Report
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim OrgID As Long = 0
            If Request("OrgID") IsNot Nothing Then
                OrgID = Convert.ToInt64(Request("OrgID"))
                Dim oPara As New Para.TABLE.OrganizationPara
                Dim oEng As New Engine.Master.OrganizationEng
                oPara = oEng.GetOrgPara(OrgID)
                lbl_organize.Text = oPara.NAME_ABB
                oPara = Nothing
                oEng = Nothing
            End If
            Binddata(OrgID)
        End If
    End Sub

    Const SessDataItem As String = "SessDataItem"
    Private Sub Binddata(ByVal OrgID As String)
        Dim dt As New DataTable
        reports.OrgID = OrgID
        dt = reports.rptRemainOrg
        Session(SessDataItem) = dt
        If dt.Rows.Count > 0 Then
            Dim gDt As New DataTable
            gDt = dt.DefaultView.ToTable(True, "doc_cat_type_name", "doc_cat_type_id").Copy
            If gDt.Rows.Count > 0 Then
                Repeater1.DataSource = gDt
                Repeater1.DataBind()
                gDt = Nothing
            End If
            dt = Nothing
        End If
        Session.Remove(SessDataItem)
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lblGroupTitleTypeID As Label = DirectCast(e.Item.FindControl("lblGroupTitleTypeID"), Label)
            Dim lblGroupTitleTypeName As Label = DirectCast(e.Item.FindControl("lblGroupTitleTypeName"), Label)

            Dim lblDesc As Label = DirectCast(e.Item.FindControl("lblDesc"), Label)
            Dim dt As New DataTable
            dt = Session(SessDataItem)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.RowFilter = "doc_cat_type_id='" & lblGroupTitleTypeID.Text & "'"
                Dim tmpDt As New DataTable
                tmpDt = dt.DefaultView.ToTable.Copy
                dt.DefaultView.RowFilter = ""
                If tmpDt.Rows.Count > 0 Then
                    Dim sumOverDue As Double = 0
                    Dim sumNotOverDue As Double = 0
                    Dim ret As String = ""
                    For i As Integer = 0 To tmpDt.Rows.Count - 1
                        Dim dr As DataRow = tmpDt.Rows(i)
                        ret += "<tr class='grid_Item' >"
                        ret += "    <td align='center' >" & (i + 1).ToString & "</td>"
                        ret += "    <td >" & dr("group_title_name") & "</td>"
                        ret += "    <td align='center' >&nbsp;"
                        If Convert.ToDouble(dr("overdue")) > 0 Then
                            ret += dr("overdue").ToString
                            sumOverDue += Convert.ToDouble(dr("overdue"))
                        End If
                        ret += "    </td>"

                        ret += "    <td align='center' >&nbsp;"
                        If Convert.ToDouble(dr("notoverdue")) > 0 Then
                            ret += dr("notoverdue").ToString
                            sumNotOverDue += Convert.ToDouble(dr("notoverdue"))
                        End If
                        ret += "    </td>"

                        ret += "    <td align='center' >&nbsp;"
                        If Convert.ToDouble(dr("overdue")) + Convert.ToDouble(dr("notoverdue")) > 0 Then
                            ret += (Convert.ToDouble(dr("overdue")) + Convert.ToDouble(dr("notoverdue"))).ToString
                        End If
                        ret += "    </td>"
                        ret += "</tr>"
                    Next
                    ret += "<tr class='grid_Header' >"
                    ret += "    <td colspan='2' align='center' >รวม " & lblGroupTitleTypeName.Text & "</td>"
                    ret += "    <td >" & sumOverDue.ToString & "</td>"
                    ret += "    <td >" & sumNotOverDue.ToString & "</td>"
                    ret += "    <td >" & (sumOverDue + sumNotOverDue).ToString & "</td>"
                    ret += "</tr>"
                    lblDesc.Text = ret

                    TotOverDue += sumOverDue
                    TotNotOverDue += sumNotOverDue
                    tmpDt = Nothing
                End If
                dt = Nothing
            End If
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            Dim lblTotOverDue As Label = DirectCast(e.Item.FindControl("lblTotOverDue"), Label)
            Dim lblTotNotOverDue As Label = DirectCast(e.Item.FindControl("lblTotNotOverDue"), Label)
            Dim lblTotTotal As Label = DirectCast(e.Item.FindControl("lblTotTotal"), Label)

            lblTotOverDue.Text = TotOverDue.ToString
            lblTotNotOverDue.Text = TotNotOverDue.ToString
            lblTotTotal.Text = (TotOverDue + TotNotOverDue).ToString
        End If
    End Sub

    Dim TotOverDue As Double = 0
    Dim TotNotOverDue As Double = 0
End Class
