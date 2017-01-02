
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_REGISTER table Parameter.
    '[Create by  on September, 9 2012]

    <Table(Name:="DOCUMENT_REGISTER")>  _
    Public Class DocumentRegisterPara

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
