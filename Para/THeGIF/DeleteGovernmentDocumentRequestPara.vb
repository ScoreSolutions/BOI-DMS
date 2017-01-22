Namespace THeGIF
    Public Class DeleteGovernmentDocumentRequestPara
        '3.2.13	การขอลบหนังสือภายนอกเพื่อจะส่งหนังสือใหม่ (กรณีได้รับหนังสือปฏิเสธหรือแจ้งหนังสือผิด) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
        Dim _HeaderMessageID As String = ""
        Dim _HeaderTo As String = ""
        Dim _BodyLetterID As String = ""
        Dim _BodyCorrespondenceDate As String = ""
        Dim _BodySenderDepartmentCode As String = ""
        Dim _BodyAcceptDepartmentCode As String = ""

        Public Property HeaderMessageID() As String
            Get
                Return _HeaderMessageID.Trim
            End Get
            Set(ByVal value As String)
                _HeaderMessageID = value
            End Set
        End Property

        Public Property HeaderTo() As String
            Get
                Return _HeaderTo.Trim
            End Get
            Set(ByVal value As String)
                _HeaderTo = value
            End Set
        End Property
        Public Property BodyLetterID() As String
            Get
                Return _BodyLetterID.Trim
            End Get
            Set(ByVal value As String)
                _BodyLetterID = value
            End Set
        End Property
        Public Property BodyCorrespondenceDate() As String
            Get
                Return _BodyCorrespondenceDate.Trim
            End Get
            Set(ByVal value As String)
                _BodyCorrespondenceDate = value
            End Set
        End Property
        Public Property BodySenderDepartmentCode() As String
            Get
                Return _BodySenderDepartmentCode.Trim
            End Get
            Set(ByVal value As String)
                _BodySenderDepartmentCode = value
            End Set
        End Property
        Public Property BodyAcceptDepartmentCode() As String
            Get
                Return _BodyAcceptDepartmentCode.Trim
            End Get
            Set(ByVal value As String)
                _BodyAcceptDepartmentCode = value
            End Set
        End Property
    End Class
End Namespace
