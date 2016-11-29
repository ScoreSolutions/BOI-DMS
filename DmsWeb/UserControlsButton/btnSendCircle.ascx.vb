Imports Para.TABLE
Imports Engine.Master
Imports Engine.Common
Imports System.Data
Partial Class UserControls_Button_btnSendCircle
    Inherits System.Web.UI.UserControl

    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SendClick(ByVal sender As Object, ByVal e As System.EventArgs, ByVal SelectOrgDT As DataTable)
    Public Event OkClick(ByVal sender As Object, ByVal e As System.EventArgs)

    'Const SessSelectedOrg As String = "SessSelectedOrg"

    Protected Sub btnButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnButton1.Click
        RaiseEvent Click(sender, e)
    End Sub
    Public Sub SetShowPop()
        'SetComBo()
        'Session.Remove(SessSelectedOrg)
        gvNoSeleteList.DataSource = Nothing
        gvNoSeleteList.DataBind()

        gvSelected.DataSource = Nothing
        gvSelected.DataBind()

        SetNoSelectGv()
        zPop.Show()
    End Sub

    'Private Sub SetComBo()
    '    Dim fnc As New OrganizationEng
    '    cmbOrgGroupID.SetItemList(fnc.GetOrgTypeList, "thai_name", "id")
    'End Sub

    Private Function GetSelectedDT() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("org_name")
        dt.Columns.Add(New DataColumn("OrgNameReceiveID", GetType(String)))
        dt.Columns.Add(New DataColumn("StaffNameReceiveID", GetType(String)))
        dt.Columns.Add(New DataColumn("PurposeID", GetType(String)))
        dt.Columns.Add(New DataColumn("remark_receive", GetType(String)))
        dt.Columns.Add(New DataColumn("OrgNameReceive", GetType(String)))
        dt.Columns.Add(New DataColumn("OrgAbbNameReceive", GetType(String)))
        dt.Columns.Add(New DataColumn("StaffNameReceive", GetType(String)))
        dt.Columns.Add(New DataColumn("Purpose", GetType(String)))

        Return dt
    End Function
    Private Function GetSelectedList() As DataTable
        Dim dt As New DataTable
        dt = GetSelectedDT()
        If gvSelected.Rows.Count > 0 Then
            For Each grv As GridViewRow In gvSelected.Rows
                Dim dr As DataRow = dt.NewRow
                dr("org_name") = grv.Cells(1).Text
                dr("id") = grv.Cells(2).Text

                Dim oEng As New Engine.Master.OrganizationEng
                Dim oPara As Para.TABLE.OrganizationPara = oEng.GetOrgPara(dr("id"))

                dr("OrgNameReceiveID") = grv.Cells(2).Text
                dr("OrgNameReceive") = oPara.ORG_NAME
                dr("OrgAbbNameReceive") = oPara.EXPR1    'ชื่อย่อหน่วยงานสำหรับออกเลขหนังสือเวียน
                dr("StaffNameReceiveID") = 0
                dr("PurposeID") = 0
                dr("remark_receive") = ""
                dr("StaffNameReceive") = ""
                dr("Purpose") = ""
                dt.Rows.Add(dr)
            Next
        End If
        Return dt
    End Function



    Private Sub SetNoSelectGv()
        Dim tmp As String = ""
        Dim dt As DataTable
        dt = GetSelectedList()
        'If Session(SessSelectedOrg) Is Nothing Then
        '    dt = GetSelectedDT()
        'Else
        '    dt = Session(SessSelectedOrg)
        'End If

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If tmp = "" Then
                    tmp = Convert.ToInt64(dr("id"))
                Else
                    tmp += "," & Convert.ToInt64(dr("id"))
                End If
            Next
        End If


        Dim oEng As New OrganizationEng
        Dim orgDT As New DataTable
        orgDT = oEng.GetOrgByType(tmp)
        If orgDT.Rows.Count > 0 Then
            gvNoSeleteList.DataSource = orgDT
            gvNoSeleteList.DataBind()
        Else
            gvNoSeleteList.DataSource = Nothing
            gvNoSeleteList.DataBind()
        End If
        orgDT.Dispose()
        oEng = Nothing
        dt.Dispose()
    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim dt As New DataTable
        dt = GetSelectedList()

        'If Session(SessSelectedOrg) Is Nothing Then
        '    dt = GetSelectedDT()
        'Else
        '    dt = Session(SessSelectedOrg)
        'End If
        For Each grv As GridViewRow In gvNoSeleteList.Rows
            Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
            If chk.Checked = True Then
                Dim dr As DataRow = dt.NewRow
                dr("org_name") = grv.Cells(1).Text
                dr("id") = grv.Cells(2).Text

                Dim oEng As New Engine.Master.OrganizationEng
                Dim oPara As Para.TABLE.OrganizationPara = oEng.GetOrgPara(dr("id"))

                dr("OrgNameReceiveID") = grv.Cells(2).Text
                dr("OrgNameReceive") = oPara.ORG_NAME
                dr("OrgAbbNameReceive") = oPara.EXPR1    'ชื่อย่อหน่วยงานสำหรับออกเลขหนังสือเวียน

                dr("StaffNameReceiveID") = 0
                dr("PurposeID") = 0
                dr("remark_receive") = ""
                dr("StaffNameReceive") = ""
                dr("Purpose") = ""

                dt.Rows.Add(dr)
            End If
        Next

        If dt.Rows.Count > 0 Then
            gvSelected.DataSource = dt
            gvSelected.DataBind()
            'Session(SessSelectedOrg) = dt
        Else
            gvSelected.DataSource = Nothing
            gvSelected.DataBind()
            'Session.Remove(SessSelectedOrg)
        End If
        SetNoSelectGv()
        Config.SaveTransLog("btnSendCurcle คลิกปุ่มเพิ่มหน่วยงาน")
        dt.Dispose()
        zPop.Show()
    End Sub

    Protected Sub btnNoSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoSelect.Click
        'If Session(SessSelectedOrg) IsNot Nothing Then
        If gvSelected.Rows.Count > 0 Then
            Dim dt As DataTable = GetSelectedList() 'Session(SessSelectedOrg)
            For i As Integer = gvSelected.Rows.Count - 1 To 0 Step -1
                Dim grv As GridViewRow = gvSelected.Rows(i)
                Dim chk As CheckBox = grv.Cells(0).FindControl("cb")
                If chk.Checked = True Then
                    dt.Rows.RemoveAt(i)
                End If
            Next

            If dt.Rows.Count > 0 Then
                gvSelected.DataSource = dt
                gvSelected.DataBind()
                'Session(SessSelectedOrg) = dt
            Else
                gvSelected.DataSource = Nothing
                gvSelected.DataBind()
                'Session.Remove(SessSelectedOrg)
            End If
            SetNoSelectGv()
        End If
        Config.SaveTransLog("btnSendCurcle คลิกปุ่มลบหน่วยงาน")
        zPop.Show()
    End Sub

    Protected Sub cbAll_OnCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkH As CheckBox = sender
        Dim grv As GridViewRow = chkH.Parent.Parent
        Dim gv As GridView = grv.Parent.Parent
        For i As Integer = 0 To gv.Rows.Count - 1
            Dim chk As CheckBox = gv.Rows(i).Cells(0).FindControl("cb")
            chk.Checked = chkH.Checked
        Next

        zPop.Show()
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'If Session(SessSelectedOrg) IsNot Nothing Then
        If gvSelected.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt = GetSelectedList() 'DirectCast(Session(SessSelectedOrg), DataTable).Copy
            RaiseEvent SendClick(sender, e, dt)
        Else
            Config.SetAlert("กรุณาเลือกหน่วยงานที่รับหนังสือเวียน", Me.Page)
            zPop.Show()
        End If
    End Sub

    'Public Sub SetSendComplete(ByVal para As Para.Document.SendCirclePara)
    '    lblBookNo.Text = para.BOOK_NO

    '    If para.SEND_LIST.Rows.Count > 0 Then
    '        GridView1.DataSource = para.SEND_LIST
    '        GridView1.DataBind()
    '    End If
    '    Session.Remove(SessSelectedOrg)
    '    zPop2.Show()
    'End Sub
    Public Sub SetSendComplete(ByVal para As Para.Document.SendCirclePara)
        lblBookNo.Text = para.BOOK_NO.Substring(2)

        If para.SEND_LIST.Rows.Count > 0 Then
            GridView1.DataSource = para.SEND_LIST
            GridView1.DataBind()
        End If
        'Session.Remove(SessSelectedOrg)
        gvSelected.DataSource = Nothing
        gvSelected.DataBind()
        zPop2.Show()
    End Sub

    Private Sub ClearForm()
        gvSelected.DataSource = Nothing
        gvSelected.DataBind()
        gvNoSeleteList.DataSource = Nothing
        gvNoSeleteList.DataBind()
        'Session.Remove(SessSelectedOrg)
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Config.SaveTransLog("คลิกปุ่มตกลง")
        ClearForm()
        RaiseEvent OkClick(sender, e)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Config.SaveTransLog("คลิกปุ่มปิด")
        ClearForm()
        RaiseEvent OkClick(sender, e)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Config.SaveTransLog("btnSendCurcle คลิกปุ่มยกเลิก")
    End Sub

    Protected Sub imgClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Config.SaveTransLog("btnSendCurcle คลิกปุ่มลบปิด")
    End Sub
End Class
