Namespace THeGIFResponse
    Public Class ReceiveRejectLetterNotifierResponsePara
        Dim _ProcessID As String = ""
        Dim _ProcessTime As String = ""
        Dim _RejectLetterNotifier As New SendRejectLetterNotifierResponsePara
        Dim _err As String = ""

        Public Property ProcessID() As String
            Get
                Return _processID.Trim
            End Get
            Set(ByVal value As String)
                _processID = value
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
        Public Property RejectLeterNotifier() As SendRejectLetterNotifierResponsePara
            Get
                Return _RejectLetterNotifier
            End Get
            Set(ByVal value As SendRejectLetterNotifierResponsePara)
                _RejectLetterNotifier = value
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

