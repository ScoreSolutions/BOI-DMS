
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for ORGANIZATION_STORAGE table Parameter.
    '[Create by  on August, 5 2012]

    <Table(Name:="ORGANIZATION_STORAGE")>  _
    Public Class OrganizationStoragePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORGANIZATION_ID As Long = 0
        Dim _START_DATE As DateTime = New DateTime(1,1,1)
        Dim _END_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _STORAGE_ABB_NAME As  String  = ""

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
        <Column(Storage:="_CREATE_ON", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
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
        <Column(Storage:="_UPDATE_ON", DbType:="DateTime")>  _
        Public Property UPDATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_ON = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID() As Long
            Get
                Return _ORGANIZATION_ID
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_START_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property START_DATE() As DateTime
            Get
                Return _START_DATE
            End Get
            Set(ByVal value As DateTime)
               _START_DATE = value
            End Set
        End Property 
        <Column(Storage:="_END_DATE", DbType:="DateTime")>  _
        Public Property END_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _END_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _END_DATE = value
            End Set
        End Property 
        <Column(Storage:="_STORAGE_ABB_NAME", DbType:="VarChar(255)")>  _
        Public Property STORAGE_ABB_NAME() As  String 
            Get
                Return _STORAGE_ABB_NAME
            End Get
            Set(ByVal value As  String )
               _STORAGE_ABB_NAME = value
            End Set
        End Property 


    End Class
End Namespace
