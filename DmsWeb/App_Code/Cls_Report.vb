Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Globalization
Public Class Cls_Report

    Private strfromdt As String = String.Empty
    Private strtodt As String = String.Empty
    Private _OrgID As String = ""
    Private strOrganize As String = String.Empty
    Private strCompany As String = String.Empty
    Private strgroup_title_code As String = String.Empty
    Private strgroup_title_name As String = String.Empty
    Private strbook_no As String = String.Empty
    Private strbookoutfrom As String = String.Empty
    Private strbookoutto As String = String.Empty
    Private strdoc_status_id As String = String.Empty
    Private strdoc_cat_type_id As Long = 0
    Private strdoc_cat_type_name As String = String.Empty
    Private strtitle_name As String = String.Empty
    Private strofficer_id_possess As String = String.Empty
    Private strofficer_id_approve As String = ""
    Private strregister_date As String = String.Empty
    Private strhavefinishdate As String = ""
    
    Public Property fromdate() As String
        Get
            Return strfromdt
        End Get
        Set(ByVal value As String)
            strfromdt = value
        End Set
    End Property
    Public Property todt() As String
        Get
            Return strtodt
        End Get
        Set(ByVal value As String)
            strtodt = value
        End Set
    End Property
    Public Property OrgID() As String
        Get
            Return _OrgID.Trim
        End Get
        Set(ByVal value As String)
            _OrgID = value
        End Set
    End Property
    Public Property Organizename() As String
        Get
            Return strOrganize
        End Get
        Set(ByVal value As String)
            strOrganize = value
        End Set
    End Property
    Public Property Companyname() As String
        Get
            Return strCompany
        End Get
        Set(ByVal value As String)
            strCompany = value
        End Set
    End Property
    Public Property group_title_code() As String
        Get
            Return strgroup_title_code
        End Get
        Set(ByVal value As String)
            strgroup_title_code = value
        End Set
    End Property
    Public Property group_title_name() As String
        Get
            Return strgroup_title_name
        End Get
        Set(ByVal value As String)
            strgroup_title_name = value
        End Set
    End Property
    Public Property book_no() As String
        Get
            Return strbook_no
        End Get
        Set(ByVal value As String)
            strbook_no = value
        End Set
    End Property
    Public Property booknoout_from() As String
        Get
            Return strbookoutfrom
        End Get
        Set(ByVal value As String)
            strbookoutfrom = value
        End Set
    End Property
    Public Property booknoout_to() As String
        Get
            Return strbookoutto
        End Get
        Set(ByVal value As String)
            strbookoutto = value
        End Set
    End Property
    Public Property doc_status_id() As String
        Get
            Return strdoc_status_id
        End Get
        Set(ByVal value As String)
            strdoc_status_id = value
        End Set
    End Property
    Public Property doc_cat_type_id() As Long
        Get
            Return strdoc_cat_type_id
        End Get
        Set(ByVal value As Long)
            strdoc_cat_type_id = value
        End Set
    End Property
    Public Property doc_cat_type_name() As String
        Get
            Return strdoc_cat_type_name
        End Get
        Set(ByVal value As String)
            strdoc_cat_type_name = value
        End Set
    End Property
    Public Property title_name() As String
        Get
            Return strtitle_name
        End Get
        Set(ByVal value As String)
            strtitle_name = value
        End Set
    End Property
    Public Property register_date() As String
        Get
            Return strregister_date
        End Get
        Set(ByVal value As String)
            strregister_date = value
        End Set
    End Property
    
    Public Property officer_id_possess() As String
        Get
            Return strofficer_id_possess
        End Get
        Set(ByVal value As String)
            strofficer_id_possess = value
        End Set
    End Property
    Public Property officer_id_approve() As String
        Get
            Return strofficer_id_approve
        End Get
        Set(ByVal value As String)
            strofficer_id_approve = value
        End Set
    End Property
    Public Property havefinishdate() As String
        Get
            Return strhavefinishdate.Trim
        End Get
        Set(ByVal value As String)
            strhavefinishdate = value
        End Set
    End Property
    Public Function rptsumdocregist() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = " where 1=1 "
        If fromdate.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8), register_date,112) >= '" & fromdate & "'"
        End If
        If todt.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8), register_date,112) <= '" & todt & "'"
        End If
        If group_title_name.Length > 0 Then

            strwc = strwc & vbCrLf & " and group_title_name ='" & group_title_name & "'"
        End If
        If book_no.Length > 0 Then
            strwc = strwc & vbCrLf & " and book_no ='" & book_no & "'"
        End If
        If doc_status_id.Length > 0 Then
            strwc = strwc & vbCrLf & " and DOCUMENT_REGISTER.doc_status_id ='" & doc_status_id & "'"
        End If
        If OrgID > 0 Then
            strwc = strwc & vbCrLf & " AND (DOCUMENT_REGISTER.organization_id_register = '" & OrgID & "')"
        End If
        strcommand = "select GROUP_TITLE.id,group_title_name,book_no,title_name,company_name,request_no,bookout_no,organization_name"
        strcommand = strcommand & vbCrLf & " ,company_doc_no,organization_appname,register_date,doc_status_name,expect_finish_date"
        strcommand = strcommand & vbCrLf & " ,company_doc_date,company_sign,company_type_name,remarks,officer_name"
        strcommand = strcommand & vbCrLf & " ,isnull(first_name,'') +' ' + isnull(last_name,'') as officer_app_name"
        strcommand = strcommand & vbCrLf & " ,close_date,DATEDIFF(day,expect_finish_date,getdate()) as over_date, DOCUMENT_REGISTER.id document_register_id"
        strcommand = strcommand & vbCrLf & " from DOCUMENT_REGISTER inner join GROUP_TITLE "
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.group_title_id=GROUP_TITLE.id"
        strcommand = strcommand & vbCrLf & " left join COMPANY "
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.company_id=company.id"
        strcommand = strcommand & vbCrLf & " left join DOC_STATUS"
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.doc_status_id=doc_status.id"
        strcommand = strcommand & vbCrLf & " left join COMPANY_TYPE"
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.business_type_id=COMPANY_TYPE.id"
        strcommand = strcommand & vbCrLf & " left join OFFICER"
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.officer_id_approve=OFFICER.id" & strwc
        strcommand = strcommand & vbCrLf & " order by CONVERT(float, group_title_code), register_date, book_no"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function rptdocrcv() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty
        
        If strfromdt.Trim <> "" Then
            strwc += " and convert(varchar(8),DOCUMENT_INT_RECEIVER.receive_date,112)>='" & strfromdt & "'"
        End If
        If strtodt.Trim <> "" Then
            strwc += " and convert(varchar(8),DOCUMENT_INT_RECEIVER.receive_date,112)<='" & strtodt & "'"
        End If
        If group_title_name.Trim <> "" Then
            strwc = strwc & vbCrLf & " and group_title_name = '" & group_title_name & "'"
        End If
        If OrgID > 0 Then
            strwc += vbCrLf & " and organization_id_receive = '" & OrgID & "'"
        End If
        Dim uPara As Para.Common.UserProfilePara = Config.GetLogOnUser
        strcommand = "select distinct DOCUMENT_REGISTER.id document_register_id, book_no,title_name,company_name,company_doc_no,organization_name"
        strcommand = strcommand & vbCrLf & ",register_date,group_title_name, request_no, convert(float,GROUP_TITLE.group_title_code) group_title_code"
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER left join DOCUMENT_INT_RECEIVER "
        strcommand = strcommand & vbCrLf & "on DOCUMENT_REGISTER.id=DOCUMENT_INT_RECEIVER.document_register_id"
        strcommand = strcommand & vbCrLf & "inner join GROUP_TITLE"
        strcommand = strcommand & vbCrLf & "on DOCUMENT_REGISTER.group_title_id=group_title.id"
        strcommand = strcommand & vbCrLf & "where DOCUMENT_INT_RECEIVER.receive_date Is Not null "
        strcommand = strcommand & vbCrLf & strwc
        strcommand = strcommand & vbCrLf & " order by convert(float,GROUP_TITLE.group_title_code) , DOCUMENT_REGISTER.register_date, DOCUMENT_REGISTER.book_no"

        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt
    End Function
    Public Function rptdocout() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = " and DOCUMENT_INT_RECEIVER.organization_id_send<>DOCUMENT_INT_RECEIVER.organization_id_receive"
        If OrgID > "0" Then
            strwc += " and DOCUMENT_INT_RECEIVER.organization_id_send = '" & OrgID & "'"
        End If
        If fromdate.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8),DOCUMENT_INT_RECEIVER.send_date,112) >='" & fromdate & "' "
        End If
        If todt.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8),DOCUMENT_INT_RECEIVER.send_date,112)<='" & todt & "' "
        End If
        If book_no.Length > 0 Then
            strwc = strwc & vbCrLf & " and book_no ='" & book_no & "'"
        End If
       
        strcommand = "select distinct book_no,title_name,org_name,company_name,company_doc_no,organization_name, DOCUMENT_REGISTER.id document_register_id"
        strcommand = strcommand & vbCrLf & " ,register_date,doc_status_name,DOCUMENT_REGISTER.expect_finish_date, "
        strcommand = strcommand & vbCrLf & " DOCUMENT_REGISTER.close_date, DOCUMENT_REGISTER.doc_status_id,DOCUMENT_REGISTER.bookout_no "
        strcommand = strcommand & vbCrLf & " from DOCUMENT_REGISTER inner join DOCUMENT_INT_RECEIVER "
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.id=DOCUMENT_INT_RECEIVER.document_register_id"
        strcommand = strcommand & vbCrLf & " left join ORGANIZATION"
        strcommand = strcommand & vbCrLf & " on DOCUMENT_INT_RECEIVER.organization_id_send=ORGANIZATION.id"
        strcommand = strcommand & vbCrLf & " left join DOC_STATUS"
        strcommand = strcommand & vbCrLf & " on DOCUMENT_REGISTER.doc_status_id=doc_status.id"
        strcommand = strcommand & vbCrLf & " where 1=1 " & strwc
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function rptsumdocregistdtl() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        strcommand = "select DOCUMENT_INT_RECEIVER.id,receiver_officer_fullname,organization_name_receive"
        strcommand = strcommand & vbCrLf & ",receive_date,sender_officer_fullname,organization_name_send"
        strcommand = strcommand & vbCrLf & ",send_date,DOCUMENT_INT_RECEIVER.remarks"
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER left join DOCUMENT_INT_RECEIVER"
        strcommand = strcommand & vbCrLf & "on DOCUMENT_REGISTER.id=DOCUMENT_INT_RECEIVER.document_register_id"
        strcommand = strcommand & vbCrLf & "where book_no='" & book_no & "'"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function

    Public Function rptdocoutside() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty
        If fromdate.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and CONVERT(varchar(10),er.send_date,120)>='" & fromdate & "'"
        End If
        If todt.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and CONVERT(varchar(10),er.send_date,120)<='" & todt & "'"
        End If
        If booknoout_from.Length > 0 And booknoout_to.Length = 0 Then
            strwc = strwc & vbCrLf & " and er.bookout_no like '" & booknoout_from & "%'"
        ElseIf booknoout_from.Length > 0 And booknoout_to.Length > 0 Then
            strwc = strwc & vbCrLf & " and er.bookout_no BETWEEN '" & booknoout_from & "' AND '" & booknoout_to & "'"
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and  er.organization_id_send ='" & OrgID & "'"
        End If

        strcommand = "select  er.bookout_no,er.send_date,er.company_name_receive,dr.title_name,dr.book_no,ds.doc_status_name, "
        strcommand = strcommand & vbCrLf & " er.document_register_id, dr.close_date"
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER dr "
        strcommand = strcommand & vbCrLf & "inner join DOCUMENT_EXT_RECEIVER er on dr.id=er.document_register_id"
        strcommand = strcommand & vbCrLf & "left join ORGANIZATION o on er.organization_id_send=o.id"
        strcommand = strcommand & vbCrLf & "left join  DOC_STATUS ds on dr.doc_status_id=ds.id"
        strcommand = strcommand & vbCrLf & "where 1=1 " & strwc
        strcommand = strcommand & vbCrLf & " order by er.send_date, er.bookout_no "
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function rptsector() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = String.Empty
        Dim wh As String = ""

        If OrgID.Length > 0 Then
            wh = wh & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
        End If
        If strfromdt.Trim <> "" Then
            wh = wh & vbCrLf & " and convert(varchar(8),dr.register_date,112)<='" & strfromdt & "'"
            'wh += " and case when dr.close_date is null then '" & (Convert.ToInt64(fromdate) - 1) & "' else CONVERT(varchar(8),dr.close_date,112) end > '" & fromdate & "'"
        End If
        'wh += " and ir.receive_status_id = '" & Para.Common.Utilities.Constant.DocumentIntReceiver.ReceiveStatusID.Received & "'"
        wh += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"

        sql += JobRemainSql(wh, strfromdt)

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function rptRemainOrg() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim wh As String = ""

        If OrgID.Length > 0 Then
            wh = wh & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
            'wh += " and ir.organization_id_receive = '" & OrgID & "'"
        End If

        Dim sql As String = ""
        sql += " select gt.group_title_name,SUBSTRING(ct.doc_cat_type_name,4, LEN(ct.doc_cat_type_name)) doc_cat_type_name, ct.id doc_cat_type_id, "
        Sql += " sum(case when DATEDIFF(day,dr.expect_finish_date,getdate())>0 then 1 else 0 end) overdue,"
        sql += " sum(case when DATEDIFF(day,dr.expect_finish_date,getdate())<=0 then 1 else 0 end) notoverdue"
        sql += " from DOCUMENT_REGISTER dr "
        'sql += " left join DOCUMENT_INT_RECEIVER ir on dr.id=ir.document_register_id"
        'sql += "    and ir.id = (select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)"
        Sql += " inner join GROUP_TITLE gt on dr.group_title_id=gt.id"
        Sql += " inner join DOC_CAT_TYPE ct on gt.group_title_type_id=ct.doc_cat_type_id"
        Sql += " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        Sql += " and dr.expect_finish_date Is Not null"
        sql += " and CHARINDEX('/',dr.book_no) = 0 "
        'sql += " and ir.receive_status_id in ('2','4') "
        Sql += wh
        sql += " group by gt.group_title_name,SUBSTRING(ct.doc_cat_type_name,4, LEN(ct.doc_cat_type_name)), ct.id, ct.doc_cat_type_name"
        Sql += " order by ct.doc_cat_type_name,gt.group_title_name"

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function rptnotsector() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = String.Empty
        Dim strwc As String = String.Empty

        If group_title_name.Length > 0 Then
            strwc = strwc & vbCrLf & " and gt.group_title_name ='" & group_title_name & "'"
        End If
        If fromdate.ToString.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8),dr.register_date,112) <= '" & fromdate & "'"
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
        End If

        sql += " select dr.id document_register_id, dr.book_no, dr.organization_appname, gt.group_title_name, gt.group_title_code,  "
        sql += " dr.register_date,dr.expect_finish_date, dr.close_date, dr.company_name, dr.title_name, "
        sql += " isnull(dr.organization_abbname_process,dr.organization_appname) organization_abbname_process, "
        sql += " isnull(dr.officer_name_possess, dr.officer_name) officer_name_possess, dr.organization_id_owner, "
        sql += " dr.officer_name, dr.remarks , dr.group_title_id"
        sql += " from DOCUMENT_REGISTER dr  "
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id"
        sql += "	    and ir.id=(select top 1 id from DOCUMENT_INT_RECEIVER where document_register_id=dr.id order by send_date desc)"
        sql += " inner join GROUP_TITLE gt on dr.group_title_id=gt.id  "
        sql += " inner join ORGANIZATION o on o.id=dr.organization_id_owner  "
        sql += " where CHARINDEX('/',dr.book_no) = 0  "
        sql += " and dr.expect_finish_date is not null"
        sql += " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        sql += strwc
        sql += " order by gt.group_title_name, dr.register_date, dr.book_no"

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt

    End Function

    Private Function JobRemainSql(ByVal whText As String, ByVal DateFrom As String) As String
        Dim sql As String = ""
        sql += " select dr.id document_register_id, dr.book_no, dr.organization_appname, gt.group_title_name, gt.group_title_code, "
        sql += " dr.register_date,dr.expect_finish_date, dr.close_date, dr.company_name, dr.title_name,"
        sql += " isnull(dr.organization_abbname_process,dr.organization_appname) organization_abbname_process, isnull(dr.officer_name_possess, dr.officer_name) officer_name_possess,"
        sql += " dr.organization_id_owner, dr.officer_name, dr.remarks, dr.group_title_id,ir.organization_appname_send"
        sql += " from DOCUMENT_REGISTER dr "
        sql += " inner join GROUP_TITLE gt on dr.group_title_id=gt.id "
        sql += " inner join ORGANIZATION o on o.id=dr.organization_id_owner "
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id and ir.id=(select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        sql += " where CHARINDEX('/',dr.book_no) = 0 "
        sql += " and dr.expect_finish_date Is Not null and ir.receive_date is not null  "
        sql += whText
        sql += " order by gt.group_title_name, dr.register_date, dr.book_no"
        Return sql
    End Function

    Public Sub BuildOverDue(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("overdue")
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                dt.Rows(i)("overdue") = 0
                Select Case dr("organization_id_owner")
                    Case "3", "4", "5", "6", "7"
                        If Convert.IsDBNull(dr("due_step1")) = False And dr("due_step1") > 0 Then
                            If Convert.IsDBNull(dr("send_date2")) = False Then
                                If dr("holiday2") > dr("due_step3") Then
                                    dt.Rows(i)("overdue") = dr("holiday2") - dr("due_step3")
                                End If
                            Else
                                If Convert.IsDBNull(dr("send_date1")) = True Then
                                    If dr("group_title_code") <> "6.02" Then
                                        If dr("holiday1") > dr("due_step1") Then
                                            dt.Rows(i)("overdue") = dr("holiday1") - dr("due_step1")
                                        End If
                                    Else
                                        If Convert.IsDBNull(dr("expect_finish_date")) = False Then
                                            If Convert.ToDateTime(dr("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < fromdate Then
                                                dt.Rows(i)("overdue") = dr("holiday1") - dr("max_proc_period")
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If Convert.IsDBNull(dr("expect_finish_date")) = False Then
                                If Convert.ToDateTime(dr("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < fromdate Then
                                    dt.Rows(i)("overdue") = dr("holiday1") - dr("max_proc_period")
                                End If
                            End If
                        End If
                    Case Else
                        Dim OrgID As String = dr("organization_id_owner")
                        If (OrgID = "20080122003" Or ((OrgID = "17" Or OrgID = "19" Or OrgID = "20080122022" Or OrgID = "21" Or OrgID = "20080122024" Or OrgID = "20080122025" Or OrgID = "20080122026" Or OrgID = "20080122017") And dr("group_title_code") = "6.02")) And dr("due_step2") > 0 Then
                            If Convert.IsDBNull(dr("send_date1")) = False Then
                                If Convert.IsDBNull(dr("send_date2")) = True Then
                                    If dr("holiday2") > dr("due_step2") Then
                                        dt.Rows(i)("overdue") = dr("holiday2") - dr("due_step2")
                                    End If
                                End If
                            End If
                        Else
                            If Convert.IsDBNull(dr("expect_finish_date")) = False Then
                                If Convert.ToDateTime(dr("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < fromdate Then
                                    dt.Rows(i)("overdue") = dr("holiday1") - dr("max_proc_period")
                                End If
                            End If
                        End If
                End Select
            Next
        End If
    End Sub

    Public Sub BuildDueDate(ByVal dt As DataTable, Optional ByVal OrgAbbNameReceive As String = "")
        If dt.Rows.Count > 0 Then
            Try
                dt.Columns.Add("due_date", GetType(Date))
                dt.Columns.Add("overdue")
                dt.Columns.Add("receive_date")

                'หาข้อมูลการ Config Duedate
                Dim dSql As String = "select id, group_title_id,organization_abbname_send,organization_abbname_receive, proc_date "
                dSql += " from GROUP_TITLE_KPI_DUE_DATE "
                dSql += " order by id"
                Dim dDt As New DataTable
                dDt = Linq.Common.Utilities.SqlDB.ExecuteTable(dSql)

                Dim SelDate As New Date(Left(fromdate, 4), fromdate.Substring(4, 2), Right(fromdate, 2))
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)
                    Dim hDt As New DataTable

                    'ข้อมูลประวัติการรับส่งของแต่ละเรื่อง
                    Dim sDt As New DataTable
                    Dim sSql As String = "select id,organization_appname_send,organization_appname_receive, receive_date, send_date "
                    sSql += " from DOCUMENT_INT_RECEIVER"
                    sSql += " where document_register_id ='" & dr("document_register_id") & "'"
                    sSql += " and receive_date is not null"
                    sSql += " order by send_date"
                    sDt = Linq.Common.Utilities.SqlDB.ExecuteTable(sSql)

                    Dim tmpDt As DataView = dDt.DefaultView
                    tmpDt.RowFilter = "group_title_id='" & dr("group_title_id") & "'"
                    If tmpDt.Count > 0 Then
                        tmpDt.Sort = "id"

                        Dim ProcDate As Long = 0
                        Dim SecondStepID As Long = 0
                        Dim FirstStepID As Long = 0

                        For Each tmpDrv As DataRowView In tmpDt
                            Dim vOrgSend As String = IIf(Convert.IsDBNull(tmpDrv("organization_abbname_send")) = False, tmpDrv("organization_abbname_send"), "")
                            Dim vOrgReceive As String = IIf(Convert.IsDBNull(tmpDrv("organization_abbname_receive")) = False, tmpDrv("organization_abbname_receive"), "")
                            If sDt.Rows.Count > 0 Then
                                'เช็คทีละ Step
                                If vOrgSend = "" Then
                                    'Step 1  ชื่อผู้ส่งเป็นค่าว่าง ให้ดูว่า ใน Movement มีการส่งไปหาผู้รับตามที่ระบุใน organization_abbname_receive แล้วหรือไม่ ถ้ายัง แสดงว่ายังอยู่ Step 1  ถ้ามีแล้วให้ไปดู Step ถัดไปโลด
                                    ProcDate = Convert.ToInt64(tmpDrv("proc_date"))
                                    'For Each sDr As DataRow In sDt.Rows
                                    If Convert.IsDBNull(sDt.Rows(0)("receive_date")) = False Then
                                        dt.Rows(i)("receive_date") = sDt.Rows(0)("receive_date")
                                        dt.Rows(i)("organization_appname_send") = sDt.Rows(0)("organization_appname_send")
                                        dt.Rows(i)("due_date") = Engine.Document.DocumentRegisterENG.CalDueDate(ProcDate, Convert.ToDateTime(sDt.Rows(0)("receive_date")))
                                        If SelDate > Convert.ToDateTime(dt.Rows(i)("due_date")).Date Then
                                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("due_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("due_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                        Else
                                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("expect_finish_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                        End If
                                        FirstStepID = sDt.Rows(0)("id")

                                        'If vOrgReceive = sDt.Rows(0)("organization_appname_receive") Then
                                        '    Exit For
                                        'End If
                                    End If
                                    'Next
                                End If

                                If vOrgSend <> "" And vOrgReceive <> "" And vOrgSend <> vOrgReceive And FirstStepID > 0 Then
                                    'Step ที่ 2 เป็นต้นไป กรณีมีการระบุทั้งหน่วยงานที่ส่ง และหน่วยงานที่รับ
                                    ProcDate = Convert.ToInt64(tmpDrv("proc_date"))
                                    For Each sDr As DataRow In sDt.Rows
                                        If sDr("organization_appname_send").ToString = vOrgSend And sDr("organization_appname_receive").ToString = vOrgReceive Then
                                            dt.Rows(i)("receive_date") = sDr("receive_date")
                                            dt.Rows(i)("organization_appname_send") = sDr("organization_appname_send")
                                            dt.Rows(i)("due_date") = Engine.Document.DocumentRegisterENG.CalDueDate(ProcDate, Convert.ToDateTime(sDr("receive_date")))

                                            If SelDate > Convert.ToDateTime(dt.Rows(i)("due_date")).Date Then
                                                hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("due_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                                dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("due_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                            Else
                                                hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                                dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("expect_finish_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                            End If
                                            SecondStepID = sDr("id")
                                        End If
                                    Next
                                End If

                                If vOrgSend <> "" And vOrgReceive <> "" And vOrgSend = vOrgReceive And SecondStepID > 0 Then
                                    ''Step สุดท้าย เมื่อ หน่วยงานผู้รับกับหน่วยงานผู้ส่งเป็นหน่วยงานเดียวกัน
                                    Dim sDrv As DataView = sDt.DefaultView
                                    sDrv.RowFilter = " id > '" & SecondStepID & "' and organization_appname_send = '" & vOrgSend & "' and organization_appname_receive = organization_appname_send"
                                    ProcDate = Convert.ToInt64(tmpDrv("proc_date"))
                                    If sDrv.Count > 0 Then
                                        dt.Rows(i)("receive_date") = sDrv(0)("receive_date")

                                        sDrv.RowFilter = "id = '" & SecondStepID & "'"
                                        dt.Rows(i)("organization_appname_send") = sDrv(0)("organization_appname_send")
                                        dt.Rows(i)("due_date") = Engine.Document.DocumentRegisterENG.CalDueDate(ProcDate, Convert.ToDateTime(sDrv(0)("receive_date")))
                                        If SelDate > Convert.ToDateTime(dt.Rows(i)("due_date")).Date Then
                                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("due_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("due_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                        Else
                                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("expect_finish_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday"))) + 1
                                        End If
                                    End If
                                End If
                            End If
                        Next

                    Else
                        'กรณีกลุ่มเรื่องไม่ได้มีการ Config วันครบกำหนดไว้เป็น Step ใน GROUP_TITLE_KPI_DUE_DATE
                        ' ให้ตรวจสอบหน่วยงานที่เรียกดูว่าได้รับเอกสารครั้งแรกวันไหน
                        If OrgAbbNameReceive <> "" Then
                            sDt.DefaultView.RowFilter = "organization_appname_receive='" & OrgAbbNameReceive & "'"
                            If sDt.DefaultView.Count > 0 Then
                                sDt.DefaultView.Sort = "receive_date"
                                dt.Rows(i)("receive_date") = sDt.DefaultView(0)("receive_date")
                            Else
                                dt.Rows(i)("receive_date") = dt.Rows(i)("register_date")
                            End If
                        Else
                            dt.Rows(i)("receive_date") = dt.Rows(i)("register_date")
                        End If
                        
                        dt.Rows(i)("due_date") = dt.Rows(i)("expect_finish_date")
                        If SelDate > Convert.ToDateTime(dt.Rows(i)("due_date")).Date Then
                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("due_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("due_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday")))
                        Else
                            hDt = Linq.Common.Utilities.SqlDB.ExecuteTable("select dbo.FN_getHoliday('" & Convert.ToDateTime(dt.Rows(i)("expect_finish_date")).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "', '" & SelDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "') as holiday")
                            dt.Rows(i)("overdue") = (DateDiff(DateInterval.Day, Convert.ToDateTime(dt.Rows(i)("expect_finish_date")), SelDate) - Convert.ToInt64(hDt.Rows(0)("holiday")))
                        End If
                    End If
                    sDt.Dispose()
                    hDt.Dispose()
                Next
                dDt = Nothing
            Catch ex As Exception
                Dim aa As String = ex.StackTrace
                Exit Sub
            End Try
        End If
    End Sub

    Public Function rptBoard() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If group_title_name.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.group_title_name ='" & group_title_name & "'"
        End If
        If fromdate.ToString.Length > 0 Then
            strwc += " and convert(varchar(8),dr.register_date,112) <='" & fromdate & "'"
            'strwc += " and (dr.close_date is null or CONVERT(varchar(8),dr.close_date,112) > '" & fromdate & "')"
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
        End If
        strwc += vbCrLf & " and dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "'"
        strcommand += JobRemainSql(strwc, fromdate)

        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function RetreiveTitle() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty
        
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and ir.organization_id_receive ='" & OrgID & "'"
        End If
        If strhavefinishdate = "Y" Then
            strwc = strwc & vbCrLf & " and dr.expect_finish_date is not null "
        End If

        strcommand = " select gt.id group_title_id, gt.group_title_name"
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER dr "
        strcommand = strcommand & vbCrLf & " inner join document_int_receiver ir on ir.document_register_id=dr.id "
        strcommand = strcommand & vbCrLf & "    and ir.id = (select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        strcommand = strcommand & vbCrLf & " inner join GROUP_TITLE gt on gt.id=dr.group_title_id "
        strcommand = strcommand & vbCrLf & " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        strcommand = strcommand & vbCrLf & strwc
        strcommand = strcommand & vbCrLf & " group by gt.id , gt.group_title_name, gt.group_title_code "
        strcommand = strcommand & vbCrLf & " order by convert(float, gt.group_title_code) "
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function RetreiveDoc() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If title_name.Length > 0 Then
            strwc = strwc & vbCrLf & " and gt.group_title_name ='" & group_title_name & "'"
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and ir.organization_id_receive ='" & OrgID & "'"
        End If
        If strhavefinishdate = "Y" Then
            strwc = strwc & vbCrLf & " and dr.expect_finish_date is not null "
        End If

        strcommand = " select o.id officer_id_approve,o.first_name"
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER dr "
        strcommand = strcommand & vbCrLf & " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id and ir.id=(select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        strcommand = strcommand & vbCrLf & " inner join OFFICER o on ir.receiver_officer_username=o.username"
        strcommand = strcommand & vbCrLf & " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        strcommand = strcommand & vbCrLf & " and CHARINDEX('/',dr.book_no) = 0"
        strcommand = strcommand & vbCrLf & strwc
        strcommand = strcommand & vbCrLf & "group by o.id,o.first_name, o.officer_level"
        strcommand = strcommand & vbCrLf & "order by o.officer_level desc"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function RetreiveOwnerbytitle() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If strhavefinishdate = "Y" Then
            strwc = strwc & vbCrLf & " and dr.expect_finish_date is not null "
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
        End If

        strcommand = " select gt.id group_title_id, gt.group_title_name, o.id officer_id_approve,COUNT(dr.id) as countdoc "
        strcommand = strcommand & vbCrLf & "from DOCUMENT_REGISTER dr "
        strcommand = strcommand & vbCrLf & " inner join GROUP_TITLE gt on gt.id=dr.group_title_id"
        strcommand = strcommand & vbCrLf & " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id and ir.id=(select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        strcommand = strcommand & vbCrLf & " inner join OFFICER o on ir.receiver_officer_username=o.username"
        strcommand = strcommand & vbCrLf & " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        strcommand = strcommand & vbCrLf & " and CHARINDEX('/',dr.book_no) = 0"
        strcommand = strcommand & vbCrLf & strwc
        strcommand = strcommand & vbCrLf & "group by gt.id, gt.group_title_name, o.id"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function

    Public Function RetreiveSectorbyemp() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If fromdate.Length > 0 Then
            strwc = strwc & vbCrLf & " and convert(varchar(8), dr.register_date,112)<='" & fromdate & "'"
        End If
        If OrgID.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'"
        End If
        If officer_id_possess.Length > 0 Then
            strwc = strwc & vbCrLf & " and dr.officer_id_approve  =" & officer_id_possess
        End If

        strcommand += " select dr.id document_register_id, dr.book_no, dr.organization_appname, gt.group_title_name,  "
        strcommand += " dr.register_date,dr.expect_finish_date, dr.close_date, dr.company_name, dr.title_name,"
        strcommand += " dr.organization_abbname_process, dr.officer_name_possess,"
        strcommand += " dr.officer_name, dr.remarks, dr.group_title_id, ir.organization_appname_send,ir.organization_appname_receive"
        strcommand += " from DOCUMENT_REGISTER dr  "
        strcommand += " inner join GROUP_TITLE gt on dr.group_title_id=gt.id "
        strcommand += " inner join document_int_receiver ir on ir.document_register_id=dr.id and ir.id=(select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        strcommand += " where dr.doc_status_id = '" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobRemain & "' "
        strcommand += " and dr.expect_finish_date Is Not null  "
        strcommand += " and CHARINDEX('/',dr.book_no) = 0 "
        strcommand += strwc
        strcommand += " order by gt.group_title_name, dr.register_date, dr.book_no"

        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function RetreiveGroupTitle() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If register_date.Length > 0 Then
            If strwc.Length = 0 Then
                strwc = strwc & vbCrLf & " where register_date<='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            Else

                strwc = strwc & vbCrLf & " and register_date<='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            End If
        End If
        If doc_status_id.Length > 0 Then
            If strwc.Length = 0 Then
                strwc = strwc & vbCrLf & " where doc_status_id='" & doc_status_id & "'"
            Else

                strwc = strwc & vbCrLf & " and doc_status_id='" & doc_status_id & "'"
            End If
        End If

        strcommand = " select group_title_name"
        strcommand = strcommand & vbCrLf & "from  DOCUMENT_REGISTER inner join GROUP_TITLE "
        strcommand = strcommand & vbCrLf & "on DOCUMENT_REGISTER.group_title_id=group_title.id" & strwc
        strcommand = strcommand & vbCrLf & "group by group_title_name"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt


    End Function
    Public Function RetreiveDoccattype() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If doc_cat_type_name.Length > 0 Then
            strwc = " where doc_cat_type_name='" & doc_cat_type_name & "'"
        End If

        strcommand = " select id,doc_cat_type_name from DOC_CAT_TYPE" & strwc
        strcommand = strcommand & vbCrLf & "group by id,doc_cat_type_name "
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    Public Function RetreiveGroupTitleOrderCode() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim strcommand As String = String.Empty
        Dim strwc As String = String.Empty

        If fromdate.Length > 0 Then
            If strwc.Length = 0 Then
                strwc = strwc & vbCrLf & " where register_date>='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            Else

                strwc = strwc & vbCrLf & " and register_date>='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            End If
        End If

        If todt.Length > 0 Then
            If strwc.Length = 0 Then
                strwc = strwc & vbCrLf & " where register_date<='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            Else

                strwc = strwc & vbCrLf & " and register_date<='" & Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) & "'"
            End If
        End If
        If doc_status_id.Length > 0 Then
            If strwc.Length = 0 Then
                strwc = strwc & vbCrLf & " where doc_status_id='" & doc_status_id & "'"
            Else

                strwc = strwc & vbCrLf & " and doc_status_id='" & doc_status_id & "'"
            End If
        End If

        strcommand = " select  GROUP_TITLE.group_title_code ,GROUP_TITLE.group_title_name "
        strcommand = strcommand & vbCrLf & "from  GROUP_TITLE  inner join DOCUMENT_REGISTER"
        strcommand = strcommand & vbCrLf & "on GROUP_TITLE.id=DOCUMENT_REGISTER.group_title_id" & strwc
        strcommand = strcommand & vbCrLf & "order by GROUP_TITLE.group_title_code"
        dt = SqlDB.GetDataTable(strcommand)
        SqlDB = Nothing
        Return dt

    End Function
    'Public Function RetreiveKPIByEMP() As DataTable
    '    Dim SqlDB As New cls_SqlDB
    '    Dim dt As New DataTable
    '    Dim sql As String = String.Empty
    '    Dim strwc As String = String.Empty

    '    If strofficer_id_approve.Trim <> "" Then
    '        strwc += " and dr.officer_id_approve='" & strofficer_id_approve & "'" & vbNewLine
    '    End If
    '    If OrgID.Length > 0 Then
    '        strwc = strwc & vbCrLf & " and dr.organization_id_owner ='" & OrgID & "'" & vbNewLine
    '    End If
    '    If havefinishdate = "Y" Then
    '        strwc = strwc & vbCrLf & " and dr.expect_finish_date  is not null" & vbNewLine
    '    End If

    '    strwc += " and convert(varchar(8),dr.register_date,112) between '20010101' and '" & todt & "'" & vbNewLine
    '    'strwc += " and (dr.close_date is null or CONVERT(varchar(8),dr.close_date,112)>='" & fromdate & "') " & vbNewLine
    '    strwc += " and CHARINDEX('/',dr.book_no) = 0" & vbNewLine


    '    sql += " select a.group_title_id, a.group_title_name, a.income, sum(a.remain_over) remain_over,sum(a.remain_notover) remain_notover, sum(a.out_over) out_over, sum(a.out_notover) out_notover, " & vbNewLine
    '    sql += " sum(a.remain_tot_over) remain_tot_over, sum(a.remain_tot_notover) remain_tot_notover,"
    '    sql += " a.max_proc_period, sum(a.workday-a.holiday) sumworkday, a.doc_cat_type_name, " & vbNewLine
    '    sql += " MAX(a.workday-a.holiday) kpi_max, MIN(a.workday-a.holiday) kpi_min" & vbNewLine
    '    sql += " from (" & vbNewLine

    '    sql += " select dr.group_title_id, gt.group_title_code, gt.group_title_name," & vbNewLine
    '    sql += " 	(select COUNT(ddr.id) " & vbNewLine
    '    sql += " 	from DOCUMENT_REGISTER ddr " & vbNewLine
    '    sql += " 	where CONVERT(varchar(8),ddr.register_date,112) between '" & fromdate & "' and '" & todt & "'" & vbNewLine
    '    sql += " 	and ddr.group_title_id=dr.group_title_id" & vbNewLine
    '    sql += " 	and ddr.organization_id_owner=dr.organization_id_owner " & vbNewLine
    '    'sql += "    and (ddr.close_date is null or CONVERT(varchar(8),ddr.close_date,112)>='" & fromdate & "') "
    '    sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
    '    sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "")& vbNewLine
    '    sql += "    and CHARINDEX('/',ddr.book_no) = 0) income," & vbNewLine
    '    'เรื่องค้างสะสม
    '    sql += "    (case when CONVERT(varchar(8),dr.register_date,112) < '" & fromdate & "' " & vbNewLine
    '    sql += "    then case when  dr.close_date is null  or CONVERT(varchar(8),dr.close_date,112)>='" & fromdate & "' " & vbNewLine
    '    sql += "    	then case when (CONVERT(varchar(8),dr.expect_finish_date,112) < CONVERT(varchar(8),dr.close_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) > '" & todt & "')) then 1 else 0 end" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "        end" & vbNewLine
    '    sql += "    else 0" & vbNewLine
    '    sql += "    end) remain_over," & vbNewLine
    '    sql += "    (case when CONVERT(varchar(8),dr.register_date,112) < '" & fromdate & "' " & vbNewLine
    '    sql += "    	then case when dr.close_date is null  or CONVERT(varchar(8),dr.close_date,112)>='" & fromdate & "' " & vbNewLine
    '    sql += "    	then case when (CONVERT(varchar(8),dr.expect_finish_date,112) >= CONVERT(varchar(8),dr.close_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) <= '" & todt & "')) then 1 else 0 end" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "        end" & vbNewLine
    '    sql += "    else 0" & vbNewLine
    '    sql += "    end) remain_notover," & vbNewLine
    '    'เรื่องออก
    '    sql += "    (case when convert(varchar(8),dr.close_date,112) between '" & fromdate & "' and '" & todt & "' " & vbNewLine
    '    sql += "    	then case when convert(varchar(8),dr.close_date,112) > convert(varchar(8),dr.expect_finish_date,112) then 1 else 0 end" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "    end) out_over," & vbNewLine
    '    sql += "    (case when convert(varchar(8),dr.close_date,112) between '" & fromdate & "' and '" & todt & "' " & vbNewLine
    '    sql += "    	then case when convert(varchar(8),dr.close_date,112) <= convert(varchar(8),dr.expect_finish_date,112) then 1 else 0 end" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "    end) out_notover," & vbNewLine
    '    'เรื่องค้างคงเหลือ
    '    sql += "    (case when dr.close_date is null or convert(varchar(8),dr.close_date,112) > '" & todt & "' " & vbNewLine
    '    sql += "        then case when (convert(varchar(8),dr.close_date,112) > convert(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) > '" & todt & "'))  then 1 else 0 end" & vbNewLine
    '    sql += "        else 0 " & vbNewLine
    '    sql += "    end) remain_tot_over," & vbNewLine
    '    sql += "    (case when dr.close_date is null or convert(varchar(8),dr.close_date,112) > '" & todt & "' " & vbNewLine
    '    sql += "    	then case when (convert(varchar(8),dr.close_date,112) > convert(varchar(8),dr.expect_finish_date,112) or (dr.close_date is null and CONVERT(varchar(8),dr.expect_finish_date,112) <= '" & todt & "'))  then 1 else 0 end" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "    end) remain_tot_notover," & vbNewLine
    '    sql += "    (case when convert(varchar(8),dr.close_date,112) between '" & fromdate & "' and '" & todt & "'  " & vbNewLine
    '    sql += "        then DATEDIFF(day,dr.register_date,dr.close_date)" & vbNewLine
    '    sql += "        else 0 " & vbNewLine
    '    sql += "    end) workday," & vbNewLine
    '    sql += "    (case when convert(varchar(8),dr.close_date,112) between '" & fromdate & "' and '" & todt & "'  " & vbNewLine
    '    sql += "    	then (select COUNT(isnull(id,0)) from HOLIDAY " & vbNewLine
    '    sql += "    		where convert(varchar(8),holiday_date,112) between convert(varchar(8),dr.register_date,112) and convert(varchar(8),dr.close_date,112))" & vbNewLine
    '    sql += "    	else 0 " & vbNewLine
    '    sql += "    end) holiday," & vbNewLine
    '    sql += " gt.max_proc_period, ct.doc_cat_type_name " & vbNewLine
    '    sql += " from DOCUMENT_REGISTER dr" & vbNewLine
    '    sql += " inner join GROUP_TITLE gt on gt.id=dr.group_title_id" & vbNewLine
    '    sql += " inner join doc_cat_type ct on ct.id=gt.group_title_type_id"
    '    sql += " where 1=1 " & strwc & vbNewLine
    '    sql += ") a"
    '    sql += " group by a.group_title_id, a.group_title_name, a.income, a.max_proc_period, a.doc_cat_type_name, a.group_title_code"
    '    sql += " order by convert(float, a.group_title_code)"

    '    dt = SqlDB.GetDataTable(sql)
    '    SqlDB = Nothing
    '    Return dt

    'End Function


    Public Function RetreiveKPIByEMP() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = String.Empty
        sql += " select g.id group_title_id,g.group_title_code, g.group_title_name,g.max_proc_period, isnull(ct.doc_cat_type_name,'') doc_cat_type_name," & vbNewLine
        'งานเข้า
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.register_date,112) between '" & fromdate & "' and '" & todt & "'" & vbNewLine
        sql += " 	and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "' " & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) income," & vbNewLine
        'งานค้างสะสมเกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where (convert(varchar(8),ddr.close_date,112) >= '" & fromdate & "' or ddr.close_date is null) "
        sql += "    and ((CONVERT(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "') and (CONVERT(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112)) "
        sql += "        or (CONVERT(varchar(8),ddr.close_date,112) > '" & todt & "' and CONVERT(varchar(8),ddr.expect_finish_date,112) < '" & todt & "')"
        sql += "        or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112) < '" & todt & "'))  " & vbNewLine
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and convert(varchar(8),ddr.register_date,112) < '" & fromdate & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_over," & vbNewLine
        'งานค้างสะสมไม่เกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where (convert(varchar(8),ddr.close_date,112) >= '" & fromdate & "' or ddr.close_date is null) "
        If havefinishdate = "Y" Then
            sql += "    and ((CONVERT(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "') and (CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)) "
            sql += "        or (CONVERT(varchar(8),ddr.close_date,112) > '" & todt & "' and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & todt & "') " & vbNewLine
            sql += "        or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & todt & "')) "
        Else
            sql += "    and ((CONVERT(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "') and (CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)) "
            sql += "        or (CONVERT(varchar(8),ddr.close_date,112) > '" & todt & "' and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & todt & "') " & vbNewLine
            sql += "        or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & todt & "') "
            sql += "        or ddr.expect_finish_date is null)"
        End If
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and convert(varchar(8),ddr.register_date,112) < '" & fromdate & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_notover," & vbNewLine
        'เรื่องออกเกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'" & vbNewLine
        sql += " 	and CONVERT(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112)" & vbNewLine
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & todt & "'"
        sql += "    and ddr.doc_status_id='" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) out_over," & vbNewLine
        'เรื่องออกไม่เกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'" & vbNewLine
        If havefinishdate = "Y" Then
            sql += " 	and CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)" & vbNewLine
        Else
            sql += " 	and (CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)" & vbNewLine
            sql += "    or ddr.expect_finish_date is null)"
        End If
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & todt & "'"
        sql += "    and ddr.doc_status_id='" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) out_notover," & vbNewLine
        'งานค้างคงเหลือเกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += "    where (convert(varchar(8),ddr.close_date,112) > '" & todt & "' or ddr.close_date is null) " & vbNewLine
        sql += " 	and (convert(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112) or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112)<'" & todt & "')) " & vbNewLine
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & todt & "'"
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_tot_over," & vbNewLine
        'งานค้างคงเหลือไม่เกินกำหนด
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += "    where (convert(varchar(8),ddr.close_date,112) > '" & todt & "' or ddr.close_date is null) " & vbNewLine
        If havefinishdate = "Y" Then
            sql += " 	and (convert(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112) or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112)>='" & todt & "')) " & vbNewLine
        Else
            sql += " 	and ((convert(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112) or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112)>='" & todt & "')) " & vbNewLine
            sql += "    or ddr.expect_finish_date is null)"
        End If
        sql += "    and ddr.group_title_id=g.id" & vbNewLine
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & todt & "'"
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_tot_notover," & vbNewLine
        'SUMWORKDAY
        sql += "    (select sum(DATEDIFF(day,ddr.register_date,ddr.close_date) - dbo.FN_getHoliday(convert(varchar(8),ddr.register_date,112), convert(varchar(8),ddr.close_date,112)))" & vbNewLine
        sql += "    from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += "    where convert(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'"
        sql += "    and ddr.group_title_id=g.id"
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) sumworkday," & vbNewLine
        'KPI
        sql += "    (select sum(DATEDIFF(day,ddr.register_date,ddr.close_date))" & vbNewLine
        sql += "    from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += "    where convert(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'"
        sql += "    and ddr.group_title_id=g.id"
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) workday," & vbNewLine
        sql += "    (select sum(dbo.FN_getHoliday(convert(varchar(8),ddr.register_date,112), convert(varchar(8),ddr.close_date,112)))" & vbNewLine
        sql += "    from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += "    where convert(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'"
        sql += "    and ddr.group_title_id=g.id"
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) holiday," & vbNewLine
        'KPI MAX
        sql += "    (select max(DATEDIFF(day,ddr.register_date,ddr.close_date) - dbo.FN_getHoliday(convert(varchar(8),ddr.register_date,112), convert(varchar(8),ddr.close_date,112)))" & vbNewLine
        sql += "    from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += "    where convert(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'"
        sql += "    and ddr.group_title_id=g.id"
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) kpi_max," & vbNewLine
        'KPI MIN
        sql += "    (select min(DATEDIFF(day,ddr.register_date,ddr.close_date) - dbo.FN_getHoliday(convert(varchar(8),ddr.register_date,112), convert(varchar(8),ddr.close_date,112)))" & vbNewLine
        sql += "    from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += "    where convert(varchar(8),ddr.close_date,112) between '" & fromdate & "' and '" & todt & "'"
        sql += "    and ddr.group_title_id=g.id"
        sql += " 	and ddr.organization_id_owner='" & OrgID & "'" & vbNewLine
        sql += IIf(havefinishdate = "Y", " and ddr.expect_finish_date is not null", "")
        sql += IIf(strofficer_id_approve.Trim <> "", " and ddr.officer_id_approve = '" & strofficer_id_approve & "'", "") & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) kpi_min" & vbNewLine
        sql += " from group_title g" & vbNewLine
        sql += " left join doc_cat_type ct on ct.id=g.group_title_type_id " & vbNewLine
        sql += " where g.group_title_name is not null"
        sql += " order by convert(float, g.group_title_code)"

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt

    End Function

    Public Function GetDocCatType(ByVal DateFrom As String, ByVal DateTo As String) As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable

        Dim sql As String = ""
        sql += " select gt.id, gt.group_type_name "
        sql += " from kpi_all_group_type gt"
        'sql += " inner join kpi_all_group_title gti on gti.kpi_all_group_type_id=gt.id"
        'sql += " inner join document_register dr on dr.group_title_id=gti.group_title_id"
        'sql += " where convert(varchar(8),dr.register_date,112) between '" & DateFrom & "' and '" & DateTo & "'"
        'sql += " and dr.organization_id_owner in (3,4,5,6) and CHARINDEX('/',dr.book_no) = 0 "
        'sql += " group by gt.id, gt.group_type_name,gt.order_seq"
        sql += " order by gt.order_seq"

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function RetriveKPIAll(ByVal DateFrom As String, ByVal DateTo As String, ByVal DocCatTyptID As Long) As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " select o.id, o.name_abb, " & vbNewLine
        'จำนวนเจ้าหน้าที่
        sql += "    (select COUNT(distinct ddr.officer_id_approve) "
        sql += "    from DOCUMENT_REGISTER ddr"
        sql += " 	where (CONVERT(varchar(8),ddr.register_date,112) between '" & DateFrom & "' and '" & DateTo & "'" & vbNewLine
        sql += "    or (convert(varchar(8),ddr.register_date,112) < '" & DateFrom & "' and (convert(varchar(8),ddr.close_date,112) >= '" & DateFrom & "' or ddr.close_date is null)))"
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and ddr.doc_status_id='" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) count_officer, " & vbNewLine
        'งานเข้า
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from DOCUMENT_REGISTER ddr" & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.register_date,112) between '" & DateFrom & "' and '" & DateTo & "'" & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and ddr.expect_finish_date is not null"
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) income," & vbNewLine
        'งานค้างสะสม
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where (convert(varchar(8),ddr.close_date,112) >= '" & DateFrom & "' or ddr.close_date is null) " & vbNewLine
        sql += "    and ((CONVERT(varchar(8),ddr.close_date,112) between '" & DateFrom & "' and '" & DateTo & "') and (CONVERT(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112)) " & vbNewLine
        sql += "        or (CONVERT(varchar(8),ddr.close_date,112) > '" & DateTo & "' and CONVERT(varchar(8),ddr.expect_finish_date,112) < '" & DateTo & "')" & vbNewLine
        sql += "        or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112) < '" & DateTo & "'))  " & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and convert(varchar(8),ddr.register_date,112) < '" & DateFrom & "'" & vbNewLine
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_over," & vbNewLine
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where (convert(varchar(8),ddr.close_date,112) >= '" & DateFrom & "' or ddr.close_date is null) " & vbNewLine
        sql += "    and ((CONVERT(varchar(8),ddr.close_date,112) between '" & DateFrom & "' and '" & DateTo & "') and (CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)) " & vbNewLine
        sql += "        or (CONVERT(varchar(8),ddr.close_date,112) > '" & DateTo & "' and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & DateTo & "') " & vbNewLine
        sql += "        or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112) >= '" & DateTo & "')) " & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and convert(varchar(8),ddr.register_date,112) < '" & DateFrom & "'" & vbNewLine
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_notover," & vbNewLine
        'งานออก
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.close_date,112) between '" & DateFrom & "' and '" & DateTo & "'" & vbNewLine
        sql += " 	and CONVERT(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112)" & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & DateTo & "'"
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and ddr.doc_status_id='" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) out_over," & vbNewLine
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += " 	where CONVERT(varchar(8),ddr.close_date,112) between '" & DateFrom & "' and '" & DateTo & "'" & vbNewLine
        sql += " 	and CONVERT(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112)" & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & DateTo & "'"
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and ddr.doc_status_id='" & Para.Common.Utilities.Constant.DocumentRegister.DocStatusID.JobClose & "'"
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) out_notover," & vbNewLine
        ''งานค้างคงเหลือ
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += "    where (convert(varchar(8),ddr.close_date,112) > '" & DateTo & "' or ddr.close_date is null) " & vbNewLine
        sql += " 	and (convert(varchar(8),ddr.close_date,112) > CONVERT(varchar(8),ddr.expect_finish_date,112) or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112)<'" & DateTo & "')) " & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & DateTo & "'"
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_tot_over," & vbNewLine
        sql += " 	(select COUNT(ddr.id) " & vbNewLine
        sql += " 	from  DOCUMENT_REGISTER ddr " & vbNewLine
        sql += "    where (convert(varchar(8),ddr.close_date,112) > '" & DateTo & "' or ddr.close_date is null) " & vbNewLine
        sql += " 	and (convert(varchar(8),ddr.close_date,112) <= CONVERT(varchar(8),ddr.expect_finish_date,112) or (ddr.close_date is null and CONVERT(varchar(8),ddr.expect_finish_date,112)>='" & DateTo & "')) " & vbNewLine
        sql += "    and ddr.group_title_id in (select group_title_id from kpi_all_group_title where kpi_all_group_type_id = '" & DocCatTyptID & "')" & vbNewLine
        sql += " 	and ddr.organization_id_owner=o.id" & vbNewLine
        sql += "    and CONVERT(varchar(8),ddr.register_date,112) <= '" & DateTo & "'"
        sql += "    and ddr.expect_finish_date is not null" & vbNewLine
        sql += "    and CHARINDEX('/',ddr.book_no) = 0) remain_tot_notover" & vbNewLine
        sql += " from ORGANIZATION o" & vbNewLine
        sql += " where o.id in (3,4,5,6)" & vbNewLine
        sql += " group by o.id, o.name_abb" & vbNewLine
        sql += " order by o.name_abb "
        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function GetGroupTitleRequest() As DataTable
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " select gt.id, gt.group_type_name, g.group_title_name"
        sql += " from KPI_ALL_GROUP_TYPE gt"
        sql += " inner join KPI_ALL_GROUP_TITLE gtt on gt.id=gtt.kpi_all_group_type_id"
        sql += " inner join GROUP_TITLE g on g.id=gtt.group_title_id"
        sql += " where gt.id in (5,6,7,8,9)"
        sql += " order by gt.order_seq"

        dt = SqlDB.GetDataTable(Sql)
        SqlDB = Nothing
        Return dt
    End Function

    Public Function RetreiveWorkLoad(ByVal OrgID As Long, ByVal DateFrom As DateTime, ByVal DateTo As DateTime, ByVal repType As String) As DataTable
        Dim StartDate As String = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim EndDate As String = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable
        Dim sql As String = ""
        sql += " select o.id officer_id, o.officer_level,dr.officer_name ," & vbNewLine
        sql += " gt.group_title_type_id,SUBSTRING(dc.doc_cat_type_name,4, LEN(dc.doc_cat_type_name)) doc_cat_type_name , gt.std_proc_period, COUNT(dr.id) count_doc" & vbNewLine
        sql += " from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " inner join GROUP_TITLE gt on dr.group_title_id=gt.id" & vbNewLine
        sql += " inner join DOC_CAT_TYPE dc on gt.group_title_type_id=dc.id" & vbNewLine
        sql += " inner join OFFICER o on dr.officer_id_approve=o.id" & vbNewLine
        sql += " inner join DOCUMENT_INT_RECEIVER ir on ir.document_register_id=dr.id and ir.id=(select top 1 id from document_int_receiver where document_register_id=dr.id order by send_date desc)"
        sql += " where dr.organization_id_owner='" & OrgID & "' "
        If repType = "0" Then 'เรื่องเข้า
            sql += " and CONVERT(varchar(8),dr.register_date,112) between '" & StartDate & "' and '" & EndDate & "'"
        ElseIf repType = "1" Then  'เรื่องออก
            sql += " and CONVERT(varchar(8),dr.close_date,112) between '" & StartDate & "' and '" & EndDate & "'"
        ElseIf repType = "2" Then  'เรื่องถือครองในช่วงเวลาที่เลือก
            sql += " and CONVERT(varchar(8),ir.receive_date,112) between '" & StartDate & "' and '" & EndDate & "'"
        End If
        sql += " and dr.expect_finish_date is not null"
        sql += " and CHARINDEX('/',dr.book_no) = 0 "
        sql += " group by o.id,o.officer_level,dr.officer_name ,gt.group_title_type_id,dc.doc_cat_type_name,SUBSTRING(dc.doc_cat_type_name,4, LEN(dc.doc_cat_type_name)), gt.std_proc_period" & vbNewLine
        sql += " order by dc.doc_cat_type_name, gt.std_proc_period, o.officer_level"

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("officer_level_show")
            For i As Integer = 0 To dt.Rows.Count - 1
                If Convert.IsDBNull(dt.Rows(i)("officer_level")) = False Then
                    dt.Rows(i)("officer_level_show") = GetOfficerLevel(dt.Rows(i)("officer_level"))
                Else
                    dt.Rows(i)("officer_level_show") = ""
                End If
                If dt.Rows(i)("officer_level_show").ToString.Trim = "" Then
                    dt.Rows(i)("officer_level") = ""
                End If
            Next
        End If
        Return dt

    End Function

    Private Function GetOfficerLevel(ByVal vOfficerLevel As String) As String
        'Sql += " case officer_level "
        'Sql += " when 'T' then '-2' "
        'Sql += " when 'A' then '-2' "
        'Sql += " when 'S' then '-2' "
        'Sql += " when 'R' then '-2' "
        'Sql += " when 'C' then '-2' "
        'Sql += " when 'M' then '-2' "
        'Sql += " when null then '-3' "
        'Sql += " when '' then '-3' "

        Dim ret As String = ""
        Select Case vOfficerLevel
            Case "T", "A", "S", "R", "C", "M"
                ret = ""
            Case "1", "2", "3", "4", "5"
                ret = "ปก."
            Case "6", "7"
                ret = "ชก."
            Case "8"
                ret = "ชพ."
            Case "9"
                ret = "ชช."
            Case Else
                ret = ""
        End Select

        Return ret
    End Function

    'Public Function GetWorkLoadHeader(ByVal OrgID As Long, ByVal DateFrom As DateTime, ByVal DateTo As DateTime) As DataTable
    '    Dim StartDate As String = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
    '    Dim EndDate As String = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
    '    Dim SqlDB As New cls_SqlDB
    '    Dim dt As New DataTable
    '    Dim sql As String = ""
    '    sql += " select ct.doc_cat_type_name, gt.std_proc_period"
    '    sql += " from GROUP_TITLE gt"
    '    sql += " inner join DOC_CAT_TYPE ct on ct.id=gt.group_title_type_id"
    '    sql += " inner join DOCUMENT_REGISTER dr on dr.group_title_id=gt.id"
    '    sql += " where CONVERT(varchar(8),dr.register_date,112) between '" & StartDate & "' and '" & EndDate & "'"
    '    sql += " and dr.organization_id_owner= '" & OrgID & "' "
    '    sql += " group by ct.doc_cat_type_name, gt.std_proc_period "

    '    dt = SqlDB.GetDataTable(sql)
    '    SqlDB = Nothing
    '    Return dt
    'End Function


    Public Function GetTimeFrame(ByVal DateFrom As DateTime, ByVal DateTo As DateTime) As String
        Dim trans As New Linq.Common.Utilities.TransactionDB
        trans.CreateTransaction()

        Dim vDateFrom As String = DateFrom.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim vDateTo As String = DateTo.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim lnq As New Linq.TABLE.HolidayLinq
        Dim dt As DataTable = lnq.GetDataList("convert(varchar(8),holiday_date,112) between '" & vDateFrom & "' and '" & vDateTo & "'", "", trans.Trans)
        trans.CommitTransaction()
        lnq = Nothing
        Dim ret As Int16 = DateDiff(DateInterval.Day, DateFrom, DateTo) - dt.Rows.Count

        Return ret.ToString
    End Function

    Public Function GetDataStorage(ByVal StOrgID As String, ByVal DateFrom As String, ByVal DateTo As String) As DataTable
        Dim sql As String = ""
        sql += " select o.id, o.name_abb, " & vbNewLine
        sql += "    (select count(dr.id)" & vbNewLine
        sql += " 	from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " 	where dr.id in " & vbNewLine
        sql += " 		(select ir.document_register_id" & vbNewLine
        sql += " 		from DOCUMENT_INT_RECEIVER ir" & vbNewLine
        sql += "        where ir.organization_id_send = o.id " & vbNewLine
        sql += "        and ir.organization_id_receive = '" & StOrgID & "'" & vbNewLine
        sql += " 		and convert(varchar(8),ir.receive_date,112) between '" & DateFrom & "' AND '" & DateTo & "')" & vbNewLine
        sql += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id=1)) recheck," & vbNewLine
        sql += " 	(select count(dr.id)" & vbNewLine
        sql += " 	from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " 	where dr.id in " & vbNewLine
        sql += " 		(select ir.document_register_id" & vbNewLine
        sql += " 		from DOCUMENT_INT_RECEIVER ir" & vbNewLine
        sql += "        where ir.organization_id_send = o.id " & vbNewLine
        sql += "        and ir.organization_id_receive = '" & StOrgID & "'" & vbNewLine
        sql += " 		and convert(varchar(8),ir.receive_date,112) between '" & DateFrom & "' AND '" & DateTo & "')" & vbNewLine
        sql += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id=2)) machine," & vbNewLine
        sql += " 	(select count(dr.id)" & vbNewLine
        sql += " 	from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " 	where dr.id in " & vbNewLine
        sql += " 		(select ir.document_register_id" & vbNewLine
        sql += " 		from DOCUMENT_INT_RECEIVER ir" & vbNewLine
        sql += "        where ir.organization_id_send = o.id " & vbNewLine
        sql += "        and ir.organization_id_receive = '" & StOrgID & "'" & vbNewLine
        sql += " 		and convert(varchar(8),ir.receive_date,112) between '" & DateFrom & "' AND '" & DateTo & "')" & vbNewLine
        sql += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id=3)) material," & vbNewLine
        sql += " 	(select count(dr.id)" & vbNewLine
        sql += " 	from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " 	where dr.id in " & vbNewLine
        sql += " 		(select ir.document_register_id" & vbNewLine
        sql += " 		from DOCUMENT_INT_RECEIVER ir" & vbNewLine
        sql += "        where ir.organization_id_send = o.id " & vbNewLine
        sql += "        and ir.organization_id_receive = '" & StOrgID & "'" & vbNewLine
        sql += " 		and convert(varchar(8),ir.receive_date,112) between '" & DateFrom & "' AND '" & DateTo & "')" & vbNewLine
        sql += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id=4)) stock," & vbNewLine
        sql += " 	(select count(dr.id)" & vbNewLine
        sql += " 	from DOCUMENT_REGISTER dr" & vbNewLine
        sql += " 	where dr.id in " & vbNewLine
        sql += " 		(select ir.document_register_id" & vbNewLine
        sql += " 		from DOCUMENT_INT_RECEIVER ir" & vbNewLine
        sql += "        where ir.organization_id_send = o.id " & vbNewLine
        sql += "        and ir.organization_id_receive = '" & StOrgID & "'" & vbNewLine
        sql += " 		and convert(varchar(8),ir.receive_date,112) between '" & DateFrom & "' AND '" & DateTo & "')" & vbNewLine
        sql += " 	and dr.group_title_id in (select group_title_id from send_storage_group_title where send_storage_group_type_id=5)) land" & vbNewLine
        sql += " from ORGANIZATION o" & vbNewLine
        sql += " where o.id in (3,4,5,6) " & vbNewLine
        sql += " order by o.name_abb" & vbNewLine

        Dim SqlDB As New cls_SqlDB
        Dim dt As New DataTable

        dt = SqlDB.GetDataTable(sql)
        SqlDB = Nothing
        Return dt
    End Function
End Class
