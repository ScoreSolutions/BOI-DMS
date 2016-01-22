﻿Namespace THeGIFResponse
    Public Class CorrespondenceLetterOutboundResponsePara
        Dim _ProcessID As String = ""
        Dim _ProcessTime As String = ""
        Dim _GovernmentDocument As String = ""
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
        Public Property GovernmentDocument() As String
            Get
                Return _GovernmentDocument
            End Get
            Set(ByVal value As String)
                _GovernmentDocument = value
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

