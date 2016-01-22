Imports Linq.TABLE
Imports Para.TABLE
Imports System.Data

Namespace Master
    Public Class OrganizationEng
        Public Function GetAllOrganizationTable() As DataTable
            Dim lnq As New OrganizationLinq
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim dt As New DataTable
            dt = lnq.GetDataList(" getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate()) ", "org_name", Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOrgTypeList() As DataTable
            Dim lnq As New OrganizationTypeLinq
            Dim dt As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            dt = lnq.GetDataList(" 1=1 ", "", Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOrgByType(ByVal tmpID As String) As DataTable
            Dim lnq As New OrganizationLinq
            Dim dt As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim whText As String = "1=1 and expr1 is not null and getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate()) "
            If tmpID <> "" Then
                whText += " and id not in (" & tmpID & ")"
            End If
            dt = lnq.GetDataList(whText, "org_name", Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOrgBySector(ByVal SectorType As String) As DataTable
            Dim lnq As New OrganizationLinq
            Dim dt As New DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim whText As String = "type = '" & SectorType & "' and getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate()) "
            dt = lnq.GetDataList(whText, "org_name", Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetStaffByOrgID(ByVal OrgID As Long) As DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim sql As String = "select id, first_name + ' ' + last_name staff_name, "
            sql += " case officer_level "
            sql += " when 'T' then '-2' "
            sql += " when 'A' then '-2' "
            sql += " when 'S' then '-2' "
            sql += " when 'R' then '-2' "
            sql += " when 'C' then '-2' "
            sql += " when 'M' then '-2' "
            sql += " when 'B' then '-2' "
            sql += " when null then '-3' "
            sql += " when '' then '-3' "
            sql += " else officer_level "
            sql += " end officer_level"
            sql += " from officer "
            sql += " where organization_id = " & OrgID
            sql += " and getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate())"
            sql += " order by first_name, last_name"
            Dim lnq As New OfficerLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOfficerSignByOrgID(ByVal OrgID As Long) As DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim sql As String = " select o.id, o.first_name + ' ' + o.last_name officer_name,"
            sql += " convert(int,case o.officer_level "
            sql += " when 'T' then '-2' "
            sql += " when 'A' then '-2' "
            sql += " when 'S' then '-2' "
            sql += " when 'R' then '-2' "
            sql += " when 'C' then '-2' "
            sql += " when 'M' then '-2' "
            sql += " when 'B' then '-2' "
            sql += " when null then '-3' "
            sql += " when '' then '-3' "
            sql += " else officer_level "
            sql += " end) officer_level"
            sql += " from OFFICER o "
            sql += " inner join OFFICER_SIGN_ORGANIZATION os on os.officer_id=o.id"
            sql += " where os.organization_id = '" & OrgID & "' "
            sql += " and getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate())"
            sql += " order by o.first_name + ' ' + o.last_name"

            Dim lnq As New OfficerLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetStaffAdmintrationByOrgID(ByVal OrgID As Long) As DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim sql As String = "select o.id, o.first_name + ' ' + o.last_name staff_name "
            sql += " from officer o "
            sql += " inner join roles_user ru on ru.login_username=o.username"
            sql += " where o.organization_id = " & OrgID
            sql += " and ru.roles_id = '" & Para.Common.Utilities.Constant.RoleID.RoleAdministration & "'"
            sql += " and getdate() between isnull(efdate,getdate()) and isnull(epdate,getdate())"
            sql += " order by o.first_name, o.last_name"
            Dim lnq As New OfficerLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function

        Public Function GetOrgPara(ByVal vID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As OrganizationPara
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New OrganizationLinq
            Dim para As New OrganizationPara
            para = lnq.GetParameter(vID, trans.Trans)
            'trans.CommitTransaction()
            Return para
        End Function

        Public Function GetOrgPara(ByVal vID As Long) As OrganizationPara
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New OrganizationLinq
            Dim para As New OrganizationPara
            para = lnq.GetParameter(vID, Nothing)
            'trans.CommitTransaction()
            Return para
        End Function

        Public Function GetOrgParaByOrgCode(ByVal OrgCode As String) As OrganizationPara
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim lnq As New OrganizationLinq
            lnq.ChkDataByORG_CODE(OrgCode, Nothing)
            Dim para As New OrganizationPara
            para = lnq.GetParameter(lnq.ID, Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return para
        End Function

        Public Function GetOrgStorageList() As DataTable
            'Dim trans As New Linq.Common.Utilities.TransactionDB
            'trans.CreateTransaction()
            Dim whText As String = "id in "
            whText += "     (select organization_id "
            whText += "     from ORGANIZATION_STORAGE "
            whText += "     where convert(varchar(10),start_date,120)<=convert(varchar(10),getdate(),120) and convert(varchar(10),isnull(end_date,getdate()),120)>= convert(varchar(10),getdate(),120))"
            Dim lnq As New OrganizationLinq
            Dim dt As DataTable = lnq.GetDataList(whText, "", Nothing)
            'trans.CommitTransaction()
            lnq = Nothing

            Return dt
        End Function
        Public Function GetDataOrgStorageList() As DataTable
            Dim sql As String = "select organization_id,storage_abb_name "
            sql += " from ORGANIZATION_STORAGE "
            sql += " where convert(varchar(10),start_date,120)<=convert(varchar(10),getdate(),120) and convert(varchar(10),isnull(end_date,getdate()),120)>= convert(varchar(10),getdate(),120)"
            Dim lnq As New OrganizationLinq
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing

            Return dt
        End Function
        Public Function GetOrgStoragePara(ByVal vOrgID As Long, ByVal trans As Linq.Common.Utilities.TransactionDB) As Para.TABLE.OrganizationStoragePara
            Dim lnq As New Linq.TABLE.OrganizationStorageLinq
            lnq.ChkDataByORGANIZATION_ID(vOrgID, trans.Trans)

            Dim para As New Para.TABLE.OrganizationStoragePara
            para.ID = lnq.ID
            para.ORGANIZATION_ID = lnq.ORGANIZATION_ID
            para.START_DATE = lnq.START_DATE
            para.END_DATE = lnq.END_DATE
            para.STORAGE_ABB_NAME = lnq.STORAGE_ABB_NAME

            lnq = Nothing

            Return para
        End Function
    End Class
End Namespace

