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
    'Represents a transaction for DOCUMENT_IMPORT_LASTSTATUS table Linq.
    '[Create by  on December, 31 2012]
    Public Class DocumentImportLaststatusLinq
        Public sub DocumentImportLaststatusLinq()

        End Sub 
        ' DOCUMENT_IMPORT_LASTSTATUS
        Const _tableName As String = "DOCUMENT_IMPORT_LASTSTATUS"
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
        Dim _BOOK_NO As String = ""
        Dim _REGISTER_DATE As DateTime = New DateTime(1,1,1)
        Dim _EXPECTED_FINISH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _COMPANY_DOC_NO As  String  = ""
        Dim _COMPANY_DOC_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _REFER_TO As  String  = ""
        Dim _GROUP_TITLE_CODE As String = ""
        Dim _TITLE_NAME As String = ""
        Dim _COMPANY_NAME As String = ""
        Dim _COMPANY_SIGN As  String  = ""
        Dim _REMARKS As  String  = ""
        Dim _ORG_CODE_OWNER As String = ""
        Dim _OFFICER_ID_APPORVE As String = ""
        Dim _BOOK_OUT_NO As  String  = ""
        Dim _BOOK_STATUS As String = ""
        Dim _CLOSE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORG_CLOSE_PROCESS As String = ""
        Dim _STAFF_ID_PROCESS As String = ""
        Dim _STAFF_OTHER_PROCESS As  String  = ""
        Dim _REF_WS_IMPORT_DOC_LASTSTATUS As Long = 0

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
        <Column(Storage:="_BOOK_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BOOK_NO() As String
            Get
                Return _BOOK_NO
            End Get
            Set(ByVal value As String)
               _BOOK_NO = value
            End Set
        End Property 
        <Column(Storage:="_REGISTER_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property REGISTER_DATE() As DateTime
            Get
                Return _REGISTER_DATE
            End Get
            Set(ByVal value As DateTime)
               _REGISTER_DATE = value
            End Set
        End Property 
        <Column(Storage:="_EXPECTED_FINISH_DATE", DbType:="DateTime")>  _
        Public Property EXPECTED_FINISH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EXPECTED_FINISH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EXPECTED_FINISH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_DOC_NO", DbType:="VarChar(50)")>  _
        Public Property COMPANY_DOC_NO() As  String 
            Get
                Return _COMPANY_DOC_NO
            End Get
            Set(ByVal value As  String )
               _COMPANY_DOC_NO = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_DOC_DATE", DbType:="DateTime")>  _
        Public Property COMPANY_DOC_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _COMPANY_DOC_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _COMPANY_DOC_DATE = value
            End Set
        End Property 
        <Column(Storage:="_REFER_TO", DbType:="VarChar(50)")>  _
        Public Property REFER_TO() As  String 
            Get
                Return _REFER_TO
            End Get
            Set(ByVal value As  String )
               _REFER_TO = value
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
        <Column(Storage:="_TITLE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property TITLE_NAME() As String
            Get
                Return _TITLE_NAME
            End Get
            Set(ByVal value As String)
               _TITLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_NAME() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_SIGN", DbType:="VarChar(255)")>  _
        Public Property COMPANY_SIGN() As  String 
            Get
                Return _COMPANY_SIGN
            End Get
            Set(ByVal value As  String )
               _COMPANY_SIGN = value
            End Set
        End Property 
        <Column(Storage:="_REMARKS", DbType:="VarChar(255)")>  _
        Public Property REMARKS() As  String 
            Get
                Return _REMARKS
            End Get
            Set(ByVal value As  String )
               _REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_ORG_CODE_OWNER", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_CODE_OWNER() As String
            Get
                Return _ORG_CODE_OWNER
            End Get
            Set(ByVal value As String)
               _ORG_CODE_OWNER = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_ID_APPORVE", DbType:="VarChar(13) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_ID_APPORVE() As String
            Get
                Return _OFFICER_ID_APPORVE
            End Get
            Set(ByVal value As String)
               _OFFICER_ID_APPORVE = value
            End Set
        End Property 
        <Column(Storage:="_BOOK_OUT_NO", DbType:="VarChar(50)")>  _
        Public Property BOOK_OUT_NO() As  String 
            Get
                Return _BOOK_OUT_NO
            End Get
            Set(ByVal value As  String )
               _BOOK_OUT_NO = value
            End Set
        End Property 
        <Column(Storage:="_BOOK_STATUS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BOOK_STATUS() As String
            Get
                Return _BOOK_STATUS
            End Get
            Set(ByVal value As String)
               _BOOK_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_DATE", DbType:="DateTime")>  _
        Public Property CLOSE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _CLOSE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CLOSE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_ORG_CLOSE_PROCESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_CLOSE_PROCESS() As String
            Get
                Return _ORG_CLOSE_PROCESS
            End Get
            Set(ByVal value As String)
               _ORG_CLOSE_PROCESS = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_ID_PROCESS", DbType:="VarChar(13) NOT NULL ",CanBeNull:=false)>  _
        Public Property STAFF_ID_PROCESS() As String
            Get
                Return _STAFF_ID_PROCESS
            End Get
            Set(ByVal value As String)
               _STAFF_ID_PROCESS = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_OTHER_PROCESS", DbType:="VarChar(255)")>  _
        Public Property STAFF_OTHER_PROCESS() As  String 
            Get
                Return _STAFF_OTHER_PROCESS
            End Get
            Set(ByVal value As  String )
               _STAFF_OTHER_PROCESS = value
            End Set
        End Property 
        <Column(Storage:="_REF_WS_IMPORT_DOC_LASTSTATUS", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property REF_WS_IMPORT_DOC_LASTSTATUS() As Long
            Get
                Return _REF_WS_IMPORT_DOC_LASTSTATUS
            End Get
            Set(ByVal value As Long)
               _REF_WS_IMPORT_DOC_LASTSTATUS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _BOOK_NO = ""
            _REGISTER_DATE = New DateTime(1,1,1)
            _EXPECTED_FINISH_DATE = New DateTime(1,1,1)
            _COMPANY_DOC_NO = ""
            _COMPANY_DOC_DATE = New DateTime(1,1,1)
            _REFER_TO = ""
            _GROUP_TITLE_CODE = ""
            _TITLE_NAME = ""
            _COMPANY_NAME = ""
            _COMPANY_SIGN = ""
            _REMARKS = ""
            _ORG_CODE_OWNER = ""
            _OFFICER_ID_APPORVE = ""
            _BOOK_OUT_NO = ""
            _BOOK_STATUS = ""
            _CLOSE_DATE = New DateTime(1,1,1)
            _ORG_CLOSE_PROCESS = ""
            _STAFF_ID_PROCESS = ""
            _STAFF_OTHER_PROCESS = ""
            _REF_WS_IMPORT_DOC_LASTSTATUS = 0
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


        '/// Returns an indication whether the current data is inserted into DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_IMPORT_LASTSTATUS table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOCUMENT_IMPORT_LASTSTATUS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As DocumentImportLaststatusLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOCUMENT_IMPORT_LASTSTATUS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As DocumentImportLaststatusPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified BOOK_NO key is retrieved successfully.
        '/// <param name=cBOOK_NO>The BOOK_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBOOK_NO(cBOOK_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("BOOK_NO = " & DB.SetString(cBOOK_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_IMPORT_LASTSTATUS by specified BOOK_NO key is retrieved successfully.
        '/// <param name=cBOOK_NO>The BOOK_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBOOK_NO(cBOOK_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BOOK_NO = " & DB.SetString(cBOOK_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified REGISTER_DATE key is retrieved successfully.
        '/// <param name=cREGISTER_DATE>The REGISTER_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByREGISTER_DATE(cREGISTER_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("REGISTER_DATE = " & DB.SetDateTime(cREGISTER_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_IMPORT_LASTSTATUS by specified REGISTER_DATE key is retrieved successfully.
        '/// <param name=cREGISTER_DATE>The REGISTER_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByREGISTER_DATE(cREGISTER_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("REGISTER_DATE = " & DB.SetDateTime(cREGISTER_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified GROUP_TITLE_CODE key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_CODE>The GROUP_TITLE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByGROUP_TITLE_CODE(cGROUP_TITLE_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_CODE = " & DB.SetString(cGROUP_TITLE_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_IMPORT_LASTSTATUS by specified GROUP_TITLE_CODE key is retrieved successfully.
        '/// <param name=cGROUP_TITLE_CODE>The GROUP_TITLE_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByGROUP_TITLE_CODE(cGROUP_TITLE_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("GROUP_TITLE_CODE = " & DB.SetString(cGROUP_TITLE_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified ORG_CODE_OWNER key is retrieved successfully.
        '/// <param name=cORG_CODE_OWNER>The ORG_CODE_OWNER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByORG_CODE_OWNER(cORG_CODE_OWNER As String, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_CODE_OWNER = " & DB.SetString(cORG_CODE_OWNER) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_IMPORT_LASTSTATUS by specified ORG_CODE_OWNER key is retrieved successfully.
        '/// <param name=cORG_CODE_OWNER>The ORG_CODE_OWNER key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByORG_CODE_OWNER(cORG_CODE_OWNER As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_CODE_OWNER = " & DB.SetString(cORG_CODE_OWNER) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOCUMENT_IMPORT_LASTSTATUS table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("book_no")) = False Then _book_no = Rdr("book_no").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expected_finish_date")) = False Then _expected_finish_date = Convert.ToDateTime(Rdr("expected_finish_date"))
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then _company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then _company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("refer_to")) = False Then _refer_to = Rdr("refer_to").ToString()
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then _group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then _company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("org_code_owner")) = False Then _org_code_owner = Rdr("org_code_owner").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_apporve")) = False Then _officer_id_apporve = Rdr("officer_id_apporve").ToString()
                        If Convert.IsDBNull(Rdr("book_out_no")) = False Then _book_out_no = Rdr("book_out_no").ToString()
                        If Convert.IsDBNull(Rdr("book_status")) = False Then _book_status = Rdr("book_status").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("org_close_process")) = False Then _org_close_process = Rdr("org_close_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_id_process")) = False Then _staff_id_process = Rdr("staff_id_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_other_process")) = False Then _staff_other_process = Rdr("staff_other_process").ToString()
                        If Convert.IsDBNull(Rdr("ref_ws_import_doc_laststatus")) = False Then _ref_ws_import_doc_laststatus = Convert.ToInt64(Rdr("ref_ws_import_doc_laststatus"))
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


        '/// Returns an indication whether the record of DOCUMENT_IMPORT_LASTSTATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocumentImportLaststatusLinq
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
                        If Convert.IsDBNull(Rdr("book_no")) = False Then _book_no = Rdr("book_no").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expected_finish_date")) = False Then _expected_finish_date = Convert.ToDateTime(Rdr("expected_finish_date"))
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then _company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then _company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("refer_to")) = False Then _refer_to = Rdr("refer_to").ToString()
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then _group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then _company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("org_code_owner")) = False Then _org_code_owner = Rdr("org_code_owner").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_apporve")) = False Then _officer_id_apporve = Rdr("officer_id_apporve").ToString()
                        If Convert.IsDBNull(Rdr("book_out_no")) = False Then _book_out_no = Rdr("book_out_no").ToString()
                        If Convert.IsDBNull(Rdr("book_status")) = False Then _book_status = Rdr("book_status").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("org_close_process")) = False Then _org_close_process = Rdr("org_close_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_id_process")) = False Then _staff_id_process = Rdr("staff_id_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_other_process")) = False Then _staff_other_process = Rdr("staff_other_process").ToString()
                        If Convert.IsDBNull(Rdr("ref_ws_import_doc_laststatus")) = False Then _ref_ws_import_doc_laststatus = Convert.ToInt64(Rdr("ref_ws_import_doc_laststatus"))
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


        '/// Returns an indication whether the Class Data of DOCUMENT_IMPORT_LASTSTATUS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocumentImportLaststatusPara
            ClearData()
            _haveData  = False
            Dim ret As New DocumentImportLaststatusPara
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
                        If Convert.IsDBNull(Rdr("book_no")) = False Then ret.book_no = Rdr("book_no").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then ret.register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expected_finish_date")) = False Then ret.expected_finish_date = Convert.ToDateTime(Rdr("expected_finish_date"))
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then ret.company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then ret.company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("refer_to")) = False Then ret.refer_to = Rdr("refer_to").ToString()
                        If Convert.IsDBNull(Rdr("group_title_code")) = False Then ret.group_title_code = Rdr("group_title_code").ToString()
                        If Convert.IsDBNull(Rdr("title_name")) = False Then ret.title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then ret.company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then ret.company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then ret.remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("org_code_owner")) = False Then ret.org_code_owner = Rdr("org_code_owner").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_apporve")) = False Then ret.officer_id_apporve = Rdr("officer_id_apporve").ToString()
                        If Convert.IsDBNull(Rdr("book_out_no")) = False Then ret.book_out_no = Rdr("book_out_no").ToString()
                        If Convert.IsDBNull(Rdr("book_status")) = False Then ret.book_status = Rdr("book_status").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then ret.close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("org_close_process")) = False Then ret.org_close_process = Rdr("org_close_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_id_process")) = False Then ret.staff_id_process = Rdr("staff_id_process").ToString()
                        If Convert.IsDBNull(Rdr("staff_other_process")) = False Then ret.staff_other_process = Rdr("staff_other_process").ToString()
                        If Convert.IsDBNull(Rdr("ref_ws_import_doc_laststatus")) = False Then ret.ref_ws_import_doc_laststatus = Convert.ToInt64(Rdr("ref_ws_import_doc_laststatus"))

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


        'Get Insert Statement for table DOCUMENT_IMPORT_LASTSTATUS
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, BOOK_NO, REGISTER_DATE, EXPECTED_FINISH_DATE, COMPANY_DOC_NO, COMPANY_DOC_DATE, REFER_TO, GROUP_TITLE_CODE, TITLE_NAME, COMPANY_NAME, COMPANY_SIGN, REMARKS, ORG_CODE_OWNER, OFFICER_ID_APPORVE, BOOK_OUT_NO, BOOK_STATUS, CLOSE_DATE, ORG_CLOSE_PROCESS, STAFF_ID_PROCESS, STAFF_OTHER_PROCESS, REF_WS_IMPORT_DOC_LASTSTATUS)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_BOOK_NO) & ", "
                sql += DB.SetDateTime(_REGISTER_DATE) & ", "
                sql += DB.SetDateTime(_EXPECTED_FINISH_DATE) & ", "
                sql += DB.SetString(_COMPANY_DOC_NO) & ", "
                sql += DB.SetDateTime(_COMPANY_DOC_DATE) & ", "
                sql += DB.SetString(_REFER_TO) & ", "
                sql += DB.SetString(_GROUP_TITLE_CODE) & ", "
                sql += DB.SetString(_TITLE_NAME) & ", "
                sql += DB.SetString(_COMPANY_NAME) & ", "
                sql += DB.SetString(_COMPANY_SIGN) & ", "
                sql += DB.SetString(_REMARKS) & ", "
                sql += DB.SetString(_ORG_CODE_OWNER) & ", "
                sql += DB.SetString(_OFFICER_ID_APPORVE) & ", "
                sql += DB.SetString(_BOOK_OUT_NO) & ", "
                sql += DB.SetString(_BOOK_STATUS) & ", "
                sql += DB.SetDateTime(_CLOSE_DATE) & ", "
                sql += DB.SetString(_ORG_CLOSE_PROCESS) & ", "
                sql += DB.SetString(_STAFF_ID_PROCESS) & ", "
                sql += DB.SetString(_STAFF_OTHER_PROCESS) & ", "
                sql += DB.SetDouble(_REF_WS_IMPORT_DOC_LASTSTATUS)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOCUMENT_IMPORT_LASTSTATUS
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "BOOK_NO = " & DB.SetString(_BOOK_NO) & ", "
                Sql += "REGISTER_DATE = " & DB.SetDateTime(_REGISTER_DATE) & ", "
                Sql += "EXPECTED_FINISH_DATE = " & DB.SetDateTime(_EXPECTED_FINISH_DATE) & ", "
                Sql += "COMPANY_DOC_NO = " & DB.SetString(_COMPANY_DOC_NO) & ", "
                Sql += "COMPANY_DOC_DATE = " & DB.SetDateTime(_COMPANY_DOC_DATE) & ", "
                Sql += "REFER_TO = " & DB.SetString(_REFER_TO) & ", "
                Sql += "GROUP_TITLE_CODE = " & DB.SetString(_GROUP_TITLE_CODE) & ", "
                Sql += "TITLE_NAME = " & DB.SetString(_TITLE_NAME) & ", "
                Sql += "COMPANY_NAME = " & DB.SetString(_COMPANY_NAME) & ", "
                Sql += "COMPANY_SIGN = " & DB.SetString(_COMPANY_SIGN) & ", "
                Sql += "REMARKS = " & DB.SetString(_REMARKS) & ", "
                Sql += "ORG_CODE_OWNER = " & DB.SetString(_ORG_CODE_OWNER) & ", "
                Sql += "OFFICER_ID_APPORVE = " & DB.SetString(_OFFICER_ID_APPORVE) & ", "
                Sql += "BOOK_OUT_NO = " & DB.SetString(_BOOK_OUT_NO) & ", "
                Sql += "BOOK_STATUS = " & DB.SetString(_BOOK_STATUS) & ", "
                Sql += "CLOSE_DATE = " & DB.SetDateTime(_CLOSE_DATE) & ", "
                Sql += "ORG_CLOSE_PROCESS = " & DB.SetString(_ORG_CLOSE_PROCESS) & ", "
                Sql += "STAFF_ID_PROCESS = " & DB.SetString(_STAFF_ID_PROCESS) & ", "
                Sql += "STAFF_OTHER_PROCESS = " & DB.SetString(_STAFF_OTHER_PROCESS) & ", "
                Sql += "REF_WS_IMPORT_DOC_LASTSTATUS = " & DB.SetDouble(_REF_WS_IMPORT_DOC_LASTSTATUS) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOCUMENT_IMPORT_LASTSTATUS
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOCUMENT_IMPORT_LASTSTATUS
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
