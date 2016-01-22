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
    'Represents a transaction for DOCUMENT_INT_RECEIVER table Linq.
    '[Create by  on July, 13 2012]
    Public Class DocumentIntReceiverLinq
        Public sub DocumentIntReceiverLinq()

        End Sub 
        ' DOCUMENT_INT_RECEIVER
        Const _tableName As String = "DOCUMENT_INT_RECEIVER"
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
        Dim _CREATE_BY As  String  = ""
        Dim _CREATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_REGISTER_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID_SEND As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_SEND As  String  = ""
        Dim _ORGANIZATION_APPNAME_SEND As  String  = ""
        Dim _SEND_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SENDER_OFFICER_USERNAME As  String  = ""
        Dim _SENDER_OFFICER_FULLNAME As  String  = ""
        Dim _RECEIVE_STATUS_ID As  String  = ""
        Dim _RECEIVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORGANIZATION_ID_RECEIVE As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_RECEIVE As  String  = ""
        Dim _ORGANIZATION_APPNAME_RECEIVE As  String  = ""
        Dim _RECEIVER_OFFICER_USERNAME As  String  = ""
        Dim _RECEIVER_OFFICER_FULLNAME As  String  = ""
        Dim _RECEIVE_TYPE_ID As  String  = ""
        Dim _RECEIVE_OBJECTIVE_ID As  System.Nullable(Of Long)  = 0
        Dim _REMARKS As  String  = ""
        Dim _ORGANIZATION_ID_STORAGE As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_STORAGE As  String  = ""
        Dim _REF_OLD_SEND_ID As  String  = ""
        Dim _REF_OLD_RECEIVE_ID As  String  = ""
        Dim _DOCUMENT_STATEMENT As  String  = ""
        Dim _DOCUMENT_INT_TYPE As  System.Nullable(Of Long)  = 0
        Dim _MODULE_FOLDER_ID As Long = 0
        Dim _IS_FORWARD As Char = "N"
        Dim _SENDBACK_REASON As  String  = ""
        Dim _RETRIEVE_REASON As  String  = ""

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
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50)")>  _
        Public Property CREATE_BY() As  String 
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As  String )
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_ON", DbType:="DateTime2")>  _
        Public Property CREATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
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
        <Column(Storage:="_DOCUMENT_REGISTER_ID", DbType:="BigInt")>  _
        Public Property DOCUMENT_REGISTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_SEND", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_SEND() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_SEND
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_SEND = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_SEND", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_SEND() As  String 
            Get
                Return _ORGANIZATION_NAME_SEND
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_SEND = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_SEND", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_APPNAME_SEND() As  String 
            Get
                Return _ORGANIZATION_APPNAME_SEND
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_APPNAME_SEND = value
            End Set
        End Property 
        <Column(Storage:="_SEND_DATE", DbType:="DateTime")>  _
        Public Property SEND_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_USERNAME", DbType:="VarChar(50)")>  _
        Public Property SENDER_OFFICER_USERNAME() As  String 
            Get
                Return _SENDER_OFFICER_USERNAME
            End Get
            Set(ByVal value As  String )
               _SENDER_OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_FULLNAME", DbType:="VarChar(255)")>  _
        Public Property SENDER_OFFICER_FULLNAME() As  String 
            Get
                Return _SENDER_OFFICER_FULLNAME
            End Get
            Set(ByVal value As  String )
               _SENDER_OFFICER_FULLNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_STATUS_ID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_STATUS_ID() As  String 
            Get
                Return _RECEIVE_STATUS_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_STATUS_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_DATE", DbType:="DateTime")>  _
        Public Property RECEIVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_RECEIVE", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_RECEIVE() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_RECEIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_RECEIVE() As  String 
            Get
                Return _ORGANIZATION_NAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_APPNAME_RECEIVE() As  String 
            Get
                Return _ORGANIZATION_APPNAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_APPNAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_OFFICER_USERNAME", DbType:="VarChar(50)")>  _
        Public Property RECEIVER_OFFICER_USERNAME() As  String 
            Get
                Return _RECEIVER_OFFICER_USERNAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_OFFICER_FULLNAME", DbType:="VarChar(255)")>  _
        Public Property RECEIVER_OFFICER_FULLNAME() As  String 
            Get
                Return _RECEIVER_OFFICER_FULLNAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_OFFICER_FULLNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_TYPE_ID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_TYPE_ID() As  String 
            Get
                Return _RECEIVE_TYPE_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_OBJECTIVE_ID", DbType:="BigInt")>  _
        Public Property RECEIVE_OBJECTIVE_ID() As  System.Nullable(Of Long) 
            Get
                Return _RECEIVE_OBJECTIVE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _RECEIVE_OBJECTIVE_ID = value
            End Set
        End Property 
        <Column(Storage:="_REMARKS", DbType:="VarChar(500)")>  _
        Public Property REMARKS() As  String 
            Get
                Return _REMARKS
            End Get
            Set(ByVal value As  String )
               _REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_STORAGE", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_STORAGE() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_STORAGE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_STORAGE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_STORAGE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_STORAGE() As  String 
            Get
                Return _ORGANIZATION_NAME_STORAGE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_STORAGE = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_SEND_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_SEND_ID() As  String 
            Get
                Return _REF_OLD_SEND_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_SEND_ID = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_RECEIVE_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_RECEIVE_ID() As  String 
            Get
                Return _REF_OLD_RECEIVE_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_RECEIVE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_STATEMENT", DbType:="VarChar(100)")>  _
        Public Property DOCUMENT_STATEMENT() As  String 
            Get
                Return _DOCUMENT_STATEMENT
            End Get
            Set(ByVal value As  String )
               _DOCUMENT_STATEMENT = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_INT_TYPE", DbType:="Int")>  _
        Public Property DOCUMENT_INT_TYPE() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_INT_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_INT_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_FOLDER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_FOLDER_ID() As Long
            Get
                Return _MODULE_FOLDER_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_FOLDER_ID = value
            End Set
        End Property 
        <Column(Storage:="_IS_FORWARD", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_FORWARD() As Char
            Get
                Return _IS_FORWARD
            End Get
            Set(ByVal value As Char)
               _IS_FORWARD = value
            End Set
        End Property 
        <Column(Storage:="_SENDBACK_REASON", DbType:="VarChar(500)")>  _
        Public Property SENDBACK_REASON() As  String 
            Get
                Return _SENDBACK_REASON
            End Get
            Set(ByVal value As  String )
               _SENDBACK_REASON = value
            End Set
        End Property 
        <Column(Storage:="_RETRIEVE_REASON", DbType:="VarChar(500)")>  _
        Public Property RETRIEVE_REASON() As  String 
            Get
                Return _RETRIEVE_REASON
            End Get
            Set(ByVal value As  String )
               _RETRIEVE_REASON = value
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
            _ORGANIZATION_ID_SEND = 0
            _ORGANIZATION_NAME_SEND = ""
            _ORGANIZATION_APPNAME_SEND = ""
            _SEND_DATE = New DateTime(1,1,1)
            _SENDER_OFFICER_USERNAME = ""
            _SENDER_OFFICER_FULLNAME = ""
            _RECEIVE_STATUS_ID = ""
            _RECEIVE_DATE = New DateTime(1,1,1)
            _ORGANIZATION_ID_RECEIVE = 0
            _ORGANIZATION_NAME_RECEIVE = ""
            _ORGANIZATION_APPNAME_RECEIVE = ""
            _RECEIVER_OFFICER_USERNAME = ""
            _RECEIVER_OFFICER_FULLNAME = ""
            _RECEIVE_TYPE_ID = ""
            _RECEIVE_OBJECTIVE_ID = 0
            _REMARKS = ""
            _ORGANIZATION_ID_STORAGE = 0
            _ORGANIZATION_NAME_STORAGE = ""
            _REF_OLD_SEND_ID = ""
            _REF_OLD_RECEIVE_ID = ""
            _DOCUMENT_STATEMENT = ""
            _DOCUMENT_INT_TYPE = 0
            _MODULE_FOLDER_ID = 0
            _IS_FORWARD = ""
            _SENDBACK_REASON = ""
            _RETRIEVE_REASON = ""
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


        '/// Returns an indication whether the current data is inserted into DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_INT_RECEIVER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOCUMENT_INT_RECEIVER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As DocumentIntReceiverLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOCUMENT_INT_RECEIVER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As DocumentIntReceiverPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified RECEIVE_DATE key is retrieved successfully.
        '/// <param name=cRECEIVE_DATE>The RECEIVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByRECEIVE_DATE(cRECEIVE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("RECEIVE_DATE = " & DB.SetDateTime(cRECEIVE_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_INT_RECEIVER by specified RECEIVE_DATE key is retrieved successfully.
        '/// <param name=cRECEIVE_DATE>The RECEIVE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByRECEIVE_DATE(cRECEIVE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("RECEIVE_DATE = " & DB.SetDateTime(cRECEIVE_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified ORGANIZATION_ID_RECEIVE key is retrieved successfully.
        '/// <param name=cORGANIZATION_ID_RECEIVE>The ORGANIZATION_ID_RECEIVE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByORGANIZATION_ID_RECEIVE(cORGANIZATION_ID_RECEIVE As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORGANIZATION_ID_RECEIVE = " & DB.SetDouble(cORGANIZATION_ID_RECEIVE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_INT_RECEIVER by specified ORGANIZATION_ID_RECEIVE key is retrieved successfully.
        '/// <param name=cORGANIZATION_ID_RECEIVE>The ORGANIZATION_ID_RECEIVE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByORGANIZATION_ID_RECEIVE(cORGANIZATION_ID_RECEIVE As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORGANIZATION_ID_RECEIVE = " & DB.SetDouble(cORGANIZATION_ID_RECEIVE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified RECEIVER_OFFICER_FULLNAME key is retrieved successfully.
        '/// <param name=cRECEIVER_OFFICER_FULLNAME>The RECEIVER_OFFICER_FULLNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByRECEIVER_OFFICER_FULLNAME(cRECEIVER_OFFICER_FULLNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("RECEIVER_OFFICER_FULLNAME = " & DB.SetString(cRECEIVER_OFFICER_FULLNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_INT_RECEIVER by specified RECEIVER_OFFICER_FULLNAME key is retrieved successfully.
        '/// <param name=cRECEIVER_OFFICER_FULLNAME>The RECEIVER_OFFICER_FULLNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByRECEIVER_OFFICER_FULLNAME(cRECEIVER_OFFICER_FULLNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("RECEIVER_OFFICER_FULLNAME = " & DB.SetString(cRECEIVER_OFFICER_FULLNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOCUMENT_INT_RECEIVER table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("organization_id_send")) = False Then _organization_id_send = Convert.ToInt64(Rdr("organization_id_send"))
                        If Convert.IsDBNull(Rdr("organization_name_send")) = False Then _organization_name_send = Rdr("organization_name_send").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_send")) = False Then _organization_appname_send = Rdr("organization_appname_send").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Convert.ToDateTime(Rdr("send_date"))
                        If Convert.IsDBNull(Rdr("sender_officer_username")) = False Then _sender_officer_username = Rdr("sender_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("sender_officer_fullname")) = False Then _sender_officer_fullname = Rdr("sender_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_status_id")) = False Then _receive_status_id = Rdr("receive_status_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_date")) = False Then _receive_date = Convert.ToDateTime(Rdr("receive_date"))
                        If Convert.IsDBNull(Rdr("organization_id_receive")) = False Then _organization_id_receive = Convert.ToInt64(Rdr("organization_id_receive"))
                        If Convert.IsDBNull(Rdr("organization_name_receive")) = False Then _organization_name_receive = Rdr("organization_name_receive").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_receive")) = False Then _organization_appname_receive = Rdr("organization_appname_receive").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_username")) = False Then _receiver_officer_username = Rdr("receiver_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_fullname")) = False Then _receiver_officer_fullname = Rdr("receiver_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_type_id")) = False Then _receive_type_id = Rdr("receive_type_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_objective_id")) = False Then _receive_objective_id = Convert.ToInt64(Rdr("receive_objective_id"))
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then _organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then _organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_send_id")) = False Then _ref_old_send_id = Rdr("ref_old_send_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_receive_id")) = False Then _ref_old_receive_id = Rdr("ref_old_receive_id").ToString()
                        If Convert.IsDBNull(Rdr("document_statement")) = False Then _document_statement = Rdr("document_statement").ToString()
                        If Convert.IsDBNull(Rdr("document_int_type")) = False Then _document_int_type = Convert.ToInt32(Rdr("document_int_type"))
                        If Convert.IsDBNull(Rdr("module_folder_id")) = False Then _module_folder_id = Convert.ToInt64(Rdr("module_folder_id"))
                        If Convert.IsDBNull(Rdr("is_forward")) = False Then _is_forward = Rdr("is_forward").ToString()
                        If Convert.IsDBNull(Rdr("sendback_reason")) = False Then _sendback_reason = Rdr("sendback_reason").ToString()
                        If Convert.IsDBNull(Rdr("retrieve_reason")) = False Then _retrieve_reason = Rdr("retrieve_reason").ToString()
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


        '/// Returns an indication whether the record of DOCUMENT_INT_RECEIVER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocumentIntReceiverLinq
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
                        If Convert.IsDBNull(Rdr("organization_id_send")) = False Then _organization_id_send = Convert.ToInt64(Rdr("organization_id_send"))
                        If Convert.IsDBNull(Rdr("organization_name_send")) = False Then _organization_name_send = Rdr("organization_name_send").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_send")) = False Then _organization_appname_send = Rdr("organization_appname_send").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Convert.ToDateTime(Rdr("send_date"))
                        If Convert.IsDBNull(Rdr("sender_officer_username")) = False Then _sender_officer_username = Rdr("sender_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("sender_officer_fullname")) = False Then _sender_officer_fullname = Rdr("sender_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_status_id")) = False Then _receive_status_id = Rdr("receive_status_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_date")) = False Then _receive_date = Convert.ToDateTime(Rdr("receive_date"))
                        If Convert.IsDBNull(Rdr("organization_id_receive")) = False Then _organization_id_receive = Convert.ToInt64(Rdr("organization_id_receive"))
                        If Convert.IsDBNull(Rdr("organization_name_receive")) = False Then _organization_name_receive = Rdr("organization_name_receive").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_receive")) = False Then _organization_appname_receive = Rdr("organization_appname_receive").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_username")) = False Then _receiver_officer_username = Rdr("receiver_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_fullname")) = False Then _receiver_officer_fullname = Rdr("receiver_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_type_id")) = False Then _receive_type_id = Rdr("receive_type_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_objective_id")) = False Then _receive_objective_id = Convert.ToInt64(Rdr("receive_objective_id"))
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then _organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then _organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_send_id")) = False Then _ref_old_send_id = Rdr("ref_old_send_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_receive_id")) = False Then _ref_old_receive_id = Rdr("ref_old_receive_id").ToString()
                        If Convert.IsDBNull(Rdr("document_statement")) = False Then _document_statement = Rdr("document_statement").ToString()
                        If Convert.IsDBNull(Rdr("document_int_type")) = False Then _document_int_type = Convert.ToInt32(Rdr("document_int_type"))
                        If Convert.IsDBNull(Rdr("module_folder_id")) = False Then _module_folder_id = Convert.ToInt64(Rdr("module_folder_id"))
                        If Convert.IsDBNull(Rdr("is_forward")) = False Then _is_forward = Rdr("is_forward").ToString()
                        If Convert.IsDBNull(Rdr("sendback_reason")) = False Then _sendback_reason = Rdr("sendback_reason").ToString()
                        If Convert.IsDBNull(Rdr("retrieve_reason")) = False Then _retrieve_reason = Rdr("retrieve_reason").ToString()

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


        '/// Returns an indication whether the Class Data of DOCUMENT_INT_RECEIVER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocumentIntReceiverPara
            ClearData()
            _haveData  = False
            Dim ret As New DocumentIntReceiverPara
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
                        If Convert.IsDBNull(Rdr("organization_id_send")) = False Then ret.organization_id_send = Convert.ToInt64(Rdr("organization_id_send"))
                        If Convert.IsDBNull(Rdr("organization_name_send")) = False Then ret.organization_name_send = Rdr("organization_name_send").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_send")) = False Then ret.organization_appname_send = Rdr("organization_appname_send").ToString()
                        If Convert.IsDBNull(Rdr("send_date")) = False Then ret.send_date = Convert.ToDateTime(Rdr("send_date"))
                        If Convert.IsDBNull(Rdr("sender_officer_username")) = False Then ret.sender_officer_username = Rdr("sender_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("sender_officer_fullname")) = False Then ret.sender_officer_fullname = Rdr("sender_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_status_id")) = False Then ret.receive_status_id = Rdr("receive_status_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_date")) = False Then ret.receive_date = Convert.ToDateTime(Rdr("receive_date"))
                        If Convert.IsDBNull(Rdr("organization_id_receive")) = False Then ret.organization_id_receive = Convert.ToInt64(Rdr("organization_id_receive"))
                        If Convert.IsDBNull(Rdr("organization_name_receive")) = False Then ret.organization_name_receive = Rdr("organization_name_receive").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname_receive")) = False Then ret.organization_appname_receive = Rdr("organization_appname_receive").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_username")) = False Then ret.receiver_officer_username = Rdr("receiver_officer_username").ToString()
                        If Convert.IsDBNull(Rdr("receiver_officer_fullname")) = False Then ret.receiver_officer_fullname = Rdr("receiver_officer_fullname").ToString()
                        If Convert.IsDBNull(Rdr("receive_type_id")) = False Then ret.receive_type_id = Rdr("receive_type_id").ToString()
                        If Convert.IsDBNull(Rdr("receive_objective_id")) = False Then ret.receive_objective_id = Convert.ToInt64(Rdr("receive_objective_id"))
                        If Convert.IsDBNull(Rdr("remarks")) = False Then ret.remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then ret.organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then ret.organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_send_id")) = False Then ret.ref_old_send_id = Rdr("ref_old_send_id").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_receive_id")) = False Then ret.ref_old_receive_id = Rdr("ref_old_receive_id").ToString()
                        If Convert.IsDBNull(Rdr("document_statement")) = False Then ret.document_statement = Rdr("document_statement").ToString()
                        If Convert.IsDBNull(Rdr("document_int_type")) = False Then ret.document_int_type = Convert.ToInt32(Rdr("document_int_type"))
                        If Convert.IsDBNull(Rdr("module_folder_id")) = False Then ret.module_folder_id = Convert.ToInt64(Rdr("module_folder_id"))
                        If Convert.IsDBNull(Rdr("is_forward")) = False Then ret.is_forward = Rdr("is_forward").ToString()
                        If Convert.IsDBNull(Rdr("sendback_reason")) = False Then ret.sendback_reason = Rdr("sendback_reason").ToString()
                        If Convert.IsDBNull(Rdr("retrieve_reason")) = False Then ret.retrieve_reason = Rdr("retrieve_reason").ToString()

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


        'Get Insert Statement for table DOCUMENT_INT_RECEIVER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, DOCUMENT_REGISTER_ID, ORGANIZATION_ID_SEND, ORGANIZATION_NAME_SEND, ORGANIZATION_APPNAME_SEND, SEND_DATE, SENDER_OFFICER_USERNAME, SENDER_OFFICER_FULLNAME, RECEIVE_STATUS_ID, RECEIVE_DATE, ORGANIZATION_ID_RECEIVE, ORGANIZATION_NAME_RECEIVE, ORGANIZATION_APPNAME_RECEIVE, RECEIVER_OFFICER_USERNAME, RECEIVER_OFFICER_FULLNAME, RECEIVE_TYPE_ID, RECEIVE_OBJECTIVE_ID, REMARKS, ORGANIZATION_ID_STORAGE, ORGANIZATION_NAME_STORAGE, REF_OLD_SEND_ID, REF_OLD_RECEIVE_ID, DOCUMENT_STATEMENT, DOCUMENT_INT_TYPE, MODULE_FOLDER_ID, IS_FORWARD, SENDBACK_REASON, RETRIEVE_REASON)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDouble(_DOCUMENT_REGISTER_ID) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_SEND) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_SEND) & ", "
                sql += DB.SetString(_ORGANIZATION_APPNAME_SEND) & ", "
                sql += DB.SetDateTime(_SEND_DATE) & ", "
                sql += DB.SetString(_SENDER_OFFICER_USERNAME) & ", "
                sql += DB.SetString(_SENDER_OFFICER_FULLNAME) & ", "
                sql += DB.SetString(_RECEIVE_STATUS_ID) & ", "
                sql += DB.SetDateTime(_RECEIVE_DATE) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_RECEIVE) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_RECEIVE) & ", "
                sql += DB.SetString(_ORGANIZATION_APPNAME_RECEIVE) & ", "
                sql += DB.SetString(_RECEIVER_OFFICER_USERNAME) & ", "
                sql += DB.SetString(_RECEIVER_OFFICER_FULLNAME) & ", "
                sql += DB.SetString(_RECEIVE_TYPE_ID) & ", "
                sql += DB.SetDouble(_RECEIVE_OBJECTIVE_ID) & ", "
                sql += DB.SetString(_REMARKS) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_STORAGE) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_STORAGE) & ", "
                sql += DB.SetString(_REF_OLD_SEND_ID) & ", "
                sql += DB.SetString(_REF_OLD_RECEIVE_ID) & ", "
                sql += DB.SetString(_DOCUMENT_STATEMENT) & ", "
                sql += DB.SetDouble(_DOCUMENT_INT_TYPE) & ", "
                sql += DB.SetDouble(_MODULE_FOLDER_ID) & ", "
                sql += DB.SetString(_IS_FORWARD) & ", "
                sql += DB.SetString(_SENDBACK_REASON) & ", "
                sql += DB.SetString(_RETRIEVE_REASON)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOCUMENT_INT_RECEIVER
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
                Sql += "ORGANIZATION_ID_SEND = " & DB.SetDouble(_ORGANIZATION_ID_SEND) & ", "
                Sql += "ORGANIZATION_NAME_SEND = " & DB.SetString(_ORGANIZATION_NAME_SEND) & ", "
                Sql += "ORGANIZATION_APPNAME_SEND = " & DB.SetString(_ORGANIZATION_APPNAME_SEND) & ", "
                Sql += "SEND_DATE = " & DB.SetDateTime(_SEND_DATE) & ", "
                Sql += "SENDER_OFFICER_USERNAME = " & DB.SetString(_SENDER_OFFICER_USERNAME) & ", "
                Sql += "SENDER_OFFICER_FULLNAME = " & DB.SetString(_SENDER_OFFICER_FULLNAME) & ", "
                Sql += "RECEIVE_STATUS_ID = " & DB.SetString(_RECEIVE_STATUS_ID) & ", "
                Sql += "RECEIVE_DATE = " & DB.SetDateTime(_RECEIVE_DATE) & ", "
                Sql += "ORGANIZATION_ID_RECEIVE = " & DB.SetDouble(_ORGANIZATION_ID_RECEIVE) & ", "
                Sql += "ORGANIZATION_NAME_RECEIVE = " & DB.SetString(_ORGANIZATION_NAME_RECEIVE) & ", "
                Sql += "ORGANIZATION_APPNAME_RECEIVE = " & DB.SetString(_ORGANIZATION_APPNAME_RECEIVE) & ", "
                Sql += "RECEIVER_OFFICER_USERNAME = " & DB.SetString(_RECEIVER_OFFICER_USERNAME) & ", "
                Sql += "RECEIVER_OFFICER_FULLNAME = " & DB.SetString(_RECEIVER_OFFICER_FULLNAME) & ", "
                Sql += "RECEIVE_TYPE_ID = " & DB.SetString(_RECEIVE_TYPE_ID) & ", "
                Sql += "RECEIVE_OBJECTIVE_ID = " & DB.SetDouble(_RECEIVE_OBJECTIVE_ID) & ", "
                Sql += "REMARKS = " & DB.SetString(_REMARKS) & ", "
                Sql += "ORGANIZATION_ID_STORAGE = " & DB.SetDouble(_ORGANIZATION_ID_STORAGE) & ", "
                Sql += "ORGANIZATION_NAME_STORAGE = " & DB.SetString(_ORGANIZATION_NAME_STORAGE) & ", "
                Sql += "REF_OLD_SEND_ID = " & DB.SetString(_REF_OLD_SEND_ID) & ", "
                Sql += "REF_OLD_RECEIVE_ID = " & DB.SetString(_REF_OLD_RECEIVE_ID) & ", "
                Sql += "DOCUMENT_STATEMENT = " & DB.SetString(_DOCUMENT_STATEMENT) & ", "
                Sql += "DOCUMENT_INT_TYPE = " & DB.SetDouble(_DOCUMENT_INT_TYPE) & ", "
                Sql += "MODULE_FOLDER_ID = " & DB.SetDouble(_MODULE_FOLDER_ID) & ", "
                Sql += "IS_FORWARD = " & DB.SetString(_IS_FORWARD) & ", "
                Sql += "SENDBACK_REASON = " & DB.SetString(_SENDBACK_REASON) & ", "
                Sql += "RETRIEVE_REASON = " & DB.SetString(_RETRIEVE_REASON) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOCUMENT_INT_RECEIVER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOCUMENT_INT_RECEIVER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
