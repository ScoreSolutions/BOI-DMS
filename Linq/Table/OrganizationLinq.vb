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
    'Represents a transaction for ORGANIZATION table Linq.
    '[Create by  on September, 6 2012]
    Public Class OrganizationLinq
        Public sub OrganizationLinq()

        End Sub 
        ' ORGANIZATION
        Const _tableName As String = "ORGANIZATION"
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
        Dim _CREATE_BY As String = "(getdate())"
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORG_CODE As String = ""
        Dim _ORG_NAME As String = ""
        Dim _ORG_THAI_NAME As String = ""
        Dim _ORG_ENG_NAME As  String  = ""
        Dim _NAME_RECEIVE As  String  = ""
        Dim _NAME_ABB As  String  = ""
        Dim _SEC_ID As  System.Nullable(Of Long)  = 0
        Dim _EXPR1 As  String  = ""
        Dim _COM_CODE As  String  = ""
        Dim _ORGANIZATION_TYPE_ID As Long = 0
        Dim _PARENT_ID As  System.Nullable(Of Long)  = 0
        Dim _ADDRESS_THAI As  String  = ""
        Dim _ADDRESS_ENG As  String  = ""
        Dim _DISTRICT_ID As  System.Nullable(Of Long)  = 0
        Dim _AMPHUR_ID As  System.Nullable(Of Long)  = 0
        Dim _PROVINCE_ID As  System.Nullable(Of Long)  = 0
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _EMAIL As  String  = ""
        Dim _TYPE As  System.Nullable(Of Char)  = ""
        Dim _EFDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EPDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DESCRIPTION As  String  = ""
        Dim _ACTIVE As Char = "Y"
        Dim _DIRECTOR As  String  = ""

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
        <Column(Storage:="_ORG_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_CODE() As String
            Get
                Return _ORG_CODE
            End Get
            Set(ByVal value As String)
               _ORG_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ORG_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_NAME() As String
            Get
                Return _ORG_NAME
            End Get
            Set(ByVal value As String)
               _ORG_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORG_THAI_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_THAI_NAME() As String
            Get
                Return _ORG_THAI_NAME
            End Get
            Set(ByVal value As String)
               _ORG_THAI_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORG_ENG_NAME", DbType:="VarChar(255)")>  _
        Public Property ORG_ENG_NAME() As  String 
            Get
                Return _ORG_ENG_NAME
            End Get
            Set(ByVal value As  String )
               _ORG_ENG_NAME = value
            End Set
        End Property 
        <Column(Storage:="_NAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property NAME_RECEIVE() As  String 
            Get
                Return _NAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _NAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_NAME_ABB", DbType:="VarChar(255)")>  _
        Public Property NAME_ABB() As  String 
            Get
                Return _NAME_ABB
            End Get
            Set(ByVal value As  String )
               _NAME_ABB = value
            End Set
        End Property 
        <Column(Storage:="_SEC_ID", DbType:="BigInt")>  _
        Public Property SEC_ID() As  System.Nullable(Of Long) 
            Get
                Return _SEC_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SEC_ID = value
            End Set
        End Property 
        <Column(Storage:="_EXPR1", DbType:="VarChar(255)")>  _
        Public Property EXPR1() As  String 
            Get
                Return _EXPR1
            End Get
            Set(ByVal value As  String )
               _EXPR1 = value
            End Set
        End Property 
        <Column(Storage:="_COM_CODE", DbType:="VarChar(50)")>  _
        Public Property COM_CODE() As  String 
            Get
                Return _COM_CODE
            End Get
            Set(ByVal value As  String )
               _COM_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_TYPE_ID() As Long
            Get
                Return _ORGANIZATION_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_PARENT_ID", DbType:="BigInt")>  _
        Public Property PARENT_ID() As  System.Nullable(Of Long) 
            Get
                Return _PARENT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PARENT_ID = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESS_THAI", DbType:="VarChar(255)")>  _
        Public Property ADDRESS_THAI() As  String 
            Get
                Return _ADDRESS_THAI
            End Get
            Set(ByVal value As  String )
               _ADDRESS_THAI = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESS_ENG", DbType:="VarChar(255)")>  _
        Public Property ADDRESS_ENG() As  String 
            Get
                Return _ADDRESS_ENG
            End Get
            Set(ByVal value As  String )
               _ADDRESS_ENG = value
            End Set
        End Property 
        <Column(Storage:="_DISTRICT_ID", DbType:="BigInt")>  _
        Public Property DISTRICT_ID() As  System.Nullable(Of Long) 
            Get
                Return _DISTRICT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DISTRICT_ID = value
            End Set
        End Property 
        <Column(Storage:="_AMPHUR_ID", DbType:="BigInt")>  _
        Public Property AMPHUR_ID() As  System.Nullable(Of Long) 
            Get
                Return _AMPHUR_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _AMPHUR_ID = value
            End Set
        End Property 
        <Column(Storage:="_PROVINCE_ID", DbType:="BigInt")>  _
        Public Property PROVINCE_ID() As  System.Nullable(Of Long) 
            Get
                Return _PROVINCE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PROVINCE_ID = value
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
        <Column(Storage:="_TYPE", DbType:="Char(1)")>  _
        Public Property TYPE() As  System.Nullable(Of Char) 
            Get
                Return _TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _TYPE = value
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
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(500)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
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
        <Column(Storage:="_DIRECTOR", DbType:="VarChar(50)")>  _
        Public Property DIRECTOR() As  String 
            Get
                Return _DIRECTOR
            End Get
            Set(ByVal value As  String )
               _DIRECTOR = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_ON = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_ON = New DateTime(1,1,1)
            _ORG_CODE = ""
            _ORG_NAME = ""
            _ORG_THAI_NAME = ""
            _ORG_ENG_NAME = ""
            _NAME_RECEIVE = ""
            _NAME_ABB = ""
            _SEC_ID = 0
            _EXPR1 = ""
            _COM_CODE = ""
            _ORGANIZATION_TYPE_ID = 0
            _PARENT_ID = 0
            _ADDRESS_THAI = ""
            _ADDRESS_ENG = ""
            _DISTRICT_ID = 0
            _AMPHUR_ID = 0
            _PROVINCE_ID = 0
            _TEL = ""
            _FAX = ""
            _EMAIL = ""
            _TYPE = ""
            _EFDATE = New DateTime(1,1,1)
            _EPDATE = New DateTime(1,1,1)
            _DESCRIPTION = ""
            _ACTIVE = ""
            _DIRECTOR = ""
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


        '/// Returns an indication whether the current data is inserted into ORGANIZATION table successfully.
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


        '/// Returns an indication whether the current data is updated to ORGANIZATION table successfully.
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


        '/// Returns an indication whether the current data is updated to ORGANIZATION table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from ORGANIZATION table successfully.
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


        '/// Returns an indication whether the record of ORGANIZATION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of ORGANIZATION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As OrganizationLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of ORGANIZATION by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As OrganizationPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ORGANIZATION by specified ORG_NAME key is retrieved successfully.
        '/// <param name=cORG_NAME>The ORG_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByORG_NAME(cORG_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_NAME = " & DB.SetString(cORG_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of ORGANIZATION by specified ORG_NAME key is retrieved successfully.
        '/// <param name=cORG_NAME>The ORG_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByORG_NAME(cORG_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_NAME = " & DB.SetString(cORG_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ORGANIZATION by specified ORG_THAI_NAME key is retrieved successfully.
        '/// <param name=cORG_THAI_NAME>The ORG_THAI_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByORG_THAI_NAME(cORG_THAI_NAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_THAI_NAME = " & DB.SetString(cORG_THAI_NAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of ORGANIZATION by specified ORG_THAI_NAME key is retrieved successfully.
        '/// <param name=cORG_THAI_NAME>The ORG_THAI_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByORG_THAI_NAME(cORG_THAI_NAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_THAI_NAME = " & DB.SetString(cORG_THAI_NAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ORGANIZATION by specified ORG_CODE key is retrieved successfully.
        '/// <param name=cORG_CODE>The ORG_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByORG_CODE(cORG_CODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_CODE = " & DB.SetString(cORG_CODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of ORGANIZATION by specified ORG_CODE key is retrieved successfully.
        '/// <param name=cORG_CODE>The ORG_CODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByORG_CODE(cORG_CODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ORG_CODE = " & DB.SetString(cORG_CODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of ORGANIZATION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into ORGANIZATION table successfully.
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


        '/// Returns an indication whether the current data is updated to ORGANIZATION table successfully.
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


        '/// Returns an indication whether the current data is deleted from ORGANIZATION table successfully.
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


        '/// Returns an indication whether the record of ORGANIZATION by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("org_code")) = False Then _org_code = Rdr("org_code").ToString()
                        If Convert.IsDBNull(Rdr("org_name")) = False Then _org_name = Rdr("org_name").ToString()
                        If Convert.IsDBNull(Rdr("org_thai_name")) = False Then _org_thai_name = Rdr("org_thai_name").ToString()
                        If Convert.IsDBNull(Rdr("org_eng_name")) = False Then _org_eng_name = Rdr("org_eng_name").ToString()
                        If Convert.IsDBNull(Rdr("name_receive")) = False Then _name_receive = Rdr("name_receive").ToString()
                        If Convert.IsDBNull(Rdr("name_abb")) = False Then _name_abb = Rdr("name_abb").ToString()
                        If Convert.IsDBNull(Rdr("sec_id")) = False Then _sec_id = Convert.ToInt64(Rdr("sec_id"))
                        If Convert.IsDBNull(Rdr("expr1")) = False Then _expr1 = Rdr("expr1").ToString()
                        If Convert.IsDBNull(Rdr("com_code")) = False Then _com_code = Rdr("com_code").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then _organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("parent_id")) = False Then _parent_id = Convert.ToInt64(Rdr("parent_id"))
                        If Convert.IsDBNull(Rdr("address_thai")) = False Then _address_thai = Rdr("address_thai").ToString()
                        If Convert.IsDBNull(Rdr("address_eng")) = False Then _address_eng = Rdr("address_eng").ToString()
                        If Convert.IsDBNull(Rdr("district_id")) = False Then _district_id = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("amphur_id")) = False Then _amphur_id = Convert.ToInt64(Rdr("amphur_id"))
                        If Convert.IsDBNull(Rdr("province_id")) = False Then _province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("type")) = False Then _type = Rdr("type").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then _efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then _epdate = Convert.ToDateTime(Rdr("epdate"))
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("director")) = False Then _director = Rdr("director").ToString()
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


        '/// Returns an indication whether the record of ORGANIZATION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As OrganizationLinq
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
                        If Convert.IsDBNull(Rdr("org_code")) = False Then _org_code = Rdr("org_code").ToString()
                        If Convert.IsDBNull(Rdr("org_name")) = False Then _org_name = Rdr("org_name").ToString()
                        If Convert.IsDBNull(Rdr("org_thai_name")) = False Then _org_thai_name = Rdr("org_thai_name").ToString()
                        If Convert.IsDBNull(Rdr("org_eng_name")) = False Then _org_eng_name = Rdr("org_eng_name").ToString()
                        If Convert.IsDBNull(Rdr("name_receive")) = False Then _name_receive = Rdr("name_receive").ToString()
                        If Convert.IsDBNull(Rdr("name_abb")) = False Then _name_abb = Rdr("name_abb").ToString()
                        If Convert.IsDBNull(Rdr("sec_id")) = False Then _sec_id = Convert.ToInt64(Rdr("sec_id"))
                        If Convert.IsDBNull(Rdr("expr1")) = False Then _expr1 = Rdr("expr1").ToString()
                        If Convert.IsDBNull(Rdr("com_code")) = False Then _com_code = Rdr("com_code").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then _organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("parent_id")) = False Then _parent_id = Convert.ToInt64(Rdr("parent_id"))
                        If Convert.IsDBNull(Rdr("address_thai")) = False Then _address_thai = Rdr("address_thai").ToString()
                        If Convert.IsDBNull(Rdr("address_eng")) = False Then _address_eng = Rdr("address_eng").ToString()
                        If Convert.IsDBNull(Rdr("district_id")) = False Then _district_id = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("amphur_id")) = False Then _amphur_id = Convert.ToInt64(Rdr("amphur_id"))
                        If Convert.IsDBNull(Rdr("province_id")) = False Then _province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("tel")) = False Then _tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then _fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("type")) = False Then _type = Rdr("type").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then _efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then _epdate = Convert.ToDateTime(Rdr("epdate"))
                        If Convert.IsDBNull(Rdr("description")) = False Then _description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then _active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("director")) = False Then _director = Rdr("director").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : GROUP_TITLE_ORG_RESPONSE Column :organization_id
                        Dim GroupTitleOrgResponse_organization_idItem As New GroupTitleOrgResponseLinq
                        _GROUP_TITLE_ORG_RESPONSE_organization_id = GroupTitleOrgResponse_organization_idItem.GetDataList("organization_id = " & _ID, "", Nothing)

                        'Child Table Name : ORGANIZATION_STORAGE Column :organization_id
                        Dim OrganizationStorage_organization_idItem As New OrganizationStorageLinq
                        _ORGANIZATION_STORAGE_organization_id = OrganizationStorage_organization_idItem.GetDataList("organization_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of ORGANIZATION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As OrganizationPara
            ClearData()
            _haveData  = False
            Dim ret As New OrganizationPara
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
                        If Convert.IsDBNull(Rdr("org_code")) = False Then ret.org_code = Rdr("org_code").ToString()
                        If Convert.IsDBNull(Rdr("org_name")) = False Then ret.org_name = Rdr("org_name").ToString()
                        If Convert.IsDBNull(Rdr("org_thai_name")) = False Then ret.org_thai_name = Rdr("org_thai_name").ToString()
                        If Convert.IsDBNull(Rdr("org_eng_name")) = False Then ret.org_eng_name = Rdr("org_eng_name").ToString()
                        If Convert.IsDBNull(Rdr("name_receive")) = False Then ret.name_receive = Rdr("name_receive").ToString()
                        If Convert.IsDBNull(Rdr("name_abb")) = False Then ret.name_abb = Rdr("name_abb").ToString()
                        If Convert.IsDBNull(Rdr("sec_id")) = False Then ret.sec_id = Convert.ToInt64(Rdr("sec_id"))
                        If Convert.IsDBNull(Rdr("expr1")) = False Then ret.expr1 = Rdr("expr1").ToString()
                        If Convert.IsDBNull(Rdr("com_code")) = False Then ret.com_code = Rdr("com_code").ToString()
                        If Convert.IsDBNull(Rdr("organization_type_id")) = False Then ret.organization_type_id = Convert.ToInt64(Rdr("organization_type_id"))
                        If Convert.IsDBNull(Rdr("parent_id")) = False Then ret.parent_id = Convert.ToInt64(Rdr("parent_id"))
                        If Convert.IsDBNull(Rdr("address_thai")) = False Then ret.address_thai = Rdr("address_thai").ToString()
                        If Convert.IsDBNull(Rdr("address_eng")) = False Then ret.address_eng = Rdr("address_eng").ToString()
                        If Convert.IsDBNull(Rdr("district_id")) = False Then ret.district_id = Convert.ToInt64(Rdr("district_id"))
                        If Convert.IsDBNull(Rdr("amphur_id")) = False Then ret.amphur_id = Convert.ToInt64(Rdr("amphur_id"))
                        If Convert.IsDBNull(Rdr("province_id")) = False Then ret.province_id = Convert.ToInt64(Rdr("province_id"))
                        If Convert.IsDBNull(Rdr("tel")) = False Then ret.tel = Rdr("tel").ToString()
                        If Convert.IsDBNull(Rdr("fax")) = False Then ret.fax = Rdr("fax").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then ret.email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("type")) = False Then ret.type = Rdr("type").ToString()
                        If Convert.IsDBNull(Rdr("efdate")) = False Then ret.efdate = Convert.ToDateTime(Rdr("efdate"))
                        If Convert.IsDBNull(Rdr("epdate")) = False Then ret.epdate = Convert.ToDateTime(Rdr("epdate"))
                        If Convert.IsDBNull(Rdr("description")) = False Then ret.description = Rdr("description").ToString()
                        If Convert.IsDBNull(Rdr("active")) = False Then ret.active = Rdr("active").ToString()
                        If Convert.IsDBNull(Rdr("director")) = False Then ret.director = Rdr("director").ToString()

                        ''Generate Item For Child Table
                        ''Child Table Name : GROUP_TITLE_ORG_RESPONSE Column :organization_id
                        'Dim GroupTitleOrgResponse_organization_idItem As New GroupTitleOrgResponseLinq
                        '_GROUP_TITLE_ORG_RESPONSE_organization_id = GroupTitleOrgResponse_organization_idItem.GetDataList("organization_id = " & ret.id, "", Nothing)
                        'ret.CHILD_GROUP_TITLE_ORG_RESPONSE_organization_id = _GROUP_TITLE_ORG_RESPONSE_organization_id

                        ''Child Table Name : ORGANIZATION_STORAGE Column :organization_id
                        'Dim OrganizationStorage_organization_idItem As New OrganizationStorageLinq
                        '_ORGANIZATION_STORAGE_organization_id = OrganizationStorage_organization_idItem.GetDataList("organization_id = " & ret.id, "", Nothing)
                        'ret.CHILD_ORGANIZATION_STORAGE_organization_id = _ORGANIZATION_STORAGE_organization_id


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


        'Get Insert Statement for table ORGANIZATION
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, ORG_CODE, ORG_NAME, ORG_THAI_NAME, ORG_ENG_NAME, NAME_RECEIVE, NAME_ABB, SEC_ID, EXPR1, COM_CODE, ORGANIZATION_TYPE_ID, PARENT_ID, ADDRESS_THAI, ADDRESS_ENG, DISTRICT_ID, AMPHUR_ID, PROVINCE_ID, TEL, FAX, EMAIL, TYPE, EFDATE, EPDATE, DESCRIPTION, ACTIVE, DIRECTOR)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_ORG_CODE) & ", "
                sql += DB.SetString(_ORG_NAME) & ", "
                sql += DB.SetString(_ORG_THAI_NAME) & ", "
                sql += DB.SetString(_ORG_ENG_NAME) & ", "
                sql += DB.SetString(_NAME_RECEIVE) & ", "
                sql += DB.SetString(_NAME_ABB) & ", "
                sql += DB.SetDouble(_SEC_ID) & ", "
                sql += DB.SetString(_EXPR1) & ", "
                sql += DB.SetString(_COM_CODE) & ", "
                sql += DB.SetDouble(_ORGANIZATION_TYPE_ID) & ", "
                sql += DB.SetDouble(_PARENT_ID) & ", "
                sql += DB.SetString(_ADDRESS_THAI) & ", "
                sql += DB.SetString(_ADDRESS_ENG) & ", "
                sql += DB.SetDouble(_DISTRICT_ID) & ", "
                sql += DB.SetDouble(_AMPHUR_ID) & ", "
                sql += DB.SetDouble(_PROVINCE_ID) & ", "
                sql += DB.SetString(_TEL) & ", "
                sql += DB.SetString(_FAX) & ", "
                sql += DB.SetString(_EMAIL) & ", "
                sql += DB.SetString(_TYPE) & ", "
                sql += DB.SetDateTime(_EFDATE) & ", "
                sql += DB.SetDateTime(_EPDATE) & ", "
                sql += DB.SetString(_DESCRIPTION) & ", "
                sql += DB.SetString(_ACTIVE) & ", "
                sql += DB.SetString(_DIRECTOR)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table ORGANIZATION
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID = " & DB.SetDouble(_ID) & ", "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "ORG_CODE = " & DB.SetString(_ORG_CODE) & ", "
                Sql += "ORG_NAME = " & DB.SetString(_ORG_NAME) & ", "
                Sql += "ORG_THAI_NAME = " & DB.SetString(_ORG_THAI_NAME) & ", "
                Sql += "ORG_ENG_NAME = " & DB.SetString(_ORG_ENG_NAME) & ", "
                Sql += "NAME_RECEIVE = " & DB.SetString(_NAME_RECEIVE) & ", "
                Sql += "NAME_ABB = " & DB.SetString(_NAME_ABB) & ", "
                Sql += "SEC_ID = " & DB.SetDouble(_SEC_ID) & ", "
                Sql += "EXPR1 = " & DB.SetString(_EXPR1) & ", "
                Sql += "COM_CODE = " & DB.SetString(_COM_CODE) & ", "
                Sql += "ORGANIZATION_TYPE_ID = " & DB.SetDouble(_ORGANIZATION_TYPE_ID) & ", "
                Sql += "PARENT_ID = " & DB.SetDouble(_PARENT_ID) & ", "
                Sql += "ADDRESS_THAI = " & DB.SetString(_ADDRESS_THAI) & ", "
                Sql += "ADDRESS_ENG = " & DB.SetString(_ADDRESS_ENG) & ", "
                Sql += "DISTRICT_ID = " & DB.SetDouble(_DISTRICT_ID) & ", "
                Sql += "AMPHUR_ID = " & DB.SetDouble(_AMPHUR_ID) & ", "
                Sql += "PROVINCE_ID = " & DB.SetDouble(_PROVINCE_ID) & ", "
                Sql += "TEL = " & DB.SetString(_TEL) & ", "
                Sql += "FAX = " & DB.SetString(_FAX) & ", "
                Sql += "EMAIL = " & DB.SetString(_EMAIL) & ", "
                Sql += "TYPE = " & DB.SetString(_TYPE) & ", "
                Sql += "EFDATE = " & DB.SetDateTime(_EFDATE) & ", "
                Sql += "EPDATE = " & DB.SetDateTime(_EPDATE) & ", "
                Sql += "DESCRIPTION = " & DB.SetString(_DESCRIPTION) & ", "
                Sql += "ACTIVE = " & DB.SetString(_ACTIVE) & ", "
                Sql += "DIRECTOR = " & DB.SetString(_DIRECTOR) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table ORGANIZATION
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table ORGANIZATION
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _GROUP_TITLE_ORG_RESPONSE_organization_id As DataTable
       Dim _ORGANIZATION_STORAGE_organization_id As DataTable

       Public Property CHILD_GROUP_TITLE_ORG_RESPONSE_organization_id() As DataTable
           Get
               Return _GROUP_TITLE_ORG_RESPONSE_organization_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_ORG_RESPONSE_organization_id = value
           End Set
       End Property
       Public Property CHILD_ORGANIZATION_STORAGE_organization_id() As DataTable
           Get
               Return _ORGANIZATION_STORAGE_organization_id
           End Get
           Set(ByVal value As DataTable)
               _ORGANIZATION_STORAGE_organization_id = value
           End Set
       End Property
    End Class
End Namespace
