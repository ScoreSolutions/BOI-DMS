
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for GROUP_TITLE_KPI_DUE_DATE table Parameter.
    '[Create by  on Febuary, 5 2013]

    <Table(Name:="GROUP_TITLE_KPI_DUE_DATE")>  _
    Public Class GroupTitleKpiDueDatePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _GROUP_TITLE_ID As Long = 0
        Dim _ORGANIZATION_ABB_NAME As String = ""
        Dim _PROC_DATE As Long = 0

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
        <Column(Storage:="_ORGANIZATION_ABB_NAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ABB_NAME() As String
            Get
                Return _ORGANIZATION_ABB_NAME
            End Get
            Set(ByVal value As String)
               _ORGANIZATION_ABB_NAME = value
            End Set
        End Property 
        <Column(Storage:="_PROC_DATE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PROC_DATE() As Long
            Get
                Return _PROC_DATE
            End Get
            Set(ByVal value As Long)
               _PROC_DATE = value
            End Set
        End Property 


    End Class
End Namespace