
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for BOOK_RUNNING table Parameter.
    '[Create by  on September, 18 2012]

    <Table(Name:="BOOK_RUNNING")>  _
    Public Class BookRunningPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _BOOK_TYPE As Char = ""
        Dim _RUN_YEAR As  String  = ""
        Dim _LENGTH As Long = 0
        Dim _ORG_ABB As  String  = ""

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
        <Column(Storage:="_BOOK_TYPE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property BOOK_TYPE() As Char
            Get
                Return _BOOK_TYPE
            End Get
            Set(ByVal value As Char)
               _BOOK_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_RUN_YEAR", DbType:="VarChar(2)")>  _
        Public Property RUN_YEAR() As  String 
            Get
                Return _RUN_YEAR
            End Get
            Set(ByVal value As  String )
               _RUN_YEAR = value
            End Set
        End Property 
        <Column(Storage:="_LENGTH", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property LENGTH() As Long
            Get
                Return _LENGTH
            End Get
            Set(ByVal value As Long)
               _LENGTH = value
            End Set
        End Property 
        <Column(Storage:="_ORG_ABB", DbType:="VarChar(20)")>  _
        Public Property ORG_ABB() As  String 
            Get
                Return _ORG_ABB
            End Get
            Set(ByVal value As  String )
               _ORG_ABB = value
            End Set
        End Property 


    End Class
End Namespace
