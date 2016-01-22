Namespace THeGIF
    Public Class DeleteInvalidLetterNotifierPara
        '5.20	การลบหนังสือแจ้งหนังสือผิด(InvalidLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง เพื่อขอรับหนังสือฉบับใหม่
        Dim _HeaderMessageID As String = ""
        Dim _HeaderTo As String = ""
        Dim _BodyProcessID As String = ""

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

        Public Property BodyProcessID() As String
            Get
                Return _BodyProcessID.Trim
            End Get
            Set(ByVal value As String)
                _BodyProcessID = value
            End Set
        End Property
    End Class
End Namespace

