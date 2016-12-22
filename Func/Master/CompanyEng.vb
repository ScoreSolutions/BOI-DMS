Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class CompanyEng
        Dim _err As String = ""
        Dim _ID As Long
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property ID() As Long
            Get
                Return _ID
            End Get
        End Property
        Public Function GetAllCompanyList() As DataTable
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New CompanyLinq
            dt = lnq.GetDataList("1=1", "comID", trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function



        Public Function GetCompanyDDList(ByVal WhText As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim sql As String = " select top 10 id, case when ltrim(thaiName)='' then engName else thaiName end + ' (" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")' company_name, company_regis_no "
            sql += " from company "
            sql += " where ltrim(case when ltrim(thaiName)='' then engName else thaiName end)<>'' "
            sql += " and ltrim(case when ltrim(thaiName)='' then engName else thaiName end) like '" & WhText & "%' "
            'sql += " order by case when ltrim(thaiName)='' then engName else thaiName end"
            Dim lnq As New CompanyLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            


            ''ข้อมูลจาก WebService
            'Dim ws As New LinqWS.OneDB.CompanyInfoLinqWS
            'Dim bDt As New DataTable
            'bDt = ws.GetCompanyList(WhText, Engine.Common.FunctionENG.GetConfigValue("BCM_WS_URL"))
            'If bDt.Rows.Count > 0 Then
            '    For Each bDr As DataRow In bDt.Rows
            '        Dim dr As DataRow = dt.NewRow
            '        dr("id") = bDr("comcode")
            '        dr("company_name") = bDr("comnameth") & " (BCM)"
            '        dt.Rows.Add(dr)
            '    Next
            'End If
            'Dim dv As DataView = dt.DefaultView
            'dv.Sort = "company_name asc"
            'dt = dv.ToTable
            dt.DefaultView.Sort = "company_name"

            Return dt.DefaultView.ToTable
        End Function


        Public Function GetDataCompanyList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim lnq As New CompanyLinq
            dt = lnq.GetDataList(sqlWhere, orderBy, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetDataCompanyByCompanyRegisNo(ByVal CompanyRegisNo As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim sql As String = " select top 10 id, case when ltrim(thaiName)='' then engName else thaiName end + ' (" & Para.Common.Utilities.Constant.CompanySourceType.DMS & ")' company_name, company_regis_no "
            sql += " from company "
            sql += " where company_regis_no='" & CompanyRegisNo & "'"
            Dim lnq As New CompanyLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetCompanyPara(ByVal DocCompanyID As Long) As CompanyPara
            Dim lnq As New CompanyLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.CompanyPara
            para = lnq.GetParameter(DocCompanyID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Function GetCompanyPara(ByVal DocCompanyID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As CompanyPara
            Dim lnq As New CompanyLinq
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim para As New Para.TABLE.CompanyPara
            para = lnq.GetParameter(DocCompanyID, trans.Trans)
            'trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Function GetCompanyParaByComID(ByVal ComID As String, ByVal trans As Linq.Common.Utilities.TransactionDB) As CompanyPara
            Dim lnq As New CompanyLinq
            
            Dim para As New Para.TABLE.CompanyPara
            If lnq.ChkDataByWhere("comid='" & ComID & "'", trans.Trans) = True Then
                para = lnq.GetParameter(lnq.ID, trans.Trans)
            End If
            lnq = Nothing

            Return para
        End Function

        Public Function CheckDupCompanyRegisNo(ByVal ComRegisNo As String, ByVal CompanyID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As String
            Dim ret As String = "false"
            Dim lnq As New CompanyLinq
            lnq.ChkDataByWhere("company_regis_no = '" & ComRegisNo & "' and id<>" & CompanyID, trans.Trans)
            If lnq.ID > 0 Then
                ret = "true"
            Else
                Dim sql As String = "select "

                Dim dt As DataTable = Engine.Common.BOICentralENG.GetCompanyByRegisID(ComRegisNo)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.RowFilter = "id <> '" & CompanyID & "'"
                    If dt.DefaultView.Count > 0 Then
                        ret = "true"
                    End If
                End If
                dt.Dispose()
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Function SaveCompany(ByVal para As CompanyPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New CompanyLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.COMPANY_TYPE_ID = para.COMPANY_TYPE_ID
            lnq.COMID = para.COMID
            lnq.COMPANY_REGIS_NO = para.COMPANY_REGIS_NO
            lnq.THAINAME = para.THAINAME
            lnq.ENGNAME = para.ENGNAME
            lnq.ADDRESSID = para.ADDRESSID
            lnq.TEL = para.TEL
            lnq.FAX = para.FAX
            lnq.ZIPCODE = para.ZIPCODE
            lnq.PROVINCE_ID = para.PROVINCE_ID
            lnq.DISTRICT_ID = para.DISTRICT_ID
            lnq.ACTIVE = para.ACTIVE
            lnq.IDCARD_NO = para.IDCARD_NO
            lnq.PASSPORT_NO = para.PASSPORT_NO

            If para.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            _ID = lnq.ID
            lnq = Nothing

            Return ret

        End Function

        Public Function GetAllBusinessType() As DataTable
            Dim lnq As New Linq.TABLE.BusinessTypeLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList("1=1", "business_type_name", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetActiveBusinessType() As DataTable
            Dim lnq As New Linq.TABLE.BusinessTypeLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList("active='Y'", "business_type_name", trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Shared Function GetBusinessTypePara(ByVal vID As Long) As Para.TABLE.BusinessTypePara
            Dim lnq As New Linq.TABLE.BusinessTypeLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim para As New Para.TABLE.BusinessTypePara
            para = lnq.GetParameter(vID, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Function GetCompanyNameByOrgID(ByVal OrgID As String) As String()
            Dim ret() As String = {"", "", ""}
            Dim dt As New DataTable
            dt = GetDataCompanyList("ref_org_id = '" & OrgID & "'", "")
            If dt.Rows.Count > 0 Then
                ret(0) = dt.Rows(0)("id").ToString
                If Convert.IsDBNull(dt.Rows(0)("thaiName")) = False Then
                    If dt.Rows(0)("thaiName").ToString.Trim <> "" Then
                        ret(1) = dt.Rows(0)("thaiName").ToString
                    Else
                        ret(1) = dt.Rows(0)("engName").ToString()
                    End If
                Else
                    If Convert.IsDBNull(dt.Rows(0)("engName")) = False Then
                        ret(1) = dt.Rows(0)("engName").ToString.Trim
                    End If
                End If

                If Convert.IsDBNull(dt.Rows(0)("company_regis_no")) = False Then
                    ret(2) = dt.Rows(0)("company_regis_no")
                End If

                dt = Nothing
            End If
            Return ret
        End Function

        Public Function GetCompanyNameByTHeGIFCode(ByVal THeGifCode As String) As String()
            Dim ret() As String = {"", ""}
            Dim dt As New DataTable
            dt = GetDataCompanyList("th_egif_org_code = '" & THeGifCode & "'", "")
            If dt.Rows.Count > 0 Then
                ret(0) = dt.Rows(0)("id").ToString
                If Convert.IsDBNull(dt.Rows(0)("thaiName")) = False Then
                    If dt.Rows(0)("thaiName").ToString.Trim <> "" Then
                        ret(1) = dt.Rows(0)("thaiName").ToString
                    Else
                        ret(1) = dt.Rows(0)("engName").ToString()
                    End If
                Else
                    If Convert.IsDBNull(dt.Rows(0)("engName")) = False Then
                        ret(1) = dt.Rows(0)("engName").ToString.Trim
                    End If
                End If
                dt = Nothing
            End If
            Return ret
        End Function
    End Class
End Namespace
