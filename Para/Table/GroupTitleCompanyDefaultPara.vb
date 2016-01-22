
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for GROUP_TITLE_COMPANY_DEFAULT table Parameter.
    '[Create by  on July, 11 2012]

    <Table(Name:="GROUP_TITLE_COMPANY_DEFAULT")>  _
    Public Class GroupTitleCompanyDefaultPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _GROUP_TITLE_ID As Long = 0
        Dim _COMPANY_ID As Long = 0
        Dim _OFFICER_SIGN_NAME As  String  = ""
        Dim _REMARKS As  String  = ""
        Dim _ACTIVE As Char = "Y"
        Dim _OFFICER_SIGN_ID As  System.Nullable(Of Long)  = 0

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
        <Column(Storage:="_GROUP_TITLE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_ID() As Long
            Get
                Return _GROUP_TITLE_ID
            End Get
            Set(ByVal value As Long)
               _GROUP_TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_ID() As Long
            Get
                Return _COMPANY_ID
            End Get
            Set(ByVal value As Long)
               _COMPANY_ID = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_SIGN_NAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_SIGN_NAME() As  String 
            Get
                Return _OFFICER_SIGN_NAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_SIGN_NAME = value
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
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_SIGN_ID", DbType:="BigInt")>  _
        Public Property OFFICER_SIGN_ID() As  System.Nullable(Of Long) 
            Get
                Return _OFFICER_SIGN_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _OFFICER_SIGN_ID = value
            End Set
        End Property 


    End Class
End Namespace
