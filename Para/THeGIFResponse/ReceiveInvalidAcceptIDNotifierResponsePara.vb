Namespace THeGIFResponse
    Public Class ReceiveInvalidAcceptIDNotifierResponsePara
        Dim _ProcessID As String = ""
        Dim _ProcessTime As String = ""
        Dim _InvalidAcceptIDNotifier As New SendInvalidAcceptIDNotifierResponsePara
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
        Public Property InvalidAcceptIDNotifier() As SendInvalidAcceptIDNotifierResponsePara
            Get
                Return _InvalidAcceptIDNotifier
            End Get
            Set(ByVal value As SendInvalidAcceptIDNotifierResponsePara)
                _InvalidAcceptIDNotifier = value
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

