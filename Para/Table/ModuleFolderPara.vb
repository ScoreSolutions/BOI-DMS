
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for MODULE_FOLDER table Parameter.
    '[Create by  on September, 6 2011]

    <Table(Name:="MODULE_FOLDER")>  _
    Public Class ModuleFolderPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MODULE_ID As Long = 0
        Dim _FOLDER_NAME As String = ""
        Dim _FOLDER_TOOLSTIP As  String  = ""
        Dim _FOLDER_DESC As  String  = ""
        Dim _FOLDER_ICON As  String  = ""
        Dim _FOLDER_URL As String = ""
        Dim _FOLDER_REF_ID As Long = 0
        Dim _ORDER_SEQ As Long = 0
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
        <Column(Storage:="_MODULE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_ID() As Long
            Get
                Return _MODULE_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_ID = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_NAME() As String
            Get
                Return _FOLDER_NAME
            End Get
            Set(ByVal value As String)
               _FOLDER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_TOOLSTIP", DbType:="VarChar(255)")>  _
        Public Property FOLDER_TOOLSTIP() As  String 
            Get
                Return _FOLDER_TOOLSTIP
            End Get
            Set(ByVal value As  String )
               _FOLDER_TOOLSTIP = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_DESC", DbType:="VarChar(500)")>  _
        Public Property FOLDER_DESC() As  String 
            Get
                Return _FOLDER_DESC
            End Get
            Set(ByVal value As  String )
               _FOLDER_DESC = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_ICON", DbType:="VarChar(255)")>  _
        Public Property FOLDER_ICON() As  String 
            Get
                Return _FOLDER_ICON
            End Get
            Set(ByVal value As  String )
               _FOLDER_ICON = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_URL", DbType:="VarChar(1000) NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_URL() As String
            Get
                Return _FOLDER_URL
            End Get
            Set(ByVal value As String)
               _FOLDER_URL = value
            End Set
        End Property 
        <Column(Storage:="_FOLDER_REF_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property FOLDER_REF_ID() As Long
            Get
                Return _FOLDER_REF_ID
            End Get
            Set(ByVal value As Long)
               _FOLDER_REF_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORDER_SEQ", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORDER_SEQ() As Long
            Get
                Return _ORDER_SEQ
            End Get
            Set(ByVal value As Long)
               _ORDER_SEQ = value
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
