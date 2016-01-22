
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_CANCEL_CLOSE table Parameter.
    '[Create by  on July, 21 2012]

    <Table(Name:="DOCUMENT_CANCEL_CLOSE")>  _
    Public Class DocumentCancelClosePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_REGISTER_ID As Long = 0
        Dim _CANCEL_DATE As DateTime = New DateTime(1,1,1)
        Dim _CANCEL_REASON As String = ""
        Dim _ORGANIZATION_ID_CANCEL As Long = 0
        Dim _ORGANIZATION_NAME_CANCEL As String = ""
        Dim _ORGANIZATION_APPNAME_CANCEL As String = ""
        Dim _OFFICER_USERNAME_CANCEL As String = ""
        Dim _OFFICER_FULLNAME_CANCEL As String = ""
        Dim _CLOSE_BY As String = ""
        Dim _CLOSE_BY_NAME As String = ""
        Dim _CLOSE_DATE As DateTime = New DateTime(1,1,1)
        Dim _CLOSE_REMARKS As  String  = ""

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
        <Column(Storage:="_CANCEL_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CANCEL_DATE() As DateTime
            Get
                Return _CANCEL_DATE
            End Get
            Set(ByVal value As DateTime)
               _CANCEL_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CANCEL_REASON", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property CANCEL_REASON() As String
            Get
                Return _CANCEL_REASON
            End Get
            Set(ByVal value As String)
               _CANCEL_REASON = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_CANCEL", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID_CANCEL() As Long
            Get
                Return _ORGANIZATION_ID_CANCEL
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_ID_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_NAME_CANCEL() As String
            Get
                Return _ORGANIZATION_NAME_CANCEL
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_NAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_APPNAME_CANCEL() As String
            Get
                Return _ORGANIZATION_APPNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_APPNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_USERNAME_CANCEL", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_USERNAME_CANCEL() As String
            Get
                Return _OFFICER_USERNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _OFFICER_USERNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_FULLNAME_CANCEL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_FULLNAME_CANCEL() As String
            Get
                Return _OFFICER_FULLNAME_CANCEL
            End Get
            Set(ByVal value As String)
               _OFFICER_FULLNAME_CANCEL = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_BY() As String
            Get
                Return _CLOSE_BY
            End Get
            Set(ByVal value As String)
               _CLOSE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_BY_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_BY_NAME() As String
            Get
                Return _CLOSE_BY_NAME
            End Get
            Set(ByVal value As String)
               _CLOSE_BY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CLOSE_DATE() As DateTime
            Get
                Return _CLOSE_DATE
            End Get
            Set(ByVal value As DateTime)
               _CLOSE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CLOSE_REMARKS", DbType:="VarChar(255)")>  _
        Public Property CLOSE_REMARKS() As  String 
            Get
                Return _CLOSE_REMARKS
            End Get
            Set(ByVal value As  String )
               _CLOSE_REMARKS = value
            End Set
        End Property 


    End Class
End Namespace
