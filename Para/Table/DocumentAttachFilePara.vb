
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_ATTACH_FILE table Parameter.
    '[Create by  on July, 17 2012]

    <Table(Name:="DOCUMENT_ATTACH_FILE")>  _
    Public Class DocumentAttachFilePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_REGISTER_ID As Long = 0
        Dim _FILE_NAME As String = ""
        Dim _FILE_PATH As String = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _MIME_TYPE As String = ""

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
        <Column(Storage:="_DOCUMENT_REGISTER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOCUMENT_REGISTER_ID() As Long
            Get
                Return _DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As Long)
               _DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_FILE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILE_NAME() As String
            Get
                Return _FILE_NAME
            End Get
            Set(ByVal value As String)
               _FILE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FILE_PATH", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILE_PATH() As String
            Get
                Return _FILE_PATH
            End Get
            Set(ByVal value As String)
               _FILE_PATH = value
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
        <Column(Storage:="_MIME_TYPE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MIME_TYPE() As String
            Get
                Return _MIME_TYPE
            End Get
            Set(ByVal value As String)
               _MIME_TYPE = value
            End Set
        End Property 


    End Class
End Namespace
