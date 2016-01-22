
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 

Namespace TABLE
    'Represents a transaction for GROUP_TITLE table Parameter.
    '[Create by  on January, 7 2013]

    <Table(Name:="GROUP_TITLE")>  _
    Public Class GroupTitlePara

        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_ON As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_ON As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _GROUP_TITLE_CODE As String = ""
        Dim _GROUP_TITLE_NAME As String = ""
        Dim _GROUP_TITLE_TYPE_ID As Long = 0
        Dim _STD_PROC_PERIOD As  System.Nullable(Of Double)  = 0
        Dim _MAX_PROC_PERIOD As  System.Nullable(Of Double)  = 0
        Dim _SUBJECT_ID As  System.Nullable(Of Long)  = 0
        Dim _IS_GEN_REQ As  System.Nullable(Of Char)  = ""
        Dim _DOC_SYS_ID As Long = 0
        Dim _WKIN_CODE As  String  = ""
        Dim _WKIN_GROUP_REP As  String  = ""
        Dim _WKIN_GROUP_CODE As  String  = ""
        Dim _DUE_STEP1 As  System.Nullable(Of Long)  = 0
        Dim _DUE_STEP2 As  System.Nullable(Of Long)  = 0
        Dim _DUE_STEP3 As  System.Nullable(Of Long)  = 0
        Dim _DIV_STEP1 As  String  = ""
        Dim _DIV_STEP2 As  String  = ""
        Dim _DIV_STEP3 As  String  = ""
        Dim _ACTIVE As Char = "Y"
        Dim _REF_OLD_ID As  String  = ""
        Dim _NO_DEFAULT_TITLE As Char = "N"

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
        <Column(Storage:="_GROUP_TITLE_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_CODE() As String
            Get
                Return _GROUP_TITLE_CODE
            End Get
            Set(ByVal value As String)
               _GROUP_TITLE_CODE = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_TITLE_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_NAME() As String
            Get
                Return _GROUP_TITLE_NAME
            End Get
            Set(ByVal value As String)
               _GROUP_TITLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_TITLE_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property GROUP_TITLE_TYPE_ID() As Long
            Get
                Return _GROUP_TITLE_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _GROUP_TITLE_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_STD_PROC_PERIOD", DbType:="Float")>  _
        Public Property STD_PROC_PERIOD() As  System.Nullable(Of Double) 
            Get
                Return _STD_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Double) )
               _STD_PROC_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_MAX_PROC_PERIOD", DbType:="Float")>  _
        Public Property MAX_PROC_PERIOD() As  System.Nullable(Of Double) 
            Get
                Return _MAX_PROC_PERIOD
            End Get
            Set(ByVal value As  System.Nullable(Of Double) )
               _MAX_PROC_PERIOD = value
            End Set
        End Property 
        <Column(Storage:="_SUBJECT_ID", DbType:="BigInt")>  _
        Public Property SUBJECT_ID() As  System.Nullable(Of Long) 
            Get
                Return _SUBJECT_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SUBJECT_ID = value
            End Set
        End Property 
        <Column(Storage:="_IS_GEN_REQ", DbType:="Char(1)")>  _
        Public Property IS_GEN_REQ() As  System.Nullable(Of Char) 
            Get
                Return _IS_GEN_REQ
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _IS_GEN_REQ = value
            End Set
        End Property 
        <Column(Storage:="_DOC_SYS_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property DOC_SYS_ID() As Long
            Get
                Return _DOC_SYS_ID
            End Get
            Set(ByVal value As Long)
               _DOC_SYS_ID = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_CODE", DbType:="VarChar(8)")>  _
        Public Property WKIN_CODE() As  String 
            Get
                Return _WKIN_CODE
            End Get
            Set(ByVal value As  String )
               _WKIN_CODE = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_GROUP_REP", DbType:="VarChar(1)")>  _
        Public Property WKIN_GROUP_REP() As  String 
            Get
                Return _WKIN_GROUP_REP
            End Get
            Set(ByVal value As  String )
               _WKIN_GROUP_REP = value
            End Set
        End Property 
        <Column(Storage:="_WKIN_GROUP_CODE", DbType:="VarChar(8)")>  _
        Public Property WKIN_GROUP_CODE() As  String 
            Get
                Return _WKIN_GROUP_CODE
            End Get
            Set(ByVal value As  String )
               _WKIN_GROUP_CODE = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP1", DbType:="Int")>  _
        Public Property DUE_STEP1() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP1
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP1 = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP2", DbType:="Int")>  _
        Public Property DUE_STEP2() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP2
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP2 = value
            End Set
        End Property 
        <Column(Storage:="_DUE_STEP3", DbType:="Int")>  _
        Public Property DUE_STEP3() As  System.Nullable(Of Long) 
            Get
                Return _DUE_STEP3
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _DUE_STEP3 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP1", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP1() As  String 
            Get
                Return _DIV_STEP1
            End Get
            Set(ByVal value As  String )
               _DIV_STEP1 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP2", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP2() As  String 
            Get
                Return _DIV_STEP2
            End Get
            Set(ByVal value As  String )
               _DIV_STEP2 = value
            End Set
        End Property 
        <Column(Storage:="_DIV_STEP3", DbType:="VarChar(5)")>  _
        Public Property DIV_STEP3() As  String 
            Get
                Return _DIV_STEP3
            End Get
            Set(ByVal value As  String )
               _DIV_STEP3 = value
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
        <Column(Storage:="_REF_OLD_ID", DbType:="VarChar(50)")>  _
        Public Property REF_OLD_ID() As  String 
            Get
                Return _REF_OLD_ID
            End Get
            Set(ByVal value As  String )
               _REF_OLD_ID = value
            End Set
        End Property 
        <Column(Storage:="_NO_DEFAULT_TITLE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property NO_DEFAULT_TITLE() As Char
            Get
                Return _NO_DEFAULT_TITLE
            End Get
            Set(ByVal value As Char)
               _NO_DEFAULT_TITLE = value
            End Set
        End Property 


    End Class
End Namespace
