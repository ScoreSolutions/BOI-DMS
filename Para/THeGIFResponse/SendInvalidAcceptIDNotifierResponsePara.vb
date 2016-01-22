Namespace THeGIFResponse
    Public Class SendInvalidAcceptIDNotifierResponsePara
        Dim _ProcessID As String = ""
        Dim _ProcessTime As String = ""
        Dim _LetterID As String = ""
        Dim _AcceptID As String = ""
        Dim _CorrespondenceDate As String = ""
        Dim _Subject As String = ""
        Dim _AcceptDate As String = ""
        Dim _AcceptDepartmentCode As String = ""
        Dim _err As String = ""

        Public Property ProcessID() As String
            Get
                Return _ProcessID.Trim
            End Get
            Set(ByVal value As String)
                _ProcessID = value
            End Set
        End Property

        Public Property ProcessTime() As String
            Get
                Return _ProcessTime.Trim
            End Get
            Set(ByVal value As String)
                _ProcessTime = value
            End Set
        End Property

        Public Property LetterID() As String
            Get
                Return _LetterID.Trim
            End Get
            Set(ByVal value As String)
                _LetterID = value
            End Set
        End Property

        Public Property AcceptID() As String
            Get
                Return _AcceptID.Trim
            End Get
            Set(ByVal value As String)
                _AcceptID = value
            End Set
        End Property

        Public Property CorrespondenceDate() As String
            Get
                Return _CorrespondenceDate.Trim
            End Get
            Set(ByVal value As String)
                _CorrespondenceDate = value
            End Set
        End Property

        Public Property Subject() As String
            Get
                Return _Subject.Trim
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property

        Public Property AcceptDate() As String
            Get
                Return _AcceptDate.Trim
            End Get
            Set(ByVal value As String)
                _AcceptDate = value
            End Set
        End Property

        Public Property AcceptDepartmentCode() As String
            Get
                Return _AcceptDepartmentCode.Trim
            End Get
            Set(ByVal value As String)
                _AcceptDepartmentCode = value
            End Set
        End Property

        Public Property ErrorMessage() As String
            Get
                Return _err.Trim
            End Get
            Set(ByVal value As String)
                _err = value
            End Set
        End Property
    End Class
End Namespace

