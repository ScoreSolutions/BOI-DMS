
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for TH_EGIF_DOC_INBOUND table Parameter.
    '[Create by  on September, 6 2012]

    <Table(Name:="TH_EGIF_DOC_INBOUND")>  _
    Public Class ThEgifDocInboundPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _PROCESS_ID As String = ""
        Dim _PROCESS_TIME As String = ""
        Dim _BODY_ID As String = ""
        Dim _BODY_CORRESPONDENCE_DATE As String = ""
        Dim _BODY_SUBJECT As String = ""
        Dim _BODY_SECRET_CODE As  String  = ""
        Dim _BODY_SPEED_CODE As  String  = ""
        Dim _SENDER_GIVEN_NAME As  String  = ""
        Dim _SENDER_FAMILY_NAME As  String  = ""
        Dim _SENDER_JOBTITLE As  String  = ""
        Dim _SENDER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _SENDER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _RECEIVER_GIVEN_NAME As  String  = ""
        Dim _RECEIVER_FAMILY_NAME As  String  = ""
        Dim _RECEIVER_JOBTITLE As  String  = ""
        Dim _RECEIVER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _RECEIVER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _ATTACHMENT As  String  = ""
        Dim _SEND_DATE As  String  = ""
        Dim _DESCRIPTION As  String  = ""
        Dim _MAIN_LETTER_MIME As  String  = ""
        Dim _MAIN_LETTER_DATABASE64 As  String  = ""
        Dim _GOVERNMENT_SIGNATURE_TYPECODE As  String  = ""
        Dim _SIGNER_GIVEN_NAME As  String  = ""
        Dim _SIGNER_FAMILY_NAME As  String  = ""
        Dim _SIGNER_JOB_TITLE As  String  = ""
        Dim _SIGNER_MINISTRY_ORGANIZATION_ID As  String  = ""
        Dim _SIGNER_DEPARTMENT_ORGANIZATION_ID As  String  = ""
        Dim _REFERENCE_URI As  String  = ""
        Dim _REFERENCE_DIGEST_VALUE As  String  = ""
        Dim _SIGNATURE_VALUE As  String  = ""
        Dim _KEY_VALUE_MODULE As  String  = ""
        Dim _KEY_VALUE_EXPONENT As  String  = ""
        Dim _DELETE_JOB_PROCESSID As  String  = ""
        Dim _DELETE_JOB_PROCESSTIME As  String  = ""
        Dim _RECEIVE_NOTIFY_LETTERID As  String  = ""
        Dim _RECEIVE_NOTIFY_CORRESPONDENCE_DATE As  String  = ""
        Dim _RECEIVE_NOTIFY_SUBJECT As  String  = ""
        Dim _RECEIVE_NOTIFY_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_PROCESS_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property PROCESS_ID() As String
            Get
                Return _PROCESS_ID
            End Get
            Set(ByVal value As String)
               _PROCESS_ID = value
            End Set
        End Property 
        <Column(Storage:="_PROCESS_TIME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property PROCESS_TIME() As String
            Get
                Return _PROCESS_TIME
            End Get
            Set(ByVal value As String)
               _PROCESS_TIME = value
            End Set
        End Property 
        <Column(Storage:="_BODY_ID", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_ID() As String
            Get
                Return _BODY_ID
            End Get
            Set(ByVal value As String)
               _BODY_ID = value
            End Set
        End Property 
        <Column(Storage:="_BODY_CORRESPONDENCE_DATE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_CORRESPONDENCE_DATE() As String
            Get
                Return _BODY_CORRESPONDENCE_DATE
            End Get
            Set(ByVal value As String)
               _BODY_CORRESPONDENCE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SUBJECT", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BODY_SUBJECT() As String
            Get
                Return _BODY_SUBJECT
            End Get
            Set(ByVal value As String)
               _BODY_SUBJECT = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SECRET_CODE", DbType:="VarChar(10)")>  _
        Public Property BODY_SECRET_CODE() As  String 
            Get
                Return _BODY_SECRET_CODE
            End Get
            Set(ByVal value As  String )
               _BODY_SECRET_CODE = value
            End Set
        End Property 
        <Column(Storage:="_BODY_SPEED_CODE", DbType:="VarChar(10)")>  _
        Public Property BODY_SPEED_CODE() As  String 
            Get
                Return _BODY_SPEED_CODE
            End Get
            Set(ByVal value As  String )
               _BODY_SPEED_CODE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property SENDER_GIVEN_NAME() As  String 
            Get
                Return _SENDER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _SENDER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property SENDER_FAMILY_NAME() As  String 
            Get
                Return _SENDER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _SENDER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_JOBTITLE", DbType:="VarChar(255)")>  _
        Public Property SENDER_JOBTITLE() As  String 
            Get
                Return _SENDER_JOBTITLE
            End Get
            Set(ByVal value As  String )
               _SENDER_JOBTITLE = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SENDER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _SENDER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SENDER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_SENDER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SENDER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _SENDER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SENDER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property RECEIVER_GIVEN_NAME() As  String 
            Get
                Return _RECEIVER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property RECEIVER_FAMILY_NAME() As  String 
            Get
                Return _RECEIVER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _RECEIVER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_JOBTITLE", DbType:="VarChar(255)")>  _
        Public Property RECEIVER_JOBTITLE() As  String 
            Get
                Return _RECEIVER_JOBTITLE
            End Get
            Set(ByVal value As  String )
               _RECEIVER_JOBTITLE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property RECEIVER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _RECEIVER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property RECEIVER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _RECEIVER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _RECEIVER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ATTACHMENT", DbType:="Text")>  _
        Public Property ATTACHMENT() As  String 
            Get
                Return _ATTACHMENT
            End Get
            Set(ByVal value As  String )
               _ATTACHMENT = value
            End Set
        End Property 
        <Column(Storage:="_SEND_DATE", DbType:="VarChar(50)")>  _
        Public Property SEND_DATE() As  String 
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As  String )
               _SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="Text")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_MAIN_LETTER_MIME", DbType:="VarChar(50)")>  _
        Public Property MAIN_LETTER_MIME() As  String 
            Get
                Return _MAIN_LETTER_MIME
            End Get
            Set(ByVal value As  String )
               _MAIN_LETTER_MIME = value
            End Set
        End Property 
        <Column(Storage:="_MAIN_LETTER_DATABASE64", DbType:="Text")>  _
        Public Property MAIN_LETTER_DATABASE64() As  String 
            Get
                Return _MAIN_LETTER_DATABASE64
            End Get
            Set(ByVal value As  String )
               _MAIN_LETTER_DATABASE64 = value
            End Set
        End Property 
        <Column(Storage:="_GOVERNMENT_SIGNATURE_TYPECODE", DbType:="VarChar(50)")>  _
        Public Property GOVERNMENT_SIGNATURE_TYPECODE() As  String 
            Get
                Return _GOVERNMENT_SIGNATURE_TYPECODE
            End Get
            Set(ByVal value As  String )
               _GOVERNMENT_SIGNATURE_TYPECODE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_GIVEN_NAME", DbType:="VarChar(100)")>  _
        Public Property SIGNER_GIVEN_NAME() As  String 
            Get
                Return _SIGNER_GIVEN_NAME
            End Get
            Set(ByVal value As  String )
               _SIGNER_GIVEN_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_FAMILY_NAME", DbType:="VarChar(100)")>  _
        Public Property SIGNER_FAMILY_NAME() As  String 
            Get
                Return _SIGNER_FAMILY_NAME
            End Get
            Set(ByVal value As  String )
               _SIGNER_FAMILY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_JOB_TITLE", DbType:="VarChar(255)")>  _
        Public Property SIGNER_JOB_TITLE() As  String 
            Get
                Return _SIGNER_JOB_TITLE
            End Get
            Set(ByVal value As  String )
               _SIGNER_JOB_TITLE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_MINISTRY_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SIGNER_MINISTRY_ORGANIZATION_ID() As  String 
            Get
                Return _SIGNER_MINISTRY_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SIGNER_MINISTRY_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_SIGNER_DEPARTMENT_ORGANIZATION_ID", DbType:="VarChar(10)")>  _
        Public Property SIGNER_DEPARTMENT_ORGANIZATION_ID() As  String 
            Get
                Return _SIGNER_DEPARTMENT_ORGANIZATION_ID
            End Get
            Set(ByVal value As  String )
               _SIGNER_DEPARTMENT_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_REFERENCE_URI", DbType:="Text")>  _
        Public Property REFERENCE_URI() As  String 
            Get
                Return _REFERENCE_URI
            End Get
            Set(ByVal value As  String )
               _REFERENCE_URI = value
            End Set
        End Property 
        <Column(Storage:="_REFERENCE_DIGEST_VALUE", DbType:="Text")>  _
        Public Property REFERENCE_DIGEST_VALUE() As  String 
            Get
                Return _REFERENCE_DIGEST_VALUE
            End Get
            Set(ByVal value As  String )
               _REFERENCE_DIGEST_VALUE = value
            End Set
        End Property 
        <Column(Storage:="_SIGNATURE_VALUE", DbType:="Text")>  _
        Public Property SIGNATURE_VALUE() As  String 
            Get
                Return _SIGNATURE_VALUE
            End Get
            Set(ByVal value As  String )
               _SIGNATURE_VALUE = value
            End Set
        End Property 
        <Column(Storage:="_KEY_VALUE_MODULE", DbType:="Text")>  _
        Public Property KEY_VALUE_MODULE() As  String 
            Get
                Return _KEY_VALUE_MODULE
            End Get
            Set(ByVal value As  String )
               _KEY_VALUE_MODULE = value
            End Set
        End Property 
        <Column(Storage:="_KEY_VALUE_EXPONENT", DbType:="Text")>  _
        Public Property KEY_VALUE_EXPONENT() As  String 
            Get
                Return _KEY_VALUE_EXPONENT
            End Get
            Set(ByVal value As  String )
               _KEY_VALUE_EXPONENT = value
            End Set
        End Property 
        <Column(Storage:="_DELETE_JOB_PROCESSID", DbType:="VarChar(50)")>  _
        Public Property DELETE_JOB_PROCESSID() As  String 
            Get
                Return _DELETE_JOB_PROCESSID
            End Get
            Set(ByVal value As  String )
               _DELETE_JOB_PROCESSID = value
            End Set
        End Property 
        <Column(Storage:="_DELETE_JOB_PROCESSTIME", DbType:="VarChar(50)")>  _
        Public Property DELETE_JOB_PROCESSTIME() As  String 
            Get
                Return _DELETE_JOB_PROCESSTIME
            End Get
            Set(ByVal value As  String )
               _DELETE_JOB_PROCESSTIME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_LETTERID", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_NOTIFY_LETTERID() As  String 
            Get
                Return _RECEIVE_NOTIFY_LETTERID
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_LETTERID = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_CORRESPONDENCE_DATE", DbType:="VarChar(50)")>  _
        Public Property RECEIVE_NOTIFY_CORRESPONDENCE_DATE() As  String 
            Get
                Return _RECEIVE_NOTIFY_CORRESPONDENCE_DATE
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_CORRESPONDENCE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_SUBJECT", DbType:="VarChar(255)")>  _
        Public Property RECEIVE_NOTIFY_SUBJECT() As  String 
            Get
                Return _RECEIVE_NOTIFY_SUBJECT
            End Get
            Set(ByVal value As  String )
               _RECEIVE_NOTIFY_SUBJECT = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_NOTIFY_TIME", DbType:="DateTime")>  _
        Public Property RECEIVE_NOTIFY_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_NOTIFY_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_NOTIFY_TIME = value
            End Set
        End Property 


            'Define Child Table 

       Dim _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id As DataTable
       Dim _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id As DataTable

       Public Property CHILD_TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id() As DataTable
           Get
               Return _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id
           End Get
           Set(ByVal value As DataTable)
               _TH_EGIF_DOC_INBOUND_ATT_th_egif_doc_inbound_id = value
           End Set
       End Property
       Public Property CHILD_TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id() As DataTable
           Get
               Return _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id
           End Get
           Set(ByVal value As DataTable)
               _TH_EGIF_DOC_INBOUND_REF_th_egif_doc_inbound_id = value
           End Set
       End Property
    End Class
End Namespace
