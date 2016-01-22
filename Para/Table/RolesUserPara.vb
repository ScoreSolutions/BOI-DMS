
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for ROLES_USER table Parameter.
    '[Create by  on September, 6 2011]

    <Table(Name:="ROLES_USER")>  _
    Public Class RolesUserPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ROLES_ID As Long = 0
        Dim _LOGIN_USERNAME As String = ""
        Dim _USER_FULL_NAME As  String  = ""
        Dim _ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME As  String  = ""

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
        <Column(Storage:="_ROLES_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ROLES_ID() As Long
            Get
                Return _ROLES_ID
            End Get
            Set(ByVal value As Long)
               _ROLES_ID = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_USERNAME() As String
            Get
                Return _LOGIN_USERNAME
            End Get
            Set(ByVal value As String)
               _LOGIN_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_USER_FULL_NAME", DbType:="VarChar(255)")>  _
        Public Property USER_FULL_NAME() As  String 
            Get
                Return _USER_FULL_NAME
            End Get
            Set(ByVal value As  String )
               _USER_FULL_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID = value
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


    End Class
End Namespace
