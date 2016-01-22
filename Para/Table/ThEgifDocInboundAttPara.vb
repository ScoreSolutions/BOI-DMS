
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TH_EGIF_DOC_INBOUND_ATT table Parameter.
    '[Create by  on September, 6 2012]

    <Table(Name:="TH_EGIF_DOC_INBOUND_ATT")>  _
    Public Class ThEgifDocInboundAttPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _TH_EGIF_DOC_INBOUND_ID As Long = 0
        Dim _MIME_CODE As String = ""
        Dim _BASE64DATA As String = ""

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
        <Column(Storage:="_TH_EGIF_DOC_INBOUND_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TH_EGIF_DOC_INBOUND_ID() As Long
            Get
                Return _TH_EGIF_DOC_INBOUND_ID
            End Get
            Set(ByVal value As Long)
               _TH_EGIF_DOC_INBOUND_ID = value
            End Set
        End Property 
        <Column(Storage:="_MIME_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MIME_CODE() As String
            Get
                Return _MIME_CODE
            End Get
            Set(ByVal value As String)
               _MIME_CODE = value
            End Set
        End Property 
        <Column(Storage:="_BASE64DATA", DbType:="Text NOT NULL ",CanBeNull:=false)>  _
        Public Property BASE64DATA() As String
            Get
                Return _BASE64DATA
            End Get
            Set(ByVal value As String)
               _BASE64DATA = value
            End Set
        End Property 


    End Class
End Namespace
