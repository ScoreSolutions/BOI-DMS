﻿Namespace THeGIF
    Public Class CorrespondenceLetterDeleteRequestPara
        Dim _HeaderMessageID As String = ""
        Dim _HeaderTo As String = ""
        Dim _BodyProcessID As String = ""
        Public Property HeaderMessageID() As String
            Get
                Return _HeaderMessageID.Trim
            End Get
            Set(ByVal value As String)
                _HeaderMessageID = value
            End Set
        End Property
        Public Property HeaderTo() As String
            Get
                Return _HeaderTo.Trim
            End Get
            Set(ByVal value As String)
                _HeaderTo = value
            End Set
        End Property
        Public Property BodyProcessID() As String
            Get
                Return _BodyProcessID.Trim
            End Get
            Set(ByVal value As String)
                _BodyProcessID = value
            End Set
        End Property
    End Class
End Namespace
