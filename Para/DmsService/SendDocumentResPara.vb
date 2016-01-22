Namespace DmsService
    <Serializable()> Public Class SendDocumentResPara
        Dim _Result As Boolean = False
        Dim _err As String = ""

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
                Return _err
            End Get
            Set(ByVal value As String)
                _err = value
            End Set
        End Property
    End Class
End Namespace

