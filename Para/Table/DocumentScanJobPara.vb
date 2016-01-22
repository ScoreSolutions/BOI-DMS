
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_SCAN_JOB table Parameter.
    '[Create by  on July, 17 2012]

    <Table(Name:="DOCUMENT_SCAN_JOB")>  _
    Public Class DocumentScanJobPara

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
