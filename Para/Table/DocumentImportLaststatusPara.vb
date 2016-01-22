
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_IMPORT_LASTSTATUS table Parameter.
    '[Create by  on December, 31 2012]

    <Table(Name:="DOCUMENT_IMPORT_LASTSTATUS")>  _
    Public Class DocumentImportLaststatusPara

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


    End Class
End Namespace
