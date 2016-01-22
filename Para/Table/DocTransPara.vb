
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for DOC_TRANS table Parameter.
    '[Create by  on October, 1 2012]

    <Table(Name:="DOC_TRANS")>  _
    Public Class DocTransPara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _ID_REF As  System.Nullable(Of Long)  = 0
        Dim _DOC_NO As  String  = ""
        Dim _DOC_SECRET As  String  = ""
        Dim _DOC_SPEED As  String  = ""
        Dim _DOC_DATE1 As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_DATE2 As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_ORGBOOKOWNER As  String  = ""
        Dim _DOC_OWNERADDRESS As  String  = ""
        Dim _DOC_TITLE As  String  = ""
        Dim _DOC_TITLECOMMAND As  String  = ""
        Dim _DOC_REFNO As  String  = ""
        Dim _DOC_TITLE_WHEN As  String  = ""
        Dim _DOC_TITLE_AT As  String  = ""
        Dim _DOC_TITLE_REGIS As  String  = ""
        Dim _DOC_TITLE_MEET As  String  = ""
        Dim _DOC_TITLE_NOMEET As  String  = ""
        Dim _DOC_TITLE_GROUP As  String  = ""
        Dim _DOC_MEMO_WONER As  String  = ""
        Dim _DOC_CONTENT As  String  = ""
        Dim _DOC_LEAN As  String  = ""
        Dim _DOC_REFTO As  String  = ""
        Dim _DOC_ATTACH As  String  = ""
        Dim _DOC_POSCRIPT As  String  = ""
        Dim _DOC_OFFICESIGN As  String  = ""
        Dim _DOC_POSITION As  String  = ""
        Dim _DOC_POSITIONSIGN As  String  = ""
        Dim _DOC_TITLEOWNER As  String  = ""
        Dim _DOC_TEL As  String  = ""
        Dim _DOC_FAX As  String  = ""
        Dim _DOC_ADDR As  String  = ""
        Dim _DOC_CCTO As  String  = ""
        Dim _DOC_DETAIL As  String  = ""
        Dim _DOC_TYPE As  System.Nullable(Of Long)  = 0
        Dim _DOC_USER As  String  = ""
        Dim _DOC_STATUS As  String  = ""
        Dim _DOC_STATUS_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CREATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_CREATE_BY As  String  = ""
        Dim _DOC_EDIT_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_EDIT_BY As  String  = ""
        Dim _DOC_SEND_BY As  String  = ""
        Dim _DOC_SEND_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _DOC_ORG_FROM As  String  = ""
        Dim _DOC_TO As  String  = ""
        Dim _DOC_ORG_TO As  String  = ""
        Dim _DOC_OBJ_TO As  String  = ""
        Dim _DOC_APPROVED As  String  = "((0))"
        Dim _DOC_OWNERADDRESS2 As  String  = ""
        Dim _IS_READ As Char = "N"
        Dim _SENDBACK_REMARKS As  String  = ""
        Dim _IS_SEND As Char = "N"

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_ID_REF", DbType:="Int")>  _
        Public Property ID_REF() As  System.Nullable(Of Long) 
            Get
                Return _ID_REF
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _ID_REF = value
            End Set
        End Property 
        <Column(Storage:="_DOC_NO", DbType:="VarChar(50)")>  _
        Public Property DOC_NO() As  String 
            Get
                Return _DOC_NO
            End Get
            Set(ByVal value As  String )
               _DOC_NO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SECRET", DbType:="VarChar(50)")>  _
        Public Property DOC_SECRET() As  String 
            Get
                Return _DOC_SECRET
            End Get
            Set(ByVal value As  String )
               _DOC_SECRET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SPEED", DbType:="VarChar(50)")>  _
        Public Property DOC_SPEED() As  String 
            Get
                Return _DOC_SPEED
            End Get
            Set(ByVal value As  String )
               _DOC_SPEED = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DATE1", DbType:="DateTime")>  _
        Public Property DOC_DATE1() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_DATE1
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_DATE1 = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DATE2", DbType:="DateTime")>  _
        Public Property DOC_DATE2() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_DATE2
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_DATE2 = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORGBOOKOWNER", DbType:="VarChar(255)")>  _
        Public Property DOC_ORGBOOKOWNER() As  String 
            Get
                Return _DOC_ORGBOOKOWNER
            End Get
            Set(ByVal value As  String )
               _DOC_ORGBOOKOWNER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OWNERADDRESS", DbType:="VarChar(255)")>  _
        Public Property DOC_OWNERADDRESS() As  String 
            Get
                Return _DOC_OWNERADDRESS
            End Get
            Set(ByVal value As  String )
               _DOC_OWNERADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE", DbType:="VarChar(100)")>  _
        Public Property DOC_TITLE() As  String 
            Get
                Return _DOC_TITLE
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLECOMMAND", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLECOMMAND() As  String 
            Get
                Return _DOC_TITLECOMMAND
            End Get
            Set(ByVal value As  String )
               _DOC_TITLECOMMAND = value
            End Set
        End Property 
        <Column(Storage:="_DOC_REFNO", DbType:="VarChar(50)")>  _
        Public Property DOC_REFNO() As  String 
            Get
                Return _DOC_REFNO
            End Get
            Set(ByVal value As  String )
               _DOC_REFNO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_WHEN", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_WHEN() As  String 
            Get
                Return _DOC_TITLE_WHEN
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_WHEN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_AT", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_AT() As  String 
            Get
                Return _DOC_TITLE_AT
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_AT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_REGIS", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_REGIS() As  String 
            Get
                Return _DOC_TITLE_REGIS
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_REGIS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_MEET", DbType:="VarChar(255)")>  _
        Public Property DOC_TITLE_MEET() As  String 
            Get
                Return _DOC_TITLE_MEET
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_MEET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_NOMEET", DbType:="VarChar(50)")>  _
        Public Property DOC_TITLE_NOMEET() As  String 
            Get
                Return _DOC_TITLE_NOMEET
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_NOMEET = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLE_GROUP", DbType:="VarChar(10)")>  _
        Public Property DOC_TITLE_GROUP() As  String 
            Get
                Return _DOC_TITLE_GROUP
            End Get
            Set(ByVal value As  String )
               _DOC_TITLE_GROUP = value
            End Set
        End Property 
        <Column(Storage:="_DOC_MEMO_WONER", DbType:="VarChar(100)")>  _
        Public Property DOC_MEMO_WONER() As  String 
            Get
                Return _DOC_MEMO_WONER
            End Get
            Set(ByVal value As  String )
               _DOC_MEMO_WONER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CONTENT", DbType:="VarChar(100)")>  _
        Public Property DOC_CONTENT() As  String 
            Get
                Return _DOC_CONTENT
            End Get
            Set(ByVal value As  String )
               _DOC_CONTENT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_LEAN", DbType:="VarChar(255)")>  _
        Public Property DOC_LEAN() As  String 
            Get
                Return _DOC_LEAN
            End Get
            Set(ByVal value As  String )
               _DOC_LEAN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_REFTO", DbType:="VarChar(255)")>  _
        Public Property DOC_REFTO() As  String 
            Get
                Return _DOC_REFTO
            End Get
            Set(ByVal value As  String )
               _DOC_REFTO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ATTACH", DbType:="VarChar(255)")>  _
        Public Property DOC_ATTACH() As  String 
            Get
                Return _DOC_ATTACH
            End Get
            Set(ByVal value As  String )
               _DOC_ATTACH = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSCRIPT", DbType:="VarChar(50)")>  _
        Public Property DOC_POSCRIPT() As  String 
            Get
                Return _DOC_POSCRIPT
            End Get
            Set(ByVal value As  String )
               _DOC_POSCRIPT = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OFFICESIGN", DbType:="VarChar(50)")>  _
        Public Property DOC_OFFICESIGN() As  String 
            Get
                Return _DOC_OFFICESIGN
            End Get
            Set(ByVal value As  String )
               _DOC_OFFICESIGN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSITION", DbType:="VarChar(100)")>  _
        Public Property DOC_POSITION() As  String 
            Get
                Return _DOC_POSITION
            End Get
            Set(ByVal value As  String )
               _DOC_POSITION = value
            End Set
        End Property 
        <Column(Storage:="_DOC_POSITIONSIGN", DbType:="VarChar(50)")>  _
        Public Property DOC_POSITIONSIGN() As  String 
            Get
                Return _DOC_POSITIONSIGN
            End Get
            Set(ByVal value As  String )
               _DOC_POSITIONSIGN = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TITLEOWNER", DbType:="VarChar(50)")>  _
        Public Property DOC_TITLEOWNER() As  String 
            Get
                Return _DOC_TITLEOWNER
            End Get
            Set(ByVal value As  String )
               _DOC_TITLEOWNER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TEL", DbType:="VarChar(50)")>  _
        Public Property DOC_TEL() As  String 
            Get
                Return _DOC_TEL
            End Get
            Set(ByVal value As  String )
               _DOC_TEL = value
            End Set
        End Property 
        <Column(Storage:="_DOC_FAX", DbType:="VarChar(50)")>  _
        Public Property DOC_FAX() As  String 
            Get
                Return _DOC_FAX
            End Get
            Set(ByVal value As  String )
               _DOC_FAX = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ADDR", DbType:="VarChar(255)")>  _
        Public Property DOC_ADDR() As  String 
            Get
                Return _DOC_ADDR
            End Get
            Set(ByVal value As  String )
               _DOC_ADDR = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CCTO", DbType:="VarChar(255)")>  _
        Public Property DOC_CCTO() As  String 
            Get
                Return _DOC_CCTO
            End Get
            Set(ByVal value As  String )
               _DOC_CCTO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_DETAIL", DbType:="Text")>  _
        Public Property DOC_DETAIL() As  String 
            Get
                Return _DOC_DETAIL
            End Get
            Set(ByVal value As  String )
               _DOC_DETAIL = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TYPE", DbType:="Int")>  _
        Public Property DOC_TYPE() As  System.Nullable(Of Long) 
            Get
                Return _DOC_TYPE
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DOC_TYPE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_USER", DbType:="VarChar(50)")>  _
        Public Property DOC_USER() As  String 
            Get
                Return _DOC_USER
            End Get
            Set(ByVal value As  String )
               _DOC_USER = value
            End Set
        End Property 
        <Column(Storage:="_DOC_STATUS", DbType:="VarChar(50)")>  _
        Public Property DOC_STATUS() As  String 
            Get
                Return _DOC_STATUS
            End Get
            Set(ByVal value As  String )
               _DOC_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_DOC_STATUS_DATE", DbType:="DateTime")>  _
        Public Property DOC_STATUS_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_STATUS_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_STATUS_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CREATE_DATE", DbType:="DateTime")>  _
        Public Property DOC_CREATE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_CREATE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_CREATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_CREATE_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_CREATE_BY() As  String 
            Get
                Return _DOC_CREATE_BY
            End Get
            Set(ByVal value As  String )
               _DOC_CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_EDIT_DATE", DbType:="DateTime")>  _
        Public Property DOC_EDIT_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_EDIT_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_EDIT_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_EDIT_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_EDIT_BY() As  String 
            Get
                Return _DOC_EDIT_BY
            End Get
            Set(ByVal value As  String )
               _DOC_EDIT_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SEND_BY", DbType:="VarChar(50)")>  _
        Public Property DOC_SEND_BY() As  String 
            Get
                Return _DOC_SEND_BY
            End Get
            Set(ByVal value As  String )
               _DOC_SEND_BY = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SEND_DATE", DbType:="DateTime")>  _
        Public Property DOC_SEND_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _DOC_SEND_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _DOC_SEND_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORG_FROM", DbType:="VarChar(50)")>  _
        Public Property DOC_ORG_FROM() As  String 
            Get
                Return _DOC_ORG_FROM
            End Get
            Set(ByVal value As  String )
               _DOC_ORG_FROM = value
            End Set
        End Property 
        <Column(Storage:="_DOC_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_TO() As  String 
            Get
                Return _DOC_TO
            End Get
            Set(ByVal value As  String )
               _DOC_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_ORG_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_ORG_TO() As  String 
            Get
                Return _DOC_ORG_TO
            End Get
            Set(ByVal value As  String )
               _DOC_ORG_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OBJ_TO", DbType:="VarChar(50)")>  _
        Public Property DOC_OBJ_TO() As  String 
            Get
                Return _DOC_OBJ_TO
            End Get
            Set(ByVal value As  String )
               _DOC_OBJ_TO = value
            End Set
        End Property 
        <Column(Storage:="_DOC_APPROVED", DbType:="VarChar(1)")>  _
        Public Property DOC_APPROVED() As  String 
            Get
                Return _DOC_APPROVED
            End Get
            Set(ByVal value As  String )
               _DOC_APPROVED = value
            End Set
        End Property 
        <Column(Storage:="_DOC_OWNERADDRESS2", DbType:="VarChar(255)")>  _
        Public Property DOC_OWNERADDRESS2() As  String 
            Get
                Return _DOC_OWNERADDRESS2
            End Get
            Set(ByVal value As  String )
               _DOC_OWNERADDRESS2 = value
            End Set
        End Property 
        <Column(Storage:="_IS_READ", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_READ() As Char
            Get
                Return _IS_READ
            End Get
            Set(ByVal value As Char)
               _IS_READ = value
            End Set
        End Property 
        <Column(Storage:="_SENDBACK_REMARKS", DbType:="VarChar(255)")>  _
        Public Property SENDBACK_REMARKS() As  String 
            Get
                Return _SENDBACK_REMARKS
            End Get
            Set(ByVal value As  String )
               _SENDBACK_REMARKS = value
            End Set
        End Property 
        <Column(Storage:="_IS_SEND", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_SEND() As Char
            Get
                Return _IS_SEND
            End Get
            Set(ByVal value As Char)
               _IS_SEND = value
            End Set
        End Property 


    End Class
End Namespace
