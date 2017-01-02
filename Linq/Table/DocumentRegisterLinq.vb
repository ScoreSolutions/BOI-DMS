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
    'Represents a transaction for DOCUMENT_REGISTER table Linq.
    '[Create by  on September, 9 2012]
    Public Class DocumentRegisterLinq
        Public sub DocumentRegisterLinq()

        End Sub 
        ' DOCUMENT_REGISTER
        Const _tableName As String = "DOCUMENT_REGISTER"
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
        Dim _BOOK_NO As  String  = ""
        Dim _REQUEST_NO As  String  = ""
        Dim _GROUP_TITLE_ID As  System.Nullable(Of Long)  = 0
        Dim _TITLE_NAME As  String  = ""
        Dim _REGISTER_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EXPECT_FINISH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_SECRET_ID As  System.Nullable(Of Long)  = 0
        Dim _DOC_SPEED_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID_OWNER As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME As  String  = ""
        Dim _ORGANIZATION_APPNAME As  String  = ""
        Dim _OFFICER_ID_APPROVE As  System.Nullable(Of Long)  = 0
        Dim _OFFICER_NAME As  String  = ""
        Dim _OFFICER_ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _ADMINISTRATION_TYPE As  System.Nullable(Of Char)  = "1"
        Dim _REMARKS As  String  = ""
        Dim _BUSINESS_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _COMPANY_ID As  System.Nullable(Of Long)  = 0
        Dim _COMPANY_NAME As  String  = ""
        Dim _COMPANY_DOC_NO As  String  = ""
        Dim _COMPANY_DOC_TYPE_ID As  String  = ""
        Dim _COMPANY_DOC_SYS_ID As  String  = ""
        Dim _COMPANY_REQ_ID As  String  = ""
        Dim _COMPANY_DOC_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _COMPANY_SIGN As  String  = ""
        Dim _COMPANY_SIGN_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_STATUS_ID As  String  = ""
        Dim _USERNAME_REGISTER As  String  = ""
        Dim _ORGANIZATION_ID_REGISTER As  System.Nullable(Of Long)  = 0
        Dim _CLOSE_BY As  String  = ""
        Dim _CLOSE_BY_NAME As  String  = ""
        Dim _CLOSE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _BOOKOUT_NO As  String  = ""
        Dim _ORGANIZATION_ID_PROCESS As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID_STORAGE As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_STORAGE As  String  = ""
        Dim _ID_MUST_RECEIVE_DOC As  System.Nullable(Of Char)  = ""
        Dim _ELECTRONIC_DOC_ID As  System.Nullable(Of Long)  = 0
        Dim _DOC_SYS_CODE As  String  = ""
        Dim _REF_OLD_ID As  String  = ""
        Dim _DOCUMENT_RECEIVE_TYPE As  System.Nullable(Of Long)  = 0
        Dim _OFFICER_ID_POSSESS As  System.Nullable(Of Long)  = 0
        Dim _OFFICER_NAME_POSSESS As  String  = ""
        Dim _REF_DOCUMENT_REGISTER_ID As  System.Nullable(Of Long)  = 0
        Dim _CLOSE_REMARKS As  String  = ""
        Dim _ORGANIZATION_NAME_PROCESS As  String  = ""
        Dim _ORGANIZATION_ABBNAME_PROCESS As  String  = ""
        Dim _COMPANY_CERT_NO As  String  = ""
        Dim _COMPANY_NOTIFY_NO As  String  = ""
        Dim _REF_TH_EGIF_DOC_INBOUND_ID As  String  = ""
        Dim _BOOKOUT_DATE As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _COMPANY_REGIS_NO As String = ""
        Dim _COMPANY_IDCARD_NO As String = ""
        Dim _COMPANY_PASSPORT_NO As String = ""

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
        <Column(Storage:="_BOOK_NO", DbType:="VarChar(50)")>  _
        Public Property BOOK_NO() As  String 
            Get
                Return _BOOK_NO
            End Get
            Set(ByVal value As  String )
               _BOOK_NO = value
            End Set
        End Property 
        <Column(Storage:="_REQUEST_NO", DbType:="VarChar(50)")>  _
        Public Property REQUEST_NO() As  String 
            Get
                Return _REQUEST_NO
            End Get
            Set(ByVal value As  String )
               _REQUEST_NO = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_TITLE_ID", DbType:="BigInt")>  _
        Public Property GROUP_TITLE_ID() As  System.Nullable(Of Long) 
            Get
                Return _GROUP_TITLE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _GROUP_TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_TITLE_NAME", DbType:="VarChar(255)")>  _
        Public Property TITLE_NAME() As  String 
            Get
                Return _TITLE_NAME
            End Get
            Set(ByVal value As  String )
               _TITLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_REGISTER_DATE", DbType:="DateTime")>  _
        Public Property REGISTER_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _REGISTER_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _REGISTER_DATE = value
            End Set
        End Property 
        <Column(Storage:="_EXPECT_FINISH_DATE", DbType:="DateTime")>  _
        Public Property EXPECT_FINISH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EXPECT_FINISH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EXPECT_FINISH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SECRET_ID", DbType:="BigInt")>  _
        Public Property DOC_SECRET_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOC_SECRET_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOC_SECRET_ID = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SPEED_ID", DbType:="BigInt")>  _
        Public Property DOC_SPEED_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOC_SPEED_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOC_SPEED_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_OWNER", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_OWNER() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_OWNER
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_OWNER = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME() As  String 
            Get
                Return _ORGANIZATION_NAME
            End Get
            Set(ByVal value As  String )
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
        <Column(Storage:="_OFFICER_ID_APPROVE", DbType:="BigInt")>  _
        Public Property OFFICER_ID_APPROVE() As  System.Nullable(Of Long) 
            Get
                Return _OFFICER_ID_APPROVE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _OFFICER_ID_APPROVE = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_NAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_NAME() As  String 
            Get
                Return _OFFICER_NAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property OFFICER_ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _OFFICER_ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _OFFICER_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ADMINISTRATION_TYPE", DbType:="Char(1)")>  _
        Public Property ADMINISTRATION_TYPE() As  System.Nullable(Of Char) 
            Get
                Return _ADMINISTRATION_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ADMINISTRATION_TYPE = value
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
        <Column(Storage:="_BUSINESS_TYPE_ID", DbType:="BigInt")>  _
        Public Property BUSINESS_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _BUSINESS_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _BUSINESS_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_ID", DbType:="BigInt")>  _
        Public Property COMPANY_ID() As  System.Nullable(Of Long) 
            Get
                Return _COMPANY_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COMPANY_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255)")>  _
        Public Property COMPANY_NAME() As  String 
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As  String )
               _COMPANY_NAME = value
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
        <Column(Storage:="_COMPANY_DOC_TYPE_ID", DbType:="VarChar(50)")>  _
        Public Property COMPANY_DOC_TYPE_ID() As  String 
            Get
                Return _COMPANY_DOC_TYPE_ID
            End Get
            Set(ByVal value As  String )
               _COMPANY_DOC_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_DOC_SYS_ID", DbType:="VarChar(50)")>  _
        Public Property COMPANY_DOC_SYS_ID() As  String 
            Get
                Return _COMPANY_DOC_SYS_ID
            End Get
            Set(ByVal value As  String )
               _COMPANY_DOC_SYS_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_REQ_ID", DbType:="VarChar(50)")>  _
        Public Property COMPANY_REQ_ID() As  String 
            Get
                Return _COMPANY_REQ_ID
            End Get
            Set(ByVal value As  String )
               _COMPANY_REQ_ID = value
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
        <Column(Storage:="_COMPANY_SIGN", DbType:="VarChar(255)")>  _
        Public Property COMPANY_SIGN() As  String 
            Get
                Return _COMPANY_SIGN
            End Get
            Set(ByVal value As  String )
               _COMPANY_SIGN = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_SIGN_DATE", DbType:="DateTime")>  _
        Public Property COMPANY_SIGN_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _COMPANY_SIGN_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _COMPANY_SIGN_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_STATUS_ID", DbType:="VarChar(50)")>  _
        Public Property DOC_STATUS_ID() As  String 
            Get
                Return _DOC_STATUS_ID
            End Get
            Set(ByVal value As  String )
               _DOC_STATUS_ID = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME_REGISTER", DbType:="VarChar(50)")>  _
        Public Property USERNAME_REGISTER() As  String 
            Get
                Return _USERNAME_REGISTER
            End Get
            Set(ByVal value As  String )
               _USERNAME_REGISTER = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_REGISTER", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_REGISTER() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_REGISTER
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_REGISTER = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY", DbType:="VarChar(50)")>  _
        Public Property CLOSE_BY() As  String 
            Get
                Return _CLOSE_BY
            End Get
            Set(ByVal value As  String )
               _CLOSE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY_NAME", DbType:="VarChar(255)")>  _
        Public Property CLOSE_BY_NAME() As  String 
            Get
                Return _CLOSE_BY_NAME
            End Get
            Set(ByVal value As  String )
               _CLOSE_BY_NAME = value
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
        <Column(Storage:="_BOOKOUT_NO", DbType:="VarChar(50)")>  _
        Public Property BOOKOUT_NO() As  String 
            Get
                Return _BOOKOUT_NO
            End Get
            Set(ByVal value As  String )
               _BOOKOUT_NO = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_PROCESS", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_PROCESS() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_PROCESS
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_PROCESS = value
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
        <Column(Storage:="_ID_MUST_RECEIVE_DOC", DbType:="Char(1)")>  _
        Public Property ID_MUST_RECEIVE_DOC() As  System.Nullable(Of Char) 
            Get
                Return _ID_MUST_RECEIVE_DOC
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ID_MUST_RECEIVE_DOC = value
            End Set
        End Property 
        <Column(Storage:="_ELECTRONIC_DOC_ID", DbType:="BigInt")>  _
        Public Property ELECTRONIC_DOC_ID() As  System.Nullable(Of Long) 
            Get
                Return _ELECTRONIC_DOC_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ELECTRONIC_DOC_ID = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SYS_CODE", DbType:="VarChar(50)")>  _
        Public Property DOC_SYS_CODE() As  String 
            Get
                Return _DOC_SYS_CODE
            End Get
            Set(ByVal value As  String )
               _DOC_SYS_CODE = value
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
        <Column(Storage:="_DOCUMENT_RECEIVE_TYPE", DbType:="Int")>  _
        Public Property DOCUMENT_RECEIVE_TYPE() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_RECEIVE_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_RECEIVE_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_ID_POSSESS", DbType:="Int")>  _
        Public Property OFFICER_ID_POSSESS() As  System.Nullable(Of Long) 
            Get
                Return _OFFICER_ID_POSSESS
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _OFFICER_ID_POSSESS = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_NAME_POSSESS", DbType:="VarChar(255)")>  _
        Public Property OFFICER_NAME_POSSESS() As  String 
            Get
                Return _OFFICER_NAME_POSSESS
            End Get
            Set(ByVal value As  String )
               _OFFICER_NAME_POSSESS = value
            End Set
        End Property 
        <Column(Storage:="_REF_DOCUMENT_REGISTER_ID", DbType:="BigInt")>  _
        Public Property REF_DOCUMENT_REGISTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_REMARKS", DbType:="VarChar(500)")>  _
        Public Property CLOSE_REMARKS() As  String 
            Get
                Return _CLOSE_REMARKS
            End Get
            Set(ByVal value As  String )
               _CLOSE_REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_PROCESS", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_PROCESS() As  String 
            Get
                Return _ORGANIZATION_NAME_PROCESS
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_PROCESS = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ABBNAME_PROCESS", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_ABBNAME_PROCESS() As  String 
            Get
                Return _ORGANIZATION_ABBNAME_PROCESS
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_ABBNAME_PROCESS = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_CERT_NO", DbType:="VarChar(255)")>  _
        Public Property COMPANY_CERT_NO() As  String 
            Get
                Return _COMPANY_CERT_NO
            End Get
            Set(ByVal value As  String )
               _COMPANY_CERT_NO = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NOTIFY_NO", DbType:="VarChar(255)")>  _
        Public Property COMPANY_NOTIFY_NO() As  String 
            Get
                Return _COMPANY_NOTIFY_NO
            End Get
            Set(ByVal value As  String )
               _COMPANY_NOTIFY_NO = value
            End Set
        End Property 
        <Column(Storage:="_REF_TH_EGIF_DOC_INBOUND_ID", DbType:="VarChar(50)")>  _
        Public Property REF_TH_EGIF_DOC_INBOUND_ID() As  String 
            Get
                Return _REF_TH_EGIF_DOC_INBOUND_ID
            End Get
            Set(ByVal value As  String )
               _REF_TH_EGIF_DOC_INBOUND_ID = value
            End Set
        End Property 
        <Column(Storage:="_BOOKOUT_DATE", DbType:="DateTime")>  _
        Public Property BOOKOUT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _BOOKOUT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _BOOKOUT_DATE = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_REGIS_NO", DbType:="VarChar(50)")> _
        Public Property COMPANY_REGIS_NO() As String
            Get
                Return _COMPANY_REGIS_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_REGIS_NO = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_IDCARD_NO", DbType:="VarChar(50)")> _
        Public Property COMPANY_IDCARD_NO() As String
            Get
                Return _COMPANY_IDCARD_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_IDCARD_NO = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_PASSPORT_NO", DbType:="VarChar(50)")> _
        Public Property COMPANY_PASSPORT_NO() As String
            Get
                Return _COMPANY_PASSPORT_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_PASSPORT_NO = value
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
            _REQUEST_NO = ""
            _GROUP_TITLE_ID = 0
            _TITLE_NAME = ""
            _REGISTER_DATE = New DateTime(1,1,1)
            _EXPECT_FINISH_DATE = New DateTime(1,1,1)
            _DOC_SECRET_ID = 0
            _DOC_SPEED_ID = 0
            _ORGANIZATION_ID_OWNER = 0
            _ORGANIZATION_NAME = ""
            _ORGANIZATION_APPNAME = ""
            _OFFICER_ID_APPROVE = 0
            _OFFICER_NAME = ""
            _OFFICER_ORGANIZATION_ID = 0
            _ADMINISTRATION_TYPE = ""
            _REMARKS = ""
            _BUSINESS_TYPE_ID = 0
            _COMPANY_ID = 0
            _COMPANY_NAME = ""
            _COMPANY_DOC_NO = ""
            _COMPANY_DOC_TYPE_ID = ""
            _COMPANY_DOC_SYS_ID = ""
            _COMPANY_REQ_ID = ""
            _COMPANY_DOC_DATE = New DateTime(1,1,1)
            _COMPANY_SIGN = ""
            _COMPANY_SIGN_DATE = New DateTime(1,1,1)
            _DOC_STATUS_ID = ""
            _USERNAME_REGISTER = ""
            _ORGANIZATION_ID_REGISTER = 0
            _CLOSE_BY = ""
            _CLOSE_BY_NAME = ""
            _CLOSE_DATE = New DateTime(1,1,1)
            _BOOKOUT_NO = ""
            _ORGANIZATION_ID_PROCESS = 0
            _ORGANIZATION_ID_STORAGE = 0
            _ORGANIZATION_NAME_STORAGE = ""
            _ID_MUST_RECEIVE_DOC = ""
            _ELECTRONIC_DOC_ID = 0
            _DOC_SYS_CODE = ""
            _REF_OLD_ID = ""
            _DOCUMENT_RECEIVE_TYPE = 0
            _OFFICER_ID_POSSESS = 0
            _OFFICER_NAME_POSSESS = ""
            _REF_DOCUMENT_REGISTER_ID = 0
            _CLOSE_REMARKS = ""
            _ORGANIZATION_NAME_PROCESS = ""
            _ORGANIZATION_ABBNAME_PROCESS = ""
            _COMPANY_CERT_NO = ""
            _COMPANY_NOTIFY_NO = ""
            _REF_TH_EGIF_DOC_INBOUND_ID = ""
            _BOOKOUT_DATE = New DateTime(1, 1, 1)
            _COMPANY_REGIS_NO = ""
            _COMPANY_IDCARD_NO = ""
            _COMPANY_PASSPORT_NO = ""
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


        '/// Returns an indication whether the current data is inserted into DOCUMENT_REGISTER table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                '_id = DB.GetNextID("id",tableName, trans)
                _CREATE_BY = LoginName
                _CREATE_ON = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to DOCUMENT_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_REGISTER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from DOCUMENT_REGISTER table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of DOCUMENT_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cid As Long, trans As SQLTransaction) As DocumentRegisterLinq
            Return doGetData("id = " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Para Class of DOCUMENT_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetParameter(cid As Long, trans As SQLTransaction) As DocumentRegisterPara
            Return doMappingParameter("id = " & DB.SetDouble(cid) & " ", trans)
        End Function

        Public Function GetParameterByBookNo(ByVal cBookNo As String, ByVal trans As SqlTransaction) As DocumentRegisterPara
            Return doMappingParameter("book_no = " & DB.SetString(cBookNo) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_REGISTER by specified BOOK_NO key is retrieved successfully.
        '/// <param name=cBOOK_NO>The BOOK_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBOOK_NO(cBOOK_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("BOOK_NO = " & DB.SetString(cBOOK_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of DOCUMENT_REGISTER by specified BOOK_NO key is retrieved successfully.
        '/// <param name=cBOOK_NO>The BOOK_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBOOK_NO(cBOOK_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BOOK_NO = " & DB.SetString(cBOOK_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of DOCUMENT_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into DOCUMENT_REGISTER table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try

                    'ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    'If ret = False Then
                    '    _error = DB.ErrorMessage
                    'Else
                    '    _haveData = True
                    'End If
                    '_information = MessageResources.MSGIN001

                    Dim dt As DataTable = DB.ExecuteTable(SqlInsert, trans)
                    If dt.Rows.Count > 0 Then
                        _ID = Convert.ToInt64(dt.Rows(0)("id"))
                        ret = (_ID > 0)
                        If ret = False Then
                            _error = DB.ErrorMessage
                        Else
                            _haveData = True
                        End If
                        _information = MessageResources.MSGIN001
                    Else
                        ret = False
                    End If
                    dt.Dispose()
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


        '/// Returns an indication whether the current data is updated to DOCUMENT_REGISTER table successfully.
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


        '/// Returns an indication whether the current data is deleted from DOCUMENT_REGISTER table successfully.
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


        '/// Returns an indication whether the record of DOCUMENT_REGISTER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("book_no")) = False Then _book_no = Rdr("book_no").ToString()
                        If Convert.IsDBNull(Rdr("request_no")) = False Then _request_no = Rdr("request_no").ToString()
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then _group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expect_finish_date")) = False Then _expect_finish_date = Convert.ToDateTime(Rdr("expect_finish_date"))
                        If Convert.IsDBNull(Rdr("doc_secret_id")) = False Then _doc_secret_id = Convert.ToInt64(Rdr("doc_secret_id"))
                        If Convert.IsDBNull(Rdr("doc_speed_id")) = False Then _doc_speed_id = Convert.ToInt64(Rdr("doc_speed_id"))
                        If Convert.IsDBNull(Rdr("organization_id_owner")) = False Then _organization_id_owner = Convert.ToInt64(Rdr("organization_id_owner"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then _organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then _organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_approve")) = False Then _officer_id_approve = Convert.ToInt64(Rdr("officer_id_approve"))
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_organization_id")) = False Then _officer_organization_id = Convert.ToInt64(Rdr("officer_organization_id"))
                        If Convert.IsDBNull(Rdr("administration_type")) = False Then _administration_type = Rdr("administration_type").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("business_type_id")) = False Then _business_type_id = Convert.ToInt64(Rdr("business_type_id"))
                        If Convert.IsDBNull(Rdr("company_id")) = False Then _company_id = Convert.ToInt64(Rdr("company_id"))
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then _company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_type_id")) = False Then _company_doc_type_id = Rdr("company_doc_type_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_sys_id")) = False Then _company_doc_sys_id = Rdr("company_doc_sys_id").ToString()
                        If Convert.IsDBNull(Rdr("company_req_id")) = False Then _company_req_id = Rdr("company_req_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then _company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then _company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("company_sign_date")) = False Then _company_sign_date = Convert.ToDateTime(Rdr("company_sign_date"))
                        If Convert.IsDBNull(Rdr("doc_status_id")) = False Then _doc_status_id = Rdr("doc_status_id").ToString()
                        If Convert.IsDBNull(Rdr("username_register")) = False Then _username_register = Rdr("username_register").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_register")) = False Then _organization_id_register = Convert.ToInt64(Rdr("organization_id_register"))
                        If Convert.IsDBNull(Rdr("close_by")) = False Then _close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then _close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("bookout_no")) = False Then _bookout_no = Rdr("bookout_no").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_process")) = False Then _organization_id_process = Convert.ToInt64(Rdr("organization_id_process"))
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then _organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then _organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("id_must_receive_doc")) = False Then _id_must_receive_doc = Rdr("id_must_receive_doc").ToString()
                        If Convert.IsDBNull(Rdr("electronic_doc_id")) = False Then _electronic_doc_id = Convert.ToInt64(Rdr("electronic_doc_id"))
                        If Convert.IsDBNull(Rdr("doc_sys_code")) = False Then _doc_sys_code = Rdr("doc_sys_code").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("document_receive_type")) = False Then _document_receive_type = Convert.ToInt32(Rdr("document_receive_type"))
                        If Convert.IsDBNull(Rdr("officer_id_possess")) = False Then _officer_id_possess = Convert.ToInt32(Rdr("officer_id_possess"))
                        If Convert.IsDBNull(Rdr("officer_name_possess")) = False Then _officer_name_possess = Rdr("officer_name_possess").ToString()
                        If Convert.IsDBNull(Rdr("ref_document_register_id")) = False Then _ref_document_register_id = Convert.ToInt64(Rdr("ref_document_register_id"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then _close_remarks = Rdr("close_remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_name_process")) = False Then _organization_name_process = Rdr("organization_name_process").ToString()
                        If Convert.IsDBNull(Rdr("organization_abbname_process")) = False Then _organization_abbname_process = Rdr("organization_abbname_process").ToString()
                        If Convert.IsDBNull(Rdr("company_cert_no")) = False Then _company_cert_no = Rdr("company_cert_no").ToString()
                        If Convert.IsDBNull(Rdr("company_notify_no")) = False Then _company_notify_no = Rdr("company_notify_no").ToString()
                        If Convert.IsDBNull(Rdr("ref_th_egif_doc_inbound_id")) = False Then _ref_th_egif_doc_inbound_id = Rdr("ref_th_egif_doc_inbound_id").ToString()
                        If Convert.IsDBNull(Rdr("bookout_date")) = False Then _BOOKOUT_DATE = Convert.ToDateTime(Rdr("bookout_date"))
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then _COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()
                        If Convert.IsDBNull(Rdr("company_idcard_no")) = False Then _COMPANY_IDCARD_NO = Rdr("company_idcard_no").ToString()
                        If Convert.IsDBNull(Rdr("company_passport_no")) = False Then _COMPANY_PASSPORT_NO = Rdr("company_passport_no").ToString()
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


        '/// Returns an indication whether the record of DOCUMENT_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As DocumentRegisterLinq
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
                        If Convert.IsDBNull(Rdr("request_no")) = False Then _request_no = Rdr("request_no").ToString()
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then _group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then _register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expect_finish_date")) = False Then _expect_finish_date = Convert.ToDateTime(Rdr("expect_finish_date"))
                        If Convert.IsDBNull(Rdr("doc_secret_id")) = False Then _doc_secret_id = Convert.ToInt64(Rdr("doc_secret_id"))
                        If Convert.IsDBNull(Rdr("doc_speed_id")) = False Then _doc_speed_id = Convert.ToInt64(Rdr("doc_speed_id"))
                        If Convert.IsDBNull(Rdr("organization_id_owner")) = False Then _organization_id_owner = Convert.ToInt64(Rdr("organization_id_owner"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then _organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then _organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_approve")) = False Then _officer_id_approve = Convert.ToInt64(Rdr("officer_id_approve"))
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_organization_id")) = False Then _officer_organization_id = Convert.ToInt64(Rdr("officer_organization_id"))
                        If Convert.IsDBNull(Rdr("administration_type")) = False Then _administration_type = Rdr("administration_type").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then _remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("business_type_id")) = False Then _business_type_id = Convert.ToInt64(Rdr("business_type_id"))
                        If Convert.IsDBNull(Rdr("company_id")) = False Then _company_id = Convert.ToInt64(Rdr("company_id"))
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then _company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_type_id")) = False Then _company_doc_type_id = Rdr("company_doc_type_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_sys_id")) = False Then _company_doc_sys_id = Rdr("company_doc_sys_id").ToString()
                        If Convert.IsDBNull(Rdr("company_req_id")) = False Then _company_req_id = Rdr("company_req_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then _company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then _company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("company_sign_date")) = False Then _company_sign_date = Convert.ToDateTime(Rdr("company_sign_date"))
                        If Convert.IsDBNull(Rdr("doc_status_id")) = False Then _doc_status_id = Rdr("doc_status_id").ToString()
                        If Convert.IsDBNull(Rdr("username_register")) = False Then _username_register = Rdr("username_register").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_register")) = False Then _organization_id_register = Convert.ToInt64(Rdr("organization_id_register"))
                        If Convert.IsDBNull(Rdr("close_by")) = False Then _close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then _close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then _close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("bookout_no")) = False Then _bookout_no = Rdr("bookout_no").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_process")) = False Then _organization_id_process = Convert.ToInt64(Rdr("organization_id_process"))
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then _organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then _organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("id_must_receive_doc")) = False Then _id_must_receive_doc = Rdr("id_must_receive_doc").ToString()
                        If Convert.IsDBNull(Rdr("electronic_doc_id")) = False Then _electronic_doc_id = Convert.ToInt64(Rdr("electronic_doc_id"))
                        If Convert.IsDBNull(Rdr("doc_sys_code")) = False Then _doc_sys_code = Rdr("doc_sys_code").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then _ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("document_receive_type")) = False Then _document_receive_type = Convert.ToInt32(Rdr("document_receive_type"))
                        If Convert.IsDBNull(Rdr("officer_id_possess")) = False Then _officer_id_possess = Convert.ToInt32(Rdr("officer_id_possess"))
                        If Convert.IsDBNull(Rdr("officer_name_possess")) = False Then _officer_name_possess = Rdr("officer_name_possess").ToString()
                        If Convert.IsDBNull(Rdr("ref_document_register_id")) = False Then _ref_document_register_id = Convert.ToInt64(Rdr("ref_document_register_id"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then _close_remarks = Rdr("close_remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_name_process")) = False Then _organization_name_process = Rdr("organization_name_process").ToString()
                        If Convert.IsDBNull(Rdr("organization_abbname_process")) = False Then _organization_abbname_process = Rdr("organization_abbname_process").ToString()
                        If Convert.IsDBNull(Rdr("company_cert_no")) = False Then _company_cert_no = Rdr("company_cert_no").ToString()
                        If Convert.IsDBNull(Rdr("company_notify_no")) = False Then _company_notify_no = Rdr("company_notify_no").ToString()
                        If Convert.IsDBNull(Rdr("ref_th_egif_doc_inbound_id")) = False Then _ref_th_egif_doc_inbound_id = Rdr("ref_th_egif_doc_inbound_id").ToString()
                        If Convert.IsDBNull(Rdr("bookout_date")) = False Then _BOOKOUT_DATE = Convert.ToDateTime(Rdr("bookout_date"))
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then _COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()
                        If Convert.IsDBNull(Rdr("company_idcard_no")) = False Then _COMPANY_IDCARD_NO = Rdr("company_idcard_no").ToString()
                        If Convert.IsDBNull(Rdr("company_passport_no")) = False Then _COMPANY_PASSPORT_NO = Rdr("company_passport_no").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : DOCUMENT_CANCEL_CLOSE Column :document_register_id
                        Dim DocumentCancelClose_document_register_idItem As New DocumentCancelCloseLinq
                        _DOCUMENT_CANCEL_CLOSE_document_register_id = DocumentCancelClose_document_register_idItem.GetDataList("document_register_id = " & _ID, "", Nothing)

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


        '/// Returns an indication whether the Class Data of DOCUMENT_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doMappingParameter(whText As String, trans As SQLTransaction) As DocumentRegisterPara
            ClearData()
            _haveData  = False
            Dim ret As New DocumentRegisterPara
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
                        If Convert.IsDBNull(Rdr("request_no")) = False Then ret.request_no = Rdr("request_no").ToString()
                        If Convert.IsDBNull(Rdr("group_title_id")) = False Then ret.group_title_id = Convert.ToInt64(Rdr("group_title_id"))
                        If Convert.IsDBNull(Rdr("title_name")) = False Then ret.title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("register_date")) = False Then ret.register_date = Convert.ToDateTime(Rdr("register_date"))
                        If Convert.IsDBNull(Rdr("expect_finish_date")) = False Then ret.expect_finish_date = Convert.ToDateTime(Rdr("expect_finish_date"))
                        If Convert.IsDBNull(Rdr("doc_secret_id")) = False Then ret.doc_secret_id = Convert.ToInt64(Rdr("doc_secret_id"))
                        If Convert.IsDBNull(Rdr("doc_speed_id")) = False Then ret.doc_speed_id = Convert.ToInt64(Rdr("doc_speed_id"))
                        If Convert.IsDBNull(Rdr("organization_id_owner")) = False Then ret.organization_id_owner = Convert.ToInt64(Rdr("organization_id_owner"))
                        If Convert.IsDBNull(Rdr("organization_name")) = False Then ret.organization_name = Rdr("organization_name").ToString()
                        If Convert.IsDBNull(Rdr("organization_appname")) = False Then ret.organization_appname = Rdr("organization_appname").ToString()
                        If Convert.IsDBNull(Rdr("officer_id_approve")) = False Then ret.officer_id_approve = Convert.ToInt64(Rdr("officer_id_approve"))
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then ret.officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_organization_id")) = False Then ret.officer_organization_id = Convert.ToInt64(Rdr("officer_organization_id"))
                        If Convert.IsDBNull(Rdr("administration_type")) = False Then ret.administration_type = Rdr("administration_type").ToString()
                        If Convert.IsDBNull(Rdr("remarks")) = False Then ret.remarks = Rdr("remarks").ToString()
                        If Convert.IsDBNull(Rdr("business_type_id")) = False Then ret.business_type_id = Convert.ToInt64(Rdr("business_type_id"))
                        If Convert.IsDBNull(Rdr("company_id")) = False Then ret.company_id = Convert.ToInt64(Rdr("company_id"))
                        If Convert.IsDBNull(Rdr("company_name")) = False Then ret.company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_no")) = False Then ret.company_doc_no = Rdr("company_doc_no").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_type_id")) = False Then ret.company_doc_type_id = Rdr("company_doc_type_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_sys_id")) = False Then ret.company_doc_sys_id = Rdr("company_doc_sys_id").ToString()
                        If Convert.IsDBNull(Rdr("company_req_id")) = False Then ret.company_req_id = Rdr("company_req_id").ToString()
                        If Convert.IsDBNull(Rdr("company_doc_date")) = False Then ret.company_doc_date = Convert.ToDateTime(Rdr("company_doc_date"))
                        If Convert.IsDBNull(Rdr("company_sign")) = False Then ret.company_sign = Rdr("company_sign").ToString()
                        If Convert.IsDBNull(Rdr("company_sign_date")) = False Then ret.company_sign_date = Convert.ToDateTime(Rdr("company_sign_date"))
                        If Convert.IsDBNull(Rdr("doc_status_id")) = False Then ret.doc_status_id = Rdr("doc_status_id").ToString()
                        If Convert.IsDBNull(Rdr("username_register")) = False Then ret.username_register = Rdr("username_register").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_register")) = False Then ret.organization_id_register = Convert.ToInt64(Rdr("organization_id_register"))
                        If Convert.IsDBNull(Rdr("close_by")) = False Then ret.close_by = Rdr("close_by").ToString()
                        If Convert.IsDBNull(Rdr("close_by_name")) = False Then ret.close_by_name = Rdr("close_by_name").ToString()
                        If Convert.IsDBNull(Rdr("close_date")) = False Then ret.close_date = Convert.ToDateTime(Rdr("close_date"))
                        If Convert.IsDBNull(Rdr("bookout_no")) = False Then ret.bookout_no = Rdr("bookout_no").ToString()
                        If Convert.IsDBNull(Rdr("organization_id_process")) = False Then ret.organization_id_process = Convert.ToInt64(Rdr("organization_id_process"))
                        If Convert.IsDBNull(Rdr("organization_id_storage")) = False Then ret.organization_id_storage = Convert.ToInt64(Rdr("organization_id_storage"))
                        If Convert.IsDBNull(Rdr("organization_name_storage")) = False Then ret.organization_name_storage = Rdr("organization_name_storage").ToString()
                        If Convert.IsDBNull(Rdr("id_must_receive_doc")) = False Then ret.id_must_receive_doc = Rdr("id_must_receive_doc").ToString()
                        If Convert.IsDBNull(Rdr("electronic_doc_id")) = False Then ret.electronic_doc_id = Convert.ToInt64(Rdr("electronic_doc_id"))
                        If Convert.IsDBNull(Rdr("doc_sys_code")) = False Then ret.doc_sys_code = Rdr("doc_sys_code").ToString()
                        If Convert.IsDBNull(Rdr("ref_old_id")) = False Then ret.ref_old_id = Rdr("ref_old_id").ToString()
                        If Convert.IsDBNull(Rdr("document_receive_type")) = False Then ret.document_receive_type = Convert.ToInt32(Rdr("document_receive_type"))
                        If Convert.IsDBNull(Rdr("officer_id_possess")) = False Then ret.officer_id_possess = Convert.ToInt32(Rdr("officer_id_possess"))
                        If Convert.IsDBNull(Rdr("officer_name_possess")) = False Then ret.officer_name_possess = Rdr("officer_name_possess").ToString()
                        If Convert.IsDBNull(Rdr("ref_document_register_id")) = False Then ret.ref_document_register_id = Convert.ToInt64(Rdr("ref_document_register_id"))
                        If Convert.IsDBNull(Rdr("close_remarks")) = False Then ret.close_remarks = Rdr("close_remarks").ToString()
                        If Convert.IsDBNull(Rdr("organization_name_process")) = False Then ret.organization_name_process = Rdr("organization_name_process").ToString()
                        If Convert.IsDBNull(Rdr("organization_abbname_process")) = False Then ret.organization_abbname_process = Rdr("organization_abbname_process").ToString()
                        If Convert.IsDBNull(Rdr("company_cert_no")) = False Then ret.company_cert_no = Rdr("company_cert_no").ToString()
                        If Convert.IsDBNull(Rdr("company_notify_no")) = False Then ret.company_notify_no = Rdr("company_notify_no").ToString()
                        If Convert.IsDBNull(Rdr("ref_th_egif_doc_inbound_id")) = False Then ret.ref_th_egif_doc_inbound_id = Rdr("ref_th_egif_doc_inbound_id").ToString()
                        If Convert.IsDBNull(Rdr("bookout_date")) = False Then ret.BOOKOUT_DATE = Convert.ToDateTime(Rdr("bookout_date"))
                        If Convert.IsDBNull(Rdr("company_regis_no")) = False Then ret.COMPANY_REGIS_NO = Rdr("company_regis_no").ToString()
                        If Convert.IsDBNull(Rdr("company_idcard_no")) = False Then ret.COMPANY_IDCARD_NO = Rdr("company_idcard_no").ToString()
                        If Convert.IsDBNull(Rdr("company_passport_no")) = False Then ret.COMPANY_PASSPORT_NO = Rdr("company_passport_no").ToString()

                        'Generate Item For Child Table
                        'Child Table Name : DOCUMENT_CANCEL_CLOSE Column :document_register_id
                        Dim DocumentCancelClose_document_register_idItem As New DocumentCancelCloseLinq
                        _DOCUMENT_CANCEL_CLOSE_document_register_id = DocumentCancelClose_document_register_idItem.GetDataList("document_register_id = " & ret.id, "", Nothing)
                        ret.CHILD_DOCUMENT_CANCEL_CLOSE_document_register_id = _DOCUMENT_CANCEL_CLOSE_document_register_id


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


        'Get Insert Statement for table DOCUMENT_REGISTER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & TableName & " ( CREATE_BY, CREATE_ON, UPDATE_BY, UPDATE_ON, BOOK_NO, REQUEST_NO, GROUP_TITLE_ID, TITLE_NAME, REGISTER_DATE, EXPECT_FINISH_DATE, DOC_SECRET_ID, DOC_SPEED_ID, ORGANIZATION_ID_OWNER, ORGANIZATION_NAME, ORGANIZATION_APPNAME, OFFICER_ID_APPROVE, OFFICER_NAME, OFFICER_ORGANIZATION_ID, ADMINISTRATION_TYPE, REMARKS, BUSINESS_TYPE_ID, COMPANY_ID, COMPANY_NAME, COMPANY_DOC_NO, COMPANY_DOC_TYPE_ID, COMPANY_DOC_SYS_ID, COMPANY_REQ_ID, COMPANY_DOC_DATE, COMPANY_SIGN, COMPANY_SIGN_DATE, DOC_STATUS_ID, USERNAME_REGISTER, ORGANIZATION_ID_REGISTER, CLOSE_BY, CLOSE_BY_NAME, CLOSE_DATE, BOOKOUT_NO, ORGANIZATION_ID_PROCESS, ORGANIZATION_ID_STORAGE, ORGANIZATION_NAME_STORAGE, ID_MUST_RECEIVE_DOC, ELECTRONIC_DOC_ID, DOC_SYS_CODE, REF_OLD_ID, DOCUMENT_RECEIVE_TYPE, OFFICER_ID_POSSESS, OFFICER_NAME_POSSESS, REF_DOCUMENT_REGISTER_ID, CLOSE_REMARKS, ORGANIZATION_NAME_PROCESS, ORGANIZATION_ABBNAME_PROCESS, COMPANY_CERT_NO, COMPANY_NOTIFY_NO, REF_TH_EGIF_DOC_INBOUND_ID, BOOKOUT_DATE, COMPANY_REGIS_NO, COMPANY_IDCARD_NO, COMPANY_PASSPORT_NO)"
                Sql += " OUTPUT INSERTED.ID "
                Sql += " VALUES("
                sql += DB.SetString(_CREATE_BY) & ", "
                sql += DB.SetDateTime(_CREATE_ON) & ", "
                sql += DB.SetString(_UPDATE_BY) & ", "
                sql += DB.SetDateTime(_UPDATE_ON) & ", "
                sql += DB.SetString(_BOOK_NO) & ", "
                sql += DB.SetString(_REQUEST_NO) & ", "
                sql += DB.SetDouble(_GROUP_TITLE_ID) & ", "
                sql += DB.SetString(_TITLE_NAME) & ", "
                sql += DB.SetDateTime(_REGISTER_DATE) & ", "
                sql += DB.SetDateTime(_EXPECT_FINISH_DATE) & ", "
                sql += DB.SetDouble(_DOC_SECRET_ID) & ", "
                sql += DB.SetDouble(_DOC_SPEED_ID) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_OWNER) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME) & ", "
                sql += DB.SetString(_ORGANIZATION_APPNAME) & ", "
                sql += DB.SetDouble(_OFFICER_ID_APPROVE) & ", "
                sql += DB.SetString(_OFFICER_NAME) & ", "
                sql += DB.SetDouble(_OFFICER_ORGANIZATION_ID) & ", "
                sql += DB.SetString(_ADMINISTRATION_TYPE) & ", "
                sql += DB.SetString(_REMARKS) & ", "
                sql += DB.SetDouble(_BUSINESS_TYPE_ID) & ", "
                sql += DB.SetDouble(_COMPANY_ID) & ", "
                sql += DB.SetString(_COMPANY_NAME) & ", "
                sql += DB.SetString(_COMPANY_DOC_NO) & ", "
                sql += DB.SetString(_COMPANY_DOC_TYPE_ID) & ", "
                sql += DB.SetString(_COMPANY_DOC_SYS_ID) & ", "
                sql += DB.SetString(_COMPANY_REQ_ID) & ", "
                sql += DB.SetDateTime(_COMPANY_DOC_DATE) & ", "
                sql += DB.SetString(_COMPANY_SIGN) & ", "
                sql += DB.SetDateTime(_COMPANY_SIGN_DATE) & ", "
                sql += DB.SetString(_DOC_STATUS_ID) & ", "
                sql += DB.SetString(_USERNAME_REGISTER) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_REGISTER) & ", "
                sql += DB.SetString(_CLOSE_BY) & ", "
                sql += DB.SetString(_CLOSE_BY_NAME) & ", "
                sql += DB.SetDateTime(_CLOSE_DATE) & ", "
                sql += DB.SetString(_BOOKOUT_NO) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_PROCESS) & ", "
                sql += DB.SetDouble(_ORGANIZATION_ID_STORAGE) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_STORAGE) & ", "
                sql += DB.SetString(_ID_MUST_RECEIVE_DOC) & ", "
                sql += DB.SetDouble(_ELECTRONIC_DOC_ID) & ", "
                sql += DB.SetString(_DOC_SYS_CODE) & ", "
                sql += DB.SetString(_REF_OLD_ID) & ", "
                sql += DB.SetDouble(_DOCUMENT_RECEIVE_TYPE) & ", "
                sql += DB.SetDouble(_OFFICER_ID_POSSESS) & ", "
                sql += DB.SetString(_OFFICER_NAME_POSSESS) & ", "
                sql += DB.SetDouble(_REF_DOCUMENT_REGISTER_ID) & ", "
                sql += DB.SetString(_CLOSE_REMARKS) & ", "
                sql += DB.SetString(_ORGANIZATION_NAME_PROCESS) & ", "
                sql += DB.SetString(_ORGANIZATION_ABBNAME_PROCESS) & ", "
                sql += DB.SetString(_COMPANY_CERT_NO) & ", "
                sql += DB.SetString(_COMPANY_NOTIFY_NO) & ", "
                sql += DB.SetString(_REF_TH_EGIF_DOC_INBOUND_ID) & ", "
                Sql += DB.SetDateTime(_BOOKOUT_DATE) & ", "
                Sql += DB.SetString(_COMPANY_REGIS_NO) & ", "
                Sql += DB.SetString(_COMPANY_IDCARD_NO) & ", "
                Sql += DB.SetString(_COMPANY_PASSPORT_NO) & " "
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table DOCUMENT_REGISTER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & DB.SetString(_CREATE_BY) & ", "
                Sql += "CREATE_ON = " & DB.SetDateTime(_CREATE_ON) & ", "
                Sql += "UPDATE_BY = " & DB.SetString(_UPDATE_BY) & ", "
                Sql += "UPDATE_ON = " & DB.SetDateTime(_UPDATE_ON) & ", "
                Sql += "BOOK_NO = " & DB.SetString(_BOOK_NO) & ", "
                Sql += "REQUEST_NO = " & DB.SetString(_REQUEST_NO) & ", "
                Sql += "GROUP_TITLE_ID = " & DB.SetDouble(_GROUP_TITLE_ID) & ", "
                Sql += "TITLE_NAME = " & DB.SetString(_TITLE_NAME) & ", "
                Sql += "REGISTER_DATE = " & DB.SetDateTime(_REGISTER_DATE) & ", "
                Sql += "EXPECT_FINISH_DATE = " & DB.SetDateTime(_EXPECT_FINISH_DATE) & ", "
                Sql += "DOC_SECRET_ID = " & DB.SetDouble(_DOC_SECRET_ID) & ", "
                Sql += "DOC_SPEED_ID = " & DB.SetDouble(_DOC_SPEED_ID) & ", "
                Sql += "ORGANIZATION_ID_OWNER = " & DB.SetDouble(_ORGANIZATION_ID_OWNER) & ", "
                Sql += "ORGANIZATION_NAME = " & DB.SetString(_ORGANIZATION_NAME) & ", "
                Sql += "ORGANIZATION_APPNAME = " & DB.SetString(_ORGANIZATION_APPNAME) & ", "
                Sql += "OFFICER_ID_APPROVE = " & DB.SetDouble(_OFFICER_ID_APPROVE) & ", "
                Sql += "OFFICER_NAME = " & DB.SetString(_OFFICER_NAME) & ", "
                Sql += "OFFICER_ORGANIZATION_ID = " & DB.SetDouble(_OFFICER_ORGANIZATION_ID) & ", "
                Sql += "ADMINISTRATION_TYPE = " & DB.SetString(_ADMINISTRATION_TYPE) & ", "
                Sql += "REMARKS = " & DB.SetString(_REMARKS) & ", "
                Sql += "BUSINESS_TYPE_ID = " & DB.SetDouble(_BUSINESS_TYPE_ID) & ", "
                Sql += "COMPANY_ID = " & DB.SetDouble(_COMPANY_ID) & ", "
                Sql += "COMPANY_NAME = " & DB.SetString(_COMPANY_NAME) & ", "
                Sql += "COMPANY_DOC_NO = " & DB.SetString(_COMPANY_DOC_NO) & ", "
                Sql += "COMPANY_DOC_TYPE_ID = " & DB.SetString(_COMPANY_DOC_TYPE_ID) & ", "
                Sql += "COMPANY_DOC_SYS_ID = " & DB.SetString(_COMPANY_DOC_SYS_ID) & ", "
                Sql += "COMPANY_REQ_ID = " & DB.SetString(_COMPANY_REQ_ID) & ", "
                Sql += "COMPANY_DOC_DATE = " & DB.SetDateTime(_COMPANY_DOC_DATE) & ", "
                Sql += "COMPANY_SIGN = " & DB.SetString(_COMPANY_SIGN) & ", "
                Sql += "COMPANY_SIGN_DATE = " & DB.SetDateTime(_COMPANY_SIGN_DATE) & ", "
                Sql += "DOC_STATUS_ID = " & DB.SetString(_DOC_STATUS_ID) & ", "
                Sql += "USERNAME_REGISTER = " & DB.SetString(_USERNAME_REGISTER) & ", "
                Sql += "ORGANIZATION_ID_REGISTER = " & DB.SetDouble(_ORGANIZATION_ID_REGISTER) & ", "
                Sql += "CLOSE_BY = " & DB.SetString(_CLOSE_BY) & ", "
                Sql += "CLOSE_BY_NAME = " & DB.SetString(_CLOSE_BY_NAME) & ", "
                Sql += "CLOSE_DATE = " & DB.SetDateTime(_CLOSE_DATE) & ", "
                Sql += "BOOKOUT_NO = " & DB.SetString(_BOOKOUT_NO) & ", "
                Sql += "ORGANIZATION_ID_PROCESS = " & DB.SetDouble(_ORGANIZATION_ID_PROCESS) & ", "
                Sql += "ORGANIZATION_ID_STORAGE = " & DB.SetDouble(_ORGANIZATION_ID_STORAGE) & ", "
                Sql += "ORGANIZATION_NAME_STORAGE = " & DB.SetString(_ORGANIZATION_NAME_STORAGE) & ", "
                Sql += "ID_MUST_RECEIVE_DOC = " & DB.SetString(_ID_MUST_RECEIVE_DOC) & ", "
                Sql += "ELECTRONIC_DOC_ID = " & DB.SetDouble(_ELECTRONIC_DOC_ID) & ", "
                Sql += "DOC_SYS_CODE = " & DB.SetString(_DOC_SYS_CODE) & ", "
                Sql += "REF_OLD_ID = " & DB.SetString(_REF_OLD_ID) & ", "
                Sql += "DOCUMENT_RECEIVE_TYPE = " & DB.SetDouble(_DOCUMENT_RECEIVE_TYPE) & ", "
                Sql += "OFFICER_ID_POSSESS = " & DB.SetDouble(_OFFICER_ID_POSSESS) & ", "
                Sql += "OFFICER_NAME_POSSESS = " & DB.SetString(_OFFICER_NAME_POSSESS) & ", "
                Sql += "REF_DOCUMENT_REGISTER_ID = " & DB.SetDouble(_REF_DOCUMENT_REGISTER_ID) & ", "
                Sql += "CLOSE_REMARKS = " & DB.SetString(_CLOSE_REMARKS) & ", "
                Sql += "ORGANIZATION_NAME_PROCESS = " & DB.SetString(_ORGANIZATION_NAME_PROCESS) & ", "
                Sql += "ORGANIZATION_ABBNAME_PROCESS = " & DB.SetString(_ORGANIZATION_ABBNAME_PROCESS) & ", "
                Sql += "COMPANY_CERT_NO = " & DB.SetString(_COMPANY_CERT_NO) & ", "
                Sql += "COMPANY_NOTIFY_NO = " & DB.SetString(_COMPANY_NOTIFY_NO) & ", "
                Sql += "REF_TH_EGIF_DOC_INBOUND_ID = " & DB.SetString(_REF_TH_EGIF_DOC_INBOUND_ID) & ", "
                Sql += "BOOKOUT_DATE = " & DB.SetDateTime(_BOOKOUT_DATE) + ", "
                Sql += "COMPANY_REGIS_NO = " & DB.SetString(_COMPANY_REGIS_NO) + ", "
                Sql += "COMPANY_IDCARD_NO = " & DB.SetString(_COMPANY_IDCARD_NO) + ", "
                Sql += "COMPANY_PASSPORT_NO = " & DB.SetString(_COMPANY_PASSPORT_NO) + " "
                Return Sql
            End Get
        End Property


        'Get Delete Record in table DOCUMENT_REGISTER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table DOCUMENT_REGISTER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT * FROM " & tableName
                Return Sql
            End Get
        End Property


            'Define Child Table 

       Dim _DOCUMENT_CANCEL_CLOSE_document_register_id As DataTable

       Public Property CHILD_DOCUMENT_CANCEL_CLOSE_document_register_id() As DataTable
           Get
               Return _DOCUMENT_CANCEL_CLOSE_document_register_id
           End Get
           Set(ByVal value As DataTable)
               _DOCUMENT_CANCEL_CLOSE_document_register_id = value
           End Set
       End Property
    End Class
End Namespace
