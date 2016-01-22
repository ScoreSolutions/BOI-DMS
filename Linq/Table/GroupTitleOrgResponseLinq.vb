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
    'Represents a transaction for GROUP_TITLE_ORG_RESPONSE table Linq.
    '[Create by  on June, 18 2012]
    Public Class GroupTitleOrgResponseLinq
        Public sub GroupTitleOrgResponseLinq()

        End Sub 
        ' GROUP_TITLE_ORG_RESPONSE
        Const _tableName As String = "GROUP_TITLE_ORG_RESPONSE"
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
        Dim _GROUP_TITLE_ID As Long = 0
        Dim _ORGANIZATION_ID As Long = 0
        Dim _ORGANIZATION_NAME As String = ""
        Dim _ORGANIZATION_APPNAME As  String  = ""
        Dim _ORGANIZATION_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _STD_PROC_PERIOD As  System.Nullable(Of Long)  = 0
        Dim _MAX_PROC_PERIOD As  System.Nullable(Of Long)  = 0

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
        <Column(Storage:="_GROUP_TITLE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_ID() As Long
            Get
                Return _GROUP_TITLE_ID
            End Get
            Set(ByVal value As Long)
               _GROUP_TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID() As Long
            Get
                Return _ORGANIZATION_ID
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_NAME() As String
            Get
                Return _ORGANIZATION_NAME
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_APPNAME() As  String 
            Get
                Return _ORGANIZATION_APPNAME
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_APPNAME = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_TYPE_ID", DbType:="BigInt")>  _
        Public Property ORGANIZATION_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_STD_PROC_PERIOD", DbType:="Int")>  _
        Public Property STD_PROC_PERIOD() As  System.Nullable(Of Long) 
            Get
                Return _STD_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _STD_PROC_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_MAX_PROC_PERIOD", DbType:="Int")>  _
        Public Property MAX_PROC_PERIOD() As  System.Nullable(Of Long) 
            Get
                Return _MAX_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MAX_PROC_PERIOD = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _GROUP_TITLE_ID = 0
            _ORGANIZATION_ID = 0
            _ORGANIZATION_NAME = ""
            _ORGANIZATION_APPNAME = ""
            _ORGANIZATION_TYPE_ID = 0
            _STD_PROC_PERIOD = 0
            _MAX_PROC_PERIOD = 0
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


        '/// Returns an indication whether the current data is inserted into GROUP_TITLE_ORG_RESPONSE table successfully.
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


        '/// Returns an indication whether the current data is updated to GROUP_TITLE_ORG_RESPONSE table successfully.
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


        '/// Returns an indication whether the current data is updated to GROUP_TITLE_ORG_RESPONSE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from GROUP_TITLE_ORG_RESPONSE table successfully.
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


        '/// Returns an indication whether the record of GROUP_TITLE_ORG_RESPONSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of GROUP_TITLE_ORG_RESPONSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As GroupTitleOrgResponseLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of GROUP_TITLE_ORG_RESPONSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As GroupTitleOrgResponsePara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE_ORG_RESPONSE by specified GROUP_TITLE_ID_ORGANIZATION_ID key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_ID_ORGANIZATION_ID>The GROUP_TITLE_ID_ORGANIZATION_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByGROUP_TITLE_ID_ORGANIZATION_ID(cGROUP_TITLE_ID As Long, cORGANIZATION_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_ID = " & DB.SetDouble(cGROUP_TITLE_ID) & " AND ORGANIZATION_ID = " & DB.SetDouble(cORGANIZATION_ID), trans)
        End Function

        '/// Returns an duplicate data record of GROUP_TITLE_ORG_RESPONSE by specified GROUP_TITLE_ID_ORGANIZATION_ID key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_ID_ORGANIZATION_ID>The GROUP_TITLE_ID_ORGANIZATION_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByGROUP_TITLE_ID_ORGANIZATION_ID(cGROUP_TITLE_ID As Long, cORGANIZATION_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_ID = " & DB.SetDouble(cGROUP_TITLE_ID) & " AND ORGANIZATION_ID = " & DB.SetDouble(cORGANIZATION_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE_ORG_RESPONSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into GROUP_TITLE_ORG_RESPONSE table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
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


        '/// Returns an indication whether the current data is updated to GROUP_TITLE_ORG_RESPONSE table successfully.
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
                            _error = DB.ErrorMessage
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


        '/// Returns an indication whether the current data is deleted from GROUP_TITLE_ORG_RESPONSE table successfully.
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


        '/// Returns an indication whether the record of GROUP_TITLE_ORG_RESPONSE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then _group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then _organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then _organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then _organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then _organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then _std_proc_period = Convert.ToInt32(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then _max_proc_period = Convert.ToInt32(Rdr("max_proc_period"))
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


        '/// Returns an indication whether the record of GROUP_TITLE_ORG_RESPONSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As GroupTitleOrgResponseLinq
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
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then _group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then _organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then _organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then _organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then _organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then _std_proc_period = Convert.ToInt32(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then _max_proc_period = Convert.ToInt32(Rdr("max_proc_period"))

                        'Generate Item For Child Table
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


        '/// Returns an indication whether the Class Data of GROUP_TITLE_ORG_RESPONSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As GroupTitleOrgResponsePara
            ClearData()
            _haveData  = False
            Dim ret As New GroupTitleOrgResponsePara
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
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then ret.group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then ret.organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then ret.organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then ret.organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then ret.organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then ret.std_proc_period = Convert.ToInt32(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then ret.max_proc_period = Convert.ToInt32(Rdr("max_proc_period"))

                        'Generate Item For Child Table

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


        'Get Insert Statement for table GROUP_TITLE_ORG_RESPONSE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, GROUP_TITLE_ID, ORGANIZATION_ID, ORGANIZATION_NAME, ORGANIZATION_APPNAME, ORGANIZATION_TYPE_ID, STD_PROC_PERIOD, MAX_PROC_PERIOD)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_GROUP_TITLE_ID) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME) & ", "
                sql += DB.SetString(_ORGANIZATION_APPNAME) & ", "
                sql += DB.SetDouble(_ORGANIZATION_TYPE_ID) & ", "
                sql += DB.SetDouble(_STD_PROC_PERIOD) & ", "
                sql += DB.SetDouble(_MAX_PROC_PERIOD)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table GROUP_TITLE_ORG_RESPONSE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "GROUP_TITLE_ID = " & DB.SetDouble(_GROUP_TITLE_ID) & ", "
                Sql += "ORGANIZATION_ID = " & DB.SetDouble(_ORGANIZATION_ID) & ", "
                Sql += "ORGANIZATION_NAME = " & DB.SetString(_ORGANIZATION_NAME) & ", "
                Sql += "ORGANIZATION_APPNAME = " & DB.SetString(_ORGANIZATION_APPNAME) & ", "
                Sql += "ORGANIZATION_TYPE_ID = " & DB.SetDouble(_ORGANIZATION_TYPE_ID) & ", "
                Sql += "STD_PROC_PERIOD = " & DB.SetDouble(_STD_PROC_PERIOD) & ", "
                Sql += "MAX_PROC_PERIOD = " & DB.SetDouble(_MAX_PROC_PERIOD) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table GROUP_TITLE_ORG_RESPONSE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table GROUP_TITLE_ORG_RESPONSE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
