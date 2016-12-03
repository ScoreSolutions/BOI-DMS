
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOCUMENT_EXT_RECEIVER table Parameter.
    '[Create by  on September, 7 2012]

    <Table(Name:="DOCUMENT_EXT_RECEIVER")>  _
    Public Class DocumentExtReceiverPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOCUMENT_REGISTER_ID As Long = 0
        Dim _ORGANIZATION_ID_SEND As Long = 0
        Dim _ORGANIZATION_NAME_SEND As String = ""
        Dim _ORGANIZATION_APPNAME_SEND As  String  = ""
        Dim _SEND_DATE As DateTime = New DateTime(1,1,1)
        Dim _SENDER_OFFICER_USERNAME As String = ""
        Dim _SENDER_OFFICER_FULLNAME As String = ""
        Dim _BOOKOUT_NO As  String  = ""
        Dim _COMPANY_ID_RECEIVE As Long = 0
        Dim _COMPANY_NAME_RECEIVE As  String  = ""
        Dim _COMPANY_DOC_SYSTEM_ID As  String  = ""
        Dim _OFFICER_USERNAME As  String  = ""
        Dim _OFFICER_FULLNAME As  String  = ""
        Dim _REMARKS As  String  = ""
        Dim _SLOT_NO As  String  = ""
        Dim _RECEIVE_STATUS_ID As  String  = ""
        Dim _PUBLISH_TYPE_ID As  String  = ""
        Dim _ORGANIZATION_ID_STORAGE As Long = 0
        Dim _ORGANIZATION_NAME_STORAGE As  String  = ""
        Dim _EXPECT_FINISH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MAXIMUM_PROCESSING_PERIOD As  System.Nullable(Of Double)  = 0
        Dim _APPROVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _REF_OLD_SEND_ID As  String  = ""
        Dim _REF_OLD_RECEIVE_ID As  String  = ""
        Dim _IS_SEND_THEGIF As System.Nullable(Of Char) = ""
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
        <Column(Storage:="_DOCUMENT_REGISTER_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOCUMENT_REGISTER_ID() As Long
            Get
                Return _DOCUMENT_REGISTER_ID
            End Get
            Set(ByVal value As Long)
               _DOCUMENT_REGISTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_SEND", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID_SEND() As Long
            Get
                Return _ORGANIZATION_ID_SEND
            End Get
            Set(ByVal value As Long)
               _ORGANIZATION_ID_SEND = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_NAME_SEND", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_NAME_SEND() As String
            Get
                Return _ORGANIZATION_NAME_SEND
            End Get
            Set(ByVal value As String)
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
        <Column(Storage:="_SEND_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property SEND_DATE() As DateTime
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As DateTime)
               _SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SENDER_OFFICER_USERNAME() As String
            Get
                Return _SENDER_OFFICER_USERNAME
            End Get
            Set(ByVal value As String)
               _SENDER_OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_OFFICER_FULLNAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SENDER_OFFICER_FULLNAME() As String
            Get
                Return _SENDER_OFFICER_FULLNAME
            End Get
            Set(ByVal value As String)
               _SENDER_OFFICER_FULLNAME = value
            End Set
        End Property 
        <Column(Storage:="_BOOKOUT_NO", DbType:="VarChar(50)")>  _
        Public Property BOOKOUT_NO() As  String 
            Get
                Return _BOOKOUT_NO
            End Get
            Set(ByVal value As  String )
               _BOOKOUT_NO = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_ID_RECEIVE", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_ID_RECEIVE() As Long
            Get
                Return _COMPANY_ID_RECEIVE
            End Get
            Set(ByVal value As Long)
               _COMPANY_ID_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME_RECEIVE", DbType:="VarChar(255)")>  _
        Public Property COMPANY_NAME_RECEIVE() As  String 
            Get
                Return _COMPANY_NAME_RECEIVE
            End Get
            Set(ByVal value As  String )
               _COMPANY_NAME_RECEIVE = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_DOC_SYSTEM_ID", DbType:="VarChar(50)")>  _
        Public Property COMPANY_DOC_SYSTEM_ID() As  String 
            Get
                Return _COMPANY_DOC_SYSTEM_ID
            End Get
            Set(ByVal value As  String )
               _COMPANY_DOC_SYSTEM_ID = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_USERNAME", DbType:="VarChar(50)")>  _
        Public Property OFFICER_USERNAME() As  String 
            Get
                Return _OFFICER_USERNAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_FULLNAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_FULLNAME() As  String 
            Get
                Return _OFFICER_FULLNAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_FULLNAME = value
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
        <Column(Storage:="_SLOT_NO", DbType:="VarChar(50)")>  _
        Public Property SLOT_NO() As  String 
            Get
                Return _SLOT_NO
            End Get
            Set(ByVal value As  String )
               _SLOT_NO = value
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
        <Column(Storage:="_PUBLISH_TYPE_ID", DbType:="VarChar(50)")>  _
        Public Property PUBLISH_TYPE_ID() As  String 
            Get
                Return _PUBLISH_TYPE_ID
            End Get
            Set(ByVal value As  String )
               _PUBLISH_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID_STORAGE", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ORGANIZATION_ID_STORAGE() As Long
            Get
                Return _ORGANIZATION_ID_STORAGE
            End Get
            Set(ByVal value As Long)
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
        <Column(Storage:="_EXPECT_FINISH_DATE", DbType:="DateTime")>  _
        Public Property EXPECT_FINISH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EXPECT_FINISH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EXPECT_FINISH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_MAXIMUM_PROCESSING_PERIOD", DbType:="Float")>  _
        Public Property MAXIMUM_PROCESSING_PERIOD() As  System.Nullable(Of Double) 
            Get
                Return _MAXIMUM_PROCESSING_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Double) )
               _MAXIMUM_PROCESSING_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_APPROVE_DATE", DbType:="DateTime")>  _
        Public Property APPROVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _APPROVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _APPROVE_DATE = value
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
        <Column(Storage:="_IS_SEND_THEGIF", DbType:="Char(1)")>  _
        Public Property IS_SEND_THEGIF() As  System.Nullable(Of Char) 
            Get
                Return _IS_SEND_THEGIF
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_SEND_THEGIF = value
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

    End Class
End Namespace
