Imports Linq.TABLE
Imports Para.TABLE
Imports Linq.Common.Utilities
Namespace Master
    Public Class RolesEng
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

        Public Function GetAllRolesList() As DataTable
            Dim lnq As New RolesLinq
            Return lnq.GetDataList("1=1", "role_code", Nothing)
        End Function
        Public Function GetDataRolesList(ByVal sqlWhere As String, ByVal orderBy As String) As DataTable
            Dim lnq As New RolesLinq
            Return lnq.GetDataList(sqlWhere, orderBy, Nothing)
        End Function
        Public Function GetRolesPara(ByVal RolesID As Long) As RolesPara
            Dim lnq As New RolesLinq
            Return lnq.GetParameter(RolesID, Nothing)
        End Function

        Public Function SaveRoles(ByVal para As RolesPara, ByVal UserID As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False

            Dim lnq As New RolesLinq
            If para.ID <> 0 Then
                lnq = lnq.GetDataByPK(para.ID, trans.Trans)
            End If

            lnq.ROLE_CODE = para.ROLE_CODE
            lnq.ROLE_NAME = para.ROLE_NAME
            lnq.ACTIVE = para.ACTIVE

            If para.ID <> 0 Then
                ret = lnq.UpdateByPK(UserID, trans.Trans)
            Else
                ret = lnq.InsertData(UserID, trans.Trans)
            End If

            If ret = False Then
                _err = lnq.ErrorMessage
            End If
            _ID = lnq.ID

            Return ret

        End Function

        Public Function ChkDupByRoleCode(ByVal vID As Long, ByVal RoleCode As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New RolesLinq
            ret = lnq.ChkDuplicateByROLE_CODE(RoleCode, vID, trans.Trans)
            trans.CommitTransaction()
            If ret = True Then
                _err = "รหัสกลุ่มซ้ำ"
            End If

            Return ret
        End Function
        Public Function ChkDupByRoleName(ByVal vID As Long, ByVal RoleName As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim lnq As New RolesLinq
            ret = lnq.ChkDuplicateByROLE_NAME(RoleName, vID, trans.Trans)
            trans.CommitTransaction()
            If ret = True Then
                _err = "ชื่อกลุ่มซ้ำ"
            End If
            Return ret
        End Function

        Public Function GetOfficerNoSelectRoleList(ByVal vRoldID As Long, ByVal vOrgID As Long) As DataTable
            Dim lnq As New OfficerLinq
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim sql As String = "select o.username, o.first_name + ' ' + o.last_name staff_name, og.org_name "
            sql += " from officer o "
            sql += " inner join organization og on og.id=o.organization_id "
            sql += " where 1=1 "
            If vOrgID <> 0 Then
                sql += " and o.organization_id = '" & vOrgID & "' "
            End If
            sql += " and o.username not in (select login_username from roles_user where roles_id = '" & vRoldID & "')"
            sql += " order by og.org_name, o.first_name "

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetOfficerSelectedRoleList(ByVal vRoldID As Long) As DataTable
            Dim lnq As New OfficerLinq
            Dim dt As New DataTable
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim sql As String = "select o.username, o.first_name + ' ' + o.last_name staff_name, og.org_name "
            sql += " from officer o "
            sql += " inner join organization og on og.id=o.organization_id "
            sql += " inner join roles_user ru on ru.login_username = o.username"
            sql += " where ru.roles_id = '" & vRoldID & "' "
            sql += " order by og.org_name, o.first_name "

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function InsertRolesUser(ByVal vLoginName As String, ByVal vUserName As String, ByVal vRoleID As Long) As Boolean
            Dim lnq As New RolesUserLinq
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim oSql As String = "select o.organization_id, o.first_name + ' ' + o.last_name staff_name, og.org_name "
            oSql += " from officer o "
            oSql += " inner join organization og on og.id=o.organization_id "
            oSql += " where o.username = '" & vUserName & "'"

            Dim oLnq As New OfficerLinq
            Dim odt As New DataTable
            odt = oLnq.GetListBySql(oSql, trans.Trans)

            lnq.ROLES_ID = vRoleID
            lnq.LOGIN_USERNAME = vUserName
            If odt.Rows.Count > 0 Then
                If Convert.IsDBNull(odt.Rows(0)("organization_id")) = False Then lnq.ORGANIZATION_ID = Convert.ToInt64(odt.Rows(0)("organization_id"))
                If Convert.IsDBNull(odt.Rows(0)("staff_name")) = False Then lnq.USER_FULL_NAME = odt.Rows(0)("staff_name")
                If Convert.IsDBNull(odt.Rows(0)("org_name")) = False Then lnq.ORGANIZATION_NAME = odt.Rows(0)("org_name")
            End If

            Dim ret As Boolean = lnq.InsertData(vLoginName, trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            odt.Dispose()
            odt = Nothing
            lnq = Nothing
            oLnq = Nothing

            Return ret
        End Function

        Public Sub DeleteRoleUser(ByVal vRoleID As Long, ByVal vUserName As String)
            Dim trans As New Linq.Common.Utilities.TransactionDB
            trans.CreateTransaction()

            Dim sql As String = "delete from roles_user where roles_id='" & vRoleID & "' and login_username = '" & vUserName & "'"
            SqlDB.ExecuteNonQuery(sql, trans.Trans)
            trans.CommitTransaction()
        End Sub
    End Class
End Namespace


