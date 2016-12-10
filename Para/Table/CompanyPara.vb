
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for COMPANY table Parameter.
    '[Create by  on September, 13 2012]

    <Table(Name:="COMPANY")>  _
    Public Class CompanyPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _COMPANY_TYPE_ID As  System.Nullable(Of Long)  = 0
        Dim _THAINAME As  String  = ""
        Dim _ENGNAME As  String  = ""
        Dim _ADDRESSID As  String  = ""
        Dim _COMID As  String  = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _ACTIVE As  System.Nullable(Of Char)  = "Y"
        Dim _REF_OLD_ID As  String  = ""
        Dim _REF_ORG_ID As  System.Nullable(Of Long)  = 0
        Dim _TH_EGIF_ORG_CODE As  String  = ""
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _ZIPCODE As  String  = ""
        Dim _PROVINCE_ID As  System.Nullable(Of Long)  = 0
        Dim _DISTRICT_ID As System.Nullable(Of Long) = 0
        Dim _DIRECTOR_POSITION As String = ""
        Dim _COMPANY_REGIS_NO As String = ""

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
        <Column(Storage:="_COMPANY_TYPE_ID", DbType:="BigInt")>  _
        Public Property COMPANY_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _COMPANY_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _COMPANY_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_THAINAME", DbType:="VarChar(200)")>  _
        Public Property THAINAME() As  String 
            Get
                Return _THAINAME
            End Get
            Set(ByVal value As  String )
               _THAINAME = value
            End Set
        End Property 
        <Column(Storage:="_ENGNAME", DbType:="VarChar(200)")>  _
        Public Property ENGNAME() As  String 
            Get
                Return _ENGNAME
            End Get
            Set(ByVal value As  String )
               _ENGNAME = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESSID", DbType:="VarChar(50)")>  _
        Public Property ADDRESSID() As  String 
            Get
                Return _ADDRESSID
            End Get
            Set(ByVal value As  String )
               _ADDRESSID = value
            End Set
        End Property 
        <Column(Storage:="_COMID", DbType:="VarChar(50)")>  _
        Public Property COMID() As  String 
            Get
                Return _COMID
            End Get
            Set(ByVal value As  String )
               _COMID = value
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
        <Column(Storage:="_ACTIVE", DbType:="Char(1)")>  _
        Public Property ACTIVE() As  System.Nullable(Of Char) 
            Get
                Return _ACTIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ACTIVE = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_ID() As  String 
            Get
                Return _REF_OLD_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_ID = value
            End Set
        End Property 
        <Column(Storage:="_REF_ORG_ID", DbType:="BigInt")>  _
        Public Property REF_ORG_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_ORG_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_ORG_ID = value
            End Set
        End Property 
        <Column(Storage:="_TH_EGIF_ORG_CODE", DbType:="VarChar(50)")>  _
        Public Property TH_EGIF_ORG_CODE() As  String 
            Get
                Return _TH_EGIF_ORG_CODE
            End Get
            Set(ByVal value As  String )
               _TH_EGIF_ORG_CODE = value
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
        <Column(Storage:="_ZIPCODE", DbType:="VarChar(255)")>  _
        Public Property ZIPCODE() As  String 
            Get
                Return _ZIPCODE
            End Get
            Set(ByVal value As  String )
               _ZIPCODE = value
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
        <Column(Storage:="_DISTRICT_ID", DbType:="BigInt")>  _
        Public Property DISTRICT_ID() As  System.Nullable(Of Long) 
            Get
                Return _DISTRICT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DISTRICT_ID = value
            End Set
        End Property
        <Column(Storage:="_DIRECTOR_POSITION", DbType:="VarChar(255)")> _
        Public Property DIRECTOR_POSITION() As String
            Get
                Return _DIRECTOR_POSITION
            End Get
            Set(ByVal value As String)
                _DIRECTOR_POSITION = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_REGIS_NO", DbType:="VarChar(50)")> _
        Public Property COMPANY_REGIS_NO() As String
            Get
                Return _COMPANY_REGIS_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_REGIS_NO = value
            End Set
        End Property


            'Define Child Table 

       Dim _GROUP_TITLE_COMPANY_DEFAULT_company_id As DataTable

       Public Property CHILD_GROUP_TITLE_COMPANY_DEFAULT_company_id() As DataTable
           Get
               Return _GROUP_TITLE_COMPANY_DEFAULT_company_id
           End Get
           Set(ByVal value As DataTable)
               _GROUP_TITLE_COMPANY_DEFAULT_company_id = value
           End Set
       End Property
    End Class
End Namespace
