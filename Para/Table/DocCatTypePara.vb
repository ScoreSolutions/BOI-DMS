
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOC_CAT_TYPE table Parameter.
    '[Create by  on July, 29 2012]

    <Table(Name:="DOC_CAT_TYPE")>  _
    Public Class DocCatTypePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CAT_TYPE_ID As Long = 0
        Dim _DOC_CAT_TYPE_NAME As String = ""
        Dim _IS_DISPLAY As  System.Nullable(Of Char)  = ""
        Dim _IS_DEFALT As  System.Nullable(Of Char)  = ""

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
        <Column(Storage:="_DOC_CAT_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_CAT_TYPE_ID() As Long
            Get
                Return _DOC_CAT_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _DOC_CAT_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CAT_TYPE_NAME", DbType:="VarChar(200) NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_CAT_TYPE_NAME() As String
            Get
                Return _DOC_CAT_TYPE_NAME
            End Get
            Set(ByVal value As String)
               _DOC_CAT_TYPE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_IS_DISPLAY", DbType:="Char(1)")>  _
        Public Property IS_DISPLAY() As  System.Nullable(Of Char) 
            Get
                Return _IS_DISPLAY
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_DISPLAY = value
            End Set
        End Property 
        <Column(Storage:="_IS_DEFALT", DbType:="Char(1)")>  _
        Public Property IS_DEFALT() As  System.Nullable(Of Char) 
            Get
                Return _IS_DEFALT
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_DEFALT = value
            End Set
        End Property 


    End Class
End Namespace
