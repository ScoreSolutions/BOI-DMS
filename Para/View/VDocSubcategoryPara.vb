
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace VIEW
    'Represents a transaction for v_doc_subcategory view Parameter.
    '[Create by  on July, 26 2011]

    <Table(Name:="v_doc_subcategory")>  _
    Public Class VDocSubcategoryPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _DOC_CATEGORY_ID As Long = 0
        Dim _CATEGORY_NAME As String = ""
        Dim _SUBCATEGORY_CODE As String = ""
        Dim _SUBCATEGORY_NAME As String = ""
        Dim _ACTIVE As Char = ""
        Dim _ACTIVE_NAME As  String  = ""

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
        <Column(Storage:="_DOC_CATEGORY_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_CATEGORY_ID() As Long
            Get
                Return _DOC_CATEGORY_ID
            End Get
            Set(ByVal value As Long)
               _DOC_CATEGORY_ID = value
            End Set
        End Property 
        <Column(Storage:="_CATEGORY_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property CATEGORY_NAME() As String
            Get
                Return _CATEGORY_NAME
            End Get
            Set(ByVal value As String)
               _CATEGORY_NAME = value
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
        <Column(Storage:="_ACTIVE_NAME", DbType:="VarChar(9)")>  _
        Public Property ACTIVE_NAME() As  String 
            Get
                Return _ACTIVE_NAME
            End Get
            Set(ByVal value As  String )
               _ACTIVE_NAME = value
            End Set
        End Property 


    End Class
End Namespace
