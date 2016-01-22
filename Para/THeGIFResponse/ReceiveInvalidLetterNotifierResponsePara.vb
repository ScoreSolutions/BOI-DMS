Namespace THeGIFResponse
    Public Class ReceiveInvalidLetterNotifierResponsePara
        Dim _ProcessID As String = ""
        Dim _ProcessTime As String = ""
        Dim _InvalidLetterNotifier As New SendInvalidLetterNotifierResponsePara
        Dim _err As String = ""

        Public Property ProcessID() As String
            Get
                Return _ProcessID.Trim
            End Get
            Set(ByVal value As String)
                _ProcessID = value
            End Set
        End Property
        Public Property ProcessTime() As String
            Get
                Return _ProcessTime.Trim
            End Get
            Set(ByVal value As String)
                _ProcessTime = value
            End Set
        End Property
        Public Property InvalidLetterNotifier() As SendInvalidLetterNotifierResponsePara
            Get
                Return _InvalidLetterNotifier
            End Get
            Set(ByVal value As SendInvalidLetterNotifierResponsePara)
                _InvalidLetterNotifier = value
            End Set
        End Property
        Public Property ErrorMessage() As String
            Get
                Return _err.Trim
            End Get
            Set(ByVal value As String)
                _err = value
            End Set
        End Property
    End Class
End Namespace

