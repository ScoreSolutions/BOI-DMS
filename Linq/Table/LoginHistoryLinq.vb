Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = Linq.Common.Utilities.SQLDB
Imports Para.TABLE
Imports Para.Common.Utilities

Namespace TABLE
    'Represents a transaction for LOGIN_HISTORY table Linq.
    '[Create by  on September, 6 2011]
    Public Class LoginHistoryLinq
        Public sub LoginHistoryLinq()

        End Sub 
        ' LOGIN_HISTORY
        Const _tableName As String = "LOGIN_HISTORY"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USERNAME As String = ""
        Dim _IDCARD_NO As String = ""
        Dim _STAFF_NAME As String = ""
        Dim _STAFF_POSNAME As  String  = ""
        Dim _STAFF_DIVISION_NAME As  String  = ""
        Dim _STAFF_DEPARTMENT_NAME As  String  = ""
        Dim _LOGIN_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOGOUT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IS_SSO As Char = ""
        Dim _IP_ADDRESS As String = ""
        Dim _SESSION_ID As String = ""
        Dim _BROWSER As String = ""

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_ON", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_ON() As DateTime
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As DateTime)
               _CREATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(50)")>  _
        Public Property UPDATE_BY() As  String 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  String )
               _UPDATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_ON", DbType:="DateTime2")>  _
        Public Property UPDATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_IDCARD_NO", DbType:="VarChar(13) NOT NULL ",CanBeNull:=false)>  _
        Public Property IDCARD_NO() As String
            Get
                Return _IDCARD_NO
            End Get
            Set(ByVal value As String)
               _IDCARD_NO = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property STAFF_NAME() As String
            Get
                Return _STAFF_NAME
            End Get
            Set(ByVal value As String)
               _STAFF_NAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_POSNAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_POSNAME() As  String 
            Get
                Return _STAFF_POSNAME
            End Get
            Set(ByVal value As  String )
               _STAFF_POSNAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_DIVISION_NAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_DIVISION_NAME() As  String 
            Get
                Return _STAFF_DIVISION_NAME
            End Get
            Set(ByVal value As  String )
               _STAFF_DIVISION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_DEPARTMENT_NAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_DEPARTMENT_NAME() As  String 
            Get
                Return _STAFF_DEPARTMENT_NAME
            End Get
            Set(ByVal value As  String )
               _STAFF_DEPARTMENT_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_TIME", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_TIME() As DateTime
            Get
                Return _LOGIN_TIME
            End Get
            Set(ByVal value As DateTime)
               _LOGIN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_LOGOUT_TIME", DbType:="DateTime2")>  _
        Public Property LOGOUT_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LOGOUT_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LOGOUT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_IS_SSO", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_SSO() As Char
            Get
                Return _IS_SSO
            End Get
            Set(ByVal value As Char)
               _IS_SSO = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_SESSION_ID", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SESSION_ID() As String
            Get
                Return _SESSION_ID
            End Get
            Set(ByVal value As String)
               _SESSION_ID = value
            End Set
        End Property 
        <Column(Storage:="_BROWSER", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BROWSER() As String
            Get
                Return _BROWSER
            End Get
            Set(ByVal value As String)
               _BROWSER = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _USERNAME = ""
            _IDCARD_NO = ""
            _STAFF_NAME = ""
            _STAFF_POSNAME = ""
            _STAFF_DIVISION_NAME = ""
            _STAFF_DEPARTMENT_NAME = ""
            _LOGIN_TIME = New DateTime(1,1,1)
            _LOGOUT_TIME = New DateTime(1,1,1)
            _IS_SSO = ""
            _IP_ADDRESS = ""
            _SESSION_ID = ""
            _BROWSER = ""
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into LOGIN_HISTORY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _id = DB.GetNextID("id",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_ON = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _UPDATE_BY = LoginName
                _UPDATE_ON = DateTime.Now
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from LOGIN_HISTORY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cPK As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("id = " & cPK, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As LoginHistoryLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As LoginHistoryPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(cUSERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSERNAME(cUSERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified IDCARD_NO key is retrieved successfully.
        '/// <param name=cIDCARD_NO>The IDCARD_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByIDCARD_NO(cIDCARD_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("IDCARD_NO = " & DB.SetString(cIDCARD_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified IDCARD_NO key is retrieved successfully.
        '/// <param name=cIDCARD_NO>The IDCARD_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByIDCARD_NO(cIDCARD_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("IDCARD_NO = " & DB.SetString(cIDCARD_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified STAFF_NAME key is retrieved successfully.
        '/// <param name=cSTAFF_NAME>The STAFF_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataBySTAFF_NAME(cSTAFF_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("STAFF_NAME = " & DB.SetString(cSTAFF_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified STAFF_NAME key is retrieved successfully.
        '/// <param name=cSTAFF_NAME>The STAFF_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateBySTAFF_NAME(cSTAFF_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("STAFF_NAME = " & DB.SetString(cSTAFF_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOGIN_TIME(cLOGIN_TIME As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByLOGIN_TIME(cLOGIN_TIME As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into LOGIN_HISTORY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = MessageResources.MSGEN001
                    Else
                        _haveData = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC101
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to LOGIN_HISTORY table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGEU001
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC102
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from LOGIN_HISTORY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Dim tmpWhere As String = " Where " & whText
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message
                    Catch ex As Exception
                        ex.ToString()
                        ret = False
                        _error = MessageResources.MSGEC103
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                     If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                     If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                     If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                     If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                     If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                     If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                     If Convert.IsDBNull(Rdr("idcard_no")) = False Then _idcard_no = Rdr("idcard_no").ToString()
                     If Convert.IsDBNull(Rdr("staff_name")) = False Then _staff_name = Rdr("staff_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_posname")) = False Then _staff_posname = Rdr("staff_posname").ToString()
                     If Convert.IsDBNull(Rdr("staff_division_name")) = False Then _staff_division_name = Rdr("staff_division_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_department_name")) = False Then _staff_department_name = Rdr("staff_department_name").ToString()
                     If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                     If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                     If Convert.IsDBNull(Rdr("is_sso")) = False Then _is_sso = Rdr("is_sso").ToString()
                     If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                     If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                     If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As LoginHistoryLinq
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                     If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                     If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                     If Convert.IsDBNull(Rdr("create_on")) = False Then _create_on = Convert.ToDateTime(Rdr("create_on"))
                     If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                     If Convert.IsDBNull(Rdr("update_on")) = False Then _update_on = Convert.ToDateTime(Rdr("update_on"))
                     If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                     If Convert.IsDBNull(Rdr("idcard_no")) = False Then _idcard_no = Rdr("idcard_no").ToString()
                     If Convert.IsDBNull(Rdr("staff_name")) = False Then _staff_name = Rdr("staff_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_posname")) = False Then _staff_posname = Rdr("staff_posname").ToString()
                     If Convert.IsDBNull(Rdr("staff_division_name")) = False Then _staff_division_name = Rdr("staff_division_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_department_name")) = False Then _staff_department_name = Rdr("staff_department_name").ToString()
                     If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                     If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                     If Convert.IsDBNull(Rdr("is_sso")) = False Then _is_sso = Rdr("is_sso").ToString()
                     If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                     If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                     If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()

                    'Generate Item For Child Table
                    'Child Table Name : LOG_ERROR Column :login_his_id
                    Dim LogError_login_his_idItem As New LogErrorLinq
                    _LOG_ERROR_login_his_id = LogError_login_his_idItem.GetDataList("login_his_id = " & _ID, "", trans)

                    'Child Table Name : LOG_TRANS Column :login_his_id
                    Dim LogTrans_login_his_idItem As New LogTransLinq
                    _LOG_TRANS_login_his_id = LogTrans_login_his_idItem.GetDataList("login_his_id = " & _ID, "", trans)

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function


        '/// Returns an indication whether the Class Data of LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As LoginHistoryPara
            ClearData()
            _haveData  = False
            Dim ret As New LoginHistoryPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                     If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt64(Rdr("id"))
                     If Convert.IsDBNull(Rdr("create_by")) = False Then ret.create_by = Rdr("create_by").ToString()
                     If Convert.IsDBNull(Rdr("create_on")) = False Then ret.create_on = Convert.ToDateTime(Rdr("create_on"))
                     If Convert.IsDBNull(Rdr("update_by")) = False Then ret.update_by = Rdr("update_by").ToString()
                     If Convert.IsDBNull(Rdr("update_on")) = False Then ret.update_on = Convert.ToDateTime(Rdr("update_on"))
                     If Convert.IsDBNull(Rdr("username")) = False Then ret.username = Rdr("username").ToString()
                     If Convert.IsDBNull(Rdr("idcard_no")) = False Then ret.idcard_no = Rdr("idcard_no").ToString()
                     If Convert.IsDBNull(Rdr("staff_name")) = False Then ret.staff_name = Rdr("staff_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_posname")) = False Then ret.staff_posname = Rdr("staff_posname").ToString()
                     If Convert.IsDBNull(Rdr("staff_division_name")) = False Then ret.staff_division_name = Rdr("staff_division_name").ToString()
                     If Convert.IsDBNull(Rdr("staff_department_name")) = False Then ret.staff_department_name = Rdr("staff_department_name").ToString()
                     If Convert.IsDBNull(Rdr("login_time")) = False Then ret.login_time = Convert.ToDateTime(Rdr("login_time"))
                     If Convert.IsDBNull(Rdr("logout_time")) = False Then ret.logout_time = Convert.ToDateTime(Rdr("logout_time"))
                     If Convert.IsDBNull(Rdr("is_sso")) = False Then ret.is_sso = Rdr("is_sso").ToString()
                     If Convert.IsDBNull(Rdr("ip_address")) = False Then ret.ip_address = Rdr("ip_address").ToString()
                     If Convert.IsDBNull(Rdr("session_id")) = False Then ret.session_id = Rdr("session_id").ToString()
                     If Convert.IsDBNull(Rdr("browser")) = False Then ret.browser = Rdr("browser").ToString()

                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104
                    If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                        Rdr.Close()
                    End If
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return ret
        End Function

        ' SQL Statements


        'Get Insert Statement for table LOGIN_HISTORY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USERNAME, IDCARD_NO, STAFF_NAME, STAFF_POSNAME, STAFF_DIVISION_NAME, STAFF_DEPARTMENT_NAME, LOGIN_TIME, LOGOUT_TIME, IS_SSO, IP_ADDRESS, SESSION_ID, BROWSER)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USERNAME) & ", "
                sql += DB.SetString(_IDCARD_NO) & ", "
                sql += DB.SetString(_STAFF_NAME) & ", "
                sql += DB.SetString(_STAFF_POSNAME) & ", "
                sql += DB.SetString(_STAFF_DIVISION_NAME) & ", "
                sql += DB.SetString(_STAFF_DEPARTMENT_NAME) & ", "
                sql += DB.SetDateTime(_LOGIN_TIME) & ", "
                sql += DB.SetDateTime(_LOGOUT_TIME) & ", "
                sql += DB.SetString(_IS_SSO) & ", "
                sql += DB.SetString(_IP_ADDRESS) & ", "
                sql += DB.SetString(_SESSION_ID) & ", "
                sql += DB.SetString(_BROWSER)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table LOGIN_HISTORY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "USERNAME = " & DB.SetString(_USERNAME) & ", "
                Sql += "IDCARD_NO = " & DB.SetString(_IDCARD_NO) & ", "
                Sql += "STAFF_NAME = " & DB.SetString(_STAFF_NAME) & ", "
                Sql += "STAFF_POSNAME = " & DB.SetString(_STAFF_POSNAME) & ", "
                Sql += "STAFF_DIVISION_NAME = " & DB.SetString(_STAFF_DIVISION_NAME) & ", "
                Sql += "STAFF_DEPARTMENT_NAME = " & DB.SetString(_STAFF_DEPARTMENT_NAME) & ", "
                Sql += "LOGIN_TIME = " & DB.SetDateTime(_LOGIN_TIME) & ", "
                Sql += "LOGOUT_TIME = " & DB.SetDateTime(_LOGOUT_TIME) & ", "
                Sql += "IS_SSO = " & DB.SetString(_IS_SSO) & ", "
                Sql += "IP_ADDRESS = " & DB.SetString(_IP_ADDRESS) & ", "
                Sql += "SESSION_ID = " & DB.SetString(_SESSION_ID) & ", "
                Sql += "BROWSER = " & DB.SetString(_BROWSER) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table LOGIN_HISTORY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table LOGIN_HISTORY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _LOG_ERROR_login_his_id As DataTable
       Dim _LOG_TRANS_login_his_id As DataTable

       Public Property CHILD_LOG_ERROR_login_his_id() As DataTable
           Get
               Return _LOG_ERROR_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_ERROR_login_his_id = value
           End Set
       End Property
       Public Property CHILD_LOG_TRANS_login_his_id() As DataTable
           Get
               Return _LOG_TRANS_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_TRANS_login_his_id = value
           End Set
       End Property
    End Class
End Namespace
