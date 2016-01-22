
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for LOGIN_HISTORY table Parameter.
    '[Create by  on September, 6 2011]

    <Table(Name:="LOGIN_HISTORY")>  _
    Public Class LoginHistoryPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USERNAME As String = ""
        Dim _IDCARD_NO As String = ""
        Dim _STAFF_NAME As String = ""
        Dim _STAFF_POSNAME As  String  = ""
        Dim _STAFF_DIVISION_NAME As  String  = ""
        Dim _STAFF_DEPARTMENT_NAME As  String  = ""
        Dim _LOGIN_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOGOUT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IS_SSO As Char = ""
        Dim _IP_ADDRESS As String = ""
        Dim _SESSION_ID As String = ""
        Dim _BROWSER As String = ""

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
        <Column(Storage:="_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_IDCARD_NO", DbType:="VarChar(13) NOT NULL ",CanBeNull:=false)>  _
        Public Property IDCARD_NO() As String
            Get
                Return _IDCARD_NO
            End Get
            Set(ByVal value As String)
               _IDCARD_NO = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property STAFF_NAME() As String
            Get
                Return _STAFF_NAME
            End Get
            Set(ByVal value As String)
               _STAFF_NAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_POSNAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_POSNAME() As  String 
            Get
                Return _STAFF_POSNAME
            End Get
            Set(ByVal value As  String )
               _STAFF_POSNAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_DIVISION_NAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_DIVISION_NAME() As  String 
            Get
                Return _STAFF_DIVISION_NAME
            End Get
            Set(ByVal value As  String )
               _STAFF_DIVISION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_DEPARTMENT_NAME", DbType:="VarChar(255)")>  _
        Public Property STAFF_DEPARTMENT_NAME() As  String 
            Get
                Return _STAFF_DEPARTMENT_NAME
            End Get
            Set(ByVal value As  String )
               _STAFF_DEPARTMENT_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_TIME", DbType:="DateTime2 NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_TIME() As DateTime
            Get
                Return _LOGIN_TIME
            End Get
            Set(ByVal value As DateTime)
               _LOGIN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_LOGOUT_TIME", DbType:="DateTime2")>  _
        Public Property LOGOUT_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LOGOUT_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LOGOUT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_IS_SSO", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_SSO() As Char
            Get
                Return _IS_SSO
            End Get
            Set(ByVal value As Char)
               _IS_SSO = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_SESSION_ID", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SESSION_ID() As String
            Get
                Return _SESSION_ID
            End Get
            Set(ByVal value As String)
               _SESSION_ID = value
            End Set
        End Property 
        <Column(Storage:="_BROWSER", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BROWSER() As String
            Get
                Return _BROWSER
            End Get
            Set(ByVal value As String)
               _BROWSER = value
            End Set
        End Property 


            'Define Child Table 

       Dim _LOG_ERROR_login_his_id As DataTable
       Dim _LOG_TRANS_login_his_id As DataTable

       Public Property CHILD_LOG_ERROR_login_his_id() As DataTable
           Get
               Return _LOG_ERROR_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_ERROR_login_his_id = value
           End Set
       End Property
       Public Property CHILD_LOG_TRANS_login_his_id() As DataTable
           Get
               Return _LOG_TRANS_login_his_id
           End Get
           Set(ByVal value As DataTable)
               _LOG_TRANS_login_his_id = value
           End Set
       End Property
    End Class
End Namespace
