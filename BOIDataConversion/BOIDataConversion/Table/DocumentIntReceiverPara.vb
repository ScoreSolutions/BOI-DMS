
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_INT_RECEIVER table Parameter.
    '[Create by  on July, 13 2012]

    <Table(Name:="DOCUMENT_INT_RECEIVER")>  _
    Public Class DocumentIntReceiverPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As  String  = ""
        Dim _CREATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_REGISTER_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID_SEND As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_SEND As  String  = ""
        Dim _ORGANIZATION_APPNAME_SEND As  String  = ""
        Dim _SEND_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SENDER_OFFICER_USERNAME As  String  = ""
        Dim _SENDER_OFFICER_FULLNAME As  String  = ""
        Dim _RECEIVE_STATUS_ID As  String  = ""
        Dim _RECEIVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _ORGANIZATION_ID_RECEIVE As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_RECEIVE As  String  = ""
        Dim _ORGANIZATION_APPNAME_RECEIVE As  String  = ""
        Dim _RECEIVER_OFFICER_USERNAME As  String  = ""
        Dim _RECEIVER_OFFICER_FULLNAME As  String  = ""
        Dim _RECEIVE_TYPE_ID As  String  = ""
        Dim _RECEIVE_OBJECTIVE_ID As  System.Nullable(Of Long)  = 0
        Dim _REMARKS As  String  = ""
        Dim _ORGANIZATION_ID_STORAGE As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_NAME_STORAGE As  String  = ""
        Dim _REF_OLD_SEND_ID As  String  = ""
        Dim _REF_OLD_RECEIVE_ID As  String  = ""
        Dim _DOCUMENT_STATEMENT As  String  = ""
        Dim _DOCUMENT_INT_TYPE As  System.Nullable(Of Long)  = 0
        Dim _MODULE_FOLDER_ID As Long = 0
        Dim _IS_FORWARD As Char = "N"
        Dim _SENDBACK_REASON As  String  = ""
        Dim _RETRIEVE_REASON As  String  = ""

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
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(50)")>  _
        Public Property CREATE_BY() As  String 
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As  String )
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_ON", DbType:="DateTime2")>  _
        Public Property CREATE_ON() As  System.Nullable(Of DateTime) 
            Get
                Return _CREATE_ON
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
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
        <Column(Storage:="_DOCUMENT_REGISTER_ID", DbType:="BigInt")>  _
        Public Property DOCUMENT_REGISTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_SEND", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_SEND() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_SEND
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_SEND = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_SEND", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_SEND() As  String 
            Get
                Return _ORGANIZATION_NAME_SEND
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_SEND = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_SEND", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_APPNAME_SEND() As  String 
            Get
                Return _ORGANIZATION_APPNAME_SEND
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_APPNAME_SEND = value
            End Set
        End Property 
        <Column(Storage:="_SEND_DATE", DbType:="DateTime")>  _
        Public Property SEND_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_USERNAME", DbType:="VarChar(50)")>  _
        Public Property SENDER_OFFICER_USERNAME() As  String 
            Get
                Return _SENDER_OFFICER_USERNAME
            End Get
            Set(ByVal value As  String )
               _SENDER_OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_FULLNAME", DbType:="VarChar(255)")>  _
        Public Property SENDER_OFFICER_FULLNAME() As  String 
            Get
                Return _SENDER_OFFICER_FULLNAME
            End Get
            Set(ByVal value As  String )
               _SENDER_OFFICER_FULLNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_STATUS_ID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_STATUS_ID() As  String 
            Get
                Return _RECEIVE_STATUS_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_STATUS_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_DATE", DbType:="DateTime")>  _
        Public Property RECEIVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_RECEIVE", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_RECEIVE() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_RECEIVE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_RECEIVE() As  String 
            Get
                Return _ORGANIZATION_NAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_APPNAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_APPNAME_RECEIVE() As  String 
            Get
                Return _ORGANIZATION_APPNAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_APPNAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_OFFICER_USERNAME", DbType:="VarChar(50)")>  _
        Public Property RECEIVER_OFFICER_USERNAME() As  String 
            Get
                Return _RECEIVER_OFFICER_USERNAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_OFFICER_FULLNAME", DbType:="VarChar(255)")>  _
        Public Property RECEIVER_OFFICER_FULLNAME() As  String 
            Get
                Return _RECEIVER_OFFICER_FULLNAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_OFFICER_FULLNAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_TYPE_ID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_TYPE_ID() As  String 
            Get
                Return _RECEIVE_TYPE_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_OBJECTIVE_ID", DbType:="BigInt")>  _
        Public Property RECEIVE_OBJECTIVE_ID() As  System.Nullable(Of Long) 
            Get
                Return _RECEIVE_OBJECTIVE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _RECEIVE_OBJECTIVE_ID = value
            End Set
        End Property 
        <Column(Storage:="_REMARKS", DbType:="VarChar(500)")>  _
        Public Property REMARKS() As  String 
            Get
                Return _REMARKS
            End Get
            Set(ByVal value As  String )
               _REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_STORAGE", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID_STORAGE() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID_STORAGE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID_STORAGE = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_STORAGE", DbType:="VarChar(255)")>  _
        Public Property ORGANIZATION_NAME_STORAGE() As  String 
            Get
                Return _ORGANIZATION_NAME_STORAGE
            End Get
            Set(ByVal value As  String )
               _ORGANIZATION_NAME_STORAGE = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_SEND_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_SEND_ID() As  String 
            Get
                Return _REF_OLD_SEND_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_SEND_ID = value
            End Set
        End Property 
        <Column(Storage:="_REF_OLD_RECEIVE_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_RECEIVE_ID() As  String 
            Get
                Return _REF_OLD_RECEIVE_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_RECEIVE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_STATEMENT", DbType:="VarChar(100)")>  _
        Public Property DOCUMENT_STATEMENT() As  String 
            Get
                Return _DOCUMENT_STATEMENT
            End Get
            Set(ByVal value As  String )
               _DOCUMENT_STATEMENT = value
            End Set
        End Property 
        <Column(Storage:="_DOCUMENT_INT_TYPE", DbType:="Int")>  _
        Public Property DOCUMENT_INT_TYPE() As  System.Nullable(Of Long) 
            Get
                Return _DOCUMENT_INT_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOCUMENT_INT_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_MODULE_FOLDER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MODULE_FOLDER_ID() As Long
            Get
                Return _MODULE_FOLDER_ID
            End Get
            Set(ByVal value As Long)
               _MODULE_FOLDER_ID = value
            End Set
        End Property 
        <Column(Storage:="_IS_FORWARD", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_FORWARD() As Char
            Get
                Return _IS_FORWARD
            End Get
            Set(ByVal value As Char)
               _IS_FORWARD = value
            End Set
        End Property 
        <Column(Storage:="_SENDBACK_REASON", DbType:="VarChar(500)")>  _
        Public Property SENDBACK_REASON() As  String 
            Get
                Return _SENDBACK_REASON
            End Get
            Set(ByVal value As  String )
               _SENDBACK_REASON = value
            End Set
        End Property 
        <Column(Storage:="_RETRIEVE_REASON", DbType:="VarChar(500)")>  _
        Public Property RETRIEVE_REASON() As  String 
            Get
                Return _RETRIEVE_REASON
            End Get
            Set(ByVal value As  String )
               _RETRIEVE_REASON = value
            End Set
        End Property 


    End Class
End Namespace
