Namespace Document
    Public Class SendInternalPara
        Dim _ORG_RECEIVE_ID As Long = 0
        Dim _ORG_NAME As String = ""
        Dim _ORG_ABB_NAME As String = ""
        Dim _STAFF_RECEIVE_ID As Long = 0
        Dim _STAFF_FULLNAME As String = ""
        Dim _STAFF_USERNAME As String = ""
        Dim _STAFF_APPROVE_ID As String = ""
        Dim _STAFF_APPROVE_FULLNAME As String = ""
        Dim _OBJECTIVE_ID As Long = 0
        Dim _REMARKS As String = ""

        Public Property ORG_RECEIVE_ID() As Long
            Get
                Return _ORG_RECEIVE_ID
            End Get
            Set(ByVal value As Long)
                _ORG_RECEIVE_ID = value
            End Set
        End Property
        Public Property ORG_NAME() As String
            Get
                Return _ORG_NAME.Trim
            End Get
            Set(ByVal value As String)
                _ORG_NAME = value
            End Set
        End Property
        Public Property ORG_ABB_NAME() As String
            Get
                Return _ORG_ABB_NAME.Trim
            End Get
            Set(ByVal value As String)
                _ORG_ABB_NAME = value
            End Set
        End Property
        Public Property STAFF_RECEIVE_ID() As Long
            Get
                Return _STAFF_RECEIVE_ID
            End Get
            Set(ByVal value As Long)
                _STAFF_RECEIVE_ID = value
            End Set
        End Property
        Public Property STAFF_FULLNAME() As String
            Get
                Return _STAFF_FULLNAME.Trim
            End Get
            Set(ByVal value As String)
                _STAFF_FULLNAME = value
            End Set
        End Property
        Public Property STAFF_USERNAME() As String
            Get
                Return _STAFF_USERNAME.Trim
            End Get
            Set(ByVal value As String)
                _STAFF_USERNAME = value
            End Set
        End Property
        Public Property STAFF_APPROVE_ID() As String
            Get
                Return _STAFF_APPROVE_ID.Trim
            End Get
            Set(ByVal value As String)
                _STAFF_APPROVE_ID = value
            End Set
        End Property
        Public Property STAFF_APPROVE_FULLNAME() As String
            Get
                Return _STAFF_APPROVE_FULLNAME.Trim
            End Get
            Set(ByVal value As String)
                _STAFF_APPROVE_FULLNAME = value
            End Set
        End Property

        Public Property OBJECTIVE_ID() As Long
            Get
                Return _OBJECTIVE_ID
            End Get
            Set(ByVal value As Long)
                _OBJECTIVE_ID = value
            End Set
        End Property

        Public Property REMARKS() As String
            Get
                Return _REMARKS.Trim
            End Get
            Set(ByVal value As String)
                _REMARKS = value
            End Set
        End Property
    End Class
End Namespace

