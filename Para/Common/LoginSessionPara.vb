Namespace Common
    <Serializable()> Public Class LoginSessionPara
        Dim _LOGIN_HISTORY_ID As Long = 0
        Dim _USER_NAME As String = ""

        Public Property LOGIN_HISTORY_ID() As Long
            Get
                Return _LOGIN_HISTORY_ID
            End Get
            Set(ByVal value As Long)
                _LOGIN_HISTORY_ID = value
            End Set
        End Property
        Public Property USER_NAME() As String
            Get
                Return _USER_NAME
            End Get
            Set(ByVal value As String)
                _USER_NAME = value
            End Set
        End Property

    End Class
End Namespace

