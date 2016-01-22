
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for ROLES table Parameter.
    '[Create by  on September, 6 2011]

    <Table(Name:="ROLES")>  _
    Public Class RolesPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ROLE_CODE As String = ""
        Dim _ROLE_NAME As String = ""
        Dim _ACTIVE As Char = ""

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
        <Column(Storage:="_ROLE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ROLE_CODE() As String
            Get
                Return _ROLE_CODE
            End Get
            Set(ByVal value As String)
               _ROLE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ROLE_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property ROLE_NAME() As String
            Get
                Return _ROLE_NAME
            End Get
            Set(ByVal value As String)
               _ROLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 


            'Define Child Table 

       Dim _ROLES_MENU_roles_id As DataTable
       Dim _ROLES_USER_roles_id As DataTable

       Public Property CHILD_ROLES_MENU_roles_id() As DataTable
           Get
               Return _ROLES_MENU_roles_id
           End Get
           Set(ByVal value As DataTable)
               _ROLES_MENU_roles_id = value
           End Set
       End Property
       Public Property CHILD_ROLES_USER_roles_id() As DataTable
           Get
               Return _ROLES_USER_roles_id
           End Get
           Set(ByVal value As DataTable)
               _ROLES_USER_roles_id = value
           End Set
       End Property
    End Class
End Namespace
