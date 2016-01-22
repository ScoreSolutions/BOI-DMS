Namespace DmsService
    <Serializable()> Public Class StartSendDocumentResPara
        Dim _Result As Boolean = False
        Dim _SendRefID As Int16 = 0
        Dim _ErrorMessage As String = ""

        Public Property Result() As Boolean
            Get
                Return _Result
            End Get
            Set(ByVal value As Boolean)
                _Result = value
            End Set
        End Property

        Public Property SendREfID() As Int16
            Get
                Return _SendRefID
            End Get
            Set(ByVal value As Int16)
                _SendRefID = value
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

