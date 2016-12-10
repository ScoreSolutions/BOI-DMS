Imports Linq.TABLE
Imports Para.TABLE

Namespace Master
    Public Class GroupTitleEng

        Dim _GroupTitleID As Long = 0
        Dim _err As String = ""
        Public ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property
        Public ReadOnly Property GroupTitleID() As Long
            Get
                Return _GroupTitleID
            End Get
        End Property

        Public Function GetDataGroupTitleList(ByVal whText As String, ByVal orderBy As String) As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New GroupTitleLinq
            dt = lnq.GetDataList(whText, orderBy, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function
        Public Function WSGetGroupTitleList() As DataTable
            Dim dt As New DataTable
            Dim lnq As New GroupTitleLinq
            Dim sql As String = "select group_title_code, group_title_name "
            sql += " from group_title "
            sql += " where active='Y'"
            sql += " order by convert(float,group_title_code)"
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function
        Public Function GetGroupTitlePara(ByVal ID As Long) As GroupTitlePara
            Dim lnq As New GroupTitleLinq
            Dim para As New GroupTitlePara
            para = lnq.GetParameter(ID, Nothing)
            Return para
        End Function

        Public Function GetGroupTitlePara(ByVal ID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As GroupTitlePara
            Dim lnq As New GroupTitleLinq
            Dim para As New GroupTitlePara
            para = lnq.GetParameter(ID, trans.Trans)
            Return para
        End Function

        Public Function GetGroupTitleOrgList(ByVal vID As Long) As DataTable
            Dim sql As String = ""
            sql += " select o.id, o.organization_type_id org_sector_id, "
            sql += " case o.organization_type_id when 0 then 'SECTOR' "
            sql += " when 1 then 'NON SECTOR' "
            sql += " when 2 then 'IC' end org_group_name, "
            sql += " o.organization_id org_id, og.org_name, og.name_abb org_abb_name, o.std_proc_period std_proc, o.max_proc_period max_proc "
            sql += " from GROUP_TITLE_ORG_RESPONSE o"
            sql += " inner join ORGANIZATION og on og.id=o.organization_id "
            sql += " where o.group_title_id = '" & vID & "'"
            sql += " order by o.id"

            Dim lnq As New GroupTitleOrgResponseLinq
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetGroupTitleComList(ByVal vID As Long) As DataTable
            Dim sql As String = ""
            sql += " select c.id, c.company_id, cm.thaiName company_name, c.officer_sign_name company_sign, c.remarks"
            sql += " from GROUP_TITLE_COMPANY_DEFAULT c"
            sql += " inner join COMPANY cm on cm.id=c.company_id "
            sql += " where c.group_title_id = '" & vID & "'"
            sql += " order by c.id "

            Dim lnq As New GroupTitleCompanyDefaultLinq
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            lnq = Nothing
            Return dt
        End Function

        Public Function GetGroupTitleList(ByVal sql As String) As DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            Dim lnq As New GroupTitleLinq
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetGroupTitleDDlList() As DataTable
            Dim lnq As New DocCatTypeLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList("1=1", "", trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function ChkDupGroupTitle(ByVal vCode As String, ByVal vName As String, ByVal vID As Long) As String
            Dim ret As String = ""
            Dim lnq As New GroupTitleLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()
            If lnq.ChkDuplicateByGROUP_TITLE_CODE(vCode, vID, trans.Trans) = True Then
                ret = "รหัสกลุ่มเรื่องซ้ำ"
            ElseIf lnq.ChkDuplicateByGROUP_TITLE_NAME(vName, vID, trans.Trans) = True Then
                ret = "ชื่อกลุ่มเรื่องซ้ำ"
            End If
            Return ret
        End Function

        Public Function SaveGroupTitle(ByVal LoginName As String, ByVal gPara As Para.TABLE.GroupTitlePara, ByVal oDt As DataTable, ByVal cDt As DataTable, ByVal trans As Linq.Common.Utilities.TransactionDB) As Boolean
            Dim lnq As New Linq.TABLE.GroupTitleLinq
            If gPara.ID <> 0 Then
                lnq.GetDataByPK(gPara.ID, trans.Trans)
            End If

            lnq.GROUP_TITLE_CODE = gPara.GROUP_TITLE_CODE
            lnq.GROUP_TITLE_NAME = gPara.GROUP_TITLE_NAME
            lnq.GROUP_TITLE_TYPE_ID = gPara.GROUP_TITLE_TYPE_ID
            lnq.STD_PROC_PERIOD = gPara.STD_PROC_PERIOD
            lnq.MAX_PROC_PERIOD = gPara.MAX_PROC_PERIOD
            lnq.SUBJECT_ID = gPara.SUBJECT_ID
            lnq.IS_GEN_REQ = gPara.IS_GEN_REQ
            lnq.DOC_SYS_ID = gPara.DOC_SYS_ID
            lnq.ACTIVE = gPara.ACTIVE
            lnq.NO_DEFAULT_TITLE = gPara.NO_DEFAULT_TITLE

            Dim ret As Boolean = False
            If lnq.ID <> 0 Then
                ret = lnq.UpdateByPK(LoginName, trans.Trans)
            Else
                ret = lnq.InsertData(LoginName, trans.Trans)
            End If

            If ret = True Then
                _GroupTitleID = lnq.ID
                Dim oSql As String = "delete from GROUP_TITLE_ORG_RESPONSE where group_title_id='" & lnq.ID & "'"
                Linq.Common.Utilities.SqlDB.ExecuteNonQuery(oSql, trans.Trans)
                If oDt IsNot Nothing Then
                    For Each dr As DataRow In oDt.Rows
                        Dim oLnq As New Linq.TABLE.GroupTitleOrgResponseLinq
                        oLnq.GROUP_TITLE_ID = lnq.ID
                        oLnq.ORGANIZATION_ID = Convert.ToInt64(dr("org_id"))
                        oLnq.ORGANIZATION_NAME = dr("org_name")
                        oLnq.ORGANIZATION_APPNAME = dr("org_abb_name")
                        oLnq.ORGANIZATION_TYPE_ID = Convert.ToInt64(dr("org_sector_id"))
                        oLnq.STD_PROC_PERIOD = Convert.ToDouble(dr("std_proc"))
                        oLnq.MAX_PROC_PERIOD = Convert.ToDouble(dr("max_proc"))

                        ret = oLnq.InsertData(LoginName, trans.Trans)
                        If ret = False Then
                            _err = oLnq.ErrorMessage
                            Exit For
                        End If
                    Next
                    oDt.Dispose()
                    oDt = Nothing
                End If

                Dim cSql As String = "delete from GROUP_TITLE_COMPANY_DEFAULT where group_title_id = '" & lnq.ID & "'"
                Linq.Common.Utilities.SqlDB.ExecuteNonQuery(cSql, trans.Trans)
                If cDt IsNot Nothing Then
                    For Each dr As DataRow In cDt.Rows
                        Dim cLnq As New Linq.TABLE.GroupTitleCompanyDefaultLinq
                        cLnq.GROUP_TITLE_ID = lnq.ID
                        cLnq.COMPANY_ID = Convert.ToInt64(dr("company_id"))
                        cLnq.OFFICER_SIGN_NAME = IIf(Convert.IsDBNull(dr("company_sign")) = False, dr("company_sign"), "")
                        cLnq.REMARKS = IIf(Convert.IsDBNull(dr("remarks")) = False, dr("remarks"), "")

                        ret = cLnq.InsertData(LoginName, trans.Trans)
                        If ret = False Then
                            _err = cLnq.ErrorMessage
                            Exit For
                        End If
                    Next
                    cDt.Dispose()
                    cDt = Nothing
                End If
            End If
            lnq = Nothing

            Return ret
        End Function

        Public Function GetKpiAllGroupTypePara(ByVal vGroupTypeID As Long) As KpiAllGroupTypePara
            Dim lnq As New KpiAllGroupTypeLinq
            Dim p As New KpiAllGroupTypePara
            p = lnq.GetParameter(vGroupTypeID, Nothing)
            lnq = Nothing
            Return p
        End Function


    End Class
End Namespace