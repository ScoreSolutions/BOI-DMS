Namespace DmsService
    <Serializable()> Public Class FinishSendDocumentResPara
        Dim _Result As Boolean = False
        Dim _ErrorMessage As String = ""

        Public Property Result() As Boolean
            Get
                Return _Result
            End Get
            Set(ByVal value As Boolean)
                _Result = value
            End Set
        End Property

        Public Property ErrorMessage() As String
            Get
                Return _ErrorMessage
            End Get
            Set(ByVal value As String)
                _ErrorMessage = value
            End Set
        End Property
    End Class
End Namespace

