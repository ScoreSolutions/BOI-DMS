Namespace THeGIF
    Public Class OutboundStatusRequestPara
        '5.25	การตรวจสอบสถานการณ์ส่งหนังสือของ eCMS

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

