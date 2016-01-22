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
    'Represents a transaction for DOC_TRANS table Linq.
    '[Create by  on October, 1 2012]
    Public Class DocTransLinq
        Public sub DocTransLinq()

        End Sub 
        ' DOC_TRANS
        Const _tableName As String = "DOC_TRANS"
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
        Dim _ID_REF As  System.Nullable(Of Long)  = 0
        Dim _DOC_NO As  String  = ""
        Dim _DOC_SECRET As  String  = ""
        Dim _DOC_SPEED As  String  = ""
        Dim _DOC_DATE1 As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_DATE2 As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_ORGBOOKOWNER As  String  = ""
        Dim _DOC_OWNERADDRESS As  String  = ""
        Dim _DOC_TITLE As  String  = ""
        Dim _DOC_TITLECOMMAND As  String  = ""
        Dim _DOC_REFNO As  String  = ""
        Dim _DOC_TITLE_WHEN As  String  = ""
        Dim _DOC_TITLE_AT As  String  = ""
        Dim _DOC_TITLE_REGIS As  String  = ""
        Dim _DOC_TITLE_MEET As  String  = ""
        Dim _DOC_TITLE_NOMEET As  String  = ""
        Dim _DOC_TITLE_GROUP As  String  = ""
        Dim _DOC_MEMO_WONER As  String  = ""
        Dim _DOC_CONTENT As  String  = ""
        Dim _DOC_LEAN As  String  = ""
        Dim _DOC_REFTO As  String  = ""
        Dim _DOC_ATTACH As  String  = ""
        Dim _DOC_POSCRIPT As  String  = ""
        Dim _DOC_OFFICESIGN As  String  = ""
        Dim _DOC_POSITION As  String  = ""
        Dim _DOC_POSITIONSIGN As  String  = ""
        Dim _DOC_TITLEOWNER As  String  = ""
        Dim _DOC_TEL As  String  = ""
        Dim _DOC_FAX As  String  = ""
        Dim _DOC_ADDR As  String  = ""
        Dim _DOC_CCTO As  String  = ""
        Dim _DOC_DETAIL As  String  = ""
        Dim _DOC_TYPE As  System.Nullable(Of Long)  = 0
        Dim _DOC_USER As  String  = ""
        Dim _DOC_STATUS As  String  = ""
        Dim _DOC_STATUS_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CREATE_BY As  String  = ""
        Dim _DOC_EDIT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_EDIT_BY As  String  = ""
        Dim _DOC_SEND_BY As  String  = ""
        Dim _DOC_SEND_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_ORG_FROM As  String  = ""
        Dim _DOC_TO As  String  = ""
        Dim _DOC_ORG_TO As  String  = ""
        Dim _DOC_OBJ_TO As  String  = ""
        Dim _DOC_APPROVED As  String  = "((0))"
        Dim _DOC_OWNERADDRESS2 As  String  = ""
        Dim _IS_READ As Char = "N"
        Dim _SENDBACK_REMARKS As  String  = ""
        Dim _IS_SEND As Char = "N"

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_ID_REF", DbType:="Int")>  _
        Public Property ID_REF() As  System.Nullable(Of Long) 
            Get
                Return _ID_REF
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ID_REF = value
            End Set
        End Property 
        <Column(Storage:="_DOC_NO", DbType:="VarChar(50)")>  _
        Public Property DOC_NO() As  String 
            Get
                Return _DOC_NO
            End Get
            Set(ByVal value As  String )
               _DOC_NO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SECRET", DbType:="VarChar(50)")>  _
        Public Property DOC_SECRET() As  String 
            Get
                Return _DOC_SECRET
            End Get
            Set(ByVal value As  String )
               _DOC_SECRET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SPEED", DbType:="VarChar(50)")>  _
        Public Property DOC_SPEED() As  String 
            Get
                Return _DOC_SPEED
            End Get
            Set(ByVal value As  String )
               _DOC_SPEED = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DATE1", DbType:="DateTime")>  _
        Public Property DOC_DATE1() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_DATE1
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_DATE1 = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DATE2", DbType:="DateTime")>  _
        Public Property DOC_DATE2() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_DATE2
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_DATE2 = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORGBOOKOWNER", DbType:="VarChar(255)")>  _
        Public Property DOC_ORGBOOKOWNER() As  String 
            Get
                Return _DOC_ORGBOOKOWNER
            End Get
            Set(ByVal value As  String )
               _DOC_ORGBOOKOWNER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OWNERADDRESS", DbType:="VarChar(255)")>  _
        Public Property DOC_OWNERADDRESS() As  String 
            Get
                Return _DOC_OWNERADDRESS
            End Get
            Set(ByVal value As  String )
               _DOC_OWNERADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE", DbType:="VarChar(100)")>  _
        Public Property DOC_TITLE() As  String 
            Get
                Return _DOC_TITLE
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLECOMMAND", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLECOMMAND() As  String 
            Get
                Return _DOC_TITLECOMMAND
            End Get
            Set(ByVal value As  String )
               _DOC_TITLECOMMAND = value
            End Set
        End Property 
        <Column(Storage:="_DOC_REFNO", DbType:="VarChar(50)")>  _
        Public Property DOC_REFNO() As  String 
            Get
                Return _DOC_REFNO
            End Get
            Set(ByVal value As  String )
               _DOC_REFNO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_WHEN", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_WHEN() As  String 
            Get
                Return _DOC_TITLE_WHEN
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_WHEN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_AT", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_AT() As  String 
            Get
                Return _DOC_TITLE_AT
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_AT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_REGIS", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_REGIS() As  String 
            Get
                Return _DOC_TITLE_REGIS
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_REGIS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_MEET", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_MEET() As  String 
            Get
                Return _DOC_TITLE_MEET
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_MEET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_NOMEET", DbType:="VarChar(50)")>  _
        Public Property DOC_TITLE_NOMEET() As  String 
            Get
                Return _DOC_TITLE_NOMEET
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_NOMEET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_GROUP", DbType:="VarChar(10)")>  _
        Public Property DOC_TITLE_GROUP() As  String 
            Get
                Return _DOC_TITLE_GROUP
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_GROUP = value
            End Set
        End Property 
        <Column(Storage:="_DOC_MEMO_WONER", DbType:="VarChar(100)")>  _
        Public Property DOC_MEMO_WONER() As  String 
            Get
                Return _DOC_MEMO_WONER
            End Get
            Set(ByVal value As  String )
               _DOC_MEMO_WONER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CONTENT", DbType:="VarChar(100)")>  _
        Public Property DOC_CONTENT() As  String 
            Get
                Return _DOC_CONTENT
            End Get
            Set(ByVal value As  String )
               _DOC_CONTENT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_LEAN", DbType:="VarChar(255)")>  _
        Public Property DOC_LEAN() As  String 
            Get
                Return _DOC_LEAN
            End Get
            Set(ByVal value As  String )
               _DOC_LEAN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_REFTO", DbType:="VarChar(255)")>  _
        Public Property DOC_REFTO() As  String 
            Get
                Return _DOC_REFTO
            End Get
            Set(ByVal value As  String )
               _DOC_REFTO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ATTACH", DbType:="VarChar(255)")>  _
        Public Property DOC_ATTACH() As  String 
            Get
                Return _DOC_ATTACH
            End Get
            Set(ByVal value As  String )
               _DOC_ATTACH = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSCRIPT", DbType:="VarChar(50)")>  _
        Public Property DOC_POSCRIPT() As  String 
            Get
                Return _DOC_POSCRIPT
            End Get
            Set(ByVal value As  String )
               _DOC_POSCRIPT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OFFICESIGN", DbType:="VarChar(50)")>  _
        Public Property DOC_OFFICESIGN() As  String 
            Get
                Return _DOC_OFFICESIGN
            End Get
            Set(ByVal value As  String )
               _DOC_OFFICESIGN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSITION", DbType:="VarChar(100)")>  _
        Public Property DOC_POSITION() As  String 
            Get
                Return _DOC_POSITION
            End Get
            Set(ByVal value As  String )
               _DOC_POSITION = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSITIONSIGN", DbType:="VarChar(50)")>  _
        Public Property DOC_POSITIONSIGN() As  String 
            Get
                Return _DOC_POSITIONSIGN
            End Get
            Set(ByVal value As  String )
               _DOC_POSITIONSIGN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLEOWNER", DbType:="VarChar(50)")>  _
        Public Property DOC_TITLEOWNER() As  String 
            Get
                Return _DOC_TITLEOWNER
            End Get
            Set(ByVal value As  String )
               _DOC_TITLEOWNER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TEL", DbType:="VarChar(50)")>  _
        Public Property DOC_TEL() As  String 
            Get
                Return _DOC_TEL
            End Get
            Set(ByVal value As  String )
               _DOC_TEL = value
            End Set
        End Property 
        <Column(Storage:="_DOC_FAX", DbType:="VarChar(50)")>  _
        Public Property DOC_FAX() As  String 
            Get
                Return _DOC_FAX
            End Get
            Set(ByVal value As  String )
               _DOC_FAX = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ADDR", DbType:="VarChar(255)")>  _
        Public Property DOC_ADDR() As  String 
            Get
                Return _DOC_ADDR
            End Get
            Set(ByVal value As  String )
               _DOC_ADDR = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CCTO", DbType:="VarChar(255)")>  _
        Public Property DOC_CCTO() As  String 
            Get
                Return _DOC_CCTO
            End Get
            Set(ByVal value As  String )
               _DOC_CCTO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DETAIL", DbType:="Text")>  _
        Public Property DOC_DETAIL() As  String 
            Get
                Return _DOC_DETAIL
            End Get
            Set(ByVal value As  String )
               _DOC_DETAIL = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TYPE", DbType:="Int")>  _
        Public Property DOC_TYPE() As  System.Nullable(Of Long) 
            Get
                Return _DOC_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOC_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_USER", DbType:="VarChar(50)")>  _
        Public Property DOC_USER() As  String 
            Get
                Return _DOC_USER
            End Get
            Set(ByVal value As  String )
               _DOC_USER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_STATUS", DbType:="VarChar(50)")>  _
        Public Property DOC_STATUS() As  String 
            Get
                Return _DOC_STATUS
            End Get
            Set(ByVal value As  String )
               _DOC_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_STATUS_DATE", DbType:="DateTime")>  _
        Public Property DOC_STATUS_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_STATUS_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_STATUS_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CREATE_DATE", DbType:="DateTime")>  _
        Public Property DOC_CREATE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_CREATE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_CREATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CREATE_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_CREATE_BY() As  String 
            Get
                Return _DOC_CREATE_BY
            End Get
            Set(ByVal value As  String )
               _DOC_CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_EDIT_DATE", DbType:="DateTime")>  _
        Public Property DOC_EDIT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_EDIT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_EDIT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_EDIT_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_EDIT_BY() As  String 
            Get
                Return _DOC_EDIT_BY
            End Get
            Set(ByVal value As  String )
               _DOC_EDIT_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SEND_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_SEND_BY() As  String 
            Get
                Return _DOC_SEND_BY
            End Get
            Set(ByVal value As  String )
               _DOC_SEND_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SEND_DATE", DbType:="DateTime")>  _
        Public Property DOC_SEND_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_SEND_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORG_FROM", DbType:="VarChar(50)")>  _
        Public Property DOC_ORG_FROM() As  String 
            Get
                Return _DOC_ORG_FROM
            End Get
            Set(ByVal value As  String )
               _DOC_ORG_FROM = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_TO() As  String 
            Get
                Return _DOC_TO
            End Get
            Set(ByVal value As  String )
               _DOC_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORG_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_ORG_TO() As  String 
            Get
                Return _DOC_ORG_TO
            End Get
            Set(ByVal value As  String )
               _DOC_ORG_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OBJ_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_OBJ_TO() As  String 
            Get
                Return _DOC_OBJ_TO
            End Get
            Set(ByVal value As  String )
               _DOC_OBJ_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_APPROVED", DbType:="VarChar(1)")>  _
        Public Property DOC_APPROVED() As  String 
            Get
                Return _DOC_APPROVED
            End Get
            Set(ByVal value As  String )
               _DOC_APPROVED = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OWNERADDRESS2", DbType:="VarChar(255)")>  _
        Public Property DOC_OWNERADDRESS2() As  String 
            Get
                Return _DOC_OWNERADDRESS2
            End Get
            Set(ByVal value As  String )
               _DOC_OWNERADDRESS2 = value
            End Set
        End Property 
        <Column(Storage:="_IS_READ", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_READ() As Char
            Get
                Return _IS_READ
            End Get
            Set(ByVal value As Char)
               _IS_READ = value
            End Set
        End Property 
        <Column(Storage:="_SENDBACK_REMARKS", DbType:="VarChar(255)")>  _
        Public Property SENDBACK_REMARKS() As  String 
            Get
                Return _SENDBACK_REMARKS
            End Get
            Set(ByVal value As  String )
               _SENDBACK_REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_IS_SEND", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_SEND() As Char
            Get
                Return _IS_SEND
            End Get
            Set(ByVal value As Char)
               _IS_SEND = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _ID_REF = 0
            _DOC_NO = ""
            _DOC_SECRET = ""
            _DOC_SPEED = ""
            _DOC_DATE1 = New DateTime(1,1,1)
            _DOC_DATE2 = New DateTime(1,1,1)
            _DOC_ORGBOOKOWNER = ""
            _DOC_OWNERADDRESS = ""
            _DOC_TITLE = ""
            _DOC_TITLECOMMAND = ""
            _DOC_REFNO = ""
            _DOC_TITLE_WHEN = ""
            _DOC_TITLE_AT = ""
            _DOC_TITLE_REGIS = ""
            _DOC_TITLE_MEET = ""
            _DOC_TITLE_NOMEET = ""
            _DOC_TITLE_GROUP = ""
            _DOC_MEMO_WONER = ""
            _DOC_CONTENT = ""
            _DOC_LEAN = ""
            _DOC_REFTO = ""
            _DOC_ATTACH = ""
            _DOC_POSCRIPT = ""
            _DOC_OFFICESIGN = ""
            _DOC_POSITION = ""
            _DOC_POSITIONSIGN = ""
            _DOC_TITLEOWNER = ""
            _DOC_TEL = ""
            _DOC_FAX = ""
            _DOC_ADDR = ""
            _DOC_CCTO = ""
            _DOC_DETAIL = ""
            _DOC_TYPE = 0
            _DOC_USER = ""
            _DOC_STATUS = ""
            _DOC_STATUS_DATE = New DateTime(1,1,1)
            _DOC_CREATE_DATE = New DateTime(1,1,1)
            _DOC_CREATE_BY = ""
            _DOC_EDIT_DATE = New DateTime(1,1,1)
            _DOC_EDIT_BY = ""
            _DOC_SEND_BY = ""
            _DOC_SEND_DATE = New DateTime(1,1,1)
            _DOC_ORG_FROM = ""
            _DOC_TO = ""
            _DOC_ORG_TO = ""
            _DOC_OBJ_TO = ""
            _DOC_APPROVED = ""
            _DOC_OWNERADDRESS2 = ""
            _IS_READ = ""
            _SENDBACK_REMARKS = ""
            _IS_SEND = ""
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


        '/// Returns an indication whether the current data is inserted into DOC_TRANS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _id = DB.GetNextID("id",tableName, trans)
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to DOC_TRANS table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doUpdate("id = " & DB.SetDouble(_id) & " ", trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to DOC_TRANS table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOC_TRANS table successfully.
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


        '/// Returns an indication whether the record of DOC_TRANS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Integer, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOC_TRANS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Integer, trans As SQLTransaction) As DocTransLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOC_TRANS by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Integer, trans As SQLTransaction) As DocTransPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOC_TRANS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOC_TRANS table successfully.
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


        '/// Returns an indication whether the current data is updated to DOC_TRANS table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOC_TRANS table successfully.
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


        '/// Returns an indication whether the record of DOC_TRANS by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("id_ref")) = False Then _id_ref = Convert.ToInt32(Rdr("id_ref"))
                        If Convert.IsDBNull(Rdr("doc_no")) = False Then _doc_no = Rdr("doc_no").ToString()
                        If Convert.IsDBNull(Rdr("doc_secret")) = False Then _doc_secret = Rdr("doc_secret").ToString()
                        If Convert.IsDBNull(Rdr("doc_speed")) = False Then _doc_speed = Rdr("doc_speed").ToString()
                        If Convert.IsDBNull(Rdr("doc_date1")) = False Then _doc_date1 = Convert.ToDateTime(Rdr("doc_date1"))
                        If Convert.IsDBNull(Rdr("doc_date2")) = False Then _doc_date2 = Convert.ToDateTime(Rdr("doc_date2"))
                        If Convert.IsDBNull(Rdr("doc_OrgBookOwner")) = False Then _doc_OrgBookOwner = Rdr("doc_OrgBookOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress")) = False Then _doc_OwnerAddress = Rdr("doc_OwnerAddress").ToString()
                        If Convert.IsDBNull(Rdr("doc_title")) = False Then _doc_title = Rdr("doc_title").ToString()
                        If Convert.IsDBNull(Rdr("doc_titleCommand")) = False Then _doc_titleCommand = Rdr("doc_titleCommand").ToString()
                        If Convert.IsDBNull(Rdr("doc_refno")) = False Then _doc_refno = Rdr("doc_refno").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_when")) = False Then _doc_title_when = Rdr("doc_title_when").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_at")) = False Then _doc_title_at = Rdr("doc_title_at").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_regis")) = False Then _doc_title_regis = Rdr("doc_title_regis").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_meet")) = False Then _doc_title_meet = Rdr("doc_title_meet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_nomeet")) = False Then _doc_title_nomeet = Rdr("doc_title_nomeet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_group")) = False Then _doc_title_group = Rdr("doc_title_group").ToString()
                        If Convert.IsDBNull(Rdr("doc_memo_woner")) = False Then _doc_memo_woner = Rdr("doc_memo_woner").ToString()
                        If Convert.IsDBNull(Rdr("doc_content")) = False Then _doc_content = Rdr("doc_content").ToString()
                        If Convert.IsDBNull(Rdr("doc_lean")) = False Then _doc_lean = Rdr("doc_lean").ToString()
                        If Convert.IsDBNull(Rdr("doc_refto")) = False Then _doc_refto = Rdr("doc_refto").ToString()
                        If Convert.IsDBNull(Rdr("doc_attach")) = False Then _doc_attach = Rdr("doc_attach").ToString()
                        If Convert.IsDBNull(Rdr("doc_poscript")) = False Then _doc_poscript = Rdr("doc_poscript").ToString()
                        If Convert.IsDBNull(Rdr("doc_officeSign")) = False Then _doc_officeSign = Rdr("doc_officeSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_position")) = False Then _doc_position = Rdr("doc_position").ToString()
                        If Convert.IsDBNull(Rdr("doc_positionSign")) = False Then _doc_positionSign = Rdr("doc_positionSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_TitleOwner")) = False Then _doc_TitleOwner = Rdr("doc_TitleOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_tel")) = False Then _doc_tel = Rdr("doc_tel").ToString()
                        If Convert.IsDBNull(Rdr("doc_fax")) = False Then _doc_fax = Rdr("doc_fax").ToString()
                        If Convert.IsDBNull(Rdr("doc_addr")) = False Then _doc_addr = Rdr("doc_addr").ToString()
                        If Convert.IsDBNull(Rdr("doc_ccto")) = False Then _doc_ccto = Rdr("doc_ccto").ToString()
                        If Convert.IsDBNull(Rdr("doc_detail")) = False Then _doc_detail = Rdr("doc_detail").ToString()
                        If Convert.IsDBNull(Rdr("doc_type")) = False Then _doc_type = Convert.ToInt32(Rdr("doc_type"))
                        If Convert.IsDBNull(Rdr("doc_user")) = False Then _doc_user = Rdr("doc_user").ToString()
                        If Convert.IsDBNull(Rdr("doc_status")) = False Then _doc_status = Rdr("doc_status").ToString()
                        If Convert.IsDBNull(Rdr("doc_status_date")) = False Then _doc_status_date = Convert.ToDateTime(Rdr("doc_status_date"))
                        If Convert.IsDBNull(Rdr("doc_create_date")) = False Then _doc_create_date = Convert.ToDateTime(Rdr("doc_create_date"))
                        If Convert.IsDBNull(Rdr("doc_create_by")) = False Then _doc_create_by = Rdr("doc_create_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_edit_date")) = False Then _doc_edit_date = Convert.ToDateTime(Rdr("doc_edit_date"))
                        If Convert.IsDBNull(Rdr("doc_edit_by")) = False Then _doc_edit_by = Rdr("doc_edit_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_by")) = False Then _doc_send_by = Rdr("doc_send_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_date")) = False Then _doc_send_date = Convert.ToDateTime(Rdr("doc_send_date"))
                        If Convert.IsDBNull(Rdr("doc_org_from")) = False Then _doc_org_from = Rdr("doc_org_from").ToString()
                        If Convert.IsDBNull(Rdr("doc_to")) = False Then _doc_to = Rdr("doc_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_org_to")) = False Then _doc_org_to = Rdr("doc_org_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_obj_to")) = False Then _doc_obj_to = Rdr("doc_obj_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_approved")) = False Then _doc_approved = Rdr("doc_approved").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress2")) = False Then _doc_OwnerAddress2 = Rdr("doc_OwnerAddress2").ToString()
                        If Convert.IsDBNull(Rdr("is_read")) = False Then _is_read = Rdr("is_read").ToString()
                        If Convert.IsDBNull(Rdr("sendback_remarks")) = False Then _sendback_remarks = Rdr("sendback_remarks").ToString()
                        If Convert.IsDBNull(Rdr("is_send")) = False Then _is_send = Rdr("is_send").ToString()
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


        '/// Returns an indication whether the record of DOC_TRANS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocTransLinq
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("id_ref")) = False Then _id_ref = Convert.ToInt32(Rdr("id_ref"))
                        If Convert.IsDBNull(Rdr("doc_no")) = False Then _doc_no = Rdr("doc_no").ToString()
                        If Convert.IsDBNull(Rdr("doc_secret")) = False Then _doc_secret = Rdr("doc_secret").ToString()
                        If Convert.IsDBNull(Rdr("doc_speed")) = False Then _doc_speed = Rdr("doc_speed").ToString()
                        If Convert.IsDBNull(Rdr("doc_date1")) = False Then _doc_date1 = Convert.ToDateTime(Rdr("doc_date1"))
                        If Convert.IsDBNull(Rdr("doc_date2")) = False Then _doc_date2 = Convert.ToDateTime(Rdr("doc_date2"))
                        If Convert.IsDBNull(Rdr("doc_OrgBookOwner")) = False Then _doc_OrgBookOwner = Rdr("doc_OrgBookOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress")) = False Then _doc_OwnerAddress = Rdr("doc_OwnerAddress").ToString()
                        If Convert.IsDBNull(Rdr("doc_title")) = False Then _doc_title = Rdr("doc_title").ToString()
                        If Convert.IsDBNull(Rdr("doc_titleCommand")) = False Then _doc_titleCommand = Rdr("doc_titleCommand").ToString()
                        If Convert.IsDBNull(Rdr("doc_refno")) = False Then _doc_refno = Rdr("doc_refno").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_when")) = False Then _doc_title_when = Rdr("doc_title_when").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_at")) = False Then _doc_title_at = Rdr("doc_title_at").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_regis")) = False Then _doc_title_regis = Rdr("doc_title_regis").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_meet")) = False Then _doc_title_meet = Rdr("doc_title_meet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_nomeet")) = False Then _doc_title_nomeet = Rdr("doc_title_nomeet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_group")) = False Then _doc_title_group = Rdr("doc_title_group").ToString()
                        If Convert.IsDBNull(Rdr("doc_memo_woner")) = False Then _doc_memo_woner = Rdr("doc_memo_woner").ToString()
                        If Convert.IsDBNull(Rdr("doc_content")) = False Then _doc_content = Rdr("doc_content").ToString()
                        If Convert.IsDBNull(Rdr("doc_lean")) = False Then _doc_lean = Rdr("doc_lean").ToString()
                        If Convert.IsDBNull(Rdr("doc_refto")) = False Then _doc_refto = Rdr("doc_refto").ToString()
                        If Convert.IsDBNull(Rdr("doc_attach")) = False Then _doc_attach = Rdr("doc_attach").ToString()
                        If Convert.IsDBNull(Rdr("doc_poscript")) = False Then _doc_poscript = Rdr("doc_poscript").ToString()
                        If Convert.IsDBNull(Rdr("doc_officeSign")) = False Then _doc_officeSign = Rdr("doc_officeSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_position")) = False Then _doc_position = Rdr("doc_position").ToString()
                        If Convert.IsDBNull(Rdr("doc_positionSign")) = False Then _doc_positionSign = Rdr("doc_positionSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_TitleOwner")) = False Then _doc_TitleOwner = Rdr("doc_TitleOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_tel")) = False Then _doc_tel = Rdr("doc_tel").ToString()
                        If Convert.IsDBNull(Rdr("doc_fax")) = False Then _doc_fax = Rdr("doc_fax").ToString()
                        If Convert.IsDBNull(Rdr("doc_addr")) = False Then _doc_addr = Rdr("doc_addr").ToString()
                        If Convert.IsDBNull(Rdr("doc_ccto")) = False Then _doc_ccto = Rdr("doc_ccto").ToString()
                        If Convert.IsDBNull(Rdr("doc_detail")) = False Then _doc_detail = Rdr("doc_detail").ToString()
                        If Convert.IsDBNull(Rdr("doc_type")) = False Then _doc_type = Convert.ToInt32(Rdr("doc_type"))
                        If Convert.IsDBNull(Rdr("doc_user")) = False Then _doc_user = Rdr("doc_user").ToString()
                        If Convert.IsDBNull(Rdr("doc_status")) = False Then _doc_status = Rdr("doc_status").ToString()
                        If Convert.IsDBNull(Rdr("doc_status_date")) = False Then _doc_status_date = Convert.ToDateTime(Rdr("doc_status_date"))
                        If Convert.IsDBNull(Rdr("doc_create_date")) = False Then _doc_create_date = Convert.ToDateTime(Rdr("doc_create_date"))
                        If Convert.IsDBNull(Rdr("doc_create_by")) = False Then _doc_create_by = Rdr("doc_create_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_edit_date")) = False Then _doc_edit_date = Convert.ToDateTime(Rdr("doc_edit_date"))
                        If Convert.IsDBNull(Rdr("doc_edit_by")) = False Then _doc_edit_by = Rdr("doc_edit_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_by")) = False Then _doc_send_by = Rdr("doc_send_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_date")) = False Then _doc_send_date = Convert.ToDateTime(Rdr("doc_send_date"))
                        If Convert.IsDBNull(Rdr("doc_org_from")) = False Then _doc_org_from = Rdr("doc_org_from").ToString()
                        If Convert.IsDBNull(Rdr("doc_to")) = False Then _doc_to = Rdr("doc_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_org_to")) = False Then _doc_org_to = Rdr("doc_org_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_obj_to")) = False Then _doc_obj_to = Rdr("doc_obj_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_approved")) = False Then _doc_approved = Rdr("doc_approved").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress2")) = False Then _doc_OwnerAddress2 = Rdr("doc_OwnerAddress2").ToString()
                        If Convert.IsDBNull(Rdr("is_read")) = False Then _is_read = Rdr("is_read").ToString()
                        If Convert.IsDBNull(Rdr("sendback_remarks")) = False Then _sendback_remarks = Rdr("sendback_remarks").ToString()
                        If Convert.IsDBNull(Rdr("is_send")) = False Then _is_send = Rdr("is_send").ToString()

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


        '/// Returns an indication whether the Class Data of DOC_TRANS by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocTransPara
            ClearData()
            _haveData  = False
            Dim ret As New DocTransPara
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then ret.id = Convert.ToInt32(Rdr("id"))
                        If Convert.IsDBNull(Rdr("id_ref")) = False Then ret.id_ref = Convert.ToInt32(Rdr("id_ref"))
                        If Convert.IsDBNull(Rdr("doc_no")) = False Then ret.doc_no = Rdr("doc_no").ToString()
                        If Convert.IsDBNull(Rdr("doc_secret")) = False Then ret.doc_secret = Rdr("doc_secret").ToString()
                        If Convert.IsDBNull(Rdr("doc_speed")) = False Then ret.doc_speed = Rdr("doc_speed").ToString()
                        If Convert.IsDBNull(Rdr("doc_date1")) = False Then ret.doc_date1 = Convert.ToDateTime(Rdr("doc_date1"))
                        If Convert.IsDBNull(Rdr("doc_date2")) = False Then ret.doc_date2 = Convert.ToDateTime(Rdr("doc_date2"))
                        If Convert.IsDBNull(Rdr("doc_OrgBookOwner")) = False Then ret.doc_OrgBookOwner = Rdr("doc_OrgBookOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress")) = False Then ret.doc_OwnerAddress = Rdr("doc_OwnerAddress").ToString()
                        If Convert.IsDBNull(Rdr("doc_title")) = False Then ret.doc_title = Rdr("doc_title").ToString()
                        If Convert.IsDBNull(Rdr("doc_titleCommand")) = False Then ret.doc_titleCommand = Rdr("doc_titleCommand").ToString()
                        If Convert.IsDBNull(Rdr("doc_refno")) = False Then ret.doc_refno = Rdr("doc_refno").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_when")) = False Then ret.doc_title_when = Rdr("doc_title_when").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_at")) = False Then ret.doc_title_at = Rdr("doc_title_at").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_regis")) = False Then ret.doc_title_regis = Rdr("doc_title_regis").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_meet")) = False Then ret.doc_title_meet = Rdr("doc_title_meet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_nomeet")) = False Then ret.doc_title_nomeet = Rdr("doc_title_nomeet").ToString()
                        If Convert.IsDBNull(Rdr("doc_title_group")) = False Then ret.doc_title_group = Rdr("doc_title_group").ToString()
                        If Convert.IsDBNull(Rdr("doc_memo_woner")) = False Then ret.doc_memo_woner = Rdr("doc_memo_woner").ToString()
                        If Convert.IsDBNull(Rdr("doc_content")) = False Then ret.doc_content = Rdr("doc_content").ToString()
                        If Convert.IsDBNull(Rdr("doc_lean")) = False Then ret.doc_lean = Rdr("doc_lean").ToString()
                        If Convert.IsDBNull(Rdr("doc_refto")) = False Then ret.doc_refto = Rdr("doc_refto").ToString()
                        If Convert.IsDBNull(Rdr("doc_attach")) = False Then ret.doc_attach = Rdr("doc_attach").ToString()
                        If Convert.IsDBNull(Rdr("doc_poscript")) = False Then ret.doc_poscript = Rdr("doc_poscript").ToString()
                        If Convert.IsDBNull(Rdr("doc_officeSign")) = False Then ret.doc_officeSign = Rdr("doc_officeSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_position")) = False Then ret.doc_position = Rdr("doc_position").ToString()
                        If Convert.IsDBNull(Rdr("doc_positionSign")) = False Then ret.doc_positionSign = Rdr("doc_positionSign").ToString()
                        If Convert.IsDBNull(Rdr("doc_TitleOwner")) = False Then ret.doc_TitleOwner = Rdr("doc_TitleOwner").ToString()
                        If Convert.IsDBNull(Rdr("doc_tel")) = False Then ret.doc_tel = Rdr("doc_tel").ToString()
                        If Convert.IsDBNull(Rdr("doc_fax")) = False Then ret.doc_fax = Rdr("doc_fax").ToString()
                        If Convert.IsDBNull(Rdr("doc_addr")) = False Then ret.doc_addr = Rdr("doc_addr").ToString()
                        If Convert.IsDBNull(Rdr("doc_ccto")) = False Then ret.doc_ccto = Rdr("doc_ccto").ToString()
                        If Convert.IsDBNull(Rdr("doc_detail")) = False Then ret.doc_detail = Rdr("doc_detail").ToString()
                        If Convert.IsDBNull(Rdr("doc_type")) = False Then ret.doc_type = Convert.ToInt32(Rdr("doc_type"))
                        If Convert.IsDBNull(Rdr("doc_user")) = False Then ret.doc_user = Rdr("doc_user").ToString()
                        If Convert.IsDBNull(Rdr("doc_status")) = False Then ret.doc_status = Rdr("doc_status").ToString()
                        If Convert.IsDBNull(Rdr("doc_status_date")) = False Then ret.doc_status_date = Convert.ToDateTime(Rdr("doc_status_date"))
                        If Convert.IsDBNull(Rdr("doc_create_date")) = False Then ret.doc_create_date = Convert.ToDateTime(Rdr("doc_create_date"))
                        If Convert.IsDBNull(Rdr("doc_create_by")) = False Then ret.doc_create_by = Rdr("doc_create_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_edit_date")) = False Then ret.doc_edit_date = Convert.ToDateTime(Rdr("doc_edit_date"))
                        If Convert.IsDBNull(Rdr("doc_edit_by")) = False Then ret.doc_edit_by = Rdr("doc_edit_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_by")) = False Then ret.doc_send_by = Rdr("doc_send_by").ToString()
                        If Convert.IsDBNull(Rdr("doc_send_date")) = False Then ret.doc_send_date = Convert.ToDateTime(Rdr("doc_send_date"))
                        If Convert.IsDBNull(Rdr("doc_org_from")) = False Then ret.doc_org_from = Rdr("doc_org_from").ToString()
                        If Convert.IsDBNull(Rdr("doc_to")) = False Then ret.doc_to = Rdr("doc_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_org_to")) = False Then ret.doc_org_to = Rdr("doc_org_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_obj_to")) = False Then ret.doc_obj_to = Rdr("doc_obj_to").ToString()
                        If Convert.IsDBNull(Rdr("doc_approved")) = False Then ret.doc_approved = Rdr("doc_approved").ToString()
                        If Convert.IsDBNull(Rdr("doc_OwnerAddress2")) = False Then ret.doc_OwnerAddress2 = Rdr("doc_OwnerAddress2").ToString()
                        If Convert.IsDBNull(Rdr("is_read")) = False Then ret.is_read = Rdr("is_read").ToString()
                        If Convert.IsDBNull(Rdr("sendback_remarks")) = False Then ret.sendback_remarks = Rdr("sendback_remarks").ToString()
                        If Convert.IsDBNull(Rdr("is_send")) = False Then ret.is_send = Rdr("is_send").ToString()

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


        'Get Insert Statement for table DOC_TRANS
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID_REF, DOC_NO, DOC_SECRET, DOC_SPEED, DOC_DATE1, DOC_DATE2, DOC_ORGBOOKOWNER, DOC_OWNERADDRESS, DOC_TITLE, DOC_TITLECOMMAND, DOC_REFNO, DOC_TITLE_WHEN, DOC_TITLE_AT, DOC_TITLE_REGIS, DOC_TITLE_MEET, DOC_TITLE_NOMEET, DOC_TITLE_GROUP, DOC_MEMO_WONER, DOC_CONTENT, DOC_LEAN, DOC_REFTO, DOC_ATTACH, DOC_POSCRIPT, DOC_OFFICESIGN, DOC_POSITION, DOC_POSITIONSIGN, DOC_TITLEOWNER, DOC_TEL, DOC_FAX, DOC_ADDR, DOC_CCTO, DOC_DETAIL, DOC_TYPE, DOC_USER, DOC_STATUS, DOC_STATUS_DATE, DOC_CREATE_DATE, DOC_CREATE_BY, DOC_EDIT_DATE, DOC_EDIT_BY, DOC_SEND_BY, DOC_SEND_DATE, DOC_ORG_FROM, DOC_TO, DOC_ORG_TO, DOC_OBJ_TO, DOC_APPROVED, DOC_OWNERADDRESS2, IS_READ, SENDBACK_REMARKS, IS_SEND)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID_REF) & ", "
                sql += DB.SetString(_DOC_NO) & ", "
                sql += DB.SetString(_DOC_SECRET) & ", "
                sql += DB.SetString(_DOC_SPEED) & ", "
                sql += DB.SetDateTime(_DOC_DATE1) & ", "
                sql += DB.SetDateTime(_DOC_DATE2) & ", "
                sql += DB.SetString(_DOC_ORGBOOKOWNER) & ", "
                sql += DB.SetString(_DOC_OWNERADDRESS) & ", "
                sql += DB.SetString(_DOC_TITLE) & ", "
                sql += DB.SetString(_DOC_TITLECOMMAND) & ", "
                sql += DB.SetString(_DOC_REFNO) & ", "
                sql += DB.SetString(_DOC_TITLE_WHEN) & ", "
                sql += DB.SetString(_DOC_TITLE_AT) & ", "
                sql += DB.SetString(_DOC_TITLE_REGIS) & ", "
                sql += DB.SetString(_DOC_TITLE_MEET) & ", "
                sql += DB.SetString(_DOC_TITLE_NOMEET) & ", "
                sql += DB.SetString(_DOC_TITLE_GROUP) & ", "
                sql += DB.SetString(_DOC_MEMO_WONER) & ", "
                sql += DB.SetString(_DOC_CONTENT) & ", "
                sql += DB.SetString(_DOC_LEAN) & ", "
                sql += DB.SetString(_DOC_REFTO) & ", "
                sql += DB.SetString(_DOC_ATTACH) & ", "
                sql += DB.SetString(_DOC_POSCRIPT) & ", "
                sql += DB.SetString(_DOC_OFFICESIGN) & ", "
                sql += DB.SetString(_DOC_POSITION) & ", "
                sql += DB.SetString(_DOC_POSITIONSIGN) & ", "
                sql += DB.SetString(_DOC_TITLEOWNER) & ", "
                sql += DB.SetString(_DOC_TEL) & ", "
                sql += DB.SetString(_DOC_FAX) & ", "
                sql += DB.SetString(_DOC_ADDR) & ", "
                sql += DB.SetString(_DOC_CCTO) & ", "
                sql += DB.SetString(_DOC_DETAIL) & ", "
                sql += DB.SetDouble(_DOC_TYPE) & ", "
                sql += DB.SetString(_DOC_USER) & ", "
                sql += DB.SetString(_DOC_STATUS) & ", "
                sql += DB.SetDateTime(_DOC_STATUS_DATE) & ", "
                sql += DB.SetDateTime(_DOC_CREATE_DATE) & ", "
                sql += DB.SetString(_DOC_CREATE_BY) & ", "
                sql += DB.SetDateTime(_DOC_EDIT_DATE) & ", "
                sql += DB.SetString(_DOC_EDIT_BY) & ", "
                sql += DB.SetString(_DOC_SEND_BY) & ", "
                sql += DB.SetDateTime(_DOC_SEND_DATE) & ", "
                sql += DB.SetString(_DOC_ORG_FROM) & ", "
                sql += DB.SetString(_DOC_TO) & ", "
                sql += DB.SetString(_DOC_ORG_TO) & ", "
                sql += DB.SetString(_DOC_OBJ_TO) & ", "
                sql += DB.SetString(_DOC_APPROVED) & ", "
                sql += DB.SetString(_DOC_OWNERADDRESS2) & ", "
                sql += DB.SetString(_IS_READ) & ", "
                sql += DB.SetString(_SENDBACK_REMARKS) & ", "
                sql += DB.SetString(_IS_SEND)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOC_TRANS
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "ID_REF = " & DB.SetDouble(_ID_REF) & ", "
                Sql += "DOC_NO = " & DB.SetString(_DOC_NO) & ", "
                Sql += "DOC_SECRET = " & DB.SetString(_DOC_SECRET) & ", "
                Sql += "DOC_SPEED = " & DB.SetString(_DOC_SPEED) & ", "
                Sql += "DOC_DATE1 = " & DB.SetDateTime(_DOC_DATE1) & ", "
                Sql += "DOC_DATE2 = " & DB.SetDateTime(_DOC_DATE2) & ", "
                Sql += "DOC_ORGBOOKOWNER = " & DB.SetString(_DOC_ORGBOOKOWNER) & ", "
                Sql += "DOC_OWNERADDRESS = " & DB.SetString(_DOC_OWNERADDRESS) & ", "
                Sql += "DOC_TITLE = " & DB.SetString(_DOC_TITLE) & ", "
                Sql += "DOC_TITLECOMMAND = " & DB.SetString(_DOC_TITLECOMMAND) & ", "
                Sql += "DOC_REFNO = " & DB.SetString(_DOC_REFNO) & ", "
                Sql += "DOC_TITLE_WHEN = " & DB.SetString(_DOC_TITLE_WHEN) & ", "
                Sql += "DOC_TITLE_AT = " & DB.SetString(_DOC_TITLE_AT) & ", "
                Sql += "DOC_TITLE_REGIS = " & DB.SetString(_DOC_TITLE_REGIS) & ", "
                Sql += "DOC_TITLE_MEET = " & DB.SetString(_DOC_TITLE_MEET) & ", "
                Sql += "DOC_TITLE_NOMEET = " & DB.SetString(_DOC_TITLE_NOMEET) & ", "
                Sql += "DOC_TITLE_GROUP = " & DB.SetString(_DOC_TITLE_GROUP) & ", "
                Sql += "DOC_MEMO_WONER = " & DB.SetString(_DOC_MEMO_WONER) & ", "
                Sql += "DOC_CONTENT = " & DB.SetString(_DOC_CONTENT) & ", "
                Sql += "DOC_LEAN = " & DB.SetString(_DOC_LEAN) & ", "
                Sql += "DOC_REFTO = " & DB.SetString(_DOC_REFTO) & ", "
                Sql += "DOC_ATTACH = " & DB.SetString(_DOC_ATTACH) & ", "
                Sql += "DOC_POSCRIPT = " & DB.SetString(_DOC_POSCRIPT) & ", "
                Sql += "DOC_OFFICESIGN = " & DB.SetString(_DOC_OFFICESIGN) & ", "
                Sql += "DOC_POSITION = " & DB.SetString(_DOC_POSITION) & ", "
                Sql += "DOC_POSITIONSIGN = " & DB.SetString(_DOC_POSITIONSIGN) & ", "
                Sql += "DOC_TITLEOWNER = " & DB.SetString(_DOC_TITLEOWNER) & ", "
                Sql += "DOC_TEL = " & DB.SetString(_DOC_TEL) & ", "
                Sql += "DOC_FAX = " & DB.SetString(_DOC_FAX) & ", "
                Sql += "DOC_ADDR = " & DB.SetString(_DOC_ADDR) & ", "
                Sql += "DOC_CCTO = " & DB.SetString(_DOC_CCTO) & ", "
                Sql += "DOC_DETAIL = " & DB.SetString(_DOC_DETAIL) & ", "
                Sql += "DOC_TYPE = " & DB.SetDouble(_DOC_TYPE) & ", "
                Sql += "DOC_USER = " & DB.SetString(_DOC_USER) & ", "
                Sql += "DOC_STATUS = " & DB.SetString(_DOC_STATUS) & ", "
                Sql += "DOC_STATUS_DATE = " & DB.SetDateTime(_DOC_STATUS_DATE) & ", "
                Sql += "DOC_CREATE_DATE = " & DB.SetDateTime(_DOC_CREATE_DATE) & ", "
                Sql += "DOC_CREATE_BY = " & DB.SetString(_DOC_CREATE_BY) & ", "
                Sql += "DOC_EDIT_DATE = " & DB.SetDateTime(_DOC_EDIT_DATE) & ", "
                Sql += "DOC_EDIT_BY = " & DB.SetString(_DOC_EDIT_BY) & ", "
                Sql += "DOC_SEND_BY = " & DB.SetString(_DOC_SEND_BY) & ", "
                Sql += "DOC_SEND_DATE = " & DB.SetDateTime(_DOC_SEND_DATE) & ", "
                Sql += "DOC_ORG_FROM = " & DB.SetString(_DOC_ORG_FROM) & ", "
                Sql += "DOC_TO = " & DB.SetString(_DOC_TO) & ", "
                Sql += "DOC_ORG_TO = " & DB.SetString(_DOC_ORG_TO) & ", "
                Sql += "DOC_OBJ_TO = " & DB.SetString(_DOC_OBJ_TO) & ", "
                Sql += "DOC_APPROVED = " & DB.SetString(_DOC_APPROVED) & ", "
                Sql += "DOC_OWNERADDRESS2 = " & DB.SetString(_DOC_OWNERADDRESS2) & ", "
                Sql += "IS_READ = " & DB.SetString(_IS_READ) & ", "
                Sql += "SENDBACK_REMARKS = " & DB.SetString(_SENDBACK_REMARKS) & ", "
                Sql += "IS_SEND = " & DB.SetString(_IS_SEND) + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOC_TRANS
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOC_TRANS
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
