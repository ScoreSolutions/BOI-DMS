Namespace Document
    Public Class SendInternalSelectedPara
        Dim _SelectedRowID As DataTable = New DataTable
        Dim _SelectedBookNo As String = ""

        Public Property SelectedRowID() As DataTable
            Get
                Return _SelectedRowID
            End Get
            Set(ByVal value As DataTable)
                _SelectedRowID = value
            End Set
        End Property
        Public Property SelectedBookNo() As String
            Get
                Return _SelectedBookNo.Trim
            End Get
            Set(ByVal value As String)
                _SelectedBookNo = value
            End Set
        End Property
    End Class
End Namespace

