Imports System.Data.Linq.Mapping

Namespace DmsService
    <Serializable()> Public Class SendDocumentReqPara

        Dim _WS_SENDDOC_LOG_ID As Long = 0
        Dim _BOOK_NO As String = ""
        Dim _REGISTER_DATE As DateTime = New DateTime(1, 1, 1)
        Dim _EXPECTED_FINISH_DATE As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _COMPANY_DOC_NO As String = ""
        Dim _COMPANY_DOC_DATE As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _REFER_TO As String = ""
        Dim _GROUP_TITLE_CODE As String = ""
        Dim _TITLE_NAME As String = ""
        Dim _COMPANY_NAME As String = ""
        Dim _COMPANY_SIGN As String = ""
        Dim _REMARKS As String = ""
        Dim _ORG_CODE_OWNER As String = ""
        Dim _OFFICER_ID_APPORVE As String = ""
        Dim _BOOK_OUT_NO As String = ""
        Dim _BOOK_STATUS As String = ""
        Dim _CLOSE_DATE As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _ORG_CLOSE_PROCESS As String = ""
        Dim _STAFF_ID_PROCESS As String = ""
        Dim _STAFF_OTHER_PROCESS As String = ""


        <Column(Storage:="_WS_SENDDOC_LOG_ID", DbType:="BigInt NOT NULL ", CanBeNull:=False)> _
        Public Property SendRefID() As Long
            Get
                Return _WS_SENDDOC_LOG_ID
            End Get
            Set(ByVal value As Long)
                _WS_SENDDOC_LOG_ID = value
            End Set
        End Property
        <Column(Storage:="_BOOK_NO", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property BookNo() As String
            Get
                Return _BOOK_NO
            End Get
            Set(ByVal value As String)
                _BOOK_NO = value
            End Set
        End Property
        <Column(Storage:="_REGISTER_DATE", DbType:="DateTime NOT NULL ", CanBeNull:=False)> _
        Public Property RegisterDate() As DateTime
            Get
                Return _REGISTER_DATE
            End Get
            Set(ByVal value As DateTime)
                _REGISTER_DATE = value
            End Set
        End Property
        <Column(Storage:="_EXPECTED_FINISH_DATE", DbType:="DateTime")> _
        Public Property ExpectedFinishDate() As System.Nullable(Of DateTime)
            Get
                Return _EXPECTED_FINISH_DATE
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EXPECTED_FINISH_DATE = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_DOC_NO", DbType:="VarChar(50)")> _
        Public Property CompanyDocNo() As String
            Get
                Return _COMPANY_DOC_NO
            End Get
            Set(ByVal value As String)
                _COMPANY_DOC_NO = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_DOC_DATE", DbType:="DateTime")> _
        Public Property CompanyDocDate() As System.Nullable(Of DateTime)
            Get
                Return _COMPANY_DOC_DATE
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _COMPANY_DOC_DATE = value
            End Set
        End Property
        <Column(Storage:="_REFER_TO", DbType:="VarChar(50)")> _
        Public Property ReferTo() As String
            Get
                Return _REFER_TO
            End Get
            Set(ByVal value As String)
                _REFER_TO = value
            End Set
        End Property
        <Column(Storage:="_GROUP_TITLE_CODE", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property GroupTitleCode() As String
            Get
                Return _GROUP_TITLE_CODE
            End Get
            Set(ByVal value As String)
                _GROUP_TITLE_CODE = value
            End Set
        End Property
        <Column(Storage:="_TITLE_NAME", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property TitleName() As String
            Get
                Return _TITLE_NAME
            End Get
            Set(ByVal value As String)
                _TITLE_NAME = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255) NOT NULL ", CanBeNull:=False)> _
        Public Property CompanyName() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
                _COMPANY_NAME = value
            End Set
        End Property
        <Column(Storage:="_COMPANY_SIGN", DbType:="VarChar(255)")> _
        Public Property CompanySign() As String
            Get
                Return _COMPANY_SIGN
            End Get
            Set(ByVal value As String)
                _COMPANY_SIGN = value
            End Set
        End Property
        <Column(Storage:="_REMARKS", DbType:="VarChar(255)")> _
        Public Property Remarks() As String
            Get
                Return _REMARKS
            End Get
            Set(ByVal value As String)
                _REMARKS = value
            End Set
        End Property
        <Column(Storage:="_ORG_CODE_OWNER", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property OrgCodeOwner() As String
            Get
                Return _ORG_CODE_OWNER
            End Get
            Set(ByVal value As String)
                _ORG_CODE_OWNER = value
            End Set
        End Property
        <Column(Storage:="_OFFICER_ID_APPORVE", DbType:="VarChar(13) NOT NULL ", CanBeNull:=False)> _
        Public Property OfficerIDApprove() As String
            Get
                Return _OFFICER_ID_APPORVE
            End Get
            Set(ByVal value As String)
                _OFFICER_ID_APPORVE = value
            End Set
        End Property
        <Column(Storage:="_BOOK_OUT_NO", DbType:="VarChar(50)")> _
        Public Property BookOutNo() As String
            Get
                Return _BOOK_OUT_NO
            End Get
            Set(ByVal value As String)
                _BOOK_OUT_NO = value
            End Set
        End Property
        <Column(Storage:="_BOOK_STATUS", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property BookStatus() As String
            Get
                Return _BOOK_STATUS
            End Get
            Set(ByVal value As String)
                _BOOK_STATUS = value
            End Set
        End Property
        <Column(Storage:="_CLOSE_DATE", DbType:="DateTime")> _
        Public Property CloseDate() As System.Nullable(Of DateTime)
            Get
                Return _CLOSE_DATE
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _CLOSE_DATE = value
            End Set
        End Property
        <Column(Storage:="_ORG_CLOSE_PROCESS", DbType:="VarChar(50) NOT NULL ", CanBeNull:=False)> _
        Public Property OrgCloseProcess() As String
            Get
                Return _ORG_CLOSE_PROCESS
            End Get
            Set(ByVal value As String)
                _ORG_CLOSE_PROCESS = value
            End Set
        End Property
        <Column(Storage:="_STAFF_ID_PROCESS", DbType:="VarChar(13) NOT NULL ", CanBeNull:=False)> _
        Public Property StaffIDProcess() As String
            Get
                Return _STAFF_ID_PROCESS
            End Get
            Set(ByVal value As String)
                _STAFF_ID_PROCESS = value
            End Set
        End Property
        <Column(Storage:="_STAFF_OTHER_PROCESS", DbType:="VarChar(255)")> _
        Public Property StaffOtherProcess() As String
            Get
                Return _STAFF_OTHER_PROCESS
            End Get
            Set(ByVal value As String)
                _STAFF_OTHER_PROCESS = value
            End Set
        End Property
    End Class
End Namespace

