
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for ORGANIZATION table Parameter.
    '[Create by  on September, 6 2012]

    <Table(Name:="ORGANIZATION")>  _
    Public Class OrganizationPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = "(getdate())"
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORG_CODE As String = ""
        Dim _ORG_NAME As String = ""
        Dim _ORG_THAI_NAME As String = ""
        Dim _ORG_ENG_NAME As  String  = ""
        Dim _NAME_RECEIVE As  String  = ""
        Dim _NAME_ABB As  String  = ""
        Dim _SEC_ID As  System.Nullable(Of Long)  = 0
        Dim _EXPR1 As  String  = ""
        Dim _COM_CODE As  String  = ""
        Dim _ORGANIZATION_TYPE_ID As Long = 0
        Dim _PARENT_ID As  System.Nullable(Of Long)  = 0
        Dim _ADDRESS_THAI As  String  = ""
        Dim _ADDRESS_ENG As  String  = ""
        Dim _DISTRICT_ID As  System.Nullable(Of Long)  = 0
        Dim _AMPHUR_ID As  System.Nullable(Of Long)  = 0
        Dim _PROVINCE_ID As  System.Nullable(Of Long)  = 0
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _EMAIL As  String  = ""
        Dim _TYPE As  System.Nullable(Of Char)  = ""
        Dim _EFDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EPDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DESCRIPTION As  String  = ""
        Dim _ACTIVE As Char = "Y"
        Dim _DIRECTOR As  String  = ""

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
        <Column(Storage:="_ORG_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_CODE() As String
            Get
                Return _ORG_CODE
            End Get
            Set(ByVal value As String)
               _ORG_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ORG_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_NAME() As String
            Get
                Return _ORG_NAME
            End Get
            Set(ByVal value As String)
               _ORG_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORG_THAI_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORG_THAI_NAME() As String
            Get
                Return _ORG_THAI_NAME
            End Get
            Set(ByVal value As String)
               _ORG_THAI_NAME = value
            End Set
        End Property 
        <Column(Storage:="_ORG_ENG_NAME", DbType:="VarChar(255)")>  _
        Public Property ORG_ENG_NAME() As  String 
            Get
                Return _ORG_ENG_NAME
            End Get
            Set(ByVal value As  String )
               _ORG_ENG_NAME = value
            End Set
        End Property 
        <Column(Storage:="_NAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property NAME_RECEIVE() As  String 
            Get
                Return _NAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _NAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_NAME_ABB", DbType:="VarChar(255)")>  _
        Public Property NAME_ABB() As  String 
            Get
                Return _NAME_ABB
            End Get
            Set(ByVal value As  String )
               _NAME_ABB = value
            End Set
        End Property 
        <Column(Storage:="_SEC_ID", DbType:="BigInt")>  _
        Public Property SEC_ID() As  System.Nullable(Of Long) 
            Get
                Return _SEC_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SEC_ID = value
            End Set
        End Property 
        <Column(Storage:="_EXPR1", DbType:="VarChar(255)")>  _
        Public Property EXPR1() As  String 
            Get
                Return _EXPR1
            End Get
            Set(ByVal value As  String )
               _EXPR1 = value
            End Set
        End Property 
        <Column(Storage:="_COM_CODE", DbType:="VarChar(50)")>  _
        Public Property COM_CODE() As  String 
            Get
                Return _COM_CODE
            End Get
            Set(ByVal value As  String )
               _COM_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_TYPE_ID() As Long
            Get
                Return _ORGANIZATION_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_PARENT_ID", DbType:="BigInt")>  _
        Public Property PARENT_ID() As  System.Nullable(Of Long) 
            Get
                Return _PARENT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PARENT_ID = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESS_THAI", DbType:="VarChar(255)")>  _
        Public Property ADDRESS_THAI() As  String 
            Get
                Return _ADDRESS_THAI
            End Get
            Set(ByVal value As  String )
               _ADDRESS_THAI = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESS_ENG", DbType:="VarChar(255)")>  _
        Public Property ADDRESS_ENG() As  String 
            Get
                Return _ADDRESS_ENG
            End Get
            Set(ByVal value As  String )
               _ADDRESS_ENG = value
            End Set
        End Property 
        <Column(Storage:="_DISTRICT_ID", DbType:="BigInt")>  _
        Public Property DISTRICT_ID() As  System.Nullable(Of Long) 
            Get
                Return _DISTRICT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DISTRICT_ID = value
            End Set
        End Property 
        <Column(Storage:="_AMPHUR_ID", DbType:="BigInt")>  _
        Public Property AMPHUR_ID() As  System.Nullable(Of Long) 
            Get
                Return _AMPHUR_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _AMPHUR_ID = value
            End Set
        End Property 
        <Column(Storage:="_PROVINCE_ID", DbType:="BigInt")>  _
        Public Property PROVINCE_ID() As  System.Nullable(Of Long) 
            Get
                Return _PROVINCE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _PROVINCE_ID = value
            End Set
        End Property 
        <Column(Storage:="_TEL", DbType:="VarChar(255)")>  _
        Public Property TEL() As  String 
            Get
                Return _TEL
            End Get
            Set(ByVal value As  String )
               _TEL = value
            End Set
        End Property 
        <Column(Storage:="_FAX", DbType:="VarChar(255)")>  _
        Public Property FAX() As  String 
            Get
                Return _FAX
            End Get
            Set(ByVal value As  String )
               _FAX = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255)")>  _
        Public Property EMAIL() As  String 
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As  String )
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_TYPE", DbType:="Char(1)")>  _
        Public Property TYPE() As  System.Nullable(Of Char) 
            Get
                Return _TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _TYPE = value
            End Set
        End Property 
        <Column(Storage:="_EFDATE", DbType:="DateTime2")>  _
        Public Property EFDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EFDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EFDATE = value
            End Set
        End Property 
        <Column(Storage:="_EPDATE", DbType:="DateTime2")>  _
        Public Property EPDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EPDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EPDATE = value
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
        <Column(Storage:="_ACTIVE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE() As Char
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As Char)
               _ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_DIRECTOR", DbType:="VarChar(50)")>  _
        Public Property DIRECTOR() As  String 
            Get
                Return _DIRECTOR
            End Get
            Set(ByVal value As  String )
               _DIRECTOR = value
            End Set
        End Property 


            'Define Child Table 

       Dim _GROUP_TITLE_ORG_RESPONSE_organization_id As DataTable
       Dim _ORGANIZATION_STORAGE_organization_id As DataTable

       Public Property CHILD_GROUP_TITLE_ORG_RESPONSE_organization_id() As DataTable
           Get
               Return _GROUP_TITLE_ORG_RESPONSE_organization_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_ORG_RESPONSE_organization_id = value
           End Set
       End Property
       Public Property CHILD_ORGANIZATION_STORAGE_organization_id() As DataTable
           Get
               Return _ORGANIZATION_STORAGE_organization_id
           End Get
           Set(ByVal value As DataTable)
               _ORGANIZATION_STORAGE_organization_id = value
           End Set
       End Property
    End Class
End Namespace
