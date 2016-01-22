Namespace THeGIF
    Public Class SendInvalidLetterNotifierPara
        '5.17	การส่งหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) จาก ระบบสารบรรณปลายทาง  ไป eCMSปลายทาง
        Dim _HeaderMessageID As String = ""
        Dim _HeaderTo As String = ""
        Dim _BodyLetterID As String = ""
        Dim _BodyCorrespondenceDate As String = ""
        Dim _BodySubject As String = ""

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
                _HeaderTo.Trim()
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

        Public Property BodySubject() As String
            Get
                Return _BodySubject.Trim
            End Get
            Set(ByVal value As String)
                _BodySubject = value
            End Set
        End Property
    End Class
End Namespace

