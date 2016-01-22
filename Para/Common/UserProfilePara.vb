
Namespace Common
    <Serializable()> Public Class UserProfilePara
        'Public Class UserProfilePara
        Dim _SSO_ID As String = ""
        Dim _USER_IDCARDNO As String = ""
        Dim _USERNAME As String = ""
        Dim _TITLE_NAME As String = ""
        Dim _FIRST_NAME As String = ""
        Dim _LAST_NAME As String = ""
        Dim _SEX As String = ""
        Dim _POSITION_NAME As String = ""
        Dim _STAFF_LEVEL As String = ""
        Dim _DIVISION_NAME As String = ""
        Dim _DEPARTMENT_NAME As String = ""
        Dim _IS_SSO As String = ""
        Dim _LOGIN_HISTORY_ID As Long = 0
        Dim _ORG_DATA As New Para.TABLE.OrganizationPara
        Dim _OFFICER_DATA As New Para.TABLE.OfficerPara
        'Dim _MENU_LIST As String = ""
        Dim _EMAIL As String = ""

        Public Property SsoID() As String
            Get
                Return _SSO_ID
            End Get
            Set(ByVal value As String)
                _SSO_ID = value
            End Set
        End Property
        Public Property UserIDCardNo() As String
            Get
                Return _USER_IDCARDNO
            End Get
            Set(ByVal value As String)
                _USER_IDCARDNO = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
                _USERNAME = value
            End Set
        End Property

        Public Property TitleName() As String
            Get
                Return _TITLE_NAME
            End Get
            Set(ByVal value As String)
                _TITLE_NAME = value
            End Set
        End Property

        Public Property FirstName() As String
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As String)
                _FIRST_NAME = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As String)
                _LAST_NAME = value
            End Set
        End Property

        Public Property Sex() As String
            Get
                Return _SEX
            End Get
            Set(ByVal value As String)
                _SEX = value
            End Set
        End Property

        Public Property PostionName() As String
            Get
                Return _POSITION_NAME
            End Get
            Set(ByVal value As String)
                _POSITION_NAME = value
            End Set
        End Property

        Public Property StaffLevel() As String
            Get
                Return _STAFF_LEVEL
            End Get
            Set(ByVal value As String)
                _STAFF_LEVEL = value
            End Set
        End Property

        Public Property DivisionName() As String
            Get
                Return _DIVISION_NAME
            End Get
            Set(ByVal value As String)
                _DIVISION_NAME = value
            End Set
        End Property

        Public Property DepartmentName() As String
            Get
                Return _DEPARTMENT_NAME
            End Get
            Set(ByVal value As String)
                _DEPARTMENT_NAME = value
            End Set
        End Property

        Public Property IS_SSO() As String
            Get
                Return _IS_SSO
            End Get
            Set(ByVal value As String)
                _IS_SSO = value
            End Set
        End Property

        Public Property LOGIN_HISTORY_ID() As Long
            Get
                Return _LOGIN_HISTORY_ID
            End Get
            Set(ByVal value As Long)
                _LOGIN_HISTORY_ID = value
            End Set
        End Property

        'Public Property MENU_LIST() As String
        '    Get
        '        Return _MENU_LIST
        '    End Get
        '    Set(ByVal value As String)
        '        _MENU_LIST = value
        '    End Set
        'End Property


        Public Property ORG_DATA() As Para.TABLE.OrganizationPara
            Get
                Return _ORG_DATA
            End Get
            Set(ByVal value As Para.TABLE.OrganizationPara)
                _ORG_DATA = value
            End Set
        End Property

        Public Property OFFICER_DATA() As Para.TABLE.OfficerPara
            Get
                Return _OFFICER_DATA
            End Get
            Set(ByVal value As Para.TABLE.OfficerPara)
                _OFFICER_DATA = value
            End Set
        End Property

        Public Property EMAIL() As String
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As String)
                _EMAIL = value
            End Set
        End Property

    End Class
End Namespace