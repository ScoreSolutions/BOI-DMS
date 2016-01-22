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
    'Represents a transaction for GROUP_TITLE table Linq.
    '[Create by  on January, 7 2013]
    Public Class GroupTitleLinq
        Public sub GroupTitleLinq()

        End Sub 
        ' GROUP_TITLE
        Const _tableName As String = "GROUP_TITLE"
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
        Dim _GROUP_TITLE_CODE As String = ""
        Dim _GROUP_TITLE_NAME As String = ""
        Dim _GROUP_TITLE_TYPE_ID As Long = 0
        Dim _STD_PROC_PERIOD As  System.Nullable(Of Double)  = 0
        Dim _MAX_PROC_PERIOD As  System.Nullable(Of Double)  = 0
        Dim _SUBJECT_ID As  System.Nullable(Of Long)  = 0
        Dim _IS_GEN_REQ As  System.Nullable(Of Char)  = ""
        Dim _DOC_SYS_ID As Long = 0
        Dim _WKIN_CODE As  String  = ""
        Dim _WKIN_GROUP_REP As  String  = ""
        Dim _WKIN_GROUP_CODE As  String  = ""
        Dim _DUE_STEP1 As  System.Nullable(Of Long)  = 0
        Dim _DUE_STEP2 As  System.Nullable(Of Long)  = 0
        Dim _DUE_STEP3 As  System.Nullable(Of Long)  = 0
        Dim _DIV_STEP1 As  String  = ""
        Dim _DIV_STEP2 As  String  = ""
        Dim _DIV_STEP3 As  String  = ""
        Dim _ACTIVE As Char = "Y"
        Dim _REF_OLD_ID As  String  = ""
        Dim _NO_DEFAULT_TITLE As Char = "N"

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
        <Column(Storage:="_GROUP_TITLE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_CODE() As String
            Get
                Return _GROUP_TITLE_CODE
            End Get
            Set(ByVal value As String)
               _GROUP_TITLE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_TITLE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_NAME() As String
            Get
                Return _GROUP_TITLE_NAME
            End Get
            Set(ByVal value As String)
               _GROUP_TITLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_TITLE_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_TYPE_ID() As Long
            Get
                Return _GROUP_TITLE_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _GROUP_TITLE_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_STD_PROC_PERIOD", DbType:="Float")>  _
        Public Property STD_PROC_PERIOD() As  System.Nullable(Of Double) 
            Get
                Return _STD_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Double) )
               _STD_PROC_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_MAX_PROC_PERIOD", DbType:="Float")>  _
        Public Property MAX_PROC_PERIOD() As  System.Nullable(Of Double) 
            Get
                Return _MAX_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Double) )
               _MAX_PROC_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_SUBJECT_ID", DbType:="BigInt")>  _
        Public Property SUBJECT_ID() As  System.Nullable(Of Long) 
            Get
                Return _SUBJECT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SUBJECT_ID = value
            End Set
        End Property 
        <Column(Storage:="_IS_GEN_REQ", DbType:="Char(1)")>  _
        Public Property IS_GEN_REQ() As  System.Nullable(Of Char) 
            Get
                Return _IS_GEN_REQ
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_GEN_REQ = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SYS_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_SYS_ID() As Long
            Get
                Return _DOC_SYS_ID
            End Get
            Set(ByVal value As Long)
               _DOC_SYS_ID = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_CODE", DbType:="VarChar(8)")>  _
        Public Property WKIN_CODE() As  String 
            Get
                Return _WKIN_CODE
            End Get
            Set(ByVal value As  String )
               _WKIN_CODE = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_GROUP_REP", DbType:="VarChar(1)")>  _
        Public Property WKIN_GROUP_REP() As  String 
            Get
                Return _WKIN_GROUP_REP
            End Get
            Set(ByVal value As  String )
               _WKIN_GROUP_REP = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_GROUP_CODE", DbType:="VarChar(8)")>  _
        Public Property WKIN_GROUP_CODE() As  String 
            Get
                Return _WKIN_GROUP_CODE
            End Get
            Set(ByVal value As  String )
               _WKIN_GROUP_CODE = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP1", DbType:="Int")>  _
        Public Property DUE_STEP1() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP1
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP1 = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP2", DbType:="Int")>  _
        Public Property DUE_STEP2() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP2
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP2 = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP3", DbType:="Int")>  _
        Public Property DUE_STEP3() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP3
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP3 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP1", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP1() As  String 
            Get
                Return _DIV_STEP1
            End Get
            Set(ByVal value As  String )
               _DIV_STEP1 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP2", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP2() As  String 
            Get
                Return _DIV_STEP2
            End Get
            Set(ByVal value As  String )
               _DIV_STEP2 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP3", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP3() As  String 
            Get
                Return _DIV_STEP3
            End Get
            Set(ByVal value As  String )
               _DIV_STEP3 = value
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
        <Column(Storage:="_REF_OLD_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_ID() As  String 
            Get
                Return _REF_OLD_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_ID = value
            End Set
        End Property 
        <Column(Storage:="_NO_DEFAULT_TITLE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property NO_DEFAULT_TITLE() As Char
            Get
                Return _NO_DEFAULT_TITLE
            End Get
            Set(ByVal value As Char)
               _NO_DEFAULT_TITLE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _GROUP_TITLE_CODE = ""
            _GROUP_TITLE_NAME = ""
            _GROUP_TITLE_TYPE_ID = 0
            _STD_PROC_PERIOD = 0
            _MAX_PROC_PERIOD = 0
            _SUBJECT_ID = 0
            _IS_GEN_REQ = ""
            _DOC_SYS_ID = 0
            _WKIN_CODE = ""
            _WKIN_GROUP_REP = ""
            _WKIN_GROUP_CODE = ""
            _DUE_STEP1 = 0
            _DUE_STEP2 = 0
            _DUE_STEP3 = 0
            _DIV_STEP1 = ""
            _DIV_STEP2 = ""
            _DIV_STEP3 = ""
            _ACTIVE = ""
            _REF_OLD_ID = ""
            _NO_DEFAULT_TITLE = ""
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


        '/// Returns an indication whether the current data is inserted into GROUP_TITLE table successfully.
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


        '/// Returns an indication whether the current data is updated to GROUP_TITLE table successfully.
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


        '/// Returns an indication whether the current data is updated to GROUP_TITLE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from GROUP_TITLE table successfully.
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


        '/// Returns an indication whether the record of GROUP_TITLE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of GROUP_TITLE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As GroupTitleLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of GROUP_TITLE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As GroupTitlePara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE by specified GROUP_TITLE_CODE key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_CODE>The GROUP_TITLE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByGROUP_TITLE_CODE(cGROUP_TITLE_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_CODE = " & DB.SetString(cGROUP_TITLE_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of GROUP_TITLE by specified GROUP_TITLE_CODE key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_CODE>The GROUP_TITLE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByGROUP_TITLE_CODE(cGROUP_TITLE_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_CODE = " & DB.SetString(cGROUP_TITLE_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE by specified GROUP_TITLE_NAME key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_NAME>The GROUP_TITLE_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByGROUP_TITLE_NAME(cGROUP_TITLE_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_NAME = " & DB.SetString(cGROUP_TITLE_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of GROUP_TITLE by specified GROUP_TITLE_NAME key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_NAME>The GROUP_TITLE_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByGROUP_TITLE_NAME(cGROUP_TITLE_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_NAME = " & DB.SetString(cGROUP_TITLE_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into GROUP_TITLE table successfully.
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
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to GROUP_TITLE table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlUpdate & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from GROUP_TITLE table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlDelete & tmpWhere
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of GROUP_TITLE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
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
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then _group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("group_title_name")) = False Then _group_title_name = Rdr("group_title_name").ToString()
                        If Convert.IsDBNull(Rdr("group_title_type_id")) = False Then _group_title_type_id = Convert.ToInt64(Rdr("group_title_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then _std_proc_period = Convert.ToDouble(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then _max_proc_period = Convert.ToDouble(Rdr("max_proc_period"))
                        If Convert.IsDBNull(Rdr("subject_id")) = False Then _subject_id = Convert.ToInt64(Rdr("subject_id"))
                        If Convert.IsDBNull(Rdr("is_gen_req")) = False Then _is_gen_req = Rdr("is_gen_req").ToString()
                        If Convert.IsDBNull(Rdr("doc_sys_id")) = False Then _doc_sys_id = Convert.ToInt64(Rdr("doc_sys_id"))
                        If Convert.IsDBNull(Rdr("wkin_code")) = False Then _wkin_code = Rdr("wkin_code").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_rep")) = False Then _wkin_group_rep = Rdr("wkin_group_rep").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_code")) = False Then _wkin_group_code = Rdr("wkin_group_code").ToString()
                        If Convert.IsDBNull(Rdr("due_step1")) = False Then _due_step1 = Convert.ToInt32(Rdr("due_step1"))
                        If Convert.IsDBNull(Rdr("due_step2")) = False Then _due_step2 = Convert.ToInt32(Rdr("due_step2"))
                        If Convert.IsDBNull(Rdr("due_step3")) = False Then _due_step3 = Convert.ToInt32(Rdr("due_step3"))
                        If Convert.IsDBNull(Rdr("div_step1")) = False Then _div_step1 = Rdr("div_step1").ToString()
                        If Convert.IsDBNull(Rdr("div_step2")) = False Then _div_step2 = Rdr("div_step2").ToString()
                        If Convert.IsDBNull(Rdr("div_step3")) = False Then _div_step3 = Rdr("div_step3").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("no_default_title")) = False Then _no_default_title = Rdr("no_default_title").ToString()
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


        '/// Returns an indication whether the record of GROUP_TITLE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As GroupTitleLinq
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
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then _group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("group_title_name")) = False Then _group_title_name = Rdr("group_title_name").ToString()
                        If Convert.IsDBNull(Rdr("group_title_type_id")) = False Then _group_title_type_id = Convert.ToInt64(Rdr("group_title_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then _std_proc_period = Convert.ToDouble(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then _max_proc_period = Convert.ToDouble(Rdr("max_proc_period"))
                        If Convert.IsDBNull(Rdr("subject_id")) = False Then _subject_id = Convert.ToInt64(Rdr("subject_id"))
                        If Convert.IsDBNull(Rdr("is_gen_req")) = False Then _is_gen_req = Rdr("is_gen_req").ToString()
                        If Convert.IsDBNull(Rdr("doc_sys_id")) = False Then _doc_sys_id = Convert.ToInt64(Rdr("doc_sys_id"))
                        If Convert.IsDBNull(Rdr("wkin_code")) = False Then _wkin_code = Rdr("wkin_code").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_rep")) = False Then _wkin_group_rep = Rdr("wkin_group_rep").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_code")) = False Then _wkin_group_code = Rdr("wkin_group_code").ToString()
                        If Convert.IsDBNull(Rdr("due_step1")) = False Then _due_step1 = Convert.ToInt32(Rdr("due_step1"))
                        If Convert.IsDBNull(Rdr("due_step2")) = False Then _due_step2 = Convert.ToInt32(Rdr("due_step2"))
                        If Convert.IsDBNull(Rdr("due_step3")) = False Then _due_step3 = Convert.ToInt32(Rdr("due_step3"))
                        If Convert.IsDBNull(Rdr("div_step1")) = False Then _div_step1 = Rdr("div_step1").ToString()
                        If Convert.IsDBNull(Rdr("div_step2")) = False Then _div_step2 = Rdr("div_step2").ToString()
                        If Convert.IsDBNull(Rdr("div_step3")) = False Then _div_step3 = Rdr("div_step3").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("no_default_title")) = False Then _no_default_title = Rdr("no_default_title").ToString()
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


        '/// Returns an indication whether the Class Data of GROUP_TITLE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As GroupTitlePara
            ClearData()
            _haveData  = False
            Dim ret As New GroupTitlePara
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
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then ret.group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("group_title_name")) = False Then ret.group_title_name = Rdr("group_title_name").ToString()
                        If Convert.IsDBNull(Rdr("group_title_type_id")) = False Then ret.group_title_type_id = Convert.ToInt64(Rdr("group_title_type_id"))
                        If Convert.IsDBNull(Rdr("std_proc_period")) = False Then ret.std_proc_period = Convert.ToDouble(Rdr("std_proc_period"))
                        If Convert.IsDBNull(Rdr("max_proc_period")) = False Then ret.max_proc_period = Convert.ToDouble(Rdr("max_proc_period"))
                        If Convert.IsDBNull(Rdr("subject_id")) = False Then ret.subject_id = Convert.ToInt64(Rdr("subject_id"))
                        If Convert.IsDBNull(Rdr("is_gen_req")) = False Then ret.is_gen_req = Rdr("is_gen_req").ToString()
                        If Convert.IsDBNull(Rdr("doc_sys_id")) = False Then ret.doc_sys_id = Convert.ToInt64(Rdr("doc_sys_id"))
                        If Convert.IsDBNull(Rdr("wkin_code")) = False Then ret.wkin_code = Rdr("wkin_code").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_rep")) = False Then ret.wkin_group_rep = Rdr("wkin_group_rep").ToString()
                        If Convert.IsDBNull(Rdr("wkin_group_code")) = False Then ret.wkin_group_code = Rdr("wkin_group_code").ToString()
                        If Convert.IsDBNull(Rdr("due_step1")) = False Then ret.due_step1 = Convert.ToInt32(Rdr("due_step1"))
                        If Convert.IsDBNull(Rdr("due_step2")) = False Then ret.due_step2 = Convert.ToInt32(Rdr("due_step2"))
                        If Convert.IsDBNull(Rdr("due_step3")) = False Then ret.due_step3 = Convert.ToInt32(Rdr("due_step3"))
                        If Convert.IsDBNull(Rdr("div_step1")) = False Then ret.div_step1 = Rdr("div_step1").ToString()
                        If Convert.IsDBNull(Rdr("div_step2")) = False Then ret.div_step2 = Rdr("div_step2").ToString()
                        If Convert.IsDBNull(Rdr("div_step3")) = False Then ret.div_step3 = Rdr("div_step3").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then ret.ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("no_default_title")) = False Then ret.no_default_title = Rdr("no_default_title").ToString()

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


        'Get Insert Statement for table GROUP_TITLE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, GROUP_TITLE_CODE, GROUP_TITLE_NAME, GROUP_TITLE_TYPE_ID, STD_PROC_PERIOD, MAX_PROC_PERIOD, SUBJECT_ID, IS_GEN_REQ, DOC_SYS_ID, WKIN_CODE, WKIN_GROUP_REP, WKIN_GROUP_CODE, DUE_STEP1, DUE_STEP2, DUE_STEP3, DIV_STEP1, DIV_STEP2, DIV_STEP3, ACTIVE, REF_OLD_ID, NO_DEFAULT_TITLE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_GROUP_TITLE_CODE) & ", "
                sql += DB.SetString(_GROUP_TITLE_NAME) & ", "
                sql += DB.SetDouble(_GROUP_TITLE_TYPE_ID) & ", "
                sql += DB.SetDouble(_STD_PROC_PERIOD) & ", "
                sql += DB.SetDouble(_MAX_PROC_PERIOD) & ", "
                sql += DB.SetDouble(_SUBJECT_ID) & ", "
                sql += DB.SetString(_IS_GEN_REQ) & ", "
                sql += DB.SetDouble(_DOC_SYS_ID) & ", "
                sql += DB.SetString(_WKIN_CODE) & ", "
                sql += DB.SetString(_WKIN_GROUP_REP) & ", "
                sql += DB.SetString(_WKIN_GROUP_CODE) & ", "
                sql += DB.SetDouble(_DUE_STEP1) & ", "
                sql += DB.SetDouble(_DUE_STEP2) & ", "
                sql += DB.SetDouble(_DUE_STEP3) & ", "
                sql += DB.SetString(_DIV_STEP1) & ", "
                sql += DB.SetString(_DIV_STEP2) & ", "
                sql += DB.SetString(_DIV_STEP3) & ", "
                sql += DB.SetString(_ACTIVE) & ", "
                sql += DB.SetString(_REF_OLD_ID) & ", "
                sql += DB.SetString(_NO_DEFAULT_TITLE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table GROUP_TITLE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "GROUP_TITLE_CODE = " & DB.SetString(_GROUP_TITLE_CODE) & ", "
                Sql += "GROUP_TITLE_NAME = " & DB.SetString(_GROUP_TITLE_NAME) & ", "
                Sql += "GROUP_TITLE_TYPE_ID = " & DB.SetDouble(_GROUP_TITLE_TYPE_ID) & ", "
                Sql += "STD_PROC_PERIOD = " & DB.SetDouble(_STD_PROC_PERIOD) & ", "
                Sql += "MAX_PROC_PERIOD = " & DB.SetDouble(_MAX_PROC_PERIOD) & ", "
                Sql += "SUBJECT_ID = " & DB.SetDouble(_SUBJECT_ID) & ", "
                Sql += "IS_GEN_REQ = " & DB.SetString(_IS_GEN_REQ) & ", "
                Sql += "DOC_SYS_ID = " & DB.SetDouble(_DOC_SYS_ID) & ", "
                Sql += "WKIN_CODE = " & DB.SetString(_WKIN_CODE) & ", "
                Sql += "WKIN_GROUP_REP = " & DB.SetString(_WKIN_GROUP_REP) & ", "
                Sql += "WKIN_GROUP_CODE = " & DB.SetString(_WKIN_GROUP_CODE) & ", "
                Sql += "DUE_STEP1 = " & DB.SetDouble(_DUE_STEP1) & ", "
                Sql += "DUE_STEP2 = " & DB.SetDouble(_DUE_STEP2) & ", "
                Sql += "DUE_STEP3 = " & DB.SetDouble(_DUE_STEP3) & ", "
                Sql += "DIV_STEP1 = " & DB.SetString(_DIV_STEP1) & ", "
                Sql += "DIV_STEP2 = " & DB.SetString(_DIV_STEP2) & ", "
                Sql += "DIV_STEP3 = " & DB.SetString(_DIV_STEP3) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) & ", "
                Sql += "REF_OLD_ID = " & DB.SetString(_REF_OLD_ID) & ", "
                Sql += "NO_DEFAULT_TITLE = " & DB.SetString(_NO_DEFAULT_TITLE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table GROUP_TITLE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table GROUP_TITLE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _GROUP_TITLE_COMPANY_DEFAULT_group_title_id As DataTable
       Dim _GROUP_TITLE_ORG_RESPONSE_group_title_id As DataTable
       Dim _KPI_ALL_GROUP_TITLE_group_title_id As DataTable
       Dim _SEND_STORAGE_GROUP_TITLE_group_title_id As DataTable

       Public Property CHILD_GROUP_TITLE_COMPANY_DEFAULT_group_title_id() As DataTable
           Get
               'Child Table Name : GROUP_TITLE_COMPANY_DEFAULT Column :group_title_id
               Dim trans As New Linq.Common.Utilities.TransactionDB
               Dim GroupTitleCompanyDefaultItem As New GroupTitleCompanyDefaultLinq
               _GROUP_TITLE_COMPANY_DEFAULT_group_title_id = GroupTitleCompanyDefaultItem.GetDataList("group_title_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               GroupTitleCompanyDefaultItem = Nothing
               Return _GROUP_TITLE_COMPANY_DEFAULT_group_title_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_COMPANY_DEFAULT_group_title_id = value
           End Set
       End Property
       Public Property CHILD_GROUP_TITLE_ORG_RESPONSE_group_title_id() As DataTable
           Get
               'Child Table Name : GROUP_TITLE_ORG_RESPONSE Column :group_title_id
               Dim trans As New Linq.Common.Utilities.TransactionDB
               Dim GroupTitleOrgResponseItem As New GroupTitleOrgResponseLinq
               _GROUP_TITLE_ORG_RESPONSE_group_title_id = GroupTitleOrgResponseItem.GetDataList("group_title_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               GroupTitleOrgResponseItem = Nothing
               Return _GROUP_TITLE_ORG_RESPONSE_group_title_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_ORG_RESPONSE_group_title_id = value
           End Set
       End Property
       Public Property CHILD_KPI_ALL_GROUP_TITLE_group_title_id() As DataTable
           Get
               'Child Table Name : KPI_ALL_GROUP_TITLE Column :group_title_id
               Dim trans As New Linq.Common.Utilities.TransactionDB
               Dim KpiAllGroupTitleItem As New KpiAllGroupTitleLinq
               _KPI_ALL_GROUP_TITLE_group_title_id = KpiAllGroupTitleItem.GetDataList("group_title_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               KpiAllGroupTitleItem = Nothing
               Return _KPI_ALL_GROUP_TITLE_group_title_id
           End Get
           Set(ByVal value As DataTable)
               _KPI_ALL_GROUP_TITLE_group_title_id = value
           End Set
       End Property
       Public Property CHILD_SEND_STORAGE_GROUP_TITLE_group_title_id() As DataTable
           Get
               'Child Table Name : SEND_STORAGE_GROUP_TITLE Column :group_title_id
               Dim trans As New Linq.Common.Utilities.TransactionDB
               Dim SendStorageGroupTitleItem As New SendStorageGroupTitleLinq
               _SEND_STORAGE_GROUP_TITLE_group_title_id = SendStorageGroupTitleItem.GetDataList("group_title_id = " & _ID, "", trans.Trans)
               trans.CommitTransaction()
               SendStorageGroupTitleItem = Nothing
               Return _SEND_STORAGE_GROUP_TITLE_group_title_id
           End Get
           Set(ByVal value As DataTable)
               _SEND_STORAGE_GROUP_TITLE_group_title_id = value
           End Set
       End Property
    End Class
End Namespace
