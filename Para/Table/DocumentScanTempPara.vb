
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_SCAN_TEMP table Parameter.
    '[Create by  on July, 23 2012]

    <Table(Name:="DOCUMENT_SCAN_TEMP")>  _
    Public Class DocumentScanTempPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_SCAN_JOB_ID As Long = 0
        Dim _FILE_BYTE() As Byte
        Dim _FILE_EXTENTION As String = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _REF_TABLE As  String  = ""
        Dim _REF_ID As  System.Nullable(Of Long)  = 0
        Dim _ATTACH_STATUS As  System.Nullable(Of Char)  = ""
        Dim _ATTACH_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_ATTACH_FILE_ID As  System.Nullable(Of Long)  = 0

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
        <Column(Storage:="_DOCUMENT_SCAN_JOB_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOCUMENT_SCAN_JOB_ID() As Long
            Get
                Return _DOCUMENT_SCAN_JOB_ID
            End Get
            Set(ByVal value As Long)
               _DOCUMENT_SCAN_JOB_ID = value
            End Set
        End Property 
        <Column(Storage:="_FILE_BYTE", DbType:="IMAGE")>  _
        Public Property FILE_BYTE() As  Byte() 
            Get
                Return _FILE_BYTE
            End Get
            Set(ByVal value() As Byte)
               _FILE_BYTE = value
            End Set
        End Property 
        <Column(Storage:="_FILE_EXTENTION", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property FILE_EXTENTION() As String
            Get
                Return _FILE_EXTENTION
            End Get
            Set(ByVal value As String)
               _FILE_EXTENTION = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(255)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_REF_TABLE", DbType:="VarChar(255)")>  _
        Public Property REF_TABLE() As  String 
            Get
                Return _REF_TABLE
            End Get
            Set(ByVal value As  String )
               _REF_TABLE = value
            End Set
        End Property 
        <Column(Storage:="_REF_ID", DbType:="BigInt")>  _
        Public Property REF_ID() As  System.Nullable(Of Long) 
            Get
                Return _REF_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _REF_ID = value
            End Set
        End Property 
        <Column(Storage:="_ATTACH_STATUS", DbType:="Char(1)")>  _
        Public Property ATTACH_STATUS() As  System.Nullable(Of Char) 
            Get
                Return _ATTACH_STATUS
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _ATTACH_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_ATTACH_TIME", DbType:="DateTime")>  _
        Public Property ATTACH_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _ATTACH_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _ATTACH_TIME = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_ATTACH_FILE_ID", DbType:="BigInt")>  _
        Public Property DOCUMENT_ATTACH_FILE_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_ATTACH_FILE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_ATTACH_FILE_ID = value
            End Set
        End Property 


    End Class
End Namespace
