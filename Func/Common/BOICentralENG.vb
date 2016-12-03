Imports Linq.Common.Utilities
Namespace Common
    Public Class BOICentralENG
        Public Shared Function GetOfficerByUserID(ByVal UserID As String) As DataTable
            Dim sql As String = " select OFFICER.LOID, "
            sql += " SYSUSER.USERID username,"
            sql += " OFFICER.CODE officer_code,"
            sql += " OFFICER.TNAME,"
            sql += " OFFICER.TLASTNAME,"
            sql += " OFFICER.ENAME,"
            sql += " OFFICER.ELASTNAME,"
            sql += " OFFICER.[DESCRIPTION], "
            sql += " ORGANIZATION.LOID AS ORGANIZATION_D,  "
            sql += " OFFICER.GENDER,"
            sql += " OFFICER.BIRTHDATE,"
            sql += " OFFICER.EFDATE,"
            sql += " OFFICER.EPDATE,"
            sql += " OFFICER.OFFICERLEVEL,"
            sql += " OFFICER.IDENTITYCARD,"
            sql += " OFFICER.TEL,"
            sql += " OFFICER.fax,"
            sql += " OFFICER.email "
            sql += " FROM OFFICER"
            sql += " INNER JOIN ORGANIZATION ON dbo.OFFICER.EXACORGANIZATION = dbo.ORGANIZATION.LOID "
            sql += " INNER JOIN TITLE ON dbo.OFFICER.TITLE = dbo.TITLE.LOID "
            sql += " INNER JOIN SYSUSER ON dbo.OFFICER.LOID = dbo.SYSUSER.OFFICER"
            sql += " WHERE SYSUSER.USERID = '" & UserID & "'"
            Dim dt As DataTable = SqlBoiCentralDB.ExecuteTable(sql)
            Return dt
        End Function

        Public Shared Function GetHolidayList(ByVal vYear As String) As DataTable
            Dim sql As String = "select CALENDARDATE, DESCRIPTION from CALENDAR where year(CALENDARDATE)='" & vYear & "' "
            Dim dt As DataTable = SqlBoiCentralDB.ExecuteTable(sql)
            Return dt
        End Function

        Public Shared Function GetCompanyList(ByVal WhText As String) As DataTable
            Dim sql As String = "select top 100 loid as id, case when ltrim(tName)='' then eName else tName end + ' (" & Para.Common.Utilities.Constant.CompanySourceType.BOICENTRAL & ")' company_name, registerid company_regis_id"
            sql += " from company "
            sql += " where ltrim(case when ltrim(tName)='' then eName else tName end)<>'' "
            sql += " and ltrim(case when ltrim(tName)='' then eName else tName end) like '" & WhText & "%' "
            'sql += " order by case when ltrim(tName)='' then eName else tName end"
            Dim dt As DataTable = SqlBoiCentralDB.ExecuteTable(sql)
            Return dt
        End Function

        Public Shared Function GetCompanyByLoid(ByVal Loid As String) As DataTable
            Dim sql As String = "select top 1 loid as id, case when ltrim(tName)='' then eName else tName end company_name"
            sql += " from company "
            sql += " where loid = '" & Loid & "' "
            Dim dt As DataTable = SqlBoiCentralDB.ExecuteTable(sql)
            Return dt
        End Function

        Public Shared Function PingServer() As Boolean
            Dim ret As Boolean = False
            If My.Computer.Network.Ping(SqlBoiCentralDB.DataSource, 1000) = True Then
                ret = True
            End If
            Return ret
        End Function
    End Class
End Namespace

