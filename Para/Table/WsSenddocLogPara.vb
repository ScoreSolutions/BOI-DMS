
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for WS_SENDDOC_LOG table Parameter.
    '[Create by  on May, 11 2012]

    <Table(Name:="WS_SENDDOC_LOG")>  _
    Public Class WsSenddocLogPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SYSTEMID As String = ""
        Dim _RECORDCOUNT As Long = 0
        Dim _START_TIME As DateTime = New DateTime(1,1,1)
        Dim _END_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ERR_MESSAGE As  String  = ""

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
        <Column(Storage:="_SYSTEMID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYSTEMID() As String
            Get
                Return _SYSTEMID
            End Get
            Set(ByVal value As String)
               _SYSTEMID = value
            End Set
        End Property 
        <Column(Storage:="_RECORDCOUNT", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property RECORDCOUNT() As Long
            Get
                Return _RECORDCOUNT
            End Get
            Set(ByVal value As Long)
               _RECORDCOUNT = value
            End Set
        End Property 
        <Column(Storage:="_START_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property START_TIME() As DateTime
            Get
                Return _START_TIME
            End Get
            Set(ByVal value As DateTime)
               _START_TIME = value
            End Set
        End Property 
        <Column(Storage:="_END_TIME", DbType:="DateTime")>  _
        Public Property END_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _END_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _END_TIME = value
            End Set
        End Property 
        <Column(Storage:="_ERR_MESSAGE", DbType:="VarChar(500)")>  _
        Public Property ERR_MESSAGE() As  String 
            Get
                Return _ERR_MESSAGE
            End Get
            Set(ByVal value As  String )
               _ERR_MESSAGE = value
            End Set
        End Property 


            'Define Child Table 

       Dim _WS_IMPORT_DOC_LASTSTATUS_ws_senddoc_log_id As DataTable

       Public Property CHILD_WS_IMPORT_DOC_LASTSTATUS_ws_senddoc_log_id() As DataTable
           Get
               Return _WS_IMPORT_DOC_LASTSTATUS_ws_senddoc_log_id
           End Get
           Set(ByVal value As DataTable)
               _WS_IMPORT_DOC_LASTSTATUS_ws_senddoc_log_id = value
           End Set
       End Property
    End Class
End Namespace
