Namespace Document
    Public Class SendCirclePara
        Dim _book_no As String = ""
        Dim _send_list As New DataTable

        Public Property BOOK_NO() As String
            Get
                Return _book_no.Trim
            End Get
            Set(ByVal value As String)
                _book_no = value
            End Set
        End Property
        Public Property SEND_LIST() As DataTable
            Get
                Return _send_list
            End Get
            Set(ByVal value As DataTable)
                _send_list = value
            End Set
        End Property
    End Class
End Namespace

