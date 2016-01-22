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
    'Represents a transaction for MODULE_FOLDER table Linq.
    '[Create by  on September, 6 2011]
    Public Class ModuleFolderLinq
        Public sub ModuleFolderLinq()

        End Sub 
        ' MODULE_FOLDER
        Const _tableName As String = "MODULE_FOLDER"
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
        Dim _MODULE_ID As Long = 0
        Dim _FOLDER_NAME As String = ""
        Dim _FOLDER_TOOLSTIP As  String  = ""
        Dim _FOLDER_DESC As  String  = ""
        Dim _FOLDER_ICON As  String  = ""
        Dim _FOLDER_URL As String = ""
        Dim _FOLDER_REF_ID As Long = 0
        Dim _ORDER_SEQ As Long = 0
        Dim _ACTIVE As Char = ""

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
        <Column(Storage:="_MODULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_NAME() As String
            Get
                Return _FOLDER_NAME
            End Get
            Set(ByVal value As String)
               _FOLDER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_TOOLSTIP", DbType:="VarChar(255)")>  _
        Public Property FOLDER_TOOLSTIP() As  String 
            Get
                Return _FOLDER_TOOLSTIP
            End Get
            Set(ByVal value As  String )
               _FOLDER_TOOLSTIP = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_DESC", DbType:="VarChar(500)")>  _
        Public Property FOLDER_DESC() As  String 
            Get
                Return _FOLDER_DESC
            End Get
            Set(ByVal value As  String )
               _FOLDER_DESC = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_ICON", DbType:="VarChar(255)")>  _
        Public Property FOLDER_ICON() As  String 
            Get
                Return _FOLDER_ICON
            End Get
            Set(ByVal value As  String )
               _FOLDER_ICON = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_URL", DbType:="VarChar(1000) NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_URL() As String
            Get
                Return _FOLDER_URL
            End Get
            Set(ByVal value As String)
               _FOLDER_URL = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_REF_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_REF_ID() As Long
            Get
                Return _FOLDER_REF_ID
            End Get
            Set(ByVal value As Long)
               _FOLDER_REF_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORDER_SEQ", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORDER_SEQ() As Long
            Get
                Return _ORDER_SEQ
            End Get
            Set(ByVal value As Long)
               _ORDER_SEQ = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _MODULE_ID = 0
            _FOLDER_NAME = ""
            _FOLDER_TOOLSTIP = ""
            _FOLDER_DESC = ""
            _FOLDER_ICON = ""
            _FOLDER_URL = ""
            _FOLDER_REF_ID = 0
            _ORDER_SEQ = 0
            _ACTIVE = ""
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


        '/// Returns an indication whether the current data is inserted into MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE_FOLDER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the record of MODULE_FOLDER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MODULE_FOLDER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As ModuleFolderLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of MODULE_FOLDER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As ModuleFolderPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MODULE_FOLDER by specified FOLDER_NAME_FOLDER_REF_ID_MODULE_ID key is retrieved successfully.
        '/// <param name=cFOLDER_NAME_FOLDER_REF_ID_MODULE_ID>The FOLDER_NAME_FOLDER_REF_ID_MODULE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByFOLDER_NAME_FOLDER_REF_ID_MODULE_ID(cFOLDER_NAME As String, cFOLDER_REF_ID As Long, cMODULE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FOLDER_NAME = " & DB.SetString(cFOLDER_NAME) & " AND FOLDER_REF_ID = " & DB.SetDouble(cFOLDER_REF_ID) & " AND MODULE_ID = " & DB.SetDouble(cMODULE_ID), trans)
        End Function

        '/// Returns an duplicate data record of MODULE_FOLDER by specified FOLDER_NAME_FOLDER_REF_ID_MODULE_ID key is retrieved successfully.
        '/// <param name=cFOLDER_NAME_FOLDER_REF_ID_MODULE_ID>The FOLDER_NAME_FOLDER_REF_ID_MODULE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByFOLDER_NAME_FOLDER_REF_ID_MODULE_ID(cFOLDER_NAME As String, cFOLDER_REF_ID As Long, cMODULE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FOLDER_NAME = " & DB.SetString(cFOLDER_NAME) & " AND FOLDER_REF_ID = " & DB.SetDouble(cFOLDER_REF_ID) & " AND MODULE_ID = " & DB.SetDouble(cMODULE_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MODULE_FOLDER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the current data is updated to MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the current data is deleted from MODULE_FOLDER table successfully.
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


        '/// Returns an indication whether the record of MODULE_FOLDER by specified condition is retrieved successfully.
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
                     If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                     If Convert.IsDBNull(Rdr("folder_name")) = False Then _folder_name = Rdr("folder_name").ToString()
                     If Convert.IsDBNull(Rdr("folder_toolstip")) = False Then _folder_toolstip = Rdr("folder_toolstip").ToString()
                     If Convert.IsDBNull(Rdr("folder_desc")) = False Then _folder_desc = Rdr("folder_desc").ToString()
                     If Convert.IsDBNull(Rdr("folder_icon")) = False Then _folder_icon = Rdr("folder_icon").ToString()
                     If Convert.IsDBNull(Rdr("folder_url")) = False Then _folder_url = Rdr("folder_url").ToString()
                     If Convert.IsDBNull(Rdr("folder_ref_id")) = False Then _folder_ref_id = Convert.ToInt64(Rdr("folder_ref_id"))
                     If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt64(Rdr("order_seq"))
                     If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
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


        '/// Returns an indication whether the record of MODULE_FOLDER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As ModuleFolderLinq
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
                     If Convert.IsDBNull(Rdr("module_id")) = False Then _module_id = Convert.ToInt64(Rdr("module_id"))
                     If Convert.IsDBNull(Rdr("folder_name")) = False Then _folder_name = Rdr("folder_name").ToString()
                     If Convert.IsDBNull(Rdr("folder_toolstip")) = False Then _folder_toolstip = Rdr("folder_toolstip").ToString()
                     If Convert.IsDBNull(Rdr("folder_desc")) = False Then _folder_desc = Rdr("folder_desc").ToString()
                     If Convert.IsDBNull(Rdr("folder_icon")) = False Then _folder_icon = Rdr("folder_icon").ToString()
                     If Convert.IsDBNull(Rdr("folder_url")) = False Then _folder_url = Rdr("folder_url").ToString()
                     If Convert.IsDBNull(Rdr("folder_ref_id")) = False Then _folder_ref_id = Convert.ToInt64(Rdr("folder_ref_id"))
                     If Convert.IsDBNull(Rdr("order_seq")) = False Then _order_seq = Convert.ToInt64(Rdr("order_seq"))
                     If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()

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


        '/// Returns an indication whether the Class Data of MODULE_FOLDER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As ModuleFolderPara
            ClearData()
            _haveData  = False
            Dim ret As New ModuleFolderPara
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
                     If Convert.IsDBNull(Rdr("module_id")) = False Then ret.module_id = Convert.ToInt64(Rdr("module_id"))
                     If Convert.IsDBNull(Rdr("folder_name")) = False Then ret.folder_name = Rdr("folder_name").ToString()
                     If Convert.IsDBNull(Rdr("folder_toolstip")) = False Then ret.folder_toolstip = Rdr("folder_toolstip").ToString()
                     If Convert.IsDBNull(Rdr("folder_desc")) = False Then ret.folder_desc = Rdr("folder_desc").ToString()
                     If Convert.IsDBNull(Rdr("folder_icon")) = False Then ret.folder_icon = Rdr("folder_icon").ToString()
                     If Convert.IsDBNull(Rdr("folder_url")) = False Then ret.folder_url = Rdr("folder_url").ToString()
                     If Convert.IsDBNull(Rdr("folder_ref_id")) = False Then ret.folder_ref_id = Convert.ToInt64(Rdr("folder_ref_id"))
                     If Convert.IsDBNull(Rdr("order_seq")) = False Then ret.order_seq = Convert.ToInt64(Rdr("order_seq"))
                     If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()

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


        'Get Insert Statement for table MODULE_FOLDER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, MODULE_ID, FOLDER_NAME, FOLDER_TOOLSTIP, FOLDER_DESC, FOLDER_ICON, FOLDER_URL, FOLDER_REF_ID, ORDER_SEQ, ACTIVE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_MODULE_ID) & ", "
                sql += DB.SetString(_FOLDER_NAME) & ", "
                sql += DB.SetString(_FOLDER_TOOLSTIP) & ", "
                sql += DB.SetString(_FOLDER_DESC) & ", "
                sql += DB.SetString(_FOLDER_ICON) & ", "
                sql += DB.SetString(_FOLDER_URL) & ", "
                sql += DB.SetDouble(_FOLDER_REF_ID) & ", "
                sql += DB.SetDouble(_ORDER_SEQ) & ", "
                sql += DB.SetString(_ACTIVE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MODULE_FOLDER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "MODULE_ID = " & DB.SetDouble(_MODULE_ID) & ", "
                Sql += "FOLDER_NAME = " & DB.SetString(_FOLDER_NAME) & ", "
                Sql += "FOLDER_TOOLSTIP = " & DB.SetString(_FOLDER_TOOLSTIP) & ", "
                Sql += "FOLDER_DESC = " & DB.SetString(_FOLDER_DESC) & ", "
                Sql += "FOLDER_ICON = " & DB.SetString(_FOLDER_ICON) & ", "
                Sql += "FOLDER_URL = " & DB.SetString(_FOLDER_URL) & ", "
                Sql += "FOLDER_REF_ID = " & DB.SetDouble(_FOLDER_REF_ID) & ", "
                Sql += "ORDER_SEQ = " & DB.SetDouble(_ORDER_SEQ) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MODULE_FOLDER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MODULE_FOLDER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
