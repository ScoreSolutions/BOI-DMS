Imports Para.Common.Utilities
Imports System.Data

Partial Class rptGrid_rptDocList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request("vPage") IsNot Nothing Then
                Dim IsMovement As Boolean = False
                Dim whText As String = ""
                If Request("vPage") = "rptOwner" Then
                    'รายงาน งานถือครอง
                    whText += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"
                    whText += " and CHARINDEX('/',dr.book_no) = 0"
                    If Request("gID") IsNot Nothing Then
                        Dim gPara As New Para.TABLE.GroupTitlePara
                        Dim gEng As New Engine.Master.GroupTitleEng
                        gPara = gEng.GetGroupTitlePara(Request("gID"))
                        whText += " and dr.group_title_id = '" & gPara.ID & "'"
                        lblDetail.Text += gPara.GROUP_TITLE_NAME
                        gPara = Nothing
                        gEng = Nothing
                    End If
                    If Request("OrgID") IsNot Nothing Then
                        Dim oPara As New Para.TABLE.OrganizationPara
                        Dim oEng As New Engine.Master.OrganizationEng
                        oPara = oEng.GetOrgPara(Request("OrgID"))
                        whText += " and ir.organization_id_receive = '" & oPara.ID & "'"
                        lblDetail.Text += " ของ " & oPara.NAME_ABB
                        oPara = Nothing
                        oEng = Nothing
                    End If
                    If Request("OfficerID") IsNot Nothing Then
                        Dim oPara As New Para.TABLE.OfficerPara
                        Dim oEng As New Engine.Master.OfficerEng
                        oPara = oEng.GetOfficerPara(Request("OfficerID"))
                        whText += " and o.id = '" & oPara.ID & "'"
                        lblDetail.Text += " ที่ " & oPara.FIRST_NAME & " " & oPara.LAST_NAME & " ถือครองอยู่และยังไม่จบงาน"
                        oPara = Nothing
                        oEng = Nothing
                    End If
                    If Request("HaveFinishDate") IsNot Nothing Then
                        If Request("HaveFinishDate") = "Y" Then
                            whText += " and dr.expect_finish_date is not null"
                        End If
                    End If
                    lblDetail.Text += " ณ " & DateTime.Now.ToString("d MMM yy HH:mm:ss", New Globalization.CultureInfo("th-TH"))
                    IsMovement = True
                ElseIf Request("vPage") = "rptKPI" Then
                    'KPI
                    If Request("rpType") IsNot Nothing Then
                        whText += " and CHARINDEX('/',dr.book_no) = 0 "
                        
                        If Request("rpType") = "INCOME" Then
                            lblDetail.Text = "เรื่องเข้า "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and convert(varchar(8),dr.register_date, 112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "RemainOver" Then
                            lblDetail.Text = "เรื่องค้างสะสมเกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (CONVERT(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                                whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "') and (CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112)) "
                                whText += "     or (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' and CONVERT(varchar(8),dr.expect_finish_date,112) < '" & Request("DateTo") & "')"
                                whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) < '" & Request("DateTo") & "')) "
                                whText += " and CONVERT(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "'"
                            End If
                        ElseIf Request("rpType") = "RemainNotOver" Then
                            lblDetail.Text = "เรื่องค้างสะสมไม่เกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (convert(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                                If Request("ExpFinish").ToString.Trim = "Y" Then
                                    whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "') and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112))"
                                    whText += "     or (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "') "
                                    whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "'))"
                                Else
                                    whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "') and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112))"
                                    whText += "     or (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "') "
                                    whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "')"
                                    whText += "     or dr.expect_finish_date is null)"
                                End If
                                whText += " and convert(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "' "
                            End If
                        ElseIf Request("rpType") = "RemainAll" Then
                            lblDetail.Text = "เรื่องค้างสะสม "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateFrom") & "' or dr.close_date is null)"
                                whText += " and CONVERT(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "'"
                            End If
                        ElseIf Request("rpType") = "OutOver" Then
                            lblDetail.Text = "เรื่องออกเกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                                whText += " and CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112)"
                                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "OutNotOver" Then
                            lblDetail.Text = "เรื่องออกไม่เกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                                If Request("ExpFinish").ToString.Trim = "Y" Then
                                    whText += " and CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112)"
                                Else
                                    whText += " and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112)"
                                    whText += " or dr.expect_finish_date is null)"
                                End If
                                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "OutAll" Then
                            lblDetail.Text = "เรื่องออก "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "RemainTotOver" Then
                            lblDetail.Text = "เรื่องค้างคงเหลือเกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                                whText += " and (convert(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)<'" & Request("DateTo") & "')) "
                                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "RemainTotNotOver" Then
                            lblDetail.Text = "เรื่องค้างคงเหลือไม่เกินกำหนด "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                                If Request("ExpFinish").ToString.Trim = "Y" Then
                                    whText += " and (convert(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)>='" & Request("DateTo") & "')) "
                                Else
                                    whText += " and ((convert(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)>='" & Request("DateTo") & "')) "
                                    whText += " or dr.expect_finish_date is null)"
                                End If
                                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                            End If
                        ElseIf Request("rpType") = "RemainTotAll" Then
                            lblDetail.Text = "เรื่องค้างคงเหลือ "
                            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                            End If
                        End If

                        If Request("gID") IsNot Nothing Then
                            Dim gPara As New Para.TABLE.GroupTitlePara
                            Dim gEng As New Engine.Master.GroupTitleEng
                            gPara = gEng.GetGroupTitlePara(Request("gID"))
                            whText += " and dr.group_title_id = '" & gPara.ID & "'"
                            lblDetail.Text += gPara.GROUP_TITLE_NAME
                            gPara = Nothing
                            gEng = Nothing
                        End If
                        If Request("OrgID") IsNot Nothing Then
                            Dim oPara As New Para.TABLE.OrganizationPara
                            Dim oEng As New Engine.Master.OrganizationEng
                            oPara = oEng.GetOrgPara(Request("OrgID"))
                            whText += " and dr.organization_id_owner = '" & oPara.ID & "'"
                            lblDetail.Text += " ของ " & oPara.NAME_ABB
                            oPara = Nothing
                            oEng = Nothing
                        End If
                        If Request("OfficerID") IsNot Nothing Then
                            Dim oPara As New Para.TABLE.OfficerPara
                            Dim oEng As New Engine.Master.OfficerEng
                            oPara = oEng.GetOfficerPara(Request("OfficerID"))
                            whText += " and dr.officer_id_approve = '" & oPara.ID & "'"
                            lblDetail.Text += "<br />เจ้าหน้าที่ " & oPara.FIRST_NAME & " " & oPara.LAST_NAME
                            oPara = Nothing
                            oEng = Nothing
                        End If
                        If Request("ExpFinish") IsNot Nothing Then
                            If Request("ExpFinish").ToString.Trim = "Y" Then
                                whText += " and dr.expect_finish_date is not null"
                            End If
                        End If

                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            Dim vDateFrom As String = SetFormatDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                            Dim vDateTo As String = SetFormatDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                            lblDetail.Text += "<br />ระหว่างวันที่ " & vDateFrom & " ถึง " & vDateTo
                        End If
                    End If

                    
                    'ElseIf Request("vPage") = "rptKPI" Then
                    '    'KPI
                    '    If Request("rpType") IsNot Nothing Then
                    '        whText += " and CHARINDEX('/',dr.book_no) = 0 "
                    '        If Request("OfficerID") IsNot Nothing Then
                    '            whText += " and dr.officer_id_approve = '" & Request("OfficerID") & "'"
                    '        End If
                    '        If Request("rpType") = "INCOME" Then
                    '            lblDetail.Text = "เรื่องเข้า "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and convert(varchar(8),dr.register_date, 112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "RemainOver" Then
                    '            lblDetail.Text = "เรื่องค้างสะสมเกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateFrom") & "' or dr.close_date is null)"
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > case when CONVERT(varchar(8),dr.expect_finish_date,112) > '" & Request("DateTo") & "' then '" & Request("DateTo") & "' else CONVERT(varchar(8),dr.expect_finish_date,112) end "
                    '                whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) < '" & Request("DateTo") & "')) "
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "RemainNotOver" Then
                    '            lblDetail.Text = "เรื่องค้างสะสมไม่เกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (convert(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                    '                If Request("ExpFinish").ToString.Trim = "Y" Then
                    '                    whText += " and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "'))"
                    '                Else
                    '                    whText += " and ((CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "'))"
                    '                    whText += " or dr.expect_finish_date is null)"
                    '                End If
                    '                whText += " and convert(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "' "
                    '            End If
                    '        ElseIf Request("rpType") = "RemainAll" Then
                    '            lblDetail.Text = "เรื่องค้างสะสม "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateFrom") & "' or dr.close_date is null)"
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "OutOver" Then
                    '            lblDetail.Text = "เรื่องออกเกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                    '                whText += " and CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112)"
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "OutNotOver" Then
                    '            lblDetail.Text = "เรื่องออกไม่เกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                    '                If Request("ExpFinish").ToString.Trim = "Y" Then
                    '                    whText += " and CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112)"
                    '                Else
                    '                    whText += " and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112)"
                    '                    whText += " or dr.expect_finish_date is null)"
                    '                End If
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "OutAll" Then
                    '            lblDetail.Text = "เรื่องออก "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "RemainTotOver" Then
                    '            lblDetail.Text = "เรื่องค้างคงเหลือเกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                    '                whText += " and (convert(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)<'" & Request("DateTo") & "')) "
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "RemainTotNotOver" Then
                    '            lblDetail.Text = "เรื่องค้างคงเหลือไม่เกินกำหนด "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                    '                If Request("ExpFinish").ToString.Trim = "Y" Then
                    '                    whText += " and (convert(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)>='" & Request("DateTo") & "')) "
                    '                Else
                    '                    whText += " and ((convert(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)>='" & Request("DateTo") & "')) "
                    '                    whText += " or dr.expect_finish_date is null)"
                    '                End If
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                    '            End If
                    '        ElseIf Request("rpType") = "RemainTotAll" Then
                    '            lblDetail.Text = "เรื่องค้างคงเหลือ "
                    '            If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '                whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                    '                whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                    '            End If
                    '        End If
                    '    End If


                    '    If Request("gID") IsNot Nothing Then
                    '        Dim gPara As New Para.TABLE.GroupTitlePara
                    '        Dim gEng As New Engine.Master.GroupTitleEng
                    '        gPara = gEng.GetGroupTitlePara(Request("gID"))
                    '        whText += " and dr.group_title_id = '" & gPara.ID & "'"
                    '        lblDetail.Text += gPara.GROUP_TITLE_NAME
                    '        gPara = Nothing
                    '        gEng = Nothing
                    '    End If
                    '    If Request("OrgID") IsNot Nothing Then
                    '        Dim oPara As New Para.TABLE.OrganizationPara
                    '        Dim oEng As New Engine.Master.OrganizationEng
                    '        oPara = oEng.GetOrgPara(Request("OrgID"))
                    '        whText += " and dr.organization_id_owner = '" & oPara.ID & "'"
                    '        lblDetail.Text += " ของ " & oPara.NAME_ABB
                    '        oPara = Nothing
                    '        oEng = Nothing
                    '    End If
                    '    If Request("ExpFinish") IsNot Nothing Then
                    '        If Request("ExpFinish").ToString.Trim = "Y" Then
                    '            whText += " and dr.expect_finish_date is not null"
                    '        End If
                    '    End If

                    '    If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                    '        Dim vDateFrom As String = SetFormatDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                    '        Dim vDateTo As String = SetFormatDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                    '        lblDetail.Text += "<br />ระหว่างวันที่ " & vDateFrom & " ถึง " & vDateTo
                    '    End If
                ElseIf Request("vPage") = "rptKPIByOrg" Then
                    'KPI รวม
                    whText += " and CHARINDEX('/',dr.book_no) = 0 "
                    whText += " and dr.expect_finish_date is not null"
                    If Request("rpType") = "Income" Then
                        lblDetail.Text += "เรื่องเข้า "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and convert(varchar(8),dr.register_date, 112) between " & "'" & Request("DateFrom") & "' and '" & Request("DateTo") & "' "
                        End If
                    ElseIf Request("rpType") = "RemainOver" Then
                        lblDetail.Text += "เรื่องค้างสะสมเกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (CONVERT(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                            whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "') and (CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112)) "
                            whText += "     or (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' and CONVERT(varchar(8),dr.expect_finish_date,112) < '" & Request("DateTo") & "')"
                            whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) < '" & Request("DateTo") & "')) "
                            whText += " and CONVERT(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "'"
                        End If
                    ElseIf Request("rpType") = "RemainNotOver" Then
                        lblDetail.Text += "เรื่องค้างสะสมไม่เกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (convert(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                            whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "') and (CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112))"
                            whText += "     or (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "') "
                            whText += "     or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) >= '" & Request("DateTo") & "'))"
                            whText += " and convert(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "' "
                        End If
                    ElseIf Request("rpType") = "RemainAll" Then
                        lblDetail.Text += "เรื่องค้างสะสม "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (convert(varchar(8),dr.close_date,112) >= '" & Request("DateFrom") & "' or dr.close_date is null)"
                            whText += " and convert(varchar(8),dr.register_date,112) < '" & Request("DateFrom") & "' "
                        End If
                    ElseIf Request("rpType") = "OutOver" Then
                        lblDetail.Text += "เรื่องออกเกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                            whText += " and CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112)"
                            whText += " and convert(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "' "
                        End If
                    ElseIf Request("rpType") = "OutNotOver" Then
                        lblDetail.Text += "เรื่องออกไม่เกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                            whText += " and CONVERT(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112)"
                            whText += " and convert(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "' "
                        End If
                    ElseIf Request("rpType") = "OutAll" Then
                        lblDetail.Text += "เรื่องออก "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                        End If
                    ElseIf Request("rpType") = "RemainTotOver" Then
                        lblDetail.Text += "เรื่องค้างคงเหลือเกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                            whText += " and (convert(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)<'" & Request("DateTo") & "')) "
                            whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                        End If
                    ElseIf Request("rpType") = "RemainTotNotOver" Then
                        lblDetail.Text += "เรื่องค้างคงเหลือไม่เกินกำหนด "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                            whText += " and (convert(varchar(8),dr.close_date,112) <= CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)>='" & Request("DateTo") & "')) "
                            whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                        End If
                    ElseIf Request("rpType") = "RemainTotAll" Then
                        lblDetail.Text += "เรื่องค้างคงเหลือ "
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and (CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                            whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'"
                        End If
                    ElseIf Request("rpType") = "BookOver" Then
                        lblDetail.Text += "เรื่องที่ใช้เวลาเกินกำหนด "   '=เรื่องออกเกิน + เรื่องค้างสะสมเกิน
                        If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                            whText += " and ((CONVERT(varchar(8),dr.close_date,112) between '" & Request("DateFrom") & "' and '" & Request("DateTo") & "'"
                            whText += " and CONVERT(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112))"
                            whText += " or ((CONVERT(varchar(8),dr.close_date,112) > '" & Request("DateTo") & "' or dr.close_date is null)"
                            whText += " and (convert(varchar(8),dr.close_date,112) > CONVERT(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112)<'" & Request("DateTo") & "')) "
                            whText += " and CONVERT(varchar(8),dr.register_date,112) <= '" & Request("DateTo") & "'))"
                        End If
                    End If
                    If Request("KpiGroupTypeID") IsNot Nothing Then
                        whText += " and dr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & Request("KpiGroupTypeID") & "')"

                        Dim gPara As New Para.TABLE.KpiAllGroupTypePara
                        Dim oEng As New Engine.Master.GroupTitleEng
                        gPara = oEng.GetKpiAllGroupTypePara(Request("KpiGroupTypeID"))
                        lblDetail.Text += "<br />" & gPara.GROUP_TYPE_NAME
                        gPara = Nothing
                        oEng = Nothing
                    End If
                    If Request("OrgID") IsNot Nothing Then
                        Dim oPara As New Para.TABLE.OrganizationPara
                        Dim oEng As New Engine.Master.OrganizationEng
                        oPara = oEng.GetOrgPara(Request("OrgID"))
                        whText += " and dr.organization_id_owner = '" & oPara.ID & "'"
                        lblDetail.Text += "<br />ของ " & oPara.NAME_ABB
                        oPara = Nothing
                        oEng = Nothing
                    End If
                    If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                        Dim vDateFrom As String = SetFormatDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        Dim vDateTo As String = SetFormatDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        lblDetail.Text += "<br />ระหว่างวันที่ " & vDateFrom & " ถึง " & vDateTo
                    End If
                ElseIf Request("vPage") = "rptWorkLoad" Then
                    'WORK LOAD
                    Dim DateDetail As String = ""
                    whText += " and CHARINDEX('/',dr.book_no) = 0 "
                    whText += " and dr.expect_finish_date is not null "
                    If Request("rpType") = "INCOME" Then
                        lblDetail.Text = "เรื่องเข้า"
                        DateDetail = " and CONVERT(varchar(8),dr.register_date,112) between "
                    ElseIf Request("rpType") = "OUT" Then
                        lblDetail.Text = "เรื่องออก"
                        DateDetail = " and CONVERT(varchar(8),dr.close_date,112) between "
                    ElseIf Request("rpType") = "REMAIN" Then
                        lblDetail.Text = "เรื่องที่ถือครองอยู่"
                        DateDetail += " and CONVERT(varchar(8),ir.receive_date,112) between "
                        IsMovement = True
                    End If
                    If Request("StdProc") IsNot Nothing Then
                        lblDetail.Text += " กลุ่มงานที่ใช้เวลา "
                        If Request("StdProc") < 1 Then
                            lblDetail.Text += (Request("StdProc") * 8) & " ชม."
                        Else
                            lblDetail.Text += Request("StdProc") & " วัน"
                        End If
                        whText += " and gt.std_proc_period = '" & Request("StdProc") & "'"
                    End If
                    If Request("GroupTitleTypeID") IsNot Nothing Then
                        whText += " and gt.group_title_type_id = '" & Request("GroupTitleTypeID") & "'"
                    End If
                    If Request("OfficerID") IsNot Nothing Then
                        Dim oPara As New Para.TABLE.OfficerPara
                        Dim oEng As New Engine.Master.OfficerEng
                        oPara = oEng.GetOfficerPara(Request("OfficerID"))
                        lblDetail.Text += "<br />ผู้พิจารณา " & oPara.FIRST_NAME & " " & oPara.LAST_NAME
                        whText += " and dr.officer_id_approve = '" & oPara.ID & "'"
                        oEng = Nothing
                        oPara = Nothing
                    End If
                    If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                        Dim vDateFrom As String = SetFormatDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        Dim vDateTo As String = SetFormatDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        lblDetail.Text += "<br />ระหว่างวันที่ " & vDateFrom & " ถึง " & vDateTo
                        whText += DateDetail & "'" & Request("DateFrom") & "' and '" & Request("DateTo") & "' "
                    End If
                ElseIf Request("vPage") = "rptRepStorageReceive" Then
                    whText += " 	and dr.id in "
                    whText += " 	    (select ir.document_register_id"
                    whText += " 		from DOCUMENT_INT_RECEIVER ir"
                    whText += "         where ir.organization_id_send = '" & Request("OrgID") & "' "
                    If Request("ReceiveOrgID") IsNot Nothing Then
                        whText += "         and ir.organization_id_receive = '" & Request("ReceiveOrgID") & "'"
                    End If
                    If Request("OrgID") IsNot Nothing Then
                        Dim oPara As New Para.TABLE.OrganizationPara
                        Dim oEng As New Engine.Master.OrganizationEng
                        oPara = oEng.GetOrgPara(Request("OrgID"))
                        lblDetail.Text += " ของ " & oPara.NAME_ABB
                        oPara = Nothing
                        oEng = Nothing
                    End If
                    If Request("DateFrom") IsNot Nothing And Request("DateTo") IsNot Nothing Then
                        Dim vDateFrom As String = SetFormatDate(Request("DateFrom")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        Dim vDateTo As String = SetFormatDate(Request("DateTo")).ToString("d MMM yy", New Globalization.CultureInfo("th-TH"))
                        lblDetail.Text += "<br />ระหว่างวันที่ " & vDateFrom & " ถึง " & vDateTo

                        whText += " 		and convert(varchar(8),ir.receive_date,112) between '" & Request("DateFrom") & "' AND '" & Request("DateTo") & "')"
                    End If
                    whText += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id='" & Request("SendGroupTypeID") & "')"
                End If
                SetGridView(whText, IsMovement, "1<>1")
            End If
        End If
    End Sub

    Private Function SetFormatDate(ByVal vDateIn As String) As Date
        'vDateIn = yyyyMMdd
        Dim ret As New Date(1, 1, 1)
        If vDateIn.Trim <> "" Then
            Dim yy As Integer = Left(vDateIn, 4)
            Dim mm As Integer = Mid(vDateIn, 5, 2)
            Dim dd As Integer = Right(vDateIn, 2)

            ret = New Date(yy, mm, dd)
        End If
        Return ret
    End Function

    Private Sub SetGridView(ByVal whText As String, ByVal IsMovement As Boolean, ByVal ImpText As String)
        Dim dt As New DataTable
        Dim eng As New Engine.Document.SearchDocumentENG
        If IsMovement = False Then
            dt = eng.SearchByCondition(whText, " and 1<>1")
        Else
            dt = eng.SearchByOfficerMovement(whText)
        End If

        If dt.Rows.Count > 0 Then
            dt.Columns.Add("process_date_qty")
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dEng As New Engine.Document.DocumentRegisterENG
                If Convert.IsDBNull(dt.Rows(i)("close_date")) = False Then
                    dt.Rows(i)("process_date_qty") = dEng.CalProcessDate(dt.Rows(i)("register_date"), dt.Rows(i)("close_date"))
                End If
                dEng = Nothing

                dt.Rows(i)("no") = (i + 1).ToString

                Dim trans As New Linq.Common.Utilities.TransactionDB
                trans.CreateTransaction()
                dt.Rows(i)("doc_status_name") += Engine.Document.DocumentRegisterENG.GetBookOutDetailReports(dt.Rows(i)("id"), trans)
                trans.CommitTransaction()
            Next
            GridView1.DataSource = dt
            GridView1.DataBind()

            Config.SaveTransLog("rptDocList.aspx " & lblDetail.Text & " จำนวน " & dt.Rows.Count & " เรื่อง")
        Else
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
        eng = Nothing
        dt = Nothing
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblRequestNo As Label = DirectCast(e.Row.FindControl("lblRequestNo"), Label)
            If e.Row.Cells(10).Text <> "&nbsp;" Then
                lblRequestNo.Text = "<br /><br />คำขอ :<font color='red'>" & e.Row.Cells(10).Text & "</font>"
            End If

            'BookNo
            Dim lblBookNo As Label = CType(e.Row.FindControl("lblBookNo"), Label)
            lblBookNo.Text = "<a href='../WebApp/frmDocBookDetailShow.aspx?id=" + e.Row.Cells(11).Text + "&rnd=" & DateTime.Now.Millisecond & "' target='_blank'>" & lblBookNo.Text & "</a>"
        End If
    End Sub
End Class
