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
    'Represents a transaction for DOCUMENT_CANCEL_CLOSE table Linq.
    '[Create by  on July, 21 2012]
    Public Class DocumentCancelCloseLinq
        Public sub DocumentCancelCloseLinq()

        End Sub 
        ' DOCUMENT_CANCEL_CLOSE
        Const _tableName As String = "DOCUMENT_CANCEL_CLOSE"
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
        Dim _DOCUMENT_REGISTER_ID As Long = 0
        Dim _CANCEL_DATE As DateTime = New DateTime(1,1,1)
        Dim _CANCEL_REASON As String = ""
        Dim _ORGANIZATION_ID_CANCEL As Long = 0
        Dim _ORGANIZATION_NAME_CANCEL As String = ""
        Dim _ORGANIZATION_APPNAME_CANCEL As String = ""
        Dim _OFFICER_USERNAME_CANCEL As String = ""
        Dim _OFFICER_FULLNAME_CANCEL As String = ""
        Dim _CLOSE_BY As String = ""
        Dim _CLOSE_BY_NAME As String = ""
        Dim _CLOSE_DATE As DateTime = New DateTime(1,1,1)
        Dim _CLOSE_REMARKS As  String  = ""

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
        <Column(Storage:="_DOCUMENT_REGISTER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOCUMENT_REGISTER_ID() As Long
            Get
                Return _DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As Long)
               _DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_CANCEL_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CANCEL_DATE() As DateTime
            Get
                Return _CANCEL_DATE
            End Get
            Set(ByVal value As DateTime)
               _CANCEL_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CANCEL_REASON", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property CANCEL_REASON() As String
            Get
                Return _CANCEL_REASON
            End Get
            Set(ByVal value As String)
               _CANCEL_REASON = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_CANCEL", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID_CANCEL() As Long
            Get
                Return _ORGANIZATION_ID_CANCEL
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_ID_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_NAME_CANCEL() As String
            Get
                Return _ORGANIZATION_NAME_CANCEL
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_NAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_APPNAME_CANCEL() As String
            Get
                Return _ORGANIZATION_APPNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_APPNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_USERNAME_CANCEL", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_USERNAME_CANCEL() As String
            Get
                Return _OFFICER_USERNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _OFFICER_USERNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_FULLNAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_FULLNAME_CANCEL() As String
            Get
                Return _OFFICER_FULLNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _OFFICER_FULLNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_BY() As String
            Get
                Return _CLOSE_BY
            End Get
            Set(ByVal value As String)
               _CLOSE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_BY_NAME() As String
            Get
                Return _CLOSE_BY_NAME
            End Get
            Set(ByVal value As String)
               _CLOSE_BY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_DATE() As DateTime
            Get
                Return _CLOSE_DATE
            End Get
            Set(ByVal value As DateTime)
               _CLOSE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_REMARKS", DbType:="VarChar(255)")>  _
        Public Property CLOSE_REMARKS() As  String 
            Get
                Return _CLOSE_REMARKS
            End Get
            Set(ByVal value As  String )
               _CLOSE_REMARKS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _DOCUMENT_REGISTER_ID = 0
            _CANCEL_DATE = New DateTime(1,1,1)
            _CANCEL_REASON = ""
            _ORGANIZATION_ID_CANCEL = 0
            _ORGANIZATION_NAME_CANCEL = ""
            _ORGANIZATION_APPNAME_CANCEL = ""
            _OFFICER_USERNAME_CANCEL = ""
            _OFFICER_FULLNAME_CANCEL = ""
            _CLOSE_BY = ""
            _CLOSE_BY_NAME = ""
            _CLOSE_DATE = New DateTime(1,1,1)
            _CLOSE_REMARKS = ""
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


        '/// Returns an indication whether the current data is inserted into DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_CANCEL_CLOSE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_CANCEL_CLOSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOCUMENT_CANCEL_CLOSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As DocumentCancelCloseLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOCUMENT_CANCEL_CLOSE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As DocumentCancelClosePara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_CANCEL_CLOSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOCUMENT_CANCEL_CLOSE table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_CANCEL_CLOSE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("document_register_id")) = False Then _document_register_id = Convert.ToInt64(Rdr("document_register_id"))
                        If Convert.IsDBNull(Rdr("cancel_date")) = False Then _cancel_date = Convert.ToDateTime(Rdr("cancel_date"))
                        If Convert.IsDBNull(Rdr("cancel_reason")) = False Then _cancel_reason = Rdr("cancel_reason").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_cancel")) = False Then _organization_id_cancel = Convert.ToInt64(Rdr("organization_id_cancel"))
                        If Convert.IsDBNull(Rdr("organization_name_cancel")) = False Then _organization_name_cancel = Rdr("organization_name_cancel").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_cancel")) = False Then _organization_appname_cancel = Rdr("organization_appname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_username_cancel")) = False Then _officer_username_cancel = Rdr("officer_username_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_fullname_cancel")) = False Then _officer_fullname_cancel = Rdr("officer_fullname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("close_by")) = False Then _close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then _close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then _close_remarks = Rdr("close_remarks").ToString()
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


        '/// Returns an indication whether the record of DOCUMENT_CANCEL_CLOSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocumentCancelCloseLinq
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
                        If Convert.IsDBNull(Rdr("document_register_id")) = False Then _document_register_id = Convert.ToInt64(Rdr("document_register_id"))
                        If Convert.IsDBNull(Rdr("cancel_date")) = False Then _cancel_date = Convert.ToDateTime(Rdr("cancel_date"))
                        If Convert.IsDBNull(Rdr("cancel_reason")) = False Then _cancel_reason = Rdr("cancel_reason").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_cancel")) = False Then _organization_id_cancel = Convert.ToInt64(Rdr("organization_id_cancel"))
                        If Convert.IsDBNull(Rdr("organization_name_cancel")) = False Then _organization_name_cancel = Rdr("organization_name_cancel").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_cancel")) = False Then _organization_appname_cancel = Rdr("organization_appname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_username_cancel")) = False Then _officer_username_cancel = Rdr("officer_username_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_fullname_cancel")) = False Then _officer_fullname_cancel = Rdr("officer_fullname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("close_by")) = False Then _close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then _close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then _close_remarks = Rdr("close_remarks").ToString()

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


        '/// Returns an indication whether the Class Data of DOCUMENT_CANCEL_CLOSE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocumentCancelClosePara
            ClearData()
            _haveData  = False
            Dim ret As New DocumentCancelClosePara
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
                        If Convert.IsDBNull(Rdr("document_register_id")) = False Then ret.document_register_id = Convert.ToInt64(Rdr("document_register_id"))
                        If Convert.IsDBNull(Rdr("cancel_date")) = False Then ret.cancel_date = Convert.ToDateTime(Rdr("cancel_date"))
                        If Convert.IsDBNull(Rdr("cancel_reason")) = False Then ret.cancel_reason = Rdr("cancel_reason").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_cancel")) = False Then ret.organization_id_cancel = Convert.ToInt64(Rdr("organization_id_cancel"))
                        If Convert.IsDBNull(Rdr("organization_name_cancel")) = False Then ret.organization_name_cancel = Rdr("organization_name_cancel").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_cancel")) = False Then ret.organization_appname_cancel = Rdr("organization_appname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_username_cancel")) = False Then ret.officer_username_cancel = Rdr("officer_username_cancel").ToString()
                        If Convert.IsDBNull(Rdr("officer_fullname_cancel")) = False Then ret.officer_fullname_cancel = Rdr("officer_fullname_cancel").ToString()
                        If Convert.IsDBNull(Rdr("close_by")) = False Then ret.close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then ret.close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then ret.close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then ret.close_remarks = Rdr("close_remarks").ToString()

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


        'Get Insert Statement for table DOCUMENT_CANCEL_CLOSE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, DOCUMENT_REGISTER_ID, CANCEL_DATE, CANCEL_REASON, ORGANIZATION_ID_CANCEL, ORGANIZATION_NAME_CANCEL, ORGANIZATION_APPNAME_CANCEL, OFFICER_USERNAME_CANCEL, OFFICER_FULLNAME_CANCEL, CLOSE_BY, CLOSE_BY_NAME, CLOSE_DATE, CLOSE_REMARKS)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_DOCUMENT_REGISTER_ID) & ", "
                sql += DB.SetDateTime(_CANCEL_DATE) & ", "
                sql += DB.SetString(_CANCEL_REASON) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_CANCEL) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_CANCEL) & ", "
                sql += DB.SetString(_ORGANIZATION_APPNAME_CANCEL) & ", "
                sql += DB.SetString(_OFFICER_USERNAME_CANCEL) & ", "
                sql += DB.SetString(_OFFICER_FULLNAME_CANCEL) & ", "
                sql += DB.SetString(_CLOSE_BY) & ", "
                sql += DB.SetString(_CLOSE_BY_NAME) & ", "
                sql += DB.SetDateTime(_CLOSE_DATE) & ", "
                sql += DB.SetString(_CLOSE_REMARKS)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOCUMENT_CANCEL_CLOSE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "DOCUMENT_REGISTER_ID = " & DB.SetDouble(_DOCUMENT_REGISTER_ID) & ", "
                Sql += "CANCEL_DATE = " & DB.SetDateTime(_CANCEL_DATE) & ", "
                Sql += "CANCEL_REASON = " & DB.SetString(_CANCEL_REASON) & ", "
                Sql += "ORGANIZATION_ID_CANCEL = " & DB.SetDouble(_ORGANIZATION_ID_CANCEL) & ", "
                Sql += "ORGANIZATION_NAME_CANCEL = " & DB.SetString(_ORGANIZATION_NAME_CANCEL) & ", "
                Sql += "ORGANIZATION_APPNAME_CANCEL = " & DB.SetString(_ORGANIZATION_APPNAME_CANCEL) & ", "
                Sql += "OFFICER_USERNAME_CANCEL = " & DB.SetString(_OFFICER_USERNAME_CANCEL) & ", "
                Sql += "OFFICER_FULLNAME_CANCEL = " & DB.SetString(_OFFICER_FULLNAME_CANCEL) & ", "
                Sql += "CLOSE_BY = " & DB.SetString(_CLOSE_BY) & ", "
                Sql += "CLOSE_BY_NAME = " & DB.SetString(_CLOSE_BY_NAME) & ", "
                Sql += "CLOSE_DATE = " & DB.SetDateTime(_CLOSE_DATE) & ", "
                Sql += "CLOSE_REMARKS = " & DB.SetString(_CLOSE_REMARKS) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOCUMENT_CANCEL_CLOSE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOCUMENT_CANCEL_CLOSE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
