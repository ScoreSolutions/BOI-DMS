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
    'Represents a transaction for OFFICER table Linq.
    '[Create by  on June, 16 2012]
    Public Class OfficerLinq
        Public sub OfficerLinq()

        End Sub 
        ' OFFICER
        Const _tableName As String = "OFFICER"
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
        Dim _USERNAME As  String  = ""
        Dim _PWD As  String  = ""
        Dim _OFFICER_CODE As  String  = ""
        Dim _FIRST_NAME As  String  = ""
        Dim _LAST_NAME As  String  = ""
        Dim _FIRST_NAME_THAI As  String  = ""
        Dim _LAST_NAME_THAI As  String  = ""
        Dim _FIRST_NAME_ENG As  String  = ""
        Dim _LAST_NAME_ENG As  String  = ""
        Dim _TITLE_ID As  System.Nullable(Of Long)  = 0
        Dim _DESCRIPTION As  String  = ""
        Dim _WORK_POSITION_ID As  System.Nullable(Of Long)  = 0
        Dim _EXEC_POSITION_ID As  System.Nullable(Of Long)  = 0
        Dim _WORK_ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _GENDER As  System.Nullable(Of Char)  = ""
        Dim _BIRTH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IDENTITY_CARD As  String  = ""
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _EMAIL As  String  = ""
        Dim _OFFICER_LEVEL As  String  = ""
        Dim _OFFICER_TYPE As  String  = ""
        Dim _SUMMER As  String  = ""
        Dim _EFDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EPDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_USERNAME", DbType:="VarChar(50)")>  _
        Public Property USERNAME() As  String 
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As  String )
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_PWD", DbType:="VarChar(50)")>  _
        Public Property PWD() As  String 
            Get
                Return _PWD
            End Get
            Set(ByVal value As  String )
               _PWD = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_CODE", DbType:="VarChar(50)")>  _
        Public Property OFFICER_CODE() As  String 
            Get
                Return _OFFICER_CODE
            End Get
            Set(ByVal value As  String )
               _OFFICER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME() As  String 
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME() As  String 
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As  String )
               _LAST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME_THAI() As  String 
            Get
                Return _FIRST_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME_THAI() As  String 
            Get
                Return _LAST_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _LAST_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME_ENG() As  String 
            Get
                Return _FIRST_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME_ENG() As  String 
            Get
                Return _LAST_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _LAST_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_TITLE_ID", DbType:="BigInt")>  _
        Public Property TITLE_ID() As  System.Nullable(Of Long) 
            Get
                Return _TITLE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(500)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_WORK_POSITION_ID", DbType:="BigInt")>  _
        Public Property WORK_POSITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _WORK_POSITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _WORK_POSITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_EXEC_POSITION_ID", DbType:="BigInt")>  _
        Public Property EXEC_POSITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _EXEC_POSITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _EXEC_POSITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_WORK_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property WORK_ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _WORK_ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _WORK_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_GENDER", DbType:="Char(1)")>  _
        Public Property GENDER() As  System.Nullable(Of Char) 
            Get
                Return _GENDER
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _GENDER = value
            End Set
        End Property 
        <Column(Storage:="_BIRTH_DATE", DbType:="DateTime2")>  _
        Public Property BIRTH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _BIRTH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _BIRTH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_IDENTITY_CARD", DbType:="VarChar(13)")>  _
        Public Property IDENTITY_CARD() As  String 
            Get
                Return _IDENTITY_CARD
            End Get
            Set(ByVal value As  String )
               _IDENTITY_CARD = value
            End Set
        End Property 
        <Column(Storage:="_TEL", DbType:="VarChar(255)")>  _
        Public Property TEL() As  String 
            Get
                Return _TEL
            End Get
            Set(ByVal value As  String )
               _TEL = value
            End Set
        End Property 
        <Column(Storage:="_FAX", DbType:="VarChar(255)")>  _
        Public Property FAX() As  String 
            Get
                Return _FAX
            End Get
            Set(ByVal value As  String )
               _FAX = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255)")>  _
        Public Property EMAIL() As  String 
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As  String )
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_LEVEL", DbType:="VarChar(50)")>  _
        Public Property OFFICER_LEVEL() As  String 
            Get
                Return _OFFICER_LEVEL
            End Get
            Set(ByVal value As  String )
               _OFFICER_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_TYPE", DbType:="VarChar(50)")>  _
        Public Property OFFICER_TYPE() As  String 
            Get
                Return _OFFICER_TYPE
            End Get
            Set(ByVal value As  String )
               _OFFICER_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_SUMMER", DbType:="VarChar(50)")>  _
        Public Property SUMMER() As  String 
            Get
                Return _SUMMER
            End Get
            Set(ByVal value As  String )
               _SUMMER = value
            End Set
        End Property 
        <Column(Storage:="_EFDATE", DbType:="DateTime2")>  _
        Public Property EFDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EFDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EFDATE = value
            End Set
        End Property 
        <Column(Storage:="_EPDATE", DbType:="DateTime2")>  _
        Public Property EPDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EPDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EPDATE = value
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
            _PWD = ""
            _OFFICER_CODE = ""
            _FIRST_NAME = ""
            _LAST_NAME = ""
            _FIRST_NAME_THAI = ""
            _LAST_NAME_THAI = ""
            _FIRST_NAME_ENG = ""
            _LAST_NAME_ENG = ""
            _TITLE_ID = 0
            _DESCRIPTION = ""
            _WORK_POSITION_ID = 0
            _EXEC_POSITION_ID = 0
            _WORK_ORGANIZATION_ID = 0
            _ORGANIZATION_ID = 0
            _GENDER = ""
            _BIRTH_DATE = New DateTime(1,1,1)
            _IDENTITY_CARD = ""
            _TEL = ""
            _FAX = ""
            _EMAIL = ""
            _OFFICER_LEVEL = ""
            _OFFICER_TYPE = ""
            _SUMMER = ""
            _EFDATE = New DateTime(1,1,1)
            _EPDATE = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to OFFICER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from OFFICER table successfully.
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


        '/// Returns an indication whether the record of OFFICER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of OFFICER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As OfficerLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of OFFICER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As OfficerPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of OFFICER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(cUSERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of OFFICER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSERNAME(cUSERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of OFFICER by specified OFFICER_CODE key is retrieved successfully.
        '/// <param name=cOFFICER_CODE>The OFFICER_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByOFFICER_CODE(cOFFICER_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("OFFICER_CODE = " & DB.SetString(cOFFICER_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of OFFICER by specified OFFICER_CODE key is retrieved successfully.
        '/// <param name=cOFFICER_CODE>The OFFICER_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByOFFICER_CODE(cOFFICER_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("OFFICER_CODE = " & DB.SetString(cOFFICER_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of OFFICER by specified FIRST_NAME key is retrieved successfully.
        '/// <param name=cFIRST_NAME>The FIRST_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByFIRST_NAME(cFIRST_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("FIRST_NAME = " & DB.SetString(cFIRST_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of OFFICER by specified FIRST_NAME key is retrieved successfully.
        '/// <param name=cFIRST_NAME>The FIRST_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByFIRST_NAME(cFIRST_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FIRST_NAME = " & DB.SetString(cFIRST_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of OFFICER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into OFFICER table successfully.
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


        '/// Returns an indication whether the current data is updated to OFFICER table successfully.
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


        '/// Returns an indication whether the current data is deleted from OFFICER table successfully.
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


        '/// Returns an indication whether the record of OFFICER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("pwd")) = False Then _pwd = Rdr("pwd").ToString()
                        If Convert.IsDBNull(Rdr("officer_code")) = False Then _officer_code = Rdr("officer_code").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("first_name_thai")) = False Then _first_name_thai = Rdr("first_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("last_name_thai")) = False Then _last_name_thai = Rdr("last_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("first_name_eng")) = False Then _first_name_eng = Rdr("first_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("last_name_eng")) = False Then _last_name_eng = Rdr("last_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("title_id")) = False Then _title_id = Convert.ToInt64(Rdr("title_id"))
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("work_position_id")) = False Then _work_position_id = Convert.ToInt64(Rdr("work_position_id"))
                        If Convert.IsDBNull(Rdr("exec_position_id")) = False Then _exec_position_id = Convert.ToInt64(Rdr("exec_position_id"))
                        If Convert.IsDBNull(Rdr("work_organization_id")) = False Then _work_organization_id = Convert.ToInt64(Rdr("work_organization_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then _organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("gender")) = False Then _gender = Rdr("gender").ToString()
                        If Convert.IsDBNull(Rdr("birth_date")) = False Then _birth_date = Convert.ToDateTime(Rdr("birth_date"))
                        If Convert.IsDBNull(Rdr("identity_card")) = False Then _identity_card = Rdr("identity_card").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("officer_level")) = False Then _officer_level = Rdr("officer_level").ToString()
                        If Convert.IsDBNull(Rdr("officer_type")) = False Then _officer_type = Rdr("officer_type").ToString()
                        If Convert.IsDBNull(Rdr("summer")) = False Then _summer = Rdr("summer").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then _efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then _epdate = Convert.ToDateTime(Rdr("epdate"))
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                    'If Rdr IsNot Nothing And Rdr.IsClosed=False Then
                    '    Rdr.Close()
                    'End If
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of OFFICER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As OfficerLinq
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
                        If Convert.IsDBNull(Rdr("pwd")) = False Then _pwd = Rdr("pwd").ToString()
                        If Convert.IsDBNull(Rdr("officer_code")) = False Then _officer_code = Rdr("officer_code").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("first_name_thai")) = False Then _first_name_thai = Rdr("first_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("last_name_thai")) = False Then _last_name_thai = Rdr("last_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("first_name_eng")) = False Then _first_name_eng = Rdr("first_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("last_name_eng")) = False Then _last_name_eng = Rdr("last_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("title_id")) = False Then _title_id = Convert.ToInt64(Rdr("title_id"))
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("work_position_id")) = False Then _work_position_id = Convert.ToInt64(Rdr("work_position_id"))
                        If Convert.IsDBNull(Rdr("exec_position_id")) = False Then _exec_position_id = Convert.ToInt64(Rdr("exec_position_id"))
                        If Convert.IsDBNull(Rdr("work_organization_id")) = False Then _work_organization_id = Convert.ToInt64(Rdr("work_organization_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then _organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("gender")) = False Then _gender = Rdr("gender").ToString()
                        If Convert.IsDBNull(Rdr("birth_date")) = False Then _birth_date = Convert.ToDateTime(Rdr("birth_date"))
                        If Convert.IsDBNull(Rdr("identity_card")) = False Then _identity_card = Rdr("identity_card").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("officer_level")) = False Then _officer_level = Rdr("officer_level").ToString()
                        If Convert.IsDBNull(Rdr("officer_type")) = False Then _officer_type = Rdr("officer_type").ToString()
                        If Convert.IsDBNull(Rdr("summer")) = False Then _summer = Rdr("summer").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then _efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then _epdate = Convert.ToDateTime(Rdr("epdate"))

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


        '/// Returns an indication whether the Class Data of OFFICER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As OfficerPara
            ClearData()
            _haveData  = False
            Dim ret As New OfficerPara
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
                        If Convert.IsDBNull(Rdr("pwd")) = False Then ret.pwd = Rdr("pwd").ToString()
                        If Convert.IsDBNull(Rdr("officer_code")) = False Then ret.officer_code = Rdr("officer_code").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then ret.first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then ret.last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("first_name_thai")) = False Then ret.first_name_thai = Rdr("first_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("last_name_thai")) = False Then ret.last_name_thai = Rdr("last_name_thai").ToString()
                        If Convert.IsDBNull(Rdr("first_name_eng")) = False Then ret.first_name_eng = Rdr("first_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("last_name_eng")) = False Then ret.last_name_eng = Rdr("last_name_eng").ToString()
                        If Convert.IsDBNull(Rdr("title_id")) = False Then ret.title_id = Convert.ToInt64(Rdr("title_id"))
                        If Convert.IsDBNull(Rdr("description")) = False Then ret.description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("work_position_id")) = False Then ret.work_position_id = Convert.ToInt64(Rdr("work_position_id"))
                        If Convert.IsDBNull(Rdr("exec_position_id")) = False Then ret.exec_position_id = Convert.ToInt64(Rdr("exec_position_id"))
                        If Convert.IsDBNull(Rdr("work_organization_id")) = False Then ret.work_organization_id = Convert.ToInt64(Rdr("work_organization_id"))
                        If Convert.IsDBNull(Rdr("organization_id")) = False Then ret.organization_id = Convert.ToInt64(Rdr("organization_id"))
                        If Convert.IsDBNull(Rdr("gender")) = False Then ret.gender = Rdr("gender").ToString()
                        If Convert.IsDBNull(Rdr("birth_date")) = False Then ret.birth_date = Convert.ToDateTime(Rdr("birth_date"))
                        If Convert.IsDBNull(Rdr("identity_card")) = False Then ret.identity_card = Rdr("identity_card").ToString()
                        If Convert.IsDBNull(Rdr("tel")) = False Then ret.tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then ret.fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then ret.email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("officer_level")) = False Then ret.officer_level = Rdr("officer_level").ToString()
                        If Convert.IsDBNull(Rdr("officer_type")) = False Then ret.officer_type = Rdr("officer_type").ToString()
                        If Convert.IsDBNull(Rdr("summer")) = False Then ret.summer = Rdr("summer").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then ret.efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then ret.epdate = Convert.ToDateTime(Rdr("epdate"))

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


        'Get Insert Statement for table OFFICER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, USERNAME, PWD, OFFICER_CODE, FIRST_NAME, LAST_NAME, FIRST_NAME_THAI, LAST_NAME_THAI, FIRST_NAME_ENG, LAST_NAME_ENG, TITLE_ID, DESCRIPTION, WORK_POSITION_ID, EXEC_POSITION_ID, WORK_ORGANIZATION_ID, ORGANIZATION_ID, GENDER, BIRTH_DATE, IDENTITY_CARD, TEL, FAX, EMAIL, OFFICER_LEVEL, OFFICER_TYPE, SUMMER, EFDATE, EPDATE)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_USERNAME) & ", "
                sql += DB.SetString(_PWD) & ", "
                sql += DB.SetString(_OFFICER_CODE) & ", "
                sql += DB.SetString(_FIRST_NAME) & ", "
                sql += DB.SetString(_LAST_NAME) & ", "
                sql += DB.SetString(_FIRST_NAME_THAI) & ", "
                sql += DB.SetString(_LAST_NAME_THAI) & ", "
                sql += DB.SetString(_FIRST_NAME_ENG) & ", "
                sql += DB.SetString(_LAST_NAME_ENG) & ", "
                sql += DB.SetDouble(_TITLE_ID) & ", "
                sql += DB.SetString(_DESCRIPTION) & ", "
                sql += DB.SetDouble(_WORK_POSITION_ID) & ", "
                sql += DB.SetDouble(_EXEC_POSITION_ID) & ", "
                sql += DB.SetDouble(_WORK_ORGANIZATION_ID) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_GENDER) & ", "
                sql += DB.SetDateTime(_BIRTH_DATE) & ", "
                sql += DB.SetString(_IDENTITY_CARD) & ", "
                sql += DB.SetString(_TEL) & ", "
                sql += DB.SetString(_FAX) & ", "
                sql += DB.SetString(_EMAIL) & ", "
                sql += DB.SetString(_OFFICER_LEVEL) & ", "
                sql += DB.SetString(_OFFICER_TYPE) & ", "
                sql += DB.SetString(_SUMMER) & ", "
                sql += DB.SetDateTime(_EFDATE) & ", "
                sql += DB.SetDateTime(_EPDATE)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table OFFICER
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
                Sql += "PWD = " & DB.SetString(_PWD) & ", "
                Sql += "OFFICER_CODE = " & DB.SetString(_OFFICER_CODE) & ", "
                Sql += "FIRST_NAME = " & DB.SetString(_FIRST_NAME) & ", "
                Sql += "LAST_NAME = " & DB.SetString(_LAST_NAME) & ", "
                Sql += "FIRST_NAME_THAI = " & DB.SetString(_FIRST_NAME_THAI) & ", "
                Sql += "LAST_NAME_THAI = " & DB.SetString(_LAST_NAME_THAI) & ", "
                Sql += "FIRST_NAME_ENG = " & DB.SetString(_FIRST_NAME_ENG) & ", "
                Sql += "LAST_NAME_ENG = " & DB.SetString(_LAST_NAME_ENG) & ", "
                Sql += "TITLE_ID = " & DB.SetDouble(_TITLE_ID) & ", "
                Sql += "DESCRIPTION = " & DB.SetString(_DESCRIPTION) & ", "
                Sql += "WORK_POSITION_ID = " & DB.SetDouble(_WORK_POSITION_ID) & ", "
                Sql += "EXEC_POSITION_ID = " & DB.SetDouble(_EXEC_POSITION_ID) & ", "
                Sql += "WORK_ORGANIZATION_ID = " & DB.SetDouble(_WORK_ORGANIZATION_ID) & ", "
                Sql += "ORGANIZATION_ID = " & DB.SetDouble(_ORGANIZATION_ID) & ", "
                Sql += "GENDER = " & DB.SetString(_GENDER) & ", "
                Sql += "BIRTH_DATE = " & DB.SetDateTime(_BIRTH_DATE) & ", "
                Sql += "IDENTITY_CARD = " & DB.SetString(_IDENTITY_CARD) & ", "
                Sql += "TEL = " & DB.SetString(_TEL) & ", "
                Sql += "FAX = " & DB.SetString(_FAX) & ", "
                Sql += "EMAIL = " & DB.SetString(_EMAIL) & ", "
                Sql += "OFFICER_LEVEL = " & DB.SetString(_OFFICER_LEVEL) & ", "
                Sql += "OFFICER_TYPE = " & DB.SetString(_OFFICER_TYPE) & ", "
                Sql += "SUMMER = " & DB.SetString(_SUMMER) & ", "
                Sql += "EFDATE = " & DB.SetDateTime(_EFDATE) & ", "
                Sql += "EPDATE = " & DB.SetDateTime(_EPDATE) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table OFFICER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table OFFICER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
