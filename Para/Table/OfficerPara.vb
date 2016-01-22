
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for OFFICER table Parameter.
    '[Create by  on June, 16 2012]

    <Table(Name:="OFFICER")>  _
    Public Class OfficerPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USERNAME As  String  = ""
        Dim _PWD As  String  = ""
        Dim _OFFICER_CODE As  String  = ""
        Dim _FIRST_NAME As  String  = ""
        Dim _LAST_NAME As  String  = ""
        Dim _FIRST_NAME_THAI As  String  = ""
        Dim _LAST_NAME_THAI As  String  = ""
        Dim _FIRST_NAME_ENG As  String  = ""
        Dim _LAST_NAME_ENG As  String  = ""
        Dim _TITLE_ID As  System.Nullable(Of Long)  = 0
        Dim _DESCRIPTION As  String  = ""
        Dim _WORK_POSITION_ID As  System.Nullable(Of Long)  = 0
        Dim _EXEC_POSITION_ID As  System.Nullable(Of Long)  = 0
        Dim _WORK_ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _ORGANIZATION_ID As  System.Nullable(Of Long)  = 0
        Dim _GENDER As  System.Nullable(Of Char)  = ""
        Dim _BIRTH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IDENTITY_CARD As  String  = ""
        Dim _TEL As  String  = ""
        Dim _FAX As  String  = ""
        Dim _EMAIL As  String  = ""
        Dim _OFFICER_LEVEL As  String  = ""
        Dim _OFFICER_TYPE As  String  = ""
        Dim _SUMMER As  String  = ""
        Dim _EFDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _EPDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_USERNAME", DbType:="VarChar(50)")>  _
        Public Property USERNAME() As  String 
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As  String )
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_PWD", DbType:="VarChar(50)")>  _
        Public Property PWD() As  String 
            Get
                Return _PWD
            End Get
            Set(ByVal value As  String )
               _PWD = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_CODE", DbType:="VarChar(50)")>  _
        Public Property OFFICER_CODE() As  String 
            Get
                Return _OFFICER_CODE
            End Get
            Set(ByVal value As  String )
               _OFFICER_CODE = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME() As  String 
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME() As  String 
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As  String )
               _LAST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME_THAI() As  String 
            Get
                Return _FIRST_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME_THAI", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME_THAI() As  String 
            Get
                Return _LAST_NAME_THAI
            End Get
            Set(ByVal value As  String )
               _LAST_NAME_THAI = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property FIRST_NAME_ENG() As  String 
            Get
                Return _FIRST_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME_ENG", DbType:="VarChar(255)")>  _
        Public Property LAST_NAME_ENG() As  String 
            Get
                Return _LAST_NAME_ENG
            End Get
            Set(ByVal value As  String )
               _LAST_NAME_ENG = value
            End Set
        End Property 
        <Column(Storage:="_TITLE_ID", DbType:="BigInt")>  _
        Public Property TITLE_ID() As  System.Nullable(Of Long) 
            Get
                Return _TITLE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_DESCRIPTION", DbType:="VarChar(500)")>  _
        Public Property DESCRIPTION() As  String 
            Get
                Return _DESCRIPTION
            End Get
            Set(ByVal value As  String )
               _DESCRIPTION = value
            End Set
        End Property 
        <Column(Storage:="_WORK_POSITION_ID", DbType:="BigInt")>  _
        Public Property WORK_POSITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _WORK_POSITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _WORK_POSITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_EXEC_POSITION_ID", DbType:="BigInt")>  _
        Public Property EXEC_POSITION_ID() As  System.Nullable(Of Long) 
            Get
                Return _EXEC_POSITION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _EXEC_POSITION_ID = value
            End Set
        End Property 
        <Column(Storage:="_WORK_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property WORK_ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _WORK_ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _WORK_ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_ORGANIZATION_ID", DbType:="BigInt")>  _
        Public Property ORGANIZATION_ID() As  System.Nullable(Of Long) 
            Get
                Return _ORGANIZATION_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ORGANIZATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_GENDER", DbType:="Char(1)")>  _
        Public Property GENDER() As  System.Nullable(Of Char) 
            Get
                Return _GENDER
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _GENDER = value
            End Set
        End Property 
        <Column(Storage:="_BIRTH_DATE", DbType:="DateTime2")>  _
        Public Property BIRTH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _BIRTH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _BIRTH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_IDENTITY_CARD", DbType:="VarChar(13)")>  _
        Public Property IDENTITY_CARD() As  String 
            Get
                Return _IDENTITY_CARD
            End Get
            Set(ByVal value As  String )
               _IDENTITY_CARD = value
            End Set
        End Property 
        <Column(Storage:="_TEL", DbType:="VarChar(255)")>  _
        Public Property TEL() As  String 
            Get
                Return _TEL
            End Get
            Set(ByVal value As  String )
               _TEL = value
            End Set
        End Property 
        <Column(Storage:="_FAX", DbType:="VarChar(255)")>  _
        Public Property FAX() As  String 
            Get
                Return _FAX
            End Get
            Set(ByVal value As  String )
               _FAX = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255)")>  _
        Public Property EMAIL() As  String 
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As  String )
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_LEVEL", DbType:="VarChar(50)")>  _
        Public Property OFFICER_LEVEL() As  String 
            Get
                Return _OFFICER_LEVEL
            End Get
            Set(ByVal value As  String )
               _OFFICER_LEVEL = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_TYPE", DbType:="VarChar(50)")>  _
        Public Property OFFICER_TYPE() As  String 
            Get
                Return _OFFICER_TYPE
            End Get
            Set(ByVal value As  String )
               _OFFICER_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_SUMMER", DbType:="VarChar(50)")>  _
        Public Property SUMMER() As  String 
            Get
                Return _SUMMER
            End Get
            Set(ByVal value As  String )
               _SUMMER = value
            End Set
        End Property 
        <Column(Storage:="_EFDATE", DbType:="DateTime2")>  _
        Public Property EFDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EFDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EFDATE = value
            End Set
        End Property 
        <Column(Storage:="_EPDATE", DbType:="DateTime2")>  _
        Public Property EPDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _EPDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _EPDATE = value
            End Set
        End Property 


    End Class
End Namespace
