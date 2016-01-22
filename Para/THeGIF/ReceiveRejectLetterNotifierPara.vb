Namespace THeGIF
    Public Class ReceiveRejectLetterNotifierPara
        '5.15	การขอรับหนังสือปฏิเสธ(RejectLetterNotifier) ของระบบสารบรรณอิเล็กทรอนิกส์ต้นทาง กับ eCMSต้นทาง
        Dim _HeaderMessageID As String = ""
        Dim _HeaderTo As String = ""

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
    End Class
End Namespace

