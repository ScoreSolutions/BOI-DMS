Namespace DmsService
    <Serializable()> Public Class GetDocumentStatusResPara
        Dim _StatusList As DataTable
        Dim _err As String = ""

        Public Property StatusList() As DataTable
            Get
                Return _StatusList
            End Get
            Set(ByVal value As DataTable)
                _StatusList = value
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

