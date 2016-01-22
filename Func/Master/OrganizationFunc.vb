Imports Linq.TABLE
Imports Para.TABLE
Imports System.Data

Namespace Master
    Public Class OrganizationFunc
        Public Function GetAllOrganizationTable() As DataTable
            Dim lnq As New OrganizationLinq
            Return lnq.GetDataList("1=1 ", "org_name", Nothing)
        End Function

        Public Function GetStaffByOrgID(ByVal OrgID As Long) As DataTable
            Dim sql As String = "select id, first_name + ' ' + last_name staff_name "
            sql += " from officer "
            sql += " where organization_id = " & OrgID
            sql += " order by first_name"
            Dim lnq As New OfficerLinq
            Return lnq.GetListBySql(sql, Nothing)
        End Function
    End Class
End Namespace

