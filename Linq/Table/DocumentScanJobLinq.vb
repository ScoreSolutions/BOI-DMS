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
    'Represents a transaction for DOCUMENT_SCAN_JOB table Linq.
    '[Create by  on July, 17 2012]
    Public Class DocumentScanJobLinq
        Public sub DocumentScanJobLinq()

        End Sub 
        ' DOCUMENT_SCAN_JOB
        Const _tableName As String = "DOCUMENT_SCAN_JOB"
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
        Dim _JOB_START_DATE As DateTime = New DateTime(1,1,1)
        Dim _CLIENT_IP As String = ""
        Dim _CLIENT_PAGE As String = ""
        Dim _CLIENT_BROWSER As String = ""
        Dim _CLIENT_SESSIONID As String = ""
        Dim _REF_ID As Long = 0
        Dim _START_STATUS As Char = "1"

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
        <Column(Storage:="_JOB_START_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property JOB_START_DATE() As DateTime
            Get
                Return _JOB_START_DATE
            End Get
            Set(ByVal value As DateTime)
               _JOB_START_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_IP", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_IP() As String
            Get
                Return _CLIENT_IP
            End Get
            Set(ByVal value As String)
               _CLIENT_IP = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_PAGE", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_PAGE() As String
            Get
                Return _CLIENT_PAGE
            End Get
            Set(ByVal value As String)
               _CLIENT_PAGE = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_BROWSER", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_BROWSER() As String
            Get
                Return _CLIENT_BROWSER
            End Get
            Set(ByVal value As String)
               _CLIENT_BROWSER = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_SESSIONID", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_SESSIONID() As String
            Get
                Return _CLIENT_SESSIONID
            End Get
            Set(ByVal value As String)
               _CLIENT_SESSIONID = value
            End Set
        End Property 
        <Column(Storage:="_REF_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property REF_ID() As Long
            Get
                Return _REF_ID
            End Get
            Set(ByVal value As Long)
               _REF_ID = value
            End Set
        End Property 
        <Column(Storage:="_START_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property START_STATUS() As Char
            Get
                Return _START_STATUS
            End Get
            Set(ByVal value As Char)
               _START_STATUS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _JOB_START_DATE = New DateTime(1,1,1)
            _CLIENT_IP = ""
            _CLIENT_PAGE = ""
            _CLIENT_BROWSER = ""
            _CLIENT_SESSIONID = ""
            _REF_ID = 0
            _START_STATUS = ""
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


        '/// Returns an indication whether the current data is inserted into DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_SCAN_JOB table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_SCAN_JOB by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOCUMENT_SCAN_JOB by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As DocumentScanJobLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOCUMENT_SCAN_JOB by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As DocumentScanJobPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_SCAN_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOCUMENT_SCAN_JOB table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_SCAN_JOB by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("job_start_date")) = False Then _job_start_date = Convert.ToDateTime(Rdr("job_start_date"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("client_page")) = False Then _client_page = Rdr("client_page").ToString()
                        If Convert.IsDBNull(Rdr("client_browser")) = False Then _client_browser = Rdr("client_browser").ToString()
                        If Convert.IsDBNull(Rdr("client_sessionid")) = False Then _client_sessionid = Rdr("client_sessionid").ToString()
                        If Convert.IsDBNull(Rdr("ref_id")) = False Then _ref_id = Convert.ToInt64(Rdr("ref_id"))
                        If Convert.IsDBNull(Rdr("start_status")) = False Then _start_status = Rdr("start_status").ToString()
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


        '/// Returns an indication whether the record of DOCUMENT_SCAN_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocumentScanJobLinq
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
                        If Convert.IsDBNull(Rdr("job_start_date")) = False Then _job_start_date = Convert.ToDateTime(Rdr("job_start_date"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("client_page")) = False Then _client_page = Rdr("client_page").ToString()
                        If Convert.IsDBNull(Rdr("client_browser")) = False Then _client_browser = Rdr("client_browser").ToString()
                        If Convert.IsDBNull(Rdr("client_sessionid")) = False Then _client_sessionid = Rdr("client_sessionid").ToString()
                        If Convert.IsDBNull(Rdr("ref_id")) = False Then _ref_id = Convert.ToInt64(Rdr("ref_id"))
                        If Convert.IsDBNull(Rdr("start_status")) = False Then _start_status = Rdr("start_status").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : DOCUMENT_SCAN_TEMP Column :document_scan_job_id
                        Dim DocumentScanTemp_document_scan_job_idItem As New DocumentScanTempLinq
                        _DOCUMENT_SCAN_TEMP_document_scan_job_id = DocumentScanTemp_document_scan_job_idItem.GetDataList("document_scan_job_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of DOCUMENT_SCAN_JOB by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocumentScanJobPara
            ClearData()
            _haveData  = False
            Dim ret As New DocumentScanJobPara
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
                        If Convert.IsDBNull(Rdr("job_start_date")) = False Then ret.job_start_date = Convert.ToDateTime(Rdr("job_start_date"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then ret.client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("client_page")) = False Then ret.client_page = Rdr("client_page").ToString()
                        If Convert.IsDBNull(Rdr("client_browser")) = False Then ret.client_browser = Rdr("client_browser").ToString()
                        If Convert.IsDBNull(Rdr("client_sessionid")) = False Then ret.client_sessionid = Rdr("client_sessionid").ToString()
                        If Convert.IsDBNull(Rdr("ref_id")) = False Then ret.ref_id = Convert.ToInt64(Rdr("ref_id"))
                        If Convert.IsDBNull(Rdr("start_status")) = False Then ret.start_status = Rdr("start_status").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : DOCUMENT_SCAN_TEMP Column :document_scan_job_id
                        Dim DocumentScanTemp_document_scan_job_idItem As New DocumentScanTempLinq
                        _DOCUMENT_SCAN_TEMP_document_scan_job_id = DocumentScanTemp_document_scan_job_idItem.GetDataList("document_scan_job_id = " & ret.id, "", Nothing)
                        ret.CHILD_DOCUMENT_SCAN_TEMP_document_scan_job_id = _DOCUMENT_SCAN_TEMP_document_scan_job_id


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


        'Get Insert Statement for table DOCUMENT_SCAN_JOB
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, JOB_START_DATE, CLIENT_IP, CLIENT_PAGE, CLIENT_BROWSER, CLIENT_SESSIONID, REF_ID, START_STATUS)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetDateTime(_JOB_START_DATE) & ", "
                sql += DB.SetString(_CLIENT_IP) & ", "
                sql += DB.SetString(_CLIENT_PAGE) & ", "
                sql += DB.SetString(_CLIENT_BROWSER) & ", "
                sql += DB.SetString(_CLIENT_SESSIONID) & ", "
                sql += DB.SetDouble(_REF_ID) & ", "
                sql += DB.SetString(_START_STATUS)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOCUMENT_SCAN_JOB
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "JOB_START_DATE = " & DB.SetDateTime(_JOB_START_DATE) & ", "
                Sql += "CLIENT_IP = " & DB.SetString(_CLIENT_IP) & ", "
                Sql += "CLIENT_PAGE = " & DB.SetString(_CLIENT_PAGE) & ", "
                Sql += "CLIENT_BROWSER = " & DB.SetString(_CLIENT_BROWSER) & ", "
                Sql += "CLIENT_SESSIONID = " & DB.SetString(_CLIENT_SESSIONID) & ", "
                Sql += "REF_ID = " & DB.SetDouble(_REF_ID) & ", "
                Sql += "START_STATUS = " & DB.SetString(_START_STATUS) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOCUMENT_SCAN_JOB
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOCUMENT_SCAN_JOB
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _DOCUMENT_SCAN_TEMP_document_scan_job_id As DataTable

       Public Property CHILD_DOCUMENT_SCAN_TEMP_document_scan_job_id() As DataTable
           Get
               Return _DOCUMENT_SCAN_TEMP_document_scan_job_id
           End Get
           Set(ByVal value As DataTable)
               _DOCUMENT_SCAN_TEMP_document_scan_job_id = value
           End Set
       End Property
    End Class
End Namespace
