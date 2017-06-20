Namespace SSO
    Public Class SSOUserPara
        Dim _UserID As String = ""
        Dim _Username As String = ""
        Dim _TitleNameTh As String = ""
        Dim _Firstname As String = ""
        Dim _Lastname As String = ""
        Dim _TitleNameEn As String = ""
        Dim _FirstnameEn As String = ""
        Dim _LastnameEn As String = ""
        Dim _CardId As String = ""
        Dim _IsSuccess As Boolean = False
        Dim _ErrorMessage As String = ""

        Public Property UserID() As String
            Get
                Return _UserID.Trim
            End Get
            Set(ByVal value As String)
                _UserID = value
            End Set
        End Property
        Public Property Username() As String
            Get
                Return _Username.Trim
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property

        Public Property TitleNameTh() As String
            Get
                Return _TitleNameTh.Trim
            End Get
            Set(ByVal value As String)
                _TitleNameTh = value
            End Set
        End Property

        Public Property FirstName() As String
            Get
                Return _Firstname.Trim
            End Get
            Set(ByVal value As String)
                _Firstname = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _Lastname.Trim
            End Get
            Set(ByVal value As String)
                _Lastname = value
            End Set
        End Property

        Public Property TitleNameEn() As String
            Get
                Return _TitleNameEn.Trim
            End Get
            Set(ByVal value As String)
                _TitleNameEn = value
            End Set
        End Property

        Public Property FirstNameEn() As String
            Get
                Return _FirstnameEn.Trim
            End Get
            Set(ByVal value As String)
                _FirstnameEn = value
            End Set
        End Property

        Public Property LastNameEn() As String
            Get
                Return _LastnameEn.Trim
            End Get
            Set(ByVal value As String)
                _LastnameEn = value
            End Set
        End Property

        Public Property CardId() As String
            Get
                Return _CardId.Trim
            End Get
            Set(ByVal value As String)
                _CardId = value
            End Set
        End Property
        Public Property IsSuccess() As Boolean
            Get
                Return _IsSuccess
            End Get
            Set(ByVal value As Boolean)
                _IsSuccess = value
            End Set
        End Property
        Public Property ErrorMessage() As String
            Get
                Return _ErrorMessage.Trim
            End Get
            Set(ByVal value As String)
                _ErrorMessage = value
            End Set
        End Property
    End Class
End Namespace

