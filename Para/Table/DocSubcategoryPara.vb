
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOC_SUBCATEGORY table Parameter.
    '[Create by  on August, 8 2012]

    <Table(Name:="DOC_SUBCATEGORY")>  _
    Public Class DocSubcategoryPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CATEGORY_ID As Long = 0
        Dim _SUBCATEGORY_CODE As String = ""
        Dim _SUBCATEGORY_NAME As String = ""
        Dim _ACTIVE As Char = "Y"

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
        <Column(Storage:="_DOC_CATEGORY_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_CATEGORY_ID() As Long
            Get
                Return _DOC_CATEGORY_ID
            End Get
            Set(ByVal value As Long)
               _DOC_CATEGORY_ID = value
            End Set
        End Property 
        <Column(Storage:="_SUBCATEGORY_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SUBCATEGORY_CODE() As String
            Get
                Return _SUBCATEGORY_CODE
            End Get
            Set(ByVal value As String)
               _SUBCATEGORY_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SUBCATEGORY_NAME", DbType:="VarChar(250) NOT NULL ",CanBeNull:=false)>  _
        Public Property SUBCATEGORY_NAME() As String
            Get
                Return _SUBCATEGORY_NAME
            End Get
            Set(ByVal value As String)
               _SUBCATEGORY_NAME = value
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


    End Class
End Namespace
